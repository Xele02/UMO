
using System.Collections.Generic;
using XeApp.Game.Common;

public class HODOGPOKOOJ
{
	public enum KMBJEEFHJOH
	{
		PHCMJBCLALL = 0,
		CCAPCGPIIPF = 1,
		MCDCNJCJCAB = 2,
		JFAGADLHIED = 3,
		EOMIACEPHGA = 4,
	}

	public enum KNNLDAHADJB
	{
		CCAPCGPIIPF = 0,
		ANFKBNLLJFN = 1,
	}

	private enum PILMBALHBPJ
	{
		EHOOCLFEKAG = 0,
	}

	public static List<int> BFHLPPDKOPC_Event1 = new List<int>(); // 0x0
	public static List<int> KCCLHODILPA_Event2 = new List<int>(); // 0x4
	public static List<int> JNDKAFPBENO_Gacha = new List<int>(); // 0x8
	public static List<int> IBBMNGEHDEP_Pickup = new List<int>(); // 0xC
	private static string[] ECLAOLBGCDD = new string[1] { "cs_w_" }; // 0x10

	//// RVA: 0x16008C8 Offset: 0x16008C8 VA: 0x16008C8
	public static KMBJEEFHJOH FABLNMEEKKF_GetFileKeepStatus(PKKHIEAEDPC CEJDIAECJKD, KNNLDAHADJB GKOAGCJNBBM)
	{
		if(CEJDIAECJKD == null)
			return KMBJEEFHJOH.MCDCNJCJCAB/*2*/;
		if(CEJDIAECJKD.NKGJOAEDCPH.EGELJDAGHPP)
			return KMBJEEFHJOH.PHCMJBCLALL/*0*/;
		if(CEJDIAECJKD.NKGJOAEDCPH.OEACGDAKMMB)
			return KMBJEEFHJOH.JFAGADLHIED/*3*/;
		if(GKOAGCJNBBM == KNNLDAHADJB.ANFKBNLLJFN/*1*/)
		{
			if(CEJDIAECJKD.NKGJOAEDCPH.AKHBHEFFNJC)
			{
				return KMBJEEFHJOH.CCAPCGPIIPF/*1*/;
			}
			if(CEJDIAECJKD.NKGJOAEDCPH.PEOIMDCECDL)
				return KMBJEEFHJOH.EOMIACEPHGA/*4*/;
			return KMBJEEFHJOH.MCDCNJCJCAB/*2*/;
		}
		if(CEJDIAECJKD.NKGJOAEDCPH.OHIOIDCLIEO)
		{
			return KMBJEEFHJOH.JFAGADLHIED/*3*/;
		}
		if(CEJDIAECJKD.NKGJOAEDCPH.PEOIMDCECDL)
			return KMBJEEFHJOH.EOMIACEPHGA/*4*/;
		if(CEJDIAECJKD.NKGJOAEDCPH.BMEHOMDBEIH)
			return KMBJEEFHJOH.CCAPCGPIIPF/*1*/;
		if(CEJDIAECJKD.NKGJOAEDCPH.AKHBHEFFNJC)
			return KMBJEEFHJOH.CCAPCGPIIPF/*1*/;
		if(CEJDIAECJKD.NKGJOAEDCPH.BEIECJDELHK_WavFlag)
		{
			if(CEJDIAECJKD.KKPAHLMJKIH_WavId < 1)
				return KMBJEEFHJOH.MCDCNJCJCAB/*2*/;
			if(EDLHFANJJJK_IsSongInstalled(CEJDIAECJKD.KKPAHLMJKIH_WavId))
				return KMBJEEFHJOH.MCDCNJCJCAB/*2*/;
			return KMBJEEFHJOH.JFAGADLHIED/*3*/;
		}
		if(CEJDIAECJKD.NKGJOAEDCPH.EELHAIGHFAC_EventFlag)
		{
			if(CEJDIAECJKD.EKANGPODCEP_EventId == 0)
				return KMBJEEFHJOH.MCDCNJCJCAB/*2*/;
			if(BFHLPPDKOPC_Event1.Count < 1)
				return KMBJEEFHJOH.JFAGADLHIED/*3*/;
			for(int i = 0; i < BFHLPPDKOPC_Event1.Count; i++)
			{
				if(BFHLPPDKOPC_Event1[i] == CEJDIAECJKD.EKANGPODCEP_EventId)
					return KMBJEEFHJOH.CCAPCGPIIPF/*1*/;
			}
			if(KCCLHODILPA_Event2.Count < 1)
				return KMBJEEFHJOH.JFAGADLHIED/*3*/;
			for(int i = 0; i < KCCLHODILPA_Event2.Count; i++)
			{
				if(KCCLHODILPA_Event2[i] == CEJDIAECJKD.EKANGPODCEP_EventId)
					return KMBJEEFHJOH.MCDCNJCJCAB/*2*/;
			}
			return KMBJEEFHJOH.JFAGADLHIED/*3*/;
		}
		if(CEJDIAECJKD.NKGJOAEDCPH.NGPLFEMNNPP_GachaFlag)
		{
			if(CEJDIAECJKD.HHGMPEEGFMA_GachaId == 0)
				return KMBJEEFHJOH.MCDCNJCJCAB/*2*/;
			if(JNDKAFPBENO_Gacha.Count < 1)
				return KMBJEEFHJOH.JFAGADLHIED/*3*/;
			for(int i = 0; i < JNDKAFPBENO_Gacha.Count; i++)
			{
				if(JNDKAFPBENO_Gacha[i] == CEJDIAECJKD.HHGMPEEGFMA_GachaId)
					return KMBJEEFHJOH.CCAPCGPIIPF/*1*/;
			}
			return KMBJEEFHJOH.JFAGADLHIED/*3*/;
		}
		if(CEJDIAECJKD.NKGJOAEDCPH.NIPNNJBPBFL_PickupFlag)
		{
			if(CEJDIAECJKD.DIDOFBIHPMB_PickupId == 0)
				return KMBJEEFHJOH.MCDCNJCJCAB/*2*/;
			if(IBBMNGEHDEP_Pickup.Count < 1)
				return KMBJEEFHJOH.MCDCNJCJCAB/*2*/;
			for(int i = 0; i < IBBMNGEHDEP_Pickup.Count; i++)
			{
				if(IBBMNGEHDEP_Pickup[i] == CEJDIAECJKD.DIDOFBIHPMB_PickupId)
					return KMBJEEFHJOH.CCAPCGPIIPF/*1*/;
			}
			return KMBJEEFHJOH.MCDCNJCJCAB/*2*/;
		}
		if(CEJDIAECJKD.NKGJOAEDCPH.ALKDIKCBKDC_ItemFlag)
		{
			if(CEJDIAECJKD.INFIBMLIHLO_ItemId == 0)
				return KMBJEEFHJOH.MCDCNJCJCAB/*2*/;
			return (KMBJEEFHJOH)EKLNMHFCAOI.LKBIIPBKNGJ_GetItemFileStatus(CEJDIAECJKD.INFIBMLIHLO_ItemId);
		}
		return KMBJEEFHJOH.MCDCNJCJCAB/*2*/;
	}

	//// RVA: 0x16010D4 Offset: 0x16010D4 VA: 0x16010D4
	public static KMBJEEFHJOH FABLNMEEKKF_GetFileKeepStatus(string CJEKGLGBIHF, HODOGPOKOOJ.KNNLDAHADJB GKOAGCJNBBM)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IELDDHJMFKN_Asset != null)
			{
				return FABLNMEEKKF_GetFileKeepStatus(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IELDDHJMFKN_Asset.NBHDIKJMLEN(CJEKGLGBIHF), GKOAGCJNBBM);
			}
		}
		return KMBJEEFHJOH.MCDCNJCJCAB/*2*/;
	}

	//// RVA: 0x1600FA4 Offset: 0x1600FA4 VA: 0x1600FA4
	private static bool EDLHFANJJJK_IsSongInstalled(int KKPAHLMJKIH)
	{
		return SoundResource.IsInstalledCueSheet(ECLAOLBGCDD[0] + KKPAHLMJKIH.ToString("D4"));
	}
}
