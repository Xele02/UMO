using System;

namespace XeApp.Core
{
	[Serializable]
	public class Pool<T>
	{
		public string name;
		public T prefab;
		public int capacity;
		public bool worldPositionStays;
	}
}
