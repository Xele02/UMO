using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutPopupUnlockDifficulty : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_textMusicName;
		[SerializeField]
		private RawImageEx m_imageMusicJacket;
		[SerializeField]
		private RawImageEx m_imageLogo;
		[SerializeField]
		private RawImageEx[] m_imageTitle;
	}
}
