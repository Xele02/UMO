using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutPopupUnlockController : IDisposable
	{
		private List<IEnumerator> m_mainUpdate = new List<IEnumerator>(8); // 0x14
		private PopupUnlock.UnlockInfo m_info; // 0x1C
		private string[] m_bundleNames = new string[1] { "ly/047.xab" }; // 0x20
		private Dictionary<string, int> m_bundleCounter = new Dictionary<string, int>(8); // 0x24

		public bool IsClosed { get; private set; } // 0x8
		public bool IsOpen { get; private set; } // 0x9
		public GameObject Parent { get; set; } // 0xC
		public GameObject CanvasParent { get; set; } // 0x10
		public LayoutPopupUnlockMusicDirection MusicDirection { get; private set; } // 0x18
		public bool IsLoadBundle { get; private set; } // 0x28

		// // RVA: 0x178A2C8 Offset: 0x178A2C8 VA: 0x178A2C8
		public void Setup()
		{
			CanvasParent = GameObject.Find("Canvas-Popup");
		}

		// // RVA: 0x178A330 Offset: 0x178A330 VA: 0x178A330
		// public void SetStatus(PopupUnlock.UnlockInfo info) { }

		// // RVA: 0x178A360 Offset: 0x178A360 VA: 0x178A360
		// public void Reset() { }

		// // RVA: 0x178A3D8 Offset: 0x178A3D8 VA: 0x178A3D8
		// public void Update() { }

		// // RVA: 0x178A584 Offset: 0x178A584 VA: 0x178A584
		// public void Show() { }

		// [IteratorStateMachineAttribute] // RVA: 0x7040D4 Offset: 0x7040D4 VA: 0x7040D4
		// // RVA: 0x178A620 Offset: 0x178A620 VA: 0x178A620
		// private IEnumerator MainPhase() { }

		// [IteratorStateMachineAttribute] // RVA: 0x70414C Offset: 0x70414C VA: 0x70414C
		// // RVA: 0x178A6CC Offset: 0x178A6CC VA: 0x178A6CC
		// private IEnumerator MusicUnlockPhase() { }

		// [IteratorStateMachineAttribute] // RVA: 0x7041C4 Offset: 0x7041C4 VA: 0x7041C4
		// // RVA: 0x178A778 Offset: 0x178A778 VA: 0x178A778
		// private IEnumerator StageUnlockPhase() { }

		// [IteratorStateMachineAttribute] // RVA: 0x70423C Offset: 0x70423C VA: 0x70423C
		// // RVA: 0x178A80C Offset: 0x178A80C VA: 0x178A80C
		// private IEnumerator DivaNotifyPhase() { }

		// [IteratorStateMachineAttribute] // RVA: 0x7042B4 Offset: 0x7042B4 VA: 0x7042B4
		// // RVA: 0x178A8A0 Offset: 0x178A8A0 VA: 0x178A8A0
		// private IEnumerator DivaUnlockPhase() { }

		// // RVA: 0x178A934 Offset: 0x178A934 VA: 0x178A934 Slot: 4
		public void Dispose() { }

		// [IteratorStateMachineAttribute] // RVA: 0x70432C Offset: 0x70432C VA: 0x70432C
		// // RVA: 0x178AC90 Offset: 0x178AC90 VA: 0x178AC90
		// public IEnumerator LoadLayoutMusic(Action callback) { }

		// [IteratorStateMachineAttribute] // RVA: 0x7043A4 Offset: 0x7043A4 VA: 0x7043A4
		// // RVA: 0x178AD58 Offset: 0x178AD58 VA: 0x178AD58
		// private IEnumerator LoadLayout(string bundleName, string assetName, Action<GameObject> callback) { }

		// // RVA: 0x178AE60 Offset: 0x178AE60 VA: 0x178AE60
		// private void AddBundleCounter(string bundleName) { }

		// // RVA: 0x178AF74 Offset: 0x178AF74 VA: 0x178AF74
		// public void LoadAssetBundle() { }

		// [IteratorStateMachineAttribute] // RVA: 0x70443C Offset: 0x70443C VA: 0x70443C
		// // RVA: 0x178B02C Offset: 0x178B02C VA: 0x178B02C
		// private IEnumerator UnionBundle() { }

		// // RVA: 0x178AA34 Offset: 0x178AA34 VA: 0x178AA34
		// public void UnloadAssetBundle() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7044B4 Offset: 0x7044B4 VA: 0x7044B4
		// // RVA: 0x178B23C Offset: 0x178B23C VA: 0x178B23C
		// private void <LoadLayoutMusic>b__33_0(GameObject instance) { }
	}
}
