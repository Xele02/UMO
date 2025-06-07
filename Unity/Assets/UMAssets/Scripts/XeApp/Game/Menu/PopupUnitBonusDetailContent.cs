using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PopupUnitBonusDetailContentSetting : PopupSetting
	{
		private List<PKNOKJNLPOE_EventRaid.MOAICCAOMCP.AAALCKPHGNG> costumeData; // 0x34
		private List<PKNOKJNLPOE_EventRaid.MOAICCAOMCP.LNKNJHEFBCE> valkyrieData; // 0x38

		public override string PrefabPath { get { return ""; } } //0x1155B70
		public override string BundleName { get { return "ly/208.xab"; } } //0x1155BCC
		public List<PKNOKJNLPOE_EventRaid.MOAICCAOMCP.AAALCKPHGNG> CostumeData { get { return costumeData; } } //0x1155A54
		public List<PKNOKJNLPOE_EventRaid.MOAICCAOMCP.LNKNJHEFBCE> ValkyrieData { get { return valkyrieData; } } //0x1155A5C
		public override string AssetName { get { return "root_pop_ep_raid_bonus_layout_root"; } } //0x1155C28
		public override bool IsAssetBundle { get { return true; } } //0x1155C84
		public override bool IsPreload { get { return true; } } //0x1155C8C
		public override GameObject Content { get { return m_content; } } //0x1155C94

		// // RVA: 0x1155C9C Offset: 0x1155C9C VA: 0x1155C9C
		// public void SetContent(GameObject obj) { }

		// RVA: 0x1155CA4 Offset: 0x1155CA4 VA: 0x1155CA4
		public void SetCostumeData(List<PKNOKJNLPOE_EventRaid.MOAICCAOMCP.AAALCKPHGNG> data)
		{
			TitleText = MessageManager.Instance.GetMessage("menu", "popup_raid_formation_bonus_costume_title");
			costumeData = data;
			valkyrieData = null;
		}

		// RVA: 0x1155D64 Offset: 0x1155D64 VA: 0x1155D64
		public void SetValkyrieData(List<PKNOKJNLPOE_EventRaid.MOAICCAOMCP.LNKNJHEFBCE> data)
		{
			TitleText = MessageManager.Instance.GetMessage("menu", "popup_raid_formation_bonus_valkyrie_title");
			costumeData = null;
			valkyrieData = data;
		}
	}

	public class PopupUnitBonusDetailContent : UIBehaviour, IPopupContent
	{
		private PopupUnitBonusDetailContentSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private int selectIndex; // 0x18
		private UnitBonusDetailWindow layout; // 0x1C

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x11557D8 Offset: 0x11557D8 VA: 0x11557D8 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupUnitBonusDetailContentSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			UnitBonusDetailWindow win = transform.GetComponent<UnitBonusDetailWindow>();
			if(setup.CostumeData == null)
			{
				win.Initialize(setup.ValkyrieData);
			}
			else
			{
				win.Initialize(setup.CostumeData);
			}
			gameObject.SetActive(true);
		}

		// RVA: 0x1155A64 Offset: 0x1155A64 VA: 0x1155A64 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1155A6C Offset: 0x1155A6C VA: 0x1155A6C
		public void Update()
		{
			return;
		}

		// RVA: 0x1155A70 Offset: 0x1155A70 VA: 0x1155A70 Slot: 19
		public void Show()
		{
			return;
		}

		// RVA: 0x1155A74 Offset: 0x1155A74 VA: 0x1155A74 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1155AAC Offset: 0x1155AAC VA: 0x1155AAC Slot: 21
		public bool IsReady()
		{
			return layout == null || layout.IsLoaded();
		}

		// RVA: 0x1155B64 Offset: 0x1155B64 VA: 0x1155B64 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
