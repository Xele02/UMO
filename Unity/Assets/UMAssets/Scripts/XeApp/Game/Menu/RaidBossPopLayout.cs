using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class RaidBossPopLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_bossNameText; // 0x14
		[SerializeField]
		private RawImageEx m_bossImage; // 0x18
		[SerializeField]
		private bool isSp; // 0x1C
		private AbsoluteLayout m_layoutMain; // 0x20
		private AbsoluteLayout m_layoutRank; // 0x24
		private bool m_isShow; // 0x28

		// RVA: 0x145E140 Offset: 0x145E140 VA: 0x145E140 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			if(!isSp)
			{
				m_layoutMain = layout.FindViewByExId("root_sel_music_raid_boss_pop_n_cc_sw_raid_boss_pop_n_set_anim") as AbsoluteLayout;
				m_layoutRank = layout.FindViewByExId("sw_raid_boss_pop_n_set_anim_sw_raid_boss_rank_l") as AbsoluteLayout;
			}
			else
			{
				m_layoutMain = layout.FindViewByExId("root_sel_music_raid_boss_pop_sp_cc_sw_raid_boss_pop_sp_set_anim") as AbsoluteLayout;
				m_layoutRank = layout.FindViewByExId("sw_raid_boss_pop_sp_set_anim_sw_raid_boss_rank_l") as AbsoluteLayout;
			}
			m_isShow = false;
			Loaded();
			return true;
		}

		// RVA: 0x145E01C Offset: 0x145E01C VA: 0x145E01C
		public void StartAnimation()
		{
			m_layoutMain.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x145DE84 Offset: 0x145DE84 VA: 0x145DE84
		public void SetRank(string str)
		{
			m_layoutRank.StartChildrenAnimGoStop(str, str);
		}

		// RVA: 0x145DE48 Offset: 0x145DE48 VA: 0x145DE48
		public void SetName(string name)
		{
			m_bossNameText.text = name;
		}

		// RVA: 0x145DEBC Offset: 0x145DEBC VA: 0x145DEBC
		public void SetBossImage(int bossType, Action callback)
		{
			GameManager.Instance.RaidBossTextureCache.LoadForBossCutin(bossType, (IiconTexture icon) =>
			{
				//0x145E52C
				icon.Set(m_bossImage);
				callback();
			});
		}

		// RVA: 0x145D844 Offset: 0x145D844 VA: 0x145D844
		public bool IsPlaying()
		{
			return m_layoutMain.IsPlayingChildren();
		}

		// // RVA: 0x145E35C Offset: 0x145E35C VA: 0x145E35C
		// public void Show() { }

		// // RVA: 0x145D768 Offset: 0x145D768 VA: 0x145D768
		public void Hide()
		{
			m_isShow = false;
			m_layoutMain.StartChildrenAnimGoStop("st_in", "st_in");
		}

		// // RVA: 0x145E3E4 Offset: 0x145E3E4 VA: 0x145E3E4
		// public void Enter() { }

		// // RVA: 0x145E484 Offset: 0x145E484 VA: 0x145E484
		// public void Leave() { }
	}
}
