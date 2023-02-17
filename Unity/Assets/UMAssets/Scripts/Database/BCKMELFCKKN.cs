
using System.Collections.Generic;

[System.Obsolete("Use BCKMELFCKKN_Tips", true)]
public class BCKMELFCKKN { }
public class BCKMELFCKKN_Tips : DIHHCBACKGG_DbSection
{
	public class ALLFFCNKFBG
	{
		public short PPFNGGCBJKC; // 0x8
		public sbyte PPEGAKEIEGM_Enabled; // 0xA
		public sbyte NCGNCEOOBGP; // 0xB
		public int[] HFLGGIBMEOL; // 0xC
		public long KJBGCLPMLCG; // 0x10
		public long GJFPFFBAKGK; // 0x18
		public string ADCMNODJBGJ; // 0x20
		public string JONNCMDGMKA; // 0x24
		public int EAHPLCJMPHD; // 0x28
		public int LKDJHPLBKAI; // 0x2C
		public int MHPAFEEPBNJ; // 0x30
		public int GGHHHIIENAF; // 0x34
		public int NLPDDGADNFP; // 0x38
		public int ILPJHHKLOEN; // 0x3C

		//public int BNHOEFJAAKK { get; } 0xC700A4 NNDJHLOPFJB
	}

	public List<ALLFFCNKFBG> CDENCMNHNGA { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB

	//// RVA: 0xC6F9D8 Offset: 0xC6F9D8 VA: 0xC6F9D8
	//public BCKMELFCKKN.ALLFFCNKFBG LBDOLHGDIEB(int PPFNGGCBJKC) { }

	// RVA: 0xC6FAD8 Offset: 0xC6FAD8 VA: 0xC6FAD8
	public BCKMELFCKKN_Tips()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		CDENCMNHNGA = new List<ALLFFCNKFBG>();
		LMHMIIKCGPE = 80;
	}

	// RVA: 0xC6FBCC Offset: 0xC6FBCC VA: 0xC6FBCC Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
	}

	// RVA: 0xC6FC44 Offset: 0xC6FC44 VA: 0xC6FC44 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		DGLENODDACE parser = DGLENODDACE.HEGEKFMJNCC(DBBGALAPFGC);
		KLNOMBKJDNN(parser);
		return true;
	}

	// RVA: 0xC7004C Offset: 0xC7004C VA: 0xC7004C Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return true;
	}

	//// RVA: 0xC6FC70 Offset: 0xC6FC70 VA: 0xC6FC70
	private bool KLNOMBKJDNN(DGLENODDACE JMHECKKKMLK)
	{
		JBFGONALAMG[] array = JMHECKKKMLK.KCCHMPEPAII;
		for(int i = 0; i < array.Length; i++)
		{
			ALLFFCNKFBG data = new ALLFFCNKFBG();
			data.PPFNGGCBJKC = (short)array[i].PPFNGGCBJKC;
			data.NCGNCEOOBGP = (sbyte)array[i].CBDOEDKIOJK;
			data.KJBGCLPMLCG = array[i].MGPEOHKLOEP;
			data.GJFPFFBAKGK = array[i].LFAFFICDFMJ;
			data.ADCMNODJBGJ = array[i].ADCMNODJBGJ;
			data.JONNCMDGMKA = array[i].IPBHCLIHAPG;
			data.PPEGAKEIEGM_Enabled = (sbyte)JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, 0);
			data.EAHPLCJMPHD = array[i].HANMDEBPBHG;
			data.LKDJHPLBKAI = array[i].HBDKKPIOFND;
			data.MHPAFEEPBNJ = array[i].NHBLDIPBHNF;
			data.HFLGGIBMEOL = array[i].KPECMLFDLOI;
			data.GGHHHIIENAF = array[i].GENGOHFLGLG;
			data.NLPDDGADNFP = array[i].OAAMGLOGJNN;
			data.ILPJHHKLOEN = array[i].PDMJBLLHICB;
			CDENCMNHNGA.Add(data);
		}
		return true;
	}

	//// RVA: 0xC70054 Offset: 0xC70054 VA: 0xC70054
	//private bool KLNOMBKJDNN(EDOHBJAPLPF OILEIIEIBHP, int KAPMOPMDHJE) { }

	// RVA: 0xC70064 Offset: 0xC70064 VA: 0xC70064 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "BCKMELFCKKN_Tips.CAOGDCBPBAN");
		return 0;
	}
}
