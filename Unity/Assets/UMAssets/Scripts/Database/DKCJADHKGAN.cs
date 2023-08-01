
using System;
using System.Collections.Generic;
using XeSys;

public class DKCJADHKGAN { }
public class DKCJADHKGAN_EventWeekDay : DIHHCBACKGG_DbSection
{
	public class JFFPEKOEINE
	{
		public long KINJOEIAHFK; // 0x8
		public long PCCFAKEOBIC; // 0x10
		public int JCADAMLIOKK_Id; // 0x18
		public sbyte PPEGAKEIEGM_Enabled; // 0x1C
		public int AIDNHPGEHPM; // 0x20
		public int DJCHKGLCLPD; // 0x24
		public string CIOJJBOHEEJ; // 0x28
		public List<List<int>> BEPAMEEBPGI = new List<List<int>>(); // 0x2C

		public int ELEPHBOKIGK { get { return AIDNHPGEHPM ^ 0x5717f14f; } set { AIDNHPGEHPM = value ^ 0x5717f14f; } } //0x198E5A0 IIJFLONJAFL 0x198E160 LHNFGPIGCNE
		public int AEHCKNNGAKF { get { return DJCHKGLCLPD ^ 0x5717f14f; } set { DJCHKGLCLPD = value ^ 0x5717f14f; } } //0x198E5B4 KKNJPEMGEBF 0x198E174 NPDLLBHCIJP

		//// RVA: 0x198E5C8 Offset: 0x198E5C8 VA: 0x198E5C8
		//public List<int> OPCBHOLFCHO(int IAPNPKAGEGH) { }

		//// RVA: 0x198DA90 Offset: 0x198DA90 VA: 0x198DA90
		public bool FLPDCNBLOKL(int IAPNPKAGEGH, int GHBPLHBNMBK)
		{
			if(BEPAMEEBPGI[IAPNPKAGEGH] != null)
			{
				for(int i = 0; i < BEPAMEEBPGI[IAPNPKAGEGH].Count; i++)
				{
					if (BEPAMEEBPGI[IAPNPKAGEGH][i] == GHBPLHBNMBK)
						return true;
				}
			}
			return false;
		}

		//// RVA: 0x198E414 Offset: 0x198E414 VA: 0x198E414
		//public uint CAOGDCBPBAN() { }
	}

	private List<JFFPEKOEINE> MPCJGPEBCCD = new List<JFFPEKOEINE>(); // 0x20

	//// RVA: 0x198D87C Offset: 0x198D87C VA: 0x198D87C
	public JFFPEKOEINE PPIBJECKCEF(long FJLBOKEKFKA)
	{
		for(int i = 0; i < MPCJGPEBCCD.Count; i++)
		{
			if (MPCJGPEBCCD[i].PPEGAKEIEGM_Enabled == 2 && FJLBOKEKFKA >= MPCJGPEBCCD[i].KINJOEIAHFK && MPCJGPEBCCD[i].PCCFAKEOBIC >= FJLBOKEKFKA)
				return MPCJGPEBCCD[i];
		}
		return null;
	}

	//// RVA: 0x198D990 Offset: 0x198D990 VA: 0x198D990
	public bool FLPDCNBLOKL(long JHNMKKNEENE, int GHBPLHBNMBK)
	{
		JFFPEKOEINE data = PPIBJECKCEF(JHNMKKNEENE);
		if(data != null)
		{
			return data.FLPDCNBLOKL((int)Utility.GetLocalDateTime(JHNMKKNEENE).DayOfWeek, GHBPLHBNMBK);
		}
		return false;
	}

	// RVA: 0x198DBA0 Offset: 0x198DBA0 VA: 0x198DBA0
	public DKCJADHKGAN_EventWeekDay()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 45;
	}

	// RVA: 0x198DC88 Offset: 0x198DC88 VA: 0x198DC88 Slot: 8
	protected override void KMBPACJNEOF()
	{
		MPCJGPEBCCD.Clear();
	}

	// RVA: 0x198DD00 Offset: 0x198DD00 VA: 0x198DD00 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		PMHJIJGDJMO parser = PMHJIJGDJMO.HEGEKFMJNCC(DBBGALAPFGC);
		FBCAIGGLGMK[] array = parser.MDFFJJKBDFC;
		for(int i = 0; i < array.Length; i++)
		{
			JFFPEKOEINE data = new JFFPEKOEINE();
			data.JCADAMLIOKK_Id = (int)array[i].PPFNGGCBJKC;
			data.PPEGAKEIEGM_Enabled = (sbyte)JKAECBCNHAN_IsEnabled(1, (int)array[i].PLALNIIBLOF, 0);
			data.KINJOEIAHFK = array[i].FNEIADJMHHO;
			data.PCCFAKEOBIC = array[i].KOMKKBDABJP;
			data.CIOJJBOHEEJ = array[i].GENIJOLKBNH;
			data.ELEPHBOKIGK = array[i].BFINGCJHOHI;
			data.AEHCKNNGAKF = array[i].OEOIHIIIMCK;
			for(int j = 0; j < array[i].EHDDADDKMFI.Length; j++)
			{
				data.BEPAMEEBPGI.Add(JCAGLPANMFC(array[i].EHDDADDKMFI[j]));
			}
			MPCJGPEBCCD.Add(data);
		}
		return true;
	}

	// RVA: 0x198E324 Offset: 0x198E324 VA: 0x198E324 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return false;
	}

	//// RVA: 0x198E188 Offset: 0x198E188 VA: 0x198E188
	private static List<int> JCAGLPANMFC(string IBDJFHFIIHN)
	{
		List<int> res = null;
		if(!string.IsNullOrEmpty(IBDJFHFIIHN))
		{
			char[] sep = new char[1] { ',' };
			string[] strs = IBDJFHFIIHN.Split(sep);
			if(strs != null && strs.Length != 0)
			{
				res = new List<int>(strs.Length);
				for(int i = 0; i < strs.Length; i++)
				{
					res.Add(Int32.Parse(strs[i]));
				}
			}
		}
		return res;
	}

	// RVA: 0x198E32C Offset: 0x198E32C VA: 0x198E32C Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "DKCJADHKGAN_EventWeekDay.CAOGDCBPBAN");
		return 0;
	}
}
