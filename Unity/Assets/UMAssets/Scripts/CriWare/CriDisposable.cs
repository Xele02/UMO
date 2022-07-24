using System;

namespace CriWare
{
	public abstract class CriDisposable : IDisposable
	{
		public Guid guid; // 0x8

		// RVA: 0x2897D18 Offset: 0x2897D18 VA: 0x2897D18
		public CriDisposable()
		{
			guid = new Guid();
		}

		// RVA: -1 Offset: -1 Slot: 5
		public abstract void Dispose();
	}
}