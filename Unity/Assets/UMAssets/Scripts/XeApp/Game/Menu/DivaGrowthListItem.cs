using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using System.Text;
using mcrs;
using XeSys;

namespace XeApp.Game.Menu
{
	public class DivaGrowthListItem : SwapScrollListContent
	{
		public enum GaugeState
		{
			Open = 0,
			Max = 1,
			Lock = 2,
		}

		[SerializeField]
		private Text m_titleText; // 0x20
		[SerializeField]
		private Text m_unlockTermsText; // 0x24
		[SerializeField]
		private ActionButton m_conditionsButton; // 0x28
		[SerializeField]
		private NumberBase[] m_skillLevel; // 0x2C
		[SerializeField]
		private RawImageEx m_complete; // 0x30
		[SerializeField]
		private RawImageEx m_conditionsImage; // 0x34
		[SerializeField]
		private NumberBase m_numerator; // 0x38
		[SerializeField]
		private NumberBase m_denominator; // 0x3C
		private AbsoluteLayout m_gaugeAnimeLayout; // 0x40
		private string m_conditionText; // 0x44
		private static StringBuilder m_strBuilder = new StringBuilder(64); // 0x0

		//// RVA: 0x17DF148 Offset: 0x17DF148 VA: 0x17DF148 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_gaugeAnimeLayout = layout.FindViewByExId("swtbl_chk_diva_met_sw_chk_diva_met01_anim") as AbsoluteLayout;
			m_conditionsButton.AddOnClickCallback(OnShowUnLockConditionsPopup);
			ClearLoadedCallback();
			return true;
		}

		//// RVA: 0x17DF27C Offset: 0x17DF27C VA: 0x17DF27C
		public void SetMusicTitle(string title)
		{
			m_titleText.horizontalOverflow = HorizontalWrapMode.Wrap;
			m_titleText.verticalOverflow = VerticalWrapMode.Truncate;
			m_titleText.resizeTextForBestFit = true;
			m_titleText.text = title;
		}

		//// RVA: 0x17DF328 Offset: 0x17DF328 VA: 0x17DF328
		public void SetUnlockTerms(string text)
		{
			m_conditionText = text;
			m_conditionsImage.enabled = SetConditionsText(m_unlockTermsText, text);
			m_conditionsButton.Disable = !m_conditionsImage.enabled;
		}

		//// RVA: 0x17DF9E8 Offset: 0x17DF9E8 VA: 0x17DF9E8
		public void SetLevel(int level)
		{
			for(int i = 0; i < m_skillLevel.Length; i++)
			{
				m_skillLevel[i].SetNumber(level, 0);
			}
		}

		//// RVA: 0x17DFA8C Offset: 0x17DFA8C VA: 0x17DFA8C
		public void SetExpNumerator(int value)
		{
			m_numerator.SetNumber(value, 0);
		}

		//// RVA: 0x17DFACC Offset: 0x17DFACC VA: 0x17DFACC
		public void SetExpDenominator(int value)
		{
			m_denominator.SetNumber(value, 0);
		}

		//// RVA: 0x17DFB0C Offset: 0x17DFB0C VA: 0x17DFB0C
		public void SetComplete(bool isComplete)
		{
			m_unlockTermsText.enabled = !isComplete;
			m_complete.enabled = isComplete;
		}

		//// RVA: 0x17DFB68 Offset: 0x17DFB68 VA: 0x17DFB68
		public void SetGaugeState(GaugeState state)
		{
			m_gaugeAnimeLayout.StartSiblingAnimGoStop(((int)state + 1).ToString("D2"));
		}

		//// RVA: 0x17DFC0C Offset: 0x17DFC0C VA: 0x17DFC0C
		public void SetGaugeValue(float value)
		{
			m_gaugeAnimeLayout.StartChildrenAnimGoStop(Mathf.RoundToInt(value * 100), Mathf.RoundToInt(value * 100));
		}

		//// RVA: 0x17DF404 Offset: 0x17DF404 VA: 0x17DF404
		public static bool SetConditionsText(Text text, string conditionText)
		{
			m_strBuilder.Clear();
			string str = conditionText.Replace("\n", "");
			Vector2 s = text.rectTransform.sizeDelta;
			TextGenerationSettings gsetting = text.GetGenerationSettings(s);
			for(int i = 0; i < str.Length; i++)
			{
				m_strBuilder.Append(str[i]);
				float w = text.cachedTextGenerator.GetPreferredWidth(m_strBuilder.ToString(), gsetting);
				if(s.x <= w / gsetting.scaleFactor )
				{
					m_strBuilder.Remove(i - 2, 2);
					m_strBuilder.Append(JpStringLiterals.StringLiteral_12038);
					break;
				}
			}
			text.text = m_strBuilder.ToString();
			return str.Length != m_strBuilder.Length;
		}

		//// RVA: 0x17DFC58 Offset: 0x17DFC58 VA: 0x17DFC58
		private void OnShowUnLockConditionsPopup()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("growth_popup_title_01"), SizeType.Small, 
				m_conditionText, new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				}, false, true), null, null, null, null);
		}
	}
}
