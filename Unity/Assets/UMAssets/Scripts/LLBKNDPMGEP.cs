
using System.Collections.Generic;

public class LLBKNDPMGEP
{
    public class GDGOMBCIJDL
    {
        public int FJOLNJLLJEJ_rank; // 0x8
        public bool KCGJGPOFOCD_ticket; // 0xC
        public List<MFDJIFIIPJD> HBHMAKNGKFK_items = new List<MFDJIFIIPJD>(); // 0x10
    }

	public int EKANGPODCEP_EventId; // 0x8
	public int GMODKHLGILM_Rank; // 0xC
	public List<int> AILDCKKOLJG_Results = new List<int>(); // 0x10
	public List<GDGOMBCIJDL> JMLKAGOACAE = new List<GDGOMBCIJDL>(); // 0x14

	// // RVA: 0x180A940 Offset: 0x180A940 VA: 0x180A940
	public void KHEKNNFCAOI_Init()
    {
        AILDCKKOLJG_Results.Clear();
        JMLKAGOACAE.Clear();
        CANAFALMGLI_EventPresentCampaign ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Find((IKDICBBFBMI_EventBase _GHPLINIACBB_x) =>
        {
            //0x180BCFC
            return _GHPLINIACBB_x.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.DMPMKBCPHMA_PresentCampaign;
        }) as CANAFALMGLI_EventPresentCampaign;
        if(ev != null)
        {
            EKANGPODCEP_EventId = ev.PGIIDPEGGPI_EventId;
            GMODKHLGILM_Rank = 1000;
            for(int i = 0; i < ev.AILDCKKOLJG_Results.Count; i++)
            {
                AILDCKKOLJG_Results.Add(ev.AILDCKKOLJG_Results[i]);
                if(AILDCKKOLJG_Results[i] < GMODKHLGILM_Rank)
                {
                    GMODKHLGILM_Rank = AILDCKKOLJG_Results[i];
                }
            }
            if(GMODKHLGILM_Rank == 1000)
                GMODKHLGILM_Rank = 0;
            HIADOIECMFP_EventPresentCampaign db = ev.PFNALBDHBLE();
            if(db != null)
            {
                for(int i = 0; i < AILDCKKOLJG_Results.Count; i++)
                {
                    if(AILDCKKOLJG_Results[i] != 0)
                    {
                        GDGOMBCIJDL d = new GDGOMBCIJDL();
                        d.FJOLNJLLJEJ_rank = AILDCKKOLJG_Results[i];
                        d.KCGJGPOFOCD_ticket = db.OBPOHDENMHH[AILDCKKOLJG_Results[i] - 1].KCGJGPOFOCD_ticket != 0;
                        for(int j = 0; j < db.OBPOHDENMHH[AILDCKKOLJG_Results[i] - 1].GLCLFMGPMAN_ItemId.Count; j++)
                        {
                            MFDJIFIIPJD m_ = new MFDJIFIIPJD();
                            m_.KHEKNNFCAOI_Init(db.OBPOHDENMHH[AILDCKKOLJG_Results[i] - 1].GLCLFMGPMAN_ItemId[j], db.OBPOHDENMHH[AILDCKKOLJG_Results[i] - 1].MBJIFDBEDAC_item_count[j]);
                            d.HBHMAKNGKFK_items.Add(m_);
                        }
                        JMLKAGOACAE.Add(d);
                    }
                }
            }
            return;
        }
        EKANGPODCEP_EventId = 9001;
        AILDCKKOLJG_Results.Add(7);
        AILDCKKOLJG_Results.Add(6);
        AILDCKKOLJG_Results.Add(5);
        AILDCKKOLJG_Results.Add(4);
        AILDCKKOLJG_Results.Add(3);
        AILDCKKOLJG_Results.Add(2);
        AILDCKKOLJG_Results.Add(4);
        AILDCKKOLJG_Results.Sort();
        GDGOMBCIJDL g = new GDGOMBCIJDL();
        g.FJOLNJLLJEJ_rank = 1;
        g.KCGJGPOFOCD_ticket = false;
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
        g.HBHMAKNGKFK_items = l2;
        JMLKAGOACAE.Add(g);
        g = new GDGOMBCIJDL();
        g.FJOLNJLLJEJ_rank = 2;
        g.KCGJGPOFOCD_ticket = false;
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
        g.HBHMAKNGKFK_items = l2;
        JMLKAGOACAE.Add(g);
        g = new GDGOMBCIJDL();
        g.FJOLNJLLJEJ_rank = 3;
        g.KCGJGPOFOCD_ticket = false;
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
        g.HBHMAKNGKFK_items = l2;
        JMLKAGOACAE.Add(g);
    }
}
