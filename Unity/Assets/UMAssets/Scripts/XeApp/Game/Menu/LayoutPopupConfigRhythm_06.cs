using System.Collections;
using UnityEngine.UI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigRhythm_06 : LayoutPopupConfigBase
	{
		public enum eTextType
		{
			CautionDetail = 0,
			DisplayDetail = 1,
			VideoTitle = 2,
			VideDesc001 = 3,
			Num = 4,
		}

		private enum eToggleButton
		{
			VideoMode = 0,
		}

		private TextSet[] m_textTbl = new TextSet[4]
			{
				new TextSet() { index = 0, label = "config_text_43" },
				new TextSet() { index = 1, label = "config_text_42" },
				new TextSet() { index = 2, label = "config_text_41" },
				new TextSet() { index = 3, label = "config_text_44" }
			}; // 0x38

		// RVA: 0x1ED23A4 Offset: 0x1ED23A4 VA: 0x1ED23A4 Slot: 6
		public override int GetContentsHeight()
		{
			return 194;
		}

		// RVA: 0x1ED23AC Offset: 0x1ED23AC VA: 0x1ED23AC Slot: 7
		public override bool IsShow()
		{
			return true;
		}

		//// RVA: 0x1ED23B4 Offset: 0x1ED23B4 VA: 0x1ED23B4 Slot: 8
		public override void SetStatus(ScrollRect scroll)
		{
			base.SetStatus(scroll);
			SetSelectToggleButton(0, ConfigManager.Instance.Option.IHEPCAHBECA_VideoMode);
		}

		//// RVA: 0x1ED2468 Offset: 0x1ED2468 VA: 0x1ED2468
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

		//[IteratorStateMachineAttribute] // RVA: 0x701F84 Offset: 0x701F84 VA: 0x701F84
		//// RVA: 0x1ED2670 Offset: 0x1ED2670 VA: 0x1ED2670
		private IEnumerator Setup()
		{
			//0x1ED2B4C
			SetText();
			SetCallbackToggleButton(0, (int value) =>
			{
				//0x1ED2ABC
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.SetVideoModeValue(value);
			});
			Loaded();
			yield break;
		}

		// RVA: 0x1ED271C Offset: 0x1ED271C VA: 0x1ED271C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			this.StartCoroutineWatched(Setup());
			return true;
		}
	}
}
