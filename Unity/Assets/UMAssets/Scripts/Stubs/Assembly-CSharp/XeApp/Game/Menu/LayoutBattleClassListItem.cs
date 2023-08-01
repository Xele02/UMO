using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutBattleClassListItem : LayoutShopListElemBase
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Text m_textLock;
		[SerializeField]
		private NumberBase m_numScore;
		[SerializeField]
		private RawImageEx m_imageClass;
		[SerializeField]
		private ActionButton m_button;
	}
}
