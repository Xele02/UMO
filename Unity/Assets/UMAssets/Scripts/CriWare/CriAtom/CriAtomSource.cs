/****************************************************************************
 *
 * Copyright (c) 2011 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

using UnityEngine;
using System;
using System.Collections;

/**
 * \addtogroup CRIATOM_UNITY_COMPONENT
 * @{
 */

namespace CriWare {

/**
 * <summary>音声再生を行うコンポーネントです。</summary>
 * <remarks>
 * <para header='説明'>任意のGameObjectに付加して使用します。<br/>
 * 再生するキューが3Dポジショニングを行うように設定されている場合、3D再生を行います。
 * この際、 ::CriAtomListener が付加されているGameObjectの位置との間で定位計算を行うため、
 * カメラやメインキャラクタに ::CriAtomListener を付加しておく必要があります。<br/>
 * Public変数は基本的にUnityEditor上で設定します。</para>
 * </remarks>
 */
[AddComponentMenu("CRIWARE/CRI Atom Source")]
public class CriAtomSource : CriMonoBehaviour
{
	#region Enumlators
	/**
	 * <summary>CriAtomSourceの再生状態を示す値です。</summary>
	 * <remarks>
	 * <para header='説明'>CriAtomSource::status プロパティにより取得できます。</para>
	 * </remarks>
	 */
	public enum Status
	{
		Stop,       /**< 停止中 */
		Prep,       /**< 再生準備中 */
		Playing,    /**< 再生中 */
		PlayEnd,    /**< 再生完了 */
		Error       /**< エラーが発生 */
	}
	#endregion

	#region Variables
	/**
	 * <summary>内部で使用している CriAtomExPlayer です。</summary>
	 * <remarks>
	 * <para header='説明'>CriAtomExPlayer を直接制御する場合にはこのプロパティから CriAtomExPlayer を取得してください。</para>
	 * </remarks>
	 */
	public CriAtomExPlayer player { protected set; get; }

	/**
	 * <summary>内部で使用している CriAtomEx3dSource です。</summary>
	 * <remarks>
	 * <para header='説明'>CriAtomEx3dSource を直接制御する場合にはこのプロパティから CriAtomEx3dSource を取得してください。</para>
	 * </remarks>
	 */
	public CriAtomEx3dSource source { protected set; get; }

	private bool initialized = false;
	private Vector3 lastPosition;
	private bool hasValidPosition = false;
	private CriAtomRegion currentRegion = null;
	private CriAtomListener currentListener = null;

	[SerializeField]
	private bool _playOnStart = false;
	[SerializeField]
	private string _cueName = "";
	[SerializeField]
	private string _cueSheet = "";
	[SerializeField]
	private CriAtomRegion _regionOnStart = null;
	[SerializeField]
	private CriAtomListener _listenerOnStart = null;

	// Parameters
	[SerializeField]
	private bool _use3dPositioning = true;
	[SerializeField]
	private bool _freezeOrientation = false;
	[SerializeField]
	private bool _loop = false;
	[SerializeField]
	private float _volume = 1.0f;
	[SerializeField]
	private float _pitch = 0.0f;
	[SerializeField]
	private bool _androidUseLowLatencyVoicePool = false;
	[SerializeField]
	private bool need_to_player_update_all = true;
	[SerializeField]
	private bool _use3dRandomization = false;
	[SerializeField]
	private uint _randomPositionListMaxLength = 0;
	[SerializeField]
	private CriAtomEx.Randomize3dConfig randomize3dConfig = new CriAtomEx.Randomize3dConfig(0);
	#endregion

	#region Properties

	/**
	 * <summary>実行開始時に再生するかどうかを設定／取得します。</summary>
	 * <remarks>
	 * <para header='説明'>trueが設定されていると、実行開始時に再生を開始します。</para>
	 * <para header='備考'>再生開始が行われるタイミングは、MonoBehaviour::Start 関数が呼ばれるタイミングです。</para>
	 * <para header='注意'>WebGL などの非同期 ACB ロードが有効なプラットフォームで本フラグによる
	 * 実行開始時のキュー再生を行う場合は、必ずキューシート名を指定してください。<br/>
	 * 指定しない場合、ロード待ちを行うべきキューシートが特定できないため、
	 * キューの再生に失敗します。</para>
	 * </remarks>
	 */
	public bool playOnStart {
		get {return this._playOnStart;}
		set {this._playOnStart = value;}
	}

	/**
	 * <summary>再生するキュー名を設定／取得します。</summary>
	 * <remarks>
	 * <para header='説明'>CriAtomSource::Play() 関数を呼び出した場合や、
	 * CriAtomSource::playOnStart プロパティの設定により実行開始時に再生する場合には、
	 * 本プロパティで設定されているキューを再生します。</para>
	 * </remarks>
	 */
	public string cueName {
		get {return this._cueName;}
		set {this._cueName = value;}
	}

	/**
	 * <summary>キューシート名を設定／取得します。</summary>
	 * <remarks>
	 * <para header='説明'>CriAtomSource::Play 関数や CriAtomSource::cueName プロパティで指定したキューは、
	 * 本プロパティで設定されているキューシートから検索されます。</para>
	 * </remarks>
	 */
	public string cueSheet {
		get {return this._cueSheet;}
		set {this._cueSheet = value;}
	}

	/**
	 * <summary>3Dポジショニングを使用するかを設定します。</summary>
	 * <remarks>
	 * <para header='説明'><br/>
	 * デフォルトの設定では、3Dポジショニングの使用は有効になっています。<br/>
	 * 本パラメータは任意のタイミングで切り替えることができます。<br/></para>
	 * </remarks>
	 */
	public bool use3dPositioning {
		set {
			this._use3dPositioning = value;
			if (this.player != null) {
				this.player.Set3dSource(this.use3dPositioning ? this.source : null);
				this.SetNeedToPlayerUpdateAll();
			}
		}
		get { return this._use3dPositioning; }
	}

	/**
	 * <summary>3D音源の向きを固定するかどうかを設定します。</summary>
	 * <remarks>
	 * <para header='説明'><br/>
	 * デフォルトの設定では、GameObjectの向きに従い3D音源の向きを設定します。<br/>
	 * 本パラメータをtrueに設定すると、音源の向きをそのタイミングの値に固定することができます。<br/></para>
	 * </remarks>
	 */
	public bool freezeOrientation {
		get { return this._freezeOrientation; }
		set { this._freezeOrientation = value; }
	}

	/**
	 * <summary>3D音源の位置のランダム化を使用するかを設定します。</summary>
	 * <remarks>
	 * <para header='説明'><br/>
	 * デフォルトの設定では、音源位置のランダム化は無効になっています。<br/>
	 * 本パラメータは任意のタイミングで切り替えることができます。<br/></para>
	 * </remarks>
	 */
	public bool use3dRandomization {
		set {
			this._use3dRandomization = value;
			if (this.source != null) {
				if (this._use3dRandomization) {
					this.source.SetRandomPositionConfig(this.randomize3dConfig);
				} else {
					this.source.SetRandomPositionConfig(null);
				}
			}
		}
		get { return this._use3dRandomization; }
	}

	/**
	 * <summary>3D音源における位置のランダム化に関する座標リストの要素数の最大値を設定します。</summary>
	 * <remarks>
	 * <para header='説明'><br/>
	 * デフォルトではリスト要素数の最大値が0になっています。<br/>
	 * 本パラメータはCriAtomSouceのAwakeが実行される前にしか変更できません。<br/></para>
	 * </remarks>
	 */
	public uint randomPositionListMaxLength {
		set {
			if (initialized) {
				Debug.LogError("[CRIWARE] Max length of random position list cannot be changed after initialization of the CriAtomSource.", this);
				return;
			}
			this._randomPositionListMaxLength = value;
		}
		get {
			return this._randomPositionListMaxLength;
		}
	}

	/**
	 * <summary>音源の3Dリージョンの設定及び取得</summary>
	 * <remarks>
	 * <para header='注意'>3Dポジショニングが無効の場合、リージョンの設定は行えません。</para>
	 * </remarks>
	 */
	public CriAtomRegion region3d {
		get { return this.currentRegion; }
		set {
			if (this._use3dPositioning == false) {
				Debug.LogWarning("[CRIWARE] Cannot set 3D Region on audio source with 3d positioning disabled.");
				return;
			}

			CriAtomEx3dRegion regionHandle = (value == null) ? null : value.region3dHn;
			if (this.source != null) {
				this.source.Set3dRegion(regionHandle);
				this.source.Update();
				this.currentRegion = value;
			} else {
				Debug.LogError("[CRIWARE] Internal: 3D Positioning is not initialized correctly.");
				this.currentRegion = null;
			}
		}
	}

	/**
	 * <summary>音源のリスナーの設定及び取得</summary>
	 * <remarks>
	 * <para header='備考'>リスナーが設定されていない場合は音源に最も近いリスナーが利用されます。</para>
	 * <para header='注意'>3Dポジショニングが無効の場合、リスナーの設定は行えません。</para>
	 * </remarks>
	 */
	public CriAtomListener listener {
		get { return currentListener; }
		set {
			if (this._use3dPositioning == false) {
				Debug.LogWarning("[CRIWARE] Cannot set 3D Listener on audio source with 3d positioning disabled.");
				return;
			}
			currentListener = value;
			player.Set3dListener(value == null ? null : value.nativeListener);
		}
	}

	/**
	 * <summary>初期リージョンを設定します。</summary>
	 * <remarks>
	 * <para header='説明'>Startが実行されるタイミングで適用するリージョンを設定します。<br/>
	 * 3Dポジショニング有効時にのみ適用されます。<br/>
	 * 空(null)の場合は適用されません。<br/></para>
	 * </remarks>
	 */
	public CriAtomRegion regionOnStart {
		get { return this._regionOnStart; }
		set { this._regionOnStart = value; }
	}

	/**
	 * <summary>初期リスナーを設定します。</summary>
	 * <remarks>
	 * <para header='説明'>Startが実行されるタイミングで適用するリスナーを設定します。<br/>
	 * 3Dポジショニング有効時にのみ適用されます。<br/>
	 * 空(null)の場合は適用されません。<br/></para>
	 * <para header='備考'>リスナーが設定されていない場合は音源に最も近いリスナーが利用されます。</para>
	 * </remarks>
	 */
	public CriAtomListener listenerOnStart {
		get { return _listenerOnStart; }
		set { _listenerOnStart = value; }
	}

	/**
	 * <summary>ループ再生の切り替え</summary>
	 * <param name='loop'>ループスイッチ（true: ループモード、false: ループモード解除）</param>
	 * <remarks>
	 * <para header='説明'>ループポイントを持たない波形データに対し、ループ再生のON/OFFを切り替えます。<br/>
	 * デフォルトはループOFFです。<br/>
	 * ループ再生をONにした場合は、音声終端まで再生しても再生は終了せず先頭に戻って再生を繰り返します。<br/></para>
	 * <para header='注意'>本関数の設定は波形データに対して適用されます。<br/>
	 * シーケンスデータに対して本関数を実行した場合、
	 * シーケンスデータ内の個々の波形データがループ再生される形になります。<br/>
	 * <br/>
	 * 本関数による指定は、ループポイントを持たない波形データに対してのみ有効です。<br/>
	 * ループポイントを持つ波形データを再生する場合、本関数の指定に関係なく、
	 * 波形データのループ位置に従ってループ再生が行われます。<br/>
	 * <br/>
	 * 本関数は内部的にシームレス連結再生機能を使用します。<br/>
	 * そのため、シームレス連結再生に未対応のフォーマット（HCA-MX等）を使用した場合、
	 * ループ位置にある程度の無音が入る形になります。<br/>
	 * <br/>
	 * 本パラメータが評価されるのは、CriAtomSource コンポーネントのステータスが停止状態で、
	 * CriAtomSource::Play 関数を呼び出した場合です。<br/></para>
	 * </remarks>
	 */
	public bool loop {
		set { this._loop = value;}
		get { return this._loop; }
	}

	/**
	 * <summary>ボリュームを設定／取得します。</summary>
	 * <remarks>
	 * <para header='説明'>出力音声のボリューム（音量）を設定／取得します。<br/>
	 * ボリューム値は音声データの振幅に対する倍率です（単位はデシベルではありません）。<br/>
	 * 例えば、1.0fを指定した場合、原音はそのままのボリュームで出力されます。<br/>
	 * 0.5fを指定した場合、原音波形の振幅を半分にしたデータと同じ音量（-6dB）で
	 * 音声が出力されます。<br/>
	 * 0.0fを指定した場合、音声はミュートされます（無音になります）。<br/>
	 * ボリュームのデフォルト値は1.0fです。</para>
	 * <para header='備考'>キュー再生時、データ側にボリュームが設定されている場合に本関数を呼び出すと、
	 * データ側に設定されている値と本関数による設定値とを<b>乗算</b>した値が適用されます。<br/>
	 * 例えば、データ側のボリュームが0.8f、 CriAtomSource のボリュームが0.5fの場合、
	 * 実際に適用されるボリュームは0.4fになります。<br/></para>
	 * </remarks>
	 */
	public float volume {
		set {
			this._volume = value;
			if (this.player != null) {
				this.player.SetVolume(this._volume);
				this.SetNeedToPlayerUpdateAll();
			}
		}
		get { return this._volume; }
	}

	/**
	 * <summary>ピッチを設定／取得します。</summary>
	 * <remarks>
	 * <para header='説明'>出力音声のピッチ（音の高さ）を設定／取得します。<br/>
	 * ピッチはセント単位で指定します。<br/>
	 * 1セントは1オクターブの1/1200です。半音は100セントです。<br/>
	 * 例えば、100.0fを指定した場合、ピッチが半音上がります。-100.0fを指定した場合、ピッチが半音下がります。<br/>
	 * ピッチのデフォルト値は0.0fです。</para>
	 * <para header='備考'>キュー再生時、データ側にピッチが設定されている場合に本関数を呼び出すと、
	 * データ側に設定されている値と本関数による設定値とを<b>加算</b>した値が適用されます。<br/>
	 * 例えば、データ側のピッチが-100.0f、 CriAtomSource のピッチが200.0fの場合、
	 * 実際に適用されるピッチは100.0fになります。</para>
	 * </remarks>
	 */
	public float pitch {
		set {
			this._pitch = value;
			if (this.player != null) {
				this.player.SetPitch(this._pitch);
				this.SetNeedToPlayerUpdateAll();
			}
		}
		get { return this._pitch; }
	}

	/**
	 * <summary>パンニング3D角度を設定／取得します。</summary>
	 * <remarks>
	 * <para header='説明'>パンニング3D角度を設定／取得します。<br/>
	 * 角度は度単位で指定します。<br/>
	 * 前方を0度とし、右方向（時計回り）に180.0f、左方向（反時計回り）に-180.0fまで設定できます。<br/>
	 * 例えば、45.0fを指定した場合、右前方45度に定位します。-45.0fを指定した場合、左前方45度に定位します。<br/></para>
	 * <para header='備考'>キュー再生時、データ側にパンニング3D角度が設定されている場合に本関数を呼び出すと、
	 * データ側に設定されている値と本関数による設定値とを<b>加算</b>した値が適用されます。<br/>
	 * 例えば、データ側のパンニング3D角度が15.0f、 CriAtomSource のパンニング3D角度が30.0fの場合、
	 * 実際に適用されるパンニング3D角度は45.0fになります。
	 * <br/>
	 * 実際に適用されるパンニング3D角度が180.0fを超える値になった場合、値を-360.0fして範囲内に納めます。<br/>
	 * 同様に、実際に適用されるボリューム値が-180.0f未満の値になった場合は、値を+360.0fして範囲内に納めます。<br/>
	 * （+360.0f, -360.0fしても定位は変わらないため、実質的には-180.0f～180.0fの範囲を超えて設定可能です。）</para>
	 * </remarks>
	 */
	public float pan3dAngle {
		set {
			if (this.player != null) {
				this.player.SetPan3dAngle(value);
				this.SetNeedToPlayerUpdateAll();
			}
		}
		get {
			return (this.player != null) ?
				this.player.GetParameterFloat32(CriAtomEx.Parameter.Pan3dAngle) : 0.0f;
		}
	}

	/**
	 * <summary>パンニング3D距離を設定／取得します。</summary>
	 * <remarks>
	 * <para header='説明'>パンニング3Dでインテリアパンニングを行う際の距離を設定／取得します。<br/>
	 * 距離は、リスナー位置を0.0f、スピーカーの配置されている円周上を1.0fとして、-1.0f～1.0fの範囲で指定します。<br/>
	 * 負値を指定すると、パンニング3D角度が180度反転し、逆方向に定位します。</para>
	 * <para header='備考'>キュー再生時、データ側にパンニング3D距離が設定されている場合に本関数を呼び出すと、
	 * データ側に設定されている値と本関数による設定値とを<b>乗算</b>した値が適用されます。<br/>
	 * 例えば、データ側のパンニング3D距離が0.8f、 CriAtomSource のパンニング3D距離が0.5fの場合、
	 * 実際に適用されるパンニング3D距離は0.4fになります。
	 * <br/>
	 * 実際に適用されるパンニング3D距離が1.0fを超える値になった場合、値は1.0fにクリップされます。<br/>
	 * 同様に、実際に適用されるパンニング3D距離が-1.0f未満の値になった場合も、値は-1.0fにクリップされます。<br/></para>
	 * </remarks>
	 */
	public float pan3dDistance {
		set {
			if (this.player != null) {
				this.player.SetPan3dInteriorDistance(value);
				this.SetNeedToPlayerUpdateAll();
			}
		}
		get {
			return (this.player != null) ?
				this.player.GetParameterFloat32(CriAtomEx.Parameter.Pan3dDistance) : 0.0f;
		}
	}

	/**
	 * <summary>再生開始位置を設定／取得します。</summary>
	 * <remarks>
	 * <para header='説明'>再生を開始する位置を設定／取得します。
	 * 再生開始位置を設定すると、音声データを途中から再生することができます。<br/>
	 * 再生開始位置の指定はミリ秒単位で行います。例えば、 10000 を設定すると、
	 * 次に再生する音声データは 10 秒目の位置から再生されます。</para>
	 * <para header='備考'>音声データ途中からの再生は、音声データ先頭からの再生に比べ、発音開始の
	 * タイミングが遅くなります。<br/>
	 * これは、一旦音声データのヘッダを解析後、指定位置にジャンプしてからデータを読み
	 * 直して再生を開始するためです。</para>
	 * <para header='注意'>
	 * 再生開始位置を指定してシーケンスを再生した場合、指定位置よりも前に配置された
	 * 波形データは再生されません。<br/>
	 * （シーケンス内の個々の波形が途中から再生されることはありません。）<br/></para>
	 * </remarks>
	 */
	public int startTime {
		set {
			if (this.player != null) {
				this.player.SetStartTime(value);
				this.SetNeedToPlayerUpdateAll();
			}
		}
		get {
			return (this.player != null) ?
				this.player.GetParameterSint32(CriAtomEx.Parameter.StartTime) : 0;
		}
	}


	/**
	 * <summary>再生時刻（ミリ秒単位）を取得します。</summary>
	 * <remarks>
	 * <para header='説明'>再生時刻が取得できている場合、本プロパティは 0 以上の値を示します。<br/>
	 * 再生時刻が取得できない場合（ボイスの取得に失敗した場合等）、本関数は負値を示します。<br/></para>
	 * <para header='備考'>同一 CriAtomSource コンポーネントで複数の音声を再生した場合は、
	 * "最後に"再生した音声の時刻を示します。<br/>
	 * 複数の音声に対して再生時刻をチェックする必要がある場合には、
	 * 再生する音声の数分だけ CriAtomSource コンポーネントを作成してください。<br/>
	 * <br/>
	 * 本プロパティが示す再生時刻は、「再生開始後からの経過時間」です。<br/>
	 * ループ再生時や、シームレス連結再生時を行った場合でも、
	 * 再生位置に応じて時刻が巻き戻ることはありません。<br/>
	 * <br/>
	 * CriAtomSource::Pause 関数でポーズをかけた場合、
	 * 再生時刻のカウントアップも停止します。<br/>
	 * （ポーズを解除すれば再度カウントアップが再開されます。）
	 * <br/></para>
	 * <para header='注意'>戻り値の型はlongですが、現状、32bit以上の精度はありません。<br/>
	 * 再生時刻を元に制御を行う場合、約24日で再生時刻が異常になる点に注意が必要です。<br/>
	 * （ 2147483647 ミリ秒を超えた時点で、再生時刻がオーバーフローし、負値になります。）<br/>
	 * <br/>
	 * 再生中の音声が発音数制御によって消去された場合、
	 * 再生時刻のカウントアップもその時点で停止します。<br/>
	 * また、再生開始時点で発音数制御によりボイスが割り当てられなかった場合、
	 * 本関数は正しい時刻を返しません。<br/>
	 * （負値が返ります。）<br/>
	 * <br/>
	 * ファイル読み込みが間に合わない等の理由により、一時的に音声データの供給が途切れた場合でも、
	 * 再生時刻のカウントアップが途切れることはありません。<br/>
	 * （データ供給停止により再生が停止した場合でも、時刻は進み続けます。）<br/>
	 * そのため、本関数で取得した時刻を元に映像との同期を行った場合、
	 * データ供給不足が発生する度に同期が大きくズレる可能性があります。<br/></para>
	 * </remarks>
	 */
	public long time
	{
		get {
			return (this.player != null) ?
				this.player.GetTime() : 0;
		}
	}

	/**
	 * <summary>ステータスを取得します。</summary>
	 * <remarks>
	 * <para header='説明'>CriAtomSource コンポーネントのステータスを取得します。<br/>
	 * ステータスは CriAtomSource コンポーネントの再生状態を示す値で、以下の5通りの値が存在します。<br/>
	 * -# Stop
	 * -# Prep
	 * -# Playing
	 * -# Playend
	 * -# Error
	 * .
	 *  <br/>
	 *  <br/>
	 *  CriAtomSource コンポーネントが作成された時点では、 CriAtomSource コンポーネントのステータスは停止状態
	 * （ Stop ）です。<br/>
	 *  CriAtomSource.Play 関数等で再生開始すると、 CriAtomSource コンポーネントのステータスが準備状態
	 * （ Prep ）に変更されます。<br/>
	 * （ Prep は、データ供給やデコードの開始を待っている状態です。）<br/>
	 * 再生の開始に十分なデータが供給された時点で、 CriAtomSource コンポーネントはステータスを再生状態
	 * （ Playing ）に変更します。<br/>
	 * 尚、再生中にエラーが発生した場合には、 CriAtomSource コンポーネントはステータスをエラー状態
	 * （ Error ）に変更します。<br/>
	 * <br/>
	 * CriAtomSource コンポーネントのステータスをチェックし、ステータスに応じて処理を切り替えることで、
	 * 音声の再生状態に連動したプログラムを作成することが可能です。</para>
	 * </remarks>
	 */
	public Status status
	{
		get {
			return (this.player != null) ?
				(Status)this.player.GetStatus() : Status.Error;
		}
	}

	/**
	 * <summary>距離減衰有効化設定を設定／取得します。</summary>
	 * <remarks>
	 * <para header='説明'>距離減衰による音量の変動を有効にするか無効にするかを設定／取得します。<br/>
	 * デフォルトは有効です。</para>
	 * </remarks>
	 */
	public bool attenuationDistanceSetting
	{
		set {
			if (this.source != null) {
				source.SetAttenuationDistanceSetting(value);
				source.Update();
			}
		}
		get {
			return (this.source != null) ?
				source.GetAttenuationDistanceSetting() : false;
		}
	}

	/**
	 * <summary>低遅延再生ボイスプールから再生を行うかどうかを設定／取得します。</summary>
	 * <remarks>
	 * <para header='説明'>trueが設定されていると、低遅延再生ボイスプールを使って再生を開始します。</para>
	 * <para header='備考'>本フラグを有効にする場合は、CriWareInitializerの低遅延再生ボイスプール数を設定しておく必要があります。</para>
	 * </remarks>
	 */
	public bool androidUseLowLatencyVoicePool {
		get {return this._androidUseLowLatencyVoicePool;}
		set {this._androidUseLowLatencyVoicePool = value;}
	}

	#endregion

	#region Functions

	protected void SetNeedToPlayerUpdateAll()
	{
		this.need_to_player_update_all = true;
	}

	protected virtual void InternalInitialize()
	{
		CriAtomPlugin.InitializeLibrary();
		this.player = new CriAtomExPlayer();
		this.source = new CriAtomEx3dSource(randomPositionListMaxLength:this.randomPositionListMaxLength);
		this.initialized = true;
	}

	protected virtual void InternalFinalize()
	{
		this.initialized = false;
		this.player.Dispose();
		this.player = null;
		this.source.Dispose();
		this.source = null;
		CriAtomPlugin.FinalizeLibrary();
	}

	void Awake()
	{
		this.InternalInitialize();
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		this.hasValidPosition = false;
		this.SetInitialParameters();
		this.SetNeedToPlayerUpdateAll();
	}

	void OnDestroy()
	{
		this.InternalFinalize();
	}

	protected bool SetInitialSourcePosition()
	{
		Vector3 position = this.transform.position;
		this.lastPosition = position;
		if (this.source != null) {
			this.source.SetPosition(position.x, position.y, position.z);
			this.source.Update();
			return true;
		} else {
			return false;
		}
	}

	protected virtual void SetInitialParameters()
	{
		this.use3dPositioning = this.use3dPositioning; /* ここで必要に応じて3Dソースが設定される */
		this.use3dRandomization = this.use3dRandomization;
		if (this.SetInitialSourcePosition() == false) {
			Debug.LogError("[ADX2][SetInitialParameters] source is null.",this);
		}

		this.player.SetVolume(this._volume);
		this.player.SetPitch(this._pitch);
	}

	protected virtual void UpdatePosition()
	{
		Vector3 position = this.transform.position;
		this.source.SetPosition(position.x, position.y, position.z);
		if (this.hasValidPosition == true) {
			Vector3 velocity = (position - this.lastPosition) / Time.deltaTime;
			this.source.SetVelocity(velocity.x, velocity.y, velocity.z);
		}
		if (this.freezeOrientation == false) {
			this.source.SetOrientation(this.transform.forward, this.transform.up);
		}
		this.source.Update();
		this.lastPosition = position;
		this.hasValidPosition = true;
	}

	void Start() {
		if (this.use3dPositioning && this.regionOnStart != null) {
			this.region3d = this.regionOnStart;
		}
		if (use3dPositioning && listenerOnStart != null)
			listener = listenerOnStart;
		this.PlayOnStart();
	}

	public override void CriInternalUpdate() { }

	public override void CriInternalLateUpdate()
	{
		if (this.use3dPositioning == true) {
			UpdatePosition();
		}

		if (this.need_to_player_update_all == true) {
			this.player.UpdateAll();
			this.need_to_player_update_all = false;
		}
	}

#if UNITY_EDITOR
	static private readonly Color c_CriWareLightBlue = new Color(0.332f, 0.661f, 0.991f);
	static private readonly Color c_RandomizeGizmoColor = new Color(0.332f, 0.661f, 0.991f, 0.2f);
	private Mesh randomize3dGizmoMesh = null;
	private CriAtomEx.Randomize3dCalcType lastRandomizeTypeGizmo = CriAtomEx.Randomize3dCalcType.None;
	private Quaternion currentGizmoRotation = Quaternion.identity;
	private Quaternion lastGizmoRotation = Quaternion.identity;
	
	private void SetGizmoMesh(PrimitiveType meshType) {
		GameObject tempPrimitive = GameObject.CreatePrimitive(meshType);
		this.randomize3dGizmoMesh = tempPrimitive.GetComponent<MeshFilter>().sharedMesh;
		DestroyImmediate(tempPrimitive);
	}

	public void OnDrawGizmos()
	{
		if (this.enabled == false) { return; }
		var gizmoColor = (!Application.isPlaying || this.status == Status.Playing) ? c_CriWareLightBlue : Color.gray;
		if (this.freezeOrientation == false) {
			currentGizmoRotation = transform.rotation;
			lastGizmoRotation = currentGizmoRotation;
		} else if (Application.isPlaying) {
			currentGizmoRotation = lastGizmoRotation;
		} else {
			currentGizmoRotation = Quaternion.identity;
		}
		UnityEditor.Handles.color = gizmoColor;
		UnityEditor.Handles.DrawLine(this.transform.position, this.transform.position + this.currentGizmoRotation * Vector3.forward);
		UnityEditor.Handles.DrawLine(this.transform.position, this.transform.position + this.currentGizmoRotation * Vector3.up);
		UnityEditor.Handles.ArrowHandleCap(1, this.transform.position + this.currentGizmoRotation * Vector3.forward, this.currentGizmoRotation, 1f, EventType.Repaint);
		UnityEditor.Handles.CircleHandleCap(1, this.transform.position, this.currentGizmoRotation * Quaternion.LookRotation(Vector3.up), 1f, EventType.Repaint);
		
		if (UnityEditor.Selection.activeGameObject == this.gameObject) {
			bool needRefreshMesh = false;
			if (lastRandomizeTypeGizmo != randomize3dConfig.CalculationType) {
				needRefreshMesh = true;
				lastRandomizeTypeGizmo = randomize3dConfig.CalculationType;
			}
			if (use3dRandomization) {
				Gizmos.color = c_RandomizeGizmoColor;
				Vector3 scale;
				switch (randomize3dConfig.CalculationType) {
					case CriAtomEx.Randomize3dCalcType.Rectangle:
						if (needRefreshMesh) { this.SetGizmoMesh(PrimitiveType.Quad); }
						scale = new Vector3(randomize3dConfig.CalculationParameter1, randomize3dConfig.CalculationParameter2, 1f);
						Gizmos.DrawWireMesh(randomize3dGizmoMesh, this.transform.position, this.currentGizmoRotation * Quaternion.LookRotation(Vector3.up), scale);
						break;
					case CriAtomEx.Randomize3dCalcType.Cuboid:
						if (needRefreshMesh) { this.SetGizmoMesh(PrimitiveType.Cube); }
						scale = new Vector3(randomize3dConfig.CalculationParameter1, randomize3dConfig.CalculationParameter3, randomize3dConfig.CalculationParameter2);
						Gizmos.DrawWireMesh(randomize3dGizmoMesh, this.transform.position, this.currentGizmoRotation, scale);
						break;
					case CriAtomEx.Randomize3dCalcType.Circle:
						if (needRefreshMesh) { this.SetGizmoMesh(PrimitiveType.Cylinder); }
						scale = new Vector3(randomize3dConfig.CalculationParameter1 * 2f, 0, randomize3dConfig.CalculationParameter1 * 2f);
						Gizmos.DrawWireMesh(randomize3dGizmoMesh, this.transform.position, this.currentGizmoRotation, scale);
						break;
					case CriAtomEx.Randomize3dCalcType.Cylinder:
						if (needRefreshMesh) { this.SetGizmoMesh(PrimitiveType.Cylinder); }
						scale = new Vector3(randomize3dConfig.CalculationParameter1 * 2f, randomize3dConfig.CalculationParameter2, randomize3dConfig.CalculationParameter1 * 2f);
						Gizmos.DrawWireMesh(randomize3dGizmoMesh, this.transform.position, this.currentGizmoRotation, scale);
						break;
					case CriAtomEx.Randomize3dCalcType.Sphere:
						if (needRefreshMesh) { this.SetGizmoMesh(PrimitiveType.Sphere); }
						scale = new Vector3(randomize3dConfig.CalculationParameter1 * 2f, randomize3dConfig.CalculationParameter1 * 2f, randomize3dConfig.CalculationParameter1 * 2f);
						Gizmos.DrawWireMesh(randomize3dGizmoMesh, this.transform.position, this.currentGizmoRotation, scale);
						break;
					default:
						randomize3dGizmoMesh = null;
						break;
				}
			}
		}
	}
#endif

	#region PlaybackAndController
	/**
	 * <summary>設定されているキューを再生開始します。</summary>
	 * <returns>再生ID</returns>
	 * <remarks>
	 * <para header='説明'>どのキューを再生するかは、事前に CriAtomSource::cueName
	 * プロパティにより設定しておく必要があります。</para>
	 * </remarks>
	 */
	public CriAtomExPlayback Play()
	{
		return this.Play(this.cueName);
	}

	/**
	 * <summary>指定したキュー名のキューを再生開始します。</summary>
	 * <param name='cueName'>キュー名</param>
	 * <returns>再生ID</returns>
	 * <remarks>
	 * <para header='説明'>CriAtomSource::cueName プロパティの設定に関わらず、本関数に指定したキュー名のキューを再生します。</para>
	 * </remarks>
	 */
	public CriAtomExPlayback Play(string cueName)
	{
		if (this.player == null)
			return new CriAtomExPlayback(CriAtomExPlayback.invalidId);

		CriAtomExAcb acb = null;
		if (!String.IsNullOrEmpty(this.cueSheet)) {
			acb = CriAtom.GetAcb(this.cueSheet);
		}
		this.player.SetCue(acb, cueName);
#if !UNITY_EDITOR && UNITY_ANDROID
		if (androidUseLowLatencyVoicePool) {
			this.player.SetSoundRendererType(CriAtomEx.SoundRendererType.Native);
		} else {
			this.player.SetSoundRendererType(CriAtomEx.androidDefaultSoundRendererType);
		}
#endif
		if (this.hasValidPosition == false) {
			this.SetInitialSourcePosition();
			this.hasValidPosition = true;
		}
		if (this.status == Status.Stop) {
			this.player.Loop(this._loop);
		}
		return this.player.Start();
	}

	/**
	 * <summary>指定したキューIDのキューを再生開始します。</summary>
	 * <param name='cueId'>キューID</param>
	 * <returns>再生ID</returns>
	 * <remarks>
	 * <para header='説明'>CriAtomSource::cueName プロパティの設定に関わらず、本関数に指定したキューIDのキューを再生します。</para>
	 * </remarks>
	 */
	public CriAtomExPlayback Play(int cueId)
	{
		if (this.player == null)
			return new CriAtomExPlayback(CriAtomExPlayback.invalidId);


		CriAtomExAcb acb = null;
		if (!String.IsNullOrEmpty(this.cueSheet)) {
			acb = CriAtom.GetAcb(this.cueSheet);
		}
		this.player.SetCue(acb, cueId);
#if !UNITY_EDITOR && UNITY_ANDROID
		if (androidUseLowLatencyVoicePool) {
			this.player.SetSoundRendererType(CriAtomEx.SoundRendererType.Native);
		} else {
			this.player.SetSoundRendererType(CriAtomEx.androidDefaultSoundRendererType);
		}
#endif
		if (this.hasValidPosition == false) {
			this.SetInitialSourcePosition();
			this.hasValidPosition = true;
		}
		if (this.status == Status.Stop) {
			this.player.Loop(this._loop);
		}
		return this.player.Start();
	}

	/**
	 * <summary>設定されているキューを再生開始します。</summary>
	 * <remarks>
	 * <para header='説明'>事前に CriAtomSource::playOnStart, CriAtomSource::cueName
	 * プロパティを設定しておく必要があります。</para>
	 * </remarks>
	 */
	private void PlayOnStart()
	{
		if (this.playOnStart && !String.IsNullOrEmpty(this.cueName)) {
			StartCoroutine(PlayAsync(this.cueName));
		}
	}

	/**
	 * <summary>非同期に、指定したキュー名のキューを再生開始します。</summary>
	 * <param name='cueName'>キュー名</param>
	 * <returns>コルーチン</returns>
	 * <remarks>
	 * <para header='説明'>Unityのコルーチン機能を使い、非同期に実行されます。
	 * 本関数は MonoBehaviour::StartCoroutine の引数に指定して呼び出してください。</para>
	 * </remarks>
	 */
	private IEnumerator PlayAsync(string cueName)
	{
		CriAtomExAcb acb = null;
		while (acb == null && !String.IsNullOrEmpty(this.cueSheet)) {
			acb = CriAtom.GetAcb(this.cueSheet);
			if (acb == null) {
				yield return null;
			}
		}
		this.player.SetCue(acb, cueName);
#if !UNITY_EDITOR && UNITY_ANDROID
		if (androidUseLowLatencyVoicePool) {
			this.player.SetSoundRendererType(CriAtomEx.SoundRendererType.Native);
		} else {
			this.player.SetSoundRendererType(CriAtomEx.androidDefaultSoundRendererType);
		}
#endif
		if (this.hasValidPosition == false) {
			this.SetInitialSourcePosition();
			this.hasValidPosition = true;
		}
		if (this.status == Status.Stop) {
			this.player.Loop(this._loop);
		}
		this.player.Start();
	}

	/**
	 * <summary>再生を停止します。</summary>
	 * <remarks>
	 * <para header='説明'>音声再生中の CriAtomSource コンポーネントに対して本関数を実行すると、
	 * CriAtomSource コンポーネントは再生を停止（ファイルの読み込みや、発音を止める）し、
	 * ステータスを停止状態（ Stop ）に遷移します。<br/>
	 * 既に停止している CriAtomSource コンポーネント（ステータスが Playend や Error
	 * の CriAtomSource コンポーネント ） に対して本関数を実行すると、
	 * CriAtomSource コンポーネント のステータスを Stop に変更します。</para>
	 * <para header='注意'>音声再生中の CriAtomSource コンポーネントに対して本関数を実行した場合、ステータスが即座に
	 * Stop になるとは限りません。<br/>
	 * （停止状態になるまでに、時間がかかる場合があります。）</para>
	 * </remarks>
	 */
	public void Stop()
	{
		if (this.player != null) {
			this.player.Stop();
		}
	}

	/**
	 * <summary>一時停止／再開します。</summary>
	 * <param name='sw'>true:一時停止、false:再開</param>
	 * <remarks>
	 * <para header='説明'>再生のポーズ／ポーズ解除を行います。<br/>
	 * sw に true を指定して本関数を実行すると、 CriAtomSource
	 * コンポーネントは再生中の音声をポーズ（一時停止）します。<br/>
	 * sw に false を指定して本関数を実行すると、 CriAtomSource
	 * コンポーネントはポーズを解除し、一時停止していた音声の再生を再開します。<br/></para>
	 * </remarks>
	 */
	public void Pause(bool sw)
	{
		if (this.player == null)
			return;

		if (sw == false) {
			this.player.Resume(CriAtomEx.ResumeMode.PausedPlayback);
		} else {
			this.player.Pause();
		}
	}

	/**
	 * <summary>ポーズ状態の取得を行います。</summary>
	 * <returns>ポーズ状態</returns>
	 * <remarks>
	 * <para header='説明'>ポーズのON/OFFを取得します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomSource::Pause'/>
	 */
	public bool IsPaused()
	{
		return (this.player != null) ? this.player.IsPaused() : false;
	}

	/**
	 * <summary>バス名を指定してバスセンドレベルを設定します。</summary>
	 * <remarks>
	 * <para header='備考'>キュー再生時、データ側にバスセンドレベルが設定されている場合に本関数を呼び出すと、
	 * データ側に設定されている値と本関数による設定値とを<b>乗算</b>した値が適用されます。<br/>
	 * 例えば、データ側のバスセンドレベルが0.8f、 CriAtomSource のバスセンドレベルが0.5fの場合、
	 * 実際に適用されるバスセンドレベルは0.4fになります。<br/></para>
	 * </remarks>
	 */
	public void SetBusSendLevel(string busName, float level)
	{
		if (this.player != null) {
			this.player.SetBusSendLevel(busName, level);
			this.SetNeedToPlayerUpdateAll();
		}
	}

	/**
	 * \deprecated
	 * 削除予定の非推奨APIです。
	 * CriAtomSource.SetBusSendLevel(string, float)の使用を検討してください。
	*/
	[System.Obsolete("Use CriAtomSource.SetBusSendLevel(string, float)")]
	public void SetBusSendLevel(int busId, float level)
	{
		if (this.player != null) {
			this.player.SetBusSendLevel(busId, level);
			this.SetNeedToPlayerUpdateAll();
		}
	}

	/**
	 * <summary>バス名を指定してバスセンドレベルをオフセット指定で設定します。</summary>
	 * <remarks>
	 * <para header='説明'>キュー再生時、データ側にバスセンドレベルが設定されている場合に本関数を呼び出すと、
	 * データ側に設定されている値と本関数による設定値とを<b>加算</b>した値が適用されます。<br/>
	 * 例えば、データ側のバスセンドレベルが0.2f、 CriAtomSource のバスセンドレベルが0.5fの場合、
	 * 実際に適用されるバスセンドレベルは0.7fになります。<br/></para>
	 * </remarks>
	 */
	public void SetBusSendLevelOffset(string busName, float levelOffset)
	{
		if (this.player != null) {
			this.player.SetBusSendLevelOffset(busName, levelOffset);
			this.SetNeedToPlayerUpdateAll();
		}
	}

	/**
	 * \deprecated
	 * 削除予定の非推奨APIです。
	 * CriAtomSource.SetBusSendLevelOffset(string, float)の使用を検討してください。
	*/
	[System.Obsolete("Use CriAtomSource.SetBusSendLevelOffset(string, float)")]
	public void SetBusSendLevelOffset(int busId, float levelOffset)
	{
		if (this.player != null) {
			this.player.SetBusSendLevelOffset(busId, levelOffset);
			this.SetNeedToPlayerUpdateAll();
		}
	}


	/**
	 * <summary>AISACコントロール名を指定してAISACコントロール値を設定します。</summary>
	 */
	public void SetAisacControl(string controlName, float value)
	{
		if (this.player != null) {
			this.player.SetAisacControl(controlName, value);
			this.SetNeedToPlayerUpdateAll();
		}
	}

	/**
	 * \deprecated
	 * 削除予定の非推奨APIです。
	 * CriAtomSource.SetAisacControlの使用を検討してください。
	*/
	[System.Obsolete("Use CriAtomSource.SetAisacControl")]
	public void SetAisac(string controlName, float value)
	{
		SetAisacControl(controlName, value);
	}

	/**
	 * <summary>AISACコントロール名を指定してAISACコントロール値を設定します。</summary>
	 */
	public void SetAisacControl(uint controlId, float value)
	{
		if (this.player != null) {
			this.player.SetAisacControl(controlId, value);
			this.SetNeedToPlayerUpdateAll();
		}
	}

	/**
	 * \deprecated
	 * 削除予定の非推奨APIです。
	 * CriAtomSource.SetAisacControlの使用を検討してください。
	*/
	[System.Obsolete("Use CriAtomSource.SetAisacControl")]
	public void SetAisac(uint controlId, float value)
	{
		SetAisacControl(controlId, value);
	}

	/**
	 * <summary>出力データの解析モジュールにアタッチします。</summary>
	 */
	public void AttachToAnalyzer(CriAtomExOutputAnalyzer analyzer)
	{
		if (this.player != null) {
			analyzer.AttachExPlayer(this.player);
		}
	}

	/**
	 * <summary>出力データの解析モジュールからデタッチします。</summary>
	 */
	public void DetachFromAnalyzer(CriAtomExOutputAnalyzer analyzer)
	{
		analyzer.DetachExPlayer();
	}
	#endregion

	#endregion
} // end of class

} //namespace CriWare
/** @} */
/* end of file */
