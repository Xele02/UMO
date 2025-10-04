using FlatBuffers;
using System.Collections.Generic;

public class BJALOLHCBKC
{
	public string MIMGPBHAJCO_file { get; set; } // 0x8 ICEMDJBNGJA JPMHJMDLFPI_get_file NLHKGLABKDI_set_file
	public uint BAOFEFFADPD_day { get; set; } // 0xC MNBJKHKHMCL KHNONKOPIPO_get_day LBJPPBMDOGE_set_day
	public uint BEPIOAIFCEC_op { get; set; } // 0x10 OHIHJLAHFOF GDBDINJGOKM_get_op JJHKMPPEBFG_set_op
}
public class PFCNGLGHLJA
{
	public string MIMGPBHAJCO_file { get; set; } // 0x8 ICEMDJBNGJA JPMHJMDLFPI_get_file NLHKGLABKDI_set_file
	public int IJEKNCDIIAE_mver { get; set; } // 0xC FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
}
public class CPHIOGHFPKN
{
	public BJALOLHCBKC[] IPHMDEOOFAI { get; set; } // 0x8 IEGLKEKHKIL JDENPLBHGJH_get_ JNIDAOHELKO_set_
	public int[] KLDHBJPDAFG { get; set; } // 0xC EKGDCBBGCHE HEEKBKPFJJJ_get_ PGDLNJLINBA_set_
	public string[] AMBODKHPHFH { get; set; } // 0x10 DIAHNBHBGJE GCCHEBPCBFN_get_ FFOBDPGIMMN_set_
	public string[] DNGKHGLIGKJ { get; set; } // 0x14 KOBOPEGFEGI DAMKLHGOOPG_get_ IJECLOFOFFO_set_
	public PFCNGLGHLJA[] DOGNLEPGCIK { get; set; } // 0x18 KKJGAONDLBD OIPPNEOLBOG_get_ KGLBGMBDOJC_set_
	public static CPHIOGHFPKN HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x176634C
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		OHOIIACCJAH res_readData_ = OHOIIACCJAH.GetRootAsOHOIIACCJAH(buffer);
		CPHIOGHFPKN res_data_ = new CPHIOGHFPKN();

		List<BJALOLHCBKC> IPHMDEOOFAI_list_ = new List<BJALOLHCBKC>();
		for(int IPHMDEOOFAI_idx_ = 0; IPHMDEOOFAI_idx_ < res_readData_.CMNLDHJPMPHLength; IPHMDEOOFAI_idx_++)
		{
			DIFBGFBHPNC IPHMDEOOFAI_readData_ = res_readData_.GetCMNLDHJPMPH(IPHMDEOOFAI_idx_);
			BJALOLHCBKC IPHMDEOOFAI_data_ = new BJALOLHCBKC();

			IPHMDEOOFAI_data_.MIMGPBHAJCO_file = IPHMDEOOFAI_readData_.DCEDMFDNAKH/*_file*/;
			IPHMDEOOFAI_data_.BAOFEFFADPD_day = IPHMDEOOFAI_readData_.FKGLOPMFMCP/*_day*/;
			IPHMDEOOFAI_data_.BEPIOAIFCEC_op = IPHMDEOOFAI_readData_.IAPOHBCMPPB/*_op*/;
			IPHMDEOOFAI_list_.Add(IPHMDEOOFAI_data_);
		}
		res_data_.IPHMDEOOFAI = IPHMDEOOFAI_list_.ToArray();

		List<int> KLDHBJPDAFG_list_ = new List<int>();
		for(int KLDHBJPDAFG_idx_ = 0; KLDHBJPDAFG_idx_ < res_readData_.NJAJCNKJFMNLength; KLDHBJPDAFG_idx_++)
		{
			KLDHBJPDAFG_list_.Add(res_readData_.GetNJAJCNKJFMN(KLDHBJPDAFG_idx_));
		}
		res_data_.KLDHBJPDAFG = KLDHBJPDAFG_list_.ToArray();

		List<string> AMBODKHPHFH_list_ = new List<string>();
		for(int AMBODKHPHFH_idx_ = 0; AMBODKHPHFH_idx_ < res_readData_.CDHLDAKBHCILength; AMBODKHPHFH_idx_++)
		{
			AMBODKHPHFH_list_.Add(res_readData_.GetCDHLDAKBHCI(AMBODKHPHFH_idx_));
		}
		res_data_.AMBODKHPHFH = AMBODKHPHFH_list_.ToArray();

		List<string> DNGKHGLIGKJ_list_ = new List<string>();
		for(int DNGKHGLIGKJ_idx_ = 0; DNGKHGLIGKJ_idx_ < res_readData_.JCKOPOCPOECLength; DNGKHGLIGKJ_idx_++)
		{
			DNGKHGLIGKJ_list_.Add(res_readData_.GetJCKOPOCPOEC(DNGKHGLIGKJ_idx_));
		}
		res_data_.DNGKHGLIGKJ = DNGKHGLIGKJ_list_.ToArray();

		List<PFCNGLGHLJA> DOGNLEPGCIK_list_ = new List<PFCNGLGHLJA>();
		for(int DOGNLEPGCIK_idx_ = 0; DOGNLEPGCIK_idx_ < res_readData_.GBHCJIPEFDFLength; DOGNLEPGCIK_idx_++)
		{
			AHCMKLEDILD DOGNLEPGCIK_readData_ = res_readData_.GetGBHCJIPEFDF(DOGNLEPGCIK_idx_);
			PFCNGLGHLJA DOGNLEPGCIK_data_ = new PFCNGLGHLJA();

			DOGNLEPGCIK_data_.MIMGPBHAJCO_file = DOGNLEPGCIK_readData_.DCEDMFDNAKH/*_file*/;
			DOGNLEPGCIK_data_.IJEKNCDIIAE_mver = DOGNLEPGCIK_readData_.OFMGALJGDAO/*_mver*/;
			DOGNLEPGCIK_list_.Add(DOGNLEPGCIK_data_);
		}
		res_data_.DOGNLEPGCIK = DOGNLEPGCIK_list_.ToArray();

		return res_data_;
	}
}
