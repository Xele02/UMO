
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use GONMPHKGKHI_RewardView", true)]
public class GONMPHKGKHI { }
public class GONMPHKGKHI_RewardView
{
	public enum CECMLGBLHHG_PopupType
	{
		HJNNKCMLGFL_0_None = 0,
		GBIDBHKEPGL_1 = 1,
		AGLFBCCGHJM_2_NewEpisode = 2,
		NNEOHGFGLKM_3_RareUp = 3,
		INJNLJHGGKB_4_NextBoard = 4,
		CEFPGLBAGAC = 5,
		MNGOJCFMBPP = 6,
		BKHAAGAAIHJ_7_Episode = 7,
		JCGKGFLCKCP_8_Poster = 8,
		AEFCOHJBLPO_9_Num = 9,
	}

	public class LCMJJMNMIKG_RewardInfo
	{
		public int BCCHOBPJJKE_SceneId; // 0x8
		public CECMLGBLHHG_PopupType IPMJIODJGBC; // 0xC
		public int JKGFBFPIMGA_Rarity; // 0x10
		public int MPGNHFDGOBO_PrevRarity; // 0x14
		public int HNNAODKJGPD_NextRarity; // 0x18
		public int LBGGNGCKOJE_PrevNumBoard; // 0x1C
		public int FICKICOHCAD_NextNumBoard; // 0x20
		public int KELFCMEOPPM_EpisodeId; // 0x24
	}

	public class GCHFDJMNCAF : LCMJJMNMIKG_RewardInfo
	{
		public bool DMJCACIDEBM; // 0x28
		public int GBALGEMKJKD_PrevBoard; // 0x2C
		public int HMGDINKEPHJ_NextBoard; // 0x30
	}

	public List<LCMJJMNMIKG_RewardInfo> NJCMJLPPIGK = new List<LCMJJMNMIKG_RewardInfo>(); // 0x8
	public List<LCMJJMNMIKG_RewardInfo> JPMPIFCKEHH_RewardsInfo = new List<LCMJJMNMIKG_RewardInfo>(); // 0xC
	public List<LCMJJMNMIKG_RewardInfo> COLIEKINOPB_ItemsPoster = new List<LCMJJMNMIKG_RewardInfo>(); // 0x10
	public List<int> DKJLFPMHDJC = new List<int>(); // 0x14
	public List<int> NPOFCCEBOGC = new List<int>(); // 0x18

	//// RVA: 0x1E59F40 Offset: 0x1E59F40 VA: 0x1E59F40
	//private bool DCEEFOKCFEC(int _KELFCMEOPPM_EpisodeId) { }

	//// RVA: 0x1E59F50 Offset: 0x1E59F50 VA: 0x1E59F50
	public bool KHEKNNFCAOI_Init(JKNGJFOBADP BEJHIEGCGNE, bool IMBGFAJLPEK)
	{
		if (BEJHIEGCGNE.FIGHNFKAMGI.Count == 0)
			return false;
		for(int i = 0; i < BEJHIEGCGNE.FIGHNFKAMGI.Count; i++)
		{
			JKNGJFOBADP.GPPAIFNBHDP FKHPGALPAIC = BEJHIEGCGNE.FIGHNFKAMGI[i];
			if(FKHPGALPAIC.JKGFBFPIMGA_Rarity < 4)
			{
				if(FKHPGALPAIC.INDDJNMPONH_type >= 3 && FKHPGALPAIC.INDDJNMPONH_type < 5)
				{
					LCMJJMNMIKG_RewardInfo rewardInfo = JPMPIFCKEHH_RewardsInfo.Find((LCMJJMNMIKG_RewardInfo _GHPLINIACBB_x) =>
					{
						//0x1E5D914
						if ((int)_GHPLINIACBB_x.IPMJIODJGBC != FKHPGALPAIC.INDDJNMPONH_type)
							return false;
						return _GHPLINIACBB_x.BCCHOBPJJKE_SceneId == FKHPGALPAIC.BCCHOBPJJKE_SceneId;
					});
					if (rewardInfo == null)
					{
						rewardInfo = new LCMJJMNMIKG_RewardInfo();
						rewardInfo.BCCHOBPJJKE_SceneId = FKHPGALPAIC.BCCHOBPJJKE_SceneId;
						rewardInfo.IPMJIODJGBC = (CECMLGBLHHG_PopupType)FKHPGALPAIC.INDDJNMPONH_type;
						rewardInfo.JKGFBFPIMGA_Rarity = FKHPGALPAIC.JKGFBFPIMGA_Rarity;
						rewardInfo.MPGNHFDGOBO_PrevRarity = FKHPGALPAIC.MPGNHFDGOBO_PrevRarity;
						rewardInfo.HNNAODKJGPD_NextRarity = FKHPGALPAIC.HNNAODKJGPD_NextRarity;
						rewardInfo.LBGGNGCKOJE_PrevNumBoard = FKHPGALPAIC.JPIPENJGGDD_NumBoard < 1 ? 0 : FKHPGALPAIC.JPIPENJGGDD_NumBoard - 1;
						rewardInfo.FICKICOHCAD_NextNumBoard = FKHPGALPAIC.JPIPENJGGDD_NumBoard;
						JPMPIFCKEHH_RewardsInfo.Add(rewardInfo);
					}
					else
					{
						rewardInfo.LBGGNGCKOJE_PrevNumBoard = Mathf.Min(FKHPGALPAIC.JPIPENJGGDD_NumBoard, rewardInfo.LBGGNGCKOJE_PrevNumBoard);
						rewardInfo.FICKICOHCAD_NextNumBoard = Mathf.Max(FKHPGALPAIC.JPIPENJGGDD_NumBoard, rewardInfo.FICKICOHCAD_NextNumBoard);
					}
				}
				else if(FKHPGALPAIC.INDDJNMPONH_type == 6)
				{
					LCMJJMNMIKG_RewardInfo rewardInfo = JPMPIFCKEHH_RewardsInfo.Find((LCMJJMNMIKG_RewardInfo _GHPLINIACBB_x) =>
					{
						//0x1E5D988
						return (int)_GHPLINIACBB_x.IPMJIODJGBC == FKHPGALPAIC.INDDJNMPONH_type;
					});
					if (rewardInfo == null)
					{
						rewardInfo = new LCMJJMNMIKG_RewardInfo();
						rewardInfo.BCCHOBPJJKE_SceneId = FKHPGALPAIC.BCCHOBPJJKE_SceneId;
						rewardInfo.IPMJIODJGBC = (CECMLGBLHHG_PopupType)FKHPGALPAIC.INDDJNMPONH_type;
						rewardInfo.JKGFBFPIMGA_Rarity = FKHPGALPAIC.JKGFBFPIMGA_Rarity;
						rewardInfo.MPGNHFDGOBO_PrevRarity = FKHPGALPAIC.MPGNHFDGOBO_PrevRarity;
						rewardInfo.HNNAODKJGPD_NextRarity = FKHPGALPAIC.HNNAODKJGPD_NextRarity;
						JPMPIFCKEHH_RewardsInfo.Add(rewardInfo);
					}
					else
					{
						if(rewardInfo.BCCHOBPJJKE_SceneId < 0)
						{
							rewardInfo.BCCHOBPJJKE_SceneId = FKHPGALPAIC.BCCHOBPJJKE_SceneId;
						}
					}
				}
				else if(FKHPGALPAIC.INDDJNMPONH_type == 1)
				{
					LCMJJMNMIKG_RewardInfo rewardInfo = new LCMJJMNMIKG_RewardInfo();
					rewardInfo.BCCHOBPJJKE_SceneId = FKHPGALPAIC.BCCHOBPJJKE_SceneId;
					rewardInfo.IPMJIODJGBC = (CECMLGBLHHG_PopupType)FKHPGALPAIC.INDDJNMPONH_type;
					rewardInfo.JKGFBFPIMGA_Rarity = FKHPGALPAIC.JKGFBFPIMGA_Rarity;
					rewardInfo.MPGNHFDGOBO_PrevRarity = FKHPGALPAIC.MPGNHFDGOBO_PrevRarity;
					rewardInfo.HNNAODKJGPD_NextRarity = FKHPGALPAIC.HNNAODKJGPD_NextRarity;
					rewardInfo.LBGGNGCKOJE_PrevNumBoard = FKHPGALPAIC.JPIPENJGGDD_NumBoard;
					rewardInfo.FICKICOHCAD_NextNumBoard = FKHPGALPAIC.JPIPENJGGDD_NumBoard;
					JPMPIFCKEHH_RewardsInfo.Add(rewardInfo);
				}
			}
			else if(FKHPGALPAIC.INDDJNMPONH_type == 1)
			{
				LCMJJMNMIKG_RewardInfo rewardInfo = new LCMJJMNMIKG_RewardInfo();
				rewardInfo.BCCHOBPJJKE_SceneId = FKHPGALPAIC.BCCHOBPJJKE_SceneId;
				rewardInfo.IPMJIODJGBC = (CECMLGBLHHG_PopupType)FKHPGALPAIC.INDDJNMPONH_type;
				rewardInfo.JKGFBFPIMGA_Rarity = FKHPGALPAIC.JKGFBFPIMGA_Rarity;
				rewardInfo.MPGNHFDGOBO_PrevRarity = FKHPGALPAIC.MPGNHFDGOBO_PrevRarity;
				rewardInfo.HNNAODKJGPD_NextRarity = FKHPGALPAIC.HNNAODKJGPD_NextRarity;
				rewardInfo.LBGGNGCKOJE_PrevNumBoard = FKHPGALPAIC.JPIPENJGGDD_NumBoard;
				rewardInfo.FICKICOHCAD_NextNumBoard = FKHPGALPAIC.JPIPENJGGDD_NumBoard;
				JPMPIFCKEHH_RewardsInfo.Add(rewardInfo);
				if(FKHPGALPAIC.OGPKHGEMLMP)
				{
					GCHFDJMNCAF d = new GCHFDJMNCAF();
					d.BCCHOBPJJKE_SceneId = FKHPGALPAIC.BCCHOBPJJKE_SceneId;
					d.JKGFBFPIMGA_Rarity = FKHPGALPAIC.JKGFBFPIMGA_Rarity;
					d.DMJCACIDEBM = FKHPGALPAIC.OLGCDLJFMDH_Sngl;
					d.GBALGEMKJKD_PrevBoard = 0;
					d.HMGDINKEPHJ_NextBoard = 1;
					COLIEKINOPB_ItemsPoster.Add(d);
				}
			}
			else
			{
				if(FKHPGALPAIC.INDDJNMPONH_type == 4)
				{
					LCMJJMNMIKG_RewardInfo rewardInfo = NJCMJLPPIGK.Find((LCMJJMNMIKG_RewardInfo _GHPLINIACBB_x) =>
					{
						//0x1E5D67C
						if ((int)_GHPLINIACBB_x.IPMJIODJGBC != FKHPGALPAIC.INDDJNMPONH_type)
							return false;
						return _GHPLINIACBB_x.BCCHOBPJJKE_SceneId == FKHPGALPAIC.BCCHOBPJJKE_SceneId;
					});
					if(rewardInfo == null)
					{
						rewardInfo = new LCMJJMNMIKG_RewardInfo();
						rewardInfo.BCCHOBPJJKE_SceneId = FKHPGALPAIC.BCCHOBPJJKE_SceneId;
						rewardInfo.IPMJIODJGBC = (CECMLGBLHHG_PopupType)FKHPGALPAIC.INDDJNMPONH_type;
						rewardInfo.JKGFBFPIMGA_Rarity = FKHPGALPAIC.JKGFBFPIMGA_Rarity;
						rewardInfo.MPGNHFDGOBO_PrevRarity = FKHPGALPAIC.MPGNHFDGOBO_PrevRarity;
						rewardInfo.HNNAODKJGPD_NextRarity = FKHPGALPAIC.HNNAODKJGPD_NextRarity;
						rewardInfo.LBGGNGCKOJE_PrevNumBoard = FKHPGALPAIC.JPIPENJGGDD_NumBoard - 1;
						rewardInfo.FICKICOHCAD_NextNumBoard = FKHPGALPAIC.JPIPENJGGDD_NumBoard;
						NJCMJLPPIGK.Add(rewardInfo);
					}
					else
					{
						rewardInfo.LBGGNGCKOJE_PrevNumBoard = Mathf.Min(FKHPGALPAIC.JPIPENJGGDD_NumBoard, rewardInfo.LBGGNGCKOJE_PrevNumBoard);
						rewardInfo.FICKICOHCAD_NextNumBoard = Mathf.Max(FKHPGALPAIC.JPIPENJGGDD_NumBoard, rewardInfo.FICKICOHCAD_NextNumBoard);
					}
					if(FKHPGALPAIC.OGPKHGEMLMP)
					{
						if(!FKHPGALPAIC.OLGCDLJFMDH_Sngl)
						{
							rewardInfo = COLIEKINOPB_ItemsPoster.Find((LCMJJMNMIKG_RewardInfo _GHPLINIACBB_x) =>
							{
								//0x1E5D6F0
								GCHFDJMNCAF d = _GHPLINIACBB_x as GCHFDJMNCAF;
								if (d.DMJCACIDEBM)
									return false;
								return d.BCCHOBPJJKE_SceneId == FKHPGALPAIC.BCCHOBPJJKE_SceneId;
							});
							if(rewardInfo == null)
							{
								GCHFDJMNCAF d = new GCHFDJMNCAF();
								d.BCCHOBPJJKE_SceneId = FKHPGALPAIC.BCCHOBPJJKE_SceneId;
								d.DMJCACIDEBM = false;
								d.JKGFBFPIMGA_Rarity = FKHPGALPAIC.JKGFBFPIMGA_Rarity;
								d.GBALGEMKJKD_PrevBoard = FKHPGALPAIC.JPIPENJGGDD_NumBoard;
								d.HMGDINKEPHJ_NextBoard = FKHPGALPAIC.JPIPENJGGDD_NumBoard + 1;
								COLIEKINOPB_ItemsPoster.Add(d);
							}
							else
							{
								GCHFDJMNCAF d = rewardInfo as GCHFDJMNCAF;
								d.GBALGEMKJKD_PrevBoard = Mathf.Min(FKHPGALPAIC.JPIPENJGGDD_NumBoard + 1, d.GBALGEMKJKD_PrevBoard);
								d.HMGDINKEPHJ_NextBoard = Mathf.Min(FKHPGALPAIC.JPIPENJGGDD_NumBoard + 1, d.HMGDINKEPHJ_NextBoard);
							}
						}
						rewardInfo = COLIEKINOPB_ItemsPoster.Find((LCMJJMNMIKG_RewardInfo _GHPLINIACBB_x) =>
						{
							//0x1E5D800
							GCHFDJMNCAF d = _GHPLINIACBB_x as GCHFDJMNCAF;
							if (!d.DMJCACIDEBM)
								return false;
							return d.BCCHOBPJJKE_SceneId == FKHPGALPAIC.BCCHOBPJJKE_SceneId;
						});
						if(rewardInfo == null)
						{
							GCHFDJMNCAF d = new GCHFDJMNCAF();
							d.BCCHOBPJJKE_SceneId = FKHPGALPAIC.BCCHOBPJJKE_SceneId;
							d.DMJCACIDEBM = true;
							d.JKGFBFPIMGA_Rarity = FKHPGALPAIC.JKGFBFPIMGA_Rarity;
							d.GBALGEMKJKD_PrevBoard = FKHPGALPAIC.JPIPENJGGDD_NumBoard;
							d.HMGDINKEPHJ_NextBoard = FKHPGALPAIC.JPIPENJGGDD_NumBoard + 1;
							COLIEKINOPB_ItemsPoster.Add(d);
						}
						else
						{
							GCHFDJMNCAF d = rewardInfo as GCHFDJMNCAF;
							d.GBALGEMKJKD_PrevBoard = Mathf.Min(FKHPGALPAIC.JPIPENJGGDD_NumBoard + 1, d.GBALGEMKJKD_PrevBoard);
							d.HMGDINKEPHJ_NextBoard = Mathf.Min(FKHPGALPAIC.JPIPENJGGDD_NumBoard + 1, d.HMGDINKEPHJ_NextBoard);
						}
					}
				}
				else
				{
					LCMJJMNMIKG_RewardInfo rewardInfo = new LCMJJMNMIKG_RewardInfo();
					rewardInfo.BCCHOBPJJKE_SceneId = FKHPGALPAIC.BCCHOBPJJKE_SceneId;
					rewardInfo.IPMJIODJGBC = (CECMLGBLHHG_PopupType)FKHPGALPAIC.INDDJNMPONH_type;
					rewardInfo.JKGFBFPIMGA_Rarity = FKHPGALPAIC.JKGFBFPIMGA_Rarity;
					rewardInfo.MPGNHFDGOBO_PrevRarity = FKHPGALPAIC.MPGNHFDGOBO_PrevRarity;
					rewardInfo.HNNAODKJGPD_NextRarity = FKHPGALPAIC.HNNAODKJGPD_NextRarity;
					rewardInfo.LBGGNGCKOJE_PrevNumBoard = FKHPGALPAIC.JPIPENJGGDD_NumBoard;
					rewardInfo.FICKICOHCAD_NextNumBoard = FKHPGALPAIC.JPIPENJGGDD_NumBoard;
					NJCMJLPPIGK.Add(rewardInfo);
					if (FKHPGALPAIC.OGPKHGEMLMP)
					{
						GCHFDJMNCAF d = new GCHFDJMNCAF();
						d.BCCHOBPJJKE_SceneId = FKHPGALPAIC.BCCHOBPJJKE_SceneId;
						d.DMJCACIDEBM = true;
						d.JKGFBFPIMGA_Rarity = FKHPGALPAIC.JKGFBFPIMGA_Rarity;
						d.GBALGEMKJKD_PrevBoard = 0;
						d.HMGDINKEPHJ_NextBoard = 1;
						COLIEKINOPB_ItemsPoster.Add(d);
					}
				}
			}
		}
		NJCMJLPPIGK.Sort((LCMJJMNMIKG_RewardInfo _HKICMNAACDA_a, LCMJJMNMIKG_RewardInfo _BNKHBCBJBKI_b) =>
		{
			//0x1E5D328
			if(_HKICMNAACDA_a.IPMJIODJGBC == _BNKHBCBJBKI_b.IPMJIODJGBC)
			{
				if(_HKICMNAACDA_a.JKGFBFPIMGA_Rarity == _BNKHBCBJBKI_b.JKGFBFPIMGA_Rarity)
				{
					return _HKICMNAACDA_a.BCCHOBPJJKE_SceneId.CompareTo(_BNKHBCBJBKI_b.BCCHOBPJJKE_SceneId);
				}
				return _HKICMNAACDA_a.JKGFBFPIMGA_Rarity.CompareTo(_BNKHBCBJBKI_b.JKGFBFPIMGA_Rarity);
			}
			return _HKICMNAACDA_a.IPMJIODJGBC.CompareTo(_BNKHBCBJBKI_b.IPMJIODJGBC);
		});
		JPMPIFCKEHH_RewardsInfo.Sort((LCMJJMNMIKG_RewardInfo _HKICMNAACDA_a, LCMJJMNMIKG_RewardInfo _BNKHBCBJBKI_b) =>
		{
			//0x1E5D3AC
			if (_HKICMNAACDA_a.IPMJIODJGBC == _BNKHBCBJBKI_b.IPMJIODJGBC)
			{
				if (_HKICMNAACDA_a.JKGFBFPIMGA_Rarity == _BNKHBCBJBKI_b.JKGFBFPIMGA_Rarity)
				{
					return _HKICMNAACDA_a.BCCHOBPJJKE_SceneId.CompareTo(_BNKHBCBJBKI_b.BCCHOBPJJKE_SceneId);
				}
				return _HKICMNAACDA_a.JKGFBFPIMGA_Rarity.CompareTo(_BNKHBCBJBKI_b.JKGFBFPIMGA_Rarity);
			}
			return _HKICMNAACDA_a.IPMJIODJGBC.CompareTo(_BNKHBCBJBKI_b.IPMJIODJGBC);
		});
		COLIEKINOPB_ItemsPoster.Sort((LCMJJMNMIKG_RewardInfo _HKICMNAACDA_a, LCMJJMNMIKG_RewardInfo _BNKHBCBJBKI_b) =>
		{
			//0x1E5D430
			if (_HKICMNAACDA_a.JKGFBFPIMGA_Rarity == _BNKHBCBJBKI_b.JKGFBFPIMGA_Rarity)
			{
				if (_HKICMNAACDA_a.BCCHOBPJJKE_SceneId == _BNKHBCBJBKI_b.BCCHOBPJJKE_SceneId)
				{
					GCHFDJMNCAF h = _HKICMNAACDA_a as GCHFDJMNCAF;
					GCHFDJMNCAF b = _BNKHBCBJBKI_b as GCHFDJMNCAF;
					return h.DMJCACIDEBM.CompareTo(b.DMJCACIDEBM);
				}
				return _HKICMNAACDA_a.BCCHOBPJJKE_SceneId.CompareTo(_BNKHBCBJBKI_b.BCCHOBPJJKE_SceneId);
			}
			return _HKICMNAACDA_a.JKGFBFPIMGA_Rarity.CompareTo(_BNKHBCBJBKI_b.JKGFBFPIMGA_Rarity);
		});
		DKJLFPMHDJC.Clear();
		List<int> l = new List<int>();
		for(int i = 0; i < BEJHIEGCGNE.NNDMIOEKKMM_NewEpisode.Count; i++)
		{
			l.Add(BEJHIEGCGNE.NNDMIOEKKMM_NewEpisode[i]);
		}
		if (l.Count > 0)
		{
			for (int i = 0; i < NJCMJLPPIGK.Count; i++)
			{
				if (NJCMJLPPIGK[i].IPMJIODJGBC == CECMLGBLHHG_PopupType.GBIDBHKEPGL_1/*1*/)
				{
					MLIBEPGADJH_Scene.KKLDOOJBJMN scene = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[NJCMJLPPIGK[i].BCCHOBPJJKE_SceneId - 1];
					for (int j = 0; j < l.Count; j++)
					{
						if (l[j] == scene.KELFCMEOPPM_EpisodeId)
						{
							DKJLFPMHDJC.Add(scene.KELFCMEOPPM_EpisodeId);
							l.RemoveAt(j);
							break;
						}
					}
				}
			}
			for (int i = 0; i < JPMPIFCKEHH_RewardsInfo.Count; i++)
			{
				if (JPMPIFCKEHH_RewardsInfo[i].IPMJIODJGBC == CECMLGBLHHG_PopupType.GBIDBHKEPGL_1/*1*/)
				{
					MLIBEPGADJH_Scene.KKLDOOJBJMN scene = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[JPMPIFCKEHH_RewardsInfo[i].BCCHOBPJJKE_SceneId - 1];
					for (int j = 0; j < l.Count; j++)
					{
						if (l[j] == scene.KELFCMEOPPM_EpisodeId)
						{
							DKJLFPMHDJC.Add(scene.KELFCMEOPPM_EpisodeId);
							l.RemoveAt(j);
							break;
						}
					}
				}
			}
		}
		NPOFCCEBOGC.Clear();
		for(int i = 0; i < BEJHIEGCGNE.FJKAMPIMFLP.Count; i++)
		{
			if(BEJHIEGCGNE.FJKAMPIMFLP[i].KELFCMEOPPM_EpisodeId > 1)
			{
				HMGPODKEFBA_EpisodeInfo MABBBOEAPAA_p = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[BEJHIEGCGNE.FJKAMPIMFLP[i].KELFCMEOPPM_EpisodeId - 1];
				FMLIFJBPFNA_Step step = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.KODIKHBMBBJ_Steps.Find((FMLIFJBPFNA_Step _GHPLINIACBB_x) =>
				{
					//0x1E5D9D4
					return _GHPLINIACBB_x.IOFHEGJPHKG_StepId == MABBBOEAPAA_p.IOFHEGJPHKG_StepId;
				});
				int pt = step.JENFHJDFFAD_Pt[MABBBOEAPAA_p.FGOGPCMHPIN_Count - 2];
				if (BEJHIEGCGNE.FJKAMPIMFLP[i].DNBFMLBNAEE_point < pt && pt <= PIGBBNDPPJC.GMDHJBGLBEI(BEJHIEGCGNE.FJKAMPIMFLP[i].KELFCMEOPPM_EpisodeId, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData))
				{
					NPOFCCEBOGC.Add(BEJHIEGCGNE.FJKAMPIMFLP[i].KELFCMEOPPM_EpisodeId);
				}
			}
		}
		bool res = true;
		if(NJCMJLPPIGK.Count < 1)
		{
			if(JPMPIFCKEHH_RewardsInfo.Count < 1)
			{
				if(DKJLFPMHDJC.Count < 1)
				{
					res = false;
					if (NPOFCCEBOGC.Count > 0)
						res = true;
				}
			}
		}
		return res;
	}

	//// RVA: 0x1E5C548 Offset: 0x1E5C548 VA: 0x1E5C548
	//public void NFOHOGAJGHB(bool IMBGFAJLPEK) { }

	//// RVA: 0x1E5C7B4 Offset: 0x1E5C7B4 VA: 0x1E5C7B4
	//public void NFOHOGAJGHB(List<int> _CGCFENMHJIM_Ids, List<int> PIHPOPCPAHL, bool IMBGFAJLPEK) { }

	//// RVA: 0x1E5C984 Offset: 0x1E5C984 VA: 0x1E5C984
	public bool LBHPMGDNPHK_IsAvailable(CECMLGBLHHG_PopupType _INDDJNMPONH_type)
	{
		List<LCMJJMNMIKG_RewardInfo> l1 = new List<LCMJJMNMIKG_RewardInfo>();
		List<LCMJJMNMIKG_RewardInfo> l2 = new List<LCMJJMNMIKG_RewardInfo>();
		List<int> l3 = new List<int>();
		return JDKOAKDLHMG(_INDDJNMPONH_type, ref l1, ref l2, ref l3);
	}

	//// RVA: 0x1E5CA78 Offset: 0x1E5CA78 VA: 0x1E5CA78
	public bool JDKOAKDLHMG(CECMLGBLHHG_PopupType _INDDJNMPONH_type, ref List<LCMJJMNMIKG_RewardInfo> PJFOENCFNEK, ref List<LCMJJMNMIKG_RewardInfo> MPCJGPEBCCD, ref List<int> _BBAJKJPKOHD_EpisodeList)
	{
		PJFOENCFNEK.Clear();
		MPCJGPEBCCD.Clear();
		_BBAJKJPKOHD_EpisodeList.Clear();
		List<LCMJJMNMIKG_RewardInfo> rewards = NJCMJLPPIGK.FindAll((LCMJJMNMIKG_RewardInfo JPAEDJJFFOI) =>
		{
			//0x1E5D60C
			return JPAEDJJFFOI.IPMJIODJGBC == _INDDJNMPONH_type;
		});
		List<LCMJJMNMIKG_RewardInfo> rewards2 = JPMPIFCKEHH_RewardsInfo.FindAll((LCMJJMNMIKG_RewardInfo JPAEDJJFFOI) =>
		{
			//0x1E5D644
			return JPAEDJJFFOI.IPMJIODJGBC == _INDDJNMPONH_type;
		});
		if(_INDDJNMPONH_type == CECMLGBLHHG_PopupType.INJNLJHGGKB_4_NextBoard/*4*/)
		{
			List<LCMJJMNMIKG_RewardInfo> rewards3 = NJCMJLPPIGK.FindAll((LCMJJMNMIKG_RewardInfo JPAEDJJFFOI) =>
			{
				//0x1E5D5AC
				return JPAEDJJFFOI.IPMJIODJGBC == CECMLGBLHHG_PopupType.NNEOHGFGLKM_3_RareUp/*3*/;
			});
			rewards.InsertRange(0, rewards3);
			rewards3 = JPMPIFCKEHH_RewardsInfo.FindAll((LCMJJMNMIKG_RewardInfo JPAEDJJFFOI) =>
			{
				//0x1E5D5DC
				return JPAEDJJFFOI.IPMJIODJGBC == CECMLGBLHHG_PopupType.NNEOHGFGLKM_3_RareUp/*3*/;
			});
			rewards2.InsertRange(0, rewards3);
		}
		switch(_INDDJNMPONH_type)
		{
			case CECMLGBLHHG_PopupType.AGLFBCCGHJM_2_NewEpisode/*2*/:
				_BBAJKJPKOHD_EpisodeList.AddRange(DKJLFPMHDJC);
				break;
			case CECMLGBLHHG_PopupType.NNEOHGFGLKM_3_RareUp/*3*/:
				PJFOENCFNEK.AddRange(rewards);
				MPCJGPEBCCD.AddRange(rewards);
				MPCJGPEBCCD.AddRange(rewards2);
				break;
			default:
				MPCJGPEBCCD.AddRange(rewards);
				MPCJGPEBCCD.AddRange(rewards2);
				break;
			case CECMLGBLHHG_PopupType.BKHAAGAAIHJ_7_Episode/*7*/:
				_BBAJKJPKOHD_EpisodeList.AddRange(NPOFCCEBOGC);
				break;
			case CECMLGBLHHG_PopupType.JCGKGFLCKCP_8_Poster/*8*/:
				MPCJGPEBCCD.AddRange(COLIEKINOPB_ItemsPoster);
				break;
		}
		if(PJFOENCFNEK.Count < 1)
		{
			if(MPCJGPEBCCD.Count < 1)
			{
				return _BBAJKJPKOHD_EpisodeList.Count > 0;
			}
		}
		return true;
	}
}
