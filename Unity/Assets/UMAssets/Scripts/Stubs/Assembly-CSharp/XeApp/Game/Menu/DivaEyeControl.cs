using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class DivaEyeControl : MonoBehaviour
	{
		[Serializable]
		public class AngleData
		{
			public float angle;
			public float offset;
		}

		[Serializable]
		public class EyeUVData
		{
			public DivaEyeControl.AngleData xMin;
			public DivaEyeControl.AngleData xMax;
			public DivaEyeControl.AngleData yMin;
			public DivaEyeControl.AngleData yMax;
		}

		[SerializeField]
		private EyeUVData m_uvData;
	}
}
