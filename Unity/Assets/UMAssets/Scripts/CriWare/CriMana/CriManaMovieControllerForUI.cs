/****************************************************************************
 *
 * CRI Middleware SDK
 *
 * Copyright (c) 2015 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

using UnityEngine;

/**
 * \addtogroup CRIMANA_UNITY_COMPONENT
 * @{
 */

/**
 * <summary>Unity UI上でムービを再生するためのコンポーネントです。</summary>
 * \par 説明:
 * Unity UI上でムービを再生するためのコンポーネントです。<br/>
 * UnityEngine.UI.Graphic にマテリアルを設定することで、ムービを表示します。<br/>
 * CriManaMovieMaterial を継承しています。<br/>
 * \par 注意:
 * 本クラスでは、再生・停止・ポーズの基本操作しか行えません。<br/>
 * 複雑な再生制御を行う場合は、playerプロパティでコアプレーヤに対して操作を行って下さい。<br/>
 */
[AddComponentMenu("CRIWARE/CriManaMovieControllerForUI")]
public class CriManaMovieControllerForUI : CriManaMovieMaterial
{
	#region Properties
	/**
	 * <summary>ムービマテリアルの設定対象の UnityEngine.UI.Graphic です。</summary>
	 * \par 説明:
	 * ムービマテリアルの設定対象の UnityEngine.UI.Graphic です。<br/>
	 * 指定されていない場合はアタッチしているゲームオブジェクトの UnityEngine.UI.Graphic を使用します。
	 */
	public UnityEngine.UI.Graphic	target;


	/**
	 * <summary>ムービフレームが使用できない場合にオリジナルのマテリアルを表示するか。</summary>
	 * \par 説明:
	 * ムービフレームが使用できない場合にオリジナルのマテリアルを表示するか。<br/>
	 * true : ムービフレームが使用できない場合、オリジナルのマテリアルを表示します。<br/>
	 * false : ムービフレームが使用できない場合、target の描画を無効にします。<br/>
	 */	
	public bool						useOriginalMaterial;
	#endregion


	#region Internal Variables
	private Material	originalMaterial;
	#endregion
	
	
	protected override void Start()
	{
		base.Start();
		if (target == null) {
			target = gameObject.GetComponent<UnityEngine.UI.Graphic>();
		}
		if (target == null) {
			Debug.LogError("[CRIWARE] error");
			Destroy(this);
			return;
		}
		originalMaterial = target.material;
		if (!useOriginalMaterial) {
			target.enabled = false;
		}
	}
	
	
	protected override void OnDestroy()
	{
		target.material = originalMaterial;
		if (!useOriginalMaterial) {
			target.enabled = false;
		}
		originalMaterial = null;
		base.OnDestroy();
	}
	
	
	protected override void OnMaterialAvailableChanged()
	{
		if (isMaterialAvailable) {
			target.material	= material;
			target.enabled	= true;
		} else {
			target.material = originalMaterial;
			if (!useOriginalMaterial) {
				target.enabled = false;
			}
		}
	}
}

/**
 * @}
 */


/* end of file */
