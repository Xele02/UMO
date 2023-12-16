using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class EpisodeRewardGet : MonoBehaviour
	{
		public delegate void CloseEpisodeCompWindowHandler(PopupButton.ButtonLabel label);

		private PIGBBNDPPJC m_data; // 0xC
		private EpisodeCompWindow m_episode_point_window; // 0x10
		private int m_add_episode_point; // 0x14
		private int m_reward_index; // 0x18
		//private EpisodeAchievPopupSetting m_achiev_window = new EpisodeAchievPopupSetting(); // 0x1C
		private EpisodeCompPopupSetting m_comp_window = new EpisodeCompPopupSetting(); // 0x20
		private bool m_is_loaded_window; // 0x24
		private bool m_is_restart; // 0x25
		private List<MFDJIFIIPJD> m_items; // 0x28
		private int m_receiveCount; // 0x2C
		private const string BundleName = "ly/052.xab";

		// RVA: 0xEFE620 Offset: 0xEFE620 VA: 0xEFE620
		private void Start()
		{
			this.StartCoroutineWatched(LoadEpisodeReleaseWindow());
		}

		// RVA: 0xEFE6D0 Offset: 0xEFE6D0 VA: 0xEFE6D0
		private void OnDestroy()
		{
			AssetBundleManager.UnloadAssetBundle("ly/052.xab", false);
		}

		//// RVA: 0xEF8848 Offset: 0xEF8848 VA: 0xEF8848
		public void Show(ref PIGBBNDPPJC data, int add_point, JKNGJFOBADP rewards, CloseEpisodeCompWindowHandler onClose, bool episodeInfoBtn = true)
		{
			Show(ref data, add_point, rewards.HBHMAKNGKFK_Items, rewards.EPPFEAIMFOE_ItemCount, onClose, episodeInfoBtn);
		}

		//// RVA: 0xEFE760 Offset: 0xEFE760 VA: 0xEFE760
		public void Show(ref PIGBBNDPPJC data, int add_point, List<MFDJIFIIPJD> items, int itemCount, CloseEpisodeCompWindowHandler onClose, bool episodeInfoBtn = true)
		{
			m_is_restart = false;
			m_items = items;
			m_receiveCount = itemCount;
			m_reward_index = 0;
			m_data = data;
			if (itemCount > 0)
			{
				for (int i = 0; i < m_receiveCount; i++)
				{
					InstallItem(items[i].NPPNDDMPFJJ_ItemCategory, items[i].JJBGOIMEIPF_ItemFullId);
				}
			}
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_comp_window.TitleText = bk.GetMessageByLabel("popup_title_episode_03");
			m_comp_window.SetParent(transform);
			m_comp_window.data = m_data;
			m_comp_window.ItemList = m_items;
			m_comp_window.add_episode_point = add_point;
			m_comp_window.WindowSize = SizeType.Middle;
			m_comp_window.is_restart = false;
			if(!episodeInfoBtn)
			{
				m_comp_window.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				m_comp_window.NegativeButtonLabel = PopupButton.ButtonLabel.None;
			}
			else
			{
				m_comp_window.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Episode, Type = PopupButton.ButtonType.Episode },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				m_comp_window.NegativeButtonLabel = PopupButton.ButtonLabel.Ok;
			}
			m_comp_window.BackButtonLabel = PopupButton.ButtonLabel.Ok;
			this.StartCoroutineWatched(ShowCoroutine(onClose));
		}

		//// RVA: 0xEF7E70 Offset: 0xEF7E70 VA: 0xEF7E70
		public void ReStart(CloseEpisodeCompWindowHandler onClose)
		{
			if (!m_is_restart)
				return;
			m_episode_point_window.enabled = true;
			m_comp_window.is_restart = true;
			m_is_restart = false;
			this.StartCoroutineWatched(ShowCoroutine(onClose));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DB0DC Offset: 0x6DB0DC VA: 0x6DB0DC
		//// RVA: 0xEFED3C Offset: 0xEFED3C VA: 0xEFED3C
		private IEnumerator ShowCoroutine(CloseEpisodeCompWindowHandler onClose)
		{
			//0xF01494
			PopupButton.ButtonLabel pushLabel = 0;
			bool isWait = true;
			PopupWindowManager.Show(m_comp_window, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xEFFC7C
				pushLabel = label;
			}, null, null, null, true, true, false, null, () =>
			{
				//0xEFFC84
				isWait = false;
			});
			while (isWait)
				yield return null;
			EpisodeCompWindow e = m_comp_window.Content.GetComponentInChildren<EpisodeCompWindow>();
			EKLNMHFCAOI.FKGCBLHOOCL_Category t = e.ItemType;
			if((t < EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume || t > EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie) && t != EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg)
			{
				if (onClose != null)
					onClose(pushLabel);
			}
			else
			{
				this.StartCoroutineWatched(CallUnlockScene(t, e.ItemId));
			}
		}

		//// RVA: 0xEFEE04 Offset: 0xEFEE04 VA: 0xEFEE04
		//private bool PlayPopupSe(PopupWindowControl.SeType type) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6DB154 Offset: 0x6DB154 VA: 0x6DB154
		//// RVA: 0xEFEE70 Offset: 0xEFEE70 VA: 0xEFEE70
		//private IEnumerator UnlockItemShowCoroutine(int unlockItemCount) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6DB1CC Offset: 0x6DB1CC VA: 0x6DB1CC
		//// RVA: 0xEFEF38 Offset: 0xEFEF38 VA: 0xEFEF38
		//private IEnumerator ShowRewardWindowCoroutine(MFDJIFIIPJD item) { }

		//// RVA: 0xEFF000 Offset: 0xEFF000 VA: 0xEFF000
		//private void OpenRewardWindow(MFDJIFIIPJD item, Action EndCallBack) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6DB244 Offset: 0x6DB244 VA: 0x6DB244
		//// RVA: 0xEFE644 Offset: 0xEFE644 VA: 0xEFE644
		private IEnumerator LoadEpisodeReleaseWindow()
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xF00FE8
			yield return AssetBundleManager.LoadUnionAssetBundle("ly/052.xab");
			operation = AssetBundleManager.LoadLayoutAsync(m_comp_window.BundleName, m_comp_window.AssetName);
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xEFFA60
				m_comp_window.SetContent(instance);
				m_episode_point_window = instance.GetComponent<EpisodeCompWindow>();
			}));
			m_comp_window.SetParent(transform);
			AssetBundleManager.UnloadAssetBundle(m_comp_window.BundleName, false);
			while (m_comp_window.Content == null)
				yield return null;
			m_is_loaded_window = true;
		}

		//// RVA: 0xEFEC1C Offset: 0xEFEC1C VA: 0xEFEC1C
		private bool InstallItem(EKLNMHFCAOI.FKGCBLHOOCL_Category type, int id)
		{
			if(type == EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie)
			{
				KDLPEDBKMID.HHCJCDFCLOB.OANDCKGGJIP(id);
				return true;
			}
			else if(type == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume)
			{
				KDLPEDBKMID.HHCJCDFCLOB.FKIJBFJBIOC(id, false);
				return true;
			}
			return false;
		}

		//// RVA: 0xEFF45C Offset: 0xEFF45C VA: 0xEFF45C
		private void DummyBackButton()
		{
			return;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DB2BC Offset: 0x6DB2BC VA: 0x6DB2BC
		//// RVA: 0xEFF460 Offset: 0xEFF460 VA: 0xEFF460
		private IEnumerator CallUnlockScene(EKLNMHFCAOI.FKGCBLHOOCL_Category type, int id)
		{
			//0xF002EC
			GameManager.Instance.AddPushBackButtonHandler(DummyBackButton);
			MenuScene.Instance.InputDisable();
			while (KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			UnlockFadeManager.Create();
			this.StartCoroutineWatched(UnlockFadeManager.Instance.Co_LoadFadeEffect(GetLogoId(type, id)));
			while(!UnlockFadeManager.Instance.IsLoaded())
				yield return null;
			if(type == EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg)
			{
				UnlockFadeManager.Instance.GetEffect().LogoEnabled(false);
			}
			else
			{
				UnlockFadeManager.Instance.GetEffect().LogoEnabled(true);
			}
			UnlockFadeManager.Instance.GetEffect().Enter();
			while (!UnlockFadeManager.Instance.GetEffect().IsEntered())
				yield return null;
			if (type == EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg)
			{
				GameManager.Instance.ClearPushBackButtonHandler();
			}
			else
			{
				GameManager.Instance.RemovePushBackButtonHandler(DummyBackButton);
			}
			MenuScene.Instance.InputEnable();
			if (type == EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg)
			{
				int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(id);
				ALJHJDHNFFB_HomeBg.ADLLAFIDFAM dbBg = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PFEKKPABPKL_HomeBg.CDENCMNHNGA.Where((ALJHJDHNFFB_HomeBg.ADLLAFIDFAM _) =>
				{
					//0xEFFD10
					return itemId == _.PPFNGGCBJKC_Id;
				}).First();
				int homeBgId = 12;
				if(dbBg != null)
				{
					homeBgId = dbBg.PPFNGGCBJKC_Id;
				}
				this.StartCoroutineWatched(CallUnlockHomeBgScene(homeBgId));
			}
			else if(type == EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie)
			{
				int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(id);
				JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo dbValk = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList.Where((JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo _) =>
				{
					//0xEFFCCC
					return itemId == _.GPPEFLKGGGJ_Id;
				}).First();
				int valkId = 1;
				if(dbValk != null)
				{
					valkId = dbValk.GPPEFLKGGGJ_Id;
				}
				UnlockValkyrieArgs arg = new UnlockValkyrieArgs();
				arg.valkyrie_id = valkId;
				MenuScene.Instance.Call(TransitionList.Type.UNLOCK_VALKYRIE, arg, true);
			}
			else if(type == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume)
			{
				int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(id);
				LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo dbCos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[itemId - 1];
				int cosId = 1;
				int divaId = 1;
				if(dbCos != null)
				{
					cosId = dbCos.DAJGPBLEEOB_PrismCostumeModelId;
					divaId = dbCos.AHHJLDLAPAN_PrismDivaId;
				}
				UnlockCostumeArgs arg = new UnlockCostumeArgs();
				arg.diva_id = divaId;
				arg.after_costume_data = new UnlockCostumeScene.CostumeData();
				arg.after_costume_data.id = cosId;
				MenuScene.Instance.Call(TransitionList.Type.UNLOCK_COSTUME, arg, true);
			}
			m_is_restart = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DB334 Offset: 0x6DB334 VA: 0x6DB334
		//// RVA: 0xEFF540 Offset: 0xEFF540 VA: 0xEFF540
		private IEnumerator CallUnlockHomeBgScene(int homeBgId)
		{
			Font systemFont; // 0x18
			AssetBundleLoadUGUIOperationBase uguiOp; // 0x1C

			//0xEFFE20
			systemFont = GameManager.Instance.GetSystemFont();
			UnlockHomeBgScene unlockHomeBgScene = null;
			uguiOp = AssetBundleManager.LoadUGUIAsync("ly/227.xab", "UnlockHomeBgScene");
			yield return uguiOp;
			yield return Co.R(uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xEFFD5C
				unlockHomeBgScene = instance.GetComponent<UnlockHomeBgScene>();
			}));
			AssetBundleManager.UnloadAssetBundle("ly/227.xab", false);
			yield return Co.R(unlockHomeBgScene.Co_Initialize(homeBgId));
			unlockHomeBgScene.transform.SetParent(GameManager.Instance.transform.Find("Canvas-Popup/Root"), false);
			unlockHomeBgScene.transform.SetAsFirstSibling();
			unlockHomeBgScene.StartSequence();
		}

		//// RVA: 0xEFF5EC Offset: 0xEFF5EC VA: 0xEFF5EC
		private int GetLogoId(EKLNMHFCAOI.FKGCBLHOOCL_Category type, int id)
		{
			int res = 1;
			if(type == EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie)
			{
				int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(id);
				JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo dbValk = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList.Where((JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo _) =>
				{
					//0xEFFCCC
					return itemId == _.GPPEFLKGGGJ_Id;
				}).First();
				if (dbValk != null)
					res = dbValk.AIHCEGFANAM_Sa;
			}
			else if(type == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume)
			{
				int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(id);
				LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo dbCos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[itemId - 1];
				int index = 0;
				if(dbCos != null)
				{
					index = dbCos.AHHJLDLAPAN_PrismDivaId - 1;
				}
				res = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[index].AIHCEGFANAM_Serie;
			}
			return res;
		}

		//// RVA: 0xEF7B98 Offset: 0xEF7B98 VA: 0xEF7B98
		public bool IsLoaded()
		{
			return m_is_loaded_window;
		}
	}
}
