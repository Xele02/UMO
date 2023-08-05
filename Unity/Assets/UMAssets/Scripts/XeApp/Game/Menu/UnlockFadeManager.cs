
using System.Collections;
using UnityEngine;
using XeApp.Core;

namespace XeApp.Game.Menu
{ 
	public class UnlockFadeManager
	{
		private static UnlockFadeManager sm_instance; // 0x0
		private bool m_loaded; // 0x8
		private static LayoutLogoCutin m_unlock_fade_effect; // 0x4

		public static UnlockFadeManager Instance { get { return sm_instance; } } //0x1648940

		// RVA: 0x16489CC Offset: 0x16489CC VA: 0x16489CC
		public static void Create()
		{
			if (sm_instance != null)
				return;
			sm_instance = new UnlockFadeManager();
		}

		//// RVA: 0x1648ABC Offset: 0x1648ABC VA: 0x1648ABC
		public static void Release()
		{
			if (sm_instance == null)
				return;
			sm_instance = null;
			Object.Destroy(m_unlock_fade_effect.gameObject);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x73132C Offset: 0x73132C VA: 0x73132C
		//// RVA: 0x1648BF8 Offset: 0x1648BF8 VA: 0x1648BF8
		public IEnumerator Co_LoadFadeEffect(int logo_id)
		{
			string BundleName; // 0x1C
			AssetBundleLoadLayoutOperationBase operation; // 0x20

			//0x1648D6C
			if (m_loaded)
				yield break;
			m_loaded = false;
			BundleName = "ly/087.xab";
			GameObject instance = null;
			operation = AssetBundleManager.LoadLayoutAsync(BundleName, "UI_UnlockFadeEffect");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject layout) =>
			{
				//0x1648D60
				instance = layout;
			}));
			instance.SetActive(true);
			m_unlock_fade_effect = instance.GetComponent<LayoutLogoCutin>();
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
			m_unlock_fade_effect.Load(logo_id);
			Instance.GetEffect().transform.SetParent(GameManager.Instance.transform.Find("Canvas-Popup/Root"), false);
			Instance.GetEffect().transform.SetAsFirstSibling();
			m_loaded = true;
		}

		//// RVA: 0x1648CC0 Offset: 0x1648CC0 VA: 0x1648CC0
		public bool IsLoaded()
		{
			return m_loaded;
		}

		//// RVA: 0x1648CC8 Offset: 0x1648CC8 VA: 0x1648CC8
		public LayoutLogoCutin GetEffect()
		{
			return m_unlock_fade_effect;
		}
	}
}
