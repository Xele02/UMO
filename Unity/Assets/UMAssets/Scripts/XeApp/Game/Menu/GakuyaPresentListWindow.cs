using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class GakuyaPresentListWindow : MonoBehaviour
	{
		public class ItemInfo
		{
			public int m_index; // 0x8
			public bool m_isEnable; // 0xC
			public OJEGDIBEBHP m_presentData; // 0x10
		}

		[SerializeField]
		private UGUISwapScrollList m_scrollList; // 0xC
		[SerializeField]
		private Image m_imageDarkFill; // 0x10
		[SerializeField]
		private Text m_textDarkFill; // 0x14
		public Action<int> OnClickItemCallback; // 0x18
		private bool m_isSetup; // 0x1C
		private List<ItemInfo> m_itemList = new List<ItemInfo>(); // 0x20
		private bool m_itemDarkFlag; // 0x24

		public int ItemCount { get { return m_itemList.Count; } } //0xB74694

		//// RVA: 0xB7470C Offset: 0xB7470C VA: 0xB7470C
		public ItemInfo GetItem(int index)
		{
			if(index > -1 && index < ItemCount)
			{
				return m_itemList[index];
			}
			return null;
		}

		// RVA: 0xB747B0 Offset: 0xB747B0 VA: 0xB747B0
		public void Setup(GameObject content)
		{
			if(!m_isSetup)
			{
				content.name += "_00";
				m_scrollList.AddScrollObject(content.GetComponentInChildren<SwapScrollListContent>());
				GakuyaPresentListContent c = content.GetComponentInChildren<GakuyaPresentListContent>();
				c.OnClickCallback = OnClickItem;
				for(int i = 1; i < m_scrollList.RowCount; i++)
				{
					GameObject g = Instantiate(content);
					g.name = content.name.Replace("_00", i.ToString("D2"));
					m_scrollList.AddScrollObject(g.GetComponentInChildren<SwapScrollListContent>());
					GakuyaPresentListContent c2 = content.GetComponentInChildren<GakuyaPresentListContent>();
					c2.OnClickCallback = OnClickItem;
				}
				m_scrollList.SetContentEscapeMode(true);
				m_scrollList.OnUpdateItem.AddListener(OnUpdateList);
				m_scrollList.Apply();
				m_isSetup = true;
			}
		}

		//// RVA: 0xB73218 Offset: 0xB73218 VA: 0xB73218
		//public void SetScrollTop() { }

		// RVA: 0xB74C90 Offset: 0xB74C90 VA: 0xB74C90
		public void SetItems(List<OJEGDIBEBHP> presentDataList)
		{
			m_itemList.Clear();
			int i = 0;
			foreach(var k in presentDataList)
			{
				ItemInfo data = new ItemInfo();
				data.m_index = i;
				data.m_isEnable = !m_itemDarkFlag;
				data.m_presentData = k;
				m_itemList.Add(data);
				i++;
			}
			m_scrollList.SetItemCount(m_itemList.Count);
			m_scrollList.SetPosition(0, 0, 0, false);
			m_scrollList.VisibleRegionUpdate();
		}

		// RVA: 0xB74F90 Offset: 0xB74F90 VA: 0xB74F90
		public void SetDark(bool enableFlag, string text = "")
		{
			m_imageDarkFill.enabled = enableFlag;
			m_textDarkFill.enabled = enableFlag;
			m_textDarkFill.text = text;
		}

		// RVA: 0xB7501C Offset: 0xB7501C VA: 0xB7501C
		public void SetItemDark(bool enableFlag)
		{
			m_itemDarkFlag = enableFlag;
			foreach(var k in m_itemList)
			{
				k.m_isEnable = !enableFlag;
			}
			m_scrollList.VisibleRegionUpdate();
		}

		//// RVA: 0xB7519C Offset: 0xB7519C VA: 0xB7519C
		private void OnUpdateList(int index, SwapScrollListContent content)
		{
			GakuyaPresentListContent c = content as GakuyaPresentListContent;
			if(c != null)
			{
				c.SetItem(GetItem(index));
			}
		}

		//// RVA: 0xB752A8 Offset: 0xB752A8 VA: 0xB752A8
		private void OnClickItem(int index)
		{
			ItemInfo item = GetItem(index);
			Debug.Log(string.Format(JpStringLiterals.StringLiteral_16170, index, item.m_presentData.OPFGFINHFCE_Name));
			if (OnClickItemCallback != null)
				OnClickItemCallback(index);
		}
	}
}
