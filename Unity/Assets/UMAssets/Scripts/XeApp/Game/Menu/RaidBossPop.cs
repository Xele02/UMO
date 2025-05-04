using System;
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class RaidBossPop : MonoBehaviour
	{
		[SerializeField]
		private RaidBossPopLayout m_bossPopLayout; // 0xC
		[SerializeField]
		private RaidBossPopLayout m_spBossPopLayout; // 0x10
		private Action endCallback; // 0x14

		// RVA: 0x145D608 Offset: 0x145D608 VA: 0x145D608
		public void StartAnim(PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ bossInfo, Action _callback)
		{
			endCallback = _callback;
			this.StartCoroutineWatched(Co_StartAnim(bossInfo, bossInfo.IKICLMGFFPB_MissionIsSpecial ? m_spBossPopLayout : m_bossPopLayout));
		}

		// // RVA: 0x145D720 Offset: 0x145D720 VA: 0x145D720
		public void Hide()
		{
			m_bossPopLayout.Hide();
			m_spBossPopLayout.Hide();
		}

		// // RVA: 0x145D7F0 Offset: 0x145D7F0 VA: 0x145D7F0
		public bool IsPlaying()
		{
			return m_bossPopLayout.IsPlaying() || m_spBossPopLayout.IsPlaying();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x711CAC Offset: 0x711CAC VA: 0x711CAC
		// // RVA: 0x145D660 Offset: 0x145D660 VA: 0x145D660
		private IEnumerator Co_StartAnim(PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ bossInfo, RaidBossPopLayout layout)
		{
			PKNOKJNLPOE_EventRaid raidEventCtl;

			//0x145D93C
			MenuScene.Instance.InputDisable();
			raidEventCtl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
			layout.Hide();
			while(layout.IsPlaying())
				yield return null;
			layout.SetName(raidEventCtl.AGEJGHGEGFF_GetBossName(bossInfo.INDDJNMPONH_Type));
			layout.SetRank(RankLabel(bossInfo.FJOLNJLLJEJ_Rank));
			bool done = false;
			layout.SetBossImage(bossInfo.HPPDFBKEJCG_BgId, () =>
			{
				//0x145D92C
				done = true;
			});
			while(!done)
				yield return null;
			SoundManager.Instance.sePlayerRaid.Play((int)mcrs.cs_se_raid.SE_RAID_000);
			layout.StartAnimation();
			while(layout.IsPlaying())
				yield return null;
			endCallback();
			endCallback = null;
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0x145D890 Offset: 0x145D890 VA: 0x145D890
		private string RankLabel(int rank)
		{
			return string.Format("{0:D2}", rank);
		}
	}
}
