using UnityEngine.Events;
using System.Collections.Generic;

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

			// RVA: 0xC07E08 Offset: 0xC07E08 VA: 0xC07E08
			//public void .ctor() { }
		}

		private AssignInfo m_assign_info; // 0x8
		//private UnityAction<int, KLJCBKMHKNK.HHMPIIILOLD, RhythmGameConsts.SpecialNoteType> onModeAttrAssignCallback; // 0xC
		//private UnityAction<int, KLJCBKMHKNK.HHMPIIILOLD, int, int> onModeItemInfoAssignCallback; // 0x10
		private int notesCount; // 0x14
		private List<int>[] modeNotesIndices; // 0x18
		//private HNJKJCDDIMG itemSet; // 0x1C
		//private OPGDJANLKBM rateSet; // 0x20
		private List<int> itemWeightTable; // 0x24
		private int rareItemRandSeed; // 0x28
		private int[] itemLotCountList; // 0x2C

		// // Methods

		// // RVA: 0xC08F90 Offset: 0xC08F90 VA: 0xC08F90
		// public void Initialize(MusicData musicData, RhythmGameSpecialNotesAssigner.AssignInfo a_assign_info, UnityAction<int, KLJCBKMHKNK.HHMPIIILOLD, RhythmGameConsts.SpecialNoteType> onModeAttrAssignCallback, UnityAction<int, KLJCBKMHKNK.HHMPIIILOLD, int, int> onModeItemInfoAssignCallback) { }

		// // RVA: 0xC09A1C Offset: 0xC09A1C VA: 0xC09A1C
		// private void AssginFromList(List<RNote> rNoteList, ref List<int>[] a_temp_note_list, RhythmGameConsts.SpecialNoteType a_type, int a_index = -1) { }

		// // RVA: 0xC09D54 Offset: 0xC09D54 VA: 0xC09D54
		// public void Assign(List<RNote> rNoteList) { }

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
		// private OPGDJANLKBM GetDropRateSet() { }

		// // RVA: 0xC09410 Offset: 0xC09410 VA: 0xC09410
		// private HNJKJCDDIMG GetDropItemSet() { }

		// // RVA: 0xC0C21C Offset: 0xC0C21C VA: 0xC0C21C
		// public void .ctor() { }
	}
}
