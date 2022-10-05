using System.Collections.Generic;

public class MHDFCLCMDKO { }
public class MHDFCLCMDKO_Enemy : DIHHCBACKGG_DbSection
{
    public class CJLENGHPIDH_EnemyInfo
    {
        public int EJNIMIAPJFJ_Id; // 0x8
        public int EAHPLCJMPHD_Pic; // 0xC
        public int EELBHDJJJHH_Plt; // 0x10
        public int EDLACELKJIK_LS; // 0x14
        public int NJOPIPNGANO_CS; // 0x18
        public int ADMMEMNGKEN_Avo; // 0x1C

        // // RVA: 0x132B704 Offset: 0x132B704 VA: 0x132B704
        // public uint CAOGDCBPBAN() { }

        // // RVA: 0x132B77C Offset: 0x132B77C VA: 0x132B77C
        // public void LHPDDGIJKNB_Reset() { }

        // // RVA: 0x132B798 Offset: 0x132B798 VA: 0x132B798
        // public void ODDIHGPONFL_Copy(MHDFCLCMDKO.CJLENGHPIDH GPBJHKLFCEP) { }
    }

	public List<CJLENGHPIDH_EnemyInfo> CKADCLJDCJK_EnemyList { get; private set; } // 0x20 LKHMPJNEEHH NOIMCFANIGL KFNHNMPHCGM

	// // RVA: 0x132ACA4 Offset: 0x132ACA4 VA: 0x132ACA4
	public CJLENGHPIDH_EnemyInfo INONDJKKOKG(int EJNIMIAPJFJ)
	{
		return CKADCLJDCJK_EnemyList.Find((CJLENGHPIDH_EnemyInfo PKLPKMLGFGK) =>
		{
			//0x132B744
			return PKLPKMLGFGK.EJNIMIAPJFJ_Id == EJNIMIAPJFJ;
		});
	}

	// // RVA: 0x132ADA4 Offset: 0x132ADA4 VA: 0x132ADA4
	public MHDFCLCMDKO_Enemy()
    {
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 23;
		CKADCLJDCJK_EnemyList = new List<CJLENGHPIDH_EnemyInfo>();
    }

	// // RVA: 0x132AE98 Offset: 0x132AE98 VA: 0x132AE98 Slot: 8
	protected override void KMBPACJNEOF()
    {
		CKADCLJDCJK_EnemyList.Clear();
	}

	// // RVA: 0x132AF10 Offset: 0x132AF10 VA: 0x132AF10 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
    {
		NHADPDNKGIE parser = NHADPDNKGIE.HEGEKFMJNCC(DBBGALAPFGC);
		FJGJEJDJHEG(parser);
		return true;
    }

	// // RVA: 0x132B18C Offset: 0x132B18C VA: 0x132B18C Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(100, "Energy IIEMACPEEBJ");
		return true;
	}

	// // RVA: 0x132AF3C Offset: 0x132AF3C VA: 0x132AF3C
	private bool FJGJEJDJHEG(NHADPDNKGIE OFGBEDPGPFO)
	{
		JNHHIHOCMHN[] array = OFGBEDPGPFO.EAHFNHMNPIB;
		for(int i = 0; i < array.Length; i++)
		{
			CJLENGHPIDH_EnemyInfo data = new CJLENGHPIDH_EnemyInfo();
			data.EJNIMIAPJFJ_Id = (int)array[i].PPFNGGCBJKC;
			data.EAHPLCJMPHD_Pic = (int)array[i].HANMDEBPBHG;
			data.EELBHDJJJHH_Plt = (int)array[i].HDEBAGHEIKD;
			data.EDLACELKJIK_LS = (int)array[i].LNKKMBCDPHH;
			data.NJOPIPNGANO_CS = (int)array[i].AKOJJJLPCKA;
			data.ADMMEMNGKEN_Avo = (int)array[i].DFOIEJOKDKJ;
			CKADCLJDCJK_EnemyList.Add(data);
		}
		return true;
	}

	// // RVA: 0x132B190 Offset: 0x132B190 VA: 0x132B190
	// private bool FJGJEJDJHEG(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE) { }

	// // RVA: 0x132B5F8 Offset: 0x132B5F8 VA: 0x132B5F8 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(100, "Energy CAOGDCBPBAN");
		return 0;
	}
}
