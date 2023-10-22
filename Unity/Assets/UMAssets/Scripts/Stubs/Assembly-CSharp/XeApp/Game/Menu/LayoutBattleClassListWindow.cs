using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutBattleClassListWindow : LayoutShopListBase
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}

        protected override void OnSelectListItem(int value, SwapScrollListContent content)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnUpdateListItem(int index, SwapScrollListContent content)
        {
            throw new System.NotImplementedException();
        }

        [SerializeField]
		private Text[] m_textCaution;

        protected override AbsoluteLayout layoutRoot => throw new System.NotImplementedException();
    }
}
