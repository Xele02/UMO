using UnityEngine;
using System.Collections.Generic;

public class VFEffList : MonoBehaviour
{
	[SerializeField]
	private List<ParticleSystem> effcts;
	private void Awake()
	{
		TodoLogger.LogError(0, "Implement Monobehaviour");
	}
}
