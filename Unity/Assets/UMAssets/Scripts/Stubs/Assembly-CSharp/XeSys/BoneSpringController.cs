using UnityEngine;
using System.Collections.Generic;

namespace XeSys
{
	public class BoneSpringController : MonoBehaviour
	{
		public enum PerformanceMode
		{
			High = 0,
			Low = 1,
		}

		public Vector3 fieldForce_;
		public float influence;
		public float Scale;
		[SerializeField]
		private BoneSpringSettingParameter highPerformanceSettingParameter;
		[SerializeField]
		private BoneSpringSettingParameter lowPerformanceSettingParameter;
		[SerializeField]
		private PerformanceMode currentPerformanceMode;
		[SerializeField]
		private List<BoneSpringCollider> m_collider;
		[SerializeField]
		private bool m_enable;
	}
}
