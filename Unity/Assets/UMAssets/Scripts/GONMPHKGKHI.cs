
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use GONMPHKGKHI_RewardView", true)]
public class GONMPHKGKHI { }
public class GONMPHKGKHI_RewardView
{
	public enum CECMLGBLHHG
	{
		HJNNKCMLGFL = 0,
		GBIDBHKEPGL = 1,
		AGLFBCCGHJM_2 = 2,
		NNEOHGFGLKM_3 = 3,
		INJNLJHGGKB_4 = 4,
		CEFPGLBAGAC = 5,
		MNGOJCFMBPP = 6,
		BKHAAGAAIHJ_7 = 7,
		JCGKGFLCKCP_8 = 8,
		AEFCOHJBLPO = 9,
	}

	public class LCMJJMNMIKG_RewardInfo
	{
		public int BCCHOBPJJKE_SceneId; // 0x8
		public CECMLGBLHHG IPMJIODJGBC; // 0xC
		public int JKGFBFPIMGA; // 0x10
		public int MPGNHFDGOBO; // 0x14
		public int HNNAODKJGPD; // 0x18
		public int LBGGNGCKOJE; // 0x1C
		public int FICKICOHCAD; // 0x20
		public int KELFCMEOPPM; // 0x24
	}

	public class GCHFDJMNCAF : LCMJJMNMIKG_RewardInfo
	{
		public bool DMJCACIDEBM; // 0x28
		public int GBALGEMKJKD; // 0x2C
		public int HMGDINKEPHJ; // 0x30
	}

	public List<LCMJJMNMIKG_RewardInfo> NJCMJLPPIGK = new List<LCMJJMNMIKG_RewardInfo>(); // 0x8
	public List<LCMJJMNMIKG_RewardInfo> JPMPIFCKEHH_RewardsInfo = new List<LCMJJMNMIKG_RewardInfo>(); // 0xC
	public List<LCMJJMNMIKG_RewardInfo> COLIEKINOPB = new List<LCMJJMNMIKG_RewardInfo>(); // 0x10
	public List<int> DKJLFPMHDJC = new List<int>(); // 0x14
	public List<int> NPOFCCEBOGC = new List<int>(); // 0x18

	//// RVA: 0x1E59F40 Offset: 0x1E59F40 VA: 0x1E59F40
	//private bool DCEEFOKCFEC(int KELFCMEOPPM) { }

	//// RVA: 0x1E59F50 Offset: 0x1E59F50 VA: 0x1E59F50
	public bool KHEKNNFCAOI(JKNGJFOBADP BEJHIEGCGNE, bool IMBGFAJLPEK)
	{
		if (BEJHIEGCGNE.FIGHNFKAMGI.Count == 0)
			return false;
		for(int i = 0; i < BEJHIEGCGNE.FIGHNFKAMGI.Count; i++)
		{
			JKNGJFOBADP.GPPAIFNBHDP FKHPGALPAIC = BEJHIEGCGNE.FIGHNFKAMGI[i];
			if(FKHPGALPAIC.JKGFBFPIMGA < 4)
			{
				if(FKHPGALPAIC.INDDJNMPONH >= 3 && FKHPGALPAIC.INDDJNMPONH < 5)
				{
					LCMJJMNMIKG_RewardInfo rewardInfo = JPMPIFCKEHH_RewardsInfo.Find((LCMJJMNMIKG_RewardInfo GHPLINIACBB) =>
					{
						//0x1E5D914
						if ((int)GHPLINIACBB.IPMJIODJGBC != FKHPGALPAIC.INDDJNMPONH)
							return false;
						return GHPLINIACBB.BCCHOBPJJKE_SceneId == FKHPGALPAIC.BCCHOBPJJKE_SceneId;
					});
					if (rewardInfo == null)
					{
						rewardInfo = new LCMJJMNMIKG_RewardInfo();
						rewardInfo.BCCHOBPJJKE_SceneId = FKHPGALPAIC.BCCHOBPJJKE_SceneId;
						rewardInfo.IPMJIODJGBC = (CECMLGBLHHG)FKHPGALPAIC.INDDJNMPONH;
						rewardInfo.JKGFBFPIMGA = FKHPGALPAIC.JKGFBFPIMGA;
						rewardInfo.MPGNHFDGOBO = FKHPGALPAIC.MPGNHFDGOBO;
						rewardInfo.HNNAODKJGPD = FKHPGALPAIC.HNNAODKJGPD;
						rewardInfo.LBGGNGCKOJE = FKHPGALPAIC.JPIPENJGGDD < 1 ? 0 : FKHPGALPAIC.JPIPENJGGDD - 1;
						rewardInfo.FICKICOHCAD = FKHPGALPAIC.JPIPENJGGDD;
						JPMPIFCKEHH_RewardsInfo.Add(rewardInfo);
					}
					else
					{
						rewardInfo.LBGGNGCKOJE = Mathf.Min(FKHPGALPAIC.JPIPENJGGDD, rewardInfo.LBGGNGCKOJE);
						rewardInfo.FICKICOHCAD = Mathf.Max(FKHPGALPAIC.JPIPENJGGDD, rewardInfo.FICKICOHCAD);
					}
				}
				else if(FKHPGALPAIC.INDDJNMPONH == 6)
				{
					LCMJJMNMIKG_RewardInfo rewardInfo = JPMPIFCKEHH_RewardsInfo.Find((LCMJJMNMIKG_RewardInfo GHPLINIACBB) =>
					{
						//0x1E5D988
						return (int)GHPLINIACBB.IPMJIODJGBC == FKHPGALPAIC.INDDJNMPONH;
					});
					if (rewardInfo == null)
					{
						rewardInfo = new LCMJJMNMIKG_RewardInfo();
						rewardInfo.BCCHOBPJJKE_SceneId = FKHPGALPAIC.BCCHOBPJJKE_SceneId;
						rewardInfo.IPMJIODJGBC = (CECMLGBLHHG)FKHPGALPAIC.INDDJNMPONH;
						rewardInfo.JKGFBFPIMGA = FKHPGALPAIC.JKGFBFPIMGA;
						rewardInfo.MPGNHFDGOBO = FKHPGALPAIC.MPGNHFDGOBO;
						rewardInfo.HNNAODKJGPD = FKHPGALPAIC.HNNAODKJGPD;
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
				else if(FKHPGALPAIC.INDDJNMPONH == 1)
				{
					LCMJJMNMIKG_RewardInfo rewardInfo = new LCMJJMNMIKG_RewardInfo();
					rewardInfo.BCCHOBPJJKE_SceneId = FKHPGALPAIC.BCCHOBPJJKE_SceneId;
					rewardInfo.IPMJIODJGBC = (CECMLGBLHHG)FKHPGALPAIC.INDDJNMPONH;
					rewardInfo.JKGFBFPIMGA = FKHPGALPAIC.JKGFBFPIMGA;
					rewardInfo.MPGNHFDGOBO = FKHPGALPAIC.MPGNHFDGOBO;
					rewardInfo.HNNAODKJGPD = FKHPGALPAIC.HNNAODKJGPD;
					rewardInfo.LBGGNGCKOJE = FKHPGALPAIC.JPIPENJGGDD;
					rewardInfo.FICKICOHCAD = FKHPGALPAIC.JPIPENJGGDD;
					JPMPIFCKEHH_RewardsInfo.Add(rewardInfo);
				}
			}
			else if(FKHPGALPAIC.INDDJNMPONH == 1)
			{
				LCMJJMNMIKG_RewardInfo rewardInfo = new LCMJJMNMIKG_RewardInfo();
				rewardInfo.BCCHOBPJJKE_SceneId = FKHPGALPAIC.BCCHOBPJJKE_SceneId;
				rewardInfo.IPMJIODJGBC = (CECMLGBLHHG)FKHPGALPAIC.INDDJNMPONH;
				rewardInfo.JKGFBFPIMGA = FKHPGALPAIC.JKGFBFPIMGA;
				rewardInfo.MPGNHFDGOBO = FKHPGALPAIC.MPGNHFDGOBO;
				rewardInfo.HNNAODKJGPD = FKHPGALPAIC.HNNAODKJGPD;
				rewardInfo.LBGGNGCKOJE = FKHPGALPAIC.JPIPENJGGDD;
				rewardInfo.FICKICOHCAD = FKHPGALPAIC.JPIPENJGGDD;
				JPMPIFCKEHH_RewardsInfo.Add(rewardInfo);
				if(FKHPGALPAIC.OGPKHGEMLMP)
				{
					GCHFDJMNCAF d = new GCHFDJMNCAF();
					d.BCCHOBPJJKE_SceneId = FKHPGALPAIC.BCCHOBPJJKE_SceneId;
					d.JKGFBFPIMGA = FKHPGALPAIC.JKGFBFPIMGA;
					d.DMJCACIDEBM = FKHPGALPAIC.OLGCDLJFMDH;
					d.GBALGEMKJKD = 0;
					d.HMGDINKEPHJ = 1;
					COLIEKINOPB.Add(d);
				}
			}
			else
			{
				if(FKHPGALPAIC.INDDJNMPONH == 4)
				{
					LCMJJMNMIKG_RewardInfo rewardInfo = NJCMJLPPIGK.Find((LCMJJMNMIKG_RewardInfo GHPLINIACBB) =>
					{
						//0x1E5D67C
						if ((int)GHPLINIACBB.IPMJIODJGBC != FKHPGALPAIC.INDDJNMPONH)
							return false;
						return GHPLINIACBB.BCCHOBPJJKE_SceneId == FKHPGALPAIC.BCCHOBPJJKE_SceneId;
					});
					if(rewardInfo == null)
					{
						rewardInfo = new LCMJJMNMIKG_RewardInfo();
						rewardInfo.BCCHOBPJJKE_SceneId = FKHPGALPAIC.BCCHOBPJJKE_SceneId;
						rewardInfo.IPMJIODJGBC = (CECMLGBLHHG)FKHPGALPAIC.INDDJNMPONH;
						rewardInfo.JKGFBFPIMGA = FKHPGALPAIC.JKGFBFPIMGA;
						rewardInfo.MPGNHFDGOBO = FKHPGALPAIC.MPGNHFDGOBO;
						rewardInfo.HNNAODKJGPD = FKHPGALPAIC.HNNAODKJGPD;
						rewardInfo.LBGGNGCKOJE = FKHPGALPAIC.JPIPENJGGDD - 1;
						rewardInfo.FICKICOHCAD = FKHPGALPAIC.JPIPENJGGDD;
						NJCMJLPPIGK.Add(rewardInfo);
					}
					else
					{
						rewardInfo.LBGGNGCKOJE = Mathf.Min(FKHPGALPAIC.JPIPENJGGDD, rewardInfo.LBGGNGCKOJE);
						rewardInfo.FICKICOHCAD = Mathf.Max(FKHPGALPAIC.JPIPENJGGDD, rewardInfo.FICKICOHCAD);
					}
					if(FKHPGALPAIC.OGPKHGEMLMP)
					{
						if(!FKHPGALPAIC.OLGCDLJFMDH)
						{
							rewardInfo = COLIEKINOPB.Find((LCMJJMNMIKG_RewardInfo GHPLINIACBB) =>
							{
								//0x1E5D6F0
								GCHFDJMNCAF d = GHPLINIACBB as GCHFDJMNCAF;
								if (d.DMJCACIDEBM)
									return false;
								return d.BCCHOBPJJKE_SceneId == FKHPGALPAIC.BCCHOBPJJKE_SceneId;
							});
							if(rewardInfo == null)
							{
								GCHFDJMNCAF d = new GCHFDJMNCAF();
								d.BCCHOBPJJKE_SceneId = FKHPGALPAIC.BCCHOBPJJKE_SceneId;
								d.DMJCACIDEBM = false;
								d.JKGFBFPIMGA = FKHPGALPAIC.JKGFBFPIMGA;
								d.GBALGEMKJKD = FKHPGALPAIC.JPIPENJGGDD;
								d.HMGDINKEPHJ = FKHPGALPAIC.JPIPENJGGDD + 1;
								COLIEKINOPB.Add(d);
							}
							else
							{
								GCHFDJMNCAF d = rewardInfo as GCHFDJMNCAF;
								d.GBALGEMKJKD = Mathf.Min(FKHPGALPAIC.JPIPENJGGDD + 1, d.GBALGEMKJKD);
								d.HMGDINKEPHJ = Mathf.Min(FKHPGALPAIC.JPIPENJGGDD + 1, d.HMGDINKEPHJ);
							}
						}
						rewardInfo = COLIEKINOPB.Find((LCMJJMNMIKG_RewardInfo GHPLINIACBB) =>
						{
							//0x1E5D800
							GCHFDJMNCAF d = GHPLINIACBB as GCHFDJMNCAF;
							if (!d.DMJCACIDEBM)
								return false;
							return d.BCCHOBPJJKE_SceneId == FKHPGALPAIC.BCCHOBPJJKE_SceneId;
						});
						if(rewardInfo == null)
						{
							GCHFDJMNCAF d = new GCHFDJMNCAF();
							d.BCCHOBPJJKE_SceneId = FKHPGALPAIC.BCCHOBPJJKE_SceneId;
							d.DMJCACIDEBM = true;
							d.JKGFBFPIMGA = FKHPGALPAIC.JKGFBFPIMGA;
							d.GBALGEMKJKD = FKHPGALPAIC.JPIPENJGGDD;
							d.HMGDINKEPHJ = FKHPGALPAIC.JPIPENJGGDD + 1;
							COLIEKINOPB.Add(d);
						}
						else
						{
							GCHFDJMNCAF d = rewardInfo as GCHFDJMNCAF;
							d.GBALGEMKJKD = Mathf.Min(FKHPGALPAIC.JPIPENJGGDD + 1, d.GBALGEMKJKD);
							d.HMGDINKEPHJ = Mathf.Min(FKHPGALPAIC.JPIPENJGGDD + 1, d.HMGDINKEPHJ);
						}
					}
				}
				else
				{
					LCMJJMNMIKG_RewardInfo rewardInfo = new LCMJJMNMIKG_RewardInfo();
					rewardInfo.BCCHOBPJJKE_SceneId = FKHPGALPAIC.BCCHOBPJJKE_SceneId;
					rewardInfo.IPMJIODJGBC = (CECMLGBLHHG)FKHPGALPAIC.INDDJNMPONH;
					rewardInfo.JKGFBFPIMGA = FKHPGALPAIC.JKGFBFPIMGA;
					rewardInfo.MPGNHFDGOBO = FKHPGALPAIC.MPGNHFDGOBO;
					rewardInfo.HNNAODKJGPD = FKHPGALPAIC.HNNAODKJGPD;
					rewardInfo.LBGGNGCKOJE = FKHPGALPAIC.JPIPENJGGDD;
					rewardInfo.FICKICOHCAD = FKHPGALPAIC.JPIPENJGGDD;
					NJCMJLPPIGK.Add(rewardInfo);
					if (FKHPGALPAIC.OGPKHGEMLMP)
					{
						GCHFDJMNCAF d = new GCHFDJMNCAF();
						d.BCCHOBPJJKE_SceneId = FKHPGALPAIC.BCCHOBPJJKE_SceneId;
						d.DMJCACIDEBM = true;
						d.JKGFBFPIMGA = FKHPGALPAIC.JKGFBFPIMGA;
						d.GBALGEMKJKD = 0;
						d.HMGDINKEPHJ = 1;
						COLIEKINOPB.Add(d);
					}
				}
			}
		}
		NJCMJLPPIGK.Sort((LCMJJMNMIKG_RewardInfo HKICMNAACDA, LCMJJMNMIKG_RewardInfo BNKHBCBJBKI) =>
		{
			//0x1E5D328
			if(HKICMNAACDA.IPMJIODJGBC == BNKHBCBJBKI.IPMJIODJGBC)
			{
				if(HKICMNAACDA.JKGFBFPIMGA == BNKHBCBJBKI.JKGFBFPIMGA)
				{
					return HKICMNAACDA.BCCHOBPJJKE_SceneId.CompareTo(BNKHBCBJBKI.BCCHOBPJJKE_SceneId);
				}
				return HKICMNAACDA.JKGFBFPIMGA.CompareTo(BNKHBCBJBKI.JKGFBFPIMGA);
			}
			return HKICMNAACDA.IPMJIODJGBC.CompareTo(BNKHBCBJBKI.IPMJIODJGBC);
		});
		JPMPIFCKEHH_RewardsInfo.Sort((LCMJJMNMIKG_RewardInfo HKICMNAACDA, LCMJJMNMIKG_RewardInfo BNKHBCBJBKI) =>
		{
			//0x1E5D3AC
			if (HKICMNAACDA.IPMJIODJGBC == BNKHBCBJBKI.IPMJIODJGBC)
			{
				if (HKICMNAACDA.JKGFBFPIMGA == BNKHBCBJBKI.JKGFBFPIMGA)
				{
					return HKICMNAACDA.BCCHOBPJJKE_SceneId.CompareTo(BNKHBCBJBKI.BCCHOBPJJKE_SceneId);
				}
				return HKICMNAACDA.JKGFBFPIMGA.CompareTo(BNKHBCBJBKI.JKGFBFPIMGA);
			}
			return HKICMNAACDA.IPMJIODJGBC.CompareTo(BNKHBCBJBKI.IPMJIODJGBC);
		});
		COLIEKINOPB.Sort((LCMJJMNMIKG_RewardInfo HKICMNAACDA, LCMJJMNMIKG_RewardInfo BNKHBCBJBKI) =>
		{
			//0x1E5D430
			if (HKICMNAACDA.JKGFBFPIMGA == BNKHBCBJBKI.JKGFBFPIMGA)
			{
				if (HKICMNAACDA.BCCHOBPJJKE_SceneId == BNKHBCBJBKI.BCCHOBPJJKE_SceneId)
				{
					GCHFDJMNCAF h = HKICMNAACDA as GCHFDJMNCAF;
					GCHFDJMNCAF b = BNKHBCBJBKI as GCHFDJMNCAF;
					return h.DMJCACIDEBM.CompareTo(b.DMJCACIDEBM);
				}
				return HKICMNAACDA.BCCHOBPJJKE_SceneId.CompareTo(BNKHBCBJBKI.BCCHOBPJJKE_SceneId);
			}
			return HKICMNAACDA.JKGFBFPIMGA.CompareTo(BNKHBCBJBKI.JKGFBFPIMGA);
		});
		DKJLFPMHDJC.Clear();
		List<int> l = new List<int>();
		for(int i = 0; i < BEJHIEGCGNE.NNDMIOEKKMM.Count; i++)
		{
			l.Add(BEJHIEGCGNE.NNDMIOEKKMM[i]);
		}
		if (l.Count > 0)
		{
			for (int i = 0; i < NJCMJLPPIGK.Count; i++)
			{
				if (NJCMJLPPIGK[i].IPMJIODJGBC == CECMLGBLHHG.GBIDBHKEPGL/*1*/)
				{
					MLIBEPGADJH_Scene.KKLDOOJBJMN scene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[NJCMJLPPIGK[i].BCCHOBPJJKE_SceneId - 1];
					for (int j = 0; j < l.Count; j++)
					{
						if (l[j] == scene.KELFCMEOPPM_Ep)
						{
							DKJLFPMHDJC.Add(scene.KELFCMEOPPM_Ep);
							l.RemoveAt(j);
							break;
						}
					}
				}
			}
			for (int i = 0; i < JPMPIFCKEHH_RewardsInfo.Count; i++)
			{
				if (JPMPIFCKEHH_RewardsInfo[i].IPMJIODJGBC == CECMLGBLHHG.GBIDBHKEPGL/*1*/)
				{
					MLIBEPGADJH_Scene.KKLDOOJBJMN scene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[JPMPIFCKEHH_RewardsInfo[i].BCCHOBPJJKE_SceneId - 1];
					for (int j = 0; j < l.Count; j++)
					{
						if (l[j] == scene.KELFCMEOPPM_Ep)
						{
							DKJLFPMHDJC.Add(scene.KELFCMEOPPM_Ep);
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
			if(BEJHIEGCGNE.FJKAMPIMFLP[i].KELFCMEOPPM_Ep > 1)
			{
				HMGPODKEFBA_EpisodeInfo MABBBOEAPAA = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[BEJHIEGCGNE.FJKAMPIMFLP[i].KELFCMEOPPM_Ep - 1];
				FMLIFJBPFNA_Step step = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.KODIKHBMBBJ_Steps.Find((FMLIFJBPFNA_Step GHPLINIACBB) =>
				{
					//0x1E5D9D4
					return GHPLINIACBB.IOFHEGJPHKG_SId == MABBBOEAPAA.IOFHEGJPHKG_StepId;
				});
				int pt = step.JENFHJDFFAD_Pt[MABBBOEAPAA.FGOGPCMHPIN_Count - 2];
				if (BEJHIEGCGNE.FJKAMPIMFLP[i].DNBFMLBNAEE < pt && pt <= PIGBBNDPPJC.GMDHJBGLBEI(BEJHIEGCGNE.FJKAMPIMFLP[i].KELFCMEOPPM_Ep, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave))
				{
					NPOFCCEBOGC.Add(BEJHIEGCGNE.FJKAMPIMFLP[i].KELFCMEOPPM_Ep);
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
	//public void NFOHOGAJGHB(List<int> CGCFENMHJIM, List<int> PIHPOPCPAHL, bool IMBGFAJLPEK) { }

	//// RVA: 0x1E5C984 Offset: 0x1E5C984 VA: 0x1E5C984
	public bool LBHPMGDNPHK(CECMLGBLHHG INDDJNMPONH)
	{
		List<LCMJJMNMIKG_RewardInfo> l1 = new List<LCMJJMNMIKG_RewardInfo>();
		List<LCMJJMNMIKG_RewardInfo> l2 = new List<LCMJJMNMIKG_RewardInfo>();
		List<int> l3 = new List<int>();
		return JDKOAKDLHMG(INDDJNMPONH, ref l1, ref l2, ref l3);
	}

	//// RVA: 0x1E5CA78 Offset: 0x1E5CA78 VA: 0x1E5CA78
	public bool JDKOAKDLHMG(CECMLGBLHHG INDDJNMPONH, ref List<LCMJJMNMIKG_RewardInfo> PJFOENCFNEK, ref List<LCMJJMNMIKG_RewardInfo> MPCJGPEBCCD, ref List<int> BBAJKJPKOHD)
	{
		PJFOENCFNEK.Clear();
		MPCJGPEBCCD.Clear();
		BBAJKJPKOHD.Clear();
		List<LCMJJMNMIKG_RewardInfo> rewards = NJCMJLPPIGK.FindAll((LCMJJMNMIKG_RewardInfo JPAEDJJFFOI) =>
		{
			//0x1E5D60C
			return JPAEDJJFFOI.IPMJIODJGBC == INDDJNMPONH;
		});
		List<LCMJJMNMIKG_RewardInfo> rewards2 = JPMPIFCKEHH_RewardsInfo.FindAll((LCMJJMNMIKG_RewardInfo JPAEDJJFFOI) =>
		{
			//0x1E5D644
			return JPAEDJJFFOI.IPMJIODJGBC == INDDJNMPONH;
		});
		if(INDDJNMPONH == CECMLGBLHHG.INJNLJHGGKB_4/*4*/)
		{
			List<LCMJJMNMIKG_RewardInfo> rewards3 = NJCMJLPPIGK.FindAll((LCMJJMNMIKG_RewardInfo JPAEDJJFFOI) =>
			{
				//0x1E5D5AC
				return JPAEDJJFFOI.IPMJIODJGBC == CECMLGBLHHG.NNEOHGFGLKM_3/*3*/;
			});
			rewards.InsertRange(0, rewards3);
			rewards3 = JPMPIFCKEHH_RewardsInfo.FindAll((LCMJJMNMIKG_RewardInfo JPAEDJJFFOI) =>
			{
				//0x1E5D5DC
				return JPAEDJJFFOI.IPMJIODJGBC == CECMLGBLHHG.NNEOHGFGLKM_3/*3*/;
			});
			rewards2.InsertRange(0, rewards3);
		}
		switch(INDDJNMPONH)
		{
			case CECMLGBLHHG.AGLFBCCGHJM_2/*2*/:
				BBAJKJPKOHD.AddRange(DKJLFPMHDJC);
				break;
			case CECMLGBLHHG.NNEOHGFGLKM_3/*3*/:
				PJFOENCFNEK.AddRange(rewards);
				MPCJGPEBCCD.AddRange(rewards);
				MPCJGPEBCCD.AddRange(rewards2);
				break;
			default:
				MPCJGPEBCCD.AddRange(rewards);
				MPCJGPEBCCD.AddRange(rewards2);
				break;
			case CECMLGBLHHG.BKHAAGAAIHJ_7/*7*/:
				BBAJKJPKOHD.AddRange(NPOFCCEBOGC);
				break;
			case CECMLGBLHHG.JCGKGFLCKCP_8/*8*/:
				MPCJGPEBCCD.AddRange(COLIEKINOPB);
				break;
		}
		if(PJFOENCFNEK.Count < 1)
		{
			if(MPCJGPEBCCD.Count < 1)
			{
				return BBAJKJPKOHD.Count > 0;
			}
		}
		return true;
	}
}
