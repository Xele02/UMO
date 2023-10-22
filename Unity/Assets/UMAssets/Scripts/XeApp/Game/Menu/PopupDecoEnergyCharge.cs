using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupDecoEnergyCharge : UIBehaviour, IPopupContent
	{
		private LayoutDecorationEnergyChargePopup m_layoutDecorationEnergyChargePopup; // 0x10
		private int currentStock; // 0x14
		private int currentGauge; // 0x18
		private bool isCurrentMax; // 0x1C
		private int nextGauge; // 0x20
		private bool isMax; // 0x24
		private ActionButton okButton; // 0x28

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x1346338 Offset: 0x1346338 VA: 0x1346338 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupDecoEnergyChargeSetting s = setting as PopupDecoEnergyChargeSetting;
			Parent = s.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_layoutDecorationEnergyChargePopup = s.Content.GetComponent<LayoutDecorationEnergyChargePopup>();
			currentStock = s.currentStock;
			currentGauge = s.currentGauge;
			isCurrentMax = s.isCurrentMax;
			nextGauge = s.nextGauge;
			isMax = s.isCurrentMax;
			if(m_layoutDecorationEnergyChargePopup != null)
			{
				m_layoutDecorationEnergyChargePopup.Set(s.currentStock, s.currentGauge, s.nextGauge, s.isCurrentMax, s.isDeco);
			}
			okButton = control.FindButton(PopupButton.ButtonLabel.UsedItem);
			Parent = s.m_parent;
		}

		// RVA: 0x134660C Offset: 0x134660C VA: 0x134660C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1346614 Offset: 0x1346614 VA: 0x1346614 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x134664C Offset: 0x134664C VA: 0x134664C Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1346684 Offset: 0x1346684 VA: 0x1346684 Slot: 21
		public bool IsReady()
		{
			return m_layoutDecorationEnergyChargePopup == null || !m_layoutDecorationEnergyChargePopup.IsLoading();
		}

		// RVA: 0x1346744 Offset: 0x1346744 VA: 0x1346744 Slot: 22
		public void CallOpenEnd()
		{
			if(m_layoutDecorationEnergyChargePopup == null || isMax)
				return;
			if(okButton != null)
			{
				okButton.IsInputOff = true;
			}
			this.StartCoroutineWatched(m_layoutDecorationEnergyChargePopup.Co_UpdateGauge(currentStock, currentGauge, nextGauge, GaugeAnimeEnd));
		}

		// // RVA: 0x13468E0 Offset: 0x13468E0 VA: 0x13468E0
		private void GaugeAnimeEnd()
		{
			if(okButton != null)
				okButton.IsInputOff = false;
		}
	}
}
