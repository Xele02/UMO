using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class DivaExtensionAdjustInterpolate : MonoBehaviour
	{
		// [HeaderAttribute] // RVA: 0x686728 Offset: 0x686728 VA: 0x686728
		public float[] m_AdjustPosParam = new float[10] {
			DivaAdjustPosParam.DIVA_00, DivaAdjustPosParam.DIVA_01, DivaAdjustPosParam.DIVA_02, DivaAdjustPosParam.DIVA_03, 
			DivaAdjustPosParam.DIVA_04, DivaAdjustPosParam.DIVA_05, DivaAdjustPosParam.DIVA_06, DivaAdjustPosParam.DIVA_07, 
			DivaAdjustPosParam.DIVA_08, DivaAdjustPosParam.DIVA_09
		}; // 0xC
		public float[] m_AdjustScaleParam = new float[10] {
			DivaAdjustScaleParam.DIVA_00, DivaAdjustScaleParam.DIVA_01, DivaAdjustScaleParam.DIVA_02, DivaAdjustScaleParam.DIVA_03, 
			DivaAdjustScaleParam.DIVA_04, DivaAdjustScaleParam.DIVA_05, DivaAdjustScaleParam.DIVA_06, DivaAdjustScaleParam.DIVA_07, 
			DivaAdjustScaleParam.DIVA_08, DivaAdjustScaleParam.DIVA_09
		}; // 0x10
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x68675C Offset: 0x68675C VA: 0x68675C
		private List<Transform> m_AdjustPosTarget = new List<Transform>(); // 0x14
		[SerializeField]
		private List<Transform> m_AdjustScaleTarget = new List<Transform>(); // 0x18
		// [HeaderAttribute] // RVA: 0x6867B4 Offset: 0x6867B4 VA: 0x6867B4
		[SerializeField]
		private Transform m_change_param_obj; // 0x1C
		private List<int> m_diva_id; // 0x20
		private List<int> m_diva_index; // 0x24

		// RVA: 0x1BEAB28 Offset: 0x1BEAB28 VA: 0x1BEAB28
		public void Initialize(List<GameDivaObject> a_diva_list)
		{
			m_diva_id = new List<int>();
			m_diva_index = new List<int>();
			for(int i = 0; i < a_diva_list.Count; i++)
			{
				m_diva_id.Add(a_diva_list[i].divaId);
				m_diva_index.Add(a_diva_list[i].divaId - 1);
			}
		}

		// RVA: 0x1BEAD08 Offset: 0x1BEAD08 VA: 0x1BEAD08
		public void LateUpdate()
		{
			if(m_change_param_obj == null)
				return;
			UpdatePosition();
			UpdateScale();
		}

		// RVA: 0x1BEADAC Offset: 0x1BEADAC VA: 0x1BEADAC
		private void UpdatePosition()
		{
			if(m_AdjustPosTarget.Count > 0)
			{
				float x = 1.0f;
				float y = 1.0f;
				int idx = Mathf.RoundToInt(m_change_param_obj.position.x);
				if(idx != 0)
				{
					x = m_AdjustPosParam[m_diva_index[idx - 1]];
				}
				idx = Mathf.RoundToInt(m_change_param_obj.position.y);
				if(idx != 0)
				{
					y = m_AdjustPosParam[m_diva_index[idx - 1]];
				}
				float val = Mathf.Lerp(x, y, m_change_param_obj.position.z);
				for(int i = 0; i < m_AdjustPosTarget.Count; i++)
				{
					m_AdjustPosTarget[i].transform.localPosition *= val;
				}
			}
		}

		// RVA: 0x1BEB168 Offset: 0x1BEB168 VA: 0x1BEB168
		private void UpdateScale()
		{
			if(m_AdjustScaleTarget.Count > 0)
			{
				float x = 1.0f;
				float y = 1.0f;
				int idx = Mathf.RoundToInt(m_change_param_obj.position.x);
				if(idx != 0)
				{
					x = m_AdjustPosParam[m_diva_index[idx - 1]];
				}
				idx = Mathf.RoundToInt(m_change_param_obj.position.y);
				if(idx != 0)
				{
					y = m_AdjustPosParam[m_diva_index[idx - 1]];
				}
				float val = Mathf.Lerp(x, y, m_change_param_obj.position.z);
				for(int i = 0; i < m_AdjustScaleTarget.Count; i++)
				{
					m_AdjustScaleTarget[i].transform.localScale *= val;
				}
			}
		}
	}
}
