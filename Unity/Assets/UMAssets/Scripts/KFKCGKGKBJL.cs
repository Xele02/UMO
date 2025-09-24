
public class KFKCGKGKBJL
{
	private const int FBGGEFFJJHB_xor = 0x2541a98f;
	private const sbyte JFOFMKBJBBE_False = 0x13;
	private const sbyte CNECJGKECHK_True = 0x57;
	public string OPFGFINHFCE_name; // 0x8
	public int OHMGPDPKGLF_ValueCrypted = FBGGEFFJJHB_xor; // 0xC
	public int JNBONMFLGNO_QuantityCrypted = FBGGEFFJJHB_xor; // 0x10
	public string MMOJHIPAAIK_probability; // 0x14
	public int IEAAHHNFLIF_GroupIdxCrypted = FBGGEFFJJHB_xor; // 0x18
	public EKLNMHFCAOI.FKGCBLHOOCL_Category NPPNDDMPFJJ_ItemCategory; // 0x1C
	public int FPKDKMCINLF_ItemIdCrypted = FBGGEFFJJHB_xor; // 0x20
	public string JBLCNEILLMJ_ItemName; // 0x24
	public int JHOMMHBDHHK_EpisodeIdCrypted = FBGGEFFJJHB_xor; // 0x28
	public int HHPFFPINGAA_OrderCrypted = FBGGEFFJJHB_xor; // 0x2C
	public sbyte FHAFHHOKGGL = JFOFMKBJBBE_False; // 0x30
	public sbyte ECDMGKIIKFL = JFOFMKBJBBE_False; // 0x31

	public int NANNGLGOFKH_value { get { return OHMGPDPKGLF_ValueCrypted ^ FBGGEFFJJHB_xor; } set { OHMGPDPKGLF_ValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19FD414 EDFAHCMGHKM 0x19FD428 BKPDFNKGNHA
	public int BPNPBJALGHM_quantity { get { return JNBONMFLGNO_QuantityCrypted ^ FBGGEFFJJHB_xor; } set { JNBONMFLGNO_QuantityCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19FD43C LNIJEHLNADC 0x19FD450 GKIFMMKBGIP
	public int FJNGOPBGEOI_GroupIdx { get { return IEAAHHNFLIF_GroupIdxCrypted ^ FBGGEFFJJHB_xor; } set { IEAAHHNFLIF_GroupIdxCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19FD464 HEODNNKNGJN 0x19FD478 CKBLABDEPPL
	public int JJBGOIMEIPF_ItemId { get { return FPKDKMCINLF_ItemIdCrypted ^ FBGGEFFJJHB_xor; } set { FPKDKMCINLF_ItemIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19FD48C PGMIHJMDLLN 0x19FD4A0 BAFGHJAOBIB
	public int GDEJFKCMNAC_EpisodeId { get { return JHOMMHBDHHK_EpisodeIdCrypted ^ FBGGEFFJJHB_xor; } set { JHOMMHBDHHK_EpisodeIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19FD4B4 AKLFLGKLABO 0x19FD4C8 KGFEHJHIGHC
	public int EILKGEADKGH_Order { get { return HHPFFPINGAA_OrderCrypted ^ FBGGEFFJJHB_xor; } set { HHPFFPINGAA_OrderCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19FD4DC NPDDACIHBKD 0x19FD4F0 BJJMCKHBPNH
	public bool FDIJEBNIBIE_IsFeatured { get { return FHAFHHOKGGL == CNECJGKECHK_True; } set { FHAFHHOKGGL = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x19FD504 GNBOCACPOFA 0x19FD518 CILHBHAOFEI
	public bool JOPPFEHKNFO_Pickup { get { return ECDMGKIIKFL == CNECJGKECHK_True; } set { ECDMGKIIKFL = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x19FD548 FNIOGOJFLMG 0x19FD55C AJIOKKIJBED

	// RVA: 0x19FD58C Offset: 0x19FD58C VA: 0x19FD58C
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
	{
		OPFGFINHFCE_name = (string)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.OPFGFINHFCE_name];
		NANNGLGOFKH_value = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.NANNGLGOFKH_value];
		BPNPBJALGHM_quantity = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.BPNPBJALGHM_quantity];
		MMOJHIPAAIK_probability = (string)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.MMOJHIPAAIK_probability];
		JOPPFEHKNFO_Pickup = false;
		JBLCNEILLMJ_ItemName = "";
		if(OPFGFINHFCE_name == AFEHLCGHAEE_Strings.COIODGJDJEJ_scene)
		{
			NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene;
			JJBGOIMEIPF_ItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene, NANNGLGOFKH_value);
			JBLCNEILLMJ_ItemName = EKLNMHFCAOI.INCKKODFJAP_GetItemName(NPPNDDMPFJJ_ItemCategory, NANNGLGOFKH_value);
			if(NANNGLGOFKH_value < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table.Count - 1)
			{
				GDEJFKCMNAC_EpisodeId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[NANNGLGOFKH_value - 1].KELFCMEOPPM_EpisodeId;
			}
		}
		else if(OPFGFINHFCE_name == AFEHLCGHAEE_Strings.KBMDMEEMGLK_grow_item)
		{
			NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem;
			JJBGOIMEIPF_ItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem, NANNGLGOFKH_value);
			JBLCNEILLMJ_ItemName = EKLNMHFCAOI.INCKKODFJAP_GetItemName(NPPNDDMPFJJ_ItemCategory, NANNGLGOFKH_value);
		}
		FJNGOPBGEOI_GroupIdx = 0;
		if (!_IDLHJIOMJBK_data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.PANKNKOIIJE_group_key))
			return;
		string group = (string)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.PANKNKOIIJE_group_key];
		FJNGOPBGEOI_GroupIdx = BPADANIKFHP.GIFAIIDJPND.FindIndex((string _GHPLINIACBB_x) =>
		{
			//0x19FDC4C
			return _GHPLINIACBB_x == group;
		}) + 1;
	}
}
