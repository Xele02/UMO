using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
        public class RaidBossInfo
        {
            public class Attacker
            {
                public int playerId;
                public int damage = 0;
                public bool receivedReward = false;
                public void Export(EDOHBJAPLPF_JsonData Res, EDOHBJAPLPF_JsonData Names)
                {
                    Res["player_id"] = playerId;
                    Res["damage"] = damage;
                    Res["player_data"] = new EDOHBJAPLPF_JsonData();
				    FillPlayerData(playerId, Res["player_data"], Names);
                }
                public EDOHBJAPLPF_JsonData Save()
                {
                    EDOHBJAPLPF_JsonData Res = new EDOHBJAPLPF_JsonData();
                    Res["playerId"] = playerId;
                    Res["damage"] = damage;
                    Res["receivedReward"] = receivedReward;
                    return Res;
                }

                public void Load(EDOHBJAPLPF_JsonData json)
                {
                    playerId = (int)json["playerId"];
                    damage = (int)json["damage"];
                    receivedReward = (bool)json["receivedReward"];
                }
            }

            public class Effect
            {
                public int id;
                public int numberOfTimes;
                public long createdAt;
                public long updatedAt;
                public long expiredAt;
                public int last_updated_player_id = -1;

                public EDOHBJAPLPF_JsonData Save()
                {
                    EDOHBJAPLPF_JsonData Res = new EDOHBJAPLPF_JsonData();
                    Res["id"] = id;
                    Res["numberOfTimes"] = numberOfTimes;
                    Res["createdAt"] = createdAt;
                    Res["updatedAt"] = updatedAt;
                    Res["expiredAt"] = expiredAt;
                    Res["last_updated_player_id"] = last_updated_player_id;
                    return Res;
                }

                public void Load(EDOHBJAPLPF_JsonData json)
                {
                    id = (int)json["id"];
                    numberOfTimes = (int)json["numberOfTimes"];
                    createdAt = JsonUtil.GetLong(json["createdAt"]);
                    updatedAt = JsonUtil.GetLong(json["updatedAt"]);
                    expiredAt = JsonUtil.GetLong(json["expiredAt"]);
                    last_updated_player_id = (int)json["last_updated_player_id"];
                }
            }

            public int id;
            public string unique_key;
            public int hp;
            public int max_hp;
            public int combo_count;
            public int status;
            public int firstAttackerId = -1;
            public int encounterPlayerId = -1;
            public long created_at;
            public long escaped_at;
            public List<Attacker> attackersList;
            public List<Effect> effectsList;

            public EDOHBJAPLPF_JsonData Save()
            {
                EDOHBJAPLPF_JsonData Res = new EDOHBJAPLPF_JsonData();
                Res["id"] = id;
                Res["unique_key"] = unique_key;
                Res["hp"] = hp;
                Res["max_hp"] = max_hp;
                Res["combo_count"] = combo_count;
                Res["status"] = status;
                Res["firstAttackerId"] = firstAttackerId;
                Res["encounterPlayerId"] = encounterPlayerId;
                Res["created_at"] = created_at;
                Res["escaped_at"] = escaped_at;
                Res["attackersList"] = new EDOHBJAPLPF_JsonData();
                Res["attackersList"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
                for(int i = 0; i < attackersList.Count; i++)
                {
                    Res["attackersList"].Add(attackersList[i].Save());
                }
                Res["effectsList"] = new EDOHBJAPLPF_JsonData();
                Res["effectsList"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
                for(int i = 0; i < effectsList.Count; i++)
                {
                    Res["effectsList"].Add(effectsList[i].Save());
                }
                return Res;
            }

            public void Load(EDOHBJAPLPF_JsonData json)
            {
                id = (int)json["id"];
                unique_key = (string)json["unique_key"];
                hp = (int)json["hp"];
                max_hp = (int)json["max_hp"];
                combo_count = (int)json["combo_count"];
                status = (int)json["status"];
                firstAttackerId = (int)json["firstAttackerId"];
                encounterPlayerId = (int)json["encounterPlayerId"];
                created_at = JsonUtil.GetLong(json["created_at"]);
                escaped_at = JsonUtil.GetLong(json["escaped_at"]);
                attackersList.Clear();
                for(int i = 0; i < json["attackersList"].HNBFOAJIIAL_Count; i++)
                {
                    Attacker atk = new Attacker();
                    atk.Load(json["attackersList"][i]);
                    attackersList.Add(atk);
                }
                for(int i = 0; i < json["effectsList"].HNBFOAJIIAL_Count; i++)
                {
                    Effect eff = new Effect();
                    eff.Load(json["effectsList"][i]);
                    effectsList.Add(eff);
                }
            }

            public void Attack(EDOHBJAPLPF_JsonData Req, EDOHBJAPLPF_JsonData Res, int userId)
            {
                if(status == 1) // TODO should send error already dead
                {
                    Attacker atk = attackersList.Find((Attacker _) =>
                    {
                        return _.playerId == userId;
                    });
                    if(atk == null)
                    {
                        attackersList.Add(new Attacker());
                        atk = attackersList.Last();
                        atk.playerId = userId;
                    }
                    int d = (int)Req["damage"];
                    atk.damage += d;
                    hp -= d;
                    if(hp <= 0)
                    {
                        hp = 0;
                        status = 2;
                    }
                    if(Req.BBAJPINMOEP_Contains("effectId"))
                    {
                        int effId = (int)Req["effectId"];
                        Effect eff = effectsList.Find((Effect _) =>
                        {
                            return _.id == effId;
                        });
                        if(eff == null)
                        {
                            eff = new Effect();
                            eff.createdAt = Utility.GetCurrentUnixTime();
                            eff.updatedAt = Utility.GetCurrentUnixTime();
                            eff.id = effId;
                            eff.numberOfTimes = 0;
                            effectsList.Add(eff);
                        }
                        eff.last_updated_player_id = userId;
                        eff.numberOfTimes += (int)Req["numberOfTimes"];
                        eff.updatedAt = Utility.GetCurrentUnixTime();
                        eff.expiredAt = eff.updatedAt + (int)Req["durationSeconds"];
                    }
                    Res["damage"] = atk.damage;
                }
                else
                {
                    Res["damage"] = 0;
                }

                Res["recent_attack_players"] = new EDOHBJAPLPF_JsonData();
                Res["recent_attack_players"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
            }

            public void ExportBossInfo(EDOHBJAPLPF_JsonData Res, int type, int userId)
            {
                if(type == 1)
                {
                    Res["id"] = id;
                    Res["unique_key"] = unique_key;
                    Res["hp"] = hp;
                    Res["max_hp"] = max_hp;
                    Res["combo_count"] = combo_count;
                    Res["attack_player_count"] = attackersList.Count;
                    Res["encounter_player_id"] = encounterPlayerId;
                    Res["created_at"] = created_at;
                    Res["escaped_at"] = escaped_at;
                    Attacker selfAtk = attackersList.Find((Attacker _) =>
                    {
                        return userId == _.playerId;
                    });
                    Res["has_attacked"] = selfAtk != null;
                    Res["can_receive_rewards"] = !selfAtk.receivedReward;
                    Res["can_request_help"] = true;
                }
                if(type == 1 || type == 3)
                {
                    Res["status"] = status;
                    if(attackersList.Count > 0)
                    {
                        Res["last_attack_player_id"] = attackersList.Last().playerId;
                    }
                }
                if(type == 1 || type == 2)
                {
                    Res["effects"] = new EDOHBJAPLPF_JsonData();
                    Res["effects"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
                    //request_player_id ?
                    for(int i = 0; i < effectsList.Count; i++)
                    {
                        EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
                        data["effect_id"] = effectsList[i].id;
                        data["number_of_times"] = effectsList[i].numberOfTimes;
                        data["created_at"] = effectsList[i].createdAt;
                        data["updated_at"] = effectsList[i].updatedAt;
                        data["expired_at"] = effectsList[i].expiredAt;
                        if(effectsList[i].last_updated_player_id != -1)
                        {
                            data["last_updated_player_id"] = effectsList[i].last_updated_player_id;
                            //last_updated_player_data todo
                        }
                        Res["effects"].Add(data);
                    }
                }
            }

            public void ExportAttackerList(EDOHBJAPLPF_JsonData Res, int numMax, EDOHBJAPLPF_JsonData namespaces, int userId)
            {
                for(int i = Mathf.Max(0, attackersList.Count - numMax ); i < attackersList.Count; i++)
                {
                    EDOHBJAPLPF_JsonData atkData = new EDOHBJAPLPF_JsonData();
                    attackersList[i].Export(atkData, namespaces);
                    Res.Add(atkData);
                }
            }
            public bool ExportFirstAttacker(EDOHBJAPLPF_JsonData Res, EDOHBJAPLPF_JsonData namespaces, int userId)
            {
                if(firstAttackerId > -1)
                {
                    Attacker atk = attackersList.Find((Attacker _) =>
                    {
                        return _.playerId == firstAttackerId;
                    });
                    if(atk != null)
                    {
                        atk.Export(Res, namespaces);
                        return true;
                    }
                }
                return false;
            }
            public bool ExportFinishAttacker(EDOHBJAPLPF_JsonData Res, EDOHBJAPLPF_JsonData namespaces, int userId)
            {
                if(status == 2 && attackersList.Count > 0)
                {
                    attackersList.Last().Export(Res, namespaces);
                    return true;
                }
                return false;
            }

            public void SetRewardReceived(int userId)
            {
                Attacker atk = attackersList.Find((Attacker _) => { return _.playerId == userId; });
                if(atk != null)
                    atk.receivedReward = true;
            }
        }

		public class UserRaidInfos
		{
			public List<RaidBossInfo> Bosses = new List<RaidBossInfo>();
			public int nextBossId = 0;

			public void Load(EDOHBJAPLPF_JsonData data)
			{
				nextBossId = 0;
				if(!data.BBAJPINMOEP_Contains("user_data"))
					return;
				if(!data["user_data"].BBAJPINMOEP_Contains("raid_info"))
					return;
				EDOHBJAPLPF_JsonData json = data["user_data"]["raid_info"];
                if(json.BBAJPINMOEP_Contains("bosses"))
                {
                    for(int i = 0; i < json["bosses"].HNBFOAJIIAL_Count; i++)
                    {
                        RaidBossInfo boss = new RaidBossInfo();
                        boss.Load(json["bosses"][i]);
                        nextBossId = Mathf.Max(nextBossId, boss.id + 1);
                    }
                }
			}

			public void Save(EDOHBJAPLPF_JsonData data)
			{
				if(!data.BBAJPINMOEP_Contains("user_data"))
					data["user_data"] = new EDOHBJAPLPF_JsonData();

				data["user_data"]["raid_info"] = new EDOHBJAPLPF_JsonData();
                data["user_data"]["raid_info"]["bosses"] = new EDOHBJAPLPF_JsonData();
                data["user_data"]["raid_info"]["bosses"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
                for(int i = 0; i < Bosses.Count; i++)
                {
                    data["user_data"]["raid_info"]["bosses"].Add(Bosses[i].Save());
                }
			}

            public void GetRaidboss(EDOHBJAPLPF_JsonData Request, EDOHBJAPLPF_JsonData Result, int userId)
            {
                int bossId = (int)Request["entityId"];
                RaidBossInfo boss = Bosses.Find((RaidBossInfo _) =>
                {
                    return _.id == bossId;
                });
                if(boss != null)
                {
                    EDOHBJAPLPF_JsonData raidBoss = new EDOHBJAPLPF_JsonData();
                    Result["raidboss"] = raidBoss;
                    boss.ExportBossInfo(raidBoss, 1, userId);
                    Result["attack_players"] = new EDOHBJAPLPF_JsonData();
                    Result["attack_players"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
                    boss.ExportAttackerList(Result["attack_players"], (int)Request["playerCount"], Request["namespaces"], userId);
                    EDOHBJAPLPF_JsonData p = new EDOHBJAPLPF_JsonData();
                    if(boss.ExportFirstAttacker(p, Request["namespaces"], userId))
                    {
                        Result["first_attack_player"] = p;
                    }
                    p = new EDOHBJAPLPF_JsonData();
                    if(boss.ExportFinishAttacker(p, Request["namespaces"], userId))
                    {
                        Result["finish_player"] = p;
                    }
                }
            }

            public void EncounterRaidboss(EDOHBJAPLPF_JsonData Request, EDOHBJAPLPF_JsonData Result, int userId)
            {
                string uniqueKey = (string)Request["uniqueKey"];
                Debug.LogError("Created boss with unique key "+uniqueKey);
                string[] parts = uniqueKey.Split(new char[]{'_'});
                int idx = int.Parse(parts[0]);
                RaidBossInfo boss = new RaidBossInfo();
                /*PKNOKJNLPOE_EventRaid ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
                BKOGPDBKFFJ_EventRaid db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev.JOPOPMLFINI_QuestId) as BKOGPDBKFFJ_EventRaid;*/
                boss.id = nextBossId;
                nextBossId++;
                boss.status = 1;
                boss.encounterPlayerId = userId;
                boss.created_at = Utility.GetCurrentUnixTime();
                boss.escaped_at = Utility.GetCurrentUnixTime() + 999999999999; // TODO
                boss.unique_key = uniqueKey;
                boss.max_hp = 100; // TODO
                boss.hp = boss.max_hp;
                Bosses.Add(boss);
                if(boss != null)
                {
                    boss.ExportBossInfo(Result, 2, userId);
                }
            }

            public void GetMyRaidbosses(EDOHBJAPLPF_JsonData Request, EDOHBJAPLPF_JsonData Result, int userId)
            {
                List<RaidBossInfo> bosses = Bosses.FindAll((RaidBossInfo _) =>
                {
                    return _.attackersList.Find((RaidBossInfo.Attacker __) =>
                    {
                        return __.playerId == userId;
                    }) != null;
                });
                Result["raidbosses"] = new EDOHBJAPLPF_JsonData();
                Result["raidbosses"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
                foreach(var boss in bosses)
                {
                    EDOHBJAPLPF_JsonData raidBoss = new EDOHBJAPLPF_JsonData();
                    Result["raidbosses"].Add(raidBoss);

                    boss.ExportBossInfo(raidBoss, 1, userId);
                }
            }

            public void ReceiveReward(EDOHBJAPLPF_JsonData Request, int userId)
            {
                int bossId = (int)Request["entityId"];
                RaidBossInfo boss = Bosses.Find((RaidBossInfo _) =>
                {
                    return _.id == bossId;
                });
                if(boss != null)
                {
                    boss.SetRewardReceived(userId);
                }
            }

            public void AttackBoss(EDOHBJAPLPF_JsonData Request, EDOHBJAPLPF_JsonData Result, int userId)
            {
                int bossId = (int)Request["entityId"];
                RaidBossInfo boss = Bosses.Find((RaidBossInfo _) =>
                {
                    return _.id == bossId;
                });
                if(boss != null)
                {
                    boss.Attack(Request, Result, userId);
                    EDOHBJAPLPF_JsonData raidBoss = new EDOHBJAPLPF_JsonData();
                    Result["raidboss"] = raidBoss;
                    boss.ExportBossInfo(raidBoss, 3, userId);
                }
            }
		};

        public static int SakashoRaidbossAttackRaidbossAndSave(int callbackId, string json)
        {
            /*
            In :
                entityId => int
                damage => int
                attackPlayerCount => int
                [effectId] => int
                [numberOfTimes] => int
                [durationSeconds] => int
                namespacesForResponse => string[]
                namespacesForSave => string[]
                playerData => string
                replace => bool

            Out :
                damage => int
                raidboss => LMJHOAHBDKN
                    status => (int)NHCDBBBMFFG
                    last_attack_player_id => int
                recent_attack_players => List<GKIJMGEBIDG>
                    player_id => int
                    player_data => Json
                created_at => long
                updated_at => long
                data_status => int
            */

			EDOHBJAPLPF_JsonData req = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			EDOHBJAPLPF_JsonData res = GetBaseMessage();

            UserRaidInfos raidInfo = playerAccount.playerData.raidInfos;
            raidInfo.AttackBoss(res, req, playerAccount.userId);

            SavePlayerData(req, res);
			SendMessage(callbackId, res);
            return 0;
        }

        public static int SakashoRaidbossEncounterRaidboss(int callbackId, string json)
        {
            /*
            In : 
                uniqueKey => string (boss_{0}_{1}_{2}{3} idx, setupid?, ?, _sp si EX )
            Out:
                => CMPLGKFJCIC<EBHIMFFJBIJ>/LBICPMOLOKD
                    id => int
                    unique_key => string
                    hp => int
                    max_hp => int
                    combo_count => int
                    attack_player_count => int
                    encounter_player_id => int
                    created_at => long
                    escaped_at => long
                    effects => List<EBHIMFFJBIJ>
                        effect_id => int
                        number_of_times => int
                        created_at => long
                        updated_at => long
                        expired_at => long
                        [last_updated_player_id] => int
            */

			EDOHBJAPLPF_JsonData req = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			EDOHBJAPLPF_JsonData res = GetBaseMessage();

            UserRaidInfos raidInfo = playerAccount.playerData.raidInfos;
            raidInfo.EncounterRaidboss(res, req, playerAccount.userId);

			SendMessage(callbackId, res);
            return 0;
        }

        public static int SakashoRaidbossGetMyRaidbosses(int callbackId, string json)
        {
            /*
            IN : 
            OUT : 
                raidbosses: List<NCMFOICNJEB<EBHIMFFJBIJ>/CMPLGKFJCIC<EBHIMFFJBIJ>/LBICPMOLOKD>
                    id => int
                    unique_key => string
                    hp => int
                    max_hp => int
                    combo_count => int
                    attack_player_count => int
                    encounter_player_id => int
                    created_at => long
                    escaped_at => long
                    status => int(NHCDBBBMFFG)
                    [last_attack_player_id] => int
                    has_attacked => bool
                    can_receive_rewards => bool
                    can_request_help => bool
                    [request_player_id] => int
                    effects => List<EBHIMFFJBIJ>
                        effect_id => int
                        number_of_times => int
                        created_at => long
                        updated_at => long
                        expired_at => long
                        [last_updated_player_id] => int
            */
			EDOHBJAPLPF_JsonData req = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			EDOHBJAPLPF_JsonData res = GetBaseMessage();

            UserRaidInfos raidInfo = playerAccount.playerData.raidInfos;
            raidInfo.GetMyRaidbosses(res, req, playerAccount.userId);

			SendMessage(callbackId, res);
            return 0;
        }

        public static int SakashoRaidbossSetRaidbossRewardsReceivedAndSave(int callbackId, string json)
        {
            /*
            In:
                entityId => int
                names => string[]
                [playerData] => string
                replace => bool
            Out:
                created_at => long
                updated_at => long
                data_status => int
            */
			EDOHBJAPLPF_JsonData req = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			EDOHBJAPLPF_JsonData res = GetBaseMessage();

            UserRaidInfos raidInfo = playerAccount.playerData.raidInfos;
            raidInfo.ReceiveReward(req, playerAccount.userId);

            SavePlayerData(req, res);
			SendMessage(callbackId, res);
            return 0;
        }

        public static int SakashoRaidbossGetRaidboss(int callbackId, string json)
        {
            /*
            In:
                entityId => int
                playerCount => int
                namespaces => string[]
            Out:
                raidboss => NCMFOICNJEB<MFKPFMCLOIB>/CMPLGKFJCIC<EBHIMFFJBIJ>/LBICPMOLOKD
                    id => int
                    unique_key => string
                    hp => int
                    max_hp => int
                    combo_count => int
                    attack_player_count => int
                    encounter_player_id => int
                    created_at => long
                    escaped_at => long
                    status => int(NHCDBBBMFFG)
                    [last_attack_player_id] => int
                    has_attacked => bool
                    can_receive_rewards => bool
                    can_request_help => bool
                    [request_player_id] => int
                    effects => List<MFKPFMCLOIB>
                        effect_id => int
                        number_of_times => int
                        created_at => long
                        updated_at => long
                        expired_at => long
                        [last_updated_player_id] => int
                        [last_updated_player_data] => json
                attack_players => List<BJIJAEOEHBJ>
                [first_attack_player] => BJIJAEOEHBJ
                [finish_player] => BJIJAEOEHBJ
                    player_id => int
                    damage => int
                    player_data => json
            */
			EDOHBJAPLPF_JsonData req = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			EDOHBJAPLPF_JsonData res = GetBaseMessage();

            UserRaidInfos raidInfo = playerAccount.playerData.raidInfos;
            raidInfo.GetRaidboss(res, req, playerAccount.userId);

			SendMessage(callbackId, res);
            return 0;
        }

        public static int SakashoRaidbossRequestRaidbossHelp(int callbackId, string json)
        {
            /*
            In:
                entityId => int
                friendPlayerCount => int
                otherPlayerCount => int
                namespaces => string[]
                [searchKey] => string
                searchNumberFrom => int
                searchNumberTo => int
            Out:
                friend_help_players => List<GHPAICMBHNJ>
                    player_id => int
                    player_data => json
                other_help_players => List<EPKECJKFKJH>
                    player_id => int
                    player_data => json
            */
			EDOHBJAPLPF_JsonData req = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			EDOHBJAPLPF_JsonData res = GetBaseMessage();

            // No help request in solo
            res["friend_help_players"] = new EDOHBJAPLPF_JsonData();
            res["friend_help_players"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
            res["other_help_players"] = new EDOHBJAPLPF_JsonData();
            res["other_help_players"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);

			SendMessage(callbackId, res);
            return 0;
        }
    }
}