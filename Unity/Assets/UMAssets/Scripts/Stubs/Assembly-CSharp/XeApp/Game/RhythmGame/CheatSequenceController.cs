using UnityEngine;

namespace XeApp.Game.RhythmGame
{
	public class CheatSequenceController : MonoBehaviour
	{
		[SerializeField]
		private float fasterSpeedValue;
		[SerializeField]
		private float skipSecond;
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement Monobehaviour");
		}
	}
}
