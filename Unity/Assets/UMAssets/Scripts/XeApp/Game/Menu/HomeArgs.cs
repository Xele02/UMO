
namespace XeApp.Game.Menu
{
	public class HomeArgs : TransitionArgs
	{
		private bool m_isOpenSns; // 0x8

		internal bool isOpenSns { get { return m_isOpenSns; } } //0x956AFC

		// RVA: 0x956B04 Offset: 0x956B04 VA: 0x956B04
		public HomeArgs()
		{
			return;
		}

		// RVA: 0x956B0C Offset: 0x956B0C VA: 0x956B0C
		public void SetOpenSns(bool open)
		{
			m_isOpenSns = open;
		}
	}
}
