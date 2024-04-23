using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupRewardEvResultBannerLayout : FlexibleListItemLayout
	{
		private RawImageEx m_BannerImage; // 0x18
		private RawImageEx m_JacketImage; // 0x1C
		private RawImageEx m_JacketImage_EventHiScore; // 0x20
		private RawImageEx m_divaIcon; // 0x24
		private Text m_rankingText; // 0x28
		private Text m_musicText; // 0x2C
		private Text m_musicText_EventHiScore; // 0x30
		private Text m_descText; // 0x34
		private int m_eventId; // 0x38
		private int m_coverId; // 0x3C
		private int m_divaId; // 0x40
		private AbsoluteLayout m_changeLayout; // 0x44

		// RVA: 0x1142B48 Offset: 0x1142B48 VA: 0x1142B48 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			LayoutUGUIRuntime l = GetComponent<LayoutUGUIRuntime>();
			RawImageEx[] imgs = l.GetComponentsInChildren<RawImageEx>(true);
			m_BannerImage = imgs.Where((RawImageEx _) =>
			{
				//0x1143ED0
				return _.name == "swtexc_cmn_bnr_list_001 (ImageView)";
			}).First();
			m_JacketImage = imgs.Where((RawImageEx _) =>
			{
				//0x1143F50
				return _.name == "swtexc_cmn_cd (ImageView)";
			}).First();
			m_JacketImage_EventHiScore = imgs.Where((RawImageEx _) =>
			{
				//0x1143FD0
				return _.name == "swtexc_cmn_cd_2 (ImageView)";
			}).First();
			m_divaIcon = imgs.Where((RawImageEx _) =>
			{
				//0x1144050
				return _.name == "cmn_chara_icon (ImageView)";
			}).First();
			Text[] txts = l.GetComponentsInChildren<Text>();
			m_musicText = txts.Where((Text _) =>
			{
				//0x11440D0
				return _.name == "music (TextView)";
			}).First();
			m_musicText_EventHiScore = txts.Where((Text _) =>
			{
				//0x1144150
				return _.name == "music_2 (TextView)";
			}).First();
			m_rankingText = txts.Where((Text _) =>
			{
				//0x11441D0
				return _.name == "rankingeve (TextView)";
			}).First();
			m_descText = txts.Where((Text _) =>
			{
				//0x1144250
				return _.name == "desc (TextView)";
			}).First();
			m_changeLayout = layout.FindViewByExId("root_pop_reward_ev_bnr_sw_pop_reward_ev_bnr") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// RVA: 0x1143520 Offset: 0x1143520 VA: 0x1143520
		public void Set(PopupRewardEvResult.ViewRewardEvResultData data, PopupRewardEvResult.Type rewardType, int divaId)
		{
			m_rankingText.text = data.EventName;
			m_musicText.text = data.MusicName;
			m_musicText_EventHiScore.text = data.MusicName;
			if(rewardType == PopupRewardEvResult.Type.CumulativePoint)
			{
				m_descText.text = MessageManager.Instance.GetMessage("menu", "event_reward_result_present_box");
			}
			else
			{
				m_descText.text = MessageManager.Instance.GetMessage("menu", "event_reward_result_present_box2");
				if(rewardType == PopupRewardEvResult.Type.RankingsEventBattleHiScore)
				{
					SetBannerImage(data.EventId);
					m_changeLayout.StartChildrenAnimGoStop("01");
					return;
				}
				else if(rewardType == PopupRewardEvResult.Type.RankingsEventHiScore)
				{
					SetBannerImage(data.EventId);
					SetJacketImageEventHiScore(data.CoverId);
					m_changeLayout.StartChildrenAnimGoStop("03");
					return;
				}
			}
			if(data.EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN_EventScore)
			{
				SetJacketImage(data.CoverId);
				m_changeLayout.StartChildrenAnimGoStop("02");
			}
			else if(data.EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
			{
				SetDivaImages(divaId);
				SetBannerImage(data.EventId);
				m_changeLayout.StartChildrenAnimGoStop("05");
			}
			else
			{
				SetBannerImage(data.EventId);
				m_changeLayout.StartChildrenAnimGoStop("01");
			}
		}

		// // RVA: 0x1143824 Offset: 0x1143824 VA: 0x1143824
		private void SetBannerImage(int eventId)
		{
			m_eventId = eventId;
			GameManager.Instance.EventBannerTextureCache.LoadBanner(m_eventId, (IiconTexture texture) =>
			{
				//0x11442D0
				if(texture.BaseTexture !=  null)
				{
					m_BannerImage.GetComponent<RectTransform>().sizeDelta = new Vector2(texture.BaseTexture.width, texture.BaseTexture.height);
					m_BannerImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(-texture.BaseTexture.width, texture.BaseTexture.height) * 0.5f;
				}
				if(eventId == m_eventId)
				{
					texture.Set(m_BannerImage);
				}
			});
		}

		// // RVA: 0x1143CB4 Offset: 0x1143CB4 VA: 0x1143CB4
		private void SetJacketImage(int coverId)
		{
			m_coverId = coverId;
			GameManager.Instance.MusicJacketTextureCache.Load(m_coverId, (IiconTexture texture) =>
			{
				//0x1144764
				if(coverId != m_coverId)
					return;
				texture.Set(m_JacketImage);
			});
		}

		// // RVA: 0x114399C Offset: 0x114399C VA: 0x114399C
		private void SetJacketImageEventHiScore(int coverId)
		{
			m_coverId = coverId;
			GameManager.Instance.MusicJacketTextureCache.Load(m_coverId, (IiconTexture texture) =>
			{
				//0x114487C
				if(coverId != m_coverId)
					return;
				texture.Set(m_JacketImage_EventHiScore);
			});
		}

		// // RVA: 0x1143B14 Offset: 0x1143B14 VA: 0x1143B14
		private void SetDivaImages(int divaId)
		{
			m_divaId = divaId;
			GameManager.Instance.DivaIconCache.Load(m_divaId, 1, 0, (IiconTexture texture) =>
			{
				//0x1144994
				if(divaId != m_divaId)
					return;
				texture.Set(m_divaIcon);
			});
		}
	}
}
