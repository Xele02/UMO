using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace XeSys
{
	public class BoneSpringSettingParameter : ScriptableObject
	{
		[Serializable]
		private class ControllerSettingParameter
		{
			public Vector3 fieldForce; // 0x8
			public float influence; // 0x14
		}

		[Serializable]
		private class ControlPointSettingParameter
		{
			public string path; // 0x8
			public string relationalPointPath; // 0xC
			public float radius; // 0x10
			public float weight; // 0x14
			public float mass; // 0x18
			public float stability; // 0x1C
			public float influence; // 0x20
			public Vector3 localVelocity; // 0x24
			public List<string> colliderPathList; // 0x30
		}

		[Serializable]
		private class ColliderSettingParameter
		{
			public string path; // 0x8
			public float radius; // 0xC
			public Vector3 offset; // 0x10
			public string relationalColliderPath; // 0x1C
		}

		private StringBuilder str = new StringBuilder(); // 0xC
		[SerializeField]
		private BoneSpringSettingParameter.ControllerSettingParameter controllerParam = new ControllerSettingParameter(); // 0x10
		[SerializeField]
		private List<BoneSpringSettingParameter.ControlPointSettingParameter> controlPointParamList = new List<ControlPointSettingParameter>(); // 0x14
		[SerializeField]
		private List<BoneSpringSettingParameter.ColliderSettingParameter> colliderParamList = new List<ColliderSettingParameter>(); // 0x18

		//// RVA: 0x192C238 Offset: 0x192C238 VA: 0x192C238
		//public void Save(GameObject root) { }

		//// RVA: 0x192C268 Offset: 0x192C268 VA: 0x192C268
		//private void SaveController(GameObject root) { }

		//// RVA: 0x192C380 Offset: 0x192C380 VA: 0x192C380
		//private void SaveCollider(GameObject root) { }

		//// RVA: 0x192C630 Offset: 0x192C630 VA: 0x192C630
		//private void SaveControlPoint(GameObject root) { }

		//// RVA: 0x192BD2C Offset: 0x192BD2C VA: 0x192BD2C
		public void Load(GameObject root)
		{
			DeleteOldComponent(root);
			LoadController(root);
			LoadCollider(root);
			LoadControlPoint(root);
		}

		//// RVA: 0x192CE40 Offset: 0x192CE40 VA: 0x192CE40
		private void LoadController(GameObject root)
		{
			BoneSpringController controller = root.GetComponent<BoneSpringController>();
			if(controller == null)
			{
				controller = root.AddComponent<BoneSpringController>();
			}
			controller.fieldForce_ = controllerParam.fieldForce;
			controller.influence = controllerParam.influence;
		}

		//// RVA: 0x192CF84 Offset: 0x192CF84 VA: 0x192CF84
		private void LoadCollider(GameObject root)
		{
			List<BoneSpringCollider> colls = new List<BoneSpringCollider>(colliderParamList.Count);
			List<string> collName = new List<string>(colliderParamList.Count);
			for(int i = 0; i < colliderParamList.Count; i++)
			{
				Transform t = root.transform.Find(colliderParamList[i].path);
				if(t != null)
				{
					BoneSpringCollider coll = t.gameObject.AddComponent<BoneSpringCollider>();
					coll.radius = colliderParamList[i].radius;
					coll.offset = colliderParamList[i].offset;
					colls.Add(coll);
					collName.Add(colliderParamList[i].relationalColliderPath);
				}
			}
			for(int i = 0; i < colls.Count; i++)
			{
				if(collName[i] != null)
				{
					Transform t = root.transform.Find(collName[i]);
					if(t != null)
					{
						colls[i].relational = t.GetComponent<BoneSpringCollider>();
					}
				}
			}
		}

		//// RVA: 0x192D420 Offset: 0x192D420 VA: 0x192D420
		private void LoadControlPoint(GameObject root)
		{
			List<BoneSpringControlPoint> cps = new List<BoneSpringControlPoint>(controlPointParamList.Count);
			List<string> cpNames = new List<string>(controlPointParamList.Count);
			for(int i = 0; i < controlPointParamList.Count; i++)
			{
				Transform t = root.transform.Find(controlPointParamList[i].path);
				if(t != null)
				{
					BoneSpringControlPoint cp = t.gameObject.AddComponent<BoneSpringControlPoint>();
					cp.radius = controlPointParamList[i].radius;
					cp.weight = controlPointParamList[i].weight;
					cp.mass = controlPointParamList[i].mass;
					cp.stability = controlPointParamList[i].stability;
					cp.influence = controlPointParamList[i].influence;
					cp.localVelocity = controlPointParamList[i].localVelocity;
					cp.colliderList = new List<BoneSpringCollider>(controlPointParamList[i].colliderPathList.Count);
					for(int j = 0; j < controlPointParamList[i].colliderPathList.Count; j++)
					{
						if(controlPointParamList[i].colliderPathList[j] != null)
						{
							Transform t2 = root.transform.Find(controlPointParamList[i].colliderPathList[j]);
							if(t2 != null)
							{
								cp.colliderList.Add(t2.GetComponent<BoneSpringCollider>());
							}
						}
					}
					cps.Add(cp);
					cpNames.Add(controlPointParamList[i].relationalPointPath);
				}
			}
			for(int i = 0; i < cps.Count; i++)
			{
				if(cpNames[i] != null)
				{
					Transform t = root.transform.Find(cpNames[i]);
					if(t != null)
					{
						cps[i].relational = t.gameObject.GetComponent<BoneSpringControlPoint>();
					}
				}
			}
		}

		//// RVA: 0x192CA70 Offset: 0x192CA70 VA: 0x192CA70
		//private string MakeTransformFullPath(Transform root, Transform target) { }

		//// RVA: 0x192CC78 Offset: 0x192CC78 VA: 0x192CC78
		private void DeleteOldComponent(GameObject root)
		{
			BoneSpringCollider[] elems = root.GetComponentsInChildren<BoneSpringCollider>(true);
			for(int i = 0; i < elems.Length; i++)
			{
				DestroyImmediate(elems[i]);
			}
			BoneSpringControlPoint[] elems2 = root.GetComponentsInChildren<BoneSpringControlPoint>(true);
			for (int i = 0; i < elems2.Length; i++)
			{
				DestroyImmediate(elems2[i]);
			}
		}
	}
}
