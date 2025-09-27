

using System.Collections.Generic;
using UnityEngine;
using XeSys;

[System.Obsolete("Use BOKMNHAFJHF_Sns", true)]
public class BOKMNHAFJHF { }
[UMOClass(ReaderClass = "MILDDOGCGLE")]
public class BOKMNHAFJHF_Sns : DIHHCBACKGG_DbSection
{
	[UMOClass(ReaderClass = "COJBCBGIGHJ")]
	public class KEIGMAOCJHK_Talk
	{
		[UMOMember(ReaderMember = "KFCIJBLDHOK_v1")]
		public long DPIBHFNDJII_UnlockCond1; // 0x8
		[UMOMember(ReaderMember = "JLEIHOEGMOP_v2")]
		public long EKPBOLNFGJB_UnlockCond2; // 0x10
		[UMOMember(ReaderMember = "PPFNGGCBJKC_id")]
		public int AIPLIEMLHGC_SnsId; // 0x18
		[UMOMember(ReaderMember = "OKECOPNBAGP_ro")]
		public int MALFHCHNEFN_RoomId; // 0x1C
		[UMOMember(ReaderMember = "EPKOHDLIKAN_tk")]
		public int AJIDLAGFPGM_TalkId; // 0x20
		[UMOMember(ReaderMember = "ODMJFHDIGLP_cnd")]
		public sbyte JKNGNIMLDDJ_UnlockType; // 0x24
		[UMOMember(ReaderMember = "IJEKNCDIIAE_mver|PLALNIIBLOF_en", Desc = "Availabe in game if value = 2")]
		public sbyte PPEGAKEIEGM_Enabled; // 0x25
		[UMOMember(ReaderMember = "IJEKNCDIIAE_mver")]
		public ushort IJEKNCDIIAE_mver; // 0x26

		//// RVA: 0x19CEFD4 Offset: 0x19CEFD4 VA: 0x19CEFD4
		//public uint CAOGDCBPBAN() { }
	}

	[UMOClass(ReaderClass = "APLNHNOKJFK")]
	public class LEBAGJNJJNG_Room
	{
		[UMOMember(ReaderMember = "OKECOPNBAGP_ro")]
		public short MALFHCHNEFN_RoomId; // 0x8
		[UMOMember(ReaderMember = "OPFGFINHFCE_name")]
		public string OPFGFINHFCE_name; // 0xC
		public int EAHPLCJMPHD_PId; // 0x10
		[UMOMember(ReaderMember = "GBJFNGCDKPM_typ")]
		public int EEECOMPDNEJ; // 0x14
		[UMOMember(ReaderMember = "JMMEGKGCIIL")]
		public int EKANGPODCEP_EventId; // 0x18
		[UMOMember(ReaderMember = "IJEKNCDIIAE_mver|PLALNIIBLOF_en", Desc = "Availabe in game if value = 2")]
		public int PPEGAKEIEGM_Enabled; // 0x1C
		[UMOMember(ReaderMember = "PFJJFCPPNIN_nx")]
		public int PKOKDPHHLCG_Next; // 0x20

		//// RVA: 0x19CF0C0 Offset: 0x19CF0C0 VA: 0x19CF0C0
		//public uint CAOGDCBPBAN() { }
	}

	[UMOClass(ReaderClass = "EIDBDFGNCFB")]
	public class JFMDDEBLCAA_CharaInfo
	{
		[UMOMember()]
		public int IDELKEKDIFD_CharaId; // 0x8
		[UMOMember(ReaderMember = "HANMDEBPBHG_pic")]
		public int EAHPLCJMPHD_PId; // 0xC PicId
		[UMOMember(ReaderMember = "DJJNOCDIIAE")]
		public int HEHKNMCDBJJ_ColorId; // 0x10
		[UMOMember(ReaderMember = "CPKMLLNADLJ_Serie")]
		public int CPKMLLNADLJ_Serie; // 0x14
		[UMOMember(ReaderMember = "OPFGFINHFCE_name")]
		public string OPFGFINHFCE_name; // 0x18
		[UMOMember(ReaderMember = "ONOPACPKFPK_ac")]
		public string HAPAFECPFEK_AtName; // 0x1C
		[UMOMember(ReaderMember = "PLALNIIBLOF_en", Desc = "Availabe in game if value = 2, Master version is 1")]
		public sbyte PPEGAKEIEGM_Enabled; // 0x20

		//// RVA: 0x19CF01C Offset: 0x19CF01C VA: 0x19CF01C
		//public uint CAOGDCBPBAN() { }
	}

	[UMOClass(ReaderClass = "CBGIPNJOPAH")]
	public class EIJGEDBGBBI_ColorInfo
	{
		[UMOMember(ReaderMember = "PPFNGGCBJKC_id")]
		public int PPFNGGCBJKC_id; // 0x8
		[UMOMember(ReaderMember = "DOKKMMFKLJI_Color")]
		public Color DOKKMMFKLJI_Color; // 0xC

		//// RVA: 0x19CF038 Offset: 0x19CF038 VA: 0x19CF038
		//public uint CAOGDCBPBAN() { }
	}

	[UMOMember(ReaderMember = "IPCJPOGBHGP")]
	public List<KEIGMAOCJHK_Talk> CDENCMNHNGA_table { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB
	[UMOMember(ReaderMember = "BHFAMKAPFNJ")]
	public List<LEBAGJNJJNG_Room> NPKPBDIDBBG_Room { get; private set; } // 0x24 APIEOMBDJJM OJBJIECLMKI KHEKLHLKDIJ
	[UMOMember(ReaderMember = "CEPBAOMAHNH")]
	public List<JFMDDEBLCAA_CharaInfo> KHCACDIKJLG_Characters { get; private set; } // 0x28 BMCJBCFBOJG ICPBCJDBBAI HHKFEJDAHNA
	[UMOMember(ReaderMember = "ABIKKECOBIJ")]
	public List<EIJGEDBGBBI_ColorInfo> LOCEHOMKJEI_ColorConfigs { get; private set; } // 0x2C GJFNINODHJK LLFHHFNLOPC CGEAKFHLBNF

	//// RVA: 0x19CD998 Offset: 0x19CD998 VA: 0x19CD998
	//public BOKMNHAFJHF_Sns.KEIGMAOCJHK GCINIJEMHFK(int _PPFNGGCBJKC_id) { }

	// RVA: 0x19CDA60 Offset: 0x19CDA60 VA: 0x19CDA60
	public BOKMNHAFJHF_Sns()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		CDENCMNHNGA_table = new List<KEIGMAOCJHK_Talk>();
		NPKPBDIDBBG_Room = new List<LEBAGJNJJNG_Room>();
		KHCACDIKJLG_Characters = new List<JFMDDEBLCAA_CharaInfo>();
		LOCEHOMKJEI_ColorConfigs = new List<EIJGEDBGBBI_ColorInfo>();
		LMHMIIKCGPE = 76;
	}

	// RVA: 0x19CDBF4 Offset: 0x19CDBF4 VA: 0x19CDBF4 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		int val = (int)Utility.GetCurrentUnixTime();
		CDENCMNHNGA_table.Clear();
		for(int i = 0; i < 2000; i++)
		{
			KEIGMAOCJHK_Talk data = new KEIGMAOCJHK_Talk();
			data.AIPLIEMLHGC_SnsId = i + 1;
			CDENCMNHNGA_table.Add(data);
		}
		KHCACDIKJLG_Characters.Clear();
		for(int i = 0; i < 100; i++)
		{
			JFMDDEBLCAA_CharaInfo data = new JFMDDEBLCAA_CharaInfo();
			data.OPFGFINHFCE_name = "";
			data.HAPAFECPFEK_AtName = "";
			data.IDELKEKDIFD_CharaId = i + 1;
			data.EAHPLCJMPHD_PId = 1;
			data.HEHKNMCDBJJ_ColorId = 1;
			data.CPKMLLNADLJ_Serie = 0;
			KHCACDIKJLG_Characters.Add(data);
		}
	}

	// RVA: 0x19CDE7C Offset: 0x19CDE7C VA: 0x19CDE7C Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		MILDDOGCGLE parser = MILDDOGCGLE.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		if(NMJBKFBFPFG(parser))
		{
			FGOHGNBIAAP_LoadRoom(parser);
			if(LHFCGAJLMDL(parser))
			{
				NOBOFLFGLMJ(parser);
				return true;
			}
		}
		return false;
	}

	// RVA: 0x19CEA10 Offset: 0x19CEA10 VA: 0x19CEA10 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return false;
	}

	//// RVA: 0x19CDEE8 Offset: 0x19CDEE8 VA: 0x19CDEE8
	private bool NMJBKFBFPFG(MILDDOGCGLE LKDONLFHMEO)
	{
		COJBCBGIGHJ[] array = LKDONLFHMEO.IPCJPOGBHGP;
		if(array.Length <= CDENCMNHNGA_table.Count)
		{
			for(int i = 0; i < array.Length; i++)
			{
				KEIGMAOCJHK_Talk data = CDENCMNHNGA_table[i];
				data.AIPLIEMLHGC_SnsId = (int)array[i].PPFNGGCBJKC_id;
				data.DPIBHFNDJII_UnlockCond1 = array[i].KFCIJBLDHOK_v1;
				data.EKPBOLNFGJB_UnlockCond2 = array[i].JLEIHOEGMOP_v2;
				data.MALFHCHNEFN_RoomId = (int)array[i].OKECOPNBAGP_ro;
				data.JKNGNIMLDDJ_UnlockType = (sbyte)array[i].ODMJFHDIGLP_cnd;
				data.PPEGAKEIEGM_Enabled = (sbyte)JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE_mver, (int)array[i].PLALNIIBLOF_en, 0);
				data.AJIDLAGFPGM_TalkId = (int)array[i].EPKOHDLIKAN_tk;
				data.IJEKNCDIIAE_mver = (ushort)array[i].IJEKNCDIIAE_mver;
			}
			return true;
		}
		return false;
	}

	//// RVA: 0x19CEA18 Offset: 0x19CEA18 VA: 0x19CEA18
	//private bool NMJBKFBFPFG(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x19CE1EC Offset: 0x19CE1EC VA: 0x19CE1EC
	private bool FGOHGNBIAAP_LoadRoom(MILDDOGCGLE LKDONLFHMEO)
	{
		NPKPBDIDBBG_Room.Clear();
		APLNHNOKJFK[] array = LKDONLFHMEO.BHFAMKAPFNJ;
		for(int i = 0; i < array.Length; i++)
		{
			LEBAGJNJJNG_Room data = new LEBAGJNJJNG_Room();
			data.MALFHCHNEFN_RoomId = (short)array[i].OKECOPNBAGP_ro;
			data.EKANGPODCEP_EventId = array[i].JMMEGKGCIIL;
			data.OPFGFINHFCE_name = DatabaseTextConverter.TranslateSnsRoomName(i, array[i].OPFGFINHFCE_name);
			data.PPEGAKEIEGM_Enabled = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE_mver, array[i].PLALNIIBLOF_en, 0);
			data.EEECOMPDNEJ = array[i].GBJFNGCDKPM_typ;
			data.PKOKDPHHLCG_Next = (int)array[i].PFJJFCPPNIN_nx;
			NPKPBDIDBBG_Room.Add(data);
		}
		return true;
	}

	//// RVA: 0x19CEA20 Offset: 0x19CEA20 VA: 0x19CEA20
	//private bool FGOHGNBIAAP(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label) { }
	//NPKPBDIDBBG_Room = room
	//	MALFHCHNEFN_RoomId = OKECOPNBAGP_ro
	//	OPFGFINHFCE_name = OPFGFINHFCE_name

	//// RVA: 0x19CE4AC Offset: 0x19CE4AC VA: 0x19CE4AC
	private bool LHFCGAJLMDL(MILDDOGCGLE LKDONLFHMEO)
	{
		EIDBDFGNCFB[] array = LKDONLFHMEO.CEPBAOMAHNH;
		if (array.Length <= KHCACDIKJLG_Characters.Count)
		{
			for (int i = 0; i < array.Length; i++)
			{
				JFMDDEBLCAA_CharaInfo data = KHCACDIKJLG_Characters[i];
				data.OPFGFINHFCE_name = DatabaseTextConverter.TranslateSnsCharaName(i, array[i].OPFGFINHFCE_name);
				data.HAPAFECPFEK_AtName = array[i].ONOPACPKFPK_ac;
				data.EAHPLCJMPHD_PId = (int)array[i].HANMDEBPBHG_pic;
				data.HEHKNMCDBJJ_ColorId = array[i].DJJNOCDIIAE;
				data.CPKMLLNADLJ_Serie = array[i].CPKMLLNADLJ_Serie;
				data.PPEGAKEIEGM_Enabled = (sbyte)JKAECBCNHAN_IsEnabled(1, (int)array[i].PLALNIIBLOF_en, 0);
			}
			return true;
		}
		return false;
	}

	//// RVA: 0x19CECD0 Offset: 0x19CECD0 VA: 0x19CECD0
	//private bool LHFCGAJLMDL(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x19CE75C Offset: 0x19CE75C VA: 0x19CE75C
	private bool NOBOFLFGLMJ(MILDDOGCGLE LKDONLFHMEO)
	{
		CBGIPNJOPAH[] array = LKDONLFHMEO.ABIKKECOBIJ;
		for(int i = 0; i < array.Length; i++)
		{
			EIJGEDBGBBI_ColorInfo data = new EIJGEDBGBBI_ColorInfo();
			data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC_id;
			data.DOKKMMFKLJI_Color = new Color((array[i].DOKKMMFKLJI_Color & 0xff) / 255.0f,
				((array[i].DOKKMMFKLJI_Color >> 8) & 0xff) / 255.0f,
				((array[i].DOKKMMFKLJI_Color >> 16) & 0xff) / 255.0f);
			LOCEHOMKJEI_ColorConfigs.Add(data);
		}
		return true;
	}

	//// RVA: 0x19CECD8 Offset: 0x19CECD8 VA: 0x19CECD8
	//private bool NOBOFLFGLMJ(EDOHBJAPLPF_JsonData FMFBOLMIIKP, int _KAPMOPMDHJE_label) { }

	// RVA: 0x19CECF0 Offset: 0x19CECF0 VA: 0x19CECF0 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "BOKMNHAFJHF_Sns.CAOGDCBPBAN");
		return 0;
	}
}
