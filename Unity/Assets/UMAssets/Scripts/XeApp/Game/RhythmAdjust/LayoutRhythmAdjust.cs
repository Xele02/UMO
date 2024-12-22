using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using XeApp.Core;
using XeSys.Gfx;

namespace XeApp.Game.RhythmAdjust
{
	public class LayoutRhythmAdjust : MonoBehaviour
	{
		public enum ModeType
		{
			NONE = -1,
			CHECK = 0,
			ADJUST = 1,
			NUM = 2,
			DEFAULT = 1,
		}

		// Fields
		private LayoutRhythmAdjustWindow m_LayoutWindow; // 0xC
		private LayoutRhythmAdjustBalloon m_LayoutBalloon; // 0x10
		private LayoutRhythmAdjustTutorialConfirmWindow m_LayoutConfirmWindow; // 0x14
		private ModeType m_mode = ModeType.ADJUST; // 0x18
		//[CompilerGeneratedAttribute] // RVA: 0x66291C Offset: 0x66291C VA: 0x66291C
		public UnityAction<LayoutRhythmAdjustTutorialConfirmWindow.ButtonType> ConfirmmButtonHandler; // 0x1C

		// [IteratorStateMachineAttribute] // RVA: 0x6B08E0 Offset: 0x6B08E0 VA: 0x6B08E0
		// // RVA: 0xF5A75C Offset: 0xF5A75C VA: 0xF5A75C
		public static IEnumerator Co_LoadLayout(Transform parent, bool isTutorial, Action<LayoutRhythmAdjust> onFinishLoad)
		{
			int loadCount;
			string BundleName;
			AssetBundleLoadLayoutOperationBase operation;

			//0xF5B898
			GameObject obj = null;
			loadCount = 1;
			LayoutRhythmAdjust layout = null;
			LayoutRhythmAdjustTutorialConfirmWindow layWindow = null;
			BundleName = "ly/056.xab";
			operation = AssetBundleManager.LoadLayoutAsync(BundleName, "UI_RhythmAdjust");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xF5B648
				obj = instance;
			}));
			layout = obj.GetComponent<LayoutRhythmAdjust>();
			obj.transform.SetParent(parent, false);
			if(isTutorial)
			{
				yield return null;
				operation = AssetBundleManager.LoadLayoutAsync(BundleName, "root_sel_note_adjust_pop_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0xF5B650
					obj = instance;
				}));
				obj.transform.SetParent(parent, false);
				layWindow = obj.GetComponent<LayoutRhythmAdjustTutorialConfirmWindow>();
				loadCount++;
			}
			for(int i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(BundleName, false);
			}
			yield return null;
			if(layWindow == null)
				yield return new WaitWhile(() =>
				{
					//0xF5B658
					return !layout.IsReady();
				});
			else
				yield return new WaitWhile(() =>
				{
					//0xF5B684
					return !layout.IsReady() || !layWindow.IsReady();
				});
			onFinishLoad(layout);
		}

		// // RVA: 0xF5A83C Offset: 0xF5A83C VA: 0xF5A83C
		public void Setup(int adjust_min, int adjust_max, Action cb_plus, Action cb_minus, Action<bool> cb_change_mode, Action cb_decide)
		{
			m_LayoutWindow = GetComponentInChildren<LayoutRhythmAdjustWindow>(true);
			m_LayoutBalloon = GetComponentInChildren<LayoutRhythmAdjustBalloon>(true);
			m_LayoutConfirmWindow = transform.parent.GetComponentInChildren<LayoutRhythmAdjustTutorialConfirmWindow>();
			if(m_LayoutConfirmWindow != null)
				m_LayoutConfirmWindow.ButtonHandler += LayoutConfirmWindow_ButtonHandler;
			m_LayoutWindow.Setup(adjust_min, adjust_max, cb_plus, cb_minus, (ModeType mode) =>
			{
				//0xF5B7C0
				m_LayoutBalloon.ChangeMode(mode);
				cb_change_mode(mode == ModeType.CHECK);
				m_mode = mode;

			}, cb_decide);
		}

		// // RVA: 0xF5ACE4 Offset: 0xF5ACE4 VA: 0xF5ACE4
		public void SetAdjustValue(int value)
		{
			m_LayoutWindow.SetAdjustValue(value);
		}

		// // RVA: 0xF5AE08 Offset: 0xF5AE08 VA: 0xF5AE08
		public bool IsReady()
		{
			LayoutUGUIRuntime[] runtimes = GetComponentsInChildren<LayoutUGUIRuntime>();
			for(int i = 0; i < runtimes.Length; i++)
			{
				if(!runtimes[i].IsReady)
					return false;
			}
			return true;
		}

		// // RVA: 0xF5AEE8 Offset: 0xF5AEE8 VA: 0xF5AEE8
		public void Enter(bool isTutorial)
		{
			m_LayoutWindow.Enter(isTutorial);
		}

		// // RVA: 0xF5AFB8 Offset: 0xF5AFB8 VA: 0xF5AFB8
		public void OpenWindow()
		{
			m_LayoutWindow.OpenWindow();
		}

		// // RVA: 0xF5B080 Offset: 0xF5B080 VA: 0xF5B080
		public bool IsPlayingWindow()
		{
			return m_LayoutWindow.IsPlaying();
		}

		// // RVA: 0xF5B0D4 Offset: 0xF5B0D4 VA: 0xF5B0D4
		public void CloseWindow()
		{
			m_LayoutWindow.CloseWindow();
		}

		// // RVA: 0xF5B19C Offset: 0xF5B19C VA: 0xF5B19C
		public void CloseBalloon()
		{
			m_LayoutBalloon.Leave();
		}

		// // RVA: 0xF5B264 Offset: 0xF5B264 VA: 0xF5B264
		public void ChangeMode(ModeType mode)
		{
			m_LayoutBalloon.ChangeMode(mode);
			m_LayoutWindow.ChangeMode(mode);
			m_mode = mode;
		}

		// // RVA: 0xF5B460 Offset: 0xF5B460 VA: 0xF5B460
		public ModeType GetMode()
		{
			return m_mode;
		}

		// // RVA: 0xF5B468 Offset: 0xF5B468 VA: 0xF5B468
		public void Update()
		{
			return;
		}

		// // RVA: 0xF5B46C Offset: 0xF5B46C VA: 0xF5B46C
		public void OpenConfirmWindow(UnityAction endCb)
		{
			m_LayoutConfirmWindow.Open(endCb);
		}

		// // RVA: 0xF5B4D0 Offset: 0xF5B4D0 VA: 0xF5B4D0
		public void CloseConfirmWindow(UnityAction endCb)
		{
			m_LayoutConfirmWindow.Close(endCb);
		}

		// // RVA: 0xF5B534 Offset: 0xF5B534 VA: 0xF5B534
		private void LayoutConfirmWindow_ButtonHandler(LayoutRhythmAdjustTutorialConfirmWindow.ButtonType arg0)
		{
			if(ConfirmmButtonHandler != null)
				ConfirmmButtonHandler(arg0);
		}

		// // RVA: 0xF5B538 Offset: 0xF5B538 VA: 0xF5B538
		// private void OnConfirmButton(LayoutRhythmAdjustTutorialConfirmWindow.ButtonType type) { }

		// // RVA: 0xF5B5AC Offset: 0xF5B5AC VA: 0xF5B5AC
		public void PerformClickCancel()
		{
			m_LayoutConfirmWindow.PerformClickCancel();
		}
	}
}
