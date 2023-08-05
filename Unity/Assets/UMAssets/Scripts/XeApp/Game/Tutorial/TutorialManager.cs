using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using XeApp.Core;
using XeSys;

namespace XeApp.Game.Tutorial
{
	public class TutorialManager : SingletonBehaviour<TutorialManager>
	{
		private GameObject m_tutorialSetInstance; // 0xC
		private bool m_isWait; // 0x10
		private TutorialWindow m_window; // 0x14
		private UnityAction m_closeCallBack; // 0x18
		public static int forceShowTipsId; // 0x0

		// // RVA: 0xE4604C Offset: 0xE4604C VA: 0xE4604C
		public static void Initialize()
		{
			TutorialManager t = GameManager.Instance.gameObject.GetComponent<TutorialManager>();
			if(GameManager.Instance != null)
			{
				if (t != null)
					return;
				GameManager.Instance.gameObject.AddComponent<TutorialManager>();
			}
		}

		// // RVA: 0xE461F8 Offset: 0xE461F8 VA: 0xE461F8
		// public void PreLoadResource(UnityAction finishCb, bool isAppendLayout = False) { }

		// // RVA: 0xE462C8 Offset: 0xE462C8 VA: 0xE462C8 Slot: 6
		public virtual void Release()
		{
			if(m_tutorialSetInstance != null)
			{
				Destroy(m_tutorialSetInstance.gameObject);
				m_window = null;
				m_tutorialSetInstance = null;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6AE758 Offset: 0x6AE758 VA: 0x6AE758
		// // RVA: 0xE463C4 Offset: 0xE463C4 VA: 0xE463C4
		public static IEnumerator TryShowTutorialCoroutine(Func<TutorialConditionId, bool> checker)
		{
			PJANOOPJIDE_TutorialPict master; // 0x14
			ILDKBCLAFPB.DNLECGEBDOI_Tutorial saveData; // 0x18
			int playerRank; // 0x1C
			int saveBitIndex; // 0x20
			int index; // 0x24

			//0xE47C64
			master = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KIBMNCOLJNC_TutorialPict;
			saveData = GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial;
			playerRank = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
			saveBitIndex = 0;
			GameManager.Instance.AddPushBackButtonHandler(OnDummyBackButton);
			bool hasShown = false;
			for (index = 0; index < master.CDENCMNHNGA.Count; index++)
			{
				if(master.CDENCMNHNGA[index].PPEGAKEIEGM_Enabled > 1)
				{
					int a = master.CDENCMNHNGA[index].PPFNGGCBJKC;
					if (master.CDENCMNHNGA[index].IODLCIBCONC > 0)
						a = master.CDENCMNHNGA[index].IODLCIBCONC;
					saveBitIndex = 0;
					if(a > 63)
					{
						if ((a - 501) > 63 || (a - 501) < 0)
							continue;
						a = a - 437;
					}
					saveBitIndex = a;
					if(!saveData.INEAGJMJLFG_TutorialAlreadyFlags.ODKIHPBEOEC_IsTrue(a))
					{
						for(int i = 0; i < master.CDENCMNHNGA[index].AKBHPFBDDOL_TutoCondId.Length; i++)
						{
							if(master.CDENCMNHNGA[index].FJOLNJLLJEJ[i] <= playerRank)
							{
								if(checker((TutorialConditionId)master.CDENCMNHNGA[index].AKBHPFBDDOL_TutoCondId[i]))
								{
									Initialize();
									yield return Instance.ShowTutorialCoroutine(master.CDENCMNHNGA[index]);
									saveData.INEAGJMJLFG_TutorialAlreadyFlags.EDEDFDDIOKO_SetTrue(saveBitIndex);
									hasShown = true;
								}
							}
						}
					}
				}
			}
			if (hasShown)
			{
				GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
				Instance.Release();
			}
			GameManager.Instance.RemovePushBackButtonHandler(OnDummyBackButton);
		}

		// // RVA: 0xE46470 Offset: 0xE46470 VA: 0xE46470
		// private static bool TutorialIdToSaveBitIndex(int id, int share, out int saveBitIndex) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6AE7D0 Offset: 0x6AE7D0 VA: 0x6AE7D0
		// // RVA: 0xE464B0 Offset: 0xE464B0 VA: 0xE464B0
		public static IEnumerator ShowTutorial(int id, UnityAction endAction)
		{
			//0xE474F4
			PJANOOPJIDE_TutorialPict.HNHHGJCPMEA h = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KIBMNCOLJNC_TutorialPict.LBDOLHGDIEB(id);
			GameManager.Instance.AddPushBackButtonHandler(OnDummyBackButton);
			if(h != null && h.PPEGAKEIEGM_Enabled == 2)
			{
				Initialize();
				yield return Co.R(Instance.ShowTutorialCoroutine(h));
			}
			if (endAction != null)
				endAction();
			GameManager.Instance.RemovePushBackButtonHandler(OnDummyBackButton);
		}

		// // RVA: 0xE46578 Offset: 0xE46578 VA: 0xE46578
		private static void OnDummyBackButton()
		{
			return;
		}

		// // RVA: 0xE4657C Offset: 0xE4657C VA: 0xE4657C
		public static bool IsAlreadyTutorial(TutorialConditionId conditionId)
		{
			for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KIBMNCOLJNC_TutorialPict.CDENCMNHNGA.Count; i++)
			{
				PJANOOPJIDE_TutorialPict.HNHHGJCPMEA pic = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KIBMNCOLJNC_TutorialPict.CDENCMNHNGA[i];
				int id = pic.PPFNGGCBJKC;
				if (pic.IODLCIBCONC > 0)
					id = pic.IODLCIBCONC;
				if(id < 64)
				{
					if(pic.AKBHPFBDDOL_TutoCondId[0] == (int)conditionId)
					{
						if (!GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.INEAGJMJLFG_TutorialAlreadyFlags.ODKIHPBEOEC_IsTrue(id))
							return false;
					}
				}
				else if((id >= 501 && id < 565))
				{
					id -= 437;
					if (pic.AKBHPFBDDOL_TutoCondId[0] == (int)conditionId)
					{
						if (!GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.INEAGJMJLFG_TutorialAlreadyFlags.ODKIHPBEOEC_IsTrue(id))
							return false;
					}
				}
			}
			return true;
		}

		// // RVA: 0xE46958 Offset: 0xE46958 VA: 0xE46958
		// public static bool IsAlreadyTutorial(int tutorialId) { }

		// // RVA: 0xE46B6C Offset: 0xE46B6C VA: 0xE46B6C
		// private bool CheckTutorialCondition(TutorialConditionId condition, Func<TutorialConditionId, bool> checker) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6AE848 Offset: 0x6AE848 VA: 0x6AE848
		// // RVA: 0xE46BE8 Offset: 0xE46BE8 VA: 0xE46BE8
		public IEnumerator ShowTutorialCoroutine(PJANOOPJIDE_TutorialPict.HNHHGJCPMEA messData)
		{
			//0xE478A4
			if(m_tutorialSetInstance == null)
			{
				bool isWait = true;
				yield return this.StartCoroutineWatched(PreLoadLayoutCoroutine(() =>
				{
					//0xE46DF4
					isWait = false;
				}, false));
				while (isWait)
					yield return null;
			}
			//LAB_00e47a44
			{
				bool isWait = true;
				m_window.SetMessageData(messData);
				m_window.gameObject.SetActive(true);
				m_window.Show(() =>
				{
					//0xE46E08
					isWait = false;
				}, true);
				while (isWait)
					yield return null;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6AE8C0 Offset: 0x6AE8C0 VA: 0x6AE8C0
		// // RVA: 0xE46220 Offset: 0xE46220 VA: 0xE46220
		private IEnumerator PreLoadLayoutCoroutine(UnityAction finishCb, bool isAppendLayout = false)
		{
			//0xE473AC
			yield return this.StartCoroutineWatched(LoadBaseLayoutCoroutine());
			if (finishCb != null)
				finishCb();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6AE938 Offset: 0x6AE938 VA: 0x6AE938
		// // RVA: 0xE46CD0 Offset: 0xE46CD0 VA: 0xE46CD0
		private IEnumerator LoadBaseLayoutCoroutine()
		{
			int loadCount; // 0x14
			AssetBundleLoadLayoutOperationBase op; // 0x18

			//0xE46E18
			if(m_tutorialSetInstance == null)
			{
				loadCount = 0;
				op = AssetBundleManager.LoadLayoutAsync("ly/093.xab", "root_cmn_tuto03_window_layout_root");
				yield return op;
				yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0xE46DE4
					m_tutorialSetInstance = instance;
				}));
				loadCount++;
				while (m_tutorialSetInstance == null)
					yield return null;
				for (int i = 0; i < loadCount; i++)
					AssetBundleManager.UnloadAssetBundle("ly/093.xab", false);
			}
			m_tutorialSetInstance.gameObject.SetActive(false);
			m_tutorialSetInstance.transform.SetParent(GameManager.Instance.PopupCanvas.transform.Find("Root"), false);
			m_tutorialSetInstance.transform.SetAsLastSibling();
			m_window = m_tutorialSetInstance.GetComponent<TutorialWindow>();
		}
	}

	public enum TutorialConditionId
	{
		None = 0,
		Condition1 = 1,
		Condition2 = 2,
		Condition3 = 3,
		Condition4 = 4,
		Condition5 = 5,
		Condition6 = 6,
		Condition7 = 7,
		Condition8 = 8,
		Condition9 = 9,
		Condition10 = 10,
		Condition11 = 11,
		Condition12 = 12,
		Condition13 = 13,
		Condition14 = 14,
		Condition15 = 15,
		Condition16 = 16,
		Condition17 = 17,
		Condition18 = 18,
		Condition19 = 19,
		Condition20 = 20,
		Condition21 = 21,
		Condition22 = 22,
		Condition23 = 23,
		Condition24 = 24,
		Condition25 = 25,
		Condition26 = 26,
		Condition27 = 27,
		Condition28 = 28,
		Condition29 = 29,
		Condition30 = 30,
		Condition31 = 31,
		Condition32 = 32,
		Condition33 = 33,
		Condition34 = 34,
		Condition35 = 35,
		Condition36 = 36,
		Condition37 = 37,
		Condition38 = 38,
		Condition39 = 39,
		Condition40 = 40,
		Condition41 = 41,
		Condition42 = 42,
		Condition43 = 43,
		Condition44 = 44,
		Condition45 = 45,
		Condition46 = 46,
		Condition47 = 47,
		Condition48 = 48,
		Condition49 = 49,
		Condition50 = 50,
		Condition51 = 51,
		Condition52 = 52,
		Condition53 = 53,
		Condition54 = 54,
		Condition55 = 55,
		Condition56 = 56,
		Condition57 = 57,
		Condition58 = 58,
		Condition59 = 59,
		Condition60 = 60,
		Condition61 = 61,
		Condition62 = 62,
		Condition63 = 63,
		Condition64 = 64,
		Condition65 = 65,
		Condition66 = 66,
		Condition67 = 67,
		Condition68 = 68,
		Condition69 = 69,
		Condition70 = 70,
		Condition71 = 71,
		Condition72 = 72,
		Condition73 = 73,
		Condition74 = 74,
		Condition75 = 75,
		Condition76 = 76,
		Condition77 = 77,
		Condition78 = 78,
		Condition79 = 79,
		Condition80 = 80,
		Condition81 = 81,
		Condition82 = 82,
		Condition83 = 83,
		Condition84 = 84,
		Condition85 = 85,
		Condition86 = 86,
		Condition87 = 87,
		Condition88 = 88,
		Condition89 = 89,
		Condition90 = 90,
		Condition91 = 91,
		Condition92 = 92,
		Condition93 = 93,
		Condition94 = 94,
		SaveDataBitArrayPrevSize = 64,
		SaveDataBitArrayAddedSize = 64,
		SaveDataBitArraySize = 128,
		TutorialIdSaveOffset = 501,
		Condition95 = 95,
		Condition96 = 96,
	}

}
