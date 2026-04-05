
public class GJMCHHCPFDL
{
	private const int FBGGEFFJJHB_xor = 625060344;
	private int ABGBHLCLBIF_PointCrypted; // 0x8
	private float NHENJCIOGJH; // 0xC
	private float MAEHJAJNAAF; // 0x10
	private int EEMKIGAAIHO_Crypted; // 0x14
	private int ABOINDIGKAM_MaxHpCrypted; // 0x18
	private int LLJGFFDPGAI_Crypted; // 0x1C
	private int HJOJJCKDPPJ_Crypted; // 0x20
	private int KBLGJMJLJBD_Crypted; // 0x24
	private int JMFKPCFMNKN_Crypted; // 0x28
	private string FINCFIGKHPA_Name; // 0x2C
	private bool AJGFHCKFCHN_Crypted; // 0x30
	private int BKDNEBPBPKC_Crypted; // 0x34

	public int ENMEKLHFMDE_Point { get { return ABGBHLCLBIF_PointCrypted ^ FBGGEFFJJHB_xor; } set { ABGBHLCLBIF_PointCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAAD5B8 AKDPDBKFIKA_bgs 0xAAD5CC BAGMEHBIGCN_bgs
	public float LBEIIEKJFPA_DamageBefore { get { return NHENJCIOGJH; } set { NHENJCIOGJH = value; } } //0xAAD5E0 MPMBHFANDBK_bgs 0xAAD5E8 PIBKAIAPIFL_bgs
	public float ODFNMNDFEFN_DamageAfter { get { return MAEHJAJNAAF; } set { MAEHJAJNAAF = value; } } //0xAAD5F0 JLJLAALNNOB_bgs 0xAAD5F8 GIODHLCCPPB_bgs
	public int GKHMIECGPJO_HpAfter { get { return EEMKIGAAIHO_Crypted ^ FBGGEFFJJHB_xor; } set { EEMKIGAAIHO_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAD600 IMIGBKMPMHC_bgs 0xAAD614 AIHANPGIGHA_bgs
	public int BDNGBCKEADA_MaxHp { get { return ABOINDIGKAM_MaxHpCrypted ^ FBGGEFFJJHB_xor; } set { ABOINDIGKAM_MaxHpCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAAD628 KBGAOONODLJ_bgs 0xAAD63C CFCHCNAICOO_bgs
	public int FCIBJNKGMOB_Damage { get { return LLJGFFDPGAI_Crypted ^ FBGGEFFJJHB_xor; } set { LLJGFFDPGAI_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAD650 IGPNLOPKDLO_bgs 0xAAD664 NBMNDKHMNHD_bgs
	public int AHOKAPCGJMA_TotalPoint { get { return HJOJJCKDPPJ_Crypted ^ FBGGEFFJJHB_xor; } set { HJOJJCKDPPJ_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAD678 GKLPFHEELGM_bgs 0xAAD68C EJPEPBGDDJM_bgs
	public int LGFFMGDBIAH_ranking { get { return KBLGJMJLJBD_Crypted ^ FBGGEFFJJHB_xor; } set { KBLGJMJLJBD_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAD6A0 AFEPCFJGPKA_bgs 0xAAD6B4 LJLAKALHFNN_bgs
	public int FJOLNJLLJEJ_rank { get { return JMFKPCFMNKN_Crypted ^ FBGGEFFJJHB_xor; } set { JMFKPCFMNKN_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAD6C8 EAKAGHDPEMI_get_rank 0xAAD6DC GHECCGBGCBI_set_rank
	public string OPFGFINHFCE_name { get { return FINCFIGKHPA_Name; } set { FINCFIGKHPA_Name = value; } } //0xAAD6F0 DKJOHDGOIJE_get_name 0xAAD6F8 MJAMIGECMMF_set_name
	public bool MPKBLMCNHOM_MissionIsSpecial { get { return AJGFHCKFCHN_Crypted; } set { AJGFHCKFCHN_Crypted = value; } } //0xAAD700 BOFCPLOLHCJ_bgs 0xAAD708 FDPPEPOHFNA_bgs
	public int HPPDFBKEJCG_BgId { get { return BKDNEBPBPKC_Crypted ^ FBGGEFFJJHB_xor; } set { BKDNEBPBPKC_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAD710 BNBDOAMEEJN_bgs 0xAAD724 GIAODJJHAEF_bgs

	// // RVA: 0xAAD738 Offset: 0xAAD738 VA: 0xAAD738
	public void KHEKNNFCAOI_Init(bool DLKLEFMHJBN/* = False*/)
	{
		PKNOKJNLPOE_NetEventRaidController ev = JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_11_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_NetEventRaidController;
		if(ev != null && ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_11_EventRaid)
		{
            PKNOKJNLPOE_NetEventRaidController.OCBPJEALCPO p = ev.PLFBKEPLAAA;
            if (DLKLEFMHJBN)
			{
				ENMEKLHFMDE_Point = ev.GGDBEANLCPC.HALIDDHLNEG_Damage;
			}
			else
			{
				ENMEKLHFMDE_Point = p.HALIDDHLNEG_Damage;
			}
			AHOKAPCGJMA_TotalPoint = p.AEIMNLACMFA_Damage;
			LGFFMGDBIAH_ranking = p.HMNOKOEJDND_Rank;
			GKHMIECGPJO_HpAfter = p.GKHMIECGPJO_HpAfter;
			BDNGBCKEADA_MaxHp = p.OGHIOGDPFJE_MaxHp;
			FCIBJNKGMOB_Damage = p.FCIBJNKGMOB_Damage;
			LBEIIEKJFPA_DamageBefore = FCIBJNKGMOB_Damage * 100.0f / BDNGBCKEADA_MaxHp;
			ODFNMNDFEFN_DamageAfter = GKHMIECGPJO_HpAfter * 100.0f / BDNGBCKEADA_MaxHp;
			FJOLNJLLJEJ_rank = ev.JIBMOEHKMGB_SelectedBoss.FJOLNJLLJEJ_rank;
			MPKBLMCNHOM_MissionIsSpecial = ev.JIBMOEHKMGB_SelectedBoss.IKICLMGFFPB_IsSpecial;
			HPPDFBKEJCG_BgId = ev.JIBMOEHKMGB_SelectedBoss.HPPDFBKEJCG_BgId;
			OPFGFINHFCE_name = ev.AGEJGHGEGFF_GetBossName(ev.JIBMOEHKMGB_SelectedBoss.INDDJNMPONH_type);
		}
	}
}
