using XeSys;

public class MCGNOFMAPBJ
{
	private int FBGGEFFJJHB_xor; // 0x8
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

	public long DLPEEDCCNMJ_CntSaveTime { get {
			if ((EHCBKLCHFHE ^ FBGGEFFJJHB_xor) != DDPGLABEIEM)
				MNJAPFEIOKD |= 1;
			return EHCBKLCHFHE ^ FBGGEFFJJHB_xor;
		} set
		{
			DDPGLABEIEM = value;
			EHCBKLCHFHE = value ^ FBGGEFFJJHB_xor;
		}
	} //0x130CD40 IPMOLPGCIIB_bgs 0x130CB20 POJLMKDPBHI_bgs
	public int NEPIPMPAFIE_CntVal { get // Stamina
		{
			if (PINPIHODOKP != HICKJFPDBEG) // Why, bug ?
			{
				MNJAPFEIOKD |= 2;
			}
			return FBGGEFFJJHB_xor ^ HICKJFPDBEG;
		} set {
			PINPIHODOKP = value;
			if (value < 1)
				PINPIHODOKP = 0;
			if (value > 999)
				PINPIHODOKP = 999;
			HICKJFPDBEG = FBGGEFFJJHB_xor ^ PINPIHODOKP;
		}
	} //0x130CD7C DNNADJLKBPC_bgs 0x130CB40 BJOJAFDBOBL_bgs
	public int DCBENCMNOGO_MaxCount { get // MAxStamina
		{
			if((EMGIAPOEKLL ^ FBGGEFFJJHB_xor) != BPADHGOCPIH)
				MKMBHBOGFHM = MKMBHBOGFHM | 4;
			return EMGIAPOEKLL ^ FBGGEFFJJHB_xor;
		} set
		{
			BPADHGOCPIH = value;
			if (value < 1)
				BPADHGOCPIH = 0;
			if (value > 999)
				BPADHGOCPIH = 999;
			EMGIAPOEKLL = BPADHGOCPIH ^ FBGGEFFJJHB_xor;
		} } //0x130CDA4 HHBCMCGODFP_bgs 0x130CB68 NPANKNNLDOB_bgs
	public long FLJGHBLEDDB_UpdateInterval { get
		{
			if ((JCGIEJGOEIM ^ FBGGEFFJJHB_xor) != OPDBPKLCEFO)
				MNJAPFEIOKD |= 8;
			return JCGIEJGOEIM ^ FBGGEFFJJHB_xor;
		}
		set {
			OPDBPKLCEFO = value;
			JCGIEJGOEIM = value ^ FBGGEFFJJHB_xor;
		} } //0x130CDCC DEOLPKEGHFP_bgs 0x130CB90 OCIMIINBMAD_bgs
	public long FJDBNGEPKHL_Time { get {
			long val = FBGGEFFJJHB_xor ^ HFMOEKIBNKA;
			if((val ^ MKMBHBOGFHM) != 0)
				MKMBHBOGFHM = MKMBHBOGFHM | 0x10;
			return val;
		}
		set {
			MKMBHBOGFHM = value;
			HFMOEKIBNKA = value ^ FBGGEFFJJHB_xor;
		} } //0x130CE08 FIIMIGEKDCM_bgs 0x130CBB0 JFIOOGMDBJD_bgs

	// RVA: 0x130CA20 Offset: 0x130CA20 VA: 0x130CA20
	public MCGNOFMAPBJ()
    {
        long time = Utility.GetCurrentUnixTime();
        FBGGEFFJJHB_xor = (int)time ^ 0x51020427;
		FLJGHBLEDDB_UpdateInterval = 180;
		FJDBNGEPKHL_Time = 0;
		DCBENCMNOGO_MaxCount = 0;
		DLPEEDCCNMJ_CntSaveTime = 0;
		NEPIPMPAFIE_CntVal = 0;
    }

	// // RVA: 0x130CBD0 Offset: 0x130CBD0 VA: 0x130CBD0
	public void ODDIHGPONFL_Copy(MCGNOFMAPBJ GPBJHKLFCEP)
	{
		DLPEEDCCNMJ_CntSaveTime = GPBJHKLFCEP.DLPEEDCCNMJ_CntSaveTime;
		NEPIPMPAFIE_CntVal = GPBJHKLFCEP.NEPIPMPAFIE_CntVal;
		DCBENCMNOGO_MaxCount = GPBJHKLFCEP.DCBENCMNOGO_MaxCount;
		FLJGHBLEDDB_UpdateInterval = GPBJHKLFCEP.FLJGHBLEDDB_UpdateInterval;
		FJDBNGEPKHL_Time = GPBJHKLFCEP.FJDBNGEPKHL_Time;
	}

	// // RVA: 0x130CE44 Offset: 0x130CE44 VA: 0x130CE44 Slot: 4
	public virtual int DCLKMNGMIKC_GetCurrentValue()
	{
		int res = NEPIPMPAFIE_CntVal;
		if(res < DCBENCMNOGO_MaxCount)
		{
			int diff = DCBENCMNOGO_MaxCount - res;
			long timeLeftToFillInSec = diff * FLJGHBLEDDB_UpdateInterval;
			long timeDiff = FJDBNGEPKHL_Time - DLPEEDCCNMJ_CntSaveTime;
			if(timeLeftToFillInSec < timeDiff)
			{
				timeDiff = timeLeftToFillInSec;
			}
			res += (int)(timeDiff / FLJGHBLEDDB_UpdateInterval);
			if (DCBENCMNOGO_MaxCount < res)
				return DCBENCMNOGO_MaxCount;
		}
		return res;
	}

	// // RVA: 0x130D008 Offset: 0x130D008 VA: 0x130D008 Slot: 5
	public virtual long MLLGPBGFLFI_GetRemainingTime()
	{
		if(NEPIPMPAFIE_CntVal < DCBENCMNOGO_MaxCount)
		{
			int staminaDiff = DCBENCMNOGO_MaxCount - NEPIPMPAFIE_CntVal;
			int healTime = (int)(staminaDiff * FLJGHBLEDDB_UpdateInterval);
			if ((FJDBNGEPKHL_Time - DLPEEDCCNMJ_CntSaveTime) < healTime)
			{
				long delta = (healTime - (FJDBNGEPKHL_Time - DLPEEDCCNMJ_CntSaveTime)) / FLJGHBLEDDB_UpdateInterval;
				if(delta != 0)
				{
					return delta;
				}
				return healTime;
			}
		}
		return 0;
	}

	// // RVA: 0x130D15C Offset: 0x130D15C VA: 0x130D15C
	public long LEHHIGOOIJJ()
	{
		if(NEPIPMPAFIE_CntVal < DCBENCMNOGO_MaxCount)
		{
			long v1 = FJDBNGEPKHL_Time - DLPEEDCCNMJ_CntSaveTime;
			long v2 = FLJGHBLEDDB_UpdateInterval * (DCBENCMNOGO_MaxCount - NEPIPMPAFIE_CntVal);
			if(v1 < v2)
			{
				return v2 - v1 + FJDBNGEPKHL_Time;
			}
		}
		return 0;
	}

	// // RVA: 0x130D2AC Offset: 0x130D2AC VA: 0x130D2AC
	public bool IGFMNMADJPP_Consume(int CHIHFGDIBJM, bool _DDGFCOPPBBN_test/* = true*/)
	{
		if(CHIHFGDIBJM <= DCLKMNGMIKC_GetCurrentValue() && _DDGFCOPPBBN_test == false)
		{
			NEPIPMPAFIE_CntVal = DCLKMNGMIKC_GetCurrentValue() - CHIHFGDIBJM;
			if (NEPIPMPAFIE_CntVal < 0)
				NEPIPMPAFIE_CntVal = 0;
			DLPEEDCCNMJ_CntSaveTime = FJDBNGEPKHL_Time;
			if(MLLGPBGFLFI_GetRemainingTime() != 0)
			{
				DLPEEDCCNMJ_CntSaveTime = MLLGPBGFLFI_GetRemainingTime() - FLJGHBLEDDB_UpdateInterval + FJDBNGEPKHL_Time;
			}
			return true;
		}
		else
		{
			return CHIHFGDIBJM <= DCLKMNGMIKC_GetCurrentValue();
		}
	}

	// // RVA: 0x130D3E0 Offset: 0x130D3E0 VA: 0x130D3E0 Slot: 6
	public virtual bool MAPPOEFALIP(int BBCCIJGFKHD, bool MDNODGAFHJN/* = true*/, bool _DDGFCOPPBBN_test/* = true*/)
	{
		int a = DCLKMNGMIKC_GetCurrentValue();
		if(a < DCBENCMNOGO_MaxCount)
		{
			int a2 = DCBENCMNOGO_MaxCount;
			if(MDNODGAFHJN)
				a2 = a + BBCCIJGFKHD;
			if(!_DDGFCOPPBBN_test)
			{
				NEPIPMPAFIE_CntVal = a2;
				DLPEEDCCNMJ_CntSaveTime = FJDBNGEPKHL_Time;
			}
			return true;
		}
		return false;
	}

	// // RVA: 0x130D4C8 Offset: 0x130D4C8 VA: 0x130D4C8
	public bool FCEMLLDEJFL(bool MDNODGAFHJN/* = true*/, bool _DDGFCOPPBBN_test/* = true*/)
	{
		return MAPPOEFALIP(DCBENCMNOGO_MaxCount, MDNODGAFHJN, _DDGFCOPPBBN_test);
	}

	// // RVA: 0x130D520 Offset: 0x130D520 VA: 0x130D520
	public void GFOAJNICANO(int GDDFDGNEACK)
	{
		int cur = DCLKMNGMIKC_GetCurrentValue();
		cur += GDDFDGNEACK;
		NEPIPMPAFIE_CntVal = cur;
		DLPEEDCCNMJ_CntSaveTime = FJDBNGEPKHL_Time;
		DCBENCMNOGO_MaxCount = GDDFDGNEACK;
	}
}

public class KAFHAKBBJEI : MCGNOFMAPBJ
{
	// RVA: 0x1BA9BE4 Offset: 0x1BA9BE4 VA: 0x1BA9BE4 Slot: 6
	public override bool MAPPOEFALIP(int BBCCIJGFKHD, bool MDNODGAFHJN/* = True*/, bool _DDGFCOPPBBN_test/* = True*/)
	{
		if(DCLKMNGMIKC_GetCurrentValue() < DCBENCMNOGO_MaxCount)
		{
			long r = MLLGPBGFLFI_GetRemainingTime();
			int v;
			if(!MDNODGAFHJN)
			{
				v = DCBENCMNOGO_MaxCount;
			}
			else
			{
				v = DCLKMNGMIKC_GetCurrentValue() + BBCCIJGFKHD;
			}
			if(!_DDGFCOPPBBN_test)
			{
				NEPIPMPAFIE_CntVal = v;
				DLPEEDCCNMJ_CntSaveTime = FJDBNGEPKHL_Time;
				if(r != 0)
				{
					DLPEEDCCNMJ_CntSaveTime = DLPEEDCCNMJ_CntSaveTime + r - FLJGHBLEDDB_UpdateInterval;
				}
			}
			return true;
		}
		return false;
	}
}
