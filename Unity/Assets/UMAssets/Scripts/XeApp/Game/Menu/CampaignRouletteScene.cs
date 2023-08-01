using System.Collections;
using UnityEngine.EventSystems;

namespace XeApp.Game.Menu
{
	public class CampaignRouletteScene : TransitionRoot, IPointerClickHandler, IEventSystemHandler
	{
		// private LayoutCampaignRouletteMain m_layoutMain; // 0x48
		// private LayoutCampaignRouletteResult m_layoutResult; // 0x4C
		// private LayoutPopupCampaign1st m_layoutPopup1st; // 0x50
		// private CampaignRouletteEffect m_effectObject; // 0x54
		private TipsTextureCache m_textureCache; // 0x58
		// private Texture2D m_textureBG; // 0x5C
		// private LLBKNDPMGEP m_view; // 0x60
		// private Coroutine m_loadCoroutine; // 0x64
		// private Coroutine m_animCoroutine; // 0x68
		// private bool m_isEndEnterAnimation; // 0x6C

		// RVA: 0x10A55D4 Offset: 0x10A55D4 VA: 0x10A55D4 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			this.StartCoroutineWatched(Co_InitializeLayout());
		}

		// RVA: 0x10A5628 Offset: 0x10A5628 VA: 0x10A5628
		private void Update()
		{
			m_textureCache.Update();
		}

		// RVA: 0x10A563C Offset: 0x10A563C VA: 0x10A563C
		private void OnDestroy()
		{
			TodoLogger.LogError(0, "Campaign roulette on destroy");
		}

		// RVA: 0x10A5670 Offset: 0x10A5670 VA: 0x10A5670 Slot: 16
		protected override void OnPreSetCanvas()
		{
			TodoLogger.LogError(0, "Campaign roulette OnPreSetCanvas");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CB39C Offset: 0x6CB39C VA: 0x6CB39C
		// // RVA: 0x10A59DC Offset: 0x10A59DC VA: 0x10A59DC
		// private IEnumerator Co_Load(int eventId) { }

		// RVA: 0x10A5AAC Offset: 0x10A5AAC VA: 0x10A5AAC Slot: 18
		protected override void OnPostSetCanvas() 
		{
			TodoLogger.LogError(0, "Campaign roulette OnPostSetCanvas");
		}

		// RVA: 0x10A5AB4 Offset: 0x10A5AB4 VA: 0x10A5AB4 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			TodoLogger.LogError(0, "Campaign roulette IsEndPreSetCanvas");
			return true;
		}

		// RVA: 0x10A5B78 Offset: 0x10A5B78 VA: 0x10A5B78 Slot: 20
		protected override bool OnBgmStart()
		{
			TodoLogger.LogError(0, "Campaign roulette OnBgmStart");
			return true;
		}

		// RVA: 0x10A5C58 Offset: 0x10A5C58 VA: 0x10A5C58 Slot: 14
		protected override void OnDestoryScene()
		{
			TodoLogger.LogError(0, "Campaign roulette OnDestoryScene");
		}

		// RVA: 0x10A5C5C Offset: 0x10A5C5C VA: 0x10A5C5C Slot: 9
		protected override void OnStartEnterAnimation()
		{
			TodoLogger.LogError(0, "Campaign roulette OnStartEnterAnimation");
		}

		// RVA: 0x10A5D0C Offset: 0x10A5D0C VA: 0x10A5D0C Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			TodoLogger.LogError(0, "Campaign roulette IsEndEnterAnimation");
			return true;
		}

		// // RVA: 0x10A5D14 Offset: 0x10A5D14 VA: 0x10A5D14 Slot: 31
		public void OnPointerClick(PointerEventData eventData)
		{
			TodoLogger.LogError(0, "Campaign roulette OnPointerClick");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CB414 Offset: 0x6CB414 VA: 0x6CB414
		// // RVA: 0x10A5D98 Offset: 0x10A5D98 VA: 0x10A5D98
		// private IEnumerator Co_StartRoulette() { }

		// // RVA: 0x10A5E44 Offset: 0x10A5E44 VA: 0x10A5E44
		// private void GoToTitle() { }

		// // RVA: 0x10A5604 Offset: 0x10A5604 VA: 0x10A5604
		// private void InitializeLayout() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6CB48C Offset: 0x6CB48C VA: 0x6CB48C
		// // RVA: 0x10A5F50 Offset: 0x10A5F50 VA: 0x10A5F50
		private IEnumerator Co_InitializeLayout()
		{
			TodoLogger.LogError(0, "Implement CampainRoulette Co_InitializeLayout");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CB504 Offset: 0x6CB504 VA: 0x6CB504
		// // RVA: 0x10A5FFC Offset: 0x10A5FFC VA: 0x10A5FFC
		// private IEnumerator Co_LoadLayout() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6CB57C Offset: 0x6CB57C VA: 0x6CB57C
		// // RVA: 0x10A60B0 Offset: 0x10A60B0 VA: 0x10A60B0
		// private void <OnStartEnterAnimation>b__18_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6CB58C Offset: 0x6CB58C VA: 0x6CB58C
		// // RVA: 0x10A60BC Offset: 0x10A60BC VA: 0x10A60BC
		// private void <Co_LoadLayout>b__26_0(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6CB59C Offset: 0x6CB59C VA: 0x6CB59C
		// // RVA: 0x10A6138 Offset: 0x10A6138 VA: 0x10A6138
		// private void <Co_LoadLayout>b__26_1(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6CB5AC Offset: 0x6CB5AC VA: 0x6CB5AC
		// // RVA: 0x10A61B4 Offset: 0x10A61B4 VA: 0x10A61B4
		// private void <Co_LoadLayout>b__26_2(GameObject instance) { }
	}
}
