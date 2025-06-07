using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using XeSys;

namespace XeApp.Game.Menu
{
	public abstract class RaidResultEffectBaseLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		protected NumberBase damageNum1; // 0x14
		[SerializeField]
		protected NumberBase damageNum2; // 0x18
		[SerializeField]
		protected NumberBase damageNum3; // 0x1C
		[SerializeField]
		protected Text m_bossName; // 0x20
		protected AbsoluteLayout m_layoutRoot; // 0x24
		protected AbsoluteLayout m_layoutRank; // 0x28
		protected bool m_isSkiped; // 0x2C
		private Matrix23 m_identity; // 0x30

		// // RVA: 0x1BDF4B0 Offset: 0x1BDF4B0 VA: 0x1BDF4B0
		public void Setup(int rank, string bossName, int damage)
		{
			damageNum1.SetNumber(damage, 0);
			damageNum2.SetNumber(damage, 0);
			damageNum3.SetNumber(damage, 0);
			m_bossName.text = bossName;
			m_layoutRank.StartChildrenAnimGoStop(rank.ToString("D2"));
		}

		// // RVA: 0x1BDF610 Offset: 0x1BDF610 VA: 0x1BDF610
		public void Hide()
		{
			m_layoutRoot.enabled = false;
		}

		// // RVA: 0x1BDF648 Offset: 0x1BDF648 VA: 0x1BDF648
		public void Show()
		{
			m_layoutRoot.enabled = true;
		}

		// // RVA: -1 Offset: -1 Slot: 6
		public abstract IEnumerator StartAnime();

		// // RVA: -1 Offset: -1 Slot: 7
		public abstract IEnumerator EndAnime();

		// [IteratorStateMachineAttribute] // RVA: 0x71F95C Offset: 0x71F95C VA: 0x71F95C
		// // RVA: 0x1BD9B9C Offset: 0x1BD9B9C VA: 0x1BD9B9C
		protected IEnumerator Co_WaitLabel(AbsoluteLayout layout, string label, bool enableSkip/* = True*/)
		{
			//0x1BDF8C8
			while(!m_isSkiped || !enableSkip)
			{
				if(layout.GetView(0).FrameAnimation.FrameCount >= layout.GetView(0).FrameAnimation.SearchLabelFrame("label"))
					break;
				yield return null;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71F9D4 Offset: 0x71F9D4 VA: 0x71F9D4
		// // RVA: 0x1BD95DC Offset: 0x1BD95DC VA: 0x1BD95DC
		protected IEnumerator Co_WaitAnim(AbsoluteLayout layout, bool enableSkip/* = True*/)
		{
			//0x1BDF6C4
			while(layout.IsPlayingChildren())
			{
				if(!m_isSkiped || !enableSkip)
					yield return null;
				else
				{
					layout.UpdateAllAnimation(TimeWrapper.deltaTime *2, false);
					layout.UpdateAll(m_identity, Color.white);
				}
			}
		}
	}
}
