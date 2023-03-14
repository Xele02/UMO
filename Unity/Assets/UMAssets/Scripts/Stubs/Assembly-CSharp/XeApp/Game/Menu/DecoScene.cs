using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class DecoScene : TransitionRoot
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private DecorationScreenShotView m_screenShotViewPrefab;
		[SerializeField]
		private GameObject m_captureLogoPrefab;
		[SerializeField]
		private Image m_serifAttacherCover;
	}
}
