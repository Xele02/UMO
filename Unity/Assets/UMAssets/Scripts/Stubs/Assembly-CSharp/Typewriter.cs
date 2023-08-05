using UnityEngine;

public class Typewriter : MonoBehaviour
{
	public float delayBetweenSymbols;
	public AudioClip[] typeSoundEffects;
	public AudioSource audioSourceForTypeEffect;
	private void Awake()
	{
		TodoLogger.LogError(0, "Implement Monobehaviour");
	}
}
