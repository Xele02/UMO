using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class MusicSelectSLiveButton : LayoutUGUIScriptBase
	{
		public enum Style
		{
			BasicLive = 0,
			SimulationLive = 1,
			Num = 2,
		}

		[SerializeField] // RVA: 0x673E34 Offset: 0x673E34 VA: 0x673E34
		private ActionButton button; // 0x18
		[SerializeField] // RVA: 0x673E44 Offset: 0x673E44 VA: 0x673E44
		private RawImageEx imageBg; // 0x1C
		[SerializeField] // RVA: 0x673E54 Offset: 0x673E54 VA: 0x673E54
		private RawImageEx imageFont; // 0x20
		// private Rect[] imageBgRectList = new Rect[2]; // 0x24
		// private Rect[] imageFontRectList = new Rect[2]; // 0x28
		// private AbsoluteLayout layoutRoot; // 0x2C
		// private NumberBase numUnlockRank; // 0x30
		// private bool isShow; // 0x34

		// public MusicSelectSLiveButton.Style style { get; private set; } // 0x14
		public Action<int> onClickButton { private get; set; } // 0x38

		// // RVA: 0x167DD64 Offset: 0x167DD64 VA: 0x167DD64
		// public void TryEnter() { }

		// // RVA: 0x167DE08 Offset: 0x167DE08 VA: 0x167DE08
		public void TryLeave()
		{
			UnityEngine.Debug.LogError("TODO MusicSelectSLiveButton TryLeave");
		}

		// // RVA: 0x167DD74 Offset: 0x167DD74 VA: 0x167DD74
		public void Enter()
		{
			UnityEngine.Debug.LogError("TODO MusicSelectSLiveButton Enter");
		}

		// // RVA: 0x167DE18 Offset: 0x167DE18 VA: 0x167DE18
		// public void Leave() { }

		// // RVA: 0x167DEAC Offset: 0x167DEAC VA: 0x167DEAC
		// public void Show() { }

		// // RVA: 0x167DF30 Offset: 0x167DF30 VA: 0x167DF30
		public void Hide()
		{
			UnityEngine.Debug.LogError("TODO MusicSelectSLiveButton Hide");
		}

		// // RVA: 0x167DFB4 Offset: 0x167DFB4 VA: 0x167DFB4
		public bool IsPlaying()
		{
			UnityEngine.Debug.LogError("TODO MusicSelectSLiveButton IsPlaying");
			return false;
		}

		// // RVA: 0x167DFE0 Offset: 0x167DFE0 VA: 0x167DFE0
		public void SetOptionStyle(MusicSelectSLiveButton.Style style)
		{
			UnityEngine.Debug.LogError("TODO MusicSelectSLiveButton SetOptionStyle");
		}

		// // RVA: 0x167E0EC Offset: 0x167E0EC VA: 0x167E0EC
		public void SetUnlockRank(int nowRank, int unlockRank)
		{
			UnityEngine.Debug.LogError("TODO MusicSelectSLiveButton SetUnlockRank");
		}

		// // RVA: 0x167E168 Offset: 0x167E168 VA: 0x167E168
		// private void OnClickButton() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F53BC Offset: 0x6F53BC VA: 0x6F53BC
		// // RVA: 0x167E1E0 Offset: 0x167E1E0 VA: 0x167E1E0
		// private IEnumerator Co_ChangeStyle(MusicSelectSLiveButton.Style style) { }

		// // RVA: 0x167E2A8 Offset: 0x167E2A8 VA: 0x167E2A8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			UnityEngine.Debug.LogError("TODO InitializeFromLayout MusicSelectSLiveButton");
			return true;
		}
	}
}
