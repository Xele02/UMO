
using System.Collections.Generic;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys;

public class ALEKLHIANJN
{
	public class HJBLCFPOFPO
	{
		private int FBGGEFFJJHB_xor; // 0x8
		private long BBEGLBMOBOF_xorl; // 0x10
		private int EHOIENNDEDH_IdCrypted; // 0x18
		private int OHMGPDPKGLF; // 0x1C

		public int PPFNGGCBJKC { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xCD9788 DEMEPMAEJOO 0xCD8550 HIGKAIDMOKN
		public int NANNGLGOFKH { get { return OHMGPDPKGLF ^ FBGGEFFJJHB_xor; } set { OHMGPDPKGLF = value ^ FBGGEFFJJHB_xor; } } //0xCD9798 EDFAHCMGHKM 0xCD8560 BKPDFNKGNHA

		public HJBLCFPOFPO()
		{
			FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA();
			BBEGLBMOBOF_xorl = FBGGEFFJJHB_xor;
			PPFNGGCBJKC = 0;
			NANNGLGOFKH = 0;
		}
	}

	private int FBGGEFFJJHB_xor; // 0x8
	private long BBEGLBMOBOF_xorl; // 0x10
	public NNJFKLBPBNK_SecureString FINCFIGKHPA_Name; // 0x18
	public NNJFKLBPBNK_SecureString FHBDAJIDLNN; // 0x1C
	private int IFGMKBKBFJI; // 0x20
	private int HCFNIMFOOPF_SkillIdCrypted; // 0x24
	private int NFCALENBIBL; // 0x28
	private int CDPBDHBBFKE; // 0x2C
	private List<HJBLCFPOFPO> COCEIPAKJKF_Item; // 0x30

	public string OPFGFINHFCE_SkillName { get { return FINCFIGKHPA_Name.DNJEJEANJGL_Value; } private set { FINCFIGKHPA_Name.DNJEJEANJGL_Value = value; } } //0xCD7DC4 DKJOHDGOIJE 0xCD7DF0 MJAMIGECMMF
	public string FEMMDNIELFC_Desc { get { return FHBDAJIDLNN.DNJEJEANJGL_Value; } private set { FHBDAJIDLNN.DNJEJEANJGL_Value = value; } } //0xCD7E24 JDHDMBHNKJD 0xCD7E50 FNAJEJLLJOE
	public int GPPEFLKGGGJ_ValkyrieId { get { return IFGMKBKBFJI ^ FBGGEFFJJHB_xor; } private set { IFGMKBKBFJI = value ^ FBGGEFFJJHB_xor; } } //0xCD7E84 PCDKIHHDCHI 0xCD7E94 LANEIFNCIAA
	public int ENMAEBJGEKL_SkillId { get { return HCFNIMFOOPF_SkillIdCrypted ^ FBGGEFFJJHB_xor; } private set { HCFNIMFOOPF_SkillIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xCD7EA4 FHIMMFAEDIP 0xCD7EB4 CPEAMPGOMCB
	public int CIEOBFIIPLD_Level { get { return NFCALENBIBL ^ FBGGEFFJJHB_xor; } private set { NFCALENBIBL = value ^ FBGGEFFJJHB_xor; } } //0xCD7EC4 OGKGFGMKPKB 0xCD7ED4 JOOMBHHPHBD
	public int PNJICDLDCAE { get { return CDPBDHBBFKE ^ FBGGEFFJJHB_xor; } private set { CDPBDHBBFKE = value ^ FBGGEFFJJHB_xor; } } //0xCD7EE4 GCGJMHMLPPN 0xCD7EF4 CEEHINGKBMD

	// RVA: 0xCD7F04 Offset: 0xCD7F04 VA: 0xCD7F04
	public ALEKLHIANJN(int GPPEFLKGGGJ_ValkyrieId, int MAFJLEEPFAA_AbilityLevel)
	{
		FINCFIGKHPA_Name = new NNJFKLBPBNK_SecureString();
		FHBDAJIDLNN = new NNJFKLBPBNK_SecureString();
		FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA();
		BBEGLBMOBOF_xorl = FBGGEFFJJHB_xor;
		CIEOBFIIPLD_Level = 0;
		PNJICDLDCAE = 0;
		OPFGFINHFCE_SkillName = "";
		FEMMDNIELFC_Desc = "";
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo valkInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.GCINIJEMHFK(GPPEFLKGGGJ_ValkyrieId);
			this.GPPEFLKGGGJ_ValkyrieId = valkInfo.GPPEFLKGGGJ_ValkyrieId;
			ENMAEBJGEKL_SkillId = valkInfo.BMIJDLBGFNP_SkillId;
			GKFMJAHKEMA_ValSkill.CCPFGNNIBDD skillInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.MNHBHNIHJJH(ENMAEBJGEKL_SkillId);
			CIEOBFIIPLD_Level = MAFJLEEPFAA_AbilityLevel;
			if (MAFJLEEPFAA_AbilityLevel != 0)
				MAFJLEEPFAA_AbilityLevel--;
			GKFMJAHKEMA_ValSkill.GBDONNIHJHG skillInfo2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.OOEFAGKHOCE(skillInfo.KFLIHDFDBOA);
			PNJICDLDCAE = skillInfo2.NBMPBLECFJD(MAFJLEEPFAA_AbilityLevel);
			OPFGFINHFCE_SkillName = MessageManager.Instance.GetBank("master").GetMessageByLabel("val_skill_nm_" + skillInfo2.CBDFEJIBAMO.ToString("D4"));
			FEMMDNIELFC_Desc = MessageManager.Instance.GetBank("master").GetMessageByLabel("val_skill_dsc_" + skillInfo.KFLIHDFDBOA.ToString("D4"));
			COCEIPAKJKF_Item = new List<HJBLCFPOFPO>(2);
			for(int i = 0; i < 2; i++)
			{
				HJBLCFPOFPO data = new HJBLCFPOFPO();
				GKFMJAHKEMA_ValSkill.FCHIPJMDHBM skillInfo3 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.MFFFFDKBOFK(skillInfo.OGMLPLGLELF);
				data.PPFNGGCBJKC = i == 0 ? skillInfo3.AFGPHBOOHJH(MAFJLEEPFAA_AbilityLevel) : skillInfo3.MKGGFAKEGFL(MAFJLEEPFAA_AbilityLevel);
				data.NANNGLGOFKH = i == 0 ? skillInfo3.IFDKNGCDNHP(MAFJLEEPFAA_AbilityLevel) : skillInfo3.BFNMADOFKHI(MAFJLEEPFAA_AbilityLevel);
				COCEIPAKJKF_Item.Add(data);
			}
		}
	}

	//// RVA: 0xCD8570 Offset: 0xCD8570 VA: 0xCD8570
	public string CHHADJECKNL_GetLevel()
	{
		return CIEOBFIIPLD_Level != 0 ? CIEOBFIIPLD_Level.ToString() : "1";
	}

	//// RVA: 0xCD85A4 Offset: 0xCD85A4 VA: 0xCD85A4
	public string DMBDNIEEMCB_GetDesc(bool PNNGGAKLJAC_UpColor/* = false*/)
	{
		string res = PNJICDLDCAE.ToString();
		if (PNNGGAKLJAC_UpColor)
		{
			res = res.ToString().Insert(0, string.Format("<color={0}>", StatusTextColor.UpColor));
			res += "</color>";
		}
		res = string.Format(FEMMDNIELFC_Desc, res);
		return res;
	}

	//// RVA: 0xCD86D8 Offset: 0xCD86D8 VA: 0xCD86D8
	public List<HJBLCFPOFPO> PFIFFGHLCJJ()
	{
		return COCEIPAKJKF_Item;
	}

	//// RVA: 0xCD86E0 Offset: 0xCD86E0 VA: 0xCD86E0
	//public ALEKLHIANJN.HJBLCFPOFPO PEKPKOAFNFL(bool JPBPEHGHBEH = True) { }

	//// RVA: 0xCD8764 Offset: 0xCD8764 VA: 0xCD8764
	private int CEJCMBICONL(int KIJAPOFAGPN, int HMFFHLPNMPH)
	{
		if(HMFFHLPNMPH < 1)
			return -1;
        EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(KIJAPOFAGPN);
        int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(KIJAPOFAGPN);
		if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem)
		{
			INDEPDKCJDD_ValItem.NHJLDENJKBE dbItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FBGKBGNIHGC_ValItem.CDENCMNHNGA_table[id - 1];
			if(dbItem.PPFNGGCBJKC_Id != id)
				return -1;
			return HMFFHLPNMPH <= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.MJAIFKFOPPI_ValItem[id - 1].BFINGCJHOHI_Count ? 1 : 0;
		}
		else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NKDGLGCAPEI_GrowItem.CDENCMNHNGA_table[id - 1].PPFNGGCBJKC != id)
				return -1;
			return HMFFHLPNMPH <= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KBMDMEEMGLK_GrowItem[id - 1].BFINGCJHOHI_Count ? 1 : 0;
		}
		return HMFFHLPNMPH <= 0 ? 1 : 0;
	}

	//// RVA: 0xCD8B18 Offset: 0xCD8B18 VA: 0xCD8B18
	private bool JLDNFNAOEKE(int _CIEOBFIIPLD_Level)
	{
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JJFFBDLIOCF_Valkyrie.OEMMJCLJMGB_GetLevel(GPPEFLKGGGJ_ValkyrieId) + 1 == _CIEOBFIIPLD_Level;
	}

	//// RVA: 0xCD8C20 Offset: 0xCD8C20 VA: 0xCD8C20
	public int KBFDFIBDOKC(IMCBBOAFION _BHFHGFKBOHH_OnSuccess)
	{
		for(int i = 0; i < COCEIPAKJKF_Item.Count; i++)
		{
			int a1 = CEJCMBICONL(COCEIPAKJKF_Item[i].PPFNGGCBJKC, COCEIPAKJKF_Item[i].NANNGLGOFKH);
			if(a1 < 1)
				return a1;
		}
		if(!JLDNFNAOEKE(CIEOBFIIPLD_Level))
		{
			return -1;
		}
		FENCAJJBLBH f = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PFAKPFKJJKA(true);
		if(f == null)
		{
			int a1 = 0;
			int a2 = 0;
			int a3 = 0;
			int a4 = 0;
			for(int i = 0; i < COCEIPAKJKF_Item.Count; i++)
			{
                EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(COCEIPAKJKF_Item[i].PPFNGGCBJKC);
				int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(COCEIPAKJKF_Item[i].PPFNGGCBJKC);
				if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem)
				{
					EGOLBAPFHHD_Common.GHOADMJCPFK valkItem = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.MJAIFKFOPPI_ValItem[id - 1];
					valkItem.BFINGCJHOHI_Count -= COCEIPAKJKF_Item[i].NANNGLGOFKH;
					if(valkItem.BFINGCJHOHI_Count < 0)
					{
						valkItem.BFINGCJHOHI_Count = 0;
					}
					a1 = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem, id);
					a2 = COCEIPAKJKF_Item[i].NANNGLGOFKH;
				}
				else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem)
				{
					EGOLBAPFHHD_Common.OFAPDOKONML growItem = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KBMDMEEMGLK_GrowItem[id - 1];
					growItem.BFINGCJHOHI_Count -= COCEIPAKJKF_Item[i].NANNGLGOFKH;
					if(growItem.BFINGCJHOHI_Count < 0)
					{
						growItem.BFINGCJHOHI_Count = 0;
					}
					a3 = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem, id);
					a4 = COCEIPAKJKF_Item[i].NANNGLGOFKH;
				}
            }
			int a5 = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JJFFBDLIOCF_Valkyrie.OEMMJCLJMGB_GetLevel(GPPEFLKGGGJ_ValkyrieId);
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JJFFBDLIOCF_Valkyrie.KBBNHBBGDEC(GPPEFLKGGGJ_ValkyrieId, a5 + 1);
			LEBCBCCPOPE();
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.FFMDFKBLECC(1);
			JDDGPJDKHNE.HHCJCDFCLOB.NFNLGGHMEAM();
			JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = true;
			ILCCJNDFFOB.HHCJCDFCLOB.ELDCONNMDGN(GPPEFLKGGGJ_ValkyrieId, a5, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JJFFBDLIOCF_Valkyrie.OEMMJCLJMGB_GetLevel(GPPEFLKGGGJ_ValkyrieId), a1, a2, a3, a4);
		}
		MenuScene.SaveWithAchievement(0, () =>
		{
			//0xCD9BBC
			JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
			_BHFHGFKBOHH_OnSuccess();
		}, null);
		return 1;
	}

	//// RVA: 0xCD97A8 Offset: 0xCD97A8 VA: 0xCD97A8
	private void LEBCBCCPOPE()
	{
		GKFMJAHKEMA_ValSkill.CCPFGNNIBDD skill = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.MNHBHNIHJJH(ENMAEBJGEKL_SkillId);
		if(skill.NHFDCMNPFDK > 0)
		{
			int level = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JJFFBDLIOCF_Valkyrie.OEMMJCLJMGB_GetLevel(GPPEFLKGGGJ_ValkyrieId);
			GKFMJAHKEMA_ValSkill.FIKGJJDIBPH sk = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.NIIADANCEKL(skill.NHFDCMNPFDK);
			int a1 = sk.MLIJKJFMOHN(level - 1);
			JKNGJFOBADP j = new JKNGJFOBADP();
			j.JCHLONCMPAJ();
			j.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.PFPGFPLGANO, GPPEFLKGGGJ_ValkyrieId + ":" + level);
			j.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, a1, sk.IMALGGGJDJO(level - 1), null, 0);
		}
	}
}
