using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;
using XeSys;
using XeApp.Game.UI;
using System.Collections;
using UnityEngine.Localization.SmartFormat;

namespace XeApp.Game.Menu
{
	public class LayoutEventGoDivaEventInfo : LayoutUGUIScriptBase
	{
		public enum StatusType
		{
			Soul = 0,
			Voice = 1,
			Charm = 2,
			Num = 3,
		}
 
		private enum InfoTextType
		{
			TitleHighScore = 0,
			TitleRank = 1,
			TitleTotalPoint = 2,
			TitleNextPoint = 3,
			TitleNextReward = 4,
			ValueHighScore = 5,
			ValueRank = 6,
			ValueTotalPoint = 7,
			ValueNextPoint = 8,
			UnitRank = 9,
			UnitTotalPoint = 10,
			UnitNextPoint = 11,
			ValueNextReward = 12,
			Num = 13,
		}

		private static int HighScoreDispMax = 99999999; // 0x0
		private static int RankDispMax = 99999999; // 0x4
		private static int TotalPointDispMax = 99999999; // 0x8
		private static int NextPointkDispMax = 99999999; // 0xC
		private static float GaugeMoveTime = 0.5f; // 0x10
		private static int GaugeFrameMax = 100; // 0x14
		private static string[] StatusNameTbl = new string[3]
		{
			"soul", "voice", "charm"
		}; // 0x18
		[SerializeField]
		private NumberBase[] m_numStatusTotalLvTbl; // 0x14
		[SerializeField]
		private Text[] m_textStatusExpTbl; // 0x18
		[SerializeField]
		private ActionButton m_buttonStatusDetail; // 0x1C
		[SerializeField]
		private Text[] m_textInfoTbl; // 0x20
		[SerializeField]
		private RawImageEx m_imageNextReward; // 0x24
		private bool m_isShown; // 0x28
		private AbsoluteLayout m_layoutMain; // 0x2C
		private AbsoluteLayout m_layoutStatusItems; // 0x30
		private AbsoluteLayout m_layoutButtonStatusDetail; // 0x34
		private AbsoluteLayout m_layoutNextReward; // 0x38
		private AbsoluteLayout[] m_layoutStatusGaugeStateTbl = new AbsoluteLayout[3]; // 0x3C
		private AbsoluteLayout[] m_layoutStatusGaugeFrameTbl = new AbsoluteLayout[3]; // 0x40
		private AbsoluteLayout m_layoutDivaNameTbl; // 0x44
		private int[] m_statusExpLimitTbl = new int[3]; // 0x48
		private int[] m_statusExpTbl = new int[3]; // 0x4C
		private FloatMover[] m_moverGaugeRateTbl = new FloatMover[3]; // 0x50
		private Coroutine[] m_coroutineGaugeUpdateTbl = new Coroutine[3]; // 0x54
		private Coroutine m_coroutineWaitEnter; // 0x58
		private int m_nextRewardTextureLoadingCount; // 0x5C
		public Action OnClickStatusDetailButtonListener; // 0x60

		// public bool IsLoadingNextRewardTexture { get; } 0x18CBB58

		// // RVA: 0x18CBB6C Offset: 0x18CBB6C VA: 0x18CBB6C
		public void Enter()
		{
			m_isShown = true;
			m_layoutMain.StartChildrenAnimGoStop("go_in", "st_in");
			if(m_coroutineWaitEnter != null)
				this.StopCoroutineWatched(m_coroutineWaitEnter);
			for(int i = 0; i < 3; i++)
			{
				m_layoutStatusGaugeFrameTbl[i].StartChildrenAnimGoStop(0, 0);
				m_textStatusExpTbl[i].text = string.Format("{0}/{1}", 0, m_statusExpLimitTbl[i]);
			}
			m_coroutineWaitEnter = this.StartCoroutineWatched(Co_WaitEnter());
		}

		// // RVA: 0x18CBE38 Offset: 0x18CBE38 VA: 0x18CBE38
		public void Leave()
		{
			m_isShown = false;
			m_layoutMain.StartChildrenAnimGoStop("go_out", "st_out");
			if(m_coroutineWaitEnter != null)
				this.StopCoroutineWatched(m_coroutineWaitEnter);
		}

		// // RVA: 0x18CBEE4 Offset: 0x18CBEE4 VA: 0x18CBEE4
		public void TryEnter()
		{
			if(!m_isShown)
				Enter();
		}

		// // RVA: 0x18CBEF4 Offset: 0x18CBEF4 VA: 0x18CBEF4
		public void TryLeave()
		{
			if(m_isShown)
				Leave();
		}

		// // RVA: 0x18CBF04 Offset: 0x18CBF04 VA: 0x18CBF04
		// public void Show() { }

		// // RVA: 0x18CC41C Offset: 0x18CC41C VA: 0x18CC41C
		public void Hide()
		{
			m_isShown = false;
			m_layoutMain.StartChildrenAnimGoStop("st_wait");
			if(m_coroutineWaitEnter != null)
				this.StopCoroutineWatched(m_coroutineWaitEnter);
		}

		// RVA: 0x18CC4B8 Offset: 0x18CC4B8 VA: 0x18CC4B8
		public bool IsPlaying()
		{
			return m_layoutMain.IsPlayingChildren();
		}

		// // RVA: 0x18CC4E4 Offset: 0x18CC4E4 VA: 0x18CC4E4
		public void SetTotalPoint(int point)
		{
			m_textInfoTbl[7].text = ClampTotalPoint(point).ToString();
		}

		// // RVA: 0x18CC648 Offset: 0x18CC648 VA: 0x18CC648
		// public void SetTotalPointInvalid() { }

		// // RVA: 0x18CC734 Offset: 0x18CC734 VA: 0x18CC734
		public void SetNextPoint(int point)
		{
			m_textInfoTbl[8].text = ClampNextPoint(point).ToString();
		}

		// // RVA: 0x18CC898 Offset: 0x18CC898 VA: 0x18CC898
		public void SetNextPointInvalid()
		{
			m_textInfoTbl[8].text = TextConstant.InvalidText;
		}

		// // RVA: 0x18CC984 Offset: 0x18CC984 VA: 0x18CC984
		public void SetNextRewardTexture(int itemId)
		{
			m_nextRewardTextureLoadingCount++;
			GameManager.Instance.ItemTextureCache.Load(itemId, (IiconTexture image) =>
			{
				//0x18CED28
				image.Set(m_imageNextReward);
				m_nextRewardTextureLoadingCount--;
			});
			m_layoutNextReward.StartChildrenAnimGoStop("01");
		}

		// // RVA: 0x18CCAD0 Offset: 0x18CCAD0 VA: 0x18CCAD0
		public void SetNextRewardTextureInvalid()
		{
			m_layoutNextReward.StartChildrenAnimGoStop("02");
		}

		// // RVA: 0x18CCB4C Offset: 0x18CCB4C VA: 0x18CCB4C
		public void SetStatusItemsVisible(bool isVisible)
		{
			if(isVisible)
			{
				m_layoutStatusItems.StartChildrenAnimGoStop("01");
				m_buttonStatusDetail.enabled = true;
				m_layoutButtonStatusDetail.StartChildrenAnimGoStop("st_bot_decide");
			}
			else
			{
				m_layoutStatusItems.StartChildrenAnimGoStop("02");
				m_buttonStatusDetail.enabled = false;
				m_layoutButtonStatusDetail.StartChildrenAnimGoStop("st_non");
			}
		}

		// // RVA: 0x18CCC8C Offset: 0x18CCC8C VA: 0x18CCC8C
		public void SetStatusValue(StatusType type, int level, int levelLimit, int currentExp, int nextExp, bool isUseGaugeAnime)
		{
			m_numStatusTotalLvTbl[(int)type].SetNumber(level, 0);
			m_statusExpTbl[(int)type] = currentExp;
			m_statusExpLimitTbl[(int)type] = nextExp;
			if(levelLimit <= level)
			{
				m_statusExpLimitTbl[(int)type] = 0;
			}
			m_layoutStatusGaugeStateTbl[(int)type].StartChildrenAnimGoStop(level < levelLimit ? "01" : "02");
			if(!m_isShown)
				return;
			if(isUseGaugeAnime)
				StartStatusGaugeUpdate(type, false);
			else
				SetStatusGauge(type);
		}

		// // RVA: 0x18CD138 Offset: 0x18CD138 VA: 0x18CD138
		public void SetDivaName(int divaId)
		{
			m_layoutDivaNameTbl.StartChildrenAnimGoStop(string.Format("{0:D2}", divaId));
		}

		// // RVA: 0x18CD1F0 Offset: 0x18CD1F0 VA: 0x18CD1F0
		public void SetRankingInfo(long highScore, int rank, bool isJoin)
		{
			if(isJoin)
			{
				m_textInfoTbl[5].text = ClampHighScore(highScore).ToString();
				m_textInfoTbl[6].text = ClampRank(rank).ToString();
			}
			else
			{
				m_textInfoTbl[5].text = TextConstant.InvalidText;
				m_textInfoTbl[6].text = TextConstant.InvalidText;
			}
		}

		// // RVA: 0x18CD5D0 Offset: 0x18CD5D0 VA: 0x18CD5D0
		public void SetRankingInfoCounting(long highScore, bool isJoin)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(isJoin)
			{
				m_textInfoTbl[5].text = ClampHighScore(highScore).ToString();
			}
			else
			{
				m_textInfoTbl[5].text = TextConstant.InvalidText;
			}
			m_textInfoTbl[1].text = bk.GetMessageByLabel("godiva_even_tinfo_final_rank");
			m_textInfoTbl[6].text = bk.GetMessageByLabel("godiva_even_tinfo_rank_collecting");
			m_textInfoTbl[9].text = bk.GetMessageByLabel("");
		}

		// // RVA: 0x18CD8D4 Offset: 0x18CD8D4 VA: 0x18CD8D4
		public void SetRankingInfoFinish(long highScore, int rank, bool isJoin)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(isJoin)
			{
				m_textInfoTbl[5].text = ClampHighScore(highScore).ToString();
				m_textInfoTbl[6].text = ClampRank(rank).ToString();
			}
			else
			{
				m_textInfoTbl[5].text = TextConstant.InvalidText;
				m_textInfoTbl[6].text = TextConstant.InvalidText;
			}
			m_textInfoTbl[1].text = bk.GetMessageByLabel("godiva_even_tinfo_final_rank");
		}

		// // RVA: 0x18CD420 Offset: 0x18CD420 VA: 0x18CD420
		private long ClampHighScore(long highScore)
		{
			return System.Math.Min(highScore, HighScoreDispMax);
		}

		// // RVA: 0x18CD504 Offset: 0x18CD504 VA: 0x18CD504
		private int ClampRank(int rank)
		{
			return System.Math.Min(rank, RankDispMax);
		}

		// // RVA: 0x18CC57C Offset: 0x18CC57C VA: 0x18CC57C
		private int ClampTotalPoint(int totalPoint)
		{
			return Mathf.Min(TotalPointDispMax, totalPoint);
		}

		// // RVA: 0x18CC7CC Offset: 0x18CC7CC VA: 0x18CC7CC
		private int ClampNextPoint(int nextPoint)
		{
			return Mathf.Min(NextPointkDispMax, nextPoint);
		}

		// // RVA: 0x18CDBD8 Offset: 0x18CDBD8 VA: 0x18CDBD8
		private void OnClickStatusDetailButton()
		{
			if(OnClickStatusDetailButtonListener != null)
				OnClickStatusDetailButtonListener();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F149C Offset: 0x6F149C VA: 0x6F149C
		// // RVA: 0x18CBDAC Offset: 0x18CBDAC VA: 0x18CBDAC
		private IEnumerator Co_WaitEnter()
		{
			//0x18CF29C
			while(IsPlaying())
				yield return null;
			for(int i = 0; i < 3; i++)
			{
				StartStatusGaugeUpdate((StatusType)i, true);
			}
		}

		// // RVA: 0x18CBFBC Offset: 0x18CBFBC VA: 0x18CBFBC
		private void SetStatusGauge(StatusType type)
		{
			if(m_coroutineGaugeUpdateTbl[(int)type] != null)
			{
				this.StopCoroutineWatched(m_coroutineGaugeUpdateTbl[(int)type]);
			}
			float f = 1;
			if(m_statusExpLimitTbl[(int)type] > 0)
			{
				f = Mathf.Min(1, Mathf.Max(m_statusExpTbl[(int)type] - 1, 0) * 1.0f / Mathf.Max(1, m_statusExpLimitTbl[(int)type] - 1));
			}
			m_moverGaugeRateTbl[(int)type].Start(f, f, 0, FloatMover.MoveType.Sin);
			m_layoutStatusGaugeFrameTbl[(int)type].StartChildrenAnimGoStop((int)f, (int)f);
			m_textStatusExpTbl[(int)type].text = string.Format("{0}/{1}", m_statusExpTbl[(int)type], m_statusExpLimitTbl[(int)type]);
		}

		// // RVA: 0x18CCED8 Offset: 0x18CCED8 VA: 0x18CCED8
		private void StartStatusGaugeUpdate(StatusType type, bool isZeroStart)
		{
			if(m_coroutineGaugeUpdateTbl[(int)type] != null)
			{
				this.StopCoroutineWatched(m_coroutineGaugeUpdateTbl[(int)type]);
			}
			m_coroutineGaugeUpdateTbl[(int)type] = this.StartCoroutineWatched(Co_StatusGaugeUpdate(m_layoutStatusGaugeFrameTbl[(int)type],
				m_textStatusExpTbl[(int)type], m_moverGaugeRateTbl[(int)type], m_statusExpTbl[(int)type], 
				m_statusExpLimitTbl[(int)type], isZeroStart));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F1514 Offset: 0x6F1514 VA: 0x6F1514
		// // RVA: 0x18CDC0C Offset: 0x18CDC0C VA: 0x18CDC0C
		private IEnumerator Co_StatusGaugeUpdate(AbsoluteLayout layout, Text text, FloatMover mover, int exp, int expLimit, bool isZeroStart)
		{
			//0x18CEE18
			float f = 0;
			if(!isZeroStart)
			{
				f = mover.Value;
			}
			float f2 = 1;
			if(expLimit >= 1)
			{
				f2 = Mathf.Min(1, Mathf.Max(0, exp - 1) * 1.0f / Mathf.Max(1, expLimit - 1));
			}
			mover.Start(f, f2, GaugeMoveTime, FloatMover.MoveType.Sin);
			do
			{
				mover.Update();
				int v = (int)(mover.Value * GaugeFrameMax);
				layout.StartChildrenAnimGoStop(v, v);
				if(mover.IsMoving)
				{
					text.text = string.Format("{0}/{1}", (int)(mover.Value * expLimit), expLimit);
				}
				else
				{
					text.text = string.Format("{0}/{1}", exp, expLimit);
				}
				yield return null;
			} while(mover.IsMoving);
		}

		// RVA: 0x18CDD38 Offset: 0x18CDD38 VA: 0x18CDD38 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_layoutMain = layout.FindViewById("sw_sel_me3_info_inout_anim") as AbsoluteLayout;
			m_layoutStatusItems = layout.FindViewById("sw_sel_me3_name_bar_onoff_anim") as AbsoluteLayout;
			m_layoutButtonStatusDetail = layout.FindViewById("sw_sel_me3_btn_anim") as AbsoluteLayout;
			m_layoutNextReward = layout.FindViewById("swtbl_item") as AbsoluteLayout;
			for(int i = 0; i < StatusNameTbl.Length; i++)
			{
				m_layoutStatusGaugeStateTbl[i] = layout.FindViewById(string.Format("sw_sel_me3_guage_{0}", StatusNameTbl[i])) as AbsoluteLayout;
				m_layoutStatusGaugeFrameTbl[i] = layout.FindViewById(string.Format("swfrm_sel_me3_guage_{0}", StatusNameTbl[i])) as AbsoluteLayout;
			}
			m_layoutDivaNameTbl = m_layoutStatusItems.FindViewById("swtbl_sel_me3_diva_name") as AbsoluteLayout;
			m_buttonStatusDetail.AddOnClickCallback(OnClickStatusDetailButton);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textInfoTbl[0].text = bk.GetMessageByLabel("godiva_event_info_highscore");
			m_textInfoTbl[1].text = bk.GetMessageByLabel("godiva_even_tinfo_rank");
			m_textInfoTbl[2].text = bk.GetMessageByLabel("godiva_even_tinfo_total_point");
			m_textInfoTbl[3].text = bk.GetMessageByLabel("godiva_even_tinfo_next_point");
			m_textInfoTbl[4].text = bk.GetMessageByLabel("godiva_even_tinfo_nest_reward");
			m_textInfoTbl[9].text = Smart.Format(bk.GetMessageByLabel("godiva_even_tinfo_rank_unit"), 0);
			m_textInfoTbl[10].text = bk.GetMessageByLabel("godiva_even_tinfo_point_unit");
			m_textInfoTbl[11].text = bk.GetMessageByLabel("godiva_even_tinfo_point_unit");
			m_textInfoTbl[12].text = TextConstant.InvalidText;
			for(int i = 0; i < 3; i++)
			{
				m_moverGaugeRateTbl[i] = new FloatMover();
			}
			Loaded();
			return true;
		}
	}
}
