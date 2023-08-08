using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;
using XeSys;
using System.Collections;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class EpisodeSceneIconCreater : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_abs; // 0x14
		[SerializeField]
		private SwapScrollList m_swapScroll; // 0x18
		[SerializeField]
		private ActionButton m_left_btn; // 0x1C
		[SerializeField]
		private ActionButton m_right_btn; // 0x20
		[SerializeField]
		private RawImageEx m_left_btn_image; // 0x24
		[SerializeField]
		private RawImageEx m_right_btn_image; // 0x28
		[SerializeField]
		private Text m_text_empty; // 0x2C
		//[CompilerGeneratedAttribute] // RVA: 0x66CEFC Offset: 0x66CEFC VA: 0x66CEFC
		public Action<int, EpisodeIcon> ScrollUpdateHander; // 0x34
		//[CompilerGeneratedAttribute] // RVA: 0x66CF0C Offset: 0x66CF0C VA: 0x66CF0C
		public Action<int> PushDetailButtonHandler; // 0x38
		private const int DispItemCount = 4;
		private int m_itemCount; // 0x3C
		private const int NewStartFrame = 1;
		private const int NewEndFrame = 60;
		private const int BlinkStartFrame = 1;
		private const int BlinkEndFrame = 120;
		private const int EpisodeFeedStartFrame = 0;
		private const int EpisodeFeedEndFrame = 60;
		private const float ScrollArrowThreshold = 134;
		private float m_scrollRange; // 0x40
		private CompatibleLayoutAnimeParam m_syncNewIconAnimParam; // 0x44
		private CompatibleLayoutAnimeParam m_syncBlinkAnimParam; // 0x50
		private CompatibleLayoutAnimeParam m_syncEpisodeFeedAnimParam; // 0x5C

		public bool IsInitialized { get; private set; } // 0x30
		public SwapScrollList Scroll { get { return m_swapScroll; } } //0xF04014

		// RVA: 0xF0401C Offset: 0xF0401C VA: 0xF0401C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_abs = layout.FindViewById("sw_sel_ep_list_anim") as AbsoluteLayout;
			m_swapScroll.OnUpdateItem.AddListener(OnUpdateScroll);
			m_syncNewIconAnimParam.Initialize(1, 60);
			m_syncBlinkAnimParam.Initialize(1, 120);
			m_syncEpisodeFeedAnimParam.Initialize(0, 60);
			m_scrollRange = m_swapScroll.GetComponent<RectTransform>().sizeDelta.x;
			ScrollRect s = GetComponentInChildren<ScrollRect>();
			s.verticalScrollbar.gameObject.SetActive(false);
			s.verticalScrollbar = null;
			return true;
		}

		// RVA: 0xF042C4 Offset: 0xF042C4 VA: 0xF042C4
		private void Start()
		{
			this.StartCoroutineWatched(LoadListItemPrefabCoroutine());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DB6F4 Offset: 0x6DB6F4 VA: 0x6DB6F4
		//// RVA: 0xF042E8 Offset: 0xF042E8 VA: 0xF042E8
		private IEnumerator LoadListItemPrefabCoroutine()
		{
			AssetBundleLoadLayoutOperationBase layOp;

			//0xF04EC4
			LayoutUGUIRuntime runtime = null;
			layOp = AssetBundleManager.LoadLayoutAsync("ly/052.xab", "EpisodeIconPrefab");
			yield return layOp;
			yield return Co.R(layOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xF04E44
				runtime = instance.GetComponent<LayoutUGUIRuntime>();
			}));
			for(int i = 0; i < 4; i++)
			{
				LayoutUGUIRuntime r = Instantiate(runtime);
				r.IsLayoutAutoLoad = false;
				r.Layout = runtime.Layout.DeepClone();
				r.UvMan = runtime.UvMan;
				r.LoadLayout();
				m_swapScroll.AddScrollObject(r.GetComponent<EpisodeIcon>());
			}
			m_swapScroll.AddScrollObject(runtime.GetComponent<EpisodeIcon>());
			m_swapScroll.Apply();
			for(int i = 0; i < 5; i++)
			{
				m_swapScroll.ScrollObjects[i].ClickButton.AddListener(OnPushDetail);
			}
			yield return null;
			IsInitialized = true;
			AssetBundleManager.UnloadAssetBundle("ly/052.xab", false);
		}

		// RVA: 0xF04394 Offset: 0xF04394 VA: 0xF04394
		private void Update()
		{
			int time = m_syncNewIconAnimParam.UpdateFrame(TimeWrapper.deltaTime);
			int time2 = m_syncBlinkAnimParam.UpdateFrame(TimeWrapper.deltaTime);
			int time3 = m_syncEpisodeFeedAnimParam.UpdateFrame(TimeWrapper.deltaTime);
			for(int i = 0; i < m_swapScroll.ScrollObjects.Count; i++)
			{
				EpisodeIcon e = m_swapScroll.ScrollObjects[i] as EpisodeIcon;
				e.SetNewIconFrame(time);
				e.SetBlinkFrame(time2);
				e.SetFeedEpisodeFrame(time3);
			}
		}

		// RVA: 0xF045A0 Offset: 0xF045A0 VA: 0xF045A0
		private void LateUpdate()
		{
			m_left_btn_image.enabled = m_swapScroll.ScrollContent.anchoredPosition.x < -134;
			m_left_btn.enabled = m_left_btn_image.enabled;
			m_right_btn_image.enabled = -(m_swapScroll.ScrollContent.sizeDelta.x - m_scrollRange - 134) <= m_swapScroll.ScrollContent.anchoredPosition.x;
			m_right_btn.enabled = m_right_btn_image.enabled;
		}

		//// RVA: 0xF045A4 Offset: 0xF045A4 VA: 0xF045A4
		//private void UpdateArrow() { }

		//// RVA: 0xF04398 Offset: 0xF04398 VA: 0xF04398
		//private void UpdateNewIcon() { }

		//// RVA: 0xF0472C Offset: 0xF0472C VA: 0xF0472C
		public void InitializeScrollView(int itemCount, int position = 0)
		{
			for(int i = 0; i < m_swapScroll.ScrollObjectCount; i++)
			{
				(m_swapScroll.ScrollObjects[i] as EpisodeIcon).InitializeNewIcon();
			}
			m_swapScroll.SetItemCount(itemCount);
			m_swapScroll.SetPosition(position, 0, 0, false);
			m_swapScroll.VisibleRegionUpdate();
			m_itemCount = itemCount;
			if(itemCount < 1)
			{
				m_text_empty.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("episode_sort_filter_empty");
			}
			else
			{
				m_text_empty.text = "";
			}
		}

		//// RVA: 0xF04A04 Offset: 0xF04A04 VA: 0xF04A04
		private void OnUpdateScroll(int index, SwapScrollListContent content)
		{
			if(ScrollUpdateHander != null)
			{
				ScrollUpdateHander(index, content as EpisodeIcon);
			}
		}

		//// RVA: 0xF04AC4 Offset: 0xF04AC4 VA: 0xF04AC4
		private void OnPushDetail(int index, SwapScrollListContent content)
		{
			if(PushDetailButtonHandler != null)
			{
				PushDetailButtonHandler(content.Index);
			}
		}

		//// RVA: 0xF04B58 Offset: 0xF04B58 VA: 0xF04B58
		public void Enter()
		{
			m_abs.StartChildrenAnimGoStop("go_in", "st_in");
			m_syncNewIconAnimParam.Initialize(1, 60);
		}

		//// RVA: 0xF04BFC Offset: 0xF04BFC VA: 0xF04BFC
		public void Leave()
		{
			m_abs.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0xF04C88 Offset: 0xF04C88 VA: 0xF04C88
		public bool IsPlaying()
		{
			return m_abs.IsPlayingChildren();
		}

		//// RVA: 0xF04CB4 Offset: 0xF04CB4 VA: 0xF04CB4
		public void Release()
		{
			for(int i = 0; i < m_swapScroll.ScrollObjectCount; i++)
			{
				(m_swapScroll.ScrollObjects[i] as EpisodeIcon).ReleaseNew();
			}
		}
	}
}
