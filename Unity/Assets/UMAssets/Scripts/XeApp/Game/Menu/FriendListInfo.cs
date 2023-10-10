using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class FriendListInfo : PlayerListInfo
	{
		private IiconTexture DivaIconTexture; // 0x18
		private IiconTexture SceneIconTexture; // 0x1C
		private bool isDivaLoad; // 0x20
		private bool isSceneLoad; // 0x21
		public int playerId; // 0x24
		public int playerRank; // 0x28
		public long lastLogin; // 0x30
		public long requestDate; // 0x38
		public int divaId; // 0x40
		public int divaModelId; // 0x44
		public int divaColorId; // 0x48
		public int sceneId; // 0x4C
		public int sceneRank; // 0x50
		public int sceneRarity; // 0x54
		public int sceneLevel; // 0x58
		public int emblemId; // 0x5C
		public GameAttribute.Type sceneAttr; // 0x60
		public SeriesAttr.Type sceneSeries; // 0x64
		public int total; // 0x68
		public string skill = ""; // 0x6C
		public int skillLevel; // 0x70
		public SkillRank.Type skillRank; // 0x74
		public HighScoreRatingRank.Type scoreRatingRank = HighScoreRatingRank.Type.Be; // 0x78
		public int life; // 0x7C
		public int soul; // 0x80
		public int voice; // 0x84
		public int charm; // 0x88
		public int luck; // 0x8C
		public int fold; // 0x90
		public int support; // 0x94
		public int musicRatio; // 0x98
		public string login = ""; // 0x9C
		public string request = ""; // 0xA0
		public string comment = ""; // 0xA4
		public bool isKira; // 0xA8

		//public IiconTexture DivaTexture { get; } 0xBAA354
		//public IiconTexture SceneTexture { get; } 0xBAA35C

		// RVA: 0xBA4480 Offset: 0xBA4480 VA: 0xBA4480
		public FriendListInfo(short titleIndex, bool isAvailable, EAJCBFGKKFA_FriendInfo fri)
		{
			SetFriListInfo(titleIndex, isAvailable, fri);
			playerId = fri.MLPEHNBNOGD_Id;
			playerRank = fri.ILOJAJNCPEC_Rank;
			lastLogin = fri.PCEGKKLKFNO.AJECHDLMKOE_LastLogin;
			requestDate = fri.PCEGKKLKFNO.DHIFKMEFABP;
			emblemId = fri.NDOLELKAJNL_DegreeData.MDPKLNFFDBO_EmblemId;
			scoreRatingRank = fri.AGJIIKKOKFJ_ScoreRatingRank;
			musicRatio = fri.BJGOPOEAAIC_MusicRatio;
			if(fri.JIGONEMPPNP_Diva != null)
			{
				divaId = fri.JIGONEMPPNP_Diva.AHHJLDLAPAN_DivaId;
				divaModelId = fri.JIGONEMPPNP_Diva.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId;
				divaColorId = fri.JIGONEMPPNP_Diva.EKFONBFDAAP_ColorId;
			}
			isKira = false;
			skill = "";
			skillLevel = 0;
			skillRank = 0;
			if(fri.AFBMEMCHJCL_MainScene == null)
			{
				total = 0;
				charm = 0;
				luck = 0;
				fold = 0;
				support = 0;
				life = 0;
				soul = 0;
				voice = 0;
			}
			else
			{
				sceneId = fri.AFBMEMCHJCL_MainScene.BCCHOBPJJKE_SceneId;
				sceneRarity = fri.AFBMEMCHJCL_MainScene.EKLIPGELKCL_SceneRarity;
				sceneRank = fri.AFBMEMCHJCL_MainScene.CGIELKDLHGE_GetEvolveId();
				sceneLevel = fri.AFBMEMCHJCL_MainScene.CIEOBFIIPLD_SceneLevel;
				sceneAttr = (GameAttribute.Type)fri.AFBMEMCHJCL_MainScene.JGJFIJOCPAG_SceneAttr;
				sceneSeries = fri.AFBMEMCHJCL_MainScene.AIHCEGFANAM_SceneSeries;
				int skillId = fri.AFBMEMCHJCL_MainScene.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0);
				if(skillId != 0)
				{
					skill = fri.AFBMEMCHJCL_MainScene.PFHJFIHGCKP_CenterSkillName1;
					skillLevel = fri.AFBMEMCHJCL_MainScene.DDEDANKHHPN_SkillLevel;
					skillRank = (SkillRank.Type)fri.AFBMEMCHJCL_MainScene.DHEFMEGKKDN_CenterSkillRank;
				}
				luck = fri.AFBMEMCHJCL_MainScene.MJBODMOLOBC_Luck;
				total = fri.AFBMEMCHJCL_MainScene.CMCKNKKCNDK_Status.Total;
				life = fri.AFBMEMCHJCL_MainScene.CMCKNKKCNDK_Status.life;
				soul = fri.AFBMEMCHJCL_MainScene.CMCKNKKCNDK_Status.soul;
				voice = fri.AFBMEMCHJCL_MainScene.CMCKNKKCNDK_Status.vocal;
				charm = fri.AFBMEMCHJCL_MainScene.CMCKNKKCNDK_Status.charm;
				fold = fri.AFBMEMCHJCL_MainScene.CMCKNKKCNDK_Status.fold;
				support = fri.AFBMEMCHJCL_MainScene.CMCKNKKCNDK_Status.support;
				isKira = fri.AFBMEMCHJCL_MainScene.MBMFJILMOBP_IsKira();
			}
			login = JpStringLiterals.StringLiteral_16059 + fri.PCEGKKLKFNO.LFKJNMFFCLH_LastLoginString;
			if(requestDate != 0)
			{
				request = JpStringLiterals.StringLiteral_16060 + PIGBKEIAMPE_FriendManager.MKILKPFAOIC_GetLastLoginString(requestDate, NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
			}
			else
			{
				request = "";
			}
			comment = fri.FGMPKKOOGCM;
			isDivaLoad = false;
			isSceneLoad = false;
		}

		// RVA: 0xBAA364 Offset: 0xBAA364 VA: 0xBAA364
		public IiconTexture GetFriendDivaIconTex()
		{
			if(DivaIconTexture == null && !isDivaLoad)
			{
				GameManager.Instance.DivaIconCache.Load(divaId, divaModelId, divaColorId, FriendIconLoadCallback);
				isDivaLoad = true;
			}
			return DivaIconTexture;
		}

		// RVA: 0xBAA4B8 Offset: 0xBAA4B8 VA: 0xBAA4B8
		public IiconTexture GetFriendSceneIconTex()
		{
			if(SceneIconTexture == null && !isSceneLoad)
			{
				GameManager.Instance.SceneIconCache.Load(sceneId, sceneRank, FriendSceneIconLoadCallback);
				isSceneLoad =  true;
			}
			return SceneIconTexture;
		}

		//// RVA: 0xBAA604 Offset: 0xBAA604 VA: 0xBAA604
		public void FriendIconLoadCallback(IiconTexture tex)
		{
			DivaIconTexture = tex;
		}

		//// RVA: 0xBAA60C Offset: 0xBAA60C VA: 0xBAA60C
		public void FriendSceneIconLoadCallback(IiconTexture tex)
		{
			SceneIconTexture = tex;
		}

		//// RVA: 0xBAA614 Offset: 0xBAA614 VA: 0xBAA614
		//public bool IsReady() { }

		// RVA: 0xBAA634 Offset: 0xBAA634 VA: 0xBAA634 Slot: 4
		public override void TryInstall()
		{
			GameManager.Instance.DivaIconCache.TryInstall(divaId, divaModelId, divaColorId);
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
