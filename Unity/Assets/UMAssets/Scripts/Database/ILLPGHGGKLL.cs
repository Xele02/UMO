
using System.Collections.Generic;

[System.Obsolete("Use ILLPGHGGKLL_TutorialMiniAdv", true)]
public class ILLPGHGGKLL { }
public class ILLPGHGGKLL_TutorialMiniAdv : DIHHCBACKGG_DbSection
{
	public class AFBMNDPOALE
	{
		public int PPFNGGCBJKC_Id; // 0x8
		public int NDFOAINJPIN_WindowPositionTop; // 0xC
		public string[] JONNCMDGMKA_Messages; // 0x10
		public int[] KGJHFFNFPOK_CharacterId; // 0x14
		public int[] CJPMCKIOCGI; // 0x18
	}

	public List<AFBMNDPOALE> CDENCMNHNGA { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB

	//// RVA: 0x9F61C8 Offset: 0x9F61C8 VA: 0x9F61C8
	public AFBMNDPOALE LBDOLHGDIEB(int PPFNGGCBJKC)
	{
		return CDENCMNHNGA.Find((AFBMNDPOALE GHPLINIACBB) =>
		{
			//0x9F66A8
			return GHPLINIACBB.PPFNGGCBJKC_Id == PPFNGGCBJKC;
		});
	}

	// RVA: 0x9F62C8 Offset: 0x9F62C8 VA: 0x9F62C8
	public ILLPGHGGKLL_TutorialMiniAdv()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		CDENCMNHNGA = new List<AFBMNDPOALE>();
		LMHMIIKCGPE = 82;
	}

	// RVA: 0x9F63BC Offset: 0x9F63BC VA: 0x9F63BC Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
	}

	// RVA: 0x9F6434 Offset: 0x9F6434 VA: 0x9F6434 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		EMEEODMLEHD parser = EMEEODMLEHD.HEGEKFMJNCC(DBBGALAPFGC);
		KLNOMBKJDNN(parser);
		return true;
	}

	// RVA: 0x9F6688 Offset: 0x9F6688 VA: 0x9F6688 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return true;
	}

	//// RVA: 0x9F6460 Offset: 0x9F6460 VA: 0x9F6460
	private bool KLNOMBKJDNN(EMEEODMLEHD JMHECKKKMLK)
	{
		JOEEBALPECG[] array = JMHECKKKMLK.DKBBEHIHBEK;
		for(int i = 0; i < array.Length; i++)
		{
			AFBMNDPOALE data = new AFBMNDPOALE();
			data.PPFNGGCBJKC_Id = array[i].PPFNGGCBJKC;
			data.JONNCMDGMKA_Messages = new string[array[i].IPBHCLIHAPG.Length];
			for(int j = 0; j < data.JONNCMDGMKA_Messages.Length; j++)
				data.JONNCMDGMKA_Messages[j] = DatabaseTextConverter.TranslateTutoMiniAdventureMessage(i, j, array[i].IPBHCLIHAPG[j]);
			data.CJPMCKIOCGI = array[i].OGDLCNPFODO;
			data.NDFOAINJPIN_WindowPositionTop = array[i].NDFOAINJPIN;
			data.KGJHFFNFPOK_CharacterId = array[i].ECEOBKOFJHK;
			CDENCMNHNGA.Add(data);
		}
		return true;
	}

	//// RVA: 0x9F6690 Offset: 0x9F6690 VA: 0x9F6690
	//private bool KLNOMBKJDNN(EDOHBJAPLPF OILEIIEIBHP, int KAPMOPMDHJE) { }

	// RVA: 0x9F66A0 Offset: 0x9F66A0 VA: 0x9F66A0 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "ILLPGHGGKLL_TutorialMiniAdv.CAOGDCBPBAN");
		return 0;
	}
}
