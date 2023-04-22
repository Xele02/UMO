using UnityEngine;
using System.Collections.Generic;
using System;

namespace XeApp.Game.Common
{
	public class EffectFactoryCollector : MonoBehaviour
	{
		[SerializeField]
		private List<ValkyrieEffectFactory> m_collection = new List<ValkyrieEffectFactory>(); // 0xC

		//// RVA: 0x1C0E5A8 Offset: 0x1C0E5A8 VA: 0x1C0E5A8
		//private void Reset() { }

		//// RVA: 0x1C0E674 Offset: 0x1C0E674 VA: 0x1C0E674
		public void RegisterSettingAll(ValkyrieSetting setting)
		{
			for (int i = 0; i < m_collection.Count; i++)
			{
				m_collection[i].RegisterSetting(setting);
			}
		}

		//// RVA: 0x1C0E758 Offset: 0x1C0E758 VA: 0x1C0E758
		public void RedirectionAll(EffectFactoryBase.GetCommonAssetFunc getCommonAsset)
		{
			for (int i = 0; i < m_collection.Count; i++)
			{
				m_collection[i].Redirection(getCommonAsset);
			}
		}

		//// RVA: 0x1C0E838 Offset: 0x1C0E838 VA: 0x1C0E838
		public void InstantiateAll()
		{
			for (int i = 0; i < m_collection.Count; i++)
			{
				m_collection[i].Instantiate();
			}
		}

		//// RVA: 0x1C0E910 Offset: 0x1C0E910 VA: 0x1C0E910
		public void Instantiate(string name)
		{
			for(int i = 0; i < m_collection.Count; i++)
			{
				m_collection[i].Instantiate(name);
			}
		}

		//// RVA: 0x1C0E9F0 Offset: 0x1C0E9F0 VA: 0x1C0E9F0
		//public void ReleaseAll() { }

		//// RVA: 0x1C0EAC8 Offset: 0x1C0EAC8 VA: 0x1C0EAC8
		public void ChangeAnimationTime(double time)
		{
			for (int i = 0; i < m_collection.Count; i++)
			{
				m_collection[i].ChangeAnimationTime(time);
			}
		}

		//// RVA: 0x1C0EBB8 Offset: 0x1C0EBB8 VA: 0x1C0EBB8
		public void SetupAll()
		{
			for(int i = 0; i < m_collection.Count; i++)
			{
				m_collection[i].Setup();
			}
		}

		//// RVA: 0x1C0EC90 Offset: 0x1C0EC90 VA: 0x1C0EC90
		public void EmitStart(string name)
		{
			for (int i = 0; i < m_collection.Count; i++)
			{
				m_collection[i].EmitStart(name);
			}
		}

		//// RVA: 0x1C0ED70 Offset: 0x1C0ED70 VA: 0x1C0ED70
		public void EmitStop(string name)
		{
			for (int i = 0; i < m_collection.Count; i++)
			{
				m_collection[i].EmitStop(name);
			}
		}

		//// RVA: 0x1C0EE50 Offset: 0x1C0EE50 VA: 0x1C0EE50
		public void Disable(string name)
		{
			for (int i = 0; i < m_collection.Count; i++)
			{
				m_collection[i].Disable(name);
			}
		}

		//// RVA: 0x1C0EF30 Offset: 0x1C0EF30 VA: 0x1C0EF30
		public void PlayAnim(string id, string anim)
		{
			for (int i = 0; i < m_collection.Count; i++)
			{
				m_collection[i].PlayAnim(id, anim);
			}
		}

		//// RVA: 0x1C0F020 Offset: 0x1C0F020 VA: 0x1C0F020
		public void PauseAll()
		{
			for (int i = 0; i < m_collection.Count; i++)
			{
				m_collection[i].Pause();
			}
		}

		//// RVA: 0x1C0F0F8 Offset: 0x1C0F0F8 VA: 0x1C0F0F8
		public void ResumeAll()
		{
			for (int i = 0; i < m_collection.Count; i++)
			{
				m_collection[i].Resume();
			}
		}

		//// RVA: -1 Offset: -1
		public void ForEach<T>(string id, Action<T> action)
		{
			for (int i = 0; i < m_collection.Count; i++)
			{
				m_collection[i].ForEach(id, action);
			}
		}
		///* GenericInstMethod :
		//|
		//|-RVA: 0x1AB48B8 Offset: 0x1AB48B8 VA: 0x1AB48B8
		//|-EffectFactoryCollector.ForEach<object>
		//|-EffectFactoryCollector.ForEach<ValkyrieFormSwitchListener>
		//*/

		//// RVA: 0x1C0E5AC Offset: 0x1C0E5AC VA: 0x1C0E5AC
		//private void Collect() { }
	}
}
