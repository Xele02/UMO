using System.Collections.Generic;
using XeSys;
using System.IO;

public class IGJHFKELHKJ
{
    public class HPJEDLPEJLF
    {
        public long JMGLAOBOAHM; // 0x8
        public long LGEGIKJGCCA; // 0x10
        public uint AAFDKMODECB; // 0x18
        public bool CPBPOIMHIML; // 0x1C

        public uint IOIMHJAOKOO { get { return FBGGEFFJJHB ^ AAFDKMODECB; } set { AAFDKMODECB = value ^ FBGGEFFJJHB; } } //0x11F5288 HJMJGBCJBIN 0x11F60B8 OLGHLLNJPKD
    }
    
	private const int BIAOPOMKMJE = 678720529;
	private static uint FBGGEFFJJHB = 0x171114; // 0x0
	public Dictionary<uint, IGJHFKELHKJ.HPJEDLPEJLF> BEIEHPNODAM = new Dictionary<uint, IGJHFKELHKJ.HPJEDLPEJLF>(); // 0x8
	private string JHJMNLMNPGO; // 0xC

	// // RVA: 0x11F4DB4 Offset: 0x11F4DB4 VA: 0x11F4DB4
	// public IGJHFKELHKJ.HPJEDLPEJLF LBDOLHGDIEB(uint IOIMHJAOKOO) { }

	// // RVA: 0x11F4E74 Offset: 0x11F4E74 VA: 0x11F4E74
	// public void IDJJFHFPNFG(uint IOIMHJAOKOO) { }

	// // RVA: 0x11F4F48 Offset: 0x11F4F48 VA: 0x11F4F48
	public void PNMIOGBPDFN()
	{
		uint[] keyArray = new uint[BEIEHPNODAM.Keys.Count];
		BEIEHPNODAM.Keys.CopyTo(keyArray, 0);
		for(int i = 0; i < BEIEHPNODAM.Keys.Count; i++)
		{
			BEIEHPNODAM[keyArray[i]].CPBPOIMHIML = true;
		}
	}

	// // RVA: 0x11F5114 Offset: 0x11F5114 VA: 0x11F5114
	// public void IKIPLMFOCFF(uint IOIMHJAOKOO) { }

	// // RVA: 0x11F51E8 Offset: 0x11F51E8 VA: 0x11F51E8
	// public void LBBOGOBBAAD(IGJHFKELHKJ.HPJEDLPEJLF KOGBMDOONFA) { }

	// // RVA: 0x11F5320 Offset: 0x11F5320 VA: 0x11F5320
	public void PCODDPDFLHK()
	{
		IGJHFKELHKJ.FBGGEFFJJHB = (uint)(Utility.GetCurrentUnixTime() + 100);
		BEIEHPNODAM.Clear();
		JHJMNLMNPGO = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + KCOGAGGCPBP.HAFLEFNJAKD; // /sys
		if(!Directory.Exists(JHJMNLMNPGO))
		{
			UnityEngine.Debug.Log("Create Dir "+JHJMNLMNPGO);
			Directory.CreateDirectory(JHJMNLMNPGO);
		}
		string file = JHJMNLMNPGO + "/" + KCOGAGGCPBP.PNBIAPMFPPD; // 01
		if(File.Exists(file))
		{
			FileStream f = new FileStream(file, FileMode.Open);
			BinaryReader b = new BinaryReader(f);
			int header = b.ReadInt32();
			if(header == 0x28747411)
			{
				int val = b.ReadInt32();
				if(val > 0)
				{
					for(int i = 0; i < val; i++)
					{
						IGJHFKELHKJ.HPJEDLPEJLF data = new IGJHFKELHKJ.HPJEDLPEJLF();
						data.IOIMHJAOKOO = b.ReadUInt32();
						b.ReadUInt32();
						data.JMGLAOBOAHM = b.ReadInt64();
						data.CPBPOIMHIML = false;
						data.LGEGIKJGCCA = b.ReadInt64();
						BEIEHPNODAM.Add(data.IOIMHJAOKOO, data);
					}
				}
				return; // ?
			}
			b.Close();
			f.Dispose();
		}
		file = JHJMNLMNPGO + "/" + KCOGAGGCPBP.NMGOCAFNNMM; // 04
		if(File.Exists(file))
		{
			TodoLogger.Log(0, "TODO");
		}
	}

	// // RVA: 0x11F6154 Offset: 0x11F6154 VA: 0x11F6154
	public void HJMKBCFJOOH()
	{
		TodoLogger.Log(0, "!!!");
	}
}
