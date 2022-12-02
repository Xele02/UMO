using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class UnitExpectedScore : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		
		[SerializeField]
		private string m_layoutRankId; // 0x14
		//private const int GaugeMax = 500;
		//private AbsoluteLayout[] m_layoutParamGauge; // 0x18
		//private AbsoluteLayout[] m_layoutRankGauge; // 0x1C
		//private AbsoluteLayout m_layoutRank; // 0x20
		//private ResultScoreRank.Type m_scoreRank; // 0x24
		//private float m_gaugeRatio; // 0x28
		//private float[] m_rankPosition; // 0x2C
		//private int[] m_scoreParams; // 0x30
		//private float m_viewRatio; // 0x34
		private readonly string[] s_ParamIdTable; // 0x38
		private readonly string[] s_RankIdTable; // 0x3C
		private readonly int[] s_RankFrameTable; // 0x40

		public static float defaultAddGaugeRatio { get { return 0.1f; } } //0x1245CE4
		public static float baseGaugeRatio { get; set; } // 0x0
		public static float baseGaugeScale { get; set; } // 0x4

		//// RVA: 0x1245E90 Offset: 0x1245E90 VA: 0x1245E90
		//public void SetScore(ResultScoreRank.Type scoreRank, float gaugeRatio, float[] rankPosition, int[] scoreParams, float viewRatio = 1) { }

		//// RVA: 0x12464DC Offset: 0x12464DC VA: 0x12464DC
		//public void UpdateScore(float viewRatio) { }

		//// RVA: 0x12463A0 Offset: 0x12463A0 VA: 0x12463A0
		//public void SetScoreRank(ResultScoreRank.Type scoreRank) { }

		//// RVA: 0x1246518 Offset: 0x1246518 VA: 0x1246518
		//public float UpdateScoreGaugeRatio(Text gaugeText, ButtonBase plusButton, ButtonBase minusButton) { }

		//// RVA: 0x12468F4 Offset: 0x12468F4 VA: 0x12468F4 Slot: 5
		//public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan) { }

		//// RVA: 0x1246E84 Offset: 0x1246E84 VA: 0x1246E84
		//public void .ctor() { }
	}
}
