using FlatBuffers;
using System.Collections.Generic;

public class JOEEBALPECG
{
	public int PPFNGGCBJKC { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO HIGKAIDMOKN
	public int[] ECEOBKOFJHK { get; set; } // 0xC NBKODANCCCK LAEIFNHLJEF BPGGKDDGPIG
	public int NDFOAINJPIN { get; set; } // 0x10 MJDPJMGBMAA CLKKCPLEKBC CLJOOFCICMO
	public int[] OGDLCNPFODO { get; set; } // 0x14 CHFPHOCONMF IKPNMPPCGDA GBOBCAKPDIA
	public string[] IPBHCLIHAPG { get; set; } // 0x18 PGDNLLBNAFF CBMCOGPJADM BAIGLALPKDE
}
public class EMEEODMLEHD
{
	public JOEEBALPECG[] DKBBEHIHBEK { get; set; } // 0x8 HKKFGHJJIHM OAODEMONFPC HKHMCAEJBHE
	public static EMEEODMLEHD HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x130947C
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		JAAOECLAKNC res_readData = JAAOECLAKNC.GetRootAsJAAOECLAKNC(buffer);
		EMEEODMLEHD res_data = new EMEEODMLEHD();

		List<JOEEBALPECG> DKBBEHIHBEK_list = new List<JOEEBALPECG>();
		for(int DKBBEHIHBEK_idx = 0; DKBBEHIHBEK_idx < res_readData.IDNFMKCJFDGLength; DKBBEHIHBEK_idx++)
		{
			FFPCNIAALNN DKBBEHIHBEK_readData = res_readData.GetIDNFMKCJFDG(DKBBEHIHBEK_idx);
			JOEEBALPECG DKBBEHIHBEK_data = new JOEEBALPECG();

			DKBBEHIHBEK_data.PPFNGGCBJKC = DKBBEHIHBEK_readData.BBPHAPFBFHK;
			List<int> ECEOBKOFJHK_list = new List<int>();
			for(int ECEOBKOFJHK_idx = 0; ECEOBKOFJHK_idx < DKBBEHIHBEK_readData.CLGAMGOJHHHLength; ECEOBKOFJHK_idx++)
			{
				ECEOBKOFJHK_list.Add(DKBBEHIHBEK_readData.GetCLGAMGOJHHH(ECEOBKOFJHK_idx));
			}
			DKBBEHIHBEK_data.ECEOBKOFJHK = ECEOBKOFJHK_list.ToArray();

			DKBBEHIHBEK_data.NDFOAINJPIN = DKBBEHIHBEK_readData.LGEDAJAFHGG;
			List<int> OGDLCNPFODO_list = new List<int>();
			for(int OGDLCNPFODO_idx = 0; OGDLCNPFODO_idx < DKBBEHIHBEK_readData.BJHDJMNLEPPLength; OGDLCNPFODO_idx++)
			{
				OGDLCNPFODO_list.Add(DKBBEHIHBEK_readData.GetBJHDJMNLEPP(OGDLCNPFODO_idx));
			}
			DKBBEHIHBEK_data.OGDLCNPFODO = OGDLCNPFODO_list.ToArray();

			List<string> IPBHCLIHAPG_list = new List<string>();
			for(int IPBHCLIHAPG_idx = 0; IPBHCLIHAPG_idx < DKBBEHIHBEK_readData.IKDLGFEPPDBLength; IPBHCLIHAPG_idx++)
			{
				IPBHCLIHAPG_list.Add(DKBBEHIHBEK_readData.GetIKDLGFEPPDB(IPBHCLIHAPG_idx));
			}
			DKBBEHIHBEK_data.IPBHCLIHAPG = IPBHCLIHAPG_list.ToArray();

			DKBBEHIHBEK_list.Add(DKBBEHIHBEK_data);
		}
		res_data.DKBBEHIHBEK = DKBBEHIHBEK_list.ToArray();

		return res_data;
	}
}
