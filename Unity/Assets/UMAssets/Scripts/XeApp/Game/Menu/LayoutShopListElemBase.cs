using mcrs;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public abstract class LayoutShopListElemBase : SwapScrollListContent
	{
		public const int InvokeId_Select = 0;

		protected abstract ButtonBase selectButton { get; } // RVA: -1 Offset: -1 Slot: 6

		// RVA: 0x193FD14 Offset: 0x193FD14 VA: 0x193FD14
		private void Awake()
		{
			Initialize(selectButton);
		}

		// // RVA: 0x193FD44 Offset: 0x193FD44 VA: 0x193FD44
		private void Initialize(ButtonBase button)
		{
			button.AddOnClickCallback(OnClickCallback);
		}

		// // RVA: 0x193FDEC Offset: 0x193FDEC VA: 0x193FDEC
		private void OnClickCallback()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			ClickButton.Invoke(0, this);
		}
	}
}
