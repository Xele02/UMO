
public class KFKCGKGKBJL
{
	private const int FBGGEFFJJHB = 0x2541a98f;
	private const sbyte JFOFMKBJBBE_False = 0x13;
	private const sbyte CNECJGKECHK_True = 0x57;
	public string OPFGFINHFCE_Name; // 0x8
	public int OHMGPDPKGLF_ValueCrypted = FBGGEFFJJHB; // 0xC
	public int JNBONMFLGNO_QuantityCrypted = FBGGEFFJJHB; // 0x10
	public string MMOJHIPAAIK_Probability; // 0x14
	public int IEAAHHNFLIF_GroupIdxCrypted = FBGGEFFJJHB; // 0x18
	public EKLNMHFCAOI.FKGCBLHOOCL_Category NPPNDDMPFJJ_ItemCat; // 0x1C
	public int FPKDKMCINLF_ItemIdCrypted = FBGGEFFJJHB; // 0x20
	public string JBLCNEILLMJ_ItemName; // 0x24
	public int JHOMMHBDHHK_EpisodeIdCrypted = FBGGEFFJJHB; // 0x28
	public int HHPFFPINGAA_IdxCrypted = FBGGEFFJJHB; // 0x2C
	public sbyte FHAFHHOKGGL = JFOFMKBJBBE_False; // 0x30
	public sbyte ECDMGKIIKFL = JFOFMKBJBBE_False; // 0x31

	public int NANNGLGOFKH_Value { get { return OHMGPDPKGLF_ValueCrypted ^ FBGGEFFJJHB; } set { OHMGPDPKGLF_ValueCrypted = value ^ FBGGEFFJJHB; } } //0x19FD414 EDFAHCMGHKM 0x19FD428 BKPDFNKGNHA
	public int BPNPBJALGHM_Quantity { get { return JNBONMFLGNO_QuantityCrypted ^ FBGGEFFJJHB; } set { JNBONMFLGNO_QuantityCrypted = value ^ FBGGEFFJJHB; } } //0x19FD43C LNIJEHLNADC 0x19FD450 GKIFMMKBGIP
	public int FJNGOPBGEOI_GroupIdx { get { return IEAAHHNFLIF_GroupIdxCrypted ^ FBGGEFFJJHB; } set { IEAAHHNFLIF_GroupIdxCrypted = value ^ FBGGEFFJJHB; } } //0x19FD464 HEODNNKNGJN 0x19FD478 CKBLABDEPPL
	public int JJBGOIMEIPF_ItemId { get { return FPKDKMCINLF_ItemIdCrypted ^ FBGGEFFJJHB; } set { FPKDKMCINLF_ItemIdCrypted = value ^ FBGGEFFJJHB; } } //0x19FD48C PGMIHJMDLLN 0x19FD4A0 BAFGHJAOBIB
	public int GDEJFKCMNAC_EpisodeId { get { return JHOMMHBDHHK_EpisodeIdCrypted ^ FBGGEFFJJHB; } set { JHOMMHBDHHK_EpisodeIdCrypted = value ^ FBGGEFFJJHB; } } //0x19FD4B4 AKLFLGKLABO 0x19FD4C8 KGFEHJHIGHC
	public int EILKGEADKGH_Idx { get { return HHPFFPINGAA_IdxCrypted ^ FBGGEFFJJHB; } set { HHPFFPINGAA_IdxCrypted = value ^ FBGGEFFJJHB; } } //0x19FD4DC NPDDACIHBKD 0x19FD4F0 BJJMCKHBPNH
	public bool FDIJEBNIBIE_IsFeatured { get { return FHAFHHOKGGL == CNECJGKECHK_True; } set { FHAFHHOKGGL = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x19FD504 GNBOCACPOFA 0x19FD518 CILHBHAOFEI
	public bool JOPPFEHKNFO_IsPickup { get { return ECDMGKIIKFL == CNECJGKECHK_True; } set { ECDMGKIIKFL = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x19FD548 FNIOGOJFLMG 0x19FD55C AJIOKKIJBED

	// RVA: 0x19FD58C Offset: 0x19FD58C VA: 0x19FD58C
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
	{
		OPFGFINHFCE_Name = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.OPFGFINHFCE_name];
		NANNGLGOFKH_Value = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.NANNGLGOFKH_value];
		BPNPBJALGHM_Quantity = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.BPNPBJALGHM_quantity];
		MMOJHIPAAIK_Probability = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.MMOJHIPAAIK_probability];
		JOPPFEHKNFO_IsPickup = false;
		JBLCNEILLMJ_ItemName = "";
		if(OPFGFINHFCE_Name == AFEHLCGHAEE_Strings.COIODGJDJEJ_scene)
		{
			NPPNDDMPFJJ_ItemCat = EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene;
			JJBGOIMEIPF_ItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene, NANNGLGOFKH_Value);
			JBLCNEILLMJ_ItemName = EKLNMHFCAOI.INCKKODFJAP_GetItemName(NPPNDDMPFJJ_ItemCat, NANNGLGOFKH_Value);
			if(NANNGLGOFKH_Value < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList.Count - 1)
			{
				GDEJFKCMNAC_EpisodeId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[NANNGLGOFKH_Value - 1].KELFCMEOPPM_Ep;
			}
		}
		else if(OPFGFINHFCE_Name == AFEHLCGHAEE_Strings.KBMDMEEMGLK_grow_item)
		{
			NPPNDDMPFJJ_ItemCat = EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem;
			JJBGOIMEIPF_ItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem, NANNGLGOFKH_Value);
			JBLCNEILLMJ_ItemName = EKLNMHFCAOI.INCKKODFJAP_GetItemName(NPPNDDMPFJJ_ItemCat, NANNGLGOFKH_Value);
		}
		FJNGOPBGEOI_GroupIdx = 0;
		if (!IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.PANKNKOIIJE_group_key))
			return;
		string group = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.PANKNKOIIJE_group_key];
		FJNGOPBGEOI_GroupIdx = BPADANIKFHP.GIFAIIDJPND.FindIndex((string GHPLINIACBB) =>
		{
			//0x19FDC4C
			return GHPLINIACBB == group;
		}) + 1;
	}
}
