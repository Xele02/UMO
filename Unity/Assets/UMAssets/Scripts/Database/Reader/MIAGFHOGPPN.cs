using FlatBuffers;
using System.Collections.Generic;

public class NPBFADCGACE
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int IJEKNCDIIAE_mver { get; set; } // 0xC FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public uint PLALNIIBLOF_en { get; set; } // 0x10 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public int DOOGFEGEKLG_max { get; set; } // 0x14 IKKMNBJGBJK AECMFIOFFJN_get_max NGOJJDOCIDG_set_max
	public int KFLIHDFDBOA { get; set; } // 0x18 LECPCIPOPBP LLMHFPBDMPM_get_ CHHBOLFOPAA_set_
	public int OGMLPLGLELF { get; set; } // 0x1C PPFNMGDLCAB CKEFNICFCIN_get_ MFFKMNBMBNJ_set_
	public int NHFDCMNPFDK { get; set; } // 0x20 JFCLCPHFNAO PENKBCJGKAF_get_ FLNEBAEGCFI_set_
}
public class JIABMKPKEOP
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int CBDFEJIBAMO { get; set; } // 0xC CAOEAKCDJIM HJIDKFIKAAI_get_ COHECJJEMMI_set_
	public int PFBDNFPPNEJ { get; set; } // 0x10 NIPPOPKKINA JHCOKFLOONM_get_ CMJFGGKIOFG_set_
	public int GAMEFFJONIJ { get; set; } // 0x14 KDPOBJBMDBI CDOHKAHAKNH_get_ NFOBBJMJFOI_set_
	public int ODMJFHDIGLP_cnd { get; set; } // 0x18 DKHKAJOLLPE IEACLNIEABJ_get_cnd KEOPEEKGMDO_set_cnd
	public int[] KFCIJBLDHOK_v1 { get; set; } // 0x1C JPBPAFOAPIO EPEKNNHHPIF_get_v1 LFGKAMKBDGA_set_v1
}
public class PJMLNHMCMOG
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int[] GHFAMFHCLLO { get; set; } // 0xC OJGPGPMGOGD AJBLNFPGNBF_get_ JDFALDALEJK_set_
	public int[] FFGGEGECPMM { get; set; } // 0x10 KEKOCCBKHGI IBHIHIFCBIL_get_ ACHAGJGIKAH_set_
	public int[] ECGHPHPNKFG { get; set; } // 0x14 KCKAPENPHDC ANCKHHIBNJE_get_ GNHHDJKLLNM_set_
	public int[] OBJCCILIBIB { get; set; } // 0x18 EHFEKCAPIEI ENJBCKMFDEB_get_ AJJFOPNEIAA_set_
}
public class CDNNOHNNJJE
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int[] GKIKBPGMEBB { get; set; } // 0xC OFNHAABECOJ GFGKFPNLJAM_get_ ALLOJNIJBLP_set_
	public int[] JIMBKGOPKHE { get; set; } // 0x10 DBFMDAPDGOG DFAKBJLHCGL_get_ AEMJFPPLGLD_set_
}
public class DNAIGLNMDBK
{
	public string LJNAKDMILMC_key { get; set; } // 0x8 KNJIHALCKLN LIIHHICIBKM_get_key OACJGKPBHIK_set_key
	public int JBGEEPFKIGG_val { get; set; } // 0xC AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
}
public class JMCDAINNDDJ
{
	public string LJNAKDMILMC_key { get; set; } // 0x8 KNJIHALCKLN LIIHHICIBKM_get_key OACJGKPBHIK_set_key
	public string JBGEEPFKIGG_val { get; set; } // 0xC AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
}
public class MIAGFHOGPPN
{
	public NPBFADCGACE[] MMJDALHDALP { get; set; } // 0x8 EOLGBFCKJNA MDEHFBCCGKJ_get_ KGBPPCNKPJB_set_
	public JIABMKPKEOP[] JNEJFDOCIDN { get; set; } // 0xC GLOAAJBLBIK CHGDOOKJALA_get_ ODGGEFDONCF_set_
	public PJMLNHMCMOG[] FLDJCNDHENP { get; set; } // 0x10 CDLFJLMKEEH NPFNCNNIMMO_get_ PPIHHHODPNF_set_
	public CDNNOHNNJJE[] KMAFAMDPEKG { get; set; } // 0x14 JJHFGOOOBBK MLPOMMIJJDH_get_ BOGIPKENAPG_set_
	public DNAIGLNMDBK[] BHGDNGHDDAC { get; set; } // 0x18 JHDNDHBDFFI CEHHJMMMCID_get_ EDOEOHENKDG_set_
	public JMCDAINNDDJ[] MHGMDJNOLMI { get; set; } // 0x1C JBFEKPIDNIC NFFJJGMEEOB_get_ BGEFBFOAMPK_set_
	public static MIAGFHOGPPN HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x1953F84
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		HACLELJLADO res_readData_ = HACLELJLADO.GetRootAsHACLELJLADO(buffer);
		MIAGFHOGPPN res_data_ = new MIAGFHOGPPN();

		List<NPBFADCGACE> MMJDALHDALP_list_ = new List<NPBFADCGACE>();
		for(int MMJDALHDALP_idx_ = 0; MMJDALHDALP_idx_ < res_readData_.DECLAPPHHLJLength; MMJDALHDALP_idx_++)
		{
			DGBGJKKIACN MMJDALHDALP_readData_ = res_readData_.GetDECLAPPHHLJ(MMJDALHDALP_idx_);
			NPBFADCGACE MMJDALHDALP_data_ = new NPBFADCGACE();

			MMJDALHDALP_data_.PPFNGGCBJKC_id = MMJDALHDALP_readData_.BBPHAPFBFHK/*_id*/;
			MMJDALHDALP_data_.IJEKNCDIIAE_mver = MMJDALHDALP_readData_.OFMGALJGDAO/*_mver*/;
			MMJDALHDALP_data_.PLALNIIBLOF_en = MMJDALHDALP_readData_.CFLMCGOJJJD/*_en*/;
			MMJDALHDALP_data_.DOOGFEGEKLG_max = MMJDALHDALP_readData_.GEJGMBBCFEE/*_max*/;
			MMJDALHDALP_data_.KFLIHDFDBOA = MMJDALHDALP_readData_.LBCHNGMGBKL;
			MMJDALHDALP_data_.OGMLPLGLELF = MMJDALHDALP_readData_.HFOBJBOILFG;
			MMJDALHDALP_data_.NHFDCMNPFDK = MMJDALHDALP_readData_.JEMNMKOCAEI;
			MMJDALHDALP_list_.Add(MMJDALHDALP_data_);
		}
		res_data_.MMJDALHDALP = MMJDALHDALP_list_.ToArray();

		List<JIABMKPKEOP> JNEJFDOCIDN_list_ = new List<JIABMKPKEOP>();
		for(int JNEJFDOCIDN_idx_ = 0; JNEJFDOCIDN_idx_ < res_readData_.CMMCFMNDNAGLength; JNEJFDOCIDN_idx_++)
		{
			BKIKCJIAIIO JNEJFDOCIDN_readData_ = res_readData_.GetCMMCFMNDNAG(JNEJFDOCIDN_idx_);
			JIABMKPKEOP JNEJFDOCIDN_data_ = new JIABMKPKEOP();

			JNEJFDOCIDN_data_.PPFNGGCBJKC_id = JNEJFDOCIDN_readData_.BBPHAPFBFHK/*_id*/;
			JNEJFDOCIDN_data_.CBDFEJIBAMO = JNEJFDOCIDN_readData_.FNMKCLELMHN;
			JNEJFDOCIDN_data_.PFBDNFPPNEJ = JNEJFDOCIDN_readData_.ENFMOLLLMCK;
			JNEJFDOCIDN_data_.GAMEFFJONIJ = JNEJFDOCIDN_readData_.KBPIOBMFPDN;
			JNEJFDOCIDN_data_.ODMJFHDIGLP_cnd = JNEJFDOCIDN_readData_.NCIKNCJLFBI/*_cnd*/;
			List<int> KFCIJBLDHOK_list_ = new List<int>();
			for(int KFCIJBLDHOK_idx_ = 0; KFCIJBLDHOK_idx_ < JNEJFDOCIDN_readData_.CHGIONDFIKPLength; KFCIJBLDHOK_idx_++)
			{
				KFCIJBLDHOK_list_.Add(JNEJFDOCIDN_readData_.GetCHGIONDFIKP(KFCIJBLDHOK_idx_));
			}
			JNEJFDOCIDN_data_.KFCIJBLDHOK_v1 = KFCIJBLDHOK_list_.ToArray();

			JNEJFDOCIDN_list_.Add(JNEJFDOCIDN_data_);
		}
		res_data_.JNEJFDOCIDN = JNEJFDOCIDN_list_.ToArray();

		List<PJMLNHMCMOG> FLDJCNDHENP_list_ = new List<PJMLNHMCMOG>();
		for(int FLDJCNDHENP_idx_ = 0; FLDJCNDHENP_idx_ < res_readData_.NIIBHCNIBKJLength; FLDJCNDHENP_idx_++)
		{
			OJJCFKMBCCG FLDJCNDHENP_readData_ = res_readData_.GetNIIBHCNIBKJ(FLDJCNDHENP_idx_);
			PJMLNHMCMOG FLDJCNDHENP_data_ = new PJMLNHMCMOG();

			FLDJCNDHENP_data_.PPFNGGCBJKC_id = FLDJCNDHENP_readData_.BBPHAPFBFHK/*_id*/;
			List<int> GHFAMFHCLLO_list_ = new List<int>();
			for(int GHFAMFHCLLO_idx_ = 0; GHFAMFHCLLO_idx_ < FLDJCNDHENP_readData_.HDALNHDJPLPLength; GHFAMFHCLLO_idx_++)
			{
				GHFAMFHCLLO_list_.Add(FLDJCNDHENP_readData_.GetHDALNHDJPLP(GHFAMFHCLLO_idx_));
			}
			FLDJCNDHENP_data_.GHFAMFHCLLO = GHFAMFHCLLO_list_.ToArray();

			List<int> FFGGEGECPMM_list_ = new List<int>();
			for(int FFGGEGECPMM_idx_ = 0; FFGGEGECPMM_idx_ < FLDJCNDHENP_readData_.LGMFAKNICMBLength; FFGGEGECPMM_idx_++)
			{
				FFGGEGECPMM_list_.Add(FLDJCNDHENP_readData_.GetLGMFAKNICMB(FFGGEGECPMM_idx_));
			}
			FLDJCNDHENP_data_.FFGGEGECPMM = FFGGEGECPMM_list_.ToArray();

			List<int> ECGHPHPNKFG_list_ = new List<int>();
			for(int ECGHPHPNKFG_idx_ = 0; ECGHPHPNKFG_idx_ < FLDJCNDHENP_readData_.LLPOHOGEHMGLength; ECGHPHPNKFG_idx_++)
			{
				ECGHPHPNKFG_list_.Add(FLDJCNDHENP_readData_.GetLLPOHOGEHMG(ECGHPHPNKFG_idx_));
			}
			FLDJCNDHENP_data_.ECGHPHPNKFG = ECGHPHPNKFG_list_.ToArray();

			List<int> OBJCCILIBIB_list_ = new List<int>();
			for(int OBJCCILIBIB_idx_ = 0; OBJCCILIBIB_idx_ < FLDJCNDHENP_readData_.IEIMHJDMABNLength; OBJCCILIBIB_idx_++)
			{
				OBJCCILIBIB_list_.Add(FLDJCNDHENP_readData_.GetIEIMHJDMABN(OBJCCILIBIB_idx_));
			}
			FLDJCNDHENP_data_.OBJCCILIBIB = OBJCCILIBIB_list_.ToArray();

			FLDJCNDHENP_list_.Add(FLDJCNDHENP_data_);
		}
		res_data_.FLDJCNDHENP = FLDJCNDHENP_list_.ToArray();

		List<CDNNOHNNJJE> KMAFAMDPEKG_list_ = new List<CDNNOHNNJJE>();
		for(int KMAFAMDPEKG_idx_ = 0; KMAFAMDPEKG_idx_ < res_readData_.HKEKGDIIMHOLength; KMAFAMDPEKG_idx_++)
		{
			EEJBHCCHCGC KMAFAMDPEKG_readData_ = res_readData_.GetHKEKGDIIMHO(KMAFAMDPEKG_idx_);
			CDNNOHNNJJE KMAFAMDPEKG_data_ = new CDNNOHNNJJE();

			KMAFAMDPEKG_data_.PPFNGGCBJKC_id = KMAFAMDPEKG_readData_.BBPHAPFBFHK/*_id*/;
			List<int> GKIKBPGMEBB_list_ = new List<int>();
			for(int GKIKBPGMEBB_idx_ = 0; GKIKBPGMEBB_idx_ < KMAFAMDPEKG_readData_.KAPGFDIPAMKLength; GKIKBPGMEBB_idx_++)
			{
				GKIKBPGMEBB_list_.Add(KMAFAMDPEKG_readData_.GetKAPGFDIPAMK(GKIKBPGMEBB_idx_));
			}
			KMAFAMDPEKG_data_.GKIKBPGMEBB = GKIKBPGMEBB_list_.ToArray();

			List<int> JIMBKGOPKHE_list_ = new List<int>();
			for(int JIMBKGOPKHE_idx_ = 0; JIMBKGOPKHE_idx_ < KMAFAMDPEKG_readData_.DIDBHLLFNOHLength; JIMBKGOPKHE_idx_++)
			{
				JIMBKGOPKHE_list_.Add(KMAFAMDPEKG_readData_.GetDIDBHLLFNOH(JIMBKGOPKHE_idx_));
			}
			KMAFAMDPEKG_data_.JIMBKGOPKHE = JIMBKGOPKHE_list_.ToArray();

			KMAFAMDPEKG_list_.Add(KMAFAMDPEKG_data_);
		}
		res_data_.KMAFAMDPEKG = KMAFAMDPEKG_list_.ToArray();

		List<DNAIGLNMDBK> BHGDNGHDDAC_list_ = new List<DNAIGLNMDBK>();
		for(int BHGDNGHDDAC_idx_ = 0; BHGDNGHDDAC_idx_ < res_readData_.NJJINHMIOHNLength; BHGDNGHDDAC_idx_++)
		{
			HAPBICPAMDF BHGDNGHDDAC_readData_ = res_readData_.GetNJJINHMIOHN(BHGDNGHDDAC_idx_);
			DNAIGLNMDBK BHGDNGHDDAC_data_ = new DNAIGLNMDBK();

			BHGDNGHDDAC_data_.LJNAKDMILMC_key = BHGDNGHDDAC_readData_.AGOIMGHMGOH/*_key*/;
			BHGDNGHDDAC_data_.JBGEEPFKIGG_val = BHGDNGHDDAC_readData_.KJFEBMBHKOC/*_val*/;
			BHGDNGHDDAC_list_.Add(BHGDNGHDDAC_data_);
		}
		res_data_.BHGDNGHDDAC = BHGDNGHDDAC_list_.ToArray();

		List<JMCDAINNDDJ> MHGMDJNOLMI_list_ = new List<JMCDAINNDDJ>();
		for(int MHGMDJNOLMI_idx_ = 0; MHGMDJNOLMI_idx_ < res_readData_.NPFBHGKLIOMLength; MHGMDJNOLMI_idx_++)
		{
			MINCDLJOALM MHGMDJNOLMI_readData_ = res_readData_.GetNPFBHGKLIOM(MHGMDJNOLMI_idx_);
			JMCDAINNDDJ MHGMDJNOLMI_data_ = new JMCDAINNDDJ();

			MHGMDJNOLMI_data_.LJNAKDMILMC_key = MHGMDJNOLMI_readData_.AGOIMGHMGOH/*_key*/;
			MHGMDJNOLMI_data_.JBGEEPFKIGG_val = MHGMDJNOLMI_readData_.KJFEBMBHKOC/*_val*/;
			MHGMDJNOLMI_list_.Add(MHGMDJNOLMI_data_);
		}
		res_data_.MHGMDJNOLMI = MHGMDJNOLMI_list_.ToArray();

		return res_data_;
	}
}
