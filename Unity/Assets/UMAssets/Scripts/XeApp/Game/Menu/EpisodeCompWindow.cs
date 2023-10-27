using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;
using XeSys;
using XeApp.Game.Common.uGUI;
using mcrs;
using System.Collections;
using System;

namespace XeApp.Game.Menu
{
	public class EpisodeCompWindow : LayoutUGUIScriptBase
	{
		public delegate void EndCallback();
		public delegate void ItemCallback();

		private AbsoluteLayout m_comp_anim; // 0x14
		private AbsoluteLayout m_next_gauge; // 0x18
		private AbsoluteLayout m_frame_anim; // 0x1C
		private AbsoluteLayout m_mask_image; // 0x20
		private AbsoluteLayout m_next_abs; // 0x24
		private AbsoluteLayout m_line_abs; // 0x28
		private AbsoluteLayout m_gauge_table; // 0x2C
		private AbsoluteLayout m_bar_anim; // 0x30
		private AbsoluteLayout m_available_episodepoint; // 0x34
		private PIGBBNDPPJC m_episodeData; // 0x38
		private RectTransform m_line; // 0x3C
		private float m_point; // 0x40
		private float m_after_point; // 0x44
		private float m_add_value; // 0x48
		private float m_old_value; // 0x4C
		private float m_add_episode_point; // 0x50
		private bool m_is_next; // 0x54
		private List<LGMEPLIJLNB> m_reward_list; // 0x58
		private const float ADD_GAUGE_FRAME = 60;
		private const int LINE_Y_ADJUST = 4;
		private const int LINE_X_ADJUST = -10;
		private bool m_is_comp; // 0x5C
		private const int MaskFrameMax = 107;
		private Rect m_image_uv; // 0x60
		private PopupEpisodeComp m_pop_window; // 0x70
		private int m_reward_index; // 0x74
		private int m_gauge_max_point; // 0x78
		private bool m_is_line_update; // 0x7C
		private StringBuilder m_work_sb = new StringBuilder(32); // 0x80
		private bool m_is_wait_open_window; // 0x84
		private RectTransform m_root; // 0x88
		private Canvas rootCanvas; // 0x8C
		private RectTransform canvasRectTransform; // 0x90
		private const float GaugeAnimationTime = 1;
		private const int GaugeHeight = 247;
		private const int AvailableEpisodePointMaxFrame = 264;
		private bool is_restart; // 0x94
		private int m_currentPoint; // 0x98
		private int m_addPoint; // 0x9C
		private int m_showReciveItemIndex; // 0xA0
		private List<MFDJIFIIPJD> m_itemList; // 0xA4
		private bool m_dirtyUpdateLine; // 0xB0
		private RectTransform m_lineStartTarget; // 0xB4
		private RectTransform m_lineEndTarget; // 0xB8
		[SerializeField] // RVA: 0x66CC8C Offset: 0x66CC8C VA: 0x66CC8C
		private NumberBase m_point_episode; // 0xBC
		[SerializeField] // RVA: 0x66CC9C Offset: 0x66CC9C VA: 0x66CC9C
		private NumberBase m_point_den; // 0xC0
		[SerializeField] // RVA: 0x66CCAC Offset: 0x66CCAC VA: 0x66CCAC
		private NumberBase m_point_mol; // 0xC4
		[SerializeField] // RVA: 0x66CCBC Offset: 0x66CCBC VA: 0x66CCBC
		private NumberBase m_point_item_num; // 0xC8
		[SerializeField] // RVA: 0x66CCCC Offset: 0x66CCCC VA: 0x66CCCC
		private Text m_episode_info; // 0xCC
		[SerializeField] // RVA: 0x66CCDC Offset: 0x66CCDC VA: 0x66CCDC
		private Text m_next; // 0xD0
		[SerializeField] // RVA: 0x66CCEC Offset: 0x66CCEC VA: 0x66CCEC
		private RawImageEx m_episode_image; // 0xD4
		[SerializeField] // RVA: 0x66CCFC Offset: 0x66CCFC VA: 0x66CCFC
		private RawImageEx m_episode_image2; // 0xD8
		[SerializeField] // RVA: 0x66CD0C Offset: 0x66CD0C VA: 0x66CD0C
		private RawImageEx m_line_image; // 0xDC
		[SerializeField] // RVA: 0x66CD1C Offset: 0x66CD1C VA: 0x66CD1C
		private RawImageEx m_next_image; // 0xE0
		[SerializeField] // RVA: 0x66CD2C Offset: 0x66CD2C VA: 0x66CD2C
		private RawImageEx m_item_image; // 0xE4
		[SerializeField] // RVA: 0x66CD3C Offset: 0x66CD3C VA: 0x66CD3C
		private Transform m_start_point; // 0xE8
		[SerializeField] // RVA: 0x66CD4C Offset: 0x66CD4C VA: 0x66CD4C
		private RectTransform m_end_point; // 0xEC
		private EpisodeAchievPopupSetting m_achiev_window = new EpisodeAchievPopupSetting(); // 0xF0
		private const float GaugeTime = 1;
		protected EndCallback EndEvent = () => 
		{
			//0x12831C0
			return;
		}; // 0xF4
		protected ItemCallback ItemEvent = () =>
		{
			//0x12831C4
			return;
		}; // 0xF8

		public EKLNMHFCAOI.FKGCBLHOOCL_Category ItemType { get; private set; } // 0xA8
		public int ItemId { get; private set; } // 0xAC

		// RVA: 0x127F7A8 Offset: 0x127F7A8 VA: 0x127F7A8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_comp_anim = layout.FindViewByExId("sw_sel_ep_comp_all_sw_sel_ep_comp_anim") as AbsoluteLayout;
			m_next_gauge = layout.FindViewById("sw_sel_ep_progress_anim") as AbsoluteLayout;
			m_frame_anim = layout.FindViewByExId("sw_sel_ep_comp_anim_sw_sel_ep_light_anim") as AbsoluteLayout;
			m_mask_image = layout.FindViewById("sw_cnm_ep_icon_02_anim") as AbsoluteLayout;
			m_bar_anim = layout.FindViewById("sw_sel_ep_mask_eff_anim") as AbsoluteLayout;
			m_bar_anim.StartChildrenAnimGoStop("go_out");
			m_line_abs = layout.FindViewByExId("sw_cnm_ep_icon_02_anim_sel_ep_next_line") as AbsoluteLayout;
			m_next_abs = layout.FindViewByExId("sw_sel_ep_comp_all_sel_ep_next_fnt") as AbsoluteLayout;
			m_gauge_table = layout.FindViewByExId("sw_sel_ep_comp_anim_swtbl_release_switch") as AbsoluteLayout;
			m_pop_window = transform.GetComponent<PopupEpisodeComp>();
			m_image_uv = new Rect(0.1171875f, 0.0f, 0.765625f, 1.0f);
			m_episode_image.uvRect = m_image_uv;
			m_episode_image2.uvRect = m_image_uv;
			GameObject g = new GameObject("lineObject");
			m_line = g.AddComponent<RectTransform>();
			g.transform.SetParent(m_end_point, false);
			m_line.anchoredPosition = Vector2.zero;
			g.AddComponent<RawImage>().color = new Color(0.9921569f, 0.2666667f, 1.0f, 1.0f);
			g = new GameObject("LineStartTarget");
			m_lineStartTarget = g.AddComponent<RectTransform>();
			g.transform.SetParent(m_start_point, false);
			m_lineStartTarget.anchorMax = new Vector2(1, 1);
			m_lineStartTarget.anchorMin = new Vector2(1, 1);
			m_lineStartTarget.sizeDelta = new Vector2(10, 10);
			m_lineStartTarget.anchoredPosition = Vector2.zero;
			g = new GameObject("LineEndTarget");
			m_lineEndTarget = g.AddComponent<RectTransform>();
			m_lineEndTarget.transform.SetParent(m_end_point, false);
			m_lineEndTarget.anchorMax = new Vector2(1, 1);
			m_lineEndTarget.anchorMin = new Vector2(1, 1);
			m_lineEndTarget.pivot = new Vector2(1, 1);
			m_lineEndTarget.sizeDelta = new Vector2(10, 10);
			m_lineEndTarget.anchoredPosition = new Vector2(0, 10);
			RectTransform rt = GetComponentInChildren<Mask>().transform.GetChild(0) as RectTransform;
			rt.pivot = new Vector2(0, 1);
			rt.anchorMin = new Vector2(0, 1);
			rt.anchorMax = new Vector2(0, 1);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_achiev_window.TitleText = bk.GetMessageByLabel("popup_title_episode_04");
			m_achiev_window.SetParent(transform);
			m_achiev_window.WindowSize = SizeType.Middle;
			m_achiev_window.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_available_episodepoint = layout.FindViewByExId("sw_cnm_ep_icon_02_anim_sw_sel_ep_meter_eff_02_anim") as AbsoluteLayout;
			return true;
		}

		//// RVA: 0x1280580 Offset: 0x1280580 VA: 0x1280580
		public void Initialize(PIGBBNDPPJC data, List<MFDJIFIIPJD> itemList, int add_point)
		{
			m_episodeData = data;
			is_restart = false;
			m_itemList = itemList;
			m_point = data.ABLHIAEDJAI_CurrentPoint;
			m_currentPoint = data.ABLHIAEDJAI_CurrentPoint;
			m_addPoint = add_point;
			m_old_value = data.ABLHIAEDJAI_CurrentPoint;
			m_add_episode_point = add_point;
			m_reward_list = LGMEPLIJLNB.FKDIMODKKJD_GetEpisodeRewards(data.KELFCMEOPPM_EpId);
			m_reward_index = EpisodeUtility.GetAcquiredRewardLastIndex(m_reward_list, (int)(m_point));
			m_next.text = data.JBFLCHFEIGL.GOOIIPFHOIG.HAAJGNCFNJM_ItemName;
			m_point_den.SetNumber(data.ABLHIAEDJAI_CurrentPoint, 0);
			m_point_mol.SetNumber(data.DMHDNKILKGI_MaxPoint, 0);
			m_point_item_num.SetNumber(data.JBFLCHFEIGL.GOOIIPFHOIG.MBJIFDBEDAC_Cnt, 0);
			m_episode_info.text = data.OPFGFINHFCE_Name;
			m_point_episode.SetNumber(add_point, 0);
			GameManager.Instance.EpisodeIconCache.Load(m_episodeData.KELFCMEOPPM_EpId, (IiconTexture icon) =>
			{
				//0x1282EF4
				icon.Set(m_episode_image);
				icon.Set(m_episode_image2);
			});
			SetItemImage(m_reward_list[GetAcquiredRewardLastIndex(m_reward_list, m_currentPoint)].GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId);
			WaitComp();
			WaitFrameAnim();
			m_gauge_max_point = m_reward_list[m_reward_list.Count - 1].DNBFMLBNAEE_TotalPoint - m_reward_list[m_reward_list.Count - 1].CCDPNBJMKDI_Idx;
			m_is_comp = false;
			m_after_point = data.ABLHIAEDJAI_CurrentPoint + add_point;
			if (!data.CCBKMCLDGAD_HasReward && data.DMHDNKILKGI_MaxPoint <= m_after_point)
				m_is_comp = true;
			if(!data.CCBKMCLDGAD_HasReward)
			{
				m_gauge_table.StartChildrenAnimGoStop(0, 0);
				m_line_image.enabled = true;
				m_next_image.enabled = true;
				int a = EpisodeUtility.CalcEpisodeGaugeFrame(data.LEGAKDFPPHA_AvaiablePoint, data.DMHDNKILKGI_MaxPoint, 264);
				m_available_episodepoint.StartChildrenAnimGoStop(a, a);
			}
			else
			{
				m_gauge_table.StartChildrenAnimGoStop(1, 1);
				m_line_image.enabled = false;
				m_next_image.enabled = false;
				m_line.gameObject.SetActive(false);
				m_available_episodepoint.StartChildrenAnimGoStop("st_out");
			}
			ItemId = 0;
			ItemType = EKLNMHFCAOI.FKGCBLHOOCL_Category.HJNNKCMLGFL_None;
			m_is_line_update = false;
			m_showReciveItemIndex = 0;
			UpdateEpisodeGauge(m_currentPoint, m_episodeData.CCBKMCLDGAD_HasReward);
			UpdateAddtiveRewardGauge(m_currentPoint);
			UpdateText(m_currentPoint, m_reward_index);
			UpdateNext(m_reward_list[m_reward_index], m_episodeData.DMHDNKILKGI_MaxPoint, data.CCBKMCLDGAD_HasReward);
			m_dirtyUpdateLine = true;
		}

		//// RVA: 0x12814A4 Offset: 0x12814A4 VA: 0x12814A4
		public void InitializeRestart()
		{
			ItemType = 0;
			is_restart = true;
			ItemId = 0;
			m_reward_index = EpisodeUtility.GetAcquiredRewardLastIndex(m_reward_list, m_currentPoint);
			SetItemImage(m_reward_list[m_reward_index].GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId);
			m_point_item_num.SetNumber(m_reward_list[m_reward_index].GOOIIPFHOIG.MBJIFDBEDAC_Cnt, 0);
			UpdateText(m_currentPoint, m_reward_index);
		}

		//// RVA: 0x1281620 Offset: 0x1281620 VA: 0x1281620
		private void DummyBackButton()
		{
			return;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DA764 Offset: 0x6DA764 VA: 0x6DA764
		//// RVA: 0x1281624 Offset: 0x1281624 VA: 0x1281624
		private IEnumerator UpdateContentCoroutine()
		{
			//0x1283900
			bool isComp = false;
			GameManager.Instance.AddPushBackButtonHandler(DummyBackButton);
			yield return this.StartCoroutineWatched(UpdateGaugeCoroutine((bool x) =>
			{
				//0x12831D0
				isComp = x;
			}));
			while (KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			if(isComp)
			{
				m_pop_window.Close();
			}
			m_pop_window.SetInput(true);
			GameManager.Instance.RemovePushBackButtonHandler(DummyBackButton);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DA7DC Offset: 0x6DA7DC VA: 0x6DA7DC
		//// RVA: 0x12816D0 Offset: 0x12816D0 VA: 0x12816D0
		private IEnumerator UpdateGaugeCoroutine(Action<bool> callBack)
		{
			float time; // 0x18
			int loopRewardIndex; // 0x1C
			LGMEPLIJLNB currentReward; // 0x20
			int skipGaugeValue; // 0x24
			bool isSkip; // 0x28
			bool isStop; // 0x29
			bool isComp; // 0x2A
			float dt; // 0x2C
			int currentPoint; // 0x30

			//0x1283D1C
			time = 0;
			loopRewardIndex = m_reward_list.Count - 1;
			currentReward = m_reward_list[m_reward_index];
			isSkip = false;
			isStop = false;
			isComp = false;
			dt = 0;
			skipGaugeValue = m_currentPoint + m_addPoint;

			while (true)
			{
				dt = TimeWrapper.deltaTime;
				if (!InputManager.Instance.GetCurrentTouchInfo(0).isIllegal)
				{
					isSkip = true;
					dt = 1.0f / Application.targetFrameRate;
				}
				do
				{
					time += dt;
					int a = Mathf.Max(currentReward.CCDPNBJMKDI_Idx, m_currentPoint);
					int b = Mathf.Min(currentReward.DNBFMLBNAEE_TotalPoint, m_addPoint + m_currentPoint);
					float f = Mathf.Lerp(a, b, time);
					currentPoint = (int)(f);
					if (currentPoint >= b)
					{
						currentPoint = b;
						m_addPoint = m_addPoint - b + m_currentPoint;
						time = 0;
						isStop = m_addPoint == 0;
					}
					if (loopRewardIndex == m_reward_index)
						UpdateAddtiveRewardGauge(currentPoint);
					else
					{
						int c = currentPoint;
						LGMEPLIJLNB r = currentReward;
						if (isSkip)
						{
							c = skipGaugeValue;
							r = m_reward_list[GetAcquiredRewardLastIndex(m_reward_list, skipGaugeValue)];
						}
						if (m_episodeData.DMHDNKILKGI_MaxPoint < c)
						{
							c = m_episodeData.DMHDNKILKGI_MaxPoint;
						}
						m_point_den.SetNumber(c, 0);
						UpdateEpisodeGauge(c, false);
						UpdateNext(r, m_episodeData.DMHDNKILKGI_MaxPoint, isComp);
					}
					UpdateText(currentPoint, m_reward_index);
					if (currentReward.DNBFMLBNAEE_TotalPoint <= currentPoint)
					{
						if ((currentReward.GOOIIPFHOIG.NPPNDDMPFJJ_ItemCategory < EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume || currentReward.GOOIIPFHOIG.NPPNDDMPFJJ_ItemCategory > EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie) &&
							currentReward.GOOIIPFHOIG.NPPNDDMPFJJ_ItemCategory != EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg)
						{
							SoundManager.Instance.sePlayerMenu.Stop();
							m_showReciveItemIndex++;
							yield return this.StartCoroutineWatched(ShowAchivementPopupCoroutine(m_itemList[m_showReciveItemIndex - 1]));
						}
						else
						{
							ItemType = currentReward.GOOIIPFHOIG.NPPNDDMPFJJ_ItemCategory;
							ItemId = currentReward.GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId;
							m_showReciveItemIndex++;
							isStop = true;
						}
						//LAB_01284468
						if (loopRewardIndex == m_reward_index)
						{
							yield return this.StartCoroutineWatched(PlayAddtiveGaugeMaxEffect());
							UpdateAddtiveRewardGauge(m_reward_list[m_reward_index].CCDPNBJMKDI_Idx);
							UpdateText(m_reward_list[m_reward_index].CCDPNBJMKDI_Idx, m_reward_index);
							//>LAB_01284694
						}
						else
						{
							int aa;
							if (m_reward_index < m_reward_list.Count)
								aa = m_reward_index + 1;
							else
								aa = m_reward_list.Count - 1;
							if (m_episodeData.DMHDNKILKGI_MaxPoint <= currentPoint)
							{
								aa--;
								isComp = true;
							}
							UpdateNext(m_reward_list[aa], m_episodeData.DMHDNKILKGI_MaxPoint, isComp);
							SetItemImage(m_reward_list[aa].GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId);
							m_point_item_num.SetNumber(m_reward_list[aa].GOOIIPFHOIG.MBJIFDBEDAC_Cnt, 0);
							UpdateText(currentPoint, aa);
						}
						//LAB_01284694
						m_reward_index++;
						if (m_reward_list.Count <= m_reward_index)
						{
							m_reward_index = m_reward_list.Count - 1;
						}
						currentReward = m_reward_list[m_reward_index];
						m_currentPoint = currentReward.CCDPNBJMKDI_Idx;
						//LAB_01284750
						while (m_is_wait_open_window)
							yield return null;
						if (m_addPoint > 0 && !isSkip)
						{
							SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_SETTING_005);
						}
					}
				} while (isSkip && !isStop);
				if (!m_episodeData.CCBKMCLDGAD_HasReward && isComp)
				{
					SoundManager.Instance.sePlayerMenu.Stop();
					SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_SETTING_007);
					m_gauge_table.StartChildrenAnimGoStop(1, 1);
					SetGauge(0);
					StartCompInAnim();
					yield return null;
					while (m_comp_anim.IsPlayingChildren())
						yield return null;
					LoopFrameAnim();
				}
				yield return null;
				if (isStop)
				{
					m_episodeData.FBANBDCOEJL();
					SoundManager.Instance.sePlayerMenu.Stop();
					if (is_restart)
					{
						ShowOfferPlatoonReleasePopup();
					}
					if (callBack != null)
						callBack(isComp);
					yield break;
				}
			}
		}

		//// RVA: 0x1281798 Offset: 0x1281798 VA: 0x1281798
		private void ShowOfferPlatoonReleasePopup()
		{
			TodoLogger.LogNotImplemented("ShowOfferPlatoonReleasePopup");
		}

		// RVA: 0x1281AA4 Offset: 0x1281AA4 VA: 0x1281AA4
		private void LateUpdate()
		{
			if (m_dirtyUpdateLine)
				UpdateItemLine();
		}

		//// RVA: 0x12823BC Offset: 0x12823BC VA: 0x12823BC
		//private bool IsUnlockSceneItem(MFDJIFIIPJD itemInfo) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6DA854 Offset: 0x6DA854 VA: 0x6DA854
		//// RVA: 0x12823F8 Offset: 0x12823F8 VA: 0x12823F8
		private IEnumerator ShowAchivementPopupCoroutine(MFDJIFIIPJD item)
		{
			//0x12835D4
			m_achiev_window.data = item;
			m_is_wait_open_window = true;
			bool isWait = true;
			m_achiev_window.openEvent = () =>
			{
				//0x1283338
				isWait = false;
			};
			PopupWindowManager.Show(m_achiev_window, null, null, null, null, true, true, false, null, () =>
			{
				//0x1283344
				m_is_wait_open_window = false;
			}, PlayPopupSe);
			while (isWait)
				yield return null;
		}

		//// RVA: 0x12824C0 Offset: 0x12824C0 VA: 0x12824C0
		private int CalcNextRewardPoint(int currentPoint, int lastRewardIndex)
		{
			return m_reward_list[lastRewardIndex].DNBFMLBNAEE_TotalPoint - currentPoint;
		}

		//// RVA: 0x1280D34 Offset: 0x1280D34 VA: 0x1280D34
		private int GetAcquiredRewardLastIndex(List<LGMEPLIJLNB> list, int point)
		{
			for (int i = 0; i < list.Count - 1; i++)
			{
				if (point < list[i].DNBFMLBNAEE_TotalPoint)
					return i;
			}
			return list.Count - 1;
		}

		//// RVA: 0x12811FC Offset: 0x12811FC VA: 0x12811FC
		private void UpdateText(int currentPoint, int rewardIndex)
		{
			int a = CalcNextRewardPoint(currentPoint, rewardIndex);
			if (a < 1)
				a = 0;
			m_work_sb.SetFormat(JpStringLiterals.StringLiteral_15750, a, RichTextUtility.MakeSizeTagString("EP", 22));
			m_next.text = m_work_sb.ToString();
		}

		//// RVA: 0x1281040 Offset: 0x1281040 VA: 0x1281040
		private void UpdateEpisodeGauge(int currentPoint, bool isAllUnlock)
		{
			if (isAllUnlock)
				currentPoint = m_episodeData.DMHDNKILKGI_MaxPoint;
			int a = EpisodeUtility.CalcEpisodeGaugeFrame(currentPoint, m_episodeData.DMHDNKILKGI_MaxPoint, 239);
			m_mask_image.StartChildrenAnimGoStop(a, a);
		}

		//// RVA: 0x1281360 Offset: 0x1281360 VA: 0x1281360
		private void UpdateNext(LGMEPLIJLNB reward, int max, bool isComp)
		{
			float f = m_line_abs.FrameAnimation.SearchLabelFrame("st_out");
			int start = (int)(f);
			if(!isComp)
			{
				start = EpisodeUtility.CalcEpisodeGaugeFrame(reward.DNBFMLBNAEE_TotalPoint, max, (int)f);
				if (f <= start)
					start = (int)(f - 1);
			}
			m_next_abs.StartAllAnimGoStop(start, start);
			m_line_abs.StartAllAnimGoStop(start, start);
		}

		//// RVA: 0x12810D8 Offset: 0x12810D8 VA: 0x12810D8
		private void UpdateAddtiveRewardGauge(int currentPoint)
		{
			SetGauge((int)(Mathf.Clamp01((currentPoint - m_reward_list[m_reward_index].CCDPNBJMKDI_Idx) * 1.0f / m_reward_list[m_reward_index].CCDPNBJMKDI_Idx) * 100));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DA8CC Offset: 0x6DA8CC VA: 0x6DA8CC
		//// RVA: 0x12825D8 Offset: 0x12825D8 VA: 0x12825D8
		private IEnumerator PlayAddtiveGaugeMaxEffect()
		{
			//0x1283370
			m_next_gauge.StartChildrenAnimGoStop("go_out", "st_out");
			SoundManager.Instance.sePlayerMenu.Stop();
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_SETTING_006);
			yield return null;
			while (m_next_gauge.IsPlayingChildren())
				yield return null;
		}

		//// RVA: 0x1282684 Offset: 0x1282684 VA: 0x1282684
		public void OpenEnd()
		{
			m_pop_window.SetInput(false);
			m_is_line_update = true;
			if(m_addPoint > 0)
			{
				SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_SETTING_005);
			}
			this.StartCoroutineWatched(UpdateContentCoroutine());
		}

		//// RVA: 0x1280E30 Offset: 0x1280E30 VA: 0x1280E30
		private void SetItemImage(int itemId)
		{
			GameManager.Instance.ItemTextureCache.Load(itemId, (IiconTexture icon) =>
			{
				//0x1283064
				icon.Set(m_item_image);
			});
		}

		//// RVA: 0x1281AB4 Offset: 0x1281AB4 VA: 0x1281AB4
		private void UpdateItemLine()
		{
			m_line.gameObject.SetActive(m_lineStartTarget.gameObject.activeInHierarchy);
			if(rootCanvas == null)
			{
				rootCanvas = GetComponentInParent<Canvas>();
				canvasRectTransform = rootCanvas.transform.Find("Root").GetComponent<RectTransform>();
			}
			Vector2 v1 = RectTransformUtility.WorldToScreenPoint(rootCanvas.worldCamera, m_lineEndTarget.transform.position);
			Vector2 v2 = RectTransformUtility.WorldToScreenPoint(rootCanvas.worldCamera, m_lineStartTarget.transform.position);
			float f = Mathf.Atan2(v2.y * m_root.sizeDelta.y / Screen.height - v1.y * m_root.sizeDelta.y / Screen.height,
								v2.x * m_root.sizeDelta.x / Screen.width - v1.x * m_root.sizeDelta.x / Screen.width);
			m_line.pivot = new Vector2(0, 1);
			m_line.anchorMax = new Vector2(1, 1);
			m_line.anchorMin = new Vector2(1, 1);
			m_line.anchoredPosition = new Vector2(0, 0);
			if(f * 57.29578f >= 0)
			{
				m_line.localScale = new Vector3(1, -1, 1);
				m_lineStartTarget.anchoredPosition = new Vector2(0, 0);
			}
			else
			{
				m_line.localScale = new Vector3(1, 1, 1);
				m_lineStartTarget.anchoredPosition = new Vector2(0, -5);
			}
			v1 = RectTransformUtility.WorldToScreenPoint(rootCanvas.worldCamera, m_lineEndTarget.transform.position);
			v2 = RectTransformUtility.WorldToScreenPoint(rootCanvas.worldCamera, m_lineStartTarget.transform.position);
			f = Mathf.Atan2(v2.y - v1.y, v2.x - v1.x);
			RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, v1, rootCanvas.worldCamera, out v1);
			RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, v2, rootCanvas.worldCamera, out v2);
			m_line.transform.SetLocalEulerAngleZ(f * 57.29578f);
			m_line.sizeDelta = new Vector2(Vector3.Distance(v2, v1), 5);
		}

		//// RVA: 0x12828A8 Offset: 0x12828A8 VA: 0x12828A8
		private bool PlayPopupSe(PopupWindowControl.SeType type)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_003);
			return true;
		}

		//// RVA: 0x1282914 Offset: 0x1282914 VA: 0x1282914
		public void StartCompInAnim()
		{
			m_comp_anim.StartChildrenAnimGoStop("go_in", "st_in");
		}

		//// RVA: 0x1280F40 Offset: 0x1280F40 VA: 0x1280F40
		public void WaitComp()
		{
			m_comp_anim.StartChildrenAnimGoStop("st_in", "st_in");
		}

		//// RVA: 0x12829A0 Offset: 0x12829A0 VA: 0x12829A0
		//public void StartFrameAnim() { }

		//// RVA: 0x1282A2C Offset: 0x1282A2C VA: 0x1282A2C
		public void LoopFrameAnim()
		{
			m_frame_anim.StartChildrenAnimLoop("logo_up", "loen_up");
		}

		//// RVA: 0x1280FC0 Offset: 0x1280FC0 VA: 0x1280FC0
		public void WaitFrameAnim()
		{
			m_frame_anim.StartChildrenAnimGoStop("st_wait", "st_wait");
		}

		//// RVA: 0x12825A0 Offset: 0x12825A0 VA: 0x12825A0
		private void SetGauge(int gauge)
		{
			m_next_gauge.StartChildrenAnimGoStop(gauge + 1, gauge + 1);
		}

		//// RVA: 0x1282730 Offset: 0x1282730 VA: 0x1282730
		//private void GetRoot() { }

		//// RVA: 0x1282AB8 Offset: 0x1282AB8 VA: 0x1282AB8
		//public void AddEndCallback(EpisodeCompWindow.EndCallback EndEvent) { }

		//// RVA: 0x1282BA4 Offset: 0x1282BA4 VA: 0x1282BA4
		//public void AddItemCallback(EpisodeCompWindow.ItemCallback ItemEvent) { }
	}
}
