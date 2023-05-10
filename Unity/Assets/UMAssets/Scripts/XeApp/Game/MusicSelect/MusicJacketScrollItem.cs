using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;
using System;
using XeApp.Game.Menu;
using XeApp.Game.Common.View;

namespace XeApp.Game.MusicSelect
{
	[RequireComponent(typeof(CanvasGroup))] // RVA: 0x639854 Offset: 0x639854 VA: 0x639854
	public class MusicJacketScrollItem : SwapScrollListContent
	{
		[SerializeField]
		private CanvasGroup m_canvasGroup; // 0x20
		//[HeaderAttribute] // RVA: 0x665674 Offset: 0x665674 VA: 0x665674
		[SerializeField]
		private Text m_textTitle; // 0x24
		[SerializeField]
		private Common.ScrollText m_scrollTextTitle; // 0x28
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6656CC Offset: 0x6656CC VA: 0x6656CC
		private RawImageEx m_imageJacket; // 0x2C
		//[HeaderAttribute] // RVA: 0x665714 Offset: 0x665714 VA: 0x665714
		[SerializeField]
		private Image m_imageSelect; // 0x30
		[SerializeField]
		private SpriteAnime m_animeSelect; // 0x34
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x665774 Offset: 0x665774 VA: 0x665774
		private Image m_imageAttr; // 0x38
		[SerializeField]
		private Sprite[] m_tableAttr; // 0x3C
		//[HeaderAttribute] // RVA: 0x6657D4 Offset: 0x6657D4 VA: 0x6657D4
		[SerializeField]
		private Image m_imageLock; // 0x40
		//[HeaderAttribute] // RVA: 0x665824 Offset: 0x665824 VA: 0x665824
		[SerializeField]
		private UGUIButton m_buttonJacket; // 0x44
		//[HeaderAttribute] // RVA: 0x665880 Offset: 0x665880 VA: 0x665880
		[SerializeField]
		private Image m_imageBookMark; // 0x48
		private int m_index = -1; // 0x4C

		public Action<int> OnClickButtonListener { get; set; } // 0x50
		private MusicJacketTextureCache jacketTexCache { get { return GameManager.Instance.MusicJacketTextureCache; } } //0xC9AF60

		//// RVA: 0xC9AFFC Offset: 0xC9AFFC VA: 0xC9AFFC
		private void Awake()
		{
			m_buttonJacket.AddOnClickCallback(() => {
				//0xC9B604
				if(OnClickButtonListener != null)
					OnClickButtonListener(m_index);
			});
		}

		//// RVA: 0xC9B0A4 Offset: 0xC9B0A4 VA: 0xC9B0A4
		public void SetVisible(bool isVisible)
		{
			m_canvasGroup.alpha = isVisible ? 1.0f : 0.0f;
		}

		//// RVA: 0xC9B0F0 Offset: 0xC9B0F0 VA: 0xC9B0F0
		public void ResetIndex()
		{
			m_index = -1;
		}

		//// RVA: 0xC9B0FC Offset: 0xC9B0FC VA: 0xC9B0FC
		public void SetSelect(bool select)
		{
			m_scrollTextTitle.ResetScroll();
			if (select)
			{
				m_scrollTextTitle.SetCopyText();
				m_scrollTextTitle.StartScroll();
			}
			else
			{
				m_scrollTextTitle.StopScroll();
			}
			m_imageSelect.enabled = select;
			m_animeSelect.enabled = select;
		}

		//// RVA: 0xC9B1C8 Offset: 0xC9B1C8 VA: 0xC9B1C8
		public void SetAttr(int attr)
		{
			if(attr == 0)
			{
				m_imageAttr.enabled = false;
			}
			else
			{
				m_imageAttr.enabled = true;
				m_imageAttr.sprite = m_tableAttr[attr - 1];
			}
		}

		//// RVA: 0xC9B278 Offset: 0xC9B278 VA: 0xC9B278
		public void SetOpen(bool isOpen)
		{
			if(!isOpen)
			{
				m_imageLock.enabled = true;
				m_buttonJacket.Dark = true;
			}
			else
			{
				m_imageLock.enabled = false;
				m_buttonJacket.Dark = false;
			}
		}

		//// RVA: 0xC9B308 Offset: 0xC9B308 VA: 0xC9B308
		public void SetInputOff(bool inputOff)
		{
			m_buttonJacket.IsInputOff = inputOff;
		}

		//// RVA: 0xC9B33C Offset: 0xC9B33C VA: 0xC9B33C
		public void SetUpdateContent(int index, bool select, VerticalMusicDataList.MusicListData musicData, bool isEvent)
		{
			if (m_index == index)
				return;
			m_index = index;
			m_imageJacket.enabled = false;
			m_imageJacket.enabled = false;
			m_imageSelect.enabled = false;
			m_imageAttr.enabled = false;
			m_imageBookMark.enabled = false;
			jacketTexCache.Load(musicData.ViewMusic.JNCPEGJGHOG_JacketId, (IiconTexture image) =>
			{
				//0xC9B674
				if (m_index != index)
					return;
				m_imageJacket.enabled = true;
				image.Set(m_imageJacket);
				m_textTitle.enabled = true;
				m_textTitle.text = musicData.MusicName;
				if(!isEvent)
				{
					m_imageBookMark.enabled = ViewBookMarkMusicData.KNKGEALPDGF(musicData.ViewMusic.DLAEJOBELBH_MusicId);
				}
				SetSelect(select);
				SetAttr(musicData.ViewMusic.FKDCCLPGKDK_JacketAttr);
				SetOpen(musicData.IsOpen);
			});
		}
	}
}
