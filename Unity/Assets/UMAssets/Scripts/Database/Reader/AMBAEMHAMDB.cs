using FlatBuffers;
using System.Collections.Generic;

public class IFHOHAKPGJH
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint PLALNIIBLOF_en { get; set; } // 0xC DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public uint JBGEEPFKIGG_val { get; set; } // 0x10 AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
	public uint DMEDKJPOLCH_cat { get; set; } // 0x14 JAEJJPMKMFI IPKCKAAEEOE_get_cat JOGLLINFLJN_set_cat
	public uint GLCLFMGPMAN_ItemId { get; set; } // 0x18 KCELNMGLKHH LNJAENEGDEL_get_ItemId JHIDBGCHOKL_set_ItemId
	public uint HHDGLPENPFI { get; set; } // 0x1C PFLNEOFEPNI JLIOIEFANME_get_ GMIFKKGDLHE_set_
}
public class EMLAKILKONB
{
	public uint ANAJIAENLNB_lv { get; set; } // 0x8 IKMILCFHBGA MMOMNMBKHJF_get_lv FEHNFGPFINK_set_lv
	public uint IHGDLBBPKFI_Next { get; set; } // 0xC GDDAGPGNGHK ONOBDELIEFB_get_Next MKNICENPJBP_set_Next
	public uint BDLNMOIOMHK_total { get; set; } // 0x10 EFBBEAKKPLD MKMAKAEDMBG_get_total GIJPLHEDIKD_set_total
	public uint DMEDKJPOLCH_cat { get; set; } // 0x14 JAEJJPMKMFI IPKCKAAEEOE_get_cat JOGLLINFLJN_set_cat
	public uint EIIDPKCBKEK_prm { get; set; } // 0x18 MEKBBDAJLIP GNOMKOGNGAD_get_prm LIAJMHMKLLM_set_prm
	public uint[] DKHIHHMOIKM_bns { get; set; } // 0x1C DDCGLGKFHPP OCOHLFAFINM_get_bns DPEOFJJLPML_set_bns
}
public class MDJJGLEJPFN
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint JBGEEPFKIGG_val { get; set; } // 0xC AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
}
public class AGPHLNAPAKA
{
	public string LJNAKDMILMC_key { get; set; } // 0x8 KNJIHALCKLN LIIHHICIBKM_get_key OACJGKPBHIK_set_key
	public int JBGEEPFKIGG_val { get; set; } // 0xC AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
}
public class CMNIIDMIIHI
{
	public string LJNAKDMILMC_key { get; set; } // 0x8 KNJIHALCKLN LIIHHICIBKM_get_key OACJGKPBHIK_set_key
	public string JBGEEPFKIGG_val { get; set; } // 0xC AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
}
public class AMBAEMHAMDB
{
	public IFHOHAKPGJH[] IINOBJKJGFK { get; set; } // 0x8 KFNKPOHMHPG KGDFPIHHCLP_get_ JPJMIMNAACK_set_
	public EMLAKILKONB[] PMICJEAOFMA { get; set; } // 0xC BDGJIKGDPGB KNBKLHDDMPM_get_ NPPNNNEKAKM_set_
	public MDJJGLEJPFN[] MIDBJNKMPEM { get; set; } // 0x10 PCPJBEOLNCA AMBBNJCAEGE_get_ NELLOBKBLEM_set_
	public AGPHLNAPAKA[] BHGDNGHDDAC { get; set; } // 0x14 JHDNDHBDFFI CEHHJMMMCID_get_ EDOEOHENKDG_set_
	public CMNIIDMIIHI[] MHGMDJNOLMI { get; set; } // 0x18 JBFEKPIDNIC NFFJJGMEEOB_get_ BGEFBFOAMPK_set_
	public static AMBAEMHAMDB HEGEKFMJNCC(byte[] NIODCJLINJN)// 0xCE01E0
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		KHKJEJCOAHJ res_readData_ = KHKJEJCOAHJ.GetRootAsKHKJEJCOAHJ(buffer);
		AMBAEMHAMDB res_data_ = new AMBAEMHAMDB();

		List<IFHOHAKPGJH> IINOBJKJGFK_list_ = new List<IFHOHAKPGJH>();
		for(int IINOBJKJGFK_idx_ = 0; IINOBJKJGFK_idx_ < res_readData_.KNPAODNMJMKLength; IINOBJKJGFK_idx_++)
		{
			HOIBFMCEOJO IINOBJKJGFK_readData_ = res_readData_.GetKNPAODNMJMK(IINOBJKJGFK_idx_);
			IFHOHAKPGJH IINOBJKJGFK_data_ = new IFHOHAKPGJH();

			IINOBJKJGFK_data_.PPFNGGCBJKC_id = IINOBJKJGFK_readData_.BBPHAPFBFHK/*_id*/;
			IINOBJKJGFK_data_.PLALNIIBLOF_en = IINOBJKJGFK_readData_.CFLMCGOJJJD/*_en*/;
			IINOBJKJGFK_data_.JBGEEPFKIGG_val = IINOBJKJGFK_readData_.KJFEBMBHKOC/*_val*/;
			IINOBJKJGFK_data_.DMEDKJPOLCH_cat = IINOBJKJGFK_readData_.ADCLAGBHDBC/*_cat*/;
			IINOBJKJGFK_data_.GLCLFMGPMAN_ItemId = IINOBJKJGFK_readData_.MBBJMJAAODG/*_ItemId*/;
			IINOBJKJGFK_data_.HHDGLPENPFI = IINOBJKJGFK_readData_.BIIMAJJDAAE;
			IINOBJKJGFK_list_.Add(IINOBJKJGFK_data_);
		}
		res_data_.IINOBJKJGFK = IINOBJKJGFK_list_.ToArray();

		List<EMLAKILKONB> PMICJEAOFMA_list_ = new List<EMLAKILKONB>();
		for(int PMICJEAOFMA_idx_ = 0; PMICJEAOFMA_idx_ < res_readData_.ACFJPKHNLHILength; PMICJEAOFMA_idx_++)
		{
			APIFHKKHODH PMICJEAOFMA_readData_ = res_readData_.GetACFJPKHNLHI(PMICJEAOFMA_idx_);
			EMLAKILKONB PMICJEAOFMA_data_ = new EMLAKILKONB();

			PMICJEAOFMA_data_.ANAJIAENLNB_lv = PMICJEAOFMA_readData_.DLPCOLDNAKE/*_lv*/;
			PMICJEAOFMA_data_.IHGDLBBPKFI_Next = PMICJEAOFMA_readData_.GDLJMMPFINH/*_Next*/;
			PMICJEAOFMA_data_.BDLNMOIOMHK_total = PMICJEAOFMA_readData_.LBMKEILIGBG/*_total*/;
			PMICJEAOFMA_data_.DMEDKJPOLCH_cat = PMICJEAOFMA_readData_.ADCLAGBHDBC/*_cat*/;
			PMICJEAOFMA_data_.EIIDPKCBKEK_prm = PMICJEAOFMA_readData_.CBPNNKIHKNG/*_prm*/;
			List<uint> DKHIHHMOIKM_list_ = new List<uint>();
			for(int DKHIHHMOIKM_idx_ = 0; DKHIHHMOIKM_idx_ < PMICJEAOFMA_readData_.PMNEOKOIHPDLength; DKHIHHMOIKM_idx_++)
			{
				DKHIHHMOIKM_list_.Add(PMICJEAOFMA_readData_.GetPMNEOKOIHPD(DKHIHHMOIKM_idx_));
			}
			PMICJEAOFMA_data_.DKHIHHMOIKM_bns = DKHIHHMOIKM_list_.ToArray();

			PMICJEAOFMA_list_.Add(PMICJEAOFMA_data_);
		}
		res_data_.PMICJEAOFMA = PMICJEAOFMA_list_.ToArray();

		List<MDJJGLEJPFN> MIDBJNKMPEM_list_ = new List<MDJJGLEJPFN>();
		for(int MIDBJNKMPEM_idx_ = 0; MIDBJNKMPEM_idx_ < res_readData_.ACKHFBIGNFJLength; MIDBJNKMPEM_idx_++)
		{
			GDNMLJHGFMI MIDBJNKMPEM_readData_ = res_readData_.GetACKHFBIGNFJ(MIDBJNKMPEM_idx_);
			MDJJGLEJPFN MIDBJNKMPEM_data_ = new MDJJGLEJPFN();

			MIDBJNKMPEM_data_.PPFNGGCBJKC_id = MIDBJNKMPEM_readData_.BBPHAPFBFHK/*_id*/;
			MIDBJNKMPEM_data_.JBGEEPFKIGG_val = MIDBJNKMPEM_readData_.KJFEBMBHKOC/*_val*/;
			MIDBJNKMPEM_list_.Add(MIDBJNKMPEM_data_);
		}
		res_data_.MIDBJNKMPEM = MIDBJNKMPEM_list_.ToArray();

		List<AGPHLNAPAKA> BHGDNGHDDAC_list_ = new List<AGPHLNAPAKA>();
		for(int BHGDNGHDDAC_idx_ = 0; BHGDNGHDDAC_idx_ < res_readData_.NJJINHMIOHNLength; BHGDNGHDDAC_idx_++)
		{
			ACNIPCFGMAE BHGDNGHDDAC_readData_ = res_readData_.GetNJJINHMIOHN(BHGDNGHDDAC_idx_);
			AGPHLNAPAKA BHGDNGHDDAC_data_ = new AGPHLNAPAKA();

			BHGDNGHDDAC_data_.LJNAKDMILMC_key = BHGDNGHDDAC_readData_.AGOIMGHMGOH/*_key*/;
			BHGDNGHDDAC_data_.JBGEEPFKIGG_val = BHGDNGHDDAC_readData_.KJFEBMBHKOC/*_val*/;
			BHGDNGHDDAC_list_.Add(BHGDNGHDDAC_data_);
		}
		res_data_.BHGDNGHDDAC = BHGDNGHDDAC_list_.ToArray();

		List<CMNIIDMIIHI> MHGMDJNOLMI_list_ = new List<CMNIIDMIIHI>();
		for(int MHGMDJNOLMI_idx_ = 0; MHGMDJNOLMI_idx_ < res_readData_.NPFBHGKLIOMLength; MHGMDJNOLMI_idx_++)
		{
			OGLBCNFMFEK MHGMDJNOLMI_readData_ = res_readData_.GetNPFBHGKLIOM(MHGMDJNOLMI_idx_);
			CMNIIDMIIHI MHGMDJNOLMI_data_ = new CMNIIDMIIHI();

			MHGMDJNOLMI_data_.LJNAKDMILMC_key = MHGMDJNOLMI_readData_.AGOIMGHMGOH/*_key*/;
			MHGMDJNOLMI_data_.JBGEEPFKIGG_val = MHGMDJNOLMI_readData_.KJFEBMBHKOC/*_val*/;
			MHGMDJNOLMI_list_.Add(MHGMDJNOLMI_data_);
		}
		res_data_.MHGMDJNOLMI = MHGMDJNOLMI_list_.ToArray();

		return res_data_;
	}
}
