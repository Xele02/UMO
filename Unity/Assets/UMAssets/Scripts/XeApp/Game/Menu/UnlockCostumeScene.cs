using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class UnlockCostumeScene : TransitionRoot
	{
		private class CameraController
		{
			public Camera camera; // 0x8
			public Animator animator; // 0xC
			public Transform pos; // 0x10
			public ObjectPositionAdjuster adjuster; // 0x14
			public FlexibleCameraChanger flexible_changer; // 0x18
			public RenderTexture rendererTexture; // 0x1C
		}

		private class EffectController
		{
			public GameObject obj; // 0x8
			public Animator animator; // 0xC

			//// RVA: 0x1258358 Offset: 0x1258358 VA: 0x1258358
			//public void Init() { }
		}

		public class CostumeData
		{
			public int id = -1; // 0x8
			public int color_id; // 0xC
		}

		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private ScriptableObject m_CameraParam;
	}
}
