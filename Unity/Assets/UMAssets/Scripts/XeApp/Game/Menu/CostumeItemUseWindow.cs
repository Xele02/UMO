using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using mcrs;
using XeSys;
using System.Text;

namespace XeApp.Game.Menu
{
	public class CostumeItemUseWindow : LayoutUGUIScriptBase
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

		private struct GaugeLayout // TypeDefIndex: 11187
		{
			public AbsoluteLayout eff; // 0x0
			public AbsoluteLayout under; // 0x4
			public AbsoluteLayout on; // 0x8
			public AbsoluteLayout up; // 0xC
		}

		[SerializeField]
		private AnimeCurveScriptableObject m_animeCurve; // 0x14
		public int xor; // 0x18
		private Action mUpdater; // 0x1C
		private ActionButton m_plus; // 0x20
		private ActionButton m_minus; // 0x24
		private ActionButton m_plus_ten; // 0x28
		private ActionButton m_minus_ten; // 0x2C
		private int m_item_use_num_; // 0x30
		private int m_have_item_; // 0x34
		private int m_use_item_min_; // 0x38
		private int m_use_item_max_; // 0x3C
		private const int ITEM_MAX = 5;
		private GaugeLayout m_gauge; // 0x40
		private AbsoluteLayout m_gauge_progress; // 0x50
		private NumberBase m_point_den; // 0x54
		private NumberBase m_point_mol; // 0x58
		private Text m_item_name; // 0x5C
		private Text m_item_value; // 0x60
		private Text m_caution; // 0x64
		private Text m_item_num; // 0x68
		private Text m_have_uc; // 0x6C
		private Text m_necessary_uc; // 0x70
		private Text m_lack_text; // 0x74
		private CostumeUpgradeUtility.RewardIconLayoutSetting m_reward_icon; // 0x78
		private RawImageEx m_use_item_image; // 0x8C
		private AbsoluteLayout m_get_icon; // 0x90
		private LFAFJCNKLML m_data; // 0x94
		private NIHHKCDHLNH item_data; // 0x98
		private List<LFAFJCNKLML.FHLDDEKAJKI> m_reward_list; // 0x9C
		private const int COSTUMEUPGRADE_ITEM_ID_OFFSET = 220000;
		private const int LINE_Y_ADJUST = -10;
		private const int LINE_X_ADJUST = -2;
		private int m_item_use_type; // 0xA0
		private PopupCostumeItemUse m_pop_window; // 0xA4
		private bool m_is_line_update; // 0xA8
		private RectTransform m_root; // 0xAC
		private float m_time; // 0xB0
		private bool m_isLack; // 0xB4
		private Color m_baseColor; // 0xB8
		[SerializeField] // RVA: 0x66B468 Offset: 0x66B468 VA: 0x66B468
		private ActionButton m_ItemButton; // 0xC8

		private int m_item_use_num { get { return xor ^ m_item_use_num_; } set { m_item_use_num_ = value ^ xor; } } //0x1631BB0 0x1631BC0
		private int m_have_item { get { return xor ^ m_have_item_; } set { m_have_item_ = xor ^ value; } } //0x1631BD0 0x1631BE0
		private int m_use_item_min { get { return xor ^ m_use_item_min_; } set { m_use_item_min_ = xor ^ value; } } //0x1631BF0 0x1631C00
		private int m_use_item_max { get { return xor ^ m_use_item_max_; } set { m_use_item_max_ = xor ^ value; } } //0x1631C10 0x1631C20

		// RVA: 0x1631C30 Offset: 0x1631C30 VA: 0x1631C30
		public CostumeItemUseWindow()
		{
			xor = LPDNKHAIOLH.CEIBAFOCNCA();
			m_item_use_num = 0;
			m_have_item = 100;
			m_use_item_min = 0;
			m_use_item_max = 0;
		}

		// RVA: 0x1631CD4 Offset: 0x1631CD4 VA: 0x1631CD4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_gauge_progress = layout.FindViewById("sw_progress_anim") as AbsoluteLayout;
			m_gauge.on = layout.FindViewByExId("sw_bar_anim_bar_on") as AbsoluteLayout;
			m_gauge.up = layout.FindViewByExId("sw_bar_anim_bar_up") as AbsoluteLayout;
			m_gauge.under = layout.FindViewByExId("sw_bar_anim_bar_under") as AbsoluteLayout;
			m_gauge.eff = layout.FindViewByExId("sw_bar_anim_bar_eff") as AbsoluteLayout;
			Transform t = transform.Find("sw_item_pop_alll (AbsoluteLayout)/sw_item_pop (AbsoluteLayout)");
			m_point_den = t.Find("sw_state_num01 (AbsoluteLayout)/swnum_state_num01_l (AbsoluteLayout)").GetComponent<NumberBase>();
			m_point_mol = t.Find("sw_state_num01 (AbsoluteLayout)").GetComponent<NumberBase>();
			m_item_name = t.Find("item_name_01 (TextView)").GetComponent<Text>();
			m_item_value = t.Find("item_number_01 (TextView)").GetComponent<Text>();
			m_caution = t.Find("caution_01 (TextView)").GetComponent<Text>();
			m_item_num = t.Find("item_number_02 (TextView)").GetComponent<Text>();
			m_get_icon = layout.FindViewById("swtbl_get_icon_01") as AbsoluteLayout;
			m_have_uc = t.Find("shoji_uc_text (AbsoluteLayout)/neceuc_01 (TextView)").GetComponent<Text>();
			m_necessary_uc = t.Find("nece_uc_text (AbsoluteLayout)/shojiuc_01 (TextView)").GetComponent<Text>();
			m_baseColor = m_have_uc.color;
			m_lack_text = t.Find("empty_01 (TextView)").GetComponent<Text>();
			m_use_item_image = t.Find("cmn_ep_item_icon_01 (AbsoluteLayout)/swtexc_cmn_item (ImageView)").GetComponent<RawImageEx>();
			Transform t2 = t.Find("sw_cos_item_anim (AbsoluteLayout)/cos_item_01 (AbsoluteLayout)");
			m_reward_icon.item_image = t2.Find("cmn_ep_item_icon_02 (AbsoluteLayout)/swtexc_cmn_item (ImageView)").GetComponent<RawImageEx>();
			m_reward_icon.diva_image = t2.Find("chara_icon_01 (AbsoluteLayout)/swtexc_cmn_chara_icon (ImageView)").GetComponent<RawImageEx>();
			m_reward_icon.item_rank = layout.FindViewById("swtbl_c_b_star_s") as AbsoluteLayout;
			m_reward_icon.get_num = t2.Find("swtbl_item_type (AbsoluteLayout)/swnum_item_num01 (AbsoluteLayout)").GetComponent<NumberBase>();
			m_reward_icon.item_type = layout.FindViewById("swtbl_item_type") as AbsoluteLayout;
			m_plus = t.Find("sw_plus_btn_anim (AbsoluteLayout)").GetComponent<ActionButton>();
			m_minus = t.Find("sw_minus_btn_anim (AbsoluteLayout)").GetComponent<ActionButton>();
			m_plus_ten = t.Find("sw_plus_btn_02_anim (AbsoluteLayout)").GetComponent<ActionButton>();
			m_minus_ten = t.Find("sw_minus_btn_02_anim (AbsoluteLayout)").GetComponent<ActionButton>();
			m_pop_window = transform.GetComponent<PopupCostumeItemUse>();
			m_plus.AddOnClickCallback(() =>
			{
				//0x1634014
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				if(m_have_item <= m_item_use_num)
					return;
				if(m_item_use_num < m_use_item_max)
				{
					m_item_use_num++;
					UpdateItemValue();
				}
			});
			m_minus.AddOnClickCallback(() =>
			{
				//0x16340B4
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				if(m_item_use_num <= m_use_item_min)
					return;
				m_item_use_num--;
				UpdateItemValue();
			});
			m_plus_ten.AddOnClickCallback(() =>
			{
				//0x1634140
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				m_item_use_num = m_item_use_num + 10;
				if(m_item_use_num > m_have_item)
					m_item_use_num = m_have_item;
				if(m_use_item_max < m_item_use_num)
					m_item_use_num = m_use_item_max;
				UpdateItemValue();
			});
			m_minus_ten.AddOnClickCallback(() =>
			{
				//0x16341DC
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				m_item_use_num = m_item_use_num - 10;
				if(m_use_item_min > m_item_use_num)
					m_item_use_num = m_use_item_min;
				UpdateItemValue();
			});
			m_ItemButton.AddOnClickCallback(() =>
			{
				//0x1634264
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				CostumeUpgradeUtility.ShowItemDetailWindow(m_data, m_data.GKIKAABHAAD_Level, transform);
			});
			mUpdater = UpdateLoad;
			return true;
		}

		// RVA: 0x1632A1C Offset: 0x1632A1C VA: 0x1632A1C
		private void Start()
		{
			return;
		}

		// RVA: 0x1632A20 Offset: 0x1632A20 VA: 0x1632A20
		private void Update()
		{
			if(mUpdater != null)
				mUpdater();
		}

		// // RVA: 0x1632A34 Offset: 0x1632A34 VA: 0x1632A34
		private void UpdateLoad()
		{
			if(m_point_den.IsLoaded() && m_point_mol.IsLoaded())
			{
				Loaded();
				mUpdater = UpdateIdle;
			}
		}

		// // RVA: 0x1632B18 Offset: 0x1632B18 VA: 0x1632B18
		private void UpdateIdle()
		{
			return;
		}

		// // RVA: 0x1632B1C Offset: 0x1632B1C VA: 0x1632B1C
		private void UpdateItemValue()
		{
			m_item_value.text = m_item_use_num + " / " + m_have_item;
			m_item_num.text = m_item_use_num.ToString();
			RewardIndex();
			int a1 = item_data.IILKAJBHLMJ_ItemPointValue * m_item_use_num;
			SetGauge((int)(m_data.ABLHIAEDJAI_Point * 1.0f / m_data.JHLKLPEHHCD_GetCurrentLevelInfo().DNBFMLBNAEE_NeedPoint * 100), (int)((m_data.ABLHIAEDJAI_Point + a1) * 1.0f / m_data.JHLKLPEHHCD_GetCurrentLevelInfo().DNBFMLBNAEE_NeedPoint * 100));
			m_point_den.SetNumber(m_data.ABLHIAEDJAI_Point + a1, 0);
			m_point_mol.SetNumber(m_data.JHLKLPEHHCD_GetCurrentLevelInfo().DNBFMLBNAEE_NeedPoint);
			int a2 = Mathf.Min(m_have_item, m_use_item_max);
			if(m_item_use_num == a2)
			{
				m_plus.Disable = true;
				m_plus_ten.Disable = true;
			}
			else
			{
				m_plus.Disable = false;
				m_plus_ten.Disable = false;
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
			m_necessary_uc.text = m_data.KPJJLJLJDIA(a1).ToString();
			m_isLack = MOEALEGLGCH.LLCBDMCPBOD_GetHaveUc() < m_data.KPJJLJLJDIA(a1);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_lack_text.text = "";
			if(m_isLack)
			{
				m_lack_text.text = bk.GetMessageByLabel("growth_popup_text08");
			}
			UpdateUcLack();
			m_pop_window.SetDisable(m_item_use_num == 0 || m_isLack);
		}

		// // RVA: 0x16330C4 Offset: 0x16330C4 VA: 0x16330C4
		private int RewardIndex()
		{
			for(int i = 0; i < m_reward_list.Count - 1; i++)
			{
				if(item_data.IILKAJBHLMJ_ItemPointValue * m_item_use_num + m_data.ABLHIAEDJAI_Point < m_reward_list[i].DNBFMLBNAEE_NeedPoint)
					return i;
			}
			return m_reward_list.Count - 1;
		}

		// // RVA: 0x1633540 Offset: 0x1633540 VA: 0x1633540
		// private int GetAcquiredRewardIndex() { }

		// // RVA: 0x1633674 Offset: 0x1633674 VA: 0x1633674
		public void Init(LFAFJCNKLML data, int item_type)
		{
			m_data = data;
			item_data = NIHHKCDHLNH.FKDIMODKKJD(data.AHHJLDLAPAN_DivaId)[item_type];
			m_item_use_type = item_type;
			m_reward_list = data.OCOOHBINGBG_LevelInfo;
			m_have_item = item_data.HMFFHLPNMPH_Cnt;
			m_use_item_min = 0;
			m_use_item_max = Mathf.CeilToInt((m_data.JHLKLPEHHCD_GetCurrentLevelInfo().DNBFMLBNAEE_NeedPoint - m_data.ABLHIAEDJAI_Point) * 1.0f / item_data.IILKAJBHLMJ_ItemPointValue);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			StringBuilder str = new StringBuilder();
			str.SetFormatSmart(bk.GetMessageByLabel("costume_upgrade_use_item_limit_text"), m_use_item_max);
			m_caution.text = str.ToString();
			m_item_name.text = item_data.OPFGFINHFCE_Name;
			m_item_use_num = 0;
			LFAFJCNKLML.GFIPDFPIKIJ g;
			LFAFJCNKLML.HKKKKFLBFJN(m_data, m_data.GKIKAABHAAD_Level, out g, LFAFJCNKLML.EJOEMKJOCMH.CCAPCGPIIPF);
			UpdateItemValue();
			CostumeUpgradeUtility.SettingRewardIcon(m_data, g.GLCLFMGPMAN_ItemId, m_data.GKIKAABHAAD_Level, g.NANNGLGOFKH_Value, m_reward_icon, null);
			SetUseItemImage(item_type + 220001);
			m_have_uc.text = MOEALEGLGCH.LLCBDMCPBOD_GetHaveUc().ToString();
			m_necessary_uc.text = m_data.KPJJLJLJDIA(0).ToString();
			m_get_icon.StartChildrenAnimGoStop(1, 1);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CE1DC Offset: 0x6CE1DC VA: 0x6CE1DC
		// RVA: 0x1633CC4 Offset: 0x1633CC4 VA: 0x1633CC4
		public IEnumerator CO_Init(LFAFJCNKLML data, int item_type)
		{
			//0x163440C
			gameObject.SetActive(true);
			transform.localPosition = new Vector3(1000, 1000, 0);
			yield return null;
			Init(data, item_type);
			yield return null;
			GetRoot();
			while(!m_use_item_image.enabled)
				yield return null;
			while(!m_reward_icon.item_image.enabled && !m_reward_icon.diva_image.enabled)
				yield return null;
			yield return null;
			gameObject.SetActive(false);
			transform.localPosition = Vector3.zero;
		}

		// // RVA: 0x1633DA4 Offset: 0x1633DA4 VA: 0x1633DA4
		public void Enter()
		{
			m_plus.IsInputOff = false;
			m_minus.IsInputOff = false;
		}

		// // RVA: 0x1633DFC Offset: 0x1633DFC VA: 0x1633DFC
		public void OpenEnd()
		{
			GetRoot();
			m_pop_window.SetDisable(m_item_use_num == 0);
		}

		// // RVA: 0x1633B90 Offset: 0x1633B90 VA: 0x1633B90
		private void SetUseItemImage(int index)
		{
			m_use_item_image.enabled = false;
			MenuScene.Instance.ItemTextureCache.Load(index, (IiconTexture icon) =>
			{
				//0x1634304
				icon.Set(m_use_item_image);
				m_use_item_image.enabled = true;
			});
		}

		// // RVA: 0x1633228 Offset: 0x1633228 VA: 0x1633228
		private void SetGauge(int gauge, int up)
		{
			int start = (int)(up * 1.02f);
			int start0 = (int)(gauge * 1.02f);
			m_gauge_progress.StartSiblingAnimGoStop(1, 1);
			m_gauge.on.StartAnimGoStop(start0, start0);
			m_gauge.under.StartAnimGoStop(start, start);
			m_gauge.eff.StartAnimGoStop(start0, start0);
			m_gauge.up.StartAnimGoStop(start0, start0);
		}

		// RVA: 0x1633F74 Offset: 0x1633F74 VA: 0x1633F74
		private void LateUpdate()
		{
			if(IsLoaded())
			{
				m_time += Time.deltaTime;
				UpdateUcLack();
			}
		}

		// // RVA: 0x1633338 Offset: 0x1633338 VA: 0x1633338
		private void UpdateUcLack()
		{
			if(m_isLack && m_animeCurve != null)
			{
				float f = m_animeCurve[0].Evaluate(m_time);
				m_have_uc.color = Color.Lerp(SystemTextColor.GetLackColor(), SystemTextColor.GetImportantYellowColor(), f);
			}
			else
			{
				m_have_uc.color = m_baseColor;
			}
		}

		// RVA: 0x1633FC0 Offset: 0x1633FC0 VA: 0x1633FC0
		public int GetItemUseCount()
		{
			return m_item_use_num;
		}

		// RVA: 0x1633FD0 Offset: 0x1633FD0 VA: 0x1633FD0
		public int GetItemUseType()
		{
			return m_item_use_type;
		}

		// RVA: 0x1633FD8 Offset: 0x1633FD8 VA: 0x1633FD8
		public int GetAddCostumePoint()
		{
			return m_item_use_num * item_data.IILKAJBHLMJ_ItemPointValue;
		}

		// // RVA: 0x1633E44 Offset: 0x1633E44 VA: 0x1633E44
		private void GetRoot()
		{
			Transform t = transform;
			while(true)
			{
				Canvas c = t.parent.GetComponent<Canvas>();
				if(c != null)
				{
					m_root = t.GetComponent<RectTransform>();
					return;
				}
				t = t.parent;
			}
		}
	}
}
