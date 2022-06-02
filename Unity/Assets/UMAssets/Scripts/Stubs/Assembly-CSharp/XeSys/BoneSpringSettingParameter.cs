using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeSys
{
	public class BoneSpringSettingParameter : ScriptableObject
	{
		[Serializable]
		private class ControllerSettingParameter
		{
			public Vector3 fieldForce;
			public float influence;
		}

		[Serializable]
		private class ControlPointSettingParameter
		{
			public string path;
			public string relationalPointPath;
			public float radius;
			public float weight;
			public float mass;
			public float stability;
			public float influence;
			public Vector3 localVelocity;
			public List<string> colliderPathList;
		}

		[Serializable]
		private class ColliderSettingParameter
		{
			public string path;
			public float radius;
			public Vector3 offset;
			public string relationalColliderPath;
		}

		[SerializeField]
		private ControllerSettingParameter controllerParam;
		[SerializeField]
		private List<BoneSpringSettingParameter.ControlPointSettingParameter> controlPointParamList;
		[SerializeField]
		private List<BoneSpringSettingParameter.ColliderSettingParameter> colliderParamList;
	}
}
