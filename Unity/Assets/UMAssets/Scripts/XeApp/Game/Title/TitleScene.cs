using XeApp.Core;

namespace XeApp.Game.Title
{
	public class TitleScene : MainSceneBase
	{
		private IOGKADECKOP a; // 0x28

		// RVA: 0xE3CC48 Offset: 0xE3CC48 VA: 0xE3CC48 Slot: 9
		protected override void DoAwake()
		{
			a = new IOGKADECKOP();
			a.OGNDELCENBB = (string INHEEPHFAON) => {
				// 0xE3CEDC
				NextScene(INHEEPHFAON);
			};
			base.DoAwake();
			enableFade = false;
			GameManager.Instance.SetDispLongScreenFrame(true);
			GameManager.Instance.UpdateInputArea(false);
			a.LIGFHEAKAGD(this);
		}

		// RVA: 0xE3CDC8 Offset: 0xE3CDC8 VA: 0xE3CDC8 Slot: 10
		protected override void DoStart()
		{
			base.DoStart();
			a.BHADKPGCNCP();
		}

		// RVA: 0xE3CE00 Offset: 0xE3CE00 VA: 0xE3CE00 Slot: 12
		protected override bool DoUpdateEnter()
		{
			return a.FKDKMCKJNJD();
		}

		// RVA: 0xE3CE2C Offset: 0xE3CE2C VA: 0xE3CE2C
		private void OnTouchScreen()
		{
			a.FGBKOJCFMKM();
		}
	}
}
