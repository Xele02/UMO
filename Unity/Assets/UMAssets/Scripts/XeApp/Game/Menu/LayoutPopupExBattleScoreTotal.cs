using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using CriWare;
using System;
using System.Collections;
using XeSys;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class LayoutPopupExBattleScoreTotal : LayoutUGUIScriptBase
	{
		[SerializeField]
		private NumberBase m_totalScore; // 0x14
		[SerializeField]
		private Text m_rank; // 0x18
		[SerializeField]
		private ActionButton m_schedule; // 0x1C
		[SerializeField]
		private ActionButton m_OKButton; // 0x20
		[SerializeField]
		private ExBattleScoreContents[] m_musicRecordList = new ExBattleScoreContents[3]; // 0x24
		private const int EX_BATTLE_SCORE_NUM = 3;
		private AbsoluteLayout m_layout; // 0x28
		private AbsoluteLayout m_windowTitle; // 0x2C
		private AbsoluteLayout m_TotalScore; // 0x30
		private Transform m_parent; // 0x34
		private Transform m_parentPopup; // 0x38
		private bool IsAnimation; // 0x3C
		private bool m_isShow; // 0x3D
		private bool IsNumAnimation; // 0x3E
		private DCAKKIJODME m_view; // 0x40
		private CriAtomExPlayback m_CountUpSEPlayback; // 0x44

		public bool IsShow { get { return m_isShow; } } //0x1725EB4

		// // RVA: 0x1725EBC Offset: 0x1725EBC VA: 0x1725EBC
		public void SetUp(DCAKKIJODME _view, bool isUpdateHiscore)
		{
			if(m_parentPopup == null)
			{
				m_parentPopup = GameManager.Instance.PopupCanvas.transform.Find("Root").transform;
			}
			if(m_parent == null)
			{
				m_parent = transform.parent;
			}
			m_view = _view;
			if(m_view == null)
			{
				m_view = new DCAKKIJODME();
				m_view.KHEKNNFCAOI(false);
			}
			IsNumAnimation = isUpdateHiscore;
		}

		// // RVA: 0x17260EC Offset: 0x17260EC VA: 0x17260EC
		private void SetStatus(Action scheduleCallBack, Action<EMGOCNMMPHC> searchCallback, int playMusicIndex)
		{
			bool update = false;
			for(int i = 0; i < m_musicRecordList.Length; i++)
			{
				m_musicRecordList[i].gameObject.SetActive(true);
				m_musicRecordList[i].SetUp(m_view.JNALKFEADEM()[i]);
				m_musicRecordList[i].SetStatus();
				m_musicRecordList[i].IconEnable(m_view.JNALKFEADEM()[i].FFHMPNGJCLK_IsHighScore);
				m_musicRecordList[i].setSearchBtnAction((EMGOCNMMPHC _view) =>
				{
					//0x1727624
					OnClickBtn(() =>
					{
						//0x17278F8
						if(_view.OHBNMGEKPNF_HasC)
						{
							searchCallback.Invoke(_view);
						}
						else
						{
							this.StartCoroutineWatched(co_NonRecord());
						}
					});
				});
				if(playMusicIndex != i)
				{
					m_musicRecordList[i].HideButton();
				}
				update |= m_view.JNALKFEADEM()[i].FFHMPNGJCLK_IsHighScore;
			}
			WindowTitleState(update);
			m_schedule.ClearOnClickCallback();
			m_schedule.AddOnClickCallback(() =>
			{
				//0x1727720
				SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
				OnClickBtn(scheduleCallBack);
			});
			m_OKButton.ClearOnClickCallback();
			m_OKButton.AddOnClickCallback(() =>
			{
				//0x17277A0
				OnClickBtn(() =>
				{
					//0x1727854
					SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_WND_001);
					this.StartCoroutineWatched(co_close());
				});
			});
			m_totalScore.SetNumber(0, 0);
			m_rank.text = "0";
			m_schedule.Hidden = true;
		}

		// // RVA: 0x17267B8 Offset: 0x17267B8 VA: 0x17267B8
		private void OnClickBtn(Action OnClick)
		{
			if(IsPlaying())
				return;
			OnClick.Invoke();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x702C14 Offset: 0x702C14 VA: 0x702C14
		// // RVA: 0x172682C Offset: 0x172682C VA: 0x172682C
		private IEnumerator co_NonRecord()
		{
            //0x17286F4
            MessageBank menuBk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = "";
			s.WindowSize = SizeType.Small;
			s.IsCaption = false;
			s.Text = menuBk.GetMessageByLabel("ex_battle_non_record");
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(s, (PopupWindowControl content, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1727620
				return;
			}, null, null, null);
			yield break;
        }

		// [IteratorStateMachineAttribute] // RVA: 0x702C8C Offset: 0x702C8C VA: 0x702C8C
		// // RVA: 0x17268C0 Offset: 0x17268C0 VA: 0x17268C0
		private IEnumerator Co_TotalScoreCounter()
		{
			//0x172840C
			if(!IsNumAnimation)
			{
				m_totalScore.SetNumber(m_view.IGIPKOJJIIA_TotalScore, 0);
				if(m_view.FHBAEDLKEEN_Rank > 0)
				{
					m_rank.text = m_view.FHBAEDLKEEN_Rank.ToString();
				}
				else
				{
					m_rank.text = "---";
				}
			}
			else
			{
				while(IsPlaying())
					yield return null;
				IsAnimation = true;
				yield return Co.R(Co_CountUpGetPoint());
				IsAnimation = false;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x702D04 Offset: 0x702D04 VA: 0x702D04
		// // RVA: 0x172696C Offset: 0x172696C VA: 0x172696C
		private IEnumerator Co_CountUpGetPoint()
		{
			//0x1727AC8
			if(m_view.IGIPKOJJIIA_TotalScore > 0)
			{
				List<float> lf = new List<float>();
				int point = m_view.IGIPKOJJIIA_TotalScore;
				NumberAnimationUtility.MakeAccelerationTimeList(8, 0.24f, 0.02f, ref lf);
				PlayCountUpLoopSE();
				yield return this.StartCoroutineWatched(NumberAnimationUtility.Co_FakeCountup(point, lf, (int score) =>
				{
					//0x1727A18
					m_totalScore.SetNumber(score, 0);
				}, () =>
				{
					//0x1727A6C
					m_totalScore.SetNumber(point, 0);
				}, null));
				m_CountUpSEPlayback.Stop(false);
				yield return null;
				yield return new WaitWhile(() =>
				{
					//0x1727504
					return m_TotalScore.IsPlayingChildren();
				});
				m_totalScore.SetNumber(m_view.IGIPKOJJIIA_TotalScore, 0);
				if(m_view.FHBAEDLKEEN_Rank > 0)
				{
					m_rank.text = m_view.FHBAEDLKEEN_Rank.ToString();
				}
				else
				{
					m_rank.text = "---";
				}
			}
		}

		// // RVA: 0x1726A18 Offset: 0x1726A18 VA: 0x1726A18
		// public bool IsLoading() { }

		// // RVA: 0x17267F0 Offset: 0x17267F0 VA: 0x17267F0
		public bool IsPlaying()
		{
			return m_layout.IsPlayingChildren() || IsAnimation;
		}

		// // RVA: 0x1726AB4 Offset: 0x1726AB4 VA: 0x1726AB4
		public void Enter()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_WND_000);
			m_layout.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x1726B8C Offset: 0x1726B8C VA: 0x1726B8C
		public void Leave()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			m_layout.StartChildrenAnimGoStop("st_stop", "st_out");
		}

		// // RVA: 0x1726C64 Offset: 0x1726C64 VA: 0x1726C64
		// public void Show() { }

		// // RVA: 0x1726CE4 Offset: 0x1726CE4 VA: 0x1726CE4
		// public void Hide() { }

		// // RVA: 0x1726724 Offset: 0x1726724 VA: 0x1726724
		public void WindowTitleState(bool isUpDate)
		{
			m_windowTitle.StartChildrenAnimGoStop(isUpDate ? "01" : "02");
		}

		// // RVA: 0x1726D64 Offset: 0x1726D64 VA: 0x1726D64
		public void OpenWindow(Action scheduleCallBack, Action<EMGOCNMMPHC> searchCallback, int playMusicIndex/* = -1*/)
		{
			this.StartCoroutineWatched(Co_OpenWindow(scheduleCallBack, searchCallback, playMusicIndex));
			GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x702D7C Offset: 0x702D7C VA: 0x702D7C
		// // RVA: 0x1726E78 Offset: 0x1726E78 VA: 0x1726E78
		private IEnumerator Co_OpenWindow(Action scheduleCallBack, Action<EMGOCNMMPHC> searchCallback, int playMusicIndex)
		{
			KDLPEDBKMID install; // 0x20
			bool InstallCheck; // 0x24

			//0x1727F8C
			MenuScene.Instance.RaycastDisable();
			m_isShow = true;
			install = KDLPEDBKMID.HHCJCDFCLOB;
			InstallCheck = false;
			for(int i = 3; i != 0; i--)
			{
				InstallCheck |= install.BDOFDNICMLC_StartInstallIfNeeded(MusicJacketTextureCache.MakeJacketTexturePath(0));
			}
			yield return null;
			if(InstallCheck)
			{
				while(install.LNHFLJBGGJB_IsRunning)
					yield return null;
			}
			transform.SetParent(m_parentPopup);
			transform.SetAsFirstSibling();
			yield return null;
			SetStatus(scheduleCallBack, searchCallback, playMusicIndex);
			yield return null;
			Enter();
			yield return Co.R(Co_TotalScoreCounter());
			while(IsPlaying())
				yield return null;
			MenuScene.Instance.RaycastEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x702DF4 Offset: 0x702DF4 VA: 0x702DF4
		// // RVA: 0x1726F70 Offset: 0x1726F70 VA: 0x1726F70
		private IEnumerator co_close()
		{
			//0x1728B4C
			MenuScene.Instance.RaycastDisable();
			Leave();
			yield return null;
			while(IsPlaying())
				yield return null;
			MenuScene.Instance.RaycastEnable();
			transform.SetParent(m_parent);
			m_isShow = false;
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
		}

		// RVA: 0x172701C Offset: 0x172701C VA: 0x172701C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layout = layout.FindViewById("sw_pop_ex_btl_win_scr_02_inout_anim") as AbsoluteLayout;
			m_windowTitle = layout.FindViewByExId("sw_pop_ex_btl_win_scr_02_swtbl_g_r_e_newrec") as AbsoluteLayout;
			m_TotalScore = layout.FindViewByExId("sw_pop_ex_btl_win_scr_02_swnum_event_score") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// // RVA: 0x17271E4 Offset: 0x17271E4 VA: 0x17271E4
		private void PlayCountUpLoopSE()
		{
			m_CountUpSEPlayback = SoundManager.Instance.sePlayerResult.Play(0);
		}

		// // RVA: 0x1727244 Offset: 0x1727244 VA: 0x1727244
		// private void StopCountUpLoopSE() { }

		// // RVA: 0x1727250 Offset: 0x1727250 VA: 0x1727250
		public void ButtonDisable()
		{
			m_schedule.IsInputOff = true;
			m_OKButton.IsInputOff = true;
			for(int i = 0; i < m_musicRecordList.Length; i++)
			{
				m_musicRecordList[i].ButtonDisable();
			}
		}

		// // RVA: 0x1727328 Offset: 0x1727328 VA: 0x1727328
		public void ButtonEnable()
		{
			m_schedule.IsInputOff = false;
			m_OKButton.IsInputOff = false;
			for(int i = 0; i < m_musicRecordList.Length; i++)
			{
				m_musicRecordList[i].ButtonEnable();
			}
		}

		// // RVA: 0x1727400 Offset: 0x1727400 VA: 0x1727400
		private void OnBackButton()
		{
			OnClickBtn(() =>
			{
				//0x1727530
				SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_WND_001);
				this.StartCoroutineWatched(co_close());
			});
		}

		// [CompilerGeneratedAttribute] // RVA: 0x702E6C Offset: 0x702E6C VA: 0x702E6C
		// // RVA: 0x1727504 Offset: 0x1727504 VA: 0x1727504
		// private bool <Co_CountUpGetPoint>b__23_2() { }
	}
}
