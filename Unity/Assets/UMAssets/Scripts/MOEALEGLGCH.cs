
using System.Collections.Generic;
using System.Text;
using XeSys;

public class MOEALEGLGCH
{
	private Dictionary<int, string> KGNCCIDGGCC; // 0x10

	// Properties
	public List<int> NBIGLBMHEDC { get; set; } // 0x8 ELHJMCKHBBO DGMMMDMLCJF PICPPMMJAEH
	public List<LFAFJCNKLML> MGJKEJHEBPO { get; set; } // 0xC DPHOPMPKAHK BNPJIIPJJLJ HOKDNOFCDHM

	//[CompilerGeneratedAttribute] // RVA: 0x7406C4 Offset: 0x7406C4 VA: 0x7406C4
	//// RVA: 0x17B2DA8 Offset: 0x17B2DA8 VA: 0x17B2DA8
	//public List<int> DGMMMDMLCJF() { }

	//[CompilerGeneratedAttribute] // RVA: 0x7406D4 Offset: 0x7406D4 VA: 0x7406D4
	//// RVA: 0x17B2DB0 Offset: 0x17B2DB0 VA: 0x17B2DB0
	//private void PICPPMMJAEH(List<int> NANNGLGOFKH) { }

	//[CompilerGeneratedAttribute] // RVA: 0x7406E4 Offset: 0x7406E4 VA: 0x7406E4
	//// RVA: 0x17B2DB8 Offset: 0x17B2DB8 VA: 0x17B2DB8
	//public List<LFAFJCNKLML> BNPJIIPJJLJ() { }

	//[CompilerGeneratedAttribute] // RVA: 0x7406F4 Offset: 0x7406F4 VA: 0x7406F4
	//// RVA: 0x17B2DC0 Offset: 0x17B2DC0 VA: 0x17B2DC0
	//private void HOKDNOFCDHM(List<LFAFJCNKLML> NANNGLGOFKH) { }

	//// RVA: 0x17B2DC8 Offset: 0x17B2DC8 VA: 0x17B2DC8
	public void KHEKNNFCAOI()
	{
		NBIGLBMHEDC = new List<int>(10);
		MGJKEJHEBPO = LFAFJCNKLML.FKDIMODKKJD(NBIGLBMHEDC);
		JOMFNNJHNIJ();
	}

	//// RVA: 0x17B2E64 Offset: 0x17B2E64 VA: 0x17B2E64
	private void JOMFNNJHNIJ()
	{
		MessageBank bk = MessageManager.Instance.GetBank("master");
		StringBuilder str = new StringBuilder(32);
		KGNCCIDGGCC = new Dictionary<int, string>();
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.FDNBEPCEHBH.Count; i++)
		{
			LCLCCHLDNHJ_Costume.JMEHNBGDEBD d = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.FDNBEPCEHBH[i + 1];
			for(int j = 0; j < d.NKNBKLHCAFD.Length; j++)
			{
				if(d.NKNBKLHCAFD[j].INDDJNMPONH != 0)
				{
					if(!KGNCCIDGGCC.ContainsKey(d.NKNBKLHCAFD[j].INDDJNMPONH))
					{
						str.SetFormat("cos_unlock_{0:D4}", d.NKNBKLHCAFD[j].INDDJNMPONH);
						KGNCCIDGGCC.Add(d.NKNBKLHCAFD[j].INDDJNMPONH, bk.GetMessageByLabel(str.ToString()));
					}
				}
			}
		}
	}

	//// RVA: 0x17B325C Offset: 0x17B325C VA: 0x17B325C
	public List<LFAFJCNKLML> NLLHENIPDDA(List<int> NBIGLBMHEDC)
	{
		if(NBIGLBMHEDC == null || NBIGLBMHEDC.Count < 1)
		{
			return MGJKEJHEBPO;
		}
		else
		{
			List<LFAFJCNKLML> res = new List<LFAFJCNKLML>(MGJKEJHEBPO.Count);
			for(int i = 0; i < MGJKEJHEBPO.Count; i++)
			{
				if(NBIGLBMHEDC.Contains(MGJKEJHEBPO[i].AHHJLDLAPAN_DivaId))
				{
					res.Add(MGJKEJHEBPO[i]);
				}
			}
			return res;
		}
	}

	//// RVA: 0x17B3438 Offset: 0x17B3438 VA: 0x17B3438
	//public static int LLCBDMCPBOD() { }

	//// RVA: 0x17B3514 Offset: 0x17B3514 VA: 0x17B3514
	//public static int LCLMFJOBPOK() { }

	//// RVA: 0x17B3604 Offset: 0x17B3604 VA: 0x17B3604
	public static int IGDOBKHKNJM_GetCostumeUpgradeOfferNum()
	{
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("costume_upgrade_complete_offer_num", 10);
	}

	//// RVA: 0x17B36F4 Offset: 0x17B36F4 VA: 0x17B36F4
	public static bool CDOCOLOKCJK()
	{
		return IGDOBKHKNJM_GetCostumeUpgradeOfferNum() <= KDHGBOOECKC.HHCJCDFCLOB.DEAIKHLFFCL_GetTotalVOp(0);
	}

	//// RVA: 0x17B3744 Offset: 0x17B3744 VA: 0x17B3744
	public static int FLGEJDKMNMI()
	{
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("costume_upgrade_vc_count", 5);
	}

	//// RVA: 0x17B3834 Offset: 0x17B3834 VA: 0x17B3834
	//public int GJFJBGNCBAP(LFAFJCNKLML IDLHJIOMJBK, int ANAJIAENLNB) { }

	//// RVA: 0x17B38E8 Offset: 0x17B38E8 VA: 0x17B38E8
	//public int GJFJBGNCBAP(LFAFJCNKLML IDLHJIOMJBK) { }

	//// RVA: 0x17B3920 Offset: 0x17B3920 VA: 0x17B3920
	private int EBFFMJHDHIO(int ANAJIAENLNB)
	{
		int res = 0;
		for(int i = 0; i < MGJKEJHEBPO.Count; i++)
		{
			if (MGJKEJHEBPO[i].GKIKAABHAAD_Level >= ANAJIAENLNB)
				res++;
		}
		return res;
	}

	//// RVA: 0x17B3A18 Offset: 0x17B3A18 VA: 0x17B3A18
	//public string EGFDDHPPFNE(LFAFJCNKLML IDLHJIOMJBK, int ANAJIAENLNB, int OIPCCBHIKIA) { }

	//// RVA: 0x17B4034 Offset: 0x17B4034 VA: 0x17B4034
	//public string EGFDDHPPFNE(LFAFJCNKLML IDLHJIOMJBK, int OIPCCBHIKIA) { }

	//// RVA: 0x17B4084 Offset: 0x17B4084 VA: 0x17B4084
	//public bool HEOGHOIOHGI(LFAFJCNKLML IDLHJIOMJBK, int ANAJIAENLNB, int OIPCCBHIKIA, out int KOGEGJOOMIG, out int JDLJPNMLFID) { }

	//// RVA: 0x17B42E0 Offset: 0x17B42E0 VA: 0x17B42E0
	//public bool HEOGHOIOHGI(LFAFJCNKLML IDLHJIOMJBK, int OIPCCBHIKIA, out int KOGEGJOOMIG, out int JDLJPNMLFID) { }

	//// RVA: 0x17B4334 Offset: 0x17B4334 VA: 0x17B4334
	public bool KFJHILDJCCB(LFAFJCNKLML IDLHJIOMJBK, int ANAJIAENLNB)
	{
		LFAFJCNKLML.FHLDDEKAJKI d = IDLHJIOMJBK.OCOOHBINGBG[ANAJIAENLNB];
		if(d.KBOLNIBLIND != null)
		{
			for(int i = 0; i < d.KBOLNIBLIND.Length; i++)
			{
				bool b = true;
				if (d.KBOLNIBLIND[i].INDDJNMPONH_Unlock < LCLCCHLDNHJ_Costume.LKLGPLFNJBA.AEFCOHJBLPO/*4*/)
				{
					switch(d.KBOLNIBLIND[i].INDDJNMPONH_Unlock)
					{
						case LCLCCHLDNHJ_Costume.LKLGPLFNJBA.HJNNKCMLGFL/*0*/:
							continue;
						case LCLCCHLDNHJ_Costume.LKLGPLFNJBA.NBEFPGIMEGA/*1*/:
							b = d.KBOLNIBLIND[i].PIBLLGLCJEO[1] <= EBFFMJHDHIO(d.KBOLNIBLIND[i].PIBLLGLCJEO[0]);
							break;
						case LCLCCHLDNHJ_Costume.LKLGPLFNJBA.BCJHILDCONA/*2*/:
							PLPBJOFICEJ_CosItem.IBEMFIAFIKH dbCosItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GOGFKAECFIP_CosItem.LBDOLHGDIEB(IDLHJIOMJBK.AHHJLDLAPAN_DivaId, PLPBJOFICEJ_CosItem.DPNGHIDJCHA.GLHANCMGNDM/*2*/);
							b = d.KBOLNIBLIND[i].PIBLLGLCJEO[0] <= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.EFBKCNNFIPJ(dbCosItem.PPFNGGCBJKC).BFINGCJHOHI_Cnt;
							break;
						case LCLCCHLDNHJ_Costume.LKLGPLFNJBA.CALCHKAMIDB/*3*/:
							b = d.KBOLNIBLIND[i].PIBLLGLCJEO[0] <= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(IDLHJIOMJBK.AHHJLDLAPAN_DivaId).KCCONFODCPN_IntimacyLevel;
							break;
					}
				}
				else
				{
					b = false;
				}
				if (!b)
					return false;
			}
		}
		return true;
	}

	//// RVA: 0x17B47F0 Offset: 0x17B47F0 VA: 0x17B47F0
	public bool KFJHILDJCCB(LFAFJCNKLML IDLHJIOMJBK)
	{
		return KFJHILDJCCB(IDLHJIOMJBK, IDLHJIOMJBK.GKIKAABHAAD_Level);
	}

	//// RVA: 0x17B4830 Offset: 0x17B4830 VA: 0x17B4830
	//public bool EJOALPKJKIG(LFAFJCNKLML IDLHJIOMJBK, int ANAJIAENLNB) { }

	//// RVA: 0x17B4918 Offset: 0x17B4918 VA: 0x17B4918
	//public bool EJOALPKJKIG(LFAFJCNKLML IDLHJIOMJBK) { }

	//// RVA: 0x17B4950 Offset: 0x17B4950 VA: 0x17B4950
	//public int DLJJACACBDI(int JBPCPCBLNDC, int MHFBCINOJEE, int HMFFHLPNMPH) { }

	//// RVA: 0x17B4BFC Offset: 0x17B4BFC VA: 0x17B4BFC
	//public int JDLAFDBFLOM(LFAFJCNKLML IDLHJIOMJBK, IMCBBOAFION BHFHGFKBOHH) { }

	//// RVA: 0x17B5320 Offset: 0x17B5320 VA: 0x17B5320
	//public void COLOGGOJGAJ() { }

	//// RVA: 0x17B53FC Offset: 0x17B53FC VA: 0x17B53FC
	//public int CALNLFGDMEE(int JBPCPCBLNDC, int KOGEGJOOMIG, int HMFFHLPNMPH, IMCBBOAFION BHFHGFKBOHH) { }

	//[IteratorStateMachineAttribute] // RVA: 0x740704 Offset: 0x740704 VA: 0x740704
	//// RVA: 0x17B5D1C Offset: 0x17B5D1C VA: 0x17B5D1C
	//private IEnumerator FOALKNNPKHG(int AHHJLDLAPAN, int CBGMGJLLDOO, IMCBBOAFION BHFHGFKBOHH) { }
}
