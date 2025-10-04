using FlatBuffers;
using System.Collections.Generic;

public class DMABOGLGILJ
{
	public string OPFGFINHFCE_name { get; set; } // 0x8 LGIIAPHCLPN DKJOHDGOIJE_get_name MJAMIGECMMF_set_name
	public int KBFOIECIADN_opened_at { get; set; } // 0xC JFIIKNDPADD NAIEFPFHLJM_get_opened_at BMLJOGEMFBH_set_opened_at
	public int EGBOHDFBAPB_closed_at { get; set; } // 0x10 DDNBDNJHAIB MGOEKKJNOLF_get_closed_at NHPFDCAFAFF_set_closed_at
}
public class IOBIKMEGCAL
{
	public DMABOGLGILJ[] IHMCKPOIBDA { get; set; } // 0x8 CIMDCEDBNKN OEDKNHNADIB_get_ LBJCBJPFKLB_set_
	public static IOBIKMEGCAL HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x9FCBA8
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		NGIOPBLNBDJ res_readData_ = NGIOPBLNBDJ.GetRootAsNGIOPBLNBDJ(buffer);
		IOBIKMEGCAL res_data_ = new IOBIKMEGCAL();

		List<DMABOGLGILJ> IHMCKPOIBDA_list_ = new List<DMABOGLGILJ>();
		for(int IHMCKPOIBDA_idx_ = 0; IHMCKPOIBDA_idx_ < res_readData_.JEILJOANFFELength; IHMCKPOIBDA_idx_++)
		{
			BAODEIILGPO IHMCKPOIBDA_readData_ = res_readData_.GetJEILJOANFFE(IHMCKPOIBDA_idx_);
			DMABOGLGILJ IHMCKPOIBDA_data_ = new DMABOGLGILJ();

			IHMCKPOIBDA_data_.OPFGFINHFCE_name = IHMCKPOIBDA_readData_.IIDCFMHCPLJ/*_name*/;
			IHMCKPOIBDA_data_.KBFOIECIADN_opened_at = IHMCKPOIBDA_readData_.OGJMNHLILJG/*_opened_at*/;
			IHMCKPOIBDA_data_.EGBOHDFBAPB_closed_at = IHMCKPOIBDA_readData_.IPHMJNCEPIJ/*_closed_at*/;
			IHMCKPOIBDA_list_.Add(IHMCKPOIBDA_data_);
		}
		res_data_.IHMCKPOIBDA = IHMCKPOIBDA_list_.ToArray();

		return res_data_;
	}
}
