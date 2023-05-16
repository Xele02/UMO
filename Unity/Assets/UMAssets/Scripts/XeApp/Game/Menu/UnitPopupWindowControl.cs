using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class UnitPopupWindowControl
	{
		private PopupUnitSaveListContentSetting m_unitSaveListSetting; // 0x8
		private PopupUnitSaveConfirmContentSetting m_unitSaveConfirmSetting; // 0xC
		private PopupAutoSettingContentSetting m_unitAutoSettingSetting; // 0x10
		private PopupSubPlateContentSetting m_subPlateSetting; // 0x14
		private TextPopupSetting m_textContentSetting; // 0x18
		private TextPopupSetting m_skillInfoContentSetting; // 0x1C
		private TextPopupSetting m_plateAllClearSetting; // 0x20
		private TextPopupSetting m_subPlateLockSetting; // 0x24

		// [IteratorStateMachineAttribute] // RVA: 0x7359F4 Offset: 0x7359F4 VA: 0x7359F4
		// RVA: 0x12475E0 Offset: 0x12475E0 VA: 0x12475E0
		public IEnumerator Initialize(GameObject parent, UnityAction action)
		{
			//0x1249C58
			MessageBank bank = MessageManager.Instance.GetBank("menu");
			m_unitSaveListSetting = new PopupUnitSaveListContentSetting();
			m_unitSaveListSetting.WindowSize = SizeType.Large;
			m_unitSaveListSetting.TitleText = bank.GetMessageByLabel("unit_popup_title_00");
			m_unitSaveConfirmSetting = new PopupUnitSaveConfirmContentSetting();
			m_unitSaveConfirmSetting.WindowSize = SizeType.Large;
			m_unitSaveListSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			m_unitAutoSettingSetting = new PopupAutoSettingContentSetting();
			m_unitAutoSettingSetting.WindowSize = SizeType.Large;
			m_unitAutoSettingSetting.TitleText = bank.GetMessageByLabel("popup_text_14");
			m_unitAutoSettingSetting.Tabs = new PopupTabButton.ButtonLabel[2]
			{
				PopupTabButton.ButtonLabel.SimpleAutoSet, PopupTabButton.ButtonLabel.NormalAutoSet
			};
			m_unitAutoSettingSetting.DefaultTab = PopupTabButton.ButtonLabel.SimpleAutoSet;
			m_subPlateSetting = new PopupSubPlateContentSetting();
			m_subPlateSetting.WindowSize = SizeType.Large;
			m_subPlateSetting.TitleText = bank.GetMessageByLabel("popup_text_17");
			m_textContentSetting = new TextPopupSetting();
			m_textContentSetting.TitleText = bank.GetMessageByLabel("popup_text_15");
			m_textContentSetting.WindowSize = SizeType.Small;
			m_textContentSetting.IsCaption = false;
			m_skillInfoContentSetting = new TextPopupSetting();
			m_skillInfoContentSetting.TitleText = bank.GetMessageByLabel("popup_text_16");
			m_skillInfoContentSetting.WindowSize = SizeType.Middle;
			m_skillInfoContentSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			m_plateAllClearSetting = new TextPopupSetting();
			m_plateAllClearSetting.TitleText = bank.GetMessageByLabel("popup_text_12");
			m_plateAllClearSetting.Text = bank.GetMessageByLabel("unit_clearplate_confirm_text");
			m_plateAllClearSetting.WindowSize = SizeType.Small;
			m_subPlateLockSetting = new TextPopupSetting();
			m_subPlateLockSetting.Text = bank.GetMessageByLabel("subplate_lock_text");
			m_subPlateLockSetting.WindowSize = SizeType.Small;
			m_subPlateLockSetting.IsCaption = false;
			m_subPlateLockSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_unitSaveListSetting.SetParent(parent.transform);
			m_unitSaveConfirmSetting.SetParent(parent.transform);
			m_unitAutoSettingSetting.SetParent(parent.transform);
			m_subPlateSetting.SetParent(parent.transform);
			yield return null;
			if (action != null)
				action();
		}

		// // RVA: 0x12476C0 Offset: 0x12476C0 VA: 0x12476C0
		// public void ShowUnitList(bool isResetPosition, UnityAction callBack, UnityAction<int> unitDatailEvent, EEDKAACNBBG musicData, EJKBKMBJMGL enemyData, EAJCBFGKKFA friendData, DFKGGBMFFGB playerData, bool isGoDiva) { }

		// // RVA: 0x1247A00 Offset: 0x1247A00 VA: 0x1247A00
		// public void ShowConfirmWindow(ConfirmType type, DFKGGBMFFGB playerData, int targetUnitId, EEDKAACNBBG musicData, EJKBKMBJMGL enemyData, EAJCBFGKKFA friendData, UnityAction onDecide, UnityAction okAction, Action onEnd, bool isGoDiva = False) { }

		// // RVA: 0x1247F64 Offset: 0x1247F64 VA: 0x1247F64
		// public void ShowSaveTextWindow(ConfirmType type, int slot, UnityAction okAction) { }

		// // RVA: 0x1248344 Offset: 0x1248344 VA: 0x1248344
		public void ShowUnitAutoSettingWindow(DFKGGBMFFGB_PlayerInfo playerData, PopupAutoSettingContent.Place place, int musicAttribute, int musicSeries, int musicID, UnityAction<PopupAutoSettingContent> okCallBack, UnityAction clearPlateCallBack, Action openEnd, KLBKPANJCPL_Score scoreInfo, bool isGoDiva)
		{
			m_unitAutoSettingSetting.Place = place;
			m_unitAutoSettingSetting.MusicAttribute = musicAttribute;
			m_unitAutoSettingSetting.MusicSeries = musicSeries;
			m_unitAutoSettingSetting.MusicID = musicID;
			m_unitAutoSettingSetting.PlayerData = playerData;
			m_unitAutoSettingSetting.OkCallBack = okCallBack;
			m_unitAutoSettingSetting.ClearPlateCallBack = clearPlateCallBack;
			m_unitAutoSettingSetting.IsGoDviva = isGoDiva;
			m_unitAutoSettingSetting.ScoreInfo = scoreInfo;
			ShowUnitAutoSettingWindow(openEnd);
		}

		// // RVA: 0x12484E8 Offset: 0x12484E8 VA: 0x12484E8
		private void ShowUnitAutoSettingWindow(Action openEnd)
		{
			m_unitAutoSettingSetting.Buttons = new ButtonInfo[3]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.PlateAllClear, Type = PopupButton.ButtonType.Other },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(m_unitAutoSettingSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1249480
				if(label == PopupButton.ButtonLabel.PlateAllClear)
				{
					OnShowClearPlateConfirm();
					return;
				}
				else if(label == PopupButton.ButtonLabel.Ok)
				{
					ILCCJNDFFOB.HHCJCDFCLOB.KHMDGNKEFOD(JpStringLiterals.StringLiteral_20864, 0, true, m_unitAutoSettingSetting.IsGoDviva, m_unitAutoSettingSetting.PlayerData.DPLBHAIKPGL_GetTeam(m_unitAutoSettingSetting.IsGoDviva).PDJEMLMOEPF_CenterDivaId);
					m_unitAutoSettingSetting.OkCallBack.Invoke(control.Content as PopupAutoSettingContent);
				}
				m_unitAutoSettingSetting.PlayerData = null;
				m_unitAutoSettingSetting.OkCallBack = null;
			}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
			{
				//0x12496F8
				m_unitAutoSettingSetting.TabCallBack.Invoke(label);
			}, null, openEnd);
			m_plateAllClearSetting.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
		}

		// // RVA: 0x12488A0 Offset: 0x12488A0 VA: 0x12488A0
		public void ShowSkillWindow(string name, string descript)
		{
			m_skillInfoContentSetting.Text = name + JpStringLiterals.StringLiteral_5812 + descript;
			PopupWindowManager.Show(m_skillInfoContentSetting, null, null, null, null);
		}

		// // RVA: 0x12489B8 Offset: 0x12489B8 VA: 0x12489B8
		private void OnShowClearPlateConfirm()
		{
			bool isGoDiva = m_unitAutoSettingSetting.IsGoDviva;
			m_plateAllClearSetting.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(m_plateAllClearSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1249968
				if(label != PopupButton.ButtonLabel.Ok)
				{
					ShowUnitAutoSettingWindow(null);
				}
				else
				{
					if(!isGoDiva)
					{
						ClearPlate();
					}
					else
					{
						GoDivaClearPlate();
					}
					m_unitAutoSettingSetting.ClearPlateCallBack.Invoke();
					m_unitAutoSettingSetting.PlayerData = null;
					m_unitAutoSettingSetting.OkCallBack = null;
				}
			}, null, null, null);
		}

		// // RVA: 0x1248C38 Offset: 0x1248C38 VA: 0x1248C38
		private void ClearPlate()
		{
			for(int i = 0; i < m_unitAutoSettingSetting.PlayerData.NBIGLBMHEDC.Count; i++)
			{
				m_unitAutoSettingSetting.PlayerData.NBIGLBMHEDC[i].MNBNLONEDPF(false);
				m_unitAutoSettingSetting.PlayerData.NBIGLBMHEDC[i].BCEJOOCGBFG(0, false);
				m_unitAutoSettingSetting.PlayerData.NBIGLBMHEDC[i].BCEJOOCGBFG(1, false);
			}
			m_unitAutoSettingSetting.PlayerData.DPLBHAIKPGL_GetTeam(false).HCDGELDHFHB();
		}

		// // RVA: 0x1248ED4 Offset: 0x1248ED4 VA: 0x1248ED4
		private void GoDivaClearPlate()
		{
			for (int i = 0; i < m_unitAutoSettingSetting.PlayerData.DPLBHAIKPGL_GetTeam(true).BCJEAJPLGMB_MainDivas.Count; i++)
			{
				FFHPBEPOMAK_DivaInfo f = m_unitAutoSettingSetting.PlayerData.DPLBHAIKPGL_GetTeam(true).BCJEAJPLGMB_MainDivas[i];
				f.CJBBDBGDFKJ(null, true);
				for (int j = 0; j < f.DJICAKGOGFO_SubSceneIds.Count; j++)
				{
					f.GIGDKIHBDHB(null, j, true);
				}
			}
			m_unitAutoSettingSetting.PlayerData.DPLBHAIKPGL_GetTeam(true).HCDGELDHFHB();
		}

		// // RVA: 0x124912C Offset: 0x124912C VA: 0x124912C
		// public void ShowSubPlateWindow(CFHDKAFLNEP result, Action openEnd, UnitWindowConstant.OperationMode opMode, Action endCallBack, Action closeCallBack, bool isReShow = False) { }

		// // RVA: 0x12493B0 Offset: 0x12493B0 VA: 0x12493B0
		// public void ShowSubPlateLockWindow(Action endCallBack) { }

		// [CompilerGeneratedAttribute] // RVA: 0x735A7C Offset: 0x735A7C VA: 0x735A7C
		// // RVA: 0x12496F8 Offset: 0x12496F8 VA: 0x12496F8
		// private void <ShowUnitAutoSettingWindow>b__13_1(IPopupContent content, PopupTabButton.ButtonLabel label) { }
	}
}
