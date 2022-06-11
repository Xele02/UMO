using UnityEngine;
using System.Collections.Generic;

public delegate bool FAPJEIOBPDG(List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData NMICBJDPLOH);

// Namespace:
public class HDPLHCDAFHA{}
public class HDPLHCDAFHA_RequestMaster : CACGCMBKHDI_Request // TypeDefIndex: 10308
{
        // Fields
        public List<string> DFDLAIGFDAH; // 0x7C
        //[CompilerGeneratedAttribute] // RVA: 0x6691D4 Offset: 0x6691D4 VA: 0x6691D4
        //private bool OGLMMENAJFL_onSuccess; // 0x84

        // Properties
        public FAPJEIOBPDG MKGLJLCMGIB { get; set; } // JJMNHPMPMEN 0x80 //  CJEOCNPHGNM // MGABGLAGKCL
        public override bool EBPLLJGPFDA { get; set; } // OGLMMENAJFL_onSuccess 0x84

	// RVA: 0x174328C Offset: 0x174328C VA: 0x174328C Slot: 12
	//public override void DHLDNIEELHO() { } // Prepare request

        // RVA: 0x174339C Offset: 0x174339C VA: 0x174339C Slot: 13
        public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE) 
        {
                //string json = NGCAIEGPLKD_result;
                //EDOHBJAPLPF_JsonData data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);

                // Hack : don't call server request, directly call callback
                DIAMDBHBKBH();

        }

        // RVA: 0x1743458 Offset: 0x1743458 VA: 0x1743458 Slot: 14
        //public override bool HGPAELCGELL() { }

        // RVA: 0x1743460 Offset: 0x1743460 VA: 0x1743460 Slot: 15
        //public override void NLDKLFODOJJ() { }

        // RVA: 0x1743464 Offset: 0x1743464 VA: 0x1743464
        public/*private*/ void DIAMDBHBKBH()
        {
                string res = NGCAIEGPLKD_result;
                EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(res);
                if(MKGLJLCMGIB != null)
                {
                        bool val = MKGLJLCMGIB.Invoke(DFDLAIGFDAH, jsonData[AFEHLCGHAEE.NDFIEMPPMLF]);
                        DLKLLHPLANH = !val;
                }
                EBPLLJGPFDA = true;
        }

        public HDPLHCDAFHA_RequestMaster() 
        { 
                // hack, directly add result
                {
                        DCKLDDCAJAP("{\"SAKASHO_CURRENT_ASSET_REVISION\":\"20220502151005\",\"SAKASHO_CURRENT_DATE_TIME\":1652133206,\"SAKASHO_CURRENT_MASTER_REVISION\":5,\"master\":{\"s_ak\":{\"data\":[{\"f\":\".usm$\",\"id\":1,\"k\":0},{\"f\":\"/cd/.+\",\"id\":2,\"k\":949554539},{\"f\":\"/ct/ba/.+\",\"id\":3,\"k\":866112838},{\"f\":\"/ct/bg/.+\",\"id\":4,\"k\":410028269},{\"f\":\"/ct/im/.+\",\"id\":5,\"k\":579739071},{\"f\":\"/ct/lo/.+\",\"id\":6,\"k\":380347857},{\"f\":\"/ct/mc/.+\",\"id\":7,\"k\":853466636},{\"f\":\"/ct/rk/.+\",\"id\":8,\"k\":200771622},{\"f\":\"/ct/sc/.+\",\"id\":9,\"k\":298289254},{\"f\":\"/ct/sk/.+\",\"id\":10,\"k\":567032733},{\"f\":\"/ct/.+\",\"id\":11,\"k\":866112838},{\"f\":\"/dv/.+\",\"id\":12,\"k\":761263956},{\"f\":\"/ev/.+\",\"id\":13,\"k\":541464883},{\"f\":\"/gc/.+\",\"id\":14,\"k\":877735754},{\"f\":\"/gm/.+\",\"id\":15,\"k\":910325268},{\"f\":\"/handmode/.+\",\"id\":16,\"k\":221729951},{\"f\":\"/ly/.+\",\"id\":17,\"k\":583823592},{\"f\":\"/mc/.+\",\"id\":18,\"k\":181802077},{\"f\":\"/mn/.+\",\"id\":19,\"k\":376454431},{\"f\":\"/msg/.+\",\"id\":20,\"k\":381029147},{\"f\":\"/st/.+\",\"id\":21,\"k\":679962129},{\"f\":\"/vl/.+\",\"id\":22,\"k\":839243735},{\"f\":\".xab$\",\"id\":23,\"k\":363534241}],\"label\":0},\"s_sys_int\":{\"data\":[{\"id\":1,\"k\":\"m_0\",\"v\":17},{\"id\":2,\"k\":\"m_1\",\"v\":1},{\"id\":3,\"k\":\"m_2\",\"v\":1},{\"id\":4,\"k\":\"m_3\",\"v\":683274560},{\"id\":5,\"k\":\"w1_0\",\"v\":11},{\"id\":6,\"k\":\"w1_1\",\"v\":1},{\"id\":7,\"k\":\"w1_2\",\"v\":1024},{\"id\":8,\"k\":\"w1_3\",\"v\":147376530},{\"id\":9,\"k\":\"w2_0\",\"v\":13},{\"id\":10,\"k\":\"w2_1\",\"v\":1},{\"id\":11,\"k\":\"w2_2\",\"v\":1024},{\"id\":12,\"k\":\"w2_3\",\"v\":381974210},{\"id\":13,\"k\":\"s_0\",\"v\":11},{\"id\":14,\"k\":\"s_1\",\"v\":3},{\"id\":15,\"k\":\"s_2\",\"v\":1},{\"id\":16,\"k\":\"s_3\",\"v\":287485137},{\"id\":17,\"k\":\"w3_0\",\"v\":15},{\"id\":18,\"k\":\"w3_1\",\"v\":1},{\"id\":19,\"k\":\"w3_2\",\"v\":1024},{\"id\":20,\"k\":\"w3_3\",\"v\":158630777},{\"id\":17,\"k\":\"w4_0\",\"v\":17},{\"id\":18,\"k\":\"w4_1\",\"v\":1},{\"id\":19,\"k\":\"w4_2\",\"v\":1024},{\"id\":20,\"k\":\"w4_3\",\"v\":160752017},{\"id\":17,\"k\":\"w5_0\",\"v\":19},{\"id\":18,\"k\":\"w5_1\",\"v\":1},{\"id\":19,\"k\":\"w5_2\",\"v\":1024},{\"id\":20,\"k\":\"w5_3\",\"v\":271863121},{\"id\":21,\"k\":\"w6_0\",\"v\":21},{\"id\":22,\"k\":\"w6_1\",\"v\":1},{\"id\":23,\"k\":\"w6_2\",\"v\":1024},{\"id\":24,\"k\":\"w6_3\",\"v\":291893421},{\"id\":25,\"k\":\"w7_0\",\"v\":23},{\"id\":26,\"k\":\"w7_1\",\"v\":1},{\"id\":27,\"k\":\"w7_2\",\"v\":1024},{\"id\":28,\"k\":\"w7_3\",\"v\":372864131}],\"label\":0},\"s_sys_str\":{\"data\":[{\"id\":1,\"k\":\"dpass\",\"v\":\"aLRjyy\"}],\"label\":0}}}");
                        /*
                        {
                                "SAKASHO_CURRENT_ASSET_REVISION":"20220502151005",
                                "SAKASHO_CURRENT_DATE_TIME":1652133206,
                                "SAKASHO_CURRENT_MASTER_REVISION":5,
                                "master":
                                {
                                        "s_ak":
                                        {
                                                "data":
                                                [
                                                        {"f":".usm$","id":1,"k":0},
                                                        {"f":"/cd/.+","id":2,"k":949554539},
                                                        {"f":"/ct/ba/.+","id":3,"k":866112838},
                                                        {"f":"/ct/bg/.+","id":4,"k":410028269},
                                                        {"f":"/ct/im/.+","id":5,"k":579739071},
                                                        {"f":"/ct/lo/.+","id":6,"k":380347857},
                                                        {"f":"/ct/mc/.+","id":7,"k":853466636},
                                                        {"f":"/ct/rk/.+","id":8,"k":200771622},
                                                        {"f":"/ct/sc/.+","id":9,"k":298289254},
                                                        {"f":"/ct/sk/.+","id":10,"k":567032733},
                                                        {"f":"/ct/.+","id":11,"k":866112838},
                                                        {"f":"/dv/.+","id":12,"k":761263956},
                                                        {"f":"/ev/.+","id":13,"k":541464883},
                                                        {"f":"/gc/.+","id":14,"k":877735754},
                                                        {"f":"/gm/.+","id":15,"k":910325268},
                                                        {"f":"/handmode/.+","id":16,"k":221729951},
                                                        {"f":"/ly/.+","id":17,"k":583823592},
                                                        {"f":"/mc/.+","id":18,"k":181802077},
                                                        {"f":"/mn/.+","id":19,"k":376454431},
                                                        {"f":"/msg/.+","id":20,"k":381029147},
                                                        {"f":"/st/.+","id":21,"k":679962129},
                                                        {"f":"/vl/.+","id":22,"k":839243735},
                                                        {"f":".xab$","id":23,"k":363534241}
                                                ]
                                                ,"label":0
                                        },
                                        "s_sys_int":
                                        {
                                                "data":
                                                [
                                                        {"id":1,"k":"m_0","v":17},
                                                        {"id":2,"k":"m_1","v":1},
                                                        {"id":3,"k":"m_2","v":1},
                                                        {"id":4,"k":"m_3","v":683274560},
                                                        {"id":5,"k":"w1_0","v":11},
                                                        {"id":6,"k":"w1_1","v":1},
                                                        {"id":7,"k":"w1_2","v":1024},
                                                        {"id":8,"k":"w1_3","v":147376530},
                                                        {"id":9,"k":"w2_0","v":13},
                                                        {"id":10,"k":"w2_1","v":1},
                                                        {"id":11,"k":"w2_2","v":1024},
                                                        {"id":12,"k":"w2_3","v":381974210},
                                                        {"id":13,"k":"s_0","v":11},
                                                        {"id":14,"k":"s_1","v":3},
                                                        {"id":15,"k":"s_2","v":1},
                                                        {"id":16,"k":"s_3","v":287485137},
                                                        {"id":17,"k":"w3_0","v":15},
                                                        {"id":18,"k":"w3_1","v":1},
                                                        {"id":19,"k":"w3_2","v":1024},
                                                        {"id":20,"k":"w3_3","v":158630777},
                                                        {"id":17,"k":"w4_0","v":17},
                                                        {"id":18,"k":"w4_1","v":1},
                                                        {"id":19,"k":"w4_2","v":1024},
                                                        {"id":20,"k":"w4_3","v":160752017},
                                                        {"id":17,"k":"w5_0","v":19},
                                                        {"id":18,"k":"w5_1","v":1},
                                                        {"id":19,"k":"w5_2","v":1024},
                                                        {"id":20,"k":"w5_3","v":271863121},
                                                        {"id":21,"k":"w6_0","v":21},
                                                        {"id":22,"k":"w6_1","v":1},
                                                        {"id":23,"k":"w6_2","v":1024},
                                                        {"id":24,"k":"w6_3","v":291893421},
                                                        {"id":25,"k":"w7_0","v":23},
                                                        {"id":26,"k":"w7_1","v":1},
                                                        {"id":27,"k":"w7_2","v":1024},
                                                        {"id":28,"k":"w7_3","v":372864131}
                                                ]
                                                ,"label":0
                                        },
                                        "s_sys_str":
                                        {
                                                "data":
                                                [
                                                        {"id":1,"k":"dpass","v":"aLRjyy"}
                                                ]
                                                ,"label":0
                                        }
                                }
                        }
                        */
                }
        }
}