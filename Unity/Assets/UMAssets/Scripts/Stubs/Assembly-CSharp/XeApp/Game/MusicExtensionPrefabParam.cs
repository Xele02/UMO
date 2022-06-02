using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game
{
	public class MusicExtensionPrefabParam : ScriptableObject
	{
		[Serializable]
		public class AttachData
		{
			[SerializeField]
			public string path;
			[SerializeField]
			public bool isEnableStart;
		}

		[SerializeField]
		private List<MusicExtensionPrefabParam.AttachData> m_AttachDataList;
	}
}
