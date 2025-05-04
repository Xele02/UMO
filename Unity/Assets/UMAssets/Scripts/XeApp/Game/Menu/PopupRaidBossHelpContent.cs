using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;

namespace XeApp.Game.Menu
{
	public class PopupRaidBossHelpContentSetting : PopupSetting
	{
		public Action<RaidBossHelpWindow.SelectType> OnSelectType; // 0x34

		public override string PrefabPath { get { return ""; } } //0x1617074
		public override string BundleName { get { return "ly/200.xab"; } } //0x16170D0
		public override string AssetName { get { return "root_sel_music_raid_pop_help_layout_root"; } } //0x161712C
		public override bool IsAssetBundle { get { return true; } } //0x1617188
		public override bool IsPreload { get { return false; } } //0x1617190
		public override GameObject Content { get { return m_content; } } //0x1617198

		// // RVA: 0x16171A0 Offset: 0x16171A0 VA: 0x16171A0
		// public void SetContent(GameObject obj) { }
	}

	public class PopupRaidBossHelpContent : UIBehaviour, IPopupContent
	{
		private PopupRaidBossHelpContentSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private int selectIndex; // 0x18
		private RaidBossHelpWindow layout; // 0x1C

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x1616940 Offset: 0x1616940 VA: 0x1616940 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupRaidBossHelpContentSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			transform.GetComponent<RaidBossHelpWindow>().Initialize(setup.OnSelectType);
		}

		// RVA: 0x1616B3C Offset: 0x1616B3C VA: 0x1616B3C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1616B44 Offset: 0x1616B44 VA: 0x1616B44
		public void Update()
		{
			return;
		}

		// RVA: 0x1616B48 Offset: 0x1616B48 VA: 0x1616B48 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1616B80 Offset: 0x1616B80 VA: 0x1616B80 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1616BB8 Offset: 0x1616BB8 VA: 0x1616BB8 Slot: 21
		public bool IsReady()
		{
			return layout == null || layout.IsLoaded();
		}

		// RVA: 0x1616C70 Offset: 0x1616C70 VA: 0x1616C70 Slot: 22
		public void CallOpenEnd()
		{
			this.StartCoroutineWatched(TryShowTutorial_78());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7149CC Offset: 0x7149CC VA: 0x7149CC
		// // RVA: 0x1616C94 Offset: 0x1616C94 VA: 0x1616C94
		protected IEnumerator TryShowTutorial_78()
		{
			//0x1616DD8
			control.InputDisable();
			yield return Co.R(TutorialManager.TryShowTutorialCoroutine((TutorialConditionId conditionId) =>
			{
				//0x1616DC4
				return conditionId == TutorialConditionId.Condition78;
			}));
			control.InputEnable();
		}
	}
}
