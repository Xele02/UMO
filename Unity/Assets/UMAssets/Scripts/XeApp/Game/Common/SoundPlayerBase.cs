using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;
using XeSys;
using CriWare;

namespace XeApp.Game.Common
{
	public abstract class SoundPlayerBase : MonoBehaviour
	{
		private Coroutine fadeCoroutine; // 0xC
		private IEnumerator changeVolume; // 0x10
		public bool requestDecCacheClear; // 0x18
		public bool isPlayedSecureMusic; // 0x19

		public abstract CriAtomSource source { get; set; } // get Slot: 4 set  Slot: 5
		protected CriAtomExPlayback playBack { get; private set; } // 0x14
		public int millisecLength { get {
			//0x1397E00
			int res = 0;
			if(source != null)
			{
				CriAtomEx.CueInfo info;
				GameManager.Instance.criAtom.GetCueSheetInternal(source.cueSheet).acb.GetCueInfo(source.cueName, out info);
				res = (int)info.length;
			}
			return res;
		} private set {
			//0x1397FE0
		} }  
		// public float secLength { get; private set; } 0x1397FE4 0x139800C
		// public int millisecTime { get; private set; } 0x1398010 0x139804C
		// public float secTime { get; private set; } 0x1398050 0x1398078
		// public bool isPlaying { get; private set; } 0x1388C94 0x139807C
		// public bool isFading { get; private set; } 0x1398080 0x1398090
		// public string cueSheetName { get; } 0x1397434

		// // RVA: 0x1397D54 Offset: 0x1397D54 VA: 0x1397D54
		private void Awake()
		{
			OnAwake();
		}

		// // RVA: 0x1397D64 Offset: 0x1397D64 VA: 0x1397D64 Slot: 6
		protected virtual void OnAwake() { }

		// // RVA: 0x138F894 Offset: 0x138F894 VA: 0x138F894
		public bool RequestChangeCueSheet(string cueSheetName, UnityAction onEndCallback)
		{
			if(source == null)
			{
				if (onEndCallback != null)
					onEndCallback();
				return false;
			}
			if(source.cueSheet == cueSheetName)
			{
				if(CriAtom.GetCueSheet(cueSheetName) != null)
				{
					if (onEndCallback != null)
						onEndCallback();
					return false;
				}
			}
			if(SoundResource.InstallCueSheet(cueSheetName))
			{
				StartCoroutine(Co_InstallProcess(cueSheetName, onEndCallback));
				return true;
			}
			ChangeCueSheet(cueSheetName);
			if (onEndCallback != null)
				onEndCallback();
			return true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73B168 Offset: 0x73B168 VA: 0x73B168
		// // RVA: 0x1398094 Offset: 0x1398094 VA: 0x1398094
		private IEnumerator Co_InstallProcess(string cueSheetName, UnityAction onEndCallback)
		{
#if UNITY_EDITOR
			bool acbAvaiable = false;
			bool awbAvaiable = false;
			FileSystemProxy.TryInstallFile(SoundResource.GetAcbPath(cueSheetName), (string newPath) =>
			{
				acbAvaiable = true;
			});
			if (SoundResource.GetAwbPath(cueSheetName) != null)
			{
				FileSystemProxy.TryInstallFile(SoundResource.GetAwbPath(cueSheetName), (string newPath) =>
				{
					awbAvaiable = true;
				});
			}
			else
			{
				awbAvaiable = true;
			}
			while (!acbAvaiable && !awbAvaiable)
				yield return null;
#endif
			//0x1395404
			yield return new WaitWhile(() =>
			{
				//0x1395364
				return KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB;
			});
			ChangeCueSheet(cueSheetName);
			if (onEndCallback != null)
				onEndCallback();
		}

		// // RVA: 0x1398154 Offset: 0x1398154 VA: 0x1398154
		public void ChangeCueSheet(string cueSheetName)
		{
			if(source != null)
			{
				if (source.cueSheet == cueSheetName && CriAtom.GetCueSheet(cueSheetName) != null)
					return;
				SoundResource.RemoveCueSheet(source.cueSheet);
				source.cueSheet = cueSheetName;
				if(!requestDecCacheClear)
				{
					if(isPlayedSecureMusic)
					{
						if(cueSheetName.Contains("cs_bgm_"))
						{
							SoundResource.DecCacheClear();
							isPlayedSecureMusic = false;
						}
					}
				}
				else
				{
					SoundResource.DecCacheClear();
					requestDecCacheClear = false;
				}
				SoundResource.AddCueSheet(source.cueSheet);
			}
		}

		// // RVA: 0x1388CCC Offset: 0x1388CCC VA: 0x1388CCC
		// public bool RemoveCueSheet() { }

		// // RVA: 0x138FF6C Offset: 0x138FF6C VA: 0x138FF6C
		protected bool PlayCue(string cueName)
		{
			if(source != null)
			{
				playBack = source.Play(cueName);
				return true;
			}
			return false;
		}

		// // RVA: 0x13987A4 Offset: 0x13987A4 VA: 0x13987A4
		// protected bool PlayCue(int cueId) { }

		// // RVA: 0x1390060 Offset: 0x1390060 VA: 0x1390060
		protected bool StopCue()
		{
			return StopCue(false);
		}

		// // RVA: 0x1398898 Offset: 0x1398898 VA: 0x1398898
		protected bool StopCue(bool ignoresReleaseTime)
		{
			if(source != null)
			{
				source.player.Stop(ignoresReleaseTime);
				return true;
			}
			return false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73B1E0 Offset: 0x73B1E0 VA: 0x73B1E0
		// // RVA: 0x13989A8 Offset: 0x13989A8 VA: 0x13989A8
		// private IEnumerator Co_ChangeVolume(float sec, float targetVol) { }

		// // RVA: 0x1398A98 Offset: 0x1398A98 VA: 0x1398A98
		// protected void FadeOut(float sec, Action onStop) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73B258 Offset: 0x73B258 VA: 0x73B258
		// // RVA: 0x1398B3C Offset: 0x1398B3C VA: 0x1398B3C
		// private IEnumerator Co_FadeOut(float sec, Action onStop) { }

		// // RVA: 0x1398C28 Offset: 0x1398C28 VA: 0x1398C28
		protected void ChangeVolume(float sec, float targetVol, Action onEnd)
		{
			if (fadeCoroutine != null)
			{
				StopCoroutine(fadeCoroutine);
				StopCoroutine(changeVolume);
			}
			fadeCoroutine = StartCoroutine(Co_ChangeVolume(sec, targetVol, onEnd));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73B2D0 Offset: 0x73B2D0 VA: 0x73B2D0
		// // RVA: 0x1398CA4 Offset: 0x1398CA4 VA: 0x1398CA4
		protected IEnumerator Co_ChangeVolume(float sec, float targetVol, Action onEnd)
		{
			float remain;
			float baseVolume;
			float rate;
			//0x1398ED0
			remain = sec;
			baseVolume = source.volume - targetVol;
			rate = 1;
			while (rate >= 0)
			{
				remain = Mathf.Max(remain - TimeWrapper.deltaTime, 0);
				rate = remain / sec;
				source.volume = targetVol + baseVolume * rate;
				yield return null;
			}
			source.volume = targetVol;
		}
	}
}
