using System.Collections;
using UnityEngine;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class OfferResultEffect : MonoBehaviour
	{
		public enum OfferEfectType
		{
			None = -1,
			Back = 0,
			SuccessA = 1,
			SuccessB = 2,
			Num = 3,
		}

		private class EffectData
		{
			public GameObject obj; // 0x8
			public Animator anim; // 0xC

			//// RVA: 0x1855C50 Offset: 0x1855C50 VA: 0x1855C50
			public void Setup(GameObject prefab)
			{
				obj = Instantiate(prefab);
				anim = obj.GetComponentInChildren<Animator>(true);
				obj.SetActive(false);
			}
		}

		private static readonly string[] EFFECT_ROOT = new string[3]
		{
			"of_back_root", "of_success_A", "of_success_B"
		}; // 0x0
		private static readonly int[] EFFECT_ANIM_STATE = new int[3]
		{
			Animator.StringToHash("get_vl_back"),
			Animator.StringToHash("get_front"),
			Animator.StringToHash("get_front")
		}; // 0x4
		private static readonly int BACK_FLASH_ANIM_STATE = Animator.StringToHash("get_vl_back_start_flash"); // 0x8
		private EffectData[] m_EffectData = new EffectData[3]; // 0xC
		private bool m_IsLoaded; // 0x10

		// RVA: 0x1854DF4 Offset: 0x1854DF4 VA: 0x1854DF4
		public void LoadResource()
		{
			this.StartCoroutineWatched(Co_LoadResource());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F98D4 Offset: 0x6F98D4 VA: 0x6F98D4
		// RVA: 0x1854E18 Offset: 0x1854E18 VA: 0x1854E18
		private IEnumerator Co_LoadResource()
		{
			string bundle_name;
			AssetBundleLoadAllAssetOperationBase operation;

			//0x1855978
			bundle_name = "mn/of/re.xab";
			operation = AssetBundleManager.LoadAllAssetAsync(bundle_name);
			yield return operation;
			for(int i = 0; i < EFFECT_ROOT.Length; i++)
			{
				m_EffectData[i] = new EffectData();
				m_EffectData[i].Setup(operation.GetAsset<GameObject>(EFFECT_ROOT[i]) as GameObject);
			}
			AssetBundleManager.UnloadAssetBundle(bundle_name, false);
			m_IsLoaded = true;
		}

		//// RVA: 0x1854EC4 Offset: 0x1854EC4 VA: 0x1854EC4
		public bool IsLoaded()
		{
			return m_IsLoaded;
		}

		// RVA: 0x1854ECC Offset: 0x1854ECC VA: 0x1854ECC
		public bool IsPlaying(OfferEfectType type)
		{
			return m_EffectData[(int)type].anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
		}

		// RVA: 0x1854FB0 Offset: 0x1854FB0 VA: 0x1854FB0
		public void Release()
		{
			for(int i = 0; i < 3; i++)
			{
				Destroy(m_EffectData[i].obj);
				m_EffectData[i] = null;
			}
			m_IsLoaded = false;
		}

		// RVA: 0x18550D0 Offset: 0x18550D0 VA: 0x18550D0
		public void Reset()
		{
			for(int i = 0; i < 3; i++)
			{
				m_EffectData[i].obj.SetActive(false);
			}
		}

		// RVA: 0x185515C Offset: 0x185515C VA: 0x185515C
		public void Play(OfferEfectType type)
		{
			m_EffectData[(int)type].obj.SetActive(true);
			m_EffectData[(int)type].anim.Play(EFFECT_ANIM_STATE[(int)type]);
		}

		// RVA: 0x18552FC Offset: 0x18552FC VA: 0x18552FC
		public void PlayBackFlash()
		{
			m_EffectData[0].obj.SetActive(true);
			m_EffectData[0].anim.Play(BACK_FLASH_ANIM_STATE);
		}

		// RVA: 0x185545C Offset: 0x185545C VA: 0x185545C
		public void AnimSkip(OfferEfectType type)
		{
			m_EffectData[(int)type].obj.SetActive(true);
			m_EffectData[(int)type].anim.Play(EFFECT_ANIM_STATE[(int)type], 0, 1);
		}

		// RVA: 0x1855610 Offset: 0x1855610 VA: 0x1855610
		public void Update()
		{
			return;
		}
	}
}
