
using System.Collections.Generic;
using XeApp.Game.Common;
using XeApp.Game.Menu;

public class CGJKNOCAPII
{
	public string JOPOPMLFINI_QuestName; // 0x8
	public string DGCOMDILAKM_EventName; // 0xC
	public int PGIIDPEGGPI_EventId; // 0x10
	public int JHAOHBNPMNA_EventId; // 0x14
	public int LFCOJABLOEN_EventId; // 0x18
	public long KINJOEIAHFK_StartTime; // 0x20
	public long PCCFAKEOBIC_EndTime; // 0x28
	public int BCOKKAALGHC_Group; // 0x30
	public bool PNFDMBHDPAJ_IsRewardOnly; // 0x34
	public BadgeConstant.ID BEEIIJJKDBH_BadgeConstantId; // 0x38
	public string BHANMJKCCBC_BadgeText; // 0x3C
	public int PKNLMLDKCLM_AchievedQuestCount; // 0x40
	public IKDICBBFBMI_EventBase COAMJFMEIBF; // 0x44
	public BKANGIKIEML.NODKLJHEAJB NNHHNFFLCFO; // 0x48
	public long BALFPCLMOGJ; // 0x50

	//// RVA: 0x12BC47C Offset: 0x12BC47C VA: 0x12BC47C
	public int KJILFMNCDLC()
	{
		return (int)(PCCFAKEOBIC_EndTime - NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
	}

	//// RVA: 0x12BC584 Offset: 0x12BC584 VA: 0x12BC584
	public CGJKNOCAPII BJKJLDPDEFA(IKDICBBFBMI_EventBase FBFNJMKPBBA, bool PNGKOHDEPFE/* = true*/)
	{
		long l1 = 0;
		long l2 = 0;
		long l3 = 0;
		long l4 = 0;
		bool b1 = false;
		CGJKNOCAPII res = new CGJKNOCAPII();
		res.JOPOPMLFINI_QuestName = FBFNJMKPBBA.JOPOPMLFINI_QuestName;
		res.LFCOJABLOEN_EventId = FBFNJMKPBBA.PGIIDPEGGPI_EventId;
		res.DGCOMDILAKM_EventName = FBFNJMKPBBA.DGCOMDILAKM_EventName;
		res.PGIIDPEGGPI_EventId = FBFNJMKPBBA.PGIIDPEGGPI_EventId;
		res.JHAOHBNPMNA_EventId = FBFNJMKPBBA.PGIIDPEGGPI_EventId;
		res.COAMJFMEIBF = FBFNJMKPBBA;
		if(FBFNJMKPBBA.NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6/*6*/)
		{
			res.KINJOEIAHFK_StartTime = FBFNJMKPBBA.GLIMIGNNGGB_RankingStart;
			res.PCCFAKEOBIC_EndTime = FBFNJMKPBBA.DPJCPDKALGI_RankingEnd;
		}
		else
		{
			res.KINJOEIAHFK_StartTime = FBFNJMKPBBA.DPJCPDKALGI_RankingEnd + 1;
			res.PCCFAKEOBIC_EndTime = FBFNJMKPBBA.LJOHLEGGGMC_RewardEnd;
		}
		res.PNFDMBHDPAJ_IsRewardOnly = FBFNJMKPBBA.NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5/*5*/;
		res.BCOKKAALGHC_Group = 0;
		if(FBFNJMKPBBA is KNKDBNFMAKF_EventSp)
		{
			KNKDBNFMAKF_EventSp ev = FBFNJMKPBBA as KNKDBNFMAKF_EventSp;
			res.BCOKKAALGHC_Group = ev.MEDEJHKNAFG_GetCurrentMissionGroup(out l1, out l2, out l3, out l4, out b1);
			res.JHAOHBNPMNA_EventId = ev.CBEACDJOIBO_GetIconTextureId(BCOKKAALGHC_Group);
			res.LFCOJABLOEN_EventId = ev.JLLGJIIHFJO_GetTitleTextureId(BCOKKAALGHC_Group);
			res.KINJOEIAHFK_StartTime = b1 ? l3 : l1;
			res.PCCFAKEOBIC_EndTime = b1 ? l4 : l2;
			res.PNFDMBHDPAJ_IsRewardOnly = b1;
		}
		res.NNHHNFFLCFO = ILLPDLODANB.ODEHLBNBPPE(FBFNJMKPBBA);
		res.BEEIIJJKDBH_BadgeConstantId = 0;
		res.BHANMJKCCBC_BadgeText = "";
		if(PNGKOHDEPFE)
		{
			List<FKMOKDCJFEN> l = QuestUtility.GetEventQuestList(res.JOPOPMLFINI_QuestName);
			if(l == null)
			{
				l = FKMOKDCJFEN.KJHKBBBDBAL(res.JOPOPMLFINI_QuestName, false, res.BCOKKAALGHC_Group);
			}
			PKNLMLDKCLM_AchievedQuestCount = QuestUtility.GetQuestCountByStatus(l, FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved);
			if(PKNLMLDKCLM_AchievedQuestCount > 0)
			{
				res.BEEIIJJKDBH_BadgeConstantId = BadgeConstant.ID.Label;
				res.BHANMJKCCBC_BadgeText = QuestUtility.GetAchievedCountText(PKNLMLDKCLM_AchievedQuestCount);
			}
		}
		res.BALFPCLMOGJ = 0;
		return res;
	}

	//// RVA: 0x12BC978 Offset: 0x12BC978 VA: 0x12BC978
	public static List<CGJKNOCAPII> JHCHAOJFHFG(bool PNGKOHDEPFE/* = true*/)
	{
		List<CGJKNOCAPII> res = new List<CGJKNOCAPII>();
		List<CGJKNOCAPII> l2 = new List<CGJKNOCAPII>();
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		for(int i = 0; i < JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Count; i++)
		{
			IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN[i];
			ev.HCDGELDHFHB_UpdateStatus(time);
			if(ev.KKFEDJNIAAG(time) && ev.AGLILDLEFDK_Missions != null)
			{
				if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp)
				{
					if(time < ev.AGLILDLEFDK_Missions[0].KJBGCLPMLCG_OpenedAt)
						continue;
				}
				if(ev is PKNOKJNLPOE_EventRaid)
				{
					NKOBMDPHNGP_EventRaidLobby evLobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Find((IKDICBBFBMI_EventBase JPAEDJJFFOI) =>
					{
						//0x12BD8F4
						return JPAEDJJFFOI.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby;
					}) as NKOBMDPHNGP_EventRaidLobby;
					if(evLobby != null && evLobby.ILCPALOKKHC_GetStep() < JKOHBJPCAJL.CNNCBDKIPGE.EGIOFFACHCP_4 && 
						evLobby.ILCPALOKKHC_GetStep() != JKOHBJPCAJL.CNNCBDKIPGE.ECKNIOGBKJO_2)
						continue;
				}
				for(int j = 0; j < ev.AGLILDLEFDK_Missions.Count; j++)
				{
					if(ev.AGLILDLEFDK_Missions[j].PPEGAKEIEGM_Enabled == 2)
					{
						CGJKNOCAPII data = new CGJKNOCAPII();
						data = data.BJKJLDPDEFA(ev, PNGKOHDEPFE);
						if(!data.PNFDMBHDPAJ_IsRewardOnly)
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
		res.Sort((CGJKNOCAPII _HKICMNAACDA_a, CGJKNOCAPII _BNKHBCBJBKI_b) =>
		{
			//0x12BD938
			if (_HKICMNAACDA_a.PCCFAKEOBIC_EndTime == _BNKHBCBJBKI_b.PCCFAKEOBIC_EndTime)
				return _HKICMNAACDA_a.JHAOHBNPMNA_EventId.CompareTo(_BNKHBCBJBKI_b.JHAOHBNPMNA_EventId);
			return _HKICMNAACDA_a.PCCFAKEOBIC_EndTime.CompareTo(_BNKHBCBJBKI_b.PCCFAKEOBIC_EndTime);
		});
		l2.Sort((CGJKNOCAPII _HKICMNAACDA_a, CGJKNOCAPII _BNKHBCBJBKI_b) =>
		{
			//0x12BD9C4
			if (_HKICMNAACDA_a.PCCFAKEOBIC_EndTime == _BNKHBCBJBKI_b.PCCFAKEOBIC_EndTime)
				return _HKICMNAACDA_a.JHAOHBNPMNA_EventId.CompareTo(_BNKHBCBJBKI_b.JHAOHBNPMNA_EventId);
			return _HKICMNAACDA_a.PCCFAKEOBIC_EndTime.CompareTo(_BNKHBCBJBKI_b.PCCFAKEOBIC_EndTime);
		});
		res.AddRange(l2);
		return res;
	}

	//// RVA: 0x12BD220 Offset: 0x12BD220 VA: 0x12BD220
	public CGJKNOCAPII NLCNDMLOCBC(int _APFDNBGMMMM_BingoId, bool PNGKOHDEPFE/* = true*/)
	{
		CGJKNOCAPII res = new CGJKNOCAPII();
		res.JOPOPMLFINI_QuestName = "";
		res.DGCOMDILAKM_EventName = "";
		res.PGIIDPEGGPI_EventId = _APFDNBGMMMM_BingoId;
		res.JHAOHBNPMNA_EventId = GNGMCIAIKMA.HHCJCDFCLOB.CBMJAPJKBNL(_APFDNBGMMMM_BingoId);
		res.LFCOJABLOEN_EventId = GNGMCIAIKMA.HHCJCDFCLOB.CBMJAPJKBNL(_APFDNBGMMMM_BingoId);
		res.COAMJFMEIBF = null;
		JKICPBIIHNE_Bingo.HNOGDJFJGPM bingo = GNGMCIAIKMA.HHCJCDFCLOB.EBEDAPJFHCE_GetBingo(_APFDNBGMMMM_BingoId);
		res.KINJOEIAHFK_StartTime = bingo.PDBPFJJCADD_open_at;
		res.NNHHNFFLCFO = BKANGIKIEML.NODKLJHEAJB.BPNDHDHHKGE_38/*38*/;
		res.BEEIIJJKDBH_BadgeConstantId = 0;
		res.PCCFAKEOBIC_EndTime = bingo.FDBNFFNFOND_close_at;
		res.PNFDMBHDPAJ_IsRewardOnly = false;
		res.BHANMJKCCBC_BadgeText = "";
		if(PNGKOHDEPFE)
		{
			res.PKNLMLDKCLM_AchievedQuestCount = GNGMCIAIKMA.HHCJCDFCLOB.OBOGIOGEBPK(_APFDNBGMMMM_BingoId, FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved);
			if(res.PKNLMLDKCLM_AchievedQuestCount > 0)
			{
				res.BHANMJKCCBC_BadgeText = QuestUtility.GetAchievedCountText(res.PKNLMLDKCLM_AchievedQuestCount);
			}
		}
		res.BALFPCLMOGJ = 0;
		if(!GNGMCIAIKMA.HHCJCDFCLOB.DOEGBMNNFKH(_APFDNBGMMMM_BingoId))
		{
			if(!GNGMCIAIKMA.HHCJCDFCLOB.DHPLHALIDHH(_APFDNBGMMMM_BingoId))
			{
				res.BALFPCLMOGJ = GNGMCIAIKMA.HHCJCDFCLOB.GKDBBGIEPLC(_APFDNBGMMMM_BingoId);
			}
		}
		return res;
	}

	//// RVA: 0x12BD520 Offset: 0x12BD520 VA: 0x12BD520
	public static List<CGJKNOCAPII> GOGBAODOOAO(bool PNGKOHDEPFE/* = true*/)
	{
		List<CGJKNOCAPII> res = new List<CGJKNOCAPII>();
		if(GNGMCIAIKMA.HHCJCDFCLOB != null)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			GNGMCIAIKMA.HHCJCDFCLOB.KIAAOBFJCHP(time);
			List<int> bingos = GNGMCIAIKMA.HHCJCDFCLOB.CNADOFDDNLO_GetActiveBingos(time);
			for(int i = 0; i < bingos.Count; i++)
			{
				CGJKNOCAPII data = new CGJKNOCAPII();
				CGJKNOCAPII data2 = data.NLCNDMLOCBC(bingos[i], PNGKOHDEPFE);
				res.Add(data2);
			}
			res.Sort((CGJKNOCAPII _HKICMNAACDA_a, CGJKNOCAPII _BNKHBCBJBKI_b) =>
			{
				//0x12BDA50
				if (_HKICMNAACDA_a.PCCFAKEOBIC_EndTime == _BNKHBCBJBKI_b.PCCFAKEOBIC_EndTime)
					return _HKICMNAACDA_a.JHAOHBNPMNA_EventId.CompareTo(_BNKHBCBJBKI_b.JHAOHBNPMNA_EventId);
				return _HKICMNAACDA_a.PCCFAKEOBIC_EndTime.CompareTo(_BNKHBCBJBKI_b.PCCFAKEOBIC_EndTime);
			});
		}
		return res;
	}
}
