using mcrs;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class AccountRemoveTextWindow : MonoBehaviour
	{
		[SerializeField]
		private Text titleText; // 0xC
		[SerializeField]
		private Text contentText; // 0x10
		[SerializeField]
		private Image backGroundImage; // 0x14
		private InOutAnime _inOutAnime; // 0x18

		// RVA: 0x1434190 Offset: 0x1434190 VA: 0x1434190
		private void Awake()
		{
			if (backGroundImage != null)
				backGroundImage.enabled = false;
			_inOutAnime = GetComponentInChildren<InOutAnime>();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C9CFC Offset: 0x6C9CFC VA: 0x6C9CFC
		// RVA: 0x1434264 Offset: 0x1434264 VA: 0x1434264
		public IEnumerator Co_Show(string titleText, string contentText)
		{
			//0x1434700
			if(_inOutAnime != null)
			{
				this.titleText.text = titleText;
				this.contentText.text = contentText;
				if(!_inOutAnime.IsEnter)
				{
					backGroundImage.enabled = true;
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_000);
					bool isWait = true;
					_inOutAnime.Enter(false, () =>
					{
						//0x1434400
						isWait = false;
					});
					while (isWait)
						yield return null;
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C9D74 Offset: 0x6C9D74 VA: 0x6C9D74
		// RVA: 0x1434344 Offset: 0x1434344 VA: 0x1434344
		public IEnumerator Co_Close()
		{
			//0x1434424
			if(_inOutAnime != null)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_001);
				bool isWait = true;
				_inOutAnime.Leave(false, () =>
				{
					//0x1434414
					isWait = false;
				});
				while (isWait)
					yield return null;
				backGroundImage.enabled = false;
			}
		}
	}
}
