using System.Collections;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class EpisodeAppealValkyrieObject : MenuValkyrieObject
	{
		private int m_ValkyrieId; // 0x64
		private bool m_IsLoaded; // 0x68
		private bool m_IsEntered; // 0x69
		private bool m_IsFinished; // 0x6A
		private Coroutine m_coAppealFinish; // 0x6C
		private float m_animClipLen_Appeal; // 0x70
		private GameObject[] m_model = new GameObject[3]; // 0x74
		public static readonly int AppealStateHash = Animator.StringToHash("Appeal"); // 0x0
		private string effectName = "EF_Con_vernier"; // 0x78
		public bool IsNotAppeal; // 0x7C

		// RVA: 0x127E120 Offset: 0x127E120 VA: 0x127E120
		private void Start()
		{
			return;
		}

		// RVA: 0x127E124 Offset: 0x127E124 VA: 0x127E124
		private void Update()
		{
			return;
		}

		// RVA: 0x127E128 Offset: 0x127E128 VA: 0x127E128 Slot: 7
		protected override void OnInitialize(ValkyrieResource resource)
		{
			IsNotAppeal = true;
			overrideController["val_cmn_appeal"] = resource.appealOverrideResource.appeal;
			IsNotAppeal = true;
			if(resource.appealOverrideResource.appeal != null)
			{
				m_animClipLen_Appeal = resource.appealOverrideResource.appeal.length;
				IsNotAppeal = false;
			}
			m_model[0] = fighter;
			m_model[1] = gerwalk;
			m_model[2] = battroid;
		}

		// // RVA: 0x1279788 Offset: 0x1279788 VA: 0x1279788
		public void Enter()
		{
			this.StartCoroutineWatched(Co_Enter());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DA62C Offset: 0x6DA62C VA: 0x6DA62C
		// // RVA: 0x127E3A0 Offset: 0x127E3A0 VA: 0x127E3A0
		private IEnumerator Co_Enter()
		{
			//0x127E7F0
			Show();
			AppealStart();
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x127E7D0
				if(m_coAppealFinish != null)
					return true;
				return false;
			});
			m_IsEntered = true;
		}

		// // RVA: 0x127E44C Offset: 0x127E44C VA: 0x127E44C
		public void AppealStart()
		{
			if(m_coAppealFinish == null)
			{
				animator.Play(AppealStateHash, -1, 0);
				m_coAppealFinish = this.StartCoroutineWatched(Co_WaitAnimationEnd(AppealStateHash, () =>
				{
					//0x127E7E0
					m_coAppealFinish = null;
				}));
			}
		}

		// // RVA: 0x127C044 Offset: 0x127C044 VA: 0x127C044
		public FKGMGBHBNOC.HPJOCKGKNCC_Form GetCurrentForm()
		{
			if(fighter.activeSelf)
				return FKGMGBHBNOC.HPJOCKGKNCC_Form.MABDGNNOPCB_Fighter;
			if(gerwalk.activeSelf)
				return FKGMGBHBNOC.HPJOCKGKNCC_Form.MOGAKDMDCJB_Gerwalk;
			if(battroid.activeSelf)
				return FKGMGBHBNOC.HPJOCKGKNCC_Form.GBLPNIGCPAP_Battroid;
			return FKGMGBHBNOC.HPJOCKGKNCC_Form.AEFCOHJBLPO_Num;
		}

		// // RVA: 0x127E5A4 Offset: 0x127E5A4 VA: 0x127E5A4
		private void Show()
		{
			DisableEffect(effectName);
			Renderer[] rs = GetComponentsInChildren<Renderer>();
			for(int i = 0; i < rs.Length; i++)
			{
				rs[i].enabled = true;
			}
		}

		// RVA: 0x127CC58 Offset: 0x127CC58 VA: 0x127CC58
		public void Hide()
		{
			Renderer[] rs = GetComponentsInChildren<Renderer>();
			for(int i = 0; i < rs.Length; i++)
			{
				rs[i].enabled = false;
			}
		}

		// // RVA: 0x127E684 Offset: 0x127E684 VA: 0x127E684
		// public bool IsPlayingAppealAnim() { }

		// // RVA: 0x127E694 Offset: 0x127E694 VA: 0x127E694
		// public bool IsEntered() { }

		// // RVA: 0x127E69C Offset: 0x127E69C VA: 0x127E69C
		// public bool IsLoaded() { }
	}
}
