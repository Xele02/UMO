using System;

namespace XeSys.Gfx
{
	[Serializable]
	public struct TimeMapData
	{
		public enum TimeMapType
		{
			None = 0,
			Quadratic = 1,
			CustomElm = 2,
		}

		public TimeMapData(int start, int end, TimeMapData.TimeMapType tmType, int strength, int elemNum) : this()
		{
		}

		public TimeMapType TmType;
		public int Strength;
		public int StartFrame;
		public int EndFrame;
		public CustomTimeMapElm[] CustomTimeMapElmList;
	}
}
