using System.Collections;
using UnityEngine.UI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigSimulation_04 : LayoutPopupConfigBase
	{
		public enum eTextType
		{
			EffectTitle = 0,
			Num = 1,
		}

		private enum eToggleButton
		{
			EffectCutin = 0,
		}

		private TextSet[] m_textTbl = new TextSet[1]
			{
				new TextSet() { index = 0, label = "config_text_09" }
			}; // 0x38

		// RVA: 0x1EDB20C Offset: 0x1EDB20C VA: 0x1EDB20C Slot: 6
		public override int GetContentsHeight()
		{
			return 120;
		}

		// RVA: 0x1EDB214 Offset: 0x1EDB214 VA: 0x1EDB214 Slot: 7
		public override bool IsShow()
		{
			return true;
		}

		// RVA: 0x1EDB21C Offset: 0x1EDB21C VA: 0x1EDB21C Slot: 8
		public override void SetStatus(ScrollRect scroll)
		{
			base.SetStatus(scroll);
			SetSelectToggleButton(0, ConfigManager.Instance.OptionSLive.DADIPGPHLDD_EffectCutin);
		}

		//// RVA: 0x1EDB2D0 Offset: 0x1EDB2D0 VA: 0x1EDB2D0
		private void SetText()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			for(int i = 0; i < m_textTbl.Length; i++)
			{
				string s = "";
				int index = i;
				if(!string.IsNullOrEmpty(m_textTbl[i].label))
				{
					s = m_textTbl[i].label;
					index = m_textTbl[i].index;
				}
				SetText(index, s);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x702804 Offset: 0x702804 VA: 0x702804
		//// RVA: 0x1EDB4D8 Offset: 0x1EDB4D8 VA: 0x1EDB4D8
		private IEnumerator Setup()
		{
			//0x1EDB76C
			SetText();
			SetCallbackToggleButton(0, (int value) =>
			{
				//0x1EDB6D8
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.SetEffectCutinValue(value, true);
			});
			Loaded();
			yield break;
		}

		// RVA: 0x1EDB584 Offset: 0x1EDB584 VA: 0x1EDB584 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			this.StartCoroutineWatched(Setup());
			return true;
		}
	}
}
