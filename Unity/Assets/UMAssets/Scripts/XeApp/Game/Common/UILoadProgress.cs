using XeSys.Gfx;
using UnityEngine;
using System;

namespace XeApp.Game.Common
{
	public class UILoadProgress : LayoutUGUIScriptBase
	{
		public enum Type
		{
			Normal = 0,
			Event = 1,
		}

		private AbsoluteLayout m_layoutType; // 0x14
		private AbsoluteLayout[] m_layoutBar = new AbsoluteLayout[2]; // 0x18
		private const float DELAY_VALUE = 0.7f;
		private float m_ratio; // 0x1C
		[SerializeField] // RVA: 0x687930 Offset: 0x687930 VA: 0x687930
		private int m_per; // 0x20
		private UILoadProgress.Type m_type; // 0x24
		private Action m_updater; // 0x28
		private Transform m_parent; // 0x2C
		private WaitForEndOfFrame m_frameYilder = new WaitForEndOfFrame(); // 0x30
		private bool m_isReady; // 0x34
		private Transform m_oldParent; // 0x38

		public bool IsReady { get { return m_isReady; } } //0x1CDDEB8

		// // RVA: 0x1CDDEC0 Offset: 0x1CDDEC0 VA: 0x1CDDEC0
		private void Start()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x1CDDEC4 Offset: 0x1CDDEC4 VA: 0x1CDDEC4
		private void Update()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x1CDDED8 Offset: 0x1CDDED8 VA: 0x1CDDED8
		// private void UpdateIdle() { }

		// // RVA: 0x1CDDFA4 Offset: 0x1CDDFA4 VA: 0x1CDDFA4
		public void Begin(Transform parent)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x1CDE13C Offset: 0x1CDE13C VA: 0x1CDE13C
		public void End()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x1CDE1B8 Offset: 0x1CDE1B8 VA: 0x1CDE1B8
		public void SetType(UILoadProgress.Type type)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x1CDE270 Offset: 0x1CDE270 VA: 0x1CDE270
		public void SetPer(int per)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x1CDDEE0 Offset: 0x1CDDEE0 VA: 0x1CDDEE0
		// private void ChangeProgress(int per) { }

		// [IteratorStateMachineAttribute] // RVA: 0x7398AC Offset: 0x7398AC VA: 0x7398AC
		// // RVA: 0x1CDE0B0 Offset: 0x1CDE0B0 VA: 0x1CDE0B0
		// private IEnumerator WaitOneFrameCoroutine() { }

		// // RVA: 0x1CDE298 Offset: 0x1CDE298 VA: 0x1CDE298 Slot: 5
		// public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan) { }
	}
}
