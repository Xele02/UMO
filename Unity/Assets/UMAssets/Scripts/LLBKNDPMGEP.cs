
using System.Collections.Generic;

public class LLBKNDPMGEP
{
    public class GDGOMBCIJDL
    {
        public int FJOLNJLLJEJ_Rank; // 0x8
        public bool KCGJGPOFOCD; // 0xC
        public List<MFDJIFIIPJD> HBHMAKNGKFK = new List<MFDJIFIIPJD>(); // 0x10
    }

	public int EKANGPODCEP_EventId; // 0x8
	public int GMODKHLGILM_Rank; // 0xC
	public List<int> AILDCKKOLJG = new List<int>(); // 0x10
	public List<GDGOMBCIJDL> JMLKAGOACAE = new List<GDGOMBCIJDL>(); // 0x14

	// // RVA: 0x180A940 Offset: 0x180A940 VA: 0x180A940
	public void KHEKNNFCAOI()
    {
        AILDCKKOLJG.Clear();
        JMLKAGOACAE.Clear();
        CANAFALMGLI_EventPresentCampaign ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Find((IKDICBBFBMI_EventBase GHPLINIACBB) =>
        {
            //0x180BCFC
            return GHPLINIACBB.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.DMPMKBCPHMA_PresentCampaign;
        }) as CANAFALMGLI_EventPresentCampaign;
        if(ev != null)
        {
            EKANGPODCEP_EventId = ev.PGIIDPEGGPI_EventId;
            GMODKHLGILM_Rank = 1000;
            for(int i = 0; i < ev.AILDCKKOLJG.Count; i++)
            {
                AILDCKKOLJG.Add(ev.AILDCKKOLJG[i]);
                if(AILDCKKOLJG[i] < GMODKHLGILM_Rank)
                {
                    GMODKHLGILM_Rank = AILDCKKOLJG[i];
                }
            }
            if(GMODKHLGILM_Rank == 1000)
                GMODKHLGILM_Rank = 0;
            HIADOIECMFP_EventPresentCampaign db = ev.PFNALBDHBLE();
            if(db != null)
            {
                for(int i = 0; i < AILDCKKOLJG.Count; i++)
                {
                    if(AILDCKKOLJG[i] != 0)
                    {
                        GDGOMBCIJDL d = new GDGOMBCIJDL();
                        d.FJOLNJLLJEJ_Rank = AILDCKKOLJG[i];
                        d.KCGJGPOFOCD = db.OBPOHDENMHH[AILDCKKOLJG[i] - 1].KCGJGPOFOCD != 0;
                        for(int j = 0; j < db.OBPOHDENMHH[AILDCKKOLJG[i] - 1].GLCLFMGPMAN_ItemId.Count; j++)
                        {
                            MFDJIFIIPJD m_ = new MFDJIFIIPJD();
                            m_.KHEKNNFCAOI(db.OBPOHDENMHH[AILDCKKOLJG[i] - 1].GLCLFMGPMAN_ItemId[j], db.OBPOHDENMHH[AILDCKKOLJG[i] - 1].MBJIFDBEDAC_Cnt[j]);
                            d.HBHMAKNGKFK.Add(m_);
                        }
                        JMLKAGOACAE.Add(d);
                    }
                }
            }
            return;
        }
        EKANGPODCEP_EventId = 9001;
        AILDCKKOLJG.Add(7);
        AILDCKKOLJG.Add(6);
        AILDCKKOLJG.Add(5);
        AILDCKKOLJG.Add(4);
        AILDCKKOLJG.Add(3);
        AILDCKKOLJG.Add(2);
        AILDCKKOLJG.Add(4);
        AILDCKKOLJG.Sort();
        GDGOMBCIJDL g = new GDGOMBCIJDL();
        g.FJOLNJLLJEJ_Rank = 1;
        g.KCGJGPOFOCD = false;
        List<MFDJIFIIPJD> l2 = new List<MFDJIFIIPJD>();
        MFDJIFIIPJD m = new MFDJIFIIPJD();
        m.JJBGOIMEIPF_ItemId = 30001;
        m.NNFNGLJOKKF_ItemId = 10000;
        m.NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit;
        l2.Add(m);
        m = new MFDJIFIIPJD();
        m.JJBGOIMEIPF_ItemId = 30001;
        m.NNFNGLJOKKF_ItemId = 20000;
        m.NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit;
        l2.Add(m);
        m = new MFDJIFIIPJD();
        m.JJBGOIMEIPF_ItemId = 30001;
        m.NNFNGLJOKKF_ItemId = 30000;
        m.NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit;
        l2.Add(m);
        m = new MFDJIFIIPJD();
        m.JJBGOIMEIPF_ItemId = 30001;
        m.NNFNGLJOKKF_ItemId = 40000;
        m.NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit;
        l2.Add(m);
        m = new MFDJIFIIPJD();
        m.JJBGOIMEIPF_ItemId = 30001;
        m.NNFNGLJOKKF_ItemId = 50000;
        m.NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit;
        l2.Add(m);
        m = new MFDJIFIIPJD();
        m.JJBGOIMEIPF_ItemId = 30001;
        m.NNFNGLJOKKF_ItemId = 60000;
        m.NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit;
        l2.Add(m);
        g.HBHMAKNGKFK = l2;
        JMLKAGOACAE.Add(g);
        g = new GDGOMBCIJDL();
        g.FJOLNJLLJEJ_Rank = 2;
        g.KCGJGPOFOCD = false;
        l2 = new List<MFDJIFIIPJD>();
        m = new MFDJIFIIPJD();
        m.JJBGOIMEIPF_ItemId = 30001;
        m.NNFNGLJOKKF_ItemId = 10000;
        m.NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit;
        l2.Add(m);
        m = new MFDJIFIIPJD();
        m.JJBGOIMEIPF_ItemId = 30001;
        m.NNFNGLJOKKF_ItemId = 20000;
        m.NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit;
        l2.Add(m);
        m = new MFDJIFIIPJD();
        m.JJBGOIMEIPF_ItemId = 30001;
        m.NNFNGLJOKKF_ItemId = 30000;
        m.NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit;
        l2.Add(m);
        m = new MFDJIFIIPJD();
        m.JJBGOIMEIPF_ItemId = 30001;
        m.NNFNGLJOKKF_ItemId = 40000;
        m.NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit;
        l2.Add(m);
        g.HBHMAKNGKFK = l2;
        JMLKAGOACAE.Add(g);
        g = new GDGOMBCIJDL();
        g.FJOLNJLLJEJ_Rank = 3;
        g.KCGJGPOFOCD = false;
        l2 = new List<MFDJIFIIPJD>();
        m = new MFDJIFIIPJD();
        m.JJBGOIMEIPF_ItemId = 30001;
        m.NNFNGLJOKKF_ItemId = 10000;
        m.NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit;
        l2.Add(m);
        m = new MFDJIFIIPJD();
        m.JJBGOIMEIPF_ItemId = 30001;
        m.NNFNGLJOKKF_ItemId = 20000;
        m.NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit;
        l2.Add(m);
        g.HBHMAKNGKFK = l2;
        JMLKAGOACAE.Add(g);
    }
}
