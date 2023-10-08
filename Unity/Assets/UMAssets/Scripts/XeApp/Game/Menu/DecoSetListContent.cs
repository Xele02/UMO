using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class DecoSetListContent : SwapScrollListContent
	{
		[SerializeField]
		private Text productName; // 0x20

		// RVA: 0x1587D8C Offset: 0x1587D8C VA: 0x1587D8C
		public void SetText(string value)
		{
			productName.text = value;
		}

		// RVA: 0x1587DC8 Offset: 0x1587DC8 VA: 0x1587DC8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}
	}
}
