using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class GameObjectFollowingPosition : MonoBehaviour
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x687638 Offset: 0x687638 VA: 0x687638
		private List<Transform> m_target_trans = new List<Transform>(); // 0xC
		//[HeaderAttribute] // RVA: 0x687680 Offset: 0x687680 VA: 0x687680
		[SerializeField]
		private bool m_freeze_x; // 0x10
		[SerializeField]
		private bool m_freeze_y; // 0x11
		[SerializeField]
		private bool m_freeze_z; // 0x12

		// RVA: 0xE9BC08 Offset: 0xE9BC08 VA: 0xE9BC08
		public void LateUpdate()
		{
			if(m_target_trans.Count > 0)
			{
				Vector3 sum = Vector3.zero;
				for(int i = 0; i < m_target_trans.Count; i++)
				{
					sum += m_target_trans[i].position;
				}
				sum /= m_target_trans.Count;
				Vector3 pos = transform.position;
				if(!m_freeze_x)
					pos.x = sum.x;
				if(!m_freeze_y)
					pos.y = sum.y;
				if(!m_freeze_z)
					pos.z = sum.z;
				transform.position = pos;
			}
		}
	}
}
