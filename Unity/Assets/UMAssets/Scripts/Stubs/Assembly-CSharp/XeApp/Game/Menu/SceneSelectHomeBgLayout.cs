using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class SceneSelectHomeBgLayout : LayoutUGUIScriptBase
	{
		private enum PlateState
		{
			Undeveloped = 0,
			Evolution = 1,
			Num = 2,
		}

		public enum SetBgType
		{
			Undeveloped = 0,
			EvoleOnly = 1,
			Evole = 2,
			Default = 3,
			LimitBg = 4,
		}

    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
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
