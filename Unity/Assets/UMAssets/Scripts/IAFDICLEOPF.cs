
using System.Collections.Generic;

public class IAFDICLEOPF
{ 
    public class HBCHKPLFHHF
    {
        public int ANMCFINOHFH; // 0x8
        public int HBBKFIMJHEL_Mid; // 0xC
        public int JOMGCCBFKEF_MissionId; // 0x10
        public int CIEOBFIIPLD_Level; // 0x14
        public int DJJGNDCMNHF_BonusValue; // 0x18
        public string FEMMDNIELFC_Desc; // 0x1C
        public string DCOFJKBIOAH_Desc2; // 0x20
        public bool JKPDKNPDEBC_EnemyHasSkill; // 0x24
    }

	public int ANMCFINOHFH; // 0x8
	public List<HBCHKPLFHHF> GAAHOOBMDEE_Mission; // 0xC

	// // RVA: 0x120D67C Offset: 0x120D67C VA: 0x120D67C
	public void KHEKNNFCAOI_Init(KPJHLACKGJF_NetEventMissionController _MOHDLLIJELH_cont)
    {
        GAAHOOBMDEE_Mission = new List<HBCHKPLFHHF>();
        if(_MOHDLLIJELH_cont == null)
            return;
        IJKAHGOJHGI(_MOHDLLIJELH_cont, 1);
        IJKAHGOJHGI(_MOHDLLIJELH_cont, 2);
        IJKAHGOJHGI(_MOHDLLIJELH_cont, 3);
    }

	// // RVA: 0x120D738 Offset: 0x120D738 VA: 0x120D738
	private void IJKAHGOJHGI(KPJHLACKGJF_NetEventMissionController _MOHDLLIJELH_cont, int _CIEOBFIIPLD_Level)
    {
        HBCHKPLFHHF d = new HBCHKPLFHHF();
        ACBAHDMEFFL_EventMission.ONECEEIOJCP dd;
        ACBAHDMEFFL_EventMission.BIMNGKEMMJM b = _MOHDLLIJELH_cont.MLLAMHMJFLP();
        if(_CIEOBFIIPLD_Level == 2)
        {
            d.HBBKFIMJHEL_Mid = b.KEEHMNJCONJ_Mid2;
            d.DJJGNDCMNHF_BonusValue = b.DHDBOPKADII_Bns2;
        }
        else if(_CIEOBFIIPLD_Level == 1)
        {
            d.HBBKFIMJHEL_Mid = b.BGFPMGPHGJJ_Mid1;
            d.DJJGNDCMNHF_BonusValue = b.JKAEKMMOJMF_Bns1;
        }
        else
        {
            d.HBBKFIMJHEL_Mid = b.CFMIPHDGCAG_Mid3;
            d.DJJGNDCMNHF_BonusValue = b.OPNNCHMFEBH_Bns3;
        }
        dd = _MOHDLLIJELH_cont.LOLJPCKNLGI(d.HBBKFIMJHEL_Mid);
        d.ANMCFINOHFH = b.PPFNGGCBJKC_id;
        d.JOMGCCBFKEF_MissionId = _MOHDLLIJELH_cont.KMOALEJMJKA_GetMission(dd.FCBDGLEPGFJ_mid).PPFNGGCBJKC_id;
        d.CIEOBFIIPLD_Level = _CIEOBFIIPLD_Level;
        d.FEMMDNIELFC_Desc = dd.FEMMDNIELFC_Desc;
        d.JKPDKNPDEBC_EnemyHasSkill = dd.MLKFDMFDFCE_enemy_c_skill != 0 || dd.DKOPDNHDLIA_enemy_l_skill != 0;
        GAAHOOBMDEE_Mission.Add(d);
    }
}
