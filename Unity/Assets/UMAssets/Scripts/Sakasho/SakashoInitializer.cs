using UnityEngine;

public class SakashoInitializer : MonoBehaviour
{
	private static SakashoInitializer instance; // 0x0
	private static bool initialized; // 0x4
	public int serverMode; // 0xC
	public string sakashoGameId; // 0x10
	public string sakashoCommonKey; // 0x14
	public string clientId; // 0x18
	public string appVersion; // 0x1C
	public SakashoSystem.PaymentType paymentType = SakashoSystem.PaymentType.V1; // 0x20

	// RVA: 0x2BC7564 Offset: 0x2BC7564 VA: 0x2BC7564
	private void Awake()
    {
		if(instance != null)
			return;
		instance = this;
		Object.DontDestroyOnLoad(transform.gameObject);
    }

	// RVA: 0x2BC768C Offset: 0x2BC768C VA: 0x2BC768C
	private void Start()
    {
		if(instance != this)
			return;
		InitializeOnStart();
		SakashoSystem.Resume();
    }

	// // RVA: 0x2BC7750 Offset: 0x2BC7750 VA: 0x2BC7750 Slot: 4
	protected virtual void InitializeOnStart()
	{
		if(Initialize() != 0)
		{
			UnityEngine.Debug.LogError("Can't initialize Sakasho or AndApp. May use debug build on production environment?");
			UnityEngine.Application.Quit();
		}
		UnityEngine.Debug.Log("Finished Sakasho initialization.");
	}

	// // RVA: 0x2BC782C Offset: 0x2BC782C VA: 0x2BC782C
	public static int Initialize()
	{
		return Initialize(instance.serverMode, instance.sakashoGameId, instance.sakashoCommonKey, instance.paymentType);
	}

	// // RVA: 0x2BC794C Offset: 0x2BC794C VA: 0x2BC794C
	public static int Initialize(int serverMode, string gameId, string commonKey, SakashoSystem.PaymentType paymentType)
	{
		if(!initialized)
		{
			if(SakashoSystem.Initialize((SakashoSystem.ServerMode)serverMode, gameId, commonKey, paymentType))
			{
				initialized = true;
				return 0;
			}
			return -1;
		}
		return 0;
	}

	// // RVA: 0x2BC7A1C Offset: 0x2BC7A1C VA: 0x2BC7A1C
	private void OnApplicationPause(bool pauseState)
	{
		if(pauseState)
			SakashoSystem.Pause();
		else
			SakashoSystem.Resume();
	}

	// // RVA: 0x2BC7A30 Offset: 0x2BC7A30 VA: 0x2BC7A30
	private void OnApplicationQuit()
	{
		SakashoSystem.Finish();
	}
}
