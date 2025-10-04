using FlatBuffers;
using System.Collections.Generic;

public class HMNCNMGCIMM
{
	public string OPFGFINHFCE_name { get; set; } // 0x8 LGIIAPHCLPN DKJOHDGOIJE_get_name MJAMIGECMMF_set_name
	public string HEDAGCNPHGD_RankingName { get; set; } // 0xC MDDOAHHHPOP FJAAEFFFFNF_get_RankingName GFPDDOPFCOG_set_RankingName
	public uint OBGBAOLONDD_UniqueId { get; set; } // 0x10 NCOKDCMHMJF OLHPPFCEIIK_get_UniqueId EIHCOIFCELN_set_UniqueId
	public string OCGFKMHNEOF_name_for_api { get; set; } // 0x14 FPPPOCOGLEB KOGCMPJKHEN_get_name_for_api NCLILAGAPCJ_set_name_for_api
	public string[] MPCAGEPEJJJ_Key { get; set; } // 0x18 OINCEAPBAHC PLBHMKFJNPJ_get_Key BCEIHFNLBIM_set_Key
	public uint BONDDBOFBND_RankingStart { get; set; } // 0x1C JLKMCNLLGOB NNHBILFHONA_get_RankingStart DKJIPIOFHNJ_set_RankingStart
	public uint HPNOGLIFJOP_RankingEnd { get; set; } // 0x20 LKCBAFJAGDN CMOKHLBLIGO_get_RankingEnd BGEFMCCGGAO_set_RankingEnd
	public uint LNFKGHNHJKE_RankingEnd2 { get; set; } // 0x24 DBAHKIMGPAI BMNKAHOBNCL_get_RankingEnd2 OLDALGAEKNB_set_RankingEnd2
	public uint JGMDAOACOJF_RewardStart { get; set; } // 0x28 HLNLAENEKOD IHLILJPCPMB_get_RewardStart NFAIHFEHHEK_set_RewardStart
	public uint IDDBFFBPNGI_RewardEnd { get; set; } // 0x2C BNFKFIHBOFD DFOFEPAMOAF_get_RewardEnd DBJHPJBOILO_set_RewardEnd
	public uint KNLGKBBIBOH_RewardEnd2 { get; set; } // 0x30 HLFNONCONAP IOMNJKGAOOD_get_RewardEnd2 CDGMGKOIMBP_set_RewardEnd2
	public int[] JHPCPNJJHLI_RankingThreshold { get; set; } // 0x34 ABFFLNFIKGK BJHMPIECMGE_get_RankingThreshold DDMAPMOHPBM_set_RankingThreshold
}
public class KAGMCEBLHAI
{
	public string LJNAKDMILMC_key { get; set; } // 0x8 KNJIHALCKLN LIIHHICIBKM_get_key OACJGKPBHIK_set_key
	public int JBGEEPFKIGG_val { get; set; } // 0xC AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
}
public class KBHIGPCGLKH
{
	public string LJNAKDMILMC_key { get; set; } // 0x8 KNJIHALCKLN LIIHHICIBKM_get_key OACJGKPBHIK_set_key
	public string JBGEEPFKIGG_val { get; set; } // 0xC AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
}
public class CEGLELHPKBO
{
	public HMNCNMGCIMM HMBHNLCFDIH { get; set; } // 0x8 GHOEBMKFFAF HPDMBLBOMBI_get_ BMLFCMKAALF_set_
	public KAGMCEBLHAI[] BHGDNGHDDAC { get; set; } // 0xC JHDNDHBDFFI CEHHJMMMCID_get_ EDOEOHENKDG_set_
	public KBHIGPCGLKH[] MHGMDJNOLMI { get; set; } // 0x10 JBFEKPIDNIC NFFJJGMEEOB_get_ BGEFBFOAMPK_set_
	public static CEGLELHPKBO HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x12B4F4C
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		AIAIHLIBPLM res_readData_ = AIAIHLIBPLM.GetRootAsAIAIHLIBPLM(buffer);
		CEGLELHPKBO res_data_ = new CEGLELHPKBO();

		MPAKIJAPJIC HMBHNLCFDIH_readData_ = res_readData_.OPBPOOKODJK;
		HMNCNMGCIMM HMBHNLCFDIH_data_ = new HMNCNMGCIMM();

		HMBHNLCFDIH_data_.OPFGFINHFCE_name = HMBHNLCFDIH_readData_.IIDCFMHCPLJ/*_name*/;
		HMBHNLCFDIH_data_.HEDAGCNPHGD_RankingName = HMBHNLCFDIH_readData_.HAEJDOGGKPC/*_RankingName*/;
		HMBHNLCFDIH_data_.OBGBAOLONDD_UniqueId = HMBHNLCFDIH_readData_.MAIJBDCJPNJ/*_UniqueId*/;
		HMBHNLCFDIH_data_.OCGFKMHNEOF_name_for_api = HMBHNLCFDIH_readData_.MKDFHLALNAF/*_name_for_api*/;
		List<string> MPCAGEPEJJJ_list_ = new List<string>();
		for(int MPCAGEPEJJJ_idx_ = 0; MPCAGEPEJJJ_idx_ < HMBHNLCFDIH_readData_.NLPMPPCENKDLength; MPCAGEPEJJJ_idx_++)
		{
			MPCAGEPEJJJ_list_.Add(HMBHNLCFDIH_readData_.GetNLPMPPCENKD(MPCAGEPEJJJ_idx_));
		}
		HMBHNLCFDIH_data_.MPCAGEPEJJJ_Key = MPCAGEPEJJJ_list_.ToArray();

		HMBHNLCFDIH_data_.BONDDBOFBND_RankingStart = HMBHNLCFDIH_readData_.LLJNABNBDMN/*_RankingStart*/;
		HMBHNLCFDIH_data_.HPNOGLIFJOP_RankingEnd = HMBHNLCFDIH_readData_.DJHKCHMBGHC/*_RankingEnd*/;
		HMBHNLCFDIH_data_.LNFKGHNHJKE_RankingEnd2 = HMBHNLCFDIH_readData_.BCKOLCDDIAG/*_RankingEnd2*/;
		HMBHNLCFDIH_data_.JGMDAOACOJF_RewardStart = HMBHNLCFDIH_readData_.LKIBIHGHEMA/*_RewardStart*/;
		HMBHNLCFDIH_data_.IDDBFFBPNGI_RewardEnd = HMBHNLCFDIH_readData_.ANELKJCGJJL/*_RewardEnd*/;
		HMBHNLCFDIH_data_.KNLGKBBIBOH_RewardEnd2 = HMBHNLCFDIH_readData_.AEOKLKJAKHB/*_RewardEnd2*/;
		List<int> JHPCPNJJHLI_list_ = new List<int>();
		for(int JHPCPNJJHLI_idx_ = 0; JHPCPNJJHLI_idx_ < HMBHNLCFDIH_readData_.KNDBMPNNCGGLength; JHPCPNJJHLI_idx_++)
		{
			JHPCPNJJHLI_list_.Add(HMBHNLCFDIH_readData_.GetKNDBMPNNCGG(JHPCPNJJHLI_idx_));
		}
		HMBHNLCFDIH_data_.JHPCPNJJHLI_RankingThreshold = JHPCPNJJHLI_list_.ToArray();

		res_data_.HMBHNLCFDIH = HMBHNLCFDIH_data_;
		List<KAGMCEBLHAI> BHGDNGHDDAC_list_ = new List<KAGMCEBLHAI>();
		for(int BHGDNGHDDAC_idx_ = 0; BHGDNGHDDAC_idx_ < res_readData_.NJJINHMIOHNLength; BHGDNGHDDAC_idx_++)
		{
			DAIIOPHMNIM BHGDNGHDDAC_readData_ = res_readData_.GetNJJINHMIOHN(BHGDNGHDDAC_idx_);
			KAGMCEBLHAI BHGDNGHDDAC_data_ = new KAGMCEBLHAI();

			BHGDNGHDDAC_data_.LJNAKDMILMC_key = BHGDNGHDDAC_readData_.AGOIMGHMGOH/*_key*/;
			BHGDNGHDDAC_data_.JBGEEPFKIGG_val = BHGDNGHDDAC_readData_.KJFEBMBHKOC/*_val*/;
			BHGDNGHDDAC_list_.Add(BHGDNGHDDAC_data_);
		}
		res_data_.BHGDNGHDDAC = BHGDNGHDDAC_list_.ToArray();

		List<KBHIGPCGLKH> MHGMDJNOLMI_list_ = new List<KBHIGPCGLKH>();
		for(int MHGMDJNOLMI_idx_ = 0; MHGMDJNOLMI_idx_ < res_readData_.NPFBHGKLIOMLength; MHGMDJNOLMI_idx_++)
		{
			NNKOCPILBMP MHGMDJNOLMI_readData_ = res_readData_.GetNPFBHGKLIOM(MHGMDJNOLMI_idx_);
			KBHIGPCGLKH MHGMDJNOLMI_data_ = new KBHIGPCGLKH();

			MHGMDJNOLMI_data_.LJNAKDMILMC_key = MHGMDJNOLMI_readData_.AGOIMGHMGOH/*_key*/;
			MHGMDJNOLMI_data_.JBGEEPFKIGG_val = MHGMDJNOLMI_readData_.KJFEBMBHKOC/*_val*/;
			MHGMDJNOLMI_list_.Add(MHGMDJNOLMI_data_);
		}
		res_data_.MHGMDJNOLMI = MHGMDJNOLMI_list_.ToArray();

		return res_data_;
	}
}
