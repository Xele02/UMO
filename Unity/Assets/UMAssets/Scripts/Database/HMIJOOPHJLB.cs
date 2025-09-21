
using System.Collections.Generic;
using UnityEngine;
using XeSys;

[System.Obsolete("Use HMIJOOPHJLB_Diva2", true)]
public class HMIJOOPHJLB { }
public class HMIJOOPHJLB_Diva2 : DIHHCBACKGG_DbSection
{
	public static bool DINNDBNPNFK; // 0x0
	public const int NLPCOAKLBAN = 0;
	public const int DNLFNEFLNED = 200;
	public int AGNCAAFGLBE_MaxLevels; // 0x20
	public List<OAMBPGCJEGJ> LENIIENHJJK = new List<OAMBPGCJEGJ>(); // 0x24
	private List<int> KNOMABFHFEB = new List<int>(); // 0x28
	private List<int> BEKCOEABLJJ = new List<int>(); // 0x2C

	// // RVA: 0x15F5CD4 Offset: 0x15F5CD4 VA: 0x15F5CD4
	// public int LMCFPOFNCFN(int MEKJFFHMKOB, out int _CIEOBFIIPLD_Level) { }

	// // RVA: 0x15F5E30 Offset: 0x15F5E30 VA: 0x15F5E30
	// public int DHIOLJDHECJ(int MEKJFFHMKOB) { }

	// // RVA: 0x15F5F4C Offset: 0x15F5F4C VA: 0x15F5F4C
	public int NAPBJDGJADP(int _CIEOBFIIPLD_Level)
	{
		int idx = _CIEOBFIIPLD_Level - 1;
		if(idx < 0)
			return 0;
		if(KNOMABFHFEB.Count <= idx)
		{
			idx = KNOMABFHFEB.Count - 1;
		}
		return KNOMABFHFEB[idx] ^ BEKCOEABLJJ[idx];
	}

	// // RVA: 0x15F607C Offset: 0x15F607C VA: 0x15F607C
	public int OAJOMHOOCJJ(int _CIEOBFIIPLD_Level)
	{
		return Mathf.Max(NAPBJDGJADP(Mathf.Clamp(_CIEOBFIIPLD_Level, 0, NBJKHMLGNPA())) - NAPBJDGJADP(Mathf.Clamp(_CIEOBFIIPLD_Level - 1, 0, NBJKHMLGNPA())), 0);
	}

	// // RVA: 0x15F6168 Offset: 0x15F6168 VA: 0x15F6168
	public int NBJKHMLGNPA()
	{
		return KNOMABFHFEB.Count - 1;
	}

	// RVA: 0x15F61E4 Offset: 0x15F61E4 VA: 0x15F61E4
	public HMIJOOPHJLB_Diva2()
    {
        JIKKNHIAEKG_BlockName = "";
        LMHMIIKCGPE = 20;
    }

	// RVA: 0x15F6324 Offset: 0x15F6324 VA: 0x15F6324 Slot: 8
	protected override void KMBPACJNEOF_Reset()
    {
        LENIIENHJJK.Clear();
        KNOMABFHFEB.Clear();
        BEKCOEABLJJ.Clear();
    }

	// RVA: 0x15F63F4 Offset: 0x15F63F4 VA: 0x15F63F4 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_Data)
    {
        int time = (int)Utility.GetCurrentUnixTime();
        time *= 0x96a;
        PBLHKFHDMGG reader = PBLHKFHDMGG.HEGEKFMJNCC(_DBBGALAPFGC_Data);
        ELHKLDPNKBD[] array = reader.HNKCJKLONLN;
        time += 2;
        for(int i = 0; i < array.Length; i++)
        {
            OAMBPGCJEGJ data = new OAMBPGCJEGJ();
            data.DOMFHDPMCCO(time, (int)array[i].LJELGFAFGAB, (int)array[i].KNEDJFLCCLN, (int)array[i].MBAMIOJNGBD);
            LENIIENHJJK.Add(data);
            time += 3;
        }
        uint[] array2 = reader.KNOMABFHFEB;
        for(int i = 0; i < array2.Length; i++)
        {
            BEKCOEABLJJ.Add(time);
            KNOMABFHFEB.Add((int)(array2[i] ^ time));
            time *= 6;
        }

        return true;
    }

	// RVA: 0x15F6804 Offset: 0x15F6804 VA: 0x15F6804 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
    {
        return true;
    }

	// RVA: 0x15F680C Offset: 0x15F680C VA: 0x15F680C Slot: 11
	public override uint CAOGDCBPBAN()
    {
        TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "HMIJOOPHJLB_Diva2.CAOGDCBPBAN");
        return 0;
    }
}
public class OAMBPGCJEGJ
{
	public int FBGGEFFJJHB_xor;//?? = (int)0xF4000006; // 0x8
	public int PFOPEKFHHBF; // 0xC
	public int ACEEGCLHCNC; // 0x10
	public int AGNKGFMGLNI; // 0x14

	public int MKMIEGPOKGG_Soul { get { return FBGGEFFJJHB_xor ^ PFOPEKFHHBF; } set { PFOPEKFHHBF = FBGGEFFJJHB_xor ^ value; } } //0x1CC6F60 OPCBPDMGOFD 0x1CC6F70 ONLKPHJHEIG
	public int MELGGCAIONF { get { return FBGGEFFJJHB_xor ^ ACEEGCLHCNC; } set { ACEEGCLHCNC = FBGGEFFJJHB_xor ^ value; } } //0x1CC6F80 BJNPIAMNIIB 0x1CC6F90 EIJEMBBHLPO
	public int LDLHPACIIAB_Charm { get { return FBGGEFFJJHB_xor ^ AGNKGFMGLNI; } set { AGNKGFMGLNI = FBGGEFFJJHB_xor ^ value; } } //0x1CC6FA0 DGMJOJECONO 0x1CC6FB0 DLFOOBCJJDC

	// // RVA: 0x1CC6FC0 Offset: 0x1CC6FC0 VA: 0x1CC6FC0
	public void DOMFHDPMCCO(int _FBGGEFFJJHB_xor, int _MKMIEGPOKGG_Soul, int MELGGCAIONF, int _LDLHPACIIAB_Charm)
    {
        this.FBGGEFFJJHB_xor = _FBGGEFFJJHB_xor;
        this.PFOPEKFHHBF = _MKMIEGPOKGG_Soul ^ _FBGGEFFJJHB_xor;
        this.ACEEGCLHCNC = MELGGCAIONF ^ _FBGGEFFJJHB_xor;
        this.AGNKGFMGLNI = _FBGGEFFJJHB_xor ^ _LDLHPACIIAB_Charm;
    }

	// // RVA: 0x1CC6FDC Offset: 0x1CC6FDC VA: 0x1CC6FDC
	// public void ANIJHEBLMGB(int _INDDJNMPONH_type, short _JBGEEPFKIGG_val) { }

	// // RVA: 0x1CC7028 Offset: 0x1CC7028 VA: 0x1CC7028
	// public void ODDIHGPONFL_Copy(OAMBPGCJEGJ GPBJHKLFCEP) { }

	// // RVA: 0x1CC70C8 Offset: 0x1CC70C8 VA: 0x1CC70C8
	// public uint CAOGDCBPBAN() { }
}
