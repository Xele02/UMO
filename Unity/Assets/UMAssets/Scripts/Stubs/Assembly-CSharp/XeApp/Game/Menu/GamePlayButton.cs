using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.Events;

namespace XeApp.Game.Menu
{
	public class GamePlayButton : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_gamePlayButton;
		[SerializeField]
		private StayButton m_friendDivaButton;
		[SerializeField]
		private StayButton m_friendSceneButton;
		[SerializeField]
		private RawImageEx m_friendDivaImage;
		[SerializeField]
		private RawImageEx m_friendSceneImage;
		[SerializeField]
		private NumberBase m_energyNumber;
		[SerializeField]
		private FriendSelectEvent m_onFriendDivaButtonEvent;
		[SerializeField]
		private FriendSelectEvent m_onSceneButtonEvent;
		[SerializeField]
		private UnityEvent m_onPlayButtonEvent;
		[SerializeField]
		private NumberBase m_totalNum;
		[SerializeField]
		private RawImageEx m_ghostRankImage;
	}
}
