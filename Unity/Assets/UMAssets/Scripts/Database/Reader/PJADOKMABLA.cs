using FlatBuffers;
using System.Collections.Generic;

public class AFICKGBLCKO
{
	public int PPFNGGCBJKC { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO HIGKAIDMOKN
	public int PLALNIIBLOF { get; set; } // 0xC DFMNDOMAPAB JPCJNLHHIPE JJFJNEJLBDG
	public int FNEIADJMHHO { get; set; } // 0x10 PJFAGECNJCF FAPDANAMOKF JIHDPPHAAOJ
	public int KOMKKBDABJP { get; set; } // 0x14 JPPMFGFLNGH MOMCBDJIGKO NECMHGINPDE
	public string LLNDMKBBNIJ { get; set; } // 0x18 BGOALFDCFBL OHMCGADLNCA KJNHDFEGEGE
	public string KOHNLDKIKPC { get; set; } // 0x1C EAMJMDBMNKI KLCNELOBOGM ILNHCICNFHF
	public string BPFBAHCDJFJ { get; set; } // 0x20 BCJILIKDOAD CBFEAHBKODM KJLAKHNLPCG
}
public class CNPDMOGIBEN
{
	public int PPFNGGCBJKC { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO HIGKAIDMOKN
	public int PLALNIIBLOF { get; set; } // 0xC DFMNDOMAPAB JPCJNLHHIPE JJFJNEJLBDG
	public int FNEIADJMHHO { get; set; } // 0x10 PJFAGECNJCF FAPDANAMOKF JIHDPPHAAOJ
	public int KOMKKBDABJP { get; set; } // 0x14 JPPMFGFLNGH MOMCBDJIGKO NECMHGINPDE
	public string KOHNLDKIKPC { get; set; } // 0x18 EAMJMDBMNKI KLCNELOBOGM ILNHCICNFHF
	public string BPFBAHCDJFJ { get; set; } // 0x1C BCJILIKDOAD CBFEAHBKODM KJLAKHNLPCG
}
public class CHOGPKAJDJN
{
	public int PPFNGGCBJKC { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO HIGKAIDMOKN
	public int PLALNIIBLOF { get; set; } // 0xC DFMNDOMAPAB JPCJNLHHIPE JJFJNEJLBDG
	public int FNEIADJMHHO { get; set; } // 0x10 PJFAGECNJCF FAPDANAMOKF JIHDPPHAAOJ
	public int KOMKKBDABJP { get; set; } // 0x14 JPPMFGFLNGH MOMCBDJIGKO NECMHGINPDE
	public string LLNDMKBBNIJ { get; set; } // 0x18 BGOALFDCFBL OHMCGADLNCA KJNHDFEGEGE
	public string CJEKGLGBIHF { get; set; } // 0x1C MLKJHEBAJFA JBNEOHCKDPL OPKIKIDFDKK
	public string KOHNLDKIKPC { get; set; } // 0x20 EAMJMDBMNKI KLCNELOBOGM ILNHCICNFHF
	public string BPFBAHCDJFJ { get; set; } // 0x24 BCJILIKDOAD CBFEAHBKODM KJLAKHNLPCG
}
public class NKJOBGGCCNA
{
	public int NHJBJIGNLHI { get; set; } // 0x8 GPBBDENNDAJ CALOGMNCDCM IPPJIMDIGPK
	public string ADBOHBLBNDL { get; set; } // 0xC NPMGAJJELEL OPAPKEJLHCF GMJEJBHAAAL
	public string IOIMHJAOKOO { get; set; } // 0x10 GMLEDKKPBFJ HJMJGBCJBIN OLGHLLNJPKD
}
public class PJADOKMABLA
{
	public AFICKGBLCKO[] KKFLAKPPPHL { get; set; } // 0x8 MOEKECBIILD DMEGLNCFKKH IDLCACEMKPK
	public CNPDMOGIBEN[] HONMNBAJPGL { get; set; } // 0xC KBAKPGIOKAA LDNJEPPPPGA NELOBFINFJH
	public CHOGPKAJDJN[] JDODPPDNNFK { get; set; } // 0x10 CGDOLHJEOBI NHIBBNMFLHJ LFKMDFGOCAB
	public NKJOBGGCCNA[] MLMGFOGCDMD { get; set; } // 0x14 DCCINJNILEL FDHOOMNIEAE OFEAAAAKFCC
	public static PJADOKMABLA HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x92F49C
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		NBKNKAIJOGL res_readData = NBKNKAIJOGL.GetRootAsNBKNKAIJOGL(buffer);
		PJADOKMABLA res_data = new PJADOKMABLA();

		List<AFICKGBLCKO> KKFLAKPPPHL_list = new List<AFICKGBLCKO>();
		for(int KKFLAKPPPHL_idx = 0; KKFLAKPPPHL_idx < res_readData.DDODJOIHKKGLength; KKFLAKPPPHL_idx++)
		{
			POBCGIFNDJF KKFLAKPPPHL_readData = res_readData.GetDDODJOIHKKG(KKFLAKPPPHL_idx);
			AFICKGBLCKO KKFLAKPPPHL_data = new AFICKGBLCKO();

			KKFLAKPPPHL_data.PPFNGGCBJKC = KKFLAKPPPHL_readData.BBPHAPFBFHK;
			KKFLAKPPPHL_data.PLALNIIBLOF = KKFLAKPPPHL_readData.CFLMCGOJJJD;
			KKFLAKPPPHL_data.FNEIADJMHHO = KKFLAKPPPHL_readData.GLIIHLOLPEF;
			KKFLAKPPPHL_data.KOMKKBDABJP = KKFLAKPPPHL_readData.BNDAHALMIPE;
			KKFLAKPPPHL_data.LLNDMKBBNIJ = KKFLAKPPPHL_readData.CNNEAFFOPAO;
			KKFLAKPPPHL_data.KOHNLDKIKPC = KKFLAKPPPHL_readData.ONBMIJLCFBD;
			KKFLAKPPPHL_data.BPFBAHCDJFJ = KKFLAKPPPHL_readData.NNNCOKLKPIH;
			KKFLAKPPPHL_list.Add(KKFLAKPPPHL_data);
		}
		res_data.KKFLAKPPPHL = KKFLAKPPPHL_list.ToArray();

		List<CNPDMOGIBEN> HONMNBAJPGL_list = new List<CNPDMOGIBEN>();
		for(int HONMNBAJPGL_idx = 0; HONMNBAJPGL_idx < res_readData.DLNKALNBAPBLength; HONMNBAJPGL_idx++)
		{
			FMINENNNIEO HONMNBAJPGL_readData = res_readData.GetDLNKALNBAPB(HONMNBAJPGL_idx);
			CNPDMOGIBEN HONMNBAJPGL_data = new CNPDMOGIBEN();

			HONMNBAJPGL_data.PPFNGGCBJKC = HONMNBAJPGL_readData.BBPHAPFBFHK;
			HONMNBAJPGL_data.PLALNIIBLOF = HONMNBAJPGL_readData.CFLMCGOJJJD;
			HONMNBAJPGL_data.FNEIADJMHHO = HONMNBAJPGL_readData.GLIIHLOLPEF;
			HONMNBAJPGL_data.KOMKKBDABJP = HONMNBAJPGL_readData.BNDAHALMIPE;
			HONMNBAJPGL_data.KOHNLDKIKPC = HONMNBAJPGL_readData.ONBMIJLCFBD;
			HONMNBAJPGL_data.BPFBAHCDJFJ = HONMNBAJPGL_readData.NNNCOKLKPIH;
			HONMNBAJPGL_list.Add(HONMNBAJPGL_data);
		}
		res_data.HONMNBAJPGL = HONMNBAJPGL_list.ToArray();

		List<CHOGPKAJDJN> JDODPPDNNFK_list = new List<CHOGPKAJDJN>();
		for(int JDODPPDNNFK_idx = 0; JDODPPDNNFK_idx < res_readData.NBNMLJNKNACLength; JDODPPDNNFK_idx++)
		{
			FNHCIJOFLAE JDODPPDNNFK_readData = res_readData.GetNBNMLJNKNAC(JDODPPDNNFK_idx);
			CHOGPKAJDJN JDODPPDNNFK_data = new CHOGPKAJDJN();

			JDODPPDNNFK_data.PPFNGGCBJKC = JDODPPDNNFK_readData.BBPHAPFBFHK;
			JDODPPDNNFK_data.PLALNIIBLOF = JDODPPDNNFK_readData.CFLMCGOJJJD;
			JDODPPDNNFK_data.FNEIADJMHHO = JDODPPDNNFK_readData.GLIIHLOLPEF;
			JDODPPDNNFK_data.KOMKKBDABJP = JDODPPDNNFK_readData.BNDAHALMIPE;
			JDODPPDNNFK_data.LLNDMKBBNIJ = JDODPPDNNFK_readData.CNNEAFFOPAO;
			JDODPPDNNFK_data.CJEKGLGBIHF = JDODPPDNNFK_readData.GOIOMMIEMJF;
			JDODPPDNNFK_data.KOHNLDKIKPC = JDODPPDNNFK_readData.ONBMIJLCFBD;
			JDODPPDNNFK_data.BPFBAHCDJFJ = JDODPPDNNFK_readData.NNNCOKLKPIH;
			JDODPPDNNFK_list.Add(JDODPPDNNFK_data);
		}
		res_data.JDODPPDNNFK = JDODPPDNNFK_list.ToArray();

		List<NKJOBGGCCNA> MLMGFOGCDMD_list = new List<NKJOBGGCCNA>();
		for(int MLMGFOGCDMD_idx = 0; MLMGFOGCDMD_idx < res_readData.PAAHAEGCMLFLength; MLMGFOGCDMD_idx++)
		{
			MNOGIDIBJHJ MLMGFOGCDMD_readData = res_readData.GetPAAHAEGCMLF(MLMGFOGCDMD_idx);
			NKJOBGGCCNA MLMGFOGCDMD_data = new NKJOBGGCCNA();

			MLMGFOGCDMD_data.NHJBJIGNLHI = MLMGFOGCDMD_readData.LNPFMOAGCJJ;
			MLMGFOGCDMD_data.ADBOHBLBNDL = MLMGFOGCDMD_readData.FFONHAEBCEG;
			MLMGFOGCDMD_data.IOIMHJAOKOO = MLMGFOGCDMD_readData.PAPMBEBHHIG;
			MLMGFOGCDMD_list.Add(MLMGFOGCDMD_data);
		}
		res_data.MLMGFOGCDMD = MLMGFOGCDMD_list.ToArray();

		return res_data;
	}
}