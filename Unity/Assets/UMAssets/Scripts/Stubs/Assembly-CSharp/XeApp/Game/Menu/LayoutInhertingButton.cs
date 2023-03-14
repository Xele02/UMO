using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutInhertingButton : ActionButton
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private RawImageEx m_fontImage;
		[SerializeField]
		private int m_fontNumber;
	}
}
