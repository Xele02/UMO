using System;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class GachaDirectionCardSet : GachaDirectionAnimSetBase
	{
		[Serializable]
		private class AttributeSetting
		{
			[SerializeField]
			private Transform m_nameRoot;
			[SerializeField]
			private List<GameObject> m_objects;
		}

		[SerializeField]
		private List<Renderer> m_cardRenderers;
		[SerializeField]
		private Animator m_cardNamePlateAnimator;
		[SerializeField]
		private Animator m_cardSeriesAnimator;
		[SerializeField]
		private List<Transform> m_cardFrameParents;
		[SerializeField]
		private AttributeSetting m_attrHoshi;
		[SerializeField]
		private AttributeSetting m_attrAi;
		[SerializeField]
		private AttributeSetting m_attrInochi;
		[SerializeField]
		private AttributeSetting m_attrZen;
	}
}
