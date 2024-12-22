using UnityEngine.Events;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.NameEntry
{
	public class NameEntry
	{
		// RVA: 0xCA4010 Offset: 0xCA4010 VA: 0xCA4010
		public static void ShowPlayerNameEntry(string defaultName, UnityAction<string> onSuccess, UnityAction onFailed)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			InputPopupSetting s = new InputPopupSetting();
			s.TitleText = bk.GetMessageByLabel("popup_title_playernameentry");
			s.InputText = defaultName;
			s.InputLineCount = 1;
			s.CharacterLimit = 10;
			s.WindowSize = SizeType.Small;
			s.Description = string.Format(bk.GetMessageByLabel("popup_text_playernameentry_desc"), 10);
			s.Notes = string.Format(bk.GetMessageByLabel("popup_text_playernameentry_notes"), SystemTextColor.ImportantColor);
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			BasicTutorialManager.Log(OAGBCBBHMPF.OGBCFNIKAFI.KAEEOAPBOCI_31);
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xCA48DC
				ShowPlayerNameConfirmPopup((control.Content as InputContent).Text, onSuccess, onFailed);
			}, null, null, null);
		}

		//// RVA: 0xCA44C0 Offset: 0xCA44C0 VA: 0xCA44C0
		private static void ShowPlayerNameConfirmPopup(string name, UnityAction<string> onSuccess, UnityAction onFailed)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = bk.GetMessageByLabel("popup_title_playernameentry");
			s.Text = string.Format(bk.GetMessageByLabel("popup_text_playernameconfirm"), name, SystemTextColor.ImportantColor);
			s.WindowSize = SizeType.Small;
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xCA49FC
				if(type == PopupButton.ButtonType.Positive)
				{
					BHLFHHBDGHO.GEJEDJNKBOF(name, () =>
					{
						//0xCA4B6C
						if(onSuccess != null)
							onSuccess(name);
						BasicTutorialManager.Log(OAGBCBBHMPF.OGBCFNIKAFI.BKFDCMALJBF_32);
					}, () =>
					{
						//0xCA4BE8
						ShowPlayerNameEntry(name, onSuccess, onFailed);
					}, () =>
					{
						//0xCA4BFC
						if(onFailed != null)
							onFailed();
					});
				}
				else
				{
					ShowPlayerNameEntry(name, onSuccess, onFailed);
				}
			}, null, null, null);
		}
	}
}
