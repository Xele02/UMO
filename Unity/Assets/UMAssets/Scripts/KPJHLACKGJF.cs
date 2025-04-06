
using System.Collections;
using System.Collections.Generic;

[System.Obsolete("Use KPJHLACKGJF_EventMission", true)]
public class KPJHLACKGJF { }
public class KPJHLACKGJF_EventMission : IKDICBBFBMI_EventBase
{
	// private const int GHJHJDIDCFA = 3;
	// private EECOJKDJIFG KBACNOCOANM; // 0xE8
	// private bool GAKPAELDIKN; // 0xF0
	// public bool EGOJLOEFMOH; // 0xF1
	// public int BCBCODAKIDN; // 0xF4
	// public bool EEIKDIHGJAD; // 0xF8
	// public int CGEAAEPEFIE; // 0xFC
	// public bool KDDBNAIJKAD; // 0x100
	// public bool KIBBLLADDPO; // 0x108
	// private List<KPJHLACKGJF.HLMINENBCKO> OEFLDPCOCNP = new List<KPJHLACKGJF.HLMINENBCKO>(); // 0x10C

	public override OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType { get { return OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest; } } //0x1133158 DKHCGLCNKCD  Slot: 4
	// public KPJHLACKGJF.OPFEKMKHEIF FHPEAPEANAI { get; set; } // 0xEC NENKPIMLLHN BFAPJDBFKEP BBDBKNDKIJL
	// public int JKCBFOAHNGL { get; private set; } // 0x104 FEHKFPEICBM MPNIHHELFBI CNLLLLAALIL
	// public List<KPJHLACKGJF.HLMINENBCKO> AFOIGLCEBAE { get; } 0x1133180 FFPIOJEFCCL

	// // RVA: 0x1133188 Offset: 0x1133188 VA: 0x1133188 Slot: 32
	public override EECOJKDJIFG DAKMIKNKHMF_GetRankingInfoForIndex(int LHJCOPMMIGO = 0)
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "DAKMIKNKHMF");
		return null;
	}

	// RVA: 0x1133190 Offset: 0x1133190 VA: 0x1133190
	public KPJHLACKGJF_EventMission(string OPFGFINHFCE) : base(OPFGFINHFCE)
    {
        return;
    }

	// // RVA: 0x1133250 Offset: 0x1133250 VA: 0x1133250 Slot: 5
	public override string IFKKBHPMALH()
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "IFKKBHPMALH");
		return null;
	}

	// // RVA: 0x11333D8 Offset: 0x11333D8 VA: 0x11333D8 Slot: 7
	public override List<int> HEACCHAKMFG_GetMusicsList()
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "HEACCHAKMFG");
		return base.HEACCHAKMFG_GetMusicsList();
	}

	// // RVA: 0x1133760 Offset: 0x1133760 VA: 0x1133760 Slot: 9
	public override long HOOBCIIOCJD_GetSongEndTime(int GHBPLHBNMBK)
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "HOOBCIIOCJD");
		return 0;
	}

	// // RVA: 0x1133C24 Offset: 0x1133C24 VA: 0x1133C24 Slot: 10
	public override bool GIDDKGMPIOK_IsLimited(int GHBPLHBNMBK)
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "GIDDKGMPIOK");
		return false;
	}

	// // RVA: 0x11340F0 Offset: 0x11340F0 VA: 0x11340F0 Slot: 8
	public override int OMJHBJPCFFC_GetEventBonusPercent(int EHDDADDKMFI)
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "OMJHBJPCFFC");
		return 0;
	}

	// // RVA: 0x11346A0 Offset: 0x11346A0 VA: 0x11346A0 Slot: 27
	public override int HLOGNJNGDJO_GetHelpId(int OIPCCBHIKIA = 0)
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "HLOGNJNGDJO");
		return 0;
	}

	// // RVA: 0x113485C Offset: 0x113485C VA: 0x113485C Slot: 67
	// public override int LBNKDKDMMOK() { }

	// // RVA: 0x11349E0 Offset: 0x11349E0 VA: 0x11349E0 Slot: 28
	public override long FBGDBGKNKOD_GetCurrentPoint()
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "FBGDBGKNKOD");
		return 0;
	}

	// // RVA: 0x1134C40 Offset: 0x1134C40 VA: 0x1134C40 Slot: 29
	public override void MJFKJHJJLMN_GetRanks(int LHJCOPMMIGO = 0, bool FBBNPFFEJBN = false)
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "MJFKJHJJLMN");
	}

	// // RVA: 0x1135118 Offset: 0x1135118 VA: 0x1135118 Slot: 30
	protected override bool JIHMLILFOPG_IsEventActive(long JHNMKKNEENE)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId);
		if(db != null)
		{
			TodoLogger.LogError(TodoLogger.EventMission_6, "KPJHLACKGJF_EventMission.JIHMLILFOPG");
		}
		return false;
	}

	// // RVA: 0x1135434 Offset: 0x1135434 VA: 0x1135434 Slot: 31
	protected override bool IMCMNOPNGHO(long JHNMKKNEENE)
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "KPJHLACKGJF_EventMission.IMCMNOPNGHO");
		return false;
	}

	// // RVA: 0x1135790 Offset: 0x1135790 VA: 0x1135790 Slot: 40
	protected override void KKFLDCBHFJA(long JHNMKKNEENE)
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "KKFLDCBHFJA");
	}

	// // RVA: 0x1136474 Offset: 0x1136474 VA: 0x1136474 Slot: 43
	protected override void FCHGHAAPIBH()
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "FCHGHAAPIBH");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BCD6C Offset: 0x6BCD6C VA: 0x6BCD6C
	// // RVA: 0x1136B28 Offset: 0x1136B28 VA: 0x1136B28 Slot: 44
	protected override IEnumerator JEIJKLPOAHP_ReceivePrologueRepeatedAchievement(DJBHIFLHJLK AOCANKOMKFG)
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "JEIJKLPOAHP_ReceivePrologueRepeatedAchievement");
		yield break;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BCDE4 Offset: 0x6BCDE4 VA: 0x6BCDE4
	// // RVA: 0x1136BCC Offset: 0x1136BCC VA: 0x1136BCC Slot: 45
	protected override IEnumerator KPBNMAEHHDF_ReceiveEpilogueRepeatedAchivement(DJBHIFLHJLK AOCANKOMKFG)
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "JEIJKLPOAHP_ReceivePrologueRepeatedAchievement");
		yield break;
	}

	// // RVA: 0x1136C70 Offset: 0x1136C70 VA: 0x1136C70
	// private bool GGJCIDOCOOM(long JHNMKKNEENE, int OHAFIGFCBMK, out int EAKEMMMBBKN) { }

	// // RVA: 0x1137D20 Offset: 0x1137D20 VA: 0x1137D20 Slot: 46
	protected override void PJDGDNJNCNM_UpdateStatusImpl(long JHNMKKNEENE)
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "PJDGDNJNCNM");
	}

	// // RVA: 0x1138374 Offset: 0x1138374 VA: 0x1138374 Slot: 47
	public override void NBMDAOFPKGK(int DNBFMLBNAEE)
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "NBMDAOFPKGK");
	}

	// // RVA: 0x11386C4 Offset: 0x11386C4 VA: 0x11386C4 Slot: 48
	public override void AMKJFGLEJGE(int KPIILHGOGJD)
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "AMKJFGLEJGE");
	}

	// // RVA: 0x11386C8 Offset: 0x11386C8 VA: 0x11386C8 Slot: 49
	// protected override void ODPJGHOJIOH(int LHJCOPMMIGO) { }

	// // RVA: 0x1138BE8 Offset: 0x1138BE8 VA: 0x1138BE8 Slot: 50
	protected override void MFJFBNPLFBE_OnReceieveTotalReward(bool GIPBIDFJFLL)
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "MFJFBNPLFBE");
	}

	// // RVA: 0x1139B70 Offset: 0x1139B70 VA: 0x1139B70 Slot: 52
	public override void FAMFKPBPIAA_GetRankingPlayerList(bool PFFJNEFNAMI, int CJHEHIMLGGL, int LHJCOPMMIGO, LIOLBKLMMIK KLMFJJCNBIP, DJBHIFLHJLK IDAEHNGOKAE, DJBHIFLHJLK JGKOLBLPMPG)
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "FAMFKPBPIAA");
	}

	// // RVA: 0x1139EA0 Offset: 0x1139EA0 VA: 0x1139EA0 Slot: 53
	public override void JPNACOLKHLB_AddRankingPlayerListSecond(int CJHEHIMLGGL, int NEFEFHBHFFF, LIOLBKLMMIK KLMFJJCNBIP, DJBHIFLHJLK IDAEHNGOKAE, DJBHIFLHJLK JGKOLBLPMPG)
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "JPNACOLKHLB");
	}

	// // RVA: 0x113A09C Offset: 0x113A09C VA: 0x113A09C
	// private int APJDIPINLLK(List<int> HNLFPKNBOHE, int PPFNGGCBJKC) { }

	// // RVA: 0x1136AD8 Offset: 0x1136AD8 VA: 0x1136AD8
	// private void PIMFJALCIGK() { }

	// // RVA: 0x113A194 Offset: 0x113A194 VA: 0x113A194
	// private void BJEOAOACMGG(int LHJCOPMMIGO) { }

	// // RVA: 0x1139844 Offset: 0x1139844 VA: 0x1139844
	// private void DENHAAGACPD() { }

	// // RVA: 0x113A9F0 Offset: 0x113A9F0 VA: 0x113A9F0 Slot: 51
	public override IHAEIOAKEMG ILICNKILFKJ_GetNextReward()
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "ILICNKILFKJ");
		return null;
	}

	// // RVA: 0x113AB04 Offset: 0x113AB04 VA: 0x113AB04 Slot: 58
	protected override void LMGMELPOGMH(int LHJCOPMMIGO)
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "LMGMELPOGMH");
	}

	// // RVA: 0x113AE94 Offset: 0x113AE94 VA: 0x113AE94 Slot: 59
	public override List<int> AEGDKBNNDBC_GetDrops()
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "AEGDKBNNDBC");
		return null;
	}

	// // RVA: 0x113B018 Offset: 0x113B018 VA: 0x113B018
	// public DJDJHGJHAJA.IOPLHHNPLGM KCHMKLPHOEB() { }

	// // RVA: 0x113B274 Offset: 0x113B274 VA: 0x113B274
	// public void PNKKJJFBBIH(DJDJHGJHAJA.IOPLHHNPLGM LGADCGFMLLD) { }

	// // RVA: 0x113B4D4 Offset: 0x113B4D4 VA: 0x113B4D4 Slot: 65
	protected override bool JLPDECMHLIM_CanShowStartAdventureInternal()
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "JLPDECMHLIM");
		return false;
	}

	// // RVA: 0x113B810 Offset: 0x113B810 VA: 0x113B810 Slot: 66
	public override void FGDDBFHGCGP_SetStartAdventureShown(bool JKDJCFEBDHC, long JHNMKKNEENE = 0)
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "FGDDBFHGCGP");
	}

	// // RVA: 0x113BA90 Offset: 0x113BA90 VA: 0x113BA90 Slot: 70
	public override void ADACMHAHHKC_PreSetupEventHome(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "ADACMHAHHKC");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BCE5C Offset: 0x6BCE5C VA: 0x6BCE5C
	// // RVA: 0x113BAE8 Offset: 0x113BAE8 VA: 0x113BAE8
	// private IEnumerator NJIEIJJMAHK(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x113BBA0 Offset: 0x113BBA0 VA: 0x113BBA0
	// public bool EGKODECGHNM() { }

	// // RVA: 0x113BBA8 Offset: 0x113BBA8 VA: 0x113BBA8 Slot: 33
	public override bool MPMKJNJGFEF_IsEntry()
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "MPMKJNJGFEF");
		return false;
	}

	// // RVA: 0x113BE08 Offset: 0x113BE08 VA: 0x113BE08 Slot: 69
	// public override void HAAEJDGMICH(LBNLAENLPNK.JEKODBEDOMM INDDJNMPONH, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x113BF30 Offset: 0x113BF30 VA: 0x113BF30 Slot: 71
	public override int BAEPGOAMBDK(string LJNAKDMILMC, int MNCOAGOKNAO)
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "BAEPGOAMBDK");
		return 0;
	}

	// // RVA: 0x113C0B0 Offset: 0x113C0B0 VA: 0x113C0B0 Slot: 72
	public override string MAICAKMIBEM(string LJNAKDMILMC, string MNCOAGOKNAO)
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "MAICAKMIBEM");
		return MNCOAGOKNAO;
	}

	// // RVA: 0x113C230 Offset: 0x113C230 VA: 0x113C230 Slot: 68
	public override bool GJMGKBDGMOP(long LPEKHFOMCAH)
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "GJMGKBDGMOP");
		return false;
	}

	// // RVA: 0x113CA18 Offset: 0x113CA18 VA: 0x113CA18 Slot: 75
	public override string FEKEBPKINIM_GetSessionId()
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "FEKEBPKINIM");
		return "";
	}

	// // RVA: 0x113CC84 Offset: 0x113CC84 VA: 0x113CC84 Slot: 73
	public override List<string> IJCPBPFEGDM_GetResourcesFilePathList(long JHNMKKNEENE)
	{
		DIHHCBACKGG_DbSection dbSection = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId);
		if(dbSection == null)
			return null;
		TodoLogger.LogError(TodoLogger.EventMission_6, "KPJHLACKGJF_EventMission.IJCPBPFEGDM");
		return null;
	}

	// // RVA: 0x113CF98 Offset: 0x113CF98 VA: 0x113CF98 Slot: 74
	public override int EDNMFMBLCGF_GetWavId()
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "EDNMFMBLCGF");
		return 0;
	}

	// // RVA: 0x113D250 Offset: 0x113D250 VA: 0x113D250 Slot: 38
	public override void EMEPJNLHJHJ(int GJEADBKFAPA, int AKNELONELJK, bool GIKLNODJKFK, ref int APMGOLOPLFP, ref int FBBDNLAMPMH)
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "EMEPJNLHJHJ");
	}

	// // RVA: 0x113D364 Offset: 0x113D364 VA: 0x113D364
	// public OFNLIBDEIFA.HGCEGAAJFBC JIPPHOKGLIH(int GOIKCKHMBDL, bool HOENAFAJMGI = False) { }

	// // RVA: 0x113D36C Offset: 0x113D36C VA: 0x113D36C
	// public void DCNEHOMHOJL(int GHBPLHBNMBK) { }

	// // RVA: 0x113D618 Offset: 0x113D618 VA: 0x113D618
	// public int IGBPFGPPJOE() { }

	// // RVA: 0x113D86C Offset: 0x113D86C VA: 0x113D86C
	// public ACBAHDMEFFL.BIMNGKEMMJM MLLAMHMJFLP() { }

	// // RVA: 0x113DAF8 Offset: 0x113DAF8 VA: 0x113DAF8
	// public ACBAHDMEFFL.BFHPHDAPEKA KMOALEJMJKA(int JOMGCCBFKEF) { }

	// // RVA: 0x113DC9C Offset: 0x113DC9C VA: 0x113DC9C
	// public ACBAHDMEFFL.ONECEEIOJCP LOLJPCKNLGI(int BCMBMAILDMP) { }

	// // RVA: 0x113DE40 Offset: 0x113DE40 VA: 0x113DE40
	// public ACBAHDMEFFL.BFHPHDAPEKA MELOGDCGMLG() { }

	// // RVA: 0x113E13C Offset: 0x113E13C VA: 0x113E13C
	// public int LLCOKGMCNAF() { }

	// // RVA: 0x113E1CC Offset: 0x113E1CC VA: 0x113E1CC
	// private void JHLIABLHIDK(int ANMCFINOHFH) { }

	// // RVA: 0x113E4D8 Offset: 0x113E4D8 VA: 0x113E4D8
	// public void ACJFIFPCJDP() { }

	// // RVA: 0x113F1C4 Offset: 0x113F1C4 VA: 0x113F1C4
	// public void BMNPDFHNLOM(bool JKDJCFEBDHC) { }

	// // RVA: 0x113F414 Offset: 0x113F414 VA: 0x113F414
	// public bool MLNOLKKHBDC() { }

	// // RVA: 0x113F674 Offset: 0x113F674 VA: 0x113F674
	// public void NAJMELNNCAN(int HHJIECNECNA) { }

	// // RVA: 0x113DEE0 Offset: 0x113DEE0 VA: 0x113DEE0
	// public int BHNEJEDEHJA() { }

	// // RVA: 0x113F92C Offset: 0x113F92C VA: 0x113F92C
	// private void LNIMCKNKFHL() { }

	// // RVA: 0x113FDE8 Offset: 0x113FDE8 VA: 0x113FDE8
	// public int CFJAHCCFIGD(int DNBFMLBNAEE) { }

	// // RVA: 0x1140028 Offset: 0x1140028 VA: 0x1140028
	// public int NEBKOHHKGBA() { }

	// // RVA: 0x11401AC Offset: 0x11401AC VA: 0x11401AC
	// public int KFGOHDKANAC() { }

	// // RVA: 0x1140348 Offset: 0x1140348 VA: 0x1140348
	// public void FCLGOCBGPJF(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, int ACMMDAHKCIF, int FCLGIPFPIPH, int LCCGDFGGIHI, int ANOPDAGJIKG, int MHADLGMJKGK, bool IKGLAFOHGDO) { }

	// // RVA: 0x1140388 Offset: 0x1140388 VA: 0x1140388
	// private void EBNMMCKCPKN(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, int ACMMDAHKCIF, int FCLGIPFPIPH, int LCCGDFGGIHI, int ANOPDAGJIKG, int MHADLGMJKGK, bool IKGLAFOHGDO) { }

	// // RVA: 0x113EBC4 Offset: 0x113EBC4 VA: 0x113EBC4
	// private int IIGKKMMJONJ() { }

	// // RVA: 0x113E7F4 Offset: 0x113E7F4 VA: 0x113E7F4
	// public int JKPDCKDMKBN() { }

	// // RVA: 0x1140EAC Offset: 0x1140EAC VA: 0x1140EAC Slot: 76
	public override void MMIMJPNLKBK()
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "MMIMJPNLKBK");
	}

	// // RVA: 0x1141128 Offset: 0x1141128 VA: 0x1141128
	// public int NCDLFEHONME() { }

	// // RVA: 0x114119C Offset: 0x114119C VA: 0x114119C
	// public CHHECNJBMLA FPCNGEEEDFM() { }

	// // RVA: 0x11412F4 Offset: 0x11412F4 VA: 0x11412F4 Slot: 77
	public override string DBEMCLMPCFA_GetBannerText()
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "DBEMCLMPCFA");
		return "";
	}

	// // RVA: 0x1141670 Offset: 0x1141670 VA: 0x1141670 Slot: 78
	public override long OEGAJJANHGL()
	{
		TodoLogger.LogError(TodoLogger.EventMission_6, "OEGAJJANHGL");
		return 0;
	}

	// [CompilerGeneratedAttribute] // RVA: 0x6BCED4 Offset: 0x6BCED4 VA: 0x6BCED4
	// // RVA: 0x11417FC Offset: 0x11417FC VA: 0x11417FC
	// private void <OnReceieveTotalReward>b__47_0(CACGCMBKHDI NHECPMNKEFK) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6BCEE4 Offset: 0x6BCEE4 VA: 0x6BCEE4
	// // RVA: 0x1141808 Offset: 0x1141808 VA: 0x1141808
	// private void <OnReceieveTotalReward>b__47_1(CACGCMBKHDI NHECPMNKEFK) { }
}
