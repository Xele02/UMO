using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.DownLoad
{
	public class DivaSelectScene : MainSceneBase
	{
		private LayoutDownLoad m_Layout; // 0x28
		private LayoutDownLoadPopup m_LayoutPopup; // 0x2C
		private int m_SelectDivaId = -1; // 0x30
		private const int KanameId = 3;
		private List<int> m_kickDivaId = new List<int> { 8, 9 }; // 0x34
		private TextPopupSetting m_popupSetting = new TextPopupSetting(); // 0x38
		private StringBuilder m_strBuilder = new StringBuilder(); // 0x3C
		private UnlockDivaManager _unlockManager; // 0x40
		private static readonly string[] DivaTitleTable = new string[10]
		{
			"{0}",
			JpStringLiterals.StringLiteral_14769,
			JpStringLiterals.StringLiteral_14769,
			JpStringLiterals.StringLiteral_14769,
			JpStringLiterals.StringLiteral_14769,
			JpStringLiterals.StringLiteral_14769,
			JpStringLiterals.StringLiteral_14769,
			JpStringLiterals.StringLiteral_14769,
			JpStringLiterals.StringLiteral_14769,
			JpStringLiterals.StringLiteral_14769
		}; // 0x0

		// RVA: 0x11B9658 Offset: 0x11B9658 VA: 0x11B9658
		public void OnDestroy()
		{
			if(DownLoadUIManager.Instance != null)
			{
				Destroy(DownLoadUIManager.Instance.gameObject);
			}
		}

		// RVA: 0x11B9954 Offset: 0x11B9954 VA: 0x11B9954 Slot: 9
		protected override void DoAwake()
		{
			base.DoAwake();
			this.StartCoroutineWatched(Initialize());
		}

		// RVA: 0x11B9A10 Offset: 0x11B9A10 VA: 0x11B9A10 Slot: 12
		protected override bool DoUpdateEnter()
		{
			if(m_Layout != null)
			{
				if(m_Layout.IsReady())
				{
					this.StartCoroutineWatched(StartSequence());
					return true;
				}
			}
			return false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B4BF8 Offset: 0x6B4BF8 VA: 0x6B4BF8
		// // RVA: 0x11B9984 Offset: 0x11B9984 VA: 0x11B9984
		private IEnumerator Initialize()
		{
			DownLoadUIManager inst;

			//0x11BBC5C
			inst = DownLoadUIManager.Instance;
			if(!inst.IsLoadedLayout)
			{
				List<int> l = new List<int>();
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
				{
					for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas.Count; i++)
					{
                        BJPLLEBHAGO_DivaInfo diva = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas[i];
						if(diva.PPEGAKEIEGM_Enabled == 2)
						{
							l.Add(diva.AHHJLDLAPAN_DivaId);
						}
                    }
					for(int i = 0; i < m_kickDivaId.Count; i++)
					{
						l.Remove(m_kickDivaId[i]);
					}
				}
				inst.LoadResouce(l);
				while(!inst.IsLoadedLayout)
					yield return null;
			}
			if(m_LayoutPopup == null)
			{
				GameObject obj = null;
				ResourcesManager.Instance.Load("Layout/sel_chara/UI_DivaSelectPopup", (FileResultObject fo) =>
				{
					//0x11BB170
					obj = Instantiate(fo.unityObject) as GameObject;
					return true;
				});
				while(obj == null)
					yield return null;
				obj.transform.SetParent(inst.UIRoot.transform, false);
				yield return null;
				m_LayoutPopup = obj.GetComponentInChildren<LayoutDownLoadPopup>();
				yield return new WaitWhile(() =>
				{
					//0x11BB040
					return !m_LayoutPopup.IsReady();
				});
			}
			//LAB_011bc258
			m_Layout = inst.Layout;
			m_Layout.SetupDivaSelect();
			m_Layout.OnClickOk = OnClickOk;
			m_LayoutPopup.OnClickCancel = OnClickCancel;
			m_LayoutPopup.OnClickDecide = OnClickDecide;
			enableFade = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B4C70 Offset: 0x6B4C70 VA: 0x6B4C70
		// // RVA: 0x11B9B40 Offset: 0x11B9B40 VA: 0x11B9B40
		private IEnumerator StartSequence()
		{
			//0x11BD050
			m_Layout.EnterDivaSelect();
			m_Layout.EnterVoiceButton();
			yield return new WaitWhile(() =>
			{
				//0x11BB0EC
				return GameManager.IsFading();
			});
			m_Layout.SetEnabledOperation(false, false);
			yield return null;
			yield return new WaitWhile(() =>
			{
				return false;
			});
			bool is_close = false;
			BasicTutorialManager.Instance.ShowMessageWindow(BasicTutorialMessageId.Id_DivaSelect, () =>
			{
				//0x11BB294
				is_close = true;
			}, null);
			yield return new WaitWhile(() =>
			{
				//0x11BB2A0
				return !is_close;
			});
			m_Layout.SetEnabledOperation(true, false);
			m_Layout.PlayStartVoice();
		}

		// // RVA: 0x11B9C0C Offset: 0x11B9C0C VA: 0x11B9C0C
		private void OnClickOk()
		{
			m_SelectDivaId = m_Layout.GetSelectDivaId();
			this.StartCoroutineWatched(Co_SelectDivaConfirm());
		}

		// // RVA: 0x11B9D90 Offset: 0x11B9D90 VA: 0x11B9D90
		private void OnClickCancel()
		{
			m_Layout.SwaipTouch.enabled = true;
			m_Layout.SetButtonEnable();
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
		}

		// // RVA: 0x11B9FC8 Offset: 0x11B9FC8 VA: 0x11B9FC8
		private void OnClickDecide()
		{
			DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo diva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(1);
			diva.CPGFPEDMDEH_Have = 0;
			diva.BEEAIAAJOHD_CostumeId = 0;
			diva.AFNIOJHODAG_CostumeColorId = 0;
			int mslot = diva.PIGLAEFPNEK_MSlot;
			diva.PIGLAEFPNEK_MSlot = 0;
			int id = m_Layout.GetSelectDivaId();
            diva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(id);
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.NGJEPEPIHIL(id);
			diva.PIGLAEFPNEK_MSlot = mslot;
			m_Layout.SetEnabledOperation(false, false);
			PNGOLKLFFLH p = new PNGOLKLFFLH();
			p.KHEKNNFCAOI_Init(BBHNACPENDM_ServerSaveData.FBFCCLFFIAF, 0, 0);
			this.StartCoroutineWatched(Co_Install(id, BBHNACPENDM_ServerSaveData.FBFCCLFFIAF, p.OPBPKNHIPPE_Pilot.PFGJJLGLPAC_PilotId));
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
        }

		// [IteratorStateMachineAttribute] // RVA: 0x6B4CE8 Offset: 0x6B4CE8 VA: 0x6B4CE8
		// // RVA: 0x11B9D04 Offset: 0x11B9D04 VA: 0x11B9D04
		private IEnumerator Co_SelectDivaConfirm()
		{
			//0x11BB764
			m_Layout.SetButtonDisable();
			m_Layout.SwaipTouch.enabled = false;
			bool is_close = false;
			BasicTutorialManager.Instance.ShowMessageWindow(BasicTutorialMessageId.Id_DecideDiva, () =>
			{
				//0x11BB2BC
				is_close = true;
			}, TagConvertFunc);
			yield return new WaitWhile(() =>
			{
				//0x11BB2C8
				return !is_close;
			});
			FFHPBEPOMAK_DivaInfo diva = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas.Where((FFHPBEPOMAK_DivaInfo _) =>
			{
				//0x11BB2DC
				return m_Layout.GetSelectDivaId() == _.AHHJLDLAPAN_DivaId;
			}).First();
			GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
			m_LayoutPopup.Show(diva.OPFGFINHFCE_Name);
		}

		// // RVA: 0x11BA530 Offset: 0x11BA530 VA: 0x11BA530
		private void OnBackButton()
		{
			m_LayoutPopup.PerformClickCancel();
		}

		// // RVA: 0x11BA55C Offset: 0x11BA55C VA: 0x11BA55C
		private string TagConvertFunc(string tag)
		{
			if(tag == "SelDiva")
			{
				m_strBuilder.SetFormat("diva_s_{0:D2}", m_SelectDivaId);
				m_strBuilder.SetFormat(DivaTitleTable[m_SelectDivaId - 1], MessageManager.Instance.GetMessage("master", m_strBuilder.ToString()));
				return m_strBuilder.ToString();
			}
			return "";
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B4D60 Offset: 0x6B4D60 VA: 0x6B4D60
		// // RVA: 0x11BA438 Offset: 0x11BA438 VA: 0x11BA438
		private IEnumerator Co_Install(int divaId, int valkyrieId, int pilotId)
		{
			//0x11BB370
			KDLPEDBKMID.HHCJCDFCLOB.NMFCNFFFMAC_InstallDivaCostume(divaId, 1, true);
			KDLPEDBKMID.HHCJCDFCLOB.CKANBNPEIJD(valkyrieId, pilotId);
			bool isWait = true;
			SoundManager.Instance.RequestEntryMenuCueSheet(() =>
			{
				//0x11BB34C
				isWait = false;
			});
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			while(isWait)
				yield return null;
			yield return this.StartCoroutineWatched(StartDivaGet(divaId));
			UnlockFadeManager.Release();
			GotoAdventure();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B4DD8 Offset: 0x6B4DD8 VA: 0x6B4DD8
		// // RVA: 0x11BA800 Offset: 0x11BA800 VA: 0x11BA800
		private IEnumerator StartDivaGet(int divaId)
		{
			string bundleName; // 0x1C
			AssetBundleLoadAssetOperation op; // 0x20
			LayoutLogoCutin effect; // 0x24
			UnityAction onOk; // 0x28

			//0x11BC76C
			bundleName = "ly/084.xab";
			op = AssetBundleManager.LoadAssetAsync(bundleName, "UnlockDivaManager", typeof(GameObject));
			yield return op;
			GameObject g = Instantiate(op.GetAsset<GameObject>());
			g.transform.SetParent(m_Layout.transform.parent, false);
			_unlockManager = g.GetComponent<UnlockDivaManager>();
			BasicTutorialManager.Log(OAGBCBBHMPF.OGBCFNIKAFI.FFFHCFBMHDD_34);
			int serie = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[divaId - 1].AIHCEGFANAM_Serie;
			UnlockFadeManager.Create();
			this.StartCoroutineWatched(UnlockFadeManager.Instance.Co_LoadFadeEffect(serie));
			_unlockManager.InitializeLayoutResource();
			_unlockManager.InitializeResource(divaId);
			while(!UnlockFadeManager.Instance.IsLoaded())
				yield return null;
			UnlockFadeManager.Instance.GetEffect().Enter();
			while(!_unlockManager.IsLoaded3dResource)
				yield return null;
			while(!_unlockManager.IsLoadedLayout)
				yield return null;
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			effect = UnlockFadeManager.Instance.GetEffect();
			while(effect.IsPlaying())
				yield return null;
			m_Layout.gameObject.SetActive(false);
			_unlockManager.StartDirection();
			bool isWait = true;
			onOk = () =>
			{
				//0x11BB360
				isWait = false;
			};
			_unlockManager.PushOkButtonHandler += onOk;
			while(isWait)
				yield return null;
			_unlockManager.PushOkButtonHandler -= onOk;
			_unlockManager.OkButtonOff();
		}

		// // RVA: 0x11BA8C8 Offset: 0x11BA8C8 VA: 0x11BA8C8
		private void GotoAdventure() 
		{
			GameManager.Instance.ResetViewPlayerData();
			BasicTutorialManager.Instance.UpdateLocalPlayerData();
			Database.Instance.advSetup.Setup(6);
			NextScene("Adv");
		}
	}
}
