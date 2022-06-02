using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class UnitSetWindow : UnitSetSettingButton
	{
		[SerializeField]
		private StayButton m_valkyrieButton;
		[SerializeField]
		private InfoButton m_infoButton;
		[SerializeField]
		private ActionButton m_unitNameButton;
		[SerializeField]
		private StayButton[] m_centerSkillButton;
		[SerializeField]
		private StayButton m_activeSkillButton;
		[SerializeField]
		private ActionButton m_subPlateWindowButton;
		[SerializeField]
		private RawImageEx m_valkyrieImage;
		[SerializeField]
		private RawImageEx[] m_centerSkillInfoImage;
		[SerializeField]
		private RawImageEx m_activeSkillInfoImage;
		[SerializeField]
		private RawImageEx[] m_centerSkillRankImage;
		[SerializeField]
		private RawImageEx m_activeSkillRankImage;
		[SerializeField]
		private RawImageEx[] m_arrowImages;
		[SerializeField]
		private Text m_unitNameText;
		[SerializeField]
		private Text[] m_centerSkillEffectText;
		[SerializeField]
		private Text m_activeSkillEffectText;
		[SerializeField]
		private Text m_valkyrieAttackText;
		[SerializeField]
		private Text m_valkyrieHitText;
		[SerializeField]
		private Text[] m_statusTexts;
		[SerializeField]
		private Text[] m_notesTexts;
		[SerializeField]
		private CharaSet[] m_unitCaractarSets;
		[SerializeField]
		private string m_statusExid;
		[SerializeField]
		private string m_valkyrieIconExid;
		[SerializeField]
		private ShowUnitNameInputEvent m_onPushNameChangeButton;
		[SerializeField]
		private ShowSkillDetailsEvent m_onShowSkillDetailsEvent;
		[SerializeField]
		private RawImageEx m_valAttackImages;
		[SerializeField]
		private RawImageEx m_valHitImages;
		[SerializeField]
		private RegulationButton m_regulationButton;
		public int displayModeTableRowCount;
	}
}
