using UnityEngine.EventSystems;
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine.UI;
using XeSys;
using mcrs;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class SceneComparisonPopup : UIBehaviour, IPopupContent, ILayoutUGUIPaste
	{
		[SerializeField]
		private SceneComparisonParam[] m_params; // 0xC
		[SerializeField]
		private InfoButton m_infoButton; // 0x10
		[SerializeField]
		private RepeatButton m_scorePlusButton; // 0x14
		[SerializeField]
		private RepeatButton m_scoreMinusButton; // 0x18
		[SerializeField]
		private UnitExpectedScore[] m_scoreGauges; // 0x1C
		[SerializeField]
		private RawImageEx m_scoreTotalArrowImage; // 0x20
		[SerializeField]
		private RawImageEx m_scorePlusImage; // 0x24
		[SerializeField]
		private Text[] m_textGaugeNames; // 0x28
		[SerializeField]
		private Text m_gaugeRateText; // 0x2C
		[SerializeField]
		private LayoutUGUIRuntime m_runtime; // 0x30
		private TexUVList m_cmnTexUvList; // 0x34
		private AbsoluteLayout m_layoutGauge; // 0x38
		private AbsoluteLayout m_layoutScoreTotalAfter; // 0x3C
		private DivaComparisonPopupSetting m_popupSetting; // 0x40

		public Transform Parent { get; set; } // 0x44

		// RVA: 0x15A3804 Offset: 0x15A3804 VA: 0x15A3804 Slot: 24
		public bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_cmnTexUvList = uvMan.GetTexUVList("cmn_tex_pack");
			m_layoutGauge = layout.FindViewById("sw_gauge_onoff_anim") as AbsoluteLayout;
			m_layoutScoreTotalAfter = layout.FindViewByExId("sw_gauge_change_anim_gauge_after") as AbsoluteLayout;
			m_scorePlusButton.AddOnClickCallback(() =>
			{
				//0x15A5E9C
				OnPushScoreRate(UnitExpectedScore.defaultAddGaugeRatio);
			});
			m_scorePlusButton.AddOnRepeatCallback(() =>
			{
				//0x15A5EC0
				OnPushScoreRate(UnitExpectedScore.defaultAddGaugeRatio);
			});
			m_scoreMinusButton.AddOnClickCallback(() =>
			{
				//0x15A5EE4
				OnPushScoreRate(-UnitExpectedScore.defaultAddGaugeRatio);
			});
			m_scoreMinusButton.AddOnRepeatCallback(() =>
			{
				//0x15A5F08
				OnPushScoreRate(-UnitExpectedScore.defaultAddGaugeRatio);
			});
			m_scorePlusImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetTexUVList("sel_card_03_pack").GetUVData("cmn_con_plus_symbol"));
			return true;
		}

		//// RVA: 0x15A3BC0 Offset: 0x15A3BC0 VA: 0x15A3BC0 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			SceneComparisonPopupSetting setting_ = setting as SceneComparisonPopupSetting;
			Parent = setting.m_parent;
			bool is6Line = false;
			SceneComparisonParam.Style style = SceneComparisonParam.Style.Param;
			if(setting_.DivaData == null)
			{
				m_infoButton.Hidden = true;
				style = SceneComparisonParam.Style.Assist;
			}
			else
			{
				if(setting_.MusicBaseData != null)
				{
					style = 0;
					m_infoButton.Hidden = false;
					is6Line = Database.Instance.gameSetup.musicInfo.IsLine6Mode;
					m_infoButton.OnClickButton = (int page) =>
					{
						//0x15A5F2C
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
						for(int i = 0; i < m_params.Length; i++)
						{
							m_params[i].ChangeStyle();
						}
					};
				}
				else
				{
					m_infoButton.Hidden = false;
					m_infoButton.OnClickButton = (int page) =>
					{
						//0x15A6018
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
						for (int i = 0; i < m_params.Length; i++)
						{
							m_params[i].ChangeDisplay(page - 1);
						}
					};
					style = SceneComparisonParam.Style.None;
				}
			}
			m_params[0].UpdateContent(style, setting_.BeforeScene, setting_.BeforeScene, setting_.PlayerData, setting_.DivaData, setting_.SceneSlotIndex, setting_.DivaSlot, setting_.MusicBaseData != null ? setting_.MusicBaseData.DLAEJOBELBH_MusicId : 0, setting_.IsGoDiva);
			m_params[1].UpdateContent(style, setting_.AfterScene, setting_.BeforeScene, setting_.PlayerData, setting_.DivaData, setting_.SceneSlotIndex, setting_.DivaSlot, setting_.MusicBaseData != null ? setting_.MusicBaseData.DLAEJOBELBH_MusicId : 0, setting_.IsGoDiva);
			for(int i = 0; i < m_params.Length; i++)
			{
				m_params[i].InitializeDecoration();
				m_params[i].UpdateDecoration(DisplayType.Level);
			}
			if(/*(style & 4) == 0*/style <= SceneComparisonParam.Style.Max)
			{
				for(int i = 0; i < 10; i++)
				{
					m_textGaugeNames[i].text = MessageManager.Instance.GetBank("menu").GetMessageByLabel(string.Format("pop_score_detail_item_name_{0:00}", i + 1));
				}
				DFKGGBMFFGB_PlayerInfo playerInfo = new DFKGGBMFFGB_PlayerInfo();
				playerInfo.KHEKNNFCAOI_Init(null, false);
				CalcScoreGauge(setting_.BeforeScene, playerInfo, setting_, is6Line, setting_.IsGoDiva);
				float gaugeRatio = Mathf.Max(1.0f, CMMKCEPBIHI.FDLECNKJCGG_GaugeRatio);
				int total1 = SetScoreGauge(0);
				playerInfo.KHEKNNFCAOI_Init(null, false);
				CalcScoreGauge(setting_.AfterScene, playerInfo, setting_, is6Line, setting_.IsGoDiva);
				float gaugeRatio2 = Mathf.Max(1.0f, CMMKCEPBIHI.FDLECNKJCGG_GaugeRatio);
				int total2 = SetScoreGauge(1);
				UpdateScoreGaugeRatio();
				ComparisonValue(total1, total2);
				SetNotes(0, setting_);
				SetNotes(1, setting_);
				m_infoButton.SetPage(m_params[0].GetStyleIndex() + 1, m_params[0].GetStyleMax());
				m_layoutGauge.StartChildrenAnimGoStop("01");
			}
			else
			{
				m_infoButton.SetPage(m_params[0].GetDisplayIndex() + 1, m_params[0].GetDisplayMax());
				m_layoutGauge.StartChildrenAnimGoStop("02");
			}
		}

		//// RVA: 0x15A45F4 Offset: 0x15A45F4 VA: 0x15A45F4
		private void CalcScoreGauge(GCIJNCFDNON_SceneInfo vsd, DFKGGBMFFGB_PlayerInfo vpd, SceneComparisonPopupSetting setting, bool isSelected6Line, bool isGoDiva)
		{
			JLKEOGLJNOD_TeamInfo team = vpd.DPLBHAIKPGL_GetTeam(isGoDiva);
			DEKKMGAFJCG_Diva.IFHCNLAODKG attach = new DEKKMGAFJCG_Diva.IFHCNLAODKG();
			attach.AHHJLDLAPAN_DivaId = setting.DivaData.AHHJLDLAPAN_DivaId;
			attach.BCCHOBPJJKE_SceneId = vsd == null ? 0 : vsd.BCCHOBPJJKE_SceneId;
			attach.LGBDBBFEPGL_SceneSlotIdx = setting.SceneSlotIndex;
			attach.NGEADPGADLI_DivaSlot = setting.DivaSlot;
			DEKKMGAFJCG_Diva.IFHCNLAODKG attachInfo = null;
			FFHPBEPOMAK_DivaInfo divaInfo2 = null;
			if (isGoDiva)
			{
				attachInfo = team.JOGOEIEKIHP_GetDivaInfoWithScene(attach.BCCHOBPJJKE_SceneId);
				divaInfo2 = setting.DivaData;
			}
			else
			{
				attachInfo = team.JOGOEIEKIHP_GetDivaInfoWithScene(attach.BCCHOBPJJKE_SceneId);
				divaInfo2 = team.BCJEAJPLGMB_MainDivas.Find((FFHPBEPOMAK_DivaInfo x) =>
				{
					//0x15A6100
					return attach.AHHJLDLAPAN_DivaId == x.AHHJLDLAPAN_DivaId;
				});
			}
			if(attachInfo != null && divaInfo2 != null)
			{
				attachInfo.BCCHOBPJJKE_SceneId = attach.LGBDBBFEPGL_SceneSlotIdx == 0 ? divaInfo2.FGFIBOBAPIA_SceneId : divaInfo2.DJICAKGOGFO_SubSceneIds[attach.LGBDBBFEPGL_SceneSlotIdx - 1];
			}
			AttachScene(vpd, attach, isGoDiva);
			AttachScene(vpd, attachInfo, isGoDiva);
			CMMKCEPBIHI.EFCNOOFFMIL(vpd, setting.FriendPlayerData, setting.MusicBaseData, setting.EnemyData, setting.Difficulty, isSelected6Line, isGoDiva);
		}

		//// RVA: 0x15A5440 Offset: 0x15A5440 VA: 0x15A5440
		private void AttachScene(DFKGGBMFFGB_PlayerInfo vpd, DEKKMGAFJCG_Diva.IFHCNLAODKG attachPos, bool isGoDiva)
		{
			if(attachPos != null)
			{
				JLKEOGLJNOD_TeamInfo team = vpd.DPLBHAIKPGL_GetTeam(isGoDiva);
				GCIJNCFDNON_SceneInfo sceneInfo = null;
				if(attachPos.BCCHOBPJJKE_SceneId > 0)
				{
					sceneInfo = vpd.OPIBAPEGCLA_Scenes[attachPos.BCCHOBPJJKE_SceneId - 1];
					for(int i = 0; i < team.BCJEAJPLGMB_MainDivas.Count; i++)
					{
						FFHPBEPOMAK_DivaInfo divaInfo = team.BCJEAJPLGMB_MainDivas[i];
						if(divaInfo != null)
						{
							if(attachPos.AHHJLDLAPAN_DivaId == divaInfo.AHHJLDLAPAN_DivaId && attachPos.NGEADPGADLI_DivaSlot == i)
							{
								GCIJNCFDNON_SceneInfo divaScene = null;
								if(divaInfo.FGFIBOBAPIA_SceneId > 0)
								{
									divaScene = vpd.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
								}
								GCIJNCFDNON_SceneInfo divaScene2 = null;
								if(divaInfo.DJICAKGOGFO_SubSceneIds[0] > 0)
								{
									divaScene2 = vpd.OPIBAPEGCLA_Scenes[divaInfo.DJICAKGOGFO_SubSceneIds[0] - 1];
								}
								GCIJNCFDNON_SceneInfo divaScene3 = null;
								if(divaInfo.DJICAKGOGFO_SubSceneIds[1] > 0)
								{
									divaScene3 = vpd.OPIBAPEGCLA_Scenes[divaInfo.DJICAKGOGFO_SubSceneIds[1] - 1];
								}
								if(attachPos.LGBDBBFEPGL_SceneSlotIdx == 2)
								{
									divaInfo.KHEKNNFCAOI(divaInfo.AHHJLDLAPAN_DivaId, divaInfo.CIEOBFIIPLD_Level, divaInfo.JPIDIENBGKH_CostumeId, 
										divaInfo.EKFONBFDAAP_ColorId, divaScene, new List<GCIJNCFDNON_SceneInfo>() { divaScene2, sceneInfo }, true);
								}
								else if(attachPos.LGBDBBFEPGL_SceneSlotIdx == 1)
								{
									divaInfo.KHEKNNFCAOI(divaInfo.AHHJLDLAPAN_DivaId, divaInfo.CIEOBFIIPLD_Level, divaInfo.JPIDIENBGKH_CostumeId, 
										divaInfo.EKFONBFDAAP_ColorId, divaScene, new List<GCIJNCFDNON_SceneInfo>() { sceneInfo, divaScene3 }, true);
								}
								else if(attachPos.LGBDBBFEPGL_SceneSlotIdx == 0)
								{
									divaInfo.KHEKNNFCAOI(divaInfo.AHHJLDLAPAN_DivaId, divaInfo.CIEOBFIIPLD_Level, divaInfo.JPIDIENBGKH_CostumeId, 
										divaInfo.EKFONBFDAAP_ColorId, sceneInfo, new List<GCIJNCFDNON_SceneInfo>() { divaScene2, divaScene3 }, true);
								}
								if(isGoDiva)
								{
									if(i == 0)
										divaInfo.HCDGELDHFHB();
									else
										divaInfo.ELHBGKLLOIO();
								}
							}
						}
					}
				}
			}
		}

		//// RVA: 0x15A5054 Offset: 0x15A5054 VA: 0x15A5054
		public void SetNotes(int index, SceneComparisonPopupSetting setting)
		{
			GCIJNCFDNON_SceneInfo scene = index == 0 ? setting.BeforeScene : setting.AfterScene;
			m_params[index].SetNotesValue(SpecialNoteAttribute.Type.Heal, scene != null ? scene.CMCKNKKCNDK_Status.spNoteExpected[1] : 0);
			m_params[index].SetNotesValue(SpecialNoteAttribute.Type.Item, scene != null ? scene.CMCKNKKCNDK_Status.spNoteExpected[3] : 0);
			m_params[index].SetNotesValue(SpecialNoteAttribute.Type.HighScore, scene != null ? scene.CMCKNKKCNDK_Status.spNoteExpected[2] : 0);
			m_params[index].SetNotesValue(SpecialNoteAttribute.Type.Fold, scene != null ? scene.CMCKNKKCNDK_Status.spNoteExpected[4] : 0);
			m_params[index].SetNotesValue(SpecialNoteAttribute.Type.Attack, scene != null ? scene.CMCKNKKCNDK_Status.spNoteExpected[5] : 0);
		}

		//// RVA: 0x15A4A88 Offset: 0x15A4A88 VA: 0x15A4A88
		private int SetScoreGauge(int index)
		{
			int[] scores = new int[10];
			float[] rank = new float[5];
			int total = 0;
			for(int i = 0; i < 10; i++)
			{
				scores[i] = CMMKCEPBIHI.NDNOLJACLLC_GetScore((CMMKCEPBIHI.NOJENDEDECD_ScoreType)i);
				total += scores[i];
			}
			for(int i = 0; i < 5; i++)
			{
				rank[i] = CMMKCEPBIHI.GPCKPNJGANO_GetRank((ResultScoreRank.Type)i);
			}
			m_scoreGauges[index].SetScore(CMMKCEPBIHI.KHCOOPDAGOE_ScoreRank, CMMKCEPBIHI.FDLECNKJCGG_GaugeRatio, rank, scores, 1);
			return total;
		}

		//// RVA: 0x15A4D14 Offset: 0x15A4D14 VA: 0x15A4D14
		private void UpdateScoreGaugeRatio()
		{
			for(int i = 0; i < m_scoreGauges.Length; i++)
			{
				m_scoreGauges[i].UpdateScore(m_scoreGauges[i].UpdateScoreGaugeRatio(m_gaugeRateText, m_scorePlusButton, m_scoreMinusButton));
			}
		}

		//// RVA: 0x15A4E20 Offset: 0x15A4E20 VA: 0x15A4E20
		protected void ComparisonValue(int before, int after)
		{
			if(before < after)
			{
				m_scoreTotalArrowImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_cmnTexUvList.GetUVData("cmn_status_icon_up"));
				m_layoutScoreTotalAfter.StartChildrenAnimGoStop("01");
			}
			else if(before == after)
			{
				m_layoutScoreTotalAfter.StartChildrenAnimGoStop("02");
			}
			else
			{
				m_scoreTotalArrowImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_cmnTexUvList.GetUVData("cmn_status_icon_down"));
				m_layoutScoreTotalAfter.StartChildrenAnimGoStop("01");
			}
		}

		//// RVA: 0x15A5C40 Offset: 0x15A5C40 VA: 0x15A5C40
		private void OnPushScoreRate(float addRatio)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			UnitExpectedScore.baseGaugeScale += addRatio;
			UpdateScoreGaugeRatio();
		}

		// RVA: 0x15A5CD0 Offset: 0x15A5CD0 VA: 0x15A5CD0 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x15A5D08 Offset: 0x15A5D08 VA: 0x15A5D08 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
			for(int i = 0; i < m_params.Length; i++)
			{
				m_params[i].ReleaseDecoration();
			}
		}

		// RVA: 0x15A5DCC Offset: 0x15A5DCC VA: 0x15A5DCC Slot: 21
		public bool IsReady()
		{
			for(int i = 0; i < m_params.Length; i++)
			{
				if (m_params[i].IsLoading())
					return false;
			}
			return m_runtime.IsReady;
		}

		// RVA: 0x15A5E88 Offset: 0x15A5E88 VA: 0x15A5E88 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		// RVA: 0x15A5E8C Offset: 0x15A5E8C VA: 0x15A5E8C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}
	}
}
