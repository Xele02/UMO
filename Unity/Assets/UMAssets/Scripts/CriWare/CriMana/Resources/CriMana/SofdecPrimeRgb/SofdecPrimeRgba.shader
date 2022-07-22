// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "CriMana/SofdecPrimeRgba" {
	Properties {
		_MainTex ("Texture", 2D) = "white" {}
	}

	SubShader {
		Tags {"Queue" = "Transparent"}

		Pass {
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#if defined(SHADER_API_PSP2) || defined(SHADER_API_PS3)
			// seems that ARB_precision_hint_fastest is not supported on these platforms.
			#else
			#pragma fragmentoption ARB_precision_hint_fastest
			#endif

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			sampler2D TextureRgba;
			float4x4  MovieUvTransform;

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
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv  = mul(MovieUvTransform, float4(TRANSFORM_TEX(v.texcoord, _MainTex), 0.0, 1.0));
				return o;
			}
			
			fixed4 frag(v2f i) : COLOR
			{
				return tex2D(TextureRgba, i.uv);
			}
			ENDCG
		}
	}
}
