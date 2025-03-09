
using XeSys;

[System.Obsolete("Use EJKBKMBJMGL_EnemyData", true)]
public class EJKBKMBJMGL { }
public class EJKBKMBJMGL_EnemyData
{
	public int EJNIMIAPJFJ = 0; // 0x8
	public int JKPPKAHPPKH = 0; // 0xC
	public int ADMMEMNGKEN_Avo = 0; // 0x10
	public int EAHPLCJMPHD_Pic = 0; // 0x14
	public int EELBHDJJJHH_Plt = 1; // 0x18
	public int JMEGLFEKEBD_LiveSkill = 1; // 0x1C
	public int MOMCFBMJJKB_CS = 1; // 0x20
	public string OPFGFINHFCE_Name; // 0x24
	public string KLMPFGOCBHC_Desc; // 0x28
	public string NDPPEMCHKHA_SkillName; // 0x2C
	public string PFHJFIHGCKP_CenterName; // 0x30
	public int DCOALMMJDJK_CenterSkill; // 0x34
	public int KKPLDFNDFDE_LiveSkill; // 0x38

	public int LMJFFFOEPLE { get { return KKPLDFNDFDE_LiveSkill < 1 ? JMEGLFEKEBD_LiveSkill : KKPLDFNDFDE_LiveSkill; } } //0x12F3790 CGIJHCKFOKG
	public int PDHCABLLJPB_SkillId { get { return DCOALMMJDJK_CenterSkill < 1 ? MOMCFBMJJKB_CS : DCOALMMJDJK_CenterSkill; } } //0x12F37A4 LJKILMHFCCK
	public bool CDEFLIHHNAB_HasSkills { get {
			int i = KKPLDFNDFDE_LiveSkill;
			if (i < 1)
				i = JMEGLFEKEBD_LiveSkill;
			if (i < 1)
				i = DCOALMMJDJK_CenterSkill;
			if (i < 1)
				i = MOMCFBMJJKB_CS;
			return i > 0;
		} } //0x12F37B8 NKOCPFCGNOG

	//// RVA: 0x12F37F4 Offset: 0x12F37F4 VA: 0x12F37F4
	public void KHEKNNFCAOI(int EJNIMIAPJFJ, int IHKNHNKMGAD)
	{
		this.EJNIMIAPJFJ = EJNIMIAPJFJ;
		JKPPKAHPPKH = IHKNHNKMGAD / 100;
		MHDFCLCMDKO_Enemy.CJLENGHPIDH_EnemyInfo dbEnnemy = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OPFBEAJJMJB_Enemy.INONDJKKOKG(EJNIMIAPJFJ);
		EAHPLCJMPHD_Pic = dbEnnemy.EAHPLCJMPHD_Pic;
		EELBHDJJJHH_Plt = dbEnnemy.EELBHDJJJHH_Plt;
		JMEGLFEKEBD_LiveSkill = dbEnnemy.EDLACELKJIK_LiveSkill;
		MOMCFBMJJKB_CS = dbEnnemy.NJOPIPNGANO_CS;
		ADMMEMNGKEN_Avo = dbEnnemy.ADMMEMNGKEN_Avo;
		OPFGFINHFCE_Name = MessageManager.Instance.GetBank("master").GetMessageByLabel("e_nm_" + EJNIMIAPJFJ.ToString("D4"));
		KLMPFGOCBHC_Desc = MessageManager.Instance.GetBank("master").GetMessageByLabel("e_dsc_" + EJNIMIAPJFJ.ToString("D4"));
		NDPPEMCHKHA_SkillName = "";
		if(KKPLDFNDFDE_LiveSkill > 0)
		{
			NDPPEMCHKHA_SkillName = MessageManager.Instance.GetBank("master").GetMessageByLabel("el_nm_" + KKPLDFNDFDE_LiveSkill.ToString("D4"));
		}
		else if (JMEGLFEKEBD_LiveSkill != 0)
		{
			NDPPEMCHKHA_SkillName = MessageManager.Instance.GetBank("master").GetMessageByLabel("el_nm_" + JMEGLFEKEBD_LiveSkill.ToString("D4"));
		}
		PFHJFIHGCKP_CenterName = "";
		if (DCOALMMJDJK_CenterSkill > 0)
		{
			PFHJFIHGCKP_CenterName = MessageManager.Instance.GetBank("master").GetMessageByLabel("ec_nm_" + DCOALMMJDJK_CenterSkill.ToString("D4"));
		}
		else if (MOMCFBMJJKB_CS != 0)
		{
			PFHJFIHGCKP_CenterName = MessageManager.Instance.GetBank("master").GetMessageByLabel("ec_nm_" + MOMCFBMJJKB_CS.ToString("D4"));
		}
	}

	//// RVA: 0x12F3BD0 Offset: 0x12F3BD0 VA: 0x12F3BD0
	public void NPEKPHAFMGE(int DCOALMMJDJK, int KKPLDFNDFDE)
	{
		this.KKPLDFNDFDE_LiveSkill = KKPLDFNDFDE;
		this.DCOALMMJDJK_CenterSkill = DCOALMMJDJK;
		PFHJFIHGCKP_CenterName = "";
		NDPPEMCHKHA_SkillName = "";
		MessageBank bk = MessageManager.Instance.GetBank("master");
		if(KKPLDFNDFDE > 0)
		{
			NDPPEMCHKHA_SkillName = bk.GetMessageByLabel("el_nm_" + KKPLDFNDFDE.ToString("D4"));
		}
		else if (JMEGLFEKEBD_LiveSkill != 0)
		{
			NDPPEMCHKHA_SkillName = bk.GetMessageByLabel("el_nm_" + JMEGLFEKEBD_LiveSkill.ToString("D4"));
		}
		if(DCOALMMJDJK > 0)
		{
			PFHJFIHGCKP_CenterName = bk.GetMessageByLabel("ec_nm_" + DCOALMMJDJK.ToString("D4"));
		}
		else if(MOMCFBMJJKB_CS != 0)
		{
			PFHJFIHGCKP_CenterName = bk.GetMessageByLabel("ec_nm_" + MOMCFBMJJKB_CS.ToString("D4"));
		}
	}

	//// RVA: 0x12F3D94 Offset: 0x12F3D94 VA: 0x12F3D94
	//public void CCFGGCGKECF() { }
}
