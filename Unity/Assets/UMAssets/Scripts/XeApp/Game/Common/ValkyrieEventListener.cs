using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace XeApp.Game.Common
{
	public class ValkyrieEventListener : MonoBehaviour
	{
		public delegate bool delegateAwakeEffectStart(string a_effect);
		public delegate bool delegateAwakeEffectStop(string a_effect);
		public delegate bool delegateAwakeEffectDisable(string a_effect);

		[SerializeField]
		private GameObject m_fighter; // 0xC
		[FormerlySerializedAsAttribute("m_garwalk")] // RVA: 0x687EAC Offset: 0x687EAC VA: 0x687EAC
		[SerializeField]
		private GameObject m_gerwalk; // 0x10
		[SerializeField]
		private GameObject m_battroid; // 0x14
		private EffectFactoryCollector m_effectFactories; // 0x18
		private List<ValkyrieFormSwitchListener> m_formSwitchListeners = new List<ValkyrieFormSwitchListener>(); // 0x1C
		public Dictionary<string, string> m_list_change_effect = new Dictionary<string, string>(); // 0x20

		public Action onShootStartEvent { private get; set; } // 0x24
		public Action onShootStopEvent { private get; set; } // 0x28
		public Action onShootSingleEvent { private get; set; } // 0x2C
		public delegateAwakeEffectStart onAwakeEffectStart { private get; set; } // 0x30
		public delegateAwakeEffectStop onAwakeEffectStop { private get; set; } // 0x34
		public delegateAwakeEffectDisable onAwakeEffectDisable { private get; set; } // 0x38

		// RVA: 0x1CE0094 Offset: 0x1CE0094 VA: 0x1CE0094
		private void Awake()
		{
			m_effectFactories = GetComponent<EffectFactoryCollector>();
		}

		//// RVA: 0x1CE00FC Offset: 0x1CE00FC VA: 0x1CE00FC
		public void Initialize()
		{
			m_formSwitchListeners.Clear();
			m_formSwitchListeners.AddRange(GetComponentsInChildren<ValkyrieFormSwitchListener>(true));
		}

		//// RVA: 0x1CE01C4 Offset: 0x1CE01C4 VA: 0x1CE01C4
		//public void Release() { }

		//// RVA: 0x1CE023C Offset: 0x1CE023C VA: 0x1CE023C
		//public void PauseAll() { }

		//// RVA: 0x1CE0268 Offset: 0x1CE0268 VA: 0x1CE0268
		//public void ResumeAll() { }

		//// RVA: 0x1CE0294 Offset: 0x1CE0294 VA: 0x1CE0294
		//private string ChangeEffectName(string a_name) { }

		//// RVA: 0x1CE0338 Offset: 0x1CE0338 VA: 0x1CE0338
		//public void Ev_SwitchToFighter() { }

		//// RVA: 0x1CE04B0 Offset: 0x1CE04B0 VA: 0x1CE04B0
		//public void Ev_SwitchToGerwalk() { }

		//// RVA: 0x1CE0628 Offset: 0x1CE0628 VA: 0x1CE0628
		//public void Ev_SwitchToBattroid() { }

		//// RVA: 0x1CE07A0 Offset: 0x1CE07A0 VA: 0x1CE07A0
		//public void Ev_EffectEmitStart(string name) { }

		//// RVA: 0x1CE07DC Offset: 0x1CE07DC VA: 0x1CE07DC
		//public void Ev_EffectEmitStop(string name) { }

		//// RVA: 0x1CE0818 Offset: 0x1CE0818 VA: 0x1CE0818
		//public void Ev_EffectDisable(string name) { }

		//// RVA: 0x1CE0854 Offset: 0x1CE0854 VA: 0x1CE0854
		//public void Ev_AwakeEffectEmitStart(string name) { }

		//// RVA: 0x1CE10E4 Offset: 0x1CE10E4 VA: 0x1CE10E4
		//public void Ev_AwakeEffectEmitStop(string name) { }

		//// RVA: 0x1CE195C Offset: 0x1CE195C VA: 0x1CE195C
		//public void Ev_AwakeEffectDisable(string name) { }

		//// RVA: 0x1CE21D4 Offset: 0x1CE21D4 VA: 0x1CE21D4
		//public void Ev_EffectPlayAnim(string name) { }

		//// RVA: 0x1CE22E4 Offset: 0x1CE22E4 VA: 0x1CE22E4
		//public void Ev_ShootStart() { }

		//// RVA: 0x1CE22F8 Offset: 0x1CE22F8 VA: 0x1CE22F8
		//public void Ev_ShootStop() { }

		//// RVA: 0x1CE230C Offset: 0x1CE230C VA: 0x1CE230C
		//public void Ev_ShootSingle() { }
	}
}
