using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutQuestRewardItem : SwapScrollListContent
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private RawImageEx m_imageIcon;
		[SerializeField]
		private NumberBase m_numReward;
		[SerializeField]
		private ActionButton m_buttonReward;
	}
}
