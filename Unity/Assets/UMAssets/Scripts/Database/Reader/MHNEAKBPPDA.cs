using FlatBuffers;
using System.Collections.Generic;

public class GEAAFPCHGFA
{
	public uint PPFNGGCBJKC { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO HIGKAIDMOKN
	public uint PLALNIIBLOF { get; set; } // 0xC DFMNDOMAPAB JPCJNLHHIPE JJFJNEJLBDG
	public uint[] JGOHPDKCJKB { get; set; } // 0x10 HOBIJNCHJHA MJFPLENCCCP OKELMCNLMDD
	public uint BDJMFDKLHPM { get; set; } // 0x14 EOBCNECIOMH GFMBGPMJPLJ ENAMMCHJBDE
	public uint FPOMEEJFBIG { get; set; } // 0x18 PJKJIFMIFDJ OEEBAHNAPEC BEHAPLPPLNE
	public int IJEKNCDIIAE { get; set; } // 0x1C FAHNCMHNFCG KJIMMIBDCIL DMEGNOKIKCD
}
public class INBANFOPJLF
{
	public uint BDJMFDKLHPM { get; set; } // 0x8 EOBCNECIOMH GFMBGPMJPLJ ENAMMCHJBDE
	public int[] FOILNHKHHDF { get; set; } // 0xC LNNCNOIGMGM FOFBHPJDHFO LHPMDDKPJDP
}
public class INMFBOOGCLB
{
	public uint FCEJJEPFIPH { get; set; } // 0x8 ACOJMMLFGOK LLLKCLJBPBL IBLEKPDKFDO
	public uint AIHOJKFNEEN { get; set; } // 0xC GGBFCEFNCFM BGFIPHMMOGA DHAIHODDOGM
	public uint BFINGCJHOHI { get; set; } // 0x10 PIAHJAJPLKA LFMCLIDAPHB EDAEPDGGFJJ
	public uint GPDEFAHJCBM { get; set; } // 0x14 LKKOPLGAIBL LNJCGKMOJHF DOBKHNNOPBH
}
public class MHNEAKBPPDA
{
	public GEAAFPCHGFA[] LCLJDEHGMCO { get; set; } // 0x8 NAMGNHGIGOP BEANGFGKAMC IPMAIDABPLG
	public INBANFOPJLF[] ECPDOFEOIPA { get; set; } // 0xC MDKBAEGFGCO JEBBAEOJEKE BICAMOJBDMP
	public INMFBOOGCLB[] APHNKNGKKFC { get; set; } // 0x10 NKNDJILLFLC IGMIBBHAANI LBGEJOLEKPL
	public static MHNEAKBPPDA HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x195363C
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		KFHCGBOADLE res_readData = KFHCGBOADLE.GetRootAsKFHCGBOADLE(buffer);
		MHNEAKBPPDA res_data = new MHNEAKBPPDA();

		List<GEAAFPCHGFA> LCLJDEHGMCO_list = new List<GEAAFPCHGFA>();
		for(int LCLJDEHGMCO_idx = 0; LCLJDEHGMCO_idx < res_readData.BHHFEPOGOIGLength; LCLJDEHGMCO_idx++)
		{
			ODDOBDBBJAB LCLJDEHGMCO_readData = res_readData.GetBHHFEPOGOIG(LCLJDEHGMCO_idx);
			GEAAFPCHGFA LCLJDEHGMCO_data = new GEAAFPCHGFA();

			LCLJDEHGMCO_data.PPFNGGCBJKC = LCLJDEHGMCO_readData.BBPHAPFBFHK;
			LCLJDEHGMCO_data.PLALNIIBLOF = LCLJDEHGMCO_readData.CFLMCGOJJJD;
			List<uint> JGOHPDKCJKB_list = new List<uint>();
			for(int JGOHPDKCJKB_idx = 0; JGOHPDKCJKB_idx < LCLJDEHGMCO_readData.FAOBJKICMBBLength; JGOHPDKCJKB_idx++)
			{
				JGOHPDKCJKB_list.Add(LCLJDEHGMCO_readData.GetFAOBJKICMBB(JGOHPDKCJKB_idx));
			}
			LCLJDEHGMCO_data.JGOHPDKCJKB = JGOHPDKCJKB_list.ToArray();

			LCLJDEHGMCO_data.BDJMFDKLHPM = LCLJDEHGMCO_readData.MJOCIHPPKNO;
			LCLJDEHGMCO_data.FPOMEEJFBIG = LCLJDEHGMCO_readData.AEAKMMJLLDK;
			LCLJDEHGMCO_data.IJEKNCDIIAE = LCLJDEHGMCO_readData.OFMGALJGDAO;
			LCLJDEHGMCO_list.Add(LCLJDEHGMCO_data);
		}
		res_data.LCLJDEHGMCO = LCLJDEHGMCO_list.ToArray();

		List<INBANFOPJLF> ECPDOFEOIPA_list = new List<INBANFOPJLF>();
		for(int ECPDOFEOIPA_idx = 0; ECPDOFEOIPA_idx < res_readData.CMAPNGGMDOILength; ECPDOFEOIPA_idx++)
		{
			DNHKFIKECGD ECPDOFEOIPA_readData = res_readData.GetCMAPNGGMDOI(ECPDOFEOIPA_idx);
			INBANFOPJLF ECPDOFEOIPA_data = new INBANFOPJLF();

			ECPDOFEOIPA_data.BDJMFDKLHPM = ECPDOFEOIPA_readData.MJOCIHPPKNO;
			List<int> FOILNHKHHDF_list = new List<int>();
			for(int FOILNHKHHDF_idx = 0; FOILNHKHHDF_idx < ECPDOFEOIPA_readData.HFOJCEBNHCILength; FOILNHKHHDF_idx++)
			{
				FOILNHKHHDF_list.Add(ECPDOFEOIPA_readData.GetHFOJCEBNHCI(FOILNHKHHDF_idx));
			}
			ECPDOFEOIPA_data.FOILNHKHHDF = FOILNHKHHDF_list.ToArray();

			ECPDOFEOIPA_list.Add(ECPDOFEOIPA_data);
		}
		res_data.ECPDOFEOIPA = ECPDOFEOIPA_list.ToArray();

		List<INMFBOOGCLB> APHNKNGKKFC_list = new List<INMFBOOGCLB>();
		for(int APHNKNGKKFC_idx = 0; APHNKNGKKFC_idx < res_readData.ILBKJACHOHMLength; APHNKNGKKFC_idx++)
		{
			PCDBMJGPDFN APHNKNGKKFC_readData = res_readData.GetILBKJACHOHM(APHNKNGKKFC_idx);
			INMFBOOGCLB APHNKNGKKFC_data = new INMFBOOGCLB();

			APHNKNGKKFC_data.FCEJJEPFIPH = APHNKNGKKFC_readData.LNHODOPAJIL;
			APHNKNGKKFC_data.AIHOJKFNEEN = APHNKNGKKFC_readData.LHMHAFHMNFF;
			APHNKNGKKFC_data.BFINGCJHOHI = APHNKNGKKFC_readData.CLEEFGNMCEL;
			APHNKNGKKFC_data.GPDEFAHJCBM = APHNKNGKKFC_readData.CIJLLHJEANC;
			APHNKNGKKFC_list.Add(APHNKNGKKFC_data);
		}
		res_data.APHNKNGKKFC = APHNKNGKKFC_list.ToArray();

		return res_data;
	}
}
