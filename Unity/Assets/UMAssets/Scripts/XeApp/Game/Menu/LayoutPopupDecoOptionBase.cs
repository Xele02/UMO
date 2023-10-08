namespace XeApp.Game.Menu
{
	public class LayoutPopupDecoOptionBase : LayoutPopupConfigBase
	{
		public MDDBFCFOKFC SaveData { get; set; } // 0x38

		// RVA: 0x171CEFC Offset: 0x171CEFC VA: 0x171CEFC Slot: 6
		public override int GetContentsHeight()
		{
			return 0;
		}

		// RVA: 0x171CF04 Offset: 0x171CF04 VA: 0x171CF04 Slot: 7
		public override bool IsShow()
		{
			return true;
		}

		// // RVA: 0x171CF0C Offset: 0x171CF0C VA: 0x171CF0C Slot: 9
		public virtual void SetDecoOption(MDDBFCFOKFC saveData)
		{
			return;
		}
	}
}
