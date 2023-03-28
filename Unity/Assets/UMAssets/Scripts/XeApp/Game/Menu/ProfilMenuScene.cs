using System;

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
			TodoLogger.Log(0, "ProfilMenuScene.IsFriend");
			return false;
		}

		// RVA: 0x9CF258 Offset: 0x9CF258 VA: 0x9CF258 Slot: 4
		protected override void Awake()
		{
			TodoLogger.Log(0, "ProfilMenuScene.Awake");
		}

		// RVA: 0x9CF2EC Offset: 0x9CF2EC VA: 0x9CF2EC Slot: 5
		protected override void Start()
		{
			TodoLogger.Log(0, "ProfilMenuScene.Start");
		}

		// RVA: 0x9CF374 Offset: 0x9CF374 VA: 0x9CF374
		private void Update()
		{
			if (mUpdater != null)
				mUpdater();
		}

		//// RVA: 0x9CF388 Offset: 0x9CF388 VA: 0x9CF388
		//private void UpdateLoad() { }

		//// RVA: 0x9CF448 Offset: 0x9CF448 VA: 0x9CF448
		//private void UpdateIdle() { }

		// RVA: 0x9CF44C Offset: 0x9CF44C VA: 0x9CF44C Slot: 9
		protected override void OnStartEnterAnimation()
		{
			TodoLogger.Log(0, "ProfilMenuScene.OnStartEnterAnimation");
		}

		// RVA: 0x9CF484 Offset: 0x9CF484 VA: 0x9CF484 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			TodoLogger.Log(0, "ProfilMenuScene.IsEndEnterAnimation");
			return base.IsEndEnterAnimation();
		}

		// RVA: 0x9CF4B4 Offset: 0x9CF4B4 VA: 0x9CF4B4 Slot: 12
		protected override void OnStartExitAnimation()
		{
			TodoLogger.Log(0, "ProfilMenuScene.OnStartExitAnimation");
		}

		// RVA: 0x9CF4EC Offset: 0x9CF4EC VA: 0x9CF4EC Slot: 13
		protected override bool IsEndExitAnimation()
		{
			TodoLogger.Log(0, "ProfilMenuScene.IsEndExitAnimation");
			return base.IsEndExitAnimation();
		}

		// RVA: 0x9CF51C Offset: 0x9CF51C VA: 0x9CF51C Slot: 14
		protected override void OnDestoryScene()
		{
			TodoLogger.Log(0, "ProfilMenuScene.OnDestoryScene");
		}

		// RVA: 0x9CF554 Offset: 0x9CF554 VA: 0x9CF554 Slot: 18
		protected override void OnPostSetCanvas()
		{
			TodoLogger.Log(0, "ProfilMenuScene.OnPostSetCanvas");
		}

		// RVA: 0x9CF558 Offset: 0x9CF558 VA: 0x9CF558 Slot: 16
		protected override void OnPreSetCanvas()
		{
			TodoLogger.Log(0, "ProfilMenuScene.OnPreSetCanvas");
		}

		// RVA: 0x9CF738 Offset: 0x9CF738 VA: 0x9CF738 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			TodoLogger.Log(0, "ProfilMenuScene.IsEndPreSetCanvas");
			return base.IsEndPreSetCanvas();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FF3EC Offset: 0x6FF3EC VA: 0x6FF3EC
		//// RVA: 0x9CF690 Offset: 0x9CF690 VA: 0x9CF690
		//private IEnumerator Co_ProfileInit(ProfilDateArgs a_arg) { }
	}
}
