
using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;

public class ALEKLHIANJN
{
	public class HJBLCFPOFPO
	{
		private int FBGGEFFJJHB; // 0x8
		private long BBEGLBMOBOF; // 0x10
		private int EHOIENNDEDH; // 0x18
		private int OHMGPDPKGLF; // 0x1C

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0xCD9788 DEMEPMAEJOO 0xCD8550 HIGKAIDMOKN
		public int NANNGLGOFKH { get { return OHMGPDPKGLF ^ FBGGEFFJJHB; } set { OHMGPDPKGLF = value ^ FBGGEFFJJHB; } } //0xCD9798 EDFAHCMGHKM 0xCD8560 BKPDFNKGNHA

		public HJBLCFPOFPO()
		{
			FBGGEFFJJHB = LPDNKHAIOLH.CEIBAFOCNCA();
			BBEGLBMOBOF = FBGGEFFJJHB;
			PPFNGGCBJKC = 0;
			NANNGLGOFKH = 0;
		}
	}

	private int FBGGEFFJJHB; // 0x8
	private long BBEGLBMOBOF; // 0x10
	public NNJFKLBPBNK_SecureString FINCFIGKHPA; // 0x18
	public NNJFKLBPBNK_SecureString FHBDAJIDLNN; // 0x1C
	private int IFGMKBKBFJI; // 0x20
	private int HCFNIMFOOPF; // 0x24
	private int NFCALENBIBL; // 0x28
	private int CDPBDHBBFKE; // 0x2C
	private List<HJBLCFPOFPO> COCEIPAKJKF; // 0x30

	public string OPFGFINHFCE_SkillName { get { return FINCFIGKHPA.DNJEJEANJGL_Value; } private set { FINCFIGKHPA.DNJEJEANJGL_Value = value; } } //0xCD7DC4 DKJOHDGOIJE 0xCD7DF0 MJAMIGECMMF
	public string FEMMDNIELFC_SkillDesc { get { return FHBDAJIDLNN.DNJEJEANJGL_Value; } private set { FHBDAJIDLNN.DNJEJEANJGL_Value = value; } } //0xCD7E24 JDHDMBHNKJD 0xCD7E50 FNAJEJLLJOE
	public int GPPEFLKGGGJ_ValkyrieId { get { return IFGMKBKBFJI ^ FBGGEFFJJHB; } private set { IFGMKBKBFJI = value ^ FBGGEFFJJHB; } } //0xCD7E84 PCDKIHHDCHI 0xCD7E94 LANEIFNCIAA
	public int ENMAEBJGEKL_SkillId { get { return HCFNIMFOOPF ^ FBGGEFFJJHB; } private set { HCFNIMFOOPF = value ^ FBGGEFFJJHB; } } //0xCD7EA4 FHIMMFAEDIP 0xCD7EB4 CPEAMPGOMCB
	public int CIEOBFIIPLD_AbilityLevel { get { return NFCALENBIBL ^ FBGGEFFJJHB; } private set { NFCALENBIBL = value ^ FBGGEFFJJHB; } } //0xCD7EC4 OGKGFGMKPKB 0xCD7ED4 JOOMBHHPHBD
	public int PNJICDLDCAE { get { return CDPBDHBBFKE ^ FBGGEFFJJHB; } private set { CDPBDHBBFKE = value ^ FBGGEFFJJHB; } } //0xCD7EE4 GCGJMHMLPPN 0xCD7EF4 CEEHINGKBMD

	// RVA: 0xCD7F04 Offset: 0xCD7F04 VA: 0xCD7F04
	public ALEKLHIANJN(int GPPEFLKGGGJ_ValkyrieId, int MAFJLEEPFAA_AbilityLevel)
	{
		FINCFIGKHPA = new NNJFKLBPBNK_SecureString();
		FHBDAJIDLNN = new NNJFKLBPBNK_SecureString();
		FBGGEFFJJHB = LPDNKHAIOLH.CEIBAFOCNCA();
		BBEGLBMOBOF = FBGGEFFJJHB;
		CIEOBFIIPLD_AbilityLevel = 0;
		PNJICDLDCAE = 0;
		OPFGFINHFCE_SkillName = "";
		FEMMDNIELFC_SkillDesc = "";
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo valkInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.GCINIJEMHFK(GPPEFLKGGGJ_ValkyrieId);
			this.GPPEFLKGGGJ_ValkyrieId = valkInfo.GPPEFLKGGGJ_Id;
			ENMAEBJGEKL_SkillId = valkInfo.BMIJDLBGFNP_SkillId;
			GKFMJAHKEMA_ValSkill.CCPFGNNIBDD skillInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.MNHBHNIHJJH(ENMAEBJGEKL_SkillId);
			CIEOBFIIPLD_AbilityLevel = MAFJLEEPFAA_AbilityLevel;
			if (MAFJLEEPFAA_AbilityLevel != 0)
				MAFJLEEPFAA_AbilityLevel--;
			GKFMJAHKEMA_ValSkill.GBDONNIHJHG skillInfo2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.OOEFAGKHOCE(skillInfo.KFLIHDFDBOA);
			PNJICDLDCAE = skillInfo2.NBMPBLECFJD(MAFJLEEPFAA_AbilityLevel);
			OPFGFINHFCE_SkillName = MessageManager.Instance.GetBank("master").GetMessageByLabel("val_skill_nm_" + skillInfo2.CBDFEJIBAMO.ToString("D4"));
			FEMMDNIELFC_SkillDesc = MessageManager.Instance.GetBank("master").GetMessageByLabel("val_skill_dsc_" + skillInfo2.CBDFEJIBAMO.ToString("D4"));
			COCEIPAKJKF = new List<HJBLCFPOFPO>(2);
			for(int i = 0; i < 2; i++)
			{
				HJBLCFPOFPO data = new HJBLCFPOFPO();
				GKFMJAHKEMA_ValSkill.FCHIPJMDHBM skillInfo3 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.MFFFFDKBOFK(skillInfo.OGMLPLGLELF);
				data.PPFNGGCBJKC = i == 0 ? skillInfo3.AFGPHBOOHJH(MAFJLEEPFAA_AbilityLevel) : skillInfo3.MKGGFAKEGFL(MAFJLEEPFAA_AbilityLevel);
				data.NANNGLGOFKH = i == 0 ? skillInfo3.IFDKNGCDNHP(MAFJLEEPFAA_AbilityLevel) : skillInfo3.BFNMADOFKHI(MAFJLEEPFAA_AbilityLevel);
				COCEIPAKJKF.Add(data);
			}
		}
	}

	//// RVA: 0xCD8570 Offset: 0xCD8570 VA: 0xCD8570
	public string CHHADJECKNL_GetLevel()
	{
		return CIEOBFIIPLD_AbilityLevel != 0 ? CIEOBFIIPLD_AbilityLevel.ToString() : "1";
	}

	//// RVA: 0xCD85A4 Offset: 0xCD85A4 VA: 0xCD85A4
	public string DMBDNIEEMCB_GetDesc(bool PNNGGAKLJAC_UpColor = false)
	{
		string res = PNJICDLDCAE.ToString();
		if (PNNGGAKLJAC_UpColor)
		{
			res = res.ToString().Insert(0, string.Format("<color={0}>", StatusTextColor.UpColor));
			res += "</color>";
		}
		res = string.Format(FEMMDNIELFC_SkillDesc, res);
		return res;
	}

	//// RVA: 0xCD86D8 Offset: 0xCD86D8 VA: 0xCD86D8
	//public List<ALEKLHIANJN.HJBLCFPOFPO> PFIFFGHLCJJ() { }

	//// RVA: 0xCD86E0 Offset: 0xCD86E0 VA: 0xCD86E0
	//public ALEKLHIANJN.HJBLCFPOFPO PEKPKOAFNFL(bool JPBPEHGHBEH = True) { }

	//// RVA: 0xCD8764 Offset: 0xCD8764 VA: 0xCD8764
	//private int CEJCMBICONL(int KIJAPOFAGPN, int HMFFHLPNMPH) { }

	//// RVA: 0xCD8B18 Offset: 0xCD8B18 VA: 0xCD8B18
	//private bool JLDNFNAOEKE(int CIEOBFIIPLD) { }

	//// RVA: 0xCD8C20 Offset: 0xCD8C20 VA: 0xCD8C20
	public int KBFDFIBDOKC(IMCBBOAFION BHFHGFKBOHH)
	{
		TodoLogger.LogError(0, "KBFDFIBDOKC");
		return 0;
	}

	//// RVA: 0xCD97A8 Offset: 0xCD97A8 VA: 0xCD97A8
	//private void LEBCBCCPOPE() { }
}
