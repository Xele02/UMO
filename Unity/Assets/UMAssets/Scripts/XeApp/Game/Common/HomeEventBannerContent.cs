using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class HomeEventBannerContent : BannerScrollViewContent
	{
		//[HeaderAttribute] // RVA: 0x689F2C Offset: 0x689F2C VA: 0x689F2C
		[SerializeField]
		protected Text m_textCampaignInfo; // 0x30
		[SerializeField]
		protected Text m_textCampaignCopy; // 0x34

		// RVA: 0xEAC10C Offset: 0xEAC10C VA: 0xEAC10C Slot: 10
		public override void SetFont(XeSys.FontInfo font)
		{
			base.SetFont(font);
			font.Apply(m_textCampaignInfo);
			font.Apply(m_textCampaignCopy);
		}

		// RVA: 0xEAAB0C Offset: 0xEAAB0C VA: 0xEAAB0C
		public void SetCampaignInfo(string text)
		{
			if(text != "")
			{
				m_textCampaignInfo.text = text;
				m_textCampaignInfo.enabled = true;
			}
			else
			{
				m_textCampaignInfo.enabled = false;
			}
		}
	}
}
