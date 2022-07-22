Shader "CriMana/Yuv2Rgb" {
	Properties {
		_MainTex  ("Texture", 2D)   = "white" {}
		Texture_y ("Texture Y", 2D) = "white" {}
		Texture_u ("Texture U", 2D) = "white" {}
		Texture_v ("Texture V", 2D) = "white" {}
	}

	SubShader {
		Tags {"Queue" = "Transparent"}

		pass {
			Blend Off

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#if defined(SHADER_API_PSP2) || defined(SHADER_API_PS3)
			// seems that ARB_precision_hint_fastest is not supported on these platforms.
			#else
			#pragma fragmentoption ARB_precision_hint_fastest
			#endif

			#include "UnityCG.cginc"

			sampler2D Texture_y;
			sampler2D Texture_u;
			sampler2D Texture_v;

			struct appdata {
				float4 vertex   : POSITION;
				half2  texcoord : TEXCOORD0;
			};

			struct v2f {
				float4   pos : SV_POSITION;
				half2     uv : TEXCOORD0;
			};

			float4 _MainTex_ST;

			v2f vert(appdata v)
			{
				v2f o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv  = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}

			static const fixed3x3 yuv_to_rgb = {
				{1.16438,      0.0,  1.59603},
				{1.16438, -0.39176, -0.81297},
				{1.16438,  2.01723,      0.0}
				};

			fixed4 frag(v2f i) : COLOR
			{
				fixed3 yuv = {
					(tex2D(Texture_y, i.uv).a - 0.06275),
					(tex2D(Texture_u, i.uv).a - 0.50196),
					(tex2D(Texture_v, i.uv).a - 0.50196),
					};
				fixed4 color;
				color.rgb = mul(yuv_to_rgb, yuv);
				color.a   = 1.0;
				return color;
			}
			ENDCG
		}
	}
}
