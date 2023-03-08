
public class JGJFFKPFMDB
{
	//private static byte[] DHDKJHKLANF = new byte[354] { D076F2AF3362484BF2F6E9A97E936F1ACAD5E778 }; // 0x0
	//private static byte[] EEJKKEGNMOF = new byte[354] { FF1E8A0971CA29778EE93FD860FA0175D084D27D }; // 0x4
	//private static byte[] OCEGPGLGMDG = new byte[354] { 033678FF46D446B3E5D372B90F9F3DB4F1536FBD }; // 0x8
	//private static byte[] BHLIFCPBHPO = new byte[354] { 0F1A77316EFCEA8D39BE35EA9C78F348CD5E4603 }; // 0xC
	private static string[] ECLAOLBGCDD = new string[5] { "common", "saka_error", "0000", JpStringLiterals.StringLiteral_11920, "000" }; // 0x10

	//// RVA: 0xB19964 Offset: 0xB19964 VA: 0xB19964
	//public static GOBDOEHKLHN BDPBNKPKAJJ(SakashoErrorId PPFNGGCBJKC) { }

	//// RVA: 0xB19A8C Offset: 0xB19A8C VA: 0xB19A8C
	//public static int JDDJKAJOJHK(SakashoErrorId PPFNGGCBJKC, bool AAIOCNJGNEN) { }

	//// RVA: 0xB19C5C Offset: 0xB19C5C VA: 0xB19C5C
	//public static string NCDHNMILIOJ(SakashoErrorId PPFNGGCBJKC, bool AAIOCNJGNEN) { }

	//// RVA: 0xB1A9A4 Offset: 0xB1A9A4 VA: 0xB1A9A4
	public static bool BDGBCCGLLAJ_IsRankingError(SakashoErrorId PPFNGGCBJKC)
	{
		if (PPFNGGCBJKC != SakashoErrorId.RANKING_REWARD_NOT_FOUND && (PPFNGGCBJKC < SakashoErrorId.RANKING_CLOSED || PPFNGGCBJKC > SakashoErrorId.REGULAR_RANKING_NOT_GENERATED))
			return PPFNGGCBJKC == SakashoErrorId.RANKING_DROPPED_PLAYER;
		return true;
	}

	//// RVA: 0xB1A9D8 Offset: 0xB1A9D8 VA: 0xB1A9D8
	public static bool NBDHKIGADLF(SakashoErrorId PPFNGGCBJKC)
	{
		TodoLogger.Log(0, "NBDHKIGADLF");
		return false;
	}

	//// RVA: 0xB1AA0C Offset: 0xB1AA0C VA: 0xB1AA0C
	//public static string HHAEOPHPCEF(SakashoErrorId PPFNGGCBJKC) { }

	//// RVA: 0xB1AD28 Offset: 0xB1AD28 VA: 0xB1AD28
	//public static bool DHHKMLMJCIK(SakashoErrorId PPFNGGCBJKC) { }

	//// RVA: 0xB1AD48 Offset: 0xB1AD48 VA: 0xB1AD48
	//public static bool IOGGLELGHLO(SakashoErrorId PPFNGGCBJKC) { }

	//// RVA: 0xB1AD5C Offset: 0xB1AD5C VA: 0xB1AD5C
	//public static bool PLMJFNPGOCD(SakashoErrorId PPFNGGCBJKC) { }
}
