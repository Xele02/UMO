using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupLimitOverContent : UIBehaviour, IPopupContent
	{
		private PopupLimitOverContentSetting setup; // 0x10
		private LayoutPopupLimitOver layout; // 0x14

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x17AF0C8 Offset: 0x17AF0C8 VA: 0x17AF0C8 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			setup = setting as PopupLimitOverContentSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			layout = setup.Content.GetComponent<LayoutPopupLimitOver>();
			layout.SetStatus(setup.LimitOverData, setup.ContentText);
			gameObject.SetActive(true);
		}

		// RVA: 0x17AF330 Offset: 0x17AF330 VA: 0x17AF330 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x17AF338 Offset: 0x17AF338 VA: 0x17AF338
		public void Update()
		{
			return;
		}

		// RVA: 0x17AF33C Offset: 0x17AF33C VA: 0x17AF33C Slot: 19
		public void Show()
		{
			if(layout != null)
				layout.Show();
			gameObject.SetActive(true);
		}

		// RVA: 0x17AF420 Offset: 0x17AF420 VA: 0x17AF420 Slot: 20
		public void Hide()
		{
			if(layout != null)
				layout.Hide();
			gameObject.SetActive(false);
		}

		// RVA: 0x17AF504 Offset: 0x17AF504 VA: 0x17AF504 Slot: 21
		public bool IsReady()
		{
			return layout == null || !layout.IsLoading();
		}

		// RVA: 0x17AF5C4 Offset: 0x17AF5C4 VA: 0x17AF5C4 Slot: 22
		public void CallOpenEnd()
		{
			if(layout != null)
				layout.StringAnimPlay();
		}
	}
}
