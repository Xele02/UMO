using System.Collections;
using UnityEngine.UI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigRhythm_10 : LayoutPopupConfigBase
	{
		public enum eTextType
		{
			NotesDesignDetail = 0,
			NotesDesignTitle = 1,
			Num = 2,
		}

		private enum eToggleButton
		{
			NotesType = 0,
			NotesColor = 1,
		}

		// Fields
		private AbsoluteLayout m_notesColorTbl; // 0x38
		private TexUVList m_texUvList; // 0x3C
		private TextSet[] m_textTbl = new TextSet[2]
			{
				new TextSet() { index = 0, label = "config_text_69" },
				new TextSet() { index = 1, label = "config_text_68" }
			}; // 0x40

		// RVA: 0x1ED58F4 Offset: 0x1ED58F4 VA: 0x1ED58F4 Slot: 6
		public override int GetContentsHeight()
		{
			return 408;
		}

		// RVA: 0x1ED58FC Offset: 0x1ED58FC VA: 0x1ED58FC Slot: 7
		public override bool IsShow()
		{
			return true;
		}

		//// RVA: 0x1ED5904 Offset: 0x1ED5904 VA: 0x1ED5904 Slot: 8
		public override void SetStatus(ScrollRect scroll)
		{
			base.SetStatus(scroll);
			int a;
			int b;
			ConfigManager.Instance.Option.FFLGCAJBPDE(out a, out b);
			string s = (b + 1).ToString("D2");
			m_notesColorTbl.StartChildrenAnimGoStop(s, s);
			SetSelectToggleButton(0, a);
			SetSelectToggleButton(1, b);
		}

		//// RVA: 0x1ED5A50 Offset: 0x1ED5A50 VA: 0x1ED5A50
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

		//[IteratorStateMachineAttribute] // RVA: 0x7022D4 Offset: 0x7022D4 VA: 0x7022D4
		//// RVA: 0x1ED5C58 Offset: 0x1ED5C58 VA: 0x1ED5C58
		private IEnumerator Setup()
		{
			//0x1ED618C
			SetText();
			SetCallbackToggleButton(0, (int value) =>
			{
				//0x1ED600C
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.SetNotesTypeValue(value);
			});
			SetCallbackToggleButton(1, (int value) =>
			{
				//0x1ED6098
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.SetNotesColorValue(value);
				string s = (value + 1).ToString("D2");
				m_notesColorTbl.StartChildrenAnimGoStop(s, s);
			});
			Loaded();
			yield break;
		}

		// RVA: 0x1ED5D04 Offset: 0x1ED5D04 VA: 0x1ED5D04 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_notesColorTbl = layout.FindViewByExId("sw_rhythm_set_10_swtbl_con_type") as AbsoluteLayout;
			m_texUvList = uvMan.GetTexUVList("cmn_config_packtex");
			this.StartCoroutineWatched(Setup());
			return true;
		}
	}
}
