using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class DivaMenuParam : ScriptableObject
	{
		[SerializeField]
		private List<int> m_reactionWeights;
		[SerializeField]
		private List<float> m_cameraPosY;
		[SerializeField]
		private List<float> m_battleResultCameraPosY;
	}
}
