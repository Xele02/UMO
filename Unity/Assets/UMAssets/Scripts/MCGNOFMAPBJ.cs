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

	public long DLPEEDCCNMJ_StaminaSaveTime { get {
			if ((EHCBKLCHFHE ^ FBGGEFFJJHB) != DDPGLABEIEM)
				MNJAPFEIOKD |= 1;
			return EHCBKLCHFHE ^ FBGGEFFJJHB;
		} set
		{
			DDPGLABEIEM = value;
			EHCBKLCHFHE = value ^ FBGGEFFJJHB;
		}
	} //0x130CD40 IPMOLPGCIIB 0x130CB20 POJLMKDPBHI
	public int NEPIPMPAFIE_Stamina { get
		{
			if (PINPIHODOKP != HICKJFPDBEG) // Why, bug ?
			{
				MNJAPFEIOKD |= 2;
			}
			return FBGGEFFJJHB ^ HICKJFPDBEG;
		} set {
			PINPIHODOKP = value;
			if (value < 1)
				PINPIHODOKP = 0;
			if (value > 999)
				PINPIHODOKP = 999;
			HICKJFPDBEG = FBGGEFFJJHB ^ PINPIHODOKP;
		}
	} //0x130CD7C DNNADJLKBPC 0x130CB40 BJOJAFDBOBL
	public int DCBENCMNOGO_MaxStamina { get
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
	public long FLJGHBLEDDB_HealSec { get
		{
			if ((JCGIEJGOEIM ^ FBGGEFFJJHB) != OPDBPKLCEFO)
				MNJAPFEIOKD |= 8;
			return JCGIEJGOEIM ^ FBGGEFFJJHB;
		}
		set {
			OPDBPKLCEFO = value;
			JCGIEJGOEIM = value ^ FBGGEFFJJHB;
		} } //0x130CDCC DEOLPKEGHFP 0x130CB90 OCIMIINBMAD
	public long FJDBNGEPKHL_Time { get {
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
		FLJGHBLEDDB_HealSec = 180;
		FJDBNGEPKHL_Time = 0;
		DCBENCMNOGO_MaxStamina = 0;
		DLPEEDCCNMJ_StaminaSaveTime = 0;
		NEPIPMPAFIE_Stamina = 0;
    }

	// // RVA: 0x130CBD0 Offset: 0x130CBD0 VA: 0x130CBD0
	public void ODDIHGPONFL(MCGNOFMAPBJ GPBJHKLFCEP)
	{
		DLPEEDCCNMJ_StaminaSaveTime = GPBJHKLFCEP.DLPEEDCCNMJ_StaminaSaveTime;
		NEPIPMPAFIE_Stamina = GPBJHKLFCEP.NEPIPMPAFIE_Stamina;
		DCBENCMNOGO_MaxStamina = GPBJHKLFCEP.DCBENCMNOGO_MaxStamina;
		FLJGHBLEDDB_HealSec = GPBJHKLFCEP.FLJGHBLEDDB_HealSec;
		FJDBNGEPKHL_Time = GPBJHKLFCEP.FJDBNGEPKHL_Time;
	}

	// // RVA: 0x130CE44 Offset: 0x130CE44 VA: 0x130CE44 Slot: 4
	public virtual int DCLKMNGMIKC_GetCurrent()
	{
		int res = NEPIPMPAFIE_Stamina;
		if(res < DCBENCMNOGO_MaxStamina)
		{
			int diff = DCBENCMNOGO_MaxStamina - res;
			long timeLeftToFillInSec = diff * FLJGHBLEDDB_HealSec;
			long timeDiff = FJDBNGEPKHL_Time - DLPEEDCCNMJ_StaminaSaveTime;
			if(timeLeftToFillInSec < timeDiff)
			{
				timeDiff = timeLeftToFillInSec;
			}
			res += (int)(timeDiff / FLJGHBLEDDB_HealSec);
			if (DCBENCMNOGO_MaxStamina < res)
				return DCBENCMNOGO_MaxStamina;
		}
		return res;
	}

	// // RVA: 0x130D008 Offset: 0x130D008 VA: 0x130D008 Slot: 5
	public virtual long MLLGPBGFLFI_GetRemainingTime()
	{
		if(NEPIPMPAFIE_Stamina < DCBENCMNOGO_MaxStamina)
		{
			int staminaDiff = DCBENCMNOGO_MaxStamina - NEPIPMPAFIE_Stamina;
			int healTime = (int)(staminaDiff * FLJGHBLEDDB_HealSec);
			if ((FJDBNGEPKHL_Time - DLPEEDCCNMJ_StaminaSaveTime) < healTime)
			{
				long delta = (healTime - (FJDBNGEPKHL_Time - DLPEEDCCNMJ_StaminaSaveTime)) / FLJGHBLEDDB_HealSec;
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
		if(NEPIPMPAFIE_Stamina < DCBENCMNOGO_MaxStamina)
		{
			long v1 = FJDBNGEPKHL_Time - DLPEEDCCNMJ_StaminaSaveTime;
			long v2 = FLJGHBLEDDB_HealSec * (DCBENCMNOGO_MaxStamina - NEPIPMPAFIE_Stamina);
			if(v1 < v2)
			{
				return v2 - v1 + FJDBNGEPKHL_Time;
			}
		}
		return 0;
	}

	// // RVA: 0x130D2AC Offset: 0x130D2AC VA: 0x130D2AC
	public bool IGFMNMADJPP_Consume(int CHIHFGDIBJM, bool _DDGFCOPPBBN_CheckOnly = true)
	{
		if(CHIHFGDIBJM <= DCLKMNGMIKC_GetCurrent() && _DDGFCOPPBBN_CheckOnly == false)
		{
			NEPIPMPAFIE_Stamina = DCLKMNGMIKC_GetCurrent() - CHIHFGDIBJM;
			if (NEPIPMPAFIE_Stamina < 0)
				NEPIPMPAFIE_Stamina = 0;
			DLPEEDCCNMJ_StaminaSaveTime = FJDBNGEPKHL_Time;
			if(MLLGPBGFLFI_GetRemainingTime() != 0)
			{
				DLPEEDCCNMJ_StaminaSaveTime = MLLGPBGFLFI_GetRemainingTime() - FLJGHBLEDDB_HealSec + FJDBNGEPKHL_Time;
			}
			return true;
		}
		else
		{
			return CHIHFGDIBJM <= DCLKMNGMIKC_GetCurrent();
		}
	}

	// // RVA: 0x130D3E0 Offset: 0x130D3E0 VA: 0x130D3E0 Slot: 6
	public virtual bool MAPPOEFALIP(int BBCCIJGFKHD, bool MDNODGAFHJN = true, bool DDGFCOPPBBN = true)
	{
		int a = DCLKMNGMIKC_GetCurrent();
		if(a < DCBENCMNOGO_MaxStamina)
		{
			int a2 = DCBENCMNOGO_MaxStamina;
			if(MDNODGAFHJN)
				a2 = a + BBCCIJGFKHD;
			if(!DDGFCOPPBBN)
			{
				NEPIPMPAFIE_Stamina = a2;
				DLPEEDCCNMJ_StaminaSaveTime = FJDBNGEPKHL_Time;
			}
			return true;
		}
		return false;
	}

	// // RVA: 0x130D4C8 Offset: 0x130D4C8 VA: 0x130D4C8
	public bool FCEMLLDEJFL(bool MDNODGAFHJN = true, bool DDGFCOPPBBN = true)
	{
		return MAPPOEFALIP(DCBENCMNOGO_MaxStamina, MDNODGAFHJN, DDGFCOPPBBN);
	}

	// // RVA: 0x130D520 Offset: 0x130D520 VA: 0x130D520
	public void GFOAJNICANO(int GDDFDGNEACK)
	{
		int cur = DCLKMNGMIKC_GetCurrent();
		cur += GDDFDGNEACK;
		NEPIPMPAFIE_Stamina = cur;
		DLPEEDCCNMJ_StaminaSaveTime = FJDBNGEPKHL_Time;
		DCBENCMNOGO_MaxStamina = GDDFDGNEACK;
	}
}

public class KAFHAKBBJEI : MCGNOFMAPBJ
{
	// RVA: 0x1BA9BE4 Offset: 0x1BA9BE4 VA: 0x1BA9BE4 Slot: 6
	public override bool MAPPOEFALIP(int BBCCIJGFKHD, bool MDNODGAFHJN/* = True*/, bool DDGFCOPPBBN/* = True*/)
	{
		if(DCLKMNGMIKC_GetCurrent() < DCBENCMNOGO_MaxStamina)
		{
			long r = MLLGPBGFLFI_GetRemainingTime();
			int v;
			if(!MDNODGAFHJN)
			{
				v = DCBENCMNOGO_MaxStamina;
			}
			else
			{
				v = DCLKMNGMIKC_GetCurrent() + BBCCIJGFKHD;
			}
			if(!DDGFCOPPBBN)
			{
				NEPIPMPAFIE_Stamina = v;
				DLPEEDCCNMJ_StaminaSaveTime = FJDBNGEPKHL_Time;
				if(r != 0)
				{
					DLPEEDCCNMJ_StaminaSaveTime = DLPEEDCCNMJ_StaminaSaveTime + r - FLJGHBLEDDB_HealSec;
				}
			}
		}
		return false;
	}
}
