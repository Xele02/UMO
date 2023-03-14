using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class GachaRateEpCaution : GachaRateElemBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Text m_caution01;
		[SerializeField]
		private Text m_caution02;
	}
}
