using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System;
using XeApp.Game.Menu;

namespace XeApp.Game.Common
{
	public class BannerScrollViewContent : SelectScrollViewContent
	{
		public delegate void LoadBannerTextureDelegate(int pictId, Action<IiconTexture> callback);

		[SerializeField]
		//[HeaderAttribute] // RVA: 0x689580 Offset: 0x689580 VA: 0x689580
		protected RawImageEx m_imageBanner; // 0x14
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6895C8 Offset: 0x6895C8 VA: 0x6895C8
		protected ButtonBase m_buttonBanner; // 0x18
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x689610 Offset: 0x689610 VA: 0x689610
		protected GameObject m_textPeriodSwitch; // 0x1C
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x689658 Offset: 0x689658 VA: 0x689658
		protected Text m_textPeriod; // 0x20

		public int pictId { get; protected set; } // 0x24
		public string period { get; protected set; } // 0x28
		// public ButtonBase button { get; } 0xE5FDD4
		public Action<int> onClickButton { protected get; set; } // 0x2C

		// RVA: 0xE5FDEC Offset: 0xE5FDEC VA: 0xE5FDEC
		private void Start()
		{
			m_buttonBanner.ClearOnClickCallback();
			m_buttonBanner.AddOnClickCallback(() =>
			{
				//0xE6077C
				if(onClickButton != null)
					onClickButton(pictId);
			});
			SetPeriod(period);
		}

		// // RVA: 0xE600F4 Offset: 0xE600F4 VA: 0xE600F4 Slot: 10
		public virtual void SetFont(Font font)
		{
			m_textPeriod.font = font;
		}

		// // RVA: 0xE60128 Offset: 0xE60128 VA: 0xE60128 Slot: 11
		public virtual void SetTexture(int pictId, LoadBannerTextureDelegate loadBannerTexture)
		{
			this.pictId = pictId;
			m_imageBanner.enabled = false;
			loadBannerTexture(pictId, (IiconTexture iconTex) =>
			{
				//0xE607EC
				m_imageBanner.enabled = true;
				iconTex.Set(m_imageBanner);
			});
		}

		// // RVA: 0xE6068C Offset: 0xE6068C VA: 0xE6068C Slot: 12
		public virtual void SetPeriod(string period)
		{
			this.period = period;
			if(period != "")
			{
				m_textPeriod.text = period;
				m_textPeriodSwitch.SetActive(true);
			}
			else
			{
				m_textPeriodSwitch.SetActive(false);
			}
		}
	}
}
