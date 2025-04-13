using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using XeSys.Gfx;
using System.Text;
using XeSys;
using mcrs;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class SetDeckStatusWindow : MonoBehaviour
	{
		public enum StatusName
		{
			Total = 0,
			Soul = 1,
			Voice = 2,
			Charm = 3,
			Life = 4,
			Support = 5,
			Fold = 6,
			Luck = 7,
			Num = 8,
		}

		public enum CenterSkillRegulation
		{
			Music = 0,
			Series = 1,
			Attribute = 2,
			Diva = 3,
			Num = 4,
		}

		private enum CenterSkillSlot
		{
			Skill2 = 0,
			Skill1 = 1,
			Num = 2,
		}

		private const string LevelFormat = "Lv{0}";
		private const string InvalidText = "---";
		private const int TOTAL_MAX = 9999999;
		private const int SUBPARAM_MAX = 999999;
		[SerializeField] // RVA: 0x683860 Offset: 0x683860 VA: 0x683860
		//[TooltipAttribute] // RVA: 0x683860 Offset: 0x683860 VA: 0x683860
		private Color m_normalColorCode = new Color(0.1960784f, 0.1960784f, 0.1960784f); // 0xC
		//[TooltipAttribute] // RVA: 0x6838C8 Offset: 0x6838C8 VA: 0x6838C8
		[SerializeField] // RVA: 0x6838C8 Offset: 0x6838C8 VA: 0x6838C8
		private InOutAnime m_inOut; // 0x1C
		//[TooltipAttribute] // RVA: 0x683910 Offset: 0x683910 VA: 0x683910
		[SerializeField] // RVA: 0x683910 Offset: 0x683910 VA: 0x683910
		private SetDeckStatusValueControl[] m_status = new SetDeckStatusValueControl[8]; // 0x20
		[SerializeField] // RVA: 0x68396C Offset: 0x68396C VA: 0x68396C
		private GameObject m_statusInvalid; // 0x24
		[SerializeField] // RVA: 0x68397C Offset: 0x68397C VA: 0x68397C
		//[TooltipAttribute] // RVA: 0x68397C Offset: 0x68397C VA: 0x68397C
		private SetDeckStatusValueControl[] m_subStatus = new SetDeckStatusValueControl[4]; // 0x28
		[SerializeField] // RVA: 0x6839D4 Offset: 0x6839D4 VA: 0x6839D4
		//[TooltipAttribute] // RVA: 0x6839D4 Offset: 0x6839D4 VA: 0x6839D4
		private Text[] m_notesTexts; // 0x2C
		[SerializeField] // RVA: 0x683A2C Offset: 0x683A2C VA: 0x683A2C
		//[TooltipAttribute] // RVA: 0x683A2C Offset: 0x683A2C VA: 0x683A2C
		private Text[] m_centerSkillNameText = new Text[2]; // 0x30
		//[TooltipAttribute] // RVA: 0x683A88 Offset: 0x683A88 VA: 0x683A88
		[SerializeField] // RVA: 0x683A88 Offset: 0x683A88 VA: 0x683A88
		private Text[] m_centerSkillEffectText = new Text[2]; // 0x34
		[SerializeField] // RVA: 0x683AE4 Offset: 0x683AE4 VA: 0x683AE4
		//[TooltipAttribute] // RVA: 0x683AE4 Offset: 0x683AE4 VA: 0x683AE4
		private Text[] m_centerSkillLevelText = new Text[2]; // 0x38
		[SerializeField] // RVA: 0x683B44 Offset: 0x683B44 VA: 0x683B44
		//[TooltipAttribute] // RVA: 0x683B44 Offset: 0x683B44 VA: 0x683B44
		private GameObject[] m_centerSkill = new GameObject[2]; // 0x3C
		[SerializeField] // RVA: 0x683B9C Offset: 0x683B9C VA: 0x683B9C
		//[TooltipAttribute] // RVA: 0x683B9C Offset: 0x683B9C VA: 0x683B9C
		private GameObject[] m_centerSkillInvalid = new GameObject[2]; // 0x40
		[SerializeField] // RVA: 0x683BF8 Offset: 0x683BF8 VA: 0x683BF8
		//[TooltipAttribute] // RVA: 0x683BF8 Offset: 0x683BF8 VA: 0x683BF8
		private RawImageEx[] m_centerSkillRankImage = new RawImageEx[2]; // 0x44
		//[TooltipAttribute] // RVA: 0x683C64 Offset: 0x683C64 VA: 0x683C64
		[SerializeField] // RVA: 0x683C64 Offset: 0x683C64 VA: 0x683C64
		private GameObject[] m_centerSkillNonActive = new GameObject[2]; // 0x48
		//[TooltipAttribute] // RVA: 0x683CD0 Offset: 0x683CD0 VA: 0x683CD0
		[SerializeField] // RVA: 0x683CD0 Offset: 0x683CD0 VA: 0x683CD0
		private GameObject[] m_centerSkillRegulation = new GameObject[4]; // 0x4C
		//[TooltipAttribute] // RVA: 0x683D40 Offset: 0x683D40 VA: 0x683D40
		[SerializeField] // RVA: 0x683D40 Offset: 0x683D40 VA: 0x683D40
		private Text[] m_centerSkillRegulationText = new Text[2]; // 0x50
		[SerializeField] // RVA: 0x683DB0 Offset: 0x683DB0 VA: 0x683DB0
		//[TooltipAttribute] // RVA: 0x683DB0 Offset: 0x683DB0 VA: 0x683DB0
		private UGUIButton m_centerSkillRegulationButton; // 0x54
		[SerializeField] // RVA: 0x683E2C Offset: 0x683E2C VA: 0x683E2C
		//[TooltipAttribute] // RVA: 0x683E2C Offset: 0x683E2C VA: 0x683E2C
		private GameObject m_activeSkill; // 0x58
		[SerializeField] // RVA: 0x683E88 Offset: 0x683E88 VA: 0x683E88
		private GameObject m_activeSkillInvalid; // 0x5C
		[SerializeField] // RVA: 0x683E98 Offset: 0x683E98 VA: 0x683E98
		//[TooltipAttribute] // RVA: 0x683E98 Offset: 0x683E98 VA: 0x683E98
		private Text m_activeSkillNameText; // 0x60
		[SerializeField] // RVA: 0x683EF4 Offset: 0x683EF4 VA: 0x683EF4
		//[TooltipAttribute] // RVA: 0x683EF4 Offset: 0x683EF4 VA: 0x683EF4
		private Text m_activeSkillEffectText; // 0x64
		//[TooltipAttribute] // RVA: 0x683F54 Offset: 0x683F54 VA: 0x683F54
		[SerializeField] // RVA: 0x683F54 Offset: 0x683F54 VA: 0x683F54
		private Text m_activeSkillLevelText; // 0x68
		[SerializeField] // RVA: 0x683FB8 Offset: 0x683FB8 VA: 0x683FB8
		//[TooltipAttribute] // RVA: 0x683FB8 Offset: 0x683FB8 VA: 0x683FB8
		private RawImageEx m_activeSkillRankImage; // 0x6C
		[SerializeField] // RVA: 0x684020 Offset: 0x684020 VA: 0x684020
		private Text[] m_limitBreakText = new Text[2]; // 0x70
		[SerializeField] // RVA: 0x684030 Offset: 0x684030 VA: 0x684030
		private Text[] m_limitBreakAttrBonusText = new Text[2]; // 0x74
		[SerializeField] // RVA: 0x684040 Offset: 0x684040 VA: 0x684040
		private GameObject[] m_limitBreakAttrBonus = new GameObject[2]; // 0x78
		[SerializeField] // RVA: 0x684050 Offset: 0x684050 VA: 0x684050
		private Text[] m_limitBreakSeriesBonusText = new Text[2]; // 0x7C
		[SerializeField] // RVA: 0x684060 Offset: 0x684060 VA: 0x684060
		private GameObject[] m_limitBreakSeriesBonus = new GameObject[2]; // 0x80
		//[TooltipAttribute] // RVA: 0x684070 Offset: 0x684070 VA: 0x684070
		[SerializeField] // RVA: 0x684070 Offset: 0x684070 VA: 0x684070
		private UGUIButton m_supportButton; // 0x84
		[SerializeField] // RVA: 0x6840CC Offset: 0x6840CC VA: 0x6840CC
		//[TooltipAttribute] // RVA: 0x6840CC Offset: 0x6840CC VA: 0x6840CC
		private GameObject m_supportLock; // 0x88
		private StatusData m_baseStatus = new StatusData(); // 0x8C
		private StatusData m_addStatus = new StatusData(); // 0x90
		private StatusData m_tmpStatus = new StatusData(); // 0x94
		private StringBuilder m_strBuilder = new StringBuilder(64); // 0x98
		private UnitWindowConstant.OperationMode m_operationMode; // 0x9C
		private GCIJNCFDNON_SceneInfo m_mainScene; // 0xA0
		private LimitOverStatusData m_limitOverStatus = new LimitOverStatusData(); // 0xA4
		private LimitOverStatusData m_tmpLimitOverStatus = new LimitOverStatusData(); // 0xA8
		private Common.ScrollText[] m_scrollTexts; // 0xAC

		public InOutAnime InOut { get { return m_inOut; } } //0xA77690
		public CFHDKAFLNEP SubPlateResult { get; set; } // 0xB0

		// RVA: 0xA776B8 Offset: 0xA776B8 VA: 0xA776B8
		private void Awake()
		{
			transform.SetAsLastSibling();
			m_centerSkillRegulation[0].SetActive(false);
			m_centerSkillRegulation[3].SetActive(false);
			m_supportButton.ClearOnClickCallback();
			m_supportButton.AddOnClickCallback(OnShowSubPlateWindowButton);
			m_centerSkillRegulationButton.ClearOnClickCallback();
			m_centerSkillRegulationButton.AddOnClickCallback(OnShowCenterSkillDetails);
			m_scrollTexts = GetComponentsInChildren<Common.ScrollText>();

			m_status[0].transform.parent.Find("Text_Label").GetComponent<Text>().text = JpStringLiterals.UMO_Total;
			m_status[1].transform.parent.Find("Text_Label").GetComponent<Text>().text = JpStringLiterals.StringLiteral_11063;
			m_status[2].transform.parent.Find("Text_Label").GetComponent<Text>().text = JpStringLiterals.StringLiteral_11064;
			m_status[3].transform.parent.Find("Text_Label").GetComponent<Text>().text = JpStringLiterals.StringLiteral_11065;
			m_status[4].transform.parent.Find("Text_Label").GetComponent<Text>().text = JpStringLiterals.StringLiteral_11062;
			m_status[5].transform.parent.Find("Text_Label").GetComponent<Text>().text = JpStringLiterals.StringLiteral_11069;
			m_status[6].transform.parent.Find("Text_Label").GetComponent<Text>().text = JpStringLiterals.UMO_Fold;
			m_status[7].transform.parent.Find("Text_Label").GetComponent<Text>().text = JpStringLiterals.UMO_Luck;

			m_subStatus[0].transform.parent.Find("Text_Label").GetComponent<Text>().text = JpStringLiterals.UMO_Total;
			m_subStatus[1].transform.parent.Find("Text_Label").GetComponent<Text>().text = JpStringLiterals.StringLiteral_11063;
			m_subStatus[2].transform.parent.Find("Text_Label").GetComponent<Text>().text = JpStringLiterals.StringLiteral_11064;
			m_subStatus[3].transform.parent.Find("Text_Label").GetComponent<Text>().text = JpStringLiterals.StringLiteral_11065;

			m_status[0].transform.parent.parent.Find("Image_Bg/Text_StatusLabel").GetComponent<Text>().text = JpStringLiterals.UMO_Status;
			m_subStatus[0].transform.parent.parent.Find("Image_Bg/Text_SupportLabel").GetComponent<Text>().text = JpStringLiterals.UMO_SubStatus;

			m_centerSkillRegulation[0].transform.parent.parent.Find("Image_Bg/Text_CSKillLabel").GetComponent<Text>().text = JpStringLiterals.UMO_CenterSkill;
			m_activeSkill.transform.parent.Find("Image_Bg/Text_ASKillLabel").GetComponent<Text>().text = JpStringLiterals.UMO_ActiveSkill;

			m_limitBreakText[0].transform.parent.parent.Find("Image_Bg/Text_LeafLabel").GetComponent<Text>().text = JpStringLiterals.UMO_LeafLabel;
			m_limitBreakText[0].transform.parent.Find("Text_Label").GetComponent<Text>().text = JpStringLiterals.UMO_Excellent;
			m_limitBreakText[1].transform.parent.Find("Text_Label").GetComponent<Text>().text = JpStringLiterals.UMO_CenterLiveSkillNote;

			m_notesTexts[0].transform.parent.parent.Find("Image_Bg/Text_NotesLabel").GetComponent<Text>().text = JpStringLiterals.UMO_Notes;
			m_notesTexts[0].transform.parent.Find("Text_Label").GetComponent<Text>().text = JpStringLiterals.UMO_Heal;
			m_notesTexts[1].transform.parent.Find("Text_Label").GetComponent<Text>().text = JpStringLiterals.UMO_Score;
			m_notesTexts[2].transform.parent.Find("Text_Label").GetComponent<Text>().text = JpStringLiterals.StringLiteral_13085;
			m_notesTexts[3].transform.parent.Find("Text_Label").GetComponent<Text>().text = JpStringLiterals.UMO_Fold;
			m_notesTexts[4].transform.parent.Find("Text_Label").GetComponent<Text>().text = JpStringLiterals.UMO_Atk;

			m_supportLock.transform.Find("Message/HGroup/Text_ImpMessage").GetComponent<Text>().text = JpStringLiterals.UMO_SupportImp;
			m_supportLock.transform.Find("Message/Text_ImpMessage").GetComponent<Text>().text = JpStringLiterals.UMO_SupportImp2;
		}

		//// RVA: 0xA778EC Offset: 0xA778EC VA: 0xA778EC
		public void SetLimitBreakValue(LimitOverStatusData status, bool isMusicSelect)
		{
			string str = MessageManager.Instance.GetBank("menu").GetMessageByLabel("unit_diva_status_leaf_attr");
			string fmt = MessageManager.Instance.GetBank("menu").GetMessageByLabel("unit_diva_status_leaf_series");
			m_limitBreakText[0].text = string.Format("{0}%", status.excellentRate + status.excellentRate_SameMusicAttr + status.excellentRate_SameSeriesAttr);
			m_limitBreakText[1].text = string.Format("{0}%", status.centerLiveSkillRate + status.centerLiveSkillRate_SameMusicAttr + status.centerLiveSkillRate_SameSeriesAttr);
			if (isMusicSelect)
			{
				m_limitBreakAttrBonusText[0].text = string.Format(str, status.excellentRate_SameMusicAttr);
				m_limitBreakAttrBonusText[1].text = string.Format(str, status.centerLiveSkillRate_SameMusicAttr);
				m_limitBreakSeriesBonusText[0].text = string.Format(fmt, status.excellentRate_SameSeriesAttr);
				m_limitBreakSeriesBonusText[1].text = string.Format(fmt, status.centerLiveSkillRate_SameSeriesAttr);
				m_limitBreakAttrBonus[0].SetActive(status.excellentRate_SameMusicAttr != 0);
				m_limitBreakAttrBonus[1].SetActive(status.centerLiveSkillRate_SameMusicAttr != 0);
				m_limitBreakSeriesBonus[0].SetActive(status.excellentRate_SameSeriesAttr != 0);
				m_limitBreakSeriesBonus[1].SetActive(status.centerLiveSkillRate_SameSeriesAttr != 0);
			}
			else
			{
				m_limitBreakAttrBonus[0].SetActive(false);
				m_limitBreakAttrBonus[1].SetActive(false);
				m_limitBreakSeriesBonus[0].SetActive(false);
				m_limitBreakSeriesBonus[1].SetActive(false);
			}

		}

		//// RVA: 0xA780B8 Offset: 0xA780B8 VA: 0xA780B8
		private void OnShowCenterSkillDetails()
		{
			if (m_mainScene != null)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				if(m_mainScene != null)
				{
					int cnt = 0;
					for(int i = 0; i < m_centerSkillRegulation.Length; i++)
					{
						if (m_centerSkillRegulation[i].activeSelf)
							cnt++;
					}
					MessageBank bk = MessageManager.Instance.GetBank("menu");
					if(m_centerSkillRegulation[2].activeSelf && cnt == 1)
					{
						SetDeckAttrRegPopupContentSetting s = new SetDeckAttrRegPopupContentSetting();
						s.TitleText = bk.GetMessageByLabel("centerskillregulation_popup_title");
						s.WindowSize = SizeType.Small;
						s.SetParent(transform);
						s.Buttons = new ButtonInfo[1]
						{
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
						};
						s.MusicAttribute = m_mainScene.NNOLHKHJPFJ_GetCenterSkillMusicAttr(null, false);
						PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
						{
							//0xC30680
							return;
						}, null, null, null);
					}
					else
					{
						PopupLiveSkillRegulationSetting s = new PopupLiveSkillRegulationSetting();
						s.TitleText = bk.GetMessageByLabel("centerskillregulation_popup_title");
						s.WindowSize = SizeType.Middle;
						s.SetParent(transform);
						s.Buttons = new ButtonInfo[1]
						{
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
						};
						s.ViewSceneData = m_mainScene;
						s.SkillType = 0;
						PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
						{
							//0xC30684
							return;
						}, null, null, null);
					}
				}
			}
		}

		//// RVA: 0xA7886C Offset: 0xA7886C VA: 0xA7886C
		private void CalcLimitBrake(JLKEOGLJNOD_TeamInfo viewUnitData, DFKGGBMFFGB_PlayerInfo viewPlayerData, EEDKAACNBBG_MusicData musicData, EAJCBFGKKFA_FriendInfo friendData)
		{
			m_limitOverStatus.Clear();
			for(int i = 0; i < viewUnitData.BCJEAJPLGMB_MainDivas.Count; i++)
			{
				m_tmpLimitOverStatus.Clear();
				if(viewUnitData.BCJEAJPLGMB_MainDivas[i] != null)
				{
					if (viewUnitData.BCJEAJPLGMB_MainDivas[i].FGFIBOBAPIA_SceneId != 0)
					{
						GCIJNCFDNON_SceneInfo scene = viewPlayerData.OPIBAPEGCLA_Scenes[viewUnitData.BCJEAJPLGMB_MainDivas[i].FGFIBOBAPIA_SceneId - 1];
						IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.MNHPPJFNPCG(ref m_tmpLimitOverStatus, scene.JKGFBFPIMGA_Rarity,
							scene.MJBODMOLOBC_Luck, scene.MKHFCGPJPFI_LimitOverCount);
						AdjustOverLimit(m_tmpLimitOverStatus, scene, musicData);
						m_limitOverStatus.Add(m_tmpLimitOverStatus);
					}
					for(int j = 0; j < viewUnitData.BCJEAJPLGMB_MainDivas[i].DJICAKGOGFO_SubSceneIds.Count; j++)
					{
						if (viewUnitData.BCJEAJPLGMB_MainDivas[i].DJICAKGOGFO_SubSceneIds[j] != 0)
						{
							GCIJNCFDNON_SceneInfo scene = viewPlayerData.OPIBAPEGCLA_Scenes[viewUnitData.BCJEAJPLGMB_MainDivas[i].DJICAKGOGFO_SubSceneIds[j] - 1];
							IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.MNHPPJFNPCG(ref m_tmpLimitOverStatus, scene.JKGFBFPIMGA_Rarity,
								scene.MJBODMOLOBC_Luck, scene.MKHFCGPJPFI_LimitOverCount);
							AdjustOverLimit(m_tmpLimitOverStatus, scene, musicData);
							m_limitOverStatus.Add(m_tmpLimitOverStatus);
						}
					}
				}
			}
			if (friendData == null || friendData.KHGKPKDBMOH_GetAssistScene() == null)
				return;
			GCIJNCFDNON_SceneInfo fscene = friendData.KHGKPKDBMOH_GetAssistScene();
			IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.MNHPPJFNPCG(ref m_tmpLimitOverStatus,
				fscene.JKGFBFPIMGA_Rarity, fscene.MJBODMOLOBC_Luck, friendData.KHGKPKDBMOH_GetAssistScene().MKHFCGPJPFI_LimitOverCount);
			AdjustOverLimit(m_tmpLimitOverStatus, fscene, musicData);
			m_limitOverStatus.Add(m_tmpLimitOverStatus);
		}

		//// RVA: 0xA78E14 Offset: 0xA78E14 VA: 0xA78E14
		private void AdjustOverLimit(LimitOverStatusData status, GCIJNCFDNON_SceneInfo sceneData, EEDKAACNBBG_MusicData musicData)
		{
			if(musicData == null)
			{
				m_tmpLimitOverStatus.excellentRate_SameSeriesAttr = 0;
				m_tmpLimitOverStatus.centerLiveSkillRate_SameSeriesAttr = 0;
				m_tmpLimitOverStatus.excellentRate_SameMusicAttr = 0;
				m_tmpLimitOverStatus.centerLiveSkillRate_SameMusicAttr = 0;
			}
			else
			{
				if((int)sceneData.AIHCEGFANAM_SceneSeries != musicData.AIHCEGFANAM_Serie)
				{
					status.excellentRate_SameSeriesAttr = 0;
					status.centerLiveSkillRate_SameSeriesAttr = 0;
				}
				if (CMMKCEPBIHI.OJNOJNEKBKH(sceneData.JGJFIJOCPAG_SceneAttr, musicData.FKDCCLPGKDK_JacketAttr))
				{
					status.excellentRate_SameMusicAttr = 0;
					status.centerLiveSkillRate_SameMusicAttr = 0;
				}
			}
		}

		//// RVA: 0xA78FC4 Offset: 0xA78FC4 VA: 0xA78FC4
		private void OnShowSubPlateWindowButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_ShowSubPlateWindowButton(false));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x730D9C Offset: 0x730D9C VA: 0x730D9C
		//// RVA: 0xA7903C Offset: 0xA7903C VA: 0xA7903C
		private IEnumerator Co_ShowSubPlateWindowButton(bool isReShow = false)
		{
			//0xC306D8
			bool isWait = true;
			WaitWhile w = new WaitWhile(() =>
			{
				//0xC30694
				return isWait;
			});
			if(SubPlateResult.CDOCOLOKCJK())
			{
				MenuScene.Instance.UnitSaveWindowControl.ShowSubPlateWindow(SubPlateResult, null, m_operationMode, () =>
				{
					//0xC3069C
					isWait = false;
				}, () =>
				{
					//0xC30688
					return;
				}, isReShow);
			}
			else
			{
				MenuScene.Instance.UnitSaveWindowControl.ShowSubPlateLockWindow(() =>
				{
					//0xC306A8
					isWait = false;
				});
			}
			yield return w;
		}

		//// RVA: 0xA790E0 Offset: 0xA790E0 VA: 0xA790E0
		private void SetInvalidText(bool isInvalid)
		{
			if(isInvalid)
			{
				m_statusInvalid.SetActive(true);
				for(int i = 0; i < m_status.Length; i++)
				{
					m_status[i].gameObject.SetActive(false);
				}
				SetInvalidSubPlate();
				m_activeSkill.SetActive(false);
				m_activeSkillInvalid.SetActive(true);
				m_centerSkillRegulationButton.gameObject.SetActive(false);
				m_centerSkillNonActive[1].SetActive(false);
				m_centerSkillNonActive[0].SetActive(false);
				m_centerSkill[1].SetActive(false);
				m_centerSkill[0].SetActive(false);
				m_centerSkillInvalid[1].SetActive(true);
				m_centerSkillInvalid[0].SetActive(true);
				for(int i = 0; i < m_centerSkillRegulation.Length; i++)
				{
					m_centerSkillRegulation[i].SetActive(false);
				}
				for(int i = 0; i < m_notesTexts.Length; i++)
				{
					m_notesTexts[i].text = "---";
				}
				m_limitBreakAttrBonus[0].SetActive(false);
				m_limitBreakAttrBonus[1].SetActive(false);
				m_limitBreakSeriesBonus[0].SetActive(false);
				m_limitBreakSeriesBonus[1].SetActive(false);
			}
			else
			{
				m_statusInvalid.SetActive(false);
				for(int i = 0; i < m_status.Length; i++)
				{
					m_status[i].gameObject.SetActive(true);
				}
				m_activeSkill.SetActive(true);
				m_activeSkillInvalid.SetActive(false);
				m_centerSkill[1].SetActive(true);
				m_centerSkill[0].SetActive(true);
				m_centerSkillInvalid[1].SetActive(false);
				m_centerSkillInvalid[0].SetActive(false);
			}
		}

		//// RVA: 0xA79A40 Offset: 0xA79A40 VA: 0xA79A40
		public void UpdateContent(DFKGGBMFFGB_PlayerInfo viewPlayerData, JLKEOGLJNOD_TeamInfo viewUnitData, EEDKAACNBBG_MusicData viewMusicData, EJKBKMBJMGL_EnemyData enemyData, EAJCBFGKKFA_FriendInfo viewFriendData, UnitWindowConstant.OperationMode opMode, bool isGoDiva)
		{
			ResetScrollText();
			m_operationMode = opMode;
			bool isInvalid = true;
			for(int i = 0; i < viewUnitData.BCJEAJPLGMB_MainDivas.Count; i++)
			{
				if (viewUnitData.BCJEAJPLGMB_MainDivas[i] != null)
				{
					isInvalid = false;
					break;
				}
			}
			int luck = 0;
			for (int i = 0; i < viewUnitData.BCJEAJPLGMB_MainDivas.Count; i++)
			{
				luck += DivaIconDecoration.GetEquipmentLuck(viewUnitData.BCJEAJPLGMB_MainDivas[i], viewPlayerData);
			}
			int luck2 = 0;
			AEGLGBOGDHH res;
			CalcStatus(ref m_baseStatus, ref m_addStatus, out luck2, viewPlayerData, viewUnitData, viewMusicData, viewFriendData, enemyData, out res);
			m_addStatus.Add(m_baseStatus);
			if(SubPlateResult.CDOCOLOKCJK())
			{
				SetSubPlateParam();
				m_supportButton.Disable = false;
				m_supportLock.SetActive(false);
			}
			else
			{
				SetInvalidSubPlate();
				m_supportButton.Disable = true;
				m_supportLock.SetActive(true);
			}
			CalcLimitBrake(viewUnitData, viewPlayerData, viewMusicData, viewFriendData);
			SetInvalidText(isInvalid);
			if(isInvalid)
			{
				m_supportButton.Disable = true;
				return;
			}
			if (SubPlateResult.CDOCOLOKCJK())
			{
				m_status[0].Set(m_baseStatus.Total - SubPlateResult.CMCKNKKCNDK.Total, m_addStatus.Total - SubPlateResult.CMCKNKKCNDK.Total, false, res.IJACIMIPBBK_IsBufftarget(MKHCIKICBOI.MKADAMIGMPO_SoulVocalCharm), res.ADENHAHPBCJ_IsDebuffTarget(MKHCIKICBOI.MKADAMIGMPO_SoulVocalCharm), "#"+ColorExtension.HexStringRGBA(m_normalColorCode), 9999999);
				m_status[1].Set(m_baseStatus.soul - SubPlateResult.CMCKNKKCNDK.soul, m_addStatus.soul - SubPlateResult.CMCKNKKCNDK.soul, false, res.IJACIMIPBBK_IsBufftarget(MKHCIKICBOI.BICPBLMPBPH_Soul), res.ADENHAHPBCJ_IsDebuffTarget(MKHCIKICBOI.BICPBLMPBPH_Soul), "#" + ColorExtension.HexStringRGBA(m_normalColorCode), 999999);
				m_status[2].Set(m_baseStatus.vocal - SubPlateResult.CMCKNKKCNDK.vocal, m_addStatus.vocal - SubPlateResult.CMCKNKKCNDK.vocal, false, res.IJACIMIPBBK_IsBufftarget(MKHCIKICBOI.GPCMMGOCPHC_Vocal), res.ADENHAHPBCJ_IsDebuffTarget(MKHCIKICBOI.GPCMMGOCPHC_Vocal), "#" + ColorExtension.HexStringRGBA(m_normalColorCode), 999999);
				m_status[3].Set(m_baseStatus.charm - SubPlateResult.CMCKNKKCNDK.charm, m_addStatus.charm - SubPlateResult.CMCKNKKCNDK.charm, false, res.IJACIMIPBBK_IsBufftarget(MKHCIKICBOI.LGOHMPBLPKA_Charm), res.ADENHAHPBCJ_IsDebuffTarget(MKHCIKICBOI.LGOHMPBLPKA_Charm), "#" + ColorExtension.HexStringRGBA(m_normalColorCode), 999999);
			}
			else
			{
				SetInvalidSubPlate();
				m_status[0].Set(m_baseStatus.Total, m_addStatus.Total, false, res.IJACIMIPBBK_IsBufftarget(MKHCIKICBOI.MKADAMIGMPO_SoulVocalCharm), res.ADENHAHPBCJ_IsDebuffTarget(MKHCIKICBOI.MKADAMIGMPO_SoulVocalCharm), "#" + ColorExtension.HexStringRGBA(m_normalColorCode), 9999999);
				m_status[1].Set(m_baseStatus.soul, m_addStatus.soul, false, res.IJACIMIPBBK_IsBufftarget(MKHCIKICBOI.BICPBLMPBPH_Soul), res.ADENHAHPBCJ_IsDebuffTarget(MKHCIKICBOI.BICPBLMPBPH_Soul), "#" + ColorExtension.HexStringRGBA(m_normalColorCode), 999999);
				m_status[2].Set(m_baseStatus.vocal, m_addStatus.vocal, false, res.IJACIMIPBBK_IsBufftarget(MKHCIKICBOI.GPCMMGOCPHC_Vocal), res.ADENHAHPBCJ_IsDebuffTarget(MKHCIKICBOI.GPCMMGOCPHC_Vocal), "#" + ColorExtension.HexStringRGBA(m_normalColorCode), 999999);
				m_status[3].Set(m_baseStatus.charm, m_addStatus.charm, false, res.IJACIMIPBBK_IsBufftarget(MKHCIKICBOI.LGOHMPBLPKA_Charm), res.ADENHAHPBCJ_IsDebuffTarget(MKHCIKICBOI.LGOHMPBLPKA_Charm), "#" + ColorExtension.HexStringRGBA(m_normalColorCode), 999999);
			}
			m_status[4].Set(m_baseStatus.life, m_addStatus.life, false, res.IJACIMIPBBK_IsBufftarget(MKHCIKICBOI.ECHJOKLBHEJ_Life), res.ADENHAHPBCJ_IsDebuffTarget(MKHCIKICBOI.ECHJOKLBHEJ_Life), "#" + ColorExtension.HexStringRGBA(m_normalColorCode), 999999);
			m_status[7].Set(luck, luck + luck2, false, res.IJACIMIPBBK_IsBufftarget(MKHCIKICBOI.OHOKFCJNFDO_Luck), res.ADENHAHPBCJ_IsDebuffTarget(MKHCIKICBOI.OHOKFCJNFDO_Luck), "#" + ColorExtension.HexStringRGBA(m_normalColorCode), 999999);
			m_status[5].Set(m_baseStatus.support, m_addStatus.support, false, res.IJACIMIPBBK_IsBufftarget(MKHCIKICBOI.AHJNCHAONGN_Support), res.ADENHAHPBCJ_IsDebuffTarget(MKHCIKICBOI.AHJNCHAONGN_Support), "#" + ColorExtension.HexStringRGBA(m_normalColorCode), 999999);
			m_status[6].Set(m_baseStatus.fold, m_addStatus.fold, false, res.IJACIMIPBBK_IsBufftarget(MKHCIKICBOI.ONBNGGDFAJK_Fold), res.ADENHAHPBCJ_IsDebuffTarget(MKHCIKICBOI.ONBNGGDFAJK_Fold), "#" + ColorExtension.HexStringRGBA(m_normalColorCode), 999999);
			if(viewFriendData == null)
			{
				m_notesTexts[0].text = m_baseStatus.spNoteExpected[1].ToString();
				m_notesTexts[2].text = m_baseStatus.spNoteExpected[3].ToString();
				m_notesTexts[1].text = m_baseStatus.spNoteExpected[2].ToString();
				m_notesTexts[3].text = m_baseStatus.spNoteExpected[4].ToString();
				m_notesTexts[4].text = m_baseStatus.spNoteExpected[5].ToString();
			}
			else
			{
				m_tmpStatus.Clear();
				if(viewFriendData.KHGKPKDBMOH_GetAssistScene() != null)
				{
					m_tmpStatus.Copy(viewFriendData.KHGKPKDBMOH_GetAssistScene().CMCKNKKCNDK_Status);
				}
				m_notesTexts[0].text = (m_baseStatus.spNoteExpected[1] - m_tmpStatus.spNoteExpected[1]).ToString();
				m_notesTexts[2].text = (m_baseStatus.spNoteExpected[3] - m_tmpStatus.spNoteExpected[3]).ToString();
				m_notesTexts[1].text = (m_baseStatus.spNoteExpected[2] - m_tmpStatus.spNoteExpected[2]).ToString();
				m_notesTexts[3].text = (m_baseStatus.spNoteExpected[4] - m_tmpStatus.spNoteExpected[4]).ToString();
				m_notesTexts[4].text = (m_baseStatus.spNoteExpected[5] - m_tmpStatus.spNoteExpected[5]).ToString();
			}
			SetLimitBreakValue(m_limitOverStatus, viewMusicData != null);
			m_centerSkillNonActive[1].SetActive(false);
			m_centerSkillNonActive[0].SetActive(false);
			m_centerSkill[1].SetActive(false);
			m_centerSkill[0].SetActive(false);
			m_centerSkillRegulationButton.gameObject.SetActive(false);
			for(int i = 0; i < m_centerSkillRegulation.Length; i++)
			{
				m_centerSkillRegulation[i].SetActive(false);
			}
			m_mainScene = null;
			FFHPBEPOMAK_DivaInfo f = viewUnitData.BCJEAJPLGMB_MainDivas[0];
			if (f != null)
			{
				if(f.FGFIBOBAPIA_SceneId > 0)
				{
					m_mainScene = viewPlayerData.OPIBAPEGCLA_Scenes[f.FGFIBOBAPIA_SceneId - 1];
				}
			}
			if(m_mainScene != null)
			{
				var ab = m_mainScene.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0);
				m_centerSkill[1].SetActive(ab != 0);
				var aa = m_mainScene.MEOOLHNNMHL_GetCenterSkillId(true, 0, 0);
				if (aa == ab)
					aa = 0;
				m_centerSkill[0].SetActive(aa != 0);
				if(m_centerSkill[1].activeSelf && !m_centerSkill[0].activeSelf)
				{
					m_centerSkill[1].transform.parent.SetSiblingIndex(1);
					m_centerSkill[0].transform.parent.SetSiblingIndex(2);
				}
				else
				{
					m_centerSkill[1].transform.parent.SetSiblingIndex(2);
					m_centerSkill[0].transform.parent.SetSiblingIndex(1);
				}
				int g = m_mainScene.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0);
				if(viewMusicData == null)
				{
					if(m_mainScene.IFBJBPEBAFH_HasCenterSkillCondSerie(null, false))
					{
						m_centerSkillRegulation[1].SetActive(true);
					}
					if(m_mainScene.IFBJBPEBAFH_HasCenterSkillCondSerie(null, true))
					{
						m_centerSkillRegulation[1].SetActive(true);
					}
					if(m_mainScene.ABIOBCMPEHM_SkillSwitchPatternCondition() == SkillSwitchPatternCondition.Type.SeriesAttr_Scn)
					{
						m_centerSkillRegulation[1].SetActive(true);
					}
					if(m_mainScene.FCGHOLNFDDF_HasCenterSkillCondMusicAttr(null, false))
					{
						m_centerSkillRegulation[2].SetActive(true);
					}
					if (m_mainScene.FCGHOLNFDDF_HasCenterSkillCondMusicAttr(null, true))
					{
						m_centerSkillRegulation[2].SetActive(true);
					}
				}
				else
				{
					int a = m_mainScene.MEOOLHNNMHL_GetCenterSkillId(false, viewMusicData.FKDCCLPGKDK_JacketAttr, viewMusicData.AIHCEGFANAM_Serie);
					g = a;
					if (a > 0)
					{
						EONOEHOKBEB_Music m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(viewMusicData.DLAEJOBELBH_MusicId);
						if (m_mainScene.IFBJBPEBAFH_HasCenterSkillCondSerie(m, false))
						{
							m_centerSkillRegulation[1].SetActive(true);
							if(!m_mainScene.JDAEAJNJBGI_IsMatchCenterSkillSerie(viewMusicData.DLAEJOBELBH_MusicId))
							{
								m_centerSkillNonActive[1].SetActive(true);
								m_centerSkillRegulationText[1].text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("unit_status_skill_regulation_series_n");
							}
						}
						if(aa != 0 && m_mainScene.IFBJBPEBAFH_HasCenterSkillCondSerie(m, true))
						{
							m_centerSkillRegulation[1].SetActive(true);
							if(!m_mainScene.JDAEAJNJBGI_IsMatchCenterSkillSerie(viewMusicData.DLAEJOBELBH_MusicId))
							{
								m_centerSkillNonActive[0].SetActive(true);
								m_centerSkillRegulationText[0].text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("unit_status_skill_regulation_series_n");
							}
							else
							{
								m_centerSkillNonActive[1].SetActive(true);
								m_centerSkillRegulationText[1].text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("unit_status_skill_regulation_series_y");
							}
						}
						if(m_mainScene.FCGHOLNFDDF_HasCenterSkillCondMusicAttr(m, false))
						{
							m_centerSkillRegulation[2].SetActive(true);
							if(!m_mainScene.KAFAAPEBCPD(viewMusicData.DLAEJOBELBH_MusicId, false))
							{
								m_centerSkillNonActive[1].SetActive(true);
								m_centerSkillRegulationText[1].text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("unit_status_skill_regulation_attr");
							}
						}
						if(aa != 0 && m_mainScene.FCGHOLNFDDF_HasCenterSkillCondMusicAttr(m, true))
						{
							m_centerSkillRegulation[2].SetActive(true);
							if(m_mainScene.ABIOBCMPEHM_SkillSwitchPatternCondition() == SkillSwitchPatternCondition.Type.SeriesAttr_Scn)
							{
								m_centerSkillRegulation[1].SetActive(true);
								if(m_mainScene.KAFAAPEBCPD(viewMusicData.DLAEJOBELBH_MusicId, true) && (int)m_mainScene.AIHCEGFANAM_SceneSeries != m.AIHCEGFANAM_SerieAttr)
								{
									m_centerSkillNonActive[0].SetActive(true);
									m_centerSkillRegulationText[0].text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("unit_status_skill_regulation_series_n");
								}
								else if(!m_mainScene.KAFAAPEBCPD(viewMusicData.DLAEJOBELBH_MusicId, true) && (int)m_mainScene.AIHCEGFANAM_SceneSeries != m.AIHCEGFANAM_SerieAttr)
								{
									m_centerSkillNonActive[1].SetActive(true);
									m_centerSkillRegulationText[1].text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("unit_status_skill_regulation_attr");
									m_centerSkillNonActive[0].SetActive(true);
									m_centerSkillRegulationText[0].text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("unit_status_skill_regulation_attr");
								}
								if(m_mainScene.KAFAAPEBCPD(viewMusicData.DLAEJOBELBH_MusicId, true) && (int)m_mainScene.AIHCEGFANAM_SceneSeries == m.AIHCEGFANAM_SerieAttr)
								{
									m_centerSkillNonActive[1].SetActive(true);
									m_centerSkillRegulationText[1].text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("unit_status_skill_regulation_series_y");
								}
								else if(!m_mainScene.KAFAAPEBCPD(viewMusicData.DLAEJOBELBH_MusicId, true) && (int)m_mainScene.AIHCEGFANAM_SceneSeries == m.AIHCEGFANAM_SerieAttr)
								{
									m_centerSkillNonActive[1].SetActive(true);
									m_centerSkillRegulationText[1].text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("unit_status_skill_regulation_attr");
									m_centerSkillNonActive[0].SetActive(true);
									m_centerSkillRegulationText[0].text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("unit_status_skill_regulation_attr");
								}
							}
							else
							{
								if (m_mainScene.KAFAAPEBCPD(viewMusicData.DLAEJOBELBH_MusicId, true))
								{
									m_centerSkillNonActive[1].SetActive(true);
									m_centerSkillRegulationText[1].text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("unit_status_skill_regulation_series_y");
								}
								else
								{
									m_centerSkillNonActive[0].SetActive(true);
									m_centerSkillRegulationText[0].text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("unit_status_skill_regulation_attr");
								}
							}
						}
					}
				}
				for(int i = 0; i < m_centerSkillRegulation.Length; i++)
				{
					if(m_centerSkillRegulation[i].activeSelf)
					{
						m_centerSkillRegulationButton.gameObject.SetActive(true);
					}
				}
				if(g > 0)
				{
					m_centerSkillLevelText[1].text = string.Format("Lv{0}", m_mainScene.AADFFCIDJCB_LiveSkillLevel);
					m_centerSkillLevelText[0].text = string.Format("Lv{0}", m_mainScene.AADFFCIDJCB_LiveSkillLevel);
					if(ab > 0)
					{
						GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_centerSkillRankImage[1], (SkillRank.Type)m_mainScene.DHEFMEGKKDN_CenterSkillRank);
						m_centerSkillEffectText[1].text = m_mainScene.IHLINMFMCDN_GetCenterSkillDesc(false);
						m_centerSkillNameText[1].text = m_mainScene.PFHJFIHGCKP_CenterSkillName1;
						if(aa > 0)
						{
							GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_centerSkillRankImage[0], (SkillRank.Type)m_mainScene.FFDCGHDNDFJ_CenterSkillRank2);
							m_centerSkillEffectText[0].text = m_mainScene.IHLINMFMCDN_GetCenterSkillDesc(true);
							m_centerSkillNameText[0].text = m_mainScene.EFELCLMJEOL_CenterSkillName2;
						}
					}
				}
			}
			if (!m_centerSkill[1].activeSelf)
			{
				GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_centerSkillRankImage[1], 0);
				m_centerSkillInvalid[1].SetActive(true);
			}
			if (!m_centerSkill[0].activeSelf)
			{
				GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_centerSkillRankImage[0], 0);
				m_centerSkillInvalid[0].SetActive(true);
			}
			if(m_mainScene == null || m_mainScene.HGONFBDIBPM_ActiveSkillId < 1)
			{
				m_activeSkill.SetActive(false);
				m_activeSkillInvalid.SetActive(true);
				GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_activeSkillRankImage, 0);
			}
			else
			{
				GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_activeSkillRankImage, (SkillRank.Type) m_mainScene.BEKGEAMJGEN_ActiveSkillRank);
				m_activeSkillEffectText.text = m_mainScene.PCMEMHPDABG_GetActiveSkillDesc().Replace(JpStringLiterals.StringLiteral_20382, string.Format(JpStringLiterals.StringLiteral_20383, SystemTextColor.ImportantColor));
				m_activeSkillNameText.text = m_mainScene.ILCLGGPHHJO_ActiveSkillName;
				m_activeSkillLevelText.text = string.Format("Lv{0}", m_mainScene.PNHJPCPFNFI_ActiveSkillLevel);
				m_activeSkill.SetActive(true);
				m_activeSkillInvalid.SetActive(false);
			}
		}

		//// RVA: 0xA7D6A0 Offset: 0xA7D6A0 VA: 0xA7D6A0
		public void CalcStatus(ref StatusData baseStatus, ref StatusData addStatus, out int luck, DFKGGBMFFGB_PlayerInfo viewPlayerData, JLKEOGLJNOD_TeamInfo unitData, EEDKAACNBBG_MusicData viewMusicData, EAJCBFGKKFA_FriendInfo viewFriendPlayerData, EJKBKMBJMGL_EnemyData viewEnemyData, out AEGLGBOGDHH result)
		{
			baseStatus.Clear();
			addStatus.Clear();
			luck = 0;
			baseStatus.Copy(unitData.JLJGCBOHJID_Status);
			result = new AEGLGBOGDHH();
			result.OBKGEDCKHHE();
			result.JCHLONCMPAJ();
			CMMKCEPBIHI.DIDENKKDJKI(ref result, unitData, viewPlayerData, viewMusicData, viewFriendPlayerData, viewEnemyData);
			result.DDPJACNMPEJ(ref addStatus);
			baseStatus.Add(addStatus);
			result.GEEDEOHGMOM(ref addStatus);
			SubPlateResult = result.CLCIOEHGFNI;
			m_tmpStatus.Clear();
			if(viewFriendPlayerData == null || viewFriendPlayerData.KHGKPKDBMOH_GetAssistScene() == null)
			{
				return;
			}
			m_tmpStatus.Copy(viewFriendPlayerData.KHGKPKDBMOH_GetAssistScene().CMCKNKKCNDK_Status);
			luck += viewFriendPlayerData.KHGKPKDBMOH_GetAssistScene().MJBODMOLOBC_Luck;
			baseStatus.Add(m_tmpStatus);
		}

		//// RVA: 0xA79920 Offset: 0xA79920 VA: 0xA79920
		private void SetInvalidSubPlate()
		{
			string col = "#" + m_normalColorCode.HexStringRGBA();
			for(int i = 0; i < m_subStatus.Length; i++)
			{
				m_subStatus[i].Set("---", false, false, false, col);
			}
		}

		//// RVA: 0xA7D9D0 Offset: 0xA7D9D0 VA: 0xA7D9D0
		private void SetSubPlateParam()
		{
			string hexa = "#" + m_normalColorCode.HexStringRGBA();
			int[] a = new int[4]
			{
				SubPlateResult.CMCKNKKCNDK.Total,
				SubPlateResult.CMCKNKKCNDK.soul,
				SubPlateResult.CMCKNKKCNDK.vocal,
				SubPlateResult.CMCKNKKCNDK.charm
			};
			int d = 0;
			for (int i = 1; i < 4; i++)
			{
				int c = SubPlateResult.KOGBMDOONFA[i - 1, 0].IKEJLHJEANO - 1;
				d |= (c + 1);
				m_subStatus[i].Set(Mathf.Min(a[i], 999999).ToString(), false, (c > 0 && c < 3) && (c & 1) == 0, (c > 0 && c < 3) && (((6 >> (c & 7)) & 1) != 0), hexa);
			}
			if(d < 1)
			{
				m_subStatus[0].Set(Mathf.Min(a[0], 999999).ToString(), false, false, false, hexa);
			}
			else
			{
				int c = d - 1;
				m_subStatus[0].Set(Mathf.Min(a[0], 999999).ToString(), false, (c > 0 && c < 3) && (c & 1) == 0, (c > 0 && c < 3) && (((6 >> (c & 7)) & 1) != 0), hexa);
			}
		}

		//// RVA: 0xA7D604 Offset: 0xA7D604 VA: 0xA7D604
		private void ResetScrollText()
		{
			if(m_scrollTexts != null)
			{
				for(int i = 0; i < m_scrollTexts.Length; i++)
				{
					m_scrollTexts[i].ResetScroll();
				}
			}
		}
	}
}
