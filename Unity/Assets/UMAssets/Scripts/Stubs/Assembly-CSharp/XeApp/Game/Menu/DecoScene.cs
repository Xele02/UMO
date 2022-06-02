using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class DecoScene : TransitionRoot
	{
		[SerializeField]
		private DecorationScreenShotView m_screenShotViewPrefab;
		[SerializeField]
		private GameObject m_captureLogoPrefab;
		[SerializeField]
		private Image m_serifAttacherCover;
	}
}
