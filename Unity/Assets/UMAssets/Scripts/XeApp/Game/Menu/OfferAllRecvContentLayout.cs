using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using System.Collections.Generic;
using System.Text;
using XeSys;
using System.Collections;
using mcrs;

namespace XeApp.Game.Menu
{
	public class OfferAllRecvContentLayout : SwapScrollListContent
	{
		public enum Arrangement
		{
			LEFT = 0,
			MIDDLE = 1,
			RIGHT = 2,
			MAX = 3,
		}

		[SerializeField]
		private Text m_offerName; // 0x20
		[SerializeField]
		private Text m_platoonName; // 0x24
		[SerializeField]
		private Text m_divaName; // 0x28
		[SerializeField]
		private RawImageEx[] m_valkyrieIcon = new RawImageEx[3]; // 0x2C
		private AbsoluteLayout[] m_valkyrieLayout = new AbsoluteLayout[3]; // 0x30
		[SerializeField]
		private RawImageEx m_seriesIcon; // 0x34
		[SerializeField]
		private RawImageEx m_seriesLogo; // 0x38
		private AbsoluteLayout rootLayout; // 0x3C
		private AbsoluteLayout m_offerType; // 0x40
		private AbsoluteLayout m_offerLevel; // 0x44
		private AbsoluteLayout m_offerEventIcon; // 0x48
		private AbsoluteLayout m_divaIcon; // 0x4C
		private AbsoluteLayout m_successIcon; // 0x50
		private AbsoluteLayout m_offerLogoState; // 0x54
		private AbsoluteLayout m_offerLevelMax; // 0x58
		private AbsoluteLayout[] m_levelIcon = new AbsoluteLayout[6]; // 0x5C
		private string m_IconTextureUvName = "s_v_icon_{0:d2}"; // 0x60
		private string m_LogoTextureUvName = "s_v_logo_{0:d2}"; // 0x64
		private TexUVList m_texUvList_3; // 0x68
		private bool isSetup; // 0x6C
		
		// RVA: 0x151DA08 Offset: 0x151DA08 VA: 0x151DA08
		public bool IsSetup()
		{
			return isSetup;
		}

		// RVA: 0x151DA10 Offset: 0x151DA10 VA: 0x151DA10
		public void Setup()
		{
			return;
		}

		// RVA: 0x151DA14 Offset: 0x151DA14 VA: 0x151DA14
		public void Setup(List<HEFCLPGPMLK.ANKPCIEKPAH> vfInfoList, HEFCLPGPMLK.AAOPGOGGMID offerInfo, string platoonName)
		{
			m_offerName.text = offerInfo.IJOLPDKFLPO_OfferName;
			m_platoonName.text = platoonName;
			SetOfferType(offerInfo.CGKPIIFCCLD_OfferType);
			SetEventIcon(offerInfo.HBJEDMOMAEE_SpOfferType);
			SetSeriesLogo(offerInfo.DFMOGBOPLEF_Series);
			SetSeriesIcon(offerInfo.DFMOGBOPLEF_Series);
			SetLevelIcon(offerInfo.CIEOBFIIPLD_Level, offerInfo.NBLBJCLIDNN_MaxLevel, offerInfo.NBHEBLNHOJO);
			if (offerInfo.FGHGMHPNEMG_Category == BOPFPIHGJMD.MLBMHDCCGHI.FMLPIOFBCMA_3_Diva)
				SetDivaOffer(offerInfo);
			int loadCount = 0;
			for (int i = 0; i < vfInfoList.Count; i++)
			{
				int index = i;
				if(vfInfoList[i].LLOBHDMHJIG_Id < 1)
				{
					m_valkyrieLayout[vfInfoList[i].JMHKMDFNAIN].StartChildrenAnimGoStop("01");
					loadCount++;
					if (loadCount == vfInfoList.Count)
						isSetup = true;
				}
				else
				{
					SetAbilityAnim(vfInfoList[i].LLOBHDMHJIG_Id, vfInfoList[i].JMHKMDFNAIN);
					GameManager.Instance.ValkyrieIconCache.Load(vfInfoList[i].LLOBHDMHJIG_Id, 0, (IiconTexture image) =>
					{
						//0x151F5A8
						image.Set(m_valkyrieIcon[vfInfoList[index].JMHKMDFNAIN]);
						m_valkyrieLayout[vfInfoList[index].JMHKMDFNAIN].StartChildrenAnimGoStop("02");
						loadCount++;
						if (loadCount == vfInfoList.Count)
							isSetup = true;
					});
				}
			}
		}

		// RVA: 0x151EAA4 Offset: 0x151EAA4 VA: 0x151EAA4
		public void SetSuccessIcon(bool isGreatSuccess)
		{
			m_successIcon.StartChildrenAnimGoStop(isGreatSuccess ? "01" : "02");
		}

		// RVA: 0x151EB3C Offset: 0x151EB3C VA: 0x151EB3C
		public void BeginAnim()
		{
			this.StartCoroutineWatched(Co_BeginAnim());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F82AC Offset: 0x6F82AC VA: 0x6F82AC
		//// RVA: 0x151EB60 Offset: 0x151EB60 VA: 0x151EB60
		private IEnumerator Co_BeginAnim()
		{
			//0x151F8FC
			rootLayout.StartChildrenAnimGoStop("go_in", "st_in");
			while (rootLayout.IsPlayingChildren())
				yield return null;
			SoundManager.Instance.sePlayerResult.Play((int)cs_se_result.SE_RESULT_016);
		}

		// RVA: 0x151EC0C Offset: 0x151EC0C VA: 0x151EC0C
		public void SkipAnim()
		{
			rootLayout.StartAllAnimGoStop("st_in");
		}

		// RVA: 0x151EC88 Offset: 0x151EC88 VA: 0x151EC88
		public void EndAnim()
		{
			rootLayout.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x151E14C Offset: 0x151E14C VA: 0x151E14C
		private void SetOfferType(BOPFPIHGJMD.ADMNKELOLPN type)
		{
			switch(type)
			{
				case BOPFPIHGJMD.ADMNKELOLPN.CCAPCGPIIPF_1:
					m_offerType.StartChildrenAnimGoStop("01");
					break;
				case BOPFPIHGJMD.ADMNKELOLPN.NBHIECDDJHH_2:
					m_offerType.StartChildrenAnimGoStop("04");
					break;
				case BOPFPIHGJMD.ADMNKELOLPN.HFPIACELNLL_3:
					m_offerType.StartChildrenAnimGoStop("02");
					break;
				case BOPFPIHGJMD.ADMNKELOLPN.HIIPBAMPCEM_4:
					m_offerType.StartChildrenAnimGoStop("03");
					break;
				default:
					break;
			}
		}

		//// RVA: 0x151E264 Offset: 0x151E264 VA: 0x151E264
		private void SetEventIcon(BOPFPIHGJMD.HDHDOOLPBEO spOfferType)
		{
			if(spOfferType == BOPFPIHGJMD.HDHDOOLPBEO.CCDOBDNDPIL_1)
			{
				m_offerEventIcon.StartAnimGoStop("01");
			}
			else if(spOfferType == BOPFPIHGJMD.HDHDOOLPBEO.LJJODKKOOFD_2 || spOfferType == BOPFPIHGJMD.HDHDOOLPBEO.MOADAEHPFPA_3)
			{
				m_offerEventIcon.StartAnimGoStop("02");
			}
			else
			{
				m_offerEventIcon.StartAnimGoStop("03");
			}
		}

		//// RVA: 0x151E958 Offset: 0x151E958 VA: 0x151E958
		private void SetAbilityAnim(int valId, int index)
		{
			NHDJHOPLMDE n = new NHDJHOPLMDE(valId, 0);
			if(n.LAKLFHGMCLI(EPIFHEDDJAE.NGEDJNHECKN.FJFMLFPJKNB_2, index == 0 ? EPIFHEDDJAE.JFEIHHBGFPF_AbilityCondition.FHBJEIEPABF_12 : EPIFHEDDJAE.JFEIHHBGFPF_AbilityCondition.PPNNBADDNKB_11))
			{
				m_valkyrieLayout[index].StartAllAnimLoop("logo_abi", "loen_abi");
			}
			else
			{
				m_valkyrieLayout[index].StartAllAnimLoop("st_wait");
			}
		}

		//// RVA: 0x151E5A8 Offset: 0x151E5A8 VA: 0x151E5A8
		private void SetLevelIcon(int level, int maxLevel, bool isMaxLevel)
		{
			m_offerLevelMax.StartAllAnimGoStop(isMaxLevel ? "01" : "02");
			m_levelIcon[0].StartSiblingAnimGoStop(maxLevel < 1 ? 1.ToString("D2") : maxLevel.ToString("D2"));
			for(int i = 0; i < m_levelIcon.Length; i++)
			{
				m_levelIcon[i].StartChildrenAnimGoStop(level <= i ? "02" : "01");
			}
		}

		//// RVA: 0x151E75C Offset: 0x151E75C VA: 0x151E75C
		private void SetDivaOffer(HEFCLPGPMLK.AAOPGOGGMID offerInfo)
		{
			m_offerLogoState.StartChildrenAnimGoStop("02");
			StringBuilder str = new StringBuilder(64);
			str.SetFormat("diva_s_{0:D2}", offerInfo.AHHJLDLAPAN);
			m_divaIcon.StartChildrenAnimGoStop(offerInfo.AHHJLDLAPAN.ToString("D2"));
			m_divaName.text = MessageManager.Instance.GetMessage("master", str.ToString());
		}

		//// RVA: 0x151E32C Offset: 0x151E32C VA: 0x151E32C
		private void SetSeriesLogo(BOPFPIHGJMD.LGEIPIHHNPH seriesIcon)
		{
			if(((int)seriesIcon | 2) != 7 && seriesIcon > 0 && seriesIcon <= BOPFPIHGJMD.LGEIPIHHNPH.LCBPJOKNKPL_7)
			{
				if (seriesIcon == BOPFPIHGJMD.LGEIPIHHNPH.GDEJFFFHFGP_6)
					seriesIcon = BOPFPIHGJMD.LGEIPIHHNPH.CFBJGAGBJEN_5;
				TexUVData data = m_texUvList_3.GetUVData(string.Format(m_LogoTextureUvName, (int)seriesIcon));
				if(data != null)
				{
					m_seriesLogo.uvRect = LayoutUGUIUtility.MakeUnityUVRect(data);
				}
			}
		}

		//// RVA: 0x151E474 Offset: 0x151E474 VA: 0x151E474
		private void SetSeriesIcon(BOPFPIHGJMD.LGEIPIHHNPH seriesIcon)
		{
			if(seriesIcon > 0 && seriesIcon <= BOPFPIHGJMD.LGEIPIHHNPH.LCBPJOKNKPL_7)
			{
				TexUVData data = m_texUvList_3.GetUVData(string.Format(m_IconTextureUvName, (int)seriesIcon));
				if(data != null)
				{
					m_seriesIcon.uvRect = LayoutUGUIUtility.MakeUnityUVRect(data);
				}
			}
		}

		// RVA: 0x151ED14 Offset: 0x151ED14 VA: 0x151ED14 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			rootLayout = layout.Root[0] as AbsoluteLayout;
			m_offerType = layout.FindViewByExId("s_v_frm_plat_bg_swtbl_s_v_frm_type") as AbsoluteLayout;
			m_offerLevel = layout.FindViewByExId("s_v_frm_plat_bg_swtbl_s_v_frm_type") as AbsoluteLayout;
			m_offerEventIcon = layout.FindViewByExId("swtbl_s_v_icon_event_s_v_icon_event_01") as AbsoluteLayout;
			m_divaIcon = layout.FindViewByExId("swtbl_s_v_logo_swtbl_s_v_minichara") as AbsoluteLayout;
			m_successIcon = layout.FindViewByExId("sw_platoon_in_anim_swtbl_sw_fnt_success") as AbsoluteLayout;
			m_offerLogoState = layout.FindViewByExId("s_v_frm_plat_bg_swtbl_s_v_logo") as AbsoluteLayout;
			m_offerLevelMax = layout.FindViewByExId("s_v_frm_plat_bg_swtbl_s_v_lv_max") as AbsoluteLayout;
			for(int i = 0; i < 6; i++)
			{
				m_levelIcon[i] = layout.FindViewByExId(string.Format("swtbl_s_v_lv_{0:D2}", i + 1)) as AbsoluteLayout;
			}
			for(int i = 0; i < 3; i++)
			{
				m_valkyrieLayout[i] = layout.FindViewByExId(string.Format("s_v_frm_plat_bg_swtbl_s_v_btn_val_{0:D1}", i + 1)) as AbsoluteLayout;
			}
			rootLayout.StartAllAnimGoStop("st_wait");
			m_texUvList_3 = uvMan.GetTexUVList("sel_vfo_03_pack");
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
