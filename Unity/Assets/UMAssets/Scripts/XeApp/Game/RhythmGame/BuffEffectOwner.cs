using System.Collections.Generic;
using UnityEngine.Events;

namespace XeApp.Game.RhythmGame
{
	public class BuffEffectPoisonEvent : UnityEvent<BuffEffect> { }

	public struct BuffDurationCheckParameter
	{
		public float musicTime; // 0x0
		public bool isValkyrieMode; // 0x4
		public RhythmGameMode.Type modeType; // 0x8
		public int bitNoteResult; // 0xC
	}

	public class BuffEffectOwner
	{
		public delegate void OnActiveBuffEffectEvent(BuffEffect buff);
		public delegate void OnRemoveBuffEffectEvent(BuffEffect buff, int ownerDivaPlaceIndex);
		
		private struct StMasterData
		{
			public int m_skill_combo_value_0; // 0x0
		}

		private OnActiveBuffEffectEvent onActiveEvent; // 0xC
		private OnRemoveBuffEffectEvent onRemoveEvent; // 0x10
		public BuffEffectPoisonEvent poisonEvent = new BuffEffectPoisonEvent(); // 0x14
		private StMasterData m_master_data; // 0x18

		public EffectiveBuffList effectiveBuffList { get; private set; } // 0x8

		//// RVA: 0xF69920 Offset: 0xF69920 VA: 0xF69920
		public BuffEffectOwner()
		{
			effectiveBuffList = new EffectiveBuffList();
		}

		//// RVA: 0xF69A80 Offset: 0xF69A80 VA: 0xF69A80
		public void Initialize()
		{
			m_master_data.m_skill_combo_value_0 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA("skill_combo_bonus_value0", 0);
		}

		//// RVA: 0xF69B78 Offset: 0xF69B78 VA: 0xF69B78
		public void AddActiveEvent(OnActiveBuffEffectEvent activeDelegate)
		{
			onActiveEvent += activeDelegate;
		}

		//// RVA: 0xF69B7C Offset: 0xF69B7C VA: 0xF69B7C
		//public void ClearActiveEvent() { }

		//// RVA: 0xF69B88 Offset: 0xF69B88 VA: 0xF69B88
		public void AddRemoveEvent(OnRemoveBuffEffectEvent removeDelegate)
		{
			onRemoveEvent += removeDelegate;
		}

		//// RVA: 0xF69B8C Offset: 0xF69B8C VA: 0xF69B8C
		//public void ClearRemoveEvent() { }

		//// RVA: 0xF69B98 Offset: 0xF69B98 VA: 0xF69B98
		public void AddBuff(BuffEffect buffEffect)
		{
			buffEffect.OnPerSecondPoisonEffect = poisonEvent;
			effectiveBuffList.AddLast(buffEffect);
			if (onActiveEvent != null)
				onActiveEvent(buffEffect);
		}

		//// RVA: 0xF6A46C Offset: 0xF6A46C VA: 0xF6A46C
		public void ClearAll()
		{
			for(var f = effectiveBuffList.First; f != null; f = f.Next)
			{
				if (onRemoveEvent != null)
					onRemoveEvent(f.Value, f.Value.ownerDivaPlaceIndex);
			}
			effectiveBuffList.Clear();
			onActiveEvent = null;
			onRemoveEvent = null;
			poisonEvent.RemoveAllListeners();
		}

		//// RVA: 0xF6AE38 Offset: 0xF6AE38 VA: 0xF6AE38
		public void OnUpdate(BuffDurationCheckParameter checkParameter)
		{
			for (var f = effectiveBuffList.First; f != null; f = f.Next)
			{
				UpdateBuff(f, checkParameter);
				CheckDuration(f, checkParameter);
			}
		}

		//// RVA: 0xF6AF30 Offset: 0xF6AF30 VA: 0xF6AF30
		private void UpdateBuff(LinkedListNode<BuffEffect> buffNode, BuffDurationCheckParameter checkParameter)
		{
			buffNode.Value.OnUpdate(checkParameter);
		}

		//// RVA: 0xF6AFE8 Offset: 0xF6AFE8 VA: 0xF6AFE8
		private void CheckDuration(LinkedListNode<BuffEffect> buffNode, BuffDurationCheckParameter checkParameter)
		{
			if(buffNode.Value.InDuration(checkParameter))
			{
				return;
			}
			effectiveBuffList.Remove(buffNode);
			if (onRemoveEvent != null)
				onRemoveEvent(buffNode.Value, buffNode.Value.ownerDivaPlaceIndex);
		}

		//// RVA: 0xF6B118 Offset: 0xF6B118 VA: 0xF6B118
		public float CalcComboBonus(int a_combo, int a_line_no)
		{
			if (m_master_data.m_skill_combo_value_0 < 1)
				return 0;
			return (effectiveBuffList.GetEffectValue(Common.SkillBuffEffect.Type.ComboBonus, a_line_no, Common.RhythmGameConsts.NoteResult.None) / 100.0f * (a_combo / m_master_data.m_skill_combo_value_0));
		}
	}
}
