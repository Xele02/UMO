using System.Collections;
using System.Text;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class GreetingVoicePlayer : VoicePlayerBase
	{
		//// RVA: 0xEA270C Offset: 0xEA270C VA: 0xEA270C
		public void EntrySheet()
		{
			RequestChangeCueSheet("cs_diva_greeting", null);
		}

		//// RVA: 0xEA2778 Offset: 0xEA2778 VA: 0xEA2778
		public void Play(int divaId, int voiceId)
		{
			StopCue();
			StringBuilder str = new StringBuilder(32);
			str.AppendFormat("diva_{0:D3}_m_select_{1:D3}", divaId, voiceId);
			PlayCue(str.ToString());
		}

		//// RVA: 0xEA28C4 Offset: 0xEA28C4 VA: 0xEA28C4
		public void Stop()
		{
			StopCue();
		}

		//// RVA: 0xEA28CC Offset: 0xEA28CC VA: 0xEA28CC
		public void RequestRemoveCueSheet()
		{
			this.StartCoroutineWatched(Co_RemoveCueSheet());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x73AAD8 Offset: 0x73AAD8 VA: 0x73AAD8
		//// RVA: 0xEA28F0 Offset: 0xEA28F0 VA: 0xEA28F0
		private IEnumerator Co_RemoveCueSheet()
		{
			//0xEA29B0
			yield return new WaitWhile(() => {
				//0xEA29A4
				return isPlaying;
			});
			RemoveCueSheet();
		}
	}
}
