using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use HHJHIFJIKAC_BonusVc", true)]
public class HHJHIFJIKAC { }
public class HHJHIFJIKAC_BonusVc : DIHHCBACKGG_DbSection
{
    public enum IJFKAIHFJLF_BonusType
    {
        HJNNKCMLGFL_0_None = 0,
        JGDEHOGIENP_1_Sphere_CostumeTicket = 1,
        JEPMLKCJCPK_2_Bonus_4001_4002 = 2,
        HCHFCCEMJED_3_Bonus_20XX = 3,
        KJBGPOMJFBE_4_MonthlyPass = 4,
        MDIJEKDNLFC_5_SpecialTickets = 5,
        ONIIJLCOCAC_6 = 6,
        MCPDGFMLJNG_7_Bonus4003 = 7,
        PPPGDKCDACF_8_Omikuji = 8,
    }

    public class MNGJPJBCMBH
    {
        public int PPFNGGCBJKC_id; // 0x8
        public int PLALNIIBLOF_en; // 0xC
        public int PDBPFJJCADD_open_at; // 0x10
        public int EGBOHDFBAPB_closed_at; // 0x14
        public int KMENGHEAIOC; // 0x18
        public int JDANEOJCLBB; // 0x1C
        public int CPGFOBNKKBF_CurrencyId; // 0x20
        public int INDDJNMPONH_type; // 0x24
        public int JBGEEPFKIGG_val; // 0x28

        // // RVA: 0x1831930 Offset: 0x1831930 VA: 0x1831930
        // public uint CAOGDCBPBAN() { }

        // // RVA: 0x18319B4 Offset: 0x18319B4 VA: 0x18319B4
        public bool EHKLFIBLHPI_IsTimeValid(long _JHNMKKNEENE_Time)
		{
			if(PLALNIIBLOF_en == 2 && INDDJNMPONH_type == 3)
			{
				return PDBPFJJCADD_open_at <= _JHNMKKNEENE_Time && _JHNMKKNEENE_Time <= EGBOHDFBAPB_closed_at;
			}
			return false;
		}
    }

	public static int FBGGEFFJJHB_xor = 0xb516d; // 0x0
	public List<MNGJPJBCMBH> CDENCMNHNGA_table = new List<MNGJPJBCMBH>(); // 0x20

	// // RVA: 0x1830F38 Offset: 0x1830F38 VA: 0x1830F38
	public bool IIEKKOHBNLA_HasMonthlyPassBonus(int _INFIBMLIHLO_ItemId)
	{
        EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(_INFIBMLIHLO_ItemId);
        int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(_INFIBMLIHLO_ItemId);
		if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC)
		{
			if(id <= CDENCMNHNGA_table.Count)
			{
				return CDENCMNHNGA_table[id - 1].INDDJNMPONH_type == 4;
			}
		}
		return false;
	}

	// // RVA: 0x183106C Offset: 0x183106C VA: 0x183106C
	public MNGJPJBCMBH NPOALOFHFPN(int _PPFNGGCBJKC_id)
	{
		for(int i = 0; i < CDENCMNHNGA_table.Count; i++)
		{
			if (CDENCMNHNGA_table[i].PLALNIIBLOF_en == 2 && CDENCMNHNGA_table[i].INDDJNMPONH_type == 1 && CDENCMNHNGA_table[i].PPFNGGCBJKC_id == _PPFNGGCBJKC_id)
				return CDENCMNHNGA_table[i];
		}
		return null;
	}

	// // RVA: 0x1831168 Offset: 0x1831168 VA: 0x1831168
	// public HHJHIFJIKAC_BonusVc.MNGJPJBCMBH GOLBDLHCBCA(long _EOLFJGMAJAB_CurrentTime) { }

	// // RVA: 0x1831284 Offset: 0x1831284 VA: 0x1831284
	public MNGJPJBCMBH EKENMIDOHPL_GetActiveBonus(long _EOLFJGMAJAB_CurrentTime, IJFKAIHFJLF_BonusType _CHOIMHCMAHG_TypeId/* = IJFKAIHFJLF_BonusType.JEPMLKCJCPK_2_Bonus_4001_4002*/)
	{
		for(int i = 0; i < CDENCMNHNGA_table.Count; i++)
		{
			if(CDENCMNHNGA_table[i].PLALNIIBLOF_en == 2 && CDENCMNHNGA_table[i].INDDJNMPONH_type == (int)_CHOIMHCMAHG_TypeId)
			{
				if (CDENCMNHNGA_table[i].PDBPFJJCADD_open_at <= _EOLFJGMAJAB_CurrentTime && CDENCMNHNGA_table[i].EGBOHDFBAPB_closed_at >= _EOLFJGMAJAB_CurrentTime)
				{
					return CDENCMNHNGA_table[i];
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
	protected override void KMBPACJNEOF_Reset()
    {
		CDENCMNHNGA_table.Clear();
	}

	// // RVA: 0x1831514 Offset: 0x1831514 VA: 0x1831514 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
    {
		FGALMCADGMO parser = FGALMCADGMO.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		MEEJPBEAKKP[] array = parser.BHOHDFAFCNL;
		for(int i = 0; i < array.Length; i++)
		{
			MNGJPJBCMBH data = new MNGJPJBCMBH();
			data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC_id;
			data.PLALNIIBLOF_en = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE_mver, array[i].PLALNIIBLOF_en, 0);
			data.PDBPFJJCADD_open_at = array[i].PDBPFJJCADD_open_at;
			data.EGBOHDFBAPB_closed_at = array[i].EGBOHDFBAPB_closed_at;
			//UnityEngine.Debug.LogError(data.PPFNGGCBJKC_id+" "+Utility.GetLocalDateTime(data.PDBPFJJCADD_open_at).ToLongDateString()+" "+Utility.GetLocalDateTime(data.EGBOHDFBAPB_closed_at).ToLongDateString());
			// UMO unlock
			data.EGBOHDFBAPB_closed_at = (int)Utility.GetCurrentUnixTime() + 24 * 3600;
			data.KMENGHEAIOC = array[i].KMENGHEAIOC;
			data.JDANEOJCLBB = array[i].JDANEOJCLBB;
			data.CPGFOBNKKBF_CurrencyId = array[i].CPGFOBNKKBF_CurrencyId;
			data.INDDJNMPONH_type = array[i].GBJFNGCDKPM_typ;
			data.JBGEEPFKIGG_val = array[i].JBGEEPFKIGG_val;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
    }

	// // RVA: 0x1831838 Offset: 0x1831838 VA: 0x1831838 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return false;
	}

	// // RVA: 0x1831840 Offset: 0x1831840 VA: 0x1831840 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "HHJHIFJIKAC_BonusVc.CAOGDCBPBAN");
		return 0;
	}
}
