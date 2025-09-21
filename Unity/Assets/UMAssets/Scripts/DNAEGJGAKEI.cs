
[System.Obsolete("Use DNAEGJGAKEI_DropItemInfo", true)]
public class DNAEGJGAKEI { }
public class DNAEGJGAKEI_DropItemInfo
{
	public static int FBGGEFFJJHB_xor = 0x7c8955f7; // 0x0
	private int BBHFIIKMFJE_IdxCrypted; // 0x8
	private int PIMKKONMBOG_ItemIdCrypted; // 0xC
	private int DBCAOAIFOCJ_Crypted; // 0x10
	private int KOGKHJMIFNP_Crypted; // 0x14

	public int OIPCCBHIKIA_index { get { return BBHFIIKMFJE_IdxCrypted ^ FBGGEFFJJHB_xor; } set { BBHFIIKMFJE_IdxCrypted = value ^ FBGGEFFJJHB_xor; } } //0x122D6FC HFCGOHDOHAP 0x122D794 FOGFPKNLADC
	public int KIJAPOFAGPN_ItemId { get { return PIMKKONMBOG_ItemIdCrypted ^ FBGGEFFJJHB_xor; } set { PIMKKONMBOG_ItemIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x122D830 GCKKKIDNACI 0x122D8C8 OGBLMPODGBG
	public int MKNDAOHGOAK_weight { get { return DBCAOAIFOCJ_Crypted ^ FBGGEFFJJHB_xor; } set { DBCAOAIFOCJ_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x122D964 MGMCJMODMAN 0x122D9FC LOBLFMFJDEC
	public int OBKKLILJJFP_Max { get { return KOGKHJMIFNP_Crypted ^ FBGGEFFJJHB_xor; } set { KOGKHJMIFNP_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x122DA98 ICNPIKLAMDP 0x122DB30 GPEKLMGGJLB

	// RVA: 0x122DBCC Offset: 0x122DBCC VA: 0x122DBCC
	public DNAEGJGAKEI_DropItemInfo()
	{
		OIPCCBHIKIA_index = 0;
		KIJAPOFAGPN_ItemId = 0;
		MKNDAOHGOAK_weight = 0;
		OBKKLILJJFP_Max = 0;
	}
}
