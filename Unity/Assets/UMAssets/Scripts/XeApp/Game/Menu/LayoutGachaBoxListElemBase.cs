using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public abstract class LayoutGachaBoxListElemBase : SwapScrollListContent
	{
		public const int InvokeId_Select = 0;

		protected abstract ButtonBase selectButton { get; }  //Slot: 6

		// RVA: 0x19A3EE0 Offset: 0x19A3EE0 VA: 0x19A3EE0
		private void Awake()
		{
			Initialize(selectButton);
		}

		// // RVA: 0x19A3F10 Offset: 0x19A3F10 VA: 0x19A3F10
		private void Initialize(ButtonBase button)
		{
			button.AddOnClickCallback(OnClickCallback);
		}

		// // RVA: 0x19A3FB8 Offset: 0x19A3FB8 VA: 0x19A3FB8
		private void OnClickCallback()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			ClickButton.Invoke(0, this);
		}
	}
}
