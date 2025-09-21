using Cryptor;
using System.Collections;

public class GNMBAOKGJDO
{
	private const int NNBHLPECAHJ = 1;
	public bool BIOFMLDLNKD; // 0x8
	public bool NPNNPNAIONN_IsError; // 0x9
	public bool PLOOEECNHFB_IsDone; // 0xA
	public byte[] IAKPCFDLMKP_db; // 0xC

	// // RVA: 0x1E59358 Offset: 0x1E59358 VA: 0x1E59358
	public void MCDJJPAKBLH(string _CJEKGLGBIHF_path)
    {
		PLOOEECNHFB_IsDone = false;
		BIOFMLDLNKD = false;
		NPNNPNAIONN_IsError = false;
		UnityEngine.Debug.Log("start Coroutine_Load="+_CJEKGLGBIHF_path);
        
		N.a.StartCoroutineWatched(ODDEPBIJHOE_Coroutine_Load(_CJEKGLGBIHF_path));
    }

	// [IteratorStateMachineAttribute] // RVA: 0x6BA184 Offset: 0x6BA184 VA: 0x6BA184
	// // RVA: 0x1E59448 Offset: 0x1E59448 VA: 0x1E59448
	private IEnumerator ODDEPBIJHOE_Coroutine_Load(string _CJEKGLGBIHF_path)
	{
		// public GNMBAOKGJDO KIGBLACMODG; // 0x14
		// private DsfdLoader.ILoadRequest OCJDGDAJMFC; // 0x18
		//0x1E5951C

		UnityEngine.Debug.Log("start DsfdLoader.LoadFile "+_CJEKGLGBIHF_path);
		DsfdLoader.ILoadRequest OCJDGDAJMFC = DsfdLoader.LoadFile(_CJEKGLGBIHF_path);
		if(OCJDGDAJMFC == null)
		{
			UnityEngine.Debug.Log("err DsfdLoader.LoadFile");
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
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
			IAKPCFDLMKP_db = data2;
			UnityEngine.Debug.Log("OK Unzip");
			PLOOEECNHFB_IsDone = true;
		}
		else
		{
			UnityEngine.Debug.Log("err2 DsfdLoader.LoadFile");
			TodoLogger.LogError(TodoLogger.Coroutine, "Exit Error ODDEPBIJHOE_Coroutine_Load");
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			yield break;
		}
	}

}
