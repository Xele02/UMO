using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class PopupMvModeLackDivaListContent : SwapScrollListContent
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Text m_divaName;
		[SerializeField]
		private RawImage m_divaIcon;
	}
}
