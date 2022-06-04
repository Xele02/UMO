using System;

namespace XeApp.Core
{
	public abstract class SubSceneBase
	{
		// Fields
		// [CompilerGeneratedAttribute] // RVA: 0x68F69C Offset: 0x68F69C VA: 0x68F69C
		// private Action <update>k__BackingField; // 0x8
		// [CompilerGeneratedAttribute] // RVA: 0x68F6AC Offset: 0x68F6AC VA: 0x68F6AC
		// private SubSceneBase <nextScene>k__BackingField; // 0xC
		// [CompilerGeneratedAttribute] // RVA: 0x68F6BC Offset: 0x68F6BC VA: 0x68F6BC
		// private MainSceneBase <mainScene>k__BackingField; // 0x10
		// [CompilerGeneratedAttribute] // RVA: 0x68F6CC Offset: 0x68F6CC VA: 0x68F6CC
		// private bool <isEnd>k__BackingField; // 0x14

		// Properties
		protected abstract bool useFadeIn { get; }
		protected abstract bool useFadeOut { get; }
		public Action update { get; set; }
		public SubSceneBase nextScene { get; set; }
		protected MainSceneBase mainScene { get; set; }
		public bool isEnd { get; set; }

		// Methods

		// // RVA: -1 Offset: -1 Slot: 9
		// protected abstract bool get_useFadeIn();

		// // RVA: -1 Offset: -1 Slot: 10
		// protected abstract bool get_useFadeOut();

		// [CompilerGeneratedAttribute] // RVA: 0x7487A0 Offset: 0x7487A0 VA: 0x7487A0
		// // RVA: 0x1D7676C Offset: 0x1D7676C VA: 0x1D7676C
		// public Action get_update() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7487B0 Offset: 0x7487B0 VA: 0x7487B0
		// // RVA: 0x1D76774 Offset: 0x1D76774 VA: 0x1D76774
		// private void set_update(Action value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x7487C0 Offset: 0x7487C0 VA: 0x7487C0
		// // RVA: 0x1D73B28 Offset: 0x1D73B28 VA: 0x1D73B28
		// public SubSceneBase get_nextScene() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7487D0 Offset: 0x7487D0 VA: 0x7487D0
		// // RVA: 0x1D7677C Offset: 0x1D7677C VA: 0x1D7677C
		// private void set_nextScene(SubSceneBase value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x7487E0 Offset: 0x7487E0 VA: 0x7487E0
		// // RVA: 0x1D76784 Offset: 0x1D76784 VA: 0x1D76784
		// protected MainSceneBase get_mainScene() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7487F0 Offset: 0x7487F0 VA: 0x7487F0
		// // RVA: 0x1D7678C Offset: 0x1D7678C VA: 0x1D7678C
		// private void set_mainScene(MainSceneBase value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x748800 Offset: 0x748800 VA: 0x748800
		// // RVA: 0x1D73B20 Offset: 0x1D73B20 VA: 0x1D73B20
		// public bool get_isEnd() { }

		// [CompilerGeneratedAttribute] // RVA: 0x748810 Offset: 0x748810 VA: 0x748810
		// // RVA: 0x1D76794 Offset: 0x1D76794 VA: 0x1D76794
		// private void set_isEnd(bool value) { }

		// // RVA: 0x1D7679C Offset: 0x1D7679C VA: 0x1D7679C
		// private void .ctor() { }

		// // RVA: 0x1D767C0 Offset: 0x1D767C0 VA: 0x1D767C0
		// public void .ctor(MainSceneBase mainScene) { }
		public SubSceneBase(MainSceneBase mainScene)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x1D73B30 Offset: 0x1D73B30 VA: 0x1D73B30
		public void Enter(SubSceneBase prevScene)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x1D73F18 Offset: 0x1D73F18 VA: 0x1D73F18
		// public void Leave() { }

		// // RVA: 0x1D73AF4 Offset: 0x1D73AF4 VA: 0x1D73AF4
		public void Update()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x1D74088 Offset: 0x1D74088 VA: 0x1D74088
		// public void NextSubScene(SubSceneBase next) { }

		// // RVA: 0x1D767E8 Offset: 0x1D767E8 VA: 0x1D767E8 Slot: 4
		// public void UpdateEnter() { }

		// // RVA: 0x1D76928 Offset: 0x1D76928 VA: 0x1D76928 Slot: 5
		// public void UpdateEnterFadeIn() { }

		// // RVA: 0x1D769F4 Offset: 0x1D769F4 VA: 0x1D769F4 Slot: 6
		// public void UpdateMain() { }

		// // RVA: 0x1D76A04 Offset: 0x1D76A04 VA: 0x1D76A04 Slot: 7
		// public void UpdateLeaveFadeOut() { }

		// // RVA: 0x1D76AD0 Offset: 0x1D76AD0 VA: 0x1D76AD0 Slot: 8
		// public void UpdateLeave() { }

		// // RVA: -1 Offset: -1 Slot: 11
		// protected abstract bool DoUpdateEnter();

		// // RVA: -1 Offset: -1 Slot: 12
		// protected abstract void DoUpdateMain();

		// // RVA: -1 Offset: -1 Slot: 13
		// protected abstract bool DoUpdateLeave();

	}
}
