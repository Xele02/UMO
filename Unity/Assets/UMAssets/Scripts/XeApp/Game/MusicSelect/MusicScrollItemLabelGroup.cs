using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MusicSelect
{
	public class MusicScrollItemLabelGroup : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup[] timeLabel; // 0xC
		[SerializeField]
		private CanvasGroup[] eventLabel; // 0x10
		[SerializeField]
		private CanvasGroup[] musicTypeLabel; // 0x14
		[SerializeField]
		private CanvasGroup[] playBoostLabel; // 0x18
		[SerializeField]
		private GameObject limitedSLiveLabel; // 0x1C

		// RVA: 0xC9EAE0 Offset: 0xC9EAE0 VA: 0xC9EAE0
		private void Awake()
		{
			DisableLimitedSLiveLabel();
			DisableTimeLabel();
			DisableEventLabel();
			DisableMusicTypeLabel();
			DisablePlayBoostLabel();
		}

		//// RVA: 0xC9EB44 Offset: 0xC9EB44 VA: 0xC9EB44
		public void DisableTimeLabel()
		{
			timeLabel[0].transform.parent.gameObject.SetActive(false);
			for(int i = 0; i < timeLabel.Length; i++)
			{
				timeLabel[i].alpha = 0;
			}
		}

		//// RVA: 0xC9EC8C Offset: 0xC9EC8C VA: 0xC9EC8C
		public void DisableEventLabel()
		{
			eventLabel[0].transform.parent.gameObject.SetActive(false);
			for (int i = 0; i < eventLabel.Length; i++)
			{
				eventLabel[i].alpha = 0;
			}
		}

		//// RVA: 0xC9EDD4 Offset: 0xC9EDD4 VA: 0xC9EDD4
		public void DisableMusicTypeLabel()
		{
			musicTypeLabel[0].transform.parent.gameObject.SetActive(false);
			for (int i = 0; i < musicTypeLabel.Length; i++)
			{
				musicTypeLabel[i].alpha = 0;
			}
		}

		//// RVA: 0xC9EF1C Offset: 0xC9EF1C VA: 0xC9EF1C
		public void DisablePlayBoostLabel()
		{
			playBoostLabel[0].transform.parent.gameObject.SetActive(false);
			for (int i = 0; i < playBoostLabel.Length; i++)
			{
				playBoostLabel[i].alpha = 0;
			}
		}

		//// RVA: 0xC9F064 Offset: 0xC9F064 VA: 0xC9F064
		public void SetTimeLabel(MusicSelectConsts.MusicTimeType label)
		{
			DisableTimeLabel();
			if ((int)label >= timeLabel.Length)
				return;
			timeLabel[(int)label].transform.parent.gameObject.SetActive(true);
			timeLabel[(int)label].alpha = 1;
		}

		//// RVA: 0xC9F1AC Offset: 0xC9F1AC VA: 0xC9F1AC
		public void SetEventLabel(MusicSelectConsts.EventType label)
		{
			DisableEventLabel();
			if ((int)label >= eventLabel.Length)
				return;
			eventLabel[(int)label].transform.parent.gameObject.SetActive(true);
			eventLabel[(int)label].alpha = 1;
		}

		//// RVA: 0xC9F2F4 Offset: 0xC9F2F4 VA: 0xC9F2F4
		public void SetMusicTypeLabel(MusicSelectConsts.MusicType label)
		{
			DisableMusicTypeLabel();
			if (label == 0)
			{
				musicTypeLabel[0].transform.parent.gameObject.SetActive(true);
			}
			else
			{
				if (musicTypeLabel.Length <= ((int)label - 1))
					return;
				musicTypeLabel[(int)label - 1].transform.parent.gameObject.SetActive(true);
				musicTypeLabel[(int)label - 1].alpha = 1;
			}
		}

		//// RVA: 0xC9F4EC Offset: 0xC9F4EC VA: 0xC9F4EC
		public void SetPlayBoostLabel(MusicSelectConsts.PlayBoostType label)
		{
			DisablePlayBoostLabel();
			if ((int)label >= playBoostLabel.Length)
				return;
			playBoostLabel[(int)label].transform.parent.gameObject.SetActive(true);
			playBoostLabel[(int)label].alpha = 1;
		}

		//// RVA: 0xC9F634 Offset: 0xC9F634 VA: 0xC9F634
		public void EnableLimitedSLiveLabel()
		{
			limitedSLiveLabel.SetActive(true);
		}

		//// RVA: 0xC9EB14 Offset: 0xC9EB14 VA: 0xC9EB14
		public void DisableLimitedSLiveLabel()
		{
			limitedSLiveLabel.SetActive(false);
		}
	}
}
