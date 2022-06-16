using XeApp.Core;
using XeSys;

namespace XeApp.Game
{
	public class BootScene : MainSceneBase
	{
		private int m_revertStep; // 0x28

		// // RVA: 0xE5CA58 Offset: 0xE5CA58 VA: 0xE5CA58 Slot: 9
		protected override void DoAwake()
		{
			enableFade = false;
		}

		// // RVA: 0xE5CA64 Offset: 0xE5CA64 VA: 0xE5CA64 Slot: 10
		protected override void DoStart()
		{
			LHFOAFAOPLC.KHEKNNFCAOI();
		}

		// // RVA: 0xE5CAE0 Offset: 0xE5CAE0 VA: 0xE5CAE0 Slot: 12
		protected override bool DoUpdateEnter()
		{
			if(GameManager.Instance != null)
			{
				GameManager.Instance.RevertResolution();
				if(GameManager.Instance.IsInitializedSystemLayout())
				{
					GameManager.Instance.ChangePopupPriority(true);
					IdleProcessManager.Instance.IsBurstEnable = false;
					NextScene("Title");
					return true;
				}
			}
			return false;
		}

		// // RVA: 0xE5CD14 Offset: 0xE5CD14 VA: 0xE5CD14
		private void OnGUI()
		{
			DoOnGUI();
		}

		// // RVA: 0xE5CD24 Offset: 0xE5CD24 VA: 0xE5CD24 Slot: 11
		protected override void DoOnGUI()
		{
			return;
		}

		// // RVA: 0xE5CD28 Offset: 0xE5CD28 VA: 0xE5CD28 Slot: 13
		protected override void DoUpdateMain()
		{
			return;
		}
	}
}
