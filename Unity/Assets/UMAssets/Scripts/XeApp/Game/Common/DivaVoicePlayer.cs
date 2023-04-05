using System.Text;
using UnityEngine.Events;
using XeSys;

namespace XeApp.Game.Common
{
	public class DivaVoicePlayer : VoicePlayerBase
	{
		public enum VoiceCategory
		{
			Login = 0,
			Home = 1,
			Touch = 2,
			Gacha = 3,
			StartGame = 4,
			GameActiveSkill = 5,
			GameDivaMode = 6,
			GameClear = 7,
			GameFailed = 8,
			GameSpecial = 9,
			Levelup = 10,
			Result = 11,
			Story = 12,
			Review = 13,
			Costume = 14,
			Mission = 15,
			Present = 16,
			Intimacy = 17,
			Campaign = 18,
			Change = 19,
			BttResult001 = 20,
			BttResult002 = 21,
			RaidSupport = 22,
			Num = 23,
			None = -1,
		}

		private static readonly string[] categoryPrefix = new string[23] { "m_login", "m_home", "m_touch", "m_gacha", "m_gstart", "g_askill", "g_dmode", "g_gend",
																			"g_gover", "g_special", "m_lvup", "m_result", "m_story", "m_review", "m_costume",
																			"m_mission", "m_present", "m_intimacy", "m_3rdlive", "g_change", "g_bttresult_001", 
																			"g_bttresult_002", "m_raidsupport"}; // 0x0
		private bool m_enable = true; // 0x20

		// // RVA: 0x1C09D7C Offset: 0x1C09D7C VA: 0x1C09D7C
		// public void SetEnable(bool a_enable) { }

		// // RVA: 0x1C09D84 Offset: 0x1C09D84 VA: 0x1C09D84
		public static string MakeCueSheetName(int divaId)
		{
			StringBuilder str = new StringBuilder(32);
			str.SetFormat("cs_diva_{0:D3}", divaId);
			return str.ToString();
		}

		// // RVA: 0x1C09E5C Offset: 0x1C09E5C VA: 0x1C09E5C
		public void RequestChangeCueSheet(int divaId, UnityAction onChangeCallback)
		{
			RequestChangeCueSheet(MakeCueSheetName(divaId), onChangeCallback);
		}

		// // RVA: 0x1C09EF8 Offset: 0x1C09EF8 VA: 0x1C09EF8
		public void RequestChangeCueSheetForReplacement(int forceDivaId, UnityAction onChangeCallback)
		{
			RequestChangeCueSheet(string.Format("cs_change_diva_{0:D3}", forceDivaId), onChangeCallback);
		}

		// // RVA: 0x1C09FA0 Offset: 0x1C09FA0 VA: 0x1C09FA0
		// public void RequestChangeCueSheetForLiveStartMulti(int cuesheet_id, UnityAction onChangeCallback) { }

		// // RVA: 0x1C0A048 Offset: 0x1C0A048 VA: 0x1C0A048
		public static string MakeCueName(DivaVoicePlayer.VoiceCategory categoryType, int voiceId)
		{
			StringBuilder str = new StringBuilder(32);
			str.AppendFormat("{0}_{1:D3}", categoryPrefix[(int)categoryType], voiceId);
			return str.ToString();
		}

		// // RVA: 0x1C0A1DC Offset: 0x1C0A1DC VA: 0x1C0A1DC
		public void Play(VoiceCategory categoryType, int voiceId)
		{
			StopCue();
			if(!m_enable)
				return;
			PlayCue(MakeCueName(categoryType,voiceId));
		}

		public void Preload(VoiceCategory categoryType, int voiceId)
		{
			if (!m_enable)
				return;
			Preload(MakeCueName(categoryType, voiceId));
		}

		// // RVA: 0x1C0A298 Offset: 0x1C0A298 VA: 0x1C0A298
		// public void Play(int cueId) { }

		// // RVA: 0x1C0A290 Offset: 0x1C0A290 VA: 0x1C0A290
		public void Stop()
		{
			StopCue();
		}
	}
}
