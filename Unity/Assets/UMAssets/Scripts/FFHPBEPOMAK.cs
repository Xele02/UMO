using System.Collections.Generic;
using System.Text;
using XeApp.Game;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys;

[System.Obsolete("Use FFHPBEPOMAK_DivaInfo", true)]
public class FFHPBEPOMAK { }
public class FFHPBEPOMAK_DivaInfo
{
	public class CLKBDNBMJCO
	{
		private const int FBGGEFFJJHB = 1561969535; // 0x5d19c37f
		private int IJNIDKLFABD; // 0x8
		private int JHKNDAGGOMG; // 0xC
		private int KLDFJGOKIKC; // 0x10
		private int CNKBEJHMHCP; // 0x14
		private int LMFEACDAOBG; // 0x18
		private int KCHNHFLJIDD; // 0x1C

		public int KAMIJDBFGDB_EvSoLevel { get { return IJNIDKLFABD ^ FBGGEFFJJHB; } set { IJNIDKLFABD = value ^ FBGGEFFJJHB; } } //0x14E4A68 JKMGKELCKFE 0x14E4A7C BPLJELMBGNK
		public int BPEFIIEPJBM_EvVoLevel { get { return JHKNDAGGOMG ^ FBGGEFFJJHB; } set { JHKNDAGGOMG = value ^ FBGGEFFJJHB; } } //0x14E4A90 NLKDKJCIFDF 0x14E4AA4 LEIHBEEKPMI
		public int DNFEEOODOBF_EvChLevel { get { return KLDFJGOKIKC ^ FBGGEFFJJHB; } set { KLDFJGOKIKC = value ^ FBGGEFFJJHB; } } //0x14E4AB8 DPKJFEPHFHK 0x14E4ACC MEEEIOFKEMI
		public int EMGLOGKKGKJ { get { return CNKBEJHMHCP ^ FBGGEFFJJHB; } set { CNKBEJHMHCP = value ^ FBGGEFFJJHB; } } //0x14E4AE0 JAPHNPMIGML 0x14E4AF4 FABNIFGNNEO
		public int FKHKMNEHBOJ { get { return LMFEACDAOBG ^ FBGGEFFJJHB; } set { LMFEACDAOBG = value ^ FBGGEFFJJHB; } } //0x14E4B08 JKCKDECEFIK 0x14E4B1C ILACLIAGFCH
		public int PHOFGCKGIIA { get { return KCHNHFLJIDD ^ FBGGEFFJJHB; } set { KCHNHFLJIDD = value ^ FBGGEFFJJHB; } } //0x14E4B30 OELCFAELPOH 0x14E4B44 INNCIFMHNGJ

		// // RVA: 0x14DF200 Offset: 0x14DF200 VA: 0x14DF200
		public void KHEKNNFCAOI(int AHHJLDLAPAN)
		{
			DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo a = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[AHHJLDLAPAN - 1];
			KAMIJDBFGDB_EvSoLevel = a.MMCEMJILMJI_EvSoLevel;
			BPEFIIEPJBM_EvVoLevel = a.HDPANGMKKCP_EvVoLevel;
			DNFEEOODOBF_EvChLevel = a.FFMLBEEBHDD_EvChLevel;
		}

		// // RVA: 0x14E02F0 Offset: 0x14E02F0 VA: 0x14E02F0
		public int PNOKIEEILJN()
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OAINIGNLJKC_Diva2.LENIIENHJJK[KAMIJDBFGDB_EvSoLevel].MKMIEGPOKGG;
		}

		// // RVA: 0x14E045C Offset: 0x14E045C VA: 0x14E045C
		public int LCDIGPJJJGI()
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OAINIGNLJKC_Diva2.LENIIENHJJK[BPEFIIEPJBM_EvVoLevel].MELGGCAIONF;
		}

		// // RVA: 0x14E05C8 Offset: 0x14E05C8 VA: 0x14E05C8
		public int KDKCMCBLEMG()
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OAINIGNLJKC_Diva2.LENIIENHJJK[DNFEEOODOBF_EvChLevel].LDLHPACIIAB;
		}

		// // RVA: 0x14E4B58 Offset: 0x14E4B58 VA: 0x14E4B58
		// public int PJCKMKEJCEL() { }
	}

	private bool BNFDBPPOAOE; // 0x8
	private bool EEBBAGGJOGH; // 0x9
	public int AHHJLDLAPAN_DivaId; // 0xC
	public int CIEOBFIIPLD_Level; // 0x10
	public int AIHCEGFANAM_Serie; // 0x14
	public string OPFGFINHFCE_Name; // 0x18
	public bool FJODMPGPDDD_DivaHave; // 0x28
	public bool IPJMPBANBPP_Enabled; // 0x29
	public byte[] FFKMEFKOBHO_Mb; // 0x2C
	public List<byte[]> FGBKIPNGGJM_SubSceneMbs = new List<byte[]>(); // 0x30
	public byte[] PFCJIKGENEH_Sb; // 0x34
	public List<byte[]> GDJPNDKMKPG_SubSceneSbs = new List<byte[]>(); // 0x38
	public int AICGALGPFMO_NumBoard; // 0x3C
	public List<int> HHKFOOFPOJL_SubSceneNumBoard = new List<int>(); // 0x40
	public bool JLKPGDEKPEO_IsHave; // 0x58
	public bool CPGDEPMPMFK_EpisodeUnlocked; // 0x59
	public bool MBFADDHOEOK_IsNew; // 0x5A
	public CKFGMNAIBNG FFKMJNHFFFL_Costume = new CKFGMNAIBNG(); // 0x5C
	public CKFGMNAIBNG EGAFMGDFFCH_HomeDivaCostume = new CKFGMNAIBNG(); // 0x60
	private BBHNACPENDM_ServerSaveData LDEGEHAEALK; // 0x78
	public static DisplayType[] HBBPOMBJJNG = new DisplayType[8] { 
		DisplayType.Total, 
		DisplayType.Soul, 
		DisplayType.Vocal, 
		DisplayType.Charm, 
		DisplayType.Life, 
		DisplayType.Luck, 
		DisplayType.Support, 
		DisplayType.Fold }; // 0x0

	public StatusData JLJGCBOHJID_Status { get; private set; } = new StatusData(); // 0x1C MHGEJIKLJOP CKAOBJJCOFO MKFJBBFNFPD
	public StatusData CMCKNKKCNDK_EquippedStatus { get; private set; } = new StatusData(); // 0x20 CLCJNFNMNBH CNKGOPKANGF CHJGGLFGALP
	public List<int> DJICAKGOGFO_SubSceneIds { get; private set; } // 0x24 GIOHLILFNGF HFNMIBKHCPA OOEOBODDEBH
	public int FGFIBOBAPIA_SceneId { get; private set; } // 0x44 HIFDNPNIAAH DEDCNFGKGEH JINCEPHFFBN
	public int JPIDIENBGKH_CostumeId { get; private set; } // 0x48 CPCGNLOMIJL PHLLMIGCPCB BLBNMENMCIF
	public int EKFONBFDAAP_ColorId { get; private set; } // 0x4C GDOPIDINPAJ EIIGMAIDCAG BLGOCKHBMIG
	public int KIIMFCFMMDN_HomeCostumeId { get; private set; } // 0x50 NBEBILCKAIH GBBCNBOMGIH GAAGDLPJGKN
	public int JFFLFIMIMOI_HomeColorId { get; private set; } // 0x54 BENJFMIAAIP EPDJMLMLHIG FJBIDEJJHOD
	public int KELFCMEOPPM_EpisodeId { get; private set; } // 0x64 LOEOGJLMNME AHJNJHDELBE PJLFKEOLFMK
	public List<int> PKLPGBKKFOL_DivaLevels { get; private set; } // 0x68 IOKGPGPGGPL ODHMENNBBML JLIFOJJIDIG
	public List<int> HMBECPGHPOE_DivaExps { get; private set; } // 0x6C BAMGHOCFIIG HDJMNMAPPAJ GBMDLJBJILK
	public List<int> FOHEIOLPAOG_DivaUnlocks { get; private set; } // 0x70 IEPHLHPLBGB BEFACAKCODI HMAHEFFHNIO
	public FFHPBEPOMAK_DivaInfo.CLKBDNBMJCO IHANGGCHPAL { get; private set; } = new FFHPBEPOMAK_DivaInfo.CLKBDNBMJCO(); // 0x74 DCLILLHDINA NIBJBLCDIHD MBAKEDKIJDG

	// RVA: 0x14DE1BC Offset: 0x14DE1BC VA: 0x14DE1BC
	public void LEHDLBJJBNC()
	{
		MBFADDHOEOK_IsNew = false;
		if(!BNFDBPPOAOE || JPIDIENBGKH_CostumeId == 0)
			return;
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume.FABAGMLEKIB_List[JPIDIENBGKH_CostumeId - 1].CADENLBDAEB_IsNew = false;
	}

	// RVA: 0x14DE4E0 Offset: 0x14DE4E0 VA: 0x14DE4E0
	public void KHEKNNFCAOI(int AHHJLDLAPAN_DivaId, BBHNACPENDM_ServerSaveData NIMOGBDCMLJ, bool OJEBNBLHPNP = false)
	{
		BNFDBPPOAOE = true;
		EEBBAGGJOGH = false;
		if(NIMOGBDCMLJ == null)
		{
			LDEGEHAEALK = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
			this.AHHJLDLAPAN_DivaId = AHHJLDLAPAN_DivaId;
		}
		else
		{
			LDEGEHAEALK = NIMOGBDCMLJ;
			this.AHHJLDLAPAN_DivaId = AHHJLDLAPAN_DivaId;
		}
		PKLPGBKKFOL_DivaLevels = LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[AHHJLDLAPAN_DivaId - 1].ANAJIAENLNB_Levels;
		HMBECPGHPOE_DivaExps = LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[AHHJLDLAPAN_DivaId - 1].LKIFDCEKDCK_Exps;
		FOHEIOLPAOG_DivaUnlocks = LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[AHHJLDLAPAN_DivaId - 1].KBOLNIBLIND_Unlocks;
		FJODMPGPDDD_DivaHave = LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[AHHJLDLAPAN_DivaId - 1].CPGFPEDMDEH_Have != 0/* || RuntimeSettings.CurrentSettings.ForceDivaUnlock*/;
		IPJMPBANBPP_Enabled = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas[AHHJLDLAPAN_DivaId - 1].PPEGAKEIEGM_Enabled == 2;
		CIEOBFIIPLD_Level = LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[AHHJLDLAPAN_DivaId - 1].OKMELNIIMMO_GetDivaLevel();
		AIHCEGFANAM_Serie = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas[AHHJLDLAPAN_DivaId - 1].AIHCEGFANAM_Attr;
		OPFGFINHFCE_Name = EJOJNFDHDHN_GetName(AHHJLDLAPAN_DivaId);
		if(RuntimeSettings.CurrentSettings.DisplayIdInName)
			OPFGFINHFCE_Name = "[" + AHHJLDLAPAN_DivaId + "] "+ OPFGFINHFCE_Name;
		DJICAKGOGFO_SubSceneIds = new List<int>();
		for(int i = 0; i < LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[AHHJLDLAPAN_DivaId - 1].JCHHIPOPNIN; i++)
		{
			int val = LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[AHHJLDLAPAN_DivaId - 1].EBDNICPAFLB_SSlot[i];
			DJICAKGOGFO_SubSceneIds.Add(val);
			if(val == 0)
			{
				FGBKIPNGGJM_SubSceneMbs.Add(null);
				GDJPNDKMKPG_SubSceneSbs.Add(null);
				HHKFOOFPOJL_SubSceneNumBoard.Add(0);
			}
			else
			{
				FGBKIPNGGJM_SubSceneMbs.Add(LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[val - 1].PDNIFBEGMHC_Mb);
				GDJPNDKMKPG_SubSceneSbs.Add(LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[val - 1].EMOJHJGHJLN_Sb);
				HHKFOOFPOJL_SubSceneNumBoard.Add(LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[val - 1].JPIPENJGGDD_Mlt);
			}
		}
		FGFIBOBAPIA_SceneId = LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[AHHJLDLAPAN_DivaId - 1].PIGLAEFPNEK_MSlot;
		if(FGFIBOBAPIA_SceneId != 0)
		{
			FFKMEFKOBHO_Mb = LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[FGFIBOBAPIA_SceneId - 1].PDNIFBEGMHC_Mb;
			PFCJIKGENEH_Sb = LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[FGFIBOBAPIA_SceneId - 1].EMOJHJGHJLN_Sb;
			AICGALGPFMO_NumBoard = LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[FGFIBOBAPIA_SceneId - 1].JPIPENJGGDD_Mlt;
		}
		JPIDIENBGKH_CostumeId = LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[AHHJLDLAPAN_DivaId - 1].BEEAIAAJOHD_CostumeId;
		EKFONBFDAAP_ColorId = LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[AHHJLDLAPAN_DivaId - 1].AFNIOJHODAG_CostumeColorId;
		FFKMJNHFFFL_Costume.KHEKNNFCAOI(AHHJLDLAPAN_DivaId, JPIDIENBGKH_CostumeId, LDEGEHAEALK, OJEBNBLHPNP);
		KIIMFCFMMDN_HomeCostumeId = LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[AHHJLDLAPAN_DivaId - 1].HPJMPINPKEP_HomeCostumeId;
		JFFLFIMIMOI_HomeColorId = LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[AHHJLDLAPAN_DivaId - 1].KKEPMONFGEI_HomeCostumeColorId;
		EGAFMGDFFCH_HomeDivaCostume.KHEKNNFCAOI(AHHJLDLAPAN_DivaId, LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[AHHJLDLAPAN_DivaId - 1].HPJMPINPKEP_HomeCostumeId, 
			LDEGEHAEALK, OJEBNBLHPNP);
		if(JPIDIENBGKH_CostumeId == 0)
		{
			KELFCMEOPPM_EpisodeId = 0;
			MBFADDHOEOK_IsNew = false;
			JLKPGDEKPEO_IsHave = false;
			CPGDEPMPMFK_EpisodeUnlocked = false;
		}
		else
		{
			KELFCMEOPPM_EpisodeId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.NNFJBBFBIEN(JPIDIENBGKH_CostumeId);
			JLKPGDEKPEO_IsHave = LDEGEHAEALK.BEKHNNCGIEL_Costume.FABAGMLEKIB_List[JPIDIENBGKH_CostumeId - 1].CGKAEMGLHNK_Possessed();
			MBFADDHOEOK_IsNew = LDEGEHAEALK.BEKHNNCGIEL_Costume.FABAGMLEKIB_List[JPIDIENBGKH_CostumeId - 1].CADENLBDAEB_IsNew;
			CPGDEPMPMFK_EpisodeUnlocked = false;
			if(KELFCMEOPPM_EpisodeId != 0)
			{
				if(LDEGEHAEALK.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM_EpisodeId - 1].BEBJKJKBOGH_Date != 0)
					CPGDEPMPMFK_EpisodeUnlocked = true;
			}
		}
		IHANGGCHPAL.KHEKNNFCAOI(AHHJLDLAPAN_DivaId);
		HCDGELDHFHB();

	}

	// RVA: 0x14DFA1C Offset: 0x14DFA1C VA: 0x14DFA1C
	public void KHEKNNFCAOI(int AHHJLDLAPAN_DivaId, int PAOGPLDOMMI_Level, int PDEEMMEHDPK_CostumeId, int KOHAAFNNBOE_ColorId, GCIJNCFDNON_SceneInfo AFBMEMCHJCL_MainScene, List<GCIJNCFDNON_SceneInfo> HDJOHAJPGBA_SubScene, bool LGNOCBFCAAK = false)
	{
		EEBBAGGJOGH = LGNOCBFCAAK;
		BNFDBPPOAOE = false;
		this.AHHJLDLAPAN_DivaId = AHHJLDLAPAN_DivaId;
		CIEOBFIIPLD_Level = PAOGPLDOMMI_Level;
		BJPLLEBHAGO_DivaInfo d = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas[AHHJLDLAPAN_DivaId-1];
		AIHCEGFANAM_Serie = d.AIHCEGFANAM_Attr;
		JPIDIENBGKH_CostumeId = PDEEMMEHDPK_CostumeId;
		EKFONBFDAAP_ColorId = KOHAAFNNBOE_ColorId;
		if(!LGNOCBFCAAK)
		{
			FFKMJNHFFFL_Costume.KHEKNNFCAOI(AHHJLDLAPAN_DivaId,PDEEMMEHDPK_CostumeId,0,false);
		}
		else
		{
			FFKMJNHFFFL_Costume.KHEKNNFCAOI(AHHJLDLAPAN_DivaId,PDEEMMEHDPK_CostumeId,CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave,false);
		}
		FJODMPGPDDD_DivaHave = false;
		IPJMPBANBPP_Enabled = d.PPEGAKEIEGM_Enabled == 2;
		OPFGFINHFCE_Name = EJOJNFDHDHN_GetName(AHHJLDLAPAN_DivaId);
		if(RuntimeSettings.CurrentSettings.DisplayIdInName)
			OPFGFINHFCE_Name = "[" + AHHJLDLAPAN_DivaId + "] "+ OPFGFINHFCE_Name;
		if(HDJOHAJPGBA_SubScene != null)
		{
			DJICAKGOGFO_SubSceneIds = new List<int>();
			for(int i = 0; i < HDJOHAJPGBA_SubScene.Count; i++)
			{
				if(HDJOHAJPGBA_SubScene[i] == null)
				{
					DJICAKGOGFO_SubSceneIds.Add(0);
					FGBKIPNGGJM_SubSceneMbs.Add(null);
					GDJPNDKMKPG_SubSceneSbs.Add(null);
					HHKFOOFPOJL_SubSceneNumBoard.Add(0);
				}
				else
				{
					if(HDJOHAJPGBA_SubScene[i].BCCHOBPJJKE_SceneId == 0)
					{
						DJICAKGOGFO_SubSceneIds.Add(0);
						FGBKIPNGGJM_SubSceneMbs.Add(null);
						GDJPNDKMKPG_SubSceneSbs.Add(null);
						HHKFOOFPOJL_SubSceneNumBoard.Add(0);
					}
					else
					{
						DJICAKGOGFO_SubSceneIds.Add(HDJOHAJPGBA_SubScene[i].BCCHOBPJJKE_SceneId);
						FGBKIPNGGJM_SubSceneMbs.Add(HDJOHAJPGBA_SubScene[i].KBOLNIBLIND_Mb);
						GDJPNDKMKPG_SubSceneSbs.Add(HDJOHAJPGBA_SubScene[i].ODKMKEHJOCK_Sb);
						HHKFOOFPOJL_SubSceneNumBoard.Add(HDJOHAJPGBA_SubScene[i].JPIPENJGGDD_NumBoard);
					}
				}
			}
		}
		if(AFBMEMCHJCL_MainScene == null || AFBMEMCHJCL_MainScene.BCCHOBPJJKE_SceneId == 0)
		{
			AICGALGPFMO_NumBoard = 0;
			FFKMEFKOBHO_Mb = null;
			FGFIBOBAPIA_SceneId = 0;
			PFCJIKGENEH_Sb = null;
		}
		else
		{
			AICGALGPFMO_NumBoard = AFBMEMCHJCL_MainScene.JPIPENJGGDD_NumBoard;
			FGFIBOBAPIA_SceneId = AFBMEMCHJCL_MainScene.BCCHOBPJJKE_SceneId;
			FFKMEFKOBHO_Mb = AFBMEMCHJCL_MainScene.KBOLNIBLIND_Mb;
			PFCJIKGENEH_Sb = AFBMEMCHJCL_MainScene.ODKMKEHJOCK_Sb;
		}
		IHANGGCHPAL.KHEKNNFCAOI(AHHJLDLAPAN_DivaId);
		HCDGELDHFHB();
	}

	// // RVA: 0x14DF0BC Offset: 0x14DF0BC VA: 0x14DF0BC
	public static string EJOJNFDHDHN_GetName(int MCDINKAKFGG)
	{
		StringBuilder str = new StringBuilder(32);
		MessageBank bank = MessageManager.Instance.GetBank("master");
		str.SetFormat("diva_{0:D2}", MCDINKAKFGG);
		return bank.GetMessageByLabel(str.ToString());
	}

	// // RVA: 0x14E01A4 Offset: 0x14E01A4 VA: 0x14E01A4
	public StatusData FDFPMGHGBNN()
	{
		StatusData res = new StatusData();
		if(EEBBAGGJOGH || BNFDBPPOAOE)
		{
			if(LDEGEHAEALK == null)
			{
				LDEGEHAEALK = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
			}
			res.Copy(LDEGEHAEALK.BEKHNNCGIEL_Costume.NNIKNCGNDHK_GetStatForDiva(AHHJLDLAPAN_DivaId));
		}
		return res;
	}

	// // RVA: 0x14DF39C Offset: 0x14DF39C VA: 0x14DF39C
	public void HCDGELDHFHB()
	{
		BJPLLEBHAGO_DivaInfo a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas[AHHJLDLAPAN_DivaId - 1];
		JLJGCBOHJID_Status.soul = a.CMCKNKKCNDK_StatsByLevel[CIEOBFIIPLD_Level].PFJCOCPKABN_Soul;
		JLJGCBOHJID_Status.vocal = a.CMCKNKKCNDK_StatsByLevel[CIEOBFIIPLD_Level].JFJDLEMNKFE_Vocal;
		JLJGCBOHJID_Status.charm = a.CMCKNKKCNDK_StatsByLevel[CIEOBFIIPLD_Level].GDOLPGBLMEA_Charm;
		JLJGCBOHJID_Status.life = a.CMCKNKKCNDK_StatsByLevel[CIEOBFIIPLD_Level].HFIDCMNFBJG_Life;
		JLJGCBOHJID_Status.fold = a.CMCKNKKCNDK_StatsByLevel[CIEOBFIIPLD_Level].ONDFNOOICLE_Fold;
		JLJGCBOHJID_Status.support = a.CMCKNKKCNDK_StatsByLevel[CIEOBFIIPLD_Level].HCFOMFDPGEC_Support;
		JLJGCBOHJID_Status.soul += IHANGGCHPAL.PNOKIEEILJN();
		JLJGCBOHJID_Status.vocal += IHANGGCHPAL.LCDIGPJJJGI();
		JLJGCBOHJID_Status.charm += IHANGGCHPAL.KDKCMCBLEMG();
		if(EEBBAGGJOGH || BNFDBPPOAOE)
		{
			JLJGCBOHJID_Status.Add(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume.NNIKNCGNDHK_GetStatForDiva(AHHJLDLAPAN_DivaId));
		}
		CMCKNKKCNDK_EquippedStatus.Copy(JLJGCBOHJID_Status);
		if(FGFIBOBAPIA_SceneId != 0)
		{
			CMCKNKKCNDK_EquippedStatus.Add(GCIJNCFDNON_SceneInfo.JPCAIAAOOLN(FGFIBOBAPIA_SceneId, FFKMEFKOBHO_Mb, PFCJIKGENEH_Sb, AICGALGPFMO_NumBoard, 0));
		}
		if(DJICAKGOGFO_SubSceneIds != null)
		{
			for(int i = 0; i < DJICAKGOGFO_SubSceneIds.Count; i++)
			{
				if(DJICAKGOGFO_SubSceneIds[i] != 0)
				{
					CMCKNKKCNDK_EquippedStatus.Add(GCIJNCFDNON_SceneInfo.JPCAIAAOOLN(DJICAKGOGFO_SubSceneIds[i], FGBKIPNGGJM_SubSceneMbs[i], GDJPNDKMKPG_SubSceneSbs[i], HHKFOOFPOJL_SubSceneNumBoard[i], 0));
				}
			}
		}
	}

	// // RVA: 0x14E0734 Offset: 0x14E0734 VA: 0x14E0734
	public void ELHBGKLLOIO()
	{
		JLJGCBOHJID_Status.Clear();
		CMCKNKKCNDK_EquippedStatus.Copy(JLJGCBOHJID_Status);
		if(FGFIBOBAPIA_SceneId != 0)
		{
			CMCKNKKCNDK_EquippedStatus.Add(GCIJNCFDNON_SceneInfo.JPCAIAAOOLN(FGFIBOBAPIA_SceneId, FFKMEFKOBHO_Mb, PFCJIKGENEH_Sb, AICGALGPFMO_NumBoard, 0));
		}
		if(DJICAKGOGFO_SubSceneIds != null)
		{
			for(int i = 0; i < DJICAKGOGFO_SubSceneIds.Count; i++)
			{
				if(DJICAKGOGFO_SubSceneIds[i] != 0)
				{
					CMCKNKKCNDK_EquippedStatus.Add(GCIJNCFDNON_SceneInfo.JPCAIAAOOLN(DJICAKGOGFO_SubSceneIds[i], FGBKIPNGGJM_SubSceneMbs[i], GDJPNDKMKPG_SubSceneSbs[i], HHKFOOFPOJL_SubSceneNumBoard[i], 0));
				}
			}
		}
	}

	// // RVA: 0x14E09E8 Offset: 0x14E09E8 VA: 0x14E09E8
	public bool OKDIEDCGODF(int BCCHOBPJJKE, bool ILBBPPMLLFM, KDMCFCBMAOI BBEBHGEHMMI, BLHOMPPGBMI NGMPDMCBNJB)
	{
		if(!BNFDBPPOAOE)
		{
			if(!ILBBPPMLLFM)
			{
				FGFIBOBAPIA_SceneId = BCCHOBPJJKE;
			}
		}
		else
		{
			DEKKMGAFJCG_Diva.IFHCNLAODKG d = LDEGEHAEALK.DGCJCAHIAPP_Diva.JOGOEIEKIHP(BCCHOBPJJKE);
			if(d != null)
			{
				if(BBEBHGEHMMI == null)
					return false;
				if(ILBBPPMLLFM)
					return false;
				if(!BBEBHGEHMMI.Invoke(d.AHHJLDLAPAN_DivaId, d.LGBDBBFEPGL_SceneSlotIdx, d.BCCHOBPJJKE_SceneId))
					return false;
			}
			if(!ILBBPPMLLFM)
			{
				DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo saveDiva = LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[AHHJLDLAPAN_DivaId - 1];
				int oldSlot = saveDiva.PIGLAEFPNEK_MSlot;
				saveDiva.PIGLAEFPNEK_MSlot = BCCHOBPJJKE;
				FGFIBOBAPIA_SceneId = BCCHOBPJJKE;
				AICGALGPFMO_NumBoard = 0;
				if(BCCHOBPJJKE == 0)
				{
					PFCJIKGENEH_Sb = null;
					FFKMEFKOBHO_Mb = null;
				}
				else
				{
					FFKMEFKOBHO_Mb = LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[BCCHOBPJJKE - 1].PDNIFBEGMHC_Mb;
					PFCJIKGENEH_Sb = LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[BCCHOBPJJKE - 1].EMOJHJGHJLN_Sb;
					AICGALGPFMO_NumBoard = LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[BCCHOBPJJKE - 1].JPIPENJGGDD_Mlt;
				}
				HCDGELDHFHB();
				if(NGMPDMCBNJB != null && d != null && oldSlot != 0)
				{
					NGMPDMCBNJB(d.AHHJLDLAPAN_DivaId, d.LGBDBBFEPGL_SceneSlotIdx, oldSlot);
				}
			}
		}
		return true;
	}

	// // RVA: 0x14E0D08 Offset: 0x14E0D08 VA: 0x14E0D08
	public bool MNBNLONEDPF(bool ILBBPPMLLFM)
	{
		if(!BNFDBPPOAOE)
		{
			if(!ILBBPPMLLFM)
			{
				FGFIBOBAPIA_SceneId = 0;
			}
		}
		else
		{
			if(!ILBBPPMLLFM)
			{
				LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[AHHJLDLAPAN_DivaId - 1].PIGLAEFPNEK_MSlot = 0;
				FFKMEFKOBHO_Mb = null;
				FGFIBOBAPIA_SceneId = 0;
				PFCJIKGENEH_Sb = null;
				AICGALGPFMO_NumBoard = 0;
				HCDGELDHFHB();
			}
		}
		return true;
	}

	// // RVA: 0x14E0E34 Offset: 0x14E0E34 VA: 0x14E0E34
	public bool IFFMDJHENHB(int IMJIADPJJMM, int BCCHOBPJJKE, bool ILBBPPMLLFM, KDMCFCBMAOI BBEBHGEHMMI, BLHOMPPGBMI NGMPDMCBNJB)
	{
		if(!BNFDBPPOAOE)
		{
			DJICAKGOGFO_SubSceneIds[IMJIADPJJMM] = BCCHOBPJJKE;
			FGBKIPNGGJM_SubSceneMbs[IMJIADPJJMM] = null;
			GDJPNDKMKPG_SubSceneSbs[IMJIADPJJMM] = null;
			HHKFOOFPOJL_SubSceneNumBoard[IMJIADPJJMM] = 0;
		}
		else
		{
			DEKKMGAFJCG_Diva.IFHCNLAODKG d = LDEGEHAEALK.DGCJCAHIAPP_Diva.JOGOEIEKIHP(BCCHOBPJJKE);
			if(d == null)
			{
				if(ILBBPPMLLFM)
					return true;
			}
			else
			{
				if(BBEBHGEHMMI == null)
					return false;
				if(ILBBPPMLLFM)
					return false;
				if(!BBEBHGEHMMI(d.AHHJLDLAPAN_DivaId, d.LGBDBBFEPGL_SceneSlotIdx, d.BCCHOBPJJKE_SceneId))
					return false;
			}
			DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo saveDiva = LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[AHHJLDLAPAN_DivaId - 1];
			int oldSlot = saveDiva.EBDNICPAFLB_SSlot[IMJIADPJJMM];
			DJICAKGOGFO_SubSceneIds[IMJIADPJJMM] = BCCHOBPJJKE;
			saveDiva.EBDNICPAFLB_SSlot[IMJIADPJJMM] = BCCHOBPJJKE;
			if(BCCHOBPJJKE == 0)
			{
				FGBKIPNGGJM_SubSceneMbs[IMJIADPJJMM] = null;
				GDJPNDKMKPG_SubSceneSbs[IMJIADPJJMM] = null;
				HHKFOOFPOJL_SubSceneNumBoard[IMJIADPJJMM] = 0;
			}
			else
			{
				FGBKIPNGGJM_SubSceneMbs[IMJIADPJJMM] = LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[BCCHOBPJJKE - 1].PDNIFBEGMHC_Mb;
				GDJPNDKMKPG_SubSceneSbs[IMJIADPJJMM] = LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[BCCHOBPJJKE - 1].EMOJHJGHJLN_Sb;
				HHKFOOFPOJL_SubSceneNumBoard[IMJIADPJJMM] = LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[BCCHOBPJJKE - 1].JPIPENJGGDD_Mlt;
			}
			HCDGELDHFHB();
			if(NGMPDMCBNJB != null && d != null && oldSlot != 0)
			{
				NGMPDMCBNJB(d.AHHJLDLAPAN_DivaId, d.LGBDBBFEPGL_SceneSlotIdx, oldSlot);
			}
		}
		return true;
	}

	// // RVA: 0x14E13AC Offset: 0x14E13AC VA: 0x14E13AC
	public bool BCEJOOCGBFG(int IMJIADPJJMM, bool ILBBPPMLLFM)
	{
		if(!BNFDBPPOAOE)
		{
			DJICAKGOGFO_SubSceneIds[IMJIADPJJMM] = 0;
			FGBKIPNGGJM_SubSceneMbs[IMJIADPJJMM] = null;
			GDJPNDKMKPG_SubSceneSbs[IMJIADPJJMM] = null;
			HHKFOOFPOJL_SubSceneNumBoard[IMJIADPJJMM] = 0;
		}
		else
		{
			if(!ILBBPPMLLFM)
			{
				LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[AHHJLDLAPAN_DivaId - 1].EBDNICPAFLB_SSlot[IMJIADPJJMM] = 0;
				DJICAKGOGFO_SubSceneIds[IMJIADPJJMM] = 0;
				FGBKIPNGGJM_SubSceneMbs[IMJIADPJJMM] = null;
				GDJPNDKMKPG_SubSceneSbs[IMJIADPJJMM] = null;
				HHKFOOFPOJL_SubSceneNumBoard[IMJIADPJJMM] = 0;
				HCDGELDHFHB();
			}
		}
		return true;
	}

	// // RVA: 0x14E168C Offset: 0x14E168C VA: 0x14E168C
	public void GFHOGBPOJDN(int PIHCLIPPNPB, int GFBJMMNGHAA, int FKCLAAAECLO, KDMCFCBMAOI BBEBHGEHMMI)
	{
		if(PIHCLIPPNPB == 0)
		{
			MNBNLONEDPF(false);
		}
		else
		{
			OKDIEDCGODF(PIHCLIPPNPB, false, BBEBHGEHMMI, null);
		}
		if(GFBJMMNGHAA == 0)
		{
			BCEJOOCGBFG(0, false);
		}
		else
		{
			IFFMDJHENHB(0, GFBJMMNGHAA, false, BBEBHGEHMMI, null);
		}
		if (FKCLAAAECLO == 0)
		{
			BCEJOOCGBFG(1, false);
		}
		else
		{
			IFFMDJHENHB(1, FKCLAAAECLO, false, BBEBHGEHMMI, null);
		}
	}

	// // RVA: 0x14E1758 Offset: 0x14E1758 VA: 0x14E1758
	public void HOOJOFACOEK_SetCostume(int PDEEMMEHDPK, int HEHKNMCDBJJ, bool MNGIDJDFBFD = false, bool OJEBNBLHPNP = false)
	{
		JPIDIENBGKH_CostumeId = PDEEMMEHDPK;
		EKFONBFDAAP_ColorId = HEHKNMCDBJJ;
		if(!BNFDBPPOAOE)
		{
			FFKMJNHFFFL_Costume.KHEKNNFCAOI(AHHJLDLAPAN_DivaId, PDEEMMEHDPK, 0, OJEBNBLHPNP);
		}
		else
		{
			FFKMJNHFFFL_Costume.KHEKNNFCAOI(AHHJLDLAPAN_DivaId, PDEEMMEHDPK, LDEGEHAEALK, OJEBNBLHPNP);
		}
		if(BNFDBPPOAOE && MNGIDJDFBFD)
		{
			if(JPIDIENBGKH_CostumeId == 0)
			{
				JLKPGDEKPEO_IsHave = true;
				KELFCMEOPPM_EpisodeId = 0;
				MBFADDHOEOK_IsNew = false;
			}
			else
			{
				if(FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId == 1)
				{
					KELFCMEOPPM_EpisodeId = 0;
					MBFADDHOEOK_IsNew = false;
					JLKPGDEKPEO_IsHave = true;
					CPGDEPMPMFK_EpisodeUnlocked = false;
				}
				else
				{
					KELFCMEOPPM_EpisodeId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.NNFJBBFBIEN(JPIDIENBGKH_CostumeId);
					JLKPGDEKPEO_IsHave = LDEGEHAEALK.BEKHNNCGIEL_Costume.FABAGMLEKIB_List[JPIDIENBGKH_CostumeId - 1].CGKAEMGLHNK_Possessed();
					MBFADDHOEOK_IsNew = LDEGEHAEALK.BEKHNNCGIEL_Costume.FABAGMLEKIB_List[JPIDIENBGKH_CostumeId - 1].CADENLBDAEB_IsNew;
					CPGDEPMPMFK_EpisodeUnlocked = false;
					if(KELFCMEOPPM_EpisodeId != 0)
					{
						if(LDEGEHAEALK.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM_EpisodeId - 1].BEBJKJKBOGH_Date != 0)
						{
							CPGDEPMPMFK_EpisodeUnlocked = true;
						}
					}
				}
			}
		}
		if (!BNFDBPPOAOE || MNGIDJDFBFD)
			return;
		LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[AHHJLDLAPAN_DivaId - 1].BEEAIAAJOHD_CostumeId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_GetUnlockedCostumeOrDefault(AHHJLDLAPAN_DivaId, PDEEMMEHDPK).JPIDIENBGKH_CostumeId;
		LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[AHHJLDLAPAN_DivaId - 1].AFNIOJHODAG_CostumeColorId = HEHKNMCDBJJ;
	}

	// // RVA: 0x14E1C7C Offset: 0x14E1C7C VA: 0x14E1C7C
	public void JEIGPGNJJCP_SetCostumeColor(int HEHKNMCDBJJ)
	{
		EKFONBFDAAP_ColorId = HEHKNMCDBJJ;
	}

	// // RVA: 0x14E1C84 Offset: 0x14E1C84 VA: 0x14E1C84
	public void JFIPEKCDKLG(int PDEEMMEHDPK, int HEHKNMCDBJJ, bool OJEBNBLHPNP = false)
	{
		KIIMFCFMMDN_HomeCostumeId = PDEEMMEHDPK;
		JFFLFIMIMOI_HomeColorId = HEHKNMCDBJJ;
		if(!BNFDBPPOAOE)
		{
			EGAFMGDFFCH_HomeDivaCostume.KHEKNNFCAOI(AHHJLDLAPAN_DivaId, PDEEMMEHDPK, 0, OJEBNBLHPNP);
		}
		else
		{
			EGAFMGDFFCH_HomeDivaCostume.KHEKNNFCAOI(AHHJLDLAPAN_DivaId, PDEEMMEHDPK, LDEGEHAEALK, OJEBNBLHPNP);
		}
	}

	// // RVA: 0x14E1D28 Offset: 0x14E1D28 VA: 0x14E1D28
	public void OPDBFHFKKJN(int PDEEMMEHDPK, int HEHKNMCDBJJ, bool OJEBNBLHPNP = false)
	{
		JFIPEKCDKLG(PDEEMMEHDPK, HEHKNMCDBJJ, OJEBNBLHPNP);
		if(!BNFDBPPOAOE)
			return;
		DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo d = LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[AHHJLDLAPAN_DivaId - 1];
        LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cosInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_GetUnlockedCostumeOrDefault(AHHJLDLAPAN_DivaId, PDEEMMEHDPK);
		d.HPJMPINPKEP_HomeCostumeId = cosInfo.JPIDIENBGKH_CostumeId;
		d.KKEPMONFGEI_HomeCostumeColorId = HEHKNMCDBJJ;
    }

	// // RVA: 0x14E1F38 Offset: 0x14E1F38 VA: 0x14E1F38
	// public void HFMDICFNFNO(int HEHKNMCDBJJ) { }

	// // RVA: 0x14E1F40 Offset: 0x14E1F40 VA: 0x14E1F40
	public int EOJIGHEFIAA_GetHomeDivaPrismCostumeId()
	{
		return (GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId < 1 ? FFKMJNHFFFL_Costume : EGAFMGDFFCH_HomeDivaCostume).DAJGPBLEEOB_PrismCostumeId;
	}

	// // RVA: 0x14E2058 Offset: 0x14E2058 VA: 0x14E2058
	public int LHGJHJLGPBE_GetHomeDivaColorId()
	{
		return (GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId < 1 ? EKFONBFDAAP_ColorId : JFFLFIMIMOI_HomeColorId);
	}

	// // RVA: 0x14E2154 Offset: 0x14E2154 VA: 0x14E2154
	public void ODFBCANBLIJ(GCIJNCFDNON_SceneInfo PNLOINMCCKH)
	{
		if(PNLOINMCCKH == null)
		{
			AICGALGPFMO_NumBoard = 0;
			FFKMEFKOBHO_Mb = null;
			FGFIBOBAPIA_SceneId = 0;
			PFCJIKGENEH_Sb = null;
		}
		else
		{
			FGFIBOBAPIA_SceneId = PNLOINMCCKH.BCCHOBPJJKE_SceneId;
			FFKMEFKOBHO_Mb = PNLOINMCCKH.KBOLNIBLIND_Mb;
			PFCJIKGENEH_Sb = PNLOINMCCKH.ODKMKEHJOCK_Sb;
			AICGALGPFMO_NumBoard = PNLOINMCCKH.JPIPENJGGDD_NumBoard;
		}
		ELHBGKLLOIO();
	}

	// // RVA: 0x14E2194 Offset: 0x14E2194 VA: 0x14E2194
	public void GOEDGNGDMCN(GCIJNCFDNON_SceneInfo PNLOINMCCKH, int IMJIADPJJMM)
	{
		if(PNLOINMCCKH == null)
		{
			DJICAKGOGFO_SubSceneIds[IMJIADPJJMM] = 0;
			FGBKIPNGGJM_SubSceneMbs[IMJIADPJJMM] = null;
			GDJPNDKMKPG_SubSceneSbs[IMJIADPJJMM] = null;
			HHKFOOFPOJL_SubSceneNumBoard[IMJIADPJJMM] = 0;
		}
		else
		{
			DJICAKGOGFO_SubSceneIds[IMJIADPJJMM] = PNLOINMCCKH.BCCHOBPJJKE_SceneId;
			FGBKIPNGGJM_SubSceneMbs[IMJIADPJJMM] = PNLOINMCCKH.KBOLNIBLIND_Mb;
			GDJPNDKMKPG_SubSceneSbs[IMJIADPJJMM] = PNLOINMCCKH.ODKMKEHJOCK_Sb;
			HHKFOOFPOJL_SubSceneNumBoard[IMJIADPJJMM] = PNLOINMCCKH.JPIPENJGGDD_NumBoard;
		}
		ELHBGKLLOIO();
	}

	// // RVA: 0x14E239C Offset: 0x14E239C VA: 0x14E239C
	public void CJBBDBGDFKJ(GCIJNCFDNON_SceneInfo PNLOINMCCKH, bool FBBNPFFEJBN = false)
	{
		bool a = false;
		if(PNLOINMCCKH != null)
		{
			a = FGFIBOBAPIA_SceneId == PNLOINMCCKH.BCCHOBPJJKE_SceneId;
		}
		if(FBBNPFFEJBN || a)
		{
			FFKMEFKOBHO_Mb = null;
			FGFIBOBAPIA_SceneId = 0;
			PFCJIKGENEH_Sb = null;
			AICGALGPFMO_NumBoard = 0;
		}
		ELHBGKLLOIO();
	}

	// // RVA: 0x14E23DC Offset: 0x14E23DC VA: 0x14E23DC
	public void GIGDKIHBDHB(GCIJNCFDNON_SceneInfo PNLOINMCCKH, int IMJIADPJJMM, bool FBBNPFFEJBN = false)
	{
		if(FBBNPFFEJBN || (PNLOINMCCKH != null && DJICAKGOGFO_SubSceneIds[IMJIADPJJMM] == PNLOINMCCKH.BCCHOBPJJKE_SceneId))
		{
			DJICAKGOGFO_SubSceneIds[IMJIADPJJMM] = 0;
			FGBKIPNGGJM_SubSceneMbs[IMJIADPJJMM] = null;
			GDJPNDKMKPG_SubSceneSbs[IMJIADPJJMM] = null;
			HHKFOOFPOJL_SubSceneNumBoard[IMJIADPJJMM] = 0;
		}
		ELHBGKLLOIO();
	}

	// // RVA: 0x14E2564 Offset: 0x14E2564 VA: 0x14E2564
	// public static int PFAGNJEPBCB(int AHHJLDLAPAN, int JPIDIENBGKH) { }

	// // RVA: 0x14E2810 Offset: 0x14E2810 VA: 0x14E2810
	public static List<FFHPBEPOMAK_DivaInfo> DNAIGDHCILM_GetCostumeList(int AHHJLDLAPAN, bool OJEBNBLHPNP = false)
	{
		List<FFHPBEPOMAK_DivaInfo> res = new List<FFHPBEPOMAK_DivaInfo>();
		for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes.Count; i++)
		{
			LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cosInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[i];
			int costumeId = cosInfo.JPIDIENBGKH_CostumeId;
			if (cosInfo.AHHJLDLAPAN_PrismDivaId == AHHJLDLAPAN)
			{
				if(cosInfo.PPEGAKEIEGM_Enabled == 2)
				{
					if(cosInfo.DAJGPBLEEOB_PrismCostumeModelId == 1 || OJEBNBLHPNP)
					{
						//LAB_014e2d4c
						FFHPBEPOMAK_DivaInfo data = new FFHPBEPOMAK_DivaInfo();
						data.KHEKNNFCAOI(AHHJLDLAPAN, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, false);
						data.HOOJOFACOEK_SetCostume(cosInfo.JPIDIENBGKH_CostumeId, 0, true, OJEBNBLHPNP);
						data.JFIPEKCDKLG(cosInfo.JPIDIENBGKH_CostumeId, 0, OJEBNBLHPNP);
						res.Add(data);
					}
					else
					{
						var a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.NNFJBBFBIEN(costumeId);
						if (a == 0)
						{
							if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume.FABAGMLEKIB_List[costumeId - 1].CGKAEMGLHNK_Possessed())
							{
								FFHPBEPOMAK_DivaInfo data = new FFHPBEPOMAK_DivaInfo();
								data.KHEKNNFCAOI(AHHJLDLAPAN, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, false);
								data.HOOJOFACOEK_SetCostume(cosInfo.JPIDIENBGKH_CostumeId, 0, true, OJEBNBLHPNP);
								data.JFIPEKCDKLG(cosInfo.JPIDIENBGKH_CostumeId, 0, OJEBNBLHPNP);
								res.Add(data);
							}
						}
						else
						{
							if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[a - 1].BEBJKJKBOGH_Date != 0/* || RuntimeSettings.CurrentSettings.ForceCardsUnlock*/)
							{
								FFHPBEPOMAK_DivaInfo data = new FFHPBEPOMAK_DivaInfo();
								data.KHEKNNFCAOI(AHHJLDLAPAN, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, false);
								data.HOOJOFACOEK_SetCostume(cosInfo.JPIDIENBGKH_CostumeId, 0, true, OJEBNBLHPNP);
								data.JFIPEKCDKLG(cosInfo.JPIDIENBGKH_CostumeId, 0, OJEBNBLHPNP);
								res.Add(data);
							}
						}
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0x14E2F68 Offset: 0x14E2F68 VA: 0x14E2F68
	public static List<FFHPBEPOMAK_DivaInfo> OOJFGDKBOHK(int AHHJLDLAPAN, bool OJEBNBLHPNP = false)
	{
		List<FFHPBEPOMAK_DivaInfo> res = new List<FFHPBEPOMAK_DivaInfo>();
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes.Count; i++)
		{
            LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[i];
            if (cos.AHHJLDLAPAN_PrismDivaId == AHHJLDLAPAN)
			{
				if(cos.PPEGAKEIEGM_Enabled == 2)
				{
					if(cos.DAJGPBLEEOB_PrismCostumeModelId == 1 || OJEBNBLHPNP)
					{
						//LAB_014e36c4
                    }
					else
					{
						int ep = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.NNFJBBFBIEN(cos.JPIDIENBGKH_CostumeId);
						if(ep == 0)
						{
							if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume.FABAGMLEKIB_List[cos.JPIDIENBGKH_CostumeId - 1].CGKAEMGLHNK_Possessed())
							{
								//LAB_014e36c4
							}
							else
								continue;
						}
						else
						{
							if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[ep - 1].BEBJKJKBOGH_Date != 0)
							{
								//LAB_014e36c4
							}
							else
								continue;
						}
					}
					//LAB_014e36c4
					AMCGONHBGGF PFEPMCNHEMJ = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KMBJGAHCBDI_UnitGoDiva.ALDOJAEAMCJ(AHHJLDLAPAN, 0).FDBOPFEOENF_MainDivas[0];
					List<GCIJNCFDNON_SceneInfo> ls = new List<GCIJNCFDNON_SceneInfo>();
					ls.Add(null);
					ls.Add(null);
					GCIJNCFDNON_SceneInfo s = null;
					if(PFEPMCNHEMJ.EBDNICPAFLB_SSlot[0] != 0)
					{
						if(GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes == null)
						{
							MMPBPOIFDAF_Scene.PMKOFEIONEG ss = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA.Find((MMPBPOIFDAF_Scene.PMKOFEIONEG IBDJFHFIIHN) =>
							{
								//0x14E475C
								return IBDJFHFIIHN.PPFNGGCBJKC_Id == PFEPMCNHEMJ.EBDNICPAFLB_SSlot[0];
							});
							s = new GCIJNCFDNON_SceneInfo();
							s.KHEKNNFCAOI(PFEPMCNHEMJ.EBDNICPAFLB_SSlot[0], ss.PDNIFBEGMHC_Mb, ss.EMOJHJGHJLN_Sb, ss.JPIPENJGGDD_Mlt, ss.IELENGDJPHF_Ulk, ss.MJBODMOLOBC_Luck, ss.LHMOAJAIJCO_New, ss.BEBJKJKBOGH_Date, ss.DMNIMMGGJJJ_Leaf);
						}
						else
						{
							s = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes.Find((GCIJNCFDNON_SceneInfo AOIKKLBKEBC) =>
							{
								//0x14E47E4
								return AOIKKLBKEBC.BCCHOBPJJKE_SceneId == PFEPMCNHEMJ.EBDNICPAFLB_SSlot[0];
							});
						}
					}
					if(PFEPMCNHEMJ.EBDNICPAFLB_SSlot[1] != 0)
					{
						if(GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes == null)
						{
							MMPBPOIFDAF_Scene.PMKOFEIONEG ss = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA.Find((MMPBPOIFDAF_Scene.PMKOFEIONEG IBDJFHFIIHN) =>
							{
								//0x14E4860
								return IBDJFHFIIHN.PPFNGGCBJKC_Id == PFEPMCNHEMJ.EBDNICPAFLB_SSlot[1];
							});
							ls[0] = new GCIJNCFDNON_SceneInfo();
							ls[0].KHEKNNFCAOI(PFEPMCNHEMJ.EBDNICPAFLB_SSlot[0], ss.PDNIFBEGMHC_Mb, ss.EMOJHJGHJLN_Sb, ss.JPIPENJGGDD_Mlt, ss.IELENGDJPHF_Ulk, ss.MJBODMOLOBC_Luck, ss.LHMOAJAIJCO_New, ss.BEBJKJKBOGH_Date, ss.DMNIMMGGJJJ_Leaf);
						}
						else
						{
							ls[0] = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes.Find((GCIJNCFDNON_SceneInfo AOIKKLBKEBC) =>
							{
								//0x14E48E8
								return AOIKKLBKEBC.BCCHOBPJJKE_SceneId == PFEPMCNHEMJ.EBDNICPAFLB_SSlot[1];
							});
						}
					}
					if(PFEPMCNHEMJ.EBDNICPAFLB_SSlot[2] != 0)
					{
						if(GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes == null)
						{
							MMPBPOIFDAF_Scene.PMKOFEIONEG ss = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA.Find((MMPBPOIFDAF_Scene.PMKOFEIONEG IBDJFHFIIHN) =>
							{
								//0x14E4964
								return IBDJFHFIIHN.PPFNGGCBJKC_Id == PFEPMCNHEMJ.EBDNICPAFLB_SSlot[2];
							});
							ls[1] = new GCIJNCFDNON_SceneInfo();
							ls[1].KHEKNNFCAOI(PFEPMCNHEMJ.EBDNICPAFLB_SSlot[0], ss.PDNIFBEGMHC_Mb, ss.EMOJHJGHJLN_Sb, ss.JPIPENJGGDD_Mlt, ss.IELENGDJPHF_Ulk, ss.MJBODMOLOBC_Luck, ss.LHMOAJAIJCO_New, ss.BEBJKJKBOGH_Date, ss.DMNIMMGGJJJ_Leaf);
						}
						else
						{
							ls[1] = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes.Find((GCIJNCFDNON_SceneInfo AOIKKLBKEBC) =>
							{
								//0x14E49EC
								return AOIKKLBKEBC.BCCHOBPJJKE_SceneId == PFEPMCNHEMJ.EBDNICPAFLB_SSlot[2];
							});
						}
					}
					FFHPBEPOMAK_DivaInfo d = new FFHPBEPOMAK_DivaInfo();
					d.KHEKNNFCAOI(AHHJLDLAPAN, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, false);
					d.ODFBCANBLIJ(s);
					d.GOEDGNGDMCN(ls[0], 0);
					d.GOEDGNGDMCN(ls[1], 1);
					d.HOOJOFACOEK_SetCostume(cos.JPIDIENBGKH_CostumeId, 0, true, OJEBNBLHPNP);
					d.JFIPEKCDKLG(cos.JPIDIENBGKH_CostumeId, 0, OJEBNBLHPNP);
					d.HCDGELDHFHB();
					res.Add(d);
				}
			}
		}
		return res;
	}
}
