using System;

namespace XeApp.Core
{
	public abstract class PoolObject : PausableBehaviour, IDisposable
	{
		public bool use { get; protected set; } // 0xC
		public int poolIndex { get; set; } // 0x10

		// RVA: 0x1D7492C Offset: 0x1D7492C VA: 0x1D7492C Slot: 10
		public virtual void Alloc()
		{
			use = true;
		}

		// // RVA: 0x1D74938 Offset: 0x1D74938 VA: 0x1D74938 Slot: 11
		// public virtual void Free() { }

		// // RVA: 0x1D74944 Offset: 0x1D74944 VA: 0x1D74944 Slot: 12
		public virtual void Create()
		{
			return;
		}

		// RVA: 0x1D74948 Offset: 0x1D74948 VA: 0x1D74948 Slot: 13
		public virtual void Dispose()
		{
			Destroy(gameObject);
		}
	}
}
