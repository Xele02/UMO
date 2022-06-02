using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class CharaSet : LayoutUGUIScriptBase
	{
		[SerializeField]
		private StayButton[] m_divaButton;
		[SerializeField]
		private SceneButton[] m_mainSceneButton;
		[SerializeField]
		private SceneButton[] m_subSceneButtons;
		[SerializeField]
		private RawImageEx[] m_divaImages;
		[SerializeField]
		private RawImageEx[] m_mainSceneImages;
		[SerializeField]
		private RawImageEx[] m_subSceneImages;
		[SerializeField]
		private string m_charaWindowExId;
		[SerializeField]
		private string m_charaWindowSymbol;
		[SerializeField]
		public DivaSelectEvent m_onDivaClickEvent;
		[SerializeField]
		public DivaSelectEvent m_onDivaStayEvent;
		[SerializeField]
		public SceneSelectEvent m_onSceneClickEvent;
		[SerializeField]
		public SceneSelectEvent m_onSceneStayEvent;
	}
}
