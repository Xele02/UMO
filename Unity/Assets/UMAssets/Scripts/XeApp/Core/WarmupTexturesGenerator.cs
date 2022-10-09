using System;
using CriWare;
using UnityEngine;

namespace XeApp.Core
{
	public class WarmupTexturesGenerator : MonoBehaviour
	{
		[SerializeField]
		private GameObject prefab; // 0xC
		[SerializeField]
		private GameObject prefabMovie; // 0x10

		public static WarmupTexturesGenerator Instance { get; private set; } // 0x0

		// RVA: 0x1D79C08 Offset: 0x1D79C08 VA: 0x1D79C08
		private void Awake()
		{
			Instance = this;
		}

		// RVA: 0x1D79C6C Offset: 0x1D79C6C VA: 0x1D79C6C
		public void Create(GameObject rootObj, Action onFinish)
		{
			GameObject obj = UnityEngine.Object.Instantiate<GameObject>(prefab, Vector3.zero, Quaternion.identity);
			obj.GetComponent<WarmupTextures>().Initialize(rootObj, onFinish);
		}

		// RVA: 0x1D79DF8 Offset: 0x1D79DF8 VA: 0x1D79DF8
		public void CreateMovie(CriManaMovieController cont, Action onFinish)
		{
			GameObject go = Instantiate(prefabMovie, Vector3.zero, Quaternion.identity, transform);
			go.GetComponent<WarmupMovieTexture>().InitializeMovie(cont, onFinish);
		}
	}
}
