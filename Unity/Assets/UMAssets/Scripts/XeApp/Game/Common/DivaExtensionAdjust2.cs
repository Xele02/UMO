using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class DivaExtensionAdjust2 : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x686508 Offset: 0x686508 VA: 0x686508
		public float[] m_AdjustPosParam = new float[10] { DivaAdjustPosParam.DIVA_00, DivaAdjustPosParam.DIVA_01, DivaAdjustPosParam.DIVA_02, DivaAdjustPosParam.DIVA_03,
			DivaAdjustPosParam.DIVA_04, DivaAdjustPosParam.DIVA_05, DivaAdjustPosParam.DIVA_06, DivaAdjustPosParam.DIVA_07, DivaAdjustPosParam.DIVA_08, DivaAdjustPosParam.DIVA_09}; // 0xC
		public float[] m_AdjustScaleParam = new float[10] { DivaAdjustScaleParam.DIVA_00, DivaAdjustScaleParam.DIVA_01, DivaAdjustScaleParam.DIVA_02, DivaAdjustScaleParam.DIVA_03,
			DivaAdjustScaleParam.DIVA_04, DivaAdjustScaleParam.DIVA_05, DivaAdjustScaleParam.DIVA_06, DivaAdjustScaleParam.DIVA_07, DivaAdjustScaleParam.DIVA_08, DivaAdjustScaleParam.DIVA_09}; // 0x10
																																																 //[HeaderAttribute] // RVA: 0x68653C Offset: 0x68653C VA: 0x68653C
		[SerializeField]
		private List<Transform> m_AdjustPosTarget = new List<Transform>(); // 0x14
		[SerializeField]
		private List<Transform> m_AdjustScaleTarget = new List<Transform>(); // 0x18
		private int m_diva_id; // 0x1C
		private int m_diva_index; // 0x20

		// RVA: 0x1BE91E0 Offset: 0x1BE91E0 VA: 0x1BE91E0
		public void Initialize(int a_diva_id)
		{
			m_diva_id = a_diva_id;
			m_diva_index = a_diva_id - 1;
		}

		// RVA: 0x1BE91F0 Offset: 0x1BE91F0 VA: 0x1BE91F0
		public void LateUpdate()
		{
			if (m_diva_id == 0) // ?? test idx
				return;
			UpdatePosition();
			UpdateScale();
		}

		// RVA: 0x1BE9228 Offset: 0x1BE9228 VA: 0x1BE9228
		private void UpdatePosition()
		{
			for(int i = 0; i < m_AdjustPosTarget.Count; i++)
			{
				m_AdjustPosTarget[i].transform.localPosition = m_AdjustPosTarget[i].transform.localPosition * m_AdjustPosParam[m_diva_index];
			}
		}

		// RVA: 0x1BE9430 Offset: 0x1BE9430 VA: 0x1BE9430
		private void UpdateScale()
		{
			for (int i = 0; i < m_AdjustScaleTarget.Count; i++)
			{
				m_AdjustScaleTarget[i].transform.localScale = m_AdjustScaleTarget[i].transform.localScale * m_AdjustScaleParam[m_diva_index];
			}
		}
	}
}
