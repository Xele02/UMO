
using XeApp.Game.Common;

public enum MKHCIKICBOI
{
	BICPBLMPBPH_Soul = 1,
	GPCMMGOCPHC_Vocal = 2,
	LGOHMPBLPKA_Charm = 4,
	ECHJOKLBHEJ_Life = 8,
	AHJNCHAONGN_Support = 16,
	ONBNGGDFAJK_Fold = 32,
	OHOKFCJNFDO_Luck = 64,
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
			GJLJJDIDODK[i].OBKGEDCKHHE_Init();
		}
		JPMGNPAHGIB = new EDMIONMCICN();
		JPMGNPAHGIB.OBKGEDCKHHE_Init();
		CLCIOEHGFNI = new CFHDKAFLNEP();
		CLCIOEHGFNI.OBKGEDCKHHE();
	}

	//// RVA: 0x7FCFCC Offset: 0x7FCFCC VA: 0x7FCFCC
	public void JCHLONCMPAJ()
	{
		for(int i = 0; i < GJLJJDIDODK.Length; i++)
		{
			GJLJJDIDODK[i].JCHLONCMPAJ_Reset();
		}
		JPMGNPAHGIB.JCHLONCMPAJ_Reset();
		CLCIOEHGFNI.JCHLONCMPAJ();
	}

	//// RVA: 0x7FCFD4 Offset: 0x7FCFD4 VA: 0x7FCFD4
	public void GEEDEOHGMOM(ref StatusData MGFGADBHOFJ)
	{
		MGFGADBHOFJ.Clear();
		for(int i = 0; i < GJLJJDIDODK.Length; i++)
		{
			MGFGADBHOFJ.Add(GJLJJDIDODK[i].ELFAIDEBLJB);
			MGFGADBHOFJ.Add(GJLJJDIDODK[i].BJABFKMIJHB_StatusMainScene);
			for(int j = 0; j < GJLJJDIDODK[i].OBCPFDNKLMM_StatusSubScenes.Length; j++)
			{
				MGFGADBHOFJ.Add(GJLJJDIDODK[i].OBCPFDNKLMM_StatusSubScenes[j]);
			}
		}
		MGFGADBHOFJ.Add(JPMGNPAHGIB.BJABFKMIJHB_StatusMainScene);
	}

	//// RVA: 0x7FCFDC Offset: 0x7FCFDC VA: 0x7FCFDC
	public void DDPJACNMPEJ(ref StatusData MGFGADBHOFJ)
	{
		MGFGADBHOFJ.Clear();
		for (int i = 0; i < GJLJJDIDODK.Length; i++)
		{
			MGFGADBHOFJ.Add(GJLJJDIDODK[i].IMLGBMGIACC);
			MGFGADBHOFJ.Add(GJLJJDIDODK[i].AJINBLGCBMM_StatusCostumeMainScene);
			for (int j = 0; j < GJLJJDIDODK[i].FEGNMIGJMDM_CostumeSubScene.Length; j++)
			{
				MGFGADBHOFJ.Add(GJLJJDIDODK[i].FEGNMIGJMDM_CostumeSubScene[j]);
			}
		}
		MGFGADBHOFJ.Add(CLCIOEHGFNI.CMCKNKKCNDK);
	}

	//// RVA: 0x7FCFE4 Offset: 0x7FCFE4 VA: 0x7FCFE4
	public int COCIPAJKDAF()
	{
		int res = 0;
		for(int i = 0; i < GJLJJDIDODK.Length; i++)
		{
			res += GJLJJDIDODK[i].JGBCNKPOOFO();
		}
		return res + JPMGNPAHGIB.MCBLDOECHEK_MatchMusicAttrStatus[0].PJCKMKEJCEL_Total();
	}

	//// RVA: 0x7FCFEC Offset: 0x7FCFEC VA: 0x7FCFEC
	public void DIJOPLHIMBO(JGEOBNENMAH.NEDILFPPCJF BGDCOKFCCBO, StatusData HFEMKGEOHJL, StatusData PDIPANKOKOL, int IFCPCIHJANL, int LCIPPBOFPOB)
	{
		StatusData d = new StatusData();
		d.Clear();
		for(int i = 0; i < GJLJJDIDODK.Length; i++)
		{
			d.Add(GJLJJDIDODK[i].ELFAIDEBLJB);
			d.Add(GJLJJDIDODK[i].BJABFKMIJHB_StatusMainScene);
			d.Add(GJLJJDIDODK[i].IMLGBMGIACC);
			d.Add(GJLJJDIDODK[i].AJINBLGCBMM_StatusCostumeMainScene);
			for(int j = 0; j < GJLJJDIDODK[i].OBCPFDNKLMM_StatusSubScenes.Length; j++)
			{
				d.Add(GJLJJDIDODK[i].OBCPFDNKLMM_StatusSubScenes[j]);
				d.Add(GJLJJDIDODK[i].FEGNMIGJMDM_CostumeSubScene[j]);
			}
		}
		BGDCOKFCCBO.HBKBKHACHHI_Soul = HFEMKGEOHJL.soul + d.soul;
		BGDCOKFCCBO.GMECIBOJCFF_Vocal = HFEMKGEOHJL.vocal + d.vocal;
		BGDCOKFCCBO.MIMLMJGGNJH_Charm = HFEMKGEOHJL.charm + d.charm;
		BGDCOKFCCBO.IPEKDLNEOFI_Life = HFEMKGEOHJL.life + d.life;
		BGDCOKFCCBO.BFHPKJEKJNN_Support = HFEMKGEOHJL.support + d.support;
		BGDCOKFCCBO.DDBEJNGJIPF_Fold = HFEMKGEOHJL.fold + d.fold;
		BGDCOKFCCBO.CBOCBLLOMHE_Total = HFEMKGEOHJL.Total + d.Total;
		BGDCOKFCCBO.MINAGJOIGOP_Luck = IFCPCIHJANL;
		BGDCOKFCCBO.ICBJAAPJNEI_Soul = PDIPANKOKOL.soul + JPMGNPAHGIB.BJABFKMIJHB_StatusMainScene.soul;
		BGDCOKFCCBO.AGNGKDFONAM_Vocal = PDIPANKOKOL.vocal + JPMGNPAHGIB.BJABFKMIJHB_StatusMainScene.vocal;
		BGDCOKFCCBO.KAEHAANLPKF_Charm = PDIPANKOKOL.charm + JPMGNPAHGIB.BJABFKMIJHB_StatusMainScene.charm;
		BGDCOKFCCBO.NIBMFONLOME_Life = PDIPANKOKOL.life + JPMGNPAHGIB.BJABFKMIJHB_StatusMainScene.life;
		BGDCOKFCCBO.PLMGHHHFAGL_Support = PDIPANKOKOL.support + JPMGNPAHGIB.BJABFKMIJHB_StatusMainScene.support;
		BGDCOKFCCBO.EKKCKGDGNPM_Fold = PDIPANKOKOL.fold + JPMGNPAHGIB.BJABFKMIJHB_StatusMainScene.fold;
		BGDCOKFCCBO.GCAOLGILAAI_Total = PDIPANKOKOL.Total + JPMGNPAHGIB.BJABFKMIJHB_StatusMainScene.Total;
		BGDCOKFCCBO.IBFPGFJDLEI_Luck = LCIPPBOFPOB;
		BGDCOKFCCBO.APPEPDLOPAA_Soul = CLCIOEHGFNI.CMCKNKKCNDK.soul;
		BGDCOKFCCBO.LHBINHCMEDA_Vocal = CLCIOEHGFNI.CMCKNKKCNDK.vocal;
		BGDCOKFCCBO.BPNAAEDJGPC_Charm = CLCIOEHGFNI.CMCKNKKCNDK.charm;
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
