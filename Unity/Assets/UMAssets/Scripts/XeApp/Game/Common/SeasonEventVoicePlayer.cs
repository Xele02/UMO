using System.Text;
using XeSys;

namespace XeApp.Game.Common
{
	public class SeasonEventVoicePlayer : VoicePlayerBase
	{
		//// RVA: 0x138F7A4 Offset: 0x138F7A4 VA: 0x138F7A4
		//public void RequestChangeCueSheet(int seasonEventId, UnityAction onChangeCallback) { }

		//// RVA: 0x138FA88 Offset: 0x138FA88 VA: 0x138FA88
		public void RequestCueSheetDelayDownLoad(int seasonEventId)
		{
			StringBuilder str = new StringBuilder(32);
			str.SetFormat("cs_event_{0:D3}", seasonEventId);
			SoundResource.InstallCueSheet(str.ToString());
		}

		//// RVA: 0x138FE1C Offset: 0x138FE1C VA: 0x138FE1C
		//public void Play(int divaId, int voiceId) { }

		//// RVA: 0x138FF64 Offset: 0x138FF64 VA: 0x138FF64
		//public void Stop() { }
	}
}
