using System.Collections;
using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class BattleResult : MonoBehaviour
	{
		[SerializeField]
		private Animator _animator; // 0xC
		[SerializeField]
		private MeshRenderer _playerMesh; // 0x10
		[SerializeField]
		private MeshRenderer _rivalMesh; // 0x14
		private Material _playerMaterial; // 0x18
		private Material _rivalMaterial; // 0x1C
		private int _playerDivaId; // 0x20
		private int _rivalDivaId; // 0x24
		private bool _isWaitWarmup; // 0x28
		private static readonly Vector2 UvOffset = new Vector2(0.25f, 0.1913f); // 0x0
		private static readonly int _playerWinTriggerHash = Animator.StringToHash("PlayerWin"); // 0x8
		private static readonly int _rivalWinTriggerHash = Animator.StringToHash("RivalWin"); // 0xC
		private static readonly int _idleStateHash = Animator.StringToHash("Idle"); // 0x10

		public bool IsWaitWarmup { get { return _isWaitWarmup; } } //0x1559B54

		// RVA: 0x1559B5C Offset: 0x1559B5C VA: 0x1559B5C
		private void Awake()
		{
			_playerMaterial = new Material(_playerMesh.material);
			_rivalMaterial = new Material(_rivalMesh.material);
			_playerMesh.material = _playerMaterial;
			_rivalMesh.material = _rivalMaterial;
		}

		// // RVA: 0x1559C90 Offset: 0x1559C90 VA: 0x1559C90
		public void SetPlayerDivaId(int divaId)
		{
			_playerDivaId = divaId;
		}

		// // RVA: 0x1559C98 Offset: 0x1559C98 VA: 0x1559C98
		public void SetRivalDivaId(int divaId)
		{
			_rivalDivaId = divaId;
		}

		// // RVA: 0x1559CA0 Offset: 0x1559CA0 VA: 0x1559CA0
		public void SetResult(bool isPlayerWin)
		{
			_playerMaterial.SetTextureOffset("_MainTex", MakeUv(_playerDivaId, isPlayerWin));
			_rivalMaterial.SetTextureOffset("_MainTex", MakeUv(_rivalDivaId, !isPlayerWin));
			_animator.SetTrigger(isPlayerWin ? _playerWinTriggerHash : _rivalWinTriggerHash);
		}

		// RVA: 0x1559F5C Offset: 0x1559F5C VA: 0x1559F5C
		public void SetWarmup()
		{
			_playerDivaId = 1;
			_rivalDivaId = 1;
			SetResult(true);
			_isWaitWarmup = true;
			this.StartCoroutineWatched(WaitWarmup());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x746EF4 Offset: 0x746EF4 VA: 0x746EF4
		// // RVA: 0x1559F9C Offset: 0x1559F9C VA: 0x1559F9C
		private IEnumerator WaitWarmup()
		{
			//0x155A150
			while(_animator.GetCurrentAnimatorStateInfo(0).shortNameHash != _idleStateHash)
				yield return null;
			_isWaitWarmup = false;
		}

		// // RVA: 0x1559E38 Offset: 0x1559E38 VA: 0x1559E38
		private Vector2 MakeUv(int divaId, bool isWin)
		{
			float x = (divaId - 1) / 5 * 0.5f;
			return new Vector2(isWin ? x : UvOffset.x + x, -UvOffset.y * ((divaId - 1) % 5));
		}
	}
}
