using XeSys;

public class MCGNOFMAPBJ
{
	private int FBGGEFFJJHB; // 0x8
	private long DDPGLABEIEM; // 0x10
	private int PINPIHODOKP; // 0x18
	private int BPADHGOCPIH; // 0x1C
	private long OPDBPKLCEFO; // 0x20
	private long MKMBHBOGFHM; // 0x28
	private long EHCBKLCHFHE; // 0x30
	private int HICKJFPDBEG; // 0x38
	private int EMGIAPOEKLL; // 0x3C
	private long JCGIEJGOEIM; // 0x40
	private long HFMOEKIBNKA; // 0x48
	private int MNJAPFEIOKD; // 0x50
	private const int FGPCFEMHOGO = 999;

	// public long DLPEEDCCNMJ { get; set; } 0x130CD40 IPMOLPGCIIB 0x130CB20 POJLMKDPBHI
	// public int NEPIPMPAFIE { get; set; } 0x130CD7C DNNADJLKBPC 0x130CB40 BJOJAFDBOBL
	public int DCBENCMNOGO { get
		{
			if((EMGIAPOEKLL ^ FBGGEFFJJHB) != BPADHGOCPIH)
				MKMBHBOGFHM = MKMBHBOGFHM | 4;
			return EMGIAPOEKLL ^ FBGGEFFJJHB;
		} set
		{
			BPADHGOCPIH = value;
			if (value < 1)
				BPADHGOCPIH = 0;
			if (value > 999)
				BPADHGOCPIH = 999;
			EMGIAPOEKLL = BPADHGOCPIH ^ FBGGEFFJJHB;
		} } //0x130CDA4 HHBCMCGODFP 0x130CB68 NPANKNNLDOB
	// public long FLJGHBLEDDB { get; set; } 0x130CDCC DEOLPKEGHFP 0x130CB90 OCIMIINBMAD
	public long FJDBNGEPKHL { get {
			long val = FBGGEFFJJHB ^ HFMOEKIBNKA;
			if((val ^ MKMBHBOGFHM) != 0)
				MKMBHBOGFHM = MKMBHBOGFHM | 0x10;
			return val;
		}
		set {
			MKMBHBOGFHM = value;
			HFMOEKIBNKA = value ^ FBGGEFFJJHB;
		} } //0x130CE08 FIIMIGEKDCM 0x130CBB0 JFIOOGMDBJD

	// RVA: 0x130CA20 Offset: 0x130CA20 VA: 0x130CA20
	public MCGNOFMAPBJ()
    {
        long time = Utility.GetCurrentUnixTime();
        FBGGEFFJJHB = (int)time ^ 0x51020427;
        OPDBPKLCEFO = 180;
        MKMBHBOGFHM = 0;
        DDPGLABEIEM = 0;
        PINPIHODOKP = 0;
        BPADHGOCPIH = 0;
        EHCBKLCHFHE = FBGGEFFJJHB;
        HICKJFPDBEG = FBGGEFFJJHB;
        EMGIAPOEKLL = FBGGEFFJJHB;
        JCGIEJGOEIM = (int)time ^ 0x51020493;
        HFMOEKIBNKA = FBGGEFFJJHB;
    }

	// // RVA: 0x130CBD0 Offset: 0x130CBD0 VA: 0x130CBD0
	// public void ODDIHGPONFL(MCGNOFMAPBJ GPBJHKLFCEP) { }

	// // RVA: 0x130CE44 Offset: 0x130CE44 VA: 0x130CE44 Slot: 4
	public virtual int DCLKMNGMIKC()
	{
		TodoLogger.Log(0, "DCLKMNGMIKC");
		return 0;
	}

	// // RVA: 0x130D008 Offset: 0x130D008 VA: 0x130D008 Slot: 5
	// public virtual long MLLGPBGFLFI() { }

	// // RVA: 0x130D15C Offset: 0x130D15C VA: 0x130D15C
	// public long LEHHIGOOIJJ() { }

	// // RVA: 0x130D2AC Offset: 0x130D2AC VA: 0x130D2AC
	// public bool IGFMNMADJPP(int CHIHFGDIBJM, bool DDGFCOPPBBN = True) { }

	// // RVA: 0x130D3E0 Offset: 0x130D3E0 VA: 0x130D3E0 Slot: 6
	// public virtual bool MAPPOEFALIP(int BBCCIJGFKHD, bool MDNODGAFHJN = True, bool DDGFCOPPBBN = True) { }

	// // RVA: 0x130D4C8 Offset: 0x130D4C8 VA: 0x130D4C8
	// public bool FCEMLLDEJFL(bool MDNODGAFHJN = True, bool DDGFCOPPBBN = True) { }

	// // RVA: 0x130D520 Offset: 0x130D520 VA: 0x130D520
	// public void GFOAJNICANO(int GDDFDGNEACK) { }
}
