using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class ScrollContentControl : MonoBehaviour
	{
		[SerializeField]
		private GameObject m_Content; // 0xC
		[SerializeField]
		private GameObject m_ItemObject; // 0x10
		private Vector2 m_AreaSize = Vector2.zero; // 0x14
		private Vector2 m_ItemSize = Vector2.zero; // 0x1C

		// RVA: 0xA65390 Offset: 0xA65390 VA: 0xA65390
		public void Awake()
		{
			return;
		}

		// RVA: 0xA65394 Offset: 0xA65394 VA: 0xA65394
		public void Setup(Vector2 area_size, Vector2 item_size, List<string> str_list, Action<int> onSelectItem)
		{
			if(m_ItemObject != null)
			{
				m_AreaSize = area_size;
				m_ItemSize = item_size;
				GetComponent<RectTransform>().sizeDelta = m_AreaSize;
				GetComponent<RectTransform>().anchoredPosition = new Vector2(0, m_ItemSize.y * -0.5f);
				float f = 0;
				for(int i = 0; i < str_list.Count; i++)
				{
					GameObject g = Instantiate(m_ItemObject, m_Content.transform, false);
					g.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -f);
					g.GetComponent<RectTransform>().sizeDelta = m_ItemSize;
					g.GetComponentInChildren<Text>(true).text = str_list[i];
					int index = i;
					g.GetComponent<Button>().onClick.AddListener(() =>
					{
						//0xA65C0C
						onSelectItem(index);
					});
					f += m_ItemSize.y;
				}
				m_Content.GetComponent<RectTransform>().sizeDelta = new Vector2(m_ItemSize.x, f);
				Destroy(m_ItemObject);
				m_ItemObject = null;
			}
		}

		// RVA: 0xA65960 Offset: 0xA65960 VA: 0xA65960
		public void Show(int index)
		{
			Vector2 s = m_Content.GetComponent<RectTransform>().sizeDelta;
			float f = m_ItemSize.y * index;
			if(s.y - f < m_AreaSize.y)
			{
				f = Mathf.Max(s.y - m_AreaSize.y, 0);
			}
			m_Content.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, f);
			gameObject.SetActive(true);
		}

		// RVA: 0xA65B14 Offset: 0xA65B14 VA: 0xA65B14
		public void Hide()
		{
			gameObject.SetActive(false);
		}
	}
}
