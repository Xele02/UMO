using FlatBuffers;
using System.Collections.Generic;

public class IHANOPGIKEO
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint EJPKFBHNDGI_ev_no { get; set; } // 0xC EMPIMMNPMJL BDKLEOCKELL_get_ev_no JILBLBACAEL_set_ev_no
	public uint GOBMACPDDCL_ev_id { get; set; } // 0x10 EKOLNCPJDPN ODBGFPGPPAC_get_ev_id LIMKOCNLLPL_set_ev_id
	public uint JBGEEPFKIGG_val { get; set; } // 0x14 AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
	public uint DOOGFEGEKLG_max { get; set; } // 0x18 IKKMNBJGBJK AECMFIOFFJN_get_max NGOJJDOCIDG_set_max
	public uint EMIJNAFJFJO_expir { get; set; } // 0x1C GBHMMAHHJGG GBGPKONOFGD_get_expir KCFHLAFJJPJ_set_expir
	public uint PLALNIIBLOF_en { get; set; } // 0x20 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public int IJEKNCDIIAE_mver { get; set; } // 0x24 FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
}
public class BOLCKDHHNDB
{
	public IHANOPGIKEO[] IIHHPGHEIIN { get; set; } // 0x8 AKOJOKBBNPK EICLLOMMNEL_get_ PCIILNEOKOP_set_
	public static BOLCKDHHNDB HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x19CF110
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		ONCFNGIBLHO res_readData_ = ONCFNGIBLHO.GetRootAsONCFNGIBLHO(buffer);
		BOLCKDHHNDB res_data_ = new BOLCKDHHNDB();

		List<IHANOPGIKEO> IIHHPGHEIIN_list_ = new List<IHANOPGIKEO>();
		for(int IIHHPGHEIIN_idx_ = 0; IIHHPGHEIIN_idx_ < res_readData_.KDGCIEMFIIMLength; IIHHPGHEIIN_idx_++)
		{
			INFGGLDJAIF IIHHPGHEIIN_readData_ = res_readData_.GetKDGCIEMFIIM(IIHHPGHEIIN_idx_);
			IHANOPGIKEO IIHHPGHEIIN_data_ = new IHANOPGIKEO();

			IIHHPGHEIIN_data_.PPFNGGCBJKC_id = IIHHPGHEIIN_readData_.BBPHAPFBFHK/*_id*/;
			IIHHPGHEIIN_data_.EJPKFBHNDGI_ev_no = IIHHPGHEIIN_readData_.ONGGCPLNOFG/*_ev_no*/;
			IIHHPGHEIIN_data_.GOBMACPDDCL_ev_id = IIHHPGHEIIN_readData_.BMACFCLAHFD/*_ev_id*/;
			IIHHPGHEIIN_data_.JBGEEPFKIGG_val = IIHHPGHEIIN_readData_.KJFEBMBHKOC/*_val*/;
			IIHHPGHEIIN_data_.DOOGFEGEKLG_max = IIHHPGHEIIN_readData_.GEJGMBBCFEE/*_max*/;
			IIHHPGHEIIN_data_.EMIJNAFJFJO_expir = IIHHPGHEIIN_readData_.HHGNAFHNHEK/*_expir*/;
			IIHHPGHEIIN_data_.PLALNIIBLOF_en = IIHHPGHEIIN_readData_.CFLMCGOJJJD/*_en*/;
			IIHHPGHEIIN_data_.IJEKNCDIIAE_mver = IIHHPGHEIIN_readData_.OFMGALJGDAO/*_mver*/;
			IIHHPGHEIIN_list_.Add(IIHHPGHEIIN_data_);
		}
		res_data_.IIHHPGHEIIN = IIHHPGHEIIN_list_.ToArray();

		return res_data_;
	}
}
