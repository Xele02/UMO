
using System.Collections.Generic;
using XeSys;

public class CHKMLHDDPHO
{
    public delegate void HKGCIPJGEFG(KDKFHGHGFEK FGDEABCKCLG, BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL KOGBMDOONFA);

    public delegate bool ILKGCGCHBHO();

	private BCGFHLIEKLJ_DecoItem BGAMFLIMLAP; // 0x8
	private List<KDKFHGHGFEK> NNLECFKJBFM; // 0xC
	private IIDJLAEDMPI FNEIADJMHHO; // 0x10
	// private CODKGCFMADC DLDGMHDHJLE = new CODKGCFMADC(); // 0x14
	// private CODKGCFMADC HDIKOBPHOFO = new CODKGCFMADC(); // 0x18

	// public int LONPMCGMLKM { get; } 0x12C7BBC NKBBGAGDDMK

	// RVA: 0x12C7C14 Offset: 0x12C7C14 VA: 0x12C7C14
	public CHKMLHDDPHO(FKAFHLIDAFD LGBMDHOLOIF)
    {
        BGAMFLIMLAP = LGBMDHOLOIF.AHEFHIMGIBI.OMMNKDEODJP_DecoItem;
        NNLECFKJBFM = KDKFHGHGFEK.FKDIMODKKJD(NDBFKHKMMCE_DecoItem.ANMODBDBNPK.DBAMIACJODJ.AAAOOKJAMGE_Sp);
        FNEIADJMHHO = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL;
    }

	// // RVA: 0x12C7DA8 Offset: 0x12C7DA8 VA: 0x12C7DA8
	// public void EJKOCOMPCLE(List<BCGFHLIEKLJ.GNGFGEIAGJL> MPCJGPEBCCD) { }

	// // RVA: 0x12C8088 Offset: 0x12C8088 VA: 0x12C8088
	// public void JCHLONCMPAJ(BCGFHLIEKLJ.GNGFGEIAGJL KOGBMDOONFA) { }

	// // RVA: 0x12C80B8 Offset: 0x12C80B8 VA: 0x12C80B8
	// public void KFFPODKBAOD(BCGFHLIEKLJ.GNGFGEIAGJL KOGBMDOONFA, IMCBBOAFION MHFGKMFMKON, DJBHIFLHJLK BJCLMGKNHIF, CHKMLHDDPHO.HKGCIPJGEFG FMKECCHDHBL) { }

	// // RVA: 0x12C8550 Offset: 0x12C8550 VA: 0x12C8550
	// public int KFFPODKBAOD(List<BCGFHLIEKLJ.GNGFGEIAGJL> MPCJGPEBCCD, IMCBBOAFION MHFGKMFMKON, DJBHIFLHJLK BJCLMGKNHIF, CHKMLHDDPHO.HKGCIPJGEFG FMKECCHDHBL) { }

	// RVA: 0x12C86CC Offset: 0x12C86CC VA: 0x12C86CC
	public List<BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL> CJLGPDLLHKC(DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN GCICHEAAKGD)
    {
        List<DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD> l = new List<DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD>(NNLECFKJBFM.Count);
        if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
        {
            List<NDBFKHKMMCE_DecoItem.NIBEBIGPKLA_ObjItem> l2 = new List<NDBFKHKMMCE_DecoItem.NIBEBIGPKLA_ObjItem>();
            for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp.Count; i++)
            {
                NDBFKHKMMCE_DecoItem.FIDBAFHNGCF db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[i];
                if(db.FJFCNGNGIBN_Attribute > 0 && db.FJFCNGNGIBN_Attribute - 1 < 3)
                {
                    l2.Add(db);
                }
            }
            foreach(var c in GCICHEAAKGD.HBHMAKNGKFK_Items)
            {
                if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(c.HAJKNHNAIKL_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp)
                {
                    int KIJAPOFAGPN = EKLNMHFCAOI.DEACAHNLMNI_getItemId(c.HAJKNHNAIKL_ItemId);
                    NDBFKHKMMCE_DecoItem.NIBEBIGPKLA_ObjItem it = l2.Find((NDBFKHKMMCE_DecoItem.NIBEBIGPKLA_ObjItem JPAEDJJFFOI) =>
                    {
                        //0xFF3A8C
                        return JPAEDJJFFOI.PPFNGGCBJKC_Id == KIJAPOFAGPN;
                    });
                    if(it != null)
                    {
                        l.Add(c);
                    }
                }
            }
        }
        return CJLGPDLLHKC(l);
    }

	// // RVA: 0x12C8C48 Offset: 0x12C8C48 VA: 0x12C8C48
	private List<BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL> CJLGPDLLHKC(List<DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD> BENDKLMPAKH)
    {
        List<BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL> l = new List<BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL>(NNLECFKJBFM.Count);
        foreach(var c in CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp)
        {
            foreach(var c2 in BENDKLMPAKH)
            {
                if(c2.HAJKNHNAIKL_ItemId == EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp, c.PPFNGGCBJKC_Id))
                {
                    l.Add(ACHKHIJMLHJ(c.PPFNGGCBJKC_Id));
                    BENDKLMPAKH.Remove(c2);
                    break;
                }
            }
            if(BENDKLMPAKH.IsEmpty())
                break;
        }
        return l;
    }

	// // RVA: 0x12C93FC Offset: 0x12C93FC VA: 0x12C93FC
	// public ReadOnlyCollection<KDKFHGHGFEK> DEDEDPHBBLN() { }

	// // RVA: 0x12C9474 Offset: 0x12C9474 VA: 0x12C9474
	// public KDKFHGHGFEK ODOGCNNGPCN(BCGFHLIEKLJ.GNGFGEIAGJL KOGBMDOONFA) { }

	// // RVA: 0x12C958C Offset: 0x12C958C VA: 0x12C958C
	// public int PAKNKLJEMBI(BCGFHLIEKLJ.GNGFGEIAGJL KOGBMDOONFA) { }

	// // RVA: 0x12C95C4 Offset: 0x12C95C4 VA: 0x12C95C4
	// public int PAKNKLJEMBI(BCGFHLIEKLJ.GNGFGEIAGJL KOGBMDOONFA, KDKFHGHGFEK IJHHPOKOBJF) { }

	// // RVA: 0x12C8068 Offset: 0x12C8068 VA: 0x12C8068
	// public bool KEPMKHNFJCN(BCGFHLIEKLJ.GNGFGEIAGJL KOGBMDOONFA) { }

	// // RVA: 0x12C9680 Offset: 0x12C9680 VA: 0x12C9680
	// public bool KEPMKHNFJCN(BCGFHLIEKLJ.GNGFGEIAGJL KOGBMDOONFA, KDKFHGHGFEK IJHHPOKOBJF) { }

	// // RVA: 0x12C9624 Offset: 0x12C9624 VA: 0x12C9624
	// public int OKMELNIIMMO(BCGFHLIEKLJ.GNGFGEIAGJL KOGBMDOONFA) { }

	// // RVA: 0x12C80F0 Offset: 0x12C80F0 VA: 0x12C80F0
	// private bool BGJCNDOBHCL(BCGFHLIEKLJ.GNGFGEIAGJL KOGBMDOONFA, CHKMLHDDPHO.HKGCIPJGEFG FMKECCHDHBL) { }

	// // RVA: 0x12C8408 Offset: 0x12C8408 VA: 0x12C8408
	// private void HJMKBCFJOOH(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0x12C9184 Offset: 0x12C9184 VA: 0x12C9184
	private BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL ACHKHIJMLHJ(int PPFNGGCBJKC)
    {
        BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL it = BGAMFLIMLAP.NBKAMFFIOOG_Sp.Find((BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL PKLPKMLGFGK) =>
        {
            //0xFF3E40
            return PKLPKMLGFGK.PPFNGGCBJKC_Id == PPFNGGCBJKC;
        });
        if(it == null)
        {
            it = BGAMFLIMLAP.NBKAMFFIOOG_Sp.Find((BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL PKLPKMLGFGK) =>
            {
                //0xFF3A58
                return PKLPKMLGFGK.DFIGPDCBAPB_IsNotInitialized();
            });
            if(it != null)
            {
                it.PPFNGGCBJKC_Id = PPFNGGCBJKC;
            }
        }
        return it;
    }
}