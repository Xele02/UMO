using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupRaidBossSortContentSetting : PopupSetting
	{
		public override string PrefabPath { get { return ""; } } //0x16174E8
		public override string BundleName { get { return "ly/200.xab"; } } //0x1617544
		public override string AssetName { get { return "root_sel_music_raid_pop_sort_filter_layout_root"; } } //0x16175A0
		public override bool IsAssetBundle { get { return true; } } //0x16175FC
		public override bool IsPreload { get { return true; } } //0x1617604
		public override GameObject Content { get { return m_content; } } //0x161760C

		// // RVA: 0x1617614 Offset: 0x1617614 VA: 0x1617614
		// public void SetContent(GameObject obj) { }
	}

	public class PopupRaidBossSortContent : UIBehaviour, IPopupContent
	{
		private PopupRaidBossSortContentSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private int selectIndex; // 0x18
		private RaidBossSortWindow layout; // 0x1C
		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x16171C0 Offset: 0x16171C0 VA: 0x16171C0 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupRaidBossSortContentSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			transform.GetComponent<RaidBossSortWindow>().Initialize();
		}

		// RVA: 0x16173A0 Offset: 0x16173A0 VA: 0x16173A0
		public RaidBossSortWindow GetRaidBossSortWindow()
		{
			return layout;
		}

		// RVA: 0x16173A8 Offset: 0x16173A8 VA: 0x16173A8 Slot: 18
		public bool IsScrollable()
		{
			return true;
		}

		// RVA: 0x16173B0 Offset: 0x16173B0 VA: 0x16173B0
		public void Update()
		{
			return;
		}

		// RVA: 0x16173B4 Offset: 0x16173B4 VA: 0x16173B4 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x16173EC Offset: 0x16173EC VA: 0x16173EC Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1617424 Offset: 0x1617424 VA: 0x1617424 Slot: 21
		public bool IsReady()
		{
			return layout == null || layout.IsLoaded();
		}

		// RVA: 0x16174DC Offset: 0x16174DC VA: 0x16174DC Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
