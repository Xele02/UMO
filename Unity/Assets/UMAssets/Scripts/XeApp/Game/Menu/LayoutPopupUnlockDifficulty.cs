using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using XeApp.Game.Common.uGUI;
using XeApp.Game.Common;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutPopupUnlockDifficulty : LayoutUGUIScriptBase
	{
		private class FontSize
		{
			public int shortFontSize; // 0x8
			public int longFontSize; // 0xC
			public int shortTextLength; // 0x10
			public int longTextLength; // 0x14
		}

		[SerializeField]
		private Text m_textMusicName; // 0x14
		[SerializeField]
		private RawImageEx m_imageMusicJacket; // 0x18
		[SerializeField]
		private RawImageEx m_imageLogo; // 0x1C
		[SerializeField]
		private RawImageEx[] m_imageTitle; // 0x20
		private AbsoluteLayout m_layoutMusicAttriTbl; // 0x24
		private AbsoluteLayout m_layoutRoot; // 0x28
		private AbsoluteLayout m_layoutDifficulty; // 0x2C
		private AbsoluteLayout m_layoutDifficulty2; // 0x30
		private AbsoluteLayout m_layoutDifficulty3; // 0x34
		private AbsoluteLayout m_layoutDifficulty4; // 0x38
		private AbsoluteLayout m_layoutLineIcon1; // 0x3C
		private AbsoluteLayout m_layoutLineIcon2; // 0x40
		private AbsoluteLayout m_layoutLine6; // 0x44
		private AbsoluteLayout m_layoutTitle; // 0x48
		private bool m_isOpen; // 0x4C
		private bool m_isClosed; // 0x4D
		private IEnumerator m_animation; // 0x50
		private bool m_isLoadingMusicJacket; // 0x54
		private bool m_isLoadingLogo; // 0x55
		private Rect m_uvSkipRelease; // 0x58
		private readonly FontSize[] m_fontSizeTbl = new FontSize[2]
			{
				new FontSize() { shortFontSize = 30, longFontSize = 20, shortTextLength = 17, longTextLength = 34 },
				new FontSize() { shortFontSize = 20, longFontSize = 18, shortTextLength = 21, longTextLength = 34 }
			}; // 0x68

		//// RVA: 0x178C6A4 Offset: 0x178C6A4 VA: 0x178C6A4
		public void SetStatus(PopupUnlock.UnlockInfo info)
		{
			EEDKAACNBBG_MusicData m = new EEDKAACNBBG_MusicData();
			m.KHEKNNFCAOI(info.param.id);
			SetMusicJacket(m.JNCPEGJGHOG_JacketId);
			SetMusicName(m.NEDBBJDAFBH_MusicName, m.FKDCCLPGKDK_JacketAttr);
			SetSeriesLogo(m.EMIKBGHIOMN_SerieLogoId);
			SwitchMusicAttri((GameAttribute.Type)m.FKDCCLPGKDK_JacketAttr);
			SetDifficulty(info.param.difficultyBit, info.param.difficulty6LineBit);
			SetTitleLiveSkip(info.param);
		}

		//// RVA: 0x178D3B8 Offset: 0x178D3B8 VA: 0x178D3B8
		public bool IsLoading()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning && !m_isLoadingLogo && !m_isLoadingMusicJacket;
		}

		//// RVA: 0x178D474 Offset: 0x178D474 VA: 0x178D474
		//private string GetVocalNameLF(int id) { }

		//// RVA: 0x178C9DC Offset: 0x178C9DC VA: 0x178C9DC
		public void SetMusicName(string text, int attr = 3)
		{
			if(m_textMusicName != null)
			{
				m_textMusicName.text = RichTextUtility.MakeColorTagString(text, GameAttributeTextColor.Colors[Mathf.Clamp(attr - 1, 0, GameAttributeTextColor.Colors.Length)]);
				m_textMusicName.horizontalOverflow = HorizontalWrapMode.Wrap;
				m_textMusicName.verticalOverflow = VerticalWrapMode.Truncate;
				m_textMusicName.resizeTextForBestFit = true;
				RecalcFontSize(m_textMusicName, text, m_fontSizeTbl[0]);
			}
		}

		//// RVA: 0x178CEC0 Offset: 0x178CEC0 VA: 0x178CEC0
		private void SetDifficulty(int difficultyBit, int difficulty6LineBit)
		{
			if(difficultyBit > 0 && difficulty6LineBit > 0)
			{
				int a = 0;
				for(int i = 0; i < 5; i++)
				{
					if((difficultyBit & (1 << i)) != 0)
					{
						if(a == 0)
						{
							m_layoutDifficulty.StartChildrenAnimGoStop((i + 1).ToString("D2"));
						}
						else
						{
							m_layoutDifficulty4.StartChildrenAnimGoStop((i + 1).ToString("D2"));
						}
						a++;
					}
				}
				if(a < 2)
				{
					for(int i = 2 - a; i > 0; i--)
					{
						if(a == 0)
						{
							m_layoutDifficulty.StartChildrenAnimGoStop("09");
						}
						else
						{
							m_layoutDifficulty4.StartChildrenAnimGoStop("09");
						}
					}
				}
				m_layoutLineIcon1.StartChildrenAnimGoStop("01");
				a = 0;
				for(int i = 0; i < 5; i++)
				{
					if ((difficulty6LineBit & (1 << i)) != 0)
					{
						if (a == 0)
						{
							m_layoutDifficulty2.StartChildrenAnimGoStop((i + 1).ToString("D2"));
						}
						else
						{
							m_layoutDifficulty3.StartChildrenAnimGoStop((i + 1).ToString("D2"));
						}
						a++;
					}
				}
				if (a < 2)
				{
					for (int i = 2 - a; i > 0; i--)
					{
						if (a == 0)
						{
							m_layoutDifficulty2.StartChildrenAnimGoStop("09");
						}
						else
						{
							m_layoutDifficulty3.StartChildrenAnimGoStop("09");
						}
					}
				}
				m_layoutLineIcon2.StartChildrenAnimGoStop("02");
				m_layoutLine6.StartChildrenAnimGoStop("03");
			}
			else
			{
				if (difficultyBit == 0)
					difficultyBit = difficulty6LineBit;
				for(int i = 0; i < 5; i++)
				{
					if ((difficultyBit & (1 << i)) != 0)
					{
						int idx = i;
						if (difficulty6LineBit > 0)
							idx += 4;
						m_layoutDifficulty.StartChildrenAnimGoStop((idx + 1).ToString("D2"));
						break;
					}
				}
				m_layoutLineIcon1.StartChildrenAnimGoStop(difficulty6LineBit > 0 ? "02" : "01");
				m_layoutLine6.StartChildrenAnimGoStop("01");
			}
		}

		//// RVA: 0x178D2DC Offset: 0x178D2DC VA: 0x178D2DC
		private void SetTitleLiveSkip(PopupUnlock.UnlockParam param)
		{
			if(param.unlockType == PopupUnlock.eUnlockType.LiveSkip)
			{
				for(int i = 0; i < m_imageTitle.Length; i++)
				{
					m_imageTitle[i].uvRect = m_uvSkipRelease;
				}
			}
		}

		//// RVA: 0x178D810 Offset: 0x178D810 VA: 0x178D810
		//private int MakeDifficultyAnimeLabel(int difficulty, bool is6Line) { }

		//// RVA: 0x178D820 Offset: 0x178D820 VA: 0x178D820
		public void TitleAnimPlay()
		{
			m_layoutTitle.StartAllAnimGoStop("go_in", "st_in");
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_004);
			m_animation = TitleAnimWait();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x704744 Offset: 0x704744 VA: 0x704744
		//// RVA: 0x178D8F8 Offset: 0x178D8F8 VA: 0x178D8F8
		private IEnumerator TitleAnimWait()
		{
			//0x178E5DC
			while (m_layoutTitle.IsPlayingChildren())
				yield return null;
			m_layoutTitle.StartAllAnimLoop("logo_up", "loen_up");
		}

		//// RVA: 0x178D60C Offset: 0x178D60C VA: 0x178D60C
		private void RecalcFontSize(Text label, string text, FontSize tbl)
		{
			if(text.Length <= tbl.shortTextLength)
			{
				label.fontSize = tbl.shortFontSize;
			}
			else if(text.Length >= tbl.longTextLength)
			{
				label.fontSize = tbl.longFontSize;
			}
			else
			{
				label.fontSize = Mathf.FloorToInt((text.Length - tbl.shortTextLength) * 1.0f / (tbl.longTextLength - tbl.shortTextLength) * (tbl.longFontSize - tbl.shortFontSize) + tbl.shortFontSize);
			}
		}

		//// RVA: 0x178C874 Offset: 0x178C874 VA: 0x178C874
		public void SetMusicJacket(int jacketId)
		{
			m_isLoadingMusicJacket = false;
			if(m_imageMusicJacket != null)
			{
				m_isLoadingMusicJacket = true;
				GameManager.Instance.MusicJacketTextureCache.Load(jacketId, (IiconTexture texture) =>
				{
					//0x178E418
					if(texture != null)
					{
						texture.Set(m_imageMusicJacket);
					}
					m_isLoadingMusicJacket = false;
				});
			}
		}

		//// RVA: 0x178CC7C Offset: 0x178CC7C VA: 0x178CC7C
		public void SetSeriesLogo(int seriesId)
		{
			m_isLoadingLogo = false;
			if(m_imageLogo != null)
			{
				m_isLoadingLogo = true;
				if (seriesId == 6)
					seriesId = 10;
				GameManager.Instance.MenuResidentTextureCache.LoadLogo(seriesId, (IiconTexture texture) =>
				{
					//0x178E4F8
					if(texture != null)
					{
						texture.Set(m_imageLogo);
					}
					m_isLoadingLogo = false;
				});
			}
		}

		//// RVA: 0x178CDEC Offset: 0x178CDEC VA: 0x178CDEC
		public void SwitchMusicAttri(GameAttribute.Type type)
		{
			switch(type)
			{
				case GameAttribute.Type.Yellow:
					m_layoutMusicAttriTbl.StartAllAnimGoStop("01");
					break;
				case GameAttribute.Type.Red:
					m_layoutMusicAttriTbl.StartAllAnimGoStop("02");
					break;
				case GameAttribute.Type.Blue:
					m_layoutMusicAttriTbl.StartAllAnimGoStop("03");
					break;
				case GameAttribute.Type.All:
					m_layoutMusicAttriTbl.StartAllAnimGoStop("04");
					break;
				default:
					break;
			}
		}

		// RVA: 0x178D9A4 Offset: 0x178D9A4 VA: 0x178D9A4
		public void Update()
		{
			if(m_animation != null)
			{
				if(!m_animation.MoveNext())
				{
					m_animation = null;
				}
			}
		}

		//// RVA: 0x178DA80 Offset: 0x178DA80 VA: 0x178DA80
		public void Show()
		{
			if(m_layoutRoot != null)
			{
				if(!m_isOpen)
				{
					m_animation = null;
					m_isOpen = true;
					m_isClosed = false;
				}
			}
		}

		//// RVA: 0x178DAAC Offset: 0x178DAAC VA: 0x178DAAC
		public void Hide()
		{
			if(m_layoutRoot != null)
			{
				if(m_isOpen)
				{
					m_isOpen = false;
					m_isClosed = true;
				}
			}
		}

		// RVA: 0x178DACC Offset: 0x178DACC VA: 0x178DACC
		public void Reset()
		{
			return;
		}

		//// RVA: 0x178DAD0 Offset: 0x178DAD0 VA: 0x178DAD0
		//private void DeleteImage(ref RawImageEx image) { }

		// RVA: 0x178DC20 Offset: 0x178DC20 VA: 0x178DC20 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.Root[0] as AbsoluteLayout;
			m_layoutMusicAttriTbl = layout.FindViewByExId("sw_pop_dif_ul_swtbl_zok") as AbsoluteLayout;
			m_layoutDifficulty = layout.FindViewByExId("swtbl_diff_pos_swtbl_diff") as AbsoluteLayout;
			m_layoutDifficulty2 = layout.FindViewByExId("swtbl_diff_pos_swtbl_diff_02") as AbsoluteLayout;
			m_layoutDifficulty3 = layout.FindViewByExId("swtbl_diff_pos_swtbl_diff_03") as AbsoluteLayout;
			m_layoutDifficulty4 = layout.FindViewByExId("swtbl_diff_pos_swtbl_diff_04") as AbsoluteLayout;
			m_layoutLineIcon1 = layout.FindViewByExId("swtbl_diff_pos_swtbl_line_icon") as AbsoluteLayout;
			m_layoutLineIcon2 = layout.FindViewByExId("swtbl_diff_pos_swtbl_line_icon_02") as AbsoluteLayout;
			m_layoutLine6 = layout.FindViewByExId("sw_pop_dif_ul_swtbl_diff_pos") as AbsoluteLayout;
			m_layoutTitle = layout.FindViewByExId("sw_pop_dif_ul_pop_dif_ul_logo_anim") as AbsoluteLayout;
			m_uvSkipRelease = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("p_d_u_title2"));
			Loaded();
			return true;
		}
	}
}
