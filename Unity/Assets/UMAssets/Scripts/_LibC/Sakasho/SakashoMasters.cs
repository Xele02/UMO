using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using XeSys;

namespace ExternLib
{
    public static partial class LibSakasho
    {
        public static string DecompressGZipBase64String(string input)
        {
            byte[] data = System.Convert.FromBase64String(input);
            using (var uncompressed = new MemoryStream())
            using (var inStream = new MemoryStream(data))
            using (var outStream = new GZipStream(inStream, CompressionMode.Decompress))
            {
                outStream .CopyTo(uncompressed);
                return Encoding.UTF8.GetString(uncompressed.ToArray());
            }

        }

        public static int SakashoMasterGetMasters(int callbackId, string json)
        {
            UnityEngine.Debug.Log("SakashoMasterGetMasters "+json);
            // Hack directly send response

            string data1 = DecompressGZipBase64String("H4sIAAV4g1sAA3XTS24CMQwG4LtE3RVB/Igdc5WqC2AoRTAgdVrUquLuHU1ANouu88lxfjsvv+ktLdP8a+if0iztu7SEWTqkZb7O2tFi0y3mz7cznM6MrRQuZG4+F+uVM5pYFQHASvWB7ZzxxBhyxoryUG3fOysTK2pKlhUiO56dycSoZmKtRSPrN8609VaIRYQkso+DszoxzFkVBDGyIVSzxqxiNSz8wEI1yO0NoplQiaJzBP/E1l0CaiNQARSy4v1vI2oDKAwsXKtftwutQ4u/qioVDb3vQvbQwjcY+y4o3tP76tT1524baBsAIiiaFZ/T8SegFn8Zn4dUzHONI4IWPlSoGccBODoF1KInFS7M5Nf1Q1gxzLetgIwG7KWGEDy24EXNBAF9ES/HgFrwlQyZxsTuaP69Wt+/DrbcSWhcL2S4vv4BlAfAEGADAAA=");
            string data2 = DecompressGZipBase64String("H4sIAEsIJ2IAA33TO27DMBBF0b2wVsE3Hw7prQRBmjRBkCpAUgTeewyY82yIskvhUjriiHr5Kx/v5YStfJZT+XqrZSs/l+s4b9ciWTBLBs0gu2AZ9BpaVwnzVnOBXxf8ghrvbUx7LljSq2IZO+M0YaHRXGmOuUJoaiZUtj0KMB2oENbJascIE5DFnNL3ulVYpqneXsiz7EeLlmWC0sO6Q/m5kHNSis7W2ZaNDqaDjUplzfl6b1ojVtfWI0TXHrv21DW6rYZLxeo63bG4/tj1p65zzoHLhiF8gOTJaOneNWHbu6JMR66xpjvQh9rds/PnCbo8N9LYFjeYjtzOmgc5pDeD4vz6D6Z8qHIiBAAA");

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["master"] = new EDOHBJAPLPF_JsonData();
			res["master"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);

			res["master"]["s_ak"] = new EDOHBJAPLPF_JsonData();
			res["master"]["s_ak"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
			res["master"]["s_ak"]["data"] = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(data1);
			res["master"]["s_ak"]["label"] = 0;

			res["master"]["s_sys_int"] = new EDOHBJAPLPF_JsonData();
			res["master"]["s_sys_int"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
			res["master"]["s_sys_int"]["data"] = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(data2);
			res["master"]["s_sys_int"]["label"] = 0;

			res["master"]["s_sys_str"] = new EDOHBJAPLPF_JsonData();
			res["master"]["s_sys_str"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
			res["master"]["s_sys_str"]["data"] = new EDOHBJAPLPF_JsonData();
			res["master"]["s_sys_str"]["data"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			res["master"]["s_sys_str"]["data"].Add(new EDOHBJAPLPF_JsonData());
			res["master"]["s_sys_str"]["data"][0].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
			res["master"]["s_sys_str"]["data"][0]["id"] = 1;
			res["master"]["s_sys_str"]["data"][0]["k"] = "dpass";
			res["master"]["s_sys_str"]["data"][0]["v"] = "aLRjyy";
			res["master"]["s_sys_str"]["label"] = 0;

			SendMessage(callbackId, res);
			// end hack

			return 0;
        }
    }
}

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
}*/
