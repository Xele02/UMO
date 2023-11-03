using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class GachaRateListWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_textContent; // 0x14
		[SerializeField]
		private ActionButton m_buttonPrev; // 0x18
		[SerializeField]
		private ActionButton m_buttonNext; // 0x1C
		[SerializeField]
		private RawImageEx m_imageNext; // 0x20
		[SerializeField]
		private ScrollRect m_scrollRect; // 0x24
		private KOPCFBCDBPC m_stepData; // 0x28
		private int m_stepIndex = -1; // 0x2C

		public RectTransform scrollContent { get { return m_scrollRect.content; } } //0xEE5898
		public Action<int> OnClickStepButton { get; set; } // 0x30

		// RVA: 0xEE58D4 Offset: 0xEE58D4 VA: 0xEE58D4
		public void Initialize()
		{
			m_stepData = null;
			m_stepIndex = -1;
		}

		// RVA: 0xEE58E8 Offset: 0xEE58E8 VA: 0xEE58E8
		public void SetStatus(KOPCFBCDBPC data)
		{
			m_stepData = data;
			if(m_stepIndex < 0)
			{
				m_stepIndex = data.LKHAAGIJEPG_PlayerStatus.DBNAGGGJDAB_CurrentStepIndex;
			}
			m_buttonPrev.Disable = m_stepIndex < 2;
			m_buttonNext.Disable = m_stepData.BMFEGOMNECF_Step.Count <= m_stepIndex;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textContent.text = string.Format(bk.GetMessageByLabel("popup_gacha_rate_stepup"), m_stepIndex);
		}

		// RVA: 0xEE5B00 Offset: 0xEE5B00 VA: 0xEE5B00
		public void SetActive(bool active)
		{
			gameObject.SetActive(active);
		}

		// RVA: 0xEE5B3C Offset: 0xEE5B3C VA: 0xEE5B3C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_imageNext.uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("proba_btn_fnt_02"));
			m_buttonPrev.AddOnClickCallback(() =>
			{
				//0xEE5D08
				m_stepIndex--;
				if (OnClickStepButton != null)
					OnClickStepButton(m_stepIndex);
			});
			m_buttonNext.AddOnClickCallback(() =>
			{
				//0xEE5D80
				m_stepIndex++;
				if (OnClickStepButton != null)
					OnClickStepButton(m_stepIndex);
			});
			Loaded();
			return true;
		}
	}
}
