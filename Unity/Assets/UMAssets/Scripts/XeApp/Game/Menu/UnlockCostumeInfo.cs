using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class UnlockCostumeInfo : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_abs; // 0x14
		private AbsoluteLayout m_name_table; // 0x18
		private Transform m_content; // 0x1C
		private Text m_name; // 0x20
		private Text m_info; // 0x24
		private Text m_skill; // 0x28
		private RawImageEx m_chara_icon; // 0x2C
		private RawImageEx m_cos_icon; // 0x30
		private bool m_isCosutimeIconLoaded; // 0x34
		private bool m_isDivaIconLoaded; // 0x35
		private ActionButton m_btn; // 0x38
		private Action mUpdater; // 0x3C

		// RVA: 0x125559C Offset: 0x125559C VA: 0x125559C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_abs = layout.FindViewById("sw_ul_cos_all_anim") as AbsoluteLayout;
			m_name_table = layout.FindViewById("swtbl_ul_cos_name") as AbsoluteLayout;
			Transform t = transform.Find("sw_ul_cos_all_anim (AbsoluteLayout)/sw_ul_cos_all (AbsoluteLayout)");
			m_skill = t.Find("contents_00 (TextView)").GetComponent<Text>();
			m_info = t.Find("cos_00 (TextView)").GetComponent<Text>();
			m_name = t.Find("logo_00 (TextView)").GetComponent<Text>();
			m_chara_icon = t.Find("swtexc_m_icon01 (ImageView)").GetComponent<RawImageEx>();
			m_cos_icon = t.Find("swtexc_cos (ImageView)").GetComponent<RawImageEx>();
			m_btn = transform.Find("sw_ul_cos_all_anim (AbsoluteLayout)/sw_btn_anim (AbsoluteLayout)").GetComponent<ActionButton>();
			mUpdater = UpdateLoad;
			return true;
		}

		// RVA: 0x1255994 Offset: 0x1255994 VA: 0x1255994
		private void Start()
		{
			return;
		}

		// RVA: 0x1255998 Offset: 0x1255998 VA: 0x1255998
		private void Update()
		{
			MenuScene.Instance.CostumeIconCache.Update();
			MenuScene.Instance.DivaIconCache.Update();
		}

		// // RVA: 0x1255A9C Offset: 0x1255A9C VA: 0x1255A9C
		private void UpdateLoad()
		{
			mUpdater = UpdateIdle;
		}

		// // RVA: 0x1255B24 Offset: 0x1255B24 VA: 0x1255B24
		private void UpdateIdle()
		{
			return;
		}

		// RVA: 0x1255B28 Offset: 0x1255B28 VA: 0x1255B28
		public void Init(int diva_id, int cos_id, int color_id)
		{
			List<FFHPBEPOMAK_DivaInfo> l = FFHPBEPOMAK_DivaInfo.DNAIGDHCILM_GetCostumeList(diva_id, true);
			FFHPBEPOMAK_DivaInfo diva = null;
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i].FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId == cos_id)
				{
					diva = l[i];
					break;
				}
			}
			m_isCosutimeIconLoaded = false;
			m_isDivaIconLoaded = false;
			m_name.text = diva.FFKMJNHFFFL_Costume.HCPCHEPCFEA_GetCostumeName(color_id);
			m_info.text = diva.OPFGFINHFCE_DivaName + JpStringLiterals.StringLiteral_15055;
			m_skill.text = diva.FFKMJNHFFFL_Costume.FCEGELPJAMH_SkillDesc;
			SetCostumeTexture(diva_id, cos_id, color_id);
			SetDivaIcon(diva_id, cos_id, color_id);
			m_name_table.StartChildrenAnimGoStop(diva_id - 1, diva_id - 1);
		}

		// RVA: 0x125605C Offset: 0x125605C VA: 0x125605C
		public void Enter()
		{
			m_abs.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x12560E8 Offset: 0x12560E8 VA: 0x12560E8
		// public void Leave() { }

		// RVA: 0x1256174 Offset: 0x1256174 VA: 0x1256174
		public void Wait()
		{
			m_abs.StartChildrenAnimGoStop("st_wait");
		}

		// // RVA: 0x12561F0 Offset: 0x12561F0 VA: 0x12561F0
		// public bool IsPlaying() { }

		// // RVA: 0x125621C Offset: 0x125621C VA: 0x125621C
		public ActionButton GetBtn()
		{
			return m_btn;
		}

		// // RVA: 0x1255E0C Offset: 0x1255E0C VA: 0x1255E0C
		private void SetCostumeTexture(int diva_id, int model_id, int color)
		{
			MenuScene.Instance.CostumeIconCache.Load(diva_id, model_id, color, (IiconTexture icon) =>
			{
				//0x125624C
				icon.Set(m_cos_icon);
				m_isCosutimeIconLoaded = true;
			});
		}

		// // RVA: 0x1255F34 Offset: 0x1255F34 VA: 0x1255F34
		public void SetDivaIcon(int diva_id, int model_id, int color_id)
		{
			MenuScene.Instance.DivaIconCache.Load(diva_id, model_id, color_id, (IiconTexture icon) =>
			{
				//0x1256334
				icon.Set(m_chara_icon);
				m_isDivaIconLoaded = true;
			});
		}

		// // RVA: 0x1256224 Offset: 0x1256224 VA: 0x1256224
		public bool IsResourceLoaded()
		{
			return m_isCosutimeIconLoaded && m_isDivaIconLoaded;
		}
	}
}
