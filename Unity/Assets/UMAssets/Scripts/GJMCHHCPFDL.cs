
public class GJMCHHCPFDL
{
	private const int FBGGEFFJJHB = 625060344;
	private int ABGBHLCLBIF_Crypted; // 0x8
	private float NHENJCIOGJH; // 0xC
	private float MAEHJAJNAAF; // 0x10
	private int EEMKIGAAIHO_Crypted; // 0x14
	private int ABOINDIGKAM_Crypted; // 0x18
	private int LLJGFFDPGAI_Crypted; // 0x1C
	private int HJOJJCKDPPJ_Crypted; // 0x20
	private int KBLGJMJLJBD_Crypted; // 0x24
	private int JMFKPCFMNKN_Crypted; // 0x28
	private string FINCFIGKHPA; // 0x2C
	private bool AJGFHCKFCHN; // 0x30
	private int BKDNEBPBPKC_Crypted; // 0x34

	public int ENMEKLHFMDE_Point { get { return ABGBHLCLBIF_Crypted ^ FBGGEFFJJHB; } set { ABGBHLCLBIF_Crypted = value ^ FBGGEFFJJHB; } } //0xAAD5B8 AKDPDBKFIKA 0xAAD5CC BAGMEHBIGCN
	public float LBEIIEKJFPA_DamageBefore { get { return NHENJCIOGJH; } set { NHENJCIOGJH = value; } } //0xAAD5E0 MPMBHFANDBK 0xAAD5E8 PIBKAIAPIFL
	public float ODFNMNDFEFN_DamageAfter { get { return MAEHJAJNAAF; } set { MAEHJAJNAAF = value; } } //0xAAD5F0 JLJLAALNNOB 0xAAD5F8 GIODHLCCPPB
	public int GKHMIECGPJO_HpAfter { get { return EEMKIGAAIHO_Crypted ^ FBGGEFFJJHB; } set { EEMKIGAAIHO_Crypted = value ^ FBGGEFFJJHB; } } //0xAAD600 IMIGBKMPMHC 0xAAD614 AIHANPGIGHA
	public int BDNGBCKEADA_MaxHp { get { return ABOINDIGKAM_Crypted ^ FBGGEFFJJHB; } set { ABOINDIGKAM_Crypted = value ^ FBGGEFFJJHB; } } //0xAAD628 KBGAOONODLJ 0xAAD63C CFCHCNAICOO
	public int FCIBJNKGMOB_Damage { get { return LLJGFFDPGAI_Crypted ^ FBGGEFFJJHB; } set { LLJGFFDPGAI_Crypted = value ^ FBGGEFFJJHB; } } //0xAAD650 IGPNLOPKDLO 0xAAD664 NBMNDKHMNHD
	public int AHOKAPCGJMA { get { return HJOJJCKDPPJ_Crypted ^ FBGGEFFJJHB; } set { HJOJJCKDPPJ_Crypted = value ^ FBGGEFFJJHB; } } //0xAAD678 GKLPFHEELGM 0xAAD68C EJPEPBGDDJM
	public int LGFFMGDBIAH { get { return KBLGJMJLJBD_Crypted ^ FBGGEFFJJHB; } set { KBLGJMJLJBD_Crypted = value ^ FBGGEFFJJHB; } } //0xAAD6A0 AFEPCFJGPKA 0xAAD6B4 LJLAKALHFNN
	public int FJOLNJLLJEJ_Rank { get { return JMFKPCFMNKN_Crypted ^ FBGGEFFJJHB; } set { JMFKPCFMNKN_Crypted = value ^ FBGGEFFJJHB; } } //0xAAD6C8 EAKAGHDPEMI 0xAAD6DC GHECCGBGCBI
	public string OPFGFINHFCE_Name { get { return FINCFIGKHPA; } set { FINCFIGKHPA = value; } } //0xAAD6F0 DKJOHDGOIJE 0xAAD6F8 MJAMIGECMMF
	public bool MPKBLMCNHOM_MissionIsSpecial { get { return AJGFHCKFCHN; } set { AJGFHCKFCHN = value; } } //0xAAD700 BOFCPLOLHCJ 0xAAD708 FDPPEPOHFNA
	public int HPPDFBKEJCG_BgId { get { return BKDNEBPBPKC_Crypted ^ FBGGEFFJJHB; } set { BKDNEBPBPKC_Crypted = value ^ FBGGEFFJJHB; } } //0xAAD710 BNBDOAMEEJN 0xAAD724 GIAODJJHAEF

	// // RVA: 0xAAD738 Offset: 0xAAD738 VA: 0xAAD738
	public void KHEKNNFCAOI(bool DLKLEFMHJBN/* = False*/)
	{
		PKNOKJNLPOE_EventRaid ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
		if(ev != null && ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
		{
            PKNOKJNLPOE_EventRaid.OCBPJEALCPO p = ev.PLFBKEPLAAA;
            if (DLKLEFMHJBN)
			{
				ENMEKLHFMDE_Point = ev.GGDBEANLCPC.HALIDDHLNEG_MCannonDamage;
			}
			else
			{
				ENMEKLHFMDE_Point = p.HALIDDHLNEG_GetPoint;
			}
			AHOKAPCGJMA = p.AEIMNLACMFA_PlayerDamage;
			LGFFMGDBIAH = p.HMNOKOEJDND_Rank;
			GKHMIECGPJO_HpAfter = p.GKHMIECGPJO_HpAfter;
			BDNGBCKEADA_MaxHp = p.OGHIOGDPFJE_MaxHp;
			FCIBJNKGMOB_Damage = p.FCIBJNKGMOB_Damage;
			LBEIIEKJFPA_DamageBefore = FCIBJNKGMOB_Damage * 100.0f / BDNGBCKEADA_MaxHp;
			ODFNMNDFEFN_DamageAfter = GKHMIECGPJO_HpAfter * 100.0f / BDNGBCKEADA_MaxHp;
			FJOLNJLLJEJ_Rank = ev.JIBMOEHKMGB_SelectedBoss.FJOLNJLLJEJ_Rank;
			MPKBLMCNHOM_MissionIsSpecial = ev.JIBMOEHKMGB_SelectedBoss.IKICLMGFFPB_IsSpecial;
			HPPDFBKEJCG_BgId = ev.JIBMOEHKMGB_SelectedBoss.HPPDFBKEJCG_BgId;
			OPFGFINHFCE_Name = ev.AGEJGHGEGFF_GetBossName(ev.JIBMOEHKMGB_SelectedBoss.INDDJNMPONH_Type);
		}
	}
}
