using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeSys;

namespace XeApp.Game.Menu
{
	public class SceneGrowthEpisodeGauge : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_rewordImage; // 0x14
		[SerializeField]
		private RawImageEx m_rewordMaskImage; // 0x18
		[SerializeField]
		private Text m_addRewardText; // 0x1C
		private AbsoluteLayout m_gaugeAnimeLayout; // 0x20
		private AbsoluteLayout m_nextAnimeLayout; // 0x24
		private AbsoluteLayout m_availableGauge; // 0x28
		private float m_startFrame; // 0x2C
		private float m_endFrame; // 0x30

		// RVA: 0x15ACEC4 Offset: 0x15ACEC4 VA: 0x15ACEC4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_gaugeAnimeLayout = layout.FindViewByExId("sw_ab_fr_set_p3_sw_cnm_ep_icon_03_anim") as AbsoluteLayout;
			m_nextAnimeLayout = layout.FindViewByExId("sw_ab_fr_set_p3_swtbl_ep_next") as AbsoluteLayout;
			m_availableGauge = layout.FindViewByExId("sw_cnm_ep_icon_03_anim_sw_sel_ep_meter_eff_anim") as AbsoluteLayout;
			m_startFrame = m_gaugeAnimeLayout[0].FrameAnimation.SearchLabelFrame("go_out");
			m_endFrame = m_gaugeAnimeLayout[0].FrameAnimation.SearchLabelFrame("st_non");
			m_rewordMaskImage.uvRect = EpisodeTextuteCache.ImageUv;
			m_rewordImage.uvRect = EpisodeTextuteCache.ImageUv;
			RectTransform rt = GetComponentInChildren<Mask>().transform.GetChild(0) as RectTransform;
			rt.pivot = new Vector2(0, 1);
			rt.anchorMax = new Vector2(0, 1);
			rt.anchorMin = new Vector2(0, 1);
			m_addRewardText.text = MessageManager.Instance.GetMessage("menu", "growth_addreward_text");
			ClearLoadedCallback();
			return true;
		}

		// RVA: 0x15AD3D4 Offset: 0x15AD3D4 VA: 0x15AD3D4
		public void UpdateContent(PIGBBNDPPJC episodeData)
		{
			if(episodeData.DKMLDEDKPBA_HasEpisode)
			{
				SetTexture(episodeData.KELFCMEOPPM_EpId);
				SetGaugeRate(episodeData.ABLHIAEDJAI_CurrentPoint, episodeData.LEGAKDFPPHA_AvaiablePoint, episodeData.DMHDNKILKGI_MaxPoint);
			}
		}

		//// RVA: 0x15AD488 Offset: 0x15AD488 VA: 0x15AD488
		private void SetTexture(int picId)
		{
			GameManager.Instance.EpisodeIconCache.Load(picId, (IiconTexture texture) =>
			{
				//0x15AD770
				texture.Set(m_rewordImage);
				texture.Set(m_rewordMaskImage);
			});
		}

		//// RVA: 0x15AD598 Offset: 0x15AD598 VA: 0x15AD598
		public void SetGaugeRate(int currentPoint, int availablePoint, int maxPoint)
		{
			int a = EpisodeUtility.CalcEpisodeGaugeFrame(availablePoint, maxPoint, 264);
			m_availableGauge.StartChildrenAnimGoStop(a, a);
			m_nextAnimeLayout.StartChildrenAnimGoStop("01");
			if (currentPoint == 0)
				m_gaugeAnimeLayout.StartChildrenAnimGoStop("st_wait");
			else if(currentPoint < maxPoint)
			{
				a = EpisodeUtility.CalcEpisodeGaugeFrame(currentPoint, maxPoint, 264);
				m_gaugeAnimeLayout.StartChildrenAnimGoStop(a + 7, a + 7);
			}
			else
			{
				m_nextAnimeLayout.StartChildrenAnimGoStop("02");
				m_gaugeAnimeLayout.StartChildrenAnimGoStop("st_non");
				m_availableGauge.StartChildrenAnimGoStop("st_out");
			}
		}
	}
}
