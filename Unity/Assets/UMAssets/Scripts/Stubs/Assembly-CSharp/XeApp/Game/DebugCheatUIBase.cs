using UnityEngine;
using System;
using XeApp.Game.Menu;

namespace XeApp.Game
{
	public class DebugCheatUIBase : MonoBehaviour
	{
		[Serializable]
		public class Condition
		{
			[SerializeField]
			private string m_sceneName;
			[SerializeField]
			private TransitionList.Type m_transitionType;
		}

		[SerializeField]
		private Condition m_menuCondition;
	}
}
