using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System;
using XeSys;

namespace XeApp.Game.Common
{
	public class LuckyLeafTerminate : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text[] m_texts; // 0x14
		[SerializeField]
		private ActionButton m_helpButton; // 0x18
		private AEKDNMPPOJN currentOverLimit = new AEKDNMPPOJN(); // 0x1C

		public Action OnClickHelpButton { get; set; } // 0x20

		// RVA: 0x110D200 Offset: 0x110D200 VA: 0x110D200 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_helpButton.AddOnClickCallback(() =>
			{
				//0x110D66C
				if(OnClickHelpButton != null)
					OnClickHelpButton();
			});
			ClearLoadedCallback();
			return true;
		}

		// RVA: 0x110D2B8 Offset: 0x110D2B8 VA: 0x110D2B8
		public void Setup(GCIJNCFDNON_SceneInfo sceneData)
		{
			currentOverLimit.KHEKNNFCAOI(sceneData.JKGFBFPIMGA_Rarity, sceneData.MKHFCGPJPFI_LimitOverCount, sceneData.MJBODMOLOBC_Luck);
			currentOverLimit.OPBFFEMJBFH();
			m_texts[0].text = currentOverLimit.ABKCMICDHLN_LeafEffectExcellentRate;
			m_texts[1].text = currentOverLimit.ACKDDGKFNIJ_LeafEffectCenterSkillRate;
			m_texts[2].text = MessageManager.Instance.GetMessage("menu", "limit_over_unlock_03");
			m_texts[3].text = MessageManager.Instance.GetMessage("menu", "limit_over_unlock_04");
		}
	}
}
