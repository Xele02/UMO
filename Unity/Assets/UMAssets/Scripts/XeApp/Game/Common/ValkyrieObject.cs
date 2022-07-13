using UnityEngine;

namespace XeApp.Game.Common
{
	public class ValkyrieObject : MonoBehaviour
	{
		protected static readonly int BaseLayer = 0; // 0x0
		protected static readonly int ShootLayer = 1; // 0x4
		// private ValkyrieShaderController m_valkyrie_shader_ctrl = new ValkyrieShaderController(); // 0xC
		// private ValkyrieObject.ShaderNameId m_shader_nameid; // 0x10
		// private List<ValkyrieObject.VernierMaterialInfo> m_list_material_vernier = new List<ValkyrieObject.VernierMaterialInfo>(); // 0x14
		private GameObject m_valkyrie; // 0x18
		private int m_activateCount; // 0x30

		protected AnimatorOverrideController overrideController { get; private set; } // 0x1C
		// public GameObject instance { get; } 0xD27E9C
		public Animator animator { get; private set; } // 0x20
		public GameObject fighter { get; private set; } // 0x24
		public GameObject gerwalk { get; private set; } // 0x28
		public GameObject battroid { get; private set; } // 0x2C
		// protected EffectFactoryCollector effectFactories { get; private set; } // 0x34
		// protected ValkyrieSoundOrderer soundOrderer { get; private set; } // 0x38
		// protected ValkyrieEventListener eventListener { get; private set; } // 0x3C
		// protected virtual bool usingEffectFactory { get; } 0xD27F0C Slot: 4
		// protected virtual bool usingQualitySetting { get; } 0xD27F14  Slot: 5

		// // RVA: 0xD27F1C Offset: 0xD27F1C VA: 0xD27F1C
		// public void SetChangeExplosionEffect(bool a_enable) { }

		// // RVA: 0xD280E8 Offset: 0xD280E8 VA: 0xD280E8
		// public void SetEnableAwakeEffect(bool a_enable) { }

		// // RVA: 0xD28300 Offset: 0xD28300 VA: 0xD28300
		private void Awake()
		{
			return;
		}

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
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xD28DA4 Offset: 0xD28DA4 VA: 0xD28DA4
		// private void ShaderInitialize() { }

		// // RVA: 0xD29F58 Offset: 0xD29F58 VA: 0xD29F58
		// private void ShaderPause(bool a_pause) { }
	}
}
