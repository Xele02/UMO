using FlatBuffers;
using System.Collections.Generic;

public class OMNECLCMFOL
{
	public uint PPFNGGCBJKC { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO HIGKAIDMOKN
	public uint FBFLDFMFFOH { get; set; } // 0xC LMKEDCAPLEE HNLMNIOMOLI CHHJKABBIBL
	public uint GBJFNGCDKPM { get; set; } // 0x10 GHLFADHILNN CEJJMKODOGK HOHCEBMMACI
	public int IJEKNCDIIAE { get; set; } // 0x14 FAHNCMHNFCG KJIMMIBDCIL DMEGNOKIKCD
	public int PLALNIIBLOF { get; set; } // 0x18 DFMNDOMAPAB JPCJNLHHIPE JJFJNEJLBDG
}
public class MDOBMPOHGJO
{
	public OMNECLCMFOL[] KKOAFINEAAG { get; set; } // 0x8 KGMBNMDHFCM FMKFOBKGGPB HBCGJPCEMKF
	public static MDOBMPOHGJO HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x1310640
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		GAPIOFFIFKN res_readData = GAPIOFFIFKN.GetRootAsGAPIOFFIFKN(buffer);
		MDOBMPOHGJO res_data = new MDOBMPOHGJO();

		List<OMNECLCMFOL> KKOAFINEAAG_list = new List<OMNECLCMFOL>();
		for(int KKOAFINEAAG_idx = 0; KKOAFINEAAG_idx < res_readData.KHFMFOFIFGGLength; KKOAFINEAAG_idx++)
		{
			EIICDPMENEH KKOAFINEAAG_readData = res_readData.GetKHFMFOFIFGG(KKOAFINEAAG_idx);
			OMNECLCMFOL KKOAFINEAAG_data = new OMNECLCMFOL();

			KKOAFINEAAG_data.PPFNGGCBJKC = KKOAFINEAAG_readData.BBPHAPFBFHK;
			KKOAFINEAAG_data.FBFLDFMFFOH = KKOAFINEAAG_readData.ODBPKGJPLMD;
			KKOAFINEAAG_data.GBJFNGCDKPM = KKOAFINEAAG_readData.LPJPOOHJKAE;
			KKOAFINEAAG_data.IJEKNCDIIAE = KKOAFINEAAG_readData.OFMGALJGDAO;
			KKOAFINEAAG_data.PLALNIIBLOF = KKOAFINEAAG_readData.CFLMCGOJJJD;
			KKOAFINEAAG_list.Add(KKOAFINEAAG_data);
		}
		res_data.KKOAFINEAAG = KKOAFINEAAG_list.ToArray();

		return res_data;
	}
}
