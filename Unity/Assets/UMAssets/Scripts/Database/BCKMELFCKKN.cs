
using System.Collections.Generic;

[System.Obsolete("Use BCKMELFCKKN_Tips", true)]
public class BCKMELFCKKN { }
public class BCKMELFCKKN_Tips : DIHHCBACKGG_DbSection
{
	public class ALLFFCNKFBG
	{
		public short PPFNGGCBJKC_Id; // 0x8
		public sbyte PPEGAKEIEGM_Enabled; // 0xA
		public sbyte NCGNCEOOBGP_EventType; // 0xB
		public int[] HFLGGIBMEOL; // 0xC
		public long KJBGCLPMLCG_Start; // 0x10
		public long GJFPFFBAKGK_End; // 0x18
		public string ADCMNODJBGJ_Title; // 0x20
		public string JONNCMDGMKA_Message; // 0x24
		public int EAHPLCJMPHD_ImageId; // 0x28
		public int LKDJHPLBKAI_GraffitiId; // 0x2C
		public int MHPAFEEPBNJ; // 0x30
		public int GGHHHIIENAF_DivaLId; // 0x34
		public int NLPDDGADNFP_DivaRId; // 0x38
		public int ILPJHHKLOEN_Situation; // 0x3C

		//public int BNHOEFJAAKK { get; } 0xC700A4 NNDJHLOPFJB
	}

	public List<ALLFFCNKFBG> CDENCMNHNGA { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB

	//// RVA: 0xC6F9D8 Offset: 0xC6F9D8 VA: 0xC6F9D8
	public ALLFFCNKFBG LBDOLHGDIEB_GetTips(int PPFNGGCBJKC)
	{
		return CDENCMNHNGA.Find((ALLFFCNKFBG GHPLINIACBB) =>
		{
			//0xC7006C
			return PPFNGGCBJKC == GHPLINIACBB.PPFNGGCBJKC_Id;
		});
	}

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
			data.PPFNGGCBJKC_Id = (short)array[i].PPFNGGCBJKC;
			data.NCGNCEOOBGP_EventType = (sbyte)array[i].CBDOEDKIOJK;
			data.KJBGCLPMLCG_Start = array[i].MGPEOHKLOEP;
			data.GJFPFFBAKGK_End = array[i].LFAFFICDFMJ;
			data.ADCMNODJBGJ_Title = array[i].ADCMNODJBGJ;
			data.JONNCMDGMKA_Message = array[i].IPBHCLIHAPG;
			data.PPEGAKEIEGM_Enabled = (sbyte)JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, 0);
			data.EAHPLCJMPHD_ImageId = array[i].HANMDEBPBHG;
			data.LKDJHPLBKAI_GraffitiId = array[i].HBDKKPIOFND;
			data.MHPAFEEPBNJ = array[i].NHBLDIPBHNF;
			data.HFLGGIBMEOL = array[i].KPECMLFDLOI;
			data.GGHHHIIENAF_DivaLId = array[i].GENGOHFLGLG;
			data.NLPDDGADNFP_DivaRId = array[i].OAAMGLOGJNN;
			data.ILPJHHKLOEN_Situation = array[i].PDMJBLLHICB;
			CDENCMNHNGA.Add(data);
		}
		return true;
	}

	//// RVA: 0xC70054 Offset: 0xC70054 VA: 0xC70054
	//private bool KLNOMBKJDNN(EDOHBJAPLPF OILEIIEIBHP, int KAPMOPMDHJE) { }

	// RVA: 0xC70064 Offset: 0xC70064 VA: 0xC70064 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "BCKMELFCKKN_Tips.CAOGDCBPBAN");
		return 0;
	}
}
