using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class UGUICrossFader : MonoBehaviour
	{
		[Serializable]
		private class TargetGroup
		{
			[SerializeField]
			public List<Graphic> m_fadeTargets;
		}

		[SerializeField]
		private List<UGUICrossFader.TargetGroup> m_targetGroups;
		[SerializeField]
		private AnimeCurveScriptableObject m_animeCurve;
		[SerializeField]
		private float m_animeLengthSec;
	}
}
