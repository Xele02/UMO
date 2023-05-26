using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using mcrs;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RegulationButton : ActionButton
	{
		public enum Type
		{
			Center = 0,
			Active = 1,
			Live = 2,
		}

		[SerializeField]
		private Text m_textAttr; // 0x84
		[SerializeField]
		private RawImageEx m_imageAttr; // 0x88
		private LayoutUGUIRuntime m_runtime; // 0x8C
		private TexUVListManager m_uvMan; // 0x90
		private AbsoluteLayout m_layoutTable; // 0x94
		private GCIJNCFDNON_SceneInfo m_sceneData; // 0x98

		public bool IsMisMatchMusic { get; set; } // 0x80
		public bool IsMisMatchSeries { get; set; } // 0x81
		public bool IsMisMatchAttr { get; set; } // 0x82

		// RVA: 0xCFAA50 Offset: 0xCFAA50 VA: 0xCFAA50 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_runtime = GetComponentInParent<LayoutUGUIRuntime>();
			m_uvMan = uvMan;
			m_layoutTable = m_runtime.FindViewBase(transform.parent as RectTransform) as AbsoluteLayout;
			IsMisMatchMusic = false;
			m_layoutTable.StartChildrenAnimGoStop("02");
			Hidden = true;
			return base.InitializeFromLayout(layout, uvMan);
		}

		// // RVA: 0xCFAC48 Offset: 0xCFAC48 VA: 0xCFAC48
		public void Setup(int musicId, Type type, GCIJNCFDNON_SceneInfo sceneData)
		{
			m_sceneData = sceneData;
			IsMisMatchMusic = false;
			IsMisMatchSeries = false;
			IsMisMatchAttr = false;
			EONOEHOKBEB_Music musicInfo = null;
			if(musicId > 0)
			{
				musicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[musicId - 1];
			}
			if(m_sceneData == null)
			{
				IsMisMatchMusic = false;
				IsMisMatchSeries = false;
				IsMisMatchAttr = false;
				m_layoutTable.StartChildrenAnimGoStop("02");
				Hidden = true;
			}
			else
			{
				if(type == Type.Center)
				{
					if(m_sceneData.ABIOBCMPEHM_SkillSwitchPatternCondition() != SkillSwitchPatternCondition.Type.SeriesAttr_Scn)
					{
						if(m_sceneData.IFBJBPEBAFH_HasCenterSkillCondSerie(musicInfo, false))
						{
							ClearOnClickCallback();
							AddOnClickCallback(OpenPopupCompatibleSeries);
							IsMisMatchSeries = !m_sceneData.JDAEAJNJBGI_IsMatchCenterSkillSerie(musicId);
							m_layoutTable.StartChildrenAnimGoStop("03");
							Hidden = false;
						}
						else
						{
							if(!m_sceneData.FCGHOLNFDDF_HasCenterSkillCondMusicAttr(musicInfo, false))
							{
								IsMisMatchMusic = false;
								IsMisMatchSeries = false;
								IsMisMatchAttr = false;
								m_layoutTable.StartChildrenAnimGoStop("02");
								Hidden = true;
							}
							else
							{
								IsMisMatchAttr = !m_sceneData.KAFAAPEBCPD_IsMatchCenterSkillMusicAttr(musicId);
								m_layoutTable.StartChildrenAnimGoStop("04");
								SetAttr(m_sceneData.NNOLHKHJPFJ_GetCenterSkillMusicAttr(musicInfo, false));
								Hidden = true;
							}
						}
					}
					else
					{
						ClearOnClickCallback();
						AddOnClickCallback(OpenPopupCenterSkillDetails);
						m_layoutTable.StartChildrenAnimGoStop("06");
						IsMisMatchAttr = !m_sceneData.KAFAAPEBCPD_IsMatchCenterSkillMusicAttr(musicId);
						Hidden = false;
					}
				}
				else if(type == Type.Live)
				{
					if(sceneData.PKPCDAAHJGP_HasLiveSkillCondMusic())
					{
						ClearOnClickCallback();
						AddOnClickCallback(OpenPopupCompatibleMusic);
						IsMisMatchMusic = musicId > 0 ? !m_sceneData.ADDCCPKEFOC_IsMatchLiveSkillMusic(musicId) : false;
						m_layoutTable.StartChildrenAnimGoStop("01");
						Hidden = false;
					}
					else
					{
						if(sceneData.GPLOOJCLNBL_GetLiveSkillSwitchPatternCond() != SkillSwitchPatternCondition.Type.SeriesAttr_Scn)
						{
							if(m_sceneData.GOEFBDNFNAA_HasLiveSkillCondAttr())
							{
								IsMisMatchAttr = !m_sceneData.JEDMBJEICBB_IsLiveSkillMatchAttr(musicId, false);
								m_layoutTable.StartChildrenAnimGoStop("04");
								SetAttr(m_sceneData.EOIGNOLJGDG_GetLiveSkillMusicAttr(musicId, true));
								Hidden = true;
							}
							else
							{
								IsMisMatchMusic = false;
								IsMisMatchSeries = false;
								IsMisMatchAttr = false;
								m_layoutTable.StartChildrenAnimGoStop("02");
								Hidden = true;
							}
						}
						else
						{
							ClearOnClickCallback();
							AddOnClickCallback(OpenPopupLiveSkillDetails);
							m_layoutTable.StartChildrenAnimGoStop("03");
							Hidden = false;
						}
					}
				}
				else
				{
					IsMisMatchMusic = false;
					IsMisMatchSeries = false;
					IsMisMatchAttr = false;
					m_layoutTable.StartChildrenAnimGoStop("02");
					Hidden = true;
				}
			}
		}

		// // RVA: 0xCFB274 Offset: 0xCFB274 VA: 0xCFB274
		private void SetAttr(GameAttribute.Type attr)
		{
			m_imageAttr.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(string.Format("cmn_zok_{0:D2}", attr)));
			if(m_textAttr != null)
				m_textAttr.text = "";
		}

		// // RVA: 0xCFB41C Offset: 0xCFB41C VA: 0xCFB41C
		private void OpenPopupCompatibleMusic()
		{
			TodoLogger.LogNotImplemented("OpenPopupCompatibleMusic");
		}

		// // RVA: 0xCFBB20 Offset: 0xCFBB20 VA: 0xCFBB20
		private void OpenPopupCompatibleSeries()
		{
			TodoLogger.LogNotImplemented("OpenPopupCompatibleSeries");
		}

		// // RVA: 0xCFBEEC Offset: 0xCFBEEC VA: 0xCFBEEC
		private void OpenPopupLiveSkillDetails()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if (m_sceneData != null)
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				PopupLiveSkillRegulationSetting s = new PopupLiveSkillRegulationSetting();
				s.TitleText = bk.GetMessageByLabel("liveskillregulation_popup_title");
				s.WindowSize = SizeType.Middle;
				s.SetParent(transform);
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
				s.ViewSceneData = m_sceneData;
				s.SkillType = Type.Live;
				PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xCFC81C
					return;
				}, null, null, null);
			}
		}

		// // RVA: 0xCFC308 Offset: 0xCFC308 VA: 0xCFC308
		private void OpenPopupCenterSkillDetails()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(m_sceneData != null)
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				PopupLiveSkillRegulationSetting s = new PopupLiveSkillRegulationSetting();
				s.TitleText = bk.GetMessageByLabel("centerskillregulation_popup_title");
				s.WindowSize = SizeType.Middle;
				s.SetParent(transform);
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
				s.ViewSceneData = m_sceneData;
				s.SkillType = Type.Center;
				PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xCFC820
					return;
				}, null, null, null);
			}
		}

		// [CompilerGeneratedAttribute] // RVA: 0x72DADC Offset: 0x72DADC VA: 0x72DADC
		// // RVA: 0xCFC72C Offset: 0xCFC72C VA: 0xCFC72C
		// private bool <OpenPopupCompatibleMusic>b__22_0(PPGHMBNIAEC _) { }
	}
}
