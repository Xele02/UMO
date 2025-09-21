
using XeSys;

[System.Obsolete("Use EJKBKMBJMGL_EnemyData", true)]
public class EJKBKMBJMGL { }
public class EJKBKMBJMGL_EnemyData
{
	public int EJNIMIAPJFJ_Id = 0; // 0x8
	public int JKPPKAHPPKH_life = 0; // 0xC
	public int ADMMEMNGKEN_Avo = 0; // 0x10
	public int EAHPLCJMPHD_PId = 0; // 0x14 Pic
	public int EELBHDJJJHH_Plt = 1; // 0x18
	public int JMEGLFEKEBD_LiveSkill = 1; // 0x1C
	public int MOMCFBMJJKB_CenterSkill = 1; // 0x20
	public string OPFGFINHFCE_name; // 0x24
	public string KLMPFGOCBHC_description; // 0x28
	public string NDPPEMCHKHA_LiveSkillName1; // 0x2C
	public string PFHJFIHGCKP_CenterSkillName; // 0x30
	public int DCOALMMJDJK_OverrideCenterSkill; // 0x34
	public int KKPLDFNDFDE_OverrideLiveSkill; // 0x38

	public int LMJFFFOEPLE_LiveSkillId { get { return KKPLDFNDFDE_OverrideLiveSkill < 1 ? JMEGLFEKEBD_LiveSkill : KKPLDFNDFDE_OverrideLiveSkill; } } //0x12F3790 CGIJHCKFOKG
	public int PDHCABLLJPB_CenterSkillId { get { return DCOALMMJDJK_OverrideCenterSkill < 1 ? MOMCFBMJJKB_CenterSkill : DCOALMMJDJK_OverrideCenterSkill; } } //0x12F37A4 LJKILMHFCCK
	public bool CDEFLIHHNAB_HasSkills { get {
			int i = KKPLDFNDFDE_OverrideLiveSkill;
			if (i < 1)
				i = JMEGLFEKEBD_LiveSkill;
			if (i < 1)
				i = DCOALMMJDJK_OverrideCenterSkill;
			if (i < 1)
				i = MOMCFBMJJKB_CenterSkill;
			return i > 0;
		} } //0x12F37B8 NKOCPFCGNOG

	//// RVA: 0x12F37F4 Offset: 0x12F37F4 VA: 0x12F37F4
	public void KHEKNNFCAOI_Init(int _EJNIMIAPJFJ_Id, int IHKNHNKMGAD)
	{
		this.EJNIMIAPJFJ_Id = _EJNIMIAPJFJ_Id;
		JKPPKAHPPKH_life = IHKNHNKMGAD / 100;
		MHDFCLCMDKO_Enemy.CJLENGHPIDH_EnemyInfo dbEnnemy = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OPFBEAJJMJB_Enemy.INONDJKKOKG(_EJNIMIAPJFJ_Id);
		EAHPLCJMPHD_PId = dbEnnemy.EAHPLCJMPHD_PId;
		EELBHDJJJHH_Plt = dbEnnemy.EELBHDJJJHH_Plt;
		JMEGLFEKEBD_LiveSkill = dbEnnemy.EDLACELKJIK_LiveSkill;
		MOMCFBMJJKB_CenterSkill = dbEnnemy.NJOPIPNGANO_CS;
		ADMMEMNGKEN_Avo = dbEnnemy.ADMMEMNGKEN_Avo;
		OPFGFINHFCE_name = MessageManager.Instance.GetBank("master").GetMessageByLabel("e_nm_" + _EJNIMIAPJFJ_Id.ToString("D4"));
		KLMPFGOCBHC_description = MessageManager.Instance.GetBank("master").GetMessageByLabel("e_dsc_" + _EJNIMIAPJFJ_Id.ToString("D4"));
		NDPPEMCHKHA_LiveSkillName1 = "";
		if(KKPLDFNDFDE_OverrideLiveSkill > 0)
		{
			NDPPEMCHKHA_LiveSkillName1 = MessageManager.Instance.GetBank("master").GetMessageByLabel("el_nm_" + KKPLDFNDFDE_OverrideLiveSkill.ToString("D4"));
		}
		else if (JMEGLFEKEBD_LiveSkill != 0)
		{
			NDPPEMCHKHA_LiveSkillName1 = MessageManager.Instance.GetBank("master").GetMessageByLabel("el_nm_" + JMEGLFEKEBD_LiveSkill.ToString("D4"));
		}
		PFHJFIHGCKP_CenterSkillName = "";
		if (DCOALMMJDJK_OverrideCenterSkill > 0)
		{
			PFHJFIHGCKP_CenterSkillName = MessageManager.Instance.GetBank("master").GetMessageByLabel("ec_nm_" + DCOALMMJDJK_OverrideCenterSkill.ToString("D4"));
		}
		else if (MOMCFBMJJKB_CenterSkill != 0)
		{
			PFHJFIHGCKP_CenterSkillName = MessageManager.Instance.GetBank("master").GetMessageByLabel("ec_nm_" + MOMCFBMJJKB_CenterSkill.ToString("D4"));
		}
	}

	//// RVA: 0x12F3BD0 Offset: 0x12F3BD0 VA: 0x12F3BD0
	public void NPEKPHAFMGE_OverrideSkill(int DCOALMMJDJK_OverrideCenterSkill, int _KKPLDFNDFDE_OverrideLiveSkill)
	{
		this.KKPLDFNDFDE_OverrideLiveSkill = _KKPLDFNDFDE_OverrideLiveSkill;
		this.DCOALMMJDJK_OverrideCenterSkill = DCOALMMJDJK_OverrideCenterSkill;
		PFHJFIHGCKP_CenterSkillName = "";
		NDPPEMCHKHA_LiveSkillName1 = "";
		MessageBank bk = MessageManager.Instance.GetBank("master");
		if(_KKPLDFNDFDE_OverrideLiveSkill > 0)
		{
			NDPPEMCHKHA_LiveSkillName1 = bk.GetMessageByLabel("el_nm_" + _KKPLDFNDFDE_OverrideLiveSkill.ToString("D4"));
		}
		else if (JMEGLFEKEBD_LiveSkill != 0)
		{
			NDPPEMCHKHA_LiveSkillName1 = bk.GetMessageByLabel("el_nm_" + JMEGLFEKEBD_LiveSkill.ToString("D4"));
		}
		if(DCOALMMJDJK_OverrideCenterSkill > 0)
		{
			PFHJFIHGCKP_CenterSkillName = bk.GetMessageByLabel("ec_nm_" + DCOALMMJDJK_OverrideCenterSkill.ToString("D4"));
		}
		else if(MOMCFBMJJKB_CenterSkill != 0)
		{
			PFHJFIHGCKP_CenterSkillName = bk.GetMessageByLabel("ec_nm_" + MOMCFBMJJKB_CenterSkill.ToString("D4"));
		}
	}

	//// RVA: 0x12F3D94 Offset: 0x12F3D94 VA: 0x12F3D94
	//public void CCFGGCGKECF() { }
}
