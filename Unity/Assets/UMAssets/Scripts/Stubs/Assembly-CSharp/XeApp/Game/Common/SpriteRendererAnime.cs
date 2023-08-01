using UnityEngine;

namespace XeApp.Game.Common
{
	public class SpriteRendererAnime : KeyFrameAnime
	{
        protected override Vector3 GetEulerAngles()
        {
            TodoLogger.LogError(0, "SpriteRendererAnime");
			return Vector3.zero;
        }

        protected override void Init()
        {
            TodoLogger.LogError(0, "SpriteRendererAnime");
        }

        protected override void SetColor(Color color)
        {
            TodoLogger.LogError(0, "SpriteRendererAnime");
        }

        protected override void SetEulerAngles(Vector3 eangle)
        {
            TodoLogger.LogError(0, "SpriteRendererAnime");
        }

        protected override void SetPosition(Vector3 pos)
        {
            TodoLogger.LogError(0, "SpriteRendererAnime");
        }

        protected override void SetScale(Vector3 scale)
        {
            TodoLogger.LogError(0, "SpriteRendererAnime");
        }

        protected override void SetSprite(Sprite sprite)
        {
            TodoLogger.LogError(0, "SpriteRendererAnime");
        }

        private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
	}
}
