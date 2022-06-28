using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class UnitSaveConfirmPanel : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private RawImageEx[] m_lowerDivaIconImages;
		[SerializeField]
		private RawImageEx[] m_upperDivaIconImages;
		[SerializeField]
		private RawImageEx[] m_lowerSceneIconImages;
		[SerializeField]
		private RawImageEx[] m_upperSceneIconImages;
		[SerializeField]
		private Text m_lowerSlotNumberText;
		[SerializeField]
		private Text m_upperSlotNumberText;
		[SerializeField]
		private Text m_lowerUnitNameText;
		[SerializeField]
		private Text m_upperUnitNameText;
		[SerializeField]
		private Text m_infoText;
		[SerializeField]
		private Text m_lowerTotalText;
		[SerializeField]
		private Text m_upperTotalText;
	}
}
