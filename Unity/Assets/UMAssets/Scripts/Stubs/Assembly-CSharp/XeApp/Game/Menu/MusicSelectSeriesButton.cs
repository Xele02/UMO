using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class MusicSelectSeriesButton : ActionButton
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private int m_logoTextureIndex;
		[SerializeField]
		private RawImageEx m_logoImage;
		[SerializeField]
		private RawImageEx m_newIcon;
	}
}
