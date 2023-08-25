namespace XeApp.Game.Common
{
	public class AdvSetupData
	{
		private int m_advId; // 0x8

		public int AdvID { get { return m_advId; } } //0xE57FEC
		//public bool IsCallResultAfterAdv { get; } 0xE5F91C

		// RVA: 0xE58110 Offset: 0xE58110 VA: 0xE58110
		public void Setup(int advId)
		{
			m_advId = advId;
		}

		// RVA: 0xE57FF4 Offset: 0xE57FF4 VA: 0xE57FF4
		public void Clear()
		{
			m_advId = 0;
		}
	}
}
