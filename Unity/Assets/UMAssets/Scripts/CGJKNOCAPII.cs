
using System.Collections.Generic;
using XeApp.Game.Common;
using XeApp.Game.Menu;

public class CGJKNOCAPII
{
	public string JOPOPMLFINI_MasterName; // 0x8
	public string DGCOMDILAKM; // 0xC
	public int PGIIDPEGGPI; // 0x10
	public int JHAOHBNPMNA_EventId; // 0x14
	public int LFCOJABLOEN; // 0x18
	public long KINJOEIAHFK_Start; // 0x20
	public long PCCFAKEOBIC_End; // 0x28
	public int BCOKKAALGHC; // 0x30
	public bool PNFDMBHDPAJ; // 0x34
	public BadgeConstant.ID BEEIIJJKDBH; // 0x38
	public string BHANMJKCCBC_QuestAchievedCountText; // 0x3C
	public int PKNLMLDKCLM_AchievedQuests; // 0x40
	public IKDICBBFBMI_EventBase COAMJFMEIBF; // 0x44
	public BKANGIKIEML.NODKLJHEAJB NNHHNFFLCFO; // 0x48
	public long BALFPCLMOGJ; // 0x50

	//// RVA: 0x12BC47C Offset: 0x12BC47C VA: 0x12BC47C
	public int KJILFMNCDLC()
	{
		return (int)(PCCFAKEOBIC_End - NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
	}

	//// RVA: 0x12BC584 Offset: 0x12BC584 VA: 0x12BC584
	public CGJKNOCAPII BJKJLDPDEFA(IKDICBBFBMI_EventBase FBFNJMKPBBA, bool PNGKOHDEPFE = true)
	{
		long l1 = 0;
		long l2 = 0;
		long l3 = 0;
		long l4 = 0;
		bool b1 = false;
		CGJKNOCAPII res = new CGJKNOCAPII();
		res.JOPOPMLFINI_MasterName = FBFNJMKPBBA.JOPOPMLFINI;
		res.LFCOJABLOEN = FBFNJMKPBBA.PGIIDPEGGPI_EventId;
		res.DGCOMDILAKM = FBFNJMKPBBA.DGCOMDILAKM_EventName;
		res.PGIIDPEGGPI = FBFNJMKPBBA.PGIIDPEGGPI_EventId;
		res.JHAOHBNPMNA_EventId = FBFNJMKPBBA.PGIIDPEGGPI_EventId;
		res.COAMJFMEIBF = FBFNJMKPBBA;
		if(FBFNJMKPBBA.NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI_6/*6*/)
		{
			res.KINJOEIAHFK_Start = FBFNJMKPBBA.GLIMIGNNGGB_Start;
			res.PCCFAKEOBIC_End = FBFNJMKPBBA.DPJCPDKALGI_End1;
		}
		else
		{
			res.KINJOEIAHFK_Start = FBFNJMKPBBA.DPJCPDKALGI_End1 + 1;
			res.PCCFAKEOBIC_End = FBFNJMKPBBA.LJOHLEGGGMC;
		}
		res.PNFDMBHDPAJ = FBFNJMKPBBA.NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD.MEAJLPAHINL_5/*5*/;
		res.BCOKKAALGHC = 0;
		if(FBFNJMKPBBA is KNKDBNFMAKF_EventSp)
		{
			TodoLogger.LogError(TodoLogger.EventSp_7, "Event SP");
		}
		res.NNHHNFFLCFO = ILLPDLODANB.ODEHLBNBPPE(FBFNJMKPBBA);
		res.BEEIIJJKDBH = 0;
		res.BHANMJKCCBC_QuestAchievedCountText = "";
		if(PNGKOHDEPFE)
		{
			List<FKMOKDCJFEN> l = QuestUtility.GetEventQuestList(res.JOPOPMLFINI_MasterName);
			if(l == null)
			{
				l = FKMOKDCJFEN.KJHKBBBDBAL(res.JOPOPMLFINI_MasterName, false, res.BCOKKAALGHC);
			}
			PKNLMLDKCLM_AchievedQuests = QuestUtility.GetQuestCountByStatus(l, FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved);
			if(PKNLMLDKCLM_AchievedQuests > 0)
			{
				res.BEEIIJJKDBH = BadgeConstant.ID.Label;
				res.BHANMJKCCBC_QuestAchievedCountText = QuestUtility.GetAchievedCountText(PKNLMLDKCLM_AchievedQuests);
			}
		}
		res.BALFPCLMOGJ = 0;
		return res;
	}

	//// RVA: 0x12BC978 Offset: 0x12BC978 VA: 0x12BC978
	public static List<CGJKNOCAPII> JHCHAOJFHFG(bool PNGKOHDEPFE = true)
	{
		List<CGJKNOCAPII> res = new List<CGJKNOCAPII>();
		List<CGJKNOCAPII> l2 = new List<CGJKNOCAPII>();
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		for(int i = 0; i < JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Count; i++)
		{
			IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN[i];
			ev.HCDGELDHFHB_UpdateStatus(time);
			if(ev.KKFEDJNIAAG(time) && ev.AGLILDLEFDK != null)
			{
				if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp)
				{
					TodoLogger.LogError(TodoLogger.EventSp_7, "Event SP");
				}
				if(ev is PKNOKJNLPOE_EventRaid)
				{
					TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event Raid");
				}
				for(int j = 0; j < ev.AGLILDLEFDK.Count; j++)
				{
					if(ev.AGLILDLEFDK[j].PPEGAKEIEGM_Enabled == 2)
					{
						CGJKNOCAPII data = new CGJKNOCAPII();
						data = data.BJKJLDPDEFA(ev, PNGKOHDEPFE);
						if(!data.PNFDMBHDPAJ)
						{
							res.Add(data);
						}
						else
						{
							l2.Add(data);
						}
						break;
					}
				}
			}
		}
		res.Sort((CGJKNOCAPII HKICMNAACDA, CGJKNOCAPII BNKHBCBJBKI) =>
		{
			//0x12BD938
			if (HKICMNAACDA.PCCFAKEOBIC_End == BNKHBCBJBKI.PCCFAKEOBIC_End)
				return HKICMNAACDA.JHAOHBNPMNA_EventId.CompareTo(BNKHBCBJBKI.JHAOHBNPMNA_EventId);
			return HKICMNAACDA.PCCFAKEOBIC_End.CompareTo(BNKHBCBJBKI.PCCFAKEOBIC_End);
		});
		l2.Sort((CGJKNOCAPII HKICMNAACDA, CGJKNOCAPII BNKHBCBJBKI) =>
		{
			//0x12BD9C4
			if (HKICMNAACDA.PCCFAKEOBIC_End == BNKHBCBJBKI.PCCFAKEOBIC_End)
				return HKICMNAACDA.JHAOHBNPMNA_EventId.CompareTo(BNKHBCBJBKI.JHAOHBNPMNA_EventId);
			return HKICMNAACDA.PCCFAKEOBIC_End.CompareTo(BNKHBCBJBKI.PCCFAKEOBIC_End);
		});
		res.AddRange(l2);
		return res;
	}

	//// RVA: 0x12BD220 Offset: 0x12BD220 VA: 0x12BD220
	public CGJKNOCAPII NLCNDMLOCBC(int APFDNBGMMMM, bool PNGKOHDEPFE = true)
	{
		CGJKNOCAPII res = new CGJKNOCAPII();
		res.JOPOPMLFINI_MasterName = "";
		res.DGCOMDILAKM = "";
		res.PGIIDPEGGPI = APFDNBGMMMM;
		res.JHAOHBNPMNA_EventId = GNGMCIAIKMA.HHCJCDFCLOB.CBMJAPJKBNL(APFDNBGMMMM);
		res.LFCOJABLOEN = GNGMCIAIKMA.HHCJCDFCLOB.CBMJAPJKBNL(APFDNBGMMMM);
		res.COAMJFMEIBF = null;
		JKICPBIIHNE_Bingo.HNOGDJFJGPM bingo = GNGMCIAIKMA.HHCJCDFCLOB.EBEDAPJFHCE_GetBingo(APFDNBGMMMM);
		res.KINJOEIAHFK_Start = bingo.PDBPFJJCADD_StartTime;
		res.NNHHNFFLCFO = BKANGIKIEML.NODKLJHEAJB.BPNDHDHHKGE_38/*38*/;
		res.BEEIIJJKDBH = 0;
		res.PCCFAKEOBIC_End = bingo.FDBNFFNFOND_EndTime;
		res.PNFDMBHDPAJ = false;
		res.BHANMJKCCBC_QuestAchievedCountText = "";
		if(PNGKOHDEPFE)
		{
			res.PKNLMLDKCLM_AchievedQuests = GNGMCIAIKMA.HHCJCDFCLOB.OBOGIOGEBPK(APFDNBGMMMM, FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved);
			if(res.PKNLMLDKCLM_AchievedQuests > 0)
			{
				res.BHANMJKCCBC_QuestAchievedCountText = QuestUtility.GetAchievedCountText(res.PKNLMLDKCLM_AchievedQuests);
			}
		}
		res.BALFPCLMOGJ = 0;
		if(!GNGMCIAIKMA.HHCJCDFCLOB.DOEGBMNNFKH(APFDNBGMMMM))
		{
			if(!GNGMCIAIKMA.HHCJCDFCLOB.DHPLHALIDHH(APFDNBGMMMM))
			{
				res.BALFPCLMOGJ = GNGMCIAIKMA.HHCJCDFCLOB.GKDBBGIEPLC(APFDNBGMMMM);
			}
		}
		return res;
	}

	//// RVA: 0x12BD520 Offset: 0x12BD520 VA: 0x12BD520
	public static List<CGJKNOCAPII> GOGBAODOOAO(bool PNGKOHDEPFE = true)
	{
		List<CGJKNOCAPII> res = new List<CGJKNOCAPII>();
		if(GNGMCIAIKMA.HHCJCDFCLOB != null)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			GNGMCIAIKMA.HHCJCDFCLOB.KIAAOBFJCHP(time);
			List<int> bingos = GNGMCIAIKMA.HHCJCDFCLOB.CNADOFDDNLO_GetActiveBingos(time);
			for(int i = 0; i < bingos.Count; i++)
			{
				CGJKNOCAPII data = new CGJKNOCAPII();
				CGJKNOCAPII data2 = data.NLCNDMLOCBC(bingos[i], PNGKOHDEPFE);
				res.Add(data2);
			}
			res.Sort((CGJKNOCAPII HKICMNAACDA, CGJKNOCAPII BNKHBCBJBKI) =>
			{
				//0x12BDA50
				if (HKICMNAACDA.PCCFAKEOBIC_End == BNKHBCBJBKI.PCCFAKEOBIC_End)
					return HKICMNAACDA.JHAOHBNPMNA_EventId.CompareTo(BNKHBCBJBKI.JHAOHBNPMNA_EventId);
				return HKICMNAACDA.PCCFAKEOBIC_End.CompareTo(BNKHBCBJBKI.PCCFAKEOBIC_End);
			});
		}
		return res;
	}
}
