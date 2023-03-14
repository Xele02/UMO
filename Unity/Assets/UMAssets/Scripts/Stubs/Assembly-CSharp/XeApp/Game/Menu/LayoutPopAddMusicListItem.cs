using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutPopAddMusicListItem : SwapScrollListContent
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private RawImageEx jacketImage;
		[SerializeField]
		private RawImageEx seriesLogoImage;
		[SerializeField]
		private RawImageEx lineImage;
		[SerializeField]
		private Text musicNameText;
		[SerializeField]
		private Text singerNameText;
	}
}
