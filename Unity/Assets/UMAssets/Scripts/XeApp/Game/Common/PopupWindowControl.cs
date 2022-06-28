using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Common
{
	public class PopupWindowControl : MonoBehaviour
	{
		public Text m_titleText;
		public Image m_image;
		public Image m_blackPanel;
		public Image[] m_gradation;
		public LayoutUGUIRuntime m_buttonUguiRuntime;
		public LayoutUGUIRuntime m_tabButtonUguiRuntime;
		public AnimationCurve m_inCurve;
		public AnimationCurve m_outCurve;
		public float m_speed;
		public Sprite[] m_windowSprites;
	}
}
