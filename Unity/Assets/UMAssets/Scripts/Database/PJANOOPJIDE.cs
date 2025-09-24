
using System.Collections.Generic;

[System.Obsolete("Use PJANOOPJIDE_TutorialPict", true)]
public class PJANOOPJIDE { }
public class PJANOOPJIDE_TutorialPict : DIHHCBACKGG_DbSection
{
	public class HNHHGJCPMEA
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int[] FJOLNJLLJEJ_rank; // 0xC
		public int[] AKBHPFBDDOL_Val; // 0x10 TutoCondId
		public int PPEGAKEIEGM_Enabled; // 0x14
		public int KNHABOOAAIP; // 0x18
		public string[] JONNCMDGMKA_Message; // 0x1C
		public string[] ADCMNODJBGJ_title; // 0x20
		public int[] MAPDMCPCLFA_PicIds; // 0x24
		public int[] KMDGMOMCDAD; // 0x28
		public int IODLCIBCONC; // 0x2C
	}

	public List<HNHHGJCPMEA> CDENCMNHNGA_table { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB

	//// RVA: 0x92FFCC Offset: 0x92FFCC VA: 0x92FFCC
	public HNHHGJCPMEA LBDOLHGDIEB(int _PPFNGGCBJKC_id)
	{
		return CDENCMNHNGA_table.Find((HNHHGJCPMEA _GHPLINIACBB_x) =>
		{
			//0x9305E8
			return _GHPLINIACBB_x.PPFNGGCBJKC_id == _PPFNGGCBJKC_id;
		});
	}

	// RVA: 0x9300CC Offset: 0x9300CC VA: 0x9300CC
	public PJANOOPJIDE_TutorialPict()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		CDENCMNHNGA_table = new List<HNHHGJCPMEA>();
		LMHMIIKCGPE = 83;
	}

	// RVA: 0x9301C0 Offset: 0x9301C0 VA: 0x9301C0 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0x930238 Offset: 0x930238 VA: 0x930238 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		BOFIIKIJEPA parser = BOFIIKIJEPA.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		KLNOMBKJDNN(parser);
		return true;
	}

	// RVA: 0x9305C8 Offset: 0x9305C8 VA: 0x9305C8 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return true;
	}

	//// RVA: 0x930264 Offset: 0x930264 VA: 0x930264
	private bool KLNOMBKJDNN(BOFIIKIJEPA JMHECKKKMLK)
	{
		LKCILPCIPBE[] array = JMHECKKKMLK.NBDMOIBEDFI;
		for(int i = 0; i < array.Length; i++)
		{
			HNHHGJCPMEA data = new HNHHGJCPMEA();
			data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC;
			data.AKBHPFBDDOL_Val = array[i].JIMJHIDEHNM;
			data.PPEGAKEIEGM_Enabled = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, array[i].DBHPPMPNCKF);
			data.KNHABOOAAIP = array[i].KNHABOOAAIP;
			
			data.JONNCMDGMKA_Message = new string[array[i].IPBHCLIHAPG.Length];
			for(int j = 0; j < data.JONNCMDGMKA_Message.Length; j++)
				data.JONNCMDGMKA_Message[j] = DatabaseTextConverter.TranslateTutoPictMessage(i, j, array[i].IPBHCLIHAPG[j]);

			data.ADCMNODJBGJ_title = new string[array[i].ADCMNODJBGJ.Length];
			for(int j = 0; j < data.ADCMNODJBGJ_title.Length; j++)
				data.ADCMNODJBGJ_title[j] = DatabaseTextConverter.TranslateTutoPictTitle(i, j, array[i].ADCMNODJBGJ[j]);

			data.MAPDMCPCLFA_PicIds = array[i].HANMDEBPBHG;
			data.FJOLNJLLJEJ_rank = array[i].INANEEGAEEG;
			data.KMDGMOMCDAD = array[i].JOFAJDPOEOB;
			data.IODLCIBCONC = array[i].BFCILBEICEN;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	//// RVA: 0x9305D0 Offset: 0x9305D0 VA: 0x9305D0
	//private bool KLNOMBKJDNN(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label) { }

	// RVA: 0x9305E0 Offset: 0x9305E0 VA: 0x9305E0 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "PJANOOPJIDE_TutorialPict.CAOGDCBPBAN");
		return 0;
	}
}
