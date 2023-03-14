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
		TodoLogger.Log(0, "Implement Monobehaviour");
	}
}
