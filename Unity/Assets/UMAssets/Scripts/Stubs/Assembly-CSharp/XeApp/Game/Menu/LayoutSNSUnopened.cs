using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutSNSUnopened : LayoutSNSBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Text m_title;
		[SerializeField]
		private Text m_text;
	}
}
