using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.DebugUIMenu
{
	public class DebugTeamSetUp : MonoBehaviour
	{
		[SerializeField]
		private UIDebugTeamEdit m_debug_team_edit;
		[SerializeField]
		private UIDebugSceneSelect m_degub_scene_select;
		[SerializeField]
		private UIDebugLiveCardSelect m_degug_live_card;
		[SerializeField]
		private Button m_button;
	}
}
