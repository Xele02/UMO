using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class TouchSlideEffect : MonoBehaviour
	{
		private Animator m_animator; // 0xC
		private static readonly int InStateHash = Animator.StringToHash("SlideNotes_IN"); // 0x0
		private static readonly int OutStateHash = Animator.StringToHash("SlideNotes_OFF"); // 0x4
		private static readonly int WingOpenRStateHash = Animator.StringToHash("WingNotes_Open_R"); // 0x8
		private static readonly int WingOpenLStateHash = Animator.StringToHash("WingNotes_Open_L"); // 0xC
		private static readonly int WingCloseRStateHash = Animator.StringToHash("WingNotes_Close_R"); // 0x10
		private static readonly int WingCloseLStateHash = Animator.StringToHash("WingNotes_Close_L"); // 0x14

		//// RVA: 0x1566EE0 Offset: 0x1566EE0 VA: 0x1566EE0
		private void Awake()
		{
			m_animator = GetComponent<Animator>();
		}

		//// RVA: 0x15649B0 Offset: 0x15649B0 VA: 0x15649B0
		//public void Initialize() { }

		//// RVA: 0x1566F48 Offset: 0x1566F48 VA: 0x1566F48
		//public void Show() { }

		//// RVA: 0x1567048 Offset: 0x1567048 VA: 0x1567048
		//public void Hide() { }

		//// RVA: 0x15670FC Offset: 0x15670FC VA: 0x15670FC
		//public void ShowWingOpenR() { }

		//// RVA: 0x15671FC Offset: 0x15671FC VA: 0x15671FC
		//public void ShowWingOpenL() { }

		//// RVA: 0x15672FC Offset: 0x15672FC VA: 0x15672FC
		//public void ShowWingCloseR() { }

		//// RVA: 0x15673FC Offset: 0x15673FC VA: 0x15673FC
		//public void ShowWingCloseL() { }
	}
}
