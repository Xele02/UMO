using FlatBuffers;
using System.Collections.Generic;

public class AKJNKDNCCCC
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int[] AIHOJKFNEEN_itm { get; set; } // 0xC GGBFCEFNCFM BGFIPHMMOGA_get_itm DHAIHODDOGM_set_itm
	public uint[] BFINGCJHOHI_cnt { get; set; } // 0x10 PIAHJAJPLKA LFMCLIDAPHB_get_cnt EDAEPDGGFJJ_set_cnt
	public int EKLIPGELKCL_Rarity { get; set; } // 0x14 DMGPKEIBKHJ OEEHBGECGKL_get_Rarity GHLMHLJJBIG_set_Rarity
}
public class FPDHPIEBAHD
{
	public AKJNKDNCCCC[] LIFDACJBDBA { get; set; } // 0x8 DHNOPCHCIOG OFJIEKEMPDA_get_ NDIKFOLDBJJ_set_
	public static FPDHPIEBAHD HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x13F9DA4
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		MNENFGHNPFJ res_readData_ = MNENFGHNPFJ.GetRootAsMNENFGHNPFJ(buffer);
		FPDHPIEBAHD res_data_ = new FPDHPIEBAHD();

		List<AKJNKDNCCCC> LIFDACJBDBA_list_ = new List<AKJNKDNCCCC>();
		for(int LIFDACJBDBA_idx_ = 0; LIFDACJBDBA_idx_ < res_readData_.PKMCMIBBNDOLength; LIFDACJBDBA_idx_++)
		{
			OAAJBDOIHLD LIFDACJBDBA_readData_ = res_readData_.GetPKMCMIBBNDO(LIFDACJBDBA_idx_);
			AKJNKDNCCCC LIFDACJBDBA_data_ = new AKJNKDNCCCC();

			LIFDACJBDBA_data_.PPFNGGCBJKC_id = LIFDACJBDBA_readData_.BBPHAPFBFHK/*_id*/;
			List<int> AIHOJKFNEEN_list_ = new List<int>();
			for(int AIHOJKFNEEN_idx_ = 0; AIHOJKFNEEN_idx_ < LIFDACJBDBA_readData_.LEFPIGNDJNCLength; AIHOJKFNEEN_idx_++)
			{
				AIHOJKFNEEN_list_.Add(LIFDACJBDBA_readData_.GetLEFPIGNDJNC(AIHOJKFNEEN_idx_));
			}
			LIFDACJBDBA_data_.AIHOJKFNEEN_itm = AIHOJKFNEEN_list_.ToArray();

			List<uint> BFINGCJHOHI_list_ = new List<uint>();
			for(int BFINGCJHOHI_idx_ = 0; BFINGCJHOHI_idx_ < LIFDACJBDBA_readData_.BNCIPLKECMCLength; BFINGCJHOHI_idx_++)
			{
				BFINGCJHOHI_list_.Add(LIFDACJBDBA_readData_.GetBNCIPLKECMC(BFINGCJHOHI_idx_));
			}
			LIFDACJBDBA_data_.BFINGCJHOHI_cnt = BFINGCJHOHI_list_.ToArray();

			LIFDACJBDBA_data_.EKLIPGELKCL_Rarity = LIFDACJBDBA_readData_.CDNLIGMMGBA/*_Rarity*/;
			LIFDACJBDBA_list_.Add(LIFDACJBDBA_data_);
		}
		res_data_.LIFDACJBDBA = LIFDACJBDBA_list_.ToArray();

		return res_data_;
	}
}
