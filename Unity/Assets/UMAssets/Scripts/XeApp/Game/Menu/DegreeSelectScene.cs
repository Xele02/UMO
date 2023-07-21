using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class DegreeSelectScene : TransitionRoot
	{
		private Action mUpdater; // 0x48
		private DegreeSelectLayout m_layout; // 0x4C

		// RVA: 0x17CE7A4 Offset: 0x17CE7A4 VA: 0x17CE7A4 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			m_layout = transform.GetComponent<DegreeSelectLayout>();
		}

		// RVA: 0x17CE838 Offset: 0x17CE838 VA: 0x17CE838 Slot: 5
		protected override void Start()
		{
			mUpdater = UpdateLoad;
		}

		// RVA: 0x17CE8C0 Offset: 0x17CE8C0 VA: 0x17CE8C0
		private void Update()
		{
			if (mUpdater != null)
				mUpdater();
		}

		// RVA: 0x17CE8D4 Offset: 0x17CE8D4 VA: 0x17CE8D4
		private void UpdateLoad()
		{
			if (!m_layout.IsLoaded())
				return;
			IsReady = true;
			mUpdater = UpdateIdle;
		}

		// RVA: 0x17CE994 Offset: 0x17CE994 VA: 0x17CE994
		private void UpdateIdle()
		{
			return;
		}

		// RVA: 0x17CE998 Offset: 0x17CE998 VA: 0x17CE998 Slot: 12
		protected override void OnStartExitAnimation()
		{
			base.OnStartExitAnimation();
			m_layout.Leave();
		}

		// RVA: 0x17CE9D0 Offset: 0x17CE9D0 VA: 0x17CE9D0 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_layout.IsPlaying();
		}

		// RVA: 0x17CEA00 Offset: 0x17CEA00 VA: 0x17CEA00 Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_layout.Init(false);
			m_layout.SetCurrentWindowTitle(bk.GetMessageByLabel("degree_current_window_title"));
			m_layout.SetSelectWindowTitle(bk.GetMessageByLabel("degree_select_window_title"));
		}

		// RVA: 0x17CEB6C Offset: 0x17CEB6C VA: 0x17CEB6C Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			if(!KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
			{
				m_layout.Enter();
				return true;
			}
			return false;
		}
	}
}
