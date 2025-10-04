using FlatBuffers;
using System.Collections.Generic;

public class GDKBIMGFAEE
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int IJEKNCDIIAE_mver { get; set; } // 0xC FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public uint PLALNIIBLOF_en { get; set; } // 0x10 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public uint GBJFNGCDKPM_typ { get; set; } // 0x14 GHLFADHILNN CEJJMKODOGK_get_typ HOHCEBMMACI_set_typ
	public uint JBFLEDKDFCO_cid { get; set; } // 0x18 JOECCKJHICK LIJMKJLDHGP_get_cid NFNCLFPPADP_set_cid
	public uint ALAEHBKAEPB { get; set; } // 0x1C NILNPADBBHI NHILKCBAGHE_get_ ONHBPCBCFAE_set_
	public uint FBFLDFMFFOH_rar { get; set; } // 0x20 LMKEDCAPLEE HNLMNIOMOLI_get_rar CHHJKABBIBL_set_rar
	public int NGILPOOLBCF_OffsetX { get; set; } // 0x24 JHEFBAFILNF EDGHLAHGBFN_get_OffsetX LFCKFNLGFCN_set_OffsetX
	public int JINEKNIBOFI_OffsetY { get; set; } // 0x28 KPHFGIFBIJA LKDHAPEGCPH_get_OffsetY PBPDONPMGNF_set_OffsetY
}
public class JABLGCMDAIK
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int IJEKNCDIIAE_mver { get; set; } // 0xC FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public uint PLALNIIBLOF_en { get; set; } // 0x10 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public int GBJFNGCDKPM_typ { get; set; } // 0x14 GHLFADHILNN CEJJMKODOGK_get_typ HOHCEBMMACI_set_typ
	public uint LDLGLHBGOKE_FontSize { get; set; } // 0x18 DPCAJGDKHGG EONNCAKAEFE_get_FontSize BJAADDLLCHE_set_FontSize
	public uint CPKMLLNADLJ_Serie { get; set; } // 0x1C COPJCMLLIMO BJPJMGHCDNO_get_Serie BPKIOJBKNBP_set_Serie
	public uint JBFLEDKDFCO_cid { get; set; } // 0x20 JOECCKJHICK LIJMKJLDHGP_get_cid NFNCLFPPADP_set_cid
	public uint DMEDKJPOLCH_cat { get; set; } // 0x24 JAEJJPMKMFI IPKCKAAEEOE_get_cat JOGLLINFLJN_set_cat
	public uint FBFLDFMFFOH_rar { get; set; } // 0x28 LMKEDCAPLEE HNLMNIOMOLI_get_rar CHHJKABBIBL_set_rar
	public int MLMCEBBDJOE { get; set; } // 0x2C LNGPPHKHGMH IGMHCODOFKG_get_ IIIGDLGGEGK_set_
	public int ODNILEDOAIP { get; set; } // 0x30 LMNIPCGLCCM GNKPMBBAJHI_get_ PPMACIMALAC_set_
	public int NPPGKNGIFGK_price { get; set; } // 0x34 JDJKLDMOMGO FLMDBAFHDNJ_get_price DIHIEJPOCOJ_set_price
}
public class LNPGKJNNIFN
{
	public string LJNAKDMILMC_key { get; set; } // 0x8 KNJIHALCKLN LIIHHICIBKM_get_key OACJGKPBHIK_set_key
	public int JBGEEPFKIGG_val { get; set; } // 0xC AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
}
public class PJHPLPHEBJH
{
	public string LJNAKDMILMC_key { get; set; } // 0x8 KNJIHALCKLN LIIHHICIBKM_get_key OACJGKPBHIK_set_key
	public string JBGEEPFKIGG_val { get; set; } // 0xC AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
}
public class JONOKOHFAJO
{
	public GDKBIMGFAEE[] AKMICHNIBCI { get; set; } // 0x8 GODDHLICPCM KAFGANANOFF_get_ AGCAHNPHMPP_set_
	public JABLGCMDAIK[] CKALDHBDFBN { get; set; } // 0xC ANAGMICLCNJ PBICKLABPAH_get_ LIJDJEFMBAL_set_
	public LNPGKJNNIFN[] BHGDNGHDDAC { get; set; } // 0x10 JHDNDHBDFFI CEHHJMMMCID_get_ EDOEOHENKDG_set_
	public PJHPLPHEBJH[] MHGMDJNOLMI { get; set; } // 0x14 JBFEKPIDNIC NFFJJGMEEOB_get_ BGEFBFOAMPK_set_
	public static JONOKOHFAJO HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x1BA42F8
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		GLBBAECGHNN res_readData_ = GLBBAECGHNN.GetRootAsGLBBAECGHNN(buffer);
		JONOKOHFAJO res_data_ = new JONOKOHFAJO();

		List<GDKBIMGFAEE> AKMICHNIBCI_list_ = new List<GDKBIMGFAEE>();
		for(int AKMICHNIBCI_idx_ = 0; AKMICHNIBCI_idx_ < res_readData_.EKEPMNOOFEFLength; AKMICHNIBCI_idx_++)
		{
			IJHCOCLJICA AKMICHNIBCI_readData_ = res_readData_.GetEKEPMNOOFEF(AKMICHNIBCI_idx_);
			GDKBIMGFAEE AKMICHNIBCI_data_ = new GDKBIMGFAEE();

			AKMICHNIBCI_data_.PPFNGGCBJKC_id = AKMICHNIBCI_readData_.BBPHAPFBFHK/*_id*/;
			AKMICHNIBCI_data_.IJEKNCDIIAE_mver = AKMICHNIBCI_readData_.OFMGALJGDAO/*_mver*/;
			AKMICHNIBCI_data_.PLALNIIBLOF_en = AKMICHNIBCI_readData_.CFLMCGOJJJD/*_en*/;
			AKMICHNIBCI_data_.GBJFNGCDKPM_typ = AKMICHNIBCI_readData_.LPJPOOHJKAE/*_typ*/;
			AKMICHNIBCI_data_.JBFLEDKDFCO_cid = AKMICHNIBCI_readData_.HOENDPOGFIO/*_cid*/;
			AKMICHNIBCI_data_.ALAEHBKAEPB = AKMICHNIBCI_readData_.IINNLHJJLHD;
			AKMICHNIBCI_data_.FBFLDFMFFOH_rar = AKMICHNIBCI_readData_.ODBPKGJPLMD/*_rar*/;
			AKMICHNIBCI_data_.NGILPOOLBCF_OffsetX = AKMICHNIBCI_readData_.PJEDCALAIFP/*_OffsetX*/;
			AKMICHNIBCI_data_.JINEKNIBOFI_OffsetY = AKMICHNIBCI_readData_.KCEANJAMDBD/*_OffsetY*/;
			AKMICHNIBCI_list_.Add(AKMICHNIBCI_data_);
		}
		res_data_.AKMICHNIBCI = AKMICHNIBCI_list_.ToArray();

		List<JABLGCMDAIK> CKALDHBDFBN_list_ = new List<JABLGCMDAIK>();
		for(int CKALDHBDFBN_idx_ = 0; CKALDHBDFBN_idx_ < res_readData_.DIOINIDFAMFLength; CKALDHBDFBN_idx_++)
		{
			ABHNDHFIFLB CKALDHBDFBN_readData_ = res_readData_.GetDIOINIDFAMF(CKALDHBDFBN_idx_);
			JABLGCMDAIK CKALDHBDFBN_data_ = new JABLGCMDAIK();

			CKALDHBDFBN_data_.PPFNGGCBJKC_id = CKALDHBDFBN_readData_.BBPHAPFBFHK/*_id*/;
			CKALDHBDFBN_data_.IJEKNCDIIAE_mver = CKALDHBDFBN_readData_.OFMGALJGDAO/*_mver*/;
			CKALDHBDFBN_data_.PLALNIIBLOF_en = CKALDHBDFBN_readData_.CFLMCGOJJJD/*_en*/;
			CKALDHBDFBN_data_.GBJFNGCDKPM_typ = CKALDHBDFBN_readData_.LPJPOOHJKAE/*_typ*/;
			CKALDHBDFBN_data_.LDLGLHBGOKE_FontSize = CKALDHBDFBN_readData_.OELANBBBMLK/*_FontSize*/;
			CKALDHBDFBN_data_.CPKMLLNADLJ_Serie = CKALDHBDFBN_readData_.LMLNKHMPOIG/*_Serie*/;
			CKALDHBDFBN_data_.JBFLEDKDFCO_cid = CKALDHBDFBN_readData_.HOENDPOGFIO/*_cid*/;
			CKALDHBDFBN_data_.DMEDKJPOLCH_cat = CKALDHBDFBN_readData_.ADCLAGBHDBC/*_cat*/;
			CKALDHBDFBN_data_.FBFLDFMFFOH_rar = CKALDHBDFBN_readData_.ODBPKGJPLMD/*_rar*/;
			CKALDHBDFBN_data_.MLMCEBBDJOE = CKALDHBDFBN_readData_.JHAMBKOEJPL;
			CKALDHBDFBN_data_.ODNILEDOAIP = CKALDHBDFBN_readData_.MJHPFNPCLBD;
			CKALDHBDFBN_data_.NPPGKNGIFGK_price = CKALDHBDFBN_readData_.JDKBBEIBJBD/*_price*/;
			CKALDHBDFBN_list_.Add(CKALDHBDFBN_data_);
		}
		res_data_.CKALDHBDFBN = CKALDHBDFBN_list_.ToArray();

		List<LNPGKJNNIFN> BHGDNGHDDAC_list_ = new List<LNPGKJNNIFN>();
		for(int BHGDNGHDDAC_idx_ = 0; BHGDNGHDDAC_idx_ < res_readData_.NJJINHMIOHNLength; BHGDNGHDDAC_idx_++)
		{
			MJMHMHKFDNC BHGDNGHDDAC_readData_ = res_readData_.GetNJJINHMIOHN(BHGDNGHDDAC_idx_);
			LNPGKJNNIFN BHGDNGHDDAC_data_ = new LNPGKJNNIFN();

			BHGDNGHDDAC_data_.LJNAKDMILMC_key = BHGDNGHDDAC_readData_.AGOIMGHMGOH/*_key*/;
			BHGDNGHDDAC_data_.JBGEEPFKIGG_val = BHGDNGHDDAC_readData_.KJFEBMBHKOC/*_val*/;
			BHGDNGHDDAC_list_.Add(BHGDNGHDDAC_data_);
		}
		res_data_.BHGDNGHDDAC = BHGDNGHDDAC_list_.ToArray();

		List<PJHPLPHEBJH> MHGMDJNOLMI_list_ = new List<PJHPLPHEBJH>();
		for(int MHGMDJNOLMI_idx_ = 0; MHGMDJNOLMI_idx_ < res_readData_.NPFBHGKLIOMLength; MHGMDJNOLMI_idx_++)
		{
			OIJDGALEEAI MHGMDJNOLMI_readData_ = res_readData_.GetNPFBHGKLIOM(MHGMDJNOLMI_idx_);
			PJHPLPHEBJH MHGMDJNOLMI_data_ = new PJHPLPHEBJH();

			MHGMDJNOLMI_data_.LJNAKDMILMC_key = MHGMDJNOLMI_readData_.AGOIMGHMGOH/*_key*/;
			MHGMDJNOLMI_data_.JBGEEPFKIGG_val = MHGMDJNOLMI_readData_.KJFEBMBHKOC/*_val*/;
			MHGMDJNOLMI_list_.Add(MHGMDJNOLMI_data_);
		}
		res_data_.MHGMDJNOLMI = MHGMDJNOLMI_list_.ToArray();

		return res_data_;
	}
}
