using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupGetBingoRewaedContent : UIBehaviour, IPopupContent
	{
		private PopupGetBingoRewaedSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private LayoutGetBingoReward layout; // 0x18

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x17A7DFC Offset: 0x17A7DFC VA: 0x17A7DFC Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupGetBingoRewaedSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			layout = setup.Content.GetComponent<LayoutGetBingoReward>();
			layout.SetUp(setup.ItemId, setup.BingoCount, setup.GetItemCount);
		}

		// RVA: 0x17A805C Offset: 0x17A805C VA: 0x17A805C
		private void Start()
		{
			return;
		}

		// RVA: 0x17A8060 Offset: 0x17A8060 VA: 0x17A8060
		private void Update()
		{
			return;
		}

		// RVA: 0x17A8064 Offset: 0x17A8064 VA: 0x17A8064 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x17A806C Offset: 0x17A806C VA: 0x17A806C Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
			if(layout != null)
				layout.ShowTitle();
		}

		// RVA: 0x17A8150 Offset: 0x17A8150 VA: 0x17A8150 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x17A8188 Offset: 0x17A8188 VA: 0x17A8188 Slot: 21
		public bool IsReady()
		{
			return layout != null && layout.IsIconLoaded() && layout.IsLoaded();
		}

		// RVA: 0x17A826C Offset: 0x17A826C VA: 0x17A826C Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
