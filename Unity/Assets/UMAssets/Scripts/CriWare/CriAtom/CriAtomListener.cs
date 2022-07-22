/****************************************************************************
 *
 * Copyright (c) 2011 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

using UnityEngine;
using System;
using System.Collections.Generic;

/**
 * \addtogroup CRIATOM_UNITY_COMPONENT
 * @{
 */

namespace CriWare {

/**
 * <summary>3Dリスナーを表すコンポーネントです。</summary>
 * <remarks>
 * <para header='説明'>通常、カメラやメインキャラクタのGameObjectに付与して使用します。
 * 現在位置の更新は自動的に行われるため、特に操作や設定を行う必要はありません。</para>
 * </remarks>
 */
[AddComponentMenu("CRIWARE/CRI Atom Listener")]
public class CriAtomListener : CriMonoBehaviour
{
	#region CRIWARE internals
	public static void CreateDummyNativeListener()
	{
		if (dummyNativeListener == null) {
			dummyNativeListener = new CriAtomEx3dListener();
		}
	}

	public static void DestroyDummyNativeListener()
	{
		if (dummyNativeListener != null) {
			dummyNativeListener.Dispose();
			dummyNativeListener = null;
		}
	}
	#endregion

	#region Fields & Properties
	/**
	 * <summary>内部で使用している CriAtomEx3dListener です。</summary>
	 * <remarks>
	 * <para header='説明'>CriAtom3dListener を直接制御する場合にはこのプロパティから CriAtom3dListener を取得してください。</para>
	 * </remarks>
	 */
	public CriAtomEx3dListener nativeListener { get; protected set; }

	[SerializeField] CriAtomRegion regionOnStart = null;

	/**
	 * <summary>OnEnable 時に排他的にアクティブリスナーにするか</summary>
	 * <remarks>
	 * <para header='説明'>true の場合、 OnEnable 時にアクティブリスナーになり、他のリスナーを非アクティブにします。
	 * false の場合、他のリスナーには影響せずにアクティブになります。</para>
	 * </remarks>
	 */
	public bool activateListenerOnEnable = false;

	/**
	 * <summary>CriAtomListenerがアクティブであるか</summary>
	 * <remarks>
	 * <para header='説明'>CriAtomListenrがアクティブである場合、CriAtomSourceによる音声のリスナーとして機能します。 <br/>
	 * CriAtomListenerが複数ある場合は、アクティブなリスナーのうち <br/>
	 * CriAtomSourceから最も近いリスナーを用いて3Dサウンドが計算されます。</para>
	 * </remarks>
	 */
	public bool isActive {
		get { return _isActive; }
		set {
			if (_isActive == value) return;
			_isActive = value;
			if (value)
				UpdatePosition();
			else {
				/* Make the listener unactive by setting far position. */
				nativeListener.SetPosition(float.MaxValue, float.MaxValue, float.MaxValue);
				nativeListener.Update();
			}
		}
	}

	/**
	 * <summary>音源の3Dリージョンの設定及び取得</summary>
	 */
	public CriAtomRegion region3d
	{
		get { return currentRegion; }
		set {
			CriAtomEx3dRegion regionHandle = (value == null) ? null : value.region3dHn;
			if (nativeListener != null) {
				nativeListener.Set3dRegion(regionHandle);
				nativeListener.Update();
				this.currentRegion = value;
			} else {
				Debug.LogError("[CRIWARE] Internal: CriAtomListener is not initialized correctly.");
				this.currentRegion = null;
			}
		}
	}
	#endregion

	#region Internal Variables
	static List<CriAtomListener> listenersList = new List<CriAtomListener>();

	/* Dummy listenr used when CriAtomListenr is not exists. */
	static CriAtomEx3dListener dummyNativeListener;

	private Vector3 lastPosition;
	private CriAtomRegion currentRegion = null;
	private bool _isActive = true;
	#endregion

	#region Functions
	private void Awake()
	{
		if (!listenersList.Contains(this))
			listenersList.Add(this);
		DestroyDummyNativeListener();
		nativeListener = new CriAtomEx3dListener();
		isActive = enabled;
	}

	private void Start()
	{
		if (regionOnStart != null) {
			region3d = this.regionOnStart;
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		ActivateListener(activateListenerOnEnable);
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		isActive = false;
	}

	private void OnDestroy()
	{
		if (listenersList.Contains(this))
			listenersList.Remove(this);
		nativeListener.Dispose();
		nativeListener = null;
	}

#if UNITY_EDITOR
	private void OnDrawGizmos() {
		if (this.enabled == false) { return; }
		var criWareLightBlue = new Color(0.332f, 0.661f, 0.991f);
		Gizmos.color = isActive || !Application.isPlaying ? criWareLightBlue : Color.gray;
		Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward);
		Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.up);
		UnityEditor.Handles.color = isActive || !Application.isPlaying ? criWareLightBlue : Color.gray;
		UnityEditor.Handles.ArrowHandleCap(1, this.transform.position + this.transform.forward, this.transform.rotation, 1f, EventType.Repaint);
		UnityEditor.Handles.RectangleHandleCap(1, this.transform.position, this.transform.rotation * Quaternion.LookRotation(Vector3.up), 1f, EventType.Repaint);
	}
#endif

	public override void CriInternalUpdate() { }

	public override void CriInternalLateUpdate()
	{
		if (isActive)
			UpdatePosition();
	}

	void UpdatePosition()
	{
		Vector3 position = this.transform.position;
		Vector3 velocity = (position - this.lastPosition) / Time.deltaTime;
		Vector3 front = this.transform.forward;
		Vector3 up = this.transform.up;
		this.lastPosition = position;
		if (nativeListener != null) {
			nativeListener.SetPosition(position.x, position.y, position.z);
			nativeListener.SetVelocity(velocity.x, velocity.y, velocity.z);
			nativeListener.SetOrientation(front.x, front.y, front.z, up.x, up.y, up.z);
			nativeListener.Update();
		}
	}
	#endregion

	/**
	 * <summary>アクティブリスナーにする</summary>
	 * <param name='exclusive'>アクティブリスナーをこのAtomListenerのみにするかどうか</param>
	 * <remarks>
	 * <para header='説明'>アクティブリスナーになると、 ::CriAtomSource の3Dリスナーとして動作します。</para>
	 * <para header='備考'>過去のプラグインとの互換性のため、引数無しで呼び出した場合は <br/>
	 * 呼び出し元のCriAtomListenerのみがアクティブとなります。</para>
	 * </remarks>
	 */
	public void ActivateListener(bool exclusive = true)
	{
		if (exclusive) {
			foreach (var listener in listenersList) {
				if (listener == this) continue;
				listener.isActive = false;
			}
		}
		isActive = true;
	}
} // end of class

} //namespace CriWare
/** @} */
/* end of file */
