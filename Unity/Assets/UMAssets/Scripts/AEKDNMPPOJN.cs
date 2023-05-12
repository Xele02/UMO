
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

public class AEKDNMPPOJN
{
	public LimitOverStatusData CMCKNKKCNDK = new LimitOverStatusData(); // 0x8
	public int OBMGLMLCGJC_ExcellentRate; // 0xC
	public int NJGBLBNALKM_ExcellentEffect; // 0x10
	public int LAAPJKFEFHK_CenterLiveSkillRate; // 0x14
	public string ABKCMICDHLN; // 0x18
	public string JFNHGLGIEMF; // 0x1C
	public string ACKDDGKFNIJ; // 0x20
	public string IBKNFJLAGIH; // 0x24
	public int DJEHLEJCPEL; // 0x28
	public int LJHOOPJACPI; // 0x2C
	public int IJEOIMGILCK; // 0x30
	public int GNKGDDMMJPF; // 0x34
	public int MJNOAMAFNHA; // 0x38
	public bool EOBACDCDGOF; // 0x3C
	public bool JMHIDPKHELB; // 0x3D
	public int DBKCPIPNKEP; // 0x40
	public bool PPIFEOJOEMO; // 0x44
	//public List<LimitOverTypeId.Type> CJLNHKNLBGH; // 0x48
	public List<string> ONABNIGCGJK; // 0x4C
	public int EKLIPGELKCL; // 0x50

	// RVA: 0x15BB8C8 Offset: 0x15BB8C8 VA: 0x15BB8C8
	public void KHEKNNFCAOI(int JKGFBFPIMGA, int DMNIMMGGJJJ, int MJBODMOLOBC)
	{
		EKLIPGELKCL = JKGFBFPIMGA;
		DJEHLEJCPEL = DMNIMMGGJJJ;
		LJHOOPJACPI = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.JNLLKKHJCAD(JKGFBFPIMGA, MJBODMOLOBC);
		if(JKGFBFPIMGA < 4)
		{
			if(LJHOOPJACPI != 0)
			{
				Debug.LogError(JpStringLiterals.StringLiteral_8676);
			}
			LJHOOPJACPI = 0;
		}
		else
		{
			int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.ELFPIODODFF(JKGFBFPIMGA);
			if (a <= LJHOOPJACPI)
				LJHOOPJACPI = a;
			IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.MNHPPJFNPCG(ref CMCKNKKCNDK, JKGFBFPIMGA, MJBODMOLOBC, DMNIMMGGJJJ);
			OBMGLMLCGJC_ExcellentRate = CMCKNKKCNDK.excellentRate;
			NJGBLBNALKM_ExcellentEffect = CMCKNKKCNDK.excellentEffect;
			LAAPJKFEFHK_CenterLiveSkillRate = CMCKNKKCNDK.centerLiveSkillRate;
			if(DMNIMMGGJJJ == a)
			{
				IJEOIMGILCK = 0;
				GNKGDDMMJPF = 0;
				MJNOAMAFNHA = 0;
				EOBACDCDGOF = false;
				JMHIDPKHELB = true;
			}
			else
			{
				int found = -1;
				for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.PIPHIPNEJCM.Count; i++)
				{
					LLKLAKGKNLD_LimitOver.ENKHACHPPFA item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.PIPHIPNEJCM[i];
					if (item.EKLIPGELKCL == JKGFBFPIMGA && item.GNFJOONKCFH == DMNIMMGGJJJ + 1)
					{
						found = i;
						break;
					}
				}
				{
					LLKLAKGKNLD_LimitOver.ENKHACHPPFA item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.PIPHIPNEJCM[found];
					MJNOAMAFNHA = item.GLCLFMGPMAN;
					IJEOIMGILCK = item.ADPPAIPFHML;
					GNKGDDMMJPF = item.ACGLMKEBMDL;
					EOBACDCDGOF = false;
					JMHIDPKHELB = false;
					JMHIDPKHELB = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.JNLLKKHJCAD(JKGFBFPIMGA, MJBODMOLOBC) < DJEHLEJCPEL + 1;
					int c = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.BKCAECPCELG();
					if (c > -1)
					{
						for(int i = 0; i < c; i++)
						{
							if(DJEHLEJCPEL + 1 <= IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.JNLLKKHJCAD(JKGFBFPIMGA, i))
							{
								DBKCPIPNKEP = i;
								break;
							}
						}
					}
				}
				PPIFEOJOEMO = true;
			}
		}
	}

	// RVA: 0x15BBE70 Offset: 0x15BBE70 VA: 0x15BBE70
	//public void OPBFFEMJBFH() { }

	// RVA: 0x15BC7A0 Offset: 0x15BC7A0 VA: 0x15BC7A0
	//public void EDNMJHBMDBK() { }

	// RVA: 0x15BCB24 Offset: 0x15BCB24 VA: 0x15BCB24
	//private string JLJOPOFHAPJ(LimitOverTypeId.Type PPFNGGCBJKC, int JBGEEPFKIGG) { }

	// RVA: 0x15BBFDC Offset: 0x15BBFDC VA: 0x15BBFDC
	//public static string MHLLBIGMHFM(LimitOverStatusData CMCKNKKCNDK) { }

	// RVA: 0x15BC390 Offset: 0x15BC390 VA: 0x15BC390
	//public static string INONJIHPOJM(LimitOverStatusData CMCKNKKCNDK) { }

	// RVA: 0x15BC3EC Offset: 0x15BC3EC VA: 0x15BC3EC
	//public static string KHMBJLKFNPH(LimitOverStatusData CMCKNKKCNDK) { }

	// RVA: 0x15BCE50 Offset: 0x15BCE50 VA: 0x15BCE50
	//public void NMIPOICAIEA(int CIEOBFIIPLD, int MJBODMOLOBC) { }

	// RVA: 0x15BD0B8 Offset: 0x15BD0B8 VA: 0x15BD0B8
	//public static int AHKFPJJKHFL(int BCCHOBPJJKE, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// RVA: 0x15BDA5C Offset: 0x15BDA5C VA: 0x15BDA5C
	//public static void LCHJNEOAMGJ(FFHPBEPOMAK JCFNFJJKPAM, DFKGGBMFFGB DJLNOAMJECI, ref int OBMGLMLCGJC, ref int NJGBLBNALKM, ref int HONONDFIICC) { }
}
