using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LobbyScrollListWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_decoIconImage01;
		[SerializeField]
		private RawImageEx m_decoIconImage02;
		[SerializeField]
		private RawImageEx m_switchIcon;
		[SerializeField]
		private ActionButton m_iconChangeButton;
		[SerializeField]
		private ActionButton m_bbsUpdateButton;
		[SerializeField]
		private Transform m_tranCharaRoot;
		[SerializeField]
		private ActionButton m_gotoListTopButton;
		[SerializeField]
		private LayoutUGUIScrollSupport m_scrollSupport;
		[SerializeField]
		private ButtonBase m_guideCharaBtn;
	}
}
