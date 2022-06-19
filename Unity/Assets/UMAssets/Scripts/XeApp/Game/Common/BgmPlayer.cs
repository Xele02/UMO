using UnityEngine.Events;

namespace XeApp.Game.Common
{
	public class BgmPlayer : SoundPlayerBase
	{
		public static readonly int MENU_BGM_ID_BASE = 1000; // 0x0
		public static readonly int MENU_TRIAL_ID_BASE = 2000; // 0x4
		public static readonly int ADJUST_BGM = 3000; // 0x8
		public static readonly int PROLOGUE_BGM = 4000; // 0xC
		public static readonly int AR_BGM_ID_BASE = 5000; // 0x10
		public static readonly int MINIGAME_BGM_ID_BASE = 6000; // 0x14
		private CriAtomBgmSource bgmSource; // 0x1C

		public override CriAtomSource source { get { return bgmSource; } set { return; } } //0xE61334 0xE6133C
		public int currentBgmId { get; private set; } // 0x20
		// public long timeSyncedWithAudio { get; private set; } 0xE61350 0xE6137C

		// // RVA: 0xE60AA4 Offset: 0xE60AA4 VA: 0xE60AA4
		// public static void ConvertBgmIdToCueSheetName(int bgmId, ref string cueSheetName) { }

		// // RVA: 0xE60EC0 Offset: 0xE60EC0 VA: 0xE60EC0
		// public static void ConvertBgmIdToCueName(int bgmId, ref string cueName) { }

		// // RVA: 0xE61380 Offset: 0xE61380 VA: 0xE61380 Slot: 6
		/*protected override void OnAwake()
		{
			UnityEngine.Debug.LogError("TODO");
		}*/

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
			UnityEngine.Debug.LogWarning("TODO BgmPlayer Play");
		}

		// // RVA: 0xE61848 Offset: 0xE61848 VA: 0xE61848
		// public void ContinuousPlay(int bgmId, float volume = 1) { }

		// // RVA: 0xE52268 Offset: 0xE52268 VA: 0xE52268
		// public void Stop() { }

		// // RVA: 0xE61858 Offset: 0xE61858 VA: 0xE61858
		// public void FadeOut(float sec, Action onStop) { }

		// // RVA: 0xE61760 Offset: 0xE61760 VA: 0xE61760
		// public void ChangeVolume(float sec, float targetVol, Action onEnd) { }
	}
}
