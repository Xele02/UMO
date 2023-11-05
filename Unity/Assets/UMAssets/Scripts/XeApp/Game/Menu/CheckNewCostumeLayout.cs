using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using XeSys;

namespace XeApp.Game.Menu
{
	public class CheckNewCostumeLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_btn; // 0x14
		[SerializeField]
		private RawImageEx m_divaIcon; // 0x18
		[SerializeField]
		private RawImageEx m_costumeImage; // 0x1C
		[SerializeField]
		private Text m_episodeText; // 0x20
		[SerializeField]
		private Text m_skillText; // 0x24
		[SerializeField]
		private Text m_costumeInfoText; // 0x28
		[SerializeField]
		private Text m_costumeNameText; // 0x2C
		[SerializeField]
		private Text m_episodeDesc1Text; // 0x30
		[SerializeField]
		private Text m_episodeDesc2Text; // 0x34
		private AbsoluteLayout logo; // 0x38
		private AbsoluteLayout CostumeNameBack; // 0x3C
		private bool CostumeImageLoaded; // 0x40
		private bool DivaIconLoaded; // 0x41

		// // RVA: 0x10B1F90 Offset: 0x10B1F90 VA: 0x10B1F90
		public bool IsResourceLoaded()
		{
			return DivaIconLoaded && CostumeImageLoaded;
		}

		// RVA: 0x10B1FB0 Offset: 0x10B1FB0 VA: 0x10B1FB0
		public void Show()
		{
			logo.StartChildrenAnimGoStop("lo_");
		}

		// RVA: 0x10B202C Offset: 0x10B202C VA: 0x10B202C
		public bool IsPlaying()
		{
			return logo.IsPlaying() || CostumeNameBack.IsPlaying();
		}

		// RVA: 0x10B2084 Offset: 0x10B2084 VA: 0x10B2084
		public void Init(int diva_id, int cos_id, int color_id)
		{
			CostumeImageLoaded = false;
			DivaIconLoaded = false;
            List<FFHPBEPOMAK_DivaInfo> l = FFHPBEPOMAK_DivaInfo.DNAIGDHCILM_GetCostumeList(diva_id, true);
			FFHPBEPOMAK_DivaInfo dInfo = null;
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i].FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId == cos_id)
				{
					dInfo = l[i];
					break;
				}
			}
			PIGBBNDPPJC data = new PIGBBNDPPJC();
			data.KHEKNNFCAOI(dInfo.KELFCMEOPPM_EpisodeId);
			m_episodeText.text = JpStringLiterals.StringLiteral_15053 + data.OPFGFINHFCE_Name + JpStringLiterals.StringLiteral_15054;
			m_costumeNameText.text = dInfo.FFKMJNHFFFL_Costume.OPFGFINHFCE_Name;
			m_costumeInfoText.text = data.OPFGFINHFCE_Name + JpStringLiterals.StringLiteral_15055;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_episodeDesc1Text.text = bk.GetMessageByLabel("gacha_main_ep_caution01");
			m_episodeDesc2Text.text = bk.GetMessageByLabel("gacha_main_ep_caution02");
			m_skillText.text = dInfo.FFKMJNHFFFL_Costume.FCEGELPJAMH_SkillDesc;
			SetCostumeTexture(diva_id, cos_id, color_id);
			SetDivaIcon(diva_id, cos_id, color_id);
			CostumeNameBack.StartChildrenAnimGoStop(diva_id - 1, diva_id - 1);
        }

		// RVA: 0x10B2774 Offset: 0x10B2774 VA: 0x10B2774
		public ActionButton GetBtn()
		{
			return m_btn;
		}

		// // RVA: 0x10B2524 Offset: 0x10B2524 VA: 0x10B2524
		private void SetCostumeTexture(int diva_id, int model_id, int color_id)
		{
			MenuScene.Instance.CostumeIconCache.Load(diva_id, model_id, color_id, (IiconTexture icon) =>
			{
				//0x10B28D4
				icon.Set(m_costumeImage);
				CostumeImageLoaded = true;
			});
		}

		// // RVA: 0x10B264C Offset: 0x10B264C VA: 0x10B264C
		public void SetDivaIcon(int diva_id, int model_id, int color_id)
		{
			MenuScene.Instance.DivaIconCache.Load(diva_id, model_id, color_id, (IiconTexture icon) =>
			{
				//0x10B29BC
				icon.Set(m_divaIcon);
				DivaIconLoaded = true;
			});
		}

		// RVA: 0x10B277C Offset: 0x10B277C VA: 0x10B277C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			logo = layout.FindViewByExId("root_ul_cos02_sw_ul_logo_anim_02") as AbsoluteLayout;
			CostumeNameBack = layout.FindViewByExId("sw_ul_cos_all_swtbl_ul_cos_name") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
