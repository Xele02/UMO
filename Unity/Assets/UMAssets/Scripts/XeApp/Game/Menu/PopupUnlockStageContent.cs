using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupUnlockStageContent : UIBehaviour, IPopupContent
	{
		private LayoutPopupUnlockStage m_stage; // 0x10

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x115F300 Offset: 0x115F300 VA: 0x115F300 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupUnlockStageContentSetting s = setting as PopupUnlockStageContentSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_stage = setting.Content.GetComponent<LayoutPopupUnlockStage>();
			if(m_stage != null)
			{
				m_stage.SetStatus(s.UnlockInfo);
			}
			gameObject.SetActive(true);
		}

		// RVA: 0x115F55C Offset: 0x115F55C VA: 0x115F55C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x115F564 Offset: 0x115F564 VA: 0x115F564
		public void Update()
		{
			return;
		}

		// RVA: 0x115F568 Offset: 0x115F568 VA: 0x115F568 Slot: 19
		public void Show()
		{
			if(m_stage != null)
				m_stage.Show();
			gameObject.SetActive(true);
		}

		// RVA: 0x115F64C Offset: 0x115F64C VA: 0x115F64C Slot: 20
		public void Hide()
		{
			if(m_stage != null)
				m_stage.Hide();
			gameObject.SetActive(false);
		}

		// RVA: 0x115F730 Offset: 0x115F730 VA: 0x115F730 Slot: 21
		public bool IsReady()
		{
			if(m_stage != null)
				return !m_stage.IsLoading();
			return true;
		}

		// RVA: 0x115F7F0 Offset: 0x115F7F0 VA: 0x115F7F0 Slot: 22
		public void CallOpenEnd()
		{
			if(m_stage != null)
				m_stage.TitleAnimPlay();
		}
	}
}
