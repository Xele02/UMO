using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using XeApp.Core;
using XeSys;
using XeApp.Game.Common;
using mcrs;
using System;

namespace XeApp.Game.Menu
{
	public class DecoStorageScene : TransitionRoot
	{
		[SerializeField]
		private Image m_cover; // 0x48
		private LayoutDecorationStorageWindow m_layoutDecorationStorageWindow; // 0x4C
		private LayoutDecorationBottomButtons m_layoutDecorationBottomButtons; // 0x50
		private AHHPBMBBCFM_DecoPrivateSet m_privateDecoSetData; // 0x54
		private AHHPBMBBCFM_DecoPrivateSet m_decoPrivateSetData; // 0x58
		private DAJBODHMLAB_DecoPublicSet m_decoPublicSetData; // 0x5C
		private JOCIAMDFJHH m_netDecoSetControl; // 0x60
		private DecorationCanvas m_decorationCanvas; // 0x64
		private DocorationSpItemRemovePopupSetting m_spItemRemovePopupSetting = new DocorationSpItemRemovePopupSetting(); // 0x68
		private List<int> m_spItemListupList = new List<int>(); // 0x6C
		private List<int> m_spItemOriginalListupList = new List<int>(); // 0x70
		private bool m_isLoadedData; // 0x74
		private DAJBODHMLAB_DecoPublicSet m_copyPublicData = new DAJBODHMLAB_DecoPublicSet(); // 0x78
		private LayoutDecorationStorageList.StorageSetting m_setting; // 0x7C
		private DecorationMapNameController m_mapNameController; // 0x88
		private bool m_isSaveSuccess; // 0x8C
		private int m_addBackKeyCount; // 0x90

		// RVA: 0x11C7898 Offset: 0x11C7898 VA: 0x11C7898 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			m_decorationCanvas = GameObject.Find(DecorationConstants.CanvasName).GetComponent<DecorationCanvas>();
			m_mapNameController = GetComponent<DecorationMapNameController>();
			m_cover.gameObject.SetActive(true);
			this.StartCoroutineWatched(Co_LoadResource());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D459C Offset: 0x6D459C VA: 0x6D459C
		//// RVA: 0x11C79E4 Offset: 0x11C79E4 VA: 0x11C79E4
		private IEnumerator Co_LoadResource()
		{
			//0x11CD070
			yield return this.StartCoroutineWatched(Co_LoadStorageWindow());
			yield return this.StartCoroutineWatched(Co_LoadBottomButtons());
			IsReady = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D4614 Offset: 0x6D4614 VA: 0x6D4614
		//// RVA: 0x11C7A90 Offset: 0x11C7A90 VA: 0x11C7A90
		private IEnumerator Co_LoadBottomButtons()
		{
			AssetBundleLoadLayoutOperationBase op;

			//0x11CC694
			op = AssetBundleManager.LoadLayoutAsync(DecorationConstants.BundleName, LayoutDecorationBottomButtons.AssetName);
			yield return op;
			yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x11CA42C
				instance.transform.SetParent(transform, false);
				m_layoutDecorationBottomButtons = instance.GetComponent<LayoutDecorationBottomButtons>();
			}));
			AssetBundleManager.UnloadAssetBundle(DecorationConstants.BundleName, false);
		}

		// RVA: 0x11C7B3C Offset: 0x11C7B3C VA: 0x11C7B3C Slot: 16
		protected override void OnPreSetCanvas()
		{
			m_isLoadedData = false;
			DecoStorageArgs arg = Args as DecoStorageArgs;
			m_decoPublicSetData = arg.decoPublicSetData;
			m_decoPrivateSetData = arg.decoPrivateSetData;
			m_netDecoSetControl = new JOCIAMDFJHH(m_decoPublicSetData, m_decoPrivateSetData);
			ListupOriginalSpItem();
			SettingData();
		}

		//// RVA: 0x11C7C48 Offset: 0x11C7C48 VA: 0x11C7C48
		private void ListupOriginalSpItem()
		{
			m_spItemOriginalListupList.Clear();
			foreach (var k in m_decoPublicSetData.LJMCPFACDGJ.HBHMAKNGKFK_Items)
			{
				if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(k.HAJKNHNAIKL_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp)
				{
					m_spItemOriginalListupList.Add(k.HAJKNHNAIKL_ItemId);
				}
			}
		}

		//// RVA: 0x11C7EEC Offset: 0x11C7EEC VA: 0x11C7EEC
		private void RsetSpItemChargeTime(long chargeTime, List<int> spItemOrigianList, DAJBODHMLAB_DecoPublicSet decoPublicSetData)
		{
			foreach(var it in decoPublicSetData.LJMCPFACDGJ.HBHMAKNGKFK_Items)
			{
				if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(it.HAJKNHNAIKL_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp)
				{
					if(spItemOrigianList.Exists((int x) =>
					{
						//0x11CA9E4
						return it.HAJKNHNAIKL_ItemId == x;
					}))
					{
						int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(it.HAJKNHNAIKL_ItemId);
						NDBFKHKMMCE_DecoItem.FIDBAFHNGCF dbSp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[id - 1];
						if(dbSp.GBJFNGCDKPM <= 3)
						{
							BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL saveSp = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp[id - 1];
							saveSp.FOONCJDLLIK_ChargeTime = chargeTime;
							saveSp.EMHCHMHMFHJ_ChargeTimeOffset = 0;
							DecoScene.SendPushMessage(dbSp, saveSp.ANAJIAENLNB_Level, chargeTime, 0);
						}
					}
				}
			}
		}

		// RVA: 0x11C85C8 Offset: 0x11C85C8 VA: 0x11C85C8 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return m_isLoadedData;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D468C Offset: 0x6D468C VA: 0x6D468C
		//// RVA: 0x11C85D0 Offset: 0x11C85D0 VA: 0x11C85D0
		private IEnumerator Co_LoadStorageWindow()
		{
			AssetBundleLoadLayoutOperationBase op;

			//0x11CD228
			op = AssetBundleManager.LoadLayoutAsync(DecorationConstants.BundleName, "root_deco_window_03_layout_root");
			yield return op;
			yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x11CA4FC
				instance.transform.SetParent(transform, false);
				m_layoutDecorationStorageWindow = instance.GetComponent<LayoutDecorationStorageWindow>();
				m_layoutDecorationStorageWindow.Hide();
			}));
			yield return new WaitUntil(() =>
			{
				//0x11CA5EC
				return m_layoutDecorationStorageWindow.IsLoadedList;
			});
		}

		//// RVA: 0x11C7EA0 Offset: 0x11C7EA0 VA: 0x11C7EA0
		private void SettingData()
		{
			SettingStorageData();
			m_layoutDecorationStorageWindow.Enter(GetUseStorageNum());
			m_isLoadedData = true;
		}

		//// RVA: 0x11C867C Offset: 0x11C867C VA: 0x11C867C
		private void SettingStorageData()
		{
			if(m_decoPrivateSetData.JBJHCJFOICD != null)
			{
				for(int i = 0; i < m_decoPrivateSetData.JBJHCJFOICD.Count; i++)
				{
					string name = UnusedStorageName();
					bool isUse = false;
					if(m_decoPrivateSetData.JBJHCJFOICD[i].CIKOPIFGLGA())
					{
						name = m_decoPrivateSetData.JBJHCJFOICD[i].CPOONLHIMKC_DecoRoomName;
						isUse = true;
					}
					m_layoutDecorationStorageWindow.SettingList(i, name, isUse, OnClickStorageDeleteButton, OnClickStorageSelectButton, OnClickStorageSaveButton, OnClickMapNameEditButton);
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D4704 Offset: 0x6D4704 VA: 0x6D4704
		//// RVA: 0x11C8BB4 Offset: 0x11C8BB4 VA: 0x11C8BB4
		private IEnumerator Co_SavePrivateStorageData(LayoutDecorationStorageList.StorageSetting setting, Action<bool> callback)
		{
			//0x11CD54C
			m_isSaveSuccess = false;
			bool done = false;
			bool isError = false;
			CIOECGOMILE.HHCJCDFCLOB.OEAMJGPAIGP(CIOECGOMILE.HHCJCDFCLOB.AEBNIAFEIHC, () =>
			{
				//0x11CAA2C
				m_layoutDecorationStorageWindow.UpdateButton(setting);
				m_isSaveSuccess = true;
				done = true;
			}, () =>
			{
				//0x11CAAB4
				done = true;
				isError = true;
			}, null);
			yield return new WaitUntil(() =>
			{
				//0x11CAAC0
				return done;
			});
			if(!isError)
			{
				m_layoutDecorationStorageWindow.UseStorageNum(GetUseStorageNum());
			}
			else
			{
				MenuScene.Instance.GotoTitle();
			}
			callback(!isError);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D477C Offset: 0x6D477C VA: 0x6D477C
		//// RVA: 0x11C8CA4 Offset: 0x11C8CA4 VA: 0x11C8CA4
		private IEnumerator Co_SavePublicStorageData(Action<bool> callback)
		{
			//0x11CD9C0
			bool done = false;
			bool isError = false;
			CIOECGOMILE.HHCJCDFCLOB.OEAMJGPAIGP(CIOECGOMILE.HHCJCDFCLOB.PDKHANKAPCI, () =>
			{
				//0x11CAAD0
				done = true;
			}, () =>
			{
				//0x11CAADC
				done = true;
				isError = false;
			}, null);
			yield return new WaitUntil(() =>
			{
				//0x11CAAE8
				return done;
			});
			if(isError)
			{
				MenuScene.Instance.GotoTitle();
			}
			callback(!isError);
		}

		// RVA: 0x11C8D50 Offset: 0x11C8D50 VA: 0x11C8D50 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_cover.gameObject.SetActive(true);
		}

		// RVA: 0x11C8DA0 Offset: 0x11C8DA0 VA: 0x11C8DA0 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_cover.gameObject.SetActive(false);
			m_layoutDecorationStorageWindow.Leave();
			m_layoutDecorationBottomButtons.Leave();
		}

		// RVA: 0x11C8E34 Offset: 0x11C8E34 VA: 0x11C8E34 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return m_layoutDecorationStorageWindow.IsPlayingEnd() && m_layoutDecorationBottomButtons.IsPlayingEnd();
		}

		// RVA: 0x11C8E94 Offset: 0x11C8E94 VA: 0x11C8E94 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return m_layoutDecorationStorageWindow.IsPlayingEnd() && m_layoutDecorationBottomButtons.IsPlayingEnd();
		}

		//// RVA: 0x11C8E38 Offset: 0x11C8E38 VA: 0x11C8E38
		//private bool IsPlayingEnd() { }

		//// RVA: 0x11C8E98 Offset: 0x11C8E98 VA: 0x11C8E98
		public void OnClickStorageDeleteButton(LayoutDecorationStorageList.StorageSetting setting)
		{
			MenuScene.Instance.InputDisable();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_StorageListDelete(setting));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D47F4 Offset: 0x6D47F4 VA: 0x6D47F4
		//// RVA: 0x11C8FBC Offset: 0x11C8FBC VA: 0x11C8FBC
		private IEnumerator Co_StorageListDelete(LayoutDecorationStorageList.StorageSetting setting)
		{
			//0x11CDD84
			bool isClose = false;
			bool isCancel = false;
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(MessageManager.Instance.GetMessage("menu", "pop_deco_storage_delete_title"),
				SizeType.Middle, string.Format(MessageManager.Instance.GetMessage("menu", "pop_deco_storage_delete_desc"), setting.m_name), new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel lable) =>
				{
					//0x11CAAF8
					isClose = true;
					if (lable == PopupButton.ButtonLabel.Cancel)
						isCancel = true;
				}, null, null, null);
			yield return new WaitUntil(() =>
			{
				//0x11CAB0C
				return isClose;
			});
			if(!isCancel)
			{
				m_netDecoSetControl.INBANHBGIFC_ResetSet(setting.m_id);
				ILCCJNDFFOB.HHCJCDFCLOB.BOIIMIEPMLG(JpStringLiterals.StringLiteral_11225, setting.m_id, UnusedStorageName());
				bool succeeded = false;
				yield return this.StartCoroutineWatched(Co_SavePrivateStorageData(new LayoutDecorationStorageList.StorageSetting() { m_id = setting.m_id, m_name = UnusedStorageName(), m_isUse = false }, (bool _result) =>
				{
					//0x11CAB14
					succeeded = _result;
				}));
				if(succeeded)
				{
					yield return this.StartCoroutineWatched(Co_CommonPopup(MessageManager.Instance.GetMessage("menu", "pop_deco_storage_delete_comp_title"), string.Format(MessageManager.Instance.GetMessage("menu", "pop_deco_storage_delete_comp_desc"), setting.m_name)));
				}
			}
			MenuScene.Instance.InputEnable();
		}

		//// RVA: 0x11C9094 Offset: 0x11C9094 VA: 0x11C9094
		public void OnClickStorageSelectButton(LayoutDecorationStorageList.StorageSetting setting)
		{
			GameManager.FadeOut(0.4f);
			MenuScene.Instance.InputDisable();
			this.StartCoroutineWatched(Co_StorageListSelect(setting));
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D486C Offset: 0x6D486C VA: 0x6D486C
		//// RVA: 0x11C91F4 Offset: 0x11C91F4 VA: 0x11C91F4
		private IEnumerator Co_StorageListSelect(LayoutDecorationStorageList.StorageSetting setting)
		{
			//0x11CED90
			yield return new WaitWhile(() =>
			{
				//0x11CA748
				return GameManager.IsFading();
			});
			m_cover.gameObject.SetActive(false);
			m_layoutDecorationStorageWindow.Leave();
			m_layoutDecorationBottomButtons.Enter(LayoutDecorationBottomButtons.BottomButtonsType.ChangeStorage, OnClickChangeStorageCancelButton, OnClickChangeStorageOKButton, null);
			yield return new WaitUntil(() =>
			{
				//0x11CA618
				return m_layoutDecorationStorageWindow.IsPlayingEnd() && m_layoutDecorationBottomButtons.IsPlayingEnd();
			});
			m_copyPublicData.ODDIHGPONFL_Copy(m_decoPublicSetData);
			m_netDecoSetControl.HGDIEHFFLMO_LoadFromSlot(setting.m_id);
			yield return this.StartCoroutineWatched(Co_LoadCanvas());
			GameManager.FadeIn(0.4f);
			yield return new WaitWhile(() =>
			{
				//0x11CA7C4
				return GameManager.IsFading();
			});
			MenuScene.Instance.InputEnable();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D48E4 Offset: 0x6D48E4 VA: 0x6D48E4
		//// RVA: 0x11C92CC Offset: 0x11C92CC VA: 0x11C92CC
		public IEnumerator Co_LoadCanvas()
		{
			//0x11CC9F4
			m_decorationCanvas.LoadDecoration(m_decoPublicSetData.LJMCPFACDGJ);
			yield return new WaitUntil(() =>
			{
				//0x11CA61C
				return m_decorationCanvas.IsLoadedDecoration;
			});
			List<DecorationItemBase> l = m_decorationCanvas.GetItemList();
			bool b = l.Exists((DecorationItemBase x) =>
			{
				//0x11CA840
				return x is DecorationSp && (x as DecorationSp).SpType == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JPPOGMHJKKJ_11;
			});
			if (!m_spItemOriginalListupList.Exists(FindVisitItemFunc))
			{
				if(!b)
				{
					yield break;
				}
				foreach(var it in l)
				{
					if(it is DecorationSp && (it as DecorationSp).SpType == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JPPOGMHJKKJ_11)
					{
						m_decorationCanvas.RemoveItem(it);
						yield break;
					}
				}
			}
			if(b)
			{
				yield break;
			}
			int id;
			DecorationItemBaseSetting s;
			m_decorationCanvas.MakeVisitItem(out id, out s);
			m_decorationCanvas.LoadItemResource(id, s, DecorationItemManager.PostType.Posted, null);
			yield return new WaitUntil(() =>
			{
				//0x11CA648
				return m_decorationCanvas.IsLoadedItemDecoration;
			});
			m_decorationCanvas.LoadedItem();
		}

		//// RVA: 0x11C9378 Offset: 0x11C9378 VA: 0x11C9378
		private bool FindVisitItemFunc(int itemId)
		{
			EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId);
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemId);
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp)
			{
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[id - 1].GBJFNGCDKPM == 11;
			}
			return false;
		}

		//// RVA: 0x11C9508 Offset: 0x11C9508 VA: 0x11C9508
		public void OnClickChangeStorageCancelButton()
		{
			GameManager.FadeOut(0.4f);
			MenuScene.Instance.InputDisable();
			this.StartCoroutineWatched(Co_ChangeStorageCancel());
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D495C Offset: 0x6D495C VA: 0x6D495C
		//// RVA: 0x11C9648 Offset: 0x11C9648 VA: 0x11C9648
		private IEnumerator Co_ChangeStorageCancel()
		{
			//0x11CACB4
			yield return new WaitWhile(() =>
			{
				//0x11CA8EC
				return GameManager.IsFading();
			});
			m_cover.gameObject.SetActive(true);
			m_layoutDecorationStorageWindow.Enter(GetUseStorageNum());
			m_layoutDecorationBottomButtons.Leave();
			HeaderEnter();
			m_decoPublicSetData.ODDIHGPONFL_Copy(m_copyPublicData);
			yield return this.StartCoroutineWatched(Co_LoadCanvas());
			yield return new WaitUntil(() =>
			{
				//0x11CA674
				return m_layoutDecorationStorageWindow.IsPlayingEnd();
			});
			yield return new WaitUntil(() =>
			{
				//0x11CA6A0
				return m_layoutDecorationBottomButtons.IsPlayingEnd();
			});
			GameManager.FadeIn(0.4f);
			yield return new WaitWhile(() =>
			{
				//0x11CA968
				return GameManager.IsFading();
			});
			MenuScene.Instance.InputEnable();
		}

		//// RVA: 0x11C96F4 Offset: 0x11C96F4 VA: 0x11C96F4
		public void OnClickChangeStorageOKButton()
		{
			MenuScene.Instance.InputDisable();
			this.StartCoroutineWatched(Co_ChangeStorageOK());
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D49D4 Offset: 0x6D49D4 VA: 0x6D49D4
		//// RVA: 0x11C97F8 Offset: 0x11C97F8 VA: 0x11C97F8
		private IEnumerator Co_ChangeStorageOK()
		{
			//0x11CB2B4
			m_spItemListupList.Clear();
			for(int i = 0; i < m_copyPublicData.LJMCPFACDGJ.HBHMAKNGKFK_Items.Count; i++)
			{
				if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(m_copyPublicData.LJMCPFACDGJ.HBHMAKNGKFK_Items[i].HAJKNHNAIKL_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp)
				{
					int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(m_copyPublicData.LJMCPFACDGJ.HBHMAKNGKFK_Items[i].HAJKNHNAIKL_ItemId);
					NDBFKHKMMCE_DecoItem.FIDBAFHNGCF dbSp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[id - 1];
					if(dbSp.GBJFNGCDKPM < 4)
					{
						m_spItemListupList.Add(m_copyPublicData.LJMCPFACDGJ.HBHMAKNGKFK_Items[i].HAJKNHNAIKL_ItemId);
					}
				}
			}
			for(int i = 0; i < m_spItemListupList.Count; i++)
			{
				DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD it = m_decoPublicSetData.LJMCPFACDGJ.HBHMAKNGKFK_Items.Find((DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD x) =>
				{
					//0x11CAB34
					return x.HAJKNHNAIKL_ItemId == m_spItemListupList[i];
				});
				if(it != null)
				{
					m_spItemListupList.RemoveAt(i);
					i--;
				}
			}
			if(m_spItemListupList.Count > 0)
			{
				m_spItemListupList.Sort();
				m_spItemRemovePopupSetting.TitleText = MessageManager.Instance.GetMessage("menu", "pop_deco_sp_item_remove_title");
				m_spItemRemovePopupSetting.m_parent = transform;
				m_spItemRemovePopupSetting.isReplaceRoom = true;
				m_spItemRemovePopupSetting.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				m_spItemRemovePopupSetting.itemList.Clear();
				for(int i = 0; i < m_spItemListupList.Count; i++)
				{
					m_spItemRemovePopupSetting.itemList.Add(m_spItemListupList[i]);
				}
				m_spItemRemovePopupSetting.WindowSize = SizeType.Middle;
				bool isDecide = false;
				bool isWait = true;
				PopupWindowManager.Show(m_spItemRemovePopupSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x11CAC18
					if (type == PopupButton.ButtonType.Positive)
						isDecide = true;
					isWait = false;
				}, null, null, null);
				while (isWait)
					yield return null;
				if(!isDecide)
				{
					MenuScene.Instance.InputEnable();
					yield break;
				}
			}
			ILCCJNDFFOB.HHCJCDFCLOB.BOIIMIEPMLG(JpStringLiterals.StringLiteral_15528, 0, m_decoPublicSetData.LJMCPFACDGJ.CPOONLHIMKC_DecoRoomName);
			bool succeeded = false;
			if(NKGJPJPHLIF.HHCJCDFCLOB.DPJBHHIHJJK)
				yield return this.StartCoroutineWatched(DecoScene.Co_UpdateDirtyTime());

			RsetSpItemChargeTime(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime(), m_spItemOriginalListupList, m_decoPublicSetData);
			ListupOriginalSpItem();
			yield return this.StartCoroutineWatched(Co_SavePublicStorageData((bool _result) =>
			{
				//0x11CAB24
				succeeded = _result;
			}));
			if(succeeded)
			{
				yield return this.StartCoroutineWatched(Co_CommonPopup(MessageManager.Instance.GetMessage("menu", "pop_deco_storage_select_comp_title"), string.Format(MessageManager.Instance.GetMessage("menu", "pop_deco_storage_select_comp_desc"), m_decoPublicSetData.LJMCPFACDGJ.CPOONLHIMKC_DecoRoomName)));
				yield return this.StartCoroutineWatched(Co_UpdatePublicStatus());
			}
			MenuScene.Instance.InputEnable();
			MenuScene.Instance.Return(false);
		}

		//// RVA: 0x11C98A4 Offset: 0x11C98A4 VA: 0x11C98A4
		public void OnClickStorageSaveButton(LayoutDecorationStorageList.StorageSetting setting)
		{
			MenuScene.Instance.InputDisable();
			this.StartCoroutineWatched(Co_StorageListSave(setting));
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D4A4C Offset: 0x6D4A4C VA: 0x6D4A4C
		//// RVA: 0x11C99C8 Offset: 0x11C99C8 VA: 0x11C99C8
		private IEnumerator Co_StorageListSave(LayoutDecorationStorageList.StorageSetting setting)
		{
			//0x11CE530
			if(setting.m_isUse)
			{
				bool isClose = false;
				bool isCancel = false;
				PopupWindowManager.Show(PopupWindowManager.CrateTextContent(MessageManager.Instance.GetMessage("menu", "pop_deco_storage_overwrite_title"), SizeType.Middle, string.Format(MessageManager.Instance.GetMessage("menu", "pop_deco_storage_overwrite_desc"), setting.m_name), new ButtonInfo[2]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0x11CAC48
						isClose = true;
						if (label == PopupButton.ButtonLabel.Cancel)
							isCancel = true;
					}, null, null, null);
				yield return new WaitUntil(() =>
				{
					//0x11CAC5C
					return isClose;
				});
				if(isCancel)
				{
					MenuScene.Instance.InputEnable();
					yield break;
				}
			}
			m_netDecoSetControl.DKHCCBIOBPH_SaveToSlot(setting.m_id);
			ILCCJNDFFOB.HHCJCDFCLOB.BOIIMIEPMLG(JpStringLiterals.StringLiteral_15538, setting.m_id, m_decoPublicSetData.LJMCPFACDGJ.CPOONLHIMKC_DecoRoomName);
			bool succeeded = false;
			yield return this.StartCoroutineWatched(Co_SavePrivateStorageData(new LayoutDecorationStorageList.StorageSetting() { m_id = setting.m_id, m_name = m_decoPublicSetData.LJMCPFACDGJ.CPOONLHIMKC_DecoRoomName, m_isUse = true }, (bool _result) =>
			{
				//0x11CAC38
				succeeded = _result;
			}));
			if(!succeeded)
			{
				MenuScene.Instance.InputEnable();
				yield break;
			}
			yield return this.StartCoroutineWatched(Co_CommonPopup(MessageManager.Instance.GetMessage("menu", "pop_deco_storage_overwrite_comp_title"), string.Format(MessageManager.Instance.GetMessage("menu", setting.m_isUse ? "pop_deco_storage_overwrite_comp_desc" : "pop_deco_storage_write_comp_desc"), setting.m_name)));
			MenuScene.Instance.InputEnable();
		}

		//// RVA: 0x11C9AA0 Offset: 0x11C9AA0 VA: 0x11C9AA0
		private void OnClickMapNameEditButton(LayoutDecorationStorageList.StorageSetting setting)
		{
			m_setting = setting;
			string name = m_decoPrivateSetData.JBJHCJFOICD[m_setting.m_id].CPOONLHIMKC_DecoRoomName;
			m_mapNameController.MapNameEdit(name, TryChangeMapName, NoChangeMapName);
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//// RVA: 0x11C9C68 Offset: 0x11C9C68 VA: 0x11C9C68
		private void NoChangeMapName()
		{
			return;
		}

		//// RVA: 0x11C9C6C Offset: 0x11C9C6C VA: 0x11C9C6C
		private void TryChangeMapName(string mapName)
		{
			this.StartCoroutineWatched(Co_TryChangeMapName(mapName));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D4AC4 Offset: 0x6D4AC4 VA: 0x6D4AC4
		//// RVA: 0x11C9C90 Offset: 0x11C9C90 VA: 0x11C9C90
		private IEnumerator Co_TryChangeMapName(string mapName)
		{
			//0x11CF3D0
			MenuScene.Instance.InputDisable();
			m_netDecoSetControl.APOIDBODGGB_RenameSlot(m_setting.m_id, mapName);
			ILCCJNDFFOB.HHCJCDFCLOB.BOIIMIEPMLG(JpStringLiterals.StringLiteral_15542, m_setting.m_id, mapName);
			bool succeeded = false;
			yield return this.StartCoroutineWatched(Co_SavePrivateStorageData(new LayoutDecorationStorageList.StorageSetting() { m_id = m_setting.m_id, m_isUse = m_setting.m_isUse, m_name = mapName }, (bool _result) =>
			{
				//0x11CAC6C
				succeeded = _result;
			}));
			MenuScene.Instance.InputEnable();
			if(succeeded)
			{
				m_mapNameController.ChangeMapName(m_isSaveSuccess);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D4B3C Offset: 0x6D4B3C VA: 0x6D4B3C
		//// RVA: 0x11C9D58 Offset: 0x11C9D58 VA: 0x11C9D58
		private IEnumerator Co_UpdatePublicStatus()
		{
			//0x11CF7AC
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DOPABKCMOOI(CIOECGOMILE.HHCJCDFCLOB.LGBMDHOLOIF_decoPlayerData, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MHEAEGMIKIE_PublicStatus.DALCINDEJLC_DcTm);
			bool isDone = false;
			bool isError = false;
			MenuScene.Instance.InputDisable();
			MenuScene.Save(() =>
			{
				//0x11CAC7C
				isDone = true;
			}, () =>
			{
				//0x11CAC88
				isDone = true;
				isError = true;
			});
			while (!isDone)
				yield return null;
			if(!isError)
			{
				MenuScene.Instance.InputEnable();
			}
			else
			{
				MenuScene.Instance.GotoTitle();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D4BB4 Offset: 0x6D4BB4 VA: 0x6D4BB4
		//// RVA: 0x11C9DEC Offset: 0x11C9DEC VA: 0x11C9DEC
		private IEnumerator Co_CommonPopup(string title, string text)
		{
			//0x11CC364
			bool isClose = false;
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(title, SizeType.Middle, text, new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x11CAC9C
					isClose = true;
				}, null, null, null);
			yield return new WaitUntil(() =>
			{
				//0x11CACA8
				return isClose;
			});
		}

		//// RVA: 0x11C899C Offset: 0x11C899C VA: 0x11C899C
		private int GetUseStorageNum()
		{
			int res = 0;
			foreach(var slot in m_decoPrivateSetData.JBJHCJFOICD)
			{
				if (slot.CIKOPIFGLGA())
					res++;
			}
			return res;
		}

		//// RVA: 0x11C8B18 Offset: 0x11C8B18 VA: 0x11C8B18
		private string UnusedStorageName()
		{
			return MessageManager.Instance.GetMessage("menu", "deco_storage_unused_storage_name");
		}

		//// RVA: 0x11C9EB4 Offset: 0x11C9EB4 VA: 0x11C9EB4
		//private void HeaderLeave() { }

		//// RVA: 0x11CA0E8 Offset: 0x11CA0E8 VA: 0x11CA0E8
		private void HeaderEnter()
		{
			MenuScene.Instance.HelpButton.TryShow(TransitionList.Type.DECO_BAST_STORAGE);
			MenuScene.Instance.HeaderMenu.MenuStack.EnterLabel();
			MenuScene.Instance.HeaderMenu.MenuStack.EnterBackButton(false);
			for(int i = 0; i < m_addBackKeyCount; i++)
			{
				GameManager.Instance.RemovePushBackButtonHandler(NotBackKey);
			}
			m_addBackKeyCount = 0;
		}

		//// RVA: 0x11CA33C Offset: 0x11CA33C VA: 0x11CA33C
		private void NotBackKey()
		{
			return;
		}
	}
}
