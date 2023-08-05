using System.Collections;
using UnityEngine.UI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigRhythm_07 : LayoutPopupConfigBase
	{
		public enum eTextType
		{
			BackKeyDesc001 = 0,
			BackKeyDesc002 = 1,
			BackKeyTitle = 2,
			Num = 3,
		}

		private enum eToggleButton
		{
			BackKey = 0,
		}

		private TextSet[] m_textTbl = new TextSet[3]
			{
				new TextSet() { index = 0, label = "config_text_34" },
				new TextSet() { index = 1, label = "config_text_35" },
				new TextSet() { index = 2, label = "config_text_36" }
			}; // 0x38

		// RVA: 0x1ED2CF0 Offset: 0x1ED2CF0 VA: 0x1ED2CF0 Slot: 6
		public override int GetContentsHeight()
		{
			return 140;
		}

		// RVA: 0x1ED2CF8 Offset: 0x1ED2CF8 VA: 0x1ED2CF8 Slot: 7
		public override bool IsShow()
		{
			return true;
		}

		//// RVA: 0x1ED2D00 Offset: 0x1ED2D00 VA: 0x1ED2D00 Slot: 8
		public override void SetStatus(ScrollRect scroll)
		{
			base.SetStatus(scroll);
			SetSelectToggleButton(0, ConfigManager.Instance.Option.OAKOJGPBAJF_BackKey);
		}

		//// RVA: 0x1ED2DB4 Offset: 0x1ED2DB4 VA: 0x1ED2DB4
		private void SetText()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			for (int i = 0; i < m_textTbl.Length; i++)
			{
				if (!string.IsNullOrEmpty(m_textTbl[i].label))
				{
					SetText(m_textTbl[i].index, bk.GetMessageByLabel(m_textTbl[i].label));
				}
				else
				{
					SetText(i, "");
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70205C Offset: 0x70205C VA: 0x70205C
		//// RVA: 0x1ED2FBC Offset: 0x1ED2FBC VA: 0x1ED2FBC
		private IEnumerator Setup()
		{
			//0x1ED33D4
			SetText();
			SetCallbackToggleButton(0, (int value) =>
			{
				//0x1ED3344
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.SetBackKeyValue(value);
			});
			Loaded();
			yield break;
		}

		// RVA: 0x1ED3068 Offset: 0x1ED3068 VA: 0x1ED3068 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			this.StartCoroutineWatched(Setup());
			return true;
		}
	}
}
