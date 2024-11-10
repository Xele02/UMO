
using System.Collections.Generic;

[System.Obsolete("Use PLPBJOFICEJ_CosItem", true)]
public class PLPBJOFICEJ { }
[UMOClass(ReaderClass = "MADCJBCGGEE")]
public class PLPBJOFICEJ_CosItem : DIHHCBACKGG_DbSection
{
	public enum DPNGHIDJCHA_Category
	{
		HJNNKCMLGFL = 0,
		GLFGNEILACA = 1,
		GLHANCMGNDM_2 = 2,
	}

	[UMOClass(ReaderClass = "FLNGBOANAGE")]
	public class IBEMFIAFIKH_ItemInfo
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int EAJCFBCHIFB_RarityCrypted; // 0xC
		public int ICKOHEDLEFP_PointValueCrypted; // 0x10
		public int LLEMDLLGIAH; // 0x14
		public int MKENMKMJFKP_CategoryCrypted; // 0x18

		[UMOMember(ReaderMember = "PPFNGGCBJKC", CryptedInMemory = true, Desc = "Item id")]
		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB; } } //0xFEC414 DEMEPMAEJOO 0xFEBDC8 HIGKAIDMOKN
		[UMOMember(ReaderMember = "FBFLDFMFFOH", CryptedInMemory = true, Desc = "Item rarity")]
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB; } } //0xFEC4AC OEEHBGECGKL 0xFEBE64 GHLMHLJJBIG
		[UMOMember(ReaderMember = "JBGEEPFKIGG", CryptedInMemory = true, Desc = "Point applied when used to upgrade costume.")]
		public int JBGEEPFKIGG_PointValue { get { return ICKOHEDLEFP_PointValueCrypted ^ FBGGEFFJJHB; } set { ICKOHEDLEFP_PointValueCrypted = value ^ FBGGEFFJJHB; } } //0xFEC544 OLOCMINKGON 0xFEBF00 ABAFHIBFKCE
		[UMOMember(ReaderMember = "FDBOPFEOENF", CryptedInMemory = true, Desc = "Could be level or diva id")]
		public int FDBOPFEOENF { get { return LLEMDLLGIAH ^ FBGGEFFJJHB; } set { LLEMDLLGIAH = value ^ FBGGEFFJJHB; } } //0xFEC2E4 MJPHCAIKKJG 0xFEBF9C GHECGDMEBFF
		[UMOMember(ReaderMember = "GBJFNGCDKPM", CryptedInMemory = true, Desc = "Only cat 2 ?")]
		public int INDDJNMPONH_Category { get { return MKENMKMJFKP_CategoryCrypted ^ FBGGEFFJJHB; } set { MKENMKMJFKP_CategoryCrypted = value ^ FBGGEFFJJHB; } } //0xFEC37C GHAILOLPHPF 0xFEC038 BACGOKIGMBC

		//// RVA: 0xFEC1C0 Offset: 0xFEC1C0 VA: 0xFEC1C0
		//public uint CAOGDCBPBAN() { }
	}

	public const int CCAPGNIGIOI = 23;
	public static int FBGGEFFJJHB = 0x181b5; // 0x0
	[UMOMember(ReaderMember = "GKNGIIHMBOD", Desc = "List of items")]
	private List<IBEMFIAFIKH_ItemInfo> CDENCMNHNGA_List; // 0x20

	//public int DLLMLAENCPA { get; }

	//// RVA: 0xFEB730 Offset: 0xFEB730 VA: 0xFEB730
	public IBEMFIAFIKH_ItemInfo EEOADCECNOM_GetItemById(int PPFNGGCBJKC)
	{
		return CDENCMNHNGA_List[PPFNGGCBJKC - 1];
	}

	//// RVA: 0xFEB7B0 Offset: 0xFEB7B0 VA: 0xFEB7B0
	public IBEMFIAFIKH_ItemInfo LOOANCFLPMP_GetItemByIdx(int OIPCCBHIKIA)
	{
		return CDENCMNHNGA_List[OIPCCBHIKIA];
	}

	//// RVA: 0xFEB830 Offset: 0xFEB830 VA: 0xFEB830
	public int MIGONIENGBF_GetItemsCount()
	{
		return CDENCMNHNGA_List.Count;
	}

	//// RVA: 0xFEB8A8 Offset: 0xFEB8A8 VA: 0xFEB8A8
	public IBEMFIAFIKH_ItemInfo LBDOLHGDIEB_FindItem(int MCDINKAKFGG, DPNGHIDJCHA_Category _INDDJNMPONH_Cat)
	{
		return CDENCMNHNGA_List.Find((IBEMFIAFIKH_ItemInfo KOGBMDOONFA) =>
		{
			//0xFEC274
			return KOGBMDOONFA.FDBOPFEOENF == MCDINKAKFGG && KOGBMDOONFA.INDDJNMPONH_Category == (int)_INDDJNMPONH_Cat;
		});
	}

	// RVA: 0xFEB9C4 Offset: 0xFEB9C4 VA: 0xFEB9C4
	public PLPBJOFICEJ_CosItem()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 12;
	}

	// RVA: 0xFEBA84 Offset: 0xFEBA84 VA: 0xFEBA84 Slot: 8
	protected override void KMBPACJNEOF()
	{
		if (CDENCMNHNGA_List == null)
			return;
		CDENCMNHNGA_List.Clear();
	}

	// RVA: 0xFEBAF0 Offset: 0xFEBAF0 VA: 0xFEBAF0 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		MADCJBCGGEE parser = MADCJBCGGEE.HEGEKFMJNCC(DBBGALAPFGC);
		FLNGBOANAGE[] array = parser.GKNGIIHMBOD;
		CDENCMNHNGA_List = new List<IBEMFIAFIKH_ItemInfo>(array.Length);
		for(int i = 0; i < array.Length; i++)
		{
			IBEMFIAFIKH_ItemInfo data = new IBEMFIAFIKH_ItemInfo();
			data.PPFNGGCBJKC_Id = (int)array[i].PPFNGGCBJKC;
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH;
			data.JBGEEPFKIGG_PointValue = (int)array[i].JBGEEPFKIGG;
			data.FDBOPFEOENF = array[i].FDBOPFEOENF;
			data.INDDJNMPONH_Category = array[i].GBJFNGCDKPM;
			CDENCMNHNGA_List.Add(data);
		}
		return true;
	}

	// RVA: 0xFEC0D4 Offset: 0xFEC0D4 VA: 0xFEC0D4 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return false;
	}

	// RVA: 0xFEC0DC Offset: 0xFEC0DC VA: 0xFEC0DC Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "PLPBJOFICEJ_CosItem.CAOGDCBPBAN");
		return 0;
	}
}
