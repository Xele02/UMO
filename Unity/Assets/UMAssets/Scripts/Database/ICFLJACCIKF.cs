
using System.Collections.Generic;
using UnityEngine.Localization.SmartFormat.Utilities;
using XeSys;

[System.Obsolete("Use ICFLJACCIKF_EventBattle", true)]
public class ICFLJACCIKF { }
public class ICFLJACCIKF_EventBattle : DIHHCBACKGG_DbSection
{
	public class KNLJPCCDPDK
	{
		public int OBGBAOLONDD; // 0x8
		public int HFNIHKOAMGC; // 0xC
		public string OPFGFINHFCE; // 0x10
		public string HEDAGCNPHGD; // 0x14
		public string IDGAEEJLGIK; // 0x18
		public string OCGFKMHNEOF; // 0x1C
		public string OGMGLOFKKPA; // 0x20
		public string FEMMDNIELFC; // 0x24
		public long BONDDBOFBND_Start; // 0x28
		public long HPNOGLIFJOP_End1; // 0x30
		public long EHHFFKAFOMC; // 0x38
		public long LNFKGHNHJKE; // 0x40
		public long JGMDAOACOJF; // 0x48
		public long IDDBFFBPNGI; // 0x50
		public long KNLGKBBIBOH_End; // 0x58
		public long JBFDHOIKAIK_InventoryEndDate; // 0x60
		public int KHIKEGLBGAF; // 0x68
		public int DPJCFLKFEPN; // 0x6C
		public int MJBKGOJBPAD; // 0x70
		public sbyte POGEFBMBPCB; // 0x74
		public sbyte AHKNMANFILO; // 0x75
		public sbyte MOEKELIIDEO_SaveIdx; // 0x76
		public string OMCAOJJGOGG; // 0x78
		public sbyte HKKNEAGCIEB; // 0x7C
		public sbyte AHKPNPNOAMO; // 0x7D
		public int HDNCGECBIKD; // 0x80
		public int EKJFNHHKBPL; // 0x84
		public int[] JKFPADIAKCK; // 0x88
		private NNJFKLBPBNK_SecureString EBGIDCIIGDO = new NNJFKLBPBNK_SecureString(); // 0x8C
		private NNJFKLBPBNK_SecureString NJKIMJAFCPC = new NNJFKLBPBNK_SecureString(); // 0x90
		public List<int> JHPCPNJJHLI = new List<int>(); // 0x94
		private List<int> HIAMHLLHAON_PlayCost = new List<int>(); // 0x98
		private List<int> LFHLCBEBPPK_PlayCostL6 = new List<int>(); // 0x9C
		public int HIOOGLEJBKM; // 0xA0
		public int FJCADCDNPMP; // 0xA4
		public int[] EJBGHLOOLBC_HelpsId; // 0xA8
		public List<int> EEOGPJJCKHH_Drops = new List<int>(); // 0xAC

		public string OCDMGOGMHGE { get { return EBGIDCIIGDO.DNJEJEANJGL_Value; } set { EBGIDCIIGDO.DNJEJEANJGL_Value = value; } } //0x11E8E00 HBAAAKFHDBB 0x11E8E2C NHJLJOIPOFK
		public string PJBILOFOCIC { get { return NJKIMJAFCPC.DNJEJEANJGL_Value; } set { NJKIMJAFCPC.DNJEJEANJGL_Value = value; } } //0x11E8E60 NOEFEAIFHCL 0x11E8E8C GJIJFGNONEL

		//// RVA: 0x11E8EC0 Offset: 0x11E8EC0 VA: 0x11E8EC0
		public void PFGFMLEEDLN(int NANNGLGOFKH)
		{
			HIAMHLLHAON_PlayCost.Add(NANNGLGOFKH);
		}

		//// RVA: 0x11E8F40 Offset: 0x11E8F40 VA: 0x11E8F40
		public void OJLPDKAKDMC(int NANNGLGOFKH)
		{
			LFHLCBEBPPK_PlayCostL6.Add(NANNGLGOFKH);
		}

		//// RVA: 0x11E8FC0 Offset: 0x11E8FC0 VA: 0x11E8FC0
		public int GEDKCAODLMM_GetPlayCost(int AKNELONELJK, bool GIKLNODJKFK)
		{
			if(!GIKLNODJKFK)
				return HIAMHLLHAON_PlayCost[AKNELONELJK];
			else
				return LFHLCBEBPPK_PlayCostL6[AKNELONELJK];
		}

		//// RVA: 0x11E9050 Offset: 0x11E9050 VA: 0x11E9050
		public void LHPDDGIJKNB()
		{
			OBGBAOLONDD = 0;
			HFNIHKOAMGC = 0;
			BONDDBOFBND_Start = 0;
			HPNOGLIFJOP_End1 = 0;
			JGMDAOACOJF = 0;
			IDDBFFBPNGI = 0;
			JBFDHOIKAIK_InventoryEndDate = 0;
			KHIKEGLBGAF = 0;
			DPJCFLKFEPN = 0;
			EHHFFKAFOMC = 0;
			OGMGLOFKKPA = "";
			FEMMDNIELFC = "";
			POGEFBMBPCB = 0;
			AHKNMANFILO = 0;
			MOEKELIIDEO_SaveIdx = 0;
			MJBKGOJBPAD = 1;
			HKKNEAGCIEB = 0;
			OPFGFINHFCE = "";
			HEDAGCNPHGD = "";
			IDGAEEJLGIK = "";
			OCGFKMHNEOF = "";
			OCDMGOGMHGE = "";
			PJBILOFOCIC = "";
			JHPCPNJJHLI.Clear();
			HIAMHLLHAON_PlayCost.Clear();
			LFHLCBEBPPK_PlayCostL6.Clear();
			OMCAOJJGOGG = "";
			HIOOGLEJBKM = 0;
			FJCADCDNPMP = 0;
			EJBGHLOOLBC_HelpsId = null;
			AHKPNPNOAMO = 0;
			EKJFNHHKBPL = 0;
			JKFPADIAKCK = null;
			EEOGPJJCKHH_Drops.Clear();
		}

		//// RVA: 0x11E91F8 Offset: 0x11E91F8 VA: 0x11E91F8
		//public uint CAOGDCBPBAN() { }
	}

	public class FGBJDLLLBEF
	{
		public int FBGGEFFJJHB; // 0x8
		private int EHOIENNDEDH_Crypted; // 0xC
		private int FMDDJNKEBBB_Crypted; // 0x10
		private int MDKGAAMBJDJ_Crypted; // 0x14
		private int GGEBNMPPEID_Crypted; // 0x18

		public int PPFNGGCBJKC { get { return EHOIENNDEDH_Crypted ^ FBGGEFFJJHB; } set { EHOIENNDEDH_Crypted = value ^ FBGGEFFJJHB; } } //0x11E8048 DEMEPMAEJOO 0x11E8058 HIGKAIDMOKN
		public int CNKFPJCGNFE { get { return FMDDJNKEBBB_Crypted ^ FBGGEFFJJHB; } set { FMDDJNKEBBB_Crypted = value ^ FBGGEFFJJHB; } } //0x11E8068 GJBOGOFHGNP 0x11E8078 GJDGIDCMJMH
		public int GNFBMCGMCFO { get { return MDKGAAMBJDJ_Crypted ^ FBGGEFFJJHB; } set { MDKGAAMBJDJ_Crypted = value ^ FBGGEFFJJHB; } } //0x11E8088 NCIMMDJLPLJ 0x11E8098 HNAJAFBHOLM
		public int BFFGFAMJAIG { get { return GGEBNMPPEID_Crypted ^ FBGGEFFJJHB; } set { GGEBNMPPEID_Crypted = value ^ FBGGEFFJJHB; } } //0x11E80A8 PKMNOMELPMN 0x11E80B8 IABBJBAHKCE

		//// RVA: 0x11E80C8 Offset: 0x11E80C8 VA: 0x11E80C8
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x11E80F4 Offset: 0x11E80F4 VA: 0x11E80F4
		public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, OPHFFGFJIBJ JMHECKKKMLK)
		{
			FBGGEFFJJHB = KNEFBLHBDBG;
			BFFGFAMJAIG = 0;
			PPFNGGCBJKC = 0;
			CNKFPJCGNFE = 0;
			GNFBMCGMCFO = 0;
			NFEINLOIPEP data = JMHECKKKMLK.OLACFKILCFD[JBGJDEELLOP];
			PPFNGGCBJKC = data.PPFNGGCBJKC;
			CNKFPJCGNFE = data.CNKFPJCGNFE;
			GNFBMCGMCFO = data.GNFBMCGMCFO;
			BFFGFAMJAIG = data.BFFGFAMJAIG;
		}

		//// RVA: 0x11E8238 Offset: 0x11E8238 VA: 0x11E8238
		//public void LHPDDGIJKNB(int KNEFBLHBDBG) { }
	}

	public class DGBPOCFMKMJ
	{
		public int FBGGEFFJJHB; // 0x8
		private int EHOIENNDEDH_Crypted; // 0xC
		private int MDKGAAMBJDJ_Crypted; // 0x10
		private int GGEBNMPPEID_Crypted; // 0x14

		public int PPFNGGCBJKC { get { return EHOIENNDEDH_Crypted ^ FBGGEFFJJHB; } set { EHOIENNDEDH_Crypted = value ^ FBGGEFFJJHB; } } //0x11E71AC DEMEPMAEJOO 0x11E71BC HIGKAIDMOKN
		public int GNFBMCGMCFO { get { return MDKGAAMBJDJ_Crypted ^ FBGGEFFJJHB; } set { MDKGAAMBJDJ_Crypted = value ^ FBGGEFFJJHB; } } //0x11E71CC NCIMMDJLPLJ 0x11E71DC HNAJAFBHOLM
		public int BFFGFAMJAIG { get { return GGEBNMPPEID_Crypted ^ FBGGEFFJJHB; } set { GGEBNMPPEID_Crypted = value ^ FBGGEFFJJHB; } } //0x11E71EC PKMNOMELPMN 0x11E71FC IABBJBAHKCE

		//// RVA: 0x11E720C Offset: 0x11E720C VA: 0x11E720C
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x11E7230 Offset: 0x11E7230 VA: 0x11E7230
		public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, OPHFFGFJIBJ JMHECKKKMLK)
		{
			FBGGEFFJJHB = KNEFBLHBDBG;
			PPFNGGCBJKC = 0;
			GNFBMCGMCFO = 0;
			BFFGFAMJAIG = 0;
			PHNMAKOGBKJ data = JMHECKKKMLK.MIOCOKLMLBD[JBGJDEELLOP];
			PPFNGGCBJKC = data.PPFNGGCBJKC;
			GNFBMCGMCFO = data.GNFBMCGMCFO;
			BFFGFAMJAIG = data.BFFGFAMJAIG;
		}

		//// RVA: 0x11E7334 Offset: 0x11E7334 VA: 0x11E7334
		//public void LHPDDGIJKNB(int KNEFBLHBDBG) { }
	}

	public class GNCIKNGDGPP
	{
		public int FBGGEFFJJHB; // 0x8
		private int HHEEHHHLKHC_Crypted; // 0xC
		private int LGAIHLFAPDC_Crypted; // 0x10
		public List<int> KDNMBOBEGJM = new List<int>(); // 0x14

		public int KHPHAAMGMJP { get { return HHEEHHHLKHC_Crypted ^ FBGGEFFJJHB; } set { HHEEHHHLKHC_Crypted = value ^ FBGGEFFJJHB; } } //0x11E84D0 ABFDDKBBPCH 0x11E84E0 MHDOIIEMDEH
		public int OFIAENKCJME { get { return LGAIHLFAPDC_Crypted ^ FBGGEFFJJHB; } set { LGAIHLFAPDC_Crypted = value ^ FBGGEFFJJHB; } } //0x11E84F0 KADLAKFANGA 0x11E8500 AIDAPNCEPOB

		//// RVA: 0x11E8510 Offset: 0x11E8510 VA: 0x11E8510
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x11E85E8 Offset: 0x11E85E8 VA: 0x11E85E8
		public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, OPHFFGFJIBJ JMHECKKKMLK)
		{
			LHPDDGIJKNB(KNEFBLHBDBG);
			FJOLJGPGDGD array = JMHECKKKMLK.IEJLJIHIDJC[JBGJDEELLOP];
			KHPHAAMGMJP = array.KHPHAAMGMJP;
			OFIAENKCJME = array.OFIAENKCJME;
			for(int i = 0; i < array.JMLCLHHLJHM.Length; i++)
			{
				KDNMBOBEGJM.Add(array.JMLCLHHLJHM[i]);
			}
		}

		//// RVA: 0x11E87BC Offset: 0x11E87BC VA: 0x11E87BC
		public void LHPDDGIJKNB(int KNEFBLHBDBG)
		{
			FBGGEFFJJHB = KNEFBLHBDBG;
			KHPHAAMGMJP = 0;
			OFIAENKCJME = 0;
			KDNMBOBEGJM.Clear();
		}
	}

	public class BEFNBMEMFOB
	{
		public int GLCLFMGPMAN; // 0x8
		public int HMFFHLPNMPH; // 0xC
		public int NMKEOMCMIPP; // 0x10
		public int HJAFPEBIBOP; // 0x14

		public bool PJPDOCNJNGJ { get { return HJAFPEBIBOP > 0; } } //0x11E6F58 MBEBLALDBHJ
	}

	public class BHBICAALJIA
	{
		public int PPFNGGCBJKC; // 0x8
		public int DNBFMLBNAEE; // 0xC
		public List<BEFNBMEMFOB> AHJNPEAMCCH = new List<BEFNBMEMFOB>(); // 0x10
		public bool JOPPFEHKNFO; // 0x14

		// RVA: 0x11E6F74 Offset: 0x11E6F74 VA: 0x11E6F74
		//public uint CAOGDCBPBAN() { }
	}

	public class LPJIKDAMGPC
	{
		public int FBGGEFFJJHB; // 0x8
		public int DPOOAOPAAGC_Crypted; // 0xC
		public int PLCMLMADCDD_Crypted; // 0x10
		public int LCGJKAGIFGO_Crypted; // 0x14
		public int HNDOLKNBOIJ; // 0x18
		public int HHGFOIMIGED; // 0x1C
		public int IBCMDICBGHH; // 0x20
		public int HKAILALAFDG; // 0x24
		public int PEBHLFLDIGC_Crypted; // 0x28

		public int EEAPIKNJNDB { get { return FBGGEFFJJHB ^ DPOOAOPAAGC_Crypted; } set { DPOOAOPAAGC_Crypted = value ^ FBGGEFFJJHB; } } // 0x11E94BC KNLJPLHJMHI 0x11E94CC IMHAJFDFGJL
		public int NNDBJGDFEEM { get { return FBGGEFFJJHB ^ PLCMLMADCDD_Crypted; } set { PLCMLMADCDD_Crypted = value ^ FBGGEFFJJHB; } } // 0x11E94DC EHNOFMPHLFC 0x11E94EC GCANPOPEKEE
		public int DOOGFEGEKLG { get { return FBGGEFFJJHB ^ LCGJKAGIFGO_Crypted; } set { LCGJKAGIFGO_Crypted = value ^ FBGGEFFJJHB; } } // 0x11E94FC AECMFIOFFJN 0x11E950C NGOJJDOCIDG
		public int DJJGNDCMNHF { get { return FBGGEFFJJHB ^ PEBHLFLDIGC_Crypted; } set { PEBHLFLDIGC_Crypted = value ^ FBGGEFFJJHB; } } // 0x11E951C GEPCOAPEAJM 0x11E952C MIFJBBAJAJP

		//// RVA: 0x11E953C Offset: 0x11E953C VA: 0x11E953C
		//public int OBMHEPPBCCI(int MBMADKJEDLP) { }

		//// RVA: 0x11E9564 Offset: 0x11E9564 VA: 0x11E9564
		//public int FBCEFLKBDHO(int MBMADKJEDLP) { }
	}

	public class FKACPHEKBNF
	{
		public int FBGGEFFJJHB; // 0x8
		public string OPFGFINHFCE_Name; // 0xC
		public int[] MJNMPAKBNKB_NotesResult = new int[5]; // 0x10
		public int ENNCJKLIGKE_Luck; // 0x14
		public int PALEGNNHIKH_Leaf; // 0x18
		public int JCDEDIOAGKE_ExcellentRatio; // 0x1C
		public int BJHHOBEMBJG_Crypted; // 0x20
		public int CPCKPCJBDEL_Crypted; // 0x24
		public int AOFGNAJLLPD_Crypted; // 0x28
		public int ENEKCBCOKNM_Crypted; // 0x2C
		public int HNJHPNPFAAN_Crypted; // 0x30
		public int CJAOMKLHFJL_Crypted; // 0x34
		public int EHOIENNDEDH_Crypted; // 0x38
		public int KPLDLGGMOMH_Crypted; // 0x3C
		public int HIJDFKKMONB_Crypted; // 0x40
		public int MHGDDPCAGAJ_Crypted; // 0x44
		public int GIELAFNPOCG_Crypted; // 0x48
		public int GHJIBEMCKLA_Crypted; // 0x4C
		public int NBOLDNMPJFG_Crypted; // 0x50
		public int EOPEEENMHEN_Crypted; // 0x54
		public int BCKCCHGMPBG_Crypted; // 0x58
		public int JKJDDGGNEAB_Crypted; // 0x5C

		public int BEEAIAAJOHD_CostumeId { get { return BJHHOBEMBJG_Crypted ^ FBGGEFFJJHB; } set { BJHHOBEMBJG_Crypted = value ^ FBGGEFFJJHB; } } //0x11E8254 DIIBIOEMHAI 0x11E8264 JIHEDMEFKAF
		public int AKNELONELJK_Difficulty { get { return CPCKPCJBDEL_Crypted ^ FBGGEFFJJHB; } set { CPCKPCJBDEL_Crypted = value ^ FBGGEFFJJHB; } } //0x11E8274 BPPILHGDABB 0x11E8284 PMMIIHKEGCI
		public int DIPKCALNIII_DivaId { get { return AOFGNAJLLPD_Crypted ^ FBGGEFFJJHB; } set { AOFGNAJLLPD_Crypted = value ^ FBGGEFFJJHB; } } //0x11E8294 EOGPBFIDAPF 0x11E82A4 JDNCGPBAFMB
		public int HEBKEJBDCBH_DivaLevel { get { return ENEKCBCOKNM_Crypted ^ FBGGEFFJJHB; } set { ENEKCBCOKNM_Crypted = value ^ FBGGEFFJJHB; } } //0x11E82B4 OMOHEDILHMF 0x11E82C4 FCGDHINFKHC
		public int PLALNIIBLOF_Enabled { get { return HNJHPNPFAAN_Crypted ^ FBGGEFFJJHB; } set { HNJHPNPFAAN_Crypted = value ^ FBGGEFFJJHB; } } //0x11E82D4 JPCJNLHHIPE 0x11E82E4 JJFJNEJLBDG
		public int GOIKCKHMBDL_FreeMusicId { get { return CJAOMKLHFJL_Crypted ^ FBGGEFFJJHB; } set { CJAOMKLHFJL_Crypted = value ^ FBGGEFFJJHB; } } //0x11E82F4 BPGCGEDHBEH 0x11E8304 ICPMFBIDFFO
		public int PPFNGGCBJKC { get { return EHOIENNDEDH_Crypted ^ FBGGEFFJJHB; } set { EHOIENNDEDH_Crypted = value ^ FBGGEFFJJHB; } } //0x11E8314 DEMEPMAEJOO 0x11E8324 HIGKAIDMOKN
		public int EDJMDDAGCEJ_Score1 { get { return KPLDLGGMOMH_Crypted ^ FBGGEFFJJHB; } set { KPLDLGGMOMH_Crypted = value ^ FBGGEFFJJHB; } } //0x11E8334 BCMKDNCFOJO 0x11E8344 DDIAEKOKDIE
		public int HEFPAIOLBAG_Score2 { get { return HIJDFKKMONB_Crypted ^ FBGGEFFJJHB; } set { HIJDFKKMONB_Crypted = value ^ FBGGEFFJJHB; } } //0x11E8354 EAGPNJEBOCP 0x11E8364 LLIGHINHLOL
		public int GLILAGLJLEP_SceneId { get { return MHGDDPCAGAJ_Crypted ^ FBGGEFFJJHB; } set { MHGDDPCAGAJ_Crypted = value ^ FBGGEFFJJHB; } } //0x11E8374 HGPGPALMELF 0x11E8384 ECHLNFNJFFO
		public int ECOLMPLOPFM_SceneLevel { get { return GIELAFNPOCG_Crypted ^ FBGGEFFJJHB; } set { GIELAFNPOCG_Crypted = value ^ FBGGEFFJJHB; } } //0x11E8394 BFLCGLBAFOE 0x11E83A4 NJGKCLHFDIB
		public int CFCIMKOHLIG_Mlt { get { return GHJIBEMCKLA_Crypted ^ FBGGEFFJJHB; } set { GHJIBEMCKLA_Crypted = value ^ FBGGEFFJJHB; } } //0x11E83B4 AJNACFGNOAA 0x11E83C4 LCGAFCPHDKA
		public int BDLNMOIOMHK_TotalStats { get { return JKJDDGGNEAB_Crypted ^ FBGGEFFJJHB; } set { JKJDDGGNEAB_Crypted = value ^ FBGGEFFJJHB; } } //0x11E83D4 MKMAKAEDMBG 0x11E83E4 GIJPLHEDIKD
		public int NLKEBAOBJCM_ComboRatio { get { return BCKCCHGMPBG_Crypted ^ FBGGEFFJJHB; } set { BCKCCHGMPBG_Crypted = value ^ FBGGEFFJJHB; } } //0x11E83F4 AECNKGBNKHH 0x11E8404 ECHLKFHOJFP
		public int KNIFCANOHOC_Score { get { return NBOLDNMPJFG_Crypted ^ FBGGEFFJJHB; } set { NBOLDNMPJFG_Crypted = value ^ FBGGEFFJJHB; } } //0x11E8414 EOJEPLIPOMJ 0x11E8424 AEEMBPAEAAI
		public int IPPNCOHEEOD_ScoreAverage { get { return EOPEEENMHEN_Crypted ^ FBGGEFFJJHB; } set { EOPEEENMHEN_Crypted = value ^ FBGGEFFJJHB; } } //0x11E8434 BNFNPCNAGAF 0x11E8444 GEMDEGDPJPK
	}

	public class FKKMACHKBFB
	{
		public int PPFNGGCBJKC; // 0x8
		public int KFCIJBLDHOK; // 0xC
		public int JLEIHOEGMOP; // 0x10
	}

	public class OABJKIKLDKP
	{
		public int FBGGEFFJJHB; // 0x8
		public int EHOIENNDEDH_IdCrypted; // 0xC
		public int HNJHPNPFAAN_EnabledCrypted; // 0x10
		public int CNMODNFFBLP_FMusicIdCrypted; // 0x14
		public int CHDLCOGBCNK_CSkillCrypted; // 0x18
		public int KNALPNKGKHD_LSkillCrypted; // 0x1C
		public long PCLNFCNIECH_OpenAtCrypted; // 0x20
		public long HHPIJHADAOB_CloseAtCrypted; // 0x28

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB; } } //0x11E9594 DEMEPMAEJOO 0x11E95A0 HIGKAIDMOKN
		public int PLALNIIBLOF_Enabled { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB; } } //0x11E95B0 JPCJNLHHIPE 0x11E95C0 JJFJNEJLBDG
		public int MPLGPBNJDJB_FMusicId { get { return CNMODNFFBLP_FMusicIdCrypted ^ FBGGEFFJJHB; } set { CNMODNFFBLP_FMusicIdCrypted = value ^ FBGGEFFJJHB; } } //0x11E95D0 KADAEAOKJNE 0x11E95E0 MBKFNLHPNPP
		public int CPBFAMJEODF_CSkill { get { return CHDLCOGBCNK_CSkillCrypted ^ FBGGEFFJJHB; } set { CHDLCOGBCNK_CSkillCrypted = value ^ FBGGEFFJJHB; } } //0x11E95F0 GEPFGJBNHNL 0x11E9600 MHBECPNIHLA
		public int MGHPJNNDCIG_LSkill { get { return KNALPNKGKHD_LSkillCrypted ^ FBGGEFFJJHB; } set { KNALPNKGKHD_LSkillCrypted = value ^ FBGGEFFJJHB; } } //0x11E9610 GFADFBMKBMD 0x11E9620 JECIKFDJMOB
		public long PDBPFJJCADD_OpenAt { get { return PCLNFCNIECH_OpenAtCrypted ^ FBGGEFFJJHB; } set { PCLNFCNIECH_OpenAtCrypted = value ^ FBGGEFFJJHB; } } //0x11E9630 FOACOMBHPAC 0x11E9648 NBACOBCOJCA
		public long FDBNFFNFOND_CloseAt { get { return HHPIJHADAOB_CloseAtCrypted ^ FBGGEFFJJHB; } set { HHPIJHADAOB_CloseAtCrypted = value ^ FBGGEFFJJHB; } } //0x11E965C BPJOGHJCLDJ 0x11E9674 NLJKMCHOCBK

		//// RVA: 0x11E9688 Offset: 0x11E9688 VA: 0x11E9688
		//public void LHPDDGIJKNB(int PPFNGGCBJKC, int KNEFBLHBDBG) { }

		//// RVA: 0x11E96B8 Offset: 0x11E96B8 VA: 0x11E96B8
		//public void KHEKNNFCAOI(int PPFNGGCBJKC, int KNEFBLHBDBG, EDOHBJAPLPF IDLHJIOMJBK) { }

		//// RVA: 0x11E99C4 Offset: 0x11E99C4 VA: 0x11E99C4
		public void KHEKNNFCAOI(int PPFNGGCBJKC_, int KNEFBLHBDBG_, OPHFFGFJIBJ JMHECKKKMLK_)
		{
			FBGGEFFJJHB = KNEFBLHBDBG_;
			PPFNGGCBJKC_Id = PPFNGGCBJKC_;
			PLALNIIBLOF_Enabled = 0;
			MPLGPBNJDJB_FMusicId = 0;
			CPBFAMJEODF_CSkill = 0;
			MGHPJNNDCIG_LSkill = 0;
			PDBPFJJCADD_OpenAt = 0;
			FDBNFFNFOND_CloseAt = 0;
			IJFIMCBAJDJ data = JMHECKKKMLK_.GHIHAGAOPNC[PPFNGGCBJKC_ - 1];
			PPFNGGCBJKC_Id = (int)data.PPFNGGCBJKC;
			PLALNIIBLOF_Enabled = (int)data.PLALNIIBLOF;
			MPLGPBNJDJB_FMusicId = (int)data.MPLGPBNJDJB;
			CPBFAMJEODF_CSkill = (int)data.CPBFAMJEODF;
			MGHPJNNDCIG_LSkill = (int)data.MGHPJNNDCIG;
			PDBPFJJCADD_OpenAt = (int)data.PDBPFJJCADD;
			FDBNFFNFOND_CloseAt = (int)data.FDBNFFNFOND;
		}

		//// RVA: 0x11E9BC0 Offset: 0x11E9BC0 VA: 0x11E9BC0
		//public uint CAOGDCBPBAN() { }
	}

	public class KGHHHPHBGGM
	{
		public int FBGGEFFJJHB; // 0x8
		public int EHOIENNDEDH_IdCrypted; // 0xC
		public int HNJHPNPFAAN_EnabledCrypted; // 0x10
		public int OGBOECHJCML_EvMusicIdCrypted; // 0x14
		public long PCLNFCNIECH_OpenAtCrypted; // 0x18
		public long HHPIJHADAOB_CloseAtCrypted; // 0x20

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB; } } //0x11E88D0 DEMEPMAEJOO 0x11E88DC HIGKAIDMOKN
		public int PLALNIIBLOF_Enabled { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB; } } //0x11E88EC JPCJNLHHIPE 0x11E88FC JJFJNEJLBDG
		public int KOJMEPJBOJM_EvMusicId { get { return OGBOECHJCML_EvMusicIdCrypted ^ FBGGEFFJJHB; } set { OGBOECHJCML_EvMusicIdCrypted = value ^ FBGGEFFJJHB; } } //0x11E890C JFLEJAJJMPF 0x11E891C DLOCAEEEJAE
		public long PDBPFJJCADD_OpenAt { get { return PCLNFCNIECH_OpenAtCrypted ^ FBGGEFFJJHB; } set { PCLNFCNIECH_OpenAtCrypted = value ^ FBGGEFFJJHB; } } //0x11E892C FOACOMBHPAC 0x11E8944 NBACOBCOJCA
		public long FDBNFFNFOND_CloseAt { get { return HHPIJHADAOB_CloseAtCrypted ^ FBGGEFFJJHB; } set { HHPIJHADAOB_CloseAtCrypted = value ^ FBGGEFFJJHB; } } //0x11E8958 BPJOGHJCLDJ 0x11E8970 NLJKMCHOCBK

		//// RVA: 0x11E8984 Offset: 0x11E8984 VA: 0x11E8984
		//public void LHPDDGIJKNB(int PPFNGGCBJKC, int KNEFBLHBDBG) { }

		//// RVA: 0x11E89B4 Offset: 0x11E89B4 VA: 0x11E89B4
		//public void KHEKNNFCAOI(int PPFNGGCBJKC, int KNEFBLHBDBG, EDOHBJAPLPF IDLHJIOMJBK) { }

		//// RVA: 0x11E8C14 Offset: 0x11E8C14 VA: 0x11E8C14
		public void KHEKNNFCAOI(int PPFNGGCBJKC_, int KNEFBLHBDBG, OPHFFGFJIBJ JMHECKKKMLK)
		{
			FBGGEFFJJHB = KNEFBLHBDBG;
			PPFNGGCBJKC_Id = PPFNGGCBJKC_;
			PLALNIIBLOF_Enabled = 0;
			KOJMEPJBOJM_EvMusicId = 0;
			PDBPFJJCADD_OpenAt = 0;
			FDBNFFNFOND_CloseAt = 0;
			HJEKNHMEPBP data = JMHECKKKMLK.PLHPEOKOMHH[PPFNGGCBJKC_ - 1];
			PPFNGGCBJKC_Id = (int)data.PPFNGGCBJKC;
			PLALNIIBLOF_Enabled = (int)data.PLALNIIBLOF;
			KOJMEPJBOJM_EvMusicId = (int)data.KOJMEPJBOJM;
			PDBPFJJCADD_OpenAt = data.PDBPFJJCADD;
			FDBNFFNFOND_CloseAt = data.FDBNFFNFOND;
		}

		//// RVA: 0x11E8DAC Offset: 0x11E8DAC VA: 0x11E8DAC
		//public uint CAOGDCBPBAN() { }
	}

	public class EIIMIHPLDFJ
	{
		public int FBGGEFFJJHB; // 0x8
		public int EHOIENNDEDH_IdCrypted; // 0xC
		public int HNJHPNPFAAN_EnabledCrypted; // 0x10
		public int AGACCBBEEDJ_EmblemIdCrypted; // 0x14
		public int PCFFCAAIPNB_ScCrypted; // 0x18
		public int[] NDOGDOPFNEG_Pnt = new int[4]; // 0x1C
		public int LNCOADKBAAP_ExBnsCrypted; // 0x20
		public int LGFBLINAGGI_BMinCrypted; // 0x24
		public int FNHJGFMGBDK_BMaxCrypted; // 0x28
		public int GPAKDLBNIOI_AMinCrypted; // 0x2C
		public int CLGFJMEKLKH_AMaxCrypted; // 0x30
		public int AJKKBHJHHLA_SMinCrypted; // 0x34
		public int MJBNEHAKLGP_SMaxCrypted; // 0x38
		public int FOJMCKKDDHP_ExMinCrypted; // 0x3C
		public int LOFGKCCABFA_ExMaxCrypted; // 0x40

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB; } set { value = EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB; } } //0x11E734C DEMEPMAEJOO 0x11E735C HIGKAIDMOKN
		public int PLALNIIBLOF_Enabled { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB; } set { value = HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB; } } //0x11E736C JPCJNLHHIPE 0x11E737C JJFJNEJLBDG
		public int APGKOJKNNGP_EmblemId { get { return AGACCBBEEDJ_EmblemIdCrypted ^ FBGGEFFJJHB; } set { value = AGACCBBEEDJ_EmblemIdCrypted ^ FBGGEFFJJHB; } } //0x11E738C KGLCIOHDBLL 0x11E739C DJKADEGEAHE
		public int AFKHNFBOMKI_Sc { get { return PCFFCAAIPNB_ScCrypted ^ FBGGEFFJJHB; } set { value = PCFFCAAIPNB_ScCrypted ^ FBGGEFFJJHB; } } //0x11E73AC NMHOKCJEIDP 0x11E73BC MPFMEIDKANE
		public int GCPKJPNENJJ_ExBns { get { return LNCOADKBAAP_ExBnsCrypted ^ FBGGEFFJJHB; } set { value = LNCOADKBAAP_ExBnsCrypted ^ FBGGEFFJJHB; } } //0x11E73CC DEFEJOEMOBM 0x11E73DC POILGINHMFI
		public int FLOAHHHAOLE_BMin { get { return LGFBLINAGGI_BMinCrypted ^ FBGGEFFJJHB; } set { value = LGFBLINAGGI_BMinCrypted ^ FBGGEFFJJHB; } } //0x11E73EC LFPPNCDDIIL 0x11E73FC AANNOOHGHHI
		public int COJMPBFFJFI_BMax { get { return FNHJGFMGBDK_BMaxCrypted ^ FBGGEFFJJHB; } set { value = FNHJGFMGBDK_BMaxCrypted ^ FBGGEFFJJHB; } } //0x11E740C JPPCEEKHOFC 0x11E741C HIOGIOLAEOI
		public int KPFDEBIEAME_AMin { get { return GPAKDLBNIOI_AMinCrypted ^ FBGGEFFJJHB; } set { value = GPAKDLBNIOI_AMinCrypted ^ FBGGEFFJJHB; } } //0x11E742C IIMKGJJGKLL 0x11E743C MDFOJINDCCM
		public int MCBDCDLKACL_AMax { get { return CLGFJMEKLKH_AMaxCrypted ^ FBGGEFFJJHB; } set { value = CLGFJMEKLKH_AMaxCrypted ^ FBGGEFFJJHB; } } //0x11E744C GCJBJKEJMPN 0x11E745C GNLEHPCNIFN
		public int JLDNDNNDEEH_SMin { get { return AJKKBHJHHLA_SMinCrypted ^ FBGGEFFJJHB; } set { value = AJKKBHJHHLA_SMinCrypted ^ FBGGEFFJJHB; } } //0x11E746C IONADHGPJOM 0x11E747C EIBPMJPKBMG
		public int LIIIGJFLAAB_SMax { get { return MJBNEHAKLGP_SMaxCrypted ^ FBGGEFFJJHB; } set { value = MJBNEHAKLGP_SMaxCrypted ^ FBGGEFFJJHB; } } //0x11E748C JPIBNDOCFKB 0x11E749C AGFPHGNJJIH
		public int NGNKKFNDEPD_ExMin { get { return FOJMCKKDDHP_ExMinCrypted ^ FBGGEFFJJHB; } set { value = FOJMCKKDDHP_ExMinCrypted ^ FBGGEFFJJHB; } } //0x11E74AC DDOMBIIGHJH 0x11E74BC OHENGMHAJHL
		public int MKOKEGGPFBC_ExMax { get { return LOFGKCCABFA_ExMaxCrypted ^ FBGGEFFJJHB; } set { value = LOFGKCCABFA_ExMaxCrypted ^ FBGGEFFJJHB; } } //0x11E74CC LGAMCIJDOOL 0x11E74DC CJGNIOCOPEO

		//// RVA: 0x11E74EC Offset: 0x11E74EC VA: 0x11E74EC
		public int KEJKLJNJJDB(int FNEIADJMHHO)
		{
			if(FNEIADJMHHO > 3)
				return 0;
			return NDOGDOPFNEG_Pnt[FNEIADJMHHO] ^ FBGGEFFJJHB;
		}

		//// RVA: 0x11E754C Offset: 0x11E754C VA: 0x11E754C
		public bool PEBPOMMIHIC(int FNEIADJMHHO, int JBGEEPFKIGG)
		{
			NDOGDOPFNEG_Pnt[FNEIADJMHHO] = JBGEEPFKIGG ^ FBGGEFFJJHB;
			return true;
		}

		//// RVA: 0x11E75B4 Offset: 0x11E75B4 VA: 0x11E75B4
		public void LHPDDGIJKNB(int PPFNGGCBJKC_, int KNEFBLHBDBG)
		{
			FBGGEFFJJHB = KNEFBLHBDBG;
			PPFNGGCBJKC_Id = PPFNGGCBJKC_;
			PLALNIIBLOF_Enabled = 0;
			APGKOJKNNGP_EmblemId = 0;
			AFKHNFBOMKI_Sc = 0;
			MKOKEGGPFBC_ExMax = 0;
			GCPKJPNENJJ_ExBns = 0;
			FLOAHHHAOLE_BMin = 0;
			COJMPBFFJFI_BMax = 0;
			KPFDEBIEAME_AMin = 0;
			MCBDCDLKACL_AMax = 0;
			JLDNDNNDEEH_SMin = 0;
			LIIIGJFLAAB_SMax = 0;
			NGNKKFNDEPD_ExMin = 0;
			for(int i = 0; i < 4; i++)
			{
				PEBPOMMIHIC(i, 0);
			}
		}

		//// RVA: 0x11E7614 Offset: 0x11E7614 VA: 0x11E7614
		//public void KHEKNNFCAOI(int PPFNGGCBJKC, int KNEFBLHBDBG, EDOHBJAPLPF IDLHJIOMJBK) { }

		//// RVA: 0x11E7BA4 Offset: 0x11E7BA4 VA: 0x11E7BA4
		public void KHEKNNFCAOI(int PPFNGGCBJKC_, int KNEFBLHBDBG, OPHFFGFJIBJ JMHECKKKMLK)
		{
			LHPDDGIJKNB(PPFNGGCBJKC_, KNEFBLHBDBG);
			HIGMGCAKFAN data = JMHECKKKMLK.NIPMOFJPFJG[PPFNGGCBJKC_ - 1];
			PPFNGGCBJKC_Id = (int)data.PPFNGGCBJKC;
			PLALNIIBLOF_Enabled = (int)data.PLALNIIBLOF;
			APGKOJKNNGP_EmblemId = (int)data.APGKOJKNNGP;
			AFKHNFBOMKI_Sc = (int)data.AFKHNFBOMKI;
			GCPKJPNENJJ_ExBns = (int)data.GCPKJPNENJJ;
			FLOAHHHAOLE_BMin = (int)data.FLOAHHHAOLE;
			COJMPBFFJFI_BMax = (int)data.COJMPBFFJFI;
			KPFDEBIEAME_AMin = (int)data.KPFDEBIEAME;
			MCBDCDLKACL_AMax = (int)data.MCBDCDLKACL;
			JLDNDNNDEEH_SMin = (int)data.JLDNDNNDEEH;
			LIIIGJFLAAB_SMax = (int)data.LIIIGJFLAAB;
			NGNKKFNDEPD_ExMin = (int)data.NGNKKFNDEPD;
			MKOKEGGPFBC_ExMax = (int)data.MKOKEGGPFBC;
			for(int i = 0; i < data.HHOFENIINIJ.Length; i++)
			{
				PEBPOMMIHIC(i, data.HHOFENIINIJ[i]);
			}
		}

		//// RVA: 0x11E7F08 Offset: 0x11E7F08 VA: 0x11E7F08
		//public uint CAOGDCBPBAN() { }
	}

	public KNLJPCCDPDK NGHKJOEDLIP = new KNLJPCCDPDK(); // 0x20
	public List<BHBICAALJIA> FCIPEDFHFEM = new List<BHBICAALJIA>(); // 0x24
	public List<AKIIJBEJOEP> NNMPGOAGEOL_Missions = new List<AKIIJBEJOEP>(); // 0x28
	public List<LPJIKDAMGPC> AFHHBNBCOKI = new List<LPJIKDAMGPC>(); // 0x2C
	public List<FKACPHEKBNF> OCPGCHOGHPB_DefaultRivals = new List<FKACPHEKBNF>(); // 0x30
	public List<FGBJDLLLBEF> GEGAEDDGNMA = new List<FGBJDLLLBEF>(); // 0x34
	public List<DGBPOCFMKMJ> OGMHMAGDNAM = new List<DGBPOCFMKMJ>(); // 0x38
	public List<GNCIKNGDGPP> LHAKGDAGEMM = new List<GNCIKNGDGPP>(); // 0x3C
	public List<AIGOEAPJGEB> MBHDIJJEOFL = new List<AIGOEAPJGEB>(); // 0x48
	public List<IJNOIMLNBGN> LLCLJBEJOPM_BannerInfo = new List<IJNOIMLNBGN>(); // 0x4C
	public List<OABJKIKLDKP> IJJHFGOIDOK_Songs = new List<OABJKIKLDKP>(); // 0x50
	public List<KGHHHPHBGGM> GCFOLMHPDBG = new List<KGHHHPHBGGM>(); // 0x54
	public List<EIIMIHPLDFJ> PMJLEPGCAOA_ClassDatas = new List<EIIMIHPLDFJ>(); // 0x58

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI { get; private set; } // 0x40 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK { get; private set; } // 0x44 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0x1221010 Offset: 0x1221010 VA: 0x1221010
	public string EFEGBHACJAL(string LJNAKDMILMC, string KKMJBMKHGNH)
	{
		if(FJOEBCMGDMI.ContainsKey(LJNAKDMILMC))
		{
			return FJOEBCMGDMI[LJNAKDMILMC].DNJEJEANJGL_Value;
		}
		return KKMJBMKHGNH;
	}

	//// RVA: 0x12210F4 Offset: 0x12210F4 VA: 0x12210F4
	public int LPJLEHAJADA(string LJNAKDMILMC, int KKMJBMKHGNH)
	{
		if(OHJFBLFELNK.ContainsKey(LJNAKDMILMC))
		{
			return OHJFBLFELNK[LJNAKDMILMC].DNJEJEANJGL_Value;
		}
		return KKMJBMKHGNH;
	}

	// RVA: 0x12211D8 Offset: 0x12211D8 VA: 0x12211D8
	public ICFLJACCIKF_EventBattle()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		FJOEBCMGDMI = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		OHJFBLFELNK = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		LMHMIIKCGPE = 28;
	}

	// RVA: 0x1221594 Offset: 0x1221594 VA: 0x1221594 Slot: 8
	protected override void KMBPACJNEOF()
	{
		NGHKJOEDLIP.LHPDDGIJKNB();
		FCIPEDFHFEM.Clear();
		OHJFBLFELNK.Clear();
		FJOEBCMGDMI.Clear();
		AFHHBNBCOKI.Clear();
		OCPGCHOGHPB_DefaultRivals.Clear();
		MBHDIJJEOFL.Clear();
		LLCLJBEJOPM_BannerInfo.Clear();
		IJJHFGOIDOK_Songs.Clear();
		GCFOLMHPDBG.Clear();
		PMJLEPGCAOA_ClassDatas.Clear();
		GEGAEDDGNMA.Clear();
		OGMHMAGDNAM.Clear();
		LHAKGDAGEMM.Clear();
	}

	// RVA: 0x122183C Offset: 0x122183C VA: 0x122183C Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		OPHFFGFJIBJ data = OPHFFGFJIBJ.HEGEKFMJNCC(DBBGALAPFGC);
		DGKKMKLCEDF(data);
		GPEKKMGGBPF(data);
		CFOFJPLEDEA(data);
		NFNBOEMGDPO(data);
		CMHJFPJFKAP(data);
		GJEHPJJBCDE(data);
		CDLNFNMFEEL(data);
		GMHGKHOBEKH(data);
		EGLHCMDNFOE(data);
		JBNBGGDDEGG(data);
		ABICOINNGEK(data);
		for(int i = 0; i < data.BHGDNGHDDAC.Length; i++)
		{
			CEBFFLDKAEC_SecureInt d = new CEBFFLDKAEC_SecureInt();
			d.DNJEJEANJGL_Value = data.BHGDNGHDDAC[i].JBGEEPFKIGG;
			OHJFBLFELNK.Add(data.BHGDNGHDDAC[i].LJNAKDMILMC, d);
		}
		for(int i = 0; i < data.MHGMDJNOLMI.Length; i++)
		{
			NNJFKLBPBNK_SecureString d = new NNJFKLBPBNK_SecureString();
			d.DNJEJEANJGL_Value = data.MHGMDJNOLMI[i].JBGEEPFKIGG;
			FJOEBCMGDMI.Add(data.MHGMDJNOLMI[i].LJNAKDMILMC, d);
		}
		AIGOEAPJGEB.KHEKNNFCAOI(MBHDIJJEOFL, data);
		IJNOIMLNBGN.KHEKNNFCAOI(LLCLJBEJOPM_BannerInfo, data);

		// Update dates
		UMOEventList.EventData CurrenEvent = UMOEventList.GetCurrentEvent();
		if (CurrenEvent != null && CurrenEvent.BlockName == JIKKNHIAEKG_BlockName)
		{
			System.DateTime date = Utility.GetLocalDateTime(Utility.GetCurrentUnixTime());
			System.DateTime date2 = Utility.GetLocalDateTime(NGHKJOEDLIP.BONDDBOFBND_Start);
			date = date.AddDays(-1);
			long offset = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, date2.Hour, date2.Minute, date2.Second) - NGHKJOEDLIP.BONDDBOFBND_Start;
			if (NGHKJOEDLIP.BONDDBOFBND_Start != 0) NGHKJOEDLIP.BONDDBOFBND_Start += offset;
			if (NGHKJOEDLIP.HPNOGLIFJOP_End1 != 0) NGHKJOEDLIP.HPNOGLIFJOP_End1 += offset;
			if (NGHKJOEDLIP.LNFKGHNHJKE != 0) NGHKJOEDLIP.LNFKGHNHJKE += offset;
			if (NGHKJOEDLIP.JGMDAOACOJF != 0) NGHKJOEDLIP.JGMDAOACOJF += offset;
			if (NGHKJOEDLIP.IDDBFFBPNGI != 0) NGHKJOEDLIP.IDDBFFBPNGI += offset;
			if (NGHKJOEDLIP.KNLGKBBIBOH_End != 0) NGHKJOEDLIP.KNLGKBBIBOH_End += offset;

			for(int i = 0; i < IJJHFGOIDOK_Songs.Count; i++)
			{
				if (IJJHFGOIDOK_Songs[i].PDBPFJJCADD_OpenAt != 0) IJJHFGOIDOK_Songs[i].PDBPFJJCADD_OpenAt = NGHKJOEDLIP.BONDDBOFBND_Start;
				if (IJJHFGOIDOK_Songs[i].FDBNFFNFOND_CloseAt != 0) IJJHFGOIDOK_Songs[i].FDBNFFNFOND_CloseAt = NGHKJOEDLIP.HPNOGLIFJOP_End1;
			}
			for(int i = 0; i < GCFOLMHPDBG.Count; i++)
			{
				if (GCFOLMHPDBG[i].PDBPFJJCADD_OpenAt != 0) GCFOLMHPDBG[i].PDBPFJJCADD_OpenAt = NGHKJOEDLIP.BONDDBOFBND_Start;
				if (GCFOLMHPDBG[i].FDBNFFNFOND_CloseAt != 0) GCFOLMHPDBG[i].FDBNFFNFOND_CloseAt = NGHKJOEDLIP.HPNOGLIFJOP_End1;
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

	// RVA: 0x122413C Offset: 0x122413C VA: 0x122413C Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.LogError(TodoLogger.DbJson, "ICFLJACCIKF_EventBattle.IIEMACPEEBJ");
		return true;
	}

	//// RVA: 0x1221BB0 Offset: 0x1221BB0 VA: 0x1221BB0
	private bool DGKKMKLCEDF(OPHFFGFJIBJ JMHECKKKMLK)
	{
		NKCJNCELIJN data = JMHECKKKMLK.HMBHNLCFDIH;
		NGHKJOEDLIP.OBGBAOLONDD = (int)data.OBGBAOLONDD;
		NGHKJOEDLIP.OPFGFINHFCE = data.OPFGFINHFCE;
		NGHKJOEDLIP.HEDAGCNPHGD = data.HEDAGCNPHGD;
		NGHKJOEDLIP.IDGAEEJLGIK = data.IDGAEEJLGIK;
		NGHKJOEDLIP.OCGFKMHNEOF = data.OCGFKMHNEOF;
		NGHKJOEDLIP.OGMGLOFKKPA = data.OGMGLOFKKPA;
		NGHKJOEDLIP.BONDDBOFBND_Start = data.BONDDBOFBND;
		NGHKJOEDLIP.HPNOGLIFJOP_End1 = data.HPNOGLIFJOP;
		NGHKJOEDLIP.EHHFFKAFOMC = data.EHHFFKAFOMC;
		NGHKJOEDLIP.LNFKGHNHJKE = data.LNFKGHNHJKE;
		NGHKJOEDLIP.JGMDAOACOJF = data.JGMDAOACOJF;
		NGHKJOEDLIP.IDDBFFBPNGI = data.IDDBFFBPNGI;
		NGHKJOEDLIP.KNLGKBBIBOH_End = data.KNLGKBBIBOH;
		NGHKJOEDLIP.JBFDHOIKAIK_InventoryEndDate = data.JBFDHOIKAIK;
		NGHKJOEDLIP.KHIKEGLBGAF = (int)data.KHIKEGLBGAF;
		NGHKJOEDLIP.DPJCFLKFEPN = (int)data.DPJCFLKFEPN;
		NGHKJOEDLIP.POGEFBMBPCB = (sbyte)data.JMJDLDEIFKE;
		NGHKJOEDLIP.AHKNMANFILO = (sbyte)data.AHKNMANFILO;
		NGHKJOEDLIP.MOEKELIIDEO_SaveIdx = (sbyte)data.MOEKELIIDEO;
		NGHKJOEDLIP.OCDMGOGMHGE = data.OCDMGOGMHGE;
		NGHKJOEDLIP.PJBILOFOCIC = data.PJBILOFOCIC;
		NGHKJOEDLIP.MJBKGOJBPAD = data.MJBKGOJBPAD;
		NGHKJOEDLIP.FEMMDNIELFC = data.FEMMDNIELFC;
		NGHKJOEDLIP.HKKNEAGCIEB = (sbyte)data.HKKNEAGCIEB;
		NGHKJOEDLIP.HIOOGLEJBKM = data.HIOOGLEJBKM;
		NGHKJOEDLIP.FJCADCDNPMP = data.FJCADCDNPMP;
		NGHKJOEDLIP.EJBGHLOOLBC_HelpsId = data.EJBGHLOOLBC;
		NGHKJOEDLIP.AHKPNPNOAMO = (sbyte)data.AHKPNPNOAMO;
		NGHKJOEDLIP.OMCAOJJGOGG = data.OMCAOJJGOGG;
		NGHKJOEDLIP.EKJFNHHKBPL = data.EKJFNHHKBPL;
		NGHKJOEDLIP.JKFPADIAKCK = data.JKFPADIAKCK;
		for(int i = 0; i < data.JHPCPNJJHLI.Length; i++)
		{
			if(data.JHPCPNJJHLI[i] < 1001)
			{
				NGHKJOEDLIP.JHPCPNJJHLI.Add(data.JHPCPNJJHLI[i]);
			}
		}
		for(int i = 0; i < data.HIAMHLLHAON.Length; i++)
		{
			if(i < data.HIAMHLLHAON.Length / 2)
				NGHKJOEDLIP.PFGFMLEEDLN((int)data.HIAMHLLHAON[i]);
			else
				NGHKJOEDLIP.OJLPDKAKDMC((int)data.HIAMHLLHAON[i]);
		}
		NGHKJOEDLIP.EEOGPJJCKHH_Drops.Clear();
		for(int i = 0; i < data.EEOGPJJCKHH.Length; i++)
		{
			NGHKJOEDLIP.EEOGPJJCKHH_Drops.Add((int)data.EEOGPJJCKHH[i]);
		}
		return true;
	}

	//// RVA: 0x1224144 Offset: 0x1224144 VA: 0x1224144
	//private bool DGKKMKLCEDF(EDOHBJAPLPF IDLHJIOMJBK, int KAPMOPMDHJE) { }

	//// RVA: 0x122414C Offset: 0x122414C VA: 0x122414C
	//private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, EDOHBJAPLPF OBHAFLMHAKG, string OPFGFINHFCE, ref bool NGJDHLGMHMH) { }

	//// RVA: 0x122432C Offset: 0x122432C VA: 0x122432C
	//private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, string OAIBJJHGCNM) { }

	//// RVA: 0x12226A0 Offset: 0x12226A0 VA: 0x12226A0
	private bool GPEKKMGGBPF(OPHFFGFJIBJ JMHECKKKMLK)
	{
		for(int i = 0; i < JMHECKKKMLK.MCHFABAKPMH.Length; i++)
		{
			FPJPKBBOICF array = JMHECKKKMLK.MCHFABAKPMH[i];
			BHBICAALJIA data = new BHBICAALJIA();
			data.PPFNGGCBJKC = (int)array.PPFNGGCBJKC;
			data.DNBFMLBNAEE = (int)array.FOILNHKHHDF;
			data.JOPPFEHKNFO = array.JOPPFEHKNFO != 0;
			for(int j = 0; j < array.AIHOJKFNEEN.Length; j++)
			{
				BEFNBMEMFOB data2 = new BEFNBMEMFOB();
				data2.GLCLFMGPMAN = array.AIHOJKFNEEN[j];
				data2.HMFFHLPNMPH = (int)array.BFINGCJHOHI[j];
				data2.NMKEOMCMIPP = (int)array.JJHPDDPKBHF[j];
				data2.HJAFPEBIBOP = (int)array.HJAFPEBIBOP[j];
				data.AHJNPEAMCCH.Add(data2);
			}
			FCIPEDFHFEM.Add(data);
		}
		return true;
	}

	//// RVA: 0x12244C8 Offset: 0x12244C8 VA: 0x12244C8
	//private bool GPEKKMGGBPF(EDOHBJAPLPF OBHAFLMHAKG, int KAPMOPMDHJE) { }

	//// RVA: 0x1222AF4 Offset: 0x1222AF4 VA: 0x1222AF4
	private bool CFOFJPLEDEA(OPHFFGFJIBJ JMHECKKKMLK)
	{
		long time = Utility.GetCurrentUnixTime();
		int xor = (int)time * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.MDDOGIAFDEI.Length; i++)
		{
			AKIIJBEJOEP data = new AKIIJBEJOEP();
			data.KHEKNNFCAOI(JIKKNHIAEKG_BlockName, i + 1, xor, JMHECKKKMLK);
			NNMPGOAGEOL_Missions.Add(data);
			xor += 13;
		}
		return true;
	}

	//// RVA: 0x12244D0 Offset: 0x12244D0 VA: 0x12244D0
	//private bool CFOFJPLEDEA(EDOHBJAPLPF OBHAFLMHAKG, int KAPMOPMDHJE) { }

	//// RVA: 0x1222C8C Offset: 0x1222C8C VA: 0x1222C8C
	private bool NFNBOEMGDPO(OPHFFGFJIBJ JMHECKKKMLK)
	{
		long time = Utility.GetCurrentUnixTime();
		int xor = (int)time * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.DDIGKGINBKL.Length; i++)
		{
			EBDMGCHHCFD array = JMHECKKKMLK.DDIGKGINBKL[i];
			LPJIKDAMGPC data = new LPJIKDAMGPC();
			data.FBGGEFFJJHB = xor;
			data.EEAPIKNJNDB = array.EEAPIKNJNDB;
			data.NNDBJGDFEEM = array.NNDBJGDFEEM;
			data.DOOGFEGEKLG = array.DOOGFEGEKLG;
			data.HNDOLKNBOIJ = array.HNDOLKNBOIJ;
			data.HHGFOIMIGED = array.HHGFOIMIGED;
			data.IBCMDICBGHH = array.IBCMDICBGHH;
			data.HKAILALAFDG = array.HKAILALAFDG;
			data.DJJGNDCMNHF = array.DJJGNDCMNHF;
			AFHHBNBCOKI.Add(data);
			xor += 13;
		}
		return true;
	}

	//// RVA: 0x1222FC0 Offset: 0x1222FC0 VA: 0x1222FC0
	private bool CMHJFPJFKAP(OPHFFGFJIBJ JMHECKKKMLK)
	{
		long time = Utility.GetCurrentUnixTime();
		int xor = (int)time * 11 + 1;
        LCLCCHLDNHJ_Costume cosDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume;
        for (int i = 0; i < JMHECKKKMLK.MDMKOGDHCIC.Length; i++)
		{
			BAJEBICKGPF array = JMHECKKKMLK.MDMKOGDHCIC[i];
			FKACPHEKBNF data = new FKACPHEKBNF();
			data.FBGGEFFJJHB = xor;
			data.BEEAIAAJOHD_CostumeId = 0;
			if(array.JFFOEAANFPG != 0)
			{
                LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = cosDb.NLIBHNJNJAN_GetUnlockedCostumeOrDefault(array.DIPKCALNIII, array.JFFOEAANFPG);
                if (cos != null)
				{
					data.BEEAIAAJOHD_CostumeId = cos.JPIDIENBGKH_CostumeId;
				}
			}
			data.AKNELONELJK_Difficulty = array.AKNELONELJK;
			data.DIPKCALNIII_DivaId = array.DIPKCALNIII;
			data.HEBKEJBDCBH_DivaLevel = array.HEBKEJBDCBH;
			data.PLALNIIBLOF_Enabled = array.PLALNIIBLOF;
			data.GOIKCKHMBDL_FreeMusicId = array.GOIKCKHMBDL;
			data.PPFNGGCBJKC = array.PPFNGGCBJKC;
			data.GLILAGLJLEP_SceneId = array.GLILAGLJLEP;
			data.ECOLMPLOPFM_SceneLevel = array.ECOLMPLOPFM;
			data.CFCIMKOHLIG_Mlt = array.CFCIMKOHLIG;
			data.BDLNMOIOMHK_TotalStats = array.BDLNMOIOMHK;
			data.NLKEBAOBJCM_ComboRatio = array.NLKEBAOBJCM;
			data.OPFGFINHFCE_Name = array.OPFGFINHFCE;
			for(int j = 0; j < array.MJNMPAKBNKB.Length; j++)
			{
				data.MJNMPAKBNKB_NotesResult[j] = array.MJNMPAKBNKB[j];
			}
			data.EDJMDDAGCEJ_Score1 = array.EDJMDDAGCEJ;
			data.HEFPAIOLBAG_Score2 = array.HEFPAIOLBAG;
			data.KNIFCANOHOC_Score = array.KNIFCANOHOC;
			data.IPPNCOHEEOD_ScoreAverage = array.IPPNCOHEEOD;
			data.ENNCJKLIGKE_Luck = array.ENNCJKLIGKE;
			data.PALEGNNHIKH_Leaf = array.PALEGNNHIKH;
			data.JCDEDIOAGKE_ExcellentRatio = array.JCDEDIOAGKE;
			OCPGCHOGHPB_DefaultRivals.Add(data);
			xor = xor * 3 + 13;
		}
		return true;
	}

	//// RVA: 0x1223824 Offset: 0x1223824 VA: 0x1223824
	private bool GJEHPJJBCDE(OPHFFGFJIBJ JMHECKKKMLK)
	{
		long time = Utility.GetCurrentUnixTime();
		int xor = (int)time * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.GHIHAGAOPNC.Length; i++)
		{
			OABJKIKLDKP data = new OABJKIKLDKP();
			data.KHEKNNFCAOI(i + 1, xor, JMHECKKKMLK);
			IJJHFGOIDOK_Songs.Add(data);
			xor = xor * 3 + 13;
		}
		return true;
	}

	//// RVA: 0x12244D8 Offset: 0x12244D8 VA: 0x12244D8
	//private bool GJEHPJJBCDE(EDOHBJAPLPF OBHAFLMHAKG, int KAPMOPMDHJE) { }

	//// RVA: 0x12239A8 Offset: 0x12239A8 VA: 0x12239A8
	private bool CDLNFNMFEEL(OPHFFGFJIBJ JMHECKKKMLK)
	{
		long time = Utility.GetCurrentUnixTime();
		int xor = (int)time * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.PLHPEOKOMHH.Length; i++)
		{
			KGHHHPHBGGM data = new KGHHHPHBGGM();
			data.KHEKNNFCAOI(i + 1, xor, JMHECKKKMLK);
			GCFOLMHPDBG.Add(data);
			xor = xor * 3 + 13;
		}
		return true;
	}

	//// RVA: 0x12244E0 Offset: 0x12244E0 VA: 0x12244E0
	//private bool CDLNFNMFEEL(EDOHBJAPLPF OBHAFLMHAKG, int KAPMOPMDHJE) { }

	//// RVA: 0x1223B2C Offset: 0x1223B2C VA: 0x1223B2C
	private bool GMHGKHOBEKH(OPHFFGFJIBJ JMHECKKKMLK)
	{
		long time = Utility.GetCurrentUnixTime();
		int xor = (int)time * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.NIPMOFJPFJG.Length; i++)
		{
			EIIMIHPLDFJ data = new EIIMIHPLDFJ();
			data.KHEKNNFCAOI(i + 1, xor, JMHECKKKMLK);
			PMJLEPGCAOA_ClassDatas.Add(data);
			xor = xor * 3 + 13;
		}
		return true;
	}

	//// RVA: 0x12244E8 Offset: 0x12244E8 VA: 0x12244E8
	//private bool GMHGKHOBEKH(EDOHBJAPLPF OBHAFLMHAKG, int KAPMOPMDHJE) { }

	//// RVA: 0x1223E34 Offset: 0x1223E34 VA: 0x1223E34
	private bool JBNBGGDDEGG(OPHFFGFJIBJ JMHECKKKMLK)
	{
		long time = Utility.GetCurrentUnixTime();
		int xor = (int)time * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.OLACFKILCFD.Length; i++)
		{
			FGBJDLLLBEF data = new FGBJDLLLBEF();
			data.BAFFAONJPCE(i, xor, JMHECKKKMLK);
			GEGAEDDGNMA.Add(data);
			xor = xor * 3 + 13;
		}
		return true;
	}

	//// RVA: 0x1223FB8 Offset: 0x1223FB8 VA: 0x1223FB8
	private bool ABICOINNGEK(OPHFFGFJIBJ JMHECKKKMLK)
	{
		long time = Utility.GetCurrentUnixTime();
		int xor = (int)time * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.MIOCOKLMLBD.Length; i++)
		{
			DGBPOCFMKMJ data = new DGBPOCFMKMJ();
			data.BAFFAONJPCE(i, xor, JMHECKKKMLK);
			OGMHMAGDNAM.Add(data);
			xor = xor * 3 + 13;
		}
		return true;
	}

	//// RVA: 0x1223CB0 Offset: 0x1223CB0 VA: 0x1223CB0
	private bool EGLHCMDNFOE(OPHFFGFJIBJ JMHECKKKMLK)
	{
		long time = Utility.GetCurrentUnixTime();
		int xor = (int)time * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.IEJLJIHIDJC.Length; i++)
		{
			GNCIKNGDGPP data = new GNCIKNGDGPP();
			data.BAFFAONJPCE(i, xor, JMHECKKKMLK);
			LHAKGDAGEMM.Add(data);
			xor = xor * 3 + 13;
		}
		return true;
	}

	// RVA: 0x12244F0 Offset: 0x12244F0 VA: 0x12244F0 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "ICFLJACCIKF_EventBattle.CAOGDCBPBAN");
		return 0;
	}
}
