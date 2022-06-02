using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class SceneSelectHomeBgLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_setBgTitle;
		[SerializeField]
		private Text m_setBgExplanation;
		[SerializeField]
		private RawImageEx[] m_sceneImages;
		[SerializeField]
		private RawImageEx[] m_sceneUnitImages;
		[SerializeField]
		private RawImageEx m_limitBgImage;
		[SerializeField]
		private ActionButton[] m_sceneImagesButtons;
	}
}
