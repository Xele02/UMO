using System;
using System.Collections.Generic;

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
        //new EventData() { Id=4, Name="GodivaRanking", BlockName="event_godiva_ranking"},
    };

    public static EventData GetEventData(int Id)
    {
        return EventList.Find((EventData d) =>
        {
            return d.Id == Id;
        });
    }

    public static EventData GetCurrentEvent()
    {
        UMO_PlayerPrefs.CheckLoad();
        return UMOEventList.GetEventData(UMO_PlayerPrefs.GetInt("CurrentEvent", -1));
    }

    public static void SetCurrentEvent(int EventId)
    {
        UMO_PlayerPrefs.SetInt("CurrentEvent", EventId);
        UMO_PlayerPrefs.Save();
    }
}