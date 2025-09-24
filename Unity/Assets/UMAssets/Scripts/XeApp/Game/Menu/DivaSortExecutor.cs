using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class DivaSortExecutor
	{
		private DFKGGBMFFGB_PlayerInfo m_playerData; // 0x8

		public SortItem SortType { get; private set; } // 0xC
		public byte SortOrder { get; private set; } // 0x10

		// RVA: 0x1266554 Offset: 0x1266554 VA: 0x1266554
		public void Initialize(DFKGGBMFFGB_PlayerInfo playerData)
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
			FFHPBEPOMAK_DivaInfo fl = m_playerData.NBIGLBMHEDC_DivaList[left];
			FFHPBEPOMAK_DivaInfo fr = m_playerData.NBIGLBMHEDC_DivaList[right];
			int val1 = 0;
			int val2 = 0;
			if(SortType <= SortItem.FoldNotes)
			{
				switch(SortType)
				{
					case SortItem.Total:
						val1 = fl.CMCKNKKCNDK_status.Total;
						val2 = fr.CMCKNKKCNDK_status.Total;
						break;
					case SortItem.Soul:
						val1 = fl.CMCKNKKCNDK_status.soul;
						val2 = fr.CMCKNKKCNDK_status.soul;
						break;
					case SortItem.Voice:
						val1 = fl.CMCKNKKCNDK_status.vocal;
						val2 = fr.CMCKNKKCNDK_status.vocal;
						break;
					case SortItem.Charm:
						val1 = fl.CMCKNKKCNDK_status.charm;
						val2 = fr.CMCKNKKCNDK_status.charm;
						break;
					case SortItem.Get:
					case SortItem.Rarity:
						break;
					case SortItem.Level:
						val1 = fl.CIEOBFIIPLD_Level;
						val2 = fr.CIEOBFIIPLD_Level;
						break;
					case SortItem.Life:
						val1 = fl.CMCKNKKCNDK_status.life;
						val2 = fr.CMCKNKKCNDK_status.life;
						break;
					case SortItem.Luck:
						val1 = DivaIconDecoration.GetEquipmentLuck(fl, m_playerData);
						val2 = DivaIconDecoration.GetEquipmentLuck(fr, m_playerData);
						break;
					case SortItem.Support:
						val1 = fl.CMCKNKKCNDK_status.support;
						val2 = fr.CMCKNKKCNDK_status.support;
						break;
					case SortItem.Fold:
						val1 = fl.CMCKNKKCNDK_status.fold;
						val2 = fr.CMCKNKKCNDK_status.fold;
						break;
					default:
						val1 = fl.CMCKNKKCNDK_status.spNoteExpected[(int)SortType - 10];
						val2 = fr.CMCKNKKCNDK_status.spNoteExpected[(int)SortType - 10];
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
