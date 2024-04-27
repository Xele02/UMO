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
				itemWeightTable = new List<int>(g.CGLAEOLPEGN.ADKDHKMPMHP_Rate);
				for(int i = 0; i < itemWeightTable.Count; i++)
				{
					if(itemSet.FKNBLDPIPMC_GetItemId(i) == 0)
					{
						itemWeightTable[i] = 0;
					}
				}
				itemLotCountList = new int[rateSet.ADKDHKMPMHP_Rate.Count];
			}
		}

		// // RVA: 0xC09A1C Offset: 0xC09A1C VA: 0xC09A1C
		private void AssginFromList(List<RNote> rNoteList, ref List<int>[] a_temp_note_list, RhythmGameConsts.SpecialNoteType a_type, int a_index = -1)
		{
			int step = Random.Range(1, 4);
			int idx = Random.Range(0, a_temp_note_list[step].Count);
			KLJCBKMHKNK.HHMPIIILOLD[] array = null;
			if (step == 3)
			{
				array = new KLJCBKMHKNK.HHMPIIILOLD[3] { /*2*/KLJCBKMHKNK.HHMPIIILOLD.FMLPIOFBCMA_Diva, /*5*/KLJCBKMHKNK.HHMPIIILOLD.FDBLOGGAKOE_DivaFail, /*3*/ KLJCBKMHKNK.HHMPIIILOLD.CBHCEDGAGHL_AwakenDiva};
			}
			else if(step == 2)
			{
				array = new KLJCBKMHKNK.HHMPIIILOLD[2] { /*1*/KLJCBKMHKNK.HHMPIIILOLD.PFIOMNHDHCO_Valkyrie, /*4*/KLJCBKMHKNK.HHMPIIILOLD.EOMCAODFBCN_ValkyrieFail };
			}
			else if(step == 1)
			{
				array = new KLJCBKMHKNK.HHMPIIILOLD[1];
			}
			if(array != null)
			{
				for(int i = 0; i < array.Length; i++)
				{
					onModeAttrAssignCallback(a_temp_note_list[step][idx], array[i], a_type);
				}
			}
			a_temp_note_list[step].RemoveAt(idx);
		}

		// // RVA: 0xC09D54 Offset: 0xC09D54 VA: 0xC09D54
		public void Assign(List<RNote> rNoteList)
		{
			if (Database.Instance.gameSetup.musicInfo.isStoryMode)
				return;
			KEODKEGFDLD_FreeMusicInfo musicinfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(Database.Instance.gameSetup.musicInfo.freeMusicId);
			short[] specialNoteByDifficulty = Database.Instance.gameSetup.musicInfo.IsLine6Mode ? musicinfo.DPJDHKIIJIJ_SpNotesByDiff6Line : musicinfo.OCOGIADDNDN_SpNoteByDiff;
			if (specialNoteByDifficulty[(int)Database.Instance.gameSetup.musicInfo.difficultyType] < 1)
				return;
			List<int>[] validNotesIdxByModeType = new List<int>[4];
			for(int i = 0; i < validNotesIdxByModeType.Length; i++)
			{
				validNotesIdxByModeType[i] = new List<int>(modeNotesIndices[i]);
				for(int j = validNotesIdxByModeType[i].Count - 1; j >= 0; j--)
				{
					if(rNoteList[validNotesIdxByModeType[i][j]].noteInfo.longTouch == MusicScoreData.TouchState.Continue)
					{
						validNotesIdxByModeType[i].RemoveAt(j);
					}
				}
			}
			if(m_assign_info.m_event_item)
			{
				AssginFromList(rNoteList, ref validNotesIdxByModeType, RhythmGameConsts.SpecialNoteType.EventItem);
			}
			if(m_assign_info.m_center_live_skill)
			{
				AssginFromList(rNoteList, ref validNotesIdxByModeType, RhythmGameConsts.SpecialNoteType.CenterLiveSkill);
			}
			rareItemRandSeed = Random.Range(0, 100000);
			int numItems = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.NBIAKELCBLC_GetNumItems(Database.Instance.gameSetup.teamInfo.teamLuck, rareItemRandSeed);
			if (Database.Instance.gameSetup.musicInfo.gameEventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0 || Database.Instance.gameSetup.musicInfo.openEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
			{
				numItems = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.NBIAKELCBLC((int)Database.Instance.gameSetup.musicInfo.gameEventType, (int)Database.Instance.gameSetup.musicInfo.openEventType, (int)Database.Instance.gameSetup.musicInfo.difficultyType, Database.Instance.gameSetup.musicInfo.IsLine6Mode, Database.Instance.gameSetup.teamInfo.teamLuck, rareItemRandSeed);
			}
			List<DNAEGJGAKEI_DropItemInfo> itemsToSpawn = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HGLIIPFLMFB_Drop.JMHHEPMILHA_GetItemsToSpawn(musicinfo, (int)Database.Instance.gameSetup.musicInfo.difficultyType, (int)Database.Instance.gameSetup.musicInfo.gameEventType, (int)Database.Instance.gameSetup.musicInfo.openEventType, numItems, this.OnRareItemRandomLot, Database.Instance.gameSetup.musicInfo.IsLine6Mode);
			if (itemsToSpawn == null || itemsToSpawn.Count < 1)
			{
				numItems = 0;
			}
			int numToSpawn = 0;
			if(!Database.Instance.gameSetup.musicInfo.isTutorialOne)
			{
				numToSpawn = numItems;
				if (Database.Instance.gameSetup.musicInfo.isTutorialTwo)
					numToSpawn = 0;
			}

			/*int c = (b * 0x55555556) >> 0x20;
			c = c - (c >> 0x1f);
			b = b + c * -3;
			int[] numItemsByMode = new int[4];
			numItemsByMode[1] = c + (b > 0 ? 1 : 0); // normal
			int d = c;
			if (b > 1)
				d++;
			numItemsByMode[2] = d; // valk
			numItemsByMode[3] = c; // diva*/
			int part = numToSpawn / 3;
			int rest = numToSpawn - 3 * part;
			int[] numItemsByMode = new int[4];
			numItemsByMode[1] = part + (rest > 0 ? 1 : 0);
			numItemsByMode[2] = part + (rest > 1 ? 1 : 0);
			numItemsByMode[3] = part;
			TodoLogger.Log(TodoLogger.Game, "Items to spawn : "+numToSpawn+" "+numItemsByMode[1]+ " "+numItemsByMode[2]+" "+numItemsByMode[3]);

			EGLJKICMCPG[] ar = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.BBFNPHGDCOF(specialNoteByDifficulty[(int)Database.Instance.gameSetup.musicInfo.difficultyType]).CDENCMNHNGA.ToArray();
			int[] li2 = new int[6];
			MusicData.NoteModeType[] nt = new MusicData.NoteModeType[6] { MusicData.NoteModeType.Normal, MusicData.NoteModeType.Valkyrie, MusicData.NoteModeType.Diva, MusicData.NoteModeType.Diva, MusicData.NoteModeType.Valkyrie, MusicData.NoteModeType.Diva };
			for (int i = 0; i < 6; i++)
			{
				int t = numItemsByMode[(int)nt[i]];
				numItemsByMode[(int)nt[i]] = Mathf.Min(numItemsByMode[(int)nt[i]], validNotesIdxByModeType[(int)nt[i]].Count);

				int v = Mathf.Clamp((int)(ar[i].PHGLKBPLFDH_RMax / 100.0f * validNotesIdxByModeType[(int)nt[i]].Count), ar[i].MPPANPOOIIB_NMin, ar[i].GKPPCFMBANO_NMax);
				t = (numItemsByMode[(int)nt[i]] - validNotesIdxByModeType[(int)nt[i]].Count) + v;
				if (t > 0)
					v = v - t;
				li2[i] = v;
			}

			RhythmGameConsts.SpecialNoteType[] specialNoteType = new RhythmGameConsts.SpecialNoteType[6] { RhythmGameConsts.SpecialNoteType.None, RhythmGameConsts.SpecialNoteType.Heal, RhythmGameConsts.SpecialNoteType.Score, RhythmGameConsts.SpecialNoteType.NormalItem, RhythmGameConsts.SpecialNoteType.Fold, RhythmGameConsts.SpecialNoteType.Attack };
			List<AssignedRareItemNoteInfo>[] assignedRareItemsByMode = new List<AssignedRareItemNoteInfo>[4];
			for(int i = 0; i < assignedRareItemsByMode.Length; i++)
			{
				assignedRareItemsByMode[i] = new List<AssignedRareItemNoteInfo>(numItemsByMode[i]);
			}

			int[,] li3 = new int[6, 6];
			int sum = 0;
			for(int i = 0; i < 6; i++)
			{
				List<int> l3 = new List<int>(validNotesIdxByModeType[(int)nt[i]]);
				for(int j = 0; j < 5; j++)
				{
					if(ar[i].JNNKKPNGPAA((SpecialNoteAttribute.Type)(j + 1)) > -1)
					{
						sum += ar[i].JNNKKPNGPAA((SpecialNoteAttribute.Type)(j + 1)) + Database.Instance.gameSetup.teamInfo.teamStatus.spNoteExpected[j + 1] / 10;
					}
				}
				for (int j = 0; j < 5; j++)
				{
					int m = 0;
					if (ar[i].JNNKKPNGPAA((SpecialNoteAttribute.Type)(j + 1)) < 0)
					{
						//nothing
					}
					else
					{
						if(sum < 100 || (j + 1) == ar[i].DAPGDCPDCNA_Pri)
						{
							//LAB_00c0b118
							m = Mathf.RoundToInt((Database.Instance.gameSetup.teamInfo.teamStatus.spNoteExpected[j + 1] / 10.0f + ar[i].JNNKKPNGPAA((SpecialNoteAttribute.Type)(j + 1))) / 100.0f * li2[i]);
						}
						else
						{
							int n = (Database.Instance.gameSetup.teamInfo.teamStatus.spNoteExpected[ar[i].DAPGDCPDCNA_Pri] / 10 + ar[i].JNNKKPNGPAA((SpecialNoteAttribute.Type)ar[i].DAPGDCPDCNA_Pri));
							m = (int)((Database.Instance.gameSetup.teamInfo.teamStatus.spNoteExpected[j + 1] / 10 + ar[i].JNNKKPNGPAA((SpecialNoteAttribute.Type)ar[i].DAPGDCPDCNA_Pri)) * 1.0f / (sum - n) * (li2[i] - Mathf.RoundToInt(n / 100.0f * li2[i])));
						}
					}
					li3[j + 1, i] = m;
				}
				if (assignedRareItemsByMode[(int)nt[i]].Count < 1)
				{
					for (int j = 0; j < numItemsByMode[(int)nt[i]]; j++)
					{
						int v = Random.Range(0, l3.Count);
						onModeAttrAssignCallback(l3[v], (KLJCBKMHKNK.HHMPIIILOLD)i, RhythmGameConsts.SpecialNoteType.RareItem);
						onModeItemInfoAssignCallback(l3[v], (KLJCBKMHKNK.HHMPIIILOLD)i, itemsToSpawn[j].KIJAPOFAGPN_ItemId, itemsToSpawn[j].OIPCCBHIKIA_ItemIdx);
						l3.RemoveAt(v);
					}
				}
				else
				{
					for (int j = 0; j < assignedRareItemsByMode[(int)nt[i]].Count; j++)
					{
						onModeAttrAssignCallback(l3[assignedRareItemsByMode[(int)nt[i]][j].noteListIndex], (KLJCBKMHKNK.HHMPIIILOLD)i, RhythmGameConsts.SpecialNoteType.RareItem);
						onModeItemInfoAssignCallback(l3[assignedRareItemsByMode[(int)nt[i]][j].noteListIndex], (KLJCBKMHKNK.HHMPIIILOLD)i, itemsToSpawn[j].KIJAPOFAGPN_ItemId, itemsToSpawn[j].OIPCCBHIKIA_ItemIdx);
						l3.RemoveAt(assignedRareItemsByMode[(int)nt[i]][j].noteListIndex);
					}
				}
				int s = 1;
				for(; s <= 5; s++)
				{
					if(s == 3 && itemWeightTable == null)
					{
						s = 4;
						continue;
					}
					for(int j = 0; j < li3[s ,i]; j++)
					{
						int t = Random.Range(0, l3.Count);
						onModeAttrAssignCallback(l3[t], (KLJCBKMHKNK.HHMPIIILOLD)i, specialNoteType[s]);
						if (s == 3)
							AllotItemNotes(l3[t], (KLJCBKMHKNK.HHMPIIILOLD)i);
						l3.RemoveAt(t);
					}
				}
			}
			if(notesCount > 1)
			{
				for(int i = 1; i < notesCount; i++)
				{
					onModeAttrAssignCallback(i, KLJCBKMHKNK.HHMPIIILOLD.JKAPLHFHGKL/*6*/, RhythmGameConsts.SpecialNoteType.NormalItem);
					AllotItemNotes(i, /*6*/KLJCBKMHKNK.HHMPIIILOLD.JKAPLHFHGKL);
				}
			}
		}

		// // RVA: 0xC0BFB8 Offset: 0xC0BFB8 VA: 0xC0BFB8
		private int OnRareItemRandomLot()
		{
			return Random.Range(0, 152);
		}

		// // RVA: 0xC0BFCC Offset: 0xC0BFCC VA: 0xC0BFCC
		public int GetRareItemRandomSeed()
		{
			return rareItemRandSeed;
		}

		// // RVA: 0xC0BD90 Offset: 0xC0BD90 VA: 0xC0BD90
		private void AllotItemNotes(int noteIndex, KLJCBKMHKNK.HHMPIIILOLD mode)
		{
			if(itemWeightTable != null)
			{
				int a = LotsItem(itemWeightTable);
				onModeItemInfoAssignCallback(noteIndex, mode, itemSet.FKNBLDPIPMC_GetItemId(a), a | 0x40000000);
				if(rateSet.DOOGFEGEKLG_Max[a] != 0)
				{
					itemLotCountList[a]++;
					if(rateSet.DOOGFEGEKLG_Max[a] <= itemLotCountList[a])
					{
						itemWeightTable[a] = 0;
					}
				}
			}
		}

		// // RVA: 0xC0BFD4 Offset: 0xC0BFD4 VA: 0xC0BFD4
		private int LotsItem(List<int> weightTable)
		{
			if(weightTable != null)
			{
				int num = weightTable.Count;
				if (num < 1)
					num = 1;
				else
				{
					int sum = 0;
					for(int i = 0; i <weightTable.Count; i++)
					{
						sum += weightTable[i];
					}
					num = sum + 1;
				}
				int v = Random.Range(1, num);
				for(int i = 0; i < weightTable.Count; i++)
				{
					if (v <= weightTable[i])
						return i;
					v -= weightTable[i];
				}
			}
			return -1;
		}

		// // RVA: 0xC0C154 Offset: 0xC0C154 VA: 0xC0C154
		// private float GetItemDropRate() { }

		// // RVA: 0xC09714 Offset: 0xC09714 VA: 0xC09714
		private OPGDJANLKBM_RateInfo GetDropRateSet()
		{
			int v = 0;
			if (Database.Instance.gameSetup.musicInfo.isFreeMode)
			{
				v = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(Database.Instance.gameSetup.musicInfo.freeMusicId).KDIKCKEEPDA_GetNormalRateId(Database.Instance.gameSetup.musicInfo.IsLine6Mode);
				if (JEPBIIJDGEF_EventInfo.HHCJCDFCLOB != null)
				{
                    IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI_6, false);
                    if (ev != null)
					{
						v = ev.NCHKBINKKBH_UpdateDropRateSet(v, Database.Instance.gameSetup.musicInfo.gameEventType);
					} 
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
				v = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(Database.Instance.gameSetup.musicInfo.freeMusicId).MGLDIOILOFF_NormalSetId;
				if (JEPBIIJDGEF_EventInfo.HHCJCDFCLOB != null)
				{
                    IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI_6, false);
                    if (ev != null)
					{
						v = ev.JDFHIHPPAHN_UpdateDropItemSet(v, Database.Instance.gameSetup.musicInfo.gameEventType);
					}
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
