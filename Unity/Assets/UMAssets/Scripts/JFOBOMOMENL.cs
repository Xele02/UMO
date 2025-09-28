
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
        BBHNACPENDM_ServerSaveData serverSave = CIOECGOMILE.HHCJCDFCLOB.LGBMDHOLOIF_decoPlayerData.AHEFHIMGIBI_PlayerData;
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
                if(EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, cat, id, null) == 0)
                {
                    a = 0;
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
                if (EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, cat, id, null) < 1)
                {
                    data.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, cat, id, 1, null, 0);
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
	public static bool AOFAHDGAMKH(DAJBODHMLAB_DecoPublicSet _PDKHANKAPCI_DecoPublicSet, List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> _CBBLAMDGOGK_bg, List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> _LMNBBOIJBBL_obj, List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> _MBAMIOJNGBD_ch, List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> OFGHDIFGIPK, List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> _PIPCIMIALOO_sp, bool OELFMOMMPMC/* = false*/)
    {
        if(_CBBLAMDGOGK_bg == null)
            _CBBLAMDGOGK_bg = new List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD>();
        if(_LMNBBOIJBBL_obj == null)
            _LMNBBOIJBBL_obj = new List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD>();
        if(_MBAMIOJNGBD_ch == null)
            _MBAMIOJNGBD_ch = new List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD>();
        if(OFGHDIFGIPK == null)
            OFGHDIFGIPK = new List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD>();
        if(_PIPCIMIALOO_sp == null)
            _PIPCIMIALOO_sp = new List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD>();
        foreach(var c in IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.CIGBHCHOPEO_DecoItemInit.CDENCMNHNGA_table)
        {
            switch(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(c.KIJAPOFAGPN_ItemId))
            {
                case EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg:
                    _CBBLAMDGOGK_bg.Add(c);
                    break;
                case EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
                    _LMNBBOIJBBL_obj.Add(c);
                    break;
                case EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
                    _MBAMIOJNGBD_ch.Add(c);
                    break;
                case EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif:
                    OFGHDIFGIPK.Add(c);
                    break;
                case EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp:
                    _PIPCIMIALOO_sp.Add(c);
                    break;
            }
        }
        if(!OELFMOMMPMC)
            MBFFGGFGPEN(_PDKHANKAPCI_DecoPublicSet, _CBBLAMDGOGK_bg, _LMNBBOIJBBL_obj, _MBAMIOJNGBD_ch, OFGHDIFGIPK, _PIPCIMIALOO_sp);
        return true;
    }

	// // RVA: 0x1C45DB0 Offset: 0x1C45DB0 VA: 0x1C45DB0
	private static void MBFFGGFGPEN(DAJBODHMLAB_DecoPublicSet _PDKHANKAPCI_DecoPublicSet, List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> _CBBLAMDGOGK_bg, List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> _LMNBBOIJBBL_obj, List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> _MBAMIOJNGBD_ch, List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> OFGHDIFGIPK, List<JEPMHCPBIGD_DecoItemInit.MPIILICCLDD> _PIPCIMIALOO_sp)
    {
        foreach(var c in _CBBLAMDGOGK_bg)
        {
            if(c.OPAHFDJPFJO_placing)
            {
                KDKFHGHGFEK data = new KDKFHGHGFEK();
                data.KHEKNNFCAOI_Init(EKLNMHFCAOI.DEACAHNLMNI_getItemId(c.KIJAPOFAGPN_ItemId), EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg);
                _PDKHANKAPCI_DecoPublicSet.LJMCPFACDGJ.KIDHLCNFCKN_FloorId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg, EKLNMHFCAOI.DEACAHNLMNI_getItemId(c.KIJAPOFAGPN_ItemId));
                _PDKHANKAPCI_DecoPublicSet.LJMCPFACDGJ.DJCJMCHMIMA_WallLId = _PDKHANKAPCI_DecoPublicSet.LJMCPFACDGJ.KIDHLCNFCKN_FloorId;
                _PDKHANKAPCI_DecoPublicSet.LJMCPFACDGJ.KCMEAABOIOA_WallRId = _PDKHANKAPCI_DecoPublicSet.LJMCPFACDGJ.KIDHLCNFCKN_FloorId;
            }
        }
        foreach(var c in _LMNBBOIJBBL_obj)
        {
            if(c.OPAHFDJPFJO_placing)
            {
                MBFFGGFGPEN(_PDKHANKAPCI_DecoPublicSet, c, 0);
            }
        }
        foreach(var c in _MBAMIOJNGBD_ch)
        {
            if(c.OPAHFDJPFJO_placing)
            {
                MBFFGGFGPEN(_PDKHANKAPCI_DecoPublicSet, c, 0);
            }
        }
        foreach(var c in _PIPCIMIALOO_sp)
        {
            if(c.OPAHFDJPFJO_placing)
            {
                MBFFGGFGPEN(_PDKHANKAPCI_DecoPublicSet, c, 0);
            }
        }
    }

	// // RVA: 0x1C46458 Offset: 0x1C46458 VA: 0x1C46458
	private static void MBFFGGFGPEN(DAJBODHMLAB_DecoPublicSet _PDKHANKAPCI_DecoPublicSet, JEPMHCPBIGD_DecoItemInit.MPIILICCLDD _IDLHJIOMJBK_data, EKLNMHFCAOI.FKGCBLHOOCL_Category _NPADACLCNAN_Category)
    {
        DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD a = _PDKHANKAPCI_DecoPublicSet.LJMCPFACDGJ.HBHMAKNGKFK_items.Find((DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD _AIHOJKFNEEN_itm) =>
        {
            //0x1C46754
            return !_AIHOJKFNEEN_itm.IEDNAKOJNDE_IsValid;
        });
        if(a == null)
            return;
        a.HAJKNHNAIKL_rsc = IPJMBAHBHCE.IMGACNAHGDL(_IDLHJIOMJBK_data.KIJAPOFAGPN_ItemId);
        a.GHPLINIACBB_x = _IDLHJIOMJBK_data.FBNCFENGOOD_PosX;
        a.PMBEODGMMBB_y = _IDLHJIOMJBK_data.LOEJKNILJKF_PosY;
        a.BDEEIPPDCLE_rvs = _IDLHJIOMJBK_data.NEGMFBPNJGK_rvs;
        a.BNHOEFJAAKK_prio = _IDLHJIOMJBK_data.DAPGDCPDCNA_Prio;
        a.BEJGNPAAKNB_word = IPJMBAHBHCE.IMGACNAHGDL(_IDLHJIOMJBK_data.BEJGNPAAKNB_word);
        a.PMIPFEJFIHA_stat = 0;
    }
}
