using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class DivaSortExecutor
	{
		private DFKGGBMFFGB m_playerData; // 0x8

		public SortItem SortType { get; private set; } // 0xC
		public byte SortOrder { get; private set; } // 0x10

		// RVA: 0x1266554 Offset: 0x1266554 VA: 0x1266554
		public void Initialize(DFKGGBMFFGB playerData)
		{
			m_playerData = playerData;
		}

		// RVA: 0x126655C Offset: 0x126655C VA: 0x126655C
		public void Execute(List<int> divaIndexList, SortItem sortType, byte sortOrder)
		{
			SortOrder = sortOrder;
			SortType = sortType;
			divaIndexList.Sort(SortImpl);
		}

		// // RVA: 0x126662C Offset: 0x126662C VA: 0x126662C
		private int SortImpl(int left, int right)
		{
			if(left < 0)
				return -1;
			if(right < 0)
				return 1;
			FFHPBEPOMAK_DivaInfo fl = m_playerData.NBIGLBMHEDC[left];
			FFHPBEPOMAK_DivaInfo fr = m_playerData.NBIGLBMHEDC[right];
			int val1 = 0;
			int val2 = 0;
			if(SortType <= SortItem.FoldNotes)
			{
				switch(SortType)
				{
					case SortItem.Total:
						val1 = fl.CMCKNKKCNDK_EquippedStatus.Total;
						val2 = fr.CMCKNKKCNDK_EquippedStatus.Total;
						break;
					case SortItem.Soul:
						val1 = fl.CMCKNKKCNDK_EquippedStatus.soul;
						val2 = fr.CMCKNKKCNDK_EquippedStatus.soul;
						break;
					case SortItem.Voice:
						val1 = fl.CMCKNKKCNDK_EquippedStatus.vocal;
						val2 = fr.CMCKNKKCNDK_EquippedStatus.vocal;
						break;
					case SortItem.Charm:
						val1 = fl.CMCKNKKCNDK_EquippedStatus.charm;
						val2 = fr.CMCKNKKCNDK_EquippedStatus.charm;
						break;
					case SortItem.Get:
					case SortItem.Rarity:
						break;
					case SortItem.Level:
						val1 = fl.CIEOBFIIPLD_Level;
						val2 = fr.CIEOBFIIPLD_Level;
						break;
					case SortItem.Life:
						val1 = fl.CMCKNKKCNDK_EquippedStatus.life;
						val2 = fr.CMCKNKKCNDK_EquippedStatus.life;
						break;
					case SortItem.Luck:
						val1 = DivaIconDecoration.GetEquipmentLuck(fl, m_playerData);
						val2 = DivaIconDecoration.GetEquipmentLuck(fr, m_playerData);
						break;
					case SortItem.Support:
						val1 = fl.CMCKNKKCNDK_EquippedStatus.support;
						val2 = fr.CMCKNKKCNDK_EquippedStatus.support;
						break;
					case SortItem.Fold:
						val1 = fl.CMCKNKKCNDK_EquippedStatus.fold;
						val2 = fr.CMCKNKKCNDK_EquippedStatus.fold;
						break;
					default:
						val1 = fl.CMCKNKKCNDK_EquippedStatus.spNoteExpected[(int)SortType - 10];
						val2 = fr.CMCKNKKCNDK_EquippedStatus.spNoteExpected[(int)SortType - 10];
						break;
				}
			}
			if(val1 != val2)
			{
				if(val1 < val2)
					return SortOrder == 0 ? -1 : 1;
				else
					return SortOrder == 0 ? 1 : -1;
			}
			return fl.AHHJLDLAPAN_DivaId - fr.AHHJLDLAPAN_DivaId;
		}
	}
}
