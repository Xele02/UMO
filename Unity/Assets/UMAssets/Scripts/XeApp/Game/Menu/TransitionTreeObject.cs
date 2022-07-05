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
			public TransitionList.Type m_sceneName; // 0x8
			public SceneCacheCategory m_cacheCategory; // 0xC
			public int m_uniquId; // 0x10
			public int m_FadeId; // 0x14
			public CommonMenuStackLabel.LabelType m_titleLabel = CommonMenuStackLabel.LabelType._Undefined; // 0x18
			public int m_descId = -1; // 0x1C
			public BgType m_bgType = BgType.Undefined; // 0x20
			public int m_childIndex = -1; // 0x24
			public int m_siblingIndex; // 0x28

			// RVA: 0xA3983C Offset: 0xA3983C VA: 0xA3983C
			public TransitionTreeObject.SceneTree FindChild(List<TransitionTreeObject.SceneTree> list, Func<TransitionTreeObject.SceneTree, bool> cmp)
			{
				if(m_childIndex < 0)
					return null;
				bool found = cmp(list[m_childIndex]);
				TransitionTreeObject.SceneTree res = list[m_childIndex];
				while(!found)
				{
					if(res.m_siblingIndex < 0)
						return null;
					res = list[res.m_siblingIndex];
					found = cmp(res);
				}
				return res;
			}
		}

		[Serializable]
		public class SceneRoot
		{
			public SceneGroupCategory m_category; // 0x8
			public List<TransitionTreeObject.SceneTree> list = new List<SceneTree>(); // 0xC
		}

		[SerializeField]
		private List<TransitionTreeObject.SceneRoot> list = new List<SceneRoot>(); // 0xC
		public List<TransitionTreeObject.SceneRoot> List { get { return list; } } //0xA316DC

		// RVA: 0xA41E50 Offset: 0xA41E50 VA: 0xA41E50
		public TransitionTreeObject.SceneRoot Find(Predicate<TransitionTreeObject.SceneRoot> match)
		{
			return list.Find(match);
		}
	}
}
