using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeSys;

namespace XeApp.Game.Menu
{
	public class SelectValueContentControl : MonoBehaviour
	{
		[SerializeField]
		private ScrollContentControl m_ScrollContentControl; // 0xC
		private Text m_ValueText; // 0x10
		private Button m_SelectButton; // 0x14
		private List<string> m_StrList; // 0x18
		private int m_Select; // 0x1C
		private bool m_IsCheckOutsideArea; // 0x20
		private Action m_OnClickSelectStart; // 0x24

		public Action OnClickSelectStart { set { m_OnClickSelectStart = value; } } //0xA678B4

		// RVA: 0xA678BC Offset: 0xA678BC VA: 0xA678BC
		public void Awake()
		{
			return;
		}

		// RVA: 0xA678C0 Offset: 0xA678C0 VA: 0xA678C0
		public void Setup(Vector2 item_size, Vector2 area_size, List<string> str_list, int default_index)
		{
			m_StrList = str_list;
			m_Select = default_index;
			Text[] txts = GetComponentsInChildren<Text>(true);
			XeSys.FontInfo f = GameManager.Instance.GetSystemFont();
			for(int i = 0; i < txts.Length; i++)
			{
				if(txts[i].font != f.font)
				{
					txts[i].horizontalOverflow = HorizontalWrapMode.Overflow;
				}
				f.Apply(txts[i]);
			}
			Transform t = transform.Find("Value");
			t.GetComponent<RectTransform>().sizeDelta = item_size;
			m_ValueText = t.GetComponentInChildren<Text>(true);
			m_ValueText.text = m_StrList[m_Select];
			m_SelectButton = t.GetComponent<Button>();
			m_SelectButton.onClick.AddListener(OnSelectStart);
			m_ScrollContentControl.Setup(area_size, item_size, m_StrList, OnSelectItem);
			m_ScrollContentControl.Hide();
		}

		// RVA: 0xA67D20 Offset: 0xA67D20 VA: 0xA67D20
		private void OnSelectStart()
		{
			m_ScrollContentControl.Show(m_Select);
			m_SelectButton.enabled = false;
		}

		// RVA: 0xA67D78 Offset: 0xA67D78 VA: 0xA67D78
		private void OnSelectItem(int index)
		{
			m_Select = index;
			m_ValueText.text = m_StrList[index];
			HideSelectContent();
		}

		// RVA: 0xA67E34 Offset: 0xA67E34 VA: 0xA67E34
		private void HideSelectContent()
		{
			m_ScrollContentControl.Hide();
			m_SelectButton.enabled = true;
			m_IsCheckOutsideArea = false;
		}

		// RVA: 0xA67E8C Offset: 0xA67E8C VA: 0xA67E8C
		public string GetSelectItem()
		{
			return m_ValueText.text;
		}

		// RVA: 0xA67EC0 Offset: 0xA67EC0 VA: 0xA67EC0
		public void Update()
		{
			if(!m_IsCheckOutsideArea)
			{
				if(m_SelectButton != null)
				{
					if(!m_SelectButton.enabled)
						m_IsCheckOutsideArea = true;
				}
			}
			else
			{
                TouchInfo info = InputManager.Instance.GetCurrentTouchInfo(0);
                if (!info.isIllegal)
				{
					if(info.isBegan)
					{
						RectTransform rect = m_ScrollContentControl.GetComponent<RectTransform>();
						if(!RectTransformUtility.RectangleContainsScreenPoint(rect, info.nativePosition, GameManager.Instance.PopupCanvas.worldCamera))
							HideSelectContent();
					}
				}
			}
		}
	}
}
