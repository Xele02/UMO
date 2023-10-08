using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using XeApp.Core;

namespace XeApp
{
	public class DecorationBgBase : MonoBehaviour
	{
		[Serializable]
		public class BgMeshData
		{
			public List<int> triangles = new List<int>(); // 0x8
			public List<Vector2> vertices = new List<Vector2>(); // 0xC
		}

		protected DecorationBgBaseSetting m_setting; // 0xC
		public const string textureBundleName = "dc/bg/{0:D4}/{1}.xab";
		private int m_id; // 0x14

		public bool IsLoaded { get; private set; } // 0x10
		// public DecorationBgBase.BgMeshData Mesh { get; } 0x1D7ED20
		public DecorationBgBaseSetting Setting { get { return m_setting; } } //0x1D7ED44
		// public DecorationConstants.Attribute.Type AttributeType { get; } 0x1D7ED4C

		// // RVA: 0x1D7ED70 Offset: 0x1D7ED70 VA: 0x1D7ED70
		public void SetSetting(DecorationBgBaseSetting setting)
		{
			m_setting = setting;
		}

		// // RVA: 0x1D7ED78 Offset: 0x1D7ED78 VA: 0x1D7ED78
		public void LoadResource(int id)
		{
			IsLoaded = false;
			m_id = id;
			this.StartCoroutineWatched(Co_LoadResource());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6AAA1C Offset: 0x6AAA1C VA: 0x6AAA1C
		// // RVA: 0x1D7EDAC Offset: 0x1D7EDAC VA: 0x1D7EDAC
		private IEnumerator Co_LoadResource()
		{
			string bundle;
			AssetBundleLoadAllAssetOperationBase op;

			//0x1D7F99C
			KDKFHGHGFEK data = new KDKFHGHGFEK();
			data.KHEKNNFCAOI(m_id, EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg);
			bundle = DecorationConstants.GetItemBundleName(data, false, m_setting.AttributeType);
			op = AssetBundleManager.LoadAllAssetAsync(bundle);
			yield return op;
			m_setting.material.SetTexture("_MainTex", op.GetAsset<Texture>(DecorationConstants.Attribute.GetTextureName(m_setting.AttributeType) + "_base"));
			m_setting.material.SetTexture("_MaskTex", op.GetAsset<Texture>(DecorationConstants.Attribute.GetTextureName(m_setting.AttributeType) + "_mask"));
			AssetBundleManager.UnloadAssetBundle(bundle, false);
			IsLoaded = true;
		}

		// // RVA: 0x1D7EE58 Offset: 0x1D7EE58 VA: 0x1D7EE58
		public bool HitCheck(Vector2 point)
		{
			for(int i = 0; i < m_setting.mesh.triangles.Count / 3; i++)
			{
				List<Vector2> l = new List<Vector2>();
				for(int j = 0; j < 3; j++)
				{
					l.Add(m_setting.mesh.vertices[m_setting.mesh.triangles[i * 3 + j]]);
				}
				int a = 2;
				int d = 0;
				while(true)
				{
					int c = a;
					if(a != 0)
						c = d + 1;
					Vector2 dir = (l[c] - l[d]).normalized;
					Vector2 dir2 = (point - l[d]).normalized;
					if(dir2.x * dir.y - dir.x * dir2.y < -DecorationConstants.VALUE_EPSILON)
						break;
					a--;
					if(1 < d)
						return true;
					d++;
				}
			}
			return false;
		}

		// // RVA: 0x1D7F314 Offset: 0x1D7F314 VA: 0x1D7F314
		// public Vector2 GetClosestPoint(Vector2 point) { }

		// // RVA: 0x1D7F7A4 Offset: 0x1D7F7A4 VA: 0x1D7F7A4
		// private static Vector2 GetClosestPoint(Vector2 a, Vector2 b, Vector2 p) { }

		// // RVA: 0x1D7F958 Offset: 0x1D7F958 VA: 0x1D7F958
		// public List<Vector2> GetVertices() { }
	}
}
