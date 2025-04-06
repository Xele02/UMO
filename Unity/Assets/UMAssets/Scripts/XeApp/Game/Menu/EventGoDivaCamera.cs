using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class EventGoDivaCamera : MonoBehaviour
	{
		[Serializable]
		private struct OffsetSetting
		{
			public int targetDiva; // 0x0
			public Vector3 pos; // 0x4
		}

		[SerializeField]
		private List<OffsetSetting> m_offsetSettings; // 0xC
		private Vector3 m_originalPos; // 0x10
		private int m_divaId; // 0x1C

		// // RVA: 0x1063968 Offset: 0x1063968 VA: 0x1063968
		public void SetDiva(int divaId)
		{
			m_divaId = divaId;
			SetOffsetByDivaId(divaId);
		}

		// RVA: 0x1063B18 Offset: 0x1063B18 VA: 0x1063B18
		private void Awake()
		{
			m_originalPos = transform.position;
		}

		// // RVA: 0x1063B68 Offset: 0x1063B68 VA: 0x1063B68
		private void ApplyOffset(OffsetSetting offset)
		{
			transform.position = m_originalPos + offset.pos;
		}

		// // RVA: 0x1063C5C Offset: 0x1063C5C VA: 0x1063C5C
		private void ClearOffset()
		{
			transform.position = m_originalPos;
		}

		// // RVA: 0x1063970 Offset: 0x1063970 VA: 0x1063970
		private void SetOffsetByDivaId(int divaId)
		{
			foreach(var off in m_offsetSettings)
			{
				if(off.targetDiva == divaId)
				{
					ApplyOffset(off);
					return;
				}
			}
			ClearOffset();
		}
	}
}
