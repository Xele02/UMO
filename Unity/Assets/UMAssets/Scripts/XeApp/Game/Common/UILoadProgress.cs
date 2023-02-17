using XeSys.Gfx;
using UnityEngine;
using System;
using System.Collections;

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
			return;
		}

		// // RVA: 0x1CDDEC4 Offset: 0x1CDDEC4 VA: 0x1CDDEC4
		private void Update()
		{
			if(m_updater != null)
				m_updater();
		}

		// // RVA: 0x1CDDED8 Offset: 0x1CDDED8 VA: 0x1CDDED8
		private void UpdateIdle()
		{
			ChangeProgress(m_per);
		}

		// // RVA: 0x1CDDFA4 Offset: 0x1CDDFA4 VA: 0x1CDDFA4
		public void Begin(Transform parent)
		{
			if(!gameObject.activeSelf)
			{
				gameObject.SetActive(true);
			}
			m_ratio = 0;
			m_per = 0;
			ChangeProgress(0);
			m_isReady = false;
			m_oldParent = transform.parent;
			transform.SetParent(parent, false);
			StartCoroutine(WaitOneFrameCoroutine());
		}

		// // RVA: 0x1CDE13C Offset: 0x1CDE13C VA: 0x1CDE13C
		public void End()
		{
			gameObject.SetActive(false);
			transform.SetParent(m_oldParent, false);
			m_oldParent = null;
		}

		// // RVA: 0x1CDE1B8 Offset: 0x1CDE1B8 VA: 0x1CDE1B8
		public void SetType(Type type)
		{
			m_type = type;
			if(type == Type.Event)
			{
				m_layoutType.StartChildrenAnimGoStop("02");
			}
			else if(type == Type.Normal)
			{
				m_layoutType.StartChildrenAnimGoStop("01");
			}
		}

		// // RVA: 0x1CDE270 Offset: 0x1CDE270 VA: 0x1CDE270
		public void SetPer(int per)
		{
			m_per = per;
		}

		// // RVA: 0x1CDDEE0 Offset: 0x1CDDEE0 VA: 0x1CDDEE0
		private void ChangeProgress(int per)
		{
			float ratio = 0;
			float p = 0;
			if (per < 100)
			{
				ratio = m_ratio;
				p = per;
			}
			else
			{
				ratio = 100;
				m_ratio = 100;
				p = 100;
			}
			m_ratio = ratio + (per - ratio) * 0.7f;
			int f = Mathf.RoundToInt(m_ratio);
			m_layoutBar[(int)m_type].StartChildrenAnimGoStop(f, f);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7398AC Offset: 0x7398AC VA: 0x7398AC
		// // RVA: 0x1CDE0B0 Offset: 0x1CDE0B0 VA: 0x1CDE0B0
		private IEnumerator WaitOneFrameCoroutine()
		{
			//0x1CDE684
			if(m_parent == null)
			{
				m_parent = transform.parent;
			}
			transform.SetParent(null, false);
			yield return m_frameYilder;
			transform.SetParent(m_parent, false);
			m_isReady = true;
		}

		// // RVA: 0x1CDE298 Offset: 0x1CDE298 VA: 0x1CDE298 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutType = layout.FindViewById("sw_cmn_load_progress_all") as AbsoluteLayout;
			m_layoutBar[0] = layout.FindViewById("swfrm_mask_bar_01_anim") as AbsoluteLayout;
			m_layoutBar[1] = layout.FindViewById("swfrm_mask_bar_03_anim") as AbsoluteLayout;
			m_updater = this.UpdateIdle;
			gameObject.SetActive(false);
			return true;
		}
	}
}
