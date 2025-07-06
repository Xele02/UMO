
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ELNKLCNHDEE
{
	private const int OBHOPEGFNGN = 16;
	private const int JJGAPCGLIFL = 16;
	public bool PLOOEECNHFB; // 0x8
	public bool GBCOABCAJHG; // 0x9
	public bool NPNNPNAIONN; // 0xA
	public List<CEBFFLDKAEC_SecureInt> AILDCKKOLJG = new List<CEBFFLDKAEC_SecureInt>(); // 0xC
	public string MHCDHKLGGBG; // 0x10
	public List<GJDFHLBONOL> IPFEPMFHHAM; // 0x14
	public List<long> HBINEKIILJL; // 0x18
	private string BIDDPDCFFHA; // 0x1C

	// RVA: 0x1305F24 Offset: 0x1305F24 VA: 0x1305F24
	public void HBOKJNECOPA(string HAAJGNCFNJM/* = "trigger_item"*/)
    {
        NPNNPNAIONN = false;
        PLOOEECNHFB = false;
        GBCOABCAJHG = false;
        BIDDPDCFFHA = HAAJGNCFNJM;
        N.a.StartCoroutineWatched(JBGPGBKBOMH_Co_GetLotResultData());
    }

	// [IteratorStateMachineAttribute] // RVA: 0x6B5F48 Offset: 0x6B5F48 VA: 0x6B5F48
	// // RVA: 0x1305F7C Offset: 0x1305F7C VA: 0x1305F7C
	private IEnumerator JBGPGBKBOMH_Co_GetLotResultData()
    {
        SakashoInventoryCriteria GHDBABPAHKN; // 0x14
        List<GJDFHLBONOL> NMJONJBONLM; // 0x18
        LGJOOFGOGCD_RequestInventories BPOJOBICBAC; // 0x1C

        //0x130617C
        GHDBABPAHKN = new SakashoInventoryCriteria();
        GHDBABPAHKN.OnlyUnreceived = true;
        HBINEKIILJL = new List<long>();
        NMJONJBONLM = new List<GJDFHLBONOL>();
        int p = 1;
        while(true)
        {
            BPOJOBICBAC = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new LGJOOFGOGCD_RequestInventories());
            BPOJOBICBAC.IGNIIEBMFIN_Page = p;
            BPOJOBICBAC.MLPLGFLKKLI_Ipp = 30;
            BPOJOBICBAC.IPKCADIAAPG_Criteria = GHDBABPAHKN;
            while(!BPOJOBICBAC.PLOOEECNHFB_IsDone)
                yield return null;
            if(BPOJOBICBAC.NPNNPNAIONN_IsError)
            {
                PLOOEECNHFB = true;
                NPNNPNAIONN = true;
                yield break;
            }
            for(int i = 0; i < BPOJOBICBAC.NFEAMMJIMPG_ResultData.PJJFEAHIPGL.Count; i++)
            {
                if(BPOJOBICBAC.NFEAMMJIMPG_ResultData.PJJFEAHIPGL[i].HAAJGNCFNJM_ItemName == BIDDPDCFFHA)
                {
                    NMJONJBONLM.Add(BPOJOBICBAC.NFEAMMJIMPG_ResultData.PJJFEAHIPGL[i]);
                }
            }
            if(BPOJOBICBAC.NFEAMMJIMPG_ResultData.MDIBIIHAAPN_NextPage == 0)
                break;
            p = BPOJOBICBAC.NFEAMMJIMPG_ResultData.MDIBIIHAAPN_NextPage;
        }
        if(NMJONJBONLM.Count == 0)
        {
            Debug.Log("StringLiteral_10274");
            PLOOEECNHFB = true;
            GBCOABCAJHG = true;
        }
        else
        {
            NMJONJBONLM.Sort((GJDFHLBONOL HKICMNAACDA, GJDFHLBONOL BNKHBCBJBKI) =>
            {
                //0x1306130
                return HKICMNAACDA.OCNINMIMHGC_ItemValue.CompareTo(BNKHBCBJBKI.OCNINMIMHGC_ItemValue);
            });
            for(int i = 0; i < NMJONJBONLM.Count; i++)
            {
                HBINEKIILJL.Add(NMJONJBONLM[i].MDPJFPHOPCH_Id);
            }
            IPFEPMFHHAM = new List<GJDFHLBONOL>();
            for(int i = 0; i < NMJONJBONLM.Count; i++)
            {
                IPFEPMFHHAM.Add(NMJONJBONLM[i]);
            }
            AILDCKKOLJG.Clear();
            for(int i = 0; i < NMJONJBONLM.Count; i++)
            {
                for(int j = 0; j < NMJONJBONLM[i].MBJIFDBEDAC_ItemCount; j++)
                {
                    CEBFFLDKAEC_SecureInt c = new CEBFFLDKAEC_SecureInt();
                    c.DNJEJEANJGL_Value = NMJONJBONLM[i].OCNINMIMHGC_ItemValue;
                    AILDCKKOLJG.Add(c);
                }
            }
            StringBuilder str = new StringBuilder();
            bool b = false;
            for(int i = 0; i < AILDCKKOLJG.Count; i++)
            {
                if(b)
                    str.Append(',');
                str.Append(AILDCKKOLJG[i].DNJEJEANJGL_Value);
            }
            MHCDHKLGGBG = str.ToString();
            Debug.Log("StringLiteral_10275 " + MHCDHKLGGBG);
            PLOOEECNHFB = true;
        }
    }
}
