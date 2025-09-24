
using System.Collections.Generic;

public class IJNOIMLNBGN
{
	private int EHOIENNDEDH_IdCrypted; // 0x8
	private long PCLNFCNIECH_OpenAtCrypted; // 0x10
	private long HHPIJHADAOB_CloseAtCrypted; // 0x18
	private string PMKLGDOEFNM_Desc_; // 0x20

	public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted; } set { EHOIENNDEDH_IdCrypted = value; } } //0x8DAB5C DEMEPMAEJOO 0x8DAB64 HIGKAIDMOKN
	public long PDBPFJJCADD_open_at { get { return PCLNFCNIECH_OpenAtCrypted; } set { PCLNFCNIECH_OpenAtCrypted = value; } } //0x8DAB6C FOACOMBHPAC 0x8DAB74 NBACOBCOJCA
	public long FDBNFFNFOND_close_at { get { return HHPIJHADAOB_CloseAtCrypted; } set { HHPIJHADAOB_CloseAtCrypted = value; } } //0x8DAB84 BPJOGHJCLDJ 0x8DAB8C NLJKMCHOCBK
	public string KLMPFGOCBHC_description { get { return PMKLGDOEFNM_Desc_; } set { PMKLGDOEFNM_Desc_ = value; } } //0x8DAB9C BGJNIABLBDB 0x8DABA4 HFBJLALGKOM

	// // RVA: 0x8DABAC Offset: 0x8DABAC VA: 0x8DABAC
	public static void KHEKNNFCAOI_Init(string BlockName, List<IJNOIMLNBGN> NNDGIAEFMOG, HMNJADGBKFA JMHECKKKMLK)
	{
		NNDGIAEFMOG.Clear();
		for(int i = 0; i < JMHECKKKMLK.IHNBOEPLJKE.Length; i++)
		{
			CMLHFCEIABD array = JMHECKKKMLK.IHNBOEPLJKE[i];
			IJNOIMLNBGN data = new IJNOIMLNBGN();
			data.PPFNGGCBJKC_id = (int)array.PPFNGGCBJKC;
			data.PDBPFJJCADD_open_at = array.PDBPFJJCADD;
			data.FDBNFFNFOND_close_at = array.FDBNFFNFOND;
			data.KLMPFGOCBHC_description = DatabaseTextConverter.TranslateEventBannerText(BlockName, data.PPFNGGCBJKC_id, array.FEMMDNIELFC);
			NNDGIAEFMOG.Add(data);
		}
	}

	// // RVA: 0x8DADAC Offset: 0x8DADAC VA: 0x8DADAC
	public static void KHEKNNFCAOI_Init(string BlockName, List<IJNOIMLNBGN> NNDGIAEFMOG, EDHLNJNFNDN JMHECKKKMLK)
	{
		NNDGIAEFMOG.Clear();
		for(int i = 0; i < JMHECKKKMLK.IHNBOEPLJKE.Length; i++)
		{
			BCDAHNEFGFF array = JMHECKKKMLK.IHNBOEPLJKE[i];
			IJNOIMLNBGN data = new IJNOIMLNBGN();
			data.PPFNGGCBJKC_id = (int)array.PPFNGGCBJKC;
			data.PDBPFJJCADD_open_at = array.PDBPFJJCADD;
			data.FDBNFFNFOND_close_at = array.FDBNFFNFOND;
			data.KLMPFGOCBHC_description = DatabaseTextConverter.TranslateEventBannerText(BlockName, data.PPFNGGCBJKC_id, array.FEMMDNIELFC);
			NNDGIAEFMOG.Add(data);
		}
	}

	// // RVA: 0x8DAFA4 Offset: 0x8DAFA4 VA: 0x8DAFA4
	public static void KHEKNNFCAOI_Init(string BlockName, List<IJNOIMLNBGN> NNDGIAEFMOG, OPHFFGFJIBJ JMHECKKKMLK)
	{
		NNDGIAEFMOG.Clear();
		for(int i = 0; i < JMHECKKKMLK.IHNBOEPLJKE.Length; i++)
		{
			FMPMFOBJNCM array = JMHECKKKMLK.IHNBOEPLJKE[i];
			IJNOIMLNBGN data = new IJNOIMLNBGN();
			data.PPFNGGCBJKC_id = (int)array.PPFNGGCBJKC;
			data.PDBPFJJCADD_open_at = array.PDBPFJJCADD;
			data.FDBNFFNFOND_close_at = array.FDBNFFNFOND;
			data.KLMPFGOCBHC_description = DatabaseTextConverter.TranslateEventBannerText(BlockName, data.PPFNGGCBJKC_id, array.FEMMDNIELFC);
			NNDGIAEFMOG.Add(data);
		}
	}

	// // RVA: 0x8DB19C Offset: 0x8DB19C VA: 0x8DB19C
	public static void KHEKNNFCAOI_Init(string BlockName, List<IJNOIMLNBGN> NNDGIAEFMOG, NPAJGBIFLHB JMHECKKKMLK)
	{
		NNDGIAEFMOG.Clear();
		for(int i = 0; i < JMHECKKKMLK.IHNBOEPLJKE.Length; i++)
		{
			EPICOEPILEJ array = JMHECKKKMLK.IHNBOEPLJKE[i];
			IJNOIMLNBGN data = new IJNOIMLNBGN();
			data.PPFNGGCBJKC_id = (int)array.PPFNGGCBJKC;
			data.PDBPFJJCADD_open_at = array.PDBPFJJCADD;
			data.FDBNFFNFOND_close_at = array.FDBNFFNFOND;
			data.KLMPFGOCBHC_description = DatabaseTextConverter.TranslateEventBannerText(BlockName, data.PPFNGGCBJKC_id, array.FEMMDNIELFC);
			NNDGIAEFMOG.Add(data);
		}
	}

	// // RVA: 0x8DB394 Offset: 0x8DB394 VA: 0x8DB394
	public static void KHEKNNFCAOI_Init(string BlockName, List<IJNOIMLNBGN> NNDGIAEFMOG, FOKPKJFHNLO JMHECKKKMLK)
	{
		NNDGIAEFMOG.Clear();
		for(int i = 0; i < JMHECKKKMLK.IHNBOEPLJKE.Length; i++)
		{
			LCFFJMJPPFI array = JMHECKKKMLK.IHNBOEPLJKE[i];
			IJNOIMLNBGN data = new IJNOIMLNBGN();
			data.PPFNGGCBJKC_id = (int)array.PPFNGGCBJKC;
			data.PDBPFJJCADD_open_at = array.PDBPFJJCADD;
			data.FDBNFFNFOND_close_at = array.FDBNFFNFOND;
			data.KLMPFGOCBHC_description = DatabaseTextConverter.TranslateEventBannerText(BlockName, data.PPFNGGCBJKC_id, array.FEMMDNIELFC);
			NNDGIAEFMOG.Add(data);
		}
	}

	// // RVA: 0x8DB58C Offset: 0x8DB58C VA: 0x8DB58C
	// public uint CAOGDCBPBAN() { }
}
