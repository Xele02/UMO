using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine.Events;

namespace XeApp.Game.Menu
{
	public class UnitCheckWindow : UnitSetSettingButton
	{
		[SerializeField]
		private StayButton m_valkyrieButton;
		[SerializeField]
		private InfoButton m_infoButton;
		[SerializeField]
		private ActionButton m_unitNameButton;
		[SerializeField]
		private ActionButton m_episodeBonusButton;
		[SerializeField]
		private ActionButton m_prismButton;
		[SerializeField]
		private ActionButton m_gameSettingButton;
		[SerializeField]
		private ActionButton m_scoreInfoButton;
		[SerializeField]
		private RepeatButton m_scorePlusButton;
		[SerializeField]
		private RepeatButton m_scoreMinusButton;
		[SerializeField]
		private StayButton m_centerSkillButton;
		[SerializeField]
		private StayButton m_activeSkillButton;
		[SerializeField]
		private ActionButton m_subPlateWindowButton;
		[SerializeField]
		private RawImageEx m_valkyrieImage;
		[SerializeField]
		private RawImageEx m_centerSkillInfoImage;
		[SerializeField]
		private RawImageEx m_activeSkillInfoImage;
		[SerializeField]
		private RawImageEx m_centerSkillRankImage;
		[SerializeField]
		private RawImageEx m_activeSkillRankImage;
		[SerializeField]
		private RawImageEx m_jacketImage;
		[SerializeField]
		private RawImageEx m_difficultImage;
		[SerializeField]
		private RawImageEx m_musicAttributeImage;
		[SerializeField]
		private RawImageEx[] m_arrowImages;
		[SerializeField]
		private RawImageEx m_prismLabelImage;
		[SerializeField]
		private RawImageEx[] m_multiIconImages;
		[SerializeField]
		private RawImageEx m_scorePlusImage;
		[SerializeField]
		private Text m_unitNameText;
		[SerializeField]
		private Text m_centerSkillEffectText;
		[SerializeField]
		private Text m_activeSkillEffectText;
		[SerializeField]
		private Text m_musicTitleText;
		[SerializeField]
		private Text m_valkyrieAttackText;
		[SerializeField]
		private Text m_valkyrieHitText;
		[SerializeField]
		private Text[] m_statusTexts;
		[SerializeField]
		private Text[] m_notesTexts;
		[SerializeField]
		private Text m_gaugeRateText;
		[SerializeField]
		private CharaSet[] m_unitCaractarSets;
		[SerializeField]
		private string m_statusExid;
		[SerializeField]
		private string m_valkyrieIconExid;
		[SerializeField]
		private Text m_episodeBonusNum;
		[SerializeField]
		private ShowUnitNameInputEvent m_onPushNameChangeButton;
		[SerializeField]
		private ShowSkillDetailsEvent m_onShowSkillDetailsEvent;
		[SerializeField]
		private AnimeCurveScriptableObject m_animeCurve;
		[SerializeField]
		private NumberBase m_prizmRankNumber;
		[SerializeField]
		private UnitExpectedScore m_scoreGauge;
		[SerializeField]
		private UnityEvent m_onPushGameSettingButton;
		[SerializeField]
		private RawImageEx m_valAttackImages;
		[SerializeField]
		private RawImageEx m_valHitImages;
		[SerializeField]
		private ActionButton m_skipButton;
		[SerializeField]
		private Text m_skipTicketText;
		[SerializeField]
		private RegulationButton m_regulationButton;
		public int displayModeTableRowCount;
	}
}
