using UnityEngine;

namespace XeApp.Game.UI
{
	public class NumericMeshMultiPolygon : MonoBehaviour
	{
		[SerializeField]
		private MeshFilter meshFilter; // 0xC
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
		private Vector2[] baseUvs; // 0x2C
		private Vector2[] writeUvs; // 0x30
		private int[] indexTopArray; // 0x34
		private byte digit; // 0x38
		private float width; // 0x3C
		private Vector3 rootBasePosition; // 0x40
		private Vector2 m_advanceUv; // 0x50
		private bool dirtyUpdateUv = true; // 0x58
		private const int VertexSize = 4;

		public int MaxValue { get; set; } // 0x4C

		// RVA: 0x1921FE4 Offset: 0x1921FE4 VA: 0x1921FE4
		private void Awake()
		{
			baseUvs = new Vector2[meshFilter.mesh.uv.Length];
			writeUvs = new Vector2[meshFilter.mesh.uv.Length];
			System.Array.Copy(meshFilter.mesh.uv, baseUvs, baseUvs.Length);
			System.Array.Copy(meshFilter.mesh.uv, writeUvs, writeUvs.Length);
			MaxValue = System.Int32.MaxValue;
			digit = (byte)(baseUvs.Length / 4);
			indexTopArray = new int[digit];
			for(int i = 0; i < digit; i++)
			{
				indexTopArray[i] = i * 4;
			}
			System.Array.Sort(indexTopArray, (int left, int right) => {
				//0x1922C60
				return meshFilter.mesh.vertices[left].x > meshFilter.mesh.vertices[right].x ? -1 : 1;
			});
			width = Mathf.Abs(meshFilter.mesh.vertices[0].x - meshFilter.mesh.vertices[3].x);
			if(rootObject != null)
			{
				rootBasePosition = rootObject.transform.localPosition;
			}
			if(meshFilter != null)
			{
				Texture tex = meshFilter.GetComponent<Renderer>().sharedMaterial.mainTexture;
				m_advanceUv = new Vector2(uvXAdvance * 1.0f / tex.width, uvYAdvance * 1.0f / tex.height);
			}
			SetNumber(0, 0);
		}

		// // RVA: 0x1922638 Offset: 0x1922638 VA: 0x1922638
		public void SetNumber(int number, int type = 0)
		{
			int idx = 0;
			if(digit != 0)
			{
				if(number > MaxValue)
					number = MaxValue;
				for(idx = 0; idx < digit; idx++)
				{
					int col = 0;
					int row = 0;
					if(number < 1)
					{
						if(0 < idx && !isZeroPadding)
							break;
						if(!useSpecialCaracter)
						{
							row = 10 / lineCount;
							col = 0;
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
						row = 10 / lineCount * type + (number % 10) / lineCount;
					}
					SetUv(idx, col, row);
					number /= 10;
				}
			}
			if(isCentering)
			{
				if(rootObject != null)
				{
					rootObject.transform.localPosition = new Vector3(
						rootBasePosition.x - (width * 0.25f - (width * 0.25f * (idx - 1)) / (digit - 1)),
						rootBasePosition.y, rootBasePosition.z
					);
				}
			}
			for(; idx < digit; idx++)
			{
				SetOffUv(idx);
			}
		}

		// // RVA: 0x1922894 Offset: 0x1922894 VA: 0x1922894
		// private void Set(int index, int value, int type = 0) { }

		// // RVA: 0x19228EC Offset: 0x19228EC VA: 0x19228EC
		private void SetUv(int index, int col, int row)
		{
			Vector2 v = new Vector2(m_advanceUv.x * col, m_advanceUv.y * row);
			for(int i = 0; i < 4; i++)
			{
				writeUvs[i + indexTopArray[index]] = baseUvs[i + indexTopArray[index]] + v;
			}
			dirtyUpdateUv = true;
		}

		// // RVA: 0x1922B08 Offset: 0x1922B08 VA: 0x1922B08
		private void SetOffUv(int index)
		{
			Vector2 v = new Vector2(0, m_advanceUv.x * lineCount);
			for(int i = 0; i < 4; i++)
			{
				writeUvs[i + indexTopArray[index]] = v;
			}
			dirtyUpdateUv = true;
		}

		// RVA: 0x1922BE4 Offset: 0x1922BE4 VA: 0x1922BE4
		private void LateUpdate()
		{
			if(!dirtyUpdateUv)
				return;
			meshFilter.mesh.uv = writeUvs;
			dirtyUpdateUv = false;

		}
	}
}
