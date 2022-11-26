using UnityEngine;

public class DebugCamera : MonoBehaviour
{
	[SerializeField]
	private float wheelSpeed;
	[SerializeField]
	private float moveSpeed;
	[SerializeField]
	private float rotateSpeed;
	private void Awake()
	{
		UnityEngine.Debug.LogError("Implement Monobehaviour");
	}
}
