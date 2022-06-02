using System;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	[Serializable]
	public class TransitionTreeObject : ScriptableObject
	{
		[Serializable]
		public class SceneTree
		{
			public TransitionList.Type m_sceneName;
			public SceneCacheCategory m_cacheCategory;
			public int m_uniquId;
			public int m_FadeId;
			public CommonMenuStackLabel.LabelType m_titleLabel;
			public int m_descId;
			public BgType m_bgType;
			public int m_childIndex;
			public int m_siblingIndex;
		}

		[Serializable]
		public class SceneRoot
		{
			public SceneGroupCategory m_category;
			public List<TransitionTreeObject.SceneTree> list;
		}

		[SerializeField]
		private List<TransitionTreeObject.SceneRoot> list;
	}
}
