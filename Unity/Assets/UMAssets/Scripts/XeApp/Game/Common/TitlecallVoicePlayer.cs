using System.Collections;
using System.Text;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class TitlecallVoicePlayer : VoicePlayerBase
	{
		// // RVA: 0x1CCED9C Offset: 0x1CCED9C VA: 0x1CCED9C
		public void EntrySheet()
		{
			RequestChangeCueSheet("cs_diva_title", null);
		}

		// // RVA: 0x1CCEE08 Offset: 0x1CCEE08 VA: 0x1CCEE08
		public void Play(int divaId, int voiceId)
		{
			StopCue();
			StringBuilder str = new StringBuilder();
			str.AppendFormat("diva_{0:D3}_m_title_{1:D3}", divaId, voiceId);
			PlayCue(str.ToString());
		}

		// // RVA: 0x1CCEF54 Offset: 0x1CCEF54 VA: 0x1CCEF54
		// public void Stop() { }

		// // RVA: 0x1CCEF5C Offset: 0x1CCEF5C VA: 0x1CCEF5C
		public void RequestRemoveCueSheet()
		{
			this.StartCoroutineWatched(Co_RemoveCueSheet());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73B488 Offset: 0x73B488 VA: 0x73B488
		// // RVA: 0x1CCEF80 Offset: 0x1CCEF80 VA: 0x1CCEF80
		private IEnumerator Co_RemoveCueSheet()
		{
			//0x1CCF040
			yield return new WaitWhile(() =>
			{
				//0x1CCF034
				return isPlaying;
			});
			RemoveCueSheet();
		}
	}
}
