using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class MenuValkyrieObject : ValkyrieObject
	{
		public static readonly int[] WaitStateHash = new int[3] {
			Animator.StringToHash("F_Wait"),
			Animator.StringToHash("G_Wait"),
			Animator.StringToHash("B_Wait")
		}; // 0x0
		public static readonly int[] ChangeStateHash = new int[3] {
			Animator.StringToHash("F_to_G"),
			Animator.StringToHash("G_to_B"),
			Animator.StringToHash("B_to_F")
		}; // 0x4
		public static readonly int UnlockStateHash = Animator.StringToHash("Unlock"); // 0x8
		private GameObject[] m_model = new GameObject[3]; // 0x40
		private int m_form; // 0x44
		private Coroutine m_coChangeFinish; // 0x48
		private Coroutine m_coUnlockFinish; // 0x4C
		private static readonly string[] s_formTypeIdlow = new string[3] {
			"f", "g", "b"
		}; // 0xC
		private float[] m_animClipLen_Wait = new float[3]; // 0x50
		private float[] m_animClipLen_Change = new float[3]; // 0x54
		private float m_animClipLen_Unlock; // 0x58
		private bool m_useEffects; // 0x5C
		private List<string> m_effectNameList = new List<string>(); // 0x60

		protected override bool usingEffectFactory { get { return m_useEffects; } } //0x11144EC
		protected override bool usingQualitySetting { get { return false; } } //0x11144F4

		//// RVA: 0x11144FC Offset: 0x11144FC VA: 0x11144FC
		public void AddUseEffectName(string effectName)
		{
			m_useEffects = true;
			m_effectNameList.Add(effectName);
		}

		//// RVA: 0x1114584 Offset: 0x1114584 VA: 0x1114584
		public void DisableEffect(string effectName)
		{
			m_useEffects = false;
			effectFactories.Disable(effectName);
		}

		// RVA: 0x11145C8 Offset: 0x11145C8 VA: 0x11145C8 Slot: 7
		protected override void OnInitialize(ValkyrieResource resource)
		{
			for(int i = 0; i < 3; i++)
			{
				overrideController["val_cmn_me_" + s_formTypeIdlow[i] + "_wait"] = resource.menuOverrideResource.wait[i];
				overrideController["val_cmn_me_" + s_formTypeIdlow[i] + "_to_" + s_formTypeIdlow[(i + 1) % 3]] = resource.menuOverrideResource.change[i];
				m_animClipLen_Wait[i] = resource.menuOverrideResource.wait[i].length;
				m_animClipLen_Change[i] = resource.menuOverrideResource.change[i].length;
			}
			overrideController["val_cmn_get"] = resource.unlockOverrideResource.unlock;
			m_animClipLen_Unlock = resource.unlockOverrideResource.unlock.length;
			m_model[0] = fighter;
			m_model[1] = gerwalk;
			m_model[2] = battroid;
		}

		// RVA: 0x1114B90 Offset: 0x1114B90 VA: 0x1114B90 Slot: 6
		protected override void InstantiateEffect()
		{
			if(m_effectNameList.Count < 1)
			{
				effectFactories.InstantiateAll();
				return;
			}
			for(int i = 0; i < m_effectNameList.Count; i++)
			{
				effectFactories.Instantiate(m_effectNameList[i]);
			}
		}

		//// RVA: 0x1114CE4 Offset: 0x1114CE4 VA: 0x1114CE4 Slot: 8
		protected override void OnRelease()
		{
			for(int i = 0; i < m_model.Length; i++)
			{
				m_model[i] = null;
			}
			m_useEffects = true;
			m_effectNameList.Clear();
		}

		//// RVA: 0x1114DCC Offset: 0x1114DCC VA: 0x1114DCC
		public void SetForm(int form)
		{
			m_form = form;
			for(int i = 0; i < m_model.Length; i++)
			{
				if(m_model[i] != null)
				{
					m_model[i].SetActive(form == i);
				}
			}
		}

		//// RVA: 0x1114FE4 Offset: 0x1114FE4 VA: 0x1114FE4
		public void Change(int form)
		{
			if(m_coChangeFinish != null)
			{
				this.StopCoroutineWatched(m_coChangeFinish);
				m_coChangeFinish = null;
			}
			form = (form + 2) % 3;
			if(m_form != form)
			{
				SetForm(form);
				m_form = form;
			}
			animator.Play(ChangeStateHash[m_form], -1, 0);
			m_coChangeFinish = this.StartCoroutineWatched(Co_WaitAnimationEnd(ChangeStateHash[m_form], () => {
				//0x1115A30
				m_coChangeFinish = null;
				SetForm((m_form + 1) % 3);
			}));
		}

		//// RVA: 0x11151FC Offset: 0x11151FC VA: 0x11151FC
		public float GetChangeAnimLength()
		{
			return m_animClipLen_Change[m_form];
		}

		//// RVA: 0x1115244 Offset: 0x1115244 VA: 0x1115244
		public void Unlock()
		{
			if(m_coUnlockFinish == null)
			{
				animator.Play(UnlockStateHash, -1, 0);
				m_coUnlockFinish = this.StartCoroutineWatched(Co_WaitAnimationEnd(UnlockStateHash, () =>
				{
					//0x1115A5C
					m_coUnlockFinish = null;
				}));
			}
		}

		//// RVA: 0x111539C Offset: 0x111539C VA: 0x111539C
		//public void Watch() { }

		//// RVA: 0x11154F4 Offset: 0x11154F4 VA: 0x11154F4
		public void AnimSpeedChenge(float speed)
		{
			if (m_coUnlockFinish != null)
				return;
			animator.speed = speed;
		}

		//// RVA: 0x111553C Offset: 0x111553C VA: 0x111553C
		public bool IsPlayingUnlockAnim()
		{
			return m_coUnlockFinish != null;
		}

		//[CompilerGeneratedAttribute] // RVA: 0x73C188 Offset: 0x73C188 VA: 0x73C188
		//// RVA: 0x1115A5C Offset: 0x1115A5C VA: 0x1115A5C
		//private void <Unlock>b__25_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x73C198 Offset: 0x73C198 VA: 0x73C198
		//// RVA: 0x1115A68 Offset: 0x1115A68 VA: 0x1115A68
		//private void <Watch>b__26_0() { }
	}
}
