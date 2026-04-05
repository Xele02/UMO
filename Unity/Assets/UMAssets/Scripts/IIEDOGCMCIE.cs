using System.Collections;

// namespace XeApp.Game.Net.Security
[System.Obsolete()]
public class IIEDOGCMCIE {}
public class IIEDOGCMCIE_SecureTarFile : CBBJHPBGBAJ_Archive
{
	private const int NNBHLPECAHJ = 1;
	public bool BIOFMLDLNKD; // 0xC
	public bool NPNNPNAIONN_IsError; // 0xD
	public bool PLOOEECNHFB_IsDone; // 0xE

	// // RVA: 0x120437C Offset: 0x120437C VA: 0x120437C
	public void MCDJJPAKBLH(string _CJEKGLGBIHF_path)
    {
        PLOOEECNHFB_IsDone = false;
        BIOFMLDLNKD = false;
        N.a.StartCoroutineWatched(ODDEPBIJHOE_Coroutine_Load(_CJEKGLGBIHF_path));
    }

	// [IteratorStateMachineAttribute] // RVA: 0x6BA26C Offset: 0x6BA26C VA: 0x6BA26C
	// // RVA: 0x12043D8 Offset: 0x12043D8 VA: 0x12043D8
	public IEnumerator ODDEPBIJHOE_Coroutine_Load(string _CJEKGLGBIHF_path)
    {
        // 	public string CJEKGLGBIHF_path; // 0x10
        // 	public IIEDOGCMCIE_SecureTarFile KIGBLACMODG; // 0x14
        // 	private DsfdLoader.ILoadRequest OCJDGDAJMFC; // 0x18
		// 0x12044AC

        Cryptor.DsfdLoader.ILoadRequest request = Cryptor.DsfdLoader.LoadFile(_CJEKGLGBIHF_path);
        if(request == null)
        {
            PLOOEECNHFB_IsDone = true;
            NPNNPNAIONN_IsError = true;
            TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error ODDEPBIJHOE_Coroutine_Load");
            yield break;
        }
        while(!request.IsDone)
        {
            yield return null;
        }
        if(!request.IsSuccess)
        {
            PLOOEECNHFB_IsDone = true;
        }
        else
        {
            byte[] result = request.Result;
            bool r = BOBCNJIPPJN.AGJJGJCIMKI(result);
            if(!r)
            {
                ANCJLICGOLP a = DOKOHKJIDBO.HHCJCDFCLOB_Instance.IKCAJDOKNOM;
                int val1 = a.LPJLEHAJADA_GetIntParam("m_0", 0);
                int val2 = a.LPJLEHAJADA_GetIntParam("m_1", 0);
                int val3 = a.LPJLEHAJADA_GetIntParam("m_2", 0);
                int val4 = a.LPJLEHAJADA_GetIntParam("m_3", 0);
                BEEINMBNKNM_Encryption encryption = new BEEINMBNKNM_Encryption();
                encryption.KHEKNNFCAOI_Init((uint)(val4 + 7));
                encryption.DGBPHDMEDNP(val1, val2, val3);
                encryption.FAEFDAJAMCE(result);
                encryption.AAGCKDHEMFD_Finish();
            }
            BIOFMLDLNKD = KHEKNNFCAOI_Init(request.Result);
            PLOOEECNHFB_IsDone = true;
            if(BIOFMLDLNKD)
            {
                yield break;
            }
        }
        NPNNPNAIONN_IsError = true;
        TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error ODDEPBIJHOE_Coroutine_Load");
    }
}
