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
 * <summary>ムービをマテリアルに流し込むためのコンポーネントです。</summary>
 * \par 説明:
 * ムービをマテリアルに流し込むためのコンポーネントです。<br/>
 * ムービ再生、描画コンポーネントの基本クラスです。<br/>
 * 本クラスを継承することで、任意の描画対象にムービを描画することが可能です。<br/>
 * 本コンポーネントはムービをマテリアルに流し込むだけなので、貼り付けて使用しても何も表示されません。<br/>
 * 通常はムービを表示したいオブジェクトにあわせて、 CriManaMovieController や、 CriManaMovieControllerForUI コンポーネントを使用してください。<br/>
 * \par 注意:
 * 本クラスでは、再生・停止・ポーズの基本操作しか行えません。<br/>
 * 複雑な再生制御を行う場合は、playerプロパティでコアプレーヤに対して操作を行って下さい。<br/>
 */
[AddComponentMenu("CRIWARE/CriManaMovieMaterial")]
public class CriManaMovieMaterial : MonoBehaviour
{
	#region Properties
	/**
	 * <summary>Start 時のストリーミング再生用のファイルパスです。</summary>
	 * <param name="filePath">ファイルパス</param>
	 * \par 説明:
	 * Start 時のストリーミング再生用のファイルパスです。<br/>
	 * - 相対パスを指定した場合は StreamingAssets フォルダからの相対でファイルをロードします。
	 * - 絶対パス、あるいはURLを指定した場合には指定したパスでファイルをロードします。
	 */
	public string	moviePath;

	/**
	 * <summary>Start 時に再生を行うかを設定します。</summary>
	 * \par 説明:
	 * Start 時に再生を行うかを設定します。デフォルト false です。
	 */
	public bool		playOnStart		= false;

	/**
	 * <summary>Start 時のムービ再生のループ設定です。</summary>
	 * \par 説明:
	 * Start 時のムービ再生のループ設定です。デフォルトは false です。
	 */
	public bool		loop			= false;

	/**
	 * <summary>Start 時の加算合成モード設定です。</summary>
	 * \par 説明:
	 * Start 時の加算合成モード設定です。デフォルトは false です。
	 */
	public bool		additiveMode	= false;

	/**
	 * <summary>CriManaMovieMaterial::material でムービフレームが描画できるかどうか</summary>
	 * \par 説明:
	 * CriManaMovieMaterial::material でムービフレームが描画できるかどうかです。
	 */
	public bool isMaterialAvailable { get; private set; }

	/**
	 * <summary>再生制御プレーヤ</summary>
	 * \par 説明:
	 * ムービの細やかな再生制御を行うためのプレーヤプロパティです。<br/>
	 * 停止・ポーズなどの基本制御以上の操作を行いたい場合、本プロパティ経由で、 CriMana::Player APIを使用してください。
	 */
	public CriMana.Player player { get; private set; }

	/**
	 * <summary>ムービを流し込むマテリアルを設定します。</summary>
	 * \par 説明:
	 * マテリアルを設定すると、設定されたマテリアルにムービが流し込まれます。
	 * マテリアルを設定しない場合は、ムービを流し込むマテリアルを生成します。<br/>
	 * \par 注意:
	 * マテリアルを設定する場合、 Start メソッドが呼びだされる前に設定する必要があります。
	 */
	public Material material
	{
		get
		{
			return _material;
		}
		set
		{
			if (value != _material) {
				if (materialOwn) {
					Destroy(_material);
				}
				_material = value;
				isMaterialAvailable = false;
			}
		}
	}
	#endregion


	#region Internal Variables
	[SerializeField]
	private Material	_material;
	private bool		materialOwn = true;	
	private bool		unpauseOnApplicationUnpause = false;
	#endregion


	/**
	 * <summary>再生を開始します。</summary>
	 * \par 説明:
	 * ムービ再生を開始します。<br/>
	 * 再生が開始されると、状態は \link CriMana::Player::Status.Playing \endlink になります。
	 * \par 注意:
	 * 本関数を呼び出し後、実際にムービの描画が開始されるまで数フレームかかります。</br>
	 * ムービ再生の頭出しを行いたい場合は本関数をを使わず、 player プロパティにアクセスし、CriMana::Player::Prepare 関数で事前に再生準備を行ってください。
	 * \sa CriManaMovieMaterial::Stop, CriMana::Player::Status
	 */
	public void Play()
	{
		player.Start();
	}


	/**
	 * <summary>ムービ再生の停止要求を行います。</summary>
	 * \par 説明:
	 * ムービ再生の停止要求を出します。本関数は即時復帰関数です。<br/>
	 * 本関数を呼び出すと、描画は即座に終了しますが、再生はすぐには止まりません。<br/>
	 * \sa CriMana::Player::Status
	 */
	public void Stop()
	{
		player.Stop();
	}
	


	/**
	 * <summary>ムービ再生のポーズ切り替えを行います。</summary>
	 * <param name="sw">ポーズスイッチ(true: ポーズ, false: ポーズ解除)</param>
	 * \par 説明:
	 * ポーズのON/OFFを切り替えます。<br/>
	 * 引数にtrueを指定する一時停止、falseを指定すると再生再開です。<br/>
	 * CriManaMovieMaterial::Stop 関数を呼び出すと、ポーズ状態は解除されます <br/>
	 */
	public void Pause(bool sw)
	{
		player.Pause(sw);
	}


	/**
	 * <summary>isMaterialAvailable プロパティが変化した際に呼び出されるメソッドです。</summary>
	 * \par 説明:
	 * isMaterialAvailable プロパティが変化した際に呼び出されるメソッドです。<br>
	 * 継承先でオーバーライドすることを想定しています。<br>
	 */
	protected virtual void OnMaterialAvailableChanged()
	{
	}


	/**
	 * <summary>マテリアルに新しいフレームが流し込まれた際に呼び出されるメソッドです。</summary>
	 * \par 説明:
	 * マテリアルに新しいフレームが流し込まれた際に呼び出されるメソッドです。<br>
	 * 継承先でオーバーライドすることを想定しています。<br>
	 */
	protected virtual void OnMaterialUpdated()
	{
	}


	#region MonoBehavior Inherited Methods
	protected virtual void Awake()
	{
		player = new CriMana.Player();
		isMaterialAvailable = false;
	}
	
	
	protected virtual void OnEnable()
	{
	}
	
	
	protected virtual void OnDestroy()
	{
		player.Dispose();
		player = null;
		material = null;
	}
	
	
	protected virtual void Start()
	{
		if (_material == null) {
			CreateMaterial();
		}
		if (moviePath != null) {
			player.SetFile(null, moviePath);
		}
		player.Loop(loop);
		player.additiveMode = additiveMode;
		if (playOnStart) {
			player.Start();
		}

		if (CriManaPlugin.isMultithreadedRenderingEnabled) {
			StartCoroutine(CallPluginAtEndOfFrames());
		}
	}
	
	
	protected virtual void Update()
	{
		player.Update();
		bool isMaterialAvailableCurrent;
		if (player.isFrameAvailable) {
			isMaterialAvailableCurrent = player.UpdateMaterial(material);
			if (isMaterialAvailableCurrent) {
				OnMaterialUpdated();
			}
		} else {
			isMaterialAvailableCurrent = false;
		}
		if (isMaterialAvailable != isMaterialAvailableCurrent) {
			isMaterialAvailable = isMaterialAvailableCurrent;
			OnMaterialAvailableChanged();
		}
	}
	
	
	protected virtual void OnApplicationPause(bool appPause)
	{
		if (appPause) {
			unpauseOnApplicationUnpause = !player.IsPaused();
			if (unpauseOnApplicationUnpause) {
				player.Pause(true);
			}
		}
		else {
			if (unpauseOnApplicationUnpause) {
				player.Pause(false);
			}
			unpauseOnApplicationUnpause = false;
		}
	}
	
	
	protected virtual void OnDrawGizmos()
	{
		if ((player != null) && (player.status == CriMana.Player.Status.Playing)) {
			Gizmos.color = new Color(1.0f, 1.0f, 1.0f, 0.8f);
		}
		else {
			Gizmos.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
		}
		
		Gizmos.DrawIcon(this.transform.position, "CriWare/film.png");
		Gizmos.DrawLine(this.transform.position, new Vector3(0, 0, 0));
	}
	#endregion


	#region Private Methods
	private void CreateMaterial()
	{
		_material      = new Material(Shader.Find("VertexLit"));
		_material.name = "CriMana-MovieMaterial";
		materialOwn = true;
	}


	private System.Collections.IEnumerator CallPluginAtEndOfFrames()
	{
		while (true)
		{
			yield return new WaitForEndOfFrame();
			player.IssuePluginEvent();
		}
	}
	#endregion
}


/**
 * @}
 */


/* end of file */
