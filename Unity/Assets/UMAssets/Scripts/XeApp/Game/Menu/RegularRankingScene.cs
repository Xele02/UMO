using System.Collections;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class RegularRankingScene : RankingSceneBase
	{
		private const int s_rankingOrderMax = 100;
		private IBJAKJJICBC m_musicData; // 0x78

		// RVA: 0xCF94CC Offset: 0xCF94CC VA: 0xCF94CC Slot: 31
		protected override void Initialize()
		{
			if (Args != null && Args is RegularRankingSceneArgs)
			{
				m_musicData = (Args as RegularRankingSceneArgs).musicData;
			}
			InitializeDecos();
			for(int i = 0; i < m_elems.Count; i++)
			{
				m_elems[i].SetStyle(RankingListElemBase.StyleType.Score);
			}
			m_windowUi.ChangePreset(GeneralListWindow.Preset.ScoreRanking, false);
			m_windowUi.SetMusicTitle(m_musicData.NEDBBJDAFBH_MusicName, GameAttributeTextColor.Colors[m_musicData.FKDCCLPGKDK_JacketAttr - 1]);
			m_windowUi.SetMusicAttr((GameAttribute.Type) m_musicData.FKDCCLPGKDK_JacketAttr);
			m_windowUi.SetMusicDiffVisible(false);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_windowUi.SetRankingMessage(bk.GetMessageByLabel("ranking_message"));
			GameManager.Instance.MusicJacketTextureCache.Load(m_musicData.JNCPEGJGHOG_JacketId, (IiconTexture image) =>
			{
				//0xCFA1AC
				m_windowUi.SetMusicJacket(image);
			});
			m_windowUi.onClickCornerButton = OnClickCornerButton;
			m_windowUi.onClickTotalRankButton = OnClickTotalButton;
			m_windowUi.onClickFriendRankButton = OnClickFriendButton;
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				m_scrollList.ScrollObjects[i].ClickButton.RemoveAllListeners();
				m_scrollList.ScrollObjects[i].ClickButton.AddListener(OnSelectListItem);
			}
			if(PrevTransition == TransitionList.Type.PROFIL)
			{
				m_scrollList.VisibleRegionUpdate();
			}
			else
			{
				m_windowUi.SelectTotalRankingTab();
				m_scrollList.SetItemCount(0);
				m_scrollList.VisibleRegionUpdate();
				ResetReceivedFlag();
				SetupTotalRanking();
			}
		}

		// RVA: 0xCF9CA0 Offset: 0xCF9CA0 VA: 0xCF9CA0 Slot: 32
		protected override void Release()
		{
			for(int i = 0; i < m_divaDecos.Count; i++)
			{
				m_divaDecos[i].Release();
			}
			m_divaDecos.Clear();
			for (int i = 0; i < m_sceneDecos.Count; i++)
			{
				m_sceneDecos[i].Release();
			}
			m_sceneDecos.Clear();
		}

		// RVA: 0xCF9CA4 Offset: 0xCF9CA4 VA: 0xCF9CA4 Slot: 34
		protected override void GetRankingList(int baseRank, int rankingIdx)
		{
			//NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester
			m_windowUi.SetMessageVisible(false);
			CNNIKANJMNG.HHCJCDFCLOB.FAMFKPBPIAA(NGNLPIBPHJH.DEPGBBJMFED, m_musicData.GHBPLHBNMBK_FreeMusicId, isFriendList, baseRank, rankingIdx, OnReceivedRankingList, OnRankingError, OnNetError);
		}

		// RVA: 0xCF9EA4 Offset: 0xCF9EA4 VA: 0xCF9EA4 Slot: 35
		protected override void GetRankingListAdditive(bool isUpper)
		{
			//NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester
			CNNIKANJMNG.HHCJCDFCLOB.JPNACOLKHLB(GetListEdgeRank(isUpper), isUpper ? -1 : 1, OnReceivedRankingListAdditive, OnRankingError, OnNetError);
		}

		// RVA: 0xCFA050 Offset: 0xCFA050 VA: 0xCFA050 Slot: 36
		protected override string GetRankingNotFoundMessage()
		{
			return MessageManager.Instance.GetMessage("menu", "ranking_no_entry");
		}

		// RVA: 0xCFA0F0 Offset: 0xCFA0F0 VA: 0xCFA0F0 Slot: 33
		protected override int GetCurrentBaseRank()
		{
			return 1;
		}

		//// RVA: 0xCFA0F8 Offset: 0xCFA0F8 VA: 0xCFA0F8
		private void OnClickCornerButton()
		{
			return;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E184C Offset: 0x6E184C VA: 0x6E184C
		// RVA: 0xCFA0FC Offset: 0xCFA0FC VA: 0xCFA0FC Slot: 39
		protected override IEnumerator Co_LoadLayout()
		{
			StringBuilder bundleName; // 0x14
			XeSys.FontInfo systemFont; // 0x18
			int bundleLoadCount; // 0x1C
			AssetBundleLoadLayoutOperationBase operation; // 0x20
			int i; // 0x24

			//0xCFA3F8
			bundleName = new StringBuilder(64);
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/039.xab");
			bundleLoadCount = 0;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_GeneralListWindow");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xCFA1E0
				instance.transform.SetParent(transform, false);
				if(instance != null)
				{
					m_windowUi = instance.GetComponent<GeneralListWindow>();
					m_scrollList = instance.GetComponentInChildren<SwapScrollList>(true);
				}
			}));
			bundleLoadCount++;
			yield return Co.R(Co_LoadListElem(bundleName.ToString(), "UI_ScoreRankingListElem", systemFont, m_scrollList.ScrollObjectCount, "RankingListElem {0:D2}", (LayoutUGUIRuntime instance) =>
			{
				//0xCFA2F8
				m_scrollList.AddScrollObject(instance.GetComponent<SwapScrollListContent>());
				m_elems.Add(instance.GetComponent<ScoreRankingListElem>());
			}));
			bundleLoadCount++;
			for(i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			m_scrollList.Apply();
			m_scrollList.SetContentEscapeMode(true);
			while (!m_windowUi.IsLoaded())
				yield return null;
			for(i = 0; i < m_elems.Count; i++)
			{
				while (!m_elems[i].IsLoaded())
					yield return null;
			}
		}
	}
}
