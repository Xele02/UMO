
using System.Collections.Generic;
using XeSys;

public class PIGBBNDPPJC
{
	public string OPFGFINHFCE; // 0x8
	public string KLMPFGOCBHC; // 0xC
	public int KELFCMEOPPM; // 0x10
	public int EAHPLCJMPHD; // 0x14
	public bool CADENLBDAEB; // 0x18
	public int FKMAEKNOLJB; // 0x1C
	public int FGOGPCMHPIN; // 0x20
	public int JJJNKGBCFMI; // 0x24
	public int ABLHIAEDJAI_CurrentPoint; // 0x28
	public int DMHDNKILKGI_MaxPoint; // 0x2C
	public int LEGAKDFPPHA; // 0x30
	public int KIJAPOFAGPN; // 0x34
	public bool CCBKMCLDGAD; // 0x38
	public bool JBCIDDKDJMM; // 0x39
	public long BEBJKJKBOGH; // 0x40
	//public LGMEPLIJLNB JBFLCHFEIGL; // 0x48

	//public bool OJOLGGKILFL { get; } 0x16D0300 KKEOAGANMNA
	//public bool DKMLDEDKPBA { get; } 0x16D0314 PCIINKJELKK
	//public bool IIEAILCOPDB { get; } 0x16D0328 EMKGOLJAJBG

	//// RVA: 0x16D0340 Offset: 0x16D0340 VA: 0x16D0340
	//public void LEHDLBJJBNC() { }

	//// RVA: 0x16D0470 Offset: 0x16D0470 VA: 0x16D0470
	public void KHEKNNFCAOI(int KELFCMEOPPM)
	{
		TodoLogger.Log(0, "PIGBBNDPPJC KHEKNNFCAOI");
		JBCIDDKDJMM = false;
	}

	//// RVA: 0x16D18D4 Offset: 0x16D18D4 VA: 0x16D18D4
	//public void FBANBDCOEJL() { }

	//// RVA: 0x16D11AC Offset: 0x16D11AC VA: 0x16D11AC
	//public void AFGOBPPKFBF() { }

	//// RVA: 0x16D2190 Offset: 0x16D2190 VA: 0x16D2190
	public static List<PIGBBNDPPJC> FKDIMODKKJD_GetAvaiableEpisodes(bool DHFLBNAHGDF = false)
	{
		List<PIGBBNDPPJC> res = new List<PIGBBNDPPJC>(500);
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList.Count; i++)
		{
			HMGPODKEFBA_EpisodeInfo dbEp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[i];
			OCLHKHAMDHF_Episode.JEHNEEBBDBO_EpisodeInfo saveEp = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[i];
			if(dbEp.PPEGAKEIEGM == 2)
			{
				if(!DHFLBNAHGDF)
				{
					if (saveEp.BEBJKJKBOGH_Date == 0)
						continue;
				}
				PIGBBNDPPJC data = new PIGBBNDPPJC();
				data.KHEKNNFCAOI(i + 1);
				res.Add(data);
			}
		}
		CEAIGKOGLIN(res);
		return res;
	}

	//// RVA: 0x16D24CC Offset: 0x16D24CC VA: 0x16D24CC
	public static void CEAIGKOGLIN(List<PIGBBNDPPJC> NNDGIAEFMOG)
	{
		NNDGIAEFMOG.Sort((PIGBBNDPPJC HKICMNAACDA, PIGBBNDPPJC BNKHBCBJBKI) =>
		{
			//0x16D365C
			return HKICMNAACDA.FKMAEKNOLJB - BNKHBCBJBKI.FKMAEKNOLJB;
		});
	}

	//// RVA: 0x16D2620 Offset: 0x16D2620 VA: 0x16D2620
	//public int HADPDBAGEIB(int BNGHLLCONJM, int HMFFHLPNMPH) { }

	//// RVA: 0x16D2950 Offset: 0x16D2950 VA: 0x16D2950
	//public int PFMLAOPEAMJ(int BNGHLLCONJM, int HMFFHLPNMPH, IMCBBOAFION BHFHGFKBOHH) { }

	//// RVA: 0x16D20E4 Offset: 0x16D20E4 VA: 0x16D20E4
	//private int GMDHJBGLBEI(int KELFCMEOPPM) { }

	//// RVA: 0x16D11D0 Offset: 0x16D11D0 VA: 0x16D11D0
	//private bool FIBLGPNEKEM(int KELFCMEOPPM) { }

	//// RVA: 0x16D2FD4 Offset: 0x16D2FD4 VA: 0x16D2FD4
	//public static int GMDHJBGLBEI(int KELFCMEOPPM, BBHNACPENDM AHEFHIMGIBI) { }

	//// RVA: 0x16D0FEC Offset: 0x16D0FEC VA: 0x16D0FEC
	public static string EJOJNFDHDHN(int KELFCMEOPPM)
	{
		return MessageManager.Instance.GetMessage("master", "ep_nm_" + KELFCMEOPPM.ToString("D4"));
	}

	//// RVA: 0x16D10C4 Offset: 0x16D10C4 VA: 0x16D10C4
	//public static string FKKHNDDGKJB(int KELFCMEOPPM) { }
}
