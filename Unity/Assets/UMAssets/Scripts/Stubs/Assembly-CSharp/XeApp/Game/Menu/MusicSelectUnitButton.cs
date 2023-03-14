using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class MusicSelectUnitButton : ActionButton
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private RawImageEx m_imageOnOff;
		[SerializeField]
		private RawImageEx m_imageDisable;
	}
}
