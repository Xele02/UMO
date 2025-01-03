using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class EpisodeBonusPlateScrollContent : SwapScrollListContent
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private RawImageEx m_sceneIconImage;
		[SerializeField]
		private Text m_bonusUpText;
		[SerializeField]
		private Text m_bonusText;
		[SerializeField]
		private Text m_unownedText;
		[SerializeField]
		private Text m_assistText;
	}
}
