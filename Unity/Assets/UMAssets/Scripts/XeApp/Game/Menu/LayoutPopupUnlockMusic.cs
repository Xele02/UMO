using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using XeApp.Game.Common.uGUI;
using XeApp.Game.Common;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutPopupUnlockMusic : LayoutUGUIScriptBase
	{
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
		private Text m_vocalName; // 0x18
		[SerializeField]
		private RawImageEx m_musicJacket; // 0x1C
		[SerializeField]
		private RawImageEx m_logo; // 0x20
		private AbsoluteLayout m_musicAttriTbl; // 0x24
		private AbsoluteLayout m_root; // 0x28
		private AbsoluteLayout m_stringAnim; // 0x2C
		private bool m_isOpen; // 0x30
		private bool m_isClosed; // 0x31
		private IEnumerator m_animation; // 0x34
		private bool m_isLoadingMusicJacket; // 0x38
		private bool m_isLoadingLogo; // 0x39
		private readonly FontSize[] m_fontSizeTbl = new FontSize[2]
			{
				new FontSize() { shortFontSize = 30, longFontSize = 20, shortTextLength = 15, longTextLength = 34 },
				new FontSize() { shortFontSize = 18, longFontSize = 20, shortTextLength = 21, longTextLength = 34 }
			}; // 0x3C

		//// RVA: 0x178FB50 Offset: 0x178FB50 VA: 0x178FB50
		public void SetStatus(PopupUnlock.UnlockInfo info)
		{
			EEDKAACNBBG_MusicData data = new EEDKAACNBBG_MusicData();
			data.KHEKNNFCAOI(info.param.id);
			SetMusicJacket(data.JNCPEGJGHOG_JacketId);
			SetMusicName(data.NEDBBJDAFBH_MusicName, data.FKDCCLPGKDK_JacketAttr);
			SetVocalName(GetVocalNameLF(info.param.id));
			SetSeriesLogo(data.EMIKBGHIOMN_SerieLogoId);
			SwitchMusicAttri((GameAttribute.Type)data.FKDCCLPGKDK_JacketAttr);
		}

		//// RVA: 0x17906A0 Offset: 0x17906A0 VA: 0x17906A0
		public bool IsLoading()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning && !m_isLoadingMusicJacket && !m_isLoadingLogo;
		}

		//// RVA: 0x1790268 Offset: 0x1790268 VA: 0x1790268
		public void SetVocalName(string text)
		{
			if(m_vocalName != null)
			{
				m_vocalName.alignment = TextAnchor.MiddleCenter;
				m_vocalName.text = text;
				RecalcFontSize(m_vocalName, text, m_fontSizeTbl[1]);
				if(text.IndexOf("\n") > -1)
				{
					m_vocalName.alignment = TextAnchor.MiddleCenter;
					m_vocalName.fontSize = m_fontSizeTbl[1].longFontSize;
				}
			}
		}

		//// RVA: 0x17900D0 Offset: 0x17900D0 VA: 0x17900D0
		private string GetVocalNameLF(int id)
		{
			EONOEHOKBEB_Music mData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[id - 1];
			return Database.Instance.musicText.Get(mData.KNMGEEFGDNI_Nam).vocalNameLF;
		}

		//// RVA: 0x178FE30 Offset: 0x178FE30 VA: 0x178FE30
		public void SetMusicName(string text, int attr = 3)
		{
			if(m_musicName != null)
			{
				m_musicName.text = RichTextUtility.MakeColorTagString(text, GameAttributeTextColor.Colors[(int)Mathf.Clamp(attr - 1, 0, GameAttributeTextColor.Colors.Length)]);
				m_musicName.horizontalOverflow = HorizontalWrapMode.Wrap;
				m_musicName.verticalOverflow = VerticalWrapMode.Truncate;
				m_musicName.resizeTextForBestFit = true;
				RecalcFontSize(m_musicName, text, m_fontSizeTbl[0]);
			}
		}

		//// RVA: 0x179075C Offset: 0x179075C VA: 0x179075C
		private void RecalcFontSize(Text label, string text, FontSize tbl)
		{
			int len = text.Length;
			int size = tbl.shortFontSize;
			if(tbl.shortTextLength < len)
			{
				size = tbl.longFontSize;
				if(len < tbl.longTextLength)
				{
					size = Mathf.FloorToInt((len - tbl.shortTextLength) / (tbl.longTextLength) * (tbl.longFontSize - tbl.shortFontSize) + tbl.shortFontSize);
				}
			}
			label.fontSize = size;
		}

		//// RVA: 0x1790960 Offset: 0x1790960 VA: 0x1790960
		public void StringAnimPlay()
		{
			m_stringAnim.StartAllAnimGoStop("go_in", "st_in");
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_004);
			m_animation = StringAnimWait();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x704904 Offset: 0x704904 VA: 0x704904
		//// RVA: 0x1790A38 Offset: 0x1790A38 VA: 0x1790A38
		private IEnumerator StringAnimWait()
		{
			//0x179139C
			while (m_stringAnim.IsPlayingChildren())
				yield return null;
			m_stringAnim.StartAllAnimLoop("logo_up", "loen_up");
		}

		//// RVA: 0x178FCC8 Offset: 0x178FCC8 VA: 0x178FCC8
		public void SetMusicJacket(int jacketId)
		{
			m_isLoadingMusicJacket = false;
			if(m_musicJacket != null)
			{
				m_isLoadingMusicJacket = true;
				GameManager.Instance.MusicJacketTextureCache.Load(jacketId, (IiconTexture texture) =>
				{
					//0x17911D8
					texture.Set(m_musicJacket);
					m_isLoadingMusicJacket = false;
				});
			}
		}

		//// RVA: 0x1790464 Offset: 0x1790464 VA: 0x1790464
		public void SetSeriesLogo(int seriesId)
		{
			m_isLoadingLogo = false;
			if(m_logo != null)
			{
				m_isLoadingLogo = true;
				GameManager.Instance.MenuResidentTextureCache.LoadLogo(seriesId, (IiconTexture texture) =>
				{
					//0x17912B8
					texture.Set(m_logo);
					m_isLoadingLogo = false;
				});
			}
		}

		//// RVA: 0x17905CC Offset: 0x17905CC VA: 0x17905CC
		public void SwitchMusicAttri(GameAttribute.Type type)
		{
			if (m_musicAttriTbl == null)
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
				default:
					break;
			}
		}

		// RVA: 0x1790AE4 Offset: 0x1790AE4 VA: 0x1790AE4
		public void Update()
		{
			if (m_animation != null)
			{
				if (!m_animation.MoveNext())
				{
					m_animation = null;
				}
			}
		}

		//// RVA: 0x1790BC0 Offset: 0x1790BC0 VA: 0x1790BC0
		public void Show()
		{
			if(m_root != null)
			{
				if (m_isOpen)
					return;
				m_animation = null;
				m_isOpen = true;
				m_isClosed = false;
			}
		}

		//// RVA: 0x1790BEC Offset: 0x1790BEC VA: 0x1790BEC
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

		// RVA: 0x1790C0C Offset: 0x1790C0C VA: 0x1790C0C
		public void Reset()
		{
			return;
		}

		//// RVA: 0x1790C10 Offset: 0x1790C10 VA: 0x1790C10
		//private void DeleteImage(ref RawImageEx image) { }

		// RVA: 0x1790D60 Offset: 0x1790D60 VA: 0x1790D60 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_musicAttriTbl = layout.FindViewByExId("sw_pop_music_ul_set_swtbl_zok") as AbsoluteLayout;
			m_stringAnim = layout.FindViewByExId("sw_pop_music_ul_set_pop_music_ul_logo_anim") as AbsoluteLayout;
			m_root = layout.Root[0] as AbsoluteLayout;
			m_root.StartAllAnimGoStop("st_wait");
			SetVocalName("");
			SetMusicName("", 3);
			Loaded();
			return true;
		}
	}
}
