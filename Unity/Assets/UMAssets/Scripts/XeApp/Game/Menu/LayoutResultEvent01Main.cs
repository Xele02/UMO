using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CriWare;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeApp.Game.Common.uGUI;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutResultEvent01Main : LayoutUGUIScriptBase
	{
		private class ItemLayout
		{
			public RawImageEx icon; // 0x8
			public NumberBase count; // 0xC
			public Text point; // 0x10
			public Text total; // 0x14
			public int target_num; // 0x18
		}

		public Action m_OnOpenPopup; // 0x14
		public Action m_OnFinished; // 0x18
		public LayoutResultEventHiScoreWindow m_layoutEventHiScoreWindow; // 0x1C
		public bool m_enable_skip = true; // 0x20
		private GCODMEIACDE m_ResultData; // 0x24
		private AbsoluteLayout m_RootAnim; // 0x28
		private AbsoluteLayout m_MainAnim; // 0x2C
		private AbsoluteLayout m_TitleAnim; // 0x30
		private AbsoluteLayout[] m_DashAnim = new AbsoluteLayout[2]; // 0x34
		private AbsoluteLayout m_UpAnim; // 0x38
		private ItemLayout[] m_ItemLayoutList = new ItemLayout[3]; // 0x3C
		private Text[] m_PointText; // 0x40
		private Text m_TotalText; // 0x44
		private Text m_EpisodeBonus; // 0x48
		private Text m_EpisodeBonusMulti; // 0x4C
		private Text[] m_DashBonus; // 0x50
		private Text m_MedalNum; // 0x54
		private RawImageEx m_MedalImage; // 0x58
		private NumberBase m_RankNum; // 0x5C
		private Text m_EventHiScore; // 0x60
		private Text m_EventMusicRank; // 0x64
		private ActionButton m_EventDetailBtn; // 0x68
		private RawImageEx m_EventMusicJacketImage; // 0x6C
		private bool m_IsReward; // 0x70
		private bool m_IsEnterTitle; // 0x71
		private int m_loadingFileCount; // 0x74
		private int m_loadedFileCount; // 0x78
		private bool m_is_loading; // 0x7C
		private bool m_is_loading_music_jacket; // 0x7D
		private bool m_EnableEventHiScore; // 0x7E
		private bool m_IsEventHiScore; // 0x7F
		private CriAtomExPlayback m_CountUpSEPlayback; // 0x80

		// RVA: 0x1D99488 Offset: 0x1D99488 VA: 0x1D99488
		private void Start()
		{
			return;
		}

		// RVA: 0x1D9948C Offset: 0x1D9948C VA: 0x1D9948C
		private void Update()
		{
			return;
		}

		// RVA: 0x1D99490 Offset: 0x1D99490 VA: 0x1D99490
		private void OnDisable()
		{
			SoundManager.Instance.sePlayerResultLoop.Stop();
		}

		// RVA: 0x1D994E4 Offset: 0x1D994E4 VA: 0x1D994E4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_RootAnim = layout.FindViewByExId("root_game_res_event01_sw_game_res_event01_inout") as AbsoluteLayout;
			m_MainAnim = layout.FindViewById("sw_game_res_event01_anim") as AbsoluteLayout;
			m_TitleAnim = layout.FindViewById("sw_g_r_event_title_anim") as AbsoluteLayout;
			m_DashAnim[0] = layout.FindViewById("swtbl_dash") as AbsoluteLayout;
			m_DashAnim[1] = (layout.FindViewById("sw_get_medal") as AbsoluteLayout).FindViewById("swtbl_dash") as AbsoluteLayout;
			m_UpAnim = layout.FindViewById("swtbl_up") as AbsoluteLayout;
			Transform t = transform.Find("sw_game_res_event01_inout (AbsoluteLayout)/sw_game_res_event01_title (AbsoluteLayout)/sw_game_res_event01_anim (AbsoluteLayout)");
			for(int i = 0; i < m_ItemLayoutList.Length; i++)
			{
				Transform t2 = t.Find(string.Format("sw_item_fr_set_{0} (AbsoluteLayout)", m_ItemLayoutList.Length - i));
				RawImageEx[] imgs2 = t2.GetComponentsInChildren<RawImageEx>(true);
				NumberBase[] nbrs2 = t2.GetComponentsInChildren<NumberBase>(true);
				Text[] txts2 = t2.GetComponentsInChildren<Text>(true);
				ItemLayout lt = new ItemLayout();
				lt.icon = imgs2.Where((RawImageEx _) =>
				{
					//0x1D9D404
					return _.name == "cmn_item (ImageView)";
				}).First();
				lt.count = nbrs2.Where((NumberBase _) =>
				{
					//0x1D9D484
					return _.name == "swnum_itemnum (AbsoluteLayout)";
				}).First();
				lt.point = txts2.Where((Text _) =>
				{
					//0x1D9D504
					return _.name == "itempt1 (TextView)";
				}).First();
				lt.total = txts2.Where((Text _) =>
				{
					//0x1D9D584
					return _.name == "itempt2 (TextView)";
				}).First();
				m_ItemLayoutList[i] = lt;
			}
			Text[] txts = GetComponentsInChildren<Text>(true);
			m_PointText = txts.Where((Text _) =>
			{
				//0x1D9D604
				return _.name == "points (TextView)";
			}).ToArray();
			m_TotalText = txts.Where((Text _) =>
			{
				//0x1D9D684
				return _.name == "total (TextView)";
			}).First();
			m_EpisodeBonus = txts.Where((Text _) =>
			{
				//0x1D9D704
				return _.name == "epi (TextView)";
			}).First();
			m_EpisodeBonusMulti = txts.Where((Text _) =>
			{
				//0x1D9D784
				return _.name == "epi_multi (TextView)";
			}).First();
			m_DashBonus = txts.Where((Text _) =>
			{
				//0x1D9D804
				return _.name == "dash (TextView)";
			}).ToArray();
			m_MedalNum = txts.Where((Text _) =>
			{
				//0x1D9D884
				return _.name == "medal (TextView)";
			}).First();
			m_EventHiScore = txts.Where((Text _) =>
			{
				//0x1D9D904
				return _.name == "eve_hiscore (TextView)";
			}).First();
			m_EventMusicRank = txts.Where((Text _) =>
			{
				//0x1D9D984
				return _.name == "eve_mrank (TextView)";
			}).First();
			ActionButton[] btns = GetComponentsInChildren<ActionButton>(true);
			m_EventDetailBtn = btns.Where((ActionButton _) =>
			{
				//0x1D9DA04
				return _.name == "sw_g_eve_btn_dtl_anim (AbsoluteLayout)";
			}).First();
			RawImageEx[] imgs = GetComponentsInChildren<RawImageEx>(true);
			m_MedalImage = imgs.Where((RawImageEx _) =>
			{
				//0x1D9DA84
				return _.name == "swtexc_cmn_item_170002 (ImageView)";
			}).First();
			m_EventMusicJacketImage = imgs.Where((RawImageEx _) =>
			{
				//0x1D9DB04
				return _.name == "swtexc_cmn_cd (ImageView)";
			}).First();
			NumberBase[] nbrs = GetComponentsInChildren<NumberBase>(true);
			m_RankNum = nbrs.Where((NumberBase _) =>
			{
				//0x1D9DB84
				return _.name == "swnum_event_rank (AbsoluteLayout)";
			}).First();
			Loaded();
			return true;
		}

		// RVA: 0x1D9AF0C Offset: 0x1D9AF0C VA: 0x1D9AF0C
		public void Setup(GCODMEIACDE data, bool is_reward)
		{
			m_ResultData = data;
			m_is_loading = true;
			m_is_loading_music_jacket = true;
			m_loadedFileCount = 0;
			m_loadingFileCount = data.HBHMAKNGKFK.Count;
			for(int i = 0; i < data.HBHMAKNGKFK.Count; i++)
			{
				ItemLayout layout = m_ItemLayoutList[i];
				GameManager.Instance.ItemTextureCache.Load(data.HBHMAKNGKFK[i].KIJAPOFAGPN_ItemId, (IiconTexture texture) =>
				{
					//0x1D9DC04
					texture.Set(layout.icon);
					m_loadedFileCount++;
				});
				layout.count.SetNumber(data.HBHMAKNGKFK[i].HMFFHLPNMPH_Cnt, 0);
				layout.point.text = string.Concat(RichTextUtility.MakeColorTagString(data.HBHMAKNGKFK[i].DNBFMLBNAEE_Point.ToString(), SystemTextColor.ImportantColor) + JpStringLiterals.StringLiteral_1290);
				layout.total.text = data.HBHMAKNGKFK[i].AHOKAPCGJMA_TargetNum.ToString();
				layout.target_num = data.HBHMAKNGKFK[i].AHOKAPCGJMA_TargetNum;
			}
			for(int i = 0; i < m_PointText.Length; i++)
			{
				m_PointText[i].text = "0";
			}
			m_RankNum.SetNumber(m_ResultData.BKKPKIGLMCN_Ranks[0], 0);
			m_TotalText.text = m_ResultData.AHOKAPCGJMA_NewPoint.ToString();
			m_EpisodeBonus.text = m_ResultData.ANOCILKJGOJ_EpBonus.ToString() + JpStringLiterals.StringLiteral_11079;
			m_EpisodeBonusMulti.text = (m_ResultData.ODCLHPGHDHA_EpBonusMulti - 100).ToString();
			int s = m_ResultData.ODCLHPGHDHA_EpBonusMulti < 101 ? 1 : 0;
			m_UpAnim.StartChildrenAnimGoStop(s, s);
			if(data.OKBEOCOKGEI < 2)
			{
				m_DashAnim[0].StartChildrenAnimGoStop(1, 1);
				m_DashAnim[1].StartChildrenAnimGoStop(1, 1);
			}
			else
			{
				m_DashAnim[0].StartChildrenAnimGoStop(0, 0);
				m_DashAnim[1].StartChildrenAnimGoStop(0, 0);
			}
			for(int i = 0; i < m_DashBonus.Length; i++)
			{
				m_DashBonus[i].text = JpStringLiterals.StringLiteral_17823 + data.OKBEOCOKGEI.ToString() + JpStringLiterals.StringLiteral_17824;
			}
			m_MedalNum.text = m_ResultData.ODOOKDGCKMF_MedalNum.ToString();
			MenuScene.Instance.ItemTextureCache.Load(m_ResultData.BEOKMNIPFBA_MedalItemId, (IiconTexture texture) =>
			{
				//0x1D9D058
				texture.Set(m_MedalImage);
				m_is_loading = false;
			});
			m_IsReward = is_reward;
			EEDKAACNBBG_MusicData md = Database.Instance.selectedMusic.GetSelectedMusicData();
			KEODKEGFDLD_FreeMusicInfo fm = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(m_ResultData.OENBOLPDBAB_FreeMusicId);
 			if(data.BKKPKIGLMCN_Ranks[1] < 1)
				m_EnableEventHiScore = false;
			else
			{
				m_EnableEventHiScore = fm.DLAEJOBELBH_MusicId == md.DLAEJOBELBH_MusicId;
				if(m_EnableEventHiScore)
				{
					m_EventHiScore.text = m_ResultData.IJPAKGFADJB_HiScore.ToString();
					m_EventMusicRank.text = m_ResultData.BKKPKIGLMCN_Ranks[1].ToString();
					m_EventDetailBtn.AddOnClickCallback(CallbackBtnClick_EventDetail);
					EEDKAACNBBG_MusicData md2 = new EEDKAACNBBG_MusicData();
					md2.KHEKNNFCAOI(fm.DLAEJOBELBH_MusicId);
					MenuScene.Instance.MusicJacketTextureCache.Load(md2.JNCPEGJGHOG_JacketId, (IiconTexture texture) =>
					{
						//0x1D9D140
						texture.Set(m_EventMusicJacketImage);
						m_is_loading_music_jacket = false;
					});
					m_layoutEventHiScoreWindow.Setup(data);
					m_IsEventHiScore = data.GIIKOMPJOHA_IsHiScore;
				}
           	}
		}

		// RVA: 0x1D9BDF8 Offset: 0x1D9BDF8 VA: 0x1D9BDF8
		public bool IsLoading()
		{
			if(m_is_loading)
				return true;
			if(m_EnableEventHiScore)
			{
				if(m_is_loading_music_jacket)
					return true;
				if(!m_layoutEventHiScoreWindow.IsSetup())
					return true;
			}
			return m_loadingFileCount != m_loadedFileCount;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x719B04 Offset: 0x719B04 VA: 0x719B04
		// // RVA: 0x1D9BE70 Offset: 0x1D9BE70 VA: 0x1D9BE70
		// private IEnumerator Co_Countup(int startNum, int endNum, float accelPer, Action<int> onChangeNumberCallback) { }

		// RVA: 0x1D9BF74 Offset: 0x1D9BF74 VA: 0x1D9BF74
		public void StartBeginAnim()
		{
			this.StartCoroutineWatched(Co_PlayAnim());
		}

		// RVA: 0x1D9C024 Offset: 0x1D9C024 VA: 0x1D9C024
		public void SkipBeginAnim()
		{
			if(!m_enable_skip)
				return;
			m_CountUpSEPlayback.Stop();
			this.StopAllCoroutinesWatched();
			GameManager.Instance.InputEnabled = true;
			m_RootAnim.StartChildrenAnimGoStop("st_in");
			m_MainAnim.StartChildrenAnimGoStop(m_EnableEventHiScore ? "st_stop" : "st_rank");
			for(int i = 0; i < m_PointText.Length; i++)
			{
				m_PointText[i].text = m_ResultData.PHPANNCGOKC_GetPoint.ToString();
			}
			m_TotalText.text = m_ResultData.AHOKAPCGJMA_NewPoint.ToString();
			for(int i = 0; i < m_ItemLayoutList.Length; i++)
			{
				m_ItemLayoutList[i].total.text = m_ItemLayoutList[i].target_num.ToString();
			}
			if(!m_IsEnterTitle)
			{
				m_TitleAnim.StartAllAnimLoop("logo_up", "loen_up");
				m_IsEnterTitle = true;
			}
			this.StartCoroutineWatched(Co_SkipPopup());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x719B7C Offset: 0x719B7C VA: 0x719B7C
		// // RVA: 0x1D9C3A8 Offset: 0x1D9C3A8 VA: 0x1D9C3A8
		private IEnumerator Co_SkipPopup()
		{
			//0x1DA0100
			if(m_IsEventHiScore)
			{
				yield return Co.R(Co_OpenEventHiScoreWindow(1));
			}
			//LAB_01da01c4
			if(m_IsReward)
			{
				yield return this.StartCoroutineWatched(PopupRewardEvResult.Co_ShowPopup_CumulativePoint(transform, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x1D9D228
					m_OnFinished();
				}));
			}
			yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x719BF4 Offset: 0x719BF4 VA: 0x719BF4
		// // RVA: 0x1D9BF98 Offset: 0x1D9BF98 VA: 0x1D9BF98
		private IEnumerator Co_PlayAnim()
		{
			//0x1D9FD40
			m_RootAnim.StartChildrenAnimGoStop("go_in", "st_in");
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1D9D254
				return m_RootAnim.IsPlayingChildren();
			});
			this.StartCoroutineWatched(Co_EnterTitle());
			yield return Co.R(Co_EnterGetPoint());
			yield return Co.R(Co_CountUpGetPoint());
			yield return Co.R(Co_EnterTotalPoint());
			yield return Co.R(Co_EnterRank());
			if(m_EnableEventHiScore)
			{
				yield return Co.R(Co_EnterEventHiScore());
			}
			if(m_IsReward)
			{
				yield return Co.R(Co_GetReward());
			}
			m_OnFinished();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x719C6C Offset: 0x719C6C VA: 0x719C6C
		// // RVA: 0x1D9C474 Offset: 0x1D9C474 VA: 0x1D9C474
		private IEnumerator Co_EnterTitle()
		{
			//0x1D9F30C
			m_IsEnterTitle = false;
			m_TitleAnim.StartAllAnimGoStop("go_in", "st_in");
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1D9D280
				return m_TitleAnim.IsPlayingAll();
			});
			m_IsEnterTitle = true;
			m_TitleAnim.StartAllAnimLoop("logo_up", "loen_up");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x719CE4 Offset: 0x719CE4 VA: 0x719CE4
		// // RVA: 0x1D9C520 Offset: 0x1D9C520 VA: 0x1D9C520
		private IEnumerator Co_EnterGetPoint()
		{
			//0x1D9ECB4
			m_MainAnim.StartChildrenAnimGoStop("go_itemnum1", "st_pt");
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_035);
			yield return null;
			yield return Co.R(Co_WaitAnim("go_itemnum1"));
			yield return Co.R(Co_WaitAnim("go_itemnum2"));
			yield return Co.R(Co_WaitAnim("go_itemnum3"));
			yield return Co.R(Co_WaitAnim("go_episode"));
			yield return Co.R(Co_WaitAnim("go_pt"));
			yield return new WaitWhile(() =>
			{
				//0x1D9D2AC
				return m_MainAnim.IsPlayingChildren();
			});
		}

		// [IteratorStateMachineAttribute] // RVA: 0x719D5C Offset: 0x719D5C VA: 0x719D5C
		// // RVA: 0x1D9C5CC Offset: 0x1D9C5CC VA: 0x1D9C5CC
		private IEnumerator Co_CountUpGetPoint()
		{
			//0x1D9DD84
			if(m_ResultData.PHPANNCGOKC_GetPoint > 0)
			{
				List<float> lf = new List<float>();
				NumberAnimationUtility.MakeAccelerationTimeList(8, 0.24f, 0.02f, ref lf);
				PlayCountUpLoopSE();
				yield return this.StartCoroutineWatched(NumberAnimationUtility.Co_FakeCountup(m_ResultData.PHPANNCGOKC_GetPoint, lf, OnChangeGetPoint, null, null));
				m_CountUpSEPlayback.Stop();
				m_MainAnim.StartChildrenAnimGoStop("act_pt", "acten_pt");
				yield return null;
				yield return new WaitWhile(() =>
				{
					//0x1D9D2D8
					return m_MainAnim.IsPlayingChildren();
				});
			}
		}

		// // RVA: 0x1D9C678 Offset: 0x1D9C678 VA: 0x1D9C678
		private void OnChangeGetPoint(int num)
		{
			for(int i = 0; i < m_PointText.Length; i++)
			{
				m_PointText[i].text = num.ToString();
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x719DD4 Offset: 0x719DD4 VA: 0x719DD4
		// // RVA: 0x1D9C734 Offset: 0x1D9C734 VA: 0x1D9C734
		// private IEnumerator Co_CountUpItem() { }

		// // RVA: 0x1D9C7E0 Offset: 0x1D9C7E0 VA: 0x1D9C7E0
		// private void OnChangeItemPointS(int num) { }

		// // RVA: 0x1D9C878 Offset: 0x1D9C878 VA: 0x1D9C878
		// private void OnChangeItemPointM(int num) { }

		// // RVA: 0x1D9C910 Offset: 0x1D9C910 VA: 0x1D9C910
		// private void OnChangeItemPointL(int num) { }

		// [IteratorStateMachineAttribute] // RVA: 0x719E4C Offset: 0x719E4C VA: 0x719E4C
		// // RVA: 0x1D9C9A8 Offset: 0x1D9C9A8 VA: 0x1D9C9A8
		private IEnumerator Co_EnterTotalPoint()
		{
			//0x1D9F5A8
			m_MainAnim.StartChildrenAnimGoStop("go_total_pt", "st_total_pt");
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_036);
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1D9D304
				return m_MainAnim.IsPlayingChildren();
			});
		}

		// [IteratorStateMachineAttribute] // RVA: 0x719EC4 Offset: 0x719EC4 VA: 0x719EC4
		// // RVA: 0x1D9CA54 Offset: 0x1D9CA54 VA: 0x1D9CA54
		// private IEnumerator Co_CountUpTotalPoint() { }

		// // RVA: 0x1D9CB00 Offset: 0x1D9CB00 VA: 0x1D9CB00
		// private void OnChangeTotalPoint(int num) { }

		// [IteratorStateMachineAttribute] // RVA: 0x719F3C Offset: 0x719F3C VA: 0x719F3C
		// // RVA: 0x1D9CB54 Offset: 0x1D9CB54 VA: 0x1D9CB54
		private IEnumerator Co_EnterRank()
		{
			//0x1D9F040
			m_MainAnim.StartChildrenAnimGoStop("go_medal", "st_rank");
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_025);
			yield return null;
			yield return Co.R(Co_WaitAnim("go_medal"));
			yield return Co.R(Co_WaitAnim("go_rank"));
			yield return new WaitWhile(() =>
			{
				//0x1D9D330
				return m_MainAnim.IsPlayingChildren();
			});
		}

		// [IteratorStateMachineAttribute] // RVA: 0x719FB4 Offset: 0x719FB4 VA: 0x719FB4
		// // RVA: 0x1D9CC00 Offset: 0x1D9CC00 VA: 0x1D9CC00
		private IEnumerator Co_EnterEventHiScore()
		{
			//0x1D9E9D4
			m_EventDetailBtn.IsInputOff = m_IsEventHiScore;
			m_MainAnim.StartChildrenAnimGoStop("go_mrank", "st_stop");
			yield return null;
			yield return Co.R(Co_WaitAnim("go_mrank"));
			yield return new WaitWhile(() =>
			{
				//0x1D9D35C
				return m_MainAnim.IsPlayingChildren();
			});
			if(m_IsEventHiScore)
				yield return Co.R(Co_OpenEventHiScoreWindow(1));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71A02C Offset: 0x71A02C VA: 0x71A02C
		// // RVA: 0x1D9CCAC Offset: 0x1D9CCAC VA: 0x1D9CCAC
		private IEnumerator Co_OpenEventHiScoreWindow(int a_open_se/* = 0*/)
		{
			//0x1D9FA80
			if(m_layoutEventHiScoreWindow != null)
			{
				m_enable_skip = false;
				m_EventDetailBtn.IsInputOff = true;
				m_layoutEventHiScoreWindow.transform.SetAsLastSibling();
				this.StartCoroutineWatched(m_layoutEventHiScoreWindow.Co_PlayAnimOpen(a_open_se));
				while(m_layoutEventHiScoreWindow.IsOpen())
					yield return null;
				m_EventDetailBtn.IsInputOff = false;
				m_enable_skip = false;
				yield return null;
			}
		}

		// // RVA: 0x1D9CD74 Offset: 0x1D9CD74 VA: 0x1D9CD74
		private void CallbackBtnClick_EventDetail()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_OpenEventHiScoreWindow(0));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71A0A4 Offset: 0x71A0A4 VA: 0x71A0A4
		// // RVA: 0x1D9CDEC Offset: 0x1D9CDEC VA: 0x1D9CDEC
		private IEnumerator Co_GetReward()
		{
			//0x1D9F7EC
			m_OnOpenPopup();
			bool is_closed = false;
			this.StartCoroutineWatched(PopupRewardEvResult.Co_ShowPopup_CumulativePoint(transform, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1D9DD60
				is_closed = true;
			}));
			yield return new WaitWhile(() =>
			{
				//0x1D9DD6C
				return !is_closed;
			});
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71A11C Offset: 0x71A11C VA: 0x71A11C
		// // RVA: 0x1D9CE98 Offset: 0x1D9CE98 VA: 0x1D9CE98
		private IEnumerator Co_WaitAnim(string label)
		{
			//0x1DA0340
			while(m_MainAnim.GetView(0).FrameAnimation.FrameCount < m_MainAnim.GetView(0).FrameAnimation.SearchLabelFrame(label))
				yield return null;
		}

		// // RVA: 0x1D9CF60 Offset: 0x1D9CF60 VA: 0x1D9CF60
		private void PlayCountUpLoopSE()
		{
			m_CountUpSEPlayback = SoundManager.Instance.sePlayerResultLoop.Play(0);
		}

		// // RVA: 0x1D9C39C Offset: 0x1D9C39C VA: 0x1D9C39C
		// private void StopCountUpLoopSE() { }
	}
}
