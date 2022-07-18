using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class DivaAwakenAuraSwitcher : MonoBehaviour
	{
		private List<GameObject> auraObjects = new List<GameObject>(); // 0xC

		// RVA: 0xE6D434 Offset: 0xE6D434 VA: 0xE6D434
		private void Awake()
		{
			auraObjects.Clear();
			EntryChildrenGameObject(transform, "_aura");
		}

		// RVA: 0xE6D630 Offset: 0xE6D630 VA: 0xE6D630
		public void Switch(bool on)
		{
			for(int i = 0; i < auraObjects.Count; i++)
			{
				auraObjects[i].SetActive(on);
			}
		}

		// RVA: 0xE6D4D4 Offset: 0xE6D4D4 VA: 0xE6D4D4
		private void EntryChildrenGameObject(Transform t, string targetName)
		{
			for(int i = 0; i < t.childCount; i++)
			{
				if(t.GetChild(i).name.Contains(targetName))
				{
					auraObjects.Add(t.gameObject);
				}
				else
				{
					EntryChildrenGameObject(t.GetChild(i), targetName);
				}
			}
		}
	}
}
