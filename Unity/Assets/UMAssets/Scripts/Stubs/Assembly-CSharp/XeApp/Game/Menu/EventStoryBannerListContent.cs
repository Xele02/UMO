using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class EventStoryBannerListContent : SwapScrollListContent
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private RawImageEx m_image;
		[SerializeField]
		private Text m_periodText;
		[SerializeField]
		private ActionButton m_button;
	}
}
