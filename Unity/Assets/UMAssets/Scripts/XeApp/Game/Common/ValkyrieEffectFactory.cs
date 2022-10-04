using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class ValkyrieEffectFactory : EffectFactoryBase
	{
		private ValkyrieSetting m_setting; // 0x20

		// RVA: 0x1CDF9F8 Offset: 0x1CDF9F8 VA: 0x1CDF9F8
		public void RegisterSetting(ValkyrieSetting setting)
		{
			m_setting = setting;
		}

		// RVA: 0x1CDFA00 Offset: 0x1CDFA00 VA: 0x1CDFA00 Slot: 6
		protected override void OnInstantiate(Instance instance)
		{
			Renderer[] rs = GetComponentsInChildren<Renderer>(true);
			ValkyrieDamageEffect[] vde = instance.gameObject.GetComponentsInChildren<ValkyrieDamageEffect>(true);
			for(int i = 0; i < vde.Length; i++)
			{
				if(vde[i].targetRenderer == null)
				{
					if(rs.Length != 0)
					{
						vde[i].targetRenderer = new List<Renderer>(rs);
					}
				}
				else
				{
					vde[i].targetRenderer.Clear();
					vde[i].targetRenderer.AddRange(rs);
				}
			}
			ValkyrieMuzzleEffect[] vme = instance.gameObject.GetComponentsInChildren<ValkyrieMuzzleEffect>(true);
			for(int i = 0; i < vme.Length; i++)
			{
				if(vme[i].targetRenderer == null)
				{
					if (rs.Length != 0)
					{
						vme[i].targetRenderer = new List<Renderer>(rs);
					}
				}
				else
				{
					vme[i].targetRenderer.Clear();
					vme[i].targetRenderer.AddRange(rs);
				}
			}
			if(m_setting != null)
			{
				ValkyrieVernierEffect vve = instance.gameObject.GetComponent<ValkyrieVernierEffect>();
				if(vve != null)
				{
					vve.ApplyColor(m_setting.vernierMeshColor, m_setting.vernierParticleColor);
				}
			}
		}
	}
}
