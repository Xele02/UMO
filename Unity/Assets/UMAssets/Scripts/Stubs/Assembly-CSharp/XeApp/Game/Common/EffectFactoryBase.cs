using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class EffectFactoryBase : MonoBehaviour
	{
		[Serializable]
		public class Setting
		{
			public GameObject effectPrefab;
			public string commonAssetName;
			public string id;
			public bool playOnAwake;
			public Transform parent;
			public Vector3 position;
			public Quaternion rotation;
			public Vector3 scale;
		}

		[SerializeField]
		private List<EffectFactoryBase.Setting> m_settings;
	}
}
