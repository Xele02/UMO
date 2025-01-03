using FlatBuffers;
using System.Collections.Generic;

public class NPBFADCGACE
{
	public int PPFNGGCBJKC { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO HIGKAIDMOKN
	public int IJEKNCDIIAE { get; set; } // 0xC FAHNCMHNFCG KJIMMIBDCIL DMEGNOKIKCD
	public uint PLALNIIBLOF { get; set; } // 0x10 DFMNDOMAPAB JPCJNLHHIPE JJFJNEJLBDG
	public int DOOGFEGEKLG { get; set; } // 0x14 IKKMNBJGBJK AECMFIOFFJN NGOJJDOCIDG
	public int KFLIHDFDBOA { get; set; } // 0x18 LECPCIPOPBP LLMHFPBDMPM CHHBOLFOPAA
	public int OGMLPLGLELF { get; set; } // 0x1C PPFNMGDLCAB CKEFNICFCIN MFFKMNBMBNJ
	public int NHFDCMNPFDK { get; set; } // 0x20 JFCLCPHFNAO PENKBCJGKAF FLNEBAEGCFI
}
public class JIABMKPKEOP
{
	public int PPFNGGCBJKC { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO HIGKAIDMOKN
	public int CBDFEJIBAMO { get; set; } // 0xC CAOEAKCDJIM HJIDKFIKAAI COHECJJEMMI
	public int PFBDNFPPNEJ { get; set; } // 0x10 NIPPOPKKINA JHCOKFLOONM CMJFGGKIOFG
	public int GAMEFFJONIJ { get; set; } // 0x14 KDPOBJBMDBI CDOHKAHAKNH NFOBBJMJFOI
	public int ODMJFHDIGLP { get; set; } // 0x18 DKHKAJOLLPE IEACLNIEABJ KEOPEEKGMDO
	public int[] KFCIJBLDHOK { get; set; } // 0x1C JPBPAFOAPIO EPEKNNHHPIF LFGKAMKBDGA
}
public class PJMLNHMCMOG
{
	public int PPFNGGCBJKC { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO HIGKAIDMOKN
	public int[] GHFAMFHCLLO { get; set; } // 0xC OJGPGPMGOGD AJBLNFPGNBF JDFALDALEJK
	public int[] FFGGEGECPMM { get; set; } // 0x10 KEKOCCBKHGI IBHIHIFCBIL ACHAGJGIKAH
	public int[] ECGHPHPNKFG { get; set; } // 0x14 KCKAPENPHDC ANCKHHIBNJE GNHHDJKLLNM
	public int[] OBJCCILIBIB { get; set; } // 0x18 EHFEKCAPIEI ENJBCKMFDEB AJJFOPNEIAA
}
public class CDNNOHNNJJE
{
	public int PPFNGGCBJKC { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO HIGKAIDMOKN
	public int[] GKIKBPGMEBB { get; set; } // 0xC OFNHAABECOJ GFGKFPNLJAM ALLOJNIJBLP
	public int[] JIMBKGOPKHE { get; set; } // 0x10 DBFMDAPDGOG DFAKBJLHCGL AEMJFPPLGLD
}
public class DNAIGLNMDBK
{
	public string LJNAKDMILMC { get; set; } // 0x8 KNJIHALCKLN LIIHHICIBKM OACJGKPBHIK
	public int JBGEEPFKIGG { get; set; } // 0xC AHPLCJAKAOP OLOCMINKGON ABAFHIBFKCE
}
public class JMCDAINNDDJ
{
	public string LJNAKDMILMC { get; set; } // 0x8 KNJIHALCKLN LIIHHICIBKM OACJGKPBHIK
	public string JBGEEPFKIGG { get; set; } // 0xC AHPLCJAKAOP OLOCMINKGON ABAFHIBFKCE
}
public class MIAGFHOGPPN
{
	public NPBFADCGACE[] MMJDALHDALP { get; set; } // 0x8 EOLGBFCKJNA MDEHFBCCGKJ KGBPPCNKPJB
	public JIABMKPKEOP[] JNEJFDOCIDN { get; set; } // 0xC GLOAAJBLBIK CHGDOOKJALA ODGGEFDONCF
	public PJMLNHMCMOG[] FLDJCNDHENP { get; set; } // 0x10 CDLFJLMKEEH NPFNCNNIMMO PPIHHHODPNF
	public CDNNOHNNJJE[] KMAFAMDPEKG { get; set; } // 0x14 JJHFGOOOBBK MLPOMMIJJDH BOGIPKENAPG
	public DNAIGLNMDBK[] BHGDNGHDDAC { get; set; } // 0x18 JHDNDHBDFFI CEHHJMMMCID EDOEOHENKDG
	public JMCDAINNDDJ[] MHGMDJNOLMI { get; set; } // 0x1C JBFEKPIDNIC NFFJJGMEEOB BGEFBFOAMPK
	public static MIAGFHOGPPN HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x1953F84
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		HACLELJLADO res_readData = HACLELJLADO.GetRootAsHACLELJLADO(buffer);
		MIAGFHOGPPN res_data = new MIAGFHOGPPN();

		List<NPBFADCGACE> MMJDALHDALP_list = new List<NPBFADCGACE>();
		for(int MMJDALHDALP_idx = 0; MMJDALHDALP_idx < res_readData.DECLAPPHHLJLength; MMJDALHDALP_idx++)
		{
			DGBGJKKIACN MMJDALHDALP_readData = res_readData.GetDECLAPPHHLJ(MMJDALHDALP_idx);
			NPBFADCGACE MMJDALHDALP_data = new NPBFADCGACE();

			MMJDALHDALP_data.PPFNGGCBJKC = MMJDALHDALP_readData.BBPHAPFBFHK;
			MMJDALHDALP_data.IJEKNCDIIAE = MMJDALHDALP_readData.OFMGALJGDAO;
			MMJDALHDALP_data.PLALNIIBLOF = MMJDALHDALP_readData.CFLMCGOJJJD;
			MMJDALHDALP_data.DOOGFEGEKLG = MMJDALHDALP_readData.GEJGMBBCFEE;
			MMJDALHDALP_data.KFLIHDFDBOA = MMJDALHDALP_readData.LBCHNGMGBKL;
			MMJDALHDALP_data.OGMLPLGLELF = MMJDALHDALP_readData.HFOBJBOILFG;
			MMJDALHDALP_data.NHFDCMNPFDK = MMJDALHDALP_readData.JEMNMKOCAEI;
			MMJDALHDALP_list.Add(MMJDALHDALP_data);
		}
		res_data.MMJDALHDALP = MMJDALHDALP_list.ToArray();

		List<JIABMKPKEOP> JNEJFDOCIDN_list = new List<JIABMKPKEOP>();
		for(int JNEJFDOCIDN_idx = 0; JNEJFDOCIDN_idx < res_readData.CMMCFMNDNAGLength; JNEJFDOCIDN_idx++)
		{
			BKIKCJIAIIO JNEJFDOCIDN_readData = res_readData.GetCMMCFMNDNAG(JNEJFDOCIDN_idx);
			JIABMKPKEOP JNEJFDOCIDN_data = new JIABMKPKEOP();

			JNEJFDOCIDN_data.PPFNGGCBJKC = JNEJFDOCIDN_readData.BBPHAPFBFHK;
			JNEJFDOCIDN_data.CBDFEJIBAMO = JNEJFDOCIDN_readData.FNMKCLELMHN;
			JNEJFDOCIDN_data.PFBDNFPPNEJ = JNEJFDOCIDN_readData.ENFMOLLLMCK;
			JNEJFDOCIDN_data.GAMEFFJONIJ = JNEJFDOCIDN_readData.KBPIOBMFPDN;
			JNEJFDOCIDN_data.ODMJFHDIGLP = JNEJFDOCIDN_readData.NCIKNCJLFBI;
			List<int> KFCIJBLDHOK_list = new List<int>();
			for(int KFCIJBLDHOK_idx = 0; KFCIJBLDHOK_idx < JNEJFDOCIDN_readData.CHGIONDFIKPLength; KFCIJBLDHOK_idx++)
			{
				KFCIJBLDHOK_list.Add(JNEJFDOCIDN_readData.GetCHGIONDFIKP(KFCIJBLDHOK_idx));
			}
			JNEJFDOCIDN_data.KFCIJBLDHOK = KFCIJBLDHOK_list.ToArray();

			JNEJFDOCIDN_list.Add(JNEJFDOCIDN_data);
		}
		res_data.JNEJFDOCIDN = JNEJFDOCIDN_list.ToArray();

		List<PJMLNHMCMOG> FLDJCNDHENP_list = new List<PJMLNHMCMOG>();
		for(int FLDJCNDHENP_idx = 0; FLDJCNDHENP_idx < res_readData.NIIBHCNIBKJLength; FLDJCNDHENP_idx++)
		{
			OJJCFKMBCCG FLDJCNDHENP_readData = res_readData.GetNIIBHCNIBKJ(FLDJCNDHENP_idx);
			PJMLNHMCMOG FLDJCNDHENP_data = new PJMLNHMCMOG();

			FLDJCNDHENP_data.PPFNGGCBJKC = FLDJCNDHENP_readData.BBPHAPFBFHK;
			List<int> GHFAMFHCLLO_list = new List<int>();
			for(int GHFAMFHCLLO_idx = 0; GHFAMFHCLLO_idx < FLDJCNDHENP_readData.HDALNHDJPLPLength; GHFAMFHCLLO_idx++)
			{
				GHFAMFHCLLO_list.Add(FLDJCNDHENP_readData.GetHDALNHDJPLP(GHFAMFHCLLO_idx));
			}
			FLDJCNDHENP_data.GHFAMFHCLLO = GHFAMFHCLLO_list.ToArray();

			List<int> FFGGEGECPMM_list = new List<int>();
			for(int FFGGEGECPMM_idx = 0; FFGGEGECPMM_idx < FLDJCNDHENP_readData.LGMFAKNICMBLength; FFGGEGECPMM_idx++)
			{
				FFGGEGECPMM_list.Add(FLDJCNDHENP_readData.GetLGMFAKNICMB(FFGGEGECPMM_idx));
			}
			FLDJCNDHENP_data.FFGGEGECPMM = FFGGEGECPMM_list.ToArray();

			List<int> ECGHPHPNKFG_list = new List<int>();
			for(int ECGHPHPNKFG_idx = 0; ECGHPHPNKFG_idx < FLDJCNDHENP_readData.LLPOHOGEHMGLength; ECGHPHPNKFG_idx++)
			{
				ECGHPHPNKFG_list.Add(FLDJCNDHENP_readData.GetLLPOHOGEHMG(ECGHPHPNKFG_idx));
			}
			FLDJCNDHENP_data.ECGHPHPNKFG = ECGHPHPNKFG_list.ToArray();

			List<int> OBJCCILIBIB_list = new List<int>();
			for(int OBJCCILIBIB_idx = 0; OBJCCILIBIB_idx < FLDJCNDHENP_readData.IEIMHJDMABNLength; OBJCCILIBIB_idx++)
			{
				OBJCCILIBIB_list.Add(FLDJCNDHENP_readData.GetIEIMHJDMABN(OBJCCILIBIB_idx));
			}
			FLDJCNDHENP_data.OBJCCILIBIB = OBJCCILIBIB_list.ToArray();

			FLDJCNDHENP_list.Add(FLDJCNDHENP_data);
		}
		res_data.FLDJCNDHENP = FLDJCNDHENP_list.ToArray();

		List<CDNNOHNNJJE> KMAFAMDPEKG_list = new List<CDNNOHNNJJE>();
		for(int KMAFAMDPEKG_idx = 0; KMAFAMDPEKG_idx < res_readData.HKEKGDIIMHOLength; KMAFAMDPEKG_idx++)
		{
			EEJBHCCHCGC KMAFAMDPEKG_readData = res_readData.GetHKEKGDIIMHO(KMAFAMDPEKG_idx);
			CDNNOHNNJJE KMAFAMDPEKG_data = new CDNNOHNNJJE();

			KMAFAMDPEKG_data.PPFNGGCBJKC = KMAFAMDPEKG_readData.BBPHAPFBFHK;
			List<int> GKIKBPGMEBB_list = new List<int>();
			for(int GKIKBPGMEBB_idx = 0; GKIKBPGMEBB_idx < KMAFAMDPEKG_readData.KAPGFDIPAMKLength; GKIKBPGMEBB_idx++)
			{
				GKIKBPGMEBB_list.Add(KMAFAMDPEKG_readData.GetKAPGFDIPAMK(GKIKBPGMEBB_idx));
			}
			KMAFAMDPEKG_data.GKIKBPGMEBB = GKIKBPGMEBB_list.ToArray();

			List<int> JIMBKGOPKHE_list = new List<int>();
			for(int JIMBKGOPKHE_idx = 0; JIMBKGOPKHE_idx < KMAFAMDPEKG_readData.DIDBHLLFNOHLength; JIMBKGOPKHE_idx++)
			{
				JIMBKGOPKHE_list.Add(KMAFAMDPEKG_readData.GetDIDBHLLFNOH(JIMBKGOPKHE_idx));
			}
			KMAFAMDPEKG_data.JIMBKGOPKHE = JIMBKGOPKHE_list.ToArray();

			KMAFAMDPEKG_list.Add(KMAFAMDPEKG_data);
		}
		res_data.KMAFAMDPEKG = KMAFAMDPEKG_list.ToArray();

		List<DNAIGLNMDBK> BHGDNGHDDAC_list = new List<DNAIGLNMDBK>();
		for(int BHGDNGHDDAC_idx = 0; BHGDNGHDDAC_idx < res_readData.NJJINHMIOHNLength; BHGDNGHDDAC_idx++)
		{
			HAPBICPAMDF BHGDNGHDDAC_readData = res_readData.GetNJJINHMIOHN(BHGDNGHDDAC_idx);
			DNAIGLNMDBK BHGDNGHDDAC_data = new DNAIGLNMDBK();

			BHGDNGHDDAC_data.LJNAKDMILMC = BHGDNGHDDAC_readData.AGOIMGHMGOH;
			BHGDNGHDDAC_data.JBGEEPFKIGG = BHGDNGHDDAC_readData.KJFEBMBHKOC;
			BHGDNGHDDAC_list.Add(BHGDNGHDDAC_data);
		}
		res_data.BHGDNGHDDAC = BHGDNGHDDAC_list.ToArray();

		List<JMCDAINNDDJ> MHGMDJNOLMI_list = new List<JMCDAINNDDJ>();
		for(int MHGMDJNOLMI_idx = 0; MHGMDJNOLMI_idx < res_readData.NPFBHGKLIOMLength; MHGMDJNOLMI_idx++)
		{
			MINCDLJOALM MHGMDJNOLMI_readData = res_readData.GetNPFBHGKLIOM(MHGMDJNOLMI_idx);
			JMCDAINNDDJ MHGMDJNOLMI_data = new JMCDAINNDDJ();

			MHGMDJNOLMI_data.LJNAKDMILMC = MHGMDJNOLMI_readData.AGOIMGHMGOH;
			MHGMDJNOLMI_data.JBGEEPFKIGG = MHGMDJNOLMI_readData.KJFEBMBHKOC;
			MHGMDJNOLMI_list.Add(MHGMDJNOLMI_data);
		}
		res_data.MHGMDJNOLMI = MHGMDJNOLMI_list.ToArray();

		return res_data;
	}
}
