namespace XeApp.Core
{
	public abstract class PauseUnifierBase : PausableBehaviour
	{
		private bool m_pauseByInterface; // 0xC
		private bool m_internalPause; // 0xD

		// // RVA: -1 Offset: -1 Slot: 9
		// public abstract void Register(GameObject root);

		// // RVA: -1 Offset: -1 Slot: 10
		// public abstract void UnregisterAll();

		// // RVA: 0x1D7489C Offset: 0x1D7489C VA: 0x1D7489C
		// public void Pause() { }

		// // RVA: 0x1D748A8 Offset: 0x1D748A8 VA: 0x1D748A8
		// public void Resume() { }

		// // RVA: -1 Offset: -1 Slot: 11
		protected abstract void InternalPause();

		// // RVA: -1 Offset: -1 Slot: 12
		protected abstract void InternalResume();

		// RVA: 0x1D748B4 Offset: 0x1D748B4 VA: 0x1D748B4 Slot: 4
		protected override bool IsPause()
		{
			return m_pauseByInterface;
		}

		// RVA: 0x1D748BC Offset: 0x1D748BC VA: 0x1D748BC Slot: 5
		protected override void PausableAwake()
		{
			return;
		}

		// RVA: 0x1D748C0 Offset: 0x1D748C0 VA: 0x1D748C0 Slot: 6
		protected override void PausableStart()
		{
			return;
		}

		// RVA: 0x1D748C4 Offset: 0x1D748C4 VA: 0x1D748C4 Slot: 7
		protected override void PausableUpdate()
		{
			if(!m_internalPause)
				return;
			m_internalPause = false;
			InternalResume();
		}

		// RVA: 0x1D748E8 Offset: 0x1D748E8 VA: 0x1D748E8 Slot: 8
		protected override void PausableInPause()
		{
			if(m_internalPause)
				return;
			m_internalPause = true;
			InternalPause();
		}
	}
}
