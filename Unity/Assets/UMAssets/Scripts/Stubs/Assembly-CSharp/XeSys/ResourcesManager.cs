using UnityEngine;

namespace XeSys
{
	public class ResourcesManager : SingletonMonoBehaviour<ResourcesManager>
	{
		[SerializeField]
		private int concurrentLimit;
	}
}
