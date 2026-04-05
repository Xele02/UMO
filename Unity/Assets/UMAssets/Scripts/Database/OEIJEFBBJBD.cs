
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use OEIJEFBBJBD_EventSp", true)]
public class OEIJEFBBJBD { }
public class OEIJEFBBJBD_EventSp : DIHHCBACKGG_DbSection
{
	public class AHNGNPCGCHH
	{
		public int OBGBAOLONDD_UniqueId; // 0x8
		public int HFNIHKOAMGC; // 0xC
		public string OPFGFINHFCE_name; // 0x10
		public string HEDAGCNPHGD_RankingName; // 0x14
		public string OCGFKMHNEOF_name_for_api; // 0x18
		public string FEMMDNIELFC_Desc; // 0x1C
		public long BONDDBOFBND_RankingStart; // 0x20
		public long HPNOGLIFJOP_RankingEnd; // 0x28
		public long BCPHKGGOEKA; // 0x30
		public long LNFKGHNHJKE_RankingEnd2; // 0x38
		public long JGMDAOACOJF_RewardStart; // 0x40
		public long IDDBFFBPNGI_RewardEnd; // 0x48
		public long KNLGKBBIBOH_RewardEnd2; // 0x50
		public int MJBKGOJBPAD_item_type; // 0x58
		public sbyte POGEFBMBPCB_MonthOdd; // 0x5C
		public sbyte AHKNMANFILO_DayGroup; // 0x5D
		public sbyte MOEKELIIDEO_SaveIdx; // 0x5E
		public sbyte HKKNEAGCIEB_RankingSupport; // 0x5F
		public string OMCAOJJGOGG_Lb; // 0x60
		public long OHGDNJLFDFF_Start; // 0x68
		public long PHKLJGNMFBL_End; // 0x70
		private NNJFKLBPBNK_SecureString EBGIDCIIGDO_KeyPrefix = new NNJFKLBPBNK_SecureString(); // 0x78
		private NNJFKLBPBNK_SecureString NJKIMJAFCPC = new NNJFKLBPBNK_SecureString(); // 0x7C
		public int HIOOGLEJBKM_StartAdventureId; // 0x80
		public int FJCADCDNPMP_EndAdventureId; // 0x84

		public string OCDMGOGMHGE_KeyPrefix { get { return EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value; } set { EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value = value; } } //0x1B468D8 HBAAAKFHDBB_get_KeyPrefix 0x1B45C44 NHJLJOIPOFK_set_KeyPrefix
		public string PJBILOFOCIC { get { return NJKIMJAFCPC.DNJEJEANJGL_Value; } set { NJKIMJAFCPC.DNJEJEANJGL_Value = value; } } //0x1B46904 NOEFEAIFHCL_get_ 0x1B45C78 GJIJFGNONEL_set_

		//// RVA: 0x1B42628 Offset: 0x1B42628 VA: 0x1B42628
		public void LHPDDGIJKNB_Reset()
		{
			OBGBAOLONDD_UniqueId = 0;
			HFNIHKOAMGC = 0;
			BONDDBOFBND_RankingStart = 0;
			HPNOGLIFJOP_RankingEnd = 0;
			JGMDAOACOJF_RewardStart = 0;
			IDDBFFBPNGI_RewardEnd = 0;
			BCPHKGGOEKA = 0;
			MJBKGOJBPAD_item_type = 1;
			POGEFBMBPCB_MonthOdd = 0;
			OPFGFINHFCE_name = null;
			OCGFKMHNEOF_name_for_api = null;
			OCDMGOGMHGE_KeyPrefix = "";
			PJBILOFOCIC = "";
			OHGDNJLFDFF_Start = 0;
			PHKLJGNMFBL_End = 0;
			OMCAOJJGOGG_Lb = "";
			HIOOGLEJBKM_StartAdventureId = 0;
			FJCADCDNPMP_EndAdventureId = 0;
		}

		//// RVA: 0x1B466EC Offset: 0x1B466EC VA: 0x1B466EC
		//public uint CAOGDCBPBAN() { }
	}

	public class AODDNOGBFLP
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int IJEKNCDIIAE_mver; // 0xC
		public int PLALNIIBLOF_en; // 0x10
		public int MGLJCOMOGLO_BtnId; // 0x14
		public int PNDEAHGLJIC_BtnType; // 0x18
		public int LPDLBACJKIB_TransId; // 0x1C
		public long PDBPFJJCADD_open_at; // 0x20
		public long FDBNFFNFOND_close_at; // 0x28
		public int GNOFNIOLPPC_ImgId; // 0x30
		public int BOJCOPAALNC_EventId; // 0x34 // SkdId

		//// RVA: 0x1B415AC Offset: 0x1B415AC VA: 0x1B415AC
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id) { }

		//// RVA: 0x1B46930 Offset: 0x1B46930 VA: 0x1B46930
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//PPFNGGCBJKC_id = id
		//IJEKNCDIIAE_mver = mver
		//PLALNIIBLOF_en = en
		//MGLJCOMOGLO_BtnId = btn_id
		//PNDEAHGLJIC_BtnType = btn_typ
		//LPDLBACJKIB_TransId = trans_id
		//PDBPFJJCADD_open_at = open_at
		//FDBNFFNFOND_close_at = close_at
		//GNOFNIOLPPC_ImgId = img_id
		//BOJCOPAALNC_EventId = skd_id

		//// RVA: 0x1B46C98 Offset: 0x1B46C98 VA: 0x1B46C98
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, ANCFFLNKINL JMHECKKKMLK) { }

		//// RVA: 0x1B415D0 Offset: 0x1B415D0 VA: 0x1B415D0
		public void ODDIHGPONFL_Copy(AODDNOGBFLP GPBJHKLFCEP)
		{
			PPFNGGCBJKC_id = GPBJHKLFCEP.PPFNGGCBJKC_id;
			IJEKNCDIIAE_mver = GPBJHKLFCEP.IJEKNCDIIAE_mver;
			PLALNIIBLOF_en = GPBJHKLFCEP.PLALNIIBLOF_en;
			MGLJCOMOGLO_BtnId = GPBJHKLFCEP.MGLJCOMOGLO_BtnId;
			PNDEAHGLJIC_BtnType = GPBJHKLFCEP.PNDEAHGLJIC_BtnType;
			LPDLBACJKIB_TransId = GPBJHKLFCEP.LPDLBACJKIB_TransId;
			PDBPFJJCADD_open_at = GPBJHKLFCEP.PDBPFJJCADD_open_at;
			FDBNFFNFOND_close_at = GPBJHKLFCEP.FDBNFFNFOND_close_at;
			GNOFNIOLPPC_ImgId = GPBJHKLFCEP.GNOFNIOLPPC_ImgId;
			BOJCOPAALNC_EventId = GPBJHKLFCEP.BOJCOPAALNC_EventId;
		}

		//// RVA: 0x1B466F4 Offset: 0x1B466F4 VA: 0x1B466F4
		//public uint CAOGDCBPBAN() { }
	}

	public class NJJEAKMBGPN
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int PLALNIIBLOF_en; // 0xC
		public int BDEOMEBFDFF_gacha_id; // 0x10
		public long PDBPFJJCADD_open_at; // 0x18
		public long FDBNFFNFOND_close_at; // 0x20

		//// RVA: 0x1DCB6D4 Offset: 0x1DCB6D4 VA: 0x1DCB6D4
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id) { }

		//// RVA: 0x1DCB6F4 Offset: 0x1DCB6F4 VA: 0x1DCB6F4
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//PPFNGGCBJKC_id = id
		//PLALNIIBLOF_en = en
		//BDEOMEBFDFF_gacha_id = gacha_id
		//PDBPFJJCADD_open_at = open_at
		//FDBNFFNFOND_close_at = close_at

		//// RVA: 0x1DCB8F8 Offset: 0x1DCB8F8 VA: 0x1DCB8F8
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, ANCFFLNKINL JMHECKKKMLK) { }

		//// RVA: 0x1DCBA5C Offset: 0x1DCBA5C VA: 0x1DCBA5C
		//public uint CAOGDCBPBAN() { }
	}

	public class PHIMHBPOMAD
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int PLALNIIBLOF_en; // 0xC
		public int DNJLJMKKDNA_EventId; // 0x10
		public long PDBPFJJCADD_open_at; // 0x18
		public long FDBNFFNFOND_close_at; // 0x20

		//// RVA: 0x1DCBA90 Offset: 0x1DCBA90 VA: 0x1DCBA90
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id) { }

		//// RVA: 0x1DCBAB0 Offset: 0x1DCBAB0 VA: 0x1DCBAB0
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//PPFNGGCBJKC_id = id
		//PLALNIIBLOF_en = en
		//DNJLJMKKDNA_EventId = event_id
		//PDBPFJJCADD_open_at = open_at
		//FDBNFFNFOND_close_at = close_at

		//// RVA: 0x1DCBCB4 Offset: 0x1DCBCB4 VA: 0x1DCBCB4
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, ANCFFLNKINL JMHECKKKMLK) { }

		//// RVA: 0x1DCBE18 Offset: 0x1DCBE18 VA: 0x1DCBE18
		//public uint CAOGDCBPBAN() { }
	}

	public class AOOLGJIFOEI
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int PLALNIIBLOF_en; // 0xC
		public int OENPCNBFPDA_bg_id; // 0x10
		public int KGICDMIJGDF_Group; // 0x14
		public long PDBPFJJCADD_open_at; // 0x18
		public long FDBNFFNFOND_close_at; // 0x20

		//// RVA: 0x1B46EC0 Offset: 0x1B46EC0 VA: 0x1B46EC0
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id) { }

		//// RVA: 0x1B46EDC Offset: 0x1B46EDC VA: 0x1B46EDC
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//PPFNGGCBJKC_id = id
		//PLALNIIBLOF_en = en
		//OENPCNBFPDA_bg_id = bg_id
		//KGICDMIJGDF_Group = group
		//PDBPFJJCADD_open_at = open_at
		//FDBNFFNFOND_close_at = close_at

		//// RVA: 0x1B47114 Offset: 0x1B47114 VA: 0x1B47114
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, ANCFFLNKINL JMHECKKKMLK) { }

		//// RVA: 0x1B4728C Offset: 0x1B4728C VA: 0x1B4728C
		//public uint CAOGDCBPBAN() { }
	}

	public class LJAJKDHLGAJ
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int PLALNIIBLOF_en; // 0xC
		public int OPKCNBFBBKP_BannerId; // 0x10
		public long PDBPFJJCADD_open_at; // 0x18
		public long FDBNFFNFOND_close_at; // 0x20

		//// RVA: 0x1B488EC Offset: 0x1B488EC VA: 0x1B488EC
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id) { }

		//// RVA: 0x1B4890C Offset: 0x1B4890C VA: 0x1B4890C
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//PPFNGGCBJKC_id = id
		//PLALNIIBLOF_en = en
		//OPKCNBFBBKP_BannerId = banner_id
		//PDBPFJJCADD_open_at = open_at
		//FDBNFFNFOND_close_at = close_at

		//// RVA: 0x1B48B10 Offset: 0x1B48B10 VA: 0x1B48B10
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, ANCFFLNKINL JMHECKKKMLK) { }

		//// RVA: 0x1B48C74 Offset: 0x1B48C74 VA: 0x1B48C74
		//public uint CAOGDCBPBAN() { }
	}

	public class CLNIPEPHJKO
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int PLALNIIBLOF_en; // 0xC
		public int[] OPKCNBFBBKP_BannerId; // 0x10
		public long[] BEBJKJKBOGH_date; // 0x14
		public long PDBPFJJCADD_open_at; // 0x18
		public long FDBNFFNFOND_close_at; // 0x20

		// RVA: 0x1B46048 Offset: 0x1B46048 VA: 0x1B46048
		public CLNIPEPHJKO()
		{
			OPKCNBFBBKP_BannerId = new int[4];
			BEBJKJKBOGH_date = new long[4];
		}

		//// RVA: 0x1B47820 Offset: 0x1B47820 VA: 0x1B47820
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id) { }

		//// RVA: 0x1B478D0 Offset: 0x1B478D0 VA: 0x1B478D0
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//PPFNGGCBJKC_id = id
		//PLALNIIBLOF_en = en
		//OPKCNBFBBKP_BannerId = banner_id
		//BEBJKJKBOGH_date = date
		//PDBPFJJCADD_open_at = open_at
		//FDBNFFNFOND_close_at = close_at

		//// RVA: 0x1B47C10 Offset: 0x1B47C10 VA: 0x1B47C10
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, ANCFFLNKINL JMHECKKKMLK) { }

		//// RVA: 0x1B47E6C Offset: 0x1B47E6C VA: 0x1B47E6C
		//public uint CAOGDCBPBAN() { }
	}

	public class HNLLDDLBJKG
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int PLALNIIBLOF_en; // 0xC
		public long PDBPFJJCADD_open_at; // 0x10
		public long FDBNFFNFOND_close_at; // 0x18

		//// RVA: 0x1B482DC Offset: 0x1B482DC VA: 0x1B482DC
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id) { }

		//// RVA: 0x1B482F8 Offset: 0x1B482F8 VA: 0x1B482F8
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//PPFNGGCBJKC_id = id
		//PLALNIIBLOF_en = en
		//PDBPFJJCADD_open_at = open_at
		//FDBNFFNFOND_close_at = close_at

		//// RVA: 0x1B4849C Offset: 0x1B4849C VA: 0x1B4849C
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, ANCFFLNKINL JMHECKKKMLK) { }

		//// RVA: 0x1B485C4 Offset: 0x1B485C4 VA: 0x1B485C4
		//public uint CAOGDCBPBAN() { }
	}

	public class LFKNBOOKCCG
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int PLALNIIBLOF_en; // 0xC
		public long PDBPFJJCADD_open_at; // 0x10
		public long FDBNFFNFOND_close_at; // 0x18

		//// RVA: 0x1B485E4 Offset: 0x1B485E4 VA: 0x1B485E4
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id) { }

		//// RVA: 0x1B48600 Offset: 0x1B48600 VA: 0x1B48600
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//PPFNGGCBJKC_id = id
		//PLALNIIBLOF_en = en
		//PDBPFJJCADD_open_at = open_at
		//FDBNFFNFOND_close_at = close_at

		//// RVA: 0x1B487A4 Offset: 0x1B487A4 VA: 0x1B487A4
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, ANCFFLNKINL JMHECKKKMLK) { }

		//// RVA: 0x1B488CC Offset: 0x1B488CC VA: 0x1B488CC
		//public uint CAOGDCBPBAN() { }
	}

	public class CKHKIMCMLAH
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int PLALNIIBLOF_en; // 0xC
		public int DNJLJMKKDNA_EventId; // 0x10
		public long PDBPFJJCADD_open_at; // 0x18
		public long FDBNFFNFOND_close_at; // 0x20

		//// RVA: 0x1B4746C Offset: 0x1B4746C VA: 0x1B4746C
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id) { }

		//// RVA: 0x1B4748C Offset: 0x1B4748C VA: 0x1B4748C
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//PPFNGGCBJKC_id = id
		//PLALNIIBLOF_en = en
		//DNJLJMKKDNA_EventId = event_id
		//PDBPFJJCADD_open_at = open_at
		//FDBNFFNFOND_close_at = close_at

		//// RVA: 0x1B47690 Offset: 0x1B47690 VA: 0x1B47690
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, ANCFFLNKINL JMHECKKKMLK) { }

		//// RVA: 0x1B477F4 Offset: 0x1B477F4 VA: 0x1B477F4
		//public uint CAOGDCBPBAN() { }
	}

	public class GFKDEIKPFNF
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int PLALNIIBLOF_en; // 0xC
		public int DNJLJMKKDNA_EventId; // 0x10
		public long PDBPFJJCADD_open_at; // 0x18
		public long FDBNFFNFOND_close_at; // 0x20

		//// RVA: 0x1B47F28 Offset: 0x1B47F28 VA: 0x1B47F28
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id) { }

		//// RVA: 0x1B47F48 Offset: 0x1B47F48 VA: 0x1B47F48
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//PPFNGGCBJKC_id = id
		//PLALNIIBLOF_en = en
		//DNJLJMKKDNA_EventId = event_id
		//PDBPFJJCADD_open_at = open_at
		//FDBNFFNFOND_close_at = close_at

		//// RVA: 0x1B4814C Offset: 0x1B4814C VA: 0x1B4814C
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, ANCFFLNKINL JMHECKKKMLK) { }

		//// RVA: 0x1B482B0 Offset: 0x1B482B0 VA: 0x1B482B0
		//public uint CAOGDCBPBAN() { }
	}

	public class BPNLIPDNKOH
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int PLALNIIBLOF_en; // 0xC
		public uint[] ALMEBFDEGBG; // 0x10
		public long PDBPFJJCADD_open_at; // 0x18
		public long FDBNFFNFOND_close_at; // 0x20

		//// RVA: 0x1B472C8 Offset: 0x1B472C8 VA: 0x1B472C8
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id) { }

		//// RVA: 0x1B472E8 Offset: 0x1B472E8 VA: 0x1B472E8
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }

		//// RVA: 0x1B47308 Offset: 0x1B47308 VA: 0x1B47308
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, ANCFFLNKINL JMHECKKKMLK) { }

		//// RVA: 0x1B46750 Offset: 0x1B46750 VA: 0x1B46750
		//public uint CAOGDCBPBAN() { }
	}

	public class MFEJBIMLPGI
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int PLALNIIBLOF_en; // 0xC
		public int KDGJBBFKLGI_Chapter; // 0x10
		public int OIAAFFHGBBD_AdvId; // 0x14 // s_value
		public long PDBPFJJCADD_open_at; // 0x18

		//// RVA: 0x1B48CA0 Offset: 0x1B48CA0 VA: 0x1B48CA0
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id) { }

		//// RVA: 0x1B48CBC Offset: 0x1B48CBC VA: 0x1B48CBC
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//PPFNGGCBJKC_id = id
		//PLALNIIBLOF_en = en
		//KDGJBBFKLGI_Chapter = chapter
		//OIAAFFHGBBD_AdvId = s_value
		//PDBPFJJCADD_open_at = open_at

		//// RVA: 0x1B48EBC Offset: 0x1B48EBC VA: 0x1B48EBC
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, ANCFFLNKINL JMHECKKKMLK) { }

		//// RVA: 0x1B467E8 Offset: 0x1B467E8 VA: 0x1B467E8
		//public uint CAOGDCBPBAN() { }
	}

	public class PLEKADHPGIJ
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int PLALNIIBLOF_en; // 0xC
		public long PDBPFJJCADD_open_at; // 0x10
		public long FDBNFFNFOND_close_at; // 0x18
		public int EJBGHLOOLBC_HelpIds; // 0x20

		// RVA: 0x1DCBE4C Offset: 0x1DCBE4C VA: 0x1DCBE4C
		//public uint CAOGDCBPBAN() { }
	}

	public const int BNODDGDDKKG = 8;
	public const int ACJBJHIOFBB = 4;
	public AHNGNPCGCHH NGHKJOEDLIP_Settings = new AHNGNPCGCHH(); // 0x20
	public List<AODDNOGBFLP> MCDIFBBJPMJ = new List<AODDNOGBFLP>(); // 0x24
	public List<NJJEAKMBGPN> EOKILLGMGDL = new List<NJJEAKMBGPN>(); // 0x28
	public List<NJJEAKMBGPN> MODIJHPMHGJ = new List<NJJEAKMBGPN>(); // 0x2C
	public List<NJJEAKMBGPN> OAIHCOFBEIE = new List<NJJEAKMBGPN>(); // 0x30
	public List<NJJEAKMBGPN> AIJIJLFKNOM = new List<NJJEAKMBGPN>(); // 0x34
	public List<PHIMHBPOMAD> ALGFDOBECLI = new List<PHIMHBPOMAD>(); // 0x38
	public List<AOOLGJIFOEI> FDGNDLBDJFH = new List<AOOLGJIFOEI>(); // 0x3C
	public List<BPNLIPDNKOH> LMLMPLLNEDG = new List<BPNLIPDNKOH>(); // 0x40
	public List<MFEJBIMLPGI> JIEIOFMJEBI = new List<MFEJBIMLPGI>(); // 0x44
	public List<AKIIJBEJOEP> NNMPGOAGEOL_quests = new List<AKIIJBEJOEP>(); // 0x48
	public List<int> JHMBHHPDPKN_SubEventIds = new List<int>(); // 0x4C
	public List<PLEKADHPGIJ> ODACAJBCJHO = new List<PLEKADHPGIJ>(); // 0x50
	public List<LJAJKDHLGAJ> CDPGPHGBNOA = new List<LJAJKDHLGAJ>(); // 0x54
	public List<CLNIPEPHJKO> OBILMOEOOFE = new List<CLNIPEPHJKO>(); // 0x58
	public List<HNLLDDLBJKG> GGEHACFPNPN = new List<HNLLDDLBJKG>(); // 0x5C
	public List<LFKNBOOKCCG> GMJFGPNMMBD = new List<LFKNBOOKCCG>(); // 0x60
	public List<CKHKIMCMLAH> PBBAKFCFGKN = new List<CKHKIMCMLAH>(); // 0x64
	public List<GFKDEIKPFNF> MEEIEAMCKFB = new List<GFKDEIKPFNF>(); // 0x68

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_m_stringParam { get; private set; } // 0x6C IHKPIFIBECO GAMGELHIHHI_get_m_stringParam DDDEJIJGGBJ_set_m_stringParam
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_m_intParam { get; private set; } // 0x70 KLDCHOIPJGB AEMNOGNEBOJ_get_m_intParam DGKDBOAMNBB_set_m_intParam

	//// RVA: 0x1B40E54 Offset: 0x1B40E54 VA: 0x1B40E54
	public string EFEGBHACJAL_GetStringParam(string _LJNAKDMILMC_key, string _KKMJBMKHGNH_noval)
	{
		if(FJOEBCMGDMI_m_stringParam.ContainsKey(_LJNAKDMILMC_key))
			return FJOEBCMGDMI_m_stringParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
		return _KKMJBMKHGNH_noval;
	}

	//// RVA: 0x1B40F38 Offset: 0x1B40F38 VA: 0x1B40F38
	public int LPJLEHAJADA_GetIntParam(string _LJNAKDMILMC_key, int _KKMJBMKHGNH_noval)
	{
		if(OHJFBLFELNK_m_intParam.ContainsKey(_LJNAKDMILMC_key))
			return OHJFBLFELNK_m_intParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
		return _KKMJBMKHGNH_noval;
	}

	//// RVA: 0x1B4101C Offset: 0x1B4101C VA: 0x1B4101C
	public List<AODDNOGBFLP> DAAHEOIEJFL(long _JHNMKKNEENE_Time)
	{
		List<AODDNOGBFLP> res = new List<AODDNOGBFLP>();
		for(int i = 1; i != 9; i++)
		{
			AODDNOGBFLP d = new AODDNOGBFLP();
			d.PPFNGGCBJKC_id = i;
			d.FDBNFFNFOND_close_at = 0;
			d.GNOFNIOLPPC_ImgId = 0;
			d.BOJCOPAALNC_EventId = 0;
			d.LPDLBACJKIB_TransId = 0;
			d.PDBPFJJCADD_open_at = 0;
			d.IJEKNCDIIAE_mver = 0;
			d.MGLJCOMOGLO_BtnId = 0;
			d.PLALNIIBLOF_en = 0;
			res.Add(d);
		}
		for(int i = 0; i < MCDIFBBJPMJ.Count; i++)
		{
			if(MCDIFBBJPMJ[i].PLALNIIBLOF_en == 2 && _JHNMKKNEENE_Time >= MCDIFBBJPMJ[i].PDBPFJJCADD_open_at && 
				MCDIFBBJPMJ[i].FDBNFFNFOND_close_at >= _JHNMKKNEENE_Time && MCDIFBBJPMJ[i].MGLJCOMOGLO_BtnId - 1 < 8)
			{
				int idx = MCDIFBBJPMJ[i].MGLJCOMOGLO_BtnId - 1;
				if(res[idx].FDBNFFNFOND_close_at != 0 && _JHNMKKNEENE_Time < res[idx].FDBNFFNFOND_close_at)
					continue;
				if(res[idx].PDBPFJJCADD_open_at != 0 && _JHNMKKNEENE_Time <= res[idx].PDBPFJJCADD_open_at)
					continue;
				res[idx].ODDIHGPONFL_Copy(MCDIFBBJPMJ[i]);
			}
		}
		for(int i = 0; i < res.Count; i++)
		{
			if(res[i].PNDEAHGLJIC_BtnType == 0)
			{
				res.RemoveAt(i);
				i--; // UMO fix add
			}
		}
		res.Sort((AODDNOGBFLP _HKICMNAACDA_a, AODDNOGBFLP _BNKHBCBJBKI_b) =>
		{
			//0x1B46890
			return _HKICMNAACDA_a.MGLJCOMOGLO_BtnId.CompareTo(_BNKHBCBJBKI_b.MGLJCOMOGLO_BtnId);
		});
		return res;
	}

	//// RVA: 0x1B4171C Offset: 0x1B4171C VA: 0x1B4171C
	//public OEIJEFBBJBD_EventSp.LJAJKDHLGAJ MLFMHEIEGDM(long _JHNMKKNEENE_Time) { }

	//// RVA: 0x1B41824 Offset: 0x1B41824 VA: 0x1B41824
	//public OEIJEFBBJBD_EventSp.CLNIPEPHJKO CLLEBDBKJNJ(long _JHNMKKNEENE_Time) { }

	//// RVA: 0x1B4192C Offset: 0x1B4192C VA: 0x1B4192C
	//public OEIJEFBBJBD_EventSp.HNLLDDLBJKG LJPEPPCMFKG(long _JHNMKKNEENE_Time) { }

	//// RVA: 0x1B41A34 Offset: 0x1B41A34 VA: 0x1B41A34
	//public OEIJEFBBJBD_EventSp.LFKNBOOKCCG NLCHJAGOIME(long _JHNMKKNEENE_Time) { }

	//// RVA: 0x1B41B3C Offset: 0x1B41B3C VA: 0x1B41B3C
	//public OEIJEFBBJBD_EventSp.CKHKIMCMLAH LMOEJHIBJJO(long _JHNMKKNEENE_Time) { }

	//// RVA: 0x1B41C44 Offset: 0x1B41C44 VA: 0x1B41C44
	//public OEIJEFBBJBD_EventSp.GFKDEIKPFNF ALMKFHACMHA(long _JHNMKKNEENE_Time) { }

	// RVA: 0x1B41D4C Offset: 0x1B41D4C VA: 0x1B41D4C
	public OEIJEFBBJBD_EventSp()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		OHJFBLFELNK_m_intParam = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI_m_stringParam = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		LMHMIIKCGPE = 42;
	}

	// RVA: 0x1B4227C Offset: 0x1B4227C VA: 0x1B4227C Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		NGHKJOEDLIP_Settings.LHPDDGIJKNB_Reset();
		MCDIFBBJPMJ.Clear();
		EOKILLGMGDL.Clear();
		MODIJHPMHGJ.Clear();
		OAIHCOFBEIE.Clear();
		AIJIJLFKNOM.Clear();
		ALGFDOBECLI.Clear();
		FDGNDLBDJFH.Clear();
		LMLMPLLNEDG.Clear();
		JIEIOFMJEBI.Clear();
		NNMPGOAGEOL_quests.Clear();
		OHJFBLFELNK_m_intParam.Clear();
		FJOEBCMGDMI_m_stringParam.Clear();
		ODACAJBCJHO.Clear();
		CDPGPHGBNOA.Clear();
		OBILMOEOOFE.Clear();
		GGEHACFPNPN.Clear();
		GMJFGPNMMBD.Clear();
		PBBAKFCFGKN.Clear();
		MEEIEAMCKFB.Clear();
	}

	// RVA: 0x1B426F8 Offset: 0x1B426F8 VA: 0x1B426F8 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		ANCFFLNKINL data = ANCFFLNKINL.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		DGKKMKLCEDF_DeserializeSetting(data);
		DFDAELHIMCD(data);
		PPJBMHNFELH(data);
		KNDCHLENAID(data);
		ECFLKOHOOJH(data);
		PKCHGPBNKGB(data);
		AOJMDNPFMNK(data);
		FPGOCMDABHL(data);
		NKDAMIOJODL(data);
		CFOFJPLEDEA(data);
		ONEMBBMAJEB(data);
		IHOLPCEPAMC(data);
		BHLGBIIHGAO(data);
		GFILKJLBHOE(data);
		BBBNBLEMHLK(data);
		OICPMKOFALK(data);
		FFEEOHDNGKE(data);
		BOABEPAHOHN(data);
		for(int i = 0; i < data.BHGDNGHDDAC.Length; i++)
		{
			CEBFFLDKAEC_SecureInt d = new CEBFFLDKAEC_SecureInt();
			d.DNJEJEANJGL_Value = data.BHGDNGHDDAC[i].JBGEEPFKIGG_val;
			OHJFBLFELNK_m_intParam.Add(data.BHGDNGHDDAC[i].LJNAKDMILMC_key, d);
		}
		for(int i = 0; i < data.MHGMDJNOLMI.Length; i++)
		{
			NNJFKLBPBNK_SecureString d = new NNJFKLBPBNK_SecureString();
			d.DNJEJEANJGL_Value = data.MHGMDJNOLMI[i].JBGEEPFKIGG_val;
			FJOEBCMGDMI_m_stringParam.Add(data.MHGMDJNOLMI[i].LJNAKDMILMC_key, d);
		}
		JHMBHHPDPKN_SubEventIds = new List<int>();
		for(int i = 0; i < ALGFDOBECLI.Count; i++)
		{
			if(ALGFDOBECLI[i].PLALNIIBLOF_en == 2)
			{
				JHMBHHPDPKN_SubEventIds.Add(ALGFDOBECLI[i].DNJLJMKKDNA_EventId);
			}
		}
		UnityEngine.Debug.LogError(NGHKJOEDLIP_Settings.OPFGFINHFCE_name+" "+NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId);

		if(!RuntimeSettings.CurrentSettings.LoadRawDatabase)
		{
			// Update dates
			UMOEventList.EventData CurrenEvent = UMOEventList.GetCurrentEvent();
			if (CurrenEvent != null && CurrenEvent.EnableBlock(JIKKNHIAEKG_BlockName))
			{
				System.DateTime date = Utility.GetLocalDateTime(Utility.GetCurrentUnixTime());
				System.DateTime date2 = Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart);
				date = date.AddDays(-1);
				long offset = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, date2.Hour, date2.Minute, date2.Second) - NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
				UnityEngine.Debug.LogError(Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart).ToLongDateString()+" "+Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd).ToLongDateString());
				if (NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart != 0) NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart += offset;
				if (NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd != 0) NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd += offset;
				if (NGHKJOEDLIP_Settings.BCPHKGGOEKA != 0) NGHKJOEDLIP_Settings.BCPHKGGOEKA += offset;
				if (NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 != 0) NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 += offset;
				if (NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart != 0) NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart += offset;
				if (NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd != 0) NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd += offset;
				if (NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 != 0) NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 += offset;
				if (NGHKJOEDLIP_Settings.OHGDNJLFDFF_Start != 0) NGHKJOEDLIP_Settings.OHGDNJLFDFF_Start += offset;
				if (NGHKJOEDLIP_Settings.PHKLJGNMFBL_End != 0) NGHKJOEDLIP_Settings.PHKLJGNMFBL_End += offset;

				for(int i = 0; i < MCDIFBBJPMJ.Count; i++)
				{
					if(MCDIFBBJPMJ[i].MGLJCOMOGLO_BtnId == 5 && MCDIFBBJPMJ[i].PNDEAHGLJIC_BtnType != 3)
						continue;
					if(MCDIFBBJPMJ[i].MGLJCOMOGLO_BtnId == 4 && MCDIFBBJPMJ[i].PNDEAHGLJIC_BtnType != 18)
						continue;
					if (MCDIFBBJPMJ[i].PDBPFJJCADD_open_at != 0) MCDIFBBJPMJ[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
					if (MCDIFBBJPMJ[i].FDBNFFNFOND_close_at != 0) MCDIFBBJPMJ[i].FDBNFFNFOND_close_at = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
				}
				for(int i = 0; i < EOKILLGMGDL.Count; i++)
				{
					UnityEngine.Debug.LogError(EOKILLGMGDL[i].BDEOMEBFDFF_gacha_id+" "+Utility.GetLocalDateTime(EOKILLGMGDL[i].PDBPFJJCADD_open_at).ToLongDateString()+" "+Utility.GetLocalDateTime(EOKILLGMGDL[i].FDBNFFNFOND_close_at).ToLongDateString());
					if(UMOEventList.IsEventEnabled(EOKILLGMGDL[i].BDEOMEBFDFF_gacha_id))
					{
						if (EOKILLGMGDL[i].PDBPFJJCADD_open_at != 0) EOKILLGMGDL[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
						if (EOKILLGMGDL[i].FDBNFFNFOND_close_at != 0) EOKILLGMGDL[i].FDBNFFNFOND_close_at = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
					}
				}
				for(int i = 0; i < MODIJHPMHGJ.Count; i++)
				{
					UnityEngine.Debug.LogError(MODIJHPMHGJ[i].BDEOMEBFDFF_gacha_id+" "+Utility.GetLocalDateTime(MODIJHPMHGJ[i].PDBPFJJCADD_open_at).ToLongDateString()+" "+Utility.GetLocalDateTime(MODIJHPMHGJ[i].FDBNFFNFOND_close_at).ToLongDateString());
					if (MODIJHPMHGJ[i].PDBPFJJCADD_open_at != 0) MODIJHPMHGJ[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
					if (MODIJHPMHGJ[i].FDBNFFNFOND_close_at != 0) MODIJHPMHGJ[i].FDBNFFNFOND_close_at = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
				}
				for(int i = 0; i < OAIHCOFBEIE.Count; i++)
				{
					UnityEngine.Debug.LogError(OAIHCOFBEIE[i].BDEOMEBFDFF_gacha_id+" "+Utility.GetLocalDateTime(OAIHCOFBEIE[i].PDBPFJJCADD_open_at).ToLongDateString()+" "+Utility.GetLocalDateTime(OAIHCOFBEIE[i].FDBNFFNFOND_close_at).ToLongDateString());
					if (OAIHCOFBEIE[i].PDBPFJJCADD_open_at != 0) OAIHCOFBEIE[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
					if (OAIHCOFBEIE[i].FDBNFFNFOND_close_at != 0) OAIHCOFBEIE[i].FDBNFFNFOND_close_at = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
				}
				for(int i = 0; i < AIJIJLFKNOM.Count; i++)
				{
					UnityEngine.Debug.LogError(AIJIJLFKNOM[i].BDEOMEBFDFF_gacha_id+" "+Utility.GetLocalDateTime(AIJIJLFKNOM[i].PDBPFJJCADD_open_at).ToLongDateString()+" "+Utility.GetLocalDateTime(AIJIJLFKNOM[i].FDBNFFNFOND_close_at).ToLongDateString());
					if (AIJIJLFKNOM[i].PDBPFJJCADD_open_at != 0) AIJIJLFKNOM[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
					if (AIJIJLFKNOM[i].FDBNFFNFOND_close_at != 0) AIJIJLFKNOM[i].FDBNFFNFOND_close_at = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
				}
				for(int i = 0; i < ALGFDOBECLI.Count; i++)
				{
					UnityEngine.Debug.LogError(ALGFDOBECLI[i].DNJLJMKKDNA_EventId+" "+Utility.GetLocalDateTime(ALGFDOBECLI[i].PDBPFJJCADD_open_at).ToLongDateString()+" "+Utility.GetLocalDateTime(ALGFDOBECLI[i].FDBNFFNFOND_close_at).ToLongDateString());
					if(UMOEventList.IsEventEnabled(ALGFDOBECLI[i].DNJLJMKKDNA_EventId))
					{
						if (ALGFDOBECLI[i].PDBPFJJCADD_open_at != 0) ALGFDOBECLI[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
						if (ALGFDOBECLI[i].FDBNFFNFOND_close_at != 0) ALGFDOBECLI[i].FDBNFFNFOND_close_at = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
					}
				}
				for(int i = 0; i < FDGNDLBDJFH.Count; i++)
				{
					if (FDGNDLBDJFH[i].PDBPFJJCADD_open_at != 0) FDGNDLBDJFH[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
					if (FDGNDLBDJFH[i].FDBNFFNFOND_close_at != 0) FDGNDLBDJFH[i].FDBNFFNFOND_close_at = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
				}
				for(int i = 0; i < LMLMPLLNEDG.Count; i++)
				{
					if (LMLMPLLNEDG[i].PDBPFJJCADD_open_at != 0) LMLMPLLNEDG[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
					if (LMLMPLLNEDG[i].FDBNFFNFOND_close_at != 0) LMLMPLLNEDG[i].FDBNFFNFOND_close_at = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
				}
				for(int i = 0; i < JIEIOFMJEBI.Count; i++)
				{
					if (JIEIOFMJEBI[i].PDBPFJJCADD_open_at != 0) JIEIOFMJEBI[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
				}
				for(int i = 0; i < ODACAJBCJHO.Count; i++)
				{
					if (ODACAJBCJHO[i].PDBPFJJCADD_open_at != 0) ODACAJBCJHO[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
					if (ODACAJBCJHO[i].FDBNFFNFOND_close_at != 0) ODACAJBCJHO[i].FDBNFFNFOND_close_at = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
				}
				for(int i = 0; i < CDPGPHGBNOA.Count; i++)
				{
					if (CDPGPHGBNOA[i].PDBPFJJCADD_open_at != 0) CDPGPHGBNOA[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
					if (CDPGPHGBNOA[i].FDBNFFNFOND_close_at != 0) CDPGPHGBNOA[i].FDBNFFNFOND_close_at = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
				}
				for(int i = 0; i < OBILMOEOOFE.Count; i++)
				{
					if (OBILMOEOOFE[i].PDBPFJJCADD_open_at != 0) OBILMOEOOFE[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
					if (OBILMOEOOFE[i].FDBNFFNFOND_close_at != 0) OBILMOEOOFE[i].FDBNFFNFOND_close_at = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
				}
				for(int i = 0; i < GGEHACFPNPN.Count; i++)
				{
					if (GGEHACFPNPN[i].PDBPFJJCADD_open_at != 0) GGEHACFPNPN[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
					if (GGEHACFPNPN[i].FDBNFFNFOND_close_at != 0) GGEHACFPNPN[i].FDBNFFNFOND_close_at = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
				}
				for(int i = 0; i < GMJFGPNMMBD.Count; i++)
				{
					if (GMJFGPNMMBD[i].PDBPFJJCADD_open_at != 0) GMJFGPNMMBD[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
					if (GMJFGPNMMBD[i].FDBNFFNFOND_close_at != 0) GMJFGPNMMBD[i].FDBNFFNFOND_close_at = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
				}
				for(int i = 0; i < PBBAKFCFGKN.Count; i++)
				{
					UnityEngine.Debug.LogError(PBBAKFCFGKN[i].DNJLJMKKDNA_EventId+" "+Utility.GetLocalDateTime(PBBAKFCFGKN[i].PDBPFJJCADD_open_at).ToLongDateString()+" "+Utility.GetLocalDateTime(PBBAKFCFGKN[i].FDBNFFNFOND_close_at).ToLongDateString());
					if(UMOEventList.IsEventEnabled(PBBAKFCFGKN[i].DNJLJMKKDNA_EventId))
					{
						if (PBBAKFCFGKN[i].PDBPFJJCADD_open_at != 0) PBBAKFCFGKN[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
						if (PBBAKFCFGKN[i].FDBNFFNFOND_close_at != 0) PBBAKFCFGKN[i].FDBNFFNFOND_close_at = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
					}
				}
				for(int i = 0; i < MEEIEAMCKFB.Count; i++)
				{
					UnityEngine.Debug.LogError(MEEIEAMCKFB[i].DNJLJMKKDNA_EventId+" "+Utility.GetLocalDateTime(MEEIEAMCKFB[i].PDBPFJJCADD_open_at).ToLongDateString()+" "+Utility.GetLocalDateTime(MEEIEAMCKFB[i].FDBNFFNFOND_close_at).ToLongDateString());
					if(UMOEventList.IsEventEnabled(MEEIEAMCKFB[i].DNJLJMKKDNA_EventId))
					{
						if (MEEIEAMCKFB[i].PDBPFJJCADD_open_at != 0) MEEIEAMCKFB[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
						if (MEEIEAMCKFB[i].FDBNFFNFOND_close_at != 0) MEEIEAMCKFB[i].FDBNFFNFOND_close_at = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
					}
				}
				for(int i = 0; i < NNMPGOAGEOL_quests.Count; i++)
				{
					if (NNMPGOAGEOL_quests[i].KJBGCLPMLCG_OpenedAt != 0) NNMPGOAGEOL_quests[i].KJBGCLPMLCG_OpenedAt = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
					if (NNMPGOAGEOL_quests[i].GJFPFFBAKGK_CloseAt != 0) NNMPGOAGEOL_quests[i].GJFPFFBAKGK_CloseAt = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
				}
			}
		}
		return true;
	}

	// RVA: 0x1B4573C Offset: 0x1B4573C VA: 0x1B4573C Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		//NGHKJOEDLIP_Settings = setting
		//MCDIFBBJPMJ? = page_btn
		//MODIJHPMHGJ? = revival_gacha
		//OAIHCOFBEIE? = ticket_gacha
		//AIJIJLFKNOM? = free10_gacha
		//ALGFDOBECLI? = child_events
		//FDGNDLBDJFH? = portal_bg
		//LMLMPLLNEDG? = stone_sale
		//NNMPGOAGEOL_quests = quests
		//JIEIOFMJEBI? = daily_adv
		//ODACAJBCJHO? = help_table
		//CDPGPHGBNOA? = campaign
		//OBILMOEOOFE? = next_events
		//GGEHACFPNPN? = weekly_events
		//GMJFGPNMMBD? = vop_campaign
		//PBBAKFCFGKN? = bonus_mission
		//MEEIEAMCKFB? = stepup_mission
		TodoLogger.LogError(TodoLogger.DbJson, "OEIJEFBBJBD_EventSp.IIEMACPEEBJ_Deserialize");
		return true;
	}

	//// RVA: 0x1B42B94 Offset: 0x1B42B94 VA: 0x1B42B94
	private bool DGKKMKLCEDF_DeserializeSetting(ANCFFLNKINL POFOEPAHMPI)
	{
		NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId = (int)POFOEPAHMPI.HMBHNLCFDIH.OBGBAOLONDD_UniqueId;
		NGHKJOEDLIP_Settings.OPFGFINHFCE_name = POFOEPAHMPI.HMBHNLCFDIH.OPFGFINHFCE_name;
		NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api = POFOEPAHMPI.HMBHNLCFDIH.OCGFKMHNEOF_name_for_api;
		NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart = POFOEPAHMPI.HMBHNLCFDIH.BONDDBOFBND_RankingStart;
		NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd = POFOEPAHMPI.HMBHNLCFDIH.HPNOGLIFJOP_RankingEnd;
		NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 = POFOEPAHMPI.HMBHNLCFDIH.LNFKGHNHJKE_RankingEnd2;
		NGHKJOEDLIP_Settings.BCPHKGGOEKA = POFOEPAHMPI.HMBHNLCFDIH.BCPHKGGOEKA;
		NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart = POFOEPAHMPI.HMBHNLCFDIH.JGMDAOACOJF_RewardStart;
		NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd = POFOEPAHMPI.HMBHNLCFDIH.IDDBFFBPNGI_RewardEnd;
		NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 = POFOEPAHMPI.HMBHNLCFDIH.KNLGKBBIBOH_RewardEnd2;
		NGHKJOEDLIP_Settings.POGEFBMBPCB_MonthOdd = (sbyte)POFOEPAHMPI.HMBHNLCFDIH.JMJDLDEIFKE;
		NGHKJOEDLIP_Settings.AHKNMANFILO_DayGroup = (sbyte)POFOEPAHMPI.HMBHNLCFDIH.AHKNMANFILO_DayGroup;
		NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx = (sbyte)POFOEPAHMPI.HMBHNLCFDIH.MOEKELIIDEO_SaveIdx;
		NGHKJOEDLIP_Settings.OCDMGOGMHGE_KeyPrefix = POFOEPAHMPI.HMBHNLCFDIH.OCDMGOGMHGE_KeyPrefix;
		NGHKJOEDLIP_Settings.PJBILOFOCIC = POFOEPAHMPI.HMBHNLCFDIH.PJBILOFOCIC;
		NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type = POFOEPAHMPI.HMBHNLCFDIH.MJBKGOJBPAD_item_type;
		NGHKJOEDLIP_Settings.FEMMDNIELFC_Desc = POFOEPAHMPI.HMBHNLCFDIH.FEMMDNIELFC_Desc;
		NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport = (sbyte)POFOEPAHMPI.HMBHNLCFDIH.HKKNEAGCIEB_RankingSupport;
		NGHKJOEDLIP_Settings.HIOOGLEJBKM_StartAdventureId = POFOEPAHMPI.HMBHNLCFDIH.HIOOGLEJBKM_StartAdventureId;
		NGHKJOEDLIP_Settings.FJCADCDNPMP_EndAdventureId = POFOEPAHMPI.HMBHNLCFDIH.FJCADCDNPMP_EndAdventureId;
		NGHKJOEDLIP_Settings.OMCAOJJGOGG_Lb = POFOEPAHMPI.HMBHNLCFDIH.OMCAOJJGOGG_Lb;
		NGHKJOEDLIP_Settings.OHGDNJLFDFF_Start = POFOEPAHMPI.HMBHNLCFDIH.OHGDNJLFDFF_Start;
		NGHKJOEDLIP_Settings.PHKLJGNMFBL_End = POFOEPAHMPI.HMBHNLCFDIH.PHKLJGNMFBL_End;
		return true;
	}

	//// RVA: 0x1B45BBC Offset: 0x1B45BBC VA: 0x1B45BBC
	//private bool DGKKMKLCEDF_DeserializeSetting(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x1B45CAC Offset: 0x1B45CAC VA: 0x1B45CAC
	//private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, EDOHBJAPLPF_JsonData OBHAFLMHAKG, string _OPFGFINHFCE_name, ref bool _NGJDHLGMHMH_IsInvalid) { }

	//// RVA: 0x1B45E8C Offset: 0x1B45E8C VA: 0x1B45E8C
	//private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, string OAIBJJHGCNM) { }

	//// RVA: 0x1B43128 Offset: 0x1B43128 VA: 0x1B43128
	private bool DFDAELHIMCD(ANCFFLNKINL POFOEPAHMPI)
	{
		for(int i = 0; i < POFOEPAHMPI.OPIDLGADBPE.Length; i++)
		{
			AODDNOGBFLP d = new AODDNOGBFLP();
			d.PPFNGGCBJKC_id = (int)POFOEPAHMPI.OPIDLGADBPE[i].PPFNGGCBJKC_id;
			d.IJEKNCDIIAE_mver = POFOEPAHMPI.OPIDLGADBPE[i].IJEKNCDIIAE_mver;
			d.PLALNIIBLOF_en = (int)POFOEPAHMPI.OPIDLGADBPE[i].PLALNIIBLOF_en;
			d.MGLJCOMOGLO_BtnId = (int)POFOEPAHMPI.OPIDLGADBPE[i].MGLJCOMOGLO_BtnId;
			d.PNDEAHGLJIC_BtnType = (int)POFOEPAHMPI.OPIDLGADBPE[i].PNDEAHGLJIC_BtnType;
			d.LPDLBACJKIB_TransId = POFOEPAHMPI.OPIDLGADBPE[i].LPDLBACJKIB_TransId;
			d.PDBPFJJCADD_open_at = POFOEPAHMPI.OPIDLGADBPE[i].PDBPFJJCADD_open_at;
			d.FDBNFFNFOND_close_at = POFOEPAHMPI.OPIDLGADBPE[i].FDBNFFNFOND_close_at;
			d.GNOFNIOLPPC_ImgId = (int)POFOEPAHMPI.OPIDLGADBPE[i].GNOFNIOLPPC_ImgId;
			d.BOJCOPAALNC_EventId = (int)POFOEPAHMPI.OPIDLGADBPE[i].BOJCOPAALNC_EventId;
			MCDIFBBJPMJ.Add(d);
		}
		return true;
	}

	//// RVA: 0x1B45BC4 Offset: 0x1B45BC4 VA: 0x1B45BC4
	//private bool DFDAELHIMCD(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x1B43424 Offset: 0x1B43424 VA: 0x1B43424
	private bool PPJBMHNFELH(ANCFFLNKINL POFOEPAHMPI)
	{
		for(int i = 0; i < POFOEPAHMPI.AFMPLCMMPHO.Length; i++)
		{
			NJJEAKMBGPN d = new NJJEAKMBGPN();
			d.PPFNGGCBJKC_id = (int)POFOEPAHMPI.AFMPLCMMPHO[i].PPFNGGCBJKC_id;
			d.PLALNIIBLOF_en = (int)POFOEPAHMPI.AFMPLCMMPHO[i].PLALNIIBLOF_en;
			d.BDEOMEBFDFF_gacha_id = (int)POFOEPAHMPI.AFMPLCMMPHO[i].BDEOMEBFDFF_gacha_id;
			d.PDBPFJJCADD_open_at = POFOEPAHMPI.AFMPLCMMPHO[i].PDBPFJJCADD_open_at;
			d.FDBNFFNFOND_close_at = POFOEPAHMPI.AFMPLCMMPHO[i].FDBNFFNFOND_close_at;
			EOKILLGMGDL.Add(d);
		}
		return true;
	}

	//// RVA: 0x1B43650 Offset: 0x1B43650 VA: 0x1B43650
	private bool KNDCHLENAID(ANCFFLNKINL POFOEPAHMPI)
	{
		for(int i = 0; i < POFOEPAHMPI.IEMKMPDAJCM.Length; i++)
		{
			NJJEAKMBGPN d = new NJJEAKMBGPN();
			d.PPFNGGCBJKC_id = (int)POFOEPAHMPI.IEMKMPDAJCM[i].PPFNGGCBJKC_id;
			d.PLALNIIBLOF_en = (int)POFOEPAHMPI.IEMKMPDAJCM[i].PLALNIIBLOF_en;
			d.BDEOMEBFDFF_gacha_id = (int)POFOEPAHMPI.IEMKMPDAJCM[i].BDEOMEBFDFF_gacha_id;
			d.PDBPFJJCADD_open_at = POFOEPAHMPI.IEMKMPDAJCM[i].PDBPFJJCADD_open_at;
			d.FDBNFFNFOND_close_at = POFOEPAHMPI.IEMKMPDAJCM[i].FDBNFFNFOND_close_at;
			MODIJHPMHGJ.Add(d);
		}
		return true;
	}

	//// RVA: 0x1B45BCC Offset: 0x1B45BCC VA: 0x1B45BCC
	//private bool KNDCHLENAID(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x1B4387C Offset: 0x1B4387C VA: 0x1B4387C
	private bool ECFLKOHOOJH(ANCFFLNKINL POFOEPAHMPI)
	{
		for(int i = 0; i < POFOEPAHMPI.OCCJOGGPJIB.Length; i++)
		{
			NJJEAKMBGPN d = new NJJEAKMBGPN();
			d.PPFNGGCBJKC_id = (int)POFOEPAHMPI.OCCJOGGPJIB[i].PPFNGGCBJKC_id;
			d.PLALNIIBLOF_en = (int)POFOEPAHMPI.OCCJOGGPJIB[i].PLALNIIBLOF_en;
			d.BDEOMEBFDFF_gacha_id = (int)POFOEPAHMPI.OCCJOGGPJIB[i].BDEOMEBFDFF_gacha_id;
			d.PDBPFJJCADD_open_at = POFOEPAHMPI.OCCJOGGPJIB[i].PDBPFJJCADD_open_at;
			d.FDBNFFNFOND_close_at = POFOEPAHMPI.OCCJOGGPJIB[i].FDBNFFNFOND_close_at;
			OAIHCOFBEIE.Add(d);
		}
		return true;
	}

	//// RVA: 0x1B45BD4 Offset: 0x1B45BD4 VA: 0x1B45BD4
	//private bool ECFLKOHOOJH(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x1B43AA8 Offset: 0x1B43AA8 VA: 0x1B43AA8
	private bool PKCHGPBNKGB(ANCFFLNKINL POFOEPAHMPI)
	{
		for(int i = 0; i < POFOEPAHMPI.OMLANIGCHDA.Length; i++)
		{
			NJJEAKMBGPN d = new NJJEAKMBGPN();
			d.PPFNGGCBJKC_id = (int)POFOEPAHMPI.OMLANIGCHDA[i].PPFNGGCBJKC_id;
			d.PLALNIIBLOF_en = (int)POFOEPAHMPI.OMLANIGCHDA[i].PLALNIIBLOF_en;
			d.BDEOMEBFDFF_gacha_id = (int)POFOEPAHMPI.OMLANIGCHDA[i].BDEOMEBFDFF_gacha_id;
			d.PDBPFJJCADD_open_at = POFOEPAHMPI.OMLANIGCHDA[i].PDBPFJJCADD_open_at;
			d.FDBNFFNFOND_close_at = POFOEPAHMPI.OMLANIGCHDA[i].FDBNFFNFOND_close_at;
			AIJIJLFKNOM.Add(d);
		}
		return true;
	}

	//// RVA: 0x1B45BDC Offset: 0x1B45BDC VA: 0x1B45BDC
	//private bool PKCHGPBNKGB(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x1B43CD4 Offset: 0x1B43CD4 VA: 0x1B43CD4
	private bool AOJMDNPFMNK(ANCFFLNKINL POFOEPAHMPI)
	{
		for(int i = 0; i < POFOEPAHMPI.MHCBBBFJALG.Length; i++)
		{
			PHIMHBPOMAD d = new PHIMHBPOMAD();
			d.PPFNGGCBJKC_id = (int)POFOEPAHMPI.MHCBBBFJALG[i].PPFNGGCBJKC_id;
			d.PLALNIIBLOF_en = (int)POFOEPAHMPI.MHCBBBFJALG[i].PLALNIIBLOF_en;
			d.DNJLJMKKDNA_EventId = (int)POFOEPAHMPI.MHCBBBFJALG[i].DNJLJMKKDNA_EventId;
			d.PDBPFJJCADD_open_at = POFOEPAHMPI.MHCBBBFJALG[i].PDBPFJJCADD_open_at;
			d.FDBNFFNFOND_close_at = POFOEPAHMPI.MHCBBBFJALG[i].FDBNFFNFOND_close_at;
			ALGFDOBECLI.Add(d);
		}
		return true;
	}

	//// RVA: 0x1B45BE4 Offset: 0x1B45BE4 VA: 0x1B45BE4
	//private bool AOJMDNPFMNK(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x1B43F00 Offset: 0x1B43F00 VA: 0x1B43F00
	private bool FPGOCMDABHL(ANCFFLNKINL POFOEPAHMPI)
	{
		for(int i = 0; i < POFOEPAHMPI.KKENLPIJOBN.Length; i++)
		{
			AOOLGJIFOEI d = new AOOLGJIFOEI();
			d.PPFNGGCBJKC_id = (int)POFOEPAHMPI.KKENLPIJOBN[i].PPFNGGCBJKC_id;
			d.PLALNIIBLOF_en = (int)POFOEPAHMPI.KKENLPIJOBN[i].PLALNIIBLOF_en;
			d.OENPCNBFPDA_bg_id = (int)POFOEPAHMPI.KKENLPIJOBN[i].OENPCNBFPDA_bg_id;
			d.KGICDMIJGDF_Group = (int)POFOEPAHMPI.KKENLPIJOBN[i].KGICDMIJGDF_Group;
			d.PDBPFJJCADD_open_at = POFOEPAHMPI.KKENLPIJOBN[i].PDBPFJJCADD_open_at;
			d.FDBNFFNFOND_close_at = POFOEPAHMPI.KKENLPIJOBN[i].FDBNFFNFOND_close_at;
			FDGNDLBDJFH.Add(d);
		}
		return true;
	}

	//// RVA: 0x1B45BEC Offset: 0x1B45BEC VA: 0x1B45BEC
	//private bool FPGOCMDABHL(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x1B44154 Offset: 0x1B44154 VA: 0x1B44154
	private bool NKDAMIOJODL(ANCFFLNKINL POFOEPAHMPI)
	{
		for(int i = 0; i < POFOEPAHMPI.BPFJNIGNLEJ.Length; i++)
		{
			BPNLIPDNKOH d = new BPNLIPDNKOH();
			d.PPFNGGCBJKC_id = (int)POFOEPAHMPI.BPFJNIGNLEJ[i].PPFNGGCBJKC_id;
			d.PLALNIIBLOF_en = (int)POFOEPAHMPI.BPFJNIGNLEJ[i].PLALNIIBLOF_en;
			d.ALMEBFDEGBG = POFOEPAHMPI.BPFJNIGNLEJ[i].ALMEBFDEGBG;
			d.PDBPFJJCADD_open_at = POFOEPAHMPI.BPFJNIGNLEJ[i].PDBPFJJCADD_open_at;
			d.FDBNFFNFOND_close_at = POFOEPAHMPI.BPFJNIGNLEJ[i].FDBNFFNFOND_close_at;
			LMLMPLLNEDG.Add(d);
		}
		return true;
	}

	//// RVA: 0x1B45BF4 Offset: 0x1B45BF4 VA: 0x1B45BF4
	//private bool NKDAMIOJODL(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x1B44380 Offset: 0x1B44380 VA: 0x1B44380
	private bool CFOFJPLEDEA(ANCFFLNKINL POFOEPAHMPI)
	{
		int xor = (int)Utility.GetCurrentUnixTime() * 11 + 1;
		for(int i = 0; i < POFOEPAHMPI.MDDOGIAFDEI.Length; i++)
		{
			AKIIJBEJOEP d = new AKIIJBEJOEP();
			d.KHEKNNFCAOI_Init(JIKKNHIAEKG_BlockName, i + 1, xor, POFOEPAHMPI);
			NNMPGOAGEOL_quests.Add(d);
			xor += 0xd;
		}
		return true;
	}

	//// RVA: 0x1B45BFC Offset: 0x1B45BFC VA: 0x1B45BFC
	//private bool CFOFJPLEDEA(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x1B44518 Offset: 0x1B44518 VA: 0x1B44518
	private bool ONEMBBMAJEB(ANCFFLNKINL POFOEPAHMPI)
	{
		for(int i = 0; i < POFOEPAHMPI.HHIGONDIHDF.Length; i++)
		{
			MFEJBIMLPGI d = new MFEJBIMLPGI();
			d.PPFNGGCBJKC_id = (int)POFOEPAHMPI.HHIGONDIHDF[i].PPFNGGCBJKC_id;
			d.PLALNIIBLOF_en = (int)POFOEPAHMPI.HHIGONDIHDF[i].PLALNIIBLOF_en;
			d.KDGJBBFKLGI_Chapter = (int)POFOEPAHMPI.HHIGONDIHDF[i].KDGJBBFKLGI_Chapter;
			d.OIAAFFHGBBD_AdvId = (int)POFOEPAHMPI.HHIGONDIHDF[i].OIAAFFHGBBD_AdvId;
			d.PDBPFJJCADD_open_at = POFOEPAHMPI.HHIGONDIHDF[i].PDBPFJJCADD_open_at;
			JIEIOFMJEBI.Add(d);
		}
		return true;
	}

	//// RVA: 0x1B45C04 Offset: 0x1B45C04 VA: 0x1B45C04
	//private bool ONEMBBMAJEB(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x1B44744 Offset: 0x1B44744 VA: 0x1B44744
	private bool IHOLPCEPAMC(ANCFFLNKINL POFOEPAHMPI)
	{
		ODACAJBCJHO.Clear();
		for(int i = 0; i < POFOEPAHMPI.JHJNMGPFAKA.Length; i++)
		{
			PLEKADHPGIJ d = new PLEKADHPGIJ();
			d.PPFNGGCBJKC_id = (int)POFOEPAHMPI.JHJNMGPFAKA[i].PPFNGGCBJKC_id;
			d.PLALNIIBLOF_en = (int)POFOEPAHMPI.JHJNMGPFAKA[i].PLALNIIBLOF_en;
			d.PDBPFJJCADD_open_at = POFOEPAHMPI.JHJNMGPFAKA[i].PDBPFJJCADD_open_at;
			d.FDBNFFNFOND_close_at = POFOEPAHMPI.JHJNMGPFAKA[i].FDBNFFNFOND_close_at;
			d.EJBGHLOOLBC_HelpIds = (int)POFOEPAHMPI.JHJNMGPFAKA[i].EJBGHLOOLBC_HelpIds;
			ODACAJBCJHO.Add(d);
		}
		return true;
	}

	//// RVA: 0x1B45C0C Offset: 0x1B45C0C VA: 0x1B45C0C
	//private bool IHOLPCEPAMC(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x1B449A4 Offset: 0x1B449A4 VA: 0x1B449A4
	private bool BHLGBIIHGAO(ANCFFLNKINL POFOEPAHMPI)
	{
		for(int i = 0; i < POFOEPAHMPI.DJEBGHFEOKG.Length; i++)
		{
			LJAJKDHLGAJ d = new LJAJKDHLGAJ();
			d.PPFNGGCBJKC_id = (int)POFOEPAHMPI.DJEBGHFEOKG[i].PPFNGGCBJKC_id;
			d.PLALNIIBLOF_en = (int)POFOEPAHMPI.DJEBGHFEOKG[i].PLALNIIBLOF_en;
			d.OPKCNBFBBKP_BannerId = (int)POFOEPAHMPI.DJEBGHFEOKG[i].OPKCNBFBBKP_BannerId;
			d.PDBPFJJCADD_open_at = POFOEPAHMPI.DJEBGHFEOKG[i].PDBPFJJCADD_open_at;
			d.FDBNFFNFOND_close_at = POFOEPAHMPI.DJEBGHFEOKG[i].FDBNFFNFOND_close_at;
			CDPGPHGBNOA.Add(d);
		}
		return true;
	}

	//// RVA: 0x1B45C14 Offset: 0x1B45C14 VA: 0x1B45C14
	//private bool BHLGBIIHGAO(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x1B44BC4 Offset: 0x1B44BC4 VA: 0x1B44BC4
	private bool GFILKJLBHOE(ANCFFLNKINL POFOEPAHMPI)
	{
		for(int i = 0; i < POFOEPAHMPI.BOBEIHMGCEC.Length; i++)
		{
			CLNIPEPHJKO d = new CLNIPEPHJKO();
			d.PPFNGGCBJKC_id = (int)POFOEPAHMPI.BOBEIHMGCEC[i].PPFNGGCBJKC_id;
			d.PLALNIIBLOF_en = (int)POFOEPAHMPI.BOBEIHMGCEC[i].PLALNIIBLOF_en;
			for(int j = 0; j < 4; j++)
			{
				d.OPKCNBFBBKP_BannerId[j] = (int)POFOEPAHMPI.BOBEIHMGCEC[i].OPKCNBFBBKP_BannerId[j];
				d.BEBJKJKBOGH_date[j] = (int)POFOEPAHMPI.BOBEIHMGCEC[i].BEBJKJKBOGH_date[j];
			}
			d.PDBPFJJCADD_open_at = POFOEPAHMPI.BOBEIHMGCEC[i].PDBPFJJCADD_open_at;
			d.FDBNFFNFOND_close_at = POFOEPAHMPI.BOBEIHMGCEC[i].FDBNFFNFOND_close_at;
			OBILMOEOOFE.Add(d);
		}
		return true;
	}

	//// RVA: 0x1B45C1C Offset: 0x1B45C1C VA: 0x1B45C1C
	//private bool GFILKJLBHOE(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x1B44F0C Offset: 0x1B44F0C VA: 0x1B44F0C
	private bool BBBNBLEMHLK(ANCFFLNKINL POFOEPAHMPI)
	{
		for(int i = 0; i < POFOEPAHMPI.GFKENIPCEKK.Length; i++)
		{
			HNLLDDLBJKG d = new HNLLDDLBJKG();
			d.PPFNGGCBJKC_id = (int)POFOEPAHMPI.GFKENIPCEKK[i].PPFNGGCBJKC_id;
			d.PLALNIIBLOF_en = (int)POFOEPAHMPI.GFKENIPCEKK[i].PLALNIIBLOF_en;
			d.PDBPFJJCADD_open_at = POFOEPAHMPI.GFKENIPCEKK[i].PDBPFJJCADD_open_at;
			d.FDBNFFNFOND_close_at = POFOEPAHMPI.GFKENIPCEKK[i].FDBNFFNFOND_close_at;
			GGEHACFPNPN.Add(d);
		}
		return true;
	}

	//// RVA: 0x1B45C24 Offset: 0x1B45C24 VA: 0x1B45C24
	//private bool BBBNBLEMHLK(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x1B45104 Offset: 0x1B45104 VA: 0x1B45104
	private bool OICPMKOFALK(ANCFFLNKINL POFOEPAHMPI)
	{
		for(int i = 0; i < POFOEPAHMPI.FEMIKAOHGPL.Length; i++)
		{
			LFKNBOOKCCG d = new LFKNBOOKCCG();
			d.PPFNGGCBJKC_id = (int)POFOEPAHMPI.FEMIKAOHGPL[i].PPFNGGCBJKC_id;
			d.PLALNIIBLOF_en = (int)POFOEPAHMPI.FEMIKAOHGPL[i].PLALNIIBLOF_en;
			d.PDBPFJJCADD_open_at = POFOEPAHMPI.FEMIKAOHGPL[i].PDBPFJJCADD_open_at;
			d.FDBNFFNFOND_close_at = POFOEPAHMPI.FEMIKAOHGPL[i].FDBNFFNFOND_close_at;
			GMJFGPNMMBD.Add(d);
		}
		return true;
	}

	//// RVA: 0x1B45C2C Offset: 0x1B45C2C VA: 0x1B45C2C
	//private bool OICPMKOFALK(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x1B452FC Offset: 0x1B452FC VA: 0x1B452FC
	private bool FFEEOHDNGKE(ANCFFLNKINL POFOEPAHMPI)
	{
		for(int i = 0; i < POFOEPAHMPI.PDIINOHFNGF.Length; i++)
		{
			CKHKIMCMLAH d = new CKHKIMCMLAH();
			d.PPFNGGCBJKC_id = (int)POFOEPAHMPI.PDIINOHFNGF[i].PPFNGGCBJKC_id;
			d.PLALNIIBLOF_en = (int)POFOEPAHMPI.PDIINOHFNGF[i].PLALNIIBLOF_en;
			d.DNJLJMKKDNA_EventId = (int)POFOEPAHMPI.PDIINOHFNGF[i].DNJLJMKKDNA_EventId;
			d.PDBPFJJCADD_open_at = POFOEPAHMPI.PDIINOHFNGF[i].PDBPFJJCADD_open_at;
			d.FDBNFFNFOND_close_at = POFOEPAHMPI.PDIINOHFNGF[i].FDBNFFNFOND_close_at;
			PBBAKFCFGKN.Add(d);
		}
		return true;
	}

	//// RVA: 0x1B45C34 Offset: 0x1B45C34 VA: 0x1B45C34
	//private bool FFEEOHDNGKE(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x1B4551C Offset: 0x1B4551C VA: 0x1B4551C
	private bool BOABEPAHOHN(ANCFFLNKINL POFOEPAHMPI)
	{
		for(int i = 0; i < POFOEPAHMPI.EODGIMADEGI.Length; i++)
		{
			GFKDEIKPFNF d = new GFKDEIKPFNF();
			d.PPFNGGCBJKC_id = (int)POFOEPAHMPI.EODGIMADEGI[i].PPFNGGCBJKC_id;
			d.PLALNIIBLOF_en = (int)POFOEPAHMPI.EODGIMADEGI[i].PLALNIIBLOF_en;
			d.DNJLJMKKDNA_EventId = (int)POFOEPAHMPI.EODGIMADEGI[i].DNJLJMKKDNA_EventId;
			d.PDBPFJJCADD_open_at = POFOEPAHMPI.EODGIMADEGI[i].PDBPFJJCADD_open_at;
			d.FDBNFFNFOND_close_at = POFOEPAHMPI.EODGIMADEGI[i].FDBNFFNFOND_close_at;
			MEEIEAMCKFB.Add(d);
		}
		return true;
	}

	//// RVA: 0x1B45C3C Offset: 0x1B45C3C VA: 0x1B45C3C
	//private bool BOABEPAHOHN(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	// RVA: 0x1B460F8 Offset: 0x1B460F8 VA: 0x1B460F8 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "OEIJEFBBJBD_EventSp.CAOGDCBPBAN");
		return 0;
	}
}
