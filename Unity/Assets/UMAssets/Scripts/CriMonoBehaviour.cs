using UnityEngine;
using System;

public abstract class CriMonoBehaviour : MonoBehaviour
{
	public Guid guid { get; set; } // 0xC

	// RVA: 0x294CA84 Offset: 0x294CA84 VA: 0x294CA84
	public CriMonoBehaviour()
    {
        guid = Guid.NewGuid();
    }

	// RVA: 0x296126C Offset: 0x296126C VA: 0x296126C Slot: 4
	protected virtual void OnEnable()
    {
        CriMonoBehaviourManager.instance.Register(this);
    }

	// RVA: 0x2963A74 Offset: 0x2963A74 VA: 0x2963A74 Slot: 5
	protected virtual void OnDisable()
    {
        CriMonoBehaviourManager.UnRegister(this);
    }

	// // RVA: -1 Offset: -1 Slot: 6
	public virtual/*abstract */void CriInternalUpdate() {} // TODO remake abstract once all implemented

	// // RVA: -1 Offset: -1 Slot: 7
	public virtual/*abstract */void CriInternalLateUpdate() {} // TODO remake abstract once all implemented
}
