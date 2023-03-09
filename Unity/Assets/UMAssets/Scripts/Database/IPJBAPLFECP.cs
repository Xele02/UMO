
using System.Collections.Generic;

[System.Obsolete("Use IPJBAPLFECP_Anketo", true)]
public class IPJBAPLFECP { }
public class IPJBAPLFECP_Anketo : DIHHCBACKGG_DbSection
{
	public class MDOMAACPHCN
	{
		public int PPFNGGCBJKC_Id; // 0x8
		public int PLALNIIBLOF_Enabled; // 0xC
		public int EILKGEADKGH; // 0x10
		public int INDDJNMPONH; // 0x14
		public int GJLFANGDGCL_Category; // 0x18
		public string ADCMNODJBGJ; // 0x1C
		public string[] BNMCMNPPPCI; // 0x20
		public int EMNLOGDDOBC; // 0x24
		public int IICECOLFEEL; // 0x28
		public int NNDBJGDFEEM; // 0x2C
		public int DOOGFEGEKLG; // 0x30
		public int LLNDMKBBNIJ; // 0x34
	}

	public List<MDOMAACPHCN> CDENCMNHNGA { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB

	//// RVA: 0x1410178 Offset: 0x1410178 VA: 0x1410178
	//public MDOMAACPHCN LBDOLHGDIEB(int PPFNGGCBJKC) { }

	// RVA: 0x1410278 Offset: 0x1410278 VA: 0x1410278
	public IPJBAPLFECP_Anketo()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 2;
		CDENCMNHNGA = new List<MDOMAACPHCN>();
	}

	// RVA: 0x141036C Offset: 0x141036C VA: 0x141036C Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
	}

	// RVA: 0x14103E4 Offset: 0x14103E4 VA: 0x14103E4 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		HHHEIMGFICD parser = HHHEIMGFICD.HEGEKFMJNCC(DBBGALAPFGC);
		KLNOMBKJDNN(parser);
		return true;
	}

	// RVA: 0x1410794 Offset: 0x1410794 VA: 0x1410794 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return true;
	}

	//// RVA: 0x1410410 Offset: 0x1410410 VA: 0x1410410
	private bool KLNOMBKJDNN(HHHEIMGFICD JMHECKKKMLK)
	{
		GGDEOLDOFMH[] array = JMHECKKKMLK.EEMGLFBGGKN;
		for(int i = 0; i < array.Length; i++)
		{
			MDOMAACPHCN data = new MDOMAACPHCN();
			data.PPFNGGCBJKC_Id = array[i].PPFNGGCBJKC;
			data.PLALNIIBLOF_Enabled = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, 0);
			data.EILKGEADKGH = array[i].EILKGEADKGH;
			data.INDDJNMPONH = array[i].GBJFNGCDKPM;
			data.ADCMNODJBGJ = array[i].ADCMNODJBGJ;
			data.BNMCMNPPPCI = array[i].BNMCMNPPPCI;
			data.GJLFANGDGCL_Category = array[i].AGNHPHEJKMK;
			data.EMNLOGDDOBC = array[i].EMNLOGDDOBC;
			data.IICECOLFEEL = array[i].IICECOLFEEL;
			data.NNDBJGDFEEM = array[i].NNDBJGDFEEM;
			data.DOOGFEGEKLG = array[i].DOOGFEGEKLG;
			data.LLNDMKBBNIJ = array[i].LLNDMKBBNIJ;
			CDENCMNHNGA.Add(data);
		}
		return true;
	}

	//// RVA: 0x14107A4 Offset: 0x14107A4 VA: 0x14107A4
	//private bool KLNOMBKJDNN(EDOHBJAPLPF OILEIIEIBHP, int KAPMOPMDHJE) { }

	// RVA: 0x14107AC Offset: 0x14107AC VA: 0x14107AC Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "IPJBAPLFECP_Anketo.CAOGDCBPBAN");
		return 0;
	}
}
