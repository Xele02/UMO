
using System.Collections.Generic;
using System.Text;
using XeApp.Game.Common;
using XeSys;

public class CKFGMNAIBNG
{
	public int ECNEBGLPECK; // 0x8
	public int FBGGEFFJJHB_xor; // 0xC
	public string OPFGFINHFCE_name; // 0x10
	public string GMOBAMGOLHB_SkillName; // 0x14
	public string FCEGELPJAMH_SkillDesc; // 0x18
	private short[] EOGIFMAPOPA_ColsAvaiableFlags_Crypted; // 0x1C
	public bool[] EJODLFBKFDK_IsNewColor; // 0x20
	public bool FJODMPGPDDD_Unlocked; // 0x24
	public int HCFNIMFOOPF_SkillIdCrypted; // 0x28
	public int NNAPJKPBBKI_Crypted; // 0x2C
	public int HNJNKCPDKAL_CryptedModelId; // 0x30
	public int CGIGOFKGCII_CryptedDivaId; // 0x34
	public int HFJLOKDMJHI_CostumeIdCrypted; // 0x38
	public int LMMCLBNCBIO_CryptedLevel; // 0x3C
	public int NPCEOIJLNGB_Crypted; // 0x40

	public int ENMAEBJGEKL_SkillId { get { return HCFNIMFOOPF_SkillIdCrypted ^ FBGGEFFJJHB_xor; } set { HCFNIMFOOPF_SkillIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x107DE8C FHIMMFAEDIP 0x107DE9C CPEAMPGOMCB
	public int DEOBDFOPLHG_SkillLevel { get { return NNAPJKPBBKI_Crypted ^ FBGGEFFJJHB_xor; } set { NNAPJKPBBKI_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x107DEAC LHFCGJBCDEE 0x107DEBC OAGOCCBEFPD
	public int DAJGPBLEEOB_ModelId { get { return FBGGEFFJJHB_xor ^ HNJNKCPDKAL_CryptedModelId; } set { HNJNKCPDKAL_CryptedModelId = FBGGEFFJJHB_xor ^ value; } } //0x107DECC LHPKEPPBKPF 0x107DEDC OIOEEEDODJA
	public int AHHJLDLAPAN_DivaId { get { return CGIGOFKGCII_CryptedDivaId ^ FBGGEFFJJHB_xor; } set { CGIGOFKGCII_CryptedDivaId = FBGGEFFJJHB_xor ^ value; } } //0x107DEEC IPKDLMIDMHH 0x107DEFC IENNENMKEFO
	public int JPIDIENBGKH_CostumeId { get { return HFJLOKDMJHI_CostumeIdCrypted ^ FBGGEFFJJHB_xor; } set { HFJLOKDMJHI_CostumeIdCrypted = FBGGEFFJJHB_xor ^ value; } } //0x107DF0C PHLLMIGCPCB 0x107DF1C BLBNMENMCIF
	public int GKIKAABHAAD_Level { get { return LMMCLBNCBIO_CryptedLevel ^ FBGGEFFJJHB_xor; } set { LMMCLBNCBIO_CryptedLevel = FBGGEFFJJHB_xor ^ value; } } //0x107DF2C JNDLKKLLAMO 0x107DF3C PBOBJNPNBHG
	public int EGLDFPILJLG_SkillBuffEffect { get { return NPCEOIJLNGB_Crypted ^ FBGGEFFJJHB_xor; } set { NPCEOIJLNGB_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x107DF4C JACADMEJOAH 0x107DF5C MMDBFGAFINM
	// public bool LFLNFHKOIIM { get; }

	// // RVA: 0x107DF6C Offset: 0x107DF6C VA: 0x107DF6C
	public short LLJPMOIPBAG(int _BMBBDIAEOMP_i)
	{
		return (short)(ECNEBGLPECK ^ EOGIFMAPOPA_ColsAvaiableFlags_Crypted[_BMBBDIAEOMP_i]);
	}

	// // RVA: 0x107DFC4 Offset: 0x107DFC4 VA: 0x107DFC4
	public int NLKGAAFBDFK()
	{
		return EOGIFMAPOPA_ColsAvaiableFlags_Crypted.Length;
	}

	// // RVA: 0x107DFE8 Offset: 0x107DFE8 VA: 0x107DFE8
	public CKFGMNAIBNG()
    {
        FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA();
        ECNEBGLPECK = LPDNKHAIOLH.CEIBAFOCNCA() & 0x7fff;
        ENMAEBJGEKL_SkillId = 0;
        DEOBDFOPLHG_SkillLevel = 0;
        DAJGPBLEEOB_ModelId = 0;
        JPIDIENBGKH_CostumeId = 0;
        GKIKAABHAAD_Level = 0;
        EGLDFPILJLG_SkillBuffEffect = 0;
    }

	// // RVA: 0x107E0A4 Offset: 0x107E0A4 VA: 0x107E0A4
	public void KHEKNNFCAOI_Init(int AHHJLDLAPAN_DivaId, int JPIDIENBGKH_CostumeId, int GKIKAABHAAD, bool OJEBNBLHPNP/* = false*/)
    {
        LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cosInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_GetUnlockedCostumeOrDefault(AHHJLDLAPAN_DivaId, JPIDIENBGKH_CostumeId);
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
		{
			this.JPIDIENBGKH_CostumeId = JPIDIENBGKH_CostumeId;
			ENMAEBJGEKL_SkillId = cosInfo.HGHFFJKGNCO_SkillId;
			this.AHHJLDLAPAN_DivaId = AHHJLDLAPAN_DivaId;
			DAJGPBLEEOB_ModelId = cosInfo.DAJGPBLEEOB_ModelId;
            EBFLJMOCLNA_Costume.ILFJDCICIKN dbCostumeId = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(cosInfo.JPIDIENBGKH_CostumeId);
			FJODMPGPDDD_Unlocked = dbCostumeId.CGKAEMGLHNK_Possessed();
			this.GKIKAABHAAD_Level = GKIKAABHAAD;
			DEOBDFOPLHG_SkillLevel = cosInfo.DOGKAEAHIMI_GetUnlockedSkillLevel(GKIKAABHAAD);
			EGLDFPILJLG_SkillBuffEffect = cosInfo.EGLDFPILJLG_SkillBuffEffect;
			short[] colsAvaiable;
			if(!OJEBNBLHPNP)
			{
				colsAvaiable = cosInfo.KKLPLPGBOFD_GetAvaiableColor(GKIKAABHAAD_Level);
			}
			else
			{
				colsAvaiable = cosInfo.CHDBGFLFPNC_GetAllAvaiableColors();
			}
			EJODLFBKFDK_IsNewColor = new bool[colsAvaiable.Length];
			EOGIFMAPOPA_ColsAvaiableFlags_Crypted = new short[colsAvaiable.Length];
			for(int i = 0; i < colsAvaiable.Length; i++)
			{
				EOGIFMAPOPA_ColsAvaiableFlags_Crypted[i] = (short)(ECNEBGLPECK ^ colsAvaiable[i]);
			}
			StringBuilder str = new StringBuilder(16);
			str.SetFormat("cos_{0:D4}", cosInfo.JPIDIENBGKH_CostumeId);
			OPFGFINHFCE_name = MessageManager.Instance.GetBank("master").GetMessageByLabel(str.ToString());
			OHGOPFEOJOG_GetSkillInfo(cosInfo, MessageManager.Instance.GetBank("master"), str, ENMAEBJGEKL_SkillId, DEOBDFOPLHG_SkillLevel, ref GMOBAMGOLHB_SkillName, ref FCEGELPJAMH_SkillDesc);
        }
	}

	// // RVA: 0x107EB24 Offset: 0x107EB24 VA: 0x107EB24
	public void KHEKNNFCAOI_Init(int AHHJLDLAPAN_DivaId, int _JPIDIENBGKH_CostumeId, BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData, bool OJEBNBLHPNP/* = false*/)
    {
		KHEKNNFCAOI_Init(AHHJLDLAPAN_DivaId, _JPIDIENBGKH_CostumeId, _AHEFHIMGIBI_PlayerData.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_GetUnlockedCostumeOrDefault(AHHJLDLAPAN_DivaId, _JPIDIENBGKH_CostumeId).JPIDIENBGKH_CostumeId).ANAJIAENLNB_Level, OJEBNBLHPNP);
		CEHICAFELBI(_AHEFHIMGIBI_PlayerData);
	}

	// // RVA: 0x107E604 Offset: 0x107E604 VA: 0x107E604
	private static void OHGOPFEOJOG_GetSkillInfo(LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo _NDFIEMPPMLF_master, MessageBank GDMBMJBMNME, StringBuilder JEHFDJPOEFF, int HDHANIEDJPA, int _DEOBDFOPLHG_SkillLevel, ref string _OPFGFINHFCE_name, ref string _HCAHCFGPJIF_Desc)
	{
		if(_NDFIEMPPMLF_master.HGHFFJKGNCO_SkillId == 0)
		{
			_OPFGFINHFCE_name = TextConstant.InvalidText;
		}
		else
		{
			HBDCPGLAPHH h = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.BIOEJKBCIKD_CenterSkillCostume[HDHANIEDJPA - 1];
			int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.EBKAAEDMIBI_CostumeEffectInfo[h.HEKHODDJHAO_P1 - 1].KCOHMHFBDKF_Value1[_DEOBDFOPLHG_SkillLevel - 1];
			if(a > 0)
			{
				StringBuilder str = new StringBuilder(32);
				JEHFDJPOEFF.SetFormat("cs_nm_{0:D4}", _NDFIEMPPMLF_master.HGHFFJKGNCO_SkillId);
				str.SetFormat(GDMBMJBMNME.GetMessageByLabel(JEHFDJPOEFF.ToString()), a);
				_OPFGFINHFCE_name = str.ToString();

				JEHFDJPOEFF.SetFormat("cs_dsc_{0:D4}", _NDFIEMPPMLF_master.HGHFFJKGNCO_SkillId);
				str.SetFormat(GDMBMJBMNME.GetMessageByLabel(JEHFDJPOEFF.ToString()), a);
				_HCAHCFGPJIF_Desc = str.ToString();
				return;
			}
			_OPFGFINHFCE_name = TextConstant.InvalidText;
		}
		_HCAHCFGPJIF_Desc = TextConstant.InvalidText;
	}

	// // RVA: 0x107EDDC Offset: 0x107EDDC VA: 0x107EDDC
	public void OHGOPFEOJOG_GetSkillInfo(int GHDGALFNGFJ, ref string _OPFGFINHFCE_name, ref string _HCAHCFGPJIF_Desc)
	{
		LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cosInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_GetUnlockedCostumeOrDefault(AHHJLDLAPAN_DivaId, JPIDIENBGKH_CostumeId);
		OHGOPFEOJOG_GetSkillInfo(cosInfo, MessageManager.Instance.GetBank("master"), new StringBuilder(32), ENMAEBJGEKL_SkillId, cosInfo.DOGKAEAHIMI_GetUnlockedSkillLevel(GHDGALFNGFJ), ref _OPFGFINHFCE_name, ref _HCAHCFGPJIF_Desc);
	}

	// // RVA: 0x107EFA0 Offset: 0x107EFA0 VA: 0x107EFA0
	// public bool LMHEGNBODJG() { }

	// // RVA: 0x107EFCC Offset: 0x107EFCC VA: 0x107EFCC
	public string HCPCHEPCFEA_GetCostumeName(int LEHGKNOCLBG)
	{
		string res = "";
		if (LEHGKNOCLBG == 0)
		{
			res = OPFGFINHFCE_name;
		}
		else
		{
			MessageBank bank = MessageManager.Instance.GetBank("master");
			StringBuilder str = new StringBuilder(16);
			str.SetFormat("cos_{0:D4}_{1:D2}", JPIDIENBGKH_CostumeId, LEHGKNOCLBG);
			res = bank.GetMessageByLabel(str.ToString());
		}
		if(RuntimeSettings.CurrentSettings.DisplayIdInName)
			res = "[" + JPIDIENBGKH_CostumeId + "/"+ DAJGPBLEEOB_ModelId +"] "+res;
		return res;
	}

	// // RVA: 0x107ECCC Offset: 0x107ECCC VA: 0x107ECCC
	public void CEHICAFELBI(BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData)
	{
		if(JPIDIENBGKH_CostumeId > 0)
		{
			EBFLJMOCLNA_Costume.ILFJDCICIKN saveCostume = _AHEFHIMGIBI_PlayerData.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(JPIDIENBGKH_CostumeId);
			for(int i = 0; i < EOGIFMAPOPA_ColsAvaiableFlags_Crypted.Length; i++)
			{
				EJODLFBKFDK_IsNewColor[i] = saveCostume.EJODLFBKFDK_IsNewColor(LLJPMOIPBAG(i));
			}
		}
	}

	// // RVA: 0x107F14C Offset: 0x107F14C VA: 0x107F14C
	public void PDADHMIODCA(BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData, int _HEHKNMCDBJJ_ColorId, bool _JKDJCFEBDHC_Enabled)
	{
		int idx = -1;
		for(int i = 0; i < EOGIFMAPOPA_ColsAvaiableFlags_Crypted.Length; i++)
		{
			if(_HEHKNMCDBJJ_ColorId == LLJPMOIPBAG(i))
			{
				idx = i;
				break;
			}
		}
		EJODLFBKFDK_IsNewColor[idx] = _JKDJCFEBDHC_Enabled;
		_AHEFHIMGIBI_PlayerData.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(JPIDIENBGKH_CostumeId).PDADHMIODCA(_HEHKNMCDBJJ_ColorId, _JKDJCFEBDHC_Enabled);
	}

	// // RVA: 0x107F26C Offset: 0x107F26C VA: 0x107F26C
	public void PDADHMIODCA(int _HEHKNMCDBJJ_ColorId, bool _JKDJCFEBDHC_Enabled)
	{
		PDADHMIODCA(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, _HEHKNMCDBJJ_ColorId, _JKDJCFEBDHC_Enabled);
	}

	// // RVA: 0x107F330 Offset: 0x107F330 VA: 0x107F330
	public static List<CKFGMNAIBNG> NEOMKKIEMJJ(BBHNACPENDM_ServerSaveData _KPMOBPNENCD_serverData, bool OJEBNBLHPNP/* = false*/, bool NHMPDLNPBJD/* = false*/)
	{
		List<CKFGMNAIBNG> cosList = new List<CKFGMNAIBNG>();
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_table.Count; i++)
		{
			LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo dbCos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_table[i];
			EBFLJMOCLNA_Costume.ILFJDCICIKN saveCos = _KPMOBPNENCD_serverData.BEKHNNCGIEL_Costume.FABAGMLEKIB_CostumeList[i];
			if (!OJEBNBLHPNP)
			{
				if (dbCos.PPEGAKEIEGM_Enabled == 2)
				{
					if (NHMPDLNPBJD)
					{
						if (dbCos.EODICFLJAKO)
							continue;
					}
					if (dbCos.DAJGPBLEEOB_ModelId == 1)
					{
						if (_KPMOBPNENCD_serverData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(dbCos.AHHJLDLAPAN_DivaId).CPGFPEDMDEH_Have != 0)
						{
							//LAB_0107f50c
							CKFGMNAIBNG data = new CKFGMNAIBNG();
							data.KHEKNNFCAOI_Init(dbCos.AHHJLDLAPAN_DivaId, dbCos.JPIDIENBGKH_CostumeId, _KPMOBPNENCD_serverData, OJEBNBLHPNP);
							data.FJODMPGPDDD_Unlocked = true;
							cosList.Add(data);
						}
					}
					else
					{
						if(saveCos.CGKAEMGLHNK_Possessed())
						{
							//LAB_0107f50c
							CKFGMNAIBNG data = new CKFGMNAIBNG();
							data.KHEKNNFCAOI_Init(dbCos.AHHJLDLAPAN_DivaId, dbCos.JPIDIENBGKH_CostumeId, _KPMOBPNENCD_serverData, OJEBNBLHPNP);
							data.FJODMPGPDDD_Unlocked = true;
							cosList.Add(data);
						}
					}
				}
			}
			else
			{
				//LAB_0107f50c
				CKFGMNAIBNG data = new CKFGMNAIBNG();
				data.KHEKNNFCAOI_Init(dbCos.AHHJLDLAPAN_DivaId, dbCos.JPIDIENBGKH_CostumeId, _KPMOBPNENCD_serverData, OJEBNBLHPNP);
				data.FJODMPGPDDD_Unlocked = true;
				cosList.Add(data);
			}
		}
		return cosList;
	}

	// // RVA: 0x107F7B4 Offset: 0x107F7B4 VA: 0x107F7B4
	public static string EJOJNFDHDHN_GetCostumeName(int _AHHJLDLAPAN_DivaId, int _JPIDIENBGKH_CostumeId)
	{
		return MessageManager.Instance.GetMessage("master", "cos_" + IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_GetUnlockedCostumeOrDefault(_AHHJLDLAPAN_DivaId, _JPIDIENBGKH_CostumeId).JPIDIENBGKH_CostumeId.ToString("D4"));
	}

	// // RVA: 0x107F958 Offset: 0x107F958 VA: 0x107F958 Slot: 3
	// public override string ToString() { }

	// // RVA: 0x107FA20 Offset: 0x107FA20 VA: 0x107FA20
	public static int LLJPMOIPBAG(int _AHHJLDLAPAN_DivaId, int _JPIDIENBGKH_CostumeId, int _ANAJIAENLNB_Level)
	{
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_GetUnlockedCostumeOrDefault(_AHHJLDLAPAN_DivaId, _JPIDIENBGKH_CostumeId).LLJPMOIPBAG_GetColorForLevel(_ANAJIAENLNB_Level);
	}

	// // RVA: 0x107FB34 Offset: 0x107FB34 VA: 0x107FB34
	public static int MHIKGGMOPOJ(int _AHHJLDLAPAN_DivaId, int _JPIDIENBGKH_CostumeId, int _HEHKNMCDBJJ_ColorId)
	{
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_GetUnlockedCostumeOrDefault(_AHHJLDLAPAN_DivaId, _JPIDIENBGKH_CostumeId).MHIKGGMOPOJ(_HEHKNMCDBJJ_ColorId);
	}
}
