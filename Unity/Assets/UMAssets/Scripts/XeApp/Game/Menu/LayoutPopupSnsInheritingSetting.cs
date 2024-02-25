using XeApp.Game.Common;
using UnityEngine;
using System;
using XeSys.Gfx;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopupSnsInheritingSetting : LayoutPopupSnsSetting
	{
		[SerializeField]
		private ActionButton m_button; // 0x40

		public Action OnButtonCallbackCaution { get; set; } // 0x44
		public bool IsPreparation { get; set; } // 0x48

		// RVA: 0x17890D4 Offset: 0x17890D4 VA: 0x17890D4 Slot: 6
		public override void SetStatus()
		{
			MessageBank bk = MessageManager.Instance.GetBank("common");
			SetText(eText.Desc1, bk.GetMessageByLabel(IsPreparation ? "popup_inh_pre_sns_select" : "popup_inh_sns_select"));
			SetText(eText.Desc2, bk.GetMessageByLabel("popup_inh_sns_caution"));
		}

		// RVA: 0x1789278 Offset: 0x1789278 VA: 0x1789278
		public new void Show()
		{
			base.Show();
		}

		// RVA: 0x1789288 Offset: 0x1789288 VA: 0x1789288 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			AbsoluteLayout abs = layout.FindViewById("swtbl_sel_inh_btn_form2") as AbsoluteLayout;
			if (abs != null)
				abs.StartChildrenAnimGoStop("02");
			m_button.AddOnClickCallback(() =>
			{
				//0x1789808
				if (OnButtonCallbackCaution != null)
					OnButtonCallbackCaution();
			});
			return true;
		}
	}
}
