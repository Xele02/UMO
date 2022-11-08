using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class MusicSelectPlayButton : ActionButton
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private NumberBase m_useEnergy;
		[SerializeField]
		private RawImageEx m_dlMessageImage;
	}
}
