using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;
using UnityEngine.UI;
using System;
using System.Collections;

namespace XeApp.Game.Menu
{
	internal class LayoutDecoraionVisitList : SwapScrollListContent
	{
		public const string AssetName = "root_deco_window_02_list_layout_root";
		[SerializeField]
		private ButtonBase m_divaIcon; // 0x20
		[SerializeField]
		private ActionButton m_visitButton; // 0x24
		[SerializeField]
		private ActionButton m_giftButton; // 0x28
		[SerializeField]
		private RawImageEx m_giftButtonFont; // 0x2C
		[SerializeField]
		private RawImageEx m_divaIconImage; // 0x30
		[SerializeField]
		private RawImageEx m_scoreRatingImage; // 0x34
		[SerializeField]
		private NumberBase m_numberFan; // 0x38
		[SerializeField]
		private Text m_nameText; // 0x3C
		[SerializeField]
		private Text m_rankText; // 0x40
		[SerializeField]
		private Text m_lastLoginTimeText; // 0x44
		[SerializeField]
		private Text m_mapNameText; // 0x48
		[SerializeField]
		private Text m_MusicRateRankText; // 0x4C
		private DivaIconDecoration m_divaDeco; // 0x50
		private AbsoluteLayout m_rankTbl; // 0x54
		private TexUVListManager m_uvManager; // 0x58
		private EAJCBFGKKFA_FriendInfo m_visitPlayerData; // 0x5C
		private IiconTexture m_divaIconTexture; // 0x60
		private MusicRatioTextureCache.MusicRatioTexture m_musicRatioTexture; // 0x64
		private HNKMEOKCNBI m_netDecoVisitControl = new HNKMEOKCNBI(); // 0x68

		// RVA: 0x19EBF54 Offset: 0x19EBF54 VA: 0x19EBF54 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_rankTbl = layout.FindViewById("swtbl_sel_deco_p_rank") as AbsoluteLayout;
			m_giftButtonFont.uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("deco_fnt_11"));
			return base.InitializeFromLayout(layout, uvMan);
		}

		//// RVA: 0x19EC0D8 Offset: 0x19EC0D8 VA: 0x19EC0D8
		public void SetSetting(EAJCBFGKKFA_FriendInfo friend, bool isFan = false, int fanNum = 0)
		{
			m_visitPlayerData = friend;
			m_nameText.text = friend.LBODHBDOMGK_Name;
			m_rankText.text = friend.ILOJAJNCPEC_Rank.ToString();
			m_lastLoginTimeText.text = friend.PCEGKKLKFNO.LFKJNMFFCLH_LastLoginString;
			if(!friend.BHJLNGEDEGN)
			{
				m_mapNameText.text = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL("deco_init_room_name", JpStringLiterals.StringLiteral_9829);
			}
			else
			{
				m_mapNameText.text = friend.FAABJIHJKEM_DcNm;
			}
			SettingDivaIconDecoration(friend);
			if (isFan)
				m_rankTbl.StartChildrenAnimGoStop(1, 1);
			else
			{
				m_rankTbl.StartChildrenAnimGoStop(0, 0);
				fanNum = 0;
			}
			m_numberFan.SetNumber(fanNum, 0);
			m_MusicRateRankText.text = OEGIPPCADNA.GEEFFAEGHAH(OEGIPPCADNA.BFKAHKBKBJE(friend.PCEGKKLKFNO.AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.AILEOFKIELL_UtaRateRank, friend.PCEGKKLKFNO.AJECHDLMKOE_LastLogin), true);
			m_giftButton.Disable = m_netDecoVisitControl.MHGJGAPLMFO(m_visitPlayerData.MLPEHNBNOGD_Id);
			GameManager.Instance.DivaIconCache.SetLoadingIcon(m_divaIconImage);
			this.StartCoroutineWatched(Co_SettingDivaIcon(friend));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D6084 Offset: 0x6D6084 VA: 0x6D6084
		//// RVA: 0x19EC6E8 Offset: 0x19EC6E8 VA: 0x19EC6E8
		public IEnumerator Co_SettingDivaIcon(EAJCBFGKKFA_FriendInfo friend)
		{
			//0x19ECFD0
			bool isLoaded = false;
			GameManager.Instance.DivaIconCache.Load(friend.JIGONEMPPNP_Diva.AHHJLDLAPAN_DivaId, friend.JIGONEMPPNP_Diva.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, friend.JIGONEMPPNP_Diva.EKFONBFDAAP_ColorId, (IiconTexture texture) =>
			{
				//0x19ECB88
				isLoaded = true;
				m_divaIconTexture = texture;
				m_divaIconTexture.Set(m_divaIconImage);
			});
			yield return new WaitUntil(() =>
			{
				//0x19ECCBC
				return isLoaded;
			});
			HighScoreRatingRank.Type rank = friend.AGJIIKKOKFJ_ScoreRatingRank;
			GameManager.Instance.MusicRatioTextureCache.Load(rank, (IiconTexture texture) =>
			{
				//0x19ECCC4
				m_musicRatioTexture = texture as MusicRatioTextureCache.MusicRatioTexture;
				if (m_musicRatioTexture == null)
					return;
				isLoaded = true;
				m_musicRatioTexture.Set(m_scoreRatingImage, rank);
			});
			yield return new WaitUntil(() =>
			{
				//0x19ECDFC
				return isLoaded;
			});
		}

		//// RVA: 0x19EC584 Offset: 0x19EC584 VA: 0x19EC584
		private void SettingDivaIconDecoration(EAJCBFGKKFA_FriendInfo friend)
		{
			m_divaDeco.Change(friend.JIGONEMPPNP_Diva, friend, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.GAAOPEGIPKA_FavoritePlayer.FFKIDMKHIOE(friend.MLPEHNBNOGD_Id), DisplayType.Level);
			m_divaDeco.SetActive(true);
		}

		//// RVA: 0x19EC7B0 Offset: 0x19EC7B0 VA: 0x19EC7B0
		public void IconAnimUpdate(int frame)
		{
			m_divaDeco.FadeFrienFanAnimationSetFrame(frame);
		}

		// RVA: 0x19EC7E4 Offset: 0x19EC7E4 VA: 0x19EC7E4
		public void SettingCallback(DecorationConstants.VisitButtonCallback visitCallback, Action<EAJCBFGKKFA_FriendInfo> giftCallback, Action<EAJCBFGKKFA_FriendInfo> divaIconCallback)
		{
			m_visitButton.AddOnClickCallback(() =>
			{
				//0x19ECE04
				visitCallback(m_visitPlayerData, m_divaIconTexture, m_musicRatioTexture);
			});
			m_giftButton.AddOnClickCallback(() =>
			{
				//0x19ECEA4
				giftCallback(m_visitPlayerData);
			});
			m_divaIcon.AddOnClickCallback(() =>
			{
				//0x19ECF38
				divaIconCallback(m_visitPlayerData);
			});
		}

		// RVA: 0x19EC9CC Offset: 0x19EC9CC VA: 0x19EC9CC
		public void Initilize()
		{
			m_divaDeco = new DivaIconDecoration(m_divaIconImage.gameObject, DivaIconDecoration.Size.S, true, true, null, null);
			m_divaDeco.SetActive(false);
			gameObject.SetActive(false);
		}

		// RVA: 0x19ECAD8 Offset: 0x19ECAD8 VA: 0x19ECAD8
		public void Release()
		{
			m_divaDeco.Release();
		}
	}
}
