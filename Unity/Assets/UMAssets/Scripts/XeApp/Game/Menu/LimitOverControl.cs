using System;
using System.Collections;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LimitOverControl
	{
		public enum AnimType
		{
			Add = 0,
			Release = 1,
		}

		private AnimType m_animType; // 0x8
		private GCIJNCFDNON_SceneInfo m_sceneData; // 0xC
		private AEKDNMPPOJN m_limitOverData; // 0x10
		private int m_prevLevel; // 0x14

		// RVA: 0x153E820 Offset: 0x153E820 VA: 0x153E820
		public void ShowAddSlot(AEKDNMPPOJN limitOverData, int prevLevel, Action updateTimingCallback, Action endCallback)
		{
			m_limitOverData = limitOverData;
			m_animType = AnimType.Add;
			m_prevLevel = prevLevel;
			GameManager.Instance.StartCoroutineWatched(LimitOverMainCoroutine(updateTimingCallback, endCallback));
		}

		// // RVA: 0x153E9B8 Offset: 0x153E9B8 VA: 0x153E9B8
		public void ShowRelease(GCIJNCFDNON_SceneInfo sceneData, AEKDNMPPOJN limitOverData, Action updateTimingCallback, Action endCallback)
		{
			m_sceneData = sceneData;
			m_animType = AnimType.Release;
			m_limitOverData = limitOverData;
			GameManager.Instance.StartCoroutineWatched(LimitOverMainCoroutine(updateTimingCallback, endCallback));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x704EB4 Offset: 0x704EB4 VA: 0x704EB4
		// // RVA: 0x153E8F8 Offset: 0x153E8F8 VA: 0x153E8F8
		private IEnumerator LimitOverMainCoroutine(Action updateTimingCallback, Action endCallback)
		{
			//0x153F468
			yield return Co.R(LimitOverReleaseEffectCoroutine());
			if(updateTimingCallback != null)
				updateTimingCallback();
			yield return Co.R(LimitOverPopupCoroutine());
			if(m_animType == AnimType.Release)
			{
				if(m_limitOverData.EOBACDCDGOF)
				{
					if(m_sceneData.ELKHCOEMNOJ_IsKira() > 0)
					{
						yield return Co.R(KiraEffectCoroutine());
						m_sceneData.JNNHIDMNBFG("", -1);
						if(updateTimingCallback != null)
							updateTimingCallback();
					}
				}
			}
			if(endCallback != null)
				endCallback();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x704F2C Offset: 0x704F2C VA: 0x704F2C
		// // RVA: 0x153EAB0 Offset: 0x153EAB0 VA: 0x153EAB0
		private IEnumerator LimitOverReleaseEffectCoroutine()
		{
			string bundleName; // 0x1C
			AssetBundleLoadLayoutOperationBase layoutOperation; // 0x20

			//0x153FCB8
			bundleName = "ly/098.xab";
			LayoutLuckyleaf luckyleaf = null;
			layoutOperation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_luckyleaf_layout_root");
			yield return layoutOperation;
			yield return Co.R(layoutOperation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
			{
				//0x153EE20
				luckyleaf = obj.GetComponent<LayoutLuckyleaf>();
				luckyleaf.transform.SetParent(GameManager.Instance.PopupCanvas.transform, false);
			}));
			luckyleaf.SetStatus(m_animType, m_limitOverData.DJEHLEJCPEL_LeafNum, m_prevLevel, m_limitOverData.LJHOOPJACPI_LeafMax);
			bool done = false;
			luckyleaf.StartAnim(() =>
			{
				//0x153EF64
				done = true;
			});
			while(!done)
				yield return null;
			yield return new WaitForSeconds(0.3f);
			done = false;
			luckyleaf.CloseAnim(() =>
			{
				//0x153EF70
				done = true;
			});
			while(!done)
				yield return null;
			UnityEngine.Object.Destroy(luckyleaf.gameObject);
			luckyleaf = null;
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			yield return Co.R(TutorialManager.TryShowTutorialCoroutine(CheckTutorialCondition));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x704FA4 Offset: 0x704FA4 VA: 0x704FA4
		// // RVA: 0x153EB5C Offset: 0x153EB5C VA: 0x153EB5C
		private IEnumerator LimitOverPopupCoroutine()
		{
			//0x153F6F4
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			bool a1 = true;
			if(!m_limitOverData.JMHIDPKHELB)
			{
				a1 = m_limitOverData.EOBACDCDGOF;
			}
			string str = "";
			if(m_animType == AnimType.Release)
			{
				str = bk.GetMessageByLabel(!a1 ? "popup_limit_over_release_02" : "popup_limit_over_release_01");
			}
			else if(m_animType == AnimType.Add)
			{
				str = bk.GetMessageByLabel("popup_limit_over_add");
			}
			PopupLimitOverContentSetting s = new PopupLimitOverContentSetting();
			s.ContentText = str;
			s.LimitOverData = m_limitOverData;
			s.WindowSize = SizeType.Small;
			s.IsCaption = false;
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			bool done = false;
			PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x153EE14
				return;
			}, null, null, null, endCallBaack:() =>
			{
				//0x153EF84
				done = true;
			});
			while(!done)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70501C Offset: 0x70501C VA: 0x70501C
		// // RVA: 0x153EC08 Offset: 0x153EC08 VA: 0x153EC08
		private IEnumerator KiraEffectCoroutine()
		{
			GameObject root; // 0x14
			LayoutPopupRecordPlateController prpController; // 0x18
			Coroutine update; // 0x1C

			//0x153EF94
			root = new GameObject("root_kira_effect");
			prpController = new LayoutPopupRecordPlateController();
			prpController.Setup(RecordPlateUtility.eSceneType.Gacha);
			prpController.mb = GameManager.Instance;
			prpController.LoadAssetBundle();
			while(!prpController.IsLoadBundle)
				yield return null;
			update = GameManager.Instance.StartCoroutineWatched(Update(prpController));
			prpController.Parent = root;
			prpController.CanvasParent = GameManager.Instance.PopupCanvas.gameObject;
			yield return Co.R(prpController.KiraUpPhase(m_sceneData.BCCHOBPJJKE_SceneId, m_sceneData.JKGFBFPIMGA_Rarity, null));
			GameManager.Instance.StopCoroutineWatched(update);
			prpController.Dispose();
			prpController = null;
			UnityEngine.Object.Destroy(root);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x705094 Offset: 0x705094 VA: 0x705094
		// // RVA: 0x153ECB4 Offset: 0x153ECB4 VA: 0x153ECB4
		private IEnumerator Update(LayoutPopupRecordPlateController prpController)
		{
			//0x1540380
			while(true)
			{
				if(prpController != null)
					prpController.Update();
				yield return null;
			}
		}

		// // RVA: 0x153ED60 Offset: 0x153ED60 VA: 0x153ED60
		private bool CheckTutorialCondition(TutorialConditionId conditionId)
		{
			if(conditionId == TutorialConditionId.Condition72)
			{
				if(m_limitOverData != null)
				{
					return m_limitOverData.LJHOOPJACPI_LeafMax > 2;
				}
			}
			return false;
		}
	}
}
