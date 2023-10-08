
using System.Collections.Generic;
using System.Data.Common;

internal static class IPJMBAHBHCE
{

	// // RVA: 0x14107EC Offset: 0x14107EC VA: 0x14107EC
	// public static KDKFHGHGFEK JOMFJINODPE(int NIDAEHBPENE) { }

	// RVA: 0x14108CC Offset: 0x14108CC VA: 0x14108CC
	public static int IMGACNAHGDL(int NIDAEHBPENE)
    {
        return NIDAEHBPENE;
    }
}

public class JFOBOMOMENL
{
	// // RVA: 0x1C45150 Offset: 0x1C45150 VA: 0x1C45150
	public static bool KIAFJHJMBFN()
    {
        List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> l1 = new List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD>();
        List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> l2 = new List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD>();
        List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> l3 = new List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD>();
        List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> l4 = new List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD>();
        List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> l5 = new List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD>();
        BBHNACPENDM_ServerSaveData serverSave = CIOECGOMILE.HHCJCDFCLOB.LGBMDHOLOIF.AHEFHIMGIBI;
        AOFAHDGAMKH(serverSave.PDKHANKAPCI_DecoPublicSet, l1, l2, l3, l4, l5, serverSave.OBDEIEHEPHC_DecoPublicInfo.DGNMOIBJBBJ_HasEnabled);
        List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> l7 = new List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD>();
        l7.AddRange(l1);
        l7.AddRange(l2);
        l7.AddRange(l3);
        l7.AddRange(l4);
        l7.AddRange(l5);
        int a = 1;
        for(int i = 0; i < l7.Count; i++)
        {
            EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(l7[i].KIJAPOFAGPN_ItemId);
            int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(l7[i].KIJAPOFAGPN_ItemId);
            if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara || 
                cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg)
            {
                if(EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, cat, id, null) != 0)
                {
                    a &= 1;
                }
            }
        }
        if(a == 0)
        {
            serverSave.OBDEIEHEPHC_DecoPublicInfo.DGNMOIBJBBJ_HasEnabled = true;
            JKNGJFOBADP data = new JKNGJFOBADP();
            for(int i = 0; i < l7.Count; i++)
            {
                EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(l7[i].KIJAPOFAGPN_ItemId);
                int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(l7[i].KIJAPOFAGPN_ItemId);
                if (EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, cat, id, null) < 1)
                {
                    data.CPIICACGNBH(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, cat, id, 1, null, 0);
                }
            }
            return true;
        }
        else
        {
            if(!serverSave.OBDEIEHEPHC_DecoPublicInfo.DGNMOIBJBBJ_HasEnabled)
            {
                serverSave.OBDEIEHEPHC_DecoPublicInfo.DGNMOIBJBBJ_HasEnabled = true;
                return true;
            }
            return false;
        }
    }

	// // RVA: 0x1C458C0 Offset: 0x1C458C0 VA: 0x1C458C0
	public static bool AOFAHDGAMKH(DAJBODHMLAB_DecoPublicSet PDKHANKAPCI, List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> CBBLAMDGOGK, List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> LMNBBOIJBBL, List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> MBAMIOJNGBD, List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> OFGHDIFGIPK, List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> PIPCIMIALOO, bool OELFMOMMPMC = false)
    {
        if(CBBLAMDGOGK == null)
            CBBLAMDGOGK = new List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD>();
        if(LMNBBOIJBBL == null)
            LMNBBOIJBBL = new List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD>();
        if(MBAMIOJNGBD == null)
            MBAMIOJNGBD = new List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD>();
        if(OFGHDIFGIPK == null)
            OFGHDIFGIPK = new List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD>();
        if(PIPCIMIALOO == null)
            PIPCIMIALOO = new List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD>();
        foreach(var c in IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.CIGBHCHOPEO_DecoItemInit.CDENCMNHNGA)
        {
            switch(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(c.KIJAPOFAGPN_ItemId))
            {
                case EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg:
                    CBBLAMDGOGK.Add(c);
                    break;
                case EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
                    LMNBBOIJBBL.Add(c);
                    break;
                case EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
                    MBAMIOJNGBD.Add(c);
                    break;
                case EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif:
                    OFGHDIFGIPK.Add(c);
                    break;
                case EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp:
                    PIPCIMIALOO.Add(c);
                    break;
            }
        }
        if(!OELFMOMMPMC)
            MBFFGGFGPEN(PDKHANKAPCI, CBBLAMDGOGK, LMNBBOIJBBL, MBAMIOJNGBD, OFGHDIFGIPK, PIPCIMIALOO);
        return true;
    }

	// // RVA: 0x1C45DB0 Offset: 0x1C45DB0 VA: 0x1C45DB0
	private static void MBFFGGFGPEN(DAJBODHMLAB_DecoPublicSet PDKHANKAPCI, List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> CBBLAMDGOGK, List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> LMNBBOIJBBL, List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> MBAMIOJNGBD, List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> OFGHDIFGIPK, List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> PIPCIMIALOO)
    {
        foreach(var c in CBBLAMDGOGK)
        {
            if(c.OPAHFDJPFJO_Placing)
            {
                KDKFHGHGFEK data = new KDKFHGHGFEK();
                data.KHEKNNFCAOI(EKLNMHFCAOI.DEACAHNLMNI_getItemId(c.KIJAPOFAGPN_ItemId), EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg);
                PDKHANKAPCI.LJMCPFACDGJ.KIDHLCNFCKN_FloorId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg, EKLNMHFCAOI.DEACAHNLMNI_getItemId(c.KIJAPOFAGPN_ItemId));
                PDKHANKAPCI.LJMCPFACDGJ.DJCJMCHMIMA_WallLId = PDKHANKAPCI.LJMCPFACDGJ.KIDHLCNFCKN_FloorId;
                PDKHANKAPCI.LJMCPFACDGJ.KCMEAABOIOA_WallRId = PDKHANKAPCI.LJMCPFACDGJ.KIDHLCNFCKN_FloorId;
            }
        }
        foreach(var c in LMNBBOIJBBL)
        {
            if(c.OPAHFDJPFJO_Placing)
            {
                MBFFGGFGPEN(PDKHANKAPCI, c, 0);
            }
        }
        foreach(var c in MBAMIOJNGBD)
        {
            if(c.OPAHFDJPFJO_Placing)
            {
                MBFFGGFGPEN(PDKHANKAPCI, c, 0);
            }
        }
        foreach(var c in PIPCIMIALOO)
        {
            if(c.OPAHFDJPFJO_Placing)
            {
                MBFFGGFGPEN(PDKHANKAPCI, c, 0);
            }
        }
    }

	// // RVA: 0x1C46458 Offset: 0x1C46458 VA: 0x1C46458
	private static void MBFFGGFGPEN(DAJBODHMLAB_DecoPublicSet PDKHANKAPCI, JEPMHCPBIGD_DecoItemInit.MPIILICCLDD IDLHJIOMJBK, EKLNMHFCAOI.FKGCBLHOOCL_Category NPADACLCNAN)
    {
        DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD a = PDKHANKAPCI.LJMCPFACDGJ.HBHMAKNGKFK_Items.Find((DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD AIHOJKFNEEN) =>
        {
            //0x1C46754
            return !AIHOJKFNEEN.IEDNAKOJNDE;
        });
        if(a == null)
            return;
        a.HAJKNHNAIKL_ItemId = IPJMBAHBHCE.IMGACNAHGDL(IDLHJIOMJBK.KIJAPOFAGPN_ItemId);
        a.GHPLINIACBB_PosX = IDLHJIOMJBK.FBNCFENGOOD_PosX;
        a.PMBEODGMMBB_PosY = IDLHJIOMJBK.LOEJKNILJKF_PosY;
        a.BDEEIPPDCLE_Rvs = IDLHJIOMJBK.NEGMFBPNJGK_Rvs;
        a.BNHOEFJAAKK_Prio = IDLHJIOMJBK.DAPGDCPDCNA_Prio;
        a.BEJGNPAAKNB_Word = IPJMBAHBHCE.IMGACNAHGDL(IDLHJIOMJBK.BEJGNPAAKNB_Word);
        a.PMIPFEJFIHA_StatusFlag = 0;
    }
}
