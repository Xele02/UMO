
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
        public int MHFBCINOJEE_Count; // 0xC
        public EKLNMHFCAOI.FKGCBLHOOCL_Category HHACNFODNEF_Category; // 0x10
        public string JDMIKEEIJFP; // 0x14
        public int HMFFHLPNMPH; // 0x18
        public int DJJGNDCMNHF_BonusCount; // 0x1C
        public int LIDBKCIMCKE_Rarity; // 0x20
        public bool BAKFIPIFDLE_IsEventRareItem; // 0x24
        public bool PHJHJGDLPED_IsRareItem; // 0x25
        public bool LHEDLDEMPPG_IsNew; // 0x26
        public int JPIPENJGGDD; // 0x28
        public int ONDODHPHOOF; // 0x2C
        public int ABIFFLDIAMM; // 0x30

        // // RVA: 0x17B8CA4 Offset: 0x17B8CA4 VA: 0x17B8CA4
        // public string LDBPEIMINJB() { }
    }

	public List<MOLKENLNCPE_DropData.CEFIOPJKEIC> HBHMAKNGKFK = new List<CEFIOPJKEIC>(8); // 0x8
	public int POPPPGMKOHN_EventRareItemNum; // 0xC
	public int ELKAMCOPCDO_EventRareItemNum; // 0x10
	public int MFNCONLNBPB_RareItemNum; // 0x14
	public int OOEFNNNFOLF_NormalItemNum; // 0x18
	public ResultScoreRank.Type DCBDCHPKLCN_Rank; // 0x1C
	public float JKLNANHPJLO; // 0x20
	public int MJBODMOLOBC_Luck; // 0x24
	public int PBIHLJKLHGJ_UCNumber; // 0x28
	public int ADHABBGDFPK; // 0x2C

	// // RVA: 0x17B8400 Offset: 0x17B8400 VA: 0x17B8400
	public void KHEKNNFCAOI()
    {
		MessageBank bk = MessageManager.Instance.GetBank("master");
		MJBODMOLOBC_Luck = JGEOBNENMAH.HHCJCDFCLOB.IKBLCEFCGDE_LastLuck;
		PBIHLJKLHGJ_UCNumber = JGEOBNENMAH.HHCJCDFCLOB.MJKFDDKLLFP_LastDropUnionCredit + JGEOBNENMAH.HHCJCDFCLOB.NMDKKAAOIOI_LastBaseUnionCredit;
		ADHABBGDFPK = JGEOBNENMAH.HHCJCDFCLOB.MJKFDDKLLFP_LastDropUnionCredit;
		DCBDCHPKLCN_Rank = (ResultScoreRank.Type)JGEOBNENMAH.HHCJCDFCLOB.PENICOGGNLF;
		POPPPGMKOHN_EventRareItemNum = 0;
		ELKAMCOPCDO_EventRareItemNum = 0;
		MFNCONLNBPB_RareItemNum = 0;
		OOEFNNNFOLF_NormalItemNum = 0;
		for (int i = 0; i < JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG.Count; i++)
		{
			CEFIOPJKEIC data = new CEFIOPJKEIC();
			data.KIJAPOFAGPN_ItemId = JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].KIJAPOFAGPN_ItemId;
			data.MHFBCINOJEE_Count = EKLNMHFCAOI.DEACAHNLMNI_getItemId(data.KIJAPOFAGPN_ItemId);
			data.HHACNFODNEF_Category = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(data.KIJAPOFAGPN_ItemId);
			data.JDMIKEEIJFP = bk.GetMessageByLabel(EKLNMHFCAOI.FKMCHHDOAAB(data.KIJAPOFAGPN_ItemId));
			data.PHJHJGDLPED_IsRareItem = JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].PHJHJGDLPED;
			data.BAKFIPIFDLE_IsEventRareItem = JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].BAKFIPIFDLE;
			data.LIDBKCIMCKE_Rarity = EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(data.HHACNFODNEF_Category, data.MHFBCINOJEE_Count);
			data.JPIPENJGGDD = JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].JPIPENJGGDD;
			data.ONDODHPHOOF = JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].ONDODHPHOOF;
			data.ABIFFLDIAMM = JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].ABIFFLDIAMM;
			data.LHEDLDEMPPG_IsNew = JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].LHEDLDEMPPG;
			data.HMFFHLPNMPH = JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].OMAJOEOOAJJ_Cnt;
			data.DJJGNDCMNHF_BonusCount = JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].HMFFHLPNMPH - JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].OMAJOEOOAJJ_Cnt;
			if(!data.PHJHJGDLPED_IsRareItem)
			{
				if (!data.BAKFIPIFDLE_IsEventRareItem)
					OOEFNNNFOLF_NormalItemNum += JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].OMAJOEOOAJJ_Cnt;
				else
					ELKAMCOPCDO_EventRareItemNum += JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].OMAJOEOOAJJ_Cnt;
			}
			else
			{
				MFNCONLNBPB_RareItemNum += JGEOBNENMAH.HHCJCDFCLOB.DCELMKFJHPG[i].OMAJOEOOAJJ_Cnt;
			}
			HBHMAKNGKFK.Add(data);
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
