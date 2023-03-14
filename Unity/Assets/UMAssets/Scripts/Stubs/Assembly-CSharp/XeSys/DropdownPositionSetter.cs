using UnityEngine;
using UnityEngine.UI;

namespace XeSys
{
	public class DropdownPositionSetter : MonoBehaviour
	{
		public Dropdown dropDown;
		public Scrollbar scrollbar;
		public int displayItemCount;
		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
