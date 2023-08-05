using System.Collections.Generic;
using System;
using System.Text;
using System.IO;
using UnityEngine;
using XeApp.Native;

public class PKECIDPBEFL
{
    public class DDBKLMKKCDL
    {
        public int BLJIJENHBPM_Id; // 0x8
        public double OACABIDEMGG_Score; // 0x10
        public int OBGBAOLONDD_Unq; // 0x18
        public int NOBCHBHEPNC_Idx; // 0x1C
        public int DKJENPIJMAK_Rank; // 0x20
        public bool POOLBEALDMA_DroppedPlayer; // 0x24
    }
	public const long BBEGLBMOBOF = 0x1719a2f1e73;
	public const int FBGGEFFJJHB = 0x2242f969;
	private const int MPLGOGILHHF = 0x15f7f449;
	private const int JDNKJIFMONK = 1;
	private const int EHMLNEGODOF = 0x96ac50;
	private const int KCFFFBGPDBO = 0x299ce1af;
	public const int FLMEHINJLML = 0;
	public const int ALBBIJHHKLA = 4;
	public const int FMKHNDEBJOG = 8;
	public const int NEODGGKALPE = 12;
	public const int GABFOFFILDF = 16;
	public const int GDIKOINOMMO = 16;
	public const int CLJDLAIMCOB = 4;
	public int JFFMOOLBCEC; // 0x8
	public int IMOMGKMFPBL; // 0xC
	public int HGGDHFDIFFG; // 0x10
	public int HJAHECBPNKM; // 0x14
	public List<PKECIDPBEFL.DDBKLMKKCDL> JPDPFGFMKHK_Ranking = new List<PKECIDPBEFL.DDBKLMKKCDL>(); // 0x18
	public List<string> PKIKNGJNJJH_RankKeys = new List<string>(); // 0x1C
	public List<int> LMKDNNCAAIJ_RankCloseDate = new List<int>(); // 0x20
	public List<string> PLMMGCFLFGC_Keys = new List<string>(); // 0x24
	public List<int> MEGNAIJPBFF_CloseDate = new List<int>(); // 0x28
	public List<string> OHNJJIMGKGK_Names = new List<string>(); // 0x2C
	public bool CHDDDCCHJJH_Replace; // 0x30
	public EDOHBJAPLPF_JsonData HJDBGMMPPEF_Player; // 0x34
	public List<PBJPACKDIIB.IFCOFHAFMON> CFLLEDGILPK_CoopQuest = new List<PBJPACKDIIB.IFCOFHAFMON>(); // 0x38
	public EDOHBJAPLPF_JsonData LAEMKLPEIAK_Logs; // 0x3C
	public string ECAOENGDBMI_SaveHash; // 0x40
	private long AFNACNGGLBD; // 0x48
	private long IPOONAJLNMD; // 0x50
	private long DCLLGOECHPA; // 0x58
	private int KNKBLHJABLA; // 0x60
	public List<int> BIOBLLHBKBC_Gpgs = new List<int>(); // 0x64
	public bool GKMONHIBHCL; // 0x68
	public string HNDDJDMAAJD; // 0x6C
	public int CPBPFGEDMAO; // 0x70

	public long IAGGEOPLJIN_LimitAt { get { return AFNACNGGLBD ^ BBEGLBMOBOF; } set { AFNACNGGLBD = value ^ BBEGLBMOBOF; } } //0x93A3D8 FEPMDKOJEAA 0x93A3F4 IHONMIKPHKO
	public long IKHKMFNIHKH_PlayAt { get { return IPOONAJLNMD ^ BBEGLBMOBOF; } set { IPOONAJLNMD = value ^ BBEGLBMOBOF; } } //0x93A414 IHGJDEMGLAF 0x93A430 JGIIPDMBIBH
	public long EHGBICNIBKE_Pid { get { return DCLLGOECHPA ^ BBEGLBMOBOF; } set { DCLLGOECHPA = value ^ BBEGLBMOBOF; } } //0x93A450 OMMOMEDOFNO 0x93A46C GKBOGMILGJE
	public int OKJNNGJJOFA_RaidBossId { get { return KNKBLHJABLA ^ FBGGEFFJJHB; } set { KNKBLHJABLA = value ^ FBGGEFFJJHB; } } //0x93A48C NCKKKAHNJJB 0x93A4A0 AMIPKODLKDN

	// RVA: 0x93A4B4 Offset: 0x93A4B4 VA: 0x93A4B4
	public PKECIDPBEFL()
    {
        if(DOKOHKJIDBO.HHCJCDFCLOB != null)
        {
            if(DOKOHKJIDBO.HHCJCDFCLOB.IKCAJDOKNOM != null)
            {
                IMOMGKMFPBL = DOKOHKJIDBO.HHCJCDFCLOB.IKCAJDOKNOM.LPJLEHAJADA("s_0", 0);
                HGGDHFDIFFG = DOKOHKJIDBO.HHCJCDFCLOB.IKCAJDOKNOM.LPJLEHAJADA("s_1", 0);
                HJAHECBPNKM = DOKOHKJIDBO.HHCJCDFCLOB.IKCAJDOKNOM.LPJLEHAJADA("s_2", 0);
                JFFMOOLBCEC = DOKOHKJIDBO.HHCJCDFCLOB.IKCAJDOKNOM.LPJLEHAJADA("s_3", 0);
            }
        }
        LHPDDGIJKNB();
    }

	// // RVA: 0x93A8F4 Offset: 0x93A8F4 VA: 0x93A8F4
	public void DOMFHDPMCCO(List<DDBKLMKKCDL> JPDPFGFMKHK, List<string> PNMLDKNKIIM, List<int> CIGDBPLIGKM, List<string> JIMKNDJMCID, List<int> EMEKFFHCHMH, bool DCOJMLNFPFM, List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData NMICBJDPLOH, EDOHBJAPLPF_JsonData LAEMKLPEIAK, List<int> BIOBLLHBKBC, long IKHKMFNIHKH, long IAGGEOPLJIN, string ECAOENGDBMI, int OKJNNGJJOFA, List<PBJPACKDIIB.IFCOFHAFMON> CFLLEDGILPK)
	{
		LHPDDGIJKNB();
		HNDDJDMAAJD = JAFAIDPJALG();
		if (JPDPFGFMKHK != null)
			JPDPFGFMKHK_Ranking.AddRange(JPDPFGFMKHK);
		PKIKNGJNJJH_RankKeys.Clear();
		if (PNMLDKNKIIM != null)
			PKIKNGJNJJH_RankKeys.AddRange(PNMLDKNKIIM);
		if (CIGDBPLIGKM != null)
			LMKDNNCAAIJ_RankCloseDate.AddRange(CIGDBPLIGKM);
		if (JIMKNDJMCID != null)
			PLMMGCFLFGC_Keys.AddRange(JIMKNDJMCID);
		if (EMEKFFHCHMH != null)
			MEGNAIJPBFF_CloseDate.AddRange(EMEKFFHCHMH);
		if (BIOBLLHBKBC != null)
			BIOBLLHBKBC_Gpgs.AddRange(BIOBLLHBKBC);
		IKHKMFNIHKH_PlayAt = IKHKMFNIHKH;
		IAGGEOPLJIN_LimitAt = IAGGEOPLJIN;
		OHNJJIMGKGK_Names = OHNJJIMGKGK;
		CHDDDCCHJJH_Replace = DCOJMLNFPFM;
		HJDBGMMPPEF_Player = NMICBJDPLOH;
		LAEMKLPEIAK_Logs = LAEMKLPEIAK;
		ECAOENGDBMI_SaveHash = ECAOENGDBMI;
		DCLLGOECHPA = NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId;
		OKJNNGJJOFA_RaidBossId = OKJNNGJJOFA;
		if(CFLLEDGILPK != null)
			CFLLEDGILPK_CoopQuest.AddRange(CFLLEDGILPK);
	}

	// // RVA: 0x93A710 Offset: 0x93A710 VA: 0x93A710
	public void LHPDDGIJKNB()
    {
        JPDPFGFMKHK_Ranking.Clear();
        PKIKNGJNJJH_RankKeys.Clear();
        LMKDNNCAAIJ_RankCloseDate.Clear();
        PLMMGCFLFGC_Keys.Clear();
        MEGNAIJPBFF_CloseDate.Clear();
        BIOBLLHBKBC_Gpgs.Clear();
		IAGGEOPLJIN_LimitAt = 0;
		IKHKMFNIHKH_PlayAt = 0;
        HJDBGMMPPEF_Player = null;
        CHDDDCCHJJH_Replace = false;
        LAEMKLPEIAK_Logs = null;
        ECAOENGDBMI_SaveHash = "";
		EHGBICNIBKE_Pid = 0;
		OKJNNGJJOFA_RaidBossId = 0;
        CFLLEDGILPK_CoopQuest.Clear();
    }

	// // RVA: 0x93AE4C Offset: 0x93AE4C VA: 0x93AE4C
	private EDOHBJAPLPF_JsonData KDMHABGINMG()
	{
		EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
		{
			EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
			data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			if (JPDPFGFMKHK_Ranking != null)
			{
				for (int i = 0; i < JPDPFGFMKHK_Ranking.Count; i++)
				{
					EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
					data2["id"] = JPDPFGFMKHK_Ranking[i].BLJIJENHBPM_Id;
					data2["sc"] = JPDPFGFMKHK_Ranking[i].OACABIDEMGG_Score;
					data2["unq"] = JPDPFGFMKHK_Ranking[i].OBGBAOLONDD_Unq;
					data2["idx"] = JPDPFGFMKHK_Ranking[i].NOBCHBHEPNC_Idx;
					data.Add(data2);
				}
			}
			res["rankings"] = data;
		}
		{
			EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
			data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			if (PKIKNGJNJJH_RankKeys != null)
			{
				for (int i = 0; i < PKIKNGJNJJH_RankKeys.Count; i++)
				{
					data.Add(PKIKNGJNJJH_RankKeys[i]);
				}
			}
			res["r_keys"] = data;
		}
		{
			EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
			data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			if (LMKDNNCAAIJ_RankCloseDate != null)
			{
				for (int i = 0; i < LMKDNNCAAIJ_RankCloseDate.Count; i++)
				{
					data.Add(LMKDNNCAAIJ_RankCloseDate[i]);
				}
			}
			res["r_closedat"] = data;
		}
		{
			EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
			data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			if (PLMMGCFLFGC_Keys != null)
			{
				for (int i = 0; i < PLMMGCFLFGC_Keys.Count; i++)
				{
					data.Add(PLMMGCFLFGC_Keys[i]);
				}
			}
			res["keys"] = data;
		}
		{
			EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
			data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			if (MEGNAIJPBFF_CloseDate != null)
			{
				for (int i = 0; i < MEGNAIJPBFF_CloseDate.Count; i++)
				{
					data.Add(MEGNAIJPBFF_CloseDate[i]);
				}
			}
			res["closedat"] = data;
		}
		{
			EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
			data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			if (OHNJJIMGKGK_Names != null)
			{
				for (int i = 0; i < OHNJJIMGKGK_Names.Count; i++)
				{
					data.Add(OHNJJIMGKGK_Names[i]);
				}
			}
			res["names"] = data;
		}
		{
			EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
			data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			if (BIOBLLHBKBC_Gpgs != null)
			{
				for (int i = 0; i < BIOBLLHBKBC_Gpgs.Count; i++)
				{
					data.Add(BIOBLLHBKBC_Gpgs[i]);
				}
			}
			res["gpgs"] = data;
		}
		res["replace"] = CHDDDCCHJJH_Replace;
		res["player"] = HJDBGMMPPEF_Player;
		res["logs"] = LAEMKLPEIAK_Logs;
		res["ver"] = AppInfo.buildVersion;
		res["limit_at"] = IAGGEOPLJIN_LimitAt;
		res["play_at"] = IKHKMFNIHKH_PlayAt;
		res["pid"] = EHGBICNIBKE_Pid;
		res["save_hash"] = ECAOENGDBMI_SaveHash;
		res["raidboss_id"] = OKJNNGJJOFA_RaidBossId;
		{
			EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
			data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			if (CFLLEDGILPK_CoopQuest != null)
			{
				for (int i = 0; i < CFLLEDGILPK_CoopQuest.Count; i++)
				{
					EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
					data2["eid"] = CFLLEDGILPK_CoopQuest[i].EKANGPODCEP_EId;
					data2["qid"] = CFLLEDGILPK_CoopQuest[i].CMEJFJFOIIJ_QId;
					data2["lid"] = CFLLEDGILPK_CoopQuest[i].AIBFGKBACCB_LId;
					data2["sta"] = CFLLEDGILPK_CoopQuest[i].FKPEAGGKNLC_Start;
					data2["end"] = CFLLEDGILPK_CoopQuest[i].KOMKKBDABJP_End;
					data2["dai"] = CFLLEDGILPK_CoopQuest[i].CGHNCPEKOCK_Dai;
					data.Add(data2);
				}
			}
			res["coop_quests"] = data;
		}
		return res;
	}

	// // RVA: 0x93C0E8 Offset: 0x93C0E8 VA: 0x93C0E8
	public byte[] FGLEBCABKCF(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		byte[] b_ = Encoding.UTF8.GetBytes(OILEIIEIBHP.EJCOJCGIBNG_ToJson());
		uint a = BEEINMBNKNM_Encryption.GKBODMNBFJM(KCFFFBGPDBO, b_);
		byte[] buffer = new byte[b_.Length + 20];
		MemoryStream ms = new MemoryStream(buffer);
		BinaryWriter bw = new BinaryWriter(ms);
		bw.Write(MPLGOGILHHF);
		bw.Write(1);
		bw.Write(a);
		bw.Write(b_.Length);
		bw.Write(b_);
		bw.Write(EHMLNEGODOF);
		bw.Close();
		bw.Dispose();
		ms.Dispose();
		BEEINMBNKNM_Encryption encode = new BEEINMBNKNM_Encryption();
		encode.KHEKNNFCAOI_Init((uint)JFFMOOLBCEC);
		encode.DGBPHDMEDNP(IMOMGKMFPBL, HGGDHFDIFFG, HJAHECBPNKM);
		encode.LBGGPBBOIEH(buffer);
		encode.AAGCKDHEMFD_GenerateKey();
		return buffer;
	}

	// // RVA: 0x93C5CC Offset: 0x93C5CC VA: 0x93C5CC
	// private EDOHBJAPLPF CLNHGLGOKPF(byte[] NIODCJLINJN) { }

	// // RVA: 0x93CBD4 Offset: 0x93CBD4 VA: 0x93CBD4
	public void MIABDPJHEHK(byte[] NIODCJLINJN)
    {
        TodoLogger.LogError(0, "TODO");
    }

	// // RVA: 0x93AC74 Offset: 0x93AC74 VA: 0x93AC74
	private string JAFAIDPJALG()
    {
        BEEINMBNKNM_Encryption.GKBODMNBFJM(0x299ce1af, BitConverter.GetBytes(NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId));
        StringBuilder str = new StringBuilder();
        str.Append(Application.persistentDataPath);
        str.AppendFormat("/61/{0:x}", NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId);
        return str.ToString();
    }

	// // RVA: 0x93DABC Offset: 0x93DABC VA: 0x93DABC
	public void IJLKLIHFMBG()
	{
		string dirName = Path.GetDirectoryName(HNDDJDMAAJD);
		if (!Directory.Exists(dirName))
			Directory.CreateDirectory(dirName);
		FileStream fs = new FileStream(HNDDJDMAAJD, FileMode.Create, FileAccess.Write);
		byte[] b_ = FGLEBCABKCF(KDMHABGINMG());
		fs.Write(b_, 0, b_.Length);
		fs.Close();
	}

	// // RVA: 0x93DD14 Offset: 0x93DD14 VA: 0x93DD14
	public void PEHBBKFGLNO()
    {
        GKMONHIBHCL = false;
        LHPDDGIJKNB();
        string path = JAFAIDPJALG();
        TodoLogger.Log(TodoLogger.Filesystem, "Try load " + path);
        if(File.Exists(path))
        {
            MIABDPJHEHK(File.ReadAllBytes(path));
            if(CPBPFGEDMAO > 0)
            {
                throw new Exception("code="+CPBPFGEDMAO);
            }
        }
    }

	// // RVA: 0x93DF78 Offset: 0x93DF78 VA: 0x93DF78
	public void OJCJPCHFPGO()
    {
        string path = JAFAIDPJALG();
        string dirName = Path.GetDirectoryName(path);
        if(!Directory.Exists(dirName))
            return;
        TodoLogger.Log(TodoLogger.Filesystem, "Delete dir " + dirName);
        Directory.Delete(dirName, true);
    }

	// // RVA: 0x93E0BC Offset: 0x93E0BC VA: 0x93E0BC
	public static void GDELLNOBNDM_DeleteCache()
	{
		StringBuilder str = new StringBuilder();
		str.Append(Application.persistentDataPath);
		str.Append("/61");
		if (Directory.Exists(str.ToString()))
			Directory.Delete(str.ToString(), true);
	}

	// // RVA: 0x93E26C Offset: 0x93E26C VA: 0x93E26C
	// public static void KCCCOEMPPEA() { }
}
