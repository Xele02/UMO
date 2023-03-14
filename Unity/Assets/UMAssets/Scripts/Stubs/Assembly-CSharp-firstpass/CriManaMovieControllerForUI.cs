using UnityEngine.UI;

namespace CriWare
{
	public class CriManaMovieControllerForUI : CriManaMovieMaterial
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		public Graphic target;
		public bool useOriginalMaterial;
	}
}
