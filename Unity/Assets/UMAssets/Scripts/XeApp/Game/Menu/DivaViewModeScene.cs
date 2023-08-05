namespace XeApp.Game.Menu
{
	public class DivaViewModeScene : ModelViewModeScene
	{
		private ViewScreenCostume m_view_screen_cos; // 0x58

		//// RVA: 0x12738E4 Offset: 0x12738E4 VA: 0x12738E4 Slot: 31
		protected override void GetLayoutName(out string bundle_name, out string asset_name, out string asset_name_LB, out string asset_name_RT)
		{
			bundle_name = "ly/044.xab";
			asset_name = "ViewModeViewOff";
			asset_name_LB = "ViewModeViewOff_Vertical";
			asset_name_RT = "ViewModeViewOff_Vertical_02";
		}

		//// RVA: 0x127398C Offset: 0x127398C VA: 0x127398C Slot: 32
		protected override void OnClickButton()
		{
			base.OnClickButton();
			if(m_view_screen_cos != null)
			{
				m_view_screen_cos.InputOff();
				m_view_screen_cos = null;
			}
			MenuScene.RemainDivaOneTime();
			GameManager.Instance.RemovePushBackButtonHandler(OnClickButton);
		}

		// RVA: 0x1273B18 Offset: 0x1273B18 VA: 0x1273B18 Slot: 21
		protected override void OnOpenScene()
		{
			base.OnOpenScene();
			if (Args != null && Args is DivaViewModeArgs)
			{
				DivaViewModeArgs arg = Args as DivaViewModeArgs;
				if(arg.viewObj != null)
				{
					m_view_screen_cos = arg.viewObj.GetComponent<ViewScreenCostume>();
					m_view_screen_cos.SetDivaTargetObject();
					m_view_screen_cos.InputOn();
				}
			}
			GameManager.Instance.AddPushBackButtonHandler(PerformClickReturnButton);
		}
	}
}
