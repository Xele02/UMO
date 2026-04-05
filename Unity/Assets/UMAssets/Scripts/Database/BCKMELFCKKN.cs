
using System.Collections.Generic;

[System.Obsolete("Use BCKMELFCKKN_Tips", true)]
public class BCKMELFCKKN { }
[UMOClass(ReaderClass = "DGLENODDACE")]
public class BCKMELFCKKN_Tips : DIHHCBACKGG_DbSection
{
	[UMOClass(ReaderClass = "JBFGONALAMG")]
	public class ALLFFCNKFBG
	{
		[UMOMember(ReaderMember = "PPFNGGCBJKC_id")]
		public short PPFNGGCBJKC_id; // 0x8
		[UMOMember(ReaderMember = "IJEKNCDIIAE_mver|PLALNIIBLOF_en")]
		public sbyte PPEGAKEIEGM_Enabled; // 0xA
		[UMOMember(ReaderMember = "CBDOEDKIOJK_ev")]
		public sbyte NCGNCEOOBGP_EventType; // 0xB
		[UMOMember(ReaderMember = "KPECMLFDLOI_pri")]
		public int[] HFLGGIBMEOL; // 0xC
		[UMOMember(ReaderMember = "MGPEOHKLOEP")]
		public long KJBGCLPMLCG_OpenedAt; // 0x10
		[UMOMember(ReaderMember = "LFAFFICDFMJ_Done")]
		public long GJFPFFBAKGK_CloseAt; // 0x18
		[UMOMember(ReaderMember = "ADCMNODJBGJ_title")]
		public string ADCMNODJBGJ_title; // 0x20
		[UMOMember(ReaderMember = "IPBHCLIHAPG_Msg")]
		public string JONNCMDGMKA_Message; // 0x24
		[UMOMember(ReaderMember = "HANMDEBPBHG_pic")]
		public int EAHPLCJMPHD_PId; // 0x28 ImageId
		[UMOMember(ReaderMember = "HBDKKPIOFND")]
		public int LKDJHPLBKAI_GraffitiId; // 0x2C
		[UMOMember(ReaderMember = "NHBLDIPBHNF_pg")]
		public int MHPAFEEPBNJ; // 0x30
		[UMOMember(ReaderMember = "GENGOHFLGLG")]
		public int GGHHHIIENAF_DivaLId; // 0x34
		[UMOMember(ReaderMember = "OAAMGLOGJNN")]
		public int NLPDDGADNFP_DivaRId; // 0x38
		[UMOMember(ReaderMember = "PDMJBLLHICB")]
		public int ILPJHHKLOEN_Situation; // 0x3C

		//public int BNHOEFJAAKK_prio { get; } 0xC700A4 NNDJHLOPFJB_bgs
	}

	[UMOMember(ReaderMember = "KCCHMPEPAII")]
	public List<ALLFFCNKFBG> CDENCMNHNGA_table { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF_get_table ILHOADLEJPB_set_table

	//// RVA: 0xC6F9D8 Offset: 0xC6F9D8 VA: 0xC6F9D8
	public ALLFFCNKFBG LBDOLHGDIEB_Find(int _PPFNGGCBJKC_id)
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
			data.JONNCMDGMKA_Message = DatabaseTextConverter.TranslateTipsMessage(i, array[i].IPBHCLIHAPG_Msg);
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
