using FlatBuffers;
using System.Collections.Generic;

public class CFNMIJDKIJH
{
	public int[] BCGKLONODHO { get; set; } // 0x8 EJKADCKMMCN KAINPELLHFF EJPIFOFOINA
	public int[] KPBJHHHMOJE { get; set; } // 0xC DDMBHIBNJIF NNBONJFLKFM FIOMMOICJLL
	public int[] JBGEEPFKIGG { get; set; } // 0x10 AHPLCJAKAOP OLOCMINKGON ABAFHIBFKCE
}
public class OLDDMCHLPEB
{
	public int[] JPMAHJJMMIA { get; set; } // 0x8 IEIHIPLOPPP EEIHPMNJMKG MGAEEIHCOAL
	public int[] HMFFHLPNMPH { get; set; } // 0xC NKBFANLDLIL NJOGDDPICKG NBBGMMBICNA
}
public class MEIHPKLEAKP
{
	public CFNMIJDKIJH[] DJOIJIADLCC { get; set; } // 0x8 JCPMCEPGJKD DAHJLCAKBDK CFOALBJFGGN
	public OLDDMCHLPEB[] NLPDKFCOPNB { get; set; } // 0xC FIPBANFOKPG MMPHCGFMOJD OCMBDBGBGMB
	public static MEIHPKLEAKP HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x1311638
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		NCJELDIPMGO res_readData = NCJELDIPMGO.GetRootAsNCJELDIPMGO(buffer);
		MEIHPKLEAKP res_data = new MEIHPKLEAKP();

		List<CFNMIJDKIJH> DJOIJIADLCC_list = new List<CFNMIJDKIJH>();
		for(int DJOIJIADLCC_idx = 0; DJOIJIADLCC_idx < res_readData.DLBEPCGINEOLength; DJOIJIADLCC_idx++)
		{
			ENFPBAMFLPL DJOIJIADLCC_readData = res_readData.GetDLBEPCGINEO(DJOIJIADLCC_idx);
			CFNMIJDKIJH DJOIJIADLCC_data = new CFNMIJDKIJH();

			List<int> BCGKLONODHO_list = new List<int>();
			for(int BCGKLONODHO_idx = 0; BCGKLONODHO_idx < DJOIJIADLCC_readData.BJOOKJIOGHFLength; BCGKLONODHO_idx++)
			{
				BCGKLONODHO_list.Add(DJOIJIADLCC_readData.GetBJOOKJIOGHF(BCGKLONODHO_idx));
			}
			DJOIJIADLCC_data.BCGKLONODHO = BCGKLONODHO_list.ToArray();

			List<int> KPBJHHHMOJE_list = new List<int>();
			for(int KPBJHHHMOJE_idx = 0; KPBJHHHMOJE_idx < DJOIJIADLCC_readData.AKKGNHMOBPPLength; KPBJHHHMOJE_idx++)
			{
				KPBJHHHMOJE_list.Add(DJOIJIADLCC_readData.GetAKKGNHMOBPP(KPBJHHHMOJE_idx));
			}
			DJOIJIADLCC_data.KPBJHHHMOJE = KPBJHHHMOJE_list.ToArray();

			List<int> JBGEEPFKIGG_list = new List<int>();
			for(int JBGEEPFKIGG_idx = 0; JBGEEPFKIGG_idx < DJOIJIADLCC_readData.CGKGLCKCAMCLength; JBGEEPFKIGG_idx++)
			{
				JBGEEPFKIGG_list.Add(DJOIJIADLCC_readData.GetCGKGLCKCAMC(JBGEEPFKIGG_idx));
			}
			DJOIJIADLCC_data.JBGEEPFKIGG = JBGEEPFKIGG_list.ToArray();

			DJOIJIADLCC_list.Add(DJOIJIADLCC_data);
		}
		res_data.DJOIJIADLCC = DJOIJIADLCC_list.ToArray();

		List<OLDDMCHLPEB> NLPDKFCOPNB_list = new List<OLDDMCHLPEB>();
		for(int NLPDKFCOPNB_idx = 0; NLPDKFCOPNB_idx < res_readData.IOCIMBDOMFILength; NLPDKFCOPNB_idx++)
		{
			HGLIPFFGBBC NLPDKFCOPNB_readData = res_readData.GetIOCIMBDOMFI(NLPDKFCOPNB_idx);
			OLDDMCHLPEB NLPDKFCOPNB_data = new OLDDMCHLPEB();

			List<int> JPMAHJJMMIA_list = new List<int>();
			for(int JPMAHJJMMIA_idx = 0; JPMAHJJMMIA_idx < NLPDKFCOPNB_readData.CKBNFBPHJEALength; JPMAHJJMMIA_idx++)
			{
				JPMAHJJMMIA_list.Add(NLPDKFCOPNB_readData.GetCKBNFBPHJEA(JPMAHJJMMIA_idx));
			}
			NLPDKFCOPNB_data.JPMAHJJMMIA = JPMAHJJMMIA_list.ToArray();

			List<int> HMFFHLPNMPH_list = new List<int>();
			for(int HMFFHLPNMPH_idx = 0; HMFFHLPNMPH_idx < NLPDKFCOPNB_readData.IKNICGHGHNMLength; HMFFHLPNMPH_idx++)
			{
				HMFFHLPNMPH_list.Add(NLPDKFCOPNB_readData.GetIKNICGHGHNM(HMFFHLPNMPH_idx));
			}
			NLPDKFCOPNB_data.HMFFHLPNMPH = HMFFHLPNMPH_list.ToArray();

			NLPDKFCOPNB_list.Add(NLPDKFCOPNB_data);
		}
		res_data.NLPDKFCOPNB = NLPDKFCOPNB_list.ToArray();

		return res_data;
	}
}
