
using System.Collections.Generic;

[System.Obsolete("Use BCKMELFCKKN_Tips", true)]
public class BCKMELFCKKN { }
public class BCKMELFCKKN_Tips : DIHHCBACKGG_DbSection
{
	public class ALLFFCNKFBG
	{
		public short PPFNGGCBJKC_id; // 0x8
		public sbyte PPEGAKEIEGM_Enabled; // 0xA
		public sbyte NCGNCEOOBGP_EventType; // 0xB
		public int[] HFLGGIBMEOL; // 0xC
		public long KJBGCLPMLCG_OpenedAt; // 0x10
		public long GJFPFFBAKGK_CloseAt; // 0x18
		public string ADCMNODJBGJ_title; // 0x20
		public string JONNCMDGMKA_Message; // 0x24
		public int EAHPLCJMPHD_PId; // 0x28 ImageId
		public int LKDJHPLBKAI_GraffitiId; // 0x2C
		public int MHPAFEEPBNJ; // 0x30
		public int GGHHHIIENAF_DivaLId; // 0x34
		public int NLPDDGADNFP_DivaRId; // 0x38
		public int ILPJHHKLOEN_Situation; // 0x3C

		//public int BNHOEFJAAKK_prio { get; } 0xC700A4 NNDJHLOPFJB
	}

	public List<ALLFFCNKFBG> CDENCMNHNGA_table { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB

	//// RVA: 0xC6F9D8 Offset: 0xC6F9D8 VA: 0xC6F9D8
	public ALLFFCNKFBG LBDOLHGDIEB_GetTips(int _PPFNGGCBJKC_id)
	{
		return CDENCMNHNGA_table.Find((ALLFFCNKFBG _GHPLINIACBB_x) =>
		{
			//0xC7006C
			return _PPFNGGCBJKC_id == _GHPLINIACBB_x.PPFNGGCBJKC_id;
		});
	}

	// RVA: 0xC6FAD8 Offset: 0xC6FAD8 VA: 0xC6FAD8
	public BCKMELFCKKN_Tips()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		CDENCMNHNGA_table = new List<ALLFFCNKFBG>();
		LMHMIIKCGPE = 80;
	}

	// RVA: 0xC6FBCC Offset: 0xC6FBCC VA: 0xC6FBCC Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0xC6FC44 Offset: 0xC6FC44 VA: 0xC6FC44 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		DGLENODDACE parser = DGLENODDACE.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		KLNOMBKJDNN(parser);
		return true;
	}

	// RVA: 0xC7004C Offset: 0xC7004C VA: 0xC7004C Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
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
			data.PPFNGGCBJKC_id = (short)array[i].PPFNGGCBJKC_id;
			data.NCGNCEOOBGP_EventType = (sbyte)array[i].CBDOEDKIOJK_ev;
			data.KJBGCLPMLCG_OpenedAt = array[i].MGPEOHKLOEP;
			data.GJFPFFBAKGK_CloseAt = array[i].LFAFFICDFMJ_Done;
			data.ADCMNODJBGJ_title = DatabaseTextConverter.TranslateTipsTitle(i, array[i].ADCMNODJBGJ_title);
			data.JONNCMDGMKA_Message = DatabaseTextConverter.TranslateTipsMessage(i, array[i].IPBHCLIHAPG);
			data.PPEGAKEIEGM_Enabled = (sbyte)JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE_mver, array[i].PLALNIIBLOF_en, 0);
			data.EAHPLCJMPHD_PId = array[i].HANMDEBPBHG_pic;
			data.LKDJHPLBKAI_GraffitiId = array[i].HBDKKPIOFND;
			data.MHPAFEEPBNJ = array[i].NHBLDIPBHNF_pg;
			data.HFLGGIBMEOL = array[i].KPECMLFDLOI_pri;
			data.GGHHHIIENAF_DivaLId = array[i].GENGOHFLGLG;
			data.NLPDDGADNFP_DivaRId = array[i].OAAMGLOGJNN;
			data.ILPJHHKLOEN_Situation = array[i].PDMJBLLHICB;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	//// RVA: 0xC70054 Offset: 0xC70054 VA: 0xC70054
	//private bool KLNOMBKJDNN(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label) { }

	// RVA: 0xC70064 Offset: 0xC70064 VA: 0xC70064 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "BCKMELFCKKN_Tips.CAOGDCBPBAN");
		return 0;
	}
}
