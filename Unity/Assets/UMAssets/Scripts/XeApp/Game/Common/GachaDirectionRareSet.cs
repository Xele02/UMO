using System;
using System.Collections.Generic;
using mcrs;
using UnityEngine;
using XeApp.Game.Gacha;

namespace XeApp.Game.Common
{
	public class GachaDirectionRareSet : GachaDirectionAnimSetBase
	{
		private static readonly int State_Main = Animator.StringToHash("Rare_Main"); // 0x0
		[SerializeField]
		private List<Renderer> m_cardRenderers; // 0x18

		public Action onEndMainAnim { private get; set; } // 0x1C

		// // RVA: 0x1C1E9AC Offset: 0x1C1E9AC VA: 0x1C1E9AC Slot: 5
		protected override void OnSetup(DirectionInfo directionInfo)
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1C1BE30 Offset: 0x1C1BE30 VA: 0x1C1BE30
		public void ApplyCardTexture(Texture texture)
		{
			for(int i = 0; i < m_cardRenderers.Count; i++)
			{
				m_cardRenderers[i].material.SetTexture("_MainTex", texture);
			}
		}

		// RVA: 0x1C1BD44 Offset: 0x1C1BD44 VA: 0x1C1BD44
		public void ApplyCardMaterial(Material material)
		{
			for(int i = 0; i < m_cardRenderers.Count; i++)
			{
				m_cardRenderers[i].material = material;
			}
		}

		// RVA: 0x1C1CEEC Offset: 0x1C1CEEC VA: 0x1C1CEEC
		public void Begin()
		{
			SoundManager.Instance.sePlayerGacha.Play((int)cs_se_gacha.SE_GACHA_009);
			gameObject.SetActive(true);
			animator.Play(State_Main);
			WaitForAnimationEnd(() =>
			{
				//0x1C1EA64
				if(onEndMainAnim != null)
					onEndMainAnim();
			});
		}

		// RVA: 0x1C1D0E0 Offset: 0x1C1D0E0 VA: 0x1C1D0E0
		public void End()
		{
			SoundManager.Instance.sePlayerGacha.Play((int)cs_se_gacha.SE_GACHA_010);
			gameObject.SetActive(false);
		}
	}
}
