
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use NEGELNMPEPH_DecoSpSetting", true)]
public class NEGELNMPEPH { }
public class NEGELNMPEPH_DecoSpSetting : DIHHCBACKGG_DbSection
{
	public class DAGLEHBMBLF
	{
		private int FBGGEFFJJHB = 0; // 0x8
		private int OAKFKBJFHBJ = 0; // 0xC
		private int COLOLEGLONK = 0; // 0x10
		private int OHMGPDPKGLF = 0; // 0x14

		public int BCGKLONODHO { get { return OAKFKBJFHBJ ^ FBGGEFFJJHB; } set { OAKFKBJFHBJ = value ^ FBGGEFFJJHB; } } //0x1AE6688 KAINPELLHFF 0x1AE628C EJPIFOFOINA
		public int KPBJHHHMOJE { get { return COLOLEGLONK ^ FBGGEFFJJHB; } set { COLOLEGLONK = value ^ FBGGEFFJJHB; } } //0x1AE6698 NNBONJFLKFM 0x1AE629C FIOMMOICJLL
		public int NANNGLGOFKH { get { return OHMGPDPKGLF ^ FBGGEFFJJHB; } set { OHMGPDPKGLF = value ^ FBGGEFFJJHB; } } //0x1AE66A8 EDFAHCMGHKM 0x1AE62AC BKPDFNKGNHA
		
		// RVA: 0x1AE6264 Offset: 0x1AE6264 VA: 0x1AE6264
		public DAGLEHBMBLF(int FBGGEFFJJHB)
		{
			this.FBGGEFFJJHB = FBGGEFFJJHB;
			BCGKLONODHO = 0;
			KPBJHHHMOJE = 0;
			NANNGLGOFKH = 0;
		}

		// RVA: 0x1AE6630 Offset: 0x1AE6630 VA: 0x1AE6630
		//public uint CAOGDCBPBAN() { }
	}

	public class NDONMEAEGFF
	{
		private int FBGGEFFJJHB; // 0x8
		private int HAPFMIDIMCH; // 0xC
		private int HLMAFFLCCKD; // 0x10

		public int JPMAHJJMMIA { get { return HAPFMIDIMCH ^ FBGGEFFJJHB; } set { HAPFMIDIMCH = value ^ FBGGEFFJJHB; } } //0x1AE66B8 EEIHPMNJMKG 0x1AE62E4 MGAEEIHCOAL
		public int HMFFHLPNMPH { get { return HLMAFFLCCKD ^ FBGGEFFJJHB; } set { HLMAFFLCCKD = value ^ FBGGEFFJJHB; } } //0x1AE66C8 NJOGDDPICKG 0x1AE62F4 NBBGMMBICNA

		// RVA: 0x1AE62BC Offset: 0x1AE62BC VA: 0x1AE62BC
		public NDONMEAEGFF(int FBGGEFFJJHB)
		{
			this.FBGGEFFJJHB = FBGGEFFJJHB;
			HAPFMIDIMCH = FBGGEFFJJHB;
			HLMAFFLCCKD = FBGGEFFJJHB;
		}

		// RVA: 0x1AE6660 Offset: 0x1AE6660 VA: 0x1AE6660
		//public uint CAOGDCBPBAN() { }
	}

	public List<List<DAGLEHBMBLF>> ILCGCPIGAFP = new List<List<DAGLEHBMBLF>>(); // 0x20
	public List<List<NDONMEAEGFF>> JDLCJAILIME = new List<List<NDONMEAEGFF>>(); // 0x24
	private int FBGGEFFJJHB; // 0x28

	// RVA: 0x1AE5A1C Offset: 0x1AE5A1C VA: 0x1AE5A1C
	public NEGELNMPEPH_DecoSpSetting()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 17;
	}

	// RVA: 0x1AE5B44 Offset: 0x1AE5B44 VA: 0x1AE5B44 Slot: 8
	protected override void KMBPACJNEOF()
	{
		FBGGEFFJJHB = (int)(Utility.GetCurrentUnixTime() ^ 0x2627849);
		ILCGCPIGAFP.Clear();
		JDLCJAILIME.Clear();
	}

	// RVA: 0x1AE5C2C Offset: 0x1AE5C2C VA: 0x1AE5C2C Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		MEIHPKLEAKP parser = MEIHPKLEAKP.HEGEKFMJNCC(DBBGALAPFGC);
		{
			CFNMIJDKIJH[] array = parser.DJOIJIADLCC;
			for(int i = 0; i < array.Length; i++)
			{
				List<DAGLEHBMBLF> lData = new List<DAGLEHBMBLF>();
				{
					int[] array2 = array[i].BCGKLONODHO;
					for(int j = 0; j < array2.Length; j++)
					{
						DAGLEHBMBLF data = new DAGLEHBMBLF(FBGGEFFJJHB);
						data.BCGKLONODHO = array2[j];
						data.KPBJHHHMOJE = array[i].KPBJHHHMOJE[j];
						data.NANNGLGOFKH = array[i].JBGEEPFKIGG[j];
						lData.Add(data);
					}
				}
				ILCGCPIGAFP.Add(lData);
			}
		}
		{
			OLDDMCHLPEB[] array = parser.NLPDKFCOPNB;
			for (int i = 0; i < array.Length; i++)
			{
				List<NDONMEAEGFF> lData = new List<NDONMEAEGFF>();
				int[] array2 = array[i].HMFFHLPNMPH;
				for (int j = 0; j < array2.Length; j++)
				{
					NDONMEAEGFF data = new NDONMEAEGFF(FBGGEFFJJHB);
					data.JPMAHJJMMIA = array[i].JPMAHJJMMIA[j];
					data.HMFFHLPNMPH = array2[j];
					lData.Add(data);
				}
				JDLCJAILIME.Add(lData);
			}
		}
		return true;
	}

	// RVA: 0x1AE6304 Offset: 0x1AE6304 VA: 0x1AE6304 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return true;
	}

	// RVA: 0x1AE630C Offset: 0x1AE630C VA: 0x1AE630C Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "NEGELNMPEPH_DecoSpSetting.CAOGDCBPBAN");
		return 0;
	}
}
