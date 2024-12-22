namespace CriWare
{

	public class CriAtomExSoundObject : CriDisposable
	{

		// private IntPtr handle; // 0x18

		// public IntPtr nativeHandle { get; }

		// // RVA: 0x28AC4A4 Offset: 0x28AC4A4 VA: 0x28AC4A4
		// public IntPtr get_nativeHandle() { }

		// // RVA: 0x28AC4AC Offset: 0x28AC4AC VA: 0x28AC4AC
		public CriAtomExSoundObject(bool enableVoiceLimitScope, bool enableCategoryCueLimitScope)
		{
			TodoLogger.LogError(TodoLogger.CriAtomExLib, "TODO");
		}

		// // RVA: 0x28AC71C Offset: 0x28AC71C VA: 0x28AC71C Slot: 5
		public override void Dispose()
		{
			TodoLogger.LogError(TodoLogger.CriAtomExLib, "TODO");
		}

		// // RVA: 0x28AC8E0 Offset: 0x28AC8E0 VA: 0x28AC8E0
		// public void AddPlayer(CriAtomExPlayer player) { }

		// // RVA: 0x28AC9F8 Offset: 0x28AC9F8 VA: 0x28AC9F8
		// public void DeletePlayer(CriAtomExPlayer player) { }

		// // RVA: 0x28ACB14 Offset: 0x28ACB14 VA: 0x28ACB14
		// public void DeleteAllPlayers() { }

		// // RVA: 0x28ACC08 Offset: 0x28ACC08 VA: 0x28ACC08 Slot: 1
		// protected override void Finalize() { }

		// // RVA: 0x28AC600 Offset: 0x28AC600 VA: 0x28AC600
		// private static extern IntPtr criAtomExSoundObject_Create(ref CriAtomExSoundObject.Config config, IntPtr work, int work_size) { }

		// // RVA: 0x28AC800 Offset: 0x28AC800 VA: 0x28AC800
		// private static extern void criAtomExSoundObject_Destroy(IntPtr soundObject) { }

		// // RVA: 0x28AC910 Offset: 0x28AC910 VA: 0x28AC910
		// private static extern void criAtomExSoundObject_AddPlayer(IntPtr soundObject, IntPtr player) { }

		// // RVA: 0x28ACA28 Offset: 0x28ACA28 VA: 0x28ACA28
		// private static extern void criAtomExSoundObject_DeletePlayer(IntPtr soundObject, IntPtr player) { }

		// // RVA: 0x28ACB20 Offset: 0x28ACB20 VA: 0x28ACB20
		// private static extern void criAtomExSoundObject_DeleteAllPlayers(IntPtr soundObject) { }
	}
}
