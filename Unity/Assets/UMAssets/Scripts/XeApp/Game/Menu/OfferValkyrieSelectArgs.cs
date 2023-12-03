
using System.Collections.Generic;

namespace XeApp.Game.Menu
{ 
	public class OfferValkyrieSelectArgs : TransitionArgs
	{
		public int selectIndex; // 0x1C
		public int platoonId; // 0x20

		public List<HEFCLPGPMLK.ANKPCIEKPAH>[] SeriesValkyrieList { get; private set; } // 0x8
		public List<HEFCLPGPMLK.ANKPCIEKPAH> Formation { get; private set; } // 0xC
		public HEFCLPGPMLK.AAOPGOGGMID OfferInfo { get; private set; } // 0x10
		public int Select { get; private set; } // 0x14
		public int SelectSeries { get; private set; } // 0x18

		// RVA: 0x1719E8C Offset: 0x1719E8C VA: 0x1719E8C
		public OfferValkyrieSelectArgs(List<HEFCLPGPMLK.ANKPCIEKPAH>[] seriesList, List<HEFCLPGPMLK.ANKPCIEKPAH> Formation, HEFCLPGPMLK.AAOPGOGGMID OfferInfo, int selectSeries, int select, int SelectFormationIndex, int platoonId)
		{
			SeriesValkyrieList = seriesList;
			this.Formation = Formation;
			this.OfferInfo = OfferInfo;
			Select = select;
			SelectSeries = selectSeries;
			selectIndex = SelectFormationIndex;
			this.platoonId = platoonId;
		}
	}
}
