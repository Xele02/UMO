using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectSeriesButton : MonoBehaviour
	{
		[SerializeField]
		private UGUIToggleButton m_toggleButton;
		[SerializeField]
		private RawImageEx m_seriesImage;
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}
	}
}
