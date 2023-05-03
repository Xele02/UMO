using System.Text;
using UnityEngine.Events;
using XeSys;

namespace XeApp.Game.Common
{
	public class SeasonEventVoicePlayer : VoicePlayerBase
	{
		//// RVA: 0x138F7A4 Offset: 0x138F7A4 VA: 0x138F7A4
		public void RequestChangeCueSheet(int seasonEventId, UnityAction onChangeCallback)
		{
			StringBuilder str = new StringBuilder(32);
			str.SetFormat("cs_event_{0:D3}", seasonEventId);
			RequestChangeCueSheet(str.ToString(), onChangeCallback);
		}

		//// RVA: 0x138FA88 Offset: 0x138FA88 VA: 0x138FA88
		public void RequestCueSheetDelayDownLoad(int seasonEventId)
		{
			StringBuilder str = new StringBuilder(32);
			str.SetFormat("cs_event_{0:D3}", seasonEventId);
			SoundResource.InstallCueSheet(str.ToString());
		}

		//// RVA: 0x138FE1C Offset: 0x138FE1C VA: 0x138FE1C
		public void Play(int divaId, int voiceId)
		{
			StopCue(false);
			StringBuilder str = new StringBuilder(32);
			str.AppendFormat("diva_{0:D3}_m_home_{1:D3}", divaId, voiceId);
			PlayCue(str.ToString());
		}

		//// RVA: 0x138FF64 Offset: 0x138FF64 VA: 0x138FF64
		public void Stop()
		{
			StopCue(false);
		}
	}
}
