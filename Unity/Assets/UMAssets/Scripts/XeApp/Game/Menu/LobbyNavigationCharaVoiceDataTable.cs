using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LobbyNavigationCharaVoiceDataTable
	{
		public enum VoiceType
		{
			Start = 0,
			Emergence = 1,
			End = 2,
			Num = 3,
		}

		private static readonly SimpleDivaVoiceSetting[] voiceSettingList = new SimpleDivaVoiceSetting[3]
		{
			new SimpleDivaVoiceSetting() { m_voiceSetting = new SimpleVoicePlayer.VoiceSetting() { m_queFormat = "m_start_{0:D3}" } },
			new SimpleDivaVoiceSetting() { m_voiceSetting = new SimpleVoicePlayer.VoiceSetting() { m_queFormat = "m_emergence_{0:D3}" } },
			new SimpleDivaVoiceSetting() { m_voiceSetting = new SimpleVoicePlayer.VoiceSetting() { m_queFormat = "m_end_{0:D3}" } }
		}; // 0x0
		public const string QueSheetName = "cs_loby";

		// // RVA: 0xD19674 Offset: 0xD19674 VA: 0xD19674
		// public static SimpleDivaVoiceSetting VoiceTable(LobbyNavigationCharaVoiceDataTable.VoiceType type) { }

		// // RVA: 0xD19738 Offset: 0xD19738 VA: 0xD19738
		public static SimpleVoicePlayer.VoiceSetting VoiceSetting(VoiceType type, int divaId = 1)
		{
			return voiceSettingList[(int)type].m_voiceSetting;
		}
	}
}
