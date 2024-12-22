using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class ValkyrieSkillCheckWindow : LayoutUGUIScriptBase
	{
		private Text m_category; // 0x14
		private Text m_level; // 0x18
		private Text m_description; // 0x1C

		// RVA: 0x16623DC Offset: 0x16623DC VA: 0x16623DC
		private void Start()
		{
			return;
		}

		// RVA: 0x16623E0 Offset: 0x16623E0 VA: 0x16623E0
		private void Update()
		{
			return;
		}

		// RVA: 0x16623E4 Offset: 0x16623E4 VA: 0x16623E4
		public void SetSkillData(ALEKLHIANJN data)
		{
			m_category.text = data.OPFGFINHFCE_SkillName;
			m_level.text = "Lv" + data.CHHADJECKNL_GetLevel();
			m_description.text = data.DMBDNIEEMCB_GetDesc(true);
		}

		// RVA: 0x1662538 Offset: 0x1662538 VA: 0x1662538 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Transform t = transform.Find("sw_val_ability_get (AbsoluteLayout)/sw_val_ability_get (AbsoluteLayout)/sw_val_abilityset (AbsoluteLayout)");
			Text[] txts = t.GetComponentsInChildren<Text>();
			m_category = txts.Where((Text _) =>
			{
				//0x16629CC
				return _.name == "abi_txt_name (TextView)";
			}).First();
			m_level = txts.Where((Text _) =>
			{
				//0x1662A4C
				return _.name == "abi_txt_lv (TextView)";
			}).First();
			m_description = txts.Where((Text _) =>
			{
				//0x1662ACC
				return _.name == "abi_txt (TextView)";
			}).First();
			Loaded();
			return true;
		}
	}
}
