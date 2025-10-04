using FlatBuffers;
using System.Collections.Generic;

public class OCANCOENHML
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint PLALNIIBLOF_en { get; set; } // 0xC DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public uint GBJFNGCDKPM_typ { get; set; } // 0x10 GHLFADHILNN CEJJMKODOGK_get_typ HOHCEBMMACI_set_typ
	public uint JBFLEDKDFCO_cid { get; set; } // 0x14 JOECCKJHICK LIJMKJLDHGP_get_cid NFNCLFPPADP_set_cid
	public uint CHOIMHCMAHG { get; set; } // 0x18 ALCEBFJAGJB APOIMEHLPBD_get_ HJFDHIEGGBH_set_
	public uint PDBPFJJCADD_open_at { get; set; } // 0x1C PMJMBGBCIGO FOACOMBHPAC_get_open_at NBACOBCOJCA_set_open_at
	public uint FDBNFFNFOND_close_at { get; set; } // 0x20 INOJHLHGKMI BPJOGHJCLDJ_get_close_at NLJKMCHOCBK_set_close_at
	public int IJEKNCDIIAE_mver { get; set; } // 0x24 FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
}
public class PCKMEHLNOFO
{
	public OCANCOENHML[] EKDAACJJAPP { get; set; } // 0x8 NCLFBMBAOIK JGEKGHCEAIC_get_ IMEOEGMGECM_set_
	public static PCKMEHLNOFO HEGEKFMJNCC(byte[] NIODCJLINJN)// 0xCC19EC
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		BNMAJCFEFOK res_readData_ = BNMAJCFEFOK.GetRootAsBNMAJCFEFOK(buffer);
		PCKMEHLNOFO res_data_ = new PCKMEHLNOFO();

		List<OCANCOENHML> EKDAACJJAPP_list_ = new List<OCANCOENHML>();
		for(int EKDAACJJAPP_idx_ = 0; EKDAACJJAPP_idx_ < res_readData_.LHHOBGIGIEILength; EKDAACJJAPP_idx_++)
		{
			PEDMFAEMCPG EKDAACJJAPP_readData_ = res_readData_.GetLHHOBGIGIEI(EKDAACJJAPP_idx_);
			OCANCOENHML EKDAACJJAPP_data_ = new OCANCOENHML();

			EKDAACJJAPP_data_.PPFNGGCBJKC_id = EKDAACJJAPP_readData_.BBPHAPFBFHK/*_id*/;
			EKDAACJJAPP_data_.PLALNIIBLOF_en = EKDAACJJAPP_readData_.CFLMCGOJJJD/*_en*/;
			EKDAACJJAPP_data_.GBJFNGCDKPM_typ = EKDAACJJAPP_readData_.LPJPOOHJKAE/*_typ*/;
			EKDAACJJAPP_data_.JBFLEDKDFCO_cid = EKDAACJJAPP_readData_.HOENDPOGFIO/*_cid*/;
			EKDAACJJAPP_data_.CHOIMHCMAHG = EKDAACJJAPP_readData_.DNIDLBOLLGH;
			EKDAACJJAPP_data_.PDBPFJJCADD_open_at = EKDAACJJAPP_readData_.NJLJEKDBPCH/*_open_at*/;
			EKDAACJJAPP_data_.FDBNFFNFOND_close_at = EKDAACJJAPP_readData_.MAOAGDBDBIB/*_close_at*/;
			EKDAACJJAPP_data_.IJEKNCDIIAE_mver = EKDAACJJAPP_readData_.OFMGALJGDAO/*_mver*/;
			EKDAACJJAPP_list_.Add(EKDAACJJAPP_data_);
		}
		res_data_.EKDAACJJAPP = EKDAACJJAPP_list_.ToArray();

		return res_data_;
	}
}
