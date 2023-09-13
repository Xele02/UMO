using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingUtility
	{
		// RVA: 0xC8E994 Offset: 0xC8E994 VA: 0xC8E994
		public static bool CheckOutTheScreen(RectTransform screen, Vector3 pos, float width, float height)
		{
			Vector2 s = screen.sizeDelta;
			if ((pos.x <= -s.x * 0.5f - width) || (s.x * 0.5f + width < pos.x) || (pos.y <= -s.y * 0.5f - height))
				return true;
			return pos.y * 0.5f + height < pos.y;
		}

		//// RVA: 0xC92C0C Offset: 0xC92C0C VA: 0xC92C0C
		public static bool CheckInTheScreen(RectTransform screen, Vector3 pos, float width, float height)
		{
			if (screen.sizeDelta.x * 0.5f - width < pos.x || pos.x <= width - screen.sizeDelta.x * 0.5f ||
				screen.sizeDelta.y * 0.5f - height < pos.y)
				return false;
			return height - screen.sizeDelta.y * 0.5f < pos.y;
		}

		//// RVA: 0xC8E308 Offset: 0xC8E308 VA: 0xC8E308
		public static Vector3 PosAfterMovement(float elapsedTime, Vector3 position, Vector3 moveDir, float speed)
		{
			return position + moveDir * speed * elapsedTime;
		}
	}
}
