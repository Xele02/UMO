using System;
using UnityEngine;

namespace XeApp.Game.MiniGame
{
	[Serializable]
	public class ShootingCollision
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

		public ObjType m_objType;
		public float m_radius;
		public GameObject m_collisionObj;
	}
}
