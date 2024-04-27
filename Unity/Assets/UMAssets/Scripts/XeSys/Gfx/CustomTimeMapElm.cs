using System;

namespace XeSys.Gfx
{
	[Serializable]
	public struct CustomTimeMapElm
	{
		public float Point; // 0x0
		public float Next; // 0x4
		public float Prev; // 0x8

		// RVA: 0x8062E8 Offset: 0x8062E8 VA: 0x8062E8
		public CustomTimeMapElm(float pt, float n, float p)
		{
			Point = pt;
			Next = n;
			Prev = p;
		}
	}
}
