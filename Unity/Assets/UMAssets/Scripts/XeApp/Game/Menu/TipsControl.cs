using XeSys;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public struct TipsData // TypeDefIndex: 16710
	{
		public int id; // 0x0
		public string title; // 0x4
		public string message; // 0x8
		public int imageId; // 0xC
		public int graffitiId; // 0x10
		public int divaLId; // 0x14
		public int divaRId; // 0x18
		public TipsTexture texture; // 0x1C
		public TipsTexture graffiti; // 0x20
		public TipsTexture divaL; // 0x24
		public TipsTexture divaR; // 0x28

		// RVA: 0x7FA8FC Offset: 0x7FA8FC VA: 0x7FA8FC
		public TipsData(BCKMELFCKKN_Tips.ALLFFCNKFBG data)
		{
			id = data.PPFNGGCBJKC_Id;
			title = data.ADCMNODJBGJ_Title;
			message = data.JONNCMDGMKA_Message;
			imageId = data.EAHPLCJMPHD_ImageId;
			graffitiId = data.LKDJHPLBKAI_GraffitiId;
			divaLId = data.GGHHHIIENAF_DivaLId;
			divaRId = data.NLPDDGADNFP_DivaRId;
			texture = null;
			graffiti = null;
			divaL = null;
			divaR = null;
		}
	}
	public class TipsControl : SingletonMonoBehaviour<TipsControl>
	{
		public enum SituationId
		{
			None = 0,
			GameOver = 1,
			Boot1stInformation = 2,
			BattleEventFailed_01 = 3,
			BattleEventFailed_02 = 4,
			BattleEventFailed_03 = 5,
			BattleEventFailed_04 = 6,
			Num = 7,
		}

		private struct ListupInfo
		{
			public enum Flags
			{
				HasPict = 1,
			}
			public int tipsId; // 0x0
			public int weight; // 0x4
			public uint flags; // 0x8

			// // RVA: 0x7FA894 Offset: 0x7FA894 VA: 0x7FA894
			// public bool IsPict() { }
		}

		private TipsMusicInfo m_musicInfo; // 0xC
		private TipsWindow m_window; // 0x10
		private bool m_isShow; // 0x14
		private bool m_isLoding; // 0x15
		private List<int> m_firstPageTipsIdList = new List<int>(); // 0x18
		private List<int> m_graphicTipsIdList = new List<int>(); // 0x1C
		private List<int> m_otherPageTipsIdList = new List<int>(); // 0x20
		private List<int> m_notPriorityTipsIdList = new List<int>(); // 0x24
		private List<TipsControl.ListupInfo> m_listUpList = new List<TipsControl.ListupInfo>(); // 0x28
		private List<int> m_historyList = new List<int>(); // 0x2C
		private List<TipsData> m_tipsList = new List<TipsData>(); // 0x30
		private TipsTextureCache m_tipsTextureCache = new TipsTextureCache(); // 0x34
		private WaitWhile m_waitLoading; // 0x38
		private int m_totalWeight; // 0x3C
		public const int TipsMax = 3;
		private const int HistoryMax = 10;
		private static int[] m_situationValues = new int[7]; // 0x0

		public bool IsInitialized { get; private set; } // 0x40
		public WaitWhile WaitLoadingYield { get { return m_waitLoading; } } //0xA974F4
		public bool IsLoading { get { return m_isLoding; } } //0xA974FC

		// // RVA: 0xA97284 Offset: 0xA97284 VA: 0xA97284
		public static void SetSituationValue(SituationId id, int val)
		{
			m_situationValues[(int)id] = val;
		}

		// // RVA: 0xA9734C Offset: 0xA9734C VA: 0xA9734C
		public static int GetSituationValue(SituationId id)
		{
			return m_situationValues[(int)id];
		}

		// // RVA: 0xA97410 Offset: 0xA97410 VA: 0xA97410
		public static void ResetSituationValues()
		{
			for(int i = 0; i < 7; i++)
			{
				m_situationValues[i] = 0;
			}
		}

		// // RVA: 0xA97504 Offset: 0xA97504 VA: 0xA97504
		private void Start()
		{
			RectTransform rt = gameObject.AddComponent<RectTransform>();
			rt.anchorMin = new Vector2(0, 0);
			rt.anchorMax = new Vector2(1, 1);
			rt.anchoredPosition = new Vector2(0, 0);
			rt.sizeDelta = new Vector2(0, 0);
			m_waitLoading = new WaitWhile(() =>
			{
				//0xA9A030
				return m_isLoding;
			});
		}

		// // RVA: 0xA97708 Offset: 0xA97708 VA: 0xA97708
		private void OnDestroy()
		{
			if(m_window != null)
			{
				Destroy(m_window.gameObject);
				m_window = null;
			}
			if(m_musicInfo != null)
			{
				Destroy(m_musicInfo.gameObject);
				m_musicInfo = null;
			}
			if (m_tipsTextureCache != null)
			{
				m_tipsTextureCache.Terminated();
				m_tipsTextureCache = null;
			}
		}

		// // RVA: 0xA978D0 Offset: 0xA978D0 VA: 0xA978D0
		private void Update()
		{
			m_tipsTextureCache.Update();
		}

		// // RVA: 0xA978FC Offset: 0xA978FC VA: 0xA978FC
		public new void Release()
		{
			if (!IsInitialized)
				return;
			m_tipsTextureCache.Terminated();
			Destroy(m_window.gameObject);
			Destroy(m_musicInfo.gameObject);
			m_musicInfo = null;
			m_window = null;
			IsInitialized = false;
			m_historyList.Clear();
		}

		// // RVA: 0xA97A3C Offset: 0xA97A3C VA: 0xA97A3C
		public void LoadResource()
		{
			this.StartCoroutineWatched(LoadResourceCoroutine());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73559C Offset: 0x73559C VA: 0x73559C
		// // RVA: 0xA97A60 Offset: 0xA97A60 VA: 0xA97A60
		private IEnumerator LoadResourceCoroutine()
		{
			int loadCount; // 0x14
			AssetBundleLoadLayoutOperationBase layOperation; // 0x18

			//0xA9AB4C
			if (IsInitialized)
				yield break;
			loadCount = 0;
			layOperation = AssetBundleManager.LoadLayoutAsync("ly/065.xab", "root_tips_window_layout_root");
			yield return layOperation;
			yield return Co.R(layOperation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xA9A038
				m_window = instance.GetComponent<TipsWindow>();
			}));
			loadCount++;
			layOperation = AssetBundleManager.LoadLayoutAsync("ly/065.xab", "root_tips_song_plate_layout_root");
			yield return layOperation;
			yield return Co.R(layOperation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xA9A0B4
				m_musicInfo = instance.GetComponent<TipsMusicInfo>();
			}));
			loadCount++;
			for(int i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle("ly/065.xab", false);
			}
			yield return null;
			m_window.gameObject.SetActive(false);
			m_musicInfo.gameObject.SetActive(false);
			m_window.transform.SetParent(transform, false);
			m_musicInfo.transform.SetParent(transform, false);
			IsInitialized = true;
		}

		// // RVA: 0xA97B0C Offset: 0xA97B0C VA: 0xA97B0C
		private int SearchPriorityTableIndex(int playerLevel)
		{
			List<int> l = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.AJBKGOPDGFI;
			List<int> l2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.KDIJDAKMODE;
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i] < playerLevel)
				{
					if(playerLevel < l2[i])
					{
						return i;
					}
				}
			}
			return l.Count - 1;
		}

		// // RVA: 0xA97D2C Offset: 0xA97D2C VA: 0xA97D2C
		private void InitializeTipsList()
		{
			BCKMELFCKKN_Tips dbTips = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KNMFNBEOGON_Tips;
			EGOLBAPFHHD_Common saveCommon = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common;
			int level = saveCommon.KIECDDFNCAN_Level;
			int priorityTable = SearchPriorityTableIndex(level);
			m_firstPageTipsIdList.Clear();
			m_graphicTipsIdList.Clear();
			m_otherPageTipsIdList.Clear();
			m_notPriorityTipsIdList.Clear();
			m_listUpList.Clear();
			m_totalWeight = 0;
			for(int i = 0; i < dbTips.CDENCMNHNGA.Count; i++)
			{
				BCKMELFCKKN_Tips.ALLFFCNKFBG tips = dbTips.CDENCMNHNGA[i];
				if(tips.PPEGAKEIEGM_Enabled > 1)
				{
					if(tips.HFLGGIBMEOL[priorityTable] != 0)
					{
						if(tips.NCGNCEOOBGP_EventType > 0)
						{
							if (!IsSessionEvent(tips.NCGNCEOOBGP_EventType))
								continue;
						}
						if (Utility.IsWithinPeriod(GetServerUnixTime(), tips.KJBGCLPMLCG_Start, tips.GJFPFFBAKGK_End))
						{
							int idx = m_historyList.FindIndex((int x) =>
							{
								//0xA9A1BC
								return x == tips.PPFNGGCBJKC_Id;
							});
							if(idx < 0)
							{
								if(tips.ILPJHHKLOEN_Situation > 0)
								{
									if (GetSituationValue((SituationId)tips.ILPJHHKLOEN_Situation) < 1)
										continue;
									m_listUpList.Clear();
									m_totalWeight = 0;
								}
								m_listUpList.Add(new ListupInfo() { flags = (uint)((tips.EAHPLCJMPHD_ImageId > 0) ? 1 : 0), tipsId = tips.PPFNGGCBJKC_Id, weight = m_totalWeight });
								m_totalWeight += tips.HFLGGIBMEOL[priorityTable];
							}
						}
					}
				}
			}
			ResetSituationValues();
		}

		// // RVA: 0xA98660 Offset: 0xA98660 VA: 0xA98660
		public void Show(int count = 3)
		{
			if (m_isShow)
				return;
			if (GameManager.Instance.IsTutorial)
				return;
			m_isShow = false;
			MakeTipsList(count);
			this.StartCoroutineWatched(ShowCoroutine(null));
		}

		// // RVA: 0xA99004 Offset: 0xA99004 VA: 0xA99004
		public void Show(IBJAKJJICBC musicData)
		{
			if(m_isShow)
				return;
			m_isShow = false;
			MakeTipsList(3);
			this.StartCoroutineWatched(ShowCoroutine(musicData));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x735614 Offset: 0x735614 VA: 0x735614
		// // RVA: 0xA98F78 Offset: 0xA98F78 VA: 0xA98F78
		private IEnumerator ShowCoroutine(IBJAKJJICBC musicData)
		{
			//0xA9B12C
			m_isLoding = true;
			if(m_tipsList.Count == 0)
			{
				m_isShow = false;
				m_isLoding = false;
				yield break;
			}
			for(int i = 0; i < m_tipsList.Count; i++)
			{
				LoadTexture(i, m_tipsList[i]);
			}
			while (m_tipsTextureCache.IsLoading())
				yield return null;
			m_window.SetContent(m_tipsList);
			m_window.Show();
			m_isShow = true;
			m_isLoding = false;
		}

		// // RVA: 0xA9906C Offset: 0xA9906C VA: 0xA9906C
		private void LoadTexture(int index, TipsData data)
		{
			if(data.imageId > 0)
			{
				m_tipsTextureCache.Load(data.imageId, (IiconTexture texture) =>
				{
					//0xA9A1F0
					TipsData d = m_tipsList[index];
					d.texture = texture as TipsTexture;
					m_tipsList[index] = d;
				});
			}
			if(data.graffitiId > 0)
			{
				m_tipsTextureCache.LoadGraffiti(data.graffitiId, (IiconTexture texture) =>
				{
					//0xA9A420
					TipsData d = m_tipsList[index];
					d.graffiti = texture as TipsTexture;
					m_tipsList[index] = d;
				});
			}
			if(data.divaLId > 0)
			{
				m_tipsTextureCache.LoadChara(0, data.divaLId, (IiconTexture texture) =>
				{
					//0xA9A648
					TipsData d = m_tipsList[index];
					d.divaL = texture as TipsTexture;
					m_tipsList[index] = d;
				});
			}
			if(data.divaRId > 0)
			{
				m_tipsTextureCache.LoadChara(1, data.divaRId, (IiconTexture texture) =>
				{
					//0xA9A868
					TipsData d = m_tipsList[index];
					d.divaR = texture as TipsTexture;
					m_tipsList[index] = d;
				});
			}
		}

		// // RVA: 0xA99520 Offset: 0xA99520 VA: 0xA99520
		public void Close()
		{
			if(!m_isShow)
				return;
			m_window.Close();
			if(m_musicInfo.IsShow)
			{
				m_musicInfo.Close();
			}
			m_isShow = false;
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
		}

		// // RVA: 0xA99794 Offset: 0xA99794 VA: 0xA99794
		public bool isPlayingAnime()
		{
			if(m_window == null)
			{
				if(m_musicInfo == null)
				{
					if(!m_window.IsPlayingAnime())
					{
						return m_musicInfo.IsPlayingAnime();
					}
					return true;
				}
			}
			return false;
		}

		// // RVA: 0xA9874C Offset: 0xA9874C VA: 0xA9874C
		private void MakeTipsList(int listUpCount)
		{
			BCKMELFCKKN_Tips dbTips = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KNMFNBEOGON_Tips;
			InitializeTipsList();
			m_tipsList.Clear();
			if(m_listUpList.Count != 0)
			{
				int n = Mathf.Min(listUpCount, m_listUpList.Count);
				uint flags = 0;
				for(int i = 0; n > m_tipsList.Count && i < n * 2; i++)
				{
					int m = UnityEngine.Random.Range(1, m_totalWeight + 1);
					//LAB_00a98a58
					for(int j = m_listUpList.Count - 1; j >= 0; j--)
					{
						if(m_listUpList[j].weight > m)
						{
							continue;
						}
						if ((m_listUpList[j].flags & flags) != 0)
						{
							flags = 1;
							continue;
						}
						int idx = m_tipsList.FindIndex((TipsData x) =>
						{
							//0xA9AA94
							return m_listUpList[j].tipsId == x.id;
						});
						if (idx > -1)
							continue;
						flags = 1;
						if (flags == 0)
						{
							flags = m_listUpList[j].flags & 1;
						}
						BCKMELFCKKN_Tips.ALLFFCNKFBG tip = dbTips.LBDOLHGDIEB_GetTips(m_listUpList[j].tipsId);
						int eventType = tip.NCGNCEOOBGP_EventType;
						if (eventType > 0)
						{
							if (!IsSessionEvent(eventType))
								continue;
						}
						if (!Utility.IsWithinPeriod(GetServerUnixTime(), tip.KJBGCLPMLCG_Start, tip.GJFPFFBAKGK_End))
							continue;
						m_tipsList.Add(new TipsData(tip));
						if(tip.ILPJHHKLOEN_Situation == 0)
						{
							m_historyList.Add(m_listUpList[j].tipsId);
						}
						while(m_historyList.Count >= 11)
						{
							m_historyList.RemoveAt(0);
						}
					}
				}
				m_tipsList.Sort((TipsData left, TipsData right) =>
				{
					//0xA9A1AC
					return right.id - left.id;
				});
			}
		}

		// // RVA: 0xA99A14 Offset: 0xA99A14 VA: 0xA99A14
		// private void MakePriorityTmpList(List<int> tmpList, List<int> idList) { }

		// // RVA: 0xA984D8 Offset: 0xA984D8 VA: 0xA984D8
		private bool IsSessionEvent(int eventTypeId)
		{
			return JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.HGHDAFJKEKO_GetEventForType((OHCAABOMEOF.KGOGMKMBCPP_EventType)eventTypeId) != null;
		}

		// // RVA: 0xA99D0C Offset: 0xA99D0C VA: 0xA99D0C
		// private bool IsRegisteredTips(int tipsId) { }

		// // RVA: 0xA98748 Offset: 0xA98748 VA: 0xA98748
		// private void DatelineUpdate() { }

		// // RVA: 0xA99DF0 Offset: 0xA99DF0 VA: 0xA99DF0
		// private bool IsDatelineUpdate() { }

		// // RVA: 0xA98584 Offset: 0xA98584 VA: 0xA98584
		private long GetServerUnixTime()
		{
			return NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		}
	}
}
