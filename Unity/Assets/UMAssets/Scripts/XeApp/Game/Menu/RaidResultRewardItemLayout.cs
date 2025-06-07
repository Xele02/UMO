using XeSys.Gfx;
using System;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RaidResultRewardItemLayout : LayoutUGUIScriptBase
	{
		private enum RewardType
		{
			Defeat = 0,
			Mvp = 1,
			First = 2,
			All = 3,
		}
 
		[Serializable]
		private class ItemCell
		{
			public AbsoluteLayout[] openAnim; // 0x8
			public RawImageEx[] itemImage; // 0xC
			public NumberBase[] itemNum; // 0x10
			public ActionButton[] itemIcon; // 0x14
		}

		[SerializeField]
		private ItemCell mvpItemCell; // 0x14
		[SerializeField]
		private ItemCell firstItemCell; // 0x18
		[SerializeField]
		private ItemCell defeatItemCell; // 0x1C
		[SerializeField]
		private Text m_bossNameText; // 0x20
		[SerializeField]
		private ActionButton m_memberListButton; // 0x24
		public Action onFinished; // 0x28
		public Action onClickButton; // 0x2C
		private PLFJMDBBAJD m_view; // 0x30
		private Matrix23 m_identity; // 0x34
		private Coroutine m_coroutine; // 0x4C
		private AbsoluteLayout m_layoutRoot; // 0x50
		private AbsoluteLayout m_layoutMain; // 0x54
		private AbsoluteLayout m_bossRank; // 0x58
		private AbsoluteLayout m_layoutMemberListButton; // 0x5C
		private bool m_isSkiped; // 0x60
		private bool m_isLoading; // 0x61
		private bool m_isChargeBonus; // 0x62
		private RewardType m_rewardType; // 0x64

		// RVA: 0x1BE269C Offset: 0x1BE269C VA: 0x1BE269C
		private void OnDisable()
		{
			if(SoundManager.Instance.sePlayerResultLoop.status != CriWare.CriAtomSource.Status.Playing)
				return;
			SoundManager.Instance.sePlayerResultLoop.Stop();
		}

		// RVA: 0x1BE2740 Offset: 0x1BE2740 VA: 0x1BE2740 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewByExId("sw_r_d_raid_win_anim_01_swtbl_get_item") as AbsoluteLayout;
			m_layoutMain = layout.FindViewByExId("swtbl_get_item_sw_getitem_set_01") as AbsoluteLayout;
			m_bossRank = layout.FindViewByExId("raid_drop_b_r_icon_base_set2_sw_raid_boss_rank") as AbsoluteLayout;
			m_layoutMemberListButton = layout.FindViewByExId("sw_r_d_raid_win_anim_01_sw_sel_music_btn_dtl_01_anim_01") as AbsoluteLayout;
			mvpItemCell.openAnim = new AbsoluteLayout[mvpItemCell.itemNum.Length];
			firstItemCell.openAnim = new AbsoluteLayout[firstItemCell.itemNum.Length];
			defeatItemCell.openAnim = new AbsoluteLayout[defeatItemCell.itemNum.Length];
			for(int i = 0; i < mvpItemCell.openAnim.Length; i++)
			{
				mvpItemCell.openAnim[i] = layout.FindViewByExId(string.Format("sw_getitem_set_01_sw_getitem_btn_anim_{0:D2}", i + 1)) as AbsoluteLayout;
				mvpItemCell.openAnim[i].StartChildrenAnimGoStop("st_wait", "st_wait");
			}
			for(int i = 0; i < firstItemCell.openAnim.Length; i++)
			{
				firstItemCell.openAnim[i] = layout.FindViewByExId(string.Format("sw_getitem_set_02_sw_getitem_btn_anim_{0:D2}", i + 1)) as AbsoluteLayout;
				firstItemCell.openAnim[i].StartChildrenAnimGoStop("st_wait", "st_wait");
			}
			for(int i = 0; i < defeatItemCell.openAnim.Length; i++)
			{
				defeatItemCell.openAnim[i] = layout.FindViewByExId(string.Format("sw_getitem_set_03_sw_getitem_btn_anim_{0:D2}", i + 1)) as AbsoluteLayout;
				defeatItemCell.openAnim[i].StartChildrenAnimGoStop("st_wait", "st_wait");
			}
			m_memberListButton.AddOnClickCallback(() =>
			{
				//0x1BE48E4
				onClickButton();
			});
			Loaded();
			return true;
		}

		// RVA: 0x1BE3190 Offset: 0x1BE3190 VA: 0x1BE3190
		public void Setup(PLFJMDBBAJD view)
		{
			m_isSkiped = false;
			m_view = view;
			m_coroutine = null;
			if(view.JAGJOLBDBDK_FirstRewards.Count != 0 && m_view.NEAPOLIIELG_MvpRewards.Count != 0)
			{
				m_rewardType = RewardType.All;
				m_layoutMain.StartSiblingAnimGoStop("04");
			}
			else
			{
				if(view.JAGJOLBDBDK_FirstRewards.Count == 0)
				{
					if(m_view.NEAPOLIIELG_MvpRewards.Count == 0)
					{
						m_rewardType = RewardType.Defeat;
						m_layoutMain.StartSiblingAnimGoStop("01");
					}
					else
					{
						m_rewardType = RewardType.Mvp;
						m_layoutMain.StartSiblingAnimGoStop("02");
					}
				}
				else
				{
					m_rewardType = RewardType.First;
					m_layoutMain.StartSiblingAnimGoStop("03");
				}
			}
			string s = string.Format("{0:D2}", m_view.FJOLNJLLJEJ_BossRank);
			m_bossRank.StartChildrenAnimGoStop(s, s);
			m_bossNameText.text = m_view.OPFGFINHFCE_Name;
			for(int i = 0; i < m_view.NEAPOLIIELG_MvpRewards.Count; i++)
			{
				mvpItemCell.itemNum[i].SetNumber(m_view.NEAPOLIIELG_MvpRewards[i].HMFFHLPNMPH_Count, 0);
				int idx = i;
				MenuScene.Instance.ItemTextureCache.Load(m_view.NEAPOLIIELG_MvpRewards[i].PPFNGGCBJKC, (IiconTexture texture) =>
				{
					//0x1BE4910
					texture.Set(mvpItemCell.itemImage[idx]);
				});
				mvpItemCell.itemIcon[i].AddOnClickCallback(() =>
				{
					//0x1BE4A50
					OnPushItemIcon(m_view.NEAPOLIIELG_MvpRewards[idx].PPFNGGCBJKC);
				});
			}
			for(int i = 0; i < m_view.JAGJOLBDBDK_FirstRewards.Count; i++)
			{
				firstItemCell.itemNum[i].SetNumber(m_view.JAGJOLBDBDK_FirstRewards[i].HMFFHLPNMPH_Count, 0);
				int idx = i;
				MenuScene.Instance.ItemTextureCache.Load(m_view.JAGJOLBDBDK_FirstRewards[i].PPFNGGCBJKC, (IiconTexture texture) =>
				{
					//0x1BE4B20
					texture.Set(firstItemCell.itemImage[idx]);
				});
				firstItemCell.itemIcon[i].AddOnClickCallback(() =>
				{
					//0x1BE4C60
					OnPushItemIcon(m_view.JAGJOLBDBDK_FirstRewards[idx].PPFNGGCBJKC);
				});
			}
			for(int i = 0; i < m_view.FGNHJFLBMIE_DefeatRewards.Count; i++)
			{
				defeatItemCell.itemNum[i].SetNumber(m_view.FGNHJFLBMIE_DefeatRewards[i].HMFFHLPNMPH_Count, 0);
				int idx = i;
				MenuScene.Instance.ItemTextureCache.Load(m_view.FGNHJFLBMIE_DefeatRewards[i].PPFNGGCBJKC, (IiconTexture texture) =>
				{
					//0x1BE4D30
					texture.Set(defeatItemCell.itemImage[idx]);
				});
				defeatItemCell.itemIcon[i].AddOnClickCallback(() =>
				{
					//0x1BE4E70
					OnPushItemIcon(m_view.FGNHJFLBMIE_DefeatRewards[idx].PPFNGGCBJKC);
				});
			}
			for(int i = 0; i < mvpItemCell.openAnim.Length; i++)
			{
				mvpItemCell.openAnim[i].StartChildrenAnimGoStop("st_wait", "st_wait");
			}
			for(int i = 0; i < firstItemCell.openAnim.Length; i++)
			{
				firstItemCell.openAnim[i].StartChildrenAnimGoStop("st_wait", "st_wait");
			}
			for(int i = 0; i < defeatItemCell.openAnim.Length; i++)
			{
				defeatItemCell.openAnim[i].StartChildrenAnimGoStop("st_wait", "st_wait");
			}
			m_layoutMemberListButton.StartChildrenAnimGoStop("st_wait", "st_wait");
		}

		// // RVA: 0x1BE4254 Offset: 0x1BE4254 VA: 0x1BE4254
		public void SkipBeginAnim()
		{
			m_isSkiped = true;
			if(m_coroutine != null)
				return;
			StartBeginAnim();
		}

		// // RVA: 0x1BE4294 Offset: 0x1BE4294 VA: 0x1BE4294
		public void StartBeginAnim()
		{
			m_coroutine = this.StartCoroutineWatched(Co_BeginAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x720384 Offset: 0x720384 VA: 0x720384
		// // RVA: 0x1BE42BC Offset: 0x1BE42BC VA: 0x1BE42BC
		private IEnumerator Co_BeginAnim()
		{
			//0x1BE4F44
			yield return Co.R(Co_EnterWindow());
			if(!m_isSkiped)
				yield return new WaitForSeconds(0.5f);
			yield return Co.R(Co_ItemShow());
			this.StartCoroutineWatched(Co_EnterButton());
			if(onFinished != null)
				onFinished();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7203FC Offset: 0x7203FC VA: 0x7203FC
		// // RVA: 0x1BE4368 Offset: 0x1BE4368 VA: 0x1BE4368
		private IEnumerator Co_EnterWindow()
		{
			//0x1BE536C
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_025);
			yield return Co.R(Co_WaitAnim(m_layoutRoot, true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x720474 Offset: 0x720474 VA: 0x720474
		// // RVA: 0x1BE4414 Offset: 0x1BE4414 VA: 0x1BE4414
		private IEnumerator Co_ItemShow()
		{
			int i;

			//0x1BE553C
			if(m_rewardType == RewardType.Mvp || m_rewardType == RewardType.All)
			{
				for(i = 0; i < m_view.NEAPOLIIELG_MvpRewards.Count; i++)
				{
					if(!m_isSkiped)
					{
						mvpItemCell.openAnim[i].StartChildrenAnimGoStop("go_in", "st_in");
						SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_025);
						yield return new WaitForSeconds(0.3f);
					}
					else
					{
						mvpItemCell.openAnim[i].StartChildrenAnimGoStop("st_in", "st_in");
					}
				}
			}
			if(m_rewardType == RewardType.First || m_rewardType == RewardType.All)
			{
				for(i = 0; i < m_view.JAGJOLBDBDK_FirstRewards.Count; i++)
				{
					if(!m_isSkiped)
					{
						firstItemCell.openAnim[i].StartChildrenAnimGoStop("go_in", "st_in");
						SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_025);
						yield return new WaitForSeconds(0.3f);
					}
					else
					{
						firstItemCell.openAnim[i].StartChildrenAnimGoStop("st_in", "st_in");
					}
				}
			}
			for(i = 0; i < m_view.FGNHJFLBMIE_DefeatRewards.Count; i++)
			{
				if(!m_isSkiped)
				{
					defeatItemCell.openAnim[i].StartChildrenAnimGoStop("go_in", "st_in");
					SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_025);
					yield return new WaitForSeconds(0.3f);
				}
				else
				{
					defeatItemCell.openAnim[i].StartChildrenAnimGoStop("st_in", "st_in");
				}
			}
			if(!m_isSkiped)
				yield return new WaitForSeconds(0.5f);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7204EC Offset: 0x7204EC VA: 0x7204EC
		// // RVA: 0x1BE44C0 Offset: 0x1BE44C0 VA: 0x1BE44C0
		private IEnumerator Co_EnterButton()
		{
			//0x1BE519C
			m_layoutMemberListButton.StartChildrenAnimGoStop("go_in", "st_in");
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_025);
			yield return Co.R(Co_WaitAnim(m_layoutMemberListButton, true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x720564 Offset: 0x720564 VA: 0x720564
		// // RVA: 0x1BE456C Offset: 0x1BE456C VA: 0x1BE456C
		// private IEnumerator Co_WaitLabel(AbsoluteLayout layout, string label, bool enableSkip = True) { }

		// [IteratorStateMachineAttribute] // RVA: 0x7205DC Offset: 0x7205DC VA: 0x7205DC
		// // RVA: 0x1BE4664 Offset: 0x1BE4664 VA: 0x1BE4664
		private IEnumerator Co_WaitAnim(AbsoluteLayout layout, bool enableSkip/* = True*/)
		{
			//0x1BE5C28
			while(layout.IsPlayingChildren())
			{
				if(!m_isSkiped || !enableSkip)
					yield return null;
				else
				{
					layout.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
					layout.UpdateAll(m_identity, Color.white);
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x720654 Offset: 0x720654 VA: 0x720654
		// // RVA: 0x1BE4744 Offset: 0x1BE4744 VA: 0x1BE4744
		// private IEnumerator Co_WaitAnimSibling(AbsoluteLayout layout, bool enableSkip = True) { }

		// // RVA: 0x1BE4824 Offset: 0x1BE4824 VA: 0x1BE4824
		private void OnPushItemIcon(int itemId)
		{
			MenuScene.Instance.ShowItemDetail(itemId, 0, null, null);
		}
	}
}
