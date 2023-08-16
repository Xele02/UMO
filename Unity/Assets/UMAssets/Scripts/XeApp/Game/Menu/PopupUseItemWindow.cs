using System.Collections;
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

		public UseItemResult Result { get { return _result; } private set { if (_result != value) _result = value; } } // 0x11607D8 0x11607E0

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
		public IEnumerator Show(MNDAMOGGJBJ itemData, UseItemList.Unlock unlock = 0)
		{
			//0x1160C00
			_result = UseItemResult.None;
			MNDAMOGGJBJ.MNDGNJLBANB reason = itemData.HDHNAIIAJCP();
			if(reason == MNDAMOGGJBJ.MNDGNJLBANB.HJNNKCMLGFL_None/*0*/)
			{
				useItemSeting.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				useItemSeting.IsValidate = true;
			}
			else
			{
				useItemSeting.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative },
				};
				useItemSeting.IsValidate = false;
			}
			useItemSeting.ViewGrowItemData = itemData;
			useItemSeting.Reason = (UseItemList.LackReason)reason;
			useItemSeting.Unlock = unlock;
			useItemSeting.WindowSize = GetUseItemCount(itemData) > 6 ? SizeType.Large : SizeType.Middle;
			bool isWait = true;
			PopupWindowManager.Show(useItemSeting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1160B98
				if (label == PopupButton.ButtonLabel.Cancel)
					_result = UseItemResult.Cancel;
				else if (label == PopupButton.ButtonLabel.Close)
					_result = UseItemResult.Close;
				else if (label == PopupButton.ButtonLabel.Ok)
					_result = UseItemResult.OK;
				isWait = false;
			}, null, null, null);
			while (isWait)
				yield return null;
		}

		// // RVA: 0x1160A70 Offset: 0x1160A70 VA: 0x1160A70
		private int GetUseItemCount(MNDAMOGGJBJ itemData)
		{
			int res = 0;
			for(int i = 0; i < itemData.INLBMFMOHCI.Count; i++)
			{
				if (itemData.INLBMFMOHCI[i].HMFFHLPNMPH > 0)
					res++;
			}
			return res;
		}
	}
}
