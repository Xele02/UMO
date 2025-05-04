using XeSys.Gfx;
using UnityEngine;
using System;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class RaidBossSelectImageLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_bossImage; // 0x14
		private AbsoluteLayout m_layoutMain; // 0x18
		private bool m_isShow; // 0x1C
		private int m_eventId; // 0x20

		// RVA: 0x145F008 Offset: 0x145F008 VA: 0x145F008 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_isShow = false;
			m_layoutMain = layout.FindViewByExId("root_sel_music_raid_boss_select_cc_sw_sel_music_raid_boss_select_anim") as AbsoluteLayout;
			m_eventId = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived).PGIIDPEGGPI_EventId;
			Loaded();
			return true;
		}

		// RVA: 0x145F164 Offset: 0x145F164 VA: 0x145F164
		public void SetBossImage(int bossId, Action endCallback)
		{
			GameManager.Instance.RaidBossTextureCache.LoadForBoss(bossId, (IiconTexture icon) =>
			{
				//0x145F738
				icon.Set(m_bossImage);
				if(endCallback != null)
					endCallback();
			});
		}

		// // RVA: 0x145F2CC Offset: 0x145F2CC VA: 0x145F2CC
		// public void Show() { }

		// // RVA: 0x145F354 Offset: 0x145F354 VA: 0x145F354
		public void Hide()
		{
			m_isShow = false;
			m_layoutMain.StartChildrenAnimGoStop("st_out", "st_out");
		}

		// // RVA: 0x145F3DC Offset: 0x145F3DC VA: 0x145F3DC
		public void Enter(Action endCallback)
		{
			if(!m_isShow)
			{
				m_layoutMain.StartChildrenAnimGoStop("go_in", "st_in");
				this.StartCoroutineWatched(AnimEnd(() =>
				{
					//0x145F844
					if(endCallback != null)
						endCallback();
				}));
			}
			m_isShow = true;
		}

		// // RVA: 0x145F5B8 Offset: 0x145F5B8 VA: 0x145F5B8
		public void Leave()
		{
			if(m_isShow)
			{
				m_layoutMain.StartChildrenAnimGoStop("go_out", "st_out");
				this.StartCoroutineWatched(AnimEnd(() =>
				{
					//0x145F700
					gameObject.SetActive(false);
				}));
			}
			m_isShow = false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x711E5C Offset: 0x711E5C VA: 0x711E5C
		// // RVA: 0x145F510 Offset: 0x145F510 VA: 0x145F510
		private IEnumerator AnimEnd(Action callback)
		{
			//0x145F85C
			while(m_layoutMain.IsPlayingChildren())
				yield return null;
			callback();
		}

		// // RVA: 0x145F6CC Offset: 0x145F6CC VA: 0x145F6CC
		public bool IsPlaying()
		{
			return m_layoutMain.IsPlayingChildren();
		}
	}
}
