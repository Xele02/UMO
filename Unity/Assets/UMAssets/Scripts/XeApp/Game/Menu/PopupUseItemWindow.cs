using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PopupUseItemWindow
	{
		public enum UseItemResult
		{
			 None = 0,
			Close = 1,
			Cancel = 2,
			OK = 3,
		}

		private PopupUseItemSetting useItemSeting; // 0x8
		private UseItemResult _result; // 0xC

		// public PopupUseItemWindow.UseItemResult Result { get; private set; }  0x11607D8 0x11607E0

		// RVA: 0x11607F0 Offset: 0x11607F0 VA: 0x11607F0
		public void Initialize()
		{
			useItemSeting = new PopupUseItemSetting();
			useItemSeting.TitleText = MessageManager.Instance.GetBank("menu").GetMessageByLabel("popup_text_09");
			useItemSeting.WindowSize = SizeType.Middle;
			useItemSeting.SetParent(MenuScene.Instance.transform);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x733634 Offset: 0x733634 VA: 0x733634
		// // RVA: 0x1160990 Offset: 0x1160990 VA: 0x1160990
		// public IEnumerator Show(MNDAMOGGJBJ itemData, UseItemList.Unlock unlock = 0) { }

		// // RVA: 0x1160A70 Offset: 0x1160A70 VA: 0x1160A70
		// private int GetUseItemCount(MNDAMOGGJBJ itemData) { }
	}
}
