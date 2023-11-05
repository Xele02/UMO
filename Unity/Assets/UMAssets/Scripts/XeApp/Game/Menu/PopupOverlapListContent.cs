using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System.Collections.Generic;
using System.Collections;
using XeApp.Core;
using mcrs;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PopupOverlapListContent : LayoutUGUIScriptBase, IPopupContent
	{
		public enum ScrollItemType
		{
			Header = 1,
			Item = 2,
		}

		[SerializeField]
		private LayoutUGUIRuntime m_runtime; // 0x14
		[SerializeField]
		private ScrollRect[] m_scrollRect; // 0x18
		[SerializeField]
		private Text m_textDesc; // 0x1C
		[SerializeField]
		private Text m_textLimit; // 0x20
		private AbsoluteLayout m_root; // 0x28
		private PopupOverlapListSetting setup; // 0x2C
		private SceneStatePopupSetting sceneStatePopup; // 0x30
		private PopupWindowControl control; // 0x34
		private LayoutPopupOverlapSingle layoutSingle; // 0x38
		private FlexibleItemScrollView fxScrollView; // 0x3C
		private List<IFlexibleListItem> m_list = new List<IFlexibleListItem>(); // 0x40
		private Coroutine m_loading; // 0x44

		public Transform Parent { get; private set; } // 0x24

		// RVA: 0x169EFB4 Offset: 0x169EFB4 VA: 0x169EFB4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.FindViewById("swtbl_win_scroll") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// // RVA: 0x169F08C Offset: 0x169F08C VA: 0x169F08C Slot: 6
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			setup = setting as PopupOverlapListSetting;
			this.control = control;
			Parent = setup.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_loading = control.StartCoroutineWatched(LoadAssetBundlePrefab());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70D1BC Offset: 0x70D1BC VA: 0x70D1BC
		// // RVA: 0x169F244 Offset: 0x169F244 VA: 0x169F244
		public IEnumerator LoadAssetBundlePrefab()
		{
			Font systemFont; // 0x20
			bool isGetPoster; // 0x24
			AssetBundleLoadLayoutOperationBase operation; // 0x28
			FlexibleItemScrollView scrollView; // 0x2C

			//0x16A1A08
			systemFont = GameManager.Instance.GetSystemFont();
			yield return Co.R(AssetBundleManager.LoadUnionAssetBundle(setup.BundleName));
			RectTransform rect = setup.Content.transform as RectTransform;
			rect.anchoredPosition = Vector2.zero;
			isGetPoster = setup.Type == GONMPHKGKHI_RewardView.CECMLGBLHHG.JCGKGFLCKCP_8;
			if(setup.List != null && setup.List.Count > 1)
			{
				scrollView = new FlexibleItemScrollView();
				scrollView.Initialize(m_scrollRect[isGetPoster ? 1 : 0]);
				operation = null;
				if(!isGetPoster)
				{
					GameObject header = null;
					operation = AssetBundleManager.LoadLayoutAsync(setup.BundleName, "root_pop_overlap_title_layout_root");
					yield return operation;
					yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
					{
						//0x16A16A4
						header = instance;
					}));
					scrollView.AddLayoutCache(1, header.GetComponent<LayoutUGUIRuntime>(), 3);
					AssetBundleManager.UnloadAssetBundle(setup.BundleName, false);
					Destroy(header);
				}
				//LAB_016a2288;
				GameObject item = null;
				operation = AssetBundleManager.LoadLayoutAsync(setup.BundleName, "root_pop_overlap_plate_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
				{
					//0x16A1694
					item = instance;
				}));
				scrollView.AddLayoutCache(2, item.GetComponent<LayoutUGUIRuntime>(), 20);
				AssetBundleManager.UnloadAssetBundle(setup.BundleName, false);
				Destroy(item);
				yield return null;
				MakeScrollItem(setup.List);
				fxScrollView = scrollView;
				yield return Co.R(SetupLayout(isGetPoster));
				operation = null;
				scrollView = null;
			}
			else
			{
				operation = AssetBundleManager.LoadLayoutAsync(setup.BundleName, "root_pop_overlap_one_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
				{
					//0x16A126C
					m_runtime.enabled = false;
					for(int i = 0; i < rect.childCount; i++)
					{
						Destroy(rect.GetChild(i).gameObject);
					}
					layoutSingle = instance.GetComponent<LayoutPopupOverlapSingle>();
					layoutSingle.transform.SetParent(rect, false);
				}));
				AssetBundleManager.UnloadAssetBundle(setup.BundleName, false);
				if(!(setup is PopupGetDecoItemSetting))
				{
					bool isKira = false;
					if(setup.List != null)
					{
						isKira = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes.Find((GCIJNCFDNON_SceneInfo x) =>
						{
							//0x16A144C
							return x.BCCHOBPJJKE_SceneId == setup.List[0].BCCHOBPJJKE_SceneId;
						}).MBMFJILMOBP_IsKira();
					}
					layoutSingle.SetStatus(setup.Type, setup.List[0], control.m_titleText, isKira);
					if(!isGetPoster)
					{
						layoutSingle.OnClickButton = () =>
						{
							//0x16A153C
							SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
							ShowSceneStatusPopup(setup.List[0], layoutSingle.transform, null);
						};
					}
				}
				else
				{
					PopupGetDecoItemSetting ds = setup as PopupGetDecoItemSetting;
					layoutSingle.SetStatusDeco(ds.typeAndId, ds.prevNum, ds.nextNum, control.m_titleText);
				}
				operation = null;
			}
			//LAB_016a282c
			AssetBundleManager.UnloadAssetBundle(setup.BundleName, false);
			m_loading = null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70D234 Offset: 0x70D234 VA: 0x70D234
		// // RVA: 0x169F2F0 Offset: 0x169F2F0 VA: 0x169F2F0
		public IEnumerator SetupLayout(bool isGetPoster)
		{
			//0x16094B8
			if(!isGetPoster)
			{
				m_root.StartChildrenAnimGoStop("01");
				for(int i = 0; i < setup.List.Count; i++)
				{
					GameManager.Instance.SceneIconCache.Load(setup.List[i].BCCHOBPJJKE_SceneId, 2, (IiconTexture texture) =>
					{
						//0x16A1130
						return;
					});
				}
			}
			else
			{
				m_root.StartChildrenAnimGoStop("02");
                GONMPHKGKHI_RewardView.GCHFDJMNCAF a = setup.List[0] as GONMPHKGKHI_RewardView.GCHFDJMNCAF;
                EKLNMHFCAOI.FKGCBLHOOCL_Category cat = a.DMJCACIDEBM ? EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft : EKLNMHFCAOI.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef;
                SetStatusDeco(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(cat, setup.List[0].BCCHOBPJJKE_SceneId), a.GBALGEMKJKD, a.HMGDINKEPHJ, control.m_titleText);
				for(int i = 0; i < setup.List.Count; i++)
				{
					GameManager.Instance.ItemTextureCache.Load(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(cat, setup.List[0].BCCHOBPJJKE_SceneId), 0, (IiconTexture texture) =>
					{
						//0x16A112C
						return;
					});
				}
			}
			gameObject.SetActive(true);
			while(m_root.IsPlayingChildren())
				yield return null;
			while(GameManager.Instance.SceneIconCache.IsLoading())
				yield return null;
		}

		// // RVA: 0x169F394 Offset: 0x169F394 VA: 0x169F394
		private void MakeScrollItem(List<GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo> list)
		{
			m_list.Clear();
			List<List<GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo>> l = new List<List<GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo>>();
			if(setup.Type == GONMPHKGKHI_RewardView.CECMLGBLHHG.JCGKGFLCKCP_8)
			{
				l.Add(list.FindAll((GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo _) =>
				{
					//0x16A1134
					if(_ != null)
					{
						if(_ is GONMPHKGKHI_RewardView.GCHFDJMNCAF)
							return (_ as GONMPHKGKHI_RewardView.GCHFDJMNCAF).GBALGEMKJKD < (_ as GONMPHKGKHI_RewardView.GCHFDJMNCAF).HMGDINKEPHJ;
					}
					return false;
				}));
			}
			else
			{
				l.Add(list.FindAll((GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo _) =>
				{
					//0x16A1204
					return _.IPMJIODJGBC == GONMPHKGKHI_RewardView.CECMLGBLHHG.NNEOHGFGLKM_3;
				}));
				l.Add(list.FindAll((GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo _) =>
				{
					//0x16A1234
					return _.IPMJIODJGBC == GONMPHKGKHI_RewardView.CECMLGBLHHG.INJNLJHGGKB_4;
				}));
			}
			float f = 0;
			for(int i = 0; i < l.Count; i++)
			{
				if(setup.Type != GONMPHKGKHI_RewardView.CECMLGBLHHG.JCGKGFLCKCP_8)
				{
					if(l[i].Count > 0)
					{
						OverlapListHeader h = new OverlapListHeader();
						h.Top = new Vector2(0, -(f + 11));
						h.Height = 34.0f;
						h.ResourceType = 1;
						h.Type = l[i][0].IPMJIODJGBC;
						m_list.Add(h);
						f += 11 + 34;
					}
				}
				for(int j = 0; j < l[i].Count; j++)
				{
					GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo data = l[i][j];
					GCIJNCFDNON_SceneInfo card = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes.Find((GCIJNCFDNON_SceneInfo x) =>
					{
						//0x16A16AC
						return data.BCCHOBPJJKE_SceneId == x.BCCHOBPJJKE_SceneId;
					});
					OverlapListItem h = new OverlapListItem();
					h.Top = new Vector2((j % 4) * 235 + 20, -(f + (j / 4) * 183 + 5));
					h.Height = 183;
					h.ResourceType = 2;
					h.Info = data;
					h.IsKira = card != null ? card.MBMFJILMOBP_IsKira() : false;
					m_list.Add(h);
				}
				if(l[i].Count > 0)
				{
					f += (l[i].Count / 4) * 183 + 173 + 5;
				}
			}
		}

		// // RVA: 0x169FE4C Offset: 0x169FE4C VA: 0x169FE4C
		private void SetStatusDeco(int typeAndId, int prevNum, int nextNum, Text titleText)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(typeAndId);
			string str = "";
            if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef && cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft)
			{
				str = "deco_name_poster";
			}
			else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure)
			{
				str = "deco_name_figure";
			}
			else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso)
			{
				str = "deco_name_torso";
			}
			titleText.text = string.Format(bk.GetMessageByLabel("pop_deco_get_title"), bk.GetMessageByLabel(str));
			m_textDesc.text = string.Format(bk.GetMessageByLabel("pop_deco_get_desc"), bk.GetMessageByLabel(str));
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef && cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft)
			{
				m_textLimit.text = string.Format(bk.GetMessageByLabel("pop_deco_get_limit"), bk.GetMessageByLabel(str), EKLNMHFCAOI.AFEONHCADEL_GetMaxAllowed(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, cat, 1, null));
			}
			else
			{
				m_textLimit.text = "";
			}
		}

		// // RVA: 0x16A02AC Offset: 0x16A02AC VA: 0x16A02AC
		private void UpdateContent(IFlexibleListItem item)
		{
			if(item != null)
			{
				FlexibleListItemLayout l = item.Layout;
				if(l != null)
				{
					if(item is OverlapListHeader)
					{
						OverlapListHeader ol = item as OverlapListHeader;
						LayoutPopupOverlapHeader l2 = l.GetComponent<LayoutPopupOverlapHeader>();
						l2.SetStatus(ol.Type);
					}
					else if(item is OverlapListItem)
					{
						OverlapListItem ol = item as OverlapListItem;
						LayoutPopupOverlapItem l2 = l.GetComponent<LayoutPopupOverlapItem>();
						if(l2 != null)
						{
							l2.SetStatus(setup.Type, ol.Info, ol.IsKira);
							if(setup.Type != GONMPHKGKHI_RewardView.CECMLGBLHHG.JCGKGFLCKCP_8)
							{
								l2.OnClickButton = () =>
								{
									//0x16A16F8
									SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
									ShowSceneStatusPopup(ol.Info, l2.transform, null);
								};
							}
						}
					}
				}
			}
		}

		// // RVA: 0x16A0838 Offset: 0x16A0838 VA: 0x16A0838
		private void ShowSceneStatusPopup(GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo info, Transform parent, Action onClose)
		{
            GCIJNCFDNON_SceneInfo card = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[info.BCCHOBPJJKE_SceneId - 1];
			if(sceneStatePopup == null)
			{
				sceneStatePopup = new SceneStatePopupSetting();
				sceneStatePopup.SetParent(parent);
			}
			sceneStatePopup.PageSave = SceneStatusParam.PageSave.Player;
			sceneStatePopup.WindowSize = SizeType.Large;
			sceneStatePopup.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			sceneStatePopup.Scene = card;
			sceneStatePopup.PlayerData = GameManager.Instance.ViewPlayerData;
			sceneStatePopup.IsOpenAnimeMoment = false;
			sceneStatePopup.IsFriend = false;
			sceneStatePopup.IsDiableLuckyLeaf = true;
			sceneStatePopup.TitleText = GameMessageManager.GetSceneCardName(card.BCCHOBPJJKE_SceneId, card.JPIPENJGGDD_NumBoard, card.OPFGFINHFCE_SceneName);
			PopupWindowManager.Show(sceneStatePopup, (PopupWindowControl control, PopupButton.ButtonType label, PopupButton.ButtonLabel type) =>
			{
				//0x16A17CC
				if(onClose != null)
					onClose();
			}, null, null, null);
        }

		// RVA: 0x16A0CEC Offset: 0x16A0CEC VA: 0x16A0CEC Slot: 7
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x16A0CF4 Offset: 0x16A0CF4 VA: 0x16A0CF4 Slot: 8
		public void Show()
		{
			gameObject.SetActive(true);
			this.StartCoroutineWatched(Co_Show());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70D2AC Offset: 0x70D2AC VA: 0x70D2AC
		// // RVA: 0x16A0D48 Offset: 0x16A0D48 VA: 0x16A0D48
		private IEnumerator Co_Show()
		{
			//0x16A17E4
			yield return null;
			if(fxScrollView != null)
			{
				fxScrollView.UpdateItemListener += UpdateContent;
				fxScrollView.SetupListItem(m_list);
				fxScrollView.SetlistTop(0);
				fxScrollView.SetZeroVelocity();
				fxScrollView.VisibleRangeUpdate();
			}
		}

		// RVA: 0x16A0DF4 Offset: 0x16A0DF4 VA: 0x16A0DF4 Slot: 9
		public void Hide()
		{
			gameObject.SetActive(false);
			if(fxScrollView != null)
			{
				fxScrollView.AllFree();
				fxScrollView.UpdateItemListener -= UpdateContent;
				fxScrollView.Release();
			}
		}

		// RVA: 0x16A0F0C Offset: 0x16A0F0C VA: 0x16A0F0C Slot: 10
		public bool IsReady()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning && (layoutSingle != null || fxScrollView != null) && m_loading == null;
		}

		// RVA: 0x16A1020 Offset: 0x16A1020 VA: 0x16A1020 Slot: 11
		public void CallOpenEnd()
		{
			return;
		}
	}
}
