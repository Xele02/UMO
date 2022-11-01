namespace XeApp.Game.RhythmGame
{
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
		//public BuffEffectPoisonEvent poisonEvent = new BuffEffectPoisonEvent(); // 0x14
		private StMasterData m_master_data; // 0x18

		public EffectiveBuffList effectiveBuffList { get; private set; } // 0x8

		//[CompilerGeneratedAttribute] // RVA: 0x7465D4 Offset: 0x7465D4 VA: 0x7465D4
		//							 // RVA: 0xF694F0 Offset: 0xF694F0 VA: 0xF694F0
		//private void add_onActiveEvent(BuffEffectOwner.OnActiveBuffEffectEvent value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x7465E4 Offset: 0x7465E4 VA: 0x7465E4
		//							 // RVA: 0xF695FC Offset: 0xF695FC VA: 0xF695FC
		//private void remove_onActiveEvent(BuffEffectOwner.OnActiveBuffEffectEvent value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x7465F4 Offset: 0x7465F4 VA: 0x7465F4
		//							 // RVA: 0xF69708 Offset: 0xF69708 VA: 0xF69708
		//private void add_onRemoveEvent(BuffEffectOwner.OnRemoveBuffEffectEvent value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x746604 Offset: 0x746604 VA: 0x746604
		//							 // RVA: 0xF69814 Offset: 0xF69814 VA: 0xF69814
		//private void remove_onRemoveEvent(BuffEffectOwner.OnRemoveBuffEffectEvent value) { }

		//// RVA: 0xF69920 Offset: 0xF69920 VA: 0xF69920
		public BuffEffectOwner()
		{
			effectiveBuffList = new EffectiveBuffList();
		}

		//// RVA: 0xF69A80 Offset: 0xF69A80 VA: 0xF69A80
		//public void Initialize() { }

		//// RVA: 0xF69B78 Offset: 0xF69B78 VA: 0xF69B78
		//public void AddActiveEvent(BuffEffectOwner.OnActiveBuffEffectEvent activeDelegate) { }

		//// RVA: 0xF69B7C Offset: 0xF69B7C VA: 0xF69B7C
		//public void ClearActiveEvent() { }

		//// RVA: 0xF69B88 Offset: 0xF69B88 VA: 0xF69B88
		//public void AddRemoveEvent(BuffEffectOwner.OnRemoveBuffEffectEvent removeDelegate) { }

		//// RVA: 0xF69B8C Offset: 0xF69B8C VA: 0xF69B8C
		//public void ClearRemoveEvent() { }

		//// RVA: 0xF69B98 Offset: 0xF69B98 VA: 0xF69B98
		//public void AddBuff(BuffEffect buffEffect) { }

		//// RVA: 0xF6A46C Offset: 0xF6A46C VA: 0xF6A46C
		//public void ClearAll() { }

		//// RVA: 0xF6AE38 Offset: 0xF6AE38 VA: 0xF6AE38
		//public void OnUpdate(BuffDurationCheckParameter checkParameter) { }

		//// RVA: 0xF6AF30 Offset: 0xF6AF30 VA: 0xF6AF30
		//private void UpdateBuff(LinkedListNode<BuffEffect> buffNode, BuffDurationCheckParameter checkParameter) { }

		//// RVA: 0xF6AFE8 Offset: 0xF6AFE8 VA: 0xF6AFE8
		//private void CheckDuration(LinkedListNode<BuffEffect> buffNode, BuffDurationCheckParameter checkParameter) { }

		//// RVA: 0xF6B118 Offset: 0xF6B118 VA: 0xF6B118
		public float CalcComboBonus(int a_combo, int a_line_no)
		{
			TodoLogger.Log(0, "CalcComboBonus");
			return 0;
		}
	}
}
