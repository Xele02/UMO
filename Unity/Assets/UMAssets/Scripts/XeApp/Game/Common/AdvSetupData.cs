namespace XeApp.Game.Common
{
	public class AdvSetupData
	{
		private int m_advId; // 0x8

		//public int AdvID { get; } 0xE57FEC
		//public bool IsCallResultAfterAdv { get; } 0xE5F91C

		// RVA: 0xE58110 Offset: 0xE58110 VA: 0xE58110
		public void Setup(int advId)
		{
			TodoLogger.Log(0, "Setup");
		}

		// RVA: 0xE57FF4 Offset: 0xE57FF4 VA: 0xE57FF4
		//public void Clear() { }
	}
}
