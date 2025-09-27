
using System.Collections.Generic;

[System.Obsolete("Use AIPOFGJGPKI_CampaignDiva", true)]
public class AIPOFGJGPKI { }
public class AIPOFGJGPKI_CampaignDiva : DIHHCBACKGG_DbSection
{
	public class KBLBMGDILAI
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int PPEGAKEIEGM_Enabled; // 0xC
		public long PDBPFJJCADD_open_at; // 0x10
		public long FDBNFFNFOND_close_at; // 0x18
		public int[] BMFACNFNCKC; // 0x20
		public int[] MFKKADJIHHK; // 0x24

		//// RVA: 0xCD2394 Offset: 0xCD2394 VA: 0xCD2394
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0xCD248C Offset: 0xCD248C VA: 0xCD248C
		public int MPHGKGNCCEE(int _AHHJLDLAPAN_DivaId, int _AKNELONELJK_difficulty)
		{
			return BMFACNFNCKC[_AKNELONELJK_difficulty] * MFKKADJIHHK[_AHHJLDLAPAN_DivaId - 1];
		}
	}

	public List<KBLBMGDILAI> CDENCMNHNGA_table { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB

	//// RVA: 0xCD1D54 Offset: 0xCD1D54 VA: 0xCD1D54
	public KBLBMGDILAI MDKOCDHIDMA(long PACNICEIIDI)
	{
		for(int i = 0; i < CDENCMNHNGA_table.Count; i++)
		{
			if (CDENCMNHNGA_table[i].PPEGAKEIEGM_Enabled == 2 && PACNICEIIDI >= CDENCMNHNGA_table[i].PDBPFJJCADD_open_at && PACNICEIIDI < CDENCMNHNGA_table[i].FDBNFFNFOND_close_at)
				return CDENCMNHNGA_table[i];
		}
		return null;
	}

	// RVA: 0xCD1E68 Offset: 0xCD1E68 VA: 0xCD1E68
	public AIPOFGJGPKI_CampaignDiva()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 9;
		CDENCMNHNGA_table = new List<KBLBMGDILAI>();
	}

	// RVA: 0xCD1F5C Offset: 0xCD1F5C VA: 0xCD1F5C Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0xCD1FD4 Offset: 0xCD1FD4 VA: 0xCD1FD4 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		MBBEDEBFEHK parser = MBBEDEBFEHK.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		LLLEJDAGGKF(parser);
		return true;
	}

	// RVA: 0xCD229C Offset: 0xCD229C VA: 0xCD229C Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return true;
	}

	// RVA: 0xCD2000 Offset: 0xCD2000 VA: 0xCD2000
	private bool LLLEJDAGGKF(MBBEDEBFEHK JMHECKKKMLK)
	{
		LCFLMIGPBLJ[] array = JMHECKKKMLK.KNCEIKIFAGD;
		for(int i = 0; i < array.Length; i++)
		{
			KBLBMGDILAI data = new KBLBMGDILAI();
			data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC_id;
			data.PPEGAKEIEGM_Enabled = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE_mver, array[i].PLALNIIBLOF_en, 0);
			data.PDBPFJJCADD_open_at = array[i].PDBPFJJCADD_open_at;
			data.FDBNFFNFOND_close_at = array[i].FDBNFFNFOND_close_at;
			data.BMFACNFNCKC = array[i].BMFACNFNCKC;
			data.MFKKADJIHHK = array[i].MFKKADJIHHK;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	// RVA: 0xCD22AC Offset: 0xCD22AC VA: 0xCD22AC Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "AIPOFGJGPKI_CampaignDiva.CAOGDCBPBAN");
		return 0;
	}
}
