using System.Collections.Generic;
using XeApp.Game;
using XeApp.Game.Common;

[System.Obsolete("Use EAJCBFGKKFA_FriendInfo", true)]
public class EAJCBFGKKFA { }
public class EAJCBFGKKFA_FriendInfo
{
	public FFHPBEPOMAK_DivaInfo JIGONEMPPNP_Diva; // 0x8
	public GCIJNCFDNON_SceneInfo AFBMEMCHJCL_MainScene; // 0xC
	public EEMGHIINEHN.OPANFJDIEGH MGMFOJPNDGA; // 0x10
	public List<GCIJNCFDNON_SceneInfo> HDJOHAJPGBA_SubScene; // 0x14
	public IBIGBMDANNM PCEGKKLKFNO; // 0x18
	public IAPDFOPPGND NDOLELKAJNL_DegreeData; // 0x1C
	public IBIGBMDANNM.LJJOIIAEICI PDIPANKOKOL_FriendType; // 0x20
	public string LBODHBDOMGK_Name; // 0x24
	public string FGMPKKOOGCM_Comment; // 0x28
	public string FAABJIHJKEM_DcNm; // 0x2C
	public int ILOJAJNCPEC_Rank; // 0x30
	public int MLPEHNBNOGD_Id; // 0x34
	public int KDHCKDHIHIP; // 0x38
	public int LNFMPMEIMPH_SceneCnt; // 0x3C
	public int BJGOPOEAAIC_MusicRatio; // 0x40
	public bool BHJLNGEDEGN; // 0x44
	public HighScoreRatingRank.Type AGJIIKKOKFJ_ScoreRatingRank = HighScoreRatingRank.Type.Be; // 0x48
	public GHLGEECLCMH PPMGIDEHHDI_ViewHSRatingData; // 0x4C
	public List<CKFGMNAIBNG> ODNHGAJPEOM_CostumeList; // 0x50
	public List<PNGOLKLFFLH> EDEPBHCOHNF_ValkyrieList; // 0x54
	public List<IAPDFOPPGND> ALJGLDBFFGJ_EmblemList; // 0x58

	// RVA: 0x14F0834 Offset: 0x14F0834 VA: 0x14F0834
	public EAJCBFGKKFA_FriendInfo()
	{
		HDJOHAJPGBA_SubScene = new List<GCIJNCFDNON_SceneInfo>();
	}

	// RVA: 0x14F08C8 Offset: 0x14F08C8 VA: 0x14F08C8
	public void KHEKNNFCAOI(IBIGBMDANNM NIMOGBDCMLJ)
	{
		if(NIMOGBDCMLJ.AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.AFBMEMCHJCL_MScene.PPFNGGCBJKC_Id == 0)
		{
			AFBMEMCHJCL_MainScene = null;
		}
		else
		{
			AFBMEMCHJCL_MainScene = new GCIJNCFDNON_SceneInfo();
			JNMFKOHFAFB_PublicStatus.KNHIPBADANI card = NIMOGBDCMLJ.AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.AFBMEMCHJCL_MScene;
			AFBMEMCHJCL_MainScene.KHEKNNFCAOI(
				card.PPFNGGCBJKC_Id,
				card.PDNIFBEGMHC_Mb,
				card.EMOJHJGHJLN_Sb,
				card.JPIPENJGGDD_Mlt,
				card.JPIPENJGGDD_Mlt,
				card.MJBODMOLOBC_Luck,
				false, 0,
				card.DMNIMMGGJJJ_Leaf
				);
		}
		MGMFOJPNDGA = new EEMGHIINEHN.OPANFJDIEGH();
		MGMFOJPNDGA.LDHHJFHGGMA(NIMOGBDCMLJ.AHEFHIMGIBI_ServerData);
		HDJOHAJPGBA_SubScene.Clear();
		for(int i = 0; i < NIMOGBDCMLJ.AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.HDJOHAJPGBA_SScene.Count; i++)
		{
			JNMFKOHFAFB_PublicStatus.KNHIPBADANI card = NIMOGBDCMLJ.AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.HDJOHAJPGBA_SScene[i];
			if (card.PPFNGGCBJKC_Id == 0)
			{
				HDJOHAJPGBA_SubScene.Add(null);
			}
			else
			{
				GCIJNCFDNON_SceneInfo data = new GCIJNCFDNON_SceneInfo();
				data.KHEKNNFCAOI(card.PPFNGGCBJKC_Id, card.PDNIFBEGMHC_Mb, card.EMOJHJGHJLN_Sb, card.JPIPENJGGDD_Mlt,
					card.JPIPENJGGDD_Mlt, card.MJBODMOLOBC_Luck, false, 0, card.DMNIMMGGJJJ_Leaf);
				HDJOHAJPGBA_SubScene.Add(data);
			}
		}
		if(NIMOGBDCMLJ.AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.DIPKCALNIII_DivaId != 0)
		{
			JIGONEMPPNP_Diva = new FFHPBEPOMAK_DivaInfo();
			JIGONEMPPNP_Diva.KHEKNNFCAOI(NIMOGBDCMLJ.AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.DIPKCALNIII_DivaId,
				NIMOGBDCMLJ.AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.ANAJIAENLNB_Level,
				NIMOGBDCMLJ.AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.BEEAIAAJOHD_CostumeId,
				NIMOGBDCMLJ.AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.AFNIOJHODAG_CostumeColorId,
				AFBMEMCHJCL_MainScene, HDJOHAJPGBA_SubScene, false);
		}
		PCEGKKLKFNO = NIMOGBDCMLJ;
		PDIPANKOKOL_FriendType = NIMOGBDCMLJ.LHMDABPNDDH_Type;
		LBODHBDOMGK_Name = NIMOGBDCMLJ.LBODHBDOMGK_Name;
		if(NIMOGBDCMLJ.AHEFHIMGIBI_ServerData == null)
		{
			FGMPKKOOGCM_Comment = "";
			LNFMPMEIMPH_SceneCnt = 1;
		}
		else
		{
			FGMPKKOOGCM_Comment = NIMOGBDCMLJ.AHEFHIMGIBI_ServerData.JHFIPCIHJNL_Base.CMKKFCGBILD_Prof;
			LNFMPMEIMPH_SceneCnt = NIMOGBDCMLJ.AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.BKIFLJAMJGG_ScnCnt;
		}
		ILOJAJNCPEC_Rank = NIMOGBDCMLJ.ADFIHAPELAN_PLevel;
		MLPEHNBNOGD_Id = NIMOGBDCMLJ.MLPEHNBNOGD_Id;
		NDOLELKAJNL_DegreeData = new IAPDFOPPGND();
		if(NIMOGBDCMLJ.AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus == null)
		{
			NDOLELKAJNL_DegreeData.KHEKNNFCAOI_Init(1, 0);
		}
		else
		{
			NDOLELKAJNL_DegreeData.KHEKNNFCAOI_Init(NIMOGBDCMLJ.AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.ABLOIBMGLFD_EmId,
				NIMOGBDCMLJ.AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.FHCAFLCLGAA_EmCnt);
		}
		ODNHGAJPEOM_CostumeList = null;
		EDEPBHCOHNF_ValkyrieList = null;
		ALJGLDBFFGJ_EmblemList = null;
		PPMGIDEHHDI_ViewHSRatingData = new GHLGEECLCMH();
		PPMGIDEHHDI_ViewHSRatingData.KHEKNNFCAOI(NIMOGBDCMLJ);
		AGJIIKKOKFJ_ScoreRatingRank = PPMGIDEHHDI_ViewHSRatingData.LLNHMMBFPMA_ScoreRatingRanking;
		BJGOPOEAAIC_MusicRatio = PPMGIDEHHDI_ViewHSRatingData.ECMFBEHEGEH_UtaRateTotal;
		FAABJIHJKEM_DcNm = NIMOGBDCMLJ.AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.NAKJJBEIION_DcNm;
		BHJLNGEDEGN = NIMOGBDCMLJ.AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.DALCINDEJLC_DcTm != 0;
	}

	// RVA: 0x14F153C Offset: 0x14F153C VA: 0x14F153C
	public void KLJNFJJMJMC(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG, bool OJEBNBLHPNP = false)
	{
		if(ODNHGAJPEOM_CostumeList != null && EDEPBHCOHNF_ValkyrieList != null && ALJGLDBFFGJ_EmblemList != null)
		{
			if (BHFHGFKBOHH != null)
				BHFHGFKBOHH();
		}
		ODNHGAJPEOM_CostumeList = null;
		EDEPBHCOHNF_ValkyrieList = null;
		ALJGLDBFFGJ_EmblemList = null;
		if(MLPEHNBNOGD_Id > 9999)
		{
			BBHNACPENDM_ServerSaveData KPMOBPNENCD_serverData = new BBHNACPENDM_ServerSaveData();
			KPMOBPNENCD_serverData.KHEKNNFCAOI_Init(0x40a10);
			NJNCAHLIHNI_GetPlayerData req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NJNCAHLIHNI_GetPlayerData());
			List<int> l = new List<int>();
			l.Add(MLPEHNBNOGD_Id);
			req.FAMHAPONILI_Ids = l;
			req.HHIHCJKLJFF_BlockNames = KPMOBPNENCD_serverData.KPIDBPEKMFD_GetBlockList();
			req.PINPBOCDKLI = (int BMBBDIAEOMP, int EHGBICNIBKE, long IFNLEKOILPM, List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData IDLHJIOMJBK) =>
			{
				//0x14F1AEC
				return KPMOBPNENCD_serverData.IIEMACPEEBJ_Load(OHNJJIMGKGK, IDLHJIOMJBK);
			};
			req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
			{
				//0x14F1B28
				ODNHGAJPEOM_CostumeList = CKFGMNAIBNG.NEOMKKIEMJJ(KPMOBPNENCD_serverData, OJEBNBLHPNP, true);
				EDEPBHCOHNF_ValkyrieList = PNGOLKLFFLH.NEOMKKIEMJJ(KPMOBPNENCD_serverData, OJEBNBLHPNP);
				ALJGLDBFFGJ_EmblemList = IAPDFOPPGND.NEOMKKIEMJJ(KPMOBPNENCD_serverData, OJEBNBLHPNP);
				PCEGKKLKFNO.AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.FOFGELKGMAH_CosCnt = KPMOBPNENCD_serverData.BEKHNNCGIEL_Costume.EFFKJGEDONM_GetNumUnlockedCostume(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume, KPMOBPNENCD_serverData.DGCJCAHIAPP_Diva, true);
				BHFHGFKBOHH();
			};
			req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
			{
				//0x14F1E80
				AOCANKOMKFG();
			};
		}
		else
		{
			ODNHGAJPEOM_CostumeList = new List<CKFGMNAIBNG>();
			EDEPBHCOHNF_ValkyrieList = new List<PNGOLKLFFLH>();
			ALJGLDBFFGJ_EmblemList = new List<IAPDFOPPGND>();
			if (BHFHGFKBOHH != null)
				BHFHGFKBOHH();
		}
	}

	//// RVA: 0x14F1970 Offset: 0x14F1970 VA: 0x14F1970
	public GCIJNCFDNON_SceneInfo KHGKPKDBMOH_GetAssistScene()
	{
		int a = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.GDMIGCCMEEF_GuestSelect.NPEEPPCPEPE_assistItem;
		if (a < 4)
		{
			if (MGMFOJPNDGA.JOHLGBDOLNO_AssistScenes[a].BCCHOBPJJKE_SceneId < 1)
				return AFBMEMCHJCL_MainScene;
			else
				return MGMFOJPNDGA.JOHLGBDOLNO_AssistScenes[a];
		}
		else
		{
			return AFBMEMCHJCL_MainScene;
		}
	}
}
