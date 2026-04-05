
using System.Collections.Generic;

public class EJFIKLONGDD
{
    public enum BLLOINEKDLM_UnlockType
    {
        HJNNKCMLGFL_0_None = 0,
        JLHALLNOHBA_1_Vc = 1,
        CIGDJNPNJAM_2_Scene5 = 2,
        AFPDIEJNMIB_3_Scene4 = 3,
        FKADJNIGFHB_4_Scene3 = 4,
        FBKFCCCACGE_5_EpiItem = 5,
        KODIFHOOOEC_6_LimitOver = 6,
        AEFCOHJBLPO_7_Num = 7,
    }

	public BLLOINEKDLM_UnlockType PEEAGFNOFFO_UnlockType; // 0x8
	public int LIOEOPGDBJK_Received; // 0xC
	public int MCJBEJBMJMF_Total; // 0x10

	// // RVA: 0x12EC23C Offset: 0x12EC23C VA: 0x12EC23C
	public void KHEKNNFCAOI_Init(List<IHAEIOAKEMG> NNDGIAEFMOG, BLLOINEKDLM_UnlockType _INDDJNMPONH_type)
    {
        PEEAGFNOFFO_UnlockType = _INDDJNMPONH_type;
        LIOEOPGDBJK_Received = 0;
        MCJBEJBMJMF_Total = 0;
        for(int i = 0; i < NNDGIAEFMOG.Count; i++)
        {
            for(int j = 0; j < NNDGIAEFMOG[i].HBHMAKNGKFK_items.Count; j++)
            {
                switch(NNDGIAEFMOG[i].HBHMAKNGKFK_items[j].NPPNDDMPFJJ_ItemCategory)
                {
                    case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC:
                    {
                        if(_INDDJNMPONH_type == BLLOINEKDLM_UnlockType.JLHALLNOHBA_1_Vc)
                        {
                            if(NNDGIAEFMOG[i].HMEOAKCLKJE_IsReceived)
                            {
                                LIOEOPGDBJK_Received += NNDGIAEFMOG[i].HBHMAKNGKFK_items[j].MBJIFDBEDAC_item_count;
                            }
                            MCJBEJBMJMF_Total += NNDGIAEFMOG[i].HBHMAKNGKFK_items[j].MBJIFDBEDAC_item_count;
                        }
                    }
                    break;
                    case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene:
                    {
                        if(_INDDJNMPONH_type == BLLOINEKDLM_UnlockType.FKADJNIGFHB_4_Scene3)
                        {
                            if(EKLNMHFCAOI_ItemManager.FABCKNDLPDH_GetItemRarity(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene, NNDGIAEFMOG[i].HBHMAKNGKFK_items[j].NNFNGLJOKKF_ItemId) == 3)
                            {
                                if(NNDGIAEFMOG[i].HMEOAKCLKJE_IsReceived)
                                {
                                    LIOEOPGDBJK_Received += NNDGIAEFMOG[i].HBHMAKNGKFK_items[j].MBJIFDBEDAC_item_count;
                                }
                                MCJBEJBMJMF_Total += NNDGIAEFMOG[i].HBHMAKNGKFK_items[j].MBJIFDBEDAC_item_count;
                            }
                        }
                        else if(_INDDJNMPONH_type == BLLOINEKDLM_UnlockType.AFPDIEJNMIB_3_Scene4)
                        {
                            if(EKLNMHFCAOI_ItemManager.FABCKNDLPDH_GetItemRarity(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene, NNDGIAEFMOG[i].HBHMAKNGKFK_items[j].NNFNGLJOKKF_ItemId) == 4)
                            {
                                if(NNDGIAEFMOG[i].HMEOAKCLKJE_IsReceived)
                                {
                                    LIOEOPGDBJK_Received += NNDGIAEFMOG[i].HBHMAKNGKFK_items[j].MBJIFDBEDAC_item_count;
                                }
                                MCJBEJBMJMF_Total += NNDGIAEFMOG[i].HBHMAKNGKFK_items[j].MBJIFDBEDAC_item_count;
                            }
                        }
                        else if(_INDDJNMPONH_type == BLLOINEKDLM_UnlockType.CIGDJNPNJAM_2_Scene5)
                        {
                            if(EKLNMHFCAOI_ItemManager.FABCKNDLPDH_GetItemRarity(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene, NNDGIAEFMOG[i].HBHMAKNGKFK_items[j].NNFNGLJOKKF_ItemId) == 5)
                            {
                                if(NNDGIAEFMOG[i].HMEOAKCLKJE_IsReceived)
                                {
                                    LIOEOPGDBJK_Received += NNDGIAEFMOG[i].HBHMAKNGKFK_items[j].MBJIFDBEDAC_item_count;
                                }
                                MCJBEJBMJMF_Total += NNDGIAEFMOG[i].HBHMAKNGKFK_items[j].MBJIFDBEDAC_item_count;
                            }
                        }
                    }
                    break;
                    case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem:
                    {
                        if(_INDDJNMPONH_type == BLLOINEKDLM_UnlockType.KODIFHOOOEC_6_LimitOver && NNDGIAEFMOG[i].HBHMAKNGKFK_items[j].NNFNGLJOKKF_ItemId == 25)
                        {
                            if(NNDGIAEFMOG[i].HMEOAKCLKJE_IsReceived)
                            {
                                LIOEOPGDBJK_Received += NNDGIAEFMOG[i].HBHMAKNGKFK_items[j].MBJIFDBEDAC_item_count;
                            }
                            MCJBEJBMJMF_Total += NNDGIAEFMOG[i].HBHMAKNGKFK_items[j].MBJIFDBEDAC_item_count;
                        }
                    }
                    break;
                    case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem:
                    {
                        if(_INDDJNMPONH_type == BLLOINEKDLM_UnlockType.FBKFCCCACGE_5_EpiItem && NNDGIAEFMOG[i].HBHMAKNGKFK_items[j].NNFNGLJOKKF_ItemId == 2)
                        {
                            if(NNDGIAEFMOG[i].HMEOAKCLKJE_IsReceived)
                            {
                                LIOEOPGDBJK_Received += NNDGIAEFMOG[i].HBHMAKNGKFK_items[j].MBJIFDBEDAC_item_count;
                            }
                            MCJBEJBMJMF_Total += NNDGIAEFMOG[i].HBHMAKNGKFK_items[j].MBJIFDBEDAC_item_count;
                        }
                    }
                    break;
                }
            }
        }
    }

	// // RVA: 0x12EDEFC Offset: 0x12EDEFC VA: 0x12EDEFC
	public static List<EJFIKLONGDD> FKDIMODKKJD_GetList(List<IHAEIOAKEMG> NNDGIAEFMOG, string _CNLJNGLMMHB_Options)
    {
        List<EJFIKLONGDD> res = new List<EJFIKLONGDD>();
        if(NNDGIAEFMOG != null)
        {
            string[] strs = _CNLJNGLMMHB_Options.Split(new char[] { ',' });
            for(int i = 0; i < strs.Length; i++)
            {
                if(strs[i] == "vc")
                {
                    EJFIKLONGDD data = new EJFIKLONGDD();
                    data.KHEKNNFCAOI_Init(NNDGIAEFMOG, BLLOINEKDLM_UnlockType.JLHALLNOHBA_1_Vc);
                    res.Add(data);
                }
                else if(strs[i] == "scene_5")
                {
                    EJFIKLONGDD data = new EJFIKLONGDD();
                    data.KHEKNNFCAOI_Init(NNDGIAEFMOG, BLLOINEKDLM_UnlockType.CIGDJNPNJAM_2_Scene5);
                    res.Add(data);
                }
                else if(strs[i] == "scene_4")
                {
                    EJFIKLONGDD data = new EJFIKLONGDD();
                    data.KHEKNNFCAOI_Init(NNDGIAEFMOG, BLLOINEKDLM_UnlockType.AFPDIEJNMIB_3_Scene4);
                    res.Add(data);
                }
                else if(strs[i] == "scene_3")
                {
                    EJFIKLONGDD data = new EJFIKLONGDD();
                    data.KHEKNNFCAOI_Init(NNDGIAEFMOG, BLLOINEKDLM_UnlockType.FKADJNIGFHB_4_Scene3);
                    res.Add(data);
                }
                else if(strs[i] == "epi_item")
                {
                    EJFIKLONGDD data = new EJFIKLONGDD();
                    data.KHEKNNFCAOI_Init(NNDGIAEFMOG, BLLOINEKDLM_UnlockType.FBKFCCCACGE_5_EpiItem);
                    res.Add(data);
                }
                else if(strs[i] == "limitover")
                {
                    EJFIKLONGDD data = new EJFIKLONGDD();
                    data.KHEKNNFCAOI_Init(NNDGIAEFMOG, BLLOINEKDLM_UnlockType.KODIFHOOOEC_6_LimitOver);
                    res.Add(data);
                }
            }
        }
        return res;
    }
}
