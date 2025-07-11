using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupCampaignPrizeListSetting : PopupSetting
	{
		public LLBKNDPMGEP View { get; set; } // 0x34
		public override string PrefabPath { get { return ""; } } //0x133D024
		public override string BundleName { get { return "ly/120.xab"; } } //0x133D080
		public override string AssetName { get { return "root_pop_cpn_roul_result_layout_root"; } } //0x133D0DC
		public override bool IsAssetBundle { get { return true; } } //0x133D138
		public override bool IsPreload { get { return false; } } //0x133D140
		public override GameObject Content { get { return m_content; } } //0x133D148

		// // RVA: 0x133D150 Offset: 0x133D150 VA: 0x133D150
		// public void SetContent(GameObject obj) { }

		// [IteratorStateMachineAttribute] // RVA: 0x700674 Offset: 0x700674 VA: 0x700674
		// RVA: 0x133D158 Offset: 0x133D158 VA: 0x133D158 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			StringBuilder bundleName; // 0x1C
			FontInfo systemFont; // 0x20
			AssetBundleLoadLayoutOperationBase operation; // 0x24
			LayoutPopupCampaignPrizeList layoutMain; // 0x28

			//0x133D26C
			m_parent = parent;
			if(m_content == null)
			{
				bundleName = new StringBuilder(64);
				systemFont = GameManager.Instance.GetSystemFont();
				bundleName.Set("ly/120.xab");
				yield return AssetBundleManager.LoadUnionAssetBundle(bundleName.ToString());
				operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), AssetName);
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
				{
					//0x133D230
					m_content = instance;
				}));
				layoutMain = m_content.GetComponentInChildren<LayoutPopupCampaignPrizeList>(true);
				GameObject header = null;
				GameObject item = null;
				operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_pop_cpn_roul_header_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
				{
					//0x133D258
					header = instance;
				}));
				layoutMain.FxScrollView.AddLayoutCache(1, header.GetComponent<LayoutUGUIRuntime>(), 7);
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
				UnityEngine.Object.Destroy(header);
				operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_pop_cpn_roul_item_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
				{
					//0x133D260
					item = instance;
				}));
				layoutMain.FxScrollView.AddLayoutCache(2, item.GetComponent<LayoutUGUIRuntime>(), 16);
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
				UnityEngine.Object.Destroy(item);
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
				yield return null;
			}
		}
	}

	public class CampaignListHeader : IFlexibleListItem
	{
		public Vector2 Top { get; set; } // 0x8
		public float Height { get; set; } // 0x10
		public int ResourceType { get; set; } // 0x14
		public FlexibleListItemLayout Layout { get; set; } // 0x18
		public int Rank { get; set; } // 0x1C
	}

	public class CampaignListItem : IFlexibleListItem
	{
		private GCIJNCFDNON_SceneInfo sceneData; // 0x20

		public Vector2 Top { get; set; } // 0x8
		public float Height { get; set; } // 0x10
		public int ResourceType { get; set; } // 0x14
		public FlexibleListItemLayout Layout { get; set; } // 0x18
		public MFDJIFIIPJD Data { get; set; } // 0x1C

		// // RVA: 0x10A52E0 Offset: 0x10A52E0 VA: 0x10A52E0
		public void OnShowItemDetails()
		{
			if(Data != null)
			{
				if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(Data.JJBGOIMEIPF_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
				{
					if(sceneData == null)
						sceneData = new GCIJNCFDNON_SceneInfo();
					sceneData.KHEKNNFCAOI(EKLNMHFCAOI.DEACAHNLMNI_getItemId(Data.JJBGOIMEIPF_ItemId), null, null, 0, 0, 0, false, 0, 0);
					MenuScene.Instance.ShowSceneStatusPopupWindow(sceneData, GameManager.Instance.ViewPlayerData, false, TransitionList.Type.UNDEFINED, null, true, true, SceneStatusParam.PageSave.None, false);
				}
				else
				{
					MenuScene.Instance.ShowItemDetail(Data.JJBGOIMEIPF_ItemId, Data.MBJIFDBEDAC_Cnt, null);
				}
			}
		}
	}

	public class PopupCampaignPrizeListContent : UIBehaviour, IPopupContent
	{
		private PopupCampaignPrizeListSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private LayoutPopupCampaignPrizeList m_layout; // 0x18
		private List<IFlexibleListItem> m_list = new List<IFlexibleListItem>(); // 0x1C

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x133BCD8 Offset: 0x133BCD8 VA: 0x133BCD8 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupCampaignPrizeListSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			MakeScrollItem(setup.View);
			m_layout = setup.Content.GetComponent<LayoutPopupCampaignPrizeList>();
		}

		// // RVA: 0x133BEE0 Offset: 0x133BEE0 VA: 0x133BEE0
		private void MakeScrollItem(LLBKNDPMGEP view)
		{
			m_list.Clear();
			float f = 0;
			for(int i = 0; i < view.JMLKAGOACAE.Count; i++)
			{
				CampaignListHeader h = new CampaignListHeader();
				h.Top = new Vector2(0, -f);
				h.Height = 55;
				h.ResourceType = 1;
				h.Rank = view.JMLKAGOACAE[i].FJOLNJLLJEJ_Rank;
				m_list.Add(h);
				f += 55;
				for(int j = 0; j < view.JMLKAGOACAE[i].HBHMAKNGKFK.Count; j++)
				{
					CampaignListItem it = new CampaignListItem();
					it.Top = new Vector2((j & 1) * 480 + 10, -(f + (j / 2) * 108 + 4));
					it.Height = 108;
					it.ResourceType = 2;
					it.Data = view.JMLKAGOACAE[i].HBHMAKNGKFK[j];
					m_list.Add(it);
					KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(ItemTextureCache.MakeItemIconTexturePath(view.JMLKAGOACAE[i].HBHMAKNGKFK[j].JJBGOIMEIPF_ItemId, 0));
				}
				f += 104 + 104 * (view.JMLKAGOACAE[i].HBHMAKNGKFK.Count - 1) / 2;
			}
		}

		// // RVA: 0x133C414 Offset: 0x133C414 VA: 0x133C414
		private void UpdateContent(IFlexibleListItem item)
		{
			if(item != null)
			{
				if(item.Layout != null)
				{
					if(item is CampaignListHeader)
					{
						LayoutPopupCampaignHeader l = item.Layout.GetComponent<LayoutPopupCampaignHeader>();
						if(l != null)
						{
							l.SetRank((item as CampaignListHeader).Rank);
						}
					}
					else if(item is CampaignListItem)
					{
						CampaignListItem it = item as CampaignListItem;
						LayoutPopupCampaignPrizeItem l = item.Layout.GetComponent<LayoutPopupCampaignPrizeItem>();
						if(l != null)
						{
							l.Setup(it.Data);
							l.OnClickButton = () =>
							{
								//0x133CDBC
								SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
								it.OnShowItemDetails();
							};
						}
					}
				}
			}
		}

		// RVA: 0x133C8B4 Offset: 0x133C8B4 VA: 0x133C8B4 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x133C8BC Offset: 0x133C8BC VA: 0x133C8BC
		public void Update()
		{
			return;
		}

		// RVA: 0x133C8C0 Offset: 0x133C8C0 VA: 0x133C8C0 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
			m_layout.FxScrollView.UpdateItemListener += UpdateContent;
			m_layout.FxScrollView.SetupListItem(m_list);
			m_layout.FxScrollView.SetlistTop(0);
			m_layout.FxScrollView.SetZeroVelocity();
			m_layout.FxScrollView.VisibleRangeUpdate();
			m_layout.FxScrollView.LockScroll();
		}

		// RVA: 0x133CB10 Offset: 0x133CB10 VA: 0x133CB10 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x133CB48 Offset: 0x133CB48 VA: 0x133CB48 Slot: 21
		public bool IsReady()
		{
			return m_layout != null && !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning && m_layout.IsLoaded();
		}

		// RVA: 0x133CC60 Offset: 0x133CC60 VA: 0x133CC60 Slot: 22
		public void CallOpenEnd()
		{
			this.StartCoroutineWatched(Co_DelayOpenEnd());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70089C Offset: 0x70089C VA: 0x70089C
		// // RVA: 0x133CC84 Offset: 0x133CC84 VA: 0x133CC84
		private IEnumerator Co_DelayOpenEnd()
		{
			//0x133CE3C
			yield return new WaitForSeconds(0.1f);
			m_layout.FxScrollView.SetZeroVelocity();
			m_layout.FxScrollView.UnLockScroll();
		}
	}
}
