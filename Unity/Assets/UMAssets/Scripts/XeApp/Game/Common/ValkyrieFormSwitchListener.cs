using UnityEngine;
using UnityEngine.Serialization;

namespace XeApp.Game.Common
{
	[RequireComponent(typeof(Animator))] // RVA: 0x64EC40 Offset: 0x64EC40 VA: 0x64EC40
	public class ValkyrieFormSwitchListener : MonoBehaviour
	{
		[SerializeField]
		private Animator m_animator; // 0xC
		[SerializeField]
		private string m_fighterStateName; // 0x10
		[FormerlySerializedAsAttribute("m_garwalkStateName")] // RVA: 0x687F88 Offset: 0x687F88 VA: 0x687F88
		[SerializeField]
		private string m_gerwalkStateName; // 0x14
		[SerializeField]
		private string m_battroidStateName; // 0x18

		//// RVA: 0x1CE2548 Offset: 0x1CE2548 VA: 0x1CE2548
		//private void Reset() { }

		// RVA: 0x1CE047C Offset: 0x1CE047C VA: 0x1CE047C
		public void ToFighter()
		{
			m_animator.Play(m_fighterStateName);
		}

		// RVA: 0x1CE05F4 Offset: 0x1CE05F4 VA: 0x1CE05F4
		public void ToGerwalk()
		{
			m_animator.Play(m_gerwalkStateName);
		}

		// RVA: 0x1CE076C Offset: 0x1CE076C VA: 0x1CE076C
		public void ToBattroid()
		{
			m_animator.Play(m_battroidStateName);
		}
	}
}
