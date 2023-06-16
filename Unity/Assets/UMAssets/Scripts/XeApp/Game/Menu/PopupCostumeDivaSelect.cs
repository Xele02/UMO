using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupCostumeDivaSelect : UIBehaviour, IPopupContent
	{
		private CostumeDivaSelectWindow m_divaSelectWindow; // 0x10

		public Transform Parent { get; private set; } // 0xC
		private CostumeDivaSelectWindow DivaSelectWindow { get
			{
				if (m_divaSelectWindow == null)
					m_divaSelectWindow = GetComponent<CostumeDivaSelectWindow>();
				return m_divaSelectWindow;
			}
		} // 0x134229C

		// RVA: 0x1342350 Offset: 0x1342350 VA: 0x1342350 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			CostumeDivaSelectPopupSetting s = setting as CostumeDivaSelectPopupSetting;
			Parent = setting.m_parent;
			gameObject.SetActive(true);
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			DivaSelectWindow.SetDivaFilterButton(s.FilterDivaIdList);
		}

		// RVA: 0x1342578 Offset: 0x1342578 VA: 0x1342578 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1342580 Offset: 0x1342580 VA: 0x1342580 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x13425B8 Offset: 0x13425B8 VA: 0x13425B8 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x13425F0 Offset: 0x13425F0 VA: 0x13425F0 Slot: 21
		public bool IsReady()
		{
			return DivaSelectWindow.IsInitialized;
		}

		// RVA: 0x1342620 Offset: 0x1342620 VA: 0x1342620 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		// RVA: 0x1342624 Offset: 0x1342624 VA: 0x1342624
		public void Update()
		{
			DivaSelectWindow.Update();
		}
	}
}
