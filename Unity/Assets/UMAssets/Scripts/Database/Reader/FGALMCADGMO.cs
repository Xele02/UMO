using FlatBuffers;
using System.Collections.Generic;

public class MEEJPBEAKKP
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int IJEKNCDIIAE_mver { get; set; } // 0xC FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public int PLALNIIBLOF_en { get; set; } // 0x10 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public int PDBPFJJCADD_open_at { get; set; } // 0x14 PMJMBGBCIGO FOACOMBHPAC_get_open_at NBACOBCOJCA_set_open_at
	public int EGBOHDFBAPB_closed_at { get; set; } // 0x18 DDNBDNJHAIB MGOEKKJNOLF_get_closed_at NHPFDCAFAFF_set_closed_at
	public int KMENGHEAIOC { get; set; } // 0x1C MLHHJIIPDPC CFEGFAIJACF_get_ CPFBBHLFALE_set_
	public int JDANEOJCLBB { get; set; } // 0x20 CIIPLOPOPBO ONCHMOLCBDG_get_ MNKBPDNCPMM_set_
	public int CPGFOBNKKBF_CurrencyId { get; set; } // 0x24 CIAEKFDKLJB AMNKHCIJHJD_get_CurrencyId INJMDACNFOL_set_CurrencyId
	public int GBJFNGCDKPM_typ { get; set; } // 0x28 GHLFADHILNN CEJJMKODOGK_get_typ HOHCEBMMACI_set_typ
	public int JBGEEPFKIGG_val { get; set; } // 0x2C AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
}
public class FGALMCADGMO
{
	public MEEJPBEAKKP[] BHOHDFAFCNL { get; set; } // 0x8 EFDGJLHLLHB BKOCPNEOBKB_get_ HHGNFHJJMKL_set_
	public static FGALMCADGMO HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x14E6D70
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		FKNGHMMLIJF res_readData_ = FKNGHMMLIJF.GetRootAsFKNGHMMLIJF(buffer);
		FGALMCADGMO res_data_ = new FGALMCADGMO();

		List<MEEJPBEAKKP> BHOHDFAFCNL_list_ = new List<MEEJPBEAKKP>();
		for(int BHOHDFAFCNL_idx_ = 0; BHOHDFAFCNL_idx_ < res_readData_.EOEALHJBOGCLength; BHOHDFAFCNL_idx_++)
		{
			HJHAEAPNEMD BHOHDFAFCNL_readData_ = res_readData_.GetEOEALHJBOGC(BHOHDFAFCNL_idx_);
			MEEJPBEAKKP BHOHDFAFCNL_data_ = new MEEJPBEAKKP();

			BHOHDFAFCNL_data_.PPFNGGCBJKC_id = BHOHDFAFCNL_readData_.BBPHAPFBFHK/*_id*/;
			BHOHDFAFCNL_data_.IJEKNCDIIAE_mver = BHOHDFAFCNL_readData_.OFMGALJGDAO/*_mver*/;
			BHOHDFAFCNL_data_.PLALNIIBLOF_en = BHOHDFAFCNL_readData_.CFLMCGOJJJD/*_en*/;
			BHOHDFAFCNL_data_.PDBPFJJCADD_open_at = BHOHDFAFCNL_readData_.NJLJEKDBPCH/*_open_at*/;
			BHOHDFAFCNL_data_.EGBOHDFBAPB_closed_at = BHOHDFAFCNL_readData_.IPHMJNCEPIJ/*_closed_at*/;
			BHOHDFAFCNL_data_.KMENGHEAIOC = BHOHDFAFCNL_readData_.JFJCBFNEOAB;
			BHOHDFAFCNL_data_.JDANEOJCLBB = BHOHDFAFCNL_readData_.GPLJLPKJPAM;
			BHOHDFAFCNL_data_.CPGFOBNKKBF_CurrencyId = BHOHDFAFCNL_readData_.DKMLEDJJFOI/*_CurrencyId*/;
			BHOHDFAFCNL_data_.GBJFNGCDKPM_typ = BHOHDFAFCNL_readData_.LPJPOOHJKAE/*_typ*/;
			BHOHDFAFCNL_data_.JBGEEPFKIGG_val = BHOHDFAFCNL_readData_.KJFEBMBHKOC/*_val*/;
			BHOHDFAFCNL_list_.Add(BHOHDFAFCNL_data_);
		}
		res_data_.BHOHDFAFCNL = BHOHDFAFCNL_list_.ToArray();

		return res_data_;
	}
}
