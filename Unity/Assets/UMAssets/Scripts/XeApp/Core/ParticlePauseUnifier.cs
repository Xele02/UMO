namespace XeApp.Core
{
	public class ParticlePauseUnifier : PauseUnifierBase
	{
		// private List<ParticlePauseUnifier.Data> m_elements = new List<ParticlePauseUnifier.Data>(); // 0x10


		// // RVA: 0x1D74284 Offset: 0x1D74284 VA: 0x1D74284 Slot: 9
		// public override void Register(GameObject root) { }

		// // RVA: 0x1D743C8 Offset: 0x1D743C8 VA: 0x1D743C8 Slot: 10
		// public override void UnregisterAll() { }

		// RVA: 0x1D74440 Offset: 0x1D74440 VA: 0x1D74440 Slot: 11
		protected override void InternalPause()
		{
			TodoLogger.Log(0, "TODO");
		}

		// RVA: 0x1D7456C Offset: 0x1D7456C VA: 0x1D7456C Slot: 12
		protected override void InternalResume()
		{
			TodoLogger.Log(0, "TODO");
		}
	}
}
