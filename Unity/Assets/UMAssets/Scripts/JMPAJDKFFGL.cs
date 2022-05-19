using UnityEngine;
using System;

[Serializable]
public class JMPAJDKFFGL
{
	static bool dumpDebug = false;
	// Fields
	private readonly byte[] LDALAFIJKKM_data; // 0x8
	private int LGEDAJAFHGG_offset; // 0xC
	// private float[] IDLHFHDIDEI; // 0x10
	// private int[] GNMCIEKCKCA; // 0x14
	// private double[] KHCECGMODOC; // 0x18
	// private ulong[] MFAJHCGLKBI; // 0x1C

	// Properties
	public int FONPCFFGPBK_offset { get { return LGEDAJAFHGG_offset; } }
	// public byte[] KOJCDOJALDM { get; }
	// public int MJANLLHCFBL { get; set; }

	// Methods
	public JMPAJDKFFGL(byte[] KNOAHOEKBPN) : this(KNOAHOEKBPN, 0)
	{
		
	}
	
	public JMPAJDKFFGL(byte[] KNOAHOEKBPN_data, int NDFOAINJPIN_offset)
	{
		LDALAFIJKKM_data = KNOAHOEKBPN_data;
		LGEDAJAFHGG_offset = NDFOAINJPIN_offset;
	}
	public int MAOEJMHCFIK_GetSize()
	{
		return LDALAFIJKKM_data.Length;
	}
	public byte[] ODKCGOOJDJF_GetData()
	{
		return LDALAFIJKKM_data;
	}
	public int PJKENMHKHCM_GetOffset()
	{
		return LGEDAJAFHGG_offset;
	}
	public void GGFHFCCNGOC_SetOffset(int NANNGLGOFKH_value)
	{
		LGEDAJAFHGG_offset = NANNGLGOFKH_value;
	}
	public void LHPDDGIJKNB_Reset()
	{
		LGEDAJAFHGG_offset = 0;
	}
	public static ushort IEOBOLDMIOM_ToLE(ushort BJKEOACPMHB)
	{
  		return (ushort)((BJKEOACPMHB >> 0x10) << 0x18 | (BJKEOACPMHB >> 0x18) << 0x10 | (BJKEOACPMHB & 0xff) << 8 | BJKEOACPMHB >> 8 & 0xff);
	}
	public static uint IEOBOLDMIOM_ToLE(uint BJKEOACPMHB)
	{
		return BJKEOACPMHB << 0x18 | (BJKEOACPMHB >> 8 & 0xff) << 0x10 | (BJKEOACPMHB >> 0x10 & 0xff) << 8 | BJKEOACPMHB >> 0x18;
	}
	public static ulong IEOBOLDMIOM_ToLE(ulong BJKEOACPMHB)
	{

		// TODO
		return 0;
  		/*return CONCAT44(param_1 << 0x18 | (param_1 >> 8 & 0xff) << 0x10 | (param_1 >> 0x10 & 0xff) << 8 |
                  param_1 >> 0x18,
                  param_2 << 0x18 | (param_2 >> 8 & 0xff) << 0x10 | (param_2 >> 0x10 & 0xff) << 8 |
                  param_2 >> 0x18);*/
	}
	protected void PLIFKACFGJF(int POMLAOPLMNA, int HMFFHLPNMPH, ulong IDLHJIOMJBK)
	{
		// TODO
	}
	protected ulong KCFGIBGNPLO_Read(int POMLAOPLMNA_offset, int HMFFHLPNMPH_size)
	{
		bool printdebug = false;
		EPMMKJFEMOB_CheckRange(POMLAOPLMNA_offset, HMFFHLPNMPH_size);
		int unknownNum = 1;
		ulong res = 0;
		if(unknownNum != 0) // Static LE ou BE ?
		{
			if(HMFFHLPNMPH_size < 1)
				return 0;
			int r4 = 0;
			ulong r7 = 0;
			ulong r5 = 0;
			for(int i = 0; i < HMFFHLPNMPH_size; i++)
			{
				/*int readoffset = POMLAOPLMNA_offset + i;
				uint r1 = (uint)(r4 & 0x38); // (reste entier /8) 0 8
				uint r2 = 32 - r1;
				uint r3 = r1 - 32;
				r4 = r4 + 8;
				ulong val = (ulong)LDALAFIJKKM_data[readoffset];
				ulong r2b = val >> (r2 & 0xff);
				ulong r1b = (val << r1);
				if(r3 >= 0)
				{
					r2b = val << (r3 & 0xff);
					r1b = 0;
				}
				r7 = r7 | r1b;
				r5 = r2b | r5;*/
				// TODO

			}
			res = r7 | (r5 << 32);
		}
		else
		{
			Debug.LogError("TODO");
			res = 0;
		}
		if(dumpDebug) Debug.Log("return "+res);
		return res;
	}
	private void EPMMKJFEMOB_CheckRange(int POMLAOPLMNA_offset, int MCMIPODICAN_size) // 0x1153C80
	{
		if(POMLAOPLMNA_offset >= 0)
		{
			if(POMLAOPLMNA_offset + MCMIPODICAN_size <= LDALAFIJKKM_data.Length)
				return;
		}
		Debug.LogError("Out of Range "+POMLAOPLMNA_offset+" "+MCMIPODICAN_size);
	}
	public void FOJBKBDDNJB_WriteSByte(int POMLAOPLMNA, sbyte NANNGLGOFKH_value)
	{
		LDALAFIJKKM_data[POMLAOPLMNA] = (byte)NANNGLGOFKH_value;
	}
	// public void FNGDPJJMDHH(int POMLAOPLMNA, byte NANNGLGOFKH_value); // 0x1153DAC
	// public void FNGDPJJMDHH(int POMLAOPLMNA, byte NANNGLGOFKH_value, int HMFFHLPNMPH); // 0x1153E00
	// public void LECLCEJCMIK(int POMLAOPLMNA, byte NANNGLGOFKH_value); // 0x1153E78
	// public void LMOOMGJOAGA(int POMLAOPLMNA, short NANNGLGOFKH_value); // 0x1153E7C
	// public void LLGCDOILPOE(int POMLAOPLMNA, ushort NANNGLGOFKH_value); // 0x1153EC0
	// public void IFHOMMKPAIE(int POMLAOPLMNA, int NANNGLGOFKH_value); // 0x1153F04
	// public void EEDJAOFJFKB(int POMLAOPLMNA, uint NANNGLGOFKH_value); // 0x1153F48
	// public void LAHABNLFINP(int POMLAOPLMNA, long NANNGLGOFKH_value); // 0x1153F8C
	// public void JLGNNCCEEEO(int POMLAOPLMNA, ulong NANNGLGOFKH_value); // 0x1153FD0
	// public void HOPAHGDHCEG(int POMLAOPLMNA, float NANNGLGOFKH_value); // 0x1154014
	// public void FLGPOMLGAOL(int POMLAOPLMNA, double NANNGLGOFKH_value); // 0x11540D8
	public sbyte NEALHNAHHKM_ReadSByte(int OIPCCBHIKIA_offset)
	{
		EPMMKJFEMOB_CheckRange(OIPCCBHIKIA_offset, 1);
		return (sbyte)LDALAFIJKKM_data[OIPCCBHIKIA_offset];
	}
	public byte GCINIJEMHFK_ReadByte(int OIPCCBHIKIA_offset)
	{
		EPMMKJFEMOB_CheckRange(OIPCCBHIKIA_offset, 1);
		return LDALAFIJKKM_data[OIPCCBHIKIA_offset];
	}
	public short IJIFMEMHIPA_ReadShort(int OIPCCBHIKIA_offset)
	{
		return (short)KCFGIBGNPLO_Read(OIPCCBHIKIA_offset, 2);
	}
	public ushort LLONMBIPALI_ReadUShort(int OIPCCBHIKIA_offset)
	{
		return (ushort)KCFGIBGNPLO_Read(OIPCCBHIKIA_offset, 2);
	}
	public int CJAENOMGPDA_ReadInt(int OIPCCBHIKIA_offset)
	{
		int val = (int)KCFGIBGNPLO_Read(OIPCCBHIKIA_offset, 4);
		if(dumpDebug) Debug.Log("Casted int : "+val);
		return val;
	}
	public uint NIACHBNBJMG_ReadUint(int OIPCCBHIKIA_offset)
	{
		//??
		/*int res = FGDIPIOKOBP.LPGLFFLLMNG(4);
		if(res == 0)
			return 0;
		return (uint)KCFGIBGNPLO_Read(OIPCCBHIKIA_offset + res, 4);*/
		// TODO
		return 0;
	}
	public long DKMPHAPBDLH(int OIPCCBHIKIA_offset)
	{
		return (long)KCFGIBGNPLO_Read(OIPCCBHIKIA_offset, 8);
	}
	// public ulong HLGOMGKMOLI(int OIPCCBHIKIA_index); // 0x1154274
	// public float GEMKJBPOLGK(int OIPCCBHIKIA_index); // 0x115427C
	// public double BLDINLMJHAF(int OIPCCBHIKIA_index); // 0x1154318
}
