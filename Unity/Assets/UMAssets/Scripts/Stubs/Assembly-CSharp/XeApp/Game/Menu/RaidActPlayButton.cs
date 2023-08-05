using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class RaidActPlayButton : ActionButton
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private NumberBase m_useAp;
		[SerializeField]
		private RawImageEx m_dlMessageImage;
	}
}
