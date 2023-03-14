using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class CommonMenuExpGauge : LayoutUGUIScriptBase
	{
		[SerializeField]
		private float m_usingRangeLow = 1; // 0x14
		[SerializeField]
		private float m_usingRangeHigh; // 0x18
		private float m_gaugeMax = 1; // 0x1C
		private float  m_gaugeValue = 1; // 0x20
		private Vector3 m_rotation = Vector3.zero; // 0x24

		//public float gaugeMax { get; set; } 0x1B49A84 0x1B49A8C
		//public float gaugeValue { get; set; } 0x1B49A94 0x1B49B14
		//private float usingRangeWidth { get; } 0x1B49B1C

		// RVA: 0x1B49B30 Offset: 0x1B49B30 VA: 0x1B49B30 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}
	}
}
