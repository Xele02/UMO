using UnityEngine.Events;

namespace XeApp.Game.Common
{
	public class BgmPlayer : SoundPlayerBase
	{
		public static readonly int MENU_BGM_ID_BASE; // 0x0
		public static readonly int MENU_TRIAL_ID_BASE; // 0x4
		public static readonly int ADJUST_BGM; // 0x8
		public static readonly int PROLOGUE_BGM; // 0xC
		public static readonly int AR_BGM_ID_BASE; // 0x10
		public static readonly int MINIGAME_BGM_ID_BASE; // 0x14
		// private CriAtomBgmSource bgmSource; // 0x1C
		// [CompilerGeneratedAttribute] // RVA: 0x687A40 Offset: 0x687A40 VA: 0x687A40
		// private int <currentBgmId>k__BackingField; // 0x20

		// // Properties
		public override CriAtomSource source { get; set; }
		public int currentBgmId { get; set; }
		public long timeSyncedWithAudio { get; set; }

		// // Methods

		// // RVA: 0xE60AA4 Offset: 0xE60AA4 VA: 0xE60AA4
		// public static void ConvertBgmIdToCueSheetName(int bgmId, ref string cueSheetName) { }

		// // RVA: 0xE60EC0 Offset: 0xE60EC0 VA: 0xE60EC0
		// public static void ConvertBgmIdToCueName(int bgmId, ref string cueName) { }

		// // RVA: 0xE61334 Offset: 0xE61334 VA: 0xE61334 Slot: 4
		/*public override CriAtomSource get_source()
		{
			UnityEngine.Debug.LogError("TODO");
			return null;
		}*/

		// // RVA: 0xE6133C Offset: 0xE6133C VA: 0xE6133C Slot: 5
		// public override void set_source(CriAtomSource value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AA74 Offset: 0x73AA74 VA: 0x73AA74
		// // RVA: 0xE61340 Offset: 0xE61340 VA: 0xE61340
		// public int get_currentBgmId() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AA84 Offset: 0x73AA84 VA: 0x73AA84
		// // RVA: 0xE61348 Offset: 0xE61348 VA: 0xE61348
		// private void set_currentBgmId(int value) { }

		// // RVA: 0xE61350 Offset: 0xE61350 VA: 0xE61350
		// public long get_timeSyncedWithAudio() { }

		// // RVA: 0xE6137C Offset: 0xE6137C VA: 0xE6137C
		// private void set_timeSyncedWithAudio(long value) { }

		// // RVA: 0xE61380 Offset: 0xE61380 VA: 0xE61380 Slot: 6
		// protected override void OnAwake() { }

		// // RVA: 0xE61410 Offset: 0xE61410 VA: 0xE61410
		public bool RequestChangeCueSheet(int wavId, UnityAction onEndCallback)
		{
			UnityEngine.Debug.LogError("TODO");
			return false;
		}

		// // RVA: 0xE614D4 Offset: 0xE614D4 VA: 0xE614D4
		public void ChangeMusicCue(int bgmId)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xE615C0 Offset: 0xE615C0 VA: 0xE615C0
		public void Play(int bgmId, float volume = 1)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xE61848 Offset: 0xE61848 VA: 0xE61848
		// public void ContinuousPlay(int bgmId, float volume = 1) { }

		// // RVA: 0xE52268 Offset: 0xE52268 VA: 0xE52268
		// public void Stop() { }

		// // RVA: 0xE61858 Offset: 0xE61858 VA: 0xE61858
		// public void FadeOut(float sec, Action onStop) { }

		// // RVA: 0xE61760 Offset: 0xE61760 VA: 0xE61760
		// public void ChangeVolume(float sec, float targetVol, Action onEnd) { }

		// // RVA: 0xE61944 Offset: 0xE61944 VA: 0xE61944
		// public void .ctor() { }

		// // RVA: 0xE6194C Offset: 0xE6194C VA: 0xE6194C
		// private static void .cctor() { }
	}
}
