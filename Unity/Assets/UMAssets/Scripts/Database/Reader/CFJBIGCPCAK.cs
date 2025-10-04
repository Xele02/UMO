using FlatBuffers;
using System.Collections.Generic;

public class LKGEMHKEBDJ
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint GBJFNGCDKPM_typ { get; set; } // 0xC GHLFADHILNN CEJJMKODOGK_get_typ HOHCEBMMACI_set_typ
	public uint IBAKPKKEDJM_month { get; set; } // 0x10 IDEJILEAOJM IJHAHFOOJKH_get_month LNKIOJGIKMB_set_month
	public uint JBGEEPFKIGG_val { get; set; } // 0x14 AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
	public uint PLALNIIBLOF_en { get; set; } // 0x18 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public int IJEKNCDIIAE_mver { get; set; } // 0x1C FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public uint AHILKBKLFJM { get; set; } // 0x20 KKMHFBEHFPE BOKMCIGOLOP_get_ HIFMNLCEDCB_set_
	public uint ODPMNBBBBIM { get; set; } // 0x24 APHBKNNKGPH GEEHPMGPKOJ_get_ FAKGBMJFGMM_set_
	public uint FBFLDFMFFOH_rar { get; set; } // 0x28 LMKEDCAPLEE HNLMNIOMOLI_get_rar CHHJKABBIBL_set_rar
}
public class CFJBIGCPCAK
{
	public LKGEMHKEBDJ[] IKIEMCADPMB { get; set; } // 0x8 DGKIEFMNGFJ OGMKENBNBAF_get_ JEBCKNLJICL_set_
	public static CFJBIGCPCAK HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x12B831C
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		PCGHGHNPJDO res_readData_ = PCGHGHNPJDO.GetRootAsPCGHGHNPJDO(buffer);
		CFJBIGCPCAK res_data_ = new CFJBIGCPCAK();

		List<LKGEMHKEBDJ> IKIEMCADPMB_list_ = new List<LKGEMHKEBDJ>();
		for(int IKIEMCADPMB_idx_ = 0; IKIEMCADPMB_idx_ < res_readData_.LMHJEEMBGIALength; IKIEMCADPMB_idx_++)
		{
			CNHFHECKIAI IKIEMCADPMB_readData_ = res_readData_.GetLMHJEEMBGIA(IKIEMCADPMB_idx_);
			LKGEMHKEBDJ IKIEMCADPMB_data_ = new LKGEMHKEBDJ();

			IKIEMCADPMB_data_.PPFNGGCBJKC_id = IKIEMCADPMB_readData_.BBPHAPFBFHK/*_id*/;
			IKIEMCADPMB_data_.GBJFNGCDKPM_typ = IKIEMCADPMB_readData_.LPJPOOHJKAE/*_typ*/;
			IKIEMCADPMB_data_.IBAKPKKEDJM_month = IKIEMCADPMB_readData_.CLGHAEBNGCF/*_month*/;
			IKIEMCADPMB_data_.JBGEEPFKIGG_val = IKIEMCADPMB_readData_.KJFEBMBHKOC/*_val*/;
			IKIEMCADPMB_data_.PLALNIIBLOF_en = IKIEMCADPMB_readData_.CFLMCGOJJJD/*_en*/;
			IKIEMCADPMB_data_.IJEKNCDIIAE_mver = IKIEMCADPMB_readData_.OFMGALJGDAO/*_mver*/;
			IKIEMCADPMB_data_.AHILKBKLFJM = IKIEMCADPMB_readData_.GODHIHAHFAH;
			IKIEMCADPMB_data_.ODPMNBBBBIM = IKIEMCADPMB_readData_.KJOOLCKNGMM;
			IKIEMCADPMB_data_.FBFLDFMFFOH_rar = IKIEMCADPMB_readData_.ODBPKGJPLMD/*_rar*/;
			IKIEMCADPMB_list_.Add(IKIEMCADPMB_data_);
		}
		res_data_.IKIEMCADPMB = IKIEMCADPMB_list_.ToArray();

		return res_data_;
	}
}
