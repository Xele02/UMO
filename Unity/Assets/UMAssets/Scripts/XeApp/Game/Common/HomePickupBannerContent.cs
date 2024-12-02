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
		private void Start()
		{
			m_buttonBanner.ClearOnClickCallback();
			m_buttonBanner.AddOnClickCallback(() =>
			{
				//0xEB0D48
				if (onClickButton != null)
					onClickButton(pictId);
			});
			SetPeriod(period);
		}

		// // RVA: 0xEAEDF4 Offset: 0xEAEDF4 VA: 0xEAEDF4
		public void Setup(JBCAHMMCOKK view, LoadBannerTextureDelegate loadBannerTexture)
		{
			string text = "";
			SetPeriod("");
			if(view.NMDLMMOGDML)
			{
				text = view.DMILLPJMDJI;
			}
			if((int)view.NNHHNFFLCFO < 28 && (1 << ((int)view.NNHHNFFLCFO) & 0x81c0060U) != 0)
			{
				SetGachaTexture(view.EAHPLCJMPHD, loadBannerTexture, () =>
				{
					//0xEB0DB8
					SetPeriod(text);
				});
			}
			else
			{
				SetTexture(view.EAHPLCJMPHD, loadBannerTexture, () =>
				{
					//0xEB0DE8
					SetPeriod(text);
				});
			}
		}

		// // RVA: 0xEAD804 Offset: 0xEAD804 VA: 0xEAD804
		public void SetFont(XeSys.FontInfo font)
		{
			font.Apply(m_textPeriod);
		}

		// // RVA: 0xEB073C Offset: 0xEB073C VA: 0xEB073C
		public void SetTexture(int pictId, LoadBannerTextureDelegate loadBannerTexture, Action callback)
		{
			this.pictId = pictId;
			m_imageBanner.enabled = false;
			loadBannerTexture(pictId, (IiconTexture iconTex) =>
			{
				//0xEB0E18
				if (this.pictId != pictId)
					return;
				m_imageBanner.enabled = true;
				iconTex.Set(m_imageBanner);
				if (callback != null)
					callback();
			});
		}

		// // RVA: 0xEB05CC Offset: 0xEB05CC VA: 0xEB05CC
		public void SetGachaTexture(int pictId, LoadBannerTextureDelegate loadBannerTexture, Action callback)
		{
			this.pictId = pictId;
			m_imageBanner.enabled = false;
			loadBannerTexture(pictId, (IiconTexture iconTex) =>
			{
				//0xEB0F80
				if (pictId != this.pictId)
					return;
				m_imageBanner.enabled = true;
				(iconTex as HomeBannerTexture).SetForGachaPickupIcon(m_imageBanner);
				if (callback != null)
					callback();
			});
		}

		// // RVA: 0xEB04DC Offset: 0xEB04DC VA: 0xEB04DC
		public void SetPeriod(string period)
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
