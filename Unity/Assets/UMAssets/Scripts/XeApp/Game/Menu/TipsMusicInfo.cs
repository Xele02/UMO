using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class TipsMusicInfo : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_titleText; // 0x14
		[SerializeField]
		private Text m_artistText; // 0x18
		[SerializeField]
		private RawImageEx m_attributeImage; // 0x1C
		[SerializeField]
		private RawImageEx m_logoImage; // 0x20
		[SerializeField]
		private RawImageEx m_jacketImage; // 0x24
		private AbsoluteLayout m_root; // 0x28
		private TexUVListManager m_uvManager; // 0x2C

		public bool IsShow { get; private set; } // 0x30

		// RVA: 0xA9B67C Offset: 0xA9B67C VA: 0xA9B67C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root;
			m_uvManager = uvMan;
			ClearLoadedCallback();
			return true;
		}

		//// RVA: 0xA9B73C Offset: 0xA9B73C VA: 0xA9B73C
		//public void SetContent(IBJAKJJICBC musicData) { }

		//// RVA: 0xA9BBC0 Offset: 0xA9BBC0 VA: 0xA9BBC0
		//public void Show() { }

		//// RVA: 0xA996E8 Offset: 0xA996E8 VA: 0xA996E8
		//public void Close() { }

		//[IteratorStateMachineAttribute] // RVA: 0x73577C Offset: 0x73577C VA: 0x73577C
		//// RVA: 0xA9BC84 Offset: 0xA9BC84 VA: 0xA9BC84
		//private IEnumerator CloseCoroutine() { }

		//// RVA: 0xA998F0 Offset: 0xA998F0 VA: 0xA998F0
		//public bool IsPlayingAnime() { }

		//[CompilerGeneratedAttribute] // RVA: 0x7357F4 Offset: 0x7357F4 VA: 0x7357F4
		//// RVA: 0xA9BD38 Offset: 0xA9BD38 VA: 0xA9BD38
		//private void <SetContent>b__12_0(IiconTexture texture) { }

		//[CompilerGeneratedAttribute] // RVA: 0x735804 Offset: 0x735804 VA: 0x735804
		//// RVA: 0xA9BE18 Offset: 0xA9BE18 VA: 0xA9BE18
		//private void <SetContent>b__12_1(IiconTexture texture) { }
	}
}
