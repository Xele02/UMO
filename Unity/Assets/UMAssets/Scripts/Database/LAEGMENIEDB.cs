
using System.Collections.Generic;

[System.Obsolete("Use LAEGMENIEDB_Story", true)]
public class LAEGMENIEDB { }
public class LAEGMENIEDB_Story : DIHHCBACKGG_DbSection
{
	public class ALGOILKGAAH
	{
		public int FBGGEFFJJHB; // 0x8
		public int KFAJGFGFFPJ; // 0xC
		public int HNJHPNPFAAN; // 0x10
		public int HKILOJEJAIH; // 0x14
		public int LCHOHDPAADG; // 0x18
		public int DKPBMFCNOMJ; // 0x1C
		public int EGFIMHJIFKP; // 0x20
		public int OJFGIINELDH; // 0x24
		public int BKHDKHFBAPG; // 0x28
		public int MLFBNJDFNAO; // 0x2C
		public int DHNEKDEDIND; // 0x30
		public int MMBAHPBKNDN; // 0x34
		public int BCFHJAEBGFJ; // 0x38
		public int OILLAIFOKHK; // 0x3C

		//public int LFLLLOPAKCO { get; set; } 0xD8F13C ELEKBNDPLGB 0xD8F758 HDKGOIOBCFI
		//public int PPEGAKEIEGM { get; set; } 0xD8EF6C KPOEEPIMMJP 0xD8F768 NCIEAFEDPBH
		//public int KLCIIHKFPPO { get; set; } 0xD8EF8C CPDGCNILCII 0xD8F778 IILKMGEKOBG
		//public int JHPPLIGJFPI { get; set; } 0xD8FA20 OJLADDBGHCB 0xD8F788 OCKBPONMDGA
		//public int NOCGGJPABMA { get; set; } 0xD8FA30 MLBEDKHJGPJ 0xD8F798 CNJDPAMOMEM
		//public int JIHMAJENMDO { get; set; } 0xD8FA40 OBBAHPDEEFA 0xD8F7A8 HPJAHFOODLM
		//public int EPBBNFDFLLD { get; set; } 0xD8FA50 BLGGFAKCGDK 0xD8F7B8 FMMOBHNGGCF
		//public int ICKPLIABPKC { get; set; } 0xD8FA60 DMHPENAMNJH 0xD8F7C8 NDFINNLJJMF
		//public int JOPNDOKOIHI { get; set; } 0xD8FA70 MGFAKJJGIKL 0xD8F7D8 DKMKKNDBDPC
		//public int GGOCFLLMHPH { get; set; } 0xD8FA80 PFBGJGDACNP 0xD8F7E8 GDLDINAMCOP
		//public int OMMEPCGNHFM { get; set; } 0xD8EF7C DEKIKCKDFME 0xD8F7F8 MDFDOBGMHKL
		//public int MHPAFEEPBNJ { get; set; } 0xD8FA90 NODKIDEKNGJ 0xD8F808 CHFBEINBPKA
		//public int JJPKBHLKILC { get; set; } 0xD8FAA0 PACFBIGGOEB 0xD8F818 LIACCHHNAOK

		//// RVA: 0xD8F914 Offset: 0xD8F914 VA: 0xD8F914
		//public uint CAOGDCBPBAN() { }
	}

	public const int BDCHCMHKIHF = 160;
	public static int FBGGEFFJJHB = 0xb516d; // 0x0
	public List<ALGOILKGAAH> CDENCMNHNGA = new List<ALGOILKGAAH>(); // 0x20

	//// RVA: 0xD8EDCC Offset: 0xD8EDCC VA: 0xD8EDCC
	//public int EPBLBFOIEEB(int GHBPLHBNMBK) { }

	//// RVA: 0xD8EF9C Offset: 0xD8EF9C VA: 0xD8EF9C
	//public int JOHMIPPKPPM(int GHBPLHBNMBK) { }

	// RVA: 0xD8F14C Offset: 0xD8F14C VA: 0xD8F14C
	public LAEGMENIEDB_Story()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 78;
	}

	// RVA: 0xD8F244 Offset: 0xD8F244 VA: 0xD8F244 Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
	}

	// RVA: 0xD8F2BC Offset: 0xD8F2BC VA: 0xD8F2BC Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		TodoLogger.Log(TodoLogger.Database, "LAEGMENIEDB_Story.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0xD8F828 Offset: 0xD8F828 VA: 0xD8F828 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(TodoLogger.Database, "LAEGMENIEDB_Story.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0xD8F830 Offset: 0xD8F830 VA: 0xD8F830 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "LAEGMENIEDB_Story.CAOGDCBPBAN");
		return 0;
	}
}
