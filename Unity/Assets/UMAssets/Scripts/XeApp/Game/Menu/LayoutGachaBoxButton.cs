using System.Linq;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutGachaBoxButton : ActionButton
	{
		private NumberBase m_numNum; // 0x80
		private NumberBase m_numCost; // 0x84

		public int num { get { return m_numNum.Number; } } //0x19A1E08

		// RVA: 0x199E560 Offset: 0x199E560 VA: 0x199E560
		public void Setup(int num, int cost)
		{
			m_numNum.SetNumber(num, 0);
			m_numCost.SetNumber(cost, 0);
		}

		// RVA: 0x19A152C Offset: 0x19A152C VA: 0x19A152C
		public bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			NumberBase[] nbrs = GetComponentsInChildren<NumberBase>(true);
			m_numNum = nbrs.Where((NumberBase _) =>
			{
				//0x19A37DC
				return _.name == "swnum_times (AbsoluteLayout)";
			}).First();
			m_numCost = nbrs.Where((NumberBase _) =>
			{
				//0x19A385C
				return _.name == "swnum_buy_stone (AbsoluteLayout)";
			}).First();
			Loaded();
			return true;
		}
	}
}
