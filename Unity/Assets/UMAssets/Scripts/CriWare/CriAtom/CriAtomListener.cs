/****************************************************************************
 *
 * CRI Middleware SDK
 *
 * Copyright (c) 2011-2015 CRI Middleware Co., Ltd.
 *
 * Library  : CRI Atom
 * Module   : CRI Atom for Unity
 * File     : CriAtomListener.cs
 *
 ****************************************************************************/
using UnityEngine;
using System;
using System.Collections;

/// \addtogroup CRIATOM_UNITY_COMPONENT
/// @{

/**
 * <summary>3Dリスナーを表すコンポーネントです。</summary>
 * \par 説明:
 * 通常、カメラやメインキャラクタのGameObjectに付与して使用します。
 * 現在位置の更新は自動的に行われるため、特に操作や設定を行う必要はありません。
 */
[AddComponentMenu("CRIWARE/CRI Atom Listener")]
public class CriAtomListener : MonoBehaviour
{
	#region CRIWARE internals
	public static CriAtomListener activeListener {
		get; private set;
	}

	public static CriAtomEx3dListener sharedNativeListener {
		get; private set;
	}
	
	public static void CreateSharedNativeListener()
	{
		if (sharedNativeListener == null) {
			sharedNativeListener = new CriAtomEx3dListener();
		}
	}

	public static void DestroySharedNativeListener()
	{
		if (sharedNativeListener != null) {
			sharedNativeListener.Dispose();
			sharedNativeListener = null;
		}
	}
	#endregion

	#region Variables
	/**
	 * <summary>OnEnable 時に常にアクティブリスナーにするか</summary>
	 * \par 説明:
	 * true の場合、 OnEnable 時に他のリスナーがアクティブな場合でもアクティブリスナーになります。
	 * false の場合、アクティブリスナーが存在しない場合のみアクティブリスナーになります。
	 */
	public bool activateListenerOnEnable = false;
	#endregion
	
	#region Internal Variables
	private Vector3 lastPosition;
	#endregion

	#region Functions
	void OnEnable()
	{
		if ((activeListener == null) || activateListenerOnEnable) {
			ActivateListener();
		}
	}

	void OnDisable()
	{
		if (activeListener == this) {
			if (sharedNativeListener != null) {
				sharedNativeListener.ResetParameters();
				sharedNativeListener.Update();
			}
			activeListener = null;
		}
	}

	void LateUpdate()
	{
		if (activeListener != this) {
			return;
		}
		Vector3 position = this.transform.position;
		Vector3 velocity = (position - this.lastPosition) / Time.deltaTime;
		Vector3 front    = this.transform.forward;
		Vector3 up       = this.transform.up;
		this.lastPosition = position;
		if (sharedNativeListener != null) {
			sharedNativeListener.SetPosition(position.x, position.y, position.z);
			sharedNativeListener.SetVelocity(velocity.x, velocity.y, velocity.z);
			sharedNativeListener.SetOrientation(front.x, front.y, front.z, up.x, up.y, up.z);
			sharedNativeListener.Update();
		}
	}
	#endregion
	
	/**
	 * <summary>アクティブリスナーにする</summary>
	 * \par 説明:
	 * アクティブリスナーになると、 ::CriAtomSource の3Dリスナーとして動作します。
	 */
	public void ActivateListener()
	{
		activeListener = this;

		Vector3 position = this.transform.position;
		Vector3 front    = this.transform.forward;
		Vector3 up       = this.transform.up;
		this.lastPosition = position;
		if (sharedNativeListener != null) {
			sharedNativeListener.SetPosition(position.x, position.y, position.z);
			sharedNativeListener.SetVelocity(0.0f, 0.0f, 0.0f);
			sharedNativeListener.SetOrientation(front.x, front.y, front.z, up.x, up.y, up.z);
			sharedNativeListener.Update();
		}
	}
} // end of class

/// @}
/* end of file */
