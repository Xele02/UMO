
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use LDEBIBGHCGD_EventRaidLobby", true)]
public class LDEBIBGHCGD { }
public class LDEBIBGHCGD_EventRaidLobby : DIHHCBACKGG_DbSection
{
	public class NBGDKOACGLM
	{
		public int OBGBAOLONDD_EventId; // 0x8
		public string OPFGFINHFCE_Name; // 0xC
		public long CJPMLAIFCDL_LobbyStart; // 0x10
		public long COIHIAKHFNF_End; // 0x18
		public long NIMLIMFPNJP_RaidStart; // 0x20
		public long KCBGBFMGHPA_End; // 0x28
		public int MJBKGOJBPAD_TicketType; // 0x30
		public sbyte MOEKELIIDEO_SaveIdx; // 0x34
		public int[] EJBGHLOOLBC_HelpIds; // 0x38

		//// RVA: 0xD65AB4 Offset: 0xD65AB4 VA: 0xD65AB4
		public void LHPDDGIJKNB()
		{
			NIMLIMFPNJP_RaidStart = 0;
			KCBGBFMGHPA_End = 0;
			CJPMLAIFCDL_LobbyStart = 0;
			COIHIAKHFNF_End = 0;
			MOEKELIIDEO_SaveIdx = 0;
			OBGBAOLONDD_EventId = 0;
			OPFGFINHFCE_Name = "";
			MJBKGOJBPAD_TicketType = 1;
			EJBGHLOOLBC_HelpIds = null;
		}

		//// RVA: 0xD66A20 Offset: 0xD66A20 VA: 0xD66A20
		//public uint CAOGDCBPBAN() { }
	}

	public class HDFAGGBJGAA
	{
		public int PPFNGGCBJKC_GroupId; // 0x8
		public int AACHOBAAALA; // 0xC
		public string OPFGFINHFCE; // 0x10
		public string HEDAGCNPHGD_Key; // 0x14
		public List<int> OCDBMHBNLEF; // 0x18

		// RVA: 0xD664B0 Offset: 0xD664B0 VA: 0xD664B0
		public HDFAGGBJGAA(int OIPCCBHIKIA, BFOKFIJNCJJ IDLHJIOMJBK)
		{
			PPFNGGCBJKC_GroupId = OIPCCBHIKIA + 1;
			AACHOBAAALA = (int)IDLHJIOMJBK.PPFNGGCBJKC;
			OPFGFINHFCE = IDLHJIOMJBK.OPFGFINHFCE;
			HEDAGCNPHGD_Key = IDLHJIOMJBK.HEDAGCNPHGD;
			OCDBMHBNLEF = new List<int>(IDLHJIOMJBK.OCDBMHBNLEF.Length);
			for(int i = 0; i < IDLHJIOMJBK.OCDBMHBNLEF.Length; i++)
			{
				OCDBMHBNLEF.Add((int)IDLHJIOMJBK.OCDBMHBNLEF[i]);
			}
		}

		//// RVA: 0xD66ADC Offset: 0xD66ADC VA: 0xD66ADC
		//public uint CAOGDCBPBAN() { }
	}

	public class LNECBHIKKHK
	{
		public int PPFNGGCBJKC; // 0x8
		public int GJNIPHMPMIC_Phase; // 0xC
		public int INDDJNMPONH; // 0x10
		public int FDBOPFEOENF_Id; // 0x14
		public int MJMPANIBFED_Pic; // 0x18
		public string LICPCDCLOIO_Message; // 0x1C

		//// RVA: 0xD666C8 Offset: 0xD666C8 VA: 0xD666C8
		public LNECBHIKKHK(PALCPDPGOPC IDLHJIOMJBK)
		{
			PPFNGGCBJKC = (int)IDLHJIOMJBK.PPFNGGCBJKC;
			GJNIPHMPMIC_Phase = (int)IDLHJIOMJBK.GJNIPHMPMIC;
			INDDJNMPONH = (int)IDLHJIOMJBK.GBJFNGCDKPM;
			FDBOPFEOENF_Id = (int)IDLHJIOMJBK.FDBOPFEOENF;
			MJMPANIBFED_Pic = (int)IDLHJIOMJBK.MJMPANIBFED;
			LICPCDCLOIO_Message = IDLHJIOMJBK.LICPCDCLOIO;
		}

		//// RVA: 0xD66BB8 Offset: 0xD66BB8 VA: 0xD66BB8
		//public uint CAOGDCBPBAN() { }
	}

	public NBGDKOACGLM NGHKJOEDLIP = new NBGDKOACGLM(); // 0x20
	public List<HDFAGGBJGAA> OJGPPOKENLG_Lobbies = new List<HDFAGGBJGAA>(); // 0x24
	public List<LNECBHIKKHK> OIIMJFCBFFG = new List<LNECBHIKKHK>(); // 0x28
	public List<AKIIJBEJOEP> NNMPGOAGEOL_Missions = new List<AKIIJBEJOEP>(); // 0x2C

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI { get; private set; } // 0x30 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK { get; private set; } // 0x34 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0xD65550 Offset: 0xD65550 VA: 0xD65550
	public HDFAGGBJGAA HMHGPIEBKPO(int PPFNGGCBJKC)
	{
		if(PPFNGGCBJKC > 0 && PPFNGGCBJKC <= OJGPPOKENLG_Lobbies.Count)
			return OJGPPOKENLG_Lobbies[PPFNGGCBJKC - 1];
		return null;
	}

	//// RVA: 0xD65610 Offset: 0xD65610 VA: 0xD65610
	public string EFEGBHACJAL(string LJNAKDMILMC, string KKMJBMKHGNH)
	{
		if(!FJOEBCMGDMI.ContainsKey(LJNAKDMILMC))
			return KKMJBMKHGNH;
		return FJOEBCMGDMI[LJNAKDMILMC].DNJEJEANJGL_Value;
	}

	//// RVA: 0xD656F4 Offset: 0xD656F4 VA: 0xD656F4
	public int LPJLEHAJADA(string LJNAKDMILMC, int KKMJBMKHGNH)
	{
		if(!OHJFBLFELNK.ContainsKey(LJNAKDMILMC))
			return KKMJBMKHGNH;
		return OHJFBLFELNK[LJNAKDMILMC].DNJEJEANJGL_Value;
	}

	// RVA: 0xD657D8 Offset: 0xD657D8 VA: 0xD657D8
	public LDEBIBGHCGD_EventRaidLobby()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		OHJFBLFELNK = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		LMHMIIKCGPE = 39;
	}

	// RVA: 0xD659C8 Offset: 0xD659C8 VA: 0xD659C8 Slot: 8
	protected override void KMBPACJNEOF()
	{
		NGHKJOEDLIP.LHPDDGIJKNB();
		NNMPGOAGEOL_Missions.Clear();
		OHJFBLFELNK.Clear();
		FJOEBCMGDMI.Clear();
	}

	// RVA: 0xD65B3C Offset: 0xD65B3C VA: 0xD65B3C Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		MAGFOKIIPPD data = MAGFOKIIPPD.HEGEKFMJNCC(DBBGALAPFGC);
		DGKKMKLCEDF(data);
		FOPPFILCLDJ(data);
		JIBKOEFOAPG(data);
		CFOFJPLEDEA(data);
		for(int i = 0; i < data.BHGDNGHDDAC.Length; i++)
		{
			CEBFFLDKAEC_SecureInt d = new CEBFFLDKAEC_SecureInt();
			d.DNJEJEANJGL_Value = data.BHGDNGHDDAC[i].JBGEEPFKIGG;
			OHJFBLFELNK.Add(data.BHGDNGHDDAC[i].LJNAKDMILMC, d);
		}
		for(int i = 0; i < data.MHGMDJNOLMI.Length; i++)
		{
			NNJFKLBPBNK_SecureString d = new NNJFKLBPBNK_SecureString();
			d.DNJEJEANJGL_Value = data.MHGMDJNOLMI[i].JBGEEPFKIGG;
			FJOEBCMGDMI.Add(data.MHGMDJNOLMI[i].LJNAKDMILMC, d);
		}
		return true;
	}

	//// RVA: 0xD65E34 Offset: 0xD65E34 VA: 0xD65E34
	private bool DGKKMKLCEDF(MAGFOKIIPPD KNOEHKKNIJA)
	{
		NGHKJOEDLIP.OBGBAOLONDD_EventId = (int)KNOEHKKNIJA.HMBHNLCFDIH.OBGBAOLONDD;
		NGHKJOEDLIP.OPFGFINHFCE_Name = KNOEHKKNIJA.HMBHNLCFDIH.OPFGFINHFCE;
		NGHKJOEDLIP.CJPMLAIFCDL_LobbyStart = KNOEHKKNIJA.HMBHNLCFDIH.BONDDBOFBND;
		NGHKJOEDLIP.COIHIAKHFNF_End = KNOEHKKNIJA.HMBHNLCFDIH.KNLGKBBIBOH;
		NGHKJOEDLIP.NIMLIMFPNJP_RaidStart = KNOEHKKNIJA.HMBHNLCFDIH.NIMLIMFPNJP;
		NGHKJOEDLIP.KCBGBFMGHPA_End = KNOEHKKNIJA.HMBHNLCFDIH.KCBGBFMGHPA;
		NGHKJOEDLIP.MOEKELIIDEO_SaveIdx = (sbyte)KNOEHKKNIJA.HMBHNLCFDIH.MOEKELIIDEO;
		NGHKJOEDLIP.MJBKGOJBPAD_TicketType = KNOEHKKNIJA.HMBHNLCFDIH.MJBKGOJBPAD;
		NGHKJOEDLIP.EJBGHLOOLBC_HelpIds = KNOEHKKNIJA.HMBHNLCFDIH.EJBGHLOOLBC;
		return true;
	}

	//// RVA: 0xD66084 Offset: 0xD66084 VA: 0xD66084
	private bool FOPPFILCLDJ(MAGFOKIIPPD KNOEHKKNIJA)
	{
		for(int i = 0; i < KNOEHKKNIJA.KBFEMKJBHBL.Length; i++)
		{
			HDFAGGBJGAA data = new HDFAGGBJGAA(i, KNOEHKKNIJA.KBFEMKJBHBL[i]);
			OJGPPOKENLG_Lobbies.Add(data);
		}
		return true;
	}

	//// RVA: 0xD661D0 Offset: 0xD661D0 VA: 0xD661D0
	private bool JIBKOEFOAPG(MAGFOKIIPPD KNOEHKKNIJA)
	{
		for(int i = 0; i < KNOEHKKNIJA.CEPBAOMAHNH.Length; i++)
		{
			LNECBHIKKHK data = new LNECBHIKKHK(KNOEHKKNIJA.CEPBAOMAHNH[i]);
			OIIMJFCBFFG.Add(data);
		}
		return true;
	}

	//// RVA: 0xD66318 Offset: 0xD66318 VA: 0xD66318
	private bool CFOFJPLEDEA(MAGFOKIIPPD KNOEHKKNIJA)
	{
		int xor = (int)Utility.GetCurrentUnixTime() * 11 + 1;
		for(int i = 0; i < KNOEHKKNIJA.CEPBAOMAHNH.Length; i++)
		{
			AKIIJBEJOEP data = new AKIIJBEJOEP();
			data.KHEKNNFCAOI(JIKKNHIAEKG_BlockName, i + 1, xor, KNOEHKKNIJA);
			NNMPGOAGEOL_Missions.Add(data);
			xor += 13;
		}
		return true;
	}

	// RVA: 0xD667D0 Offset: 0xD667D0 VA: 0xD667D0 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "LDEBIBGHCGD_EventRaidLobby.CAOGDCBPBAN");
		return 0;
	}
}
