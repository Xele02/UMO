using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class FriendMenuRuntime : LayoutLabelScriptBase
	{
		[SerializeField]
		private FriendMenuListButton m_friendListButton;
		[SerializeField]
		private FriendMenuListButton m_requestListButton;
		[SerializeField]
		private FriendMenuListButton m_acceptListButton;
		[SerializeField]
		private ActionButton m_friendSearchButton;
	}
}
