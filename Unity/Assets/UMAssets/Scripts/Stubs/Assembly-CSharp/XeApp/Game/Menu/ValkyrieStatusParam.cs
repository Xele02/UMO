using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class ValkyrieStatusParam : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_valkrieImage;
		[SerializeField]
		private RawImageEx m_pilotImage;
		[SerializeField]
		private RawImageEx m_logoImage;
		[SerializeField]
		private RawImageEx m_valAtkImage;
		[SerializeField]
		private RawImageEx m_valHitImage;
		[SerializeField]
		private Text m_robotName;
		[SerializeField]
		private Text m_pilotName;
		[SerializeField]
		private Text m_attackText;
		[SerializeField]
		private Text m_hitText;
	}
}
