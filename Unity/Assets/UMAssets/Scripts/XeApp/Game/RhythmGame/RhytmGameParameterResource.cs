using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class RhytmGameParameterResource : MonoBehaviour
	{
		public bool isRequestLoad; // 0xC
		public bool isLoaded; // 0xD
		public ParameterData_ValkyrieAwake m_paramValkyrieAwake; // 0x10
		public ParameterData_ValkyrieChangeExplosion m_paramValkyrieChangeExplosion; // 0x14
		public ParameterData_ValkyrieChangeIntro m_paramIntro; // 0x18
		public ParameterData_ValkyrieChangeBattle m_paramBattle; // 0x1C
		public ParameterData_ValkyrieChangeEnemy m_paramEnemy; // 0x20

		// Methods

		// // RVA: 0x1551C0C Offset: 0x1551C0C VA: 0x1551C0C
		// public void OnDestroy() { }

		// // RVA: 0x1551C88 Offset: 0x1551C88 VA: 0x1551C88
		public void LoadResource()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x74640C Offset: 0x74640C VA: 0x74640C
		// // RVA: 0x1551CB8 Offset: 0x1551CB8 VA: 0x1551CB8
		// private IEnumerator Co_LoadResource() { }

		// // RVA: 0x1551D64 Offset: 0x1551D64 VA: 0x1551D64
		// public void .ctor() { }
	}
}
