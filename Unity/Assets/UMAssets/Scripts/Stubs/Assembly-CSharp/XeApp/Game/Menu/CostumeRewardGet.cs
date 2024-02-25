using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class CostumeRewardGet : MonoBehaviour
	{
		public delegate bool CloseCostumeCompWindowHandler(PopupButton.ButtonLabel label);

		private LFAFJCNKLML m_data; // 0xC
		private CostumeCompWindow m_costume_point_window; // 0x10
		private CostumeCompPopupSetting m_comp_window = new CostumeCompPopupSetting(); // 0x14
		private CostumeAchievePopupSetting m_achieve_window = new CostumeAchievePopupSetting(); // 0x18
		private bool m_is_loaded_window; // 0x1C
		private bool m_is_restart; // 0x1D
		private int m_prevOfferDifficult; // 0x20
		private const string BundleName = "ly/128.xab";

		public SimpleVoicePlayer m_voicePlayer { get; set; } // 0x24
		public bool m_isPrevCostumeSelect { get; set; } // 0x28

		// RVA: 0x1636308 Offset: 0x1636308 VA: 0x1636308
		private void Start()
		{
			this.StartCoroutineWatched(LoadCostumeReleaseWindow());
		}

		// RVA: 0x16363B8 Offset: 0x16363B8 VA: 0x16363B8
		private void OnDestroy()
		{
			AssetBundleManager.UnloadAssetBundle("ly/128.xab", false);
		}

		// RVA: 0x1636448 Offset: 0x1636448 VA: 0x1636448
		public void Show(ref LFAFJCNKLML data, int add_point, int prev_offer_difficult, CostumeRewardGet.CloseCostumeCompWindowHandler onClose)
		{
			m_is_restart = false;
			m_prevOfferDifficult = prev_offer_difficult;
			m_data = data;
			List<LFAFJCNKLML.FHLDDEKAJKI> l = CostumeUpgradeUtility.GetRewardList(data, add_point);
			foreach(var k in l)
			{
				InstallItem(k);
			}
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_comp_window.TitleText = bk.GetMessageByLabel("costume_upgrade_comp_title_text");
			m_comp_window.SetParent(transform);
			m_comp_window.data = m_data;
			m_comp_window.add_point = add_point;
			m_comp_window.prev_offer_difficult = m_prevOfferDifficult;
			m_comp_window.voicePlayer = m_voicePlayer;
			m_comp_window.is_restart = false;
			m_comp_window.is_reshow = false;
			m_comp_window.WindowSize = SizeType.Middle;
			if(!m_isPrevCostumeSelect)
			{
				m_comp_window.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.CostumeSelect, Type = PopupButton.ButtonType.Costume },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
			}
			else
			{
				m_comp_window.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
			}
			m_comp_window.NegativeButtonLabel = PopupButton.ButtonLabel.None;
			m_comp_window.BackButtonLabel = PopupButton.ButtonLabel.Ok;
			this.StartCoroutineWatched(ShowCoroutine(onClose));
		}

		// RVA: 0x1636AF0 Offset: 0x1636AF0 VA: 0x1636AF0
		public void ReShow(LFAFJCNKLML data, CloseCostumeCompWindowHandler onClose)
		{
			m_data = data;
			m_is_restart = false;
			List<LFAFJCNKLML.FHLDDEKAJKI> l = CostumeUpgradeUtility.GetRewardList(data, m_comp_window.add_point);
			foreach(var k in l)
			{
				InstallItem(k);
			}
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_comp_window.TitleText = bk.GetMessageByLabel("costume_upgrade_comp_title_text");
			m_comp_window.SetParent(transform);
			m_comp_window.data = m_data;
			m_comp_window.prev_offer_difficult = m_prevOfferDifficult;
			m_comp_window.voicePlayer = m_voicePlayer;
			m_comp_window.is_restart = false;
			m_comp_window.is_reshow = true;
			m_comp_window.WindowSize = SizeType.Middle;
			if(!m_isPrevCostumeSelect)
			{
				m_comp_window.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.CostumeSelect, Type = PopupButton.ButtonType.Costume },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
			}
			else
			{
				m_comp_window.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
			}
			m_comp_window.NegativeButtonLabel = PopupButton.ButtonLabel.None;
			m_comp_window.BackButtonLabel = PopupButton.ButtonLabel.Ok;
			this.StartCoroutineWatched(ShowCoroutine(onClose));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CE44C Offset: 0x6CE44C VA: 0x6CE44C
		// // RVA: 0x1636A48 Offset: 0x1636A48 VA: 0x1636A48
		private IEnumerator ShowCoroutine(CloseCostumeCompWindowHandler onClose)
		{
			//0x16390B4
			PopupButton.ButtonLabel pushLabel = PopupButton.ButtonLabel.None;
			bool isWait = true;
			PopupWindowManager.Show(m_comp_window, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1637934
				pushLabel = label;
			}, null, null, null, endCallBaack:() =>
			{
				//0x163793C
				isWait = false;
			});
			while(isWait)
				yield return null;
			CostumeCompWindow w = m_comp_window.Content.GetComponentInChildren<CostumeCompWindow>();
			if(w.ItemType == LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.CFOEMAAKOMC_4_Costume)
			{
				yield return this.StartCoroutineWatched(CallUnlockScene(LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.CFOEMAAKOMC_4_Costume, w.CostumeId, w.CostumeColorId));
			}
			else
			{
				if(pushLabel == PopupButton.ButtonLabel.CostumeSelect)
				{
					MenuScene.Instance.Call(TransitionList.Type.COSTUME_SELECT, new CostumeChangeDivaArgs() { DivaId = m_data.AHHJLDLAPAN_DivaId }, true);
				}
				else
				{
					if(onClose != null)
						onClose(pushLabel);
				}
			}
		}

		// // RVA: 0x1637010 Offset: 0x1637010 VA: 0x1637010
		// private bool PlayPopupSe(PopupWindowControl.SeType type) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6CE4C4 Offset: 0x6CE4C4 VA: 0x6CE4C4
		// // RVA: 0x163707C Offset: 0x163707C VA: 0x163707C
		private IEnumerator Co_ShowRewardWindow(LFAFJCNKLML data)
		{
			//0x16386E0
			m_achieve_window.data = data;
			m_achieve_window.voicePlayer = m_voicePlayer;
			bool is_wait = true;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_achieve_window.TitleText = bk.GetMessageByLabel("costume_upgrade_achievement_title_text");
			m_achieve_window.SetParent(transform);
			m_achieve_window.WindowSize = SizeType.Middle;
			m_achieve_window.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(m_achieve_window, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x16377D0
				return;
			}, null, null, null, endCallBaack:() =>
			{
				//0x1637950
				is_wait = false;
			});
			yield return new WaitWhile(() =>
			{
				//0x163795C
				return is_wait;
			});
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CE53C Offset: 0x6CE53C VA: 0x6CE53C
		// // RVA: 0x163632C Offset: 0x163632C VA: 0x163632C
		private IEnumerator LoadCostumeReleaseWindow()
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x1638C1C
			yield return Co.R(AssetBundleManager.LoadUnionAssetBundle("ly/128.xab"));
			operation = AssetBundleManager.LoadLayoutAsync(m_comp_window.BundleName, m_comp_window.AssetName);
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x1637600
				m_comp_window.SetContent(instance);
				m_costume_point_window = instance.GetComponent<CostumeCompWindow>();
			}));
			m_comp_window.SetParent(transform);
			AssetBundleManager.UnloadAssetBundle(m_comp_window.BundleName, false);
			yield return new WaitUntil(() =>
			{
				//0x16376A0
				return m_comp_window.Content != null;
			});
			m_is_loaded_window = true;
		}

		// // RVA: 0x1636954 Offset: 0x1636954 VA: 0x1636954
		private bool InstallItem(LFAFJCNKLML.FHLDDEKAJKI type)
		{
			if(type.PEEAGFNOFFO_UnlockType != LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.CFOEMAAKOMC_4_Costume)
				return false;
			KDLPEDBKMID.HHCJCDFCLOB.FKIJBFJBIOC(m_data.JPIDIENBGKH_CostumeId, false);
			return true;
		}

		// // RVA: 0x1637164 Offset: 0x1637164 VA: 0x1637164
		private void DummyBackButton()
		{
			return;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CE5B4 Offset: 0x6CE5B4 VA: 0x6CE5B4
		// // RVA: 0x1637168 Offset: 0x1637168 VA: 0x1637168
		private IEnumerator CallUnlockScene(LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType type, int id, int colorId)
		{
			//0x1637998
			GameManager.Instance.AddPushBackButtonHandler(DummyBackButton);
			MenuScene.Instance.InputDisable();
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			UnlockFadeManager.Create();
			this.StartCoroutineWatched(UnlockFadeManager.Instance.Co_LoadFadeEffect(GetLogoId(type, id)));
			yield return new WaitUntil(() =>
			{
				//0x16377D4
				return UnlockFadeManager.Instance.IsLoaded();
			});
			UnlockFadeManager.Instance.GetEffect().Enter();
			yield return new WaitUntil(() =>
			{
				//0x1637870
				return UnlockFadeManager.Instance.GetEffect().IsEntered();
			});
			GameManager.Instance.RemovePushBackButtonHandler(DummyBackButton);
			MenuScene.Instance.InputEnable();
			if(type == LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.CFOEMAAKOMC_4_Costume)
			{
				int cosId = 1;
				int divaId = 1;
				LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[id - 1];
				if(cos != null)
				{
					cosId = cos.DAJGPBLEEOB_PrismCostumeModelId;
					divaId = cos.AHHJLDLAPAN_PrismDivaId;
				}
				MenuScene.Instance.Call(TransitionList.Type.UNLOCK_COSTUME, 
					new UnlockCostumeArgs() { diva_id = divaId, 
						after_costume_data = new UnlockCostumeScene.CostumeData() { id = cosId, color_id = colorId }, 
						before_costume_data = new UnlockCostumeScene.CostumeData() { id = cosId, color_id = colorId - 1 } 
					}, true);
			}
			m_is_restart = true;
		}

		// // RVA: 0x1637260 Offset: 0x1637260 VA: 0x1637260
		private int GetLogoId(LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType type, int id)
		{
			if(type != LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.CFOEMAAKOMC_4_Costume)
				return 1;
			LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[id - 1];
			int idx = 0;
			if(cos != null)
			{
				//cos.DAJGPBLEEOB_PrismCostumeModelId;
				idx = cos.AHHJLDLAPAN_PrismDivaId - 1;
			}
			return GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[idx].AIHCEGFANAM_Serie;
		}

		// // RVA: 0x163745C Offset: 0x163745C VA: 0x163745C
		// public bool IsLoaded() { }

		// RVA: 0x1637464 Offset: 0x1637464 VA: 0x1637464
		public void Restart(CloseCostumeCompWindowHandler onClose)
		{
			if(!m_is_restart)
				return;
			this.StartCoroutineWatched(Co_ShowRestart(onClose));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CE62C Offset: 0x6CE62C VA: 0x6CE62C
		// // RVA: 0x1637498 Offset: 0x1637498 VA: 0x1637498
		private IEnumerator Co_ShowRestart(CloseCostumeCompWindowHandler onClose)
		{
			//0x16382C4
			yield return Co.R(Co_ShowRewardWindow(m_data));
			m_comp_window.is_restart = true;
			bool isClose = false;
			CostumeUpgradeUtility.ShowCommonAchieveWindow(() =>
			{
				//0x163796C
				isClose = true;
			});
			yield return new WaitUntil(() =>
			{
				//0x1637978
				return isClose;
			});
			isClose = false;
			CostumeUpgradeUtility.ShowReleaseDailyOperationWindow(m_prevOfferDifficult, () =>
			{
				//0x1637980
				isClose = true;
			});
			yield return new WaitUntil(() =>
			{
				//0x163798C
				return isClose;
			});
			m_is_restart = false;
			this.StartCoroutineWatched(ShowCoroutine(onClose));
		}
	}
}
