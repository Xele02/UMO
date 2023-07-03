
using System.Collections.Generic;
using System.Text;
using XeApp.Game.Common;
using XeSys;

public class CKFGMNAIBNG
{
	public int ECNEBGLPECK; // 0x8
	public int FBGGEFFJJHB; // 0xC
	public string OPFGFINHFCE_Name; // 0x10
	public string GMOBAMGOLHB_SkillName; // 0x14
	public string FCEGELPJAMH_SkillDesc; // 0x18
	private short[] EOGIFMAPOPA_ColsAvaiableFlags_Crypted; // 0x1C
	public bool[] EJODLFBKFDK_ColNewflags; // 0x20
	public bool FJODMPGPDDD_Possessed; // 0x24
	public int HCFNIMFOOPF_SkillIdCrypted; // 0x28
	public int NNAPJKPBBKI_Crypted; // 0x2C
	public int HNJNKCPDKAL_PrismCostumeId_CryptedPrismCostumeId; // 0x30
	public int CGIGOFKGCII_CryptedDivaId; // 0x34
	public int HFJLOKDMJHI_CryptedCostumeId; // 0x38
	public int LMMCLBNCBIO_CryptedLevel; // 0x3C
	public int NPCEOIJLNGB_Crypted; // 0x40

	public int ENMAEBJGEKL_SkillId { get { return HCFNIMFOOPF_SkillIdCrypted ^ FBGGEFFJJHB; } set { HCFNIMFOOPF_SkillIdCrypted = value ^ FBGGEFFJJHB; } } //0x107DE8C FHIMMFAEDIP 0x107DE9C CPEAMPGOMCB
	public int DEOBDFOPLHG_SkillLevel { get { return NNAPJKPBBKI_Crypted ^ FBGGEFFJJHB; } set { NNAPJKPBBKI_Crypted = value ^ FBGGEFFJJHB; } } //0x107DEAC LHFCGJBCDEE 0x107DEBC OAGOCCBEFPD
	public int DAJGPBLEEOB_PrismCostumeId { get { return FBGGEFFJJHB ^ HNJNKCPDKAL_PrismCostumeId_CryptedPrismCostumeId; } set { HNJNKCPDKAL_PrismCostumeId_CryptedPrismCostumeId = FBGGEFFJJHB ^ value; } } //0x107DECC LHPKEPPBKPF 0x107DEDC OIOEEEDODJA
	public int AHHJLDLAPAN_DivaId { get { return CGIGOFKGCII_CryptedDivaId ^ FBGGEFFJJHB; } set { CGIGOFKGCII_CryptedDivaId = FBGGEFFJJHB ^ value; } } //0x107DEEC IPKDLMIDMHH 0x107DEFC IENNENMKEFO
	public int JPIDIENBGKH_CostumeId { get { return HFJLOKDMJHI_CryptedCostumeId ^ FBGGEFFJJHB; } set { HFJLOKDMJHI_CryptedCostumeId = FBGGEFFJJHB ^ value; } } //0x107DF0C PHLLMIGCPCB 0x107DF1C BLBNMENMCIF
	public int GKIKAABHAAD_Level { get { return LMMCLBNCBIO_CryptedLevel ^ FBGGEFFJJHB; } set { LMMCLBNCBIO_CryptedLevel = FBGGEFFJJHB ^ value; } } //0x107DF2C JNDLKKLLAMO 0x107DF3C PBOBJNPNBHG
	public int EGLDFPILJLG { get { return NPCEOIJLNGB_Crypted ^ FBGGEFFJJHB; } set { NPCEOIJLNGB_Crypted = value ^ FBGGEFFJJHB; } } //0x107DF4C JACADMEJOAH 0x107DF5C MMDBFGAFINM
	// public bool LFLNFHKOIIM { get; }

	// // RVA: 0x107DF6C Offset: 0x107DF6C VA: 0x107DF6C
	public short LLJPMOIPBAG(int BMBBDIAEOMP)
	{
		return (short)(ECNEBGLPECK ^ EOGIFMAPOPA_ColsAvaiableFlags_Crypted[BMBBDIAEOMP]);
	}

	// // RVA: 0x107DFC4 Offset: 0x107DFC4 VA: 0x107DFC4
	public int NLKGAAFBDFK()
	{
		return EOGIFMAPOPA_ColsAvaiableFlags_Crypted.Length;
	}

	// // RVA: 0x107DFE8 Offset: 0x107DFE8 VA: 0x107DFE8
	public CKFGMNAIBNG()
    {
        FBGGEFFJJHB = LPDNKHAIOLH.CEIBAFOCNCA();
        ECNEBGLPECK = LPDNKHAIOLH.CEIBAFOCNCA() & 0x7fff;
        ENMAEBJGEKL_SkillId = 0;
        DEOBDFOPLHG_SkillLevel = 0;
        DAJGPBLEEOB_PrismCostumeId = 0;
        JPIDIENBGKH_CostumeId = 0;
        GKIKAABHAAD_Level = 0;
        EGLDFPILJLG = 0;
    }

	// // RVA: 0x107E0A4 Offset: 0x107E0A4 VA: 0x107E0A4
	public void KHEKNNFCAOI(int AHHJLDLAPAN_DivaId, int JPIDIENBGKH_CostumeId, int GKIKAABHAAD, bool OJEBNBLHPNP = false)
    {
        LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cosInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_GetUnlockedCostumeOrDefault(AHHJLDLAPAN_DivaId, JPIDIENBGKH_CostumeId);
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
		{
			this.JPIDIENBGKH_CostumeId = JPIDIENBGKH_CostumeId;
			ENMAEBJGEKL_SkillId = cosInfo.HGHFFJKGNCO_SkillId;
			this.AHHJLDLAPAN_DivaId = AHHJLDLAPAN_DivaId;
			DAJGPBLEEOB_PrismCostumeId = cosInfo.DAJGPBLEEOB_PrismCostumeModelId;
            EBFLJMOCLNA_Costume.ILFJDCICIKN dbCostumeId = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(cosInfo.JPIDIENBGKH_CostumeId);
			FJODMPGPDDD_Possessed = dbCostumeId.CGKAEMGLHNK_Possessed();
			this.GKIKAABHAAD_Level = GKIKAABHAAD;
			DEOBDFOPLHG_SkillLevel = cosInfo.DOGKAEAHIMI_GetUnlockedSkillLevel(GKIKAABHAAD);
			EGLDFPILJLG = cosInfo.EGLDFPILJLG;
			short[] colsAvaiable;
			if(!OJEBNBLHPNP)
			{
				colsAvaiable = cosInfo.KKLPLPGBOFD_GetAvaiableColor(GKIKAABHAAD_Level);
			}
			else
			{
				colsAvaiable = cosInfo.CHDBGFLFPNC_GetAllAvaiableColors();
			}
			EJODLFBKFDK_ColNewflags = new bool[colsAvaiable.Length];
			EOGIFMAPOPA_ColsAvaiableFlags_Crypted = new short[colsAvaiable.Length];
			for(int i = 0; i < colsAvaiable.Length; i++)
			{
				EOGIFMAPOPA_ColsAvaiableFlags_Crypted[i] = (short)(ECNEBGLPECK ^ colsAvaiable[i]);
			}
			StringBuilder str = new StringBuilder(16);
			str.SetFormat("cos_{0:D4}", cosInfo.JPIDIENBGKH_CostumeId);
			OPFGFINHFCE_Name = MessageManager.Instance.GetBank("master").GetMessageByLabel(str.ToString());
			OHGOPFEOJOG_GetSkillInfo(cosInfo, MessageManager.Instance.GetBank("master"), str, ENMAEBJGEKL_SkillId, DEOBDFOPLHG_SkillLevel, ref GMOBAMGOLHB_SkillName, ref FCEGELPJAMH_SkillDesc);
        }
	}

	// // RVA: 0x107EB24 Offset: 0x107EB24 VA: 0x107EB24
	public void KHEKNNFCAOI(int AHHJLDLAPAN_DivaId, int JPIDIENBGKH_CostumeId, BBHNACPENDM_ServerSaveData AHEFHIMGIBI, bool OJEBNBLHPNP = false)
    {
		KHEKNNFCAOI(AHHJLDLAPAN_DivaId, JPIDIENBGKH_CostumeId, AHEFHIMGIBI.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_GetUnlockedCostumeOrDefault(AHHJLDLAPAN_DivaId, JPIDIENBGKH_CostumeId).JPIDIENBGKH_CostumeId).ANAJIAENLNB_Level, OJEBNBLHPNP);
		CEHICAFELBI(AHEFHIMGIBI);
	}

	// // RVA: 0x107E604 Offset: 0x107E604 VA: 0x107E604
	private static void OHGOPFEOJOG_GetSkillInfo(LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo NDFIEMPPMLF, MessageBank GDMBMJBMNME, StringBuilder JEHFDJPOEFF, int HDHANIEDJPA, int DEOBDFOPLHG, ref string OPFGFINHFCE_Name, ref string HCAHCFGPJIF_Desc)
	{
		if(NDFIEMPPMLF.HGHFFJKGNCO_SkillId == 0)
		{
			OPFGFINHFCE_Name = TextConstant.InvalidText;
		}
		else
		{
			HBDCPGLAPHH h = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.BIOEJKBCIKD_CenterSkillCostume[HDHANIEDJPA - 1];
			int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.EBKAAEDMIBI_CostumeEffectInfo[h.HEKHODDJHAO_P1 - 1].KCOHMHFBDKF_ValueByLevel[DEOBDFOPLHG - 1];
			if(a > 0)
			{
				StringBuilder str = new StringBuilder(32);
				JEHFDJPOEFF.SetFormat("cs_nm_{0:D4}", NDFIEMPPMLF.HGHFFJKGNCO_SkillId);
				str.SetFormat(GDMBMJBMNME.GetMessageByLabel(JEHFDJPOEFF.ToString()), a);
				OPFGFINHFCE_Name = str.ToString();

				JEHFDJPOEFF.SetFormat("cs_dsc_{0:D4}", NDFIEMPPMLF.HGHFFJKGNCO_SkillId);
				str.SetFormat(GDMBMJBMNME.GetMessageByLabel(JEHFDJPOEFF.ToString()), a);
				HCAHCFGPJIF_Desc = str.ToString();
			}
			OPFGFINHFCE_Name = TextConstant.InvalidText;
		}
		HCAHCFGPJIF_Desc = TextConstant.InvalidText;
	}

	// // RVA: 0x107EDDC Offset: 0x107EDDC VA: 0x107EDDC
	public void OHGOPFEOJOG_GetSkillInfo(int GHDGALFNGFJ, ref string OPFGFINHFCE, ref string HCAHCFGPJIF)
	{
		LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cosInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_GetUnlockedCostumeOrDefault(AHHJLDLAPAN_DivaId, JPIDIENBGKH_CostumeId);
		OHGOPFEOJOG_GetSkillInfo(cosInfo, MessageManager.Instance.GetBank("master"), new StringBuilder(32), ENMAEBJGEKL_SkillId, cosInfo.DOGKAEAHIMI_GetUnlockedSkillLevel(GHDGALFNGFJ), ref OPFGFINHFCE, ref HCAHCFGPJIF);
	}

	// // RVA: 0x107EFA0 Offset: 0x107EFA0 VA: 0x107EFA0
	// public bool LMHEGNBODJG() { }

	// // RVA: 0x107EFCC Offset: 0x107EFCC VA: 0x107EFCC
	public string HCPCHEPCFEA_GetCostumeName(int LEHGKNOCLBG)
	{
		if (LEHGKNOCLBG == 0)
			return OPFGFINHFCE_Name;
		MessageBank bank = MessageManager.Instance.GetBank("master");
		StringBuilder str = new StringBuilder(16);
		str.SetFormat("cos_{0:D4}_{1:D2}", JPIDIENBGKH_CostumeId, LEHGKNOCLBG);
		return bank.GetMessageByLabel(str.ToString());
	}

	// // RVA: 0x107ECCC Offset: 0x107ECCC VA: 0x107ECCC
	public void CEHICAFELBI(BBHNACPENDM_ServerSaveData AHEFHIMGIBI)
	{
		if(JPIDIENBGKH_CostumeId > 0)
		{
			EBFLJMOCLNA_Costume.ILFJDCICIKN saveCostume = AHEFHIMGIBI.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(JPIDIENBGKH_CostumeId);
			for(int i = 0; i < EOGIFMAPOPA_ColsAvaiableFlags_Crypted.Length; i++)
			{
				EJODLFBKFDK_ColNewflags[i] = saveCostume.EJODLFBKFDK_IsNewColor(LLJPMOIPBAG(i));
			}
		}
	}

	// // RVA: 0x107F14C Offset: 0x107F14C VA: 0x107F14C
	// public void PDADHMIODCA(BBHNACPENDM AHEFHIMGIBI, int HEHKNMCDBJJ, bool JKDJCFEBDHC) { }

	// // RVA: 0x107F26C Offset: 0x107F26C VA: 0x107F26C
	public void PDADHMIODCA(int HEHKNMCDBJJ, bool JKDJCFEBDHC)
	{
		TodoLogger.Log(0, "PDADHMIODCA");
	}

	// // RVA: 0x107F330 Offset: 0x107F330 VA: 0x107F330
	public static List<CKFGMNAIBNG> NEOMKKIEMJJ(BBHNACPENDM_ServerSaveData KPMOBPNENCD, bool OJEBNBLHPNP = false, bool NHMPDLNPBJD = false)
	{
		List<CKFGMNAIBNG> cosList = new List<CKFGMNAIBNG>();
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes.Count; i++)
		{
			LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo dbCos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[i];
			EBFLJMOCLNA_Costume.ILFJDCICIKN saveCos = KPMOBPNENCD.BEKHNNCGIEL_Costume.FABAGMLEKIB_List[i];
			if (!OJEBNBLHPNP)
			{
				if (dbCos.PPEGAKEIEGM_Enabled == 2)
				{
					if (NHMPDLNPBJD)
					{
						if (dbCos.EODICFLJAKO)
							continue;
					}
					if (dbCos.DAJGPBLEEOB_PrismCostumeModelId == 1)
					{
						if (KPMOBPNENCD.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(dbCos.AHHJLDLAPAN_PrismDivaId).CPGFPEDMDEH_Have != 0)
						{
							//LAB_0107f50c
							CKFGMNAIBNG data = new CKFGMNAIBNG();
							data.KHEKNNFCAOI(dbCos.AHHJLDLAPAN_PrismDivaId, dbCos.JPIDIENBGKH_CostumeId, KPMOBPNENCD, OJEBNBLHPNP);
							data.FJODMPGPDDD_Possessed = true;
							cosList.Add(data);
						}
					}
					else
					{
						if(saveCos.CGKAEMGLHNK_Possessed())
						{
							//LAB_0107f50c
							CKFGMNAIBNG data = new CKFGMNAIBNG();
							data.KHEKNNFCAOI(dbCos.AHHJLDLAPAN_PrismDivaId, dbCos.JPIDIENBGKH_CostumeId, KPMOBPNENCD, OJEBNBLHPNP);
							data.FJODMPGPDDD_Possessed = true;
							cosList.Add(data);
						}
					}
				}
			}
			else
			{
				//LAB_0107f50c
				CKFGMNAIBNG data = new CKFGMNAIBNG();
				data.KHEKNNFCAOI(dbCos.AHHJLDLAPAN_PrismDivaId, dbCos.JPIDIENBGKH_CostumeId, KPMOBPNENCD, OJEBNBLHPNP);
				data.FJODMPGPDDD_Possessed = true;
				cosList.Add(data);
			}
		}
		return cosList;
	}

	// // RVA: 0x107F7B4 Offset: 0x107F7B4 VA: 0x107F7B4
	// public static string EJOJNFDHDHN(int AHHJLDLAPAN, int JPIDIENBGKH) { }

	// // RVA: 0x107F958 Offset: 0x107F958 VA: 0x107F958 Slot: 3
	// public override string ToString() { }

	// // RVA: 0x107FA20 Offset: 0x107FA20 VA: 0x107FA20
	public static int LLJPMOIPBAG(int AHHJLDLAPAN, int JPIDIENBGKH, int ANAJIAENLNB)
	{
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_GetUnlockedCostumeOrDefault(AHHJLDLAPAN, JPIDIENBGKH).LLJPMOIPBAG_GetColorForLevel(ANAJIAENLNB);
	}

	// // RVA: 0x107FB34 Offset: 0x107FB34 VA: 0x107FB34
	// public static int MHIKGGMOPOJ(int AHHJLDLAPAN, int JPIDIENBGKH, int HEHKNMCDBJJ) { }
}
