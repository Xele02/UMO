
using System.Collections.Generic;

[System.Obsolete("Use PJANOOPJIDE_TutorialPict", true)]
public class PJANOOPJIDE { }
public class PJANOOPJIDE_TutorialPict : DIHHCBACKGG_DbSection
{
	public class HNHHGJCPMEA
	{
		public int PPFNGGCBJKC; // 0x8
		public int[] FJOLNJLLJEJ; // 0xC
		public int[] AKBHPFBDDOL_TutoCondId; // 0x10
		public int PPEGAKEIEGM_Enabled; // 0x14
		public int KNHABOOAAIP; // 0x18
		public string[] JONNCMDGMKA; // 0x1C
		public string[] ADCMNODJBGJ; // 0x20
		public int[] MAPDMCPCLFA; // 0x24
		public int[] KMDGMOMCDAD; // 0x28
		public int IODLCIBCONC; // 0x2C
	}

	public List<HNHHGJCPMEA> CDENCMNHNGA { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB

	//// RVA: 0x92FFCC Offset: 0x92FFCC VA: 0x92FFCC
	public HNHHGJCPMEA LBDOLHGDIEB(int PPFNGGCBJKC)
	{
		return CDENCMNHNGA.Find((HNHHGJCPMEA GHPLINIACBB) =>
		{
			//0x9305E8
			return GHPLINIACBB.PPFNGGCBJKC == PPFNGGCBJKC;
		});
	}

	// RVA: 0x9300CC Offset: 0x9300CC VA: 0x9300CC
	public PJANOOPJIDE_TutorialPict()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		CDENCMNHNGA = new List<HNHHGJCPMEA>();
		LMHMIIKCGPE = 83;
	}

	// RVA: 0x9301C0 Offset: 0x9301C0 VA: 0x9301C0 Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
	}

	// RVA: 0x930238 Offset: 0x930238 VA: 0x930238 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		BOFIIKIJEPA parser = BOFIIKIJEPA.HEGEKFMJNCC(DBBGALAPFGC);
		KLNOMBKJDNN(parser);
		return true;
	}

	// RVA: 0x9305C8 Offset: 0x9305C8 VA: 0x9305C8 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
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
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			data.AKBHPFBDDOL_TutoCondId = array[i].JIMJHIDEHNM;
			data.PPEGAKEIEGM_Enabled = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, array[i].DBHPPMPNCKF);
			data.KNHABOOAAIP = array[i].KNHABOOAAIP;
			data.JONNCMDGMKA = array[i].IPBHCLIHAPG;
			data.ADCMNODJBGJ = array[i].ADCMNODJBGJ;
			data.MAPDMCPCLFA = array[i].HANMDEBPBHG;
			data.FJOLNJLLJEJ = array[i].INANEEGAEEG;
			data.KMDGMOMCDAD = array[i].JOFAJDPOEOB;
			data.IODLCIBCONC = array[i].BFCILBEICEN;
			CDENCMNHNGA.Add(data);
		}
		return true;
	}

	//// RVA: 0x9305D0 Offset: 0x9305D0 VA: 0x9305D0
	//private bool KLNOMBKJDNN(EDOHBJAPLPF OILEIIEIBHP, int KAPMOPMDHJE) { }

	// RVA: 0x9305E0 Offset: 0x9305E0 VA: 0x9305E0 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "PJANOOPJIDE_TutorialPict.CAOGDCBPBAN");
		return 0;
	}
}
