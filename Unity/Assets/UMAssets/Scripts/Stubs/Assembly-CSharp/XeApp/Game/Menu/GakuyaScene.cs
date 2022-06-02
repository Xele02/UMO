using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class GakuyaScene : TransitionRoot
	{
		[SerializeField]
		private float m_divaCameraRotDuration;
		[SerializeField]
		private float m_intimacyHintIntervalTime;
		[SerializeField]
		private float m_intimacyHintDispTime;
		[SerializeField]
		private RectTransform m_intimacyPresentEffectPos;
		[SerializeField]
		private Image m_imageDebugDivaHit;
		[SerializeField]
		private float m_durationCancelCostumeChange;
	}
}
