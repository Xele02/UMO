using UnityEngine;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class EpisodeAppealScene : TransitionRoot
	{
		[SerializeField]
		private EpisodeAppeal m_episodeAppealPrefab; // 0x48
		// private HBCPJANGOLB m_view; // 0x4C
		// private List<HGBOODNMNFM> m_episodeDataList; // 0x50
		// private bool m_isInitialized; // 0x54
		// private ButtonBase m_hitButton; // 0x58
		// private EpisodeAppeal m_appeal; // 0x5C
		// private Camera HomeDivaViewCamera; // 0x60
		// private bool IsStartedBgm; // 0x64

		// RVA: 0x127CF58 Offset: 0x127CF58 VA: 0x127CF58
		// private void Initialize(List<HGBOODNMNFM> episodeInfoList) { }

		// RVA: 0x127D170 Offset: 0x127D170 VA: 0x127D170 Slot: 4
		protected override void Awake()
		{
			TodoLogger.Log(0, "Episode Appeal Awake");
			IsReady = true;
		}

		// RVA: 0x127D3A0 Offset: 0x127D3A0 VA: 0x127D3A0 Slot: 16
		protected override void OnPreSetCanvas()
		{
			TodoLogger.Log(0, "Episode Appeal OnPreSetCanvas");
		}

		// RVA: 0x127D6B0 Offset: 0x127D6B0 VA: 0x127D6B0 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return true;
		}

		// RVA: 0x127D6B8 Offset: 0x127D6B8 VA: 0x127D6B8 Slot: 18
		protected override void OnPostSetCanvas()
		{
			base.OnPostSetCanvas();
			this.StartCoroutineWatched(MainFlow());
		}

		// RVA: 0x127D774 Offset: 0x127D774 VA: 0x127D774 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return true;
		}

		// RVA: 0x127D77C Offset: 0x127D77C VA: 0x127D77C Slot: 14
		protected override void OnDestoryScene()
		{
			TodoLogger.Log(0, "Episode Appeal OnPreSetCanvas");
		}

		// RVA: 0x127D92C Offset: 0x127D92C VA: 0x127D92C Slot: 20
		protected override bool OnBgmStart()
		{
			return true;
		}

		// RVA: 0x127D934 Offset: 0x127D934 VA: 0x127D934
		// private void StartBGM() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6DA534 Offset: 0x6DA534 VA: 0x6DA534
		// RVA: 0x127D6E8 Offset: 0x127D6E8 VA: 0x127D6E8
		private IEnumerator MainFlow()
		{
			//0x127DB30
			TodoLogger.Log(0, "Episode Appeal OnPreSetCanvas");
			yield return null;
			MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, 0);
		}

		// // RVA: 0x127DA4C Offset: 0x127DA4C VA: 0x127DA4C
		// private void OnBackButton() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6DA5AC Offset: 0x6DA5AC VA: 0x6DA5AC
		// // RVA: 0x127DB04 Offset: 0x127DB04 VA: 0x127DB04
		// private void <Awake>b__9_0() { }
	}
}
