using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupRaidHelpCompletionListContentSetting : PopupSetting
	{
		public List<PKNOKJNLPOE_EventRaid.ECICDAPCMJG> helperList; // 0x34

		public override string PrefabPath { get { return ""; } } //0x1617970
		public override string BundleName { get { return "ly/200.xab"; } } //0x16179CC
		public override string AssetName { get { return "root_sel_music_raid_win_01_layout_root"; } } //0x1617A28
		public override bool IsAssetBundle { get { return true; } } //0x1617A84
		public override bool IsPreload { get { return false; } } //0x1617A8C
		public override GameObject Content { get { return m_content; } } //0x1617A94

		// // RVA: 0x1617A9C Offset: 0x1617A9C VA: 0x1617A9C
		// public void SetContent(GameObject obj) { }

		// [IteratorStateMachineAttribute] // RVA: 0x714AB4 Offset: 0x714AB4 VA: 0x714AB4
		// RVA: 0x1617AA4 Offset: 0x1617AA4 VA: 0x1617AA4 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			//0x1617B80
			yield return Co.R(base.LoadAssetBundlePrefab(parent));
			yield return Co.R(m_content.GetComponent<RaidHelpCompletionListWindow>().LoadScrollObjectCoroutine());
		}

		// [CompilerGeneratedAttribute] // RVA: 0x714B2C Offset: 0x714B2C VA: 0x714B2C
		// [DebuggerHiddenAttribute] // RVA: 0x714B2C Offset: 0x714B2C VA: 0x714B2C
		// // RVA: 0x1617B74 Offset: 0x1617B74 VA: 0x1617B74
		// private IEnumerator <>n__0(Transform parent) { }
	}

	public class PopupRaidHelpCompletionListContent : UIBehaviour, IPopupContent
	{
		private PopupRaidHelpCompletionListContentSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private int selectIndex; // 0x18
		private RaidHelpCompletionListWindow layout; // 0x1C

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x1617634 Offset: 0x1617634 VA: 0x1617634 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupRaidHelpCompletionListContentSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			transform.GetComponent<RaidHelpCompletionListWindow>().Initialize(setup.helperList);
		}

		// RVA: 0x1617830 Offset: 0x1617830 VA: 0x1617830 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1617838 Offset: 0x1617838 VA: 0x1617838
		public void Update()
		{
			return;
		}

		// RVA: 0x161783C Offset: 0x161783C VA: 0x161783C Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1617874 Offset: 0x1617874 VA: 0x1617874 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x16178AC Offset: 0x16178AC VA: 0x16178AC Slot: 21
		public bool IsReady()
		{
			return layout == null || layout.IsLoaded();
		}

		// RVA: 0x1617964 Offset: 0x1617964 VA: 0x1617964 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
