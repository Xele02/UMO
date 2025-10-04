using FlatBuffers;
using System.Collections.Generic;

public class FDGGBBPGKFB
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int ADKDHKMPMHP_rate { get; set; } // 0xC HIELAPGGNEJ KCLKBHDMAFH_get_rate GOLECEILPOI_set_rate
	public int JOPPFEHKNFO_Pickup { get; set; } // 0x10 LLNLOLIOPBO FNIOGOJFLMG_get_Pickup AJIOKKIJBED_set_Pickup
	public int HDOEJDHGFLH_ItemFullId { get; set; } // 0x14 LBHMFCIPOOA OEGAADKHDEB_get_ItemFullId NCJCOKLLAIL_set_ItemFullId
	public int DDLGKJOKGFJ { get; set; } // 0x18 CHOMMGHNCOE LOOIIPKGBDN_get_ EEFGDPLHGDM_set_
	public string CHEHLCNHMII { get; set; } // 0x1C NNJDPFKJJOE PEHOFHPJDFK_get_ PEBKEBNMNEO_set_
	public int[] GLCLFMGPMAN_ItemId { get; set; } // 0x20 KCELNMGLKHH LNJAENEGDEL_get_ItemId JHIDBGCHOKL_set_ItemId
	public int[] ADPPAIPFHML_num { get; set; } // 0x24 LONDDHLNFBL LJMLHOOPGEM_get_num PHNIOCPOBGO_set_num
	public uint LJNAKDMILMC_key { get; set; } // 0x28 KNJIHALCKLN LIIHHICIBKM_get_key OACJGKPBHIK_set_key
}
public class BAAELIGJGIJ
{
	public string LJNAKDMILMC_key { get; set; } // 0x8 KNJIHALCKLN LIIHHICIBKM_get_key OACJGKPBHIK_set_key
	public int JBGEEPFKIGG_val { get; set; } // 0xC AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
}
public class MKHHOIJDCAH
{
	public string LJNAKDMILMC_key { get; set; } // 0x8 KNJIHALCKLN LIIHHICIBKM_get_key OACJGKPBHIK_set_key
	public string JBGEEPFKIGG_val { get; set; } // 0xC AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
}
public class GHFFJFCGDCB
{
	public FDGGBBPGKFB[] HEHPAMADHGC { get; set; } // 0x8 ELDDPACCPDB BGLEMGEDKIM_get_ HPKKCCEEGEK_set_
	public BAAELIGJGIJ[] BHGDNGHDDAC { get; set; } // 0xC JHDNDHBDFFI CEHHJMMMCID_get_ EDOEOHENKDG_set_
	public MKHHOIJDCAH[] MHGMDJNOLMI { get; set; } // 0x10 JBFEKPIDNIC NFFJJGMEEOB_get_ BGEFBFOAMPK_set_
	public static GHFFJFCGDCB HEGEKFMJNCC(byte[] NIODCJLINJN)// 0xAA4DF0
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		KMANHBAOCLJ res_readData_ = KMANHBAOCLJ.GetRootAsKMANHBAOCLJ(buffer);
		GHFFJFCGDCB res_data_ = new GHFFJFCGDCB();

		List<FDGGBBPGKFB> HEHPAMADHGC_list_ = new List<FDGGBBPGKFB>();
		for(int HEHPAMADHGC_idx_ = 0; HEHPAMADHGC_idx_ < res_readData_.PIIOHCJFHBDLength; HEHPAMADHGC_idx_++)
		{
			OIGIKHKPIOF HEHPAMADHGC_readData_ = res_readData_.GetPIIOHCJFHBD(HEHPAMADHGC_idx_);
			FDGGBBPGKFB HEHPAMADHGC_data_ = new FDGGBBPGKFB();

			HEHPAMADHGC_data_.PPFNGGCBJKC_id = HEHPAMADHGC_readData_.BBPHAPFBFHK/*_id*/;
			HEHPAMADHGC_data_.ADKDHKMPMHP_rate = HEHPAMADHGC_readData_.EKJDPPJFKOK/*_rate*/;
			HEHPAMADHGC_data_.JOPPFEHKNFO_Pickup = HEHPAMADHGC_readData_.ALPALMJMJJK/*_Pickup*/;
			HEHPAMADHGC_data_.HDOEJDHGFLH_ItemFullId = HEHPAMADHGC_readData_.MJGENHDKIFB/*_ItemFullId*/;
			HEHPAMADHGC_data_.DDLGKJOKGFJ = HEHPAMADHGC_readData_.JFLHEINHLOC;
			HEHPAMADHGC_data_.CHEHLCNHMII = HEHPAMADHGC_readData_.GJBNEGIFCDG;
			List<int> GLCLFMGPMAN_list_ = new List<int>();
			for(int GLCLFMGPMAN_idx_ = 0; GLCLFMGPMAN_idx_ < HEHPAMADHGC_readData_.AGPECCAGHFLLength; GLCLFMGPMAN_idx_++)
			{
				GLCLFMGPMAN_list_.Add(HEHPAMADHGC_readData_.GetAGPECCAGHFL(GLCLFMGPMAN_idx_));
			}
			HEHPAMADHGC_data_.GLCLFMGPMAN_ItemId = GLCLFMGPMAN_list_.ToArray();

			List<int> ADPPAIPFHML_list_ = new List<int>();
			for(int ADPPAIPFHML_idx_ = 0; ADPPAIPFHML_idx_ < HEHPAMADHGC_readData_.EKPDMIAPDKBLength; ADPPAIPFHML_idx_++)
			{
				ADPPAIPFHML_list_.Add(HEHPAMADHGC_readData_.GetEKPDMIAPDKB(ADPPAIPFHML_idx_));
			}
			HEHPAMADHGC_data_.ADPPAIPFHML_num = ADPPAIPFHML_list_.ToArray();

			HEHPAMADHGC_data_.LJNAKDMILMC_key = HEHPAMADHGC_readData_.AGOIMGHMGOH/*_key*/;
			HEHPAMADHGC_list_.Add(HEHPAMADHGC_data_);
		}
		res_data_.HEHPAMADHGC = HEHPAMADHGC_list_.ToArray();

		List<BAAELIGJGIJ> BHGDNGHDDAC_list_ = new List<BAAELIGJGIJ>();
		for(int BHGDNGHDDAC_idx_ = 0; BHGDNGHDDAC_idx_ < res_readData_.NJJINHMIOHNLength; BHGDNGHDDAC_idx_++)
		{
			HLDFFNGONFE BHGDNGHDDAC_readData_ = res_readData_.GetNJJINHMIOHN(BHGDNGHDDAC_idx_);
			BAAELIGJGIJ BHGDNGHDDAC_data_ = new BAAELIGJGIJ();

			BHGDNGHDDAC_data_.LJNAKDMILMC_key = BHGDNGHDDAC_readData_.AGOIMGHMGOH/*_key*/;
			BHGDNGHDDAC_data_.JBGEEPFKIGG_val = BHGDNGHDDAC_readData_.KJFEBMBHKOC/*_val*/;
			BHGDNGHDDAC_list_.Add(BHGDNGHDDAC_data_);
		}
		res_data_.BHGDNGHDDAC = BHGDNGHDDAC_list_.ToArray();

		List<MKHHOIJDCAH> MHGMDJNOLMI_list_ = new List<MKHHOIJDCAH>();
		for(int MHGMDJNOLMI_idx_ = 0; MHGMDJNOLMI_idx_ < res_readData_.NPFBHGKLIOMLength; MHGMDJNOLMI_idx_++)
		{
			OLDFIFPNMJO MHGMDJNOLMI_readData_ = res_readData_.GetNPFBHGKLIOM(MHGMDJNOLMI_idx_);
			MKHHOIJDCAH MHGMDJNOLMI_data_ = new MKHHOIJDCAH();

			MHGMDJNOLMI_data_.LJNAKDMILMC_key = MHGMDJNOLMI_readData_.AGOIMGHMGOH/*_key*/;
			MHGMDJNOLMI_data_.JBGEEPFKIGG_val = MHGMDJNOLMI_readData_.KJFEBMBHKOC/*_val*/;
			MHGMDJNOLMI_list_.Add(MHGMDJNOLMI_data_);
		}
		res_data_.MHGMDJNOLMI = MHGMDJNOLMI_list_.ToArray();

		return res_data_;
	}
}
