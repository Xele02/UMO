using UnityEngine;

namespace XeApp.Game.Common
{
	public class ValkyrieObject : MonoBehaviour
	{
		protected static readonly int BaseLayer; // 0x0
		protected static readonly int ShootLayer; // 0x4
		// private ValkyrieShaderController m_valkyrie_shader_ctrl; // 0xC
		// private ValkyrieObject.ShaderNameId m_shader_nameid; // 0x10
		// private List<ValkyrieObject.VernierMaterialInfo> m_list_material_vernier; // 0x14
		private GameObject m_valkyrie; // 0x18
		// [CompilerGeneratedAttribute] // RVA: 0x68800C Offset: 0x68800C VA: 0x68800C
		// private AnimatorOverrideController <overrideController>k__BackingField; // 0x1C
		// [CompilerGeneratedAttribute] // RVA: 0x68801C Offset: 0x68801C VA: 0x68801C
		// private Animator <animator>k__BackingField; // 0x20
		// [CompilerGeneratedAttribute] // RVA: 0x68802C Offset: 0x68802C VA: 0x68802C
		// private GameObject <fighter>k__BackingField; // 0x24
		// [CompilerGeneratedAttribute] // RVA: 0x68803C Offset: 0x68803C VA: 0x68803C
		// private GameObject <gerwalk>k__BackingField; // 0x28
		// [CompilerGeneratedAttribute] // RVA: 0x68804C Offset: 0x68804C VA: 0x68804C
		// private GameObject <battroid>k__BackingField; // 0x2C
		private int m_activateCount; // 0x30
		// [CompilerGeneratedAttribute] // RVA: 0x68805C Offset: 0x68805C VA: 0x68805C
		// private EffectFactoryCollector <effectFactories>k__BackingField; // 0x34
		// [CompilerGeneratedAttribute] // RVA: 0x68806C Offset: 0x68806C VA: 0x68806C
		// private ValkyrieSoundOrderer <soundOrderer>k__BackingField; // 0x38
		// [CompilerGeneratedAttribute] // RVA: 0x68807C Offset: 0x68807C VA: 0x68807C
		// private ValkyrieEventListener <eventListener>k__BackingField; // 0x3C

		// Properties
		protected AnimatorOverrideController overrideController { get; set; }
		public GameObject instance { get; }
		public Animator animator { get; set; }
		public GameObject fighter { get; set; }
		public GameObject gerwalk { get; set; }
		public GameObject battroid { get; set; }
		// protected EffectFactoryCollector effectFactories { get; set; }
		// protected ValkyrieSoundOrderer soundOrderer { get; set; }
		// protected ValkyrieEventListener eventListener { get; set; }
		protected virtual bool usingEffectFactory { get; }
		protected virtual bool usingQualitySetting { get; }

		// Methods

		// [CompilerGeneratedAttribute] // RVA: 0x73C2A8 Offset: 0x73C2A8 VA: 0x73C2A8
		// // RVA: 0xD27E8C Offset: 0xD27E8C VA: 0xD27E8C
		// protected AnimatorOverrideController get_overrideController() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C2B8 Offset: 0x73C2B8 VA: 0x73C2B8
		// // RVA: 0xD27E94 Offset: 0xD27E94 VA: 0xD27E94
		// private void set_overrideController(AnimatorOverrideController value) { }

		// // RVA: 0xD27E9C Offset: 0xD27E9C VA: 0xD27E9C
		// public GameObject get_instance() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C2C8 Offset: 0x73C2C8 VA: 0x73C2C8
		// // RVA: 0xD26F20 Offset: 0xD26F20 VA: 0xD26F20
		// public Animator get_animator() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C2D8 Offset: 0x73C2D8 VA: 0x73C2D8
		// // RVA: 0xD27EA4 Offset: 0xD27EA4 VA: 0xD27EA4
		// private void set_animator(Animator value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C2E8 Offset: 0x73C2E8 VA: 0x73C2E8
		// // RVA: 0xD27EAC Offset: 0xD27EAC VA: 0xD27EAC
		// public GameObject get_fighter() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C2F8 Offset: 0x73C2F8 VA: 0x73C2F8
		// // RVA: 0xD27EB4 Offset: 0xD27EB4 VA: 0xD27EB4
		// private void set_fighter(GameObject value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C308 Offset: 0x73C308 VA: 0x73C308
		// // RVA: 0xD27EBC Offset: 0xD27EBC VA: 0xD27EBC
		// public GameObject get_gerwalk() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C318 Offset: 0x73C318 VA: 0x73C318
		// // RVA: 0xD27EC4 Offset: 0xD27EC4 VA: 0xD27EC4
		// private void set_gerwalk(GameObject value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C328 Offset: 0x73C328 VA: 0x73C328
		// // RVA: 0xD27ECC Offset: 0xD27ECC VA: 0xD27ECC
		// public GameObject get_battroid() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C338 Offset: 0x73C338 VA: 0x73C338
		// // RVA: 0xD27ED4 Offset: 0xD27ED4 VA: 0xD27ED4
		// private void set_battroid(GameObject value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C348 Offset: 0x73C348 VA: 0x73C348
		// // RVA: 0xD27EDC Offset: 0xD27EDC VA: 0xD27EDC
		// protected EffectFactoryCollector get_effectFactories() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C358 Offset: 0x73C358 VA: 0x73C358
		// // RVA: 0xD27EE4 Offset: 0xD27EE4 VA: 0xD27EE4
		// private void set_effectFactories(EffectFactoryCollector value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C368 Offset: 0x73C368 VA: 0x73C368
		// // RVA: 0xD27EEC Offset: 0xD27EEC VA: 0xD27EEC
		// protected ValkyrieSoundOrderer get_soundOrderer() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C378 Offset: 0x73C378 VA: 0x73C378
		// // RVA: 0xD27EF4 Offset: 0xD27EF4 VA: 0xD27EF4
		// private void set_soundOrderer(ValkyrieSoundOrderer value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C388 Offset: 0x73C388 VA: 0x73C388
		// // RVA: 0xD27EFC Offset: 0xD27EFC VA: 0xD27EFC
		// protected ValkyrieEventListener get_eventListener() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C398 Offset: 0x73C398 VA: 0x73C398
		// // RVA: 0xD27F04 Offset: 0xD27F04 VA: 0xD27F04
		// private void set_eventListener(ValkyrieEventListener value) { }

		// // RVA: 0xD27F0C Offset: 0xD27F0C VA: 0xD27F0C Slot: 4
		// protected virtual bool get_usingEffectFactory() { }

		// // RVA: 0xD27F14 Offset: 0xD27F14 VA: 0xD27F14 Slot: 5
		// protected virtual bool get_usingQualitySetting() { }

		// // RVA: 0xD27F1C Offset: 0xD27F1C VA: 0xD27F1C
		// public void SetChangeExplosionEffect(bool a_enable) { }

		// // RVA: 0xD280E8 Offset: 0xD280E8 VA: 0xD280E8
		// public void SetEnableAwakeEffect(bool a_enable) { }

		// // RVA: 0xD28300 Offset: 0xD28300 VA: 0xD28300
		// private void Awake() { }

		// // RVA: 0xD28304 Offset: 0xD28304 VA: 0xD28304
		// public void Initialize(ValkyrieResource resource) { }

		// // RVA: 0xD29140 Offset: 0xD29140 VA: 0xD29140 Slot: 6
		// protected virtual void InstantiateEffect() { }

		// // RVA: 0xD2843C Offset: 0xD2843C VA: 0xD2843C
		// private void InstantiateValkyrie(ValkyrieResource resource) { }

		// // RVA: 0xD29C38 Offset: 0xD29C38 VA: 0xD29C38 Slot: 7
		// protected virtual void OnInitialize(ValkyrieResource resource) { }

		// // RVA: 0xD29C3C Offset: 0xD29C3C VA: 0xD29C3C
		// public void Release() { }

		// // RVA: 0xD29D7C Offset: 0xD29D7C VA: 0xD29D7C Slot: 8
		// protected virtual void OnRelease() { }

		// // RVA: 0xD29CC4 Offset: 0xD29CC4 VA: 0xD29CC4
		// private void DestroyValkyrie() { }

		// // RVA: 0xD29D80 Offset: 0xD29D80 VA: 0xD29D80
		// public void Activate(bool toActive) { }

		// // RVA: 0xD29E54 Offset: 0xD29E54 VA: 0xD29E54
		// public void Pause() { }

		// // RVA: 0xD2A158 Offset: 0xD2A158 VA: 0xD2A158
		// public void Resume() { }

		// [IteratorStateMachineAttribute] // RVA: 0x73C3A8 Offset: 0x73C3A8 VA: 0x73C3A8
		// // RVA: 0xD2A25C Offset: 0xD2A25C VA: 0xD2A25C
		// protected IEnumerator Co_WaitAnimationEnd(int stateHash, Action onEnd) { }

		// // RVA: 0xD2A33C Offset: 0xD2A33C VA: 0xD2A33C
		// public bool OnAwakeEffectEmitStart(string name) { }

		// // RVA: 0xD2A898 Offset: 0xD2A898 VA: 0xD2A898
		// public bool OnAwakeEffectEmitStop(string name) { }

		// // RVA: 0xD2A8A0 Offset: 0xD2A8A0 VA: 0xD2A8A0
		// public bool OnAwakeEffectEmitDisable(string name) { }

		// // RVA: 0xD2A8D0 Offset: 0xD2A8D0 VA: 0xD2A8D0
		public void SetIBLColor(ValkyrieColorParam a_color_param)
		{
			UnityEngine.Debug.Log("TODO");
		}

		// // RVA: 0xD28DA4 Offset: 0xD28DA4 VA: 0xD28DA4
		// private void ShaderInitialize() { }

		// // RVA: 0xD29F58 Offset: 0xD29F58 VA: 0xD29F58
		// private void ShaderPause(bool a_pause) { }

		// // RVA: 0xD2B524 Offset: 0xD2B524 VA: 0xD2B524
		// public void .ctor() { }

		// // RVA: 0xD2B65C Offset: 0xD2B65C VA: 0xD2B65C
		// private static void .cctor() { }
	}
}
