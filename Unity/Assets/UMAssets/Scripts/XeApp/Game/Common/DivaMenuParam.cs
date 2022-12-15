using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class DivaMenuParam : ScriptableObject
	{
		public enum CameraPosType
		{
			Default = 0,
			BattleResult = 1,
			_Num = 2,
		}

		[SerializeField]
		private List<int> m_reactionWeights; // 0xC
		[SerializeField]
		private List<float> m_cameraPosY; // 0x10
		[SerializeField]
		private List<float> m_battleResultCameraPosY; // 0x14

		public IList<int> ReactionWeights { get { return m_reactionWeights; } } // get_ReactionWeights 0x1BF00FC 

		// // RVA: 0x1BF0104 Offset: 0x1BF0104 VA: 0x1BF0104
		public IList<float> CameraPosY(DivaMenuParam.CameraPosType type)
		{
			if (type == CameraPosType.BattleResult)
				return m_battleResultCameraPosY;
			return m_cameraPosY;
		}
	}
}
