
using System.Collections.Generic;

public class LIEJFHMGNIA : EEDKAACNBBG_MusicData
{
	public class AGDCEJNCPDE
	{
		// Fields
		public const int JIKCABGFIEG = 0;
		public const int IPJKMCONMEB = 1;
		public const int EFFOOAJNBKC = 2;
		public const int DDBPGOCNAGL = 4;
		public const int JAOBGNNJFLA = 8;
		public const int KBMMFEFPHMI = 16;
	}

	public static bool DHNMLIJIKNA; // 0x0
	public static bool OJEBNBLHPNP; // 0x1
	public static int IBODEOADPCP; // 0x4
	public int LFLLLOPAKCO; // 0x40
	public bool EOBACDCDGOF; // 0x44
	public bool ENEKMHMKNFK; // 0x45
	public int KLCIIHKFPPO; // 0x48
	public int AHHJLDLAPAN; // 0x4C
	public bool CADENLBDAEB; // 0x50
	public bool BCGLDMKODLC; // 0x51
	public int DDNCFHEKBAF; // 0x54
	public string FHPHCFEEBMP; // 0x58
	public bool NDLKPJDHHCN; // 0x5C
	public bool DHPNLACAGPG; // 0x5D
	public bool PGCCOCKGCKO; // 0x5E
	public bool MBJOBPJKGBO; // 0x5F
	public bool CGDIFBMIJJH; // 0x60
	public int KEFGPJBKAOD; // 0x64
	public int JJPKBHLKILC; // 0x68
	public bool JJFMMNBEABA; // 0x6C
	public bool ELIHAGFNOBN; // 0x6D
	public EJKBKMBJMGL_EnemyData HPBPDHPIBGN; // 0x70
	public int NDFOAINJPIN; // 0x74
	private int GJIIGKLIGLA; // 0x78

	public bool MMEGDFPNONJ { get { return AHHJLDLAPAN != 0; } } //0x17F754C LCEFNOMFGCC
	public bool HHBJAEOIGIH { get { return DDNCFHEKBAF != 0; } } //0x17F755C EEGJFFAIOPD
	//public bool PCFICCCLBNP { get; } 0x17F756C NNCIIIFBKEG
	//public bool GOELFAECHGI { get; } 0x17F758C AAFHNPBKGCH

	//// RVA: 0x17F76D8 Offset: 0x17F76D8 VA: 0x17F76D8
	//public void KHEKNNFCAOI(int LFLLLOPAKCO) { }

	//// RVA: 0x17F7FB4 Offset: 0x17F7FB4 VA: 0x17F7FB4
	//public void OIAMHMDHGKE(int HMFFHLPNMPH) { }

	//// RVA: 0x17F810C Offset: 0x17F810C VA: 0x17F810C
	//public void PMBLGPGHNEE(int HMFFHLPNMPH) { }

	//// RVA: 0x17F8138 Offset: 0x17F8138 VA: 0x17F8138
	//public static int MGKOEEMNFJD(int LFLLLOPAKCO) { }

	//// RVA: 0x17F87C8 Offset: 0x17F87C8 VA: 0x17F87C8
	//private void IHKEMKHANHM() { }

	//// RVA: 0x17F7CDC Offset: 0x17F7CDC VA: 0x17F7CDC
	//public void HCDGELDHFHB() { }

	//// RVA: 0x17F9134 Offset: 0x17F9134 VA: 0x17F9134
	//public string EJKPLJCMHMP() { }

	//// RVA: 0x17F87CC Offset: 0x17F87CC VA: 0x17F87CC
	//private void FLIFKFOGEAM() { }

	//// RVA: 0x17F99CC Offset: 0x17F99CC VA: 0x17F99CC
	//public void JLHOLHCDELP() { }

	//// RVA: 0x17F9F24 Offset: 0x17F9F24 VA: 0x17F9F24
	//public void CPIPDGGOLFO() { }

	//// RVA: 0x17FA138 Offset: 0x17FA138 VA: 0x17FA138
	//public void MFEGPPKFCEI() { }

	//// RVA: 0x17FA294 Offset: 0x17FA294 VA: 0x17FA294
	public static int PJIJLMFBBCJ()
	{
		return 1;
	}

	//// RVA: 0x17FA29C Offset: 0x17FA29C VA: 0x17FA29C
	public static List<LIEJFHMGNIA> FKDIMODKKJD(int KFOLEAPKGFC = 0, bool POOMOBGPCNE = true, bool OKIAAPADPLM = true, bool HFOAFJBMNOF = false)
	{
		int storyEnd = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ACNNFJJMEEO_StoryEnd;
		LAEGMENIEDB_Story.ALGOILKGAAH LODFKHJLGJP = null;
		List<LIEJFHMGNIA> res = new List<LIEJFHMGNIA>();
		int a = 0;
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA.Count; i++)
		{
			LAEGMENIEDB_Story.ALGOILKGAAH dbStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA[i];
			if(dbStory.PPEGAKEIEGM_Enabled == 2)
			{
				NEKDCJKANAH_StoryRecord.HKDNILFKCFC saveStory = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[i];
				if(saveStory.EALOBDHOCHP_Stat != 0)
				{
					if (storyEnd > 0 && storyEnd != a)
					{
						LODFKHJLGJP = dbStory;
					}
					if (dbStory.NOCGGJPABMA > 0)
						storyEnd++;
					a++;
					if(dbStory.MHPAFEEPBNJ == KFOLEAPKGFC + 1)
					{
						LIEJFHMGNIA data = new LIEJFHMGNIA();
						data.KHEKNNFCAOI(dbStory.LFLLLOPAKCO);
						res.Add(data);
					}
				}
			}
		}
		if(LODFKHJLGJP != null)
		{
			LIEJFHMGNIA d = res.Find((LIEJFHMGNIA GHPLINIACBB) =>
			{
				//0x17FE088
				return LODFKHJLGJP.LFLLLOPAKCO == GHPLINIACBB.LFLLLOPAKCO;
			});
			if (d != null && d.NDLKPJDHHCN)
				d.ENEKMHMKNFK = true;
		}
		res.Sort((LIEJFHMGNIA HKICMNAACDA, LIEJFHMGNIA BNKHBCBJBKI) =>
		{
			//0x17FE01C
			return HKICMNAACDA.NDFOAINJPIN.CompareTo(BNKHBCBJBKI.NDFOAINJPIN);
		});
		if (!OKIAAPADPLM)
			return res;
		if(res.Count == 0 || !(
			!res[res.Count - 1].BCGLDMKODLC && (res[res.Count - 1].AHHJLDLAPAN < 1 || res[res.Count - 1].DDNCFHEKBAF != 0)
			))
		{
			for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA.Count; i++)
			{
				LAEGMENIEDB_Story.ALGOILKGAAH dbStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA[i];
				if (dbStory.PPEGAKEIEGM_Enabled == 2)
				{
					NEKDCJKANAH_StoryRecord.HKDNILFKCFC saveStory = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[i];
					if (dbStory.MHPAFEEPBNJ == KFOLEAPKGFC + 1)
					{
						if(saveStory.EALOBDHOCHP_Stat == 0)
						{
							if(dbStory.NOCGGJPABMA == 0)
							{
								CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LNOOKHJBENO_StoryRecord.ODOKNPHEIFN(dbStory.LFLLLOPAKCO, 1);
								LIEJFHMGNIA data = new LIEJFHMGNIA();
								data.KHEKNNFCAOI(dbStory.LFLLLOPAKCO);
								res.Add(data);
								if (data.DDNCFHEKBAF != 0)
									break;
								if (data.AHHJLDLAPAN == 0 && !data.BCGLDMKODLC)
									break;
							}
						}
					}
				}
			}
		}
		if(HFOAFJBMNOF)
		{
			FDEGGJPAOHM(res);
			PHNNCGBNCGO(res);
		}
		return res;
	}

	//// RVA: 0x17FB06C Offset: 0x17FB06C VA: 0x17FB06C
	//public static void PMBEMMPPNMN(List<LIEJFHMGNIA> NNDGIAEFMOG) { }

	//// RVA: 0x17FAE64 Offset: 0x17FAE64 VA: 0x17FAE64
	public static bool FDEGGJPAOHM(List<LIEJFHMGNIA> NNDGIAEFMOG)
	{
		if(OCIKEFNDJKC(NNDGIAEFMOG, 1))
		{
			LIEJFHMGNIA data = DJAHKAIDCKH(1);
			if(data != null)
			{
				data.CGDIFBMIJJH = true;
				NNDGIAEFMOG.Add(data);
			}
			return true;
		}
		return false;
	}

	//// RVA: 0x17FAF6C Offset: 0x17FAF6C VA: 0x17FAF6C
	public static bool PHNNCGBNCGO(List<LIEJFHMGNIA> NNDGIAEFMOG)
	{
		if (OCIKEFNDJKC(NNDGIAEFMOG, 2))
		{
			LIEJFHMGNIA data = DJAHKAIDCKH(2);
			if (data != null)
			{
				data.CGDIFBMIJJH = true;
				NNDGIAEFMOG.Add(data);
			}
		}
		return false;
	}

	//// RVA: 0x17FB76C Offset: 0x17FB76C VA: 0x17FB76C
	private static bool OCIKEFNDJKC(List<LIEJFHMGNIA> NNDGIAEFMOG, int INDDJNMPONH)
	{
		int f = 0;
		int g = 0;
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA.Count; i++)
		{
			LAEGMENIEDB_Story.ALGOILKGAAH dbStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA[i];
			if(dbStory.PPEGAKEIEGM_Enabled == 2)
			{
				if(dbStory.NOCGGJPABMA == 1)
				{
					f = dbStory.LFLLLOPAKCO;
				}
				if(dbStory.NOCGGJPABMA == 2)
				{
					g = dbStory.LFLLLOPAKCO;
					break;
				}
			}
		}
		if(INDDJNMPONH == 2)
		{
			if (g == 0)
				return false;
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[f - 1].EALOBDHOCHP_Stat < 2)
				return false;
			f = g;
		}
		else
		{
			if (INDDJNMPONH != 1)
				return false;
			if (g == 0)
				return false;
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[2].EALOBDHOCHP_Stat != 4)
				return false;
		}
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[f - 1].EALOBDHOCHP_Stat == 0;
	}

	//// RVA: 0x17FBC28 Offset: 0x17FBC28 VA: 0x17FBC28
	private static LIEJFHMGNIA DJAHKAIDCKH(int INDDJNMPONH)
	{
		int f = 0;
		int g = 0;
		for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA.Count; i++)
		{
			LAEGMENIEDB_Story.ALGOILKGAAH dbStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA[i];
			if (dbStory.PPEGAKEIEGM_Enabled == 2)
			{
				if (dbStory.NOCGGJPABMA == 1)
				{
					f = dbStory.LFLLLOPAKCO;
				}
				if (dbStory.NOCGGJPABMA == 2)
				{
					g = dbStory.LFLLLOPAKCO;
					break;
				}
			}
		}
		if (INDDJNMPONH == 2)
		{
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[f - 1].EALOBDHOCHP_Stat < 2)
				return null;
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[g - 1].EALOBDHOCHP_Stat != 0)
				return null;
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LNOOKHJBENO_StoryRecord.ODOKNPHEIFN(g, 1);
			f = g;
		}
		else
		{
			if (INDDJNMPONH != 1)
				return null;
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[g - 1].EALOBDHOCHP_Stat != 0)
				return null;
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LNOOKHJBENO_StoryRecord.ODOKNPHEIFN(f, 1);
		}
		LIEJFHMGNIA data = new LIEJFHMGNIA();
		data.KHEKNNFCAOI(f);
		return data;
	}

	//// RVA: 0x17FC24C Offset: 0x17FC24C VA: 0x17FC24C
	//public static void PJHMKEGKMGH(List<LIEJFHMGNIA> NNDGIAEFMOG, bool OKIAAPADPLM) { }

	//// RVA: 0x17FC808 Offset: 0x17FC808 VA: 0x17FC808
	//public static int GOLBKEOBAOH(List<LIEJFHMGNIA> NNDGIAEFMOG) { }

	//// RVA: 0x17FC8E0 Offset: 0x17FC8E0 VA: 0x17FC8E0
	//public static int GIEHPDAHFJE(List<LIEJFHMGNIA> NNDGIAEFMOG) { }

	//// RVA: 0x17FC9BC Offset: 0x17FC9BC VA: 0x17FC9BC
	//public static void BPFPIOLIOEM(List<LIEJFHMGNIA> NNDGIAEFMOG) { }

	//// RVA: 0x17FCAD8 Offset: 0x17FCAD8 VA: 0x17FCAD8
	//public static int DKOPDAPDKHE(List<LIEJFHMGNIA> NNDGIAEFMOG) { }

	//// RVA: 0x17FCBB4 Offset: 0x17FCBB4 VA: 0x17FCBB4
	//public static int BKCFCGKBCDC(List<LIEJFHMGNIA> NNDGIAEFMOG) { }

	//// RVA: 0x17FCD28 Offset: 0x17FCD28 VA: 0x17FCD28
	//public static void BELAIBFFJNF(List<LIEJFHMGNIA> NNDGIAEFMOG) { }

	//// RVA: 0x17FCE44 Offset: 0x17FCE44 VA: 0x17FCE44
	//public static int AHJNFDFPCBH(List<LIEJFHMGNIA> NNDGIAEFMOG) { }

	//// RVA: 0x17FCF20 Offset: 0x17FCF20 VA: 0x17FCF20
	//public string MNNKOKNBJNC() { }

	//// RVA: 0x17FD51C Offset: 0x17FD51C VA: 0x17FD51C
	//public static int KLOHKIPGCME(List<LIEJFHMGNIA> NNDGIAEFMOG) { }

	//// RVA: 0x17FD644 Offset: 0x17FD644 VA: 0x17FD644
	public static LIEJFHMGNIA HDKCNAKPAAC(FDDIIKBJNNA ANJGLKIGLAN)
	{
		List<LIEJFHMGNIA> l = FKDIMODKKJD(0, false, false, false);
		for(int i = 0; i < l.Count; i++)
		{
			if(l[i].CADENLBDAEB)
			{
				return l[i];
			}
		}
		return null;
	}

	//// RVA: 0x17FD794 Offset: 0x17FD794 VA: 0x17FD794
	//public static int CCOJMPONIOC() { }

	//// RVA: 0x17FDA24 Offset: 0x17FDA24 VA: 0x17FDA24
	//public static bool OCHGOAKIPPM(List<LIEJFHMGNIA> DJPCNPLJJAF) { }

	//// RVA: 0x17FDD2C Offset: 0x17FDD2C VA: 0x17FDD2C
	//public static bool DJMAJKMBJNE(List<LIEJFHMGNIA> DJPCNPLJJAF) { }

	//// RVA: 0x17F7FE0 Offset: 0x17F7FE0 VA: 0x17F7FE0
	//private bool NNPFKBOJBCI(int HMFFHLPNMPH) { }
}
