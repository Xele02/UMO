using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace XeApp.Game.Menu
{
	public class RaidMvpScrollItem : SwapScrollListContent
	{
		[SerializeField]
		private RawImageEx m_playerIconImage; // 0x20
		[SerializeField]
		private RawImageEx m_playerPlateImage; // 0x24
		[SerializeField]
		private Text m_playerNameText; // 0x28
		[SerializeField]
		private Text m_damageText; // 0x2C
		[SerializeField]
		private Text m_playerRankText; // 0x30
		[SerializeField]
		private Text m_beText; // 0x34
		[SerializeField]
		private RawImageEx m_beImage; // 0x38
		[SerializeField]
		private Text m_eventRankText; // 0x3C
		[SerializeField]
		private ButtonBase m_profileButton; // 0x40
		private AbsoluteLayout m_eventRankImageLayout; // 0x44
		private AbsoluteLayout m_raidPointLayout; // 0x48
		private SceneIconDecoration m_sceneDecoration = new SceneIconDecoration(); // 0x4C
		private DivaIconDecoration m_divaDecoration = new DivaIconDecoration(); // 0x50
		public Action<int> OnClickProfileButton; // 0x54
		private int m_index; // 0x58
		private int m_sceneId; // 0x5C
		private int m_evolveId; // 0x60
		private bool m_isKira; // 0x64

		// RVA: 0x1BD5ED8 Offset: 0x1BD5ED8 VA: 0x1BD5ED8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_profileButton.ClearOnClickCallback();
			m_profileButton.AddOnClickCallback(OnClickProfileCallback);
			m_eventRankImageLayout = layout.FindViewByExId("sw_sel_list_cont_mvp01_swtbl_list_cont_icon_rank_mvp") as AbsoluteLayout;
			m_raidPointLayout = layout.FindViewByExId("sw_sel_list_cont_mvp01_swtbl_pt_hiscore") as AbsoluteLayout;
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}

		// RVA: 0x1BD48F0 Offset: 0x1BD48F0 VA: 0x1BD48F0
		public void InitializeDecoration()
		{
			m_sceneDecoration.Initialize(m_playerPlateImage.gameObject, SceneIconDecoration.Size.M, null, null);
			m_divaDecoration.Initialize(m_playerIconImage.gameObject, DivaIconDecoration.Size.S, true, true, null, null);
		}

		// RVA: 0x1BD537C Offset: 0x1BD537C VA: 0x1BD537C
		public void UpdateContent(int index, PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ.CALIFIMGGMD playerData)
		{
			m_index = index;
			SetPlayerName(playerData.LBODHBDOMGK_Name);
			SetPlayerDamage(playerData.HALIDDHLNEG_Damage);
			SetPlayerRank(playerData.ADFIHAPELAN_PLevel);
			SetPlayerBe(playerData.OFHFGHJEKKL);
			SetPlayerRankImage(playerData.HIMMCGKKOOL_Rate);
			EAJCBFGKKFA_FriendInfo f = new EAJCBFGKKFA_FriendInfo();
			f.KHEKNNFCAOI(playerData);
			SetPlayerIcon(f.JIGONEMPPNP_Diva.AHHJLDLAPAN_DivaId, f.JIGONEMPPNP_Diva.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, f.JIGONEMPPNP_Diva.EKFONBFDAAP_ColorId);
			SetPlayerPlate(f.AFBMEMCHJCL_MainScene);
			m_divaDecoration.Change(f.JIGONEMPPNP_Diva, f, DisplayType.Level, f.AFBMEMCHJCL_MainScene);
			m_sceneDecoration.Change(f.AFBMEMCHJCL_MainScene, DisplayType.Level);
		}

		// // RVA: 0x1BD6528 Offset: 0x1BD6528 VA: 0x1BD6528
		private void SetPlayerIcon(int divaId, int divaModelId, int divaColorId)
		{
			GameManager.Instance.DivaIconCache.SetLoadingIcon(m_playerIconImage);
			GameManager.Instance.DivaIconCache.Load(divaId, divaModelId, divaColorId, (IiconTexture icon) =>
			{
				//0x1BD6A14
				icon.Set(m_playerIconImage);
			});
		}

		// // RVA: 0x1BD66A0 Offset: 0x1BD66A0 VA: 0x1BD66A0
		private void SetPlayerPlate(GCIJNCFDNON_SceneInfo sceneData)
		{
			int evolveId = 0;
			int sceneId = 0;
			bool isKira = false;
			if(sceneData != null)
			{
				evolveId = sceneData.CGIELKDLHGE_GetEvolveId();
				sceneId = sceneData.BCCHOBPJJKE_SceneId;
				isKira = sceneData.MBMFJILMOBP_IsKira();
			}
			m_sceneId = sceneId;
			m_evolveId = evolveId;
			m_isKira = isKira;
			MenuScene.Instance.SceneIconCache.SetLoadingTexture(m_playerPlateImage);
			MenuScene.Instance.SceneIconCache.Load(sceneId, evolveId, (IiconTexture texture) =>
			{
				//0x1BD6AF4
				if(m_sceneId == sceneId && m_evolveId == evolveId && m_isKira == isKira)
				{
					texture.Set(m_playerPlateImage);
					SceneIconTextureCache.ChangeKiraMaterial(m_playerPlateImage, texture as IconTexture, isKira);
				}
			});
		}

		// // RVA: 0x1BD60B8 Offset: 0x1BD60B8 VA: 0x1BD60B8
		private void SetPlayerName(string str)
		{
			m_playerNameText.text = str;
		}

		// // RVA: 0x1BD60F4 Offset: 0x1BD60F4 VA: 0x1BD60F4
		private void SetPlayerDamage(int damage)
		{
			m_damageText.text = damage.ToString();
			m_raidPointLayout.StartChildrenAnimGoStop("04");
		}

		// // RVA: 0x1BD61B8 Offset: 0x1BD61B8 VA: 0x1BD61B8
		private void SetPlayerRank(int rank)
		{
			m_playerRankText.text = rank.ToString();
		}

		// // RVA: 0x1BD620C Offset: 0x1BD620C VA: 0x1BD620C
		private void SetPlayerBe(int rank)
		{
			m_beText.text = rank.ToString();
		}

		// // RVA: 0x1BD6260 Offset: 0x1BD6260 VA: 0x1BD6260
		private void SetPlayerRankImage(int grade)
		{
			HighScoreRatingRank.Type rank = (HighScoreRatingRank.Type)grade;
			GameManager.Instance.MusicRatioTextureCache.Load(rank, (IiconTexture texture) =>
			{
				//0x1BD6CDC
				if(texture != null)
				{
					(texture as MusicRatioTextureCache.MusicRatioTexture).Set(m_beImage, rank);
				}
			});
		}

		// // RVA: 0x1BD63C0 Offset: 0x1BD63C0 VA: 0x1BD63C0
		// private void SetPlayerEventRank(int rank) { }

		// // RVA: 0x1BD68F4 Offset: 0x1BD68F4 VA: 0x1BD68F4
		private void OnClickProfileCallback()
		{
			if(OnClickProfileButton != null)
				OnClickProfileButton(Index);
		}

		// RVA: 0x1BD4B90 Offset: 0x1BD4B90 VA: 0x1BD4B90
		public void Release()
		{
			m_sceneDecoration.Release();
			m_divaDecoration.Release();
		}
	}
}
