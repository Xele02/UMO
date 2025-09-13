
using System.Collections.Generic;

public class IAFDICLEOPF
{ 
    public class HBCHKPLFHHF
    {
        public int ANMCFINOHFH; // 0x8
        public int HBBKFIMJHEL_Mid; // 0xC
        public int JOMGCCBFKEF; // 0x10
        public int CIEOBFIIPLD_Level; // 0x14
        public int DJJGNDCMNHF_BonusValue; // 0x18
        public string FEMMDNIELFC_Desc; // 0x1C
        public string DCOFJKBIOAH_Desc2; // 0x20
        public bool JKPDKNPDEBC; // 0x24
    }

	public int ANMCFINOHFH; // 0x8
	public List<HBCHKPLFHHF> GAAHOOBMDEE_Mission; // 0xC

	// // RVA: 0x120D67C Offset: 0x120D67C VA: 0x120D67C
	public void KHEKNNFCAOI(KPJHLACKGJF_EventMission MOHDLLIJELH)
    {
        GAAHOOBMDEE_Mission = new List<HBCHKPLFHHF>();
        if(MOHDLLIJELH == null)
            return;
        IJKAHGOJHGI(MOHDLLIJELH, 1);
        IJKAHGOJHGI(MOHDLLIJELH, 2);
        IJKAHGOJHGI(MOHDLLIJELH, 3);
    }

	// // RVA: 0x120D738 Offset: 0x120D738 VA: 0x120D738
	private void IJKAHGOJHGI(KPJHLACKGJF_EventMission MOHDLLIJELH, int _CIEOBFIIPLD_Level)
    {
        HBCHKPLFHHF d = new HBCHKPLFHHF();
        ACBAHDMEFFL_EventMission.ONECEEIOJCP dd;
        ACBAHDMEFFL_EventMission.BIMNGKEMMJM b = MOHDLLIJELH.MLLAMHMJFLP();
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
        dd = MOHDLLIJELH.LOLJPCKNLGI(d.HBBKFIMJHEL_Mid);
        d.ANMCFINOHFH = b.PPFNGGCBJKC_Id;
        d.JOMGCCBFKEF = MOHDLLIJELH.KMOALEJMJKA_GetMission(dd.FCBDGLEPGFJ_Mid).PPFNGGCBJKC_Id;
        d.CIEOBFIIPLD_Level = _CIEOBFIIPLD_Level;
        d.FEMMDNIELFC_Desc = dd.FEMMDNIELFC_Desc;
        d.JKPDKNPDEBC = dd.MLKFDMFDFCE_EnemyCSkill != 0 || dd.DKOPDNHDLIA_EnemyLSkill != 0;
        GAAHOOBMDEE_Mission.Add(d);
    }
}
