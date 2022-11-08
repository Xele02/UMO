using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class EventStorySeriestabLayout : ActionButton
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private int m_logoTextureIndex;
		[SerializeField]
		private RawImageEx m_offLogoImage;
		[SerializeField]
		private RawImageEx m_onLogoImage;
		[SerializeField]
		private RawImageEx new_Icon;
	}
}
