using System.Collections.Generic;
using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public class ThreadInfo
		{
			public ThreadInfo() {}
			public class Comment
			{
				public int Idx;
				public bool Sage;
				public string Extra;
				public string Nickname;
				public string Content;
				public int ReplyTo = -1;
				public List<int> ReplyFrom = new List<int>();
				public int WritterId;
				public long WrittenAt;
				public long UpdatedAt;

				public EDOHBJAPLPF_JsonData Save(int saveType)
				{
					//saveType = 0 : Profile save
					//saveType = 1 : GetComment request
					EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
					res["comment_index"] = Idx;
					res["extra"] = Extra;
					res["content"] = Content;
					res["nickname"] = Nickname;
					res["comment_writer_id"] = WritterId;
					res["written_at"] = WrittenAt;
					res["updated_at"] = UpdatedAt;
					res["reply_to"] = ReplyTo;
					res["reply_from"] = new EDOHBJAPLPF_JsonData();
					res["reply_from"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
					for(int i = 0; i < ReplyFrom.Count; i++)
					{
						res["reply_from"].Add(ReplyFrom[i]);
					}
					res["sage"] = Sage;
					if(saveType == 0)
					{
					}
					return res;
				}

				public void Load(EDOHBJAPLPF_JsonData data, bool isFromCreate = false)
				{
					ReplyFrom = new List<int>();
					if(isFromCreate)
					{

					}
					else
					{
						if(data.BBAJPINMOEP_Contains("comment_index"))
							Idx = (int)data["comment_index"];
						WritterId = (int)data["comment_writer_id"];
						WrittenAt = JsonUtil.GetLong(data, "written_at", 0);
						UpdatedAt = JsonUtil.GetLong(data, "updated_at", 0);
						if(data.BBAJPINMOEP_Contains("reply_from"))
						{
							EDOHBJAPLPF_JsonData d = data["reply_from"];
							for(int i = 0; i < d.HNBFOAJIIAL_Count; i++)
							{
								ReplyFrom.Add((int)d[i]);
							}
						}
					}
					if(data.BBAJPINMOEP_Contains("reply_to"))
						ReplyTo = (int)data["reply_to"];
					if(data.BBAJPINMOEP_Contains("replyTo"))
						ReplyTo = (int)data["replyTo"];
					Content = (string)data["content"];
					Nickname = (string)data["nickname"];
					Sage = (bool)data["sage"];
					Extra = (string)data["extra"];
				}

				public void Create(int idx, EDOHBJAPLPF_JsonData data, int userId)
				{
					Idx = idx;
					WritterId = userId;
					WrittenAt = Utility.GetCurrentUnixTime();
					UpdatedAt = Utility.GetCurrentUnixTime();
					Load(data, true);
				}
			};

			public int Id = -1;
			public string Title;
			public string Detail;
			public string ThreadGroup;
			public string Extra;
			public int MinCommentBytes;
			public int MaxCommentBytes;
			public int MaxComments;
			public int ExpireDays;
			public int ThreadScore;
			public List<int> WritePlayerIds;
			public List<int> UpdatePlayerIds;
			public int ApplyOwnerBlacklist;
			public bool CommentRotate = false;
			public int OwnerId;
			public int LastUpdaterId;
			public long CreatedAt;
			public long UpdatedAt;
			public long LastCommentWritenAt;
			public long LastCommentUpdatetAt;
			public List<Comment> Comments = new List<Comment>();

			public void Load(EDOHBJAPLPF_JsonData data, bool fromCreate = false)
			{
				if(!fromCreate)
				{
					Id = (int)data["id"];
					CommentRotate = (bool)data["comment_rotate"];
					Comments = new List<Comment>();
					EDOHBJAPLPF_JsonData commentData = data["comments"];
					Comments.Clear();
					for(int i = 0; i < commentData.HNBFOAJIIAL_Count; i++)
					{
						Comment c = new Comment();
						c.Load(commentData[i]);
						Comments.Add(c);
					}
					OwnerId = (int)data["thread_owner_id"];
					LastUpdaterId = (int)data["last_thread_updater_id"];
					CreatedAt = JsonUtil.GetLong(data, "thread_created_at", 0);
					UpdatedAt = JsonUtil.GetLong(data, "last_thread_updated_at", 0);
					LastCommentWritenAt = JsonUtil.GetLong(data, "last_comment_written_at", 0);
					LastCommentUpdatetAt = JsonUtil.GetLong(data, "last_comment_updated_at", 0);
				}
				if(data.BBAJPINMOEP_Contains("title") && data["title"] != null)
					Title = (string)data["title"];
				if(data.BBAJPINMOEP_Contains("detail") && data["detail"] != null)
					Detail = (string)data["detail"];
				if(data.BBAJPINMOEP_Contains("threadGroup") && data["threadGroup"] != null)
					ThreadGroup = (string)data["threadGroup"];
				if(data.BBAJPINMOEP_Contains("extra") && data["extra"] != null)
					Extra = (string)data["extra"];
				MinCommentBytes = (int)data["minCommentBytes"];
				MaxCommentBytes = (int)data["maxCommentBytes"];
				MaxComments = (int)data["maxComments"];
				ExpireDays = (int)data["expireDays"];
				ThreadScore = (int)data["threadScore"];
				WritePlayerIds = null;
				if(data.BBAJPINMOEP_Contains("writePlayerIds"))
				{
					WritePlayerIds = new List<int>();
					EDOHBJAPLPF_JsonData d = data["writePlayerIds"];
					if(d != null)
					{
						for(int i = 0; i < d.HNBFOAJIIAL_Count; i++)
						{
							WritePlayerIds.Add((int)d[i]);
						}
					}
				}
				if(data.BBAJPINMOEP_Contains("updatePlayerIds"))
				{
					UpdatePlayerIds = new List<int>();
					EDOHBJAPLPF_JsonData d = data["updatePlayerIds"];
					if(d != null)
					{
						for(int i = 0; i < d.HNBFOAJIIAL_Count; i++)
						{
							UpdatePlayerIds.Add((int)d[i]);
						}
					}
				}
				ApplyOwnerBlacklist = (int)data["applyOwnerBlacklist"];
			}

			public EDOHBJAPLPF_JsonData Save(int saveType)
			{
				//saveType = 0 : Profile save
				//saveType = 1 : GetThread request
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				if(saveType == 1)
				{
					res["thread_id"] = Id;
					res["comments_count"] = Comments.Count;
					res["current_comments_count"] = Comments.Count; // ??
					res["min_comment_bytes"] = MinCommentBytes;
					res["max_comment_bytes"] = MaxCommentBytes;
					res["max_comments"] = MaxComments;
					if(MaxComments == -1)
						res["max_comments"] = int.MaxValue;
					res["expire_days"] = ExpireDays;
					res["thread_score"] = ThreadScore;
					res["thread_group"] = ThreadGroup;
					res["apply_owner_blacklist"] = ApplyOwnerBlacklist == 1;
				}
				res["title"] = Title;
				res["comment_rotate"] = CommentRotate;
				res["thread_owner_id"] = OwnerId;
				res["last_thread_updater_id"] = LastUpdaterId;
				res["thread_created_at"] = CreatedAt;
				res["last_thread_updated_at"] = UpdatedAt;
				res["last_comment_written_at"] = LastCommentWritenAt;
				res["last_comment_updated_at"] = LastCommentUpdatetAt;
				if(saveType == 0 || !string.IsNullOrEmpty(Extra))
					res["extra"] = Extra;
				if(saveType == 0)
				{
					res["id"] = Id;
					res["detail"] = Detail;
					res["minCommentBytes"] = MinCommentBytes;
					res["maxCommentBytes"] = MaxCommentBytes;
					res["maxComments"] = MaxComments;
					res["expireDays"] = ExpireDays;
					res["threadScore"] = ThreadScore;
					res["threadGroup"] = ThreadGroup;
					res["applyOwnerBlacklist"] = ApplyOwnerBlacklist;
					if(WritePlayerIds != null)
					{
						res["writePlayerIds"] = new EDOHBJAPLPF_JsonData();
						res["writePlayerIds"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
						for(int i = 0; i < WritePlayerIds.Count; i++)
						{
							res["writePlayerIds"].Add(WritePlayerIds[i]);
						}
					}
					if(UpdatePlayerIds != null)
					{
						res["updatePlayerIds"] = new EDOHBJAPLPF_JsonData();
						res["updatePlayerIds"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
						for(int i = 0; i < UpdatePlayerIds.Count; i++)
						{
							res["updatePlayerIds"].Add(UpdatePlayerIds[i]);
						}
					}
					res["comments"] = new EDOHBJAPLPF_JsonData();
					res["comments"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
					for(int i = 0; i < Comments.Count; i++)
					{
						res["comments"].Add(Comments[i].Save(0));
					}
				}
				return res;
			}

			public void Create(int Id, EDOHBJAPLPF_JsonData createData, int userId)
			{
				this.Id = Id;
				OwnerId = userId;
				LastUpdaterId = userId;
				CreatedAt = Utility.GetCurrentUnixTime();
				UpdatedAt = Utility.GetCurrentUnixTime();
				Load(createData, true);
			}

			public int AddComment(EDOHBJAPLPF_JsonData createData, int userId)
			{
				Comment c = new Comment();
				int idx = Comments.Count;
				c.Create(idx, createData, userId);
				Comments.Add(c);
				WritePlayerIds.Add(userId);
				LastCommentWritenAt = c.WrittenAt;
				LastCommentUpdatetAt = c.UpdatedAt;
				return idx;
			}
		};

		public class UserThreads
		{
			public Dictionary<int, ThreadInfo> Threads = new Dictionary<int, ThreadInfo>();
			public int nextThreadId = 0;

			public void Load(EDOHBJAPLPF_JsonData data)
			{
				nextThreadId = 0;
				if(!data.BBAJPINMOEP_Contains("user_data"))
					return;
				if(!data["user_data"].BBAJPINMOEP_Contains("threads"))
					return;
				EDOHBJAPLPF_JsonData json = data["user_data"]["threads"];
				if(json.BBAJPINMOEP_Contains("threads"))
				{
					EDOHBJAPLPF_JsonData array = json["threads"];
					for(int i = 0; i < array.HNBFOAJIIAL_Count; i++)
					{
						ThreadInfo d = new ThreadInfo();
						d.Load(array[i]);
						Threads.Add(d.Id, d);
						nextThreadId = d.Id + 1;
					}
				}
			}

			public void Save(EDOHBJAPLPF_JsonData data)
			{
				if(!data.BBAJPINMOEP_Contains("user_data"))
					data["user_data"] = new EDOHBJAPLPF_JsonData();

				data["user_data"]["threads"] = new EDOHBJAPLPF_JsonData();
				data["user_data"]["threads"]["threads"] = new EDOHBJAPLPF_JsonData();
				data["user_data"]["threads"]["threads"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
				foreach(var k in Threads)
				{
					data["user_data"]["threads"]["threads"].Add(k.Value.Save(0));
				}
			}

			public int CreateThread(EDOHBJAPLPF_JsonData data, int userId)
			{
				int id = nextThreadId;
				Threads.Add(id, new ThreadInfo());
				Threads[id].Create(id, data, userId);
				nextThreadId++;
				return id;
			}

			public int AddComment(EDOHBJAPLPF_JsonData data, int userId)
			{
				int threadId = (int)data["threadId"];
				if(Threads.ContainsKey(threadId))
				{
					return Threads[threadId].AddComment(data, userId);
				}
				return -1;
			}
		};

		public static int SakashoBbsGetThreads(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData req = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);

			UserThreads threadData = playerAccount.playerData.bbsThreadCache;

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["threads"] = new EDOHBJAPLPF_JsonData();
			res["threads"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			foreach(var t in threadData.Threads)
			{
				if(req.BBAJPINMOEP_Contains("threadGroup"))
				{
					if (t.Value.ThreadGroup != null)
					{
						if ((string)req["threadGroup"] != t.Value.ThreadGroup)
							continue;
					}
					else
						continue;
				}
				res["threads"].Add(t.Value.Save(1));
			}
			res["current_page"] = 1;
			res["previous_page"] = 0;
			res["next_page"] = 0;

			SendMessage(callbackId, res);

			return 0;
		}

		public static int SakashoBbsCreateThread(int callbackId, string json)
		{
			/*
			{"updatePlayerIds":null, "writePlayerIds":null, "threadScore":0, "minCommentBytes":-1, "maxComments":-1, "maxCommentBytes":-1, "title":"none", "applyOwnerBlacklist":0, "threadGroup":"554933243_deco", "expireDays":60}
			In : 
			{
				(opt)"title" = (string),
				(opt)"detail" = (string),
				(opt)"threadGroup" = (string),
				(opt)"extra" = (string),
				"minCommentBytes" = (int),
				"maxCommentBytes" = (int),
				"maxComments" = (int),
				"expireDays" = (int),
				"threadScore" = (int),
				(opt)writePlayerIds = [
					(int)
				],
				(opt)updatePlayerIds = [
					(int)
				],
				"applyOwnerBlacklist" = (int)
			}

			Out : 
			{
				"thread_id" = (int)
			}
			*/

			UserThreads threadData = playerAccount.playerData.bbsThreadCache;
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			EDOHBJAPLPF_JsonData threadInfo = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			res["thread_id"] = threadData.CreateThread(threadInfo, playerAccount.userId);

			SaveAccountServerData();

			SendMessage(callbackId, res);

			return 0;
		}

		public static int SakashoBbsGetThreadComments(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData req = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);

			UserThreads threadData = playerAccount.playerData.bbsThreadCache;
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			int threadId = (int)req["threadId"];
			res["thread"] = threadData.Threads[threadId].Save(1);
			res["comments"] = new EDOHBJAPLPF_JsonData();
			res["comments"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int i = 0; i < threadData.Threads[threadId].Comments.Count; i++)
			{
				res["comments"].Add(threadData.Threads[threadId].Comments[i].Save(1));
			}
			res["current_page"] = 1;
			res["previous_page"] = 0;
			res["next_page"] = 0;

			SendMessage(callbackId, res);

			return 0;
		}

		public static int SakashoBbsCreateThreadComment(int callbackId, string json)
		{
			//{"sage":false, "extra":"{\"type\":1,\"dv\":6,\"dvc\":101,\"dvcc\":0,\"em\":1,\"emc\":0,\"utarr\":1,\"utar\":603}", "nickname":"Xele", "threadId":6, "content":"test", "replyTo":0}
			EDOHBJAPLPF_JsonData req = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);

			UserThreads threadData = playerAccount.playerData.bbsThreadCache;
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["comment_index"] = threadData.AddComment(req, playerAccount.userId);

			SaveAccountServerData();

			SendMessage(callbackId, res);

			return 0;
		}

	}
}
