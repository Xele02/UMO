using mcrs;
using System.Collections;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public abstract class ModelViewModeScene : TransitionRoot
	{
		private LayoutModelViewModeBase m_Layout; // 0x48
		private LayoutModelViewModeBase m_LayoutVertical_LB; // 0x4C
		private LayoutModelViewModeBase m_LayoutVertical_RT; // 0x50
		private bool m_IsCheckShowUI; // 0x54
		private bool m_reverse; // 0x55

		// RVA: 0x1047608 Offset: 0x1047608 VA: 0x1047608 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			this.StartCoroutineWatched(Co_Initialize());
		}

		//// RVA: -1 Offset: -1 Slot: 31
		protected abstract void GetLayoutName(out string bundle_name, out string asset_name, out string asset_name_vertical_LB, out string asset_name_vertical_RT);

		//[IteratorStateMachineAttribute] // RVA: 0x6ED194 Offset: 0x6ED194 VA: 0x6ED194
		//// RVA: 0x1047638 Offset: 0x1047638 VA: 0x1047638
		private IEnumerator Co_Initialize()
		{
			//0x1048730
			yield return Co.R(Co_LoadLayout());
			while (m_Layout == null)
				yield return null;
			while (!m_Layout.IsReady())
				yield return null;
			while(m_Layout.GetButton() == null)
				yield return null;
			m_Layout.GetButton().AddOnClickCallback(OnClickButton);
			if (m_LayoutVertical_LB != null)
			{
				while (!m_LayoutVertical_LB.IsReady())
					yield return null;
				while (m_LayoutVertical_LB.GetButton() == null)
					yield return null;
				m_LayoutVertical_LB.GetButton().AddOnClickCallback(OnClickButton);
			}
			if(m_LayoutVertical_RT != null)
			{
				while (!m_LayoutVertical_RT.IsReady())
					yield return null;
				while (m_LayoutVertical_RT.GetButton() == null)
					yield return null;
				m_LayoutVertical_RT.GetButton().AddOnClickCallback(OnClickButton);
			}
			IsReady = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6ED20C Offset: 0x6ED20C VA: 0x6ED20C
		//// RVA: 0x10476E4 Offset: 0x10476E4 VA: 0x10476E4
		private IEnumerator Co_LoadLayout()
		{
			string bundle_name; // 0x14
			string asset_name_v_LB; // 0x18
			string asset_name_v_RT; // 0x1C
			int t_cnt_load_bundle; // 0x20
			AssetBundleLoadLayoutOperationBase op; // 0x24

			//0x1048E04
			bundle_name = "";
			asset_name_v_LB = "";
			asset_name_v_RT = "";
			string asset_name = "";
			GetLayoutName(out bundle_name, out asset_name, out asset_name_v_LB, out asset_name_v_RT);

			t_cnt_load_bundle = 0;
			if(asset_name != "")
			{
				op = AssetBundleManager.LoadLayoutAsync(bundle_name, asset_name);
				yield return op;
				yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x1048474
					m_Layout = instance.GetComponent<LayoutModelViewModeBase>();
					instance.transform.SetParent(transform, false);
				}));
				t_cnt_load_bundle++;
				op = null;
			}
			if(asset_name_v_LB != "")
			{
				m_LayoutVertical_LB = new LayoutModelViewModeBase();
				op = AssetBundleManager.LoadLayoutAsync(bundle_name, asset_name_v_LB);
				yield return op;
				yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x104855C
					m_LayoutVertical_LB = instance.GetComponent<LayoutModelViewModeBase>();
					instance.transform.SetParent(transform, false);
				}));
				t_cnt_load_bundle++;
				op = null;
			}
			if (asset_name_v_RT != "")
			{
				m_LayoutVertical_RT = new LayoutModelViewModeBase();
				op = AssetBundleManager.LoadLayoutAsync(bundle_name, asset_name_v_RT);
				yield return op;
				yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x1048644
					m_LayoutVertical_RT = instance.GetComponent<LayoutModelViewModeBase>();
					instance.transform.SetParent(transform, false);
				}));
				t_cnt_load_bundle++;
				op = null;
			}
			for(int i = 0; i < t_cnt_load_bundle; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundle_name, false);
			}
		}

		//// RVA: 0x1047790 Offset: 0x1047790 VA: 0x1047790
		private bool IsPlayingAll()
		{
			if (m_Layout.IsPlaying())
				return true;
			if (m_LayoutVertical_LB != null && m_LayoutVertical_LB.IsPlaying())
				return true;
			if (m_LayoutVertical_RT != null && m_LayoutVertical_RT.IsPlaying())
				return true;
			return false;
		}

		//// RVA: 0x1047904 Offset: 0x1047904 VA: 0x1047904
		private void Enter()
		{
			m_Layout.Enter();
			if(m_LayoutVertical_LB != null)
			{
				m_LayoutVertical_LB.SetEnableHit(false);
			}
			if(m_LayoutVertical_RT != null)
			{
				m_LayoutVertical_RT.SetEnableHit(false);
			}
		}

		//// RVA: 0x1047A60 Offset: 0x1047A60 VA: 0x1047A60
		private void Leave()
		{
			if(m_Layout.IsEntered())
			{
				m_Layout.Leave();
			}
			if(m_LayoutVertical_LB != null && m_LayoutVertical_LB.IsEntered())
			{
				m_LayoutVertical_LB.Leave();
			}
			if (m_LayoutVertical_RT != null && m_LayoutVertical_RT.IsEntered())
			{
				m_LayoutVertical_RT.Leave();
			}
		}

		// RVA: 0x1047C30 Offset: 0x1047C30 VA: 0x1047C30 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			Enter();
			GameManager.Instance.SetTouchEffectVisible(false);
		}

		// RVA: 0x1047CDC Offset: 0x1047CDC VA: 0x1047CDC Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !IsPlayingAll();
		}

		// RVA: 0x1047CF0 Offset: 0x1047CF0 VA: 0x1047CF0 Slot: 12
		protected override void OnStartExitAnimation()
		{
			Leave();
			GameManager.Instance.SetTouchEffectVisible(true);
			m_IsCheckShowUI = false;
		}

		// RVA: 0x1047DA4 Offset: 0x1047DA4 VA: 0x1047DA4 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !IsPlayingAll();
		}

		// RVA: 0x1047DB8 Offset: 0x1047DB8 VA: 0x1047DB8 Slot: 21
		protected override void OnOpenScene()
		{
			base.OnOpenScene();
			m_IsCheckShowUI = true;
		}

		//// RVA: 0x1047DD8 Offset: 0x1047DD8 VA: 0x1047DD8 Slot: 32
		protected virtual void OnClickButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.Return(true);
		}

		// RVA: 0x1047EC4 Offset: 0x1047EC4 VA: 0x1047EC4
		protected void PerformClickReturnButton()
		{
			if(m_Layout.GetButton() != null)
			{
				m_Layout.GetButton().PerformClick();
			}
		}

		// RVA: 0x1047F94 Offset: 0x1047F94 VA: 0x1047F94
		public void Update()
		{
			if (!m_IsCheckShowUI)
				return;
			if (Screen.orientation == ScreenOrientation.LandscapeRight)
				m_reverse = false;
			else
			{
				if (Screen.orientation == ScreenOrientation.LandscapeLeft)
					m_reverse = true;
			}
			if(!m_reverse)
			{
				if (Input.deviceOrientation <= DeviceOrientation.PortraitUpsideDown || Input.deviceOrientation > DeviceOrientation.LandscapeRight)
				{
					if (Input.deviceOrientation != DeviceOrientation.PortraitUpsideDown)
					{
						if (Input.deviceOrientation != DeviceOrientation.Portrait)
						{
							return;
						}
						//LAB_01048064
						if (m_Layout.IsEntered())
							m_Layout.Leave();
						if (m_LayoutVertical_LB != null && m_LayoutVertical_LB.IsEntered())
							m_LayoutVertical_LB.Leave();
						if (m_LayoutVertical_RT != null && !m_LayoutVertical_RT.IsEntered())
							m_LayoutVertical_RT.Enter();
					}
					else
					{
						//LAB_010482c8
						if (m_Layout.IsEntered())
							m_Layout.Leave();
						if (m_LayoutVertical_LB != null && !m_LayoutVertical_LB.IsEntered())
							m_LayoutVertical_LB.Enter();
						if (m_LayoutVertical_RT != null && m_LayoutVertical_RT.IsEntered())
							m_LayoutVertical_RT.Leave();
					}
				}
				else
				{
					//LAB_010481d8
					if (!m_Layout.IsEntered())
						m_Layout.Enter();
					if (m_LayoutVertical_LB != null && m_LayoutVertical_LB.IsEntered())
						m_LayoutVertical_LB.Leave();
					if (m_LayoutVertical_RT != null && m_LayoutVertical_RT.IsEntered())
						m_LayoutVertical_RT.Leave();
				}
			}
			else
			{
				if(Input.deviceOrientation >= DeviceOrientation.LandscapeLeft && Input.deviceOrientation < DeviceOrientation.FaceUp)
				{
					//LAB_010481d8
					if (!m_Layout.IsEntered())
						m_Layout.Enter();
					if (m_LayoutVertical_LB != null && m_LayoutVertical_LB.IsEntered())
						m_LayoutVertical_LB.Leave();
					if (m_LayoutVertical_RT != null && m_LayoutVertical_RT.IsEntered())
						m_LayoutVertical_RT.Leave();
				}
				else
				{
					if(Input.deviceOrientation != DeviceOrientation.Portrait)
					{
						if(Input.deviceOrientation != DeviceOrientation.PortraitUpsideDown)
						{
							return;
						}
						//LAB_01048064
						if (m_Layout.IsEntered())
							m_Layout.Leave();
						if (m_LayoutVertical_LB != null && m_LayoutVertical_LB.IsEntered())
							m_LayoutVertical_LB.Leave();
						if (m_LayoutVertical_RT != null && !m_LayoutVertical_RT.IsEntered())
							m_LayoutVertical_RT.Enter();
					}
					else
					{
						//LAB_010482c8
						if (m_Layout.IsEntered())
							m_Layout.Leave();
						if (m_LayoutVertical_LB != null && !m_LayoutVertical_LB.IsEntered())
							m_LayoutVertical_LB.Enter();
						if (m_LayoutVertical_RT != null && m_LayoutVertical_RT.IsEntered())
							m_LayoutVertical_RT.Leave();
					}
				}
			}
		}
	}
}
