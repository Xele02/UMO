using UnityEngine;
using System.Collections;

namespace XeApp.Game.Common
{
	public abstract class SoundPlayerBase : MonoBehaviour
	{
		private Coroutine fadeCoroutine; // 0xC
		private IEnumerator changeVolume; // 0x10
		// [CompilerGeneratedAttribute] // RVA: 0x687BF0 Offset: 0x687BF0 VA: 0x687BF0
		// private CriAtomExPlayback <playBack>k__BackingField; // 0x14
		public bool requestDecCacheClear; // 0x18
		public bool isPlayedSecureMusic; // 0x19

		public abstract CriAtomSource source { get; set; }
		// protected CriAtomExPlayback playBack { get; set; }
		public int millisecLength { get; set; }
		public float secLength { get; set; }
		public int millisecTime { get; set; }
		public float secTime { get; set; }
		public bool isPlaying { get; set; }
		public bool isFading { get; set; }
		public string cueSheetName { get; }

		// // Methods

		// // RVA: -1 Offset: -1 Slot: 4
		//public abstract CriAtomSource get_source();

		// // RVA: -1 Offset: -1 Slot: 5
		// public abstract void set_source(CriAtomSource value);

		// [CompilerGeneratedAttribute] // RVA: 0x73B148 Offset: 0x73B148 VA: 0x73B148
		// // RVA: 0x1397D44 Offset: 0x1397D44 VA: 0x1397D44
		// protected CriAtomExPlayback get_playBack() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73B158 Offset: 0x73B158 VA: 0x73B158
		// // RVA: 0x1397D4C Offset: 0x1397D4C VA: 0x1397D4C
		// private void set_playBack(CriAtomExPlayback value) { }

		// // RVA: 0x1397D54 Offset: 0x1397D54 VA: 0x1397D54
		// private void Awake() { }

		// // RVA: 0x1397D64 Offset: 0x1397D64 VA: 0x1397D64 Slot: 6
		// protected virtual void OnAwake() { }

		// // RVA: 0x1397E00 Offset: 0x1397E00 VA: 0x1397E00
		// public int get_millisecLength() { }

		// // RVA: 0x1397FE0 Offset: 0x1397FE0 VA: 0x1397FE0
		// private void set_millisecLength(int value) { }

		// // RVA: 0x1397FE4 Offset: 0x1397FE4 VA: 0x1397FE4
		// public float get_secLength() { }

		// // RVA: 0x139800C Offset: 0x139800C VA: 0x139800C
		// private void set_secLength(float value) { }

		// // RVA: 0x1398010 Offset: 0x1398010 VA: 0x1398010
		// public int get_millisecTime() { }

		// // RVA: 0x139804C Offset: 0x139804C VA: 0x139804C
		// private void set_millisecTime(int value) { }

		// // RVA: 0x1398050 Offset: 0x1398050 VA: 0x1398050
		// public float get_secTime() { }

		// // RVA: 0x1398078 Offset: 0x1398078 VA: 0x1398078
		// private void set_secTime(float value) { }

		// // RVA: 0x1388C94 Offset: 0x1388C94 VA: 0x1388C94
		// public bool get_isPlaying() { }

		// // RVA: 0x139807C Offset: 0x139807C VA: 0x139807C
		// private void set_isPlaying(bool value) { }

		// // RVA: 0x1398080 Offset: 0x1398080 VA: 0x1398080
		// public bool get_isFading() { }

		// // RVA: 0x1398090 Offset: 0x1398090 VA: 0x1398090
		// private void set_isFading(bool value) { }

		// // RVA: 0x1397434 Offset: 0x1397434 VA: 0x1397434
		// public string get_cueSheetName() { }

		// // RVA: 0x138F894 Offset: 0x138F894 VA: 0x138F894
		// public bool RequestChangeCueSheet(string cueSheetName, UnityAction onEndCallback) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73B168 Offset: 0x73B168 VA: 0x73B168
		// // RVA: 0x1398094 Offset: 0x1398094 VA: 0x1398094
		// private IEnumerator Co_InstallProcess(string cueSheetName, UnityAction onEndCallback) { }

		// // RVA: 0x1398154 Offset: 0x1398154 VA: 0x1398154
		// public void ChangeCueSheet(string cueSheetName) { }

		// // RVA: 0x1388CCC Offset: 0x1388CCC VA: 0x1388CCC
		// public bool RemoveCueSheet() { }

		// // RVA: 0x138FF6C Offset: 0x138FF6C VA: 0x138FF6C
		// protected bool PlayCue(string cueName) { }

		// // RVA: 0x13987A4 Offset: 0x13987A4 VA: 0x13987A4
		// protected bool PlayCue(int cueId) { }

		// // RVA: 0x1390060 Offset: 0x1390060 VA: 0x1390060
		// protected bool StopCue() { }

		// // RVA: 0x1398898 Offset: 0x1398898 VA: 0x1398898
		// protected bool StopCue(bool ignoresReleaseTime) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73B1E0 Offset: 0x73B1E0 VA: 0x73B1E0
		// // RVA: 0x13989A8 Offset: 0x13989A8 VA: 0x13989A8
		// private IEnumerator Co_ChangeVolume(float sec, float targetVol) { }

		// // RVA: 0x1398A98 Offset: 0x1398A98 VA: 0x1398A98
		// protected void FadeOut(float sec, Action onStop) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73B258 Offset: 0x73B258 VA: 0x73B258
		// // RVA: 0x1398B3C Offset: 0x1398B3C VA: 0x1398B3C
		// private IEnumerator Co_FadeOut(float sec, Action onStop) { }

		// // RVA: 0x1398C28 Offset: 0x1398C28 VA: 0x1398C28
		// protected void ChangeVolume(float sec, float targetVol, Action onEnd) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73B2D0 Offset: 0x73B2D0 VA: 0x73B2D0
		// // RVA: 0x1398CA4 Offset: 0x1398CA4 VA: 0x1398CA4
		// protected IEnumerator Co_ChangeVolume(float sec, float targetVol, Action onEnd) { }

		// // RVA: 0x1398DAC Offset: 0x1398DAC VA: 0x1398DAC
		// protected void .ctor() { }
	}
}
