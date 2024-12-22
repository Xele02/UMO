using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Text;
using XeSys;
using XeApp.Game.Common;
using mcrs;
using XeApp.Game.Common.uGUI;

namespace XeApp.Game.Menu
{
	public class LayoutPopAdd6LineMusic : LayoutUGUIScriptBase
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
		private Text m_descText; // 0x18
		[SerializeField]
		private RawImageEx m_musicJacket; // 0x1C
		[SerializeField]
		private RawImageEx m_Serieslogo; // 0x20
		private AbsoluteLayout m_musicAttriTbl; // 0x24
		private AbsoluteLayout m_diffRootLayout; // 0x28
		private AbsoluteLayout[] m_diffIconLayout; // 0x2C
		private AbsoluteLayout m_root; // 0x30
		private AbsoluteLayout m_title; // 0x34
		private bool m_isOpen; // 0x38
		private bool m_isClosed; // 0x39
		private IEnumerator m_animation; // 0x3C
		private bool m_isLoadingMusicJacket; // 0x40
		private bool m_isLoadingLogo; // 0x41
		private readonly FontSize[] m_fontSizeTbl = new FontSize[2]
		{
			new FontSize() { shortFontSize = 30, longFontSize = 20, shortTextLength = 17, longTextLength = 34 },
			new FontSize() { shortFontSize = 20, longFontSize = 18, shortTextLength = 21, longTextLength = 34 }
		}; // 0x44

		// RVA: 0x15D8BBC Offset: 0x15D8BBC VA: 0x15D8BBC
		public void SetStatus(PopupUnlock.UnlockInfo info)
		{
			EEDKAACNBBG_MusicData data = new EEDKAACNBBG_MusicData();
			EONOEHOKBEB_Music minfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[info.param.id - 1];
			data.KHEKNNFCAOI(info.param.id);
			SetMusicJacket(data.JNCPEGJGHOG_JacketId);
			SetMusicName(data.NEDBBJDAFBH_MusicName, data.FKDCCLPGKDK_JacketAttr);
			SetSeriesLogo(data.EMIKBGHIOMN_SerieLogoId);
			SwitchMusicAttri((GameAttribute.Type) data.FKDCCLPGKDK_JacketAttr);
			SetDifficulty(info.param.difficulty6LineBit);
			m_descText.text = MessageManager.Instance.GetMessage("menu", "popup_unlock_6line_music_text");
		}

		// RVA: 0x15D9678 Offset: 0x15D9678 VA: 0x15D9678
		public bool IsLoading()
		{
			return KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning || m_isLoadingMusicJacket || m_isLoadingLogo;
		}

		// // RVA: 0x15D9010 Offset: 0x15D9010 VA: 0x15D9010
		public void SetMusicName(string text, int attr = 3)
		{
			if(m_musicName != null)
			{
				m_musicName.text = RichTextUtility.MakeColorTagString(text, GameAttributeTextColor.Colors[Mathf.Clamp(attr - 1, 0, GameAttributeTextColor.Colors.Length)]);
				RecalcFontSize(m_musicName, text, m_fontSizeTbl[0]);
			}
		}

		// // RVA: 0x15D9480 Offset: 0x15D9480 VA: 0x15D9480
		private void SetDifficulty(int diffBit)
		{
			StringBuilder str = new StringBuilder(64);
			int j = 0;
			for(int i = 0; i < 5; i++)
			{
				if((diffBit & (1 << i)) != 0)
				{
					str.SetFormat("{0:D2}", i + 4);
					m_diffIconLayout[j].StartChildrenAnimGoStop(str.ToString());
					j++;
				}
			}
			str.SetFormat("{0:D2}", j);
			m_diffRootLayout.StartChildrenAnimGoStop(str.ToString());
		}

		// RVA: 0x15D9938 Offset: 0x15D9938 VA: 0x15D9938
		public void TitleAnimPlay()
		{
			m_title.StartAllAnimGoStop("go_in", "st_in");
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_004);
			m_animation = TitleAnimWait();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7070D4 Offset: 0x7070D4 VA: 0x7070D4
		// // RVA: 0x15D9A10 Offset: 0x15D9A10 VA: 0x15D9A10
		private IEnumerator TitleAnimWait()
		{
			//0x15DA5C4
			while(m_title.IsPlayingChildren())
				yield return null;
			m_title.StartAllAnimLoop("logo_up", "loen_up");
		}

		// // RVA: 0x15D9734 Offset: 0x15D9734 VA: 0x15D9734
		private void RecalcFontSize(Text label, string text, LayoutPopAdd6LineMusic.FontSize tbl)
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

		// // RVA: 0x15D8EA8 Offset: 0x15D8EA8 VA: 0x15D8EA8
		public void SetMusicJacket(int jacketId)
		{
			m_isLoadingMusicJacket = false;
			if(m_musicJacket != null)
			{
				m_isLoadingMusicJacket = true;
				GameManager.Instance.MusicJacketTextureCache.Load(jacketId, (IiconTexture texture) =>
				{
					//0x15DA400
					if(texture != null)
					{
						texture.Set(m_musicJacket);
					}
					m_isLoadingMusicJacket = false;
				});
			}
		}

		// // RVA: 0x15D9244 Offset: 0x15D9244 VA: 0x15D9244
		public void SetSeriesLogo(int seriesId)
		{
			m_isLoadingLogo = false;
			if(m_Serieslogo != null)
			{
				m_isLoadingLogo = true;
				GameManager.Instance.MenuResidentTextureCache.LoadLogo(seriesId, (IiconTexture texture) =>
				{
					//0x15DA4E0
					if(texture != null)
					{
						texture.Set(m_Serieslogo);
					}
					m_isLoadingLogo = false;
				});
			}
		}

		// // RVA: 0x15D93AC Offset: 0x15D93AC VA: 0x15D93AC
		public void SwitchMusicAttri(GameAttribute.Type type)
		{
			if(m_musicAttriTbl == null)
				return;
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

		// RVA: 0x15D9ABC Offset: 0x15D9ABC VA: 0x15D9ABC
		public void Update()
		{
			if(m_animation != null)
			{
				if(!m_animation.MoveNext())
					m_animation = null;
			}
		}

		// RVA: 0x15D9B98 Offset: 0x15D9B98 VA: 0x15D9B98
		public void Show()
		{
			if(m_root != null)
			{
				if(m_isOpen)
					return;
				m_animation = null;
				m_isOpen = true;
				m_isClosed = false;
			}
		}

		// RVA: 0x15D9BC4 Offset: 0x15D9BC4 VA: 0x15D9BC4
		public void Hide()
		{
			if(m_root != null && m_isOpen)
			{
				m_isOpen = false;
				m_isClosed = true;
			}
		}

		// RVA: 0x15D9BE4 Offset: 0x15D9BE4 VA: 0x15D9BE4
		public void Reset()
		{
			return;
		}

		// // RVA: 0x15D9BE8 Offset: 0x15D9BE8 VA: 0x15D9BE8
		// private void DeleteImage(ref RawImageEx image) { }

		// RVA: 0x15D9D38 Offset: 0x15D9D38 VA: 0x15D9D38 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			m_musicAttriTbl = layout.FindViewByExId("sw_pop_music_ul_set_swtbl_zok") as AbsoluteLayout;
			m_title = layout.FindViewByExId("sw_pop_music_ul_set_pop_music_ul_logo_anim") as AbsoluteLayout;
			m_diffRootLayout = layout.FindViewByExId("sw_pop_music_ul_set_swtbl_diff_pos") as AbsoluteLayout;
			m_diffIconLayout = new AbsoluteLayout[m_diffRootLayout.viewCount];
			StringBuilder str = new StringBuilder(64);
			for(int i = 0; i < m_diffIconLayout.Length; i++)
			{
				str.SetFormat("swtbl_diff_pos_swtbl_diff_{0:D2}", i + 1);
				m_diffIconLayout[i] = m_diffRootLayout.FindViewByExId(str.ToString()) as AbsoluteLayout;
			}
			Loaded();
			return true;
		}
	}
}
