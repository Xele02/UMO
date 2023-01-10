
using XeApp.Game.Common;

public struct CGCBEHANFJO
{
	public int LDLHPACIIAB; // 0x0
	public int MKMIEGPOKGG; // 0x4
	public int EACDINDLGLF; // 0x8

	// RVA: 0x7FC620 Offset: 0x7FC620 VA: 0x7FC620
	public void JCHLONCMPAJ()
	{
		LDLHPACIIAB = 0;
		MKMIEGPOKGG = 0;
		EACDINDLGLF = 0;
	}

	// RVA: 0x7FC634 Offset: 0x7FC634 VA: 0x7FC634
	public int PJCKMKEJCEL()
	{
		return LDLHPACIIAB + MKMIEGPOKGG + EACDINDLGLF;
	}
}
public struct EDMIONMCICN
{
	public StatusData ELFAIDEBLJB; // 0x0
	public StatusData BJABFKMIJHB; // 0x4
	public StatusData[] OBCPFDNKLMM; // 0x8
	public CGCBEHANFJO[] MCBLDOECHEK; // 0xC
	public StatusData IMLGBMGIACC; // 0x10
	public StatusData AJINBLGCBMM; // 0x14
	public StatusData[] FEGNMIGJMDM; // 0x18
	public MKHCIKICBOI LGGLFAECCBK; // 0x1C
	public MKHCIKICBOI NOEFMBAIAMP; // 0x20

	// RVA: 0x7FC8FC Offset: 0x7FC8FC VA: 0x7FC8FC
	public void OBKGEDCKHHE()
	{
		ELFAIDEBLJB = new StatusData();
		BJABFKMIJHB = new StatusData();
		OBCPFDNKLMM = new StatusData[2];
		MCBLDOECHEK = new CGCBEHANFJO[3];
		IMLGBMGIACC = new StatusData();
		AJINBLGCBMM = new StatusData();
		FEGNMIGJMDM = new StatusData[2];
		for(int i = 0; i < 2; i++)
		{
			OBCPFDNKLMM[i] = new StatusData();
			FEGNMIGJMDM[i] = new StatusData();
		}
		JCHLONCMPAJ();
	}

	//// RVA: 0x7FC904 Offset: 0x7FC904 VA: 0x7FC904
	public void JCHLONCMPAJ()
	{
		ELFAIDEBLJB.Clear();
		BJABFKMIJHB.Clear();
		IMLGBMGIACC.Clear();
		AJINBLGCBMM.Clear();
		for(int i = 0; i < 2; i++)
		{
			OBCPFDNKLMM[i].Clear();
			FEGNMIGJMDM[i].Clear();
		}
		for(int i = 0; i < 3; i++)
		{
			MCBLDOECHEK[i].JCHLONCMPAJ();
		}
		LGGLFAECCBK = 0;
		NOEFMBAIAMP = 0;
	}

	//// RVA: 0x7FC90C Offset: 0x7FC90C VA: 0x7FC90C
	public void BEDINMCPENB(ref StatusData MGFGADBHOFJ)
	{
		MGFGADBHOFJ.Clear();
		MGFGADBHOFJ.Add(ELFAIDEBLJB);
		MGFGADBHOFJ.Add(BJABFKMIJHB);
		for(int i = 0; i < OBCPFDNKLMM.Length; i++)
		{
			MGFGADBHOFJ.Add(OBCPFDNKLMM[i]);
		}
	}

	//// RVA: 0x7FC914 Offset: 0x7FC914 VA: 0x7FC914
	public void IMLOCECFHGK(ref StatusData MGFGADBHOFJ)
	{
		MGFGADBHOFJ.Clear();
		MGFGADBHOFJ.Add(IMLGBMGIACC);
		MGFGADBHOFJ.Add(AJINBLGCBMM);
		for(int i = 0; i < OBCPFDNKLMM.Length; i++)
		{
			MGFGADBHOFJ.Add(FEGNMIGJMDM[i]);
		}
	}

	//// RVA: 0x7FC91C Offset: 0x7FC91C VA: 0x7FC91C
	//public int JGBCNKPOOFO() { }
}
