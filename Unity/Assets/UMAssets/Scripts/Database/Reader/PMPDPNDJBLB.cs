using FlatBuffers;
using System.Collections.Generic;

public class HNGLACEEHKJ
{
	public string OPFGFINHFCE_name { get; set; } // 0x8 LGIIAPHCLPN DKJOHDGOIJE_get_name MJAMIGECMMF_set_name
	public string HEDAGCNPHGD_RankingName { get; set; } // 0xC MDDOAHHHPOP FJAAEFFFFNF_get_RankingName GFPDDOPFCOG_set_RankingName
	public uint OBGBAOLONDD_UniqueId { get; set; } // 0x10 NCOKDCMHMJF OLHPPFCEIIK_get_UniqueId EIHCOIFCELN_set_UniqueId
	public string OCGFKMHNEOF_name_for_api { get; set; } // 0x14 FPPPOCOGLEB KOGCMPJKHEN_get_name_for_api NCLILAGAPCJ_set_name_for_api
	public uint MOEKELIIDEO_SaveIdx { get; set; } // 0x18 MJBDEKDJLJL BGIBLNEJJNA_get_SaveIdx BAMKBOHIDFG_set_SaveIdx
	public uint BONDDBOFBND_RankingStart { get; set; } // 0x1C JLKMCNLLGOB NNHBILFHONA_get_RankingStart DKJIPIOFHNJ_set_RankingStart
	public uint HPNOGLIFJOP_RankingEnd { get; set; } // 0x20 LKCBAFJAGDN CMOKHLBLIGO_get_RankingEnd BGEFMCCGGAO_set_RankingEnd
	public uint LNFKGHNHJKE_RankingEnd2 { get; set; } // 0x24 DBAHKIMGPAI BMNKAHOBNCL_get_RankingEnd2 OLDALGAEKNB_set_RankingEnd2
	public uint JGMDAOACOJF_RewardStart { get; set; } // 0x28 HLNLAENEKOD IHLILJPCPMB_get_RewardStart NFAIHFEHHEK_set_RewardStart
	public uint IDDBFFBPNGI_RewardEnd { get; set; } // 0x2C BNFKFIHBOFD DFOFEPAMOAF_get_RewardEnd DBJHPJBOILO_set_RewardEnd
	public uint KNLGKBBIBOH_RewardEnd2 { get; set; } // 0x30 HLFNONCONAP IOMNJKGAOOD_get_RewardEnd2 CDGMGKOIMBP_set_RewardEnd2
	public uint KHIKEGLBGAF_RankingRewardScene { get; set; } // 0x34 OAPPFIGOMHO FAHFDEFDLMH_get_RankingRewardScene OJJMIBDFGBG_set_RankingRewardScene
	public uint JMJDLDEIFKE { get; set; } // 0x38 OAGMMIOODOF OIHKCLCPBJI_get_ PKPGPELDIBH_set_
	public uint AHKNMANFILO_DayGroup { get; set; } // 0x3C IFFLMDALMBO PEGLCODNPHG_get_DayGroup PAGEFLIKEIE_set_DayGroup
	public string OCDMGOGMHGE_KeyPrefix { get; set; } // 0x40 AEEOIOIDHEE HBAAAKFHDBB_get_KeyPrefix NHJLJOIPOFK_set_KeyPrefix
	public string KOHMHBGOFFI_free_music { get; set; } // 0x44 JLLIIMINNHM GLMMBMGFOMJ_get_free_music MPHABIGJJJH_set_free_music
	public uint AHKPNPNOAMO_ExtreamOpen { get; set; } // 0x48 AFNKJBHLGEM GFGFHFAENCE_get_ExtreamOpen BLDNJLKJEDC_set_ExtreamOpen
	public uint HKKNEAGCIEB_RankingSupport { get; set; } // 0x4C DLECBCICIJB KCBPJPCEPHH_get_RankingSupport KBACNJPKDOD_set_RankingSupport
	public int[] JHPCPNJJHLI_RankingThreshold { get; set; } // 0x50 ABFFLNFIKGK BJHMPIECMGE_get_RankingThreshold DDMAPMOHPBM_set_RankingThreshold
}
public class IJPMFNGFABJ
{
	public string LJNAKDMILMC_key { get; set; } // 0x8 KNJIHALCKLN LIIHHICIBKM_get_key OACJGKPBHIK_set_key
	public int JBGEEPFKIGG_val { get; set; } // 0xC AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
}
public class GEANDMOANHJ
{
	public string LJNAKDMILMC_key { get; set; } // 0x8 KNJIHALCKLN LIIHHICIBKM_get_key OACJGKPBHIK_set_key
	public string JBGEEPFKIGG_val { get; set; } // 0xC AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
}
public class LNBFCFMMHCN
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int KFCIJBLDHOK_v1 { get; set; } // 0xC JPBPAFOAPIO EPEKNNHHPIF_get_v1 LFGKAMKBDGA_set_v1
	public int JLEIHOEGMOP_v2 { get; set; } // 0x10 JLNAMGLBPME JJGFFGDDFPA_get_v2 LIIFHDMHLHP_set_v2
}
public class PMPDPNDJBLB
{
	public HNGLACEEHKJ HMBHNLCFDIH { get; set; } // 0x8 GHOEBMKFFAF HPDMBLBOMBI_get_ BMLFCMKAALF_set_
	public IJPMFNGFABJ[] BHGDNGHDDAC { get; set; } // 0xC JHDNDHBDFFI CEHHJMMMCID_get_ EDOEOHENKDG_set_
	public GEANDMOANHJ[] MHGMDJNOLMI { get; set; } // 0x10 JBFEKPIDNIC NFFJJGMEEOB_get_ BGEFBFOAMPK_set_
	public LNBFCFMMHCN[] KIEKMCKCMGD { get; set; } // 0x14 AHOFIJDMDAO EEMBMMJIHPE_get_ CDHPBECJGGO_set_
	public static PMPDPNDJBLB HEGEKFMJNCC(byte[] NIODCJLINJN)// 0xFEFFF0
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		MCCEAMFIECM res_readData_ = MCCEAMFIECM.GetRootAsMCCEAMFIECM(buffer);
		PMPDPNDJBLB res_data_ = new PMPDPNDJBLB();

		APGJGCCJNJF HMBHNLCFDIH_readData_ = res_readData_.OPBPOOKODJK;
		HNGLACEEHKJ HMBHNLCFDIH_data_ = new HNGLACEEHKJ();

		HMBHNLCFDIH_data_.OPFGFINHFCE_name = HMBHNLCFDIH_readData_.IIDCFMHCPLJ/*_name*/;
		HMBHNLCFDIH_data_.HEDAGCNPHGD_RankingName = HMBHNLCFDIH_readData_.HAEJDOGGKPC/*_RankingName*/;
		HMBHNLCFDIH_data_.OBGBAOLONDD_UniqueId = HMBHNLCFDIH_readData_.MAIJBDCJPNJ/*_UniqueId*/;
		HMBHNLCFDIH_data_.OCGFKMHNEOF_name_for_api = HMBHNLCFDIH_readData_.MKDFHLALNAF/*_name_for_api*/;
		HMBHNLCFDIH_data_.MOEKELIIDEO_SaveIdx = HMBHNLCFDIH_readData_.MCHOEAGDGJP/*_SaveIdx*/;
		HMBHNLCFDIH_data_.BONDDBOFBND_RankingStart = HMBHNLCFDIH_readData_.LLJNABNBDMN/*_RankingStart*/;
		HMBHNLCFDIH_data_.HPNOGLIFJOP_RankingEnd = HMBHNLCFDIH_readData_.DJHKCHMBGHC/*_RankingEnd*/;
		HMBHNLCFDIH_data_.LNFKGHNHJKE_RankingEnd2 = HMBHNLCFDIH_readData_.BCKOLCDDIAG/*_RankingEnd2*/;
		HMBHNLCFDIH_data_.JGMDAOACOJF_RewardStart = HMBHNLCFDIH_readData_.LKIBIHGHEMA/*_RewardStart*/;
		HMBHNLCFDIH_data_.IDDBFFBPNGI_RewardEnd = HMBHNLCFDIH_readData_.ANELKJCGJJL/*_RewardEnd*/;
		HMBHNLCFDIH_data_.KNLGKBBIBOH_RewardEnd2 = HMBHNLCFDIH_readData_.AEOKLKJAKHB/*_RewardEnd2*/;
		HMBHNLCFDIH_data_.KHIKEGLBGAF_RankingRewardScene = HMBHNLCFDIH_readData_.HKPPDACCCOH/*_RankingRewardScene*/;
		HMBHNLCFDIH_data_.JMJDLDEIFKE = HMBHNLCFDIH_readData_.OGBOPHDAMCI;
		HMBHNLCFDIH_data_.AHKNMANFILO_DayGroup = HMBHNLCFDIH_readData_.HGFJBAJCFNF/*_DayGroup*/;
		HMBHNLCFDIH_data_.OCDMGOGMHGE_KeyPrefix = HMBHNLCFDIH_readData_.HAEMDABJFJF/*_KeyPrefix*/;
		HMBHNLCFDIH_data_.KOHMHBGOFFI_free_music = HMBHNLCFDIH_readData_.GPCEIBGOEGB/*_free_music*/;
		HMBHNLCFDIH_data_.AHKPNPNOAMO_ExtreamOpen = HMBHNLCFDIH_readData_.KPCNGKDBMHA/*_ExtreamOpen*/;
		HMBHNLCFDIH_data_.HKKNEAGCIEB_RankingSupport = HMBHNLCFDIH_readData_.LENBJLOPKLE/*_RankingSupport*/;
		List<int> JHPCPNJJHLI_list_ = new List<int>();
		for(int JHPCPNJJHLI_idx_ = 0; JHPCPNJJHLI_idx_ < HMBHNLCFDIH_readData_.KNDBMPNNCGGLength; JHPCPNJJHLI_idx_++)
		{
			JHPCPNJJHLI_list_.Add(HMBHNLCFDIH_readData_.GetKNDBMPNNCGG(JHPCPNJJHLI_idx_));
		}
		HMBHNLCFDIH_data_.JHPCPNJJHLI_RankingThreshold = JHPCPNJJHLI_list_.ToArray();

		res_data_.HMBHNLCFDIH = HMBHNLCFDIH_data_;
		List<IJPMFNGFABJ> BHGDNGHDDAC_list_ = new List<IJPMFNGFABJ>();
		for(int BHGDNGHDDAC_idx_ = 0; BHGDNGHDDAC_idx_ < res_readData_.NJJINHMIOHNLength; BHGDNGHDDAC_idx_++)
		{
			HFNALPGCIFB BHGDNGHDDAC_readData_ = res_readData_.GetNJJINHMIOHN(BHGDNGHDDAC_idx_);
			IJPMFNGFABJ BHGDNGHDDAC_data_ = new IJPMFNGFABJ();

			BHGDNGHDDAC_data_.LJNAKDMILMC_key = BHGDNGHDDAC_readData_.AGOIMGHMGOH/*_key*/;
			BHGDNGHDDAC_data_.JBGEEPFKIGG_val = BHGDNGHDDAC_readData_.KJFEBMBHKOC/*_val*/;
			BHGDNGHDDAC_list_.Add(BHGDNGHDDAC_data_);
		}
		res_data_.BHGDNGHDDAC = BHGDNGHDDAC_list_.ToArray();

		List<GEANDMOANHJ> MHGMDJNOLMI_list_ = new List<GEANDMOANHJ>();
		for(int MHGMDJNOLMI_idx_ = 0; MHGMDJNOLMI_idx_ < res_readData_.NPFBHGKLIOMLength; MHGMDJNOLMI_idx_++)
		{
			CNOCBANEBIK MHGMDJNOLMI_readData_ = res_readData_.GetNPFBHGKLIOM(MHGMDJNOLMI_idx_);
			GEANDMOANHJ MHGMDJNOLMI_data_ = new GEANDMOANHJ();

			MHGMDJNOLMI_data_.LJNAKDMILMC_key = MHGMDJNOLMI_readData_.AGOIMGHMGOH/*_key*/;
			MHGMDJNOLMI_data_.JBGEEPFKIGG_val = MHGMDJNOLMI_readData_.KJFEBMBHKOC/*_val*/;
			MHGMDJNOLMI_list_.Add(MHGMDJNOLMI_data_);
		}
		res_data_.MHGMDJNOLMI = MHGMDJNOLMI_list_.ToArray();

		List<LNBFCFMMHCN> KIEKMCKCMGD_list_ = new List<LNBFCFMMHCN>();
		for(int KIEKMCKCMGD_idx_ = 0; KIEKMCKCMGD_idx_ < res_readData_.FBAHAFKCMMHLength; KIEKMCKCMGD_idx_++)
		{
			DMNHOBFBIJD KIEKMCKCMGD_readData_ = res_readData_.GetFBAHAFKCMMH(KIEKMCKCMGD_idx_);
			LNBFCFMMHCN KIEKMCKCMGD_data_ = new LNBFCFMMHCN();

			KIEKMCKCMGD_data_.PPFNGGCBJKC_id = KIEKMCKCMGD_readData_.BBPHAPFBFHK/*_id*/;
			KIEKMCKCMGD_data_.KFCIJBLDHOK_v1 = KIEKMCKCMGD_readData_.MCJNHPMBPIJ/*_v1*/;
			KIEKMCKCMGD_data_.JLEIHOEGMOP_v2 = KIEKMCKCMGD_readData_.MGJKFKDICGC/*_v2*/;
			KIEKMCKCMGD_list_.Add(KIEKMCKCMGD_data_);
		}
		res_data_.KIEKMCKCMGD = KIEKMCKCMGD_list_.ToArray();

		return res_data_;
	}
}
