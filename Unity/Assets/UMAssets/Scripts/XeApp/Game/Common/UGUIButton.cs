using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	[RequireComponent(typeof(Button))]
	[RequireComponent(typeof(Animator))]
	public class UGUIButton : ButtonBase
	{
		protected enum TransitionState
		{
			None = 0,
			Normal = 1,
			Enter = 2,
			Decide = 3,
			Disable = 4,
			Hidden = 5,
		}

		protected static string m_animeStateNameWait = "Wait"; // 0x0
		protected static string m_animeStateNameOn = "On"; // 0x4
		protected static string m_animeStateNameOff = "Off"; // 0x8
		protected static string m_animeStateNameDecide = "Decide"; // 0xC
		protected static string m_animeStateNameImp = "Imp"; // 0x10
		protected static string m_animeStateNameNon = "Non"; // 0x14
		[SerializeField]
		protected Animator m_animator; // 0x30
		protected UGUIButton.TransitionState m_transitionState; // 0x34

		// public Animator animator { get; }0x1CD0CC4

		// RVA: 0x1CD0CCC Offset: 0x1CD0CCC VA: 0x1CD0CCC Slot: 28
		protected virtual void Awake()
		{
			return;
		}

		// RVA: 0x1CD0CD0 Offset: 0x1CD0CD0 VA: 0x1CD0CD0 Slot: 11
		protected override void Start()
		{
			base.Start();
		}

		// RVA: 0x1CD0CD8 Offset: 0x1CD0CD8 VA: 0x1CD0CD8 Slot: 29
		protected virtual void OnEnable()
		{
			UnityEngine.Debug.LogError("TODO UGUIButton OnEnable");
		}

		// RVA: 0x1CD0EE8 Offset: 0x1CD0EE8 VA: 0x1CD0EE8 Slot: 12
		protected override void OnDisable()
		{
			return;
		}

		// RVA: 0x1CD0EEC Offset: 0x1CD0EEC VA: 0x1CD0EEC Slot: 15
		public override void OnPointerClick(PointerEventData eventData)
		{
			base.OnPointerClick(eventData);
		}

		// RVA: 0x1CD0EF4 Offset: 0x1CD0EF4 VA: 0x1CD0EF4 Slot: 16
		public override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
		}

		// RVA: 0x1CD0EFC Offset: 0x1CD0EFC VA: 0x1CD0EFC Slot: 17
		public override void OnPointerExit(PointerEventData eventData)
		{
			base.OnPointerExit(eventData);
		}

		// RVA: 0x1CD0F04 Offset: 0x1CD0F04 VA: 0x1CD0F04 Slot: 18
		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
		}

		// RVA: 0x1CD0F0C Offset: 0x1CD0F0C VA: 0x1CD0F0C Slot: 19
		public override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);
		}

		// // RVA: 0x1CD0F14 Offset: 0x1CD0F14 VA: 0x1CD0F14 Slot: 27
		// public override bool IsPlaying() { }

		// // RVA: 0x1CD112C Offset: 0x1CD112C VA: 0x1CD112C Slot: 20
		// public override void SetOn() { }

		// RVA: 0x1CD1210 Offset: 0x1CD1210 VA: 0x1CD1210 Slot: 21
		public override void SetOff()
		{
			UnityEngine.Debug.LogError("TODO UGUIButton SetOff");
		}

		// // RVA: 0x1CD12E8 Offset: 0x1CD12E8 VA: 0x1CD12E8 Slot: 24
		// protected override void PlayEnter() { }

		// // RVA: 0x1CD13B4 Offset: 0x1CD13B4 VA: 0x1CD13B4 Slot: 23
		// protected override void PlayNormal() { }

		// // RVA: 0x1CD14C4 Offset: 0x1CD14C4 VA: 0x1CD14C4 Slot: 22
		// protected override void PlayDecide() { }

		// // RVA: 0x1CD1590 Offset: 0x1CD1590 VA: 0x1CD1590 Slot: 25
		// protected override void PlayDisable() { }

		// // RVA: 0x1CD165C Offset: 0x1CD165C VA: 0x1CD165C Slot: 26
		// protected override void PlayHidden() { }
	}
}
