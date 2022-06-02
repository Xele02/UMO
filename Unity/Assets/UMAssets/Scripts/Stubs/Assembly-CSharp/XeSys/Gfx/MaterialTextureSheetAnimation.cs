using UnityEngine;

namespace XeSys.Gfx
{
	public class MaterialTextureSheetAnimation : MonoBehaviour
	{
		public int sheetColumn;
		public int sheetRow;
		public float changeTime;
		public int startIndex;
		public int slices;
		public bool random;
		public bool reverse;
		public bool enableScale;
		public int startSliceOffset;
	}
}
