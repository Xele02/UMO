using FlatBuffers;
using System.Collections.Generic;

public class BJALOLHCBKC
{
	public string MIMGPBHAJCO { get; set; } // 0x8 ICEMDJBNGJA JPMHJMDLFPI NLHKGLABKDI
	public uint BAOFEFFADPD { get; set; } // 0xC MNBJKHKHMCL KHNONKOPIPO LBJPPBMDOGE
	public uint BEPIOAIFCEC { get; set; } // 0x10 OHIHJLAHFOF GDBDINJGOKM JJHKMPPEBFG
}
public class PFCNGLGHLJA
{
	public string MIMGPBHAJCO { get; set; } // 0x8 ICEMDJBNGJA JPMHJMDLFPI NLHKGLABKDI
	public int IJEKNCDIIAE { get; set; } // 0xC FAHNCMHNFCG KJIMMIBDCIL DMEGNOKIKCD
}
public class CPHIOGHFPKN
{
	public BJALOLHCBKC[] IPHMDEOOFAI { get; set; } // 0x8 IEGLKEKHKIL JDENPLBHGJH JNIDAOHELKO
	public int[] KLDHBJPDAFG { get; set; } // 0xC EKGDCBBGCHE HEEKBKPFJJJ PGDLNJLINBA
	public string[] AMBODKHPHFH { get; set; } // 0x10 DIAHNBHBGJE GCCHEBPCBFN FFOBDPGIMMN
	public string[] DNGKHGLIGKJ { get; set; } // 0x14 KOBOPEGFEGI DAMKLHGOOPG IJECLOFOFFO
	public PFCNGLGHLJA[] DOGNLEPGCIK { get; set; } // 0x18 KKJGAONDLBD OIPPNEOLBOG KGLBGMBDOJC
	public static CPHIOGHFPKN HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x176634C
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		OHOIIACCJAH res_readData = OHOIIACCJAH.GetRootAsOHOIIACCJAH(buffer);
		CPHIOGHFPKN res_data = new CPHIOGHFPKN();

		List<BJALOLHCBKC> IPHMDEOOFAI_list = new List<BJALOLHCBKC>();
		for(int IPHMDEOOFAI_idx = 0; IPHMDEOOFAI_idx < res_readData.CMNLDHJPMPHLength; IPHMDEOOFAI_idx++)
		{
			DIFBGFBHPNC IPHMDEOOFAI_readData = res_readData.GetCMNLDHJPMPH(IPHMDEOOFAI_idx);
			BJALOLHCBKC IPHMDEOOFAI_data = new BJALOLHCBKC();

			IPHMDEOOFAI_data.MIMGPBHAJCO = IPHMDEOOFAI_readData.DCEDMFDNAKH;
			IPHMDEOOFAI_data.BAOFEFFADPD = IPHMDEOOFAI_readData.FKGLOPMFMCP;
			IPHMDEOOFAI_data.BEPIOAIFCEC = IPHMDEOOFAI_readData.IAPOHBCMPPB;
			IPHMDEOOFAI_list.Add(IPHMDEOOFAI_data);
		}
		res_data.IPHMDEOOFAI = IPHMDEOOFAI_list.ToArray();

		List<int> KLDHBJPDAFG_list = new List<int>();
		for(int KLDHBJPDAFG_idx = 0; KLDHBJPDAFG_idx < res_readData.NJAJCNKJFMNLength; KLDHBJPDAFG_idx++)
		{
			KLDHBJPDAFG_list.Add(res_readData.GetNJAJCNKJFMN(KLDHBJPDAFG_idx));
		}
		res_data.KLDHBJPDAFG = KLDHBJPDAFG_list.ToArray();

		List<string> AMBODKHPHFH_list = new List<string>();
		for(int AMBODKHPHFH_idx = 0; AMBODKHPHFH_idx < res_readData.CDHLDAKBHCILength; AMBODKHPHFH_idx++)
		{
			AMBODKHPHFH_list.Add(res_readData.GetCDHLDAKBHCI(AMBODKHPHFH_idx));
		}
		res_data.AMBODKHPHFH = AMBODKHPHFH_list.ToArray();

		List<string> DNGKHGLIGKJ_list = new List<string>();
		for(int DNGKHGLIGKJ_idx = 0; DNGKHGLIGKJ_idx < res_readData.JCKOPOCPOECLength; DNGKHGLIGKJ_idx++)
		{
			DNGKHGLIGKJ_list.Add(res_readData.GetJCKOPOCPOEC(DNGKHGLIGKJ_idx));
		}
		res_data.DNGKHGLIGKJ = DNGKHGLIGKJ_list.ToArray();

		List<PFCNGLGHLJA> DOGNLEPGCIK_list = new List<PFCNGLGHLJA>();
		for(int DOGNLEPGCIK_idx = 0; DOGNLEPGCIK_idx < res_readData.GBHCJIPEFDFLength; DOGNLEPGCIK_idx++)
		{
			AHCMKLEDILD DOGNLEPGCIK_readData = res_readData.GetGBHCJIPEFDF(DOGNLEPGCIK_idx);
			PFCNGLGHLJA DOGNLEPGCIK_data = new PFCNGLGHLJA();

			DOGNLEPGCIK_data.MIMGPBHAJCO = DOGNLEPGCIK_readData.DCEDMFDNAKH;
			DOGNLEPGCIK_data.IJEKNCDIIAE = DOGNLEPGCIK_readData.OFMGALJGDAO;
			DOGNLEPGCIK_list.Add(DOGNLEPGCIK_data);
		}
		res_data.DOGNLEPGCIK = DOGNLEPGCIK_list.ToArray();

		return res_data;
	}
}
