
using System.Collections.Generic;

public class EJFIKLONGDD
{
    public enum BLLOINEKDLM
    {
        HJNNKCMLGFL = 0,
        JLHALLNOHBA_1_Vc = 1,
        CIGDJNPNJAM_2_Scene5 = 2,
        AFPDIEJNMIB_3_Scene4 = 3,
        FKADJNIGFHB_4_Scene3 = 4,
        FBKFCCCACGE_5_EpiItem = 5,
        KODIFHOOOEC_6_LimitOver = 6,
        AEFCOHJBLPO = 7,
    }

	public BLLOINEKDLM PEEAGFNOFFO_ItemId; // 0x8
	public int LIOEOPGDBJK_Received; // 0xC
	public int MCJBEJBMJMF_Total; // 0x10

	// // RVA: 0x12EC23C Offset: 0x12EC23C VA: 0x12EC23C
	public void KHEKNNFCAOI(List<IHAEIOAKEMG> NNDGIAEFMOG, BLLOINEKDLM INDDJNMPONH)
    {
        PEEAGFNOFFO_ItemId = INDDJNMPONH;
        LIOEOPGDBJK_Received = 0;
        MCJBEJBMJMF_Total = 0;
        for(int i = 0; i < NNDGIAEFMOG.Count; i++)
        {
            for(int j = 0; j < NNDGIAEFMOG[i].HBHMAKNGKFK_Items.Count; j++)
            {
                switch(NNDGIAEFMOG[i].HBHMAKNGKFK_Items[j].NPPNDDMPFJJ_ItemCategory)
                {
                    case EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC:
                    {
                        if(INDDJNMPONH == BLLOINEKDLM.JLHALLNOHBA_1_Vc)
                        {
                            if(NNDGIAEFMOG[i].HMEOAKCLKJE_IsReceived)
                            {
                                LIOEOPGDBJK_Received += NNDGIAEFMOG[i].HBHMAKNGKFK_Items[j].MBJIFDBEDAC_Cnt;
                            }
                            MCJBEJBMJMF_Total += NNDGIAEFMOG[i].HBHMAKNGKFK_Items[j].MBJIFDBEDAC_Cnt;
                        }
                    }
                    break;
                    case EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene:
                    {
                        if(INDDJNMPONH == BLLOINEKDLM.FKADJNIGFHB_4_Scene3)
                        {
                            if(EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene, NNDGIAEFMOG[i].HBHMAKNGKFK_Items[j].NNFNGLJOKKF_ItemId) == 3)
                            {
                                if(NNDGIAEFMOG[i].HMEOAKCLKJE_IsReceived)
                                {
                                    LIOEOPGDBJK_Received += NNDGIAEFMOG[i].HBHMAKNGKFK_Items[j].MBJIFDBEDAC_Cnt;
                                }
                                MCJBEJBMJMF_Total += NNDGIAEFMOG[i].HBHMAKNGKFK_Items[j].MBJIFDBEDAC_Cnt;
                            }
                        }
                        else if(INDDJNMPONH == BLLOINEKDLM.AFPDIEJNMIB_3_Scene4)
                        {
                            if(EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene, NNDGIAEFMOG[i].HBHMAKNGKFK_Items[j].NNFNGLJOKKF_ItemId) == 4)
                            {
                                if(NNDGIAEFMOG[i].HMEOAKCLKJE_IsReceived)
                                {
                                    LIOEOPGDBJK_Received += NNDGIAEFMOG[i].HBHMAKNGKFK_Items[j].MBJIFDBEDAC_Cnt;
                                }
                                MCJBEJBMJMF_Total += NNDGIAEFMOG[i].HBHMAKNGKFK_Items[j].MBJIFDBEDAC_Cnt;
                            }
                        }
                        else if(INDDJNMPONH == BLLOINEKDLM.CIGDJNPNJAM_2_Scene5)
                        {
                            if(EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene, NNDGIAEFMOG[i].HBHMAKNGKFK_Items[j].NNFNGLJOKKF_ItemId) == 5)
                            {
                                if(NNDGIAEFMOG[i].HMEOAKCLKJE_IsReceived)
                                {
                                    LIOEOPGDBJK_Received += NNDGIAEFMOG[i].HBHMAKNGKFK_Items[j].MBJIFDBEDAC_Cnt;
                                }
                                MCJBEJBMJMF_Total += NNDGIAEFMOG[i].HBHMAKNGKFK_Items[j].MBJIFDBEDAC_Cnt;
                            }
                        }
                    }
                    break;
                    case EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem:
                    {
                        if(INDDJNMPONH == BLLOINEKDLM.KODIFHOOOEC_6_LimitOver && NNDGIAEFMOG[i].HBHMAKNGKFK_Items[j].NNFNGLJOKKF_ItemId == 25)
                        {
                            if(NNDGIAEFMOG[i].HMEOAKCLKJE_IsReceived)
                            {
                                LIOEOPGDBJK_Received += NNDGIAEFMOG[i].HBHMAKNGKFK_Items[j].MBJIFDBEDAC_Cnt;
                            }
                            MCJBEJBMJMF_Total += NNDGIAEFMOG[i].HBHMAKNGKFK_Items[j].MBJIFDBEDAC_Cnt;
                        }
                    }
                    break;
                    case EKLNMHFCAOI.FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem:
                    {
                        if(INDDJNMPONH == BLLOINEKDLM.FBKFCCCACGE_5_EpiItem && NNDGIAEFMOG[i].HBHMAKNGKFK_Items[j].NNFNGLJOKKF_ItemId == 2)
                        {
                            if(NNDGIAEFMOG[i].HMEOAKCLKJE_IsReceived)
                            {
                                LIOEOPGDBJK_Received += NNDGIAEFMOG[i].HBHMAKNGKFK_Items[j].MBJIFDBEDAC_Cnt;
                            }
                            MCJBEJBMJMF_Total += NNDGIAEFMOG[i].HBHMAKNGKFK_Items[j].MBJIFDBEDAC_Cnt;
                        }
                    }
                    break;
                }
            }
        }
    }

	// // RVA: 0x12EDEFC Offset: 0x12EDEFC VA: 0x12EDEFC
	public static List<EJFIKLONGDD> FKDIMODKKJD(List<IHAEIOAKEMG> NNDGIAEFMOG, string CNLJNGLMMHB)
    {
        List<EJFIKLONGDD> res = new List<EJFIKLONGDD>();
        if(NNDGIAEFMOG != null)
        {
            string[] strs = CNLJNGLMMHB.Split(new char[] { ',' });
            for(int i = 0; i < strs.Length; i++)
            {
                if(strs[i] == "vc")
                {
                    EJFIKLONGDD data = new EJFIKLONGDD();
                    data.KHEKNNFCAOI(NNDGIAEFMOG, BLLOINEKDLM.JLHALLNOHBA_1_Vc);
                    res.Add(data);
                }
                else if(strs[i] == "scene_5")
                {
                    EJFIKLONGDD data = new EJFIKLONGDD();
                    data.KHEKNNFCAOI(NNDGIAEFMOG, BLLOINEKDLM.CIGDJNPNJAM_2_Scene5);
                    res.Add(data);
                }
                else if(strs[i] == "scene_4")
                {
                    EJFIKLONGDD data = new EJFIKLONGDD();
                    data.KHEKNNFCAOI(NNDGIAEFMOG, BLLOINEKDLM.AFPDIEJNMIB_3_Scene4);
                    res.Add(data);
                }
                else if(strs[i] == "scene_3")
                {
                    EJFIKLONGDD data = new EJFIKLONGDD();
                    data.KHEKNNFCAOI(NNDGIAEFMOG, BLLOINEKDLM.FKADJNIGFHB_4_Scene3);
                    res.Add(data);
                }
                else if(strs[i] == "epi_item")
                {
                    EJFIKLONGDD data = new EJFIKLONGDD();
                    data.KHEKNNFCAOI(NNDGIAEFMOG, BLLOINEKDLM.FBKFCCCACGE_5_EpiItem);
                    res.Add(data);
                }
                else if(strs[i] == "limitover")
                {
                    EJFIKLONGDD data = new EJFIKLONGDD();
                    data.KHEKNNFCAOI(NNDGIAEFMOG, BLLOINEKDLM.KODIFHOOOEC_6_LimitOver);
                    res.Add(data);
                }
            }
        }
        return res;
    }
}
