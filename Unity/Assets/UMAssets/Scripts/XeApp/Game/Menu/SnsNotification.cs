using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class SnsNotification : MonoBehaviour
	{
		[SerializeField]
		private float m_touchWaitTime = 3; // 0xC
		private SnsNotificationLayout m_layout; // 0x10
		private float m_touchWaitCounter; // 0x14
		private bool m_dirtyClose; // 0x18

		public bool DirtyClose { get { return m_dirtyClose; } set { m_dirtyClose = value; } } //0x12D1228 0x12D1230

		// RVA: 0x12D1238 Offset: 0x12D1238 VA: 0x12D1238
		public void OnDestroy()
		{
			m_layout = null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7351EC Offset: 0x7351EC VA: 0x7351EC
		//// RVA: 0x12D1244 Offset: 0x12D1244 VA: 0x12D1244
		public IEnumerator LoadLayout()
		{
			AssetBundleLoadLayoutOperationBase layOp;

			//0x12D23D8
			layOp = AssetBundleManager.LoadLayoutAsync("ly/094.xab", "root_sns_notifi_layout_root");
			yield return layOp;
			yield return Co.R(layOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x12D18BC
				m_layout = instance.GetComponent<SnsNotificationLayout>();
				instance.transform.SetParent(transform, false);
			}));
			AssetBundleManager.UnloadAssetBundle("ly/094.xab", false);
		}

		//// RVA: 0x12D12F0 Offset: 0x12D12F0 VA: 0x12D12F0
		//public void Show(int snsId, UnityAction pushAction, bool isButtonEnable = True) { }

		//// RVA: 0x12D14E4 Offset: 0x12D14E4 VA: 0x12D14E4
		public void ShowOffer(UnityAction pushAction, bool isButtonEnable = true)
		{
			Show(KDHGBOOECKC.HHCJCDFCLOB.IOCBOGFFHFE.AHHJLDLAPAN_DivaId, KDHGBOOECKC.HHCJCDFCLOB.IOCBOGFFHFE.PGOGHFDBIBA_OfferName, KDHGBOOECKC.HHCJCDFCLOB.IOCBOGFFHFE.PNOBKANLFHA_OfferText, pushAction, isButtonEnable, true);
			m_dirtyClose = false;
		}

		//// RVA: 0x12D1408 Offset: 0x12D1408 VA: 0x12D1408
		private void Show(int charaId, string header, string body, UnityAction pushAction, bool isButtonEnable = true, bool IsOffer = false)
		{
			TodoLogger.Log(0, "Show");
			pushAction();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x735264 Offset: 0x735264 VA: 0x735264
		//// RVA: 0x12D17A8 Offset: 0x12D17A8 VA: 0x12D17A8
		//private IEnumerator Co_TouchWait(UnityAction pushAction, bool isButtonEnable = True, bool IsOffer = False) { }

		//// RVA: 0x12D189C Offset: 0x12D189C VA: 0x12D189C
		public void Close()
		{
			m_dirtyClose = true;
			return;
		}
	}
}
