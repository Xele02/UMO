using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class BgItem : SwapScrollListContent
	{
		[SerializeField]
		private RawImage image; // 0x20
		private int bgCount = -1; // 0x24
		private bool loading; // 0x28
		private bool initialize; // 0x29
		private const int MapNo = 1;
		private const float MapBgContentWidth = 1184;
		private const float MapBgMerginWidth = 2;
		private const float MapBgClampWidth = 1188;
		private const float MapBgUvRectX = 0.001683502f;
		private const float MapBgUvRectW = 0.996633f;
		private static Rect MapBgUvRect = new Rect(MapBgUvRectX, 0, MapBgUvRectW, 1); // 0x0

		public bool isLoaded { get { return !loading || !initialize; } } //0x14446F0

		// RVA: 0x1444714 Offset: 0x1444714 VA: 0x1444714
		private void Start()
		{
			image.uvRect = MapBgUvRect;
			image.enabled = false;
		}

		//// RVA: 0x144480C Offset: 0x144480C VA: 0x144480C
		//public void UpdateItem(int count) { }
	}
}
