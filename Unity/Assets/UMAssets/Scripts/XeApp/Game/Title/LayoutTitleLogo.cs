using XeSys.Gfx;
using System.Collections;
using System;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Title
{
	public class LayoutTitleLogo : LayoutUGUIScriptBase
	{
		private const float FADE_TIME = 0.3f;
		private AbsoluteLayout m_logoTbl; // 0x14
		private AbsoluteLayout m_root; // 0x18
		private int[] m_logoIndexArray = new int[1] { 2 }; // 0x1C
		private float[] m_skipWaitArray = new float[1] { 0.2f }; // 0x20
		private float[] m_waitArray = new float[1] { 2.0f }; // 0x24
		private int m_visibleIndex; // 0x28
		private Coroutine m_logoCoroutine; // 0x2C

		public bool IsOpen { get; private set; } // 0x30
		public bool IsClose { get; private set; } // 0x31
		public bool IsSkip { get; private set; } // 0x32

		// // RVA: 0xE39A60 Offset: 0xE39A60 VA: 0xE39A60
		public void SetStatus()
		{
			m_visibleIndex = 0;
			SwitchLogo(m_logoIndexArray[0]);
		}

		// // RVA: 0xE39B60 Offset: 0xE39B60 VA: 0xE39B60
		// public void Reset() { }

		// // RVA: 0xE39B64 Offset: 0xE39B64 VA: 0xE39B64
		public void Update()
		{
			Skip();
		}

		// // RVA: 0xE39AB4 Offset: 0xE39AB4 VA: 0xE39AB4
		public void SwitchLogo(int index)
		{
			if(m_logoTbl != null)
			{
				string startLabel = index.ToString("D2");
				m_logoTbl.StartAllAnimGoStop(startLabel, startLabel);
			}
		}

		// // RVA: 0xE39C3C Offset: 0xE39C3C VA: 0xE39C3C
		public void Show()
		{
			if(m_root == null)
			{
				IsClose = true;
				return;
			}
			gameObject.SetActive(true);
			m_root.StartAllAnimGoStop("st_in", "st_in");
			m_visibleIndex = 0;
			IsOpen = true;
			if(m_logoCoroutine != null)
			{
				StopCoroutine(m_logoCoroutine);
				m_logoCoroutine = null;
			}
			m_logoCoroutine = this.StartCoroutineWatched(UpdateLogo());
		}

		// // RVA: 0xE39DDC Offset: 0xE39DDC VA: 0xE39DDC
		public void Hide()
		{
			if(m_root == null)
				return;
			m_root.StartAllAnimGoStop("st_out", "st_out");
			gameObject.SetActive(false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B39F0 Offset: 0x6B39F0 VA: 0x6B39F0
		// // RVA: 0xE39D50 Offset: 0xE39D50 VA: 0xE39D50
		private IEnumerator UpdateLogo()
		{
			// private float <wait>5__2; // 0x14
			// private Color <scolor>5__3; // 0x18
			// private Color <ecolor>5__4; // 0x28
			//0xE3A160
			Color ecolor = Color.black;
			Color scolor = Color.black;
			while(m_visibleIndex < m_logoIndexArray.Length)
			{
				ecolor.a = 0.0f;
				scolor.a = 1.0f;
				float wait = 0.0f;
				GameManager.Instance.fullscreenFader.Fade(0.3f, scolor, ecolor);
				while(GameManager.Instance.fullscreenFader.isFading)
				{
					yield return null;
				}
				yield return null;
				IsSkip = false;
				while(wait < m_waitArray[m_visibleIndex] && !IsSkip)
				{
					IsSkip = false;
					wait += TimeWrapper.deltaTime;
				}

				wait = 0.0f;
				Color col = Color.black;
				if(m_visibleIndex + 1 < m_logoIndexArray.Length)
					col = Color.white;
				ecolor = col;
				scolor = col;
				scolor.a = 0.0f;
				GameManager.Instance.fullscreenFader.Fade(0.3f, scolor, ecolor);
				while(GameManager.Instance.fullscreenFader.isFading)
				{
					yield return null;
				}
				yield return null;
				m_visibleIndex = m_visibleIndex + 1;
				if(m_visibleIndex < m_logoIndexArray.Length)
				{
					SwitchLogo(m_logoIndexArray[m_visibleIndex]);
				}
				yield return null;
			}
			IsClose = true;
		}

		// // RVA: 0xE39B68 Offset: 0xE39B68 VA: 0xE39B68
		private void Skip()
		{
			if(InputManager.Instance.IsScreenTouch())
			{
				IsSkip = true;
			}
		}

		// // RVA: 0xE39EA0 Offset: 0xE39EA0 VA: 0xE39EA0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			m_logoTbl = layout.FindViewByExId("sw_start_logo_anim_swtbl_start_logo") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
