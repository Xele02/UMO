using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using System;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutQuestHorizontalItem : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_bg; // 0x14
		[SerializeField]
		private RawImageEx m_imageFont; // 0x18
		[SerializeField]
		private Text m_time; // 0x1C
		[SerializeField]
		private Text m_count; // 0x20
		[SerializeField]
		private Text m_next; // 0x24
		[SerializeField]
		private ActionButton m_button; // 0x28
		private GameObject m_base; // 0x2C
		private RectTransform m_rtTransform; // 0x30
		private AbsoluteLayout m_bgLayout; // 0x34
		private AbsoluteLayout m_receiptLayout; // 0x38
		private AbsoluteLayout m_timeLayout; // 0x3C
		private AbsoluteLayout m_countLayout; // 0x40
		private BadgeIcon m_badge = new BadgeIcon(); // 0x44
		private AbsoluteLayout m_badgeParentLayout; // 0x48
		private GameObject m_badgeParentObject; // 0x4C
		private bool m_isReceipt; // 0x50
		private int m_fontId; // 0x54
		private int m_iconId; // 0x58
		private LayoutQuestScrollListHorizontal.ItemParam m_itemParam; // 0x5C
		private LimitTimeWatcher m_timeWatcher = new LimitTimeWatcher(); // 0x60

		public bool IsClosed { get; set; } // 0x51

		// RVA: 0x1877958 Offset: 0x1877958 VA: 0x1877958
		private void Update()
		{
			m_timeWatcher.Update();
		}

		//// RVA: 0x1877984 Offset: 0x1877984 VA: 0x1877984
		private void ButtonCallbackEvent(LayoutQuestScrollListHorizontal.ItemParam itemParam)
		{
			QuestTopFormQuestListArgs args = new QuestTopFormQuestListArgs(itemParam.questData);
			if(MenuScene.Instance != null)
			{
				if(!MenuScene.CheckDatelineAndAssetUpdate())
				{
					if(itemParam.questData.COAMJFMEIBF != null)
					{
						itemParam.questData.COAMJFMEIBF.IONOAFPLANN = itemParam.questData.KJILFMNCDLC() == 0;
						this.StartCoroutineWatched(itemParam.questData.COAMJFMEIBF.EPOOEDJCBDN_Co_CheckClosedEvent((bool result) =>
						{
							//0x1879364
							if(result)
							{
								MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
							}
							else
							{
								if(itemParam.questData.NNHHNFFLCFO == BKANGIKIEML.NODKLJHEAJB.BPNDHDHHKGE_38)
								{
									if (GNGMCIAIKMA.HHCJCDFCLOB == null)
										return;
									GNGMCIAIKMA.HHCJCDFCLOB.DJGFICMNGGP_SetBingoId(itemParam.questData.PGIIDPEGGPI);
									GNGMCIAIKMA.HHCJCDFCLOB.BHFGBNNEMLI(itemParam.questData.PGIIDPEGGPI);
									if (!GNGMCIAIKMA.HHCJCDFCLOB.IDKFAMEFCPD(itemParam.questData.PGIIDPEGGPI) &&
										GNGMCIAIKMA.HHCJCDFCLOB.MLCGJAJCFDP(itemParam.questData.PGIIDPEGGPI, 0, 0) != 0)
									{
										MenuScene.Instance.Call(TransitionList.Type.BINGO_SELECT, args, true);
									}
									else
									{
										MenuScene.Instance.Call(TransitionList.Type.BINGO_MISSION, args, true);
									}
								}
								else
								{
									MenuScene.Instance.Call(TransitionList.Type.QUEST_SELECT, args, true);
								}
							}
						}));
						return;
					}
					if(itemParam.questData.NNHHNFFLCFO == BKANGIKIEML.NODKLJHEAJB.BPNDHDHHKGE_38)
					{
						if (GNGMCIAIKMA.HHCJCDFCLOB == null)
							return;
						GNGMCIAIKMA.HHCJCDFCLOB.DJGFICMNGGP_SetBingoId(itemParam.questData.PGIIDPEGGPI);
						GNGMCIAIKMA.HHCJCDFCLOB.BHFGBNNEMLI(itemParam.questData.PGIIDPEGGPI);
						if (!GNGMCIAIKMA.HHCJCDFCLOB.IDKFAMEFCPD(itemParam.questData.PGIIDPEGGPI) &&
							GNGMCIAIKMA.HHCJCDFCLOB.MLCGJAJCFDP(itemParam.questData.PGIIDPEGGPI, 0, 0) != 0)
						{
							MenuScene.Instance.Call(TransitionList.Type.BINGO_SELECT, args, true);
						}
						else
						{
							MenuScene.Instance.Call(TransitionList.Type.BINGO_MISSION, args, true);
						}
					}
					else
					{
						MenuScene.Instance.Call(TransitionList.Type.QUEST_SELECT, args, true);
					}
				}
			}
		}

		//// RVA: 0x1877E6C Offset: 0x1877E6C VA: 0x1877E6C
		//public bool IsReady() { }

		//// RVA: 0x1877E74 Offset: 0x1877E74 VA: 0x1877E74
		public GameObject GetBase()
		{
			return m_base;
		}

		//// RVA: 0x1877E7C Offset: 0x1877E7C VA: 0x1877E7C
		public void SetPosition(int x, int y)
		{
			if(m_rtTransform != null)
			{
				m_rtTransform.anchoredPosition = new Vector2(x, -y);
			}
		}

		// RVA: 0x1877F78 Offset: 0x1877F78 VA: 0x1877F78
		public void SetStatus(LayoutQuestScrollListHorizontal.ItemParam param)
		{
			m_itemParam = param;
			SetIcon(param.questData.JHAOHBNPMNA_EventId);
			SetFont(param.questData.LFCOJABLOEN);
			SwitchEmphasisIcon(param.questData.BEEIIJJKDBH, param.questData.BHANMJKCCBC_QuestAchievedCountText);
			SwitchReceiptIcon(param.questData.PNFDMBHDPAJ);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(param.questData.NNHHNFFLCFO == BKANGIKIEML.NODKLJHEAJB.BPNDHDHHKGE_38)
			{
				if(GNGMCIAIKMA.HHCJCDFCLOB == null)
				{
					SetBingoCount(string.Format(bk.GetMessageByLabel("bingo_count_text"), "1"+ "/"+"1"));
				}
				else
				{
					SetBingoCount(string.Format(bk.GetMessageByLabel("bingo_count_text"), GNGMCIAIKMA.HHCJCDFCLOB.EAIJHJPKBFA(param.questData.PGIIDPEGGPI).ToString() + "/" + GNGMCIAIKMA.HHCJCDFCLOB.EHFLAKIFPOO(param.questData.PGIIDPEGGPI).ToString()));
				}
			}
			else
			{
				SetBingoCount(null);
			}
			string s = "";
			if(param.questData.BALFPCLMOGJ != 0)
			{
				DateTime date = Utility.GetLocalDateTime(param.questData.BALFPCLMOGJ);
				s = string.Format(bk.GetMessageByLabel("bingo_next_charange"), date.Year, date.Month, date.Day);
			}
			SetNextCharange(param.questData.BALFPCLMOGJ != 0, s);
			SetTime(param.questData.PCCFAKEOBIC_End);
		}

		//// RVA: 0x1878728 Offset: 0x1878728 VA: 0x1878728
		public void SwitchEmphasisIcon(BadgeConstant.ID id, string text = "")
		{
			m_badge.Set(id, text);
		}

		//// RVA: 0x1878764 Offset: 0x1878764 VA: 0x1878764
		public void SwitchReceiptIcon(bool enable)
		{
			m_isReceipt = enable;
			m_receiptLayout.StartChildrenAnimGoStop(enable ? "01" : "02");
		}

		//// RVA: 0x18788E0 Offset: 0x18788E0 VA: 0x18788E0
		public void SetNextCharange(bool enable, string text)
		{
			if(enable)
			{
				m_bgLayout.StartChildrenAnimGoStop("02");
				m_receiptLayout.StartChildrenAnimGoStop("03");
				m_next.text = text;
			}
			else
			{
				m_bgLayout.StartChildrenAnimGoStop("01");
				SwitchReceiptIcon(m_isReceipt);
			}
			m_button.Disable = enable;
		}

		//// RVA: 0x1878A18 Offset: 0x1878A18 VA: 0x1878A18
		public void SetTime(long remainTime)
		{
			if (remainTime == 0)
				m_timeLayout.StartChildrenAnimGoStop("02");
			else
			{
				m_timeLayout.StartChildrenAnimGoStop("01");
				m_timeWatcher.onElapsedCallback = (long current, long limit, long remain) =>
				{
					//0x18792E4
					ApplyRemainTime(remain);
				};
				m_timeWatcher.onEndCallback = null;
				m_timeWatcher.WatchStart(remainTime, true);
			}
		}

		//// RVA: 0x1878B84 Offset: 0x1878B84 VA: 0x1878B84
		private void ApplyRemainTime(long remainSec)
		{
			int d, h, m, s;
			MusicSelectSceneBase.ExtractRemainTime((int)remainSec, out d, out h, out m, out s);
			m_time.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("music_event_remain_prefix") + MusicSelectSceneBase.MakeRemainTime(d, h, m, s);
		}

		//// RVA: 0x18787FC Offset: 0x18787FC VA: 0x18787FC
		public void SetBingoCount(string text)
		{
			if(string.IsNullOrEmpty(text))
			{
				m_countLayout.StartChildrenAnimGoStop("02");
			}
			else
			{
				m_countLayout.StartChildrenAnimGoStop("01");
				m_count.text = text;
			}
		}

		//// RVA: 0x1878380 Offset: 0x1878380 VA: 0x1878380
		public void SetIcon(int iconId)
		{
			if (m_bg == null)
				return;
			m_iconId = iconId;
			m_bg.enabled = false;
			GameManager.Instance.QuestEventTextureCache.LoadIcon(iconId, (IiconTexture texture) =>
			{
				//0x1879654
				if (iconId != m_iconId)
					return;
				m_bg.enabled = true;
				if(texture != null)
				{
					texture.Set(m_bg);
				}
			});
		}

		//// RVA: 0x1878554 Offset: 0x1878554 VA: 0x1878554
		public void SetFont(int fontId)
		{
			if (m_imageFont == null)
				return;
			m_fontId = fontId;
			m_imageFont.enabled = false;
			GameManager.Instance.QuestEventTextureCache.LoadFont(fontId, (IiconTexture texture) =>
			{
				//0x18797A0
				if (m_fontId != fontId)
					return;
				m_imageFont.enabled = true;
				if(texture != null)
				{
					texture.Set(m_imageFont);
				}
			});
		}

		// RVA: 0x1878CE8 Offset: 0x1878CE8 VA: 0x1878CE8
		public void ResetParam()
		{
			m_itemParam = null;
			SwitchEmphasisIcon(0, "");
			SwitchReceiptIcon(false);
		}

		// RVA: 0x1878D64 Offset: 0x1878D64 VA: 0x1878D64
		public void Dispose()
		{
			ResetParam();
			m_base = null;
			m_rtTransform = null;
		}

		// RVA: 0x1878D84 Offset: 0x1878D84 VA: 0x1878D84
		public void InitializeBadge()
		{
			m_badge.Initialize(m_badgeParentObject, m_badgeParentLayout);
		}

		// RVA: 0x1878DC0 Offset: 0x1878DC0 VA: 0x1878DC0
		public void ReleaseBadge()
		{
			m_badge.Release();
		}

		// RVA: 0x1878DEC Offset: 0x1878DEC VA: 0x1878DEC
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1878E24 Offset: 0x1878E24 VA: 0x1878E24
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1878E5C Offset: 0x1878E5C VA: 0x1878E5C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			LayoutUGUIRuntime r = GetComponentInParent<LayoutUGUIRuntime>();
			m_base = r.gameObject;
			m_rtTransform = GetComponent<RectTransform>();
			m_bgLayout = layout.FindViewByExId("cmn_event_icon_swtbl_quest_icon") as AbsoluteLayout;
			m_receiptLayout = layout.FindViewByExId("cmn_event_icon_swtbl_sel_que_whet_fnt") as AbsoluteLayout;
			m_timeLayout = layout.FindViewByExId("cmn_event_icon_sw_sel_que_count_frm_onoff") as AbsoluteLayout;
			m_countLayout = layout.FindViewByExId("cmn_event_icon_sw_bingo_onoff") as AbsoluteLayout;
			m_badgeParentLayout = layout.FindViewByExId("cmn_event_icon_swtbl_sel_que_notice_icon") as AbsoluteLayout;
			m_badgeParentObject = r.FindRectTransform(m_badgeParentLayout).gameObject;
			if(m_button != null)
			{
				m_button.AddOnClickCallback(() =>
				{
					//0x1879304
					ButtonCallbackEvent(m_itemParam);
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				});
			}
			Loaded();
			return true;
		}
	}
}
