
using System;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Menu;

public class PLFJMDBBAJD
{
	public const int FBGGEFFJJHB_xor = 625060344;
	public string FINCFIGKHPA_Name; // 0x8
	public int JMFKPCFMNKN_Crypted; // 0xC
	public int NFCALENBIBL_LevelCrypted; // 0x10
	public bool AJGFHCKFCHN; // 0x14
	public int BKDNEBPBPKC_Crypted; // 0x18
	public List<PKNOKJNLPOE_EventRaid.KJJDLBFDGDM.EGMFNKCKOLB> PAHGKOAIPFL; // 0x1C
	public List<PKNOKJNLPOE_EventRaid.KJJDLBFDGDM.EGMFNKCKOLB> BLPPOBLGLAJ; // 0x20
	public List<PKNOKJNLPOE_EventRaid.KJJDLBFDGDM.EGMFNKCKOLB> NAJFDCBBCHD; // 0x24

	public string OPFGFINHFCE_name { get { return FINCFIGKHPA_Name; } set { FINCFIGKHPA_Name = value; } } //0xFE9224 DKJOHDGOIJE 0xFE922C MJAMIGECMMF
	public int FJOLNJLLJEJ_rank { get { return JMFKPCFMNKN_Crypted ^ FBGGEFFJJHB_xor; } set { JMFKPCFMNKN_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xFE9234 EAKAGHDPEMI 0xFE9248 GHECCGBGCBI
	public int CIEOBFIIPLD_Level { get { return NFCALENBIBL_LevelCrypted ^ FBGGEFFJJHB_xor; } set { NFCALENBIBL_LevelCrypted = value ^ FBGGEFFJJHB_xor; } } //0xFE925C OGKGFGMKPKB 0xFE9270 JOOMBHHPHBD
	public bool MPKBLMCNHOM_MissionIsSpecial { get { return AJGFHCKFCHN; } set { AJGFHCKFCHN = value; } } //0xFE9284 BOFCPLOLHCJ 0xFE928C FDPPEPOHFNA
	public int HPPDFBKEJCG_BgId { get { return BKDNEBPBPKC_Crypted ^ FBGGEFFJJHB_xor; } set { BKDNEBPBPKC_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xFE9294 BNBDOAMEEJN 0xFE92A8 GIAODJJHAEF
	public List<PKNOKJNLPOE_EventRaid.KJJDLBFDGDM.EGMFNKCKOLB> NEAPOLIIELG_MvpRewards { get { return PAHGKOAIPFL; } set { PAHGKOAIPFL = value; } } //0xFE92BC JBCIDFIBJMB 0xFE92C4 PJGAMCFPENJ
	public List<PKNOKJNLPOE_EventRaid.KJJDLBFDGDM.EGMFNKCKOLB> JAGJOLBDBDK_FirstRewards { get { return BLPPOBLGLAJ; } set { BLPPOBLGLAJ = value; } } //0xFE92CC MEPHLOMFANC 0xFE92D4 OKKIILBBLPM
	public List<PKNOKJNLPOE_EventRaid.KJJDLBFDGDM.EGMFNKCKOLB> FGNHJFLBMIE_DefeatRewards { get { return NAJFDCBBCHD; } set { NAJFDCBBCHD = value; } } //0xFE92DC NPCCNIIELEL 0xFE92E4 AGPAFGCHEBM

	// // RVA: 0xFE92EC Offset: 0xFE92EC VA: 0xFE92EC
	public void KHEKNNFCAOI_Init()
    {
		PKNOKJNLPOE_EventRaid ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
		if(ev != null && ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
		{
            PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ p = ev.JIBMOEHKMGB_SelectedBoss;
            PKNOKJNLPOE_EventRaid.KJJDLBFDGDM p2 = ev.KONJMFICNJJ_RewardsInfo;
            CIEOBFIIPLD_Level = p.ANAJIAENLNB_lv;
            FJOLNJLLJEJ_rank = p.FJOLNJLLJEJ_rank;
            MPKBLMCNHOM_MissionIsSpecial = p.IKICLMGFFPB_IsSpecial;
            HPPDFBKEJCG_BgId = p.HPPDFBKEJCG_BgId;
            OPFGFINHFCE_name = ev.AGEJGHGEGFF_GetBossName(p.INDDJNMPONH_type);
			if(p2 != null)
			{
				NEAPOLIIELG_MvpRewards = p2.NEAPOLIIELG_MvpRewards;
				JAGJOLBDBDK_FirstRewards = p2.JAGJOLBDBDK_FirstRewards;
				FGNHJFLBMIE_DefeatRewards = p2.FGNHJFLBMIE_DefeatRewards;
			}
        }
    }

	// // RVA: 0xFE9520 Offset: 0xFE9520 VA: 0xFE9520
	public void KHEKNNFCAOI_Init(PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ _GJFJLEOGFLD_RaidBoss, Action KBCBGIGOLHP)
	{
		PKNOKJNLPOE_EventRaid ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
		if(ev != null)
		{
			ev.JKBOOMAPOBL(_GJFJLEOGFLD_RaidBoss, () =>
			{
				//0xFE98E4
				CIEOBFIIPLD_Level = _GJFJLEOGFLD_RaidBoss.ANAJIAENLNB_lv;
				FJOLNJLLJEJ_rank = _GJFJLEOGFLD_RaidBoss.FJOLNJLLJEJ_rank;
				MPKBLMCNHOM_MissionIsSpecial = _GJFJLEOGFLD_RaidBoss.IKICLMGFFPB_IsSpecial;
				HPPDFBKEJCG_BgId = _GJFJLEOGFLD_RaidBoss.HPPDFBKEJCG_BgId;
				OPFGFINHFCE_name = ev.AGEJGHGEGFF_GetBossName(_GJFJLEOGFLD_RaidBoss.INDDJNMPONH_type);
				if(ev.KONJMFICNJJ_RewardsInfo != null)
				{
					NEAPOLIIELG_MvpRewards = ev.KONJMFICNJJ_RewardsInfo.NEAPOLIIELG_MvpRewards;
					JAGJOLBDBDK_FirstRewards = ev.KONJMFICNJJ_RewardsInfo.JAGJOLBDBDK_FirstRewards;
					FGNHJFLBMIE_DefeatRewards = ev.KONJMFICNJJ_RewardsInfo.FGNHJFLBMIE_DefeatRewards;
					KBCBGIGOLHP();
				}
			}, () =>
			{
				//0xFE9848
				MenuScene.Instance.GotoTitle();
			});
			return;
		}
	}
}
