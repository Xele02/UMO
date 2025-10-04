using FlatBuffers;
using System.Collections.Generic;

public class KDNFKHOKMJL
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint JPFMJHLCMJL_sa { get; set; } // 0xC PIJIPMOBEIJ LLFFAPHPGFJ_get_sa PMGNHNIKHLE_set_sa
	public uint FLNJLKKAFPB_mdl { get; set; } // 0x10 JLLDIELMHID IHDOHKGJGCM_get_mdl IGNBIGFGIFM_set_mdl
	public uint HDEBAGHEIKD_plt { get; set; } // 0x14 LEOIDFOJDEB ILEIGMALLGJ_get_plt EEAKPBHBMOL_set_plt
	public uint FCBJFKGDINH_atk { get; set; } // 0x18 EKHAHLAEBNM APJOLOOEKPM_get_atk BEFLICOCMHH_set_atk
	public uint NONBCCLGBAO_hit { get; set; } // 0x1C FGGPAEAFOJK AEJBEGKBPCO_get_hit JPIBPFANBNG_set_hit
	public uint PLALNIIBLOF_en { get; set; } // 0x20 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public uint[] GMELAKNFKMG { get; set; } // 0x24 NBIGNIFKHLH GNIIGNBNAJF_get_ DNGBCJOKLND_set_
	public int IJEKNCDIIAE_mver { get; set; } // 0x28 FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public uint BMIJDLBGFNP_skill { get; set; } // 0x2C NLNNLBICNHM NIHGHMNFOAO_get_skill KOPGMKMNJJL_set_skill
	public int BFCBGDOICCO { get; set; } // 0x30 JIJFLOEODFI BMIDBHCAMPH_get_ DLNNMGILLDO_set_
}
public class NJOFJDHEGIK
{
	public KDNFKHOKMJL[] PIEGAMCFGGL { get; set; } // 0x8 LHBDLFBMMEE AFEINBHAFDG_get_ FPLDHNLOPKN_set_
	public static NJOFJDHEGIK HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x18AC780
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		LDLCKBMOFJC res_readData_ = LDLCKBMOFJC.GetRootAsLDLCKBMOFJC(buffer);
		NJOFJDHEGIK res_data_ = new NJOFJDHEGIK();

		List<KDNFKHOKMJL> PIEGAMCFGGL_list_ = new List<KDNFKHOKMJL>();
		for(int PIEGAMCFGGL_idx_ = 0; PIEGAMCFGGL_idx_ < res_readData_.HLBFAIIOKBILength; PIEGAMCFGGL_idx_++)
		{
			ILOKJEKGMOB PIEGAMCFGGL_readData_ = res_readData_.GetHLBFAIIOKBI(PIEGAMCFGGL_idx_);
			KDNFKHOKMJL PIEGAMCFGGL_data_ = new KDNFKHOKMJL();

			PIEGAMCFGGL_data_.PPFNGGCBJKC_id = PIEGAMCFGGL_readData_.BBPHAPFBFHK/*_id*/;
			PIEGAMCFGGL_data_.JPFMJHLCMJL_sa = PIEGAMCFGGL_readData_.GJEJFAJHBME/*_sa*/;
			PIEGAMCFGGL_data_.FLNJLKKAFPB_mdl = PIEGAMCFGGL_readData_.KAOBJENOMHF/*_mdl*/;
			PIEGAMCFGGL_data_.HDEBAGHEIKD_plt = PIEGAMCFGGL_readData_.DALJDMJEJGE/*_plt*/;
			PIEGAMCFGGL_data_.FCBJFKGDINH_atk = PIEGAMCFGGL_readData_.JJPIKBCKLGF/*_atk*/;
			PIEGAMCFGGL_data_.NONBCCLGBAO_hit = PIEGAMCFGGL_readData_.ENPKFDIPGPF/*_hit*/;
			PIEGAMCFGGL_data_.PLALNIIBLOF_en = PIEGAMCFGGL_readData_.CFLMCGOJJJD/*_en*/;
			List<uint> GMELAKNFKMG_list_ = new List<uint>();
			for(int GMELAKNFKMG_idx_ = 0; GMELAKNFKMG_idx_ < PIEGAMCFGGL_readData_.DLJEENDFNDBLength; GMELAKNFKMG_idx_++)
			{
				GMELAKNFKMG_list_.Add(PIEGAMCFGGL_readData_.GetDLJEENDFNDB(GMELAKNFKMG_idx_));
			}
			PIEGAMCFGGL_data_.GMELAKNFKMG = GMELAKNFKMG_list_.ToArray();

			PIEGAMCFGGL_data_.IJEKNCDIIAE_mver = PIEGAMCFGGL_readData_.OFMGALJGDAO/*_mver*/;
			PIEGAMCFGGL_data_.BMIJDLBGFNP_skill = PIEGAMCFGGL_readData_.MPIHPCJAHGA/*_skill*/;
			PIEGAMCFGGL_data_.BFCBGDOICCO = PIEGAMCFGGL_readData_.GBJKMHDILHH;
			PIEGAMCFGGL_list_.Add(PIEGAMCFGGL_data_);
		}
		res_data_.PIEGAMCFGGL = PIEGAMCFGGL_list_.ToArray();

		return res_data_;
	}
}
