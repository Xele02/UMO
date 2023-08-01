
[System.Obsolete("Use KCDJCKCKKFM_HelpBrowser", true)]
public class KCDJCKCKKFM { }
public class KCDJCKCKKFM_HelpBrowser : DIHHCBACKGG_DbSection
{
	public DPGPEALHJOB[] LOMHJBIJMOD; // 0x20
	public CEFDJALCHBL[] FBJCBCOEBBB; // 0x24

	// RVA: 0x101FCA4 Offset: 0x101FCA4 VA: 0x101FCA4
	public KCDJCKCKKFM_HelpBrowser()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 51;
	}

	// RVA: 0x101FD64 Offset: 0x101FD64 VA: 0x101FD64 Slot: 8
	protected override void KMBPACJNEOF()
	{
		LOMHJBIJMOD = null;
		FBJCBCOEBBB = null;
	}

	// RVA: 0x101FD74 Offset: 0x101FD74 VA: 0x101FD74 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		IGDFIPKLHBA parser = IGDFIPKLHBA.HEGEKFMJNCC(DBBGALAPFGC);
		LOMHJBIJMOD = parser.FNOIEDBFLPH;
		FBJCBCOEBBB = parser.NAPKJCKIPEF;
		return true;
	}

	// RVA: 0x101FDE4 Offset: 0x101FDE4 VA: 0x101FDE4 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return false;
	}

	// RVA: 0x101FDEC Offset: 0x101FDEC VA: 0x101FDEC Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "KCDJCKCKKFM_HelpBrowser.CAOGDCBPBAN");
		return 0;
	}
}
