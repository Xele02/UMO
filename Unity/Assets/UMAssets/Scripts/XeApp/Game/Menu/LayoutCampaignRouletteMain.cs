using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CriWare;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutCampaignRouletteMain : LayoutUGUIScriptBase
	{
		private Text m_textTitle; // 0x14
		private RawImageEx[] m_imageChara; // 0x18
		private AbsoluteLayout m_layoutRoot; // 0x1C
		private AbsoluteLayout m_layoutTable; // 0x20
		private OLLAFCBLMIJ m_view; // 0x24
		private CriAtomExPlayback m_loopSE; // 0x28
		private List<CampaignRouletteScene.MiniCharaTexture> m_miniCharaList = new List<CampaignRouletteScene.MiniCharaTexture>(); // 0x2C

		// RVA: 0x19D60A8 Offset: 0x19D60A8 VA: 0x19D60A8
		public List<CampaignRouletteScene.MiniCharaTexture> GetMiniCharaList()
		{
			return m_miniCharaList;
		}

		// RVA: 0x19D60B0 Offset: 0x19D60B0 VA: 0x19D60B0
		public void Enter(Action callback)
		{
			this.StartCoroutineWatched(Co_Enter(callback));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CB6FC Offset: 0x6CB6FC VA: 0x6CB6FC
		// // RVA: 0x19D60D4 Offset: 0x19D60D4 VA: 0x19D60D4
		private IEnumerator Co_Enter(Action callback)
		{
			//0x19D6D8C
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			yield return Co.R(WaitAnim(m_layoutRoot, "se_07"));
			yield return new WaitWhile(() =>
			{
				//0x19D6B50
				return m_layoutRoot.IsPlayingChildren();
			});
			m_layoutRoot.StartChildrenAnimLoop("logo_act", "loen_act");
			m_loopSE = SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_ROULETTE_000);
			if(callback != null)
				callback();
		}

		// RVA: 0x19D619C Offset: 0x19D619C VA: 0x19D619C
		public void SetParent(Transform parent)
		{
			transform.SetParent(parent, false);
		}

		// // RVA: 0x19D61DC Offset: 0x19D61DC VA: 0x19D61DC
		// public bool IsPlaying() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6CB774 Offset: 0x6CB774 VA: 0x6CB774
		// RVA: 0x19D6208 Offset: 0x19D6208 VA: 0x19D6208
		public IEnumerator StartRoulette(int rank)
		{
			//0x19D7064
			m_loopSE.Stop();
			m_layoutRoot.StartChildrenAnimGoStop("go_act", "st_act");
			yield return Co.R(WaitAnim(m_layoutRoot, "se_08"));
			SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.Campaign, 1);
			yield return new WaitForSeconds(0.1f);
			m_loopSE = SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_ROULETTE_001);
			yield return Co.R(WaitAnim(m_layoutRoot, "se_01"));
			m_loopSE.Stop();
			m_layoutTable.StartChildrenAnimGoStop(rank.ToString("D2"));
			m_layoutTable.StartAllAnimGoStop("go_roul", "st_roul");
			yield return Co.R(WaitAnim(m_layoutRoot, "se_09"));
			SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_ROULETTE_002);
			yield return new WaitWhile(() =>
			{
				//0x19D6B7C
				return m_layoutRoot.IsPlayingChildren();
			});
		}

		// RVA: 0x19D62D0 Offset: 0x19D62D0 VA: 0x19D62D0
		public void SetCharaTexture(CampaignRouletteScene.MiniCharaTexture info, IiconTexture texture)
		{
            List<CampaignRouletteScene.MiniCharaTexture> l = m_miniCharaList.FindAll((CampaignRouletteScene.MiniCharaTexture x) =>
			{
				//0x19D6D3C
				return x.imageId == info.imageId;
			});
			for(int i = 0; i < l.Count; i++)
			{
				texture.Set(l[i].image);
			}
        }

		// [IteratorStateMachineAttribute] // RVA: 0x6CB7EC Offset: 0x6CB7EC VA: 0x6CB7EC
		// RVA: 0x19D6504 Offset: 0x19D6504 VA: 0x19D6504
		public IEnumerator WaitAnim(AbsoluteLayout layout, string label)
		{
			//0x19D751C
			while(layout.GetView(0).FrameAnimation.FrameCount < layout.GetView(0).FrameAnimation.SearchLabelFrame(label))
				yield return null;
		}

		// RVA: 0x19D65CC Offset: 0x19D65CC VA: 0x19D65CC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewById("sw_sel_cpn_roul_anim") as AbsoluteLayout;
			m_layoutTable = layout.FindViewById("swtbl_sel_cpn_roul_num") as AbsoluteLayout;
			RawImageEx[] imgs = GetComponentsInChildren<RawImageEx>(true);
			m_imageChara = imgs.Where((RawImageEx _) =>
			{
				//0x19D6C24
				return _.name.Contains("minichara_l_01_02_");
			}).ToArray();
			for(int i = 0; i < m_imageChara.Length; i++)
			{
				m_miniCharaList.Add(CampaignRouletteScene.MiniCharaTexture.Make(m_imageChara[i]));
			}
			Text[] txts = GetComponentsInChildren<Text>(true);
			m_textTitle = txts.Where((Text _) =>
			{
				//0x19D6CBC
				return _.name == "title (TextView)";
			}).First();
			m_textTitle.text = MessageManager.Instance.GetMessage("menu", "campaign_live_3rd_roulette_title");
			Loaded();
			return true;
		}
	}
}
