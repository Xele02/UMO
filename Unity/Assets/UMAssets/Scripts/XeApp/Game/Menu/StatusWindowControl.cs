using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace XeApp.Game.Menu
{
	public class StatusWindowControl
	{
		// private Dictionary<int, List<StatusPopupState>> m_popStateDict = new Dictionary<int, List<StatusPopupState>>(); // 0x8
		// private int m_historyPosition; // 0xC
		// public DivaStatePopupSetting m_divaStatePopup; // 0x10
		// public SceneStatePopupSetting m_sceneStatePopup; // 0x14

		// [IteratorStateMachineAttribute] // RVA: 0x7354B4 Offset: 0x7354B4 VA: 0x7354B4
		// RVA: 0x12E147C Offset: 0x12E147C VA: 0x12E147C
		public IEnumerator Initialize(GameObject parent, UnityAction action)
		{
			UnityEngine.Debug.LogError("TODO StatusWindowControl Initialize");
			action();
			yield break;
		}

		// // RVA: 0x12E155C Offset: 0x12E155C VA: 0x12E155C
		public void ResetHistory()
		{
			UnityEngine.Debug.LogError("TODO StatusWindowControl ResetHistory");
		}

		// // RVA: 0x12E1708 Offset: 0x12E1708 VA: 0x12E1708
		// public void ShowDivaStatusPopupWindow(FFHPBEPOMAK diva, DFKGGBMFFGB playerData, EAJCBFGKKFA friendData, EEDKAACNBBG musicData, bool isMoment, TransitionList.Type transitionName = -2, Action callBack, bool isFriend = False, bool isChangeScene = True, bool isCloseOnly = False, int divaSlotNumber = -1, bool isGoDiva = False) { }

		// // RVA: 0x12E21FC Offset: 0x12E21FC VA: 0x12E21FC
		// public void ShowSceneStatusPopupWindow(GCIJNCFDNON scene, DFKGGBMFFGB playerData, bool isMoment, TransitionList.Type transitionName = -2, Action callBack, bool isFriend = False, bool isReward = False, SceneStatusParam.PageSave pageSave = 1, bool isDisableZoom = False) { }

		// // RVA: 0x12E2978 Offset: 0x12E2978 VA: 0x12E2978
		// public void TryShowPopupWindow(DFKGGBMFFGB viewPlayerData, EEDKAACNBBG musicData, bool isMoment, TransitionList.Type transitionName, Action closeCallBack) { }
	}
}
