using System.Collections.Generic;

[System.Obsolete("Use HHJHIFJIKAC_BonusVc", true)]
public class HHJHIFJIKAC { }
public class HHJHIFJIKAC_BonusVc : DIHHCBACKGG_DbSection
{
    public enum IJFKAIHFJLF
    {
        HJNNKCMLGFL = 0,
        JGDEHOGIENP = 1,
        JEPMLKCJCPK = 2,
        HCHFCCEMJED = 3,
        KJBGPOMJFBE_MonthlyPass = 4,
        MDIJEKDNLFC = 5,
        ONIIJLCOCAC = 6,
        MCPDGFMLJNG = 7,
        PPPGDKCDACF = 8,
    }

    public class MNGJPJBCMBH
    {
        public int PPFNGGCBJKC_Id; // 0x8
        public int PLALNIIBLOF_Enabled; // 0xC
        public int PDBPFJJCADD; // 0x10
        public int EGBOHDFBAPB_ClosedAt; // 0x14
        public int KMENGHEAIOC; // 0x18
        public int JDANEOJCLBB; // 0x1C
        public int CPGFOBNKKBF; // 0x20
        public int INDDJNMPONH; // 0x24
        public int JBGEEPFKIGG; // 0x28

        // // RVA: 0x1831930 Offset: 0x1831930 VA: 0x1831930
        // public uint CAOGDCBPBAN() { }

        // // RVA: 0x18319B4 Offset: 0x18319B4 VA: 0x18319B4
        public bool EHKLFIBLHPI_IsTimeValid(long JHNMKKNEENE)
		{
			if(PLALNIIBLOF_Enabled == 2 && INDDJNMPONH == 3)
			{
				return PDBPFJJCADD <= JHNMKKNEENE && JHNMKKNEENE <= EGBOHDFBAPB_ClosedAt;
			}
			return false;
		}
    }

	public static int FBGGEFFJJHB = 0xb516d; // 0x0
	public List<MNGJPJBCMBH> CDENCMNHNGA = new List<MNGJPJBCMBH>(); // 0x20

	// // RVA: 0x1830F38 Offset: 0x1830F38 VA: 0x1830F38
	// public bool IIEKKOHBNLA(int INFIBMLIHLO) { }

	// // RVA: 0x183106C Offset: 0x183106C VA: 0x183106C
	public MNGJPJBCMBH NPOALOFHFPN(int PPFNGGCBJKC_Id)
	{
		for(int i = 0; i < CDENCMNHNGA.Count; i++)
		{
			if (CDENCMNHNGA[i].PLALNIIBLOF_Enabled == 2 && CDENCMNHNGA[i].INDDJNMPONH == 1 && CDENCMNHNGA[i].PPFNGGCBJKC_Id == PPFNGGCBJKC_Id)
				return CDENCMNHNGA[i];
		}
		return null;
	}

	// // RVA: 0x1831168 Offset: 0x1831168 VA: 0x1831168
	// public HHJHIFJIKAC.MNGJPJBCMBH GOLBDLHCBCA(long EOLFJGMAJAB) { }

	// // RVA: 0x1831284 Offset: 0x1831284 VA: 0x1831284
	public MNGJPJBCMBH EKENMIDOHPL_GetActiveBonus(long EOLFJGMAJAB, IJFKAIHFJLF CHOIMHCMAHG = IJFKAIHFJLF.JEPMLKCJCPK/*2*/)
	{
		for(int i = 0; i < CDENCMNHNGA.Count; i++)
		{
			if(CDENCMNHNGA[i].PLALNIIBLOF_Enabled == 2 && CDENCMNHNGA[i].INDDJNMPONH == (int)CHOIMHCMAHG)
			{
				if (CDENCMNHNGA[i].PDBPFJJCADD < EOLFJGMAJAB && CDENCMNHNGA[i].EGBOHDFBAPB_ClosedAt > EOLFJGMAJAB)
				{
					return CDENCMNHNGA[i];
				}
			}
		}
		return null;
	}

	// // RVA: 0x18313A8 Offset: 0x18313A8 VA: 0x18313A8
	public HHJHIFJIKAC_BonusVc()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 8;
	}

	// // RVA: 0x183149C Offset: 0x183149C VA: 0x183149C Slot: 8
	protected override void KMBPACJNEOF()
    {
		CDENCMNHNGA.Clear();
	}

	// // RVA: 0x1831514 Offset: 0x1831514 VA: 0x1831514 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
    {
		FGALMCADGMO parser = FGALMCADGMO.HEGEKFMJNCC(DBBGALAPFGC);
		MEEJPBEAKKP[] array = parser.BHOHDFAFCNL;
		for(int i = 0; i < array.Length; i++)
		{
			MNGJPJBCMBH data = new MNGJPJBCMBH();
			data.PPFNGGCBJKC_Id = array[i].PPFNGGCBJKC;
			data.PLALNIIBLOF_Enabled = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, 0);
			data.PDBPFJJCADD = array[i].PDBPFJJCADD;
			data.EGBOHDFBAPB_ClosedAt = array[i].EGBOHDFBAPB;
			data.KMENGHEAIOC = array[i].KMENGHEAIOC;
			data.JDANEOJCLBB = array[i].JDANEOJCLBB;
			data.CPGFOBNKKBF = array[i].CPGFOBNKKBF;
			data.INDDJNMPONH = array[i].GBJFNGCDKPM;
			data.JBGEEPFKIGG = array[i].JBGEEPFKIGG;
			CDENCMNHNGA.Add(data);
		}
		return true;
    }

	// // RVA: 0x1831838 Offset: 0x1831838 VA: 0x1831838 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return false;
	}

	// // RVA: 0x1831840 Offset: 0x1831840 VA: 0x1831840 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "HHJHIFJIKAC_BonusVc.CAOGDCBPBAN");
		return 0;
	}
}
