using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupRaidPlateContentSetting : PopupSetting
	{
		public override string PrefabPath { get { return ""; } } //0x1618068
		public override string BundleName { get { return "ly/200.xab"; } } //0x16180C4
		public override string AssetName { get { return "root_sel_music_raid_pop_plate_layout_root"; } } //0x1618120
		public override bool IsAssetBundle { get { return true; } } //0x161817C
		public override bool IsPreload { get { return false; } } //0x1618184
		public override GameObject Content { get { return m_content; } } //0x161818C

		// // RVA: 0x1618194 Offset: 0x1618194 VA: 0x1618194
		// public void SetContent(GameObject obj) { }

		// [IteratorStateMachineAttribute] // RVA: 0x714BCC Offset: 0x714BCC VA: 0x714BCC
		// RVA: 0x161819C Offset: 0x161819C VA: 0x161819C Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			//0x1618278
			yield return Co.R(base.LoadAssetBundlePrefab(parent));
			yield return Co.R(m_content.GetComponent<RaidPlateWindow>().LoadScrollObjectCoroutine());
		}

		// [DebuggerHiddenAttribute] // RVA: 0x714C44 Offset: 0x714C44 VA: 0x714C44
		// [CompilerGeneratedAttribute] // RVA: 0x714C44 Offset: 0x714C44 VA: 0x714C44
		// // RVA: 0x161826C Offset: 0x161826C VA: 0x161826C
		// private IEnumerator <>n__0(Transform parent) { }
	}
	public class PopupRaidPlateContent : UIBehaviour, IPopupContent
	{
		private PopupRaidPlateContentSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private int selectIndex; // 0x18
		private RaidPlateWindow layout; // 0x1C

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x1617D48 Offset: 0x1617D48 VA: 0x1617D48 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupRaidPlateContentSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			transform.GetComponent<RaidPlateWindow>().Initialize();
		}

		// RVA: 0x1617F28 Offset: 0x1617F28 VA: 0x1617F28 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1617F30 Offset: 0x1617F30 VA: 0x1617F30
		public void Update()
		{
			return;
		}

		// RVA: 0x1617F34 Offset: 0x1617F34 VA: 0x1617F34 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1617F6C Offset: 0x1617F6C VA: 0x1617F6C Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1617FA4 Offset: 0x1617FA4 VA: 0x1617FA4 Slot: 21
		public bool IsReady()
		{
			return layout == null || layout.IsLoaded();
		}

		// RVA: 0x161805C Offset: 0x161805C VA: 0x161805C Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
