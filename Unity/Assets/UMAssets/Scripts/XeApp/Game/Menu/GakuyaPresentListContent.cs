using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class GakuyaPresentListContent : SwapScrollListContent
	{
		[SerializeField]
		private UGUIButton m_button; // 0x20
		[SerializeField]
		private RawImage m_imagePresent; // 0x24
		[SerializeField]
		private Text m_textName; // 0x28
		[SerializeField]
		private Text m_textCount; // 0x2C
		[SerializeField]
		private ColorGroup m_contentColorGroup; // 0x30
		[SerializeField]
		private Color m_colorNormal; // 0x34
		[SerializeField]
		private Color m_colorImp; // 0x44
		public Action<int> OnClickCallback; // 0x54
		private GakuyaPresentListWindow.ItemInfo m_itemInfo; // 0x58

		// RVA: 0xB73FA0 Offset: 0xB73FA0 VA: 0xB73FA0
		private void Awake()
		{
			m_button.AddOnClickCallback(() =>
			{
				//0xB74444
				if (OnClickCallback != null)
					OnClickCallback(m_itemInfo.m_index);
			});
		}

		// RVA: 0xB74048 Offset: 0xB74048 VA: 0xB74048
		public void SetItem(GakuyaPresentListWindow.ItemInfo itemInfo)
		{
			m_itemInfo = itemInfo;
			m_textName.text = itemInfo.m_presentData.OPFGFINHFCE_Name;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textCount.text = string.Format(bk.GetMessageByLabel("gakuya_gift_stock_count"), itemInfo.m_presentData.GLHBKPNFLOP_Count);
			SetTexture(itemInfo);
			if(!itemInfo.m_isEnable)
			{
				m_contentColorGroup.color = m_colorImp;
			}
			else
			{
				m_contentColorGroup.color = m_colorNormal;
			}
			m_contentColorGroup.SetMaterialDirty();
		}

		//// RVA: 0xB74284 Offset: 0xB74284 VA: 0xB74284
		private void SetTexture(GakuyaPresentListWindow.ItemInfo itemInfo)
		{
			int itemId = itemInfo.m_presentData.KIJAPOFAGPN_FullItemId;
			int index = itemInfo.m_index;
			int presentId = itemInfo.m_presentData.ADJBIEOILPJ_Id;
			GameManager.Instance.ItemTextureCache.Load(itemId, (IiconTexture icon) =>
			{
				//0xB744CC
				if(index == m_itemInfo.m_index)
				{
					if(m_itemInfo.m_presentData.ADJBIEOILPJ_Id == presentId)
					{
						if(m_itemInfo.m_presentData.KIJAPOFAGPN_FullItemId == itemId)
						{
							icon.Set(m_imagePresent);
						}
					}
				}
			});
		}
	}
}
