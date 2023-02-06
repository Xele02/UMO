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
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0x1CCEF54 Offset: 0x1CCEF54 VA: 0x1CCEF54
		// public void Stop() { }

		// // RVA: 0x1CCEF5C Offset: 0x1CCEF5C VA: 0x1CCEF5C
		public void RequestRemoveCueSheet()
		{
			TodoLogger.Log(0, "TODO");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73B488 Offset: 0x73B488 VA: 0x73B488
		// // RVA: 0x1CCEF80 Offset: 0x1CCEF80 VA: 0x1CCEF80
		// private IEnumerator Co_RemoveCueSheet() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73B500 Offset: 0x73B500 VA: 0x73B500
		// // RVA: 0x1CCF034 Offset: 0x1CCF034 VA: 0x1CCF034
		// private bool <Co_RemoveCueSheet>b__4_0() { }
	}
}
