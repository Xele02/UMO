/****************************************************************************
 *
 * Copyright (c) 2020 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

using System;
using UnityEngine;

/**
 * \addtogroup CRIATOM_UNITY_COMPONENT
 * @{
 */

namespace CriWare {

/**
 * <summary>トランシーバーコンポーネント</summary>
 * <remarks>
 * <para header='説明'>空間音響接続機能を提供するコンポーネントです。3Dポジショニングが有効な音声をサブミックスして、一点から出力します。<br/>
 * 本コンポーネントは任意のGameObjectに付加して使用します。<br/>
 * 機能を有効にするには音源、リスナー及びトランシーバーに CriAtomRegion を設定する必要があります。<br/>
 * トランシーバーのパラメータはすべてインスペクタで、<br/>
 * 若しくは内蔵の CriAtomEx3dTransceiver のメンバー関数を通して設定できます。<br/>
 * トランシーバーの位置・向き情報はすべて取り付けたGameObjectの値を使用します。<br/>
 * また、「Use Dedicated Input」が有効になっている場合、<br/>
 * 別設定されたGameObjectの位置・向きがトランシーバー入力に使われます。<br/>
 * 本コンポーネントは一つのGameObjectに一つのみ取り付けられます。</para>
 * </remarks>
 * <seealso cref='CriAtomRegion'/>
 */
[AddComponentMenu("CRIWARE/CRI Atom Transceiver"), DisallowMultipleComponent]
public class CriAtomTransceiver : CriMonoBehaviour
{
	#region Fields & Properties
	/**
	 * <summary>内部で使用している CriAtomEx3dTransceiver です。</summary>
	 * <remarks>
	 * <para header='説明'>CriAtomEx3dTransceiver を直接制御する場合にはこのプロパティから CriAtomEx3dTransceiver を取得してください。</para>
	 * </remarks>
	 */
	public CriAtomEx3dTransceiver transceiverHn { get; protected set; }
	/** <summary>トランシーバー入力の位置（リードオンリー）</summary> */
	public Vector3 inputPos { get; private set; }
	/** <summary>トランシーバー入力の前方ベクトル（リードオンリー）</summary> */
	public Vector3 inputFront { get; private set; }
	/** <summary>トランシーバー入力の上方ベクトル（リードオンリー）</summary> */
	public Vector3 inputUp { get; private set; }
	/**
	 * <summary>音源の3Dリージョンの設定及び取得</summary>
	 */
	public CriAtomRegion region3d
	{
		get { return this.currentRegion; }
		set {
			CriAtomEx3dRegion regionHandle = (value == null) ? null : value.region3dHn;
			if (this.transceiverHn != null) {
				this.transceiverHn.Set3dRegion(regionHandle);
				this.transceiverHn.Update();
				this.currentRegion = value;
			} else {
				Debug.LogError("[CRIWARE] Internal: The Transcevier is not initialized correctly.");
				this.currentRegion = null;
			}
		}
	}

	[SerializeField] private CriAtomRegion regionOnStart = null;
	[SerializeField] private bool useDedicatedInput = false;
	[SerializeField] private GameObject dedicatedInput = null;
	[SerializeField, Range(0, 1f)] private float outputVolume = 1f;
	[SerializeField] private float directAudioRadius = 0;
	[SerializeField] private float crossFadeDistance = 10f;
	[SerializeField, Range(0, 360f)] private float coneInsideAngle = 360f;
	[SerializeField, Range(0, 360f)] private float coneOutsideAngle = 360f;
	[SerializeField, Range(0, 1f)] private float coneOutsideVolume = 0f;
	[SerializeField] private float transceiverRadius = 1f;
	[SerializeField] private float interiorDistance = 3f;
	[SerializeField] public float minAttenuation = 1f;
	[SerializeField] public float maxAttenuation = 100f;

	[SerializeField] private string globalAisacName = string.Empty;
	[SerializeField] private float maxAngleAisacDelta = 1f;
	[SerializeField] private string distanceAisacControlId = string.Empty;
	[SerializeField] private string listenerAzimuthAisacControlId = string.Empty;
	[SerializeField] private string listenerElevationAisacControlId = string.Empty;
	[SerializeField] private string outputAzimuthAisacControlId = string.Empty;
	[SerializeField] private string outputElevationAisacControlId = string.Empty;

	[NonSerialized] public bool inspectorAisacSettingFoldout = false;

	private bool isInitialized = false;
	private bool dedicatedInputNotSetWarned = false;
	private CriAtomRegion currentRegion = null;
	#endregion

	#region Methods
	private void Awake()
	{
		this.InternalInitialize();
	}

	private void Start()
	{
		if (this.regionOnStart != null) {
			this.region3d = this.regionOnStart;
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		this.InitializeParameters();
	}

	private void OnDestroy()
	{
		this.InternalFinalize();
	}

	protected virtual void InternalInitialize()
	{
		CriAtomPlugin.InitializeLibrary();
		this.transceiverHn = new CriAtomEx3dTransceiver();
		this.isInitialized = true;
	}

	protected virtual void InternalFinalize()
	{
		this.isInitialized = false;
		transceiverHn.Dispose();
		transceiverHn = null;
		CriAtomPlugin.FinalizeLibrary();
	}

	protected virtual void InitializeParameters()
	{
		if (this.transceiverHn != null) {
			this.ApplyCurrentPosition();
			this.ApplyParameters();
		} else {
			Debug.LogError("[CRIWARE] Internal: CriAtomEx3dTranceiver is not created correctly.", this);
		}
	}

	public override void CriInternalUpdate() { }

	public override void CriInternalLateUpdate()
	{
		this.ApplyCurrentPosition();
	}

	private void ApplyCurrentPosition()
	{
		if (this.isInitialized == false || this.transceiverHn == null) { return; }

		Vector3 position = this.transform.position;
		Vector3 front = this.transform.forward;
		Vector3 up = this.transform.up;
		this.transceiverHn.SetOutputPosition(position);
		this.transceiverHn.SetOutputOrientation(front, up);

		if (this.useDedicatedInput) {
			if (this.dedicatedInput != null) {
				var listenerTransform = this.dedicatedInput.transform;
				this.inputPos = listenerTransform.position;
				this.inputFront = listenerTransform.forward;
				this.inputUp = listenerTransform.up;
			} else {
				if (dedicatedInputNotSetWarned == false) {
					Debug.LogWarning("[CRIWARE] " + this.GetType().ToString() + " : dedicated input is not specified. The output object will also be used as input.", this);
					this.dedicatedInputNotSetWarned = true;
				}
				this.inputPos = position;
				this.inputFront = -front;
				this.inputUp = up;
			}
		} else {
			this.inputPos = position;
			this.inputFront = -front;
			this.inputUp = up;
		}
		this.transceiverHn.SetInputPosition(this.inputPos);
		this.transceiverHn.SetInputOrientation(this.inputFront, this.inputUp);

		this.transceiverHn.Update();
	}

	private void ApplyParameters()
	{
		if (this.isInitialized == false || this.transceiverHn == null) { return; }

		this.transceiverHn.SetOutputVolume(this.outputVolume);
		this.transceiverHn.SetInputCrossFadeField(this.directAudioRadius, this.crossFadeDistance);
		this.transceiverHn.SetOutputConeParameter(this.coneInsideAngle, this.coneOutsideAngle, this.coneOutsideVolume);
		this.transceiverHn.SetOutputInteriorPanField(this.transceiverRadius, this.interiorDistance);
		this.transceiverHn.SetOutputMinMaxDistance(this.minAttenuation, this.maxAttenuation);

		if (string.IsNullOrEmpty(globalAisacName) == false) {
			this.transceiverHn.AttachAisac(globalAisacName);
		}
		this.transceiverHn.SetMaxAngleAisacDelta(this.maxAngleAisacDelta);
		TrySetAisacControlId(distanceAisacControlId, this.transceiverHn.SetDistanceAisacControlId);
		TrySetAisacControlId(listenerAzimuthAisacControlId, this.transceiverHn.SetListenerBasedAzimuthAngleAisacControlId);
		TrySetAisacControlId(listenerElevationAisacControlId, this.transceiverHn.SetListenerBasedElevationAngleAisacControlId);
		TrySetAisacControlId(outputAzimuthAisacControlId, this.transceiverHn.SetTransceiverOutputBasedAzimuthAngleAisacControlId);
		TrySetAisacControlId(outputElevationAisacControlId, this.transceiverHn.SetTransceiverOutputBasedElevationAngleAisacControlId);

		this.transceiverHn.Update();
	}

	private delegate void SetControlIdMethod(ushort id);
	private void TrySetAisacControlId(string strId, SetControlIdMethod callback)
	{
		if (string.IsNullOrEmpty(strId) == false) {
			ushort controlId;
			if (ushort.TryParse(strId, out controlId)) {
				callback.Invoke(controlId);
			} else {
				Debug.LogError("[CRIWARE] " + this.GetType().ToString() + " : invalid AISAC control ID.", this);
			}
		}
	}

#if UNITY_EDITOR
	public void OnDrawGizmos()
	{
		if (this.enabled == false) { return; }

		Gizmos.color = Color.green;
		Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.up);
		if (UnityEditor.Selection.activeGameObject != this.gameObject) {
			Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward);
			UnityEditor.Handles.color = Color.green;
			UnityEditor.Handles.ArrowHandleCap(0, this.transform.position + this.transform.forward, this.transform.rotation, 1f, EventType.Repaint);
			UnityEditor.Handles.CircleHandleCap(0, this.transform.position, this.transform.rotation * Quaternion.LookRotation(Vector3.up), 1f, EventType.Repaint);
		}

		if (this.useDedicatedInput && this.dedicatedInput != null) {
			var transformTarget = this.dedicatedInput.transform;
			Gizmos.color = Color.green;
			Gizmos.DrawLine(transformTarget.position, transformTarget.position + transformTarget.forward);
			Gizmos.DrawLine(transformTarget.position, transformTarget.position + transformTarget.up);
			UnityEditor.Handles.color = Color.green;
			UnityEditor.Handles.ArrowHandleCap(0, transformTarget.position + transformTarget.forward, transformTarget.rotation, 1f, EventType.Repaint);
			UnityEditor.Handles.RectangleHandleCap(0, transformTarget.position, transformTarget.rotation * Quaternion.LookRotation(Vector3.up), 1f, EventType.Repaint);
		}
	}
#endif
	#endregion
} // end of class

} //namespace CriWare
/** @} */
/* end of file */
