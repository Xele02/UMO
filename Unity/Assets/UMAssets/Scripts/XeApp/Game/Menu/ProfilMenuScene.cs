using System;
using System.Collections;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class ProfilMenuScene : TransitionRoot
	{
		private Action mUpdater; // 0x48
		private ProfilMenuLayout m_profil; // 0x4C
		private bool m_isCreateValkyrieAndCostumeList; // 0x50
		private bool m_isGotoTitle; // 0x51
		private int m_mainGunPower; // 0x54
		private int m_fanCount; // 0x58
		private int m_musicRank; // 0x5C

		// RVA: 0x9CF1A0 Offset: 0x9CF1A0 VA: 0x9CF1A0
		public bool IsFriend()
		{
			return m_profil != null && m_profil.IsFriend;
		}

		// RVA: 0x9CF258 Offset: 0x9CF258 VA: 0x9CF258 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			m_profil = transform.GetComponent<ProfilMenuLayout>();
		}

		// RVA: 0x9CF2EC Offset: 0x9CF2EC VA: 0x9CF2EC Slot: 5
		protected override void Start()
		{
			mUpdater = UpdateLoad;
		}

		// RVA: 0x9CF374 Offset: 0x9CF374 VA: 0x9CF374
		private void Update()
		{
			if (mUpdater != null)
				mUpdater();
		}

		//// RVA: 0x9CF388 Offset: 0x9CF388 VA: 0x9CF388
		private void UpdateLoad()
		{
			if (!m_profil.IsLoaded())
				return;
			IsReady = true;
			mUpdater = UpdateIdle;
		}

		//// RVA: 0x9CF448 Offset: 0x9CF448 VA: 0x9CF448
		private void UpdateIdle()
		{
			return;
		}

		// RVA: 0x9CF44C Offset: 0x9CF44C VA: 0x9CF44C Slot: 9
		protected override void OnStartEnterAnimation()
		{
			if (m_isGotoTitle)
				return;
			m_profil.Enter();
		}

		// RVA: 0x9CF484 Offset: 0x9CF484 VA: 0x9CF484 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_profil.IsPlaying();
		}

		// RVA: 0x9CF4B4 Offset: 0x9CF4B4 VA: 0x9CF4B4 Slot: 12
		protected override void OnStartExitAnimation()
		{
			base.OnStartExitAnimation();
			m_profil.Leave();
		}

		// RVA: 0x9CF4EC Offset: 0x9CF4EC VA: 0x9CF4EC Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_profil.IsPlaying();
		}

		// RVA: 0x9CF51C Offset: 0x9CF51C VA: 0x9CF51C Slot: 14
		protected override void OnDestoryScene()
		{
			base.OnDestoryScene();
			m_profil.OtherRelease();
		}

		// RVA: 0x9CF554 Offset: 0x9CF554 VA: 0x9CF554 Slot: 18
		protected override void OnPostSetCanvas()
		{
			return;
		}

		// RVA: 0x9CF558 Offset: 0x9CF558 VA: 0x9CF558 Slot: 16
		protected override void OnPreSetCanvas()
		{
			ProfilDateArgs a = null;
			if (Args != null && Args is ProfilDateArgs)
			{
				a = Args as ProfilDateArgs;
			}
			else if(ArgsReturn != null && ArgsReturn is ProfilDateArgs)
			{
				a = ArgsReturn as ProfilDateArgs;
			}
			m_isCreateValkyrieAndCostumeList = false;
			this.StartCoroutineWatched(Co_ProfileInit(a));
			m_profil.Out();
		}

		// RVA: 0x9CF738 Offset: 0x9CF738 VA: 0x9CF738 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			if(!m_isGotoTitle)
			{
				if(!KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				{
					if(m_isCreateValkyrieAndCostumeList)
					{
						return m_profil.IsLoadingImage();
					}
				}
				return false;
			}
			else
			{
				GotoTitle();
				return true;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FF3EC Offset: 0x6FF3EC VA: 0x6FF3EC
		//// RVA: 0x9CF690 Offset: 0x9CF690 VA: 0x9CF690
		private IEnumerator Co_ProfileInit(ProfilDateArgs a_arg)
		{
			bool _isFanEnable; // 0x24
			bool _isCannonEnable; // 0x25
			bool IsLobby; // 0x26
			NKOBMDPHNGP_EventRaidLobby lobbyController; // 0x28

			//0x9CFCC4
			bool t_is_end = false;
			bool t_is_error = false;
			_isFanEnable = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("deco_player_level", 0) > 0;
			_isCannonEnable = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.BLEDNLHJDEF_IsCannonEnabled();
			if(a_arg != null && !a_arg.isShowMyProfil)
			{
				a_arg.data.KLJNFJJMJMC(() =>
				{
					//0x9CF9A8
					m_profil.CostumeList = a_arg.data.ODNHGAJPEOM_CostumeList;
					m_profil.ValkyrieList = a_arg.data.EDEPBHCOHNF_ValkyrieList;
					m_profil.EmblemList = a_arg.data.ALJGLDBFFGJ_EmblemList;
					t_is_end = true;
				}, () =>
				{
					//0x9CFAEC
					t_is_error = true;
				}, false);
				//LAB_009d0034
				while(!t_is_end)
				{
					if (!t_is_error)
						yield return null;
					else
					{
						//LAB_009d109c
						m_isGotoTitle = true;
						yield break;
					}
				}
				m_mainGunPower = a_arg.data.PCEGKKLKFNO.AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.OENMBJEKJII_McPower;
				t_is_end = false;
				t_is_error = false;
				CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.NDDIOKIKCNA_GetFanCount(a_arg.data.PCEGKKLKFNO.MLPEHNBNOGD_Id, (int fanCount) =>
				{
					//0x9CFAF8
					m_fanCount = fanCount;
					t_is_end = true;
				}, () =>
				{
					//0x9CFB2C
					t_is_error = true;
				});
				while(!t_is_end)
				{
					if (!t_is_error)
						yield return null;
					else
					{
						//LAB_009d109c
						m_isGotoTitle = true;
						yield break;
					}
				}
				IsLobby = false;
				lobbyController = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/) as NKOBMDPHNGP_EventRaidLobby;
				if(lobbyController != null)
				{
					TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event");
				}
				t_is_end = false;
				t_is_error = false;
				CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.EKIJICIBGOG_GetBlacklist(true, () =>
				{
					//0x9CFB44
					t_is_end = true;
				}, (CACGCMBKHDI_Request error) =>
				{
					//0x9CFB50
					t_is_error = true;
				}, (CACGCMBKHDI_Request error) =>
				{
					//0x9CFB5C
					t_is_error = true;
				});
				//LAB_009d04bc
				while(!t_is_end)
				{
					if (!t_is_error)
						yield return null;
					else
					{
						//LAB_009d109c
						m_isGotoTitle = true;
						yield break;
					}
				}
				m_profil.Init(a_arg.data, IsLobby);
				m_profil.SetInfoTable(a_arg.infoType);
				m_profil.HiddenVisitButton(!a_arg.isFavorite);
				m_profil.SetFanCount(m_fanCount);
				m_profil.SetMainGunPower(m_mainGunPower);
				m_musicRank = OEGIPPCADNA.BFKAHKBKBJE(a_arg.data.PCEGKKLKFNO.AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.AILEOFKIELL_UtaRateRank, a_arg.data.PCEGKKLKFNO.AJECHDLMKOE_LastLogin);
				m_profil.SetMusicRanking(m_musicRank);
				m_profil.SetButtonType(a_arg.btnType);
				m_profil.SetPlayerInfoWindow(_isCannonEnable, _isFanEnable);
				lobbyController = null;
				//LAB_009d15fc
			}
			else
			{ 
				m_profil.CostumeList = CKFGMNAIBNG.NEOMKKIEMJJ(GameManager.Instance.ViewPlayerData.AHEFHIMGIBI_ServerSave, false, true);
				m_profil.ValkyrieList = PNGOLKLFFLH.NEOMKKIEMJJ(GameManager.Instance.ViewPlayerData.AHEFHIMGIBI_ServerSave, false);
				m_mainGunPower = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MHEAEGMIKIE_PublicStatus.OENMBJEKJII_McPower;
				t_is_end = false;
				t_is_error = false;
				CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.CCAOOIMEPAL_GetPlayerFanCount((int fanCount) =>
				{
					//0x9CFB68
					m_fanCount = fanCount;
					t_is_end = true;
				}, () =>
				{
					//0x9CFB9C
					t_is_error = true;
				});
				while (!t_is_end)
				{
					if (!t_is_error)
						yield return null;
					else
					{
						m_isGotoTitle = true;
						yield break;
					}
				}
				if (!m_isGotoTitle)
				{
					t_is_end = false;
					t_is_error = false;
					OEGIPPCADNA mng = OEGIPPCADNA.HHCJCDFCLOB;
					mng.MJFKJHJJLMN_GetUtaRateRank(0, false, () =>
					{
						//0x9CFC28
						m_musicRank = OEGIPPCADNA.BFKAHKBKBJE(mng.CDINKAANIAA, 0);
						t_is_end = true;
					}, () =>
					{
						//0x9CFBA8
						m_musicRank = 0;
						t_is_end  = true;
					}, () =>
					{
						//0x9CFBDC
						t_is_error = true;
					});
					while(!t_is_end)
					{
						if (!t_is_error)
							yield return null;
						else
						{
							//LAB_009d109c
							m_isGotoTitle = true;
							yield break;
						}
					}
				}
				m_profil.EmblemList.Clear();
				List<IAPDFOPPGND> embList = IAPDFOPPGND.FKDIMODKKJD(false);
				foreach(var emb in embList)
				{
					if(emb.EAHPLCJMPHD_EmblemPic > 0)
					{
						m_profil.EmblemList.Add(emb);
					}
				}
				m_profil.Init();
				m_profil.SetInfoTable(a_arg == null ? ProfilMenuLayout.InfoType.PLAYER : a_arg.infoType);
				m_profil.SetFanCount(m_fanCount);
				m_profil.SetMainGunPower(m_mainGunPower);
				m_profil.SetMusicRanking(m_musicRank);
				m_profil.SetButtonType(0);
				m_profil.SetPlayerInfoWindow(_isCannonEnable, _isFanEnable);
			}
			//LAB_009d15fc
			if(m_profil.CostumeList != null)
			{
				m_profil.CostumeList.Sort((CKFGMNAIBNG a, CKFGMNAIBNG b) =>
				{
					//0x9CF8DC
					int res = a.AHHJLDLAPAN_DivaId - b.AHHJLDLAPAN_DivaId;
					if (res == 0)
						res = a.JPIDIENBGKH_CostumeId - b.JPIDIENBGKH_CostumeId;
					return res;
				});
				for(int i = 0; i < m_profil.CostumeList.Count; i++)
				{
					int itemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume, m_profil.CostumeList[i].JPIDIENBGKH_CostumeId);
					KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(ItemTextureCache.MakeItemIconTexturePath(itemId, 0));
					for(int j = 0; j < m_profil.CostumeList[i].NLKGAAFBDFK(); j++)
					{
						KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(ItemTextureCache.MakeItemIconTexturePath(itemId, m_profil.CostumeList[i].LLJPMOIPBAG(j)));
					}
				}
			}
			if(m_profil.ValkyrieList != null)
			{
				for(int i = 0; i < m_profil.ValkyrieList.Count; i++)
				{
					int itemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie, m_profil.ValkyrieList[i].GPPEFLKGGGJ_ValkyrieId);
					KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(ItemTextureCache.MakeItemIconTexturePath(itemId, 0));
				}
			}
			if(m_profil.EmblemList != null)
			{
				for(int i = 0; i < m_profil.EmblemList.Count; i++)
				{
					int itemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem, m_profil.EmblemList[i].MDPKLNFFDBO_EmblemId);
					KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(ItemTextureCache.MakeItemIconTexturePath(itemId, 0));
				}
			}
			m_profil.SetTransitionUniqueId((TransitionUniqueId) MenuScene.Instance.GetCurrentScene().uniqueId);
			m_isCreateValkyrieAndCostumeList = true;
		}
	}
}
