
using System.Collections.Generic;

[System.Obsolete("Use ILLPGHGGKLL_TutorialMiniAdv", true)]
public class ILLPGHGGKLL { }
public class ILLPGHGGKLL_TutorialMiniAdv : DIHHCBACKGG_DbSection
{
	public class AFBMNDPOALE
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int NDFOAINJPIN_pos; // 0xC
		public string[] JONNCMDGMKA_Message; // 0x10
		public int[] KGJHFFNFPOK_CharacterId; // 0x14
		public int[] CJPMCKIOCGI; // 0x18
	}

	public List<AFBMNDPOALE> CDENCMNHNGA_table { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB

	//// RVA: 0x9F61C8 Offset: 0x9F61C8 VA: 0x9F61C8
	public AFBMNDPOALE LBDOLHGDIEB_Find(int _PPFNGGCBJKC_id)
	{
		return CDENCMNHNGA_table.Find((AFBMNDPOALE _GHPLINIACBB_x) =>
		{
			//0x9F66A8
			return _GHPLINIACBB_x.PPFNGGCBJKC_id == _PPFNGGCBJKC_id;
		});
	}

	// RVA: 0x9F62C8 Offset: 0x9F62C8 VA: 0x9F62C8
	public ILLPGHGGKLL_TutorialMiniAdv()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		CDENCMNHNGA_table = new List<AFBMNDPOALE>();
		LMHMIIKCGPE = 82;
	}

	// RVA: 0x9F63BC Offset: 0x9F63BC VA: 0x9F63BC Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0x9F6434 Offset: 0x9F6434 VA: 0x9F6434 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		EMEEODMLEHD parser = EMEEODMLEHD.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		KLNOMBKJDNN(parser);
		return true;
	}

	// RVA: 0x9F6688 Offset: 0x9F6688 VA: 0x9F6688 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
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
			data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC_id;
			data.JONNCMDGMKA_Message = new string[array[i].IPBHCLIHAPG_Msg.Length];
			for(int j = 0; j < data.JONNCMDGMKA_Message.Length; j++)
				data.JONNCMDGMKA_Message[j] = DatabaseTextConverter.TranslateTutoMiniAdventureMessage(i, j, array[i].IPBHCLIHAPG_Msg[j]);
			data.CJPMCKIOCGI = array[i].OGDLCNPFODO;
			data.NDFOAINJPIN_pos = array[i].NDFOAINJPIN_pos;
			data.KGJHFFNFPOK_CharacterId = array[i].ECEOBKOFJHK;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	//// RVA: 0x9F6690 Offset: 0x9F6690 VA: 0x9F6690
	//private bool KLNOMBKJDNN(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label) { }

	// RVA: 0x9F66A0 Offset: 0x9F66A0 VA: 0x9F66A0 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "ILLPGHGGKLL_TutorialMiniAdv.CAOGDCBPBAN");
		return 0;
	}
}
