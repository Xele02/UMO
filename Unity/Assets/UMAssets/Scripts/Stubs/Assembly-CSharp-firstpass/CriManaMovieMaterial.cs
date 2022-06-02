using UnityEngine;

public class CriManaMovieMaterial : CriMonoBehaviour
{
	public enum RenderMode
	{
		Always = 0,
		OnVisibility = 1,
		Never = 2,
	}

	public enum MaxFrameDrop
	{
		Disabled = 0,
		One = 1,
		Two = 2,
		Three = 3,
		Four = 4,
		Five = 5,
		Six = 6,
		Seven = 7,
		Eight = 8,
		Nine = 9,
		Ten = 10,
		Infinite = -1,
	}

	public bool playOnStart;
	public bool restartOnEnable;
	public RenderMode renderMode;
	[SerializeField]
	private Material _material;
	[SerializeField]
	private string _moviePath;
	[SerializeField]
	private bool _loop;
	[SerializeField]
	private MaxFrameDrop _maxFrameDrop;
	[SerializeField]
	private bool _additiveMode;
	[SerializeField]
	private bool _advancedAudio;
	[SerializeField]
	private bool _ambisonics;
	[SerializeField]
	private bool _applyTargetAlpha;
	[SerializeField]
	private bool _uiRenderMode;
}
