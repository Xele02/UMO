using FlatBuffers;
using System.Collections.Generic;

public class LKCILPCIPBE
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int[] JIMJHIDEHNM_ApCounter { get; set; } // 0xC CPFMBIINNNL HMLIMKEFHHD_get_ApCounter OPHOIBNLNLN_set_ApCounter
	public int PLALNIIBLOF_en { get; set; } // 0x10 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public int[] HANMDEBPBHG_pic { get; set; } // 0x14 IMDBPCNAOOE EFGGIMOPNMG_get_pic PNGGKPFDKMA_set_pic
	public string[] IPBHCLIHAPG_Msg { get; set; } // 0x18 PGDNLLBNAFF CBMCOGPJADM_get_Msg BAIGLALPKDE_set_Msg
	public int IJEKNCDIIAE_mver { get; set; } // 0x1C FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public int KNHABOOAAIP { get; set; } // 0x20 ADCPFMGAFHF KILMBMIGBOE_get_ NEDDEHCHIBE_set_
	public string[] ADCMNODJBGJ_title { get; set; } // 0x24 PDOIKFFAKNG AJDDKABOOLK_get_title GHAHAGNIELN_set_title
	public int[] INANEEGAEEG { get; set; } // 0x28 CKPKJEJMACE GAEPJHACPBA_get_ FGPHIHOOEGP_set_
	public int[] JOFAJDPOEOB { get; set; } // 0x2C HFBODPFCJDN IFMBJHJFFNF_get_ CHNGFDMJKBE_set_
	public int DBHPPMPNCKF { get; set; } // 0x30 PLPJBFEDAOM JHLPDKDGDJB_get_ GBKBPCELENK_set_
	public int BFCILBEICEN { get; set; } // 0x34 GFBFNCJOPAL NBIIHNECDLH_get_ HPFFECCGJCP_set_
}
public class BOFIIKIJEPA
{
	public LKCILPCIPBE[] NBDMOIBEDFI { get; set; } // 0x8 PNNNALPPKAG EPIPNCALBIK_get_ AIDOPJFGDJI_set_
	public static BOFIIKIJEPA HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x19CCD6C
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		PCIPKGNLLBO res_readData_ = PCIPKGNLLBO.GetRootAsPCIPKGNLLBO(buffer);
		BOFIIKIJEPA res_data_ = new BOFIIKIJEPA();

		List<LKCILPCIPBE> NBDMOIBEDFI_list_ = new List<LKCILPCIPBE>();
		for(int NBDMOIBEDFI_idx_ = 0; NBDMOIBEDFI_idx_ < res_readData_.NGOGEEKMLKNLength; NBDMOIBEDFI_idx_++)
		{
			NHPNFFMICJP NBDMOIBEDFI_readData_ = res_readData_.GetNGOGEEKMLKN(NBDMOIBEDFI_idx_);
			LKCILPCIPBE NBDMOIBEDFI_data_ = new LKCILPCIPBE();

			NBDMOIBEDFI_data_.PPFNGGCBJKC_id = NBDMOIBEDFI_readData_.BBPHAPFBFHK/*_id*/;
			List<int> JIMJHIDEHNM_list_ = new List<int>();
			for(int JIMJHIDEHNM_idx_ = 0; JIMJHIDEHNM_idx_ < NBDMOIBEDFI_readData_.OFJEKBGFFPBLength; JIMJHIDEHNM_idx_++)
			{
				JIMJHIDEHNM_list_.Add(NBDMOIBEDFI_readData_.GetOFJEKBGFFPB(JIMJHIDEHNM_idx_));
			}
			NBDMOIBEDFI_data_.JIMJHIDEHNM_ApCounter = JIMJHIDEHNM_list_.ToArray();

			NBDMOIBEDFI_data_.PLALNIIBLOF_en = NBDMOIBEDFI_readData_.CFLMCGOJJJD/*_en*/;
			List<int> HANMDEBPBHG_list_ = new List<int>();
			for(int HANMDEBPBHG_idx_ = 0; HANMDEBPBHG_idx_ < NBDMOIBEDFI_readData_.KNOOHMIHJNLLength; HANMDEBPBHG_idx_++)
			{
				HANMDEBPBHG_list_.Add(NBDMOIBEDFI_readData_.GetKNOOHMIHJNL(HANMDEBPBHG_idx_));
			}
			NBDMOIBEDFI_data_.HANMDEBPBHG_pic = HANMDEBPBHG_list_.ToArray();

			List<string> IPBHCLIHAPG_list_ = new List<string>();
			for(int IPBHCLIHAPG_idx_ = 0; IPBHCLIHAPG_idx_ < NBDMOIBEDFI_readData_.IKDLGFEPPDBLength; IPBHCLIHAPG_idx_++)
			{
				IPBHCLIHAPG_list_.Add(NBDMOIBEDFI_readData_.GetIKDLGFEPPDB(IPBHCLIHAPG_idx_));
			}
			NBDMOIBEDFI_data_.IPBHCLIHAPG_Msg = IPBHCLIHAPG_list_.ToArray();

			NBDMOIBEDFI_data_.IJEKNCDIIAE_mver = NBDMOIBEDFI_readData_.OFMGALJGDAO/*_mver*/;
			NBDMOIBEDFI_data_.KNHABOOAAIP = NBDMOIBEDFI_readData_.EECIECJDLGC;
			List<string> ADCMNODJBGJ_list_ = new List<string>();
			for(int ADCMNODJBGJ_idx_ = 0; ADCMNODJBGJ_idx_ < NBDMOIBEDFI_readData_.CFBPBOLLPHHLength; ADCMNODJBGJ_idx_++)
			{
				ADCMNODJBGJ_list_.Add(NBDMOIBEDFI_readData_.GetCFBPBOLLPHH(ADCMNODJBGJ_idx_));
			}
			NBDMOIBEDFI_data_.ADCMNODJBGJ_title = ADCMNODJBGJ_list_.ToArray();

			List<int> INANEEGAEEG_list_ = new List<int>();
			for(int INANEEGAEEG_idx_ = 0; INANEEGAEEG_idx_ < NBDMOIBEDFI_readData_.KMLACADFKINLength; INANEEGAEEG_idx_++)
			{
				INANEEGAEEG_list_.Add(NBDMOIBEDFI_readData_.GetKMLACADFKIN(INANEEGAEEG_idx_));
			}
			NBDMOIBEDFI_data_.INANEEGAEEG = INANEEGAEEG_list_.ToArray();

			List<int> JOFAJDPOEOB_list_ = new List<int>();
			for(int JOFAJDPOEOB_idx_ = 0; JOFAJDPOEOB_idx_ < NBDMOIBEDFI_readData_.EGMHEAOKLNDLength; JOFAJDPOEOB_idx_++)
			{
				JOFAJDPOEOB_list_.Add(NBDMOIBEDFI_readData_.GetEGMHEAOKLND(JOFAJDPOEOB_idx_));
			}
			NBDMOIBEDFI_data_.JOFAJDPOEOB = JOFAJDPOEOB_list_.ToArray();

			NBDMOIBEDFI_data_.DBHPPMPNCKF = NBDMOIBEDFI_readData_.OILFLMOBFJM;
			NBDMOIBEDFI_data_.BFCILBEICEN = NBDMOIBEDFI_readData_.CMNENMNDDMO;
			NBDMOIBEDFI_list_.Add(NBDMOIBEDFI_data_);
		}
		res_data_.NBDMOIBEDFI = NBDMOIBEDFI_list_.ToArray();

		return res_data_;
	}
}
