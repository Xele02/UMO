using mcrs;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class GuestListScene : TransitionRoot
	{
		private const float m_statusChangeSec = 3;
		private static readonly SortItem[] s_sortTypeList = new SortItem[14] { SortItem.Total, SortItem.Soul, SortItem.Voice, SortItem.Charm, SortItem.Rarity, SortItem.Level, SortItem.Life, SortItem.Support, SortItem.Fold, SortItem.Luck, SortItem.Episode, SortItem.LastPlayDate, SortItem.PlayerRunk, SortItem.HighScoreRating }; // 0x0
		private GeneralListButtonRuntime m_buttonRuntime; // 0x48
		private GuestListWindow m_windowUi; // 0x4C
		private List<GuestListElem> m_elems = new List<GuestListElem>(); // 0x50
		private SwapScrollList m_scrollList; // 0x54
		private List<DivaIconDecoration> m_divaDecos = new List<DivaIconDecoration>(); // 0x58
		private List<SceneIconDecoration> m_sceneDecos = new List<SceneIconDecoration>(); // 0x5C
		private AssistSelectButton m_assistButton; // 0x60
		private SortItem m_sortType; // 0x64
		private GeneralList.SortOrder m_sortOrder; // 0x68
		private AssistItem m_assistType; // 0x6C
		private uint m_seriesFilter; // 0x70
		private uint m_centerSkillFilter; // 0x74
		private bool m_saveDataDirty; // 0x78
		private List<EAJCBFGKKFA_FriendInfo> friends = new List<EAJCBFGKKFA_FriendInfo>(100); // 0x7C
		private List<GuestListInfo> m_guestInfoAllList = new List<GuestListInfo>(); // 0x80
		private List<GuestListInfo> m_guestInfoList = new List<GuestListInfo>(); // 0x84
		private TeamSlectSceneArgs m_teamSelectSceneArgs = new TeamSlectSceneArgs(); // 0x88
		private string m_guestNotFoundMessage; // 0x8C
		private string m_guestAllFilteredMessage; // 0x90
		private ElemStatusChange m_statusChange = new ElemStatusChange(); // 0x94
		private RankingSceneBase.WaitForFrame waitForFrame; // 0x98
		private bool m_monitorReloadCoolingTime; // 0x9C
		private bool m_isShowHelp; // 0x9D

		// RVA: 0xE291A8 Offset: 0xE291A8 VA: 0xE291A8 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			waitForFrame = new RankingSceneBase.WaitForFrame(3);
			m_statusChange.Setup(3.0f);
			m_statusChange.onChangeEvent = () =>
			{
				//0xE2DA20
				for(int i = 0; i < m_elems.Count; i++)
				{
					m_elems[i].SwapStatus(false);
				}
			};
			this.StartCoroutineWatched(Co_LoadResources());
		}

		// RVA: 0xE29350 Offset: 0xE29350 VA: 0xE29350 Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			Initialize();
			m_windowUi.Hide();
			m_buttonRuntime.Hide();
		}

		// RVA: 0xE29E98 Offset: 0xE29E98 VA: 0xE29E98 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return base.IsEndPreSetCanvas();
		}

		// RVA: 0xE29EA0 Offset: 0xE29EA0 VA: 0xE29EA0 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			m_windowUi.transform.SetAsLastSibling();
			m_buttonRuntime.transform.SetAsLastSibling();
			return true;
		}

		// RVA: 0xE29F34 Offset: 0xE29F34 VA: 0xE29F34 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_buttonRuntime.Enter();
			m_windowUi.Enter();
			m_assistButton.Enter();
		}

		// RVA: 0xE2A01C Offset: 0xE2A01C VA: 0xE2A01C Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_buttonRuntime.IsPlaying() && !m_windowUi.IsPlaying();
		}

		// RVA: 0xE2A0A4 Offset: 0xE2A0A4 VA: 0xE2A0A4 Slot: 23
		protected override void OnActivateScene()
		{
			base.OnActivateScene();
			m_isShowHelp = false;
			InitializeList();
			this.StartCoroutineWatched(Co_ShowHelp());
		}

		// RVA: 0xE2A468 Offset: 0xE2A468 VA: 0xE2A468
		private void Update()
		{
			m_statusChange.Update();
			if (!m_monitorReloadCoolingTime)
				return;
			m_buttonRuntime.SetReloadButtonLock(CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.CDOBDJFJLPG_GetRecheckTime() > 0);
		}

		// RVA: 0xE2A584 Offset: 0xE2A584 VA: 0xE2A584 Slot: 14
		protected override void OnDestoryScene()
		{
			for(int i = 0; i < m_divaDecos.Count; i++)
			{
				m_divaDecos[i].Release();
			}
			m_divaDecos.Clear();
			for (int i = 0; i < m_sceneDecos.Count; i++)
			{
				m_sceneDecos[i].Release();
			}
			m_sceneDecos.Clear();
		}

		// RVA: 0xE2A72C Offset: 0xE2A72C VA: 0xE2A72C Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_statusChange.Deactivate();
			m_monitorReloadCoolingTime = false;
			m_buttonRuntime.Leave();
			m_windowUi.Leave();
			m_assistButton.Leave();
		}

		// RVA: 0xE2A83C Offset: 0xE2A83C VA: 0xE2A83C Slot: 13
		protected override bool IsEndExitAnimation()
		{
			if(!m_buttonRuntime.IsPlaying() && !m_windowUi.IsPlaying() && !m_assistButton.IsPlaying())
			{
				if(m_saveDataDirty)
				{
					GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
				}
				return base.IsEndExitAnimation();
			}
			return false;
		}

		// RVA: 0xE2A990 Offset: 0xE2A990 VA: 0xE2A990
		//private bool CheckTransitByReturn() { }

		// RVA: 0xE2A9C8 Offset: 0xE2A9C8 VA: 0xE2A9C8
		protected bool CheckEventLimit()
		{
			if(!MenuScene.CheckDatelineAndAssetUpdate())
			{
				if(Database.Instance.gameSetup.musicInfo.gameEventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL/*0*/)
				{
					TodoLogger.Log(0, "CheckEventLimit");
				}
				return false;
			}
			return true;
		}

		// RVA: 0xE2AD40 Offset: 0xE2AD40 VA: 0xE2AD40
		//private AssistItem GameAttributeToAssisItem(GameAttribute.Type attr) { }

		// RVA: 0xE293AC Offset: 0xE293AC VA: 0xE293AC
		private void Initialize()
		{
			ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.MMALELPFEBH_UserList guestInfo = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.GDMIGCCMEEF_GuestSelect;
			m_sortType = (SortItem)guestInfo.LHPDCGNKPHD_sortItem;
			m_sortOrder = (GeneralList.SortOrder)guestInfo.EILKGEADKGH_order;
			m_seriesFilter = (uint)guestInfo.BBIIHLNBHDE_seriaseFilter;
			m_centerSkillFilter = (uint)guestInfo.LKPCKPJGJKN_centerSkillFilter;
			if(PrevTransition == TransitionList.Type.TEAM_SELECT || PrevTransition == TransitionList.Type.PROFIL || PrevTransition == TransitionList.Type.GODIVA_TEAM_SELECT)
			{
				;
			}
			else
			{
				guestInfo.NPEEPPCPEPE_assistItem = Database.Instance.selectedMusic.GetSelectedMusicData().FKDCCLPGKDK_JacketAttr < 5 ? new int[5] { 4, 1, 2, 3, 4 }[Database.Instance.selectedMusic.GetSelectedMusicData().FKDCCLPGKDK_JacketAttr] : 0;
			}
			m_assistType = (AssistItem)guestInfo.NPEEPPCPEPE_assistItem;
			if(TutorialProc.CanBeginnerAssistSelect())
			{
				m_sortOrder = GeneralList.SortOrder.Descend;
				m_sortType = SortItem.Rarity;
			}
			m_divaDecos.Capacity = m_elems.Count;
			m_sceneDecos.Capacity = m_elems.Count;
			for(int i = 0; i < m_elems.Count; i++)
			{
				m_divaDecos.Add(new DivaIconDecoration(m_elems[i].GetDivaIconObject(), DivaIconDecoration.Size.S, false, true, null, null));
				m_sceneDecos.Add(new SceneIconDecoration(m_elems[i].GetSceneIconObject(), SceneIconDecoration.Size.M, null, null));
			}
			m_assistButton.OnClickButtonLisner = this.OnShowAssistSelectButton;
			m_buttonRuntime.ChangePreset(0);
			m_buttonRuntime.SetSortType(m_sortType);
			m_buttonRuntime.SetSortOrder(m_sortOrder);
			m_buttonRuntime.onClickSortButton = this.OnClickSortButton;
			m_buttonRuntime.onClickOrderButton = this.OnClickOrderButton;
			m_buttonRuntime.onClickReloadButton = this.OnClickReloadButton;
			m_windowUi.SetMessageVisible(false);
			m_windowUi.SetCautionVisible(false);
			m_windowUi.SetCounterStyle(GuestListWindow.CounterStyle.None);
			m_guestNotFoundMessage = string.Empty;
			m_guestAllFilteredMessage = string.Empty;
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				m_scrollList.ScrollObjects[i].ClickButton.RemoveAllListeners();
				m_scrollList.ScrollObjects[i].ClickButton.AddListener(this.OnSelectListItem);
			}
			m_statusChange.Activate(false);
			for(int i = 0; i < m_elems.Count; i++)
			{
				m_elems[i].ChangeStatus(true, true);
			}
			m_monitorReloadCoolingTime = true;
			if ((PrevTransition != TransitionList.Type.TEAM_SELECT && PrevTransition != TransitionList.Type.PROFIL && PrevTransition != TransitionList.Type.GODIVA_TEAM_SELECT) || friends.Count < 1)
			{
				m_scrollList.SetItemCount(0);
				m_scrollList.VisibleRegionUpdate();
			}
		}

		// RVA: 0xE2A0E4 Offset: 0xE2A0E4 VA: 0xE2A0E4
		private void InitializeList()
		{
			if (PrevTransition != TransitionList.Type.TEAM_SELECT && PrevTransition != TransitionList.Type.PROFIL && PrevTransition != TransitionList.Type.GODIVA_TEAM_SELECT)
			{
				m_scrollList.SetItemCount(0);
				m_scrollList.VisibleRegionUpdate();
				SearchFriend();
			}
			else if (friends.Count > 0)
			{
				m_scrollList.VisibleRegionUpdate();
			}
			else
			{
				List<IBIGBMDANNM> l = CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.BFDEHIANFOG;
				for (int i = 0; i < l.Count; i++)
				{
					EAJCBFGKKFA_FriendInfo data = new EAJCBFGKKFA_FriendInfo();
					data.KHEKNNFCAOI(l[i]);
					friends.Add(data);
				}
				MenuScene.Instance.InputDisable();
				this.StartCoroutineWatched(OnSuccessSearchFriend());
			}
		}

		// RVA: 0xE2A588 Offset: 0xE2A588 VA: 0xE2A588
		//private void Release() { }

		// RVA: 0xE2B498 Offset: 0xE2B498 VA: 0xE2B498
		private void OnSelectListItem(int value, SwapScrollListContent content)
		{
			if (value == 1)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				ProfilDateArgs arg = new ProfilDateArgs();
				arg.data = m_guestInfoList[content.Index].friend;
				arg.infoType = ProfilMenuLayout.InfoType.ASSIST;
				MenuScene.Instance.Call(TransitionList.Type.PROFIL, arg, true);
			}
			else if(value == 0)
			{
				OnClickElemButton(content.Index);
			}
		}

		// RVA: 0xE2AFC0 Offset: 0xE2AFC0 VA: 0xE2AFC0
		private void SearchFriend()
		{
			PIGBKEIAMPE_FriendManager friendManager = CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager;
			MenuScene.Instance.InputDisable();
			friends.Clear();
			EMOLDNAEDMG query = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.BHDJIIHLMDM_Query[1].MGCBIOALLFE(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave);
			EMOLDNAEDMG query2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.BHDJIIHLMDM_Query[0].MGCBIOALLFE(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave);
			EMOLDNAEDMG query3 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.BHDJIIHLMDM_Query[2].MGCBIOALLFE(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave);
			friendManager.CHAILEPDOPJ(query, query2, query3, () =>
			{
				//0xE2DFEC
				UnityEngine.Debug.Log(JpStringLiterals.StringLiteral_16339 + friendManager.BFDEHIANFOG.Count);
				for(int i = 0; i < friendManager.BFDEHIANFOG.Count; i++)
				{
					EAJCBFGKKFA_FriendInfo data = new EAJCBFGKKFA_FriendInfo();
					data.KHEKNNFCAOI(friendManager.BFDEHIANFOG[i]);
					friends.Add(data);
				}
				this.StartCoroutineWatched(OnSuccessSearchFriend());
			}, (CACGCMBKHDI_Request error) =>
			{
				//0xE2DF0C
				UnityEngine.Debug.Log(JpStringLiterals.StringLiteral_16338);
				MenuScene.Instance.InputEnable();
			}, (CACGCMBKHDI_Request error) =>
			{
				//0xE2E250
				TodoLogger.Log(0, "Error friend request");
			});

		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E0CD4 Offset: 0x6E0CD4 VA: 0x6E0CD4
		// RVA: 0xE2AF34 Offset: 0xE2AF34 VA: 0xE2AF34
		private IEnumerator OnSuccessSearchFriend()
		{
			//0xE2F8D0
			m_guestInfoAllList.Clear();
			for(int i = 0; i < friends.Count; i++)
			{
				GuestListInfo data = new GuestListInfo((short)i, true, Database.Instance.selectedMusic.GetSelectedMusicData(), friends[i]);
				m_guestInfoAllList.Add(data);
				data.TryInstall();
			}
			waitForFrame.Reset();
			yield return waitForFrame;

			while (KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			SortGuestList();
			MenuScene.Instance.InputEnable();
			if(TutorialProc.CanBeginnerAssistSelect())
			{
				GuestListElem elem = m_scrollList.ScrollContent.GetComponentInChildren<GuestListElem>(true);
				if(elem != null)
				{
					this.StartCoroutineWatched(TutorialProc.Co_AssistSelect(elem.Button));
				}
			}
			m_isShowHelp = true;
		}

		// RVA: 0xE2B69C Offset: 0xE2B69C VA: 0xE2B69C
		private void OnClickElemButton(int elemIndex)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			if(!CheckEventLimit())
			{
				GameManager.Instance.SelectedGuestData = m_guestInfoList[elemIndex].friend;
				MenuScene.Instance.Call(TransitionList.Type.TEAM_SELECT, m_teamSelectSceneArgs, true);
			}
		}

		// RVA: 0xE2B87C Offset: 0xE2B87C VA: 0xE2B87C
		private void OnClickSortButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.ShowSortWindow(PopupSortMenu.SortPlace.GuestSelect, (PopupSortMenu popup) =>
			{
				//0xE2DB0C
				MenuScene.Instance.InputDisable();
				m_sortType = popup.SortItem;
				m_assistType = popup.AssistItem;
				m_seriesFilter = popup.GetSeriaseFilter();
				m_centerSkillFilter = popup.GetCenterSkillFilter();
				m_buttonRuntime.SetSortType(m_sortType);
				this.StartCoroutineWatched(OnSuccessSearchFriend());
			}, null);
		}

		// RVA: 0xE2B9C4 Offset: 0xE2B9C4 VA: 0xE2B9C4
		//private void OnClickSortNextButton() { }

		// RVA: 0xE2C1DC Offset: 0xE2C1DC VA: 0xE2C1DC
		private void OnClickOrderButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_sortOrder = m_sortOrder == GeneralList.SortOrder.Ascend ? GeneralList.SortOrder.Descend : GeneralList.SortOrder.Ascend;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.GDMIGCCMEEF_GuestSelect.EILKGEADKGH_order = (int)m_sortOrder;
			m_saveDataDirty = true;
			m_buttonRuntime.SetSortOrder(m_sortOrder);
			SortGuestList();
		}

		// RVA: 0xE2C378 Offset: 0xE2C378 VA: 0xE2C378
		private void OnClickReloadButton()
		{
			TodoLogger.LogNotImplemented("OnClickReloadButton");
		}

		// RVA: 0xE2BCA8 Offset: 0xE2BCA8 VA: 0xE2BCA8
		private void SortGuestList()
		{
			m_guestInfoAllList.Sort(SortDelegate);
			m_guestInfoList.Clear();
			m_guestInfoList.Capacity = m_guestInfoAllList.Count;
			for(int i = 0; i < m_guestInfoAllList.Count; i++)
			{
				if(PopupSortMenu.IsSerializeFilterOn((int)m_guestInfoAllList[i].sceneSeries, m_seriesFilter))
				{
					if (PopupSortMenu.IsSkillRankFilterOn(m_guestInfoAllList[i].centerSkillRank, m_guestInfoAllList[i].centerSkillRank2, m_centerSkillFilter))
					{
						if (m_assistType == (m_guestInfoAllList[i].sceneAttr < GameAttribute.Type.All ? new AssistItem[4] { AssistItem.None, AssistItem.Yellow, AssistItem.Red, AssistItem.Blue }[(int)m_guestInfoAllList[i].sceneAttr] : AssistItem.Free) 
							|| m_assistType == AssistItem.None || m_assistType == AssistItem.Free)
						{
							m_guestInfoList.Add(m_guestInfoAllList[i]);
						}
					}
				}
			}
			if(m_guestInfoList.IsEmpty())
			{
				m_windowUi.SetMessageVisible(true);
				m_windowUi.SetMessage(m_guestInfoAllList.IsEmpty() ? m_guestNotFoundMessage : m_guestAllFilteredMessage);
			}
			else
			{
				m_windowUi.SetMessageVisible(false);
			}
			m_scrollList.SetItemCount(m_guestInfoList.Count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener((int index, SwapScrollListContent content) =>
			{
				//0xE2DCA0
				OnUpdateListItem(index, content as GeneralListContent, m_guestInfoList[index]);
			});
			m_scrollList.SetPosition(0, 0, 0, false);
			m_scrollList.VisibleRegionUpdate();
		}

		// RVA: 0xE2C45C Offset: 0xE2C45C VA: 0xE2C45C
		private int SortDelegate(GuestListInfo a, GuestListInfo b)
		{
			int res = 0;
			switch(m_sortType)
			{
				case SortItem.Total:
					res = a.total.CompareTo(b.total);
					break;
				case SortItem.Soul:
					res = a.soul.CompareTo(b.soul);
					break;
				case SortItem.Voice:
					res = a.voice.CompareTo(b.voice);
					break;
				case SortItem.Charm:
					res = a.charm.CompareTo(b.charm);
					break;
				default:
					break;
				case SortItem.Rarity:
					res = a.sceneRarity.CompareTo(b.sceneRarity);
					break;
				case SortItem.Level:
					res = a.sceneLevel.CompareTo(b.sceneLevel);
					break;
				case SortItem.Life:
					res = a.life.CompareTo(b.life);
					break;
				case SortItem.Luck:
					res = a.luck.CompareTo(b.luck);
					break;
				case SortItem.Support:
					res = a.support.CompareTo(b.support);
					break;
				case SortItem.Fold:
					res = a.fold.CompareTo(b.fold);
					break;
				case SortItem.LastPlayDate:
					res = a.lastLogin.CompareTo(b.lastLogin);
					break;
				case SortItem.PlayerRunk:
					res = a.playerRank.CompareTo(b.playerRank);
					break;
				case SortItem.Episode:
					{
						if (a.episodeId == 0 && b.episodeId == 0)
							break;
						if (a.episodeId == 0)
							res = 1;
						else if (b.episodeId == 0)
							res = -1;
						else
							res = a.episodeId.CompareTo(b.episodeId);
					}
					break;
				case SortItem.HighScoreRating:
					res = a.musicRatio.CompareTo(b.musicRatio);
					break;
				case SortItem.LuckyLeaf:
					res = a.limitOverCount.CompareTo(b.limitOverCount);
					break;
			}
			//switchD_00e2c494_caseD_4;
			if(res == 0)
			{
				res = GetBaseRaritySortValue(a, b);
				if (res == 0)
				{
					res = b.sceneId.CompareTo(a.sceneId);
					if(res == 0)
					{
						res = a.ListIndex.CompareTo(b.ListIndex);
					}
				}
				return res;
			}
			if (m_sortOrder == GeneralList.SortOrder.Descend)
				res = -res;
			return res;
		}

		// RVA: 0xE2C908 Offset: 0xE2C908 VA: 0xE2C908
		private int GetBaseRaritySortValue(GuestListInfo a, GuestListInfo b)
		{
			int res = (a.friend.KHGKPKDBMOH_GetAssistScene() != null ? a.friend.KHGKPKDBMOH_GetAssistScene().JKGFBFPIMGA_Rarity : 0).CompareTo(b.friend.KHGKPKDBMOH_GetAssistScene() != null ? b.friend.KHGKPKDBMOH_GetAssistScene().JKGFBFPIMGA_Rarity : 0);
			if(res == 0)
			{
				res = (a.friend.KHGKPKDBMOH_GetAssistScene() != null ? a.friend.KHGKPKDBMOH_GetAssistScene().EKLIPGELKCL_SceneRarity : 0).CompareTo(b.friend.KHGKPKDBMOH_GetAssistScene() != null ? b.friend.KHGKPKDBMOH_GetAssistScene().EKLIPGELKCL_SceneRarity : 0);
			}
			return res;
		}

		// RVA: 0xE2C9C0 Offset: 0xE2C9C0 VA: 0xE2C9C0
		private void OnUpdateListItem(int index, GeneralListContent content, GuestListInfo info)
		{
			GuestListElem elem = content.GetElemUI<GuestListElem>();
			elem.SetName(info.name);
			elem.SetLevel(info.playerRank.ToString());
			elem.SetTotal(info.total.ToString());
			elem.SetSkill(info.skill);
			elem.SetSkillLevel(info.skillLevel);
			elem.SetSkillRank(info.skillRank);
			elem.SetLife(info.life.ToString());
			elem.SetLuck(UnitWindowConstant.MakeLuckText(info.luck));
			elem.SetSoul(info.soul.ToString());
			elem.SetVoice(info.voice.ToString());
			elem.SetCharm(info.charm.ToString());
			elem.SetFold(info.fold.ToString());
			elem.SetSupport(info.support.ToString());
			elem.SetMusicRatio(info.musicRatio.ToString());
			elem.SetMusicRank(info.scoreRatingRank);
			elem.SetMusicRateRank(info.friend.PCEGKKLKFNO);
			elem.ToggleMusicRatio(m_sortType);
			elem.SetKira(info.isKira);
			if(info.sceneId < 1)
			{
				elem.SetSkillMask(GuestListElem.SkillMask.None);
			}
			else
			{
				GCIJNCFDNON_SceneInfo g = new GCIJNCFDNON_SceneInfo();
				g.KHEKNNFCAOI(info.sceneId, null, null);
				if(g.KAFAAPEBCPD_IsMatchCenterSkillMusicAttr(Database.Instance.gameSetup.musicInfo.musicId))
				{
					elem.SetSkillMask(GuestListElem.SkillMask.None);
				}
				else if(g.JDAEAJNJBGI_IsMatchCenterSkillSerie(Database.Instance.gameSetup.musicInfo.musicId))
				{
					elem.SetSkillMask(GuestListElem.SkillMask.MisMatchSeries);
				}
				else
				{
					elem.SetSkillMask(GuestListElem.SkillMask.MisMatchAttr);
				}
			}
			elem.SetDivaIconDelegate(info.GetGuestDivaIconTex);
			elem.SetSceneIconDelegate(info.GetGuestSceneIconTex);
			DivaIconDecoration di = m_divaDecos[m_elems.IndexOf(elem)];
			di.SetActive(true);
			di.Change(info.friend.JIGONEMPPNP_Diva, info.friend, DisplayType.Level, info.friend.KHGKPKDBMOH_GetAssistScene());
			SceneIconDecoration si = m_sceneDecos[m_elems.IndexOf(elem)];
			si.SetActive(true);
			si.Change(info.friend.KHGKPKDBMOH_GetAssistScene(), m_sortType == SortItem.Episode ? DisplayType.EpisodeName : DisplayType.Level);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E0D4C Offset: 0x6E0D4C VA: 0x6E0D4C
		// RVA: 0xE2A3DC Offset: 0xE2A3DC VA: 0xE2A3DC
		private IEnumerator Co_ShowHelp()
		{
			//0xE2F644
			while (!m_isShowHelp)
				yield return null;
			MenuScene.Instance.InputDisable();
			yield return TutorialManager.TryShowTutorialCoroutine(CheckTutorialCondition);
			MenuScene.Instance.InputEnable();
			yield return null;
		}

		// RVA: 0xE2D13C Offset: 0xE2D13C VA: 0xE2D13C
		private bool CheckTutorialCondition(TutorialConditionId conditionId)
		{
			return conditionId == TutorialConditionId.Condition88 && IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.OANJBOPLCKP_IsUnit5Enabled() && !QuestUtility.IsBeginnerQuest() && !GameManager.Instance.IsTutorial;
		}

		// RVA: 0xE2D2C8 Offset: 0xE2D2C8 VA: 0xE2D2C8
		private void OnShowAssistSelectButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			ProfilDateArgs arg = new ProfilDateArgs();
			arg.infoType = ProfilMenuLayout.InfoType.ASSIST;
			arg.isShowMyProfil = true;
			MenuScene.Instance.Call(TransitionList.Type.PROFIL, arg, true);
		}

		// RVA: 0xE2D41C Offset: 0xE2D41C VA: 0xE2D41C Slot: 28
		protected override TransitionArgs GetCallArgsReturn()
		{
			OHCAABOMEOF.KGOGMKMBCPP_EventType eventType = Database.Instance.gameSetup.musicInfo.gameEventType;
			if(eventType < OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB)
			{
				if(eventType > OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest || 
				((1 << (int)eventType) & 78) == 0)
				{
					return base.GetCallArgsReturn();
				}
			}
			else
			{
				if(eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
				{
					TodoLogger.Log(0, "GetCallArgsReturn Event");
				}
				if(eventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
				{
					return base.GetCallArgsReturn();
				}
			}
			TodoLogger.Log(0, "GetCallArgsReturn Event");
			return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E0DC4 Offset: 0x6E0DC4 VA: 0x6E0DC4
		//// RVA: 0xE292C4 Offset: 0xE292C4 VA: 0xE292C4
		private IEnumerator Co_LoadResources()
		{
			//0xE2F51C
			yield return Co.R(Co_LoadLayout());
			IsReady = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E0E3C Offset: 0x6E0E3C VA: 0x6E0E3C
		//// RVA: 0xE2D71C Offset: 0xE2D71C VA: 0xE2D71C
		private IEnumerator Co_LoadLayout()
		{
			StringBuilder bundleName; // 0x18
			Font systemFont; // 0x1C
			int bundleLoadCount; // 0x20
			AssetBundleLoadLayoutOperationBase operation; // 0x24
			AssetBundleLoadUGUIOperationBase uguiOperation; // 0x28
			int poolSize; // 0x2C
			int i; // 0x30

			//0xE2E8B8
			bundleName = new StringBuilder(64);
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/039.xab");
			bundleLoadCount = 0;

			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_GeneralListButton");
			yield return Co.R(operation);

			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xE2E3BC
				instance.transform.SetParent(transform, false);
				m_buttonRuntime = instance.GetComponent<GeneralListButtonRuntime>();
			}));
			bundleLoadCount++;

			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_GuestListWindow");
			yield return Co.R(operation);

			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xE2E4B8
				instance.transform.SetParent(transform, false);
				m_windowUi = instance.GetComponent<GuestListWindow>();
				m_scrollList = instance.GetComponentInChildren<SwapScrollList>(true);
			}));
			bundleLoadCount++;

			uguiOperation = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "UGUI_AssistButton");
			yield return Co.R(uguiOperation);

			yield return Co.R(uguiOperation.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xE2E5FC
				instance.transform.SetParent(transform, false);
				m_assistButton = instance.GetComponent<AssistSelectButton>();
			}));
			bundleLoadCount++;

			poolSize = m_scrollList.ScrollObjectCount;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_GuestListElem");
			yield return Co.R(operation);

			LayoutUGUIRuntime baseRuntime = null;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xE2E6F8
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				baseRuntime.name = string.Format("GuestListElem {0:D2}", 0);
				m_scrollList.AddScrollObject(baseRuntime.GetComponent<SwapScrollListContent>());
				m_elems.Add(baseRuntime.GetComponent<GuestListElem>());
			}));
			bundleLoadCount++;

			for(i = 1; i < poolSize; i++)
			{
				LayoutUGUIRuntime runtime = Instantiate(baseRuntime);
				runtime.name = string.Format("GuestListElem {0:D2}", i);
				runtime.IsLayoutAutoLoad = false;
				runtime.Layout = baseRuntime.Layout.DeepClone();
				runtime.UvMan = baseRuntime.UvMan;
				runtime.LoadLayout();
				m_scrollList.AddScrollObject(runtime.GetComponent<SwapScrollListContent>());
				m_elems.Add(runtime.GetComponent<GuestListElem>());
			}
			for(i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			m_scrollList.Apply();
			m_scrollList.SetContentEscapeMode(true);
			while (!m_buttonRuntime.IsLoaded() && !m_windowUi.IsLoaded())
				yield return null;
			for(i = 0; i < m_elems.Count; i++)
			{
				while (!m_elems[i].IsLoaded())
					yield return null;
			}
		}
		
		//[CompilerGeneratedAttribute] // RVA: 0x6E0ED4 Offset: 0x6E0ED4 VA: 0x6E0ED4
		//// RVA: 0xE2DC8C Offset: 0xE2DC8C VA: 0xE2DC8C
		//private bool <OnClickSortNextButton>b__47_0(SortItem _) { }
	}
}
