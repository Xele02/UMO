using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;
using XeSys;
using mcrs;
using UnityEngine.Localization.SmartFormat;

namespace XeApp.Game.Menu
{
	public class EpisodeReleaseWindow : LayoutUGUIScriptBase
	{
		public class ItemIcon
		{
			public AbsoluteLayout table; // 0x8
			public RawImageEx get_icon; // 0xC
			public RawImageEx image; // 0x10
			public NumberBase num; // 0x14
			public RawImageEx image2; // 0x18
			public NumberBase num2; // 0x1C
			public Transform end_pos; // 0x20
			public AbsoluteLayout line_abs; // 0x24
			public Transform start_pos; // 0x28
			public Transform start_pos2; // 0x2C
			public GameObject line1; // 0x30
			public GameObject line2; // 0x34
			public bool is_next; // 0x38
		}

		public class GaugeLayout
		{
			public AbsoluteLayout under; // 0x8
			public AbsoluteLayout up; // 0xC
			public AbsoluteLayout on; // 0x10
			public AbsoluteLayout over; // 0x14
		}

		private Action mUpdater; // 0x14
		[SerializeField]
		private ActionButton m_plas; // 0x18
		[SerializeField]
		private ActionButton m_minus; // 0x1C
		[SerializeField]
		private ActionButton m_plas_ten; // 0x20
		[SerializeField]
		private ActionButton m_minus_ten; // 0x24
		private int m_item_use_num; // 0x28
		private int m_have_item = 100; // 0x2C
		private int m_use_item_min; // 0x30
		private int m_use_item_max; // 0x34
		private const int ITEM_MAX = 6;
		private int rewardItemNum = 5; // 0x38
		private AbsoluteLayout m_next_gauge; // 0x3C
		private AbsoluteLayout m_item_list_changeNum; // 0x40
		private AbsoluteLayout m_gauge_table; // 0x44
		private GaugeLayout m_unlock_gauge = new GaugeLayout(); // 0x48
		private GaugeLayout m_lock_gauge = new GaugeLayout(); // 0x4C
		[SerializeField]
		private NumberBase m_point_den; // 0x50
		[SerializeField]
		private NumberBase m_point_mol; // 0x54
		[SerializeField]
		private NumberBase m_point_item_num; // 0x58
		[SerializeField]
		private Text m_episode_item; // 0x5C
		[SerializeField]
		private Text m_item_value; // 0x60
		[SerializeField]
		private Text m_caution; // 0x64
		[SerializeField]
		private Text m_episode_item_num; // 0x68
		[SerializeField]
		private Text m_item_name; // 0x6C
		[SerializeField]
		private List<ItemIcon> m_item_icon_list = new List<ItemIcon>(); // 0x70
		[SerializeField]
		private RawImageEx m_episode_item_image; // 0x74
		[SerializeField]
		private RawImageEx m_item_image; // 0x78
		[SerializeField]
		private PopupEpisodeRelease m_pop_window; // 0x7C
		private PIGBBNDPPJC m_data; // 0x80
		private EEDBNJAEKBI item_data; // 0x84
		private List<LGMEPLIJLNB> m_reward_list; // 0x88
		private const int EPISODE_ITEM_NUMBER = 80000;
		private const int LINE_Y_ADJUST = -10;
		private const int LINE_X_ADJUST = -2;
		private int m_item_use_type; // 0x8C
		private int m_next_point; // 0x90
		private bool m_is_line_update; // 0x94
		private RectTransform m_root; // 0x98

		// RVA: 0xEF9588 Offset: 0xEF9588 VA: 0xEF9588 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_next_gauge = layout.FindViewById("sw_sel_ep_progress_02_anim") as AbsoluteLayout;
			m_gauge_table = layout.FindViewByExId("swtbl_sel_ep_bar_sw_bar_after_anim") as AbsoluteLayout;
			m_lock_gauge.under = layout.FindViewByExId("sw_bar_before_anim_sel_ep_bar_under") as AbsoluteLayout;
			m_lock_gauge.up = layout.FindViewByExId("sw_bar_before_anim_sel_ep_bar_up") as AbsoluteLayout;
			m_lock_gauge.on = layout.FindViewByExId("sw_bar_before_anim_sel_ep_bar_on") as AbsoluteLayout;
			m_lock_gauge.over = layout.FindViewByExId("sw_bar_before_anim_sel_ep_bar_up_02") as AbsoluteLayout;
			m_unlock_gauge.under = layout.FindViewByExId("sw_bar_after_anim_sel_ep_bar_up_02") as AbsoluteLayout;
			m_unlock_gauge.up = layout.FindViewByExId("sw_bar_after_anim_sel_ep_bar_up") as AbsoluteLayout;
			m_unlock_gauge.on = layout.FindViewByExId("sw_bar_after_anim_sel_ep_bar_on_02") as AbsoluteLayout;
			m_unlock_gauge.over = layout.FindViewByExId("sw_bar_after_anim_sel_ep_bar_up_02") as AbsoluteLayout;
			m_item_list_changeNum = layout.FindViewByExId("sw_sel_ep_item_pop_swtbl_item_lane") as AbsoluteLayout;
			StringBuilder str = new StringBuilder();
			Transform t1 = transform.Find("sw_sel_ep_item_pop_all (AbsoluteLayout)/sw_sel_ep_item_pop (AbsoluteLayout)/swtbl_item_lane (AbsoluteLayout)");
			for(int i = 1; i < 7; i++)
			{
				str.Clear();
				str.AppendFormat("swtbl_scaling_frm_{0:D2} (AbsoluteLayout)", i);
				Transform t2 = t1.Find(str.ToString());
				ItemIcon image = new ItemIcon();
				image.image = t2.Find("sw_icon_scaling_01 (AbsoluteLayout)/cnm_ep_item_icon_01 (AbsoluteLayout)/swtexc_cmn_item (ImageView)").GetComponent<RawImageEx>();
				image.num = t2.Find("sw_icon_scaling_01 (AbsoluteLayout)/swnum_item_num01 (AbsoluteLayout)").GetComponent<NumberBase>();
				image.start_pos = t2.Find("sw_icon_scaling_01 (AbsoluteLayout)/item_arrival_pos (AbsoluteLayout)").GetComponent<Transform>();
				image.image2 = t2.Find("sw_icon_scaling_02 (AbsoluteLayout)/cnm_ep_item_icon_02 (AbsoluteLayout)/swtexc_cmn_item (ImageView)").GetComponent<RawImageEx>();
				image.num2 = t2.Find("sw_icon_scaling_02 (AbsoluteLayout)/swnum_item_num01 (AbsoluteLayout)").GetComponent<NumberBase>();
				image.start_pos2 = t2.Find("sw_icon_scaling_02 (AbsoluteLayout)/item_arrival_pos (AbsoluteLayout)").GetComponent<Transform>();
				str.Clear();
				str.AppendFormat("swtbl_get_icon_{0:D2} (AbsoluteLayout)", i);
				t2 = t1.Find(str.ToString());
				image.get_icon = t2.Find("sel_ep_clear_icon (AbsoluteLayout)").GetComponentInChildren<RawImageEx>();
				str.Clear();
				str.Clear();
				str.AppendFormat("swtbl_item_lane_swtbl_scaling_frm_{0:D2}", i);
				image.table = layout.FindViewByExId(str.ToString()) as AbsoluteLayout;
				image.table = image.table.FindViewByExId("swtbl_scaling_frm_sw_icon_scaling_01") as AbsoluteLayout;
				str.Clear();
				str.AppendFormat("sw_sel_ep_progress_02_anim_sel_ep_arrival_line_{0:D2}", i);
				image.line_abs = layout.FindViewByExId(str.ToString()) as AbsoluteLayout;
				GameObject g = new GameObject();
				image.line1 = Instantiate(g);
				image.line1.AddComponent<RawImageEx>();
				image.line1.transform.SetParent(image.start_pos, false);
				image.line2 = Instantiate(g);
				image.line2.AddComponent<RawImageEx>();
				image.line2.transform.SetParent(image.start_pos2, false);
				DestroyImmediate(g);
				str.Clear();
				str.AppendFormat("sw_sel_ep_progress_02_anim (AbsoluteLayout)", Array.Empty<object>());
				t2 = t1.Find(str.ToString());
				Transform[] ts = t2.GetComponentsInChildren<Transform>(true);
				str.Clear();
				str.AppendFormat("sel_ep_arrival_line_{0:D2} (AbsoluteLayout)", i);
				image.end_pos = ts.Where((Transform _) =>
				{
					//0xEFCD10
					return _.name == str.ToString();
				}).First();
				m_item_icon_list.Add(image);
			}
			m_plas.AddOnClickCallback(() =>
			{
				//0xEFCD7C
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				if (m_have_item <= m_item_use_num)
					return;
				if (m_use_item_max <= m_item_use_num)
					return;
				m_item_use_num++;
				UpdateItemValue();
				UpdateLine();
			});
			m_minus.AddOnClickCallback(() =>
			{
				//0xEFCEBC
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				if (m_item_use_num <= m_use_item_min)
					return;
				m_item_use_num--;
				UpdateItemValue();
				UpdateLine();
			});
			m_plas_ten.AddOnClickCallback(() =>
			{
				//0xEFCFC4
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				m_item_use_num += 10;
				if (m_have_item < m_item_use_num)
					m_item_use_num = m_have_item;
				if (m_use_item_max < m_item_use_num)
					m_item_use_num = m_use_item_max;
				UpdateItemValue();
				UpdateLine();
			});
			m_minus_ten.AddOnClickCallback(() =>
			{
				//0xEFD160
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				m_item_use_num -= 10;
				if (m_item_use_num < m_use_item_min)
					m_item_use_num = m_use_item_min;
				UpdateItemValue();
				UpdateLine();
			});
			mUpdater = UpdateLoad;
			return true;
		}

		// RVA: 0xEFAABC Offset: 0xEFAABC VA: 0xEFAABC
		private void Start()
		{
			return;
		}

		// RVA: 0xEFAAC0 Offset: 0xEFAAC0 VA: 0xEFAAC0
		private void Update()
		{
			if (mUpdater != null)
				mUpdater();
		}

		//// RVA: 0xEFAAD4 Offset: 0xEFAAD4 VA: 0xEFAAD4
		private void UpdateLoad()
		{
			if(m_point_den.IsLoaded() && m_point_mol.IsLoaded() && m_point_item_num.IsLoaded())
			{
				Loaded();
				mUpdater = UpdateIdle;
			}
		}

		//// RVA: 0xEFABE0 Offset: 0xEFABE0 VA: 0xEFABE0
		private void UpdateIdle()
		{
			return;
		}

		//// RVA: 0xEFABE4 Offset: 0xEFABE4 VA: 0xEFABE4
		private void UpdateItemValue()
		{
			m_item_value.text = m_item_use_num.ToString() + " / " + m_have_item.ToString();
			m_episode_item_num.text = m_item_use_num.ToString();
			RewardIndex();
			int a = item_data.IILKAJBHLMJ_Value * m_item_use_num + m_data.ABLHIAEDJAI_CurrentPoint;
			if(!m_data.CCBKMCLDGAD_HasReward)
			{
				SetGauge((int)(m_data.ABLHIAEDJAI_CurrentPoint * 100.0f / m_data.DMHDNKILKGI_MaxPoint), (int)(a * 100.0f / m_data.DMHDNKILKGI_MaxPoint));
				m_point_den.SetNumber(a, 0);
				m_point_mol.SetNumber(m_data.DMHDNKILKGI_MaxPoint, 0);
			}
			else
			{
				SetGauge((int)((m_data.ABLHIAEDJAI_CurrentPoint - m_data.DMHDNKILKGI_MaxPoint) * 100.0f / (m_reward_list[m_reward_list.Count - 1].DNBFMLBNAEE_TotalPoint - m_reward_list[m_reward_list.Count - 1].CCDPNBJMKDI_StartPoint)),
						(int)((a - m_data.DMHDNKILKGI_MaxPoint) * 100.0f / (m_reward_list[m_reward_list.Count - 1].DNBFMLBNAEE_TotalPoint - m_reward_list[m_reward_list.Count - 1].CCDPNBJMKDI_StartPoint)));
				m_point_den.SetNumber(a - m_data.DMHDNKILKGI_MaxPoint, 0);
				m_point_mol.SetNumber(m_reward_list[m_reward_list.Count - 1].DNBFMLBNAEE_TotalPoint - m_reward_list[m_reward_list.Count - 1].CCDPNBJMKDI_StartPoint);
			}
			int a2 = Mathf.Min(m_have_item, m_use_item_max);
			if(m_item_use_num == a2)
			{
				m_plas.Disable = true;
				m_plas_ten.Disable = true;
			}
			else
			{
				m_plas.Disable = false;
				m_plas_ten.Disable = false;
			}
			if(m_item_use_num == m_use_item_min)
			{
				m_minus.Disable = true;
				m_minus_ten.Disable = true;
			}
			else
			{
				m_minus.Disable = false;
				m_minus_ten.Disable = false;
			}
			m_pop_window.SetDisable(m_item_use_num == 0);
		}

		//// RVA: 0xEFB1DC Offset: 0xEFB1DC VA: 0xEFB1DC
		private int RewardIndex()
		{
			for(int i = 0; i < m_reward_list.Count - 1; i++)
			{
				if (item_data.IILKAJBHLMJ_Value * m_item_use_num + m_data.ABLHIAEDJAI_CurrentPoint < m_reward_list[i].DNBFMLBNAEE_TotalPoint)
					return i;
			}
			return m_reward_list.Count - 1;
		}

		//// RVA: 0xEFB568 Offset: 0xEFB568 VA: 0xEFB568
		private int GetAcquiredRewardIndex()
		{
			for(int i = 0; i < m_reward_list.Count - 1; i++)
			{
				if (m_data.ABLHIAEDJAI_CurrentPoint < m_reward_list[i].DNBFMLBNAEE_TotalPoint)
					return i;
			}
			return m_reward_list.Count - 1;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DAF2C Offset: 0x6DAF2C VA: 0x6DAF2C
		//// RVA: 0xEF9284 Offset: 0xEF9284 VA: 0xEF9284
		public IEnumerator CO_Init(PIGBBNDPPJC data, int item_type)
		{
			int i;

			//0xEFD5C4
			gameObject.SetActive(true);
			transform.localPosition = new Vector3(1000, 1000, 0);
			yield return null;
			Init(data, item_type);
			yield return null;
			GetRoot();
			UpdateLine();
			if(!m_is_line_update)
			{
				for(i = 0; i < rewardItemNum; i++)
				{
					while (!m_item_icon_list[i].image.enabled)
						yield return null;
				}
			}
			while(!m_item_image.enabled)
				yield return null;
			while (!m_episode_item_image.enabled)
				yield return null;
			yield return null;
			gameObject.SetActive(false);
			transform.localPosition = Vector3.zero;
		}

		//// RVA: 0xEFB6A8 Offset: 0xEFB6A8 VA: 0xEFB6A8
		public void Init(PIGBBNDPPJC data, int item_type)
		{
			m_data = data;
			item_data = EEDBNJAEKBI.FKDIMODKKJD()[item_type];
			m_item_use_type = item_type;
			m_reward_list = LGMEPLIJLNB.FKDIMODKKJD_GetEpisodeRewards(data.KELFCMEOPPM_EpId);
			m_have_item = item_data.HMFFHLPNMPH_Count;
			if (!m_data.CCBKMCLDGAD_HasReward)
			{
				m_use_item_max = m_data.DMHDNKILKGI_MaxPoint / item_data.IILKAJBHLMJ_Value;
			}
			else
			{
				m_use_item_max = (m_reward_list[m_reward_list.Count - 1].DNBFMLBNAEE_TotalPoint - m_reward_list[m_reward_list.Count - 1].CCDPNBJMKDI_StartPoint) / item_data.IILKAJBHLMJ_Value;
			}
			m_caution.text = JpStringLiterals.StringLiteral_15830 + m_use_item_max.ToString() + Smart.Format(JpStringLiterals.StringLiteral_15831, m_use_item_max);
			m_episode_item.text = item_data.OPFGFINHFCE_Name;
			m_item_use_num = 0;
			UpdateItemValue();
			rewardItemNum = m_reward_list.Count - 1;
			m_item_list_changeNum.StartChildrenAnimGoStop(rewardItemNum < 6 ? "01" : "02");
			for(int i = 0; i < rewardItemNum; i++)
			{
				int index = i;
				m_item_icon_list[i].num.SetNumber(m_reward_list[i].GOOIIPFHOIG.MBJIFDBEDAC_Cnt, 0);
				m_item_icon_list[i].num2.SetNumber(m_reward_list[i].GOOIIPFHOIG.MBJIFDBEDAC_Cnt, 0);
				m_item_icon_list[i].get_icon.enabled = m_reward_list[i].HMEOAKCLKJE_IsReceived;
				m_item_icon_list[i].image.enabled = false;
				m_item_icon_list[i].image2.enabled = false;
				MenuScene.Instance.ItemTextureCache.Load(m_reward_list[i].GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId, (IiconTexture icon) =>
				{
					//0xEFD298
					icon.Set(m_item_icon_list[index].image);
					icon.Set(m_item_icon_list[index].image2);
					m_item_icon_list[index].image.enabled = true;
					m_item_icon_list[index].image2.enabled = true;
				});
			}
			m_item_name.text = JpStringLiterals.StringLiteral_15778;
			SetItemImage(m_reward_list[m_reward_list.Count - 1].GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId);
			m_point_item_num.SetNumber(m_reward_list[m_reward_list.Count - 1].GOOIIPFHOIG.MBJIFDBEDAC_Cnt, 0);
			m_next_point = data.JBFLCHFEIGL.OJELCGDDAOM_MissingPoint;
			SetEpiItemImage(item_type + 80001);
		}

		//// RVA: 0xEFC460 Offset: 0xEFC460 VA: 0xEFC460
		public void Enter()
		{
			m_plas.IsInputOff = false;
			m_minus.IsInputOff = false;
		}

		//// RVA: 0xEFC4B8 Offset: 0xEFC4B8 VA: 0xEFC4B8
		public void OpenEnd()
		{
			GetRoot();
			m_pop_window.SetDisable(m_item_use_num == 0);
		}

		//// RVA: 0xEFC62C Offset: 0xEFC62C VA: 0xEFC62C
		private void UpdateLine()
		{
			if(!m_data.CCBKMCLDGAD_HasReward)
			{
				int idx = RewardIndex();
				int idx2 = GetAcquiredRewardIndex();
				for(int i = 0; i < rewardItemNum; i++)
				{
					this.StartCoroutineWatched(SetItemGaugeLine(i, idx == i, i < idx2, i + 1 == rewardItemNum && rewardItemNum < 6));
				}
			}
			else
			{
				for(int i = 0; i < rewardItemNum; i++)
				{
					m_item_icon_list[i].table.StartSiblingAnimGoStop(0, 0);
					m_item_icon_list[i].line_abs.StartAllAnimGoStop(0, 0);
					m_item_icon_list[i].line1.SetActive(false);
					m_item_icon_list[i].line2.SetActive(false);
				}
			}
		}

		//// RVA: 0xEFC1F8 Offset: 0xEFC1F8 VA: 0xEFC1F8
		private void SetItemImage(int index)
		{
			m_item_image.enabled = false;
			MenuScene.Instance.ItemTextureCache.Load(index, (IiconTexture icon) =>
			{
				//0xEFCB08
				icon.Set(m_item_image);
				m_item_image.enabled = true;
			});
		}

		//// RVA: 0xEFC32C Offset: 0xEFC32C VA: 0xEFC32C
		private void SetEpiItemImage(int index)
		{
			m_episode_item_image.enabled = false;
			MenuScene.Instance.ItemTextureCache.Load(index, (IiconTexture icon) =>
			{
				//0xEFCC0C
				icon.Set(m_episode_item_image);
				m_episode_item_image.enabled = true;
			});
		}

		//// RVA: 0xEFB31C Offset: 0xEFB31C VA: 0xEFB31C
		private void SetGauge(int gauge, int up)
		{
			int start0 = (int)(up * 1.01f);
			int start1 = (int)(gauge * 1.01f);
			int start = start0 - 101;
			if (start0 > 100)
				start0 = 101;
			if (start < 1)
				start = 0;
			if(!m_data.CCBKMCLDGAD_HasReward)
			{
				m_gauge_table.StartSiblingAnimGoStop(1, 1);
				m_next_gauge.StartChildrenAnimGoStop(start1, start1);
				if (start1 == 0)
					start1 = 1;
				m_lock_gauge.on.StartAllAnimGoStop(start1, start1);
				m_lock_gauge.up.StartAllAnimGoStop(start0, start0);
				m_lock_gauge.over.StartAllAnimGoStop(start, start);
			}
			else
			{
				m_gauge_table.StartSiblingAnimGoStop(0, 0);
				m_next_gauge.StartChildrenAnimGoStop(start1, start1);
				m_unlock_gauge.on.StartAllAnimGoStop(start1, start1);
				m_unlock_gauge.up.StartAllAnimGoStop(start0, start0);
				m_unlock_gauge.over.StartAllAnimGoStop(start, start);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DAFA4 Offset: 0x6DAFA4 VA: 0x6DAFA4
		//// RVA: 0xEFC918 Offset: 0xEFC918 VA: 0xEFC918
		private IEnumerator SetItemGaugeLine(int index, bool is_next, bool isAcquired, bool is_line_skip)
		{
			int _index;

			//0xEFDAA8
			m_is_line_update = true;
			_index = index;
			if(is_line_skip)
			{
				if(_index + 1 < m_item_icon_list.Count())
				{
					_index++;
				}
			}
			int a = (int)(m_reward_list[index].DNBFMLBNAEE_TotalPoint * 100.0f / m_data.DMHDNKILKGI_MaxPoint);
			if (isAcquired)
				a = 0;
			m_item_icon_list[_index].line_abs.StartAllAnimGoStop(a, a);
			m_item_icon_list[index].table.StartSiblingAnimGoStop(is_next ? 1 : 0, is_next ? 1 : 0);
			yield return null;
			Camera c = GameManager.Instance.transform.Find("SystemCanvasCamera").GetComponent<Camera>();
			Vector3 p;
			GameObject g;
			if(!is_next)
			{
				g = m_item_icon_list[index].line1;
				m_item_icon_list[index].line1.GetComponent<RawImageEx>().color = new Color(0.1607843f, 0.7176471f, 0.9215686f, 1);
				m_item_icon_list[index].line1.SetActive(!isAcquired);
				p = RectTransformUtility.WorldToScreenPoint(c, m_item_icon_list[index].start_pos.transform.position);
			}
			else
			{
				g = m_item_icon_list[index].line2;
				m_item_icon_list[index].line2.GetComponent<RawImageEx>().color = new Color(0.9921569f, 0.2666667f, 1.0f, 1);
				m_item_icon_list[index].line2.SetActive(!isAcquired);
				p = RectTransformUtility.WorldToScreenPoint(c, m_item_icon_list[index].start_pos2.transform.position);
			}
			Vector3 p2 = c.WorldToScreenPoint(m_item_icon_list[_index].end_pos.GetChild(0).position);
			Vector2 r, r2;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(m_root, p, c, out r2);
			RectTransformUtility.ScreenPointToLocalPointInRectangle(m_root, p2, c, out r);
			g.transform.transform.SetLocalEulerAngleZ(57.29578f * Mathf.Atan2(r.y - 10 - r2.y, r.x - 2 - r2.x));
			g.transform.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
			g.transform.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
			g.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(Vector3.Distance(r + new Vector2(-2, -10), r2), 5);
			m_is_line_update = true;
		}

		//// RVA: 0xEF82F4 Offset: 0xEF82F4 VA: 0xEF82F4
		public int GetItemUseCount()
		{
			return m_item_use_num;
		}

		//// RVA: 0xEF82FC Offset: 0xEF82FC VA: 0xEF82FC
		public int GetItemUseType()
		{
			return m_item_use_type;
		}

		//// RVA: 0xEF8304 Offset: 0xEF8304 VA: 0xEF8304
		public int GetAddEpisodePoint()
		{
			return item_data.IILKAJBHLMJ_Value * m_item_use_num;
		}

		//// RVA: 0xEFC4FC Offset: 0xEFC4FC VA: 0xEFC4FC
		private void GetRoot()
		{
			Transform t = transform;
			while(t != null)
			{
				if (t.GetComponent<Canvas>() != null)
					m_root = t.GetComponent<RectTransform>();
				t = t.parent;
			}
		}
	}
}
