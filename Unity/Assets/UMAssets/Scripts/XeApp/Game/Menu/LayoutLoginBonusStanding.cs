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
	public class LayoutLoginBonusStanding : LayoutUGUIScriptBase
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

			public AbsoluteLayout iconLayout { get; set; } // 0x20
			public AbsoluteLayout stampAnim { get; set; } // 0x24
			public AbsoluteLayout frameLPlaying { get; set; } // 0x28
			public AbsoluteLayout frameSPlaying { get; set; } // 0x2C
			public bool isLoadingIconL { get; set; } // 0x30
			public bool isLoadingIconS { get; set; } // 0x31
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

		public enum eType
		{
			None = 0,
			Standing = 1,
			Succession = 2,
			Comeback = 3,
			ComebackSp = 4,
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

		private const int ICON_NUM = 10;
		private const int REWARD_NUM = 7;
		[SerializeField]
		private NumberBase[] m_day = new NumberBase[10]; // 0x14
		[SerializeField]
		private LoginBonusPrizeObject[] m_prizeObject = new LoginBonusPrizeObject[10]; // 0x18
		[SerializeField]
		private ActionButton m_okButton; // 0x1C
		private AbsoluteLayout m_root; // 0x20
		private AbsoluteLayout[] m_dayLayout = new AbsoluteLayout[10]; // 0x24
		private AbsoluteLayout m_titleStandingAnim; // 0x28
		private AbsoluteLayout m_titleSuccessionAnim; // 0x2C
		private AbsoluteLayout m_titleComebackAnim; // 0x30
		private AbsoluteLayout m_titleComebackSpAnim; // 0x34
		private AbsoluteLayout m_iconsAnim; // 0x38
		private LayoutUGUIRuntime m_runtime; // 0x3C
		private bool m_isOpen; // 0x40
		private bool m_isClosed; // 0x41
		private bool m_isSkip; // 0x42
		private bool m_isPlayStampSe; // 0x43
		private bool m_skipEnd; // 0x44
		private eType m_type = eType.Standing; // 0x48
		private int m_stampPlayDay; // 0x4C
		private bool m_isNextReward; // 0x50
		private Action m_prevStampPlayCallback; // 0x54
		private EPLAAEHPCDM m_rewardData; // 0x58
		private ItemPackImageTextureCache m_itemPackTextureCache; // 0x5C
		private List<IEnumerator> m_animationList = new List<IEnumerator>(); // 0x60
		private IEnumerator m_animItemIconL; // 0x64
		private IEnumerator m_animItemIconS; // 0x68
		private bool m_isCheckItemPack; // 0x6C
		private RectTransform m_rectPrizeLayout; // 0x74
		private int m_prevIndex; // 0x78

		public Func<bool> OnWaitDivaVoice { get; set; } // 0x70

		// RVA: 0x1D5FF20 Offset: 0x1D5FF20 VA: 0x1D5FF20
		public bool IsReady()
		{
			if(m_runtime != null)
			{
				if(m_runtime.IsReady)
					return IsLoaded();
			}
			return false;
		}

		// RVA: 0x1D5FFF0 Offset: 0x1D5FFF0 VA: 0x1D5FFF0
		public bool IsClosed()
		{
			return m_isClosed;
		}

		// RVA: 0x1D5FFF8 Offset: 0x1D5FFF8 VA: 0x1D5FFF8
		public void SetButtonCallbackOk(Action callback)
		{
			if(m_okButton != null)
			{
				if(callback != null)
				{
					m_okButton.ClearOnClickCallback();
					m_okButton.AddOnClickCallback(() =>
					{
						//0x1D647D4
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
						if(!m_isSkip || !m_skipEnd)
							return;
						callback();
						LayoutUGUIUtility.SetImageRaycastTarget(m_okButton.gameObject, false);
					});
				}
			}
		}

		// // RVA: 0x1D60170 Offset: 0x1D60170 VA: 0x1D60170
		// private bool IsCallback() { }

		// RVA: 0x1D60184 Offset: 0x1D60184 VA: 0x1D60184
		public void SetPreStampPlayCallback(Action callback)
		{
			m_prevStampPlayCallback = callback;
		}

		// RVA: 0x1D6018C Offset: 0x1D6018C VA: 0x1D6018C
		public void SetStatus(EPLAAEHPCDM data, IKIIAFKHDFP manager, ItemPackImageTextureCache textureCache)
		{
			m_rewardData = data;
			m_itemPackTextureCache = textureCache;
			m_type = (eType)data.CKHOBDIKJFN_Type;
			SwitchType(m_type);
			List<GMHKBJLIILI> l = manager.GAOEDFGMHFD;
			int a1 = 0;
			if(l != null)
			{
				GMHKBJLIILI d = l.Find((GMHKBJLIILI _) =>
				{
					//0x1D6492C
					return _.BPEAIOBHMFD_NameForApis == data.BPEAIOBHMFD_NameForApis;
				});
				if(d != null && d.HMFFHLPNMPH_Count > 0)
				{
					a1 = d.HMFFHLPNMPH_Count - 1;
				}
				if(data.CKHOBDIKJFN_Type == ANPGILOLNFK.CDOGFBNLIPG.PHABJLGFJNI_1)
				{
					a1 = data.MGANCKPFONE;
				}
			}
			SetStatusInner(data, a1, false);
			m_isNextReward = false;
			m_stampPlayDay = a1;
			if(data.CKHOBDIKJFN_Type == ANPGILOLNFK.CDOGFBNLIPG.PHABJLGFJNI_1)
			{
				if(data.JPILDOGJLDG_LoginBonusPrizes.Count >= 8)
				{
					m_isNextReward = m_stampPlayDay == 6;
				}
			}
			if(!m_isNextReward)
			{
				SwitchIcon(m_stampPlayDay + 1, eIconLayoutType.Big);
				SwitchNext(m_stampPlayDay + 1, eNextType.Next);
			}
		}

		// RVA: 0x1D60F98 Offset: 0x1D60F98 VA: 0x1D60F98
		public bool IsLoading()
		{
			for(int i = 0; i < 10; i++)
			{
				if(m_prizeObject[i].isLoadingIconS)
					return true;
				if(m_prizeObject[i].isLoadingIconL)
					return true;
			}
			return false;
		}

		// // RVA: 0x1D60690 Offset: 0x1D60690 VA: 0x1D60690
		private void SetStatusInner(EPLAAEHPCDM data, int currentReciveCount, bool isNext)
		{
			int a1 = 7;
			if(data.CKHOBDIKJFN_Type != ANPGILOLNFK.CDOGFBNLIPG.PHABJLGFJNI_1)
			{
				a1 = data.JPILDOGJLDG_LoginBonusPrizes.Count;
			}
			int idx = 0;
			if(isNext)
			{
				a1 = data.JPILDOGJLDG_LoginBonusPrizes.Count;
				idx = 7;
			}
			if(idx < a1)
			{
				int arrayIdx = 0;
				for(int i = 0; i < data.JPILDOGJLDG_LoginBonusPrizes.Count; i++)
				{
                    CAEDGOPBDNK d = data.JPILDOGJLDG_LoginBonusPrizes[i];
                    if(d.HBHMAKNGKFK_Items != null)
					{
						if(d.HBHMAKNGKFK_Items.Count > 0)
						{
							m_prizeObject[arrayIdx].iconLayout.enabled = true;
							SwitchDayEnable(arrayIdx, true);
							if(arrayIdx < currentReciveCount)
							{
								SwitchStampAnim(arrayIdx, eStampStatus.Press);
							}
							if(d.HBHMAKNGKFK_Items.Count < 2)
							{
								SetItemIcon(arrayIdx, d.HBHMAKNGKFK_Items[0].JJBGOIMEIPF_ItemFullId);
								SwitchUnitPrice(arrayIdx, d.HBHMAKNGKFK_Items[0].NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit ? eUnitPrice.Uc : eUnitPrice.Num);
								SetNumItem(arrayIdx, d.HBHMAKNGKFK_Items[0].MBJIFDBEDAC_Cnt);
							}
							else
							{
								if(data.CKHOBDIKJFN_Type >= ANPGILOLNFK.CDOGFBNLIPG.DHGCJEOPEIE_3 && data.CKHOBDIKJFN_Type < ANPGILOLNFK.CDOGFBNLIPG.LAOEGNLOJHC_5)
								{
									int val;
									int.TryParse(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.EFEGBHACJAL("comeback_login_bonus_pack_id", "1,1,1,1,1,1,1,1,1,1").Split(new char[] { ',' })[i], out val);
									SetItemPackIcon(arrayIdx, (ItemPackImageTextureCache.Type)val);
								}
								else
								{
									SetItemPackIcon(arrayIdx, ItemPackImageTextureCache.Type.Pack1);
								}
								SwitchUnitPrice(arrayIdx, eUnitPrice.Num);
								SetNumItem(arrayIdx, 1);
							}
							SwitchDay(arrayIdx, arrayIdx + 1);
							arrayIdx++;
						}
					}
					if(a1 <= i + 1)
						return;
					if(arrayIdx > 9)
						return;
				}
			}
		}

		// // RVA: 0x1D6205C Offset: 0x1D6205C VA: 0x1D6205C
		private bool IsIconLayoutArrayRange(int arrayIndex)
		{
			if(arrayIndex > -1)
			{
				if(arrayIndex < m_prizeObject.Length)
				{
					return m_prizeObject[arrayIndex].iconLayout != null;
				}
			}
			return false;
		}

		// // RVA: 0x1D620F4 Offset: 0x1D620F4 VA: 0x1D620F4
		private void SetButtonVisibleEnable(bool enable)
		{
			if (m_okButton != null)
				m_okButton.Hidden = !enable;
		}

		// // RVA: 0x1D61EF8 Offset: 0x1D61EF8 VA: 0x1D61EF8
		public void SwitchDay(int arrayIndex, int day)
		{
			if(arrayIndex > -1 && day > -1)
			{
				if(arrayIndex < m_day.Length)
				{
					if (m_day[arrayIndex] == null)
						return;
					m_day[arrayIndex].SetNumber(day, 0);
				}
			}
		}

		// // RVA: 0x1D61080 Offset: 0x1D61080 VA: 0x1D61080
		public void SwitchDayEnable(int arrayIndex, bool enable)
		{
			if(arrayIndex > -1)
			{
				if(arrayIndex < m_day.Length)
				{
					if (m_dayLayout[arrayIndex] == null)
						return;
					m_dayLayout[arrayIndex].StartAllAnimGoStop(enable ? "00" : "01");
				}
			}
		}

		// // RVA: 0x1D60CD8 Offset: 0x1D60CD8 VA: 0x1D60CD8
		public void SwitchIcon(int arrayIndex, eIconLayoutType type)
		{
			if (!IsIconLayoutArrayRange(arrayIndex))
				return;
			if(type == eIconLayoutType.Big)
			{
				m_prizeObject[arrayIndex].iconLayout.StartAllAnimGoStop("icon_01");
			}
			else if(type == eIconLayoutType.Normal)
			{
				m_prizeObject[arrayIndex].iconLayout.StartAllAnimGoStop("icon_00");
			}
		}

		// // RVA: 0x1D621B0 Offset: 0x1D621B0 VA: 0x1D621B0
		public void SwitchIconEnable(int arrayIndex, bool enable)
		{
			if (!IsIconLayoutArrayRange(arrayIndex))
				return;
			m_prizeObject[arrayIndex].iconLayout.enabled = enable;
		}

		// // RVA: 0x1D60E38 Offset: 0x1D60E38 VA: 0x1D60E38
		public void SwitchNext(int arrayIndex, eNextType type)
		{
			if (!IsIconLayoutArrayRange(arrayIndex))
				return;
			if(type == eNextType.Next)
			{
				m_prizeObject[arrayIndex].iconLayout.StartAllAnimGoStop("next_00");
			}
			else
			{
				m_prizeObject[arrayIndex].iconLayout.StartAllAnimGoStop("next_01");
			}
		}

		// // RVA: 0x1D617D4 Offset: 0x1D617D4 VA: 0x1D617D4
		public void SwitchUnitPrice(int arrayIndex, eUnitPrice type)
		{
			if (!IsIconLayoutArrayRange(arrayIndex))
				return;
			if(type == eUnitPrice.Uc)
			{
				m_prizeObject[arrayIndex].iconLayout.StartAllAnimGoStop("itemcount_00");
			}
			else if(type == eUnitPrice.Num)
			{
				m_prizeObject[arrayIndex].iconLayout.StartAllAnimGoStop("itemcount_01");
			}
		}

		// // RVA: 0x1D62248 Offset: 0x1D62248 VA: 0x1D62248
		public void SwitchItemFrameAnim(int arrayIndex, eIconLayoutType layoutType, eIconFrameAnim type)
		{
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

		// [IteratorStateMachineAttribute] // RVA: 0x6EC014 Offset: 0x6EC014 VA: 0x6EC014
		// // RVA: 0x1D6245C Offset: 0x1D6245C VA: 0x1D6245C
		private IEnumerator WaitItemFrameAnim(eIconLayoutType layoutType, int arrayIndex, bool isLoop)
		{
			AbsoluteLayout layout;

			//0x1D65944
			yield return null;
			layout = layoutType == eIconLayoutType.Big ? m_prizeObject[arrayIndex].frameLPlaying : m_prizeObject[arrayIndex].frameSPlaying;
			if (layout == null)
				yield break;
			while (layout.IsPlayingChildren())
				yield return null;
			if (isLoop)
				SwitchItemFrameAnim(arrayIndex, layoutType, eIconFrameAnim.Loop);
		}

		// // RVA: 0x1D6242C Offset: 0x1D6242C VA: 0x1D6242C
		// private void SetAnimationIconFrame(LayoutLoginBonusStanding.eIconLayoutType layoutType, int arrayIndex, bool isLoop) { }

		// // RVA: 0x1D62550 Offset: 0x1D62550 VA: 0x1D62550
		// private void ResetAnimationIconFrame() { }

		// // RVA: 0x1D611B8 Offset: 0x1D611B8 VA: 0x1D611B8
		public void SwitchStampAnim(int arrayIndex, eStampStatus status)
		{
			if (!IsIconLayoutArrayRange(arrayIndex))
				return;
			switch(status)
			{
				case eStampStatus.None:
					m_prizeObject[arrayIndex].stampAnim.StartAllAnimGoStop("st_wait_stamp");
					m_prizeObject[arrayIndex].iconLayout.StartAllAnimGoStop("st_wait_stamp");
					break;
				case eStampStatus.Play:
					m_prizeObject[arrayIndex].stampAnim.StartAllAnimGoStop("go_in_stamp", "st_in_stamp");
					m_animationList.Add(WaitStampAnim(arrayIndex));
					break;
				case eStampStatus.Press:
					m_prizeObject[arrayIndex].iconLayout.StartAllAnimGoStop("st_press_stamp");
					break;
				case eStampStatus.Loop:
					m_prizeObject[arrayIndex].stampAnim.StartAllAnimLoop("logo_act_01", "loen_act_01");
					break;
			}
		}

		// // RVA: 0x1D604B8 Offset: 0x1D604B8 VA: 0x1D604B8
		public void SwitchType(eType type)
		{
			switch(type)
			{
				case eType.Standing:
					m_root.StartAllAnimGoStop("title_00");
					m_root.StartAllAnimGoStop("window_00");
					break;
				case eType.Succession:
					m_root.StartAllAnimGoStop("title_01");
					m_root.StartAllAnimGoStop("window_01");
					break;
				case eType.Comeback:
					m_root.StartAllAnimGoStop("title_02");
					m_root.StartAllAnimGoStop("window_02");
					break;
				case eType.ComebackSp:
					m_root.StartAllAnimGoStop("title_03");
					m_root.StartAllAnimGoStop("window_03");
					break;
				default:
					return;
			}
		}

		// // RVA: 0x1D62610 Offset: 0x1D62610 VA: 0x1D62610
		public void SwitchTitleAnim(eType type)
		{
			switch(type)
			{
				case eType.Standing:
					if(m_titleStandingAnim != null)
						m_titleStandingAnim.StartAllAnimLoop("logo_act_01", "loen_act_01");
					break;
				case eType.Succession:
					if(m_titleSuccessionAnim != null)
						m_titleSuccessionAnim.StartAllAnimLoop("logo_act_01", "loen_act_01");
					break;
				case eType.Comeback:
					if(m_titleComebackAnim != null)
						m_titleComebackAnim.StartAllAnimLoop("logo_act_01", "loen_act_01");
					break;
				case eType.ComebackSp:
					if(m_titleComebackSpAnim != null)
						m_titleComebackSpAnim.StartAllAnimLoop("logo_act_01", "loen_act_01");
					break;
			}
		}

		// // RVA: 0x1D61500 Offset: 0x1D61500 VA: 0x1D61500
		public void SetItemPackIcon(int arrayIndex, ItemPackImageTextureCache.Type type)
		{
			m_prizeObject[arrayIndex].isLoadingIconS = true;
			m_itemPackTextureCache.Load(type, (IiconTexture texture) =>
			{
				//0x1D6498C
				if (texture != null && texture is ItemPackImageTextureCache.ItemPackImageTexture)
					((ItemPackImageTextureCache.ItemPackImageTexture)texture).Set(m_prizeObject[arrayIndex].iconS, type);
				m_prizeObject[arrayIndex].isLoadingIconS = false;
			});
			m_prizeObject[arrayIndex].isLoadingIconL = true;
			m_itemPackTextureCache.Load(type, (IiconTexture texture) =>
			{
				//0x1D64A98
				if (texture != null && texture is ItemPackImageTextureCache.ItemPackImageTexture)
					((ItemPackImageTextureCache.ItemPackImageTexture)texture).Set(m_prizeObject[arrayIndex].iconL, type);
				m_prizeObject[arrayIndex].isLoadingIconL = false;
			});
		}

		// // RVA: 0x1D61B2C Offset: 0x1D61B2C VA: 0x1D61B2C
		public void SetItemIcon(int arrayIndex, int itemId)
		{
			m_prizeObject[arrayIndex].iconS.uvRect = new Rect(0, 0, 1, 1);
			m_prizeObject[arrayIndex].isLoadingIconS = true;
			GameManager.Instance.ItemTextureCache.Load(itemId, (IiconTexture texture) =>
			{
				//0x1D64BA4
				if (texture != null)
					texture.Set(m_prizeObject[arrayIndex].iconS);
				m_prizeObject[arrayIndex].isLoadingIconS = false;
			});
			m_prizeObject[arrayIndex].iconL.uvRect = new Rect(0, 0, 1, 1);
			m_prizeObject[arrayIndex].isLoadingIconL = true;
			GameManager.Instance.ItemTextureCache.Load(itemId, (IiconTexture texture) =>
			{
				//0x1D64CE4
				if (texture != null)
					texture.Set(m_prizeObject[arrayIndex].iconL);
				m_prizeObject[arrayIndex].isLoadingIconL = false;
			});
		}

		// // RVA: 0x1D61934 Offset: 0x1D61934 VA: 0x1D61934
		public void SetNumItem(int arrayIndex, int num)
		{
			m_prizeObject[arrayIndex].itemNumL.SetNumber(num, 0);
			m_prizeObject[arrayIndex].itemNumS.SetNumber(num, 0);
			m_prizeObject[arrayIndex].ucL.SetNumber(num, 0);
			m_prizeObject[arrayIndex].ucS.SetNumber(num, 0);
		}

		// RVA: 0x1D6275C Offset: 0x1D6275C VA: 0x1D6275C
		public void Update()
		{
			if(!IsReady())
				return;
			Skip();
			if(m_animationList.Count > 0)
			{
				if(!m_animationList[0].MoveNext())
				{
					m_animationList.RemoveAt(0);
				}
			}
			if(m_animItemIconL != null)
			{
				if(!m_animItemIconL.MoveNext())
					m_animItemIconL = null;
			}
			if(m_animItemIconS != null)
			{
				if(!m_animItemIconS.MoveNext())
					m_animItemIconS = null;
			}
		}

		// // RVA: 0x1D62BBC Offset: 0x1D62BBC VA: 0x1D62BBC
		public void Show()
		{
			if (m_root == null)
				return;
			if (m_isOpen)
				return;
			m_isOpen = true;
			m_isClosed = false;
			m_animationList.Clear();
			if (m_type >= eType.Comeback && m_type <= eType.ComebackSp)
				m_root.StartChildrenAnimGoStop("go_in_2", "st_in_2");
			else
				m_root.StartChildrenAnimGoStop("go_in", "st_in");
			m_animationList.Add(WaitOpenAnim());
			gameObject.SetActive(true);
			SetButtonVisibleEnable(false);
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_000);
		}

		// // RVA: 0x1D62E1C Offset: 0x1D62E1C VA: 0x1D62E1C
		public void Hide()
		{
			if (!m_isOpen)
				return;
			m_isOpen = false;
			m_animationList.Clear();
			if (m_type >= eType.Comeback && m_type <= eType.ComebackSp)
				m_root.StartChildrenAnimGoStop("go_out_2", "st_out_2");
			else
				m_root.StartChildrenAnimGoStop("go_out", "st_out");
			m_animationList.Add(WaitCloseAnim());
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_001);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EC08C Offset: 0x6EC08C VA: 0x6EC08C
		// // RVA: 0x1D62D90 Offset: 0x1D62D90 VA: 0x1D62D90
		private IEnumerator WaitOpenAnim()
		{
			//0x1D65B50
			yield return null;
			while(m_root.IsPlayingChildren())
				yield return null;
			if (m_prevStampPlayCallback != null)
			{
				m_prevStampPlayCallback();
				m_prevStampPlayCallback = null;
			}
			SwitchTitleAnim(m_type);
			SwitchStampAnim(m_stampPlayDay, eStampStatus.Play);
			SwitchItemFrameAnim(m_stampPlayDay, eIconLayoutType.Normal, eIconFrameAnim.In);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EC104 Offset: 0x6EC104 VA: 0x6EC104
		// // RVA: 0x1D62F9C Offset: 0x1D62F9C VA: 0x1D62F9C
		private IEnumerator WaitCloseAnim()
		{
			//0x1D657CC
			yield return null;
			while (m_root.IsPlayingChildren())
				yield return null;
			m_isClosed = true;
			gameObject.SetActive(false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EC17C Offset: 0x6EC17C VA: 0x6EC17C
		// // RVA: 0x1D62568 Offset: 0x1D62568 VA: 0x1D62568
		private IEnumerator WaitStampAnim(int arrayIndex)
		{
			AbsoluteLayout layout; // 0x18
			CAEDGOPBDNK data; // 0x1C

			//0x1D65CE4
			ResetObjectSibiling();
			if (m_prizeObject[arrayIndex].stampAnim == null)
				yield break;
			layout = m_prizeObject[arrayIndex].stampAnim;
			float lbl = layout.GetView(0).FrameAnimation.SearchLabelFrame("stamp_se");
			while (layout.GetView(0).FrameAnimation.FrameCount < lbl)
				yield return null;
			if (!m_isPlayStampSe && !m_isSkip)
			{
				m_isPlayStampSe = true;
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_LOGIN_000);
			}
			//LAB_01d65fe8
			while (layout.IsPlayingChildren())
				yield return null;
			data = m_rewardData.JPILDOGJLDG_LoginBonusPrizes[m_stampPlayDay];
			if(data.HBHMAKNGKFK_Items.Count >= 2)
			{
				if(OnWaitDivaVoice != null)
				{
					//LAB_01d66128
					while (OnWaitDivaVoice())
						yield return null;
				}
				OpenItemPackPopup(data, () =>
				{
					//0x1D64714
					m_isCheckItemPack = true;
				});
				yield return new WaitWhile(() =>
				{
					//0x1D64720
					return !m_isCheckItemPack;
				});
			}
			//LAB_01d660c4
			if(!m_isNextReward)
			{
				m_skipEnd = true;
				m_isSkip = true;
				SetButtonVisibleEnable(true);
				SwitchItemFrameAnim(m_stampPlayDay, eIconLayoutType.Normal, eIconFrameAnim.Out);
				SwitchItemFrameAnim(m_stampPlayDay + 1, eIconLayoutType.Big, eIconFrameAnim.InToLoop);
				SetObjectSibiling(1, m_prizeObject[m_stampPlayDay + 1].iconLayout);
				SwitchStampAnim(arrayIndex, eStampStatus.Loop);
			}
			else
			{
				m_animationList.Add(ChangeRewardAnim());
				SwitchStampAnim(arrayIndex, eStampStatus.Loop);
			}
		}

		// // RVA: 0x1D63088 Offset: 0x1D63088 VA: 0x1D63088
		private void OpenItemPackPopup(CAEDGOPBDNK data, Action callback)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			string str = m_rewardData.BPEAIOBHMFD_NameForApis + "_{0:00}";
			str = bk.GetMessageByLabel(string.Format(str, m_stampPlayDay + 1));
			if(str.Contains("!not exist"))
			{
				str = bk.GetMessageByLabel("popup_loginbonus_comeback_pack_001");
			}
			PopupLoginBonusPackSetting s = new PopupLoginBonusPackSetting();
			s.TitleText = str;
			s.WindowSize = SizeType.Middle;
			s.Data = data;
			s.Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative } };
			PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1D647D0
				return;
			}, null, null, null, endCallBaack:() =>
			{
				//0x1D64E24
				if (callback != null)
					callback();
			});
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EC1F4 Offset: 0x6EC1F4 VA: 0x6EC1F4
		// // RVA: 0x1D63530 Offset: 0x1D63530 VA: 0x1D63530
		private IEnumerator ChangeRewardAnim()
		{
			float wait; // 0x14
			float waitCounter; // 0x18

			//0x1D64E3C
			wait = 1;
			waitCounter = 0;
			while(true)
			{
				waitCounter = TimeWrapper.deltaTime;
				yield return null;
				if (wait <= waitCounter)
					break;
			}
			m_iconsAnim.StartAllAnimGoStop("go_out_change", "st_out_change");
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_001);
			yield return null;
			while (m_root.IsPlayingChildren())
				yield return null;
			ResetRewardData();
			SetStatusInner(m_rewardData, 0, true);
			SwitchNext(0, eNextType.Next);
			m_iconsAnim.StartAllAnimGoStop("go_in_change", "st_in_change");
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_000);
			yield return null;
			while (m_root.IsPlayingChildren())
				yield return null;
			SwitchIcon(0, eIconLayoutType.Big);
			SwitchItemFrameAnim(0, eIconLayoutType.Big, eIconFrameAnim.InToLoop);
			SetObjectSibiling(1, m_prizeObject[0].iconLayout);
			m_skipEnd = true;
			m_isSkip = true;
			SetButtonVisibleEnable(true);
		}

		// // RVA: 0x1D635DC Offset: 0x1D635DC VA: 0x1D635DC
		// public bool IsPlayingAnim() { }

		// // RVA: 0x1D62A08 Offset: 0x1D62A08 VA: 0x1D62A08
		public void Skip()
		{
			if(m_isOpen && !m_isSkip)
			{
				if(InputManager.Instance.GetInScreenTouchCount() > 0)
				{
					if(!InputManager.Instance.IsScreenTouch())
						return;
					m_isSkip = true;
					m_skipEnd = false;
					m_animationList.Clear();
					m_animationList.Add(SkipAnim());
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EC26C Offset: 0x6EC26C VA: 0x6EC26C
		// // RVA: 0x1D635F4 Offset: 0x1D635F4 VA: 0x1D635F4
		private IEnumerator SkipAnim()
		{
			//0x1D65284
			SwitchTitleAnim(m_type);
			if(m_prevStampPlayCallback != null)
			{
				m_prevStampPlayCallback();
				m_prevStampPlayCallback = null;
			}
			if(!m_isNextReward)
			{
				m_root.StartChildrenAnimGoStop("st_in", "st_in");
				SwitchStampAnim(m_stampPlayDay, eStampStatus.Loop);
				m_animItemIconL = null;
				m_animItemIconS = null;
				SwitchItemFrameAnim(m_stampPlayDay, eIconLayoutType.Normal, eIconFrameAnim.Out);
				SwitchItemFrameAnim(m_stampPlayDay + 1, eIconLayoutType.Big, eIconFrameAnim.Loop);
				SetObjectSibiling(1, m_prizeObject[m_stampPlayDay + 1].iconLayout);
			}
			else
			{
				m_iconsAnim.StartAllAnimGoStop("st_out_change", "st_out_change");
				ResetRewardData();
				SetStatusInner(m_rewardData, 0, true);
				SwitchNext(0, eNextType.Next);
				m_iconsAnim.StartAllAnimGoStop("st_in_change", "st_in_change");
				m_animItemIconL = null;
				m_animItemIconS = null;
				SwitchIcon(0, eIconLayoutType.Big);
				SwitchItemFrameAnim(0, eIconLayoutType.Big, eIconFrameAnim.InToLoop);
				SetObjectSibiling(1, m_prizeObject[0].iconLayout);
			}
			SetButtonVisibleEnable(true);
			if(!m_isPlayStampSe)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_LOGIN_000);
				m_isPlayStampSe = true;
			}
			if(m_rewardData.JPILDOGJLDG_LoginBonusPrizes[m_stampPlayDay].HBHMAKNGKFK_Items.Count >= 1 && !m_isCheckItemPack)
			{
				OpenItemPackPopup(m_rewardData.JPILDOGJLDG_LoginBonusPrizes[m_stampPlayDay], () =>
				{
					//0x1D64734
					m_isCheckItemPack = true;
				});
				yield return new WaitWhile(() =>
				{
					//0x1D64740
					return !m_isCheckItemPack;
				});
			}
			m_skipEnd = true;
		}

		// RVA: 0x1D636A0 Offset: 0x1D636A0 VA: 0x1D636A0
		public void Reset()
		{
			ResetRewardData();
			m_rewardData = null;
			m_animationList.Clear();
			m_isNextReward = false;
			m_stampPlayDay = 0;
			m_isSkip = false;
			m_isPlayStampSe = false;
			m_skipEnd = false;
			if(m_okButton != null)
			{
				LayoutUGUIUtility.SetImageRaycastTarget(m_okButton.gameObject, true);
			}
		}

		// // RVA: 0x1D637E0 Offset: 0x1D637E0 VA: 0x1D637E0
		private void ResetRewardData()
		{
			for(int i = 0; i < 10; i++)
			{
				if(m_prizeObject[i] != null)
				{
					SwitchStampAnim(i, eStampStatus.None);
					SwitchIcon(i, eIconLayoutType.Normal);
					SwitchUnitPrice(i, eUnitPrice.Num);
					SwitchItemFrameAnim(i, eIconLayoutType.Normal, eIconFrameAnim.Wait);
					SwitchItemFrameAnim(i, eIconLayoutType.Big, eIconFrameAnim.Wait);
					SwitchNext(i, eNextType.None);
					SwitchIconEnable(i, false);
					SwitchDayEnable(i, false);
					m_prizeObject[i].isLoadingIconS = false;
					m_prizeObject[i].isLoadingIconL = false;
				}
			}
		}

		// // RVA: 0x1D63964 Offset: 0x1D63964 VA: 0x1D63964
		private void SetObjectSibiling(int value, AbsoluteLayout layout)
		{
			m_rectPrizeLayout = m_runtime.FindRectTransform(layout);
			m_prevIndex = m_rectPrizeLayout.GetSiblingIndex();
			m_rectPrizeLayout.SetSiblingIndex(m_prevIndex + value);
		}

		// // RVA: 0x1D639F0 Offset: 0x1D639F0 VA: 0x1D639F0
		private void ResetObjectSibiling()
		{
			if (m_rectPrizeLayout == null)
				return;
			m_rectPrizeLayout.SetSiblingIndex(m_prevIndex);
		}

		// // RVA: 0x1D63AAC Offset: 0x1D63AAC VA: 0x1D63AAC
		// private void DeleteImage(ref RawImageEx image) { }

		// RVA: 0x1D63BFC Offset: 0x1D63BFC VA: 0x1D63BFC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			m_runtime = gameObject.GetComponent<LayoutUGUIRuntime>();
			m_root.StartAllAnimGoStop("st_wait");
			m_titleStandingAnim = layout.FindViewByExId("swtbl_login_title_sw_login_title_fulltime_anim") as AbsoluteLayout;
			m_titleSuccessionAnim = layout.FindViewByExId("swtbl_login_title_sw_login_title_succession_anim") as AbsoluteLayout;
			m_titleComebackAnim = layout.FindViewByExId("swtbl_login_title_sw_login_title_comeback_anim") as AbsoluteLayout;
			m_titleComebackSpAnim = layout.FindViewByExId("swtbl_login_title_sw_login_title_comebacks_anim") as AbsoluteLayout;
			m_iconsAnim = layout.FindViewByExId("sw_login_window_01_all_sw_login_item_window_anim") as AbsoluteLayout;
			for(int i = 0; i < 10; i++)
			{
				m_dayLayout[i] = layout.FindViewByExId(string.Format("sw_login_window_01_all_swnum_m_{0}dey", i + 1)) as AbsoluteLayout;
				m_prizeObject[i].iconLayout = layout.FindViewByExId(string.Format("sw_login_item_window_swtbl_login_icon_{0}day", i + 1)) as AbsoluteLayout;
				if(m_prizeObject[i].iconLayout != null)
				{
					m_prizeObject[i].frameLPlaying = m_prizeObject[i].iconLayout.FindViewByExId("swtbl_login_icon_sw_next_icon_anim") as AbsoluteLayout;
					m_prizeObject[i].frameSPlaying = m_prizeObject[i].iconLayout.FindViewByExId("sw_icon_s_sw_icon_s_ef_loop_anim") as AbsoluteLayout;
				}
				m_prizeObject[i].stampAnim = layout.FindViewByExId(string.Format("sw_login_item_window_swtbl_login_get_{0}day", i + 1)) as AbsoluteLayout;
			}
			Reset();
			Loaded();
			return true;
		}
	}
}
