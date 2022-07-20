using System.Collections.Generic;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Common
{
	public class StageExtensionWindCtrlForMenu : StageExtensionWindCtrl
	{

		// RVA: 0x13A6268 Offset: 0x13A6268 VA: 0x13A6268
		public void Initialize(DivaObject a_diva, DivaResource.BoneSpringResource a_resource)
		{
			List<DivaObject> divas = new List<DivaObject>();
			divas.Add(a_diva);
			Initialize(divas);
			SetupBoneSpringSuppresser(a_diva, a_resource, m_list_diva[0]);
		}

		// RVA: 0x13A6784 Offset: 0x13A6784 VA: 0x13A6784
		public void ResetBoneSpringController()
		{
			for(int i = 0; i < m_list_diva.Count; i++)
			{
				List<BoneSpringControlPoint> points = m_list_diva[i].m_bsc.GetListBSCP();
				for(int j = 0; j < points.Count; j++)
				{
					points[j].m_forceFromOutside = Vector3.zero;
				}
			}
		}

		// RVA: 0x13A636C Offset: 0x13A636C VA: 0x13A636C
		private void SetupBoneSpringSuppresser(DivaObject a_diva, DivaResource.BoneSpringResource a_resource, StageExtensionWindCtrl.DivaInfo a_info)
		{
			BoneSpringSuppressParam param;
			if(a_resource.suppress.presets.TryGetValue(BoneSpringSuppressor.Preset.preset11_Wind, out param))
			{
				Transform t = a_diva.divaPrefab.transform.Find("joint_root");
				for(int i = 0; i < param.targetCount; i++)
				{
					BoneSpringSuppressParam.TargetData target = param.GetTargetData(i);
					if(target != null)
					{
						Transform t2 = t.Find(target.pointPath);
						if(t2 != null)
						{
							BoneSpringControlPoint bscp = t2.GetComponent<BoneSpringControlPoint>();
							if(bscp != null)
							{
								for(int j = 0; j < a_info.m_node.Count; j++)
								{
									if(a_info.m_node[j].m_trans == t2)
									{
										a_info.m_node[j].m_rate = 1.0f - target.influenceRate;
										break;
									}
								}
							}
						}
					}
				}
			}
		}
	}
}
