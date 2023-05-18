using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Menu;
using XeSys;

namespace XeApp.Game.Common
{
	public class LayoutSkillRegulationWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text[] m_skillLevelTexts; // 0x14
		[SerializeField]
		private Text[] m_skillDetails; // 0x18
		[SerializeField]
		private Text[] m_skillNames; // 0x1C
		[SerializeField]
		private Text[] m_logoSeriesExceptText; // 0x20
		[SerializeField]
		private RawImageEx[] m_logoSeriesImages; // 0x24
		[SerializeField]
		private RawImageEx[] m_skillRankImages; // 0x28
		[SerializeField]
		private RawImageEx[] m_skilllimitAttributeImages; // 0x2C
		private TexUVListManager m_uvMan; // 0x30
		private GCIJNCFDNON_SceneInfo m_sceneData; // 0x34
		private AbsoluteLayout m_logoChangeLayout; // 0x38
		private AbsoluteLayout[] m_skillTypeLayout; // 0x3C
		private AbsoluteLayout[] m_skillLimitLayout; // 0x40
		private const string LevelFormat = "Lv{0}";
		private readonly string[] SkillLayoutExIds = new string[2]
			{
				"sw_skill_pop_sw_skill", "sw_skill_pop_sw_skill_2"
			}; // 0x44
		private readonly string[] SkillAttributeLayoutExIds = new string[2]
			{
				"sw_skill_pop_swtbl_rimit_zok", "sw_skill_pop_swtbl_rimit_zok_2"
			}; // 0x48

		// RVA: 0x1107BC8 Offset: 0x1107BC8 VA: 0x1107BC8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvMan = uvMan;
			m_logoChangeLayout = layout.FindViewByExId("sw_skill_swtbl_logo") as AbsoluteLayout;
			m_skillTypeLayout = new AbsoluteLayout[SkillLayoutExIds.Length];
			for(int i = 0; i < SkillLayoutExIds.Length; i++)
			{
				m_skillTypeLayout[i] = (layout.FindViewByExId(SkillLayoutExIds[i]) as AbsoluteLayout).FindViewByExId("sw_skill_skill_l") as AbsoluteLayout;
			}
			m_skillLimitLayout = new AbsoluteLayout[SkillAttributeLayoutExIds.Length];
			for(int i = 0; i < SkillAttributeLayoutExIds.Length; i++)
			{
				m_skillLimitLayout[i] = (layout.FindViewByExId(SkillAttributeLayoutExIds[i]) as AbsoluteLayout).FindViewByExId("swtbl_rimit_zok_cmn_chk_attri_lim") as AbsoluteLayout;
			}
			Loaded();
			return true;
		}

		// RVA: 0x11080E0 Offset: 0x11080E0 VA: 0x11080E0
		public void Setup(GCIJNCFDNON_SceneInfo sceneData, RegulationButton.Type type)
		{
			if (sceneData == null)
				return;
			m_sceneData = sceneData;
			if(type == RegulationButton.Type.Live)
			{
				ShowLiveSkill();
			}
			else if(type == RegulationButton.Type.Center)
			{
				ShowCenterSkill();
			}
		}

		//// RVA: 0x1109480 Offset: 0x1109480 VA: 0x1109480
		private void SetLimitEnable(bool enable, int index)
		{
			m_skillLimitLayout[index].StartAllAnimGoStop(enable ? "01" : "02");
		}

		//// RVA: 0x1109550 Offset: 0x1109550 VA: 0x1109550
		private void SetLimitAttribute(GameAttribute.Type attr, int index)
		{
			m_skilllimitAttributeImages[index].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(string.Format("cmn_zok_{0:D2}", (int)attr)));
		}

		//// RVA: 0x1108B64 Offset: 0x1108B64 VA: 0x1108B64
		private void ShowLiveSkill()
		{
			int series = 0;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_skillNames[series].text = m_sceneData.LNLECENGMKK_LiveSkillName2;
			m_skillDetails[series].text = m_sceneData.ODICCEOHOPH_LiveSkillDesc2;
			m_skillLevelTexts[series].text = string.Format("Lv{0}", m_sceneData.AADFFCIDJCB_LiveSkillLevel);
			m_logoSeriesExceptText[series].text = "";
			GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankImages[series], (SkillRank.Type) m_sceneData.ELNJADBILOM_LiveSkillRank2);
			UnitWindowConstant.SetSkillDetails(m_skillDetails[series], m_sceneData.KDGACEJPGFG_GetLiveSkillDesc(true), 2);
			GameManager.Instance.MenuResidentTextureCache.LoadLogo((int)m_sceneData.EMIKBGHIOMN_SerieLogo, (IiconTexture texture) =>
			{
				//0x1109928
				texture.Set(m_logoSeriesImages[series]);
			});
			m_logoChangeLayout.StartAllAnimGoStop("01");
			m_skillNames[1].text = m_sceneData.NDPPEMCHKHA_LiveSkillName1;
			m_skillDetails[1].text = m_sceneData.AGJBLOKLMED_LiveSkillDesc1;
			m_skillLevelTexts[1].text = string.Format("Lv{0}", m_sceneData.AADFFCIDJCB_LiveSkillLevel);
			m_logoSeriesExceptText[1].text = bk.GetMessageByLabel("liveskillregulation_except");
			GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankImages[1], (SkillRank.Type)m_sceneData.OAHMFMJIENM_LiveSkillRank);
			UnitWindowConstant.SetSkillDetails(m_skillDetails[1], m_sceneData.KDGACEJPGFG_GetLiveSkillDesc(false), 2);
			m_logoChangeLayout.StartAllAnimGoStop("02");
			for(int i = 0; i < m_skillTypeLayout.Length; i++)
			{
				if (m_skillTypeLayout[i] != null)
					m_skillTypeLayout[i].StartAllAnimGoStop("01");
			}
		}

		//// RVA: 0x1108108 Offset: 0x1108108 VA: 0x1108108
		private void ShowCenterSkill()
		{
			int series = 0;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_skillNames[series].text = m_sceneData.EFELCLMJEOL_CenterSkillName2;
			m_skillDetails[series].text = m_sceneData.IHLINMFMCDN_GetCenterSkillDesc(true);
			m_skillLevelTexts[series].text = string.Format("Lv{0}", m_sceneData.DDEDANKHHPN_SkillLevel);
			m_logoSeriesExceptText[series].text = "";
			GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankImages[series], (SkillRank.Type) m_sceneData.FFDCGHDNDFJ_CenterSkillRank2);
			UnitWindowConstant.SetSkillDetails(m_skillDetails[series], m_sceneData.IHLINMFMCDN_GetCenterSkillDesc(true), 2);
			GameManager.Instance.MenuResidentTextureCache.LoadLogo((int)m_sceneData.EMIKBGHIOMN_SerieLogo, (IiconTexture texture) =>
			{
				//0x1109A54
				texture.Set(m_logoSeriesImages[series]);
			});
			if(m_sceneData.NNOLHKHJPFJ_GetCenterSkillMusicAttr(null, true) == GameAttribute.Type.None)
			{
				SetLimitEnable(false, series);
			}
			else
			{
				SetLimitEnable(true, series);
				SetLimitAttribute(m_sceneData.NNOLHKHJPFJ_GetCenterSkillMusicAttr(null, true), series);
			}
			m_skillNames[1].text = m_sceneData.PFHJFIHGCKP_CenterSkillName1;
			m_skillDetails[1].text = m_sceneData.IHLINMFMCDN_GetCenterSkillDesc(false);
			m_skillLevelTexts[1].text = string.Format("Lv{0}", m_sceneData.DDEDANKHHPN_SkillLevel);
			m_logoSeriesExceptText[1].text = bk.GetMessageByLabel("liveskillregulation_except");
			GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankImages[1], (SkillRank.Type)m_sceneData.DHEFMEGKKDN_CenterSkillRank);
			UnitWindowConstant.SetSkillDetails(m_skillDetails[1], m_sceneData.IHLINMFMCDN_GetCenterSkillDesc(false), 2);
			m_logoChangeLayout.StartAllAnimGoStop("02");
			if (m_sceneData.NNOLHKHJPFJ_GetCenterSkillMusicAttr(null, false) == GameAttribute.Type.None)
			{
				SetLimitEnable(false, 1);
			}
			else
			{
				SetLimitEnable(true, 1);
				SetLimitAttribute(m_sceneData.NNOLHKHJPFJ_GetCenterSkillMusicAttr(null, false), 1);
			}
			for (int i = 0; i < m_skillTypeLayout.Length; i++)
			{
				if (m_skillTypeLayout[i] != null)
					m_skillTypeLayout[i].StartAllAnimGoStop("02");
			}
		}
	}
}
