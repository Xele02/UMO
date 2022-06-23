
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
    ""SAKASHO_CURRENT_ASSET_REVISION"": ""20220613222105"",
    ""SAKASHO_CURRENT_DATE_TIME"": 1655761248,
    ""SAKASHO_CURRENT_MASTER_REVISION"": 5,
    ""base_url"": ""https://assets-sakasho.cdn-dena.com/1246/20220613222105"",
    ""files"": [
        {
            ""file"": ""/db/ar_event!sa4130fcbz!.dat"",
            ""hash_value"": ""753ef65fc2a73d7684a36c4a5025b9b0"",
            ""last_updated_at"": 1654745966
        },
        {
            ""file"": ""/db/ar_marker!s3e75269bz!.dat"",
            ""hash_value"": ""f2553780b0f2796e11a41aed42f7db2d"",
            ""last_updated_at"": 1654745966
        },
        {
            ""file"": ""/db/md-20170701-000000_v00000001_s1_h00000000!see11e970z!.dat"",
            ""hash_value"": ""e21174ba56518b172d009d8e12b32993"",
            ""last_updated_at"": 1654745966
        },
        {
            ""file"": ""/db/md-20170701-000000_v01000000_s0_h00000000!sbe7e64cfz!.dat"",
            ""hash_value"": ""a8ca951a5e5d07a0b30c7d52058006c4"",
            ""last_updated_at"": 1654745966
        },
        {
            ""file"": ""/db/md-20220529-000000_v00007630_s1_h00000000!s09a5539bz!.dat"",
            ""hash_value"": ""3d33cb836a38c1e78606f3849492f8a9"",
            ""last_updated_at"": 1654745966
        },
        {
            ""file"": ""/db/md-20220601-000000_v00007635_s1_h00000000!s710a70fdz!.dat"",
            ""hash_value"": ""78b3288661fa1c36c40cdb7a6f313f4c"",
            ""last_updated_at"": 1654745966
        },
        {
            ""file"": ""/db/md-20220601-110000_v00007637_s1_h00000000!s618d84f5z!.dat"",
            ""hash_value"": ""bd77cb113e05878449ce8acf765fae51"",
            ""last_updated_at"": 1654745966
        },
        {
            ""file"": ""/db/md-20220601-120000_v00007640_s1_h00000000!s1c1bb0acz!.dat"",
            ""hash_value"": ""503bc9a2471d90103c4b08ca3014727e"",
            ""last_updated_at"": 1654745966
        },
        {
            ""file"": ""/db/md-20220605-000000_v00007650_s1_h00000000!sfb50aedaz!.dat"",
            ""hash_value"": ""609d5291152fdd158834b97988d53805"",
            ""last_updated_at"": 1654745966
        },
        {
            ""file"": ""/db/md-20220606-000000_v00007660_s1_h00000000!se15da7baz!.dat"",
            ""hash_value"": ""162ffe0da64a34ccd9a25e52b6ea61e1"",
            ""last_updated_at"": 1654745966
        },
        {
            ""file"": ""/db/md-20220607-000000_v00007670_s1_h00000000!s94a79346z!.dat"",
            ""hash_value"": ""d60974f7efc78a3751da26bfde222712"",
            ""last_updated_at"": 1654745966
        },
        {
            ""file"": ""/db/md-20220608-120000_v00007690_s1_h00000000!s0770fff0z!.dat"",
            ""hash_value"": ""e4ee61d88b6f9fab0fb017e5ac6035c5"",
            ""last_updated_at"": 1654745966
        },
        {
            ""file"": ""/db/md-20220611-000000_v00007700_s1_h00000000!sa05467cdz!.dat"",
            ""hash_value"": ""70eb9572b2ec667c4f49b0b0871373cc"",
            ""last_updated_at"": 1654745966
        },
        {
            ""file"": ""/db/md-20220615-120000_v00007720_s1_h00000000!s89aade2az!.dat"",
            ""hash_value"": ""55cba8c39990f6b4ab7826eedbd794c7"",
            ""last_updated_at"": 1654745966
        },
        {
            ""file"": ""/db/md-20220616-000000_v00007730_s1_h00000000!s99522649z!.dat"",
            ""hash_value"": ""ed6c3d1177dd5c12b1fb7651768dd551"",
            ""last_updated_at"": 1654745966
        },
        {
            ""file"": ""/db/md-20220617-000000_v00007740_s1_h00000000!se2dc19afz!.dat"",
            ""hash_value"": ""640633545e57c4d25996de47fdfb3f91"",
            ""last_updated_at"": 1654745966
        },
        {
            ""file"": ""/db/md-20220618-120000_v00007750_s1_h00000000!s194f08f0z!.dat"",
            ""hash_value"": ""f5ad611efb2bce27869f94fa944c08dd"",
            ""last_updated_at"": 1654745966
        },
        {
            ""file"": ""/db/md-20220621-120000_v00007760_s1_h00000000!sdd9835c1z!.dat"",
            ""hash_value"": ""6a82e3ae24039adcc20cc5aad010bf98"",
            ""last_updated_at"": 1654745966
        },
        {
            ""file"": ""/db/md-20220623-000000_v00007770_s1_h00000000!s6f563c05z!.dat"",
            ""hash_value"": ""a18e822d503cce76d486823ed4e93358"",
            ""last_updated_at"": 1654745966
        },
        {
            ""file"": ""/db/md-20220624-210000_v00007780_s1_h00000000!sb8f86186z!.dat"",
            ""hash_value"": ""ecac91e0c2329fd6fb6775000445153b"",
            ""last_updated_at"": 1654745966
        },
        {
            ""file"": ""/db/md-20220626-000000_v00007790_s1_h00000000!s602bc890z!.dat"",
            ""hash_value"": ""5583e6abea715d152af15af1d23f3dac"",
            ""last_updated_at"": 1654745966
        },
        {
            ""file"": ""/db/sd!s6b10b98cz!.dat"",
            ""hash_value"": ""9ed90d80750874d7d783a260988769f6"",
            ""last_updated_at"": 1649387947
        }
    ]
}";
            }
            else if(json.Contains("android"))
            {
                message = System.Text.Encoding.UTF8.GetString(System.IO.File.ReadAllBytes(UnityEngine.Application.dataPath+"/../../Data/RequestGetFiles.json"));
            }
            else
            {
                UnityEngine.Debug.LogError("TODO SakashoAssetGetAssetList "+json);
            }
            UnityEngine.GameObject.Find(UnityCallbackObject).SendMessage("NotifyOnSuccess", ""+callbackId+":"+message);
            // end hack

            return 0;
        }
    }
}