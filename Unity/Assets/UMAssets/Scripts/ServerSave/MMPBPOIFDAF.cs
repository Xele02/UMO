
using System.Collections.Generic;

[System.Obsolete("Use MMPBPOIFDAF_Scene", true)]
public class MMPBPOIFDAF { }
public class MMPBPOIFDAF_Scene : KLFDBFMNLBL_ServerSaveBlock
{
	public class PMKOFEIONEG
	{
		public static int FBGGEFFJJHB = 0x3438a712; // 0x0
		public static int FCEJCHGLFGN = 0x7123348a; // 0x4
		private long JMFGGKLPKOM; // 0x8
		private long OJKBLADGDBM; // 0x10
		public byte[] PDNIFBEGMHC_Mb = new byte[15]; // 0x18
		public byte[] EMOJHJGHJLN = new byte[50]; // 0x1C
		private uint NHJDFCIMPEB; // 0x20
		private uint KNABHOOKLOH; // 0x24
		private int EHOIENNDEDH; // 0x28
		private int DGOIBJDJHFH; // 0x2C
		private int OPLKJKAIFPF; // 0x30
		private int FEIKCJFNEGC; // 0x34
		private int AOGCPFFLHHN; // 0x38
		public int ANAJIAENLNB_Level; // 0x3C
		public bool LHMOAJAIJCO_New; // 0x40
		private int IBFKAGCMCFA; // 0x44
		private int NKCNFBCEEOI; // 0x48
		private int KALBBDLPCDJ; // 0x4C
		private int NPHDJGPDJGK; // 0x50
		private int ELMLPFGPIIM; // 0x54
		private int MDIGCJGJBBA; // 0x58
		public int DOAAOOHGODJ_PstNew; // 0x5C

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x196B428 DEMEPMAEJOO 0x196BF80 HIGKAIDMOKN
		public long BEBJKJKBOGH_Date { get { return OJKBLADGDBM ^ FBGGEFFJJHB; } set { OJKBLADGDBM = value ^ FBGGEFFJJHB; JMFGGKLPKOM = value ^ FCEJCHGLFGN; } } //0x1969A80 DIAPHCJBPFD 0x196D63C IHAIKPNEEJE
		public bool IHIAFIHAAPO_Unlocked { get { return BEBJKJKBOGH_Date != 0 && ((JMFGGKLPKOM ^ FCEJCHGLFGN) == 0); } } //0x196A33C IIPKLJJIDNG
		public int MJBODMOLOBC_Luck { get { return NKCNFBCEEOI ^ FBGGEFFJJHB; } set { NKCNFBCEEOI = value ^ FBGGEFFJJHB; FEIKCJFNEGC = value ^ FCEJCHGLFGN; } } //0x196CA5C JDPBFBEBJOK 0x196D6F4 PNKGEPNKKBM
		public int JPIPENJGGDD_Mlt { get { return OPLKJKAIFPF ^ FBGGEFFJJHB; } set { OPLKJKAIFPF = value ^ FBGGEFFJJHB; DGOIBJDJHFH = value ^ FCEJCHGLFGN; } } //0x196A418 FBLKAMOKPPP 0x196D7A0 BEEPHNBJGLI
		public int IELENGDJPHF_Ulk { get { return AOGCPFFLHHN ^ FBGGEFFJJHB; } set { AOGCPFFLHHN = value ^ FBGGEFFJJHB; IBFKAGCMCFA = value ^ FCEJCHGLFGN; } } //0x196CAF4 OPNNJFMBCKC 0x196D84C CGAEHPNGCAK
		public int CDOBCKMHAOK_Inf { get { return KALBBDLPCDJ ^ FBGGEFFJJHB; } set { KALBBDLPCDJ = value ^ FBGGEFFJJHB; NPHDJGPDJGK = value ^ FCEJCHGLFGN; } } //0x196CB8C BKKAHGMBICD 0x196D8F8 LIIPKILBICO
		public int DMNIMMGGJJJ_Leaf { get { return ELMLPFGPIIM ^ FBGGEFFJJHB; } set { ELMLPFGPIIM = value ^ FBGGEFFJJHB; MDIGCJGJBBA = value ^ FCEJCHGLFGN; } } //0x196B0E4 CJCDKIKDBNP 0x196D9A4 CCGHKFJEFCB

		// // RVA: 0x196ADCC Offset: 0x196ADCC VA: 0x196ADCC
		public void CHDJAACPMJK_SetBit(ref byte[] MNHKNPDFMJL, int OIPCCBHIKIA)
		{
			MNHKNPDFMJL[OIPCCBHIKIA >> 3] |= (byte)(1 << (OIPCCBHIKIA & 0x7));
		}

		// // RVA: 0x1971BE8 Offset: 0x1971BE8 VA: 0x1971BE8
		// public void JPJDCAKKAOB(ref byte[] MNHKNPDFMJL, int OIPCCBHIKIA) { }

		// // RVA: 0x1971C48 Offset: 0x1971C48 VA: 0x1971C48
		public bool FAGMBGKOIFI_HasBit(byte[] MNHKNPDFMJL, int OIPCCBHIKIA)
		{
			return ((1 << (OIPCCBHIKIA & 0x7)) & MNHKNPDFMJL[OIPCCBHIKIA >> 3]) != 0;
		}

		// // RVA: 0x1971CA8 Offset: 0x1971CA8 VA: 0x1971CA8
		// public void HPNIPCKNHLL(int OIPCCBHIKIA) { }

		// // RVA: 0x1971CB4 Offset: 0x1971CB4 VA: 0x1971CB4
		// public void MMGLOEGODKD(int OIPCCBHIKIA) { }

		// // RVA: 0x1971CC0 Offset: 0x1971CC0 VA: 0x1971CC0
		// public bool IEPGLOIICLJ(int OIPCCBHIKIA) { }

		// // RVA: 0x1971CCC Offset: 0x1971CCC VA: 0x1971CCC
		// public void BNHNLIEOGBA(int OIPCCBHIKIA) { }

		// // RVA: 0x1971CD8 Offset: 0x1971CD8 VA: 0x1971CD8
		// public void EOPDKOCOLPI(int OIPCCBHIKIA) { }

		// // RVA: 0x196ADC0 Offset: 0x196ADC0 VA: 0x196ADC0
		// public bool PJLNENPKEDD(int OIPCCBHIKIA) { }

		// // RVA: 0x196BEF4 Offset: 0x196BEF4 VA: 0x196BEF4
		public PMKOFEIONEG()
		{
			LHPDDGIJKNB();
		}

		// // RVA: 0x1971CE4 Offset: 0x1971CE4 VA: 0x1971CE4
		public void LHPDDGIJKNB()
		{
			PPFNGGCBJKC_Id = 0;
			BEBJKJKBOGH_Date = 0;
			MJBODMOLOBC_Luck = 0;
			JPIPENJGGDD_Mlt = 0;
			IELENGDJPHF_Ulk = 0;
			ANAJIAENLNB_Level = 0;
			LHMOAJAIJCO_New = false;
			CDOBCKMHAOK_Inf = 0;
			DMNIMMGGJJJ_Leaf = 0;
			DOAAOOHGODJ_PstNew = 0;
			for(int i = 0; i < PDNIFBEGMHC_Mb.Length; i++)
			{
				PDNIFBEGMHC_Mb[i] = 0;
			}
			for(int i = 0; i < EMOJHJGHJLN.Length; i++)
			{
				EMOJHJGHJLN[i] = 0;
			}
			IDBDAPPJOND();
		}

		// // RVA: 0x196E140 Offset: 0x196E140 VA: 0x196E140
		// public bool AGBOGBEOFME(MMPBPOIFDAF.PMKOFEIONEG OIKJFMGEICL) { }

		// // RVA: 0x196DBEC Offset: 0x196DBEC VA: 0x196DBEC
		public void ODDIHGPONFL(PMKOFEIONEG GPBJHKLFCEP)
		{
			PPFNGGCBJKC_Id = GPBJHKLFCEP.PPFNGGCBJKC_Id;
			BEBJKJKBOGH_Date = GPBJHKLFCEP.BEBJKJKBOGH_Date;
			ANAJIAENLNB_Level = GPBJHKLFCEP.ANAJIAENLNB_Level;
			MJBODMOLOBC_Luck = GPBJHKLFCEP.MJBODMOLOBC_Luck;
			JPIPENJGGDD_Mlt = GPBJHKLFCEP.JPIPENJGGDD_Mlt;
			IELENGDJPHF_Ulk = GPBJHKLFCEP.IELENGDJPHF_Ulk;
			LHMOAJAIJCO_New = GPBJHKLFCEP.LHMOAJAIJCO_New;
			NHJDFCIMPEB = GPBJHKLFCEP.NHJDFCIMPEB;
			KNABHOOKLOH = GPBJHKLFCEP.KNABHOOKLOH;
			CDOBCKMHAOK_Inf = GPBJHKLFCEP.CDOBCKMHAOK_Inf;
			DMNIMMGGJJJ_Leaf = GPBJHKLFCEP.DMNIMMGGJJJ_Leaf;
			DOAAOOHGODJ_PstNew = GPBJHKLFCEP.DOAAOOHGODJ_PstNew;
			for(int i = 0; i < PDNIFBEGMHC_Mb.Length; i++)
			{
				PDNIFBEGMHC_Mb[i] = GPBJHKLFCEP.PDNIFBEGMHC_Mb[i];
			}
			for(int i = 0; i < EMOJHJGHJLN.Length; i++)
			{
				EMOJHJGHJLN[i] = GPBJHKLFCEP.EMOJHJGHJLN[i];
			}
		}

		// // RVA: 0x196E8D8 Offset: 0x196E8D8 VA: 0x196E8D8
		// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, MMPBPOIFDAF.PMKOFEIONEG OHMCIEMIKCE, bool KFCGIKHEEMB) { }

		// // RVA: 0x196AE2C Offset: 0x196AE2C VA: 0x196AE2C
		public void IDBDAPPJOND()
		{
			NHJDFCIMPEB = CEDHHAGBIBA.CAOGDCBPBAN(PDNIFBEGMHC_Mb);
			KNABHOOKLOH = CEDHHAGBIBA.CAOGDCBPBAN(EMOJHJGHJLN);
			ANAJIAENLNB_Level = CEDHHAGBIBA.OGPFNHOKONH(PDNIFBEGMHC_Mb) + 1;
		}

		// // RVA: 0x1971698 Offset: 0x1971698 VA: 0x1971698
		// public FENCAJJBLBH PFAKPFKJJKA() { }

		// // RVA: 0x1971E34 Offset: 0x1971E34 VA: 0x1971E34
		// public bool OFNNNEMCJNN() { }

		// // RVA: 0x196A4B0 Offset: 0x196A4B0 VA: 0x196A4B0
		// public void OEBOPKCCEEO(int JPIPENJGGDD) { }

		// // RVA: 0x197210C Offset: 0x197210C VA: 0x197210C
		// public bool JECJALJEDPP(int INDDJNMPONH) { }

		// // RVA: 0x1972124 Offset: 0x1972124 VA: 0x1972124
		// public void BILHHMGCPFC(int INDDJNMPONH) { }

		// // RVA: 0x1972140 Offset: 0x1972140 VA: 0x1972140
		// public void DDLEICINOHK(long BEBJKJKBOGH, int JKONPJKILCH) { }

		// // RVA: 0x1972278 Offset: 0x1972278 VA: 0x1972278
		// public void DJNPIJPHKKJ(long BEBJKJKBOGH, int JKONPJKILCH) { }

		// // RVA: 0x19723B0 Offset: 0x19723B0 VA: 0x19723B0
		// public int HNNOJNHDNLF(int JPJNKNOJBMM) { }

		// // RVA: 0x19723F4 Offset: 0x19723F4 VA: 0x19723F4
		// public bool LMLDPHIAOPH(int JPJNKNOJBMM, int BMIKDIOLMCF) { }
	}
	private const int ECFEMKGFDCE = 3;
	private const int MJCBKPFKLIN = 3;
	public static string POFDDFCGEGP = "_"; // 0x0
	private const int CPDDEFMBHOM = 6000;
	private const int JBCJOLMDAOD = 100;

	public List<PMKOFEIONEG> OPIBAPEGCLA { get; private set; } // 0x24 OAKOEGLENEJ KHGLIMIOIEJ HELEKCPEPLE
	// public override bool DMICHEJIAJL { get; } ??

	// // RVA: 0x1969998 Offset: 0x1969998 VA: 0x1969998
	// public int IGJAAIEAJPB() { }

	// // RVA: 0x1969B1C Offset: 0x1969B1C VA: 0x1969B1C
	public int MPFLFKBNFEI_GetNumSceneAtLevelOrMore(LDDDBPNGGIN_Game HNMMJINNHII, MLIBEPGADJH_Scene ECNHDEHADGL, int FCDKJAKLGMB)
	{
		int res = 0;
		for(int i = 0; i < ECNHDEHADGL.CDENCMNHNGA_SceneList.Count; i++)
		{
			if(ECNHDEHADGL.CDENCMNHNGA_SceneList[i].PPEGAKEIEGM_En == 2)
			{
				if(OPIBAPEGCLA[i].BEBJKJKBOGH_Date != 0)
				{
					if (FCDKJAKLGMB <= OPIBAPEGCLA[i].ANAJIAENLNB_Level)
						res++;
				}
			}
		}
		return res;
	}

	// // RVA: 0x1969CD8 Offset: 0x1969CD8 VA: 0x1969CD8
	public int NEAGFIEMLIL_GetSceneLevel(LDDDBPNGGIN_Game HNMMJINNHII, MLIBEPGADJH_Scene ECNHDEHADGL, int PPFNGGCBJKC)
	{
		if(ECNHDEHADGL.CDENCMNHNGA_SceneList[PPFNGGCBJKC - 1].PPEGAKEIEGM_En == 2)
		{
			if(OPIBAPEGCLA[PPFNGGCBJKC - 1].BEBJKJKBOGH_Date != 0)
			{
				return OPIBAPEGCLA[PPFNGGCBJKC - 1].ANAJIAENLNB_Level;
			}
		}
		return 0;
	}

	// // RVA: 0x1969E34 Offset: 0x1969E34 VA: 0x1969E34
	// public int BNNPJLPMLLK(LDDDBPNGGIN HNMMJINNHII, MLIBEPGADJH ECNHDEHADGL) { }

	// // RVA: 0x196A0C8 Offset: 0x196A0C8 VA: 0x196A0C8
	// public int FLPPOODHKAB(MLIBEPGADJH ECNHDEHADGL, int NDKJCDGHPLD, int LFPEIEOHABE, bool DHOFGFAEJFM = False) { }

	// // RVA: 0x196A4D8 Offset: 0x196A4D8 VA: 0x196A4D8
	// public int HOLEDOLMJCB(int PPFNGGCBJKC, MLIBEPGADJH ECNHDEHADGL, int INDDJNMPONH) { }

	// // RVA: 0x196A78C Offset: 0x196A78C VA: 0x196A78C
	private bool AHKLHIBIDHF(MLIBEPGADJH_Scene ECNHDEHADGL, KOGHKIODHPA_Board JEMMMJEJLNL)
	{
		byte[] b = new byte[50];
		bool res = false;
		for(int i = 0; i < OPIBAPEGCLA.Count; i++)
		{
			MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = ECNHDEHADGL.CDENCMNHNGA_SceneList[i];
			if(JEMMMJEJLNL.AKKIBDEENJH(dbScene.ILABPFOMEAG_Va) && OPIBAPEGCLA[i].IHIAFIHAAPO_Unlocked)
			{
				int val = 99;
				if(OPIBAPEGCLA[i].JPIPENJGGDD_Mlt < 101)
				{
					val = OPIBAPEGCLA[i].JPIPENJGGDD_Mlt - 1;
					if(val < 1)
						continue;
				}
				if(OPIBAPEGCLA[i].FAGMBGKOIFI_HasBit(OPIBAPEGCLA[i].EMOJHJGHJLN, 0))
				{
					DMPDJFAGCPN a = JEMMMJEJLNL.GPKFGCFHDHH(dbScene.AOPBAOJIOGO_Sb, false);
					if(a != null)
					{
						if(a.PDKGMFHIFML_Pl.Count > 1)
						{
							for(int j = 0; j < 50; j++)
							{
								b[i] = 0;
							}
							int l = 0;
							int m = 0;
							int f = -1;
							int n = 0;
							for(int j = 0; j < val; j++)
							{
								for(int k = a.PDKGMFHIFML_Pl.Count - 2; k > -1; k--)
								{
									if(OPIBAPEGCLA[i].FAGMBGKOIFI_HasBit(OPIBAPEGCLA[i].EMOJHJGHJLN, k + l))
									{
										if(f < 0)
											f = k;
										if(!(JEMMMJEJLNL.GJLBMELKHEM[dbScene.ILABPFOMEAG_Va - 1].JPJNKNOJBMM <= j || m != 0))
										{
											m = 0;
											if(JEMMMJEJLNL.DDGNLCJGFJF(a.PDKGMFHIFML_Pl[k].JBGEEPFKIGG).INDDJNMPONH_StatType == 19)
											{
												m = 1;
											}
										}
									}
								}
								if(l != 0)
								{
									n++;
									OPIBAPEGCLA[i].CHDJAACPMJK_SetBit(ref b, n + f);
								}
								n += a.PDKGMFHIFML_Pl.Count - 1;
								l += a.PDKGMFHIFML_Pl.Count - 1;
							}
							if(n != a.PDKGMFHIFML_Pl.Count * val)
							{
								for(int j = 0; j < 50; j++)
								{
									OPIBAPEGCLA[i].EMOJHJGHJLN[j] = b[j];
								}
								OPIBAPEGCLA[i].IDBDAPPJOND();
								res = true;
							}
						}
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0x196AEE4 Offset: 0x196AEE4 VA: 0x196AEE4
	// public bool MBGEHFKKOEN(MLIBEPGADJH ECNHDEHADGL) { }

	// // RVA: 0x196B17C Offset: 0x196B17C VA: 0x196B17C
	public List<MLIBEPGADJH_Scene.KKLDOOJBJMN> NFFGMOFIBDH_GetAllUnlockedRareScenes(MLIBEPGADJH_Scene ECNHDEHADGL)
	{
		List<MLIBEPGADJH_Scene.KKLDOOJBJMN> res = new List<MLIBEPGADJH_Scene.KKLDOOJBJMN>();
		for(int i = 0; i < OPIBAPEGCLA.Count; i++)
		{
			MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = ECNHDEHADGL.CDENCMNHNGA_SceneList[OPIBAPEGCLA[i].PPFNGGCBJKC_Id - 1];
			if(dbScene.PPEGAKEIEGM_En > 1)
			{
				if(dbScene.EKLIPGELKCL_Rarity > 5)
				{
					if(OPIBAPEGCLA[i].IHIAFIHAAPO_Unlocked)
					{
						res.Add(dbScene);
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0x196B4C0 Offset: 0x196B4C0 VA: 0x196B4C0
	public bool GOFAPKBNNCL_HasRareSceneWithCostumeForDivaUnlocked(int DPKCMAHGHNI)
    {
		OKGLGHCBCJP_Database db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
		if (db != null)
		{
			MLIBEPGADJH_Scene dbScenes = db.ECNHDEHADGL_Scene;
			KMOGDEOKHPG_Episode dbEps = db.MOLEPBNJAGE_Episode;
			LCLCCHLDNHJ_Costume dbCos = db.MFPNGNMFEAL_Costume;
			List<MLIBEPGADJH_Scene.KKLDOOJBJMN> l = NFFGMOFIBDH_GetAllUnlockedRareScenes(dbScenes);
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i].KELFCMEOPPM_Ep > 0)
				{
					HMGPODKEFBA_EpisodeInfo ep = dbEps.BBAJKJPKOHD_EpisodeList[l[i].KELFCMEOPPM_Ep - 1];
					for(int j = 0; j < ep.HHJGBJCIFON_Rewards.Count; j++)
					{
						JNIKPOIKFAC_Reward reward = dbEps.LFAAEPAAEMB_Rewards[ep.HHJGBJCIFON_Rewards[j]];
						if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(reward.KIJAPOFAGPN_Item) == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume)
						{
							int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(reward.KIJAPOFAGPN_Item);
							if(itemId > 0)
							{
								LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = dbCos.CDENCMNHNGA_Costumes[itemId - 1];
								if (cos.AHHJLDLAPAN_PrismDivaId == DPKCMAHGHNI)
									return true;
							}
						}
					}
				}
			}
		}
        return false;
    }

	// // RVA: 0x196B8D8 Offset: 0x196B8D8 VA: 0x196B8D8
	// public int JKMOIKPIGBA() { }

	// // RVA: 0x196BAA8 Offset: 0x196BAA8 VA: 0x196BAA8
	// public int JPFAAHCMCEO() { }

	// // RVA: 0x196BD54 Offset: 0x196BD54 VA: 0x196BD54
	public MMPBPOIFDAF_Scene()
	{
		OPIBAPEGCLA = new List<PMKOFEIONEG>(6000);
		KMBPACJNEOF();
	}

	// // RVA: 0x196BDF8 Offset: 0x196BDF8 VA: 0x196BDF8 Slot: 4
	public override void KMBPACJNEOF()
	{
		OPIBAPEGCLA.Clear();
		for(int i = 0; i < 6000; i++)
		{
			PMKOFEIONEG data = new PMKOFEIONEG();
			data.PPFNGGCBJKC_Id = i + 1;
			OPIBAPEGCLA.Add(data);
		}
	}

	// // RVA: 0x196C01C Offset: 0x196C01C VA: 0x196C01C Slot: 5
	// public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH) { }

	// // RVA: 0x196CC24 Offset: 0x196CC24 VA: 0x196CC24 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 3);
		if(blockMissing)
			return false;
		OKGLGHCBCJP_Database db = null;
		if(IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
		{
			db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
		}
		if(block != null)
		{
			for(int i = 0; i < OPIBAPEGCLA.Count; i++)
			{
				PMKOFEIONEG data = OPIBAPEGCLA[i];
				string k = POFDDFCGEGP + (i + 1);
				if(block.BBAJPINMOEP_Contains(k))
				{
					EDOHBJAPLPF_JsonData json = block[k];
					data.BEBJKJKBOGH_Date = DKMPHAPBDLH_ReadLong(json, AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0, ref isInvalid);
					data.ANAJIAENLNB_Level = CJAENOMGPDA_ReadInt(json, AFEHLCGHAEE_Strings.ANAJIAENLNB_lv, 0, ref isInvalid);
					data.MJBODMOLOBC_Luck = CJAENOMGPDA_ReadInt(json, AFEHLCGHAEE_Strings.MJBODMOLOBC_luck, 0, ref isInvalid);
					data.JPIPENJGGDD_Mlt = CJAENOMGPDA_ReadInt(json, AFEHLCGHAEE_Strings.ALMNMBDELDB_mlt, 0, ref isInvalid);
					data.IELENGDJPHF_Ulk = CJAENOMGPDA_ReadInt(json, AFEHLCGHAEE_Strings.PMANOMLMICI_ulk, 0, ref isInvalid);
					data.LHMOAJAIJCO_New = CJAENOMGPDA_ReadInt(json, AFEHLCGHAEE_Strings.KLJGEHBKMMG_new, 0, ref isInvalid) != 0;
					data.CDOBCKMHAOK_Inf = CJAENOMGPDA_ReadInt(json, AFEHLCGHAEE_Strings.CDOBCKMHAOK_inf, 0, ref isInvalid);
					data.DMNIMMGGJJJ_Leaf = CJAENOMGPDA_ReadInt(json, "leaf", 0, ref isInvalid);
					data.DOAAOOHGODJ_PstNew = CJAENOMGPDA_ReadInt(json, AFEHLCGHAEE_Strings.EGPELMDJDCC_pst_new, 0, ref isInvalid);
					CEDHHAGBIBA.IFOLECIIDPO_StringToByteArray(data.PDNIFBEGMHC_Mb, FGCNMLBACGO_ReadString(json, AFEHLCGHAEE_Strings.DANMJLOBLIE_mb, "", ref isInvalid));
					if(db != null)
					{
						if(data.PPFNGGCBJKC_Id != 0)
						{
							if(db.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[i].PPEGAKEIEGM_En == 2)
							{
								data.MJBODMOLOBC_Luck = db.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[i].AGOEDLNOHND(db.JEMMMJEJLNL_Board, data.EMOJHJGHJLN, data.JPIPENJGGDD_Mlt, db.HNMMJINNHII_Game.GENHLFPKOEE(db.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[i].EKLIPGELKCL_Rarity, db.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[i].MCCIFLKCNKO_Feed));
							}
						}
					}
					data.IDBDAPPJOND();
				}
			}
			if(db != null)
			{
				if(block.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev) && (int)block[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] <= 2 && AHKLHIBIDHF(db.ECNHDEHADGL_Scene, db.JEMMMJEJLNL_Board))
				{
					isInvalid = true;
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
		}
		else
		{
			KFKDMBPNLJK_BlockInvalid = true;
		}
		return true;
	}

	// // RVA: 0x196DA50 Offset: 0x196DA50 VA: 0x196DA50 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		MMPBPOIFDAF_Scene s = GPBJHKLFCEP as MMPBPOIFDAF_Scene;
		for(int i = 0; i < 6000; i++)
		{
			OPIBAPEGCLA[i].ODDIHGPONFL(s.OPIBAPEGCLA[i]);
		}
	}

	// // RVA: 0x196DEF8 Offset: 0x196DEF8 VA: 0x196DEF8 Slot: 8
	// public override bool AGBOGBEOFME(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x196E4CC Offset: 0x196E4CC VA: 0x196E4CC Slot: 10
	// public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL GJLFANGDGCL, long MCKEOKFMLAH) { }

	// // RVA: 0x19715B4 Offset: 0x19715B4 VA: 0x19715B4 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.Log(0, "TODO");
		return null;
	}

	// // RVA: 0x1971B6C Offset: 0x1971B6C VA: 0x1971B6C Slot: 9
	// public override bool NFKFOODCJJB() { }
}
