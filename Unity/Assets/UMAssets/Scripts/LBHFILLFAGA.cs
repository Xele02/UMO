using XeSys;
using System.Collections.Generic;

public abstract class LBHFILLFAGA
{
	public enum PLINNKMECEF
	{
		NFFGMBBNNPH = 0,
		AMDJBGNGLDL = 1,
		KEDMBDBJBKM = 2,
		PNGOBECOOJM = 3,
		JKONMHNBGLL = 4,
	}

	public string BOPDLODALFD; // 0x18
	public string HHHEFALNMJO; // 0x1C
	private float JMHHKKFPPOL; // 0x48
	private static readonly byte[] ILINJKLDCJD; // 0x0
	private static readonly byte[] MPNFIMBCMFK; // 0x4
	private static readonly byte[] OBIKJLFDNJA; // 0x8
	private static readonly byte[] NFIOLMJLGFM; // 0xC
	private static readonly byte[] OPMNFNHOMJF; // 0x10
	private static readonly byte[] LLJJCPNHPFP; // 0x14
	private static readonly byte[] BGLBMKIKKKP; // 0x18
	private static readonly byte[] LEAAJEJAMMH; // 0x1C

	// // Properties
	public FileLoadedPostProcess DAPCDNJBKBK { get; set; }  // 0x8 OGPIDJJJPDA ONKPBECIMIE JJHJMLAJLIL
	public FileLoadedPostProcess HAANPNDACPE { get; set; } // 0xC HEBMELACEOE OMFPAIIEMEF KKNOOFCBHGN
	protected FileResultObject IMGIFJHHEED { get; set; } // 0x10 BJCPEOGAOCP LNDGEDHIEAF KDNEHECLIDH
	public int IIMBNNKHGOM { get; set; } // 0x14 HLAHGBEIIDC NBLBPKLLFHB JKGMAOLDLLM
	public bool FHHAFJMELMD { get; set; } // 0x20 KGPGOAPDCGM LGCBNNBFLLC HNKEGLMMFFH
	public int EAABKFGHKBG { get; set; } // 0x24 PCCDLFDCFBG OACNBAPAKAA GMJKJICMLHI
	public byte NHJKENJIEME { get; set; } // 0x28 DIPNMHIKPKL ILBBLANOILG CEEPINBAEKO
	public float EBKOJBFMABH { get; set; } // 0x2C NKIAIBHHPDL BMPPFIPBMBE BIILBBPMNBJ
	public CriFsBinder COIBJNACMFK { get; set; } // 0x30 NFIDNEPMMOK EBIJOIDBPIE GOKEIMCNGHB
	public BEEINMBNKNM_Encryption DMKAFCEJFDG { get; set; } // 0x34 FKCKGBMNBPL LIMGNMMPKGF AKNAGKOHHCA
	public PLINNKMECEF LHMDABPNDDH { get; set; } // 0x38 JNOFANKGNGJ HMMFHMFLNAJ PBNPKEFIPKI
	public bool KCIDANFAFPP { get; set; } // 0x3C PJOGIHCDNCE KMEELELCBJJ HNDBDCPGMOM
	public float AJOAGOLGLAI { get; set; }  // 0x40 NEMPFIPLCMK IMNPGDHJKEN HODDHFFBNIL
	public bool PHOPDCNFFEI { get { return LHMDABPNDDH == PLINNKMECEF.PNGOBECOOJM; } } // NPFACLDLOCJ 0xD98588
	public bool OJOLGGKILFL { get; set; } // 0x44 CLJDDDODKCD KKEOAGANMNA HHPCOOAPJJN

	// // RVA: 0xD985AC Offset: 0xD985AC VA: 0xD985AC
	public LBHFILLFAGA()
	{
		KCIDANFAFPP = false;
		OJOLGGKILFL = false;
		AJOAGOLGLAI = 1.0f;
		LHMDABPNDDH = PLINNKMECEF.NFFGMBBNNPH;
		FHHAFJMELMD = false;
		IIMBNNKHGOM = 0;
		JMHHKKFPPOL = 0.0f;
		EBKOJBFMABH = 0.0f;
		NHJKENJIEME = 0;
		EAABKFGHKBG = 0;
	}

	// // RVA: 0xD985F4 Offset: 0xD985F4 VA: 0xD985F4
	public LBHFILLFAGA(string CJEKGLGBIHF, string BOPDLODALFD, FileLoadedPostProcess OGLMMENAJFL, FileLoadedPostProcess GOIHDOPGPCE, Dictionary<string, string> JBKMAPLCBMO, int HNKPENAFDKA, FileLoadInfo LAMFBMFNOFP)
	{
		KCIDANFAFPP = false;
		OJOLGGKILFL = false;
		AJOAGOLGLAI = 1.0f;
		LHMDABPNDDH = 0;
		EAABKFGHKBG = 0;
		this.BOPDLODALFD = BOPDLODALFD;
		HHHEFALNMJO = CJEKGLGBIHF;
		DAPCDNJBKBK = OGLMMENAJFL;
		HAANPNDACPE = GOIHDOPGPCE;
		if(LAMFBMFNOFP == null)
		{
			IMGIFJHHEED = new FileResultObject(CJEKGLGBIHF,JBKMAPLCBMO,HNKPENAFDKA);
		}
		else
		{
			IMGIFJHHEED = LAMFBMFNOFP.resultObject;
		}
		FHHAFJMELMD = LAMFBMFNOFP != null;
		IIMBNNKHGOM = CJEKGLGBIHF.GetHashCode();
		EAABKFGHKBG = 0;
		JMHHKKFPPOL = 0.0f;
		NHJKENJIEME = 0;
		EBKOJBFMABH = 0.0f;
	}

	// // RVA: 0xD9872C Offset: 0xD9872C VA: 0xD9872C
	// public void ODJCMJBNDOK() { }

	// // RVA: -1 Offset: -1 Slot: 4
	// public abstract void BDALHEMDIDC();

	// // RVA: -1 Offset: -1 Slot: 5
	// public abstract bool GDEMPLAOGKK();

	// // RVA: -1 Offset: -1 Slot: 6
	// public abstract string LKPOPGJLPAJ();

	// // RVA: 0xD98788 Offset: 0xD98788 VA: 0xD98788 Slot: 7
	// public virtual void GFCMEKDCCME() { }

	// // RVA: 0xD987CC Offset: 0xD987CC VA: 0xD987CC Slot: 8
	// public virtual void GMHKEJMLDDJ() { }

	// // RVA: 0xD987D0 Offset: 0xD987D0 VA: 0xD987D0
	// public bool KIDJFNEGAHO() { }

	// // RVA: 0xD9884C Offset: 0xD9884C VA: 0xD9884C
	// public bool INODGGFPKOE() { }

	// // RVA: 0xD98894 Offset: 0xD98894 VA: 0xD98894 Slot: 9
	public virtual bool MLMEOLAEJEL() 
    { 
        if(DAPCDNJBKBK != null)
		{
			return DAPCDNJBKBK(IMGIFJHHEED);
		}
		return true;
    }

	// // RVA: 0xD988B4 Offset: 0xD988B4 VA: 0xD988B4 Slot: 10
	// public virtual bool HICEMOLOKKF() { }

	// // RVA: 0xD988D4 Offset: 0xD988D4 VA: 0xD988D4
	// public void PEFNBFCMIBL() { }

	// // RVA: 0xD988E4 Offset: 0xD988E4 VA: 0xD988E4
	// public void IPGGCCPIMMI() { }

	// // RVA: 0xD988F4 Offset: 0xD988F4 VA: 0xD988F4 Slot: 11
	// public virtual void PAHHAMPDBFP() { }

	// // RVA: 0xD988F8 Offset: 0xD988F8 VA: 0xD988F8 Slot: 12
	// public virtual void DKNGPHJKGAP() { }

	// // RVA: -1 Offset: -1 Slot: 13
	// public abstract void JNDNHPEIMEI();

	// // RVA: 0xD988FC Offset: 0xD988FC VA: 0xD988FC
	// public void JKONMHNBGLL() { }

	// // RVA: 0xD98908 Offset: 0xD98908 VA: 0xD98908
	// public void JOCCKKMCPAC() { }

	// // RVA: 0xD98914 Offset: 0xD98914 VA: 0xD98914
	// public bool GCPOIANJEOC() { }

	// // RVA: 0xD98928 Offset: 0xD98928 VA: 0xD98928
	// private bool GOGBNFLIJAB(byte[] DBBGALAPFGC, byte[] PJCEJFENECH) { }

	// // RVA: 0xD98AE0 Offset: 0xD98AE0 VA: 0xD98AE0
	protected bool BBGDFKAPJHN(byte[] DBBGALAPFGC) 
    { 
		UnityEngine.Debug.LogError("TODO");
        return false;
    }

	// // RVA: 0xD98EE4 Offset: 0xD98EE4 VA: 0xD98EE4
	// private static void .cctor() { }
}
