using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System;
using XeSys;

namespace XeApp.Game.Common
{
	public class LuckyLeafOpenAbility : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text[] prevLeafEffectTexts; // 0x14
		[SerializeField]
		private Text[] addLeafEffectTexts; // 0x18
		[SerializeField]
		private Text unlockCondition; // 0x1C
		[SerializeField]
		private Text skillCaution; // 0x20
		[SerializeField]
		private Text kiraCaution; // 0x24
		[SerializeField]
		private ActionButton helpButton; // 0x28
		private AbsoluteLayout currentLeafLayout; // 0x2C
		private AbsoluteLayout nextLeafLayout; // 0x30
		private AbsoluteLayout statusLayoutUnder; // 0x34
		private AbsoluteLayout skillCautionLayout; // 0x38
		private AbsoluteLayout kiraLayout; // 0x3C
		private AbsoluteLayout[] currentLeaf = new AbsoluteLayout[5]; // 0x40
		private AbsoluteLayout[] nextLeaf = new AbsoluteLayout[5]; // 0x44
		private AEKDNMPPOJN currentOverLimit = new AEKDNMPPOJN(); // 0x48

		public Action OnClickHelpButton { get; set; } // 0x4C

		// RVA: 0x110C044 Offset: 0x110C044 VA: 0x110C044 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			currentLeafLayout = layout.FindViewByExId("sw_scene_ex_01_base_swtbl_add_leaf_anim_01") as AbsoluteLayout;
			nextLeafLayout = layout.FindViewByExId("sw_scene_ex_01_base_swtbl_add_leaf_anim_02") as AbsoluteLayout;
			statusLayoutUnder = layout.FindViewByExId("sw_scene_ex_01_base_swtbl_scene_ex_05") as AbsoluteLayout;
			skillCautionLayout = layout.FindViewByExId("sw_scene_ex_01_base_swtbl_fnt_ex_07") as AbsoluteLayout;
			kiraLayout = layout.FindViewByExId("sw_scene_ex_01_base_sw_pop_luckyleaf_kira_onoff") as AbsoluteLayout;
			for(int i = 0; i < 5; i++)
			{
				currentLeaf[i] = currentLeafLayout.FindViewByExId(string.Format("swtbl_add_leaf_anim_pop_luckyleaf_off_{0:D2}", i + 1)) as AbsoluteLayout;
				nextLeaf[i] = nextLeafLayout.FindViewByExId(string.Format("swtbl_add_leaf_anim_pop_luckyleaf_off_{0:D2}", i + 1)) as AbsoluteLayout;
			}
			helpButton.AddOnClickCallback(() =>
			{
				//0x110D1DC
				if (OnClickHelpButton != null)
					OnClickHelpButton();
			});
			ClearLoadedCallback();
			return true;
		}

		// RVA: 0x110C5F8 Offset: 0x110C5F8 VA: 0x110C5F8
		public void Setup(GCIJNCFDNON_SceneInfo sceneData)
		{
			currentOverLimit.KHEKNNFCAOI(sceneData.JKGFBFPIMGA_Rarity, sceneData.MKHFCGPJPFI_LimitOverCount, sceneData.MJBODMOLOBC_Luck);
			currentOverLimit.OPBFFEMJBFH();
			string s = currentOverLimit.LJHOOPJACPI_LeafMax.ToString("00");
			currentLeafLayout.StartChildrenAnimGoStop(s);
			if(currentOverLimit.LJHOOPJACPI_LeafMax == currentOverLimit.DJEHLEJCPEL_LeafNum)
			{
				s = (currentOverLimit.DJEHLEJCPEL_LeafNum + 1).ToString("00");
			}
			else
			{
				s = currentOverLimit.LJHOOPJACPI_LeafMax.ToString("00");
			}
			nextLeafLayout.StartChildrenAnimGoStop(s);
			if(currentOverLimit.EKLIPGELKCL < 5 || currentOverLimit.DJEHLEJCPEL_LeafNum != 4 || currentOverLimit.LJHOOPJACPI_LeafMax != 5)
			{
				kiraLayout.StartChildrenAnimGoStop("02");
			}
			else
			{
				kiraLayout.StartChildrenAnimGoStop("01");
			}
			int i;
			for (i = 0; i < currentOverLimit.DJEHLEJCPEL_LeafNum; i++)
			{
				currentLeaf[i].StartChildrenAnimGoStop("02");
			}
			for(; i < currentLeaf.Length; i++)
			{
				currentLeaf[i].StartChildrenAnimGoStop("01");
			}
			for(i = 0; i < currentOverLimit.DJEHLEJCPEL_LeafNum + 1; i++)
			{
				nextLeaf[i].StartChildrenAnimGoStop("02");
			}
			for(; i < nextLeaf.Length; i++)
			{
				nextLeaf[i].StartChildrenAnimGoStop("01");
			}
			prevLeafEffectTexts[0].text = currentOverLimit.ABKCMICDHLN_LeafEffectExcellentRate;
			prevLeafEffectTexts[1].text = currentOverLimit.ACKDDGKFNIJ_LeafEffectCenterSkillRate;
			unlockCondition.text = currentOverLimit.IBKNFJLAGIH_UnlockCond;
			skillCautionLayout.StartChildrenAnimGoStop(currentOverLimit.CMCKNKKCNDK.centerLiveSkillRate > 0 ? "01" : "02");
			if(currentOverLimit.CJLNHKNLBGH.Count == 2)
			{
				statusLayoutUnder.StartChildrenAnimGoStop("03");
				for(i = 0; i < currentOverLimit.ONABNIGCGJK_AddLeafEffect.Count; i++)
				{
					addLeafEffectTexts[i].text = currentOverLimit.ONABNIGCGJK_AddLeafEffect[i];
				}
			}
			else
			{
				LimitOverTypeId.Type v = currentOverLimit.CJLNHKNLBGH[0];
				if(v < LimitOverTypeId.Type.Num)
				{
					if((0x2aU & (1 << (int)v)) == 0)
					{
						if ((0x54U & (1 << (int)v)) == 0)
						{
							;
						}
						else
						{
							statusLayoutUnder.StartChildrenAnimGoStop("02");
							addLeafEffectTexts[1].text = currentOverLimit.ONABNIGCGJK_AddLeafEffect[0];
						}
					}
					else
					{
						statusLayoutUnder.StartChildrenAnimGoStop("01");
						addLeafEffectTexts[0].text = currentOverLimit.ONABNIGCGJK_AddLeafEffect[0];
					}
				}
			}
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			skillCaution.text = bk.GetMessageByLabel("limit_over_unlock_04");
			kiraCaution.text = string.Format(bk.GetMessageByLabel("limit_over_popup_caution"), sceneData.EKLIPGELKCL_SceneRarity);
		}
	}
}
