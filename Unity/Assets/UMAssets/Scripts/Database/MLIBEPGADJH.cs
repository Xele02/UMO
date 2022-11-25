using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;

public class MLIBEPGADJH { }
public class MLIBEPGADJH_Scene : DIHHCBACKGG_DbSection
{
	public class KKLDOOJBJMN
	{
		public int JFLFKAKFKJJ_Hp1; // 0x44
		public int BMCPCMPAOEP_Ch1; // 0x48
		public int LAGMNJFONLB_Nx1; // 0x4C
		public int JBFJGPMANNM_So1; // 0x50
		public int MGBKEMHECLA_Vo1; // 0x54
		public int FCPKKHPHPMO_Fd1; // 0x58
		public int HBBAIDHNJFH_Sp1; // 0x5C
		public int FBGGEFFJJHB; // 0x60
		public int KIEJFFPDDLJ_Gdrp; // 0x88
		public int HKGLDLJDILN_Odrp; // 0x8C
		public byte[] OCKJIHPHMDE; // 0x98

		public int BCCHOBPJJKE_Id { get; set; } // 0x8 BNOLCKHMAAH COHCNONLPAC HJEBBEHGHGG
		public SeriesAttr.Type AIHCEGFANAM_Serie { get; set; } // 0xC FJOGAAMLJMA ANEJPLENMAL HEHDOGFEIOL
		public SeriesLogoId.Type EMIKBGHIOMN_SerieLogo { get; set; } // 0x10 CCEIEDMCHLA BJGJCKFOBCA OAKIKBEEACC
		public sbyte EKLIPGELKCL_Rarity { get; set; } // 0x14 DMGPKEIBKHJ OEEHBGECGKL GHLMHLJJBIG
		public sbyte PPEGAKEIEGM_En { get; set; } // 0x15 NEKLJCCBECB KPOEEPIMMJP NCIEAFEDPBH
		public sbyte FKDCCLPGKDK_Ma { get; set; } // 0x16 KLMKEFEMHOC FBADKBMGIBP NCNMMABFHGN
		public int AOLIJKMIJJE_Dv { get; set; } // 0x18 HPEJJNAIFNP DLNCBNNPHCL CBAJOLNBJNP
		public short KELFCMEOPPM_Ep { get; set; } // 0x1C LOEOGJLMNME AHJNJHDELBE PJLFKEOLFMK
		public bool MCCIFLKCNKO_Feed { get; set; } // 0x1E JFDLAEKGPAO JCFCNLOHIBN JMENCPKNKHI
		public bool FBJDHLGODPP_Sngl { get; set; } // 0x1F KKEAHIOMHMG LGDHJNNBNIE JMKPCLFDLHD
		public int LFPEIEOHABE_Pstv { get; set; }  // 0x20 AODEGDMPLMN DGNJINLAEEA KHPCMIMBPME
		public int HFIDCMNFBJG_Hp { get; set; } // 0x24 HINMKMNCGFJ CMDOHPBAFCO BJBDGCMJNEO
		public int PFJCOCPKABN_So { get; set; } // 0x28 GNAPLLPFDEH EJPPLFNLAAO NEMMJEJENFD
		public int JFJDLEMNKFE_Vo { get; set; } // 0x2C HGANCHPKOEG GCMPLDKECFM CEHKELOHIBD
		public int GDOLPGBLMEA_Ch { get; set; } // 0x30 GMPHNADBLAP LEHDODJMICA IKPOCJDOOGA
		public int HCFOMFDPGEC_Sp { get; set; } // 0x34 LFNHOBGPDAI GGIDKCOMCJL LAIHOHGICJD
		public int ONDFNOOICLE_Fd { get; set; } // 0x38 JLJACODCBIK OGGOHKCANFG BKMHMPEBNPE
		public int FLGDCCFAGEL_Nx { get; set; } // 0x3C BPPACKLALEM OMHMJGDMACK EJIJEKLDDOH
		public int JIJOGLFOOMN_Aver { get; set; } // 0x40 MCJCIKOEOHH AEOFOBJHHHN FDHKHDIKPKE
		// public int JABFJHJFJEO { get; set; } // MIAFAEEAIEG 0x196242C DLKALAPFCFK 0x19607AC
		// public int EFMJLKIFNJK { get; set; } // LAMFLFENKJF 0x196243C BHJKJCOFKLO 0x19607BC
		// public int EGNCKFNALIA { get; set; } // CKJKINNOKIL 0x196244C JIOKNPPGIKO 0x19607CC
		// public int OIOABIDEJPG { get; set; } // NGHMJMNLNIE 0x196245C AFKDHCJPFEI 0x19607DC
		// public int DCICNKHCBJK { get; set; } // GEDMBCPNFHI 0x196246C DEBIACKNCLF 0x19607EC
		// public int EANBFFCPKOO { get; set; } // MOCNJMBAJKK 0x196247C FJBKNIFMKEJ 0x19607FC
		public int GPAOEGPMBOJ { get { return LAGMNJFONLB_Nx1 ^ FBGGEFFJJHB; } set { LAGMNJFONLB_Nx1 = value ^ FBGGEFFJJHB; } } // KEMDEJKPDOG 0x196248C LJJNJENJGHK 0x196080C
		public int EMAGAIKNHDN_CS { get; set; } // 0x64 DAMNLKLGGAI EBHLKAEBFCE ONOKGLFKJLK
		public int AEIBPIEIBFO_CS2 { get; set; } // 0x68 KNMELHKEPDB KDFOMMHFGBL CKLAPJMCGOJ
		public int PBEPKDEEBBK_AS { get; set; } // 0x6C HOOPPDKEPIP MPMNIGEOBOC CDJEALCHFKL
		public int ECKJJCGPOPN_AS2 { get; set; } // 0x70 IJMEDLIHHPM LKFHCJFFMAJ MLJAIDJHMAI
		public int KPIIIEGGPIB_LS { get; set; } // 0x74 PJNCJOIODGP DPMKOIOIADB PFKMHCNPLLB
		public int PJKJFIOKBGJ_LS2 { get; set; } // 0x78 DPCGBPLOHJE EGNELMIPIIO FANPLCAHHNP
		public short BJNBBEMBMIK_Bd { get; set; } // 0x7C PJFIENAGLNL LFOMFGJDJDI EABGNGKHJAO
		public short AOPBAOJIOGO_Sb { get; set; } // 0x7E IKKNPDLNPKH HDLCEEHNBKN AGKAANFCJIP
		public int ILABPFOMEAG_Va { get; set; }  // 0x80 OMFFPPDGOPE ICFAOLCLHIA LIJJLCOMANF
		public int FIHNJFKBKBD_Note { get; set; }  // 0x84 CHOBNFJBALL KLEAPKCDDHN NICEKBABGLD
		// public int LDMOHIKFDEK { get; set; } // IJCCFFMMALD 0x19624D4 MJDCIIBOHIL 0x1960874
		// public int FPHOPBNPCML { get; set; } // DILIELECNKD 0x19624E4 PKGHMNIEJAK 0x1960884
		public int GCLAAGFKPPJ_Aofs { get; set; } // 0x90 JHOJALACCGC BBOJJFCLKJF KFMLHEGGPJA
		public List<short> GDHGEECAJGI { get; set; } // 0x94 PNKKMNPCGCO DGIKNGMCPGA CAMLBFJNCIK

		// // RVA: 0x19624FC Offset: 0x19624FC VA: 0x19624FC
		// public int CGMFEOFCKPA(KOGHKIODHPA JEMMMJEJLNL, byte[] KBOLNIBLIND) { }

		// // RVA: 0x19627E8 Offset: 0x19627E8 VA: 0x19627E8
		// public int ONBGNBDIGPF(KOGHKIODHPA JEMMMJEJLNL, byte[] KBOLNIBLIND) { }

		// // RVA: 0x1962808 Offset: 0x1962808 VA: 0x1962808
		// public int DPDGKOBDBJF(KOGHKIODHPA JEMMMJEJLNL, byte[] KBOLNIBLIND) { }

		// // RVA: 0x1962828 Offset: 0x1962828 VA: 0x1962828
		// public int JEDMOOILJOJ(KOGHKIODHPA JEMMMJEJLNL, byte[] KBOLNIBLIND) { }

		// // RVA: 0x1962848 Offset: 0x1962848 VA: 0x1962848
		public int MGKDKGOACDB(KOGHKIODHPA_Board JEMMMJEJLNL, byte[] KBOLNIBLIND)
		{
			return HODFCGGDHGG(JEMMMJEJLNL, IDMPGHMNLHD.NPIEEGNKDEG.GMKEEAPLKHC/*5*/, KBOLNIBLIND);
		}

		// // RVA: 0x1962868 Offset: 0x1962868 VA: 0x1962868
		public int CMPJFHEFIND(KOGHKIODHPA_Board JEMMMJEJLNL, byte[] KBOLNIBLIND)
		{
			return HODFCGGDHGG(JEMMMJEJLNL, IDMPGHMNLHD.NPIEEGNKDEG.DEKFNLBLKEH/*6*/, KBOLNIBLIND);
		}

		// // RVA: 0x1962888 Offset: 0x1962888 VA: 0x1962888
		public int BBGLLMIFPMA(KOGHKIODHPA_Board JEMMMJEJLNL, byte[] KBOLNIBLIND)
		{
			return HODFCGGDHGG(JEMMMJEJLNL, IDMPGHMNLHD.NPIEEGNKDEG.AJKGPEGCJBH/*7*/, KBOLNIBLIND);
		}

		// // RVA: 0x19628A8 Offset: 0x19628A8 VA: 0x19628A8
		// public int OANKNGPCIMG(KOGHKIODHPA JEMMMJEJLNL, byte[] KBOLNIBLIND) { }

		// // RVA: 0x19628C8 Offset: 0x19628C8 VA: 0x19628C8
		// public int EEDCLCMJONO(KOGHKIODHPA JEMMMJEJLNL, byte[] KBOLNIBLIND) { }

		// // RVA: 0x1962040 Offset: 0x1962040 VA: 0x1962040
		// public uint CAOGDCBPBAN() { }

		// // RVA: 0x19608A8 Offset: 0x19608A8 VA: 0x19608A8
		public void LHPDDGIJKNB_Reset(int PPFNGGCBJKC_Id)
		{
			EKLIPGELKCL_Rarity = 1;
			BCCHOBPJJKE_Id = PPFNGGCBJKC_Id;
			AIHCEGFANAM_Serie = SeriesAttr.Type.Delta;
			EMIKBGHIOMN_SerieLogo = SeriesLogoId.Type.DeltaTV;
			FKDCCLPGKDK_Ma = 1;
			AOLIJKMIJJE_Dv = 0;
			KELFCMEOPPM_Ep = 1;
			MCCIFLKCNKO_Feed = false;
			FBJDHLGODPP_Sngl = false;
			GDOLPGBLMEA_Ch = 100;
			HCFOMFDPGEC_Sp = 100;
			ONDFNOOICLE_Fd = 100;
			LFPEIEOHABE_Pstv = 0x64;
			HFIDCMNFBJG_Hp = 0x64;
			PFJCOCPKABN_So = 0x64;
			JFJDLEMNKFE_Vo = 0x64;
			JFLFKAKFKJJ_Hp1 = 100 ^ FBGGEFFJJHB;
			BMCPCMPAOEP_Ch1 = 100 ^ FBGGEFFJJHB;
			JBFJGPMANNM_So1 = 0;
			MGBKEMHECLA_Vo1 = 0;
			FCPKKHPHPMO_Fd1 = 0;
			LAGMNJFONLB_Nx1 = 0;
			EMAGAIKNHDN_CS = 0;
			AEIBPIEIBFO_CS2 = 0;
			PBEPKDEEBBK_AS = 0;
			ECKJJCGPOPN_AS2 = 0;
			KIEJFFPDDLJ_Gdrp = FBGGEFFJJHB;
			HKGLDLJDILN_Odrp = FBGGEFFJJHB;
			GCLAAGFKPPJ_Aofs = 0;
			KPIIIEGGPIB_LS = 0;
			PJKJFIOKBGJ_LS2 = 0;
			BJNBBEMBMIK_Bd = 7;
			AOPBAOJIOGO_Sb = 1;
			ILABPFOMEAG_Va = 0;
		}

		// // RVA: 0x196251C Offset: 0x196251C VA: 0x196251C
		public int HODFCGGDHGG(KOGHKIODHPA_Board JEMMMJEJLNL, IDMPGHMNLHD.NPIEEGNKDEG INDDJNMPONH, byte[] KBOLNIBLIND)
		{
			int res = 0;
			DMPDJFAGCPN d = JEMMMJEJLNL.FDCDIHIIJJM_GetLayout(BJNBBEMBMIK_Bd);
			if(d != null)
			{
				int l = 0;
				if(KBOLNIBLIND != null)
				{
					for(int i = 0; i < d.PDKGMFHIFML_Pl.Count; i++)
					{
						if((i >> 3) < KBOLNIBLIND.Length)
						{
							if(((1 << (i & 7)) & KBOLNIBLIND[i >> 3]) != 0)
							{
								AFIFDLOAKGI a = JEMMMJEJLNL.DDGNLCJGFJF(d.PDKGMFHIFML_Pl[i].JBGEEPFKIGG);
								if(a != null && a.INDDJNMPONH == (int)INDDJNMPONH)
								{
									l += GDHGEECAJGI[i];
								}
							}
						}
					}
				}
				res = 1;
				switch(INDDJNMPONH)
				{
					case IDMPGHMNLHD.NPIEEGNKDEG.KLJAMOGANCA:
						res = HFIDCMNFBJG_Hp;
						break;
					case IDMPGHMNLHD.NPIEEGNKDEG.IDFLLFIBKGK:
						res = PFJCOCPKABN_So;
						break;
					case IDMPGHMNLHD.NPIEEGNKDEG.JMLMELKOJND:
						res = JFJDLEMNKFE_Vo;
						break;
					case IDMPGHMNLHD.NPIEEGNKDEG.MJEJOPJKFNK:
						res = GDOLPGBLMEA_Ch;
						break;
					case IDMPGHMNLHD.NPIEEGNKDEG.GMKEEAPLKHC:
					case IDMPGHMNLHD.NPIEEGNKDEG.DEKFNLBLKEH:
					case IDMPGHMNLHD.NPIEEGNKDEG.AJKGPEGCJBH:
						break;
					case IDMPGHMNLHD.NPIEEGNKDEG.NBAPLFKEJBL:
						res = HCFOMFDPGEC_Sp;
						break;
					case IDMPGHMNLHD.NPIEEGNKDEG.AFCFOLIHPDB:
						res = ONDFNOOICLE_Fd;
						break;
					default:
						res = 0;
						break;
					case IDMPGHMNLHD.NPIEEGNKDEG.EHHEKKDOLNF:
						res = FLGDCCFAGEL_Nx;
						break;
				}
				res += l;
			}
			return res;
		}

		// // RVA: 0x19628E8 Offset: 0x19628E8 VA: 0x19628E8
		// public int NGGBHLCKJGO(KOGHKIODHPA JEMMMJEJLNL, byte[] KBOLNIBLIND, byte[] ODKMKEHJOCK, int JPIPENJGGDD, int JPJNKNOJBMM, int MBLGJDKKLPO) { }

		// // RVA: 0x1962D3C Offset: 0x1962D3C VA: 0x1962D3C
		public int AGOEDLNOHND(KOGHKIODHPA_Board JEMMMJEJLNL, byte[] ODKMKEHJOCK, int JPIPENJGGDD_Mlt, int JPJNKNOJBMM)
		{
			if(ODKMKEHJOCK == null)
				return 0;
			else
			{
				int res = 0;
				KOGHKIODHPA_Board.ADPMJDMFEIK data = new KOGHKIODHPA_Board.ADPMJDMFEIK();
				data.KHEKNNFCAOI_Init(JEMMMJEJLNL, AOPBAOJIOGO_Sb, 0, JPIPENJGGDD_Mlt, JPJNKNOJBMM, ILABPFOMEAG_Va, FKDCCLPGKDK_Ma);
				if(data.EEDDJLLIOBD != null)
				{
					List<AFIFDLOAKGI> l = data.NKBGIKPCLMI(false);
					int k = 0;
					for(int i = 0; i < l.Count - 1; i++)
					{
						if(l[i] != null && l[i].INDDJNMPONH == 19)
						{
							if(((1 << (i & 7)) & ODKMKEHJOCK[i >> 3]) != 0)
							{
								res += l[i].MKNDAOHGOAK;
							}
						}
					}
				}
				return res;
			}
		}

		// // RVA: 0x1962F5C Offset: 0x1962F5C VA: 0x1962F5C
		public int PKNGPIFNIGN(KOGHKIODHPA_Board JEMMMJEJLNL, int JPIPENJGGDD, int JPJNKNOJBMM)
		{
			int res = 0;
			KOGHKIODHPA_Board.ADPMJDMFEIK a = new KOGHKIODHPA_Board.ADPMJDMFEIK();
			if(a != null)
			{
				a.KHEKNNFCAOI_Init(JEMMMJEJLNL, AOPBAOJIOGO_Sb, 0, JPIPENJGGDD, JPJNKNOJBMM, ILABPFOMEAG_Va, FKDCCLPGKDK_Ma);
				if(a.EEDDJLLIOBD != null)
				{
					var array = a.NKBGIKPCLMI(true);
					for (int i = 0; i < array.Count - 1; i++)
					{
						if(array[i] != null && array[i].INDDJNMPONH == 19)
						{
							res += array[i].MKNDAOHGOAK;
						}
					}
				}
			}
			return res;
		}

		// // RVA: 0x1963110 Offset: 0x1963110 VA: 0x1963110
		// public int JGKOJEOLMIL(KOGHKIODHPA JEMMMJEJLNL, byte[] KBOLNIBLIND) { }

		// // RVA: 0x1961A48 Offset: 0x1961A48 VA: 0x1961A48
		// public int BDDIGGPHGKH(IDMPGHMNLHD.NPIEEGNKDEG INDDJNMPONH) { }

		// // RVA: 0x19619AC Offset: 0x19619AC VA: 0x19619AC
		public int BLNPFJKODCJ(IDMPGHMNLHD.NPIEEGNKDEG INDDJNMPONH)
		{
			switch(INDDJNMPONH)
			{
				case IDMPGHMNLHD.NPIEEGNKDEG.KLJAMOGANCA: return JFLFKAKFKJJ_Hp1 ^ FBGGEFFJJHB;
				case IDMPGHMNLHD.NPIEEGNKDEG.IDFLLFIBKGK: return JBFJGPMANNM_So1 ^ FBGGEFFJJHB;
				case IDMPGHMNLHD.NPIEEGNKDEG.JMLMELKOJND: return MGBKEMHECLA_Vo1 ^ FBGGEFFJJHB;
				case IDMPGHMNLHD.NPIEEGNKDEG.MJEJOPJKFNK: return BMCPCMPAOEP_Ch1 ^ FBGGEFFJJHB;
				case IDMPGHMNLHD.NPIEEGNKDEG.GMKEEAPLKHC:
				case IDMPGHMNLHD.NPIEEGNKDEG.DEKFNLBLKEH:
				case IDMPGHMNLHD.NPIEEGNKDEG.AJKGPEGCJBH:
					return 1;
				case IDMPGHMNLHD.NPIEEGNKDEG.NBAPLFKEJBL: return HBBAIDHNJFH_Sp1 ^ FBGGEFFJJHB;
				case IDMPGHMNLHD.NPIEEGNKDEG.AFCFOLIHPDB: return FCPKKHPHPMO_Fd1 ^ FBGGEFFJJHB;
				case IDMPGHMNLHD.NPIEEGNKDEG.LCEPKDJCNBJ: return LAGMNJFONLB_Nx1 ^ FBGGEFFJJHB;
				default:
					return 0;
			}
		}

		// // RVA: 0x19632D0 Offset: 0x19632D0 VA: 0x19632D0
		// public bool OOOPJNKBDIL() { }
	}

	
	public const int NBHMMGEMHAF = 6000;
	public int GEDACMANCDO; // 0x24
	public string HDIDJNCGICK; // 0x28

	public List<MLIBEPGADJH_Scene.KKLDOOJBJMN> CDENCMNHNGA { get; set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB

	// // RVA: 0x195D7F0 Offset: 0x195D7F0 VA: 0x195D7F0
	// public int NGAIKCLLDBN(int BCCHOBPJJKE) { }

	// // RVA: 0x195D7F8 Offset: 0x195D7F8 VA: 0x195D7F8
	// public int BMPOAGJJNAF(int BCCHOBPJJKE) { }

	// // RVA: 0x195D800 Offset: 0x195D800 VA: 0x195D800
	public MLIBEPGADJH_Scene()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 70;
		CDENCMNHNGA = new List<MLIBEPGADJH_Scene.KKLDOOJBJMN>(6000);
	}

	// // RVA: 0x195D90C Offset: 0x195D90C VA: 0x195D90C Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
		GEDACMANCDO = 0;
		for(int i = 0; i < 6000; i++)
		{
			MLIBEPGADJH_Scene.KKLDOOJBJMN data = new MLIBEPGADJH_Scene.KKLDOOJBJMN();
			data.BCCHOBPJJKE_Id = i+1;
			data.GDHGEECAJGI = new List<short>(100);
			CDENCMNHNGA.Add(data);
		}
	}

	// // RVA: 0x195DA6C Offset: 0x195DA6C VA: 0x195DA6C Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
    {
		JNNFCGGHCAF reader = JNNFCGGHCAF.HEGEKFMJNCC(DBBGALAPFGC);
		OEMFKEODOIF(reader);
		return true;
    }

	// // RVA: 0x195EF38 Offset: 0x195EF38 VA: 0x195EF38 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(100, "Json load");
		return true;
	}

	// // RVA: 0x195DA94 Offset: 0x195DA94 VA: 0x195DA94
	private bool OEMFKEODOIF(JNNFCGGHCAF MPIDEPMCHII)
	{
		LFPCDGMAMJM[] array = MPIDEPMCHII.OMODKDAOCJL;
		if (array.Length > 6000)
			return false;
		GEDACMANCDO = 0;
		long time = Utility.GetCurrentUnixTime();
		int key = (int)(time * 0x37);
		for (int i = 0; i < array.Length; i++)
		{
			CDENCMNHNGA[i].FBGGEFFJJHB = key;
			CDENCMNHNGA[i].BCCHOBPJJKE_Id = (int)array[i].PPFNGGCBJKC;
			CDENCMNHNGA[i].EKLIPGELKCL_Rarity = (sbyte)array[i].FBFLDFMFFOH;
			CDENCMNHNGA[i].PPEGAKEIEGM_En = (sbyte)JKAECBCNHAN(array[i].IJEKNCDIIAE, (int)array[i].PLALNIIBLOF, 0);
			CDENCMNHNGA[i].EMIKBGHIOMN_SerieLogo = (SeriesLogoId.Type)array[i].JPFMJHLCMJL;
			CDENCMNHNGA[i].AIHCEGFANAM_Serie = SeriesAttr.ConvertFromLogoId(CDENCMNHNGA[i].EMIKBGHIOMN_SerieLogo);
			CDENCMNHNGA[i].FKDCCLPGKDK_Ma = (sbyte)array[i].AOLLIMFKDAA;
			CDENCMNHNGA[i].HFIDCMNFBJG_Hp = (int)array[i].BCCOMAODPJI;
			CDENCMNHNGA[i].PFJCOCPKABN_So = (int)array[i].LJELGFAFGAB;
			CDENCMNHNGA[i].JFJDLEMNKFE_Vo = (int)array[i].KNEDJFLCCLN;
			CDENCMNHNGA[i].GDOLPGBLMEA_Ch = (int)array[i].MBAMIOJNGBD;
			CDENCMNHNGA[i].HCFOMFDPGEC_Sp = (int)array[i].PIPCIMIALOO;
			CDENCMNHNGA[i].ONDFNOOICLE_Fd = (int)array[i].ADLGKMBIPCA;
			CDENCMNHNGA[i].FLGDCCFAGEL_Nx = (int)array[i].PFJJFCPPNIN;
			CDENCMNHNGA[i].AOLIJKMIJJE_Dv = (int)array[i].OCAMDLMPBGA;
			CDENCMNHNGA[i].KELFCMEOPPM_Ep = (short)array[i].FELIFAHDLON;
			CDENCMNHNGA[i].MCCIFLKCNKO_Feed = array[i].KALPJIJCHFO != 0;
			CDENCMNHNGA[i].FBJDHLGODPP_Sngl = array[i].DPHMNJNCHJG != 0;
			CDENCMNHNGA[i].LFPEIEOHABE_Pstv = array[i].NPJOJEHFBKG;
			CDENCMNHNGA[i].JFLFKAKFKJJ_Hp1 = (int)array[i].MOPBJIOCKML ^ CDENCMNHNGA[i].FBGGEFFJJHB;
			CDENCMNHNGA[i].JBFJGPMANNM_So1 = (int)array[i].NDDDBPKPMDK ^ CDENCMNHNGA[i].FBGGEFFJJHB;
			CDENCMNHNGA[i].MGBKEMHECLA_Vo1 = (int)array[i].KKPADIFPHOK ^ CDENCMNHNGA[i].FBGGEFFJJHB;
			CDENCMNHNGA[i].BMCPCMPAOEP_Ch1 = (int)array[i].JCAPANAALDF ^ CDENCMNHNGA[i].FBGGEFFJJHB;
			CDENCMNHNGA[i].HBBAIDHNJFH_Sp1 = (int)array[i].FMGKFCHAOCF ^ CDENCMNHNGA[i].FBGGEFFJJHB;
			CDENCMNHNGA[i].FCPKKHPHPMO_Fd1 = (int)array[i].ILKEDIDGNLP ^ CDENCMNHNGA[i].FBGGEFFJJHB;
			CDENCMNHNGA[i].LAGMNJFONLB_Nx1 = (int)array[i].BCIDCCGECBG ^ CDENCMNHNGA[i].FBGGEFFJJHB;
			CDENCMNHNGA[i].JIJOGLFOOMN_Aver = (int)array[i].JIJOGLFOOMN;
			CDENCMNHNGA[i].EMAGAIKNHDN_CS = (int)array[i].AKOJJJLPCKA;
			CDENCMNHNGA[i].PBEPKDEEBBK_AS = (int)array[i].ELBJIFCDJGO;
			CDENCMNHNGA[i].KPIIIEGGPIB_LS = (int)array[i].LNKKMBCDPHH;
			CDENCMNHNGA[i].AEIBPIEIBFO_CS2 = (int)array[i].GBIIBCHECJC;
			CDENCMNHNGA[i].ECKJJCGPOPN_AS2 = (int)array[i].GPPCEKHBMCO;
			CDENCMNHNGA[i].PJKJFIOKBGJ_LS2 = (int)array[i].FPNNEEHLIJM;
			CDENCMNHNGA[i].BJNBBEMBMIK_Bd = (short)array[i].LHAFADCJBME;
			CDENCMNHNGA[i].AOPBAOJIOGO_Sb = (short)array[i].KOHNLDKIKPC;
			CDENCMNHNGA[i].ILABPFOMEAG_Va = (int)array[i].FIKLIDJBPBB;
			CDENCMNHNGA[i].FIHNJFKBKBD_Note = (int)array[i].AIFGNKMBFCD;
			CDENCMNHNGA[i].KIEJFFPDDLJ_Gdrp = (int)array[i].JLHAHAMAIBG ^ CDENCMNHNGA[i].FBGGEFFJJHB;
			CDENCMNHNGA[i].HKGLDLJDILN_Odrp = (int)array[i].OKEFHPHNFNK ^ CDENCMNHNGA[i].FBGGEFFJJHB;
			CDENCMNHNGA[i].GCLAAGFKPPJ_Aofs = (int)array[i].FGJKNLLDHJI;
			if(CDENCMNHNGA[i].PPEGAKEIEGM_En == 2)
			{
				GEDACMANCDO++;
			}
		}
		for(int i = array.Length; i < 6000; i++)
		{
			CDENCMNHNGA[i].LHPDDGIJKNB_Reset(i+1);
		}
		return true;
	}

	// // RVA: 0x195EF3C Offset: 0x195EF3C VA: 0x195EF3C
	// private bool OEMFKEODOIF(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE) { }

	// // RVA: 0x1960958 Offset: 0x1960958 VA: 0x1960958
	public void AMACEDAPNKJ(LDDDBPNGGIN_Game HNMMJINNHII_GameDB, KOGHKIODHPA_Board JEMMMJEJLNL_BoardDB)
	{
		List<int> l1 = new List<int>(22);
		List<int> l2 = new List<int>(22);
		List<int> l3 = new List<int>(22);
		for(int i = 0; i < 22; i++)
		{
			l1.Add(0);
			l2.Add(0);
			l3.Add(0);
		}
		for (int i = 0; i < CDENCMNHNGA.Count; i++)
		{
			DMPDJFAGCPN layout = JEMMMJEJLNL_BoardDB.FDCDIHIIJJM_GetLayout(CDENCMNHNGA[i].BJNBBEMBMIK_Bd);
			for (int j = 0; j < 22; j++)
			{
				l1[j] = 0;
				l2[j] = 0;
				l3[j] = 0;
			}
			for (int j = 0; j < layout.PDKGMFHIFML_Pl.Count; j++)
			{
				AFIFDLOAKGI a = JEMMMJEJLNL_BoardDB.DDGNLCJGFJF(layout.PDKGMFHIFML_Pl[j].JBGEEPFKIGG);
				if (a != null)
				{
					l1[a.INDDJNMPONH] += a.MKNDAOHGOAK;
				}
			}
			for (int j = 0; j < 22; j++)
			{
				int val = CDENCMNHNGA[i].BLNPFJKODCJ((IDMPGHMNLHD.NPIEEGNKDEG)j);
				int val2 = 1;
				switch (j)
				{
					case 1: val2 = CDENCMNHNGA[i].HFIDCMNFBJG_Hp; break;
					case 2: val2 = CDENCMNHNGA[i].PFJCOCPKABN_So; break;
					case 3: val2 = CDENCMNHNGA[i].JFJDLEMNKFE_Vo; break;
					case 4: val2 = CDENCMNHNGA[i].GDOLPGBLMEA_Ch; break;
					case 8: val2 = CDENCMNHNGA[i].HCFOMFDPGEC_Sp; break;
					case 9: val2 = CDENCMNHNGA[i].ONDFNOOICLE_Fd; break;
					case 0xb: val2 = CDENCMNHNGA[i].FLGDCCFAGEL_Nx; break;
					case 5:
					case 6:
					case 7:
						break;
					default:
						val2 = 0;
						break;
				}
				l2[j] = val - val2;
			}
			CDENCMNHNGA[i].GDHGEECAJGI.Clear();
			for (int j = 0; j < layout.PDKGMFHIFML_Pl.Count; j++)
			{
				AFIFDLOAKGI a = JEMMMJEJLNL_BoardDB.DDGNLCJGFJF(layout.PDKGMFHIFML_Pl[j].JBGEEPFKIGG);
				int val = 0;
				if(a != null)
				{
					if(a.INDDJNMPONH == 18 || a.INDDJNMPONH == 6 || a.INDDJNMPONH == 5 || a.INDDJNMPONH == 7 || a.INDDJNMPONH == 21)
					{
						val = a.MKNDAOHGOAK;
						l3[a.INDDJNMPONH] += val;
					}
					else if(a.INDDJNMPONH != 20 && a.INDDJNMPONH != 10 && l1[a.INDDJNMPONH] != 0)
					{
						val = (a.MKNDAOHGOAK * l2[a.INDDJNMPONH]) / l1[a.INDDJNMPONH];
						l3[a.INDDJNMPONH] += val;
					}
				}
				CDENCMNHNGA[i].GDHGEECAJGI.Add((short)val);
			}
			for (int j = 0; j < 22; j++)
			{
				int k = 0;
				if (l3[j] != 0 || l2[j] < 1)
				{
					while(k <= 99999 && l3.Count < l2.Count)
					{
						for(int l = layout.PDKGMFHIFML_Pl.Count - 1; l >= 0; l--)
						{
							k++;
							if (l3[j] >= l2[j])
								break;
							AFIFDLOAKGI a = JEMMMJEJLNL_BoardDB.DDGNLCJGFJF(layout.PDKGMFHIFML_Pl[l].JBGEEPFKIGG);
							if(a != null)
							{
								CDENCMNHNGA[i].GDHGEECAJGI[l]++;
								l3[j]++;
							}
						}
					}
				}
			}
			CDENCMNHNGA[i].OCKJIHPHMDE = HNMMJINNHII_GameDB.KLIGCACGHHN(JEMMMJEJLNL_BoardDB, CDENCMNHNGA[i].AOPBAOJIOGO_Sb, CDENCMNHNGA[i].ILABPFOMEAG_Va, CDENCMNHNGA[i].EKLIPGELKCL_Rarity, CDENCMNHNGA[i].MCCIFLKCNKO_Feed);
		}
	}

	// // RVA: 0x1961B04 Offset: 0x1961B04 VA: 0x1961B04
	// public bool FDIOFBGJKNO(int BCCHOBPJJKE) { }

	// // RVA: 0x1961C54 Offset: 0x1961C54 VA: 0x1961C54
	// public int KBEGPJEBFMA(int BCCHOBPJJKE) { }

	// // RVA: 0x1961D38 Offset: 0x1961D38 VA: 0x1961D38
	// public bool OEEJKKFOBKD(int BCCHOBPJJKE) { }

	// // RVA: 0x1961E30 Offset: 0x1961E30 VA: 0x1961E30
	// public int ELKHCOEMNOJ(int BCCHOBPJJKE, int DMNIMMGGJJJ, LLKLAKGKNLD HDGOHBFKKDM) { }

	// // RVA: 0x1961F54 Offset: 0x1961F54 VA: 0x1961F54 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(100, "CAOGDCBPBAN");
		return 0;
	}

	// // RVA: 0x195BFB8 Offset: 0x195BFB8 VA: 0x195BFB8
	public bool FGNJBMPDBLO_IsSceneValid(int BCCHOBPJJKE)
	{
		bool res = true;
		if(BCCHOBPJJKE != 0)
		{
			if(BCCHOBPJJKE > 0)
			{
				if(BCCHOBPJJKE <= CDENCMNHNGA.Count)
				{
					if(CDENCMNHNGA[BCCHOBPJJKE - 1].PPEGAKEIEGM_En == 2)
					{
						return CDENCMNHNGA[BCCHOBPJJKE - 1].BCCHOBPJJKE_Id == BCCHOBPJJKE;
					}
				}
			}
			res = false;
		}
		return res;
	}

	// // RVA: 0x196225C Offset: 0x196225C VA: 0x196225C
	// public MLIBEPGADJH.KKLDOOJBJMN PLKHCPPCHJL(int GJGIFNEAHJN) { }
}

public class IDMPGHMNLHD
{
	public enum NPIEEGNKDEG
	{
		HJNNKCMLGFL = 0,
		KLJAMOGANCA = 1,
		IDFLLFIBKGK = 2,
		JMLMELKOJND = 3,
		MJEJOPJKFNK = 4,
		GMKEEAPLKHC = 5,
		DEKFNLBLKEH = 6,
		AJKGPEGCJBH = 7,
		NBAPLFKEJBL = 8,
		AFCFOLIHPDB = 9,
		NNEOHGFGLKM = 10,
		LCEPKDJCNBJ = 11,
		EHHEKKDOLNF = 12,
		FGAFMBJLOBG = 13,
		BILOBMIFMJI = 14,
		MINNGBKKKBL = 15,
		ENJGGBDLPEG = 16,
		LAOEGNLOJHC = 17,
		KDNCKIMIGOE = 18,
		HLDDCDBLFGJ = 19,
		KJONKGJHLCH = 20,
		PAAIHBHJJMM = 21,
		AEFCOHJBLPO = 22,
	}

	public static string[] HBOECCCMPMJ = new string[22]
	{
		"StringLiteral_8686",
		"StringLiteral_11062",
		"StringLiteral_11063",
		"StringLiteral_11064",
		"StringLiteral_11065",
		"StringLiteral_11066",
		"StringLiteral_11067",
		"StringLiteral_11068",
		"StringLiteral_11069",
		"StringLiteral_11070",
		"StringLiteral_11071",
		"StringLiteral_11072",
		"StringLiteral_11073",
		"StringLiteral_11074",
		"StringLiteral_11075",
		"StringLiteral_11076",
		"StringLiteral_11077",
		"StringLiteral_11078",
		"StringLiteral_11079",
		"LUCK",
		"StringLiteral_11081",
		"StringLiteral_11082"
	}; // 0x0
}
