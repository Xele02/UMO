using System;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class ConfigMenu : MonoBehaviour, IDisposable
	{
		//private bool m_loaded; // 0xC
		//private PopupTabSetting m_tabSetting; // 0x10
		//private PopupTabContents m_tabContents; // 0x14
		//private PopupConfigScrollListSetting m_settingMenu; // 0x18
		//private PopupConfigScrollListSetting m_settingRhythmView; // 0x1C
		//private PopupConfigScrollListSetting m_settingRhythmSystem; // 0x20
		//private PopupConfigScrollListSetting m_settingRhythmSimulation; // 0x24
		//private PopupConfigScrollListSetting m_settingOther; // 0x28
		//private GameObject m_loadingObject; // 0x2C
		//private Dictionary<string, int> m_bundleCounter = new Dictionary<string, int>(8); // 0x30

		//public bool IsOpen { get; private set; } // 0x34
		//public bool IsReady { get; } 0x1B5E13C
		//public bool IsLoadBundle { get; private set; } // 0x35

		//// RVA: 0x1B5D9E0 Offset: 0x1B5D9E0 VA: 0x1B5D9E0
		public static ConfigMenu Create(Transform parent)
		{
			UnityEngine.Debug.LogError("TODO Create Config");
			return null;
		}

		//// RVA: 0x1B5DB78 Offset: 0x1B5DB78 VA: 0x1B5DB78
		//public void CreateLoadingObject() { }

		//// RVA: 0x1B5E04C Offset: 0x1B5E04C VA: 0x1B5E04C
		//private void DestroyLoadingObject() { }

		//// RVA: 0x1B5DF90 Offset: 0x1B5DF90 VA: 0x1B5DF90
		//private void LoadingObjectEnable(bool enable) { }

		//// RVA: 0x1B5E124 Offset: 0x1B5E124 VA: 0x1B5E124
		public void Awake()
		{
			return;
		}

		//// RVA: 0x1B5E128 Offset: 0x1B5E128 VA: 0x1B5E128
		public void Start()
		{
			return;
		}

		//// RVA: 0x1B5DF6C Offset: 0x1B5DF6C VA: 0x1B5DF6C
		//public void LoadAssetBundle() { }

		//[IteratorStateMachineAttribute] // RVA: 0x700B8C Offset: 0x700B8C VA: 0x700B8C
		//// RVA: 0x1B5E154 Offset: 0x1B5E154 VA: 0x1B5E154
		//private IEnumerator LoadUnionAssetBundle() { }

		//// RVA: 0x1B5E200 Offset: 0x1B5E200 VA: 0x1B5E200
		//public void UnloadAssetBundle() { }

		//[IteratorStateMachineAttribute] // RVA: 0x700C04 Offset: 0x700C04 VA: 0x700C04
		//// RVA: 0x1B5E4A4 Offset: 0x1B5E4A4 VA: 0x1B5E4A4
		//private IEnumerator LoadLayoutAssetBundle(PopupSetting setting, Action<GameObject> callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x700C7C Offset: 0x700C7C VA: 0x700C7C
		//// RVA: 0x1B5E584 Offset: 0x1B5E584 VA: 0x1B5E584
		//private IEnumerator LoadLayoutAssetBundle(string bundleName, string assetName, Action<GameObject> callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x700CF4 Offset: 0x700CF4 VA: 0x700CF4
		//// RVA: 0x1B5E67C Offset: 0x1B5E67C VA: 0x1B5E67C
		//private IEnumerator LoadLayout(ConfigMenu.eType etype) { }

		//[IteratorStateMachineAttribute] // RVA: 0x700D6C Offset: 0x700D6C VA: 0x700D6C
		//// RVA: 0x1B5E744 Offset: 0x1B5E744 VA: 0x1B5E744
		//private IEnumerator LoadLayoutInner(ConfigMenu.eType etype) { }

		//[IteratorStateMachineAttribute] // RVA: 0x700DE4 Offset: 0x700DE4 VA: 0x700DE4
		//// RVA: 0x1B5E80C Offset: 0x1B5E80C VA: 0x1B5E80C
		//private IEnumerator LoadLayoutTab(ConfigMenu.eType etype) { }

		//[IteratorStateMachineAttribute] // RVA: 0x700E5C Offset: 0x700E5C VA: 0x700E5C
		//// RVA: 0x1B5E8D4 Offset: 0x1B5E8D4 VA: 0x1B5E8D4
		//private IEnumerator SetupTabWindow(ConfigMenu.eType etype, PopupTabButton.ButtonLabel[] tabs, UnityAction showEndCb, UnityAction<PopupButton.ButtonLabel> finishCb) { }

		//[IteratorStateMachineAttribute] // RVA: 0x700ED4 Offset: 0x700ED4 VA: 0x700ED4
		//// RVA: 0x1B5E9EC Offset: 0x1B5E9EC VA: 0x1B5E9EC
		//private IEnumerator ReShowTabWindow(ConfigMenu.eType etype, PopupTabButton.ButtonLabel[] tabs, UnityAction showEndCb, UnityAction<PopupButton.ButtonLabel> finishCb) { }

		//[IteratorStateMachineAttribute] // RVA: 0x700F4C Offset: 0x700F4C VA: 0x700F4C
		//// RVA: 0x1B5EB00 Offset: 0x1B5EB00 VA: 0x1B5EB00
		//private IEnumerator SetupWindowSimulation(UnityAction showEndCb, UnityAction<PopupButton.ButtonLabel> finishCb) { }

		//[IteratorStateMachineAttribute] // RVA: 0x700FC4 Offset: 0x700FC4 VA: 0x700FC4
		//// RVA: 0x1B5EBE0 Offset: 0x1B5EBE0 VA: 0x1B5EBE0
		//private IEnumerator ReShowWindowSimulation(UnityAction showEndCb, UnityAction<PopupButton.ButtonLabel> finishCb) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70103C Offset: 0x70103C VA: 0x70103C
		//// RVA: 0x1B5ECC0 Offset: 0x1B5ECC0 VA: 0x1B5ECC0
		//private IEnumerator Co_ConfigSave(Action<bool> repopCallback) { }

		//// RVA: 0x1B5ED6C Offset: 0x1B5ED6C VA: 0x1B5ED6C
		//public void ShowPopupConfig(UnityAction showEndCb, UnityAction<PopupButton.ButtonLabel> finishCb) { }

		//// RVA: 0x1B5EE28 Offset: 0x1B5EE28 VA: 0x1B5EE28
		//public void ShowPopupRhythm(UnityAction showEndCb, UnityAction<PopupButton.ButtonLabel> finishCb) { }

		//// RVA: 0x1B5EFA4 Offset: 0x1B5EFA4 VA: 0x1B5EFA4 Slot: 4
		public void Dispose()
		{
			UnityEngine.Debug.LogError("TODO Dispose ConfigMenu");
		}

		//[CompilerGeneratedAttribute] // RVA: 0x7010B4 Offset: 0x7010B4 VA: 0x7010B4
		//// RVA: 0x1B5F374 Offset: 0x1B5F374 VA: 0x1B5F374
		//private void <LoadLayoutInner>b__33_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x7010C4 Offset: 0x7010C4 VA: 0x7010C4
		//// RVA: 0x1B5F450 Offset: 0x1B5F450 VA: 0x1B5F450
		//private void <LoadLayoutInner>b__33_1(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x7010D4 Offset: 0x7010D4 VA: 0x7010D4
		//// RVA: 0x1B5F52C Offset: 0x1B5F52C VA: 0x1B5F52C
		//private void <LoadLayoutInner>b__33_2(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x7010E4 Offset: 0x7010E4 VA: 0x7010E4
		//// RVA: 0x1B5F608 Offset: 0x1B5F608 VA: 0x1B5F608
		//private void <LoadLayoutInner>b__33_3(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x7010F4 Offset: 0x7010F4 VA: 0x7010F4
		//// RVA: 0x1B5F6E4 Offset: 0x1B5F6E4 VA: 0x1B5F6E4
		//private void <LoadLayoutInner>b__33_4(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x701104 Offset: 0x701104 VA: 0x701104
		//// RVA: 0x1B5F7C0 Offset: 0x1B5F7C0 VA: 0x1B5F7C0
		//private void <LoadLayoutInner>b__33_5(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x701114 Offset: 0x701114 VA: 0x701114
		//// RVA: 0x1B5F84C Offset: 0x1B5F84C VA: 0x1B5F84C
		//private void <LoadLayoutInner>b__33_6(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x701124 Offset: 0x701124 VA: 0x701124
		//// RVA: 0x1B5F8D8 Offset: 0x1B5F8D8 VA: 0x1B5F8D8
		//private void <LoadLayoutInner>b__33_7(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x701134 Offset: 0x701134 VA: 0x701134
		//// RVA: 0x1B5F964 Offset: 0x1B5F964 VA: 0x1B5F964
		//private void <LoadLayoutInner>b__33_8(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x701144 Offset: 0x701144 VA: 0x701144
		//// RVA: 0x1B5F9F0 Offset: 0x1B5F9F0 VA: 0x1B5F9F0
		//private void <LoadLayoutInner>b__33_9(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x701154 Offset: 0x701154 VA: 0x701154
		//// RVA: 0x1B5FA7C Offset: 0x1B5FA7C VA: 0x1B5FA7C
		//private void <LoadLayoutInner>b__33_10(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x701164 Offset: 0x701164 VA: 0x701164
		//// RVA: 0x1B5FB08 Offset: 0x1B5FB08 VA: 0x1B5FB08
		//private void <LoadLayoutInner>b__33_11(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x701174 Offset: 0x701174 VA: 0x701174
		//// RVA: 0x1B5FB94 Offset: 0x1B5FB94 VA: 0x1B5FB94
		//private void <LoadLayoutInner>b__33_12(GameObject instance) { }
	}
}
