using System;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Core
{
	[Serializable]
	public class Pool<T> where T : PoolObject
	{
		public string name; // 0x0
		public T prefab; // 0x0
		public int capacity; // 0x0
		public bool worldPositionStays = true; // 0x0
		private List<T> mList; // 0x0
		private int mNext; // 0x0
		private GameObject mRootObject; // 0x0

		public GameObject RootObject { get { return mRootObject; } } //0x30A4EE4
		///* GenericInstMethod :
		//|
		//|-RVA:  Offset: 0x30A4EE4 VA: 0x30A4EE4
		//|-Pool<object>.get_RootObject
		//|-Pool<RNoteLong>.get_RootObject
		//|-Pool<RNoteSlide>.get_RootObject
		//|-Pool<RNoteSync>.get_RootObject
		//|-Pool<BattleEvaluateObject>.get_RootObject
		//*/

		public List<T> list { get { return mList; } set { return; } } //0x30A4EEC 0x30A4EF4
		//|-RVA:  Offset: 0x30A4EEC VA: 0x30A4EEC
		//|-Pool<object>.get_list
		//|-Pool<RNoteLong>.get_list
		//|-Pool<RNoteObject>.get_list
		//|-Pool<RNoteSingle>.get_list
		//|-Pool<RNoteSlide>.get_list
		//|-Pool<RNoteSync>.get_list
		//|-RVA:  Offset: 0x30A4EF4 VA: 0x30A4EF4
		//|-Pool<object>.set_list
		//*/

		//// RVA: -1 Offset: -1
		public void Create(string header, GameObject parent_, T prefab_, int capacity_, bool worldPositionStays_)
		{
			if(prefab_ != null)
			{
				mNext = 0;
				mList = new List<T>(capacity);
				string s = header + "Pool(" + prefab_.name + ")";
				RectTransform rt = prefab_.GetComponent<RectTransform>();
				if(rt != null)
				{
					mRootObject = new GameObject(s, new Type[] { typeof(RectTransform) });
					mRootObject.layer = 5;
				}
				else
				{
					mRootObject = new GameObject(s);
				}
				mRootObject.transform.SetParent(parent_.transform, false);
				for(int i = 0; i < capacity_; i++)
				{
					T p = UnityEngine.Object.Instantiate(prefab_);
					p.poolIndex = i;
					mList.Add(p);
					p.Create();
					p.gameObject.SetActive(false);
					p.gameObject.name = prefab_.name + "-" + i.ToString("D3");
					p.transform.SetParent(mRootObject.transform, false);
				}
			}
		}
		///* GenericInstMethod :
		//|
		//|-RVA: 0x30A4EF8 Offset: 0x30A4EF8 VA: 0x30A4EF8
		//|-Pool<object>.Create
		//|-Pool<TouchParticleObject>.Create
		//|-Pool<RNoteLong>.Create
		//|-Pool<RNoteObject>.Create
		//|-Pool<RNoteSingle>.Create
		//|-Pool<RNoteSlide>.Create
		//|-Pool<RNoteSync>.Create
		//|-Pool<BattleEvaluateObject>.Create
		//*/

		//// RVA: -1 Offset: -1
		//public void Create(GameObject parent_) { }
		///* GenericInstMethod :
		//|
		//|-RVA: 0x30A54B8 Offset: 0x30A54B8 VA: 0x30A54B8
		//|-Pool<object>.Create
		//*/

		//// RVA: -1 Offset: -1
		//public void Create(string header, GameObject parent_) { }
		///* GenericInstMethod :
		//|
		//|-RVA: 0x30A5570 Offset: 0x30A5570 VA: 0x30A5570
		//|-Pool<object>.Create
		//*/

		//// RVA: -1 Offset: -1
		//public void Create(string header, GameObject parent_, T prefab_, int capacity_) { }
		///* GenericInstMethod :
		//|
		//|-RVA: 0x30A55E4 Offset: 0x30A55E4 VA: 0x30A55E4
		//|-Pool<object>.Create
		//*/

		//// RVA: -1 Offset: -1
		public T Alloc()
		{
			for(int i = 0; i < mList.Count; i++)
			{
				int cur = mNext;
				mNext = XeSys.Math.Repeat(mNext + 1, 0, mList.Count - 1);
				if (!mList[cur].use)
				{
					mList[cur].Alloc();
					return mList[cur];
				}
			}
			return null;
		}
		///* GenericInstMethod :
		//|
		//|-RVA: 0x30A5660 Offset: 0x30A5660 VA: 0x30A5660
		//|-Pool<object>.Alloc
		//|-Pool<TouchParticleObject>.Alloc
		//|-Pool<RNoteLong>.Alloc
		//|-Pool<RNoteObject>.Alloc
		//|-Pool<RNoteSingle>.Alloc
		//|-Pool<RNoteSlide>.Alloc
		//|-Pool<RNoteSync>.Alloc
		//|-Pool<BattleEvaluateObject>.Alloc
		//*/

		//// RVA: -1 Offset: -1
		//public T AllocForce() { }
		///* GenericInstMethod :
		//|
		//|-RVA: 0x30A578C Offset: 0x30A578C VA: 0x30A578C
		//|-Pool<object>.AllocForce
		//|-Pool<TouchParticleObject>.AllocForce
		//*/

		//// RVA: -1 Offset: -1
		//public void FreeAll() { }
		///* GenericInstMethod :
		//|
		//|-RVA: 0x30A58F0 Offset: 0x30A58F0 VA: 0x30A58F0
		//|-Pool<object>.FreeAll
		//|-Pool<RNoteLong>.FreeAll
		//|-Pool<RNoteObject>.FreeAll
		//|-Pool<RNoteSingle>.FreeAll
		//|-Pool<RNoteSlide>.FreeAll
		//|-Pool<RNoteSync>.FreeAll
		//*/

		//// RVA: -1 Offset: -1
		public void Dispose()
		{
			if (mList == null)
				return;
			for(int i = 0; i < mList.Count; i++)
			{
				mList[i].Dispose();
			}
			mList.Clear();
			mList = null;
			UnityEngine.Object.Destroy(mRootObject);
		}
		///* GenericInstMethod :
		//|
		//|-RVA: 0x30A5A10 Offset: 0x30A5A10 VA: 0x30A5A10
		//|-Pool<object>.Dispose
		//|-Pool<TouchParticleObject>.Dispose
		//|-Pool<RNoteLong>.Dispose
		//|-Pool<RNoteObject>.Dispose
		//|-Pool<RNoteSingle>.Dispose
		//|-Pool<RNoteSlide>.Dispose
		//|-Pool<RNoteSync>.Dispose
		//*/

		//// RVA: -1 Offset: -1
		//public List<T> MakeUsingList() { }
		///* GenericInstMethod :
		//|
		//|-RVA: 0x30A5B60 Offset: 0x30A5B60 VA: 0x30A5B60
		//|-Pool<object>.MakeUsingList
		//*/

		//// RVA: -1 Offset: -1
		//public List<T> MakeUsingList(ref List<T> output) { }
		///* GenericInstMethod :
		//|
		//|-RVA: 0x30A5CE8 Offset: 0x30A5CE8 VA: 0x30A5CE8
		//|-Pool<object>.MakeUsingList
		//|-Pool<TouchParticleObject>.MakeUsingList
		//|-Pool<RNoteLong>.MakeUsingList
		//|-Pool<RNoteSingle>.MakeUsingList
		//|-Pool<RNoteSlide>.MakeUsingList
		//|-Pool<RNoteSync>.MakeUsingList
		//*/
	}
}
