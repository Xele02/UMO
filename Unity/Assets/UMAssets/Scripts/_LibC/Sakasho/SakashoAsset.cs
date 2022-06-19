
namespace ExternLib
{
    public static partial class LibSakasho
    {
        public static int SakashoAssetGetAssetList(int callbackId, string json)
        {
            string message = "{}";
            if(json.Contains("db"))
            {
                // Hack directly send response
                message =
@"{
    ""SAKASHO_CURRENT_ASSET_REVISION"": ""20220602120304"",
    ""SAKASHO_CURRENT_DATE_TIME"": 1654415204,
    ""SAKASHO_CURRENT_MASTER_REVISION"": 5,
    ""base_url"": ""https://assets-sakasho.cdn-dena.com/1246/20220602120304"",
    ""files"": [
        {
            ""file"": ""/db/ar_event!sa4130fcbz!.dat"",
            ""hash_value"": ""57815e2298aea9d7158d812ae8041e45"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/ar_marker!s3e75269bz!.dat"",
            ""hash_value"": ""c51a732cfd5ae6f5d48f1068c27b71eb"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/md-20170701-000000_v00000001_s1_h00000000!see11e970z!.dat"",
            ""hash_value"": ""42dc3fc9c8d3f40b1817d5ec908616e0"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/md-20170701-000000_v01000000_s0_h00000000!sbe7e64cfz!.dat"",
            ""hash_value"": ""495186a4781bfffac1fd0fe677dce8ec"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/md-20220428-000000_v00007490_s1_h00000000!s15767cabz!.dat"",
            ""hash_value"": ""b96e09c39fdf518318f00cd69727cc5a"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/md-20220428-120000_v00007500_s1_h00000000!sb3594478z!.dat"",
            ""hash_value"": ""f5d50f72520caff13c67170fb5a3c8dc"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/md-20220429-000000_v00007510_s1_h00000000!s5356990dz!.dat"",
            ""hash_value"": ""112262f1c450bd037d2c95efc40330a8"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/md-20220501-000000_v00007520_s1_h00000000!s9c9f2a41z!.dat"",
            ""hash_value"": ""9d7fb0f7fe03a1fd59bfcbbe442ae1d4"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/md-20220506-120000_v00007530_s1_h00000000!s9944ab52z!.dat"",
            ""hash_value"": ""5d8f951b9a33d9a4ea9077f87023b892"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/md-20220508-000000_v00007540_s1_h00000000!s163025dcz!.dat"",
            ""hash_value"": ""9fad8fb69a566577eda6be4368088f06"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/md-20220511-120000_v00007550_s1_h00000000!s149355e8z!.dat"",
            ""hash_value"": ""1550021cf780b6fec33be6f6ed073737"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/md-20220515-000000_v00007560_s1_h00000000!s587ceea4z!.dat"",
            ""hash_value"": ""1500ea8b7fefac55672265c8f6da554f"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/md-20220515-120000_v00007570_s1_h00000000!sa7c08422z!.dat"",
            ""hash_value"": ""841963512ff5baa152f48e98dcd004cb"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/md-20220517-000000_v00007580_s1_h00000000!sb93170c8z!.dat"",
            ""hash_value"": ""5f7a325c888b59a69ee8c596cba73f2a"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/md-20220517-150000_v00007590_s1_h00000000!sa6ed597dz!.dat"",
            ""hash_value"": ""77abaa5a5719e2203fe4d9b70b88de27"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/md-20220520-120000_v00007600_s1_h00000000!s1b9cae8cz!.dat"",
            ""hash_value"": ""5923e47aba27ccb2d0399b2fe74e95e8"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/md-20220522-000000_v00007610_s1_h00000000!s9920d404z!.dat"",
            ""hash_value"": ""111d8f33515f3c5d87f9c09769d6920d"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/md-20220527-000000_v00007620_s1_h00000000!s71ace632z!.dat"",
            ""hash_value"": ""63a0c20a54fb00601c34c9eaa78f5fb9"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/md-20220529-000000_v00007630_s1_h00000000!s09a5539bz!.dat"",
            ""hash_value"": ""f71c09961c5fb918a702131c088e8704"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/md-20220601-000000_v00007635_s1_h00000000!s710a70fdz!.dat"",
            ""hash_value"": ""4ea7af4fce25f4ded55bd9d1ac8790ae"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/md-20220601-110000_v00007637_s1_h00000000!s618d84f5z!.dat"",
            ""hash_value"": ""1fcc6e5ba6903b0903aaa66a810f42ad"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/md-20220601-120000_v00007640_s1_h00000000!s1c1bb0acz!.dat"",
            ""hash_value"": ""87a35b62b0b0742412df9ca2d802f6c7"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/md-20220605-000000_v00007650_s1_h00000000!sfb50aedaz!.dat"",
            ""hash_value"": ""70626f9390d83e21357764d6f591ff78"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/md-20220606-000000_v00007660_s1_h00000000!se15da7baz!.dat"",
            ""hash_value"": ""860e2d606225e710277af943dd0350c5"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/md-20220607-000000_v00007670_s1_h00000000!s94a79346z!.dat"",
            ""hash_value"": ""47adb837295c3f7aae740c9fbf1355e7"",
            ""last_updated_at"": 1654081712
        },
        {
            ""file"": ""/db/sd!s6b10b98cz!.dat"",
            ""hash_value"": ""9ed90d80750874d7d783a260988769f6"",
            ""last_updated_at"": 1649387947
        }
    ]
}";
            }
            else
            {
                UnityEngine.Debug.LogError("TODO");
            }
            UnityEngine.GameObject.Find(UnityCallbackObject).SendMessage("NotifyOnSuccess", ""+callbackId+":"+message);
            // end hack

            return 0;
        }
    }
}