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
		public int FBGGEFFJJHB_xor; // 0x60
		public int KIEJFFPDDLJ_GdrpCrypted; // 0x88
		public int HKGLDLJDILN_OdrpCrypted; // 0x8C
		public byte[] OCKJIHPHMDE; // 0x98

		public int BCCHOBPJJKE_SceneId { get; set; } // 0x8 BNOLCKHMAAH COHCNONLPAC HJEBBEHGHGG
		public SeriesAttr.Type AIHCEGFANAM_SerieAttr { get; set; } // 0xC FJOGAAMLJMA ANEJPLENMAL HEHDOGFEIOL
		public SeriesLogoId.Type EMIKBGHIOMN_SerieLogoId { get; set; } // 0x10 CCEIEDMCHLA BJGJCKFOBCA OAKIKBEEACC
		public sbyte EKLIPGELKCL_Rarity { get; set; } // 0x14 DMGPKEIBKHJ OEEHBGECGKL GHLMHLJJBIG
		public sbyte PPEGAKEIEGM_Enabled { get; set; } // 0x15 NEKLJCCBECB KPOEEPIMMJP NCIEAFEDPBH
		public sbyte FKDCCLPGKDK_Ma { get; set; } // 0x16 KLMKEFEMHOC FBADKBMGIBP NCNMMABFHGN
		public int AOLIJKMIJJE_Diva { get; set; } // 0x18 HPEJJNAIFNP DLNCBNNPHCL CBAJOLNBJNP
		public short KELFCMEOPPM_EpisodeId { get; set; } // 0x1C LOEOGJLMNME AHJNJHDELBE PJLFKEOLFMK
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
		public int JABFJHJFJEO_Life1 { get { return JFLFKAKFKJJ_Life1_Crypted ^ FBGGEFFJJHB_xor; } set { JFLFKAKFKJJ_Life1_Crypted = value ^ FBGGEFFJJHB_xor; } } // MIAFAEEAIEG 0x196242C DLKALAPFCFK 0x19607AC
		public int EFMJLKIFNJK_Soul1 { get { return JBFJGPMANNM_Soul1Crypted ^ FBGGEFFJJHB_xor; } set { JBFJGPMANNM_Soul1Crypted = value ^ FBGGEFFJJHB_xor; } } // LAMFLFENKJF 0x196243C BHJKJCOFKLO 0x19607BC
		public int EGNCKFNALIA_Vocal1 { get { return MGBKEMHECLA_Vocal1Crypted ^ FBGGEFFJJHB_xor; } set { MGBKEMHECLA_Vocal1Crypted = value ^ FBGGEFFJJHB_xor; } } // CKJKINNOKIL 0x196244C JIOKNPPGIKO 0x19607CC
		public int OIOABIDEJPG_Charm1 { get { return BMCPCMPAOEP_Charm1Crypted ^ FBGGEFFJJHB_xor; } set { BMCPCMPAOEP_Charm1Crypted = value ^ FBGGEFFJJHB_xor; } } // NGHMJMNLNIE 0x196245C AFKDHCJPFEI 0x19607DC
		public int DCICNKHCBJK_Support1 { get { return HBBAIDHNJFH_Support1Crypted ^ FBGGEFFJJHB_xor; } set { HBBAIDHNJFH_Support1Crypted = value ^ FBGGEFFJJHB_xor; } } // GEDMBCPNFHI 0x196246C DEBIACKNCLF 0x19607EC
		public int EANBFFCPKOO_Fold1 { get { return FCPKKHPHPMO_Fold1_Crypted ^ FBGGEFFJJHB_xor; } set { FCPKKHPHPMO_Fold1_Crypted = value ^ FBGGEFFJJHB_xor; } } // MOCNJMBAJKK 0x196247C FJBKNIFMKEJ 0x19607FC
		public int GPAOEGPMBOJ_NoteExpected1 { get { return LAGMNJFONLB_NoteExpected1Crypted ^ FBGGEFFJJHB_xor; } set { LAGMNJFONLB_NoteExpected1Crypted = value ^ FBGGEFFJJHB_xor; } } // KEMDEJKPDOG 0x196248C LJJNJENJGHK 0x196080C
		public int EMAGAIKNHDN_CS { get; set; } // 0x64 DAMNLKLGGAI EBHLKAEBFCE ONOKGLFKJLK
		public int AEIBPIEIBFO_CS2 { get; set; } // 0x68 KNMELHKEPDB KDFOMMHFGBL CKLAPJMCGOJ
		public int PBEPKDEEBBK_AS { get; set; } // 0x6C HOOPPDKEPIP MPMNIGEOBOC CDJEALCHFKL
		public int ECKJJCGPOPN_AS2 { get; set; } // 0x70 IJMEDLIHHPM LKFHCJFFMAJ MLJAIDJHMAI
		public int KPIIIEGGPIB_LS { get; set; } // 0x74 PJNCJOIODGP DPMKOIOIADB PFKMHCNPLLB
		public int PJKJFIOKBGJ_LS2 { get; set; } // 0x78 DPCGBPLOHJE EGNELMIPIIO FANPLCAHHNP
		public short BJNBBEMBMIK_BoardId { get; set; } // 0x7C PJFIENAGLNL LFOMFGJDJDI EABGNGKHJAO
		public short AOPBAOJIOGO_Sb { get; set; } // 0x7E IKKNPDLNPKH HDLCEEHNBKN AGKAANFCJIP
		public int ILABPFOMEAG_Va { get; set; }  // 0x80 OMFFPPDGOPE ICFAOLCLHIA LIJJLCOMANF
		public int FIHNJFKBKBD_NoteType { get; set; }  // 0x84 CHOBNFJBALL KLEAPKCDDHN NICEKBABGLD
		public int LDMOHIKFDEK_Gdrp { get { return KIEJFFPDDLJ_GdrpCrypted ^ FBGGEFFJJHB_xor; } set { KIEJFFPDDLJ_GdrpCrypted = value ^ FBGGEFFJJHB_xor; } } // IJCCFFMMALD 0x19624D4 MJDCIIBOHIL 0x1960874
		public int FPHOPBNPCML_Odrp { get { return HKGLDLJDILN_OdrpCrypted ^ FBGGEFFJJHB_xor; } set { HKGLDLJDILN_OdrpCrypted = value ^ FBGGEFFJJHB_xor; } } // DILIELECNKD 0x19624E4 PKGHMNIEJAK 0x1960884
		public int GCLAAGFKPPJ_Aofs { get; set; } // 0x90 JHOJALACCGC BBOJJFCLKJF KFMLHEGGPJA
		public List<short> GDHGEECAJGI_BoardValue { get; set; } // 0x94 PNKKMNPCGCO DGIKNGMCPGA CAMLBFJNCIK

		// // RVA: 0x19624FC Offset: 0x19624FC VA: 0x19624FC
		public int CGMFEOFCKPA_GetLife(KOGHKIODHPA_Board JEMMMJEJLNL, byte[] _KBOLNIBLIND_unlock)
		{
			return HODFCGGDHGG_GetStat(JEMMMJEJLNL, IDMPGHMNLHD.NPIEEGNKDEG.KLJAMOGANCA_Life, _KBOLNIBLIND_unlock);
		}

		// // RVA: 0x19627E8 Offset: 0x19627E8 VA: 0x19627E8
		public int ONBGNBDIGPF_GetSoul(KOGHKIODHPA_Board JEMMMJEJLNL, byte[] _KBOLNIBLIND_unlock)
		{
			return HODFCGGDHGG_GetStat(JEMMMJEJLNL, IDMPGHMNLHD.NPIEEGNKDEG.IDFLLFIBKGK_Soul, _KBOLNIBLIND_unlock);
		}

		// // RVA: 0x1962808 Offset: 0x1962808 VA: 0x1962808
		public int DPDGKOBDBJF_GetVocal(KOGHKIODHPA_Board JEMMMJEJLNL, byte[] _KBOLNIBLIND_unlock)
		{
			return HODFCGGDHGG_GetStat(JEMMMJEJLNL, IDMPGHMNLHD.NPIEEGNKDEG.JMLMELKOJND_Vocal, _KBOLNIBLIND_unlock);
		}

		// // RVA: 0x1962828 Offset: 0x1962828 VA: 0x1962828
		public int JEDMOOILJOJ_GetCharm(KOGHKIODHPA_Board JEMMMJEJLNL, byte[] _KBOLNIBLIND_unlock)
		{
			return HODFCGGDHGG_GetStat(JEMMMJEJLNL, IDMPGHMNLHD.NPIEEGNKDEG.MJEJOPJKFNK_Charm, _KBOLNIBLIND_unlock);
		}

		// // RVA: 0x1962848 Offset: 0x1962848 VA: 0x1962848
		public int MGKDKGOACDB_GetSkillLevel(KOGHKIODHPA_Board JEMMMJEJLNL, byte[] _KBOLNIBLIND_unlock)
		{
			return HODFCGGDHGG_GetStat(JEMMMJEJLNL, IDMPGHMNLHD.NPIEEGNKDEG.GMKEEAPLKHC_SkillLevel/*5*/, _KBOLNIBLIND_unlock);
		}

		// // RVA: 0x1962868 Offset: 0x1962868 VA: 0x1962868
		public int CMPJFHEFIND_GetActiveSkillLevel(KOGHKIODHPA_Board JEMMMJEJLNL, byte[] _KBOLNIBLIND_unlock)
		{
			return HODFCGGDHGG_GetStat(JEMMMJEJLNL, IDMPGHMNLHD.NPIEEGNKDEG.DEKFNLBLKEH_ActiveSkillLevel/*6*/, _KBOLNIBLIND_unlock);
		}

		// // RVA: 0x1962888 Offset: 0x1962888 VA: 0x1962888
		public int BBGLLMIFPMA_GetLiveSkillLevel(KOGHKIODHPA_Board JEMMMJEJLNL, byte[] _KBOLNIBLIND_unlock)
		{
			return HODFCGGDHGG_GetStat(JEMMMJEJLNL, IDMPGHMNLHD.NPIEEGNKDEG.AJKGPEGCJBH_LiveSkillLevel/*7*/, _KBOLNIBLIND_unlock);
		}

		// // RVA: 0x19628A8 Offset: 0x19628A8 VA: 0x19628A8
		// public int OANKNGPCIMG(KOGHKIODHPA JEMMMJEJLNL, byte[] _KBOLNIBLIND_unlock) { }

		// // RVA: 0x19628C8 Offset: 0x19628C8 VA: 0x19628C8
		// public int EEDCLCMJONO(KOGHKIODHPA JEMMMJEJLNL, byte[] _KBOLNIBLIND_unlock) { }

		// // RVA: 0x1962040 Offset: 0x1962040 VA: 0x1962040
		// public uint CAOGDCBPBAN() { }

		// // RVA: 0x19608A8 Offset: 0x19608A8 VA: 0x19608A8
		public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id)
		{
			EKLIPGELKCL_Rarity = 1;
			BCCHOBPJJKE_SceneId = _PPFNGGCBJKC_id;
			AIHCEGFANAM_SerieAttr = SeriesAttr.Type.Delta;
			EMIKBGHIOMN_SerieLogoId = SeriesLogoId.Type.DeltaTV;
			FKDCCLPGKDK_Ma = 1;
			AOLIJKMIJJE_Diva = 0;
			KELFCMEOPPM_EpisodeId = 1;
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
			LDMOHIKFDEK_Gdrp = 0;
			FPHOPBNPCML_Odrp = 0;
			GCLAAGFKPPJ_Aofs = 0;
			KPIIIEGGPIB_LS = 0;
			PJKJFIOKBGJ_LS2 = 0;
			BJNBBEMBMIK_BoardId = 7;
			AOPBAOJIOGO_Sb = 1;
			ILABPFOMEAG_Va = 0;
		}

		// // RVA: 0x196251C Offset: 0x196251C VA: 0x196251C
		public int HODFCGGDHGG_GetStat(KOGHKIODHPA_Board JEMMMJEJLNL_Board, IDMPGHMNLHD.NPIEEGNKDEG _INDDJNMPONH_type, byte[] _KBOLNIBLIND_unlock)
		{
			int res = 0;
			DMPDJFAGCPN d = JEMMMJEJLNL_Board.FDCDIHIIJJM_GetLayout(BJNBBEMBMIK_BoardId);
			if(d != null)
			{
				int l = 0;
				if(_KBOLNIBLIND_unlock != null)
				{
					for(int i = 0; i < d.PDKGMFHIFML_Panels.Count; i++)
					{
						if((i >> 3) < _KBOLNIBLIND_unlock.Length)
						{
							if(((1 << (i & 7)) & _KBOLNIBLIND_unlock[i >> 3]) != 0)
							{
								AFIFDLOAKGI a = JEMMMJEJLNL_Board.DDGNLCJGFJF(d.PDKGMFHIFML_Panels[i].JBGEEPFKIGG_val);
								if(a != null && a.INDDJNMPONH_type == (int)_INDDJNMPONH_type)
								{
									l += GDHGEECAJGI_BoardValue[i];
								}
							}
						}
					}
				}
				res = 1;
				switch(_INDDJNMPONH_type)
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
		public int NGGBHLCKJGO(KOGHKIODHPA_Board JEMMMJEJLNL, byte[] _KBOLNIBLIND_unlock, byte[] _ODKMKEHJOCK_Sb, int _JPIPENJGGDD_NumBoard, int JPJNKNOJBMM, int MBLGJDKKLPO)
		{
			int res = 0;
			if(_KBOLNIBLIND_unlock != null)
			{
				DMPDJFAGCPN d = JEMMMJEJLNL.FDCDIHIIJJM_GetLayout(BJNBBEMBMIK_BoardId);
				if(d != null)
				{
					for(int i = 0; i < d.PDKGMFHIFML_Panels.Count; i++)
					{
						int idx = i >> 3;
						if(idx < _KBOLNIBLIND_unlock.Length)
						{
							if(((1 << (i & 7)) & _KBOLNIBLIND_unlock[idx]) != 0)
							{
								AFIFDLOAKGI a = JEMMMJEJLNL.DDGNLCJGFJF(d.PDKGMFHIFML_Panels[i].JBGEEPFKIGG_val);
								if(a != null && a.INDDJNMPONH_type == 18)
								{
									res += GDHGEECAJGI_BoardValue[i];
								}
							}
						}
					}
				}
			}
			if(_ODKMKEHJOCK_Sb != null)
			{
				KOGHKIODHPA_Board.ADPMJDMFEIK data = new KOGHKIODHPA_Board.ADPMJDMFEIK();
				data.KHEKNNFCAOI_Init(JEMMMJEJLNL, AOPBAOJIOGO_Sb, 0, _JPIPENJGGDD_NumBoard, JPJNKNOJBMM, ILABPFOMEAG_Va, FKDCCLPGKDK_Ma);
				if(data.EEDDJLLIOBD_layout != null)
				{
					List<AFIFDLOAKGI> l = data.NKBGIKPCLMI(false);
					if(l.Count > 0)
					{
						if (l.Count - 1 > 0)
						{
							for (int i = 0; i < l.Count - 1; i++)
							{
								if (l[i] != null && l[i].INDDJNMPONH_type == 18)
								{
									if (((1 << (i & 7)) & _ODKMKEHJOCK_Sb[i >> 3]) != 0)
									{
										res += l[i].MKNDAOHGOAK_weight;
									}
								}
							}
						}
						if(MBLGJDKKLPO > 0)
						{
							if(l[l.Count - 1]!= null && l[l.Count - 1].INDDJNMPONH_type == 20)
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
		public int AGOEDLNOHND(KOGHKIODHPA_Board JEMMMJEJLNL, byte[] _ODKMKEHJOCK_Sb, int _JPIPENJGGDD_NumBoard, int JPJNKNOJBMM)
		{
			if(_ODKMKEHJOCK_Sb == null)
				return 0;
			else
			{
				int res = 0;
				KOGHKIODHPA_Board.ADPMJDMFEIK data = new KOGHKIODHPA_Board.ADPMJDMFEIK();
				data.KHEKNNFCAOI_Init(JEMMMJEJLNL, AOPBAOJIOGO_Sb, 0, _JPIPENJGGDD_NumBoard, JPJNKNOJBMM, ILABPFOMEAG_Va, FKDCCLPGKDK_Ma);
				if(data.EEDDJLLIOBD_layout != null)
				{
					List<AFIFDLOAKGI> l = data.NKBGIKPCLMI(false);
					for(int i = 0; i < l.Count - 1; i++)
					{
						if(l[i] != null && l[i].INDDJNMPONH_type == 19)
						{
							if(((1 << (i & 7)) & _ODKMKEHJOCK_Sb[i >> 3]) != 0)
							{
								res += l[i].MKNDAOHGOAK_weight;
							}
						}
					}
				}
				return res;
			}
		}

		// // RVA: 0x1962F5C Offset: 0x1962F5C VA: 0x1962F5C
		public int PKNGPIFNIGN(KOGHKIODHPA_Board JEMMMJEJLNL, int _JPIPENJGGDD_NumBoard, int JPJNKNOJBMM)
		{
			int res = 0;
			KOGHKIODHPA_Board.ADPMJDMFEIK a = new KOGHKIODHPA_Board.ADPMJDMFEIK();
			if(a != null)
			{
				a.KHEKNNFCAOI_Init(JEMMMJEJLNL, AOPBAOJIOGO_Sb, 0, _JPIPENJGGDD_NumBoard, JPJNKNOJBMM, ILABPFOMEAG_Va, FKDCCLPGKDK_Ma);
				if(a.EEDDJLLIOBD_layout != null)
				{
					var array = a.NKBGIKPCLMI(true);
					for (int i = 0; i < array.Count - 1; i++)
					{
						if(array[i] != null && array[i].INDDJNMPONH_type == 19)
						{
							res += array[i].MKNDAOHGOAK_weight;
						}
					}
				}
			}
			return res;
		}

		// // RVA: 0x1963110 Offset: 0x1963110 VA: 0x1963110
		public int JGKOJEOLMIL_GetNumUnlockedStory(KOGHKIODHPA_Board JEMMMJEJLNL, byte[] _KBOLNIBLIND_unlock)
		{
			if (_KBOLNIBLIND_unlock == null)
				return 0;
			else
			{
				DMPDJFAGCPN d = JEMMMJEJLNL.FDCDIHIIJJM_GetLayout(BJNBBEMBMIK_BoardId);
				int res = 0;
				for(int i = 0; i < d.PDKGMFHIFML_Panels.Count; i++)
				{
					if((i >> 3) < _KBOLNIBLIND_unlock.Length)
					{
						if(((1 << (i & 7)) & _KBOLNIBLIND_unlock[i >> 3]) != 0)
						{
							AFIFDLOAKGI a = JEMMMJEJLNL.DDGNLCJGFJF(d.PDKGMFHIFML_Panels[i].JBGEEPFKIGG_val);
							if (a != null && a.INDDJNMPONH_type == 21)
								res++;
						}
					}
				}
				return res;
			}
		}

		// // RVA: 0x1961A48 Offset: 0x1961A48 VA: 0x1961A48
		// public int BDDIGGPHGKH(IDMPGHMNLHD.NPIEEGNKDEG _INDDJNMPONH_type) { }

		// // RVA: 0x19619AC Offset: 0x19619AC VA: 0x19619AC
		public int BLNPFJKODCJ(IDMPGHMNLHD.NPIEEGNKDEG _INDDJNMPONH_type)
		{
			switch(_INDDJNMPONH_type)
			{
				case IDMPGHMNLHD.NPIEEGNKDEG.KLJAMOGANCA_Life: return JFLFKAKFKJJ_Life1_Crypted ^ FBGGEFFJJHB_xor;
				case IDMPGHMNLHD.NPIEEGNKDEG.IDFLLFIBKGK_Soul: return JBFJGPMANNM_Soul1Crypted ^ FBGGEFFJJHB_xor;
				case IDMPGHMNLHD.NPIEEGNKDEG.JMLMELKOJND_Vocal: return MGBKEMHECLA_Vocal1Crypted ^ FBGGEFFJJHB_xor;
				case IDMPGHMNLHD.NPIEEGNKDEG.MJEJOPJKFNK_Charm: return BMCPCMPAOEP_Charm1Crypted ^ FBGGEFFJJHB_xor;
				case IDMPGHMNLHD.NPIEEGNKDEG.GMKEEAPLKHC_SkillLevel:
				case IDMPGHMNLHD.NPIEEGNKDEG.DEKFNLBLKEH_ActiveSkillLevel:
				case IDMPGHMNLHD.NPIEEGNKDEG.AJKGPEGCJBH_LiveSkillLevel:
					return 1;
				case IDMPGHMNLHD.NPIEEGNKDEG.NBAPLFKEJBL_Support: return HBBAIDHNJFH_Support1Crypted ^ FBGGEFFJJHB_xor;
				case IDMPGHMNLHD.NPIEEGNKDEG.AFCFOLIHPDB_Fold: return FCPKKHPHPMO_Fold1_Crypted ^ FBGGEFFJJHB_xor;
				case IDMPGHMNLHD.NPIEEGNKDEG.LCEPKDJCNBJ: return LAGMNJFONLB_NoteExpected1Crypted ^ FBGGEFFJJHB_xor;
				default:
					return 0;
			}
		}

		// // RVA: 0x19632D0 Offset: 0x19632D0 VA: 0x19632D0
		public bool OOOPJNKBDIL_Is6OrMoreRarity()
		{
			return EKLIPGELKCL_Rarity > 5;
		}
	}

	
	public const int NBHMMGEMHAF = 6000;
	public int GEDACMANCDO; // 0x24
	new public string HDIDJNCGICK_LoadError; // 0x28

	public List<KKLDOOJBJMN> CDENCMNHNGA_table { get; set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB

	// // RVA: 0x195D7F0 Offset: 0x195D7F0 VA: 0x195D7F0
	public int NGAIKCLLDBN(int _BCCHOBPJJKE_SceneId)
	{
		return 100;
	}

	// // RVA: 0x195D7F8 Offset: 0x195D7F8 VA: 0x195D7F8
	public int BMPOAGJJNAF(int _BCCHOBPJJKE_SceneId)
	{
		return 1;
	}

	// // RVA: 0x195D800 Offset: 0x195D800 VA: 0x195D800
	public MLIBEPGADJH_Scene()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 70;
		CDENCMNHNGA_table = new List<MLIBEPGADJH_Scene.KKLDOOJBJMN>(6000);
	}

	// // RVA: 0x195D90C Offset: 0x195D90C VA: 0x195D90C Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
		GEDACMANCDO = 0;
		for(int i = 0; i < 6000; i++)
		{
			MLIBEPGADJH_Scene.KKLDOOJBJMN data = new MLIBEPGADJH_Scene.KKLDOOJBJMN();
			data.BCCHOBPJJKE_SceneId = i+1;
			data.GDHGEECAJGI_BoardValue = new List<short>(100);
			CDENCMNHNGA_table.Add(data);
		}
	}

	// // RVA: 0x195DA6C Offset: 0x195DA6C VA: 0x195DA6C Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_Data)
    {
		JNNFCGGHCAF reader = JNNFCGGHCAF.HEGEKFMJNCC(_DBBGALAPFGC_Data);
		OEMFKEODOIF(reader);
		return true;
    }

	// // RVA: 0x195EF38 Offset: 0x195EF38 VA: 0x195EF38 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		TodoLogger.LogError(TodoLogger.DbJson, "Json load");
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
			CDENCMNHNGA_table[i].FBGGEFFJJHB_xor = key;
			CDENCMNHNGA_table[i].BCCHOBPJJKE_SceneId = (int)array[i].PPFNGGCBJKC;
			CDENCMNHNGA_table[i].EKLIPGELKCL_Rarity = (sbyte)array[i].FBFLDFMFFOH;
			CDENCMNHNGA_table[i].PPEGAKEIEGM_Enabled = (sbyte)JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, (int)array[i].PLALNIIBLOF, 0);
			CDENCMNHNGA_table[i].EMIKBGHIOMN_SerieLogoId = (SeriesLogoId.Type)array[i].JPFMJHLCMJL;
			CDENCMNHNGA_table[i].AIHCEGFANAM_SerieAttr = SeriesAttr.ConvertFromLogoId(CDENCMNHNGA_table[i].EMIKBGHIOMN_SerieLogoId);
			CDENCMNHNGA_table[i].FKDCCLPGKDK_Ma = (sbyte)array[i].AOLLIMFKDAA;
			CDENCMNHNGA_table[i].HFIDCMNFBJG_Life = (int)array[i].BCCOMAODPJI;
			CDENCMNHNGA_table[i].PFJCOCPKABN_Soul = (int)array[i].LJELGFAFGAB;
			CDENCMNHNGA_table[i].JFJDLEMNKFE_Vocal = (int)array[i].KNEDJFLCCLN;
			CDENCMNHNGA_table[i].GDOLPGBLMEA_Charm = (int)array[i].MBAMIOJNGBD;
			CDENCMNHNGA_table[i].HCFOMFDPGEC_Support = (int)array[i].PIPCIMIALOO;
			CDENCMNHNGA_table[i].ONDFNOOICLE_Fold = (int)array[i].ADLGKMBIPCA;
			CDENCMNHNGA_table[i].FLGDCCFAGEL_NotesExpected = (int)array[i].PFJJFCPPNIN;
			CDENCMNHNGA_table[i].AOLIJKMIJJE_Diva = (int)array[i].OCAMDLMPBGA;
			CDENCMNHNGA_table[i].KELFCMEOPPM_EpisodeId = (short)array[i].FELIFAHDLON;
			CDENCMNHNGA_table[i].MCCIFLKCNKO_Feed = array[i].KALPJIJCHFO != 0;
			CDENCMNHNGA_table[i].FBJDHLGODPP_Sngl = array[i].DPHMNJNCHJG != 0;
			CDENCMNHNGA_table[i].LFPEIEOHABE_Pstv = array[i].NPJOJEHFBKG;
			CDENCMNHNGA_table[i].JFLFKAKFKJJ_Life1_Crypted = (int)array[i].MOPBJIOCKML ^ CDENCMNHNGA_table[i].FBGGEFFJJHB_xor;
			CDENCMNHNGA_table[i].JBFJGPMANNM_Soul1Crypted = (int)array[i].NDDDBPKPMDK ^ CDENCMNHNGA_table[i].FBGGEFFJJHB_xor;
			CDENCMNHNGA_table[i].MGBKEMHECLA_Vocal1Crypted = (int)array[i].KKPADIFPHOK ^ CDENCMNHNGA_table[i].FBGGEFFJJHB_xor;
			CDENCMNHNGA_table[i].BMCPCMPAOEP_Charm1Crypted = (int)array[i].JCAPANAALDF ^ CDENCMNHNGA_table[i].FBGGEFFJJHB_xor;
			CDENCMNHNGA_table[i].HBBAIDHNJFH_Support1Crypted = (int)array[i].FMGKFCHAOCF ^ CDENCMNHNGA_table[i].FBGGEFFJJHB_xor;
			CDENCMNHNGA_table[i].FCPKKHPHPMO_Fold1_Crypted = (int)array[i].ILKEDIDGNLP ^ CDENCMNHNGA_table[i].FBGGEFFJJHB_xor;
			CDENCMNHNGA_table[i].LAGMNJFONLB_NoteExpected1Crypted = (int)array[i].BCIDCCGECBG ^ CDENCMNHNGA_table[i].FBGGEFFJJHB_xor;
			CDENCMNHNGA_table[i].JIJOGLFOOMN_Aver = (int)array[i].JIJOGLFOOMN;
			CDENCMNHNGA_table[i].EMAGAIKNHDN_CS = (int)array[i].AKOJJJLPCKA;
			CDENCMNHNGA_table[i].PBEPKDEEBBK_AS = (int)array[i].ELBJIFCDJGO;
			CDENCMNHNGA_table[i].KPIIIEGGPIB_LS = (int)array[i].LNKKMBCDPHH;
			CDENCMNHNGA_table[i].AEIBPIEIBFO_CS2 = (int)array[i].GBIIBCHECJC;
			CDENCMNHNGA_table[i].ECKJJCGPOPN_AS2 = (int)array[i].GPPCEKHBMCO;
			CDENCMNHNGA_table[i].PJKJFIOKBGJ_LS2 = (int)array[i].FPNNEEHLIJM;
			CDENCMNHNGA_table[i].BJNBBEMBMIK_BoardId = (short)array[i].LHAFADCJBME;
			CDENCMNHNGA_table[i].AOPBAOJIOGO_Sb = (short)array[i].KOHNLDKIKPC;
			CDENCMNHNGA_table[i].ILABPFOMEAG_Va = (int)array[i].FIKLIDJBPBB;
			CDENCMNHNGA_table[i].FIHNJFKBKBD_NoteType = (int)array[i].AIFGNKMBFCD;
			CDENCMNHNGA_table[i].LDMOHIKFDEK_Gdrp = (int)array[i].JLHAHAMAIBG;
			CDENCMNHNGA_table[i].FPHOPBNPCML_Odrp = (int)array[i].OKEFHPHNFNK;
			CDENCMNHNGA_table[i].GCLAAGFKPPJ_Aofs = (int)array[i].FGJKNLLDHJI;
			if(CDENCMNHNGA_table[i].PPEGAKEIEGM_Enabled == 2)
			{
				GEDACMANCDO++;
			}
		}
		for(int i = array.Length; i < 6000; i++)
		{
			CDENCMNHNGA_table[i].LHPDDGIJKNB_Reset(i+1);
		}
		return true;
	}

	// // RVA: 0x195EF3C Offset: 0x195EF3C VA: 0x195EF3C
	// private bool OEMFKEODOIF(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label) { }

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
		for (int i = 0; i < CDENCMNHNGA_table.Count; i++)
		{
			DMPDJFAGCPN layout = JEMMMJEJLNL_BoardDB.FDCDIHIIJJM_GetLayout(CDENCMNHNGA_table[i].BJNBBEMBMIK_BoardId);
			for (int j = 0; j < 22; j++)
			{
				l1[j] = 0;
				l2[j] = 0;
				l3[j] = 0;
			}
			for (int j = 0; j < layout.PDKGMFHIFML_Panels.Count; j++)
			{
				AFIFDLOAKGI a = JEMMMJEJLNL_BoardDB.DDGNLCJGFJF(layout.PDKGMFHIFML_Panels[j].JBGEEPFKIGG_val);
				if (a != null)
				{
					l1[a.INDDJNMPONH_type] += a.MKNDAOHGOAK_weight;
				}
			}
			for (int j = 0; j < 22; j++)
			{
				int val = CDENCMNHNGA_table[i].BLNPFJKODCJ((IDMPGHMNLHD.NPIEEGNKDEG)j);
				int val2 = 1;
				switch (j)
				{
					case 1: val2 = CDENCMNHNGA_table[i].HFIDCMNFBJG_Life; break;
					case 2: val2 = CDENCMNHNGA_table[i].PFJCOCPKABN_Soul; break;
					case 3: val2 = CDENCMNHNGA_table[i].JFJDLEMNKFE_Vocal; break;
					case 4: val2 = CDENCMNHNGA_table[i].GDOLPGBLMEA_Charm; break;
					case 8: val2 = CDENCMNHNGA_table[i].HCFOMFDPGEC_Support; break;
					case 9: val2 = CDENCMNHNGA_table[i].ONDFNOOICLE_Fold; break;
					case 0xb: val2 = CDENCMNHNGA_table[i].FLGDCCFAGEL_NotesExpected; break;
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
			CDENCMNHNGA_table[i].GDHGEECAJGI_BoardValue.Clear();
			for (int j = 0; j < layout.PDKGMFHIFML_Panels.Count; j++)
			{
				AFIFDLOAKGI a = JEMMMJEJLNL_BoardDB.DDGNLCJGFJF(layout.PDKGMFHIFML_Panels[j].JBGEEPFKIGG_val);
				int val = 0;
				if(a != null)
				{
					if(a.INDDJNMPONH_type == 18 || a.INDDJNMPONH_type == 6 || a.INDDJNMPONH_type == 5 || a.INDDJNMPONH_type == 7 || a.INDDJNMPONH_type == 21)
					{
						val = a.MKNDAOHGOAK_weight;
						l3[a.INDDJNMPONH_type] += val;
					}
					else if(a.INDDJNMPONH_type != 20 && a.INDDJNMPONH_type != 10 && l1[a.INDDJNMPONH_type] != 0)
					{
						val = (a.MKNDAOHGOAK_weight * l2[a.INDDJNMPONH_type]) / l1[a.INDDJNMPONH_type];
						l3[a.INDDJNMPONH_type] += val;
					}
				}
				CDENCMNHNGA_table[i].GDHGEECAJGI_BoardValue.Add((short)val);
			}
			for (int j = 0; j < 22; j++)
			{
				int k = 0;
				if (l3[j] != 0 || l2[j] < 1)
				{
					while(k <= 99999 && l3.Count < l2.Count)
					{
						for(int l = layout.PDKGMFHIFML_Panels.Count - 1; l >= 0; l--)
						{
							k++;
							if (l3[j] >= l2[j])
								break;
							AFIFDLOAKGI a = JEMMMJEJLNL_BoardDB.DDGNLCJGFJF(layout.PDKGMFHIFML_Panels[l].JBGEEPFKIGG_val);
							if(a != null)
							{
								CDENCMNHNGA_table[i].GDHGEECAJGI_BoardValue[l]++;
								l3[j]++;
							}
						}
					}
				}
			}
			CDENCMNHNGA_table[i].OCKJIHPHMDE = HNMMJINNHII_GameDB.KLIGCACGHHN(JEMMMJEJLNL_BoardDB, CDENCMNHNGA_table[i].AOPBAOJIOGO_Sb, CDENCMNHNGA_table[i].ILABPFOMEAG_Va, CDENCMNHNGA_table[i].EKLIPGELKCL_Rarity, CDENCMNHNGA_table[i].MCCIFLKCNKO_Feed);
		}
	}

	// // RVA: 0x1961B04 Offset: 0x1961B04 VA: 0x1961B04
	public bool FDIOFBGJKNO(int _BCCHOBPJJKE_SceneId)
	{
		if(_BCCHOBPJJKE_SceneId > 0)
		{
			if(_BCCHOBPJJKE_SceneId <= CDENCMNHNGA_table.Count)
			{
				if(CDENCMNHNGA_table[_BCCHOBPJJKE_SceneId - 1].PPEGAKEIEGM_Enabled == 2)
				{
					if(CDENCMNHNGA_table[_BCCHOBPJJKE_SceneId - 1].EKLIPGELKCL_Rarity >= 4 && CDENCMNHNGA_table[_BCCHOBPJJKE_SceneId - 1].LFPEIEOHABE_Pstv > 0)
					{
						return CDENCMNHNGA_table[_BCCHOBPJJKE_SceneId - 1].LFPEIEOHABE_Pstv <= IEFOPDOOLOK_MasterVersion;
					}
				}
			}
		}
		return false;
	}

	// // RVA: 0x1961C54 Offset: 0x1961C54 VA: 0x1961C54
	public int KBEGPJEBFMA(int _BCCHOBPJJKE_SceneId)
	{
		if(_BCCHOBPJJKE_SceneId > 0 && _BCCHOBPJJKE_SceneId <= CDENCMNHNGA_table.Count)
		{
			if(CDENCMNHNGA_table[_BCCHOBPJJKE_SceneId - 1].PPEGAKEIEGM_Enabled == 2)
				return CDENCMNHNGA_table[_BCCHOBPJJKE_SceneId - 1].LFPEIEOHABE_Pstv;
		}
		return 0;
	}

	// // RVA: 0x1961D38 Offset: 0x1961D38 VA: 0x1961D38
	public bool OEEJKKFOBKD(int _BCCHOBPJJKE_SceneId)
	{
		if(_BCCHOBPJJKE_SceneId > 0)
		{
			if(_BCCHOBPJJKE_SceneId <= CDENCMNHNGA_table.Count)
			{
				if(CDENCMNHNGA_table[_BCCHOBPJJKE_SceneId - 1].PPEGAKEIEGM_Enabled == 2)
				{
					return CDENCMNHNGA_table[_BCCHOBPJJKE_SceneId - 1].FBJDHLGODPP_Sngl;
				}
			}
		}
		return false;
	}

	// // RVA: 0x1961E30 Offset: 0x1961E30 VA: 0x1961E30
	public int ELKHCOEMNOJ(int _BCCHOBPJJKE_SceneId, int _DMNIMMGGJJJ_Leaf, LLKLAKGKNLD_LimitOver HDGOHBFKKDM)
	{
		if(_BCCHOBPJJKE_SceneId > 0)
		{
			if (_BCCHOBPJJKE_SceneId <= CDENCMNHNGA_table.Count)
			{
				if(CDENCMNHNGA_table[_BCCHOBPJJKE_SceneId - 1].EKLIPGELKCL_Rarity > 4)
				{
					int a = HDGOHBFKKDM.ELFPIODODFF(CDENCMNHNGA_table[_BCCHOBPJJKE_SceneId - 1].EKLIPGELKCL_Rarity);
					if (a > 0)
						return a <= _DMNIMMGGJJJ_Leaf ? 1 : 0;
				}
			}
		}
		return 0;
	}

	// // RVA: 0x1961F54 Offset: 0x1961F54 VA: 0x1961F54 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "MLIBEPGADJH_Scene.CAOGDCBPBAN");
		return 0;
	}

	// // RVA: 0x195BFB8 Offset: 0x195BFB8 VA: 0x195BFB8
	public bool FGNJBMPDBLO_IsSceneValid(int _BCCHOBPJJKE_SceneId)
	{
		bool res = true;
		if(_BCCHOBPJJKE_SceneId != 0)
		{
			if(_BCCHOBPJJKE_SceneId > 0)
			{
				if(_BCCHOBPJJKE_SceneId <= CDENCMNHNGA_table.Count)
				{
					if(CDENCMNHNGA_table[_BCCHOBPJJKE_SceneId - 1].PPEGAKEIEGM_Enabled == 2)
					{
						return CDENCMNHNGA_table[_BCCHOBPJJKE_SceneId - 1].BCCHOBPJJKE_SceneId == _BCCHOBPJJKE_SceneId;
					}
				}
			}
			res = false;
		}
		return res;
	}

	// // RVA: 0x196225C Offset: 0x196225C VA: 0x196225C
	public KKLDOOJBJMN PLKHCPPCHJL(int GJGIFNEAHJN)
	{
		for (int i = 0; i < CDENCMNHNGA_table.Count; i++)
		{
			if(CDENCMNHNGA_table[i].PPEGAKEIEGM_Enabled > 1)
			{
				if(CDENCMNHNGA_table[i].KELFCMEOPPM_EpisodeId == GJGIFNEAHJN)
				{
					return CDENCMNHNGA_table[i];
				}
			}
		}
		return null;
	}
}

public class IDMPGHMNLHD
{
	public enum NPIEEGNKDEG
	{
		HJNNKCMLGFL_0_None = 0,
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
		LAOEGNLOJHC_17_Start = 17,
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
