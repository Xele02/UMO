using UnityEngine;

namespace XeApp.Game.Common
{
	public class HomeUIHideButton : MonoBehaviour
	{
		[SerializeField]
		private ButtonBase m_buttonHide;
		[SerializeField]
		private ButtonBase m_buttonShow;
		[SerializeField]
		private InOutAnime m_inOutAnime;
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement Monobehaviour");
		}
	}
}
