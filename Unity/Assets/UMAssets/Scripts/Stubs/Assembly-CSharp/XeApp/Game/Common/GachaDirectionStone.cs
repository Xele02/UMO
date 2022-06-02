using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class GachaDirectionStone : MonoBehaviour
	{
		[Serializable]
		public class TypeChangeData
		{
			[SerializeField]
			private Cubemap quartz_Cube_map;
			[SerializeField]
			private Texture memory_DiffuseTex;
			[SerializeField]
			private List<ParticleSystem> particles;
		}

		[Serializable]
		public class RefData
		{
			public RefData(Transform memory, Transform quartz, List<Transform> quartzBreak)
			{
			}

			[SerializeField]
			private Transform m_memory;
			[SerializeField]
			private Transform m_quartz;
			[SerializeField]
			private List<Transform> m_quartzBreak;
		}

		[SerializeField]
		private TypeChangeData m_changeToBlue;
		[SerializeField]
		private TypeChangeData m_changeToRed;
		[SerializeField]
		private TypeChangeData m_changeToGold;
		[SerializeField]
		private List<GameObject> m_quartzRename;
		[SerializeField]
		private List<GameObject> m_memoryRename;
		[SerializeField]
		private RefData m_meshRefData;
	}
}
