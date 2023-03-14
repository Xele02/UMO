using XeApp.Core;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Test
{
	public class DebugUnlockTestScene : MainSceneBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Dropdown m_diva_list;
		[SerializeField]
		private Dropdown m_cos_list;
		[SerializeField]
		private Dropdown m_val_list;
	}
}
