using System;

public abstract class CriDisposable : IDisposable
{
	public Guid guid; // 0x8

	// RVA: 0x2897D18 Offset: 0x2897D18 VA: 0x2897D18
	// public void .ctor() { }

	// RVA: -1 Offset: -1 Slot: 5
	public /*abstract*/virtual void Dispose() {} // TODO remove dispose when all implemented
}
