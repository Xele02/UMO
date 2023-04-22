using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class ComparisonNotesInfo : LayoutUGUIScriptBase
	{
		[SerializeField]
		private LayoutUGUIRuntime m_runtime; // 0x14
		[SerializeField]
		protected Text m_notesValue; // 0x18
		[SerializeField]
		private RawImageEx m_noteIcon; // 0x1C
		[SerializeField]
		private RawImageEx m_noteName; // 0x20
		protected AbsoluteLayout m_styleLayout; // 0x24
		protected TexUVListManager m_uvMan; // 0x28
		private static readonly string[] m_nortsUvNameTable = new string[6] { "", "cmn_status_note_01",
		"cmn_status_note_03", "cmn_status_note_02", "cmn_status_note_04", "cmn_status_note_05"}; // 0x0
		private static readonly string[] m_nortsEffectUvNameTable = new string[6] {
			"", "sel_card_status_fnt_09", "sel_card_status_fnt_11", "sel_card_status_fnt_10",
			"sel_card_status_fnt_08", "sel_card_status_fnt_12"
		}; // 0x4

		// RVA: 0x1B50288 Offset: 0x1B50288 VA: 0x1B50288 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvMan = uvMan;
			ClearLoadedCallback();
			return true;
		}

		//// RVA: 0x1B50348 Offset: 0x1B50348 VA: 0x1B50348
		public void SetNotesValue(int value)
		{
			m_notesValue.text = value.ToString();
			m_notesValue.enabled = true;
		}

		//// RVA: 0x1B503C4 Offset: 0x1B503C4 VA: 0x1B503C4 Slot: 6
		//public virtual void SetNotesInvalid() { }

		//// RVA: 0x1B50448 Offset: 0x1B50448 VA: 0x1B50448
		public void SetNotesIcon(SpecialNoteAttribute.Type type)
		{
			m_noteIcon.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(m_nortsUvNameTable[(int)type]));
			m_noteName.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(m_nortsEffectUvNameTable[(int)type]));
		}
	}
}
