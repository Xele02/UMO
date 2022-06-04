using UnityEngine;
using System;
using System.Collections;
using XeSys;
using XeApp.Game;

namespace XeApp.Core
{
	public class MainSceneBase : MonoBehaviour
	{
		private static string mPrevSceneName; // 0x0
		[SerializeField]
		private GameObject systemManagerPrefab; // 0xC
		[SerializeField]
		private GameObject gameManagerPrefab; // 0x10
		private string mNextSceneName; // 0x18

		public static string prevSceneName { get { return mPrevSceneName; } } // get_prevSceneName 0x1D73458
		public Action updateState { get; set; } // 0x14
		public bool IsRequestChangeScene { 
			get // get_IsRequestChangeScene 0x1D734F4
			{
				return mNextSceneName != null;
			}
			set {} // set_IsRequestChangeScene 0x1D73504
		}
		private SceneAsyncLoader asyncLoader { get; set; } // 0x1C
		public bool enableFade { get; set; } // 0x20
		protected SubSceneBase subScene { get; set; } // 0x24

		// // RVA: 0x1D73538 Offset: 0x1D73538 VA: 0x1D73538
		private void Awake()
		{
			subScene = null;
			enableFade = true;
			mNextSceneName = null;
			updateState = this.UpdateEnter; // ?
			SystemManager.Create(systemManagerPrefab);
			GameManager.Create(gameManagerPrefab);
			if(GetComponent<Camera>() != null)
			{
				GetComponent<Camera>().cullingMask = (int)(GetComponent<Camera>().cullingMask & 0xfffff4ff);
			}
			DoAwake();
		}

		// // RVA: 0x1D73730 Offset: 0x1D73730 VA: 0x1D73730
		private void Start()
		{
			DoStart();
		}

		// // RVA: 0x1D73740 Offset: 0x1D73740 VA: 0x1D73740
		private void Update()
		{
			updateState();
		}

		// // RVA: 0x1D7376C Offset: 0x1D7376C VA: 0x1D7376C
		// private void OnApplicationQuit() { }

		// // RVA: 0x1D7377C Offset: 0x1D7377C VA: 0x1D7377C Slot: 4
		public void UpdateEnter()
		{
			if(!DoUpdateEnter())
				return;

			if(!enableFade)
			{
				updateState = this.UpdateMain;
			}
			else
			{
				GameManager.FadeIn();
				updateState = this.UpdateEnterFadeIn;
			}
		}

		// // RVA: 0x1D73884 Offset: 0x1D73884 VA: 0x1D73884 Slot: 5
		public void UpdateEnterFadeIn()
		{
			if(GameManager.IsFading())
				return;
			
			updateState = this.UpdateMain;
		}

		// // RVA: 0x1D73950 Offset: 0x1D73950 VA: 0x1D73950 Slot: 6
		public void UpdateMain()
		{
			if(subScene == null)
			{
				DoUpdateMain();
				if(mNextSceneName == null)
					return;
				if(!enableFade)
				{
					updateState = this.UpdateLeave;
				}
				else
				{
					GameManager.FadeOut();
					updateState = this.UpdateLeaveFadeOut;
				}
			}
			else
			{
				subScene.Update();
				if(subScene.isEnd)
				{
					if(subScene.nextScene == null)
					{
						subScene = null;
						return;
					}
					SubSceneBase nextScene = subScene.nextScene;
					subScene = null;
					nextScene.Enter(subScene);
				}
			}
		}

		// // RVA: 0x1D73BD8 Offset: 0x1D73BD8 VA: 0x1D73BD8 Slot: 7
		public void UpdateLeaveFadeOut()
		{
			if(GameManager.IsFading())
				return;

			updateState = this.UpdateLeave;
		}

		// // RVA: 0x1D73CA4 Offset: 0x1D73CA4 VA: 0x1D73CA4 Slot: 8
		public void UpdateLeave()
		{
			if(!DoUpdateLeave())
				return;

			asyncLoader = SceneAsyncLoader.Create(mNextSceneName);
			updateState = this.UpdateStateLoadScene;
		}

		// // RVA: 0x1D73D58 Offset: 0x1D73D58 VA: 0x1D73D58
		private void UpdateStateLoadScene()
		{
			if(!asyncLoader.isLoaded)
				return;

			DestroyObject(asyncLoader.gameObject);
		}

		// // RVA: 0x1D73E28 Offset: 0x1D73E28 VA: 0x1D73E28 Slot: 9
		protected virtual void DoAwake()
		{
		}

		// // RVA: 0x1D73E2C Offset: 0x1D73E2C VA: 0x1D73E2C Slot: 10
		protected virtual void DoStart()
		{
		}

		// // RVA: 0x1D73E30 Offset: 0x1D73E30 VA: 0x1D73E30 Slot: 11
		// protected virtual void DoOnGUI() { }

		// // RVA: 0x1D73E34 Offset: 0x1D73E34 VA: 0x1D73E34 Slot: 12
		protected virtual bool DoUpdateEnter()
		{
			return true;
		}

		// // RVA: 0x1D73E3C Offset: 0x1D73E3C VA: 0x1D73E3C Slot: 13
		protected virtual void DoUpdateMain()
		{
		}

		// // RVA: 0x1D73E40 Offset: 0x1D73E40 VA: 0x1D73E40 Slot: 14
		protected virtual bool DoUpdateLeave()
		{
			return true;
		}

		// // RVA: 0x1D73E48 Offset: 0x1D73E48 VA: 0x1D73E48 Slot: 15
		// protected virtual void DoOnApplicationQuit() { }

		// // RVA: 0x1D73E4C Offset: 0x1D73E4C VA: 0x1D73E4C
		// protected void NextScene(string nextSceneName) { }

		// // RVA: 0x1D73F08 Offset: 0x1D73F08 VA: 0x1D73F08
		// protected void ReturnMainScene() { }

		// // RVA: 0x1D7403C Offset: 0x1D7403C VA: 0x1D7403C
		// protected void NextSubScene(SubSceneBase subScene) { }
	}
}
