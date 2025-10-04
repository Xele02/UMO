
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
		public short[] NLBLLLLBHOP_StatusCrypted = new short[2]; // 0x8
		[UMOMember(ReaderMember = "IJEKNCDIIAE_mver|PLALNIIBLOF_en", Desc = "Availabe in game if value = 2")]
		public short PPEGAKEIEGM_Enabled; // 0xC
		public short IMGMAKOGIFP_CryptedPilotId; // 0xE
		public short IFGMKBKBFJI_ValkyrieIdCrypted; // 0x10
		public short FBGGEFFJJHB_xor; // 0x12
		public short HNJNKCPDKAL_CryptedModelId; // 0x14
		public short KIDNEIEHOMN_AtkCrypted; // 0x16
		public short CDDLNKAPCFB_HitCrypted; // 0x18
		[UMOMember(ReaderMember = "JPFMJHLCMJL_sa", Desc = "Serie")]
		public sbyte AIHCEGFANAM_SerieAttr; // 0x1A
		[UMOMember(ReaderMember = "GMELAKNFKMG", Desc = "Bitfield for each enabled form")]
		public sbyte CMAJHIMEIAC; // 0x1B
		public short AENGKBBMPGM_SkillIdCrypted; // 0x1C
		public int BFFGMECIOIA_Crypted; // 0x20

		[UMOMember(ReaderMember = "PPFNGGCBJKC_id", Desc = "Valkyrie id", CryptedInMemory = true)]
		public short GPPEFLKGGGJ_ValkyrieId { get { return (short)(IFGMKBKBFJI_ValkyrieIdCrypted ^ FBGGEFFJJHB_xor); } set { IFGMKBKBFJI_ValkyrieIdCrypted = (short)(value ^ FBGGEFFJJHB_xor); } } //0x1BA72D8 PCDKIHHDCHI_bgs 0x1BA6D54 LANEIFNCIAA_bgs
		[UMOMember(ReaderMember = "HDEBAGHEIKD_plt", Desc = "Pilot id", CryptedInMemory = true)]
		public short PFGJJLGLPAC_PilotId { get { return (short)(IMGMAKOGIFP_CryptedPilotId ^ FBGGEFFJJHB_xor); } set { IMGMAKOGIFP_CryptedPilotId = (short)(value ^ FBGGEFFJJHB_xor); } } //0x1BA7530 PODJOBBGCNC_bgs 0x1BA7178 AMDGADPHLEF_bgs
		[UMOMember(ReaderMember = "FLNJLKKAFPB_mdl", Desc = "Model id", CryptedInMemory = true)]
		public short DAJGPBLEEOB_ModelId { get { return (short)(HNJNKCPDKAL_CryptedModelId ^ FBGGEFFJJHB_xor); } set { HNJNKCPDKAL_CryptedModelId = (short)(value ^ FBGGEFFJJHB_xor); } } //0x1BA7544 LHPKEPPBKPF_bgs 0x1BA6D64 OIOEEEDODJA_bgs
		[UMOMember(ReaderMember = "FCBJFKGDINH_atk", Desc = "Battle attack stat", CryptedInMemory = true)]
		public short KINFGHHNFCF_Atk { get { return (short)(KIDNEIEHOMN_AtkCrypted ^ FBGGEFFJJHB_xor); } set { KIDNEIEHOMN_AtkCrypted = (short)(value ^ FBGGEFFJJHB_xor); } } //0x1BA7558 BNLKPIIJCDF_bgs 0x1BA756C PKEDNGJNJNC_bgs
		[UMOMember(ReaderMember = "NONBCCLGBAO_hit", Desc = "Battle hit stat", CryptedInMemory = true)]
		public short NONBCCLGBAO_hit { get { return (short)(CDDLNKAPCFB_HitCrypted ^ FBGGEFFJJHB_xor); } set { CDDLNKAPCFB_HitCrypted = (short)(value ^ FBGGEFFJJHB_xor); } } //0x1BA757C AEJBEGKBPCO_get_hit 0x1BA7590 JPIBPFANBNG_set_hit
		[UMOMember(ReaderMember = "BMIJDLBGFNP_skill", Desc = "Battle skill id", CryptedInMemory = true)]
		public short BMIJDLBGFNP_skill { get { return (short)(AENGKBBMPGM_SkillIdCrypted ^ FBGGEFFJJHB_xor); } } //0x1BA75A0 NIHGHMNFOAO_get_skill
		[UMOMember(ReaderMember = "BFCBGDOICCO", Desc = "Version when enabled in deco room", CryptedInMemory = true)]
		public int MIHAHCEANII { get { return BFFGMECIOIA_Crypted ^ FBGGEFFJJHB_xor; } set { BFFGMECIOIA_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1BA7434 FOKDFFJIDDI_bgs 0x1BA7188 KMILCNKADIO_bgs
		public bool IPJMPBANBPP_Enabled { get { return PPEGAKEIEGM_Enabled == 2; } } //0x1BA75B4 IJMCHOOIMBB_bgs

		//// RVA: 0x1BA75C8 Offset: 0x1BA75C8 VA: 0x1BA75C8
		public bool ENIGAEMEAOP(int KNDKMLNLPJO)
		{
			return (CMAJHIMEIAC & (1 << KNDKMLNLPJO)) != 0;
		}

		//// RVA: 0x1BA75E4 Offset: 0x1BA75E4 VA: 0x1BA75E4
		public short OJHINEMKMOP(int _IGBFFCLMAMM_Form)
		{
			return KINFGHHNFCF_Atk;
		}

		//// RVA: 0x1BA75F8 Offset: 0x1BA75F8 VA: 0x1BA75F8
		public short PAELLCKLEJP(int _IGBFFCLMAMM_Form)
		{
			return NONBCCLGBAO_hit;
		}

		//// RVA: 0x1BA7280 Offset: 0x1BA7280 VA: 0x1BA7280
		//public uint CAOGDCBPBAN() { }
	}

	[UMOMember(ReaderMember = "PIEGAMCFGGL")]
	public List<KJPIDJOMODA_ValkyrieInfo> CDENCMNHNGA_table { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF_get_table ILHOADLEJPB_set_table

	//// RVA: 0x1BA6998 Offset: 0x1BA6998 VA: 0x1BA6998
	public KJPIDJOMODA_ValkyrieInfo GCINIJEMHFK_Get(int _PPFNGGCBJKC_id)
	{
		if (_PPFNGGCBJKC_id == 0 || CDENCMNHNGA_table.Count < _PPFNGGCBJKC_id)
			return null;
		return CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1];
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
	protected override void KMBPACJNEOF_Reset()
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
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		NJOFJDHEGIK parser = NJOFJDHEGIK.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		return JANANCJMFPB(parser);
	}

	// RVA: 0x1BA7168 Offset: 0x1BA7168 VA: 0x1BA7168 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
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
			CDENCMNHNGA_table[i].GPPEFLKGGGJ_ValkyrieId = (short)(array[i].PPFNGGCBJKC_id);
			CDENCMNHNGA_table[i].DAJGPBLEEOB_ModelId = (short)(array[i].FLNJLKKAFPB_mdl);
			CDENCMNHNGA_table[i].AIHCEGFANAM_SerieAttr = (sbyte)array[i].JPFMJHLCMJL_sa;
			CDENCMNHNGA_table[i].PFGJJLGLPAC_PilotId = (short)(array[i].HDEBAGHEIKD_plt);
			CDENCMNHNGA_table[i].PPEGAKEIEGM_Enabled = (short)JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE_mver, (int)array[i].PLALNIIBLOF_en, 0);
			CDENCMNHNGA_table[i].KINFGHHNFCF_Atk = (short)(array[i].FCBJFKGDINH_atk);
			CDENCMNHNGA_table[i].NONBCCLGBAO_hit = (short)(array[i].NONBCCLGBAO_hit);
			CDENCMNHNGA_table[i].AENGKBBMPGM_SkillIdCrypted = (short)(array[i].BMIJDLBGFNP_skill ^ CDENCMNHNGA_table[i].FBGGEFFJJHB_xor);
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
	//private bool JANANCJMFPB(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label) { }

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
	public bool AAACOMKNJJJ(int _LLOBHDMHJIG_Id)
	{
		if(_LLOBHDMHJIG_Id > 0)
		{
			if(_LLOBHDMHJIG_Id <= CDENCMNHNGA_table.Count)
			{
				if(CDENCMNHNGA_table[_LLOBHDMHJIG_Id - 1].PPEGAKEIEGM_Enabled == 2 && CDENCMNHNGA_table[_LLOBHDMHJIG_Id - 1].MIHAHCEANII > 0)
				{
					return CDENCMNHNGA_table[_LLOBHDMHJIG_Id - 1].MIHAHCEANII <= IEFOPDOOLOK_MasterVersion;
				}
			}
		}
		return false;
	}

	//// RVA: 0x1BA7444 Offset: 0x1BA7444 VA: 0x1BA7444
	public int MGKNLBJCJCK(int _LLOBHDMHJIG_Id)
	{
		if(_LLOBHDMHJIG_Id > 0)
		{
			if(_LLOBHDMHJIG_Id <= CDENCMNHNGA_table.Count)
			{
				if(CDENCMNHNGA_table[_LLOBHDMHJIG_Id - 1].PPEGAKEIEGM_Enabled == 2)
				{
					return CDENCMNHNGA_table[_LLOBHDMHJIG_Id - 1].MIHAHCEANII;
				}
			}
		}
		return 0;
	}
}
