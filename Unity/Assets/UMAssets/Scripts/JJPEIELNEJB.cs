
using System.Collections.Generic;
using XeApp.Game;
using XeSys;

public class JJPEIELNEJB
{
	public class LKDLJCCJJNK
	{
		private int FBGGEFFJJHB_xor = GNGMCIAIKMA.FBGGEFFJJHB_xor; // 0x8
		private long BBEGLBMOBOF_xorl = GNGMCIAIKMA.BBEGLBMOBOF_xorl; // 0x10
		private int AEMBNNJLEIB_BingoIdCrypted; // 0x18
		private int EHOIENNDEDH_IdCrypted; // 0x1C
		private int CGIGOFKGCII_CryptedDivaId; // 0x20
		private int HFJLOKDMJHI_CostumeIdCrypted; // 0x24
		private int HNJNKCPDKAL_CryptedModelId; // 0x28
		private NNJFKLBPBNK_SecureString NONEFNOHBGJ = new NNJFKLBPBNK_SecureString(); // 0x2C
		private int POAOLKIEOHC_Crypted; // 0x30
		private int HHNNGNKEBDA_Crypted; // 0x34
		private NNJFKLBPBNK_SecureString KHICNFJAMNO = new NNJFKLBPBNK_SecureString(); // 0x38
		private NNJFKLBPBNK_SecureString CHMNKLMNJGI = new NNJFKLBPBNK_SecureString(); // 0x3C
		private sbyte BEHMPLPICHP_Crypted; // 0x40
		private int NCPKEALEIIG_Crypted; // 0x44
		private NNJFKLBPBNK_SecureString JAOLFCOEBKJ = new NNJFKLBPBNK_SecureString(); // 0x48
		private List<LKDLJCCJJNK> LNGGFOFLJNM = new List<LKDLJCCJJNK>(); // 0x4C

		public int APFDNBGMMMM_BingoId { get { return AEMBNNJLEIB_BingoIdCrypted ^ FBGGEFFJJHB_xor; } set { AEMBNNJLEIB_BingoIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1358E4C PBHPNJNEMHN_bgs 0x1358E5C KLPENCIJKME_bgs
		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1358E6C DEMEPMAEJOO_get_id 0x1358E7C HIGKAIDMOKN_set_id
		public int AHHJLDLAPAN_DivaId { get { return CGIGOFKGCII_CryptedDivaId ^ FBGGEFFJJHB_xor; } set { CGIGOFKGCII_CryptedDivaId = value ^ FBGGEFFJJHB_xor; } } //0x1358E8C IPKDLMIDMHH_bgs 0x1358E9C IENNENMKEFO_bgs
		public int JPIDIENBGKH_CostumeId { get { return HFJLOKDMJHI_CostumeIdCrypted ^ FBGGEFFJJHB_xor; } set { HFJLOKDMJHI_CostumeIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1358EAC PHLLMIGCPCB_bgs 0x1358EBC BLBNMENMCIF_bgs
		public int DAJGPBLEEOB_ModelId { get { return HNJNKCPDKAL_CryptedModelId ^ FBGGEFFJJHB_xor; } set { HNJNKCPDKAL_CryptedModelId = value ^ FBGGEFFJJHB_xor; } } //0x1358ECC LHPKEPPBKPF_bgs 0x1358EDC OIOEEEDODJA_bgs
		public string OJIBIPFCHJJ_CostumeName { get { return NONEFNOHBGJ.DNJEJEANJGL_Value; } set { NONEFNOHBGJ.DNJEJEANJGL_Value = value; } } //0x1358EEC AMBCADKGPCK_bgs 0x1358F18 HEKMHCMLAJJ_bgs
		public int BCCHOBPJJKE_SceneId { get { return POAOLKIEOHC_Crypted ^ FBGGEFFJJHB_xor; } set { POAOLKIEOHC_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1358F4C COHCNONLPAC_bgs 0x1358F5C HJEBBEHGHGG_bgs
		public int BOCDGDKMMIP_Rarity { get { return HHNNGNKEBDA_Crypted ^ FBGGEFFJJHB_xor; } set { HHNNGNKEBDA_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1358F6C JGEHNNFJBFC_bgs 0x1358F7C MMFLIFJMIJK_bgs
		public string LLBBBDBMMFN_SceneDetail { get { return KHICNFJAMNO.DNJEJEANJGL_Value; } set { KHICNFJAMNO.DNJEJEANJGL_Value = value; } } //0x1358F8C BMDCOLPEHOP_bgs 0x1358FB8 HJACPCKCNMA_bgs
		public string BGIMCADKCKJ_EpisodeName { get { return CHMNKLMNJGI.DNJEJEANJGL_Value; } set { CHMNKLMNJGI.DNJEJEANJGL_Value = value; } } //0x1358FEC MNIGPJKBINM_bgs 0x1359018 GNLLGODCCIL_bgs
		public bool FIKLKJBHCOH_Acquired { get { return BEHMPLPICHP_Crypted == 0x1d; } set { BEHMPLPICHP_Crypted = (sbyte)(value ? 0x1d : 0x3f); } } //0x135904C ABIADACMFEB_bgs 0x1359060 EGHECENGGHC_bgs
		public int FOAPHMMBKDM { get { return NCPKEALEIIG_Crypted ^ FBGGEFFJJHB_xor; } set { NCPKEALEIIG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1359090 LKOFKKOGJHL_bgs 0x13590A0 JDEIGMAHFKP_bgs
		public string GNKKNILFNDP_ExplanationText { get { return JAOLFCOEBKJ.DNJEJEANJGL_Value; } set { JAOLFCOEBKJ.DNJEJEANJGL_Value = value;  } } //0x13590B0 DEPDJBKFLLC_bgs 0x13590DC JJPGCPJMOKJ_bgs

		// RVA: 0x1358444 Offset: 0x1358444 VA: 0x1358444
		public LKDLJCCJJNK(int _PPFNGGCBJKC_id)
		{
			LHPDDGIJKNB_Reset(_PPFNGGCBJKC_id);
		}

		// RVA: 0x1359110 Offset: 0x1359110 VA: 0x1359110
		public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id)
		{
			BCCHOBPJJKE_SceneId = 0;
			BOCDGDKMMIP_Rarity = 0;
			AHHJLDLAPAN_DivaId = 0;
			JPIDIENBGKH_CostumeId = 0;
			DAJGPBLEEOB_ModelId = 0;
			APFDNBGMMMM_BingoId = _PPFNGGCBJKC_id;
			OJIBIPFCHJJ_CostumeName = JpStringLiterals.StringLiteral_12010;
			LLBBBDBMMFN_SceneDetail = "";
			BGIMCADKCKJ_EpisodeName = "";
			FIKLKJBHCOH_Acquired = false;
			FOAPHMMBKDM = 1;
			GNKKNILFNDP_ExplanationText = "";
		}

		//// RVA: 0x13591F8 Offset: 0x13591F8 VA: 0x13591F8
		public List<LKDLJCCJJNK> FKDIMODKKJD_GetList()
		{
			LNGGFOFLJNM.Clear();
			if(GNGMCIAIKMA.HHCJCDFCLOB != null)
			{
				GNGMCIAIKMA.DFABPMMMIIB d = GNGMCIAIKMA.HHCJCDFCLOB.GLJKKGFPEPA(APFDNBGMMMM_BingoId);
				if(d != null)
				{
					NFMHCLHEMHB_Bingo.CCGKCGJKADC bingo = GNGMCIAIKMA.HHCJCDFCLOB.MENDFPNPAAO_GetSaveBingo(APFDNBGMMMM_BingoId);
					FOAPHMMBKDM = 0;
					MessageBank bk = MessageManager.Instance.GetBank("menu");
					int divaId = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId;
					if (divaId == 0 || divaId > 10)
					{
						divaId = GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].AHHJLDLAPAN_DivaId;
						if(divaId == 0 || divaId > 10)
						{
							for(int i = 0; i < GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_DivaList.Count; i++)
							{
								if (GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_DivaList[i].FJODMPGPDDD_Unlocked)
								{
									divaId = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_DivaList[i].AHHJLDLAPAN_DivaId;
								}
							}
						}
					}
					int a = 0;
					for(int i = 0; i < d.LNHNECFGEPO.Count; i++)
					{
						LKDLJCCJJNK data = new LKDLJCCJJNK(APFDNBGMMMM_BingoId);
						data.PPFNGGCBJKC_id = d.LNHNECFGEPO[i].PPFNGGCBJKC_id;
						data.AHHJLDLAPAN_DivaId = d.LNHNECFGEPO[i].FDBOPFEOENF_diva;
						data.BCCHOBPJJKE_SceneId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(d.LNHNECFGEPO[i].GLCLFMGPMAN_ItemId[0].DNJEJEANJGL_Value);
						GCIJNCFDNON_SceneInfo scene = new GCIJNCFDNON_SceneInfo();
						scene.KHEKNNFCAOI_Init(data.BCCHOBPJJKE_SceneId, null, null, 0, 0, 0, false, 0, 0);
						data.LLBBBDBMMFN_SceneDetail = scene.BGJNIABLBDB_get_description();
						data.BOCDGDKMMIP_Rarity = scene.JOKJBMJBLBB_Single ? 2 : 1;
						PIGBBNDPPJC data2 = new PIGBBNDPPJC();
						data2.KHEKNNFCAOI_Init(scene.KELFCMEOPPM_EpisodeId);
						data.BGIMCADKCKJ_EpisodeName = data2.OPFGFINHFCE_name;
						data.GNKKNILFNDP_ExplanationText = "";
						if(!data2.CCBKMCLDGAD_HasReward)
						{
							if(data2.DMHDNKILKGI_MaxPoint <= data2.LEGAKDFPPHA_AvaiablePoint)
							{
								GNKKNILFNDP_ExplanationText = bk.GetMessageByLabel("bingo_reward_select_caution_desc");
							}
						}
						else
						{
							GNKKNILFNDP_ExplanationText = bk.GetMessageByLabel("bingo_reward_select_caution_desc1");
						}
						data.JPIDIENBGKH_CostumeId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(data2.KIJAPOFAGPN_ItemId);
						CKFGMNAIBNG data3 = new CKFGMNAIBNG();
						data3.KHEKNNFCAOI_Init(data.AHHJLDLAPAN_DivaId, data.JPIDIENBGKH_CostumeId, 0, false);
						data.DAJGPBLEEOB_ModelId = data3.DAJGPBLEEOB_ModelId;
						data.OJIBIPFCHJJ_CostumeName = CKFGMNAIBNG.EJOJNFDHDHN_GetName(data.AHHJLDLAPAN_DivaId, data.JPIDIENBGKH_CostumeId);
						if(a == 0)
						{
							if (bingo.AHJNPEAMCCH_rewards[i].MIKCFEHGNJB_dt == 0)
								a = i + 1;
						}
						if(data.AHHJLDLAPAN_DivaId == divaId && FOAPHMMBKDM == 0)
						{
							if (bingo.AHJNPEAMCCH_rewards[i].MIKCFEHGNJB_dt == 0)
								FOAPHMMBKDM = i + 1;
						}
						FIKLKJBHCOH_Acquired = bingo.AHJNPEAMCCH_rewards[i].MIKCFEHGNJB_dt != 0;
						LNGGFOFLJNM.Add(data);
					}
					if(FOAPHMMBKDM == 0)
					{
						if (a == 0)
							a = 1;
						FOAPHMMBKDM = a;
					}
				}
			}
			return LNGGFOFLJNM;
		}
	}

	public class OMMBBPKFLNH
	{
		private int FBGGEFFJJHB_xor = GNGMCIAIKMA.FBGGEFFJJHB_xor; // 0x8
		private long BBEGLBMOBOF_xorl = GNGMCIAIKMA.BBEGLBMOBOF_xorl; // 0x10
		public CEBFFLDKAEC_SecureInt[] LPLDJDCELAN_RewardsId = new CEBFFLDKAEC_SecureInt[8]; // 0x18
		public List<CJBKOOCMLEO> BECEJMHDBBP = new List<CJBKOOCMLEO>(); // 0x1C
		public List<JLHHGLANHGE> KONJMFICNJJ_RewardsInfo = new List<JLHHGLANHGE>(); // 0x20
		public List<JLHHGLANHGE> CIDBGGOGGPL = new List<JLHHGLANHGE>(); // 0x24
		private int AEMBNNJLEIB_BingoIdCrypted; // 0x28
		private int CGIGOFKGCII_CryptedDivaId; // 0x2C
		private int HNJNKCPDKAL_CryptedModelId; // 0x30
		private int FKKHMCINELD; // 0x34
		private int IPAKEGGICML_SerieCrypted; // 0x38
		private int PONPENCCCMO; // 0x3C
		private int OGPNNCFEJIL; // 0x40
		private int GIOJINKEEKD; // 0x44
		private int NPNDCNDCDPC; // 0x48
		private sbyte BHHMFFONDOC; // 0x4C
		private sbyte IMEHBMMLODJ; // 0x4D
		private sbyte JBHEEAONKNJ; // 0x4E
		private sbyte PPMPALLNEHL; // 0x4F
		private sbyte GDFGKNPKMFL; // 0x50

		public int APFDNBGMMMM_BingoId { get { return AEMBNNJLEIB_BingoIdCrypted ^ FBGGEFFJJHB_xor; } set { AEMBNNJLEIB_BingoIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1359D28 PBHPNJNEMHN_bgs 0x1359D38 KLPENCIJKME_bgs
		public int AHHJLDLAPAN_DivaId { get { return CGIGOFKGCII_CryptedDivaId ^ FBGGEFFJJHB_xor; } set { CGIGOFKGCII_CryptedDivaId = value ^ FBGGEFFJJHB_xor; } } //0x1359D48 IPKDLMIDMHH_bgs 0x1359D58 IENNENMKEFO_bgs
		public int DAJGPBLEEOB_ModelId { get { return HNJNKCPDKAL_CryptedModelId ^ FBGGEFFJJHB_xor; } set { HNJNKCPDKAL_CryptedModelId = value ^ FBGGEFFJJHB_xor; } } //0x1359D68 LHPKEPPBKPF_bgs 0x1359D78 OIOEEEDODJA_bgs
		public int EIHOBHDKCDB_RewardId { get { return FKKHMCINELD ^ FBGGEFFJJHB_xor; } set { FKKHMCINELD = value ^ FBGGEFFJJHB_xor; } } //0x1359D88 EALKEGPNHGK_bgs 0x1359D98 LNFEIPOKKNG_bgs
		public int CPKMLLNADLJ_Serie { get { return IPAKEGGICML_SerieCrypted ^ FBGGEFFJJHB_xor; } set { IPAKEGGICML_SerieCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1359DA8 BJPJMGHCDNO_get_Serie 0x1359DB8 BPKIOJBKNBP_set_Serie
		public int OLPBIMOPHLM_ReceiveCount { get { return PONPENCCCMO ^ FBGGEFFJJHB_xor; } set { PONPENCCCMO = value ^ FBGGEFFJJHB_xor; } } //0x1359DC8 GMCPLBFNGBM_bgs 0x1359DD8 JDMNDHONBEN_bgs
		public int ACKBJLLNLJF { get { return OGPNNCFEJIL ^ FBGGEFFJJHB_xor; } set { OGPNNCFEJIL = value ^ FBGGEFFJJHB_xor; } } //0x1359DE8 KDAFDIKHBEA_bgs 0x1359DF8 PMLDAJAELHP_bgs
		public int AIEFMNBLCKA_MaxCount { get { return GIOJINKEEKD ^ FBGGEFFJJHB_xor; } set { GIOJINKEEKD = value ^ FBGGEFFJJHB_xor; } } //0x1359E08 GOHMDFBAIHM_bgs 0x1359E18 PDKONFGBILC_bgs
		public int MALACFEDHDE_CurrentCount { get { return NPNDCNDCDPC ^ FBGGEFFJJHB_xor; } set { NPNDCNDCDPC = value ^ FBGGEFFJJHB_xor; } } //0x1359E28 KIMKKEOMPDL_bgs 0x1359E38 PGILHFKNKEN_bgs
		public bool DAKIMDGPHNE_IsReleaseEpisode { get { return BHHMFFONDOC == 0x1d; } set { BHHMFFONDOC = (sbyte)(value ? 0x1d : 0x3f); } } // 0x1359E48 NNAOEHCMHOE_bgs 0x1359E5C LCMDKNFKEPP_bgs
		public bool GKEKBBOFNLB { get { return IMEHBMMLODJ == 0x1d; } set { IMEHBMMLODJ = (sbyte)(value ? 0x1d : 0x3f); } } // 0x1359E8C LOMKNMABKLI_bgs 0x1359EA0 ODAJLKMLBDG_bgs
		public bool FHLGEKGBLLN_AllReceived { get { return JBHEEAONKNJ == 0x1d; } set { JBHEEAONKNJ = (sbyte)(value ? 0x1d : 0x3f); } } // 0x1359ED0 IMDFGCGKKDF_bgs 0x1359EE4 HINNHCPENEH_bgs
		public bool JOJINPEMEBC { get { return PPMPALLNEHL == 0x1d; } set { PPMPALLNEHL = (sbyte)(value ? 0x1d : 0x3f); } } // 0x1359F14 ELDFPJHFMNP_bgs 0x1359F28 DPOCKGPBMPC_bgs
		public bool DDLGNNMGDIL { get { return GDFGKNPKMFL == 0x1d; } set { GDFGKNPKMFL = (sbyte)(value ? 0x1d : 0x3f); } } // 0x1359F58 KEPIJJIIHJC_bgs 0x1359F6C MPAJKDGLCDA_bgs

		// RVA: 0x1358574 Offset: 0x1358574 VA: 0x1358574
		public OMMBBPKFLNH(int _PPFNGGCBJKC_id)
		{
			LHPDDGIJKNB_Reset(_PPFNGGCBJKC_id);
		}

		//// RVA: 0x1359F9C Offset: 0x1359F9C VA: 0x1359F9C
		public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id)
		{
			APFDNBGMMMM_BingoId = _PPFNGGCBJKC_id;
			AHHJLDLAPAN_DivaId = 0;
			DAJGPBLEEOB_ModelId = 0;
			OLPBIMOPHLM_ReceiveCount = 0;
			ACKBJLLNLJF = 0;
			AIEFMNBLCKA_MaxCount = 0;
			MALACFEDHDE_CurrentCount = 0;
			DAKIMDGPHNE_IsReleaseEpisode = false;
			GKEKBBOFNLB = false;
			FHLGEKGBLLN_AllReceived = false;
			JOJINPEMEBC = false;
			DDLGNNMGDIL = false;
			BECEJMHDBBP.Clear();
			for(int i = 1; i < 10; i++)
			{
				CJBKOOCMLEO data = new CJBKOOCMLEO();
				data.LHPDDGIJKNB_Reset(i);
				BECEJMHDBBP.Add(data);
			}
			KONJMFICNJJ_RewardsInfo.Clear();
			for(int i = 1; i < 9; i++)
			{
				JLHHGLANHGE data = new JLHHGLANHGE();
				data.LHPDDGIJKNB_Reset(i);
				KONJMFICNJJ_RewardsInfo.Add(data);
			}
			for(int i = 0; i < LPLDJDCELAN_RewardsId.Length; i++)
			{
				LPLDJDCELAN_RewardsId[i] = new CEBFFLDKAEC_SecureInt();
			}
			CIDBGGOGGPL.Clear();
		}

		//// RVA: 0x135A2A0 Offset: 0x135A2A0 VA: 0x135A2A0
		public void FBANBDCOEJL_Update()
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null && GNGMCIAIKMA.HHCJCDFCLOB != null)
			{
				GNGMCIAIKMA.DFABPMMMIIB bingo = GNGMCIAIKMA.HHCJCDFCLOB.GLJKKGFPEPA(APFDNBGMMMM_BingoId);
				NFMHCLHEMHB_Bingo.CCGKCGJKADC saveBingo = GNGMCIAIKMA.HHCJCDFCLOB.MENDFPNPAAO_GetSaveBingo(APFDNBGMMMM_BingoId);
				AHHJLDLAPAN_DivaId = saveBingo.AHCFGOGCJKI_St.AHHJLDLAPAN_DivaId;
				DAJGPBLEEOB_ModelId = saveBingo.AHCFGOGCJKI_St.DAJGPBLEEOB_ModelId;
				EIHOBHDKCDB_RewardId = saveBingo.AHCFGOGCJKI_St.EIHOBHDKCDB_RewardId;
				GNGMCIAIKMA.KDGHBAGLKEP bingo2 = null;
				if (EIHOBHDKCDB_RewardId > 0)
				{
					bingo2 = bingo.LNHNECFGEPO[EIHOBHDKCDB_RewardId - 1];
				}
				CPKMLLNADLJ_Serie = 0;
				if(AHHJLDLAPAN_DivaId > 0 && AHHJLDLAPAN_DivaId < 11)
				{
					CPKMLLNADLJ_Serie = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.GCINIJEMHFK_Get(AHHJLDLAPAN_DivaId).AIHCEGFANAM_SerieAttr;
				}
				OLPBIMOPHLM_ReceiveCount = GNGMCIAIKMA.HHCJCDFCLOB.BPGMPJHPKND(APFDNBGMMMM_BingoId).Count;
				ACKBJLLNLJF = GNGMCIAIKMA.HHCJCDFCLOB.MLCGJAJCFDP(APFDNBGMMMM_BingoId, OLPBIMOPHLM_ReceiveCount, 0);
				AIEFMNBLCKA_MaxCount = bingo.PJNIEFHBGIF.Count;
				MALACFEDHDE_CurrentCount = saveBingo.AHCFGOGCJKI_St.PPFNGGCBJKC_id;
				GNGMCIAIKMA.GGJOIEMJPEF r = bingo.PJNIEFHBGIF[MALACFEDHDE_CurrentCount - 1];
				if (bingo2 == null || ACKBJLLNLJF < 1)
				{
					for(int i = 0; i < LPLDJDCELAN_RewardsId.Length; i++)
					{
						LPLDJDCELAN_RewardsId[i].DNJEJEANJGL_Value = r.EIOBAIJMNGL[i].PPFNGGCBJKC_id;
					}
				}
				else
				{
					for (int i = 0; i < LPLDJDCELAN_RewardsId.Length; i++)
					{
						EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(r.EIOBAIJMNGL[i].PPFNGGCBJKC_id);
						if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.HJNNKCMLGFL_0_None)
						{
							LPLDJDCELAN_RewardsId[i].DNJEJEANJGL_Value = bingo2.GLCLFMGPMAN_ItemId[r.EIOBAIJMNGL[i].PPFNGGCBJKC_id - 1].DNJEJEANJGL_Value;
						}
						else
						{
							LPLDJDCELAN_RewardsId[i].DNJEJEANJGL_Value = r.EIOBAIJMNGL[i].PPFNGGCBJKC_id;
						}
					}
				}
				DAKIMDGPHNE_IsReleaseEpisode = false;
				GKEKBBOFNLB = GNGMCIAIKMA.HHCJCDFCLOB.DOEGBMNNFKH(APFDNBGMMMM_BingoId);
				FHLGEKGBLLN_AllReceived = OLPBIMOPHLM_ReceiveCount == 8;
				if(MALACFEDHDE_CurrentCount > 0)
				{
					DAKIMDGPHNE_IsReleaseEpisode = bingo.PJNIEFHBGIF[MALACFEDHDE_CurrentCount - 1].EOALGPLPGKB;
				}
				JOJINPEMEBC = false;
				DDLGNNMGDIL = false;
				if(MALACFEDHDE_CurrentCount > 0 && MALACFEDHDE_CurrentCount < AIEFMNBLCKA_MaxCount)
				{
					DDLGNNMGDIL = true;
					JOJINPEMEBC = bingo.PJNIEFHBGIF[MALACFEDHDE_CurrentCount - 1].EOALGPLPGKB;
				}
				List<JKICPBIIHNE_Bingo.IEGCPLCLOHF> bl = GNGMCIAIKMA.HHCJCDFCLOB.AOIADBHHJAJ_GetValidBingoCells(APFDNBGMMMM_BingoId, MALACFEDHDE_CurrentCount, CPKMLLNADLJ_Serie, AHHJLDLAPAN_DivaId);
				for(int i = 0; i < BECEJMHDBBP.Count; i++)
				{
					BECEJMHDBBP[i].LHPDDGIJKNB_Reset(i + 1);
				}
				for(int i = 0; i < bl.Count; i++)
				{
					BECEJMHDBBP[i].PPFNGGCBJKC_id = bl[i].PPFNGGCBJKC_id;
					BECEJMHDBBP[i].NDFOAINJPIN_pos = bl[i].NDFOAINJPIN_pos;
					BECEJMHDBBP[i].GLCLFMGPMAN_ItemId = bl[i].GLCLFMGPMAN_ItemId;
					BECEJMHDBBP[i].LJKMKCOAICL_ItemCount = bl[i].LJKMKCOAICL_ItemCount;
					BECEJMHDBBP[i].FEMMDNIELFC_Desc = bl[i].FEMMDNIELFC_Desc;
					BECEJMHDBBP[i].JEPGJJJBFLN_ConditionText = bl[i].JEPGJJJBFLN_ConditionText;
					EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(bl[i].GLCLFMGPMAN_ItemId);
					BECEJMHDBBP[i].LNDAOGHCKJK_ItemDetailText = string.Concat(new object[4]
					{
						EKLNMHFCAOI.INCKKODFJAP_GetItemName(bl[i].GLCLFMGPMAN_ItemId),
						"   ",
						bl[i].LJKMKCOAICL_ItemCount,
						EKLNMHFCAOI.NDBLEADIDLA(cat, 0)
					});
					BECEJMHDBBP[i].GIKJNDFJFPM_MsCnt = saveBingo.AHCFGOGCJKI_St.HDMADAHNLDN_Missions[i].HMFFHLPNMPH_count;
					BECEJMHDBBP[i].MPBADMODLOJ_MsTarget = bl[i].PMDLBHLNIDP_Target;
					BECEJMHDBBP[i].CMCKNKKCNDK_status = saveBingo.AHCFGOGCJKI_St.HDMADAHNLDN_Missions[i].CMCKNKKCNDK_status;
					BECEJMHDBBP[i].GMGGCIJHDJH_ConditionType = bl[i].MAPNDFCJFLJ_ConditionType;
					BECEJMHDBBP[i].DODGLIDGBBC_ConditionValue = bl[i].JBFLEDKDFCO_cid;
					BECEJMHDBBP[i].CCKELABMHIO_MsAc = saveBingo.AHCFGOGCJKI_St.HDMADAHNLDN_Missions[i].CCKELABMHIO_MsAc != 0;
					BECEJMHDBBP[i].BCGLDMKODLC_IsClear = false;
					if (BECEJMHDBBP[i].CCKELABMHIO_MsAc)
					{
						BECEJMHDBBP[i].BCGLDMKODLC_IsClear = BECEJMHDBBP[i].CMCKNKKCNDK_status > 1;
					}
				}
				KONJMFICNJJ_RewardsInfo.Clear();
				for(int i = 0; i < r.EIOBAIJMNGL.Count; i++)
				{
					JLHHGLANHGE data = new JLHHGLANHGE();
					data.PPFNGGCBJKC_id = i + 1;
					data.GLCLFMGPMAN_ItemId = r.EIOBAIJMNGL[i].PPFNGGCBJKC_id;
					if (r.EIOBAIJMNGL[i].PPFNGGCBJKC_id > 0 && r.EIOBAIJMNGL[i].PPFNGGCBJKC_id < 9 && bingo2 != null)
					{
						data.GLCLFMGPMAN_ItemId = bingo2.GLCLFMGPMAN_ItemId[r.EIOBAIJMNGL[i].PPFNGGCBJKC_id - 1].DNJEJEANJGL_Value;
					}
					data.MJBKGOJBPAD_item_type = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(data.GLCLFMGPMAN_ItemId);
					data.OCNINMIMHGC_item_value = EKLNMHFCAOI.DEACAHNLMNI_getItemId(data.GLCLFMGPMAN_ItemId);
					data.HAAJGNCFNJM_item_name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(data.GLCLFMGPMAN_ItemId);
					data.FLGEGLADKHC_MissionText = BECEJMHDBBP[i].FEMMDNIELFC_Desc;
					data.LJKMKCOAICL_ItemCount = r.EIOBAIJMNGL[i].BFINGCJHOHI_cnt;
					data.MPKBLMCNHOM_MissionIsSpecial = r.EIOBAIJMNGL[i].MPKBLMCNHOM_MissionIsSpecial;
					KONJMFICNJJ_RewardsInfo.Add(data);
				}
			}
		}
	}

	public class CJBKOOCMLEO
	{
		private int FBGGEFFJJHB_xor = GNGMCIAIKMA.FBGGEFFJJHB_xor; // 0x8
		private long BBEGLBMOBOF_xorl = GNGMCIAIKMA.BBEGLBMOBOF_xorl; // 0x10
		private int EHOIENNDEDH_IdCrypted; // 0x18
		private int MEJIFDMJHLM_Crypted; // 0x1C
		private NNJFKLBPBNK_SecureString FHBDAJIDLNN = new NNJFKLBPBNK_SecureString(); // 0x20
		private NNJFKLBPBNK_SecureString IDCENBCAPBP = new NNJFKLBPBNK_SecureString(); // 0x24
		private int AHGCGHAAHOO_ItemIdCrypted; // 0x28
		private int CMBLIDNDLOO_Crypted; // 0x2C
		private NNJFKLBPBNK_SecureString ELCOGKOBCNH = new NNJFKLBPBNK_SecureString(); // 0x30
		private int NLBLLLLBHOP_StatusCrypted; // 0x34
		private int KFEPIAKDDHA_Crypted; // 0x38
		private int CILEPBKEOHB_ConditionValueCrypted; // 0x3C
		private int FANHHAHBDPA_Crypted; // 0x40
		private int JCCJFCHMDBF_Crypted; // 0x44
		private sbyte ALPDMEILILP_IsClearCrypted; // 0x48
		private sbyte MCFFGKAOIHP_MsAcCrypted; // 0x49

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x13586A8 DEMEPMAEJOO_get_id 0x13586B8 HIGKAIDMOKN_set_id
		public int NDFOAINJPIN_pos { get { return MEJIFDMJHLM_Crypted ^ FBGGEFFJJHB_xor; } set { MEJIFDMJHLM_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x13586C8 CLKKCPLEKBC_get_pos 0x13586D8 CLJOOFCICMO_set_pos
		public string FEMMDNIELFC_Desc { get { return FHBDAJIDLNN.DNJEJEANJGL_Value; } set { FHBDAJIDLNN.DNJEJEANJGL_Value = value; } } //0x13586E8 JDHDMBHNKJD_get_Desc 0x1358714 FNAJEJLLJOE_set_Desc
		public string JEPGJJJBFLN_ConditionText { get { return IDCENBCAPBP.DNJEJEANJGL_Value; } set { IDCENBCAPBP.DNJEJEANJGL_Value = value; } } //0x1358748 AKHEBLBJGBP_get_ConditionText 0x1358774 EEJDMJMLKMG_set_ConditionText
		public int GLCLFMGPMAN_ItemId { get { return AHGCGHAAHOO_ItemIdCrypted ^ FBGGEFFJJHB_xor; } set { AHGCGHAAHOO_ItemIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x13587A8 LNJAENEGDEL_get_ItemId 0x13587B8 JHIDBGCHOKL_set_ItemId
		public int LJKMKCOAICL_ItemCount { get { return CMBLIDNDLOO_Crypted ^ FBGGEFFJJHB_xor; } set { CMBLIDNDLOO_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x13587C8 KJPMAPBJBKE_get_ItemCount 0x13587D8 PPBMLEFDPOF_set_ItemCount
		public string LNDAOGHCKJK_ItemDetailText { get { return ELCOGKOBCNH.DNJEJEANJGL_Value; } set { ELCOGKOBCNH.DNJEJEANJGL_Value = value; } } //0x13587E8 JOPLPEHNFCO_bgs 0x1358814 BKHEPENKIBE_bgs
		public int CMCKNKKCNDK_status { get { return NLBLLLLBHOP_StatusCrypted ^ FBGGEFFJJHB_xor; } set { NLBLLLLBHOP_StatusCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1358848 CNKGOPKANGF_bgs 0x1358858 CHJGGLFGALP_set_status
		public int GMGGCIJHDJH_ConditionType { get { return KFEPIAKDDHA_Crypted ^ FBGGEFFJJHB_xor; } set { KFEPIAKDDHA_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1358868 BIPCONAFCPO_bgs 0x1358878 PKGLOAAEKHI_bgs
		public int DODGLIDGBBC_ConditionValue { get { return CILEPBKEOHB_ConditionValueCrypted ^ FBGGEFFJJHB_xor; } set { CILEPBKEOHB_ConditionValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1358888 PAACNLDBGKP_get_ConditionValue 0x1358898 AHIHPMDINHA_set_ConditionValue
		public int GIKJNDFJFPM_MsCnt { get { return FANHHAHBDPA_Crypted ^ FBGGEFFJJHB_xor; } set { FANHHAHBDPA_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x13588A8 IBMKJNJCEDO_bgs 0x13588B8 LJPNAJOLKNG_bgs
		public int MPBADMODLOJ_MsTarget { get { return JCCJFCHMDBF_Crypted ^ FBGGEFFJJHB_xor; } set { JCCJFCHMDBF_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x13588C8 AMOLLDKGIPD_bgs 0x13588D8 GGPADGDEHMO_bgs
		public bool BCGLDMKODLC_IsClear { get { return ALPDMEILILP_IsClearCrypted == 0x1d; } set { ALPDMEILILP_IsClearCrypted = (sbyte)(value ? 0x1d : 0x3f); } } //0x13588E8 NNGALFPBDNA_bgs 0x13588FC JJBMOHCMALD_bgs
		public bool CCKELABMHIO_MsAc { get { return MCFFGKAOIHP_MsAcCrypted == 0x1d; } set { MCFFGKAOIHP_MsAcCrypted = (sbyte)(value ? 0x1d : 0x3f); } } //0x135892C GGHKPKEGFLM_bgs 0x1358940 GCDJHHFGLLE_bgs

		// RVA: 0x1358970 Offset: 0x1358970 VA: 0x1358970
		public CJBKOOCMLEO()
		{
			LHPDDGIJKNB_Reset(0);
		}

		// RVA: 0x1358A50 Offset: 0x1358A50 VA: 0x1358A50
		public void LHPDDGIJKNB_Reset(int _CMEJFJFOIIJ_QuestId)
		{
			GLCLFMGPMAN_ItemId = 0;
			LJKMKCOAICL_ItemCount = 0;
			PPFNGGCBJKC_id = _CMEJFJFOIIJ_QuestId;
			NDFOAINJPIN_pos = 0;
			LNDAOGHCKJK_ItemDetailText = "";
			MPBADMODLOJ_MsTarget = 0;
			CMCKNKKCNDK_status = 0;
			GMGGCIJHDJH_ConditionType = 0;
			DODGLIDGBBC_ConditionValue = 0;
			GIKJNDFJFPM_MsCnt = 0;
			FEMMDNIELFC_Desc = "";
			JEPGJJJBFLN_ConditionText = "";
			BCGLDMKODLC_IsClear = false;
			CCKELABMHIO_MsAc = false;
		}
	}

	public class JLHHGLANHGE
	{
		private int FBGGEFFJJHB_xor = GNGMCIAIKMA.FBGGEFFJJHB_xor; // 0x8
		private long BBEGLBMOBOF_xorl = GNGMCIAIKMA.BBEGLBMOBOF_xorl; // 0x10
		private int EHOIENNDEDH_IdCrypted; // 0x18
		private int AHGCGHAAHOO_ItemIdCrypted; // 0x1C
		private int CMBLIDNDLOO_Crypted; // 0x20
		private NNJFKLBPBNK_SecureString AKPFPJPIION = new NNJFKLBPBNK_SecureString(); // 0x24
		private NNJFKLBPBNK_SecureString KFIDIDGPJGB = new NNJFKLBPBNK_SecureString(); // 0x28
		private int BFNCPNIMLGJ_Crypted; // 0x2C
		private int OBNCDLMGDFG_Crypted; // 0x30
		private sbyte AJGFHCKFCHN_Crypted; // 0x34

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1358B30 DEMEPMAEJOO_get_id 0x1358B40 HIGKAIDMOKN_set_id
		public int GLCLFMGPMAN_ItemId { get { return AHGCGHAAHOO_ItemIdCrypted ^ FBGGEFFJJHB_xor; } set { AHGCGHAAHOO_ItemIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1358B50 LNJAENEGDEL_get_ItemId 0x1358B60 JHIDBGCHOKL_set_ItemId
		public int LJKMKCOAICL_ItemCount { get { return CMBLIDNDLOO_Crypted ^ FBGGEFFJJHB_xor; } set { CMBLIDNDLOO_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1358B70 KJPMAPBJBKE_get_ItemCount 0x1358B80 PPBMLEFDPOF_set_ItemCount
		public string HAAJGNCFNJM_item_name { get { return AKPFPJPIION.DNJEJEANJGL_Value; } set { AKPFPJPIION.DNJEJEANJGL_Value = value; } } //0x1358B90 HKEGMCDHPBN_bgs 0x1358BBC EAANOGMNKNK_bgs
		public string FLGEGLADKHC_MissionText { get { return KFIDIDGPJGB.DNJEJEANJGL_Value; } set { KFIDIDGPJGB.DNJEJEANJGL_Value = value; } } //0x1358BF0 GLOGENJHAJG_bgs 0x1358C1C FHIAOOMBHNC_bgs
		public EKLNMHFCAOI.FKGCBLHOOCL_Category MJBKGOJBPAD_item_type { get { return (EKLNMHFCAOI.FKGCBLHOOCL_Category)(BFNCPNIMLGJ_Crypted ^ FBGGEFFJJHB_xor); } set { BFNCPNIMLGJ_Crypted = (int)value ^ FBGGEFFJJHB_xor; } } //0x1358C50 COFMKKJBELJ_get_item_type 0x1358C64 KHOHIGFNIIF_set_item_type
		public int OCNINMIMHGC_item_value { get { return OBNCDLMGDFG_Crypted ^ FBGGEFFJJHB_xor; } set { OBNCDLMGDFG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1358C74 BGCLLLFODPB_bgs 0x1358C84 FILEGBHDMFC_bgs
		public bool MPKBLMCNHOM_MissionIsSpecial { get { return AJGFHCKFCHN_Crypted == 0x1d; } set { AJGFHCKFCHN_Crypted = (sbyte)(value ? 0x1d : 0x3f); } } //0x1358C94 BOFCPLOLHCJ_bgs 0x1358CA8 FDPPEPOHFNA_bgs

		// RVA: 0x1358CD8 Offset: 0x1358CD8 VA: 0x1358CD8
		public JLHHGLANHGE()
		{
			LHPDDGIJKNB_Reset(0);
		}

		// RVA: 0x1358DA0 Offset: 0x1358DA0 VA: 0x1358DA0
		public void LHPDDGIJKNB_Reset(int _EIHOBHDKCDB_RewardId)
		{
			PPFNGGCBJKC_id = _EIHOBHDKCDB_RewardId;
			GLCLFMGPMAN_ItemId = 0;
			LJKMKCOAICL_ItemCount = 0;
			HAAJGNCFNJM_item_name = "";
			FLGEGLADKHC_MissionText = "";
			MJBKGOJBPAD_item_type = EKLNMHFCAOI.FKGCBLHOOCL_Category.HJNNKCMLGFL_0_None;
			OCNINMIMHGC_item_value = 0;
			MPKBLMCNHOM_MissionIsSpecial = false;
		}
	}

	private int FBGGEFFJJHB_xor = GNGMCIAIKMA.FBGGEFFJJHB_xor; // 0x8
	private long BBEGLBMOBOF_xorl = GNGMCIAIKMA.BBEGLBMOBOF_xorl; // 0x10
	public int PMPKHBAJAFA_BingoId; // 0x18
	public LKDLJCCJJNK NHPHOKNJNAH; // 0x1C
	public OMMBBPKFLNH MEAPAEMIOBB; // 0x20
	
	// RVA: 0x13582D8 Offset: 0x13582D8 VA: 0x13582D8
	public JJPEIELNEJB(int _APFDNBGMMMM_BingoId)
	{
		LHPDDGIJKNB_Reset(_APFDNBGMMMM_BingoId);
	}

	// RVA: 0x1358368 Offset: 0x1358368 VA: 0x1358368
	public bool LHPDDGIJKNB_Reset(int _APFDNBGMMMM_BingoId)
	{
		if (GNGMCIAIKMA.HHCJCDFCLOB != null)
		{
			GNGMCIAIKMA.DFABPMMMIIB d = GNGMCIAIKMA.HHCJCDFCLOB.GLJKKGFPEPA(_APFDNBGMMMM_BingoId);
			if (d != null)
			{
				PMPKHBAJAFA_BingoId = _APFDNBGMMMM_BingoId;
				d.KHEKNNFCAOI_Init(_APFDNBGMMMM_BingoId);
				NHPHOKNJNAH = new LKDLJCCJJNK(_APFDNBGMMMM_BingoId);
				MEAPAEMIOBB = new OMMBBPKFLNH(_APFDNBGMMMM_BingoId);
				return true;
			}
		}
		return false;
	}
}
