
using XeApp.Game.Common;

public struct CGCBEHANFJO
{
	public int LDLHPACIIAB_Soul; // 0x0
	public int MKMIEGPOKGG_Vocal; // 0x4
	public int EACDINDLGLF_Charm; // 0x8

	// RVA: 0x7FC620 Offset: 0x7FC620 VA: 0x7FC620
	public void JCHLONCMPAJ()
	{
		LDLHPACIIAB_Soul = 0;
		MKMIEGPOKGG_Vocal = 0;
		EACDINDLGLF_Charm = 0;
	}

	// RVA: 0x7FC634 Offset: 0x7FC634 VA: 0x7FC634
	public int PJCKMKEJCEL_Total()
	{
		return LDLHPACIIAB_Soul + MKMIEGPOKGG_Vocal + EACDINDLGLF_Charm;
	}
}
public struct EDMIONMCICN
{
	public StatusData ELFAIDEBLJB; // 0x0
	public StatusData BJABFKMIJHB_StatusMainScene; // 0x4
	public StatusData[] OBCPFDNKLMM_StatusSubScenes; // 0x8
	public CGCBEHANFJO[] MCBLDOECHEK_MatchMusicAttrStatus; // 0xC
	public StatusData IMLGBMGIACC; // 0x10
	public StatusData AJINBLGCBMM_StatusCostumeMainScene; // 0x14
	public StatusData[] FEGNMIGJMDM_CostumeSubScene; // 0x18
	public MKHCIKICBOI LGGLFAECCBK_BonusTypeFlag; // 0x1C
	public MKHCIKICBOI NOEFMBAIAMP_MalusTypeFlag; // 0x20

	// RVA: 0x7FC8FC Offset: 0x7FC8FC VA: 0x7FC8FC
	public void OBKGEDCKHHE_Reset()
	{
		ELFAIDEBLJB = new StatusData();
		BJABFKMIJHB_StatusMainScene = new StatusData();
		OBCPFDNKLMM_StatusSubScenes = new StatusData[2];
		MCBLDOECHEK_MatchMusicAttrStatus = new CGCBEHANFJO[3];
		IMLGBMGIACC = new StatusData();
		AJINBLGCBMM_StatusCostumeMainScene = new StatusData();
		FEGNMIGJMDM_CostumeSubScene = new StatusData[2];
		for(int i = 0; i < 2; i++)
		{
			OBCPFDNKLMM_StatusSubScenes[i] = new StatusData();
			FEGNMIGJMDM_CostumeSubScene[i] = new StatusData();
		}
		JCHLONCMPAJ_Reset();
	}

	//// RVA: 0x7FC904 Offset: 0x7FC904 VA: 0x7FC904
	public void JCHLONCMPAJ_Reset()
	{
		ELFAIDEBLJB.Clear();
		BJABFKMIJHB_StatusMainScene.Clear();
		IMLGBMGIACC.Clear();
		AJINBLGCBMM_StatusCostumeMainScene.Clear();
		for(int i = 0; i < 2; i++)
		{
			OBCPFDNKLMM_StatusSubScenes[i].Clear();
			FEGNMIGJMDM_CostumeSubScene[i].Clear();
		}
		for(int i = 0; i < 3; i++)
		{
			MCBLDOECHEK_MatchMusicAttrStatus[i].JCHLONCMPAJ();
		}
		LGGLFAECCBK_BonusTypeFlag = 0;
		NOEFMBAIAMP_MalusTypeFlag = 0;
	}

	//// RVA: 0x7FC90C Offset: 0x7FC90C VA: 0x7FC90C
	public void BEDINMCPENB_SetupStatus(ref StatusData MGFGADBHOFJ)
	{
		MGFGADBHOFJ.Clear();
		MGFGADBHOFJ.Add(ELFAIDEBLJB);
		MGFGADBHOFJ.Add(BJABFKMIJHB_StatusMainScene);
		for(int i = 0; i < OBCPFDNKLMM_StatusSubScenes.Length; i++)
		{
			MGFGADBHOFJ.Add(OBCPFDNKLMM_StatusSubScenes[i]);
		}
	}

	//// RVA: 0x7FC914 Offset: 0x7FC914 VA: 0x7FC914
	public void IMLOCECFHGK(ref StatusData MGFGADBHOFJ)
	{
		MGFGADBHOFJ.Clear();
		MGFGADBHOFJ.Add(IMLGBMGIACC);
		MGFGADBHOFJ.Add(AJINBLGCBMM_StatusCostumeMainScene);
		for(int i = 0; i < OBCPFDNKLMM_StatusSubScenes.Length; i++)
		{
			MGFGADBHOFJ.Add(FEGNMIGJMDM_CostumeSubScene[i]);
		}
	}

	//// RVA: 0x7FC91C Offset: 0x7FC91C VA: 0x7FC91C
	//public int JGBCNKPOOFO() { }
}
