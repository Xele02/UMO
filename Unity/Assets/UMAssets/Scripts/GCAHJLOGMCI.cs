
public class GCAHJLOGMCI
{
	public enum KNMMOMEHDON_GachaType
	{
		HJNNKCMLGFL_0_None = 0,
		CCAPCGPIIPF_1_Daily = 1,
		PHABJLGFJNI_2_Regular = 2,
		GENEIBGNMPH_3 = 3,
		JGDEHOGIENP_4 = 4,
		GKDFKDLFNAJ_5_LimitedTicket1 = 5,
		BKNHBNINDOC_6_LimitedTicket2 = 6,
		ANFKBNLLJFN_7 = 7,
		BCBJMKDAAKA_8_StepUp = 8,
		OOABDNHIEFK_9 = 9,
		DLOPEFGOAPD_10_PassGacha = 10,
		AEFCOHJBLPO_11 = 11,
	}

	public enum NFCAJPIJFAM_SummonType
	{
		HJNNKCMLGFL_0_None = 0,
		AIMPCCIHKAJ_1 = 1,
		DIHBOGEPHFI_2 = 2,
		ODDGKAKAGLE_3 = 3,
		AKHEAGMMIAM_4 = 4,
		GOAHICNDICO_5 = 5,
		LMHDFEKIDKG_6 = 6,
		OBLEFFEJGIJ_8 = 8,
		NGAHKKOBGPA_9 = 9,
		BPPLDIBMPKH_10 = 10,
		AEFCOHJBLPO_11 = 11,
	}

	private const int KBAHKEAEDEJ = 1000000;
	private const int HHOIIDMKCIG = 10;

	//// RVA: 0x16A9698 Offset: 0x16A9698 VA: 0x16A9698
	public static KNMMOMEHDON_GachaType OLMFIANJBOB_GetGachaType(int _KAPMOPMDHJE_label)
	{
		return (KNMMOMEHDON_GachaType)((_KAPMOPMDHJE_label / 1000000) % 100);
	}

	//// RVA: 0x16A96CC Offset: 0x16A96CC VA: 0x16A96CC
	public static int GPAJHMLOPNP_GetGachaId(int _KAPMOPMDHJE_label)
	{
		return (_KAPMOPMDHJE_label % 1000000) / 100;
	}

	//// RVA: 0x16A9704 Offset: 0x16A9704 VA: 0x16A9704
	//public static int AIAOCEGMOJP(int _KAPMOPMDHJE_label) { }

	//// RVA: 0x16A971C Offset: 0x16A971C VA: 0x16A971C
	public static int BDJDDKBCHKO(int _KAPMOPMDHJE_label)
	{
		return (_KAPMOPMDHJE_label / 10) % 10;
	}

	//// RVA: 0x16A9748 Offset: 0x16A9748 VA: 0x16A9748
	public static NFCAJPIJFAM_SummonType HHFLDFFJICJ_GetGachaSummonType(int _KAPMOPMDHJE_label)
	{
		return (NFCAJPIJFAM_SummonType)(_KAPMOPMDHJE_label % 10);
	}

	//// RVA: 0x16A9768 Offset: 0x16A9768 VA: 0x16A9768
	public static long PMBGPACNPIN(KNMMOMEHDON_GachaType _INDDJNMPONH_type, string _OPFGFINHFCE_name, long _KJBGCLPMLCG_OpenedAt, long NMPMNPLGIEL/* = 0*/)
	{
		if(_INDDJNMPONH_type != KNMMOMEHDON_GachaType.CCAPCGPIIPF_1_Daily/*1*/ && _INDDJNMPONH_type != KNMMOMEHDON_GachaType.ANFKBNLLJFN_7/*7*/)
		{
			if(_INDDJNMPONH_type == KNMMOMEHDON_GachaType.GENEIBGNMPH_3)
			{
				if(_OPFGFINHFCE_name.Contains(JpStringLiterals.StringLiteral_10431_Jp))
				{
					NMPMNPLGIEL = 0;
					TodoLogger.LogError(TodoLogger.ToCheck, "PMBGPACNPIN values "+_INDDJNMPONH_type+" "+_OPFGFINHFCE_name+" "+_KJBGCLPMLCG_OpenedAt+" "+NMPMNPLGIEL+" "+(NMPMNPLGIEL | _KJBGCLPMLCG_OpenedAt | (0xff0000 << 32)));
					return NMPMNPLGIEL | _KJBGCLPMLCG_OpenedAt | (0xff0000 << 32);
				}
			}
			if(NMPMNPLGIEL != 0)
			{
				TodoLogger.LogError(TodoLogger.ToCheck, "PMBGPACNPIN values"+_INDDJNMPONH_type+" "+_OPFGFINHFCE_name+" "+_KJBGCLPMLCG_OpenedAt+" "+NMPMNPLGIEL+" "+(NMPMNPLGIEL | _KJBGCLPMLCG_OpenedAt));
				return NMPMNPLGIEL | _KJBGCLPMLCG_OpenedAt;
			}
			long val = 0;
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.IOIDJALFFJA_GachaSortPriority.TryGetValue((int)_INDDJNMPONH_type, out val))
			{
				TodoLogger.LogError(TodoLogger.ToCheck, "PMBGPACNPIN values"+_INDDJNMPONH_type+" "+_OPFGFINHFCE_name+" "+_KJBGCLPMLCG_OpenedAt+" "+NMPMNPLGIEL+" "+(val | _KJBGCLPMLCG_OpenedAt));
				return val | _KJBGCLPMLCG_OpenedAt;
			}
		}
		NMPMNPLGIEL = 0;
		TodoLogger.LogError(TodoLogger.ToCheck, "PMBGPACNPIN values"+_INDDJNMPONH_type+" "+_OPFGFINHFCE_name+" "+_KJBGCLPMLCG_OpenedAt+" "+NMPMNPLGIEL+" "+(NMPMNPLGIEL | _KJBGCLPMLCG_OpenedAt));
		return NMPMNPLGIEL | _KJBGCLPMLCG_OpenedAt;
	}
}
