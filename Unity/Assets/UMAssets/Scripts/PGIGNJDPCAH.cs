
using System.Collections;

public class PGIGNJDPCAH
{
    public enum IMOIPBMGIPN
    {
        HJNNKCMLGFL = 0,
        MGEFLLPGDDN = 1,
        OGFOHBGEAEC = 2,
        CKOMFNPGHOM = 3,
        PJPJEHEFMMJ = 4,
    }

    public enum FELLIEJEPIJ
    {
        JBAIEADLAGH = 0,
        FFPANKMKAPD = 1,
        NADCOIBMMJM = 2,
        ONHOCOBCINO = 3,
        ANGNLABPOIH = 4,
        LPBDIINNFEE = 5,
    }

	private static PGIGNJDPCAH.FELLIEJEPIJ EPDEBBDHFCH = FELLIEJEPIJ.JBAIEADLAGH; // 0x0
	private static bool LMGGIBJPGLE = true; // 0x4
	public static bool OGAIOKGEMDE = false; // 0x5
	private static bool LANLFCFBOHI = false; // 0x6
	private static int OANIGHDIKJH; // 0x8

	public static bool IPJMPBANBPP { 
		get {
			// IJMCHOOIMBB 0x16C982C 
			TodoLogger.Log(0, "TODO");
			return false;
		}
		set{
			//FLHLJFHILPO 0x16C98B8 
			if(value == LMGGIBJPGLE)
				return;
			LMGGIBJPGLE = value;
		}
	} 
	private static int HIJBIPLMNEA { get { return OANIGHDIKJH ^ 0x3f587e47; } set { OANIGHDIKJH = value ^ 0x3f587e47; } } // IDLMAHADDKO 0x16CA0EC  PPDOPFGBPAM 0x16CA184

	// // RVA: 0x16C998C Offset: 0x16C998C VA: 0x16C998C
	public static void MLPMNKKNFCJ()
    {
        LANLFCFBOHI = false;
    }

	// // RVA: 0x16C9A1C Offset: 0x16C9A1C VA: 0x16C9A1C
	public static void NNOBACMJHDM(PGIGNJDPCAH.FELLIEJEPIJ PPFNGGCBJKC)
    {
		EPDEBBDHFCH = PPFNGGCBJKC;
		IPJMPBANBPP = false;
    }

	// // RVA: 0x16C9AB4 Offset: 0x16C9AB4 VA: 0x16C9AB4
	public static void HIHIEBACIHJ(PGIGNJDPCAH.FELLIEJEPIJ PPFNGGCBJKC)
	{
		TodoLogger.Log(0, "HIHIEBACIHJ");
	}

	// // RVA: 0x16C9D9C Offset: 0x16C9D9C VA: 0x16C9D9C
	public static IMOIPBMGIPN AIMFCMCMOIH()
	{
		TodoLogger.Log(0, "AIMFCMCMOIH");
		return 0;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B8B48 Offset: 0x6B8B48 VA: 0x6B8B48
	// // RVA: 0x16CA220 Offset: 0x16CA220 VA: 0x16CA220
	private static IEnumerator OOILBGOKHDC(bool FBBNPFFEJBN, IMCBBOAFION GIMKOLPGIAO, IMCBBOAFION MBIKIBHLAGE)
	{
		TodoLogger.Log(0, "OOILBGOKHDC");
		yield break;
	}

	// // RVA: 0x16CA300 Offset: 0x16CA300 VA: 0x16CA300
	public static bool MNANNMDBHMP(IMCBBOAFION GIMKOLPGIAO, IMCBBOAFION MBIKIBHLAGE)
	{
		if(!LANLFCFBOHI)
		{
			IMOIPBMGIPN EALOBDHOCHP = AIMFCMCMOIH();
			switch(EALOBDHOCHP)
			{
				case IMOIPBMGIPN.MGEFLLPGDDN:
				case IMOIPBMGIPN.CKOMFNPGHOM:
					NKGJPJPHLIF.HHCJCDFCLOB.NIJDPPHGHFD(EALOBDHOCHP == IMOIPBMGIPN.CKOMFNPGHOM/*3*/);
					JHHBAFKMBDL.HHCJCDFCLOB.CIKMDHMMCIL(2, MBIKIBHLAGE);
					LANLFCFBOHI = true;
					return true;
				break;
				case IMOIPBMGIPN.OGFOHBGEAEC:
				case IMOIPBMGIPN.PJPJEHEFMMJ:
					JHHBAFKMBDL.HHCJCDFCLOB.PNIJEKOHEII(() =>
					{
						//0x16CA6C8
						HIJBIPLMNEA = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
						N.a.StartCoroutineWatched(OOILBGOKHDC(EALOBDHOCHP == IMOIPBMGIPN.CKOMFNPGHOM, GIMKOLPGIAO, MBIKIBHLAGE));
					});
					LANLFCFBOHI = true;
					return true;
				break;
			}
		}
		return false;
	}
}
