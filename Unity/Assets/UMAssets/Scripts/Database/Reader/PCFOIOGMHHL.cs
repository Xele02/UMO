using FlatBuffers;
using System.Collections.Generic;

public class CMEPJFBDNPP
{
	public int BFINGCJHOHI { get; set; } // 0x8 PIAHJAJPLKA LFMCLIDAPHB EDAEPDGGFJJ
	public int LKIFDCEKDCK { get; set; } // 0xC IAHMAGLCEBN GOKMANFHFPC ICJKOKGFNLI
}
public class EJLDLIODAID
{
	public uint PPFNGGCBJKC { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO HIGKAIDMOKN
	public uint AGNHPHEJKMK { get; set; } // 0xC BCKMGEBHABF MNJIGLFFJAH MEHEHNALGIH
	public uint DHIPGHBJLIL { get; set; } // 0x10 KPOCJEKICDF PEIEKKODNKE MHBDIGBDPNK
}
public class PCFOIOGMHHL
{
	public uint[] FEOKKEPAIBB { get; set; } // 0x8 GIGNEBBDCBK ICBAELIDDMP NPOGDBMAGGF
	public uint[] FDBOPFEOENF { get; set; } // 0xC DNDMMJJOAOE MJPHCAIKKJG GHECGDMEBFF
	public CMEPJFBDNPP[] MDFFJJKBDFC { get; set; } // 0x10 MLEEAALCDDB CGKHDMIDHGN MDIFADGJNNH
	public uint[] BPLOEAHOPFI { get; set; } // 0x14 KKOIOMJKJJK IFLOIFCLBFJ NGMKCJOPEGH
	public uint[] FJAJPKBEPPG { get; set; } // 0x18 FGOLJFGOHOE GMFOGMLLLED KNLDHCEKOPJ
	public uint[] KJEJPGIHAEK { get; set; } // 0x1C CDKEFACJIMH FPAKLDBFNOG AKDIBNOENKB
	public EJLDLIODAID[] OGGLMPCHEDD { get; set; } // 0x20 CLPPBIOJDBL CCEPJDHBMHB ODJNKOBMJKJ
	public uint[] JPFFIBCDCNJ { get; set; } // 0x24 CMMMMFKLOEI PFHOLHLIENA LMMBLLEOLEI
	public static PCFOIOGMHHL HEGEKFMJNCC(byte[] NIODCJLINJN)// 0xCBF638
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		NLMKDBJHCCM res_readData = NLMKDBJHCCM.GetRootAsNLMKDBJHCCM(buffer);
		PCFOIOGMHHL res_data = new PCFOIOGMHHL();

		List<uint> FEOKKEPAIBB_list = new List<uint>();
		for(int FEOKKEPAIBB_idx = 0; FEOKKEPAIBB_idx < res_readData.EOKPHAFLHBGLength; FEOKKEPAIBB_idx++)
		{
			FEOKKEPAIBB_list.Add(res_readData.GetEOKPHAFLHBG(FEOKKEPAIBB_idx));
		}
		res_data.FEOKKEPAIBB = FEOKKEPAIBB_list.ToArray();

		List<uint> FDBOPFEOENF_list = new List<uint>();
		for(int FDBOPFEOENF_idx = 0; FDBOPFEOENF_idx < res_readData.FOGBEEHMDJMLength; FDBOPFEOENF_idx++)
		{
			FDBOPFEOENF_list.Add(res_readData.GetFOGBEEHMDJM(FDBOPFEOENF_idx));
		}
		res_data.FDBOPFEOENF = FDBOPFEOENF_list.ToArray();

		List<CMEPJFBDNPP> MDFFJJKBDFC_list = new List<CMEPJFBDNPP>();
		for(int MDFFJJKBDFC_idx = 0; MDFFJJKBDFC_idx < res_readData.CGHMONDBJAILength; MDFFJJKBDFC_idx++)
		{
			PLJHMEIABJO MDFFJJKBDFC_readData = res_readData.GetCGHMONDBJAI(MDFFJJKBDFC_idx);
			CMEPJFBDNPP MDFFJJKBDFC_data = new CMEPJFBDNPP();

			MDFFJJKBDFC_data.BFINGCJHOHI = MDFFJJKBDFC_readData.CLEEFGNMCEL;
			MDFFJJKBDFC_data.LKIFDCEKDCK = MDFFJJKBDFC_readData.JKDAMKCJMLD;
			MDFFJJKBDFC_list.Add(MDFFJJKBDFC_data);
		}
		res_data.MDFFJJKBDFC = MDFFJJKBDFC_list.ToArray();

		List<uint> BPLOEAHOPFI_list = new List<uint>();
		for(int BPLOEAHOPFI_idx = 0; BPLOEAHOPFI_idx < res_readData.JPNFHMDOLDILength; BPLOEAHOPFI_idx++)
		{
			BPLOEAHOPFI_list.Add(res_readData.GetJPNFHMDOLDI(BPLOEAHOPFI_idx));
		}
		res_data.BPLOEAHOPFI = BPLOEAHOPFI_list.ToArray();

		List<uint> FJAJPKBEPPG_list = new List<uint>();
		for(int FJAJPKBEPPG_idx = 0; FJAJPKBEPPG_idx < res_readData.DDIHJIBBICGLength; FJAJPKBEPPG_idx++)
		{
			FJAJPKBEPPG_list.Add(res_readData.GetDDIHJIBBICG(FJAJPKBEPPG_idx));
		}
		res_data.FJAJPKBEPPG = FJAJPKBEPPG_list.ToArray();

		List<uint> KJEJPGIHAEK_list = new List<uint>();
		for(int KJEJPGIHAEK_idx = 0; KJEJPGIHAEK_idx < res_readData.JBGHINGOKLJLength; KJEJPGIHAEK_idx++)
		{
			KJEJPGIHAEK_list.Add(res_readData.GetJBGHINGOKLJ(KJEJPGIHAEK_idx));
		}
		res_data.KJEJPGIHAEK = KJEJPGIHAEK_list.ToArray();

		List<EJLDLIODAID> OGGLMPCHEDD_list = new List<EJLDLIODAID>();
		for(int OGGLMPCHEDD_idx = 0; OGGLMPCHEDD_idx < res_readData.IBLGLCALOMGLength; OGGLMPCHEDD_idx++)
		{
			CJBKPOKAIDA OGGLMPCHEDD_readData = res_readData.GetIBLGLCALOMG(OGGLMPCHEDD_idx);
			EJLDLIODAID OGGLMPCHEDD_data = new EJLDLIODAID();

			OGGLMPCHEDD_data.PPFNGGCBJKC = OGGLMPCHEDD_readData.BBPHAPFBFHK;
			OGGLMPCHEDD_data.AGNHPHEJKMK = OGGLMPCHEDD_readData.HLPHBGLMBIO;
			OGGLMPCHEDD_data.DHIPGHBJLIL = OGGLMPCHEDD_readData.KBPBECKBGMH;
			OGGLMPCHEDD_list.Add(OGGLMPCHEDD_data);
		}
		res_data.OGGLMPCHEDD = OGGLMPCHEDD_list.ToArray();

		List<uint> JPFFIBCDCNJ_list = new List<uint>();
		for(int JPFFIBCDCNJ_idx = 0; JPFFIBCDCNJ_idx < res_readData.GNOLKLKMNFPLength; JPFFIBCDCNJ_idx++)
		{
			JPFFIBCDCNJ_list.Add(res_readData.GetGNOLKLKMNFP(JPFFIBCDCNJ_idx));
		}
		res_data.JPFFIBCDCNJ = JPFFIBCDCNJ_list.ToArray();

		return res_data;
	}
}
