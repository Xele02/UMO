using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class GachaRateItem : GachaRateElemBase
	{
		[SerializeField]
		private RawImageEx m_attributeImage; // 0x24
		[SerializeField]
		private Text m_name; // 0x28
		[SerializeField]
		private Text m_percent; // 0x2C
		[SerializeField]
		private Text m_pickup; // 0x30
		private List<Rect> m_attributeUvRects; // 0x34

		// RVA: 0xEE560C Offset: 0xEE560C VA: 0xEE560C
		public void SetNameAutoSize(bool isAutoSize)
		{
			m_name.resizeTextForBestFit = isAutoSize;
			if(isAutoSize)
			{
				m_name.resizeTextMaxSize = m_name.fontSize;
				m_name.horizontalOverflow = HorizontalWrapMode.Wrap;
				m_name.verticalOverflow = VerticalWrapMode.Truncate;
			}
			else
			{
				m_name.horizontalOverflow = HorizontalWrapMode.Overflow;
				m_name.verticalOverflow = VerticalWrapMode.Overflow;
			}
		}

		// RVA: 0xEE5724 Offset: 0xEE5724 VA: 0xEE5724
		public void SetAttribute(GameAttribute.Type attribute)
		{
			m_attributeImage.uvRect = m_attributeUvRects[(int)attribute - 1];
		}

		// RVA: 0xEE57E4 Offset: 0xEE57E4 VA: 0xEE57E4
		public void SetName(string name)
		{
			m_name.text = name;
		}

		// RVA: 0xEE5820 Offset: 0xEE5820 VA: 0xEE5820
		public void SetPercent(string percent)
		{
			m_percent.text = percent;
		}

		// RVA: 0xEE585C Offset: 0xEE585C VA: 0xEE585C
		public void SetEnablePickup(bool pickup)
		{
			m_pickup.enabled = pickup;
		}

		// RVA: 0xEE471C Offset: 0xEE471C VA: 0xEE471C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_attributeUvRects = new List<Rect>(GameAttribute.ArrayNum);
			for(int i = 0; i < GameAttribute.ArrayNum; i++)
			{
				m_attributeUvRects.Add(LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(string.Format("cmn_zok_{0:D2}", i + 1))));
			}
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_pickup.text = bk.GetMessageByLabel("popup_gacha_rate_pickup");
			Loaded();
			return true;
		}
	}
}
