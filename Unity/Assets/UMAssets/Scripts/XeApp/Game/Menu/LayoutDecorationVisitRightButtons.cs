using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationVisitRightButtons : LayoutUGUIScriptBase
	{
		public static readonly string AssetName = "root_deco_right_btn_02_layout_root"; // 0x0
		[SerializeField]
		private RawImageEx m_divaIconImage; // 0x14
		[SerializeField]
		private RawImageEx m_scoreRatingImage; // 0x18
		[SerializeField]
		private Text m_nameText; // 0x1C
		[SerializeField]
		private Text m_rankText; // 0x20
		[SerializeField]
		private Text m_mapNameText; // 0x24
		[SerializeField]
		private ButtonBase m_divaIcon; // 0x28
		[SerializeField]
		private ActionButton m_giftButton; // 0x2C
		[SerializeField]
		private ActionButton m_friendButton; // 0x30
		[SerializeField]
		private ActionButton m_fanButton; // 0x34
		[SerializeField]
		private Text m_rateText; // 0x38
		[SerializeField]
		private Text m_rateRankText; // 0x3C
		private AbsoluteLayout m_visitBase; // 0x40
		private AbsoluteLayout m_buttonBase; // 0x44
		private AbsoluteLayout m_fanButtonLabelLayout; // 0x48
		private DivaIconDecoration m_decoDeco = new DivaIconDecoration(); // 0x4C
		public Action ClickDivaIconCallback; // 0x50
		public Action ClickGiftButtonCallback; // 0x54
		public Action ClickFriendButtonCallback; // 0x58
		public Action ClickFanButtonCallback; // 0x5C
		private int m_playerId; // 0x60
		private bool IsEnter; // 0x64

		// RVA: 0x18BDB3C Offset: 0x18BDB3C VA: 0x18BDB3C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_visitBase = layout.FindViewById("sw_deco_prf_anim") as AbsoluteLayout;
			m_buttonBase = layout.FindViewById("sw_view_deco_all_anim") as AbsoluteLayout;
			m_fanButtonLabelLayout = layout.FindViewByExId("sw_view_diva_view_btn_03_swtbl_view_diva_fnt_06") as AbsoluteLayout;
			m_divaIcon.AddOnClickCallback(() =>
			{
				//0x18BEC4C
				ClickDivaIconCallback();
			});
			m_friendButton.AddOnClickCallback(() =>
			{
				//0x18BEC78
				ClickFriendButtonCallback();
			});
			m_giftButton.AddOnClickCallback(() =>
			{
				//0x18BECA4
				ClickGiftButtonCallback();
			});
			m_fanButton.AddOnClickCallback(() =>
			{
				//0x18BECD0
				ClickFanButtonCallback();
			});
			return base.InitializeFromLayout(layout, uvMan);
		}

		// RVA: 0x18BDE7C Offset: 0x18BDE7C VA: 0x18BDE7C
		public void Initialize()
		{
			m_decoDeco.Initialize(m_divaIconImage.gameObject, DivaIconDecoration.Size.S, true, true, null, null);
		}

		// RVA: 0x18BDEF0 Offset: 0x18BDEF0 VA: 0x18BDEF0
		public void Release()
		{
			m_decoDeco.Release();
		}

		// RVA: 0x18BDF1C Offset: 0x18BDF1C VA: 0x18BDF1C
		public void Enter()
		{
			if(IsEnter)
				return;
			IsEnter = true;
			m_visitBase.StartChildrenAnimGoStop("go_in", "st_in");
			m_buttonBase.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x18BDFFC Offset: 0x18BDFFC VA: 0x18BDFFC
		public void Leave()
		{ 
			if(!IsEnter)
				return;
			IsEnter = false;
			m_visitBase.StartChildrenAnimGoStop("go_out", "st_out");
			m_buttonBase.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x18BE0DC Offset: 0x18BE0DC VA: 0x18BE0DC
		public void Hide()
		{
			m_visitBase.StartChildrenAnimGoStop("st_wait", "st_wait");
			m_buttonBase.StartChildrenAnimGoStop("st_wait", "st_wait");
		}

		// RVA: 0x18BE190 Offset: 0x18BE190 VA: 0x18BE190
		public bool IsPlaying()
		{
			return m_visitBase.IsPlayingChildren() || m_buttonBase.IsPlayingChildren();
		}

		// // RVA: 0x18BE1EC Offset: 0x18BE1EC VA: 0x18BE1EC
		public void UpdateContent(EAJCBFGKKFA_FriendInfo playerData, string mapName)
		{
			m_playerId = playerData.MLPEHNBNOGD_Id;
			m_nameText.text = playerData.LBODHBDOMGK_Name;
			m_rankText.text = playerData.ILOJAJNCPEC_Rank.ToString();
			m_mapNameText.text = mapName;
			m_rateText.text = HighScoreRatingRank.GetRankName(playerData.AGJIIKKOKFJ_ScoreRatingRank);
			m_rateRankText.text = OEGIPPCADNA.GEEFFAEGHAH(OEGIPPCADNA.BFKAHKBKBJE(playerData.PCEGKKLKFNO.AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.AILEOFKIELL_UtaRateRank, playerData.PCEGKKLKFNO.AJECHDLMKOE_LastLogin), true);
			GameManager.Instance.DivaIconCache.Load(playerData.JIGONEMPPNP_Diva.AHHJLDLAPAN_DivaId, playerData.JIGONEMPPNP_Diva.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, playerData.JIGONEMPPNP_Diva.EKFONBFDAAP_ColorId, (IiconTexture texture) =>
			{
				//0x18BECFC
				texture.Set(m_divaIconImage);
			});
			GameManager.Instance.MusicRatioTextureCache.Load(playerData.AGJIIKKOKFJ_ScoreRatingRank, (IiconTexture texture) =>
			{
				//0x18BEDF0
				if(texture != null)
				{
					(texture as MusicRatioTextureCache.MusicRatioTexture).Set(m_scoreRatingImage, playerData.AGJIIKKOKFJ_ScoreRatingRank);
				}
			});
			UpdateFanButton(playerData);
			UpdateFriendIcon(playerData);
		}

		// RVA: 0x18BE7E8 Offset: 0x18BE7E8 VA: 0x18BE7E8
		public void UpdateFanButton(EAJCBFGKKFA_FriendInfo playerData)
		{
			FanButtonLabelChange(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.GAAOPEGIPKA_FavoritePlayer.FFKIDMKHIOE(playerData.MLPEHNBNOGD_Id));
		}

		// RVA: 0x18BE8F0 Offset: 0x18BE8F0 VA: 0x18BE8F0
		public void UpdateFriendIcon(EAJCBFGKKFA_FriendInfo playerData)
		{
			m_decoDeco.Change(playerData.JIGONEMPPNP_Diva, playerData, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.GAAOPEGIPKA_FavoritePlayer.FFKIDMKHIOE(playerData.MLPEHNBNOGD_Id), DisplayType.Level);
			m_decoDeco.SetActive(true);
		}

		// RVA: 0x18BEAFC Offset: 0x18BEAFC VA: 0x18BEAFC
		public void DisableButton_Gift()
		{
			m_giftButton.Disable = true;
		}

		// RVA: 0x18BEB2C Offset: 0x18BEB2C VA: 0x18BEB2C
		public void HiddenButton_Friend()
		{
			m_friendButton.Hidden = true;
		}

		// // RVA: 0x18BEA68 Offset: 0x18BEA68 VA: 0x18BEA68
		public void FanButtonLabelChange(bool isFav)
		{
			m_fanButtonLabelLayout.StartChildrenAnimGoStop(isFav ? "02" : "01");
		}
	}
}
