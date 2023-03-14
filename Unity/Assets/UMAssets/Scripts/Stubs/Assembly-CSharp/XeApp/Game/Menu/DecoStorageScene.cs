using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class DecoStorageScene : TransitionRoot
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Image m_cover;
	}
}
