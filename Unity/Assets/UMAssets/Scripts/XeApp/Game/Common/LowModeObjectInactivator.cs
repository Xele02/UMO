using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class LowModeObjectInactivator : MonoBehaviour
	{
		public List<GameObject> inactivateTargetObjects; // 0xC
		public bool m_force_enable; // 0x10

		// RVA: 0x110BE08 Offset: 0x110BE08 VA: 0x110BE08
		private void Start()
		{
			if(!GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.DKECHCHOMEL_IsValkyrieHighQuality() || m_force_enable)
			{
				for(int i = 0; i < inactivateTargetObjects.Count; i++)
				{
					if (inactivateTargetObjects[i] != null)
						inactivateTargetObjects[i].SetActive(false);
				}
			}
		}
	}
}
