
using System.Collections.Generic;
using XeApp.Game.Common;

[System.Obsolete("Use JNKEEAOKNCI_Skill", true)]
public class JNKEEAOKNCI { }
public class JNKEEAOKNCI_Skill : DIHHCBACKGG_DbSection
{
	public enum MKGJHBAKMBD_SkillType
	{
		MHKFDBLMOGF_Scene = 0,
		AIFGINAKBMA_EnemySkill = 1,
		KBHGPMNGALJ_CostumeSkill = 2,
	}
	private const int LKIDINCKEIO = 999;
	private const int LADJALDCEFH = 999;
	private const int JDIBNEBPNOO = 999;
	private const int BDEKKNPBAFK = 999;
	private const int KLLOOJHHFDB = 999;
	private const int JCOMLCCFPLN = 999;
	private const int OACJPPFDDME = 999;
	private const int DLJDONNFDGI = 999;
	private const int AFNICLNNOBF = 999;

	public List<HBDCPGLAPHH> COLCPGFABLP_CenterSkills { get; private set; } // 0x20 IEOCIJKANCB ONEGOEKILNK CHHJNKOCCKE
	public List<KFCIIMBBNCD> PEPLECGHBFA_SceneEffectInfo { get; private set; } // 0x24 AOMPIDGKJGA HBMHINNFLHK MMLJKFOBKJG
	public List<CDNKOFIELMK> PABCHCAAEAA_ActiveSkills { get; private set; } // 0x28 OOOLDFIEODH OAFKMOPEEIP AHMCPCEIAFI
	public List<PPGHMBNIAEC> PNJMFKFGIML_LiveSkills { get; private set; } // 0x2C FGDCFKENKPF MCMKNIPBADD FCOEOGELHLJ
	public List<BMMNKCJOHOM> BNAPNENIMBO { get; private set; } // 0x30 GOHHIHGILLH FJFMOFEOEAP PCCILLOLLEL
	public List<EDPDCLMMBPL> KGKICLDOOKG { get; private set; } // 0x34 DGFABBAMAFP JHBCOBJNGKC AALPMJGALDK
	public List<HBDCPGLAPHH> FFCFHFOIKGB_CenterSkillEnemy { get; private set; } // 0x38 NPFBNINCGMG FDEAPPEHCEF MAFNLFMCEMI
	public List<KFCIIMBBNCD> PHPGICHCBPM_EnemyEffectInfo { get; private set; } // 0x3C KOFOCBFCJDK PFKGHJNIJBL JCHPLEIJLPN
	public List<PPGHMBNIAEC> JNKGMICHPFC_EnemySkills { get; private set; } // 0x40 ENJODFBILBK CNIBLEEMDMC ODGMLPGNGHK
	public List<HBDCPGLAPHH> BIOEJKBCIKD_CenterSkillCostume { get; private set; } // 0x44 JLGHNNCIFMI AOBILEDJONM IDLNDLKEBPK
	public List<KFCIIMBBNCD> EBKAAEDMIBI_CostumeEffectInfo { get; private set; } // 0x48 LKEHMGJFDAF EELGPNPHCOK NONOJPGGMHM
	public List<PKLNDFNKINB> BGDOCIBFLBM_EnemyBuffs { get; private set; } // 0x4C PNLLBMNKEHH IDIHBACLADO BGBMJGMCEIP
	public List<BNHOEENHMDF> NHGMDOIBNDE { get; private set; } // 0x50 EDPGKOPMJBF MOMMJGHEMFK PPDOHIJLHFM
	public List<HCDIOPEOGEE> OEELDELPIIP { get; private set; } // 0x54 GFNGDLPDFEE GLMEKLEENIL HLLJKHHBDLN
	public List<DNIDPGDJCOG> GAGNFDHGJGC { get; private set; } // 0x58 BNOPAKDJBGC FFHLDPAEAKD KKDPEBICCEM
	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_m_stringParam { get; private set; } // 0x5C IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_m_intParam { get; private set; } // 0x60 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB
	public List<FOKHDKJJOFB_EffectByNumDiva> CHOMLDBLPLC_EffectValue { get; private set; } // 0x64 IDGKDCFDJAF CKJPKNALGLC MIOHFAAGKAG
	public List<EHGAHMIBPIB> CNKKCMLOAGN { get; private set; } // 0x68 HCDOIAIENDD DNFHHCNJLIF LALMDIOEJDI
	// TargetSkillEffects
	public List<ALECCMCNIBG> KGICDMIJGDF_Group { get; private set; } // 0x6C LHIOCOLMMNP ENACPBCEBLF KPCDPMGBPAG

	//// RVA: 0x1B904EC Offset: 0x1B904EC VA: 0x1B904EC
	public bool JBGPIPLAAIA(int GPBNFOMEDCG, int LFAFFMFOFEG)
	{
		for(int i = 0; i < KGICDMIJGDF_Group.Count; i++)
		{
			if(GPBNFOMEDCG != -1 && GPBNFOMEDCG == KGICDMIJGDF_Group[i].PPFNGGCBJKC_id)
			{
				for(int j = 0; j < KGICDMIJGDF_Group[i].LGFLNOJDHHC_Targets.Length; j++)
				{
					if (KGICDMIJGDF_Group[i].LGFLNOJDHHC_Targets[j] == LFAFFMFOFEG)
						return true;
				}
			}
		}
		return false;
	}

	//// RVA: 0x1B906EC Offset: 0x1B906EC VA: 0x1B906EC
	//public string EFEGBHACJAL_GetStringParam(string _LJNAKDMILMC_key, string _KKMJBMKHGNH_noval) { }

	//// RVA: 0x1B907D0 Offset: 0x1B907D0 VA: 0x1B907D0
	public int LPJLEHAJADA_GetIntParam(string _LJNAKDMILMC_key, int _KKMJBMKHGNH_noval)
	{
		if (!OHJFBLFELNK_m_intParam.ContainsKey(_LJNAKDMILMC_key))
			return _KKMJBMKHGNH_noval;
		return OHJFBLFELNK_m_intParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
	}

	//// RVA: 0x1B908B4 Offset: 0x1B908B4 VA: 0x1B908B4
	public EHGAHMIBPIB HJGDBBPDHON(int AOGDKBPNGCI)
	{
		return CNKKCMLOAGN[AOGDKBPNGCI - 1];
	}

	//// RVA: 0x1B90934 Offset: 0x1B90934 VA: 0x1B90934
	public FOKHDKJJOFB_EffectByNumDiva EFJFIIPIMOO_GetEffectValue(int AOGDKBPNGCI)
	{
		return CHOMLDBLPLC_EffectValue[AOGDKBPNGCI - 1];
	}

	//// RVA: 0x1B909B4 Offset: 0x1B909B4 VA: 0x1B909B4
	//private List<PPGHMBNIAEC> DGKHKMNMMDN(JNKEEAOKNCI.MKGJHBAKMBD _INDDJNMPONH_type) { }

	//// RVA: 0x1B909E0 Offset: 0x1B909E0 VA: 0x1B909E0
	//private List<HBDCPGLAPHH> LGONDBKGPMH(JNKEEAOKNCI.MKGJHBAKMBD _INDDJNMPONH_type) { }

	//// RVA: 0x1B90A1C Offset: 0x1B90A1C VA: 0x1B90A1C
	//private List<KFCIIMBBNCD> BHHJHMEKCCB(JNKEEAOKNCI.MKGJHBAKMBD _INDDJNMPONH_type) { }

	//// RVA: 0x1B90A58 Offset: 0x1B90A58 VA: 0x1B90A58
	public JNKEEAOKNCI_Skill()
	{
		JIKKNHIAEKG_BlockName = "";
		COLCPGFABLP_CenterSkills = new List<HBDCPGLAPHH>(999);
		PEPLECGHBFA_SceneEffectInfo = new List<KFCIIMBBNCD>(999);
		BNAPNENIMBO = new List<BMMNKCJOHOM>(999);
		PABCHCAAEAA_ActiveSkills = new List<CDNKOFIELMK>(999);
		PNJMFKFGIML_LiveSkills = new List<PPGHMBNIAEC>(999);
		KGKICLDOOKG = new List<EDPDCLMMBPL>(999);
		FFCFHFOIKGB_CenterSkillEnemy = new List<HBDCPGLAPHH>(999);
		PHPGICHCBPM_EnemyEffectInfo = new List<KFCIIMBBNCD>(999);
		JNKGMICHPFC_EnemySkills = new List<PPGHMBNIAEC>(999);
		BIOEJKBCIKD_CenterSkillCostume = new List<HBDCPGLAPHH>(999);
		EBKAAEDMIBI_CostumeEffectInfo = new List<KFCIIMBBNCD>(999);
		BGDOCIBFLBM_EnemyBuffs = new List<PKLNDFNKINB>();
		NHGMDOIBNDE = new List<BNHOEENHMDF>();
		OEELDELPIIP = new List<HCDIOPEOGEE>();
		LMHMIIKCGPE = 75;
		GAGNFDHGJGC = new List<DNIDPGDJCOG>();
		OHJFBLFELNK_m_intParam = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI_m_stringParam = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		CHOMLDBLPLC_EffectValue = new List<FOKHDKJJOFB_EffectByNumDiva>();
		CNKKCMLOAGN = new List<EHGAHMIBPIB>();
		KGICDMIJGDF_Group = new List<ALECCMCNIBG>();
		LNIMEIMBCMF = false;
	}

	//// RVA: 0x1B90EE8 Offset: 0x1B90EE8 VA: 0x1B90EE8 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		COLCPGFABLP_CenterSkills.Clear();
		PEPLECGHBFA_SceneEffectInfo.Clear();
		BNAPNENIMBO.Clear();
		PABCHCAAEAA_ActiveSkills.Clear();
		PNJMFKFGIML_LiveSkills.Clear();
		KGKICLDOOKG.Clear();
		FFCFHFOIKGB_CenterSkillEnemy.Clear();
		PHPGICHCBPM_EnemyEffectInfo.Clear();
		JNKGMICHPFC_EnemySkills.Clear();
		BIOEJKBCIKD_CenterSkillCostume.Clear();
		EBKAAEDMIBI_CostumeEffectInfo.Clear();
		BGDOCIBFLBM_EnemyBuffs.Clear();
		NHGMDOIBNDE.Clear();
		OEELDELPIIP.Clear();
		GAGNFDHGJGC.Clear();
		KGICDMIJGDF_Group.Clear();
		OHJFBLFELNK_m_intParam.Clear();
		FJOEBCMGDMI_m_stringParam.Clear();
	}

	//// RVA: 0x1B9124C Offset: 0x1B9124C VA: 0x1B9124C Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		bool res = false;
		FLHKDAGGLNK parser = FLHKDAGGLNK.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		BKIPCJEJGGF(parser);
		MMINKHFAOJJ(parser, MKGJHBAKMBD_SkillType.MHKFDBLMOGF_Scene);
		DFGFFILCCEI(parser, MKGJHBAKMBD_SkillType.MHKFDBLMOGF_Scene);
		ELDPNELNCOH(parser);
		ANPNMONLBNA(parser);
		if(INLJKKMEENJ(parser, MKGJHBAKMBD_SkillType.MHKFDBLMOGF_Scene))
		{
			FOMPOPFNLME(parser);
			DBINMPHFJEA(parser);
			JAHNPCHIDIA(parser, MKGJHBAKMBD_SkillType.MHKFDBLMOGF_Scene);
			if(INLJKKMEENJ(parser, MKGJHBAKMBD_SkillType.AIFGINAKBMA_EnemySkill))
			{
				MMINKHFAOJJ(parser, MKGJHBAKMBD_SkillType.AIFGINAKBMA_EnemySkill);
				DFGFFILCCEI(parser, MKGJHBAKMBD_SkillType.AIFGINAKBMA_EnemySkill);
				MMINKHFAOJJ(parser, MKGJHBAKMBD_SkillType.KBHGPMNGALJ_CostumeSkill);
				DFGFFILCCEI(parser, MKGJHBAKMBD_SkillType.KBHGPMNGALJ_CostumeSkill);
				IEKMLIKFMIJ(parser);
				FOKLKLCDEBC(parser);
				JDCPBKNMHMM(parser);
				DGENOFKIBBE(parser);
				LEKKJEDCPNK(parser);
				{
					OJEKDEDAIEP[] array = parser.BHGDNGHDDAC;
					for(int i = 0; i < array.Length; i++)
					{
						CEBFFLDKAEC_SecureInt data = new CEBFFLDKAEC_SecureInt();
						data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG;
						OHJFBLFELNK_m_intParam.Add(array[i].LJNAKDMILMC, data);
					}
				}
				{
					NGKKAGAMMDF[] array = parser.MHGMDJNOLMI;
					for (int i = 0; i < array.Length; i++)
					{
						NNJFKLBPBNK_SecureString data = new NNJFKLBPBNK_SecureString();
						data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG;
						FJOEBCMGDMI_m_stringParam.Add(array[i].LJNAKDMILMC, data);
					}
				}
				res = true;
			}
		}
		return res;
	}

	//// RVA: 0x1B95F10 Offset: 0x1B95F10 VA: 0x1B95F10 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		//KGPJGLFLDBE_a_skill
		//COLCPGFABLP_CenterSkills = CPBFAMJEODF_c_skill MMINKHFAOJJ
		//PEPLECGHBFA_SceneEffectInfo	 = MFGHMHBADMC_c_pat  DFGFFILCCEI
		//	 = FBMPJABPOGN_c_skill_pat 
		// = MGHPJNNDCIG_l_skill PNJMFKFGIML_LiveSkills
		//	 = l_pat  KGKICLDOOKG
		// = DKOPDNHDLIA_enemy_l_skill JNKGMICHPFC_EnemySkills
		//FFCFHFOIKGB_CenterSkillEnemy = MLKFDMFDFCE_enemy_c_skill MMINKHFAOJJ
		//PHPGICHCBPM_EnemyEffectInfo	 = JHFGJGEAGPH_enemy_c_pat DFGFFILCCEI
		//BIOEJKBCIKD_CenterSkillCostume = NGOONCOAOMI_cos_c_skill MMINKHFAOJJ
		//EBKAAEDMIBI_CostumeEffectInfo	 = IOAKMAAFBAJ_cos_c_pat DFGFFILCCEI
		// = enemy_life_up
		//OHJFBLFELNK_m_intParam = int_param
		// = key
		// = val
		//OHJFBLFELNK_m_intParam = string_param
		TodoLogger.LogError(TodoLogger.DbJson, "DB Skills IIEMACPEEBJ");
		return true;
	}

	//// RVA: 0x1B9163C Offset: 0x1B9163C VA: 0x1B9163C
	private bool BKIPCJEJGGF(FLHKDAGGLNK GGIHPBILDIG)
	{
		PKDAOHIIJMM[] array = GGIHPBILDIG.OKDCMAAIICE;
		for(int i = 0; i < array.Length; i++)
		{
			CDNKOFIELMK data = new CDNKOFIELMK();
			data.DDMENKOHCGM_aid = (int)array[i].DDMENKOHCGM;
			data.EGLDFPILJLG_SkillBuffEffect = new byte[2];
			data.EGLDFPILJLG_SkillBuffEffect[0] = (byte)array[i].HIMIDIJIGJN;
			data.EGLDFPILJLG_SkillBuffEffect[1] = (byte)array[i].NDIOEOHDMLJ;
			data.FPMFEKIPFPI_DurationType = new byte[2];
			data.FPMFEKIPFPI_DurationType[0] = (byte)array[i].MIKCFEHGNJB;
			data.FPMFEKIPFPI_DurationType[1] = (byte)array[i].LFOHDJJHLJE;
			data.JGDJACOPHJP_LineTarget = (byte)array[i].PLMHOKJIPJK;
			data.JGNHOGKKPDM = (byte)array[i].INANEEGAEEG;
			data.HEOLEHDFLJO_ico = new int[2];
			data.HEOLEHDFLJO_ico[0] = (int)array[i].HEOLEHDFLJO;
			data.HEOLEHDFLJO_ico[1] = (int)array[i].AOELPHMDDND;
			data.GIEFBAHPMMM = (int)array[i].KPECMLFDLOI;
			data.NLCJNOBOBAH_MaxActivation = (int)array[i].GAMODHFMOMK;
			{
				uint[] array2 = array[i].CBDOEDKIOJK;
				for(int j = 0; j < array2.Length; j++)
				{
					data.NKGHBKFMFCI_BuffValue[j, 0] = (short)array2[j];
				}
			}
			{
				uint[] array2 = array[i].JNNFFAEFGOC;
				for (int j = 0; j < array2.Length; j++)
				{
					data.NKGHBKFMFCI_BuffValue[j, 1] = (short)array2[j];
				}
			}
			{
				uint[] array2 = array[i].OCAMDLMPBGA;
				for (int j = 0; j < array2.Length; j++)
				{
					data.PHAGNOHBMCM_DurationByIndexAndLevel[j, 0] = (short)array2[j];
				}
			}
			{
				uint[] array2 = array[i].JMAGFEENOED;
				for (int j = 0; j < array2.Length; j++)
				{
					data.PHAGNOHBMCM_DurationByIndexAndLevel[j, 1] = (short)array2[j];
				}
			}
			PABCHCAAEAA_ActiveSkills.Add(data);
		}
		return true;
	}

	//// RVA: 0x1B96884 Offset: 0x1B96884 VA: 0x1B96884
	//private bool BKIPCJEJGGF(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x1B91DE8 Offset: 0x1B91DE8 VA: 0x1B91DE8
	private bool MMINKHFAOJJ(FLHKDAGGLNK GGIHPBILDIG, MKGJHBAKMBD_SkillType _GJLFANGDGCL_Target)
	{
		if (_GJLFANGDGCL_Target == MKGJHBAKMBD_SkillType.KBHGPMNGALJ_CostumeSkill)
		{
			MEDPEPOBHGD[] array = GGIHPBILDIG.GCGNDMLDCML;
			for(int i = 0; i < array.Length; i++)
			{
				HBDCPGLAPHH data = new HBDCPGLAPHH();
				data.JBFLEDKDFCO_cid = (int)array[i].JBFLEDKDFCO;
				data.HEKHODDJHAO_P1 = (int)array[i].POOHGENNICD;
				data.AKGNPLBDKLN_P2 = (int)array[i].LLGBAPAACLL;
				data.JGNHOGKKPDM = 0;
				BIOEJKBCIKD_CenterSkillCostume.Add(data);
			}
		}
		else if (_GJLFANGDGCL_Target == MKGJHBAKMBD_SkillType.AIFGINAKBMA_EnemySkill)
		{
			OPNDNFJFFIO[] array = GGIHPBILDIG.FMMKFANHGMJ;
			for (int i = 0; i < array.Length; i++)
			{
				HBDCPGLAPHH data = new HBDCPGLAPHH();
				data.JBFLEDKDFCO_cid = (int)array[i].JBFLEDKDFCO;
				data.HEKHODDJHAO_P1 = (int)array[i].POOHGENNICD;
				data.AKGNPLBDKLN_P2 = (int)array[i].LLGBAPAACLL;
				data.JGNHOGKKPDM = 0;
				FFCFHFOIKGB_CenterSkillEnemy.Add(data);
			}
		}
		else if (_GJLFANGDGCL_Target == MKGJHBAKMBD_SkillType.MHKFDBLMOGF_Scene)
		{
			DJJLEDFBIBI[] array = GGIHPBILDIG.CAIFABNNKJB;
			for (int i = 0; i < array.Length; i++)
			{
				HBDCPGLAPHH data = new HBDCPGLAPHH();
				data.JBFLEDKDFCO_cid = (int)array[i].JBFLEDKDFCO;
				data.HEKHODDJHAO_P1 = (int)array[i].POOHGENNICD;
				data.AKGNPLBDKLN_P2 = (int)array[i].LLGBAPAACLL;
				data.JGNHOGKKPDM = (byte)array[i].INANEEGAEEG;
				COLCPGFABLP_CenterSkills.Add(data);
			}
		}
		return true;
	}

	//// RVA: 0x1B968B4 Offset: 0x1B968B4 VA: 0x1B968B4
	//private bool MMINKHFAOJJ(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label, JNKEEAOKNCI.MKGJHBAKMBD _GJLFANGDGCL_Target) { }
	//JBFLEDKDFCO_cid = JBFLEDKDFCO_cid
	//HEKHODDJHAO_P1 = POOHGENNICD_p1
	//AKGNPLBDKLN_P2 = LLGBAPAACLL_p2

	//// RVA: 0x1B929A8 Offset: 0x1B929A8 VA: 0x1B929A8
	private bool ELDPNELNCOH(FLHKDAGGLNK GGIHPBILDIG)
	{
		MFGCKJCKFDM[] array = GGIHPBILDIG.CHKNAMIFECK;
		for(int i = 0; i < array.Length; i++)
		{
			BMMNKCJOHOM data = new BMMNKCJOHOM();
			data.LGCPDKGMLJI = (int)array[i].MJMPANIBFED;
			data.CHOFDPDFPDC_ConfigValue = (int)array[i].ODMJFHDIGLP;
			data.PNCCGBBHLLP = (int)array[i].JHGHCMEBOOL;
			data.KGBMHHFLGEE = (int)array[i].BEJMJAHGAFH;
			BNAPNENIMBO.Add(data);
		}
		return true;
	}

	//// RVA: 0x1B92BAC Offset: 0x1B92BAC VA: 0x1B92BAC
	private bool ANPNMONLBNA(FLHKDAGGLNK GGIHPBILDIG)
	{
		GOIHGONJPNC[] array = GGIHPBILDIG.FIMINKADAPC;
		for (int i = 0; i < array.Length; i++)
		{
			FOKHDKJJOFB_EffectByNumDiva data = new FOKHDKJJOFB_EffectByNumDiva();
			data.FDBOPFEOENF_diva = array[i].FDBOPFEOENF;
			data.NNDBJGDFEEM_Min = array[i].NNDBJGDFEEM;
			{
				int[] array2 = array[i].NANNGLGOFKH;
				data.NANNGLGOFKH_value = new int[array2.Length];
				for (int j = 0; j < array2.Length; j++)
				{
					data.NANNGLGOFKH_value[j] = array2[j];
				}
			}
			CHOMLDBLPLC_EffectValue.Add(data);
		}
		return true;
	}

	//// RVA: 0x1B94054 Offset: 0x1B94054 VA: 0x1B94054
	private bool DBINMPHFJEA(FLHKDAGGLNK GGIHPBILDIG)
	{
		HPCMDEIGDDH[] array = GGIHPBILDIG.GDFFALAJFNP;
		for (int i = 0; i < array.Length; i++)
		{
			EHGAHMIBPIB data = new EHGAHMIBPIB();
			data.DOOGFEGEKLG_max = array[i].DOOGFEGEKLG;
			{
				int[] array2 = array[i].KCOHMHFBDKF;
				data.KCOHMHFBDKF_Value1 = new int[array2.Length];
				for (int j = 0; j < array2.Length; j++)
				{
					data.KCOHMHFBDKF_Value1[j] = array2[j];
				}
			}
			{
				int[] array2 = array[i].HLMMBNCIIAC;
				data.HLMMBNCIIAC_Value2 = new int[array2.Length];
				for (int j = 0; j < array2.Length; j++)
				{
					data.HLMMBNCIIAC_Value2[j] = array2[j];
				}
			}
			CNKKCMLOAGN.Add(data);
		}
		return true;
	}

	//// RVA: 0x1B96F74 Offset: 0x1B96F74 VA: 0x1B96F74
	//private bool ELDPNELNCOH(EDOHBJAPLPF_JsonData OBHAFLMHAKG) { }

	//// RVA: 0x1B92258 Offset: 0x1B92258 VA: 0x1B92258
	private bool DFGFFILCCEI(FLHKDAGGLNK GGIHPBILDIG, MKGJHBAKMBD_SkillType _GJLFANGDGCL_Target)
	{
		if(_GJLFANGDGCL_Target == MKGJHBAKMBD_SkillType.MHKFDBLMOGF_Scene)
		{
			OEBKKEFIOEB[] array = GGIHPBILDIG.BHJHBOKODBH;
			for(int i = 0; i < array.Length; i++)
			{
				KFCIIMBBNCD data = new KFCIIMBBNCD();
				data.MJMPANIBFED_pid = (int)array[i].MJMPANIBFED;
				data.GJLFANGDGCL_Target = (byte)array[i].AGNHPHEJKMK;
				data.INDDJNMPONH_type = (byte)array[i].GBJFNGCDKPM;
				data.OAFPGJLCNFM_cond = (int)array[i].ODMJFHDIGLP & 0xff;
				data.BBFKKANELFP_EffectType = (byte)array[i].BBFKKANELFP;
				{
					uint[] array2 = array[i].KFCIJBLDHOK;
					for(int j = 0; j < array2.Length; j++)
					{
						data.KCOHMHFBDKF_Value1[j] = (short)array2[j];
					}
				}
				PEPLECGHBFA_SceneEffectInfo.Add(data);
			}
		}
		else if (_GJLFANGDGCL_Target == MKGJHBAKMBD_SkillType.AIFGINAKBMA_EnemySkill)
		{
			DLMMECOIPDO[] array = GGIHPBILDIG.JNJPNLDJJMI;
			for (int i = 0; i < array.Length; i++)
			{
				KFCIIMBBNCD data = new KFCIIMBBNCD();
				data.MJMPANIBFED_pid = (int)array[i].MJMPANIBFED;
				data.GJLFANGDGCL_Target = (byte)array[i].AGNHPHEJKMK;
				data.INDDJNMPONH_type = (byte)array[i].GBJFNGCDKPM;
				data.OAFPGJLCNFM_cond = (int)array[i].ODMJFHDIGLP & 0xff;
				data.BBFKKANELFP_EffectType = 0;
				{
					uint[] array2 = array[i].KFCIJBLDHOK;
					for (int j = 0; j < array2.Length; j++)
					{
						data.KCOHMHFBDKF_Value1[j] = (short)array2[j];
					}
				}
				PHPGICHCBPM_EnemyEffectInfo.Add(data);
			}
		}
		else if (_GJLFANGDGCL_Target == MKGJHBAKMBD_SkillType.KBHGPMNGALJ_CostumeSkill)
		{
			OJEFFPDNEOP[] array = GGIHPBILDIG.NAAHEIAJLDP;
			for (int i = 0; i < array.Length; i++)
			{
				KFCIIMBBNCD data = new KFCIIMBBNCD();
				data.MJMPANIBFED_pid = (int)array[i].MJMPANIBFED;
				data.GJLFANGDGCL_Target = (byte)array[i].AGNHPHEJKMK;
				data.INDDJNMPONH_type = (byte)array[i].GBJFNGCDKPM;
				data.OAFPGJLCNFM_cond = (int)array[i].ODMJFHDIGLP & 0xff;
				data.BBFKKANELFP_EffectType = 0;
				{
					uint[] array2 = array[i].KFCIJBLDHOK;
					for (int j = 0; j < array2.Length; j++)
					{
						data.KCOHMHFBDKF_Value1[j] = (short)array2[j];
					}
				}
				EBKAAEDMIBI_CostumeEffectInfo.Add(data);
			}
		}
		return true;
	}

	//// RVA: 0x1B95C54 Offset: 0x1B95C54 VA: 0x1B95C54
	private bool LEKKJEDCPNK(FLHKDAGGLNK EJPJKHPLGMO)
	{
		NLLCPFIHFFA[] array = EJPJKHPLGMO.KBFEMKJBHBL;
		for(int i = 0; i < array.Length; i++)
		{
			ALECCMCNIBG data = new ALECCMCNIBG();
			data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC;
			{
				int[] array2 = array[i].LGFLNOJDHHC;
				data.LGFLNOJDHHC_Targets = new int[array2.Length];
				for(int j = 0; j < array2.Length; j++)
				{
					data.LGFLNOJDHHC_Targets[j] = array2[j];
				}
			}
			KGICDMIJGDF_Group.Add(data);
		}
		return true;
	}

	//// RVA: 0x1B96B60 Offset: 0x1B96B60 VA: 0x1B96B60
	//private bool DFGFFILCCEI(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label, JNKEEAOKNCI.MKGJHBAKMBD _GJLFANGDGCL_Target) { }
	//MJMPANIBFED_pid = MJMPANIBFED_pid
	//GJLFANGDGCL_TargetGJLFANGDGCL_Target = AGNHPHEJKMK_tgt
	//INDDJNMPONH_type = GBJFNGCDKPM_typ
	//OAFPGJLCNFM_cond = ODMJFHDIGLP_cnd
	//BBFKKANELFP_EffectType = KFCIJBLDHOK_v1

	//// RVA: 0x1B92E50 Offset: 0x1B92E50 VA: 0x1B92E50
	private bool INLJKKMEENJ(FLHKDAGGLNK GGIHPBILDIG, MKGJHBAKMBD_SkillType _GJLFANGDGCL_Target)
	{
		if(_GJLFANGDGCL_Target == MKGJHBAKMBD_SkillType.MHKFDBLMOGF_Scene)
		{
			GNDJHFAGJKB[] array = GGIHPBILDIG.GBOHIMFKPPI;
			for(int i = 0; i < array.Length; i++)
			{
				PPGHMBNIAEC data = new PPGHMBNIAEC();
				data.BEKFHEBCPEE_lid = (int)array[i].BEKFHEBCPEE;
				data.FLJHGGKIOJH_SkillType = array[i].PFOIIAGCKON;
				data.EGLDFPILJLG_SkillBuffEffect = new byte[2];
				data.EGLDFPILJLG_SkillBuffEffect[0] = (byte)array[i].HIMIDIJIGJN;
				data.EGLDFPILJLG_SkillBuffEffect[1] = (byte)array[i].NDIOEOHDMLJ;
				data.FPMFEKIPFPI_DurationType = new byte[2];
				data.FPMFEKIPFPI_DurationType[0] = (byte)array[i].MIKCFEHGNJB;
				data.FPMFEKIPFPI_DurationType[1] = (byte)array[i].LFOHDJJHLJE;
				data.ELEPHBOKIGK_Limit = new int[2];
				data.ELEPHBOKIGK_Limit[0] = (int)array[i].IMLOHAOEKJE;
				data.ELEPHBOKIGK_Limit[1] = (int)array[i].IAAMCGAOFPK;
				data.CPNAGMFCIJK_TriggerType = (byte)array[i].NNONCOCHGMD;
				data.JGDJACOPHJP_LineTarget = (byte)array[i].PLMHOKJIPJK;
				data.JGNHOGKKPDM = (byte)array[i].INANEEGAEEG;
				data.MKPJBDFDHOL_ThumbId = new int[2];
				data.MKPJBDFDHOL_ThumbId[0] = (int)array[i].HEOLEHDFLJO;
				data.MKPJBDFDHOL_ThumbId[1] = (int)array[i].AOELPHMDDND;
				data.GIEFBAHPMMM = (int)array[i].KPECMLFDLOI;
				data.CEFHDLLAPDH_MusicId = (int)array[i].FCBDGLEPGFJ;
				data.NFIBKOACELP_Attr = (int)array[i].BPBLHHFKBBG;
				data.POMLAENHCHA_TargetSkillEffectId = array[i].LECPFABMCHE;
				data.DPGDCJFBFGK_TargetSkillType = array[i].EHCACJFKHIC;
				{
					uint[] array2 = array[i].MHHNOKGNJFN;
					for(int j = 0; j < array2.Length; j++)
					{
						data.LFGFBMJNBKN_ConfigValue[j] = (short)array2[j];
					}
				}
				{
					uint[] array2 = array[i].CBDOEDKIOJK;
					for (int j = 0; j < array2.Length; j++)
					{
						data.NKGHBKFMFCI_BuffValue[j, 0] = (short)array2[j];
					}
				}
				{
					uint[] array2 = array[i].JNNFFAEFGOC;
					for (int j = 0; j < array2.Length; j++)
					{
						data.NKGHBKFMFCI_BuffValue[j, 1] = (short)array2[j];
					}
				}
				{
					uint[] array2 = array[i].OCAMDLMPBGA;
					for (int j = 0; j < array2.Length; j++)
					{
						data.PHAGNOHBMCM_DurationByIndexAndLevel[j, 0] = (short)array2[j];
					}
				}
				{
					uint[] array2 = array[i].JMAGFEENOED;
					for (int j = 0; j < array2.Length; j++)
					{
						data.PHAGNOHBMCM_DurationByIndexAndLevel[j, 1] = (short)array2[j];
					}
				}
				PNJMFKFGIML_LiveSkills.Add(data);
			}
		}
		else if (_GJLFANGDGCL_Target == MKGJHBAKMBD_SkillType.AIFGINAKBMA_EnemySkill)
		{
			LIAMFMKIPFD[] array = GGIHPBILDIG.CLELJNJEGID;
			for (int i = 0; i < array.Length; i++)
			{
				PPGHMBNIAEC data = new PPGHMBNIAEC();
				data.BEKFHEBCPEE_lid = (int)array[i].BEKFHEBCPEE;
				data.EGLDFPILJLG_SkillBuffEffect = new byte[1];
				data.EGLDFPILJLG_SkillBuffEffect[0] = (byte)array[i].HIMIDIJIGJN;
				data.FPMFEKIPFPI_DurationType = new byte[1];
				data.FPMFEKIPFPI_DurationType[0] = (byte)array[i].MIKCFEHGNJB;
				data.ELEPHBOKIGK_Limit = new int[1];
				data.CPNAGMFCIJK_TriggerType = (byte)array[i].NNONCOCHGMD;
				data.JGDJACOPHJP_LineTarget = (byte)array[i].PLMHOKJIPJK;
				data.JGNHOGKKPDM = 0;
				data.MKPJBDFDHOL_ThumbId = new int[0];
				{
					for (int j = 0; j < data.LFGFBMJNBKN_ConfigValue.Length; j++)
					{
						data.LFGFBMJNBKN_ConfigValue[j] = (short)array[i].MHHNOKGNJFN;
					}
				}
				{
					uint[] array2 = array[i].CBDOEDKIOJK;
					for (int j = 0; j < array2.Length; j++)
					{
						data.NKGHBKFMFCI_BuffValue[j, 0] = (short)array2[j];
					}
				}
				{
					uint[] array2 = array[i].OCAMDLMPBGA;
					for (int j = 0; j < array2.Length; j++)
					{
						data.PHAGNOHBMCM_DurationByIndexAndLevel[j, 0] = (short)array2[j];
					}
				}
				JNKGMICHPFC_EnemySkills.Add(data);
			}
		}
		return true;
	}

	//// RVA: 0x1B93E44 Offset: 0x1B93E44 VA: 0x1B93E44
	private bool FOMPOPFNLME(FLHKDAGGLNK GGIHPBILDIG)
	{
		EBAOBOGMNPH[] array = GGIHPBILDIG.KIHBDEJJHJM;
		for(int i = 0; i < array.Length; i++)
		{
			EDPDCLMMBPL data = new EDPDCLMMBPL();
			data.LGCPDKGMLJI = (int)array[i].MJMPANIBFED;
			data.CHOFDPDFPDC_ConfigValue = (int)array[i].ODMJFHDIGLP;
			data.PNCCGBBHLLP = (int)array[i].JHGHCMEBOOL;
			data.KGBMHHFLGEE = (int)array[i].BEJMJAHGAFH;
			KGKICLDOOKG.Add(data);
		}
		return true;
	}

	//// RVA: 0x1B94448 Offset: 0x1B94448 VA: 0x1B94448
	private bool JAHNPCHIDIA(FLHKDAGGLNK GGIHPBILDIG, MKGJHBAKMBD_SkillType _GJLFANGDGCL_Target)
	{
		FAGNHJMBNCI[] array = GGIHPBILDIG.NIIDELOIGDB;
		List<PPGHMBNIAEC> array2 = null;
		if (_GJLFANGDGCL_Target == MKGJHBAKMBD_SkillType.MHKFDBLMOGF_Scene)
		{
			array2 = PNJMFKFGIML_LiveSkills;
		}
		else if (_GJLFANGDGCL_Target == MKGJHBAKMBD_SkillType.AIFGINAKBMA_EnemySkill)
		{
			array2 = JNKGMICHPFC_EnemySkills;
		}
		for (int i = 0; i < array2.Count; i++)
		{
			for(int j = 0; j < array.Length; j++)
			{
				if (((int)array[j].PFOIIAGCKON ^ array2[i].FLJHGGKIOJH_SkillType | array2[i].FLJHGGKIOJH_SkillType >> 0x1f) == 0) // ?? not sure if ((uVar8 ^ uVar5 | (int)uVar8 >> 0x1f) == 0) break;
				{
					array2[i].AOPELJFAMCL_LiveSkillType = (int)array[j].AOPELJFAMCL;
					break;
				}
				array2[i].AOPELJFAMCL_LiveSkillType = 0;
			}
		}
		return true;
	}

	//// RVA: 0x1B96FE0 Offset: 0x1B96FE0 VA: 0x1B96FE0
	//private bool FOMPOPFNLME(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label, JNKEEAOKNCI.MKGJHBAKMBD _GJLFANGDGCL_Target) { }

	//// RVA: 0x1B96F7C Offset: 0x1B96F7C VA: 0x1B96F7C
	//private bool INLJKKMEENJ(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label, JNKEEAOKNCI.MKGJHBAKMBD _GJLFANGDGCL_Target) { }

	//// RVA: 0x1B95928 Offset: 0x1B95928 VA: 0x1B95928
	private bool DGENOFKIBBE(FLHKDAGGLNK GGIHPBILDIG)
	{
		DGMLKJPPPOC[] array = GGIHPBILDIG.NAJGALLJIBP;
		for(int i = 0; i < array.Length; i++)
		{
			PKLNDFNKINB data = new PKLNDFNKINB();
			{
				int[] array2 = array[i].FDBOPFEOENF;
				for(int j = 0; j < array2.Length; j++)
				{
					data.OMIMBPNKOKE_SubGoalPercent.Add(array2[j]);
				}
			}
			{
				int[] array2 = array[i].DKEDLFLAKGC;
				for (int j = 0; j < array2.Length; j++)
				{
					data.HGIOBLMAAEO_GoalPercent.Add(array2[j]);
				}
			}
			BGDOCIBFLBM_EnemyBuffs.Add(data);
		}
		return true;
	}

	//// RVA: 0x1B9701C Offset: 0x1B9701C VA: 0x1B9701C
	//private bool DGENOFKIBBE(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x1B94638 Offset: 0x1B94638 VA: 0x1B94638
	private bool IEKMLIKFMIJ(FLHKDAGGLNK GGIHPBILDIG)
	{
		CLFBIKKLDOH[] array = GGIHPBILDIG.BGOAGJLBECM;
		for(int i = 0; i < array.Length; i++)
		{
			AFLHKMDNHID data = new AFLHKMDNHID();
			data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC;
			data.PLALNIIBLOF_en = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, 0);
			data.MKDDOJOADMF = (int)array[i].MKDDOJOADMF;
			data.GJLFANGDGCL_Target = new byte[2];
			data.GJLFANGDGCL_Target[0] = (byte)array[i].GNPACBPKKCP;
			data.GJLFANGDGCL_Target[1] = (byte)array[i].CGNBOKANMAD;
			data.INDDJNMPONH_type = new byte[2];
			data.INDDJNMPONH_type[0] = (byte)array[i].EPIBJMFJNDC;
			data.INDDJNMPONH_type[1] = (byte)array[i].KLCMNKMONJJ;
			data.OAFPGJLCNFM_cond = new int[2];
			data.OAFPGJLCNFM_cond[0] = (int)array[i].GCFHEHAFHKO;
			data.OAFPGJLCNFM_cond[1] = (int)array[i].JOKNHEBCHFB;
			BNHOEENHMDF a = NHGMDOIBNDE.Find((BNHOEENHMDF _GHPLINIACBB_x) =>
			{
				//0x1B97ACC
				return _GHPLINIACBB_x.MKDDOJOADMF == data.MKDDOJOADMF;
			});
			if(a == null)
			{
				a = new BNHOEENHMDF();
				a.PPFNGGCBJKC_id = data.PPFNGGCBJKC_id;
				a.MKDDOJOADMF = data.MKDDOJOADMF;
				NHGMDOIBNDE.Add(a);
			}
			a.NNDGIAEFMOG.Add(data);
		}
		return true;
	}

	//// RVA: 0x1B94CB8 Offset: 0x1B94CB8 VA: 0x1B94CB8
	private bool FOKLKLCDEBC(FLHKDAGGLNK GGIHPBILDIG)
	{
		BPEPDCHPBOC[] array = GGIHPBILDIG.HGFOLPABILK;
		for(int i = 0; i < array.Length; i++)
		{
			CCINPCJDFJG data = new CCINPCJDFJG();
			data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC;
			data.PLALNIIBLOF_en = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, 0);
			data.MKDDOJOADMF = (int)array[i].MKDDOJOADMF;
			data.EGLDFPILJLG_SkillBuffEffect = new byte[2];
			data.EGLDFPILJLG_SkillBuffEffect[0] = (byte)array[i].JKOIOLGLNFO;
			data.EGLDFPILJLG_SkillBuffEffect[1] = (byte)array[i].NDIOEOHDMLJ;
			data.FPMFEKIPFPI_DurationType = new byte[2];
			data.FPMFEKIPFPI_DurationType[0] = (byte)array[i].OGNCJAMBOCJ;
			data.FPMFEKIPFPI_DurationType[1] = (byte)array[i].LFOHDJJHLJE;
			HCDIOPEOGEE a = OEELDELPIIP.Find((HCDIOPEOGEE _GHPLINIACBB_x) =>
			{
				//0x1B97B18
				return _GHPLINIACBB_x.MKDDOJOADMF == data.MKDDOJOADMF;
			});
			if(a == null)
			{
				a = new HCDIOPEOGEE();
				a.PPFNGGCBJKC_id = data.PPFNGGCBJKC_id;
				a.MKDDOJOADMF = data.MKDDOJOADMF;
				OEELDELPIIP.Add(a);
			}
			a.NNDGIAEFMOG.Add(data);
		}
		return true;
	}

	//// RVA: 0x1B95268 Offset: 0x1B95268 VA: 0x1B95268
	private bool JDCPBKNMHMM(FLHKDAGGLNK GGIHPBILDIG)
	{
		DCOKBIMIIMA[] array = GGIHPBILDIG.OOBEHBMMJAC;
		for(int i = 0; i < array.Length; i++)
		{
			FCNGHAJPMEA data = new FCNGHAJPMEA();
			data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC;
			data.PLALNIIBLOF_en = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, 0);
			data.MKDDOJOADMF = (int)array[i].MKDDOJOADMF;
			data.NEHDLDEHFCD = array[i].PFOIIAGCKON;
			data.EGLDFPILJLG_SkillBuffEffect = new byte[2];
			data.EGLDFPILJLG_SkillBuffEffect[0] = (byte)array[i].JKOIOLGLNFO;
			data.EGLDFPILJLG_SkillBuffEffect[1] = (byte)array[i].NDIOEOHDMLJ;
			data.FPMFEKIPFPI_DurationType = new byte[2];
			data.FPMFEKIPFPI_DurationType[0] = (byte)array[i].OGNCJAMBOCJ;
			data.FPMFEKIPFPI_DurationType[1] = (byte)array[i].LFOHDJJHLJE;
			data.CPNAGMFCIJK_TriggerType = (byte)array[i].NNONCOCHGMD;
			data.CEFHDLLAPDH_MusicId = (int)array[i].FCBDGLEPGFJ;
			data.NFIBKOACELP_Attr = (int)array[i].BPBLHHFKBBG;
			data.BHADMHLIFMM = (int)array[i].OCAMDLMPBGA;
			DNIDPGDJCOG a = GAGNFDHGJGC.Find((DNIDPGDJCOG _GHPLINIACBB_x) =>
			{
				//0x1B97B64
				return data.MKDDOJOADMF == _GHPLINIACBB_x.MKDDOJOADMF;
			});
			if(a == null)
			{
				a = new DNIDPGDJCOG();
				a.PPFNGGCBJKC_id = data.PPFNGGCBJKC_id;
				a.MKDDOJOADMF = data.MKDDOJOADMF;
				GAGNFDHGJGC.Add(a);
			}
			a.NNDGIAEFMOG.Add(data);
		}
		return true;
	}

	//// RVA: 0x1B97044 Offset: 0x1B97044 VA: 0x1B97044 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "JNKEEAOKNCI_Skill.CAOGDCBPBAN");
		return 0;
	}
}

public class HBDCPGLAPHH
{
	public int JBFLEDKDFCO_cid; // 0x8
	public int HEKHODDJHAO_P1; // 0xC
	public int AKGNPLBDKLN_P2; // 0x10
	public byte JGNHOGKKPDM; // 0x14
	public int FOKGIBANJKJ; // 0x18

	//// RVA: 0x173EF2C Offset: 0x173EF2C VA: 0x173EF2C
	//public uint CAOGDCBPBAN() { }

	//// RVA: 0x173EF48 Offset: 0x173EF48 VA: 0x173EF48
	public string KMFMGLENCJH_FormatDesc(string _HCAHCFGPJIF_Desc, int _CIEOBFIIPLD_Level)
	{
		string res = _HCAHCFGPJIF_Desc;
		if (_CIEOBFIIPLD_Level > 0)
		{
			if (HEKHODDJHAO_P1 != 0)
			{
				KFCIIMBBNCD k = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PEPLECGHBFA_SceneEffectInfo[HEKHODDJHAO_P1 - 1];
				GLNMPEBIMGO_ReplaceEffectInfo(ref res, _CIEOBFIIPLD_Level, k, 1);
			}
			if(AKGNPLBDKLN_P2 != 0)
			{
				KFCIIMBBNCD k = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PEPLECGHBFA_SceneEffectInfo[AKGNPLBDKLN_P2 - 1];
				GLNMPEBIMGO_ReplaceEffectInfo(ref res, _CIEOBFIIPLD_Level, k, 2);
			}
		}

		return res;
	}

	//// RVA: 0x173F130 Offset: 0x173F130 VA: 0x173F130
	private void GLNMPEBIMGO_ReplaceEffectInfo(ref string _HCAHCFGPJIF_Desc, int _CIEOBFIIPLD_Level, KFCIIMBBNCD LKPOKJPOLIE_EffectInfo, int AOGDKBPNGCI_EffectIdx)
	{
		string s1, s2;
		int v = LKPOKJPOLIE_EffectInfo.KCOHMHFBDKF_Value1[_CIEOBFIIPLD_Level - 1];
		if (LKPOKJPOLIE_EffectInfo.BBFKKANELFP_EffectType == 1)
		{
			_HCAHCFGPJIF_Desc = _HCAHCFGPJIF_Desc.Replace(string.Format("[v{0}_1]", AOGDKBPNGCI_EffectIdx), IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.EFJFIIPIMOO_GetEffectValue(LKPOKJPOLIE_EffectInfo.KCOHMHFBDKF_Value1[_CIEOBFIIPLD_Level - 1]).NANNGLGOFKH_value[_CIEOBFIIPLD_Level - 1].ToString());
			s1 = string.Format("[v{0}_min]", AOGDKBPNGCI_EffectIdx);
			s2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.EFJFIIPIMOO_GetEffectValue(LKPOKJPOLIE_EffectInfo.KCOHMHFBDKF_Value1[_CIEOBFIIPLD_Level - 1]).NNDBJGDFEEM_Min.ToString();
		}
		else
		{
			s1 = string.Format("[v{0}]", AOGDKBPNGCI_EffectIdx);
			s2 = v.ToString();
		}
		_HCAHCFGPJIF_Desc = _HCAHCFGPJIF_Desc.Replace(s1, s2);
	}

	//// RVA: 0x173F474 Offset: 0x173F474 VA: 0x173F474
	//public bool JGNLACPLALL() { }

	//// RVA: 0x173F488 Offset: 0x173F488 VA: 0x173F488
	//public bool DCLHEKGLENB(int _MGBDCFIKBPM_Serie) { }
}

public class KFCIIMBBNCD
{
	public int MJMPANIBFED_pid; // 0x8
	public short[] KCOHMHFBDKF_Value1 = new short[5]; // 0xC // ValueByLevel
	public byte GJLFANGDGCL_Target; // 0x10 // CenterSkillTarget
	public byte INDDJNMPONH_type; // 0x11 ModifierType
	public int OAFPGJLCNFM_cond; // 0x14 CenterSkillCondition
	public byte BBFKKANELFP_EffectType; // 0x18

	//// RVA: 0x19FC87C Offset: 0x19FC87C VA: 0x19FC87C
	//public uint CAOGDCBPBAN() { }
}

public class CDNKOFIELMK
{
	public int DDMENKOHCGM_aid; // 0x8
	public short[,] NKGHBKFMFCI_BuffValue = new short[5, 2]; // 0xC BuffValueByIndexAndLevel
	public short[,] PHAGNOHBMCM_DurationByIndexAndLevel = new short[5, 2]; // 0x10
	public byte[] EGLDFPILJLG_SkillBuffEffect; // 0x14
	public byte[] FPMFEKIPFPI_DurationType; // 0x18
	public byte JGDJACOPHJP_LineTarget; // 0x1C
	public byte JGNHOGKKPDM; // 0x1D
	public int[] HEOLEHDFLJO_ico; // 0x20
	public int GIEFBAHPMMM; // 0x24
	public int NLCJNOBOBAH_MaxActivation; // 0x28

	//// RVA: 0x12B043C Offset: 0x12B043C VA: 0x12B043C
	//public uint CAOGDCBPBAN() { }

	//// RVA: 0x12B0698 Offset: 0x12B0698 VA: 0x12B0698
	public string KMFMGLENCJH_FormatDesc(string _HCAHCFGPJIF_Desc, int _CIEOBFIIPLD_Level)
	{
		if(_CIEOBFIIPLD_Level > 0)
		{
			for(int i = 0; i < 2; i++)
			{
				_HCAHCFGPJIF_Desc = _HCAHCFGPJIF_Desc.Replace(i == 0 ? "[v1]" : "[v2]", NKGHBKFMFCI_BuffValue[_CIEOBFIIPLD_Level - 1, i].ToString());
			}
			for (int i = 0; i < 2; i++)
			{
				_HCAHCFGPJIF_Desc = _HCAHCFGPJIF_Desc.Replace(i == 0 ? "[dv]" : "[dv2]", PHAGNOHBMCM_DurationByIndexAndLevel[_CIEOBFIIPLD_Level - 1, i].ToString());
			}
		}
		return _HCAHCFGPJIF_Desc;
	}
}

public class PPGHMBNIAEC
{
	public int BEKFHEBCPEE_lid; // 0x8 LiveSkillId
	public short[,] NKGHBKFMFCI_BuffValue = new short[5, 2]; // 0xC BuffValueByIndexAndLevel
	public short[,] PHAGNOHBMCM_DurationByIndexAndLevel = new short[5, 2]; // 0x10
	public short[] LFGFBMJNBKN_ConfigValue = new short[5]; // 0x14
	public int FLJHGGKIOJH_SkillType; // 0x18
	public byte[] EGLDFPILJLG_SkillBuffEffect; // 0x1C
	public byte[] FPMFEKIPFPI_DurationType; // 0x20
	public int[] ELEPHBOKIGK_Limit; // 0x24
	public byte CPNAGMFCIJK_TriggerType; // 0x28
	public byte JGDJACOPHJP_LineTarget; // 0x29
	public byte JGNHOGKKPDM; // 0x2A
	public int[] MKPJBDFDHOL_ThumbId; // 0x2C
	public int GIEFBAHPMMM; // 0x30
	public int CEFHDLLAPDH_MusicId; // 0x34
	public int NFIBKOACELP_Attr; // 0x38
	public int POMLAENHCHA_TargetSkillEffectId; // 0x3C
	public int DPGDCJFBFGK_TargetSkillType; // 0x40
	public int AOPELJFAMCL_LiveSkillType; // 0x44

	//// RVA: 0xDF6D74 Offset: 0xDF6D74 VA: 0xDF6D74
	//public uint CAOGDCBPBAN() { }

	//// RVA: 0xDF70CC Offset: 0xDF70CC VA: 0xDF70CC
	public string KMFMGLENCJH_FormatDesc(string _HCAHCFGPJIF_Desc, int _CIEOBFIIPLD_Level)
	{
		if(_CIEOBFIIPLD_Level > 0)
		{
			string str = _HCAHCFGPJIF_Desc;
			for(int i = 0; i < 2; i++)
			{
				DKGNGLBCPKA(ref str, _CIEOBFIIPLD_Level, i);
			}
			for(int i = 0; i < 2; i++)
			{
				short a = PHAGNOHBMCM_DurationByIndexAndLevel[_CIEOBFIIPLD_Level - 1, i];
				str = str.Replace(i == 0 ? "[dv]" : "[dv2]", a.ToString());
			}
			return str.Replace("[tv]", LFGFBMJNBKN_ConfigValue[_CIEOBFIIPLD_Level - 1].ToString());
		}
		return _HCAHCFGPJIF_Desc;
	}

	//// RVA: 0xDF72D8 Offset: 0xDF72D8 VA: 0xDF72D8
	private void DKGNGLBCPKA(ref string IAPANOCEMBI, int GBMHFDKCFGB, int AOGDKBPNGCI)
	{
		string res = "";
		string a, b;
		if(EGLDFPILJLG_SkillBuffEffect[AOGDKBPNGCI] == (int)SkillBuffEffect.Type.ScoreUpPercentage_FoldWave || 
		EGLDFPILJLG_SkillBuffEffect[AOGDKBPNGCI] == (int)SkillBuffEffect.Type.ScoreUpPercentage_Intimacy)
		{
			EHGAHMIBPIB s = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.HJGDBBPDHON(NKGHBKFMFCI_BuffValue[GBMHFDKCFGB - 1, AOGDKBPNGCI]);

			IAPANOCEMBI = IAPANOCEMBI.Replace(string.Format("[v{0}_1]", AOGDKBPNGCI + 1), s.KCOHMHFBDKF_Value1[GBMHFDKCFGB - 1].ToString());
			IAPANOCEMBI = IAPANOCEMBI.Replace(string.Format("[v{0}_2]", AOGDKBPNGCI + 1), s.HLMMBNCIIAC_Value2[GBMHFDKCFGB - 1].ToString());

			a = string.Format("[v{0}_max]", AOGDKBPNGCI + 1);
			res = IAPANOCEMBI;
			b = s.DOOGFEGEKLG_max.ToString();
		}
		else
		{
			res = IAPANOCEMBI;
			a = AOGDKBPNGCI == 0 ? "[v1]" : "[v2]";
			b = NKGHBKFMFCI_BuffValue[GBMHFDKCFGB - 1, AOGDKBPNGCI].ToString();
		}
		IAPANOCEMBI = res.Replace(a, b);
	}

	//// RVA: 0xDF76D0 Offset: 0xDF76D0 VA: 0xDF76D0
	public bool AANDPLGPDEI()
	{
		return CEFHDLLAPDH_MusicId > 0;
	}

	//// RVA: 0xDF76E4 Offset: 0xDF76E4 VA: 0xDF76E4
	public bool HDPIEILADDH(int _DLAEJOBELBH_MusicId)
	{
		return CEFHDLLAPDH_MusicId == _DLAEJOBELBH_MusicId;
	}

	//// RVA: 0xDF76F8 Offset: 0xDF76F8 VA: 0xDF76F8
	public bool HCGDJAFINMH()
	{
		return NFIBKOACELP_Attr > 0;
	}

	//// RVA: 0xDF770C Offset: 0xDF770C VA: 0xDF770C
	public bool OEJNKFONOGJ(int FJFCNGNGIBN)
	{
		return NFIBKOACELP_Attr == FJFCNGNGIBN;
	}
}

public class EDPDCLMMBPL
{
	public int LGCPDKGMLJI; // 0x8
	public int CHOFDPDFPDC_ConfigValue; // 0xC //SwitchPatternCondition
	public int PNCCGBBHLLP; // 0x10
	public int KGBMHHFLGEE; // 0x14

	//// RVA: 0x150FB30 Offset: 0x150FB30 VA: 0x150FB30
	//public uint CAOGDCBPBAN() { }
}

public class BMMNKCJOHOM
{
	public int LGCPDKGMLJI; // 0x8
	public int CHOFDPDFPDC_ConfigValue; // 0xC //SwitchPatternCondition
	public int PNCCGBBHLLP; // 0x10
	public int KGBMHHFLGEE; // 0x14

	//// RVA: 0x19CA094 Offset: 0x19CA094 VA: 0x19CA094
	//public uint CAOGDCBPBAN() { }
}

public class PKLNDFNKINB
{
	public List<int> OMIMBPNKOKE_SubGoalPercent = new List<int>(); // 0x8
	public List<int> HGIOBLMAAEO_GoalPercent = new List<int>(); // 0xC

	//// RVA: 0x93FC48 Offset: 0x93FC48 VA: 0x93FC48
	//public uint CAOGDCBPBAN() { }
}

public class BNHOEENHMDF
{
	public int PPFNGGCBJKC_id; // 0x8
	public int MKDDOJOADMF; // 0xC
	public List<AFLHKMDNHID> NNDGIAEFMOG = new List<AFLHKMDNHID>(); // 0x10

	public int PLALNIIBLOF_en { get
	{
		if(NNDGIAEFMOG.Count == 0)
			return 0;
		for(int i = 0; i < NNDGIAEFMOG.Count; i++)
		{
			if(NNDGIAEFMOG[i].PLALNIIBLOF_en != 2)
				return 0;
		}
		return 2;
	} } //0x19CABD8 JPCJNLHHIPE

	//// RVA: 0x19CACF0 Offset: 0x19CACF0 VA: 0x19CACF0
	//public uint CAOGDCBPBAN() { }
}

public class AFLHKMDNHID
{
	public int PPFNGGCBJKC_id; // 0x8
	public int PLALNIIBLOF_en; // 0xC
	public int MKDDOJOADMF; // 0x10
	public byte[] INDDJNMPONH_type; // 0x14
	public byte[] GJLFANGDGCL_Target; // 0x18
	public int[] OAFPGJLCNFM_cond; // 0x1C

	//// RVA: 0x15C3270 Offset: 0x15C3270 VA: 0x15C3270
	//public uint CAOGDCBPBAN() { }
}

// Namespace: 
public class HCDIOPEOGEE // TypeDefIndex: 10027
{
	public int PPFNGGCBJKC_id; // 0x8
	public int MKDDOJOADMF; // 0xC
	public List<CCINPCJDFJG> NNDGIAEFMOG = new List<CCINPCJDFJG>(); // 0x10

	public int PLALNIIBLOF_en { get {
		if(NNDGIAEFMOG.Count == 0)
			return 0;
		for(int i = 0; i < NNDGIAEFMOG.Count; i++)
		{
			if(NNDGIAEFMOG[i].PLALNIIBLOF_en != 2)
				return 0;
		}
		return 2;
	} } //0x173F688 JPCJNLHHIPE

	//// RVA: 0x173F7A0 Offset: 0x173F7A0 VA: 0x173F7A0
	//public uint CAOGDCBPBAN() { }
}

public class CCINPCJDFJG
{
	public int PPFNGGCBJKC_id; // 0x8
	public int PLALNIIBLOF_en; // 0xC
	public int MKDDOJOADMF; // 0x10
	public byte[] EGLDFPILJLG_SkillBuffEffect; // 0x14
	public byte[] FPMFEKIPFPI_DurationType; // 0x18

	//// RVA: 0x190984C Offset: 0x190984C VA: 0x190984C
	//public uint CAOGDCBPBAN() { }
}

public class DNIDPGDJCOG
{
	public int PPFNGGCBJKC_id; // 0x8
	public int MKDDOJOADMF; // 0xC
	public List<FCNGHAJPMEA> NNDGIAEFMOG = new List<FCNGHAJPMEA>(); // 0x10

	public int PLALNIIBLOF_en { get {
		if(NNDGIAEFMOG.Count == 0)
			return 0;
		for(int i = 0; i < NNDGIAEFMOG.Count; i++)
		{
			if(NNDGIAEFMOG[i].PLALNIIBLOF_en != 2)
				return 0;
		}
		return 2;
	} } //0x1231D14 JPCJNLHHIPE

	//// RVA: 0x1231E2C Offset: 0x1231E2C VA: 0x1231E2C
	//public uint CAOGDCBPBAN() { }
}

public class FCNGHAJPMEA
{
	public int PPFNGGCBJKC_id; // 0x8
	public int PLALNIIBLOF_en; // 0xC
	public int MKDDOJOADMF; // 0x10
	public int NEHDLDEHFCD; // 0x14
	public byte[] EGLDFPILJLG_SkillBuffEffect; // 0x18
	public byte[] FPMFEKIPFPI_DurationType; // 0x1C
	public byte CPNAGMFCIJK_TriggerType; // 0x20
	public int CEFHDLLAPDH_MusicId; // 0x24
	public int NFIBKOACELP_Attr; // 0x28
	public int BHADMHLIFMM; // 0x2C

	//// RVA: 0xFC7C70 Offset: 0xFC7C70 VA: 0xFC7C70
	//public uint CAOGDCBPBAN() { }
}

[System.Obsolete("Use FOKHDKJJOFB_EffectByNumDiva", true)]
public class FOKHDKJJOFB { }
public class FOKHDKJJOFB_EffectByNumDiva
{
	public int[] NANNGLGOFKH_value; // 0x8
	public int NNDBJGDFEEM_Min; // 0xC
	public int FDBOPFEOENF_diva; // 0x10

	//// RVA: 0x13F5500 Offset: 0x13F5500 VA: 0x13F5500
	//public uint CAOGDCBPBAN() { }
}

public class EHGAHMIBPIB
{
	public int[] KCOHMHFBDKF_Value1; // 0x8
	public int[] HLMMBNCIIAC_Value2; // 0xC
	public int DOOGFEGEKLG_max; // 0x10

	//// RVA: 0x12E9C60 Offset: 0x12E9C60 VA: 0x12E9C60
	//public uint CAOGDCBPBAN() { }
}

public class ALECCMCNIBG
{
	public uint PPFNGGCBJKC_id; // 0x8
	public int[] LGFLNOJDHHC_Targets; // 0xC // SkillBuffEffects

	//// RVA: 0xCD7D38 Offset: 0xCD7D38 VA: 0xCD7D38
	//public uint CAOGDCBPBAN() { }
}
