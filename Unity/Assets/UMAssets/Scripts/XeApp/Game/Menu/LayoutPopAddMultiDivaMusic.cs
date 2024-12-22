using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using XeApp.Game.Common;
using mcrs;
using XeApp.Game.Common.uGUI;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopAddMultiDivaMusic : LayoutUGUIScriptBase
	{
		private class viewPopData
		{
			public int divaNum = 2; // 0x8
			public string musicName = ""; // 0xC
			public int attr = 1; // 0x10
			public int coverId; // 0x14
			public int seriesId; // 0x18
		}

		private class FontSize
		{
			public int shortFontSize; // 0x8
			public int longFontSize; // 0xC
			public int shortTextLength; // 0x10
			public int longTextLength; // 0x14
		}

		[SerializeField]
		private Text m_musicName; // 0x14
		[SerializeField]
		private Text m_divaNumText; // 0x18
		[SerializeField]
		private RawImageEx m_musicJacket; // 0x1C
		[SerializeField]
		private RawImageEx m_Serieslogo; // 0x20
		private AbsoluteLayout m_musicAttriTbl; // 0x24
		private AbsoluteLayout m_root; // 0x28
		private AbsoluteLayout m_divaCountIcon; // 0x2C
		private AbsoluteLayout m_title; // 0x30
		private bool m_isOpen; // 0x34
		private bool m_isClosed; // 0x35
		private IEnumerator m_animation; // 0x38
		private bool m_isLoadingMusicJacket; // 0x3C
		private bool m_isLoadingLogo; // 0x3D
		private readonly FontSize[] m_fontSizeTbl = new FontSize[2]
		{
			new FontSize() { shortFontSize = 30, longFontSize = 20, shortTextLength = 17, longTextLength = 34 },
			new FontSize() { shortFontSize = 20, longFontSize = 18, shortTextLength = 21, longTextLength = 34 }
		}; // 0x40

		// RVA: 0x15DA7D4 Offset: 0x15DA7D4 VA: 0x15DA7D4
		public void SetStatus(PopupUnlock.UnlockInfo info)
		{
			EEDKAACNBBG_MusicData data = new EEDKAACNBBG_MusicData();
			EONOEHOKBEB_Music minfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[info.param.id - 1];
			data.KHEKNNFCAOI(info.param.id);
			SetMusicJacket(data.JNCPEGJGHOG_JacketId);
			SetMusicName(data.NEDBBJDAFBH_MusicName, data.FKDCCLPGKDK_JacketAttr);
			SetSeriesLogo(data.EMIKBGHIOMN_SerieLogoId);
			SwitchMusicAttri((GameAttribute.Type) data.FKDCCLPGKDK_JacketAttr);
			SetDivaNumIcon(minfo.PECMGDOMLAF_DivaMulti);
			m_divaNumText.text = GetAddMusicText(minfo.PECMGDOMLAF_DivaMulti);
		}

		// RVA: 0x15DB1F8 Offset: 0x15DB1F8 VA: 0x15DB1F8
		public bool IsLoading()
		{
			return KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning || m_isLoadingMusicJacket || m_isLoadingLogo;
		}

		// // RVA: 0x15DABE8 Offset: 0x15DABE8 VA: 0x15DABE8
		public void SetMusicName(string text, int attr = 3)
		{
			if(m_musicName != null)
			{
				m_musicName.text = RichTextUtility.MakeColorTagString(text, GameAttributeTextColor.Colors[Mathf.Clamp(attr - 1, 0, GameAttributeTextColor.Colors.Length)]);
				RecalcFontSize(m_musicName, text, m_fontSizeTbl[0]);
			}
		}

		// // RVA: 0x15DB100 Offset: 0x15DB100 VA: 0x15DB100
		private string GetAddMusicText(int divaNum)
		{
			return string.Format(MessageManager.Instance.GetMessage("menu", "add_unit_multi_dance_popup_01"), divaNum);
		}

		// RVA: 0x15DB4B8 Offset: 0x15DB4B8 VA: 0x15DB4B8
		public void TitleAnimPlay()
		{
			if(m_title != null)
			{
				m_title.StartAllAnimGoStop("go_in", "st_in");
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_004);
				m_animation = TitleAnimWait();
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7071FC Offset: 0x7071FC VA: 0x7071FC
		// // RVA: 0x15DB590 Offset: 0x15DB590 VA: 0x15DB590
		private IEnumerator TitleAnimWait()
		{
			//0x15DBF1C
			while(m_title.IsPlayingChildren())
				yield return null;
			m_title.StartAllAnimLoop("logo_up", "loen_up");
		}

		// // RVA: 0x15DB2B4 Offset: 0x15DB2B4 VA: 0x15DB2B4
		private void RecalcFontSize(Text label, string text, FontSize tbl)
		{
			int l = text.Length;
			if(tbl.shortTextLength < l)
			{
				if(l < tbl.longTextLength)
				{
					label.fontSize = Mathf.FloorToInt((l - tbl.shortTextLength) * 1.0f / (tbl.longTextLength - tbl.shortTextLength) * (tbl.longFontSize - tbl.shortFontSize) + tbl.shortFontSize);
				}
				else
				{
					label.fontSize = tbl.longFontSize;
				}
			}
			else
			{
				label.fontSize = tbl.shortFontSize;
			}
		}

		// // RVA: 0x15DAA80 Offset: 0x15DAA80 VA: 0x15DAA80
		public void SetMusicJacket(int jacketId)
		{
			m_isLoadingMusicJacket = false;
			if(m_musicJacket != null)
			{
				m_isLoadingMusicJacket = true;
				GameManager.Instance.MusicJacketTextureCache.Load(jacketId, (IiconTexture texture) =>
				{
					//0x15DBD58
					if(texture != null)
						texture.Set(m_musicJacket);
					m_isLoadingMusicJacket = false;
				});
			}
		}

		// // RVA: 0x15DAE1C Offset: 0x15DAE1C VA: 0x15DAE1C
		public void SetSeriesLogo(int seriesId)
		{
			m_isLoadingLogo = false;
			if(m_Serieslogo != null)
			{
				m_isLoadingLogo = true;
				GameManager.Instance.MenuResidentTextureCache.LoadLogo(seriesId, (IiconTexture texture) =>
				{
					//0x15DBE38
					if(texture != null)
						texture.Set(m_Serieslogo);
					m_isLoadingLogo = false;
				});
			}
		}

		// // RVA: 0x15DAF84 Offset: 0x15DAF84 VA: 0x15DAF84
		public void SwitchMusicAttri(GameAttribute.Type type)
		{
			if(m_musicAttriTbl != null)
			{
				switch(type)
				{
					case GameAttribute.Type.Yellow:
						m_musicAttriTbl.StartAllAnimGoStop("01");
						break;
					case GameAttribute.Type.Red:
						m_musicAttriTbl.StartAllAnimGoStop("02");
						break;
					case GameAttribute.Type.Blue:
						m_musicAttriTbl.StartAllAnimGoStop("03");
						break;
					case GameAttribute.Type.All:
						m_musicAttriTbl.StartAllAnimGoStop("04");
						break;
				}
			}
		}

		// // RVA: 0x15DB058 Offset: 0x15DB058 VA: 0x15DB058
		private void SetDivaNumIcon(int divaNum)
		{
			m_divaCountIcon.StartAllAnimGoStop((divaNum - 1).ToString("00"));
		}

		// RVA: 0x15DB63C Offset: 0x15DB63C VA: 0x15DB63C
		public void Update()
		{
			if(m_animation != null)
			{
				if(!m_animation.MoveNext())
					m_animation = null;
			}
		}

		// RVA: 0x15DB718 Offset: 0x15DB718 VA: 0x15DB718
		public void Show()
		{
			if(m_root != null)
			{
				if(!m_isOpen)
				{
					m_animation = null;
					m_isOpen = true;
					m_isClosed = false;
				}
			}
		}

		// RVA: 0x15DB744 Offset: 0x15DB744 VA: 0x15DB744
		public void Hide()
		{
			if(m_root != null)
			{
				if(m_isOpen)
				{
					m_isOpen = false;
					m_isClosed = true;
				}
			}
		}

		// RVA: 0x15DB764 Offset: 0x15DB764 VA: 0x15DB764
		public void Reset()
		{
			return;
		}

		// // RVA: 0x15DB768 Offset: 0x15DB768 VA: 0x15DB768
		// private void DeleteImage(ref RawImageEx image) { }

		// RVA: 0x15DB8B8 Offset: 0x15DB8B8 VA: 0x15DB8B8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			m_musicAttriTbl = layout.FindViewByExId("sw_pop_music_ul_set_swtbl_zok") as AbsoluteLayout;
			m_divaCountIcon = layout.FindViewByExId("sw_pop_music_ul_set_swtbl_unit_icon") as AbsoluteLayout;
			m_title = layout.FindViewByExId("sw_pop_music_ul_set_pop_music_ul_logo_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
