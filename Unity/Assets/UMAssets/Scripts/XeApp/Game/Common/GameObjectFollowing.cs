using UnityEngine;

namespace XeApp.Game.Common
{
	public class GameObjectFollowing : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x6875E0 Offset: 0x6875E0 VA: 0x6875E0
		[SerializeField]
		private Transform targetNode; // 0xC
		private Vector3 m_target_pos; // 0x10
		private Quaternion m_target_rotateion; // 0x1C

		// RVA: 0xE9AFC0 Offset: 0xE9AFC0 VA: 0xE9AFC0
		public void Start()
		{
			LateUpdate();
		}

		// RVA: 0xE9B048 Offset: 0xE9B048 VA: 0xE9B048
		public void Update()
		{
			transform.position = m_target_pos;
			transform.rotation = m_target_rotateion;
		}

		// RVA: 0xE9AFC4 Offset: 0xE9AFC4 VA: 0xE9AFC4
		public void LateUpdate()
		{
			m_target_pos = targetNode.position;
			m_target_rotateion = targetNode.rotation;
		}
	}
}
