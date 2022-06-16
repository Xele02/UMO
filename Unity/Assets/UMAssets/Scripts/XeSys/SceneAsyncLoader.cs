using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace XeSys
{
	public class SceneAsyncLoader : MonoBehaviour
	{
		private string sceneName { get; set; } // 0xC
		public bool isLoaded { get; private set; } // 0x10

		// // RVA: 0x239F244 Offset: 0x239F244 VA: 0x239F244
		public static SceneAsyncLoader Create(string sceneName)
		{
			GameObject go = new GameObject("SceneAsyncLoader");
			SceneAsyncLoader sal = go.AddComponent<SceneAsyncLoader>();
			sal.sceneName = sceneName;
			return sal;
		}

		// // RVA: 0x239F308 Offset: 0x239F308 VA: 0x239F308
		private void Awake()
		{
			isLoaded = false;
		}

		// // RVA: 0x239F314 Offset: 0x239F314 VA: 0x239F314
		private void Start()
		{
			StartCoroutine("LoadLevel");
		}

		// // RVA: 0x239F37C Offset: 0x239F37C VA: 0x239F37C
		private void Update()
		{
			return;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6918EC Offset: 0x6918EC VA: 0x6918EC
		// // RVA: 0x239F380 Offset: 0x239F380 VA: 0x239F380
		private IEnumerator LoadLevel()
		{
			//0x239F438
			yield return SceneManager.LoadSceneAsync(sceneName);
			isLoaded = true;
		}
	}
}
