using UnityEngine;

namespace XeApp.Game.Common
{
	public class SpriteRendererAnime : KeyFrameAnime
	{
        protected override Vector3 GetEulerAngles()
        {
            TodoLogger.Log(0, "SpriteRendererAnime");
			return Vector3.zero;
        }

        protected override void Init()
        {
            TodoLogger.Log(0, "SpriteRendererAnime");
        }

        protected override void SetColor(Color color)
        {
            TodoLogger.Log(0, "SpriteRendererAnime");
        }

        protected override void SetEulerAngles(Vector3 eangle)
        {
            TodoLogger.Log(0, "SpriteRendererAnime");
        }

        protected override void SetPosition(Vector3 pos)
        {
            TodoLogger.Log(0, "SpriteRendererAnime");
        }

        protected override void SetScale(Vector3 scale)
        {
            TodoLogger.Log(0, "SpriteRendererAnime");
        }

        protected override void SetSprite(Sprite sprite)
        {
            TodoLogger.Log(0, "SpriteRendererAnime");
        }

        private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
	}
}
