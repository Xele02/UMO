using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupRaidBossEncountContentSetting : PopupSetting
	{
		public override string PrefabPath { get { return ""; } } //0x16167F4
		public override string BundleName { get { return "ly/200.xab"; } } //0x1616850
		public override string AssetName { get { return "root_sel_music_raid_pop_boss_layout_root"; } } //0x16168AC
		public override bool IsAssetBundle { get { return true; } } //0x1616908
		public override bool IsPreload { get { return false; } } //0x1616910
		public override GameObject Content { get { return m_content; } } //0x1616918

		// // RVA: 0x1616920 Offset: 0x1616920 VA: 0x1616920
		// public void SetContent(GameObject obj) { }
	}

	public class PopupRaidBossEncountContent : UIBehaviour, IPopupContent
	{
		private PopupRaidBossEncountContentSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private int selectIndex; // 0x18
		private RaidBossEncountWindow layout; // 0x1C

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x16164D4 Offset: 0x16164D4 VA: 0x16164D4 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupRaidBossEncountContentSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			transform.GetComponent<RaidBossEncountWindow>().Initialize();
		}

		// RVA: 0x16166B4 Offset: 0x16166B4 VA: 0x16166B4 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x16166BC Offset: 0x16166BC VA: 0x16166BC
		public void Update()
		{
			return;
		}

		// RVA: 0x16166C0 Offset: 0x16166C0 VA: 0x16166C0 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x16166F8 Offset: 0x16166F8 VA: 0x16166F8 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1616730 Offset: 0x1616730 VA: 0x1616730 Slot: 21
		public bool IsReady()
		{
			return layout == null || layout.IsLoaded();
		}

		// RVA: 0x16167E8 Offset: 0x16167E8 VA: 0x16167E8 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
