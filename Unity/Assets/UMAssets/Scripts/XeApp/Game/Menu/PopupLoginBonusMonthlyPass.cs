using System;
using System.Collections;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class PopupLoginBonusMonthlyPass : IDisposable
	{
		public enum Type
		{
			RequestLoginBonus = 0,
			TitleLoginBonus = 1,
			TitleMonthlyPass = 2,
		}

		private static PopupLoginBonusMonthlyPass m_instance; // 0x0
		private static Action m_forceCloseCallback; // 0x4
		private LayoutLoginBonusMonthlyPass m_layoutLoginbonusMonthlyPass; // 0x8
		private GJFMKMJOFMB m_viewLoginBonusMonthlyPass; // 0xC
		private bool m_isSuccess; // 0x10

		//[IteratorStateMachineAttribute] // RVA: 0x7061F4 Offset: 0x7061F4 VA: 0x7061F4
		// RVA: 0x168AE50 Offset: 0x168AE50 VA: 0x168AE50
		public static IEnumerator Show(Type popupType, bool forceAvailableTopplan = false, Transform parent = null, Action<bool> closeCallback = null)
		{
			GJFMKMJOFMB view;

			//0x168D98C
			if(m_instance != null)
			{
				if (closeCallback != null)
					closeCallback(false);
				yield break;
			}
			m_instance = new PopupLoginBonusMonthlyPass();
			if(popupType == Type.RequestLoginBonus)
			{
				bool err = false;
				yield return m_instance.Co_RequestLoginBonusMonthlyPass(() =>
				{
					//0x168B5B0
					err = true;
				});
				if(err)
				{
					MenuScene.Instance.GotoTitle();
					yield break;
				}
			}
			view = new GJFMKMJOFMB();
			view.KHEKNNFCAOI(m_instance.m_isSuccess, forceAvailableTopplan);
			if(m_instance.m_isSuccess || popupType != Type.RequestLoginBonus)
			{
				TodoLogger.LogError(0, "PopupLoginBonusMonthlyPass.Show");
			}
			//LAB_0168db54
			if(!view.KLMNKBCDGPI)
			{
				//LAB_0168dc58
				if(view.ENHGKPMEICN)
				{
					TodoLogger.LogError(0, "PopupLoginBonusMonthlyPass.Show");
				}
				if(closeCallback != null)
				{
					closeCallback(m_instance.m_isSuccess);
				}
				if(m_instance != null)
				{
					m_instance.Dispose();
					m_instance = null;
				}
				if(m_forceCloseCallback != null)
				{
					m_forceCloseCallback();
					m_forceCloseCallback = null;
				}
			}
			else
			{
				TodoLogger.LogError(0, "PopupLoginBonusMonthlyPass.Show");
			}
		}

		//// RVA: 0x168AF48 Offset: 0x168AF48 VA: 0x168AF48
		//public static void Close(Action closeCallback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70626C Offset: 0x70626C VA: 0x70626C
		//// RVA: 0x168B0D0 Offset: 0x168B0D0 VA: 0x168B0D0
		private IEnumerator Co_RequestLoginBonusMonthlyPass(DJBHIFLHJLK onErrorToTitle)
		{
			int hotenCount;

			//0x168C4A4
			m_isSuccess = false;
			if(NHPDPKHMFEP.HHCJCDFCLOB.KBJJGEJAMOK())
			{
				bool done = false;
				bool err = false;
				//MenuScene.Instance.RaycastDisable();
				TodoLogger.LogError(0, "Co_RequestLoginBonusMonthlyPass");
			}
			//LAB_0168cc50
			int numItem = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.FKGCBLHOOCL_Category.PJCJEOECLBK_MonthlyPassItem, 1, null);
			if(numItem < 1)
			{
				//LAB_0168d4e4
				if (!NHPDPKHMFEP.HHCJCDFCLOB.GBCPDBJEDHL(false))
					yield break;
				TodoLogger.LogError(0, "Co_RequestLoginBonusMonthlyPass 2");
			}
			else
			{
				TodoLogger.LogError(0, "Co_RequestLoginBonusMonthlyPass 3");
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7062E4 Offset: 0x7062E4 VA: 0x7062E4
		//// RVA: 0x168B198 Offset: 0x168B198 VA: 0x168B198
		//private IEnumerator Co_OpenLoginBonusMonthlyPass(GJFMKMJOFMB view, PopupLoginBonusMonthlyPass.Type popupType, bool forceAvailableTopplan, Transform parent, Action closeCallback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70635C Offset: 0x70635C VA: 0x70635C
		//// RVA: 0x168B2B0 Offset: 0x168B2B0 VA: 0x168B2B0
		//private IEnumerator Co_LoadingLayoutMonthlyPass() { }

		//// RVA: 0x168B008 Offset: 0x168B008 VA: 0x168B008
		//public void ForceClose() { }

		// RVA: 0x168B35C Offset: 0x168B35C VA: 0x168B35C Slot: 4
		public void Dispose()
		{
			if(m_layoutLoginbonusMonthlyPass != null)
			{
				UnityEngine.Object.Destroy(m_layoutLoginbonusMonthlyPass);
				m_layoutLoginbonusMonthlyPass = null;
			}
			m_viewLoginBonusMonthlyPass = null;
		}

		//[CompilerGeneratedAttribute] // RVA: 0x7063D4 Offset: 0x7063D4 VA: 0x7063D4
		//// RVA: 0x168B468 Offset: 0x168B468 VA: 0x168B468
		//private void <Co_LoadingLayoutMonthlyPass>b__10_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x7063E4 Offset: 0x7063E4 VA: 0x7063E4
		//// RVA: 0x168B4E4 Offset: 0x168B4E4 VA: 0x168B4E4
		//private void <ForceClose>b__11_0() { }
	}
}
