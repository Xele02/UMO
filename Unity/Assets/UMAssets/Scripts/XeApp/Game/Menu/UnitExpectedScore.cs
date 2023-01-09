using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class UnitExpectedScore : LayoutUGUIScriptBase
	{
		[SerializeField]
		private string m_layoutRankId = "swtbl_rank_icon"; // 0x14
		private const int GaugeMax = 500;
		private AbsoluteLayout[] m_layoutParamGauge; // 0x18
		private AbsoluteLayout[] m_layoutRankGauge; // 0x1C
		private AbsoluteLayout m_layoutRank; // 0x20
		private ResultScoreRank.Type m_scoreRank; // 0x24
		private float m_gaugeRatio; // 0x28
		private float[] m_rankPosition; // 0x2C
		private int[] m_scoreParams; // 0x30
		private float m_viewRatio; // 0x34
		private readonly string[] s_ParamIdTable = new string[10] {
			"gauge_01_base", "gauge_02_isyou", "gauge_03_zokusei", "gauge_08_combo",
			"gauge_05_shien", "gauge_04_cskill", "gauge_06_lskill", "gauge_07_askill",
			"gauge_09_notes", "gauge_10_leaf"
		}; // 0x38
		private readonly string[] s_RankIdTable = new string[5] {
			"", "gauge_scr_b", "gauge_scr_a", "gauge_scr_s", "gauge_scr_ss"
		}; // 0x3C
		private readonly int[] s_RankFrameTable = new int[5] {
			0, 120, 180, 240, 300
		}; // 0x40

		public static float defaultAddGaugeRatio { get { return 0.1f; } } //0x1245CE4
		public static float baseGaugeRatio { get; set; } // 0x0
		public static float baseGaugeScale { get; set; } // 0x4

		//// RVA: 0x1245E90 Offset: 0x1245E90 VA: 0x1245E90
		public void SetScore(ResultScoreRank.Type scoreRank, float gaugeRatio, float[] rankPosition, int[] scoreParams, float viewRatio = 1)
		{
			m_gaugeRatio = gaugeRatio;
			m_scoreRank = scoreRank;
			m_rankPosition = rankPosition;
			m_scoreParams = scoreParams;
			m_viewRatio = viewRatio;
			float f = 0;
			for(int i = 0; i < scoreParams.Length; i++)
			{
				f += scoreParams[i];
			}
			float f2 = gaugeRatio / viewRatio;
			int[] vali = new int[m_layoutParamGauge.Length];
			float f3 = 0;
			for(int i = 0; i < vali.Length && i < scoreParams.Length; i++)
			{
				if(scoreParams[i] < 1)
					vali[i] = 0;
				else
				{
					float f4 = scoreParams[i] / (f / f2);
					vali[i] = (int)Mathf.Clamp((f3 + f4) * 500, 0, 500);
					int s = (int)Mathf.Clamp(f3 * 500, 0, 500);
					f3 += f4;
					if(0 <= f4)
					{
						for(int j = i; j >= 0 && vali[i] == s; j--)
						{
							if(j - 1 < 0)
								break;
							vali[j - 1] = Mathf.Clamp(vali[j - 1] - 1, 0, 500);
						}
					}
				}
			}
			for(int i = 0; i < m_layoutParamGauge.Length; i++)
			{
				int val = (int)(vali[i] * 2);
				m_layoutParamGauge[i].StartAnimGoStop(val, val);
			}
			for(int i = 1; i < m_layoutRankGauge.Length; i++)
			{
				int val = (int)(rankPosition[i] * 500 * 2 / viewRatio);
				m_layoutRankGauge[i].StartAnimGoStop(val, val);
			}
			SetScoreRank(scoreRank);
		}

		//// RVA: 0x12464DC Offset: 0x12464DC VA: 0x12464DC
		public void UpdateScore(float viewRatio)
		{
			if(m_scoreParams == null)
				return;
			m_viewRatio = viewRatio;
			SetScore(m_scoreRank, m_gaugeRatio, m_rankPosition, m_scoreParams, viewRatio);
		}

		//// RVA: 0x12463A0 Offset: 0x12463A0 VA: 0x12463A0
		public void SetScoreRank(ResultScoreRank.Type scoreRank)
		{
			switch(scoreRank)
			{
				case ResultScoreRank.Type.C:
					m_layoutRank.StartChildrenAnimGoStop("01");
					break;
				case ResultScoreRank.Type.B:
					m_layoutRank.StartChildrenAnimGoStop("02");
					break;
				case ResultScoreRank.Type.A:
					m_layoutRank.StartChildrenAnimGoStop("03");
					break;
				case ResultScoreRank.Type.S:
					m_layoutRank.StartChildrenAnimGoStop("04");
					break;
				case ResultScoreRank.Type.SS:
					m_layoutRank.StartChildrenAnimGoStop("05");
					break;
			}
		}

		//// RVA: 0x1246518 Offset: 0x1246518 VA: 0x1246518
		public float UpdateScoreGaugeRatio(Text gaugeText, ButtonBase plusButton, ButtonBase minusButton)
		{
			int a = Mathf.Clamp(Mathf.RoundToInt(baseGaugeScale * 10) * 10, -50, 50);
			if(gaugeText != null)
			{
				if(a == 0)
				{
					gaugeText.text = string.Format("{0}\n%", string.Format("StringLiteral_20369{0}", 0));
				}
				else
				{
					gaugeText.text = string.Format("{0}\n%", a.ToString("+#;-#;"));
				}
			}
			if(plusButton != null)
			{
				plusButton.Disable = a > 49;
			}
			if(minusButton != null)
			{
				minusButton.Disable = a < -49;
			}
			return Mathf.Max(0.0001f, defaultAddGaugeRatio + baseGaugeRatio);
		}

		//// RVA: 0x12468F4 Offset: 0x12468F4 VA: 0x12468F4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			RectTransform rt = transform as RectTransform;
			LayoutUGUIRuntime runtime = GetComponentInParent<LayoutUGUIRuntime>();
			AbsoluteLayout viewbase = runtime.FindViewBase(rt) as AbsoluteLayout;
			m_layoutParamGauge = new AbsoluteLayout[10];
			for(int i = 0; i < 10; i++)
			{
				m_layoutParamGauge[i] = viewbase.FindViewById(s_ParamIdTable[i]) as AbsoluteLayout;
			}
			m_layoutRankGauge = new AbsoluteLayout[5];
			for(int i = 1; i < 5; i++)
			{
				m_layoutRankGauge[i] = layout.FindViewById(s_RankIdTable[i]) as AbsoluteLayout;
				m_layoutRankGauge[i].StartAnimGoStop(s_RankFrameTable[i], s_RankFrameTable[i]);
			}
			m_layoutRank = layout.FindViewById(m_layoutRankId) as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
