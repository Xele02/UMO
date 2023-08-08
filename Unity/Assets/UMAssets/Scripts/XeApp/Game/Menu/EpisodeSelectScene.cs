using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;

namespace XeApp.Game.Menu
{
	public class EpisodeSelectScene : TransitionRoot
	{
		private Action mUpdater; // 0x48
		private EpisodeSceneIconCreater m_icon_creater; // 0x4C
		private EpisodeSortBtn m_btn_sort; // 0x50
		private StringBuilder m_strBuilder = new StringBuilder(64); // 0x54
		private List<PIGBBNDPPJC> m_list; // 0x58
		private List<PIGBBNDPPJC> m_list_filter; // 0x5C
		private bool isBeginner; // 0x60
		private const int BeginnerEpisodeId = 1;
		private const string BundleName = "ly/052.xab";
		private int m_init_episodeid = -1; // 0x64

		// RVA: 0xF05588 Offset: 0xF05588 VA: 0xF05588 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			m_icon_creater = transform.Find("IconCreater").GetComponent<EpisodeSceneIconCreater>();
			m_icon_creater.ScrollUpdateHander += UpdateScrollListItem;
			m_icon_creater.PushDetailButtonHandler += OnDetailButton;
			m_btn_sort = transform.Find("EpisodeSortBtn").GetComponent<EpisodeSortBtn>();
			m_btn_sort.SetDelegateChangeSort(OnChangeSort);
			m_btn_sort.SetDelegateChangeOrder(OnChangeSort);
			this.StartCoroutineWatched(WaitScrollItemInitializeCoroutine());
		}

		// RVA: 0xF058FC Offset: 0xF058FC VA: 0xF058FC Slot: 15
		protected override void OnDeleteCache()
		{
			AssetBundleManager.UnloadAssetBundle("ly/052.xab", false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DB7BC Offset: 0x6DB7BC VA: 0x6DB7BC
		//// RVA: 0xF05870 Offset: 0xF05870 VA: 0xF05870
		private IEnumerator WaitScrollItemInitializeCoroutine()
		{
			//0xF08058
			yield return AssetBundleManager.LoadUnionAssetBundle("ly/052.xab");
			while (!m_icon_creater.IsInitialized)
				yield return null;
			IsReady = true;
		}

		// RVA: 0xF059AC Offset: 0xF059AC VA: 0xF059AC Slot: 9
		protected override void OnStartEnterAnimation()
		{
			base.OnStartEnterAnimation();
			if(!isBeginner)
			{
				m_btn_sort.EnableSave(true);
				m_btn_sort.m_order = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CEJNPBFIIMJ_EpisodeSelect.EILKGEADKGH_order;
				m_btn_sort.m_sort = (SortItem)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CEJNPBFIIMJ_EpisodeSelect.LHPDCGNKPHD_sortItem;
			}
			else
			{
				m_btn_sort.EnableSave(false);
				m_btn_sort.m_order = 0;
				m_btn_sort.m_sort = SortItem.EpisodeNo;
			}
			OnChangeSort(m_btn_sort.m_sort, m_btn_sort.m_order);
			if(m_init_episodeid > 0)
			{
				int idx = m_list_filter.FindIndex((PIGBBNDPPJC x) =>
				{
					//0xF07184
					return x.KELFCMEOPPM_EpId == m_init_episodeid;
				});
				m_icon_creater.Scroll.ResetScrollVelocity();
				m_icon_creater.Scroll.SetPosition(idx, 0, 0, false);
				m_icon_creater.Scroll.VisibleRegionUpdate();
			}
			m_icon_creater.Enter();
			m_btn_sort.Enter();
		}

		// RVA: 0xF061F8 Offset: 0xF061F8 VA: 0xF061F8 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_icon_creater.IsPlaying();
		}

		// RVA: 0xF06224 Offset: 0xF06224 VA: 0xF06224 Slot: 12
		protected override void OnStartExitAnimation()
		{
			base.OnStartExitAnimation();
			m_icon_creater.Leave();
			m_icon_creater.Release();
			m_list = null;
			m_list_filter = null;
			m_btn_sort.Leave();
		}

		// RVA: 0xF06340 Offset: 0xF06340 VA: 0xF06340 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_icon_creater.IsPlaying();
		}

		// RVA: 0xF0636C Offset: 0xF0636C VA: 0xF0636C Slot: 16
		protected override void OnPreSetCanvas()
		{
			if (m_list == null)
				m_list = PIGBBNDPPJC.FKDIMODKKJD_GetAvaiableEpisodes(false);
			UpdateFilterList();
			isBeginner = false;
			if(Args != null && Args is EpisodeSelectSceneArgs)
			{
				isBeginner = (Args as EpisodeSelectSceneArgs).IsFromBeginner;
			}
			m_init_episodeid = -1;
			if(ArgsReturn != null && ArgsReturn is EpisodeDetailBackArgs)
			{
				m_init_episodeid = (ArgsReturn as EpisodeDetailBackArgs).data.KELFCMEOPPM_EpId;
			}
			TryInstall();
			m_icon_creater.InitializeScrollView(m_list_filter.Count, 0);
		}

		// RVA: 0xF06974 Offset: 0xF06974 VA: 0xF06974 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// RVA: 0xF06A14 Offset: 0xF06A14 VA: 0xF06A14 Slot: 23
		protected override void OnActivateScene()
		{
			if(isBeginner)
			{
				int idx = m_list_filter.FindIndex((PIGBBNDPPJC x) =>
				{
					return x.KELFCMEOPPM_EpId == 1;
				});
				if(idx > -1)
				{
					for(int i = 0; i < m_icon_creater.Scroll.ScrollObjectCount; i++)
					{
						if(m_icon_creater.Scroll.ScrollObjects[i].Index == idx)
						{
							if(i > -1)
							{
								if (!BasicTutorialManager.HasInstanced)
									BasicTutorialManager.Initialize();
								this.StartCoroutineWatched(SetupTutorial(m_icon_creater.Scroll.ScrollObjects[i].GetComponentInChildren<ButtonBase>()));
								return;
							}
						}
					}
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DB834 Offset: 0x6DB834 VA: 0x6DB834
		//// RVA: 0xF06D34 Offset: 0xF06D34 VA: 0xF06D34
		private IEnumerator SetupTutorial(ButtonBase button)
		{
			TodoLogger.LogError(0, "SetupTutorial");
			yield return null;
		}

		//// RVA: 0xF06DE0 Offset: 0xF06DE0 VA: 0xF06DE0
		private void UpdateScrollListItem(int index, EpisodeIcon content)
		{
			content.SetViewData(m_list_filter[index]);
		}

		//// RVA: 0xF06E84 Offset: 0xF06E84 VA: 0xF06E84
		private void OnDetailButton(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			EpisodeDetailArgs args = new EpisodeDetailArgs();
			args.data = m_list_filter[index];
			args.isFromBeginner = isBeginner;
			MenuScene.Instance.Call(TransitionList.Type.EPISODE_DETAIL, args, true);
		}

		//// RVA: 0xF068B0 Offset: 0xF068B0 VA: 0xF068B0
		private void TryInstall()
		{
			GameManager.Instance.EpisodeIconCache.TryInstallIcon(m_list);
		}

		//// RVA: 0xF05D08 Offset: 0xF05D08 VA: 0xF05D08
		private void OnChangeSort(SortItem a_item, int a_order)
		{
			UpdateFilterList();
			if(a_item == SortItem.EpisodeNo)
			{
				m_list_filter.Sort((PIGBBNDPPJC a, PIGBBNDPPJC b) =>
				{
					//0xF07468
					if(a_order == 1)
					{
						return b.FKMAEKNOLJB_EpisodeNo - a.FKMAEKNOLJB_EpisodeNo;
					}
					else
					{
						return a.FKMAEKNOLJB_EpisodeNo - b.FKMAEKNOLJB_EpisodeNo;
					}
				});
			}
			else if(a_item == SortItem.DivaAndValkyrie || a_item == SortItem.DivaValkyrieHomeBG)
			{
				LCLCCHLDNHJ_Costume t_master_cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume;
				JPIANKEOOMB_Valkyrie t_master_valkyrie = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie;
				ALJHJDHNFFB_HomeBg t_master_home_bg = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PFEKKPABPKL_HomeBg;
				m_list_filter.Sort((PIGBBNDPPJC a, PIGBBNDPPJC b) =>
				{
					//0xF075B4
					EKLNMHFCAOI.FKGCBLHOOCL_Category cat1 = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(a.KIJAPOFAGPN_UnlockItemId);
					EKLNMHFCAOI.FKGCBLHOOCL_Category cat2 = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(b.KIJAPOFAGPN_UnlockItemId);
					int itemId1 = EKLNMHFCAOI.DEACAHNLMNI_getItemId(a.KIJAPOFAGPN_UnlockItemId);
					int itemId2 = EKLNMHFCAOI.DEACAHNLMNI_getItemId(b.KIJAPOFAGPN_UnlockItemId);
					if (cat1 == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume && cat2 == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume)
					{
						LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos1 = t_master_cos.EEOADCECNOM_GetCostumeInfo(itemId1);
						LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos2 = t_master_cos.EEOADCECNOM_GetCostumeInfo(itemId2);
						if(a_order != 1)
						{
							LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo tmp = cos1;
							cos1 = cos2;
							cos2 = tmp;
						}
						int res = cos2.AHHJLDLAPAN_PrismDivaId - cos1.AHHJLDLAPAN_PrismDivaId;
						if (res != 0)
							return res;
						return cos2.JPIDIENBGKH_CostumeId - cos1.JPIDIENBGKH_CostumeId;
					}
					else if(cat1 == EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie && cat2 == EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie)
					{
						JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo valk1 = t_master_valkyrie.GCINIJEMHFK(itemId1);
						JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo valk2 = t_master_valkyrie.GCINIJEMHFK(itemId2);
						if (a_order != 1)
						{
							JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo tmp = valk1;
							valk1 = valk2;
							valk2 = tmp;
						}
						return valk2.IFGMKBKBFJI - valk1.IFGMKBKBFJI;
					}
					else if(cat1 == EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg && cat2 == EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg)
					{
						ALJHJDHNFFB_HomeBg.ADLLAFIDFAM homeBg1 = t_master_home_bg.GCINIJEMHFK(itemId1);
						ALJHJDHNFFB_HomeBg.ADLLAFIDFAM homeBg2 = t_master_home_bg.GCINIJEMHFK(itemId2);
						if (a_order != 1)
						{
							ALJHJDHNFFB_HomeBg.ADLLAFIDFAM tmp = homeBg1;
							homeBg1 = homeBg2;
							homeBg2 = tmp;
						}
						return homeBg2.PPFNGGCBJKC_Id - homeBg1.PPFNGGCBJKC_Id;
					}
					if(a_order == 1)
					{
						int res = b.KIJAPOFAGPN_UnlockItemId - a.KIJAPOFAGPN_UnlockItemId;
						if (res == 0)
							res = b.FKMAEKNOLJB_EpisodeNo - a.FKMAEKNOLJB_EpisodeNo;
						return res;
					}
					else
					{
						int res = a.KIJAPOFAGPN_UnlockItemId - b.KIJAPOFAGPN_UnlockItemId;
						if (res == 0)
							res = a.FKMAEKNOLJB_EpisodeNo - b.FKMAEKNOLJB_EpisodeNo;
						return res;
					}
				});
			}
			else if(a_item == SortItem.EpisodePoint)
			{
				m_list_filter.Sort((PIGBBNDPPJC a, PIGBBNDPPJC b) =>
				{
					//0xF074DC
					if(a_order != 1)
					{
						PIGBBNDPPJC tmp = a;
						a = b;
						b = tmp;
					}
					int res = b.ABLHIAEDJAI_CurrentPoint - a.ABLHIAEDJAI_CurrentPoint;
					if (res == 0)
						res = b.FKMAEKNOLJB_EpisodeNo - a.FKMAEKNOLJB_EpisodeNo;
					return res;
				});
			}
			m_icon_creater.InitializeScrollView(m_list_filter.Count, 0);
			m_icon_creater.Scroll.ResetScrollVelocity();
			m_icon_creater.Scroll.SetPosition(0, 0, 0, false);
			m_icon_creater.Scroll.VisibleRegionUpdate();
		}

		//// RVA: 0xF064FC Offset: 0xF064FC VA: 0xF064FC
		private void UpdateFilterList()
		{
			m_list_filter = new List<PIGBBNDPPJC>();
			if(m_list != null)
			{
				int divaValFilter = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CEJNPBFIIMJ_EpisodeSelect.IKEMMEAEPLM_filterDivaAndVal;
				int epFilter = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CEJNPBFIIMJ_EpisodeSelect.CNGFLNMNIMJ_filterMainEp;
				int seriesFilter = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CEJNPBFIIMJ_EpisodeSelect.JFOPNJOOGNI_filterSeriese;
				if(isBeginner)
				{
					divaValFilter = 0;
					epFilter = 0;
					seriesFilter = 0;
				}
				for(int i = 0; i < m_list.Count; i++)
				{
					uint val = PopupFilterSortParts_FilterMainEp.CreateBit(m_list[i]);
					uint val2 = PopupFilterSortParts_FilterSeries.CreateBit(m_list[i]);
					uint val3 = PopupFilterSortParts_FilterDiva2.CreateBit(m_list[i]);
					if ((epFilter == 0 || (epFilter & val) != 0) && (seriesFilter == 0 || (seriesFilter & val2) != 0) && (divaValFilter == 0 || (divaValFilter & val3) != 0))
					{
						m_list_filter.Add(m_list[i]);
					}
				}
			}
		}
	}
}
