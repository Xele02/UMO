using FlatBuffers;
using System.Collections.Generic;

public class GEAAFPCHGFA
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint PLALNIIBLOF_en { get; set; } // 0xC DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public uint[] JGOHPDKCJKB_rw { get; set; } // 0x10 HOBIJNCHJHA MJFPLENCCCP_get_rw OKELMCNLMDD_set_rw
	public uint BDJMFDKLHPM_s_id { get; set; } // 0x14 EOBCNECIOMH GFMBGPMJPLJ_get_s_id ENAMMCHJBDE_set_s_id
	public uint FPOMEEJFBIG_odr { get; set; } // 0x18 PJKJIFMIFDJ OEEBAHNAPEC_get_odr BEHAPLPPLNE_set_odr
	public int IJEKNCDIIAE_mver { get; set; } // 0x1C FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
}
public class INBANFOPJLF
{
	public uint BDJMFDKLHPM_s_id { get; set; } // 0x8 EOBCNECIOMH GFMBGPMJPLJ_get_s_id ENAMMCHJBDE_set_s_id
	public int[] FOILNHKHHDF_pt { get; set; } // 0xC LNNCNOIGMGM FOFBHPJDHFO_get_pt LHPMDDKPJDP_set_pt
}
public class INMFBOOGCLB
{
	public uint FCEJJEPFIPH_rwid { get; set; } // 0x8 ACOJMMLFGOK LLLKCLJBPBL_get_rwid IBLEKPDKFDO_set_rwid
	public uint AIHOJKFNEEN_itm { get; set; } // 0xC GGBFCEFNCFM BGFIPHMMOGA_get_itm DHAIHODDOGM_set_itm
	public uint BFINGCJHOHI_cnt { get; set; } // 0x10 PIAHJAJPLKA LFMCLIDAPHB_get_cnt EDAEPDGGFJJ_set_cnt
	public uint GPDEFAHJCBM { get; set; } // 0x14 LKKOPLGAIBL LNJCGKMOJHF_get_ DOBKHNNOPBH_set_
}
public class MHNEAKBPPDA
{
	public GEAAFPCHGFA[] LCLJDEHGMCO { get; set; } // 0x8 NAMGNHGIGOP BEANGFGKAMC_get_ IPMAIDABPLG_set_
	public INBANFOPJLF[] ECPDOFEOIPA { get; set; } // 0xC MDKBAEGFGCO JEBBAEOJEKE_get_ BICAMOJBDMP_set_
	public INMFBOOGCLB[] APHNKNGKKFC { get; set; } // 0x10 NKNDJILLFLC IGMIBBHAANI_get_ LBGEJOLEKPL_set_
	public static MHNEAKBPPDA HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x195363C
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		KFHCGBOADLE res_readData_ = KFHCGBOADLE.GetRootAsKFHCGBOADLE(buffer);
		MHNEAKBPPDA res_data_ = new MHNEAKBPPDA();

		List<GEAAFPCHGFA> LCLJDEHGMCO_list_ = new List<GEAAFPCHGFA>();
		for(int LCLJDEHGMCO_idx_ = 0; LCLJDEHGMCO_idx_ < res_readData_.BHHFEPOGOIGLength; LCLJDEHGMCO_idx_++)
		{
			ODDOBDBBJAB LCLJDEHGMCO_readData_ = res_readData_.GetBHHFEPOGOIG(LCLJDEHGMCO_idx_);
			GEAAFPCHGFA LCLJDEHGMCO_data_ = new GEAAFPCHGFA();

			LCLJDEHGMCO_data_.PPFNGGCBJKC_id = LCLJDEHGMCO_readData_.BBPHAPFBFHK/*_id*/;
			LCLJDEHGMCO_data_.PLALNIIBLOF_en = LCLJDEHGMCO_readData_.CFLMCGOJJJD/*_en*/;
			List<uint> JGOHPDKCJKB_list_ = new List<uint>();
			for(int JGOHPDKCJKB_idx_ = 0; JGOHPDKCJKB_idx_ < LCLJDEHGMCO_readData_.FAOBJKICMBBLength; JGOHPDKCJKB_idx_++)
			{
				JGOHPDKCJKB_list_.Add(LCLJDEHGMCO_readData_.GetFAOBJKICMBB(JGOHPDKCJKB_idx_));
			}
			LCLJDEHGMCO_data_.JGOHPDKCJKB_rw = JGOHPDKCJKB_list_.ToArray();

			LCLJDEHGMCO_data_.BDJMFDKLHPM_s_id = LCLJDEHGMCO_readData_.MJOCIHPPKNO/*_s_id*/;
			LCLJDEHGMCO_data_.FPOMEEJFBIG_odr = LCLJDEHGMCO_readData_.AEAKMMJLLDK/*_odr*/;
			LCLJDEHGMCO_data_.IJEKNCDIIAE_mver = LCLJDEHGMCO_readData_.OFMGALJGDAO/*_mver*/;
			LCLJDEHGMCO_list_.Add(LCLJDEHGMCO_data_);
		}
		res_data_.LCLJDEHGMCO = LCLJDEHGMCO_list_.ToArray();

		List<INBANFOPJLF> ECPDOFEOIPA_list_ = new List<INBANFOPJLF>();
		for(int ECPDOFEOIPA_idx_ = 0; ECPDOFEOIPA_idx_ < res_readData_.CMAPNGGMDOILength; ECPDOFEOIPA_idx_++)
		{
			DNHKFIKECGD ECPDOFEOIPA_readData_ = res_readData_.GetCMAPNGGMDOI(ECPDOFEOIPA_idx_);
			INBANFOPJLF ECPDOFEOIPA_data_ = new INBANFOPJLF();

			ECPDOFEOIPA_data_.BDJMFDKLHPM_s_id = ECPDOFEOIPA_readData_.MJOCIHPPKNO/*_s_id*/;
			List<int> FOILNHKHHDF_list_ = new List<int>();
			for(int FOILNHKHHDF_idx_ = 0; FOILNHKHHDF_idx_ < ECPDOFEOIPA_readData_.HFOJCEBNHCILength; FOILNHKHHDF_idx_++)
			{
				FOILNHKHHDF_list_.Add(ECPDOFEOIPA_readData_.GetHFOJCEBNHCI(FOILNHKHHDF_idx_));
			}
			ECPDOFEOIPA_data_.FOILNHKHHDF_pt = FOILNHKHHDF_list_.ToArray();

			ECPDOFEOIPA_list_.Add(ECPDOFEOIPA_data_);
		}
		res_data_.ECPDOFEOIPA = ECPDOFEOIPA_list_.ToArray();

		List<INMFBOOGCLB> APHNKNGKKFC_list_ = new List<INMFBOOGCLB>();
		for(int APHNKNGKKFC_idx_ = 0; APHNKNGKKFC_idx_ < res_readData_.ILBKJACHOHMLength; APHNKNGKKFC_idx_++)
		{
			PCDBMJGPDFN APHNKNGKKFC_readData_ = res_readData_.GetILBKJACHOHM(APHNKNGKKFC_idx_);
			INMFBOOGCLB APHNKNGKKFC_data_ = new INMFBOOGCLB();

			APHNKNGKKFC_data_.FCEJJEPFIPH_rwid = APHNKNGKKFC_readData_.LNHODOPAJIL/*_rwid*/;
			APHNKNGKKFC_data_.AIHOJKFNEEN_itm = APHNKNGKKFC_readData_.LHMHAFHMNFF/*_itm*/;
			APHNKNGKKFC_data_.BFINGCJHOHI_cnt = APHNKNGKKFC_readData_.CLEEFGNMCEL/*_cnt*/;
			APHNKNGKKFC_data_.GPDEFAHJCBM = APHNKNGKKFC_readData_.CIJLLHJEANC;
			APHNKNGKKFC_list_.Add(APHNKNGKKFC_data_);
		}
		res_data_.APHNKNGKKFC = APHNKNGKKFC_list_.ToArray();

		return res_data_;
	}
}
