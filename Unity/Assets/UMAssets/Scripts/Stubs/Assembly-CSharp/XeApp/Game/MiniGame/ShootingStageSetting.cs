using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.MiniGame
{
	public class ShootingStageSetting : MonoBehaviour
	{
		public GameObject m_rootPos;
		public GameObject m_editorRoot;
		public List<ShootingTask> m_editList;
		public int stageNum;
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}
	}
}
