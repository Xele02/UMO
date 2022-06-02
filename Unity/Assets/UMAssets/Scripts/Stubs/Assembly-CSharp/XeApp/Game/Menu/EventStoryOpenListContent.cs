using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class EventStoryOpenListContent : SwapScrollListContent
	{
		[SerializeField]
		private RawImageEx m_thumbnail;
		[SerializeField]
		private Text m_titleText;
	}
}
