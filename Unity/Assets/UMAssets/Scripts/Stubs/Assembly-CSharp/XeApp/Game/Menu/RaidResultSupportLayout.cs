using XeSys.Gfx;
using UnityEngine;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class RaidResultSupportLayout : RaidResultEffectBaseLayout
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}

        public override IEnumerator StartAnime()
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerator EndAnime()
        {
            throw new System.NotImplementedException();
        }

        [SerializeField]
		protected RawImageEx[] m_imageDiva;
	}
}
