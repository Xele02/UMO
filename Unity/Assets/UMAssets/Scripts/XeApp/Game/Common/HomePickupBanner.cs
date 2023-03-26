using UnityEngine;
using System;
using UnityEngine.UI;
using XeApp.Game.Menu;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class HomePickupBanner : MonoBehaviour
	{
		public enum Type
		{
			Open = 0,
			Close = 1,
			Num = 2,
		}

		[Serializable]
		public class ReplaceInfo
		{
			public string name; // 0x8
			public Sprite sprite; // 0xC
		}

		public class RepeatTimer
		{
			private float m_wait; // 0x8
			private float m_time; // 0xC

			public Action OnRepeatTiming { get; set; } // 0x10

			// // RVA: 0xEAD384 Offset: 0xEAD384 VA: 0xEAD384
			// public void Update() { }

			// // RVA: 0xEADA10 Offset: 0xEADA10 VA: 0xEADA10
			// public void Init(float wait) { }
		}

		// [HeaderAttribute] // RVA: 0x68A404 Offset: 0x68A404 VA: 0x68A404
		[SerializeField]
		private ReplaceInfo[] m_tableReplace = new ReplaceInfo[2]; // 0xC
		// [HeaderAttribute] // RVA: 0x68A46C Offset: 0x68A46C VA: 0x68A46C
		[SerializeField]
		private float m_autoScrollWait = 5; // 0x10
		[SerializeField]
		private int m_sizeOpen = 580; // 0x14
		[SerializeField]
		private int m_sizeClose = 80; // 0x18
		[SerializeField]
		private float m_openAnimTime = 0.5f; // 0x1C
		[SerializeField]
		private float m_closeAnimTime = 0.5f; // 0x20
		[SerializeField]
		private AnimationCurve m_animOpenClose; // 0x24
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x68A504 Offset: 0x68A504 VA: 0x68A504
		private float m_changeTime = 0.5f; // 0x28
		// [HeaderAttribute] // RVA: 0x68A57C Offset: 0x68A57C VA: 0x68A57C
		[SerializeField]
		private float m_swipeMinDistance = 50; // 0x2C
		[SerializeField]
		private float m_swipeMaxDistance = 150; // 0x30
		// [HeaderAttribute] // RVA: 0x68A608 Offset: 0x68A608 VA: 0x68A608
		[SerializeField]
		private ButtonBase m_buttonOpenClose; // 0x34
		// [HeaderAttribute] // RVA: 0x68A67C Offset: 0x68A67C VA: 0x68A67C
		[SerializeField]
		private Image m_imageOpenClose; // 0x38
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x68A6F4 Offset: 0x68A6F4 VA: 0x68A6F4
		private UGUILoopScrollList m_scrollView; // 0x3C
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x68A73C Offset: 0x68A73C VA: 0x68A73C
		private GameObject m_scrollbar; // 0x40
		// [HeaderAttribute] // RVA: 0x68A794 Offset: 0x68A794 VA: 0x68A794
		[SerializeField]
		private Image m_imageScroll; // 0x44
		// [HeaderAttribute] // RVA: 0x68A7FC Offset: 0x68A7FC VA: 0x68A7FC
		[SerializeField]
		private HomePickupBannerContent m_objBanner; // 0x48
		// [HeaderAttribute] // RVA: 0x68A844 Offset: 0x68A844 VA: 0x68A844
		[SerializeField]
		private Transform m_rootPageNum; // 0x4C
		[SerializeField]
		private Text m_textPageNum; // 0x50
		// [HeaderAttribute] // RVA: 0x68A8BC Offset: 0x68A8BC VA: 0x68A8BC
		[SerializeField]
		private InOutAnime m_inOutAnime; // 0x54
		// [HeaderAttribute] // RVA: 0x68A904 Offset: 0x68A904 VA: 0x68A904
		[SerializeField]
		private CanvasGroup m_canvasGroup; // 0x58
		private Font m_font; // 0x5C
		private bool m_vertical; // 0x60
		private bool m_toggleOpenClose; // 0x61
		private int m_inputDisableCount; // 0x64
		private RepeatTimer m_repeatTimer = new RepeatTimer(); // 0x68
		private HomeBannerTextureCache m_bannerTexCache; // 0x6C
		// private List<JBCAHMMCOKK> m_list = new List<JBCAHMMCOKK>(); // 0x70

		public Action<int> onClickBannerButton { private get; set; } // 0x74

		// RVA: 0xEAD074 Offset: 0xEAD074 VA: 0xEAD074
		private void Start()
		{
			TodoLogger.Log(0, "Start");
		}

		// RVA: 0xEAD2C0 Offset: 0xEAD2C0 VA: 0xEAD2C0
		protected void LateUpdate()
		{
			TodoLogger.Log(0, "Late Update");
		}

		// RVA: 0xEAD3F8 Offset: 0xEAD3F8 VA: 0xEAD3F8
		public void SetFont(Font font)
		{
			m_font = font;
		}

		// // RVA: 0xEAD400 Offset: 0xEAD400 VA: 0xEAD400
		// public void Setup(List<JBCAHMMCOKK> list, HomeBannerTextureCache bannerTexCache) { }

		// // RVA: 0xEAD960 Offset: 0xEAD960 VA: 0xEAD960
		// public void StartAutoScroll() { }

		// // RVA: 0xEADA20 Offset: 0xEADA20 VA: 0xEADA20
		// public void StopAutoScroll() { }

		// // RVA: 0xEADA4C Offset: 0xEADA4C VA: 0xEADA4C
		// public int GetContentSize(bool vertical) { }

		// // RVA: 0xEADBBC Offset: 0xEADBBC VA: 0xEADBBC
		// private void InputEnable() { }

		// // RVA: 0xEADC7C Offset: 0xEADC7C VA: 0xEADC7C
		// private void InputDisable() { }

		// // RVA: 0xEADD3C Offset: 0xEADD3C VA: 0xEADD3C
		// private void SetPageNum(int page) { }

		// // RVA: 0xEADE44 Offset: 0xEADE44 VA: 0xEADE44
		// private void OnClickToggle() { }

		// // RVA: 0xEAD840 Offset: 0xEAD840 VA: 0xEAD840
		// private void ToggleAnimation(bool toggle, float animTime) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73D684 Offset: 0x73D684 VA: 0x73D684
		// // RVA: 0xEADF04 Offset: 0xEADF04 VA: 0xEADF04
		// private IEnumerator Co_ToggleAnimation(bool toggle, float animTime) { }

		// // RVA: 0xEADFF0 Offset: 0xEADFF0 VA: 0xEADFF0
		// private void ChangeScrollType(bool vertical) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73D6FC Offset: 0x73D6FC VA: 0x73D6FC
		// // RVA: 0xEAE560 Offset: 0xEAE560 VA: 0xEAE560
		// public IEnumerator Co_TryInstallBanner(List<JBCAHMMCOKK> list) { }

		// // RVA: 0xEAE628 Offset: 0xEAE628 VA: 0xEAE628
		// private void LoadBanner(int pictId, Action<IiconTexture> onLoaded) { }

		// // RVA: 0xEAE83C Offset: 0xEAE83C VA: 0xEAE83C
		// public void SetActive(bool active) { }

		// // RVA: 0xEAE914 Offset: 0xEAE914 VA: 0xEAE914
		// public void Enter() { }

		// // RVA: 0xEAE9DC Offset: 0xEAE9DC VA: 0xEAE9DC
		// public void Enter(float animTime) { }

		// // RVA: 0xEAEAB8 Offset: 0xEAEAB8 VA: 0xEAEAB8
		// public void Leave() { }

		// // RVA: 0xEAEAEC Offset: 0xEAEAEC VA: 0xEAEAEC
		// public void Leave(float animTime) { }

		// // RVA: 0xEAEB34 Offset: 0xEAEB34 VA: 0xEAEB34
		// public bool IsPlaying() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73D774 Offset: 0x73D774 VA: 0x73D774
		// // RVA: 0xEAEC78 Offset: 0xEAEC78 VA: 0xEAEC78
		// private void <Start>b__33_0(int index, UGUILoopScrollContent content) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73D784 Offset: 0x73D784 VA: 0x73D784
		// // RVA: 0xEAF00C Offset: 0xEAF00C VA: 0xEAF00C
		// private void <Start>b__33_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73D794 Offset: 0x73D794 VA: 0x73D794
		// // RVA: 0xEAF048 Offset: 0xEAF048 VA: 0xEAF048
		// private void <Start>b__33_2(Vector2 vec) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73D7A4 Offset: 0x73D7A4 VA: 0x73D7A4
		// // RVA: 0xEAF294 Offset: 0xEAF294 VA: 0xEAF294
		// private void <Start>b__33_3() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73D7B4 Offset: 0x73D7B4 VA: 0x73D7B4
		// // RVA: 0xEAF41C Offset: 0xEAF41C VA: 0xEAF41C
		// private void <Setup>b__36_0(int pictId) { }
	}
}
