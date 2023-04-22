using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using XeSys;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class ComparisonNotesBase : LayoutUGUIScriptBase
	{
		[SerializeField]
		protected LayoutUGUIRuntime m_runtime; // 0x14
		[SerializeField]
		protected Text m_notesValue; // 0x18
		[SerializeField]
		private RawImageEx m_noteIcon; // 0x1C
		[SerializeField]
		private RawImageEx m_noteName; // 0x20
		[SerializeField]
		private string m_symbolName; // 0x24
		protected StringBuilder m_strBuilder = new StringBuilder(); // 0x28
		protected AbsoluteLayout m_rootLayout; // 0x2C
		protected TexUVListManager m_uvMan; // 0x30
		private static readonly string[] m_nortsUvNameTable = new string[6] {
			"", "cmn_status_note_01", "cmn_status_note_03", "cmn_status_note_02", 
			"cmn_status_note_04", "cmn_status_note_05"
		}; // 0x0
		private static readonly string[] m_nortsEffectUvNameTable = new string[6] {
			"", "sel_card_status_fnt_09", "sel_card_status_fnt_11", 
			"sel_card_status_fnt_10", "sel_card_status_fnt_08", 
			"sel_card_status_fnt_12"
		}; // 0x4

		// RVA: 0x1B4F61C Offset: 0x1B4F61C VA: 0x1B4F61C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_strBuilder.Set(name);
			m_strBuilder.Replace(" (AbsoluteLayout)", "");
			m_strBuilder.Insert(0, "_");
			m_strBuilder.Insert(0, m_symbolName);
			RectTransform rt = transform as RectTransform;
			AbsoluteLayout root = m_runtime.FindViewBase(rt) as AbsoluteLayout;
			m_rootLayout = root.FindViewByExId(m_strBuilder.ToString()) as AbsoluteLayout;
			m_uvMan = uvMan;
			ClearLoadedCallback();
			return true;
		}

		// // RVA: 0x1B4F87C Offset: 0x1B4F87C VA: 0x1B4F87C
		public void SetNotesValue(int value)
		{
			m_notesValue.text = value.ToString();
			m_notesValue.enabled = true;
			m_rootLayout.StartChildrenAnimGoStop("01");
		}

		// // RVA: 0x1B4F964 Offset: 0x1B4F964 VA: 0x1B4F964 Slot: 6
		public virtual void SetNotesInvalid()
		{
			m_notesValue.text = "";
			m_rootLayout.StartChildrenAnimGoStop("02");
		}

		// // RVA: 0x1B4FA18 Offset: 0x1B4FA18 VA: 0x1B4FA18
		public void SetNotesIcon(SpecialNoteAttribute.Type type)
		{
			m_noteIcon.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(m_nortsUvNameTable[(int)type]));
			m_noteName.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(m_nortsEffectUvNameTable[(int)type]));
		}
	}
}
