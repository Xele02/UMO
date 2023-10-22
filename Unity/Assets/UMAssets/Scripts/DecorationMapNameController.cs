using System;
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys;

public class DecorationMapNameController : MonoBehaviour
{
	private const int MapNameMaxLength = 10;
	private InputPopupSetting m_inputMapNamePopupSetting = new InputPopupSetting(); // 0xC
	private TextPopupSetting m_changedMapNamePopupSetting = new TextPopupSetting(); // 0x10
	private TextPopupSetting m_notChangedMapNamePopupSetting = new TextPopupSetting(); // 0x14
	private string m_newName; // 0x18
	private bool m_IsWait; // 0x1C
	private string m_name; // 0x20
	public Action<string> ChangeMapNameCallback; // 0x24
	public Action NoChangeMapNameCallback; // 0x28
	public Action<bool> DecoTapGuardCallback; // 0x2C

	// RVA: 0x123F984 Offset: 0x123F984 VA: 0x123F984
	private void Awake()
	{
		m_notChangedMapNamePopupSetting = PopupWindowManager.CrateTextContent(
			MessageManager.Instance.GetMessage("common", "popup_ngword_error_title"),
			SizeType.Small, MessageManager.Instance.GetMessage("menu", "pop_deco_name_change_cancel"),
			new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, true
		);
		m_inputMapNamePopupSetting = new InputPopupSetting();
		m_inputMapNamePopupSetting.TitleText = MessageManager.Instance.GetMessage("menu", "pop_deco_name_change_title");
		m_inputMapNamePopupSetting.InputText = m_name;
		m_inputMapNamePopupSetting.CharacterLimit = 10;
		m_inputMapNamePopupSetting.WindowSize = SizeType.Middle;
		m_inputMapNamePopupSetting.Description = MessageManager.Instance.GetMessage("menu", "pop_deco_name_change_desc");
		m_inputMapNamePopupSetting.Notes = MessageManager.Instance.GetMessage("menu", "pop_deco_name_change_notes");
		m_inputMapNamePopupSetting.Buttons = new ButtonInfo[2]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		m_changedMapNamePopupSetting = new TextPopupSetting();
		m_changedMapNamePopupSetting.TitleText = MessageManager.Instance.GetMessage("menu", "pop_deco_name_change_title");
		m_changedMapNamePopupSetting.WindowSize = SizeType.Small;
		m_changedMapNamePopupSetting.Text = MessageManager.Instance.GetMessage("menu", "pop_deco_name_change_text");
		m_changedMapNamePopupSetting.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
	}

	// RVA: 0x1240078 Offset: 0x1240078 VA: 0x1240078
	public void MapNameEdit(string name, Action<string> changeMapNameCallback, Action noChangeMapNameCallback)
	{
		m_IsWait = false;
		m_name = name;
		ChangeMapNameCallback = changeMapNameCallback;
		NoChangeMapNameCallback = noChangeMapNameCallback;
		DecoTapGuardCallback = (bool _) =>
		{
			//0x12407CC
			return;
		};
		this.StartCoroutineWatched(Co_MapNameEdit());
	}

	// // RVA: 0x1240268 Offset: 0x1240268 VA: 0x1240268
	// private void OnClickMapNameEditButton() { }

	// [IteratorStateMachineAttribute] // RVA: 0x68FCDC Offset: 0x68FCDC VA: 0x68FCDC
	// // RVA: 0x12401DC Offset: 0x12401DC VA: 0x12401DC
	private IEnumerator Co_MapNameEdit()
	{
		//0x1240D0C
		bool isClose = false;
		bool isDecide = false;
		string inputText = "";
		m_inputMapNamePopupSetting.InputText = m_name;
		PopupWindowManager.Show(m_inputMapNamePopupSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
		{
			//0x12407D8
			if(type == PopupButton.ButtonType.Positive)
			{
				isDecide = true;
				inputText = (control.Content as InputContent).Text;
				MenuScene.Instance.InputDisable();
				DecoTapGuardCallback(true);
			}
			isClose = true;
		}, null, null, null);
		yield return new WaitUntil(() =>
		{
			//0x12409B0
			return isClose;
		});
		if(!isDecide)
		{
			NoChangeMapNameCallback();
		}
		else
		{
			if(m_name != inputText)
			{
				BHLFHHBDGHO.GEJEDJNKBOF(inputText, () =>
				{
					//0x12409B8
					MenuScene.Instance.InputEnable();
					DecoTapGuardCallback(false);
					ChangeMapNameCallback(inputText);
				}, () =>
				{
					//0x1240AE4
					MenuScene.Instance.InputEnable();
					DecoTapGuardCallback(false);
					NoChangeMapNameCallback();
				}, () =>
				{
					//0x1240BFC
					DecoTapGuardCallback(false);
					MenuScene.Instance.GotoTitle();
				});
			}
			else
			{
				MenuScene.Instance.InputEnable();
				DecoTapGuardCallback(false);
				ChangeMapName(false);
			}
		}
	}

	// // RVA: 0x124028C Offset: 0x124028C VA: 0x124028C
	public void ChangeMapName(bool isSaveSuccess)
	{
		if(isSaveSuccess)
		{
			MenuScene.Instance.InputDisable();
			DecoTapGuardCallback(true);
			PopupWindowManager.Show(m_changedMapNamePopupSetting, (PopupWindowControl _control, PopupButton.ButtonType _btnType, PopupButton.ButtonLabel _btnLabel) =>
			{
				//0x1240638
				DecoTapGuardCallback(false);
			}, null, null, MenuScene.Instance.InputEnable);
		}
		else
		{
			MenuScene.Instance.InputDisable();
			DecoTapGuardCallback(true);
			PopupWindowManager.Show(m_notChangedMapNamePopupSetting, (PopupWindowControl _control, PopupButton.ButtonType _btnType, PopupButton.ButtonLabel _btnLabel) =>
			{
				//0x12406B4
				DecoTapGuardCallback(false);
				NoChangeMapNameCallback();
			}, null, null, MenuScene.Instance.InputEnable);
		}
	}
}
