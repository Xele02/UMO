
using System.Collections.Generic;

[System.Obsolete("Use AIPOFGJGPKI_CampaignDiva", true)]
public class AIPOFGJGPKI { }
public class AIPOFGJGPKI_CampaignDiva : DIHHCBACKGG_DbSection
{
	public class KBLBMGDILAI
	{
		public int PPFNGGCBJKC; // 0x8
		public int PPEGAKEIEGM; // 0xC
		public long PDBPFJJCADD; // 0x10
		public long FDBNFFNFOND; // 0x18
		public int[] BMFACNFNCKC; // 0x20
		public int[] MFKKADJIHHK; // 0x24

		//// RVA: 0xCD2394 Offset: 0xCD2394 VA: 0xCD2394
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0xCD248C Offset: 0xCD248C VA: 0xCD248C
		public int MPHGKGNCCEE(int AHHJLDLAPAN_DivaId, int AKNELONELJK)
		{
			return BMFACNFNCKC[AKNELONELJK] * MFKKADJIHHK[AHHJLDLAPAN_DivaId - 1];
		}
	}

	public List<KBLBMGDILAI> CDENCMNHNGA { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB

	//// RVA: 0xCD1D54 Offset: 0xCD1D54 VA: 0xCD1D54
	public KBLBMGDILAI MDKOCDHIDMA(long PACNICEIIDI)
	{
		for(int i = 0; i < CDENCMNHNGA.Count; i++)
		{
			if (CDENCMNHNGA[i].PPEGAKEIEGM == 2 && PACNICEIIDI >= CDENCMNHNGA[i].PDBPFJJCADD && PACNICEIIDI < CDENCMNHNGA[i].FDBNFFNFOND)
				return CDENCMNHNGA[i];
		}
		return null;
	}

	// RVA: 0xCD1E68 Offset: 0xCD1E68 VA: 0xCD1E68
	public AIPOFGJGPKI_CampaignDiva()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 9;
		CDENCMNHNGA = new List<KBLBMGDILAI>();
	}

	// RVA: 0xCD1F5C Offset: 0xCD1F5C VA: 0xCD1F5C Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
	}

	// RVA: 0xCD1FD4 Offset: 0xCD1FD4 VA: 0xCD1FD4 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		MBBEDEBFEHK parser = MBBEDEBFEHK.HEGEKFMJNCC(DBBGALAPFGC);
		LLLEJDAGGKF(parser);
		return true;
	}

	// RVA: 0xCD229C Offset: 0xCD229C VA: 0xCD229C Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
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
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			data.PPEGAKEIEGM = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, 0);
			data.PDBPFJJCADD = array[i].PDBPFJJCADD;
			data.FDBNFFNFOND = array[i].FDBNFFNFOND;
			data.BMFACNFNCKC = array[i].BMFACNFNCKC;
			data.MFKKADJIHHK = array[i].MFKKADJIHHK;
			CDENCMNHNGA.Add(data);
		}
		return true;
	}

	// RVA: 0xCD22AC Offset: 0xCD22AC VA: 0xCD22AC Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "AIPOFGJGPKI_CampaignDiva.CAOGDCBPBAN");
		return 0;
	}
}
