using UnityEngine;
using XeSys;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;



#if UNITY_EDITOR
using UnityEditor;
#endif

public class DateDisplayAttribute : PropertyAttribute
{
}
public class UMItemTypeDisplayAttribute : PropertyAttribute
{
}

[Serializable]
public class DlcLoginBonus : DlcContent
{
    public class DlcContextLoginBonus : DlcContext
    {
    }

    [Serializable]
    public class LoginBonusSetup
    {
        [Serializable]
        public class RewardDay
        {
            [Serializable]
            public class RewardItems
            {
                public int Count;
                [UMItemTypeDisplayAttribute]
                public int Id;

                public void Serialize(EDOHBJAPLPF_JsonData jsonData)
                {
                    jsonData["item_id"] = Id;
                    jsonData["count"] = Count;
                }
                public void Deserialize(EDOHBJAPLPF_JsonData jsonData)
                {
                    Id = (int)jsonData["item_id"];
                    Count = (int)jsonData["count"];
                }
            }
            public List<RewardItems> Items = new List<RewardItems>();

            public void Serialize(EDOHBJAPLPF_JsonData jsonData)
            {
                jsonData["items"] = new EDOHBJAPLPF_JsonData();
                jsonData["items"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
                foreach(var it in Items)
                {
                    EDOHBJAPLPF_JsonData json_it = new EDOHBJAPLPF_JsonData();
                    it.Serialize(json_it);
                    jsonData["items"].Add(json_it);
                }
            }
            public void Deserialize(EDOHBJAPLPF_JsonData jsonData)
            {
                Items.Clear();
                for(int i = 0; i < jsonData["items"].HNBFOAJIIAL_Count; i++)
                {
                    RewardItems rit = new RewardItems();
                    rit.Deserialize(jsonData["items"][i]);
                    Items.Add(rit);
                }
            }
        }
        public int Id;
        public DlcTranslatedString Name = new DlcTranslatedString();
        public DlcTranslatedString Description = new DlcTranslatedString();
        public string Type = "campaign";
        [DateDisplay]
        public long StartDate;
        [DateDisplay]
        public long EndDate;
        public int RepeatCount = 0;
        public long RepeatPeriod = 0;
        public bool RepeatEachYear = false;
        public int BgId;
        public List<RewardDay> DayRewards = new List<RewardDay>();
        public bool RequireBgBundle = true;
        public DlcTranslatedString InventoryMessage = new DlcTranslatedString();

        public void Serialize(EDOHBJAPLPF_JsonData jsonData)
        {
            jsonData["id"] = Id;
            jsonData["name"] = new EDOHBJAPLPF_JsonData();
            Name.Serialize(jsonData["name"]);
            jsonData["description"] = new EDOHBJAPLPF_JsonData();
            Description.Serialize(jsonData["description"]);
            jsonData["type"] = Type;
            if(BgId != 0)
                jsonData["bg_id"] = BgId.ToString();
            jsonData["opened_at"] = StartDate;
            jsonData["closed_at"] = EndDate;
            if(RepeatCount != 0)
                jsonData["repeat_with_count"] = RepeatCount;
            if(RepeatPeriod != 0)
                jsonData["repeat_with_period"] = RepeatPeriod;
            if(RepeatEachYear)
                jsonData["repeat_each_year"] = RepeatEachYear;
            jsonData["inventory_message"] = new EDOHBJAPLPF_JsonData();
            InventoryMessage.Serialize(jsonData["inventory_message"]);
            jsonData["prizes"] = new EDOHBJAPLPF_JsonData();
            jsonData["prizes"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
            foreach(var p in DayRewards)
            {
                EDOHBJAPLPF_JsonData json_prize = new EDOHBJAPLPF_JsonData();
                p.Serialize(json_prize);
                jsonData["prizes"].Add(json_prize);
            }
        }

        public void Deserialize(EDOHBJAPLPF_JsonData jsonData)
        {
            Id = (int)jsonData["id"];
            Name.Deserialize(jsonData["name"]);
            Description.Deserialize(jsonData["description"]);
            Type = (string)jsonData["type"];
            if(jsonData.BBAJPINMOEP_Contains("bg_id"))
                BgId =  int.Parse((string)jsonData["bg_id"]);
            StartDate = (long)jsonData["opened_at"];
            EndDate = (long)jsonData["closed_at"];
            if(jsonData.BBAJPINMOEP_Contains("repeat_with_count"))
                RepeatCount = (int)jsonData["repeat_with_count"];
            if(jsonData.BBAJPINMOEP_Contains("repeat_with_period"))
                RepeatPeriod = (long)jsonData["repeat_with_period"];
            if(jsonData.BBAJPINMOEP_Contains("repeat_each_year"))
                RepeatEachYear = (bool)jsonData["repeat_each_year"];
            InventoryMessage.Deserialize(jsonData["inventory_message"]);
            DayRewards.Clear();
            for(int i = 0; i < jsonData["prizes"].HNBFOAJIIAL_Count; i++)
            {
                RewardDay rd = new RewardDay();
                rd.Deserialize(jsonData["prizes"][i]);
                DayRewards.Add(rd);
            }
        }
    }

    public List<LoginBonusSetup> LoginBonuses = new List<LoginBonusSetup>();

    DlcBuilderBase[] Files;

    private int GetLbUniqueId(int staticNum)
    {
        while(true)
        {
            int Num = UnityEngine.Random.Range(10000, 9999999);
            if(LoginBonuses.Find(d => d.Id == Num) == null)
                return Num;
        }
    }

    public override void UpdateDatabase(string dlcPath, DlcPackage dlc)
    {
        //base.UpdateDatabase(dlcPath);
        string dir = Path.Combine(dlcPath, "files", "login_bonus");
        LoginBonuses.Clear();
        if(Directory.Exists(dir))
        {
            foreach(var f in Directory.EnumerateFiles(dir, "*.json"))
            {
                try
                {
                    string content = File.ReadAllText(f);
                    EDOHBJAPLPF_JsonData json_data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(content);
                    LoginBonusSetup setup = new LoginBonusSetup();
                    setup.Deserialize(json_data);
                    LoginBonuses.Add(setup);
                }
                catch(Exception e)
                {
                    UnityEngine.Debug.LogError(e);
                }
            }
        }

        MFDJIFIIPJD itHelper = new MFDJIFIIPJD();
        foreach(var lb in LoginBonuses)
        {
            ExternLib.LibSakasho.LoginBonusData lbData = new ExternLib.LibSakasho.LoginBonusData();
            lbData.name = lb.Name.GetText();
            lbData.description = lb.Description.GetText();
            lbData.opened_at = lb.StartDate;
            lbData.closed_at = lb.EndDate;
            lbData.reset_at = lb.StartDate;
            lbData.id = GetLbUniqueId(lb.Id);
            if(lb.BgId != 0)
                lbData.name_for_apis = string.Format("{3}_{2}_{0:D4}_bg_{1:D3}", lb.Id, lb.BgId, lb.Type, dlc.PackageName);
            else
                lbData.name_for_apis = string.Format("{2}_{1}_{0:D4}", lb.Id, lb.Type, dlc.PackageName);
            if(lb.RepeatCount > 0)
            {
                lbData.repeat_with_count = true;
                lbData.max_count = lb.RepeatCount;
            }
            if(lb.RepeatPeriod > 0)
            {
                lbData.repeat_with_period = true;
                lbData.max_period = lb.RepeatPeriod;
            }
            lbData.repeat_every_year = lb.RepeatEachYear;
            lbData.prizes = new List<ExternLib.LibSakasho.LoginBonusData.Prize>();
            for(int i = 0; i < lb.DayRewards.Count; i++)
            {
                ExternLib.LibSakasho.LoginBonusData.Prize p = new ExternLib.LibSakasho.LoginBonusData.Prize();
                lbData.prizes.Add(p);
                p.is_lot = false;
                p.required_count = i + 1;
                p.inventory_message = lb.InventoryMessage.GetText();
                p.items = new List<ExternLib.LibSakasho.LoginBonusData.Prize.Items>();
                foreach(var it in lb.DayRewards[i].Items)
                {
                    ExternLib.LibSakasho.LoginBonusData.Prize.Items pit = new ExternLib.LibSakasho.LoginBonusData.Prize.Items();
                    p.items.Add(pit);
                    pit.count = it.Count;
                    itHelper.KHEKNNFCAOI_Init(it.Id, it.Count);
                    pit.name = itHelper.HAAJGNCFNJM_item_name;
                    pit.value = itHelper.OCNINMIMHGC_item_value;
                    pit.type = itHelper.MJBKGOJBPAD_item_type;
                }
            }
            if(lbData.max_count == 0)
                lbData.max_count = lbData.prizes.Count;
                
            ExternLib.LibSakasho.AddLoginBonus(lbData);
        }
    }

    public override void UpdateFileList(string dlcPath)
    {
        //base.UpdateFileList(dlcPath);
    }

    public override void UpdateBank(string bankName, MessageBank bank)
    {
        //base.UpdateBank(bankName, bank);
    }

    public override void Save(EDOHBJAPLPF_JsonData json_data)
    {
        json_data["login_bonus"] = new EDOHBJAPLPF_JsonData();
        json_data["login_bonus"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
    }

    public override void Build(DlcContext Context, string tmpDir, string outDir)
    {
        string dir = Path.Combine(outDir, "files", "login_bonus");
        Directory.CreateDirectory(dir);
        foreach(var lb in LoginBonuses)
        {
            EDOHBJAPLPF_JsonData jsonData = new EDOHBJAPLPF_JsonData();
            lb.Serialize(jsonData);
            File.WriteAllText(Path.Combine(dir, lb.Id.ToString() + ".json"), jsonData.EJCOJCGIBNG_ToJson());
        }
    }

    public override void Load(EDOHBJAPLPF_JsonData json_data)
    {
        if(json_data.BBAJPINMOEP_Contains("login_bonus"))
        {
            Enabled = true;
        }
    }

#if UNITY_EDITOR
    public override void FillBuilder(DlcBuilder builder)
    {
        foreach(var lb in LoginBonuses)
        {
            if(lb.BgId != 0)
            {
                builder.Bundles.Bundles.Add(new DlcBundleBuilder() {
                    NamePattern = string.Format("{0:D2}.xab", lb.BgId),
                    Path = "ct/bg/lo/",
                    Required = lb.RequireBgBundle,
                    Files = new DlcFileBuilder[] {
                        new DlcFileTextureBuilder() {
                            MaxSize = new Vector2(1024, 1024),
                            MinSize = new Vector2(1024, 1024),
                            NamePattern = string.Format("{0:D2}", lb.BgId),
                            Required = true,
                            TextureType = DlcFileTextureBuilder.ETextureType.SingleTexture
                        }
                    }
                });
            }
        }
    }
#endif
}

#if UNITY_EDITOR
/*[CustomPropertyDrawer(typeof(UMItemTypeDisplayAttribute))]
public class UMItemTypeDisplayDrawer : PropertyDrawer
{
    private int itemTypeIdx;
    private string[] itemTypeList = EKLNMHFCAOI_ItemManager.ABLJLBEPCHK;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;
        itemTypeIdx = EditorGUI.Popup(new Rect(position.x, position.y, position.width, position.height), itemTypeIdx, itemTypeList);
        EditorGUI.indentLevel = indent;
    }
}*/

[CustomPropertyDrawer(typeof(DateDisplayAttribute))]
public class DateDisplayDrawer : PropertyDrawer
{
    int dateTypeIdx = 1;
    int dateEditTypeIdx = 1;
    string[] dateTypeList = new string[] {"UTC", "JST"};
    bool enterAsTimestamp = true;

    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // First get the attribute since it contains the range for the slider
        //DateDisplayAttribute range = attribute as DateDisplayAttribute;

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;
        enterAsTimestamp = EditorGUI.Toggle(new Rect(position.x + position.width - 20, position.y, 20, position.height / 2), enterAsTimestamp);
        if(enterAsTimestamp)
            EditorGUI.PropertyField(new Rect(position.x, position.y, position.width - 20, position.height / 2), property, GUIContent.none);
        else
        {
            dateEditTypeIdx = EditorGUI.Popup(new Rect(position.x + position.width - 70, position.y, 50, position.height / 2), dateEditTypeIdx, dateTypeList);
            int day = 0;
            int month = 0;
            int year = 0;
            int hour = 0;
            int min = 0;
            int sec = 0;
            DateTime d = new DateTime();
            bool isValid = true;
            if(dateEditTypeIdx == 0)
            {
                d = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(property.intValue);
            }
            else
            {
                try
                {
                    TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById("Asia/Tokyo");
                    d = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(property.intValue), tst);
                }
                catch (Exception)
                {
                    isValid = false;
                    EditorGUI.LabelField(new Rect(position.x, position.y, position.width - 70, position.height / 2), "Timezone info not found for Asia/Tokyo");
                }
            }
            if(isValid)
            {
                day = d.Day;
                month = d.Month;
                year = d.Year;
                hour = d.Hour;
                min = d.Minute;
                sec = d.Second;
                float size = (position.width - 70) / 6;
                month = Mathf.Clamp(EditorGUI.IntField(new Rect(position.x + size, position.y, size, position.height / 2), month), 1, 12);
                year = Mathf.Max(1970, EditorGUI.IntField(new Rect(position.x + size * 2, position.y, size, position.height / 2), year));
                day = Mathf.Clamp(EditorGUI.IntField(new Rect(position.x, position.y, size, position.height / 2), day), 1, DateTime.DaysInMonth(year, month));
                hour = Mathf.Clamp(EditorGUI.IntField(new Rect(position.x + size * 3, position.y, size, position.height / 2), hour), 0, 23);
                min = Mathf.Clamp(EditorGUI.IntField(new Rect(position.x + size * 4, position.y, size, position.height / 2), min), 0, 59);
                sec = Mathf.Clamp(EditorGUI.IntField(new Rect(position.x + size * 5, position.y, size, position.height / 2), sec), 0, 59);
                if(dateEditTypeIdx == 0)
                {
                    d = new DateTime(year, month, day, hour, min, sec, 0, DateTimeKind.Utc);
                }
                else
                {
                    try
                    {
                        TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById("Asia/Tokyo");
                        d = TimeZoneInfo.ConvertTimeToUtc(new DateTime(year, month, day, hour, min, sec, 0, DateTimeKind.Unspecified), tst);
                    }
                    catch(Exception e)
                    {
                        isValid = false;
                        UnityEngine.Debug.LogError(e);
                    }
                }
                if(isValid)
                {
                    long newValue = (long)d.Subtract(XeSys.Utility.UNIX_EPOCH).TotalSeconds;
                    property.longValue = newValue;
                }
            }
        }
        dateTypeIdx = EditorGUI.Popup(new Rect(position.x + position.width - 50, position.y + position.height / 2, 50, position.height / 2), dateTypeIdx, dateTypeList);
        if(dateTypeIdx == 0)
            EditorGUI.LabelField(new Rect(position.x, position.y + position.height / 2, position.width - 50, position.height / 2), new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(property.intValue).ToString("d MMM yyy HH:mm:ss")+" UTC");
        else
        {
            try
            {
                TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById("Asia/Tokyo");
                EditorGUI.LabelField(new Rect(position.x, position.y + position.height / 2, position.width - 50, position.height / 2), TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(property.intValue), tst).ToString("d MMM yyy HH:mm:ss")+" UTC");
            }
            catch(Exception)
            {
                EditorGUI.LabelField(new Rect(position.x, position.y + position.height / 2, position.width - 50, position.height / 2), "Timezone info not found for Asia/Tokyo");
            }
        }
        EditorGUI.indentLevel = indent;
    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float height = base.GetPropertyHeight(property, label);
        return height * 2;
    }
}
#endif
