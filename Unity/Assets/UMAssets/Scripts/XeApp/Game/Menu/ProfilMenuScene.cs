using System;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class ProfilMenuScene : TransitionRoot
	{
		private Action mUpdater; // 0x48
		private ProfilMenuLayout m_profil; // 0x4C
		private bool m_isCreateValkyrieAndCostumeList; // 0x50
		private bool m_isGotoTitle; // 0x51
		private int m_mainGunPower; // 0x54
		private int m_fanCount; // 0x58
		private int m_musicRank; // 0x5C

		// RVA: 0x9CF1A0 Offset: 0x9CF1A0 VA: 0x9CF1A0
		public bool IsFriend()
		{
			return m_profil != null && m_profil.IsFriend;
		}

		// RVA: 0x9CF258 Offset: 0x9CF258 VA: 0x9CF258 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			m_profil = transform.GetComponent<ProfilMenuLayout>();
		}

		// RVA: 0x9CF2EC Offset: 0x9CF2EC VA: 0x9CF2EC Slot: 5
		protected override void Start()
		{
			mUpdater = UpdateLoad;
		}

		// RVA: 0x9CF374 Offset: 0x9CF374 VA: 0x9CF374
		private void Update()
		{
			if (mUpdater != null)
				mUpdater();
		}

		//// RVA: 0x9CF388 Offset: 0x9CF388 VA: 0x9CF388
		private void UpdateLoad()
		{
			if (!m_profil.IsLoaded())
				return;
			IsReady = true;
			mUpdater = UpdateIdle;
		}

		//// RVA: 0x9CF448 Offset: 0x9CF448 VA: 0x9CF448
		private void UpdateIdle()
		{
			return;
		}

		// RVA: 0x9CF44C Offset: 0x9CF44C VA: 0x9CF44C Slot: 9
		protected override void OnStartEnterAnimation()
		{
			if (m_isGotoTitle)
				return;
			m_profil.Enter();
		}

		// RVA: 0x9CF484 Offset: 0x9CF484 VA: 0x9CF484 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_profil.IsPlaying();
		}

		// RVA: 0x9CF4B4 Offset: 0x9CF4B4 VA: 0x9CF4B4 Slot: 12
		protected override void OnStartExitAnimation()
		{
			base.OnStartExitAnimation();
			m_profil.Leave();
		}

		// RVA: 0x9CF4EC Offset: 0x9CF4EC VA: 0x9CF4EC Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_profil.IsPlaying();
		}

		// RVA: 0x9CF51C Offset: 0x9CF51C VA: 0x9CF51C Slot: 14
		protected override void OnDestoryScene()
		{
			base.OnDestoryScene();
			m_profil.OtherRelease();
		}

		// RVA: 0x9CF554 Offset: 0x9CF554 VA: 0x9CF554 Slot: 18
		protected override void OnPostSetCanvas()
		{
			return;
		}

		// RVA: 0x9CF558 Offset: 0x9CF558 VA: 0x9CF558 Slot: 16
		protected override void OnPreSetCanvas()
		{
			ProfilDateArgs a = null;
			if (Args != null && Args is ProfilDateArgs)
			{
				a = Args as ProfilDateArgs;
			}
			else if(ArgsReturn != null && ArgsReturn is ProfilDateArgs)
			{
				a = ArgsReturn as ProfilDateArgs;
			}
			m_isCreateValkyrieAndCostumeList = false;
			this.StartCoroutineWatched(Co_ProfileInit(a));
			m_profil.Out();
		}

		// RVA: 0x9CF738 Offset: 0x9CF738 VA: 0x9CF738 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			if(!m_isGotoTitle)
			{
				if(!KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				{
					if(m_isCreateValkyrieAndCostumeList)
					{
						return m_profil.IsLoadingImage();
					}
				}
				return false;
			}
			else
			{
				GotoTitle();
				return true;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FF3EC Offset: 0x6FF3EC VA: 0x6FF3EC
		//// RVA: 0x9CF690 Offset: 0x9CF690 VA: 0x9CF690
		private IEnumerator Co_ProfileInit(ProfilDateArgs a_arg)
		{
			TodoLogger.Log(0, "Co_ProfileInit");
			yield return null;
		}
	}
}
