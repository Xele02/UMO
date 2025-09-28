
using XeApp.Game.Common;

public enum MKHCIKICBOI
{
	BICPBLMPBPH_1_Soul = 1,
	GPCMMGOCPHC_2_Vocal = 2,
	LGOHMPBLPKA_4_Charm = 4,
	ECHJOKLBHEJ_8_Life = 8,
	AHJNCHAONGN_16_Support = 16,
	ONBNGGDFAJK_32_Fold = 32,
	OHOKFCJNFDO_Luck = 64,
	MKADAMIGMPO_Total = 7,
}

public struct AEGLGBOGDHH
{
	public EDMIONMCICN[] GJLJJDIDODK; // 0x0
	public EDMIONMCICN JPMGNPAHGIB; // 0x4
	public CFHDKAFLNEP CLCIOEHGFNI; // 0x28

	//// RVA: 0x7FCFC4 Offset: 0x7FCFC4 VA: 0x7FCFC4
	public void OBKGEDCKHHE_Init()
	{
		GJLJJDIDODK = new EDMIONMCICN[3];
		for(int i = 0; i < GJLJJDIDODK.Length; i++)
		{
			GJLJJDIDODK[i].OBKGEDCKHHE_Init();
		}
		JPMGNPAHGIB = new EDMIONMCICN();
		JPMGNPAHGIB.OBKGEDCKHHE_Init();
		CLCIOEHGFNI = new CFHDKAFLNEP();
		CLCIOEHGFNI.OBKGEDCKHHE_Init();
	}

	//// RVA: 0x7FCFCC Offset: 0x7FCFCC VA: 0x7FCFCC
	public void JCHLONCMPAJ_Clear()
	{
		for(int i = 0; i < GJLJJDIDODK.Length; i++)
		{
			GJLJJDIDODK[i].JCHLONCMPAJ_Clear();
		}
		JPMGNPAHGIB.JCHLONCMPAJ_Clear();
		CLCIOEHGFNI.JCHLONCMPAJ_Clear();
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
		MGFGADBHOFJ.Add(CLCIOEHGFNI.CMCKNKKCNDK_status);
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
	public void DIJOPLHIMBO(JGEOBNENMAH.NEDILFPPCJF BGDCOKFCCBO, StatusData HFEMKGEOHJL, StatusData _PDIPANKOKOL_FriendStat, int IFCPCIHJANL, int LCIPPBOFPOB)
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
		BGDCOKFCCBO.HBKBKHACHHI_para_soul = HFEMKGEOHJL.soul + d.soul;
		BGDCOKFCCBO.GMECIBOJCFF_para_voice = HFEMKGEOHJL.vocal + d.vocal;
		BGDCOKFCCBO.MIMLMJGGNJH_para_charm = HFEMKGEOHJL.charm + d.charm;
		BGDCOKFCCBO.IPEKDLNEOFI_para_life = HFEMKGEOHJL.life + d.life;
		BGDCOKFCCBO.BFHPKJEKJNN_para_support = HFEMKGEOHJL.support + d.support;
		BGDCOKFCCBO.DDBEJNGJIPF_para_foldwave = HFEMKGEOHJL.fold + d.fold;
		BGDCOKFCCBO.CBOCBLLOMHE_para_total = HFEMKGEOHJL.Total + d.Total;
		BGDCOKFCCBO.MINAGJOIGOP_para_luck = IFCPCIHJANL;
		BGDCOKFCCBO.ICBJAAPJNEI_Soul = _PDIPANKOKOL_FriendStat.soul + JPMGNPAHGIB.BJABFKMIJHB_StatusMainScene.soul;
		BGDCOKFCCBO.AGNGKDFONAM_Vocal = _PDIPANKOKOL_FriendStat.vocal + JPMGNPAHGIB.BJABFKMIJHB_StatusMainScene.vocal;
		BGDCOKFCCBO.KAEHAANLPKF_Charm = _PDIPANKOKOL_FriendStat.charm + JPMGNPAHGIB.BJABFKMIJHB_StatusMainScene.charm;
		BGDCOKFCCBO.NIBMFONLOME_Life = _PDIPANKOKOL_FriendStat.life + JPMGNPAHGIB.BJABFKMIJHB_StatusMainScene.life;
		BGDCOKFCCBO.PLMGHHHFAGL_Support = _PDIPANKOKOL_FriendStat.support + JPMGNPAHGIB.BJABFKMIJHB_StatusMainScene.support;
		BGDCOKFCCBO.EKKCKGDGNPM_Fold = _PDIPANKOKOL_FriendStat.fold + JPMGNPAHGIB.BJABFKMIJHB_StatusMainScene.fold;
		BGDCOKFCCBO.GCAOLGILAAI_Total = _PDIPANKOKOL_FriendStat.Total + JPMGNPAHGIB.BJABFKMIJHB_StatusMainScene.Total;
		BGDCOKFCCBO.IBFPGFJDLEI_Luck = LCIPPBOFPOB;
		BGDCOKFCCBO.APPEPDLOPAA_Soul = CLCIOEHGFNI.CMCKNKKCNDK_status.soul;
		BGDCOKFCCBO.LHBINHCMEDA_Vocal = CLCIOEHGFNI.CMCKNKKCNDK_status.vocal;
		BGDCOKFCCBO.BPNAAEDJGPC_Charm = CLCIOEHGFNI.CMCKNKKCNDK_status.charm;
	}

	//// RVA: 0x7FD014 Offset: 0x7FD014 VA: 0x7FD014
	//public int ABEDECHGFAG(JLKEOGLJNOD_TeamInfo _HEDKFICAPIJ_Team) { }

	//// RVA: 0x7FD01C Offset: 0x7FD01C VA: 0x7FD01C
	public bool IJACIMIPBBK_IsBufftarget(MKHCIKICBOI _ICPDDMIBEIL_Bf)
	{
		for (int i = 0; i < GJLJJDIDODK.Length; i++)
		{
			if ((GJLJJDIDODK[i].LGGLFAECCBK_BonusTypeFlag & _ICPDDMIBEIL_Bf) != 0)
				return true;
		}
		return (JPMGNPAHGIB.LGGLFAECCBK_BonusTypeFlag & _ICPDDMIBEIL_Bf) != 0;
	}

	//// RVA: 0x7FD024 Offset: 0x7FD024 VA: 0x7FD024
	public bool ADENHAHPBCJ_IsDebuffTarget(MKHCIKICBOI _ICPDDMIBEIL_Bf)
	{
		for(int i = 0; i < GJLJJDIDODK.Length; i++)
		{
			if ((GJLJJDIDODK[i].NOEFMBAIAMP_MalusTypeFlag & _ICPDDMIBEIL_Bf) != 0)
				return true;
		}
		return (JPMGNPAHGIB.NOEFMBAIAMP_MalusTypeFlag & _ICPDDMIBEIL_Bf) != 0;
	}
}
