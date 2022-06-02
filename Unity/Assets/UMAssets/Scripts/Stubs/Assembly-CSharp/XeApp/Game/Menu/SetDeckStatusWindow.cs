using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class SetDeckStatusWindow : MonoBehaviour
	{
		[SerializeField]
		private Color m_normalColorCode;
		[SerializeField]
		private InOutAnime m_inOut;
		[SerializeField]
		private SetDeckStatusValueControl[] m_status;
		[SerializeField]
		private GameObject m_statusInvalid;
		[SerializeField]
		private SetDeckStatusValueControl[] m_subStatus;
		[SerializeField]
		private Text[] m_notesTexts;
		[SerializeField]
		private Text[] m_centerSkillNameText;
		[SerializeField]
		private Text[] m_centerSkillEffectText;
		[SerializeField]
		private Text[] m_centerSkillLevelText;
		[SerializeField]
		private GameObject[] m_centerSkill;
		[SerializeField]
		private GameObject[] m_centerSkillInvalid;
		[SerializeField]
		private RawImageEx[] m_centerSkillRankImage;
		[SerializeField]
		private GameObject[] m_centerSkillNonActive;
		[SerializeField]
		private GameObject[] m_centerSkillRegulation;
		[SerializeField]
		private Text[] m_centerSkillRegulationText;
		[SerializeField]
		private UGUIButton m_centerSkillRegulationButton;
		[SerializeField]
		private GameObject m_activeSkill;
		[SerializeField]
		private GameObject m_activeSkillInvalid;
		[SerializeField]
		private Text m_activeSkillNameText;
		[SerializeField]
		private Text m_activeSkillEffectText;
		[SerializeField]
		private Text m_activeSkillLevelText;
		[SerializeField]
		private RawImageEx m_activeSkillRankImage;
		[SerializeField]
		private Text[] m_limitBreakText;
		[SerializeField]
		private Text[] m_limitBreakAttrBonusText;
		[SerializeField]
		private GameObject[] m_limitBreakAttrBonus;
		[SerializeField]
		private Text[] m_limitBreakSeriesBonusText;
		[SerializeField]
		private GameObject[] m_limitBreakSeriesBonus;
		[SerializeField]
		private UGUIButton m_supportButton;
		[SerializeField]
		private GameObject m_supportLock;
	}
}
