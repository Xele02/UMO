using UnityEngine.EventSystems;
using UnityEngine;

namespace XeApp.Core
{
	public class CustomInputModule : PointerInputModule
	{
		public override void Process()
		{
		}

		[SerializeField]
		private string m_HorizontalAxis;
		[SerializeField]
		private string m_VerticalAxis;
		[SerializeField]
		private string m_SubmitButton;
		[SerializeField]
		private string m_CancelButton;
		[SerializeField]
		private float m_InputActionsPerSecond;
		[SerializeField]
		private float m_RepeatDelay;
		[SerializeField]
		private bool m_ForceModuleActive;
	}
}
