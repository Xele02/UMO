using UnityEngine;

namespace XeApp.Game.Common
{
	public class ActionButton : ButtonBase
	{
		[SerializeField]
		protected string m_symbolName;
		[SerializeField]
		protected string m_exId;
		[SerializeField]
		protected string m_clickSeName;
		[SerializeField]
		protected bool m_childAnim;
		[SerializeField]
		protected string m_parentExId;
		[SerializeField]
		protected bool m_isRelativeSearch;
	}
}
