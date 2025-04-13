using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using CriWare;
using XeSys;
using System.Collections;
using System;
using System.Text;
using System.Linq;

namespace XeApp.Game.Menu
{
	public class GoDivaResultAnimSetting
	{
		public List<float> delayTimeList = new List<float>(); // 0x8
		public List<string> animNameList = new List<string>(); // 0xC
		public string queSheetName; // 0x10
	}

	public class GoDivaGrowResultLayoutController : LayoutUGUIScriptBase
	{
		private class GaugeLayout
		{
			public List<AbsoluteLayout> layout = new List<AbsoluteLayout>(); // 0x8
		}

		private JLCHNKIHGHK viewEventResultData; // 0x14
		private AbsoluteLayout m_layoutRoot; // 0x18
		private AbsoluteLayout[] m_layoutBonus = new AbsoluteLayout[3]; // 0x1C
		private AbsoluteLayout[] m_layoutParamMaxIcon = new AbsoluteLayout[3]; // 0x20
		private GaugeLayout[] m_beforeGaugeLayout = new GaugeLayout[3]; // 0x24
		private GaugeLayout[] m_afterGaugeLayout = new GaugeLayout[3]; // 0x28
		[SerializeField]
		private Text m_textPoint; // 0x2C
		[SerializeField]
		private Text m_textPointEf; // 0x30
		[SerializeField]
		private Text[] m_textBonusExp = new Text[3]; // 0x34
		[SerializeField]
		private Text[] m_textGauge = new Text[3]; // 0x38
		[SerializeField]
		private NumberBase[] m_levelCapNum = new NumberBase[3]; // 0x3C
		[SerializeField]
		private NumberBase[] m_levelNum = new NumberBase[3]; // 0x40
		[SerializeField]
		private NumberBase[] m_totalExpNum = new NumberBase[3]; // 0x44
		private float m_gaugeFinishTime = 3.0f; // 0x48
		private Matrix23 m_identity; // 0x4C
		private bool m_isSkiped; // 0x64
		private bool m_isStarted; // 0x65
		private bool m_isLoading = true; // 0x66
		private bool m_isLoadingModel; // 0x67
		private int m_voiceType = 1; // 0x68
		private SimpleDivaVoiceSetting m_voiceSetting = new SimpleDivaVoiceSetting(); // 0x6C
		private GoDivaResultBalloonLayoutController m_balloonController; // 0x70
		private MenuDivaManager m_divaManager; // 0x74
		private DivaResource m_divaResource; // 0x78
		private SimpleDivaAnimation m_simpleDivaAnimation; // 0x7C
		private GoDivaResultAnimSetting m_animSetting; // 0x80
		private SimpleDivaObject m_divaObject; // 0x84
		private Coroutine m_playVoiceCoroutine; // 0x88
		private Coroutine m_playDivaAnimCoroutine; // 0x8C
		private CriAtomExPlayback m_countUpSEPlayback; // 0x90
		private CriAtomExPlayback m_countDivaExpUpSEPlayback; // 0x94

		// RVA: 0xE13D08 Offset: 0xE13D08 VA: 0xE13D08
		private void OnDisable() { }

		// RVA: 0xE13D5C Offset: 0xE13D5C VA: 0xE13D5C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewById("sw_g_r_diva_grow_anim") as AbsoluteLayout;
			m_layoutBonus[0] = (layout.FindViewById("sw_g_r_bonus_onoff_anim_soul") as AbsoluteLayout).FindViewById("sw_g_r_bonus_anim") as AbsoluteLayout;
			m_layoutBonus[1] = (layout.FindViewById("sw_g_r_bonus_onoff_anim_voice") as AbsoluteLayout).FindViewById("sw_g_r_bonus_anim") as AbsoluteLayout;
			m_layoutBonus[2] = (layout.FindViewById("sw_g_r_bonus_onoff_anim_charm") as AbsoluteLayout).FindViewById("sw_g_r_bonus_anim") as AbsoluteLayout;
			m_layoutParamMaxIcon[0] = (layout.FindViewById("sw_guage_soul") as AbsoluteLayout).FindViewById("swtbl_exp") as AbsoluteLayout;
			m_layoutParamMaxIcon[1] = (layout.FindViewById("sw_guage_voice") as AbsoluteLayout).FindViewById("swtbl_exp") as AbsoluteLayout;
			m_layoutParamMaxIcon[2] = (layout.FindViewById("sw_guage_charm") as AbsoluteLayout).FindViewById("swtbl_exp") as AbsoluteLayout;
			Func<string,string,GaugeLayout> f = (string viewId, string name) =>
			{
				//0xE17074
				AbsoluteLayout abs = layout.FindViewById(viewId) as AbsoluteLayout;
				GaugeLayout res = new GaugeLayout();
				res.layout.Add(abs.FindViewById("guage_" + name) as AbsoluteLayout);
				res.layout.Add(abs.FindViewById("g_r_event_guage_" + name + "_2") as AbsoluteLayout);
				res.layout.Add(abs.FindViewById("g_r_event_guage_" + name + "_03") as AbsoluteLayout);
				res.layout.Add(abs.FindViewById("guage_ef") as AbsoluteLayout);
				return res;
			};
			Func<string, GaugeLayout> f2 = (string viewId) =>
			{
				//0xE174EC
				AbsoluteLayout abs = layout.FindViewById(viewId) as AbsoluteLayout;
				GaugeLayout res = new GaugeLayout();
				res.layout.Add(abs.FindViewById("black_01") as AbsoluteLayout);
				res.layout.Add(abs.FindViewById("black_02") as AbsoluteLayout);
				res.layout.Add(abs.FindViewById("guage_ef_plus") as AbsoluteLayout);
				res.layout.Add(abs.FindViewById("sw_jlv_plus_out_anim") as AbsoluteLayout);
				return res;
			};
			m_beforeGaugeLayout[0] = f.Invoke("swfrm_soul", "soul");
			m_afterGaugeLayout[0] = f2.Invoke("swfrm_soul");
			m_beforeGaugeLayout[1] = f.Invoke("swfrm_voice", "voice");
			m_afterGaugeLayout[1] = f2.Invoke("swfrm_voice");
			m_beforeGaugeLayout[2] = f.Invoke("swfrm_charm", "charm");
			m_afterGaugeLayout[2] = f2.Invoke("swfrm_charm");
			BetterOutline b = m_textGauge[0].gameObject.AddComponent<BetterOutline>();
			b.effectDistance = new Vector2(2, -2);
			b = m_textGauge[1].gameObject.AddComponent<BetterOutline>();
			b.effectDistance = new Vector2(2, -2);
			b = m_textGauge[2].gameObject.AddComponent<BetterOutline>();
			b.effectDistance = new Vector2(2, -2);
			if(m_divaResource == null)
			{
				GameObject g = new GameObject("DivaResourceObj");
				g.transform.SetParent(transform);
				m_divaResource = g.AddComponent<DivaResource>();
			}
			Loaded();
			return true;
		}

		// // RVA: 0xE14FD4 Offset: 0xE14FD4 VA: 0xE14FD4
		public void Setup(JLCHNKIHGHK viewEventData, GoDivaResultBalloonLayoutController balloonController)
		{
			m_divaManager = MenuScene.Instance.divaManager;
			m_divaManager.ApplyCameraPos(viewEventData.AHHJLDLAPAN_DivaId, DivaMenuParam.CameraPosType.Default);
			m_balloonController = balloonController;
			viewEventResultData = viewEventData;
			m_textPoint.text = viewEventData.JKFCHNEININ_GetPoint.ToString();
			m_textPointEf.text = viewEventData.JKFCHNEININ_GetPoint.ToString();
			Action<int> act = (int paramType) =>
			{
				//0xE17878
				if(viewEventData.FMMNAEJEIFF_BeforeLevel[paramType] == viewEventResultData.OMOLFAKIDIC_LevelCap)
				{
					m_layoutParamMaxIcon[paramType].StartAllAnimGoStop("02");
					SetExpGauge((JLCHNKIHGHK.GDJKDOMAAPG)paramType, 1, 1);
					SetAddExpGauge((JLCHNKIHGHK.GDJKDOMAAPG)paramType, 1, 1);
				}
				else
				{
					int currentExp = viewEventData.IADKEFDENEG_PrevExp[paramType];
					int needExp = GetNextExp(viewEventData.MKOIJCGNGGI_StartLevel[paramType], (JLCHNKIHGHK.GDJKDOMAAPG)paramType);
					SetExpGauge((JLCHNKIHGHK.GDJKDOMAAPG)paramType, currentExp, needExp);
					SetAddExpGauge((JLCHNKIHGHK.GDJKDOMAAPG)paramType, currentExp, needExp);
					m_textGauge[paramType].text = currentExp + "/" + needExp;
					m_layoutParamMaxIcon[paramType].StartAllAnimGoStop("01");
				}
			};
			for(int i = 0; i < 3; i++)
			{
				if(viewEventData.OGOJCIIINBG_BonusExp[i] == 0 || viewEventData.OGOJCIIINBG_BonusExp[i] == 100)
				{
					//LAB_00e15314
					m_textBonusExp[i].text = "";
					m_layoutBonus[i].StartAllAnimGoStop("02");
				}
				else
				{
					StringBuilder str = new StringBuilder();
					str.SetFormat(MessageManager.Instance.GetMessage("menu", "godiva_result_bonus"), viewEventData.OGOJCIIINBG_BonusExp[i] / 100);
					m_textBonusExp[i].text = str.ToString();
				}
				m_totalExpNum[i].SetNumber(0, 0);
				m_levelNum[i].SetNumber(viewEventData.FMMNAEJEIFF_BeforeLevel[i], 0);
				act(i);
			}
			m_levelCapNum[0].SetNumber(viewEventData.OMOLFAKIDIC_LevelCap, 0);
			m_levelCapNum[1].SetNumber(viewEventData.OMOLFAKIDIC_LevelCap, 0);
			m_levelCapNum[2].SetNumber(viewEventData.OMOLFAKIDIC_LevelCap, 0);
			m_isLoadingModel = true;
			this.StartCoroutineWatched(Co_LoadDivaResource());
			m_isLoading = false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x715E0C Offset: 0x715E0C VA: 0x715E0C
		// RVA: 0xE15968 Offset: 0xE15968 VA: 0xE15968
		public IEnumerator Release()
		{
			//0xE1BD14
			if(m_playVoiceCoroutine != null)
				this.StopCoroutineWatched(m_playVoiceCoroutine);
			if(m_playDivaAnimCoroutine != null)
				this.StopCoroutineWatched(m_playDivaAnimCoroutine);
			if(m_simpleDivaAnimation != null)
			{
				m_simpleDivaAnimation.StopVoice();
				while(m_simpleDivaAnimation.IsPlayingVoice())
					yield return null;
				SoundResource.RemoveCueSheet(m_animSetting.queSheetName);
				m_simpleDivaAnimation.Release();
				Destroy(m_simpleDivaAnimation.gameObject);
			}
		}

		// // RVA: 0xE15A14 Offset: 0xE15A14 VA: 0xE15A14
		public bool IsSetup()
		{
			return !m_isLoading && !m_isLoadingModel;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x715E84 Offset: 0x715E84 VA: 0x715E84
		// // RVA: 0xE158DC Offset: 0xE158DC VA: 0xE158DC
		private IEnumerator Co_LoadDivaResource()
		{
			//0xE19DE4
			yield return this.StartCoroutineWatched(Co_LoadSimpleDivaAnimation());
			m_animSetting = m_simpleDivaAnimation.CreateGoDivaAnimSetting(viewEventResultData.AHHJLDLAPAN_DivaId, viewEventResultData.HPPBOKAGECM_IsBonusPop);
			m_voiceType = 1;
			for(int i = 0; i < viewEventResultData.HGMAAIJFPOI_AfterLevel.Length; i++)
			{
				if(viewEventResultData.HGMAAIJFPOI_AfterLevel[i] != viewEventResultData.FMMNAEJEIFF_BeforeLevel[i])
				{
					m_voiceType = 2;
					break;
				}
			}
			if(viewEventResultData.HPPBOKAGECM_IsBonusPop)
				m_voiceType = 3;
			m_voiceSetting.m_isSimpleLipSync = true;
			m_voiceSetting.m_voiceSetting = new SimpleVoicePlayer.VoiceSetting();
			if(m_voiceType == 3)
			{
				m_voiceSetting.m_voiceSetting.m_queFormat = "m_result_bonus_000";
			}
			else if(m_voiceType == 2)
			{
				m_voiceSetting.m_voiceSetting.m_queFormat = "m_result_lvup_000";
			}
			else if(m_voiceType == 1)
			{
				m_voiceSetting.m_voiceSetting.m_queFormat = "m_result_exp_000";
			}
			m_simpleDivaAnimation.LoadGoDivaResource(viewEventResultData.AHHJLDLAPAN_DivaId, viewEventResultData.DAJGPBLEEOB_CostumeId, viewEventResultData.HEHKNMCDBJJ_ColorId, m_animSetting);
			yield return new WaitWhile(() =>
			{
				//0xE16E1C
				return m_simpleDivaAnimation.m_IsLoading;
			});
			m_divaObject = m_simpleDivaAnimation.transform.Find("SimpleDivaPrefab").GetComponent<SimpleDivaObject>();
			m_divaObject.setAdjuster();
			m_divaObject.gameObject.SetActive(true);
			m_simpleDivaAnimation.transform.SetParent(m_divaManager.transform);
			if(m_animSetting.animNameList.Count == 3)
			{
				m_divaObject.Play("idle");
			}
			else
			{
				m_simpleDivaAnimation.StartIdleMotion();
			}
			m_simpleDivaAnimation.SetVisible(false);
			m_isLoadingModel = false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x715EFC Offset: 0x715EFC VA: 0x715EFC
		// // RVA: 0xE15A5C Offset: 0xE15A5C VA: 0xE15A5C
		private IEnumerator Co_LoadSimpleDivaAnimation()
		{
			//0xE1A540
			if(m_simpleDivaAnimation == null)
			{
				bool isLoaded = false;
				ResourcesManager.Instance.Load("Menu/Prefab/3dModel/SimpleDivaAnimation", (FileResultObject anm) =>
				{
					//0xE17C74
					m_simpleDivaAnimation = (Instantiate(anm.unityObject) as GameObject).GetComponent<SimpleDivaAnimation>();
					isLoaded = true;
					return false;
				});
				yield return new WaitUntil(() =>
				{
					//0xE17D98
					return isLoaded;
				});
				m_simpleDivaAnimation.m_divaResource = m_divaResource;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x715F74 Offset: 0x715F74 VA: 0x715F74
		// // RVA: 0xE15B08 Offset: 0xE15B08 VA: 0xE15B08
		public IEnumerator Co_BeginAnim()
		{
			//0xE17EA8
			m_isStarted = true;
			m_simpleDivaAnimation.SetVisible(true);
			yield return Co.R(Co_EnterGetPoint());
			yield return Co.R(Co_EnterGetExp());
			yield return Co.R(Co_CountUpExp());
			PlayDivaExpCountUpLoopSE();
			int finishCount = 0;
			for(int i = 0; i < 3; i++)
			{
				this.StartCoroutineWatched(Co_CountUpExpGauge((JLCHNKIHGHK.GDJKDOMAAPG) i, () =>
				{
					//0xE17DA8
					finishCount++;
				}));
			}
			yield return new WaitWhile(() =>
			{
				//0xE17DB8
				return finishCount != 3;
			});
			m_countDivaExpUpSEPlayback.Stop(false);
			yield return new WaitForSeconds(0.5f);
			yield return Co.R(Co_ShowLevelupPopup());
			m_playDivaAnimCoroutine = this.StartCoroutineWatched(Co_PlayDivaAnim());
		}

		// // RVA: 0xE15BB4 Offset: 0xE15BB4 VA: 0xE15BB4
		// public void EndAnim() { }

		// [IteratorStateMachineAttribute] // RVA: 0x715FEC Offset: 0x715FEC VA: 0x715FEC
		// // RVA: 0xE15C30 Offset: 0xE15C30 VA: 0xE15C30
		private IEnumerator Co_EnterGetPoint()
		{
			AbsoluteLayout layout;

			//0xE19B38
			layout = m_layoutRoot;
			m_layoutRoot.StartChildrenAnimGoStop("go_get_pt", "st_get_pt");
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_035);
			yield return Co.R(Co_WaitAnim(layout, true));
			layout.StartChildrenAnimGoStop("go_window", "st_window");
			yield return Co.R(Co_WaitAnim(layout, true));
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_028);

		}

		// [IteratorStateMachineAttribute] // RVA: 0x716064 Offset: 0x716064 VA: 0x716064
		// // RVA: 0xE15CDC Offset: 0xE15CDC VA: 0xE15CDC
		private IEnumerator Co_EnterGetExp()
		{
			AbsoluteLayout layout;

			//0xE198B4
			layout = m_layoutRoot;
			layout.StartChildrenAnimGoStop("go_get_exp", "st_get_exp");
			yield return Co.R(Co_WaitAnim(layout, true));
			layout.StartChildrenAnimGoStop("go_exp", "st_exp");
			yield return Co.R(Co_WaitAnim(layout, true));
			layout.StartChildrenAnimGoStop("go_guage", "st_guage");
			yield return Co.R(Co_WaitAnim(layout, true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7160DC Offset: 0x7160DC VA: 0x7160DC
		// // RVA: 0xE15D88 Offset: 0xE15D88 VA: 0xE15D88
		private IEnumerator Co_CountUpExp()
		{
			//0xE18348
			PlayCountUpLoopSE();
			int finishCount = 0;
			for(int i = 0; i < 3; i++)
			{
				int count = i;
				this.StartCoroutineWatched(Co_Countup(0, viewEventResultData.GMHOPMFPBJG_GetExp[i], 0.3f, (int num) =>
				{
					//0xE17E00
					m_totalExpNum[count].SetNumber(num, 0);
				}, () =>
				{
					//0xE17DD4
					finishCount++;
				}));
			}
			yield return new WaitWhile(() =>
			{
				//0xE17DE4
				return finishCount != 3;
			});
			m_countUpSEPlayback.Stop(false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x716154 Offset: 0x716154 VA: 0x716154
		// // RVA: 0xE15E34 Offset: 0xE15E34 VA: 0xE15E34
		private IEnumerator Co_CountUpExpGauge(JLCHNKIHGHK.GDJKDOMAAPG divaParamType, Action onFinishCallback)
		{
			float currentTime; // 0x1C
			float timeLength; // 0x20
			int upLevel; // 0x24
			int startLevel; // 0x28
			int totalLevel; // 0x2C
			int startExp; // 0x30
			float getExp; // 0x34
			float endExp; // 0x38
			int startNeedExp; // 0x3C
			int currentLevel; // 0x40
			int addLevel; // 0x44

			//0xE18738
			if(viewEventResultData.FMMNAEJEIFF_BeforeLevel[(int)divaParamType] != viewEventResultData.OMOLFAKIDIC_LevelCap)
			{
				currentTime = 0;
				timeLength = m_gaugeFinishTime;
				upLevel = viewEventResultData.HGMAAIJFPOI_AfterLevel[(int)divaParamType] - viewEventResultData.FMMNAEJEIFF_BeforeLevel[(int)divaParamType];
				startLevel = viewEventResultData.MKOIJCGNGGI_StartLevel[(int)divaParamType];
				totalLevel = viewEventResultData.FMMNAEJEIFF_BeforeLevel[(int)divaParamType];
				startExp = viewEventResultData.IADKEFDENEG_PrevExp[(int)divaParamType];
				getExp = viewEventResultData.GMHOPMFPBJG_GetExp[(int)divaParamType];
				endExp = viewEventResultData.MKPAIJGMHOJ_NextExp[(int)divaParamType];
				startNeedExp = GetNextExp(startLevel, divaParamType) - startExp;
				currentLevel = startLevel;
				addLevel = 0;
				while(true)
				{
					if(getExp != 0)
					{
						if(viewEventResultData.FMMNAEJEIFF_BeforeLevel[(int)divaParamType] != viewEventResultData.OMOLFAKIDIC_LevelCap)
						{
							currentTime += TimeWrapper.deltaTime;
							currentTime = Mathf.Min(currentTime, timeLength);
							float f = XeSys.Math.Tween.EasingInOutCubic(0, getExp, currentTime / timeLength);
							f += startExp;
							float exp = startExp;
							for(int i = 0; i < addLevel - 1; i++)
							{
								exp = GetNextExp(startLevel + 1 + i, divaParamType);
								f -= exp;
							}
							if(addLevel != 0)
							{
								exp = startNeedExp;
								f -= startNeedExp;
							}
							SetAddExpGauge(divaParamType, (int)f, GetNextExp(currentLevel, divaParamType));
							if(GetNextExp(currentLevel, divaParamType) <= f)
							{
								SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_015);
								startExp = 0;
								currentLevel++;
								addLevel++;
								m_levelNum[(int)divaParamType].SetNumber(addLevel + totalLevel, 0);
								if(addLevel + totalLevel != viewEventResultData.OMOLFAKIDIC_LevelCap)
								{
									SetExpGauge(divaParamType, 0, GetNextExp(currentLevel, divaParamType));
								}
							}
							if(addLevel + totalLevel == viewEventResultData.OMOLFAKIDIC_LevelCap)
							{
								m_layoutParamMaxIcon[(int)divaParamType].StartAllAnimGoStop("02");
								break;
							}
							else if(currentTime != timeLength && !m_isSkiped)
								yield return null;
							else
								break;
						}
						else
							break;
					}
					else
						break;
				}
				currentLevel = viewEventResultData.HGMAAIJFPOI_AfterLevel[(int)divaParamType];
				if(upLevel == 0)
				{
					//LAB_00e19114
					if(currentLevel != viewEventResultData.OMOLFAKIDIC_LevelCap)
					{
						//LAB_00e19194
						SetAddExpGauge(divaParamType, (int)endExp, (int)GetNextExp(viewEventResultData.CLDDEGBGJGK[(int)divaParamType], divaParamType));
						//LAB_00e19214
					}
				}
				else
				{
					if(currentLevel != viewEventResultData.OMOLFAKIDIC_LevelCap)
					{
						SetExpGauge(divaParamType, 0, GetNextExp(viewEventResultData.CLDDEGBGJGK[(int)divaParamType], divaParamType));
						//LAB_00e19194
						SetAddExpGauge(divaParamType, (int)endExp, (int)GetNextExp(viewEventResultData.CLDDEGBGJGK[(int)divaParamType], divaParamType));
						//LAB_00e19214
					}
					else
					{
						if(upLevel == 0)
						{
							//LAB_00e19114
							if(currentLevel != viewEventResultData.OMOLFAKIDIC_LevelCap)
							{
								//LAB_00e19194
								SetAddExpGauge(divaParamType, (int)endExp, (int)GetNextExp(viewEventResultData.CLDDEGBGJGK[(int)divaParamType], divaParamType));
								//LAB_00e19214
							}
						}
						else
						{
							if(currentLevel != viewEventResultData.OMOLFAKIDIC_LevelCap)
							{
								//LAB_00e19214
							}
							if(upLevel != 1)
							{
								SetExpGauge(divaParamType, 0, 0);
							}
							m_layoutParamMaxIcon[(int)divaParamType].StartAllAnimGoStop("02");
							SetAddExpGauge(divaParamType, 1, 1);
						}
					}
				}
				//LAB_00e19214
				m_levelNum[(int)divaParamType].SetNumber(currentLevel, 0);
			}
			//LAB_00e19284
			if(onFinishCallback != null)
				onFinishCallback();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7161CC Offset: 0x7161CC VA: 0x7161CC
		// // RVA: 0xE15F14 Offset: 0xE15F14 VA: 0xE15F14
		private IEnumerator Co_PlayDivaAnim()
		{
			//0xE1A858
			m_balloonController.gameObject.SetActive(true);
			m_playVoiceCoroutine = this.StartCoroutineWatched(Co_DelayPlayVoice());
			if(m_animSetting.animNameList.Count == 1)
			{
				m_balloonController.ShowBalloon(viewEventResultData.AHHJLDLAPAN_DivaId, m_voiceType);
				m_divaObject.Anim_SetTrigger("menu_toSimple");
				m_divaObject.Anim_SetInteger("menu_simpleId", 1);
				m_divaObject.FacialAnim_SetInteger("menu_simpleId", 0);
			}
			else
			{
				m_balloonController.ShowBalloon(viewEventResultData.AHHJLDLAPAN_DivaId, m_voiceType);
				if(m_animSetting.animNameList.Count != 2)
				{
					m_divaObject.Anim_SetTrigger("menu_toTalk");
					m_divaObject.Anim_SetInteger("menu_talkType", 1);
					m_divaObject.Anim_SetBool("menu_breakTalkLoop", false);
					m_divaObject.FacialAnim_SetInteger("menu_talkType", 0);
					yield return new WaitUntil(() =>
					{
						//0xE16E48
						return m_simpleDivaAnimation.IsPlayingVoice();
					});
					yield return new WaitUntil(() =>
					{
						//0xE16E74
						return !m_simpleDivaAnimation.IsPlayingVoice();
					});
					yield return new WaitForSeconds(1);
					m_divaObject.Anim_SetBool("menu_breakTalkLoop", true);
				}
				else
				{
					m_divaObject.Anim_SetBool("menu_simpleLoopStart2", true);
				}
			}
			m_playDivaAnimCoroutine = null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x716244 Offset: 0x716244 VA: 0x716244
		// // RVA: 0xE15FC0 Offset: 0xE15FC0 VA: 0xE15FC0
		private IEnumerator Co_DelayPlayVoice()
		{
			//0xE19594
			yield return new WaitForSeconds(m_animSetting.delayTimeList[0]);
			m_simpleDivaAnimation.PlayVoice(m_voiceSetting, -1);
			yield return new WaitUntil(() =>
			{
				//0xE16EA4
				return m_simpleDivaAnimation.IsPlayingVoice();
			});
			yield return new WaitUntil(() =>
			{
				//0xE16ED0
				return !m_simpleDivaAnimation.IsPlayingVoice();
			});
			m_playVoiceCoroutine = null;
		}

		// RVA: 0xE1606C Offset: 0xE1606C VA: 0xE1606C
		private void Start()
		{
			return;
		}

		// RVA: 0xE16070 Offset: 0xE16070 VA: 0xE16070
		private void Update()
		{
			if(m_isStarted && !m_isSkiped && InputManager.Instance.GetInScreenTouchCount() > 0 && ResultScene.IsScreenTouch())
				m_isSkiped = true;
		}

		// // RVA: 0xE16148 Offset: 0xE16148 VA: 0xE16148
		// public bool IsLoading() { }

		// // RVA: 0xE16074 Offset: 0xE16074 VA: 0xE16074
		// private void CheckSkipStep() { }

		// // RVA: 0xE16150 Offset: 0xE16150 VA: 0xE16150
		private int GetNextExp(int level, JLCHNKIHGHK.GDJKDOMAAPG paramType)
		{
			return viewEventResultData.HKKJBILCDLA_ExpByLevel[(int)paramType][Mathf.Clamp(level + 1, 1, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OAINIGNLJKC_Diva2.NBJKHMLGNPA() + 1)];
		}

		// // RVA: 0xE16300 Offset: 0xE16300 VA: 0xE16300
		private void SetExpGauge(JLCHNKIHGHK.GDJKDOMAAPG divaParamType, int currentExp, int needExp)
		{
			foreach(var l in m_beforeGaugeLayout[(int)divaParamType].layout)
			{
				int start = (int)(currentExp * 1.0f / needExp * (l.FrameAnimation.FrameNum + 1));
				l.StartAnimGoStop(start, start);
			}
		}

		// // RVA: 0xE1652C Offset: 0xE1652C VA: 0xE1652C
		private void SetAddExpGauge(JLCHNKIHGHK.GDJKDOMAAPG divaParamType, int currentExp, int needExp)
		{
			if(needExp < currentExp)
				currentExp = needExp;
			m_textGauge[(int)divaParamType].text = currentExp + "/" + needExp;
			foreach(var l in m_afterGaugeLayout[(int)divaParamType].layout)
			{
				int start = (int)(currentExp * 1.0f / needExp * (l.FrameAnimation.FrameNum + 1));
				l.StartAnimGoStop(start, start);
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7162BC Offset: 0x7162BC VA: 0x7162BC
		// // RVA: 0xE16808 Offset: 0xE16808 VA: 0xE16808
		private IEnumerator Co_ShowLevelupPopup()
		{
			int i;

			//0xE1B188
			for(i = 0; i < 3; i++)
			{
				if(viewEventResultData.FMMNAEJEIFF_BeforeLevel[i] < viewEventResultData.HGMAAIJFPOI_AfterLevel[i])
				{
					PopupGoDivaLevelupSetting s = new PopupGoDivaLevelupSetting();
					s.TitleText = "";
					s.IsCaption = false;
					s.initParam.divaParamType = (JLCHNKIHGHK.GDJKDOMAAPG) i;
					s.initParam.beforeLevel = viewEventResultData.FMMNAEJEIFF_BeforeLevel[i];
					s.initParam.afterLevel = viewEventResultData.HGMAAIJFPOI_AfterLevel[i];
					s.initParam.beforeValue = viewEventResultData.DFNNLEMDIPI_BeforeValue[i];
					s.initParam.afterValue = viewEventResultData.AECCBECCINI_AfterValue[i];
					s.WindowSize = SizeType.Small;
					s.Buttons = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					};
					PopupWindowManager.Show(s, null, null, null, null, true, true, false);
					yield return new WaitUntil(() =>
					{
						//0xE16F7C
						return PopupWindowManager.IsActivePopupWindow();
					});
					yield return new WaitWhile(() =>
					{
						//0xE16FF8
						return PopupWindowManager.IsActivePopupWindow();
					});
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x716334 Offset: 0x716334 VA: 0x716334
		// // RVA: 0xE168B4 Offset: 0xE168B4 VA: 0xE168B4
		private IEnumerator Co_Countup(int startNum, int endNum, float accelPer, Action<int> onChangeNumberCallback, Action onFinishCallback)
		{
			float add_num;

			//0xE1937C
			add_num = 1;
			while(true)
			{
				startNum += (int)add_num;
				if(startNum < endNum)
				{
					add_num += add_num * accelPer;
					onChangeNumberCallback(startNum);
					if(m_isSkiped)
						break;
					yield return null;
				}
				else
					break;
			}
			onChangeNumberCallback(endNum);
			if(onFinishCallback != null)
				onFinishCallback();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7163AC Offset: 0x7163AC VA: 0x7163AC
		// // RVA: 0xE169F0 Offset: 0xE169F0 VA: 0xE169F0
		private IEnumerator Co_WaitAnim(AbsoluteLayout layout, bool enableSkip/* = True*/)
		{
			//0xE1B928
			while(layout.IsPlayingChildren())
			{
				if(!m_isSkiped || !enableSkip)
				{
					yield return null;
				}
				else
				{
					layout.UpdateAllAnimation(TimeWrapper.deltaTime * 2);
					layout.UpdateAll(m_identity, Color.white);
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x716424 Offset: 0x716424 VA: 0x716424
		// // RVA: 0xE16AD0 Offset: 0xE16AD0 VA: 0xE16AD0
		// private IEnumerator Co_WaitLabel(AbsoluteLayout layout, string label, bool enableSkip = True) { }

		// // RVA: 0xE16BC8 Offset: 0xE16BC8 VA: 0xE16BC8
		private void PlayDivaExpCountUpLoopSE()
		{
			if(m_countDivaExpUpSEPlayback.GetStatus() == CriAtomExPlayback.Status.Removed)
				return;
			m_countDivaExpUpSEPlayback = SoundManager.Instance.sePlayerResultLoop.Play(14);
		}

		// // RVA: 0xE16C3C Offset: 0xE16C3C VA: 0xE16C3C
		// private void StopDivaExpCountUpLoopSE() { }

		// // RVA: 0xE16C48 Offset: 0xE16C48 VA: 0xE16C48
		private void PlayCountUpLoopSE()
		{
			if(m_countUpSEPlayback.GetStatus() == CriAtomExPlayback.Status.Removed)
				return;
			m_countUpSEPlayback = SoundManager.Instance.sePlayerResultLoop.Play(0);
		}

		// // RVA: 0xE16CBC Offset: 0xE16CBC VA: 0xE16CBC
		// private void StopCountUpLoopSE() { }
	}
}
