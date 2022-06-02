using UnityEngine;

namespace XeSys.Gfx
{
	public class LayoutUGUIRuntime : MonoBehaviour
	{
		[SerializeField]
		private string m_layoutPath;
		[SerializeField]
		private string m_uvlistPath;
		[SerializeField]
		private string m_texturePath;
		[SerializeField]
		private string[] m_uvlistPathList;
		[SerializeField]
		private string[] m_texturePathList;
		[SerializeField]
		private string m_animListPath;
		[SerializeField]
		private Font m_font;
		[SerializeField]
		private bool m_isTextureSplit;
		[SerializeField]
		private bool m_isUseImage;
		[SerializeField]
		private bool m_isLayoutAutoLoad;
		[SerializeField]
		private bool m_isAutoStart;
		[SerializeField]
		private bool m_isPrefabTextureDelete;
		[SerializeField]
		private bool m_isActiveCheck;
		[SerializeField]
		private float m_timeScale;
		[SerializeField]
		private GameObject[] m_ActiveObjLsit;
		[SerializeField]
		private Color m_testColor;
	}
}
