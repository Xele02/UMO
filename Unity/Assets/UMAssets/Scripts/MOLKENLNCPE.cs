
using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;

[System.Obsolete("Use MOLKENLNCPE_DropData", true)]
public class MOLKENLNCPE { }
public class MOLKENLNCPE_DropData
{
    public class CEFIOPJKEIC
    {
        public int KIJAPOFAGPN_ItemId; // 0x8
        public int MHFBCINOJEE_Num; // 0xC
        public EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category HHACNFODNEF_ItemCategory; // 0x10
        public string JDMIKEEIJFP; // 0x14
        public int HMFFHLPNMPH_count; // 0x18
        public int DJJGNDCMNHF_BonusValue; // 0x1C
        public int LIDBKCIMCKE_rarity; // 0x20
        public bool BAKFIPIFDLE_IsEventRareItem; // 0x24
        public bool PHJHJGDLPED_IsRareDrop; // 0x25
        public bool LHEDLDEMPPG_IsNew; // 0x26
        public int JPIPENJGGDD_NumBoard; // 0x28
        public int ONDODHPHOOF_ConvertItemId; // 0x2C
        public int ABIFFLDIAMM_ConvertItemCount; // 0x30

        // // RVA: 0x17B8CA4 Offset: 0x17B8CA4 VA: 0x17B8CA4
        // public string LDBPEIMINJB() { }
    }

	public List<MOLKENLNCPE_DropData.CEFIOPJKEIC> HBHMAKNGKFK_items = new List<CEFIOPJKEIC>(8); // 0x8
	public int POPPPGMKOHN_EventRareItemNum; // 0xC
	public int ELKAMCOPCDO_EventRareItemNum; // 0x10
	public int MFNCONLNBPB_Rare; // 0x14
	public int OOEFNNNFOLF_Nomal; // 0x18
	public ResultScoreRank.Type DCBDCHPKLCN_Rank; // 0x1C
	public float JKLNANHPJLO_ScorePoint; // 0x20
	public int MJBODMOLOBC_luck; // 0x24
	public int PBIHLJKLHGJ_UCNumber; // 0x28
	public int ADHABBGDFPK; // 0x2C

	// // RVA: 0x17B8400 Offset: 0x17B8400 VA: 0x17B8400
	public void KHEKNNFCAOI_Init()
    {
		MessageBank bk = MessageManager.Instance.GetBank("master");
		MJBODMOLOBC_luck = JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.IKBLCEFCGDE_LastLuck;
		PBIHLJKLHGJ_UCNumber = JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.MJKFDDKLLFP_DropUnionCredit + JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.NMDKKAAOIOI_BaseUnionCredit;
		ADHABBGDFPK = JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.MJKFDDKLLFP_DropUnionCredit;
		DCBDCHPKLCN_Rank = (ResultScoreRank.Type)JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.PENICOGGNLF_ScoreRank;
		POPPPGMKOHN_EventRareItemNum = 0;
		ELKAMCOPCDO_EventRareItemNum = 0;
		MFNCONLNBPB_Rare = 0;
		OOEFNNNFOLF_Nomal = 0;
		for (int i = 0; i < JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.DCELMKFJHPG.Count; i++)
		{
			CEFIOPJKEIC data = new CEFIOPJKEIC();
			data.KIJAPOFAGPN_ItemId = JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.DCELMKFJHPG[i].KIJAPOFAGPN_ItemId;
			data.MHFBCINOJEE_Num = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(data.KIJAPOFAGPN_ItemId);
			data.HHACNFODNEF_ItemCategory = EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(data.KIJAPOFAGPN_ItemId);
			data.JDMIKEEIJFP = bk.GetMessageByLabel(EKLNMHFCAOI_ItemManager.FKMCHHDOAAB(data.KIJAPOFAGPN_ItemId));
			data.PHJHJGDLPED_IsRareDrop = JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.DCELMKFJHPG[i].PHJHJGDLPED_IsRareDrop;
			data.BAKFIPIFDLE_IsEventRareItem = JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.DCELMKFJHPG[i].BAKFIPIFDLE_IsEventRareItem;
			data.LIDBKCIMCKE_rarity = EKLNMHFCAOI_ItemManager.FABCKNDLPDH_GetItemRarity(data.HHACNFODNEF_ItemCategory, data.MHFBCINOJEE_Num);
			data.JPIPENJGGDD_NumBoard = JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.DCELMKFJHPG[i].JPIPENJGGDD_NumBoard;
			data.ONDODHPHOOF_ConvertItemId = JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.DCELMKFJHPG[i].ONDODHPHOOF_ConvertItemId;
			data.ABIFFLDIAMM_ConvertItemCount = JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.DCELMKFJHPG[i].ABIFFLDIAMM_ConvertItemCount;
			data.LHEDLDEMPPG_IsNew = JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.DCELMKFJHPG[i].LHEDLDEMPPG_IsNew;
			data.HMFFHLPNMPH_count = JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.DCELMKFJHPG[i].OMAJOEOOAJJ_Count0;
			data.DJJGNDCMNHF_BonusValue = JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.DCELMKFJHPG[i].HMFFHLPNMPH_count - JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.DCELMKFJHPG[i].OMAJOEOOAJJ_Count0;
			if(!data.PHJHJGDLPED_IsRareDrop)
			{
				if (!data.BAKFIPIFDLE_IsEventRareItem)
					OOEFNNNFOLF_Nomal += JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.DCELMKFJHPG[i].OMAJOEOOAJJ_Count0;
				else
					ELKAMCOPCDO_EventRareItemNum += JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.DCELMKFJHPG[i].OMAJOEOOAJJ_Count0;
			}
			else
			{
				MFNCONLNBPB_Rare += JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.DCELMKFJHPG[i].OMAJOEOOAJJ_Count0;
			}
			HBHMAKNGKFK_items.Add(data);
		}
		if(ELKAMCOPCDO_EventRareItemNum > 0)
		{
			POPPPGMKOHN_EventRareItemNum = 1;
			if(Database.Instance.gameSetup.EnableLiveSkip && Database.Instance.gameSetup.LiveSkipTicketCount > 1)
			{
				POPPPGMKOHN_EventRareItemNum *= Database.Instance.gameSetup.LiveSkipTicketCount;
			}
		}
	}

	// // RVA: 0x17B88C8 Offset: 0x17B88C8 VA: 0x17B88C8
	// public string LDBPEIMINJB() { }
}
