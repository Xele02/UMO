using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System;

namespace XeApp.Game.Menu
{
	public class DivaGrowthStatusWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text[] m_statusTexts; // 0x14
		[SerializeField]
		private RawImageEx m_divaImage; // 0x18
		[SerializeField]
		private ActionButton m_detailButton; // 0x1C
		public Action OnClickDetailButtonListener; // 0x20
		private DivaIconDecoration m_divaIconDecoration; // 0x24

		// RVA: 0x17DFF1C Offset: 0x17DFF1C VA: 0x17DFF1C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			TodoLogger.Log(0, "InitializeFromLayout");
			return true;
		}

		//// RVA: 0x17DFFF4 Offset: 0x17DFFF4 VA: 0x17DFFF4
		public void InitializeDecoration()
		{
			TodoLogger.Log(0, "InitializeDecoration");
		}

		//// RVA: 0x17E0064 Offset: 0x17E0064 VA: 0x17E0064
		public void ReleaseDecoration()
		{
			TodoLogger.Log(0, "ReleaseDecoration");
		}

		//// RVA: 0x17E008C Offset: 0x17E008C VA: 0x17E008C
		public void UpdateContent(FFHPBEPOMAK_DivaInfo divaData, DFKGGBMFFGB_PlayerInfo playerData)
		{
			TodoLogger.Log(0, "UpdateContent");
		}

		//[CompilerGeneratedAttribute] // RVA: 0x6D8574 Offset: 0x6D8574 VA: 0x6D8574
		//// RVA: 0x17E06DC Offset: 0x17E06DC VA: 0x17E06DC
		//private void <InitializeFromLayout>b__5_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D8584 Offset: 0x6D8584 VA: 0x6D8584
		//// RVA: 0x17E06F0 Offset: 0x17E06F0 VA: 0x17E06F0
		//private void <UpdateContent>b__8_0(IiconTexture texture) { }
	}
}
