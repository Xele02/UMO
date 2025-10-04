using FlatBuffers;
using System.Collections.Generic;

public class ELHKLDPNKBD
{
	public uint LJELGFAFGAB_so { get; set; } // 0x8 CJCOPPAFPKE APHFJDOOLCK_get_so KBEAJHMCGPM_set_so
	public uint KNEDJFLCCLN_vo { get; set; } // 0xC HJMKHFAHBIO DKJNGOIGJGH_get_vo EOMMBJGKKJI_set_vo
	public uint MBAMIOJNGBD_ch { get; set; } // 0x10 PJHOHPBOIDJ NJBKAFBFJML_get_ch IGAFGHBHMIF_set_ch
}
public class PBLHKFHDMGG
{
	public ELHKLDPNKBD[] HNKCJKLONLN { get; set; } // 0x8 GAAOJNJMPIL BEBGGKPGACL_get_ CLCKDJKNCMP_set_
	public uint[] KNOMABFHFEB { get; set; } // 0xC HENBLFJOCGH IDOEMGMGHOO_get_ BEPMNJLFLIO_set_
	public static PBLHKFHDMGG HEGEKFMJNCC(byte[] NIODCJLINJN)// 0xCBD46C
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		PKLIOFHMFFC res_readData_ = PKLIOFHMFFC.GetRootAsPKLIOFHMFFC(buffer);
		PBLHKFHDMGG res_data_ = new PBLHKFHDMGG();

		List<ELHKLDPNKBD> HNKCJKLONLN_list_ = new List<ELHKLDPNKBD>();
		for(int HNKCJKLONLN_idx_ = 0; HNKCJKLONLN_idx_ < res_readData_.NEKBFHJGJLLLength; HNKCJKLONLN_idx_++)
		{
			EFBMIPDEIIB HNKCJKLONLN_readData_ = res_readData_.GetNEKBFHJGJLL(HNKCJKLONLN_idx_);
			ELHKLDPNKBD HNKCJKLONLN_data_ = new ELHKLDPNKBD();

			HNKCJKLONLN_data_.LJELGFAFGAB_so = HNKCJKLONLN_readData_.FHLKEIBOFNN/*_so*/;
			HNKCJKLONLN_data_.KNEDJFLCCLN_vo = HNKCJKLONLN_readData_.EGEFMJCLNDM/*_vo*/;
			HNKCJKLONLN_data_.MBAMIOJNGBD_ch = HNKCJKLONLN_readData_.KDPKPOBKKMJ/*_ch*/;
			HNKCJKLONLN_list_.Add(HNKCJKLONLN_data_);
		}
		res_data_.HNKCJKLONLN = HNKCJKLONLN_list_.ToArray();

		List<uint> KNOMABFHFEB_list_ = new List<uint>();
		for(int KNOMABFHFEB_idx_ = 0; KNOMABFHFEB_idx_ < res_readData_.EOPAINGDDGDLength; KNOMABFHFEB_idx_++)
		{
			KNOMABFHFEB_list_.Add(res_readData_.GetEOPAINGDDGD(KNOMABFHFEB_idx_));
		}
		res_data_.KNOMABFHFEB = KNOMABFHFEB_list_.ToArray();

		return res_data_;
	}
}
