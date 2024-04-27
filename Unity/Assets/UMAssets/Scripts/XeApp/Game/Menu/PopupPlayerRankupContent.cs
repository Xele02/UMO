using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupPlayerRankupContent : UIBehaviour, IPopupContent
	{
		private LayoutResultPopupPlayerRankup layout; // 0x10
		private PopupWindowControl m_control; // 0x14

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x160A774 Offset: 0x160A774 VA: 0x160A774 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupPlayerRankupSetting s = setting as PopupPlayerRankupSetting;
			Parent = control.transform;
			m_control = control;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			if(s.Content != null)
			{
				layout = s.Content.GetComponent<LayoutResultPopupPlayerRankup>();
				if(layout != null)
				{
					layout.Setup(s.param);
				}
			}
			gameObject.SetActive(true);
		}

		// RVA: 0x160AA50 Offset: 0x160AA50 VA: 0x160AA50 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x160AA58 Offset: 0x160AA58 VA: 0x160AA58 Slot: 19
		public void Show()
		{
			if(layout != null)
				layout.Show();
		}

		// RVA: 0x160AB0C Offset: 0x160AB0C VA: 0x160AB0C Slot: 20
		public void Hide()
		{
			if(layout != null)
				layout.Hide();
		}

		// RVA: 0x160ABC0 Offset: 0x160ABC0 VA: 0x160ABC0 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x160ABC8 Offset: 0x160ABC8 VA: 0x160ABC8 Slot: 22
		public void CallOpenEnd()
		{
			SetInput(false);
		}

		// // RVA: 0x160ABD0 Offset: 0x160ABD0 VA: 0x160ABD0
		public void SetInput(bool enabled)
		{
			PopupButton[] btns = transform.parent.parent.parent.GetComponentsInChildren<PopupButton>(true);
			for(int i = 0; i < btns.Length; i++)
			{
				btns[i].enabled = enabled;
			}
		}
	}
}
