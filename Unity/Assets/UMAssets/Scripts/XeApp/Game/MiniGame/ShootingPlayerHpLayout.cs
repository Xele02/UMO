using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.MiniGame
{
	public class ShootingPlayerHpLayout : MonoBehaviour
	{
		private Image[] m_hp; // 0xC

		// RVA: 0xC8FBC8 Offset: 0xC8FBC8 VA: 0xC8FBC8
		private void Awake()
		{
			m_hp = GetComponentsInChildren<Image>(true);
		}

		//// RVA: 0xC8F894 Offset: 0xC8F894 VA: 0xC8F894
		public void ResetParam(int hpMax)
		{
			for(int i = 0; i < m_hp.Length; i++)
			{
				m_hp[i].gameObject.SetActive(false);
			}
			if (hpMax < 1)
				return;
			for (int i = 0; i < hpMax; i++)
			{
				m_hp[i].gameObject.SetActive(true);
			}
		}

		// RVA: 0xC8DCD4 Offset: 0xC8DCD4 VA: 0xC8DCD4
		public void Damege(int lifeNum)
		{
			if (lifeNum < 1)
				return;
			m_hp[lifeNum - 1].gameObject.SetActive(false);
		}
	}
}
