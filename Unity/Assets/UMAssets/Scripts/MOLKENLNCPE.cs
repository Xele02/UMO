
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
        public EKLNMHFCAOI.FKGCBLHOOCL_Category HHACNFODNEF_ItemCategory; // 0x10
        public string JDMIKEEIJFP; // 0x14
        public int HMFFHLPNMPH_Count; // 0x18
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

	public List<MOLKENLNCPE_DropData.CEFIOPJKEIC> HBHMAKNGKFK_Items = new List<CEFIOPJKEIC>(8); // 0x8
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
		MJBODMOLOBC_luck = JGEOBNENMAH.HHCJCDFCLOB.IKBLCEFCGDE_LastLuck;
		PBIHLJKLHGJ_UCNumber = JGEOBNENMAH.HHCJCDFCLOB.MJKFDDKLLFP_DropUnionCredit + JGEOBNENMAH.HHCJCDFCLOB.NMDKKAAOIOI_BaseUnionCredit;
		ADHABBGDFPK = JGEOBNENMAH.HHCJCDFCLOB.MJKFDDKLLFP_DropUnionCredit;
		DCBDCHPKLCN_Rank = (ResultScoreRank.Type)JGEOBNENMAH.HHCJCDFCLOB.PENICOGGNLF_ScoreRank;
		POPPPGMKOHN_EventRareItemNum = 0;
		ELKAMCOPCDO_EventRareItemNum = 0;
		MFNCONLNBPB_Rare = 0;
		OOEFNNNFOLF_Nomal = 0;
		for (int i = 0; i < JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG.Count; i++)
		{
			CEFIOPJKEIC data = new CEFIOPJKEIC();
			data.KIJAPOFAGPN_ItemId = JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].KIJAPOFAGPN_ItemId;
			data.MHFBCINOJEE_Num = EKLNMHFCAOI.DEACAHNLMNI_getItemId(data.KIJAPOFAGPN_ItemId);
			data.HHACNFODNEF_ItemCategory = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(data.KIJAPOFAGPN_ItemId);
			data.JDMIKEEIJFP = bk.GetMessageByLabel(EKLNMHFCAOI.FKMCHHDOAAB(data.KIJAPOFAGPN_ItemId));
			data.PHJHJGDLPED_IsRareDrop = JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].PHJHJGDLPED_IsRareDrop;
			data.BAKFIPIFDLE_IsEventRareItem = JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].BAKFIPIFDLE_IsEventRareItem;
			data.LIDBKCIMCKE_rarity = EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(data.HHACNFODNEF_ItemCategory, data.MHFBCINOJEE_Num);
			data.JPIPENJGGDD_NumBoard = JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].JPIPENJGGDD_NumBoard;
			data.ONDODHPHOOF_ConvertItemId = JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].ONDODHPHOOF_ConvertItemId;
			data.ABIFFLDIAMM_ConvertItemCount = JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].ABIFFLDIAMM_ConvertItemCount;
			data.LHEDLDEMPPG_IsNew = JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].LHEDLDEMPPG_IsNew;
			data.HMFFHLPNMPH_Count = JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].OMAJOEOOAJJ_Count0;
			data.DJJGNDCMNHF_BonusValue = JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].HMFFHLPNMPH_Count - JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].OMAJOEOOAJJ_Count0;
			if(!data.PHJHJGDLPED_IsRareDrop)
			{
				if (!data.BAKFIPIFDLE_IsEventRareItem)
					OOEFNNNFOLF_Nomal += JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].OMAJOEOOAJJ_Count0;
				else
					ELKAMCOPCDO_EventRareItemNum += JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].OMAJOEOOAJJ_Count0;
			}
			else
			{
				MFNCONLNBPB_Rare += JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].OMAJOEOOAJJ_Count0;
			}
			HBHMAKNGKFK_Items.Add(data);
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
