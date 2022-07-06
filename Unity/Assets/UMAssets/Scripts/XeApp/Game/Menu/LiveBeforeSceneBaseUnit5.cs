using System.Collections;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class LiveBeforeSceneBaseUnit5 : TransitionRoot
	{
		private struct PrefabCacheParam
		{
			public string prefabName; // 0x0
			public int count; // 0x4

			// RVA: 0x7FCACC Offset: 0x7FCACC VA: 0x7FCACC
			//public void .ctor(string prefabName, int count) { }
		}

		// protected bool m_isGotoGame; // 0x45
		private static readonly LiveBeforeSceneBaseUnit5.PrefabCacheParam[] m_prefabCacheParams = new LiveBeforeSceneBaseUnit5.PrefabCacheParam[15] {
			new PrefabCacheParam() { prefabName="SetDeckHeadButtons", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckUnitStatus", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckValkyrieButton", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckUnitInfoChangeButton", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckUnitInfo_Select", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckMusicInfo", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckPlayButtons", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckUnitSetListButtons", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckUnitSetCloseButton", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckUnitSetSelectButtons", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckUnitInfo_Edit", count=2 },
			new PrefabCacheParam() { prefabName="SetDeckLoadSaveButtons", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckPrismSettingButtons", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckUnitInfo_SLive", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckStatusWindow", count=1 }
		}; // 0x0
		// protected AOJGDNFAIJL.AMIECPBIALP m_prismData = new AOJGDNFAIJL.AMIECPBIALP(); // 0x48
		// private AOJGDNFAIJL.AMIECPBIALP m_prismLogDiffData = new AOJGDNFAIJL.AMIECPBIALP(); // 0x4C
		// private PopupMvModeSelectListSetting m_prismPopupSetting = new PopupMvModeSelectListSetting(); // 0x50
		// private List<int> m_lackDivaIds = new List<int>(); // 0x54
		// private AOJGDNFAIJL.AMIECPBIALP m_prismOriginalData = new AOJGDNFAIJL.AMIECPBIALP(); // 0x58
		// private TextPopupSetting m_textSetPrizmPopup = new TextPopupSetting(); // 0x5C
		// private PopupMvModeLackDivaSetting m_lackDivaSetting = new PopupMvModeLackDivaSetting(); // 0x60

		// protected DFKGGBMFFGB m_playerData { get; } 0x1547368

		// [IteratorStateMachineAttribute] // RVA: 0x72E4B4 Offset: 0x72E4B4 VA: 0x72E4B4
		// // RVA: 0x1547404 Offset: 0x1547404 VA: 0x1547404
		protected IEnumerator CreateUGUIObjectCache()
		{
			//0x154B8E8
			yield return AssetBundleManager.LoadUnionAssetBundle("ly/013.xab");
			int loadCount = 0;
			int reqCount = 0;
			for(int i = 0; i < m_prefabCacheParams.Length; i++)
			{
				if(!GameManager.Instance.LayoutObjectCache.IsLoadedObject(m_prefabCacheParams[i].prefabName))
				{
					StartCoroutine(GameManager.Instance.LayoutObjectCache.CreateUGUI("ly/013.xab", m_prefabCacheParams[i].prefabName, null, m_prefabCacheParams[i].count, () =>
					{
						//0x154A604
						loadCount++;
					}));
					reqCount++;
				}
			}
			while (loadCount < reqCount)
				yield return null;
			AssetBundleManager.UnloadAssetBundle("ly/013.xab", false);
		}

		// // RVA: 0x15474B0 Offset: 0x15474B0 VA: 0x15474B0 Slot: 15
		protected override void OnDeleteCache()
		{
			UnityEngine.Debug.LogError("TODO OnDeleteCache");
		}

		// // RVA: 0x154760C Offset: 0x154760C VA: 0x154760C
		// protected bool IsDifferHomeDivaModel(JLKEOGLJNOD unitData, GameSetupData.TeamInfo teamInfo, bool isGotoGame) { }

		// // RVA: 0x1547C0C Offset: 0x1547C0C VA: 0x1547C0C
		// protected void AdvanceGame(StatusData teamUnitStatus, DFKGGBMFFGB playerData, EAJCBFGKKFA friendData, LimitOverStatusData limitOverData, bool isSkip, int ticketCount, long consumeTime, JGEOBNENMAH.NEDILFPPCJF log, bool isNotUpdateProfile) { }

		// // RVA: 0x15487BC Offset: 0x15487BC VA: 0x15487BC
		// protected void UpdatePrismData(int musicId, GameSetupData.MusicInfo musicInfo) { }

		// // RVA: 0x1548820 Offset: 0x1548820 VA: 0x1548820
		protected void SetupPrismPopupSetting()
		{
			UnityEngine.Debug.LogError("TODO SetupPrismPopupSetting");
		}

		// // RVA: 0x1548D74 Offset: 0x1548D74 VA: 0x1548D74
		// protected void ShowPrismSelectPopup(PopupMvModeSelectListContent.SelectTarget target, int divaSlotNumber, int musicId, GameSetupData.MusicInfo musicInfo, bool isSimulation, Action onOK, Action onEnd) { }

		// // RVA: 0x15490A0 Offset: 0x15490A0 VA: 0x15490A0
		// protected bool OriginalPrizmApply(int musicId, GameSetupData.MusicInfo musicInfo) { }

		// // RVA: 0x15494A0 Offset: 0x15494A0 VA: 0x15494A0
		// private void ShowOriginalPrismSettingFailurePopup(List<int> divaIds) { }

		// // RVA: 0x1549668 Offset: 0x1549668 VA: 0x1549668
		// protected void ShowOriginalPrismSettingPopup(int musicId, GameSetupData.MusicInfo musicInfo, bool isSimulation, Action okCallBack) { }

		// // RVA: 0x1549810 Offset: 0x1549810 VA: 0x1549810
		// protected static bool CheckExistOriginalSetting(AOJGDNFAIJL.AMIECPBIALP prismData) { }

		// // RVA: 0x154983C Offset: 0x154983C VA: 0x154983C
		// private void SendPrismChangeLog(int musicId, GameSetupData.MusicInfo musicInfo, bool isSimulation) { }
	}
}
