
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class OfferVoiceDataTable
	{
		public enum VoiceType
		{
			Entry = 0,
			OperationDecide = 1,
			Sortie = 2,
			ToIdle1 = 3,
			ToIdle2 = 4,
			ToIdle3 = 5,
			Touch1 = 6,
			Touch2 = 7,
			Touch3 = 8,
			Num = 9,
		}

		private static SimpleDivaVoiceSetting[] voiceSettingList = new SimpleDivaVoiceSetting[9]
			{
				new SimpleDivaVoiceSetting() { m_voiceSetting = new SimpleVoicePlayer.VoiceSetting() { m_queFormat = "m_start_{0:D3}", m_randomNum = 4 }, m_isSimpleLipSync = true },
				new SimpleDivaVoiceSetting() { m_voiceSetting = new SimpleVoicePlayer.VoiceSetting() { m_queFormat = "m_decision_{0:D3}", m_randomNum = 3 }, m_isSimpleLipSync = true },
				new SimpleDivaVoiceSetting() { m_voiceSetting = new SimpleVoicePlayer.VoiceSetting() { m_queFormat = "m_sortie_{0:D3}", m_randomNum = 2 }, m_isSimpleLipSync = true },
				new SimpleDivaVoiceSetting() { m_voiceSetting = new SimpleVoicePlayer.VoiceSetting() { m_queFormat = "m_standby_000", m_randomNum = 0 }, m_isSimpleLipSync = true },
				new SimpleDivaVoiceSetting() { m_voiceSetting = new SimpleVoicePlayer.VoiceSetting() { m_queFormat = "m_standby_001", m_randomNum = 0 }, m_isSimpleLipSync = true },
				new SimpleDivaVoiceSetting() { m_voiceSetting = new SimpleVoicePlayer.VoiceSetting() { m_queFormat = "m_standby_002", m_randomNum = 0 }, m_isSimpleLipSync = true },
				new SimpleDivaVoiceSetting() { m_voiceSetting = new SimpleVoicePlayer.VoiceSetting() { m_queFormat = "m_touch_000", m_randomNum = 0 }, m_isSimpleLipSync = false },
				new SimpleDivaVoiceSetting() { m_voiceSetting = new SimpleVoicePlayer.VoiceSetting() { m_queFormat = "m_touch_001", m_randomNum = 0 }, m_isSimpleLipSync = false },
				new SimpleDivaVoiceSetting() { m_voiceSetting = new SimpleVoicePlayer.VoiceSetting() { m_queFormat = "m_touch_002", m_randomNum = 0 }, m_isSimpleLipSync = false }
			}; // 0x0
		public const string QueSheetName = "cs_vfo";

		// RVA: 0xDD32CC Offset: 0xDD32CC VA: 0xDD32CC
		public static SimpleDivaVoiceSetting VoiceTable(VoiceType type)
		{
			return voiceSettingList[(int)type];
		}

		//// RVA: 0xDD3390 Offset: 0xDD3390 VA: 0xDD3390
		//public static SimpleVoicePlayer.VoiceSetting VoiceSetting(OfferVoiceDataTable.VoiceType type) { }
	}
}
