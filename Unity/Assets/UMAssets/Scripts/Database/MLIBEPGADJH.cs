using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;

[System.Obsolete("Use MLIBEPGADJH_Scene", true)]
public class MLIBEPGADJH { }
public class MLIBEPGADJH_Scene : DIHHCBACKGG_DbSection
{
	public class KKLDOOJBJMN
	{
		public int JFLFKAKFKJJ_Life1_Crypted; // 0x44
		public int BMCPCMPAOEP_Charm1Crypted; // 0x48
		public int LAGMNJFONLB_NoteExpected1Crypted; // 0x4C
		public int JBFJGPMANNM_Soul1Crypted; // 0x50
		public int MGBKEMHECLA_Vocal1Crypted; // 0x54
		public int FCPKKHPHPMO_Fold1_Crypted; // 0x58
		public int HBBAIDHNJFH_Support1Crypted; // 0x5C
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
		public int HFIDCMNFBJG_Life { get; set; } // 0x24 HINMKMNCGFJ CMDOHPBAFCO BJBDGCMJNEO
		public int PFJCOCPKABN_Soul { get; set; } // 0x28 GNAPLLPFDEH EJPPLFNLAAO NEMMJEJENFD
		public int JFJDLEMNKFE_Vocal { get; set; } // 0x2C HGANCHPKOEG GCMPLDKECFM CEHKELOHIBD
		public int GDOLPGBLMEA_Charm { get; set; } // 0x30 GMPHNADBLAP LEHDODJMICA IKPOCJDOOGA
		public int HCFOMFDPGEC_Support { get; set; } // 0x34 LFNHOBGPDAI GGIDKCOMCJL LAIHOHGICJD
		public int ONDFNOOICLE_Fold { get; set; } // 0x38 JLJACODCBIK OGGOHKCANFG BKMHMPEBNPE
		public int FLGDCCFAGEL_NotesExpected { get; set; } // 0x3C BPPACKLALEM OMHMJGDMACK EJIJEKLDDOH
		public int JIJOGLFOOMN_Aver { get; set; } // 0x40 MCJCIKOEOHH AEOFOBJHHHN FDHKHDIKPKE
		public int JABFJHJFJEO_Life1 { get { return JFLFKAKFKJJ_Life1_Crypted ^ FBGGEFFJJHB; } set { JFLFKAKFKJJ_Life1_Crypted = value ^ FBGGEFFJJHB; } } // MIAFAEEAIEG 0x196242C DLKALAPFCFK 0x19607AC
		public int EFMJLKIFNJK_Soul1 { get { return JBFJGPMANNM_Soul1Crypted ^ FBGGEFFJJHB; } set { JBFJGPMANNM_Soul1Crypted = value ^ FBGGEFFJJHB; } } // LAMFLFENKJF 0x196243C BHJKJCOFKLO 0x19607BC
		public int EGNCKFNALIA_Vocal1 { get { return MGBKEMHECLA_Vocal1Crypted ^ FBGGEFFJJHB; } set { MGBKEMHECLA_Vocal1Crypted = value ^ FBGGEFFJJHB; } } // CKJKINNOKIL 0x196244C JIOKNPPGIKO 0x19607CC
		public int OIOABIDEJPG_Charm1 { get { return BMCPCMPAOEP_Charm1Crypted ^ FBGGEFFJJHB; } set { BMCPCMPAOEP_Charm1Crypted = value ^ FBGGEFFJJHB; } } // NGHMJMNLNIE 0x196245C AFKDHCJPFEI 0x19607DC
		public int DCICNKHCBJK_Support1 { get { return HBBAIDHNJFH_Support1Crypted ^ FBGGEFFJJHB; } set { HBBAIDHNJFH_Support1Crypted = value ^ FBGGEFFJJHB; } } // GEDMBCPNFHI 0x196246C DEBIACKNCLF 0x19607EC
		public int EANBFFCPKOO_Fold1 { get { return FCPKKHPHPMO_Fold1_Crypted ^ FBGGEFFJJHB; } set { FCPKKHPHPMO_Fold1_Crypted = value ^ FBGGEFFJJHB; } } // MOCNJMBAJKK 0x196247C FJBKNIFMKEJ 0x19607FC
		public int GPAOEGPMBOJ_NoteExpected1 { get { return LAGMNJFONLB_NoteExpected1Crypted ^ FBGGEFFJJHB; } set { LAGMNJFONLB_NoteExpected1Crypted = value ^ FBGGEFFJJHB; } } // KEMDEJKPDOG 0x196248C LJJNJENJGHK 0x196080C
		public int EMAGAIKNHDN_CS { get; set; } // 0x64 DAMNLKLGGAI EBHLKAEBFCE ONOKGLFKJLK
		public int AEIBPIEIBFO_CS2 { get; set; } // 0x68 KNMELHKEPDB KDFOMMHFGBL CKLAPJMCGOJ
		public int PBEPKDEEBBK_AS { get; set; } // 0x6C HOOPPDKEPIP MPMNIGEOBOC CDJEALCHFKL
		public int ECKJJCGPOPN_AS2 { get; set; } // 0x70 IJMEDLIHHPM LKFHCJFFMAJ MLJAIDJHMAI
		public int KPIIIEGGPIB_LS { get; set; } // 0x74 PJNCJOIODGP DPMKOIOIADB PFKMHCNPLLB
		public int PJKJFIOKBGJ_LS2 { get; set; } // 0x78 DPCGBPLOHJE EGNELMIPIIO FANPLCAHHNP
		public short BJNBBEMBMIK_Bd { get; set; } // 0x7C PJFIENAGLNL LFOMFGJDJDI EABGNGKHJAO
		public short AOPBAOJIOGO_Sb { get; set; } // 0x7E IKKNPDLNPKH HDLCEEHNBKN AGKAANFCJIP
		public int ILABPFOMEAG_Va { get; set; }  // 0x80 OMFFPPDGOPE ICFAOLCLHIA LIJJLCOMANF
		public int FIHNJFKBKBD_NoteType { get; set; }  // 0x84 CHOBNFJBALL KLEAPKCDDHN NICEKBABGLD
		// public int LDMOHIKFDEK { get; set; } // IJCCFFMMALD 0x19624D4 MJDCIIBOHIL 0x1960874
		// public int FPHOPBNPCML { get; set; } // DILIELECNKD 0x19624E4 PKGHMNIEJAK 0x1960884
		public int GCLAAGFKPPJ_Aofs { get; set; } // 0x90 JHOJALACCGC BBOJJFCLKJF KFMLHEGGPJA
		public List<short> GDHGEECAJGI_BoardValue { get; set; } // 0x94 PNKKMNPCGCO DGIKNGMCPGA CAMLBFJNCIK

		// // RVA: 0x19624FC Offset: 0x19624FC VA: 0x19624FC
		public int CGMFEOFCKPA_GetLife(KOGHKIODHPA_Board JEMMMJEJLNL, byte[] KBOLNIBLIND)
		{
			return HODFCGGDHGG_GetStat(JEMMMJEJLNL, IDMPGHMNLHD.NPIEEGNKDEG.KLJAMOGANCA_Life, KBOLNIBLIND);
		}

		// // RVA: 0x19627E8 Offset: 0x19627E8 VA: 0x19627E8
		public int ONBGNBDIGPF_GetSoul(KOGHKIODHPA_Board JEMMMJEJLNL, byte[] KBOLNIBLIND)
		{
			return HODFCGGDHGG_GetStat(JEMMMJEJLNL, IDMPGHMNLHD.NPIEEGNKDEG.IDFLLFIBKGK_Soul, KBOLNIBLIND);
		}

		// // RVA: 0x1962808 Offset: 0x1962808 VA: 0x1962808
		public int DPDGKOBDBJF_GetVocal(KOGHKIODHPA_Board JEMMMJEJLNL, byte[] KBOLNIBLIND)
		{
			return HODFCGGDHGG_GetStat(JEMMMJEJLNL, IDMPGHMNLHD.NPIEEGNKDEG.JMLMELKOJND_Vocal, KBOLNIBLIND);
		}

		// // RVA: 0x1962828 Offset: 0x1962828 VA: 0x1962828
		public int JEDMOOILJOJ_GetCharm(KOGHKIODHPA_Board JEMMMJEJLNL, byte[] KBOLNIBLIND)
		{
			return HODFCGGDHGG_GetStat(JEMMMJEJLNL, IDMPGHMNLHD.NPIEEGNKDEG.MJEJOPJKFNK_Charm, KBOLNIBLIND);
		}

		// // RVA: 0x1962848 Offset: 0x1962848 VA: 0x1962848
		public int MGKDKGOACDB_GetSkillLevel(KOGHKIODHPA_Board JEMMMJEJLNL, byte[] KBOLNIBLIND)
		{
			return HODFCGGDHGG_GetStat(JEMMMJEJLNL, IDMPGHMNLHD.NPIEEGNKDEG.GMKEEAPLKHC_SkillLevel/*5*/, KBOLNIBLIND);
		}

		// // RVA: 0x1962868 Offset: 0x1962868 VA: 0x1962868
		public int CMPJFHEFIND_GetActiveSkillLevel(KOGHKIODHPA_Board JEMMMJEJLNL, byte[] KBOLNIBLIND)
		{
			return HODFCGGDHGG_GetStat(JEMMMJEJLNL, IDMPGHMNLHD.NPIEEGNKDEG.DEKFNLBLKEH_ActiveSkillLevel/*6*/, KBOLNIBLIND);
		}

		// // RVA: 0x1962888 Offset: 0x1962888 VA: 0x1962888
		public int BBGLLMIFPMA_GetLiveSkillLevel(KOGHKIODHPA_Board JEMMMJEJLNL, byte[] KBOLNIBLIND)
		{
			return HODFCGGDHGG_GetStat(JEMMMJEJLNL, IDMPGHMNLHD.NPIEEGNKDEG.AJKGPEGCJBH_LiveSkillLevel/*7*/, KBOLNIBLIND);
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
			GDOLPGBLMEA_Charm = 100;
			HCFOMFDPGEC_Support = 100;
			ONDFNOOICLE_Fold = 100;
			LFPEIEOHABE_Pstv = 100;
			HFIDCMNFBJG_Life = 100;
			PFJCOCPKABN_Soul = 100;
			JFJDLEMNKFE_Vocal = 100;
			JABFJHJFJEO_Life1 = 100;
			OIOABIDEJPG_Charm1 = 100;
			EFMJLKIFNJK_Soul1 = 100;
			EGNCKFNALIA_Vocal1 = 100;
			EANBFFCPKOO_Fold1 = 100;
			LAGMNJFONLB_NoteExpected1Crypted = 0;
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
		public int HODFCGGDHGG_GetStat(KOGHKIODHPA_Board JEMMMJEJLNL_Board, IDMPGHMNLHD.NPIEEGNKDEG INDDJNMPONH_StatType, byte[] KBOLNIBLIND)
		{
			int res = 0;
			DMPDJFAGCPN d = JEMMMJEJLNL_Board.FDCDIHIIJJM_GetLayout(BJNBBEMBMIK_Bd);
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
								AFIFDLOAKGI a = JEMMMJEJLNL_Board.DDGNLCJGFJF(d.PDKGMFHIFML_Pl[i].JBGEEPFKIGG);
								if(a != null && a.INDDJNMPONH_StatType == (int)INDDJNMPONH_StatType)
								{
									l += GDHGEECAJGI_BoardValue[i];
								}
							}
						}
					}
				}
				res = 1;
				switch(INDDJNMPONH_StatType)
				{
					case IDMPGHMNLHD.NPIEEGNKDEG.KLJAMOGANCA_Life:
						res = HFIDCMNFBJG_Life;
						break;
					case IDMPGHMNLHD.NPIEEGNKDEG.IDFLLFIBKGK_Soul:
						res = PFJCOCPKABN_Soul;
						break;
					case IDMPGHMNLHD.NPIEEGNKDEG.JMLMELKOJND_Vocal:
						res = JFJDLEMNKFE_Vocal;
						break;
					case IDMPGHMNLHD.NPIEEGNKDEG.MJEJOPJKFNK_Charm:
						res = GDOLPGBLMEA_Charm;
						break;
					case IDMPGHMNLHD.NPIEEGNKDEG.GMKEEAPLKHC_SkillLevel:
					case IDMPGHMNLHD.NPIEEGNKDEG.DEKFNLBLKEH_ActiveSkillLevel:
					case IDMPGHMNLHD.NPIEEGNKDEG.AJKGPEGCJBH_LiveSkillLevel:
						break;
					case IDMPGHMNLHD.NPIEEGNKDEG.NBAPLFKEJBL_Support:
						res = HCFOMFDPGEC_Support;
						break;
					case IDMPGHMNLHD.NPIEEGNKDEG.AFCFOLIHPDB_Fold:
						res = ONDFNOOICLE_Fold;
						break;
					default:
						res = 0;
						break;
					case IDMPGHMNLHD.NPIEEGNKDEG.EHHEKKDOLNF_NoteExpected:
						res = FLGDCCFAGEL_NotesExpected;
						break;
				}
				res += l;
			}
			return res;
		}

		// // RVA: 0x19628E8 Offset: 0x19628E8 VA: 0x19628E8
		public int NGGBHLCKJGO(KOGHKIODHPA_Board JEMMMJEJLNL, byte[] KBOLNIBLIND, byte[] ODKMKEHJOCK, int JPIPENJGGDD, int JPJNKNOJBMM, int MBLGJDKKLPO)
		{
			int res = 0;
			if(KBOLNIBLIND != null)
			{
				DMPDJFAGCPN d = JEMMMJEJLNL.FDCDIHIIJJM_GetLayout(BJNBBEMBMIK_Bd);
				if(d != null)
				{
					for(int i = 0; i < d.PDKGMFHIFML_Pl.Count; i++)
					{
						int idx = i >> 3;
						if(idx < KBOLNIBLIND.Length)
						{
							if(((1 << (i & 7)) & KBOLNIBLIND[idx]) != 0)
							{
								AFIFDLOAKGI a = JEMMMJEJLNL.DDGNLCJGFJF(d.PDKGMFHIFML_Pl[i].JBGEEPFKIGG);
								if(a != null && a.INDDJNMPONH_StatType == 18)
								{
									res += GDHGEECAJGI_BoardValue[i];
								}
							}
						}
					}
				}
			}
			if(ODKMKEHJOCK != null)
			{
				KOGHKIODHPA_Board.ADPMJDMFEIK data = new KOGHKIODHPA_Board.ADPMJDMFEIK();
				data.KHEKNNFCAOI_Init(JEMMMJEJLNL, AOPBAOJIOGO_Sb, 0, JPIPENJGGDD, JPJNKNOJBMM, ILABPFOMEAG_Va, FKDCCLPGKDK_Ma);
				if(data.EEDDJLLIOBD != null)
				{
					List<AFIFDLOAKGI> l = data.NKBGIKPCLMI(false);
					if(l.Count > 0)
					{
						if (l.Count - 1 > 0)
						{
							for (int i = 0; i < l.Count - 1; i++)
							{
								if (l[i] != null && l[i].INDDJNMPONH_StatType == 18)
								{
									if (((1 << (i & 7)) & ODKMKEHJOCK[i >> 3]) != 0)
									{
										res += l[i].MKNDAOHGOAK;
									}
								}
							}
						}
						if(MBLGJDKKLPO > 0)
						{
							if(l[l.Count - 1]!= null && l[l.Count - 1].INDDJNMPONH_StatType == 20)
							{
								res += l.Count * MBLGJDKKLPO;
							}
						}
					}
				}
			}
			return res;
		}

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
						if(l[i] != null && l[i].INDDJNMPONH_StatType == 19)
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
						if(array[i] != null && array[i].INDDJNMPONH_StatType == 19)
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
				case IDMPGHMNLHD.NPIEEGNKDEG.KLJAMOGANCA_Life: return JFLFKAKFKJJ_Life1_Crypted ^ FBGGEFFJJHB;
				case IDMPGHMNLHD.NPIEEGNKDEG.IDFLLFIBKGK_Soul: return JBFJGPMANNM_Soul1Crypted ^ FBGGEFFJJHB;
				case IDMPGHMNLHD.NPIEEGNKDEG.JMLMELKOJND_Vocal: return MGBKEMHECLA_Vocal1Crypted ^ FBGGEFFJJHB;
				case IDMPGHMNLHD.NPIEEGNKDEG.MJEJOPJKFNK_Charm: return BMCPCMPAOEP_Charm1Crypted ^ FBGGEFFJJHB;
				case IDMPGHMNLHD.NPIEEGNKDEG.GMKEEAPLKHC_SkillLevel:
				case IDMPGHMNLHD.NPIEEGNKDEG.DEKFNLBLKEH_ActiveSkillLevel:
				case IDMPGHMNLHD.NPIEEGNKDEG.AJKGPEGCJBH_LiveSkillLevel:
					return 1;
				case IDMPGHMNLHD.NPIEEGNKDEG.NBAPLFKEJBL_Support: return HBBAIDHNJFH_Support1Crypted ^ FBGGEFFJJHB;
				case IDMPGHMNLHD.NPIEEGNKDEG.AFCFOLIHPDB_Fold: return FCPKKHPHPMO_Fold1_Crypted ^ FBGGEFFJJHB;
				case IDMPGHMNLHD.NPIEEGNKDEG.LCEPKDJCNBJ: return LAGMNJFONLB_NoteExpected1Crypted ^ FBGGEFFJJHB;
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

	public List<MLIBEPGADJH_Scene.KKLDOOJBJMN> CDENCMNHNGA_SceneList { get; set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB

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
		CDENCMNHNGA_SceneList = new List<MLIBEPGADJH_Scene.KKLDOOJBJMN>(6000);
	}

	// // RVA: 0x195D90C Offset: 0x195D90C VA: 0x195D90C Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA_SceneList.Clear();
		GEDACMANCDO = 0;
		for(int i = 0; i < 6000; i++)
		{
			MLIBEPGADJH_Scene.KKLDOOJBJMN data = new MLIBEPGADJH_Scene.KKLDOOJBJMN();
			data.BCCHOBPJJKE_Id = i+1;
			data.GDHGEECAJGI_BoardValue = new List<short>(100);
			CDENCMNHNGA_SceneList.Add(data);
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
			CDENCMNHNGA_SceneList[i].FBGGEFFJJHB = key;
			CDENCMNHNGA_SceneList[i].BCCHOBPJJKE_Id = (int)array[i].PPFNGGCBJKC;
			CDENCMNHNGA_SceneList[i].EKLIPGELKCL_Rarity = (sbyte)array[i].FBFLDFMFFOH;
			CDENCMNHNGA_SceneList[i].PPEGAKEIEGM_En = (sbyte)JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, (int)array[i].PLALNIIBLOF, 0);
			CDENCMNHNGA_SceneList[i].EMIKBGHIOMN_SerieLogo = (SeriesLogoId.Type)array[i].JPFMJHLCMJL;
			CDENCMNHNGA_SceneList[i].AIHCEGFANAM_Serie = SeriesAttr.ConvertFromLogoId(CDENCMNHNGA_SceneList[i].EMIKBGHIOMN_SerieLogo);
			CDENCMNHNGA_SceneList[i].FKDCCLPGKDK_Ma = (sbyte)array[i].AOLLIMFKDAA;
			CDENCMNHNGA_SceneList[i].HFIDCMNFBJG_Life = (int)array[i].BCCOMAODPJI;
			CDENCMNHNGA_SceneList[i].PFJCOCPKABN_Soul = (int)array[i].LJELGFAFGAB;
			CDENCMNHNGA_SceneList[i].JFJDLEMNKFE_Vocal = (int)array[i].KNEDJFLCCLN;
			CDENCMNHNGA_SceneList[i].GDOLPGBLMEA_Charm = (int)array[i].MBAMIOJNGBD;
			CDENCMNHNGA_SceneList[i].HCFOMFDPGEC_Support = (int)array[i].PIPCIMIALOO;
			CDENCMNHNGA_SceneList[i].ONDFNOOICLE_Fold = (int)array[i].ADLGKMBIPCA;
			CDENCMNHNGA_SceneList[i].FLGDCCFAGEL_NotesExpected = (int)array[i].PFJJFCPPNIN;
			CDENCMNHNGA_SceneList[i].AOLIJKMIJJE_Dv = (int)array[i].OCAMDLMPBGA;
			CDENCMNHNGA_SceneList[i].KELFCMEOPPM_Ep = (short)array[i].FELIFAHDLON;
			CDENCMNHNGA_SceneList[i].MCCIFLKCNKO_Feed = array[i].KALPJIJCHFO != 0;
			CDENCMNHNGA_SceneList[i].FBJDHLGODPP_Sngl = array[i].DPHMNJNCHJG != 0;
			CDENCMNHNGA_SceneList[i].LFPEIEOHABE_Pstv = array[i].NPJOJEHFBKG;
			CDENCMNHNGA_SceneList[i].JFLFKAKFKJJ_Life1_Crypted = (int)array[i].MOPBJIOCKML ^ CDENCMNHNGA_SceneList[i].FBGGEFFJJHB;
			CDENCMNHNGA_SceneList[i].JBFJGPMANNM_Soul1Crypted = (int)array[i].NDDDBPKPMDK ^ CDENCMNHNGA_SceneList[i].FBGGEFFJJHB;
			CDENCMNHNGA_SceneList[i].MGBKEMHECLA_Vocal1Crypted = (int)array[i].KKPADIFPHOK ^ CDENCMNHNGA_SceneList[i].FBGGEFFJJHB;
			CDENCMNHNGA_SceneList[i].BMCPCMPAOEP_Charm1Crypted = (int)array[i].JCAPANAALDF ^ CDENCMNHNGA_SceneList[i].FBGGEFFJJHB;
			CDENCMNHNGA_SceneList[i].HBBAIDHNJFH_Support1Crypted = (int)array[i].FMGKFCHAOCF ^ CDENCMNHNGA_SceneList[i].FBGGEFFJJHB;
			CDENCMNHNGA_SceneList[i].FCPKKHPHPMO_Fold1_Crypted = (int)array[i].ILKEDIDGNLP ^ CDENCMNHNGA_SceneList[i].FBGGEFFJJHB;
			CDENCMNHNGA_SceneList[i].LAGMNJFONLB_NoteExpected1Crypted = (int)array[i].BCIDCCGECBG ^ CDENCMNHNGA_SceneList[i].FBGGEFFJJHB;
			CDENCMNHNGA_SceneList[i].JIJOGLFOOMN_Aver = (int)array[i].JIJOGLFOOMN;
			CDENCMNHNGA_SceneList[i].EMAGAIKNHDN_CS = (int)array[i].AKOJJJLPCKA;
			CDENCMNHNGA_SceneList[i].PBEPKDEEBBK_AS = (int)array[i].ELBJIFCDJGO;
			CDENCMNHNGA_SceneList[i].KPIIIEGGPIB_LS = (int)array[i].LNKKMBCDPHH;
			CDENCMNHNGA_SceneList[i].AEIBPIEIBFO_CS2 = (int)array[i].GBIIBCHECJC;
			CDENCMNHNGA_SceneList[i].ECKJJCGPOPN_AS2 = (int)array[i].GPPCEKHBMCO;
			CDENCMNHNGA_SceneList[i].PJKJFIOKBGJ_LS2 = (int)array[i].FPNNEEHLIJM;
			CDENCMNHNGA_SceneList[i].BJNBBEMBMIK_Bd = (short)array[i].LHAFADCJBME;
			CDENCMNHNGA_SceneList[i].AOPBAOJIOGO_Sb = (short)array[i].KOHNLDKIKPC;
			CDENCMNHNGA_SceneList[i].ILABPFOMEAG_Va = (int)array[i].FIKLIDJBPBB;
			CDENCMNHNGA_SceneList[i].FIHNJFKBKBD_NoteType = (int)array[i].AIFGNKMBFCD;
			CDENCMNHNGA_SceneList[i].KIEJFFPDDLJ_Gdrp = (int)array[i].JLHAHAMAIBG ^ CDENCMNHNGA_SceneList[i].FBGGEFFJJHB;
			CDENCMNHNGA_SceneList[i].HKGLDLJDILN_Odrp = (int)array[i].OKEFHPHNFNK ^ CDENCMNHNGA_SceneList[i].FBGGEFFJJHB;
			CDENCMNHNGA_SceneList[i].GCLAAGFKPPJ_Aofs = (int)array[i].FGJKNLLDHJI;
			if(CDENCMNHNGA_SceneList[i].PPEGAKEIEGM_En == 2)
			{
				GEDACMANCDO++;
			}
		}
		for(int i = array.Length; i < 6000; i++)
		{
			CDENCMNHNGA_SceneList[i].LHPDDGIJKNB_Reset(i+1);
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
		for (int i = 0; i < CDENCMNHNGA_SceneList.Count; i++)
		{
			DMPDJFAGCPN layout = JEMMMJEJLNL_BoardDB.FDCDIHIIJJM_GetLayout(CDENCMNHNGA_SceneList[i].BJNBBEMBMIK_Bd);
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
					l1[a.INDDJNMPONH_StatType] += a.MKNDAOHGOAK;
				}
			}
			for (int j = 0; j < 22; j++)
			{
				int val = CDENCMNHNGA_SceneList[i].BLNPFJKODCJ((IDMPGHMNLHD.NPIEEGNKDEG)j);
				int val2 = 1;
				switch (j)
				{
					case 1: val2 = CDENCMNHNGA_SceneList[i].HFIDCMNFBJG_Life; break;
					case 2: val2 = CDENCMNHNGA_SceneList[i].PFJCOCPKABN_Soul; break;
					case 3: val2 = CDENCMNHNGA_SceneList[i].JFJDLEMNKFE_Vocal; break;
					case 4: val2 = CDENCMNHNGA_SceneList[i].GDOLPGBLMEA_Charm; break;
					case 8: val2 = CDENCMNHNGA_SceneList[i].HCFOMFDPGEC_Support; break;
					case 9: val2 = CDENCMNHNGA_SceneList[i].ONDFNOOICLE_Fold; break;
					case 0xb: val2 = CDENCMNHNGA_SceneList[i].FLGDCCFAGEL_NotesExpected; break;
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
			CDENCMNHNGA_SceneList[i].GDHGEECAJGI_BoardValue.Clear();
			for (int j = 0; j < layout.PDKGMFHIFML_Pl.Count; j++)
			{
				AFIFDLOAKGI a = JEMMMJEJLNL_BoardDB.DDGNLCJGFJF(layout.PDKGMFHIFML_Pl[j].JBGEEPFKIGG);
				int val = 0;
				if(a != null)
				{
					if(a.INDDJNMPONH_StatType == 18 || a.INDDJNMPONH_StatType == 6 || a.INDDJNMPONH_StatType == 5 || a.INDDJNMPONH_StatType == 7 || a.INDDJNMPONH_StatType == 21)
					{
						val = a.MKNDAOHGOAK;
						l3[a.INDDJNMPONH_StatType] += val;
					}
					else if(a.INDDJNMPONH_StatType != 20 && a.INDDJNMPONH_StatType != 10 && l1[a.INDDJNMPONH_StatType] != 0)
					{
						val = (a.MKNDAOHGOAK * l2[a.INDDJNMPONH_StatType]) / l1[a.INDDJNMPONH_StatType];
						l3[a.INDDJNMPONH_StatType] += val;
					}
				}
				CDENCMNHNGA_SceneList[i].GDHGEECAJGI_BoardValue.Add((short)val);
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
								CDENCMNHNGA_SceneList[i].GDHGEECAJGI_BoardValue[l]++;
								l3[j]++;
							}
						}
					}
				}
			}
			CDENCMNHNGA_SceneList[i].OCKJIHPHMDE = HNMMJINNHII_GameDB.KLIGCACGHHN(JEMMMJEJLNL_BoardDB, CDENCMNHNGA_SceneList[i].AOPBAOJIOGO_Sb, CDENCMNHNGA_SceneList[i].ILABPFOMEAG_Va, CDENCMNHNGA_SceneList[i].EKLIPGELKCL_Rarity, CDENCMNHNGA_SceneList[i].MCCIFLKCNKO_Feed);
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
				if(BCCHOBPJJKE <= CDENCMNHNGA_SceneList.Count)
				{
					if(CDENCMNHNGA_SceneList[BCCHOBPJJKE - 1].PPEGAKEIEGM_En == 2)
					{
						return CDENCMNHNGA_SceneList[BCCHOBPJJKE - 1].BCCHOBPJJKE_Id == BCCHOBPJJKE;
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
		KLJAMOGANCA_Life = 1,
		IDFLLFIBKGK_Soul = 2,
		JMLMELKOJND_Vocal = 3,
		MJEJOPJKFNK_Charm = 4,
		GMKEEAPLKHC_SkillLevel = 5,
		DEKFNLBLKEH_ActiveSkillLevel = 6,
		AJKGPEGCJBH_LiveSkillLevel = 7,
		NBAPLFKEJBL_Support = 8,
		AFCFOLIHPDB_Fold = 9,
		NNEOHGFGLKM = 10,
		LCEPKDJCNBJ = 11,
		EHHEKKDOLNF_NoteExpected = 12,
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
		JpStringLiterals.StringLiteral_8686,
		JpStringLiterals.StringLiteral_11062,
		JpStringLiterals.StringLiteral_11063,
		JpStringLiterals.StringLiteral_11064,
		JpStringLiterals.StringLiteral_11065,
		JpStringLiterals.StringLiteral_11066,
		JpStringLiterals.StringLiteral_11067,
		JpStringLiterals.StringLiteral_11068,
		JpStringLiterals.StringLiteral_11069,
		JpStringLiterals.StringLiteral_11070,
		JpStringLiterals.StringLiteral_11071,
		JpStringLiterals.StringLiteral_11072,
		JpStringLiterals.StringLiteral_11073,
		JpStringLiterals.StringLiteral_11074,
		JpStringLiterals.StringLiteral_11075,
		JpStringLiterals.StringLiteral_11076,
		JpStringLiterals.StringLiteral_11077,
		JpStringLiterals.StringLiteral_11078,
		JpStringLiterals.StringLiteral_11079,
		"LUCK",
		JpStringLiterals.StringLiteral_11081,
		JpStringLiterals.StringLiteral_11082
	}; // 0x0
}
