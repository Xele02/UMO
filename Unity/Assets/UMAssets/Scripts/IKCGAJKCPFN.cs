
public class IKCGAJKCPFN
{
	public int FBGGEFFJJHB_xor; // 0x8
	public int EOONNJAMAMJ_StatCrypted2; // 0xC
	public int EHOIENNDEDH_IdCrypted; // 0x10
	public int HLMAFFLCCKD_CountCrypted; // 0x14
	public int INNAAKJONMJ_StatCrypted; // 0x18
	public int IMKEAJDJANE_CountCrypted2; // 0x1C
	public int BJMDLOCLCEN_Crypted; // 0x20
	public long BEBJKJKBOGH_date; // 0x28
	public bool CADENLBDAEB_IsNew; // 0x30

	public int PPFNGGCBJKC_id { get { return FBGGEFFJJHB_xor ^ EHOIENNDEDH_IdCrypted; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x8DBB88 DEMEPMAEJOO_get_id 0x8DBB98 HIGKAIDMOKN_set_id
	public int EALOBDHOCHP_stat { get { return FBGGEFFJJHB_xor ^ INNAAKJONMJ_StatCrypted; } set { INNAAKJONMJ_StatCrypted = value ^ FBGGEFFJJHB_xor; EOONNJAMAMJ_StatCrypted2 = INNAAKJONMJ_StatCrypted; } } //0x8DBBA8 KLDFNIEJBFE_bgs 0x8DBBB8 GJLLJFLGMCN_bgs
	public int HMFFHLPNMPH_count { get { return FBGGEFFJJHB_xor ^ HLMAFFLCCKD_CountCrypted; } set { HLMAFFLCCKD_CountCrypted = value ^ FBGGEFFJJHB_xor; IMKEAJDJANE_CountCrypted2 = HLMAFFLCCKD_CountCrypted; } } //0x8DBBCC NJOGDDPICKG_get_count 0x8DBBDC NBBGMMBICNA_set_count
	public int JIOMCDGKIAF { get { return FBGGEFFJJHB_xor ^ BJMDLOCLCEN_Crypted; } set { BJMDLOCLCEN_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x8DBBF0 DJHPCCHENCM_bgs 0x8DBC00 CJEGJOKIJPO_bgs

	//// RVA: 0x8DBC10 Offset: 0x8DBC10 VA: 0x8DBC10
	public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id, int KNEFBLHBDBG)
	{
		BEBJKJKBOGH_date = 0;
		FBGGEFFJJHB_xor = KNEFBLHBDBG;
		EALOBDHOCHP_stat = 0;
		this.PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
		HMFFHLPNMPH_count = 0;
		CADENLBDAEB_IsNew = true;
	}

	//// RVA: 0x8DBC44 Offset: 0x8DBC44 VA: 0x8DBC44
	public bool AGBOGBEOFME(IKCGAJKCPFN OIKJFMGEICL)
	{
		if (CADENLBDAEB_IsNew != OIKJFMGEICL.CADENLBDAEB_IsNew ||
			PPFNGGCBJKC_id != OIKJFMGEICL.PPFNGGCBJKC_id ||
			EALOBDHOCHP_stat != OIKJFMGEICL.EALOBDHOCHP_stat ||
			HMFFHLPNMPH_count != OIKJFMGEICL.HMFFHLPNMPH_count ||
			BEBJKJKBOGH_date != OIKJFMGEICL.BEBJKJKBOGH_date
			)
			return false;
		return true;
	}

	//// RVA: 0x8DBDBC Offset: 0x8DBDBC VA: 0x8DBDBC
	public void ODDIHGPONFL_Copy(IKCGAJKCPFN OIKJFMGEICL)
	{
		PPFNGGCBJKC_id = OIKJFMGEICL.PPFNGGCBJKC_id;
		EALOBDHOCHP_stat = OIKJFMGEICL.EALOBDHOCHP_stat;
		HMFFHLPNMPH_count = OIKJFMGEICL.HMFFHLPNMPH_count;
		BEBJKJKBOGH_date = OIKJFMGEICL.BEBJKJKBOGH_date;
		CADENLBDAEB_IsNew = OIKJFMGEICL.CADENLBDAEB_IsNew;
	}

	//// RVA: 0x8DBEA8 Offset: 0x8DBEA8 VA: 0x8DBEA8
	//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string _JIKKNHIAEKG_BlockName, string MJBACHKCIHA, int _OIPCCBHIKIA_index, IKCGAJKCPFN _OHMCIEMIKCE_t, bool EFOEPDLNLJG) { }

	//// RVA: 0x8DCB60 Offset: 0x8DCB60 VA: 0x8DCB60
	public EDOHBJAPLPF_JsonData NOJCMGAFAAC_ToJsonData()
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data["id"] = PPFNGGCBJKC_id;
		data["stat"] = EALOBDHOCHP_stat;
		data["count"] = HMFFHLPNMPH_count;
		data["date"] = BEBJKJKBOGH_date;
		data[AFEHLCGHAEE_Strings.KLJGEHBKMMG_new] = CADENLBDAEB_IsNew ? 1 : 0;
		return data;
	}
}
