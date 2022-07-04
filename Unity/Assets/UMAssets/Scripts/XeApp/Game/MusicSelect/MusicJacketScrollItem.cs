using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.MusicSelect
{
	[RequireComponent(typeof(CanvasGroup))] // RVA: 0x639854 Offset: 0x639854 VA: 0x639854
	public class MusicJacketScrollItem : SwapScrollListContent
	{
		[SerializeField] // RVA: 0x665664 Offset: 0x665664 VA: 0x665664
		private CanvasGroup m_canvasGroup; // 0x20
		//[HeaderAttribute] // RVA: 0x665674 Offset: 0x665674 VA: 0x665674
		[SerializeField] // RVA: 0x665674 Offset: 0x665674 VA: 0x665674
		private Text m_textTitle; // 0x24
		[SerializeField] // RVA: 0x6656BC Offset: 0x6656BC VA: 0x6656BC
		private XeSys.Gfx.ScrollText m_scrollTextTitle; // 0x28
		[SerializeField] // RVA: 0x6656CC Offset: 0x6656CC VA: 0x6656CC
		//[HeaderAttribute] // RVA: 0x6656CC Offset: 0x6656CC VA: 0x6656CC
		private RawImageEx m_imageJacket; // 0x2C
		//[HeaderAttribute] // RVA: 0x665714 Offset: 0x665714 VA: 0x665714
		[SerializeField] // RVA: 0x665714 Offset: 0x665714 VA: 0x665714
		private Image m_imageSelect; // 0x30
		[SerializeField] // RVA: 0x665764 Offset: 0x665764 VA: 0x665764
		private SpriteAnime m_animeSelect; // 0x34
		[SerializeField] // RVA: 0x665774 Offset: 0x665774 VA: 0x665774
		//[HeaderAttribute] // RVA: 0x665774 Offset: 0x665774 VA: 0x665774
		private Image m_imageAttr; // 0x38
		[SerializeField] // RVA: 0x6657C4 Offset: 0x6657C4 VA: 0x6657C4
		private Sprite[] m_tableAttr; // 0x3C
		//[HeaderAttribute] // RVA: 0x6657D4 Offset: 0x6657D4 VA: 0x6657D4
		[SerializeField] // RVA: 0x6657D4 Offset: 0x6657D4 VA: 0x6657D4
		private Image m_imageLock; // 0x40
		//[HeaderAttribute] // RVA: 0x665824 Offset: 0x665824 VA: 0x665824
		[SerializeField] // RVA: 0x665824 Offset: 0x665824 VA: 0x665824
		private UGUIButton m_buttonJacket; // 0x44
		//[HeaderAttribute] // RVA: 0x665880 Offset: 0x665880 VA: 0x665880
		[SerializeField] // RVA: 0x665880 Offset: 0x665880 VA: 0x665880
		private Image m_imageBookMark; // 0x48
		//private int m_index = -1; // 0x4C

		//public Action<int> OnClickButtonListener { get; set; } // 0x50
		//private MusicJacketTextureCache jacketTexCache { get; } 0xC9AF60

		//// RVA: 0xC9AFFC Offset: 0xC9AFFC VA: 0xC9AFFC
		private void Awake()
		{
			UnityEngine.Debug.LogError("TODO !!!");
		}

		//// RVA: 0xC9B0A4 Offset: 0xC9B0A4 VA: 0xC9B0A4
		public void SetVisible(bool isVisible)
		{
			UnityEngine.Debug.LogError("TODO !!!");
		}

		//// RVA: 0xC9B0F0 Offset: 0xC9B0F0 VA: 0xC9B0F0
		//public void ResetIndex() { }

		//// RVA: 0xC9B0FC Offset: 0xC9B0FC VA: 0xC9B0FC
		//public void SetSelect(bool select) { }

		//// RVA: 0xC9B1C8 Offset: 0xC9B1C8 VA: 0xC9B1C8
		//public void SetAttr(int attr) { }

		//// RVA: 0xC9B278 Offset: 0xC9B278 VA: 0xC9B278
		//public void SetOpen(bool isOpen) { }

		//// RVA: 0xC9B308 Offset: 0xC9B308 VA: 0xC9B308
		//public void SetInputOff(bool inputOff) { }

		//// RVA: 0xC9B33C Offset: 0xC9B33C VA: 0xC9B33C
		//public void SetUpdateContent(int index, bool select, VerticalMusicDataList.MusicListData musicData, bool isEvent) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6B49A8 Offset: 0x6B49A8 VA: 0x6B49A8
		//// RVA: 0xC9B604 Offset: 0xC9B604 VA: 0xC9B604
		//private void <Awake>b__18_0() { }
	}
}
