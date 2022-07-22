using System.Text;
using XeSys;

namespace XeApp.Game.Common
{
	public class SoundResource
	{
		private enum CueSheetSubDirectoryNameType
		{
			Se = 0,
			Bgm = 1,
			DivaVoice = 2,
			PilotVoice = 3,
			EventVoice = 4,
			AdvVoice = 5,
			Num = 6,
			Illegal = -1,
		}

		private static readonly string[] CueSheetSubDirectoryName = new string[6] { "snd/se", "snd/bgm", "snd/vo/diva", "snd/vo/pilot", "snd/vo/event", "snd/vo/adv" }; // 0x0
		private static readonly string[] BuiltinSheetName = new string[5] { "cs_se_boot", "cs_bgm_002", "cs_bgm_009", "cs_diva_title", "cs_diva_greeting" }; // 0x4
		private static readonly string[] TutorialBuiltinSheetName = new string[24] {"cs_bgm_adjust", "cs_bgm_tutorial", "cs_bgm_001", "cs_bgm_003",
																				"cs_bgm_004", "cs_bgm_007", "cs_bgm_008", "cs_bgm_010", "cs_bgm_011",
																				"cs_w_0022", "cs_se_adv", "cs_se_gacha", "cs_se_game", "cs_se_menu",
																				"cs_se_notes", "cs_se_result", "cs_diva_001", "cs_adv_000001",
																				"cs_adv_000002", "cs_adv_000003", "cs_adv_000004", "cs_adv_000005",
																				"cs_adv_000006", "cs_pilot_004"}; // 0x8
		public static string[] decryptDirs = new string[7] { "ly/sb", "gm/it/px", "dv/x1", "ef/da", "ct/xg", "dr/xt", "gc/px" }; // 0xC
		private static int selectDecIndex; // 0x10

		// // RVA: 0x1399740 Offset: 0x1399740 VA: 0x1399740
		public static bool IsBuiltinSheet(string cueSheetName)
		{
			for(int i = 0; i < BuiltinSheetName.Length; i++)
			{
				if (BuiltinSheetName[i] == cueSheetName)
					return true;
			}
			return false;
		}

		// // RVA: 0x13998A8 Offset: 0x13998A8 VA: 0x13998A8
		public static bool IsBgm(string cueSheetName)
		{
			if (!cueSheetName.Contains("cs_w_") && !cueSheetName.Contains("cs_bgm_") && !cueSheetName.Contains("cs_ar_w_"))
				return false;
			return true;
		}

		// // RVA: 0x1399990 Offset: 0x1399990 VA: 0x1399990
		public static bool IsVoice(string cueSheetName)
		{
			if (!cueSheetName.Contains("cs_diva_") && !cueSheetName.Contains("cs_pilot_") && !cueSheetName.Contains("cs_event_") && !cueSheetName.Contains("cs_adv_") && !cueSheetName.Contains("cs_ar_diva_") &&
				!cueSheetName.Contains("cs_apl_diva_") && !cueSheetName.Contains("cs_vfo") && !cueSheetName.Contains("cs_cosupg") && !cueSheetName.Contains("cs_coschange") && !cueSheetName.Contains("cs_apl_pilot_") &&
				!cueSheetName.Contains("cs_loby") && !cueSheetName.Contains("cs_gacha_diva") && !cueSheetName.Contains("cs_dec_char_") && !cueSheetName.Contains("cs_change_diva_") && !cueSheetName.Contains("cs_change_pilot_") &&
				!cueSheetName.Contains("cs_livestart_multi_"))
				return false;
			return true;
		}

		// // RVA: 0x1399D1C Offset: 0x1399D1C VA: 0x1399D1C
		private static SoundResource.CueSheetSubDirectoryNameType GetCueSheetSubDirectoryNameType(string cueSheetName)
		{
			if(cueSheetName.Contains("cs_se_"))
				return CueSheetSubDirectoryNameType.Se;
			if (IsBgm(cueSheetName))
				return CueSheetSubDirectoryNameType.Bgm;
			if (cueSheetName.Contains("cs_diva_"))
				return CueSheetSubDirectoryNameType.DivaVoice;
			if (cueSheetName.Contains("cs_pilot_"))
				return CueSheetSubDirectoryNameType.PilotVoice;
			if (cueSheetName.Contains("cs_event_"))
				return CueSheetSubDirectoryNameType.EventVoice;
			if (cueSheetName.Contains("cs_adv_"))
				return CueSheetSubDirectoryNameType.AdvVoice;
			if(!cueSheetName.Contains("cs_ar_diva_") && !cueSheetName.Contains("cs_apl_diva_") && !cueSheetName.Contains("cs_vfo") && !cueSheetName.Contains("cs_cosupg") &&
				!cueSheetName.Contains("cs_coschange"))
			{
				if (cueSheetName.Contains("cs_apl_pilot_"))
					return CueSheetSubDirectoryNameType.PilotVoice;
				if(!cueSheetName.Contains("cs_loby") && !cueSheetName.Contains("cs_gacha_diva") && !cueSheetName.Contains("cs_dec_char_"))
				{
					if (cueSheetName.Contains("cs_change_diva"))
						return CueSheetSubDirectoryNameType.DivaVoice;
					if(!cueSheetName.Contains("cs_change_pilot"))
					{
						if (cueSheetName.Contains("cs_livestart_multi_"))
							return CueSheetSubDirectoryNameType.DivaVoice;
						return CueSheetSubDirectoryNameType.Illegal;
					}
					return CueSheetSubDirectoryNameType.PilotVoice;
				}
			}
			return CueSheetSubDirectoryNameType.DivaVoice;
		}

		// // RVA: 0x139A150 Offset: 0x139A150 VA: 0x139A150
		private static string GetCueSheetSubDirectoryName(string cueSheetName)
		{
			return GetCueSheetSubDirectoryName(GetCueSheetSubDirectoryNameType(cueSheetName));
		}

		// // RVA: 0x139A1D4 Offset: 0x139A1D4 VA: 0x139A1D4
		private static string GetCueSheetSubDirectoryName(SoundResource.CueSheetSubDirectoryNameType type)
		{
			return CueSheetSubDirectoryName[(int)type];
		}

		// // RVA: 0x139A298 Offset: 0x139A298 VA: 0x139A298
		private static string GetInstallCueSheetPath(string cueSheetName)
		{
			StringBuilder str = new StringBuilder();
			str.SetFormat("{0}/{1}/{2}", KEHOJEJMGLJ.CGAHFOBGHIM, GetCueSheetSubDirectoryName(cueSheetName), cueSheetName);
			return str.ToString();
		}

		// // RVA: 0x139A3C8 Offset: 0x139A3C8 VA: 0x139A3C8
		public static string GetStreamingAssetCueSheetPath(string cueSheetName)
		{
			StringBuilder str = new StringBuilder(256);
			str.SetFormat("{0}/{1}", GetCueSheetSubDirectoryName(cueSheetName), cueSheetName);
			return str.ToString();
		}

		// // RVA: 0x139A4C0 Offset: 0x139A4C0 VA: 0x139A4C0
		private static string GetCueSheetPath(string cueSheetName)
		{
			if(IsBuiltinSheet(cueSheetName))
			{
				return GetStreamingAssetCueSheetPath(cueSheetName);
			}
			else
			{
				return GetInstallCueSheetPath(cueSheetName);
			}
		}

		// // RVA: 0x139A5A8 Offset: 0x139A5A8 VA: 0x139A5A8
		public static string GetAcbPath(string cueSheetName)
		{
			return GetCueSheetPath(cueSheetName) + ".acb";
		}

		// // RVA: 0x139A640 Offset: 0x139A640 VA: 0x139A640
		public static string GetAwbPath(string cueSheetName)
		{
			if (!IsBgm(cueSheetName) && !IsVoice(cueSheetName))
				return null;
			if(isSecureCueSheet(cueSheetName))
			{
				UnityEngine.Debug.LogError("TODO GetAwbPath issecure");
			}
			return GetCueSheetPath(cueSheetName) + ".awb";
		}

		// // RVA: 0x1398490 Offset: 0x1398490 VA: 0x1398490
		public static void DecCacheClear()
		{
			UnityEngine.Debug.LogWarning("TODO SoundResource DecCacheClear");
		}

		// // RVA: 0x139A8E0 Offset: 0x139A8E0 VA: 0x139A8E0
		// public static void ChooseDecFileBase() { }

		// // RVA: 0x139A9E4 Offset: 0x139A9E4 VA: 0x139A9E4
		// public static string GetDecAwbPath(string cueSheetName) { }

		// // RVA: 0x1394924 Offset: 0x1394924 VA: 0x1394924
		public static bool AddCueSheet(string cueSheetName)
		{
			if(CriAtom.GetCueSheet(cueSheetName) == null)
			{
				string acbPath = GetAcbPath(cueSheetName);
				string path = "";
				if(isSecureCueSheet(cueSheetName))
				{
					UnityEngine.Debug.LogError("TODO AddCueSheet secure");
				}
				else
				{
					path = GetAwbPath(cueSheetName);
				}
				CriAtom.AddCueSheet(cueSheetName, acbPath, path, null);
				return true;
			}
			return false;
		}

		// // RVA: 0x1394F04 Offset: 0x1394F04 VA: 0x1394F04
		public static void RemoveCueSheet(string cueSheetName)
		{
			if(CriAtom.GetCueSheet(cueSheetName) == null)
			{
				return;
			}
			CriAtom.RemoveCueSheet(cueSheetName);
		}

		// // RVA: 0x139AEFC Offset: 0x139AEFC VA: 0x139AEFC
		// public static bool IsInstalledCueSheet(string cueSheetName) { }

		// // RVA: 0x138FB98 Offset: 0x138FB98 VA: 0x138FB98
		public static bool InstallCueSheet(string cueSheetName)
		{
			if(IsBuiltinSheet(cueSheetName))
			{
				string path = GetStreamingAssetCueSheetPath(cueSheetName);
				bool exists = KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC(path);
				if(!IsBgm(cueSheetName))
				{
					if(!IsVoice(cueSheetName))
					{
						return exists;
					}
				}
				string suf = "";
				if(isSecureCueSheet(cueSheetName))
				{
					suf = "_d.awb";
				}
				else
				{
					suf = ".awb";
				}
				path = path + suf;
				return exists || KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC(path);
			}
			return false;
		}

		// // RVA: 0x139B010 Offset: 0x139B010 VA: 0x139B010
		// public static List<string> CreateBgmFilePathList(int wavId) { }

		// // RVA: 0x139A7D8 Offset: 0x139A7D8 VA: 0x139A7D8
		public static bool isSecureCueSheet(string cueSheetName)
		{
			UnityEngine.Debug.LogError("TODO isSecureCueSheet");
			return false;
			//return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.DDGHBNLOBAJ(cueSheetName) != 0;
		}

		// // RVA: 0x139B1F8 Offset: 0x139B1F8 VA: 0x139B1F8
		// public static CriFsLoadFileRequest RequestLoadAcbFile(string cueSheetName) { }

		// // RVA: 0x139B338 Offset: 0x139B338 VA: 0x139B338
		// public static CriFsLoadFileRequest RequestLoadAwbFile(string cueSheetName) { }

		// // RVA: 0x139B478 Offset: 0x139B478 VA: 0x139B478
		// public static BEEINMBNKNM FindDecryptor(string cueSheetName) { }

		// // RVA: 0x139B61C Offset: 0x139B61C VA: 0x139B61C
		// public static bool IsAcbHeader(byte[] bytes) { }

		// // RVA: 0x139B6D4 Offset: 0x139B6D4 VA: 0x139B6D4
		// public static bool IsAwbHeader(byte[] bytes) { }

		// // RVA: 0x139AC70 Offset: 0x139AC70 VA: 0x139AC70
		// public static void DeployDecFile(string srcPath, string rawAwbPath, string cueSheetName) { }
	}
}
