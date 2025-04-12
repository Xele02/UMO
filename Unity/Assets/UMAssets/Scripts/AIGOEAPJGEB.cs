
using System.Collections.Generic;

public class AIGOEAPJGEB
{
	public int EHOIENNDEDH_Crypted; // 0x8
	public int MKENMKMJFKP_Crypted; // 0xC
	public int ICKOHEDLEFP_Crypted; // 0x10
	public int HDMBJJJJEEG_Crypted; // 0x14
	public int PPFNGGCBJKC { get { return EHOIENNDEDH_Crypted ^ 0x301d6e99; } set { EHOIENNDEDH_Crypted = value ^ 0x301d6e99; } } //0xCD0F34 DEMEPMAEJOO 0xCD0F48 HIGKAIDMOKN
	public int INDDJNMPONH { get { return MKENMKMJFKP_Crypted ^ 0xc85b093; } set { MKENMKMJFKP_Crypted = value ^ 0xc85b093; } } //0xCD0F5C GHAILOLPHPF 0xCD0F70 BACGOKIGMBC
	public int JBGEEPFKIGG { get { return ICKOHEDLEFP_Crypted ^ 0x299e7cd; } set { ICKOHEDLEFP_Crypted = value ^ 0x299e7cd; } } //0xCD0F84 OLOCMINKGON 0xCD0F98 ABAFHIBFKCE
	public int MAFAIIHJAFG { get { return HDMBJJJJEEG_Crypted ^ 0x598ffe9; } set { HDMBJJJJEEG_Crypted = value ^ 0x598ffe9; } } //0xCD0FAC LLNFMLKMFKB 0xCD0FC0 PCICDCAILIF

	// // RVA: 0xCD0FD4 Offset: 0xCD0FD4 VA: 0xCD0FD4
	// public static void KHEKNNFCAOI(List<AIGOEAPJGEB> NNDGIAEFMOG, HMNJADGBKFA JMHECKKKMLK) { }

	// // RVA: 0xCD11FC Offset: 0xCD11FC VA: 0xCD11FC
	public static void KHEKNNFCAOI(List<AIGOEAPJGEB> NNDGIAEFMOG, OPHFFGFJIBJ JMHECKKKMLK)
	{
		NNDGIAEFMOG.Clear();
		for(int i = 0; i < JMHECKKKMLK.MHKNGJMEGFI.Length; i++)
		{
            EGFGKMKLEFG array = JMHECKKKMLK.MHKNGJMEGFI[i];
            AIGOEAPJGEB data = new AIGOEAPJGEB();
			data.PPFNGGCBJKC = array.PPFNGGCBJKC;
			data.INDDJNMPONH = array.GBJFNGCDKPM;
			data.JBGEEPFKIGG = array.JBGEEPFKIGG;
			data.MAFAIIHJAFG = array.MAFAIIHJAFG;
			NNDGIAEFMOG.Add(data);
		}
	}

	// // RVA: 0xCD141C Offset: 0xCD141C VA: 0xCD141C
	// public static void KHEKNNFCAOI(List<AIGOEAPJGEB> NNDGIAEFMOG, HGHOHICGBEP JMHECKKKMLK) { }

	// // RVA: 0xCD163C Offset: 0xCD163C VA: 0xCD163C
	// public static void KHEKNNFCAOI(List<AIGOEAPJGEB> NNDGIAEFMOG, EDHLNJNFNDN JMHECKKKMLK) { }

	// // RVA: 0xCD185C Offset: 0xCD185C VA: 0xCD185C
	public static void KHEKNNFCAOI(List<AIGOEAPJGEB> NNDGIAEFMOG, FOKPKJFHNLO JMHECKKKMLK)
	{
		NNDGIAEFMOG.Clear();
		for(int i = 0; i < JMHECKKKMLK.MHKNGJMEGFI.Length; i++)
		{
            NEEFDIIDPHK array = JMHECKKKMLK.MHKNGJMEGFI[i];
            AIGOEAPJGEB data = new AIGOEAPJGEB();
			data.PPFNGGCBJKC = array.PPFNGGCBJKC;
			data.INDDJNMPONH = array.GBJFNGCDKPM;
			data.JBGEEPFKIGG = array.JBGEEPFKIGG;
			data.MAFAIIHJAFG = array.MAFAIIHJAFG;
			NNDGIAEFMOG.Add(data);
		}
	}
}
