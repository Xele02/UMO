
public class KDOMGMCGHDC
{
	public class HJNMIKNAMFH
	{
		public bool HHBJAEOIGIH; // 0x8
		public bool NBHEBLNHOJO; // 0x9
		public int LHBDCGFOKCA; // 0xC
		public int CEFHDLLAPDH; // 0x10
		public int KDGIHMCBLND; // 0x14
		public int EHBAJPHFDOK_NextLevel; // 0x18
		public int PBGFIOONCMB_NextLevelMusicExp; // 0x1C
		public int PMBFNFOCNAJ_CurLevelMusicExp; // 0x20
		public string ONIAMNAJLKI = JpStringLiterals.StringLiteral_12215; // 0x24

		//// RVA: 0xE86F90 Offset: 0xE86F90 VA: 0xE86F90
		//public void ODDIHGPONFL(KDOMGMCGHDC.HJNMIKNAMFH GPBJHKLFCEP) { }
	}

	//// RVA: 0xE862CC Offset: 0xE862CC VA: 0xE862CC
	public static HJNMIKNAMFH ODIAFJCPIFO(int DLAEJOBELBH_MusicId, int AHHJLDLAPAN_DivaId, BBHNACPENDM_ServerSaveData AHEFHIMGIBI_SaveServer, int EFFAFONBNFM_PrevMusicLevel)
	{
		DEKKMGAFJCG_Diva saveDiva = AHEFHIMGIBI_SaveServer.DGCJCAHIAPP_Diva;
		HJNMIKNAMFH res = new HJNMIKNAMFH();
		LPPGENBEECK_musicMaster dbMusic = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music;
		JJOPEDJCCJK_Exp dbExp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FMPEMFPLPDA_Exp;
		res.EHBAJPHFDOK_NextLevel = EFFAFONBNFM_PrevMusicLevel + 1;
		res.KDGIHMCBLND = 0;
		res.CEFHDLLAPDH = 0;
		res.LHBDCGFOKCA = 0;
		res.HHBJAEOIGIH = false;
		res.NBHEBLNHOJO = false;

		res.PBGFIOONCMB_NextLevelMusicExp = dbExp.IECLHMBPEIJ_GetMusicExp(EFFAFONBNFM_PrevMusicLevel + 1);
		res.PMBFNFOCNAJ_CurLevelMusicExp = dbExp.IECLHMBPEIJ_GetMusicExp(EFFAFONBNFM_PrevMusicLevel);
		res.ONIAMNAJLKI = "";
		HMJHLLPBCLD h = dbMusic.KCBOGEBCMMJ(HMJHLLPBCLD.ABDFBABHIHJ(DLAEJOBELBH_MusicId, AHHJLDLAPAN_DivaId, res.EHBAJPHFDOK_NextLevel));
		if(h != null)
		{
			if(h.CEFHDLLAPDH == 0)
			{
				if(saveDiva.LGKFMLIOPKL_GetDivaInfo(h.LHBDCGFOKCA).OKMELNIIMMO_GetDivaLevel() < h.KDGIHMCBLND)
				{
					res.HHBJAEOIGIH = true;
					res.KDGIHMCBLND = h.KDGIHMCBLND;
					res.LHBDCGFOKCA = h.LHBDCGFOKCA;
					res.PBGFIOONCMB_NextLevelMusicExp = dbExp.IECLHMBPEIJ_GetMusicExp(EFFAFONBNFM_PrevMusicLevel);
					res.PMBFNFOCNAJ_CurLevelMusicExp = 
						//L169
				}
			}
		}
	}

	//// RVA: 0xE86F00 Offset: 0xE86F00 VA: 0xE86F00
	//public static HJNMIKNAMFH NEGKGKKLICK(int DLAEJOBELBH, int AHHJLDLAPAN, BBHNACPENDM AHEFHIMGIBI) { }

	//// RVA: 0xE86F74 Offset: 0xE86F74 VA: 0xE86F74
	//public static bool BKEMLLBKELP(int DMBFOMLCGBG) { }
}
