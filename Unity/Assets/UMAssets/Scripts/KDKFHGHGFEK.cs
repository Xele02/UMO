
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

public class KDKFHGHGFEK
{
	public enum BAFEHAIGDOL
	{
		HJNNKCMLGFL_0_None = 0,
		FMLPIOFBCMA_1_Diva = 1,
		PFCFIMGGJJO = 2,
		GEENNEGMMCD = 3,
	}

	public enum MNBBLHKJBOJ
	{
		HJNNKCMLGFL_0_None = 0,
		FIHLMHDCFEO = 1,
		NFJPPHMCDBF = 2,
		OFBKNBLLFEM = 3,
		FDMBJAGLPLA = 4,
		KAONFJDOABE = 5,
		CAMKIILHPDE_6 = 6,
	}

	public enum AANBHFEEDGP
	{
		HJNNKCMLGFL_0_None = 0,
		HPPAGEALCLK = 1,
		FIHMIDDLAKH_1_CanonFillSp = 1,
		IOEGFJMNDBM_2_Medal = 2,
		JJNIMNEJPOF_3_Present = 3,
		OHKBCBLOHEF = 3,
	}
	
	private int[] NOHLPBMMHGE; // 0x64
	private int[] KGKGILMHPFN; // 0x68
	private static List<BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ> CIBDILHIBEG_PosterBef; // 0x0
	private static List<BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ> FFNENJELGIF_PosterAft; // 0x4
	private static List<BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ> KKIEEIGGJPK_ValkList; // 0x8
	private static List<BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ> JKNMNFKPEAA_CostumeList; // 0xC

	public int PPFNGGCBJKC_id { get; private set; } // 0x8 FDGEMCPHJCB_bgs DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category NPADACLCNAN_Category { get; private set; } // 0xC GAGLCECFOPM_bgs OOPDEPLJIJL_bgs OCMGDHJFELC_bgs
	public string OPFGFINHFCE_name { get; private set; } // 0x10 LGIIAPHCLPN_bgs DKJOHDGOIJE_get_name MJAMIGECMMF_set_name
	public string FEMMDNIELFC_Desc { get; private set; } // 0x14 GDKPKLJELJK_bgs JDHDMBHNKJD_get_Desc FNAJEJLLJOE_set_Desc
	public string DOIGLOBENMG_StampName { get; private set; } // 0x18 DEENOHGDMBK_bgs OFONPMEMOJB_bgs OGCPMJBBBLK_bgs
	public int FJFCNGNGIBN_Attribute { get; private set; } // 0x1C PKNMGMMCPPJ_bgs OCNDKILHCJK_get_Attribute NMEEPJEFADN_set_Attribute
	public SeriesAttr.Type CPKMLLNADLJ_Serie { get; private set; } // 0x20 COPJCMLLIMO_bgs BJPJMGHCDNO_get_Serie BPKIOJBKNBP_set_Serie
	public int FBFLDFMFFOH_rar { get; private set; } // 0x24 LMKEDCAPLEE_bgs HNLMNIOMOLI_get_rar CHHJKABBIBL_set_rar
	public int FLJPIHEEKOJ { get; private set; } // 0x28 BJNHJEMJOFB_bgs OBPAIHNNGDD_bgs GACABMLKLBP_bgs
	public int KGBAOKCMALD { get; private set; } // 0x2C KIHCOJIJICA_bgs FMOLFIOAFON_bgs CLHPGMPNHOF_bgs
	//NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC_SpType
	public int GBJFNGCDKPM_typ { get; private set; } // 0x30 GHLFADHILNN_bgs CEJJMKODOGK_get_typ HOHCEBMMACI_set_typ //Attribute
	public int FAKNMCIIAEM_IsAutoFlip { get; private set; } // 0x34 CLELCODBOBF_bgs CGDPJCABPDB_get_IsAutoFlip JJFPNFCDNIC_set_IsAutoFlip
	public int FNAKHNBAFGB { get; private set; } // 0x38 NJOIHAMCKHP_bgs IOBBDOKLIJD_bgs EDJPCMJJJCH_bgs
	public int FPCGPGJOKNH_CharaId { get; private set; } // 0x3C LEKPDGHPEJI_bgs ALFNIJMLAKF_bgs HGLMGFOOLGI_bgs
	public int EDEEMPJPFCP_OffsetX { get; private set; } // 0x40 NMNENMCBGOO_bgs LNELAEPIDOL_bgs FMPMDBENAGN_bgs
	public int HDHNEILDILJ_OffsetY { get; private set; } // 0x44 DIAPFECKENP_bgs MLECPDIKEPC_bgs LBGPIFGNOMF_bgs
	public int BHDHPCDLICO_Thickness { get; private set; } // 0x48 EMNLBCOMNPG_bgs AHKMMIGMMHJ_bgs CHFCMEBBCOG_bgs
	public int GJMHALIIPME_Type { get; private set; } // 0x4C EDGKPFBJAIN_bgs PJMOPGGDAEM_bgs FKLKNOBLCAK_bgs
	public bool GEMAFKNIKJN_IsOnShelf { get; private set; } // 0x50 JKPLAJNFKPC_bgs DKLPJBCLAHN_bgs NKIOCFFFHDF_bgs
	public int DBGAJBIBODC_FontType { get; private set; } // 0x54 JNBNBIGFFOM_bgs FFGNKPMHDIL_bgs GCCHDIOECNK_bgs
	public int EILKGEADKGH_Order { get; private set; } // 0x58 PBIPJHCABED_bgs NPDDACIHBKD_get_Order BJJMCKHBPNH_set_Order
	public int AKKLMEPIJBN { get; private set; } // 0x5C AJGDNHHDKEA_bgs FPGPCCBECCF_bgs PCPAHCAOGPN_bgs
	public int BAGLABPGMMK { get; private set; } // 0x60 BDJEDIKLJMN_bgs JKPECJGJPCL_bgs FPHMBIBHPHN_bgs
	public int BFINGCJHOHI_cnt { get; private set; } // 0x6C PIAHJAJPLKA_bgs LFMCLIDAPHB_get_cnt EDAEPDGGFJJ_set_cnt
	public bool CADENLBDAEB_IsNew { get; private set; } // 0x70 HMFLCAALEKM_bgs KJGFPPLHLAB_bgs ILJHLPMDHPO_bgs
	public bool FMGBBKHJDEC_CanKira { get; private set; } // 0x71 EOPNLNOMPAH_bgs FHPAOOLILMF_bgs HHEGCPCPHHF_bgs

	//// RVA: 0xE74A08 Offset: 0xE74A08 VA: 0xE74A08
	public int PPOJIMKEGMF(int _PPFNGGCBJKC_id)
	{
		if(_PPFNGGCBJKC_id > -1 && NOHLPBMMHGE != null)
		{
			if(NOHLPBMMHGE.Length <= _PPFNGGCBJKC_id)
				return 0;
			return NOHLPBMMHGE[_PPFNGGCBJKC_id];
		}
		return 0;
	}

	//// RVA: 0xE74A5C Offset: 0xE74A5C VA: 0xE74A5C
	public int NBGONKHPADA(int _PPFNGGCBJKC_id)
	{
		if(_PPFNGGCBJKC_id > -1 && KGKGILMHPFN != null)
		{
			if(KGKGILMHPFN.Length <= _PPFNGGCBJKC_id)
				return 0;
			return KGKGILMHPFN[_PPFNGGCBJKC_id];
		}
		return 0;
	}

	//// RVA: 0xE74AE0 Offset: 0xE74AE0 VA: 0xE74AE0
	public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category _NPADACLCNAN_Category)
	{
		LHPDDGIJKNB_Reset();
		if(_PPFNGGCBJKC_id < 1)
			return;
		if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database == null)
			return;
		if(CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData == null)
			return;
		OPFGFINHFCE_name = EKLNMHFCAOI_ItemManager.INCKKODFJAP_GetItemName(_NPADACLCNAN_Category, _PPFNGGCBJKC_id);
		FEMMDNIELFC_Desc = EKLNMHFCAOI_ItemManager.ILKGBGOCLAO_GetItemDesc(_NPADACLCNAN_Category, _PPFNGGCBJKC_id);
		EILKGEADKGH_Order = 0;
		FMGBBKHJDEC_CanKira = false;
		switch(_NPADACLCNAN_Category)
		{
			case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg:
			{
				if(_PPFNGGCBJKC_id < 1)
					return;
				if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GJLHEJPHEDA_ItemsBg.Count < _PPFNGGCBJKC_id)
					return;
				NDBFKHKMMCE_DecoItem.EHLEEEBJLAM_BgItem dbItem = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GJLHEJPHEDA_ItemsBg[_PPFNGGCBJKC_id - 1];
				if(dbItem.PLALNIIBLOF_en != 2)
					return;
				FJFCNGNGIBN_Attribute = dbItem.FJFCNGNGIBN_Attribute;
				CPKMLLNADLJ_Serie = (SeriesAttr.Type)dbItem.CPKMLLNADLJ_Serie;
				FLJPIHEEKOJ = dbItem.EKLIPGELKCL_Rarity;
				GJMHALIIPME_Type = 0;
				BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ saveItem = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.OMMNKDEODJP_DecoItem.DJHBDDGEKGO_Bgs.Find((BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ JPAEDJJFFOI) =>
				{
					//0xE7B6DC
					return _PPFNGGCBJKC_id == JPAEDJJFFOI.PPFNGGCBJKC_id;
				});
				if(saveItem != null)
					CADENLBDAEB_IsNew = saveItem.CADENLBDAEB_IsNew;
				break;
			}
			case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
			{
				if(_PPFNGGCBJKC_id < 1)
					return;
				if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GHOLIPLDMPJ_ItemsObj.Count < _PPFNGGCBJKC_id)
					return;
				NDBFKHKMMCE_DecoItem.NIBEBIGPKLA_ObjItem dbItem = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GHOLIPLDMPJ_ItemsObj[_PPFNGGCBJKC_id - 1];
				if(dbItem.PLALNIIBLOF_en != 2)
					return;
				FJFCNGNGIBN_Attribute = dbItem.FJFCNGNGIBN_Attribute;
				CPKMLLNADLJ_Serie = (SeriesAttr.Type)dbItem.CPKMLLNADLJ_Serie;
				FLJPIHEEKOJ = dbItem.EKLIPGELKCL_Rarity;
				GBJFNGCDKPM_typ = dbItem.GBJFNGCDKPM_typ;
				FAKNMCIIAEM_IsAutoFlip = dbItem.FAKNMCIIAEM_IsAutoFlip;
				EDEEMPJPFCP_OffsetX = dbItem.NGILPOOLBCF_OffsetX;
				HDHNEILDILJ_OffsetY = dbItem.JINEKNIBOFI_OffsetY;
				BHDHPCDLICO_Thickness = dbItem.BHDHPCDLICO_Thickness;
				GJMHALIIPME_Type = dbItem.GBJFNGCDKPM_typ;
				GEMAFKNIKJN_IsOnShelf = dbItem.CMMNFCJNIOO_IsOnShelf == 1;
				EILKGEADKGH_Order = dbItem.EILKGEADKGH_Order;
				BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ saveItem = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.OMMNKDEODJP_DecoItem.KPMFLNOELIN_Objs.Find((BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ JPAEDJJFFOI) =>
				{
					//0xE7B720
					return _PPFNGGCBJKC_id == JPAEDJJFFOI.PPFNGGCBJKC_id;
				});
				if(saveItem != null)
					CADENLBDAEB_IsNew = saveItem.CADENLBDAEB_IsNew;
				break;
			}
			case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
			{
				if(_PPFNGGCBJKC_id < 1)
					return;
				if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.KHCACDIKJLG_Characters.Count < _PPFNGGCBJKC_id)
					return;
				NDBFKHKMMCE_DecoItem.CCHHGIJMLBN_CharaItem dbItem = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.KHCACDIKJLG_Characters[_PPFNGGCBJKC_id - 1];
				if(dbItem.PLALNIIBLOF_en != 2)
					return;
				CPKMLLNADLJ_Serie = (SeriesAttr.Type)dbItem.CPKMLLNADLJ_Serie;
				FLJPIHEEKOJ = dbItem.EKLIPGELKCL_Rarity;
				GJMHALIIPME_Type = dbItem.CPKMLLNADLJ_Serie;
				GBJFNGCDKPM_typ = dbItem.GBJFNGCDKPM_typ;
				FPCGPGJOKNH_CharaId = dbItem.JBFLEDKDFCO_cid;
				BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ saveItem = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.OMMNKDEODJP_DecoItem.PEBDEIKBCCM_Chars.Find((BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ JPAEDJJFFOI) =>
				{
					//0xE7B7A8
					return _PPFNGGCBJKC_id == JPAEDJJFFOI.PPFNGGCBJKC_id;
				});
				if(saveItem != null)
					CADENLBDAEB_IsNew = saveItem.CADENLBDAEB_IsNew;
				break;
			}
			case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif:
			{
				if(_PPFNGGCBJKC_id < 1)
					return;
				if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif.Count < _PPFNGGCBJKC_id)
					return;
				IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP dbItem = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif[_PPFNGGCBJKC_id - 1];
				if(dbItem.PLALNIIBLOF_en != 2)
					return;
				CPKMLLNADLJ_Serie = (SeriesAttr.Type)dbItem.CPKMLLNADLJ_Serie;
				FLJPIHEEKOJ = dbItem.EKLIPGELKCL_Rarity;
				GBJFNGCDKPM_typ = dbItem.GBJFNGCDKPM_typ;
				FPCGPGJOKNH_CharaId = dbItem.JBFLEDKDFCO_cid;
				GJMHALIIPME_Type = dbItem.DMEDKJPOLCH_cat;
				DBGAJBIBODC_FontType = dbItem.LDLGLHBGOKE_FontSize;
				IOEKHJBOMDH_DecoStamp.GFPPDCEPLCM SItem = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.FJPOELGFPBP_DecoStamp.DMKMNGELNAE_Serif.Find((IOEKHJBOMDH_DecoStamp.GFPPDCEPLCM JPAEDJJFFOI) =>
				{
					//0xE7B7EC
					return _PPFNGGCBJKC_id == JPAEDJJFFOI.PPFNGGCBJKC_id;
				});
				if(SItem != null)
				{
					CADENLBDAEB_IsNew = SItem.CADENLBDAEB_IsNew;
				}
				DOIGLOBENMG_StampName = NCPPAHHCCAO.GHHOBKGGADG(_PPFNGGCBJKC_id);
				break;
			}
			case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp:
			{
				if(_PPFNGGCBJKC_id < 1)
					return;
				if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp.Count < _PPFNGGCBJKC_id)
					return;
				NDBFKHKMMCE_DecoItem.FIDBAFHNGCF dbItem = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[_PPFNGGCBJKC_id - 1];
				if(dbItem.PLALNIIBLOF_en != 2)
					return;
				FJFCNGNGIBN_Attribute = dbItem.FJFCNGNGIBN_Attribute;
				CPKMLLNADLJ_Serie = (SeriesAttr.Type)dbItem.CPKMLLNADLJ_Serie;
				FLJPIHEEKOJ = dbItem.EKLIPGELKCL_Rarity;
				GBJFNGCDKPM_typ = dbItem.GBJFNGCDKPM_typ;
				FAKNMCIIAEM_IsAutoFlip = dbItem.FAKNMCIIAEM_IsAutoFlip;
				EDEEMPJPFCP_OffsetX = dbItem.NGILPOOLBCF_OffsetX;
				HDHNEILDILJ_OffsetY = dbItem.JINEKNIBOFI_OffsetY;
				BHDHPCDLICO_Thickness = dbItem.BHDHPCDLICO_Thickness;
				GJMHALIIPME_Type = dbItem.DMEDKJPOLCH_cat;
				GEMAFKNIKJN_IsOnShelf = dbItem.CMMNFCJNIOO_IsOnShelf == 1;
				FNAKHNBAFGB = dbItem.KIJAPOFAGPN_ItemId;
				if(EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(FNAKHNBAFGB) == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal)
				{
					int id2 = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(FNAKHNBAFGB);
					if(id2 == 0)
					{
						FNAKHNBAFGB = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.DNEKJCKEOHL_GetMonthlyItemFullId(NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
					}
				}
				if(GBJFNGCDKPM_typ == 12)
				{
					if(dbItem.ADECCOKCCDH > 0)
					{
						if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.ONODAPNHMPB.Count >= dbItem.ADECCOKCCDH)
						{
							NDBFKHKMMCE_DecoItem.PELPLGBMOII d = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.ONODAPNHMPB[dbItem.ADECCOKCCDH - 1];
							BAGLABPGMMK = d.AGHJAAMABPI;
							NOHLPBMMHGE = GDMGBCFMBPH(ref d.IPGHEIAFCHE);
							KGKGILMHPFN = GDMGBCFMBPH(ref d.MILFOEODPDK);
						}
					}
				}
				BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ saveItem = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp.Find((BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL JPAEDJJFFOI) =>
				{
					//0xE7B764
					return _PPFNGGCBJKC_id == JPAEDJJFFOI.PPFNGGCBJKC_id;
				});
				if(saveItem != null)
					CADENLBDAEB_IsNew = saveItem.CADENLBDAEB_IsNew;
				break;
			}
			default:
				break;
			case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
			{
				if(_PPFNGGCBJKC_id < 1)
					return;
				if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.COLIEKINOPB_ItemsPoster.Count < _PPFNGGCBJKC_id)
					return;
				NDBFKHKMMCE_DecoItem.IEOEMNPLANK_PosterItem dbItem = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.COLIEKINOPB_ItemsPoster[_PPFNGGCBJKC_id - 1];
				if(dbItem.PLALNIIBLOF_en != 2)
					return;
				FJFCNGNGIBN_Attribute = 3;
				CPKMLLNADLJ_Serie = (SeriesAttr.Type)dbItem.CPKMLLNADLJ_Serie;
				FLJPIHEEKOJ = dbItem.EKLIPGELKCL_Rarity;
				GJMHALIIPME_Type = 99;
				BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ saveItem = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.OMMNKDEODJP_DecoItem.PFNNIMBMKDL_Posters.Find((BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ JPAEDJJFFOI) =>
				{
					//0xE7B830
					return _PPFNGGCBJKC_id == JPAEDJJFFOI.PPFNGGCBJKC_id;
				});
				if(saveItem != null)
					CADENLBDAEB_IsNew = saveItem.CADENLBDAEB_IsNew;
				break;
			}
			case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef:
			case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft:
			{
				if(_PPFNGGCBJKC_id < 1)
					return;
				if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table.Count < _PPFNGGCBJKC_id)
					return;
				MMPBPOIFDAF_Scene.PMKOFEIONEG sIte = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[_PPFNGGCBJKC_id - 1];
				FJFCNGNGIBN_Attribute = 3;
				MLIBEPGADJH_Scene.KKLDOOJBJMN dbItem = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1];
				CPKMLLNADLJ_Serie = dbItem.AIHCEGFANAM_SerieAttr;
				FLJPIHEEKOJ = dbItem.EKLIPGELKCL_Rarity;
				GJMHALIIPME_Type = 99;
				CADENLBDAEB_IsNew = sIte.JECJALJEDPP(_NPADACLCNAN_Category == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft ? 1 : 0);
				if(_NPADACLCNAN_Category == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft)
				{
					FMGBBKHJDEC_CanKira = 0 < IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.ELKHCOEMNOJ_IsKira(_PPFNGGCBJKC_id, sIte.DMNIMMGGJJJ_Leaf, IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver);
				}
				break;
			}
			case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure:
			{
				if(_PPFNGGCBJKC_id < 1)
					return;
				if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_table.Count < _PPFNGGCBJKC_id)
					return;
				JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo dbItem = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1];
				CPKMLLNADLJ_Serie = (SeriesAttr.Type)dbItem.AIHCEGFANAM_SerieAttr;
				FJFCNGNGIBN_Attribute = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA_GetIntParam("attr_vffigure", 12);
				FLJPIHEEKOJ = 1;
				GBJFNGCDKPM_typ = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA_GetIntParam("typ_vffigure", 3);
				GJMHALIIPME_Type = GBJFNGCDKPM_typ;
				EDEEMPJPFCP_OffsetX = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA_GetIntParam("offset_x_vffigure", 0);
				HDHNEILDILJ_OffsetY = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA_GetIntParam("offset_y_vffigure", 0);
				BHDHPCDLICO_Thickness = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA_GetIntParam("thickness_vffigure", 20);
				OIGEIIGKMNH_Valkyrie.HLNPGNNPCGO_ValkyrieInfo sIt = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.JJFFBDLIOCF_Valkyrie.CNGNBKNBKGI_ValkList[_PPFNGGCBJKC_id - 1];
				CADENLBDAEB_IsNew = sIt.FJKIELICMAH_DvfNew;
				break;
			}
			case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso:
			{
				if(_PPFNGGCBJKC_id < 1)
					return;
				if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_table.Count < _PPFNGGCBJKC_id)
					return;
				LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo dbItem = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1];
				CPKMLLNADLJ_Serie = (SeriesAttr.Type)IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.GCINIJEMHFK_Get(dbItem.AHHJLDLAPAN_DivaId).AIHCEGFANAM_SerieAttr;
				FJFCNGNGIBN_Attribute = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA_GetIntParam("attr_costume_torso", 12);
				FLJPIHEEKOJ = 1;
				GBJFNGCDKPM_typ = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA_GetIntParam("typ_costume_torso", 3);
				GJMHALIIPME_Type = GBJFNGCDKPM_typ;
				EDEEMPJPFCP_OffsetX = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA_GetIntParam("offset_x_costume_torso", 0);
				HDHNEILDILJ_OffsetY = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA_GetIntParam("offset_y_costume_torso", 0);
				BHDHPCDLICO_Thickness = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA_GetIntParam("thickness_costume_torso", 20);
				EBFLJMOCLNA_Costume.ILFJDCICIKN sIt = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.BEKHNNCGIEL_Costume.FABAGMLEKIB_CostumeList[_PPFNGGCBJKC_id - 1];
				CADENLBDAEB_IsNew = sIt.GPOJCDOEDFD(0);
				break;
			}
		}
		NPADACLCNAN_Category = _NPADACLCNAN_Category;
		PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
		int itemId = 0;
		if(_NPADACLCNAN_Category != 0)
		{
			itemId = EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(_NPADACLCNAN_Category, _PPFNGGCBJKC_id);
		}
		KGBAOKCMALD = itemId;
		FBFLDFMFFOH_rar = EKLNMHFCAOI_ItemManager.FABCKNDLPDH_GetItemRarity(_NPADACLCNAN_Category, _PPFNGGCBJKC_id);
		BFINGCJHOHI_cnt = EKLNMHFCAOI_ItemManager.ALHCGDMEMID_GetNumItems(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, _NPADACLCNAN_Category, _PPFNGGCBJKC_id, null);
		AKKLMEPIJBN = DOEMNGNEILE(_NPADACLCNAN_Category);
	}

	//// RVA: 0xE76BE4 Offset: 0xE76BE4 VA: 0xE76BE4
	public void LHPDDGIJKNB_Reset()
	{
		PPFNGGCBJKC_id = 0;
		FPCGPGJOKNH_CharaId = 0;
		EDEEMPJPFCP_OffsetX = 0;
		HDHNEILDILJ_OffsetY = 0;
		BHDHPCDLICO_Thickness = 0;
		KGBAOKCMALD = 0;
		GBJFNGCDKPM_typ = 0;
		FAKNMCIIAEM_IsAutoFlip = 0;
		FNAKHNBAFGB = 0;
		FJFCNGNGIBN_Attribute = 0;
		CPKMLLNADLJ_Serie = 0;
		FBFLDFMFFOH_rar = 0;
		FLJPIHEEKOJ = 0;
		AKKLMEPIJBN = 0;
		BAGLABPGMMK = 0;
		NOHLPBMMHGE = null;
		KGKGILMHPFN = null;
		OPFGFINHFCE_name = "";
		FEMMDNIELFC_Desc = "";
		DOIGLOBENMG_StampName = "";
		NPADACLCNAN_Category = 0;
		DBGAJBIBODC_FontType = 0;
		GJMHALIIPME_Type = 0;
		GEMAFKNIKJN_IsOnShelf = false;
		BHDHPCDLICO_Thickness = 0;
		GJMHALIIPME_Type = 0;
		BFINGCJHOHI_cnt = 0;
		CADENLBDAEB_IsNew = false;
		FMGBBKHJDEC_CanKira = false;
	}

	//// RVA: 0xE76E6C Offset: 0xE76E6C VA: 0xE76E6C
	public void ODDIHGPONFL_Copy(KDKFHGHGFEK GPBJHKLFCEP)
	{
		PPFNGGCBJKC_id = GPBJHKLFCEP.PPFNGGCBJKC_id;
		OPFGFINHFCE_name = GPBJHKLFCEP.OPFGFINHFCE_name;
		FEMMDNIELFC_Desc = GPBJHKLFCEP.FEMMDNIELFC_Desc;
		DOIGLOBENMG_StampName = GPBJHKLFCEP.DOIGLOBENMG_StampName;
		NPADACLCNAN_Category = GPBJHKLFCEP.NPADACLCNAN_Category;
		FJFCNGNGIBN_Attribute = GPBJHKLFCEP.FJFCNGNGIBN_Attribute;
		CPKMLLNADLJ_Serie = GPBJHKLFCEP.CPKMLLNADLJ_Serie;
		FBFLDFMFFOH_rar = GPBJHKLFCEP.FBFLDFMFFOH_rar;
		FLJPIHEEKOJ = GPBJHKLFCEP.FLJPIHEEKOJ;
		KGBAOKCMALD = GPBJHKLFCEP.KGBAOKCMALD;
		GBJFNGCDKPM_typ = GPBJHKLFCEP.GBJFNGCDKPM_typ;
		BFINGCJHOHI_cnt = GPBJHKLFCEP.BFINGCJHOHI_cnt;
		FAKNMCIIAEM_IsAutoFlip = GPBJHKLFCEP.FAKNMCIIAEM_IsAutoFlip;
		FNAKHNBAFGB = GPBJHKLFCEP.FNAKHNBAFGB;
		FPCGPGJOKNH_CharaId = GPBJHKLFCEP.FPCGPGJOKNH_CharaId;
		EDEEMPJPFCP_OffsetX = GPBJHKLFCEP.EDEEMPJPFCP_OffsetX;
		HDHNEILDILJ_OffsetY = GPBJHKLFCEP.HDHNEILDILJ_OffsetY;
		BHDHPCDLICO_Thickness = GPBJHKLFCEP.BHDHPCDLICO_Thickness;
		GJMHALIIPME_Type = GPBJHKLFCEP.GJMHALIIPME_Type;
		GEMAFKNIKJN_IsOnShelf = GPBJHKLFCEP.GEMAFKNIKJN_IsOnShelf;
		DBGAJBIBODC_FontType = GPBJHKLFCEP.DBGAJBIBODC_FontType;
		AKKLMEPIJBN = GPBJHKLFCEP.AKKLMEPIJBN;
		CADENLBDAEB_IsNew = GPBJHKLFCEP.CADENLBDAEB_IsNew;
		BAGLABPGMMK = GPBJHKLFCEP.BAGLABPGMMK;
		if(GPBJHKLFCEP.NOHLPBMMHGE != null)
			NOHLPBMMHGE = GPBJHKLFCEP.NOHLPBMMHGE.Clone() as int[];
		if(GPBJHKLFCEP.KGKGILMHPFN != null)
			KGKGILMHPFN = GPBJHKLFCEP.KGKGILMHPFN.Clone() as int[];
	}

	//// RVA: 0xE772C8 Offset: 0xE772C8 VA: 0xE772C8
	public bool OHAMGNMKOII()
	{
		if(NPADACLCNAN_Category >= EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster && NPADACLCNAN_Category <= EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft)
			return FLJPIHEEKOJ > 5;
		return false;
	}

	//// RVA: 0xE772F4 Offset: 0xE772F4 VA: 0xE772F4
	public static List<KDKFHGHGFEK> FKDIMODKKJD_GetList()
	{
		List<KDKFHGHGFEK> res = new List<KDKFHGHGFEK>();
		FKDIMODKKJD_GetList(ref res);
		return res; 
	}

	//// RVA: 0xE773B0 Offset: 0xE773B0 VA: 0xE773B0
	public static void FKDIMODKKJD_GetList(ref List<KDKFHGHGFEK> NNDGIAEFMOG)
	{
		NNDGIAEFMOG.Clear();
		FKDIMODKKJD_GetList(NDBFKHKMMCE_DecoItem.ANMODBDBNPK.DBAMIACJODJ_ItemCat.PMJFENNOEJD_1_Bg, ref NNDGIAEFMOG);
		FKDIMODKKJD_GetList(NDBFKHKMMCE_DecoItem.ANMODBDBNPK.DBAMIACJODJ_ItemCat.JKMLKAMHJIF_2_Obj, ref NNDGIAEFMOG);
		FKDIMODKKJD_GetList(NDBFKHKMMCE_DecoItem.ANMODBDBNPK.DBAMIACJODJ_ItemCat.MIIELMELDBO_3_Char, ref NNDGIAEFMOG);
		FKDIMODKKJD_GetList(NDBFKHKMMCE_DecoItem.ANMODBDBNPK.DBAMIACJODJ_ItemCat.BKLKNLDCJIO_4_Stamp, ref NNDGIAEFMOG);
		FKDIMODKKJD_GetList(NDBFKHKMMCE_DecoItem.ANMODBDBNPK.DBAMIACJODJ_ItemCat.AAAOOKJAMGE_5_Sp, ref NNDGIAEFMOG);
	}

	//// RVA: 0xE78E64 Offset: 0xE78E64 VA: 0xE78E64
	public static bool JBLGOGMHCFP_UpdatePosterCache()
	{
		bool res = false;
		if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database != null && CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData != null)
		{
			if(CIBDILHIBEG_PosterBef == null)
				CIBDILHIBEG_PosterBef = new List<BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ>();
			CIBDILHIBEG_PosterBef.Clear();
			if(FFNENJELGIF_PosterAft == null)
				FFNENJELGIF_PosterAft = new List<BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ>();
			FFNENJELGIF_PosterAft.Clear();
			for(int i = 0; i < CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes.Count; i++)
			{
				int cnt = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.PNLOINMCCKH_Scene.HOLEDOLMJCB(i + 1, IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene, 0);
				int cnt2 = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.PNLOINMCCKH_Scene.HOLEDOLMJCB(i + 1, IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene, 1);
				if(cnt > 0)
				{
					BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ data = new BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ();
					data.PPFNGGCBJKC_id = i + 1;
					data.BFINGCJHOHI_cnt = cnt;
					CIBDILHIBEG_PosterBef.Add(data);
					res = true;
				}
				if(cnt2 > 0)
				{
					BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ data = new BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ();
					data.PPFNGGCBJKC_id = i + 1;
					data.BFINGCJHOHI_cnt = cnt2;
					FFNENJELGIF_PosterAft.Add(data);
					res = true;
				}
			}
		}
		return res;
	}

	//// RVA: 0xE794B0 Offset: 0xE794B0 VA: 0xE794B0
	public static bool CEMDACGFKFP_UpdateValkCache()
	{
		bool res = false;
		if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database != null && CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData != null)
		{
			if(KKIEEIGGJPK_ValkList == null)
			{
				KKIEEIGGJPK_ValkList = new List<BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ>();
			}
			KKIEEIGGJPK_ValkList.Clear();
			for(int i = 0; i < CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.JJFFBDLIOCF_Valkyrie.CNGNBKNBKGI_ValkList.Count; i++)
			{
				int cnt = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.JJFFBDLIOCF_Valkyrie.NBFPEPBFEHI(i + 1, IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie);
				if(cnt > 0)
				{
					BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ data = new BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ();
					data.PPFNGGCBJKC_id = i + 1;
					data.BFINGCJHOHI_cnt = cnt;
					KKIEEIGGJPK_ValkList.Add(data);
					res = true;
				}
            }
		}
		return res;
	}

	//// RVA: 0xE79890 Offset: 0xE79890 VA: 0xE79890
	public static bool EOACAIMCBCG_UpdateCostumeCache()
	{
		bool res = false;
		if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database != null && CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData != null)
		{
			if(JKNMNFKPEAA_CostumeList == null)
				JKNMNFKPEAA_CostumeList = new List<BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ>();
			JKNMNFKPEAA_CostumeList.Clear();
			for(int i = 0; i < CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.BEKHNNCGIEL_Costume.FABAGMLEKIB_CostumeList.Count; i++)
			{
				int cnt = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.BEKHNNCGIEL_Costume.LMLGEDEJCJO(i + 1, IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume, true);
				if(cnt > 0)
				{
					BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ data = new BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ();
					data.PPFNGGCBJKC_id = i + 1;
					data.BFINGCJHOHI_cnt = cnt;
					JKNMNFKPEAA_CostumeList.Add(data);
					res = true;
				}
			}
		}
		return res;
	}

	//// RVA: 0xE79C80 Offset: 0xE79C80 VA: 0xE79C80
	public static List<KDKFHGHGFEK> FKDIMODKKJD_GetList(NDBFKHKMMCE_DecoItem.ANMODBDBNPK.DBAMIACJODJ_ItemCat _NPADACLCNAN_Category)
	{
		List<KDKFHGHGFEK> res = new List<KDKFHGHGFEK>();
		FKDIMODKKJD_GetList(_NPADACLCNAN_Category, ref res);
		return res;
	}

	//// RVA: 0xE77490 Offset: 0xE77490 VA: 0xE77490
	public static void FKDIMODKKJD_GetList(NDBFKHKMMCE_DecoItem.ANMODBDBNPK.DBAMIACJODJ_ItemCat _NPADACLCNAN_Category, ref List<KDKFHGHGFEK> NNDGIAEFMOG)
	{
		if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database != null && CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData != null)
		{
			switch(_NPADACLCNAN_Category)
			{
				case NDBFKHKMMCE_DecoItem.ANMODBDBNPK.DBAMIACJODJ_ItemCat.PMJFENNOEJD_1_Bg:
					for(int i = 0; i < CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.OMMNKDEODJP_DecoItem.DJHBDDGEKGO_Bgs.Count; i++)
					{
                        BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ it = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.OMMNKDEODJP_DecoItem.DJHBDDGEKGO_Bgs[i];
						if(it.BFINGCJHOHI_cnt > 0)
						{
							KDKFHGHGFEK data = new KDKFHGHGFEK();
							data.KHEKNNFCAOI_Init(it.PPFNGGCBJKC_id, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg);
							if(data.PPFNGGCBJKC_id > 0)
							{
								NNDGIAEFMOG.Add(data);
							}
						}
                    }
					break;
				case NDBFKHKMMCE_DecoItem.ANMODBDBNPK.DBAMIACJODJ_ItemCat.JKMLKAMHJIF_2_Obj:
					for(int i = 0; i < CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.OMMNKDEODJP_DecoItem.KPMFLNOELIN_Objs.Count; i++)
					{
                        BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ it = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.OMMNKDEODJP_DecoItem.KPMFLNOELIN_Objs[i];
						if(it.BFINGCJHOHI_cnt > 0)
						{
							KDKFHGHGFEK data = new KDKFHGHGFEK();
							data.KHEKNNFCAOI_Init(it.PPFNGGCBJKC_id, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj);
							if(data.PPFNGGCBJKC_id > 0)
							{
								NNDGIAEFMOG.Add(data);
							}
						}
					}
					for(int i = 0; i < CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.OMMNKDEODJP_DecoItem.PFNNIMBMKDL_Posters.Count; i++)
					{
                        BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ it = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.OMMNKDEODJP_DecoItem.PFNNIMBMKDL_Posters[i];
						if(it.BFINGCJHOHI_cnt > 0)
						{
							KDKFHGHGFEK data = new KDKFHGHGFEK();
							data.KHEKNNFCAOI_Init(it.PPFNGGCBJKC_id, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster);
							if(data.PPFNGGCBJKC_id > 0)
							{
								NNDGIAEFMOG.Add(data);
							}
						}
					}
					List<KDKFHGHGFEK> l = new List<KDKFHGHGFEK>();
					l.Clear();
					CEMDACGFKFP_UpdateValkCache();
					for(int i = 0; i < KKIEEIGGJPK_ValkList.Count; i++)
					{
						if(KKIEEIGGJPK_ValkList[i].BFINGCJHOHI_cnt > 0)
						{
							KDKFHGHGFEK data = new KDKFHGHGFEK();
							data.KHEKNNFCAOI_Init(KKIEEIGGJPK_ValkList[i].PPFNGGCBJKC_id, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure);
							if(data.PPFNGGCBJKC_id > 0)
							{
								l.Add(data);
							}
						}
					}
					NNDGIAEFMOG.AddRange(l);
					List<KDKFHGHGFEK> l2 = new List<KDKFHGHGFEK>();
					l2.Clear();
					EOACAIMCBCG_UpdateCostumeCache();
					for(int i = 0; i < JKNMNFKPEAA_CostumeList.Count; i++)
					{
						if(JKNMNFKPEAA_CostumeList[i].BFINGCJHOHI_cnt > 0)
						{
							KDKFHGHGFEK data = new KDKFHGHGFEK();
							data.KHEKNNFCAOI_Init(JKNMNFKPEAA_CostumeList[i].PPFNGGCBJKC_id, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso);
							if(data.PPFNGGCBJKC_id > 0)
							{
                                LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo dbCos = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_table[data.PPFNGGCBJKC_id - 1];
								data.EILKGEADKGH_Order = data.PPFNGGCBJKC_id * 10 + dbCos.AHHJLDLAPAN_DivaId * 100000;
                                l2.Add(data);
							}
						}
					}
					NNDGIAEFMOG.AddRange(l2);
					l2 = new List<KDKFHGHGFEK>();
					l2.Clear();
					JBLGOGMHCFP_UpdatePosterCache();
					for(int i = 0; i < CIBDILHIBEG_PosterBef.Count; i++)
					{
						if(CIBDILHIBEG_PosterBef[i].BFINGCJHOHI_cnt > 0)
						{
							KDKFHGHGFEK data = new KDKFHGHGFEK();
							data.KHEKNNFCAOI_Init(CIBDILHIBEG_PosterBef[i].PPFNGGCBJKC_id, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef);
							if(data.PPFNGGCBJKC_id > 0)
							{
								l2.Add(data);
							}
						}
					}
					for(int i = 0; i < FFNENJELGIF_PosterAft.Count; i++)
					{
						if(FFNENJELGIF_PosterAft[i].BFINGCJHOHI_cnt > 0)
						{
							KDKFHGHGFEK data = new KDKFHGHGFEK();
							data.KHEKNNFCAOI_Init(FFNENJELGIF_PosterAft[i].PPFNGGCBJKC_id, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft);
							if(data.PPFNGGCBJKC_id > 0)
							{
								l2.Add(data);
							}
						}
					}
					l2.Sort((KDKFHGHGFEK _HKICMNAACDA_a, KDKFHGHGFEK _BNKHBCBJBKI_b) =>
					{
						//0xE7B598
						int res = _HKICMNAACDA_a.PPFNGGCBJKC_id.CompareTo(_BNKHBCBJBKI_b.PPFNGGCBJKC_id);
						if(res == 0)
						{
							res = ((int)_HKICMNAACDA_a.NPADACLCNAN_Category).CompareTo((int)_BNKHBCBJBKI_b.NPADACLCNAN_Category);
						}
						return res;
					});
					NNDGIAEFMOG.AddRange(l2);
					return;
				case NDBFKHKMMCE_DecoItem.ANMODBDBNPK.DBAMIACJODJ_ItemCat.MIIELMELDBO_3_Char:
					for(int i = 0; i < CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.OMMNKDEODJP_DecoItem.PEBDEIKBCCM_Chars.Count; i++)
					{
                        BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ it = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.OMMNKDEODJP_DecoItem.PEBDEIKBCCM_Chars[i];
						if(it.BFINGCJHOHI_cnt > 0)
						{
							KDKFHGHGFEK data = new KDKFHGHGFEK();
							data.KHEKNNFCAOI_Init(it.PPFNGGCBJKC_id, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara);
							if(data.PPFNGGCBJKC_id > 0)
							{
								NNDGIAEFMOG.Add(data);
							}
						}
                    }
					break;
				case NDBFKHKMMCE_DecoItem.ANMODBDBNPK.DBAMIACJODJ_ItemCat.BKLKNLDCJIO_4_Stamp:
					for(int i = 0; i < CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.FJPOELGFPBP_DecoStamp.DMKMNGELNAE_Serif.Count; i++)
					{
                        IOEKHJBOMDH_DecoStamp.GFPPDCEPLCM it = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.FJPOELGFPBP_DecoStamp.DMKMNGELNAE_Serif[i];
                        if (it.BFINGCJHOHI_cnt > 0)
						{
							KDKFHGHGFEK data = new KDKFHGHGFEK();
							data.KHEKNNFCAOI_Init(it.PPFNGGCBJKC_id, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif);
							if(data.PPFNGGCBJKC_id > 0)
							{
								NNDGIAEFMOG.Add(data);
							}
						}
                    }
					break;
				case NDBFKHKMMCE_DecoItem.ANMODBDBNPK.DBAMIACJODJ_ItemCat.AAAOOKJAMGE_5_Sp:
					for(int i = 0; i < CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp.Count; i++)
					{
                        BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ it = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp[i];
						if(it.BFINGCJHOHI_cnt > 0)
						{
							KDKFHGHGFEK data = new KDKFHGHGFEK();
							data.KHEKNNFCAOI_Init(it.PPFNGGCBJKC_id, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp);
							if(data.PPFNGGCBJKC_id > 0)
							{
								NNDGIAEFMOG.Add(data);
							}
						}
                    }
					break;
			}
		}
	}

	//// RVA: 0xE79D4C Offset: 0xE79D4C VA: 0xE79D4C
	public static bool ALBPEEPPNOI(int _KIJAPOFAGPN_ItemId)
	{
		int itemId = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(_KIJAPOFAGPN_ItemId);
		int a = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[itemId - 1].GBJFNGCDKPM_typ;
		return a > 0 && a - 1 < 3;
	}

	//// RVA: 0xE79EC0 Offset: 0xE79EC0 VA: 0xE79EC0
	public static bool HANJGFKOGGO(int _KIJAPOFAGPN_ItemId)
	{
		EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category cat = EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(_KIJAPOFAGPN_ItemId);
		int id = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(_KIJAPOFAGPN_ItemId);
		if (cat != EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp)
			return false;
		return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[id - 1].GBJFNGCDKPM_typ > 0 && IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[id - 1].GBJFNGCDKPM_typ - 1 < 3;
	}

	//// RVA: 0xE7A04C Offset: 0xE7A04C VA: 0xE7A04C
	public static bool HMAOJBKJIOJ(int _KIJAPOFAGPN_ItemId, int _DMBFOMLCGBG_Level, int OMMKKNPGNPH)
	{
		if(ALBPEEPPNOI(_KIJAPOFAGPN_ItemId))
		{
			if(!KKDMFKGMHLD(_DMBFOMLCGBG_Level))
			{
				int itemId = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(_KIJAPOFAGPN_ItemId);
				BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL s = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp[itemId - 1];
				NDBFKHKMMCE_DecoItem.FIDBAFHNGCF db = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[itemId - 1];
				List<NEGELNMPEPH_DecoSpSetting.DAGLEHBMBLF> l = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.BGKKOOGPEFD_DecoSpSetting.ILCGCPIGAFP[_DMBFOMLCGBG_Level];
				if(OMMKKNPGNPH >= l[db.GBJFNGCDKPM_typ - 1].BCGKLONODHO)
					return true;
			}
		}
		return false;
	}

	//// RVA: 0xE7A520 Offset: 0xE7A520 VA: 0xE7A520
	public static int DFMGMEDILKB(int _KIJAPOFAGPN_ItemId)
	{
		return CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp[EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(_KIJAPOFAGPN_ItemId) - 1].ANAJIAENLNB_lv;
	}

	//// RVA: 0xE7A410 Offset: 0xE7A410 VA: 0xE7A410
	public static bool KKDMFKGMHLD(int _DMBFOMLCGBG_Level)
	{
		return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.BGKKOOGPEFD_DecoSpSetting.ILCGCPIGAFP.Count <= _DMBFOMLCGBG_Level;
	}

	//// RVA: 0xE7A68C Offset: 0xE7A68C VA: 0xE7A68C
	public static bool HMDOAKPBLFL_HasItemsReady(int _KIJAPOFAGPN_ItemId, int _DMBFOMLCGBG_Level, long _JHNMKKNEENE_Time)
	{
		return IOKFJAIDMLD_GetNumItemsReady(_KIJAPOFAGPN_ItemId, _DMBFOMLCGBG_Level, _JHNMKKNEENE_Time) > 0;
	}

	//// RVA: 0xE7A73C Offset: 0xE7A73C VA: 0xE7A73C
	public static int IOKFJAIDMLD_GetNumItemsReady(int _KIJAPOFAGPN_ItemId, int _DMBFOMLCGBG_Level, long _JHNMKKNEENE_Time)
	{
		int itemId = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(_KIJAPOFAGPN_ItemId);
		BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL s = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp[itemId - 1];
		List<NEGELNMPEPH_DecoSpSetting.DAGLEHBMBLF> l = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.BGKKOOGPEFD_DecoSpSetting.ILCGCPIGAFP[_DMBFOMLCGBG_Level - 1];
		NDBFKHKMMCE_DecoItem.FIDBAFHNGCF db = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[itemId - 1];
		return Mathf.Min((int)((s.EMHCHMHMFHJ_ChargeTimeOffset + (_JHNMKKNEENE_Time - s.FOONCJDLLIK_ChargeTime)) / GGEGLPOMJCK_TimeByUnit(_KIJAPOFAGPN_ItemId, _DMBFOMLCGBG_Level)), l[db.GBJFNGCDKPM_typ - 1].NANNGLGOFKH_value);
	}

	//// RVA: 0xE7ADE4 Offset: 0xE7ADE4 VA: 0xE7ADE4
	public static long CFNHNIMKPCI_GetChargeTimeOffset(BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL _BBFIGEOBOMB_SpItem, long _JHNMKKNEENE_Time)
	{
		int id = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(_BBFIGEOBOMB_SpItem.PPFNGGCBJKC_id);
		NDBFKHKMMCE_DecoItem.FIDBAFHNGCF dbItem = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[id - 1];
		List<NEGELNMPEPH_DecoSpSetting.DAGLEHBMBLF> l = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.BGKKOOGPEFD_DecoSpSetting.ILCGCPIGAFP[_BBFIGEOBOMB_SpItem.ANAJIAENLNB_lv - 1];
		NEGELNMPEPH_DecoSpSetting.DAGLEHBMBLF data = l[dbItem.GBJFNGCDKPM_typ - 1];
		long t = _BBFIGEOBOMB_SpItem.EMHCHMHMFHJ_ChargeTimeOffset + _JHNMKKNEENE_Time - _BBFIGEOBOMB_SpItem.FOONCJDLLIK_ChargeTime;
		long res = 0;
		if(t < data.KPBJHHHMOJE_Time * 60)
		{
			long t2 = t - GGEGLPOMJCK_TimeByUnit(_BBFIGEOBOMB_SpItem.PPFNGGCBJKC_id, _BBFIGEOBOMB_SpItem.ANAJIAENLNB_lv) * IOKFJAIDMLD_GetNumItemsReady(_BBFIGEOBOMB_SpItem.PPFNGGCBJKC_id, _BBFIGEOBOMB_SpItem.ANAJIAENLNB_lv, _JHNMKKNEENE_Time);
			if(t2 != 0)
				res = t2;
		}
		return res;
	}

	//// RVA: 0xE7AB60 Offset: 0xE7AB60 VA: 0xE7AB60
	public static long GGEGLPOMJCK_TimeByUnit(int _KIJAPOFAGPN_ItemId, int _CIEOBFIIPLD_Level)
	{
		int itemId = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(_KIJAPOFAGPN_ItemId);
		NDBFKHKMMCE_DecoItem.FIDBAFHNGCF db = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[itemId - 1];
		List<NEGELNMPEPH_DecoSpSetting.DAGLEHBMBLF> l = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.BGKKOOGPEFD_DecoSpSetting.ILCGCPIGAFP[_CIEOBFIIPLD_Level - 1];
		return (l[db.GBJFNGCDKPM_typ - 1].KPBJHHHMOJE_Time * 60) / l[db.GBJFNGCDKPM_typ - 1].NANNGLGOFKH_value;
	}

	//// RVA: 0xE7B21C Offset: 0xE7B21C VA: 0xE7B21C
	//public List<int> FGEADBNLMDB(List<int> _LJNPPPOBHFK_ItemIds) { }

	//// RVA: 0xE7B224 Offset: 0xE7B224 VA: 0xE7B224
	public static bool LDKPACJFPFK(int _KIJAPOFAGPN_ItemId, out TransitionUniqueId _PGIIDPEGGPI_EventId)
	{
		_PGIIDPEGGPI_EventId = TransitionUniqueId.TITLE;
		if(EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(_KIJAPOFAGPN_ItemId) == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp)
		{
			int id = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(_KIJAPOFAGPN_ItemId);
			NDBFKHKMMCE_DecoItem.FIDBAFHNGCF dbItem = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[id - 1];
			if(dbItem.GBJFNGCDKPM_typ == 4)
				_PGIIDPEGGPI_EventId = TransitionUniqueId.MUSICSELECT;
			else if(dbItem.GBJFNGCDKPM_typ == 6)
				_PGIIDPEGGPI_EventId = TransitionUniqueId.GACHA2;
			else if(dbItem.GBJFNGCDKPM_typ == 5)
				_PGIIDPEGGPI_EventId = TransitionUniqueId.SETTINGMENU;
			else
				return false;
			return true;
		}
		return false;
	}

	//// RVA: 0xE7B410 Offset: 0xE7B410 VA: 0xE7B410
	//public static int EIMPNCHJFOB() { }

	//// RVA: 0xE76C90 Offset: 0xE76C90 VA: 0xE76C90
	private static int[] GDMGBCFMBPH(ref CEBFFLDKAEC_SecureInt[] BGGANFLMLDA)
	{
		int[] res = new int[BGGANFLMLDA.Length];
		for(int i = 0; i < BGGANFLMLDA.Length; i++)
		{
			res[i] = BGGANFLMLDA[i].DNJEJEANJGL_Value;
		}
		return res;
	}

	//// RVA: 0xE76DC4 Offset: 0xE76DC4 VA: 0xE76DC4
	private int DOEMNGNEILE(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category _JONPKLHMOBL_Category)
	{
		switch(_JONPKLHMOBL_Category)
		{
			case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg:
			case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
			case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif:
				return (int)_JONPKLHMOBL_Category - 26;
			case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
				return 1;
			case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp:
				return 11;
			default:
				return -1;
			case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
				return 5;
			case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef:
				return 6;
			case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft:
				return 7;
			case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem:
				return 8;
			case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure:
				return 9;
			case EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso:
				return 10;
		}
	}
}
