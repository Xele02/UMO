using System.Collections;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RivalDivaManager : MonoBehaviour
	{
		[SerializeField]
		private GameObject divaPrefab; // 0xC
		private DivaResource resource; // 0x10
		private DivaMenuParam divaMenuParam; // 0x14
		private MenuDivaObject divaObject; // 0x18
		private MenuDivaControlBase divaControl; // 0x1C
		private MessageBank messageBank; // 0x20
		private Camera divaCamera; // 0x24

		public bool IsLoading { get; private set; } // 0x28
		public int DivaId { get { return divaObject != null ? divaObject.divaId : -1; } } //0xB647D4

		// RVA: 0xB6488C Offset: 0xB6488C VA: 0xB6488C
		private void Awake()
		{
			resource = gameObject.AddComponent<DivaResource>();
		}

		// RVA: 0xB64914 Offset: 0xB64914 VA: 0xB64914
		private void Start()
		{
			divaCamera = GetComponentInChildren<Camera>(true);
			divaCamera.enabled = false;
			gameObject.SetActive(false);
		}

		// RVA: 0xB649D4 Offset: 0xB649D4 VA: 0xB649D4
		private void Update()
		{
			if(divaControl != null)
				divaControl.OnUpdate();
		}

		// RVA: 0xB649F0 Offset: 0xB649F0 VA: 0xB649F0
		private void LateUpdate()
		{
			if(divaControl != null)
				divaControl.OnLateUpdate();
		}

		//// RVA: 0xB64A0C Offset: 0xB64A0C VA: 0xB64A0C
		public void Load(int divaId, int modelId, int colorId)
		{
			IsLoading = true;
			this.StartCoroutineWatched(Co_Load(divaId, modelId, colorId));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C7324 Offset: 0x6C7324 VA: 0x6C7324
		//// RVA: 0xB64A44 Offset: 0xB64A44 VA: 0xB64A44
		private IEnumerator Co_Load(int divaId, int modelId, int colorId)
		{
			//0xB65770
			if(divaObject == null)
			{
				GameObject g = Instantiate(divaPrefab);
				g.transform.SetParent(transform, false);
				divaObject = g.GetComponent<MenuDivaObject>();
			}
			messageBank = MessageManager.Instance.GetBank(MessageLoader.DivaIdToSheet(divaId).ToString());
			resource.LoadBasicResource(divaId, modelId, colorId);
			resource.LoadRivalResultResource(divaId, modelId);
			yield return new WaitUntil(() =>
			{
				//0xB65604
				return resource.isRivalResultAllLoaded;
			});
			divaMenuParam = resource.divaMenuParam;
			divaObject.Initialize(resource, divaId, false);
			ApplyCameraPos(divaId, DivaMenuParam.CameraPosType.BattleResult);
			IsLoading = false;
		}

		//// RVA: 0xB64B3C Offset: 0xB64B3C VA: 0xB64B3C
		public void Release()
		{
			messageBank = null;
			resource.ReleaseBasicResource();
			if(resource.isLoadedRivalResultAnimationResource)
			{
				resource.ReleaseRivalResultResource();
			}
			if(divaObject != null)
			{
				if(divaObject.divaId != Database.Instance.gameSetup.teamInfo.divaList[0].prismDivaId)
				{
					SoundManager.Instance.voOtherDiva.RemoveCueSheet();
				}
				Destroy(divaObject.gameObject);
				divaObject = null;
			}
		}

		//// RVA: 0xB4A400 Offset: 0xB4A400 VA: 0xB4A400
		public void SetActive(bool active, bool isIdle/* = True*/)
		{
			if(divaObject != null)
			{
				divaObject.VisibleRendererComponent(active);
				if(active && isIdle)
					OnIdle();
			}
			divaCamera.enabled = active;
		}

		//// RVA: 0xB64E94 Offset: 0xB64E94 VA: 0xB64E94
		//public bool isWaitUnlockBoneSpring() { }

		//// RVA: 0xB64F4C Offset: 0xB64F4C VA: 0xB64F4C
		public void LockBoneSpring()
		{
			divaObject.LockBoneSpring(0);
		}

		//// RVA: 0xB4A4F8 Offset: 0xB4A4F8 VA: 0xB4A4F8
		public void UnlockBoneSpring()
		{
			divaObject.UnlockBoneSpring(false, 0);
		}

		//// RVA: 0xB64DD0 Offset: 0xB64DD0 VA: 0xB64DD0
		public void OnIdle()
		{
			if(divaObject != null)
				divaObject.Idle("");
		}

		//// RVA: 0xB64F7C Offset: 0xB64F7C VA: 0xB64F7C
		public void ApplyCameraPos(int divaId, DivaMenuParam.CameraPosType type/* = 0*/)
		{
			divaCamera.transform.localPosition = new Vector3(divaCamera.transform.localPosition.x, divaMenuParam.CameraPosY(type)[divaId - 1], divaCamera.transform.localPosition.z);
		}

		//// RVA: 0xB4A558 Offset: 0xB4A558 VA: 0xB4A558
		public void SwitchCameraRender(DivaCameraRenderSwitch renderSwitch)
		{
			renderSwitch.Apply(divaCamera);
		}

		//// RVA: 0xB65134 Offset: 0xB65134 VA: 0xB65134
		public void RevertCameraRender(DivaCameraRenderSwitch renderSwitch)
		{
			renderSwitch.Revert(divaCamera);
		}

		//// RVA: 0xB65168 Offset: 0xB65168 VA: 0xB65168
		//public VectorI2 GetCameraPixelSize() { }

		//// RVA: 0xB4A52C Offset: 0xB4A52C VA: 0xB4A52C
		public void OnBattleResultStart()
		{
			divaObject.BattleResult();
		}

		//// RVA: 0xB651E0 Offset: 0xB651E0 VA: 0xB651E0
		public void OnBattleResultAnimStart(bool isWin)
		{
			divaObject.BattleResultAnimStart(isWin, false);
			if(isWin)
			{
				SoundManager.Instance.voOtherDiva.RequestChangeCueSheet(divaObject.divaId, () =>
				{
					//0xB656AC
					SoundManager.Instance.voOtherDiva.Play(DivaVoicePlayer.VoiceCategory.Result, DivaResultMotion.GetVoiceId(ResultScoreRank.Type.SS));
				});
			}
		}

		//// RVA: 0xB653A4 Offset: 0xB653A4 VA: 0xB653A4
		public void RequestBattleResultAnimStart(bool isWin)
		{
			OnBattleResultAnimStart(isWin);
			if(isWin)
			{
				this.StartCoroutineWatched(Coroutine_RequestResultAnimStart());
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C739C Offset: 0x6C739C VA: 0x6C739C
		//// RVA: 0xB653DC Offset: 0xB653DC VA: 0xB653DC
		private IEnumerator Coroutine_RequestResultAnimStart()
		{
			//0xB65BCC
			yield return new WaitWhile(() =>
			{
				//0xB65718
				return SoundManager.Instance.voDiva.isPlaying;
			});
			if(divaObject != null)
				divaObject.ResultReactionLoopBreak();
		}

		//// RVA: 0xB65488 Offset: 0xB65488 VA: 0xB65488
		public void ResetBattleResultTransform()
		{
			if(divaObject != null)
				divaObject.ResetBattleResultTransform();
		}

		//// RVA: 0xB6553C Offset: 0xB6553C VA: 0xB6553C
		//public void SetEnableDivaEffect(bool a_enable, bool a_save_ginore = False) { }

		//// RVA: 0xB4A340 Offset: 0xB4A340 VA: 0xB4A340
		public void SetEnableDivaWind(bool a_enable, bool a_save_ginore/* = False*/)
		{
			if(divaObject != null)
			{
				divaObject.SetEnableWind(a_enable, false);
			}
		}
	}
}
