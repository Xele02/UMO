using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutDecoCustomSelectItemBase : SwapScrollListContent
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Vector2 m_size;
		[SerializeField]
		private RawImageEx m_itemImage;
		[SerializeField]
		private ButtonBase m_button;
	}
}
