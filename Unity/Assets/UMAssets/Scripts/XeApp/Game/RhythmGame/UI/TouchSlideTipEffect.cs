using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class TouchSlideTipEffect : MonoBehaviour
	{
		private Animator m_animator; // 0xC
		private static readonly int InStateHash = Animator.StringToHash("SlideNotes_touch_IN"); // 0x0
		private static readonly int OutStateHash = Animator.StringToHash("SlideNotes_touch_OFF"); // 0x4

		public RNoteSlide noteSlide { get; set; } // 0x10

		//// RVA: 0x1567640 Offset: 0x1567640 VA: 0x1567640
		private void Awake()
		{
			m_animator = GetComponent<Animator>();
		}

		//// RVA: 0x1564A78 Offset: 0x1564A78 VA: 0x1564A78
		public void Initialize()
		{
			m_animator.Play(OutStateHash, -1, 1.0f);
			for(int i = 0; i < transform.childCount; i++)
			{
				Transform t = transform.GetChild(i);
				if (t.name == "fx_rhythm_light_L" || t.name == "SlideNotes_touch_model02")
				{
					t.GetComponent<MeshRenderer>().enabled = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.MJHEPGIEDDL_IsSlideNoteEffect;
				}
			}
		}

		//// RVA: 0x15676A8 Offset: 0x15676A8 VA: 0x15676A8
		//public void Show(RNoteSlide ns) { }

		//// RVA: 0x15677E0 Offset: 0x15677E0 VA: 0x15677E0
		//public void Hide() { }

		//// RVA: 0x1567918 Offset: 0x1567918 VA: 0x1567918
		public void SetPosition(Vector3 pos)
		{
			transform.position = pos;
		}
	}
}
