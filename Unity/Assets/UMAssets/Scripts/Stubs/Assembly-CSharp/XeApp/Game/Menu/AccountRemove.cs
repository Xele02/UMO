using System.Collections;

namespace XeApp.Game.Menu
{
	public class AccountRemove
	{
		public enum Result
		{
			None = 0,
			Success = 1,
			Failure = 2,
			Cancel = 3,
		}

		private HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink[] _platforms = new HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink[3]
			{
				HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.AIECBKAKOGC_Twitter,
				HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.OKEAEMBLENP_Facebook,
				HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.LMODEBIKEBC_Line
			}; // 0x8

		public Result RemoveAcctounResult { get; private set; } // 0xC

		//[IteratorStateMachineAttribute] // RVA: 0x6C9C34 Offset: 0x6C9C34 VA: 0x6C9C34
		// RVA: 0x1433444 Offset: 0x1433444 VA: 0x1433444
		public IEnumerator Execute()
		{
			int i; // 0x24
			//IAEMADDNJPJ request; // 0x28

			//0x14336CC
			TodoLogger.LogError(0, "Execute");
			RemoveAcctounResult = Result.Success;
			yield return null;
		}
	}
}
