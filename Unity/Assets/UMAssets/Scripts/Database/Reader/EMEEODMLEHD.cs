using FlatBuffers;
using System.Collections.Generic;

public class JOEEBALPECG
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int[] ECEOBKOFJHK { get; set; } // 0xC NBKODANCCCK LAEIFNHLJEF_get_ BPGGKDDGPIG_set_
	public int NDFOAINJPIN_pos { get; set; } // 0x10 MJDPJMGBMAA CLKKCPLEKBC_get_pos CLJOOFCICMO_set_pos
	public int[] OGDLCNPFODO { get; set; } // 0x14 CHFPHOCONMF IKPNMPPCGDA_get_ GBOBCAKPDIA_set_
	public string[] IPBHCLIHAPG_Msg { get; set; } // 0x18 PGDNLLBNAFF CBMCOGPJADM_get_Msg BAIGLALPKDE_set_Msg
}
public class EMEEODMLEHD
{
	public JOEEBALPECG[] DKBBEHIHBEK { get; set; } // 0x8 HKKFGHJJIHM OAODEMONFPC_get_ HKHMCAEJBHE_set_
	public static EMEEODMLEHD HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x130947C
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		JAAOECLAKNC res_readData_ = JAAOECLAKNC.GetRootAsJAAOECLAKNC(buffer);
		EMEEODMLEHD res_data_ = new EMEEODMLEHD();

		List<JOEEBALPECG> DKBBEHIHBEK_list_ = new List<JOEEBALPECG>();
		for(int DKBBEHIHBEK_idx_ = 0; DKBBEHIHBEK_idx_ < res_readData_.IDNFMKCJFDGLength; DKBBEHIHBEK_idx_++)
		{
			FFPCNIAALNN DKBBEHIHBEK_readData_ = res_readData_.GetIDNFMKCJFDG(DKBBEHIHBEK_idx_);
			JOEEBALPECG DKBBEHIHBEK_data_ = new JOEEBALPECG();

			DKBBEHIHBEK_data_.PPFNGGCBJKC_id = DKBBEHIHBEK_readData_.BBPHAPFBFHK/*_id*/;
			List<int> ECEOBKOFJHK_list_ = new List<int>();
			for(int ECEOBKOFJHK_idx_ = 0; ECEOBKOFJHK_idx_ < DKBBEHIHBEK_readData_.CLGAMGOJHHHLength; ECEOBKOFJHK_idx_++)
			{
				ECEOBKOFJHK_list_.Add(DKBBEHIHBEK_readData_.GetCLGAMGOJHHH(ECEOBKOFJHK_idx_));
			}
			DKBBEHIHBEK_data_.ECEOBKOFJHK = ECEOBKOFJHK_list_.ToArray();

			DKBBEHIHBEK_data_.NDFOAINJPIN_pos = DKBBEHIHBEK_readData_.LGEDAJAFHGG/*_pos*/;
			List<int> OGDLCNPFODO_list_ = new List<int>();
			for(int OGDLCNPFODO_idx_ = 0; OGDLCNPFODO_idx_ < DKBBEHIHBEK_readData_.BJHDJMNLEPPLength; OGDLCNPFODO_idx_++)
			{
				OGDLCNPFODO_list_.Add(DKBBEHIHBEK_readData_.GetBJHDJMNLEPP(OGDLCNPFODO_idx_));
			}
			DKBBEHIHBEK_data_.OGDLCNPFODO = OGDLCNPFODO_list_.ToArray();

			List<string> IPBHCLIHAPG_list_ = new List<string>();
			for(int IPBHCLIHAPG_idx_ = 0; IPBHCLIHAPG_idx_ < DKBBEHIHBEK_readData_.IKDLGFEPPDBLength; IPBHCLIHAPG_idx_++)
			{
				IPBHCLIHAPG_list_.Add(DKBBEHIHBEK_readData_.GetIKDLGFEPPDB(IPBHCLIHAPG_idx_));
			}
			DKBBEHIHBEK_data_.IPBHCLIHAPG_Msg = IPBHCLIHAPG_list_.ToArray();

			DKBBEHIHBEK_list_.Add(DKBBEHIHBEK_data_);
		}
		res_data_.DKBBEHIHBEK = DKBBEHIHBEK_list_.ToArray();

		return res_data_;
	}
}
