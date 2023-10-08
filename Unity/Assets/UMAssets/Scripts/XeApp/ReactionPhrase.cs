
using System;
using System.Collections;
using UnityEngine;
using XeApp.Core;

namespace XeApp
{ 
	internal class ReactionPhrase : MonoBehaviour
	{
		private GameObject glad; // 0xC
		private GameObject angry; // 0x10

		//// RVA: 0x1924038 Offset: 0x1924038 VA: 0x1924038
		public static ReactionPhrase Instantiate(Transform scaled, DecorationChara chara)
		{
			GameObject g = new GameObject("ReactionPhrase");
			ReactionPhrase rp = g.AddComponent<ReactionPhrase>();
			rp.gameObject.AddComponent<RectTransform>();
			rp.transform.SetParent(chara.GetObject().transform, false);
			rp.StartCoroutineWatched(rp.Co_LoadPhrase(9001, rp.transform, scaled, (GameObject rcv) =>
			{
				//0x1924768
				rp.glad = rcv;
			}));
			rp.StartCoroutineWatched(rp.Co_LoadPhrase(9002, rp.transform, scaled, (GameObject rcv) =>
			{
				//0x1924790
				rp.angry = rcv;
			}));
			rp.transform.localPosition += new Vector3(chara.Size.x, chara.Size.y, 0);
			return rp;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6ABB38 Offset: 0x6ABB38 VA: 0x6ABB38
		//// RVA: 0x19244D4 Offset: 0x19244D4 VA: 0x19244D4
		private IEnumerator Co_LoadPhrase(int id, Transform parent, Transform scaled, Action<GameObject> receive)
		{
			string bn;
			AssetBundleLoadAllAssetOperationBase op;

			//0x19247BC
			bn = DecorationConstants.DecoAssetPath + string.Format("sf/{0:D4}.xab", id);
			op = AssetBundleManager.LoadAllAssetAsync(bn);
			yield return op;
			GameObject g = op.GetAsset<GameObject>(string.Format("{0:D4}", id));
			if(g != null)
			{
				GameObject g2 = Instantiate(g, parent, false);
				g2.transform.localScale = scaled.transform.localScale;
				receive(g2);
			}
			AssetBundleManager.UnloadAssetBundle(bn, false);
		}

		// RVA: 0x19245CC Offset: 0x19245CC VA: 0x19245CC
		public void SetGlad(bool active)
		{
			if (glad != null)
				glad.SetActive(active);
		}

		//// RVA: 0x1924684 Offset: 0x1924684 VA: 0x1924684
		public void SetAngry(bool active)
		{
			if (angry != null)
				angry.SetActive(active);
		}

		//// RVA: 0x192473C Offset: 0x192473C VA: 0x192473C
		public void HideAll()
		{
			SetGlad(false);
			SetAngry(false);
		}
	}
}
