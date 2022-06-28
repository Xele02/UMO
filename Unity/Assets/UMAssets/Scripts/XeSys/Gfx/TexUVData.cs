using System;

namespace XeSys.Gfx
{
	[Serializable]
	public class TexUVData
	{
		public string name; // 0x8
		public float u; // 0xC
		public float v; // 0x10
		public float width; // 0x14
		public float height; // 0x18
	}
}
