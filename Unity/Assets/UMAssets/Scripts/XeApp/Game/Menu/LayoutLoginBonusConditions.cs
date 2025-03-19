using XeSys.Gfx;
using System;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using System.Collections;
using mcrs;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutLoginBonusConditions : LayoutUGUIScriptBase
	{
		[Serializable]
		public class LoginBonusPrizeObject
		{
			[SerializeField]
			public RawImageEx iconL; // 0x8
			[SerializeField]
			public RawImageEx iconS; // 0xC
			[SerializeField]
			public NumberBase itemNumS; // 0x10
			[SerializeField]
			public NumberBase itemNumL; // 0x14
			[SerializeField]
			public NumberBase ucL; // 0x18
			[SerializeField]
			public NumberBase ucS; // 0x1C
			[SerializeField]
			public NumberBase day; // 0x20

			public AbsoluteLayout iconLayout { get; set; } // 0x24
			public AbsoluteLayout stampAnim { get; set; } // 0x28
			public AbsoluteLayout frameLPlaying { get; set; } // 0x2C
			public AbsoluteLayout frameSPlaying { get; set; } // 0x30
			public bool isLoadingIconL { get; set; } // 0x34
			public bool isLoadingIconS { get; set; } // 0x35
		}

		public enum eIconLayoutType
		{
			Normal = 0,
			Big = 1,
		}

		public enum eNextType
		{
			None = 0,
			Next = 1,
		}

		public enum eStampStatus
		{
			None = 0,
			Play = 1,
			Press = 2,
			Loop = 3,
		}

		public enum eUnitPrice
		{
			Num = 0,
			Uc = 1,
		}

		public enum eIconFrameAnim
		{
			None = 0,
			Wait = 1,
			InToLoop = 2,
			Loop = 3,
			In = 4,
			Out = 5,
		}

		private const int ICON_NUM = 14;
		[SerializeField]
		private LoginBonusPrizeObject[] m_prizeObject = new LoginBonusPrizeObject[14]; // 0x14
		[SerializeField]
		private ActionButton m_okButton; // 0x18
		private EPLAAEHPCDM m_rewardData; // 0x1C
		private ItemPackImageTextureCache m_itemPackTextureCache; // 0x20
		private AbsoluteLayout m_root; // 0x24
		private LayoutUGUIRuntime m_runtime; // 0x28
		private bool m_isOpen; // 0x2C
		private bool m_isClosed; // 0x2D
		private bool m_isSkip; // 0x2E
		private bool m_isPlayStampSe; // 0x2F
		private int m_stampPlayDay; // 0x30
		private List<IEnumerator> m_animationList = new List<IEnumerator>(); // 0x34
		private IEnumerator m_animItemIconL; // 0x38
		private IEnumerator m_animItemIconS; // 0x3C
		private bool m_isCheckItemPack; // 0x40

		// RVA: 0x1D55720 Offset: 0x1D55720 VA: 0x1D55720
		public bool IsReady()
		{
			if(m_runtime != null)
			{
				return m_runtime.IsReady && IsLoaded();
			}
			return false;
		}

		// RVA: 0x1D557F0 Offset: 0x1D557F0 VA: 0x1D557F0
		public void SetButtonCallbackOk(Action callback)
		{
			if(m_okButton != null && callback != null)
			{
				m_okButton.ClearOnClickCallback();
				m_okButton.AddOnClickCallback(() =>
				{
					//0x1D597C8
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
					if (!m_isSkip)
						return;
					callback();
					LayoutUGUIUtility.SetImageRaycastTarget(m_okButton.gameObject, false);
				});
			}
		}

		// RVA: 0x1D55968 Offset: 0x1D55968 VA: 0x1D55968
		public bool IsClosed()
		{
			return m_isClosed;
		}

		// RVA: 0x1D55970 Offset: 0x1D55970 VA: 0x1D55970
		public void SetStatus(EPLAAEHPCDM data, IKIIAFKHDFP manager, ItemPackImageTextureCache textureCache)
		{
			m_rewardData = data;
			m_itemPackTextureCache = textureCache;
			int a1 = 0;
			int a2 = 0;
			if(manager.GAOEDFGMHFD != null)
			{
				GMHKBJLIILI g = manager.GAOEDFGMHFD.Find((GMHKBJLIILI _) =>
				{
					//0x1D59914
					return data.BPEAIOBHMFD_NameForApis == _.BPEAIOBHMFD_NameForApis;
				});
				if(g != null)
				{
					if (g.HMFFHLPNMPH_Count > 0)
						a1 = g.HMFFHLPNMPH_Count - 1;
				}
			}
			ResetRewardData();
			int idx2 = 0;
			for(int i = 0; i < 14 && i < data.JPILDOGJLDG_LoginBonusPrizes.Count; i++)
			{
				if(data.JPILDOGJLDG_LoginBonusPrizes[i].HBHMAKNGKFK_Items != null)
				{
					if(data.JPILDOGJLDG_LoginBonusPrizes[i].HBHMAKNGKFK_Items.Count > 0)
					{
						m_prizeObject[i].iconLayout.enabled = true;
						if (i < a1)
							SwitchStampAnim(i, eStampStatus.Press);
						a2++;
						if(data.JPILDOGJLDG_LoginBonusPrizes[i].HBHMAKNGKFK_Items[0] == null)
						{
							m_prizeObject[i].iconLayout.enabled = false;
						}
						else
						{
							if(data.JPILDOGJLDG_LoginBonusPrizes[i].HBHMAKNGKFK_Items.Count < 2)
							{
								SetItemIconS(idx2, data.JPILDOGJLDG_LoginBonusPrizes[i].HBHMAKNGKFK_Items[0].JJBGOIMEIPF_ItemId);
								SetItemIconL(idx2, data.JPILDOGJLDG_LoginBonusPrizes[i].HBHMAKNGKFK_Items[0].JJBGOIMEIPF_ItemId);
								SwitchUnitPrice(idx2, data.JPILDOGJLDG_LoginBonusPrizes[i].HBHMAKNGKFK_Items[0].NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit ? eUnitPrice.Uc : eUnitPrice.Num);
								SetNumItem(idx2, data.JPILDOGJLDG_LoginBonusPrizes[i].HBHMAKNGKFK_Items[0].MBJIFDBEDAC_Cnt);
							}
							else
							{
								SetItemPackIconS(idx2, ItemPackImageTextureCache.Type.Pack1);
								SetItemPackIconL(idx2, ItemPackImageTextureCache.Type.Pack1);
								SwitchUnitPrice(idx2, 0);
								SetNumItem(idx2, 1);
							}
							SwitchDay(idx2, i + 1);
							SwitchItemFrameAnim(i, eIconLayoutType.Normal, eIconFrameAnim.Wait);
							idx2++;
						}
					}
				}
			}
			SwitchDayIconTbl(a2);
			m_stampPlayDay = a1;
			SwitchIcon(m_stampPlayDay + 1, eIconLayoutType.Big);
			SwitchNext(m_stampPlayDay + 1, eNextType.Next);
		}

		// RVA: 0x1D57C50 Offset: 0x1D57C50 VA: 0x1D57C50
		public bool IsLoading()
		{
			for(int i = 0; i < 14; i++)
			{
				if (m_prizeObject[i].isLoadingIconL)
					return true;
				if (m_prizeObject[i].isLoadingIconS)
					return true;
			}
			return false;
		}

		//// RVA: 0x1D57D30 Offset: 0x1D57D30 VA: 0x1D57D30
		private bool IsIconLayoutArrayRange(int arrayIndex)
		{
			if(arrayIndex < 14 && m_prizeObject != null)
			{
				return m_prizeObject[arrayIndex] != null;
			}
			return false;
		}

		//// RVA: 0x1D57D88 Offset: 0x1D57D88 VA: 0x1D57D88
		private void SetButtonVisibleEnable(bool enable)
		{
			if (m_okButton != null)
				m_okButton.Hidden = !enable;
		}

		//// RVA: 0x1D57490 Offset: 0x1D57490 VA: 0x1D57490
		public void SwitchDay(int arrayIndex, int day)
		{
			if(arrayIndex > -1 && day > -1)
			{
				if(arrayIndex < m_prizeObject.Length)
				{
					if(m_prizeObject[arrayIndex].day != null)
					{
						m_prizeObject[arrayIndex].day.SetNumber(day, 0);
					}
				}
			}
		}

		//// RVA: 0x1D578E8 Offset: 0x1D578E8 VA: 0x1D578E8
		public void SwitchIcon(int arrayIndex, eIconLayoutType type)
		{
			if(IsIconLayoutArrayRange(arrayIndex))
			{
				if(m_prizeObject[arrayIndex].iconLayout != null)
				{
					if(type == eIconLayoutType.Big)
					{
						m_prizeObject[arrayIndex].iconLayout.StartAllAnimGoStop("icon_01");
					}
					else if(type == eIconLayoutType.Normal)
					{
						m_prizeObject[arrayIndex].iconLayout.StartAllAnimGoStop("icon_00");
					}
				}
			}
		}

		//// RVA: 0x1D569E0 Offset: 0x1D569E0 VA: 0x1D569E0
		public void SwitchUnitPrice(int arrayIndex, eUnitPrice type)
		{
			if(IsIconLayoutArrayRange(arrayIndex))
			{
				if(m_prizeObject[arrayIndex].iconLayout != null)
				{
					if(type == eUnitPrice.Uc)
					{
						m_prizeObject[arrayIndex].iconLayout.StartAllAnimGoStop("itemcount_00");
					}
					else if(type == eUnitPrice.Num)
					{
						m_prizeObject[arrayIndex].iconLayout.StartAllAnimGoStop("itemcount_01");
					}
				}
			}
		}

		//// RVA: 0x1D57A9C Offset: 0x1D57A9C VA: 0x1D57A9C
		public void SwitchNext(int arrayIndex, eNextType type)
		{
			if(IsIconLayoutArrayRange(arrayIndex))
			{
				if(m_prizeObject[arrayIndex].iconLayout != null)
				{
					if(type == eNextType.Next)
					{
						m_prizeObject[arrayIndex].iconLayout.StartAllAnimGoStop("next_00");
					}
					else if(type == eNextType.None)
					{
						m_prizeObject[arrayIndex].iconLayout.StartAllAnimGoStop("next_01");
					}
				}
			}
		}

		//// RVA: 0x1D57814 Offset: 0x1D57814 VA: 0x1D57814
		public void SwitchDayIconTbl(int day)
		{
			if(m_root != null)
			{
				if (day < 6)
					day = 5;
				if (day > 13)
					day = 14;
				m_root.StartAllAnimGoStop(string.Format("period_login_{0:d2}", day));
			}
		}

		//// RVA: 0x1D5624C Offset: 0x1D5624C VA: 0x1D5624C
		public void SwitchStampAnim(int arrayIndex, eStampStatus status)
		{
			if(IsIconLayoutArrayRange(arrayIndex))
			{
				if(m_prizeObject[arrayIndex].iconLayout != null &&
					m_prizeObject[arrayIndex].stampAnim != null)
				{
					switch(status)
					{
						case eStampStatus.None:
							m_prizeObject[arrayIndex].iconLayout.StartAllAnimGoStop("st_wait_stamp");
							m_prizeObject[arrayIndex].stampAnim.StartAllAnimGoStop("st_wait_stamp");
							break;
						case eStampStatus.Play:
							m_prizeObject[arrayIndex].stampAnim.StartAllAnimGoStop("go_in_stamp", "st_in_stamp");
							m_animationList.Add(WaitStampAnim(arrayIndex));
							SwitchItemFrameAnim(arrayIndex, eIconLayoutType.Normal, eIconFrameAnim.In);
							break;
						case eStampStatus.Press:
							m_prizeObject[arrayIndex].iconLayout.StartAllAnimGoStop("st_press_stamp");
							break;
						case eStampStatus.Loop:
							m_prizeObject[arrayIndex].stampAnim.StartAllAnimLoop("logo_act_01", "loen_act_01");
							break;
					}
				}
			}
		}

		//// RVA: 0x1D56828 Offset: 0x1D56828 VA: 0x1D56828
		public void SetItemPackIconL(int arrayIndex, ItemPackImageTextureCache.Type type)
		{
			m_prizeObject[arrayIndex].isLoadingIconL = true;
			m_itemPackTextureCache.Load(type, (IiconTexture texture) =>
			{
				//0x1D59974
				if (texture != null && texture is ItemPackImageTextureCache.ItemPackImageTexture)
					(texture as ItemPackImageTextureCache.ItemPackImageTexture).Set(m_prizeObject[arrayIndex].iconL, type);
				m_prizeObject[arrayIndex].isLoadingIconL = false;
			});
		}

		//// RVA: 0x1D56670 Offset: 0x1D56670 VA: 0x1D56670
		public void SetItemPackIconS(int arrayIndex, ItemPackImageTextureCache.Type type)
		{
			m_prizeObject[arrayIndex].isLoadingIconS = true;
			m_itemPackTextureCache.Load(type, (IiconTexture texture) =>
			{
				//0x1D59A80
				if (texture != null && texture is ItemPackImageTextureCache.ItemPackImageTexture)
					(texture as ItemPackImageTextureCache.ItemPackImageTexture).Set(m_prizeObject[arrayIndex].iconS, type);
				m_prizeObject[arrayIndex].isLoadingIconS = false;
			});
		}

		//// RVA: 0x1D5724C Offset: 0x1D5724C VA: 0x1D5724C
		public void SetItemIconL(int arrayIndex, int itemId)
		{
			m_prizeObject[arrayIndex].iconL.uvRect = new Rect(0, 0, 1, 1);
			m_prizeObject[arrayIndex].isLoadingIconL = true;
			GameManager.Instance.ItemTextureCache.Load(itemId, (IiconTexture texture) =>
			{
				//0x1D59B8C
				texture.Set(m_prizeObject[arrayIndex].iconL);
				m_prizeObject[arrayIndex].isLoadingIconL = false;
			});
		}

		//// RVA: 0x1D57008 Offset: 0x1D57008 VA: 0x1D57008
		public void SetItemIconS(int arrayIndex, int itemId)
		{
			m_prizeObject[arrayIndex].iconS.uvRect = new Rect(0, 0, 1, 1);
			m_prizeObject[arrayIndex].isLoadingIconS = true;
			GameManager.Instance.ItemTextureCache.Load(itemId, (IiconTexture texture) =>
			{
				//0x1D59CCC
				texture.Set(m_prizeObject[arrayIndex].iconS);
				m_prizeObject[arrayIndex].isLoadingIconS = false;
			});
		}

		//// RVA: 0x1D56B94 Offset: 0x1D56B94 VA: 0x1D56B94
		public void SetNumItem(int arrayIndex, int num)
		{
			if(m_prizeObject[arrayIndex].itemNumL != null)
				m_prizeObject[arrayIndex].itemNumL.SetNumber(num, 0);
			if (m_prizeObject[arrayIndex].itemNumS != null)
				m_prizeObject[arrayIndex].itemNumS.SetNumber(num, 0);
			if (m_prizeObject[arrayIndex].ucL != null)
				m_prizeObject[arrayIndex].ucL.SetNumber(num, 0);
			if (m_prizeObject[arrayIndex].ucS != null)
				m_prizeObject[arrayIndex].ucS.SetNumber(num, 0);
		}

		//// RVA: 0x1D5761C Offset: 0x1D5761C VA: 0x1D5761C
		public void SwitchItemFrameAnim(int arrayIndex, eIconLayoutType layoutType, eIconFrameAnim type)
		{
			if (!IsIconLayoutArrayRange(arrayIndex))
				return;
			if (m_prizeObject[arrayIndex].iconLayout == null)
				return;
			switch(type)
			{
				case eIconFrameAnim.Wait:
					m_prizeObject[arrayIndex].iconLayout.StartAllAnimGoStop("st_wait", "st_wait");
					break;
				case eIconFrameAnim.InToLoop:
					m_prizeObject[arrayIndex].iconLayout.StartAllAnimGoStop("go_in", "st_in");
					if (layoutType == eIconLayoutType.Normal)
						m_animItemIconS = WaitItemFrameAnim(layoutType, arrayIndex, true);
					else
						m_animItemIconL = WaitItemFrameAnim(layoutType, arrayIndex, true);
					break;
				case eIconFrameAnim.Loop:
					m_prizeObject[arrayIndex].iconLayout.StartAllAnimLoop("logo_up", "loen_up");
					break;
				case eIconFrameAnim.In:
					m_prizeObject[arrayIndex].iconLayout.StartAllAnimGoStop("go_in", "st_in");
					if (layoutType == eIconLayoutType.Normal)
						m_animItemIconS = WaitItemFrameAnim(layoutType, arrayIndex, false);
					else
						m_animItemIconL = WaitItemFrameAnim(layoutType, arrayIndex, false);
					break;
				case eIconFrameAnim.Out:
					m_prizeObject[arrayIndex].iconLayout.StartAllAnimGoStop("go_out", "st_out");
					break;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6EBB0C Offset: 0x6EBB0C VA: 0x6EBB0C
		//// RVA: 0x1D57F54 Offset: 0x1D57F54 VA: 0x1D57F54
		private IEnumerator WaitItemFrameAnim(eIconLayoutType layoutType, int arrayIndex, bool isLoop)
		{
			AbsoluteLayout layout;

			//0x1D5A340
			if (!IsIconLayoutArrayRange(arrayIndex))
				yield break;
			layout = layoutType == eIconLayoutType.Big ? m_prizeObject[arrayIndex].frameLPlaying : m_prizeObject[arrayIndex].frameSPlaying;
			if (layout == null)
				yield break;
			while (layout.IsPlayingChildren())
				yield return null;
			if (isLoop)
				SwitchItemFrameAnim(arrayIndex, layoutType, eIconFrameAnim.Loop);
		}

		//// RVA: 0x1D57F24 Offset: 0x1D57F24 VA: 0x1D57F24
		//private void SetAnimationIconFrame(LayoutLoginBonusConditions.eIconLayoutType layoutType, int arrayIndex, bool isLoop) { }

		//// RVA: 0x1D5804C Offset: 0x1D5804C VA: 0x1D5804C
		//private void ResetAnimationIconFrame() { }

		//// RVA: 0x1D5805C Offset: 0x1D5805C VA: 0x1D5805C
		public void Skip()
		{
			if(m_isOpen && !m_isSkip)
			{
				if (InputManager.Instance.GetInScreenTouchCount() < 1)
					return;
				if(InputManager.Instance.IsScreenTouch())
				{
					m_isSkip = true;
					this.StartCoroutineWatched(SkipAnim());
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6EBB84 Offset: 0x6EBB84 VA: 0x6EBB84
		//// RVA: 0x1D581B8 Offset: 0x1D581B8 VA: 0x1D581B8
		private IEnumerator SkipAnim()
		{
			//0x1D59E24
			m_root.StartChildrenAnimGoStop("st_in", "st_in");
			SetButtonVisibleEnable(true);
			SwitchStampAnim(m_stampPlayDay, eStampStatus.Loop);
			m_animItemIconL = null;
			m_animItemIconS = null;
			m_animationList.Clear();
			SwitchItemFrameAnim(m_stampPlayDay, eIconLayoutType.Normal, eIconFrameAnim.Wait);
			SwitchItemFrameAnim(m_stampPlayDay + 1, eIconLayoutType.Big, eIconFrameAnim.Loop);
			if(!m_isPlayStampSe)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_LOGIN_000);
				m_isPlayStampSe = true;
			}
			if(m_rewardData.JPILDOGJLDG_LoginBonusPrizes[m_stampPlayDay].HBHMAKNGKFK_Items.Count > 1 && !m_isCheckItemPack)
			{
				OpenItemPackPopup(m_rewardData.JPILDOGJLDG_LoginBonusPrizes[m_stampPlayDay], () =>
				{
					//0x1D59708
					m_isCheckItemPack = true;
				});
				yield return new WaitWhile(() =>
				{
					//0x1D59714
					return !m_isCheckItemPack;
				});
			}
		}

		// RVA: 0x1D58264 Offset: 0x1D58264 VA: 0x1D58264
		public void Update()
		{
			if (!IsReady())
				return;
			Skip();
			if(m_animationList.Count > 0)
			{
				if (!m_animationList[0].MoveNext())
					m_animationList.RemoveAt(0);
			}
			if(m_animItemIconL != null)
			{
				if (!m_animItemIconL.MoveNext())
					m_animItemIconL = null;
			}
			if(m_animItemIconS != null)
			{
				if (!m_animItemIconS.MoveNext())
					m_animItemIconS = null;
			}
		}

		// RVA: 0x1D58510 Offset: 0x1D58510 VA: 0x1D58510
		public void Show()
		{
			if (m_root == null)
				return;
			if (m_isOpen)
				return;
			m_isOpen = true;
			m_isClosed = false;
			gameObject.SetActive(true);
			SetButtonVisibleEnable(false);
			m_root.StartChildrenAnimGoStop("go_in", "st_in");
			m_animationList.Clear();
			m_animationList.Add(WaitOpenAnim());
		}

		// RVA: 0x1D586F0 Offset: 0x1D586F0 VA: 0x1D586F0
		public void Hide()
		{
			if (!m_isOpen)
				return;
			m_isOpen = false;
			m_root.StartChildrenAnimGoStop("go_out", "st_out");
			m_animationList.Clear();
			m_animationList.Add(WaitCloseAnim());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6EBBFC Offset: 0x6EBBFC VA: 0x6EBBFC
		//// RVA: 0x1D58664 Offset: 0x1D58664 VA: 0x1D58664
		private IEnumerator WaitOpenAnim()
		{
			//0x1D5A554
			yield return null;
			while(m_root.IsPlayingChildren())
				yield return null;
			SwitchStampAnim(m_stampPlayDay, eStampStatus.Play);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6EBC74 Offset: 0x6EBC74 VA: 0x6EBC74
		//// RVA: 0x1D587F8 Offset: 0x1D587F8 VA: 0x1D587F8
		private IEnumerator WaitCloseAnim()
		{
			//0x1D5A1C8
			yield return null;
			while(m_root.IsPlayingChildren())
				yield return null;
			m_isClosed = true;
			gameObject.SetActive(false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6EBCEC Offset: 0x6EBCEC VA: 0x6EBCEC
		//// RVA: 0x1D57E4C Offset: 0x1D57E4C VA: 0x1D57E4C
		private IEnumerator WaitStampAnim(int arrayIndex)
		{
			AbsoluteLayout layout;

			//0x1D5A6A4
			if (!IsIconLayoutArrayRange(arrayIndex))
				yield break;
			if (m_prizeObject[arrayIndex].stampAnim == null)
				yield break;
			layout = m_prizeObject[arrayIndex].stampAnim;
			while (layout.GetView(0).FrameAnimation.FrameCount < layout.GetView(0).FrameAnimation.SearchLabelFrame("stamp_se"))
				yield return null;
			if(!m_isPlayStampSe && !m_isSkip)
			{
				m_isPlayStampSe = true;
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_LOGIN_000);
			}
			while (layout.IsPlayingChildren())
				yield return null;
			if(m_rewardData.JPILDOGJLDG_LoginBonusPrizes[m_stampPlayDay].HBHMAKNGKFK_Items.Count > 1)
			{
				OpenItemPackPopup(m_rewardData.JPILDOGJLDG_LoginBonusPrizes[m_stampPlayDay], () =>
				{
					//0x1D59728
					m_isCheckItemPack = true;
				});
				yield return new WaitWhile(() =>
				{
					//0x1D59734
					return !m_isCheckItemPack;
				});
			}
			m_isSkip = true;
			m_animItemIconL = null;
			m_animItemIconS = null;
			SwitchItemFrameAnim(arrayIndex, eIconLayoutType.Normal, eIconFrameAnim.Out);
			SwitchItemFrameAnim(arrayIndex + 1, eIconLayoutType.Big, eIconFrameAnim.InToLoop);
			SetButtonVisibleEnable(true);
			SwitchStampAnim(arrayIndex, eStampStatus.Loop);
		}

		//// RVA: 0x1D588E4 Offset: 0x1D588E4 VA: 0x1D588E4
		private void OpenItemPackPopup(CAEDGOPBDNK data, Action callback)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			string str = bk.GetMessageByLabel(string.Format(m_rewardData.BPEAIOBHMFD_NameForApis + "_{0:00}", m_stampPlayDay + 1));
			if(str.Contains("!not exist"))
				str = bk.GetMessageByLabel("popup_loginbonus_comeback_pack_001");
			PopupLoginBonusPackSetting s = new PopupLoginBonusPackSetting();
			s.TitleText = str;
			s.WindowSize = SizeType.Middle;
			s.Data = data;
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1D597C4
				return;
			}, null, null, null, endCallBaack:() =>
			{
				//0x1D59E0C
				if(callback != null)
					callback();
			});
		}

		//// RVA: 0x1D58D8C Offset: 0x1D58D8C VA: 0x1D58D8C
		//public bool IsPlayingAnim() { }

		// RVA: 0x1D58DA4 Offset: 0x1D58DA4 VA: 0x1D58DA4
		public void Reset()
		{
			m_stampPlayDay = 0;
			m_isSkip = false;
			m_isPlayStampSe = false;
			if(m_okButton != null)
			{
				LayoutUGUIUtility.SetImageRaycastTarget(m_okButton.gameObject, true);
			}
			ResetRewardData();
		}

		//// RVA: 0x1D56040 Offset: 0x1D56040 VA: 0x1D56040
		private void ResetRewardData()
		{
			for(int i = 0; i < 14; i++)
			{
				SwitchStampAnim(i, eStampStatus.None);
				SwitchUnitPrice(i, 0);
				SwitchIcon(i, eIconLayoutType.Normal);
				SwitchNext(i, eNextType.None);
				if(m_prizeObject[i] != null)
				{
					if(m_prizeObject[i].iconLayout != null)
					{
						m_prizeObject[i].iconLayout.enabled = false;
					}
					m_prizeObject[i].isLoadingIconS = false;
					m_prizeObject[i].isLoadingIconL = false;
				}
			}
		}

		//// RVA: 0x1D58EAC Offset: 0x1D58EAC VA: 0x1D58EAC
		//private void DeleteImage(ref RawImageEx image) { }

		// RVA: 0x1D58FFC Offset: 0x1D58FFC VA: 0x1D58FFC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			m_runtime = gameObject.GetComponent<LayoutUGUIRuntime>();
			m_root.StartAllAnimGoStop("st_wait");
			for(int i = 0; i < 14; i++)
			{
				m_prizeObject[i].iconLayout = layout.FindViewByExId(string.Format("swtbl_login_window_02_all_sw_icon_s_02_period_{0}dey", i + 1)) as AbsoluteLayout;
				if(m_prizeObject[i].iconLayout != null)
				{
					m_prizeObject[i].frameLPlaying = m_prizeObject[i].iconLayout.FindViewByExId("swtbl_login_icon_2_sw_next_icon_anim") as AbsoluteLayout;
					m_prizeObject[i].frameSPlaying = m_prizeObject[i].iconLayout.FindViewByExId("sw_icon_s_02_sw_icon_s_ef_loop_2_anim") as AbsoluteLayout;
				}
				m_prizeObject[i].stampAnim = layout.FindViewByExId(string.Format("swtbl_login_window_02_all_sw_icon_s_02_get_{0}dey", i + 1)) as AbsoluteLayout;
			}
			Reset();
			Loaded();
			return true;
		}
	}
}
