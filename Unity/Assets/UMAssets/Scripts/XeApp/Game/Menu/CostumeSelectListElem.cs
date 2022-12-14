using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using UnityEngine.Events;

namespace XeApp.Game.Menu
{
	public class CostumeSelectListElem : SwapScrollListContent
	{
		[SerializeField]
		public AbsoluteLayout m_anim_type; // 0x20
		[SerializeField]
		public AbsoluteLayout m_anim_button; // 0x24
		[SerializeField]
		public AbsoluteLayout m_anim_set; // 0x28
		[SerializeField]
		public AbsoluteLayout m_anim_lock; // 0x2C
		[SerializeField]
		public AbsoluteLayout m_anim_star_base; // 0x30
		[SerializeField]
		public AbsoluteLayout m_anim_thumnail; // 0x34
		[SerializeField]
		public AbsoluteLayout[] m_anim_star_onoff = new AbsoluteLayout[6]; // 0x38
		[SerializeField]
		public Text m_text_status; // 0x3C
		[SerializeField]
		public Text m_text_name; // 0x40
		[SerializeField]
		public RawImageEx m_image_icon01; // 0x44
		[SerializeField]
		public RawImageEx m_image_icon02; // 0x48
		[SerializeField]
		public ActionButton m_btn_try; // 0x4C
		[SerializeField]
		public ActionButton m_btn_getinfo; // 0x50
		public CostumeSelectListWin m_parent; // 0x54
		public int m_index = -1; // 0x58
		public int m_diva_id; // 0x5C
		public int m_costume_id; // 0x60
		public int m_costume_color; // 0x64
		public int m_costume_model_id; // 0x68
		public int m_item_id; // 0x6C
		public readonly int MAX_LV = 6; // 0x70
		public int m_lv; // 0x74
		public int m_lv_max; // 0x78
							 //[CompilerGeneratedAttribute] // RVA: 0x66B248 Offset: 0x66B248 VA: 0x66B248
		public UnityAction<int> m_cb_try; // 0x7C
										  //[CompilerGeneratedAttribute] // RVA: 0x66B258 Offset: 0x66B258 VA: 0x66B258
		public UnityAction<int> m_cb_getinfo; // 0x80
		public NewMarkIcon m_new_icon; // 0x84

		// RVA: 0x16432A8 Offset: 0x16432A8 VA: 0x16432A8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_anim_type = layout.FindViewById("swtbl_sel_cos_list") as AbsoluteLayout;
			m_anim_button = layout.FindViewById("swtbl_sel_cos_btn_01") as AbsoluteLayout;
			m_anim_set = layout.FindViewById("swtbl_sel_cos_set_icon") as AbsoluteLayout;
			m_anim_lock = layout.FindViewById("swtbl_cmn_lock_icon") as AbsoluteLayout;
			m_anim_star_base = layout.FindViewById("swtbl_s_c_star_s_num") as AbsoluteLayout;
			m_anim_thumnail = layout.FindViewById("cmn_diva_cos_01") as AbsoluteLayout;
			m_anim_star_onoff[0] = layout.FindViewById("swtbl_s_c_star_s_01") as AbsoluteLayout;
			m_anim_star_onoff[1] = layout.FindViewById("swtbl_s_c_star_s_02") as AbsoluteLayout;
			m_anim_star_onoff[2] = layout.FindViewById("swtbl_s_c_star_s_03") as AbsoluteLayout;
			m_anim_star_onoff[3] = layout.FindViewById("swtbl_s_c_star_s_04") as AbsoluteLayout;
			m_anim_star_onoff[4] = layout.FindViewById("swtbl_s_c_star_s_05") as AbsoluteLayout;
			m_anim_star_onoff[5] = layout.FindViewById("swtbl_s_c_star_s_06") as AbsoluteLayout;
			m_image_icon01 = transform.Find("swtbl_sel_cos_list (AbsoluteLayout)/cmn_diva_cos_01 (AbsoluteLayout)/cmn_diva_cos_02 (AbsoluteLayout)/swtexf_cmn_diva_cos (ImageView)").GetComponent<RawImageEx>();
			m_image_icon02 = transform.Find("swtbl_sel_cos_list (AbsoluteLayout)/cmn_diva_cos_02 (AbsoluteLayout)/swtexf_cmn_diva_cos (ImageView)").GetComponent<RawImageEx>();
			ActionButton[] bs = GetComponentsInChildren<ActionButton>(true);
			m_btn_try = System.Array.Find(bs, (ActionButton _) =>
			{
				//0x1644FAC
				return _.name.Contains("sel_cos_btn_try_anim");
			});
			m_btn_getinfo = System.Array.Find(bs, (ActionButton _) =>
			{
				//0x1645044
				return _.name.Contains("sel_cos_btn_terms_anim");
			});
			Text[] ts = GetComponentsInChildren<Text>(true);
			m_text_status = System.Array.Find(ts, (Text _) =>
			{
				//0x16450DC
				return _.name.Contains("costume_status_01");
			});
			m_text_name = System.Array.Find(ts, (Text _) =>
			{
				//0x1645174
				return _.name.Contains("costume_name_01");
			});
			m_anim_type.StartChildrenAnimGoStop("02");
			m_anim_button.StartChildrenAnimGoStop("02");
			m_anim_set.StartChildrenAnimGoStop("02");
			m_anim_lock.StartChildrenAnimGoStop("02");
			if (m_anim_star_base != null)
			{
				m_anim_star_base.StartChildrenAnimGoStop("00");
				for (int i = 0; i < MAX_LV; i++)
				{
					m_anim_star_onoff[i].StartChildrenAnimGoStop("01");
				}
			}
			m_btn_try.AddOnClickCallback(OnPushBtnTry);
			m_btn_getinfo.AddOnClickCallback(OnPushBtnGetInfo);
			Loaded();
			return true;
		}

		// RVA: 0x164436C Offset: 0x164436C VA: 0x164436C
		private void OnDestroy()
		{
			if (m_new_icon != null)
			{
				m_new_icon.Release();
				m_new_icon = null;
			}
		}

		//// RVA: 0x16443C4 Offset: 0x16443C4 VA: 0x16443C4
		private void OnPushBtnTry()
		{
			if (m_cb_try != null)
				m_cb_try.Invoke(m_index);
		}

		//// RVA: 0x1644434 Offset: 0x1644434 VA: 0x1644434
		private void OnPushBtnGetInfo()
		{
			if (m_cb_getinfo != null)
				m_cb_getinfo.Invoke(m_index);
		}

		//// RVA: 0x16444A4 Offset: 0x16444A4 VA: 0x16444A4
		public void SetItem(int a_index, int a_diva_id, CostumeSelectListWin.ItemInfo a_item)
		{
			m_index = a_index;
			m_text_status.text = a_item.m_status;
			m_text_name.text = a_item.m_name;
			SetTexture(a_diva_id, a_item);
			SetLevel(a_diva_id, a_item);
			if (m_new_icon != null)
				m_new_icon.SetActive(a_item.m_is_new);
			m_anim_type.StartChildrenAnimGoStop(a_item.m_cos_color > 0 ? "02" : "01");
			m_anim_lock.StartChildrenAnimGoStop(a_item.m_is_have ? "02" : "01");
			m_anim_thumnail.StartChildrenAnimGoStop(a_item.m_is_have ? "01" : "02");
			m_anim_set.StartChildrenAnimGoStop(a_item.m_is_set ? "01" : "02");
			m_anim_button.StartChildrenAnimGoStop(m_parent.m_index_try == a_index ? "03" : (a_item.m_is_have ? "01" : "02"));
		}

		//// RVA: 0x1644754 Offset: 0x1644754 VA: 0x1644754
		private void SetTexture(int a_diva_id, CostumeSelectListWin.ItemInfo a_item)
		{
			int itemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume, a_item.m_cos_id);
			m_costume_id = a_item.m_cos_id;
			m_diva_id = a_diva_id;
			m_costume_model_id = a_item.m_view_diva.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId;
			m_costume_color = a_item.m_cos_color;
			m_item_id = itemId;
			if (m_costume_color == 0)
			{
				int t_diva_id = m_diva_id;
				int t_item_id = m_item_id;
				int t_costume_color = m_costume_color;
				GameManager.Instance.ItemTextureCache.Load(itemId, m_costume_color, (IiconTexture icon) =>
				{
					//0x164534C
					if (m_diva_id == t_diva_id && t_item_id == m_item_id && t_costume_color == m_costume_color)
					{
						icon.Set(m_image_icon01);
					}
				});
			}
			else
			{
				int t_diva_id = m_diva_id;
				int t_item_id = m_item_id;
				int t_costume_color = m_costume_color;
				GameManager.Instance.ItemTextureCache.Load(itemId, 0, (IiconTexture icon) =>
				{
					//0x164520C
					if (m_diva_id == t_diva_id && t_item_id == m_item_id)
					{
						icon.Set(m_image_icon02);
					}
				});
				GameManager.Instance.ItemTextureCache.Load(itemId, m_costume_color, (IiconTexture icon) =>
				{
					//0x16454B0
					if (m_diva_id == t_diva_id && t_item_id == m_item_id && t_costume_color == m_costume_color)
					{
						icon.Set(m_image_icon01);
					}
				});
			}
		}

		//// RVA: 0x1644BA8 Offset: 0x1644BA8 VA: 0x1644BA8
		private void SetLevel(int a_diva_id, CostumeSelectListWin.ItemInfo a_item)
		{
			int lvl = Mathf.Clamp(a_item.m_lv, 0, MAX_LV);
			int lvlMax = Mathf.Clamp(a_item.m_lv_max, 0, MAX_LV);
			if(m_lv != lvl || m_lv_max != lvlMax)
			{
				m_lv_max = lvlMax;
				m_lv = lvl;
				m_anim_star_base.StartChildrenAnimGoStop("0" + m_lv_max);
				for(int i = 0; i < MAX_LV; i++)
				{
					m_anim_star_onoff[i].StartChildrenAnimGoStop(i < m_lv ? "02" : "01");
				}
			}
		}

		//// RVA: 0x1644DAC Offset: 0x1644DAC VA: 0x1644DAC
		public void CreateNewIcon()
		{
			if (m_new_icon != null)
				return;
			Transform t = transform.Find("swtbl_sel_cos_list (AbsoluteLayout)/new_icon (AbsoluteLayout)");
			m_new_icon = new NewMarkIcon(t.gameObject);
			m_new_icon.SetActive(false);
		}

		//// RVA: 0x1644398 Offset: 0x1644398 VA: 0x1644398
		public void DestroyNewIcon()
		{
			if (m_new_icon != null)
			{
				m_new_icon.Release();
				m_new_icon = null;
			}

			//// RVA: 0x1644D88 Offset: 0x1644D88 VA: 0x1644D88
			//public void SetNewIcon(bool a_active) { }
		}
	}
}
