using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

namespace XeApp.Game.Menu
{
	public class GakuyaCostumeListContent : SwapScrollListContent
	{
		public readonly int MAX_LV = 6; // 0x20
		[SerializeField]
		private UGUIButton m_button; // 0x24
		[SerializeField]
		private Image m_backNormal; // 0x28
		[SerializeField]
		private Image m_backDressing; // 0x2C
		[SerializeField]
		private RawImage m_imageCostume; // 0x30
		[SerializeField]
		private List<Image> m_lvStars; // 0x34
		[SerializeField]
		private List<Image> m_lvStarBases; // 0x38
		[SerializeField]
		private Text m_textName; // 0x3C
		[SerializeField]
		private Image m_checkIcon; // 0x40
		[SerializeField]
		private Image m_newIcon; // 0x44
		[SerializeField]
		private Image m_tryingFrame; // 0x48
		[SerializeField]
		private Image m_colorChangeIcon; // 0x4C
		[SerializeField]
		private Image m_lockIcon; // 0x50
		[SerializeField]
		private ColorGroup m_contentColorGroup; // 0x54
		[SerializeField]
		private Color m_colorNormal; // 0x58
		[SerializeField]
		private Color m_colorLock; // 0x68
		public Action<int> OnClickCallback; // 0x78
		private GakuyaCostumeListWindow m_parentWindow; // 0x7C
		private GakuyaCostumeListWindow.ItemInfo m_itemInfo; // 0x80

		// RVA: 0xB6D024 Offset: 0xB6D024 VA: 0xB6D024
		private void Awake()
		{
			m_button.AddOnClickCallback(() =>
			{
				//0xB6D8BC
				if (OnClickCallback != null)
					OnClickCallback(m_itemInfo.m_index);
			});
		}

		//// RVA: 0xB6D0CC Offset: 0xB6D0CC VA: 0xB6D0CC
		public void SetParent(GakuyaCostumeListWindow parent)
		{
			m_parentWindow = parent;
		}

		// RVA: 0xB6D0D4 Offset: 0xB6D0D4 VA: 0xB6D0D4
		public void SetItem(int divaId, GakuyaCostumeListWindow.ItemInfo itemInfo)
		{
			m_itemInfo = itemInfo;
			m_textName.text = itemInfo.m_name;
			SetTexture(divaId, itemInfo);
			SetLevel(divaId, itemInfo);
			if(!itemInfo.m_isSet)
			{
				m_backNormal.enabled = true;
				m_backDressing.enabled = false;
				m_checkIcon.enabled = false;
			}
			else
			{
				m_backNormal.enabled = false;
				m_backDressing.enabled = true;
				m_checkIcon.enabled = true;
			}
			m_newIcon.enabled = itemInfo.m_isNew;
			if(!itemInfo.m_isTry)
			{
				m_tryingFrame.gameObject.SetActive(false);
				m_button.enabled = true;
			}
			else
			{
				m_tryingFrame.gameObject.SetActive(m_parentWindow.IsTaped);
				m_button.enabled = false;
			}
			m_colorChangeIcon.enabled = itemInfo.m_cosColor > 0;
			if(!itemInfo.m_isHave)
			{
				m_contentColorGroup.color = m_colorLock;
				m_lockIcon.enabled = true;
			}
			else
			{
				m_contentColorGroup.color = m_colorNormal;
				m_lockIcon.enabled = false;
			}
			m_contentColorGroup.SetMaterialDirty();
		}

		//// RVA: 0xB6D478 Offset: 0xB6D478 VA: 0xB6D478
		private void SetTexture(int divaId, GakuyaCostumeListWindow.ItemInfo itemInfo)
		{
			int costumeId = itemInfo.m_cosId;
			int costumeModelId = itemInfo.m_cosModelId;
			int costumeColor = itemInfo.m_cosColor;
			int id = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume, costumeId);
			GameManager.Instance.ItemTextureCache.Load(id, costumeColor, (IiconTexture icon) =>
			{
				//0xB6D944
				if(m_itemInfo.m_cosId == costumeId)
				{
					if(costumeModelId == m_itemInfo.m_cosModelId)
					{
						if(costumeColor == m_itemInfo.m_cosColor)
						{
							icon.Set(m_imageCostume);
						}
					}
				}
			});
		}

		//// RVA: 0xB6D668 Offset: 0xB6D668 VA: 0xB6D668
		private void SetLevel(int divaId, GakuyaCostumeListWindow.ItemInfo itemInfo)
		{
			int num = Mathf.Clamp(itemInfo.m_lv, 0, MAX_LV);
			int max = Mathf.Clamp(itemInfo.m_lvMax, 0, MAX_LV);
			for(int i = 0; i < m_lvStarBases.Count; i++)
			{
				m_lvStarBases[i].enabled = i < max;
			}
			for (int i = 0; i < m_lvStars.Count; i++)
			{
				m_lvStars[i].enabled = i < max && i < num;
			}
		}
	}
}
