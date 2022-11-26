using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	[RequireComponent(typeof(LineRenderer))] // RVA: 0x650E60 Offset: 0x650E60 VA: 0x650E60
	public class EnemyTargetSight : MonoBehaviour
	{
		private LineRenderer m_renderer; // 0xC
		private static readonly Vector3 m_endPointOffset = new Vector3(-48, 26, 0); // 0x0
		private const float ZPosition = 50;

		// RVA: 0x155E69C Offset: 0x155E69C VA: 0x155E69C
		public void Initialize()
		{
			m_renderer = GetComponent<LineRenderer>();
			m_renderer.SetPosition(0, new Vector3(252, -132, 50));
			m_renderer.SetPosition(1, new Vector3(252, -132, 50));
			m_renderer.enabled = false;
		}

		//// RVA: 0x155E7F8 Offset: 0x155E7F8 VA: 0x155E7F8
		public void Show()
		{
			m_renderer.enabled = true;
		}

		//// RVA: 0x155E828 Offset: 0x155E828 VA: 0x155E828
		public void Hide()
		{
			m_renderer.enabled = false;
		}

		//// RVA: 0x155E858 Offset: 0x155E858 VA: 0x155E858
		public void UpdateTargetPosition(Vector3 position)
		{
			m_renderer.SetPosition(1, position + m_endPointOffset);
		}
	}
}
