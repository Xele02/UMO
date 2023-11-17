using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using CriWare;
using XeSys;
using System.Collections;
using mcrs;
using System.Text;

namespace XeApp.Game.Menu
{
	public class OfferSelectContent : SwapScrollListContent
	{
		public enum OrderButtonState
		{
			ORDER = 0,
			PROGRESS = 1,
			DONE = 2,
			COMPLETE = 3,
		}

		private enum NewState
		{
			NONE = 0,
			CROSS_FADE = 1,
			FLASHING = 2,
			FIXED = 3,
		}

		public const int BUTTON_SATE_MAX = 3;
		private const int FAST_COUNT_TIME = 2;
		private const float FAST_COUNT_END_WAIT_TIME = 0.3f;
		private const int MAX_COMP_ITEM_COUNT = 3;
		private const int MAX_OFFER_LEVEL = 5;
		[SerializeField]
		private ActionButton[] ExecuBtn = new ActionButton[3]; // 0x20
		[SerializeField]
		private RawImageEx SeriesIcon; // 0x24
		[SerializeField]
		private RawImageEx SeriesLogo; // 0x28
		[SerializeField]
		private RawImageEx[] ItemIconList = new RawImageEx[3]; // 0x2C
		[SerializeField]
		private NumberBase[] ItemIconNumList = new NumberBase[3]; // 0x30
		[SerializeField]
		private ActionButton[] ItemIconButtonList = new ActionButton[3]; // 0x34
		[SerializeField]
		private RawImageEx ItemIconSp; // 0x38
		[SerializeField]
		private ActionButton ItemIconSpButton; // 0x3C
		[SerializeField]
		private Text ClearTime; // 0x40
		[SerializeField]
		private Text AfterClearTime; // 0x44
		[SerializeField]
		private Text OfferName; // 0x48
		[SerializeField]
		private Text OfferDeadLine; // 0x4C
		[SerializeField]
		private Text DivaName; // 0x50
		[SerializeField]
		private List<NumberBase> GetItemNum = new List<NumberBase>(); // 0x54
		[SerializeField]
		private RawImageEx EventIcon; // 0x58
		private AbsoluteLayout[] ItemIconAnimList = new AbsoluteLayout[3]; // 0x5C
		private AbsoluteLayout ItemIconSpAnim; // 0x60
		private AbsoluteLayout m_offerType; // 0x64
		private AbsoluteLayout OfferLevel; // 0x68
		private AbsoluteLayout OfferLevelMax; // 0x6C
		private AbsoluteLayout OfferEventIcon; // 0x70
		private AbsoluteLayout OfferClearIcon; // 0x74
		private AbsoluteLayout OfferButtonState; // 0x78
		private AbsoluteLayout OfferDebutIcon; // 0x7C
		private AbsoluteLayout OfferLogoState; // 0x80
		private AbsoluteLayout OfferNewIcon; // 0x84
		private AbsoluteLayout OfferNewLoopAnim; // 0x88
		private AbsoluteLayout OfferCategory; // 0x8C
		private AbsoluteLayout m_DivaIcon; // 0x90
		private AbsoluteLayout m_contentFram; // 0x94
		private AbsoluteLayout[] m_levelIcon = new AbsoluteLayout[6]; // 0x98
		private AbsoluteLayout m_newAnimation; // 0x9C
		private TexUVList m_texUvList_3; // 0xA0
		private TexUVList m_texUvList_1; // 0xA4
		public OrderButtonState buttonState; // 0xA8
		private HEFCLPGPMLK.AAOPGOGGMID m_view; // 0xAC
		private LimitTimeWatcher m_timeWatcher = new LimitTimeWatcher(); // 0xB0
		private LimitTimeWatcher m_DivaTimeWatcher = new LimitTimeWatcher(); // 0xB4
		private long m_currentRemainingTime; // 0xB8
		private AbsoluteLayout DebutIcon; // 0xC0
		private bool IsStartTimeWatcher; // 0xC4
		private Action ListUpdateStart; // 0xC8
		private bool IsBeginner; // 0xCC
		private CriAtomExPlayback countUpSEPlayback; // 0xD0
		public Action ItemDetilsOpen; // 0xD4
		public Action ItemDetailClose; // 0xD8
		private string m_IconTextureUvName = "s_v_icon_{0:d2}"; // 0xDC
		private string m_LogoTextureUvName = "s_v_logo_{0:d2}"; // 0xE0
		private bool IsServerUpdateEnd; // 0xE4
		private bool IsServerUpdating; // 0xE5
		private static readonly string[] m_eventUvNameTable = new string[2] { "s_v_icon_event_01", "s_v_icon_pass_01" }; // 0x0
		private int m_NewAnimFrame; // 0xE8
		private int m_NewFlashFrame; // 0xEC
		private int[] m_itemIdList = new int[3]; // 0xF0
		private int m_spItemId; // 0xF4

		//// RVA: 0x185EE50 Offset: 0x185EE50 VA: 0x185EE50
		private void PlayCountUpLoopSE()
		{
			countUpSEPlayback = SoundManager.Instance.sePlayerResult.Play((int)cs_se_result.SE_RESULT_000);
		}

		//// RVA: 0x185EEB0 Offset: 0x185EEB0 VA: 0x185EEB0
		//private void StopCountUpLoopSE() { }

		// RVA: 0x185EEBC Offset: 0x185EEBC VA: 0x185EEBC
		public void StopTimer()
		{
			m_timeWatcher.WatchStop();
			m_DivaTimeWatcher.WatchStop();
		}

		// RVA: 0x185EF0C Offset: 0x185EF0C VA: 0x185EF0C
		public void Setup(HEFCLPGPMLK.AAOPGOGGMID view, Action listUpdate)
		{
			ListUpdateStart = listUpdate;
			m_view = view;
			IsBeginner = view.FGHGMHPNEMG_Category == BOPFPIHGJMD.MLBMHDCCGHI.GENEIBGNMPH_4_Debut;
		}

		// RVA: 0x185EF4C Offset: 0x185EF4C VA: 0x185EF4C
		public void SetStatus()
		{
			IsServerUpdateEnd = false;
			IsStartTimeWatcher = false;
			IsServerUpdating = false;
			for(int i = 0; i < 3; i++)
			{
				ItemIconList[i].enabled = false;
				if(i < m_view.AHNKDJLBLNM.Count && m_view.AHNKDJLBLNM.Count > 0)
				{
					int itemId = m_view.AHNKDJLBLNM[i];
					m_itemIdList[i] = m_view.AHNKDJLBLNM[i];
					RawImageEx icon = ItemIconList[i];
					int index = i;
					GameManager.Instance.ItemTextureCache.Load(itemId, (IiconTexture image) =>
					{
						//0x18646FC
						if (itemId != m_itemIdList[index])
							return;
						icon.enabled = true;
						image.Set(icon);
					});
					ItemIconNumList[i].SetNumber(m_view.PCPPHNINBBC[i]);
					ItemIconAnimList[i].StartChildrenAnimGoStop("01");
					ItemIconButtonList[i].Disable = m_view.CMCKNKKCNDK_Status == BOPFPIHGJMD.IGHPDAGKIKO.CADDNFIKDLG_4_Complete;
					ItemIconButtonList[i].Hidden = false;
				}
				else
				{
					//LAB_0185f158
					ItemIconAnimList[i].StartChildrenAnimGoStop("03");
					ItemIconButtonList[i].Disable = false;
					ItemIconButtonList[i].Hidden = true;
				}
			}
			ItemIconSp.enabled = false;
			m_spItemId = m_view.BIEGNEGKLDE_SpItemId;
			int spItemId = m_view.BIEGNEGKLDE_SpItemId;
			GameManager.Instance.ItemTextureCache.Load(spItemId, (IiconTexture image) =>
			{
				//0x18645AC
				if (m_spItemId != spItemId)
					return;
				ItemIconSp.enabled = true;
				image.Set(ItemIconSp);
			});
			ItemIconSpAnim.StartChildrenAnimGoStop("02");
			DebutIcon.StartChildrenAnimGoStop("02");
			SetOrderButtonState(m_view.MJKJGDOIAGO());
			if (CheckOverEndTime(m_view.PCCFAKEOBIC_EndDate) && buttonState == OrderButtonState.PROGRESS)
				SetOrderButtonState(OrderButtonState.DONE);
			SetLevelIcon(m_view.CIEOBFIIPLD_Level, m_view.NBLBJCLIDNN_MaxLevel);
			SetOfferType(m_view.CGKPIIFCCLD_OfferType);
			OfferName.text = m_view.IJOLPDKFLPO_OfferName;
			EventIconSetting(m_view.HBJEDMOMAEE_SpOfferType);
			OfferCategoryChenge();
			SetTimeText(ClearTime, m_view.JGAMLEMMJCJ);
			SetTimeWatcher(m_view.PCCFAKEOBIC_EndDate);
			SetItemIconButton();
			OfferDebutIcon.StartChildrenAnimGoStop(!IsBeginner ? "02" : "01");
			AbsUpdate();
		}

		//// RVA: 0x1860970 Offset: 0x1860970 VA: 0x1860970
		private void AbsUpdate()
		{
			m_offerType.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
			m_offerType.Update(new Matrix23(), Color.white);
			OfferLevel.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
			OfferLevel.Update(new Matrix23(), Color.white);
			OfferLevelMax.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
			OfferLevelMax.Update(new Matrix23(), Color.white);
			OfferEventIcon.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
			OfferEventIcon.Update(new Matrix23(), Color.white);
			OfferClearIcon.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
			OfferClearIcon.Update(new Matrix23(), Color.white);
			OfferButtonState.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
			OfferButtonState.Update(new Matrix23(), Color.white);
			OfferLogoState.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
			OfferLogoState.Update(new Matrix23(), Color.white);
			OfferCategory.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
			OfferCategory.Update(new Matrix23(), Color.white);
			m_DivaIcon.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
			m_DivaIcon.Update(new Matrix23(), Color.white);
			m_newAnimation.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
			m_newAnimation.Update(new Matrix23(), Color.white);
			OfferNewLoopAnim.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
			OfferNewLoopAnim.Update(new Matrix23(), Color.white);
			for(int i = 0; i < ItemIconButtonList.Length; i++)
			{
				ItemIconButtonList[i].RootAbsoluteLayout.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
				ItemIconButtonList[i].RootAbsoluteLayout.Update(new Matrix23(), Color.white);
			}
			for(int i = 0; i < ExecuBtn.Length; i++)
			{
				ExecuBtn[i].RootAbsoluteLayout.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
				ExecuBtn[i].RootAbsoluteLayout.Update(new Matrix23(), Color.white);
			}
		}

		// RVA: 0x1861328 Offset: 0x1861328 VA: 0x1861328
		private void Start()
		{
			return;
		}

		// RVA: 0x186132C Offset: 0x186132C VA: 0x186132C
		private void Update()
		{
			m_timeWatcher.Update();
			m_DivaTimeWatcher.Update();
			if (m_view == null || m_view.MJKJGDOIAGO() != OrderButtonState.DONE || m_currentRemainingTime < 0)
				return;
			if (!IsStartTimeWatcher)
				return;
			IsStartTimeWatcher = false;
			m_timeWatcher.onElapsedCallback = null;
			this.StartCoroutineWatched(FastCountTime());
		}

		//// RVA: 0x185FE08 Offset: 0x185FE08 VA: 0x185FE08
		private void SetOfferType(BOPFPIHGJMD.ADMNKELOLPN type)
		{
			switch (type)
			{
				case BOPFPIHGJMD.ADMNKELOLPN.CCAPCGPIIPF_1:
					m_offerType.StartChildrenAnimGoStop("01");
					break;
				case BOPFPIHGJMD.ADMNKELOLPN.NBHIECDDJHH_2:
					m_offerType.StartChildrenAnimGoStop("04");
					break;
				case BOPFPIHGJMD.ADMNKELOLPN.HFPIACELNLL_3:
					m_offerType.StartChildrenAnimGoStop("02");
					break;
				case BOPFPIHGJMD.ADMNKELOLPN.HIIPBAMPCEM_4:
					m_offerType.StartChildrenAnimGoStop("03");
					break;
				default:
					break;
			}
		}

		//// RVA: 0x185F9C4 Offset: 0x185F9C4 VA: 0x185F9C4
		private void SetOrderButtonState(OrderButtonState _state)
		{
			buttonState = _state;
			if(_state == OrderButtonState.COMPLETE)
			{
				OfferButtonState.enabled = false;
				OfferClearIcon.StartChildrenAnimGoStop("01");
				ItemIconSpButton.Disable = true;
			}
			else
			{
				OfferButtonState.enabled = true;
				OfferButtonState.StartChildrenAnimGoStop(((int)_state - 1).ToString("D2"));
				OfferClearIcon.StartChildrenAnimGoStop("02");
				ItemIconSpButton.Disable = false;
			}
		}

		// RVA: 0x1861484 Offset: 0x1861484 VA: 0x1861484
		public void SetButtonCallback(Action OrderAction, Action ProgressAction, Action DoneAction, Action itemDetilsOpen, Action itemDetailClose)
		{
			for (int i = 0; i < 3; i++)
			{
				if (i == 0)
				{
					ExecuBtn[i].ClearOnClickCallback();
					ExecuBtn[i].AddOnClickCallback(() =>
					{
						//0x1864870
						OrderAction();
					});
				}
				if(i == 1)
				{
					ExecuBtn[i].AddOnClickCallback(() =>
					{
						//0x186489C
						ProgressAction();
					});
				}
				if(i == 2)
				{
					ExecuBtn[i].AddOnClickCallback(() =>
					{
						//0x18648C8
						DoneAction();
					});
				}
			}
			ItemDetilsOpen = itemDetilsOpen;
			ItemDetailClose = itemDetailClose;
		}

		//// RVA: 0x1860720 Offset: 0x1860720 VA: 0x1860720
		private void SetItemIconButton()
		{
			for(int i = 0; i < 3; i++)
			{
				int index = i;
				ItemIconButtonList[i].ClearOnClickCallback();
				ItemIconButtonList[i].AddOnClickCallback(() =>
				{
					//0x18648F4
					GameManager.Instance.CloseSnsNotice();
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
					OnclickItemIcon(index);
				});
			}
			ItemIconSpButton.ClearOnClickCallback();
			ItemIconSpButton.AddOnClickCallback(() =>
			{
				//0x1864048
				GameManager.Instance.CloseSnsNotice();
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				OnclickSpItemIcon();
			});
		}

		//// RVA: 0x18617E0 Offset: 0x18617E0 VA: 0x18617E0
		public void OnclickItemIcon(int index)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(m_view.AHNKDJLBLNM[index]);
			if (cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				ShowItemDetail(m_view.AHNKDJLBLNM[index], bk.GetMessageByLabel("item_detail_popup_title_00"), bk.GetMessageByLabel("item_episode_plate"), bk.GetMessageByLabel("offer_item_scene_detail_text"), false);
			}
			else
			{
				int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(m_view.AHNKDJLBLNM[index]);
				ShowItemDetail(m_view.AHNKDJLBLNM[index], bk.GetMessageByLabel("item_detail_popup_title_00"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(cat, id), EKLNMHFCAOI.ILKGBGOCLAO_GetItemDesc(cat, id), false);
			}
		}

		//// RVA: 0x1861D24 Offset: 0x1861D24 VA: 0x1861D24
		public void OnclickSpItemIcon()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			ShowItemDetail(m_view.BIEGNEGKLDE_SpItemId, bk.GetMessageByLabel("offer_spitem_detail_title"), "", bk.GetMessageByLabel("offer_spitem_detail_text"), true);
		}

		//// RVA: 0x1861A4C Offset: 0x1861A4C VA: 0x1861A4C
		public void ShowItemDetail(int id, string titleText, string ItemName, string ItemDetail, bool IsSecret)
		{
			if (ItemDetilsOpen != null)
				ItemDetilsOpen();
			PopupOfferItemDetailSetting s = new PopupOfferItemDetailSetting();
			s.TitleText = titleText;
			s.IsSecret = IsSecret;
			s.ItemName = ItemName;
			s.ItemDetail = ItemDetail;
			s.ItemId = id;
			s.WindowSize = 1;
			s.SetParent(transform);
			s.Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative } };
			PopupWindowManager.Show(s, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x186413C
				if (ItemDetailClose != null)
					ItemDetailClose();
			}, null, null, null);
		}

		//// RVA: 0x185FB78 Offset: 0x185FB78 VA: 0x185FB78
		private bool CheckOverEndTime(long endTime)
		{
			return endTime < NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		}

		//// RVA: 0x18605D0 Offset: 0x18605D0 VA: 0x18605D0
		public void SetTimeWatcher(long remainTime)
		{
			if(remainTime != 0)
			{
				if(m_view.MJKJGDOIAGO() == OrderButtonState.PROGRESS)
				{
					m_timeWatcher.onElapsedCallback = (long current, long limit, long remain) =>
					{
						//0x1864150
						m_currentRemainingTime = limit;
						SetTimeText(AfterClearTime, limit);
						if(!CIOECGOMILE.HHCJCDFCLOB.KONHMOLMOCI)
						{
							if (buttonStateCheck(limit) && !IsServerUpdateEnd && !IsServerUpdating)
								ServerUpdate();
						}
					};
					m_timeWatcher.onEndCallback = null;
					m_currentRemainingTime = remainTime;
					m_timeWatcher.WatchStart(remainTime, false);
					IsStartTimeWatcher = true;
				}
			}
		}

		//// RVA: 0x1861E90 Offset: 0x1861E90 VA: 0x1861E90
		private void ServerUpdate()
		{
			MenuScene.Instance.RaycastDisable();
			SoundManager.Instance.sePlayerResult.Play((int)cs_se_result.SE_RESULT_026);
			IsServerUpdateEnd = false;
			IsServerUpdating = true;
			NKGJPJPHLIF.HHCJCDFCLOB.CADNBFCHAKM_GetToken(() =>
			{
				//0x1864258
				MenuScene.Instance.RaycastEnable();
				if(buttonStateCheck(m_view.PCCFAKEOBIC_EndDate - NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime()))
				{
					StateUpdate();
				}
				ListUpdateStart();
				IsServerUpdateEnd = true;
				IsServerUpdating = false;
			}, () =>
			{
				//0x18644E8
				MenuScene.Instance.RaycastEnable();
				MenuScene.Instance.GotoTitle();
			});
		}

		//// RVA: 0x18620E8 Offset: 0x18620E8 VA: 0x18620E8
		public void SetDivaTimeWatcher(long remainTime)
		{
			if(remainTime != 0)
			{
				m_DivaTimeWatcher.onElapsedCallback = (long current, long limit, long remain) =>
				{
					//0x18643F0
					SetTimeText(OfferDeadLine, limit);
				};
				m_DivaTimeWatcher.onEndCallback = null;
				m_DivaTimeWatcher.WatchStart(remainTime, false);
			}
		}

		//// RVA: 0x1860494 Offset: 0x1860494 VA: 0x1860494
		private void SetTimeText(Text text, long remainSec)
		{
			int h, m, s;
			OfferSelectScene.GetMiddleTime((int)remainSec, out h, out m, out s, true);
			text.text = string.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);
		}

		//// RVA: 0x1862200 Offset: 0x1862200 VA: 0x1862200
		public bool buttonStateCheck(long remainSec)
		{
			if(remainSec == 0 && buttonState == OrderButtonState.PROGRESS)
			{
				SoundManager.Instance.sePlayerResult.Play((int)cs_se_result.SE_RESULT_026);
				ListUpdateStart();
				buttonState = OrderButtonState.DONE;
				if(KDHGBOOECKC.HHCJCDFCLOB != null)
				{
					if(KDHGBOOECKC.HHCJCDFCLOB.KOGFFBBKOPB(m_view.FGHGMHPNEMG_Category, m_view.PPFNGGCBJKC) == BOPFPIHGJMD.IGHPDAGKIKO.LGOIJAPMEBG_2_Progress)
					{
						KDHGBOOECKC.HHCJCDFCLOB.MOOJLBNGNOB(m_view.FGHGMHPNEMG_Category, m_view.PPFNGGCBJKC, BOPFPIHGJMD.IGHPDAGKIKO.FJGFAPKLLCL_3_Achieved);
					}
				}
				m_view.CMCKNKKCNDK_Status = BOPFPIHGJMD.IGHPDAGKIKO.FJGFAPKLLCL_3_Achieved;
				IsStartTimeWatcher = false;
				m_timeWatcher.onElapsedCallback = null;
				m_timeWatcher.WatchStop();
				return true;
			}
			return false;
		}

		//// RVA: 0x18623B4 Offset: 0x18623B4 VA: 0x18623B4
		private void StateUpdate()
		{
			buttonState = OrderButtonState.DONE;
			if (KDHGBOOECKC.HHCJCDFCLOB != null)
			{
				if (KDHGBOOECKC.HHCJCDFCLOB.KOGFFBBKOPB(m_view.FGHGMHPNEMG_Category, m_view.PPFNGGCBJKC) == BOPFPIHGJMD.IGHPDAGKIKO.LGOIJAPMEBG_2_Progress)
				{
					KDHGBOOECKC.HHCJCDFCLOB.MOOJLBNGNOB(m_view.FGHGMHPNEMG_Category, m_view.PPFNGGCBJKC, BOPFPIHGJMD.IGHPDAGKIKO.FJGFAPKLLCL_3_Achieved);
				}
			}
			m_view.CMCKNKKCNDK_Status = BOPFPIHGJMD.IGHPDAGKIKO.FJGFAPKLLCL_3_Achieved;
			IsStartTimeWatcher = false;
			m_timeWatcher.onElapsedCallback = null;
			m_timeWatcher.WatchStop();
			m_currentRemainingTime = 0;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FA7B4 Offset: 0x6FA7B4 VA: 0x6FA7B4
		//// RVA: 0x18613F8 Offset: 0x18613F8 VA: 0x18613F8
		private IEnumerator FastCountTime()
		{
			bool IsPlayingSE; // 0x14
			long MaxTime; // 0x18
			float CountTime; // 0x20
			float fast_time; // 0x24

			//0x1864A08
			IsPlayingSE = true;
			MenuScene.Instance.RaycastDisable();
			PlayCountUpLoopSE();
			MaxTime = m_currentRemainingTime;
			fast_time = 2;
			if (MaxTime < 61)
				fast_time = 0.5f;
			CountTime = 1; // ??
			while (m_currentRemainingTime != 0)
			{
				AfterClearTime.color = Color.red;
				float f;
				if(1.0f / Time.deltaTime * fast_time < MaxTime)
				{
					f = (MaxTime / (1.0f / Time.deltaTime)) / fast_time;
				}
				else
				{
					CountTime = CountTime < 1 ? CountTime + Time.deltaTime : (MaxTime / (1.0f / Time.deltaTime)) / fast_time;
					f = CountTime;
				}
				m_currentRemainingTime -= (int)f;
				if(m_currentRemainingTime == 0)
				{
					IsPlayingSE = false;
					countUpSEPlayback.Stop();
					SetTimeText(AfterClearTime, 0);
					yield return Co.R(KDHGBOOECKC.HHCJCDFCLOB.FMGMIKPJNKG_Co_wait(0.3f, false, () =>
					{
						//0x1864414
						AfterClearTime.color = Color.red;
					}));
				}
				else
				{
					SetTimeText(AfterClearTime, m_currentRemainingTime);
				}
				while(CIOECGOMILE.HHCJCDFCLOB.KONHMOLMOCI)
				{
					yield return null;
				}
				yield return null;
			}
			if (IsPlayingSE)
			{
				IsPlayingSE = false;
				countUpSEPlayback.Stop();
			}
			SoundManager.Instance.sePlayerResult.Play((int)cs_se_result.SE_RESULT_026);
			StateUpdate();
			ListUpdateStart();
			MenuScene.Instance.RaycastDisable();
		}

		//// RVA: 0x18601CC Offset: 0x18601CC VA: 0x18601CC
		private void OfferCategoryChenge()
		{
			if(m_view.FGHGMHPNEMG_Category > BOPFPIHGJMD.MLBMHDCCGHI.HJNNKCMLGFL_0 && m_view.FGHGMHPNEMG_Category <= BOPFPIHGJMD.MLBMHDCCGHI.FDOOAJLGFAE_2_Week)
			{
				ChengeSeriesLogo(m_view.DFMOGBOPLEF_Series);
				ChengeSeriesIcon(m_view.DFMOGBOPLEF_Series);
				OfferCategory.StartChildrenAnimGoStop(m_view.CMCKNKKCNDK_Status == BOPFPIHGJMD.IGHPDAGKIKO.CADDNFIKDLG_4_Complete ? "03" : "01");
				OfferLogoState.StartChildrenAnimGoStop("01");
			}
			else if(m_view.FGHGMHPNEMG_Category == BOPFPIHGJMD.MLBMHDCCGHI.FMLPIOFBCMA_3_Diva)
			{
				DivaOfferSetting();
			}
			else if(m_view.FGHGMHPNEMG_Category == BOPFPIHGJMD.MLBMHDCCGHI.GENEIBGNMPH_4_Debut)
			{
				ChengeSeriesLogo(m_view.DFMOGBOPLEF_Series);
				ChengeSeriesIcon(m_view.DFMOGBOPLEF_Series);
				OfferCategory.StartChildrenAnimGoStop(m_view.CMCKNKKCNDK_Status == BOPFPIHGJMD.IGHPDAGKIKO.CADDNFIKDLG_4_Complete ? "03" : "01");
				OfferLogoState.StartChildrenAnimGoStop("01");
			}
			m_contentFram.StartChildrenAnimGoStop(m_view.FGHGMHPNEMG_Category == BOPFPIHGJMD.MLBMHDCCGHI.FDOOAJLGFAE_2_Week ? "02" : "01");
			if(m_view.DFMOGBOPLEF_Series != BOPFPIHGJMD.LGEIPIHHNPH.CFBJGAGBJEN_5)
			{
				if (m_view.DFMOGBOPLEF_Series != BOPFPIHGJMD.LGEIPIHHNPH.LCBPJOKNKPL_7)
					return;
			}
			OfferLogoState.StartChildrenAnimGoStop("03");
		}

		//// RVA: 0x18627A8 Offset: 0x18627A8 VA: 0x18627A8
		private void DivaOfferSetting()
		{
			ChengeSeriesLogo(m_view.DFMOGBOPLEF_Series);
			ChengeSeriesIcon(m_view.DFMOGBOPLEF_Series);
			if(m_view.CMCKNKKCNDK_Status == BOPFPIHGJMD.IGHPDAGKIKO.EBAPFCDNMGD_1_Order)
			{
				OfferCategory.StartChildrenAnimGoStop("02");
			}
			else if(m_view.CMCKNKKCNDK_Status == BOPFPIHGJMD.IGHPDAGKIKO.CADDNFIKDLG_4_Complete)
			{
				OfferCategory.StartChildrenAnimGoStop("03");
			}
			else
			{
				OfferCategory.StartChildrenAnimGoStop("01");
			}
			OfferLogoState.StartChildrenAnimGoStop("02");
			StringBuilder str = new StringBuilder(64);
			str.SetFormat("diva_s_{0:D2}", m_view.AHHJLDLAPAN);
			m_DivaIcon.StartChildrenAnimGoStop(m_view.AHHJLDLAPAN.ToString("D2"));
			DivaName.text = MessageManager.Instance.GetMessage("master", str.ToString());
			SetDivaTimeWatcher(m_view.LOAEGNGKFNF_Expr);
		}

		//// RVA: 0x1862508 Offset: 0x1862508 VA: 0x1862508
		//private void ChangeSeries(BOPFPIHGJMD.LGEIPIHHNPH seriesIcon) { }

		//// RVA: 0x186252C Offset: 0x186252C VA: 0x186252C
		private void ChengeSeriesLogo(BOPFPIHGJMD.LGEIPIHHNPH seriesIcon)
		{
			if(seriesIcon != BOPFPIHGJMD.LGEIPIHHNPH.LCBPJOKNKPL_7 && seriesIcon != BOPFPIHGJMD.LGEIPIHHNPH.CFBJGAGBJEN_5 && seriesIcon > BOPFPIHGJMD.LGEIPIHHNPH.HJNNKCMLGFL_0 && seriesIcon <= BOPFPIHGJMD.LGEIPIHHNPH.LCBPJOKNKPL_7)
			{
				if (seriesIcon == BOPFPIHGJMD.LGEIPIHHNPH.GDEJFFFHFGP_6)
					seriesIcon = BOPFPIHGJMD.LGEIPIHHNPH.CFBJGAGBJEN_5;
				TexUVData data = m_texUvList_3.GetUVData(string.Format(m_LogoTextureUvName, (int)seriesIcon));
				if(data != null)
				{
					SeriesLogo.uvRect = LayoutUGUIUtility.MakeUnityUVRect(data);
				}
			}
		}

		//// RVA: 0x1862674 Offset: 0x1862674 VA: 0x1862674
		private void ChengeSeriesIcon(BOPFPIHGJMD.LGEIPIHHNPH seriesIcon)
		{
			if(seriesIcon > BOPFPIHGJMD.LGEIPIHHNPH.HJNNKCMLGFL_0 && seriesIcon < BOPFPIHGJMD.LGEIPIHHNPH.LCBPJOKNKPL_7)
			{
				TexUVData data = m_texUvList_3.GetUVData(string.Format(m_IconTextureUvName, (int)seriesIcon));
				if(data != null)
				{
					SeriesIcon.uvRect = LayoutUGUIUtility.MakeUnityUVRect(data);
				}
			}
		}

		//// RVA: 0x185FF20 Offset: 0x185FF20 VA: 0x185FF20
		private void EventIconSetting(BOPFPIHGJMD.HDHDOOLPBEO spOfferType)
		{
			if (spOfferType == BOPFPIHGJMD.HDHDOOLPBEO.CCDOBDNDPIL_1)
			{
				OfferEventIcon.StartChildrenAnimGoStop("01");
				EventIcon.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_texUvList_1.GetUVData(m_eventUvNameTable[0]));
			}
			else if (((int)spOfferType & 0xfffffffeU) != 2)
				OfferEventIcon.StartChildrenAnimGoStop("03");
			else
			{
				OfferEventIcon.StartChildrenAnimGoStop("01");
				EventIcon.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_texUvList_1.GetUVData(m_eventUvNameTable[1]));
			}
		}

		//// RVA: 0x185FC70 Offset: 0x185FC70 VA: 0x185FC70
		private void SetLevelIcon(int level, int maxLevel)
		{
			OfferLevelMax.StartAllAnimGoStop(m_view.NBHEBLNHOJO ? "01" : "02");
			OfferLevel.StartAllAnimGoStop((maxLevel < 1 ? 1 : maxLevel).ToString("D2"));
			for(int i = 0; i < 6; i++)
			{
				m_levelIcon[i].StartChildrenAnimGoStop(level <= i ? "02" : "01");
			}
		}

		//// RVA: 0x1862AA0 Offset: 0x1862AA0 VA: 0x1862AA0
		public void SetDailyAnimFrame(int frame)
		{
			OfferNewLoopAnim.StartChildrenAnimGoStop(frame % m_NewAnimFrame, frame % m_NewAnimFrame);
		}

		//// RVA: 0x1862AE8 Offset: 0x1862AE8 VA: 0x1862AE8
		public void SetNewAnimFrame(int frame)
		{
			m_newAnimation.StartChildrenAnimGoStop(frame % m_NewFlashFrame, frame % m_NewFlashFrame);
		}

		// RVA: 0x1862B30 Offset: 0x1862B30 VA: 0x1862B30
		public void NewIconSetting(int frame)
		{
			if(m_view != null)
			{
				NewState state = SettingNewState();
				if (state <= NewState.FIXED)
				{
					switch (state)
					{
						case NewState.NONE:
							OfferNewIcon.StartChildrenAnimGoStop("03");
							OfferNewLoopAnim.StartChildrenAnimLoop("st_wait");
							m_newAnimation.StartChildrenAnimGoStop("st_wait");
							return;
						case NewState.CROSS_FADE:
							OfferNewIcon.StartChildrenAnimGoStop("01");
							SetDailyAnimFrame(frame);
							m_newAnimation.StartChildrenAnimGoStop("st_wait");
							for(int i = 0; i < GetItemNum.Count; i++)
							{
								GetItemNum[i].SetNumber(m_view.KPFHAMNOIAG, 0);
							}
							break;
						case NewState.FLASHING:
							OfferNewIcon.StartChildrenAnimGoStop("01");
							OfferNewLoopAnim.StartChildrenAnimLoop("st_wait");
							SetNewAnimFrame(frame);
							return;
						case NewState.FIXED:
							OfferNewIcon.StartChildrenAnimGoStop("02");
							OfferNewLoopAnim.StartChildrenAnimLoop("st_wait");
							m_newAnimation.StartChildrenAnimGoStop("st_wait");
							for(int i = 0; i < GetItemNum.Count; i++)
							{
								GetItemNum[i].SetNumber(m_view.KPFHAMNOIAG, 0);
							}
							break;
					}
				}
			}
		}

		//// RVA: 0x1862F2C Offset: 0x1862F2C VA: 0x1862F2C
		private NewState SettingNewState()
		{
			NewState res = NewState.NONE;
			if(m_view.CADENLBDAEB || (m_view.CMCKNKKCNDK_Status != BOPFPIHGJMD.IGHPDAGKIKO.EBAPFCDNMGD_1_Order && !m_view.OHOGIHMFEIJ))
			{
				if(m_view.OHOGIHMFEIJ)
				{
					if (m_view.CMCKNKKCNDK_Status != BOPFPIHGJMD.IGHPDAGKIKO.EBAPFCDNMGD_1_Order)
						return NewState.FIXED;
					return NewState.CROSS_FADE;
				}
				if (m_view.CMCKNKKCNDK_Status == BOPFPIHGJMD.IGHPDAGKIKO.EBAPFCDNMGD_1_Order)
					return NewState.FLASHING;
			}
			return res;
		}

		// RVA: 0x1862FFC Offset: 0x1862FFC VA: 0x1862FFC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_texUvList_3 = uvMan.GetTexUVList("sel_vfo_03_pack");
			m_texUvList_1 = uvMan.GetTexUVList("sel_vfo_pack");
			m_offerType = layout.FindViewByExId("sw_s_v_list_swtbl_s_v_frm_type") as AbsoluteLayout;
			OfferLevel = layout.FindViewByExId("sw_s_v_list_swtbl_s_v_lv") as AbsoluteLayout;
			OfferLevelMax = layout.FindViewByExId("sw_s_v_list_swtbl_s_v_lv_max") as AbsoluteLayout;
			OfferEventIcon = layout.FindViewByExId("sw_s_v_list_swtbl_s_v_icon_event") as AbsoluteLayout;
			OfferClearIcon = layout.FindViewByExId("swtbl_s_v_list_swtbl_cmn_clear_icon") as AbsoluteLayout;
			OfferButtonState = layout.FindViewByExId("sw_s_v_list_swtbl_s_v_btn_01") as AbsoluteLayout;
			OfferCategory = layout.FindViewByExId("root_sel_vfo_list_swtbl_s_v_list") as AbsoluteLayout;
			DebutIcon = layout.FindViewByExId("sw_s_v_list_swtbl_s_v_icon_begi") as AbsoluteLayout;
			OfferDebutIcon = layout.FindViewByExId("sw_s_v_list_swtbl_s_v_icon_begi") as AbsoluteLayout;
			OfferLogoState = layout.FindViewByExId("sw_s_v_list_swtbl_s_v_logo") as AbsoluteLayout;
			OfferNewIcon = layout.FindViewByExId("sw_s_v_list_swtbl_icon_new") as AbsoluteLayout;
			OfferNewLoopAnim = layout.FindViewByExId("swtbl_icon_new_sw_icon_new_01") as AbsoluteLayout;
			m_contentFram = layout.FindViewByExId("sw_s_v_list_swtbl_s_v_win_01") as AbsoluteLayout;
			m_DivaIcon = layout.FindViewByExId("swtbl_s_v_logo_swtbl_s_v_minichara") as AbsoluteLayout;
			m_newAnimation = layout.FindViewByExId("sw_icon_new_01_cmn_icon01") as AbsoluteLayout;
			for(int i = 0; i < 3; i++)
			{
				AbsoluteLayout p = layout.FindViewByExId(string.Format("sw_s_v_list_sw_s_v_item_anim_0{0}", i + 1)) as AbsoluteLayout;
				ItemIconAnimList[i] = p.FindViewByExId("sw_s_v_item_anim_swtbl_s_v_item") as AbsoluteLayout;
			}
			ItemIconSpAnim = (layout.FindViewByExId("sw_s_v_list_sw_s_v_item_anim_04") as AbsoluteLayout).FindViewByExId("sw_s_v_item_anim_swtbl_s_v_item") as AbsoluteLayout;
			for(int i = 0; i < 6; i++)
			{
				m_levelIcon[i] = layout.FindViewByExId(string.Format("swtbl_s_v_lv_{0:D2}", i + 1)) as AbsoluteLayout;
			}
			m_NewAnimFrame = OfferNewLoopAnim.GetView(0).FrameAnimation.FrameNum;
			m_NewFlashFrame = m_newAnimation.GetView(0).FrameAnimation.FrameNum;
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
