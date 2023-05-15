using UnityEngine;

namespace XeApp.Game.Menu
{
	public class ZoomSceneFrame : MonoBehaviour
	{
		[SerializeField]
		private RectTransform[] m_rareRoot; // 0xC
		[SerializeField]
		private RectTransform[] m_frameRoot; // 0x10

		// RVA: 0x1CE9A70 Offset: 0x1CE9A70 VA: 0x1CE9A70
		public void SetAttribute(int attr)
		{
			for(int i = 0; i < m_frameRoot.Length; i++)
			{
				m_frameRoot[i].gameObject.SetActive(attr - 1 == i);
			}
		}

		// RVA: 0x1CE9B30 Offset: 0x1CE9B30 VA: 0x1CE9B30
		public void SetRarity(int baseRare, bool isRankup)
		{
			if (m_rareRoot.Length < 2)
				return;
			m_rareRoot[0].gameObject.SetActive(!isRankup);
			m_rareRoot[1].gameObject.SetActive(isRankup);
		}
	}
}
