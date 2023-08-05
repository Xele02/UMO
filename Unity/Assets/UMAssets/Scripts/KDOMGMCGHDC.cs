
using XeApp.Game.Common;
using XeSys;

public class KDOMGMCGHDC
{
	public class HJNMIKNAMFH
	{
		public bool HHBJAEOIGIH_IsLocked; // 0x8
		public bool NBHEBLNHOJO_IsMax; // 0x9
		public int LHBDCGFOKCA_DivaId; // 0xC
		public int CEFHDLLAPDH_MusicId; // 0x10
		public int KDGIHMCBLND_MusicLevel; // 0x14
		public int EHBAJPHFDOK_NextLevel; // 0x18
		public int PBGFIOONCMB_NextLevelMusicExp; // 0x1C
		public int PMBFNFOCNAJ_CurLevelMusicExp; // 0x20
		public string ONIAMNAJLKI_LockMessage = JpStringLiterals.StringLiteral_12215; // 0x24

		//// RVA: 0xE86F90 Offset: 0xE86F90 VA: 0xE86F90
		//public void ODDIHGPONFL(KDOMGMCGHDC.HJNMIKNAMFH GPBJHKLFCEP) { }
	}

	//// RVA: 0xE862CC Offset: 0xE862CC VA: 0xE862CC
	public static HJNMIKNAMFH ODIAFJCPIFO(int DLAEJOBELBH_MusicId, int AHHJLDLAPAN_DivaId, BBHNACPENDM_ServerSaveData AHEFHIMGIBI_SaveServer, int EFFAFONBNFM_PrevMusicLevel)
	{
		DEKKMGAFJCG_Diva saveDiva = AHEFHIMGIBI_SaveServer.DGCJCAHIAPP_Diva;
		HJNMIKNAMFH res = new HJNMIKNAMFH();
		LPPGENBEECK_MusicMaster dbMusic = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music;
		JJOPEDJCCJK_Exp dbExp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FMPEMFPLPDA_Exp;
		res.EHBAJPHFDOK_NextLevel = EFFAFONBNFM_PrevMusicLevel + 1;
		res.KDGIHMCBLND_MusicLevel = 0;
		res.CEFHDLLAPDH_MusicId = 0;
		res.LHBDCGFOKCA_DivaId = 0;
		res.HHBJAEOIGIH_IsLocked = false;
		res.NBHEBLNHOJO_IsMax = false;

		res.PBGFIOONCMB_NextLevelMusicExp = dbExp.IECLHMBPEIJ_GetMusicExp(EFFAFONBNFM_PrevMusicLevel + 1);
		res.PMBFNFOCNAJ_CurLevelMusicExp = dbExp.IECLHMBPEIJ_GetMusicExp(EFFAFONBNFM_PrevMusicLevel);
		res.ONIAMNAJLKI_LockMessage = "";
		HMJHLLPBCLD h = dbMusic.KCBOGEBCMMJ(HMJHLLPBCLD.ABDFBABHIHJ_GetId(DLAEJOBELBH_MusicId, AHHJLDLAPAN_DivaId, res.EHBAJPHFDOK_NextLevel));
		if(h != null)
		{
			if(h.CEFHDLLAPDH_MusicId == 0)
			{
				if(saveDiva.LGKFMLIOPKL_GetDivaInfo(h.LHBDCGFOKCA_DivaId).OKMELNIIMMO_GetDivaLevel() < h.KDGIHMCBLND_MusicLevel)
				{
					res.HHBJAEOIGIH_IsLocked = true;
					res.KDGIHMCBLND_MusicLevel = h.KDGIHMCBLND_MusicLevel;
					res.LHBDCGFOKCA_DivaId = h.LHBDCGFOKCA_DivaId;
					res.PBGFIOONCMB_NextLevelMusicExp = dbExp.IECLHMBPEIJ_GetMusicExp(EFFAFONBNFM_PrevMusicLevel);
					res.PMBFNFOCNAJ_CurLevelMusicExp = dbExp.IECLHMBPEIJ_GetMusicExp(EFFAFONBNFM_PrevMusicLevel - 1);
					res.ONIAMNAJLKI_LockMessage = string.Format(MessageManager.Instance.GetMessage("common", "mlv_unlock_00"), MessageManager.Instance.GetMessage("master", "diva_" + h.LHBDCGFOKCA_DivaId.ToString("D2")), res.KDGIHMCBLND_MusicLevel);
				}
			}
			else if(h.LHBDCGFOKCA_DivaId != 0)
			{
				int currentMusicLevel = saveDiva.LGKFMLIOPKL_GetDivaInfo(h.LHBDCGFOKCA_DivaId).ANAJIAENLNB_Levels[h.CEFHDLLAPDH_MusicId - 1];
				if(currentMusicLevel < h.KDGIHMCBLND_MusicLevel)
				{
					res.HHBJAEOIGIH_IsLocked = true;
					res.KDGIHMCBLND_MusicLevel = h.KDGIHMCBLND_MusicLevel;
					res.LHBDCGFOKCA_DivaId = h.LHBDCGFOKCA_DivaId;
					res.CEFHDLLAPDH_MusicId = h.CEFHDLLAPDH_MusicId;
					res.PBGFIOONCMB_NextLevelMusicExp = dbExp.IECLHMBPEIJ_GetMusicExp(EFFAFONBNFM_PrevMusicLevel);
					res.PMBFNFOCNAJ_CurLevelMusicExp = dbExp.IECLHMBPEIJ_GetMusicExp(EFFAFONBNFM_PrevMusicLevel - 1);
					res.ONIAMNAJLKI_LockMessage = string.Format(MessageManager.Instance.GetMessage("common", "mlv_unlock_01"), Database.Instance.musicText.Get(dbMusic.IAJLOELFHKC_GetMusicInfo(h.CEFHDLLAPDH_MusicId).KNMGEEFGDNI_Nam).musicName, MessageManager.Instance.GetMessage("master", "diva_" + h.LHBDCGFOKCA_DivaId.ToString("D2")), res.KDGIHMCBLND_MusicLevel);
				}
			}
		}
		if(res.EHBAJPHFDOK_NextLevel > 8)
		{
			res.EHBAJPHFDOK_NextLevel = 8;
			res.NBHEBLNHOJO_IsMax = true;
			res.PBGFIOONCMB_NextLevelMusicExp = dbExp.IECLHMBPEIJ_GetMusicExp(res.EHBAJPHFDOK_NextLevel);
			res.PMBFNFOCNAJ_CurLevelMusicExp = dbExp.IECLHMBPEIJ_GetMusicExp(res.EHBAJPHFDOK_NextLevel - 1);
		}
		return res;
	}

	//// RVA: 0xE86F00 Offset: 0xE86F00 VA: 0xE86F00
	public static HJNMIKNAMFH NEGKGKKLICK(int DLAEJOBELBH_MusicId, int AHHJLDLAPAN_DivaId, BBHNACPENDM_ServerSaveData AHEFHIMGIBI_SaveData)
	{
		int level = 0;
		HJNMIKNAMFH res = null;
		do
		{
			res = ODIAFJCPIFO(DLAEJOBELBH_MusicId, AHHJLDLAPAN_DivaId, AHEFHIMGIBI_SaveData, level);
		} while (!res.NBHEBLNHOJO_IsMax && !res.HHBJAEOIGIH_IsLocked && level++ < 8);
		return res;
	}

	//// RVA: 0xE86F74 Offset: 0xE86F74 VA: 0xE86F74
	public static bool BKEMLLBKELP(int DMBFOMLCGBG)
	{
		return DMBFOMLCGBG > 7;
	}
}
