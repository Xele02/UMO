using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class DivaGrowthListItem : SwapScrollListContent
	{
		[SerializeField]
		private Text m_titleText;
		[SerializeField]
		private Text m_unlockTermsText;
		[SerializeField]
		private ActionButton m_conditionsButton;
		[SerializeField]
		private NumberBase[] m_skillLevel;
		[SerializeField]
		private RawImageEx m_complete;
		[SerializeField]
		private RawImageEx m_conditionsImage;
		[SerializeField]
		private NumberBase m_numerator;
		[SerializeField]
		private NumberBase m_denominator;
	}
}
