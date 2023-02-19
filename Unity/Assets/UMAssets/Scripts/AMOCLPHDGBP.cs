using System;
using System.Collections;

public delegate void JFDNPFFOACP();
public delegate void ELBOJBBIBFM(LGDNAJACFHI PPFNGGCBJKC_Id);
public delegate void BKEHAMOGHCL(AMOCLPHDGBP PKLPKMLGFGK, ELBOJBBIBFM EDMKFIJKJLB, JFDNPFFOACP NIMPEHIECJH);
public delegate void JCKIFJADNEF(PJHHCHAKGKI KFFBDNMNBMM, JFDNPFFOACP NIMPEHIECJH);
public delegate void PJHHCHAKGKI(int LBEBFEIHPOO, int IBAKPKKEDJM);
public delegate void KMIEKGLLDCI(int LBEBFEIHPOO, int KLCMKLPIDDJ, IMCBBOAFION BHEOPIPFEFJ, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK MOBEEPPKFLG);

public class AMOCLPHDGBP
{
    private enum EMAGIFONJLD
    {
        LCNHAHPGDEA = 0,
        PLBEBIPLODF = 1,
        HLEGCGNPMAB = 0,
    }

    private enum FINNDKJENCG
    {
        FKPEAGGKNLC = 0,
        EBABINMPENN = 1,
        NALKNDBAEHD = 2,
        CPJMCILHPKO = 3,
        ACJKDEHJGFI = 4,
        GCBEOFGKJPF = 5,
        NGFFHEHOKJB = 6,
        FJNADADCBGJ = 7,
        AAHHJDACPCN = 8,
        FMPPMBNDJJF = 9,
        EEEAMFOKGFK = 10,
    }

	public BKEHAMOGHCL MKDKKDNBEEK; // 0x8
	public JCKIFJADNEF AJGKLIIDKHA; // 0xC
	public KMIEKGLLDCI FIJMBKFJJIJ; // 0x10
	private IMCBBOAFION BHFHGFKBOHH; // 0x14
	private JFDNPFFOACP NIMPEHIECJH; // 0x18
	private DJBHIFLHJLK MOBEEPPKFLG; // 0x1C
	public Action PBJINBCLFBB; // 0x20
	private bool ENDJKKHKMNP; // 0x24
	private bool PPKOLFEBLCF = true; // 0x25
	private SakashoErrorId OHBJPKPCIEB = SakashoErrorId.PRODUCT_TRANSACTION_EXISTS; // 0x28
	private bool LNHFLJBGGJB; // 0x2C
	private bool OCNNKKPBDLL; // 0x2D
	private bool PBCJCAOLLKI; // 0x2E
	private bool NHOAJCLAEJD; // 0x2F
	public bool CLFGEAPFFMA; // 0x30
	private EMAGIFONJLD GDGBDFEGLKK; // 0x34
	private static string[] CMPEKADFEEO = new string[11] {"paidvc start ", "get_products_success ", "purchase_start ", "purchase_action ", "error_emultaion ", "purchase_success ",
															"purchase_cancel ", "purchase_error_special ", "purchase_error_permanent ", "purchase_error_purchase ", "processing now "}; // 0x0
	private int LBEBFEIHPOO; // 0x38
	private int KLCMKLPIDDJ; // 0x3C
	private bool LPEJBOIONDP; // 0x40
	private bool KIECCJLPNMN; // 0x41
	private bool ALNCNJMEFHM; // 0x42
	private bool KCEDKOHKHGL; // 0x43
	private bool KMABBBKJFCB; // 0x44
	private int FJIKAAOMOKE; // 0x48

	// public EJHPIMANJFP HFCNOINEPLB { get; } // IHHPFGILBNE 0xCE9480

	// // RVA: 0xCE9488 Offset: 0xCE9488 VA: 0xCE9488
	// private void FCPBCDOKOPD(AMOCLPHDGBP.FINNDKJENCG PPFNGGCBJKC_Id, string IBDJFHFIIHN = "") { }

	// // RVA: 0xCE948C Offset: 0xCE948C VA: 0xCE948C
	// private void JEEPGGGAKMI() { }

	// // RVA: 0xCE949C Offset: 0xCE949C VA: 0xCE949C
	// public void DCDPMEPNKND(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK MOBEEPPKFLG, Action PBJINBCLFBB, bool MBGCBCOPOLA = False, bool AJAPLLGJKJB = False) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B9118 Offset: 0x6B9118 VA: 0x6B9118
	// // RVA: 0xCE9838 Offset: 0xCE9838 VA: 0xCE9838
	// private IEnumerator JGKMFHLKEJP_PreGetProductList(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK MOBEEPPKFLG, Action PBJINBCLFBB) { }

	// // RVA: 0xCE9924 Offset: 0xCE9924 VA: 0xCE9924
	// private void JLNBMEMFGPH(LGDNAJACFHI MEANCEOIMGE) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B9190 Offset: 0x6B9190 VA: 0x6B9190
	// // RVA: 0xCE99D4 Offset: 0xCE99D4 VA: 0xCE99D4
	// private IEnumerator IGFMPECJFJA_Purchase(LGDNAJACFHI MEANCEOIMGE) { }

	// // RVA: 0xCE9A78 Offset: 0xCE9A78 VA: 0xCE9A78
	// private void HENOMNBDBMA(JFDNPFFOACP GIGHIFOIMNA) { }

	// // RVA: 0xCE9D78 Offset: 0xCE9D78 VA: 0xCE9D78
	// private void AJHEHLHNMMF(int PMBEODGMMBB, int MABBBOEAPAA) { }

	// // RVA: 0xCE9D8C Offset: 0xCE9D8C VA: 0xCE9D8C
	// private void DCGBPKBCGIO() { }

	// // RVA: 0xCE9DA0 Offset: 0xCE9DA0 VA: 0xCE9DA0
	// private void GFKFKJAPPLA() { }

	// // RVA: 0xCE9DB4 Offset: 0xCE9DB4 VA: 0xCE9DB4
	// private void FDMEGIGOIPD() { }

	// // RVA: 0xCE9DC0 Offset: 0xCE9DC0 VA: 0xCE9DC0
	// private void KJMDILMLFBG() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B9208 Offset: 0x6B9208 VA: 0x6B9208
	// // RVA: 0xCE9DCC Offset: 0xCE9DCC VA: 0xCE9DCC
	// private IEnumerator NLMLHDONBJC_BirthdayRegistration(IMCBBOAFION KLMFJJCNBIP, JFDNPFFOACP NEFKBBNKNPP, JFDNPFFOACP JGKOLBLPMPG) { }

	// // RVA: 0xCE9EA0 Offset: 0xCE9EA0 VA: 0xCE9EA0
	// private bool MJOKGGCMOMD(SakashoErrorId GGBJNJJHLHJ) { }

	// // RVA: 0xCE9EB0 Offset: 0xCE9EB0 VA: 0xCE9EB0
	public void OLNDKPDNPCM_Auto_Recover(IMCBBOAFION KLMFJJCNBIP, JFDNPFFOACP NEFKBBNKNPP, DJBHIFLHJLK BFKEGJMPELF, bool EBKGBLFCENA = false, bool BOGDHEBBHFA = false)
	{
		N.a.StartCoroutineWatched(GEMPIKIBEKJ_Coroutine_AutoRecover(KLMFJJCNBIP,NEFKBBNKNPP,BFKEGJMPELF,EBKGBLFCENA,BOGDHEBBHFA));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B9280 Offset: 0x6B9280 VA: 0x6B9280
	// // RVA: 0xCE9F24 Offset: 0xCE9F24 VA: 0xCE9F24
	private IEnumerator GEMPIKIBEKJ_Coroutine_AutoRecover(IMCBBOAFION KLMFJJCNBIP, JFDNPFFOACP NEFKBBNKNPP, DJBHIFLHJLK BFKEGJMPELF, bool EBKGBLFCENA, bool BOGDHEBBHFA)
	{
		//UnityEngine.Debug.Log("Enter GEMPIKIBEKJ_Coroutine_AutoRecover");
		TodoLogger.Log(0, "TODO");
		////UnityEngine.Debug.Log("Exit GEMPIKIBEKJ_Coroutine_AutoRecover");
		KLMFJJCNBIP();
		yield break;
	}

	// // RVA: 0xCEA030 Offset: 0xCEA030 VA: 0xCEA030
	// private void PCLDNINHHBE(List<int> NNDGIAEFMOG, long JHNMKKNEENE) { }

	// // RVA: 0xCEA23C Offset: 0xCEA23C VA: 0xCEA23C
	// private bool DDGIEBFGGDF(SakashoErrorId PPFNGGCBJKC_Id) { }

	// // RVA: 0xCEA274 Offset: 0xCEA274 VA: 0xCEA274
	// public static bool ELDMAINJHJI(SakashoErrorId PPFNGGCBJKC_Id) { }

	// // RVA: 0xCEA298 Offset: 0xCEA298 VA: 0xCEA298
	// public void CGPFMPHAAJK(IMCBBOAFION KLMFJJCNBIP, DJBHIFLHJLK BFKEGJMPELF) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B92F8 Offset: 0x6B92F8 VA: 0x6B92F8
	// // RVA: 0xCEA2F0 Offset: 0xCEA2F0 VA: 0xCEA2F0
	// private IEnumerator BIIABMDFMEN_ManualRecover(IMCBBOAFION KLMFJJCNBIP, DJBHIFLHJLK BFKEGJMPELF) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B9370 Offset: 0x6B9370 VA: 0x6B9370
	// // RVA: 0xCEA3AC Offset: 0xCEA3AC VA: 0xCEA3AC
	// public IEnumerator HELKENJBJBH_AccountRemoveRecover(IMCBBOAFION KLMFJJCNBIP, DJBHIFLHJLK BFKEGJMPELF) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B93E8 Offset: 0x6B93E8 VA: 0x6B93E8
	// // RVA: 0xCEA468 Offset: 0xCEA468 VA: 0xCEA468
	// public IEnumerator KCCCOEMPPEA(SakashoErrorId MFDOKGNKNJJ, bool JBADCKAEMLI) { }

	// // RVA: 0xCEA524 Offset: 0xCEA524 VA: 0xCEA524
	// private void FOKFHDAFODE() { }

	// // RVA: 0xCEA538 Offset: 0xCEA538 VA: 0xCEA538
	// private void LFGLFMCIGIK() { }

	// // RVA: 0xCEA54C Offset: 0xCEA54C VA: 0xCEA54C
	// private void DHAOCHPANFH() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B9460 Offset: 0x6B9460 VA: 0x6B9460
	// // RVA: 0xCEA560 Offset: 0xCEA560 VA: 0xCEA560
	// public IEnumerator PKNNELLMKPD_Test() { }

	// // RVA: 0xCEA5E8 Offset: 0xCEA5E8 VA: 0xCEA5E8
	// public void PFEKONLBFDM() { }

	// // RVA: 0xCE95AC Offset: 0xCE95AC VA: 0xCE95AC
	// private void FAHKEEFPAFH(JFDNPFFOACP NIMPEHIECJH) { }

	// // RVA: 0xCEA5F8 Offset: 0xCEA5F8 VA: 0xCEA5F8
	// private void JCLIKCHGEBH(LGDNAJACFHI MEANCEOIMGE) { }

	// // RVA: 0xCEA6C8 Offset: 0xCEA6C8 VA: 0xCEA6C8
	// public static void JCLIKCHGEBH(FHPFLAGNCAF MEANCEOIMGE) { }

	// // RVA: 0xCEA6CC Offset: 0xCEA6CC VA: 0xCEA6CC
	// public static void FPEGBMIFDDN() { }

	// // RVA: 0xCEA6D0 Offset: 0xCEA6D0 VA: 0xCEA6D0
	// public static void HIBOGALOHHO() { }
}
