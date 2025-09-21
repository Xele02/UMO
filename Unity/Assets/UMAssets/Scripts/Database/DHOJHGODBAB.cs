
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use DHOJHGODBAB_Quest", true)]
public class DHOJHGODBAB { }
public class DHOJHGODBAB_Quest : DIHHCBACKGG_DbSection
{
	public List<CNLPPCFJEID_QuestInfo> BEGCHDHHEKC_DailyQuests { get; private set; } // 0x20 FGGBICBDOEN DEBOJOHHPPB CFINEIEEJGN
	public List<CNLPPCFJEID_QuestInfo> GPMKFMFEKLN_NormalQuests { get; private set; } // 0x24 LKPJIEOOENM HDOHKBOJCDK CDNIDJPOHDJ
	public List<LCKMNLOLDPD> LFAAEPAAEMB { get; private set; } // 0x28 LGPNBHKGMEA CBMPDJKIIOF EFCJGLJJBNA

	// RVA: 0x1988E24 Offset: 0x1988E24 VA: 0x1988E24
	public DHOJHGODBAB_Quest()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		BEGCHDHHEKC_DailyQuests = new List<CNLPPCFJEID_QuestInfo>();
		GPMKFMFEKLN_NormalQuests = new List<CNLPPCFJEID_QuestInfo>();
		LFAAEPAAEMB = new List<LCKMNLOLDPD>();
		LMHMIIKCGPE = 67;
	}

	// RVA: 0x1988F64 Offset: 0x1988F64 VA: 0x1988F64 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		BEGCHDHHEKC_DailyQuests.Clear();
		GPMKFMFEKLN_NormalQuests.Clear();
		LFAAEPAAEMB.Clear();
		int t = (int)Utility.GetCurrentUnixTime();
		t *= 7;
		int v = t;
		for(int i = 1; i < 21; i++)
		{
			CNLPPCFJEID_QuestInfo data = new CNLPPCFJEID_QuestInfo();
			data.LHPDDGIJKNB_Reset(i, v);
			BEGCHDHHEKC_DailyQuests.Add(data);
			v += 3;
		}
		for(int i = 0; i < 1700; i++)
		{
			CNLPPCFJEID_QuestInfo data = new CNLPPCFJEID_QuestInfo();
			data.LHPDDGIJKNB_Reset(i + 1, t);
			GPMKFMFEKLN_NormalQuests.Add(data);
			t += 7;
		}
	}

	// RVA: 0x1989194 Offset: 0x1989194 VA: 0x1989194 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_Data)
	{
		GEDOHHLGKCG parser = GEDOHHLGKCG.HEGEKFMJNCC(_DBBGALAPFGC_Data);
		if(EELEJILKBIM_LoadDailyQuest(parser) && GBNIHKOIMFO_LoadNormalQuest(parser))
		{
			IHJNKFOJPKM(parser);
			return true;
		}
		return false;
	}

	//// RVA: 0x19891F4 Offset: 0x19891F4 VA: 0x19891F4
	private bool EELEJILKBIM_LoadDailyQuest(GEDOHHLGKCG ENCJBKPHGAL)
	{
		EKMJAONFHDF[] array = ENCJBKPHGAL.HGMBJPLPHJJ;
		if (array.Length < 21)
		{
			for (int i = 0; i < array.Length; i++)
			{
				CNLPPCFJEID_QuestInfo data = BEGCHDHHEKC_DailyQuests[i];
				data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC;
				data.INDDJNMPONH_type = (int)array[i].MAPNDFCJFLJ;
				data.CHOFDPDFPDC_ConfigValue = (int)array[i].JBFLEDKDFCO;
				data.FCDKJAKLGMB_TargetValue = (int)array[i].PMDLBHLNIDP;
				data.AKBHPFBDDOL_Val = (int)array[i].JIMJHIDEHNM;
				data.EIHOBHDKCDB_RewardId = (int)array[i].JGOHPDKCJKB;
				data.HHIBBHFHENH_LinkQuestId = 0;
				data.EILKGEADKGH_Order = (int)array[i].FPOMEEJFBIG;
				data.KJBGCLPMLCG_OpenedAt = array[i].FNEIADJMHHO;
				data.GJFPFFBAKGK_CloseAt = array[i].EICJBAEDMNM;
				data.DEPGBBJMFED_CategoryId = data.PPFNGGCBJKC_id;
			}
			return true;
		}
		else
		{
			HDIDJNCGICK_LoadError = "daily quest limit over";
			return false;
		}
	}

	//// RVA: 0x1989628 Offset: 0x1989628 VA: 0x1989628
	private bool GBNIHKOIMFO_LoadNormalQuest(GEDOHHLGKCG ENCJBKPHGAL)
	{
		GBGCDLGBMEF[] array = ENCJBKPHGAL.MECOBEMIHDG;
		if (array.Length < 1701)
		{
			for (int i = 0; i < array.Length; i++)
			{
				CNLPPCFJEID_QuestInfo data = GPMKFMFEKLN_NormalQuests[i];
				data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC;
				data.INDDJNMPONH_type = (int)array[i].MAPNDFCJFLJ;
				data.CHOFDPDFPDC_ConfigValue = (int)array[i].JBFLEDKDFCO;
				data.FCDKJAKLGMB_TargetValue = (int)array[i].PMDLBHLNIDP;
				data.AKBHPFBDDOL_Val = 0;
				data.EIHOBHDKCDB_RewardId = (int)array[i].JGOHPDKCJKB;
				data.EILKGEADKGH_Order = (int)array[i].FPOMEEJFBIG;
				data.KJBGCLPMLCG_OpenedAt = array[i].FNEIADJMHHO;
				data.GJFPFFBAKGK_CloseAt = array[i].EICJBAEDMNM;
				data.OAPCHMHAJID = array[i].HPGNBPIBAOM != 0;
				data.DEPGBBJMFED_CategoryId = (int)array[i].DMEDKJPOLCH;
				data.HDBFCIOCNPA_AchievementId = (int)array[i].ADOJHHMMNIN;
				data.LMPPENOILPF = (int)array[i].ADCKKAFCIAC;
				data.EKANGPODCEP_EventId = array[i].JMMEGKGCIIL;
				if(JKAECBCNHAN_IsEnabled((int)array[i].IJEKNCDIIAE, data.INDDJNMPONH_type != 0 ? 2 : data.INDDJNMPONH_type, 0) != 2)
				{
					data.INDDJNMPONH_type = 0;
				}
			}
			return true;
		}
		else
		{
			HDIDJNCGICK_LoadError = "normal quest limit over";
			return false;
		}
	}

	//// RVA: 0x1989B7C Offset: 0x1989B7C VA: 0x1989B7C
	private bool IHJNKFOJPKM(GEDOHHLGKCG ENCJBKPHGAL)
	{
		KLPHKNHEKPM[] array = ENCJBKPHGAL.APHNKNGKKFC;
		for(int i = 0; i < array.Length; i++)
		{
			LCKMNLOLDPD data = new LCKMNLOLDPD();
			data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC;
			data.GLCLFMGPMAN_ItemId = (int)array[i].CLDDAEMKHOG;
			data.HMFFHLPNMPH_Count = (int)array[i].PIMBMBIICMK;
			data.BGFPPGPJONG_QuestKeyId = (int)array[i].LJNAKDMILMC;
			data.APNMKLJMPMD_Type = (int)array[i].OILNNGPCLGD;
			LFAAEPAAEMB.Add(data);
		}
		return true;
	}

	// RVA: 0x1989F28 Offset: 0x1989F28 VA: 0x1989F28 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "DHOJHGODBAB_Quest.CAOGDCBPBAN");
		return 0;
	}
}

[System.Obsolete("Use CNLPPCFJEID_QuestInfo", true)]
public class CNLPPCFJEID { }
public class CNLPPCFJEID_QuestInfo
{
	public int FBGGEFFJJHB_xor; // 0x8
	private int EHOIENNDEDH_IdCrypted; // 0xC
	private int MKENMKMJFKP_TypeCrypted; // 0x10
	private int ICLBAMBDKNI; // 0x14
	private int NILLPINGIIP; // 0x18
	private int FKKHMCINELD; // 0x1C
	private int IOAGHJGBNLC_LinkQuestIdCrypted; // 0x20
	private int APJGMOJDPAK; // 0x24
	private int HNEHIJCAOJM_CategoryIdCrypted; // 0x28
	private long IBCNABKLHHH_StartCrypted; // 0x30
	private long MABPKDKBJAG_CloseAtCrypted; // 0x38
	private int HHPFFPINGAA_OrderCrypted; // 0x40
	private int ELFADCBHPCD; // 0x44
	private int EGCMPELNLKP; // 0x48
	public bool OAPCHMHAJID; // 0x4C
	public int HDBFCIOCNPA_AchievementId; // 0x50

	public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x175CD9C DEMEPMAEJOO 0x175CCD4 HIGKAIDMOKN
	public int INDDJNMPONH_type { get { return MKENMKMJFKP_TypeCrypted ^ FBGGEFFJJHB_xor; } set { MKENMKMJFKP_TypeCrypted = value ^ FBGGEFFJJHB_xor; } } //0x175CDA8 GHAILOLPHPF 0x175CCE4 BACGOKIGMBC
	public int CHOFDPDFPDC_ConfigValue { get { return ICLBAMBDKNI ^ FBGGEFFJJHB_xor; } set { ICLBAMBDKNI = value ^ FBGGEFFJJHB_xor; } } //0x175CDB8 IBCDKHDLOKG 0x175CCF4 ICHJGBKDCGM
	public int FCDKJAKLGMB_TargetValue { get { return NILLPINGIIP ^ FBGGEFFJJHB_xor; } set { NILLPINGIIP = value ^ FBGGEFFJJHB_xor; } } //0x175CDC8 IJPJEEOLPIG 0x175CDD8 EDECEGOKICK
	public int HHIBBHFHENH_LinkQuestId { get { return IOAGHJGBNLC_LinkQuestIdCrypted ^ FBGGEFFJJHB_xor; } set { IOAGHJGBNLC_LinkQuestIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x175CDE8 MEHBABCCHOO 0x175CD14 FBCMDNCLBDC
	public int DEPGBBJMFED_CategoryId { get { return HNEHIJCAOJM_CategoryIdCrypted ^ FBGGEFFJJHB_xor; } set { HNEHIJCAOJM_CategoryIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x175CDF8 FNMFOBJIIIC 0x175CD6C OBEDPJLBBEG
	// DayOfWeek
	public int AKBHPFBDDOL_Val { get { return APJGMOJDPAK ^ FBGGEFFJJHB_xor; } set { APJGMOJDPAK = value ^ FBGGEFFJJHB_xor; } } //0x175CE08 ANBHKALCHDJ 0x175CD24 GDANPNDMDCC
	public int EIHOBHDKCDB_RewardId { get { return FKKHMCINELD ^ FBGGEFFJJHB_xor; } set { FKKHMCINELD = value ^ FBGGEFFJJHB_xor; } } //0x175CE18 EALKEGPNHGK 0x175CD04 LNFEIPOKKNG
	public int EILKGEADKGH_Order { get { return HHPFFPINGAA_OrderCrypted ^ FBGGEFFJJHB_xor; } set { HHPFFPINGAA_OrderCrypted = value ^ FBGGEFFJJHB_xor; } } //0x175CE28 NPDDACIHBKD 0x175CD34 BJJMCKHBPNH
	public int LMPPENOILPF { get { return ELFADCBHPCD ^ FBGGEFFJJHB_xor; } set { ELFADCBHPCD = value ^ FBGGEFFJJHB_xor; } } //0x175CE38 JAOMCMFJPDJ 0x175CD7C LINHGODPPMB
	public long KJBGCLPMLCG_OpenedAt { get { return IBCNABKLHHH_StartCrypted ^ FBGGEFFJJHB_xor; } set { IBCNABKLHHH_StartCrypted = value ^ FBGGEFFJJHB_xor; } } //0x175CE48 IDLJOCDJJOC 0x175CD44 ODIEKGPKOAC
	public long GJFPFFBAKGK_CloseAt { get { return MABPKDKBJAG_CloseAtCrypted ^ FBGGEFFJJHB_xor; } set { MABPKDKBJAG_CloseAtCrypted = value ^ FBGGEFFJJHB_xor; } } //0x175CE60 KPBMCJKFEGN 0x175CD58 IEFCDGKGICA
	public int EKANGPODCEP_EventId { get { return EGCMPELNLKP ^ FBGGEFFJJHB_xor; } set { EGCMPELNLKP = value ^ FBGGEFFJJHB_xor; } } //0x175CE78 EBLAFEMDFGD 0x175CD8C AHEFELNFBDM

	//// RVA: 0x175CC78 Offset: 0x175CC78 VA: 0x175CC78
	public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id, int KNEFBLHBDBG)
	{
		FBGGEFFJJHB_xor = _PPFNGGCBJKC_id * KNEFBLHBDBG * 11;
		OAPCHMHAJID = false;
		EILKGEADKGH_Order = 0;
		LMPPENOILPF = 0;
		EKANGPODCEP_EventId = 0;
		this.PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
		INDDJNMPONH_type = 0;
		CHOFDPDFPDC_ConfigValue = 0;
		EIHOBHDKCDB_RewardId = 0;
		HHIBBHFHENH_LinkQuestId = 0;
		AKBHPFBDDOL_Val = 0;
		DEPGBBJMFED_CategoryId = 0;
		KJBGCLPMLCG_OpenedAt = 0;
		GJFPFFBAKGK_CloseAt = 0;
	}

	//// RVA: 0x175CE88 Offset: 0x175CE88 VA: 0x175CE88
	//public uint CAOGDCBPBAN() { }
}

public class LCKMNLOLDPD
{
	public int FBGGEFFJJHB_xor = 0x340f8ed5; // 0x8
	public int EHOIENNDEDH_IdCrypted; // 0xC
	public int AHGCGHAAHOO_ItemIdCrypted; // 0x10
	public int HLMAFFLCCKD_CountCrypted; // 0x14
	public int IPFBMBMNAGL_Crypted; // 0x18
	public int OHDDANALELB_Crypted; // 0x1C

	public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xD9A97C DEMEPMAEJOO 0xD9A98C HIGKAIDMOKN
	public int GLCLFMGPMAN_ItemId { get { return AHGCGHAAHOO_ItemIdCrypted ^ FBGGEFFJJHB_xor; } set { AHGCGHAAHOO_ItemIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xD9A99C LNJAENEGDEL 0xD9A9AC JHIDBGCHOKL
	public int HMFFHLPNMPH_Count { get { return HLMAFFLCCKD_CountCrypted ^ FBGGEFFJJHB_xor; } set { HLMAFFLCCKD_CountCrypted = value ^ FBGGEFFJJHB_xor; } } //0xD9A9BC NJOGDDPICKG 0xD9A9CC NBBGMMBICNA
	public int BGFPPGPJONG_QuestKeyId { get { return IPFBMBMNAGL_Crypted ^ FBGGEFFJJHB_xor; } set { IPFBMBMNAGL_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xD9A9DC LBMNPGFFCJN 0xD9A9EC NDNCLLKIJHA
	public int APNMKLJMPMD_Type { get { return OHDDANALELB_Crypted ^ FBGGEFFJJHB_xor; } set { OHDDANALELB_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xD9A9FC ICCFOKKODOH 0xD9AA0C CBPDLNBEJAE

	//// RVA: 0xD9AA1C Offset: 0xD9AA1C VA: 0xD9AA1C
	//public uint CAOGDCBPBAN() { }
}
