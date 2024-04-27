using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupUnlockNotifyDivaContent : UIBehaviour, IPopupContent
	{
		private LayoutPopupUnlockNotifyDiva m_notifyDiva; // 0x10

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x115EC00 Offset: 0x115EC00 VA: 0x115EC00 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupUnlockNotifyDivaSetting s = setting as PopupUnlockNotifyDivaSetting;
			Parent = s.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_notifyDiva = setting.Content.GetComponent<LayoutPopupUnlockNotifyDiva>();
			if(m_notifyDiva != null)
			{
				m_notifyDiva.SetStatus(s.UnlockInfo);
			}
			gameObject.SetActive(true);
		}

		// RVA: 0x115EE5C Offset: 0x115EE5C VA: 0x115EE5C Slot: 18
		public bool IsScrollable()
		{ 
			return false;
		}

		// RVA: 0x115EE64 Offset: 0x115EE64 VA: 0x115EE64
		public void Update()
		{ 
			return;
		}

		// RVA: 0x115EE68 Offset: 0x115EE68 VA: 0x115EE68 Slot: 19
		public void Show()
		{
			if(m_notifyDiva != null)
			{
				m_notifyDiva.Show();
			}
			gameObject.SetActive(true);
		}

		// RVA: 0x115EF4C Offset: 0x115EF4C VA: 0x115EF4C Slot: 20
		public void Hide()
		{
			if(m_notifyDiva != null)
			{
				m_notifyDiva.Hide();
			}
			gameObject.SetActive(false);
		}

		// RVA: 0x115F030 Offset: 0x115F030 VA: 0x115F030 Slot: 21
		public bool IsReady()
		{
			if(m_notifyDiva == null)
				return true;
			return !m_notifyDiva.IsLoading();
		}

		// RVA: 0x115F0F0 Offset: 0x115F0F0 VA: 0x115F0F0 Slot: 22
		public void CallOpenEnd()
		{
			if(m_notifyDiva != null)
				m_notifyDiva.TitleAnimPlay();
		}
	}
}
