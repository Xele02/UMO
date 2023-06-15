using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;

namespace XeApp.Game.Menu
{
	public class CostumeUpgradeScene : TransitionRoot
	{
		private const int MakinaId = 4;
		private const int CostumeModelId = 1;
		private List<string> m_motionListName = new List<string>(); // 0x48
		private List<string> m_loopMotionListName = new List<string>(); // 0x4C
		private Action m_updater; // 0x50
		private List<int> m_divaIndexList = new List<int>(); // 0x54
		private DivaResource m_divaResource; // 0x58
		private CostumeUpgradeDivaController m_divaController; // 0x5C
		[SerializeField] // RVA: 0x66B5C8 Offset: 0x66B5C8 VA: 0x66B5C8
		private CharTouchHitCheck m_charTouch; // 0x60
		private const string BundleName = "ly/128.xab";
		private bool m_isLoadModel; // 0x64
		private bool m_isSuccess; // 0x65
		private bool m_isTutorial; // 0x66
		private bool m_isLoadingDivaResource; // 0x67
		private CostumeUpgradeCostumeSelect m_costumeSelect; // 0x68

		//private DFKGGBMFFGB_PlayerInfo PlayerData { get; } 0x16F70F8

		// RVA: 0x16F7194 Offset: 0x16F7194 VA: 0x16F7194 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			string[] strs = new string[] { "diva_{0:D3}_menu_simple_loop02_{1}" };
			for(int i = 0; i < strs.Length; i++)
			{
				m_loopMotionListName.Add(strs[i]);
			}
			m_divaController = GetComponent<CostumeUpgradeDivaController>();
			this.StartCoroutineWatched(Co_Initilize());
		}

		// RVA: 0x16F73BC Offset: 0x16F73BC VA: 0x16F73BC Slot: 5
		protected override void Start()
		{
			return;
		}

		//// RVA: 0x16F73C0 Offset: 0x16F73C0 VA: 0x16F73C0
		private void DivaTouch()
		{
			m_divaController.StartTouchMotion();
		}

		// RVA: 0x16F73E8 Offset: 0x16F73E8 VA: 0x16F73E8
		private void Update()
		{
			if(m_costumeSelect != null)
				m_costumeSelect.Update();
			if (m_updater != null)
				m_updater();
		}

		//// RVA: 0x16F74AC Offset: 0x16F74AC VA: 0x16F74AC
		private void UpdateEntryWait()
		{
			if (m_divaController.IsPlayingEntry())
				return;
			m_updater = UpdateIdle;
		}

		//// RVA: 0x16F7558 Offset: 0x16F7558 VA: 0x16F7558
		private void UpdateIdle()
		{
			m_divaController.UpdateIntervalMotion();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CEFB4 Offset: 0x6CEFB4 VA: 0x6CEFB4
		//// RVA: 0x16F7330 Offset: 0x16F7330 VA: 0x16F7330
		private IEnumerator Co_Initilize()
		{
			//0x16F81A4
			yield return AssetBundleManager.LoadUnionAssetBundle("ly/128.xab");
			yield return this.StartCoroutineWatched(Co_LoadCostumeLayout());
			m_charTouch.OnClickCallback = DivaTouch;
			IsReady = true;
		}

		// RVA: 0x16F75A0 Offset: 0x16F75A0 VA: 0x16F75A0 Slot: 16
		protected override void OnPreSetCanvas()
		{
			bool b = false;
			if(PrevTransition == TransitionList.Type.COSTUME_UPGRADE_ITEM_SELECT)
			{
				b = m_costumeSelect.isPrevCostumeSelect;
			}
			else
			{
				if (PrevTransition == TransitionList.Type.COSTUME_SELECT)
					b = true;
			}
			m_costumeSelect.isPrevCostumeSelect = b;
			m_costumeSelect.Init();
			m_costumeSelect.TryInstall();
			m_divaController.TryInstall(4, 1);
		}

		// RVA: 0x16F7670 Offset: 0x16F7670 VA: 0x16F7670 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// RVA: 0x16F7710 Offset: 0x16F7710 VA: 0x16F7710 Slot: 18
		protected override void OnPostSetCanvas()
		{
			if (Args != null)
			{
				CostumeUpgradeArgs a = Args as CostumeUpgradeArgs;
				m_costumeSelect.SetFocus(a.divaId, a.costumemModelId, true);
			}
		}

		// RVA: 0x16F780C Offset: 0x16F780C VA: 0x16F780C Slot: 14
		protected override void OnDestoryScene()
		{
			m_divaController.StopVoice();
			m_costumeSelect.SaveSelectDiva();
			if(!m_costumeSelect.isItemSelectScene || !m_isSuccess)
			{
				m_divaController.Release();
				m_isLoadModel = false;
			}
			else
			{
				m_divaController.SetVisible(false);
				m_divaController.DestoryCamera();
			}
			if(m_isLoadingDivaResource)
			{
				m_isLoadingDivaResource = false;
				MenuScene.Instance.InputEnable();
			}
			m_updater = null;
		}

		// RVA: 0x16F798C Offset: 0x16F798C VA: 0x16F798C Slot: 15
		protected override void OnDeleteCache()
		{
			AssetBundleManager.UnloadAssetBundle("ly/128.xab", false);
			SoundResource.RemoveCueSheet("cs_cosupg");
		}

		// RVA: 0x16F7A60 Offset: 0x16F7A60 VA: 0x16F7A60 Slot: 23
		protected override void OnActivateScene()
		{
			if (!m_isTutorial)
				return;
			this.StartCoroutineWatched(Co_OnTutorial());
		}

		// RVA: 0x16F7B20 Offset: 0x16F7B20 VA: 0x16F7B20 Slot: 29
		protected override void InputEnable()
		{
			base.InputEnable();
			if (InputStateCount > 0)
				return;
			m_costumeSelect.ScrollerInputEnable(true);
		}

		// RVA: 0x16F7B6C Offset: 0x16F7B6C VA: 0x16F7B6C Slot: 30
		protected override void InputDisable()
		{
			base.InputDisable();
			m_costumeSelect.m_scroller.InputDisable();
		}

		// RVA: 0x16F7BB4 Offset: 0x16F7BB4 VA: 0x16F7BB4 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_isTutorial = CanShowTutorial();
			m_costumeSelect.Enter();
			this.StartCoroutineWatched(Co_LoadResource());
		}

		// RVA: 0x16F7DE4 Offset: 0x16F7DE4 VA: 0x16F7DE4 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return m_costumeSelect.IsPlayingEnd();
		}

		// RVA: 0x16F7E0C Offset: 0x16F7E0C VA: 0x16F7E0C Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_costumeSelect.Leave();
		}

		// RVA: 0x16F7E34 Offset: 0x16F7E34 VA: 0x16F7E34 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return m_costumeSelect.IsPlayingEnd();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CF02C Offset: 0x6CF02C VA: 0x6CF02C
		//// RVA: 0x16F7E5C Offset: 0x16F7E5C VA: 0x16F7E5C
		private IEnumerator Co_LoadCostumeLayout()
		{
			//0x16F83F4
			m_costumeSelect = transform.Find("CostumeUpgradeCostumeSelect").GetComponent<CostumeUpgradeCostumeSelect>();
			yield return new WaitUntil(() =>
			{
				//0x16F80CC
				return m_costumeSelect.IsLoaded();
			});
			yield return new WaitUntil(() =>
			{
				//0x16F80F8
				return m_costumeSelect.m_scroller.IsLoaded();
			});
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CF0A4 Offset: 0x6CF0A4 VA: 0x6CF0A4
		//// RVA: 0x16F7F08 Offset: 0x16F7F08 VA: 0x16F7F08
		private IEnumerator Co_LoadDivaResource()
		{
			//0x16F86F0
			m_divaController.Initialize(CostumeUpgradeDivaController.Controlype.CostumeSelect, 4, 1, 0);
			yield return new WaitUntil(() =>
			{
				//0x16F8138
				return m_costumeSelect.IsPlayingEnd();
			});
			yield return new WaitUntil(() =>
			{
				//0x16F8160
				return m_isTutorial;
			});
			if(m_isLoadModel)
			{
				m_divaController.StopMotion();
			}
			else
			{
				m_isLoadingDivaResource = true;
				MenuScene.Instance.InputDisable();
				m_divaController.LoadDivaResource();
				yield return new WaitUntil(() =>
				{
					//0x16F8168
					return m_divaController.isLoadedModel;
				});
				MenuScene.Instance.InputEnable();
				m_isLoadingDivaResource = false;
			}
			m_divaController.StartEntryMotion();
			m_divaController.SetVisible(true);
			m_costumeSelect.SettingDivaFilter();
			m_isLoadModel = true;
			m_updater = UpdateEntryWait;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CF11C Offset: 0x6CF11C VA: 0x6CF11C
		//// RVA: 0x16F7D58 Offset: 0x16F7D58 VA: 0x16F7D58
		private IEnumerator Co_LoadResource()
		{
			//0x16F8BE4
			m_isSuccess = false;
			yield return this.StartCoroutineWatched(Co_LoadDivaResource());
			m_isSuccess = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CF194 Offset: 0x6CF194 VA: 0x6CF194
		//// RVA: 0x16F7A94 Offset: 0x16F7A94 VA: 0x16F7A94
		private IEnumerator Co_OnTutorial()
		{
			//0x16F8D48
			MenuScene.Instance.InputDisable();
			yield return Co.R(TutorialProc.Co_CostumeUpgrade(EBFLJMOCLNA_Costume.NDOPBOCEPJO.LEHHJINPFHA, null, BasicTutorialMessageId.Id_CostumeUpgradeSelect, InputLimitButton.None, TutorialPointer.Direction.Normal));
			yield return TutorialManager.ShowTutorial(50, null);
			bool isWait = true;
			MenuScene.Save(() =>
			{
				//0x16F8194
				isWait = false;
			}, null);
			while (isWait)
				yield return null;
			MenuScene.Instance.InputEnable();
			m_isTutorial = false;
		}

		//// RVA: 0x16F7C00 Offset: 0x16F7C00 VA: 0x16F7C00
		private bool CanShowTutorial()
		{
			if(MOEALEGLGCH.CDOCOLOKCJK())
			{
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume.MLBBKNLPBBD_IsTutoDone(0))
				{
					if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume.MLBBKNLPBBD_IsTutoDone(1))
					{
						return !CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume.MLBBKNLPBBD_IsTutoDone(2);
					}
				}
			}
			return false;
		}
	}
}
