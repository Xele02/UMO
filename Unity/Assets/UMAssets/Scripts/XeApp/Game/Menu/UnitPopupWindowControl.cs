using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace XeApp.Game.Menu
{
	public class UnitPopupWindowControl
	{
		// private PopupUnitSaveListContentSetting m_unitSaveListSetting; // 0x8
		// private PopupUnitSaveConfirmContentSetting m_unitSaveConfirmSetting; // 0xC
		// private PopupAutoSettingContentSetting m_unitAutoSettingSetting; // 0x10
		// private PopupSubPlateContentSetting m_subPlateSetting; // 0x14
		// private TextPopupSetting m_textContentSetting; // 0x18
		// private TextPopupSetting m_skillInfoContentSetting; // 0x1C
		// private TextPopupSetting m_plateAllClearSetting; // 0x20
		// private TextPopupSetting m_subPlateLockSetting; // 0x24

		// [IteratorStateMachineAttribute] // RVA: 0x7359F4 Offset: 0x7359F4 VA: 0x7359F4
		// RVA: 0x12475E0 Offset: 0x12475E0 VA: 0x12475E0
		public IEnumerator Initialize(GameObject parent, UnityAction action)
		{
			TodoLogger.Log(0, "UnitPopupWindowControl Initialize");
			action();
			yield break;
		}

		// // RVA: 0x12476C0 Offset: 0x12476C0 VA: 0x12476C0
		// public void ShowUnitList(bool isResetPosition, UnityAction callBack, UnityAction<int> unitDatailEvent, EEDKAACNBBG musicData, EJKBKMBJMGL enemyData, EAJCBFGKKFA friendData, DFKGGBMFFGB playerData, bool isGoDiva) { }

		// // RVA: 0x1247A00 Offset: 0x1247A00 VA: 0x1247A00
		// public void ShowConfirmWindow(ConfirmType type, DFKGGBMFFGB playerData, int targetUnitId, EEDKAACNBBG musicData, EJKBKMBJMGL enemyData, EAJCBFGKKFA friendData, UnityAction onDecide, UnityAction okAction, Action onEnd, bool isGoDiva = False) { }

		// // RVA: 0x1247F64 Offset: 0x1247F64 VA: 0x1247F64
		// public void ShowSaveTextWindow(ConfirmType type, int slot, UnityAction okAction) { }

		// // RVA: 0x1248344 Offset: 0x1248344 VA: 0x1248344
		// public void ShowUnitAutoSettingWindow(DFKGGBMFFGB playerData, PopupAutoSettingContent.Place place, int musicAttribute, int musicSeries, int musicID, UnityAction<PopupAutoSettingContent> okCallBack, UnityAction clearPlateCallBack, Action openEnd, KLBKPANJCPL scoreInfo, bool isGoDiva) { }

		// // RVA: 0x12484E8 Offset: 0x12484E8 VA: 0x12484E8
		// private void ShowUnitAutoSettingWindow(Action openEnd) { }

		// // RVA: 0x12488A0 Offset: 0x12488A0 VA: 0x12488A0
		// public void ShowSkillWindow(string name, string descript) { }

		// // RVA: 0x12489B8 Offset: 0x12489B8 VA: 0x12489B8
		// private void OnShowClearPlateConfirm() { }

		// // RVA: 0x1248C38 Offset: 0x1248C38 VA: 0x1248C38
		// private void ClearPlate() { }

		// // RVA: 0x1248ED4 Offset: 0x1248ED4 VA: 0x1248ED4
		// private void GoDivaClearPlate() { }

		// // RVA: 0x124912C Offset: 0x124912C VA: 0x124912C
		// public void ShowSubPlateWindow(CFHDKAFLNEP result, Action openEnd, UnitWindowConstant.OperationMode opMode, Action endCallBack, Action closeCallBack, bool isReShow = False) { }

		// // RVA: 0x12493B0 Offset: 0x12493B0 VA: 0x12493B0
		// public void ShowSubPlateLockWindow(Action endCallBack) { }

		// [CompilerGeneratedAttribute] // RVA: 0x735A6C Offset: 0x735A6C VA: 0x735A6C
		// // RVA: 0x1249480 Offset: 0x1249480 VA: 0x1249480
		// private void <ShowUnitAutoSettingWindow>b__13_0(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		// [CompilerGeneratedAttribute] // RVA: 0x735A7C Offset: 0x735A7C VA: 0x735A7C
		// // RVA: 0x12496F8 Offset: 0x12496F8 VA: 0x12496F8
		// private void <ShowUnitAutoSettingWindow>b__13_1(IPopupContent content, PopupTabButton.ButtonLabel label) { }
	}
}
