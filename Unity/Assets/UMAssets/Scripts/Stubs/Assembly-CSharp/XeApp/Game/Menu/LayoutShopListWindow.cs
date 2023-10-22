using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutShopListWindow : LayoutShopListBase
	{
        protected override AbsoluteLayout layoutRoot => throw new System.NotImplementedException();

        protected override void OnSelectListItem(int value, SwapScrollListContent content)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnUpdateListItem(int index, SwapScrollListContent content)
        {
            throw new System.NotImplementedException();
        }

        private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
	}
}
