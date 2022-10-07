using System.Text;
using UnityEngine.Events;
using XeSys;

namespace XeApp.Game.Common
{
	public class PilotVoicePlayer : VoicePlayerBase
	{
		public enum VoiceCategory
		{
			Start = 0,
			Fwave = 1,
			Valkyrie = 2,
			Special = 3,
			Unlock = 4,
			Select = 5,
			Change = 6,
			Offer_Success = 7,
			Offer_Great = 8,
			Offer_Sortie = 9,
			Num = 10,
		}

		private static readonly string[] categoryPrefix = new string[10] { "g_gstart", "g_fwave", "g_vmode", "g_special", "m_get", "m_select", "g_change",
																			"m_good", "m_great", "m_sortie"}; // 0x0
		private bool m_enable = true; // 0x20

		// // RVA: 0xAF6DA8 Offset: 0xAF6DA8 VA: 0xAF6DA8
		// public void SetEnable(bool a_enable) { }

		// // RVA: 0xAF6DB0 Offset: 0xAF6DB0 VA: 0xAF6DB0
		public void RequestChangeCueSheet(int pilotId, UnityAction onChangeCallback)
		{
			StringBuilder str = new StringBuilder(32);
			str.SetFormat("cs_pilot_{0:D3}", pilotId);
			RequestChangeCueSheet(str.ToString(), onChangeCallback);
		}

		// // RVA: 0xAF6EA4 Offset: 0xAF6EA4 VA: 0xAF6EA4
		public void RequestChangeCueSheetForReplacement(int forceId, UnityAction onChangeCallback)
		{
			StringBuilder str = new StringBuilder(32);
			str.SetFormat("cs_change_pilot_{0:D3}", forceId);
			RequestChangeCueSheet(str.ToString(), onChangeCallback);
		}

		// // RVA: 0xAF6F98 Offset: 0xAF6F98 VA: 0xAF6F98
		// public void RequestChangeCueSheet_offer(int valkrieyId, UnityAction onChangeCallback) { }

		// // RVA: 0xAF7040 Offset: 0xAF7040 VA: 0xAF7040
		public void Play(VoiceCategory categoryType, int voiceId)
		{

		}

		// // RVA: 0xAF7200 Offset: 0xAF7200 VA: 0xAF7200
		// public void Stop() { }
	}
}
