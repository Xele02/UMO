using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class ProfilScrollIcon : SwapScrollListContent
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private RawImageEx m_image_icon;
		[SerializeField]
		private ActionButton m_button;
	}
}
