
using System.Collections.Generic;

public class IAFDICLEOPF
{ 
    public class HBCHKPLFHHF
    {
        public int ANMCFINOHFH; // 0x8
        public int HBBKFIMJHEL; // 0xC
        public int JOMGCCBFKEF; // 0x10
        public int CIEOBFIIPLD; // 0x14
        public int DJJGNDCMNHF; // 0x18
        public string FEMMDNIELFC_Desc; // 0x1C
        public string DCOFJKBIOAH; // 0x20
        public bool JKPDKNPDEBC; // 0x24
    }

	public int ANMCFINOHFH; // 0x8
	public List<HBCHKPLFHHF> GAAHOOBMDEE_Missions; // 0xC

	// // RVA: 0x120D67C Offset: 0x120D67C VA: 0x120D67C
	public void KHEKNNFCAOI(KPJHLACKGJF_EventMission MOHDLLIJELH)
    {
        GAAHOOBMDEE_Missions = new List<HBCHKPLFHHF>();
        if(MOHDLLIJELH == null)
            return;
        IJKAHGOJHGI(MOHDLLIJELH, 1);
        IJKAHGOJHGI(MOHDLLIJELH, 2);
        IJKAHGOJHGI(MOHDLLIJELH, 3);
    }

	// // RVA: 0x120D738 Offset: 0x120D738 VA: 0x120D738
	private void IJKAHGOJHGI(KPJHLACKGJF_EventMission MOHDLLIJELH, int CIEOBFIIPLD)
    {
        HBCHKPLFHHF d = new HBCHKPLFHHF();
        ACBAHDMEFFL_EventMission.ONECEEIOJCP dd;
        ACBAHDMEFFL_EventMission.BIMNGKEMMJM b = MOHDLLIJELH.MLLAMHMJFLP();
        if(CIEOBFIIPLD == 2)
        {
            d.HBBKFIMJHEL = b.KEEHMNJCONJ_Mid2;
            d.DJJGNDCMNHF = b.DHDBOPKADII_Bns2;
        }
        else if(CIEOBFIIPLD == 1)
        {
            d.HBBKFIMJHEL = b.BGFPMGPHGJJ_Mid1;
            d.DJJGNDCMNHF = b.JKAEKMMOJMF_Bns1;
        }
        else
        {
            d.HBBKFIMJHEL = b.CFMIPHDGCAG_Mid3;
            d.DJJGNDCMNHF = b.OPNNCHMFEBH_Bns3;
        }
        dd = MOHDLLIJELH.LOLJPCKNLGI(d.HBBKFIMJHEL);
        d.ANMCFINOHFH = b.PPFNGGCBJKC_Id;
        d.JOMGCCBFKEF = MOHDLLIJELH.KMOALEJMJKA_GetMission(dd.FCBDGLEPGFJ_Mid).PPFNGGCBJKC_Id;
        d.CIEOBFIIPLD = CIEOBFIIPLD;
        d.FEMMDNIELFC_Desc = dd.FEMMDNIELFC_Desc;
        d.JKPDKNPDEBC = dd.MLKFDMFDFCE_EnemyCSkill != 0 || dd.DKOPDNHDLIA_EnemyLSkill != 0;
        GAAHOOBMDEE_Missions.Add(d);
    }
}
