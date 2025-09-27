using System.Collections.Generic;

public class IBIGBMDANNM
{
	public enum LJJOIIAEICI
	{
		CCAPCGPIIPF_Guest = 0,
		HEEJBCDDOJJ_Friend = 1,
		BGHNFBANAMN_2 = 2,
		FCDDHHKAGEP = 3,
	}
	
	public long AJECHDLMKOE_LastLogin; // 0x10
	public long DHIFKMEFABP; // 0x18
	public LJJOIIAEICI LHMDABPNDDH_state; // 0x28
	public BBHNACPENDM_ServerSaveData AHEFHIMGIBI_PlayerData; // 0x2C
	public bool ONAFFLLLBHE_IsSelf; // 0x30
	public int FJOLNJLLJEJ_rank; // 0x34
	public long KNIFCANOHOC_score; // 0x38
	public double HMLEDBJDCAF_PreciseScore; // 0x40

	public int MLPEHNBNOGD_PlayerId { get; set; } // 0x8 OCNCGDJNBIH LJALJLIIODH MKBAMFJNCDK
	public int ADFIHAPELAN_PLevel { get { return AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.KIECDDFNCAN_PLevel; } set { AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.KIECDDFNCAN_PLevel = value; } } //0x121255C NBALCMLLJGJ 0x12125A8 CPMNIMFDFAM
	public string LBODHBDOMGK_PlayerName { get { return AHEFHIMGIBI_PlayerData.JHFIPCIHJNL_Base.OPFGFINHFCE_name; } set { AHEFHIMGIBI_PlayerData.JHFIPCIHJNL_Base.OPFGFINHFCE_name = value; } }// 0x12125FC JLFIGDAGIEB 0x1212648 KMHENDLDBEA
	public string LFKJNMFFCLH_LastLoginString { get; set; } // 0x20 JDLEEBJKOIL LMGFMDMOCIC KKODLMIGNIG
	public int PDJEMLMOEPF_DivaId { get { return AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.DIPKCALNIII_diva_id; } set { AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.DIPKCALNIII_diva_id = value; } } //0x12126AC OICEHMGFBOG 0x12126F8 GIAENPIECFL
	public int FCKJJGIMPPI_Level { get { return AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.ANAJIAENLNB_lv; } set { AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.ANAJIAENLNB_lv = value; } } //0x121274C KHAEBKHHDDH 0x1212798 FODBHLHKHFI
	public int NOEAJIJIIHK_McPower { get { return AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.OENMBJEKJII_McPower; } set { AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.OENMBJEKJII_McPower = value; } } //0x12127EC IKHEOMAMDGP 0x1212838 MMLGLIOAOBA
	//public bool CADENLBDAEB_IsNew { get; } 0x121288C KJGFPPLHLAB
	public int NEILEPPJKIN_favorite { get; set; } // 0x24 MBBNGAAAJKL 0x12128A0 CPCOJHKJPAG 0x12128A8 JOPFPEAKGOH

	//// RVA: 0x12128B0 Offset: 0x12128B0 VA: 0x12128B0
	//public string LDBPEIMINJB() { }

	//// RVA: 0x1212D10 Offset: 0x1212D10 VA: 0x1212D10 Slot: 4
	public virtual bool EDEDFDDIOKO_Set(int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, bool _MLEHCBKPNGK_IsFriend, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
	{
		BBHNACPENDM_ServerSaveData data = new BBHNACPENDM_ServerSaveData();
		data.EBKCPELHDKN_InitWithBaseAndPublicStatus();
		return NLENMNMCJCJ(_PPFNGGCBJKC_id, _IFNLEKOILPM_updated_at, _MLEHCBKPNGK_IsFriend, _OHNJJIMGKGK_Names, _IDLHJIOMJBK_data, data);
	}

	//// RVA: 0x1212DEC Offset: 0x1212DEC VA: 0x1212DEC Slot: 5
	protected virtual bool NLENMNMCJCJ(int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, bool _MLEHCBKPNGK_IsFriend, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data, BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData)
	{
		if(_AHEFHIMGIBI_PlayerData.IIEMACPEEBJ_Deserialize(_OHNJJIMGKGK_Names, _IDLHJIOMJBK_data))
		{
			AJECHDLMKOE_LastLogin = _IFNLEKOILPM_updated_at;
			MLPEHNBNOGD_PlayerId = _PPFNGGCBJKC_id;
			this.AHEFHIMGIBI_PlayerData = _AHEFHIMGIBI_PlayerData;
			LFKJNMFFCLH_LastLoginString = PIGBKEIAMPE_FriendManager.MKILKPFAOIC_GetLastLoginString(_IFNLEKOILPM_updated_at, NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
			LHMDABPNDDH_state = _MLEHCBKPNGK_IsFriend ? LJJOIIAEICI.HEEJBCDDOJJ_Friend : LJJOIIAEICI.CCAPCGPIIPF_Guest;
			return true;
		}
		return false;
	}

	//// RVA: -1 Offset: -1
	public static FriendPlayerDataClass HEGEKFMJNCC<FriendPlayerDataClass>(int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, bool _MLEHCBKPNGK_IsFriend, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) where FriendPlayerDataClass : IBIGBMDANNM, new()
	{
		FriendPlayerDataClass res = new FriendPlayerDataClass();
		if(res.EDEDFDDIOKO_Set(_PPFNGGCBJKC_id, _IFNLEKOILPM_updated_at, _MLEHCBKPNGK_IsFriend, _OHNJJIMGKGK_Names, _IDLHJIOMJBK_data))
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
	//|-IBIGBMDANNM.HEGEKFMJNCC<NKOBMDPHNGP_EventRaidLobby.ELKMKCNPDFO>
	//|-IBIGBMDANNM.HEGEKFMJNCC<object>
	//*/

	//// RVA: 0x1212F94 Offset: 0x1212F94 VA: 0x1212F94
	public void ILEBOIGEGEH()
	{
		AHEFHIMGIBI_PlayerData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData;
		MLPEHNBNOGD_PlayerId = NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId;
		AJECHDLMKOE_LastLogin = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		LFKJNMFFCLH_LastLoginString = PIGBKEIAMPE_FriendManager.MKILKPFAOIC_GetLastLoginString(AJECHDLMKOE_LastLogin, AJECHDLMKOE_LastLogin);
		LHMDABPNDDH_state = LJJOIIAEICI.CCAPCGPIIPF_Guest;
	}
}
