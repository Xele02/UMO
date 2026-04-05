
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
		private int OHMGPDPKGLF_ValueCrypted; // 0x1C

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xCD9788 DEMEPMAEJOO_get_id 0xCD8550 HIGKAIDMOKN_set_id
		public int NANNGLGOFKH_value { get { return OHMGPDPKGLF_ValueCrypted ^ FBGGEFFJJHB_xor; } set { OHMGPDPKGLF_ValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0xCD9798 EDFAHCMGHKM_get_value 0xCD8560 BKPDFNKGNHA_set_value

		public HJBLCFPOFPO()
		{
			FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA_Int();
			BBEGLBMOBOF_xorl = FBGGEFFJJHB_xor;
			PPFNGGCBJKC_id = 0;
			NANNGLGOFKH_value = 0;
		}
	}

	private int FBGGEFFJJHB_xor; // 0x8
	private long BBEGLBMOBOF_xorl; // 0x10
	public NNJFKLBPBNK_SecureString FINCFIGKHPA_Name; // 0x18
	public NNJFKLBPBNK_SecureString FHBDAJIDLNN; // 0x1C
	private int IFGMKBKBFJI_ValkyrieIdCrypted; // 0x20
	private int HCFNIMFOOPF_SkillIdCrypted; // 0x24
	private int NFCALENBIBL_LevelCrypted; // 0x28
	private int CDPBDHBBFKE; // 0x2C
	private List<HJBLCFPOFPO> COCEIPAKJKF_item; // 0x30

	public string OPFGFINHFCE_name { get { return FINCFIGKHPA_Name.DNJEJEANJGL_Value; } private set { FINCFIGKHPA_Name.DNJEJEANJGL_Value = value; } } //0xCD7DC4 DKJOHDGOIJE_get_name 0xCD7DF0 MJAMIGECMMF_set_name
	public string FEMMDNIELFC_Desc { get { return FHBDAJIDLNN.DNJEJEANJGL_Value; } private set { FHBDAJIDLNN.DNJEJEANJGL_Value = value; } } //0xCD7E24 JDHDMBHNKJD_get_Desc 0xCD7E50 FNAJEJLLJOE_set_Desc
	public int GPPEFLKGGGJ_ValkyrieId { get { return IFGMKBKBFJI_ValkyrieIdCrypted ^ FBGGEFFJJHB_xor; } private set { IFGMKBKBFJI_ValkyrieIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xCD7E84 PCDKIHHDCHI_bgs 0xCD7E94 LANEIFNCIAA_bgs
	public int ENMAEBJGEKL_SkillId { get { return HCFNIMFOOPF_SkillIdCrypted ^ FBGGEFFJJHB_xor; } private set { HCFNIMFOOPF_SkillIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xCD7EA4 FHIMMFAEDIP_bgs 0xCD7EB4 CPEAMPGOMCB_bgs
	public int CIEOBFIIPLD_Level { get { return NFCALENBIBL_LevelCrypted ^ FBGGEFFJJHB_xor; } private set { NFCALENBIBL_LevelCrypted = value ^ FBGGEFFJJHB_xor; } } //0xCD7EC4 OGKGFGMKPKB_bgs 0xCD7ED4 JOOMBHHPHBD_bgs
	public int PNJICDLDCAE { get { return CDPBDHBBFKE ^ FBGGEFFJJHB_xor; } private set { CDPBDHBBFKE = value ^ FBGGEFFJJHB_xor; } } //0xCD7EE4 GCGJMHMLPPN_bgs 0xCD7EF4 CEEHINGKBMD_bgs

	// RVA: 0xCD7F04 Offset: 0xCD7F04 VA: 0xCD7F04
	public ALEKLHIANJN(int GPPEFLKGGGJ_ValkyrieId, int MAFJLEEPFAA_AbilityLevel)
	{
		FINCFIGKHPA_Name = new NNJFKLBPBNK_SecureString();
		FHBDAJIDLNN = new NNJFKLBPBNK_SecureString();
		FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA_Int();
		BBEGLBMOBOF_xorl = FBGGEFFJJHB_xor;
		CIEOBFIIPLD_Level = 0;
		PNJICDLDCAE = 0;
		OPFGFINHFCE_name = "";
		FEMMDNIELFC_Desc = "";
		if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database != null)
		{
			JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo valkInfo = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.GCINIJEMHFK_Get(GPPEFLKGGGJ_ValkyrieId);
			this.GPPEFLKGGGJ_ValkyrieId = valkInfo.GPPEFLKGGGJ_ValkyrieId;
			ENMAEBJGEKL_SkillId = valkInfo.BMIJDLBGFNP_skill;
			GKFMJAHKEMA_ValSkill.CCPFGNNIBDD skillInfo = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.MNHBHNIHJJH(ENMAEBJGEKL_SkillId);
			CIEOBFIIPLD_Level = MAFJLEEPFAA_AbilityLevel;
			if (MAFJLEEPFAA_AbilityLevel != 0)
				MAFJLEEPFAA_AbilityLevel--;
			GKFMJAHKEMA_ValSkill.GBDONNIHJHG skillInfo2 = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.OOEFAGKHOCE(skillInfo.KFLIHDFDBOA);
			PNJICDLDCAE = skillInfo2.NBMPBLECFJD(MAFJLEEPFAA_AbilityLevel);
			OPFGFINHFCE_name = MessageManager.Instance.GetBank("master").GetMessageByLabel("val_skill_nm_" + skillInfo2.CBDFEJIBAMO.ToString("D4"));
			FEMMDNIELFC_Desc = MessageManager.Instance.GetBank("master").GetMessageByLabel("val_skill_dsc_" + skillInfo.KFLIHDFDBOA.ToString("D4"));
			COCEIPAKJKF_item = new List<HJBLCFPOFPO>(2);
			for(int i = 0; i < 2; i++)
			{
				HJBLCFPOFPO data = new HJBLCFPOFPO();
				GKFMJAHKEMA_ValSkill.FCHIPJMDHBM skillInfo3 = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.MFFFFDKBOFK(skillInfo.OGMLPLGLELF);
				data.PPFNGGCBJKC_id = i == 0 ? skillInfo3.AFGPHBOOHJH(MAFJLEEPFAA_AbilityLevel) : skillInfo3.MKGGFAKEGFL(MAFJLEEPFAA_AbilityLevel);
				data.NANNGLGOFKH_value = i == 0 ? skillInfo3.IFDKNGCDNHP(MAFJLEEPFAA_AbilityLevel) : skillInfo3.BFNMADOFKHI(MAFJLEEPFAA_AbilityLevel);
				COCEIPAKJKF_item.Add(data);
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
		return COCEIPAKJKF_item;
	}

	//// RVA: 0xCD86E0 Offset: 0xCD86E0 VA: 0xCD86E0
	//public ALEKLHIANJN.HJBLCFPOFPO PEKPKOAFNFL(bool JPBPEHGHBEH = True) { }

	//// RVA: 0xCD8764 Offset: 0xCD8764 VA: 0xCD8764
	private int CEJCMBICONL(int _KIJAPOFAGPN_ItemId, int _HMFFHLPNMPH_count)
	{
		if(_HMFFHLPNMPH_count < 1)
			return -1;
        EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category cat = EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(_KIJAPOFAGPN_ItemId);
        int id = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(_KIJAPOFAGPN_ItemId);
		if(cat == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem)
		{
			INDEPDKCJDD_ValItem.NHJLDENJKBE dbItem = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FBGKBGNIHGC_ValItem.CDENCMNHNGA_table[id - 1];
			if(dbItem.PPFNGGCBJKC_id != id)
				return -1;
			return _HMFFHLPNMPH_count <= CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.MJAIFKFOPPI_ValItem[id - 1].BFINGCJHOHI_cnt ? 1 : 0;
		}
		else if(cat == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem)
		{
			if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.NKDGLGCAPEI_GrowItem.CDENCMNHNGA_table[id - 1].PPFNGGCBJKC_id != id)
				return -1;
			return _HMFFHLPNMPH_count <= CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KBMDMEEMGLK_grow_item[id - 1].BFINGCJHOHI_cnt ? 1 : 0;
		}
		return _HMFFHLPNMPH_count <= 0 ? 1 : 0;
	}

	//// RVA: 0xCD8B18 Offset: 0xCD8B18 VA: 0xCD8B18
	private bool JLDNFNAOEKE(int _CIEOBFIIPLD_Level)
	{
		return CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.JJFFBDLIOCF_Valkyrie.OEMMJCLJMGB_GetLevel(GPPEFLKGGGJ_ValkyrieId) + 1 == _CIEOBFIIPLD_Level;
	}

	//// RVA: 0xCD8C20 Offset: 0xCD8C20 VA: 0xCD8C20
	public int KBFDFIBDOKC(IMCBBOAFION _BHFHGFKBOHH_OnSuccess)
	{
		for(int i = 0; i < COCEIPAKJKF_item.Count; i++)
		{
			int a1 = CEJCMBICONL(COCEIPAKJKF_item[i].PPFNGGCBJKC_id, COCEIPAKJKF_item[i].NANNGLGOFKH_value);
			if(a1 < 1)
				return a1;
		}
		if(!JLDNFNAOEKE(CIEOBFIIPLD_Level))
		{
			return -1;
		}
		FENCAJJBLBH f = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.PFAKPFKJJKA(true);
		if(f == null)
		{
			int a1 = 0;
			int a2 = 0;
			int a3 = 0;
			int a4 = 0;
			for(int i = 0; i < COCEIPAKJKF_item.Count; i++)
			{
                EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category cat = EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(COCEIPAKJKF_item[i].PPFNGGCBJKC_id);
				int id = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(COCEIPAKJKF_item[i].PPFNGGCBJKC_id);
				if(cat == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem)
				{
					EGOLBAPFHHD_Common.GHOADMJCPFK valkItem = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.MJAIFKFOPPI_ValItem[id - 1];
					valkItem.BFINGCJHOHI_cnt -= COCEIPAKJKF_item[i].NANNGLGOFKH_value;
					if(valkItem.BFINGCJHOHI_cnt < 0)
					{
						valkItem.BFINGCJHOHI_cnt = 0;
					}
					a1 = EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem, id);
					a2 = COCEIPAKJKF_item[i].NANNGLGOFKH_value;
				}
				else if(cat == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem)
				{
					EGOLBAPFHHD_Common.OFAPDOKONML growItem = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KBMDMEEMGLK_grow_item[id - 1];
					growItem.BFINGCJHOHI_cnt -= COCEIPAKJKF_item[i].NANNGLGOFKH_value;
					if(growItem.BFINGCJHOHI_cnt < 0)
					{
						growItem.BFINGCJHOHI_cnt = 0;
					}
					a3 = EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem, id);
					a4 = COCEIPAKJKF_item[i].NANNGLGOFKH_value;
				}
            }
			int a5 = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.JJFFBDLIOCF_Valkyrie.OEMMJCLJMGB_GetLevel(GPPEFLKGGGJ_ValkyrieId);
			CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.JJFFBDLIOCF_Valkyrie.KBBNHBBGDEC(GPPEFLKGGGJ_ValkyrieId, a5 + 1);
			LEBCBCCPOPE();
			CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.FFMDFKBLECC(1);
			JDDGPJDKHNE.HHCJCDFCLOB_Instance.NFNLGGHMEAM();
			JDDGPJDKHNE.HHCJCDFCLOB_Instance.FCMCNIMEAEA = true;
			ILCCJNDFFOB.HHCJCDFCLOB_Instance.ELDCONNMDGN_ValkyrieEnhance(GPPEFLKGGGJ_ValkyrieId, a5, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.JJFFBDLIOCF_Valkyrie.OEMMJCLJMGB_GetLevel(GPPEFLKGGGJ_ValkyrieId), a1, a2, a3, a4);
		}
		MenuScene.SaveWithAchievement(0, () =>
		{
			//0xCD9BBC
			JDDGPJDKHNE.HHCJCDFCLOB_Instance.FCMCNIMEAEA = false;
			_BHFHGFKBOHH_OnSuccess();
		}, null);
		return 1;
	}

	//// RVA: 0xCD97A8 Offset: 0xCD97A8 VA: 0xCD97A8
	private void LEBCBCCPOPE()
	{
		GKFMJAHKEMA_ValSkill.CCPFGNNIBDD skill = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.MNHBHNIHJJH(ENMAEBJGEKL_SkillId);
		if(skill.NHFDCMNPFDK > 0)
		{
			int level = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.JJFFBDLIOCF_Valkyrie.OEMMJCLJMGB_GetLevel(GPPEFLKGGGJ_ValkyrieId);
			GKFMJAHKEMA_ValSkill.FIKGJJDIBPH sk = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.NIIADANCEKL(skill.NHFDCMNPFDK);
			int a1 = sk.MLIJKJFMOHN(level - 1);
			JKNGJFOBADP j = new JKNGJFOBADP();
			j.JCHLONCMPAJ_Clear();
			j.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.PFPGFPLGANO_30_ValkyrieSkillUpgrade, GPPEFLKGGGJ_ValkyrieId + ":" + level);
			j.CPIICACGNBH_AddItem(CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, a1, sk.IMALGGGJDJO(level - 1), null, 0);
		}
	}
}
