using XeSys.Gfx;
using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using XeApp.Game.Common;
using CriWare;
using System.Linq;
using System.Text;
using XeSys;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutResultDropMain : LayoutUGUIScriptBase
	{
		private enum MainAnimStep
		{
			EVENT_RARE_DROP = 0,
			RARE_DROP = 1,
			NOMAL_DROP = 2,
			RANK_BONUS = 3,
			BONUS_VALUE = 4,
			UC = 5,
			End = 6,
			NoneItem = 7,
		}

		[RangeAttribute(0, 0.5f)] // RVA: 0x67D02C Offset: 0x67D02C VA: 0x67D02C
		public float nextItemMoveSec = 0.1f; // 0x14
		[RangeAttribute(0, 0.5f)] // RVA: 0x67D044 Offset: 0x67D044 VA: 0x67D044
		public float backItemMoveSec = 0.25f; // 0x18
		[SerializeField]
		public float itemBonusCountupSec = 0.5f; // 0x1C
		public Action onFinished; // 0x20
		private static readonly float SCROLL_MARGIN_WIDTH = 20; // 0x0
		private MOLKENLNCPE_DropData viewDrop; // 0x24
		private List<LayoutResultDropItem> itemList; // 0x28
		private AbsoluteLayout layoutRoot; // 0x2C
		private AbsoluteLayout layoutMain; // 0x30
		private Text textRareItemNum; // 0x34
		private Text textNomralItemNum; // 0x38
		private Text textEventRareItemNum; // 0x3C
		private AbsoluteLayout layoutLuckType; // 0x40
		private NumberBase numberLuck; // 0x44
		private AbsoluteLayout layoutScoreRankIcon; // 0x48
		private AbsoluteLayout layoutScoreRankLoop; // 0x4C
		private Text[] textScoreRankBonus; // 0x50
		private AbsoluteLayout layoutUCRoot; // 0x54
		private NumberBase numberTotalUC; // 0x58
		private Text textConvertUC; // 0x5C
		private LayoutUGUIScrollSupport scrollSupporter; // 0x60
		private AbsoluteLayout layoutZeroItem; // 0x64
		private AbsoluteLayout layoutBonus; // 0x68
		private int currentItemIndex; // 0x6C
		private CriAtomExPlayback countUpSEPlayback; // 0x70
		private CriAtomExPlayback countUpBonusSEPlayback; // 0x74
		private bool is_evenRareDrop; // 0x78
		private bool m_is_bonus; // 0x79
		private bool m_is_scoreRank = true; // 0x7A
		private AbsoluteLayout[] layoutRankIcon = new AbsoluteLayout[5]; // 0x7C
		private bool isSkip; // 0x80

		public bool IsSkip { get { return isSkip; } } //0x1D93478

		// RVA: 0x1D93480 Offset: 0x1D93480 VA: 0x1D93480
		private void Start()
		{
			return;
		}

		// RVA: 0x1D93484 Offset: 0x1D93484 VA: 0x1D93484
		private void Update()
		{
			return;
		}

		// RVA: 0x1D93488 Offset: 0x1D93488 VA: 0x1D93488 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Transform t = transform.Find("sw_drop_set_anim (AbsoluteLayout)").Find("sw_drop_set (AbsoluteLayout)");
			layoutRoot = layout.FindViewById("sw_drop_set_anim") as AbsoluteLayout;
			layoutMain = layoutRoot.FindViewById("sw_drop_set") as AbsoluteLayout;
			layoutBonus = layout.FindViewById("sw_g_r_drop_txt_no_bns_in_anim") as AbsoluteLayout;
			textRareItemNum = t.Find("sw_txt_raredrop (AbsoluteLayout)/raredrop (TextView)").GetComponent<Text>();
			textNomralItemNum = t.Find("sw_txt_nomaldrop (AbsoluteLayout)/nomaldrop (TextView)").GetComponent<Text>();
			textEventRareItemNum = t.Find("sw_txt_evedrop (AbsoluteLayout)/raredrop (TextView)").GetComponent<Text>();
			layoutLuckType = (layoutMain.FindViewById("sw_txt_raredrop") as AbsoluteLayout).FindViewById("swtbl_luck_num") as AbsoluteLayout;
			numberLuck = t.Find("sw_txt_raredrop (AbsoluteLayout)/swtbl_luck_num (AbsoluteLayout)").Find("swnum_luck (AbsoluteLayout)").GetComponent<NumberBase>();
			layoutScoreRankIcon = layoutMain.FindViewById("swtbl_rank_icon") as AbsoluteLayout;
			layoutScoreRankLoop = layoutMain.FindViewById("sw_txt_rbonus") as AbsoluteLayout;
			textScoreRankBonus = t.Find("sw_txt_rbonus (AbsoluteLayout)").GetComponentsInChildren<Text>(true).Where((Text _) => {
				//0x1D970E0
				return _.name == "rbonus (TextView)";
			}).ToArray();
			scrollSupporter = t.Find("sw_item_area (AbsoluteLayout)/item_area (ScrollView)").GetComponent<LayoutUGUIScrollSupport>();
			layoutZeroItem = layoutMain.FindViewById("sw_nonitem_in_anim") as AbsoluteLayout;
			t.Find("sw_nonitem_in_anim (AbsoluteLayout)/sw_nonitem (AbsoluteLayout)/nonitem (TextView)").GetComponent<Text>().text = JpStringLiterals.StringLiteral_17777;
			layoutUCRoot = layoutMain.FindViewById("sw_getuc_set") as AbsoluteLayout;
			numberTotalUC = t.Find("sw_getuc_set (AbsoluteLayout)").Find("sw_getuc_anim (AbsoluteLayout)/swnum_uc (AbsoluteLayout)").GetComponent<NumberBase>();
			textConvertUC = t.Find("sw_getuc_set (AbsoluteLayout)").Find("sw_ucitemtxt (AbsoluteLayout)/ucitem (TextView)").GetComponent<Text>();
			layoutRankIcon[0] = layout.FindViewById("sw_rank_score_c") as AbsoluteLayout;
			layoutRankIcon[1] = layout.FindViewById("sw_rank_score_b") as AbsoluteLayout;
			layoutRankIcon[2] = layout.FindViewById("sw_rank_score_a") as AbsoluteLayout;
			layoutRankIcon[3] = layout.FindViewById("sw_rank_score_s") as AbsoluteLayout;
			layoutRankIcon[4] = layout.FindViewById("sw_rank_score_ss") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// // RVA: 0x1D943BC Offset: 0x1D943BC VA: 0x1D943BC
		public void Setup(MOLKENLNCPE_DropData viewDrop, List<LayoutResultDropItem> itemList)
		{
			this.viewDrop = viewDrop;
			this.itemList = itemList;
			numberLuck.SetNumber(viewDrop.MJBODMOLOBC_Luck, 0);
			StringBuilder str = new StringBuilder(32);
			textRareItemNum.text = viewDrop.MFNCONLNBPB_RareItemNum.ToString();
			textNomralItemNum.text = viewDrop.OOEFNNNFOLF_NormalItemNum.ToString();
			textEventRareItemNum.text = viewDrop.POPPPGMKOHN_EventRareItemNum.ToString();
			is_evenRareDrop = viewDrop.ELKAMCOPCDO_EventRareItemNum > 0;
			layoutLuckType.StartChildrenAnimGoStop(viewDrop.MJBODMOLOBC_Luck == 0 ? "00": "01");
			layoutScoreRankIcon.StartChildrenAnimGoStop((int)viewDrop.DCBDCHPKLCN_Rank, (int)viewDrop.DCBDCHPKLCN_Rank);
			float a = (viewDrop.JKLNANHPJLO - 1) * 100;
			for(int i = 0; i < textScoreRankBonus.Length; i++)
			{
				textScoreRankBonus[i].text = a.ToString() + JpStringLiterals.StringLiteral_17787;
			}
			layoutScoreRankLoop.StartChildrenAnimGoStop("st_wait", "st_wait");
			numberTotalUC.SetNumber(0, 0);
			numberTotalUC.enabled = false;
			str.SetFormat(JpStringLiterals.StringLiteral_17788, viewDrop.ADHABBGDFPK);
			textConvertUC.text = str.ToString();
			textConvertUC.enabled = false;
			m_is_bonus = viewDrop.DCBDCHPKLCN_Rank != ResultScoreRank.Type.C;
			RecordPlateUtility.ClearShowedList();
			if(!m_is_scoreRank)
			{
				layoutScoreRankIcon.StartChildrenAnimGoStop("06", "06");
				layoutBonus.StartChildrenAnimGoStop("st_in", "st_in");
			}
			currentItemIndex = 0;
		}

		// // RVA: 0x1D948BC Offset: 0x1D948BC VA: 0x1D948BC
		public void StartBeginAnim()
		{
			this.StartCoroutineWatched(Co_PlayingRootAnim());
		}

		// // RVA: 0x1D9496C Offset: 0x1D9496C VA: 0x1D9496C
		public void StartEndAnim(Action endCallback)
		{
			this.StartCoroutineWatched(Co_EndPlayingAnim(endCallback));
		}

		// // RVA: 0x1D94A38 Offset: 0x1D94A38 VA: 0x1D94A38
		public void SkipBeginAnim()
		{
			countUpSEPlayback.Stop();
			countUpBonusSEPlayback.Stop();
			for(int i = 0; i < itemList.Count; i++)
			{
				itemList[i].StopAllCoroutinesWatched();
			}
			for(int i = 0; i < itemList.Count; i++)
			{
				itemList[i].SkipBeginAnim();	
			}
			if(itemList.Count == 0)
			{
				layoutZeroItem.StartChildrenAnimGoStop("st_in");
			}
			do
			{
				;
			} while(!AddItem());
			scrollSupporter.scrollRect.horizontalNormalizedPosition = 0;
			SetupUCAnimTable();
			StringBuilder str = new StringBuilder(32);
			numberTotalUC.SetNumber(viewDrop.PBIHLJKLHGJ_UCNumber, 0);
			numberTotalUC.enabled = true;
			if(viewDrop.ADHABBGDFPK != 0)
				textConvertUC.enabled = true;
			layoutRoot.StartChildrenAnimGoStop("st_in");
			EnterMainStep(MainAnimStep.End);
			StartScoreLoopAnim();
			layoutRankIcon[(int)viewDrop.DCBDCHPKLCN_Rank].StartChildrenAnimGoStop("st_in", "st_in");
			layoutRankIcon[(int)viewDrop.DCBDCHPKLCN_Rank].StartChildrenAnimLoop("logo_act", "loen_act");
			scrollSupporter.ContentHeight = 0;
		}

		// // RVA: 0x1D95714 Offset: 0x1D95714 VA: 0x1D95714
		public void SkipRecordPlate(Action callback)
		{
			if(RecordPlateUtility.CheckPlateId(viewDrop.HBHMAKNGKFK))
			{
				this.StartCoroutineWatched(PopupRecordPlate.Show(RecordPlateUtility.eSceneType.Result, callback, false));
				return;
			}
			if(callback != null)
			{
				callback();
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71933C Offset: 0x71933C VA: 0x71933C
		// // RVA: 0x1D948E0 Offset: 0x1D948E0 VA: 0x1D948E0
		private IEnumerator Co_PlayingRootAnim()
		{
			//0x1D98BF0
			layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1D96B64
				return layoutRoot.IsPlayingChildren();
			});
			isSkip = true;
			StartZeroItemAnim();
			if(!is_evenRareDrop)
			{
				this.StartCoroutineWatched(Co_PlayingRareItemDropNumAnim());
			}
			else
			{
				this.StartCoroutineWatched(Co_PlayingEventRareItemDropNumAnim());
			}
		}

		// // RVA: 0x1D95818 Offset: 0x1D95818 VA: 0x1D95818
		private void StartZeroItemAnim()
		{
			if (viewDrop.HBHMAKNGKFK.Count != 0)
				return;
			layoutZeroItem.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x1D958EC Offset: 0x1D958EC VA: 0x1D958EC
		// private void StartEventRareItemDropNumAnim() { }

		// [IteratorStateMachineAttribute] // RVA: 0x7193B4 Offset: 0x7193B4 VA: 0x7193B4
		// // RVA: 0x1D95910 Offset: 0x1D95910 VA: 0x1D95910
		private IEnumerator Co_PlayingEventRareItemDropNumAnim()
		{
			//0x1D97710
			EnterMainStep(MainAnimStep.EVENT_RARE_DROP);
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1D96B90
				return layoutMain.IsPlayingChildren();
			});
			if(viewDrop.HBHMAKNGKFK.Count > 0 && viewDrop.HBHMAKNGKFK[0].BAKFIPIFDLE_IsEventRareItem)
			{
				StartNextEventRareItemAnim();
			}
			else
			{
				this.StartCoroutineWatched(Co_PlayingRareItemDropNumAnim());
			}
		}

		// // RVA: 0x1D959BC Offset: 0x1D959BC VA: 0x1D959BC
		private void StartNextEventRareItemAnim()
		{
			TodoLogger.Log(0, "StartNextEventRareItemAnim");
		}

		// // RVA: 0x1D95D34 Offset: 0x1D95D34 VA: 0x1D95D34
		// private void StartRareItemDropNumAnim() { }

		// [IteratorStateMachineAttribute] // RVA: 0x71942C Offset: 0x71942C VA: 0x71942C
		// // RVA: 0x1D95D58 Offset: 0x1D95D58 VA: 0x1D95D58
		private IEnumerator Co_PlayingRareItemDropNumAnim()
		{
			//0x1D98934
			EnterMainStep(MainAnimStep.RARE_DROP);
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1D96BBC
				return layoutMain.IsPlayingChildren();
			});
			if(viewDrop.HBHMAKNGKFK.Count > 0 && viewDrop.HBHMAKNGKFK[currentItemIndex].PHJHJGDLPED_IsRareItem)
			{
				StartNextRareItemAnim();
			}
			else
			{
				this.StartCoroutineWatched(Co_PlayingNomralItemDropNumAnim());
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7194A4 Offset: 0x7194A4 VA: 0x7194A4
		// // RVA: 0x1D94990 Offset: 0x1D94990 VA: 0x1D94990
		private IEnumerator Co_EndPlayingAnim(Action endCallback)
		{
			//0x1D974E4
			layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1D96BE8
				return layoutRoot.IsPlayingChildren();
			});
			endCallback();
		}

		// // RVA: 0x1D95E24 Offset: 0x1D95E24 VA: 0x1D95E24
		private void StartNextRareItemAnim()
		{
			LayoutResultDropItem item = itemList[currentItemIndex];
			if(item.itemInfo != null && item.itemInfo.HHACNFODNEF_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				RecordPlateUtility.CheckPlateId(item.itemInfo);
			}
			if(!AddItem() && viewDrop.HBHMAKNGKFK[currentItemIndex].PHJHJGDLPED_IsRareItem)
			{
				item.onFinished = StartNextRareItemAnim;
			}
			else
			{
				item.onFinished = StartNormalItemDropNumAnim;
			}
			if(currentItemIndex < 7)
			{
				item.StartBeginAnim();
			}
			else
			{
				this.StartCoroutineWatched(Co_AutoScrolling(1, nextItemMoveSec, item.StartBeginAnim));
			}
		}

		// // RVA: 0x1D960B4 Offset: 0x1D960B4 VA: 0x1D960B4
		private void StartNormalItemDropNumAnim()
		{
			this.StartCoroutineWatched(Co_PlayingNomralItemDropNumAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71951C Offset: 0x71951C VA: 0x71951C
		// // RVA: 0x1D960D8 Offset: 0x1D960D8 VA: 0x1D960D8
		private IEnumerator Co_PlayingNomralItemDropNumAnim()
		{
			bool isExistNormalItem = false;

			//0x1D979CC
			if(currentItemIndex < viewDrop.HBHMAKNGKFK.Count)
			{
				isExistNormalItem = !viewDrop.HBHMAKNGKFK[currentItemIndex].PHJHJGDLPED_IsRareItem;
				if (!viewDrop.HBHMAKNGKFK[currentItemIndex].PHJHJGDLPED_IsRareItem)
				{
					EnterMainStep(MainAnimStep.NOMAL_DROP);
					yield return null;
				}
				else
				{
					isExistNormalItem = false;
					EnterMainStep(MainAnimStep.NoneItem);
					yield return null;
				}
			}
			else
			{
				isExistNormalItem = false;
				EnterMainStep(MainAnimStep.NoneItem);
				yield return null;
			}
			yield return new WaitWhile(() =>
			{
				//0x1D96C14
				return layoutMain.IsPlayingChildren();
			});
			if (isExistNormalItem)
				StartNextNormalItemAnim();
			else
				StartUCAnim();
		}

		// // RVA: 0x1D96184 Offset: 0x1D96184 VA: 0x1D96184
		private void StartNextNormalItemAnim()
		{
			AddItem();
			onFinished = StartNormalItemBonusAnim;
			if(currentItemIndex < 7)
			{
				itemList[currentItemIndex].StartBeginAnim();
			}
			else
			{
				this.StartCoroutineWatched(Co_AutoScrolling(1, nextItemMoveSec, StartBeginAnim));
			}
		}

		// // RVA: 0x1D962FC Offset: 0x1D962FC VA: 0x1D962FC
		public void StartNormalItemBonusAnim()
		{
			this.StartCoroutineWatched(Co_PlayingNormalItemBonusAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x719594 Offset: 0x719594 VA: 0x719594
		// // RVA: 0x1D96320 Offset: 0x1D96320 VA: 0x1D96320
		private IEnumerator Co_PlayingNormalItemBonusAnim()
		{
			//0x1D97C9C
			PlayJingle();
			EnterMainStep(MainAnimStep.RANK_BONUS);
			if (!m_is_scoreRank)
			{
				layoutBonus.StartChildrenAnimGoStop("go_in", "st_in");
				yield return new WaitWhile(() =>
				{
					//0x1D96C40
					return layoutBonus.IsPlayingChildren();
				});
			}
			else
			{
				if (m_is_bonus)
				{
					ResultScoreRank.Type rank_index = viewDrop.DCBDCHPKLCN_Rank;
					layoutRankIcon[(int)rank_index].StartChildrenAnimGoStop("go_in", "st_in");
					yield return new WaitWhile(() =>
					{
						//0x1D97168
						return layoutRankIcon[(int)rank_index].IsPlayingChildren();
					});
					layoutRankIcon[(int)rank_index].StartChildrenAnimLoop("logo_act", "loen_act");
					EnterMainStep(MainAnimStep.BONUS_VALUE);
				}
			}
			if(m_is_bonus)
			{
				for(int i = 0; i < itemList.Count; i++)
				{
					itemList[i].StartMoveNum();
				}
				yield return null;
				yield return new WaitWhile(() =>
				{
					//0x1D96C6C
					for(int i = 0; i < itemList.Count; i++)
					{
						if (itemList[i].IsPlaying())
							return true;
					}
					return false;
				});
				for(int i = 0; i < itemList.Count; i++)
				{
					if(!itemList[i].itemInfo.BAKFIPIFDLE_IsEventRareItem)
					{
						itemList[i].StartShowBonus();
					}
				}
				yield return null;
				yield return new WaitWhile(() =>
				{
					//0x1D96D54
					return layoutMain.IsPlayingChildren();
				});
				yield return new WaitWhile(() =>
				{
					//0x1D96D80
					for(int i = 0; i < itemList.Count; i++)
					{
						if (itemList[i].IsPlaying())
							return true;
					}
					return false;
				});
				yield return new WaitForSeconds(0.1f);
				bool b = false;
				for(int i = 0; i < itemList.Count; i++)
				{
					if(itemList[i].itemInfo != null)
					{
						if(!itemList[i].itemInfo.PHJHJGDLPED_IsRareItem && !itemList[i].itemInfo.BAKFIPIFDLE_IsEventRareItem)
						{
							b |= itemList[i].itemInfo.DJJGNDCMNHF_BonusCount > 0;
						}
					}
				}
				if(b)
				{
					for(int i = 0; i < itemList.Count; i++)
					{
						itemList[i].StartAnimBonus();
					}
					yield return new WaitWhile(() =>
					{
						//0x1D96E68
						for (int i = 0; i < itemList.Count; i++)
						{
							if (itemList[i].IsPlaying())
								return true;
						}
						return false;
					});
					SoundManager.Instance.sePlayerResult.Play(5);
					for(int i = 0; i < itemList.Count; i++)
					{
						itemList[i].StartAnimBonusAdd();
						itemList[i].FinalizeBaseCountNumber();
					}
					yield return new WaitWhile(() =>
					{
						//0x1D96F50
						for (int i = 0; i < itemList.Count; i++)
						{
							if (itemList[i].IsPlaying())
								return true;
						}
						return false;
					});
					StartScoreLoopAnim();
					yield return new WaitForSeconds(0.2f);
				}
				else
				{
					StartScoreLoopAnim();
				}
			}
			StartUCAnim();
		}

		// // RVA: 0x1D963CC Offset: 0x1D963CC VA: 0x1D963CC
		public void StartUCAnim()
		{
			SetupUCAnimTable();
			this.StartCoroutineWatched(Co_PlayingUCAnim());
		}

		// // RVA: 0x1D955DC Offset: 0x1D955DC VA: 0x1D955DC
		public void StartScoreLoopAnim()
		{
			if(viewDrop.DCBDCHPKLCN_Rank > ResultScoreRank.Type.C)
			{
				layoutScoreRankLoop.StartChildrenAnimLoop("logo", "loen");
				for(int i = 0; i < itemList.Count; i++)
				{
					itemList[i].StartLoopAnimBonus();
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71960C Offset: 0x71960C VA: 0x71960C
		// // RVA: 0x1D963F8 Offset: 0x1D963F8 VA: 0x1D963F8
		private IEnumerator Co_PlayingUCAnim()
		{
			//0x1D98E88
			this.StartCoroutineWatched(Co_AutoScrolling(0, backItemMoveSec, null));
			yield return null;
			EnterMainStep(MainAnimStep.UC);
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1D97038
				return layoutMain.IsPlayingChildren();
			});
			numberTotalUC.enabled = true;
			List<float> fl = new List<float>();
			NumberAnimationUtility.MakeAccelerationTimeList(10, 0.3f, 0.02f, ref fl);
			PlayCountUpLoopSE();
			yield return this.StartCoroutineWatched(NumberAnimationUtility.Co_FakeCountup(viewDrop.PBIHLJKLHGJ_UCNumber, fl, OnChangeUCNumber, null, null));
			countUpSEPlayback.Stop();
			if(viewDrop.ADHABBGDFPK != 0)
			{
				textConvertUC.enabled = true;
			}
			if (onFinished != null)
				onFinished();
		}

		// // RVA: 0x1D964A4 Offset: 0x1D964A4 VA: 0x1D964A4
		private void OnChangeUCNumber(int number)
		{
			numberTotalUC.SetNumber(number, 0);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x719684 Offset: 0x719684 VA: 0x719684
		// // RVA: 0x1D95C4C Offset: 0x1D95C4C VA: 0x1D95C4C
		private IEnumerator Co_AutoScrolling(float endNormalizePos, float time, Action actionScrollFinished)
		{
			float beginNormalizePos; // 0x20
			float ct; // 0x24

			//0x1D971E8
			beginNormalizePos = scrollSupporter.scrollRect.horizontalNormalizedPosition;
			ct = 0;
			while(true)
			{
				ct = Mathf.Clamp(ct + Time.deltaTime, 0, time);
				float r = XeSys.Math.Tween.EasingInOutCubic(beginNormalizePos, endNormalizePos, ct / time);
				scrollSupporter.scrollRect.horizontalNormalizedPosition = r;
				if(time <= ct)
				{
					break;
				}
				else
				{
					yield return null;
				}
			}
			if(actionScrollFinished != null)
				actionScrollFinished();
		}

		// // RVA: 0x1D94EB8 Offset: 0x1D94EB8 VA: 0x1D94EB8
		private bool AddItem()
		{
			if(currentItemIndex < itemList.Count)
			{
				Vector2 pos = new Vector2(SCROLL_MARGIN_WIDTH + itemList[currentItemIndex].Width * currentItemIndex + SCROLL_MARGIN_WIDTH + itemList[currentItemIndex].Width, 0);
				scrollSupporter.BeginAddView();
				scrollSupporter.AddView(itemList[currentItemIndex].gameObject, SCROLL_MARGIN_WIDTH + itemList[currentItemIndex].Width * currentItemIndex, 0);
				scrollSupporter.EndAddView();
				currentItemIndex++;
				return itemList.Count == currentItemIndex;
			}
			return true;
		}

		// // RVA: 0x1D951E8 Offset: 0x1D951E8 VA: 0x1D951E8
		private void EnterMainStep(MainAnimStep step)
		{
			switch(step)
			{
				case MainAnimStep.EVENT_RARE_DROP:
					layoutMain.StartChildrenAnimGoStop("go_evedrop_02", "st_evedrop_02");
					break;
				case MainAnimStep.RARE_DROP:
					if(is_evenRareDrop)
						layoutMain.StartChildrenAnimGoStop("go_raredrop_02", "st_raredrop_02");
					else
						layoutMain.StartChildrenAnimGoStop("go_raredrop", "st_raredrop");
					break;
				case MainAnimStep.NOMAL_DROP:
					if (is_evenRareDrop)
						layoutMain.StartChildrenAnimGoStop("go_nomaldrop_02", "st_nomaldrop_02");
					else
						layoutMain.StartChildrenAnimGoStop("go_nomaldrop", "st_nomaldrop");
					break;
				case MainAnimStep.RANK_BONUS:
					if (!m_is_bonus)
						return;
					if (is_evenRareDrop)
						layoutMain.StartChildrenAnimGoStop("go_rankbonus_02", "st_rankbonus_02");
					else
						layoutMain.StartChildrenAnimGoStop("go_rankbonus", "st_rankbonus");
					break;
				case MainAnimStep.BONUS_VALUE:
					if (is_evenRareDrop)
						layoutMain.StartChildrenAnimGoStop("go_bonusnum_02", "st_bonusnum_02");
					else
						layoutMain.StartChildrenAnimGoStop("go_bonusnum", "st_bonusnum");
					break;
				case MainAnimStep.UC:
					if (!is_evenRareDrop)
					{
						if(!m_is_bonus)
							layoutMain.StartChildrenAnimGoStop("go_getuc2", "st_getuc2");
						else
							layoutMain.StartChildrenAnimGoStop("go_getuc", "st_getuc");
					}
					else
					{
						if (!m_is_bonus)
							layoutMain.StartChildrenAnimGoStop("go_getuc2_02", "st_getuc2_02");
						else
							layoutMain.StartChildrenAnimGoStop("go_getuc_02", "st_getuc_02");
					}
					break;
				case MainAnimStep.End:
					if (!is_evenRareDrop)
					{
						if (!m_is_bonus)
							layoutMain.StartChildrenAnimGoStop("st_getuc2", "st_getuc2");
						else
							layoutMain.StartChildrenAnimGoStop("st_getuc", "st_getuc");
					}
					else
					{
						if (!m_is_bonus)
							layoutMain.StartChildrenAnimGoStop("st_getuc2_02", "st_getuc2_02");
						else
							layoutMain.StartChildrenAnimGoStop("st_getuc_02", "st_getuc_02");
					}
					break;
				case MainAnimStep.NoneItem:
					if (!is_evenRareDrop)
					{
						if (!m_is_bonus)
							layoutMain.StartChildrenAnimGoStop("go_nomaldrop", "st_nomaldrop");
						else
							layoutMain.StartChildrenAnimGoStop("go_nomaldrop", "st_rankbonus");
					}
					else
					{
						if (!m_is_bonus)
							layoutMain.StartChildrenAnimGoStop("go_nomaldrop_02", "st_nomaldrop_02");
						else
							layoutMain.StartChildrenAnimGoStop("go_nomaldrop_02", "st_rankbonus_02");
					}
					break;
				default:
					break;
			}
		}

		// // RVA: 0x1D9513C Offset: 0x1D9513C VA: 0x1D9513C
		public void SetupUCAnimTable()
		{
			layoutUCRoot.StartChildrenAnimGoStop(viewDrop.ADHABBGDFPK == 0 ? "02" : "01");
		}

		// // RVA: 0x1D96504 Offset: 0x1D96504 VA: 0x1D96504
		public bool IsOpenPopupRecordPlate()
		{
			if (currentItemIndex - 1 < 0)
				return false;
			return itemList[currentItemIndex - 1].IsOpenRecordPlateInfo;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7196FC Offset: 0x7196FC VA: 0x7196FC
		// // RVA: 0x1D965B8 Offset: 0x1D965B8 VA: 0x1D965B8
		// private IEnumerator Co_ScrollArea() { }

		// // RVA: 0x1D96664 Offset: 0x1D96664 VA: 0x1D96664
		private void PlayJingle()
		{
			switch(viewDrop.DCBDCHPKLCN_Rank)
			{
				case ResultScoreRank.Type.C:
					SoundManager.Instance.sePlayerResult.Play(23);
					break;
				case ResultScoreRank.Type.B:
					SoundManager.Instance.sePlayerResult.Play(22);
					break;
				case ResultScoreRank.Type.A:
					SoundManager.Instance.sePlayerResult.Play(21);
					break;
				case ResultScoreRank.Type.S:
					SoundManager.Instance.sePlayerResult.Play(20);
					break;
				case ResultScoreRank.Type.SS:
					SoundManager.Instance.sePlayerResult.Play(19);
					break;
			}
		}

		// // RVA: 0x1D96820 Offset: 0x1D96820 VA: 0x1D96820
		private void PlayCountUpLoopSE()
		{
			countUpSEPlayback = SoundManager.Instance.sePlayerResult.Play(0);
		}

		// // RVA: 0x1D94EA0 Offset: 0x1D94EA0 VA: 0x1D94EA0
		// private void StopCountUpLoopSE() { }

		// // RVA: 0x1D96880 Offset: 0x1D96880 VA: 0x1D96880
		// private void PlayBonusCountUpLoopSE() { }

		// // RVA: 0x1D94EAC Offset: 0x1D94EAC VA: 0x1D94EAC
		// private void StopBonusCountUpLoopSE() { }

		// // RVA: 0x1D968E0 Offset: 0x1D968E0 VA: 0x1D968E0
		public bool IsDrop()
		{
			return itemList.Count > 0;
		}

		// // RVA: 0x1D96968 Offset: 0x1D96968 VA: 0x1D96968
		public bool IsMedalDrop()
		{
			for(int i = 0; i < itemList.Count; i++)
			{
				if (itemList[i].itemInfo.HHACNFODNEF_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal)
					return true;
			}
			return false;
		}
	}
}
