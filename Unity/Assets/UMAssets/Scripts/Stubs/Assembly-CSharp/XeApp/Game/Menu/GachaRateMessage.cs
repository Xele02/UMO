using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class GachaRateMessage : GachaRateElemBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Text m_message;
	}
}
