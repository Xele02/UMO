using UnityEngine;
using System;
using UnityEngine.UI;
using XeApp.Game.Menu;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using XeSys;

namespace XeApp.Game.Common
{
	public class HomePickupBanner : MonoBehaviour
	{
		public enum Type
		{
			Open = 0,
			Close = 1,
			Num = 2,
		}

		[Serializable]
		public class ReplaceInfo
		{
			public string name; // 0x8
			public Sprite sprite; // 0xC
		}

		public class RepeatTimer
		{
			private float m_wait; // 0x8
			private float m_time; // 0xC

			public Action OnRepeatTiming { get; set; } // 0x10

			// // RVA: 0xEAD384 Offset: 0xEAD384 VA: 0xEAD384
			public void Update()
			{
				if(m_wait > 0)
				{
					if(m_time >= m_wait)
					{
						m_time = 0;
						if (OnRepeatTiming != null)
							OnRepeatTiming();
					}
					else
					{
						m_time += Time.deltaTime;
					}
				}
			}

			// // RVA: 0xEADA10 Offset: 0xEADA10 VA: 0xEADA10
			public void Init(float wait)
			{
				m_wait = wait;
				m_time = 0;
			}
		}

		// [HeaderAttribute] // RVA: 0x68A404 Offset: 0x68A404 VA: 0x68A404
		[SerializeField]
		private ReplaceInfo[] m_tableReplace = new ReplaceInfo[2]; // 0xC
		// [HeaderAttribute] // RVA: 0x68A46C Offset: 0x68A46C VA: 0x68A46C
		[SerializeField]
		private float m_autoScrollWait = 5; // 0x10
		[SerializeField]
		private int m_sizeOpen = 580; // 0x14
		[SerializeField]
		private int m_sizeClose = 80; // 0x18
		[SerializeField]
		private float m_openAnimTime = 0.5f; // 0x1C
		[SerializeField]
		private float m_closeAnimTime = 0.5f; // 0x20
		[SerializeField]
		private AnimationCurve m_animOpenClose; // 0x24
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x68A504 Offset: 0x68A504 VA: 0x68A504
		private float m_changeTime = 0.5f; // 0x28
		// [HeaderAttribute] // RVA: 0x68A57C Offset: 0x68A57C VA: 0x68A57C
		[SerializeField]
		private float m_swipeMinDistance = 50; // 0x2C
		[SerializeField]
		private float m_swipeMaxDistance = 150; // 0x30
		// [HeaderAttribute] // RVA: 0x68A608 Offset: 0x68A608 VA: 0x68A608
		[SerializeField]
		private ButtonBase m_buttonOpenClose; // 0x34
		// [HeaderAttribute] // RVA: 0x68A67C Offset: 0x68A67C VA: 0x68A67C
		[SerializeField]
		private Image m_imageOpenClose; // 0x38
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x68A6F4 Offset: 0x68A6F4 VA: 0x68A6F4
		private UGUILoopScrollList m_scrollView; // 0x3C
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x68A73C Offset: 0x68A73C VA: 0x68A73C
		private GameObject m_scrollbar; // 0x40
		// [HeaderAttribute] // RVA: 0x68A794 Offset: 0x68A794 VA: 0x68A794
		[SerializeField]
		private Image m_imageScroll; // 0x44
		// [HeaderAttribute] // RVA: 0x68A7FC Offset: 0x68A7FC VA: 0x68A7FC
		[SerializeField]
		private HomePickupBannerContent m_objBanner; // 0x48
		// [HeaderAttribute] // RVA: 0x68A844 Offset: 0x68A844 VA: 0x68A844
		[SerializeField]
		private Transform m_rootPageNum; // 0x4C
		[SerializeField]
		private Text m_textPageNum; // 0x50
		// [HeaderAttribute] // RVA: 0x68A8BC Offset: 0x68A8BC VA: 0x68A8BC
		[SerializeField]
		private InOutAnime m_inOutAnime; // 0x54
		// [HeaderAttribute] // RVA: 0x68A904 Offset: 0x68A904 VA: 0x68A904
		[SerializeField]
		private CanvasGroup m_canvasGroup; // 0x58
		private Font m_font; // 0x5C
		private bool m_vertical; // 0x60
		private bool m_toggleOpenClose; // 0x61
		private int m_inputDisableCount; // 0x64
		private RepeatTimer m_repeatTimer = new RepeatTimer(); // 0x68
		private HomeBannerTextureCache m_bannerTexCache; // 0x6C
		private List<JBCAHMMCOKK> m_list = new List<JBCAHMMCOKK>(); // 0x70

		public Action<int> onClickBannerButton { private get; set; } // 0x74

		// RVA: 0xEAD074 Offset: 0xEAD074 VA: 0xEAD074
		private void Start()
		{
			m_buttonOpenClose.ClearOnClickCallback();
			m_buttonOpenClose.AddOnClickCallback(OnClickToggle);
			m_scrollView.OnUpdateItem = (int index, UGUILoopScrollContent content) =>
			{
				//0xEAEC78
				TodoLogger.Log(0, "OnUpdateItem ");
			};
			m_scrollView.OnDragBegin = () =>
			{
				//0xEAF00C
				TodoLogger.Log(0, "OnDragBegin ");
			};
			m_scrollView.OnDragEnd = (Vector2 vec) =>
			{
				//0xEAF048
				TodoLogger.Log(0, "OnDragEnd ");
			};
			m_repeatTimer.OnRepeatTiming = () =>
			{
				//0xEAF294
				TodoLogger.Log(0, "OnRepeatTiming ");
			};
		}

		// RVA: 0xEAD2C0 Offset: 0xEAD2C0 VA: 0xEAD2C0
		protected void LateUpdate()
		{
			if (MenuScene.Instance.IsTransition())
				return;
			m_repeatTimer.Update();
		}

		// RVA: 0xEAD3F8 Offset: 0xEAD3F8 VA: 0xEAD3F8
		public void SetFont(Font font)
		{
			m_font = font;
		}

		// // RVA: 0xEAD400 Offset: 0xEAD400 VA: 0xEAD400
		public void Setup(List<JBCAHMMCOKK> list, HomeBannerTextureCache bannerTexCache)
		{
			m_bannerTexCache = bannerTexCache;
			m_list = list;
			for(int i = 0; i < m_scrollView.ScrollObjects.Count; i++)
			{
				Destroy(m_scrollView.ScrollObjects[i].gameObject);
			}
			m_scrollView.ClearScrollObject();
			for(int i = 0; i < m_scrollView.ObjectPoolSize; i++)
			{
                HomePickupBannerContent banner = Instantiate(m_objBanner);
				banner.name = banner.name.Replace("(Clone)", string.Format("_{0:D2}0", i));
				banner.transform.SetParent(m_scrollView.content, false);
				banner.SetFont(m_font);
				banner.onClickButton = (int pictId) => {
					//0xEAF41C
					if(onClickBannerButton != null)
						onClickBannerButton(pictId);
				};
				m_scrollView.AddScrollObject(banner);
            }
			ToggleAnimation(true, 0);
			m_toggleOpenClose = false;
		}

		// // RVA: 0xEAD960 Offset: 0xEAD960 VA: 0xEAD960
		public void StartAutoScroll()
		{
			if(m_list.Count < 2)
				m_repeatTimer.Init(0);
			else
				m_repeatTimer.Init(m_autoScrollWait);
		}

		// // RVA: 0xEADA20 Offset: 0xEADA20 VA: 0xEADA20
		public void StopAutoScroll()
		{
			m_repeatTimer.Init(0);
		}

		// // RVA: 0xEADA4C Offset: 0xEADA4C VA: 0xEADA4C
		public int GetContentSize(bool vertical)
		{
			if(vertical)
			{
				return (int)(Mathf.Min(m_list.Count, 5) * Mathf.Round(m_scrollView.ContentSize.y + m_scrollView.Spacing.y));
			}
			else
			{
				return (int)Mathf.Round(m_scrollView.ContentSize.x + m_scrollView.Spacing.x);
			}
		}

		// // RVA: 0xEADBBC Offset: 0xEADBBC VA: 0xEADBBC
		private void InputEnable()
		{
			m_inputDisableCount = Mathf.Max(m_inputDisableCount - 1, 0);
			m_buttonOpenClose.enabled = m_inputDisableCount == 0;
		}

		// // RVA: 0xEADC7C Offset: 0xEADC7C VA: 0xEADC7C
		private void InputDisable()
		{
			m_inputDisableCount = Mathf.Max(m_inputDisableCount + 1, 0);
			m_buttonOpenClose.enabled = m_inputDisableCount == 0;
		}

		// // RVA: 0xEADD3C Offset: 0xEADD3C VA: 0xEADD3C
		private void SetPageNum(int page)
		{
			m_textPageNum.text = string.Format("{0}\n{1}", page, m_list.Count);
		}

		// // RVA: 0xEADE44 Offset: 0xEADE44 VA: 0xEADE44
		private void OnClickToggle()
		{
			TodoLogger.LogNotImplemented("OnClickToggle");
		}

		// // RVA: 0xEAD840 Offset: 0xEAD840 VA: 0xEAD840
		private void ToggleAnimation(bool toggle, float animTime)
		{
			IEnumerator e = Co_ToggleAnimation(toggle, animTime);
			if(animTime > 0)
			{
				this.StartCoroutineWatched(e);
			}
			else
			{
				e.MoveNext();
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73D684 Offset: 0x73D684 VA: 0x73D684
		// // RVA: 0xEADF04 Offset: 0xEADF04 VA: 0xEADF04
		private IEnumerator Co_ToggleAnimation(bool toggle, float animTime)
		{
			RectTransform scrollViewRect; // 0x1C
			Vector2 scrollSize; // 0x20
			int contentSize; // 0x28
			int animStart; // 0x2C
			int animEnd; // 0x30
			int diff; // 0x34
			float time; // 0x38
			float speed; // 0x3C

			//0xEAF4CC
			InputDisable();
			if(!toggle)
			{
				ChangeScrollType(true);
				m_scrollView.Apply(6, 1, m_scrollView.ContentSize);
				m_scrollView.SetItemCount(m_list.Count, false);
				m_scrollView.SetPosition(0, 0);
				SetPageNum(1);
			}
			scrollViewRect = m_scrollView.transform as RectTransform;
			scrollSize = scrollViewRect.sizeDelta;
			contentSize = GetContentSize(true);
			if(!toggle)
			{
				m_imageOpenClose.sprite = m_tableReplace[0].sprite;
				animStart = Mathf.Min(m_sizeClose, contentSize);
				animEnd = Mathf.Min(m_sizeOpen, contentSize);
				m_scrollView.vertical = m_sizeOpen < contentSize;
			}
			else
			{
				m_imageOpenClose.sprite = m_tableReplace[1].sprite;
				animStart = Mathf.Min(m_sizeOpen, contentSize);
				animEnd = Mathf.Min(m_sizeClose, contentSize);
				m_scrollView.vertical = m_sizeOpen < contentSize;
			}
			time = 0;
			diff = animEnd - animStart;
			speed = 1.0f / animTime;
			while(time <= animTime)
			{
				time += Time.deltaTime;
				float f = m_animOpenClose.Evaluate(time * speed);
				scrollSize.y = f * diff + animStart;
				scrollViewRect.sizeDelta = scrollSize;
				yield return null;
			}
			scrollSize.y = animEnd;
			scrollViewRect.sizeDelta = scrollSize;
			if(!toggle)
			{
				if(m_scrollbar != null)
				{
					m_scrollbar.SetActive(scrollSize.y < contentSize);
				}
			}
			else
			{
				ChangeScrollType(false);
				m_scrollView.Apply(1, 6, m_scrollView.ContentSize);
				m_scrollView.SetItemCount(m_list.Count, true);
				m_scrollView.SetPosition(0, 0);
				SetPageNum(1);
				if(m_scrollbar != null)
				{
					m_scrollbar.SetActive(false);
				}
			}
			InputEnable();
		}

		// // RVA: 0xEADFF0 Offset: 0xEADFF0 VA: 0xEADFF0
		private void ChangeScrollType(bool vertical)
		{
			m_vertical = vertical;
			if(vertical)
			{
				m_scrollView.content.anchoredPosition = new Vector2(0, m_scrollView.content.anchoredPosition.y);
				m_scrollView.content.offsetMin = new Vector2(5, m_scrollView.content.offsetMin.y);
				m_scrollView.horizontal = false;
				m_scrollView.vertical = true;
				m_scrollView.verticalNormalizedPosition = 1;
				m_scrollView.movementType = ScrollRect.MovementType.Elastic;
				m_imageScroll.enabled = true;
				m_rootPageNum.gameObject.SetActive(false);
				m_repeatTimer.Init(0);
			}
			else
			{
				m_scrollView.content.anchoredPosition = new Vector2(m_scrollView.content.anchoredPosition.x, 0);
				m_scrollView.content.offsetMin = new Vector2(20, m_scrollView.content.offsetMin.y);
				m_scrollView.horizontal = m_list.Count > 1;
				m_scrollView.vertical = false;
				m_scrollView.horizontalNormalizedPosition = 1;
				m_scrollView.movementType = ScrollRect.MovementType.Unrestricted;
				m_imageScroll.enabled = false;
				m_rootPageNum.gameObject.SetActive(true);
				if(m_list.Count < 2)
				{
					m_repeatTimer.Init(0);
					m_buttonOpenClose.gameObject.SetActive(false);
				}
				else
				{
					StartAutoScroll();
					m_buttonOpenClose.gameObject.SetActive(true);
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73D6FC Offset: 0x73D6FC VA: 0x73D6FC
		// // RVA: 0xEAE560 Offset: 0xEAE560 VA: 0xEAE560
		public IEnumerator Co_TryInstallBanner(List<JBCAHMMCOKK> list)
		{
			//0xEAFD58
			if(list == null)
				list = m_list;
			StringBuilder str = new StringBuilder(32);
			bool b = false;
			for(int i = 0; i < list.Count; i++)
			{
				if(list[i].NNHHNFFLCFO >= JBCAHMMCOKK.ALEKHDPDOEA.KCOEIKAMLBD)
				{
					str.SetFormat("ct/ba/hm/{0:D3}.xab", list[i].EAHPLCJMPHD);
				}
				else if(((1 << ((int)list[i].NNHHNFFLCFO & 0xff)) & 0x4030e10U) != 0)
				{
					str.SetFormat("ct/ev/hm/{0:D4}.xab", list[i].EAHPLCJMPHD);
				}
				else if (((1 << ((int)list[i].NNHHNFFLCFO & 0xff)) & 0x81c0060U) != 0)
				{
					str.SetFormat("ct/gc/hm/{0:D5}.xab", list[i].EAHPLCJMPHD);
				}
				else if (((1 << ((int)list[i].NNHHNFFLCFO & 0xff)) & 0xc00000U) != 0)
				{
					str.SetFormat("ct/ba/hm/{0:D3}.xab", list[i].EAHPLCJMPHD);
				}
				else
				{
					str.SetFormat("ct/bn/hm/{0:D5}.xab", list[i].EAHPLCJMPHD);
				}
				if(!KDLPEDBKMID.HHCJCDFCLOB.EGIFDIFALKK(str.ToString()))
				{
					Debug.Log("install cancelled : " + str.ToString());
				}
				else
				{
					if(KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(str.ToString()))
					{
						Debug.Log("install request : " + str.ToString());
						b = true;
					}
				}
			}
			if(!b)
				yield break;
			Debug.Log("install start");
			while (KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			Debug.Log("install end");
		}

		// // RVA: 0xEAE628 Offset: 0xEAE628 VA: 0xEAE628
		// private void LoadBanner(int pictId, Action<IiconTexture> onLoaded) { }

		// // RVA: 0xEAE83C Offset: 0xEAE83C VA: 0xEAE83C
		// public void SetActive(bool active) { }

		// // RVA: 0xEAE914 Offset: 0xEAE914 VA: 0xEAE914
		public void Enter()
		{
			if(m_scrollView.ScrollObjects.Count < 1)
				return;
			m_inOutAnime.Enter(false, null);
		}

		// // RVA: 0xEAE9DC Offset: 0xEAE9DC VA: 0xEAE9DC
		// public void Enter(float animTime) { }

		// // RVA: 0xEAEAB8 Offset: 0xEAEAB8 VA: 0xEAEAB8
		// public void Leave() { }

		// // RVA: 0xEAEAEC Offset: 0xEAEAEC VA: 0xEAEAEC
		// public void Leave(float animTime) { }

		// // RVA: 0xEAEB34 Offset: 0xEAEB34 VA: 0xEAEB34
		public bool IsPlaying()
		{
			return m_inOutAnime.IsPlaying();
		}
	}
}
