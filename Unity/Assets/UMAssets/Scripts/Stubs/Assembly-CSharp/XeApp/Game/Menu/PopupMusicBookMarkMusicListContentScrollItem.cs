using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupMusicBookMarkMusicListContentScrollItem : SwapScrollListContent
	{
		[SerializeField]
		private RawImageEx m_jacketImage;
		[SerializeField]
		private GameObject[] m_attribute;
		[SerializeField]
		private RawImageEx m_seriesImage;
		[SerializeField]
		private Text m_musicNameText;
		[SerializeField]
		private Text m_singerNameText;
	}
}
