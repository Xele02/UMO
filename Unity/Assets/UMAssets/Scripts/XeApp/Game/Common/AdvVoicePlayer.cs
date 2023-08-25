using System.Text;
using UnityEngine.Events;
using XeSys;

namespace XeApp.Game.Common
{
	public class AdvVoicePlayer : VoicePlayerBase
	{
		//// RVA: 0xE5F934 Offset: 0xE5F934 VA: 0xE5F934
		public void RequestChangeAdvCueSheet(int advId, UnityAction onChangeCallback)
		{
			StringBuilder str = new StringBuilder(32);
			str.SetFormat("cs_adv_{0:D6}", advId);
			RequestChangeCueSheet(str.ToString(), onChangeCallback);
		}

		//// RVA: 0xE5205C Offset: 0xE5205C VA: 0xE5205C
		public void Play(int charaId, int voiceId)
		{
			StopCue();
			StringBuilder str = new StringBuilder(32);
			str.AppendFormat("char_{0:D3}_{1:D3}", charaId, voiceId);
			PlayCue(str.ToString());
		}

		//// RVA: 0xE5223C Offset: 0xE5223C VA: 0xE5223C
		public void Stop()
		{
			StopCue();
		}
	}
}
