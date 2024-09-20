
using System.Collections.Generic;
using XeApp.Game;
using XeSys;

public class JJPEIELNEJB
{
	public class LKDLJCCJJNK
	{
		private int FBGGEFFJJHB = GNGMCIAIKMA.FBGGEFFJJHB; // 0x8
		private long BBEGLBMOBOF = GNGMCIAIKMA.BBEGLBMOBOF; // 0x10
		private int AEMBNNJLEIB; // 0x18
		private int EHOIENNDEDH; // 0x1C
		private int CGIGOFKGCII; // 0x20
		private int HFJLOKDMJHI; // 0x24
		private int HNJNKCPDKAL; // 0x28
		private NNJFKLBPBNK_SecureString NONEFNOHBGJ = new NNJFKLBPBNK_SecureString(); // 0x2C
		private int POAOLKIEOHC; // 0x30
		private int HHNNGNKEBDA; // 0x34
		private NNJFKLBPBNK_SecureString KHICNFJAMNO = new NNJFKLBPBNK_SecureString(); // 0x38
		private NNJFKLBPBNK_SecureString CHMNKLMNJGI = new NNJFKLBPBNK_SecureString(); // 0x3C
		private sbyte BEHMPLPICHP; // 0x40
		private int NCPKEALEIIG; // 0x44
		private NNJFKLBPBNK_SecureString JAOLFCOEBKJ = new NNJFKLBPBNK_SecureString(); // 0x48
		private List<LKDLJCCJJNK> LNGGFOFLJNM = new List<LKDLJCCJJNK>(); // 0x4C

		public int APFDNBGMMMM_BingoId { get { return AEMBNNJLEIB ^ FBGGEFFJJHB; } set { AEMBNNJLEIB = value ^ FBGGEFFJJHB; } } //0x1358E4C PBHPNJNEMHN 0x1358E5C KLPENCIJKME
		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x1358E6C DEMEPMAEJOO 0x1358E7C HIGKAIDMOKN
		public int AHHJLDLAPAN_DivaId { get { return CGIGOFKGCII ^ FBGGEFFJJHB; } set { CGIGOFKGCII = value ^ FBGGEFFJJHB; } } //0x1358E8C IPKDLMIDMHH 0x1358E9C IENNENMKEFO
		public int JPIDIENBGKH { get { return HFJLOKDMJHI ^ FBGGEFFJJHB; } set { HFJLOKDMJHI = value ^ FBGGEFFJJHB; } } //0x1358EAC PHLLMIGCPCB 0x1358EBC BLBNMENMCIF
		public int DAJGPBLEEOB_CostumeId { get { return HNJNKCPDKAL ^ FBGGEFFJJHB; } set { HNJNKCPDKAL = value ^ FBGGEFFJJHB; } } //0x1358ECC LHPKEPPBKPF 0x1358EDC OIOEEEDODJA
		public string OJIBIPFCHJJ_CostumeName { get { return NONEFNOHBGJ.DNJEJEANJGL_Value; } set { NONEFNOHBGJ.DNJEJEANJGL_Value = value; } } //0x1358EEC AMBCADKGPCK 0x1358F18 HEKMHCMLAJJ
		public int BCCHOBPJJKE_SceneId { get { return POAOLKIEOHC ^ FBGGEFFJJHB; } set { POAOLKIEOHC = value ^ FBGGEFFJJHB; } } //0x1358F4C COHCNONLPAC 0x1358F5C HJEBBEHGHGG
		public int BOCDGDKMMIP_Rarity { get { return HHNNGNKEBDA ^ FBGGEFFJJHB; } set { HHNNGNKEBDA = value ^ FBGGEFFJJHB; } } //0x1358F6C JGEHNNFJBFC 0x1358F7C MMFLIFJMIJK
		public string LLBBBDBMMFN_SceneDetail { get { return KHICNFJAMNO.DNJEJEANJGL_Value; } set { KHICNFJAMNO.DNJEJEANJGL_Value = value; } } //0x1358F8C BMDCOLPEHOP 0x1358FB8 HJACPCKCNMA
		public string BGIMCADKCKJ_EpisodeName { get { return CHMNKLMNJGI.DNJEJEANJGL_Value; } set { CHMNKLMNJGI.DNJEJEANJGL_Value = value; } } //0x1358FEC MNIGPJKBINM 0x1359018 GNLLGODCCIL
		public bool FIKLKJBHCOH_Acquired { get { return BEHMPLPICHP == 0x1d; } set { BEHMPLPICHP = (sbyte)(value ? 0x1d : 0x3f); } } //0x135904C ABIADACMFEB 0x1359060 EGHECENGGHC
		public int FOAPHMMBKDM { get { return NCPKEALEIIG ^ FBGGEFFJJHB; } set { NCPKEALEIIG = value ^ FBGGEFFJJHB; } } //0x1359090 LKOFKKOGJHL 0x13590A0 JDEIGMAHFKP
		public string GNKKNILFNDP_ExplanationText { get { return JAOLFCOEBKJ.DNJEJEANJGL_Value; } set { JAOLFCOEBKJ.DNJEJEANJGL_Value = value;  } } //0x13590B0 DEPDJBKFLLC 0x13590DC JJPGCPJMOKJ

		// RVA: 0x1358444 Offset: 0x1358444 VA: 0x1358444
		public LKDLJCCJJNK(int PPFNGGCBJKC)
		{
			LHPDDGIJKNB(PPFNGGCBJKC);
		}

		// RVA: 0x1359110 Offset: 0x1359110 VA: 0x1359110
		public void LHPDDGIJKNB(int PPFNGGCBJKC)
		{
			BCCHOBPJJKE_SceneId = 0;
			BOCDGDKMMIP_Rarity = 0;
			AHHJLDLAPAN_DivaId = 0;
			JPIDIENBGKH = 0;
			DAJGPBLEEOB_CostumeId = 0;
			APFDNBGMMMM_BingoId = PPFNGGCBJKC;
			OJIBIPFCHJJ_CostumeName = JpStringLiterals.StringLiteral_12010;
			LLBBBDBMMFN_SceneDetail = "";
			BGIMCADKCKJ_EpisodeName = "";
			FIKLKJBHCOH_Acquired = false;
			FOAPHMMBKDM = 1;
			GNKKNILFNDP_ExplanationText = "";
		}

		//// RVA: 0x13591F8 Offset: 0x13591F8 VA: 0x13591F8
		public List<LKDLJCCJJNK> FKDIMODKKJD()
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
							for(int i = 0; i < GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas.Count; i++)
							{
								if (GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[i].FJODMPGPDDD_DivaHave)
								{
									divaId = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[i].AHHJLDLAPAN_DivaId;
								}
							}
						}
					}
					int a = 0;
					for(int i = 0; i < d.LNHNECFGEPO.Count; i++)
					{
						LKDLJCCJJNK data = new LKDLJCCJJNK(APFDNBGMMMM_BingoId);
						data.PPFNGGCBJKC = d.LNHNECFGEPO[i].PPFNGGCBJKC;
						data.AHHJLDLAPAN_DivaId = d.LNHNECFGEPO[i].FDBOPFEOENF;
						data.BCCHOBPJJKE_SceneId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(d.LNHNECFGEPO[i].GLCLFMGPMAN[0].DNJEJEANJGL_Value);
						GCIJNCFDNON_SceneInfo scene = new GCIJNCFDNON_SceneInfo();
						scene.KHEKNNFCAOI(data.BCCHOBPJJKE_SceneId, null, null, 0, 0, 0, false, 0, 0);
						data.LLBBBDBMMFN_SceneDetail = scene.BGJNIABLBDB_GetSceneDetail();
						data.BOCDGDKMMIP_Rarity = scene.JOKJBMJBLBB_Single ? 2 : 1;
						PIGBBNDPPJC data2 = new PIGBBNDPPJC();
						data2.KHEKNNFCAOI(scene.KELFCMEOPPM_EpisodeId);
						data.BGIMCADKCKJ_EpisodeName = data2.OPFGFINHFCE_Name;
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
						data.JPIDIENBGKH = EKLNMHFCAOI.DEACAHNLMNI_getItemId(data2.KIJAPOFAGPN_UnlockItemId);
						CKFGMNAIBNG data3 = new CKFGMNAIBNG();
						data3.KHEKNNFCAOI(data.AHHJLDLAPAN_DivaId, data.JPIDIENBGKH, 0, false);
						data.DAJGPBLEEOB_CostumeId = data3.DAJGPBLEEOB_PrismCostumeId;
						data.OJIBIPFCHJJ_CostumeName = CKFGMNAIBNG.EJOJNFDHDHN_GetCostumeName(data.AHHJLDLAPAN_DivaId, data.JPIDIENBGKH);
						if(a == 0)
						{
							if (bingo.AHJNPEAMCCH_Rw[i].MIKCFEHGNJB_Dt == 0)
								a = i + 1;
						}
						if(data.AHHJLDLAPAN_DivaId == divaId && FOAPHMMBKDM == 0)
						{
							if (bingo.AHJNPEAMCCH_Rw[i].MIKCFEHGNJB_Dt == 0)
								FOAPHMMBKDM = i + 1;
						}
						FIKLKJBHCOH_Acquired = bingo.AHJNPEAMCCH_Rw[i].MIKCFEHGNJB_Dt != 0;
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
		private int FBGGEFFJJHB = GNGMCIAIKMA.FBGGEFFJJHB; // 0x8
		private long BBEGLBMOBOF = GNGMCIAIKMA.BBEGLBMOBOF; // 0x10
		public CEBFFLDKAEC_SecureInt[] LPLDJDCELAN_RewardsId = new CEBFFLDKAEC_SecureInt[8]; // 0x18
		public List<CJBKOOCMLEO> BECEJMHDBBP = new List<CJBKOOCMLEO>(); // 0x1C
		public List<JLHHGLANHGE> KONJMFICNJJ_RewardsInfo = new List<JLHHGLANHGE>(); // 0x20
		public List<JLHHGLANHGE> CIDBGGOGGPL = new List<JLHHGLANHGE>(); // 0x24
		private int AEMBNNJLEIB; // 0x28
		private int CGIGOFKGCII; // 0x2C
		private int HNJNKCPDKAL; // 0x30
		private int FKKHMCINELD; // 0x34
		private int IPAKEGGICML; // 0x38
		private int PONPENCCCMO; // 0x3C
		private int OGPNNCFEJIL; // 0x40
		private int GIOJINKEEKD; // 0x44
		private int NPNDCNDCDPC; // 0x48
		private sbyte BHHMFFONDOC; // 0x4C
		private sbyte IMEHBMMLODJ; // 0x4D
		private sbyte JBHEEAONKNJ; // 0x4E
		private sbyte PPMPALLNEHL; // 0x4F
		private sbyte GDFGKNPKMFL; // 0x50

		public int APFDNBGMMMM_BingoId { get { return AEMBNNJLEIB ^ FBGGEFFJJHB; } set { AEMBNNJLEIB = value ^ FBGGEFFJJHB; } } //0x1359D28 PBHPNJNEMHN 0x1359D38 KLPENCIJKME
		public int AHHJLDLAPAN_DivaId { get { return CGIGOFKGCII ^ FBGGEFFJJHB; } set { CGIGOFKGCII = value ^ FBGGEFFJJHB; } } //0x1359D48 IPKDLMIDMHH 0x1359D58 IENNENMKEFO
		public int DAJGPBLEEOB_CostumeModelId { get { return HNJNKCPDKAL ^ FBGGEFFJJHB; } set { HNJNKCPDKAL = value ^ FBGGEFFJJHB; } } //0x1359D68 LHPKEPPBKPF 0x1359D78 OIOEEEDODJA
		public int EIHOBHDKCDB_RewardId { get { return FKKHMCINELD ^ FBGGEFFJJHB; } set { FKKHMCINELD = value ^ FBGGEFFJJHB; } } //0x1359D88 EALKEGPNHGK 0x1359D98 LNFEIPOKKNG
		public int CPKMLLNADLJ_Attr { get { return IPAKEGGICML ^ FBGGEFFJJHB; } set { IPAKEGGICML = value ^ FBGGEFFJJHB; } } //0x1359DA8 BJPJMGHCDNO 0x1359DB8 BPKIOJBKNBP
		public int OLPBIMOPHLM_ReceiveCount { get { return PONPENCCCMO ^ FBGGEFFJJHB; } set { PONPENCCCMO = value ^ FBGGEFFJJHB; } } //0x1359DC8 GMCPLBFNGBM 0x1359DD8 JDMNDHONBEN
		public int ACKBJLLNLJF { get { return OGPNNCFEJIL ^ FBGGEFFJJHB; } set { OGPNNCFEJIL = value ^ FBGGEFFJJHB; } } //0x1359DE8 KDAFDIKHBEA 0x1359DF8 PMLDAJAELHP
		public int AIEFMNBLCKA_MaxCount { get { return GIOJINKEEKD ^ FBGGEFFJJHB; } set { GIOJINKEEKD = value ^ FBGGEFFJJHB; } } //0x1359E08 GOHMDFBAIHM 0x1359E18 PDKONFGBILC
		public int MALACFEDHDE_CurrentCount { get { return NPNDCNDCDPC ^ FBGGEFFJJHB; } set { NPNDCNDCDPC = value ^ FBGGEFFJJHB; } } //0x1359E28 KIMKKEOMPDL 0x1359E38 PGILHFKNKEN
		public bool DAKIMDGPHNE_IsReleaseEpisode { get { return BHHMFFONDOC == 0x1d; } set { BHHMFFONDOC = (sbyte)(value ? 0x1d : 0x3f); } } // 0x1359E48 NNAOEHCMHOE 0x1359E5C LCMDKNFKEPP
		public bool GKEKBBOFNLB { get { return IMEHBMMLODJ == 0x1d; } set { IMEHBMMLODJ = (sbyte)(value ? 0x1d : 0x3f); } } // 0x1359E8C LOMKNMABKLI 0x1359EA0 ODAJLKMLBDG
		public bool FHLGEKGBLLN_AllReceived { get { return JBHEEAONKNJ == 0x1d; } set { JBHEEAONKNJ = (sbyte)(value ? 0x1d : 0x3f); } } // 0x1359ED0 IMDFGCGKKDF 0x1359EE4 HINNHCPENEH
		public bool JOJINPEMEBC { get { return PPMPALLNEHL == 0x1d; } set { PPMPALLNEHL = (sbyte)(value ? 0x1d : 0x3f); } } // 0x1359F14 ELDFPJHFMNP 0x1359F28 DPOCKGPBMPC
		public bool DDLGNNMGDIL { get { return GDFGKNPKMFL == 0x1d; } set { GDFGKNPKMFL = (sbyte)(value ? 0x1d : 0x3f); } } // 0x1359F58 KEPIJJIIHJC 0x1359F6C MPAJKDGLCDA

		// RVA: 0x1358574 Offset: 0x1358574 VA: 0x1358574
		public OMMBBPKFLNH(int PPFNGGCBJKC)
		{
			LHPDDGIJKNB(PPFNGGCBJKC);
		}

		//// RVA: 0x1359F9C Offset: 0x1359F9C VA: 0x1359F9C
		public void LHPDDGIJKNB(int PPFNGGCBJKC)
		{
			APFDNBGMMMM_BingoId = PPFNGGCBJKC;
			AHHJLDLAPAN_DivaId = 0;
			DAJGPBLEEOB_CostumeModelId = 0;
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
				data.LHPDDGIJKNB(i);
				BECEJMHDBBP.Add(data);
			}
			KONJMFICNJJ_RewardsInfo.Clear();
			for(int i = 1; i < 9; i++)
			{
				JLHHGLANHGE data = new JLHHGLANHGE();
				data.LHPDDGIJKNB(i);
				KONJMFICNJJ_RewardsInfo.Add(data);
			}
			for(int i = 0; i < LPLDJDCELAN_RewardsId.Length; i++)
			{
				LPLDJDCELAN_RewardsId[i] = new CEBFFLDKAEC_SecureInt();
			}
			CIDBGGOGGPL.Clear();
		}

		//// RVA: 0x135A2A0 Offset: 0x135A2A0 VA: 0x135A2A0
		public void FBANBDCOEJL()
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null && GNGMCIAIKMA.HHCJCDFCLOB != null)
			{
				GNGMCIAIKMA.DFABPMMMIIB bingo = GNGMCIAIKMA.HHCJCDFCLOB.GLJKKGFPEPA(APFDNBGMMMM_BingoId);
				NFMHCLHEMHB_Bingo.CCGKCGJKADC saveBingo = GNGMCIAIKMA.HHCJCDFCLOB.MENDFPNPAAO_GetSaveBingo(APFDNBGMMMM_BingoId);
				AHHJLDLAPAN_DivaId = saveBingo.AHCFGOGCJKI_St.AHHJLDLAPAN_Dv;
				DAJGPBLEEOB_CostumeModelId = saveBingo.AHCFGOGCJKI_St.DAJGPBLEEOB_Mdl;
				EIHOBHDKCDB_RewardId = saveBingo.AHCFGOGCJKI_St.EIHOBHDKCDB_RId;
				GNGMCIAIKMA.KDGHBAGLKEP bingo2 = null;
				if (EIHOBHDKCDB_RewardId > 0)
				{
					bingo2 = bingo.LNHNECFGEPO[EIHOBHDKCDB_RewardId - 1];
				}
				CPKMLLNADLJ_Attr = 0;
				if(AHHJLDLAPAN_DivaId > 0 && AHHJLDLAPAN_DivaId < 11)
				{
					CPKMLLNADLJ_Attr = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.GCINIJEMHFK_GetInfo(AHHJLDLAPAN_DivaId).AIHCEGFANAM_Attr;
				}
				OLPBIMOPHLM_ReceiveCount = GNGMCIAIKMA.HHCJCDFCLOB.BPGMPJHPKND(APFDNBGMMMM_BingoId).Count;
				ACKBJLLNLJF = GNGMCIAIKMA.HHCJCDFCLOB.MLCGJAJCFDP(APFDNBGMMMM_BingoId, OLPBIMOPHLM_ReceiveCount, 0);
				AIEFMNBLCKA_MaxCount = bingo.PJNIEFHBGIF.Count;
				MALACFEDHDE_CurrentCount = saveBingo.AHCFGOGCJKI_St.PPFNGGCBJKC_Id;
				GNGMCIAIKMA.GGJOIEMJPEF r = bingo.PJNIEFHBGIF[MALACFEDHDE_CurrentCount - 1];
				if (bingo2 == null || ACKBJLLNLJF < 1)
				{
					for(int i = 0; i < LPLDJDCELAN_RewardsId.Length; i++)
					{
						LPLDJDCELAN_RewardsId[i].DNJEJEANJGL_Value = r.EIOBAIJMNGL[i].PPFNGGCBJKC_Id;
					}
				}
				else
				{
					for (int i = 0; i < LPLDJDCELAN_RewardsId.Length; i++)
					{
						EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(r.EIOBAIJMNGL[i].PPFNGGCBJKC_Id);
						if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.HJNNKCMLGFL_None)
						{
							LPLDJDCELAN_RewardsId[i].DNJEJEANJGL_Value = bingo2.GLCLFMGPMAN[r.EIOBAIJMNGL[i].PPFNGGCBJKC_Id - 1].DNJEJEANJGL_Value;
						}
						else
						{
							LPLDJDCELAN_RewardsId[i].DNJEJEANJGL_Value = r.EIOBAIJMNGL[i].PPFNGGCBJKC_Id;
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
				List<JKICPBIIHNE_Bingo.IEGCPLCLOHF> bl = GNGMCIAIKMA.HHCJCDFCLOB.AOIADBHHJAJ_GetValidBingoCells(APFDNBGMMMM_BingoId, MALACFEDHDE_CurrentCount, CPKMLLNADLJ_Attr, AHHJLDLAPAN_DivaId);
				for(int i = 0; i < BECEJMHDBBP.Count; i++)
				{
					BECEJMHDBBP[i].LHPDDGIJKNB(i + 1);
				}
				for(int i = 0; i < bl.Count; i++)
				{
					BECEJMHDBBP[i].PPFNGGCBJKC = bl[i].PPFNGGCBJKC;
					BECEJMHDBBP[i].NDFOAINJPIN = bl[i].NDFOAINJPIN;
					BECEJMHDBBP[i].GLCLFMGPMAN_ItemId = bl[i].GLCLFMGPMAN;
					BECEJMHDBBP[i].LJKMKCOAICL_ItemCount = bl[i].LJKMKCOAICL;
					BECEJMHDBBP[i].FEMMDNIELFC_MissionText = bl[i].FEMMDNIELFC;
					BECEJMHDBBP[i].JEPGJJJBFLN_ConditionText = bl[i].JEPGJJJBFLN;
					EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(bl[i].GLCLFMGPMAN);
					BECEJMHDBBP[i].LNDAOGHCKJK_ItemDetailText = string.Concat(new object[4]
					{
						EKLNMHFCAOI.INCKKODFJAP_GetItemName(bl[i].GLCLFMGPMAN),
						"   ",
						bl[i].LJKMKCOAICL,
						EKLNMHFCAOI.NDBLEADIDLA(cat, 0)
					});
					BECEJMHDBBP[i].GIKJNDFJFPM_MsCnt = saveBingo.AHCFGOGCJKI_St.HDMADAHNLDN_Ms[i].HMFFHLPNMPH_Cnt;
					BECEJMHDBBP[i].MPBADMODLOJ_MsTarget = bl[i].PMDLBHLNIDP_Target;
					BECEJMHDBBP[i].CMCKNKKCNDK_MsStat = saveBingo.AHCFGOGCJKI_St.HDMADAHNLDN_Ms[i].CMCKNKKCNDK_Stat;
					BECEJMHDBBP[i].GMGGCIJHDJH_ConditionType = bl[i].MAPNDFCJFLJ_ConditionType;
					BECEJMHDBBP[i].DODGLIDGBBC_ConditionValue = bl[i].JBFLEDKDFCO_ConditionValue;
					BECEJMHDBBP[i].CCKELABMHIO_MsAc = saveBingo.AHCFGOGCJKI_St.HDMADAHNLDN_Ms[i].CCKELABMHIO_Ac != 0;
					BECEJMHDBBP[i].BCGLDMKODLC_IsSingle = false;
					if (BECEJMHDBBP[i].CCKELABMHIO_MsAc)
					{
						BECEJMHDBBP[i].BCGLDMKODLC_IsSingle = BECEJMHDBBP[i].CMCKNKKCNDK_MsStat > 1;
					}
				}
				KONJMFICNJJ_RewardsInfo.Clear();
				for(int i = 0; i < r.EIOBAIJMNGL.Count; i++)
				{
					JLHHGLANHGE data = new JLHHGLANHGE();
					data.PPFNGGCBJKC = i + 1;
					data.GLCLFMGPMAN_ItemFullId = r.EIOBAIJMNGL[i].PPFNGGCBJKC_Id;
					if (r.EIOBAIJMNGL[i].PPFNGGCBJKC_Id > 0 && r.EIOBAIJMNGL[i].PPFNGGCBJKC_Id < 9 && bingo2 != null)
					{
						data.GLCLFMGPMAN_ItemFullId = bingo2.GLCLFMGPMAN[r.EIOBAIJMNGL[i].PPFNGGCBJKC_Id - 1].DNJEJEANJGL_Value;
					}
					data.MJBKGOJBPAD_ItemCat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(data.GLCLFMGPMAN_ItemFullId);
					data.OCNINMIMHGC_ItemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(data.GLCLFMGPMAN_ItemFullId);
					data.HAAJGNCFNJM_ItemName = EKLNMHFCAOI.INCKKODFJAP_GetItemName(data.GLCLFMGPMAN_ItemFullId);
					data.FLGEGLADKHC_MissionText = BECEJMHDBBP[i].FEMMDNIELFC_MissionText;
					data.LJKMKCOAICL_ItemCount = r.EIOBAIJMNGL[i].BFINGCJHOHI_Cnt;
					data.MPKBLMCNHOM = r.EIOBAIJMNGL[i].MPKBLMCNHOM;
					KONJMFICNJJ_RewardsInfo.Add(data);
				}
			}
		}
	}

	public class CJBKOOCMLEO
	{
		private int FBGGEFFJJHB = GNGMCIAIKMA.FBGGEFFJJHB; // 0x8
		private long BBEGLBMOBOF = GNGMCIAIKMA.BBEGLBMOBOF; // 0x10
		private int EHOIENNDEDH; // 0x18
		private int MEJIFDMJHLM; // 0x1C
		private NNJFKLBPBNK_SecureString FHBDAJIDLNN = new NNJFKLBPBNK_SecureString(); // 0x20
		private NNJFKLBPBNK_SecureString IDCENBCAPBP = new NNJFKLBPBNK_SecureString(); // 0x24
		private int AHGCGHAAHOO; // 0x28
		private int CMBLIDNDLOO; // 0x2C
		private NNJFKLBPBNK_SecureString ELCOGKOBCNH = new NNJFKLBPBNK_SecureString(); // 0x30
		private int NLBLLLLBHOP; // 0x34
		private int KFEPIAKDDHA; // 0x38
		private int CILEPBKEOHB; // 0x3C
		private int FANHHAHBDPA; // 0x40
		private int JCCJFCHMDBF; // 0x44
		private sbyte ALPDMEILILP; // 0x48
		private sbyte MCFFGKAOIHP; // 0x49

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x13586A8 DEMEPMAEJOO 0x13586B8 HIGKAIDMOKN
		public int NDFOAINJPIN { get { return MEJIFDMJHLM ^ FBGGEFFJJHB; } set { MEJIFDMJHLM = value ^ FBGGEFFJJHB; } } //0x13586C8 CLKKCPLEKBC 0x13586D8 CLJOOFCICMO
		public string FEMMDNIELFC_MissionText { get { return FHBDAJIDLNN.DNJEJEANJGL_Value; } set { FHBDAJIDLNN.DNJEJEANJGL_Value = value; } } //0x13586E8 JDHDMBHNKJD 0x1358714 FNAJEJLLJOE
		public string JEPGJJJBFLN_ConditionText { get { return IDCENBCAPBP.DNJEJEANJGL_Value; } set { IDCENBCAPBP.DNJEJEANJGL_Value = value; } } //0x1358748 AKHEBLBJGBP 0x1358774 EEJDMJMLKMG
		public int GLCLFMGPMAN_ItemId { get { return AHGCGHAAHOO ^ FBGGEFFJJHB; } set { AHGCGHAAHOO = value ^ FBGGEFFJJHB; } } //0x13587A8 LNJAENEGDEL 0x13587B8 JHIDBGCHOKL
		public int LJKMKCOAICL_ItemCount { get { return CMBLIDNDLOO ^ FBGGEFFJJHB; } set { CMBLIDNDLOO = value ^ FBGGEFFJJHB; } } //0x13587C8 KJPMAPBJBKE 0x13587D8 PPBMLEFDPOF
		public string LNDAOGHCKJK_ItemDetailText { get { return ELCOGKOBCNH.DNJEJEANJGL_Value; } set { ELCOGKOBCNH.DNJEJEANJGL_Value = value; } } //0x13587E8 JOPLPEHNFCO 0x1358814 BKHEPENKIBE
		public int CMCKNKKCNDK_MsStat { get { return NLBLLLLBHOP ^ FBGGEFFJJHB; } set { NLBLLLLBHOP = value ^ FBGGEFFJJHB; } } //0x1358848 CNKGOPKANGF 0x1358858 CHJGGLFGALP
		public int GMGGCIJHDJH_ConditionType { get { return KFEPIAKDDHA ^ FBGGEFFJJHB; } set { KFEPIAKDDHA = value ^ FBGGEFFJJHB; } } //0x1358868 BIPCONAFCPO 0x1358878 PKGLOAAEKHI
		public int DODGLIDGBBC_ConditionValue { get { return CILEPBKEOHB ^ FBGGEFFJJHB; } set { CILEPBKEOHB = value ^ FBGGEFFJJHB; } } //0x1358888 PAACNLDBGKP 0x1358898 AHIHPMDINHA
		public int GIKJNDFJFPM_MsCnt { get { return FANHHAHBDPA ^ FBGGEFFJJHB; } set { FANHHAHBDPA = value ^ FBGGEFFJJHB; } } //0x13588A8 IBMKJNJCEDO 0x13588B8 LJPNAJOLKNG
		public int MPBADMODLOJ_MsTarget { get { return JCCJFCHMDBF ^ FBGGEFFJJHB; } set { JCCJFCHMDBF = value ^ FBGGEFFJJHB; } } //0x13588C8 AMOLLDKGIPD 0x13588D8 GGPADGDEHMO
		public bool BCGLDMKODLC_IsSingle { get { return ALPDMEILILP == 0x1d; } set { ALPDMEILILP = (sbyte)(value ? 0x1d : 0x3f); } } //0x13588E8 NNGALFPBDNA 0x13588FC JJBMOHCMALD
		public bool CCKELABMHIO_MsAc { get { return MCFFGKAOIHP == 0x1d; } set { MCFFGKAOIHP = (sbyte)(value ? 0x1d : 0x3f); } } //0x135892C GGHKPKEGFLM 0x1358940 GCDJHHFGLLE

		// RVA: 0x1358970 Offset: 0x1358970 VA: 0x1358970
		public CJBKOOCMLEO()
		{
			LHPDDGIJKNB(0);
		}

		// RVA: 0x1358A50 Offset: 0x1358A50 VA: 0x1358A50
		public void LHPDDGIJKNB(int CMEJFJFOIIJ)
		{
			GLCLFMGPMAN_ItemId = 0;
			LJKMKCOAICL_ItemCount = 0;
			PPFNGGCBJKC = CMEJFJFOIIJ;
			NDFOAINJPIN = 0;
			LNDAOGHCKJK_ItemDetailText = "";
			MPBADMODLOJ_MsTarget = 0;
			CMCKNKKCNDK_MsStat = 0;
			GMGGCIJHDJH_ConditionType = 0;
			DODGLIDGBBC_ConditionValue = 0;
			GIKJNDFJFPM_MsCnt = 0;
			FEMMDNIELFC_MissionText = "";
			JEPGJJJBFLN_ConditionText = "";
			BCGLDMKODLC_IsSingle = false;
			CCKELABMHIO_MsAc = false;
		}
	}

	public class JLHHGLANHGE
	{
		private int FBGGEFFJJHB = GNGMCIAIKMA.FBGGEFFJJHB; // 0x8
		private long BBEGLBMOBOF = GNGMCIAIKMA.BBEGLBMOBOF; // 0x10
		private int EHOIENNDEDH; // 0x18
		private int AHGCGHAAHOO; // 0x1C
		private int CMBLIDNDLOO; // 0x20
		private NNJFKLBPBNK_SecureString AKPFPJPIION = new NNJFKLBPBNK_SecureString(); // 0x24
		private NNJFKLBPBNK_SecureString KFIDIDGPJGB = new NNJFKLBPBNK_SecureString(); // 0x28
		private int BFNCPNIMLGJ; // 0x2C
		private int OBNCDLMGDFG; // 0x30
		private sbyte AJGFHCKFCHN; // 0x34

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x1358B30 DEMEPMAEJOO 0x1358B40 HIGKAIDMOKN
		public int GLCLFMGPMAN_ItemFullId { get { return AHGCGHAAHOO ^ FBGGEFFJJHB; } set { AHGCGHAAHOO = value ^ FBGGEFFJJHB; } } //0x1358B50 LNJAENEGDEL 0x1358B60 JHIDBGCHOKL
		public int LJKMKCOAICL_ItemCount { get { return CMBLIDNDLOO ^ FBGGEFFJJHB; } set { CMBLIDNDLOO = value ^ FBGGEFFJJHB; } } //0x1358B70 KJPMAPBJBKE 0x1358B80 PPBMLEFDPOF
		public string HAAJGNCFNJM_ItemName { get { return AKPFPJPIION.DNJEJEANJGL_Value; } set { AKPFPJPIION.DNJEJEANJGL_Value = value; } } //0x1358B90 HKEGMCDHPBN 0x1358BBC EAANOGMNKNK
		public string FLGEGLADKHC_MissionText { get { return KFIDIDGPJGB.DNJEJEANJGL_Value; } set { KFIDIDGPJGB.DNJEJEANJGL_Value = value; } } //0x1358BF0 GLOGENJHAJG 0x1358C1C FHIAOOMBHNC
		public EKLNMHFCAOI.FKGCBLHOOCL_Category MJBKGOJBPAD_ItemCat { get { return (EKLNMHFCAOI.FKGCBLHOOCL_Category)(BFNCPNIMLGJ ^ FBGGEFFJJHB); } set { BFNCPNIMLGJ = (int)value ^ FBGGEFFJJHB; } } //0x1358C50 COFMKKJBELJ 0x1358C64 KHOHIGFNIIF
		public int OCNINMIMHGC_ItemId { get { return OBNCDLMGDFG ^ FBGGEFFJJHB; } set { OBNCDLMGDFG = value ^ FBGGEFFJJHB; } } //0x1358C74 BGCLLLFODPB 0x1358C84 FILEGBHDMFC
		public bool MPKBLMCNHOM { get { return AJGFHCKFCHN == 0x1d; } set { AJGFHCKFCHN = (sbyte)(value ? 0x1d : 0x3f); } } //0x1358C94 BOFCPLOLHCJ 0x1358CA8 FDPPEPOHFNA

		// RVA: 0x1358CD8 Offset: 0x1358CD8 VA: 0x1358CD8
		public JLHHGLANHGE()
		{
			LHPDDGIJKNB(0);
		}

		// RVA: 0x1358DA0 Offset: 0x1358DA0 VA: 0x1358DA0
		public void LHPDDGIJKNB(int EIHOBHDKCDB)
		{
			PPFNGGCBJKC = EIHOBHDKCDB;
			GLCLFMGPMAN_ItemFullId = 0;
			LJKMKCOAICL_ItemCount = 0;
			HAAJGNCFNJM_ItemName = "";
			FLGEGLADKHC_MissionText = "";
			MJBKGOJBPAD_ItemCat = EKLNMHFCAOI.FKGCBLHOOCL_Category.HJNNKCMLGFL_None;
			OCNINMIMHGC_ItemId = 0;
			MPKBLMCNHOM = false;
		}
	}

	private int FBGGEFFJJHB = GNGMCIAIKMA.FBGGEFFJJHB; // 0x8
	private long BBEGLBMOBOF = GNGMCIAIKMA.BBEGLBMOBOF; // 0x10
	public int PMPKHBAJAFA_BingoId; // 0x18
	public LKDLJCCJJNK NHPHOKNJNAH; // 0x1C
	public OMMBBPKFLNH MEAPAEMIOBB; // 0x20
	
	// RVA: 0x13582D8 Offset: 0x13582D8 VA: 0x13582D8
	public JJPEIELNEJB(int APFDNBGMMMM)
	{
		LHPDDGIJKNB(APFDNBGMMMM);
	}

	// RVA: 0x1358368 Offset: 0x1358368 VA: 0x1358368
	public bool LHPDDGIJKNB(int APFDNBGMMMM)
	{
		if (GNGMCIAIKMA.HHCJCDFCLOB != null)
		{
			GNGMCIAIKMA.DFABPMMMIIB d = GNGMCIAIKMA.HHCJCDFCLOB.GLJKKGFPEPA(APFDNBGMMMM);
			if (d != null)
			{
				PMPKHBAJAFA_BingoId = APFDNBGMMMM;
				d.KHEKNNFCAOI(APFDNBGMMMM);
				NHPHOKNJNAH = new LKDLJCCJJNK(APFDNBGMMMM);
				MEAPAEMIOBB = new OMMBBPKFLNH(APFDNBGMMMM);
				return true;
			}
		}
		return false;
	}
}
