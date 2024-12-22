using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using mcrs;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeApp.Game.Common.uGUI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class CostumeCompWindow : LayoutUGUIScriptBase
	{
		private struct GaugeLayout
		{
			public AbsoluteLayout root; // 0x0
			public AbsoluteLayout bar; // 0x4
			public AbsoluteLayout max; // 0x8
		}

		private struct EffectLyaout
		{
			public AbsoluteLayout root; // 0x0
			public AbsoluteLayout alpha; // 0x4
		}

		private const int GAUGE_FRAME_NUM = 103;
		private const float GaugeTime = 1;
		private LFAFJCNKLML m_data; // 0x14
		private PopupCostumeComp m_pop_window; // 0x18
		private int m_currentPoint; // 0x1C
		private int m_addPoint; // 0x20
		private AbsoluteLayout m_baseLayout; // 0x30
		private NumberBase m_get_point; // 0x34
		private CostumeUpgradeUtility.RewardIconLayoutSetting m_reward_icon; // 0x38
		private AbsoluteLayout m_get_icon; // 0x4C
		private CostumeUpgradeUtility.CostumeData m_costume = new CostumeUpgradeUtility.CostumeData(); // 0x50
		private AbsoluteLayout m_rank_up_anim; // 0x54
		private Text m_need_point_text; // 0x58
		private GaugeLayout m_gauge; // 0x5C
		private EffectLyaout m_effect; // 0x68
		private bool m_is_wait_open_window; // 0x70
		private CostumeAchievePopupSetting m_achieve_window = new CostumeAchievePopupSetting(); // 0x74
		private CostumeCostumeStatusUpPopupSetting m_costume_stup_window = new CostumeCostumeStatusUpPopupSetting(); // 0x78
		private CostumeDivaStatusUpPopupSetting m_diva_stup_window = new CostumeDivaStatusUpPopupSetting(); // 0x7C
		private int m_rank; // 0x80
		private int m_reward_index; // 0x84
		private int m_next_rank_point; // 0x88
		private SimpleVoicePlayer m_voicePlayer; // 0x8C
		private int m_prev_offer_difficult; // 0x90
		private StringBuilder m_work_sb = new StringBuilder(32); // 0x94

		public LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType ItemType { get; private set; } // 0x24
		public int CostumeId { get; private set; } // 0x28
		public int CostumeColorId { get; private set; } // 0x2C

		// RVA: 0x1B6660C Offset: 0x1B6660C VA: 0x1B6660C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_rank_up_anim = layout.FindViewById("sw_c_b_rankup_anim") as AbsoluteLayout;
			Transform t = transform.Find("sw_rankup_pop_all (AbsoluteLayout)");
			m_get_point = t.Find("swnum_release_num01 (AbsoluteLayout)").GetComponent<NumberBase>();
			m_reward_icon.item_image = t.Find("cmn_ep_item_icon_02 (AbsoluteLayout)/swtexc_cmn_item (ImageView)").GetComponent<RawImageEx>();
			m_reward_icon.diva_image = t.Find("chara_icon_01 (AbsoluteLayout)/swtexc_cmn_chara_icon (ImageView)").GetComponent<RawImageEx>();
			m_reward_icon.get_num = t.Find("swtbl_item_type (AbsoluteLayout)/swnum_item_num01 (AbsoluteLayout)").GetComponent<NumberBase>();
			m_reward_icon.item_type = layout.FindViewByExId("sw_rankup_pop_all_swtbl_item_type") as AbsoluteLayout;
			m_reward_icon.item_rank = layout.FindViewById("swtbl_c_b_star_s") as AbsoluteLayout;
			t = t.Find("sw_c_b_rankup_anim (AbsoluteLayout)");
			m_costume.image = t.Find("swtbl_cos_01 (AbsoluteLayout)/cos_01_001 (AbsoluteLayout)/cos_01_001 (ImageView)").GetComponent<RawImageEx>();
			m_costume.rank.num = layout.FindViewById("swtbl_star_num_02") as AbsoluteLayout;
			m_costume.rank.enable = new List<AbsoluteLayout>();
			m_costume.rank.rank_up_anim = new List<AbsoluteLayout>();
			for(int i = 0; i < 6; i++)
			{
				AbsoluteLayout abs = layout.FindViewByExId("swtbl_star_num_02_swbtl_star_on_off_0" + (i + 1)) as AbsoluteLayout;
				m_costume.rank.enable.Add(abs);
				m_costume.rank.rank_up_anim.Add(abs.FindViewByExId("swtbl_star_on_off_sw_rankup_star_anim") as AbsoluteLayout);
			}
			m_get_icon = layout.FindViewByExId("sw_rankup_pop_all_swtbl_get_icon_01") as AbsoluteLayout;
			m_rank_up_anim = layout.FindViewById("sw_c_b_rankup_anim") as AbsoluteLayout;
			m_gauge.root = layout.FindViewById("sw_progress_anim") as AbsoluteLayout;
			m_gauge.max = layout.FindViewById("swtbl_release_switch") as AbsoluteLayout;
			m_gauge.bar = layout.FindViewById("sw_bar_anim") as AbsoluteLayout;
			m_need_point_text = t.Find("swtbl_release_switch (AbsoluteLayout)/sel_ep_point_count (AbsoluteLayout)/point_count_01 (TextView)").GetComponent<Text>();
			m_effect.root = layout.FindViewByExId("sw_s_c_b_makina_ef_sw_s_c_b_makina_ef_anim_all") as AbsoluteLayout;
			m_effect.alpha = layout.FindViewByExId("sw_rankup_pop_all_sw_s_c_b_makina_ef_anim_all") as AbsoluteLayout;
			m_pop_window = transform.GetComponent<PopupCostumeComp>();
			return true;
		}

		// // RVA: 0x1B6713C Offset: 0x1B6713C VA: 0x1B6713C
		public void SettingNextRewardPoint()
		{
			m_next_rank_point = m_data.OCOOHBINGBG_LevelInfo[GetRankToIndex()].DNBFMLBNAEE_NeedPoint;
		}

		// // RVA: 0x1B67260 Offset: 0x1B67260 VA: 0x1B67260
		public void Initialize(LFAFJCNKLML data, int add_point, int prev_offer_difficult, SimpleVoicePlayer voicePlayer)
		{
			m_data = data;
			m_currentPoint = data.ABLHIAEDJAI_Point;
			m_addPoint = add_point;
			m_rank = m_data.GKIKAABHAAD_Level;
			m_voicePlayer = voicePlayer;
			m_prev_offer_difficult = prev_offer_difficult;
			SettingNextRewardPoint();
			m_get_point.SetNumber(add_point, 0);
			SettingRankMaxLayout(-1);
			SetGauge(m_currentPoint);
			StartEffectAnimation();
			m_voicePlayer.PlayVoiceRandom(CostumeUpgradeVoiceDataTable.VoiceSetting(CostumeUpgradeVoiceDataTable.VoiceType.PointUp, 1), -1);
			m_costume.SetCostumeIcon(new CostumeUpgradeUtility.CostumeData.Setting() {
				divaId = data.AHHJLDLAPAN_DivaId,
				costumeModelId = data.DAJGPBLEEOB_PrismCostumeId,
				colorId = null,
				isHave = true,
				rankMax = data.LLLCMHENKKN_LevelMax,
				rankNum = m_rank
			}, null);
			UpdateRewardIcon();
		}

		// // RVA: 0x1B679C4 Offset: 0x1B679C4 VA: 0x1B679C4
		public void InitializeRestart()
		{
			int prevPoint = m_currentPoint;
			m_rank++;
			m_currentPoint = 0;
			m_addPoint = m_addPoint + prevPoint - m_next_rank_point;
			ItemType = LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.HJNNKCMLGFL_0_None;
			SettingRankMaxLayout(-1);
			SetGauge(m_currentPoint);
			m_costume.SetCostumeIcon(new CostumeUpgradeUtility.CostumeData.Setting() {
				divaId = m_data.AHHJLDLAPAN_DivaId,
				costumeModelId = m_data.DAJGPBLEEOB_PrismCostumeId,
				colorId = null,
				isHave = true,
				rankMax = m_data.LLLCMHENKKN_LevelMax,
				rankNum = m_rank
			}, null);
			UpdateRewardIcon();
		}

		// // RVA: 0x1B67ADC Offset: 0x1B67ADC VA: 0x1B67ADC
		public void InitializeReShow(LFAFJCNKLML data, int addPoint)
		{
			m_data = data;
			m_currentPoint = data.ABLHIAEDJAI_Point;
			m_get_point.SetNumber(addPoint, 0);
			ItemType = LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.HJNNKCMLGFL_0_None;
			SettingRankMaxLayout(-1);
			SetGauge(m_currentPoint);
			m_costume.SetCostumeIcon(new CostumeUpgradeUtility.CostumeData.Setting() {
				divaId = data.AHHJLDLAPAN_DivaId,
				costumeModelId = data.DAJGPBLEEOB_PrismCostumeId,
				colorId = null,
				isHave = true,
				rankMax = data.LLLCMHENKKN_LevelMax,
				rankNum = m_rank
			}, null);
			UpdateRewardIcon();
		}

		// // RVA: 0x1B67928 Offset: 0x1B67928 VA: 0x1B67928
		private void UpdateRewardIcon()
		{
			LFAFJCNKLML.GFIPDFPIKIJ v;
			LFAFJCNKLML.HKKKKFLBFJN(m_data, GetRankToIndex(), out v, 0);
			CostumeUpgradeUtility.SettingRewardIcon(m_data, v.GLCLFMGPMAN_ItemId, GetRankToIndex(), v.NANNGLGOFKH_Value, m_reward_icon, null);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CD95C Offset: 0x6CD95C VA: 0x6CD95C
		// // RVA: 0x1B67C2C Offset: 0x1B67C2C VA: 0x1B67C2C
		private IEnumerator ShowAchivementPopupCoroutine(LFAFJCNKLML data)
		{
			//0x1B68D5C
			m_achieve_window.data = data;
			m_achieve_window.voicePlayer = m_voicePlayer;
			m_is_wait_open_window = true;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_achieve_window.TitleText = bk.GetMessageByLabel("costume_upgrade_achievement_title_text");
			m_achieve_window.SetParent(transform);
			m_achieve_window.WindowSize = SizeType.Middle;
			m_achieve_window.Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive } };
			PopupWindowManager.Show(m_achieve_window, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1B68904
				if(label != PopupButton.ButtonLabel.Ok)
					return;
				ShowStatusUpWindow();
			}, null, null, null, endCallBaack:() =>
			{
				//0x1B68910
				m_is_wait_open_window = true;
			});
			yield return new WaitWhile(() =>
			{
				//0x1B6891C
				return m_is_wait_open_window;
			});
		}

		// // RVA: 0x1B67CF4 Offset: 0x1B67CF4 VA: 0x1B67CF4
		public void ShowStatusUpWindow()
		{
			if(m_achieve_window.data.JHLKLPEHHCD_GetCurrentLevelInfo().PEEAGFNOFFO_UnlockType == LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.NKKIKONDGPF_1_CostumeEffect)
			{
				m_costume_stup_window.IsCaption = false;
				m_costume_stup_window.TitleText = "";
				m_costume_stup_window.WindowSize = SizeType.Middle;
				m_costume_stup_window.m_data = m_data;
				m_costume_stup_window.SetParent(transform);
				m_costume_stup_window.Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive } };
				PopupWindowManager.Show(m_costume_stup_window, OnAchieveOKButton, null, null, null);
			}
			else if(m_achieve_window.data.JHLKLPEHHCD_GetCurrentLevelInfo().PEEAGFNOFFO_UnlockType == LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.PJJJGFBLIAP_5_Stat)
			{
				m_diva_stup_window.IsCaption = false;
				m_diva_stup_window.TitleText = "";
				m_diva_stup_window.WindowSize = SizeType.Middle;
				m_diva_stup_window.m_data = m_data;
				m_diva_stup_window.SetParent(transform);
				m_diva_stup_window.Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive } };
				PopupWindowManager.Show(m_diva_stup_window, OnAchieveOKButton, null, null, null);
			}
			else
			{
				ShowCommonAchieveWindow();
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CD9D4 Offset: 0x6CD9D4 VA: 0x6CD9D4
		// // RVA: 0x1B68258 Offset: 0x1B68258 VA: 0x1B68258
		private IEnumerator RankUpAnimation()
		{
			//0x1B689F4
			m_gauge.root.StartChildrenAnimGoStop("go_in", "st_in");
			m_rank_up_anim.StartChildrenAnimGoStop("go_in", "st_in");
			m_costume.StartRankUpAnimation(m_rank);
			yield return new WaitWhile(() =>
			{
				//0x1B68924
				return m_rank_up_anim.IsPlayingChildren();
			});
			m_costume.SetCostumeIcon(new CostumeUpgradeUtility.CostumeData.Setting() {
				divaId = m_data.AHHJLDLAPAN_DivaId,
				costumeModelId = m_data.DAJGPBLEEOB_PrismCostumeId,
				colorId = null,
				isHave = true,
				rankMax = m_data.LLLCMHENKKN_LevelMax,
				rankNum = m_rank + 1
			}, null);
			yield return null;
		}

		// // RVA: 0x1B68304 Offset: 0x1B68304 VA: 0x1B68304
		public void OnAchieveOKButton(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label)
		{
			ShowCommonAchieveWindow();
		}

		// // RVA: 0x1B681C8 Offset: 0x1B681C8 VA: 0x1B681C8
		public void ShowCommonAchieveWindow()
		{
			CostumeUpgradeUtility.ShowCommonAchieveWindow(() =>
			{
				//0x1B68950
				CostumeUpgradeUtility.ShowReleaseDailyOperationWindow(m_prev_offer_difficult, () =>
				{
					//0x1B68954
					m_is_wait_open_window = false;
				});
			});
		}

		// // RVA: 0x1B68308 Offset: 0x1B68308 VA: 0x1B68308
		// public void ShowReleaseDailyOperationWindow() { }

		// // RVA: 0x1B683A0 Offset: 0x1B683A0 VA: 0x1B683A0
		public void OpenEnd()
		{
			m_pop_window.SetInput(false, false);
			if(m_addPoint > 0)
			{
				SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_SETTING_005);
			}
			this.StartCoroutineWatched(UpdateCoroutine());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CDA4C Offset: 0x6CDA4C VA: 0x6CDA4C
		// // RVA: 0x1B68448 Offset: 0x1B68448 VA: 0x1B68448
		private IEnumerator UpdateCoroutine()
		{
			GameManager.PushBackButtonHandler doNothing;

			//0x1B691D0
			bool isComp = false;
			doNothing = () =>
			{
				//0x1B689DC
				return;
			};
			GameManager.Instance.AddPushBackButtonHandler(doNothing);
			yield return this.StartCoroutineWatched(UpdateGaugeCoroutine((bool x) =>
			{
				//0x1B689E8
				isComp = x;
			}));
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			if(isComp)
				m_pop_window.Close();
			m_pop_window.SetInput(true, true);
			//yield return new WaitForSeconds(0.1f); // Fix UMO when skip by click on top of OK button
			m_pop_window.SetInputCostumeSelect(true);
			GameManager.Instance.RemovePushBackButtonHandler(doNothing);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CDAC4 Offset: 0x6CDAC4 VA: 0x6CDAC4
		// // RVA: 0x1B684F4 Offset: 0x1B684F4 VA: 0x1B684F4
		private IEnumerator UpdateGaugeCoroutine(Action<bool> callBack)
		{
			float time; // 0x18
			bool isSkip; // 0x1C
			bool isStop; // 0x1D
			bool isComp; // 0x1E
			float dt; // 0x20

			//0x16274BC
			time = 0;
			isSkip = false;
			isStop = false;
			isComp = false;
			dt = 0;
			while(!isStop)
			{
				dt = TimeWrapper.deltaTime;
				if(!InputManager.Instance.GetCurrentTouchInfo(0).isIllegal)
				{
					isSkip = true;
					dt = 1.0f / Application.targetFrameRate;
				}
				do
				{
					time += dt;
					int end = m_currentPoint + m_addPoint;
					int f = (int)Mathf.Lerp(m_currentPoint, end, time);
					if(end <= f)
					{
						m_addPoint = m_addPoint - end + m_currentPoint;
						time = 0;
						isStop = m_addPoint == 0;
						f = end;
					}
					SetGauge(f);
					if(m_next_rank_point <= f)
					{
						SoundManager.Instance.sePlayerMenu.Stop();
						SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_BINGO_000);
						FadeoutEffectAnimation();
						yield return this.StartCoroutineWatched(RankUpAnimation());
						LFAFJCNKLML.FHLDDEKAJKI d = m_data.OCOOHBINGBG_LevelInfo[m_rank];
						if(!IsUnlockSceneItem(d))
						{
							yield return this.StartCoroutineWatched(ShowAchivementPopupCoroutine(m_data));
							int prevPoint = m_currentPoint;
							m_currentPoint = 0;
							m_rank++;
							m_addPoint = m_addPoint + prevPoint - m_next_rank_point;
							if(m_rank < m_data.LLLCMHENKKN_LevelMax)
							{
								SetGauge(m_currentPoint);
							}
							UpdateRewardIcon();
							SettingNextRewardPoint();
							SettingRankMaxLayout(m_next_rank_point);
							if(m_addPoint > 0)
							{
								if(!isSkip)
								{
									if(m_data.LLLCMHENKKN_LevelMax <= m_rank)
									{
										SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_SETTING_005);
									}
								}
							}
						}
						else
						{
							ItemType = LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.CFOEMAAKOMC_4_CostumeColor;
							CostumeId = m_data.JPIDIENBGKH_CostumeId;
							CostumeColorId = 1;
							isStop = true;
							isComp = true;
							break;
						}
					}
				} while(isSkip && !isStop);
				yield return null;
			}
			SoundManager.Instance.sePlayerMenu.Stop();
			FadeoutEffectAnimation();
			if(callBack != null)
				callBack(isComp);
		}

		// // RVA: 0x1B68598 Offset: 0x1B68598 VA: 0x1B68598
		private bool IsUnlockSceneItem(LFAFJCNKLML.FHLDDEKAJKI upgrade)
		{
			return upgrade.PEEAGFNOFFO_UnlockType == LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.CFOEMAAKOMC_4_CostumeColor;
		}

		// // RVA: 0x1B685C8 Offset: 0x1B685C8 VA: 0x1B685C8
		// public void StartCompInAnim() { }

		// // RVA: 0x1B68654 Offset: 0x1B68654 VA: 0x1B68654
		// public void WaitComp() { }

		// // RVA: 0x1B686D4 Offset: 0x1B686D4 VA: 0x1B686D4
		// public void StartFrameAnim() { }

		// // RVA: 0x1B68760 Offset: 0x1B68760 VA: 0x1B68760
		// public void LoopFrameAnim() { }

		// // RVA: 0x1B687EC Offset: 0x1B687EC VA: 0x1B687EC
		// public void WaitFrameAnim() { }

		// // RVA: 0x1B67768 Offset: 0x1B67768 VA: 0x1B67768
		private void SetGauge(int point)
		{
			int v = (int)(Mathf.Clamp01(point * 1.0f / m_next_rank_point) * 103.0f);
			m_gauge.bar.StartChildrenAnimGoStop(v, v);
			int next = m_next_rank_point - point;
			if(next <= 0)
				next = 0;
			SettingRankMaxLayout(next);
		}

		// // RVA: 0x1B67868 Offset: 0x1B67868 VA: 0x1B67868
		private void StartEffectAnimation()
		{
			m_effect.alpha.StartChildrenAnimGoStop("st_wait", "st_wait");
			m_effect.root.StartAllAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x1B687F0 Offset: 0x1B687F0 VA: 0x1B687F0
		private void FadeoutEffectAnimation()
		{
			return;
		}

		// // RVA: 0x1B67498 Offset: 0x1B67498 VA: 0x1B67498
		private void SettingRankMaxLayout(int next = -1)
		{
			if(m_data.LLLCMHENKKN_LevelMax <= m_rank)
			{
				m_get_icon.StartChildrenAnimGoStop(0, 0);
				m_gauge.max.StartChildrenAnimGoStop(1, 1);
				m_gauge.bar.StartChildrenAnimGoStop(103, 103);
				m_need_point_text.text = "";
			}
			else
			{
				m_get_icon.StartChildrenAnimGoStop(1, 1);
				m_gauge.max.StartChildrenAnimGoStop(0, 0);
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				m_work_sb.SetFormat(bk.GetMessageByLabel("costume_upgrade_next_release_point_text"), next, RichTextUtility.MakeSizeTagString("CP", 22));
				m_need_point_text.text = m_work_sb.ToString();
			}
		}

		// // RVA: 0x1B671FC Offset: 0x1B671FC VA: 0x1B671FC
		private int GetRankToIndex()
		{
			if(m_data.LLLCMHENKKN_LevelMax <= m_rank)
			{
				return m_data.LLLCMHENKKN_LevelMax - 1;
			}
			return m_rank;
		}
	}
}
