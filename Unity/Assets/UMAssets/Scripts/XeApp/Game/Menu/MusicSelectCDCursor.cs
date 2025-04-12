using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using System.Text;
using XeSys;

namespace XeApp.Game.Menu
{
	public class MusicSelectCDCursor : LayoutLabelScriptBase
	{
		[SerializeField]
		private Text m_remainPrefix; // 0x18
		[SerializeField]
		private Text m_remainPostfix; // 0x1C
		[SerializeField]
		private Text m_endMessage; // 0x20
		[SerializeField]
		private Text m_bonusMessage; // 0x24
		[SerializeField]
		private Text m_musicRatio; // 0x28
		[SerializeField]
		private Text m_musicRankingText; // 0x2C
		[SerializeField]
		private Text m_stepCountText; // 0x30
		[SerializeField]
		private Text m_eventGoDivaExpBonudText; // 0x34
		[SerializeField]
		private Text m_eventGoDivaRankingText; // 0x38
		[SerializeField]
		private Text[] m_eventGoDivaExpTypeText; // 0x3C
		[SerializeField]
		private Text[] m_eventGoDivaExpValueText; // 0x40
		[SerializeField]
		private RawImageEx m_endPanelImage; // 0x44
		[SerializeField]
		private RawImageEx m_bonusPanelImage; // 0x48
		[SerializeField]
		private NumberBase m_playCount; // 0x4C
		[SerializeField]
		private NumberBase m_ticketCount; // 0x50
		[SerializeField]
		private NumberBase m_rankValue; // 0x54
		[SerializeField]
		private List<RawImageEx> m_itemImages; // 0x58
		[SerializeField]
		private GameObject m_newIconParent; // 0x5C
		[SerializeField]
		private MusicSelectAttrFrame m_attrFrame; // 0x60
		[SerializeField]
		private RawImageEx m_rewardMarkForScore; // 0x64
		[SerializeField]
		private RawImageEx m_rewardMarkForCombo; // 0x68
		[SerializeField]
		private RawImageEx m_rewardMarkForClearCount; // 0x6C
		[SerializeField]
		private RawImageEx m_coutingMarkImage; // 0x70
		[SerializeField]
		private List<RawImageEx> m_eventTicketImage; // 0x74
		[SerializeField]
		private RawImageEx m_frameImage; // 0x78
		[SerializeField]
		private RawImageEx m_ratioImage; // 0x7C
		private TexUVListManager m_uvMan; // 0x80
		private NewMarkIcon m_newIcon; // 0x84
		private StringBuilder m_stringBuilder; // 0x88

		// RVA: 0x166C3C8 Offset: 0x166C3C8 VA: 0x166C3C8
		public void MakeCache()
		{
			m_newIcon.Initialize(m_newIconParent);
			m_newIcon.SetActive(false);
		}

		// // RVA: 0x166C424 Offset: 0x166C424 VA: 0x166C424
		public void ReleaseCache()
		{
			m_newIcon.Release();
		}

		// // RVA: 0x166C450 Offset: 0x166C450 VA: 0x166C450
		public void SetNew(bool isNew)
		{
			m_newIcon.SetActive(isNew);
		}

		// // RVA: 0x166C484 Offset: 0x166C484 VA: 0x166C484
		public void SetAttribute(GameAttribute.Type attr)
		{
			m_attrFrame.SetAttribute(attr);
		}

		// // RVA: 0x166C4B8 Offset: 0x166C4B8 VA: 0x166C4B8
		public void SetSimulationLiveFrame()
		{
			m_attrFrame.SetSimulationLiveFrame();
		}

		// // RVA: 0x166C4E4 Offset: 0x166C4E4 VA: 0x166C4E4
		public void ShowRewardMark(bool forScore, bool forCombo, bool forClearCount)
		{
			m_attrFrame.SetRewardVisible(true);
			m_rewardMarkForScore.enabled = forScore;
			m_rewardMarkForCombo.enabled = forCombo;
			m_rewardMarkForClearCount.enabled = forClearCount;
		}

		// // RVA: 0x166C590 Offset: 0x166C590 VA: 0x166C590
		public void HideRewardMark()
		{
			m_attrFrame.SetRewardVisible(false);
			m_rewardMarkForScore.enabled = false;
			m_rewardMarkForCombo.enabled = false;
			m_rewardMarkForClearCount.enabled = false;
		}

		// // RVA: 0x166C630 Offset: 0x166C630 VA: 0x166C630
		public void SetRemainTimePrefix(string prefixLabel)
		{
			m_remainPrefix.text = prefixLabel;
		}

		// // RVA: 0x166C66C Offset: 0x166C66C VA: 0x166C66C
		public void SetRemainTimeValue(string valueLabel)
		{
			m_remainPostfix.text = valueLabel;
		}

		// // RVA: 0x166C6A8 Offset: 0x166C6A8 VA: 0x166C6A8
		public void SetDisable(bool isDisable, bool isEventEntrance/* = False*/)
		{
			m_endMessage.enabled = isDisable;
			m_endPanelImage.enabled = isDisable && !isEventEntrance;
		}

		// // RVA: 0x166C70C Offset: 0x166C70C VA: 0x166C70C
		public void SetEndMessage(string message) 
		{ 
			m_endMessage.text = message;
		}

		// // RVA: 0x166C748 Offset: 0x166C748 VA: 0x166C748
		public void SetEventBonusValue(int percent)
		{
			if(percent < 1)
			{
				m_bonusMessage.enabled = false;
				m_bonusPanelImage.enabled = false;
			}
			else
			{
				m_bonusMessage.text = MessageManager.Instance.GetMessage("menu", "music_select_event_bonus");
				m_bonusMessage.enabled = true;
				m_bonusPanelImage.enabled = true;
			}
		}

		// // RVA: 0x166C8F0 Offset: 0x166C8F0 VA: 0x166C8F0
		public void SetMusicRatio(int ratio)
		{
			m_musicRatio.text = ratio.ToString();
		}

		// // RVA: 0x166C944 Offset: 0x166C944 VA: 0x166C944
		public void SetMusicRatioVisibility(bool isVisible)
		{
			m_ratioImage.enabled = isVisible;
			m_musicRatio.enabled = isVisible;
		}

		// // RVA: 0x166C9A0 Offset: 0x166C9A0 VA: 0x166C9A0
		public void SetRemainPlayCount(int count)
		{
			m_playCount.SetNumber(count, 0);
		}

		// // RVA: 0x166C9E0 Offset: 0x166C9E0 VA: 0x166C9E0
		public void ResetEventItem()
		{
			for(int i = 0; i < m_itemImages.Count; i++)
			{
				m_itemImages[i].enabled = false;
			}
		}

		// // RVA: 0x166CAC0 Offset: 0x166CAC0 VA: 0x166CAC0
		public void ApplyEventItem(int index, IiconTexture image)
		{
			m_itemImages[index].enabled = true;
			image.Set(m_itemImages[index]);
		}

		// // RVA: 0x166CC28 Offset: 0x166CC28 VA: 0x166CC28
		public void SetEventTicket(IiconTexture image)
		{
			for(int i = 0; i < m_eventTicketImage.Count; i++)
			{
				image.Set(m_eventTicketImage[i]);
			}
			m_frameImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData("s_m_cd_eve_tkt_bg"));
		}

		// // RVA: 0x166CE38 Offset: 0x166CE38 VA: 0x166CE38
		public void EventTicketEnable(bool _enable)
		{
			for(int i = 0; i < m_eventTicketImage.Count; i++)
			{
				m_eventTicketImage[i].enabled = _enable;
			}
		}

		// // RVA: 0x166CF1C Offset: 0x166CF1C VA: 0x166CF1C
		public void SetEventItem(IiconTexture image)
		{
			if(image != null)
			{
				for(int i = 0; i < m_eventTicketImage.Count; i++)
				{
					image.Set(m_eventTicketImage[i]);
				}
			}
			m_frameImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData("s_m_cd_simu_item_bg"));
		}

		// // RVA: 0x166D124 Offset: 0x166D124 VA: 0x166D124
		public void SetTicketCount(int count)
		{
			m_ticketCount.SetNumber(count, 0);
		}

		// // RVA: 0x166D164 Offset: 0x166D164 VA: 0x166D164
		public void SetRankValue(int rank)
		{
			if(rank > 0)
				m_rankValue.SetNumber(rank, 0);
			else
				m_rankValue.SetDigitLength(10, true);
		}

		// // RVA: 0x166D1C8 Offset: 0x166D1C8 VA: 0x166D1C8
		public void SetEventMusicRank(int rank)
		{
			if(rank > 0)
			{
				m_musicRankingText.text = rank.ToString();
			}
			else
			{
				m_musicRankingText.text = TextConstant.InvalidText;
			}
		}

		// // RVA: 0x166D2DC Offset: 0x166D2DC VA: 0x166D2DC
		public void SetStepCount(int count)
		{
			if(count > 0)
			{
				m_stepCountText.text = count.ToString();
			}
			else
			{
				m_stepCountText.text = TextConstant.InvalidText;
			}
		}

		// // RVA: 0x166D3F0 Offset: 0x166D3F0 VA: 0x166D3F0
		public void EnableCoutingMark(bool isEnable)
		{
			m_coutingMarkImage.enabled = isEnable;
		}

		// // RVA: 0x166D424 Offset: 0x166D424 VA: 0x166D424
		public void SetEventGoDivaRank(int rank)
		{
			if(rank > 0)
			{
				m_eventGoDivaRankingText.text = rank.ToString();
			}
			else
			{
				m_eventGoDivaRankingText.text = TextConstant.InvalidText;
			}
		}

		// // RVA: 0x166D538 Offset: 0x166D538 VA: 0x166D538
		public void SetEventGoDivaExpBonus(float bonus)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_eventGoDivaExpBonudText.text = string.Format(bk.GetMessageByLabel("godiva_music_select_exp_bonus"), bonus);
		}

		// // RVA: 0x166D670 Offset: 0x166D670 VA: 0x166D670
		public void SetEventGoDivaExp(int expValue)
		{
			for(int i = 0; i < m_eventGoDivaExpValueText.Length; i++)
			{
				m_eventGoDivaExpValueText[i].text = expValue.ToString();
			}
		}

		// RVA: 0x166D710 Offset: 0x166D710 VA: 0x166D710 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_uvMan = uvMan;
			m_newIcon = new NewMarkIcon();
			m_stringBuilder = new StringBuilder(32);
			if(m_eventGoDivaExpTypeText != null && m_eventGoDivaExpTypeText.Length > 3)
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				if(m_eventGoDivaExpTypeText[0] != null)
				{
					m_eventGoDivaExpTypeText[0].text = bk.GetMessageByLabel("sel_music_godiva_exp_type_soul");
				}
				if(m_eventGoDivaExpTypeText[1] != null)
				{
					m_eventGoDivaExpTypeText[1].text = bk.GetMessageByLabel("sel_music_godiva_exp_type_voice");
				}
				if(m_eventGoDivaExpTypeText[2] != null)
				{
					m_eventGoDivaExpTypeText[2].text = bk.GetMessageByLabel("sel_music_godiva_exp_type_charm");
				}
				if(m_eventGoDivaExpTypeText[3] != null)
				{
					m_eventGoDivaExpTypeText[3].text = bk.GetMessageByLabel("sel_music_godiva_exp_type_all");
				}
			}
			Loaded();
			return true;
		}
	}
}
