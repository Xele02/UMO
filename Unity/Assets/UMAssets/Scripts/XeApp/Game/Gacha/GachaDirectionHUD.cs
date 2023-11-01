using System;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Gacha
{
	public class GachaDirectionHUD : MonoBehaviour
	{
		[SerializeField]
		private Button m_activateButton; // 0xC
		[SerializeField]
		private Button m_skipButton; // 0x10
		[SerializeField]
		private Button m_allSkipButton; // 0x14
		
		public Action onClickActivate { private get; set; } // 0x18
		public Action onClickSkip { private get; set; } // 0x1C
		public Action onClickAllSkip { private get; set; } // 0x20

		// RVA: 0x9848C8 Offset: 0x9848C8 VA: 0x9848C8
		private void Start()
		{
			m_activateButton.onClick.AddListener(() =>
			{
				//0x984D88
				if(onClickActivate != null)
					onClickActivate();
			});
			m_skipButton.onClick.AddListener(() =>
			{
				//0x984D9C
				if(onClickSkip != null)
					onClickSkip();
			});
			m_allSkipButton.onClick.AddListener(() =>
			{
				//0x984DB0
				if(onClickAllSkip != null)
					onClickAllSkip();
			});
		}

		// RVA: 0x984AB8 Offset: 0x984AB8 VA: 0x984AB8
		public void ShowActivateButton()
		{
			m_activateButton.gameObject.SetActive(true);
		}

		// RVA: 0x984B08 Offset: 0x984B08 VA: 0x984B08
		public void HideActivateButton()
		{
			m_activateButton.gameObject.SetActive(false);
		}

		// RVA: 0x984B58 Offset: 0x984B58 VA: 0x984B58
		public void ShowSkipButton()
		{
			m_skipButton.enabled = true;
			m_skipButton.targetGraphic.enabled = true;
		}

		// RVA: 0x984BD0 Offset: 0x984BD0 VA: 0x984BD0
		public void HideSkipButton()
		{
			m_skipButton.enabled = false;
			m_skipButton.targetGraphic.enabled = false;
		}

		// RVA: 0x984C48 Offset: 0x984C48 VA: 0x984C48
		public void ShowAllSkipButton()
		{
			if(m_allSkipButton.gameObject.activeSelf)
				return;
			m_allSkipButton.gameObject.SetActive(true);
		}

		// RVA: 0x984CE4 Offset: 0x984CE4 VA: 0x984CE4
		public void HideAllSkipButton()
		{
			if(!m_allSkipButton.gameObject.activeSelf)
				return;
			m_allSkipButton.gameObject.SetActive(false);
		}
	}
}
