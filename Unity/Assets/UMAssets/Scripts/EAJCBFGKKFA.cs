using System.Collections.Generic;
using XeApp.Game;
using XeApp.Game.Common;

[System.Obsolete("Use EAJCBFGKKFA_FriendInfo", true)]
public class EAJCBFGKKFA { }
public class EAJCBFGKKFA_FriendInfo
{
	public FFHPBEPOMAK_DivaInfo JIGONEMPPNP_Diva; // 0x8
	public GCIJNCFDNON_SceneInfo AFBMEMCHJCL_MainScene; // 0xC
	public EEMGHIINEHN.OPANFJDIEGH MGMFOJPNDGA_AssistData; // 0x10
	public List<GCIJNCFDNON_SceneInfo> HDJOHAJPGBA_SubScene; // 0x14
	public IBIGBMDANNM PCEGKKLKFNO_FriendData; // 0x18
	public IAPDFOPPGND NDOLELKAJNL_Degree; // 0x1C
	public IBIGBMDANNM.LJJOIIAEICI PDIPANKOKOL_FriendStat; // 0x20
	public string LBODHBDOMGK_PlayerName; // 0x24
	public string FGMPKKOOGCM_Comment; // 0x28
	public string FAABJIHJKEM_DcNm; // 0x2C
	public int ILOJAJNCPEC_Rank; // 0x30
	public int MLPEHNBNOGD_PlayerId; // 0x34
	public int KDHCKDHIHIP_EmblemCount; // 0x38
	public int LNFMPMEIMPH_SceneCnt; // 0x3C
	public int BJGOPOEAAIC_UtaRate; // 0x40
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
	public void KHEKNNFCAOI_Init(IBIGBMDANNM _NIMOGBDCMLJ_ServerSave)
	{
		if(_NIMOGBDCMLJ_ServerSave.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.AFBMEMCHJCL_MainScene.PPFNGGCBJKC_id == 0)
		{
			AFBMEMCHJCL_MainScene = null;
		}
		else
		{
			AFBMEMCHJCL_MainScene = new GCIJNCFDNON_SceneInfo();
			JNMFKOHFAFB_PublicStatus.KNHIPBADANI card = _NIMOGBDCMLJ_ServerSave.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.AFBMEMCHJCL_MainScene;
			AFBMEMCHJCL_MainScene.KHEKNNFCAOI_Init(
				card.PPFNGGCBJKC_id,
				card.PDNIFBEGMHC_Mb,
				card.EMOJHJGHJLN_Sb,
				card.JPIPENJGGDD_NumBoard,
				card.JPIPENJGGDD_NumBoard,
				card.MJBODMOLOBC_luck,
				false, 0,
				card.DMNIMMGGJJJ_Leaf
				);
		}
		MGMFOJPNDGA_AssistData = new EEMGHIINEHN.OPANFJDIEGH();
		MGMFOJPNDGA_AssistData.LDHHJFHGGMA(_NIMOGBDCMLJ_ServerSave.AHEFHIMGIBI_PlayerData);
		HDJOHAJPGBA_SubScene.Clear();
		for(int i = 0; i < _NIMOGBDCMLJ_ServerSave.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.HDJOHAJPGBA_SubScene.Count; i++)
		{
			JNMFKOHFAFB_PublicStatus.KNHIPBADANI card = _NIMOGBDCMLJ_ServerSave.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.HDJOHAJPGBA_SubScene[i];
			if (card.PPFNGGCBJKC_id == 0)
			{
				HDJOHAJPGBA_SubScene.Add(null);
			}
			else
			{
				GCIJNCFDNON_SceneInfo data = new GCIJNCFDNON_SceneInfo();
				data.KHEKNNFCAOI_Init(card.PPFNGGCBJKC_id, card.PDNIFBEGMHC_Mb, card.EMOJHJGHJLN_Sb, card.JPIPENJGGDD_NumBoard,
					card.JPIPENJGGDD_NumBoard, card.MJBODMOLOBC_luck, false, 0, card.DMNIMMGGJJJ_Leaf);
				HDJOHAJPGBA_SubScene.Add(data);
			}
		}
		if(_NIMOGBDCMLJ_ServerSave.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.DIPKCALNIII_diva_id != 0)
		{
			JIGONEMPPNP_Diva = new FFHPBEPOMAK_DivaInfo();
			JIGONEMPPNP_Diva.KHEKNNFCAOI_Init(_NIMOGBDCMLJ_ServerSave.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.DIPKCALNIII_diva_id,
				_NIMOGBDCMLJ_ServerSave.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.ANAJIAENLNB_lv,
				_NIMOGBDCMLJ_ServerSave.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.BEEAIAAJOHD_CostumeId,
				_NIMOGBDCMLJ_ServerSave.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.AFNIOJHODAG_CostumeColorId,
				AFBMEMCHJCL_MainScene, HDJOHAJPGBA_SubScene, false);
		}
		PCEGKKLKFNO_FriendData = _NIMOGBDCMLJ_ServerSave;
		PDIPANKOKOL_FriendStat = _NIMOGBDCMLJ_ServerSave.LHMDABPNDDH_state;
		LBODHBDOMGK_PlayerName = _NIMOGBDCMLJ_ServerSave.LBODHBDOMGK_PlayerName;
		if(_NIMOGBDCMLJ_ServerSave.AHEFHIMGIBI_PlayerData == null)
		{
			FGMPKKOOGCM_Comment = "";
			LNFMPMEIMPH_SceneCnt = 1;
		}
		else
		{
			FGMPKKOOGCM_Comment = _NIMOGBDCMLJ_ServerSave.AHEFHIMGIBI_PlayerData.JHFIPCIHJNL_Base.CMKKFCGBILD_prof;
			LNFMPMEIMPH_SceneCnt = _NIMOGBDCMLJ_ServerSave.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.BKIFLJAMJGG_scn_cnt;
		}
		ILOJAJNCPEC_Rank = _NIMOGBDCMLJ_ServerSave.ADFIHAPELAN_PLevel;
		MLPEHNBNOGD_PlayerId = _NIMOGBDCMLJ_ServerSave.MLPEHNBNOGD_PlayerId;
		NDOLELKAJNL_Degree = new IAPDFOPPGND();
		if(_NIMOGBDCMLJ_ServerSave.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus == null)
		{
			NDOLELKAJNL_Degree.KHEKNNFCAOI_Init(1, 0);
		}
		else
		{
			NDOLELKAJNL_Degree.KHEKNNFCAOI_Init(_NIMOGBDCMLJ_ServerSave.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.ABLOIBMGLFD_em_id,
				_NIMOGBDCMLJ_ServerSave.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.FHCAFLCLGAA_em_cnt);
		}
		ODNHGAJPEOM_CostumeList = null;
		EDEPBHCOHNF_ValkyrieList = null;
		ALJGLDBFFGJ_EmblemList = null;
		PPMGIDEHHDI_ViewHSRatingData = new GHLGEECLCMH();
		PPMGIDEHHDI_ViewHSRatingData.KHEKNNFCAOI_Init(_NIMOGBDCMLJ_ServerSave);
		AGJIIKKOKFJ_ScoreRatingRank = PPMGIDEHHDI_ViewHSRatingData.LLNHMMBFPMA_ScoreRatingRanking;
		BJGOPOEAAIC_UtaRate = PPMGIDEHHDI_ViewHSRatingData.ECMFBEHEGEH_UtaRateTotal;
		FAABJIHJKEM_DcNm = _NIMOGBDCMLJ_ServerSave.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.NAKJJBEIION_DcNm;
		BHJLNGEDEGN = _NIMOGBDCMLJ_ServerSave.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.DALCINDEJLC_DcTm != 0;
	}

	// RVA: 0x14F153C Offset: 0x14F153C VA: 0x14F153C
	public void KLJNFJJMJMC(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError, bool OJEBNBLHPNP/* = false*/)
	{
		if(ODNHGAJPEOM_CostumeList != null && EDEPBHCOHNF_ValkyrieList != null && ALJGLDBFFGJ_EmblemList != null)
		{
			if (_BHFHGFKBOHH_OnSuccess != null)
				_BHFHGFKBOHH_OnSuccess();
		}
		ODNHGAJPEOM_CostumeList = null;
		EDEPBHCOHNF_ValkyrieList = null;
		ALJGLDBFFGJ_EmblemList = null;
		if(MLPEHNBNOGD_PlayerId > 9999)
		{
			BBHNACPENDM_ServerSaveData KPMOBPNENCD_serverData = new BBHNACPENDM_ServerSaveData();
			KPMOBPNENCD_serverData.KHEKNNFCAOI_Init(0x40a10);
			NJNCAHLIHNI_GetPlayerData req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NJNCAHLIHNI_GetPlayerData());
			List<int> l = new List<int>();
			l.Add(MLPEHNBNOGD_PlayerId);
			req.FAMHAPONILI_PlayerIds = l;
			req.HHIHCJKLJFF_Names = KPMOBPNENCD_serverData.KPIDBPEKMFD_GetNames();
			req.PINPBOCDKLI_OnPlayerCb = (int _BMBBDIAEOMP_i, int _EHGBICNIBKE_player_id, long _IFNLEKOILPM_updated_at, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
			{
				//0x14F1AEC
				return KPMOBPNENCD_serverData.IIEMACPEEBJ_Deserialize(_OHNJJIMGKGK_Names, _IDLHJIOMJBK_data);
			};
			req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
			{
				//0x14F1B28
				ODNHGAJPEOM_CostumeList = CKFGMNAIBNG.NEOMKKIEMJJ(KPMOBPNENCD_serverData, OJEBNBLHPNP, true);
				EDEPBHCOHNF_ValkyrieList = PNGOLKLFFLH.NEOMKKIEMJJ(KPMOBPNENCD_serverData, OJEBNBLHPNP);
				ALJGLDBFFGJ_EmblemList = IAPDFOPPGND.NEOMKKIEMJJ(KPMOBPNENCD_serverData, OJEBNBLHPNP);
				PCEGKKLKFNO_FriendData.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.FOFGELKGMAH_cos_cnt = KPMOBPNENCD_serverData.BEKHNNCGIEL_Costume.EFFKJGEDONM_GetNumUnlockedCostume(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume, KPMOBPNENCD_serverData.DGCJCAHIAPP_Diva, true);
				_BHFHGFKBOHH_OnSuccess();
			};
			req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
			{
				//0x14F1E80
				_AOCANKOMKFG_OnError();
			};
		}
		else
		{
			ODNHGAJPEOM_CostumeList = new List<CKFGMNAIBNG>();
			EDEPBHCOHNF_ValkyrieList = new List<PNGOLKLFFLH>();
			ALJGLDBFFGJ_EmblemList = new List<IAPDFOPPGND>();
			if (_BHFHGFKBOHH_OnSuccess != null)
				_BHFHGFKBOHH_OnSuccess();
		}
	}

	//// RVA: 0x14F1970 Offset: 0x14F1970 VA: 0x14F1970
	public GCIJNCFDNON_SceneInfo KHGKPKDBMOH_GetAssistScene()
	{
		int a = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.GDMIGCCMEEF_GuestSelect.NPEEPPCPEPE_assistItem;
		if (a < 4)
		{
			if (MGMFOJPNDGA_AssistData.JOHLGBDOLNO_AssistScenes[a].BCCHOBPJJKE_SceneId < 1)
				return AFBMEMCHJCL_MainScene;
			else
				return MGMFOJPNDGA_AssistData.JOHLGBDOLNO_AssistScenes[a];
		}
		else
		{
			return AFBMEMCHJCL_MainScene;
		}
	}
}
