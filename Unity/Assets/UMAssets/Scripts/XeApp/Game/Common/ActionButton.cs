using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using XeSys.Gfx;
using System.Text;

namespace XeApp.Game.Common
{
	public class ActionButton : ButtonBase
	{
		[SerializeField]
		protected string m_symbolName = String.Empty; // 0x30
		[SerializeField]
		protected string m_exId = String.Empty; // 0x34
		[SerializeField]
		protected string m_clickSeName = ""; // 0x38
		[SerializeField]
		protected bool m_childAnim; // 0x3C
		[SerializeField]
		protected string m_parentExId = String.Empty; // 0x40
		[SerializeField]
		protected bool m_isRelativeSearch; // 0x44
		protected AbsoluteLayout m_abs; // 0x48
		protected string m_normalLabel = "st_wait"; // 0x4C
		protected string m_onPointerStartLabel = "go_bot_on"; // 0x50
		protected string m_onPointerEndLabel = "st_bot_on"; // 0x54
		protected string m_onPointerExitLabel = "go_bot_off"; // 0x58
		protected string m_decideStartLabel = "go_bot_decide"; // 0x5C
		protected string m_decideEndLabel = "st_bot_decide"; // 0x60
		protected string m_disableLabel = "st_bot_imp"; // 0x64
		protected string m_hiddenLabel = "st_non"; // 0x68
		// protected Queue<string> m_playRequestAnim = new Queue<string>(); // 0x6C
		private string m_playingAnimLabel = "st_wait"; // 0x70
		private List<IEnumerator> m_coroutineList = new List<IEnumerator>(); // 0x74
		protected Action m_animEndCallBack; // 0x78
		// private ActionButton.TransitionState m_transitionState; // 0x7C

		// Properties
		public AbsoluteLayout RootAbsoluteLayout { get { return m_abs; } } //0xE5D330

		// // RVA: 0xE5D338 Offset: 0xE5D338 VA: 0xE5D338 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			if(!m_isRelativeSearch)
			{
				StringBuilder str = new StringBuilder(m_symbolName);
				str.Append("_");
				str.Append(name.Replace(" (AbsoluteLayout)", ""));
				if(string.IsNullOrEmpty(m_parentExId))
				{
					m_abs = layout.FindViewByExId(str.ToString()) as AbsoluteLayout;
				}
				else
				{
					m_abs = (layout.FindViewByExId(m_parentExId) as AbsoluteLayout).FindViewByExId(str.ToString()) as AbsoluteLayout;
				}
			}
			else
			{
				m_abs = GetComponentInParent<LayoutUGUIRuntime>().FindViewBase(transform as RectTransform) as AbsoluteLayout;
			}
			if(!string.IsNullOrEmpty(m_exId))
			{
				m_abs = m_abs.FindViewByExId(m_exId) as AbsoluteLayout;
			}
			if(m_childAnim)
			{
				for(int i = 0; i < m_abs.viewCount; i++)
				{
					if(m_abs[i] != null)
					{
						if(m_abs[i] is AbsoluteLayout)
						{
							m_abs = m_abs[i] as AbsoluteLayout;
							break;
						}
					}
				}
			}
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}

		// RVA: 0xE5D880 Offset: 0xE5D880 VA: 0xE5D880 Slot: 28
		protected virtual void Awake()
		{
			return;
		}

		// RVA: 0xE5D884 Offset: 0xE5D884 VA: 0xE5D884 Slot: 11
		protected override void Start()
		{
			base.Start();
			m_animEndCallBack = () => {
				//0xE5F314
				return;
			};
		}

		// RVA: 0xE5DBBC Offset: 0xE5DBBC VA: 0xE5DBBC Slot: 12
		protected override void OnDisable()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// RVA: 0xE5DDD0 Offset: 0xE5DDD0 VA: 0xE5DDD0 Slot: 15
		public override void OnPointerClick(PointerEventData eventData)
		{
			base.OnPointerClick(eventData);
		}

		// RVA: 0xE5DE78 Offset: 0xE5DE78 VA: 0xE5DE78 Slot: 16
		public override void OnPointerEnter(PointerEventData eventData)
		{
			UnityEngine.Debug.LogWarning("TODO OnPointerEnter");
		}

		// RVA: 0xE5DF08 Offset: 0xE5DF08 VA: 0xE5DF08 Slot: 17
		public override void OnPointerExit(PointerEventData eventData)
		{
			UnityEngine.Debug.LogWarning("TODO OnPointerExit");
		}

		// RVA: 0xE5DF8C Offset: 0xE5DF8C VA: 0xE5DF8C Slot: 18
		public override void OnPointerDown(PointerEventData eventData)
		{
			UnityEngine.Debug.LogWarning("TODO OnPointerDown");
		}

		// RVA: 0xE5E040 Offset: 0xE5E040 VA: 0xE5E040 Slot: 19
		public override void OnPointerUp(PointerEventData eventData)
		{
			UnityEngine.Debug.LogWarning("TODO OnPointerUp");
		}

		// // RVA: 0xE5E0D8 Offset: 0xE5E0D8 VA: 0xE5E0D8 Slot: 27
		// public override bool IsPlaying() { }

		// // RVA: 0xE5E378 Offset: 0xE5E378 VA: 0xE5E378 Slot: 20
		public override void SetOn()
		{
			UnityEngine.Debug.LogError("TODO Button SetOn");
		}

		// // RVA: 0xE5E484 Offset: 0xE5E484 VA: 0xE5E484 Slot: 21
		public override void SetOff()
		{
			UnityEngine.Debug.LogError("TODO Button SetOff");
		}

		// // RVA: 0xE5E5A4 Offset: 0xE5E5A4 VA: 0xE5E5A4 Slot: 24
		// protected override void PlayEnter() { }

		// // RVA: 0xE5E880 Offset: 0xE5E880 VA: 0xE5E880 Slot: 23
		// protected override void PlayNormal() { }

		// // RVA: 0xE5EA44 Offset: 0xE5EA44 VA: 0xE5EA44 Slot: 22
		// protected override void PlayDecide() { }

		// // RVA: 0xE5EBBC Offset: 0xE5EBBC VA: 0xE5EBBC Slot: 25
		// protected override void PlayDisable() { }

		// // RVA: 0xE5ECA0 Offset: 0xE5ECA0 VA: 0xE5ECA0 Slot: 26
		// protected override void PlayHidden() { }

		// // RVA: 0xE5E6B8 Offset: 0xE5E6B8 VA: 0xE5E6B8
		// private void StartAnime() { }

		// // RVA: 0xE5DCE8 Offset: 0xE5DCE8 VA: 0xE5DCE8
		// private void StopAnime() { }

		// [IteratorStateMachineAttribute] // RVA: 0x73CDB8 Offset: 0x73CDB8 VA: 0x73CDB8
		// // RVA: 0xE5ED84 Offset: 0xE5ED84 VA: 0xE5ED84
		// private IEnumerator StartAnimeCoroutine() { }

		// [IteratorStateMachineAttribute] // RVA: 0x73CE30 Offset: 0x73CE30 VA: 0x73CE30
		// // RVA: 0xE5EE30 Offset: 0xE5EE30 VA: 0xE5EE30
		// private IEnumerator StartChildAnimeCoroutine() { }

		// // RVA: 0xE5E1BC Offset: 0xE5E1BC VA: 0xE5E1BC
		// private bool IsPlaying(AbsoluteLayout abs) { }
	}
}
