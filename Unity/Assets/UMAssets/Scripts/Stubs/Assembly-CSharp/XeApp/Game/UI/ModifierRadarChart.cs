using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.UI
{
	public class ModifierRadarChart : LayoutUGUIScriptBase, IMeshModifier
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }

		public void ModifyMesh(Mesh mesh)
		{
			throw new System.NotImplementedException();
		}

		public void ModifyMesh(VertexHelper verts)
		{
			throw new System.NotImplementedException();
		}

		[SerializeField]
		private int m_DataCount;
		[SerializeField]
		private float m_DrawSize;
		[SerializeField]
		private Vector2[] m_UVList;
		[SerializeField]
		private float m_AnimeTime;
	}
}
