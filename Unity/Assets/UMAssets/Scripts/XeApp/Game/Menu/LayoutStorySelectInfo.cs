using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Collections;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutStorySelectInfo : LayoutUGUIScriptBase
	{
		public enum eButtonLabel
		{
			None = 0,
			Close = 1,
			Play = 2,
			Live = 3,
			DownLoad = 4,
		}

		public enum eTblType
		{
			None = 0,
			Music = 1,
			Diva = 2,
			Basara = 3,
		}
 
		public enum eButtonTblType
		{
			Dummy = 0,
			GoLive = 1,
			GoPlay = 2,
			Close = 3,
			GoDownLoad = 4,
			None = 5,
		}

		private enum eLabel
		{
			DownLoad = 0,
			Play = 1,
		}

		[SerializeField]
		private ActionButton m_closeButton; // 0x14
		[SerializeField]
		private ActionButton m_playorDLButton; // 0x18
		[SerializeField]
		private ActionButton m_liveButton; // 0x1C
		[SerializeField]
		private Text m_desc; // 0x20
		[SerializeField]
		private Text m_musicName; // 0x24
		[SerializeField]
		private Text m_storyOne; // 0x28
		[SerializeField]
		private Text m_storyMain; // 0x2C
		[SerializeField]
		private RawImageEx m_bgImage; // 0x30
		[SerializeField]
		private RawImageEx m_seriesImage; // 0x34
		[SerializeField]
		private RawImageEx m_divaImage; // 0x38
		[SerializeField]
		private RawImageEx m_divaNameImage; // 0x3C
		[SerializeField]
		private RawImageEx m_buttonLabel; // 0x40
		private AbsoluteLayout m_root; // 0x48
		private AbsoluteLayout m_titleTbl; // 0x4C
		private AbsoluteLayout m_buttonTbl; // 0x50
		private AbsoluteLayout m_baseTbl; // 0x54
		private AbsoluteLayout m_descTitleTbl; // 0x58
		private AbsoluteLayout m_descTitleEfTbl; // 0x5C
		private AbsoluteLayout m_openAnim; // 0x60
		private bool m_isLoadingBgImage; // 0x64
		private bool m_isLoadingSeriesImage; // 0x65
		private bool m_isLoadingDivaImage; // 0x66
		private Action<int> m_callbackButton; // 0x68
		private TexUVListManager m_uvManager; // 0x6C
		private LIEJFHMGNIA m_viewData; // 0x70
		private List<IEnumerator> m_animList = new List<IEnumerator>(4); // 0x74
		private string m_descHeaderMess; // 0x78
		private LayoutUGUIHitOnly m_hitOnlyPlayOrDL; // 0x7C
		private LayoutUGUIHitOnly m_hitOnlyClose; // 0x80
		private LayoutUGUIHitOnly m_hitOnlyLive; // 0x84
		private bool m_isRequireStoryDescription; // 0x88
		private readonly string[] m_buttonLabelTbl = new string[2]
		{
			"sel_story_btn_v_fnt_dl", "sel_story_btn_v_fnt_play"
		}; // 0x8C

		public bool IsOpen { get; private set; } // 0x44

		//// RVA: 0x153359C Offset: 0x153359C VA: 0x153359C
		public void SetStatus(LIEJFHMGNIA stageData, Action<int> callbackButton)
		{
			SetButtonPlayOrDownLoad(!stageData.IFNPBIJEPBO_IsDlded);
			m_viewData = stageData;
			m_isRequireStoryDescription = false;
			m_callbackButton = callbackButton;
			Clear();
			SwitchButtonType(stageData);
			SetDiva(stageData);
			SetMusic(stageData);
		}

		//// RVA: 0x1533E90 Offset: 0x1533E90 VA: 0x1533E90
		public void ChangeButton()
		{
			SetButtonPlayOrDownLoad(false);
			SwitchButtonType(m_viewData);
		}

		//// RVA: 0x15338D0 Offset: 0x15338D0 VA: 0x15338D0
		private void SetDiva(LIEJFHMGNIA stageData)
		{
			if(stageData.MMEGDFPNONJ_HasDivaId)
			{
				if (stageData.AHHJLDLAPAN_DivaId == 9)
					SwitchTbl(eTblType.Basara);
				else
					SwitchTbl(eTblType.Diva);
				SetDivaImage(stageData.AHHJLDLAPAN_DivaId);
				SetDivaName(stageData.AHHJLDLAPAN_DivaId);
				FFHPBEPOMAK_DivaInfo f = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas.Find((FFHPBEPOMAK_DivaInfo _) =>
				{
					//0x15367E4
					return stageData.AHHJLDLAPAN_DivaId == _.AHHJLDLAPAN_DivaId;
				});
				if(f != null)
				{
					SetSeriesLogoImage((int)SeriesAttr.ConvertFromLogoId((SeriesLogoId.Type) f.AIHCEGFANAM_Serie));
					MessageBank bk = MessageManager.Instance.GetBank("menu");
					SetStoryOne(bk.GetMessageByLabel(string.Format("story_diva_tilte_{0:d2}", stageData.AHHJLDLAPAN_DivaId)));
					SetStoryMain(bk.GetMessageByLabel(string.Format("story_diva_desc_{0:d2}", stageData.AHHJLDLAPAN_DivaId)));
					SetText(stageData.FHPHCFEEBMP);
				}
			}
		}

		//// RVA: 0x1533D00 Offset: 0x1533D00 VA: 0x1533D00
		private void SetMusic(LIEJFHMGNIA stageData)
		{
			if (stageData.MMEGDFPNONJ_HasDivaId)
				return;
			m_isRequireStoryDescription = m_viewData.MBJOBPJKGBO;
			SwitchTbl(eTblType.Music);
			SetBgImage(stageData.JJPKBHLKILC_BgId);
			SetMusicName(stageData.NEDBBJDAFBH_MusicName);
			SetSeriesLogoImage(stageData.EMIKBGHIOMN_SerieLogoId);
			SetStoryOne(GetStoryTitle(stageData.DLAEJOBELBH_MusicId));
			SetStoryMain(stageData.OLLHCHDEHHM_StoryDesc);
			if (!stageData.HHBJAEOIGIH && !m_isRequireStoryDescription)
				return;
			SetText(stageData.FHPHCFEEBMP);
		}

		//// RVA: 0x1533754 Offset: 0x1533754 VA: 0x1533754
		public void Clear()
		{
			DeleteImage(ref m_bgImage);
			DeleteImage(ref m_divaImage);
			SetText("");
			SetStoryOne("");
			SetStoryMain("");
		}

		//// RVA: 0x1534A14 Offset: 0x1534A14 VA: 0x1534A14
		private string GetStoryTitle(int musicId)
		{
			EONOEHOKBEB_Music m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[musicId - 1];
			return Database.Instance.musicText.Get(m.KNMGEEFGDNI_Nam).storyTitle;
		}

		//// RVA: 0x1534BAC Offset: 0x1534BAC VA: 0x1534BAC
		private void DeleteImage(ref RawImageEx image)
		{
			if(image != null)
			{
				image.material = null;
				image.MaterialMul = null;
				image.MaterialAdd = null;
				image.texture = null;
				image.alphaTexture = null;
			}
		}

		//// RVA: 0x1534CFC Offset: 0x1534CFC VA: 0x1534CFC
		public void ButtonHitOnlyEnable(bool enable)
		{
			if (m_hitOnlyPlayOrDL != null)
				m_hitOnlyPlayOrDL.enabled = enable;
			if (m_hitOnlyClose != null)
				m_hitOnlyClose.enabled = enable;
			if (m_hitOnlyLive != null)
				m_hitOnlyLive.enabled = enable;
		}

		//// RVA: 0x1533EBC Offset: 0x1533EBC VA: 0x1533EBC
		public void SwitchTbl(eTblType tblType)
		{
			if(tblType == eTblType.Music)
			{
				if(m_titleTbl != null)
					m_titleTbl.StartChildrenAnimGoStop("01", "01");
				if (m_baseTbl != null)
					m_baseTbl.StartChildrenAnimGoStop("01", "01");
				if (m_descTitleTbl != null)
					m_descTitleTbl.StartChildrenAnimGoStop("01", "01");
				if(m_descTitleEfTbl != null)
					m_descTitleEfTbl.StartChildrenAnimGoStop("01", "01");
			}
			else if(tblType == eTblType.Diva)
			{
				if (m_titleTbl != null)
					m_titleTbl.StartChildrenAnimGoStop("02", "02");
				if (m_baseTbl != null)
					m_baseTbl.StartChildrenAnimGoStop("02", "02");
				if (m_descTitleTbl != null)
					m_descTitleTbl.StartChildrenAnimGoStop("02", "02");
				if (m_descTitleEfTbl != null)
					m_descTitleEfTbl.StartChildrenAnimGoStop("02", "02");
			}
			else if (tblType == eTblType.Basara)
			{
				if (m_titleTbl != null)
					m_titleTbl.StartChildrenAnimGoStop("02", "02");
				if (m_baseTbl != null)
					m_baseTbl.StartChildrenAnimGoStop("02", "02");
				if (m_descTitleTbl != null)
					m_descTitleTbl.StartChildrenAnimGoStop("03", "03");
				if (m_descTitleEfTbl != null)
					m_descTitleEfTbl.StartChildrenAnimGoStop("03", "03");
			}
		}

		//// RVA: 0x15337E0 Offset: 0x15337E0 VA: 0x15337E0
		public void SwitchButtonType(LIEJFHMGNIA stageData)
		{
			if(!stageData.BCGLDMKODLC)
			{
				if(stageData.HHBJAEOIGIH)
				{
					SwitchButtonType(eButtonTblType.GoLive);
					return;
				}
				if(stageData.MMEGDFPNONJ_HasDivaId || stageData.IFNPBIJEPBO_IsDlded)
				{
					if (stageData.MMEGDFPNONJ_HasDivaId)
						SwitchButtonType(eButtonTblType.GoPlay);
					else
						SwitchButtonType(eButtonTblType.Close);
					return;
				}
			}
			else
			{
				SwitchButtonType(eButtonTblType.Close);
				if (stageData.MMEGDFPNONJ_HasDivaId)
					return;
				if (stageData.IFNPBIJEPBO_IsDlded)
					return;
			}
			SwitchButtonType(eButtonTblType.GoDownLoad);
		}

		//// RVA: 0x1534E90 Offset: 0x1534E90 VA: 0x1534E90
		public void SwitchButtonType(eButtonTblType type)
		{
			if(m_buttonTbl != null)
			{
				string t = ((int)type).ToString("D2");
				m_buttonTbl.StartChildrenAnimGoStop(t, t);
			}
		}

		//// RVA: 0x15346EC Offset: 0x15346EC VA: 0x15346EC
		public void SetText(string text)
		{
			if(m_desc != null)
			{
				if(!string.IsNullOrEmpty(text))
				{
					text = string.Format("{0}\n{1}", m_descHeaderMess, text);
				}
				m_desc.text = text;
			}
		}

		//// RVA: 0x1534540 Offset: 0x1534540 VA: 0x1534540
		public void SetStoryOne(string text)
		{
			if (m_storyOne != null)
				m_storyOne.text = text;
		}

		//// RVA: 0x1534604 Offset: 0x1534604 VA: 0x1534604
		public void SetStoryMain(string text)
		{
			if(m_storyMain != null)
			{
				m_storyMain.text = text;
				m_storyMain.alignment = TextAnchor.UpperCenter;
			}
		}

		//// RVA: 0x1534950 Offset: 0x1534950 VA: 0x1534950
		public void SetMusicName(string text)
		{
			if(m_musicName != null)
			{
				m_musicName.text = text;
			}
		}

		//// RVA: 0x15347E8 Offset: 0x15347E8 VA: 0x15347E8
		public void SetBgImage(int bgId)
		{
			m_isLoadingBgImage = false;
			if(m_bgImage != null)
			{
				m_isLoadingBgImage = true;
				GameManager.Instance.storyImageCache.LoadImage(bgId, (IiconTexture texture) =>
				{
					//0x15362A4
					if(texture != null)
					{
						texture.Set(m_bgImage);
					}
					m_isLoadingBgImage = false;
				});
			}
		}

		//// RVA: 0x15343D8 Offset: 0x15343D8 VA: 0x15343D8
		public void SetSeriesLogoImage(int seriesId)
		{
			m_isLoadingSeriesImage = false;
			if(m_seriesImage != null)
			{
				m_isLoadingSeriesImage = true;
				GameManager.Instance.MenuResidentTextureCache.LoadLogo(seriesId, (IiconTexture texture) =>
				{
					//0x1536384
					if(texture != null)
					{
						texture.Set(m_seriesImage);
					}
					m_isLoadingSeriesImage = false;
				});
			}
		}

		//// RVA: 0x1534268 Offset: 0x1534268 VA: 0x1534268
		public void SetDivaName(int divaId)
		{
			if(m_divaNameImage != null)
			{
				m_divaNameImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(string.Format("sel_story_divaname_{0:d2}", divaId)));
			}
		}

		//// RVA: 0x15340F0 Offset: 0x15340F0 VA: 0x15340F0
		public void SetDivaImage(int divaId)
		{
			m_isLoadingDivaImage = false;
			if(m_divaImage != null)
			{
				m_isLoadingDivaImage = true;
				GameManager.Instance.DivaIconCache.LoadPortraitIcon(divaId, 1, 0, (IiconTexture texture) =>
				{
					//0x1536464
					if (texture != null)
						texture.Set(m_divaImage);
					m_isLoadingDivaImage = false;
				});
			}
		}

		//// RVA: 0x1534F48 Offset: 0x1534F48 VA: 0x1534F48
		public bool IsReady()
		{
			return !m_isLoadingBgImage && !m_isLoadingSeriesImage && !m_isLoadingDivaImage;
		}

		// RVA: 0x1534F7C Offset: 0x1534F7C VA: 0x1534F7C
		public void Reset()
		{
			return;
		}

		// RVA: 0x1534F80 Offset: 0x1534F80 VA: 0x1534F80
		public void Update()
		{
			for(int i = 0; i < m_animList.Count; i++)
			{
				if(m_animList[i] != null)
				{
					if (!m_animList[i].MoveNext())
						m_animList[i] = null;
				}
			}
		}

		//// RVA: 0x1535164 Offset: 0x1535164 VA: 0x1535164
		//public void Show() { }

		//// RVA: 0x1535270 Offset: 0x1535270 VA: 0x1535270
		public void In()
		{
			if (m_root == null || IsOpen)
				return;
			IsOpen = true;
			ButtonHitOnlyEnable(false);
			m_root.StartChildrenAnimGoStop("go_in", "st_in");
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_000);
			m_animList.Clear();
			m_animList.Add(WaitAnimIn());
			m_openAnim.StartChildrenAnimGoStop("st_wait", "st_wait");
			if(!m_viewData.HHBJAEOIGIH)
			{
				m_openAnim.StartChildrenAnimGoStop("st_stop", "st_stop");
			}
			SwitchButtonType(eButtonTblType.None);
		}

		//// RVA: 0x1535508 Offset: 0x1535508 VA: 0x1535508
		//public void Hide() { }

		//// RVA: 0x15355B4 Offset: 0x15355B4 VA: 0x15355B4
		public void Out()
		{
			if (m_root == null || !IsOpen)
				return;
			IsOpen = false;
			ButtonHitOnlyEnable(false);
			m_root.StartChildrenAnimGoStop("go_out", "st_out");
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_001);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7292CC Offset: 0x7292CC VA: 0x7292CC
		//// RVA: 0x153547C Offset: 0x153547C VA: 0x153547C
		private IEnumerator WaitAnimIn()
		{
			//0x1536834
			while (m_root.IsPlayingChildren())
				yield return null;
			if(m_isRequireStoryDescription)
			{
				m_openAnim.StartChildrenAnimGoStop("go_act", "st_act");
				SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_STORY_003);
				while (m_openAnim.IsPlayingChildren())
					yield return null;
			}
			//LAB_015369bc
			ButtonHitOnlyEnable(true);
			SwitchButtonType(m_viewData);
		}

		//// RVA: 0x15356D8 Offset: 0x15356D8 VA: 0x15356D8
		public bool IsShow()
		{
			if (m_root != null && m_root.IsPlayingChildren())
				return true;
			return IsOpen;
		}

		//// RVA: 0x1535718 Offset: 0x1535718 VA: 0x1535718
		//public bool IsPlayingRootAnim() { }

		//// RVA: 0x1535730 Offset: 0x1535730 VA: 0x1535730
		public bool IsPlayingInAnim()
		{
			if (m_root == null)
				return false;
			return m_root.IsPlayingChildren() || m_openAnim.IsPlayingChildren();
		}

		//// RVA: 0x153579C Offset: 0x153579C VA: 0x153579C
		public void Close()
		{
			if (m_callbackButton != null)
				m_callbackButton(1);
			Out();
		}

		//// RVA: 0x1533618 Offset: 0x1533618 VA: 0x1533618
		private void SetButtonPlayOrDownLoad(bool isDownLoad)
		{
			if(m_playorDLButton != null)
			{
				m_playorDLButton.ClearOnClickCallback();
				if (isDownLoad)
				{
					m_playorDLButton.AddOnClickCallback(() =>
					{
						//0x1536544
						if (m_callbackButton != null)
							m_callbackButton(4);
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
					});
				}
				else
				{
					m_playorDLButton.AddOnClickCallback(() =>
					{
						//0x1536600
						if (m_callbackButton != null)
							m_callbackButton(2);
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
						Out();
					});
				}
				SetButtonLabel(m_buttonLabel, !isDownLoad ? eLabel.Play : eLabel.DownLoad);
			}
		}

		//// RVA: 0x1535814 Offset: 0x1535814 VA: 0x1535814
		private void SetButtonLabel(RawImageEx image, eLabel label)
		{
			if((int)label > -1 && (int)label < m_buttonLabelTbl.Length)
			{
				if(image != null)
				{
					image.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(m_buttonLabelTbl[(int)label]));
				}
			}
		}

		// RVA: 0x15359A4 Offset: 0x15359A4 VA: 0x15359A4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvManager = uvMan;
			m_root = layout.Root[0] as AbsoluteLayout;
			m_titleTbl = layout.FindViewByExId("sw_sel_story_frm_inout_anim_swtbl_sel_story_title") as AbsoluteLayout;
			m_descTitleTbl = layout.FindViewByExId("sw_sel_story_frm_free_anim_swtbl_sel_story_frm_title") as AbsoluteLayout;
			m_descTitleEfTbl = layout.FindViewByExId("sw_sel_story_frm_free_anim_swtbl_sel_story_frm_title_ef") as AbsoluteLayout;
			m_buttonTbl = layout.FindViewByExId("sw_sel_story_frm_inout_anim_swtbl_sel_story_btn") as AbsoluteLayout;
			m_baseTbl = layout.FindViewByExId("sw_sel_story_frm_inout_anim_swtbl_sel_story_base") as AbsoluteLayout;
			m_openAnim = layout.FindViewByExId("sw_sel_story_frm_inout_anim_sw_sel_story_frm_free_anim") as AbsoluteLayout;
			m_root.StartChildrenAnimGoStop("st_wait");
			m_descHeaderMess = MessageManager.Instance.GetMessage("menu", "story_unlock_01");
			SetText("");
			SetStoryOne("");
			SetStoryMain("");
			if(m_closeButton != null)
			{
				m_hitOnlyClose = m_closeButton.GetComponentInChildren<LayoutUGUIHitOnly>(true);
				m_closeButton.ClearOnClickCallback();
				m_closeButton.AddOnClickCallback(() =>
				{
					//0x15366C4
					Close();
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				});
			}
			if(m_playorDLButton != null)
			{
				m_hitOnlyPlayOrDL = m_playorDLButton.GetComponentInChildren<LayoutUGUIHitOnly>(true);
				SetButtonPlayOrDownLoad(false);
			}
			if(m_liveButton != null)
			{
				m_hitOnlyLive = m_liveButton.GetComponentInChildren<LayoutUGUIHitOnly>(true);
				m_liveButton.ClearOnClickCallback();
				m_liveButton.AddOnClickCallback(() =>
				{
					//0x1536720
					if (m_callbackButton != null)
						m_callbackButton(3);
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
					Out();
				});
			}
			if (m_bgImage != null)
				m_bgImage.raycastTarget = false;
			Loaded();
			return true;
		}
	}
}
