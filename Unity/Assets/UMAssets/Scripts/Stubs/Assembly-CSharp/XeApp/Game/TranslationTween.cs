using UnityEngine;

namespace XeApp.Game
{
	public class TranslationTween : TweenBase
	{
		[SerializeField]
		private Vector3 m_from;
		[SerializeField]
		private Vector3 m_to;
	}
}
