using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class MenuDivaGazeControl : MonoBehaviour
	{
		[Serializable]
		public class RotateData
		{
			public float min;
			public float max;
			public MenuDivaGazeControl.RotateType type;
		}

		[Serializable]
		public class Data
		{
			[Serializable]
			public class NodeData
			{
				public MenuDivaGazeControl.RotateData Head;
				public MenuDivaGazeControl.RotateData Neck;
				public MenuDivaGazeControl.RotateData Spine2;
				public MenuDivaGazeControl.RotateData Spine1;
				public MenuDivaGazeControl.RotateData Spine;
			}

			public DivaEyeControl.EyeUVData eyeUVData;
			public NodeData nodeData;
			public float threshold;
		}

		public enum RotateType
		{
			None = -1,
			X = 0,
			Y = 1,
			Z = 2,
			Num = 3,
		}

	}
}
