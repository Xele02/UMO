
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use JPIANKEOOMB_Valkyrie", true)]
public class JPIANKEOOMB { }
public class JPIANKEOOMB_Valkyrie : DIHHCBACKGG_DbSection
{
	public class KJPIDJOMODA_ValkyrieInfo
	{
		public short[] NLBLLLLBHOP = new short[2]; // 0x8
		public short PPEGAKEIEGM_Enabled; // 0xC
		public short IMGMAKOGIFP_CryptedPilotId; // 0xE
		public short IFGMKBKBFJI; // 0x10
		public short FBGGEFFJJHB; // 0x12
		public short HNJNKCPDKAL_CryptedModelId; // 0x14
		public short KIDNEIEHOMN; // 0x16
		public short CDDLNKAPCFB; // 0x18
		public sbyte AIHCEGFANAM_Sa; // 0x1A
		public sbyte CMAJHIMEIAC; // 0x1B
		public short AENGKBBMPGM; // 0x1C
		public int BFFGMECIOIA; // 0x20

		public short GPPEFLKGGGJ_Id { get { return (short)(IFGMKBKBFJI ^ FBGGEFFJJHB); } set { IFGMKBKBFJI = (short)(value ^ FBGGEFFJJHB); } } //0x1BA72D8 PCDKIHHDCHI 0x1BA6D54 LANEIFNCIAA
		public short PFGJJLGLPAC_PilotId { get { return (short)(IMGMAKOGIFP_CryptedPilotId ^ FBGGEFFJJHB); } set { IMGMAKOGIFP_CryptedPilotId = (short)(value ^ FBGGEFFJJHB); } } //0x1BA7530 PODJOBBGCNC 0x1BA7178 AMDGADPHLEF
		public short DAJGPBLEEOB_ModelId { get { return (short)(HNJNKCPDKAL_CryptedModelId ^ FBGGEFFJJHB); } set { HNJNKCPDKAL_CryptedModelId = (short)(value ^ FBGGEFFJJHB); } } //0x1BA7544 LHPKEPPBKPF 0x1BA6D64 OIOEEEDODJA
		public short KINFGHHNFCF { get { return (short)(KIDNEIEHOMN ^ FBGGEFFJJHB); } set { KIDNEIEHOMN = (short)(value ^ FBGGEFFJJHB); } } //0x1BA7558 BNLKPIIJCDF 0x1BA756C PKEDNGJNJNC
		public short NONBCCLGBAO { get { return (short)(CDDLNKAPCFB ^ FBGGEFFJJHB); } set { CDDLNKAPCFB = (short)(value ^ FBGGEFFJJHB); } } //0x1BA757C AEJBEGKBPCO 0x1BA7590 JPIBPFANBNG
		public short BMIJDLBGFNP_SkillId { get { return (short)(AENGKBBMPGM ^ FBGGEFFJJHB); } } //0x1BA75A0 NIHGHMNFOAO
		public int MIHAHCEANII { get { return BFFGMECIOIA ^ FBGGEFFJJHB; } set { BFFGMECIOIA = value ^ FBGGEFFJJHB; } } //0x1BA7434 FOKDFFJIDDI 0x1BA7188 KMILCNKADIO
		public bool IPJMPBANBPP_IsEnabled { get { return PPEGAKEIEGM_Enabled == 2; } } //0x1BA75B4 IJMCHOOIMBB

		//// RVA: 0x1BA75C8 Offset: 0x1BA75C8 VA: 0x1BA75C8
		public bool ENIGAEMEAOP(int KNDKMLNLPJO)
		{
			return (CMAJHIMEIAC & (1 << KNDKMLNLPJO)) != 0;
		}

		//// RVA: 0x1BA75E4 Offset: 0x1BA75E4 VA: 0x1BA75E4
		public short OJHINEMKMOP(int IGBFFCLMAMM)
		{
			return (short)(KIDNEIEHOMN ^ FBGGEFFJJHB);
		}

		//// RVA: 0x1BA75F8 Offset: 0x1BA75F8 VA: 0x1BA75F8
		public short PAELLCKLEJP(int IGBFFCLMAMM)
		{
			return (short)(CDDLNKAPCFB ^ FBGGEFFJJHB);
		}

		//// RVA: 0x1BA7280 Offset: 0x1BA7280 VA: 0x1BA7280
		//public uint CAOGDCBPBAN() { }
	}

	public List<KJPIDJOMODA_ValkyrieInfo> CDENCMNHNGA_ValkyrieList { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB

	//// RVA: 0x1BA6998 Offset: 0x1BA6998 VA: 0x1BA6998
	public KJPIDJOMODA_ValkyrieInfo GCINIJEMHFK(int PPFNGGCBJKC)
	{
		if (PPFNGGCBJKC == 0 || CDENCMNHNGA_ValkyrieList.Count < PPFNGGCBJKC)
			return null;
		return CDENCMNHNGA_ValkyrieList[PPFNGGCBJKC - 1];
	}

	// RVA: 0x1BA6A60 Offset: 0x1BA6A60 VA: 0x1BA6A60
	public JPIANKEOOMB_Valkyrie()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 85;
		CDENCMNHNGA_ValkyrieList = new List<KJPIDJOMODA_ValkyrieInfo>(100);
	}

	// RVA: 0x1BA6B58 Offset: 0x1BA6B58 VA: 0x1BA6B58 Slot: 8
	protected override void KMBPACJNEOF()
	{
		long time = Utility.GetCurrentUnixTime();
		int key = (int)time * 0x5e7;
		CDENCMNHNGA_ValkyrieList.Clear();
		for(int i = 0; i < 100; i++)
		{
			KJPIDJOMODA_ValkyrieInfo data = new KJPIDJOMODA_ValkyrieInfo();
			data.FBGGEFFJJHB = (short)key;
			data.GPPEFLKGGGJ_Id = (short)((i + 1));
			data.DAJGPBLEEOB_ModelId = (short)(1);
			CDENCMNHNGA_ValkyrieList.Add(data);
			key = ((key * 0x373d0000) >> 0x10) + 0x85d;
		}
	}

	// RVA: 0x1BA6D74 Offset: 0x1BA6D74 VA: 0x1BA6D74 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		NJOFJDHEGIK parser = NJOFJDHEGIK.HEGEKFMJNCC(DBBGALAPFGC);
		return JANANCJMFPB(parser);
	}

	// RVA: 0x1BA7168 Offset: 0x1BA7168 VA: 0x1BA7168 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.LogError(100, "Valkyrie Json Load");
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
			CDENCMNHNGA_ValkyrieList[i].GPPEFLKGGGJ_Id = (short)(array[i].PPFNGGCBJKC);
			CDENCMNHNGA_ValkyrieList[i].DAJGPBLEEOB_ModelId = (short)(array[i].FLNJLKKAFPB);
			CDENCMNHNGA_ValkyrieList[i].AIHCEGFANAM_Sa = (sbyte)array[i].JPFMJHLCMJL;
			CDENCMNHNGA_ValkyrieList[i].PFGJJLGLPAC_PilotId = (short)(array[i].HDEBAGHEIKD);
			CDENCMNHNGA_ValkyrieList[i].PPEGAKEIEGM_Enabled = (short)JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, (int)array[i].PLALNIIBLOF, 0);
			CDENCMNHNGA_ValkyrieList[i].KIDNEIEHOMN = (short)(array[i].FCBJFKGDINH ^ CDENCMNHNGA_ValkyrieList[i].FBGGEFFJJHB);
			CDENCMNHNGA_ValkyrieList[i].CDDLNKAPCFB = (short)(array[i].NONBCCLGBAO ^ CDENCMNHNGA_ValkyrieList[i].FBGGEFFJJHB);
			CDENCMNHNGA_ValkyrieList[i].AENGKBBMPGM = (short)(array[i].BMIJDLBGFNP ^ CDENCMNHNGA_ValkyrieList[i].FBGGEFFJJHB);
			CDENCMNHNGA_ValkyrieList[i].MIHAHCEANII = (short)(array[i].BFCBGDOICCO);
			CDENCMNHNGA_ValkyrieList[i].CMAJHIMEIAC = 0;
			for (int j = 0; j < 3; j++)
			{
				CDENCMNHNGA_ValkyrieList[i].CMAJHIMEIAC |= (sbyte)(array[i].GMELAKNFKMG[j] << j);
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
	public bool PILGJJCABME_IsValkyrieAvaiable(int GPPEFLKGGGJ)
	{
		if(GPPEFLKGGGJ > 0 && GPPEFLKGGGJ < CDENCMNHNGA_ValkyrieList.Count)
		{
			if (CDENCMNHNGA_ValkyrieList[GPPEFLKGGGJ - 1].PPEGAKEIEGM_Enabled == 2)
				return CDENCMNHNGA_ValkyrieList[GPPEFLKGGGJ - 1].GPPEFLKGGGJ_Id == GPPEFLKGGGJ;
		}
		return false;
	}

	//// RVA: 0x1BA72EC Offset: 0x1BA72EC VA: 0x1BA72EC
	public bool AAACOMKNJJJ(int LLOBHDMHJIG)
	{
		if(LLOBHDMHJIG > 0)
		{
			if(LLOBHDMHJIG <= CDENCMNHNGA_ValkyrieList.Count)
			{
				if(CDENCMNHNGA_ValkyrieList[LLOBHDMHJIG - 1].PPEGAKEIEGM_Enabled == 2 && CDENCMNHNGA_ValkyrieList[LLOBHDMHJIG - 1].MIHAHCEANII > 0)
				{
					return CDENCMNHNGA_ValkyrieList[LLOBHDMHJIG - 1].MIHAHCEANII <= IEFOPDOOLOK_MasterVersion;
				}
			}
		}
		return false;
	}

	//// RVA: 0x1BA7444 Offset: 0x1BA7444 VA: 0x1BA7444
	//public int MGKNLBJCJCK(int LLOBHDMHJIG) { }
}
