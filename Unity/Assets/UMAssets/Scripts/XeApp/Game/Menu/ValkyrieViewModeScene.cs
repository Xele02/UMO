namespace XeApp.Game.Menu
{
	public class ValkyrieViewModeScene : ModelViewModeScene
	{

		// RVA: 0xBDAB24 Offset: 0xBDAB24 VA: 0xBDAB24 Slot: 31
		protected override void GetLayoutName(out string bundle_name, out string asset_name, out string asset_name_LB, out string asset_name_RT)
		{
			bundle_name = "ly/045.xab";
			asset_name = "ViewModeViewOff";
			asset_name_LB = "ViewModeViewOff_Vertical";
			asset_name_RT = "ViewModeViewOff_Vertical_02";
		}

		// RVA: 0xBDABCC Offset: 0xBDABCC VA: 0xBDABCC Slot: 21
		protected override void OnOpenScene()
		{
			base.OnOpenScene();
			if(ViewModeCameraMan.Instance != null)
			{
				ViewModeCameraMan.Instance.SetUserOperation(true);
			}
			GetComponentInChildren<LayoutViewModeViewOff>(true).Setup();
			GameManager.Instance.AddPushBackButtonHandler(PerformClickReturnButton);
		}

		// RVA: 0xBDADC4 Offset: 0xBDADC4 VA: 0xBDADC4 Slot: 12
		protected override void OnStartExitAnimation()
		{
			base.OnStartExitAnimation();
			if(ViewModeCameraMan.Instance != null)
			{
				ViewModeCameraMan.Instance.SetUserOperation(false);
				ViewModeCameraMan.Instance.StartNeutralPose();
			}
			GetComponentInChildren<LayoutViewModeViewOff>(true).Exit();
			PGIGNJDPCAH.HIHIEBACIHJ(PGIGNJDPCAH.FELLIEJEPIJ.LPBDIINNFEE/*5*/);
		}

		// RVA: 0xBDAF8C Offset: 0xBDAF8C VA: 0xBDAF8C Slot: 32
		protected override void OnClickButton()
		{
			base.OnClickButton();
			GameManager.Instance.RemovePushBackButtonHandler(PerformClickReturnButton);
		}
	}
}
