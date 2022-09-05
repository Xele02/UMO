using System;
using System.Collections.Generic;
using CriWare;
using CriWare.CriMana;
using UnityEngine;

namespace XeApp.Core
{
	public class WarmupTextures : MonoBehaviour
	{
		[SerializeField]
		private GameObject spritePrefab; // 0xC
		private List<Texture> textures = new List<Texture>(); // 0x10
		private List<MeshRenderer> meshRenderers; // 0x14
		private int oneFrameRenderMaxCount = 8; // 0x18
		private int currentPosition; // 0x1C
		private Action onFinish; // 0x20
		private CriManaMovieController moviePlayer; // 0x24
		private bool isMoveMode; // 0x28
		private int step; // 0x2C

		// RVA: 0x1D78BF0 Offset: 0x1D78BF0 VA: 0x1D78BF0
		public void Initialize(GameObject rootObj, Action onFinish)
		{
			Renderer[] renderers = rootObj.GetComponentsInChildren<Renderer>();
			for(int i = 0; i < renderers.Length; i++)
			{
				Material[] mats = renderers[i].materials;
				for(int j = 0; j < mats.Length; j++)
				{
					if(mats[j].HasProperty("_MainTex"))
					{
						if(mats[j].mainTexture != null)
						{
							textures.Add(mats[j].mainTexture);
						}
					}
				}
			}
			Debug.Log("<color=cyan>textures "+ textures.Count + " count.</color>");
			int capacity = oneFrameRenderMaxCount;
			if (capacity >= textures.Count)
			{
				capacity = textures.Count;
			}
			GameObject sprite = Instantiate<GameObject>(spritePrefab);
			meshRenderers = new List<MeshRenderer>(capacity);
			for(int i = 0; i < capacity; i++)
			{
				GameObject newSprite = Instantiate<GameObject>(sprite, new Vector3(0, 0, -100), Quaternion.identity, transform);
				meshRenderers.Add(newSprite.GetComponent<MeshRenderer>());
			}
			currentPosition = 0;
			this.onFinish = onFinish;
			Destroy(sprite);
		}

		// RVA: 0x1D79234 Offset: 0x1D79234 VA: 0x1D79234
		//public void InitializeMovie(CriManaMovieController controller, Action onFinish) { }

		// RVA: 0x1D794E8 Offset: 0x1D794E8 VA: 0x1D794E8
		private void Update()
		{
			if(!isMoveMode)
			{
				if(textures != null)
				{
					int numToDo = textures.Count - currentPosition;
					if (numToDo > oneFrameRenderMaxCount)
						numToDo = oneFrameRenderMaxCount;
					if (textures.Count > currentPosition)
					{
						for(int i = 0; i < numToDo; i++)
						{
							meshRenderers[i].material.mainTexture = textures[currentPosition + i];
						}
						currentPosition += numToDo;
					}
					else
					{
						if (onFinish != null)
							onFinish();
						Debug.Log("<color=cyan>WarmupTextures finish " + textures.Count+ "</color>");
						Destroy(gameObject);
					}
				}
			}
			else
			{
				switch(step)
				{
					case 0:
					Debug.Log("<color=cyan>movie play</color>");
					moviePlayer.Play();
					break;
					case 1:
					if(moviePlayer.player.status != Player.Status.Playing)
						return;
					Debug.Log("<color=cyan>movie playing</color>");
					break;
					case 2:
					Debug.Log("<color=cyan>movie stop</color>");
					moviePlayer.Stop();
					break;
					case 3:
					if(moviePlayer.player.status != Player.Status.Stop)
						return;
					Debug.Log("<color=cyan>movie seek</color>");
					moviePlayer.player.SetSeekPosition(0);
					break;
					case 4:
					Debug.Log("<color=cyan>movie fin</color>");
					if(onFinish != null)
						onFinish();
					Destroy(gameObject);
					break;
					default:
					return;
				}
				step = step + 1;
			}
		}
	}
}
