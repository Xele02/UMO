using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class ValkyrieCameraParameter : ScriptableObject
	{
		public Vector3 m_DefaultCameraPosition;
		public Vector3 m_DefaultTargetPosition;
		public Vector3 m_FinishCameraInfo;
		public Vector3 m_FinishTargetInfo;
		public List<Vector3> m_FinishCameraPositionList;
		public List<Vector3> m_FinishTargetPositionList;
		public float m_CameraFieldOfView;
		public float m_CameraFarClip;
		public float m_CameraNearClip;
		public float m_CameraLerpTime;
	}
}
