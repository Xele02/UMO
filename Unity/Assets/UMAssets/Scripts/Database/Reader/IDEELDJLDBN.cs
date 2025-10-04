using FlatBuffers;
using System.Collections.Generic;

public class JGIHJPPECBB
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public string OPFGFINHFCE_name { get; set; } // 0xC LGIIAPHCLPN DKJOHDGOIJE_get_name MJAMIGECMMF_set_name
	public int BEBJKJKBOGH_date { get; set; } // 0x10 MCIJNMKFMDB DIAPHCJBPFD_get_date IHAIKPNEEJE_set_date
	public int IJEKNCDIIAE_mver { get; set; } // 0x14 FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
}
public class IDEELDJLDBN
{
	public JGIHJPPECBB[] MLOPDBGPLFI { get; set; } // 0x8 EGHMJKKFFBD LKEHBKLHHMP_get_ OCGNMNHBBPE_set_
	public static IDEELDJLDBN HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x11EB4FC
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		JHCHMCIFCND res_readData_ = JHCHMCIFCND.GetRootAsJHCHMCIFCND(buffer);
		IDEELDJLDBN res_data_ = new IDEELDJLDBN();

		List<JGIHJPPECBB> MLOPDBGPLFI_list_ = new List<JGIHJPPECBB>();
		for(int MLOPDBGPLFI_idx_ = 0; MLOPDBGPLFI_idx_ < res_readData_.MFLNKKKEGJHLength; MLOPDBGPLFI_idx_++)
		{
			GGCGMFLDFMA MLOPDBGPLFI_readData_ = res_readData_.GetMFLNKKKEGJH(MLOPDBGPLFI_idx_);
			JGIHJPPECBB MLOPDBGPLFI_data_ = new JGIHJPPECBB();

			MLOPDBGPLFI_data_.PPFNGGCBJKC_id = MLOPDBGPLFI_readData_.BBPHAPFBFHK/*_id*/;
			MLOPDBGPLFI_data_.OPFGFINHFCE_name = MLOPDBGPLFI_readData_.IIDCFMHCPLJ/*_name*/;
			MLOPDBGPLFI_data_.BEBJKJKBOGH_date = MLOPDBGPLFI_readData_.IBDFJIDNDJH/*_date*/;
			MLOPDBGPLFI_data_.IJEKNCDIIAE_mver = MLOPDBGPLFI_readData_.OFMGALJGDAO/*_mver*/;
			MLOPDBGPLFI_list_.Add(MLOPDBGPLFI_data_);
		}
		res_data_.MLOPDBGPLFI = MLOPDBGPLFI_list_.ToArray();

		return res_data_;
	}
}
