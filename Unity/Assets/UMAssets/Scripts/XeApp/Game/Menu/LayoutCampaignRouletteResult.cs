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
	public class LayoutCampaignRouletteResult : LayoutUGUIScriptBase
	{
		private Text m_textTitle; // 0x14
		private RawImageEx[] m_imageRank; // 0x18
		private RawImageEx[] m_imageChara; // 0x1C
		private AbsoluteLayout m_layoutRoot; // 0x20
		private AbsoluteLayout m_layoutTable; // 0x24
		private AbsoluteLayout m_layoutAnim1; // 0x28
		private AbsoluteLayout m_layoutAnim2; // 0x2C
		private Transform m_parent; // 0x30
		private TexUVListManager m_uvMan; // 0x34
		private OLLAFCBLMIJ m_view; // 0x38
		private CriAtomExPlayback m_loopSE; // 0x3C
		private List<CampaignRouletteScene.MiniCharaTexture> m_miniCharaList = new List<CampaignRouletteScene.MiniCharaTexture>(); // 0x40

		// RVA: 0x19D76D8 Offset: 0x19D76D8 VA: 0x19D76D8
		public List<CampaignRouletteScene.MiniCharaTexture> GetMiniCharaList()
		{
			return m_miniCharaList;
		}

		// RVA: 0x19D76E0 Offset: 0x19D76E0 VA: 0x19D76E0
		public void Setup(int rank, int rankMax)
		{
			if(rank == 1)
			{
				m_layoutRoot.StartChildrenAnimGoStop("01");
                TexUVData uvData = m_uvMan.GetUVData("s_c_r_roulette_num_" + rankMax.ToString());
				for(int i = 0; i < m_imageRank.Length; i++)
				{
					m_imageRank[i].uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvData);
				}
            }
			else
			{
				m_layoutRoot.StartChildrenAnimGoStop("02");
				m_layoutTable.StartChildrenAnimGoStop(rank.ToString("D2"));
				TexUVData uvData = m_uvMan.GetUVData("s_c_r_roulette_num_" + rank.ToString());
				for(int i = 0; i < m_imageRank.Length; i++)
				{
					m_imageRank[i].uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvData);
				}
			}
			m_layoutAnim1.StartChildrenAnimGoStop("st_wait");
			m_layoutAnim2.StartChildrenAnimGoStop("st_wait");
		}

		// RVA: 0x19D7AA8 Offset: 0x19D7AA8 VA: 0x19D7AA8
		public void SetParent(Transform parent)
		{
			transform.SetParent(parent, false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CB974 Offset: 0x6CB974 VA: 0x6CB974
		// RVA: 0x19D7AE8 Offset: 0x19D7AE8 VA: 0x19D7AE8
		public IEnumerator StartRouletteResult(int rank, Action callback)
		{
			//0x19D96C8
			if(rank == 1)
			{
				yield return Co.R(Co_RouletteResultAnim1(callback));
			}
			else
			{
				yield return Co.R(Co_RouletteResultAnim2(callback));
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CB9EC Offset: 0x6CB9EC VA: 0x6CB9EC
		// // RVA: 0x19D7BC8 Offset: 0x19D7BC8 VA: 0x19D7BC8
		private IEnumerator Co_RouletteResultAnim1(Action callback)
		{
			//0x19D8A9C
			m_layoutAnim1.StartChildrenAnimGoStop("go_act", "st_act");
			yield return Co.R(WaitAnim(m_layoutAnim1,"se_02"));
			SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_ROULETTE_003);
			yield return Co.R(WaitAnim(m_layoutAnim1,"se_03"));
			SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.Campaign, 4);
			yield return Co.R(WaitAnim(m_layoutAnim1,"se_04"));
			SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_ROULETTE_004);
			SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_ROULETTE_008);
			yield return Co.R(WaitAnim(m_layoutAnim1,"se_10"));
			m_loopSE = SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_ROULETTE_001);
			yield return Co.R(WaitAnim(m_layoutAnim1,"se_11"));
			yield return Co.R(WaitAnim(m_layoutAnim1,"se_12"));
			SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_ROULETTE_010);
			yield return Co.R(WaitAnim(m_layoutAnim1,"se_13"));
			SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_ROULETTE_009);
			yield return Co.R(WaitAnim(m_layoutAnim1,"se_14"));
			SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_ROULETTE_002);
			yield return Co.R(WaitAnim(m_layoutAnim1,"se_05"));
			SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_ROULETTE_005);
			SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_ROULETTE_007);
			SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.Campaign, 2);
			if(callback != null)
				callback();
			yield return new WaitWhile(() =>
			{
				//0x19D87E0
				return m_layoutAnim1.IsPlayingChildren();
			});
			m_layoutAnim1.StartChildrenAnimLoop("logo_act", "loen_act");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CBA64 Offset: 0x6CBA64 VA: 0x6CBA64
		// // RVA: 0x19D7C90 Offset: 0x19D7C90 VA: 0x19D7C90
		private IEnumerator Co_RouletteResultAnim2(Action callback)
		{
			//0x19D935C
			m_layoutAnim2.StartChildrenAnimGoStop("go_in", "st_in");
			yield return Co.R(WaitAnim(m_layoutAnim2,"se_06"));
			SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_ROULETTE_005);
			SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_ROULETTE_007);
			SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.Campaign, 3);
			if(callback != null)
				callback();
			yield return new WaitWhile(() =>
			{
				//0x19D880C
				return m_layoutAnim2.IsPlayingChildren();
			});
			m_layoutAnim2.StartChildrenAnimLoop("logo_act", "loen_act");
		}

		// RVA: 0x19D7D58 Offset: 0x19D7D58 VA: 0x19D7D58
		public void SetCharaTexture(CampaignRouletteScene.MiniCharaTexture info, IiconTexture texture)
		{
            List<CampaignRouletteScene.MiniCharaTexture> l = m_miniCharaList.FindAll((CampaignRouletteScene.MiniCharaTexture x) =>
			{
				//0x19D8A4C
				return x.imageId == info.imageId;
			});
			for(int i = 0; i < l.Count; i++)
			{
				texture.Set(l[i].image);
			}
        }

		// [IteratorStateMachineAttribute] // RVA: 0x6CBADC Offset: 0x6CBADC VA: 0x6CBADC
		// // RVA: 0x19D7F8C Offset: 0x19D7F8C VA: 0x19D7F8C
		public IEnumerator WaitAnim(AbsoluteLayout layout, string label)
		{
			//0x19D97F0
			while(layout.GetView(0).FrameAnimation.FrameCount < layout.GetView(0).FrameAnimation.SearchLabelFrame(label))
				yield return null;
		}

		// RVA: 0x19D8054 Offset: 0x19D8054 VA: 0x19D8054 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvMan = uvMan;
			m_layoutRoot = layout.FindViewById("swtbl_sel_cpn_roul_result") as AbsoluteLayout;
			m_layoutAnim1 = layout.FindViewById("sw_sel_cpn_roul_result_1_anim") as AbsoluteLayout;
			m_layoutAnim2 = layout.FindViewById("sw_sel_cpn_roul_result_2_anim") as AbsoluteLayout;
			m_layoutTable = layout.FindViewById("swtbl_sel_cpn_roul_num") as AbsoluteLayout;
			RawImageEx[] imgs = GetComponentsInChildren<RawImageEx>(true);
			m_imageRank = imgs.Where((RawImageEx _) =>
			{
				//0x19D88B4
				return _.name == "swtexf_s_c_r_roulette_num (ImageView)";
			}).ToArray();
			m_imageChara = imgs.Where((RawImageEx _) =>
			{
				//0x19D8934
				return _.name.Contains("minichara_l_01_02_");
			}).ToArray();
			for(int i = 0; i < m_imageChara.Length; i++)
			{
				m_miniCharaList.Add(CampaignRouletteScene.MiniCharaTexture.Make(m_imageChara[i]));
			}
			Text[] txts = GetComponentsInChildren<Text>(true);
			m_textTitle = txts.Where((Text _) =>
			{
				//0x19D89CC
				return _.name == "title (TextView)";
			}).First();
			m_textTitle.text = MessageManager.Instance.GetMessage("menu", "campaign_live_3rd_roulette_title");
			Loaded();
			return true;
		}
	}
}
