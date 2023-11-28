using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using XeApp.Game.Common;
using System;
using CriWare;
using System.Collections;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class OfferGetItemLayout : LayoutUGUIScriptBase
	{
		private const int BONUS_ITEM_COUNT = 2;
		[Range(0, 0.5f)] // RVA: 0x67614C Offset: 0x67614C VA: 0x67614C
		public float nextItemMoveSec = 0.1f; // 0x14
		[Range(0, 0.5f)] // RVA: 0x676164 Offset: 0x676164 VA: 0x676164
		public float backItemMoveSec = 0.25f; // 0x18
		[SerializeField]
		public float itemBonusCountupSec = 0.5f; // 0x1C
		[SerializeField]
		private List<RawImageEx> BonusItemIcon = new List<RawImageEx>(); // 0x20
		public Action onFinished; // 0x24
		private static readonly float SCROLL_MARGIN_WIDTH = 20; // 0x0
		private AbsoluteLayout m_layoutRoot; // 0x28
		private AbsoluteLayout m_layoutMain; // 0x2C
		private AbsoluteLayout m_layoutFormType; // 0x30
		private AbsoluteLayout[] m_layoutBonusItemEnable = new AbsoluteLayout[2]; // 0x34
		private AbsoluteLayout m_layoutBonusItemAnim; // 0x38
		[SerializeField]
		private Text textRareItemNum; // 0x3C
		[SerializeField]
		private Text textNomralItemNum; // 0x40
		[SerializeField]
		private Text textConfirmItemNum; // 0x44
		private AbsoluteLayout layoutScoreRankIcon; // 0x48
		private AbsoluteLayout layoutScoreRankLoop; // 0x4C
		[SerializeField]
		private Text[] textScoreRankBonus; // 0x50
		private AbsoluteLayout layoutUCRoot; // 0x54
		[SerializeField]
		private NumberBase numberTotalUC; // 0x58
		[SerializeField]
		private Text textConvertUC; // 0x5C
		[SerializeField]
		private LayoutUGUIScrollSupport scrollSupporter; // 0x60
		private AbsoluteLayout layoutZeroItem; // 0x64
		private AbsoluteLayout layoutBonus; // 0x68
		private int currentItemIndex; // 0x6C
		private AbsoluteLayout[] layoutRankIcon = new AbsoluteLayout[5]; // 0x70
		private bool m_isSkip; // 0x74
		private ViewOfferCompensation m_viewCompItem; // 0x78
		private List<OfferGetItemContent> itemList = new List<OfferGetItemContent>(); // 0x7C
		private bool IsBonus; // 0x80
		public bool IsAutoScrolling; // 0x81
		private bool[] IsFormIconLoaded = new bool[2]; // 0x84
		private List<int> DisplayItemIdList = new List<int>(); // 0x88
		private CriAtomExPlayback countUpSEPlayback; // 0x8C
		private int[] debug_itemIdListGARWALK = new int[1] { 70001 }; // 0x90
		private int[] debug_itemIdListBATROID = new int[1] { 70007 }; // 0x94

		public bool IsSkip { get { return m_isSkip; } set { m_isSkip = value; } } //0x152DF70 0x152DF78

		// RVA: 0x152DF80 Offset: 0x152DF80 VA: 0x152DF80
		private void Start()
		{
			return;
		}

		// RVA: 0x152DF84 Offset: 0x152DF84 VA: 0x152DF84
		private void Update()
		{
			return;
		}

		// RVA: 0x152DF88 Offset: 0x152DF88 VA: 0x152DF88
		public void ResetScrollList()
		{
			itemList.Clear();
			scrollSupporter.RemoveAllView();
		}

		// RVA: 0x152E020 Offset: 0x152E020 VA: 0x152E020
		public void AddScrollContent(List<OfferGetItemContent> list)
		{
			itemList = list;
		}

		// RVA: 0x152E028 Offset: 0x152E028 VA: 0x152E028
		public void Initialize()
		{
			for(int i = 0; i < itemList.Count; i++)
			{
				if(i < itemList.Count)
				{
					itemList[i].Setup(m_viewCompItem.ItemList[i]);
					itemList[i].SetStatus();
				}
			}
			SetText();
			SetBonusAnum();
			layoutUCRoot.StartChildrenAnimGoStop("02");
		}

		//// RVA: 0x152E1E4 Offset: 0x152E1E4 VA: 0x152E1E4
		public void SetText()
		{
			textNomralItemNum.text = m_viewCompItem.Nomal.ToString();
			textRareItemNum.text = m_viewCompItem.Rare.ToString();
			textConfirmItemNum.text = m_viewCompItem.Confirm.ToString();
		}

		//// RVA: 0x152E2E4 Offset: 0x152E2E4 VA: 0x152E2E4
		//public void SetLuckAnim() { }

		//// RVA: 0x152E3C4 Offset: 0x152E3C4 VA: 0x152E3C4
		public void SetUcAnim(int number)
		{
			numberTotalUC.SetNumber(number, 0);
		}

		//// RVA: 0x152E2E8 Offset: 0x152E2E8 VA: 0x152E2E8
		public void SetBonusAnum()
		{
			IsBonus = m_viewCompItem.IsBonus;
			for(int i = 0; i < textScoreRankBonus.Length; i++)
			{
				textScoreRankBonus[i].text = m_viewCompItem.BonusNum.ToString();
			}
		}

		// RVA: 0x152E404 Offset: 0x152E404 VA: 0x152E404
		public void SettingValkyrieFormIcon(int from, int offerType, int offerId)
		{
			ChengeValkyrieForm(from);
			KDHGBOOECKC.JNHGHDKLDEM data = new KDHGBOOECKC.JNHGHDKLDEM();
			data = data.JGJOAFJPIIH((BOPFPIHGJMD.MLBMHDCCGHI)offerType, offerId);
			for(int i = 0; i < data.NNDGIAEFMOG[from].LHMDABPNDDH.Length; i++)
			{
				if(data.NNDGIAEFMOG[from].LHMDABPNDDH[i] >= 0 && data.NNDGIAEFMOG[from].LHMDABPNDDH[i] <= BOPFPIHGJMD.MGPIJGMDLOM.HJNNKCMLGFL_3)
				{
					DisplayItemIdList.Add(data.NNDGIAEFMOG[from].LNADJDFHHAI[i]);
				}
			}
			SettingBonusItemIcon(DisplayItemIdList);
			ItemIconSettingEneble();
		}

		// RVA: 0x152E930 Offset: 0x152E930 VA: 0x152E930
		public void ReleaseBonusIconList()
		{
			DisplayItemIdList.Clear();
		}

		//// RVA: 0x152E5F4 Offset: 0x152E5F4 VA: 0x152E5F4
		private void ChengeValkyrieForm(int from)
		{
			m_layoutFormType.StartChildrenAnimGoStop(string.Format("{0:d2}", from + 1));
		}

		//// RVA: 0x152E9A8 Offset: 0x152E9A8 VA: 0x152E9A8
		//private bool CheckBonusItemIcon() { }

		//// RVA: 0x152EA30 Offset: 0x152EA30 VA: 0x152EA30
		private int CountBonusItem()
		{
			return DisplayItemIdList.Count;
		}

		// RVA: 0x152EAA8 Offset: 0x152EAA8 VA: 0x152EAA8
		public bool ItemIconLoded()
		{
			for(int i = 0; i < CountBonusItem(); i++)
			{
				if (!IsFormIconLoaded[i])
					return false;
			}
			return true;
		}

		//// RVA: 0x152E6B0 Offset: 0x152E6B0 VA: 0x152E6B0
		private void SettingBonusItemIcon(List<int> itemIdList)
		{
			for(int i = 0; i < BonusItemIcon.Count; i++)
			{
				IsFormIconLoaded[i] = true;
				if(i < CountBonusItem())
				{
					BonusItemIcon[i].enabled = false;
					SettingIcon(itemIdList[i], i);
				}
			}
		}

		//// RVA: 0x152EB30 Offset: 0x152EB30 VA: 0x152EB30
		private void SettingIcon(int itemId, int index)
		{
			IsFormIconLoaded[index] = false;
			MenuScene.Instance.InputDisable();
			GameManager.Instance.ItemTextureCache.Load(itemId, (IiconTexture image) =>
			{
				//0x1850E20
				BonusItemIcon[index].enabled = true;
				image.Set(BonusItemIcon[index]);
				IsFormIconLoaded[index] = true;
				MenuScene.Instance.InputEnable();
			});
		}

		//// RVA: 0x152E834 Offset: 0x152E834 VA: 0x152E834
		private void ItemIconSettingEneble()
		{
			for(int i = 0; i < m_layoutBonusItemEnable.Length; i++)
			{
				m_layoutBonusItemEnable[i].StartChildrenAnimGoStop(i < CountBonusItem() ? "01" : "02");
			}
		}

		// RVA: 0x152ED38 Offset: 0x152ED38 VA: 0x152ED38
		public void BonusIconLoopAnimStart()
		{
			m_layoutBonusItemAnim.StartChildrenAnimGoStop(CountBonusItem() < 2 ? "st_wait" : "lo_");
		}

		// RVA: 0x152EDD8 Offset: 0x152EDD8 VA: 0x152EDD8
		public void Enter()
		{
			if (m_isSkip)
				Show();
			else
				m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x152EEF8 Offset: 0x152EEF8 VA: 0x152EEF8
		public void Leave()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// RVA: 0x152EF84 Offset: 0x152EF84 VA: 0x152EF84
		public void Hide()
		{
			m_layoutRoot.StartChildrenAnimGoStop("st_out");
		}

		//// RVA: 0x152EE7C Offset: 0x152EE7C VA: 0x152EE7C
		public void Show()
		{
			m_layoutRoot.StartChildrenAnimGoStop("st_in");
		}

		// RVA: 0x152F000 Offset: 0x152F000 VA: 0x152F000
		public bool IsPlaying()
		{
			return m_layoutRoot.IsPlaying();
		}

		// RVA: 0x152F02C Offset: 0x152F02C VA: 0x152F02C
		public void EnterChild()
		{
			if (m_isSkip)
				ShowChild();
			else
				m_layoutMain.StartChildrenAnimGoStop("go_evedrop_02", "st_nomaldrop_02");
		}

		// RVA: 0x152F0D0 Offset: 0x152F0D0 VA: 0x152F0D0
		public void ShowChild()
		{
			m_layoutMain.StartChildrenAnimGoStop(!IsBonus ? "st_nomaldrop_02" : "st_bonusnum_02");
		}

		// RVA: 0x152F16C Offset: 0x152F16C VA: 0x152F16C
		public void UCEnter()
		{
			m_layoutMain.StartChildrenAnimGoStop(!IsBonus ? "go_getuc2_02" : "go_getuc_02", !IsBonus ? "st_getuc2_02" : "st_getuc_02");
		}

		// RVA: 0x152F220 Offset: 0x152F220 VA: 0x152F220
		public void UCShow()
		{
			m_layoutMain.StartChildrenAnimGoStop(!IsBonus ? "st_getuc2_02" : "st_getuc_02");
		}

		// RVA: 0x152F2BC Offset: 0x152F2BC VA: 0x152F2BC
		public void CampaignAnimStart()
		{
			if (!IsBonus)
				return;
			m_layoutMain.StartChildrenAnimGoStop("go_rankbonus_02", "st_bonusnum_02");
		}

		// RVA: 0x152F354 Offset: 0x152F354 VA: 0x152F354
		public void CampaignAnimShow()
		{
			if (!IsBonus)
				return;
			m_layoutMain.StartChildrenAnimGoStop("st_bonusnum_02", "st_bonusnum_02");
		}

		// RVA: 0x152F3E0 Offset: 0x152F3E0 VA: 0x152F3E0
		public bool IsPlayingInWindow()
		{
			return m_layoutMain.IsPlayingChildren();
		}

		// RVA: 0x152F40C Offset: 0x152F40C VA: 0x152F40C
		public void ScrollContentAllHide()
		{
			for(int i = 0; i < itemList.Count; i++)
			{
				itemList[i].Hide();
			}
			scrollSupporter.scrollRect.content.localPosition = Vector3.zero;
			currentItemIndex = 0;
		}

		// RVA: 0x152F590 Offset: 0x152F590 VA: 0x152F590
		public void ShowDropItem()
		{
			for(int i = 0; i < itemList.Count; i++)
			{
				scrollSupporter.scrollRect.horizontalNormalizedPosition = 0;
				AddItem();
				itemList[i].ShowBeginAnim();
				RecordPlateUtility.CheckPlateId(m_viewCompItem.ItemList[i]);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F95B4 Offset: 0x6F95B4 VA: 0x6F95B4
		// RVA: 0x152F9C0 Offset: 0x152F9C0 VA: 0x152F9C0
		public IEnumerator ScrollAnimPlay()
		{
			int i; // 0x14
			bool IsLast; // 0x18
			OfferGetItemContent content; // 0x1C

			//0x1851C88
			//LAB_01851ea4
			for(i = 0; i < itemList.Count; i++)
			{
				IsLast = false;
				content = itemList[i];
				if (!m_isSkip)
				{
					IsLast = AddItem();
					if (currentItemIndex < 7)
					{
						content.StartBeginAnim();
						yield return null;
					}
					else
					{
						yield return Co.R(Co_AutoScrolling(1, nextItemMoveSec, content.StartBeginAnim));
						yield return null;
					}
					if (IsLast)
					{
						//LAB_01851d44
						while (content.IsPlayng())
							yield return null;
					}
					//LAB_01851d78
					if (m_viewCompItem.ItemList[i].itemType == ViewOfferGetItem.ItemType.NOMAL)
					{
						yield return Co.R(KDHGBOOECKC.HHCJCDFCLOB.FMGMIKPJNKG_Co_wait(0.1f, false, null));
					}
					else
					{
						//5
						while (content.IsPlayng())
							yield return null;
					}
					//LAB_01851e90
					content = null;
				}
				else
					break;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F962C Offset: 0x6F962C VA: 0x6F962C
		// RVA: 0x152FA48 Offset: 0x152FA48 VA: 0x152FA48
		public IEnumerator SceneCardCheck()
		{
			bool prevInput;

			//0x18517F4
			prevInput = GameManager.Instance.InputEnabled;
			GameManager.Instance.InputEnabled = true;
			bool isOpenRecordPlateInfo = true;
			this.StartCoroutineWatched(PopupRecordPlate.Show(RecordPlateUtility.eSceneType.Offer, () =>
			{
				//0x1851064
				isOpenRecordPlateInfo = false;
			}, false));
			yield return new WaitWhile(() =>
			{
				//0x1851070
				return isOpenRecordPlateInfo;
			});
			RecordPlateUtility.ClearShowedList();
			GameManager.Instance.InputEnabled = prevInput;
			while (CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.FIGHNFKAMGI.Count > 0)
				CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.FIGHNFKAMGI.RemoveAt(0);
		}

		// RVA: 0x152FAD0 Offset: 0x152FAD0 VA: 0x152FAD0
		public void DropItemBounsNumAnumStart()
		{
			if(IsBonus)
			{
				for(int i = 0; i < itemList.Count; i++)
				{
					if(m_viewCompItem.ItemList[i].itemType == ViewOfferGetItem.ItemType.NOMAL)
					{
						itemList[i].BounsNumAnumStart();
					}
				}
			}
		}

		// RVA: 0x152FC18 Offset: 0x152FC18 VA: 0x152FC18
		public void DropItemBounsNumAnumShow()
		{
			if(IsBonus)
			{
				for(int i = 0; i < itemList.Count; i++)
				{
					if(m_viewCompItem.ItemList[i].itemType == ViewOfferGetItem.ItemType.NOMAL)
					{
						itemList[i].BounsNumAnumShow();
					}
				}
			}
		}

		// RVA: 0x152FD60 Offset: 0x152FD60 VA: 0x152FD60
		public bool IsPlayingDropItem()
		{
			for(int i = 0; i < itemList.Count; i++)
			{
				if (itemList[i].IsPlayng())
					return true;
			}
			return false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F96A4 Offset: 0x6F96A4 VA: 0x6F96A4
		// RVA: 0x152FE44 Offset: 0x152FE44 VA: 0x152FE44
		public IEnumerator Co_PlayingUCAnim()
		{
			Coroutine coroutin;

			//0x1851424
			bool CountPlaying = true;
			numberTotalUC.enabled = true;
			if(m_viewCompItem.UCNum < 1)
			{
				SetUcAnim(m_viewCompItem.UCNum);
			}
			else
			{
				List<float> l = new List<float>();
				NumberAnimationUtility.MakeAccelerationTimeList(10, 0.3f, 0.02f, ref l);
				PlayCountUpLoopSE();
				coroutin = this.StartCoroutineWatched(NumberAnimationUtility.Co_FakeCountup(m_viewCompItem.UCNum, l, SetUcAnim, () =>
				{
					//0x1851080
					CountPlaying = false;
				}, null));
				while (CountPlaying && !m_isSkip)
					yield return null;
				if (CountPlaying)
				{
					this.StopCoroutineWatched(coroutin);
					coroutin = null;
				}
				StopCountUpLoopSE();
			}
		}

		// RVA: 0x152FECC Offset: 0x152FECC VA: 0x152FECC
		public void UC_AnimSkip()
		{
			numberTotalUC.SetNumber(m_viewCompItem.UCNum, 0);
		}

		// RVA: 0x152FF24 Offset: 0x152FF24 VA: 0x152FF24
		public void ResetUC()
		{
			numberTotalUC.SetNumber(0, 0);
		}

		//// RVA: 0x152FF60 Offset: 0x152FF60 VA: 0x152FF60
		private void PlayCountUpLoopSE()
		{
			countUpSEPlayback = SoundManager.Instance.sePlayerResult.Play((int)cs_se_result.SE_RESULT_000);
		}

		//// RVA: 0x152FFC0 Offset: 0x152FFC0 VA: 0x152FFC0
		private void StopCountUpLoopSE()
		{
			countUpSEPlayback.Stop();
		}

		//// RVA: 0x152F73C Offset: 0x152F73C VA: 0x152F73C
		private bool AddItem()
		{
			if(currentItemIndex < itemList.Count)
			{
				scrollSupporter.BeginAddView();
				scrollSupporter.AddView(itemList[currentItemIndex].gameObject, SCROLL_MARGIN_WIDTH + itemList[currentItemIndex].Width * currentItemIndex + SCROLL_MARGIN_WIDTH + itemList[currentItemIndex].Width, 0);
				currentItemIndex++;
				return itemList.Count == currentItemIndex;
			}
			return true;
		}

		// RVA: 0x152FFCC Offset: 0x152FFCC VA: 0x152FFCC
		public void ResetScrollBar()
		{
			scrollSupporter.scrollRect.horizontalNormalizedPosition = 0;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F971C Offset: 0x6F971C VA: 0x6F971C
		// RVA: 0x153001C Offset: 0x153001C VA: 0x153001C
		public IEnumerator Co_AutoScrolling(float endNormalizePos, float time, Action actionScrollFinished)
		{
			float beginNormalizePos; // 0x20
			float ct; // 0x24

			//0x18510B0
			IsAutoScrolling = true;
			yield return null;
			beginNormalizePos = scrollSupporter.scrollRect.horizontalNormalizedPosition;
			ct = 0;
			do
			{
				ct += Time.deltaTime;
				ct = Mathf.Clamp(ct, 0, time);
				scrollSupporter.scrollRect.horizontalNormalizedPosition = XeSys.Math.Tween.EasingInOutCubic(beginNormalizePos, endNormalizePos, ct / time);
				if (time <= ct)
					break;
				yield return null;
			} while (true);
			if (actionScrollFinished != null)
				actionScrollFinished();
			yield return null;
			IsAutoScrolling = false;
		}

		// RVA: 0x1530100 Offset: 0x1530100 VA: 0x1530100
		public void SetView(ViewOfferCompensation view)
		{
			m_viewCompItem = view;
		}

		// RVA: 0x1530108 Offset: 0x1530108 VA: 0x1530108 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewByExId("sw_drop_set_anim") as AbsoluteLayout;
			m_layoutMain = layout.FindViewByExId("sw_drop_set") as AbsoluteLayout;
			layoutBonus = layout.FindViewByExId("sw_g_r_drop_txt_no_bns_in_anim") as AbsoluteLayout;
			layoutScoreRankIcon = m_layoutMain.FindViewById("swtbl_rank_icon") as AbsoluteLayout;
			layoutScoreRankLoop = m_layoutMain.FindViewById("sw_txt_rbonus") as AbsoluteLayout;
			layoutZeroItem = m_layoutMain.FindViewById("sw_nonitem_in_anim") as AbsoluteLayout;
			layoutZeroItem.StartAllAnimGoStop("st_wait");
			layoutUCRoot = m_layoutMain.FindViewById("sw_getuc_set") as AbsoluteLayout;
			layoutRankIcon[0] = layout.FindViewById("sw_rank_score_c") as AbsoluteLayout;
			layoutRankIcon[1] = layout.FindViewById("sw_rank_score_b") as AbsoluteLayout;
			layoutRankIcon[2] = layout.FindViewById("sw_rank_score_a") as AbsoluteLayout;
			layoutRankIcon[3] = layout.FindViewById("sw_rank_score_s") as AbsoluteLayout;
			layoutRankIcon[4] = layout.FindViewById("sw_rank_score_ss") as AbsoluteLayout;
			m_layoutFormType = layout.FindViewByExId("g_r_drop_fr_swtbl_valform") as AbsoluteLayout;
			m_layoutBonusItemEnable[0] = layout.FindViewByExId("sw_valform_up_anim_swtbl_valform_up_01") as AbsoluteLayout;
			m_layoutBonusItemEnable[1] = layout.FindViewByExId("sw_valform_up_anim_swtbl_valform_up_02") as AbsoluteLayout;
			m_layoutBonusItemAnim = layout.FindViewByExId("g_r_drop_fr_sw_valform_up_anim") as AbsoluteLayout;
			m_isSkip = false;
			Loaded();
			return true;
		}
	}
}
