using XeApp.Core;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameScene : MainSceneBase
	{
		[SerializeField] // RVA: 0x68E4B8 Offset: 0x68E4B8 VA: 0x68E4B8
		private Button prevSceneButton; // 0x28
		public bool isReady; // 0x2C
		// private DenominationManager denomControl; // 0x30
		public Action onChangeScene; // 0x34

		// Properties
		// public DenominationManager DenomControl { get; }

		// Methods

		// RVA: 0xBFD62C Offset: 0xBFD62C VA: 0xBFD62C
		// public DenominationManager get_DenomControl() { }

		// // RVA: 0xBFD634 Offset: 0xBFD634 VA: 0xBFD634 Slot: 9
		// protected override void DoAwake() { }

		// // RVA: 0xBFD848 Offset: 0xBFD848 VA: 0xBFD848 Slot: 12
		// protected override bool DoUpdateEnter() { }

		// // RVA: 0xBFD978 Offset: 0xBFD978 VA: 0xBFD978 Slot: 14
		// protected override bool DoUpdateLeave() { }

		// // RVA: 0xBFDB40 Offset: 0xBFDB40 VA: 0xBFDB40
		// public void GotoPrevScene() { }

		// // RVA: 0xBFDCE0 Offset: 0xBFDCE0 VA: 0xBFDCE0
		// public void GotoMenuScene() { }

		// // RVA: 0xBFDD74 Offset: 0xBFDD74 VA: 0xBFDD74
		// public void GotoTitleScene() { }

		// // RVA: 0xBFDE98 Offset: 0xBFDE98 VA: 0xBFDE98
		// public bool IsDebugFlow() { }

		// // RVA: 0xBFDEA0 Offset: 0xBFDEA0 VA: 0xBFDEA0
		public bool IsEnableTransionResult()
		{
			UnityEngine.Debug.LogError("TODO");
			return false;
		}

		// // RVA: 0xBFDEA8 Offset: 0xBFDEA8 VA: 0xBFDEA8
		// public void .ctor() { }
	}
}
