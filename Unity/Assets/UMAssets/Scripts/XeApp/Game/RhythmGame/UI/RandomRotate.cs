using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class RandomRotate : MonoBehaviour
	{
		[SerializeField]
		private Transform[] _rotateTargets; // 0xC

		// RVA: 0x1560628 Offset: 0x1560628 VA: 0x1560628
		public void Do()
		{
			float r = Random.Range(0.0f, 360.0f);
			for(int i = 0; i < _rotateTargets.Length; i++)
			{
				_rotateTargets[i].localRotation = Quaternion.Euler(new Vector3(0, 0, r));
			}
		}
	}
}
