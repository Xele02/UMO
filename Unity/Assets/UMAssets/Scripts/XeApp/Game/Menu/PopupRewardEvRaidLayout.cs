using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using mcrs;
using XeSys;
using System;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class PopupRewardEvRaidLayout : LayoutUGUIScriptBase
	{
		public enum EnemyType
		{
			Normal = 0,
			Ex = 1,
		}

		public enum RewardType
		{
			RewardDefeat = 0,
			Reward1st = 1,
			RewardMvp = 2,
		}

		private AbsoluteLayout m_windowStyleTable; // 0x14
		[SerializeField] // RVA: 0x67B03C Offset: 0x67B03C VA: 0x67B03C
		private SwapScrollList m_scrollList; // 0x18
		private RawImageEx m_imageChangeEnemy; // 0x1C
		private List<IIMNHDGFDAG> m_defeatNormalRewardList = new List<IIMNHDGFDAG>(); // 0x20
		private List<IIMNHDGFDAG> m_1stNormalRewardList = new List<IIMNHDGFDAG>(); // 0x24
		private List<IIMNHDGFDAG> m_mvpNormalRewardList = new List<IIMNHDGFDAG>(); // 0x28
		private List<IIMNHDGFDAG> m_defeatExRewardList = new List<IIMNHDGFDAG>(); // 0x2C
		private List<IIMNHDGFDAG> m_1stExRewardList = new List<IIMNHDGFDAG>(); // 0x30
		private List<IIMNHDGFDAG> m_mvpExRewardList = new List<IIMNHDGFDAG>(); // 0x34
		private ActionButton m_switchEnemyTypeButton; // 0x38
		private AbsoluteLayout m_rewardTypeAnim; // 0x3C
		private AbsoluteLayout m_windowInfoAnim; // 0x40
		private RawImageEx m_itemRewardImage; // 0x44
		private Text m_windowInfoText; // 0x48
		private RewardType m_rewardType; // 0x4C
		private EnemyType m_enemyType; // 0x50
		private HighScoreRatingRank.Type m_playerUtaGrade; // 0x54
		private TexUVList m_texUv_02; // 0x58
		private string m_utaGradeMoreText = ""; // 0x5C

		// // RVA: 0x1A7936C Offset: 0x1A7936C VA: 0x1A7936C
		private List<IIMNHDGFDAG> CurrentViewList()
		{
			if(m_rewardType == RewardType.RewardMvp)
			{
				if(m_enemyType == EnemyType.Normal)
				{
					return m_mvpNormalRewardList;
				}
				else
				{
					return m_mvpExRewardList;
				}
			}
			else if(m_rewardType == RewardType.Reward1st)
			{
				if(m_enemyType == EnemyType.Normal)
				{
					return m_1stNormalRewardList;
				}
				else
				{
					return m_1stExRewardList;
				}
			}
			else if(m_rewardType == RewardType.RewardDefeat)
			{
				if(m_enemyType == EnemyType.Normal)
				{
					return m_defeatNormalRewardList;
				}
				else
				{
					return m_defeatExRewardList;
				}
			}
			Debug.LogError("not exist ViewList");
			return m_defeatNormalRewardList;
		}

		// RVA: 0x1A7945C Offset: 0x1A7945C VA: 0x1A7945C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_texUv_02 = uvMan.GetTexUVList("pop_reward_ev2_02_pack");
			RawImageEx[] imgs = GetComponentsInChildren<RawImageEx>(true);
			m_imageChangeEnemy = imgs.Where((RawImageEx _) =>
			{
				//0x1A7B534
				return _.name == "swtexf_p_r_e_tgl_fnt_01 (ImageView)";
			}).First();
			m_imageChangeEnemy.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_texUv_02.GetUVData("p_r_e_tgl_fnt_02"));
			m_rewardTypeAnim = layout.FindViewByExId("sw_pop_reward_ev_check_2_swtbl_pop_reward_ev_fnt_3") as AbsoluteLayout;
			m_windowInfoAnim = layout.FindViewByExId("sw_pop_reward_ev_check_2_swtbl_pop_reward_ev_fnt_2") as AbsoluteLayout;
			m_itemRewardImage = imgs.Where((RawImageEx _) =>
			{
				//0x1A7B5B4
				return _.name == "swtexc_cmn_item (ImageView)";
			}).First();
			m_itemRewardImage.enabled = false;
			Text[] txts = GetComponentsInChildren<Text>(true);
			m_windowInfoText = txts.Where((Text _) =>
			{
				//0x1A7B634
				return _.name == "desk2 (TextView)";
			}).First();
			m_switchEnemyTypeButton = GetComponentInChildren<ActionButton>(true);
			m_switchEnemyTypeButton.AddOnClickCallback(() =>
			{
				//0x1A7B3B0
				if(m_enemyType == EnemyType.Normal)
				{
					m_enemyType = EnemyType.Ex;
					m_imageChangeEnemy.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_texUv_02.GetUVData("p_r_e_tgl_fnt_01"));
				}
				else if(m_enemyType == EnemyType.Ex)
				{
					m_enemyType = EnemyType.Normal;
					m_imageChangeEnemy.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_texUv_02.GetUVData("p_r_e_tgl_fnt_02"));
				}
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				UpdateUI();
			});
			Loaded();
			return true;
		}

		// // RVA: 0x1A79AB8 Offset: 0x1A79AB8 VA: 0x1A79AB8
		private void SetupScrollList(int count, int focus, bool resetScroll)
		{
			m_scrollList.SetItemCount(count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener(OnUpdateListItem);
			m_scrollList.ResetScrollVelocity();
			if(resetScroll)
				m_scrollList.SetPosition(focus, 0, 0, false);
			m_scrollList.VisibleRegionUpdate();
		}

		// // RVA: 0x1A79C8C Offset: 0x1A79C8C VA: 0x1A79C8C
		private void OnUpdateListItem(int index, SwapScrollListContent content)
		{
			PopupRewardEvRaidBossItemLayout l = content as PopupRewardEvRaidBossItemLayout;
			if(l != null)
			{
				l.SetRewardData(CurrentViewList()[index], m_playerUtaGrade, m_utaGradeMoreText);
			}
		}

		// RVA: 0x1A67B70 Offset: 0x1A67B70 VA: 0x1A67B70
		public void Setup(PopupTabButton.ButtonLabel label)
		{
			if(label >= PopupTabButton.ButtonLabel.RewardMVP && label < PopupTabButton.ButtonLabel.MusicRateDetail)
				m_rewardType = (RewardType)(25 - (int)label);
			else	
			{
				Debug.LogError("StringLiteral_19515");
				m_rewardType = RewardType.RewardMvp;
			}
			GHLGEECLCMH g = new GHLGEECLCMH();
			g.KHEKNNFCAOI(null, null);
			m_playerUtaGrade = g.LLNHMMBFPMA_ScoreRatingRanking;
			m_utaGradeMoreText = "";
			PKNOKJNLPOE_EventRaid ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
			if(ev != null)
			{
				m_utaGradeMoreText = ev.ICCEILFHKEL_GetUtaGradeMoreText();
			}
			int itemId = SpItemConstants.MakeItemId(SpItemConstants.SpItemId.RaidMedal);
			GameManager.Instance.ItemTextureCache.Load(itemId, (IiconTexture texture) =>
			{
				//0x1A7B3B4
				texture.Set(m_itemRewardImage);
				m_itemRewardImage.enabled = true;
			});
			UpdateUI();
		}

		// // RVA: 0x1A7A0AC Offset: 0x1A7A0AC VA: 0x1A7A0AC
		// private void ResetCell() { }

		// // RVA: 0x1A79DDC Offset: 0x1A79DDC VA: 0x1A79DDC
		private void UpdateUI()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(m_rewardType == RewardType.RewardDefeat)
			{
				m_rewardTypeAnim.StartChildrenAnimGoStop("03");
				m_windowInfoAnim.StartChildrenAnimGoStop("02");
				m_windowInfoText.text = bk.GetMessageByLabel("popup_event_reward_raid_info_disempowerment");
			}
			else if(m_rewardType == RewardType.Reward1st)
			{
				m_rewardTypeAnim.StartChildrenAnimGoStop("02");
				m_windowInfoAnim.StartChildrenAnimGoStop("01");
				m_windowInfoText.text = bk.GetMessageByLabel("popup_event_reward_raid_info_attack1st");
			}
			else if(m_rewardType == RewardType.RewardMvp)
			{
				m_rewardTypeAnim.StartChildrenAnimGoStop("01");
				m_windowInfoAnim.StartChildrenAnimGoStop("01");
				m_windowInfoText.text = bk.GetMessageByLabel("popup_event_reward_raid_info_mvp");
			}
			int a1 = CurrentViewList().Count - (int)m_playerUtaGrade;
			if(a1 < 1)
				a1 = 0;
			SetupScrollList(CurrentViewList().Count, a1, true);
		}

		// // RVA: 0x1A7A0B0 Offset: 0x1A7A0B0 VA: 0x1A7A0B0
		private void CreateRewardList(PopupRewardEvCheck.ViewRewardEvCheckData data)
		{
			m_defeatNormalRewardList.Clear();
			m_1stNormalRewardList.Clear();
			m_mvpNormalRewardList.Clear();
			m_defeatExRewardList.Clear();
			m_1stExRewardList.Clear();
			m_mvpExRewardList.Clear();
			if(data.normal_raidboss_info_list != null)
			{
				for(int i = 0; i < data.normal_raidboss_info_list.Count; i++)
				{
					IIMNHDGFDAG a1 = new IIMNHDGFDAG();
					IIMNHDGFDAG a2 = new IIMNHDGFDAG();
					IIMNHDGFDAG a3 = new IIMNHDGFDAG();
					a3.ILELGGCCGMJ_HighscoreRank = data.normal_raidboss_info_list[i].ILELGGCCGMJ_HighscoreRank;
					a2.ILELGGCCGMJ_HighscoreRank = data.normal_raidboss_info_list[i].ILELGGCCGMJ_HighscoreRank;
					a1.ILELGGCCGMJ_HighscoreRank = data.normal_raidboss_info_list[i].ILELGGCCGMJ_HighscoreRank;
					a3.DJEMBILEBFP_IsPlayerRank = data.normal_raidboss_info_list[i].DJEMBILEBFP_IsPlayerRank;
					a2.DJEMBILEBFP_IsPlayerRank = data.normal_raidboss_info_list[i].DJEMBILEBFP_IsPlayerRank;
					a1.DJEMBILEBFP_IsPlayerRank = data.normal_raidboss_info_list[i].DJEMBILEBFP_IsPlayerRank;
					a3.IOBJDNEGEBB_BossRankLower = data.normal_raidboss_info_list[i].IOBJDNEGEBB_RankLower;
					a2.IOBJDNEGEBB_BossRankLower = data.normal_raidboss_info_list[i].IOBJDNEGEBB_RankLower;
					a1.IOBJDNEGEBB_BossRankLower = data.normal_raidboss_info_list[i].IOBJDNEGEBB_RankLower;
					a3.PKLKOMIAKNL_BossRankUpper = data.normal_raidboss_info_list[i].PKLKOMIAKNL_RankUpper;
					a2.PKLKOMIAKNL_BossRankUpper = data.normal_raidboss_info_list[i].PKLKOMIAKNL_RankUpper;
					a1.PKLKOMIAKNL_BossRankUpper = data.normal_raidboss_info_list[i].PKLKOMIAKNL_RankUpper;
					a1.CHOIMPLAOCO_RewardCountLower = data.normal_raidboss_info_list[i].ABHGIJFDLMM_DefeatRewardCountLower;
					a1.EAOBPKJDDKC_RewardCountUpper = data.normal_raidboss_info_list[i].EMPCHHKMKBG_DefeatRewardCountUpper;
					a2.CHOIMPLAOCO_RewardCountLower = data.normal_raidboss_info_list[i].DFMBENKEIHF_FirstRewardCountLower;
					a2.EAOBPKJDDKC_RewardCountUpper = data.normal_raidboss_info_list[i].HDPONDIDHAN_FirstRewardCountUpper;
					a3.CHOIMPLAOCO_RewardCountLower = data.normal_raidboss_info_list[i].HCPJEHKMFHB_MvpRewardCountLower;
					a3.EAOBPKJDDKC_RewardCountUpper = data.normal_raidboss_info_list[i].IPJANNBLHMB_MvpRewardCountUpper;
					m_defeatNormalRewardList.Add(a1);
					m_1stNormalRewardList.Add(a2);
					m_mvpNormalRewardList.Add(a3);
				}
			}
			if(data.ex_raidboss_info_list != null)
			{
				for(int i = 0; i < data.ex_raidboss_info_list.Count; i++)
				{
					IIMNHDGFDAG d1 = new IIMNHDGFDAG();
					IIMNHDGFDAG d2 = new IIMNHDGFDAG();
					IIMNHDGFDAG d3 = new IIMNHDGFDAG();
					d3.ILELGGCCGMJ_HighscoreRank = data.ex_raidboss_info_list[i].ILELGGCCGMJ_HighscoreRank;
					d2.ILELGGCCGMJ_HighscoreRank = data.ex_raidboss_info_list[i].ILELGGCCGMJ_HighscoreRank;
					d1.ILELGGCCGMJ_HighscoreRank = data.ex_raidboss_info_list[i].ILELGGCCGMJ_HighscoreRank;
					d3.DJEMBILEBFP_IsPlayerRank = data.ex_raidboss_info_list[i].DJEMBILEBFP_IsPlayerRank;
					d2.DJEMBILEBFP_IsPlayerRank = data.ex_raidboss_info_list[i].DJEMBILEBFP_IsPlayerRank;
					d1.DJEMBILEBFP_IsPlayerRank = data.ex_raidboss_info_list[i].DJEMBILEBFP_IsPlayerRank;
					d3.IOBJDNEGEBB_BossRankLower = data.ex_raidboss_info_list[i].IOBJDNEGEBB_RankLower;
					d2.IOBJDNEGEBB_BossRankLower = data.ex_raidboss_info_list[i].IOBJDNEGEBB_RankLower;
					d1.IOBJDNEGEBB_BossRankLower = data.ex_raidboss_info_list[i].IOBJDNEGEBB_RankLower;
					d3.PKLKOMIAKNL_BossRankUpper = data.ex_raidboss_info_list[i].PKLKOMIAKNL_RankUpper;
					d2.PKLKOMIAKNL_BossRankUpper = data.ex_raidboss_info_list[i].PKLKOMIAKNL_RankUpper;
					d1.PKLKOMIAKNL_BossRankUpper = data.ex_raidboss_info_list[i].PKLKOMIAKNL_RankUpper;
					d1.CHOIMPLAOCO_RewardCountLower = data.ex_raidboss_info_list[i].ABHGIJFDLMM_DefeatRewardCountLower;
					d1.EAOBPKJDDKC_RewardCountUpper = data.ex_raidboss_info_list[i].EMPCHHKMKBG_DefeatRewardCountUpper;
					d2.CHOIMPLAOCO_RewardCountLower = data.ex_raidboss_info_list[i].DFMBENKEIHF_FirstRewardCountLower;
					d2.EAOBPKJDDKC_RewardCountUpper = data.ex_raidboss_info_list[i].HDPONDIDHAN_FirstRewardCountUpper;
					d3.CHOIMPLAOCO_RewardCountLower = data.ex_raidboss_info_list[i].HCPJEHKMFHB_MvpRewardCountLower;
					d3.EAOBPKJDDKC_RewardCountUpper = data.ex_raidboss_info_list[i].IPJANNBLHMB_MvpRewardCountUpper;
					m_defeatExRewardList.Add(d1);
					m_1stExRewardList.Add(d2);
					m_mvpExRewardList.Add(d3);
				}
			}
			m_defeatNormalRewardList.Reverse();
			m_1stNormalRewardList.Reverse();
			m_mvpNormalRewardList.Reverse();
			m_defeatExRewardList.Reverse();
			m_1stExRewardList.Reverse();
			m_mvpExRewardList.Reverse();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70E4F4 Offset: 0x70E4F4 VA: 0x70E4F4
		// // RVA: 0x1A6FAAC Offset: 0x1A6FAAC VA: 0x1A6FAAC
		public IEnumerator Co_LoadResource(PopupRewardEvCheck.ViewRewardEvCheckData data)
		{
			//0x1A7BEF4
			m_enemyType = EnemyType.Normal;
			CreateRewardList(data);
			yield return Co.R(Co_LoadLayoutListItem(null));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70E56C Offset: 0x70E56C VA: 0x70E56C
		// // RVA: 0x1A7AE50 Offset: 0x1A7AE50 VA: 0x1A7AE50
		private IEnumerator Co_LoadLayoutListItem(Action callback)
		{
			int poolSize; // 0x1C
			AssetBundleLoadLayoutOperationBase operation; // 0x20

			//0x1A7B838
			poolSize = m_scrollList.ScrollObjectCount;
			operation = AssetBundleManager.LoadLayoutAsync("ly/053.xab", "PopupRewardEvRaidBossItem");
			yield return operation;
			LayoutUGUIRuntime baseRuntime = null;
			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x1A7B6BC
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				baseRuntime.name = string.Format(baseRuntime + "_{0:D2}", 0);
				m_scrollList.AddScrollObject(baseRuntime.GetComponent<SwapScrollListContent>());
			}));
			AssetBundleManager.UnloadAssetBundle("ly/053.xab", false);
			for(int i = 1; i < poolSize; i++)
			{
				LayoutUGUIRuntime r = Instantiate(baseRuntime);
				r.name = string.Format(r.name + "_{0:D2}", i);
				r.IsLayoutAutoLoad = false;
				r.Layout = baseRuntime.Layout.DeepClone();
				r.UvMan = baseRuntime.UvMan;
				r.LoadLayout();
				m_scrollList.AddScrollObject(r.GetComponent<SwapScrollListContent>());
			}
			m_scrollList.Apply();
			m_scrollList.SetContentEscapeMode(true);
			while(!IsLoaded())
				yield return null;
			if(callback != null)
				callback();
		}

		// // RVA: 0x1A7AF18 Offset: 0x1A7AF18 VA: 0x1A7AF18
		// private bool IsLoaded() { }

		// // RVA: 0x1A7B01C Offset: 0x1A7B01C VA: 0x1A7B01C
		// private void OnClickChangeButton() { }

		// // RVA: 0x1A67E30 Offset: 0x1A67E30 VA: 0x1A67E30
		public void WaitAnimation(Action callback)
		{
			this.StartCoroutineWatched(Co_WaitAnimation(callback));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70E5E4 Offset: 0x70E5E4 VA: 0x70E5E4
		// // RVA: 0x1A7B1D0 Offset: 0x1A7B1D0 VA: 0x1A7B1D0
		private IEnumerator Co_WaitAnimation(Action callback)
		{
			//0x1A7C03C
			while(m_rewardTypeAnim.IsPlaying() && m_windowInfoAnim.IsPlaying())
				yield return null;
			callback();
		}
	}
}
