using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class SceneGrowthBoard : LayoutUGUIScriptBase
	{
		[SerializeField]
		protected ActionButton m_boardChangeButton;
		[SerializeField]
		protected ScrollRect m_scrollRect;
		[SerializeField]
		protected LayoutElement m_rangeObject;
		[SerializeField]
		protected NumberBase m_nultNumber;
		[SerializeField]
		protected string m_layoutExId;
		[SerializeField]
		protected ActionButton m_limitOverButton;
		[SerializeField]
		protected ActionButton m_subBoardReleaseButton;
	}
}
