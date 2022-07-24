using System;
using UnityEngine;

namespace CriWare
{

	public class CriAtomServer : CriMonoBehaviour
	{
		private static CriAtomServer _instance = null; // 0x0
	#if UNITY_EDITOR
		private bool isApplicationPaused = false;
		private bool isEditorPaused = false;
	#endif
		public Action<bool> onApplicationPausePreProcess; // 0x1C
		public Action<bool> onApplicationPausePostProcess; // 0x20
		public static bool KeepPlayingSoundOnPause = true; // 0x4

		public static CriAtomServer instance { 
			get {
				CreateInstance();
				return _instance;
			}
		} //0x28B5140

		// // RVA: 0x28B3254 Offset: 0x28B3254 VA: 0x28B3254
		public static void CreateInstance()
		{
			if (_instance == null) {
				CriWare.Common.managerObject.AddComponent<CriAtomServer>();
			}
		}

		// // RVA: 0x28B3484 Offset: 0x28B3484 VA: 0x28B3484
		public static void DestroyInstance()
		{
			if (_instance != null) {
				UnityEngine.GameObject.Destroy(_instance);
			}
		}

		// // RVA: 0x28B51D0 Offset: 0x28B51D0 VA: 0x28B51D0
		private void Awake()
		{
			if (_instance == null) {
				_instance = this;
			} else {
				GameObject.Destroy(this);
			}
		}

		// // RVA: 0x28B5324 Offset: 0x28B5324 VA: 0x28B5324 Slot: 4
		protected override void OnEnable()
		{
			base.OnEnable();
	#if UNITY_EDITOR
	#if UNITY_2017_2_OR_NEWER
			UnityEditor.EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
			UnityEditor.EditorApplication.pauseStateChanged += OnPauseStateChanged;
	#else
			UnityEditor.EditorApplication.playmodeStateChanged += OnPlaymodeStateChange;
	#endif
	#endif
		}

		// // RVA: 0x28B532C Offset: 0x28B532C VA: 0x28B532C Slot: 5
		protected override void OnDisable()
		{
			base.OnDisable();
	#if UNITY_EDITOR
	#if UNITY_2017_2_OR_NEWER
			UnityEditor.EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
			UnityEditor.EditorApplication.pauseStateChanged -= OnPauseStateChanged;
	#else
			UnityEditor.EditorApplication.playmodeStateChanged -= OnPlaymodeStateChange;
	#endif
	#endif

			if (_instance == this) {
				_instance = null;
			}
		}

		// // RVA: 0x28B5454 Offset: 0x28B5454 VA: 0x28B5454 Slot: 6
		public override void CriInternalUpdate()
		{
			return;
		}

		// // RVA: 0x28B5458 Offset: 0x28B5458 VA: 0x28B5458 Slot: 7
		public override void CriInternalLateUpdate()
		{
			return;
		}

	#if UNITY_EDITOR
		private void OnPlaymodeStateChange()
		{
			bool paused = UnityEditor.EditorApplication.isPaused;
			if (!isApplicationPaused && isEditorPaused != paused) {
				ProcessApplicationPause(paused);
				isEditorPaused = paused;
			}
		}

	#if UNITY_2017_2_OR_NEWER
		private void OnPlayModeStateChanged(UnityEditor.PlayModeStateChange state)
		{
			OnPlaymodeStateChange();
		}
		private void OnPauseStateChanged(UnityEditor.PauseState state)
		{
			OnPlaymodeStateChange();
		}
	#endif

	#endif

		// // RVA: 0x28B545C Offset: 0x28B545C VA: 0x28B545C
		private void OnApplicationPause(bool appPause)
		{
	#if UNITY_EDITOR
			if (!isEditorPaused && isApplicationPaused != appPause) {
				ProcessApplicationPause(appPause);
				isApplicationPaused = appPause;
			}
	#else
			ProcessApplicationPause(appPause);
	#endif
		}

		// // RVA: 0x28B5460 Offset: 0x28B5460 VA: 0x28B5460
		private void ProcessApplicationPause(bool appPause)
		{
			if (onApplicationPausePreProcess != null) {
				onApplicationPausePreProcess(appPause);
			}
	#if !UNITY_EDITOR && UNITY_IOS
			if(appPause == false) {
				CriAtomPlugin.CallOnApplicationResume_IOS();
			}
	#endif

	#if UNITY_STANDALONE || UNITY_EDITOR
			if (!KeepPlayingSoundOnPause) {
				CriAtomPlugin.Pause(appPause);
			}
	#else
	#if !UNITY_IOS
			CriAtomPlugin.Pause(appPause);
	#endif
	#endif
			if (onApplicationPausePostProcess != null) {
				onApplicationPausePostProcess(appPause);
			}
		}
	}
}