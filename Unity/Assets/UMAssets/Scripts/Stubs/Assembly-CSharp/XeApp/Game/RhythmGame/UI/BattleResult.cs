using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class BattleResult : MonoBehaviour
	{
		[SerializeField]
		private Animator _animator;
		[SerializeField]
		private MeshRenderer _playerMesh;
		[SerializeField]
		private MeshRenderer _rivalMesh;
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement Monobehaviour");
		}
	}
}
