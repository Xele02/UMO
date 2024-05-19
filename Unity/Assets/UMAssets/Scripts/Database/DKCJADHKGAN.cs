
using System;
using System.Collections.Generic;
using XeSys;

public class DKCJADHKGAN { }
public class DKCJADHKGAN_EventWeekDay : DIHHCBACKGG_DbSection
{
	public class JFFPEKOEINE
	{
		public long KINJOEIAHFK_StartDate; // 0x8
		public long PCCFAKEOBIC_EndDate; // 0x10
		public int JCADAMLIOKK_Id; // 0x18
		public sbyte PPEGAKEIEGM_Enabled; // 0x1C
		public int AIDNHPGEHPM_Crypted; // 0x20
		public int DJCHKGLCLPD_Crypted; // 0x24
		public string CIOJJBOHEEJ; // 0x28
		public List<List<int>> BEPAMEEBPGI_SongIdByWeekday = new List<List<int>>(); // 0x2C

		public int ELEPHBOKIGK_MaxCount { get { return AIDNHPGEHPM_Crypted ^ 0x5717f14f; } set { AIDNHPGEHPM_Crypted = value ^ 0x5717f14f; } } //0x198E5A0 IIJFLONJAFL 0x198E160 LHNFGPIGCNE
		public int AEHCKNNGAKF_BonusMaxCount { get { return DJCHKGLCLPD_Crypted ^ 0x5717f14f; } set { DJCHKGLCLPD_Crypted = value ^ 0x5717f14f; } } //0x198E5B4 KKNJPEMGEBF 0x198E174 NPDLLBHCIJP

		//// RVA: 0x198E5C8 Offset: 0x198E5C8 VA: 0x198E5C8
		public List<int> OPCBHOLFCHO_GetSongsForWeekDay(int IAPNPKAGEGH)
		{
			return BEPAMEEBPGI_SongIdByWeekday[IAPNPKAGEGH];
		}

		//// RVA: 0x198DA90 Offset: 0x198DA90 VA: 0x198DA90
		public bool FLPDCNBLOKL_IsSongForWeekDay(int IAPNPKAGEGH, int GHBPLHBNMBK)
		{
			if(BEPAMEEBPGI_SongIdByWeekday[IAPNPKAGEGH] != null)
			{
				for(int i = 0; i < BEPAMEEBPGI_SongIdByWeekday[IAPNPKAGEGH].Count; i++)
				{
					if (BEPAMEEBPGI_SongIdByWeekday[IAPNPKAGEGH][i] == GHBPLHBNMBK)
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
			if (MPCJGPEBCCD[i].PPEGAKEIEGM_Enabled == 2 && FJLBOKEKFKA >= MPCJGPEBCCD[i].KINJOEIAHFK_StartDate && MPCJGPEBCCD[i].PCCFAKEOBIC_EndDate >= FJLBOKEKFKA)
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
			return data.FLPDCNBLOKL_IsSongForWeekDay((int)Utility.GetLocalDateTime(JHNMKKNEENE).DayOfWeek, GHBPLHBNMBK);
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
			data.KINJOEIAHFK_StartDate = array[i].FNEIADJMHHO;
			data.PCCFAKEOBIC_EndDate = array[i].KOMKKBDABJP;
			data.CIOJJBOHEEJ = array[i].GENIJOLKBNH;
			data.ELEPHBOKIGK_MaxCount = array[i].BFINGCJHOHI;
			data.AEHCKNNGAKF_BonusMaxCount = array[i].OEOIHIIIMCK;
			//UnityEngine.Debug.LogError(Utility.GetLocalDateTime(data.KINJOEIAHFK_StartDate).ToShortDateString() + " " + Utility.GetLocalDateTime(data.KINJOEIAHFK_StartDate).ToShortTimeString()+" "+ Utility.GetLocalDateTime(data.PCCFAKEOBIC_EndDate).ToShortDateString() + " " + Utility.GetLocalDateTime(data.PCCFAKEOBIC_EndDate).ToShortTimeString() + " " + data.CIOJJBOHEEJ+" "+data.ELEPHBOKIGK_MaxCount+" "+data.AEHCKNNGAKF_BonusMaxCount);
			for(int j = 0; j < array[i].EHDDADDKMFI.Length; j++)
			{
				data.BEPAMEEBPGI_SongIdByWeekday.Add(JCAGLPANMFC(array[i].EHDDADDKMFI[j]));
				/*for(int k = 0; k < data.BEPAMEEBPGI_SongIdByWeekday[data.BEPAMEEBPGI_SongIdByWeekday.Count - 1].Count; k++)
				{
					UnityEngine.Debug.LogError(j+" "+data.BEPAMEEBPGI_SongIdByWeekday[data.BEPAMEEBPGI_SongIdByWeekday.Count - 1][k]);
				}*/
			}
			MPCJGPEBCCD.Add(data);
		}
		// UMO, loop the event. Use only those without bonus and set bonus on fixed days
		{
			List<JFFPEKOEINE> usableList = MPCJGPEBCCD.FindAll((JFFPEKOEINE _) =>
			{
				return _.AEHCKNNGAKF_BonusMaxCount == 0;
			});
			// Special days : 27/12 => 01/03
			// Start from 1 week before today up to 2 weeks after
			DateTime t = Utility.GetLocalDateTime(Utility.GetCurrentUnixTime());
			DateTime start = t.Date.AddDays(-(int)t.DayOfWeek + 1).AddDays(-7);
			// Find the index to use. Count the number of weeks since 1/1/24
			DateTime loopStart = new DateTime(2024, 1, 1);
			int weekDiff = (start - loopStart).Days / 7;
			int idx = weekDiff % usableList.Count;
			//UnityEngine.Debug.LogError(start.ToLongDateString()+" "+usableList.Count+" "+weekDiff+" "+idx);
			DateTime s1 = start;
			for(int i = 0; i < 4; i++)
			{
                JFFPEKOEINE data = usableList[(idx + i) % usableList.Count];
				data.KINJOEIAHFK_StartDate = Utility.GetTargetUnixTime(s1.Year, s1.Month, s1.Day, 0, 0, 0);
				DateTime s1b = s1.AddDays(6);
				s1 = s1.AddDays(7);
				data.PCCFAKEOBIC_EndDate = Utility.GetTargetUnixTime(s1b.Year, s1b.Month, s1b.Day, 23, 59, 59);
				if(i == 1 && ((t.Month == 12 && t.Day >= 27) || (t.Month == 1 && t.Day <= 3)))
					data.AEHCKNNGAKF_BonusMaxCount = 2;
                //UnityEngine.Debug.LogError(((idx + i) % usableList.Count)+" "+Utility.GetLocalDateTime(data.KINJOEIAHFK_StartDate).ToShortDateString() + " " + Utility.GetLocalDateTime(data.KINJOEIAHFK_StartDate).ToShortTimeString()+" "+ Utility.GetLocalDateTime(data.PCCFAKEOBIC_EndDate).ToShortDateString() + " " + Utility.GetLocalDateTime(data.PCCFAKEOBIC_EndDate).ToShortTimeString());
			}
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
