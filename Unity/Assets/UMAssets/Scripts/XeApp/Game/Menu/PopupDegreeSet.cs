using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupDegreeSet : UIBehaviour, IPopupContent
	{
		private IAPDFOPPGND m_data; // 0x10

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0xF7B214 Offset: 0xF7B214 VA: 0xF7B214 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			DegreeSetPopupSetting s = setting as DegreeSetPopupSetting;
			Parent = setting.m_parent;
			m_data = s.data;
			gameObject.SetActive(true);
			transform.localPosition = Vector3.zero;
			transform.GetComponent<RectTransform>().sizeDelta = size;
		}

		// RVA: 0xF7B42C Offset: 0xF7B42C VA: 0xF7B42C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF7B434 Offset: 0xF7B434 VA: 0xF7B434 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0xF7B46C Offset: 0xF7B46C VA: 0xF7B46C Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0xF7B4A4 Offset: 0xF7B4A4 VA: 0xF7B4A4 Slot: 21
		public bool IsReady()
		{
			transform.GetComponent<DegreeSetWindow>().Init(m_data);
			return true;
		}

		// RVA: 0xF7B554 Offset: 0xF7B554 VA: 0xF7B554 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
