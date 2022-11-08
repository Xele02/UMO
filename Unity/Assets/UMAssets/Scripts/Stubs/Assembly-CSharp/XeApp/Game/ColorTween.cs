using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game
{
	public class ColorTween : TweenBase
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private Color m_from;
		[SerializeField]
		private Color m_to;
		[SerializeField]
		private Graphic m_target;
	}
}
