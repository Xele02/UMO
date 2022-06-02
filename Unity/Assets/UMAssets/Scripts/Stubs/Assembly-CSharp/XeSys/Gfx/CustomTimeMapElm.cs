using System;

namespace XeSys.Gfx
{
	[Serializable]
	public struct CustomTimeMapElm
	{
		public CustomTimeMapElm(float pt, float n, float p) : this()
		{
		}

		public float Point;
		public float Next;
		public float Prev;
	}
}
