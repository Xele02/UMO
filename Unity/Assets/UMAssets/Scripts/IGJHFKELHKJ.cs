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
    
	private const int BIAOPOMKMJE = 0x28747411;
	private static uint FBGGEFFJJHB = 0x171114; // 0x0
	public Dictionary<uint, IGJHFKELHKJ.HPJEDLPEJLF> BEIEHPNODAM = new Dictionary<uint, IGJHFKELHKJ.HPJEDLPEJLF>(); // 0x8
	private string JHJMNLMNPGO_BasePath; // 0xC

	// // RVA: 0x11F4DB4 Offset: 0x11F4DB4 VA: 0x11F4DB4
	public HPJEDLPEJLF LBDOLHGDIEB(uint IOIMHJAOKOO)
	{
		if(!BEIEHPNODAM.ContainsKey(IOIMHJAOKOO))
			return null;
		return BEIEHPNODAM[IOIMHJAOKOO];
	}

	// // RVA: 0x11F4E74 Offset: 0x11F4E74 VA: 0x11F4E74
	public void IDJJFHFPNFG(uint IOIMHJAOKOO)
	{
		if(!BEIEHPNODAM.ContainsKey(IOIMHJAOKOO))
			return;
		BEIEHPNODAM[IOIMHJAOKOO].CPBPOIMHIML = true;
	}

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
	public void LBBOGOBBAAD(HPJEDLPEJLF KOGBMDOONFA)
	{
		BEIEHPNODAM.Add(KOGBMDOONFA.IOIMHJAOKOO, KOGBMDOONFA);
	}

	// // RVA: 0x11F5320 Offset: 0x11F5320 VA: 0x11F5320
	public void PCODDPDFLHK()
	{
		IGJHFKELHKJ.FBGGEFFJJHB = (uint)(Utility.GetCurrentUnixTime() + 100);
		BEIEHPNODAM.Clear();
		JHJMNLMNPGO_BasePath = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + KCOGAGGCPBP.HAFLEFNJAKD_DirSys; // /sys
		if(!Directory.Exists(JHJMNLMNPGO_BasePath))
		{
			UnityEngine.Debug.Log("Create Dir "+JHJMNLMNPGO_BasePath);
			Directory.CreateDirectory(JHJMNLMNPGO_BasePath);
		}
		string file = JHJMNLMNPGO_BasePath + "/" + KCOGAGGCPBP.PNBIAPMFPPD_File01; // 01
		if(File.Exists(file))
		{
			FileStream f = new FileStream(file, FileMode.Open);
			BinaryReader b = new BinaryReader(f);
			int header = b.ReadInt32();
			bool isValid = false;
			if(header == BIAOPOMKMJE)
			{
				isValid = true;
				int val = b.ReadInt32();
				if(val > 0)
				{
					for(int i = 0; i < val; i++)
					{
						HPJEDLPEJLF data = new HPJEDLPEJLF();
						data.IOIMHJAOKOO = b.ReadUInt32();
						b.ReadUInt32();
						data.JMGLAOBOAHM = b.ReadInt64();
						data.CPBPOIMHIML = false;
						data.LGEGIKJGCCA = b.ReadInt64();
						BEIEHPNODAM.Add(data.IOIMHJAOKOO, data);
					}
				}
			}
			b.Close();
			f.Dispose();
			if (isValid)
				return;
		}
		file = JHJMNLMNPGO_BasePath + "/" + KCOGAGGCPBP.NMGOCAFNNMM_File04; // 04
		if(File.Exists(file))
		{
			BEIEHPNODAM.Clear(); FileStream f = new FileStream(file, FileMode.Open);
			BinaryReader b = new BinaryReader(f);
			int header = b.ReadInt32();
			if (header == BIAOPOMKMJE)
			{
				int val = b.ReadInt32();
				if (val > 0)
				{
					for (int i = 0; i < val; i++)
					{
						HPJEDLPEJLF data = new HPJEDLPEJLF();
						data.IOIMHJAOKOO = b.ReadUInt32();
						b.ReadUInt32();
						data.JMGLAOBOAHM = b.ReadInt64();
						data.CPBPOIMHIML = false;
						data.LGEGIKJGCCA = b.ReadInt64();
						BEIEHPNODAM.Add(data.IOIMHJAOKOO, data);
					}
				}
			}
			b.Close();
			f.Dispose();
		}
	}

	// // RVA: 0x11F6154 Offset: 0x11F6154 VA: 0x11F6154
	public void HJMKBCFJOOH()
	{
		JHJMNLMNPGO_BasePath = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + KCOGAGGCPBP.HAFLEFNJAKD_DirSys;
		if(!Directory.Exists(JHJMNLMNPGO_BasePath))
		{
			Directory.CreateDirectory(JHJMNLMNPGO_BasePath);
		}
		string p1 = JHJMNLMNPGO_BasePath + "/" + KCOGAGGCPBP.PNBIAPMFPPD_File01;
		string p2 = JHJMNLMNPGO_BasePath + "/" + KCOGAGGCPBP.NMGOCAFNNMM_File04;
		uint[] k = new uint[BEIEHPNODAM.Keys.Count];
		BEIEHPNODAM.Keys.CopyTo(k, 0);
		HPJEDLPEJLF[] v = new HPJEDLPEJLF[BEIEHPNODAM.Values.Count];
		BEIEHPNODAM.Values.CopyTo(v, 0);
		int s = 0;
		for(int i = 0; i < k.Length; i++)
		{
			s += v[i].CPBPOIMHIML ? 1 : 0;
		}
		MemoryStream ms = new MemoryStream();
		BinaryWriter bw = new BinaryWriter(ms);
		bw.Write(BIAOPOMKMJE);
		bw.Write(s);
		for(int i = 0; i < k.Length; i++)
		{
			if(v[i].CPBPOIMHIML)
			{
				bw.Write(k[i]);
				bw.Write(0);
				bw.Write(v[i].JMGLAOBOAHM);
				bw.Write(v[i].LGEGIKJGCCA);
			}
		}
		byte[] bytes = ms.ToArray();
		bw.Dispose();
		ms.Dispose();
		File.WriteAllBytes(p1, bytes);
		File.WriteAllBytes(p2, bytes);
	}
}
