using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class UvChangeAnimeEventBase : MonoBehaviour
	{
		[SerializeField]
		private MeshFilter meshFilter; // 0xC
		private Vector2[] m_baseUv; // 0x10
		private Vector2[] m_writeUv; // 0x14

		// RVA: 0x15697BC Offset: 0x15697BC VA: 0x15697BC
		private void Awake()
		{
			m_baseUv = new Vector2[meshFilter.mesh.uv.Length];
			m_writeUv = new Vector2[m_baseUv.Length];
			System.Array.Copy(meshFilter.mesh.uv, m_baseUv, m_baseUv.Length);
		}

		// RVA: 0x155814C Offset: 0x155814C VA: 0x155814C
		protected void UpdateUv(Vector2 uvOffset)
		{
			for(int i = 0; i < m_baseUv.Length; i++)
			{
				m_writeUv[i] = m_baseUv[i] + uvOffset;
			}
			meshFilter.mesh.uv = m_writeUv;
		}
	}
}
