using XeApp.Core;
using System;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Gacha
{
	public class GachaDirectionScene : MainSceneBase
	{
		[Serializable]
		private class Setting
		{
			[SerializeField]
			internal GachaDirectionQuartzTable quartzTable;
			[SerializeField]
			internal GachaDirectionOrbTable orbTable;
		}

		[SerializeField]
		private Canvas m_mainCanvas;
		[SerializeField]
		private GraphicRaycaster m_raycaster;
		[SerializeField]
		private Transform m_mainCanvasRoot;
		[SerializeField]
		private GachaDirectionObject m_modelObject;
		[SerializeField]
		private GachaDirectionCamera m_cameraObject;
		[SerializeField]
		private Setting m_settingRegular;
		[SerializeField]
		private Setting m_settingTutorial;
	}
}
