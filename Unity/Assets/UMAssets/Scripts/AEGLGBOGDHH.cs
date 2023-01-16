
using XeApp.Game.Common;

public enum MKHCIKICBOI
{
	BICPBLMPBPH_Soul = 1,
	GPCMMGOCPHC_Vocal = 2,
	LGOHMPBLPKA_Charm = 4,
	ECHJOKLBHEJ_Life = 8,
	AHJNCHAONGN_Support = 16,
	ONBNGGDFAJK_Fold = 32,
	OHOKFCJNFDO = 64,
	MKADAMIGMPO_SoulVocalCharm = 7,
}

public struct AEGLGBOGDHH
{
	public EDMIONMCICN[] GJLJJDIDODK; // 0x0
	public EDMIONMCICN JPMGNPAHGIB; // 0x4
	public CFHDKAFLNEP CLCIOEHGFNI; // 0x28

	//// RVA: 0x7FCFC4 Offset: 0x7FCFC4 VA: 0x7FCFC4
	public void OBKGEDCKHHE()
	{
		GJLJJDIDODK = new EDMIONMCICN[3];
		for(int i = 0; i < GJLJJDIDODK.Length; i++)
		{
			GJLJJDIDODK[i].OBKGEDCKHHE_Reset();
		}
		JPMGNPAHGIB = new EDMIONMCICN();
		JPMGNPAHGIB.OBKGEDCKHHE_Reset();
		CLCIOEHGFNI = new CFHDKAFLNEP();
		CLCIOEHGFNI.OBKGEDCKHHE();
	}

	//// RVA: 0x7FCFCC Offset: 0x7FCFCC VA: 0x7FCFCC
	public void JCHLONCMPAJ()
	{
		TodoLogger.Log(0, "JCHLONCMPAJ");
	}

	//// RVA: 0x7FCFD4 Offset: 0x7FCFD4 VA: 0x7FCFD4
	public void GEEDEOHGMOM(ref StatusData MGFGADBHOFJ)
	{
		TodoLogger.Log(0, "GEEDEOHGMOM");
	}

	//// RVA: 0x7FCFDC Offset: 0x7FCFDC VA: 0x7FCFDC
	public void DDPJACNMPEJ(ref StatusData MGFGADBHOFJ)
	{
		TodoLogger.Log(0, "DDPJACNMPEJ");
	}

	//// RVA: 0x7FCFE4 Offset: 0x7FCFE4 VA: 0x7FCFE4
	//public int COCIPAJKDAF() { }

	//// RVA: 0x7FCFEC Offset: 0x7FCFEC VA: 0x7FCFEC
	public void DIJOPLHIMBO(JGEOBNENMAH.NEDILFPPCJF BGDCOKFCCBO, StatusData HFEMKGEOHJL, StatusData PDIPANKOKOL, int IFCPCIHJANL, int LCIPPBOFPOB)
	{
		TodoLogger.Log(0, "DIJOPLHIMBO");
	}

	//// RVA: 0x7FD014 Offset: 0x7FD014 VA: 0x7FD014
	//public int ABEDECHGFAG(JLKEOGLJNOD HEDKFICAPIJ) { }

	//// RVA: 0x7FD01C Offset: 0x7FD01C VA: 0x7FD01C
	public bool IJACIMIPBBK_IsBufftarget(MKHCIKICBOI ICPDDMIBEIL)
	{
		for (int i = 0; i < GJLJJDIDODK.Length; i++)
		{
			if ((GJLJJDIDODK[i].LGGLFAECCBK_BonusTypeFlag & ICPDDMIBEIL) != 0)
				return true;
		}
		return (JPMGNPAHGIB.LGGLFAECCBK_BonusTypeFlag & ICPDDMIBEIL) != 0;
	}

	//// RVA: 0x7FD024 Offset: 0x7FD024 VA: 0x7FD024
	public bool ADENHAHPBCJ_IsDebuffTarget(MKHCIKICBOI ICPDDMIBEIL)
	{
		for(int i = 0; i < GJLJJDIDODK.Length; i++)
		{
			if ((GJLJJDIDODK[i].NOEFMBAIAMP_MalusTypeFlag & ICPDDMIBEIL) != 0)
				return true;
		}
		return (JPMGNPAHGIB.NOEFMBAIAMP_MalusTypeFlag & ICPDDMIBEIL) != 0;
	}
}
