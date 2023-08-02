using System;
using System.Text;
using CriWare;
using UnityEngine.Events;
using XeSys;

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
		public long timeSyncedWithAudio { get { return playBack.timeSyncedWithAudio; } private set { return; } } //0xE61350 0xE6137C

		// // RVA: 0xE60AA4 Offset: 0xE60AA4 VA: 0xE60AA4
		public static void ConvertBgmIdToCueSheetName(int bgmId, ref string cueSheetName)
		{
			StringBuilder str = new StringBuilder();
			if(bgmId < MINIGAME_BGM_ID_BASE)
			{
				if(bgmId < AR_BGM_ID_BASE)
				{
					if(bgmId < PROLOGUE_BGM)
					{
						if(bgmId < ADJUST_BGM)
						{
							if(bgmId < MENU_TRIAL_ID_BASE)
							{
								if(bgmId < MENU_BGM_ID_BASE)
								{
									str.SetFormat("cs_w_{0:D4}", bgmId);
								}
								else
								{
									str.SetFormat("cs_bgm_{0:D3}", bgmId - MENU_BGM_ID_BASE);
								}
							}
							else
							{
								str.SetFormat("cs_w_{0:D4}", bgmId - MENU_TRIAL_ID_BASE);
							}
						}
						else
						{
							cueSheetName = "cs_bgm_adjust";
							return;
						}
					}
					else
					{
						cueSheetName = "cs_bgm_tutorial";
						return;
					}
				}
				else
				{
					str.SetFormat("cs_ar_w_{0:D4}", bgmId - AR_BGM_ID_BASE);
				}
			}
			else
			{
				str.SetFormat("cs_bgm_minigame_{0:D3}", bgmId - MINIGAME_BGM_ID_BASE);
			}
			cueSheetName = str.ToString();
		}

		// // RVA: 0xE60EC0 Offset: 0xE60EC0 VA: 0xE60EC0
		public static void ConvertBgmIdToCueName(int bgmId, ref string cueName)
		{
			StringBuilder str = new StringBuilder();
			if (bgmId < MINIGAME_BGM_ID_BASE)
			{
				if (bgmId < AR_BGM_ID_BASE)
				{
					if (bgmId < PROLOGUE_BGM)
					{
						if (bgmId < ADJUST_BGM)
						{
							if (bgmId < MENU_TRIAL_ID_BASE)
							{
								if (bgmId < MENU_BGM_ID_BASE)
								{
									str.SetFormat("w_{0:D4}", bgmId);
								}
								else
								{
									str.SetFormat("bgm_{0:D3}", bgmId - MENU_BGM_ID_BASE);
								}
							}
							else
							{
								str.SetFormat("w_{0:D4}_chorus", bgmId - MENU_TRIAL_ID_BASE);
							}
						}
						else
						{
							cueName = "bgm_adjust";
							return;
						}
					}
					else
					{
						cueName = "cs_bgm_tutorial";
						return;
					}
				}
				else
				{
					str.SetFormat("ar_w_{0:D4}", bgmId - AR_BGM_ID_BASE);
				}
			}
			else
			{
				str.SetFormat("bgm_minigame_{0:D3}", bgmId - MINIGAME_BGM_ID_BASE);
			}
			cueName = str.ToString();
		}

		// // RVA: 0xE61380 Offset: 0xE61380 VA: 0xE61380 Slot: 6
		protected override void OnAwake()
		{
			bgmSource = gameObject.AddComponent<CriAtomBgmSource>();
			currentBgmId = -1;
		}

		// // RVA: 0xE61410 Offset: 0xE61410 VA: 0xE61410
		public bool RequestChangeCueSheet(int wavId, UnityAction onEndCallback)
		{
			string sheetName = string.Empty;
			ConvertBgmIdToCueSheetName(wavId, ref sheetName);
			return RequestChangeCueSheet(sheetName, onEndCallback);
		}

		// // RVA: 0xE614D4 Offset: 0xE614D4 VA: 0xE614D4
		public void ChangeMusicCue(int bgmId)
		{
			string sheetName = string.Empty;
			ConvertBgmIdToCueName(bgmId, ref sheetName);
			source.cueName = sheetName;
			currentBgmId = bgmId;
		}

		// // RVA: 0xE615C0 Offset: 0xE615C0 VA: 0xE615C0
		public void Play(int bgmId, float volume = 1)
		{
			StopCue();
			currentBgmId = -1;
			string sheetName = string.Empty;
			ConvertBgmIdToCueSheetName(bgmId, ref sheetName);
			// Try catch added for UMO for download mode when bgm wasn't preloaded, until download at start works.
			try
			{
				ChangeCueSheet(sheetName);
				if (SoundResource.isSecureCueSheet(sheetName))
					isPlayedSecureMusic = true;
				string cueName = string.Empty;
				ConvertBgmIdToCueName(bgmId, ref cueName);
				PlayCue(cueName);
				ChangeVolume(0, volume, null);
				currentBgmId = bgmId;
			} catch (Exception e)
			{
				TodoLogger.LogError(TodoLogger.Filesystem, "Could not plsy bgm : "+e.ToString());
			}
		}

		// // RVA: 0xE61848 Offset: 0xE61848 VA: 0xE61848
		public void ContinuousPlay(int bgmId, float volume = 1)
		{
			if(currentBgmId == bgmId)
				return;
			Play(bgmId, volume);
		}

		// // RVA: 0xE52268 Offset: 0xE52268 VA: 0xE52268
		public void Stop()
		{
			StopCue();
			currentBgmId = -1;
		}

		// // RVA: 0xE61858 Offset: 0xE61858 VA: 0xE61858
		public new void FadeOut(float sec, Action onStop)
		{
			currentBgmId = -1;
			base.FadeOut(sec, () =>
			{
				//0xE619F4
				if (onStop != null)
					onStop();
			});
		}

		// // RVA: 0xE61760 Offset: 0xE61760 VA: 0xE61760
		public new void ChangeVolume(float sec, float targetVol, Action onEnd)
		{
			base.ChangeVolume(sec,targetVol, () =>
			{
				//0xE61A08
				if (onEnd != null)
					onEnd();
			});
		}
	}
}
