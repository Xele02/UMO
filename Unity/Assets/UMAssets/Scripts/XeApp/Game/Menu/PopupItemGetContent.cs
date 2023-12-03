using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupItemGetContent : UIBehaviour, IPopupContent, ILayoutUGUIPaste
	{
		private PopupItemGetSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private LayoutPopupItemGet layout; // 0x18

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x17AC228 Offset: 0x17AC228 VA: 0x17AC228 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupItemGetSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			layout = setup.Content.GetComponent<LayoutPopupItemGet>();
			layout.SetStatus(setup.ItemId, setup.IsPresentBox, setup.Count, setup.ItemContent);
			gameObject.SetActive(true);
		}

		// RVA: 0x17AC508 Offset: 0x17AC508 VA: 0x17AC508 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x17AC510 Offset: 0x17AC510 VA: 0x17AC510 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x17AC548 Offset: 0x17AC548 VA: 0x17AC548 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x17AC580 Offset: 0x17AC580 VA: 0x17AC580 Slot: 21
		public bool IsReady()
		{
			return layout == null || !layout.IsLoading();
		}

		// RVA: 0x17AC640 Offset: 0x17AC640 VA: 0x17AC640 Slot: 22
		public void CallOpenEnd()
		{
			OnDestroy();
		}

		// RVA: 0x17AC648 Offset: 0x17AC648 VA: 0x17AC648 Slot: 25
		public virtual bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			return true;
		}
	}
}
