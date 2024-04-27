using System;
using XeApp.Game;

namespace XeApp.Core
{
	public abstract class SubSceneBase : IScene
	{
		protected abstract bool useFadeIn { get; } //Slot: 9
		protected abstract bool useFadeOut { get; }  //Slot: 10
		public Action update { get; private set; } // 0x8
		public SubSceneBase nextScene { get; private set; } // 0xC
		protected MainSceneBase mainScene { get; private set; } // 0x10
		public bool isEnd { get; private set; } // 0x14

		// // RVA: 0x1D7679C Offset: 0x1D7679C VA: 0x1D7679C
		private SubSceneBase()
		{
			nextScene = null;
			mainScene = null;
		}

		// // RVA: 0x1D767C0 Offset: 0x1D767C0 VA: 0x1D767C0
		public SubSceneBase(MainSceneBase mainScene)
		{
			nextScene = null;
			this.mainScene = mainScene;
		}

		// // RVA: 0x1D73B30 Offset: 0x1D73B30 VA: 0x1D73B30
		public void Enter(SubSceneBase prevScene)
		{
			if(prevScene != null)
				prevScene.nextScene = null;
			isEnd = false;
			update = UpdateEnter;
		}

		// // RVA: 0x1D73F18 Offset: 0x1D73F18 VA: 0x1D73F18
		// public void Leave() { }

		// // RVA: 0x1D73AF4 Offset: 0x1D73AF4 VA: 0x1D73AF4
		public void Update()
		{
			if(update != null)
				update();
		}

		// // RVA: 0x1D74088 Offset: 0x1D74088 VA: 0x1D74088
		// public void NextSubScene(SubSceneBase next) { }

		// // RVA: 0x1D767E8 Offset: 0x1D767E8 VA: 0x1D767E8 Slot: 4
		public void UpdateEnter()
		{
			if(!DoUpdateEnter())
				return;
			if(useFadeIn)
			{
				GameManager.FadeIn(0.4f);
				update = UpdateEnterFadeIn;
			}
			else
			{
				GameManager.FadeReset();
				update = UpdateMain;
			}
		}

		// // RVA: 0x1D76928 Offset: 0x1D76928 VA: 0x1D76928 Slot: 5
		public void UpdateEnterFadeIn()
		{
			if(GameManager.IsFading())
				return;
			update = UpdateMain;
		}

		// // RVA: 0x1D769F4 Offset: 0x1D769F4 VA: 0x1D769F4 Slot: 6
		public void UpdateMain()
		{
			DoUpdateMain();
		}

		// // RVA: 0x1D76A04 Offset: 0x1D76A04 VA: 0x1D76A04 Slot: 7
		// public void UpdateLeaveFadeOut() { }

		// // RVA: 0x1D76AD0 Offset: 0x1D76AD0 VA: 0x1D76AD0 Slot: 8
		// public void UpdateLeave() { }

		// // RVA: -1 Offset: -1 Slot: 11
		protected abstract bool DoUpdateEnter();

		// // RVA: -1 Offset: -1 Slot: 12
		protected abstract void DoUpdateMain();

		// // RVA: -1 Offset: -1 Slot: 13
		// protected abstract bool DoUpdateLeave();

	}
}
