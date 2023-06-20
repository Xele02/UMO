using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupEpisodeRelease : UIBehaviour, IPopupContent
	{
		private PIGBBNDPPJC m_data; // 0x10
		private int m_item_type; // 0x14
		private PopupButton[] m_buttons; // 0x18

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0xF8B57C Offset: 0xF8B57C VA: 0xF8B57C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			EpisodeReleasePopupSetting s = setting as EpisodeReleasePopupSetting;
			Parent = setting.m_parent;
			m_data = s.data;
			m_item_type = s.item_type;
			gameObject.SetActive(true);
			transform.localPosition = Vector3.zero;
		}

		// RVA: 0xF8B754 Offset: 0xF8B754 VA: 0xF8B754 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF8B75C Offset: 0xF8B75C VA: 0xF8B75C Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
			SetDisable(true);
			transform.GetComponent<EpisodeReleaseWindow>().Enter();
		}

		// RVA: 0xF8B9D8 Offset: 0xF8B9D8 VA: 0xF8B9D8 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0xF8BA10 Offset: 0xF8BA10 VA: 0xF8BA10 Slot: 21
		public bool IsReady()
		{
			return transform.GetComponent<EpisodeReleaseWindow>().IsLoaded();
		}

		// RVA: 0xF8B83C Offset: 0xF8B83C VA: 0xF8B83C
		public void SetDisable(bool disable)
		{
			PopupButton[] btns = transform.parent.parent.parent.GetComponentsInChildren<PopupButton>(true);
			for(int i = 0; i < btns.Length; i++)
			{
				if(btns[i].Label == PopupButton.ButtonLabel.UsedItem)
				{
					btns[i].Disable = disable;
				}
			}
		}

		// RVA: 0xF8BAB4 Offset: 0xF8BAB4 VA: 0xF8BAB4 Slot: 22
		public void CallOpenEnd()
		{
			transform.GetComponent<EpisodeReleaseWindow>().OpenEnd();
		}
	}
}
