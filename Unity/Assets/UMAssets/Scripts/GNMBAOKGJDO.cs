using Cryptor;
using System.Collections;

public class GNMBAOKGJDO
{
	private const int NNBHLPECAHJ = 1;
	public bool BIOFMLDLNKD; // 0x8
	public bool NPNNPNAIONN; // 0x9
	public bool PLOOEECNHFB; // 0xA
	public byte[] IAKPCFDLMKP; // 0xC

	// // RVA: 0x1E59358 Offset: 0x1E59358 VA: 0x1E59358
	public void MCDJJPAKBLH(string CJEKGLGBIHF)
    {
		PLOOEECNHFB = false;
		BIOFMLDLNKD = false;
		NPNNPNAIONN = false;
		UnityEngine.Debug.Log("start Coroutine_Load="+CJEKGLGBIHF);
        
		N.a.StartCoroutineWatched(ODDEPBIJHOE_Coroutine_Load(CJEKGLGBIHF));
    }

	// [IteratorStateMachineAttribute] // RVA: 0x6BA184 Offset: 0x6BA184 VA: 0x6BA184
	// // RVA: 0x1E59448 Offset: 0x1E59448 VA: 0x1E59448
	private IEnumerator ODDEPBIJHOE_Coroutine_Load(string CJEKGLGBIHF)
	{
		// public GNMBAOKGJDO KIGBLACMODG; // 0x14
		// private DsfdLoader.ILoadRequest OCJDGDAJMFC; // 0x18
		//0x1E5951C

		UnityEngine.Debug.Log("start DsfdLoader.LoadFile "+CJEKGLGBIHF);
		DsfdLoader.ILoadRequest OCJDGDAJMFC = DsfdLoader.LoadFile(CJEKGLGBIHF);
		if(OCJDGDAJMFC == null)
		{
			UnityEngine.Debug.Log("err DsfdLoader.LoadFile");
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
			yield break;
		}

		while(!OCJDGDAJMFC.IsDone)
		{
			yield return null;
		}
		if(OCJDGDAJMFC.IsSuccess)
		{
			UnityEngine.Debug.Log("XorBytes");
			byte[] data = OCJDGDAJMFC.Result;
			byte[] data2 = new byte[data.Length];
			int var = 0x75;
			for(int i = 0; i < data.Length; i++)
			{
				data2[i] = (byte)(data[i] ^ var);
				var = (var * 0xd) % 0x100;
			}
			UnityEngine.Debug.Log("Start Unzip");
			data2 = BOBCNJIPPJN.JCBCBNFPJDH(data2);
			BIOFMLDLNKD = true;
			IAKPCFDLMKP = data2;
			UnityEngine.Debug.Log("OK Unzip");
			PLOOEECNHFB = true;
		}
		else
		{
			UnityEngine.Debug.Log("err2 DsfdLoader.LoadFile");
			TodoLogger.LogError(TodoLogger.Coroutine, "Exit Error ODDEPBIJHOE_Coroutine_Load");
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
			yield break;
		}
	}

}
