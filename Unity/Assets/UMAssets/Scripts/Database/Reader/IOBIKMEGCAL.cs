using FlatBuffers;
using System.Collections.Generic;

public class DMABOGLGILJ
{
	public string OPFGFINHFCE_name { get; set; } // 0x8 LGIIAPHCLPN DKJOHDGOIJE MJAMIGECMMF
	public int KBFOIECIADN_opened_at { get; set; } // 0xC JFIIKNDPADD NAIEFPFHLJM BMLJOGEMFBH
	public int EGBOHDFBAPB_closed_at { get; set; } // 0x10 DDNBDNJHAIB MGOEKKJNOLF NHPFDCAFAFF
}
public class IOBIKMEGCAL
{
	public DMABOGLGILJ[] IHMCKPOIBDA { get; set; } // 0x8 CIMDCEDBNKN OEDKNHNADIB LBJCBJPFKLB
	public static IOBIKMEGCAL HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x9FCBA8
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		NGIOPBLNBDJ res_readData = NGIOPBLNBDJ.GetRootAsNGIOPBLNBDJ(buffer);
		IOBIKMEGCAL res_data = new IOBIKMEGCAL();

		List<DMABOGLGILJ> IHMCKPOIBDA_list = new List<DMABOGLGILJ>();
		for(int IHMCKPOIBDA_idx = 0; IHMCKPOIBDA_idx < res_readData.JEILJOANFFELength; IHMCKPOIBDA_idx++)
		{
			BAODEIILGPO IHMCKPOIBDA_readData = res_readData.GetJEILJOANFFE(IHMCKPOIBDA_idx);
			DMABOGLGILJ IHMCKPOIBDA_data = new DMABOGLGILJ();

			IHMCKPOIBDA_data.OPFGFINHFCE_name = IHMCKPOIBDA_readData.IIDCFMHCPLJ;
			IHMCKPOIBDA_data.KBFOIECIADN_opened_at = IHMCKPOIBDA_readData.OGJMNHLILJG;
			IHMCKPOIBDA_data.EGBOHDFBAPB_closed_at = IHMCKPOIBDA_readData.IPHMJNCEPIJ;
			IHMCKPOIBDA_list.Add(IHMCKPOIBDA_data);
		}
		res_data.IHMCKPOIBDA = IHMCKPOIBDA_list.ToArray();

		return res_data;
	}
}
