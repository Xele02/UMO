
using System.Collections.Generic;
using System.Linq;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys;

public class HEFCLPGPMLK
{
	public class AAOPGOGGMID
	{
		public int PPFNGGCBJKC; // 0x8
		public string IJOLPDKFLPO_OfferName; // 0xC
		public int KINFGHHNFCF; // 0x10
		public int NONBCCLGBAO; // 0x14
		public BOPFPIHGJMD.LGEIPIHHNPH DFMOGBOPLEF_Series; // 0x18
		public int CIEOBFIIPLD_Level; // 0x1C
		public int NBLBJCLIDNN_MaxLevel; // 0x20
		public bool NBHEBLNHOJO; // 0x24
		public int BIEGNEGKLDE_SpItemId; // 0x28
		public List<int> AHNKDJLBLNM = new List<int>(); // 0x2C
		public List<int> PCPPHNINBBC = new List<int>(); // 0x30
		public BOPFPIHGJMD.MLBMHDCCGHI FGHGMHPNEMG_Category; // 0x34
		public BOPFPIHGJMD.ADMNKELOLPN CGKPIIFCCLD_OfferType; // 0x38
		public BOPFPIHGJMD.IGHPDAGKIKO CMCKNKKCNDK_Status; // 0x3C
		public long KINJOEIAHFK_StartDate; // 0x40
		public long PCCFAKEOBIC_EndDate; // 0x48
		public long JGAMLEMMJCJ_ClearTime; // 0x50
		public long GCDPPCDBPDD_TimeLeftMs; // 0x58
		public long LOAEGNGKFNF_Expr; // 0x60
		public int IMPNNOLLMBK; // 0x68
		public bool CADENLBDAEB; // 0x6C
		public bool OHOGIHMFEIJ; // 0x6D
		public int MNPEAHNONAI_Cnt; // 0x70
		public int KPFHAMNOIAG; // 0x74
		public int AHHJLDLAPAN; // 0x78
		public BOPFPIHGJMD.HDHDOOLPBEO HBJEDMOMAEE_SpOfferType; // 0x7C

		//// RVA: 0x1747F3C Offset: 0x1747F3C VA: 0x1747F3C
		public OfferSelectContent.OrderButtonState MJKJGDOIAGO()
		{
			if(CMCKNKKCNDK_Status <= BOPFPIHGJMD.IGHPDAGKIKO.CADDNFIKDLG_4_Complete && CMCKNKKCNDK_Status > BOPFPIHGJMD.IGHPDAGKIKO.FLFIICJKPKF_0)
			{
				switch(CMCKNKKCNDK_Status)
				{
					default:
						return (OfferSelectContent.OrderButtonState)(CMCKNKKCNDK_Status - 1);
					case BOPFPIHGJMD.IGHPDAGKIKO.LGOIJAPMEBG_2_Progress:
						return OfferSelectContent.OrderButtonState.PROGRESS;
				}
			}
			return OfferSelectContent.OrderButtonState.COMPLETE;
		}
	}

	public class ANKPCIEKPAH
	{
		public int LLOBHDMHJIG_Id; // 0x8
		public int LABKKJAGDFN_FormationId; // 0xC
		public int KINFGHHNFCF_Atk; // 0x10
		public int NONBCCLGBAO_Hit; // 0x14
		public int JMHKMDFNAIN; // 0x18
		public SeriesAttr.Type CPKMLLNADLJ_Attr; // 0x1C
		public int PFGJJLGLPAC_PilotId; // 0x20
		public string PMKFOEIFBLB_PilotName; // 0x24
		public string PNIEAEHKGMJ_ValkName; // 0x28
		public int CNLIAMIIJID_Level; // 0x2C
		public bool LPDDOLAIODN; // 0x30
		public int HOJHKJBBOLM; // 0x34
		public int CKJPPJHNBBN; // 0x38
		public int KFFEFIPMOLD; // 0x3C
	}

	public class DNNODDKHJBJ : IComparer<AAOPGOGGMID>
	{
		private int AAFGNHHCILA = -1; // 0x8
		private int OJDPFLDPODB = -1; // 0xC

		// RVA: 0x1745D74 Offset: 0x1745D74 VA: 0x1745D74
		public DNNODDKHJBJ(bool DACKJBKIDOM = false)
		{
			AAFGNHHCILA = DACKJBKIDOM ? -1 : 1;
			OJDPFLDPODB = DACKJBKIDOM ? 1 : -1;
		}

		// RVA: 0x1747F80 Offset: 0x1747F80 VA: 0x1747F80 Slot: 4
		public int Compare(AAOPGOGGMID HKICMNAACDA, AAOPGOGGMID BNKHBCBJBKI)
		{
			if(HKICMNAACDA.CIEOBFIIPLD_Level == BNKHBCBJBKI.CIEOBFIIPLD_Level)
			{
				if(HKICMNAACDA.JGAMLEMMJCJ_ClearTime == BNKHBCBJBKI.JGAMLEMMJCJ_ClearTime)
				{
					if(HKICMNAACDA.NONBCCLGBAO == BNKHBCBJBKI.NONBCCLGBAO)
					{
						if (HKICMNAACDA.PPFNGGCBJKC == BNKHBCBJBKI.PPFNGGCBJKC)
							return 0;
						if (HKICMNAACDA.PPFNGGCBJKC <= BNKHBCBJBKI.PPFNGGCBJKC)
							return OJDPFLDPODB;
					}
					else if(HKICMNAACDA.NONBCCLGBAO <= BNKHBCBJBKI.NONBCCLGBAO)
						return OJDPFLDPODB;
				}
				else if (HKICMNAACDA.JGAMLEMMJCJ_ClearTime <= BNKHBCBJBKI.JGAMLEMMJCJ_ClearTime)
					return OJDPFLDPODB;
			}
			else
			{
				if (HKICMNAACDA.CIEOBFIIPLD_Level <= BNKHBCBJBKI.CIEOBFIIPLD_Level)
					return OJDPFLDPODB;
			}
			return AAFGNHHCILA;
		}
	}

	public List<AAOPGOGGMID> CAGIOJAAGGP; // 0x8
	public List<AAOPGOGGMID> KPMDLOBOEEM; // 0xC
	public List<AAOPGOGGMID> NLKBPLNCPGG; // 0x10
	public List<AAOPGOGGMID> PJEOEOHGMMA; // 0x14
	public List<ANKPCIEKPAH> MDNHCIKGEAE; // 0x18

	// RVA: 0x17439B0 Offset: 0x17439B0 VA: 0x17439B0
	public void EMAEAEAKDLJ()
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		if(KDHGBOOECKC.HHCJCDFCLOB != null)
		{
			KDHGBOOECKC.HHCJCDFCLOB.HKDGKDNIGDD();
			KDHGBOOECKC.HHCJCDFCLOB.JPNPPIHOJFC(time);
			CAGIOJAAGGP = IOCBIDHIIAE(time);
			KPMDLOBOEEM = GCHFJGGNEAM(time);
			NLKBPLNCPGG = CICAACFCNDC(time);
			PJEOEOHGMMA = JNJOOCCFBLF(time);
		}
	}

	//// RVA: 0x17453CC Offset: 0x17453CC VA: 0x17453CC
	public AAOPGOGGMID HHPEMLOLJIH()
	{
		List<AAOPGOGGMID> l = new List<AAOPGOGGMID>(CAGIOJAAGGP);
		l.AddRange(KPMDLOBOEEM);
		l.AddRange(NLKBPLNCPGG);
		return l.Where((AAOPGOGGMID GHPLINIACBB) =>
		{
			//0x1747EB0
			return GHPLINIACBB.CMCKNKKCNDK_Status == BOPFPIHGJMD.IGHPDAGKIKO.LGOIJAPMEBG_2_Progress;
		}).OrderBy((AAOPGOGGMID GHPLINIACBB) =>
		{
			//0x1747EE0
			return GHPLINIACBB.PCCFAKEOBIC_EndDate;
		}).FirstOrDefault();
	}

	//// RVA: 0x17456B8 Offset: 0x17456B8 VA: 0x17456B8
	public List<AAOPGOGGMID> PDFOBMKIKKJ(BOPFPIHGJMD.MLBMHDCCGHI INDDJNMPONH, bool CILNIPJEECH = false, bool GJAFIADJFHH = false)
	{
		List<AAOPGOGGMID> l = new List<AAOPGOGGMID>();
		if (CILNIPJEECH)
			EMAEAEAKDLJ();
		switch(INDDJNMPONH)
		{
			case BOPFPIHGJMD.MLBMHDCCGHI.HEFPAOLDHCK_1_Day:
				return OEMBGNHHONF(CAGIOJAAGGP, GJAFIADJFHH);
			case BOPFPIHGJMD.MLBMHDCCGHI.FDOOAJLGFAE_2_Week:
				return OEMBGNHHONF(KPMDLOBOEEM, GJAFIADJFHH);
			case BOPFPIHGJMD.MLBMHDCCGHI.FMLPIOFBCMA_3_Diva:
				return OEMBGNHHONF(NLKBPLNCPGG, GJAFIADJFHH);
			case BOPFPIHGJMD.MLBMHDCCGHI.GENEIBGNMPH_4_Debut:
				return OEMBGNHHONF(PJEOEOHGMMA, GJAFIADJFHH);
			default:
				return OEMBGNHHONF(l, GJAFIADJFHH);
		}
	}

	//// RVA: 0x17457A4 Offset: 0x17457A4 VA: 0x17457A4
	public List<AAOPGOGGMID> OEMBGNHHONF(List<AAOPGOGGMID> NNDGIAEFMOG, bool DACKJBKIDOM = false)
	{
		List<AAOPGOGGMID> l1 = new List<AAOPGOGGMID>();
		List<AAOPGOGGMID> l2 = new List<AAOPGOGGMID>();
		List<AAOPGOGGMID> l3 = new List<AAOPGOGGMID>();
		List<AAOPGOGGMID> l4 = new List<AAOPGOGGMID>();
		List<AAOPGOGGMID> l5 = new List<AAOPGOGGMID>();
		List<AAOPGOGGMID> l6 = new List<AAOPGOGGMID>();
		List<AAOPGOGGMID> l7 = new List<AAOPGOGGMID>();
		for(int i = 0; i < NNDGIAEFMOG.Count; i++)
		{
			switch(NNDGIAEFMOG[i].CMCKNKKCNDK_Status)
			{
				case BOPFPIHGJMD.IGHPDAGKIKO.EBAPFCDNMGD_1_Order:
					if (NNDGIAEFMOG[i].HBJEDMOMAEE_SpOfferType == BOPFPIHGJMD.HDHDOOLPBEO.MOADAEHPFPA_3)
						l2.Add(NNDGIAEFMOG[i]);
					else if (NNDGIAEFMOG[i].HBJEDMOMAEE_SpOfferType == BOPFPIHGJMD.HDHDOOLPBEO.LJJODKKOOFD_2)
						l1.Add(NNDGIAEFMOG[i]);
					else if (NNDGIAEFMOG[i].HBJEDMOMAEE_SpOfferType == BOPFPIHGJMD.HDHDOOLPBEO.CCDOBDNDPIL_1)
						l3.Add(NNDGIAEFMOG[i]);
					else
						l4.Add(NNDGIAEFMOG[i]);
					break;
				case BOPFPIHGJMD.IGHPDAGKIKO.LGOIJAPMEBG_2_Progress:
					l5.Add(NNDGIAEFMOG[i]);
					break;
				case BOPFPIHGJMD.IGHPDAGKIKO.FJGFAPKLLCL_3_Achieved:
					l6.Add(NNDGIAEFMOG[i]);
					break;
				case BOPFPIHGJMD.IGHPDAGKIKO.CADDNFIKDLG_4_Complete:
					l7.Add(NNDGIAEFMOG[i]);
					break;
				default:
					break;
			}
		}
		DNNODDKHJBJ d = new DNNODDKHJBJ(DACKJBKIDOM);
		l6.Sort(d);
		l5.Sort(d);
		l1.Sort(d);
		l2.Sort(d);
		l3.Sort(d);
		l4.Sort(d);
		l7.Sort(d);
		l6.AddRange(l5);
		l6.AddRange(l1);
		l6.AddRange(l2);
		l6.AddRange(l3);
		l6.AddRange(l4);
		l6.AddRange(l7);
		return l6;
	}

	//// RVA: 0x1745DB4 Offset: 0x1745DB4 VA: 0x1745DB4
	public void KJODFBIBFFO(BBHNACPENDM_ServerSaveData LDEGEHAEALK, ref AAOPGOGGMID IDLHJIOMJBK, int FGHGMHPNEMG, int MLDPDLPHJPM, long JHNMKKNEENE)
	{
		if(KDHGBOOECKC.HHCJCDFCLOB != null)
		{
			List<KDHGBOOECKC.NOCAJFGHDPC> l = KDHGBOOECKC.HHCJCDFCLOB.NBIJDMOOILH();
			if (l == null)
				KDHGBOOECKC.HHCJCDFCLOB.BJIPLMJFAGH();
			OCMJNBIFJNM_Offer.JPOHOLBBFGP d = KDHGBOOECKC.HHCJCDFCLOB.BKJJKHIBIGP((BOPFPIHGJMD.MLBMHDCCGHI)FGHGMHPNEMG, MLDPDLPHJPM);
			if(d != null)
			{
				IDLHJIOMJBK.CMCKNKKCNDK_Status = (BOPFPIHGJMD.IGHPDAGKIKO) d.EALOBDHOCHP_Stat;
				IDLHJIOMJBK.KINJOEIAHFK_StartDate = d.DFJLNPFJGDK_Sdt;
				IDLHJIOMJBK.PCCFAKEOBIC_EndDate = d.NCDHKKCCGOD_Edt;
				IDLHJIOMJBK.GCDPPCDBPDD_TimeLeftMs = (d.NCDHKKCCGOD_Edt - JHNMKKNEENE) * 1000;
				IDLHJIOMJBK.LOAEGNGKFNF_Expr = d.KOOEOKEDJDO_Expr;
				IDLHJIOMJBK.MNPEAHNONAI_Cnt = d.BFINGCJHOHI_Cnt;
				IDLHJIOMJBK.CADENLBDAEB = d.BFINGCJHOHI_Cnt == 0;
				if (d.DPMCPMJJGAA_HasFlag(BOPFPIHGJMD.CMBJEEGFODD.HIJBHIFABFC_32))
					IDLHJIOMJBK.HBJEDMOMAEE_SpOfferType = BOPFPIHGJMD.HDHDOOLPBEO.MOADAEHPFPA_3;
				else if (d.DPMCPMJJGAA_HasFlag(BOPFPIHGJMD.CMBJEEGFODD.JPFLFLFFEDD_16))
					IDLHJIOMJBK.HBJEDMOMAEE_SpOfferType = BOPFPIHGJMD.HDHDOOLPBEO.LJJODKKOOFD_2;
				else
				{
					IDLHJIOMJBK.HBJEDMOMAEE_SpOfferType = d.DPMCPMJJGAA_HasFlag(BOPFPIHGJMD.CMBJEEGFODD.DPNBNKOOJHI_1) ? BOPFPIHGJMD.HDHDOOLPBEO.CCDOBDNDPIL_1 : BOPFPIHGJMD.HDHDOOLPBEO.HJNNKCMLGFL_0;
					return;
				}
				IDLHJIOMJBK.CADENLBDAEB = false;
			}
		}
	}

	//// RVA: 0x1743B28 Offset: 0x1743B28 VA: 0x1743B28
	public List<AAOPGOGGMID> IOCBIDHIIAE(long JHNMKKNEENE)
	{
		List<AAOPGOGGMID> res = new List<AAOPGOGGMID>();
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
		{
			if(KDHGBOOECKC.HHCJCDFCLOB != null)
			{
				List<LGHIPHEDCNC_Offer.LHDLCLNBPLB>  l1 = KDHGBOOECKC.HHCJCDFCLOB.MIMNFDFLFFA(JHNMKKNEENE);
				for(int i = 0; i < l1.Count; i++)
				{
					AAOPGOGGMID data = new AAOPGOGGMID();
					data.PPFNGGCBJKC = l1[i].PPFNGGCBJKC;
					data.IJOLPDKFLPO_OfferName = KDHGBOOECKC.HHCJCDFCLOB.GEGAJLNPMEC((BOPFPIHGJMD.MLBMHDCCGHI)l1[i].GBJFNGCDKPM, l1[i].PPFNGGCBJKC);
					data.DFMOGBOPLEF_Series = KDHGBOOECKC.HHCJCDFCLOB.MDNPDBIPKLB((BOPFPIHGJMD.AHIOHONIGDH)l1[i].CPKMLLNADLJ, l1[i].JBHBGOIMALD);
					data.KINFGHHNFCF = l1[i].FCBJFKGDINH;
					data.NONBCCLGBAO = l1[i].NONBCCLGBAO;
					data.FGHGMHPNEMG_Category = (BOPFPIHGJMD.MLBMHDCCGHI)l1[i].GBJFNGCDKPM;
					data.CGKPIIFCCLD_OfferType = (BOPFPIHGJMD.ADMNKELOLPN)l1[i].CECKOCLEABH;
					data.CIEOBFIIPLD_Level = l1[i].GOKJLBDJOLA;
					data.NBLBJCLIDNN_MaxLevel = l1[i].GOKJLBDJOLA;
					data.NBHEBLNHOJO = false;
					data.AHHJLDLAPAN = 0;
					data.BIEGNEGKLDE_SpItemId = l1[i].BBMBLOABEOK;
					for(int j = 0; j < l1[i].AGMPIKBJPPB(); j++)
					{
						data.AHNKDJLBLNM.Add(l1[i].GNLAKGANAPG_GetId(j));
						data.PCPPHNINBBC.Add(l1[i].FALLJIODMBC_GetCount(j));
					}
					data.KPFHAMNOIAG = 5;
					data.HBJEDMOMAEE_SpOfferType = 0;
					data.JGAMLEMMJCJ_ClearTime = l1[i].AIIOIKGMOBD * 60;
					data.IMPNNOLLMBK = (int)data.JGAMLEMMJCJ_ClearTime;
					data.OHOGIHMFEIJ = l1[i].LJNAKDMILMC > 0;
					KJODFBIBFFO(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, ref data, l1[i].GBJFNGCDKPM, l1[i].PPFNGGCBJKC, JHNMKKNEENE);
					res.Add(data);
				}
				return OEMBGNHHONF(res, KDHGBOOECKC.HHCJCDFCLOB.LBKNBKPBAPJ_IsSortDesc());
			}
		}
		return res;
	}

	//// RVA: 0x1744144 Offset: 0x1744144 VA: 0x1744144
	public List<AAOPGOGGMID> GCHFJGGNEAM(long JHNMKKNEENE)
	{
		List<AAOPGOGGMID> res = new List<AAOPGOGGMID>();
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
		{
			if(KDHGBOOECKC.HHCJCDFCLOB != null)
			{
				List<LGHIPHEDCNC_Offer.BFEIHCJHHAJ> l = KDHGBOOECKC.HHCJCDFCLOB.NHHLDEPNCNG(JHNMKKNEENE);
				for(int i = 0; i < l.Count; i++)
				{
					AAOPGOGGMID data = new AAOPGOGGMID();
					data.PPFNGGCBJKC = l[i].PPFNGGCBJKC;
					data.IJOLPDKFLPO_OfferName = KDHGBOOECKC.HHCJCDFCLOB.GEGAJLNPMEC((BOPFPIHGJMD.MLBMHDCCGHI)l[i].GBJFNGCDKPM, l[i].PPFNGGCBJKC);
					data.DFMOGBOPLEF_Series = KDHGBOOECKC.HHCJCDFCLOB.MDNPDBIPKLB((BOPFPIHGJMD.AHIOHONIGDH)l[i].CPKMLLNADLJ, 0);
					data.KINFGHHNFCF = l[i].FCBJFKGDINH;
					data.NONBCCLGBAO = l[i].NONBCCLGBAO;
					data.FGHGMHPNEMG_Category = (BOPFPIHGJMD.MLBMHDCCGHI)l[i].GBJFNGCDKPM;
					data.CGKPIIFCCLD_OfferType = (BOPFPIHGJMD.ADMNKELOLPN)l[i].CECKOCLEABH;
					data.CIEOBFIIPLD_Level = l[i].GOKJLBDJOLA;
					data.NBLBJCLIDNN_MaxLevel = l[i].GOKJLBDJOLA;
					data.NBHEBLNHOJO = false;
					data.AHHJLDLAPAN = 0;
					data.BIEGNEGKLDE_SpItemId = l[i].BBMBLOABEOK;
					for(int j = 0; j < l[i].AGMPIKBJPPB(); j++)
					{
						data.AHNKDJLBLNM.Add(l[i].GNLAKGANAPG_GetId(j));
						data.PCPPHNINBBC.Add(l[i].FALLJIODMBC_GetCount(j));
					}
					data.JGAMLEMMJCJ_ClearTime = l[i].AIIOIKGMOBD * 60;
					data.KPFHAMNOIAG = 5;
					data.HBJEDMOMAEE_SpOfferType = BOPFPIHGJMD.HDHDOOLPBEO.HJNNKCMLGFL_0;
					data.IMPNNOLLMBK = (int)data.JGAMLEMMJCJ_ClearTime;
					data.OHOGIHMFEIJ = l[i].LJNAKDMILMC > 0;
					KJODFBIBFFO(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, ref data, l[i].GBJFNGCDKPM, l[i].PPFNGGCBJKC, JHNMKKNEENE);
					res.Add(data);
				}
				res = OEMBGNHHONF(res, KDHGBOOECKC.HHCJCDFCLOB.LBKNBKPBAPJ_IsSortDesc());
			}
		}
		return res;
	}

	//// RVA: 0x1744750 Offset: 0x1744750 VA: 0x1744750
	public List<AAOPGOGGMID> CICAACFCNDC(long JHNMKKNEENE)
	{
		List<AAOPGOGGMID> res = new List<AAOPGOGGMID>();
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
			{
				if(KDHGBOOECKC.HHCJCDFCLOB != null)
				{
					List<LGHIPHEDCNC_Offer.PDLENIHAMBC>  l = KDHGBOOECKC.HHCJCDFCLOB.OGIKEILKDEA();
					for(int i = 0; i < l.Count; i++)
					{
						AAOPGOGGMID data = new AAOPGOGGMID();
						data.PPFNGGCBJKC = l[i].PPFNGGCBJKC;
						data.IJOLPDKFLPO_OfferName = KDHGBOOECKC.HHCJCDFCLOB.GEGAJLNPMEC((BOPFPIHGJMD.MLBMHDCCGHI)l[i].GBJFNGCDKPM, l[i].PPFNGGCBJKC);
						data.KINFGHHNFCF = l[i].FCBJFKGDINH;
						data.NONBCCLGBAO = l[i].NONBCCLGBAO;
						data.FGHGMHPNEMG_Category = (BOPFPIHGJMD.MLBMHDCCGHI)l[i].GBJFNGCDKPM;
						data.CGKPIIFCCLD_OfferType = (BOPFPIHGJMD.ADMNKELOLPN)l[i].CECKOCLEABH;
						data.CIEOBFIIPLD_Level = l[i].GOKJLBDJOLA;
						data.NBLBJCLIDNN_MaxLevel = KDHGBOOECKC.HHCJCDFCLOB.HFLNFKFGEJH(l[i].OCAMDLMPBGA);
						data.NBHEBLNHOJO = data.NBLBJCLIDNN_MaxLevel <= data.CIEOBFIIPLD_Level;
						data.AHHJLDLAPAN = l[i].OCAMDLMPBGA;
						data.DFMOGBOPLEF_Series = KDHGBOOECKC.HHCJCDFCLOB.MDNPDBIPKLB((BOPFPIHGJMD.AHIOHONIGDH)l[i].CPKMLLNADLJ, 0);
						data.BIEGNEGKLDE_SpItemId = l[i].BBMBLOABEOK;
						for(int j = 0; j < l[i].AGMPIKBJPPB(); j++)
						{
							data.AHNKDJLBLNM.Add(l[i].GNLAKGANAPG_GetId(j));
							data.PCPPHNINBBC.Add(l[i].FALLJIODMBC_GetCount(j));
						}
						data.JGAMLEMMJCJ_ClearTime = l[i].AIIOIKGMOBD * 60;
						data.KPFHAMNOIAG = 5;
						data.HBJEDMOMAEE_SpOfferType = BOPFPIHGJMD.HDHDOOLPBEO.HJNNKCMLGFL_0;
						data.IMPNNOLLMBK = (int)data.JGAMLEMMJCJ_ClearTime;
						data.OHOGIHMFEIJ = l[i].LJNAKDMILMC > 0;
						KJODFBIBFFO(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, ref data, l[i].GBJFNGCDKPM, l[i].PPFNGGCBJKC, JHNMKKNEENE);
						res.Add(data);
					}
					res = OEMBGNHHONF(res, KDHGBOOECKC.HHCJCDFCLOB.LBKNBKPBAPJ_IsSortDesc());
				}
			}
		}
		return res;
	}

	//// RVA: 0x1744DCC Offset: 0x1744DCC VA: 0x1744DCC
	public List<AAOPGOGGMID> JNJOOCCFBLF(long JHNMKKNEENE)
	{
		List<AAOPGOGGMID> res = new List<AAOPGOGGMID>();
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null && KDHGBOOECKC.HHCJCDFCLOB != null)
		{
			List<LGHIPHEDCNC_Offer.FCOBCHHKMOA> l = KDHGBOOECKC.HHCJCDFCLOB.DNNAPBIGHJI();
			for(int i = 0; i < l.Count; i++)
			{
				AAOPGOGGMID data = new AAOPGOGGMID();
				data.PPFNGGCBJKC = l[i].PPFNGGCBJKC;
				data.IJOLPDKFLPO_OfferName = KDHGBOOECKC.HHCJCDFCLOB.GEGAJLNPMEC((BOPFPIHGJMD.MLBMHDCCGHI)l[i].GBJFNGCDKPM, l[i].PPFNGGCBJKC);
				data.DFMOGBOPLEF_Series = KDHGBOOECKC.HHCJCDFCLOB.MDNPDBIPKLB((BOPFPIHGJMD.AHIOHONIGDH)l[i].CPKMLLNADLJ, 0);
				data.KINFGHHNFCF = l[i].FCBJFKGDINH;
				data.NONBCCLGBAO = l[i].NONBCCLGBAO;
				data.FGHGMHPNEMG_Category = (BOPFPIHGJMD.MLBMHDCCGHI)l[i].GBJFNGCDKPM;
				data.CGKPIIFCCLD_OfferType = (BOPFPIHGJMD.ADMNKELOLPN)l[i].CECKOCLEABH;
				data.CIEOBFIIPLD_Level = l[i].GOKJLBDJOLA;
				data.NBLBJCLIDNN_MaxLevel = l[i].GOKJLBDJOLA;
				data.NBHEBLNHOJO = false;
				data.AHHJLDLAPAN = 0;
				data.BIEGNEGKLDE_SpItemId = l[i].BBMBLOABEOK;
				for(int j = 0; j < l[i].AGMPIKBJPPB(); j++)
				{
					data.AHNKDJLBLNM.Add(l[i].GNLAKGANAPG_GetId(j));
					data.PCPPHNINBBC.Add(l[i].FALLJIODMBC_GetCount(j));
				}
				data.JGAMLEMMJCJ_ClearTime = l[i].AIIOIKGMOBD * 60;
				data.KPFHAMNOIAG = 5;
				data.HBJEDMOMAEE_SpOfferType = BOPFPIHGJMD.HDHDOOLPBEO.HJNNKCMLGFL_0;
				data.IMPNNOLLMBK = (int)data.JGAMLEMMJCJ_ClearTime;
				data.OHOGIHMFEIJ = l[i].LJNAKDMILMC > 0;
				KJODFBIBFFO(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, ref data, l[i].GBJFNGCDKPM, l[i].PPFNGGCBJKC, JHNMKKNEENE);
				res.Add(data);
			}
			res = OEMBGNHHONF(res, KDHGBOOECKC.HHCJCDFCLOB.LBKNBKPBAPJ_IsSortDesc());
		}
		return res;
	}

	//// RVA: 0x17460DC Offset: 0x17460DC VA: 0x17460DC
	public void CFMHAGBNNKA()
	{
		MDNHCIKGEAE = AANFIKBAJPI_GetValkyrieList();
	}

	//// RVA: 0x17460F4 Offset: 0x17460F4 VA: 0x17460F4
	public List<ANKPCIEKPAH> AANFIKBAJPI_GetValkyrieList()
	{
		List<ANKPCIEKPAH> res = new List<ANKPCIEKPAH>();
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				List<OIGEIIGKMNH_Valkyrie.HLNPGNNPCGO_ValkyrieInfo> vList = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JJFFBDLIOCF_Valkyrie.CNGNBKNBKGI_ValkList;
				MessageBank bk = MessageManager.Instance.GetBank("master");
				for(int i = 0; i < vList.Count; i++)
				{
					if(vList[i].FODKKJIDDKN_Id > 0)
					{
						JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo dbValk = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList[vList[i].FODKKJIDDKN_Id - 1];
						if(dbValk.PPEGAKEIEGM_Enabled == 2)
						{
							if(vList[i].FJODMPGPDDD)
							{
								if(vList[i].FODKKJIDDKN_Id == dbValk.GPPEFLKGGGJ_Id)
								{
									ANKPCIEKPAH data = new ANKPCIEKPAH();
									data.LLOBHDMHJIG_Id = vList[i].FODKKJIDDKN_Id;
									data.LABKKJAGDFN_FormationId = LHFJMGDOBEK(data.LLOBHDMHJIG_Id);
									data.KINFGHHNFCF_Atk = dbValk.KINFGHHNFCF;
									data.NONBCCLGBAO_Hit = dbValk.NONBCCLGBAO;
									data.JMHKMDFNAIN = NAEMOCCOGAA(data.LABKKJAGDFN_FormationId, data.LLOBHDMHJIG_Id);
									data.CPKMLLNADLJ_Attr = (SeriesAttr.Type)dbValk.AIHCEGFANAM_Sa;
									data.PFGJJLGLPAC_PilotId = dbValk.PFGJJLGLPAC_PilotId;
									data.PMKFOEIFBLB_PilotName = bk.GetMessageByLabel("plt_nm_" + data.PFGJJLGLPAC_PilotId.ToString("D4"));
									data.PNIEAEHKGMJ_ValkName = bk.GetMessageByLabel("vn_" + data.LLOBHDMHJIG_Id.ToString("D4"));
									data.CNLIAMIIJID_Level = vList[i].CIEOBFIIPLD_Level;
									data.LPDDOLAIODN = false;
									data.HOJHKJBBOLM = 0;
									data.CKJPPJHNBBN = 0;
									data.KFFEFIPMOLD = 0;
									res.Add(data);
								}
							}
						}
					}
				}
			}
		}
		return res;
	}

	//// RVA: 0x1746A04 Offset: 0x1746A04 VA: 0x1746A04
	public List<ANKPCIEKPAH> PMFIOHGEPPD(int PPFNGGCBJKC, bool LIFPCFFJEOA = false)
	{
		List<ANKPCIEKPAH> res = new List<ANKPCIEKPAH>();
		if (LIFPCFFJEOA)
			MDNHCIKGEAE = AANFIKBAJPI_GetValkyrieList();
		for(int i = 0; i < MDNHCIKGEAE.Count; i++)
		{
			if (MDNHCIKGEAE[i].LABKKJAGDFN_FormationId == PPFNGGCBJKC)
				res.Add(MDNHCIKGEAE[i]);
		}
		if(res.Count < 3)
		{
			int missing = 3 - res.Count;
			for (int i = 0; i < missing; i++)
			{
				ANKPCIEKPAH data = new ANKPCIEKPAH();
				int a = AIJJCLLJOKH(res);
				if (a < 0)
					break;
				JBHBEKJHLFE(PPFNGGCBJKC, a, 0);
				data.JMHKMDFNAIN = a;
				data.LLOBHDMHJIG_Id = 0;
				res.Add(data);
			}
		}
		for(int i = 0; i < res.Count; i++)
		{
			NHDJHOPLMDE n = new NHDJHOPLMDE(res[i].LLOBHDMHJIG_Id, res[i].CNLIAMIIJID_Level);
			res[i].LPDDOLAIODN = n.LAKLFHGMCLI(EPIFHEDDJAE.NGEDJNHECKN.FJFMLFPJKNB_2, i == 0 ? EPIFHEDDJAE.JFEIHHBGFPF_AbilityCondition.FHBJEIEPABF_12 : EPIFHEDDJAE.JFEIHHBGFPF_AbilityCondition.PPNNBADDNKB_11);
			if (res[i].LPDDOLAIODN)
			{
				res[i].HOJHKJBBOLM = n.KINFGHHNFCF_Atk;
				res[i].CKJPPJHNBBN = n.NONBCCLGBAO_Hit;
				res[i].KFFEFIPMOLD = n.EHMLAAHLNMN;
			}
		}
		return res;
	}

	//// RVA: 0x1746E08 Offset: 0x1746E08 VA: 0x1746E08
	private int AIJJCLLJOKH(List<ANKPCIEKPAH> NNDGIAEFMOG)
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
		{
			int res = -1;
			for(int i = 0; i < 3; i++)
			{
				ANKPCIEKPAH d = NNDGIAEFMOG.Find((ANKPCIEKPAH HHKBDDNBEAA) =>
				{
					//0x1747F04
					return HHKBDDNBEAA.JMHKMDFNAIN == i;
				});
				if (d == null)
					res = i;
			}
			return res;
		}
		return -1;
	}

	//// RVA: 0x1746708 Offset: 0x1746708 VA: 0x1746708
	public int LHFJMGDOBEK(int FODKKJIDDKN)
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
		{
			for(int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.NEGDGHKOFFF_VFplatoon.Count; i++)
			{
				for(int j = 0; j < 3; j++)
				{
					if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.NEGDGHKOFFF_VFplatoon[i].LBCCCKNANMJ_GetValkyrieId(j) == FODKKJIDDKN)
						return i + 1;
				}
			}
		}
		return 0;
	}

	//// RVA: 0x174689C Offset: 0x174689C VA: 0x174689C
	public int NAEMOCCOGAA(int PPFNGGCBJKC, int FODKKJIDDKN)
	{
		if(PPFNGGCBJKC > 0 && PPFNGGCBJKC <= 5)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
			{
				OCMJNBIFJNM_Offer.PMOECIDOLNA d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.NEGDGHKOFFF_VFplatoon[PPFNGGCBJKC - 1];
				for (int j = 0; j < 3; j++)
				{
					if (d.LBCCCKNANMJ_GetValkyrieId(j) == FODKKJIDDKN)
						return j;
				}
			}
		}
		return -1;
	}

	//// RVA: 0x1746FC0 Offset: 0x1746FC0 VA: 0x1746FC0
	public bool JBHBEKJHLFE(int PPFNGGCBJKC, int ADPPAIPFHML, int FODKKJIDDKN)
	{
		if(PPFNGGCBJKC > 0 && PPFNGGCBJKC <= 5 && FODKKJIDDKN > -1)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
			{
				int a = LHFJMGDOBEK(FODKKJIDDKN);
				if(a > 0)
				{
					int a2 = NAEMOCCOGAA(a, FODKKJIDDKN);
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.NEGDGHKOFFF_VFplatoon[a - 1].ODGFPJFJPFP(a2, 0);
				}
				return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.NEGDGHKOFFF_VFplatoon[PPFNGGCBJKC - 1].ODGFPJFJPFP(ADPPAIPFHML, FODKKJIDDKN);
			}
		}
		return false;
	}

	//// RVA: 0x174718C Offset: 0x174718C VA: 0x174718C
	public string NPMKEEANPBE(int PPFNGGCBJKC)
	{
		if(PPFNGGCBJKC > 0)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
			{
				List<OCMJNBIFJNM_Offer.PMOECIDOLNA> l = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.NEGDGHKOFFF_VFplatoon;
				return l[PPFNGGCBJKC - 1].OPFGFINHFCE_Name;
			}
		}
		return "";
	}

	//// RVA: 0x17472D8 Offset: 0x17472D8 VA: 0x17472D8
	public bool PFEMFIICBCE(int PPFNGGCBJKC, string OPFGFINHFCE)
	{
		if(PPFNGGCBJKC > 0)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
			{
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.NEGDGHKOFFF_VFplatoon[PPFNGGCBJKC - 1].OPFGFINHFCE_Name = OPFGFINHFCE;
			}
		}
		return false;
	}

	//// RVA: 0x174741C Offset: 0x174741C VA: 0x174741C
	public bool NAIBONEPAOJ(int OIOECMEEFKJ)
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null && KDHGBOOECKC.HHCJCDFCLOB != null && OIOECMEEFKJ > 0)
		{
			if (KDHGBOOECKC.HHCJCDFCLOB.NBIJDMOOILH() == null)
				KDHGBOOECKC.HHCJCDFCLOB.BJIPLMJFAGH();
			List<KDHGBOOECKC.NOCAJFGHDPC> l = KDHGBOOECKC.HHCJCDFCLOB.NBIJDMOOILH();
			for(int i = 0; i < l.Count; i++)
			{
				OCMJNBIFJNM_Offer.JPOHOLBBFGP of = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.FOFLMHELILC[l[i].OIPCCBHIKIA_Index];
				if(of.EALOBDHOCHP_Stat == 2 || of.EALOBDHOCHP_Stat == 3)
				{
					if (of.OIOECMEEFKJ_VFp == OIOECMEEFKJ)
						return true;
				}
			}
		}
		return false;
	}

	//// RVA: 0x1747664 Offset: 0x1747664 VA: 0x1747664
	public bool JHBMCGABHMD(int FODKKJIDDKN)
	{
		int a = LHFJMGDOBEK(FODKKJIDDKN);
		if (a > 0)
		{
			return NAIBONEPAOJ(a);
		}
		return false;
	}

	//// RVA: 0x1747688 Offset: 0x1747688 VA: 0x1747688
	public List<int> LOEDABGEMFJ(int CPKMLLNADLJ)
	{
		List<int> res = new List<int>();
		if (MDNHCIKGEAE == null)
			MDNHCIKGEAE = AANFIKBAJPI_GetValkyrieList();
		for(int i = 0; i < MDNHCIKGEAE.Count; i++)
		{
			if((int)MDNHCIKGEAE[i].CPKMLLNADLJ_Attr == CPKMLLNADLJ)
			{
				if(!JHBMCGABHMD(MDNHCIKGEAE[i].LLOBHDMHJIG_Id))
				{
					res.Add(MDNHCIKGEAE[i].LLOBHDMHJIG_Id);
				}
			}
		}
		return res;
	}

	//// RVA: 0x174784C Offset: 0x174784C VA: 0x174784C
	public int LLMEKDNIOEF(BOPFPIHGJMD.MLBMHDCCGHI FGHGMHPNEMG, int MLDPDLPHJPM)
	{
		if(KDHGBOOECKC.HHCJCDFCLOB != null)
		{
			List<KDHGBOOECKC.NOCAJFGHDPC> l = KDHGBOOECKC.HHCJCDFCLOB.NBIJDMOOILH();
			if (l == null)
				KDHGBOOECKC.HHCJCDFCLOB.BJIPLMJFAGH();
			OCMJNBIFJNM_Offer.JPOHOLBBFGP of = KDHGBOOECKC.HHCJCDFCLOB.BKJJKHIBIGP(FGHGMHPNEMG, MLDPDLPHJPM);
			if (of != null)
				return of.OIOECMEEFKJ_VFp;
		}
		return 0;
	}

	//// RVA: 0x17478C0 Offset: 0x17478C0 VA: 0x17478C0
	public ANKPCIEKPAH FFGHIOAOABE(int PPFNGGCBJKC)
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
		{
			List<ANKPCIEKPAH> l = PMFIOHGEPPD(PPFNGGCBJKC, true);
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i].JMHKMDFNAIN == 0)
				{
					return l[i];
				}
			}
		}
		return null;
	}

	// RVA: 0x1747A48 Offset: 0x1747A48 VA: 0x1747A48
	public int NCAPNMMJCLF()
	{
		int res = 0;
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
		{
			if(KDHGBOOECKC.HHCJCDFCLOB != null)
			{
				List<KDHGBOOECKC.NOCAJFGHDPC> l1 = KDHGBOOECKC.HHCJCDFCLOB.NBIJDMOOILH();
				List<OCMJNBIFJNM_Offer.JPOHOLBBFGP> l2 = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.FOFLMHELILC;
				for(int i = 0; i < l1.Count; i++)
				{
					OCMJNBIFJNM_Offer.JPOHOLBBFGP save = l2[l1[i].OIPCCBHIKIA_Index];
					if(save.EALOBDHOCHP_Stat == 2 || save.EALOBDHOCHP_Stat == 3)
					{
						if (save.OIOECMEEFKJ_VFp > 0)
							res++;
					}
				}
			}
		}
		return res;
	}

	// RVA: 0x1747C58 Offset: 0x1747C58 VA: 0x1747C58
	public int JGFHJPGJJHP()
	{
		if (KDHGBOOECKC.HHCJCDFCLOB != null)
			return KDHGBOOECKC.HHCJCDFCLOB.JGFHJPGJJHP();
		return 0;
	}

	//// RVA: 0x1747C80 Offset: 0x1747C80 VA: 0x1747C80
	//public string OMPLNLDPOFN(int OIOECMEEFKJ) { }

	// RVA: 0x1747D00 Offset: 0x1747D00 VA: 0x1747D00
	public string BEGJBMHBGPL()
	{
		if(KDHGBOOECKC.HHCJCDFCLOB != null)
		{
			string str = KDHGBOOECKC.HHCJCDFCLOB.JIMBMBEEMHI();
			KDHGBOOECKC.HHCJCDFCLOB.PANKGNBPFEL(BOPFPIHGJMD.GNGGLPCONLM.HJNNKCMLGFL_0);
			KDHGBOOECKC.HHCJCDFCLOB.BFJFAIIAMMO(BOPFPIHGJMD.FDDGIANLNAD.DMHGLBIOLLL_2, true);
			return str;
		}
		return "";
	}

	// RVA: 0x1747DA4 Offset: 0x1747DA4 VA: 0x1747DA4
	public bool OHILPCDFKCH()
	{
		if (KDHGBOOECKC.HHCJCDFCLOB != null)
			return KDHGBOOECKC.HHCJCDFCLOB.OHILPCDFKCH();
		return false;
	}

	//// RVA: 0x1747DCC Offset: 0x1747DCC VA: 0x1747DCC
	//public int ECBHIIOABCK() { }

	//// RVA: 0x1747DF4 Offset: 0x1747DF4 VA: 0x1747DF4
	//public int PDGOLEJBNMM(BOPFPIHGJMD.IGHPDAGKIKO CMCKNKKCNDK) { }
}
