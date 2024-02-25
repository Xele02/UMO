using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class CostumeUpgradeVoiceDataTable
	{
		public enum VoiceType
		{
			Entry = 0,
			Idle = 1,
			ItemSelect = 2,
			PointUp = 3,
			RewardGetItem = 4,
			RewardGetCostumeLvUp = 5,
			RewardGetStatusUp_SubPlate = 6,
			RewardGetCostumeColor = 7,
			Touch1 = 8,
			Touch2 = 9,
			Touch3 = 10,
			Num = 11,
		}

		private static readonly SimpleDivaVoiceSetting[] voiceSettingList = new SimpleDivaVoiceSetting[11]
		{
			new SimpleDivaVoiceSetting() { m_voiceSetting = new SimpleVoicePlayer.VoiceSetting() { m_queFormat = "m_start_{0:D3}", m_randomNum = 3 }, m_isSimpleLipSync = true },
			new SimpleDivaVoiceSetting() { m_voiceSetting = new SimpleVoicePlayer.VoiceSetting() { m_queFormat = "m_select_{0:D3}", m_randomNum = 3 }, m_isSimpleLipSync = true },
			new SimpleDivaVoiceSetting() { m_voiceSetting = new SimpleVoicePlayer.VoiceSetting() { m_queFormat = "m_itemA_{0:D3}", m_randomNum = 2 } },
			new SimpleDivaVoiceSetting() { m_voiceSetting = new SimpleVoicePlayer.VoiceSetting() { m_queFormat = "m_pointUP_{0:D3}", m_randomNum = 6 } },
			new SimpleDivaVoiceSetting() { m_voiceSetting = new SimpleVoicePlayer.VoiceSetting() { m_queFormat = "m_reward1_{0:D3}", m_randomNum = 1 } },
			new SimpleDivaVoiceSetting() { m_voiceSetting = new SimpleVoicePlayer.VoiceSetting() { m_queFormat = "m_reward2_{0:D3}", m_randomNum = 1 } },
			new SimpleDivaVoiceSetting() { m_voiceSetting = new SimpleVoicePlayer.VoiceSetting() { m_queFormat = "m_reward3_{0:D3}", m_randomNum = 1 } },
			new SimpleDivaVoiceSetting() { m_voiceSetting = new SimpleVoicePlayer.VoiceSetting() { m_queFormat = "m_reward4_{0:D3}", m_randomNum = 1 } },
			new SimpleDivaVoiceSetting() { m_voiceSetting = new SimpleVoicePlayer.VoiceSetting() { m_queFormat = "m_touch_000" } },
			new SimpleDivaVoiceSetting() { m_voiceSetting = new SimpleVoicePlayer.VoiceSetting() { m_queFormat = "m_touch_001" } },
			new SimpleDivaVoiceSetting() { m_voiceSetting = new SimpleVoicePlayer.VoiceSetting() { m_queFormat = "m_touch_002" } },
		}; // 0x0
		public const string QueSheetName = "cs_cosupg";

		//// RVA: 0x16F2BC8 Offset: 0x16F2BC8 VA: 0x16F2BC8
		public static SimpleDivaVoiceSetting VoiceTable(VoiceType type)
		{
			return voiceSettingList[(int)type];
		}

		//// RVA: 0x16F6AD4 Offset: 0x16F6AD4 VA: 0x16F6AD4
		public static SimpleVoicePlayer.VoiceSetting VoiceSetting(VoiceType type, int divaId = 1)
		{
			SimpleVoicePlayer.VoiceSetting setting = voiceSettingList[(int)type].m_voiceSetting;
			if(type == VoiceType.ItemSelect)
			{
				setting.m_randomStart = divaId * 2 - 2;
				setting.m_randomNum = divaId * 2;
			}
			return setting;
		}
	}
}
