using UnityEngine;
using System;

namespace XeSys.Gfx
{
	public class LayoutUGUIPrefabManager : MonoBehaviour
	{
		[Serializable]
		public class PrefabData
		{
			public string m_name;
			public bool m_isUpdate;
			public bool m_isTextureUpdate;
		}

		public LayoutUGUIRuntime[] m_prefabList;
		public PrefabData[] m_prefabData;
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}
	}
}
