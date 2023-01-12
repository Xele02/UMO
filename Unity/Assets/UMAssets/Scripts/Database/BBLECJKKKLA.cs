using System.Collections.Generic;

public class BBLECJKKKLA { }
public class BBLECJKKKLA_DecoSetItem : DIHHCBACKGG_DbSection
{
	public class GJBPBKNHLHC_DecoSetItemInfo
	{
		public int EHOIENNDEDH; // 0x8
		public int HNJHPNPFAAN; // 0xC
		public int EAJCFBCHIFB; // 0x10
		public int IPAKEGGICML; // 0x14
		public int MMDBOPCEKCJ; // 0x18
		public int HJCJMAONOMH; // 0x1C
		public int HAIFEBPOPEF; // 0x20
		public int GJFLAHAGDKG; // 0x24
		public int[] OMALMJLHABC; // 0x28

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0xF2C094 DEMEPMAEJOO 0xF2BA2C HIGKAIDMOKN
		public int PLALNIIBLOF { get { return HNJHPNPFAAN ^ FBGGEFFJJHB; } set { HNJHPNPFAAN = value ^ FBGGEFFJJHB; } } //0xF2C12C JPCJNLHHIPE 0xF2BB64 JJFJNEJLBDG
		public int EKLIPGELKCL { get { return EAJCFBCHIFB ^ FBGGEFFJJHB; } set { EAJCFBCHIFB = value ^ FBGGEFFJJHB; } } //0xF2C1C4 OEEHBGECGKL 0xF2BAC8 GHLMHLJJBIG
		public int CPKMLLNADLJ { get { return IPAKEGGICML ^ FBGGEFFJJHB; } set { IPAKEGGICML = value ^ FBGGEFFJJHB; } } //0xF2C25C BJPJMGHCDNO 0xF2BC00 BPKIOJBKNBP
		public int MLMCEBBDJOE { get { return MMDBOPCEKCJ ^ FBGGEFFJJHB; } set { MMDBOPCEKCJ = value ^ FBGGEFFJJHB; } } //0xF2C2F4 IGMHCODOFKG 0xF2BC9C IIIGDLGGEGK
		public int ODNILEDOAIP { get { return HJCJMAONOMH ^ FBGGEFFJJHB; } set { HJCJMAONOMH = value ^ FBGGEFFJJHB; } } //0xF2C38C GNKPMBBAJHI 0xF2BD38 PPMACIMALAC
		public int NPPGKNGIFGK { get { return HAIFEBPOPEF ^ FBGGEFFJJHB; } set { HAIFEBPOPEF = value ^ FBGGEFFJJHB; } } //0xF2C424 FLMDBAFHDNJ 0xF2BDD4 DIHIEJPOCOJ
		public int KEJMJPHFFOJ { get { return GJFLAHAGDKG ^ FBGGEFFJJHB; } set { GJFLAHAGDKG = value ^ FBGGEFFJJHB; } } //0xF2C4BC FMNMLNIALNE 0xF2BE70 GBEPCBPOGDB

		// // RVA: 0xF2C554 Offset: 0xF2C554 VA: 0xF2C554
		// public int FKNBLDPIPMC(int BMBBDIAEOMP) { }

		// // RVA: 0xF2C628 Offset: 0xF2C628 VA: 0xF2C628
		// public int NKOHMLHLJGL(int BMBBDIAEOMP) { }

		// // RVA: 0xF2C700 Offset: 0xF2C700 VA: 0xF2C700
		// public int JJBNDDDGEAN() { }

		// // RVA: 0xF2BFF8 Offset: 0xF2BFF8 VA: 0xF2BFF8
		// public uint CAOGDCBPBAN() { }
	}

	public const int ICGIBJBALLH = 300;
	public static int FBGGEFFJJHB = 0x181b5; // 0x0
	public List<GJBPBKNHLHC_DecoSetItemInfo> CDENCMNHNGA = new List<GJBPBKNHLHC_DecoSetItemInfo>(300); // 0x20

	// // RVA: 0xF2B3A0 Offset: 0xF2B3A0 VA: 0xF2B3A0
	public BBLECJKKKLA_DecoSetItem()
    {
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 16;
    }

	// // RVA: 0xF2B498 Offset: 0xF2B498 VA: 0xF2B498 Slot: 8
	protected override void KMBPACJNEOF()
    {
		CDENCMNHNGA.Clear();
    }

	// // RVA: 0xF2B510 Offset: 0xF2B510 VA: 0xF2B510 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
    {
		MDMEBHPAKIH parser = MDMEBHPAKIH.HEGEKFMJNCC(DBBGALAPFGC);
		DDHCKMFAKFA[] array = parser.NFBMFDPFHCL;
		for(int i = 0; i < array.Length; i++)
		{
			GJBPBKNHLHC_DecoSetItemInfo data = new GJBPBKNHLHC_DecoSetItemInfo();
			data.PPFNGGCBJKC_Id = array[i].PPFNGGCBJKC;
			data.EKLIPGELKCL = array[i].FBFLDFMFFOH;
			data.PLALNIIBLOF = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, 0);
			data.CPKMLLNADLJ = array[i].CPKMLLNADLJ;
			data.MLMCEBBDJOE = array[i].MLMCEBBDJOE;
			data.ODNILEDOAIP = array[i].ODNILEDOAIP;
			data.NPPGKNGIFGK = array[i].NPPGKNGIFGK;
			int[] array2 = array[i].PIPDCAEIBPO;
			data.OMALMJLHABC = new int[array2.Length];
			for(int j = 0; j < array2.Length; j++)
			{
				data.OMALMJLHABC[j] = array2[j] ^ FBGGEFFJJHB;
			}
			data.KEJMJPHFFOJ = array[i].KEJMJPHFFOJ;
			CDENCMNHNGA.Add(data);
		}
		return true;
    }

	// // RVA: 0xF2BF0C Offset: 0xF2BF0C VA: 0xF2BF0C Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return false;
	}

	// // RVA: 0xF2BF14 Offset: 0xF2BF14 VA: 0xF2BF14 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(100, "DecoSteItem CAOGDCBPBAN");
		return 0;
	}
}
