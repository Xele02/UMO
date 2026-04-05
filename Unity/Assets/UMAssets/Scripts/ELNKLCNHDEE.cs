
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//namespace XeApp.Game.Net
[System.Obsolete()]
public class ELNKLCNHDEE {}
public class ELNKLCNHDEE_NetEventLotResultData
{
	private const int OBHOPEGFNGN = 16;
	private const int JJGAPCGLIFL = 16;
	public bool PLOOEECNHFB_IsDone; // 0x8
	public bool GBCOABCAJHG; // 0x9
	public bool NPNNPNAIONN_IsError; // 0xA
	public List<CEBFFLDKAEC_SecureInt> AILDCKKOLJG_Results = new List<CEBFFLDKAEC_SecureInt>(); // 0xC
	public string MHCDHKLGGBG; // 0x10
	public List<GJDFHLBONOL> IPFEPMFHHAM; // 0x14
	public List<long> HBINEKIILJL; // 0x18
	private string BIDDPDCFFHA; // 0x1C

	// RVA: 0x1305F24 Offset: 0x1305F24 VA: 0x1305F24
	public void HBOKJNECOPA_GetMaster(string _HAAJGNCFNJM_item_name/* = "trigger_item"*/)
    {
        NPNNPNAIONN_IsError = false;
        PLOOEECNHFB_IsDone = false;
        GBCOABCAJHG = false;
        BIDDPDCFFHA = _HAAJGNCFNJM_item_name;
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
            BPOJOBICBAC = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new LGJOOFGOGCD_RequestInventories());
            BPOJOBICBAC.IGNIIEBMFIN_Page = p;
            BPOJOBICBAC.MLPLGFLKKLI_Ipp = 30;
            BPOJOBICBAC.IPKCADIAAPG_Criteria = GHDBABPAHKN;
            while(!BPOJOBICBAC.PLOOEECNHFB_IsDone)
                yield return null;
            if(BPOJOBICBAC.NPNNPNAIONN_IsError)
            {
                PLOOEECNHFB_IsDone = true;
                NPNNPNAIONN_IsError = true;
                yield break;
            }
            for(int i = 0; i < BPOJOBICBAC.NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories.Count; i++)
            {
                if(BPOJOBICBAC.NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories[i].HAAJGNCFNJM_item_name == BIDDPDCFFHA)
                {
                    NMJONJBONLM.Add(BPOJOBICBAC.NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories[i]);
                }
            }
            if(BPOJOBICBAC.NFEAMMJIMPG_Result.MDIBIIHAAPN_next_page == 0)
                break;
            p = BPOJOBICBAC.NFEAMMJIMPG_Result.MDIBIIHAAPN_next_page;
        }
        if(NMJONJBONLM.Count == 0)
        {
            Debug.Log("StringLiteral_10274");
            PLOOEECNHFB_IsDone = true;
            GBCOABCAJHG = true;
        }
        else
        {
            NMJONJBONLM.Sort((GJDFHLBONOL _HKICMNAACDA_a, GJDFHLBONOL _BNKHBCBJBKI_b) =>
            {
                //0x1306130
                return _HKICMNAACDA_a.OCNINMIMHGC_item_value.CompareTo(_BNKHBCBJBKI_b.OCNINMIMHGC_item_value);
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
            AILDCKKOLJG_Results.Clear();
            for(int i = 0; i < NMJONJBONLM.Count; i++)
            {
                for(int j = 0; j < NMJONJBONLM[i].MBJIFDBEDAC_item_count; j++)
                {
                    CEBFFLDKAEC_SecureInt c = new CEBFFLDKAEC_SecureInt();
                    c.DNJEJEANJGL_Value = NMJONJBONLM[i].OCNINMIMHGC_item_value;
                    AILDCKKOLJG_Results.Add(c);
                }
            }
            StringBuilder str = new StringBuilder();
            bool b = false;
            for(int i = 0; i < AILDCKKOLJG_Results.Count; i++)
            {
                if(b)
                    str.Append(',');
                str.Append(AILDCKKOLJG_Results[i].DNJEJEANJGL_Value);
            }
            MHCDHKLGGBG = str.ToString();
            Debug.Log("StringLiteral_10275 " + MHCDHKLGGBG);
            PLOOEECNHFB_IsDone = true;
        }
    }
}
