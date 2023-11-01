using UnityEngine;
using System.Collections;
using XeApp.Game.Common;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class EpisodeAppealScene : TransitionRoot
	{ 
		public class EpisodeAppealArgs : TransitionArgs
		{
			public List<HGBOODNMNFM> EpisodeInfoList { get; private set; } // 0x8

			// RVA: 0x127E0F8 Offset: 0x127E0F8 VA: 0x127E0F8
			public EpisodeAppealArgs(List<HGBOODNMNFM> episodeInfoList)
			{
				EpisodeInfoList = episodeInfoList;
			}

			// RVA: 0x127E118 Offset: 0x127E118 VA: 0x127E118
			//public void Init(List<HGBOODNMNFM> episodeInfoList) { }
		}

		[SerializeField]
		private EpisodeAppeal m_episodeAppealPrefab; // 0x48
		private HBCPJANGOLB m_view; // 0x4C
		private List<HGBOODNMNFM> m_episodeDataList; // 0x50
		private bool m_isInitialized; // 0x54
		private ButtonBase m_hitButton; // 0x58
		private EpisodeAppeal m_appeal; // 0x5C
		private Camera HomeDivaViewCamera; // 0x60
		private bool IsStartedBgm; // 0x64

		// RVA: 0x127CF58 Offset: 0x127CF58 VA: 0x127CF58
		private void Initialize(List<HGBOODNMNFM> episodeInfoList)
		{
			if(episodeInfoList == null)
			{
				m_view = new HBCPJANGOLB();
				m_view.OBKGEDCKHHE();
				m_episodeDataList = new List<HGBOODNMNFM>();
				m_episodeDataList = m_view.DJOMLJELOLM();
				m_view.HJMKBCFJOOH();
			}
			else
			{
				m_episodeDataList = episodeInfoList;
			}
			IsStartedBgm = false;
			HomeDivaViewCamera = MenuScene.Instance.divaManager.transform.Find("DivaCamera").GetComponent<Camera>();
			HomeDivaViewCamera.enabled = false;
		}

		// RVA: 0x127D170 Offset: 0x127D170 VA: 0x127D170 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			Transform t = transform.Find("HitCheckPanel");
			t.localScale = Vector3.one;
			t.GetComponent<RectTransform>().sizeDelta = new Vector2(1184, 792);
			m_hitButton = t.GetComponent<ButtonBase>();
			m_hitButton.AddOnClickCallback(() =>
			{
				//0x127DB04
				m_appeal.IsSkip = true;
			});
			IsReady = true;
		}

		// RVA: 0x127D3A0 Offset: 0x127D3A0 VA: 0x127D3A0 Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			AutoFadeFlag = false;
			GameManager.Instance.SetFPS(60);
			m_appeal = Instantiate(m_episodeAppealPrefab);
			EpisodeAppealArgs args = Args as EpisodeAppealArgs;
			List<HGBOODNMNFM> epList = null;
			if (args != null)
				epList = args.EpisodeInfoList;
			Initialize(epList);
			if(m_episodeDataList.Count > 0)
			{
				TipsControl.Instance.Close();
				GameManager.Instance.NowLoading.Hide();
			}
			GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
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
			base.OnDestoryScene();
			m_appeal.Release();
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
			Destroy(m_appeal.gameObject);
			HomeDivaViewCamera.enabled = true;
			GameManager.Instance.SetFPS(30);
		}

		// RVA: 0x127D92C Offset: 0x127D92C VA: 0x127D92C Slot: 20
		protected override bool OnBgmStart()
		{
			return true;
		}

		// RVA: 0x127D934 Offset: 0x127D934 VA: 0x127D934
		private void StartBGM()
		{
			TodoLogger.LogError(0, "StartBGM");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DA534 Offset: 0x6DA534 VA: 0x6DA534
		// RVA: 0x127D6E8 Offset: 0x127D6E8 VA: 0x127D6E8
		private IEnumerator MainFlow()
		{
			bool NotScene; // 0x14
			int i; // 0x18

			//0x127DB30
			NotScene = false;
			if(m_episodeDataList.Count > 0)
			{
				yield return Co.R(m_appeal.Co_LoadDirectionLayout());
			}
			for(i = 0; i < m_episodeDataList.Count; i++)
			{
				if(m_episodeDataList[i].ADDCEJNOJLG_Scenes.Count < 1)
				{
					CEBFFLDKAEC_SecureInt val = new CEBFFLDKAEC_SecureInt();
					val.DNJEJEANJGL_Value = 0;
					m_episodeDataList[i].ADDCEJNOJLG_Scenes.Add(val);
					NotScene = true;
				}
				yield return Co.R(m_appeal.LoadResource(m_episodeDataList[i].KELFCMEOPPM_EpisodeId, m_episodeDataList[i].ADDCEJNOJLG_Scenes[0].DNJEJEANJGL_Value));
				if(m_appeal.IsAppeal && !NotScene)
				{
					StartBGM();
				}
				yield return Co.R(m_appeal.Co_Play());
			}
			if(PrevTransition == TransitionList.Type.GACHA_2)
			{
				MenuScene.Instance.Return(true);
			}
			else
			{
				MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			}
		}

		// // RVA: 0x127DA4C Offset: 0x127DA4C VA: 0x127DA4C
		private void OnBackButton()
		{
			if(m_appeal != null)
				m_appeal.IsSkip = true;
		}
	}
}
