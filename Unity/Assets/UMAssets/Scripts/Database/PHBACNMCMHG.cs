
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use PHBACNMCMHG_EventCollection", true)]
public class PHBACNMCMHG { }
public class PHBACNMCMHG_EventCollection : DIHHCBACKGG_DbSection
{
	public class IHCDILMMOJM
	{
		public int OBGBAOLONDD_EventId; // 0x8
		public string OPFGFINHFCE_Name; // 0xC
		public string HEDAGCNPHGD; // 0x10
		public string IDGAEEJLGIK; // 0x14
		public string OCGFKMHNEOF; // 0x18
		public string OGMGLOFKKPA; // 0x1C
		public string FEMMDNIELFC_MusicSelectDesc; // 0x20
		public long BONDDBOFBND_Start; // 0x28
		public long EHHFFKAFOMC; // 0x30
		public long HPNOGLIFJOP_End1; // 0x38
		public long LNFKGHNHJKE; // 0x40
		public long JGMDAOACOJF; // 0x48
		public long IDDBFFBPNGI; // 0x50
		public long KNLGKBBIBOH_End; // 0x58
		public long JBFDHOIKAIK_InventoryEndDate; // 0x60
		public int KHIKEGLBGAF; // 0x68
		public int DPJCFLKFEPN; // 0x6C
		public int MJBKGOJBPAD_TicketType; // 0x70
		public sbyte POGEFBMBPCB; // 0x74
		public sbyte AHKNMANFILO; // 0x75
		public sbyte MOEKELIIDEO_SaveIdx; // 0x76
		public string OMCAOJJGOGG; // 0x78
		public int EKJFNHHKBPL; // 0x7C
		private NNJFKLBPBNK_SecureString EBGIDCIIGDO = new NNJFKLBPBNK_SecureString(); // 0x80
		private NNJFKLBPBNK_SecureString NJKIMJAFCPC = new NNJFKLBPBNK_SecureString(); // 0x84
		public sbyte MPKNCMEAMLO; // 0x88
		public sbyte AHKPNPNOAMO; // 0x89
		public sbyte HKKNEAGCIEB; // 0x8A
		public List<int> CAPAPAABKDP = new List<int>(); // 0x8C
		public List<int> HKEAFPNNAPC = new List<int>(); // 0x90
		public List<int> MCDPPHKEMJI = new List<int>(); // 0x94
		public List<int> BJHHDGCOACI = new List<int>(); // 0x98
		public List<int> JDDIOIMOFDE = new List<int>(); // 0x9C
		private List<int> DMDHPBNAPKI = new List<int>(); // 0xA0
		private List<int> HOJFGDGNBCF = new List<int>(); // 0xA4
		public List<int> JHPCPNJJHLI = new List<int>(); // 0xA8
		public int HIOOGLEJBKM_StartAdventureId; // 0xAC
		public int FJCADCDNPMP_EndAdventureId; // 0xB0
		public int[] EJBGHLOOLBC_HelpIds; // 0xB4
		public List<int> EEOGPJJCKHH_Drops = new List<int>(); // 0xB8

		public string OCDMGOGMHGE_RewardPrefix { get { return EBGIDCIIGDO.DNJEJEANJGL_Value; } set { EBGIDCIIGDO.DNJEJEANJGL_Value = value; } } //0x16CF088 HBAAAKFHDBB 0x16CD898 NHJLJOIPOFK
		public string PJBILOFOCIC { get { return NJKIMJAFCPC.DNJEJEANJGL_Value; } set { NJKIMJAFCPC.DNJEJEANJGL_Value = value; } } //0x16CF0B4 NOEFEAIFHCL 0x16CD8CC GJIJFGNONEL

		//// RVA: 0x16CDA9C Offset: 0x16CDA9C VA: 0x16CDA9C
		public void LLMCLICMLLG(int NANNGLGOFKH)
		{
			DMDHPBNAPKI.Add(NANNGLGOFKH);
		}

		//// RVA: 0x16CDB1C Offset: 0x16CDB1C VA: 0x16CDB1C
		public void DJBHHJEJPFK(int NANNGLGOFKH)
		{
			HOJFGDGNBCF.Add(NANNGLGOFKH);
		}

		//// RVA: 0x16CF0E0 Offset: 0x16CF0E0 VA: 0x16CF0E0
		public int KIGCDOJGJEP(int AKNELONELJK, bool GIKLNODJKFK)
		{
			if(GIKLNODJKFK)
				return HOJFGDGNBCF[AKNELONELJK];
			else
				return DMDHPBNAPKI[AKNELONELJK];
		}

		//// RVA: 0x16CB724 Offset: 0x16CB724 VA: 0x16CB724
		public void LHPDDGIJKNB()
		{
			OBGBAOLONDD_EventId = 0;
			JGMDAOACOJF = 0;
			IDDBFFBPNGI = 0;
			JBFDHOIKAIK_InventoryEndDate = 0;
			KHIKEGLBGAF = 0;
			DPJCFLKFEPN = 0;
			BONDDBOFBND_Start = 0;
			EHHFFKAFOMC = 0;
			HPNOGLIFJOP_End1 = 0;
			OGMGLOFKKPA = "";
			FEMMDNIELFC_MusicSelectDesc = "";
			POGEFBMBPCB = 0;
			AHKNMANFILO = 0;
			MOEKELIIDEO_SaveIdx = 0;
			MJBKGOJBPAD_TicketType = 1;
			EKJFNHHKBPL = 0;
			OPFGFINHFCE_Name = null;
			HEDAGCNPHGD = null;
			IDGAEEJLGIK = null;
			OCGFKMHNEOF = null;
			OCDMGOGMHGE_RewardPrefix = "";
			PJBILOFOCIC = "";
			MPKNCMEAMLO = 0;
			CAPAPAABKDP.Clear();
			HKEAFPNNAPC.Clear();
			MCDPPHKEMJI.Clear();
			BJHHDGCOACI.Clear();
			JDDIOIMOFDE.Clear();
			DMDHPBNAPKI.Clear();
			HOJFGDGNBCF.Clear();
			JHPCPNJJHLI.Clear();
			HKKNEAGCIEB = 0;
			EEOGPJJCKHH_Drops.Clear();
			OMCAOJJGOGG = "";
			HIOOGLEJBKM_StartAdventureId = 0;
			FJCADCDNPMP_EndAdventureId = 0;
			EJBGHLOOLBC_HelpIds = null;
		}

		//// RVA: 0x16CE8DC Offset: 0x16CE8DC VA: 0x16CE8DC
		//public uint CAOGDCBPBAN() { }
	}

	public class ALBKHBLGHHN
	{
		public int FBGGEFFJJHB; // 0x8
		private int EHOIENNDEDH_Crypted; // 0xC
		private int FMDDJNKEBBB_Crypted; // 0x10
		private int MDKGAAMBJDJ_Crypted; // 0x14
		private int GGEBNMPPEID_Crypted; // 0x18

		public int PPFNGGCBJKC { get { return EHOIENNDEDH_Crypted ^ FBGGEFFJJHB; } set { EHOIENNDEDH_Crypted = value ^ FBGGEFFJJHB; } } //0x16CEFAC DEMEPMAEJOO 0x16CEFBC HIGKAIDMOKN
		public int CNKFPJCGNFE_SceneId { get { return FMDDJNKEBBB_Crypted ^ FBGGEFFJJHB; } set { FMDDJNKEBBB_Crypted = value ^ FBGGEFFJJHB; } } //0x16CEFCC GJBOGOFHGNP 0x16CEFDC GJDGIDCMJMH
		public int GNFBMCGMCFO_BonusBefore { get { return MDKGAAMBJDJ_Crypted ^ FBGGEFFJJHB; } set { MDKGAAMBJDJ_Crypted = value ^ FBGGEFFJJHB; } } //0x16CEFEC NCIMMDJLPLJ 0x16CEFFC HNAJAFBHOLM
		public int BFFGFAMJAIG_BonusAfter { get { return GGEBNMPPEID_Crypted ^ FBGGEFFJJHB; } set { GGEBNMPPEID_Crypted = value ^ FBGGEFFJJHB; } } //0x16CF00C PKMNOMELPMN 0x16CF01C IABBJBAHKCE

		//// RVA: 0x16CEEB8 Offset: 0x16CEEB8 VA: 0x16CEEB8
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x16CE020 Offset: 0x16CE020 VA: 0x16CE020
		public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, HMNJADGBKFA JMHECKKKMLK)
		{
			FBGGEFFJJHB = KNEFBLHBDBG;
			PPFNGGCBJKC = 0;
			CNKFPJCGNFE_SceneId = 0;
			GNFBMCGMCFO_BonusBefore = 0;
			BFFGFAMJAIG_BonusAfter = 0;
			KPFPLABANJG data = JMHECKKKMLK.OLACFKILCFD[JBGJDEELLOP];
			PPFNGGCBJKC = data.PPFNGGCBJKC;
			CNKFPJCGNFE_SceneId = data.CNKFPJCGNFE;
			GNFBMCGMCFO_BonusBefore = data.GNFBMCGMCFO;
			BFFGFAMJAIG_BonusAfter = data.BFFGFAMJAIG;
		}

		//// RVA: 0x16CF02C Offset: 0x16CF02C VA: 0x16CF02C
		//public void LHPDDGIJKNB(int KNEFBLHBDBG) { }
	}

	public class MAPOMNOALHJ
	{
		public int FBGGEFFJJHB; // 0x8
		private int EHOIENNDEDH_Crypted; // 0xC
		private int MDKGAAMBJDJ_Crypted; // 0x10
		private int GGEBNMPPEID_Crypted; // 0x14

		public int PPFNGGCBJKC { get { return EHOIENNDEDH_Crypted ^ FBGGEFFJJHB; } set { EHOIENNDEDH_Crypted = value ^ FBGGEFFJJHB; } } //0x16CF408 DEMEPMAEJOO 0x16CF418 HIGKAIDMOKN
		public int GNFBMCGMCFO_BonusBefore { get { return MDKGAAMBJDJ_Crypted ^ FBGGEFFJJHB; } set { MDKGAAMBJDJ_Crypted = value ^ FBGGEFFJJHB; } } //0x16CF428 NCIMMDJLPLJ 0x16CF438 HNAJAFBHOLM
		public int BFFGFAMJAIG_BonusAfter { get { return GGEBNMPPEID_Crypted ^ FBGGEFFJJHB; } set { GGEBNMPPEID_Crypted = value ^ FBGGEFFJJHB; } } //0x16CF448 PKMNOMELPMN 0x16CF458 IABBJBAHKCE

		//// RVA: 0x16CEE94 Offset: 0x16CEE94 VA: 0x16CEE94
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x16CE16C Offset: 0x16CE16C VA: 0x16CE16C
		public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, HMNJADGBKFA JMHECKKKMLK)
		{
			FBGGEFFJJHB = KNEFBLHBDBG;
			PPFNGGCBJKC = 0;
			GNFBMCGMCFO_BonusBefore = 0;
			BFFGFAMJAIG_BonusAfter = 0;
			CNFAHCDJNKD data = JMHECKKKMLK.MIOCOKLMLBD[JBGJDEELLOP];
			PPFNGGCBJKC = data.PPFNGGCBJKC;
			GNFBMCGMCFO_BonusBefore = data.GNFBMCGMCFO;
			BFFGFAMJAIG_BonusAfter = data.BFFGFAMJAIG;
		}

		//// RVA: 0x16CF468 Offset: 0x16CF468 VA: 0x16CF468
		//public void LHPDDGIJKNB(int KNEFBLHBDBG) { }
	}

	public class ABGNMIEBCDN
	{
		public int FBGGEFFJJHB; // 0x8
		private int HHEEHHHLKHC_Crypted; // 0xC
		private int LGAIHLFAPDC_Crypted; // 0x10
		public List<int> KDNMBOBEGJM = new List<int>(); // 0x14

		public int KHPHAAMGMJP_Id { get { return HHEEHHHLKHC_Crypted ^ FBGGEFFJJHB; } set { HHEEHHHLKHC_Crypted = value ^ FBGGEFFJJHB; } } //0x16CEEE4 ABFDDKBBPCH 0x16CEEF4 MHDOIIEMDEH
		public int OFIAENKCJME_BaseBonus { get { return LGAIHLFAPDC_Crypted ^ FBGGEFFJJHB; } set { LGAIHLFAPDC_Crypted = value ^ FBGGEFFJJHB; } } //0x16CEF04 KADLAKFANGA 0x16CEF14 AIDAPNCEPOB

		//// RVA: 0x16CEDBC Offset: 0x16CEDBC VA: 0x16CEDBC
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x16CE2FC Offset: 0x16CE2FC VA: 0x16CE2FC
		public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, HMNJADGBKFA JMHECKKKMLK)
		{
			LHPDDGIJKNB(KNEFBLHBDBG);
			CFFKBKJMNNN data = JMHECKKKMLK.IEJLJIHIDJC[JBGJDEELLOP];
			KHPHAAMGMJP_Id = data.KHPHAAMGMJP;
			OFIAENKCJME_BaseBonus = data.OFIAENKCJME;
			for(int i = 0; i < data.JMLCLHHLJHM.Length; i++)
			{
				KDNMBOBEGJM.Add(data.JMLCLHHLJHM[i]);
			}
		}

		//// RVA: 0x16CEF24 Offset: 0x16CEF24 VA: 0x16CEF24
		public void LHPDDGIJKNB(int KNEFBLHBDBG)
		{
			FBGGEFFJJHB = KNEFBLHBDBG;
			KHPHAAMGMJP_Id = 0;
			OFIAENKCJME_BaseBonus = 0;
			KDNMBOBEGJM.Clear();
		}
	}

	public class PFGFDNLGPKP
	{
		public int FBGGEFFJJHB = 0x341e805b; // 0x8
		public int AHGCGHAAHOO_Crypted; // 0xC
		public int HLMAFFLCCKD_Crypted; // 0x10
		public int JCCHHFPCACO_Crypted; // 0x14
		public bool JOPPFEHKNFO_IsGold; // 0x18
		private int HJAFPEBIBOP_Cryped; // 0x1C

		public int GLCLFMGPMAN_ItemId { get { return AHGCGHAAHOO_Crypted ^ FBGGEFFJJHB; } set { AHGCGHAAHOO_Crypted = value ^ FBGGEFFJJHB; } } //0x16CF478 LNJAENEGDEL 0x16CDE3C JHIDBGCHOKL
		public int HMFFHLPNMPH_Cnt { get { return HLMAFFLCCKD_Crypted ^ FBGGEFFJJHB; } set { HLMAFFLCCKD_Crypted = value ^ FBGGEFFJJHB; } } //0x16CF488 NJOGDDPICKG 0x16CDE4C NBBGMMBICNA
		public int NMKEOMCMIPP_RewardId { get { return JCCHHFPCACO_Crypted ^ FBGGEFFJJHB; } set { JCCHHFPCACO_Crypted = value ^ FBGGEFFJJHB; } } //0x16CF498 EKDBBLNLMBC 0x16CDE5C LJHKEDCGLPO
		public bool PJPDOCNJNGJ_IsLimited { get { return HJAFPEBIBOP_Cryped == 117; } set { HJAFPEBIBOP_Cryped = value ? 117 : 85; } } //0x16CF4A8 MBEBLALDBHJ 0x16CDE6C ENPODKCLKMC

		//// RVA: 0x16CF060 Offset: 0x16CF060 VA: 0x16CF060
		//public uint CAOGDCBPBAN() { }
	}

	public class GBBANJEDBOP
	{
		public int FBGGEFFJJHB; // 0x8
		public int EHOIENNDEDH_Crypted; // 0xC
		public int AADPAJOLEEF_Crypted; // 0x10
		public bool JOPPFEHKNFO; // 0x14
		public List<PFGFDNLGPKP> AHJNPEAMCCH_Items = new List<PFGFDNLGPKP>(); // 0x18

		public int PPFNGGCBJKC { get { return EHOIENNDEDH_Crypted ^ FBGGEFFJJHB; } set { EHOIENNDEDH_Crypted = value ^ FBGGEFFJJHB; } } //0x16CF040 DEMEPMAEJOO 0x16CDE08 HIGKAIDMOKN
		public int DNBFMLBNAEE_Point { get { return AADPAJOLEEF_Crypted ^ FBGGEFFJJHB; } set { AADPAJOLEEF_Crypted = value ^ FBGGEFFJJHB; } } //0x16CF050 JKHIIAEMMDE 0x16CDE18 PFFKLBLEPKB

		// RVA: 0x16CECAC Offset: 0x16CECAC VA: 0x16CECAC
		//public uint CAOGDCBPBAN() { }
	}

	public class LLFNMNJGLNL
	{
		public int PPFNGGCBJKC_Id; // 0x8
		public int PLALNIIBLOF_Enabled; // 0xC
		public int MPLGPBNJDJB_FMusicId; // 0x10
		public int DKHIHHMOIKM_Bns; // 0x14
		public long PDBPFJJCADD_OpenAt; // 0x18
		public long FDBNFFNFOND_CloseAt; // 0x20

		//// RVA: 0x16CF170 Offset: 0x16CF170 VA: 0x16CF170
		//public void LHPDDGIJKNB(int PPFNGGCBJKC) { }

		//// RVA: 0x16CF18C Offset: 0x16CF18C VA: 0x16CF18C
		//public void KHEKNNFCAOI(int PPFNGGCBJKC, EDOHBJAPLPF IDLHJIOMJBK) { }

		//// RVA: 0x16CDEA4 Offset: 0x16CDEA4 VA: 0x16CDEA4
		public void KHEKNNFCAOI(int PPFNGGCBJKC, HMNJADGBKFA JMHECKKKMLK)
		{
			PPFNGGCBJKC_Id = PPFNGGCBJKC;
			PDBPFJJCADD_OpenAt = 0;
			FDBNFFNFOND_CloseAt = 0;
			PLALNIIBLOF_Enabled = 0;
			MPLGPBNJDJB_FMusicId = 0;
			DKHIHHMOIKM_Bns = 0;
			ENAEMKEKAOE d = JMHECKKKMLK.GHIHAGAOPNC[PPFNGGCBJKC - 1];
			PPFNGGCBJKC_Id = (int)d.PPFNGGCBJKC;
			PLALNIIBLOF_Enabled = (int)d.PLALNIIBLOF;
			MPLGPBNJDJB_FMusicId = (int)d.MPLGPBNJDJB;
			DKHIHHMOIKM_Bns = (int)d.DKHIHHMOIKM;
			PDBPFJJCADD_OpenAt = d.PDBPFJJCADD;
			FDBNFFNFOND_CloseAt = d.FDBNFFNFOND;
		}

		//// RVA: 0x16CF3CC Offset: 0x16CF3CC VA: 0x16CF3CC
		//public uint CAOGDCBPBAN() { }
	}

	public class OLLFEBCLPIL
	{
		public int PPFNGGCBJKC; // 0x8
		public int KFCIJBLDHOK; // 0xC
		public int JLEIHOEGMOP; // 0x10
	}

	public IHCDILMMOJM NGHKJOEDLIP = new IHCDILMMOJM(); // 0x20
	public List<GBBANJEDBOP> FCIPEDFHFEM_RewardStep = new List<GBBANJEDBOP>(); // 0x24
	public List<LLFNMNJGLNL> IJJHFGOIDOK_Songs = new List<LLFNMNJGLNL>(); // 0x28
	public List<AKIIJBEJOEP> NNMPGOAGEOL_Missions = new List<AKIIJBEJOEP>(); // 0x2C
	public List<ALBKHBLGHHN> GEGAEDDGNMA_EpBonusByScene = new List<ALBKHBLGHHN>(); // 0x30
	public List<MAPOMNOALHJ> OGMHMAGDNAM_EpBonusBySceneRarity = new List<MAPOMNOALHJ>(); // 0x34
	public List<ABGNMIEBCDN> LHAKGDAGEMM_EpBonus = new List<ABGNMIEBCDN>(); // 0x38
	private List<NNJFKLBPBNK_SecureString> IFBBNEGGCIH; // 0x44
	private List<CEBFFLDKAEC_SecureInt> JNJAOACIGOC; // 0x48
	public List<OLLFEBCLPIL> ADPFKHEMNBL = new List<OLLFEBCLPIL>(); // 0x4C
	public List<OLLFEBCLPIL> GKCBPNPEJJF = new List<OLLFEBCLPIL>(); // 0x50
	public List<AIGOEAPJGEB> MBHDIJJEOFL = new List<AIGOEAPJGEB>(); // 0x54
	public List<IJNOIMLNBGN> LLCLJBEJOPM_BannerInfo = new List<IJNOIMLNBGN>(); // 0x58

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI { get; private set; } // 0x3C IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK { get; private set; } // 0x40 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0x16CAD94 Offset: 0x16CAD94 VA: 0x16CAD94
	public string EFEGBHACJAL(string LJNAKDMILMC, string KKMJBMKHGNH)
	{
		if(FJOEBCMGDMI.ContainsKey(LJNAKDMILMC))
		{
			return FJOEBCMGDMI[LJNAKDMILMC].DNJEJEANJGL_Value;
		}
		return KKMJBMKHGNH;
	}

	//// RVA: 0x16CAE78 Offset: 0x16CAE78 VA: 0x16CAE78
	public int LPJLEHAJADA(string LJNAKDMILMC, int KKMJBMKHGNH)
	{
		if(OHJFBLFELNK.ContainsKey(LJNAKDMILMC))
		{
			return OHJFBLFELNK[LJNAKDMILMC].DNJEJEANJGL_Value;
		}
		return KKMJBMKHGNH;
	}

	// RVA: 0x16CAF5C Offset: 0x16CAF5C VA: 0x16CAF5C
	public PHBACNMCMHG_EventCollection()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		OHJFBLFELNK = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		JNJAOACIGOC = new List<CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		IFBBNEGGCIH = new List<NNJFKLBPBNK_SecureString>();
		LMHMIIKCGPE = 30;
	}

	// RVA: 0x16CB480 Offset: 0x16CB480 VA: 0x16CB480 Slot: 8
	protected override void KMBPACJNEOF()
	{
		NGHKJOEDLIP.LHPDDGIJKNB();
		FCIPEDFHFEM_RewardStep.Clear();
		NNMPGOAGEOL_Missions.Clear();
		OHJFBLFELNK.Clear();
		JNJAOACIGOC.Clear();
		FJOEBCMGDMI.Clear();
		IFBBNEGGCIH.Clear();
		ADPFKHEMNBL.Clear();
		GKCBPNPEJJF.Clear();
		MBHDIJJEOFL.Clear();
		LLCLJBEJOPM_BannerInfo.Clear();
		GEGAEDDGNMA_EpBonusByScene.Clear();
		OGMHMAGDNAM_EpBonusBySceneRarity.Clear();
		LHAKGDAGEMM_EpBonus.Clear();
	}

	// RVA: 0x16CB9A8 Offset: 0x16CB9A8 VA: 0x16CB9A8 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		HMNJADGBKFA data = HMNJADGBKFA.HEGEKFMJNCC(DBBGALAPFGC);
		DGKKMKLCEDF(data);
		GPEKKMGGBPF(data);
		GJEHPJJBCDE(data);
		CFOFJPLEDEA(data);
		ABICOINNGEK(data);
		EGLHCMDNFOE(data);
		JBNBGGDDEGG(data);
		{
			DPCNINPPGFC[] array = data.BHGDNGHDDAC;
			for(int i = 0; i < array.Length; i++)
			{
				CEBFFLDKAEC_SecureInt d = new CEBFFLDKAEC_SecureInt();
				d.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG;
				OHJFBLFELNK.Add(array[i].LJNAKDMILMC, d);
				JNJAOACIGOC.Add(d);
			}
		}
		{
			KNLJCIJAAME[] array = data.MHGMDJNOLMI;
			for(int i = 0; i < array.Length; i++)
			{
				NNJFKLBPBNK_SecureString d = new NNJFKLBPBNK_SecureString();
				d.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG;
				FJOEBCMGDMI.Add(array[i].LJNAKDMILMC, d);
				IFBBNEGGCIH.Add(d);
			}
		}
		{
			CBFHDJAILAO[] array = data.KIEKMCKCMGD;
			for(int i = 0; i < array.Length; i++)
			{
				OLLFEBCLPIL d = new OLLFEBCLPIL();
				d.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
				d.KFCIJBLDHOK = array[i].KFCIJBLDHOK;
				d.JLEIHOEGMOP = array[i].JLEIHOEGMOP;
				if(i > array.Length / 2)
					ADPFKHEMNBL.Add(d);
				else
					GKCBPNPEJJF.Add(d);
			}
		}
		AIGOEAPJGEB.KHEKNNFCAOI(MBHDIJJEOFL, data);
		IJNOIMLNBGN.KHEKNNFCAOI(JIKKNHIAEKG_BlockName, LLCLJBEJOPM_BannerInfo, data);

		UnityEngine.Debug.LogError(NGHKJOEDLIP.OPFGFINHFCE_Name+" "+NGHKJOEDLIP.OBGBAOLONDD_EventId);

		// Update dates
		UMOEventList.EventData CurrenEvent = UMOEventList.GetCurrentEvent();
		if (CurrenEvent != null && CurrenEvent.EnableBlock(JIKKNHIAEKG_BlockName))
		{
			System.DateTime date = Utility.GetLocalDateTime(Utility.GetCurrentUnixTime());
			System.DateTime date2 = Utility.GetLocalDateTime(NGHKJOEDLIP.BONDDBOFBND_Start);
			date = date.AddDays(-1);
			long offset = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, date2.Hour, date2.Minute, date2.Second) - NGHKJOEDLIP.BONDDBOFBND_Start;
			if (NGHKJOEDLIP.BONDDBOFBND_Start != 0) NGHKJOEDLIP.BONDDBOFBND_Start += offset;
			if (NGHKJOEDLIP.EHHFFKAFOMC != 0) NGHKJOEDLIP.EHHFFKAFOMC += offset;
			if (NGHKJOEDLIP.HPNOGLIFJOP_End1 != 0) NGHKJOEDLIP.HPNOGLIFJOP_End1 += offset;
			if (NGHKJOEDLIP.LNFKGHNHJKE != 0) NGHKJOEDLIP.LNFKGHNHJKE += offset;
			if (NGHKJOEDLIP.JGMDAOACOJF != 0) NGHKJOEDLIP.JGMDAOACOJF += offset;
			if (NGHKJOEDLIP.IDDBFFBPNGI != 0) NGHKJOEDLIP.IDDBFFBPNGI += offset;
			if (NGHKJOEDLIP.KNLGKBBIBOH_End != 0) NGHKJOEDLIP.KNLGKBBIBOH_End += offset;
			if (NGHKJOEDLIP.JBFDHOIKAIK_InventoryEndDate != 0) NGHKJOEDLIP.JBFDHOIKAIK_InventoryEndDate += offset;

			for(int i = 0; i < IJJHFGOIDOK_Songs.Count; i++)
			{
				if (IJJHFGOIDOK_Songs[i].PDBPFJJCADD_OpenAt != 0) IJJHFGOIDOK_Songs[i].PDBPFJJCADD_OpenAt = NGHKJOEDLIP.BONDDBOFBND_Start;
				if (IJJHFGOIDOK_Songs[i].FDBNFFNFOND_CloseAt != 0) IJJHFGOIDOK_Songs[i].FDBNFFNFOND_CloseAt = NGHKJOEDLIP.HPNOGLIFJOP_End1;
			}
			for(int i = 0; i < NNMPGOAGEOL_Missions.Count; i++)
			{
				if (NNMPGOAGEOL_Missions[i].KJBGCLPMLCG_Start != 0) NNMPGOAGEOL_Missions[i].KJBGCLPMLCG_Start = NGHKJOEDLIP.BONDDBOFBND_Start;
				if (NNMPGOAGEOL_Missions[i].GJFPFFBAKGK_End != 0) NNMPGOAGEOL_Missions[i].GJFPFFBAKGK_End = NGHKJOEDLIP.HPNOGLIFJOP_End1;
			}
			for(int i = 0; i < LLCLJBEJOPM_BannerInfo.Count; i++)
			{
				if (LLCLJBEJOPM_BannerInfo[i].PDBPFJJCADD_OpenAt != 0) LLCLJBEJOPM_BannerInfo[i].PDBPFJJCADD_OpenAt = NGHKJOEDLIP.BONDDBOFBND_Start;
				if (LLCLJBEJOPM_BannerInfo[i].FDBNFFNFOND_CloseAt != 0) LLCLJBEJOPM_BannerInfo[i].FDBNFFNFOND_CloseAt = NGHKJOEDLIP.HPNOGLIFJOP_End1;
			}
		}
		return true;
	}

	// RVA: 0x16CD738 Offset: 0x16CD738 VA: 0x16CD738 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.LogError(TodoLogger.DbJson, "PHBACNMCMHG_EventCollection.IIEMACPEEBJ");
		return true;
	}

	//// RVA: 0x16CBEF4 Offset: 0x16CBEF4 VA: 0x16CBEF4
	private bool DGKKMKLCEDF(HMNJADGBKFA OPHJCBPIPLM)
	{
		NGHKJOEDLIP.OBGBAOLONDD_EventId = (int)OPHJCBPIPLM.HMBHNLCFDIH.OBGBAOLONDD;
		NGHKJOEDLIP.OPFGFINHFCE_Name = OPHJCBPIPLM.HMBHNLCFDIH.OPFGFINHFCE;
		NGHKJOEDLIP.HEDAGCNPHGD = OPHJCBPIPLM.HMBHNLCFDIH.HEDAGCNPHGD;
		NGHKJOEDLIP.IDGAEEJLGIK = OPHJCBPIPLM.HMBHNLCFDIH.IDGAEEJLGIK;
		NGHKJOEDLIP.OCGFKMHNEOF = OPHJCBPIPLM.HMBHNLCFDIH.OCGFKMHNEOF;
		NGHKJOEDLIP.OGMGLOFKKPA = OPHJCBPIPLM.HMBHNLCFDIH.OGMGLOFKKPA;
		NGHKJOEDLIP.BONDDBOFBND_Start = OPHJCBPIPLM.HMBHNLCFDIH.BONDDBOFBND;
		NGHKJOEDLIP.EHHFFKAFOMC = OPHJCBPIPLM.HMBHNLCFDIH.EHHFFKAFOMC;
		NGHKJOEDLIP.HPNOGLIFJOP_End1 = OPHJCBPIPLM.HMBHNLCFDIH.HPNOGLIFJOP;
		NGHKJOEDLIP.LNFKGHNHJKE = OPHJCBPIPLM.HMBHNLCFDIH.LNFKGHNHJKE;
		NGHKJOEDLIP.JGMDAOACOJF = OPHJCBPIPLM.HMBHNLCFDIH.JGMDAOACOJF;
		NGHKJOEDLIP.IDDBFFBPNGI = OPHJCBPIPLM.HMBHNLCFDIH.IDDBFFBPNGI;
		NGHKJOEDLIP.KNLGKBBIBOH_End = OPHJCBPIPLM.HMBHNLCFDIH.KNLGKBBIBOH;
		NGHKJOEDLIP.JBFDHOIKAIK_InventoryEndDate = OPHJCBPIPLM.HMBHNLCFDIH.JBFDHOIKAIK;
		NGHKJOEDLIP.KHIKEGLBGAF = (int)OPHJCBPIPLM.HMBHNLCFDIH.KHIKEGLBGAF;
		NGHKJOEDLIP.DPJCFLKFEPN = (int)OPHJCBPIPLM.HMBHNLCFDIH.DPJCFLKFEPN;
		NGHKJOEDLIP.POGEFBMBPCB = (sbyte)OPHJCBPIPLM.HMBHNLCFDIH.JMJDLDEIFKE;
		NGHKJOEDLIP.AHKNMANFILO = (sbyte)OPHJCBPIPLM.HMBHNLCFDIH.AHKNMANFILO;
		NGHKJOEDLIP.MOEKELIIDEO_SaveIdx = (sbyte)OPHJCBPIPLM.HMBHNLCFDIH.MOEKELIIDEO;
		NGHKJOEDLIP.OCDMGOGMHGE_RewardPrefix = OPHJCBPIPLM.HMBHNLCFDIH.OCDMGOGMHGE;
		NGHKJOEDLIP.PJBILOFOCIC = OPHJCBPIPLM.HMBHNLCFDIH.PJBILOFOCIC;
		NGHKJOEDLIP.MJBKGOJBPAD_TicketType = OPHJCBPIPLM.HMBHNLCFDIH.MJBKGOJBPAD;
		NGHKJOEDLIP.MPKNCMEAMLO = (sbyte)OPHJCBPIPLM.HMBHNLCFDIH.MPKNCMEAMLO;
		NGHKJOEDLIP.AHKPNPNOAMO = (sbyte)OPHJCBPIPLM.HMBHNLCFDIH.AHKPNPNOAMO;
		NGHKJOEDLIP.FEMMDNIELFC_MusicSelectDesc = OPHJCBPIPLM.HMBHNLCFDIH.FEMMDNIELFC;
		NGHKJOEDLIP.HKKNEAGCIEB = (sbyte)OPHJCBPIPLM.HMBHNLCFDIH.HKKNEAGCIEB;
		NGHKJOEDLIP.HIOOGLEJBKM_StartAdventureId = OPHJCBPIPLM.HMBHNLCFDIH.HIOOGLEJBKM;
		NGHKJOEDLIP.FJCADCDNPMP_EndAdventureId = OPHJCBPIPLM.HMBHNLCFDIH.FJCADCDNPMP;
		NGHKJOEDLIP.EJBGHLOOLBC_HelpIds = OPHJCBPIPLM.HMBHNLCFDIH.EJBGHLOOLBC;
		NGHKJOEDLIP.EKJFNHHKBPL = OPHJCBPIPLM.HMBHNLCFDIH.EKJFNHHKBPL;
		NGHKJOEDLIP.OMCAOJJGOGG = OPHJCBPIPLM.HMBHNLCFDIH.OMCAOJJGOGG;
		EEEKPHDPJHG(NGHKJOEDLIP.CAPAPAABKDP, OPHJCBPIPLM.HMBHNLCFDIH.KOHMHBGOFFI);
		EEEKPHDPJHG(NGHKJOEDLIP.HKEAFPNNAPC, OPHJCBPIPLM.HMBHNLCFDIH.HKEAFPNNAPC);
		EEEKPHDPJHG(NGHKJOEDLIP.MCDPPHKEMJI, OPHJCBPIPLM.HMBHNLCFDIH.MCDPPHKEMJI);
		EEEKPHDPJHG(NGHKJOEDLIP.BJHHDGCOACI, OPHJCBPIPLM.HMBHNLCFDIH.BJHHDGCOACI);
		EEEKPHDPJHG(NGHKJOEDLIP.JDDIOIMOFDE, OPHJCBPIPLM.HMBHNLCFDIH.JDDIOIMOFDE);
		{
			uint[] array = OPHJCBPIPLM.HMBHNLCFDIH.DMDHPBNAPKI;
			for(int i = 0; i < array.Length; i++)
			{
				if(i < array.Length / 2)
					NGHKJOEDLIP.LLMCLICMLLG((int)array[i]);
				else
					NGHKJOEDLIP.DJBHHJEJPFK((int)array[i]);
			}
		}
		for(int i = 0; i < OPHJCBPIPLM.HMBHNLCFDIH.JHPCPNJJHLI.Length; i++)
		{
			if(OPHJCBPIPLM.HMBHNLCFDIH.JHPCPNJJHLI[i] < 1001)
			{
				NGHKJOEDLIP.JHPCPNJJHLI.Add(OPHJCBPIPLM.HMBHNLCFDIH.JHPCPNJJHLI[i]);
			}
		}
		NGHKJOEDLIP.EEOGPJJCKHH_Drops.Clear();
		for(int i = 0; i < OPHJCBPIPLM.HMBHNLCFDIH.EEOGPJJCKHH.Length; i++)
		{
			NGHKJOEDLIP.EEOGPJJCKHH_Drops.Add((int)OPHJCBPIPLM.HMBHNLCFDIH.EEOGPJJCKHH[i]);
		}
		return true;
	}

	//// RVA: 0x16CD878 Offset: 0x16CD878 VA: 0x16CD878
	//private bool DGKKMKLCEDF(EDOHBJAPLPF IDLHJIOMJBK, int KAPMOPMDHJE) { }

	//// RVA: 0x16CDB9C Offset: 0x16CDB9C VA: 0x16CDB9C
	//private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, EDOHBJAPLPF OBHAFLMHAKG, string OPFGFINHFCE, ref bool NGJDHLGMHMH) { }

	//// RVA: 0x16CD900 Offset: 0x16CD900 VA: 0x16CD900
	private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, string OAIBJJHGCNM)
	{
		string[] strs = OAIBJJHGCNM.Split(new char[] {','});
		NNDGIAEFMOG.Clear();
		for(int i = 0; i < strs.Length; i++)
		{
			if(!string.IsNullOrEmpty(strs[i]))
			{
				NNDGIAEFMOG.Add(int.Parse(strs[i]));
			}
		}
	}

	//// RVA: 0x16CCB3C Offset: 0x16CCB3C VA: 0x16CCB3C
	private bool GPEKKMGGBPF(HMNJADGBKFA OPHJCBPIPLM)
	{
		MCFPAFGFPJC[] array = OPHJCBPIPLM.MCHFABAKPMH;
		for(int i = 0; i < array.Length; i++)
		{
			GBBANJEDBOP d = new GBBANJEDBOP();
			d.FBGGEFFJJHB = 0xa38887a;
			d.PPFNGGCBJKC = (int)array[i].PPFNGGCBJKC;
			d.DNBFMLBNAEE_Point = (int)array[i].FOILNHKHHDF;
			d.JOPPFEHKNFO = array[i].JOPPFEHKNFO != 0;
			for(int j = 0; j < array[i].AIHOJKFNEEN.Length; j++)
			{
				PFGFDNLGPKP d2 = new PFGFDNLGPKP();
				d2.FBGGEFFJJHB = 0x341e805b;
				d2.GLCLFMGPMAN_ItemId = array[i].AIHOJKFNEEN[j];
				d2.HMFFHLPNMPH_Cnt = (int)array[i].BFINGCJHOHI[j];
				d2.NMKEOMCMIPP_RewardId = (int)array[i].JJHPDDPKBHF[j];
				d2.PJPDOCNJNGJ_IsLimited = array[i].HJAFPEBIBOP[j] != 0;
				d.AHJNPEAMCCH_Items.Add(d2);
			}
			FCIPEDFHFEM_RewardStep.Add(d);
		}
		return true;
	}

	//// RVA: 0x16CD880 Offset: 0x16CD880 VA: 0x16CD880
	//private bool GPEKKMGGBPF(EDOHBJAPLPF OBHAFLMHAKG, int KAPMOPMDHJE) { }

	//// RVA: 0x16CD00C Offset: 0x16CD00C VA: 0x16CD00C
	private bool GJEHPJJBCDE(HMNJADGBKFA OPHJCBPIPLM)
	{
		ENAEMKEKAOE[] array = OPHJCBPIPLM.GHIHAGAOPNC;
		for(int i = 0; i < array.Length; i++)
		{
			LLFNMNJGLNL d = new LLFNMNJGLNL();
			d.KHEKNNFCAOI(i + 1, OPHJCBPIPLM);
			IJJHFGOIDOK_Songs.Add(d);
		}
		return true;
	}

	//// RVA: 0x16CD888 Offset: 0x16CD888 VA: 0x16CD888
	//private bool GJEHPJJBCDE(EDOHBJAPLPF OBHAFLMHAKG, int KAPMOPMDHJE) { }

	//// RVA: 0x16CD128 Offset: 0x16CD128 VA: 0x16CD128
	private bool CFOFJPLEDEA(HMNJADGBKFA OPHJCBPIPLM)
	{
		OFFLOKADBGI[] array = OPHJCBPIPLM.MDDOGIAFDEI;
		int xor = (int)Utility.GetCurrentUnixTime() * 0xb + 1;
		for(int i = 0; i < array.Length; i++)
		{
			AKIIJBEJOEP d = new AKIIJBEJOEP();
			d.KHEKNNFCAOI(JIKKNHIAEKG_BlockName, i + 1, xor, OPHJCBPIPLM);
			NNMPGOAGEOL_Missions.Add(d);
			xor += 0xd;
		}
		return true;
	}

	//// RVA: 0x16CD890 Offset: 0x16CD890 VA: 0x16CD890
	//private bool CFOFJPLEDEA(EDOHBJAPLPF OBHAFLMHAKG, int KAPMOPMDHJE) { }

	//// RVA: 0x16CD5B4 Offset: 0x16CD5B4 VA: 0x16CD5B4
	private bool JBNBGGDDEGG(HMNJADGBKFA JMHECKKKMLK)
	{
		KPFPLABANJG[] array = JMHECKKKMLK.OLACFKILCFD;
		int xor = (int)Utility.GetCurrentUnixTime() * 0xb + 1;
		for(int i = 0; i < array.Length; i++)
		{
			ALBKHBLGHHN d = new ALBKHBLGHHN();
			d.BAFFAONJPCE(i, xor, JMHECKKKMLK);
			GEGAEDDGNMA_EpBonusByScene.Add(d);
			xor = xor * 3 + 0xd;
		}
		return true;
	}

	//// RVA: 0x16CD2C0 Offset: 0x16CD2C0 VA: 0x16CD2C0
	private bool ABICOINNGEK(HMNJADGBKFA JMHECKKKMLK)
	{
		CNFAHCDJNKD[] array = JMHECKKKMLK.MIOCOKLMLBD;
		int xor = (int)Utility.GetCurrentUnixTime() * 0xb + 1;
		for(int i = 0; i < array.Length; i++)
		{
			MAPOMNOALHJ d = new MAPOMNOALHJ();
			d.BAFFAONJPCE(i, xor, JMHECKKKMLK);
			OGMHMAGDNAM_EpBonusBySceneRarity.Add(d);
			xor = xor * 3 + 0xd;
		}
		return true;
	}

	//// RVA: 0x16CD43C Offset: 0x16CD43C VA: 0x16CD43C
	private bool EGLHCMDNFOE(HMNJADGBKFA JMHECKKKMLK)
	{
		CFFKBKJMNNN[] array = JMHECKKKMLK.IEJLJIHIDJC;
		int xor = (int)Utility.GetCurrentUnixTime() * 0xb + 1;
		for(int i = 0; i < array.Length; i++)
		{
			ABGNMIEBCDN d = new ABGNMIEBCDN();
			d.BAFFAONJPCE(i, xor, JMHECKKKMLK);
			LHAKGDAGEMM_EpBonus.Add(d);
			xor = xor * 3 + 0xd;
		}
		return true;
	}

	// RVA: 0x16CE4D0 Offset: 0x16CE4D0 VA: 0x16CE4D0 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "PHBACNMCMHG_EventCollection.CAOGDCBPBAN");
		return 0;
	}
}
