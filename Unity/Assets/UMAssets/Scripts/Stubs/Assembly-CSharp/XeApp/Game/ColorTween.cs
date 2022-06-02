using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game
{
	public class ColorTween : TweenBase
	{
		[SerializeField]
		private Color m_from;
		[SerializeField]
		private Color m_to;
		[SerializeField]
		private Graphic m_target;
	}
}
