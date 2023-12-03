
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use KCGOMAFPGDD_EventAprilFool", true)]
public class KCGOMAFPGDD { }
public class KCGOMAFPGDD_EventAprilFool : DIHHCBACKGG_DbSection
{
	public class OEHCHEEEBDC
	{
		public int OBGBAOLONDD; // 0x8
		public string OPFGFINHFCE; // 0xC
		public string HEDAGCNPHGD; // 0x10
		public string OCGFKMHNEOF_Key; // 0x14
		public long BONDDBOFBND_Start; // 0x18
		public long HPNOGLIFJOP_End1; // 0x20
		public long LNFKGHNHJKE; // 0x28
		public long JGMDAOACOJF; // 0x30
		public long IDDBFFBPNGI; // 0x38
		public long KNLGKBBIBOH_End; // 0x40
		public int KHIKEGLBGAF; // 0x48
		public sbyte POGEFBMBPCB; // 0x4C
		public sbyte AHKNMANFILO; // 0x4D
		public sbyte MOEKELIIDEO_SaveIdx; // 0x4E
		public int OILIKPOBBGD; // 0x50
		public int AMCPINEGNPG; // 0x54
		public int HBACKHIOIBG; // 0x58
		public int BMKDEHFGHFG; // 0x5C
		public int OFGDLGBFOOA; // 0x60
		private NNJFKLBPBNK_SecureString EBGIDCIIGDO = new NNJFKLBPBNK_SecureString(); // 0x64
		private NNJFKLBPBNK_SecureString NJKIMJAFCPC = new NNJFKLBPBNK_SecureString(); // 0x68
		public sbyte AHKPNPNOAMO; // 0x6C
		public sbyte HKKNEAGCIEB; // 0x6D
		public List<int> CAPAPAABKDP = new List<int>(); // 0x70
		public List<int> JHPCPNJJHLI = new List<int>(); // 0x74

		public string OCDMGOGMHGE { get { return EBGIDCIIGDO.DNJEJEANJGL_Value; } set { EBGIDCIIGDO.DNJEJEANJGL_Value = value; } } //0x1021EE8 HBAAAKFHDBB 0x102138C NHJLJOIPOFK
		public string PJBILOFOCIC { get { return NJKIMJAFCPC.DNJEJEANJGL_Value; } set { NJKIMJAFCPC.DNJEJEANJGL_Value = value; } } //0x1021F14 NOEFEAIFHCL 0x10213C0 GJIJFGNONEL

		//// RVA: 0x102041C Offset: 0x102041C VA: 0x102041C
		public void LHPDDGIJKNB()
		{
			BONDDBOFBND_Start = 0;
			HPNOGLIFJOP_End1 = 0;
			JGMDAOACOJF = 0;
			IDDBFFBPNGI = 0;
			OBGBAOLONDD = 0;
			OPFGFINHFCE = "";
			HEDAGCNPHGD = "";
			OCGFKMHNEOF_Key = "";
			MOEKELIIDEO_SaveIdx = 0;
			POGEFBMBPCB = 0;
			AHKNMANFILO = 0;
			KHIKEGLBGAF = 0;
			OCDMGOGMHGE = "";
			PJBILOFOCIC = "";
			CAPAPAABKDP.Clear();
			OILIKPOBBGD = 0;
			AMCPINEGNPG = 0;
			HBACKHIOIBG = 0;
			BMKDEHFGHFG = 0;
			OFGDLGBFOOA = 0;
			HKKNEAGCIEB = 0;
			JHPCPNJJHLI.Clear();
		}

		//// RVA: 0x1021A64 Offset: 0x1021A64 VA: 0x1021A64
		//public uint CAOGDCBPBAN() { }
	}

	public class EIEGCBJHGCP
	{
		public int PPFNGGCBJKC_Id; // 0x8
		public int PLALNIIBLOF_Enabled; // 0xC
		public int MPLGPBNJDJB_FreeMusicId; // 0x10
		public int LGADCGFMLLD_Step; // 0x14
		public int MLKFDMFDFCE_EnemyCSkill; // 0x18
		public int DKOPDNHDLIA_EnemyLSkill; // 0x1C
		public long PDBPFJJCADD_OpenAt; // 0x20
		public long FDBNFFNFOND_CloseAt; // 0x28

		//// RVA: 0x1021B9C Offset: 0x1021B9C VA: 0x1021B9C
		//public void LHPDDGIJKNB(int PPFNGGCBJKC) { }

		//// RVA: 0x1021BC0 Offset: 0x1021BC0 VA: 0x1021BC0
		//public void KHEKNNFCAOI(int PPFNGGCBJKC, EDOHBJAPLPF_JsonData IDLHJIOMJBK) { }

		//// RVA: 0x10215A0 Offset: 0x10215A0 VA: 0x10215A0
		public void KHEKNNFCAOI(int PPFNGGCBJKC, OLLJFONKEKO JMHECKKKMLK)
		{
			PPFNGGCBJKC_Id = PPFNGGCBJKC;
			FDBNFFNFOND_CloseAt = 0;
			DKOPDNHDLIA_EnemyLSkill = 0;
			PDBPFJJCADD_OpenAt = 0;
			PLALNIIBLOF_Enabled = 0;
			MPLGPBNJDJB_FreeMusicId = 0;
			LGADCGFMLLD_Step = 0;
			MLKFDMFDFCE_EnemyCSkill = 0;

			PPFNGGCBJKC_Id = (int)JMHECKKKMLK.GHIHAGAOPNC[PPFNGGCBJKC - 1].PPFNGGCBJKC;
			PLALNIIBLOF_Enabled = (int)JMHECKKKMLK.GHIHAGAOPNC[PPFNGGCBJKC - 1].PLALNIIBLOF;
			MPLGPBNJDJB_FreeMusicId = (int)JMHECKKKMLK.GHIHAGAOPNC[PPFNGGCBJKC - 1].MPLGPBNJDJB;
			LGADCGFMLLD_Step = (int)JMHECKKKMLK.GHIHAGAOPNC[PPFNGGCBJKC - 1].LGADCGFMLLD;
			MLKFDMFDFCE_EnemyCSkill = (int)JMHECKKKMLK.GHIHAGAOPNC[PPFNGGCBJKC - 1].MLKFDMFDFCE;
			DKOPDNHDLIA_EnemyLSkill = (int)JMHECKKKMLK.GHIHAGAOPNC[PPFNGGCBJKC - 1].DKOPDNHDLIA;
			PDBPFJJCADD_OpenAt = JMHECKKKMLK.GHIHAGAOPNC[PPFNGGCBJKC - 1].PDBPFJJCADD;
			FDBNFFNFOND_CloseAt = JMHECKKKMLK.GHIHAGAOPNC[PPFNGGCBJKC - 1].FDBNFFNFOND;
		}

		//// RVA: 0x1021E9C Offset: 0x1021E9C VA: 0x1021E9C
		//public uint CAOGDCBPBAN() { }
	}

	public class BMLAHOGDIAK
	{
		public int PPFNGGCBJKC; // 0x8
		public int KFCIJBLDHOK; // 0xC
		public int JLEIHOEGMOP; // 0x10
	}

	public OEHCHEEEBDC NGHKJOEDLIP = new OEHCHEEEBDC(); // 0x20
	public List<EIEGCBJHGCP> IJJHFGOIDOK_Songs = new List<EIEGCBJHGCP>(); // 0x24
	public List<AKIIJBEJOEP> NNMPGOAGEOL_Missions = new List<AKIIJBEJOEP>(); // 0x28
	public List<BMLAHOGDIAK> ADPFKHEMNBL = new List<BMLAHOGDIAK>(); // 0x34
	public List<int> IHKIFGPICLG_HelpIds = new List<int>(); // 0x38

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI { get; private set; } // 0x2C IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK { get; private set; } // 0x30 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0x101FE9C Offset: 0x101FE9C VA: 0x101FE9C
	public string EFEGBHACJAL(string LJNAKDMILMC, string KKMJBMKHGNH)
	{
		if (!FJOEBCMGDMI.ContainsKey(LJNAKDMILMC))
			return KKMJBMKHGNH;
		return FJOEBCMGDMI[LJNAKDMILMC].DNJEJEANJGL_Value;
	}

	//// RVA: 0x101FF80 Offset: 0x101FF80 VA: 0x101FF80
	public int LPJLEHAJADA(string LJNAKDMILMC, int KKMJBMKHGNH)
	{
		if (!OHJFBLFELNK.ContainsKey(LJNAKDMILMC))
			return KKMJBMKHGNH;
		return OHJFBLFELNK[LJNAKDMILMC].DNJEJEANJGL_Value;
	}

	// RVA: 0x1020064 Offset: 0x1020064 VA: 0x1020064
	public KCGOMAFPGDD_EventAprilFool()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		FJOEBCMGDMI = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		OHJFBLFELNK = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		LMHMIIKCGPE = 27;
	}

	// RVA: 0x102035C Offset: 0x102035C VA: 0x102035C Slot: 8
	protected override void KMBPACJNEOF()
	{
		NGHKJOEDLIP.LHPDDGIJKNB();
		OHJFBLFELNK.Clear();
		FJOEBCMGDMI.Clear();
	}

	// RVA: 0x1020530 Offset: 0x1020530 VA: 0x1020530 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		OLLJFONKEKO reader = OLLJFONKEKO.HEGEKFMJNCC(DBBGALAPFGC);
		DGKKMKLCEDF(reader);
		GJEHPJJBCDE(reader);
		CFOFJPLEDEA(reader);
		for (int i = 0; i < reader.BHGDNGHDDAC.Length; i++)
		{
			CEBFFLDKAEC_SecureInt v = new CEBFFLDKAEC_SecureInt();
			v.DNJEJEANJGL_Value = reader.BHGDNGHDDAC[i].JBGEEPFKIGG;
			OHJFBLFELNK.Add(reader.BHGDNGHDDAC[i].LJNAKDMILMC, v);
		}
		for (int i = 0; i < reader.MHGMDJNOLMI.Length; i++)
		{
			NNJFKLBPBNK_SecureString v = new NNJFKLBPBNK_SecureString();
			v.DNJEJEANJGL_Value = reader.MHGMDJNOLMI[i].JBGEEPFKIGG;
			FJOEBCMGDMI.Add(reader.MHGMDJNOLMI[i].LJNAKDMILMC, v);
		}
		string s = EFEGBHACJAL("help_id", "0");
		string[] strs = s.Split(new char[] { ',' });
		IHKIFGPICLG_HelpIds.Clear();
		for(int i = 0; i < strs.Length; i++)
		{
			int v = 0;
			if (!int.TryParse(strs[i], out v))
				v = 0;
			IHKIFGPICLG_HelpIds.Add(v);
		}
		//UnityEngine.Debug.LogError(NGHKJOEDLIP.OBGBAOLONDD);
		//UnityEngine.Debug.LogError(NGHKJOEDLIP.OPFGFINHFCE);
		//UnityEngine.Debug.LogError(NGHKJOEDLIP.HEDAGCNPHGD);
		//UnityEngine.Debug.LogError(JIKKNHIAEKG_BlockName);
		//UnityEngine.Debug.LogError(NGHKJOEDLIP.OCGFKMHNEOF_Key);
		//UnityEngine.Debug.LogError(NGHKJOEDLIP.HBACKHIOIBG);
		UMOEventList.EventData CurrenEvent = UMOEventList.GetCurrentEvent();
		if (CurrenEvent != null && CurrenEvent.BlockName == JIKKNHIAEKG_BlockName)
		{
			/*TodoLogger.LogError(TodoLogger.Event, "Switch to the real event enable");
			UnityEngine.Debug.LogError("Date : \n"
				+ Utility.GetLocalDateTime(NGHKJOEDLIP.BONDDBOFBND_Start).ToShortDateString() + " " + Utility.GetLocalDateTime(NGHKJOEDLIP.BONDDBOFBND_Start).ToShortTimeString() + "\n"
				+ Utility.GetLocalDateTime(NGHKJOEDLIP.HPNOGLIFJOP_End1).ToShortDateString() + " " + Utility.GetLocalDateTime(NGHKJOEDLIP.HPNOGLIFJOP_End1).ToShortTimeString() + "\n"
				+ Utility.GetLocalDateTime(NGHKJOEDLIP.LNFKGHNHJKE).ToShortDateString() + " " + Utility.GetLocalDateTime(NGHKJOEDLIP.LNFKGHNHJKE).ToShortTimeString() + "\n"
				+ Utility.GetLocalDateTime(NGHKJOEDLIP.JGMDAOACOJF).ToShortDateString() + " " + Utility.GetLocalDateTime(NGHKJOEDLIP.JGMDAOACOJF).ToShortTimeString() + "\n"
				+ Utility.GetLocalDateTime(NGHKJOEDLIP.IDDBFFBPNGI).ToShortDateString() + " " + Utility.GetLocalDateTime(NGHKJOEDLIP.IDDBFFBPNGI).ToShortTimeString() + "\n"
				+ Utility.GetLocalDateTime(NGHKJOEDLIP.KNLGKBBIBOH_End).ToShortDateString() + " " + Utility.GetLocalDateTime(NGHKJOEDLIP.KNLGKBBIBOH_End).ToShortTimeString() + "\n"
			);*/
			System.DateTime date = Utility.GetLocalDateTime(Utility.GetCurrentUnixTime());
			System.DateTime date2 = Utility.GetLocalDateTime(NGHKJOEDLIP.BONDDBOFBND_Start);
			date.AddDays(-1);
			long offset = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, date2.Hour, date2.Minute, date2.Second) - NGHKJOEDLIP.BONDDBOFBND_Start;
			if (NGHKJOEDLIP.BONDDBOFBND_Start != 0) NGHKJOEDLIP.BONDDBOFBND_Start += offset;
			if (NGHKJOEDLIP.HPNOGLIFJOP_End1 != 0) NGHKJOEDLIP.HPNOGLIFJOP_End1 += offset;
			if (NGHKJOEDLIP.LNFKGHNHJKE != 0) NGHKJOEDLIP.LNFKGHNHJKE += offset;
			if (NGHKJOEDLIP.JGMDAOACOJF != 0) NGHKJOEDLIP.JGMDAOACOJF += offset;
			if (NGHKJOEDLIP.IDDBFFBPNGI != 0) NGHKJOEDLIP.IDDBFFBPNGI += offset;
			if (NGHKJOEDLIP.KNLGKBBIBOH_End != 0) NGHKJOEDLIP.KNLGKBBIBOH_End += offset;
			for (int i = 0; i < IJJHFGOIDOK_Songs.Count; i++)
			{
				//UnityEngine.Debug.LogError("Date2 " + i + " : \n"
				//+ Utility.GetLocalDateTime(IJJHFGOIDOK_Songs[i].PDBPFJJCADD_OpenAt).ToShortDateString() + " " + Utility.GetLocalDateTime(IJJHFGOIDOK_Songs[i].PDBPFJJCADD_OpenAt).ToShortTimeString() + "\n"
				//+ Utility.GetLocalDateTime(IJJHFGOIDOK_Songs[i].FDBNFFNFOND_CloseAt).ToShortDateString() + " " + Utility.GetLocalDateTime(IJJHFGOIDOK_Songs[i].FDBNFFNFOND_CloseAt).ToShortTimeString() + "\n"
				//);
				if (IJJHFGOIDOK_Songs[i].PDBPFJJCADD_OpenAt != 0) IJJHFGOIDOK_Songs[i].PDBPFJJCADD_OpenAt = NGHKJOEDLIP.BONDDBOFBND_Start;
				if (IJJHFGOIDOK_Songs[i].FDBNFFNFOND_CloseAt != 0) IJJHFGOIDOK_Songs[i].FDBNFFNFOND_CloseAt = NGHKJOEDLIP.HPNOGLIFJOP_End1;
			}
			for (int i = 0; i < NNMPGOAGEOL_Missions.Count; i++)
			{
				//UnityEngine.Debug.LogError("Date3 " + i + " : \n"
				//+ Utility.GetLocalDateTime(NNMPGOAGEOL_Missions[i].KJBGCLPMLCG_Start).ToShortDateString() + " " + Utility.GetLocalDateTime(NNMPGOAGEOL_Missions[i].KJBGCLPMLCG_Start).ToShortTimeString() + "\n"
				//+ Utility.GetLocalDateTime(NNMPGOAGEOL_Missions[i].GJFPFFBAKGK_End).ToShortDateString() + " " + Utility.GetLocalDateTime(NNMPGOAGEOL_Missions[i].GJFPFFBAKGK_End).ToShortTimeString() + "\n"
				//);
				if (NNMPGOAGEOL_Missions[i].KJBGCLPMLCG_Start != 0) NNMPGOAGEOL_Missions[i].KJBGCLPMLCG_Start = NGHKJOEDLIP.BONDDBOFBND_Start;
				if (NNMPGOAGEOL_Missions[i].GJFPFFBAKGK_End != 0) NNMPGOAGEOL_Missions[i].GJFPFFBAKGK_End = NGHKJOEDLIP.HPNOGLIFJOP_End1;
			}
		}
		return true;
	}

	// RVA: 0x1021384 Offset: 0x1021384 VA: 0x1021384 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return true;
	}

	//// RVA: 0x1020994 Offset: 0x1020994 VA: 0x1020994
	private bool DGKKMKLCEDF(OLLJFONKEKO JMHECKKKMLK)
	{
		NGHKJOEDLIP.OBGBAOLONDD = (int)JMHECKKKMLK.HMBHNLCFDIH.OBGBAOLONDD;
		NGHKJOEDLIP.OPFGFINHFCE = JMHECKKKMLK.HMBHNLCFDIH.OPFGFINHFCE;
		NGHKJOEDLIP.HEDAGCNPHGD = JMHECKKKMLK.HMBHNLCFDIH.HEDAGCNPHGD;
		NGHKJOEDLIP.OCGFKMHNEOF_Key = JMHECKKKMLK.HMBHNLCFDIH.OCGFKMHNEOF;
		NGHKJOEDLIP.BONDDBOFBND_Start = JMHECKKKMLK.HMBHNLCFDIH.BONDDBOFBND;
		NGHKJOEDLIP.HPNOGLIFJOP_End1 = JMHECKKKMLK.HMBHNLCFDIH.HPNOGLIFJOP;
		NGHKJOEDLIP.LNFKGHNHJKE = JMHECKKKMLK.HMBHNLCFDIH.LNFKGHNHJKE;
		NGHKJOEDLIP.JGMDAOACOJF = JMHECKKKMLK.HMBHNLCFDIH.JGMDAOACOJF;
		NGHKJOEDLIP.IDDBFFBPNGI = JMHECKKKMLK.HMBHNLCFDIH.IDDBFFBPNGI;
		NGHKJOEDLIP.KNLGKBBIBOH_End = JMHECKKKMLK.HMBHNLCFDIH.KNLGKBBIBOH;
		NGHKJOEDLIP.KHIKEGLBGAF = (int)JMHECKKKMLK.HMBHNLCFDIH.KHIKEGLBGAF;
		NGHKJOEDLIP.POGEFBMBPCB = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.JMJDLDEIFKE;
		NGHKJOEDLIP.AHKNMANFILO = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.AHKNMANFILO;
		NGHKJOEDLIP.MOEKELIIDEO_SaveIdx = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.MOEKELIIDEO;
		NGHKJOEDLIP.OILIKPOBBGD = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.OILIKPOBBGD;
		NGHKJOEDLIP.AMCPINEGNPG = JMHECKKKMLK.HMBHNLCFDIH.AMCPINEGNPG;
		NGHKJOEDLIP.HBACKHIOIBG = JMHECKKKMLK.HMBHNLCFDIH.AGGLDFOKCLJ;
		NGHKJOEDLIP.BMKDEHFGHFG = JMHECKKKMLK.HMBHNLCFDIH.EODIMCFIMMP;
		NGHKJOEDLIP.OFGDLGBFOOA = JMHECKKKMLK.HMBHNLCFDIH.GLFPABNKHHA;
		NGHKJOEDLIP.OCDMGOGMHGE = JMHECKKKMLK.HMBHNLCFDIH.OCDMGOGMHGE;
		NGHKJOEDLIP.PJBILOFOCIC = JMHECKKKMLK.HMBHNLCFDIH.PJBILOFOCIC;
		NGHKJOEDLIP.AHKPNPNOAMO = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.AHKPNPNOAMO;
		NGHKJOEDLIP.HKKNEAGCIEB = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.HKKNEAGCIEB;
		EEEKPHDPJHG(NGHKJOEDLIP.CAPAPAABKDP, JMHECKKKMLK.HMBHNLCFDIH.KOHMHBGOFFI);
		for(int i = 0; i < JMHECKKKMLK.HMBHNLCFDIH.JHPCPNJJHLI.Length; i++)
		{
			if(JMHECKKKMLK.HMBHNLCFDIH.JHPCPNJJHLI[i] < 1001)
			{
				NGHKJOEDLIP.JHPCPNJJHLI.Add(JMHECKKKMLK.HMBHNLCFDIH.JHPCPNJJHLI[i]);
			}
		}
		return true;
	}

	//// RVA: 0x1021590 Offset: 0x1021590 VA: 0x1021590
	//private bool DGKKMKLCEDF(EDOHBJAPLPF IDLHJIOMJBK, int KAPMOPMDHJE) { }

	//// RVA: 0x10210D0 Offset: 0x10210D0 VA: 0x10210D0
	private bool GJEHPJJBCDE(OLLJFONKEKO JMHECKKKMLK)
	{
		for(int i = 0; i < JMHECKKKMLK.GHIHAGAOPNC.Length; i++)
		{
			EIEGCBJHGCP data = new EIEGCBJHGCP();
			data.KHEKNNFCAOI(i + 1, JMHECKKKMLK);
			IJJHFGOIDOK_Songs.Add(data);
		}
		return true;
	}

	//// RVA: 0x102176C Offset: 0x102176C VA: 0x102176C
	//private bool GJEHPJJBCDE(EDOHBJAPLPF OBHAFLMHAKG, int KAPMOPMDHJE) { }

	//// RVA: 0x10211EC Offset: 0x10211EC VA: 0x10211EC
	private bool CFOFJPLEDEA(OLLJFONKEKO JMHECKKKMLK)
	{
		long time = Utility.GetCurrentUnixTime();
		int key = (int)time * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.MDDOGIAFDEI.Length; i++)
		{
			AKIIJBEJOEP data = new AKIIJBEJOEP();
			data.KHEKNNFCAOI(JIKKNHIAEKG_BlockName, i + 1, key, JMHECKKKMLK);
			NNMPGOAGEOL_Missions.Add(data);
			key += 13;
		}
		return true;
	}

	//// RVA: 0x1021774 Offset: 0x1021774 VA: 0x1021774
	//private bool CFOFJPLEDEA(EDOHBJAPLPF OBHAFLMHAKG, int KAPMOPMDHJE) { }

	//// RVA: 0x102177C Offset: 0x102177C VA: 0x102177C
	//private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, EDOHBJAPLPF OBHAFLMHAKG, string OPFGFINHFCE, ref bool NGJDHLGMHMH) { }

	//// RVA: 0x10213F4 Offset: 0x10213F4 VA: 0x10213F4
	private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, string OAIBJJHGCNM)
	{
		string[] strs = OAIBJJHGCNM.Split(new char[] { ',' });
		NNDGIAEFMOG.Clear();
		for(int i = 0; i < strs.Length; i++)
		{
			if (!string.IsNullOrEmpty(strs[i]))
			{
				NNDGIAEFMOG.Add(int.Parse(strs[i]));
			}
		}
	}

	// RVA: 0x102195C Offset: 0x102195C VA: 0x102195C Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "KCGOMAFPGDD_EventAprilFool.CAOGDCBPBAN");
		return 0;
	}
}
