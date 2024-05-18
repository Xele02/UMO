using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupRewardEv2Detail : UIBehaviour, IPopupContent
	{
		private PopupRewardEv2DetailLayout layout; // 0xC

		public Transform Parent { get; set; } // 0x10

		// RVA: 0x161DB70 Offset: 0x161DB70 VA: 0x161DB70 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupRewardEv2DetailSetting s = setting as PopupRewardEv2DetailSetting;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			Parent = setting.m_parent;
			gameObject.SetActive(true);
			transform.localPosition = Vector3.zero;
			layout = transform.GetComponent<PopupRewardEv2DetailLayout>();
			layout.Init(s.Scene);
		}

		// RVA: 0x161DE34 Offset: 0x161DE34 VA: 0x161DE34 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x161DE3C Offset: 0x161DE3C VA: 0x161DE3C Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x161DE74 Offset: 0x161DE74 VA: 0x161DE74 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
			layout.ReleaseDecoration();
		}

		// RVA: 0x161DEF8 Offset: 0x161DEF8 VA: 0x161DEF8 Slot: 21
		public bool IsReady()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning && !layout.IsLoading();
		}

		// RVA: 0x161DFE0 Offset: 0x161DFE0 VA: 0x161DFE0
		public void SetInput(bool enabled)
		{
			PopupButton[] btns = transform.parent.parent.parent.GetComponentsInChildren<PopupButton>(true);
			for(int i = 0; i < btns.Length; i++)
			{
				btns[i].enabled = enabled;
			}
		}

		// RVA: 0x161E138 Offset: 0x161E138 VA: 0x161E138 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
