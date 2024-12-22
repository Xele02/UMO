using System.Collections;
using UnityEngine;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class UnlockValkyrieEffect : MonoBehaviour
	{
		public enum EffectType
		{
			None = -1,
			Back = 0,
			Front = 1,
			Num = 2,
		}

		private class EffectData
		{
			public GameObject obj; // 0x8
			public Animator anim; // 0xC

			// // RVA: 0x164C610 Offset: 0x164C610 VA: 0x164C610
			public void Setup(GameObject prefab)
			{
				obj = Instantiate(prefab);
				anim = obj.GetComponentInChildren<Animator>(true);
				obj.SetActive(false);
			}
		}

		private static readonly string[] EFFECT_ROOT = new string[2]
		{
			"get_vl_back_root", "get_vl_front_root"
		}; // 0x0
		private static readonly int[] EFFECT_ANIM_STATE = new int[2]
		{
			Animator.StringToHash("get_vl_back"),
			Animator.StringToHash("get_front"),
		}; // 0x4
		private static readonly int BACK_FLASH_ANIM_STATE = Animator.StringToHash("get_vl_back_start_flash"); // 0x8
		private EffectData[] m_EffectData = new EffectData[2]; // 0xC
		private bool m_IsLoaded; // 0x10

		// RVA: 0x164BA10 Offset: 0x164BA10 VA: 0x164BA10
		public void LoadResource()
		{
			this.StartCoroutineWatched(Co_LoadResource());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7327AC Offset: 0x7327AC VA: 0x7327AC
		// // RVA: 0x164BA34 Offset: 0x164BA34 VA: 0x164BA34
		private IEnumerator Co_LoadResource()
		{
			string bundle_name; // 0x14
			AssetBundleLoadAllAssetOperationBase operation; // 0x18

			//0x164C338
			bundle_name = "mn/gt/vl.xab";
			operation = AssetBundleManager.LoadAllAssetAsync(bundle_name);
			yield return operation;
			for(int i = 0; i < 2; i++)
			{
				GameObject g = operation.GetAsset<GameObject>(EFFECT_ROOT[i]);
				EffectData d = new EffectData();
				d.Setup(g);
				m_EffectData[i] = d;
			}
			AssetBundleManager.UnloadAssetBundle(bundle_name, false);
			m_IsLoaded = true;
		}

		// RVA: 0x164BAE0 Offset: 0x164BAE0 VA: 0x164BAE0
		public bool IsLoaded()
		{
			return m_IsLoaded;
		}

		// RVA: 0x164BAE8 Offset: 0x164BAE8 VA: 0x164BAE8
		public bool IsPlaying(EffectType type)
		{
			return m_EffectData[(int)type].anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
		}

		// RVA: 0x164BBCC Offset: 0x164BBCC VA: 0x164BBCC
		public void Release()
		{
			for(int i = 0; i < 2; i++)
			{
				Destroy(m_EffectData[i].obj);
				m_EffectData[i] = null;
			}
			m_IsLoaded = false;
		}

		// RVA: 0x164BCEC Offset: 0x164BCEC VA: 0x164BCEC
		public void Reset()
		{
			for(int i = 0; i < 2; i++)
			{
				m_EffectData[i].obj.SetActive(false);
			}
		}

		// RVA: 0x164BD78 Offset: 0x164BD78 VA: 0x164BD78
		public void Play(EffectType type)
		{
			m_EffectData[(int)type].obj.SetActive(true);
			m_EffectData[(int)type].anim.Play(EFFECT_ANIM_STATE[(int)type]);
		}

		// RVA: 0x164BF18 Offset: 0x164BF18 VA: 0x164BF18
		public void PlayBackFlash()
		{
			m_EffectData[0].obj.SetActive(true);
			m_EffectData[0].anim.Play(BACK_FLASH_ANIM_STATE);
		}

		// RVA: 0x164C078 Offset: 0x164C078 VA: 0x164C078
		public void Update()
		{
			return;
		}
	}
}
