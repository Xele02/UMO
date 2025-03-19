using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeSys;
using System;

namespace XeApp.Game.Menu
{
	public class EpisodeBonusPlateScrollContent : SwapScrollListContent
	{
		public class ShowEpisodeBonusAnimationInfo
		{
			public bool isDisplay; // 0x8
			public bool isHave; // 0x9
			public bool isAvailable; // 0xA
			public bool isEvo; // 0xB
			public bool isAssistEvo; // 0xC
			public bool isAssist; // 0xD
			public int bonusBefore; // 0x10
			public int bonusAfter; // 0x14
		}

		[SerializeField]
		private RawImageEx m_sceneIconImage; // 0x20
		[SerializeField]
		private Text m_bonusUpText; // 0x24
		[SerializeField]
		private Text m_bonusText; // 0x28
		[SerializeField]
		private Text m_unownedText; // 0x2C
		[SerializeField]
		private Text m_assistText; // 0x30
		private AbsoluteLayout m_plateAnimation; // 0x34
		private AbsoluteLayout m_plateBonusAnimation; // 0x38
		private AbsoluteLayout m_plateStateTextAnimation; // 0x3C
		private short m_sceneId; // 0x40
		private short m_evolveId; // 0x42

		// RVA: 0x127E9F8 Offset: 0x127E9F8 VA: 0x127E9F8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_plateAnimation = layout.FindViewById("root_pop_ep_plate_layout_root") as AbsoluteLayout;
			m_plateBonusAnimation = layout.FindViewByExId("swtbl_plate_frame_swtbl_pop_ep_up") as AbsoluteLayout;
			m_plateStateTextAnimation = layout.FindViewByExId("swtbl_plate_frame_pop_ep_no") as AbsoluteLayout;
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}

		// // RVA: 0x127EBD4 Offset: 0x127EBD4 VA: 0x127EBD4
		private void SetPlateTexture(GCIJNCFDNON_SceneInfo sceneData, ShowEpisodeBonusAnimationInfo episodeInfo)
		{
			int sceneId = sceneData.BCCHOBPJJKE_SceneId;
			int evo = episodeInfo.isEvo ? 2 : 1;
			if(episodeInfo.isAssist && episodeInfo.isAvailable)
				evo = episodeInfo.isAssistEvo ? 2 : 1;
			m_sceneId = (short)sceneId;
			m_evolveId = (short)evo;
			MenuScene.Instance.SceneIconCache.SetLoadingTexture(m_sceneIconImage);
			MenuScene.Instance.SceneIconCache.Load(sceneId, evo, (IiconTexture texture) =>
			{
				//0x127F4C4
				if(m_sceneId != sceneId)
					return;
				if(m_evolveId != evo)
					return;
				texture.Set(m_sceneIconImage);
			});
		}

		// // RVA: 0x127EE00 Offset: 0x127EE00 VA: 0x127EE00
		private void SetBonusValue(GCIJNCFDNON_SceneInfo sceneData, ShowEpisodeBonusAnimationInfo episodeInfo)
		{
			if(!episodeInfo.isAssist)
			{
				if(!episodeInfo.isAvailable)
				{
					m_plateAnimation.StartAllAnimGoStop(!episodeInfo.isHave && !episodeInfo.isAssist ? "03" : "02");
					m_bonusText.text = string.Format("+{0}%", episodeInfo.isEvo ? episodeInfo.bonusAfter : episodeInfo.bonusBefore);
				}
				else
				{
					m_plateAnimation.StartAllAnimGoStop("01");
					m_bonusText.text = string.Format("+{0}%", episodeInfo.isEvo ? episodeInfo.bonusAfter : episodeInfo.bonusBefore);
				}
			}
			else
			{
				if(!episodeInfo.isAvailable)
				{
					m_plateAnimation.StartAllAnimGoStop(!episodeInfo.isHave && !episodeInfo.isAssist ? "03" : "02");
					m_bonusText.text = string.Format("+{0}%", episodeInfo.isEvo ? episodeInfo.bonusAfter : episodeInfo.bonusBefore);
				}
				else
				{
					m_plateAnimation.StartAllAnimGoStop("01");
					m_bonusText.text = string.Format("+{0}%", episodeInfo.isAssistEvo ? episodeInfo.bonusAfter : episodeInfo.bonusBefore);
				}
			}
		}

		// // RVA: 0x127EFC0 Offset: 0x127EFC0 VA: 0x127EFC0
		private void SetBonusAnimation(GCIJNCFDNON_SceneInfo sceneData, ShowEpisodeBonusAnimationInfo episodeInfo)
		{
			if((episodeInfo.bonusAfter - episodeInfo.bonusBefore) > 0 && !episodeInfo.isEvo && !episodeInfo.isAssistEvo)
			{
				m_plateBonusAnimation.StartAllAnimGoStop("01");
				m_bonusUpText.text = string.Format(MessageManager.Instance.GetMessage("menu", "popup_episodebonus_evo_bonus"), episodeInfo.bonusAfter);
			}
			else
			{
				m_plateBonusAnimation.StartAllAnimGoStop("02");
			}
		}

		// // RVA: 0x127F188 Offset: 0x127F188 VA: 0x127F188
		private void SetStateTextAnimation(GCIJNCFDNON_SceneInfo sceneData, ShowEpisodeBonusAnimationInfo episodeInfo)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(!episodeInfo.isAvailable)
			{
				if(!episodeInfo.isHave)
				{
					m_unownedText.text = string.Format(bk.GetMessageByLabel("not_possessed"), Array.Empty<object>());
					m_plateStateTextAnimation.StartAllAnimGoStop("01");
				}
				else
				{
					m_plateStateTextAnimation.StartAllAnimGoStop("03");
				}
			}
			else
			{
				if(!episodeInfo.isAssist)
				{
					m_assistText.text = bk.GetMessageByLabel("episode_available");
					m_plateStateTextAnimation.StartAllAnimGoStop("02");
				}
				else
				{
					m_assistText.text = bk.GetMessageByLabel("episode_assist");
					m_plateStateTextAnimation.StartAllAnimGoStop("02");
				}
			}
		}

		// RVA: 0x127F480 Offset: 0x127F480 VA: 0x127F480
		public void UpdateContent(GCIJNCFDNON_SceneInfo sceneData, ShowEpisodeBonusAnimationInfo episodeInfo)
		{
			SetPlateTexture(sceneData, episodeInfo);
			SetBonusValue(sceneData, episodeInfo);
			SetBonusAnimation(sceneData, episodeInfo);
			SetStateTextAnimation(sceneData, episodeInfo);
		}
	}
}
