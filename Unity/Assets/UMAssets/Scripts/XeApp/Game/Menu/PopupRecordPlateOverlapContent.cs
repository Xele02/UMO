using System;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupRecordPlateOverlapContent : UIBehaviour, IPopupContent, IDisposable
	{
		private LayoutPopupGachaOverlap m_gachaOverlap; // 0x10

		// Properties
		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x161B124 Offset: 0x161B124 VA: 0x161B124 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupRecordPlateOverlapSetting s = setting as PopupRecordPlateOverlapSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_gachaOverlap = GetComponent<LayoutPopupGachaOverlap>();
			if(m_gachaOverlap != null)
			{
				m_gachaOverlap.SetStatus(s.RareUpInfo);
				m_gachaOverlap.OnButtonCallbackHidden = (bool isHidden) =>
				{
					//0x161B6E8
					control.FindButton(PopupButton.ButtonLabel.Ok).Hidden = isHidden;
				};
			}
			gameObject.SetActive(true);
		}

		// RVA: 0x161B400 Offset: 0x161B400 VA: 0x161B400 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x161B408 Offset: 0x161B408 VA: 0x161B408 Slot: 19
		public void Show()
		{
			if(m_gachaOverlap != null)
			{
				m_gachaOverlap.Show();
			}
			gameObject.SetActive(true);
		}

		// RVA: 0x161B4EC Offset: 0x161B4EC VA: 0x161B4EC Slot: 20
		public void Hide()
		{
			if(m_gachaOverlap != null)
			{
				m_gachaOverlap.Hide();
				m_gachaOverlap.Reset();
			}
			gameObject.SetActive(false);
		}

		// RVA: 0x161B5F0 Offset: 0x161B5F0 VA: 0x161B5F0 Slot: 21
		public bool IsReady()
		{
			if (m_gachaOverlap != null)
				return !m_gachaOverlap.IsLoading();
			return true;
		}

		// RVA: 0x161B6B0 Offset: 0x161B6B0 VA: 0x161B6B0 Slot: 22
		public void CallOpenEnd()
		{
			m_gachaOverlap.CallbackOpenEnd();
		}

		// RVA: 0x161B6DC Offset: 0x161B6DC VA: 0x161B6DC Slot: 24
		public void Dispose()
		{
			return;
		}
	}
}
