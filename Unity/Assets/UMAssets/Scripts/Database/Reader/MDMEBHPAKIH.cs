using FlatBuffers;
using System.Collections.Generic;

public class DDHCKMFAKFA
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int IJEKNCDIIAE_mver { get; set; } // 0xC FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public int PLALNIIBLOF_en { get; set; } // 0x10 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public int FBFLDFMFFOH_rar { get; set; } // 0x14 LMKEDCAPLEE HNLMNIOMOLI_get_rar CHHJKABBIBL_set_rar
	public int MLMCEBBDJOE { get; set; } // 0x18 LNGPPHKHGMH IGMHCODOFKG_get_ IIIGDLGGEGK_set_
	public int ODNILEDOAIP { get; set; } // 0x1C LMNIPCGLCCM GNKPMBBAJHI_get_ PPMACIMALAC_set_
	public int NPPGKNGIFGK_price { get; set; } // 0x20 JDJKLDMOMGO FLMDBAFHDNJ_get_price DIHIEJPOCOJ_set_price
	public int[] PIPDCAEIBPO { get; set; } // 0x24 MDOGGIFJDBA MIOJEAKDNKO_get_ OBPFGNALDKP_set_
	public int KEJMJPHFFOJ_Max { get; set; } // 0x28 NNGEOJMHAEA FMNMLNIALNE_get_Max GBEPCBPOGDB_set_Max
	public int CPKMLLNADLJ_Serie { get; set; } // 0x2C COPJCMLLIMO BJPJMGHCDNO_get_Serie BPKIOJBKNBP_set_Serie
}
public class MDMEBHPAKIH
{
	public DDHCKMFAKFA[] NFBMFDPFHCL { get; set; } // 0x8 HDEEHBKLIOD DANCLHPKEMO_get_ OIPCINELDBO_set_
	public static MDMEBHPAKIH HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x13100F0
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		JBMPGMCNGNP res_readData_ = JBMPGMCNGNP.GetRootAsJBMPGMCNGNP(buffer);
		MDMEBHPAKIH res_data_ = new MDMEBHPAKIH();

		List<DDHCKMFAKFA> NFBMFDPFHCL_list_ = new List<DDHCKMFAKFA>();
		for(int NFBMFDPFHCL_idx_ = 0; NFBMFDPFHCL_idx_ < res_readData_.OKEBOFCGHGDLength; NFBMFDPFHCL_idx_++)
		{
			CKGLLPFMEDH NFBMFDPFHCL_readData_ = res_readData_.GetOKEBOFCGHGD(NFBMFDPFHCL_idx_);
			DDHCKMFAKFA NFBMFDPFHCL_data_ = new DDHCKMFAKFA();

			NFBMFDPFHCL_data_.PPFNGGCBJKC_id = NFBMFDPFHCL_readData_.BBPHAPFBFHK/*_id*/;
			NFBMFDPFHCL_data_.IJEKNCDIIAE_mver = NFBMFDPFHCL_readData_.OFMGALJGDAO/*_mver*/;
			NFBMFDPFHCL_data_.PLALNIIBLOF_en = NFBMFDPFHCL_readData_.CFLMCGOJJJD/*_en*/;
			NFBMFDPFHCL_data_.FBFLDFMFFOH_rar = NFBMFDPFHCL_readData_.ODBPKGJPLMD/*_rar*/;
			NFBMFDPFHCL_data_.MLMCEBBDJOE = NFBMFDPFHCL_readData_.JHAMBKOEJPL;
			NFBMFDPFHCL_data_.ODNILEDOAIP = NFBMFDPFHCL_readData_.MJHPFNPCLBD;
			NFBMFDPFHCL_data_.NPPGKNGIFGK_price = NFBMFDPFHCL_readData_.JDKBBEIBJBD/*_price*/;
			List<int> PIPDCAEIBPO_list_ = new List<int>();
			for(int PIPDCAEIBPO_idx_ = 0; PIPDCAEIBPO_idx_ < NFBMFDPFHCL_readData_.CGHIJPPACBCLength; PIPDCAEIBPO_idx_++)
			{
				PIPDCAEIBPO_list_.Add(NFBMFDPFHCL_readData_.GetCGHIJPPACBC(PIPDCAEIBPO_idx_));
			}
			NFBMFDPFHCL_data_.PIPDCAEIBPO = PIPDCAEIBPO_list_.ToArray();

			NFBMFDPFHCL_data_.KEJMJPHFFOJ_Max = NFBMFDPFHCL_readData_.HMNFFFLCANH/*_Max*/;
			NFBMFDPFHCL_data_.CPKMLLNADLJ_Serie = NFBMFDPFHCL_readData_.LMLNKHMPOIG/*_Serie*/;
			NFBMFDPFHCL_list_.Add(NFBMFDPFHCL_data_);
		}
		res_data_.NFBMFDPFHCL = NFBMFDPFHCL_list_.ToArray();

		return res_data_;
	}
}
