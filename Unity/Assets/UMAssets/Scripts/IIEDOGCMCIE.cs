using System.Collections;

public class IIEDOGCMCIE : CBBJHPBGBAJ_Archive
{
	private const int NNBHLPECAHJ = 1;
	public bool BIOFMLDLNKD; // 0xC
	public bool NPNNPNAIONN; // 0xD
	public bool PLOOEECNHFB; // 0xE

	// // RVA: 0x120437C Offset: 0x120437C VA: 0x120437C
	public void MCDJJPAKBLH(string CJEKGLGBIHF_path)
    {
		UnityEngine.Debug.LogError("TODO");
    }

	// [IteratorStateMachineAttribute] // RVA: 0x6BA26C Offset: 0x6BA26C VA: 0x6BA26C
	// // RVA: 0x12043D8 Offset: 0x12043D8 VA: 0x12043D8
	public IEnumerator ODDEPBIJHOE_Load(string CJEKGLGBIHF_path)
    {
        // 	public string CJEKGLGBIHF_path; // 0x10
        // 	public IIEDOGCMCIE KIGBLACMODG; // 0x14
        // 	private DsfdLoader.ILoadRequest OCJDGDAJMFC; // 0x18
		// 0x12044AC

        Cryptor.DsfdLoader.ILoadRequest request = Cryptor.DsfdLoader.LoadFile(CJEKGLGBIHF_path);
        if(request == null)
        {
            PLOOEECNHFB = true;
            NPNNPNAIONN = true;
            yield break;
        }
        while(!request.IsDone)
        {
            yield return null;
        }
        if(!request.IsSuccess)
        {
            PLOOEECNHFB = true;
        }
        else
        {
            byte[] result = request.Result;
            bool r = BOBCNJIPPJN.AGJJGJCIMKI(result);
            if(!r)
            {
                ANCJLICGOLP a = DOKOHKJIDBO.HHCJCDFCLOB.IKCAJDOKNOM;
                int val1 = a.LPJLEHAJADA("m_0", 0);
                int val2 = a.LPJLEHAJADA("m_1", 0);
                int val3 = a.LPJLEHAJADA("m_2", 0);
                int val4 = a.LPJLEHAJADA("m_3", 0);
                BEEINMBNKNM_Encryption encryption = new BEEINMBNKNM_Encryption();
                encryption.KHEKNNFCAOI((uint)(val4 + 7));
                encryption.DGBPHDMEDNP(val1, val2, val3);
                encryption.FAEFDAJAMCE(result);
                encryption.AAGCKDHEMFD_GenerateKey();
            }
            BIOFMLDLNKD = KHEKNNFCAOI_Load(request.Result);
            PLOOEECNHFB = true;
            if(!BIOFMLDLNKD)
            {
                yield break;
            }
        }
        NPNNPNAIONN = true;
    }
}
