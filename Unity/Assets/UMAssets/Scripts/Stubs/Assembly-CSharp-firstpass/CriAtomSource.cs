using UnityEngine;

public class CriAtomSource : CriMonoBehaviour
{
	[SerializeField]
	private bool _playOnStart;
	[SerializeField]
	private string _cueName;
	[SerializeField]
	private string _cueSheet;
	[SerializeField]
	private CriAtomRegion _regionOnStart;
	[SerializeField]
	private CriAtomListener _listenerOnStart;
	[SerializeField]
	private bool _use3dPositioning;
	[SerializeField]
	private bool _freezeOrientation;
	[SerializeField]
	private bool _loop;
	[SerializeField]
	private float _volume;
	[SerializeField]
	private float _pitch;
	[SerializeField]
	private bool _androidUseLowLatencyVoicePool;
	[SerializeField]
	private bool need_to_player_update_all;
	[SerializeField]
	private bool _use3dRandomization;
	[SerializeField]
	private uint _randomPositionListMaxLength;
	[SerializeField]
	private CriAtomEx.Randomize3dConfig randomize3dConfig;
}
