using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using mcrs;

namespace XeApp.Game.Menu
{
	public class SetDeckExpectedScoreGauge : MonoBehaviour
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x680F34 Offset: 0x680F34 VA: 0x680F34
		//[TooltipAttribute] // RVA: 0x680F34 Offset: 0x680F34 VA: 0x680F34
		private UGUIRepeatButton m_minusButton; // 0xC
		//[TooltipAttribute] // RVA: 0x680FAC Offset: 0x680FAC VA: 0x680FAC
		[SerializeField]
		private UGUIRepeatButton m_plusButton; // 0x10
		//[TooltipAttribute] // RVA: 0x680FFC Offset: 0x680FFC VA: 0x680FFC
		[SerializeField]
		private Text m_scaleText; // 0x14
		//[TooltipAttribute] // RVA: 0x681058 Offset: 0x681058 VA: 0x681058
		[SerializeField]
		private List<UGUIGauge> m_scoreGauges; // 0x18
		//[TooltipAttribute] // RVA: 0x6810B0 Offset: 0x6810B0 VA: 0x6810B0
		[SerializeField]
		private List<UGUIGauge> m_rankGauges; // 0x1C
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x681108 Offset: 0x681108 VA: 0x681108
		private Image m_rankImage; // 0x20
		//[HeaderAttribute] // RVA: 0x681158 Offset: 0x681158 VA: 0x681158
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x681158 Offset: 0x681158 VA: 0x681158
		private List<Sprite> m_rankSprites; // 0x24
		public Action OnClickMinusButton; // 0x28
		public Action OnClickPlusButton; // 0x2C
		private ResultScoreRank.Type m_scoreRank; // 0x30
		private float m_gaugeRatio; // 0x34
		private float[] m_rankPosition; // 0x38
		private int[] m_scoreParams; // 0x3C
		private float m_viewRatio; // 0x40

		//public static float DefaultAddGaugeRatio { get; } 0xA6CBAC
		//public static float BaseGaugeRatio { get; set; } 0xA6CBB4 0xA6CBBC
		//public static float BaseGaugeScale { get; set; } 0xA6CBC4 0xA6CBCC

		// RVA: 0xA6CBD4 Offset: 0xA6CBD4 VA: 0xA6CBD4
		private void Awake()
		{
			if(m_plusButton != null)
			{
				m_plusButton.AddOnClickCallback(OnClickPlusButtonFunc);
				m_plusButton.AddOnRepeatCallback(OnClickPlusButtonFunc);
			}
			if(m_minusButton != null)
			{
				m_minusButton.AddOnClickCallback(OnClickMinusButtonFunc);
				m_minusButton.AddOnRepeatCallback(OnClickMinusButtonFunc);
			}
		}

		//// RVA: 0xA6CE20 Offset: 0xA6CE20 VA: 0xA6CE20
		public void UpdateBaseGaugeRatio()
		{
			UnitExpectedScore.baseGaugeRatio = Mathf.CeilToInt((IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA("score_gauge_rate_margin", 10) * 0.01f + CMMKCEPBIHI.FDLECNKJCGG_GaugeRatio) * 10.0f) / 10.0f;
			UnitExpectedScore.baseGaugeScale = 0;
		}

		//// RVA: 0xA6CFD0 Offset: 0xA6CFD0 VA: 0xA6CFD0
		public void Set(ResultScoreRank.Type scoreRank, float gaugeRatio, float[] rankPosition, int[] scoreParams)
		{
			float viewRatio = UpdateScoreGaugeRatio(m_scaleText, m_plusButton, m_minusButton);
			SetScore(scoreRank, gaugeRatio, rankPosition, scoreParams, viewRatio);
		}

		//// RVA: 0xA6D978 Offset: 0xA6D978 VA: 0xA6D978
		public void UpdateScore()
		{
			if (m_scoreParams == null)
				return;
			Set(m_scoreRank, m_gaugeRatio, m_rankPosition, m_scoreParams);
		}

		//// RVA: 0xA6D334 Offset: 0xA6D334 VA: 0xA6D334
		public void SetScore(ResultScoreRank.Type scoreRank, float gaugeRatio, float[] rankPosition, int[] scoreParams, float viewRatio)
		{
			m_gaugeRatio = gaugeRatio;
			m_scoreRank = scoreRank;
			m_rankPosition = rankPosition;
			m_viewRatio = viewRatio;
			m_scoreParams = scoreParams;
			float t = 0;
			for(int i = 0; i < scoreParams.Length; i++)
			{
				t += scoreParams[i];
			}
			int[] vals = new int[m_scoreGauges.Count];
			float r = gaugeRatio / m_viewRatio;
			float f2 = 0;
			for(int i = 0; i < scoreParams.Length && i < vals.Length; i++)
			{
				if(scoreParams[i] < 1)
				{
					vals[i] = 0;
				}
				else
				{
					float v = scoreParams[i] / (t / r);
					float max = m_scoreGauges[i].MaxValue * 0.5f;
					vals[i] = (int)(Mathf.Clamp(max * (f2 + v), 0, max));
					float v2 = Mathf.Clamp(f2 * max, 0, max);
					f2 += v;
					if (v > 0)
					{
						if(vals[i] == (int)(v2))
						{
							for(int j = i; j >= 0; j--)
							{
								if (j - 1 < 0)
									break;
								vals[j - 1] = Mathf.Clamp(vals[j - 1] - 1, 0, (int)max);
							}
						}
					}
				}
			}
			for(int i = 0; i < m_scoreGauges.Count; i++)
			{
				m_scoreGauges[i].CurrentValue = vals[i] * 2;
			}
			for(int i = 1; i < m_rankGauges.Count; i++)
			{
				float f = m_rankGauges[i].MaxValue * 0.5f * rankPosition[i];
				m_rankGauges[i].CurrentValue = (int)((f + f) / m_viewRatio);
			}
			SetScoreRank(scoreRank);
		}

		//// RVA: 0xA6DA58 Offset: 0xA6DA58 VA: 0xA6DA58
		//public void UpdateScore(float viewRatio) { }

		//// RVA: 0xA6D024 Offset: 0xA6D024 VA: 0xA6D024
		public float UpdateScoreGaugeRatio(Text gaugeText, ButtonBase plusButton, ButtonBase minusButton)
		{
			int f = Mathf.Clamp(Mathf.RoundToInt(UnitExpectedScore.baseGaugeScale * 10) * 10, -50, 50);
			if(gaugeText != null)
			{
				gaugeText.text = string.Format("{0}\n%", f == 0 ? string.Format(JpStringLiterals.StringLiteral_20369, 0) : f.ToString("+#;-#;"));
			}
			if(plusButton != null)
			{
				plusButton.Disable = f > 49;
			}
			if(minusButton != null)
			{
				minusButton.Disable = f < -49;
			}
			return Mathf.Max(0.0001f, UnitExpectedScore.baseGaugeRatio + UnitExpectedScore.baseGaugeScale);
		}

		//// RVA: 0xA6D9A8 Offset: 0xA6D9A8 VA: 0xA6D9A8
		private void SetScoreRank(ResultScoreRank.Type rank)
		{
			if (rank > ResultScoreRank.Type.SS)
				return;
			m_rankImage.sprite = m_rankSprites[(int)rank];
		}

		//// RVA: 0xA6DA90 Offset: 0xA6DA90 VA: 0xA6DA90
		private void OnClickPlusButtonFunc()
		{
			if (OnClickPlusButton != null)
				OnClickPlusButton();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			UnitExpectedScore.baseGaugeScale += UnitExpectedScore.defaultAddGaugeRatio;
			UpdateScore();
		}

		//// RVA: 0xA6DB38 Offset: 0xA6DB38 VA: 0xA6DB38
		private void OnClickMinusButtonFunc()
		{
			if (OnClickMinusButton != null)
				OnClickMinusButton();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			UnitExpectedScore.baseGaugeScale -= UnitExpectedScore.defaultAddGaugeRatio;
			UpdateScore();
		}
	}
}
