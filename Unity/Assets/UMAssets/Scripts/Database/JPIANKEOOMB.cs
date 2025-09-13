
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use JPIANKEOOMB_Valkyrie", true)]
public class JPIANKEOOMB { }
[UMOClass(ReaderClass = "NJOFJDHEGIK")]
public class JPIANKEOOMB_Valkyrie : DIHHCBACKGG_DbSection
{
	[UMOClass(ReaderClass = "KDNFKHOKMJL")]
	public class KJPIDJOMODA_ValkyrieInfo
	{
		public short[] NLBLLLLBHOP = new short[2]; // 0x8
		[UMOMember(ReaderMember = "IJEKNCDIIAE|PLALNIIBLOF", Desc = "Availabe in game if value = 2")]
		public short PPEGAKEIEGM_Enabled; // 0xC
		public short IMGMAKOGIFP_CryptedPilotId; // 0xE
		public short IFGMKBKBFJI_IdCrypted; // 0x10
		public short FBGGEFFJJHB_xor; // 0x12
		public short HNJNKCPDKAL_CryptedModelId; // 0x14
		public short KIDNEIEHOMN_Crypted; // 0x16
		public short CDDLNKAPCFB_HitCrypted; // 0x18
		[UMOMember(ReaderMember = "JPFMJHLCMJL", Desc = "Serie")]
		public sbyte AIHCEGFANAM_SerieAttr; // 0x1A
		[UMOMember(ReaderMember = "GMELAKNFKMG", Desc = "Bitfield for each enabled form")]
		public sbyte CMAJHIMEIAC; // 0x1B
		public short AENGKBBMPGM_SkillIdCrypted; // 0x1C
		public int BFFGMECIOIA_Crypted; // 0x20

		[UMOMember(ReaderMember = "PPFNGGCBJKC", Desc = "Valkyrie id", CryptedInMemory = true)]
		public short GPPEFLKGGGJ_ValkyrieId { get { return (short)(IFGMKBKBFJI_IdCrypted ^ FBGGEFFJJHB_xor); } set { IFGMKBKBFJI_IdCrypted = (short)(value ^ FBGGEFFJJHB_xor); } } //0x1BA72D8 PCDKIHHDCHI 0x1BA6D54 LANEIFNCIAA
		[UMOMember(ReaderMember = "HDEBAGHEIKD", Desc = "Pilot id", CryptedInMemory = true)]
		public short PFGJJLGLPAC_PilotId { get { return (short)(IMGMAKOGIFP_CryptedPilotId ^ FBGGEFFJJHB_xor); } set { IMGMAKOGIFP_CryptedPilotId = (short)(value ^ FBGGEFFJJHB_xor); } } //0x1BA7530 PODJOBBGCNC 0x1BA7178 AMDGADPHLEF
		[UMOMember(ReaderMember = "FLNJLKKAFPB", Desc = "Model id", CryptedInMemory = true)]
		public short DAJGPBLEEOB_ModelId { get { return (short)(HNJNKCPDKAL_CryptedModelId ^ FBGGEFFJJHB_xor); } set { HNJNKCPDKAL_CryptedModelId = (short)(value ^ FBGGEFFJJHB_xor); } } //0x1BA7544 LHPKEPPBKPF 0x1BA6D64 OIOEEEDODJA
		[UMOMember(ReaderMember = "FCBJFKGDINH", Desc = "Battle attack stat", CryptedInMemory = true)]
		public short KINFGHHNFCF_Atk { get { return (short)(KIDNEIEHOMN_Crypted ^ FBGGEFFJJHB_xor); } set { KIDNEIEHOMN_Crypted = (short)(value ^ FBGGEFFJJHB_xor); } } //0x1BA7558 BNLKPIIJCDF 0x1BA756C PKEDNGJNJNC
		[UMOMember(ReaderMember = "NONBCCLGBAO", Desc = "Battle hit stat", CryptedInMemory = true)]
		public short NONBCCLGBAO_Hit { get { return (short)(CDDLNKAPCFB_HitCrypted ^ FBGGEFFJJHB_xor); } set { CDDLNKAPCFB_HitCrypted = (short)(value ^ FBGGEFFJJHB_xor); } } //0x1BA757C AEJBEGKBPCO 0x1BA7590 JPIBPFANBNG
		[UMOMember(ReaderMember = "BMIJDLBGFNP", Desc = "Battle skill id", CryptedInMemory = true)]
		public short BMIJDLBGFNP_SkillId { get { return (short)(AENGKBBMPGM_SkillIdCrypted ^ FBGGEFFJJHB_xor); } } //0x1BA75A0 NIHGHMNFOAO
		[UMOMember(ReaderMember = "BFCBGDOICCO", Desc = "Version when enabled in deco room", CryptedInMemory = true)]
		public int MIHAHCEANII { get { return BFFGMECIOIA_Crypted ^ FBGGEFFJJHB_xor; } set { BFFGMECIOIA_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1BA7434 FOKDFFJIDDI 0x1BA7188 KMILCNKADIO
		public bool IPJMPBANBPP_IsEnabled { get { return PPEGAKEIEGM_Enabled == 2; } } //0x1BA75B4 IJMCHOOIMBB

		//// RVA: 0x1BA75C8 Offset: 0x1BA75C8 VA: 0x1BA75C8
		public bool ENIGAEMEAOP(int KNDKMLNLPJO)
		{
			return (CMAJHIMEIAC & (1 << KNDKMLNLPJO)) != 0;
		}

		//// RVA: 0x1BA75E4 Offset: 0x1BA75E4 VA: 0x1BA75E4
		public short OJHINEMKMOP(int IGBFFCLMAMM)
		{
			return KINFGHHNFCF_Atk;
		}

		//// RVA: 0x1BA75F8 Offset: 0x1BA75F8 VA: 0x1BA75F8
		public short PAELLCKLEJP(int IGBFFCLMAMM)
		{
			return NONBCCLGBAO_Hit;
		}

		//// RVA: 0x1BA7280 Offset: 0x1BA7280 VA: 0x1BA7280
		//public uint CAOGDCBPBAN() { }
	}

	[UMOMember(ReaderMember = "PIEGAMCFGGL")]
	public List<KJPIDJOMODA_ValkyrieInfo> CDENCMNHNGA_table { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB

	//// RVA: 0x1BA6998 Offset: 0x1BA6998 VA: 0x1BA6998
	public KJPIDJOMODA_ValkyrieInfo GCINIJEMHFK(int PPFNGGCBJKC)
	{
		if (PPFNGGCBJKC == 0 || CDENCMNHNGA_table.Count < PPFNGGCBJKC)
			return null;
		return CDENCMNHNGA_table[PPFNGGCBJKC - 1];
	}

	// RVA: 0x1BA6A60 Offset: 0x1BA6A60 VA: 0x1BA6A60
	public JPIANKEOOMB_Valkyrie()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 85;
		CDENCMNHNGA_table = new List<KJPIDJOMODA_ValkyrieInfo>(100);
	}

	// RVA: 0x1BA6B58 Offset: 0x1BA6B58 VA: 0x1BA6B58 Slot: 8
	protected override void KMBPACJNEOF()
	{
		long time = Utility.GetCurrentUnixTime();
		int key = (int)time * 0x5e7;
		CDENCMNHNGA_table.Clear();
		for(int i = 0; i < 100; i++)
		{
			KJPIDJOMODA_ValkyrieInfo data = new KJPIDJOMODA_ValkyrieInfo();
			data.FBGGEFFJJHB_xor = (short)key;
			data.GPPEFLKGGGJ_ValkyrieId = (short)((i + 1));
			data.DAJGPBLEEOB_ModelId = (short)(1);
			CDENCMNHNGA_table.Add(data);
			key = ((key * 0x373d0000) >> 0x10) + 0x85d;
		}
	}

	// RVA: 0x1BA6D74 Offset: 0x1BA6D74 VA: 0x1BA6D74 Slot: 9
	public override bool IIEMACPEEBJ(byte[] _DBBGALAPFGC_Data)
	{
		NJOFJDHEGIK parser = NJOFJDHEGIK.HEGEKFMJNCC(_DBBGALAPFGC_Data);
		return JANANCJMFPB(parser);
	}

	// RVA: 0x1BA7168 Offset: 0x1BA7168 VA: 0x1BA7168 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.LogError(TodoLogger.DbJson, "Valkyrie Json Load");
		return false;
	}

	//// RVA: 0x1BA6D9C Offset: 0x1BA6D9C VA: 0x1BA6D9C
	private bool JANANCJMFPB(NJOFJDHEGIK CKLOMFKNFPG)
	{
		KDNFKHOKMJL[] array = CKLOMFKNFPG.PIEGAMCFGGL;
		if (array.Length > 100)
			return false;
		for(int i = 0; i < array.Length; i++)
		{
			CDENCMNHNGA_table[i].GPPEFLKGGGJ_ValkyrieId = (short)(array[i].PPFNGGCBJKC);
			CDENCMNHNGA_table[i].DAJGPBLEEOB_ModelId = (short)(array[i].FLNJLKKAFPB);
			CDENCMNHNGA_table[i].AIHCEGFANAM_SerieAttr = (sbyte)array[i].JPFMJHLCMJL;
			CDENCMNHNGA_table[i].PFGJJLGLPAC_PilotId = (short)(array[i].HDEBAGHEIKD);
			CDENCMNHNGA_table[i].PPEGAKEIEGM_Enabled = (short)JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, (int)array[i].PLALNIIBLOF, 0);
			CDENCMNHNGA_table[i].KINFGHHNFCF_Atk = (short)(array[i].FCBJFKGDINH);
			CDENCMNHNGA_table[i].NONBCCLGBAO_Hit = (short)(array[i].NONBCCLGBAO);
			CDENCMNHNGA_table[i].AENGKBBMPGM_SkillIdCrypted = (short)(array[i].BMIJDLBGFNP ^ CDENCMNHNGA_table[i].FBGGEFFJJHB_xor);
			CDENCMNHNGA_table[i].MIHAHCEANII = (short)(array[i].BFCBGDOICCO);
			CDENCMNHNGA_table[i].CMAJHIMEIAC = 0;
			for (int j = 0; j < 3; j++)
			{
				CDENCMNHNGA_table[i].CMAJHIMEIAC |= (sbyte)(array[i].GMELAKNFKMG[j] << j);
			}
		}
		return true;
	}

	//// RVA: 0x1BA7170 Offset: 0x1BA7170 VA: 0x1BA7170
	//private bool JANANCJMFPB(EDOHBJAPLPF OILEIIEIBHP, int KAPMOPMDHJE) { }

	// RVA: 0x1BA7198 Offset: 0x1BA7198 VA: 0x1BA7198 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "JPIANKEOOMB_Valkyrie.CAOGDCBPBAN");
		return 0;
	}

	//// RVA: 0x1B9D208 Offset: 0x1B9D208 VA: 0x1B9D208
	public bool PILGJJCABME_IsValkyrieAvaiable(int _GPPEFLKGGGJ_ValkyrieId)
	{
		if(_GPPEFLKGGGJ_ValkyrieId > 0 && _GPPEFLKGGGJ_ValkyrieId < CDENCMNHNGA_table.Count)
		{
			if (CDENCMNHNGA_table[_GPPEFLKGGGJ_ValkyrieId - 1].PPEGAKEIEGM_Enabled == 2)
				return CDENCMNHNGA_table[_GPPEFLKGGGJ_ValkyrieId - 1].GPPEFLKGGGJ_ValkyrieId == _GPPEFLKGGGJ_ValkyrieId;
		}
		return false;
	}

	//// RVA: 0x1BA72EC Offset: 0x1BA72EC VA: 0x1BA72EC
	public bool AAACOMKNJJJ(int LLOBHDMHJIG)
	{
		if(LLOBHDMHJIG > 0)
		{
			if(LLOBHDMHJIG <= CDENCMNHNGA_table.Count)
			{
				if(CDENCMNHNGA_table[LLOBHDMHJIG - 1].PPEGAKEIEGM_Enabled == 2 && CDENCMNHNGA_table[LLOBHDMHJIG - 1].MIHAHCEANII > 0)
				{
					return CDENCMNHNGA_table[LLOBHDMHJIG - 1].MIHAHCEANII <= IEFOPDOOLOK_MasterVersion;
				}
			}
		}
		return false;
	}

	//// RVA: 0x1BA7444 Offset: 0x1BA7444 VA: 0x1BA7444
	public int MGKNLBJCJCK(int LLOBHDMHJIG)
	{
		if(LLOBHDMHJIG > 0)
		{
			if(LLOBHDMHJIG <= CDENCMNHNGA_table.Count)
			{
				if(CDENCMNHNGA_table[LLOBHDMHJIG - 1].PPEGAKEIEGM_Enabled == 2)
				{
					return CDENCMNHNGA_table[LLOBHDMHJIG - 1].MIHAHCEANII;
				}
			}
		}
		return 0;
	}
}
