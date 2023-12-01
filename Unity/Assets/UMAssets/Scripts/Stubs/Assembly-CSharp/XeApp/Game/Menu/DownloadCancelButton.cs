using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;
using mcrs;

namespace XeApp.Game.Menu
{
	public class DownloadCancelButton : LayoutUGUIScriptBase
	{
		public static readonly string AssetName = "root_cmn_load_cancel_btn_layout_root"; // 0x0
		[SerializeField]
		private ActionButton m_cancelButton; // 0x18

		public Action OnClickCancelButton { get; set; } // 0x14

		// RVA: 0x1273EE0 Offset: 0x1273EE0 VA: 0x1273EE0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_cancelButton.AddOnClickCallback(() =>
			{
				//0x1274070
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				if (OnClickCancelButton != null)
					OnClickCancelButton();
			});
			return true;
		}

		//// RVA: 0x1273F8C Offset: 0x1273F8C VA: 0x1273F8C
		//public void SetDisable(bool isDisable) { }

		//// RVA: 0x1273FC0 Offset: 0x1273FC0 VA: 0x1273FC0
		//public void SetInputOff(bool isInputOff) { }
	}
}
