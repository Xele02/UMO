using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System;
using XeApp.Game.Menu;

namespace XeApp.Game.Common
{
	public class HomePickupBannerContent : UGUILoopScrollContent
	{
		public delegate void LoadBannerTextureDelegate(int pictId, Action<IiconTexture> callback);

		[SerializeField]
		// [HeaderAttribute] // RVA: 0x68A96C Offset: 0x68A96C VA: 0x68A96C
		private RawImageEx m_imageBanner; // 0x10
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x68A9B4 Offset: 0x68A9B4 VA: 0x68A9B4
		private ButtonBase m_buttonBanner; // 0x14
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x68A9FC Offset: 0x68A9FC VA: 0x68A9FC
		private GameObject m_textPeriodSwitch; // 0x18
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x68AA60 Offset: 0x68AA60 VA: 0x68AA60
		private Text m_textPeriod; // 0x1C

		public int pictId { get; private set; } // 0x20
		public string period { get; private set; } // 0x24
		// public ButtonBase button { get; } 0xEB03F8
		public Action<int> onClickButton { private get; set; } // 0x28

		// RVA: 0xEB0408 Offset: 0xEB0408 VA: 0xEB0408
		private void Start() { }

		// // RVA: 0xEAEDF4 Offset: 0xEAEDF4 VA: 0xEAEDF4
		// public void Setup(JBCAHMMCOKK view, HomePickupBannerContent.LoadBannerTextureDelegate loadBannerTexture) { }

		// // RVA: 0xEAD804 Offset: 0xEAD804 VA: 0xEAD804
		public void SetFont(Font font)
		{
			m_textPeriod.font = font;
		}

		// // RVA: 0xEB073C Offset: 0xEB073C VA: 0xEB073C
		// public void SetTexture(int pictId, HomePickupBannerContent.LoadBannerTextureDelegate loadBannerTexture, Action callback) { }

		// // RVA: 0xEB05CC Offset: 0xEB05CC VA: 0xEB05CC
		// public void SetGachaTexture(int pictId, HomePickupBannerContent.LoadBannerTextureDelegate loadBannerTexture, Action callback) { }

		// // RVA: 0xEB04DC Offset: 0xEB04DC VA: 0xEB04DC
		// public void SetPeriod(string period) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73D8E4 Offset: 0x73D8E4 VA: 0x73D8E4
		// // RVA: 0xEB0D48 Offset: 0xEB0D48 VA: 0xEB0D48
		// private void <Start>b__19_0() { }
	}
}
