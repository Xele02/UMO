using System;
using UnityEngine;

namespace XeApp.Game.MiniGame
{
	[Serializable]
	public class ShootingCollision : ShootingTaskMethod
	{
		public enum ObjType
		{
			Player = 0,
			Enemy = 1,
			EnemyBullet = 2,
			PlayerBullet = 3,
			EnemyBoss = 4,
			Kyururu = 5,
		}

		public ObjType m_objType; // 0x8
		public float m_radius; // 0xC
		public bool m_isPlayerCol; // 0x10
		public Vector3 m_pos; // 0x14
		public GameObject m_collisionObj; // 0x20
		public Action<ShootingCollision> HitCallBack; // 0x24

		public ShootingTask Owner { get; set; } // 0x28

		//// RVA: 0x1CF4868 Offset: 0x1CF4868 VA: 0x1CF4868
		//private bool CheckPlauerCollisionType() { }

		// RVA: 0x1CF351C Offset: 0x1CF351C VA: 0x1CF351C Slot: 4
		public void OnAwake()
		{
			m_isPlayerCol = m_objType == ObjType.PlayerBullet || m_objType == ObjType.Player;
		}

		//// RVA: 0x1CF3550 Offset: 0x1CF3550 VA: 0x1CF3550 Slot: 5
		public void OnStart()
		{
			return;
		}

		//// RVA: 0x1CF4884 Offset: 0x1CF4884 VA: 0x1CF4884 Slot: 6
		//public void Initialize() { }

		//// RVA: 0x1CF4888 Offset: 0x1CF4888 VA: 0x1CF4888 Slot: 7
		//public void Pause() { }

		//// RVA: 0x1CF488C Offset: 0x1CF488C VA: 0x1CF488C Slot: 8
		//public void UnPause() { }

		// RVA: g Offset: 0x1CF36BC VA: 0x1CF36BC Slot: 9
		public void OnUpdate(float elapsedTime)
		{
			m_pos = m_collisionObj.transform.position;
		}

		// RVA: 0x1CF3768 Offset: 0x1CF3768 VA: 0x1CF3768 Slot: 10
		public void OnLateUpdate(float elapsedTime)
		{
			return;
		}
	}
}
