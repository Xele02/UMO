
using mcrs;
using System;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class ConfigUtility
	{
		//// RVA: 0x1B64AF4 Offset: 0x1B64AF4 VA: 0x1B64AF4
		public static void PlaySeSlider()
		{
			SoundManager.Instance.sePlayerBoot.Stop();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
		}

		//// RVA: 0x1B64B94 Offset: 0x1B64B94 VA: 0x1B64B94
		public static void PlaySeButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
		}

		//// RVA: 0x1B64BEC Offset: 0x1B64BEC VA: 0x1B64BEC
		public static void PlaySeToggleButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//// RVA: 0x1B64C44 Offset: 0x1B64C44 VA: 0x1B64C44
		public static void VolumeDefaultPopup(Action<bool> callback)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("config_text_22"), SizeType.Small, bk.GetMessageByLabel("config_text_23"), new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x1B65924
					if (type == PopupButton.ButtonType.Negative)
					{
						if (callback != null)
							callback(false);
					}
					else if (type == PopupButton.ButtonType.Positive)
					{
						if (callback != null)
							callback(true);
					}
				}, null, null, null);
		}

		//// RVA: 0x1B64F58 Offset: 0x1B64F58 VA: 0x1B64F58
		public static void TimingDefaultPopup(Action<bool> callback)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("config_text_22"), SizeType.Small, bk.GetMessageByLabel("config_text_51"), new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x1B659D4
					if (type == PopupButton.ButtonType.Negative)
					{
						if (callback != null)
							callback(false);
					}
					else if (type == PopupButton.ButtonType.Positive)
					{
						if (callback != null)
							callback(true);
					}
				}, null, null, null);
		}

		//// RVA: 0x1B6526C Offset: 0x1B6526C VA: 0x1B6526C
		public static void NotesSpeedDefaultPopup(Action<bool> callback)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("config_text_61"), SizeType.Small, bk.GetMessageByLabel("config_text_62"), new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x1B65A84
					if (callback != null)
						callback(label == PopupButton.ButtonLabel.Ok);
				}, null, null, null);
		}

		//// RVA: 0x1B65580 Offset: 0x1B65580 VA: 0x1B65580
		public static void DimmerDefaultPopup(Action<bool> callback)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("config_text_22"), SizeType.Small, bk.GetMessageByLabel("config_text_56"), new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x1B65B00
					if(type == PopupButton.ButtonType.Negative)
					{
						if (callback != null)
							callback(false);
					}
					else if(type == PopupButton.ButtonType.Positive)
					{
						if (callback != null)
							callback(true);
					}
				}, null, null, null);
		}

		//// RVA: 0x1B60B24 Offset: 0x1B60B24 VA: 0x1B60B24
		public static void PopupShowVideoQuality(Action<bool> callback)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("config_text_41"), SizeType.Small, 
				bk.GetMessageByLabel("config_text_45"), new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Change, Type = PopupButton.ButtonType.Positive }
				}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x1B65BB0
					if(type == PopupButton.ButtonType.Negative)
					{
						if(callback != null)
							callback(false);
					}
					else if(type == PopupButton.ButtonType.Positive)
					{
						if (callback != null)
							callback(true);
					}
				}, null, null, null);
		}

		//// RVA: 0x1B60E30 Offset: 0x1B60E30 VA: 0x1B60E30
		public static void PopupShowVideoDelete(Action callback)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("config_text_41"), SizeType.Small, 
				bk.GetMessageByLabel("config_text_46"), new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x1B65920
					return;
				}, null, null, null, true, true, false, null, callback);
		}
	}
}
