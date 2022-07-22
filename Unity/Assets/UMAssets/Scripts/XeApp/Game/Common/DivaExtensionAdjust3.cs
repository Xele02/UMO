using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class DivaExtensionAdjust3 : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x686594 Offset: 0x686594 VA: 0x686594
		public float[] m_AdjustPosParam = new float[10] { DivaAdjustPosParam.DIVA_00, DivaAdjustPosParam.DIVA_01, DivaAdjustPosParam.DIVA_02, DivaAdjustPosParam.DIVA_03,
			DivaAdjustPosParam.DIVA_04, DivaAdjustPosParam.DIVA_05, DivaAdjustPosParam.DIVA_06, DivaAdjustPosParam.DIVA_07, DivaAdjustPosParam.DIVA_08, DivaAdjustPosParam.DIVA_09}; // 0xC
		public float[] m_AdjustScaleParam = new float[10] { DivaAdjustScaleParam.DIVA_00, DivaAdjustScaleParam.DIVA_01, DivaAdjustScaleParam.DIVA_02, DivaAdjustScaleParam.DIVA_03,
			DivaAdjustScaleParam.DIVA_04, DivaAdjustScaleParam.DIVA_05, DivaAdjustScaleParam.DIVA_06, DivaAdjustScaleParam.DIVA_07, DivaAdjustScaleParam.DIVA_08, DivaAdjustScaleParam.DIVA_09}; // 0x10
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6865C8 Offset: 0x6865C8 VA: 0x6865C8
		private List<Transform> m_AdjustPosTarget = new List<Transform>(); // 0x14
		[SerializeField]
		private List<Transform> m_AdjustScaleTarget = new List<Transform>(); // 0x18
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x686620 Offset: 0x686620 VA: 0x686620
		private float m_rate_x = 1; // 0x1C
		[SerializeField]
		private float m_rate_y = 1; // 0x20
		[SerializeField]
		private float m_rate_z = 1; // 0x24
		//[HeaderAttribute] // RVA: 0x686688 Offset: 0x686688 VA: 0x686688
		[SerializeField]
		private int m_position_id_01 = 1; // 0x28
		[SerializeField]
		private int m_position_id_02 = 1; // 0x2C
		//[HeaderAttribute] // RVA: 0x6866E0 Offset: 0x6866E0 VA: 0x6866E0
		[SerializeField]
		private float m_position_id_rate; // 0x30
		private List<int> m_diva_index; // 0x34

		// RVA: 0x1BE9BF4 Offset: 0x1BE9BF4 VA: 0x1BE9BF4
		public void Initialize(List<GameDivaObject> a_diva_list)
		{
			m_diva_index = new List<int>();
			for(int i = 0; i < a_diva_list.Count; i++)
			{
				m_diva_index.Add(a_diva_list[i].divaId - 1);
			}
		}

		// RVA: 0x1BE9D40 Offset: 0x1BE9D40 VA: 0x1BE9D40
		public void LateUpdate()
		{
			if(m_diva_index.Count > 0)
			{
				UpdatePosition();
				UpdateScale();
			}
		}

		// RVA: 0x1BE9DC8 Offset: 0x1BE9DC8 VA: 0x1BE9DC8
		private void UpdatePosition()
		{
			if(m_AdjustPosTarget.Count > 0)
			{
				int diva1 = GetDivaIndex(m_position_id_01);
				int diva2 = GetDivaIndex(m_position_id_02);
				float val = Mathf.Lerp(m_AdjustPosParam[diva1], m_AdjustPosParam[diva2], m_position_id_rate);
				for(int i = 0; i < m_AdjustPosTarget.Count; i++)
				{
					Vector3 pos = m_AdjustPosTarget[i].transform.localPosition;
					pos.x *= Mathf.Lerp(1.0f, val, m_rate_x);
					pos.y *= Mathf.Lerp(1.0f, val, m_rate_y);
					pos.z *= Mathf.Lerp(1.0f, val, m_rate_z);
					m_AdjustPosTarget[i].transform.localPosition = pos;
				}
			}
		}

		// RVA: 0x1BEA12C Offset: 0x1BEA12C VA: 0x1BEA12C
		private void UpdateScale()
		{
			if (m_AdjustScaleTarget.Count > 0)
			{
				int diva1 = GetDivaIndex(m_position_id_01);
				int diva2 = GetDivaIndex(m_position_id_02);
				float val = Mathf.Lerp(m_AdjustPosParam[diva1], m_AdjustPosParam[diva2], m_position_id_rate);
				for (int i = 0; i < m_AdjustScaleTarget.Count; i++)
				{
					Vector3 pos = m_AdjustScaleTarget[i].transform.localScale;
					pos.x *= Mathf.Lerp(1.0f, val, m_rate_x);
					pos.y *= Mathf.Lerp(1.0f, val, m_rate_y);
					pos.z *= Mathf.Lerp(1.0f, val, m_rate_z);
					m_AdjustScaleTarget[i].transform.localScale = pos;
				}
			}
		}

		// RVA: 0x1BEA490 Offset: 0x1BEA490 VA: 0x1BEA490
		private int GetDivaIndex(int a_pos_id)
		{
			if (m_diva_index.Count <= a_pos_id - 1)
				return 0;
			return m_diva_index[a_pos_id - 1];
		}
	}
}
