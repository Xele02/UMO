using FlatBuffers;
using System.Collections.Generic;

public class BEHPCLGJNDE
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint GBJFNGCDKPM_typ { get; set; } // 0xC GHLFADHILNN CEJJMKODOGK_get_typ HOHCEBMMACI_set_typ
	public int OENPCNBFPDA_bg_id { get; set; } // 0x10 CFHILALNGHJ BNLALNCFJPB_get_bg_id KPJBLJCKBLF_set_bg_id
	public int KFNDHKFLPPK_mus_id { get; set; } // 0x14 IKDKPOLAAHF CCPAPHPPGOB_get_mus_id ICBGFBNICOE_set_mus_id
	public uint PDBPFJJCADD_open_at { get; set; } // 0x18 PMJMBGBCIGO FOACOMBHPAC_get_open_at NBACOBCOJCA_set_open_at
	public uint FDBNFFNFOND_close_at { get; set; } // 0x1C INOJHLHGKMI BPJOGHJCLDJ_get_close_at NLJKMCHOCBK_set_close_at
	public uint PLALNIIBLOF_en { get; set; } // 0x20 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public int IJEKNCDIIAE_mver { get; set; } // 0x24 FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public int LEJOJFHKHIJ_Have { get; set; } // 0x28 FHBFPFOLLHA PGCOGCIHNGG_get_Have PJDCNPKFOBE_set_Have
	public string OPFGFINHFCE_name { get; set; } // 0x2C LGIIAPHCLPN DKJOHDGOIJE_get_name MJAMIGECMMF_set_name
	public int JPFMJHLCMJL_sa { get; set; } // 0x30 PIJIPMOBEIJ LLFFAPHPGFJ_get_sa PMGNHNIKHLE_set_sa
}
public class LEGLJNFOBGN
{
	public BEHPCLGJNDE[] AFNCMAJBLGO { get; set; } // 0x8 MCEMGKGEEEK JJCLCHLCEDN_get_ ENMBCFNMPBO_set_
	public static LEGLJNFOBGN HEGEKFMJNCC(byte[] NIODCJLINJN)// 0xD67EB0
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		CHFNKBBHDGM res_readData_ = CHFNKBBHDGM.GetRootAsCHFNKBBHDGM(buffer);
		LEGLJNFOBGN res_data_ = new LEGLJNFOBGN();

		List<BEHPCLGJNDE> AFNCMAJBLGO_list_ = new List<BEHPCLGJNDE>();
		for(int AFNCMAJBLGO_idx_ = 0; AFNCMAJBLGO_idx_ < res_readData_.EMGBLHGBJNDLength; AFNCMAJBLGO_idx_++)
		{
			CJBICDDNGHH AFNCMAJBLGO_readData_ = res_readData_.GetEMGBLHGBJND(AFNCMAJBLGO_idx_);
			BEHPCLGJNDE AFNCMAJBLGO_data_ = new BEHPCLGJNDE();

			AFNCMAJBLGO_data_.PPFNGGCBJKC_id = AFNCMAJBLGO_readData_.BBPHAPFBFHK/*_id*/;
			AFNCMAJBLGO_data_.GBJFNGCDKPM_typ = AFNCMAJBLGO_readData_.LPJPOOHJKAE/*_typ*/;
			AFNCMAJBLGO_data_.OENPCNBFPDA_bg_id = AFNCMAJBLGO_readData_.MOMCBJDJDIA/*_bg_id*/;
			AFNCMAJBLGO_data_.KFNDHKFLPPK_mus_id = AFNCMAJBLGO_readData_.IMCIIPLKCNO/*_mus_id*/;
			AFNCMAJBLGO_data_.PDBPFJJCADD_open_at = AFNCMAJBLGO_readData_.NJLJEKDBPCH/*_open_at*/;
			AFNCMAJBLGO_data_.FDBNFFNFOND_close_at = AFNCMAJBLGO_readData_.MAOAGDBDBIB/*_close_at*/;
			AFNCMAJBLGO_data_.PLALNIIBLOF_en = AFNCMAJBLGO_readData_.CFLMCGOJJJD/*_en*/;
			AFNCMAJBLGO_data_.IJEKNCDIIAE_mver = AFNCMAJBLGO_readData_.OFMGALJGDAO/*_mver*/;
			AFNCMAJBLGO_data_.LEJOJFHKHIJ_Have = AFNCMAJBLGO_readData_.EJPEFOELHFD/*_Have*/;
			AFNCMAJBLGO_data_.OPFGFINHFCE_name = AFNCMAJBLGO_readData_.IIDCFMHCPLJ/*_name*/;
			AFNCMAJBLGO_data_.JPFMJHLCMJL_sa = AFNCMAJBLGO_readData_.GJEJFAJHBME/*_sa*/;
			AFNCMAJBLGO_list_.Add(AFNCMAJBLGO_data_);
		}
		res_data_.AFNCMAJBLGO = AFNCMAJBLGO_list_.ToArray();

		return res_data_;
	}
}
