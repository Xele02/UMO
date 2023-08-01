using UnityEngine;

public class FCMTokenReceiver : MonoBehaviour
{
	public static string fcmToken = ""; // 0x0
	private bool isInitialized; // 0xC
	//private DependencyStatus dependencyStatus = 7; // 0x10
	public static bool isDpendencyChecked = false; // 0x4

	// RVA: 0xFC74F8 Offset: 0xFC74F8 VA: 0xFC74F8
	public void Start()
	{
		TodoLogger.LogError(TodoLogger.FCMTokenReceiver, "FCMTokenReceiver.Start");
		{
			//Method$FCMTokenReceiver.<Start>b__4_0()
			// Hack cause Firebase not coded
			isDpendencyChecked = true;
			InitializeFirebase();
		}
	}

	// RVA: 0xFC75EC Offset: 0xFC75EC VA: 0xFC75EC
	public void OnDestory()
	{
		if (!isInitialized)
			return;
		TodoLogger.LogError(TodoLogger.FCMTokenReceiver, "FCMTokenReceiver.OnDestory");
	}

	//// RVA: 0xFC7718 Offset: 0xFC7718 VA: 0xFC7718
	private void InitializeFirebase()
	{
		if (isInitialized)
			return;
		TodoLogger.LogError(TodoLogger.FCMTokenReceiver, "FCMTokenReceiver.InitializeFirebase");
		//Hack
		fcmToken = "aa";
		//
		isInitialized = true;
	}

	//// RVA: 0xFC794C Offset: 0xFC794C VA: 0xFC794C
	//public void OnTokenReceived(object sender, TokenReceivedEventArgs token) { }

	//// RVA: 0xFC79FC Offset: 0xFC79FC VA: 0xFC79FC
	//public void OnMessageReceived(object sender, MessageReceivedEventArgs e) { }

	//[CompilerGeneratedAttribute] // RVA: 0x68FEEC Offset: 0x68FEEC VA: 0x68FEEC
	//// RVA: 0xFC7A94 Offset: 0xFC7A94 VA: 0xFC7A94
	//private void <Start>b__4_0(Task<DependencyStatus> checkTask) { }
}
