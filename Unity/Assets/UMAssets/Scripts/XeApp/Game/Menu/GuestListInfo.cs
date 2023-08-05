using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class GuestListInfo : PlayerListInfo
	{
		public enum FriendListBunType
		{
			Btn_Ud_01 = 0,
			Btn_Ud_02 = 1,
			Btn_Item = 2,
			Btn_Max = 3,
		}

		private IiconTexture DivaIconTexture; // 0x18
		private IiconTexture SceneIconTexture; // 0x1C
		private bool isDivaLoad; // 0x20
		private bool isSceneLoad; // 0x21
		public int playerRank; // 0x24
		public long lastLogin; // 0x28
		public int divaId; // 0x30
		public int divaModelId; // 0x34
		public int divaColorId; // 0x38
		public int sceneId; // 0x3C
		public int episodeId; // 0x40
		public int sceneRank; // 0x44
		public int sceneRarity; // 0x48
		public int sceneLevel; // 0x4C
		public int emblemId; // 0x50
		public int musicRatio; // 0x54
		public HighScoreRatingRank.Type scoreRatingRank = HighScoreRatingRank.Type.Be; // 0x58
		public GameAttribute.Type sceneAttr; // 0x5C
		public SeriesAttr.Type sceneSeries; // 0x60
		public int total; // 0x64
		public string skill = ""; // 0x68
		public int skillLevel; // 0x6C
		public SkillRank.Type skillRank; // 0x70
		public int life; // 0x74
		public int soul; // 0x78
		public int voice; // 0x7C
		public int charm; // 0x80
		public int luck; // 0x84
		public int fold; // 0x88
		public int support; // 0x8C
		public bool Friend; // 0x90
		public bool isKira; // 0x91
		public int centerSkillRank; // 0x94
		public int centerSkillRank2; // 0x98
		public int limitOverCount; // 0x9C

		//public IiconTexture DivaTexture { get; } 0xE28828
		//public IiconTexture SceneTexture { get; } 0xE28830

		// RVA: 0xE28838 Offset: 0xE28838 VA: 0xE28838
		public GuestListInfo(short titleIndex, bool isAvailable, EEDKAACNBBG_MusicData musicData, EAJCBFGKKFA_FriendInfo fri)
		{
			SetFriListInfo(titleIndex, isAvailable, fri);
			playerRank = fri.ILOJAJNCPEC_Rank;
			lastLogin = fri.PCEGKKLKFNO.AJECHDLMKOE_LastLogin;
			musicRatio = fri.BJGOPOEAAIC_MusicRatio;
			scoreRatingRank = fri.AGJIIKKOKFJ_ScoreRatingRank;
			if(fri.JIGONEMPPNP_Diva != null)
			{
				divaId = fri.JIGONEMPPNP_Diva.AHHJLDLAPAN_DivaId;
				divaModelId = fri.JIGONEMPPNP_Diva.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId;
				divaColorId = fri.JIGONEMPPNP_Diva.EKFONBFDAAP_ColorId;
			}
			emblemId = fri.NDOLELKAJNL_DegreeData.MDPKLNFFDBO_EmblemId;
			isKira = false;
			skill = "";
			skillLevel = 0;
			skillRank = SkillRank.Type.None;
			GCIJNCFDNON_SceneInfo g = fri.KHGKPKDBMOH_GetAssistScene();
			if (g == null)
			{
				total = 0;
				charm = 0;
				luck = 0;
				fold = 0;
				support = 0;
				life = 0;
				soul = 0;
				voice = 0;
				charm = 0;
			}
			else
			{
				sceneId = g.BCCHOBPJJKE_SceneId;
				episodeId = g.KELFCMEOPPM_EpisodeId;
				sceneRarity = g.EKLIPGELKCL_SceneRarity;
				sceneRank = g.CGIELKDLHGE_GetEvolveId();
				sceneLevel = g.CIEOBFIIPLD_SceneLevel;
				sceneAttr = (GameAttribute.Type)g.JGJFIJOCPAG_SceneAttr;
				sceneSeries = g.AIHCEGFANAM_SceneSeries;
				int v = g.MEOOLHNNMHL_GetCenterSkillId(false, musicData == null ? 0 : musicData.FKDCCLPGKDK_JacketAttr, musicData == null ? 0 : musicData.AIHCEGFANAM_Serie);
				if(v != 0)
				{
					int v2 = g.MEOOLHNNMHL_GetCenterSkillId(true, 0, 0);
					skill = v == v2 ? g.EFELCLMJEOL_CenterSkillName2 : g.PFHJFIHGCKP_CenterSkillName1;
					skillLevel = g.DDEDANKHHPN_SkillLevel;
					skillRank = (SkillRank.Type)(v == v2 ? g.FFDCGHDNDFJ_CenterSkillRank2 : g.DHEFMEGKKDN_CenterSkillRank);
				}
				luck = g.MJBODMOLOBC_Luck;
				total = g.CMCKNKKCNDK_Status.Total;
				life = g.CMCKNKKCNDK_Status.life;
				soul = g.CMCKNKKCNDK_Status.soul;
				voice = g.CMCKNKKCNDK_Status.vocal;
				charm = g.CMCKNKKCNDK_Status.charm;
				fold = g.CMCKNKKCNDK_Status.fold;
				support = g.CMCKNKKCNDK_Status.support;
				isKira = g.MBMFJILMOBP_IsKira();
				centerSkillRank = g.DHEFMEGKKDN_CenterSkillRank;
				centerSkillRank2 = g.FFDCGHDNDFJ_CenterSkillRank2;
				limitOverCount = g.MKHFCGPJPFI_LimitOverCount;
			}
			isDivaLoad = false;
			Friend = fri.PCEGKKLKFNO.LHMDABPNDDH_Type == IBIGBMDANNM.LJJOIIAEICI.HEEJBCDDOJJ_Friend;
		}

		//// RVA: 0xE28CD8 Offset: 0xE28CD8 VA: 0xE28CD8
		public IiconTexture GetGuestDivaIconTex()
		{
			if(DivaIconTexture == null && !isDivaLoad)
			{
				GameManager.Instance.DivaIconCache.Load(divaId, divaModelId, divaColorId, GuestIconLoadCallback);
				isDivaLoad = true;
			}
			return DivaIconTexture;
		}

		//// RVA: 0xE28E28 Offset: 0xE28E28 VA: 0xE28E28
		public IiconTexture GetGuestSceneIconTex()
		{
			if(SceneIconTexture == null && !isSceneLoad)
			{
				GameManager.Instance.SceneIconCache.Load(sceneId, sceneRank, GuestSceneIconLoadCallback);
				isSceneLoad = true;
			}
			return SceneIconTexture;
		}

		//// RVA: 0xE28F74 Offset: 0xE28F74 VA: 0xE28F74
		public void GuestIconLoadCallback(IiconTexture tex)
		{
			DivaIconTexture = tex;
		}

		//// RVA: 0xE28F7C Offset: 0xE28F7C VA: 0xE28F7C
		public void GuestSceneIconLoadCallback(IiconTexture tex)
		{
			SceneIconTexture = tex;
		}

		//// RVA: 0xE28F84 Offset: 0xE28F84 VA: 0xE28F84
		//public bool IsReady() { }

		// RVA: 0xE28FA4 Offset: 0xE28FA4 VA: 0xE28FA4 Slot: 4
		public override void TryInstall()
		{
			GameManager.Instance.DivaIconCache.TryInstall(divaId, divaModelId, divaColorId);
			if(sceneId > 0)
			{
				GameManager.Instance.SceneIconCache.TryInstall(sceneId, sceneRank);
			}
			if(emblemId >= 2)
			{
				GameManager.Instance.ItemTextureCache.TryInstallEmblem(emblemId);
			}
		}
	}
}
