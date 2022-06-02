using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class SetDeckStatusValueControl : MonoBehaviour
	{
		[SerializeField]
		private Text m_valueText;
		[SerializeField]
		private Image m_arrowImage;
		[SerializeField]
		private Image m_enemyImage;
		[SerializeField]
		private Color m_enemyTextColor;
		[SerializeField]
		private AnimeCurveScriptableObject m_animeCurve;
		[SerializeField]
		private float m_animeLengthSec;
	}
}
