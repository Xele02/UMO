using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System;
using CriWare;
using System.Text;
using XeSys;
using XeApp.Game.Common;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class MissonResultLayoutController : LayoutUGUIScriptBase
	{
		public class InitParam
		{
			public KPJHLACKGJF_EventMission.OPFEKMKHEIF viewEventResultData; // 0x8
			public LayoutResultOkayButton layoutOkayButton; // 0xC
		}

		private AbsoluteLayout m_Anim; // 0x14
		private AbsoluteLayout m_Step; // 0x18
		private AbsoluteLayout m_CardSwitch; // 0x1C
		private AbsoluteLayout m_ClearSwitch; // 0x20
		private AbsoluteLayout m_DashSwitch; // 0x24
		private AbsoluteLayout m_DashSwitchMedal; // 0x28
		private AbsoluteLayout m_DashSwitchMedal2; // 0x2C
		private AbsoluteLayout m_PercentLoopAnime; // 0x30
		private AbsoluteLayout[] m_UpAnim = new AbsoluteLayout[3]; // 0x34
		private Rect[] m_diffRectArray; // 0x38
		private Rect[] m_diffRectArray_6Line; // 0x3C
		private Rect[] m_levelRectArray; // 0x40
		private LayoutResultOkayButton layoutOkayButton; // 0x44
		public Action onClickOkayButton; // 0x48
		private int m_getPoint; // 0x4C
		private int m_prevTotalPoint; // 0x50
		private int m_totalPoint; // 0x54
		private bool is_loading; // 0x58
		private CriAtomExPlayback countUpSEPlayback; // 0x5C
		private StringBuilder m_strBulder = new StringBuilder(); // 0x60
		[SerializeField]
		private Text m_missionInfoText; // 0x64
		[SerializeField]
		private Text m_missionPerText; // 0x68
		[SerializeField]
		private Text m_noClearPerText; // 0x6C
		[SerializeField]
		private Text m_basePointText; // 0x70
		[SerializeField]
		private Text m_missionBonusText; // 0x74
		[SerializeField]
		private Text m_musicBonusText; // 0x78
		[SerializeField]
		private Text m_episodeBonusText; // 0x7C
		[SerializeField]
		private Text m_episodeNumText; // 0x80
		[SerializeField]
		private Text[] m_getPointText; // 0x84
		[SerializeField]
		private Text m_totalPointText; // 0x88
		[SerializeField]
		private Text m_medalNumText; // 0x8C
		[SerializeField]
		private RawImageEx m_levelNumImage; // 0x90
		[SerializeField]
		private RawImageEx m_diffImage; // 0x94
		[SerializeField]
		private RawImageEx m_medalImage; // 0x98
		[SerializeField]
		private Text m_militaryMedalText; // 0x9C
		[SerializeField]
		private List<Text> m_textlist_dash = new List<Text>(); // 0xA0
		private AbsoluteLayout m_TitleAnim; // 0xA4
		private bool m_IsEnterTitle; // 0xA8
		private bool m_isSkiped; // 0xA9
		private bool m_isStarted; // 0xAA
		private bool m_IsReward; // 0xAB

		// RVA: 0x1040D54 Offset: 0x1040D54 VA: 0x1040D54
		private void OnDisable()
		{
			SoundManager.Instance.sePlayerResultLoop.Stop();
		}

		// RVA: 0x1040DA8 Offset: 0x1040DA8 VA: 0x1040DA8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_Anim = layout.FindViewById("sw_game_res_event02_inout") as AbsoluteLayout;
			m_Step = layout.FindViewById("sw_game_res_event02_anim") as AbsoluteLayout;
			m_CardSwitch = layout.FindViewById("swtbl_sel_music_eve_card") as AbsoluteLayout;
			m_ClearSwitch = layout.FindViewById("swtbl_g_r_ev_clear") as AbsoluteLayout;
			m_DashSwitch = (layout.FindViewById("sw_game_res_event02_anim") as AbsoluteLayout).FindViewById("swtbl_dash") as AbsoluteLayout;
			m_DashSwitchMedal = (layout.FindViewById("sw_get_medal") as AbsoluteLayout).FindViewById("swtbl_dash") as AbsoluteLayout;
			m_TitleAnim = layout.FindViewById("sw_g_r_event_title_anim") as AbsoluteLayout;
			m_DashSwitchMedal2 = (layout.FindViewById("sw_rank_fr_set") as AbsoluteLayout).FindViewById("swtbl_dash") as AbsoluteLayout;
			string[] str = new string[3]
			{
				"swtbl_up", "swtbl_up_2", "swtbl_up_3"
			};
			for(int i = 0; i < 3; i++)
			{
				m_UpAnim[i] = layout.FindViewById(str[i]) as AbsoluteLayout;
			}
			StringBuilder s = new StringBuilder();
			m_diffRectArray = new Rect[5];
			for(int i = 0; i < m_diffRectArray.Length; i++)
			{
				s.Clear();
				s.AppendFormat("cmn_music_diff_{0:D2}", i + 1);
				m_diffRectArray[i] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(s.ToString()));
			}
			m_diffRectArray_6Line = new Rect[3];
			for(int i = 0; i < m_diffRectArray_6Line.Length; i++)
			{
				s.Clear();
				s.AppendFormat("cmn_music_diff_{0:D2}", i + 6);
				m_diffRectArray_6Line[i] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(s.ToString()));
			}
			m_levelRectArray = new Rect[3];
			for(int i = 0; i < m_levelRectArray.Length; i++)
			{
				s.Clear();
				s.AppendFormat("s_m_e_card_lv_{0:D2}", i + 1);
				m_levelRectArray[i] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(s.ToString()));
			}
			m_PercentLoopAnime = layout.FindViewByExId("swtbl_g_r_ev_clear_sw_g_r_ev_clear_no_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// RVA: 0x1041C5C Offset: 0x1041C5C VA: 0x1041C5C
		public void Setup(InitParam initParam)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			layoutOkayButton = initParam.layoutOkayButton;
			layoutOkayButton.SetupCallback(null, OnClickOkayButton);
            KPJHLACKGJF_EventMission.OPFEKMKHEIF data = initParam.viewEventResultData;
            if (initParam.viewEventResultData == null)
			{
				m_missionInfoText.text = TextConstant.InvalidText;
				m_missionPerText.text = "";
				m_noClearPerText.text = JpStringLiterals.StringLiteral_18575;
				GameManager.Instance.UnionTextureManager.GetTexture("cmn_tex_pack").Set(m_diffImage);
				m_diffImage.uvRect = m_diffRectArray[0];
				m_levelNumImage.uvRect = m_levelRectArray[0];
				m_CardSwitch.StartChildrenAnimGoStop(0, 0);
				m_ClearSwitch.StartChildrenAnimGoStop(1, 1);
				m_basePointText.text = "0";
				m_missionBonusText.text = "0";
				SetActiveUpIcon(0, false);
				m_musicBonusText.text = "0";
				SetActiveUpIcon(1, false);
				m_episodeBonusText.text = "0";
				SetActiveUpIcon(2, false);
				m_episodeNumText.text = "0" + JpStringLiterals.StringLiteral_11079;
				for(int i = 0; i < m_getPointText.Length; i++)
				{
					m_getPointText[i].text = "0";
				}
				m_totalPoint = 0;
				m_getPoint = 0;
				m_prevTotalPoint = 0;
				m_totalPointText.text = "0";
				SetActiveDashBonus(false);
				m_medalNumText.text = "0";
				is_loading = true;
				MenuScene.Instance.ItemTextureCache.Load(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal, MenuScene.Instance.GetMedalMonthId()), (IiconTexture texture) =>
				{
					//0x104425C
					texture.Set(m_medalImage);
					is_loading = false;
				});
                IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived, false);
				m_IsReward = ev != null && ev.JOFBHHHLBBN_Rewards.Count > 0;
				m_militaryMedalText.text = "0";
				m_PercentLoopAnime.StartChildrenAnimGoStop(0, 0);
            }
			else
			{
				m_missionInfoText.text = GameMessageManager.ReplaceMessageTag(initParam.viewEventResultData.EMBGHCNOCEH_Desc, (string tag) =>
				{
					//0x1044030
					return GameMessageManager.MissionMessageTagFunc(m_strBulder, tag, data.GHBPLHBNMBK_FreeMusicId, data.LFGNLKKFOCD_IsLine6, (Difficulty.Type)data.FCNIAJHHGJH_Difficulty);
				});
				m_missionPerText.text = string.Format(bk.GetMessageByLabel("event_mission_message_000"), data.NFOOOBMJINC_MissionPercent);
				m_noClearPerText.text = JpStringLiterals.StringLiteral_18575;
				if(!data.LFGNLKKFOCD_IsLine6)
				{
					GameManager.Instance.UnionTextureManager.GetTexture("cmn_tex_pack").Set(m_diffImage);
					m_diffImage.uvRect = m_diffRectArray[data.FCNIAJHHGJH_Difficulty];
				}
				else
				{
					GameManager.Instance.UnionTextureManager.GetTexture("cmn_tex_02_pack").Set(m_diffImage);
					m_diffImage.uvRect = m_diffRectArray_6Line[data.FCNIAJHHGJH_Difficulty - 2];
				}
				m_levelNumImage.uvRect = m_levelRectArray[data.AJCMCKGNFHC_Level - 1];
				int d = data.JKPDKNPDEBC_EnemyHasSkill ? 3 : data.AJCMCKGNFHC_Level - 1;
				m_CardSwitch.StartChildrenAnimGoStop(d, d);
				m_ClearSwitch.StartChildrenAnimGoStop(!data.BCGLDMKODLC ? 1 : 0, !data.BCGLDMKODLC ? 1 : 0);
				m_basePointText.text = data.FPEOGFMKMKJ_BasePoint.ToString();
				m_missionBonusText.text = (data.PJEFKNPJEBE_MissionBonus - 100).ToString();
				SetActiveUpIcon(0, data.PJEFKNPJEBE_MissionBonus - 100 > 0);
				m_musicBonusText.text = (data.JKDICBNOGBL_MusicBonus - 100).ToString();
				SetActiveUpIcon(1, data.JKDICBNOGBL_MusicBonus - 100 > 0);
				m_episodeBonusText.text = (data.ODCLHPGHDHA_EpisodeBonus - 100).ToString();
				SetActiveUpIcon(2, data.ODCLHPGHDHA_EpisodeBonus - 100 > 0);
				m_episodeNumText.text = data.LIPIAPOGHIP_EpisodeNum + JpStringLiterals.StringLiteral_11079;
				for(int i = 0; i < m_getPointText.Length; i++)
				{
					m_getPointText[i].text = "0";
				}
				m_getPoint = data.JKFCHNEININ_GetPoint;
				m_prevTotalPoint = data.BPJEOPHAJPP_PrevTotalPoint;
				m_totalPoint = data.AHOKAPCGJMA_TotalPoint;
				m_totalPointText.text = m_totalPoint.ToString();
				if(data.FCLGIPFPIPH_DashBonus > 1)
				{
					string s = string.Format(bk.GetMessageByLabel("event_reward_result_dash_bonus"), data.FCLGIPFPIPH_DashBonus);
					foreach(var t in m_textlist_dash)
					{
						t.text = s;
					}
				}
				SetActiveDashBonus(data.FCLGIPFPIPH_DashBonus > 1);
				m_medalNumText.text = data.ODOOKDGCKMF_MedalNum.ToString();
				is_loading = true;
				MenuScene.Instance.ItemTextureCache.Load(data.BEOKMNIPFBA_MedalItemId, (IiconTexture texture) =>
				{
					//0x104414C
					texture.Set(m_medalImage);
					is_loading = false;
				});
                IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived, false);
				m_IsReward = ev != null && ev.JOFBHHHLBBN_Rewards.Count > 0;
				m_militaryMedalText.text = data.JHGGBBNLINH_MilitaryMedalCount.ToString();
			}
		}

		// RVA: 0x1043388 Offset: 0x1043388 VA: 0x1043388
		public bool IsLoading()
		{
			return is_loading;
		}

		// // RVA: 0x1043390 Offset: 0x1043390 VA: 0x1043390
		public bool IsReady()
		{
			return IsLoaded();
		}

		// RVA: 0x1043398 Offset: 0x1043398 VA: 0x1043398
		private void Update()
		{
			if(IsLoaded())
				CheckSkipStep();
		}

		// RVA: 0x10434F0 Offset: 0x10434F0 VA: 0x10434F0
		public void Enter()
		{
			this.StartCoroutineWatched(Co_ResultStep());
		}

		// // RVA: 0x10435A0 Offset: 0x10435A0 VA: 0x10435A0
		// public void Leave() { }

		// // RVA: 0x10433C0 Offset: 0x10433C0 VA: 0x10433C0
		private void CheckSkipStep()
		{
			if(m_isStarted && !m_isSkiped)
			{
				if(InputManager.Instance.GetInScreenTouchCount() > 0 && ResultScene.IsScreenTouch())
				{
					if(!m_IsEnterTitle)
					{
						m_TitleAnim.StartAllAnimLoop("logo_up", "loen_up");
						m_IsEnterTitle = true;
					}
					Finish();
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F2AC4 Offset: 0x6F2AC4 VA: 0x6F2AC4
		// // RVA: 0x10438B0 Offset: 0x10438B0 VA: 0x10438B0
		private IEnumerator Co_EnterTitle()
		{
			//0x104456C
			m_IsEnterTitle = false;
			m_TitleAnim.StartAllAnimGoStop("go_in", "st_in");
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1043E48
				return m_TitleAnim.IsPlayingAll();
			});
			m_TitleAnim.StartAllAnimLoop("logo_up", "loen_up");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F2B3C Offset: 0x6F2B3C VA: 0x6F2B3C
		// // RVA: 0x1043514 Offset: 0x1043514 VA: 0x1043514
		private IEnumerator Co_ResultStep()
		{
			List<float> timerList;

			//0x1044808
			timerList = new List<float>();
			NumberAnimationUtility.MakeAccelerationTimeList(10, 0.24f, 0.02f, ref timerList);
			m_Step.StartChildrenAnimGoStop("st_wait");
			m_Anim.StartChildrenAnimGoStop("go_in", "st_in");
			yield return new WaitWhile(() =>
			{
				//0x1043E74
				return m_Anim.IsPlayingChildren();
			});
			m_isStarted = true;
			this.StartCoroutineWatched(Co_EnterTitle());
			m_Step.StartChildrenAnimGoStop("se_01", "st_pt");
			yield return null;
			yield return Co.R(Co_WaitAnim("se_01"));
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_035);
			yield return Co.R(Co_WaitAnim("se_02"));
			yield return Co.R(Co_WaitAnim("se_03"));
			yield return Co.R(Co_WaitAnim("se_04"));
			yield return Co.R(Co_WaitAnim("se_05"));
			yield return Co.R(Co_WaitAnim("go_pt"));
			yield return new WaitWhile(() =>
			{
				//0x1043EA0
				return m_Step.IsPlayingChildren();
			});
			PlayCountUpLoopSE();
			yield return this.StartCoroutineWatched(NumberAnimationUtility.Co_FakeCountup(m_getPoint, timerList, (int number) =>
			{
				//0x1043ECC
				for(int i = 0; i < m_getPointText.Length; i++)
				{
					m_getPointText[i].text = number.ToString();
				}
			}, null, null));
			countUpSEPlayback.Stop();
			m_Step.StartChildrenAnimGoStop("act_pt", "acten_pt");
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1043F88
				return m_Step.IsPlayingChildren();
			});
			m_Step.StartChildrenAnimGoStop("go_total_pt", "st_total_pt");
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_036);
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1043FB4
				return m_Step.IsPlayingChildren();
			});
			m_Step.StartChildrenAnimGoStop("go_medal", "st_stop");
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_025);
			yield return null;
			yield return Co.R(Co_WaitAnim("go_medal"));
			yield return Co.R(Co_WaitAnim("go_rank"));
			yield return new WaitWhile(() =>
			{
				//0x1043FE0
				return m_Step.IsPlayingChildren();
			});
			Finish();
		}

		// // RVA: 0x104362C Offset: 0x104362C VA: 0x104362C
		private void Finish()
		{
			this.StopAllCoroutinesWatched();
			countUpSEPlayback.Stop();
			m_Step.StartChildrenAnimGoStop("st_stop", "st_stop");
			m_Anim.StartChildrenAnimGoStop("st_in", "st_in");
			for(int i = 0; i < m_getPointText.Length; i++)
			{
				m_getPointText[i].text = m_getPoint.ToString();
			}
			m_totalPointText.text = m_totalPoint.ToString();
			if(!m_IsReward)
				layoutOkayButton.StartBeginAnim(true);
			else
			{
				this.StartCoroutineWatched(PopupRewardEvResult.Co_ShowPopup_CumulativePoint(transform, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x104400C
					this.StartCoroutineWatched(Co_ShowPlatePopup());
				}));
			}
			m_isSkiped = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F2BB4 Offset: 0x6F2BB4 VA: 0x6F2BB4
		// // RVA: 0x1043988 Offset: 0x1043988 VA: 0x1043988
		private IEnumerator Co_ShowPlatePopup()
		{
			//0x1045304
			yield return null;
			bool is_close = false;
			this.StartCoroutineWatched(PopupRecordPlate.Show(RecordPlateUtility.eSceneType.EventResult, () =>
			{
				//0x1044374
				is_close = true;
			}, false));
			yield return new WaitWhile(() =>
			{
				//0x1044380
				return !is_close;
			});
			layoutOkayButton.StartBeginAnim(true);
		}

		// // RVA: 0x1043214 Offset: 0x1043214 VA: 0x1043214
		private void SetActiveUpIcon(int index, bool active)
		{
			m_UpAnim[index].StartChildrenAnimGoStop(!active ? 1 : 0, !active ? 1 : 0);
		}

		// // RVA: 0x1043298 Offset: 0x1043298 VA: 0x1043298
		private void SetActiveDashBonus(bool active)
		{
			if(active)
			{
				m_DashSwitch.StartChildrenAnimGoStop(0, 0);
				m_DashSwitchMedal.StartChildrenAnimGoStop(0, 0);
				m_DashSwitchMedal2.StartChildrenAnimGoStop(0, 0);
			}
			else
			{
				m_DashSwitch.StartChildrenAnimGoStop(1, 1);
				m_DashSwitchMedal.StartChildrenAnimGoStop(1, 1);
				m_DashSwitchMedal2.StartChildrenAnimGoStop(1, 1);
			}
		}

		// // RVA: 0x1043A34 Offset: 0x1043A34 VA: 0x1043A34
		private void OnClickOkayButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(onClickOkayButton != null)
				onClickOkayButton();
		}

		// // RVA: 0x1043AA4 Offset: 0x1043AA4 VA: 0x1043AA4
		// public bool IsPlaying() { }

		// // RVA: 0x1043AD0 Offset: 0x1043AD0 VA: 0x1043AD0
		// public void Skip() { }

		// // RVA: 0x1043B4C Offset: 0x1043B4C VA: 0x1043B4C
		private void PlayCountUpLoopSE()
		{
			countUpSEPlayback = SoundManager.Instance.sePlayerResultLoop.Play(0);
		}

		// // RVA: 0x104397C Offset: 0x104397C VA: 0x104397C
		// private void StopCountUpLoopSE() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F2C2C Offset: 0x6F2C2C VA: 0x6F2C2C
		// // RVA: 0x1043BAC Offset: 0x1043BAC VA: 0x1043BAC
		private IEnumerator Co_WaitAnim(string label)
		{
			//0x10455AC
			while(m_Step.GetView(0).FrameAnimation.FrameCount < m_Step.GetView(0).FrameAnimation.SearchLabelFrame(label))
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F2CA4 Offset: 0x6F2CA4 VA: 0x6F2CA4
		// // RVA: 0x1043C74 Offset: 0x1043C74 VA: 0x1043C74
		// private IEnumerator Co_Countup(int startNum, int endNum, float accelPer, Action<int> onChangeNumberCallback) { }
	}
}
