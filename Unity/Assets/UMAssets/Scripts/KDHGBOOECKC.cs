using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System;
using XeSys;
using XeApp.Game;
using XeApp.Game.Menu;
using XeApp.Game.Common;

public class KDHGBOOECKC
{
	public class NKMCJCAJIGD
	{
		private int ICPJNJLHKPB; // 0x8
		private int KDPLFFJOLFI; // 0xC

		public int MLDPDLPHJPM_OfferId { get { return ICPJNJLHKPB ^ 0x7138b4a5; } set { ICPJNJLHKPB = value ^ 0x7138b4a5; } } //0xE7481C EJEKNOACOFD 0xE74830 DBBHJDGJOCA
		public BOPFPIHGJMD.MLBMHDCCGHI FGHGMHPNEMG_Type { get { return (BOPFPIHGJMD.MLBMHDCCGHI)(KDPLFFJOLFI ^ 0x7138b4a5); } set { KDPLFFJOLFI = (int)value ^ 0x7138b4a5; } } //0xE74844 PCFFCOKAHBD 0xE74858 JBCALBBCBLF
			
		// RVA: 0xE74874 Offset: 0xE74874 VA: 0xE74874
		public void LHPDDGIJKNB_Reset()
		{
			ICPJNJLHKPB = 0x7138b4a5;
			KDPLFFJOLFI = 0x7138b4a5;
		}
	}

	public class JLLOKCFPOFH
	{
		private int EAJCFBCHIFB_RarityCrypted; // 0x8
		private int CNABOLBIBMH; // 0xC

		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ 0x7138b4a5; } set { EAJCFBCHIFB_RarityCrypted = value ^ 0x7138b4a5; } } //0xE72090 OEEHBGECGKL 0xE73D00 GHLMHLJJBIG
		public int EGDEGGMPIGA_normal { get { return CNABOLBIBMH ^ 0x7138b4a5; } set { CNABOLBIBMH = value ^ 0x7138b4a5; } } //0xE720A4 ECJJIGCGIIO 0xE73D14 AAMILKDNEML

		// RVA: 0xE73D30 Offset: 0xE73D30 VA: 0xE73D30
		public void LHPDDGIJKNB_Reset()
		{
			EAJCFBCHIFB_RarityCrypted = 0x7138b4a5;
			CNABOLBIBMH = 0x7138b4a5;
		}
	}

	public class IBAOKNMIBCL
	{
		private int EHOIENNDEDH_IdCrypted; // 0x8
		private int IFEHKNJONPL_CountCrypted; // 0xC
		private int DGBAEDJPAMA; // 0x10
		private int MKENMKMJFKP_TypeCrypted; // 0x14

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ 0x7138b4a5; } set { EHOIENNDEDH_IdCrypted = value ^ 0x7138b4a5; } } //0xE720CC DEMEPMAEJOO 0xE720E0 HIGKAIDMOKN
		public int BFINGCJHOHI_cnt { get { return IFEHKNJONPL_CountCrypted ^ 0x7138b4a5; } set { IFEHKNJONPL_CountCrypted = value ^ 0x7138b4a5; } } //0xE720B8 LFMCLIDAPHB 0xE724B4 EDAEPDGGFJJ
		public int DKHIHHMOIKM_bns { get { return DGBAEDJPAMA ^ 0x7138b4a5; } set { DGBAEDJPAMA = value ^ 0x7138b4a5; } } //0xE72DB4 OCOHLFAFINM 0xE72DA0 DPEOFJJLPML
		public BOPFPIHGJMD.CJDCPBACOLH INDDJNMPONH_type { get { return (BOPFPIHGJMD.CJDCPBACOLH)(MKENMKMJFKP_TypeCrypted ^ 0x7138b4a5); } set { MKENMKMJFKP_TypeCrypted = (int)value ^ 0x7138b4a5; } } //0xE72D8C GHAILOLPHPF 0xE73CC0 BACGOKIGMBC

		// RVA: 0xE73CD8 Offset: 0xE73CD8 VA: 0xE73CD8
		public void LHPDDGIJKNB_Reset()
		{
			EHOIENNDEDH_IdCrypted = 0x7138b4a5;
			IFEHKNJONPL_CountCrypted = 0x7138b4a5;
			DGBAEDJPAMA = 0x7138b4a5;
			MKENMKMJFKP_TypeCrypted = 0x7138b4a6;
		}

		// RVA: 0xE7295C Offset: 0xE7295C VA: 0xE7295C
		public void ODDIHGPONFL_Copy(IBAOKNMIBCL GPBJHKLFCEP)
		{
			EHOIENNDEDH_IdCrypted = GPBJHKLFCEP.EHOIENNDEDH_IdCrypted;
			IFEHKNJONPL_CountCrypted = GPBJHKLFCEP.IFEHKNJONPL_CountCrypted;
			DGBAEDJPAMA = GPBJHKLFCEP.DGBAEDJPAMA;
			MKENMKMJFKP_TypeCrypted = GPBJHKLFCEP.MKENMKMJFKP_TypeCrypted;
		}
	}

	public class CBJJINJDFDC
	{
		public List<IBAOKNMIBCL> BHKKEJJMMDD; // 0x8
		public List<IBAOKNMIBCL> ENEHOPNDNAF; // 0xC
		public List<IBAOKNMIBCL> AJPLGEHPPGN; // 0x10
		public int OKDOMNJHGNF_Confirm; // 0x14
		public int MFNCONLNBPB_Rare; // 0x18
		public int OOEFNNNFOLF_Nomal; // 0x1C
		public bool KKBAGBFOPIJ_IsBonus; // 0x20
		public int FLIEFMMPKHF_BonusNum; // 0x24
		public int CMMNABJIKOH_UCNum; // 0x28
		public bool JLDJAOCIIIG_IsGreatSuccess; // 0x2C

		// // RVA: 0xE716D8 Offset: 0xE716D8 VA: 0xE716D8
		public CBJJINJDFDC FKDIMODKKJD(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId)
		{
			if(KDHGBOOECKC.HHCJCDFCLOB != null)
			{
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
				{
					if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
					{
						LGHIPHEDCNC_Offer.NONCDAINJLD of2 = KDHGBOOECKC.HHCJCDFCLOB.GKIOIHLDBGF(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
						OCMJNBIFJNM_Offer.JPOHOLBBFGP of = KDHGBOOECKC.HHCJCDFCLOB.BKJJKHIBIGP(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
						JLLOKCFPOFH d = KDHGBOOECKC.HHCJCDFCLOB.DOBIMMEGLOB(of2.GOKJLBDJOLA_df, true);
						int a1 = 2;
						if(of.MNCEBKHBBEF_VFform != 0)
						{
							a1 = of.MNCEBKHBBEF_VFform;
							if (a1 != 1)
								a1 = 0;
						}
						JLDJAOCIIIG_IsGreatSuccess = of.DPMCPMJJGAA_HasFlag(BOPFPIHGJMD.CMBJEEGFODD.CDFJPMPHNJM_8);
						List<IBAOKNMIBCL> l = KDHGBOOECKC.HHCJCDFCLOB.NLAPKNDOEPL_GetConfirmList(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
						List<IBAOKNMIBCL> l2 = new List<IBAOKNMIBCL>();
						if(JLDJAOCIIIG_IsGreatSuccess && d.EKLIPGELKCL_Rarity > 0)
						{
							l2.Add(KDHGBOOECKC.HHCJCDFCLOB.LEPDAMFKAJP(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.IGIBGGIACBC, of2.FCDMDDIHMPO));
						}
						if (d.EKLIPGELKCL_Rarity > 0)
						{
							l2.AddRange(KDHGBOOECKC.HHCJCDFCLOB.FOACCNFAGCH(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.IGIBGGIACBC, BOPFPIHGJMD.CJDCPBACOLH.GAEONADENEJ_2_RARE, of2.FCDMDDIHMPO, d.EKLIPGELKCL_Rarity));
						}
						List<IBAOKNMIBCL> l3 = KDHGBOOECKC.HHCJCDFCLOB.FOACCNFAGCH(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.CIMLFGFMFCH, BOPFPIHGJMD.CJDCPBACOLH.CCAPCGPIIPF_3_NOMAL, of2.FFCJEOLDKGN(a1), d.EGDEGGMPIGA_normal);
						OKDOMNJHGNF_Confirm = 0;
						MFNCONLNBPB_Rare = 0;
						OOEFNNNFOLF_Nomal = 0;
						for(int i = 0; i < l.Count; i++)
						{
							OKDOMNJHGNF_Confirm += l[i].BFINGCJHOHI_cnt;
						}
						for(int i = 0; i < l2.Count; i++)
						{
							MFNCONLNBPB_Rare += l2[i].BFINGCJHOHI_cnt;
						}
						for (int i = 0; i < l3.Count; i++)
						{
							OOEFNNNFOLF_Nomal += l3[i].BFINGCJHOHI_cnt;
						}
						BHKKEJJMMDD = new List<IBAOKNMIBCL>();
						BHKKEJJMMDD.AddRange(l);
						BHKKEJJMMDD.AddRange(l2);
						BHKKEJJMMDD.AddRange(l3);
						int item_instead_of_emblem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA_GetIntParam("item_instead_of_emblem", EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit, 5));
						COOFLMBIHML data = new COOFLMBIHML();
						data.KHEKNNFCAOI_Init(4, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, true);
						for(int i = 0; i < BHKKEJJMMDD.Count; i++)
						{
							EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BHKKEJJMMDD[i].PPFNGGCBJKC_id);
							if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem)
							{
								int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(BHKKEJJMMDD[i].PPFNGGCBJKC_id);
								if (EKLNMHFCAOI.AFEONHCADEL_GetMaxAllowed(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, cat, id, null) <= EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, cat, id, null))
									BHKKEJJMMDD[i].PPFNGGCBJKC_id = item_instead_of_emblem;
							}
							else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene && BHKKEJJMMDD[i].PPFNGGCBJKC_id == 40000)
							{
								BHKKEJJMMDD[i].PPFNGGCBJKC_id = 40000 + data.NEHHNEPPIBK();
							}
						}
						return this;
					}
				}
			}
			return null;
		}

		// // RVA: 0xE720F4 Offset: 0xE720F4 VA: 0xE720F4
		public void CDNFIAKLGLH(ref List<IBAOKNMIBCL> FFKPGLNBMNL, List<IBAOKNMIBCL> PEGBLDOPIPM, bool AJBPBOECIMB)
		{
			FFKPGLNBMNL.Clear();
			for (int i = 0; i < PEGBLDOPIPM.Count; i++)
			{
				IBAOKNMIBCL d = FFKPGLNBMNL.Find((IBAOKNMIBCL JPAEDJJFFOI) =>
				{
					//0xE73844
					if(AJBPBOECIMB)
					{
						if (JPAEDJJFFOI.INDDJNMPONH_type != PEGBLDOPIPM[i].INDDJNMPONH_type)
							return false;
					}
					return JPAEDJJFFOI.PPFNGGCBJKC_id == PEGBLDOPIPM[i].PPFNGGCBJKC_id;
				});
				if(d == null)
				{
					FFKPGLNBMNL.Add(PEGBLDOPIPM[i]);
				}
				else
				{
					d.BFINGCJHOHI_cnt += PEGBLDOPIPM[i].BFINGCJHOHI_cnt;
				}
			}
			FFKPGLNBMNL.Sort((IBAOKNMIBCL _HKICMNAACDA_a, IBAOKNMIBCL _BNKHBCBJBKI_b) =>
			{
				//0xE736E8
				if(_HKICMNAACDA_a.INDDJNMPONH_type == _BNKHBCBJBKI_b.INDDJNMPONH_type)
				{
					return _BNKHBCBJBKI_b.PPFNGGCBJKC_id.CompareTo(_HKICMNAACDA_a.PPFNGGCBJKC_id);
				}
				else
				{
					return _HKICMNAACDA_a.INDDJNMPONH_type.CompareTo(_BNKHBCBJBKI_b.INDDJNMPONH_type);
				}
			});
		}

		// // RVA: 0xE724C8 Offset: 0xE724C8 VA: 0xE724C8
		public List<IBAOKNMIBCL> CDNFIAKLGLH()
		{
			ENEHOPNDNAF = new List<IBAOKNMIBCL>();
			CDNFIAKLGLH(ref ENEHOPNDNAF, BHKKEJJMMDD, true);
			return ENEHOPNDNAF;
		}

		// // RVA: 0xE72564 Offset: 0xE72564 VA: 0xE72564
		public List<IBAOKNMIBCL> JEMAJJIPHGA(long _JHNMKKNEENE_Time)
		{
			AJPLGEHPPGN = new List<IBAOKNMIBCL>();
			AJPLGEHPPGN.Clear();
			if(ENEHOPNDNAF != null)
			{
				List<IBAOKNMIBCL> l = new List<IBAOKNMIBCL>();
				l.Clear();
				for(int i = 0; i < ENEHOPNDNAF.Count; i++)
				{
					IBAOKNMIBCL d = ENEHOPNDNAF[i];
					for(int j = 0; j < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.DDKAFBFPIEA.Count; j++)
					{
						LGHIPHEDCNC_Offer.FFNEKFPAGDO of = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.DDKAFBFPIEA[j];
						if (d.PPFNGGCBJKC_id == of.PPFNGGCBJKC_id)
						{
							if(_JHNMKKNEENE_Time >= of.NHPCKCOPKAM_from)
							{
								if (of.PJFKNNNDMIA_to >= _JHNMKKNEENE_Time)
									continue;
							}
							IBAOKNMIBCL r = new IBAOKNMIBCL();
							r.ODDIHGPONFL_Copy(d);
							l.Add(r);
						}
					}
				}
				CDNFIAKLGLH(ref AJPLGEHPPGN, l, false);
			}
			return AJPLGEHPPGN;
		}

		// // RVA: 0xE729E0 Offset: 0xE729E0 VA: 0xE729E0
		public List<IBAOKNMIBCL> KBEMAMHADOO(List<IBAOKNMIBCL> APMMCLKENBI, List<IBAOKNMIBCL> HJAGDFOMEPM)
		{
			List<IBAOKNMIBCL> res = new List<IBAOKNMIBCL>();
			res.Clear();
			for(int i = 0; i < APMMCLKENBI.Count; i++)
			{
				List<IBAOKNMIBCL> d = HJAGDFOMEPM.FindAll((IBAOKNMIBCL JPAEDJJFFOI) =>
				{
					//0xE738EC
					return JPAEDJJFFOI.PPFNGGCBJKC_id == APMMCLKENBI[i].PPFNGGCBJKC_id;
				});
				if (d.Count == 0)
					res.Add(APMMCLKENBI[i]);
			}
			return res;
		}

		// // RVA: 0xE72C54 Offset: 0xE72C54 VA: 0xE72C54
		public List<IBAOKNMIBCL> JEMJKEPLPAA(int KGMACNGGCNB, BOPFPIHGJMD.CJDCPBACOLH _HHACNFODNEF_ItemCategory)
		{
			for(int i = 0; i < ENEHOPNDNAF.Count; i++)
			{
				if(ENEHOPNDNAF[i].INDDJNMPONH_type == _HHACNFODNEF_ItemCategory)
				{
					int a = (ENEHOPNDNAF[i].BFINGCJHOHI_cnt * KGMACNGGCNB + 99) / 100;
					ENEHOPNDNAF[i].BFINGCJHOHI_cnt += a;
					ENEHOPNDNAF[i].DKHIHHMOIKM_bns = a;
				}
			}
			return ENEHOPNDNAF;
		}

		// // RVA: 0xE72DC8 Offset: 0xE72DC8 VA: 0xE72DC8
		public int JLHACGNEFPJ_GetNumUc(List<IBAOKNMIBCL> NNDGIAEFMOG)
		{
			int res = 0;
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				for(int i = 0; i < NNDGIAEFMOG.Count; i++)
				{
					if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(NNDGIAEFMOG[i].PPFNGGCBJKC_id) == EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit)
					{
						int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(NNDGIAEFMOG[i].PPFNGGCBJKC_id);
						if (id > 0)
						{
							DGDIEDDPNNG_UcItem.FCPCMPLGJNP dbItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NMJEDFNPIPL_UcItem.CDENCMNHNGA_table[id - 1];
							res += dbItem.JBGEEPFKIGG_val * NNDGIAEFMOG[i].BFINGCJHOHI_cnt;
						}
					}
				}
			}
			return res;
		}

		// // RVA: 0xE7304C Offset: 0xE7304C VA: 0xE7304C
		private void OIBNJADJHHG(JKNGJFOBADP _JANMJPOKLFL_InventoryUtil, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, int _KIJAPOFAGPN_ItemId, int _HMFFHLPNMPH_count, BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId)
		{
			StringBuilder str = new StringBuilder();
			str.Append(_FGHGMHPNEMG_Type);
			str.Append(':');
			str.Append(_MLDPDLPHJPM_OfferId);
			str.Append(':');
			str.Append(KDHGBOOECKC.HHCJCDFCLOB.OHDGMEGGLDP_GetSessionId(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId));
			_JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.JJGHKIBKFFJ_23, str.ToString());
			_JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(_LDEGEHAEALK_ServerData, _KIJAPOFAGPN_ItemId, _HMFFHLPNMPH_count, null, 0);
		}

		// // RVA: 0xE73264 Offset: 0xE73264 VA: 0xE73264
		public bool BOAOOEIIAHG(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId, List<IBAOKNMIBCL> NNDGIAEFMOG)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
			{
				CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ();
				for(int i = 0; i < NNDGIAEFMOG.Count; i++)
				{
					OIBNJADJHHG(CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL_InventoryUtil, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, NNDGIAEFMOG[i].PPFNGGCBJKC_id, NNDGIAEFMOG[i].BFINGCJHOHI_cnt, _FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
				}
				return true;
			}
			return false;
		}

		// // RVA: 0xE7349C Offset: 0xE7349C VA: 0xE7349C
		public bool BOAOOEIIAHG(JKNGJFOBADP _JANMJPOKLFL_InventoryUtil, BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId, List<IBAOKNMIBCL> NNDGIAEFMOG)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
			{
				for(int i = 0; i < NNDGIAEFMOG.Count; i++)
				{
					OIBNJADJHHG(_JANMJPOKLFL_InventoryUtil, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, NNDGIAEFMOG[i].PPFNGGCBJKC_id, NNDGIAEFMOG[i].BFINGCJHOHI_cnt, _FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
				}
			}
			return false;
		}
	}

	public class GBAGPIKOGAN_DivaOfferInfo
	{
		public int AHHJLDLAPAN_DivaId; // 0x8
		public int MLDPDLPHJPM_OfferId; // 0xC
		public string MBALOBPODGA_DivaName; // 0x10
		public string PGOGHFDBIBA_OfferName; // 0x14
		public string PNOBKANLFHA_OfferText; // 0x18
		public BOPFPIHGJMD.LEIPFJHOFPC OAFPGJLCNFM_cond; // 0x1C
		public int KFEMFDFPCGO_Level0; // 0x20
		public int CIEOBFIIPLD_Level; // 0x24
		public bool NBHEBLNHOJO_IsMaxLevel; // 0x28

		// RVA: 0xE73938 Offset: 0xE73938 VA: 0xE73938
		public void LHPDDGIJKNB_Reset()
		{
			MLDPDLPHJPM_OfferId = 0;
			AHHJLDLAPAN_DivaId = 0;
			PGOGHFDBIBA_OfferName = "";
			MBALOBPODGA_DivaName = "";
			PNOBKANLFHA_OfferText = "";
			CIEOBFIIPLD_Level = 0;
			KFEMFDFPCGO_Level0 = 0;
			OAFPGJLCNFM_cond = BOPFPIHGJMD.LEIPFJHOFPC.HJNNKCMLGFL_0_None/*0*/;
		}

		// // RVA: 0xE739BC Offset: 0xE739BC VA: 0xE739BC
		public void ODDIHGPONFL_Copy(GBAGPIKOGAN_DivaOfferInfo GPBJHKLFCEP)
		{
			AHHJLDLAPAN_DivaId = GPBJHKLFCEP.AHHJLDLAPAN_DivaId;
			MLDPDLPHJPM_OfferId = GPBJHKLFCEP.MLDPDLPHJPM_OfferId;
			MBALOBPODGA_DivaName = GPBJHKLFCEP.MBALOBPODGA_DivaName;
			PGOGHFDBIBA_OfferName = GPBJHKLFCEP.PGOGHFDBIBA_OfferName;
			PNOBKANLFHA_OfferText = GPBJHKLFCEP.PNOBKANLFHA_OfferText;
			OAFPGJLCNFM_cond = GPBJHKLFCEP.OAFPGJLCNFM_cond;
			KFEMFDFPCGO_Level0 = GPBJHKLFCEP.KFEMFDFPCGO_Level0;
			CIEOBFIIPLD_Level = GPBJHKLFCEP.CIEOBFIIPLD_Level;
			NBHEBLNHOJO_IsMaxLevel = GPBJHKLFCEP.NBHEBLNHOJO_IsMaxLevel;
		}

		// // RVA: 0xE73ACC Offset: 0xE73ACC VA: 0xE73ACC
		public bool AGBOGBEOFME(GBAGPIKOGAN_DivaOfferInfo OIKJFMGEICL)
		{
			return AHHJLDLAPAN_DivaId == OIKJFMGEICL.AHHJLDLAPAN_DivaId &&
				MLDPDLPHJPM_OfferId == OIKJFMGEICL.MLDPDLPHJPM_OfferId &&
				MBALOBPODGA_DivaName == OIKJFMGEICL.MBALOBPODGA_DivaName &&
				PGOGHFDBIBA_OfferName == OIKJFMGEICL.PGOGHFDBIBA_OfferName &&
				PNOBKANLFHA_OfferText == OIKJFMGEICL.PNOBKANLFHA_OfferText &&
				NBHEBLNHOJO_IsMaxLevel == OIKJFMGEICL.NBHEBLNHOJO_IsMaxLevel &&
				OAFPGJLCNFM_cond == OIKJFMGEICL.OAFPGJLCNFM_cond &&
				KFEMFDFPCGO_Level0 == OIKJFMGEICL.KFEMFDFPCGO_Level0 &&
				CIEOBFIIPLD_Level == OIKJFMGEICL.CIEOBFIIPLD_Level;
		}
	}
	public enum LEIPFJHOFPC
	{
		HJNNKCMLGFL_0_None = 0,
		NBDBAFGEEGA = 1,
		GLFGNEILACA = 2,
		GEJGMBBCFEE = 3,
	}

	public class LKBMNFAOOII
	{
		public BOPFPIHGJMD.AGGLEGJDLGF HHACNFODNEF_ItemCategory; // 0x8 //PayType
		public int AICGFEIBKFL_Price; // 0xC
		public int ADPPAIPFHML_num; // 0x10
		public int DOOGFEGEKLG_max; // 0x14
	}

	public class PGCENGCEJGB
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int MKPJBDFDHOL_ThumbId; // 0xC
		public BOPFPIHGJMD.MGPIJGMDLOM LHMDABPNDDH_state; // 0x10
	}

	public class BOBLBPGKIOH
	{
		public BOPFPIHGJMD.MGPIJGMDLOM[] LHMDABPNDDH_state = new BOPFPIHGJMD.MGPIJGMDLOM[2]; // 0x8
		public int[] LNADJDFHHAI = new int[2]; // 0xC

		// RVA: 0xE71568 Offset: 0xE71568 VA: 0xE71568
		public void BAFFAONJPCE()
		{
			for(int i = 0; i < LHMDABPNDDH_state.Length; i++)
			{
				LHMDABPNDDH_state[i] = BOPFPIHGJMD.MGPIJGMDLOM.HJNNKCMLGFL_3_None;
			}
			for(int i = 0; i < LNADJDFHHAI.Length; i++)
			{
				LNADJDFHHAI[i] = 0;
			}
		}
	}

	public class JNHGHDKLDEM
	{
		public int FMHLGHDKJBC; // 0x8
		public int JIOPJDJBLFK; // 0xC
		public BOBLBPGKIOH[] NNDGIAEFMOG = new BOBLBPGKIOH[3]; // 0x10

		//// RVA: 0xE73D44 Offset: 0xE73D44 VA: 0xE73D44
		public void BAFFAONJPCE()
		{
			FMHLGHDKJBC = 0;
			JIOPJDJBLFK = 0;
			for(int i = 0; i < NNDGIAEFMOG.Length; i++)
			{
				NNDGIAEFMOG[i] = new BOBLBPGKIOH();
				NNDGIAEFMOG[i].BAFFAONJPCE();
			}
		}

		//// RVA: 0xE73E98 Offset: 0xE73E98 VA: 0xE73E98
		public JNHGHDKLDEM JGJOAFJPIIH(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId)
		{
			JNHGHDKLDEM res = new JNHGHDKLDEM();
			res.BAFFAONJPCE();
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				if(HHCJCDFCLOB != null)
				{
					switch(HHCJCDFCLOB.KJGAJBOBIHK(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId))
					{
						case BOPFPIHGJMD.ADMNKELOLPN.CCAPCGPIIPF_1:
							{
								for(int i = 0; i < 3; i++)
								{
									for(int j = 0; j < 2; j++)
									{
										LGHIPHEDCNC_Offer.KPPFMKLEKLE of = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.BJKKBBPFBOL[i];
										PGCENGCEJGB p = HHCJCDFCLOB.OFJFGHEIMAH((BOPFPIHGJMD.DBNJDPHLLHI)of.GKBNNGPIELM(j));
										res.NNDGIAEFMOG[i].LNADJDFHHAI[j] = p.MKPJBDFDHOL_ThumbId;
										res.NNDGIAEFMOG[i].LHMDABPNDDH_state[j] = p.LHMDABPNDDH_state;
									}
								}
							}
							break;
						case BOPFPIHGJMD.ADMNKELOLPN.NBHIECDDJHH_2:
							{
								for (int i = 0; i < 3; i++)
								{
									for (int j = 0; j < 2; j++)
									{
										LGHIPHEDCNC_Offer.KPPFMKLEKLE of = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.BJKKBBPFBOL[i];
										PGCENGCEJGB p = HHCJCDFCLOB.OFJFGHEIMAH((BOPFPIHGJMD.DBNJDPHLLHI)of.EICKLOBPHKD(j));
										res.NNDGIAEFMOG[i].LNADJDFHHAI[j] = p.MKPJBDFDHOL_ThumbId;
										res.NNDGIAEFMOG[i].LHMDABPNDDH_state[j] = p.LHMDABPNDDH_state;
									}
								}
							}
							break;
						case BOPFPIHGJMD.ADMNKELOLPN.HFPIACELNLL_3:
							{
								for (int i = 0; i < 3; i++)
								{
									for (int j = 0; j < 2; j++)
									{
										LGHIPHEDCNC_Offer.KPPFMKLEKLE of = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.BJKKBBPFBOL[i];
										PGCENGCEJGB p = HHCJCDFCLOB.OFJFGHEIMAH((BOPFPIHGJMD.DBNJDPHLLHI)of.LPEBGOAFGNG(j));
										res.NNDGIAEFMOG[i].LNADJDFHHAI[j] = p.MKPJBDFDHOL_ThumbId;
										res.NNDGIAEFMOG[i].LHMDABPNDDH_state[j] = p.LHMDABPNDDH_state;
									}
								}
							}
							break;
						case BOPFPIHGJMD.ADMNKELOLPN.HIIPBAMPCEM_4:
							{
								for (int i = 0; i < 3; i++)
								{
									for (int j = 0; j < 2; j++)
									{
										LGHIPHEDCNC_Offer.KPPFMKLEKLE of = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.BJKKBBPFBOL[i];
										PGCENGCEJGB p = HHCJCDFCLOB.OFJFGHEIMAH((BOPFPIHGJMD.DBNJDPHLLHI)of.DLKPKENAECK(j));
										res.NNDGIAEFMOG[i].LNADJDFHHAI[j] = p.MKPJBDFDHOL_ThumbId;
										res.NNDGIAEFMOG[i].LHMDABPNDDH_state[j] = p.LHMDABPNDDH_state;
									}
								}
							}
							break;
					}
					res.FMHLGHDKJBC = 200;
					res.JIOPJDJBLFK = 200;
				}
			}
			return res;
		}
	}

	private class BADCBAILPID
	{
		public int FGHGMHPNEMG_Type; // 0x8
		public int MLDPDLPHJPM_OfferId; // 0xC
		public string GCFBAJONKHA = ""; // 0x10
	}

	public class NOCAJFGHDPC
	{
		public BOPFPIHGJMD.MLBMHDCCGHI FGHGMHPNEMG_Type; // 0x8
		public int MLDPDLPHJPM_OfferId; // 0xC
		public int OIPCCBHIKIA_index; // 0x10
	}


	private const int ENOBDCFHELD = 1899541669;
	private long GBOGLEDPFIO; // 0x8
	private long AIHOHDONCND; // 0x10
	private long HCHNGGAMGAD; // 0x18
	private BOPFPIHGJMD.JFHCHOILMEL GINJHBLEALE; // 0x20
	private int LHNLHFKDPKI; // 0x24
	private int CEFEHEAANKC; // 0x28
	private int EHMLAAHLNMN; // 0x2C
	private int JFFFPPPPNGK; // 0x30
	private BOPFPIHGJMD.GNGGLPCONLM DGCOECIKEGA; // 0x34
	private long LJPLPIOJCNK_LastShowAt; // 0x38
	private BOPFPIHGJMD.MLBMHDCCGHI HMPKMCKANBG; // 0x40
	private int JNIGHEHKAHG_DvPow; // 0x44
	private bool LONBOKLFGMI; // 0x48
	private List<NOCAJFGHDPC> JGPJCOCHJFJ; // 0x4C
	private const int LOKDKGIBOMF = 604800;
	private string[] JPJADDADKDA = new string[5] { JpStringLiterals.StringLiteral_12148, JpStringLiterals.StringLiteral_12149, JpStringLiterals.StringLiteral_12150, JpStringLiterals.StringLiteral_12151, JpStringLiterals.StringLiteral_12152 }; // 0x64

	public static KDHGBOOECKC HHCJCDFCLOB { get; private set; } // 0x0 LGMPACEDIJF NKACBOEHELJ OKPMHKNCNAL
	public NKMCJCAJIGD NKMMJACCHEH { get; private set; } // 0x50 HFADJHMDDMB LJJDDFEFJNC GLBKBOAABOM
	public JLLOKCFPOFH KPNGLBDMEBF { get; private set; } // 0x54 CENBJJIGEDL EMIGDHPEGDI LCMCCEKLAHP
	public GBAGPIKOGAN_DivaOfferInfo IOCBOGFFHFE { get; private set; } // 0x58 GJJFCABOCII CAACODBAKMO OMPFOHNINBC
	public GBAGPIKOGAN_DivaOfferInfo EHEEIIHLHHB { get; private set; } // 0x5C EFLOOGGNBAA DCBJPNFEAGP KEKPDABLCGD
	public CBJJINJDFDC NGHMGNMNNEP { get; private set; } // 0x60 DJGNEFOADCE PNBNEBNMCJA EGJIKLMEBNF

	// // RVA: 0x1026FE4 Offset: 0x1026FE4 VA: 0x1026FE4
	public void IJBGPAENLJA(MonoBehaviour _DANMJLOBLIE_mb)
	{
		HHCJCDFCLOB = this;
		NKMMJACCHEH = new KDHGBOOECKC.NKMCJCAJIGD();
		NKMMJACCHEH.LHPDDGIJKNB_Reset();
		KPNGLBDMEBF = new KDHGBOOECKC.JLLOKCFPOFH();
		KPNGLBDMEBF.LHPDDGIJKNB_Reset();
		IOCBOGFFHFE = new KDHGBOOECKC.GBAGPIKOGAN_DivaOfferInfo();
		IOCBOGFFHFE.LHPDDGIJKNB_Reset();
		EHEEIIHLHHB = new KDHGBOOECKC.GBAGPIKOGAN_DivaOfferInfo();
		EHEEIIHLHHB.LHPDDGIJKNB_Reset();
		JFFFPPPPNGK = 0;
		LONBOKLFGMI = false;
		GINJHBLEALE = BOPFPIHGJMD.JFHCHOILMEL.HJNNKCMLGFL_0_None/*0*/;
		LHNLHFKDPKI = 0;
		CEFEHEAANKC = 0;
		EHMLAAHLNMN = 0;
		NGHMGNMNNEP = new KDHGBOOECKC.CBJJINJDFDC();
	}

	// // RVA: 0x10271C0 Offset: 0x10271C0 VA: 0x10271C0
	public bool MDKADMHKOLN(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId, bool FAGEBAKNAOB/* = false*/, int KDLDOLENIDG/* = 0*/, int _AHHJLDLAPAN_DivaId/* = 0*/, long _KOOEOKEDJDO_expr/* = 0*/, bool AGELHLFEJNG/* = true*/)
	{
		OCMJNBIFJNM_Offer saveOffer = _LDEGEHAEALK_ServerData.DAEJHMCMFJD_Offer;
		//LKMHPJKIFDN_md.LBCMJGOOHLJ_Offer;
		BJIPLMJFAGH();
		OCMJNBIFJNM_Offer.JPOHOLBBFGP sOf = BKJJKHIBIGP(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
		if(sOf == null)
		{
			sOf = saveOffer.EACEMMDIPFD_GetFirstUnititialized();
			FGDFFDELFIO(sOf);
		}
		else
		{
			if (sOf.EALOBDHOCHP_stat > 1)
				return false;
			FGDFFDELFIO(sOf);
		}
		sOf.MLDPDLPHJPM_OfferId = _MLDPDLPHJPM_OfferId;
		sOf.GBJFNGCDKPM_typ = (int)_FGHGMHPNEMG_Type;
		sOf.EALOBDHOCHP_stat = 1;
		sOf.LHMOAJAIJCO_is_new = sOf.BFINGCJHOHI_cnt == 0;
		sOf.KOOEOKEDJDO_expr = _KOOEOKEDJDO_expr;
		sOf.JBPOABLNLHC_UpPer = LHNLHFKDPKI;
		sOf.BKMEPICADBC_ResetFlag(BOPFPIHGJMD.CMBJEEGFODD.ELCJGBEKIKD_2 | BOPFPIHGJMD.CMBJEEGFODD.PIICPBCIHKN_4 | BOPFPIHGJMD.CMBJEEGFODD.DPNBNKOOJHI_1); // 7
		if (FAGEBAKNAOB)
			sOf.HKFGCIOEMJE_SetFlag(BOPFPIHGJMD.CMBJEEGFODD.DPNBNKOOJHI_1);
		if(KDLDOLENIDG == 2)
		{
			sOf.HKFGCIOEMJE_SetFlag(BOPFPIHGJMD.CMBJEEGFODD.JPFLFLFFEDD_16);
			sOf.HKFGCIOEMJE_SetFlag(BOPFPIHGJMD.CMBJEEGFODD.HIJBHIFABFC_32);
		}
		else if(KDLDOLENIDG == 1)
		{
			sOf.HKFGCIOEMJE_SetFlag(BOPFPIHGJMD.CMBJEEGFODD.JPFLFLFFEDD_16);
		}
		if (GINJHBLEALE == BOPFPIHGJMD.JFHCHOILMEL.GNHENCIPDFK_2)
			sOf.HKFGCIOEMJE_SetFlag(BOPFPIHGJMD.CMBJEEGFODD.PIICPBCIHKN_4);
		else if(GINJHBLEALE == BOPFPIHGJMD.JFHCHOILMEL.MLFOEICOGAP_1)
			sOf.HKFGCIOEMJE_SetFlag(BOPFPIHGJMD.CMBJEEGFODD.ELCJGBEKIKD_2);
		if (_FGHGMHPNEMG_Type == BOPFPIHGJMD.MLBMHDCCGHI.FMLPIOFBCMA_3_Diva)
		{
			if (_AHHJLDLAPAN_DivaId > 0)
			{
				sOf.PIBLLGLCJEO_Param = _AHHJLDLAPAN_DivaId;
			}
		}
		else
		{
			if(_FGHGMHPNEMG_Type == BOPFPIHGJMD.MLBMHDCCGHI.FDOOAJLGFAE_2_Week)
			{
				LGHIPHEDCNC_Offer.BFEIHCJHHAJ d = GKIOIHLDBGF(BOPFPIHGJMD.MLBMHDCCGHI.FDOOAJLGFAE_2_Week, sOf.MLDPDLPHJPM_OfferId) as LGHIPHEDCNC_Offer.BFEIHCJHHAJ;
				if (d != null)
				{
					sOf.PIBLLGLCJEO_Param = d.HAHMHBNPGFM;
				}
			}
		}
		ILCCJNDFFOB.HHCJCDFCLOB.DAGHKCKEJPA(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
		return true;
	}

	// // RVA: 0x1027FD0 Offset: 0x1027FD0 VA: 0x1027FD0
	public bool NEGHCLNLFEM(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId)
	{
		OCMJNBIFJNM_Offer.JPOHOLBBFGP of = BKJJKHIBIGP(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
		if(of != null && of.EALOBDHOCHP_stat == 2)
		{
			of.EALOBDHOCHP_stat = 1;
			of.DFJLNPFJGDK_sdt = 0;
			of.NCDHKKCCGOD_edt = 0;
			of.MNCEBKHBBEF_VFform = 0;
			return true;
		}
		return false;
	}

	// // RVA: 0x1028060 Offset: 0x1028060 VA: 0x1028060
	public List<LGHIPHEDCNC_Offer.LHDLCLNBPLB> IOCBIDHIIAE(int AHCDMDKCDFM, int GPABMPAPIEC, long _JHNMKKNEENE_Time, BOPFPIHGJMD.FPKMKLDDCNL LJHNOBJJBJA, BOPFPIHGJMD.DLDOEOEFJKA _INDDJNMPONH_type, int _BAOFEFFADPD_day, bool BPAOFBAIAIK)
	{
		List<LGHIPHEDCNC_Offer.LHDLCLNBPLB> res = new List<LGHIPHEDCNC_Offer.LHDLCLNBPLB>();
		res.Clear();
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
			{
				if (_INDDJNMPONH_type == BOPFPIHGJMD.DLDOEOEFJKA.PLFJBGJMMDP_1)
					_BAOFEFFADPD_day += 10;
				if (JGPJCOCHJFJ == null)
					BJIPLMJFAGH();
				for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.HOJPJAFDIAD.Count; i++)
				{
					LGHIPHEDCNC_Offer.LHDLCLNBPLB dbOf = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.HOJPJAFDIAD[i];
					if(dbOf.PLALNIIBLOF_en == 2)
					{
						if(BPAOFBAIAIK)
						{
							OCMJNBIFJNM_Offer.JPOHOLBBFGP d = BKJJKHIBIGP((BOPFPIHGJMD.MLBMHDCCGHI)dbOf.GBJFNGCDKPM_typ, dbOf.PPFNGGCBJKC_id);
							if (d != null && d.EALOBDHOCHP_stat > 1)
								continue;
						}
						switch(_INDDJNMPONH_type)
						{
							case BOPFPIHGJMD.DLDOEOEFJKA.CCAPCGPIIPF_0:
							case BOPFPIHGJMD.DLDOEOEFJKA.PLFJBGJMMDP_1:
								{
									if (dbOf.PDBPFJJCADD_open_at == 0 && dbOf.FDBNFFNFOND_close_at == 0)
									{
										int a = 1;
										if (LJHNOBJJBJA < BOPFPIHGJMD.FPKMKLDDCNL.HNOJIKHAPHA_1)
											a = dbOf.DNEDEGCHFGH((int)LJHNOBJJBJA - 1);
										if (a == _BAOFEFFADPD_day)
										{
											if (AHCDMDKCDFM <= dbOf.GOKJLBDJOLA_df)
											{
												if (dbOf.GOKJLBDJOLA_df <= GPABMPAPIEC)
												{
													res.Add(dbOf);
												}
											}
										}
									}
									break;
								}
							case BOPFPIHGJMD.DLDOEOEFJKA.CCDOBDNDPIL_2:
								{
									if (dbOf.PDBPFJJCADD_open_at == 0 && dbOf.FDBNFFNFOND_close_at == 0)
										break;
									if (dbOf.FDBNFFNFOND_close_at != 0 && _JHNMKKNEENE_Time >= dbOf.FDBNFFNFOND_close_at)
										break;
									if (dbOf.PDBPFJJCADD_open_at != 0 && _JHNMKKNEENE_Time < dbOf.PDBPFJJCADD_open_at)
										break;
									res.Add(dbOf);
								}
								break;
							case BOPFPIHGJMD.DLDOEOEFJKA.LJJODKKOOFD_3:
								{
									if (dbOf.JBHBGOIMALD == 1)
										res.Add(dbOf);
								}
								break;
							case BOPFPIHGJMD.DLDOEOEFJKA.MOADAEHPFPA_4:
								{
									if (dbOf.JBHBGOIMALD == 2)
										res.Add(dbOf);
								}
								break;
							default:
								{
									int a = 1;
									if (LJHNOBJJBJA < BOPFPIHGJMD.FPKMKLDDCNL.HNOJIKHAPHA_1)
										a = dbOf.DNEDEGCHFGH((int)LJHNOBJJBJA - 1);
									if(a == _BAOFEFFADPD_day)
									{
										if(AHCDMDKCDFM <= dbOf.GOKJLBDJOLA_df)
										{
											if(dbOf.GOKJLBDJOLA_df <= GPABMPAPIEC)
											{
												res.Add(dbOf);
											}
										}
									}
								}
								break;
						}
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0x1028660 Offset: 0x1028660 VA: 0x1028660
	// public int PEJKAKECJNI(int _NNDBJGDFEEM_Min, int _DOOGFEGEKLG_max) { }

	// // RVA: 0x1028670 Offset: 0x1028670 VA: 0x1028670
	public LGHIPHEDCNC_Offer.LHDLCLNBPLB MJMIABEOKOA(ref List<LGHIPHEDCNC_Offer.LHDLCLNBPLB> CLMLKNCOOHH)
	{
		for(int i = 0; i < CLMLKNCOOHH.Count; i++)
		{
			int idx = UnityEngine.Random.Range(0, CLMLKNCOOHH.Count);
			LGHIPHEDCNC_Offer.LHDLCLNBPLB d = CLMLKNCOOHH[idx];
			CLMLKNCOOHH.RemoveAt(idx);
			if(d.PLALNIIBLOF_en == 2)
				return d;
		}
		return null;
	}

	// // RVA: 0x10287D4 Offset: 0x10287D4 VA: 0x10287D4
	public LGHIPHEDCNC_Offer.LHDLCLNBPLB GABIMDJLBAG(ref List<LGHIPHEDCNC_Offer.LHDLCLNBPLB> CLMLKNCOOHH)
	{
		List<LGHIPHEDCNC_Offer.LHDLCLNBPLB> l = new List<LGHIPHEDCNC_Offer.LHDLCLNBPLB>();
		for(int i = 0; i < CLMLKNCOOHH.Count; i++)
		{
			OCMJNBIFJNM_Offer.JPOHOLBBFGP of = BKJJKHIBIGP((BOPFPIHGJMD.MLBMHDCCGHI)CLMLKNCOOHH[i].GBJFNGCDKPM_typ, CLMLKNCOOHH[i].PPFNGGCBJKC_id);
			if(of == null || (of.EALOBDHOCHP_stat == 0 && of.BFINGCJHOHI_cnt == 0))
			{
				l.Add(CLMLKNCOOHH[i]);
			}
		}
		if(l.Count > 0)
		{
			LGHIPHEDCNC_Offer.LHDLCLNBPLB d = l[UnityEngine.Random.Range(0, l.Count)];
			CLMLKNCOOHH.Remove(d);
			return d;
		}
		return null;
	}

	// // RVA: 0x1028A74 Offset: 0x1028A74 VA: 0x1028A74
	public bool HNPIJCCBLIA(LGHIPHEDCNC_Offer.HEECIKHJOBM KIOFLAGHLGD, long _JHNMKKNEENE_Time, ref List<LGHIPHEDCNC_Offer.LHDLCLNBPLB> ELAOAOKEJHN)
	{
		DateTime date = Utility.GetLocalDateTime(_JHNMKKNEENE_Time);
		int dow = (int)date.DayOfWeek;
		List<LGHIPHEDCNC_Offer.LHDLCLNBPLB> l1 = IOCBIDHIIAE(1, 1, _JHNMKKNEENE_Time, (BOPFPIHGJMD.FPKMKLDDCNL)KIOFLAGHLGD.LJHNOBJJBJA, 0, 1, true);
		int cnt = KIOFLAGHLGD.OHJEJDEMGIH;
		if (l1.Count < cnt)
			cnt = l1.Count;
		if (cnt > 0)
		{
			LGHIPHEDCNC_Offer.LHDLCLNBPLB d = GABIMDJLBAG(ref l1);
			if(d != null)
			{
				ELAOAOKEJHN.Add(d);
				cnt--;
			}
			if (cnt > 0)
			{
				do
				{
					d = MJMIABEOKOA(ref l1);
					if (d != null)
					{
						ELAOAOKEJHN.Add(d);
					}
					cnt--;
				} while (cnt != 0);
			}
		}
		List<LGHIPHEDCNC_Offer.LHDLCLNBPLB> l2 = IOCBIDHIIAE(2, 2, _JHNMKKNEENE_Time, (BOPFPIHGJMD.FPKMKLDDCNL)KIOFLAGHLGD.LJHNOBJJBJA, BOPFPIHGJMD.DLDOEOEFJKA.CCAPCGPIIPF_0, 1, true);
		cnt = KIOFLAGHLGD.HICPFMHEMPN;
		if (l2.Count < cnt)
			cnt = l2.Count;
		if(cnt > 0)
		{
			LGHIPHEDCNC_Offer.LHDLCLNBPLB d = GABIMDJLBAG(ref l2);
			if(d != null)
			{
				ELAOAOKEJHN.Add(d);
				cnt--;
			}
			if (cnt > 0)
			{
				do
				{
					d = MJMIABEOKOA(ref l2);
					if (d != null)
					{
						ELAOAOKEJHN.Add(d);
					}
					cnt--;
				} while (cnt != 0);
			}
		}
		List<LGHIPHEDCNC_Offer.LHDLCLNBPLB> l3 = IOCBIDHIIAE(3, 3, _JHNMKKNEENE_Time, (BOPFPIHGJMD.FPKMKLDDCNL) KIOFLAGHLGD.LJHNOBJJBJA, BOPFPIHGJMD.DLDOEOEFJKA.CCAPCGPIIPF_0, 1, true);
		cnt = KIOFLAGHLGD.HLDAPDPGDME;
		if (l3.Count < cnt)
			cnt = l3.Count;
		if (cnt > 0)
		{
			LGHIPHEDCNC_Offer.LHDLCLNBPLB d = GABIMDJLBAG(ref l3);
			if (d != null)
			{
				ELAOAOKEJHN.Add(d);
				cnt--;
			}
			if (cnt > 0)
			{
				do
				{
					d = MJMIABEOKOA(ref l3);
					if (d != null)
					{
						ELAOAOKEJHN.Add(d);
					}
					cnt--;
				} while (cnt != 0);
			}
		}
		List<LGHIPHEDCNC_Offer.LHDLCLNBPLB> l4 = IOCBIDHIIAE(4, 4, _JHNMKKNEENE_Time, (BOPFPIHGJMD.FPKMKLDDCNL) KIOFLAGHLGD.LJHNOBJJBJA, BOPFPIHGJMD.DLDOEOEFJKA.CCAPCGPIIPF_0, 1, true);
		cnt = KIOFLAGHLGD.NAHPAJGLDAF;
		if (l4.Count < cnt)
			cnt = l4.Count;
		if (cnt > 0)
		{
			LGHIPHEDCNC_Offer.LHDLCLNBPLB d = GABIMDJLBAG(ref l4);
			if (d != null)
			{
				ELAOAOKEJHN.Add(d);
				cnt--;
			}
			if (cnt > 0)
			{
				do
				{
					d = MJMIABEOKOA(ref l4);
					if (d != null)
					{
						ELAOAOKEJHN.Add(d);
					}
					cnt--;
				} while (cnt != 0);
			}
		}
		List<LGHIPHEDCNC_Offer.LHDLCLNBPLB> l5 = IOCBIDHIIAE(5, 5, _JHNMKKNEENE_Time, (BOPFPIHGJMD.FPKMKLDDCNL) KIOFLAGHLGD.LJHNOBJJBJA, BOPFPIHGJMD.DLDOEOEFJKA.CCAPCGPIIPF_0, 1, true);
		cnt = KIOFLAGHLGD.LIJHGLLNMLG;
		if (l5.Count < cnt)
			cnt = l5.Count;
		if (cnt > 0)
		{
			LGHIPHEDCNC_Offer.LHDLCLNBPLB d = GABIMDJLBAG(ref l5);
			if (d != null)
			{
				ELAOAOKEJHN.Add(d);
				cnt--;
			}
			if (cnt > 0)
			{
				do
				{
					d = MJMIABEOKOA(ref l5);
					if (d != null)
					{
						ELAOAOKEJHN.Add(d);
					}
					cnt--;
				} while (cnt != 0);
			}
		}
		List<LGHIPHEDCNC_Offer.LHDLCLNBPLB> l6 = IOCBIDHIIAE(1, 5, _JHNMKKNEENE_Time, (BOPFPIHGJMD.FPKMKLDDCNL) KIOFLAGHLGD.LJHNOBJJBJA, BOPFPIHGJMD.DLDOEOEFJKA.PLFJBGJMMDP_1, dow, true);
		cnt = KIOFLAGHLGD.EJFAEKPGKNJ_daily;
		if (l6.Count < cnt)
			cnt = l6.Count;
		if (cnt > 0)
		{
			do
			{
				LGHIPHEDCNC_Offer.LHDLCLNBPLB d = MJMIABEOKOA(ref l6);
				if (d != null)
				{
					ELAOAOKEJHN.Add(d);
				}
				cnt--;
			} while (cnt != 0);
		}
		return true;
	}

	// // RVA: 0x10293B0 Offset: 0x10293B0 VA: 0x10293B0
	public bool AJAAFLHLNKP(long _JHNMKKNEENE_Time, ref List<LGHIPHEDCNC_Offer.LHDLCLNBPLB> ELAOAOKEJHN)
	{
		bool res = false;
		List<LGHIPHEDCNC_Offer.LHDLCLNBPLB> l = IOCBIDHIIAE(1, 5, _JHNMKKNEENE_Time, BOPFPIHGJMD.FPKMKLDDCNL.HJNNKCMLGFL_0_None, BOPFPIHGJMD.DLDOEOEFJKA.CCDOBDNDPIL_2, 1, true);
		for(int i = 0; i < l.Count; i++)
		{
			OCMJNBIFJNM_Offer.JPOHOLBBFGP of = BKJJKHIBIGP((BOPFPIHGJMD.MLBMHDCCGHI)l[i].GBJFNGCDKPM_typ, l[i].PPFNGGCBJKC_id);
			if(of == null || of.EALOBDHOCHP_stat == 0)
			{
				ELAOAOKEJHN.Add(l[i]);
				res = true;
			}
		}
		return res;
	}

	// // RVA: 0x1029574 Offset: 0x1029574 VA: 0x1029574
	public List<OCMJNBIFJNM_Offer.JPOHOLBBFGP> ONEMGDCCPPM(BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, BOPFPIHGJMD.IGHPDAGKIKO CMCKNKKCNDK_status, BOPFPIHGJMD.CMBJEEGFODD IBADNKFPNPI)
	{
		BJIPLMJFAGH();
		List<OCMJNBIFJNM_Offer.JPOHOLBBFGP> l = new List<OCMJNBIFJNM_Offer.JPOHOLBBFGP>();
		for(int i = 0; i < JGPJCOCHJFJ.Count; i++)
		{
			OCMJNBIFJNM_Offer.JPOHOLBBFGP of = _LDEGEHAEALK_ServerData.DAEJHMCMFJD_Offer.FOFLMHELILC[JGPJCOCHJFJ[i].OIPCCBHIKIA_index];
			if(of.DPMCPMJJGAA_HasFlag(IBADNKFPNPI))
			{
				if((int)CMCKNKKCNDK_status <= of.EALOBDHOCHP_stat)
				{
					l.Add(of);
				}
			}
		}
		return l;
	}

	// // RVA: 0x102979C Offset: 0x102979C VA: 0x102979C
	public bool FGFJMGLFNNF(long KGIBHAGPCGE, long _JHNMKKNEENE_Time, ref List<LGHIPHEDCNC_Offer.LHDLCLNBPLB> ELAOAOKEJHN)
	{
		if(NHPDPKHMFEP.HHCJCDFCLOB.GBCPDBJEDHL(false) || NHPDPKHMFEP.HHCJCDFCLOB.ENAAHAPDMCO())
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
				{
					bool res = false;
					if (!LNFMLNDHFHI(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, _JHNMKKNEENE_Time, BOPFPIHGJMD.DLDOEOEFJKA.LJJODKKOOFD_3))
						res = HDNBNNKHCPA(BOPFPIHGJMD.DLDOEOEFJKA.LJJODKKOOFD_3, _JHNMKKNEENE_Time, ref ELAOAOKEJHN);
					if(NHPDPKHMFEP.HHCJCDFCLOB.ENAAHAPDMCO())
					{
						if (!LNFMLNDHFHI(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, _JHNMKKNEENE_Time, BOPFPIHGJMD.DLDOEOEFJKA.MOADAEHPFPA_4))
							res |= HDNBNNKHCPA(BOPFPIHGJMD.DLDOEOEFJKA.MOADAEHPFPA_4, _JHNMKKNEENE_Time, ref ELAOAOKEJHN);
					}
					return res;
				}
			}
		}
		return false;
	}

	// // RVA: 0x10299FC Offset: 0x10299FC VA: 0x10299FC
	public bool LNFMLNDHFHI(BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, long _JHNMKKNEENE_Time, BOPFPIHGJMD.DLDOEOEFJKA NPFIFEIOGAM)
	{
		List<OCMJNBIFJNM_Offer.JPOHOLBBFGP> l = ONEMGDCCPPM(_LDEGEHAEALK_ServerData, BOPFPIHGJMD.IGHPDAGKIKO.EBAPFCDNMGD_1_Order, NPFIFEIOGAM == BOPFPIHGJMD.DLDOEOEFJKA.MOADAEHPFPA_4 ? BOPFPIHGJMD.CMBJEEGFODD.HIJBHIFABFC_32 : BOPFPIHGJMD.CMBJEEGFODD.JPFLFLFFEDD_16);
		DateTime date = Utility.GetLocalDateTime(_JHNMKKNEENE_Time);
		for(int i = 0; i < l.Count; i++)
		{
			if (l[i].EALOBDHOCHP_stat == 1)
				return true;
			if(l[i].EALOBDHOCHP_stat >= 2 && l[i].EALOBDHOCHP_stat < 5)
			{
				DateTime date2 = Utility.GetLocalDateTime(l[i].DFJLNPFJGDK_sdt);
				if (date.Year == date2.Year && date.Month == date2.Month && date.Day == date2.Day)
					return true;
			}
		}
		return false;
	}

	// // RVA: 0x1029C7C Offset: 0x1029C7C VA: 0x1029C7C
	public bool HDNBNNKHCPA(BOPFPIHGJMD.DLDOEOEFJKA _FGHGMHPNEMG_Type, long _JHNMKKNEENE_Time, ref List<LGHIPHEDCNC_Offer.LHDLCLNBPLB> ELAOAOKEJHN)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
			{
				List<int> l = new List<int>();
				int a;
				if (_FGHGMHPNEMG_Type == BOPFPIHGJMD.DLDOEOEFJKA.MOADAEHPFPA_4)
					a = GOJDPOGJOLM(BOPFPIHGJMD.IGHPDAGKIKO.EBAPFCDNMGD_1_Order, false);
				else
					a = MPPINCEGOJE(BOPFPIHGJMD.IGHPDAGKIKO.EBAPFCDNMGD_1_Order, false);
				int a2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.KGHLJBEJOIG();
				if (a2 > 0)
					l.Add(a2);
				bool res = false;
				for(int i = 0; i < l.Count; i++)
				{
					LGHIPHEDCNC_Offer.HEECIKHJOBM of = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.JGNEADEJDOF[l[i] - 1];
					int a3;
					if (_FGHGMHPNEMG_Type == BOPFPIHGJMD.DLDOEOEFJKA.MOADAEHPFPA_4)
						a3 = of.DIDNHGHIAFO;
					else
						a3 = of.JBHBGOIMALD;
					if (a < a3)
					{
						List<LGHIPHEDCNC_Offer.LHDLCLNBPLB> l2 = IOCBIDHIIAE(1, 5, _JHNMKKNEENE_Time, BOPFPIHGJMD.FPKMKLDDCNL.HJNNKCMLGFL_0_None, _FGHGMHPNEMG_Type, 1, true);
						for (int j = 0; j < l2.Count; j++)
						{
							OCMJNBIFJNM_Offer.JPOHOLBBFGP of2 = BKJJKHIBIGP((BOPFPIHGJMD.MLBMHDCCGHI)l2[i].GBJFNGCDKPM_typ, l2[i].PPFNGGCBJKC_id);
							if (of2 == null || (of2.EALOBDHOCHP_stat == 0 && of2.BFINGCJHOHI_cnt == 0))
							{
								ELAOAOKEJHN.Add(l2[i]);
								res = true;
								a++;
								if (a3 <= a)
									return true;
							}
						}
						for (int j = 0; j < l2.Count; j++)
						{
							OCMJNBIFJNM_Offer.JPOHOLBBFGP of2 = BKJJKHIBIGP((BOPFPIHGJMD.MLBMHDCCGHI)l2[i].GBJFNGCDKPM_typ, l2[i].PPFNGGCBJKC_id);
							if (of2 == null || of2.EALOBDHOCHP_stat == 0)
							{
								ELAOAOKEJHN.Add(l2[i]);
								res = true;
								a++;
								if (a3 <= a)
									return true;
							}
						}
					}
				}
				return res;
			}
		}
		return false;
	}

	// // RVA: 0x102A6E0 Offset: 0x102A6E0 VA: 0x102A6E0
	private bool PEMMDEMCHAH()
	{
		return NKGJPJPHLIF.HHCJCDFCLOB.DPJBHHIHJJK;
	}

	// // RVA: 0x102A774 Offset: 0x102A774 VA: 0x102A774
	public bool DJMICICGLLG()
	{
		if(!PEMMDEMCHAH())
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
				{
					long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
					if (LJPLPIOJCNK_LastShowAt == 0)
					{
						LJPLPIOJCNK_LastShowAt = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.LJPLPIOJCNK_LastShowAt;
					}
					List<int> l = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.FMFMLGHLELN(LJPLPIOJCNK_LastShowAt, t);
					LJPLPIOJCNK_LastShowAt = t;
					return l.Count > 0;
				}
			}
		}
		return false;
	}

	// // RVA: 0x102A9F8 Offset: 0x102A9F8 VA: 0x102A9F8
	private bool DCKHPFDIMFI_IsDayOfWeek(int PPMBFJJDCPP, long _JHNMKKNEENE_Time)
	{
		if (PPMBFJJDCPP < 1)
			return true;
		return (int)Utility.GetLocalDateTime(_JHNMKKNEENE_Time).DayOfWeek == PPMBFJJDCPP - 1;
	}

	// // RVA: 0x102AAE0 Offset: 0x102AAE0 VA: 0x102AAE0
	public List<LGHIPHEDCNC_Offer.LHDLCLNBPLB> MIMNFDFLFFA(long _JHNMKKNEENE_Time)
	{
		List<LGHIPHEDCNC_Offer.LHDLCLNBPLB> res = new List<LGHIPHEDCNC_Offer.LHDLCLNBPLB>();
		res.Clear();
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
			{
				List<LGHIPHEDCNC_Offer.HEECIKHJOBM> l1 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.JGNEADEJDOF;
				List<OCMJNBIFJNM_Offer.JPOHOLBBFGP> l2 = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.FOFLMHELILC;
				long lastShowAt = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.LJPLPIOJCNK_LastShowAt;
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.LJPLPIOJCNK_LastShowAt = _JHNMKKNEENE_Time;
				LJPLPIOJCNK_LastShowAt = _JHNMKKNEENE_Time;
				AIHOHDONCND = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.IILNIBNFOLG(_JHNMKKNEENE_Time);
				GBOGLEDPFIO = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.JMFOBCHBCCB(_JHNMKKNEENE_Time);
				List<int> l3 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.FMFMLGHLELN(lastShowAt, _JHNMKKNEENE_Time);
				if(l3.Count > 0)
				{
					List<LGHIPHEDCNC_Offer.LHDLCLNBPLB> l4 = new List<LGHIPHEDCNC_Offer.LHDLCLNBPLB>();
					l4.Clear();
					for(int i = 0; i < l3.Count; i++)
					{
						LGHIPHEDCNC_Offer.HEECIKHJOBM dbOf = l1[l3[i] - 1];
						if(dbOf.KDMIJCOJNGO == 1)
						{
							for(int j = 0; j < l2.Count; j++)
							{
								OCMJNBIFJNM_Offer.JPOHOLBBFGP saveOf = l2[j];
								if(saveOf.GBJFNGCDKPM_typ < 2)
								{
									if(saveOf.KOOEOKEDJDO_expr == 0)
									{
										if(saveOf.EALOBDHOCHP_stat == 1)
										{
											FGDFFDELFIO(saveOf);
										}
									}
								}
							}
						}
						else if(dbOf.KDMIJCOJNGO == 2)
						{
							for(int j = 0; j < l2.Count; j++)
							{
								OCMJNBIFJNM_Offer.JPOHOLBBFGP saveOf = l2[j];
								if(saveOf.GBJFNGCDKPM_typ < 2)
								{
									if(saveOf.KOOEOKEDJDO_expr > -1)
									{
										if (saveOf.EALOBDHOCHP_stat == 4 || saveOf.EALOBDHOCHP_stat == 1)
											FGDFFDELFIO(saveOf);
									}
								}
							}
						}
						HNPIJCCBLIA(dbOf, _JHNMKKNEENE_Time, ref l4);
					}
					for(int i = 0; i < l4.Count; i++)
					{
						MDKADMHKOLN(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, BOPFPIHGJMD.MLBMHDCCGHI.HEFPAOLDHCK_1_Day, l4[i].PPFNGGCBJKC_id, l4[i].PDBPFJJCADD_open_at != 0 || l4[i].FDBNFFNFOND_close_at != 0, l4[i].JBHBGOIMALD, 0, l4[i].KOOEOKEDJDO_expr, false);
					}
					DGCOECIKEGA |= BOPFPIHGJMD.GNGGLPCONLM.OCKIDPJNNBP_1;
				}
				List<LGHIPHEDCNC_Offer.LHDLCLNBPLB> l5 = new List<LGHIPHEDCNC_Offer.LHDLCLNBPLB>();
				if(AJAAFLHLNKP(_JHNMKKNEENE_Time, ref l5))
				{
					for(int i = 0; i < l5.Count; i++)
					{
						MDKADMHKOLN(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, BOPFPIHGJMD.MLBMHDCCGHI.HEFPAOLDHCK_1_Day, l5[i].PPFNGGCBJKC_id, l5[i].PDBPFJJCADD_open_at != 0 || l5[i].FDBNFFNFOND_close_at != 0, l5[i].JBHBGOIMALD, 0, l5[i].KOOEOKEDJDO_expr, false);
					}
				}
				List<LGHIPHEDCNC_Offer.LHDLCLNBPLB> l6 = new List<LGHIPHEDCNC_Offer.LHDLCLNBPLB>();
				if(FGFJMGLFNNF(0, _JHNMKKNEENE_Time, ref l6))
				{
					for (int i = 0; i < l6.Count; i++)
					{
						MDKADMHKOLN(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, BOPFPIHGJMD.MLBMHDCCGHI.HEFPAOLDHCK_1_Day, l6[i].PPFNGGCBJKC_id, l6[i].PDBPFJJCADD_open_at != 0 || l6[i].FDBNFFNFOND_close_at != 0, l6[i].JBHBGOIMALD, 0, l6[i].KOOEOKEDJDO_expr, false);
					}
					DGCOECIKEGA |= BOPFPIHGJMD.GNGGLPCONLM.OCKIDPJNNBP_1;
				}
				BJIPLMJFAGH();
				int a2 = BCACCAGCPCO();
				long a3 = 0;
				long a4 = 0;
				for(int i = 0; i < JGPJCOCHJFJ.Count; i++)
				{
					OCMJNBIFJNM_Offer.JPOHOLBBFGP dbOf = l2[JGPJCOCHJFJ[i].OIPCCBHIKIA_index];
					if (dbOf.GBJFNGCDKPM_typ == 1)
					{
						if(dbOf.EALOBDHOCHP_stat > 0)
						{
							LGHIPHEDCNC_Offer.LHDLCLNBPLB d = GKIOIHLDBGF(BOPFPIHGJMD.MLBMHDCCGHI.HEFPAOLDHCK_1_Day, dbOf.MLDPDLPHJPM_OfferId) as LGHIPHEDCNC_Offer.LHDLCLNBPLB;
							if(d != null)
							{
								if(dbOf.EALOBDHOCHP_stat > 1)
								{
									res.Add(d);
								}
								else if(!dbOf.DPMCPMJJGAA_HasFlag(BOPFPIHGJMD.CMBJEEGFODD.JPFLFLFFEDD_16))
								{
									if(dbOf.DPMCPMJJGAA_HasFlag(BOPFPIHGJMD.CMBJEEGFODD.DPNBNKOOJHI_1))
									{
										if(DCKHPFDIMFI_IsDayOfWeek(d.PPMBFJJDCPP, _JHNMKKNEENE_Time))
										{
											if(LJPLPIOJCNK_LastShowAt >= d.PDBPFJJCADD_open_at)
											{
												if(d.FDBNFFNFOND_close_at >= LJPLPIOJCNK_LastShowAt)
												{
													res.Add(d);
												}
											}
											if (LJPLPIOJCNK_LastShowAt >= d.PDBPFJJCADD_open_at)
											{
												if(a3 != 0)
												{
													if(a3 < d.PDBPFJJCADD_open_at)
														a3 = d.PDBPFJJCADD_open_at;
												}
											}
											if(a4 != 0)
											{
												if (d.PDBPFJJCADD_open_at < a4)
													a4 = d.PDBPFJJCADD_open_at;
											}
										}
									}
									else
									{
										if(d.GOKJLBDJOLA_df <= a2)
										{
											res.Add(d);
										}
									}
								}
								else
								{
									if(dbOf.DPMCPMJJGAA_HasFlag(BOPFPIHGJMD.CMBJEEGFODD.HIJBHIFABFC_32))
									{
										if(NHPDPKHMFEP.HHCJCDFCLOB.ENAAHAPDMCO())
										{
											res.Add(d);
										}
									}
									else
									{
										if(NHPDPKHMFEP.HHCJCDFCLOB.GBCPDBJEDHL(false))
										{
											res.Add(d);
										}
									}
								}
							}
						}
					}
				}
				if (a3 != 0 && LJPLPIOJCNK_LastShowAt >= a3)
					a4 = a3;
				if (a4 != 0)
				{
					if(LJPLPIOJCNK_LastShowAt >= a4 && a4 != CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.JKIFLFKFHPB_LastAddAt)
					{
						DGCOECIKEGA |= BOPFPIHGJMD.GNGGLPCONLM.OCKIDPJNNBP_1;
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.JKIFLFKFHPB_LastAddAt = a4;
					}
				}
				res.Sort((LGHIPHEDCNC_Offer.LHDLCLNBPLB _HKICMNAACDA_a, LGHIPHEDCNC_Offer.LHDLCLNBPLB _BNKHBCBJBKI_b) =>
				{
					//0xE6F144
					if(_HKICMNAACDA_a.KOOEOKEDJDO_expr == _BNKHBCBJBKI_b.KOOEOKEDJDO_expr)
					{
						return _HKICMNAACDA_a.PPFNGGCBJKC_id.CompareTo(_BNKHBCBJBKI_b.PPFNGGCBJKC_id);
					}
					return _BNKHBCBJBKI_b.KOOEOKEDJDO_expr.CompareTo(_HKICMNAACDA_a.KOOEOKEDJDO_expr);
				});
			}
		}
		return res;
	}

	// // RVA: 0x102BFC0 Offset: 0x102BFC0 VA: 0x102BFC0
	// public int CBDOLLGCIKB(long EJFPCCIHIBG, long _JHNMKKNEENE_Time) { }

	// // RVA: 0x102BFE0 Offset: 0x102BFE0 VA: 0x102BFE0
	// public long OGIGEGAMNCI(long EJFPCCIHIBG, int DNFKINPBKJL) { }

	// // RVA: 0x102C000 Offset: 0x102C000 VA: 0x102C000
	public List<LGHIPHEDCNC_Offer.BFEIHCJHHAJ> NHHLDEPNCNG(long _JHNMKKNEENE_Time)
	{
		List<LGHIPHEDCNC_Offer.BFEIHCJHHAJ> res = new List<LGHIPHEDCNC_Offer.BFEIHCJHHAJ>();
		res.Clear();
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
			{
				int sDate = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA_GetIntParam("start_date", 1);
				sDate = (int)Utility.RoundDownDayUnixTime(sDate, 86400);
				HCHNGGAMGAD = ((_JHNMKKNEENE_Time - sDate) / 604800) * 604800 + 604800 + sDate;
				List<LGHIPHEDCNC_Offer.BFEIHCJHHAJ> l = new List<LGHIPHEDCNC_Offer.BFEIHCJHHAJ>();
				l.Clear();
				int a = (int)((_JHNMKKNEENE_Time - sDate) / 604800) % 4 + 1;
				for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.FFKIBJKEBNP.Count; i++)
				{
					LGHIPHEDCNC_Offer.BFEIHCJHHAJ of = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.FFKIBJKEBNP[i];
					if(of.PDBPFJJCADD_open_at == 0 && of.FDBNFFNFOND_close_at == 0)
					{
						if (of.HAHMHBNPGFM == a)
							l.Add(of);
					}
					else
					{
						if (_JHNMKKNEENE_Time >= of.FDBNFFNFOND_close_at)
							l.Add(of);
					}
				}
				for(int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.FOFLMHELILC.Count; i++)
				{
					OCMJNBIFJNM_Offer.JPOHOLBBFGP of = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.FOFLMHELILC[i];
					if(of.GBJFNGCDKPM_typ == 2)
					{
						if (of.EALOBDHOCHP_stat == 1)
							FGDFFDELFIO(of);
						else
						{
							if(of.EALOBDHOCHP_stat == 4)
							{
								if (((_JHNMKKNEENE_Time - sDate) / 604800) != (of.DFJLNPFJGDK_sdt - HCHNGGAMGAD) / 604800)
									FGDFFDELFIO(of);
							}
						}
					}
				}
				for(int i = 0; i < l.Count; i++)
				{
					MDKADMHKOLN(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, BOPFPIHGJMD.MLBMHDCCGHI.FDOOAJLGFAE_2_Week, l[i].PPFNGGCBJKC_id, l[i].PDBPFJJCADD_open_at != 0 || l[i].FDBNFFNFOND_close_at != 0, 0, 0, 0, false);
				}
				BJIPLMJFAGH();
				bool b = false;
				for(int i = 0; i < JGPJCOCHJFJ.Count; i++)
				{
					OCMJNBIFJNM_Offer.JPOHOLBBFGP of = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.FOFLMHELILC[JGPJCOCHJFJ[i].OIPCCBHIKIA_index];
					if(of.GBJFNGCDKPM_typ == 2)
					{
						if(of.EALOBDHOCHP_stat > 0)
						{
							LGHIPHEDCNC_Offer.NONCDAINJLD d = GKIOIHLDBGF(BOPFPIHGJMD.MLBMHDCCGHI.FDOOAJLGFAE_2_Week, of.MLDPDLPHJPM_OfferId);
							if(d != null)
							{
								if(of.PIBLLGLCJEO_Param != a)
								{
									if(of.EALOBDHOCHP_stat == 4)
									{
										FGDFFDELFIO(of);
										b = true;
										continue;
									}
								}
								if(of.EALOBDHOCHP_stat < 2)
								{
									if (d.PDBPFJJCADD_open_at != 0 || d.FDBNFFNFOND_close_at != 0)
									{
										if (_JHNMKKNEENE_Time >= d.PDBPFJJCADD_open_at)
										{
											if (d.FDBNFFNFOND_close_at >= _JHNMKKNEENE_Time)
											{
												res.Add(d as LGHIPHEDCNC_Offer.BFEIHCJHHAJ);
											}
										}
										continue;
									}
								}
								res.Add(d as LGHIPHEDCNC_Offer.BFEIHCJHHAJ);
							}
						}
					}
				}
				if (!b)
					return res;
				BJIPLMJFAGH();
				return res;
			}
		}
		return res;
	}

	// // RVA: 0x102CB08 Offset: 0x102CB08 VA: 0x102CB08
	public List<LGHIPHEDCNC_Offer.PDLENIHAMBC> OGIKEILKDEA()
	{
		List<LGHIPHEDCNC_Offer.PDLENIHAMBC> res = new List<LGHIPHEDCNC_Offer.PDLENIHAMBC>();
		res.Clear();
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
			{
				if (JGPJCOCHJFJ == null)
					BJIPLMJFAGH();
				for(int i = 0; i < JGPJCOCHJFJ.Count; i++)
				{
					OCMJNBIFJNM_Offer.JPOHOLBBFGP of = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.FOFLMHELILC[JGPJCOCHJFJ[i].OIPCCBHIKIA_index];
					if(of.GBJFNGCDKPM_typ == 3)
					{
						if(of.EALOBDHOCHP_stat > 0)
						{
							LGHIPHEDCNC_Offer.PDLENIHAMBC d = GKIOIHLDBGF(BOPFPIHGJMD.MLBMHDCCGHI.FMLPIOFBCMA_3_Diva, of.MLDPDLPHJPM_OfferId) as LGHIPHEDCNC_Offer.PDLENIHAMBC;
							if(d != null)
							{
								res.Add(d);
							}
						}
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0x102CED4 Offset: 0x102CED4 VA: 0x102CED4
	public List<LGHIPHEDCNC_Offer.FCOBCHHKMOA> DNNAPBIGHJI()
	{
		List<LGHIPHEDCNC_Offer.FCOBCHHKMOA> res = new List<LGHIPHEDCNC_Offer.FCOBCHHKMOA>();
		res.Clear();
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
			{
				int found = -1;
				for(int j = 0; j < 9 && found == -1; j++)
				{ 
					for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.OICGEEKOLOG.Count; i++)
					{
						LGHIPHEDCNC_Offer.FCOBCHHKMOA GJLFANGDGCL_Target = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.OICGEEKOLOG[i];
						if(GJLFANGDGCL_Target.PLALNIIBLOF_en == 2)
						{
							if(GJLFANGDGCL_Target.DMEDKJPOLCH_cat == j)
							{
								OCMJNBIFJNM_Offer.JPOHOLBBFGP of = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.FOFLMHELILC.Find((OCMJNBIFJNM_Offer.JPOHOLBBFGP JPAEDJJFFOI) =>
								{
									//0xE6FAF4
									if(JPAEDJJFFOI.GBJFNGCDKPM_typ == GJLFANGDGCL_Target.GBJFNGCDKPM_typ)
									{
										if(JPAEDJJFFOI.MLDPDLPHJPM_OfferId == GJLFANGDGCL_Target.PPFNGGCBJKC_id)
										{
											return JPAEDJJFFOI.EALOBDHOCHP_stat < 4;
										}
									}
									return false;
								});
								if(of != null)
								{
									found = j;
									break;
								}
							}
						}
					}
				}
				if (found == -1)
					found = 0;
				for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.OICGEEKOLOG.Count; i++)
				{
					LGHIPHEDCNC_Offer.FCOBCHHKMOA of = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.OICGEEKOLOG[i];
					MDKADMHKOLN(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, BOPFPIHGJMD.MLBMHDCCGHI.GENEIBGNMPH_4_Debut, of.PPFNGGCBJKC_id, of.PDBPFJJCADD_open_at != 0 || of.FDBNFFNFOND_close_at != 0, 0, 0, 0, false);
				}
				BJIPLMJFAGH();
				for(int i = 0; i < JGPJCOCHJFJ.Count; i++)
				{
					OCMJNBIFJNM_Offer.JPOHOLBBFGP of = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.FOFLMHELILC[JGPJCOCHJFJ[i].OIPCCBHIKIA_index];
					if(of.GBJFNGCDKPM_typ == 4)
					{
						if(of.EALOBDHOCHP_stat > 0)
						{
							LGHIPHEDCNC_Offer.FCOBCHHKMOA d = GKIOIHLDBGF(BOPFPIHGJMD.MLBMHDCCGHI.GENEIBGNMPH_4_Debut, of.MLDPDLPHJPM_OfferId) as LGHIPHEDCNC_Offer.FCOBCHHKMOA;
							if(d != null)
							{
								if(d.DMEDKJPOLCH_cat != found)
								{
									if (of.EALOBDHOCHP_stat != 4)
										continue;
								}
								res.Add(d);
							}
						}
					}
				}
				if(found > 0)
				{
					if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.DFCFJMOLIOC_Cat != found)
						LONBOKLFGMI = true;
				}
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.DFCFJMOLIOC_Cat = found;
			}
		}
		return res;
	}

	// // RVA: 0x102D6A0 Offset: 0x102D6A0 VA: 0x102D6A0
	public bool PHNCOGEOBAD()
	{
		return LONBOKLFGMI;
	}

	// // RVA: 0x102D698 Offset: 0x102D698 VA: 0x102D698
	public void OLNHMMHLAGF(bool _OAFPGJLCNFM_cond)
	{
		LONBOKLFGMI = _OAFPGJLCNFM_cond;
	}

	// // RVA: 0x102D6A8 Offset: 0x102D6A8 VA: 0x102D6A8
	public bool OHILPCDFKCH()
	{
		int a1 = ECBHIIOABCK();
		int a2 = LJMOMAGLEGL(BOPFPIHGJMD.MLBMHDCCGHI.GENEIBGNMPH_4_Debut, BOPFPIHGJMD.IGHPDAGKIKO.CADDNFIKDLG_4_Complete, true);
		return a1 != a2 && -1 < a1 - a2;
	}

	// // RVA: 0x102D6EC Offset: 0x102D6EC VA: 0x102D6EC
	public int ECBHIIOABCK()
	{
		int res = 0;
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.OICGEEKOLOG.Count; i++)
			{
				if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.OICGEEKOLOG[i].PLALNIIBLOF_en == 2)
					res++;
			}
		}
		return res;
	}

	// // RVA: 0x102D84C Offset: 0x102D84C VA: 0x102D84C
	public int PDGOLEJBNMM(BOPFPIHGJMD.IGHPDAGKIKO _CMCKNKKCNDK_status, bool PFCKDGKGBMM)
	{
		return LJMOMAGLEGL(BOPFPIHGJMD.MLBMHDCCGHI.GENEIBGNMPH_4_Debut, _CMCKNKKCNDK_status, PFCKDGKGBMM);
	}

	// // RVA: 0x102A4B8 Offset: 0x102A4B8 VA: 0x102A4B8
	public int MPPINCEGOJE(BOPFPIHGJMD.IGHPDAGKIKO _CMCKNKKCNDK_status, bool PFCKDGKGBMM)
	{
		if (JGPJCOCHJFJ == null)
			BJIPLMJFAGH();
		int res = 0;
		if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
		{
			for (int i = 0; i < JGPJCOCHJFJ.Count; i++)
			{
				OCMJNBIFJNM_Offer.JPOHOLBBFGP d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.FOFLMHELILC[JGPJCOCHJFJ[i].OIPCCBHIKIA_index];
				if (d.DPMCPMJJGAA_HasFlag(BOPFPIHGJMD.CMBJEEGFODD.JPFLFLFFEDD_16))
				{
					if (PFCKDGKGBMM)
					{
						if ((int)_CMCKNKKCNDK_status <= d.EALOBDHOCHP_stat)
							res++;
					}
					else if (d.EALOBDHOCHP_stat == (int)_CMCKNKKCNDK_status)
						res++;
				}
			}
		}
		return res;
	}

	// // RVA: 0x102A290 Offset: 0x102A290 VA: 0x102A290
	public int GOJDPOGJOLM(BOPFPIHGJMD.IGHPDAGKIKO _CMCKNKKCNDK_status, bool PFCKDGKGBMM)
	{
		if (JGPJCOCHJFJ == null)
			BJIPLMJFAGH();
		int res = 0;
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
		{
			for(int i = 0; i < JGPJCOCHJFJ.Count; i++)
			{
				OCMJNBIFJNM_Offer.JPOHOLBBFGP d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.FOFLMHELILC[JGPJCOCHJFJ[i].OIPCCBHIKIA_index];
				if(d.DPMCPMJJGAA_HasFlag(BOPFPIHGJMD.CMBJEEGFODD.HIJBHIFABFC_32))
				{
					if (PFCKDGKGBMM)
					{
						if ((int)_CMCKNKKCNDK_status <= d.EALOBDHOCHP_stat)
							res++;
					}
					else if (d.EALOBDHOCHP_stat == (int)_CMCKNKKCNDK_status)
						res++;
				}
			}
		}
		return res;
	}

	// // RVA: 0x102D870 Offset: 0x102D870 VA: 0x102D870
	public int LJMOMAGLEGL(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, BOPFPIHGJMD.IGHPDAGKIKO _CMCKNKKCNDK_status, bool PFCKDGKGBMM)
	{
		if (JGPJCOCHJFJ == null)
			BJIPLMJFAGH();
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
		{
			int res = 0;
			for(int i = 0; i < JGPJCOCHJFJ.Count; i++)
			{
				OCMJNBIFJNM_Offer.JPOHOLBBFGP d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.FOFLMHELILC[JGPJCOCHJFJ[i].OIPCCBHIKIA_index];
				if(d.GBJFNGCDKPM_typ == (int)_FGHGMHPNEMG_Type)
				{
					if (PFCKDGKGBMM)
					{
						if ((int)_CMCKNKKCNDK_status <= d.EALOBDHOCHP_stat)
							res++;
					}
					else if (d.EALOBDHOCHP_stat == (int)_CMCKNKKCNDK_status)
						res++;
				}
			}
			return res;
		}
		return 0;
	}

	// // RVA: 0x102DAA4 Offset: 0x102DAA4 VA: 0x102DAA4
	public string GEGAJLNPMEC(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId)
	{
		MessageBank bk = MessageManager.Instance.GetBank("master");
		switch(_FGHGMHPNEMG_Type)
		{
			case BOPFPIHGJMD.MLBMHDCCGHI.HEFPAOLDHCK_1_Day:
				return bk.GetMessageByLabel("oda_nm_" + _MLDPDLPHJPM_OfferId.ToString("D4"));
			case BOPFPIHGJMD.MLBMHDCCGHI.FDOOAJLGFAE_2_Week:
				return bk.GetMessageByLabel("owk_nm_" + _MLDPDLPHJPM_OfferId.ToString("D4"));
			case BOPFPIHGJMD.MLBMHDCCGHI.FMLPIOFBCMA_3_Diva:
				return bk.GetMessageByLabel("odv_nm_" + _MLDPDLPHJPM_OfferId.ToString("D4"));
			case BOPFPIHGJMD.MLBMHDCCGHI.GENEIBGNMPH_4_Debut:
				return bk.GetMessageByLabel("obg_nm_" + _MLDPDLPHJPM_OfferId.ToString("D4"));
			default:
				break;
		}
		return "";
	}

	// // RVA: 0x102DC74 Offset: 0x102DC74 VA: 0x102DC74
	// public BOPFPIHGJMD.AHIOHONIGDH EKAECAHFMKE(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId) { }

	// // RVA: 0x102DC98 Offset: 0x102DC98 VA: 0x102DC98
	public BOPFPIHGJMD.AHIOHONIGDH EKAECAHFMKE(LGHIPHEDCNC_Offer.NONCDAINJLD _KOGBMDOONFA_Info)
	{
		if(_KOGBMDOONFA_Info.GBJFNGCDKPM_typ != 3)
		{
			return (BOPFPIHGJMD.AHIOHONIGDH)_KOGBMDOONFA_Info.CPKMLLNADLJ_Serie;
		}
		LGHIPHEDCNC_Offer.PDLENIHAMBC d = _KOGBMDOONFA_Info as LGHIPHEDCNC_Offer.PDLENIHAMBC;
		if(d.OCAMDLMPBGA_dv > 0)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				return (BOPFPIHGJMD.AHIOHONIGDH)IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_table[d.OCAMDLMPBGA_dv - 1].AIHCEGFANAM_SerieAttr;
			}
		}
		return BOPFPIHGJMD.AHIOHONIGDH.HJNNKCMLGFL_0_None;
	}

	// // RVA: 0x102DF48 Offset: 0x102DF48 VA: 0x102DF48
	public BOPFPIHGJMD.ADMNKELOLPN KJGAJBOBIHK(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId)
	{
		LGHIPHEDCNC_Offer.NONCDAINJLD of = GKIOIHLDBGF(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
		if(of != null)
		{
			return (BOPFPIHGJMD.ADMNKELOLPN)of.CECKOCLEABH;
		}
		return 0;
	}

	// // RVA: 0x102DF6C Offset: 0x102DF6C VA: 0x102DF6C
	public int LBDENPEGONA(int _OIOECMEEFKJ_VFp, BOPFPIHGJMD.HBJMIJIOCAM DGGBOFDCOLG)
	{
		if (_OIOECMEEFKJ_VFp < 1)
			return 0;
		if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
			{
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie != null)
				{
					OCMJNBIFJNM_Offer.PMOECIDOLNA of = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.NEGDGHKOFFF_VFplatoon[_OIOECMEEFKJ_VFp - 1];
					if(of != null)
					{
						int a1 = 100;
						int a2 = 50;
						if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer != null)
						{
							a1 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA_GetIntParam("main_vf_spec_percent", 100);
							a2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA_GetIntParam("sub_vf_spec_percent", 50);
						}
						JFFFPPPPNGK = 0;
						int res = 0;
						for(int i = 0; i < 3; i++)
						{
							int a3 = of.LBCCCKNANMJ_GetValkyrieId(i);
							if (a3 > 0)
							{
								JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo valk = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.GCINIJEMHFK(a3);
								if(valk != null && valk.PPEGAKEIEGM_Enabled == 2)
								{
									OIGEIIGKMNH_Valkyrie.HLNPGNNPCGO_ValkyrieInfo saveValk = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JJFFBDLIOCF_Valkyrie.JMJOPCDNHKK(a3);
									if (saveValk.FJODMPGPDDD_Unlocked)
									{
										if(valk.GPPEFLKGGGJ_ValkyrieId == saveValk.FODKKJIDDKN_vf_Id)
										{
											NHDJHOPLMDE n = new NHDJHOPLMDE(a3, 0);
											int a4 = 0;
											int a5 = 0;
											if (n.LAKLFHGMCLI(EPIFHEDDJAE.NGEDJNHECKN.FJFMLFPJKNB_2, i == 0 ? EPIFHEDDJAE.JFEIHHBGFPF_AbilityCondition.FHBJEIEPABF_12 : EPIFHEDDJAE.JFEIHHBGFPF_AbilityCondition.PPNNBADDNKB_11))
											{
												a4 = n.KINFGHHNFCF_Atk;
												a5 = n.NONBCCLGBAO_hit;
												JFFFPPPPNGK += n.EHMLAAHLNMN;
											}
											if (DGGBOFDCOLG == BOPFPIHGJMD.HBJMIJIOCAM.JIOPJDJBLFK_1)
												res += a5 + ((i == 0 ? a1 : a2) * valk.NONBCCLGBAO_hit) / 100;
											else if(DGGBOFDCOLG == BOPFPIHGJMD.HBJMIJIOCAM.FMHLGHDKJBC_0)
												res += a4 + ((i == 0 ? a1 : a2) * valk.KINFGHHNFCF_Atk) / 100;
										}
									}
								}
							}
						}
						return res;
					}
				}
			}
		}
		return 0;
	}

	// // RVA: 0x102E430 Offset: 0x102E430 VA: 0x102E430
	public void JPHPEIFPKDL(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId)
	{
		NKMMJACCHEH.FGHGMHPNEMG_Type = _FGHGMHPNEMG_Type;
		NKMMJACCHEH.MLDPDLPHJPM_OfferId = _MLDPDLPHJPM_OfferId;
	}

	// // RVA: 0x102E490 Offset: 0x102E490 VA: 0x102E490
	public NKMCJCAJIGD CNNICINEKBJ()
	{
		return NKMMJACCHEH;
	}

	// // RVA: 0x102E498 Offset: 0x102E498 VA: 0x102E498
	public List<NOCAJFGHDPC> NBIJDMOOILH()
	{
		return JGPJCOCHJFJ;
	}

	// // RVA: 0x10276C0 Offset: 0x10276C0 VA: 0x10276C0
	public List<NOCAJFGHDPC> BJIPLMJFAGH()
	{
		JGPJCOCHJFJ = new List<NOCAJFGHDPC>();
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
		{
			List<OCMJNBIFJNM_Offer.JPOHOLBBFGP> d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.FOFLMHELILC;
			for(int i = 0; i < d.Count; i++)
			{
				if(!d[i].DFIGPDCBAPB_IsUnitialized())
				{
					NOCAJFGHDPC data = new NOCAJFGHDPC();
					data.OIPCCBHIKIA_index = i;
					data.FGHGMHPNEMG_Type = (BOPFPIHGJMD.MLBMHDCCGHI)d[i].GBJFNGCDKPM_typ;
					data.MLDPDLPHJPM_OfferId = d[i].MLDPDLPHJPM_OfferId;
					JGPJCOCHJFJ.Add(data);
				}
			}
		}
		return JGPJCOCHJFJ;
	}

	// // RVA: 0x1027928 Offset: 0x1027928 VA: 0x1027928
	public OCMJNBIFJNM_Offer.JPOHOLBBFGP BKJJKHIBIGP(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId)
	{
		if(JGPJCOCHJFJ != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
			{
				NOCAJFGHDPC d = JGPJCOCHJFJ.Find((NOCAJFGHDPC JPAEDJJFFOI) =>
				{
					//0xE6FBD4
					if (JPAEDJJFFOI.FGHGMHPNEMG_Type != _FGHGMHPNEMG_Type)
						return false;
					return JPAEDJJFFOI.MLDPDLPHJPM_OfferId == _MLDPDLPHJPM_OfferId;
				});
				if(d != null)
				{
					return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.FOFLMHELILC[d.OIPCCBHIKIA_index];
				}
			}
		}
		return null;
	}

	// // RVA: 0x1027C8C Offset: 0x1027C8C VA: 0x1027C8C
	public LGHIPHEDCNC_Offer.NONCDAINJLD GKIOIHLDBGF(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			switch(_FGHGMHPNEMG_Type)
			{
				case BOPFPIHGJMD.MLBMHDCCGHI.HEFPAOLDHCK_1_Day:
					return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.HOJPJAFDIAD.Find((LGHIPHEDCNC_Offer.LHDLCLNBPLB JPAEDJJFFOI) =>
					{
						//0xE6FC28
						if (JPAEDJJFFOI.PLALNIIBLOF_en == 2)
							return JPAEDJJFFOI.PPFNGGCBJKC_id == _MLDPDLPHJPM_OfferId;
						return false;
					});
				case BOPFPIHGJMD.MLBMHDCCGHI.FDOOAJLGFAE_2_Week:
					return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.FFKIBJKEBNP.Find((LGHIPHEDCNC_Offer.BFEIHCJHHAJ JPAEDJJFFOI) =>
					{
						//0xE6FC94
						if (JPAEDJJFFOI.PLALNIIBLOF_en == 2)
							return JPAEDJJFFOI.PPFNGGCBJKC_id == _MLDPDLPHJPM_OfferId;
						return false;
					});
				case BOPFPIHGJMD.MLBMHDCCGHI.FMLPIOFBCMA_3_Diva:
					return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.PMCDKBBHCJK.Find((LGHIPHEDCNC_Offer.PDLENIHAMBC JPAEDJJFFOI) =>
					{
						//0xE6FD00
						if (JPAEDJJFFOI.PLALNIIBLOF_en == 2)
							return JPAEDJJFFOI.PPFNGGCBJKC_id == _MLDPDLPHJPM_OfferId;
						return false;
					});
				case BOPFPIHGJMD.MLBMHDCCGHI.GENEIBGNMPH_4_Debut:
					return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.OICGEEKOLOG.Find((LGHIPHEDCNC_Offer.FCOBCHHKMOA JPAEDJJFFOI) =>
					{
						//0xE6FD6C
						if (JPAEDJJFFOI.PLALNIIBLOF_en == 2)
							return JPAEDJJFFOI.PPFNGGCBJKC_id == _MLDPDLPHJPM_OfferId;
						return false;
					});
				default:
					break;
			}
		}
		return null;
	}

	// // RVA: 0x102E4A0 Offset: 0x102E4A0 VA: 0x102E4A0
	// public bool CKBDHFNLLJE(BOPFPIHGJMD.AHIOHONIGDH AELKJEKCJND, SeriesAttr.Type LLNKADMJODG) { }

	// // RVA: 0x102E4FC Offset: 0x102E4FC VA: 0x102E4FC
	public bool CKBDHFNLLJE(BOPFPIHGJMD.LGEIPIHHNPH _DFMOGBOPLEF_Series, SeriesAttr.Type LLNKADMJODG)
	{
		if(_DFMOGBOPLEF_Series > BOPFPIHGJMD.LGEIPIHHNPH.HJNNKCMLGFL_0_None && _DFMOGBOPLEF_Series <= BOPFPIHGJMD.LGEIPIHHNPH.LCBPJOKNKPL_7)
		{
			switch(_DFMOGBOPLEF_Series)
			{
				case BOPFPIHGJMD.LGEIPIHHNPH.HOOPCKAOMGG_1:
					return LLNKADMJODG == SeriesAttr.Type.Delta;
				case BOPFPIHGJMD.LGEIPIHHNPH.GLICCOKGLPF_2:
					return LLNKADMJODG == SeriesAttr.Type.Frontia;
				case BOPFPIHGJMD.LGEIPIHHNPH.IHCCBHDNHPC_3:
					return LLNKADMJODG == SeriesAttr.Type.Seven;
				case BOPFPIHGJMD.LGEIPIHHNPH.DBPDLIPKFAL_4:
					return LLNKADMJODG == SeriesAttr.Type.First;
				default:
					return true;
				case BOPFPIHGJMD.LGEIPIHHNPH.GDEJFFFHFGP_6:
					return LLNKADMJODG == SeriesAttr.Type.Plus;
			}
		}
		return false;
	}

	// // RVA: 0x102E578 Offset: 0x102E578 VA: 0x102E578
	public BOPFPIHGJMD.LGEIPIHHNPH MDNPDBIPKLB(BOPFPIHGJMD.AHIOHONIGDH AELKJEKCJND, int JBHBGOIMALD)
	{
		switch(AELKJEKCJND)
		{
			case BOPFPIHGJMD.AHIOHONIGDH.HJNNKCMLGFL_0_None:
			case BOPFPIHGJMD.AHIOHONIGDH.HOOPCKAOMGG_1:
			case BOPFPIHGJMD.AHIOHONIGDH.GLICCOKGLPF_2:
				return (BOPFPIHGJMD.LGEIPIHHNPH)AELKJEKCJND;
			case BOPFPIHGJMD.AHIOHONIGDH.IHCCBHDNHPC_4:
				return BOPFPIHGJMD.LGEIPIHHNPH.IHCCBHDNHPC_3;
			case BOPFPIHGJMD.AHIOHONIGDH.DBPDLIPKFAL_8:
				return BOPFPIHGJMD.LGEIPIHHNPH.DBPDLIPKFAL_4;
			case BOPFPIHGJMD.AHIOHONIGDH.GDEJFFFHFGP_16:
				return BOPFPIHGJMD.LGEIPIHHNPH.GDEJFFFHFGP_6;
			default:
				return JBHBGOIMALD == 2 ? BOPFPIHGJMD.LGEIPIHHNPH.LCBPJOKNKPL_7 : BOPFPIHGJMD.LGEIPIHHNPH.CFBJGAGBJEN_5;
		}
	}

	// // RVA: 0x102E5F0 Offset: 0x102E5F0 VA: 0x102E5F0
	public bool KGKEGICJHCB_CheckValkSerieMatch(int _OIOECMEEFKJ_VFp, BOPFPIHGJMD.AHIOHONIGDH AELKJEKCJND)
	{
		if(_OIOECMEEFKJ_VFp > 0)
		{
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database == null)
				return false;
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie == null)
				return false;
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData == null)
				return false;
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer == null)
				return false;
			for(int i = 0; i < 3; i++)
			{
				OCMJNBIFJNM_Offer.PMOECIDOLNA of = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.NEGDGHKOFFF_VFplatoon[_OIOECMEEFKJ_VFp - 1];
				int vId = of.LBCCCKNANMJ_GetValkyrieId(i);
				if (vId > 0)
				{
					JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo valk = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_table[vId - 1];
					switch(valk.AIHCEGFANAM_SerieAttr)
					{
						case 1:
							return ((int)AELKJEKCJND & 1) != 0;
						case 2:
							return ((int)AELKJEKCJND & 2) != 0;
						case 3:
							return ((int)AELKJEKCJND & 4) != 0;
						case 4:
							return ((int)AELKJEKCJND & 8) != 0;
						case 5:
							return ((int)AELKJEKCJND & 16) != 0;
					}
				}
			}
		}
		return false;
	}

	// // RVA: 0x102E8A8 Offset: 0x102E8A8 VA: 0x102E8A8
	public bool NNGDHKMNDNK(OCMJNBIFJNM_Offer.JPOHOLBBFGP _EILKGEADKGH_Order, BOPFPIHGJMD.AHIOHONIGDH AELKJEKCJND)
	{
		int a = EHMLAAHLNMN;
		if (KGKEGICJHCB_CheckValkSerieMatch(_EILKGEADKGH_Order.OIOECMEEFKJ_VFp, AELKJEKCJND))
		{
			a += CEFEHEAANKC;
		}
		return UnityEngine.Random.Range(0, 101) <= JFFFPPPPNGK + a;
	}

	// // RVA: 0x102E950 Offset: 0x102E950 VA: 0x102E950
	public bool NKHGLFOBOJD(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId, int _OIOECMEEFKJ_VFp, int MNCEBKHBBEF)
	{
		if(_OIOECMEEFKJ_VFp > 0)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			LGHIPHEDCNC_Offer.NONCDAINJLD of = GKIOIHLDBGF(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
			if(of != null)
			{
				OCMJNBIFJNM_Offer.JPOHOLBBFGP of2 = BKJJKHIBIGP(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
				if(of2 != null)
				{
					if(of2.EALOBDHOCHP_stat == 1)
					{
						bool b = ECBHIIOABCK() == LJMOMAGLEGL(BOPFPIHGJMD.MLBMHDCCGHI.GENEIBGNMPH_4_Debut, BOPFPIHGJMD.IGHPDAGKIKO.EBAPFCDNMGD_1_Order, false);
						of2.EALOBDHOCHP_stat = 2;
						//of.AIIOIKGMOBD
						of2.DFJLNPFJGDK_sdt = t;
						of2.NCDHKKCCGOD_edt = t + NPEFMNPOMMJ(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId, _OIOECMEEFKJ_VFp, (FKGMGBHBNOC.HPJOCKGKNCC_Form) MNCEBKHBBEF, true);
						of2.OIOECMEEFKJ_VFp = _OIOECMEEFKJ_VFp;
						of2.MNCEBKHBBEF_VFform = MNCEBKHBBEF;
						of2.LHMOAJAIJCO_is_new = false;
						of2.BKMEPICADBC_ResetFlag(BOPFPIHGJMD.CMBJEEGFODD.CDFJPMPHNJM_8);
						if (b || NNGDHKMNDNK(of2, EKAECAHFMKE(of)))
						{
							of2.HKFGCIOEMJE_SetFlag(BOPFPIHGJMD.CMBJEEGFODD.CDFJPMPHNJM_8);
						}
						PBKNBDCABDM_CreateSessionId(of2, true);
						return true;
					}
				}
			}
		}
		return false;
	}

	// // RVA: 0x102EC00 Offset: 0x102EC00 VA: 0x102EC00
	public long NPEFMNPOMMJ(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId, int _OIOECMEEFKJ_VFp, FKGMGBHBNOC.HPJOCKGKNCC_Form MNCEBKHBBEF, bool FMCIBHOHDAH/* = true*/)
	{
		LGHIPHEDCNC_Offer.NONCDAINJLD of = GKIOIHLDBGF(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
		int valkAtk = LBDENPEGONA(_OIOECMEEFKJ_VFp, BOPFPIHGJMD.HBJMIJIOCAM.FMHLGHDKJBC_0);
		int valkHit = LBDENPEGONA(_OIOECMEEFKJ_VFp, BOPFPIHGJMD.HBJMIJIOCAM.JIOPJDJBLFK_1);
		int offerAtk = of.FCBJFKGDINH_atk;
		int offerHit = of.NONBCCLGBAO_hit;
		BOPFPIHGJMD.ADMNKELOLPN a5 = KJGAJBOBIHK(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
		int a6 = KGLLKKCFDEL(MNCEBKHBBEF, a5, BOPFPIHGJMD.HBJMIJIOCAM.FMHLGHDKJBC_0);
		int a7 = KGLLKKCFDEL(MNCEBKHBBEF, a5, BOPFPIHGJMD.HBJMIJIOCAM.JIOPJDJBLFK_1);
		if(FMCIBHOHDAH)
		{
			valkHit = (a7 * valkHit) / 100;
			valkAtk = (a6 * valkAtk) / 100;
		}
		int a8 = of.AIIOIKGMOBD;
		int vff_superior_short_time = 10;
		int vff_inferior_ext_time = 20;
		int short_time_limit_percent = 50;
		int extension_time_limit_percent = 100;
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			vff_superior_short_time = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA_GetIntParam("vff_superior_short_time", 10);
			vff_inferior_ext_time = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA_GetIntParam("vff_inferior_ext_time", 20);
			short_time_limit_percent = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA_GetIntParam("short_time_limit_percent", 50);
			extension_time_limit_percent = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA_GetIntParam("extension_time_limit_percent", 100);
		}
		long offerTime = a8 * 60;
		int a14 = vff_inferior_ext_time;
		if (offerAtk - valkAtk < 1)
			a14 = vff_superior_short_time;
		if (offerHit - valkHit < 1)
			vff_inferior_ext_time = vff_superior_short_time;
		long res2 = vff_inferior_ext_time * (offerHit - valkHit) + a14 * (offerAtk - valkAtk);
		if(res2 < 0)
		{
			if (res2 < -short_time_limit_percent * offerTime / 100)
				res2 = -short_time_limit_percent * offerTime / 100;
		}
		else
		{
			if (extension_time_limit_percent * offerTime / 100 < res2)
				res2 = extension_time_limit_percent * offerTime / 100;
		}
		return offerTime + res2;
	}

	// // RVA: 0x102F054 Offset: 0x102F054 VA: 0x102F054
	public int KGLLKKCFDEL(FKGMGBHBNOC.HPJOCKGKNCC_Form MNCEBKHBBEF, BOPFPIHGJMD.ADMNKELOLPN _CGKPIIFCCLD_OfferType, BOPFPIHGJMD.HBJMIJIOCAM DGGBOFDCOLG)
	{
		if(MNCEBKHBBEF < FKGMGBHBNOC.HPJOCKGKNCC_Form.AEFCOHJBLPO_Num && _CGKPIIFCCLD_OfferType > BOPFPIHGJMD.ADMNKELOLPN.HJNNKCMLGFL_0_None && _CGKPIIFCCLD_OfferType <= BOPFPIHGJMD.ADMNKELOLPN.GEJGMBBCFEE_5)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				if(DGGBOFDCOLG == BOPFPIHGJMD.HBJMIJIOCAM.JIOPJDJBLFK_1)
				{
					LGHIPHEDCNC_Offer.OKNFCMGANNF of = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.KJEKILELBAB[(int)MNCEBKHBBEF];
					return of.MCOHMGONPAF((int)_CGKPIIFCCLD_OfferType - 1);
				}
				if(DGGBOFDCOLG == BOPFPIHGJMD.HBJMIJIOCAM.FMHLGHDKJBC_0)
				{
					LGHIPHEDCNC_Offer.OKNFCMGANNF of = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.KJEKILELBAB[(int)MNCEBKHBBEF];
					return of.EFHJBBKONGA((int)_CGKPIIFCCLD_OfferType - 1);
				}
			}
		}
		return 0;
	}

	// // RVA: 0x102F1F4 Offset: 0x102F1F4 VA: 0x102F1F4
	public bool JPNPPIHOJFC(long _JHNMKKNEENE_Time)
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
		{
			if(JGPJCOCHJFJ == null)
			{
				BJIPLMJFAGH();
			}
			List<OCMJNBIFJNM_Offer.JPOHOLBBFGP> saveOffers = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.FOFLMHELILC;
			bool res = false;
			for(int i = 0; i < JGPJCOCHJFJ.Count; i++)
			{
				OCMJNBIFJNM_Offer.JPOHOLBBFGP of = saveOffers[JGPJCOCHJFJ[i].OIPCCBHIKIA_index];
				if(of.EALOBDHOCHP_stat == 4)
				{
					if(of.GBJFNGCDKPM_typ == 3)
					{
						FGDFFDELFIO(of);
					}
				}
				else if(of.EALOBDHOCHP_stat == 2)
				{
					if(of.DFJLNPFJGDK_sdt != 0 && of.NCDHKKCCGOD_edt != 0)
					{
						if(_JHNMKKNEENE_Time >= of.NCDHKKCCGOD_edt)
						{
							of.EALOBDHOCHP_stat = 3;
							DGCOECIKEGA |= BOPFPIHGJMD.GNGGLPCONLM.HHPBNBIEGHK_2;
						}
						res = true;
					}
				}
				else if(of.EALOBDHOCHP_stat == 1 && of.GBJFNGCDKPM_typ == 3)
				{
					if(_JHNMKKNEENE_Time >= of.KOOEOKEDJDO_expr)
					{
						if(FGDFFDELFIO(of))
						{
							DGCOECIKEGA &= ~(BOPFPIHGJMD.GNGGLPCONLM.BCMLFJPLKAM_4 | BOPFPIHGJMD.GNGGLPCONLM.MGPHIBLKNMO_8); // 0xfffffff3
						}
					}
				}
			}
			BIFNGFAIEIL.HHCJCDFCLOB.DNKCCHCEPBH(false);
			return res;
		}
		return false;
	}

	// // RVA: 0x102F5A0 Offset: 0x102F5A0 VA: 0x102F5A0
	public BOPFPIHGJMD.IGHPDAGKIKO KOGFFBBKOPB(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId)
	{
		OCMJNBIFJNM_Offer.JPOHOLBBFGP d = BKJJKHIBIGP(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
		if (d != null)
			return (BOPFPIHGJMD.IGHPDAGKIKO)d.EALOBDHOCHP_stat;
		return BOPFPIHGJMD.IGHPDAGKIKO.FLFIICJKPKF_0;
	}

	// // RVA: 0x102F5C4 Offset: 0x102F5C4 VA: 0x102F5C4
	public bool MOOJLBNGNOB(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId, BOPFPIHGJMD.IGHPDAGKIKO _CMCKNKKCNDK_status)
	{
		OCMJNBIFJNM_Offer.JPOHOLBBFGP d = BKJJKHIBIGP(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
		if(d != null)
		{
			d.EALOBDHOCHP_stat = (int)_CMCKNKKCNDK_status;
			if(d.GBJFNGCDKPM_typ == 2 && d.EALOBDHOCHP_stat == 4)
			{
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
				{
					d.PIBLLGLCJEO_Param = (int)((NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime() - Utility.RoundDownDayUnixTime(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA_GetIntParam("start_date", 1), 86400)) / 604800) % 4 + 1;
				}
			}
			return true;
		}
		return false;
	}

	// // RVA: 0x102F7F4 Offset: 0x102F7F4 VA: 0x102F7F4
	public bool PGGLEDMJEHB(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId, int _BFINGCJHOHI_cnt)
	{
		OCMJNBIFJNM_Offer.JPOHOLBBFGP of = BKJJKHIBIGP(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
		if(of != null)
		{
			of.BFINGCJHOHI_cnt += _BFINGCJHOHI_cnt;
		}
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null && CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total != null)
			{
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.KNGCKBNFEGM_AddVOp((int)_FGHGMHPNEMG_Type, _BFINGCJHOHI_cnt);
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.KNGCKBNFEGM_AddVOp(0, _BFINGCJHOHI_cnt);
				if(_FGHGMHPNEMG_Type == BOPFPIHGJMD.MLBMHDCCGHI.FMLPIOFBCMA_3_Diva)
				{
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.PMDMJKCANFF_AddDOp(of.PIBLLGLCJEO_Param, _BFINGCJHOHI_cnt);
				}
			}
		}
		if(GNGMCIAIKMA.HHCJCDFCLOB != null)
		{
			GNGMCIAIKMA.HHCJCDFCLOB.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI.KENMCJCIGIB_3, (int)_FGHGMHPNEMG_Type, _BFINGCJHOHI_cnt, null);
			if(_FGHGMHPNEMG_Type == BOPFPIHGJMD.MLBMHDCCGHI.FMLPIOFBCMA_3_Diva)
			{
				GNGMCIAIKMA.HHCJCDFCLOB.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI.LFLMBPJJEEG_4, of.PIBLLGLCJEO_Param, _BFINGCJHOHI_cnt, null);
			}
			GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA_UpdateMission(null, -1);
		}
		return of != null;
	}

	// // RVA: 0x102FAD0 Offset: 0x102FAD0 VA: 0x102FAD0
	// public int MJILMJNJGFH(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId) { }

	// // RVA: 0x102FAF4 Offset: 0x102FAF4 VA: 0x102FAF4
	public int DEAIKHLFFCL_GetTotalVOp(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type/* = 0*/)
	{
		if(_FGHGMHPNEMG_Type < BOPFPIHGJMD.MLBMHDCCGHI.GEJGMBBCFEE/*5*/)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
			{
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter != null)
				{
					if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total != null)
					{
						return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.GKOAPFJFKEJ_VOpC[(int)_FGHGMHPNEMG_Type];
					}
				}
			}
		}
		return 0;
	}

	// // RVA: 0x102FC68 Offset: 0x102FC68 VA: 0x102FC68
	// public int KGEOELDMHJF(int _AHHJLDLAPAN_DivaId) { }

	// // RVA: 0x102E920 Offset: 0x102E920 VA: 0x102E920
	// public bool KDLDEFCPBMD(int _ADPPAIPFHML_num, int BDMLMGBLGPC) { }

	// // RVA: 0x102FDE0 Offset: 0x102FDE0 VA: 0x102FDE0
	public int DOBEIMMEHJF(List<int> NNDGIAEFMOG)
	{
		if (NNDGIAEFMOG.Count < 1)
			return -1;
		int total = 0;
		for(int i = 0; i < NNDGIAEFMOG.Count; i++)
		{
			if (NNDGIAEFMOG[i] > 0)
				total += NNDGIAEFMOG[i];
		}
		if (total < 1)
			return -1;
		int v = UnityEngine.Random.Range(0, total + 1);
		int cnt = 0;
		for(int i = 0; i < NNDGIAEFMOG.Count; i++)
		{
			if (NNDGIAEFMOG[i] > 0)
			{
				cnt += NNDGIAEFMOG[i];
				if (v <= cnt)
					return i;
			}
		}
		return -1;
	}

	// // RVA: 0x102FFA0 Offset: 0x102FFA0 VA: 0x102FFA0
	public JLLOKCFPOFH DOBIMMEGLOB(int _GOKJLBDJOLA_df, bool _BCGLDMKODLC_IsClear)
	{
		if(_BCGLDMKODLC_IsClear)
		{
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database == null)
				return null;
			LGHIPHEDCNC_Offer.JFJCGPNKCEL of = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.ODNHHBHCEDO.Find((LGHIPHEDCNC_Offer.JFJCGPNKCEL JPAEDJJFFOI) =>
			{
				//0xE6F2A4
				return JPAEDJJFFOI.GOKJLBDJOLA_df == _GOKJLBDJOLA_df;
			});
			if (of == null)
				return null;
			KPNGLBDMEBF.LHPDDGIJKNB_Reset();
			int a = UnityEngine.Random.Range(0, 101);
			if(a <= of.PANOFCFJBPN_BonusProbability)
			{
				KPNGLBDMEBF.EKLIPGELKCL_Rarity = UnityEngine.Random.Range(0, of.NDGBHPJJPAB_BonusAddMax + 1) + of.PONECEJICJC_RequestCount;
			}
			KPNGLBDMEBF.EGDEGGMPIGA_normal = UnityEngine.Random.Range(0, of.HLFHGEJKAAE_NormalAddMax + 1) + of.PLMOFDENJOL_NormalBase;
		}
		return KPNGLBDMEBF;
	}

	// // RVA: 0x1030234 Offset: 0x1030234 VA: 0x1030234
	public List<IBAOKNMIBCL> FOACCNFAGCH(List<LGHIPHEDCNC_Offer.NACBCEDKEPF> NNDGIAEFMOG, BOPFPIHGJMD.CJDCPBACOLH _HHACNFODNEF_ItemCategory, int _PPFNGGCBJKC_id, int _BFINGCJHOHI_cnt)
	{
		LGHIPHEDCNC_Offer.NACBCEDKEPF of = NNDGIAEFMOG.Find((LGHIPHEDCNC_Offer.NACBCEDKEPF JPAEDJJFFOI) =>
		{
			//0xE6F2F0
			return JPAEDJJFFOI.PPFNGGCBJKC_id == _PPFNGGCBJKC_id;
		});
		if(of != null)
		{
			LGHIPHEDCNC_Offer.NACBCEDKEPF d = new LGHIPHEDCNC_Offer.NACBCEDKEPF();
			d.ODDIHGPONFL_Copy(of);
			for(int i = 0; i < d.JPHGMBLDFOM.Length; i++)
			{
				if(d.IJFPFIOIJPB(i) == 0)
				{
					d.CJEGGLPCIOD(i, _BFINGCJHOHI_cnt);
				}
			}
			List<IBAOKNMIBCL> res = new List<IBAOKNMIBCL>();
			for(int i = 0; i < _BFINGCJHOHI_cnt; i++)
			{
				IBAOKNMIBCL data = new IBAOKNMIBCL();
				data.LHPDDGIJKNB_Reset();
				List<int> l = new List<int>();
				l.Clear();
				for(int j = 0; j < d.JPHGMBLDFOM.Length; j++)
				{
					if (d.IJFPFIOIJPB(j) < 1)
						l.Add(0);
					else
						l.Add(d.MEKEPNAMIKL(j));
				}
				int a = DOBEIMMEHJF(l);
				data.PPFNGGCBJKC_id = d.PMDIMEDKGJF_GetId(a);
				data.BFINGCJHOHI_cnt = d.GMLLLODBHDB_GetCount(a);
				data.INDDJNMPONH_type = _HHACNFODNEF_ItemCategory;
				if (d.IJFPFIOIJPB(a) > 0)
					d.CJEGGLPCIOD(a, d.IJFPFIOIJPB(a) - 1);
				res.Add(data);
			}
			return res;
		}
		return null;
	}

	// // RVA: 0x10306F4 Offset: 0x10306F4 VA: 0x10306F4
	public List<IBAOKNMIBCL> NLAPKNDOEPL_GetConfirmList(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId)
	{
		LGHIPHEDCNC_Offer.NONCDAINJLD of = GKIOIHLDBGF(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
		List<IBAOKNMIBCL> res = new List<IBAOKNMIBCL>();
		for(int i = 0; i < 3; i++)
		{
			IBAOKNMIBCL data = new IBAOKNMIBCL();
			int id = of.GNLAKGANAPG_GetId(i);
			int cnt = of.FALLJIODMBC_GetCount(i);
			if(id > 0 && cnt > 0)
			{
				data.PPFNGGCBJKC_id = id;
				data.BFINGCJHOHI_cnt = cnt;
				data.INDDJNMPONH_type = BOPFPIHGJMD.CJDCPBACOLH.HFFNOFJBCAB_0_CONFIRM;
				res.Add(data);
			}
		}
		return res;
	}

	// // RVA: 0x10308CC Offset: 0x10308CC VA: 0x10308CC
	public IBAOKNMIBCL LEPDAMFKAJP(List<LGHIPHEDCNC_Offer.NACBCEDKEPF> NNDGIAEFMOG, int FCDMDDIHMPO)
	{
		IBAOKNMIBCL res = new IBAOKNMIBCL();
		if(FCDMDDIHMPO > 0)
		{
			LGHIPHEDCNC_Offer.NACBCEDKEPF of = NNDGIAEFMOG[FCDMDDIHMPO - 1];
			res.PPFNGGCBJKC_id = of.PMDIMEDKGJF_GetId(0);
			res.BFINGCJHOHI_cnt = of.GMLLLODBHDB_GetCount(0);
			if(of.IJFPFIOIJPB(0) > 0)
			{
				of.CJEGGLPCIOD(0, of.IJFPFIOIJPB(0) - 1);
			}
			res.INDDJNMPONH_type = BOPFPIHGJMD.CJDCPBACOLH.LOAJGGDKOIH_1_GREATERARE;
		}
		return res;
	}

	// // RVA: 0x1030A70 Offset: 0x1030A70 VA: 0x1030A70
	// public int PCGKAPBMIDM(int _MLDPDLPHJPM_OfferId) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B8CD0 Offset: 0x6B8CD0 VA: 0x6B8CD0
	// // RVA: 0x1030B70 Offset: 0x1030B70 VA: 0x1030B70
	public IEnumerator FMGMIKPJNKG_Co_wait(float MINBFANDAPL, bool CNHLBGMNGOF/* = false*/, Action LFEELJFNMKL/* = null*/)
	{
		float DFCOCMIJMMC;

		//0xE6FDFC
		if(CNHLBGMNGOF)
		{
			MenuScene.Instance.RaycastDisable();
		}
		DFCOCMIJMMC = 0;
		while(DFCOCMIJMMC < MINBFANDAPL)
		{
			DFCOCMIJMMC += Time.deltaTime;
			if (LFEELJFNMKL != null)
				LFEELJFNMKL();
			yield return null;
		}
		if(CNHLBGMNGOF)
		{
			MenuScene.Instance.RaycastEnable();
		}
	}

	// // RVA: 0x1030C38 Offset: 0x1030C38 VA: 0x1030C38
	public int LHIOJHAOAOD()
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter != null)
			{
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total != null)
				{
					return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.KNCLIEBAPJD_Cosu;
				}
			}
		}
		return 0;
	}

	// // RVA: 0x102BE44 Offset: 0x102BE44 VA: 0x102BE44
	public int BCACCAGCPCO()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			for(int i = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.CNBFDHBNCBD.Count - 1; i > -1; i--)
			{
				LGHIPHEDCNC_Offer.NBOFLLJFGOA of = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.CNBFDHBNCBD[i];
				if (of.ACGMHCKDHOO <= LHIOJHAOAOD())
					return of.DOOGFEGEKLG_max;
			}
		}
		return 1;
	}

	// // RVA: 0x1030D68 Offset: 0x1030D68 VA: 0x1030D68
	public int MAPECPHBNGM(int _AHHJLDLAPAN_DivaId)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			JJOELIOGMKK_DivaIntimacyInfo data = new JJOELIOGMKK_DivaIntimacyInfo();
			data.KHEKNNFCAOI_Init(_AHHJLDLAPAN_DivaId);
			for(int i = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.KGHEHEDBPFL.Count - 1; i >= 0; i--)
			{
                LGHIPHEDCNC_Offer.NEINKEIIICC of = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.KGHEHEDBPFL[i];
                if (of.ANAJIAENLNB_lv <= data.HEKJGCMNJAB_CurrentLevel)
				{
					return of.DEMGMKOLNOI;
				}
			}
		}
		return 42;
	}

	// // RVA: 0x1030F40 Offset: 0x1030F40 VA: 0x1030F40
	public int LHLMBJNFEGB(int _AHHJLDLAPAN_DivaId)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			JJOELIOGMKK_DivaIntimacyInfo data = new JJOELIOGMKK_DivaIntimacyInfo();
			data.KHEKNNFCAOI_Init(_AHHJLDLAPAN_DivaId);
			for(int i = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.KGHEHEDBPFL.Count - 1; i >= 0; i--)
			{
                LGHIPHEDCNC_Offer.NEINKEIIICC of = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.KGHEHEDBPFL[i];
				if(of.ANAJIAENLNB_lv <= data.HEKJGCMNJAB_CurrentLevel)
				{
					return of.OANKLPBCKGN_pwup;
				}
            }
		}
		return 0;
	}

	// // RVA: 0x1031118 Offset: 0x1031118 VA: 0x1031118
	public LGHIPHEDCNC_Offer.PDLENIHAMBC AGFFPFCADJK(int _AHHJLDLAPAN_DivaId, List<LGHIPHEDCNC_Offer.PDLENIHAMBC> ABKBDLNLJDI, List<OCMJNBIFJNM_Offer.JPOHOLBBFGP> OMABPKCJECB)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			List<LGHIPHEDCNC_Offer.PDLENIHAMBC> l = new List<LGHIPHEDCNC_Offer.PDLENIHAMBC>();
			for(int i = 0; i < ABKBDLNLJDI.Count; i++)
			{
				LGHIPHEDCNC_Offer.PDLENIHAMBC d = ABKBDLNLJDI[i];
				if(d.OCAMDLMPBGA_dv == _AHHJLDLAPAN_DivaId)
				{
					if(d.GOKJLBDJOLA_df == 1)
					{
						l.Add(d);
					}
				}
			}
			for(int i = 0; i < OMABPKCJECB.Count; i++)
			{
                OCMJNBIFJNM_Offer.JPOHOLBBFGP EILKGEADKGH_Order = OMABPKCJECB[i];
				if(EILKGEADKGH_Order.PIBLLGLCJEO_Param == _AHHJLDLAPAN_DivaId)
				{
					LGHIPHEDCNC_Offer.PDLENIHAMBC GJLFANGDGCL_Target = ABKBDLNLJDI.Find((LGHIPHEDCNC_Offer.PDLENIHAMBC JPAEDJJFFOI) =>
					{
						//0xE6F33C
						if(JPAEDJJFFOI.PFJJFCPPNIN_nx != EILKGEADKGH_Order.MLDPDLPHJPM_OfferId)
						{
							if(JPAEDJJFFOI.PPFNGGCBJKC_id == EILKGEADKGH_Order.MLDPDLPHJPM_OfferId)
								return true;
							return false;
						}
						return true;
					});
					if(GJLFANGDGCL_Target != null)
					{
						LGHIPHEDCNC_Offer.PDLENIHAMBC OBKAKIJLHLF = ABKBDLNLJDI.Find((LGHIPHEDCNC_Offer.PDLENIHAMBC JPAEDJJFFOI) =>
						{
							//0xE6F3F4
							return JPAEDJJFFOI.PPFNGGCBJKC_id == GJLFANGDGCL_Target.PPFNGGCBJKC_id;
						});
						while(OBKAKIJLHLF != null)
						{
							if(OBKAKIJLHLF.GOKJLBDJOLA_df < 2)
							{
								break;
							}
							OBKAKIJLHLF = ABKBDLNLJDI.Find((LGHIPHEDCNC_Offer.PDLENIHAMBC JPAEDJJFFOI) =>
							{
								//0xE6F460
								return JPAEDJJFFOI.PFJJFCPPNIN_nx == OBKAKIJLHLF.PPFNGGCBJKC_id;
							});
						}
						if(OBKAKIJLHLF != null && OBKAKIJLHLF.GOKJLBDJOLA_df == 1)
							l.Remove(OBKAKIJLHLF);
					}
				}
            }
			if(l.Count > 0)
			{
				return l[UnityEngine.Random.Range(0, l.Count)];
			}
		}
		return null;
	}

	// // RVA: 0x1031790 Offset: 0x1031790 VA: 0x1031790
	public BOPFPIHGJMD.LEIPFJHOFPC PANBPMDADAH(int _BBIOMNCILMC_HomeDivaId, int _AKNELONELJK_difficulty)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database == null)
			return BOPFPIHGJMD.LEIPFJHOFPC.HJNNKCMLGFL_0_None;
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData == null)
			return BOPFPIHGJMD.LEIPFJHOFPC.HJNNKCMLGFL_0_None;
		List<NOCAJFGHDPC> l = JGPJCOCHJFJ;
		if (l == null)
			l = BJIPLMJFAGH();
		if (ECBHIIOABCK() - LJMOMAGLEGL(BOPFPIHGJMD.MLBMHDCCGHI.GENEIBGNMPH_4_Debut, BOPFPIHGJMD.IGHPDAGKIKO.CADDNFIKDLG_4_Complete, true) > 0)
			return BOPFPIHGJMD.LEIPFJHOFPC.HJNNKCMLGFL_0_None;
		if(!MGHPDFMDFCJ())
			return BOPFPIHGJMD.LEIPFJHOFPC.HJNNKCMLGFL_0_None;
		List<OCMJNBIFJNM_Offer.JPOHOLBBFGP> l2 = new List<OCMJNBIFJNM_Offer.JPOHOLBBFGP>();
		for(int i = 0; i < JGPJCOCHJFJ.Count; i++)
		{
			NOCAJFGHDPC data = JGPJCOCHJFJ[i];
			OCMJNBIFJNM_Offer.JPOHOLBBFGP of = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.FOFLMHELILC[data.OIPCCBHIKIA_index];
			if(of.GBJFNGCDKPM_typ == 3)
			{
				if(of.EALOBDHOCHP_stat > 0)
				{
					l2.Add(of);
				}
			}
		}
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		int diva_offer_time_limit = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA_GetIntParam("diva_offer_time_limit", 3600);
		for(int i = 0; i < l2.Count; i++)
		{
			OCMJNBIFJNM_Offer.JPOHOLBBFGP of = l2[i];
			if(of.EALOBDHOCHP_stat < 2)
			{
				if(t >= of.KOOEOKEDJDO_expr)
				{
					l2.Remove(of);
					FGDFFDELFIO(of);
				}
			}
		}
		TodoLogger.LogError(TodoLogger.ToCheck, "Removing in array like that is wrong");
		OCMJNBIFJNM_Offer.JPOHOLBBFGP of2 = l2.Find((OCMJNBIFJNM_Offer.JPOHOLBBFGP JPAEDJJFFOI) =>
		{
			//0xE6F268
			return JPAEDJJFFOI.EALOBDHOCHP_stat == 1;
		});
		BOPFPIHGJMD.LEIPFJHOFPC a2 = BOPFPIHGJMD.LEIPFJHOFPC.HJNNKCMLGFL_0_None;
		int a1;
		if(of2 == null)
		{
			List<int> l3 = new List<int>();
			for(int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
			{
                DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo dInfo = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i];
                if (dInfo.CPGFPEDMDEH_have != 0)
				{
					if(dInfo.DIPKCALNIII_diva_id != _BBIOMNCILMC_HomeDivaId)
					{
						l3.Add(dInfo.DIPKCALNIII_diva_id);
					}
				}
			}
			a1 = _BBIOMNCILMC_HomeDivaId;
			if(l3.Count > 0)
			{
				if(l3.Count > 1)
				{
					for(int i = 0; i < l3.Count; i++)
					{
						int c = l3[UnityEngine.Random.Range(1, l3.Count)];
						l3.Remove(c);
						l3.Insert(0, c);
					}
				}
				int diva_offer_home_diva_per = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA_GetIntParam("diva_offer_home_diva_per", 50);
				if(UnityEngine.Random.Range(0, 101) <= diva_offer_home_diva_per)
				{
					a1 = l3[UnityEngine.Random.Range(0, l3.Count)];
				}
			}
			if(MAPECPHBNGM(a1) < UnityEngine.Random.Range(0, 101))
				return BOPFPIHGJMD.LEIPFJHOFPC.HJNNKCMLGFL_0_None;
			LGHIPHEDCNC_Offer.PDLENIHAMBC of3 = AGFFPFCADJK(a1, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.PMCDKBBHCJK, l2);
			if(of3 == null)
			{
				if(a1 != _BBIOMNCILMC_HomeDivaId)
				{
					l3.Remove(a1);
					l3.Insert(0, _BBIOMNCILMC_HomeDivaId);
				}
				for(int i = 0; i < l3.Count; i++)
				{
					a1 = l3[i];
					of3 = AGFFPFCADJK(a1, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.PMCDKBBHCJK, l2);
					if(of3 != null)
						break;
				}
				if(of3 == null)
					return  BOPFPIHGJMD.LEIPFJHOFPC.HJNNKCMLGFL_0_None;
			}
			if(!MDKADMHKOLN(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, BOPFPIHGJMD.MLBMHDCCGHI.FMLPIOFBCMA_3_Diva, of3.PPFNGGCBJKC_id, of3.PDBPFJJCADD_open_at != 0 || of3.FDBNFFNFOND_close_at != 0, 0, a1, t + diva_offer_time_limit, false))
			{
				return BOPFPIHGJMD.LEIPFJHOFPC.HJNNKCMLGFL_0_None;
			}
			BJIPLMJFAGH();
			IOCBOGFFHFE.MLDPDLPHJPM_OfferId = of3.PPFNGGCBJKC_id;
			IOCBOGFFHFE.KFEMFDFPCGO_Level0 = of3.GOKJLBDJOLA_df;
			IOCBOGFFHFE.CIEOBFIIPLD_Level = IOCBOGFFHFE.KFEMFDFPCGO_Level0;
			IOCBOGFFHFE.NBHEBLNHOJO_IsMaxLevel = false;
			a2 = BOPFPIHGJMD.LEIPFJHOFPC.NBDBAFGEEGA_1;
		}
		else
		{
			LGHIPHEDCNC_Offer.PDLENIHAMBC of3 = GKIOIHLDBGF(BOPFPIHGJMD.MLBMHDCCGHI.FMLPIOFBCMA_3_Diva, of2.MLDPDLPHJPM_OfferId) as LGHIPHEDCNC_Offer.PDLENIHAMBC;
			a1 = of3.OCAMDLMPBGA_dv;
			if(HFLNFKFGEJH(a1) <= of3.GOKJLBDJOLA_df)
			{
				JNIGHEHKAHG_DvPow = 0;
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.JNIGHEHKAHG_DvPow = JNIGHEHKAHG_DvPow;
				return BOPFPIHGJMD.LEIPFJHOFPC.HJNNKCMLGFL_0_None;
			}
			JNIGHEHKAHG_DvPow = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.JNIGHEHKAHG_DvPow;
			LGHIPHEDCNC_Offer.PCOENHPINEI of4 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.JNIGHEHKAHG_DvPow[_AKNELONELJK_difficulty];
			of4.DEMGMKOLNOI += JNIGHEHKAHG_DvPow;
			of4.DEMGMKOLNOI += LHLMBJNFEGB(a1);
			if(of4.DEMGMKOLNOI > 99)
				of4.DEMGMKOLNOI = 100;
			if(of4.DEMGMKOLNOI < UnityEngine.Random.Range(0, 101))
			{
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.JNIGHEHKAHG_DvPow = of4.DEMGMKOLNOI;
				return BOPFPIHGJMD.LEIPFJHOFPC.HJNNKCMLGFL_0_None;
			}
			if(of3.PFJJFCPPNIN_nx > 0)
			{
				LGHIPHEDCNC_Offer.PDLENIHAMBC of5 = GKIOIHLDBGF(BOPFPIHGJMD.MLBMHDCCGHI.FMLPIOFBCMA_3_Diva, of3.PFJJFCPPNIN_nx) as LGHIPHEDCNC_Offer.PDLENIHAMBC;
				if(!MDKADMHKOLN(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, BOPFPIHGJMD.MLBMHDCCGHI.FMLPIOFBCMA_3_Diva, of5.PPFNGGCBJKC_id, of5.PDBPFJJCADD_open_at != 0 || of5.FDBNFFNFOND_close_at != 0, 0, a1, t + diva_offer_time_limit, false))
				{
					return BOPFPIHGJMD.LEIPFJHOFPC.HJNNKCMLGFL_0_None;
				}
				FGDFFDELFIO(BKJJKHIBIGP(BOPFPIHGJMD.MLBMHDCCGHI.FMLPIOFBCMA_3_Diva, of3.PPFNGGCBJKC_id));
				BJIPLMJFAGH();
				IOCBOGFFHFE.MLDPDLPHJPM_OfferId = of3.PFJJFCPPNIN_nx;
				IOCBOGFFHFE.KFEMFDFPCGO_Level0 = of3.GOKJLBDJOLA_df;
				IOCBOGFFHFE.CIEOBFIIPLD_Level = of5.GOKJLBDJOLA_df;
				IOCBOGFFHFE.NBHEBLNHOJO_IsMaxLevel = HFLNFKFGEJH(a1) <= of5.GOKJLBDJOLA_df;
				a2 = BOPFPIHGJMD.LEIPFJHOFPC.GLFGNEILACA_2;
			}
		}
		JNIGHEHKAHG_DvPow = 0;
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.JNIGHEHKAHG_DvPow = 0;
		IOCBOGFFHFE.AHHJLDLAPAN_DivaId = a1;
		IOCBOGFFHFE.OAFPGJLCNFM_cond = a2;
		if(a1 > 0)
		{
			StringBuilder str = new StringBuilder(64);
			str.SetFormat("diva_s_{0:D2}", a1);
			IOCBOGFFHFE.MBALOBPODGA_DivaName = MessageManager.Instance.GetMessage("master", str.ToString());
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			StringBuilder str2 = new StringBuilder(64);
			DKFJADMCNPI.NLKCMNHOBAI a3 = DKFJADMCNPI.NLKCMNHOBAI.HJNNKCMLGFL_0_None;
			if(a2 == BOPFPIHGJMD.LEIPFJHOFPC.GLFGNEILACA_2)
			{
				str2.SetFormat(bk.GetMessageByLabel("offer_occur_diva_offer_text_02"), IOCBOGFFHFE.MBALOBPODGA_DivaName);
				DGCOECIKEGA |= BOPFPIHGJMD.GNGGLPCONLM.MGPHIBLKNMO_8;
				a3 = DKFJADMCNPI.NLKCMNHOBAI.EGFEFGJLKLA_6;
			}
			else if(a2 == BOPFPIHGJMD.LEIPFJHOFPC.NBDBAFGEEGA_1)
			{
				str2.SetFormat(bk.GetMessageByLabel("offer_occur_diva_offer_text_01"), IOCBOGFFHFE.MBALOBPODGA_DivaName);
				DGCOECIKEGA |= BOPFPIHGJMD.GNGGLPCONLM.BCMLFJPLKAM_4;
				a3 = DKFJADMCNPI.NLKCMNHOBAI.BCMLFJPLKAM_5;
			}
			IOCBOGFFHFE.PNOBKANLFHA_OfferText = str2.ToString();
			if(a3 != 0 && GNGMCIAIKMA.HHCJCDFCLOB != null)
			{
				GNGMCIAIKMA.HHCJCDFCLOB.GJENEJOANEL(a3, a1, 1, null);
				GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA_UpdateMission(null, -1);
			}
		}
		//LAB_01032c24;
		if(IOCBOGFFHFE.MLDPDLPHJPM_OfferId > 0)
		{
			IOCBOGFFHFE.PGOGHFDBIBA_OfferName = GEGAJLNPMEC(BOPFPIHGJMD.MLBMHDCCGHI.FMLPIOFBCMA_3_Diva, IOCBOGFFHFE.MLDPDLPHJPM_OfferId);
		}
		LMAHFGBPGKF(IOCBOGFFHFE, true);
		EHEEIIHLHHB.ODDIHGPONFL_Copy(IOCBOGFFHFE);
		LPGIDDKBJFJ(BOPFPIHGJMD.FDDGIANLNAD.BCMLFJPLKAM_1, true);
		return a2;
	}

	// // RVA: 0x1027B20 Offset: 0x1027B20 VA: 0x1027B20
	public bool FGDFFDELFIO(OCMJNBIFJNM_Offer.JPOHOLBBFGP EILKGEADKGH_Order)
	{
		if(EILKGEADKGH_Order != null)
		{
			if (EILKGEADKGH_Order.BFINGCJHOHI_cnt < 1)
				EILKGEADKGH_Order.LHPDDGIJKNB_Reset(-1);
			else
			{
				EILKGEADKGH_Order.EALOBDHOCHP_stat = 0;
				EILKGEADKGH_Order.DFJLNPFJGDK_sdt = 0;
				EILKGEADKGH_Order.NCDHKKCCGOD_edt = 0;
				EILKGEADKGH_Order.OIOECMEEFKJ_VFp = 0;
				EILKGEADKGH_Order.MNCEBKHBBEF_VFform = 0;
				EILKGEADKGH_Order.KOOEOKEDJDO_expr = 0;
				EILKGEADKGH_Order.LHMOAJAIJCO_is_new = false;
				EILKGEADKGH_Order.PIBLLGLCJEO_Param = 0;
				EILKGEADKGH_Order.NACGJGLGOHM_EvFlg = 0;
				EILKGEADKGH_Order.JBPOABLNLHC_UpPer = 0;
				EILKGEADKGH_Order.BDJMFDKLHPM_s_id = "";
			}
			EILKGEADKGH_Order.JIOMCDGKIAF = 0;
			return true;
		}
		return false;
	}

	// // RVA: 0x103308C Offset: 0x103308C VA: 0x103308C
	// public bool FGDFFDELFIO(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId) { }

	// // RVA: 0x10332E4 Offset: 0x10332E4 VA: 0x10332E4
	// public void NBBFDHNKGEO() { }

	// // RVA: 0x1032DB4 Offset: 0x1032DB4 VA: 0x1032DB4
	public bool MGHPDFMDFCJ()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("vfo_diva_unlock_complete_offer_num", 10) <= DEAIKHLFFCL_GetTotalVOp(BOPFPIHGJMD.MLBMHDCCGHI.HJNNKCMLGFL_0_None);
		}
		return false;
	}

	// // RVA: 0x10334EC Offset: 0x10334EC VA: 0x10334EC
	public int OHMPHEFJBGN()
	{
		if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database == null)
			return 0;
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA_GetIntParam("beginner_reward_valkyrie_id", 26);
	}

	// // RVA: 0x10335D4 Offset: 0x10335D4 VA: 0x10335D4
	public int JMGECJKIJJF()
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
		{
			int a = OHMPHEFJBGN();
			if (a > 0 && !AHKAIKMNKJL())
			{
				JKNGJFOBADP data = new JKNGJFOBADP();
				data.JCHLONCMPAJ();
				data.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.NODLEHAGKMN_24, "");
				data.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie, a), 1, null, 0);
			}
			return a;
		}
		return 0;
	}

	// // RVA: 0x10337A8 Offset: 0x10337A8 VA: 0x10337A8
	public bool AHKAIKMNKJL()
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
		{
			int FODKKJIDDKN = OHMPHEFJBGN();
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JJFFBDLIOCF_Valkyrie.CNGNBKNBKGI_ValkList.Find((OIGEIIGKMNH_Valkyrie.HLNPGNNPCGO_ValkyrieInfo JPAEDJJFFOI) =>
			{
				//0xE6F4CC
				return JPAEDJJFFOI.FODKKJIDDKN_vf_Id == FODKKJIDDKN && JPAEDJJFFOI.FJODMPGPDDD_Unlocked;
			}) != null;
		}
		return false;
	}

	// // RVA: 0x1033940 Offset: 0x1033940 VA: 0x1033940
	// public bool BOGPKGKBCFM() { }

	// // RVA: 0x1033A20 Offset: 0x1033A20 VA: 0x1033A20
	public LGHIPHEDCNC_Offer.GHLIDOPMMDB LAIKKACPBPB(int _PPFNGGCBJKC_id)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.GLOOEBIBCOC.Find((LGHIPHEDCNC_Offer.GHLIDOPMMDB JPAEDJJFFOI) =>
			{
				//0xE6F530
				return JPAEDJJFFOI.PPFNGGCBJKC_id == _PPFNGGCBJKC_id;
			});
		}
		return null;
	}

	// // RVA: 0x1033B98 Offset: 0x1033B98 VA: 0x1033B98
	public int JGFHJPGJJHP()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer != null)
			{
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie != null)
				{
					if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
					{
						if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JJFFBDLIOCF_Valkyrie != null)
						{
							int cnt = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JJFFBDLIOCF_Valkyrie.IJHGOONDKLI_GetNumUnlocked(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie);
							int res = 1;
							for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.GLOOEBIBCOC.Count; i++)
							{
								LGHIPHEDCNC_Offer.GHLIDOPMMDB of = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.GLOOEBIBCOC[i];
								if(of.OAFPGJLCNFM_cond == 2)
								{
									if (of.JBGEEPFKIGG_val <= cnt)
										res = of.ADPPAIPFHML_num;
								}
								else if(of.OAFPGJLCNFM_cond == 1)
								{
									if (ECBHIIOABCK() - LJMOMAGLEGL(BOPFPIHGJMD.MLBMHDCCGHI.GENEIBGNMPH_4_Debut, BOPFPIHGJMD.IGHPDAGKIKO.CADDNFIKDLG_4_Complete, true) > 0)
										return res;
									res = of.ADPPAIPFHML_num;
								}
								else if(of.OAFPGJLCNFM_cond == 0)
									res = of.ADPPAIPFHML_num;
							}
							return res;
						}
					}
				}
			}
		}
		return 0;
	}

	// // RVA: 0x1033E30 Offset: 0x1033E30 VA: 0x1033E30
	public bool OOOMMBCDOBO()
	{
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.GHKKEFGDIBC_LastVfpUnlock < JGFHJPGJJHP();
	}

	// // RVA: 0x1033F2C Offset: 0x1033F2C VA: 0x1033F2C
	public string OMPLNLDPOFN_GetReleaseCondText(int _OIOECMEEFKJ_VFp)
	{
		LGHIPHEDCNC_Offer.GHLIDOPMMDB of = LAIKKACPBPB(_OIOECMEEFKJ_VFp);
		if(of != null)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(of.OAFPGJLCNFM_cond == 2)
			{
				StringBuilder str = new StringBuilder(64);
				str.SetFormat(bk.GetMessageByLabel("offer_platoon_release_condition_text_02"), of.JBGEEPFKIGG_val);
				return str.ToString();
			}
			else if(of.OAFPGJLCNFM_cond == 1)
			{
				return bk.GetMessageByLabel("offer_platoon_release_condition_text_01");
			}
		}
		return "";
	}

	// // RVA: 0x1032EB4 Offset: 0x1032EB4 VA: 0x1032EB4
	public int HFLNFKFGEJH(int _AHHJLDLAPAN_DivaId)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			JJOELIOGMKK_DivaIntimacyInfo data = new JJOELIOGMKK_DivaIntimacyInfo();
			data.KHEKNNFCAOI_Init(_AHHJLDLAPAN_DivaId);
			for(int i = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.DMOLOCBIDBD.Count - 1; i > -1; i--)
			{
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.DMOLOCBIDBD[i].ANAJIAENLNB_lv <= data.HEKJGCMNJAB_CurrentLevel)
				{
					return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.DMOLOCBIDBD[i].GOKJLBDJOLA_df;
				}
			}
		}
		return 1;
	}

	// // RVA: 0x10340FC Offset: 0x10340FC VA: 0x10340FC
	public int KPCKLKIGOID_GetFastProgramItemId()
	{
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA_GetIntParam("fast_program_item_id", 210002);
	}

	// // RVA: 0x10341EC Offset: 0x10341EC VA: 0x10341EC
	public int CKINCELGOEE_GetNumItems(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, int _KIJAPOFAGPN_ItemId)
	{
		return EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(_LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(_KIJAPOFAGPN_ItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(_KIJAPOFAGPN_ItemId), null);
	}

	// // RVA: 0x10342B0 Offset: 0x10342B0 VA: 0x10342B0
	public void CGBBDJBEFAM(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, int _KIJAPOFAGPN_ItemId, int _ADPPAIPFHML_num)
	{
		EKLNMHFCAOI.DPHGFMEPOCA_SetNumItems(_LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(_KIJAPOFAGPN_ItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(_KIJAPOFAGPN_ItemId), _ADPPAIPFHML_num, null);
	}

	// // RVA: 0x103437C Offset: 0x103437C VA: 0x103437C
	public int CKINCELGOEE_GetNumFastProgramAvaiable()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
			{
				return CKINCELGOEE_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, KPCKLKIGOID_GetFastProgramItemId());
			}
		}
		return 0;
	}

	// // RVA: 0x10344AC Offset: 0x10344AC VA: 0x10344AC
	public int HJIJAOHCLOE(int _ADPPAIPFHML_num)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
			{
				int a = CKINCELGOEE_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, KPCKLKIGOID_GetFastProgramItemId()) - _ADPPAIPFHML_num;
				if (a > -1)
					CGBBDJBEFAM(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, KPCKLKIGOID_GetFastProgramItemId(), a);
				return a;
			}
		}
		return 0;
	}

	// // RVA: 0x1034604 Offset: 0x1034604 VA: 0x1034604
	public LKBMNFAOOII NNMPMKGBJFB(long KAMNCNDAAOK, BOPFPIHGJMD.AGGLEGJDLGF FLGECLFIGPL)
	{
		if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database == null)
			return null;
		int num = 0;
		int max = 0;
		if(FLGECLFIGPL == BOPFPIHGJMD.AGGLEGJDLGF.NLGNJNJBLEJ_2_Stone)
		{
			num = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA_GetIntParam("stone_num_for_fast_complete", 5);
			max = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA_GetIntParam("max_stone_num_for_fast_complete", 40);
		}
		else if(FLGECLFIGPL == BOPFPIHGJMD.AGGLEGJDLGF.JPAODAPCJGG_1_Program)
		{
			num = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA_GetIntParam("program_num_for_fast_complete", 1);
			max = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA_GetIntParam("max_program_num_for_fast_complete", 8);
		}
		LKBMNFAOOII res = new LKBMNFAOOII();
		res.HHACNFODNEF_ItemCategory = FLGECLFIGPL;
		res.AICGFEIBKFL_Price = num;
		res.ADPPAIPFHML_num = (int)((KAMNCNDAAOK + 3599) / 3600) * num;
		if (res.ADPPAIPFHML_num > max)
			res.ADPPAIPFHML_num = max;
		res.DOOGFEGEKLG_max = max;
		return res;
	}

	// // RVA: 0x1034878 Offset: 0x1034878 VA: 0x1034878
	public LKBMNFAOOII NNMPMKGBJFB(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId, BOPFPIHGJMD.AGGLEGJDLGF FLGECLFIGPL, long _JHNMKKNEENE_Time/* = -1*/)
	{
		LKBMNFAOOII res = new LKBMNFAOOII();
		OCMJNBIFJNM_Offer.JPOHOLBBFGP of = BKJJKHIBIGP(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
		if(of != null)
		{
			if(_JHNMKKNEENE_Time < 0)
			{
				_JHNMKKNEENE_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			}
			if (of.NCDHKKCCGOD_edt >= _JHNMKKNEENE_Time) //?
				return NNMPMKGBJFB(of.NCDHKKCCGOD_edt - _JHNMKKNEENE_Time, FLGECLFIGPL);
		}
		return res;
	}

	// // RVA: 0x10349F8 Offset: 0x10349F8 VA: 0x10349F8
	public int PEBJPOPJAJJ_GetFastCompleteSlotAvaiable()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null && CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
		{
			int fast_complete_limit_cnt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA_GetIntParam("fast_complete_limit_cnt", 10);
			if (fast_complete_limit_cnt > CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.KPAJEAHFPFH_FastCmp)
				return fast_complete_limit_cnt - CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.KPAJEAHFPFH_FastCmp;
		}
		return 0;
	}

	// // RVA: 0x1034B84 Offset: 0x1034B84 VA: 0x1034B84
	public int BCJNPJKGNHF(int _JBGEEPFKIGG_val)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
			{
				int fast_complete_limit_cnt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA_GetIntParam("fast_complete_limit_cnt", 0);
				int a = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.KPAJEAHFPFH_FastCmp + _JBGEEPFKIGG_val;
				if (a > fast_complete_limit_cnt)
					a = fast_complete_limit_cnt;
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.KPAJEAHFPFH_FastCmp = a;
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.EAINJDPLIAG_FastCmpDt = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
				return a;
			}
		}
		return -1;
	}

	// // RVA: 0x1034DC0 Offset: 0x1034DC0 VA: 0x1034DC0
	public bool PCPECPFJMGC()
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
		{
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.KPAJEAHFPFH_FastCmp = 0;
			return true;
		}
		return false;
	}

	// // RVA: 0x1034E9C Offset: 0x1034E9C VA: 0x1034E9C
	public bool IHGJNLNJPOK()
	{
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.EAINJDPLIAG_FastCmpDt != NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
	}

	// // RVA: 0x1034FD8 Offset: 0x1034FD8 VA: 0x1034FD8
	public int EJBPEBIIMPG_GetVfoPlayerLevelUnlock()
	{
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("vfo_player_level", 7);
	}

	// // RVA: 0x10350C0 Offset: 0x10350C0 VA: 0x10350C0
	public bool LOCAIBNPKDL_IsPlayerLevelOk()
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
		{
			if (EJBPEBIIMPG_GetVfoPlayerLevelUnlock() <= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level)
				return true;
		}
		return false;
	}

	// // RVA: 0x10351B0 Offset: 0x10351B0 VA: 0x10351B0
	public bool NKEKPBALJGD_IsFirstAdvOfferDone()
	{
		if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database == null || CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData == null)
			return false;
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA_GetIntParam("first_adv_id", 88));
	}

	// // RVA: 0x1035330 Offset: 0x1035330 VA: 0x1035330
	public TransitionUniqueId OOFNEPBLPEA()
	{
		if(LOCAIBNPKDL_IsPlayerLevelOk())
		{
			if (NKEKPBALJGD_IsFirstAdvOfferDone())
				return TransitionUniqueId.OFFERSELECT;
			return TransitionUniqueId.HOME;
		}
		return TransitionUniqueId.MUSICSELECT;
	}

	// // RVA: 0x1035360 Offset: 0x1035360 VA: 0x1035360
	// public bool GNJCAJKEOGB() { }

	// // RVA: 0x1035370 Offset: 0x1035370 VA: 0x1035370
	// public bool GNJCAJKEOGB(BOPFPIHGJMD.GNGGLPCONLM HBOHFOPMLBO) { }

	// // RVA: 0x1035380 Offset: 0x1035380 VA: 0x1035380
	public void PANKGNBPFEL(BOPFPIHGJMD.GNGGLPCONLM HBOHFOPMLBO)
	{
		DGCOECIKEGA = HBOHFOPMLBO;
	}

	// // RVA: 0x102BE34 Offset: 0x102BE34 VA: 0x102BE34
	public void JLKENFELMPM_SetFlag(BOPFPIHGJMD.GNGGLPCONLM HBOHFOPMLBO)
	{
		DGCOECIKEGA |= HBOHFOPMLBO;
	}

	// // RVA: 0x102F590 Offset: 0x102F590 VA: 0x102F590
	public void EGNCJPMPMDC_ClearFlag(BOPFPIHGJMD.GNGGLPCONLM HBOHFOPMLBO)
	{
		DGCOECIKEGA &= ~HBOHFOPMLBO;
	}

	// // RVA: 0x1035388 Offset: 0x1035388 VA: 0x1035388
	public bool PPPLNJCFAID()
	{
		if (!LOCAIBNPKDL_IsPlayerLevelOk())
			return false;
		if (PEMMDEMCHAH())
			return false;
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		if(OONMAICCONN_HasDivaOfferCond())
		{
			GHNMKNCNHAA(IOCBOGFFHFE);
			EHEEIIHLHHB.ODDIHGPONFL_Copy(IOCBOGFFHFE);
			if (IOCBOGFFHFE.OAFPGJLCNFM_cond == BOPFPIHGJMD.LEIPFJHOFPC.GLFGNEILACA_2)
				DGCOECIKEGA |= BOPFPIHGJMD.GNGGLPCONLM.MGPHIBLKNMO_8;
			else if (IOCBOGFFHFE.OAFPGJLCNFM_cond == BOPFPIHGJMD.LEIPFJHOFPC.NBDBAFGEEGA_1)
				DGCOECIKEGA |= BOPFPIHGJMD.GNGGLPCONLM.BCMLFJPLKAM_4;
		}
		if(DGCOECIKEGA == BOPFPIHGJMD.GNGGLPCONLM.BCMLFJPLKAM_4 || DGCOECIKEGA == BOPFPIHGJMD.GNGGLPCONLM.MGPHIBLKNMO_8)
		{
			if(EHEEIIHLHHB.MLDPDLPHJPM_OfferId > 0)
			{
				OCMJNBIFJNM_Offer.JPOHOLBBFGP of = BKJJKHIBIGP(BOPFPIHGJMD.MLBMHDCCGHI.FMLPIOFBCMA_3_Diva, EHEEIIHLHHB.MLDPDLPHJPM_OfferId);
				if(of == null || time > of.KOOEOKEDJDO_expr)
				{
					DGCOECIKEGA &= ~(BOPFPIHGJMD.GNGGLPCONLM.BCMLFJPLKAM_4 | BOPFPIHGJMD.GNGGLPCONLM.MGPHIBLKNMO_8);
					IOCBOGFFHFE.LHPDDGIJKNB_Reset();
					EHEEIIHLHHB.LHPDDGIJKNB_Reset();
					BFJFAIIAMMO(BOPFPIHGJMD.FDDGIANLNAD.BCMLFJPLKAM_1, true);
				}
			}
		}
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
			{
				if(GBOGLEDPFIO == 0)
				{
					GBOGLEDPFIO = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.JMFOBCHBCCB(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.LJPLPIOJCNK_LastShowAt);
				}
				int sDate = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA_GetIntParam("start_date", 1);
				sDate = (int)Utility.RoundDownDayUnixTime(sDate, 86400);
				HCHNGGAMGAD = ((time - sDate) / 604800) * 604800 + 604800 + sDate;
				if(time >= GBOGLEDPFIO || time >= HCHNGGAMGAD)
				{
					LPGIDDKBJFJ(BOPFPIHGJMD.FDDGIANLNAD.DMHGLBIOLLL_2, true);
				}
				GBOGLEDPFIO = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.JMFOBCHBCCB(time);
				if(MGMIIAMOMGH(BOPFPIHGJMD.FDDGIANLNAD.DMHGLBIOLLL_2))
				{
					DGCOECIKEGA |= BOPFPIHGJMD.GNGGLPCONLM.OCKIDPJNNBP_1;
				}
				if(ECBHIIOABCK() - LJMOMAGLEGL(BOPFPIHGJMD.MLBMHDCCGHI.GENEIBGNMPH_4_Debut, BOPFPIHGJMD.IGHPDAGKIKO.CADDNFIKDLG_4_Complete, true) > 0 ||
					DGCOECIKEGA == BOPFPIHGJMD.GNGGLPCONLM.HJNNKCMLGFL_0_None)
				{
					return CCPNBHCKNDC(time, MGMIIAMOMGH(BOPFPIHGJMD.FDDGIANLNAD.BCMLFJPLKAM_1));
				}
				return true;
			}
		}
		return false;
	}

	// // RVA: 0x1035CB8 Offset: 0x1035CB8 VA: 0x1035CB8
	public bool CCPNBHCKNDC()
	{
		if (PEMMDEMCHAH())
			return false;
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		return CCPNBHCKNDC(time, false);
	}

	// // RVA: 0x1035C7C Offset: 0x1035C7C VA: 0x1035C7C
	// private bool OJELEDJNCFO(long _JHNMKKNEENE_Time) { }

	// // RVA: 0x1035DD0 Offset: 0x1035DD0 VA: 0x1035DD0
	private bool CCPNBHCKNDC(long _JHNMKKNEENE_Time, bool CGKINNALDGE)
	{
		if (JGPJCOCHJFJ == null)
			BJIPLMJFAGH();
		if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
		{
			List<OCMJNBIFJNM_Offer.JPOHOLBBFGP> l = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.FOFLMHELILC;
			bool b = false;
			bool res = CGKINNALDGE;
			for (int i = 0; i < JGPJCOCHJFJ.Count; i++)
			{
				OCMJNBIFJNM_Offer.JPOHOLBBFGP of = l[JGPJCOCHJFJ[i].OIPCCBHIKIA_index];
				if(of.EALOBDHOCHP_stat == 1)
				{
					if(of.GBJFNGCDKPM_typ == 3)
					{
						if(_JHNMKKNEENE_Time >= of.KOOEOKEDJDO_expr)
						{
							b = true;
							if (FGDFFDELFIO(of))
								DGCOECIKEGA &= ~(BOPFPIHGJMD.GNGGLPCONLM.BCMLFJPLKAM_4 | BOPFPIHGJMD.GNGGLPCONLM.MGPHIBLKNMO_8);
						}
					}
				}
				else if(of.EALOBDHOCHP_stat == 2)
				{
					if(_JHNMKKNEENE_Time >= of.NCDHKKCCGOD_edt)
					{
						DGCOECIKEGA |= BOPFPIHGJMD.GNGGLPCONLM.HHPBNBIEGHK_2;
						return true;
					}
				}
				else if(of.EALOBDHOCHP_stat == 3)
				{
					res = true;
				}
			}
			if (b)
				BJIPLMJFAGH();
			return res;
		}
		return false;
	}

	// // RVA: 0x10360A0 Offset: 0x10360A0 VA: 0x10360A0
	public string JIMBMBEEMHI()
	{
		MessageBank bk = MessageManager.Instance.GetBank("menu");
		if (ECBHIIOABCK() - LJMOMAGLEGL(BOPFPIHGJMD.MLBMHDCCGHI.GENEIBGNMPH_4_Debut, BOPFPIHGJMD.IGHPDAGKIKO.CADDNFIKDLG_4_Complete, true) < 1)
		{
			if ((DGCOECIKEGA & BOPFPIHGJMD.GNGGLPCONLM.MGPHIBLKNMO_8) == 0)
			{
				if ((DGCOECIKEGA & BOPFPIHGJMD.GNGGLPCONLM.BCMLFJPLKAM_4) != 0)
				{
					StringBuilder str = new StringBuilder(64);
					str.SetFormat(bk.GetMessageByLabel("offer_infomation_text_02"), EHEEIIHLHHB.MBALOBPODGA_DivaName);
					return str.ToString();
				}
				if ((DGCOECIKEGA & BOPFPIHGJMD.GNGGLPCONLM.HHPBNBIEGHK_2) == 0)
				{
					if ((DGCOECIKEGA & BOPFPIHGJMD.GNGGLPCONLM.OCKIDPJNNBP_1) == 0)
						return "";
					return bk.GetMessageByLabel("offer_infomation_text_01");
				}
				else
					return bk.GetMessageByLabel("offer_infomation_text_04");
			}
			else
				return bk.GetMessageByLabel("offer_infomation_text_03");
		}
		else
		{
			if ((DGCOECIKEGA & BOPFPIHGJMD.GNGGLPCONLM.HHPBNBIEGHK_2) == 0)
				return "";
			return bk.GetMessageByLabel("offer_infomation_text_04");
		}
	}

	// // RVA: 0x10362E0 Offset: 0x10362E0 VA: 0x10362E0
	public bool NLDDHJGHHOD()
	{
		return (DGCOECIKEGA & BOPFPIHGJMD.GNGGLPCONLM.HHPBNBIEGHK_2) != 0; // << 13 >> 15
	}

	// // RVA: 0x10362EC Offset: 0x10362EC VA: 0x10362EC
	public long IILNIBNFOLG(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type)
	{
		if (_FGHGMHPNEMG_Type == BOPFPIHGJMD.MLBMHDCCGHI.FDOOAJLGFAE_2_Week)
			return HCHNGGAMGAD;
		else if (_FGHGMHPNEMG_Type == BOPFPIHGJMD.MLBMHDCCGHI.HEFPAOLDHCK_1_Day)
			return AIHOHDONCND;
		else return 0;
	}

	// // RVA: 0x1036320 Offset: 0x1036320 VA: 0x1036320
	public string IJEFGJHHELK()
	{
		MessageBank bk = MessageManager.Instance.GetBank("menu");
		if(bk != null)
			return bk.GetMessageByLabel("offer_notification_return_vfp_title");
		return JpStringLiterals.StringLiteral_12139;
	}

	// // RVA: 0x10363E4 Offset: 0x10363E4 VA: 0x10363E4
	public string GOIOHEOGOFK(int _OIOECMEEFKJ_VFp)
	{
		if(_OIOECMEEFKJ_VFp > 0 && _OIOECMEEFKJ_VFp <= 5)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(bk != null)
			{
				return bk.GetMessageByLabel("offer_notification_return_vfp_" + _OIOECMEEFKJ_VFp);
			}
			return JpStringLiterals.StringLiteral_12141 + JPJADDADKDA[_OIOECMEEFKJ_VFp - 1];
		}
		return "";
	}

	// // RVA: 0x102EF84 Offset: 0x102EF84 VA: 0x102EF84
	public string PBKNBDCABDM_CreateSessionId(OCMJNBIFJNM_Offer.JPOHOLBBFGP _GJLFANGDGCL_Target, bool _FBBNPFFEJBN_Force/* = false*/)
	{
		if(_GJLFANGDGCL_Target != null)
		{
			if(!_FBBNPFFEJBN_Force)
			{
				if(_GJLFANGDGCL_Target.BDJMFDKLHPM_s_id != "")
					return _GJLFANGDGCL_Target.BDJMFDKLHPM_s_id;
			}
			string res = JDDGPJDKHNE.GPLMOKEIOLE();
			_GJLFANGDGCL_Target.BDJMFDKLHPM_s_id = res;
			return res;
		}
		return "";
	}

	// // RVA: 0x1036554 Offset: 0x1036554 VA: 0x1036554
	// public string PBKNBDCABDM(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId, bool _FBBNPFFEJBN_Force = False) { }

	// // RVA: 0x1036574 Offset: 0x1036574 VA: 0x1036574
	public string OHDGMEGGLDP_GetSessionId(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId)
	{
		OCMJNBIFJNM_Offer.JPOHOLBBFGP of = BKJJKHIBIGP(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
		if (of != null)
			return of.BDJMFDKLHPM_s_id;
		return "";
	}

	// // RVA: 0x1036600 Offset: 0x1036600 VA: 0x1036600
	// public bool MPEEILDOBCJ(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId) { }

	// // RVA: 0x1036690 Offset: 0x1036690 VA: 0x1036690
	public BOPFPIHGJMD.JFHCHOILMEL JAMKJBMGAGI()
	{
		return GINJHBLEALE;
	}

	// // RVA: 0x1036698 Offset: 0x1036698 VA: 0x1036698
	public BOPFPIHGJMD.JFHCHOILMEL HKDGKDNIGDD()
	{
		GINJHBLEALE = BOPFPIHGJMD.JFHCHOILMEL.HJNNKCMLGFL_0_None;
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			long _JHNMKKNEENE_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			DateTime date = Utility.GetLocalDateTime(_JHNMKKNEENE_Time);
			int day = (int)date.DayOfWeek;
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.CDCCOJKCHIG.Count > 0)
			{
				LGHIPHEDCNC_Offer.ADLCPEOHOMP dbOffer = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.CDCCOJKCHIG[0];
				LHNLHFKDPKI = dbOffer.CEKFBFIOBGO(day);
				CEFEHEAANKC = dbOffer.CPKMLLNADLJ_Serie;
				EHMLAAHLNMN = dbOffer.JPDCHPDMDDG;
				LGHIPHEDCNC_Offer.ADLCPEOHOMP dbOffer2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.CDCCOJKCHIG.Find((LGHIPHEDCNC_Offer.ADLCPEOHOMP JPAEDJJFFOI) =>
				{
					//0xE6F57C
					return _JHNMKKNEENE_Time >= JPAEDJJFFOI.PDBPFJJCADD_open_at && JPAEDJJFFOI.FDBNFFNFOND_close_at >= _JHNMKKNEENE_Time;
				});
				if (dbOffer2 != null)
				{
					GINJHBLEALE = (BOPFPIHGJMD.JFHCHOILMEL)dbOffer2.GBJFNGCDKPM_typ;
					LHNLHFKDPKI = dbOffer2.CEKFBFIOBGO(day);
					CEFEHEAANKC = dbOffer2.CPKMLLNADLJ_Serie;
					EHMLAAHLNMN = dbOffer2.JPDCHPDMDDG;
				}
			}
		}
		return GINJHBLEALE;
	}

	// // RVA: 0x1036A7C Offset: 0x1036A7C VA: 0x1036A7C
	public void EBJOGGIHHBA(BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId, bool FMLIHIEMBBH/* = false*/)
	{
		NGHMGNMNNEP.FKDIMODKKJD(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
		NGHMGNMNNEP.CDNFIAKLGLH();
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		NGHMGNMNNEP.JEMAJJIPHGA(t);
		OCMJNBIFJNM_Offer.JPOHOLBBFGP of = BKJJKHIBIGP(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
		int a = of.JBPOABLNLHC_UpPer - 100;
		NGHMGNMNNEP.KKBAGBFOPIJ_IsBonus = of.DPMCPMJJGAA_HasFlag(BOPFPIHGJMD.CMBJEEGFODD.PIICPBCIHKN_4);
		NGHMGNMNNEP.FLIEFMMPKHF_BonusNum = a > 0 ? a : 0;
		if(NGHMGNMNNEP.KKBAGBFOPIJ_IsBonus)
		{
			NGHMGNMNNEP.JEMJKEPLPAA(a, BOPFPIHGJMD.CJDCPBACOLH.CCAPCGPIIPF_3_NOMAL);
		}
		List<IBAOKNMIBCL> a2 = NGHMGNMNNEP.KBEMAMHADOO(NGHMGNMNNEP.ENEHOPNDNAF, NGHMGNMNNEP.AJPLGEHPPGN);
		NGHMGNMNNEP.CMMNABJIKOH_UCNum = NGHMGNMNNEP.JLHACGNEFPJ_GetNumUc(a2);
		NGHMGNMNNEP.BOAOOEIIAHG(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId, a2);
		if(of.BFINGCJHOHI_cnt == 1)
		{
			if (of.JIOMCDGKIAF == 0)
				of.JIOMCDGKIAF = 1;
		}
	}

	// // RVA: 0x1036E04 Offset: 0x1036E04 VA: 0x1036E04
	private bool CEHIEFPLPFM_IsOverflow(BBHNACPENDM_ServerSaveData LNEAHKALBHN, OKGLGHCBCJP_Database JLBMBKHBKBG, int MBBJMJAAODG, int ENHEJFPMPJH)
	{
		EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(MBBJMJAAODG);
		int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(MBBJMJAAODG);
		int num = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(JLBMBKHBKBG, LNEAHKALBHN, cat, id, null);
		if(cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC && cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
		{
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.GIMBFBNKPNO_CompoItem)
			{
				HHPEMHHCKBE_Compo.MLMDKHBFOJM dbItem = JLBMBKHBKBG.ALFKMKICDPP_Compo.CDENCMNHNGA_table[id - 1];
				for(int i = 0; i < dbItem.JCJGGHGIKIJ(); i++)
				{
					if (CEHIEFPLPFM_IsOverflow(LNEAHKALBHN, JLBMBKHBKBG, dbItem.CBLLFCGEJAI(i), ENHEJFPMPJH))
						return true;
				}
			}
			else
			{
				if (EKLNMHFCAOI.AFEONHCADEL_GetMaxAllowed(JLBMBKHBKBG, LNEAHKALBHN, cat, id, null) < num + ENHEJFPMPJH)
					return true;
			}
		}
		return false;
	}

	// // RVA: 0x103701C Offset: 0x103701C VA: 0x103701C
	public void EBJOGGIHHBA(JKNGJFOBADP _JANMJPOKLFL_InventoryUtil, BOPFPIHGJMD.MLBMHDCCGHI _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId, ref bool GHEHKJFGOIE)
	{
		GHEHKJFGOIE = false;
		NGHMGNMNNEP.FKDIMODKKJD(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
		NGHMGNMNNEP.CDNFIAKLGLH();
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		NGHMGNMNNEP.JEMAJJIPHGA(t);
		OCMJNBIFJNM_Offer.JPOHOLBBFGP of = BKJJKHIBIGP(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
		NGHMGNMNNEP.KKBAGBFOPIJ_IsBonus = of.DPMCPMJJGAA_HasFlag(BOPFPIHGJMD.CMBJEEGFODD.PIICPBCIHKN_4);
		int a = of.JBPOABLNLHC_UpPer - 100;
		NGHMGNMNNEP.FLIEFMMPKHF_BonusNum = a > 0 ? a : 0;
		if(NGHMGNMNNEP.KKBAGBFOPIJ_IsBonus)
		{
			NGHMGNMNNEP.JEMJKEPLPAA(a, BOPFPIHGJMD.CJDCPBACOLH.CCAPCGPIIPF_3_NOMAL);
		}
		List<IBAOKNMIBCL> a2 = NGHMGNMNNEP.KBEMAMHADOO(NGHMGNMNNEP.ENEHOPNDNAF, NGHMGNMNNEP.AJPLGEHPPGN);
		NGHMGNMNNEP.CMMNABJIKOH_UCNum = NGHMGNMNNEP.JLHACGNEFPJ_GetNumUc(a2);
		BBHNACPENDM_ServerSaveData tmpData = new BBHNACPENDM_ServerSaveData();
		tmpData.KHEKNNFCAOI_Init(0x1fdcffdffffff7);
		tmpData.ODDIHGPONFL_Copy(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData);
		ViewOfferCompensation v = ViewOfferCompensation.CreateList(_FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId);
		for(int i = 0; i < v.ItemList.Count; i++)
		{
			GHEHKJFGOIE = CEHIEFPLPFM_IsOverflow(tmpData, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, v.ItemList[i].itemId, v.ItemList[i].itemNum);
			if(GHEHKJFGOIE)
			{
				break;
			}
		}
		NGHMGNMNNEP.BOAOOEIIAHG(_JANMJPOKLFL_InventoryUtil, _FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId, a2);
		if(of.BFINGCJHOHI_cnt == 1)
		{
			if(of.JIOMCDGKIAF == 0)
			{
				of.JIOMCDGKIAF = 1;
			}
		}
	}

	// // RVA: 0x1037620 Offset: 0x1037620 VA: 0x1037620
	public CBJJINJDFDC IKENGGJIJJO()
	{
		return NGHMGNMNNEP;
	}

	// // RVA: 0x1037628 Offset: 0x1037628 VA: 0x1037628
	public PGCENGCEJGB OFJFGHEIMAH(BOPFPIHGJMD.DBNJDPHLLHI _CIANOCNPIFF_Type)
	{
		PGCENGCEJGB res = new PGCENGCEJGB();
		res.PPFNGGCBJKC_id = 0;
		res.MKPJBDFDHOL_ThumbId = 0;
		res.LHMDABPNDDH_state = BOPFPIHGJMD.MGPIJGMDLOM.HJNNKCMLGFL_3_None;
		if(_CIANOCNPIFF_Type > 0)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				LGHIPHEDCNC_Offer.GGKANMNMPBB of = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.FOIEHFEINKI[(int)_CIANOCNPIFF_Type - 1];
				res.PPFNGGCBJKC_id = of.PPFNGGCBJKC_id;
				res.MKPJBDFDHOL_ThumbId = of.MKPJBDFDHOL_ThumbId;
				res.LHMDABPNDDH_state = _CIANOCNPIFF_Type == BOPFPIHGJMD.DBNJDPHLLHI.KMCGPEACGEE_11 ? BOPFPIHGJMD.MGPIJGMDLOM.JIOPJDJBLFK_2 : (_CIANOCNPIFF_Type == BOPFPIHGJMD.DBNJDPHLLHI.LKFPALJBJFM_10 ? BOPFPIHGJMD.MGPIJGMDLOM.FMHLGHDKJBC_1 : BOPFPIHGJMD.MGPIJGMDLOM.INIMBLOHIEF_0);
			}
		}
		return res;
	}

	// // RVA: 0x103780C Offset: 0x103780C VA: 0x103780C
	public string JIDINGHMOJF()
	{
		MessageBank bank = MessageManager.Instance.GetBank("menu");
		if(!LOCAIBNPKDL_IsPlayerLevelOk())
		{
			return string.Format(bank.GetMessageByLabel("home_unlock_rank"), EJBPEBIIMPG_GetVfoPlayerLevelUnlock());
		}
		else
		{
			int a = 0;
			for(int i = 0; i < 5; i++)
			{
				a += LJMOMAGLEGL((BOPFPIHGJMD.MLBMHDCCGHI) i, BOPFPIHGJMD.IGHPDAGKIKO.FJGFAPKLLCL_3_Achieved/* 3*/, false);
			}
			return string.Format(bank.GetMessageByLabel("offer_operation_badge_text"), a);
		}
	}

	// // RVA: 0x1035B84 Offset: 0x1035B84 VA: 0x1035B84
	public bool MGMIIAMOMGH(BOPFPIHGJMD.FDDGIANLNAD FIKCHOLCKNJ)
	{
		return GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer.MGMIIAMOMGH(FIKCHOLCKNJ);
	}

	// // RVA: 0x10331C4 Offset: 0x10331C4 VA: 0x10331C4
	public void LPGIDDKBJFJ(BOPFPIHGJMD.FDDGIANLNAD FIKCHOLCKNJ, bool OGBEGDKPDGK)
	{
		GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer.LPGIDDKBJFJ(FIKCHOLCKNJ);
		if(!OGBEGDKPDGK)
			return;
		GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
	}

	// // RVA: 0x1035A64 Offset: 0x1035A64 VA: 0x1035A64
	public void BFJFAIIAMMO(BOPFPIHGJMD.FDDGIANLNAD FIKCHOLCKNJ, bool OGBEGDKPDGK)
	{
		GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer.BFJFAIIAMMO(FIKCHOLCKNJ);
		if (!OGBEGDKPDGK)
			return;
		GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
	}

	// // RVA: 0x1035868 Offset: 0x1035868 VA: 0x1035868
	public bool OONMAICCONN_HasDivaOfferCond()
	{
		return GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer.PCLGJLABHKG_DivaOfferInfo.OAFPGJLCNFM_cond != BOPFPIHGJMD.LEIPFJHOFPC.HJNNKCMLGFL_0_None;
	}

	// // RVA: 0x10330A4 Offset: 0x10330A4 VA: 0x10330A4
	public void LMAHFGBPGKF(GBAGPIKOGAN_DivaOfferInfo _KOGBMDOONFA_Info, bool OGBEGDKPDGK)
	{
		GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer.LMAHFGBPGKF(_KOGBMDOONFA_Info);
		if(!OGBEGDKPDGK)
			return;
		GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
	}

	// // RVA: 0x103596C Offset: 0x103596C VA: 0x103596C
	public void GHNMKNCNHAA(GBAGPIKOGAN_DivaOfferInfo _KOGBMDOONFA_Info)
	{
		GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer.OEIIDFEIFBE(_KOGBMDOONFA_Info);
	}

	// // RVA: 0x1037990 Offset: 0x1037990 VA: 0x1037990
	public void CPDBAIILNPL(bool OGBEGDKPDGK)
	{
		GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer.CPDBAIILNPL();
		if (!OGBEGDKPDGK)
			return;
		GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
	}

	// // RVA: 0x1037AA8 Offset: 0x1037AA8 VA: 0x1037AA8
	public void HJOLFCDAIGE(BOPFPIHGJMD.MLBMHDCCGHI CKEDODOIIPD)
	{
		HMPKMCKANBG = CKEDODOIIPD;
	}

	// // RVA: 0x1037AB0 Offset: 0x1037AB0 VA: 0x1037AB0
	public BOPFPIHGJMD.MLBMHDCCGHI NPIJHJNCBGM()
	{
		return HMPKMCKANBG;
	}

	// // RVA: 0x1037AB8 Offset: 0x1037AB8 VA: 0x1037AB8
	// public int PICPOPFLEJH() { }

	// // RVA: 0x1037BBC Offset: 0x1037BBC VA: 0x1037BBC
	public int EKODBMNLMKA()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null && IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer != null)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA_GetIntParam("sns_diva_room_id", 59);
		}
		return 59;
	}

	// // RVA: 0x1037CC0 Offset: 0x1037CC0 VA: 0x1037CC0
	public void NCGGBBELDFI(bool _OAFPGJLCNFM_cond)
	{
		GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer.GJAFIADJFHH_IsSortDesc = _OAFPGJLCNFM_cond;
		GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
	}

	// // RVA: 0x1037DF4 Offset: 0x1037DF4 VA: 0x1037DF4
	public bool LBKNBKPBAPJ_IsSortDesc()
	{
		return GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer.GJAFIADJFHH_IsSortDesc;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B8D48 Offset: 0x6B8D48 VA: 0x6B8D48
	// // RVA: 0x1037EDC Offset: 0x1037EDC VA: 0x1037EDC
	public IEnumerator CEHFPAGELLE_Coroutine_ReceiveVOP_UnreceivedAchivements(IMCBBOAFION BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
    {
		BBHNACPENDM_ServerSaveData MNKKMKJMFDB_ServerSave; // 0x20
		List<string> HLOHHJKCOIP; // 0x24
		int MAHHCPJIKHA_VopVcAchvtCnt; // 0x28

		//0xE70060
		MNKKMKJMFDB_ServerSave = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData;
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null && MNKKMKJMFDB_ServerSave != null)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.FFKIBJKEBNP[0].LJNAKDMILMC_key == 0)
			{
				if (BHFHGFKBOHH_OnSuccess != null)
					BHFHGFKBOHH_OnSuccess();
			}
			else
			{
				bool PLOOEECNHFB = false;
				bool NPNNPNAIONN_IsError = false;
				StringBuilder str = new StringBuilder(256);
				HLOHHJKCOIP = new List<string>();
				List<string> CLPMDJFKJBO = new List<string>();
				List<BADCBAILPID> FCLLKLPHPMP = new List<BADCBAILPID>();
				List<BADCBAILPID> ICKPEPLDFOG = new List<BADCBAILPID>();
				List<NOCAJFGHDPC> data = BJIPLMJFAGH();
				for (int i = 0; i < data.Count;  i++)
				{
					OCMJNBIFJNM_Offer.JPOHOLBBFGP d = MNKKMKJMFDB_ServerSave.DAEJHMCMFJD_Offer.FOFLMHELILC[data[i].OIPCCBHIKIA_index];
					if (d.BFINGCJHOHI_cnt > 0)
					{
						int val = 0;
						int offerId = d.MLDPDLPHJPM_OfferId;
						switch (d.GBJFNGCDKPM_typ)
						{
							case 1:
								val = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.HOJPJAFDIAD[offerId - 1].LJNAKDMILMC_key;
								break;
							case 2:
								val = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.FFKIBJKEBNP[offerId - 1].LJNAKDMILMC_key;
								break;
							case 3:
								val = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.PMCDKBBHCJK[offerId - 1].LJNAKDMILMC_key;
								break;
							case 4:
								val = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.OICGEEKOLOG[offerId - 1].LJNAKDMILMC_key;
								break;
							default:
								break;
						}
						if(val > 0)
						{
							str.Clear();
							str.AppendFormat("new_offer_clear_key_" + val.ToString("D4"), Array.Empty<object>());
							HLOHHJKCOIP.Add(str.ToString());
							BADCBAILPID data2 = new BADCBAILPID();
							data2.FGHGMHPNEMG_Type = d.GBJFNGCDKPM_typ;
							data2.MLDPDLPHJPM_OfferId = d.MLDPDLPHJPM_OfferId;
							data2.GCFBAJONKHA = str.ToString();
							FCLLKLPHPMP.Add(data2);
						}
					}
				}
				if(HLOHHJKCOIP.Count < 1)
				{
					if (BHFHGFKBOHH_OnSuccess != null)
						BHFHGFKBOHH_OnSuccess();
					MNKKMKJMFDB_ServerSave.DAEJHMCMFJD_Offer.KNIKMMKNOFA_ARcv = 3;
				}
				else
				{
					MAHHCPJIKHA_VopVcAchvtCnt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("vop_vc_achvment_get_count", 80);
					if(MAHHCPJIKHA_VopVcAchvtCnt != 0)
					{
						//LAB_00e712f4
						while(HLOHHJKCOIP.Count > 0)
						{
							List<string> strs = new List<string>();
							if(MAHHCPJIKHA_VopVcAchvtCnt < HLOHHJKCOIP.Count)
							{
								for(int i = 0; i < MAHHCPJIKHA_VopVcAchvtCnt; i++)
								{
									strs.Add(HLOHHJKCOIP[0]);
									HLOHHJKCOIP.RemoveAt(0);
								}
							}
							else
							{
								for(int i = 0; i < HLOHHJKCOIP.Count; i++)
								{
									strs.Add(HLOHHJKCOIP[i]);
								}
								HLOHHJKCOIP.Clear();
							}
							CLPMDJFKJBO.Clear();
							ICKPEPLDFOG.Clear();
							PLOOEECNHFB = false;
							NPNNPNAIONN_IsError = false;
							JGMEFHJCNHP_GetAchievementRecords req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new JGMEFHJCNHP_GetAchievementRecords());
							req.KMOBDLBKAAA_Repeatable = false;
							req.MIDAMHNABAJ_Keys = strs;
							CACGCMBKHDI_Request.HDHIKGLMOGF KDFFGLHBDLO = (CACGCMBKHDI_Request NHECPMNKEFK) =>
							{
								//0xE6F5F8
								JGMEFHJCNHP_GetAchievementRecords t = NHECPMNKEFK as JGMEFHJCNHP_GetAchievementRecords;
								List<PNFCNPCGKDM> AHOECALHPCP = t.NFEAMMJIMPG_Result.CEDLLCCONJP_achievement_prizes;
								for(int i = 0; i < AHOECALHPCP.Count; i++)
								{
									if(!AHOECALHPCP[i].OOIJCMLEAJP_is_received)
									{
										CLPMDJFKJBO.Add(AHOECALHPCP[i].LJNAKDMILMC_key);
										BADCBAILPID item = FCLLKLPHPMP.Find((BADCBAILPID JPAEDJJFFOI) =>
										{
											//0xE6FA1C
											return JPAEDJJFFOI.GCFBAJONKHA == AHOECALHPCP[i].LJNAKDMILMC_key;
										});
										if(item != null)
										{
											ICKPEPLDFOG.Add(item);
										}
									}
								}
								PLOOEECNHFB = true;
							};
							req.BHFHGFKBOHH_OnSuccess = KDFFGLHBDLO;
							CACGCMBKHDI_Request.HDHIKGLMOGF BAHANNNJCGC = (CACGCMBKHDI_Request NHECPMNKEFK) =>
							{
								//0xE6F9F8
								PLOOEECNHFB = true;
								NPNNPNAIONN_IsError = true;
							};
							req.MOBEEPPKFLG_OnFail = BAHANNNJCGC;
							//LAB_00e71020
							while (PLOOEECNHFB == false)
								yield return null;
							if(NPNNPNAIONN_IsError == false)
							{
								if(CLPMDJFKJBO.Count > 0)
								{
									PLOOEECNHFB = false;
									NPNNPNAIONN_IsError = false;
									FLONELKGABJ_ClaimAchievementPrizes req2 = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new FLONELKGABJ_ClaimAchievementPrizes());
									req2.KMOBDLBKAAA_Repeatable = false;
									req2.MIDAMHNABAJ_Keys = CLPMDJFKJBO;
									CACGCMBKHDI_Request.HDHIKGLMOGF CMJMGEFNBDK = (CACGCMBKHDI_Request NHECPMNKEFK) =>
									{
										//0xE6FA04
										PLOOEECNHFB = true;
									};
									req2.BHFHGFKBOHH_OnSuccess = CMJMGEFNBDK;
									CACGCMBKHDI_Request.HDHIKGLMOGF DMLJLPMBLCH = (CACGCMBKHDI_Request NHECPMNKEFK) =>
									{
										//0xE6FA10
										PLOOEECNHFB = true;
										NPNNPNAIONN_IsError = true;
									};
									req2.MOBEEPPKFLG_OnFail = DMLJLPMBLCH;
									while (PLOOEECNHFB == false)
										yield return null;
									if(NPNNPNAIONN_IsError)
									{
										if (_MOBEEPPKFLG_OnFail != null)
											_MOBEEPPKFLG_OnFail();
										yield break;
									}
									else
									{
										JKNGJFOBADP data2 = new JKNGJFOBADP();
										data2.JCHLONCMPAJ();
										for(int i = 0; i < ICKPEPLDFOG.Count; i++)
										{
											data2.OBCINIPHGGH = 0;
											data2.PJBJCBEMEEC = 0;
											data2.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.JMLJADADEEF_28/*28*/, ICKPEPLDFOG[i].FGHGMHPNEMG_Type.ToString() + ":" + ICKPEPLDFOG[i].MLDPDLPHJPM_OfferId.ToString());
											data2.CPIICACGNBH_AddItem(MNKKMKJMFDB_ServerSave, EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, 1), 5, null, 0);
										}
									}
								}
								// go LAB_00e712f4
							}
							else
							{
								if (_MOBEEPPKFLG_OnFail != null)
									_MOBEEPPKFLG_OnFail();
								yield break;
							}
						}
						MNKKMKJMFDB_ServerSave.DAEJHMCMFJD_Offer.KNIKMMKNOFA_ARcv = 3;
						if (BHFHGFKBOHH_OnSuccess != null)
							BHFHGFKBOHH_OnSuccess();
					}
				}
			}
		}
		else
		{
			if (_MOBEEPPKFLG_OnFail != null)
				_MOBEEPPKFLG_OnFail();
		}
	}
}
