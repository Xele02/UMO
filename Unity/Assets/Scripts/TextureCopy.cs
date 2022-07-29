
using UnityEngine;

static class TextureHelper
{
	static public Texture2D Copy(Texture2D texture, int newWidth = -1, int newHeight = -1, Material mat = null)
	{
		// Create a temporary RenderTexture of the same size as the texture
		RenderTexture tmp = RenderTexture.GetTemporary(
							texture.width,
							texture.height,
							0,
							RenderTextureFormat.ARGB32,
							RenderTextureReadWrite.Linear);


		// Backup the currently set RenderTexture
		RenderTexture previous = RenderTexture.active;


		// Set the current RenderTexture to the temporary one we created
		RenderTexture.active = tmp;
		GL.Clear(true, true, Color.clear);

		// Blit the pixels on texture to the RenderTexture

		if (mat != null)
			Graphics.Blit(texture, tmp, mat);
		else
			Graphics.Blit(texture, tmp);

		if(newWidth != -1 || newHeight != -1)
		{
			RenderTexture tmp2 = RenderTexture.GetTemporary(
								newWidth,
								newHeight,
								0,
								RenderTextureFormat.ARGB32,
								RenderTextureReadWrite.Linear, 1);

			RenderTexture.active = tmp2;
			GL.Clear(true, true, Color.clear);
			tmp.filterMode = FilterMode.Bilinear;
			Graphics.Blit(tmp, tmp2);

			RenderTexture.ReleaseTemporary(tmp);
			tmp = tmp2;
		}


		// Create a new readable Texture2D to copy the pixels to it
		Texture2D myTexture2D = new Texture2D(tmp.width, tmp.height, TextureFormat.ARGB32, false);


		// Copy the pixels from the RenderTexture to the new Texture
		myTexture2D.ReadPixels(new Rect(0, 0, tmp.width, tmp.height), 0, 0);
		myTexture2D.Apply();


		// Reset the active RenderTexture
		RenderTexture.active = previous;


		// Release the temporary RenderTexture
		RenderTexture.ReleaseTemporary(tmp);

		return myTexture2D;
	}
}
