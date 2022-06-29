using XeSys.Gfx;
using System.Collections;

namespace XeApp.Game.Common
{
	public class UILoadWait : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_anim; // 0x14
		private LayoutUGUIRuntime m_runtime; // 0x18

		public bool IsInitialized { get { return m_runtime.IsReady; } }// 0x1CDE8D8

		// // RVA: 0x1CDE904 Offset: 0x1CDE904 VA: 0x1CDE904
		private void Start()
		{
			m_runtime = GetComponent<LayoutUGUIRuntime>();
		}

		// // RVA: 0x1CDE96C Offset: 0x1CDE96C VA: 0x1CDE96C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_anim = layout.FindViewByExId("root_cmn_load_now_sw_cmn_load_now_anim") as AbsoluteLayout;
			Loaded();
			StartCoroutine(WaitLayoutUGUICoroutine());
			return true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x739974 Offset: 0x739974 VA: 0x739974
		// // RVA: 0x1CDEA5C Offset: 0x1CDEA5C VA: 0x1CDEA5C
		private IEnumerator WaitLayoutUGUICoroutine()
		{
			//0x1CDEC3C
			while(!m_runtime.IsReady)
			{
				yield return null;
			}
			gameObject.SetActive(false);
		}

		// // RVA: 0x1CDEB08 Offset: 0x1CDEB08 VA: 0x1CDEB08
		public void Show()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x1CDEBF8 Offset: 0x1CDEBF8 VA: 0x1CDEBF8
		public void Hide()
		{
			UnityEngine.Debug.LogError("TODO");
		}
	}
}
