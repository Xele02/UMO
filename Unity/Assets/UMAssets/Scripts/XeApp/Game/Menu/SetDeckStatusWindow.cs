using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using XeSys.Gfx;
using System.Text;

namespace XeApp.Game.Menu
{
	public class SetDeckStatusWindow : MonoBehaviour
	{
		public enum StatusName
		{
			Total = 0,
			Soul = 1,
			Voice = 2,
			Charm = 3,
			Life = 4,
			Support = 5,
			Fold = 6,
			Luck = 7,
			Num = 8,
		}

		public enum CenterSkillRegulation
		{
			Music = 0,
			Series = 1,
			Attribute = 2,
			Diva = 3,
			Num = 4,
		}

		private enum CenterSkillSlot
		{
			Skill2 = 0,
			Skill1 = 1,
			Num = 2,
		}

		private const string LevelFormat = "Lv{0}";
		private const string InvalidText = "---";
		private const int TOTAL_MAX = 9999999;
		private const int SUBPARAM_MAX = 999999;
		[SerializeField] // RVA: 0x683860 Offset: 0x683860 VA: 0x683860
		//[TooltipAttribute] // RVA: 0x683860 Offset: 0x683860 VA: 0x683860
		private Color m_normalColorCode = new Color(0.1960784f, 0.1960784f, 0.1960784f); // 0xC
		//[TooltipAttribute] // RVA: 0x6838C8 Offset: 0x6838C8 VA: 0x6838C8
		[SerializeField] // RVA: 0x6838C8 Offset: 0x6838C8 VA: 0x6838C8
		private InOutAnime m_inOut; // 0x1C
		//[TooltipAttribute] // RVA: 0x683910 Offset: 0x683910 VA: 0x683910
		[SerializeField] // RVA: 0x683910 Offset: 0x683910 VA: 0x683910
		private SetDeckStatusValueControl[] m_status = new SetDeckStatusValueControl[8]; // 0x20
		[SerializeField] // RVA: 0x68396C Offset: 0x68396C VA: 0x68396C
		private GameObject m_statusInvalid; // 0x24
		[SerializeField] // RVA: 0x68397C Offset: 0x68397C VA: 0x68397C
		//[TooltipAttribute] // RVA: 0x68397C Offset: 0x68397C VA: 0x68397C
		private SetDeckStatusValueControl[] m_subStatus = new SetDeckStatusValueControl[4]; // 0x28
		[SerializeField] // RVA: 0x6839D4 Offset: 0x6839D4 VA: 0x6839D4
		//[TooltipAttribute] // RVA: 0x6839D4 Offset: 0x6839D4 VA: 0x6839D4
		private Text[] m_notesTexts; // 0x2C
		[SerializeField] // RVA: 0x683A2C Offset: 0x683A2C VA: 0x683A2C
		//[TooltipAttribute] // RVA: 0x683A2C Offset: 0x683A2C VA: 0x683A2C
		private Text[] m_centerSkillNameText = new Text[2]; // 0x30
		//[TooltipAttribute] // RVA: 0x683A88 Offset: 0x683A88 VA: 0x683A88
		[SerializeField] // RVA: 0x683A88 Offset: 0x683A88 VA: 0x683A88
		private Text[] m_centerSkillEffectText = new Text[2]; // 0x34
		[SerializeField] // RVA: 0x683AE4 Offset: 0x683AE4 VA: 0x683AE4
		//[TooltipAttribute] // RVA: 0x683AE4 Offset: 0x683AE4 VA: 0x683AE4
		private Text[] m_centerSkillLevelText = new Text[2]; // 0x38
		[SerializeField] // RVA: 0x683B44 Offset: 0x683B44 VA: 0x683B44
		//[TooltipAttribute] // RVA: 0x683B44 Offset: 0x683B44 VA: 0x683B44
		private GameObject[] m_centerSkill = new GameObject[2]; // 0x3C
		[SerializeField] // RVA: 0x683B9C Offset: 0x683B9C VA: 0x683B9C
		//[TooltipAttribute] // RVA: 0x683B9C Offset: 0x683B9C VA: 0x683B9C
		private GameObject[] m_centerSkillInvalid = new GameObject[2]; // 0x40
		[SerializeField] // RVA: 0x683BF8 Offset: 0x683BF8 VA: 0x683BF8
		//[TooltipAttribute] // RVA: 0x683BF8 Offset: 0x683BF8 VA: 0x683BF8
		private RawImageEx[] m_centerSkillRankImage = new RawImageEx[2]; // 0x44
		//[TooltipAttribute] // RVA: 0x683C64 Offset: 0x683C64 VA: 0x683C64
		[SerializeField] // RVA: 0x683C64 Offset: 0x683C64 VA: 0x683C64
		private GameObject[] m_centerSkillNonActive = new GameObject[2]; // 0x48
		//[TooltipAttribute] // RVA: 0x683CD0 Offset: 0x683CD0 VA: 0x683CD0
		[SerializeField] // RVA: 0x683CD0 Offset: 0x683CD0 VA: 0x683CD0
		private GameObject[] m_centerSkillRegulation = new GameObject[4]; // 0x4C
		//[TooltipAttribute] // RVA: 0x683D40 Offset: 0x683D40 VA: 0x683D40
		[SerializeField] // RVA: 0x683D40 Offset: 0x683D40 VA: 0x683D40
		private Text[] m_centerSkillRegulationText = new Text[2]; // 0x50
		[SerializeField] // RVA: 0x683DB0 Offset: 0x683DB0 VA: 0x683DB0
		//[TooltipAttribute] // RVA: 0x683DB0 Offset: 0x683DB0 VA: 0x683DB0
		private UGUIButton m_centerSkillRegulationButton; // 0x54
		[SerializeField] // RVA: 0x683E2C Offset: 0x683E2C VA: 0x683E2C
		//[TooltipAttribute] // RVA: 0x683E2C Offset: 0x683E2C VA: 0x683E2C
		private GameObject m_activeSkill; // 0x58
		[SerializeField] // RVA: 0x683E88 Offset: 0x683E88 VA: 0x683E88
		private GameObject m_activeSkillInvalid; // 0x5C
		[SerializeField] // RVA: 0x683E98 Offset: 0x683E98 VA: 0x683E98
		//[TooltipAttribute] // RVA: 0x683E98 Offset: 0x683E98 VA: 0x683E98
		private Text m_activeSkillNameText; // 0x60
		[SerializeField] // RVA: 0x683EF4 Offset: 0x683EF4 VA: 0x683EF4
		//[TooltipAttribute] // RVA: 0x683EF4 Offset: 0x683EF4 VA: 0x683EF4
		private Text m_activeSkillEffectText; // 0x64
		//[TooltipAttribute] // RVA: 0x683F54 Offset: 0x683F54 VA: 0x683F54
		[SerializeField] // RVA: 0x683F54 Offset: 0x683F54 VA: 0x683F54
		private Text m_activeSkillLevelText; // 0x68
		[SerializeField] // RVA: 0x683FB8 Offset: 0x683FB8 VA: 0x683FB8
		//[TooltipAttribute] // RVA: 0x683FB8 Offset: 0x683FB8 VA: 0x683FB8
		private RawImageEx m_activeSkillRankImage; // 0x6C
		[SerializeField] // RVA: 0x684020 Offset: 0x684020 VA: 0x684020
		private Text[] m_limitBreakText = new Text[2]; // 0x70
		[SerializeField] // RVA: 0x684030 Offset: 0x684030 VA: 0x684030
		private Text[] m_limitBreakAttrBonusText = new Text[2]; // 0x74
		[SerializeField] // RVA: 0x684040 Offset: 0x684040 VA: 0x684040
		private GameObject[] m_limitBreakAttrBonus = new GameObject[2]; // 0x78
		[SerializeField] // RVA: 0x684050 Offset: 0x684050 VA: 0x684050
		private Text[] m_limitBreakSeriesBonusText = new Text[2]; // 0x7C
		[SerializeField] // RVA: 0x684060 Offset: 0x684060 VA: 0x684060
		private GameObject[] m_limitBreakSeriesBonus = new GameObject[2]; // 0x80
		//[TooltipAttribute] // RVA: 0x684070 Offset: 0x684070 VA: 0x684070
		[SerializeField] // RVA: 0x684070 Offset: 0x684070 VA: 0x684070
		private UGUIButton m_supportButton; // 0x84
		[SerializeField] // RVA: 0x6840CC Offset: 0x6840CC VA: 0x6840CC
		//[TooltipAttribute] // RVA: 0x6840CC Offset: 0x6840CC VA: 0x6840CC
		private GameObject m_supportLock; // 0x88
		private StatusData m_baseStatus = new StatusData(); // 0x8C
		private StatusData m_addStatus = new StatusData(); // 0x90
		private StatusData m_tmpStatus = new StatusData(); // 0x94
		private StringBuilder m_strBuilder = new StringBuilder(64); // 0x98
		private UnitWindowConstant.OperationMode m_operationMode; // 0x9C
		private GCIJNCFDNON m_mainScene; // 0xA0
		private LimitOverStatusData m_limitOverStatus = new LimitOverStatusData(); // 0xA4
		private LimitOverStatusData m_tmpLimitOverStatus = new LimitOverStatusData(); // 0xA8
		private Common.ScrollText[] m_scrollTexts; // 0xAC

		public InOutAnime InOut { get { return m_inOut; } } //0xA77690
		//public CFHDKAFLNEP SubPlateResult { get; set; } // 0xB0

		// RVA: 0xA776B8 Offset: 0xA776B8 VA: 0xA776B8
		private void Awake()
		{
			transform.SetAsLastSibling();
			m_centerSkillRegulation[0].SetActive(false);
			m_centerSkillRegulation[3].SetActive(false);
			m_supportButton.ClearOnClickCallback();
			m_supportButton.AddOnClickCallback(OnShowSubPlateWindowButton);
			m_centerSkillRegulationButton.ClearOnClickCallback();
			m_centerSkillRegulationButton.AddOnClickCallback(OnShowCenterSkillDetails);
			m_scrollTexts = GetComponentsInChildren<Common.ScrollText>();
		}

		//// RVA: 0xA778EC Offset: 0xA778EC VA: 0xA778EC
		//public void SetLimitBreakValue(LimitOverStatusData status, bool isMusicSelect) { }

		//// RVA: 0xA780B8 Offset: 0xA780B8 VA: 0xA780B8
		private void OnShowCenterSkillDetails()
		{
			TodoLogger.Log(0, "OnShowCenterSkillDetails");
		}

		//// RVA: 0xA7886C Offset: 0xA7886C VA: 0xA7886C
		//private void CalcLimitBrake(JLKEOGLJNOD viewUnitData, DFKGGBMFFGB viewPlayerData, EEDKAACNBBG musicData, EAJCBFGKKFA friendData) { }

		//// RVA: 0xA78E14 Offset: 0xA78E14 VA: 0xA78E14
		//private void AdjustOverLimit(LimitOverStatusData status, GCIJNCFDNON sceneData, EEDKAACNBBG musicData) { }

		//// RVA: 0xA78FC4 Offset: 0xA78FC4 VA: 0xA78FC4
		private void OnShowSubPlateWindowButton()
		{
			TodoLogger.Log(0, "OnShowSubPlateWindowButton");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x730D9C Offset: 0x730D9C VA: 0x730D9C
		//// RVA: 0xA7903C Offset: 0xA7903C VA: 0xA7903C
		//private IEnumerator Co_ShowSubPlateWindowButton(bool isReShow = False) { }

		//// RVA: 0xA790E0 Offset: 0xA790E0 VA: 0xA790E0
		//private void SetInvalidText(bool isInvalid) { }

		//// RVA: 0xA79A40 Offset: 0xA79A40 VA: 0xA79A40
		//public void UpdateContent(DFKGGBMFFGB viewPlayerData, JLKEOGLJNOD viewUnitData, EEDKAACNBBG viewMusicData, EJKBKMBJMGL enemyData, EAJCBFGKKFA viewFriendData, UnitWindowConstant.OperationMode opMode, bool isGoDiva) { }

		//// RVA: 0xA7D6A0 Offset: 0xA7D6A0 VA: 0xA7D6A0
		//public void CalcStatus(ref StatusData baseStatus, ref StatusData addStatus, out int luck, DFKGGBMFFGB viewPlayerData, JLKEOGLJNOD unitData, EEDKAACNBBG viewMusicData, EAJCBFGKKFA viewFriendPlayerData, EJKBKMBJMGL viewEnemyData, out AEGLGBOGDHH result) { }

		//// RVA: 0xA79920 Offset: 0xA79920 VA: 0xA79920
		//private void SetInvalidSubPlate() { }

		//// RVA: 0xA7D9D0 Offset: 0xA7D9D0 VA: 0xA7D9D0
		//private void SetSubPlateParam() { }

		//// RVA: 0xA7D604 Offset: 0xA7D604 VA: 0xA7D604
		//private void ResetScrollText() { }

		// RVA: 0xA7DF00 Offset: 0xA7DF00 VA: 0xA7DF00
		public void .ctor() { }
	}
}
