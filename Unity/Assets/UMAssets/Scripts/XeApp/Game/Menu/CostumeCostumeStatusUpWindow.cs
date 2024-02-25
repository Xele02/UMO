using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeApp.Game.Common.uGUI;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	internal class CostumeCostumeStatusUpWindow : LayoutUGUIScriptBase
	{
		private LFAFJCNKLML m_data; // 0x14
		private CostumeUpgradeUtility.CostumeData m_costume = new CostumeUpgradeUtility.CostumeData(); // 0x18
		private Text m_costumeName; // 0x1C
		private Text m_oldSkillName; // 0x20
		private Text m_newSkillName; // 0x24
		private RawImageEx m_costumeArrow; // 0x28
		private AbsoluteLayout m_statusUpAnim; // 0x2C
		private AbsoluteLayout m_statusUpEffectAnim; // 0x30
		private bool m_IsInialize; // 0x34

		// RVA: 0x1627DC0 Offset: 0x1627DC0 VA: 0x1627DC0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_statusUpAnim = layout.FindViewById("sw_st_up_anim") as AbsoluteLayout;
			m_statusUpEffectAnim = layout.FindViewById("sw_pu_ef_anim") as AbsoluteLayout;
			Transform t = transform.Find("sw_st_up_cos_set (AbsoluteLayout)");
			m_costume.image = t.Find("cos_01_001 (AbsoluteLayout)/cos_01_001 (ImageView)").GetComponent<RawImageEx>();
			m_costume.rank = new CostumeUpgradeUtility.CostumeData.RankData();
			m_costume.rank.num = layout.FindViewById("swtbl_star_num_02") as AbsoluteLayout;
			m_costume.rank.enable = new List<AbsoluteLayout>();
			for(int i = 0; i < 6; i++)
			{
				m_costume.rank.enable.Add(layout.FindViewByExId("swtbl_star_num_02_swbtl_star_on_off_0" + (i + 1).ToString()) as AbsoluteLayout);
			}
			m_costumeName = t.Find("cos_name_01 (TextView)").GetComponent<Text>();
			m_oldSkillName = t.Find("cos_ef_01 (TextView)").GetComponent<Text>();
			m_newSkillName = t.Find("cos_ef_02 (TextView)").GetComponent<Text>();
			m_costumeArrow = t.Find("cmn_arr_d_02 (ImageView)").GetComponent<RawImageEx>();
			m_costume.rank.num = layout.FindViewById("swtbl_star_num_02") as AbsoluteLayout;
			return true;
		}

		// RVA: 0x16283E4 Offset: 0x16283E4 VA: 0x16283E4
		public void Initialize(LFAFJCNKLML data)
		{
			m_data = data;
			m_costume.SetCostumeIcon(new CostumeUpgradeUtility.CostumeData.Setting()
			{
				divaId = data.AHHJLDLAPAN_DivaId,
				costumeModelId = data.DAJGPBLEEOB_PrismCostumeId,
				colorId = null,
				isHave = data.FJODMPGPDDD_Possessed,
				rankMax = data.LLLCMHENKKN_LevelMax,
				rankNum = data.GKIKAABHAAD_Level + 1
			}, null);
			m_costumeName.text = m_data.OPFGFINHFCE_Name;
			string s = "";
			string t = "";
			m_data.OHGOPFEOJOG_GetSkillInfo(data.GKIKAABHAAD_Level + 1, ref s, ref t);
			m_newSkillName.text = t;
			m_data.OHGOPFEOJOG_GetSkillInfo(data.GKIKAABHAAD_Level, ref s, ref t);
			m_oldSkillName.text = t;
			if(s == TextConstant.InvalidText)
			{
				m_oldSkillName.text = RichTextUtility.MakeColorTagString(m_newSkillName.text, StatusTextColor.UpColor);
				m_newSkillName.text = "";
				m_costumeArrow.enabled = false;
			}
			else
			{
				m_newSkillName.text = RichTextUtility.MakeColorTagString(m_newSkillName.text, StatusTextColor.UpColor);
				m_costumeArrow.enabled = true;
			}
			m_IsInialize = true;
		}

		// RVA: 0x1628930 Offset: 0x1628930 VA: 0x1628930
		public void Start()
		{
			if(!m_IsInialize)
				return;
			this.StartCoroutineWatched(Co_StatusAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CDCDC Offset: 0x6CDCDC VA: 0x6CDCDC
		// // RVA: 0x1628964 Offset: 0x1628964 VA: 0x1628964
		private IEnumerator Co_StatusAnim()
		{
			//0x1628ABC
			m_statusUpAnim.StartAllAnimGoStop("go_in", "st_in");
			m_statusUpEffectAnim.StartChildrenAnimLoop("logo_", "loen_");
			yield return new WaitWhile(() =>
			{
				//0x1628A8C
				return m_statusUpAnim.IsPlaying();
			});
			m_statusUpAnim.StartAllAnimLoop("logo_up", "loen_up");
		}
	}
}
