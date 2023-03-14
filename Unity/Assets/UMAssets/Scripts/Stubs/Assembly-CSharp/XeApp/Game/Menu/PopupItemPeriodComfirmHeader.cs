using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class PopupItemPeriodComfirmHeader : FlexibleListItemLayout
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Text m_textPeriod;
		[SerializeField]
		private Text m_textNum;
	}
}
