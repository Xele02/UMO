
using System;
using System.Collections.Generic;
using System.Linq;
using XeSys;

[System.Obsolete("Use JLOGEHCIBEJ_EventRaid", true)]
public class JLOGEHCIBEJ { }
public class JLOGEHCIBEJ_EventRaid : KLFDBFMNLBL_ServerSaveBlock
{
	public enum JJAFLOEBLDH
	{
		CCAPCGPIIPF_1_Normal = 1, // Support
		LPNPLGJJCPC_2 = 2,
		OOEHFFBHCIC_3_Full = 3, // FullPower
		EKIGHDLEBAH_4_MacrossCanon = 4,
		CKPGGPDJCAL_5 = 5
	}

	public class PMJBKKNNNEM
	{
		public struct PHIONIAFEIP
		{
			public CEBFFLDKAEC_SecureInt JOMGCCBFKEF_MissionId; // 0x0
			public CEBFFLDKAEC_SecureInt IELDJLGIKGC_PlayCount; // 0x4
			public CEBFFLDKAEC_SecureInt AAFHFMDKKDE_AssistCount; // 0x8
			public CEBFFLDKAEC_SecureInt OMNJALHBFCG_RequestCount; // 0xC
			public KCKKMNOELLB_SecureLong JLNIAIJKEHC_LastRequestTime; // 0x10
			public CEBFFLDKAEC_SecureInt ECFIOMGFCDJ_OverLimitHelp; // 0x14
			public static string KLMIFEKNBLL_m_id = "mission_id"; // 0x0
			public static string KBKPCNIFLAM_PlayCount = "play_count"; // 0x4
			public static string GPNHBMLJHGA_AssistCount = "assist_count"; // 0x8
			public static string PONECEJICJC_RequestCount = "request_count"; // 0xC
			public static string OOFCCOMCOLD_LastRequestTime = "last_request_time"; // 0x10
			public static string KJEPKLLCJOD_OverLimitHelp = "over_limit_help"; // 0x14
		}

		private int ENOBDCFHELD; // 0x8
		private int FCEJCHGLFGN; // 0xC
		private long AADPAJOLEEF_PointCrypted; // 0x10
		private long IOJOBGHPLIE_PointCrypted; // 0x18
		private long DLEEMCAPOBP_Crypted; // 0x20
		private long JPNMMOEPAEM_Crypted; // 0x28
		public int AFGHJEJKDHN_StepCrypted; // 0x30
		public int FBDJBMDEENG_StepCrypted2; // 0x34
		private sbyte MLLPMIHMMFL_Crypted; // 0x38
		private int HFIHMDILNFD_LbCrypted; // 0x3C
		private int IGMFFIKLEHP_LbCrypted2; // 0x40
		private int IOAHLDEMPOD_Crypted; // 0x44
		private int OEGPFIDLBGN_Crypted; // 0x48
		private long BFGNKOJKKFE_Crypted; // 0x50
		private long FOENKEHHBNI_Crypted; // 0x58
		private int HBBHPIJNIMJ_Crypted; // 0x60
		private int MAJIPCGOEEP_Crypted; // 0x64
		private int ICANINEMJBH_Crypted; // 0x68
		private int DNLOFPBEMNH_Crypted; // 0x6C
		private sbyte JBOCIADFMEA_Crypted; // 0x70
		private sbyte PICDFKNKFLG_Crypted; // 0x71
		private sbyte MAJCFIBNBPP_Crypted; // 0x72
		private Dictionary<int, byte[]> FKJINLKCKJK_McannonScene = new Dictionary<int, byte[]>(8); // 0x74
		private List<CEBFFLDKAEC_SecureInt> JMPBGDLHAPE_MyBossAtkCount = new List<CEBFFLDKAEC_SecureInt>(4); // 0x78
		private List<CEBFFLDKAEC_SecureInt> FJDKDGBKGLB_BossList = new List<CEBFFLDKAEC_SecureInt>(20); // 0x7C
		private Dictionary<int, PHIONIAFEIP> BPMCABFPPHI_MissionList = new Dictionary<int, PHIONIAFEIP>(20); // 0x80
		public List<IKCGAJKCPFN> NNMPGOAGEOL_quests = new List<IKCGAJKCPFN>(100); // 0x84
		public string MPCAGEPEJJJ_Key; // 0x88
		public long EGBOHDFBAPB_closed_at; // 0x90
		public bool IMFBCJOIJKJ_Entry; // 0x98
		public bool ABBJBPLHFHA_Spurt; // 0x99
		public int INLNJOGHLJE_Show; // 0x9C
		public int MHKICPIMFEI_PlayCount; // 0xA0
		public string MDADLCOCEBN_session_id = ""; // 0xA4
		public int LIEKIBHAPKC_FId; // 0xA8

		public bool HPLMECLKFID_RRcv { get { return MLLPMIHMMFL_Crypted == 113; } set { MLLPMIHMMFL_Crypted = (sbyte)(value ? 113 : 50); } } //0x147D9BC DCHHABKOMFP_bgs 0x147FEAC EGGIBMLGCOJ_bgs
		public bool OKEJGGCMAAI_PlaRcv { get { return JBOCIADFMEA_Crypted == 80; } set { JBOCIADFMEA_Crypted = (sbyte)(value ? 80 : 145); } } //0x147D9F0 CLGCKBAEJHF_bgs 0x147FEDC AHFMKDDCFAM_bgs
		public bool CGMMMJCIDFE_EpaRcv { get { return PICDFKNKFLG_Crypted == 98; } set { PICDFKNKFLG_Crypted = (sbyte)(value ? 98 : 66); } } //0x147DA04 AIBENAPCPJI_bgs 0x147FF0C FKKHHKCJEII_bgs
		public bool KILJKLIHMAE_SboRcv { get { return MAJCFIBNBPP_Crypted == 55; } set { MAJCFIBNBPP_Crypted = (sbyte)(value ? 55 : 146); } } //0x147DA18 IJOBIBMOCAJ_bgs 0x147FF3C GBBEDONIGLO_bgs
		public long DNBFMLBNAEE_point { get { return AADPAJOLEEF_PointCrypted ^ ENOBDCFHELD; } set { value = value >= 100000000 ? 99999999 : value; AADPAJOLEEF_PointCrypted = value ^ ENOBDCFHELD; IOJOBGHPLIE_PointCrypted = value ^ FCEJCHGLFGN; } } // 0x147D98C JKHIIAEMMDE_bgs 0x147FDEC PFFKLBLEPKB_bgs
		public long NFIOKIBPJCJ_uptime { get { return DLEEMCAPOBP_Crypted ^ ENOBDCFHELD; } set { DLEEMCAPOBP_Crypted = value ^ ENOBDCFHELD; JPNMMOEPAEM_Crypted = value ^ FCEJCHGLFGN; } } //0x147D9A4 NGIDBCKCAMO_bgs 0x147FE70 AEHIIPBDNGE_bgs
		public int LGADCGFMLLD_step { get { return AFGHJEJKDHN_StepCrypted ^ ENOBDCFHELD; } set { AFGHJEJKDHN_StepCrypted = value ^ ENOBDCFHELD; FBDJBMDEENG_StepCrypted2 = value ^ FCEJCHGLFGN; } } //0x147D9D0 MAFBDLKFHGJ_get_step 0x147FE98 EPEFBOIALDI_set_step
		public int OMCAOJJGOGG_Lb { get { return HFIHMDILNFD_LbCrypted ^ ENOBDCFHELD; } set { HFIHMDILNFD_LbCrypted = value ^ ENOBDCFHELD; IGMFFIKLEHP_LbCrypted2 = value ^ FCEJCHGLFGN; } } //0x147D9E0 PBEMPHPDDDB_get_Lb 0x147FF6C MCADMIEOCCF_set_Lb
		public int NOKPCBEIJHJ_ApVal { get { return IOAHLDEMPOD_Crypted ^ ENOBDCFHELD; } set { IOAHLDEMPOD_Crypted = value ^ ENOBDCFHELD; OEGPFIDLBGN_Crypted = value ^ FCEJCHGLFGN; } } //0x147DA2C OPMKDHPIMHK_bgs 0x147FF84 OELPBKEMAAG_bgs
		public long CKLPPIIKAKD_ApSaveTime { get { return BFGNKOJKKFE_Crypted ^ ENOBDCFHELD; } set { BFGNKOJKKFE_Crypted = value ^ ENOBDCFHELD; FOENKEHHBNI_Crypted = value ^ FCEJCHGLFGN; } } //0x147DA3C FHAGOEBBKKK_bgs 0x147FF9C MNOLGHMPBCN_bgs
		public int HBHCCLGECOC_MyBossId { get { return HBBHPIJNIMJ_Crypted ^ ENOBDCFHELD; } set { HBBHPIJNIMJ_Crypted = value ^ ENOBDCFHELD; MAJIPCGOEEP_Crypted = value ^ FCEJCHGLFGN; } } //0x147DA54 ACFBGMNDPBB_bgs 0x147FFC4 MABPNPENDMH_bgs
		public int BJBJHNJJCHL_AtkMcgBonus { get { return ICANINEMJBH_Crypted ^ ENOBDCFHELD; } set { ICANINEMJBH_Crypted = value ^ ENOBDCFHELD; DNLOFPBEMNH_Crypted = value ^ FCEJCHGLFGN; } } //0x147DA64 KBGIEODAIHF_bgs 0x147FFD8 NINGBBJFMCM_bgs

		// // RVA: 0x14891F8 Offset: 0x14891F8 VA: 0x14891F8
		// public bool AHDAHNCGEPL() { }

		// // RVA: 0x1489238 Offset: 0x1489238 VA: 0x1489238
		// public bool MILHIALDDLG() { }

		// // RVA: 0x148925C Offset: 0x148925C VA: 0x148925C
		// public bool HEHFNGNNGCH() { }

		// // RVA: 0x1489280 Offset: 0x1489280 VA: 0x1489280
		// public bool NJBBHANHMIC() { }

		// // RVA: 0x1489BC8 Offset: 0x1489BC8 VA: 0x1489BC8
		public void HPNHGLMMMHG(int _HMHHNHEPAPP_BossId, int _JGJPKLCCOIO_scene_id, bool _JKDJCFEBDHC_Enabled)
		{
            int idx = _JGJPKLCCOIO_scene_id - 1;
			if(idx < 6000)
			{
				if(!FKJINLKCKJK_McannonScene.ContainsKey(_HMHHNHEPAPP_BossId))
				{
                    FKJINLKCKJK_McannonScene.Add(_HMHHNHEPAPP_BossId, new byte[750]);
                }
				if(idx < 6000)
				{
					if(_JKDJCFEBDHC_Enabled)
                        FKJINLKCKJK_McannonScene[_HMHHNHEPAPP_BossId][idx >> 3] |= (byte)(1 << (idx & 7));
					else
						FKJINLKCKJK_McannonScene[_HMHHNHEPAPP_BossId][idx >> 3] &= (byte)~(1 << (idx & 7));
                }
			}
        }

		// // RVA: 0x1489D50 Offset: 0x1489D50 VA: 0x1489D50
		public void PJCGNAKDOKH(int _HMHHNHEPAPP_BossId)
		{
			FKJINLKCKJK_McannonScene.Remove(_HMHHNHEPAPP_BossId);
		}

		// // RVA: 0x1489DD0 Offset: 0x1489DD0 VA: 0x1489DD0
		public bool PHBLJOCFNHG(int _HMHHNHEPAPP_BossId, int _JGJPKLCCOIO_scene_id)
		{
            int idx = _JGJPKLCCOIO_scene_id - 1;
            if(idx < 6000)
			{
				if(FKJINLKCKJK_McannonScene.ContainsKey(_HMHHNHEPAPP_BossId))
				{
                    return ((1 << (idx & 7)) & FKJINLKCKJK_McannonScene[_HMHHNHEPAPP_BossId][idx >> 3]) != 0;
                }
			}
            return false;
        }

		// // RVA: 0x1489F0C Offset: 0x1489F0C VA: 0x1489F0C
		public List<int> HBBNJHLHPDH()
		{
			List<int> res = new List<int>(FKJINLKCKJK_McannonScene.Count);
			foreach(var k in FKJINLKCKJK_McannonScene.Keys)
			{
				res.Add(k);
			}
			return res;
		}

		// // RVA: 0x148A10C Offset: 0x148A10C VA: 0x148A10C
		private bool CBGPNDNBMDN(Dictionary<int, byte[]> NCFOLBDMHGO)
		{
			if(FKJINLKCKJK_McannonScene.Count != NCFOLBDMHGO.Count)
				return false;
			foreach(var k in NCFOLBDMHGO.Keys)
			{
				if(!FKJINLKCKJK_McannonScene.ContainsKey(k))
					return false;
				if(!FKJINLKCKJK_McannonScene[k].SequenceEqual(NCFOLBDMHGO[k]))
					return false;
			}
			return true;
		}

		// // RVA: 0x147FFEC Offset: 0x147FFEC VA: 0x147FFEC
		public void LJKCCFMDCCN(int _LJNAKDMILMC_key, byte[] _NANNGLGOFKH_value)
		{
			FKJINLKCKJK_McannonScene[_LJNAKDMILMC_key] = _NANNGLGOFKH_value;
		}

		// // RVA: 0x147D70C Offset: 0x147D70C VA: 0x147D70C
		public void ILHFNBFDNPO(Action<int, byte[]> _ADKIDBJCAJA_action)
		{
            Dictionary<int, byte[]>.KeyCollection k = FKJINLKCKJK_McannonScene.Keys;
			foreach(var key in k)
			{
				_ADKIDBJCAJA_action(key, FKJINLKCKJK_McannonScene[key]);
			}
        }

		// // RVA: 0x14892C0 Offset: 0x14892C0 VA: 0x14892C0
		// public bool IOCGEDLLAPM() { }

		// // RVA: 0x14892E0 Offset: 0x14892E0 VA: 0x14892E0
		// public bool DOBNKAKAGGP() { }

		// // RVA: 0x147D8EC Offset: 0x147D8EC VA: 0x147D8EC
		public int KAHKFBKIMBE_GetMyBossAttackCount(JJAFLOEBLDH _INDDJNMPONH_type)
		{
			return JMPBGDLHAPE_MyBossAtkCount[(int)_INDDJNMPONH_type - 1].DNJEJEANJGL_Value;
		}

		// // RVA: 0x14899EC Offset: 0x14899EC VA: 0x14899EC
		public void GNDJFKNNMHD(JJAFLOEBLDH _INDDJNMPONH_type, int _HMFFHLPNMPH_count)
		{
			JMPBGDLHAPE_MyBossAtkCount[(int)_INDDJNMPONH_type - 1].DNJEJEANJGL_Value = _HMFFHLPNMPH_count;
		}

		// // RVA: 0x148A3D4 Offset: 0x148A3D4 VA: 0x148A3D4
		public void CPPNJFGEBNM_ResetMyBossAttacksCount()
		{
			for(int i = 0; i < JMPBGDLHAPE_MyBossAtkCount.Count; i++)
			{
				JMPBGDLHAPE_MyBossAtkCount[i].DNJEJEANJGL_Value = 0;
			}
		}

		// // RVA: 0x1489300 Offset: 0x1489300 VA: 0x1489300
		// public bool GIBMOMGFCAB() { }

		// // RVA: 0x147DA74 Offset: 0x147DA74 VA: 0x147DA74
		public int ABIMDFJNEMI()
		{
			return FJDKDGBKGLB_BossList.Count;
		}

		// // RVA: 0x147DAEC Offset: 0x147DAEC VA: 0x147DAEC
		public int ADEKOBLCCGC(int _OIPCCBHIKIA_index)
		{
			return FJDKDGBKGLB_BossList[_OIPCCBHIKIA_index].DNJEJEANJGL_Value;
		}

		// // RVA: 0x1480074 Offset: 0x1480074 VA: 0x1480074
		public void BADLOIKHGLK()
		{
			FJDKDGBKGLB_BossList.Clear();
		}

		// // RVA: 0x148A4B4 Offset: 0x148A4B4 VA: 0x148A4B4
		public bool OFJNLMIHMDE(int _PPFNGGCBJKC_id)
		{
			return FJDKDGBKGLB_BossList.Find((CEBFFLDKAEC_SecureInt OHDPMGMGJBI) =>
			{
				//0x1B8D58C
				return OHDPMGMGJBI.DNJEJEANJGL_Value == _PPFNGGCBJKC_id;
			}) != null;
		}

		// // RVA: 0x1489ACC Offset: 0x1489ACC VA: 0x1489ACC
		public void NBCJGLLLFOH(int _PPFNGGCBJKC_id)
		{
			CEBFFLDKAEC_SecureInt v = new CEBFFLDKAEC_SecureInt();
			v.DNJEJEANJGL_Value = _PPFNGGCBJKC_id;
			FJDKDGBKGLB_BossList.Add(v);
		}

		// // RVA: 0x148A5B4 Offset: 0x148A5B4 VA: 0x148A5B4
		// public void AJEGDIGEEHP(int _PPFNGGCBJKC_id) { }

		// // RVA: 0x14893F0 Offset: 0x14893F0 VA: 0x14893F0
		// public bool GGBCNKCPIAC() { }

		// // RVA: 0x14800EC Offset: 0x14800EC VA: 0x14800EC
		public void LGJLABFMGHG()
		{
			BPMCABFPPHI_MissionList.Clear();
		}

		// // RVA: 0x148A6E8 Offset: 0x148A6E8 VA: 0x148A6E8
		public int NHGJFJBEIBL_GetNumMissions()
		{
			return BPMCABFPPHI_MissionList.Count;
		}

		// // RVA: 0x148A760 Offset: 0x148A760 VA: 0x148A760
		public bool MPOLPHDMBKA(int KCNAEONFIBP)
		{
			return BPMCABFPPHI_MissionList.ContainsKey(KCNAEONFIBP);
		}

		// // RVA: 0x148A7E0 Offset: 0x148A7E0 VA: 0x148A7E0
		public bool LDJPDEHJFOC(int KCNAEONFIBP, out int _FCBDGLEPGFJ_mid)
		{
			if(BPMCABFPPHI_MissionList.Count > 0)
			{
				if(BPMCABFPPHI_MissionList.ContainsKey(KCNAEONFIBP))
				{
					if(BPMCABFPPHI_MissionList[KCNAEONFIBP].JOMGCCBFKEF_MissionId != null)
					{
						_FCBDGLEPGFJ_mid = BPMCABFPPHI_MissionList[KCNAEONFIBP].JOMGCCBFKEF_MissionId.DNJEJEANJGL_Value;
						return true;
					}
				}
			}
			_FCBDGLEPGFJ_mid = 1;
			return false;
		}

		// // RVA: 0x1480164 Offset: 0x1480164 VA: 0x1480164
		public void BEDGDKOCGEE(int KCNAEONFIBP, int _JOMGCCBFKEF_MissionId, int HKFGPNJPFAD, int EBMJBOLJOEC, int MIFBGIDBFAO, long IOAEPKFIBDG, int HBJMPOPKOKK)
		{
			CEBFFLDKAEC_SecureInt v1 = new CEBFFLDKAEC_SecureInt();
			CEBFFLDKAEC_SecureInt v2 = new CEBFFLDKAEC_SecureInt();
			CEBFFLDKAEC_SecureInt v3 = new CEBFFLDKAEC_SecureInt();
			CEBFFLDKAEC_SecureInt v4 = new CEBFFLDKAEC_SecureInt();
			KCKKMNOELLB_SecureLong v5 = new KCKKMNOELLB_SecureLong();
			CEBFFLDKAEC_SecureInt v6 = new CEBFFLDKAEC_SecureInt();
			v1.LHPDDGIJKNB_Reset(ENOBDCFHELD, FCEJCHGLFGN);
			v1.DNJEJEANJGL_Value = _JOMGCCBFKEF_MissionId;
			v2.LHPDDGIJKNB_Reset(ENOBDCFHELD, FCEJCHGLFGN);
			v2.DNJEJEANJGL_Value = HKFGPNJPFAD;
			v3.LHPDDGIJKNB_Reset(ENOBDCFHELD, FCEJCHGLFGN);
			v3.DNJEJEANJGL_Value = EBMJBOLJOEC;
			v4.LHPDDGIJKNB_Reset(ENOBDCFHELD, FCEJCHGLFGN);
			v4.DNJEJEANJGL_Value = MIFBGIDBFAO;
			v5.LHPDDGIJKNB_Reset(ENOBDCFHELD, FCEJCHGLFGN);
			v5.DNJEJEANJGL_Value = IOAEPKFIBDG;
			v6.LHPDDGIJKNB_Reset(ENOBDCFHELD, FCEJCHGLFGN);
			v6.DNJEJEANJGL_Value = HBJMPOPKOKK;
			BPMCABFPPHI_MissionList.Add(KCNAEONFIBP, new PHIONIAFEIP()
			{
				JOMGCCBFKEF_MissionId = v1,
				IELDJLGIKGC_PlayCount = v2,
				AAFHFMDKKDE_AssistCount = v3,
				OMNJALHBFCG_RequestCount = v4,
				JLNIAIJKEHC_LastRequestTime = v5,
				ECFIOMGFCDJ_OverLimitHelp = v6
			});
		}

		// // RVA: 0x148A914 Offset: 0x148A914 VA: 0x148A914
		public void IPNJMALJDKM_AddPlayCount(int KCNAEONFIBP, int _IELDJLGIKGC_PlayCount)
		{
			BPMCABFPPHI_MissionList[KCNAEONFIBP].IELDJLGIKGC_PlayCount.DNJEJEANJGL_Value += _IELDJLGIKGC_PlayCount;
		}

		// // RVA: 0x148A9F4 Offset: 0x148A9F4 VA: 0x148A9F4
		public int OEENOAGJKJK_GetPlayCount(int KCNAEONFIBP)
		{
			return BPMCABFPPHI_MissionList[KCNAEONFIBP].IELDJLGIKGC_PlayCount.DNJEJEANJGL_Value;
		}

		// // RVA: 0x148AAA0 Offset: 0x148AAA0 VA: 0x148AAA0
		public void KCBGMGHNKMB_AddAssistCount(int KCNAEONFIBP, int EBMJBOLJOEC)
		{
			BPMCABFPPHI_MissionList[KCNAEONFIBP].AAFHFMDKKDE_AssistCount.DNJEJEANJGL_Value += EBMJBOLJOEC;
		}

		// // RVA: 0x148AB80 Offset: 0x148AB80 VA: 0x148AB80
		public int IEPDBGCJDEP_GetAssistCount(int KCNAEONFIBP)
		{
			return BPMCABFPPHI_MissionList[KCNAEONFIBP].AAFHFMDKKDE_AssistCount.DNJEJEANJGL_Value;
		}

		// // RVA: 0x148AC2C Offset: 0x148AC2C VA: 0x148AC2C
		public void EEPAJLBMEII_AddRequestCount(int KCNAEONFIBP, int JLFNEBBFCIA)
		{
			BPMCABFPPHI_MissionList[KCNAEONFIBP].OMNJALHBFCG_RequestCount.DNJEJEANJGL_Value += JLFNEBBFCIA;
		}

		// // RVA: 0x148AD0C Offset: 0x148AD0C VA: 0x148AD0C
		public int LNCILHPNOGP_GetRequestCount(int KCNAEONFIBP)
		{
			return BPMCABFPPHI_MissionList[KCNAEONFIBP].OMNJALHBFCG_RequestCount.DNJEJEANJGL_Value;
		}

		// // RVA: 0x148ADB8 Offset: 0x148ADB8 VA: 0x148ADB8
		public void FIBJPHMKGFL_SetLastRequestTime(int KCNAEONFIBP, long GDBNLALOFKE)
		{
			BPMCABFPPHI_MissionList[KCNAEONFIBP].JLNIAIJKEHC_LastRequestTime.DNJEJEANJGL_Value = GDBNLALOFKE;
		}

		// // RVA: 0x148AE78 Offset: 0x148AE78 VA: 0x148AE78
		public long HKCAPAOLNNC_GetLastRequestTime(int KCNAEONFIBP)
		{
			return BPMCABFPPHI_MissionList[KCNAEONFIBP].JLNIAIJKEHC_LastRequestTime.DNJEJEANJGL_Value;
		}

		// // RVA: 0x148AF24 Offset: 0x148AF24 VA: 0x148AF24
		public void HCJHKDOANKK_IncOverLimitHelp(int KCNAEONFIBP)
		{
			BPMCABFPPHI_MissionList[KCNAEONFIBP].ECFIOMGFCDJ_OverLimitHelp.DNJEJEANJGL_Value++;
		}

		// // RVA: 0x148B000 Offset: 0x148B000 VA: 0x148B000
		public bool GAIGIKOLLFI_IsOverLimitHelp(int KCNAEONFIBP)
		{
			return BPMCABFPPHI_MissionList[KCNAEONFIBP].ECFIOMGFCDJ_OverLimitHelp.DNJEJEANJGL_Value > 0;
		}

		// // RVA: 0x148B0BC Offset: 0x148B0BC VA: 0x148B0BC
		// public void AGMJCMNFDGA(int KCNAEONFIBP, long JLFNEBBFCIA) { }

		// // RVA: 0x148B1B0 Offset: 0x148B1B0 VA: 0x148B1B0
		// public long MKEAGOMMJLE(int KCNAEONFIBP) { }

		// // RVA: 0x148B25C Offset: 0x148B25C VA: 0x148B25C
		public void IDBJMCBHJJJ(int KCNAEONFIBP)
		{
			BPMCABFPPHI_MissionList.Remove(KCNAEONFIBP);
		}

		// // RVA: 0x148B2DC Offset: 0x148B2DC VA: 0x148B2DC
		public List<int> HEMPBHOBAPE()
		{
			List<int> res = new List<int>(BPMCABFPPHI_MissionList.Count);
			foreach(var k in BPMCABFPPHI_MissionList.Keys)
			{
				res.Add(k);
			}
			return res;
		}

		// // RVA: 0x148B4E4 Offset: 0x148B4E4 VA: 0x148B4E4
		public bool HLCEBIENJHN(Dictionary<int, PHIONIAFEIP> PIIPOANPMCF)
		{
			if(BPMCABFPPHI_MissionList.Count != PIIPOANPMCF.Count)
				return false;
			foreach(var k in PIIPOANPMCF)
			{
				if(!MPOLPHDMBKA(k.Key))
					return false;
				int a = k.Value.JOMGCCBFKEF_MissionId.DNJEJEANJGL_Value;
				if(!LDJPDEHJFOC(k.Key, out a))
					return false;
				if(a != BPMCABFPPHI_MissionList[k.Key].JOMGCCBFKEF_MissionId.DNJEJEANJGL_Value)
					return false;
				if(k.Value.IELDJLGIKGC_PlayCount.DNJEJEANJGL_Value != BPMCABFPPHI_MissionList[k.Key].IELDJLGIKGC_PlayCount.DNJEJEANJGL_Value)
					return false;
				if(k.Value.AAFHFMDKKDE_AssistCount.DNJEJEANJGL_Value != BPMCABFPPHI_MissionList[k.Key].AAFHFMDKKDE_AssistCount.DNJEJEANJGL_Value)
					return false;
				if(k.Value.OMNJALHBFCG_RequestCount.DNJEJEANJGL_Value != BPMCABFPPHI_MissionList[k.Key].OMNJALHBFCG_RequestCount.DNJEJEANJGL_Value)
					return false;
				if(k.Value.JLNIAIJKEHC_LastRequestTime.DNJEJEANJGL_Value != BPMCABFPPHI_MissionList[k.Key].JLNIAIJKEHC_LastRequestTime.DNJEJEANJGL_Value)
					return false;
				if(k.Value.ECFIOMGFCDJ_OverLimitHelp.DNJEJEANJGL_Value != BPMCABFPPHI_MissionList[k.Key].ECFIOMGFCDJ_OverLimitHelp.DNJEJEANJGL_Value)
					return false;
			}
			return true;
		}

		// // RVA: 0x147DB8C Offset: 0x147DB8C VA: 0x147DB8C
		public EDOHBJAPLPF_JsonData NOOGGMKMGFF(string _POFDDFCGEGP_Underscore)
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
			data[PHIONIAFEIP.KLMIFEKNBLL_m_id] = 0;
			data[PHIONIAFEIP.KBKPCNIFLAM_PlayCount] = 0;
			data[PHIONIAFEIP.GPNHBMLJHGA_AssistCount] = 0;
			data[PHIONIAFEIP.PONECEJICJC_RequestCount] = 0;
			data[PHIONIAFEIP.OOFCCOMCOLD_LastRequestTime] = 0;
			data[PHIONIAFEIP.KJEPKLLCJOD_OverLimitHelp] = 0;
			res[_POFDDFCGEGP_Underscore] = data;
			foreach(var key in BPMCABFPPHI_MissionList.Keys)
			{
				data = new EDOHBJAPLPF_JsonData();
				data[PHIONIAFEIP.KLMIFEKNBLL_m_id] = BPMCABFPPHI_MissionList[key].JOMGCCBFKEF_MissionId.DNJEJEANJGL_Value;
				data[PHIONIAFEIP.KBKPCNIFLAM_PlayCount] = BPMCABFPPHI_MissionList[key].IELDJLGIKGC_PlayCount.DNJEJEANJGL_Value;
				data[PHIONIAFEIP.GPNHBMLJHGA_AssistCount] = BPMCABFPPHI_MissionList[key].AAFHFMDKKDE_AssistCount.DNJEJEANJGL_Value;
				data[PHIONIAFEIP.PONECEJICJC_RequestCount] = BPMCABFPPHI_MissionList[key].OMNJALHBFCG_RequestCount.DNJEJEANJGL_Value;
				data[PHIONIAFEIP.OOFCCOMCOLD_LastRequestTime] = BPMCABFPPHI_MissionList[key].JLNIAIJKEHC_LastRequestTime.DNJEJEANJGL_Value;
				data[PHIONIAFEIP.KJEPKLLCJOD_OverLimitHelp] = BPMCABFPPHI_MissionList[key].ECFIOMGFCDJ_OverLimitHelp.DNJEJEANJGL_Value;
				res[_POFDDFCGEGP_Underscore + key.ToString()] = data;
			}
			return res;
		}

		// // RVA: 0x148BC48 Offset: 0x148BC48 VA: 0x148BC48
		// public EDOHBJAPLPF_JsonData PPLDAJBGBOC(int _LJNAKDMILMC_key) { }

		// // RVA: 0x14894E0 Offset: 0x14894E0 VA: 0x14894E0
		// public bool KPIPHJOGAMN() { }

		// // RVA: 0x147C0E8 Offset: 0x147C0E8 VA: 0x147C0E8
		public void LHPDDGIJKNB_Reset()
		{
			ENOBDCFHELD = (int)Utility.GetCurrentUnixTime();
			FCEJCHGLFGN = ENOBDCFHELD ^ 0x8730115;
			EGBOHDFBAPB_closed_at = 0;
			MPCAGEPEJJJ_Key = "";
			IMFBCJOIJKJ_Entry = false;
			ABBJBPLHFHA_Spurt = false;
			OKEJGGCMAAI_PlaRcv = false;
			HPLMECLKFID_RRcv = false;
			CGMMMJCIDFE_EpaRcv = false;
			KILJKLIHMAE_SboRcv = false;
			LGADCGFMLLD_step = 0;
			INLNJOGHLJE_Show = 0;
			OMCAOJJGOGG_Lb = 0;
			DNBFMLBNAEE_point = 0;
			NFIOKIBPJCJ_uptime = 0;
			NNMPGOAGEOL_quests.Clear();
			int k = ENOBDCFHELD + 5;
			for(int i = 0; i < 100; i++)
			{
				IKCGAJKCPFN ik = new IKCGAJKCPFN();
				ik.LHPDDGIJKNB_Reset(i + 1, k);
				NNMPGOAGEOL_quests.Add(ik);
				k *= 13;
			}
			MHKICPIMFEI_PlayCount = 0;
			MDADLCOCEBN_session_id = "";
			LIEKIBHAPKC_FId = 0;
			NOKPCBEIJHJ_ApVal = 0;
			CKLPPIIKAKD_ApSaveTime = 0;
			HBHCCLGECOC_MyBossId = 0;
			BJBJHNJJCHL_AtkMcgBonus = 0;
			FKJINLKCKJK_McannonScene.Clear();
			for(int i = 0; i < 4; i++)
			{
				CEBFFLDKAEC_SecureInt v = new CEBFFLDKAEC_SecureInt();
				v.LHPDDGIJKNB_Reset(ENOBDCFHELD, FCEJCHGLFGN);
				JMPBGDLHAPE_MyBossAtkCount.Add(v);
			}
			FJDKDGBKGLB_BossList.Clear();
			BPMCABFPPHI_MissionList.Clear();
		}

		// // RVA: 0x14806C4 Offset: 0x14806C4 VA: 0x14806C4
		public void ODDIHGPONFL_Copy(PMJBKKNNNEM GPBJHKLFCEP)
		{
			MPCAGEPEJJJ_Key = GPBJHKLFCEP.MPCAGEPEJJJ_Key;
			EGBOHDFBAPB_closed_at = GPBJHKLFCEP.EGBOHDFBAPB_closed_at;
			IMFBCJOIJKJ_Entry = GPBJHKLFCEP.IMFBCJOIJKJ_Entry;
			ABBJBPLHFHA_Spurt = GPBJHKLFCEP.ABBJBPLHFHA_Spurt;
			HPLMECLKFID_RRcv = GPBJHKLFCEP.HPLMECLKFID_RRcv;
			OKEJGGCMAAI_PlaRcv = GPBJHKLFCEP.OKEJGGCMAAI_PlaRcv;
			CGMMMJCIDFE_EpaRcv = GPBJHKLFCEP.CGMMMJCIDFE_EpaRcv;
			KILJKLIHMAE_SboRcv = GPBJHKLFCEP.KILJKLIHMAE_SboRcv;
			DNBFMLBNAEE_point = GPBJHKLFCEP.DNBFMLBNAEE_point;
			LGADCGFMLLD_step = GPBJHKLFCEP.LGADCGFMLLD_step;
			NFIOKIBPJCJ_uptime = GPBJHKLFCEP.NFIOKIBPJCJ_uptime;
			INLNJOGHLJE_Show = GPBJHKLFCEP.INLNJOGHLJE_Show;
			OMCAOJJGOGG_Lb = GPBJHKLFCEP.OMCAOJJGOGG_Lb;
			for(int i = 0; i < 100; i++)
			{
				NNMPGOAGEOL_quests[i].ODDIHGPONFL_Copy(GPBJHKLFCEP.NNMPGOAGEOL_quests[i]);
			}
			MDADLCOCEBN_session_id = GPBJHKLFCEP.MDADLCOCEBN_session_id;
			LIEKIBHAPKC_FId = GPBJHKLFCEP.LIEKIBHAPKC_FId;
			MHKICPIMFEI_PlayCount = GPBJHKLFCEP.MHKICPIMFEI_PlayCount;
			NOKPCBEIJHJ_ApVal = GPBJHKLFCEP.NOKPCBEIJHJ_ApVal;
			CKLPPIIKAKD_ApSaveTime = GPBJHKLFCEP.CKLPPIIKAKD_ApSaveTime;
			HBHCCLGECOC_MyBossId = GPBJHKLFCEP.HBHCCLGECOC_MyBossId;
			BJBJHNJJCHL_AtkMcgBonus = GPBJHKLFCEP.BJBJHNJJCHL_AtkMcgBonus;
			FKJINLKCKJK_McannonScene = new Dictionary<int, byte[]>(GPBJHKLFCEP.FKJINLKCKJK_McannonScene.Count);
			foreach(var k in GPBJHKLFCEP.FKJINLKCKJK_McannonScene)
			{
				FKJINLKCKJK_McannonScene.Add(k.Key, k.Value.Clone() as byte[]);
			}
			for(int i = 0; i < JMPBGDLHAPE_MyBossAtkCount.Count; i++)
			{
				JMPBGDLHAPE_MyBossAtkCount[i].DNJEJEANJGL_Value = GPBJHKLFCEP.JMPBGDLHAPE_MyBossAtkCount[i].DNJEJEANJGL_Value;
			}
			FJDKDGBKGLB_BossList.Clear();
			for(int i = 0; i < GPBJHKLFCEP.FJDKDGBKGLB_BossList.Count; i++)
			{
				NBCJGLLLFOH(GPBJHKLFCEP.FJDKDGBKGLB_BossList[i].DNJEJEANJGL_Value);
			}
			BPMCABFPPHI_MissionList.Clear();
			foreach(var k in GPBJHKLFCEP.BPMCABFPPHI_MissionList)
			{
				BEDGDKOCGEE(k.Key, k.Value.JOMGCCBFKEF_MissionId.DNJEJEANJGL_Value, 
				k.Value.IELDJLGIKGC_PlayCount.DNJEJEANJGL_Value, 
				k.Value.AAFHFMDKKDE_AssistCount.DNJEJEANJGL_Value, 
				k.Value.OMNJALHBFCG_RequestCount.DNJEJEANJGL_Value, 
				k.Value.JLNIAIJKEHC_LastRequestTime.DNJEJEANJGL_Value, 
				k.Value.ECFIOMGFCDJ_OverLimitHelp.DNJEJEANJGL_Value);
			}
		}

		// // RVA: 0x14815B4 Offset: 0x14815B4 VA: 0x14815B4
		public bool AGBOGBEOFME(PMJBKKNNNEM OIKJFMGEICL)
		{
			if(ABBJBPLHFHA_Spurt != OIKJFMGEICL.ABBJBPLHFHA_Spurt)
				return false;
			if(IMFBCJOIJKJ_Entry != OIKJFMGEICL.IMFBCJOIJKJ_Entry)
				return false;
			if(INLNJOGHLJE_Show != OIKJFMGEICL.INLNJOGHLJE_Show)
				return false;
			if(LIEKIBHAPKC_FId != OIKJFMGEICL.LIEKIBHAPKC_FId)
				return false;
			if(HBHCCLGECOC_MyBossId != OIKJFMGEICL.HBHCCLGECOC_MyBossId)
				return false;
			if(EGBOHDFBAPB_closed_at != OIKJFMGEICL.EGBOHDFBAPB_closed_at)
				return false;
			if(HPLMECLKFID_RRcv != OIKJFMGEICL.HPLMECLKFID_RRcv)
				return false;
			if(OKEJGGCMAAI_PlaRcv != OIKJFMGEICL.OKEJGGCMAAI_PlaRcv)
				return false;
			if(CGMMMJCIDFE_EpaRcv != OIKJFMGEICL.CGMMMJCIDFE_EpaRcv)
				return false;
			if(KILJKLIHMAE_SboRcv != OIKJFMGEICL.KILJKLIHMAE_SboRcv)
				return false;
			if(DNBFMLBNAEE_point != OIKJFMGEICL.DNBFMLBNAEE_point)
				return false;
			if(LGADCGFMLLD_step != OIKJFMGEICL.LGADCGFMLLD_step)
				return false;
			if(NFIOKIBPJCJ_uptime != OIKJFMGEICL.NFIOKIBPJCJ_uptime)
				return false;
			if(OMCAOJJGOGG_Lb != OIKJFMGEICL.OMCAOJJGOGG_Lb)
				return false;
			if(MHKICPIMFEI_PlayCount != OIKJFMGEICL.MHKICPIMFEI_PlayCount)
				return false;
			if(NOKPCBEIJHJ_ApVal != OIKJFMGEICL.NOKPCBEIJHJ_ApVal)
				return false;
			if(CKLPPIIKAKD_ApSaveTime != OIKJFMGEICL.CKLPPIIKAKD_ApSaveTime)
				return false;
			if(BJBJHNJJCHL_AtkMcgBonus != OIKJFMGEICL.BJBJHNJJCHL_AtkMcgBonus)
				return false;
			if(MPCAGEPEJJJ_Key != OIKJFMGEICL.MPCAGEPEJJJ_Key)
				return false;
			if(MDADLCOCEBN_session_id != OIKJFMGEICL.MDADLCOCEBN_session_id)
				return false;
			for(int i = 0; i < 100; i++)
			{
				if(!NNMPGOAGEOL_quests[i].AGBOGBEOFME(OIKJFMGEICL.NNMPGOAGEOL_quests[i]))
					return false;
			}
			if(!CBGPNDNBMDN(OIKJFMGEICL.FKJINLKCKJK_McannonScene))
				return false;
			for(int i = 0; i < JMPBGDLHAPE_MyBossAtkCount.Count; i++)
			{
				if(JMPBGDLHAPE_MyBossAtkCount[i].DNJEJEANJGL_Value != OIKJFMGEICL.JMPBGDLHAPE_MyBossAtkCount[i].DNJEJEANJGL_Value)
					return false;
			}
			if(FJDKDGBKGLB_BossList.Count != OIKJFMGEICL.FJDKDGBKGLB_BossList.Count)
				return false;
			for(int i = 0; i < FJDKDGBKGLB_BossList.Count; i++)
			{
				int v = FJDKDGBKGLB_BossList[i].DNJEJEANJGL_Value;
				if(OIKJFMGEICL.FJDKDGBKGLB_BossList.Find((CEBFFLDKAEC_SecureInt _JKDKBCPFFEL_o) =>
				{
					//0x1B8D540
					return _JKDKBCPFFEL_o.DNJEJEANJGL_Value == v;
				}) == null)
					return false;
			}
			if(!HLCEBIENJHN(OIKJFMGEICL.BPMCABFPPHI_MissionList))
				return false;
			return true;
		}

		// // RVA: 0x148242C Offset: 0x148242C VA: 0x148242C
		// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string _JIKKNHIAEKG_BlockName, string MJBACHKCIHA, int _OIPCCBHIKIA_index, JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM _OHMCIEMIKCE_t, bool EFOEPDLNLJG) { }

		// // RVA: 0x148C0CC Offset: 0x148C0CC VA: 0x148C0CC
		public void BGOJNJLNLKE()
		{
			PJCGNAKDOKH(HBHCCLGECOC_MyBossId);
			IDBJMCBHJJJ(HBHCCLGECOC_MyBossId);
			HBHCCLGECOC_MyBossId = 0;
		}
	}

	private const int ECFEMKGFDCE_CurrentVersion = 1;
	public const int ICHFGGBPCBJ = 4;
	public const int BJEPEBMLKOL = 100;
	public const long EGHFCEBIGEE = 99999999;
	public const int EHMODBCDMJP = 20;
	private const int ABHKFICDNDB = 8;
	private const int DCNPEJBGAAL = 6000;
	private const int GPEANMJHLPJ = 750;
	private const string POFDDFCGEGP_Underscore = "_";
	public const int BFGBBPGHJHM = 4;
	public List<PMJBKKNNNEM> FBCJICEPLED = new List<PMJBKKNNNEM>(4); // 0x24

	public override bool DMICHEJIAJL { get { return true; } } // 0x1489874 NFKFOODCJJB_bgs

	// // RVA: 0x147BDFC Offset: 0x147BDFC VA: 0x147BDFC
	public JLOGEHCIBEJ_EventRaid()
	{
		LHPDDGIJKNB_Reset();
	}

	// // RVA: 0x147BE98 Offset: 0x147BE98 VA: 0x147BE98 Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		FBCJICEPLED.Clear();
		for(int i = 0; i < 4; i++)
		{
			PMJBKKNNNEM data = new PMJBKKNNNEM();
			data.LHPDDGIJKNB_Reset();
			FBCJICEPLED.Add(data);
		}
	}

	// // RVA: 0x147C4BC Offset: 0x147C4BC VA: 0x147C4BC Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < 4; i++)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < 100; j++)
			{
				data2.Add(FBCJICEPLED[i].NNMPGOAGEOL_quests[j].NOJCMGAFAAC_ToJsonData());
			}
			EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
			data3["_"] = "";
			FBCJICEPLED[i].ILHFNBFDNPO((int _LJNAKDMILMC_key, byte[] _NANNGLGOFKH_value) =>
			{
				//0x148987C
				data3["_" + _LJNAKDMILMC_key.ToString()] = CEDHHAGBIBA.EHNMFLADJKG_ByteArrayToString(_NANNGLGOFKH_value);
			});
			EDOHBJAPLPF_JsonData data4 = new EDOHBJAPLPF_JsonData();
			data4.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < 4; j++)
			{
				data4.Add(FBCJICEPLED[i].KAHKFBKIMBE_GetMyBossAttackCount((JJAFLOEBLDH)(j + 1)));
			}
			EDOHBJAPLPF_JsonData data6 = new EDOHBJAPLPF_JsonData();
			data6[AFEHLCGHAEE_Strings.LJNAKDMILMC_key] = FBCJICEPLED[i].MPCAGEPEJJJ_Key;
			data6[AFEHLCGHAEE_Strings.KOMKKBDABJP_end] = FBCJICEPLED[i].EGBOHDFBAPB_closed_at;
			data6[AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry] = FBCJICEPLED[i].IMFBCJOIJKJ_Entry ? 1 : 0;
			data6[AFEHLCGHAEE_Strings.MAFAIIHJAFG_spurt] = FBCJICEPLED[i].ABBJBPLHFHA_Spurt ? 1 : 0;
			data6[AFEHLCGHAEE_Strings.DNBFMLBNAEE_point] = FBCJICEPLED[i].DNBFMLBNAEE_point;
			data6[AFEHLCGHAEE_Strings.NFIOKIBPJCJ_uptime] = FBCJICEPLED[i].NFIOKIBPJCJ_uptime;
			data6[AFEHLCGHAEE_Strings.LDALACBKEJN_r_rcv] = FBCJICEPLED[i].HPLMECLKFID_RRcv ? 1 : 0;
			data6[AFEHLCGHAEE_Strings.LGADCGFMLLD_step] = FBCJICEPLED[i].LGADCGFMLLD_step;
			data6[AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests] = data2;
			data6["show"] = FBCJICEPLED[i].INLNJOGHLJE_Show;
			data6[AFEHLCGHAEE_Strings.MDADLCOCEBN_session_id] = FBCJICEPLED[i].MDADLCOCEBN_session_id;
			data6["lb"] = FBCJICEPLED[i].OMCAOJJGOGG_Lb;
			data6["f_id"] = FBCJICEPLED[i].LIEKIBHAPKC_FId;
			data6["play_cnt"] = FBCJICEPLED[i].MHKICPIMFEI_PlayCount;
			data6["pla_rcv"] = FBCJICEPLED[i].OKEJGGCMAAI_PlaRcv ? 1 : 0;
			data6["epa_rcv"] = FBCJICEPLED[i].CGMMMJCIDFE_EpaRcv ? 1 : 0;
			data6["sbo_rcv"] = FBCJICEPLED[i].KILJKLIHMAE_SboRcv ? 1 : 0;
			data6["ap_val"] = FBCJICEPLED[i].NOKPCBEIJHJ_ApVal;
			data6["ap_save_time"] = FBCJICEPLED[i].CKLPPIIKAKD_ApSaveTime;
			data6["my_boss_id"] = FBCJICEPLED[i].HBHCCLGECOC_MyBossId;
			data6["atk_mcg_bonus"] = FBCJICEPLED[i].BJBJHNJJCHL_AtkMcgBonus;
			data6["mcannon_scene"] = data3;
			data6["my_boss_atk_count"] = data4;
			EDOHBJAPLPF_JsonData data5 = new EDOHBJAPLPF_JsonData();
			data5.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < FBCJICEPLED[i].ABIMDFJNEMI(); j++)
			{
				data5.Add(FBCJICEPLED[i].ADEKOBLCCGC(j));
			}
			data6["o_boss_list"] = data5;
			data.Add(data6);
			data6["mission_list"] = FBCJICEPLED[i].NOOGGMKMGFF("_");
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData tmp = new EDOHBJAPLPF_JsonData();
			tmp[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = _MCKEOKFMLAH_SaveId;
			tmp[JIKKNHIAEKG_BlockName] = data;
			tmp[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 1;
			data = tmp;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x147E5B4 Offset: 0x147E5B4 VA: 0x147E5B4 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 1);
		if (!blockMissing)
		{
			if (block == null || !block.EPNGJLOKGIF_IsArray)
			{
				isInvalid = true;
			}
			else
			{
				if(block.HNBFOAJIIAL_Count > 0)
				{
					int cnt = block.HNBFOAJIIAL_Count;
					if(cnt >= 5)
					{
						isInvalid = true;
						cnt = 4;
					}
					for(int i = 0; i < cnt; i++)
					{
						FBCJICEPLED[i].MPCAGEPEJJJ_Key = FGCNMLBACGO_GetString(block[i], AFEHLCGHAEE_Strings.LJNAKDMILMC_key, "", ref isInvalid);
						FBCJICEPLED[i].EGBOHDFBAPB_closed_at = DKMPHAPBDLH_GetLong(block[i], AFEHLCGHAEE_Strings.KOMKKBDABJP_end, 0, ref isInvalid);
						FBCJICEPLED[i].IMFBCJOIJKJ_Entry = CJAENOMGPDA_GetInt(block[i], AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry, 0, ref isInvalid) != 0;
						FBCJICEPLED[i].ABBJBPLHFHA_Spurt = CJAENOMGPDA_GetInt(block[i], AFEHLCGHAEE_Strings.MAFAIIHJAFG_spurt, 0, ref isInvalid) != 0;
						FBCJICEPLED[i].DNBFMLBNAEE_point = DKMPHAPBDLH_GetLong(block[i], AFEHLCGHAEE_Strings.DNBFMLBNAEE_point, 0, ref isInvalid);
						FBCJICEPLED[i].NFIOKIBPJCJ_uptime = DKMPHAPBDLH_GetLong(block[i], AFEHLCGHAEE_Strings.NFIOKIBPJCJ_uptime, 0, ref isInvalid);
						FBCJICEPLED[i].LGADCGFMLLD_step = CJAENOMGPDA_GetInt(block[i], AFEHLCGHAEE_Strings.LGADCGFMLLD_step, 0, ref isInvalid);
						FBCJICEPLED[i].HPLMECLKFID_RRcv = CJAENOMGPDA_GetInt(block[i], AFEHLCGHAEE_Strings.LDALACBKEJN_r_rcv, 0, ref isInvalid) != 0;
						FBCJICEPLED[i].OKEJGGCMAAI_PlaRcv = CJAENOMGPDA_GetInt(block[i], "pla_rcv", 0, ref isInvalid) != 0;
						FBCJICEPLED[i].CGMMMJCIDFE_EpaRcv = CJAENOMGPDA_GetInt(block[i], "epa_rcv", 0, ref isInvalid) != 0;
						FBCJICEPLED[i].KILJKLIHMAE_SboRcv = CJAENOMGPDA_GetInt(block[i], "sbo_rcv", 0, ref isInvalid) != 0;
						FBCJICEPLED[i].INLNJOGHLJE_Show = CJAENOMGPDA_GetInt(block[i], "show", 0, ref isInvalid);
						FBCJICEPLED[i].MDADLCOCEBN_session_id = FGCNMLBACGO_GetString(block[i], AFEHLCGHAEE_Strings.MDADLCOCEBN_session_id, "", ref isInvalid);
						FBCJICEPLED[i].OMCAOJJGOGG_Lb = CJAENOMGPDA_GetInt(block[i], "lb", 0, ref isInvalid);
						FBCJICEPLED[i].LIEKIBHAPKC_FId = CJAENOMGPDA_GetInt(block[i], "f_id", 0, ref isInvalid);
						FBCJICEPLED[i].MHKICPIMFEI_PlayCount = CJAENOMGPDA_GetInt(block[i], "play_cnt", 0, ref isInvalid);
						FBCJICEPLED[i].NOKPCBEIJHJ_ApVal = CJAENOMGPDA_GetInt(block[i], "ap_val", 0, ref isInvalid);
						FBCJICEPLED[i].CKLPPIIKAKD_ApSaveTime = DKMPHAPBDLH_GetLong(block[i], "ap_save_time", 0, ref isInvalid);
						FBCJICEPLED[i].HBHCCLGECOC_MyBossId = CJAENOMGPDA_GetInt(block[i], "my_boss_id", 0, ref isInvalid);
						FBCJICEPLED[i].BJBJHNJJCHL_AtkMcgBonus = CJAENOMGPDA_GetInt(block[i], "atk_mcg_bonus", 0, ref isInvalid);
						if(block[i].BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests))
						{
							EDOHBJAPLPF_JsonData data = block[i][AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests];
							int cnt2 = data.HNBFOAJIIAL_Count;
							if(cnt2 > 100)
								cnt2 = 100;
							for(int j = 0; j < cnt2; j++)
							{
								FBCJICEPLED[i].NNMPGOAGEOL_quests[j].PPFNGGCBJKC_id = CJAENOMGPDA_GetInt(data[j], AFEHLCGHAEE_Strings.PPFNGGCBJKC_id, j + 1, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_quests[j].EALOBDHOCHP_stat = CJAENOMGPDA_GetInt(data[j], AFEHLCGHAEE_Strings.EALOBDHOCHP_stat, 0, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_quests[j].HMFFHLPNMPH_count = CJAENOMGPDA_GetInt(data[j], AFEHLCGHAEE_Strings.HMFFHLPNMPH_count, 0, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_quests[j].BEBJKJKBOGH_date = DKMPHAPBDLH_GetLong(data[j], AFEHLCGHAEE_Strings.BEBJKJKBOGH_date, 0, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_quests[j].CADENLBDAEB_IsNew = CJAENOMGPDA_GetInt(data[j], AFEHLCGHAEE_Strings.KLJGEHBKMMG_new, 0, ref isInvalid) == 1;
							}
						}
						if(block[i].BBAJPINMOEP_Contains("mcannon_scene"))
						{
							EDOHBJAPLPF_JsonData data = block[i]["mcannon_scene"];
							int cnt2 = data.HNBFOAJIIAL_Count;
							for(int j = 0; j < cnt2; j++)
							{
								string s = data.FLPBHNAOIOB(j);
								if(s != "_")
								{
									int a = int.Parse(s.Substring("_".Length));
									byte[] bts = new byte[750];
									CEDHHAGBIBA.IFOLECIIDPO_StringToByteArray(bts, FGCNMLBACGO_GetString(data, s, null, ref isInvalid));
									FBCJICEPLED[i].LJKCCFMDCCN(a, bts);
								}
							}
						}
						IBCGPBOGOGP_ReadIntArray(block[i], "my_boss_atk_count", 0, 4, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
						{
							//0x14899B4
							FBCJICEPLED[i].GNDJFKNNMHD((JJAFLOEBLDH)_OIPCCBHIKIA_index + 1, _JBGEEPFKIGG_val);
						}, ref isInvalid);
						FBCJICEPLED[i].BADLOIKHGLK();
						if(block[i].BBAJPINMOEP_Contains("o_boss_list"))
						{
							IBCGPBOGOGP_ReadIntArray(block[i], "o_boss_list", 0, 20, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
							{
								//0x1489A94
								if(_JBGEEPFKIGG_val == 0)
									return;
								FBCJICEPLED[i].NBCJGLLLFOH(_JBGEEPFKIGG_val);
							}, ref isInvalid);
						}
						FBCJICEPLED[i].LGJLABFMGHG();
						if(block[i].BBAJPINMOEP_Contains("mission_list"))
						{
							EDOHBJAPLPF_JsonData data = block[i]["mission_list"];
							for(int j = 0; j < data.HNBFOAJIIAL_Count; j++)
							{
								string s = data.FLPBHNAOIOB(j);
								if(s != "_")
								{
									if(data[s].LLHIGGPIILM_IsObject)
									{
										int a = int.Parse(s.Substring("_".Length));
										FBCJICEPLED[i].BEDGDKOCGEE(a, 
											CJAENOMGPDA_GetInt(data[s], PMJBKKNNNEM.PHIONIAFEIP.KLMIFEKNBLL_m_id, 1, ref isInvalid),
											CJAENOMGPDA_GetInt(data[s], PMJBKKNNNEM.PHIONIAFEIP.KBKPCNIFLAM_PlayCount, 1, ref isInvalid),
											CJAENOMGPDA_GetInt(data[s], PMJBKKNNNEM.PHIONIAFEIP.GPNHBMLJHGA_AssistCount, 1, ref isInvalid),
											CJAENOMGPDA_GetInt(data[s], PMJBKKNNNEM.PHIONIAFEIP.PONECEJICJC_RequestCount, 1, ref isInvalid),
											CJAENOMGPDA_GetInt(data[s], PMJBKKNNNEM.PHIONIAFEIP.OOFCCOMCOLD_LastRequestTime, 0, ref isInvalid),
											CJAENOMGPDA_GetInt(data[s], PMJBKKNNNEM.PHIONIAFEIP.KJEPKLLCJOD_OverLimitHelp, 0, ref isInvalid)
										);
									}
								}
							}
						}
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x14804F4 Offset: 0x14804F4 VA: 0x14804F4 Slot: 7
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		JLOGEHCIBEJ_EventRaid other = GPBJHKLFCEP as JLOGEHCIBEJ_EventRaid;
		for(int i = 0; i < FBCJICEPLED.Count; i++)
		{
			FBCJICEPLED[i].ODDIHGPONFL_Copy(other.FBCJICEPLED[i]);
		}
	}

	// // RVA: 0x14813D4 Offset: 0x14813D4 VA: 0x14813D4 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		JLOGEHCIBEJ_EventRaid other = GPBJHKLFCEP as JLOGEHCIBEJ_EventRaid;
		for(int i = 0; i < FBCJICEPLED.Count; i++)
		{
			if(!FBCJICEPLED[i].AGBOGBEOFME(other.FBCJICEPLED[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0x1482020 Offset: 0x1482020 VA: 0x1482020 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);

	// // RVA: 0x1488EB0 Offset: 0x1488EB0 VA: 0x1488EB0 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}
}
