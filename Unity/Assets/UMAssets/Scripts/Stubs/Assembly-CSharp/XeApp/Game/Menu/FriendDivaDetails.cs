using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class FriendDivaDetails : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_friendNameText;
		[SerializeField]
		private Text m_rankText;
		[SerializeField]
		private Text m_centerSkillText;
		[SerializeField]
		private StatusLabelSet m_status;
		[SerializeField]
		private RawImageEx m_sceneIconImage;
		[SerializeField]
		private RawImageEx m_skillDetailIconImage;
		[SerializeField]
		private StayButton m_sceneButton;
		[SerializeField]
		private ActionButton m_centerSkillInfo;
		[SerializeField]
		private FriendSelectEvent m_onFriendDivaButtonEvent;
		[SerializeField]
		private SceneSelectEvent m_onSceneButtonEvent;
		[SerializeField]
		private ShowSkillDetailsEvent m_onShowSkillDetailsEvent;
	}
}
