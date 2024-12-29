using System;
using UnityEngine;
using UnityEngine.Events;

namespace UdonLib
{
	public class AndroidPermissionReceiver : MonoBehaviour
	{
		private const double ESTIMATE_NEVER_MS = 250;
		private const string PackageClassName = "jp.co.xeen.xeapp.PermissionManager";
		private const string ReceiverObjName = "UniAndroidPermission";
		private UnityEvent m_permitCallBack; // 0xC
		private UnityEvent m_notPermitCallBack; // 0x10
		private DateTime m_startTime; // 0x18
		private bool m_permissionResult; // 0x20
		private bool m_estimateNever; // 0x21
		private static AndroidPermissionReceiver m_instance; // 0x0

		public static AndroidPermissionReceiver Instance { get { return m_instance; } } //0xE086E4

		// RVA: 0xE08770 Offset: 0xE08770 VA: 0xE08770
		private void Awake()
		{
			m_instance = this;
		}

		// RVA: 0xE08800 Offset: 0xE08800 VA: 0xE08800
		public static void Create()
		{
			if(m_instance != null)
				return;
			GameObject g = new GameObject("UniAndroidPermission");
			g.AddComponent<AndroidPermissionReceiver>();
		}

		// // RVA: 0xE0892C Offset: 0xE0892C VA: 0xE0892C
		// public bool GetLastResult() { }

		// // RVA: 0xE08934 Offset: 0xE08934 VA: 0xE08934
		// public bool GetEstimateNever() { }

		// RVA: 0xE0893C Offset: 0xE0893C VA: 0xE0893C
		public void RequestPremission(AndroidPermission permission, UnityAction onPermit, UnityAction notPermit)
		{
			m_permissionResult = false;
			m_estimateNever = false;
			m_startTime = DateTime.Now;
#if !UNITY_EDITOR
			AndroidJavaClass c = new AndroidJavaClass("jp.co.xeen.xeapp.PermissionManager");
			c.CallStatic("requestPermission", new object[] { getPermissionStr(permission) });
#endif
			if(onPermit != null)
			{
				if(m_permitCallBack == null)
					m_permitCallBack = new UnityEvent();
				m_permitCallBack.AddListener(onPermit);
			}
			if(notPermit != null)
			{
				if(m_notPermitCallBack == null)
					m_notPermitCallBack = new UnityEvent();
				m_notPermitCallBack.AddListener(notPermit);
			}
#if UNITY_EDITOR
			NotPermit();
#endif
		}

		// // RVA: 0xE08C88 Offset: 0xE08C88 VA: 0xE08C88
		public void OnPermit()
		{
			m_permissionResult = true;
			m_estimateNever = false;
			if(m_permitCallBack != null)
				m_permitCallBack.Invoke();
			m_permitCallBack = null;
			m_notPermitCallBack = null;
		}

		// // RVA: 0xE08CD0 Offset: 0xE08CD0 VA: 0xE08CD0
		public void NotPermit()
		{
			m_permissionResult = false;
			m_estimateNever = (DateTime.Now - m_startTime).TotalMilliseconds < 250;
			if(m_notPermitCallBack != null)
				m_notPermitCallBack.Invoke();
			m_permitCallBack = null;
			m_notPermitCallBack = null;
		}

		// // RVA: 0xE08CC0 Offset: 0xE08CC0 VA: 0xE08CC0
		// private void resetCallBacks() { }

		// // RVA: 0xE08BB4 Offset: 0xE08BB4 VA: 0xE08BB4
		private static string getPermissionStr(AndroidPermission permission)
		{
			return "android.permission." + permission.ToString();
		}
	}
}
