
using System;
using System.Runtime.InteropServices;
using smartar;
using UnityEngine;
using XeApp.Game.AR;

public abstract class TargetEffectorBase : MonoBehaviour
{
	public string targetID; // 0xC
	[HideInInspector]
	public RecognitionResult result_; // 0x10
	[SerializeField]
	protected int m_LostPermissionCount; // 0x88
	protected IntPtr landmarkBuffer_ = IntPtr.Zero; // 0x8C
	protected IntPtr initPointBuffer_ = IntPtr.Zero; // 0x90
	protected IntPtr nodePointBuffer_ = IntPtr.Zero; // 0x94
	protected int m_LostCount = int.MinValue; // 0x98
	protected bool m_isShown; // 0x9C

	// RVA: 0x12FD6D0 Offset: 0x12FD6D0 VA: 0x12FD6D0 Slot: 4
	protected virtual void Awake() { }

	// RVA: 0x12FDA3C Offset: 0x12FDA3C VA: 0x12FDA3C Slot: 5
	protected virtual void Start() { }

	// RVA: 0x12FDB0C Offset: 0x12FDB0C VA: 0x12FDB0C Slot: 6
	protected virtual void Update()
    {
        if(!result_.isRecognized_)
        {
            if(m_LostCount == int.MinValue)
                return;
            m_LostCount++;
        }
        showOrHideChildrens(m_LostPermissionCount >= m_LostCount);
        if(m_isShown != (m_LostCount <= m_LostPermissionCount))
        {
            m_isShown = m_LostCount <= m_LostPermissionCount;
            if(VuforiaManager.Instance != null)
            {
                if(!m_isShown)
                {
                    VuforiaManager.Instance.CallbackTrackingLost(gameObject);
                }
                else
                {
                    VuforiaManager.Instance.CallbackTrackingFound(gameObject);
                }
            }
            ARObject[] ars = GetComponentsInChildren<ARObject>(true);
            for(int i = 0; i < ars.Length; i++)
            {
                ars[i].SetDiaplayMask(ARObjDispMask.TRACKING_LOST, m_LostCount <= m_LostPermissionCount);
            }
        }
    }

	// RVA: 0x12FDE34 Offset: 0x12FDE34 VA: 0x12FDE34
	private void OnDestroy()
    {
        if(landmarkBuffer_ == IntPtr.Zero)
            return;
        Marshal.FreeCoTaskMem(landmarkBuffer_);
        landmarkBuffer_ = IntPtr.Zero;
        Marshal.FreeCoTaskMem(initPointBuffer_);
        initPointBuffer_ = IntPtr.Zero;
        Marshal.FreeCoTaskMem(nodePointBuffer_);
        nodePointBuffer_ = IntPtr.Zero;
    }

	// RVA: 0x12FDEFC Offset: 0x12FDEFC VA: 0x12FDEFC
	private void OnValidate()
    {
        if(m_LostPermissionCount < 1)
            m_LostPermissionCount = 0;
    }

	// // RVA: 0x12FDF2C Offset: 0x12FDF2C VA: 0x12FDF2C Slot: 7
	protected virtual void showOrHideChildrens(bool enabled)
    {
        Renderer[] rs = GetComponentsInChildren<Renderer>();
        for(int i = 0; i < rs.Length; i++)
        {
            rs[i].enabled = enabled;
        }
    }
}
