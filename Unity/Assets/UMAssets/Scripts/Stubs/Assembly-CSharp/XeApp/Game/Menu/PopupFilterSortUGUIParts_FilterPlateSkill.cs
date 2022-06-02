using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_FilterPlateSkill : PopupFilterSortUGUIPartsBase
	{
		[SerializeField]
		private InOutAnime m_inOutAnime;
		[SerializeField]
		private UGUIToggleButton[] m_RangeBtn;
		[SerializeField]
		private UGUIToggleButton[] m_RankBtn;
		[SerializeField]
		private UGUIToggleButton[] m_SkillBtn;
		[SerializeField]
		private Text[] m_Text;
		[SerializeField]
		private int skillType;
		[SerializeField]
		public UGUIToggleButton m_showBtn;
		[SerializeField]
		private GameObject m_setupContents;
		[SerializeField]
		private UGUIToggleButton m_allBtn;
		[SerializeField]
		private UGUIButton m_releaseBtn;
		[SerializeField]
		private RectTransform[] m_longshortArea;
	}
}
