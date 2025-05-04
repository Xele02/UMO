using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class MemberListInfo : PlayerListInfo
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
		private NKOBMDPHNGP_EventRaidLobby.ELKMKCNPDFO m_lobbyData; // 0x24
		public int playerId; // 0x28
		public int playerRank; // 0x2C
		public long lastLogin; // 0x30
		public int divaId; // 0x38
		public int divaModelId; // 0x3C
		public int divaColorId; // 0x40
		public int sceneId; // 0x44
		public int episodeId; // 0x48
		public int sceneRank; // 0x4C
		public int sceneRarity; // 0x50
		public int sceneLevel; // 0x54
		public int emblemId; // 0x58
		public int musicRatio; // 0x5C
		public HighScoreRatingRank.Type scoreRatingRank = HighScoreRatingRank.Type.Be; // 0x60
		public GameAttribute.Type sceneAttr; // 0x64
		public SeriesAttr.Type sceneSeries; // 0x68
		public int total; // 0x6C
		public string skill = ""; // 0x70
		public int skillLevel; // 0x74
		public SkillRank.Type skillRank; // 0x78
		public int life; // 0x7C
		public int soul; // 0x80
		public int voice; // 0x84
		public int charm; // 0x88
		public int luck; // 0x8C
		public int fold; // 0x90
		public int support; // 0x94
		public bool Friend; // 0x98
		public string comment = ""; // 0x9C
		public string login = ""; // 0xA0
		public int mcannonPower; // 0xA4
		public string mcannonPowerMes = ""; // 0xA8
		public int funCount; // 0xAC
		public string funCountMes = ""; // 0xB0
		public bool isFavorite; // 0xB4
		public bool isKira; // 0xB5

		// public IiconTexture DivaTexture { get; } 0xEC1598
		// public IiconTexture SceneTexture { get; } 0xEC15A0
		public NKOBMDPHNGP_EventRaidLobby.ELKMKCNPDFO LobbyData { get { return m_lobbyData; } private set { m_lobbyData = value; } } //0xEC15A8 0xEC15B0

		// RVA: 0xEC15B8 Offset: 0xEC15B8 VA: 0xEC15B8
		public MemberListInfo(short titleIndex, bool isAvailable, EAJCBFGKKFA_FriendInfo fri)
		{
			MessageBank bk = MessageManager.Instance.GetBank("master");
			SetFriListInfo(titleIndex, isAvailable, fri);
			playerRank = fri.ILOJAJNCPEC_Rank;
			lastLogin = fri.PCEGKKLKFNO.AJECHDLMKOE_LastLogin;
			musicRatio = fri.BJGOPOEAAIC_MusicRatio;
			scoreRatingRank = fri.AGJIIKKOKFJ_ScoreRatingRank;
			m_lobbyData = fri.PCEGKKLKFNO as NKOBMDPHNGP_EventRaidLobby.ELKMKCNPDFO;
			if(fri.JIGONEMPPNP_Diva != null)
			{
				divaId = fri.JIGONEMPPNP_Diva.AHHJLDLAPAN_DivaId;
				divaModelId = fri.JIGONEMPPNP_Diva.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId;
				divaColorId = fri.JIGONEMPPNP_Diva.EKFONBFDAAP_ColorId;
			}
			emblemId = fri.NDOLELKAJNL_DegreeData.MDPKLNFFDBO_EmblemId;
			skill = "";
			skillLevel = 0;
			skillRank = 0;
			isKira = false;
			playerId = fri.MLPEHNBNOGD_Id;
			if(fri.AFBMEMCHJCL_MainScene == null)
			{
				mcannonPower = 0;
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
				sceneId = fri.AFBMEMCHJCL_MainScene.BCCHOBPJJKE_SceneId;
				episodeId = fri.AFBMEMCHJCL_MainScene.KELFCMEOPPM_EpisodeId;
				sceneRarity = fri.AFBMEMCHJCL_MainScene.EKLIPGELKCL_SceneRarity;
				sceneRank = fri.AFBMEMCHJCL_MainScene.CGIELKDLHGE_GetEvolveId();
				sceneLevel = fri.AFBMEMCHJCL_MainScene.CIEOBFIIPLD_SceneLevel;
				sceneAttr = (GameAttribute.Type) fri.AFBMEMCHJCL_MainScene.JGJFIJOCPAG_SceneAttr;
				sceneSeries = fri.AFBMEMCHJCL_MainScene.AIHCEGFANAM_SceneSeries;
				int skillId = fri.AFBMEMCHJCL_MainScene.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0);
				if(skillId != 0)
				{
					skill = fri.AFBMEMCHJCL_MainScene.PFHJFIHGCKP_CenterSkillName1;
					skillLevel = fri.AFBMEMCHJCL_MainScene.DDEDANKHHPN_SkillLevel;
					skillRank = (SkillRank.Type) fri.AFBMEMCHJCL_MainScene.DHEFMEGKKDN_CenterSkillRank;
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
			comment = fri.FGMPKKOOGCM_Comment;
			login = string.Concat(JpStringLiterals.StringLiteral_16059, fri.PCEGKKLKFNO.LFKJNMFFCLH_LastLoginString);
			mcannonPower = m_lobbyData.NOEAJIJIIHK_McPower;
			mcannonPowerMes = mcannonPower.ToString();
			funCount = m_lobbyData.AGDBNNEAIIC_FanNum;
			isFavorite = m_lobbyData.BBNAEPGAMMA_IsFavorite;
			isDivaLoad = false;
			Friend = fri.PCEGKKLKFNO.LHMDABPNDDH_Type == IBIGBMDANNM.LJJOIIAEICI.HEEJBCDDOJJ_Friend;
		}

		// // RVA: 0xEC1C6C Offset: 0xEC1C6C VA: 0xEC1C6C
		public IiconTexture GetGuestDivaIconTex()
		{
			if(DivaIconTexture == null && !isDivaLoad)
			{
				GameManager.Instance.DivaIconCache.Load(divaId, divaModelId, divaColorId, GuestIconLoadCallback);
				isDivaLoad = true;
			}
			return DivaIconTexture;
		}

		// // RVA: 0xEC1DBC Offset: 0xEC1DBC VA: 0xEC1DBC
		public IiconTexture GetGuestSceneIconTex()
		{
			if(SceneIconTexture == null && !isSceneLoad)
			{
				GameManager.Instance.SceneIconCache.Load(sceneId, sceneRank, GuestSceneIconLoadCallback);
				isSceneLoad = true;
			}
			return SceneIconTexture;
		}

		// // RVA: 0xEC1F08 Offset: 0xEC1F08 VA: 0xEC1F08
		public void GuestIconLoadCallback(IiconTexture tex)
		{
			DivaIconTexture = tex;
		}

		// // RVA: 0xEC1F10 Offset: 0xEC1F10 VA: 0xEC1F10
		public void GuestSceneIconLoadCallback(IiconTexture tex)
		{
			SceneIconTexture = tex;
		}

		// // RVA: 0xEC1F18 Offset: 0xEC1F18 VA: 0xEC1F18
		// public bool IsReady() { }

		// // RVA: 0xEC1F38 Offset: 0xEC1F38 VA: 0xEC1F38
		// public void SetFavorite(bool isFun) { }

		// // RVA: 0xEC1F6C Offset: 0xEC1F6C VA: 0xEC1F6C
		public string GetBelongsGroupName()
		{
			NKOBMDPHNGP_EventRaidLobby ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			int a, b;
			ev.LHIIGAMEABL(m_lobbyData, out a, out b);
			return string.Format(bk.GetMessageByLabel("lobby_room_name_format"), ev.OFAKIAJNPDF(a) + JpStringLiterals.StringLiteral_367 + string.Format(bk.GetMessageByLabel("lobby_room_num_format"), b ));
		}

		// RVA: 0xEC21F0 Offset: 0xEC21F0 VA: 0xEC21F0 Slot: 4
		public override void TryInstall()
		{
			GameManager.Instance.DivaIconCache.TryInstall(divaId, divaModelId, divaColorId);
			if(sceneId > 0)
			{
				GameManager.Instance.SceneIconCache.TryInstall(sceneId, sceneRank);
			}
			if(emblemId < 2)
				return;
			GameManager.Instance.ItemTextureCache.TryInstallEmblem(emblemId);
		}
	}
}
