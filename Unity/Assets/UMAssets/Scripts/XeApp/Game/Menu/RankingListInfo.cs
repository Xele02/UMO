using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class RankingListInfo : PlayerListInfo
	{
		private bool m_isDivaLoad; // 0x20
		private bool m_isSceneLoad; // 0x21
		public int divaId = 1; // 0x24
		public int divaCostumeId = 1; // 0x28
		public int divaCostumeColorId; // 0x2C
		public int sceneId; // 0x30
		public int sceneRank; // 0x34
		public int emblemId; // 0x38
		public int musicRatio; // 0x3C
		public HighScoreRatingRank.Type scoreRatingRank = HighScoreRatingRank.Type.Be; // 0x40
		public bool isKira; // 0x44
		public int playerLevel; // 0x48
		public long score; // 0x50
		public int rankingOrder; // 0x58
		public bool isOwner; // 0x5C

		public IiconTexture DivaTexture { get; private set; } // 0x18
		public IiconTexture SceneTexture { get; private set; } // 0x1C

		// RVA: 0xCF3DEC Offset: 0xCF3DEC VA: 0xCF3DEC
		public RankingListInfo(int index, bool isAvailable, EAJCBFGKKFA_FriendInfo friend)
		{
			SetFriListInfo(index, isAvailable, friend);
			if(friend.JIGONEMPPNP_Diva != null)
			{
				LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_GetUnlockedCostumeOrDefault(friend.JIGONEMPPNP_Diva.AHHJLDLAPAN_DivaId, friend.JIGONEMPPNP_Diva.JPIDIENBGKH_CostumeId);
				divaId = cos.AHHJLDLAPAN_PrismDivaId;
				divaCostumeId = cos.DAJGPBLEEOB_PrismCostumeModelId;
				divaCostumeColorId = friend.JIGONEMPPNP_Diva.EKFONBFDAAP_ColorId;
			}
			isKira = false;
			if(friend.AFBMEMCHJCL_MainScene != null)
			{
				sceneId = friend.AFBMEMCHJCL_MainScene.BCCHOBPJJKE_SceneId;
				sceneRank = friend.AFBMEMCHJCL_MainScene.CGIELKDLHGE_GetEvolveId();
				isKira = friend.AFBMEMCHJCL_MainScene.MBMFJILMOBP_IsKira();
			}
			emblemId = friend.NDOLELKAJNL_DegreeData.MDPKLNFFDBO_EmblemId;
			rankingOrder = friend.PCEGKKLKFNO.FJOLNJLLJEJ_Rank;
			playerLevel = friend.PCEGKKLKFNO.ADFIHAPELAN_PLevel;
			score = friend.PCEGKKLKFNO.KNIFCANOHOC_Score;
			isOwner = friend.PCEGKKLKFNO.ONAFFLLLBHE_IsSelf;
			musicRatio = friend.BJGOPOEAAIC_MusicRatio;
			scoreRatingRank = friend.AGJIIKKOKFJ_ScoreRatingRank;
		}

		// RVA: 0xCF40A4 Offset: 0xCF40A4 VA: 0xCF40A4
		public IiconTexture GetDivaIconTex()
		{
			if(DivaTexture == null && !m_isDivaLoad)
			{
				GameManager.Instance.DivaIconCache.Load(divaId, divaCostumeId, divaCostumeColorId, OnDivaIconLoaded);
				m_isDivaLoad = true;
			}
			return DivaTexture;
		}

		// RVA: 0xCF41F8 Offset: 0xCF41F8 VA: 0xCF41F8
		public IiconTexture GetSceneIconTex()
		{
			if(SceneTexture == null && !m_isSceneLoad)
			{
				GameManager.Instance.SceneIconCache.Load(sceneId, sceneRank, OnSceneIconLoaded);
				m_isSceneLoad = true;
			}
			return SceneTexture;
		}

		//// RVA: 0xCF4340 Offset: 0xCF4340 VA: 0xCF4340
		private void OnDivaIconLoaded(IiconTexture icon)
		{
			DivaTexture = icon;
		}

		//// RVA: 0xCF4348 Offset: 0xCF4348 VA: 0xCF4348
		private void OnSceneIconLoaded(IiconTexture icon)
		{
			SceneTexture = icon;
		}

		// RVA: 0xCF4350 Offset: 0xCF4350 VA: 0xCF4350 Slot: 4
		public override void TryInstall()
		{
			GameManager.Instance.DivaIconCache.TryInstall(divaId, divaCostumeId, divaCostumeColorId);
			if(sceneId > 0)
			{
				GameManager.Instance.SceneIconCache.TryInstall(sceneId, sceneRank);
			}
			if (emblemId < 2)
				return;
			GameManager.Instance.ItemTextureCache.TryInstallEmblem(emblemId);
		}
	}
}
