using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use ENBPNDFOOCK_RequestRaidbossHelp", true)]
public class ENBPNDFOOCK {}
public class ENBPNDFOOCK_RequestRaidbossHelp : CACGCMBKHDI_NetBaseAction
{
    public class GDGEBGHDHBE
    {
        public int KJPDHNJGEAH_EntityId; // 0x8
        public int IHIANEHALAD_FriendPlayerCount; // 0xC
        public int NIKGBLBENGD_OtherPlayerCount; // 0x10
        public List<string> GACJGEENCKM_Namespaces; // 0x14
        public string ILABNPMBCAK_SearchKey; // 0x18
        public int ANOJACPGGNO_SearchNumberFrom; // 0x1C
        public int FOGLBBANMAP_SearchNumberTo; // 0x20
    }

    public class FHFAAOMLEPF
    {
        public class OFDFOMEFOAG
        {
            public int MLPEHNBNOGD_PlayerId; // 0x8
            public EDOHBJAPLPF_JsonData AHEFHIMGIBI_PlayerData; // 0xC

            // RVA: 0x130A620 Offset: 0x130A620 VA: 0x130A620
            public OFDFOMEFOAG(EDOHBJAPLPF_JsonData _DLENPPIJNPA_json)
            {
                MLPEHNBNOGD_PlayerId = (int)_DLENPPIJNPA_json["player_id"];
                AHEFHIMGIBI_PlayerData = _DLENPPIJNPA_json["player_data"];
            }
        }

        public class GHPAICMBHNJ : OFDFOMEFOAG
        {
            // RVA: 0x130A598 Offset: 0x130A598 VA: 0x130A598
            public GHPAICMBHNJ(EDOHBJAPLPF_JsonData _DLENPPIJNPA_json)
                : base(_DLENPPIJNPA_json)
            {
                //
            }
        }

        public class EPKECJKFKJH : OFDFOMEFOAG
        {
            // RVA: 0x130A61C Offset: 0x130A61C VA: 0x130A61C
            public EPKECJKFKJH(EDOHBJAPLPF_JsonData _DLENPPIJNPA_json)
                : base(_DLENPPIJNPA_json)
            {
                //
            }
        }

        public List<GHPAICMBHNJ> LBMEJEDJJFM_friend_help_players = new List<GHPAICMBHNJ>(); // 0x8
        public List<EPKECJKFKJH> ENDAPLAFFAI_other_help_players = new List<EPKECJKFKJH>(); // 0xC

        // RVA: 0x130A0E8 Offset: 0x130A0E8 VA: 0x130A0E8
        public FHFAAOMLEPF(EDOHBJAPLPF_JsonData _DLENPPIJNPA_json)
        {
            LBMEJEDJJFM_friend_help_players.MAECPJAJNBO(_DLENPPIJNPA_json.PFBEBCDEIND("friend_help_players"), (GIINMFDIIMD _IDLHJIOMJBK_data) =>
            {
                //0x130A518
                return new GHPAICMBHNJ(GIINMFDIIMD.JNEJKMKNIJJ(_IDLHJIOMJBK_data));
            });
            ENDAPLAFFAI_other_help_players.MAECPJAJNBO(_DLENPPIJNPA_json.PFBEBCDEIND("other_help_players"), (GIINMFDIIMD _IDLHJIOMJBK_data) =>
            {
                //0x130A59C
                return new EPKECJKFKJH(GIINMFDIIMD.JNEJKMKNIJJ(_IDLHJIOMJBK_data));
            });
        }
    }

	public const int DHCHACHAEKA = 15;
	public GDGEBGHDHBE BIHCCEHLAOD = new GDGEBGHDHBE(); // 0x7C
	public FHFAAOMLEPF NFEAMMJIMPG_Result; // 0x80

	// RVA: 0x1309E30 Offset: 0x1309E30 VA: 0x1309E30 Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoRaidboss.RequestRaidbossHelp(BIHCCEHLAOD.KJPDHNJGEAH_EntityId,
            BIHCCEHLAOD.IHIANEHALAD_FriendPlayerCount, BIHCCEHLAOD.NIKGBLBENGD_OtherPlayerCount, 
            BIHCCEHLAOD.GACJGEENCKM_Namespaces.ToArray(), BIHCCEHLAOD.ILABNPMBCAK_SearchKey, 
            BIHCCEHLAOD.ANOJACPGGNO_SearchNumberFrom, BIHCCEHLAOD.FOGLBBANMAP_SearchNumberTo,
            DCKLDDCAJAP, MEOCKCJBDAD);
    }

	// RVA: 0x130A02C Offset: 0x130A02C VA: 0x130A02C Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
    {
        NFEAMMJIMPG_Result = new FHFAAOMLEPF(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
    }
}
