using System.Collections.Generic;

public class IBIGBMDANNM
{
	public enum LJJOIIAEICI
	{
		CCAPCGPIIPF_Guest = 0,
		HEEJBCDDOJJ_Friend = 1,
		BGHNFBANAMN = 2,
		FCDDHHKAGEP = 3,
	}
	
	public long AJECHDLMKOE_LastLogin; // 0x10
	public long DHIFKMEFABP; // 0x18
	public LJJOIIAEICI LHMDABPNDDH_Type; // 0x28
	public BBHNACPENDM_ServerSaveData AHEFHIMGIBI_ServerData; // 0x2C
	public bool ONAFFLLLBHE_IsSelf; // 0x30
	public int FJOLNJLLJEJ_Rank; // 0x34
	public long KNIFCANOHOC_Score; // 0x38
	public double HMLEDBJDCAF_PreciseScore; // 0x40

	public int MLPEHNBNOGD_Id { get; set; } // 0x8 OCNCGDJNBIH LJALJLIIODH MKBAMFJNCDK
	public int ADFIHAPELAN_PLevel { get { return AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.KIECDDFNCAN_PLevel; } set { AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.KIECDDFNCAN_PLevel = value; } } //0x121255C NBALCMLLJGJ 0x12125A8 CPMNIMFDFAM
	public string LBODHBDOMGK { get { return AHEFHIMGIBI_ServerData.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName; } set { AHEFHIMGIBI_ServerData.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName = value; } }// 0x12125FC JLFIGDAGIEB 0x1212648 KMHENDLDBEA
	public string LFKJNMFFCLH_LastLoginString { get; set; } // 0x20 JDLEEBJKOIL LMGFMDMOCIC KKODLMIGNIG
	public int PDJEMLMOEPF_DivaId { get { return AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.DIPKCALNIII_DivaId; } set { AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.DIPKCALNIII_DivaId = value; } } //0x12126AC OICEHMGFBOG 0x12126F8 GIAENPIECFL
	public int FCKJJGIMPPI { get { return AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.ANAJIAENLNB_Level; } set { AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.ANAJIAENLNB_Level = value; } } //0x121274C KHAEBKHHDDH 0x1212798 FODBHLHKHFI
	//public int NOEAJIJIIHK { get; set; } 0x12127EC IKHEOMAMDGP 0x1212838 MMLGLIOAOBA
	//public bool CADENLBDAEB { get; } 0x121288C KJGFPPLHLAB
	public int NEILEPPJKIN { get; set; } // 0x24 MBBNGAAAJKL 0x12128A0 CPCOJHKJPAG 0x12128A8 JOPFPEAKGOH

	//// RVA: 0x12128B0 Offset: 0x12128B0 VA: 0x12128B0
	//public string LDBPEIMINJB() { }

	//// RVA: 0x1212D10 Offset: 0x1212D10 VA: 0x1212D10 Slot: 4
	public virtual bool EDEDFDDIOKO(int PPFNGGCBJKC_Id, long IFNLEKOILPM_LastLogin, bool MLEHCBKPNGK_IsFriend, List<string> OHNJJIMGKGK_BlockList, EDOHBJAPLPF_JsonData IDLHJIOMJBK_PlayerData)
	{
		BBHNACPENDM_ServerSaveData data = new BBHNACPENDM_ServerSaveData();
		data.EBKCPELHDKN_InitWithBaseAndPublicStatus();
		return NLENMNMCJCJ(PPFNGGCBJKC_Id, IFNLEKOILPM_LastLogin, MLEHCBKPNGK_IsFriend, OHNJJIMGKGK_BlockList, IDLHJIOMJBK_PlayerData, data);
	}

	//// RVA: 0x1212DEC Offset: 0x1212DEC VA: 0x1212DEC Slot: 5
	protected virtual bool NLENMNMCJCJ(int PPFNGGCBJKC_Id, long IFNLEKOILPM_LastLogin, bool MLEHCBKPNGK_IsFriend, List<string> OHNJJIMGKGK_BlockList, EDOHBJAPLPF_JsonData IDLHJIOMJBK_PlayerData, BBHNACPENDM_ServerSaveData AHEFHIMGIBI_ServerData)
	{
		if(AHEFHIMGIBI_ServerData.IIEMACPEEBJ_Load(OHNJJIMGKGK_BlockList, IDLHJIOMJBK_PlayerData))
		{
			AJECHDLMKOE_LastLogin = IFNLEKOILPM_LastLogin;
			MLPEHNBNOGD_Id = PPFNGGCBJKC_Id;
			this.AHEFHIMGIBI_ServerData = AHEFHIMGIBI_ServerData;
			LFKJNMFFCLH_LastLoginString = PIGBKEIAMPE_FriendManager.MKILKPFAOIC_GetLastLoginString(IFNLEKOILPM_LastLogin, NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
			LHMDABPNDDH_Type = MLEHCBKPNGK_IsFriend ? LJJOIIAEICI.HEEJBCDDOJJ_Friend : LJJOIIAEICI.CCAPCGPIIPF_Guest;
			return true;
		}
		return false;
	}

	//// RVA: -1 Offset: -1
	public static FriendPlayerDataClass HEGEKFMJNCC<FriendPlayerDataClass>(int PPFNGGCBJKC_Id, long IFNLEKOILPM_LastLogin, bool MLEHCBKPNGK_IsFriend, List<string> OHNJJIMGKGK_BlockList, EDOHBJAPLPF_JsonData IDLHJIOMJBK_PlayerData) where FriendPlayerDataClass : IBIGBMDANNM, new()
	{
		FriendPlayerDataClass res = new FriendPlayerDataClass();
		if(res.EDEDFDDIOKO(PPFNGGCBJKC_Id, IFNLEKOILPM_LastLogin, MLEHCBKPNGK_IsFriend, OHNJJIMGKGK_BlockList, IDLHJIOMJBK_PlayerData))
		{
			return res;
		}
		return null;
	}
	///* GenericInstMethod :
	//|
	//|-RVA: 0x2B62220 Offset: 0x2B62220 VA: 0x2B62220
	//|-IBIGBMDANNM.HEGEKFMJNCC<IBIGBMDANNM>
	//|-IBIGBMDANNM.HEGEKFMJNCC<IFICNCAHIGI>
	//|-IBIGBMDANNM.HEGEKFMJNCC<NKOBMDPHNGP.ELKMKCNPDFO>
	//|-IBIGBMDANNM.HEGEKFMJNCC<object>
	//*/

	//// RVA: 0x1212F94 Offset: 0x1212F94 VA: 0x1212F94
	//public void ILEBOIGEGEH() { }
}
