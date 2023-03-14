using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class OfferResultScene : TransitionRoot
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private ScriptableObject m_CameraParam;
		[SerializeField]
		private Button m_SkipButton;
	}
}
