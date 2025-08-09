using System;
using System.Collections.Generic;
using System.Linq;

public static class UMOEventList
{
    public class EventData
    {
        public int Id;
        public string BlockName;
        public List<int> BgId = new List<int>();
        public string Name;
        public string Desc;
        public int EventBannerImageId = -1;
        public int GlobalBannerImageId = -1;
        public int MissionBannerImageId = -1;
        public List<int> LinkedEvent = new List<int>();

        public bool EnableBlock(string Name)
        {
            if(BlockName == Name || BlockName.Replace("raid", "raidlobby") == Name)
                return true;
            for(int i = 0; i < LinkedEvent.Count; i++)
            {
                EventData SubEv = GetEventData(LinkedEvent[i]);
                if(SubEv != null && SubEv.EnableBlock(Name))
                    return true;
            }
            return false;
        }

        public bool IsEventEnabled(int _Id)
        {
            if(Id == _Id)
                return true;
            for(int i = 0; i < LinkedEvent.Count; i++)
            {
                EventData SubEv = GetEventData(LinkedEvent[i]);
                if(SubEv != null && SubEv.IsEventEnabled(_Id))
                    return true;
            }
            return false;
        }
    }

    public static List<EventData> EventList = new List<EventData>()
    {
        // April Fools. key = april_fool_<Id>
        new EventData() { Id=-1, Name="None" },
        new EventData() { Id=10231, Name="Yami_Q_ray Mission", Desc="Glow in the dark (Extreme version)", BlockName="event_april_fool_a", BgId = new List<int>() { 81 }, GlobalBannerImageId = 723 }, //04/27/2022
        new EventData() { Id=10049, Name="Happy birthday ～カナメ～", BlockName="event_april_fool_b", GlobalBannerImageId = 409 }, //06/06/2022
        new EventData() { Id=10232, Name="レイド後ADV", BlockName="event_april_fool_c" }, // 06/24/2022
        new EventData() { Id=10233, Name="ラスト3日最終シナリオ", BlockName="event_april_fool_d", BgId = new List<int>() { 99 }  }, // 06/25/2022 
        new EventData() { Id=10047, Name="Happy birthday ～マキナ～", BlockName="event_april_fool_e", GlobalBannerImageId = 408 }, // 04/17/2022
        new EventData() { Id=10048, Name="Happy birthday ～ランカ～", Desc="ランキング", BlockName="event_april_fool_f", GlobalBannerImageId = 407 }, // 04/27/2022
        new EventData() { Id=10228, Name="復刻エイプリル", Desc="2018/2019/2020/2022 april fool songs", BlockName="event_april_fool_g", BgId=new List<int>() { 13, 36, 93 }, GlobalBannerImageId = 725 }, // 04/30/2022
        new EventData() { Id=10229, Name="復刻エイプリル2021", Desc="2021 april fool minigame", BlockName="event_april_fool_h", BgId=new List<int>() { 60 }, GlobalBannerImageId = 728 }, // 05/21/2022
        new EventData() { Id=10230, Name="レアアップスタースペシャルミッション", BlockName="event_april_fool_i", GlobalBannerImageId = 714}, // 05/16/2022
        new EventData() { Id=3046, Name="超時空ファイナルLive ～Act.3～", BlockName="event_battle_a"},
        new EventData() { Id=3044, Name="会えないときのValentine", BlockName="event_battle_b"},
        new EventData() { Id=3045, Name="吹き抜ける風 ～NEVER SAY DIE～", BlockName="event_battle_c"},
        new EventData() { Id=14010, Name="シルバームーン・ホーリームーン", BlockName="event_godiva_a"},
        new EventData() { Id=14011, Name="無垢になれ！ ～つらみ現在進行形～", BlockName="event_godiva_b"},
        new EventData() { Id=14012, Name="復刻　FLASH IN THE SOUL", BlockName="event_godiva_c"},
        new EventData() { Id=13037, Name="超銀河総力LIVE Final", BlockName="event_raid_a"},
        new EventData() { Id=13038, Name="超銀河総力LIVE", BlockName="event_raid_b"},
        new EventData() { Id=13039, Name="超銀河総力LIVE", BlockName="event_raid_c"},
        new EventData() { Id=13040, Name="超銀河総力LIVE", BlockName="event_raid_d"},
        new EventData() { Id=1061, Name="超時空ファイナルLive ～Act.1～", BlockName="event_collection_a"},
        new EventData() { Id=1059, Name="ふたりの恋のマホウ", BlockName="event_collection_b"},
        new EventData() { Id=1060, Name="復刻　超時空ヴィーナス ワルキューレ", BlockName="event_collection_c"},
        new EventData() { Id=8204, Name="年末年始娘々祭　娘くじ", BlockName="event_box_gacha_d", LinkedEvent={7009}},
        new EventData() { Id=8203, Name="4周年　娘々祭　娘くじ 後半", BlockName="event_box_gacha_e"},
        new EventData() { Id=8039, Name="3周年　娘々祭　娘くじ 後半", BlockName="event_box_gacha_f"},
        //new EventData() { Id=4, Name="GodivaRanking", BlockName="event_godiva_ranking"},
        new EventData() { Id=9007, Name="マクロスF ギャラクシーライブ 2021[リベンジ]", BlockName="event_present_campaign_a"},
        new EventData() { Id=2061, Name="復刻　夏だ！水着だ！ワル裏フェス！", BlockName="event_mission_a", LinkedEvent={8061}},
        new EventData() { Id=2062, Name="復刻　0-G Love", BlockName="event_mission_b", LinkedEvent={8062}},
        new EventData() { Id=2063, Name="超時空ファイナルLive ～Act.2～", BlockName="event_mission_c", LinkedEvent={8063}},
    };
    public static List<EventData> EventListHidden = new List<EventData>()
    {
        new EventData() { Id=7009, Name="4周年 娘々祭", BlockName="event_sp_a" },
        new EventData() { Id=8061, Name="アーネスト艦長からの報酬", BlockName="event_box_gacha_a"},
        new EventData() { Id=8062, Name="アーネスト艦長からの報酬", BlockName="event_box_gacha_b"},
        new EventData() { Id=8063, Name="アーネスト艦長からの報酬", BlockName="event_box_gacha_c"},
    };

    public static EventData GetEventData(int Id)
    {
        if(Id == -1)
            return null;
        List<EventData> All = new List<EventData>();
        All.AddRange(EventList);
        All.AddRange(EventListHidden);
        return All.Find((EventData d) =>
        {
            return d.Id == Id;
        });
    }

    public static EventData GetCurrentEvent()
    {
        UMO_PlayerPrefs.CheckLoad();
        return GetEventData(UMO_PlayerPrefs.GetInt("CurrentEvent", -1));
    }

    public static bool IsEventEnabled(int Id)
    {
        EventData ev = GetCurrentEvent();
        if(ev != null)
        {
            return ev.IsEventEnabled(Id);
        }
        return false;
    }

    public static void SetCurrentEvent(int EventId)
    {
        UMO_PlayerPrefs.SetInt("CurrentEvent", EventId);
        UMO_PlayerPrefs.Save();
    }
}