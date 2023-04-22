using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class EffectiveBuffList : LinkedList<BuffEffect>
	{
		//// RVA: 0xF6B1B0 Offset: 0xF6B1B0 VA: 0xF6B1B0
		public int GetEffectValue(SkillBuffEffect.Type type, int line = -1, RhythmGameConsts.NoteResult a_result = RhythmGameConsts.NoteResult.None)
		{
			int res = 0;
			LinkedListNode<BuffEffect> eff = First;
			while (eff != null)
			{
				if(eff.Value.effectType == type)
				{
					int a = line >> 0x1f;
					if ((eff.Value.lineTarget & (1 << line & 0x1f)) > 0)
					{
						a = 1;
					}
					if (a != 0 && eff.Value.IsValue(a_result))
					{
						res += eff.Value.effectValue;
					}
				}
				eff = eff.Next;
			}
			return res;
		}

		//// RVA: 0xF73BE4 Offset: 0xF73BE4 VA: 0xF73BE4
		public bool IsConatinEffectType(SkillBuffEffect.Type type, int line = -1)
		{
			LinkedListNode<BuffEffect> eff = First;
			while (eff != null)
			{
				if(eff.Value.effectType == type)
				{
					int a = line >> 0x1f;
					if((eff.Value.lineTarget & (1 << line & 0x1f)) > 0)
					{
						a = 1;
					}
					if (a != 0)
						return true;
				}
				eff = eff.Next;
			}
			return false;
		}
	}
}
