namespace XeApp.Game.MiniGame
{
	public class ShootingResulData
	{
		private const int xor = 1185147999;
		private const int SCORE_MAX = 99999999;
		private int m_score; // 0x8

		public int Score { get { return m_score ^ xor; } set
			{
				m_score = (m_score ^ xor) + value;
				if (m_score > SCORE_MAX)
					m_score = SCORE_MAX;
				m_score = m_score ^ xor;
			}
		} //0xC90060 0xC90090

		// RVA: 0xC90050 Offset: 0xC90050 VA: 0xC90050
		public void Initialize()
		{
			m_score = xor;
		}
	}
}
