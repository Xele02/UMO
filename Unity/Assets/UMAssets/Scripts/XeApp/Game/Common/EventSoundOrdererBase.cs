using CriWare;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class EventSoundOrdererBase : MonoBehaviour
	{
		protected CriAtomSource atomSource; // 0xC
		private Dictionary<int, CriAtomExPlayback> playbackIdDictionary; // 0x10
		private Dictionary<string, CriAtomExPlayback> playbackNameDictionary; // 0x14

		protected virtual int capacityForIdDictionary { get { return 8; } } //0x1C0F264
		protected virtual int capacityForNameDictionary { get { return 8; } } //0x1C0F26C

		//// RVA: 0x1C0F274 Offset: 0x1C0F274 VA: 0x1C0F274
		private void Start()
		{
			InitializeAtomSource();
			playbackIdDictionary = new Dictionary<int, CriAtomExPlayback>(capacityForIdDictionary);
			playbackNameDictionary = new Dictionary<string, CriAtomExPlayback>(capacityForNameDictionary);
		}

		//// RVA: 0x1C0F374 Offset: 0x1C0F374 VA: 0x1C0F374
		private void OnDestroy()
		{
			StopSoundAllPlayback();
		}

		//// RVA: 0x1C0F72C Offset: 0x1C0F72C VA: 0x1C0F72C Slot: 6
		public virtual void InitializeAtomSource()
		{
			return;
		}

		//// RVA: 0x1C0F730 Offset: 0x1C0F730 VA: 0x1C0F730 Slot: 7
		//public virtual void PlaySoundById(int id) { }

		//// RVA: 0x1C0F824 Offset: 0x1C0F824 VA: 0x1C0F824 Slot: 8
		public virtual void PlaySoundByName(string name)
		{
			if(atomSource != null)
			{
				playbackNameDictionary.Add(name, atomSource.Play(name));
			}
		}

		//// RVA: 0x1C0F918 Offset: 0x1C0F918 VA: 0x1C0F918 Slot: 9
		public virtual void PlaySoundByName(string name, bool lowLatency)
		{
			if (atomSource == null)
				return;
#if UNITY_ANDROID
			bool old = atomSource.androidUseLowLatencyVoicePool();
			atomSource.androidUseLowLatencyVoicePool(lowLatency);
#endif
			CriAtomExPlayback pb = atomSource.Play(name);
			playbackNameDictionary.Add(name, pb);
#if UNITY_ANDROID
			atomSource.androidUseLowLatencyVoicePool(old);
#endif
		}

		//[ObsoleteAttribute] // RVA: 0x73AAA4 Offset: 0x73AAA4 VA: 0x73AAA4
		//// RVA: 0x1C0FA7C Offset: 0x1C0FA7C VA: 0x1C0FA7C
		//public void StopSound() { }

		//// RVA: 0x1C0F378 Offset: 0x1C0F378 VA: 0x1C0F378
		public void StopSoundAllPlayback()
		{
			if(playbackIdDictionary != null)
			{
				foreach(var s in playbackIdDictionary)
				{
					s.Value.Stop(true);
				}
			}
			if(playbackNameDictionary != null)
			{
				foreach(var s in playbackNameDictionary)
				{
					s.Value.Stop(true);
				}
			}
		}

		//// RVA: 0x1C0FAA8 Offset: 0x1C0FAA8 VA: 0x1C0FAA8
		//public void StopSoundById(int id) { }

		//// RVA: 0x1C0FB80 Offset: 0x1C0FB80 VA: 0x1C0FB80
		public void StopSoundByName(string name)
		{
			if(playbackNameDictionary.ContainsKey(name))
			{
				playbackNameDictionary[name].Stop(false);
			}
		}

		//// RVA: 0x1C0FC58 Offset: 0x1C0FC58 VA: 0x1C0FC58
		//public bool IsPlayingById(int id) { }

		//// RVA: 0x1C0FD40 Offset: 0x1C0FD40 VA: 0x1C0FD40
		public bool IsPlayingByName(string name)
		{
			CriAtomExPlayback pb;
			if(playbackNameDictionary.TryGetValue(name, out pb))
			{
				return pb.GetStatus() == CriAtomExPlayback.Status.Playing;
			}
			return false;
		}

		//// RVA: 0x1C0FE28 Offset: 0x1C0FE28 VA: 0x1C0FE28
		//public void PauseSoundById(int id) { }

		//// RVA: 0x1C0FF00 Offset: 0x1C0FF00 VA: 0x1C0FF00
		public void PauseSoundByName(string name)
		{
			CriAtomExPlayback pb;
			if (playbackNameDictionary.TryGetValue(name, out pb))
			{
				pb.Pause(true);
			}
		}

		//// RVA: 0x1C0FFDC Offset: 0x1C0FFDC VA: 0x1C0FFDC
		//public void ResumeSoundById(int id) { }

		//// RVA: 0x1C100B8 Offset: 0x1C100B8 VA: 0x1C100B8
		//public void ResumeSoundByName(string name) { }
	}
}
