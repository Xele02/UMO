using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupDashContent : UIBehaviour, IPopupContent
	{
		private PopupDashContentSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private int selectIndex; // 0x18
		private LayoutPopupDash layout; // 0x1C

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x13441F4 Offset: 0x13441F4 VA: 0x13441F4 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupDashContentSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			if(setup.EventId == GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.BCOIACHCMLA_Live.BKCOOGKFJJF_GetPlayDashEventId())
			{
				selectIndex = GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.BCOIACHCMLA_Live.GHEFLJANGIC_GetPlayDashSelect();
				selectIndex = Mathf.Clamp(selectIndex, 0, setup.Param.Length - 1);
			}
			layout = setup.Content.GetComponent<LayoutPopupDash>();
			layout.SetStatus(setup.CostType, setup.Param, setup.OwnValue, selectIndex);
			gameObject.SetActive(true);
			layout.OnSelectCallback = OnSelect;
		}

		// RVA: 0x13446D0 Offset: 0x13446D0 VA: 0x13446D0
		private void OnSelect(int select)
		{
			if(setup.OnSelectCallback != null)
			{
				setup.OnSelectCallback(select);
			}
			selectIndex = select;
			bool isOver = false;
			if(setup.CostType == LayoutPopupDash.CostType.Ticket)
			{
				isOver = setup.OwnValue < setup.Param[select].Cost;
			}
			else if(setup.CostType == LayoutPopupDash.CostType.Energy)
			{
				int b = CIOECGOMILE.HHCJCDFCLOB.BPLOEAHOPFI_StaminaUpdater.DCBENCMNOGO_MaxStamina;
				int a = setup.OwnValue;
				if(a < b)
					a += b;
				isOver = setup.OwnValue < setup.Param[select].Cost;
			}
			layout.SetCostOver(isOver);
			ButtonBase btn = control.FindButton(PopupButton.ButtonType.Live);
			if(btn != null)
				btn.Disable = isOver;
		}

		// RVA: 0x13449BC Offset: 0x13449BC VA: 0x13449BC Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x13449C4 Offset: 0x13449C4 VA: 0x13449C4
		public void Update()
		{
			return;
		}

		// RVA: 0x13449C8 Offset: 0x13449C8 VA: 0x13449C8 Slot: 19
		public void Show()
		{
			OnSelect(selectIndex);
			ButtonBase btn = control.FindButton(PopupButton.ButtonType.Live);
			if(btn != null)
			{
				btn.AddOnClickCallback(() =>
				{
					//0x1344D2C
					GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.BCOIACHCMLA_Live.KJGPOAEGFHK_SetDashInfo(setup.EventId, selectIndex);
					GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
				});
			}
			if(layout != null)
				layout.Show();
			gameObject.SetActive(true);
		}

		// RVA: 0x1344B7C Offset: 0x1344B7C VA: 0x1344B7C Slot: 20
		public void Hide()
		{
			if(layout != null)
			{
				layout.Hide();
			}
			gameObject.SetActive(false);
		}

		// RVA: 0x1344C60 Offset: 0x1344C60 VA: 0x1344C60 Slot: 21
		public bool IsReady()
		{
			return layout == null || !layout.IsLoading();
		}

		// RVA: 0x1344D20 Offset: 0x1344D20 VA: 0x1344D20 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
