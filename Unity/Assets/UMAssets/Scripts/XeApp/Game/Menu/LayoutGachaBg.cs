using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;
using System.Collections;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class LayoutGachaBg : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_image; // 0x14
		[SerializeField]
		private ButtonBase m_button; // 0x18
		[SerializeField]
		private SwaipTouch m_swipeTouch; // 0x1C
		private AbsoluteLayout m_layoutFade; // 0x20
		private LayoutGachaArrowButton[] m_arrowButton; // 0x24
		private int m_index; // 0x28
		private bool m_initialized; // 0x2C
		private float m_waitTime; // 0x30
		private bool m_loopStop; // 0x34
		private int m_loadSceneId; // 0x38
		private int m_loadGachaId; // 0x3C
		private bool m_fade; // 0x40
		private bool m_isLockScene; // 0x41
		private bool m_isLockSwipe; // 0x42
		private BEPHBEGDFFK m_view; // 0x44
		private List<CEBFFLDKAEC_SecureInt> m_sceneIds; // 0x48
		private Coroutine m_coroutine; // 0x4C

		public Action OnClickBgImage { private get; set; } // 0x50
		public Action<int> OnChangeBgScene { private get; set; } // 0x54
		public Action OnSwipeToLeft { private get; set; } // 0x58
		public Action OnSwipeToRight { private get; set; } // 0x5C

		// RVA: 0x199A310 Offset: 0x199A310 VA: 0x199A310
		private void Update()
		{
			if (!m_swipeTouch.IsReady())
				return;
			EventSystem ev = EventSystem.current;
			if (ev == null)
				return;
			if (ev.currentSelectedGameObject == null)
				return;
			if (ev.currentSelectedGameObject.name != m_button.name)
				return;
			if(m_isLockScene)
			{
				if (!m_swipeTouch.IsSwaiping())
					m_isLockScene = false;
			}
			if(m_swipeTouch.IsSwaip(SwaipTouch.Direction.RIGHT) || m_swipeTouch.IsFlickNoSwaip(SwaipTouch.Direction.RIGHT))
			{
				if(!m_isLockSwipe)
				{
					m_isLockScene = true;
					if (OnSwipeToRight != null)
						OnSwipeToRight();
				}
			}
			if (m_swipeTouch.IsSwaip(SwaipTouch.Direction.LEFT) || m_swipeTouch.IsFlickNoSwaip(SwaipTouch.Direction.LEFT))
			{
				if (!m_isLockSwipe)
				{
					m_isLockScene = true;
					if (OnSwipeToLeft != null)
						OnSwipeToLeft();
				}
			}
			if (!m_isLockSwipe)
				return;
			if (!m_button.IsPressed())
				m_isLockSwipe = false;
		}

		// RVA: 0x199A670 Offset: 0x199A670 VA: 0x199A670
		private void OnDestroy()
		{
			if(m_arrowButton[0] != null)
			{
				Destroy(m_arrowButton[0].gameObject);
				m_arrowButton[0] = null;
			}
			if (m_arrowButton[1] != null)
			{
				Destroy(m_arrowButton[1].gameObject);
				m_arrowButton[1] = null;
			}
			m_arrowButton = null;
		}

		//// RVA: 0x199A934 Offset: 0x199A934 VA: 0x199A934
		public bool IsFading()
		{
			return m_fade;
		}

		// RVA: 0x199A93C Offset: 0x199A93C VA: 0x199A93C
		public void Setup(BEPHBEGDFFK view, bool isFade)
		{
			m_index = 0;
			m_view = view;
			m_waitTime = 0;
			m_sceneIds = null;
			if (view.DPBDFPPMIPH.KACECFNECON != null)
			{
				m_sceneIds = m_view.DPBDFPPMIPH.KACECFNECON.PGKIHFOKEHL;
			}
			if(m_view.DPBDFPPMIPH.MFICPBJPCCJ < 1)
			{
				if(m_sceneIds != null && m_sceneIds.Count > 0)
				{
					int pickupId = m_view.BADFIKBADNH_PickupId;
					int idx = m_sceneIds.FindIndex((CEBFFLDKAEC_SecureInt x) =>
					{
						//0x199C208
						return x.DNJEJEANJGL_Value == pickupId;
					});
					m_index = Mathf.Clamp(idx, 0, m_sceneIds.Count - 1);
					if (isFade)
					{
						this.StartCoroutineWatched(Co_FadeChangeSceneBgImage(m_sceneIds[idx].DNJEJEANJGL_Value, m_view.EFCJADAPOMN));
					}
					else
					{
						LoadSceneBgImage(m_sceneIds[idx].DNJEJEANJGL_Value, m_view.EFCJADAPOMN, null);
					}
					m_loopStop = false;
					m_arrowButton[0].SetActive(m_sceneIds.Count > 1);
					m_arrowButton[1].SetActive(m_sceneIds.Count > 1);
					m_swipeTouch.enabled = m_sceneIds.Count > 1;
				}
				else
				{
					if(isFade)
					{
						this.StartCoroutineWatched(Co_FadeChangeGachaBgImage(70001));
					}
					else
					{
						LoadGachaBgImage(70001, null);
					}
					m_loopStop = true;
					m_loadGachaId = 70001;
					m_arrowButton[0].SetActive(false);
					m_arrowButton[1].SetActive(false);
					m_swipeTouch.enabled = false;
				}
			}
			else
			{
				if(isFade)
				{
					this.StartCoroutineWatched(Co_FadeChangeGachaBgImage(m_view.DPBDFPPMIPH.MFICPBJPCCJ));
				}
				else
				{
					LoadGachaBgImage(m_view.DPBDFPPMIPH.MFICPBJPCCJ, null);
				}
				m_loopStop = true;
				m_arrowButton[0].SetActive(false);
				m_arrowButton[1].SetActive(false);
				m_swipeTouch.enabled = false;
			}
			m_initialized = true;
		}

		//// RVA: 0x199B248 Offset: 0x199B248 VA: 0x199B248
		public void NextChangeBg()
		{
			m_waitTime = 0;
			m_index++;
			if(m_index >= m_sceneIds.Count)
				m_index = 0;
			LoadSceneBgImage(m_sceneIds[m_index].DNJEJEANJGL_Value, m_view.EFCJADAPOMN, () =>
			{
				//0x199BCAC
				if (OnChangeBgScene != null)
					OnChangeBgScene(m_sceneIds[m_index].DNJEJEANJGL_Value);
			});
		}

		//// RVA: 0x199B3A4 Offset: 0x199B3A4 VA: 0x199B3A4
		public void PrevChangeBg()
		{
			m_waitTime = 0;
			m_index--;
			if (m_index < 0)
				m_index = m_sceneIds.Count - 1;
			LoadSceneBgImage(m_sceneIds[m_index].DNJEJEANJGL_Value, m_view.EFCJADAPOMN, () =>
			{
				//0x199BD74
				if (OnChangeBgScene != null)
					OnChangeBgScene(m_sceneIds[m_index].DNJEJEANJGL_Value);
			});
		}

		//// RVA: 0x199B500 Offset: 0x199B500 VA: 0x199B500
		//public void SwitchRarity(bool rarity) { }

		//// RVA: 0x199B5C8 Offset: 0x199B5C8 VA: 0x199B5C8
		public void StartChangeBgLoop()
		{
			if (m_coroutine != null)
				return;
			m_coroutine = this.StartCoroutineWatched(Co_ChangeBgLoop());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DD94C Offset: 0x6DD94C VA: 0x6DD94C
		//// RVA: 0x199B600 Offset: 0x199B600 VA: 0x199B600
		private IEnumerator Co_ChangeBgLoop()
		{
			float interval;

			//0x199C56C
			interval = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA("interval_time_gacha_bg", 5000);
			while(true)
			{
				while (m_loopStop)
					yield return null;
				while (m_sceneIds == null || m_sceneIds.Count < 1)
					yield return null;
				if(MenuScene.Instance.IsTransition())
				{
					m_coroutine = null;
					yield break;
				}
				if(interval <= m_waitTime)
				{
					m_waitTime = 0;
					m_index++;
					if (m_index >= m_sceneIds.Count)
						m_index = 0;
					int v = m_sceneIds[m_index].DNJEJEANJGL_Value;
					if(m_view.BADFIKBADNH_PickupId != v)
					{
						yield return Co.R(Co_FadeChangeSceneBgImage(v, m_view.EFCJADAPOMN));
					}
				}
				m_waitTime += Time.deltaTime;
				yield return null;
			}
		}

		//// RVA: 0x199B6AC Offset: 0x199B6AC VA: 0x199B6AC
		public void SetChangeBgLoopState(bool stop, float waitTime = -1)
		{
			if (m_loadGachaId > 0)
				return;
			m_loopStop = stop;
			if (waitTime >= 0)
				m_waitTime = waitTime;
		}

		//// RVA: 0x199B0B4 Offset: 0x199B0B4 VA: 0x199B0B4
		public void LoadSceneBgImage(int sceneId, bool rarity, Action callback)
		{
			m_view.BADFIKBADNH_PickupId = sceneId;
			m_image.enabled = m_initialized;
			m_view.LBMILLAEEBK.Load(sceneId, rarity ? 2 : 1, (IiconTexture iconTex) =>
			{
				//0x199C24C
				m_image.enabled = true;
				iconTex.Set(m_image);
				m_image.uvRect = new Rect(0, 0, 1, 1);
				if (callback != null)
					callback();
			});
		}

		//// RVA: 0x199AF10 Offset: 0x199AF10 VA: 0x199AF10
		public void LoadGachaBgImage(int gachaId, Action callback)
		{
			m_view.BADFIKBADNH_PickupId = 0;
			m_image.enabled = m_initialized;
			m_view.MMJONIHIOFI.Load(gachaId, (IiconTexture iconTex) =>
			{
				//0x199C3FC
				m_image.enabled = true;
				iconTex.Set(m_image);
				if (callback != null)
					callback();
			});
		}

		//// RVA: 0x199B090 Offset: 0x199B090 VA: 0x199B090
		//private void FadeChangeSceneBgImage(int sceneId, bool rarity) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6DD9C4 Offset: 0x6DD9C4 VA: 0x6DD9C4
		//// RVA: 0x199B6E0 Offset: 0x199B6E0 VA: 0x199B6E0
		private IEnumerator Co_FadeChangeSceneBgImage(int sceneId, bool rarity)
		{
			//0x199CE34
			MenuScene.Instance.RaycastDisable();
			m_loadSceneId = sceneId;
			if (!m_fade)
			{
				m_fade = true;
				m_layoutFade.StartChildrenAnimGoStop("go_in", "st_in");
				while (m_layoutFade.IsPlayingChildren())
					yield return null;
			}
			if(m_loadSceneId != sceneId)
			{
				MenuScene.Instance.RaycastEnable();
				yield break;
			}
			m_loadGachaId = 0;
			bool done = false;
			LoadSceneBgImage(m_loadSceneId, rarity, () =>
			{
				//0x199C548
				done = true;
			});
			while (!done)
				yield return null;
			if (OnChangeBgScene != null)
				OnChangeBgScene(sceneId);
			MenuScene.Instance.RaycastEnable();
			if(m_fade)
			{
				m_fade = false;
				m_layoutFade.StartChildrenAnimGoStop("go_out", "st_out");
				while (m_layoutFade.IsPlayingChildren())
					yield return null;
			}
		}

		//// RVA: 0x199AEEC Offset: 0x199AEEC VA: 0x199AEEC
		//private void FadeChangeGachaBgImage(int gachaId) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6DDA3C Offset: 0x6DDA3C VA: 0x6DDA3C
		//// RVA: 0x199B7C0 Offset: 0x199B7C0 VA: 0x199B7C0
		private IEnumerator Co_FadeChangeGachaBgImage(int gachaId)
		{
			//0x199C9B4
			MenuScene.Instance.RaycastDisable();
			m_loadGachaId = gachaId;
			m_layoutFade.StartChildrenAnimGoStop("go_in", "st_in");
			while (m_layoutFade.IsPlayingChildren())
				yield return null;
			if(m_loadGachaId == gachaId)
			{
				m_loadSceneId = 0;
				bool done = false;
				LoadGachaBgImage(m_loadGachaId, () =>
				{
					//0x199C55C
					done = true;
				});
				while (!done)
					yield return null;
				MenuScene.Instance.RaycastEnable();
				m_layoutFade.StartChildrenAnimGoStop("go_out", "st_out");
				while (m_layoutFade.IsPlayingChildren())
					yield return null;
			}
			else
			{
				MenuScene.Instance.RaycastEnable();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DDAB4 Offset: 0x6DDAB4 VA: 0x6DDAB4
		//// RVA: 0x199B888 Offset: 0x199B888 VA: 0x199B888
		private IEnumerator LoadContents(Action callback)
		{
			string assetBundleName; // 0x18
			Font font; // 0x1C
			AssetBundleLoadLayoutOperationBase layoutOp; // 0x20

			//0x199D314
			assetBundleName = "ly/155.xab";
			font = GameManager.Instance.GetSystemFont();
			m_arrowButton = new LayoutGachaArrowButton[2];
			layoutOp = AssetBundleManager.LoadLayoutAsync(assetBundleName, "root_arrow_l_layout_root");
			yield return layoutOp;
			yield return Co.R(layoutOp.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x199BE3C
				instance.transform.SetParent(transform, false);
				m_arrowButton[0] = instance.GetComponent<LayoutGachaArrowButton>();
				m_arrowButton[0].OnClickButton = PrevChangeBg;
			}));
			layoutOp = AssetBundleManager.LoadLayoutAsync(assetBundleName, "root_arrow_r_layout_root");
			yield return layoutOp;
			yield return Co.R(layoutOp.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x199C010
				instance.transform.SetParent(transform, false);
				m_arrowButton[1] = instance.GetComponent<LayoutGachaArrowButton>();
				m_arrowButton[1].OnClickButton = NextChangeBg;
			}));
			if (callback != null)
				callback();
		}

		//// RVA: 0x199B950 Offset: 0x199B950 VA: 0x199B950
		//public string ToString(bool isWait = True, bool isLoading = True) { }

		// RVA: 0x199BAB4 Offset: 0x199BAB4 VA: 0x199BAB4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutFade = layout.FindViewById("sw_plate_w_anim") as AbsoluteLayout;
			m_button.AddOnClickCallback(() =>
			{
				//0x199C1E4
				if (m_isLockScene)
					return;
				if (OnClickBgImage != null)
					OnClickBgImage();
			});
			m_swipeTouch.SetAdjustment(true, false, 50, 50, 50, 50, true);
			m_swipeTouch.SetMute(true);
			this.StartCoroutineWatched(LoadContents(Loaded));
			return true;
		}
	}
}
