
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
		TodoLogger.Log(TodoLogger.Database, "KCDJCKCKKFM_HelpBrowser.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x101FDE4 Offset: 0x101FDE4 VA: 0x101FDE4 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(TodoLogger.Database, "KCDJCKCKKFM_HelpBrowser.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x101FDEC Offset: 0x101FDEC VA: 0x101FDEC Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "KCDJCKCKKFM_HelpBrowser.CAOGDCBPBAN");
		return 0;
	}
}
 
public class DPGPEALHJOB
{
	public int PPFNGGCBJKC { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO HIGKAIDMOKN
	public int PLALNIIBLOF { get; set; } // 0xC DFMNDOMAPAB JPCJNLHHIPE JJFJNEJLBDG
	public string OPFGFINHFCE { get; set; } // 0x10 LGIIAPHCLPN DKJOHDGOIJE MJAMIGECMMF
	public int OBGBAOLONDD { get; set; } // 0x14 NCOKDCMHMJF OLHPPFCEIIK EIHCOIFCELN
	public int IJEKNCDIIAE { get; set; } // 0x18 FAHNCMHNFCG KJIMMIBDCIL DMEGNOKIKCD
	public int PDBPFJJCADD { get; set; } // 0x1C PMJMBGBCIGO FOACOMBHPAC NBACOBCOJCA
	public int FDBNFFNFOND { get; set; } // 0x20 INOJHLHGKMI BPJOGHJCLDJ NLJKMCHOCBK
	public int DIJHLDAIBCA { get; set; } // 0x24 GPNFFGDHJPG JDMOCKJPIOH KFJJFDLPEDE
}

public class CEFDJALCHBL
{
	public int OBGBAOLONDD { get; set; } // 0x8 NCOKDCMHMJF OLHPPFCEIIK EIHCOIFCELN
	//public MEDIMPGIJHC[] EBEMOEPADJB { get; set; } // 0xC HGDDOFPEOOB HOCJMMAIKKG NGAAMODFBNP
	//public KODOLHPAONC[] OJMEIBNMLNP { get; set; } // 0x10 ENJDPPONPGF DMPIELBKMNB CFLFPNGJLDF
}