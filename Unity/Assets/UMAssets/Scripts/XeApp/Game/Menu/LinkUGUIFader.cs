using UnityEngine;
using UnityEngine.UI;
using XeSys.uGUI;

namespace XeApp.Game.Menu
{
	public class LinkUGUIFader : MonoBehaviour
	{
		[SerializeField]
		private Image mImage; // 0xC
		private UGUIFader mTargetFader; // 0x10

		// RVA: 0x1541398 Offset: 0x1541398 VA: 0x1541398
		public void SetTargetFader(UGUIFader a_fader)
		{
			if(a_fader != null)
			{
				mTargetFader = a_fader;
				Update();
			}
			else
			{
				mImage.enabled = false;
			}
		}

		// RVA: 0x1541460 Offset: 0x1541460 VA: 0x1541460
		private void Update()
		{
			Image i = null;
			if(mTargetFader != null)
			{
				i = mTargetFader.GetImage();
			}
			if(i == null)
			{
				mImage.enabled = false;
				return;
			}
			mImage.enabled = i.enabled;
			mImage.color = i.color;
		}
	}
}
