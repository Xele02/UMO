using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using XeApp.Game.Common;
using mcrs;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopupUnlockStage : LayoutUGUIScriptBase
	{
		private class FontSize
		{
			public int shortFontSize; // 0x8
			public int longFontSize; // 0xC
			public int shortTextLength; // 0x10
			public int longTextLength; // 0x14
		}

		[SerializeField]
		private Text m_title; // 0x14
		[SerializeField]
		private Text m_musicName; // 0x18
		[SerializeField]
		private RawImageEx m_musicJacket; // 0x1C
		private AbsoluteLayout m_root; // 0x20
		private AbsoluteLayout m_logo; // 0x24
		private bool m_isOpen; // 0x28
		private bool m_isClosed; // 0x29
		private IEnumerator m_animation; // 0x2C
		private bool m_isLoadingMusicJacket; // 0x30
		private readonly FontSize[] m_fontSizeTbl = new FontSize[1]
		{
			new FontSize() { shortFontSize = 30, longFontSize = 20, shortTextLength = 15, longTextLength = 34 }
		}; // 0x34

		// RVA: 0x1792CC4 Offset: 0x1792CC4 VA: 0x1792CC4
		public void SetStatus(PopupUnlock.UnlockInfo info)
		{
			EEDKAACNBBG_MusicData e = new EEDKAACNBBG_MusicData();
			e.KHEKNNFCAOI(info.param.id);
			SetMusicJacket(e.JNCPEGJGHOG_JacketId);
			SetMusicName(e.NEDBBJDAFBH_MusicName);
		}

		// RVA: 0x1793094 Offset: 0x1793094 VA: 0x1793094
		public bool IsLoading()
		{
			return KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning || m_isLoadingMusicJacket;
		}

		// RVA: 0x1792DB4 Offset: 0x1792DB4 VA: 0x1792DB4
		public void SetMusicJacket(int jacketId)
		{
			m_isLoadingMusicJacket = false;
			if(m_musicJacket != null)
			{
				m_isLoadingMusicJacket = true;
				GameManager.Instance.MusicJacketTextureCache.Load(jacketId, (IiconTexture texture) =>
				{
					//0x1793BBC
					if(texture != null)
					{
						texture.Set(m_musicJacket);
					}
					m_isLoadingMusicJacket = false;
				});
			}
		}

		// RVA: 0x1792F1C Offset: 0x1792F1C VA: 0x1792F1C
		public void SetMusicName(string text)
		{
			if(m_musicName != null)
			{
				m_musicName.text = text;
				m_musicName.horizontalOverflow = HorizontalWrapMode.Wrap;
				m_musicName.verticalOverflow = VerticalWrapMode.Truncate;
				m_musicName.resizeTextForBestFit = true;
				RecalcFontSize(m_musicName, text, m_fontSizeTbl[0]);
			}
		}

		// // RVA: 0x1793140 Offset: 0x1793140 VA: 0x1793140
		private void RecalcFontSize(Text label, string text, FontSize tbl)
		{
			int s = text.Length;
			if(tbl.shortTextLength < s)
			{
				if(s < tbl.longTextLength)
				{
					label.fontSize = Mathf.FloorToInt((s - tbl.shortTextLength) * 1.0f / (tbl.longTextLength - tbl.shortTextLength) * (tbl.longFontSize - tbl.shortFontSize) + tbl.shortFontSize);
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

		// RVA: 0x1793344 Offset: 0x1793344 VA: 0x1793344
		public void SetDesc()
		{
			if(m_title != null)
			{
				m_title.text = MessageManager.Instance.GetMessage("menu", "popup_unlock_desc_001");
			}
		}

		// RVA: 0x1793478 Offset: 0x1793478 VA: 0x1793478
		public void TitleAnimPlay()
		{
			m_logo.StartAllAnimGoStop("go_in", "st_in");
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_004);
			m_animation = TitleAnimWait();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x704CE4 Offset: 0x704CE4 VA: 0x704CE4
		// // RVA: 0x1793550 Offset: 0x1793550 VA: 0x1793550
		private IEnumerator TitleAnimWait()
		{
			//0x1793CA0
			while(m_logo.IsPlayingChildren())
				yield return null;
			m_logo.StartAllAnimLoop("logo_up", "loen_up");
		}

		// RVA: 0x17935FC Offset: 0x17935FC VA: 0x17935FC
		public void Update()
		{
			if(m_animation != null)
			{
				if(!m_animation.MoveNext())
					m_animation = null;
			}
		}

		// RVA: 0x17936D8 Offset: 0x17936D8 VA: 0x17936D8
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

		// RVA: 0x1793704 Offset: 0x1793704 VA: 0x1793704
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

		// RVA: 0x1793724 Offset: 0x1793724 VA: 0x1793724
		public void Reset()
		{
			return;
		}

		// // RVA: 0x1793728 Offset: 0x1793728 VA: 0x1793728
		// private void DeleteImage(ref RawImageEx image) { }

		// RVA: 0x1793878 Offset: 0x1793878 VA: 0x1793878 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			m_logo = layout.FindViewByExId("sw_pop_story_ul_set_pop_story_ul_logo_anim") as AbsoluteLayout;
			m_root.StartAllAnimGoStop("st_wait");
			SetMusicName("");
			SetDesc();
			if(m_root != null && !m_isOpen)
			{
				m_animation = null;
				m_isOpen = true;
				m_isClosed = false;
			}
			Loaded();
			return true;
		}
	}
}
