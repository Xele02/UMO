using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupDecoCreateStamp : UIBehaviour, IPopupContent
	{
		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x1345F8C Offset: 0x1345F8C VA: 0x1345F8C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			DecoCreateStampPopupSetting s = setting as DecoCreateStampPopupSetting;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			LayoutDecoCustomCreateCheckWindow l = transform.GetComponent<LayoutDecoCustomCreateCheckWindow>();
			l.SetStampInfo(s.charactorId, s.serifId);
			Parent = s.m_parent;
			gameObject.SetActive(true);
		}

		// RVA: 0x13461D8 Offset: 0x13461D8 VA: 0x13461D8 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x13461E0 Offset: 0x13461E0 VA: 0x13461E0 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1346218 Offset: 0x1346218 VA: 0x1346218 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1346250 Offset: 0x1346250 VA: 0x1346250 Slot: 21
		public bool IsReady()
		{
			LayoutDecoCustomCreateCheckWindow l = transform.GetComponent<LayoutDecoCustomCreateCheckWindow>();
			return l.IsLoaded() && l.IsLoading();
		}

		// RVA: 0x134631C Offset: 0x134631C VA: 0x134631C Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
