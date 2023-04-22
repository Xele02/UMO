using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.UI
{
	public class NumericMesh : MonoBehaviour
	{
		[SerializeField]
		private MeshFilter[] meshFilters; // 0xC
		[SerializeField]
		private GameObject rootObject; // 0x10
		[SerializeField]
		private int uvXAdvance; // 0x14
		[SerializeField]
		private int uvYAdvance; // 0x18
		[SerializeField]
		private int lineCount; // 0x1C
		[SerializeField]
		private bool isZeroPadding; // 0x20
		[SerializeField]
		private bool useSpecialCaracter; // 0x21
		[SerializeField]
		private bool isCentering; // 0x22
		[SerializeField]
		private int specialCaracterColumn; // 0x24
		[SerializeField]
		private int specialCaracterRow; // 0x28
		private List<Vector2[]> baseUvs; // 0x2C
		private List<Vector2[]> writeUvs; // 0x30
		private float width; // 0x34
		private Vector3 rootBasePosition; // 0x38
		private Vector2 m_advanceUv; // 0x48

		public int MaxValue { get; set; } // 0x44

		// RVA: 0x192115C Offset: 0x192115C VA: 0x192115C
		private void Awake()
		{
			baseUvs = new List<Vector2[]>();
			writeUvs = new List<Vector2[]>();
			for(int i = 0; i < meshFilters.Length; i++)
			{
				baseUvs.Add(new Vector2[meshFilters[i].mesh.uv.Length]);
				writeUvs.Add(new Vector2[meshFilters[i].mesh.uv.Length]);
				System.Array.Copy(meshFilters[i].mesh.uv, baseUvs[i], baseUvs[i].Length);
				System.Array.Copy(meshFilters[i].mesh.uv, writeUvs[i], writeUvs[i].Length);
			}
			MaxValue = System.Int32.MaxValue;
			SetNumber(0, 0);
			width = meshFilters[0].mesh.bounds.max.x - meshFilters[0].mesh.bounds.min.x;
			if(rootObject != null)
			{
				rootBasePosition = rootObject.transform.localPosition;
			}
			if(meshFilters.Length != 0)
			{
				Texture tex = meshFilters[0].GetComponent<Renderer>().sharedMaterial.mainTexture;
				m_advanceUv = new Vector2(uvXAdvance * 1.0f / tex.width, uvYAdvance * 1.0f / tex.height);
			}
		}

		// RVA: 0x1921938 Offset: 0x1921938 VA: 0x1921938
		public void SetNumber(int number, int type = 0)
		{
			int idx = 0;
			if(meshFilters.Length >= 1)
			{
				if(number > MaxValue)
					number = MaxValue;
				for(idx = 0; idx < meshFilters.Length; idx++)
				{
					int col, row;
					meshFilters[idx].gameObject.SetActive(true);
					if(number < 1)
					{
						if(idx > 0 && !isZeroPadding)
							break;
						if(!useSpecialCaracter)
						{
							col = 0;
							row = type * 10 / lineCount;
						}
						else
						{
							col = specialCaracterColumn;
							row = specialCaracterRow;
						}
					}
					else
					{
						col = (number % 10) % lineCount;
						row = type * 10 / lineCount + (number % 10) / lineCount;
					}
					SetUv(idx, col, row);
					number /= 10;
				}
			}
			if(isCentering)
			{
				if(rootObject != null)
				{
					rootObject.transform.localPosition = new Vector3(rootBasePosition.x - (width * 0.5f - ((width * 0.5f) * (idx - 1) / (meshFilters.Length - 1))), rootBasePosition.y, rootBasePosition.z);
				}
			}
			for(; idx < meshFilters.Length; idx++)
			{
				meshFilters[idx].gameObject.SetActive(false);
			}
		}

		// // RVA: 0x1921C7C Offset: 0x1921C7C VA: 0x1921C7C
		// private void Set(int index, int value, int type = 0) { }

		// // RVA: 0x1921CD4 Offset: 0x1921CD4 VA: 0x1921CD4
		private void SetUv(int index, int col, int row)
		{
			Vector2 v = new Vector2(m_advanceUv.x * col, m_advanceUv.y * row);
			for(int i = 0; i < baseUvs[index].Length; i++)
			{
				writeUvs[index][i] = baseUvs[index][i] + v;
			}
			meshFilters[index].mesh.uv = writeUvs[index];
		}
	}
}
