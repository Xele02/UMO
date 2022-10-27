using UnityEngine.Events;
using System.Collections.Generic;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameSpecialNotesAssigner
	{
		private struct AssignedRareItemNoteInfo
		{
			public int noteListIndex; // 0x0
			public int rareItemIndex; // 0x4
		}

		public class AssignInfo
		{
			public bool m_center_live_skill; // 0x8
			public int m_center_live_skill_index; // 0xC
			public bool m_event_item; // 0x10
			public int m_event_item_index; // 0x14
		}

		private AssignInfo m_assign_info = new AssignInfo(); // 0x8
		private UnityAction<int, KLJCBKMHKNK.HHMPIIILOLD, RhythmGameConsts.SpecialNoteType> onModeAttrAssignCallback; // 0xC
		private UnityAction<int, KLJCBKMHKNK.HHMPIIILOLD, int, int> onModeItemInfoAssignCallback; // 0x10
		private int notesCount; // 0x14
		private List<int>[] modeNotesIndices; // 0x18
		private HNJKJCDDIMG_SetInfo itemSet; // 0x1C
		private OPGDJANLKBM_RateInfo rateSet; // 0x20
		private List<int> itemWeightTable; // 0x24
		private int rareItemRandSeed; // 0x28
		private int[] itemLotCountList; // 0x2C

		// // RVA: 0xC08F90 Offset: 0xC08F90 VA: 0xC08F90
		public void Initialize(MusicData musicData, AssignInfo a_assign_info, UnityAction<int, KLJCBKMHKNK.HHMPIIILOLD, RhythmGameConsts.SpecialNoteType> onModeAttrAssignCallback, UnityAction<int, KLJCBKMHKNK.HHMPIIILOLD, int, int> onModeItemInfoAssignCallback)
		{
			this.onModeItemInfoAssignCallback = onModeItemInfoAssignCallback;
			this.onModeAttrAssignCallback = onModeAttrAssignCallback;
			m_assign_info = a_assign_info;
			modeNotesIndices = new List<int>[4];
			for(int i = 0; i < 4; i++)
			{
				modeNotesIndices[i] = new List<int>();
			}
			for(int i = 0; i < musicData.musicScoreData.inputNoteTrack.Count; i++)
			{
				modeNotesIndices[(int)musicData.GetNotesModeType(musicData.musicScoreData.inputNoteTrack[i])].Add(i);
			}
			notesCount = musicData.musicScoreData.inputNoteTrack.Count;
			GDMKJMAFJAG g = new GDMKJMAFJAG();
			g.KHEKNNFCAOI(GetDropItemSet(), GetDropRateSet());
			itemSet = g.GEDOFFFKIFN;
			rateSet = g.CGLAEOLPEGN;
			if (g.CGLAEOLPEGN != null && g.GEDOFFFKIFN != null)
			{
				itemWeightTable = new List<int>(g.CGLAEOLPEGN.ADKDHKMPMHP_Rat);
				for(int i = 0; i < itemWeightTable.Count; i++)
				{
					if(itemSet.FKNBLDPIPMC(i) == 0)
					{
						itemWeightTable[i] = 0;
					}
				}
				itemLotCountList = new int[rateSet.ADKDHKMPMHP_Rat.Count];
			}
		}

		// // RVA: 0xC09A1C Offset: 0xC09A1C VA: 0xC09A1C
		// private void AssginFromList(List<RNote> rNoteList, ref List<int>[] a_temp_note_list, RhythmGameConsts.SpecialNoteType a_type, int a_index = -1) { }

		// // RVA: 0xC09D54 Offset: 0xC09D54 VA: 0xC09D54
		public void Assign(List<RNote> rNoteList)
		{
			if (Database.Instance.gameSetup.musicInfo.isStoryMode)
				return;
			KEODKEGFDLD musicinfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(Database.Instance.gameSetup.musicInfo.freeMusicId);
			short[] l = Database.Instance.gameSetup.musicInfo.IsLine6Mode ? musicinfo.DPJDHKIIJIJ : musicinfo.OCOGIADDNDN;
			if (l[(int)Database.Instance.gameSetup.musicInfo.difficultyType] < 1)
				return;
			List<int>[] l2 = new List<int>[4];
			for(int i = 0; i < l2.Length; i++)
			{
				l2[i] = new List<int>(modeNotesIndices[i]);
				for(int j = l2[i].Count - 1; j >= 0; j--)
				{
					if(rNoteList[l2[i][j]].noteInfo.longTouch == MusicScoreData.TouchState.Continue)
					{
						l2[i].RemoveAt(j);
					}
				}
			}
			if(m_assign_info.m_event_item)
			{
				AssginFromList(rNoteList, l2, 8, ??);
			}
			if(m_assign_info.m_center_live_skill)
			{
				AssginFromList(rNoteList, l2, 7, ??);
			}
			rareItemRandSeed = Random.Range(0, 100000);
			int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.NBIAKELCBLC(Database.Instance.gameSetup.teamInfo.teamLuck, rareItemRandSeed);
			if (Database.Instance.gameSetup.musicInfo.gameEventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL || Database.Instance.gameSetup.musicInfo.openEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA)
			{
				a = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.NBIAKELCBLC(Database.Instance.gameSetup.musicInfo.gameEventType, Database.Instance.gameSetup.musicInfo.openEventType, Database.Instance.gameSetup.musicInfo.difficultyType, Database.Instance.gameSetup.musicInfo.IsLine6Mode, Database.Instance.gameSetup.teamInfo.teamLuck, rareItemRandSeed);
			}
			List<DNAEGJGAKEI> ld = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HGLIIPFLMFB_Drop.JMHHEPMILHA(musicinfo, Database.Instance.gameSetup.musicInfo.difficultyType, Database.Instance.gameSetup.musicInfo.gameEventType, Database.Instance.gameSetup.musicInfo.openEventType, a, this.OnRareItemRandomLot, Database.Instance.gameSetup.musicInfo.IsLine6Mode);
			if (ld == null || ld.Count < 1)
			{
				a = 0;
			}
			int b = 0;
			if(!Database.Instance.gameSetup.musicInfo.isTutorialOne)
			{
				b = a;
				if (Database.Instance.gameSetup.musicInfo.isTutorialTwo)
					b = 0;
			}
			int c = (b * 0x55555556) >> 0x20;
			c = (c - c >> 0x1f);
			b = b + c * -3;
			int[] li = new int[4];
			li[1] = c + (b > 0 ? 1 : 0);
			int d = c;
			if (b > 1)
				d++;
			li[2] = d;
			li[3] = c;

			EGLJKICMCPG[] ar = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.BBFNPHGDCOF(l[(int)Database.Instance.gameSetup.musicInfo.difficultyType]).CDENCMNHNGA.ToArray();
			int[] li2 = new int[6];
			MusicData.NoteModeType[] nt = new MusicData.NoteModeType[6] { BB78C0550E8F09BCD95AC92C66D1BE4F5255FD10 };
			for (int i = 0; i < 6; i++)
			{
				int t = li[(int)nt[i]];
				li[(int)nt[i]] = Mathf.Min(li[(int)nt[i]], l2[(int)nt[i]].Count);

				int v = Mathf.Clamp((int)(ar[i].PHGLKBPLFDH_RMax / 100.0f * l2[(int)nt[i]].Count), ar[i].MPPANPOOIIB_NMin, ar[i].GKPPCFMBANO_NMax);
				t = (t - l2[(int)nt[i]].Count) + v;
				if (t > 0)
					v = v - t;
				li2[i] = v;
			}

			RhythmGameConsts.SpecialNoteType[] st = new RhythmGameConsts.SpecialNoteType[6] { D49780DCC9EB17A96D48BCA54DECC227BC5AB890 };
			List<AssignedRareItemNoteInfo>[] ari = new List<AssignedRareItemNoteInfo>[4];
			for(int i = 0; i < ari.Length; i++)
			{
				ari[i] = new List<AssignedRareItemNoteInfo>(li[i]);
			}

			int[,] li3 = new int[6, 6];
			int sum = 0;
			for(int i = 0; i < 6; i++)
			{
				List<int> l3 = new List<int>(li2[(int)nt[i]]);
				for(int j = 0; j < 5; j++)
				{
					if(ar[i].JNNKKPNGPAA(j + 1) > -1)
					{
						sum += ar[i].JNNKKPNGPAA(j + 1) + Database.Instance.gameSetup.teamInfo.teamStatus.spNoteExpected[j + 1] / 10;
					}
				}
				for (int j = 0; j < 5; j++)
				{
					int m = 0;
					if (ar[i].JNNKKPNGPAA(j + 1) < 0)
					{
						//nothing
					}
					else
					{
						if(sum < 100 || (j + 1) == ar[i].DAPGDCPDCNA_Pri)
						{
							//LAB_00c0b118
							m = Mathf.RoundToInt((Database.Instance.gameSetup.teamInfo.teamStatus.spNoteExpected[j + 1] / 10 + ar[i].JNNKKPNGPAA(j + 1)) / 100 * li2[i]);
						}
						else
						{
							int n = (Database.Instance.gameSetup.teamInfo.teamStatus.spNoteExpected[ar[i].DAPGDCPDCNA_Pri] / 10 + ar[i].JNNKKPNGPAA(ar[i].DAPGDCPDCNA_Pri));
							m = (Database.Instance.gameSetup.teamInfo.teamStatus.spNoteExpected[j + 1] / 10 + ar[i].JNNKKPNGPAA(ar[i].DAPGDCPDCNA_Pri)) / (sum - n) * (li2[i] - Mathf.RoundToInt(n / 100 * li2[i]));
						}
					}
					li3[j + 1, i] = m;
				}
				if (ari[i].Count < 1)
				{
					for (int j = 0; j < li[i]; j++)
					{
						int v = Random.Range(0, l3.Count);
						onModeAttrAssignCallback(l3[v], (KLJCBKMHKNK.HHMPIIILOLD)i, RhythmGameConsts.SpecialNoteType.RareItem);
						onModeItemInfoAssignCallback(l3[v], (KLJCBKMHKNK.HHMPIIILOLD)i, ld[j].GCKKKIDNACI, ld[j].HFCGOHDOHAP);
						l3.RemoveAt(v);
					}
				}
				else
				{
					for (int j = 0; j < ari[i].Count; j++)
					{
						int v = Random.Range(0, l3.Count);
						onModeAttrAssignCallback(l3[v], (KLJCBKMHKNK.HHMPIIILOLD)i, RhythmGameConsts.SpecialNoteType.RareItem);
						onModeItemInfoAssignCallback(l3[v], (KLJCBKMHKNK.HHMPIIILOLD)i, ld[j].GCKKKIDNACI, ld[j].HFCGOHDOHAP);
						l3.RemoveAt(v);
					}
				}
			}

			TodoLogger.Log(0, "Assign");

			!!!
		}

		// // RVA: 0xC0BFB8 Offset: 0xC0BFB8 VA: 0xC0BFB8
		// private int OnRareItemRandomLot() { }

		// // RVA: 0xC0BFCC Offset: 0xC0BFCC VA: 0xC0BFCC
		// public int GetRareItemRandomSeed() { }

		// // RVA: 0xC0BD90 Offset: 0xC0BD90 VA: 0xC0BD90
		// private void AllotItemNotes(int noteIndex, KLJCBKMHKNK.HHMPIIILOLD mode) { }

		// // RVA: 0xC0BFD4 Offset: 0xC0BFD4 VA: 0xC0BFD4
		// private int LotsItem(List<int> weightTable) { }

		// // RVA: 0xC0C154 Offset: 0xC0C154 VA: 0xC0C154
		// private float GetItemDropRate() { }

		// // RVA: 0xC09714 Offset: 0xC09714 VA: 0xC09714
		private OPGDJANLKBM_RateInfo GetDropRateSet()
		{
			int v = 0;
			if (Database.Instance.gameSetup.musicInfo.isFreeMode)
			{
				v = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(Database.Instance.gameSetup.musicInfo.freeMusicId).KDIKCKEEPDA(Database.Instance.gameSetup.musicInfo.IsLine6Mode);
				if (JEPBIIJDGEF_EventInfo.HHCJCDFCLOB != null && JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB(KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI, false) != null)
				{
					TodoLogger.Log(0, "GetDropItemSet event");
				}
				v += (int)Database.Instance.gameSetup.musicInfo.difficultyType;
			}
			else
			{
				v = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData(Database.Instance.gameSetup.musicInfo.storyMusicId).KCNHKNKNGNH;
			}
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HGLIIPFLMFB_Drop.KPDHGNEILPO(v);
		}

		// // RVA: 0xC09410 Offset: 0xC09410 VA: 0xC09410
		private HNJKJCDDIMG_SetInfo GetDropItemSet()
		{
			int v = 0;
			if(Database.Instance.gameSetup.musicInfo.isFreeMode)
			{
				v = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(Database.Instance.gameSetup.musicInfo.freeMusicId).MGLDIOILOFF;
				if (JEPBIIJDGEF_EventInfo.HHCJCDFCLOB != null && JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB(KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI, false) != null)
				{
					TodoLogger.Log(0, "GetDropItemSet event");
				}
			}
			else
			{
				v = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData(Database.Instance.gameSetup.musicInfo.storyMusicId).MGLDIOILOFF;
			}
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HGLIIPFLMFB_Drop.NMGAAKPJPLB(v);
		}
	}
}
