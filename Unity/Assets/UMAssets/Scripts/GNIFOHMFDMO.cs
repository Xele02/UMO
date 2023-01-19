
using System.Collections.Generic;
using XeApp.Game.Common;

[System.Obsolete("Use GNIFOHMFDMO_DivaResultData", true)]
public class GNIFOHMFDMO { }
public class GNIFOHMFDMO_DivaResultData
{
	public class IKODHMDOMMP
	{
		public int AHHJLDLAPAN_DivaId; // 0x8
		public double NMHNDLHJENB_PrevMusicExp; // 0x10
		public double CFDGFLNIMCL_MusicExp; // 0x18
		public double BKJJLJKGDJB_MusicExpDiff; // 0x20
		public double HMBECPGHPOE; // 0x28
		public int IIHHAFPPFCP_PrevMusicLevel; // 0x30
		public int AIMAJDEJDLM_MusicLevel; // 0x34
		public int PKLPGBKKFOL; // 0x38
		public double NFJFBOBJONF_PrevExpFrag; // 0x40
		public double DKLBOOEIKKL_ExpFrag; // 0x48
		public double MECHKMMEIPP; // 0x50
		public double KNCMFPIODKJ_ExpFragDiff; // 0x58
		public double FADHHKOGJIP; // 0x60
		public int AJCEIPJDMEC_PrevDivaLevel; // 0x68
		public int JPGEAFPDHDE_DivaLevel; // 0x6C
		public int PAOGPLDOMMI; // 0x70
		public KDOMGMCGHDC.HJNMIKNAMFH EEHOJJNJJAI; // 0x74
		public KDOMGMCGHDC.HJNMIKNAMFH OJLEDBKKMLN; // 0x78
		public int DACHHLHPAAB; // 0x7C
	}

	public int AKNELONELJK; // 0x8
	public int OGFBKCGGPBC; // 0xC
	public int GCAPLLEIAAI_LastScore; // 0x10
	public int FFEBMCAKOHK; // 0x14
	public int BMGKGDPKJFA; // 0x18
	public int CBCIFACJGHI; // 0x1C
	public int DLAEJOBELBH_MusicId; // 0x20
	private int DHJAFJKALCA_ForcedMusicId; // 0x24
	public bool LFGNLKKFOCD_Is6Line; // 0x28
	public int HGHMMDOEGEF; // 0x2C
	public List<IKODHMDOMMP> NAIHIJAJPNK; // 0x30

	//public int IOPCBBNHJIP { get; set; } 0x1E56110 PJKILEHFBHA 0x1E56124 BOBNBADBNGG

	//// RVA: 0x1E5612C Offset: 0x1E5612C VA: 0x1E5612C
	//public KDOMGMCGHDC.HJNMIKNAMFH LNHIFELKOJF(int AAIKJJHPEEL, int BAKLKJLPLOJ) { }

	//// RVA: 0x1E56244 Offset: 0x1E56244 VA: 0x1E56244
	//public int HMHJOEMJOKE() { }

	//// RVA: 0x1E56334 Offset: 0x1E56334 VA: 0x1E56334
	public void KHEKNNFCAOI(int GHBPLHBNMBK_FreeMusicId, bool GIKLNODJKFK_IsLine6)
	{
		KEODKEGFDLD_FreeMusicInfo GEAANLPDJBP = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(GHBPLHBNMBK_FreeMusicId);
		DLAEJOBELBH_MusicId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(GEAANLPDJBP.DLAEJOBELBH_MusicId).DLAEJOBELBH_Id;
		AIPEHINPIHC_ForcedSettingInfo forcedSetting = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.HBJDIFMCGAL_ForcedSettings.Find((AIPEHINPIHC_ForcedSettingInfo GHPLINIACBB) =>
		{
			//0x1E59250
			return GEAANLPDJBP.BLDDNEJDFON_ForcePrismId == GHPLINIACBB.NMNDNFFJHPJ_Id;
		});
		if (forcedSetting != null)
			DHJAFJKALCA_ForcedMusicId = forcedSetting.IOPCBBNHJIP_MusicId;
		AKNELONELJK = JGEOBNENMAH.HHCJCDFCLOB.LBLOIOMNEIH_Difficulty;
		OGFBKCGGPBC = JGEOBNENMAH.HHCJCDFCLOB.NGDDIIDJFNG;
		GCAPLLEIAAI_LastScore = JGEOBNENMAH.HHCJCDFCLOB.GCAPLLEIAAI_LastScore;
		FFEBMCAKOHK = JGEOBNENMAH.HHCJCDFCLOB.LKGONGDLJBH + 100;
		BMGKGDPKJFA = JGEOBNENMAH.HHCJCDFCLOB.MKEPHNGLHDL;
		LFGNLKKFOCD_Is6Line = GIKLNODJKFK_IsLine6;
		CBCIFACJGHI = JGEOBNENMAH.HHCJCDFCLOB.CBCIFACJGHI;
		HGHMMDOEGEF = JGEOBNENMAH.HHCJCDFCLOB.HGHMMDOEGEF;
		JJOPEDJCCJK_Exp dbExp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FMPEMFPLPDA_Exp;
		DEKKMGAFJCG_Diva saveDiva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva;
		DEKKMGAFJCG_Diva prevSaveDiva = CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData.DGCJCAHIAPP_Diva;
		NAIHIJAJPNK = new List<IKODHMDOMMP>(5);
		for(int i = 0; i < JGEOBNENMAH.HHCJCDFCLOB.AMJFOGHBFKJ_DivaIds.Count; i++)
		{
			IKODHMDOMMP data = new IKODHMDOMMP();
			int val = JGEOBNENMAH.HHCJCDFCLOB.AMJFOGHBFKJ_DivaIds[i];
			data.AHHJLDLAPAN_DivaId = val;
			if(val != 0)
			{
				DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo prevSaveDivaInfo = prevSaveDiva.LGKFMLIOPKL_GetDivaInfo(data.AHHJLDLAPAN_DivaId);
				DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo saveDivaInfo = saveDiva.LGKFMLIOPKL_GetDivaInfo(data.AHHJLDLAPAN_DivaId);
				data.NMHNDLHJENB_PrevMusicExp = prevSaveDivaInfo.LKIFDCEKDCK_Exps[DLAEJOBELBH_MusicId - 1];
				data.CFDGFLNIMCL_MusicExp = saveDivaInfo.LKIFDCEKDCK_Exps[DLAEJOBELBH_MusicId - 1];
				data.BKJJLJKGDJB_MusicExpDiff = data.CFDGFLNIMCL_MusicExp - data.NMHNDLHJENB_PrevMusicExp;
				data.HMBECPGHPOE = data.NMHNDLHJENB_PrevMusicExp;
				data.IIHHAFPPFCP_PrevMusicLevel = prevSaveDivaInfo.ANAJIAENLNB_Levels[DLAEJOBELBH_MusicId - 1];
				data.AIMAJDEJDLM_MusicLevel = saveDivaInfo.ANAJIAENLNB_Levels[DLAEJOBELBH_MusicId - 1];
				data.PKLPGBKKFOL = data.IIHHAFPPFCP_PrevMusicLevel;
				data.NFJFBOBJONF_PrevExpFrag = prevSaveDivaInfo.ACABEFKBBEN_ExpFrag;
				data.DKLBOOEIKKL_ExpFrag = saveDivaInfo.ACABEFKBBEN_ExpFrag;
				data.FADHHKOGJIP = 0;
				data.MECHKMMEIPP = data.NFJFBOBJONF_PrevExpFrag;
				data.KNCMFPIODKJ_ExpFragDiff = data.DKLBOOEIKKL_ExpFrag - data.NFJFBOBJONF_PrevExpFrag;
				data.AJCEIPJDMEC_PrevDivaLevel = prevSaveDivaInfo.OKMELNIIMMO_GetDivaLevel();
				data.JPGEAFPDHDE_DivaLevel = saveDivaInfo.OKMELNIIMMO_GetDivaLevel();
				data.PAOGPLDOMMI = data.AJCEIPJDMEC_PrevDivaLevel;
				data.EEHOJJNJJAI = KDOMGMCGHDC.ODIAFJCPIFO(DLAEJOBELBH_MusicId, data.AHHJLDLAPAN_DivaId, CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData, data.IIHHAFPPFCP_PrevMusicLevel);
				data.OJLEDBKKMLN = KDOMGMCGHDC.NEGKGKKLICK(DLAEJOBELBH_MusicId, data.AHHJLDLAPAN_DivaId, CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData);
				if(JGEOBNENMAH.HHCJCDFCLOB.HMMFHMHENAO != null)
				{
					int a = JGEOBNENMAH.HHCJCDFCLOB.HMMFHMHENAO.MPHGKGNCCEE(data.AHHJLDLAPAN_DivaId, AKNELONELJK);
					int b = Database.Instance.gameSetup.LiveSkipTicketCount;
					if (!Database.Instance.gameSetup.EnableLiveSkip)
						b = 1;
					if (Database.Instance.gameSetup.LiveSkipTicketCount < 2)
						b = 1;
					data.DACHHLHPAAB = a * b;
				}
				NAIHIJAJPNK.Add(data);
			}
		}
	}

	//// RVA: 0x1E56DA4 Offset: 0x1E56DA4 VA: 0x1E56DA4
	//public void NFOHOGAJGHB(int GHBPLHBNMBK) { }

	//// RVA: 0x1E577F4 Offset: 0x1E577F4 VA: 0x1E577F4
	//public void AJMKBHHAIEB(int GHBPLHBNMBK, int HMBECPGHPOE, int[] AHHJLDLAPAN, int[] OELBLDNDMBN, int[] BCCEPIHPKAH) { }

	//// RVA: 0x1E58660 Offset: 0x1E58660 VA: 0x1E58660
	//public bool NEINFNHHACO(LMLIDBBMBKJ KANEPEKDFLA, PNABDOFAFAB HANMMPCJKJE) { }

	//// RVA: 0x1E586A8 Offset: 0x1E586A8 VA: 0x1E586A8
	//public bool NAPBBCANJPO(double JMGAFJBEMDK, double DIOEOCLNFNN, double MONDMKECDJL, LMLIDBBMBKJ KANEPEKDFLA, PNABDOFAFAB HANMMPCJKJE) { }

	//// RVA: 0x1E58B98 Offset: 0x1E58B98 VA: 0x1E58B98
	//public string EMOLIPLIIAJ() { }
}
