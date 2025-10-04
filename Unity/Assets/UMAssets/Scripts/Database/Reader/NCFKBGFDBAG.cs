using FlatBuffers;
using System.Collections.Generic;

public class FABKJOODBNN
{
	public int KAPMOPMDHJE_label { get; set; } // 0x8 EJDCHACDMPH MONBNPKLFGC_get_label KGFFKEDNIID_set_label
	public string[] PIBLLGLCJEO_Param { get; set; } // 0xC KGLJBJIIAEG CMKMAGNMPGC_get_Param CICCOMMMNHK_set_Param
}
public class GPCOJNLJJLE
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public FABKJOODBNN[] PBOHDAFOEIA { get; set; } // 0xC JGOGMDKIANB DOHAEHILHEJ_get_ PDACBNCMOJO_set_
	public int PMJAGEJIOJE { get; set; } // 0x10 LLPEBCNLMAN BOEDFMEFNJH_get_ BBJCCCBILNL_set_
	public string IPBHCLIHAPG_Msg { get; set; } // 0x14 PGDNLLBNAFF CBMCOGPJADM_get_Msg BAIGLALPKDE_set_Msg
}
public class NCFKBGFDBAG
{
	public GPCOJNLJJLE[] HEHPAMADHGC { get; set; } // 0x8 ELDDPACCPDB BGLEMGEDKIM_get_ HPKKCCEEGEK_set_
	public static NCFKBGFDBAG HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x17CC234
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		JDKBJLPDAMB res_readData_ = JDKBJLPDAMB.GetRootAsJDKBJLPDAMB(buffer);
		NCFKBGFDBAG res_data_ = new NCFKBGFDBAG();

		List<GPCOJNLJJLE> HEHPAMADHGC_list_ = new List<GPCOJNLJJLE>();
		for(int HEHPAMADHGC_idx_ = 0; HEHPAMADHGC_idx_ < res_readData_.PIIOHCJFHBDLength; HEHPAMADHGC_idx_++)
		{
			LDOCPAKMACI HEHPAMADHGC_readData_ = res_readData_.GetPIIOHCJFHBD(HEHPAMADHGC_idx_);
			GPCOJNLJJLE HEHPAMADHGC_data_ = new GPCOJNLJJLE();

			HEHPAMADHGC_data_.PPFNGGCBJKC_id = HEHPAMADHGC_readData_.BBPHAPFBFHK/*_id*/;
			List<FABKJOODBNN> PBOHDAFOEIA_list_ = new List<FABKJOODBNN>();
			for(int PBOHDAFOEIA_idx_ = 0; PBOHDAFOEIA_idx_ < HEHPAMADHGC_readData_.IIBAJDOLFBMLength; PBOHDAFOEIA_idx_++)
			{
				LJONABMKIOM PBOHDAFOEIA_readData_ = HEHPAMADHGC_readData_.GetIIBAJDOLFBM(PBOHDAFOEIA_idx_);
				FABKJOODBNN PBOHDAFOEIA_data_ = new FABKJOODBNN();

				PBOHDAFOEIA_data_.KAPMOPMDHJE_label = PBOHDAFOEIA_readData_.BNFLNMGOJCM/*_label*/;
				List<string> PIBLLGLCJEO_list_ = new List<string>();
				for(int PIBLLGLCJEO_idx_ = 0; PIBLLGLCJEO_idx_ < PBOHDAFOEIA_readData_.BPODDGNIDBGLength; PIBLLGLCJEO_idx_++)
				{
					PIBLLGLCJEO_list_.Add(PBOHDAFOEIA_readData_.GetBPODDGNIDBG(PIBLLGLCJEO_idx_));
				}
				PBOHDAFOEIA_data_.PIBLLGLCJEO_Param = PIBLLGLCJEO_list_.ToArray();

				PBOHDAFOEIA_list_.Add(PBOHDAFOEIA_data_);
			}
			HEHPAMADHGC_data_.PBOHDAFOEIA = PBOHDAFOEIA_list_.ToArray();

			HEHPAMADHGC_data_.PMJAGEJIOJE = HEHPAMADHGC_readData_.GELNDPJNLJM;
			HEHPAMADHGC_data_.IPBHCLIHAPG_Msg = HEHPAMADHGC_readData_.IAHNDJDBCAJ/*_Msg*/;
			HEHPAMADHGC_list_.Add(HEHPAMADHGC_data_);
		}
		res_data_.HEHPAMADHGC = HEHPAMADHGC_list_.ToArray();

		return res_data_;
	}
}
