
using System.Collections.Generic;

public class IJNOIMLNBGN
{
	private int EHOIENNDEDH; // 0x8
	private long PCLNFCNIECH; // 0x10
	private long HHPIJHADAOB; // 0x18
	private string PMKLGDOEFNM; // 0x20

	public int PPFNGGCBJKC { get { return EHOIENNDEDH; } set { EHOIENNDEDH = value; } } //0x8DAB5C DEMEPMAEJOO 0x8DAB64 HIGKAIDMOKN
	public long PDBPFJJCADD_OpenAt { get { return PCLNFCNIECH; } set { PCLNFCNIECH = value; } } //0x8DAB6C FOACOMBHPAC 0x8DAB74 NBACOBCOJCA
	public long FDBNFFNFOND_CloseAt { get { return HHPIJHADAOB; } set { HHPIJHADAOB = value; } } //0x8DAB84 BPJOGHJCLDJ 0x8DAB8C NLJKMCHOCBK
	public string KLMPFGOCBHC_BannerText { get { return PMKLGDOEFNM; } set { PMKLGDOEFNM = value; } } //0x8DAB9C BGJNIABLBDB 0x8DABA4 HFBJLALGKOM

	// // RVA: 0x8DABAC Offset: 0x8DABAC VA: 0x8DABAC
	// public static void KHEKNNFCAOI(List<IJNOIMLNBGN> NNDGIAEFMOG, HMNJADGBKFA JMHECKKKMLK) { }

	// // RVA: 0x8DADAC Offset: 0x8DADAC VA: 0x8DADAC
	// public static void KHEKNNFCAOI(List<IJNOIMLNBGN> NNDGIAEFMOG, EDHLNJNFNDN JMHECKKKMLK) { }

	// // RVA: 0x8DAFA4 Offset: 0x8DAFA4 VA: 0x8DAFA4
	public static void KHEKNNFCAOI(string BlockName, List<IJNOIMLNBGN> NNDGIAEFMOG, OPHFFGFJIBJ JMHECKKKMLK)
	{
		NNDGIAEFMOG.Clear();
		for(int i = 0; i < JMHECKKKMLK.IHNBOEPLJKE.Length; i++)
		{
			FMPMFOBJNCM array = JMHECKKKMLK.IHNBOEPLJKE[i];
			IJNOIMLNBGN data = new IJNOIMLNBGN();
			data.PPFNGGCBJKC = (int)array.PPFNGGCBJKC;
			data.PDBPFJJCADD_OpenAt = array.PDBPFJJCADD;
			data.FDBNFFNFOND_CloseAt = array.FDBNFFNFOND;
			data.KLMPFGOCBHC_BannerText = DatabaseTextConverter.TranslateEventBannerText(BlockName, data.PPFNGGCBJKC, array.FEMMDNIELFC);
			NNDGIAEFMOG.Add(data);
		}
	}

	// // RVA: 0x8DB19C Offset: 0x8DB19C VA: 0x8DB19C
	// public static void KHEKNNFCAOI(List<IJNOIMLNBGN> NNDGIAEFMOG, NPAJGBIFLHB JMHECKKKMLK) { }

	// // RVA: 0x8DB394 Offset: 0x8DB394 VA: 0x8DB394
	public static void KHEKNNFCAOI(string BlockName, List<IJNOIMLNBGN> NNDGIAEFMOG, FOKPKJFHNLO JMHECKKKMLK)
	{
		NNDGIAEFMOG.Clear();
		for(int i = 0; i < JMHECKKKMLK.IHNBOEPLJKE.Length; i++)
		{
			LCFFJMJPPFI array = JMHECKKKMLK.IHNBOEPLJKE[i];
			IJNOIMLNBGN data = new IJNOIMLNBGN();
			data.PPFNGGCBJKC = (int)array.PPFNGGCBJKC;
			data.PDBPFJJCADD_OpenAt = array.PDBPFJJCADD;
			data.FDBNFFNFOND_CloseAt = array.FDBNFFNFOND;
			data.KLMPFGOCBHC_BannerText = DatabaseTextConverter.TranslateEventBannerText(BlockName, data.PPFNGGCBJKC, array.FEMMDNIELFC);
			NNDGIAEFMOG.Add(data);
		}
	}

	// // RVA: 0x8DB58C Offset: 0x8DB58C VA: 0x8DB58C
	// public uint CAOGDCBPBAN() { }
}
